﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IMR00017
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IMR00017))
        Me.grpSearchType = New System.Windows.Forms.GroupBox
        Me.optDAA = New System.Windows.Forms.RadioButton
        Me.optDAC = New System.Windows.Forms.RadioButton
        Me.optLST = New System.Windows.Forms.RadioButton
        Me.optITM = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.grpITM = New System.Windows.Forms.GroupBox
        Me.txtToItmNo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtFromItmNo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.grpLST = New System.Windows.Forms.GroupBox
        Me.cmd_S_ItmNo = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtItmLst = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.grpDAT = New System.Windows.Forms.GroupBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtUpddatTo = New System.Windows.Forms.MaskedTextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtUpddatFm = New System.Windows.Forms.MaskedTextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.grpSearchDetail = New System.Windows.Forms.GroupBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.optExt = New System.Windows.Forms.RadioButton
        Me.optInt = New System.Windows.Forms.RadioButton
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.txt_S_SecCustAll = New System.Windows.Forms.TextBox
        Me.cmd_S_SecCustAll = New System.Windows.Forms.Button
        Me.txt_S_PriCustAll = New System.Windows.Forms.TextBox
        Me.cmd_S_PriCustAll = New System.Windows.Forms.Button
        Me.SLabel_2 = New System.Windows.Forms.Label
        Me.SLabel_1 = New System.Windows.Forms.Label
        Me.txt_S_DV = New System.Windows.Forms.TextBox
        Me.cmd_S_DV = New System.Windows.Forms.Button
        Me.LblPeriodFormat = New System.Windows.Forms.Label
        Me.lblPeriod = New System.Windows.Forms.Label
        Me.txt_S_Period = New System.Windows.Forms.MaskedTextBox
        Me.cboStatus = New System.Windows.Forms.ComboBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.cboPrdVTo = New System.Windows.Forms.ComboBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.cboPrdVFm = New System.Windows.Forms.ComboBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.cboDsgTo = New System.Windows.Forms.ComboBox
        Me.cboDsgFm = New System.Windows.Forms.ComboBox
        Me.cboToCatLvl4 = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.cboFromCatLvl4 = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.cmdShow = New System.Windows.Forms.Button
        Me.grpSearchType.SuspendLayout()
        Me.grpITM.SuspendLayout()
        Me.grpLST.SuspendLayout()
        Me.grpDAT.SuspendLayout()
        Me.grpSearchDetail.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpSearchType
        '
        Me.grpSearchType.Controls.Add(Me.optDAA)
        Me.grpSearchType.Controls.Add(Me.optDAC)
        Me.grpSearchType.Controls.Add(Me.optLST)
        Me.grpSearchType.Controls.Add(Me.optITM)
        Me.grpSearchType.Controls.Add(Me.Label1)
        Me.grpSearchType.Location = New System.Drawing.Point(12, 11)
        Me.grpSearchType.Name = "grpSearchType"
        Me.grpSearchType.Size = New System.Drawing.Size(690, 45)
        Me.grpSearchType.TabIndex = 0
        Me.grpSearchType.TabStop = False
        '
        'optDAA
        '
        Me.optDAA.AutoSize = True
        Me.optDAA.Location = New System.Drawing.Point(511, 17)
        Me.optDAA.Name = "optDAA"
        Me.optDAA.Size = New System.Drawing.Size(172, 16)
        Me.optDAA.TabIndex = 4
        Me.optDAA.TabStop = True
        Me.optDAA.Text = "Date Range w/ CUR + HIS Item"
        Me.optDAA.UseVisualStyleBackColor = True
        '
        'optDAC
        '
        Me.optDAC.AutoSize = True
        Me.optDAC.Location = New System.Drawing.Point(357, 17)
        Me.optDAC.Name = "optDAC"
        Me.optDAC.Size = New System.Drawing.Size(142, 16)
        Me.optDAC.TabIndex = 3
        Me.optDAC.TabStop = True
        Me.optDAC.Text = "Date Range w/ CUR Item"
        Me.optDAC.UseVisualStyleBackColor = True
        '
        'optLST
        '
        Me.optLST.AutoSize = True
        Me.optLST.Location = New System.Drawing.Point(247, 17)
        Me.optLST.Name = "optLST"
        Me.optLST.Size = New System.Drawing.Size(105, 16)
        Me.optLST.TabIndex = 2
        Me.optLST.TabStop = True
        Me.optLST.Text = "Item Number List"
        Me.optLST.UseVisualStyleBackColor = True
        '
        'optITM
        '
        Me.optITM.AutoSize = True
        Me.optITM.Location = New System.Drawing.Point(121, 17)
        Me.optITM.Name = "optITM"
        Me.optITM.Size = New System.Drawing.Size(118, 16)
        Me.optITM.TabIndex = 1
        Me.optITM.TabStop = True
        Me.optITM.Text = "Item Number Range"
        Me.optITM.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Search Type"
        '
        'grpITM
        '
        Me.grpITM.Controls.Add(Me.txtToItmNo)
        Me.grpITM.Controls.Add(Me.Label4)
        Me.grpITM.Controls.Add(Me.txtFromItmNo)
        Me.grpITM.Controls.Add(Me.Label2)
        Me.grpITM.Controls.Add(Me.Label3)
        Me.grpITM.Location = New System.Drawing.Point(12, 62)
        Me.grpITM.Name = "grpITM"
        Me.grpITM.Size = New System.Drawing.Size(690, 57)
        Me.grpITM.TabIndex = 1
        Me.grpITM.TabStop = False
        '
        'txtToItmNo
        '
        Me.txtToItmNo.Location = New System.Drawing.Point(444, 15)
        Me.txtToItmNo.Name = "txtToItmNo"
        Me.txtToItmNo.Size = New System.Drawing.Size(165, 22)
        Me.txtToItmNo.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(420, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(18, 12)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "To"
        '
        'txtFromItmNo
        '
        Me.txtFromItmNo.Location = New System.Drawing.Point(149, 13)
        Me.txtFromItmNo.Name = "txtFromItmNo"
        Me.txtFromItmNo.Size = New System.Drawing.Size(165, 22)
        Me.txtFromItmNo.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 12)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Item Number"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(110, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 12)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "From"
        '
        'grpLST
        '
        Me.grpLST.Controls.Add(Me.cmd_S_ItmNo)
        Me.grpLST.Controls.Add(Me.Label8)
        Me.grpLST.Controls.Add(Me.txtItmLst)
        Me.grpLST.Controls.Add(Me.Label5)
        Me.grpLST.Controls.Add(Me.Label7)
        Me.grpLST.Location = New System.Drawing.Point(12, 62)
        Me.grpLST.Name = "grpLST"
        Me.grpLST.Size = New System.Drawing.Size(690, 57)
        Me.grpLST.TabIndex = 2
        Me.grpLST.TabStop = False
        '
        'cmd_S_ItmNo
        '
        Me.cmd_S_ItmNo.Location = New System.Drawing.Point(78, 17)
        Me.cmd_S_ItmNo.Name = "cmd_S_ItmNo"
        Me.cmd_S_ItmNo.Size = New System.Drawing.Size(45, 18)
        Me.cmd_S_ItmNo.TabIndex = 76
        Me.cmd_S_ItmNo.Text = "＞＞"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(370, 37)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(166, 12)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Note: Maximum 30 Items Allowed"
        '
        'txtItmLst
        '
        Me.txtItmLst.Location = New System.Drawing.Point(129, 15)
        Me.txtItmLst.Name = "txtItmLst"
        Me.txtItmLst.Size = New System.Drawing.Size(527, 22)
        Me.txtItmLst.TabIndex = 77
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(110, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(213, 12)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Seperate each item number by a comma(  ,  )"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 12)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Number List:"
        '
        'grpDAT
        '
        Me.grpDAT.Controls.Add(Me.Label14)
        Me.grpDAT.Controls.Add(Me.Label13)
        Me.grpDAT.Controls.Add(Me.Label12)
        Me.grpDAT.Controls.Add(Me.txtUpddatTo)
        Me.grpDAT.Controls.Add(Me.Label11)
        Me.grpDAT.Controls.Add(Me.txtUpddatFm)
        Me.grpDAT.Controls.Add(Me.Label10)
        Me.grpDAT.Controls.Add(Me.Label9)
        Me.grpDAT.Location = New System.Drawing.Point(12, 63)
        Me.grpDAT.Name = "grpDAT"
        Me.grpDAT.Size = New System.Drawing.Size(690, 57)
        Me.grpDAT.TabIndex = 3
        Me.grpDAT.TabStop = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(110, 39)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(463, 12)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "(Update Date of Item Basic Info./ Design Vendor Cost Markup / Production Vendor C" & _
            "ost Markup)"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(547, 18)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(87, 12)
        Me.Label13.TabIndex = 6
        Me.Label13.Text = "(MM/DD/YYYY)"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(233, 18)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(87, 12)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "(MM/DD/YYYY)"
        '
        'txtUpddatTo
        '
        Me.txtUpddatTo.Location = New System.Drawing.Point(460, 16)
        Me.txtUpddatTo.Mask = "##/##/####"
        Me.txtUpddatTo.Name = "txtUpddatTo"
        Me.txtUpddatTo.Size = New System.Drawing.Size(81, 22)
        Me.txtUpddatTo.TabIndex = 9
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(424, 18)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(18, 12)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "To"
        '
        'txtUpddatFm
        '
        Me.txtUpddatFm.Location = New System.Drawing.Point(146, 16)
        Me.txtUpddatFm.Mask = "##/##/####"
        Me.txtUpddatFm.Name = "txtUpddatFm"
        Me.txtUpddatFm.Size = New System.Drawing.Size(81, 22)
        Me.txtUpddatFm.TabIndex = 8
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(110, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(30, 12)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "From"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(7, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 12)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Update Date"
        '
        'grpSearchDetail
        '
        Me.grpSearchDetail.Controls.Add(Me.Panel1)
        Me.grpSearchDetail.Controls.Add(Me.Label24)
        Me.grpSearchDetail.Controls.Add(Me.txt_S_SecCustAll)
        Me.grpSearchDetail.Controls.Add(Me.Label6)
        Me.grpSearchDetail.Controls.Add(Me.cmd_S_SecCustAll)
        Me.grpSearchDetail.Controls.Add(Me.txt_S_PriCustAll)
        Me.grpSearchDetail.Controls.Add(Me.cmd_S_PriCustAll)
        Me.grpSearchDetail.Controls.Add(Me.SLabel_2)
        Me.grpSearchDetail.Controls.Add(Me.SLabel_1)
        Me.grpSearchDetail.Controls.Add(Me.txt_S_DV)
        Me.grpSearchDetail.Controls.Add(Me.cmd_S_DV)
        Me.grpSearchDetail.Controls.Add(Me.LblPeriodFormat)
        Me.grpSearchDetail.Controls.Add(Me.lblPeriod)
        Me.grpSearchDetail.Controls.Add(Me.txt_S_Period)
        Me.grpSearchDetail.Controls.Add(Me.cboStatus)
        Me.grpSearchDetail.Controls.Add(Me.Label25)
        Me.grpSearchDetail.Controls.Add(Me.cboPrdVTo)
        Me.grpSearchDetail.Controls.Add(Me.Label21)
        Me.grpSearchDetail.Controls.Add(Me.cboPrdVFm)
        Me.grpSearchDetail.Controls.Add(Me.Label22)
        Me.grpSearchDetail.Controls.Add(Me.Label23)
        Me.grpSearchDetail.Controls.Add(Me.cboDsgTo)
        Me.grpSearchDetail.Controls.Add(Me.cboDsgFm)
        Me.grpSearchDetail.Controls.Add(Me.cboToCatLvl4)
        Me.grpSearchDetail.Controls.Add(Me.Label17)
        Me.grpSearchDetail.Controls.Add(Me.cboFromCatLvl4)
        Me.grpSearchDetail.Controls.Add(Me.Label16)
        Me.grpSearchDetail.Controls.Add(Me.Label15)
        Me.grpSearchDetail.Location = New System.Drawing.Point(13, 126)
        Me.grpSearchDetail.Name = "grpSearchDetail"
        Me.grpSearchDetail.Size = New System.Drawing.Size(689, 209)
        Me.grpSearchDetail.TabIndex = 3
        Me.grpSearchDetail.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.optExt)
        Me.Panel1.Controls.Add(Me.optInt)
        Me.Panel1.Location = New System.Drawing.Point(145, 170)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(225, 23)
        Me.Panel1.TabIndex = 95
        '
        'optExt
        '
        Me.optExt.AutoSize = True
        Me.optExt.Location = New System.Drawing.Point(138, 4)
        Me.optExt.Name = "optExt"
        Me.optExt.Size = New System.Drawing.Size(62, 16)
        Me.optExt.TabIndex = 1
        Me.optExt.TabStop = True
        Me.optExt.Text = "External"
        Me.optExt.UseVisualStyleBackColor = True
        '
        'optInt
        '
        Me.optInt.AutoSize = True
        Me.optInt.Location = New System.Drawing.Point(6, 4)
        Me.optInt.Name = "optInt"
        Me.optInt.Size = New System.Drawing.Size(59, 16)
        Me.optInt.TabIndex = 0
        Me.optInt.TabStop = True
        Me.optInt.Text = "Internal"
        Me.optInt.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 175)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 12)
        Me.Label6.TabIndex = 94
        Me.Label6.Text = "Report Format"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(9, 147)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(75, 12)
        Me.Label24.TabIndex = 92
        Me.Label24.Text = "Design Vendor"
        '
        'txt_S_SecCustAll
        '
        Me.txt_S_SecCustAll.Location = New System.Drawing.Point(196, 119)
        Me.txt_S_SecCustAll.Name = "txt_S_SecCustAll"
        Me.txt_S_SecCustAll.Size = New System.Drawing.Size(475, 22)
        Me.txt_S_SecCustAll.TabIndex = 91
        '
        'cmd_S_SecCustAll
        '
        Me.cmd_S_SecCustAll.Location = New System.Drawing.Point(145, 119)
        Me.cmd_S_SecCustAll.Name = "cmd_S_SecCustAll"
        Me.cmd_S_SecCustAll.Size = New System.Drawing.Size(45, 21)
        Me.cmd_S_SecCustAll.TabIndex = 90
        Me.cmd_S_SecCustAll.Text = "＞＞"
        '
        'txt_S_PriCustAll
        '
        Me.txt_S_PriCustAll.Location = New System.Drawing.Point(196, 95)
        Me.txt_S_PriCustAll.Name = "txt_S_PriCustAll"
        Me.txt_S_PriCustAll.Size = New System.Drawing.Size(475, 22)
        Me.txt_S_PriCustAll.TabIndex = 89
        '
        'cmd_S_PriCustAll
        '
        Me.cmd_S_PriCustAll.Location = New System.Drawing.Point(145, 95)
        Me.cmd_S_PriCustAll.Name = "cmd_S_PriCustAll"
        Me.cmd_S_PriCustAll.Size = New System.Drawing.Size(45, 21)
        Me.cmd_S_PriCustAll.TabIndex = 88
        Me.cmd_S_PriCustAll.Text = "＞＞"
        '
        'SLabel_2
        '
        Me.SLabel_2.AutoSize = True
        Me.SLabel_2.Location = New System.Drawing.Point(9, 123)
        Me.SLabel_2.Name = "SLabel_2"
        Me.SLabel_2.Size = New System.Drawing.Size(119, 12)
        Me.SLabel_2.TabIndex = 87
        Me.SLabel_2.Text = "Secondary Customer No"
        '
        'SLabel_1
        '
        Me.SLabel_1.AutoSize = True
        Me.SLabel_1.Location = New System.Drawing.Point(9, 99)
        Me.SLabel_1.Name = "SLabel_1"
        Me.SLabel_1.Size = New System.Drawing.Size(107, 12)
        Me.SLabel_1.TabIndex = 86
        Me.SLabel_1.Text = "Primary Customer No"
        '
        'txt_S_DV
        '
        Me.txt_S_DV.Location = New System.Drawing.Point(197, 144)
        Me.txt_S_DV.Name = "txt_S_DV"
        Me.txt_S_DV.Size = New System.Drawing.Size(474, 22)
        Me.txt_S_DV.TabIndex = 93
        '
        'cmd_S_DV
        '
        Me.cmd_S_DV.Location = New System.Drawing.Point(145, 142)
        Me.cmd_S_DV.Name = "cmd_S_DV"
        Me.cmd_S_DV.Size = New System.Drawing.Size(45, 21)
        Me.cmd_S_DV.TabIndex = 92
        Me.cmd_S_DV.Text = "＞＞"
        Me.cmd_S_DV.UseVisualStyleBackColor = True
        '
        'LblPeriodFormat
        '
        Me.LblPeriodFormat.AutoSize = True
        Me.LblPeriodFormat.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPeriodFormat.Location = New System.Drawing.Point(550, 84)
        Me.LblPeriodFormat.Name = "LblPeriodFormat"
        Me.LblPeriodFormat.Size = New System.Drawing.Size(46, 12)
        Me.LblPeriodFormat.TabIndex = 45
        Me.LblPeriodFormat.Text = "YYYY-MM"
        '
        'lblPeriod
        '
        Me.lblPeriod.AutoSize = True
        Me.lblPeriod.Location = New System.Drawing.Point(507, 67)
        Me.lblPeriod.Name = "lblPeriod"
        Me.lblPeriod.Size = New System.Drawing.Size(35, 12)
        Me.lblPeriod.TabIndex = 44
        Me.lblPeriod.Text = "Period"
        '
        'txt_S_Period
        '
        Me.txt_S_Period.Location = New System.Drawing.Point(548, 62)
        Me.txt_S_Period.Mask = "0000-00"
        Me.txt_S_Period.Name = "txt_S_Period"
        Me.txt_S_Period.Size = New System.Drawing.Size(50, 22)
        Me.txt_S_Period.TabIndex = 42
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(145, 62)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(225, 20)
        Me.cboStatus.TabIndex = 17
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(9, 66)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(56, 12)
        Me.Label25.TabIndex = 15
        Me.Label25.Text = "Item Status"
        '
        'cboPrdVTo
        '
        Me.cboPrdVTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPrdVTo.FormattingEnabled = True
        Me.cboPrdVTo.Location = New System.Drawing.Point(446, 39)
        Me.cboPrdVTo.Name = "cboPrdVTo"
        Me.cboPrdVTo.Size = New System.Drawing.Size(225, 20)
        Me.cboPrdVTo.Sorted = True
        Me.cboPrdVTo.TabIndex = 14
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(420, 42)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(18, 12)
        Me.Label21.TabIndex = 13
        Me.Label21.Text = "To"
        '
        'cboPrdVFm
        '
        Me.cboPrdVFm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPrdVFm.FormattingEnabled = True
        Me.cboPrdVFm.Location = New System.Drawing.Point(145, 39)
        Me.cboPrdVFm.Name = "cboPrdVFm"
        Me.cboPrdVFm.Size = New System.Drawing.Size(225, 20)
        Me.cboPrdVFm.Sorted = True
        Me.cboPrdVFm.TabIndex = 12
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(109, 42)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(30, 12)
        Me.Label22.TabIndex = 11
        Me.Label22.Text = "From"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(9, 42)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(94, 12)
        Me.Label23.TabIndex = 10
        Me.Label23.Text = "Production Vendor"
        '
        'cboDsgTo
        '
        Me.cboDsgTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDsgTo.FormattingEnabled = True
        Me.cboDsgTo.Location = New System.Drawing.Point(281, 146)
        Me.cboDsgTo.Name = "cboDsgTo"
        Me.cboDsgTo.Size = New System.Drawing.Size(340, 20)
        Me.cboDsgTo.TabIndex = 9
        Me.cboDsgTo.Visible = False
        '
        'cboDsgFm
        '
        Me.cboDsgFm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDsgFm.FormattingEnabled = True
        Me.cboDsgFm.Location = New System.Drawing.Point(196, 143)
        Me.cboDsgFm.Name = "cboDsgFm"
        Me.cboDsgFm.Size = New System.Drawing.Size(340, 20)
        Me.cboDsgFm.TabIndex = 7
        Me.cboDsgFm.Visible = False
        '
        'cboToCatLvl4
        '
        Me.cboToCatLvl4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboToCatLvl4.FormattingEnabled = True
        Me.cboToCatLvl4.Location = New System.Drawing.Point(446, 16)
        Me.cboToCatLvl4.Name = "cboToCatLvl4"
        Me.cboToCatLvl4.Size = New System.Drawing.Size(225, 20)
        Me.cboToCatLvl4.TabIndex = 11
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(420, 18)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(18, 12)
        Me.Label17.TabIndex = 3
        Me.Label17.Text = "To"
        '
        'cboFromCatLvl4
        '
        Me.cboFromCatLvl4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFromCatLvl4.FormattingEnabled = True
        Me.cboFromCatLvl4.Location = New System.Drawing.Point(145, 16)
        Me.cboFromCatLvl4.Name = "cboFromCatLvl4"
        Me.cboFromCatLvl4.Size = New System.Drawing.Size(225, 20)
        Me.cboFromCatLvl4.TabIndex = 10
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(109, 18)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(30, 12)
        Me.Label16.TabIndex = 1
        Me.Label16.Text = "From"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(9, 18)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(76, 12)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Category Code"
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(285, 343)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(169, 22)
        Me.cmdShow.TabIndex = 4
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'IMR00017
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(714, 368)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.grpSearchDetail)
        Me.Controls.Add(Me.grpSearchType)
        Me.Controls.Add(Me.grpITM)
        Me.Controls.Add(Me.grpDAT)
        Me.Controls.Add(Me.grpLST)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "IMR00017"
        Me.Text = "IMR00017 - Item Pricing Report (Export to Excel) (IMR17)"
        Me.grpSearchType.ResumeLayout(False)
        Me.grpSearchType.PerformLayout()
        Me.grpITM.ResumeLayout(False)
        Me.grpITM.PerformLayout()
        Me.grpLST.ResumeLayout(False)
        Me.grpLST.PerformLayout()
        Me.grpDAT.ResumeLayout(False)
        Me.grpDAT.PerformLayout()
        Me.grpSearchDetail.ResumeLayout(False)
        Me.grpSearchDetail.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpSearchType As System.Windows.Forms.GroupBox
    Friend WithEvents optITM As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents optDAC As System.Windows.Forms.RadioButton
    Friend WithEvents optLST As System.Windows.Forms.RadioButton
    Friend WithEvents optDAA As System.Windows.Forms.RadioButton
    Friend WithEvents grpITM As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtToItmNo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFromItmNo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grpLST As System.Windows.Forms.GroupBox
    Friend WithEvents txtItmLst As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents grpDAT As System.Windows.Forms.GroupBox
    Friend WithEvents txtUpddatFm As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtUpddatTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents grpSearchDetail As System.Windows.Forms.GroupBox
    Friend WithEvents cboToCatLvl4 As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cboFromCatLvl4 As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cboPrdVTo As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cboPrdVFm As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents cboDsgTo As System.Windows.Forms.ComboBox
    Friend WithEvents cboDsgFm As System.Windows.Forms.ComboBox
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents txt_S_Period As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblPeriod As System.Windows.Forms.Label
    Friend WithEvents LblPeriodFormat As System.Windows.Forms.Label
    Friend WithEvents cmd_S_ItmNo As System.Windows.Forms.Button
    Friend WithEvents txt_S_DV As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_DV As System.Windows.Forms.Button
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txt_S_SecCustAll As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_SecCustAll As System.Windows.Forms.Button
    Friend WithEvents txt_S_PriCustAll As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_PriCustAll As System.Windows.Forms.Button
    Friend WithEvents SLabel_2 As System.Windows.Forms.Label
    Friend WithEvents SLabel_1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents optExt As System.Windows.Forms.RadioButton
    Friend WithEvents optInt As System.Windows.Forms.RadioButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
