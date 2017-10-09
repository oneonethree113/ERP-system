<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_QCinsert
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
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.txtResult = New System.Windows.Forms.TextBox
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboCocde = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox_Search = New System.Windows.Forms.GroupBox
        Me.txt_S_PONo = New System.Windows.Forms.TextBox
        Me.cmd_S_PONo = New System.Windows.Forms.Button
        Me.SLabel_7 = New System.Windows.Forms.Label
        Me.txt_S_CV = New System.Windows.Forms.TextBox
        Me.cmdShow = New System.Windows.Forms.Button
        Me.cmd_S_CV = New System.Windows.Forms.Button
        Me.SLabel_4 = New System.Windows.Forms.Label
        Me.txt_S_FA = New System.Windows.Forms.TextBox
        Me.cmd_S_FA = New System.Windows.Forms.Button
        Me.txt_S_PV = New System.Windows.Forms.TextBox
        Me.cmd_S_PV = New System.Windows.Forms.Button
        Me.txt_S_ItmNo = New System.Windows.Forms.TextBox
        Me.cmd_S_ItmNo = New System.Windows.Forms.Button
        Me.txt_S_SCNo = New System.Windows.Forms.TextBox
        Me.cmd_S_SCNo = New System.Windows.Forms.Button
        Me.txt_S_CustPONo = New System.Windows.Forms.TextBox
        Me.cmd_S_CustPONo = New System.Windows.Forms.Button
        Me.SLabel_8 = New System.Windows.Forms.Label
        Me.txt_S_SecCustAll = New System.Windows.Forms.TextBox
        Me.cmd_S_SecCustAll = New System.Windows.Forms.Button
        Me.txt_S_PriCustAll = New System.Windows.Forms.TextBox
        Me.cmd_S_PriCustAll = New System.Windows.Forms.Button
        Me.txtPOShipDateTo = New System.Windows.Forms.MaskedTextBox
        Me.Label41 = New System.Windows.Forms.Label
        Me.txtPOShipDateFm = New System.Windows.Forms.MaskedTextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.SLabel_5 = New System.Windows.Forms.Label
        Me.SLabel_3 = New System.Windows.Forms.Label
        Me.SLabel_9 = New System.Windows.Forms.Label
        Me.SLabel_6 = New System.Windows.Forms.Label
        Me.SLabel_2 = New System.Windows.Forms.Label
        Me.SLabel_1 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.dg_Header = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.chk_day1 = New System.Windows.Forms.CheckBox
        Me.chk_day2 = New System.Windows.Forms.CheckBox
        Me.chk_day3 = New System.Windows.Forms.CheckBox
        Me.chk_day4 = New System.Windows.Forms.CheckBox
        Me.chk_day5 = New System.Windows.Forms.CheckBox
        Me.chk_day7 = New System.Windows.Forms.CheckBox
        Me.chk_day6 = New System.Windows.Forms.CheckBox
        Me.txt_CYdate = New System.Windows.Forms.MaskedTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_SZdate = New System.Windows.Forms.MaskedTextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cbo_year = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.opt_genbyPV = New System.Windows.Forms.RadioButton
        Me.opt_genbyCV = New System.Windows.Forms.RadioButton
        Me.opt_genbyFA = New System.Windows.Forms.RadioButton
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.opt_samphandle2 = New System.Windows.Forms.RadioButton
        Me.opt_samphandle1 = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.opt_insptyp5 = New System.Windows.Forms.RadioButton
        Me.opt_insptyp4 = New System.Windows.Forms.RadioButton
        Me.opt_insptyp3 = New System.Windows.Forms.RadioButton
        Me.opt_insptyp2 = New System.Windows.Forms.RadioButton
        Me.opt_insptyp1 = New System.Windows.Forms.RadioButton
        Me.cmdApply = New System.Windows.Forms.Button
        Me.txtRmk = New System.Windows.Forms.TextBox
        Me.cmdSelectAll = New System.Windows.Forms.Button
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cbo_week = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.dg_Detail = New System.Windows.Forms.DataGridView
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox_Search.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dg_Header, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.dg_Detail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(12, 29)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(949, 561)
        Me.TabControl1.TabIndex = 285
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtResult)
        Me.TabPage1.Controls.Add(Me.txtCoNam)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.cboCocde)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.GroupBox_Search)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(941, 535)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "(1) Search"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtResult
        '
        Me.txtResult.BackColor = System.Drawing.Color.White
        Me.txtResult.ForeColor = System.Drawing.Color.Black
        Me.txtResult.Location = New System.Drawing.Point(6, 362)
        Me.txtResult.Multiline = True
        Me.txtResult.Name = "txtResult"
        Me.txtResult.ReadOnly = True
        Me.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtResult.Size = New System.Drawing.Size(704, 156)
        Me.txtResult.TabIndex = 46
        '
        'txtCoNam
        '
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.Location = New System.Drawing.Point(283, 16)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.Size = New System.Drawing.Size(302, 20)
        Me.txtCoNam.TabIndex = 43
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(192, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 13)
        Me.Label6.TabIndex = 45
        Me.Label6.Text = "Company Name:"
        '
        'cboCocde
        '
        Me.cboCocde.FormattingEnabled = True
        Me.cboCocde.Location = New System.Drawing.Point(102, 15)
        Me.cboCocde.Name = "cboCocde"
        Me.cboCocde.Size = New System.Drawing.Size(70, 21)
        Me.cboCocde.TabIndex = 42
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 13)
        Me.Label7.TabIndex = 44
        Me.Label7.Text = "Company Code:"
        '
        'GroupBox_Search
        '
        Me.GroupBox_Search.Controls.Add(Me.txt_S_PONo)
        Me.GroupBox_Search.Controls.Add(Me.cmd_S_PONo)
        Me.GroupBox_Search.Controls.Add(Me.SLabel_7)
        Me.GroupBox_Search.Controls.Add(Me.txt_S_CV)
        Me.GroupBox_Search.Controls.Add(Me.cmdShow)
        Me.GroupBox_Search.Controls.Add(Me.cmd_S_CV)
        Me.GroupBox_Search.Controls.Add(Me.SLabel_4)
        Me.GroupBox_Search.Controls.Add(Me.txt_S_FA)
        Me.GroupBox_Search.Controls.Add(Me.cmd_S_FA)
        Me.GroupBox_Search.Controls.Add(Me.txt_S_PV)
        Me.GroupBox_Search.Controls.Add(Me.cmd_S_PV)
        Me.GroupBox_Search.Controls.Add(Me.txt_S_ItmNo)
        Me.GroupBox_Search.Controls.Add(Me.cmd_S_ItmNo)
        Me.GroupBox_Search.Controls.Add(Me.txt_S_SCNo)
        Me.GroupBox_Search.Controls.Add(Me.cmd_S_SCNo)
        Me.GroupBox_Search.Controls.Add(Me.txt_S_CustPONo)
        Me.GroupBox_Search.Controls.Add(Me.cmd_S_CustPONo)
        Me.GroupBox_Search.Controls.Add(Me.SLabel_8)
        Me.GroupBox_Search.Controls.Add(Me.txt_S_SecCustAll)
        Me.GroupBox_Search.Controls.Add(Me.cmd_S_SecCustAll)
        Me.GroupBox_Search.Controls.Add(Me.txt_S_PriCustAll)
        Me.GroupBox_Search.Controls.Add(Me.cmd_S_PriCustAll)
        Me.GroupBox_Search.Controls.Add(Me.txtPOShipDateTo)
        Me.GroupBox_Search.Controls.Add(Me.Label41)
        Me.GroupBox_Search.Controls.Add(Me.txtPOShipDateFm)
        Me.GroupBox_Search.Controls.Add(Me.Label30)
        Me.GroupBox_Search.Controls.Add(Me.Label16)
        Me.GroupBox_Search.Controls.Add(Me.SLabel_5)
        Me.GroupBox_Search.Controls.Add(Me.SLabel_3)
        Me.GroupBox_Search.Controls.Add(Me.SLabel_9)
        Me.GroupBox_Search.Controls.Add(Me.SLabel_6)
        Me.GroupBox_Search.Controls.Add(Me.SLabel_2)
        Me.GroupBox_Search.Controls.Add(Me.SLabel_1)
        Me.GroupBox_Search.Location = New System.Drawing.Point(6, 42)
        Me.GroupBox_Search.Name = "GroupBox_Search"
        Me.GroupBox_Search.Size = New System.Drawing.Size(704, 314)
        Me.GroupBox_Search.TabIndex = 40
        Me.GroupBox_Search.TabStop = False
        Me.GroupBox_Search.Text = "Search Criteria"
        '
        'txt_S_PONo
        '
        Me.txt_S_PONo.Location = New System.Drawing.Point(188, 174)
        Me.txt_S_PONo.Name = "txt_S_PONo"
        Me.txt_S_PONo.Size = New System.Drawing.Size(500, 20)
        Me.txt_S_PONo.TabIndex = 88
        '
        'cmd_S_PONo
        '
        Me.cmd_S_PONo.Location = New System.Drawing.Point(138, 175)
        Me.cmd_S_PONo.Name = "cmd_S_PONo"
        Me.cmd_S_PONo.Size = New System.Drawing.Size(45, 19)
        Me.cmd_S_PONo.TabIndex = 87
        Me.cmd_S_PONo.Text = "＞＞"
        '
        'SLabel_7
        '
        Me.SLabel_7.AutoSize = True
        Me.SLabel_7.Location = New System.Drawing.Point(10, 177)
        Me.SLabel_7.Name = "SLabel_7"
        Me.SLabel_7.Size = New System.Drawing.Size(62, 13)
        Me.SLabel_7.TabIndex = 86
        Me.SLabel_7.Text = "PO Number"
        '
        'txt_S_CV
        '
        Me.txt_S_CV.Location = New System.Drawing.Point(188, 104)
        Me.txt_S_CV.Name = "txt_S_CV"
        Me.txt_S_CV.Size = New System.Drawing.Size(500, 20)
        Me.txt_S_CV.TabIndex = 85
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(306, 285)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(75, 23)
        Me.cmdShow.TabIndex = 41
        Me.cmdShow.Text = "Search"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'cmd_S_CV
        '
        Me.cmd_S_CV.Location = New System.Drawing.Point(138, 104)
        Me.cmd_S_CV.Name = "cmd_S_CV"
        Me.cmd_S_CV.Size = New System.Drawing.Size(45, 19)
        Me.cmd_S_CV.TabIndex = 84
        Me.cmd_S_CV.Text = "＞＞"
        '
        'SLabel_4
        '
        Me.SLabel_4.AutoSize = True
        Me.SLabel_4.Location = New System.Drawing.Point(10, 107)
        Me.SLabel_4.Name = "SLabel_4"
        Me.SLabel_4.Size = New System.Drawing.Size(21, 13)
        Me.SLabel_4.TabIndex = 83
        Me.SLabel_4.Text = "CV"
        '
        'txt_S_FA
        '
        Me.txt_S_FA.Location = New System.Drawing.Point(188, 126)
        Me.txt_S_FA.Name = "txt_S_FA"
        Me.txt_S_FA.Size = New System.Drawing.Size(500, 20)
        Me.txt_S_FA.TabIndex = 77
        '
        'cmd_S_FA
        '
        Me.cmd_S_FA.Location = New System.Drawing.Point(138, 127)
        Me.cmd_S_FA.Name = "cmd_S_FA"
        Me.cmd_S_FA.Size = New System.Drawing.Size(45, 19)
        Me.cmd_S_FA.TabIndex = 76
        Me.cmd_S_FA.Text = "＞＞"
        '
        'txt_S_PV
        '
        Me.txt_S_PV.Location = New System.Drawing.Point(188, 80)
        Me.txt_S_PV.Name = "txt_S_PV"
        Me.txt_S_PV.Size = New System.Drawing.Size(500, 20)
        Me.txt_S_PV.TabIndex = 75
        '
        'cmd_S_PV
        '
        Me.cmd_S_PV.Location = New System.Drawing.Point(138, 80)
        Me.cmd_S_PV.Name = "cmd_S_PV"
        Me.cmd_S_PV.Size = New System.Drawing.Size(45, 19)
        Me.cmd_S_PV.TabIndex = 74
        Me.cmd_S_PV.Text = "＞＞"
        '
        'txt_S_ItmNo
        '
        Me.txt_S_ItmNo.Location = New System.Drawing.Point(188, 222)
        Me.txt_S_ItmNo.Name = "txt_S_ItmNo"
        Me.txt_S_ItmNo.Size = New System.Drawing.Size(500, 20)
        Me.txt_S_ItmNo.TabIndex = 73
        '
        'cmd_S_ItmNo
        '
        Me.cmd_S_ItmNo.Location = New System.Drawing.Point(138, 222)
        Me.cmd_S_ItmNo.Name = "cmd_S_ItmNo"
        Me.cmd_S_ItmNo.Size = New System.Drawing.Size(45, 19)
        Me.cmd_S_ItmNo.TabIndex = 72
        Me.cmd_S_ItmNo.Text = "＞＞"
        '
        'txt_S_SCNo
        '
        Me.txt_S_SCNo.Location = New System.Drawing.Point(188, 150)
        Me.txt_S_SCNo.Name = "txt_S_SCNo"
        Me.txt_S_SCNo.Size = New System.Drawing.Size(500, 20)
        Me.txt_S_SCNo.TabIndex = 69
        '
        'cmd_S_SCNo
        '
        Me.cmd_S_SCNo.Location = New System.Drawing.Point(138, 150)
        Me.cmd_S_SCNo.Name = "cmd_S_SCNo"
        Me.cmd_S_SCNo.Size = New System.Drawing.Size(45, 19)
        Me.cmd_S_SCNo.TabIndex = 68
        Me.cmd_S_SCNo.Text = "＞＞"
        '
        'txt_S_CustPONo
        '
        Me.txt_S_CustPONo.Location = New System.Drawing.Point(188, 197)
        Me.txt_S_CustPONo.Name = "txt_S_CustPONo"
        Me.txt_S_CustPONo.Size = New System.Drawing.Size(500, 20)
        Me.txt_S_CustPONo.TabIndex = 67
        '
        'cmd_S_CustPONo
        '
        Me.cmd_S_CustPONo.Location = New System.Drawing.Point(138, 197)
        Me.cmd_S_CustPONo.Name = "cmd_S_CustPONo"
        Me.cmd_S_CustPONo.Size = New System.Drawing.Size(45, 19)
        Me.cmd_S_CustPONo.TabIndex = 66
        Me.cmd_S_CustPONo.Text = "＞＞"
        '
        'SLabel_8
        '
        Me.SLabel_8.AutoSize = True
        Me.SLabel_8.Location = New System.Drawing.Point(10, 201)
        Me.SLabel_8.Name = "SLabel_8"
        Me.SLabel_8.Size = New System.Drawing.Size(86, 13)
        Me.SLabel_8.TabIndex = 65
        Me.SLabel_8.Text = "Customer PO No"
        '
        'txt_S_SecCustAll
        '
        Me.txt_S_SecCustAll.Location = New System.Drawing.Point(188, 58)
        Me.txt_S_SecCustAll.Name = "txt_S_SecCustAll"
        Me.txt_S_SecCustAll.Size = New System.Drawing.Size(500, 20)
        Me.txt_S_SecCustAll.TabIndex = 64
        '
        'cmd_S_SecCustAll
        '
        Me.cmd_S_SecCustAll.Location = New System.Drawing.Point(138, 58)
        Me.cmd_S_SecCustAll.Name = "cmd_S_SecCustAll"
        Me.cmd_S_SecCustAll.Size = New System.Drawing.Size(45, 19)
        Me.cmd_S_SecCustAll.TabIndex = 63
        Me.cmd_S_SecCustAll.Text = "＞＞"
        '
        'txt_S_PriCustAll
        '
        Me.txt_S_PriCustAll.Location = New System.Drawing.Point(188, 35)
        Me.txt_S_PriCustAll.Name = "txt_S_PriCustAll"
        Me.txt_S_PriCustAll.Size = New System.Drawing.Size(500, 20)
        Me.txt_S_PriCustAll.TabIndex = 62
        '
        'cmd_S_PriCustAll
        '
        Me.cmd_S_PriCustAll.Location = New System.Drawing.Point(138, 35)
        Me.cmd_S_PriCustAll.Name = "cmd_S_PriCustAll"
        Me.cmd_S_PriCustAll.Size = New System.Drawing.Size(45, 19)
        Me.cmd_S_PriCustAll.TabIndex = 61
        Me.cmd_S_PriCustAll.Text = "＞＞"
        '
        'txtPOShipDateTo
        '
        Me.txtPOShipDateTo.Location = New System.Drawing.Point(414, 250)
        Me.txtPOShipDateTo.Mask = "##/##/####"
        Me.txtPOShipDateTo.Name = "txtPOShipDateTo"
        Me.txtPOShipDateTo.Size = New System.Drawing.Size(164, 20)
        Me.txtPOShipDateTo.TabIndex = 24
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(382, 253)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(26, 13)
        Me.Label41.TabIndex = 46
        Me.Label41.Text = "To :"
        '
        'txtPOShipDateFm
        '
        Me.txtPOShipDateFm.Location = New System.Drawing.Point(200, 250)
        Me.txtPOShipDateFm.Mask = "##/##/####"
        Me.txtPOShipDateFm.Name = "txtPOShipDateFm"
        Me.txtPOShipDateFm.Size = New System.Drawing.Size(161, 20)
        Me.txtPOShipDateFm.TabIndex = 23
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(158, 254)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(36, 13)
        Me.Label30.TabIndex = 24
        Me.Label30.Text = "From :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(10, 253)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(139, 13)
        Me.Label16.TabIndex = 10
        Me.Label16.Text = "PO Ship Date (mm/dd/yyyy)"
        '
        'SLabel_5
        '
        Me.SLabel_5.AutoSize = True
        Me.SLabel_5.Location = New System.Drawing.Point(10, 130)
        Me.SLabel_5.Name = "SLabel_5"
        Me.SLabel_5.Size = New System.Drawing.Size(20, 13)
        Me.SLabel_5.TabIndex = 7
        Me.SLabel_5.Text = "FA"
        '
        'SLabel_3
        '
        Me.SLabel_3.AutoSize = True
        Me.SLabel_3.Location = New System.Drawing.Point(10, 84)
        Me.SLabel_3.Name = "SLabel_3"
        Me.SLabel_3.Size = New System.Drawing.Size(21, 13)
        Me.SLabel_3.TabIndex = 6
        Me.SLabel_3.Text = "PV"
        '
        'SLabel_9
        '
        Me.SLabel_9.AutoSize = True
        Me.SLabel_9.Location = New System.Drawing.Point(10, 226)
        Me.SLabel_9.Name = "SLabel_9"
        Me.SLabel_9.Size = New System.Drawing.Size(44, 13)
        Me.SLabel_9.TabIndex = 5
        Me.SLabel_9.Text = "Item No"
        '
        'SLabel_6
        '
        Me.SLabel_6.AutoSize = True
        Me.SLabel_6.Location = New System.Drawing.Point(10, 154)
        Me.SLabel_6.Name = "SLabel_6"
        Me.SLabel_6.Size = New System.Drawing.Size(38, 13)
        Me.SLabel_6.TabIndex = 3
        Me.SLabel_6.Text = "SC No"
        '
        'SLabel_2
        '
        Me.SLabel_2.AutoSize = True
        Me.SLabel_2.Location = New System.Drawing.Point(10, 62)
        Me.SLabel_2.Name = "SLabel_2"
        Me.SLabel_2.Size = New System.Drawing.Size(122, 13)
        Me.SLabel_2.TabIndex = 1
        Me.SLabel_2.Text = "Secondary Customer No"
        '
        'SLabel_1
        '
        Me.SLabel_1.AutoSize = True
        Me.SLabel_1.Location = New System.Drawing.Point(10, 39)
        Me.SLabel_1.Name = "SLabel_1"
        Me.SLabel_1.Size = New System.Drawing.Size(105, 13)
        Me.SLabel_1.TabIndex = 0
        Me.SLabel_1.Text = "Primary Customer No"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dg_Header)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(941, 535)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "(2) Header"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dg_Header
        '
        Me.dg_Header.AllowUserToAddRows = False
        Me.dg_Header.AllowUserToDeleteRows = False
        Me.dg_Header.ColumnHeadersHeight = 20
        Me.dg_Header.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dg_Header.Location = New System.Drawing.Point(0, 0)
        Me.dg_Header.Name = "dg_Header"
        Me.dg_Header.RowHeadersWidth = 20
        Me.dg_Header.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dg_Header.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.dg_Header.RowTemplate.Height = 16
        Me.dg_Header.Size = New System.Drawing.Size(941, 295)
        Me.dg_Header.TabIndex = 397
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.txt_CYdate)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txt_SZdate)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.cbo_year)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.cmdApply)
        Me.GroupBox1.Controls.Add(Me.txtRmk)
        Me.GroupBox1.Controls.Add(Me.cmdSelectAll)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cbo_week)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 301)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(926, 226)
        Me.GroupBox1.TabIndex = 315
        Me.GroupBox1.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.chk_day1)
        Me.GroupBox5.Controls.Add(Me.chk_day2)
        Me.GroupBox5.Controls.Add(Me.chk_day3)
        Me.GroupBox5.Controls.Add(Me.chk_day4)
        Me.GroupBox5.Controls.Add(Me.chk_day5)
        Me.GroupBox5.Controls.Add(Me.chk_day7)
        Me.GroupBox5.Controls.Add(Me.chk_day6)
        Me.GroupBox5.Location = New System.Drawing.Point(144, 66)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(362, 31)
        Me.GroupBox5.TabIndex = 334
        Me.GroupBox5.TabStop = False
        '
        'chk_day1
        '
        Me.chk_day1.AutoSize = True
        Me.chk_day1.Location = New System.Drawing.Point(6, 9)
        Me.chk_day1.Name = "chk_day1"
        Me.chk_day1.Size = New System.Drawing.Size(47, 17)
        Me.chk_day1.TabIndex = 323
        Me.chk_day1.Text = "Mon"
        Me.chk_day1.UseVisualStyleBackColor = True
        '
        'chk_day2
        '
        Me.chk_day2.AutoSize = True
        Me.chk_day2.Location = New System.Drawing.Point(59, 9)
        Me.chk_day2.Name = "chk_day2"
        Me.chk_day2.Size = New System.Drawing.Size(45, 17)
        Me.chk_day2.TabIndex = 324
        Me.chk_day2.Text = "Tue"
        Me.chk_day2.UseVisualStyleBackColor = True
        '
        'chk_day3
        '
        Me.chk_day3.AutoSize = True
        Me.chk_day3.Location = New System.Drawing.Point(108, 9)
        Me.chk_day3.Name = "chk_day3"
        Me.chk_day3.Size = New System.Drawing.Size(49, 17)
        Me.chk_day3.TabIndex = 325
        Me.chk_day3.Text = "Wed"
        Me.chk_day3.UseVisualStyleBackColor = True
        '
        'chk_day4
        '
        Me.chk_day4.AutoSize = True
        Me.chk_day4.Location = New System.Drawing.Point(161, 9)
        Me.chk_day4.Name = "chk_day4"
        Me.chk_day4.Size = New System.Drawing.Size(48, 17)
        Me.chk_day4.TabIndex = 326
        Me.chk_day4.Text = "Thur"
        Me.chk_day4.UseVisualStyleBackColor = True
        '
        'chk_day5
        '
        Me.chk_day5.AutoSize = True
        Me.chk_day5.Location = New System.Drawing.Point(214, 9)
        Me.chk_day5.Name = "chk_day5"
        Me.chk_day5.Size = New System.Drawing.Size(37, 17)
        Me.chk_day5.TabIndex = 327
        Me.chk_day5.Text = "Fri"
        Me.chk_day5.UseVisualStyleBackColor = True
        '
        'chk_day7
        '
        Me.chk_day7.AutoSize = True
        Me.chk_day7.Location = New System.Drawing.Point(317, 9)
        Me.chk_day7.Name = "chk_day7"
        Me.chk_day7.Size = New System.Drawing.Size(45, 17)
        Me.chk_day7.TabIndex = 329
        Me.chk_day7.Text = "Sun"
        Me.chk_day7.UseVisualStyleBackColor = True
        '
        'chk_day6
        '
        Me.chk_day6.AutoSize = True
        Me.chk_day6.Location = New System.Drawing.Point(267, 9)
        Me.chk_day6.Name = "chk_day6"
        Me.chk_day6.Size = New System.Drawing.Size(42, 17)
        Me.chk_day6.TabIndex = 328
        Me.chk_day6.Text = "Sat"
        Me.chk_day6.UseVisualStyleBackColor = True
        '
        'txt_CYdate
        '
        Me.txt_CYdate.BackColor = System.Drawing.Color.White
        Me.txt_CYdate.Location = New System.Drawing.Point(496, 128)
        Me.txt_CYdate.Mask = "##/##/####"
        Me.txt_CYdate.Name = "txt_CYdate"
        Me.txt_CYdate.Size = New System.Drawing.Size(80, 20)
        Me.txt_CYdate.TabIndex = 333
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(386, 131)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 332
        Me.Label1.Text = "CY Date"
        '
        'txt_SZdate
        '
        Me.txt_SZdate.BackColor = System.Drawing.Color.White
        Me.txt_SZdate.Location = New System.Drawing.Point(496, 103)
        Me.txt_SZdate.Mask = "##/##/####"
        Me.txt_SZdate.Name = "txt_SZdate"
        Me.txt_SZdate.Size = New System.Drawing.Size(80, 20)
        Me.txt_SZdate.TabIndex = 331
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(386, 106)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(43, 13)
        Me.Label13.TabIndex = 330
        Me.Label13.Text = "SI Date"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 77)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 13)
        Me.Label12.TabIndex = 322
        Me.Label12.Text = "Request Date"
        '
        'cbo_year
        '
        Me.cbo_year.BackColor = System.Drawing.Color.White
        Me.cbo_year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_year.FormattingEnabled = True
        Me.cbo_year.Location = New System.Drawing.Point(151, 12)
        Me.cbo_year.Name = "cbo_year"
        Me.cbo_year.Size = New System.Drawing.Size(140, 21)
        Me.cbo_year.TabIndex = 321
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 17)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(29, 13)
        Me.Label11.TabIndex = 320
        Me.Label11.Text = "Year"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.opt_genbyPV)
        Me.GroupBox4.Controls.Add(Me.opt_genbyCV)
        Me.GroupBox4.Controls.Add(Me.opt_genbyFA)
        Me.GroupBox4.Location = New System.Drawing.Point(143, 183)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(169, 29)
        Me.GroupBox4.TabIndex = 317
        Me.GroupBox4.TabStop = False
        '
        'opt_genbyPV
        '
        Me.opt_genbyPV.AutoSize = True
        Me.opt_genbyPV.Location = New System.Drawing.Point(70, 9)
        Me.opt_genbyPV.Name = "opt_genbyPV"
        Me.opt_genbyPV.Size = New System.Drawing.Size(39, 17)
        Me.opt_genbyPV.TabIndex = 309
        Me.opt_genbyPV.TabStop = True
        Me.opt_genbyPV.Text = "PV"
        Me.opt_genbyPV.UseVisualStyleBackColor = True
        '
        'opt_genbyCV
        '
        Me.opt_genbyCV.AutoSize = True
        Me.opt_genbyCV.Checked = True
        Me.opt_genbyCV.Location = New System.Drawing.Point(16, 9)
        Me.opt_genbyCV.Name = "opt_genbyCV"
        Me.opt_genbyCV.Size = New System.Drawing.Size(39, 17)
        Me.opt_genbyCV.TabIndex = 308
        Me.opt_genbyCV.TabStop = True
        Me.opt_genbyCV.Text = "CV"
        Me.opt_genbyCV.UseVisualStyleBackColor = True
        '
        'opt_genbyFA
        '
        Me.opt_genbyFA.AutoSize = True
        Me.opt_genbyFA.Location = New System.Drawing.Point(113, 9)
        Me.opt_genbyFA.Name = "opt_genbyFA"
        Me.opt_genbyFA.Size = New System.Drawing.Size(38, 17)
        Me.opt_genbyFA.TabIndex = 310
        Me.opt_genbyFA.TabStop = True
        Me.opt_genbyFA.Text = "FA"
        Me.opt_genbyFA.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.opt_samphandle2)
        Me.GroupBox3.Controls.Add(Me.opt_samphandle1)
        Me.GroupBox3.Location = New System.Drawing.Point(144, 151)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(151, 31)
        Me.GroupBox3.TabIndex = 316
        Me.GroupBox3.TabStop = False
        '
        'opt_samphandle2
        '
        Me.opt_samphandle2.AutoSize = True
        Me.opt_samphandle2.Location = New System.Drawing.Point(72, 9)
        Me.opt_samphandle2.Name = "opt_samphandle2"
        Me.opt_samphandle2.Size = New System.Drawing.Size(77, 17)
        Me.opt_samphandle2.TabIndex = 306
        Me.opt_samphandle2.TabStop = True
        Me.opt_samphandle2.Text = "No Sample"
        Me.opt_samphandle2.UseVisualStyleBackColor = True
        '
        'opt_samphandle1
        '
        Me.opt_samphandle1.AutoSize = True
        Me.opt_samphandle1.Checked = True
        Me.opt_samphandle1.Location = New System.Drawing.Point(6, 9)
        Me.opt_samphandle1.Name = "opt_samphandle1"
        Me.opt_samphandle1.Size = New System.Drawing.Size(60, 17)
        Me.opt_samphandle1.TabIndex = 305
        Me.opt_samphandle1.TabStop = True
        Me.opt_samphandle1.Text = "Factory"
        Me.opt_samphandle1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.opt_insptyp5)
        Me.GroupBox2.Controls.Add(Me.opt_insptyp4)
        Me.GroupBox2.Controls.Add(Me.opt_insptyp3)
        Me.GroupBox2.Controls.Add(Me.opt_insptyp2)
        Me.GroupBox2.Controls.Add(Me.opt_insptyp1)
        Me.GroupBox2.Location = New System.Drawing.Point(144, 103)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(196, 48)
        Me.GroupBox2.TabIndex = 315
        Me.GroupBox2.TabStop = False
        '
        'opt_insptyp5
        '
        Me.opt_insptyp5.AutoSize = True
        Me.opt_insptyp5.Location = New System.Drawing.Point(100, 29)
        Me.opt_insptyp5.Name = "opt_insptyp5"
        Me.opt_insptyp5.Size = New System.Drawing.Size(69, 17)
        Me.opt_insptyp5.TabIndex = 303
        Me.opt_insptyp5.Text = "Customer"
        Me.opt_insptyp5.UseVisualStyleBackColor = True
        '
        'opt_insptyp4
        '
        Me.opt_insptyp4.AutoSize = True
        Me.opt_insptyp4.Enabled = False
        Me.opt_insptyp4.Location = New System.Drawing.Point(8, 29)
        Me.opt_insptyp4.Name = "opt_insptyp4"
        Me.opt_insptyp4.Size = New System.Drawing.Size(80, 17)
        Me.opt_insptyp4.TabIndex = 302
        Me.opt_insptyp4.Text = "PP Meeting"
        Me.opt_insptyp4.UseVisualStyleBackColor = True
        '
        'opt_insptyp3
        '
        Me.opt_insptyp3.AutoSize = True
        Me.opt_insptyp3.Location = New System.Drawing.Point(133, 6)
        Me.opt_insptyp3.Name = "opt_insptyp3"
        Me.opt_insptyp3.Size = New System.Drawing.Size(47, 17)
        Me.opt_insptyp3.TabIndex = 301
        Me.opt_insptyp3.Text = "Final"
        Me.opt_insptyp3.UseVisualStyleBackColor = True
        '
        'opt_insptyp2
        '
        Me.opt_insptyp2.AutoSize = True
        Me.opt_insptyp2.Checked = True
        Me.opt_insptyp2.Location = New System.Drawing.Point(73, 6)
        Me.opt_insptyp2.Name = "opt_insptyp2"
        Me.opt_insptyp2.Size = New System.Drawing.Size(57, 17)
        Me.opt_insptyp2.TabIndex = 300
        Me.opt_insptyp2.TabStop = True
        Me.opt_insptyp2.Text = "In-Line"
        Me.opt_insptyp2.UseVisualStyleBackColor = True
        '
        'opt_insptyp1
        '
        Me.opt_insptyp1.AutoSize = True
        Me.opt_insptyp1.Enabled = False
        Me.opt_insptyp1.Location = New System.Drawing.Point(8, 6)
        Me.opt_insptyp1.Name = "opt_insptyp1"
        Me.opt_insptyp1.Size = New System.Drawing.Size(59, 17)
        Me.opt_insptyp1.TabIndex = 299
        Me.opt_insptyp1.Text = "Pre-pro"
        Me.opt_insptyp1.UseVisualStyleBackColor = True
        '
        'cmdApply
        '
        Me.cmdApply.Location = New System.Drawing.Point(503, 195)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.Size = New System.Drawing.Size(75, 23)
        Me.cmdApply.TabIndex = 314
        Me.cmdApply.Text = "Apply"
        Me.cmdApply.UseVisualStyleBackColor = True
        '
        'txtRmk
        '
        Me.txtRmk.BackColor = System.Drawing.Color.White
        Me.txtRmk.Location = New System.Drawing.Point(626, 29)
        Me.txtRmk.Multiline = True
        Me.txtRmk.Name = "txtRmk"
        Me.txtRmk.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRmk.Size = New System.Drawing.Size(294, 93)
        Me.txtRmk.TabIndex = 312
        '
        'cmdSelectAll
        '
        Me.cmdSelectAll.Location = New System.Drawing.Point(503, 166)
        Me.cmdSelectAll.Name = "cmdSelectAll"
        Me.cmdSelectAll.Size = New System.Drawing.Size(75, 23)
        Me.cmdSelectAll.TabIndex = 313
        Me.cmdSelectAll.Text = "Select All"
        Me.cmdSelectAll.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(623, 13)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(49, 13)
        Me.Label19.TabIndex = 311
        Me.Label19.Text = "Remarks"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 193)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 307
        Me.Label5.Text = "Generated By"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 159)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 13)
        Me.Label4.TabIndex = 304
        Me.Label4.Text = "Sampling Handling"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 109)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 298
        Me.Label3.Text = "Inspection Type"
        '
        'cbo_week
        '
        Me.cbo_week.BackColor = System.Drawing.Color.White
        Me.cbo_week.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_week.FormattingEnabled = True
        Me.cbo_week.Location = New System.Drawing.Point(149, 39)
        Me.cbo_week.Name = "cbo_week"
        Me.cbo_week.Size = New System.Drawing.Size(140, 21)
        Me.cbo_week.TabIndex = 294
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(7, 45)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 13)
        Me.Label9.TabIndex = 292
        Me.Label9.Text = "Inspection Week"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.dg_Detail)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(941, 535)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "(3) Detail"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'dg_Detail
        '
        Me.dg_Detail.AllowUserToAddRows = False
        Me.dg_Detail.AllowUserToDeleteRows = False
        Me.dg_Detail.ColumnHeadersHeight = 20
        Me.dg_Detail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dg_Detail.Location = New System.Drawing.Point(0, 0)
        Me.dg_Detail.Name = "dg_Detail"
        Me.dg_Detail.RowHeadersWidth = 20
        Me.dg_Detail.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dg_Detail.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.dg_Detail.RowTemplate.Height = 16
        Me.dg_Detail.Size = New System.Drawing.Size(941, 295)
        Me.dg_Detail.TabIndex = 398
        '
        'frm_QCinsert
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(973, 602)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frm_QCinsert"
        Me.Text = "frm_QCinsert"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox_Search.ResumeLayout(False)
        Me.GroupBox_Search.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dg_Header, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.dg_Detail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents txtResult As System.Windows.Forms.TextBox
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboCocde As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox_Search As System.Windows.Forms.GroupBox
    Friend WithEvents txt_S_PONo As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_PONo As System.Windows.Forms.Button
    Friend WithEvents SLabel_7 As System.Windows.Forms.Label
    Friend WithEvents txt_S_CV As System.Windows.Forms.TextBox
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents cmd_S_CV As System.Windows.Forms.Button
    Friend WithEvents SLabel_4 As System.Windows.Forms.Label
    Friend WithEvents txt_S_FA As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_FA As System.Windows.Forms.Button
    Friend WithEvents txt_S_PV As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_PV As System.Windows.Forms.Button
    Friend WithEvents txt_S_ItmNo As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_ItmNo As System.Windows.Forms.Button
    Friend WithEvents txt_S_SCNo As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_SCNo As System.Windows.Forms.Button
    Friend WithEvents txt_S_CustPONo As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_CustPONo As System.Windows.Forms.Button
    Friend WithEvents SLabel_8 As System.Windows.Forms.Label
    Friend WithEvents txt_S_SecCustAll As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_SecCustAll As System.Windows.Forms.Button
    Friend WithEvents txt_S_PriCustAll As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_PriCustAll As System.Windows.Forms.Button
    Friend WithEvents txtPOShipDateTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents txtPOShipDateFm As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents SLabel_5 As System.Windows.Forms.Label
    Friend WithEvents SLabel_3 As System.Windows.Forms.Label
    Friend WithEvents SLabel_9 As System.Windows.Forms.Label
    Friend WithEvents SLabel_6 As System.Windows.Forms.Label
    Friend WithEvents SLabel_2 As System.Windows.Forms.Label
    Friend WithEvents SLabel_1 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dg_Header As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents chk_day1 As System.Windows.Forms.CheckBox
    Friend WithEvents chk_day2 As System.Windows.Forms.CheckBox
    Friend WithEvents chk_day3 As System.Windows.Forms.CheckBox
    Friend WithEvents chk_day4 As System.Windows.Forms.CheckBox
    Friend WithEvents chk_day5 As System.Windows.Forms.CheckBox
    Friend WithEvents chk_day7 As System.Windows.Forms.CheckBox
    Friend WithEvents chk_day6 As System.Windows.Forms.CheckBox
    Friend WithEvents txt_CYdate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_SZdate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cbo_year As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents opt_genbyPV As System.Windows.Forms.RadioButton
    Friend WithEvents opt_genbyCV As System.Windows.Forms.RadioButton
    Friend WithEvents opt_genbyFA As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents opt_samphandle2 As System.Windows.Forms.RadioButton
    Friend WithEvents opt_samphandle1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents opt_insptyp5 As System.Windows.Forms.RadioButton
    Friend WithEvents opt_insptyp4 As System.Windows.Forms.RadioButton
    Friend WithEvents opt_insptyp3 As System.Windows.Forms.RadioButton
    Friend WithEvents opt_insptyp2 As System.Windows.Forms.RadioButton
    Friend WithEvents opt_insptyp1 As System.Windows.Forms.RadioButton
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents txtRmk As System.Windows.Forms.TextBox
    Friend WithEvents cmdSelectAll As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbo_week As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents dg_Detail As System.Windows.Forms.DataGridView
End Class
