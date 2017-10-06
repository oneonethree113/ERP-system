<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CLR00005
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CLR00005))
        Me.lblRptName = New System.Windows.Forms.Label
        Me.Panel10 = New System.Windows.Forms.Panel
        Me.Combo1 = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.cmdShow = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.chk_1756 = New System.Windows.Forms.CheckBox
        Me.chk_ext = New System.Windows.Forms.CheckBox
        Me.chk_int = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.saveto_folder = New System.Windows.Forms.TextBox
        Me.txt_S_SARvsdatTo = New System.Windows.Forms.MaskedTextBox
        Me.txt_S_SARvsdatFm = New System.Windows.Forms.MaskedTextBox
        Me.txt_S_SAIssdatTo = New System.Windows.Forms.MaskedTextBox
        Me.txt_S_SAIssdatFm = New System.Windows.Forms.MaskedTextBox
        Me.chk_donot_show_dtl = New System.Windows.Forms.CheckBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.txt_S_CaSts = New System.Windows.Forms.TextBox
        Me.cmd_S_CaSts = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmd_S_PONo = New System.Windows.Forms.Button
        Me.txt_S_PONo = New System.Windows.Forms.TextBox
        Me.txt_S_SCNo = New System.Windows.Forms.TextBox
        Me.cmd_S_SCNo = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_S_CaOrdNo = New System.Windows.Forms.TextBox
        Me.cmd_S_Clmno = New System.Windows.Forms.Button
        Me.cmd_S_PV = New System.Windows.Forms.Button
        Me.lbl_S_PV = New System.Windows.Forms.Label
        Me.txt_S_PV = New System.Windows.Forms.TextBox
        Me.cmd_S_SecCust = New System.Windows.Forms.Button
        Me.txt_S_SecCust = New System.Windows.Forms.TextBox
        Me.lbl_S_SecCust = New System.Windows.Forms.Label
        Me.cmd_S_ItmNo = New System.Windows.Forms.Button
        Me.cmd_S_PriCust = New System.Windows.Forms.Button
        Me.cmd_S_CoCde = New System.Windows.Forms.Button
        Me.lbl_S_ItmNo = New System.Windows.Forms.Label
        Me.txt_S_ItmNo = New System.Windows.Forms.TextBox
        Me.txt_S_PriCust = New System.Windows.Forms.TextBox
        Me.txt_S_CoCde = New System.Windows.Forms.TextBox
        Me.lbl_S_PriCust = New System.Windows.Forms.Label
        Me.lbl_S_CoCde = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Panel10.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblRptName
        '
        Me.lblRptName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRptName.ForeColor = System.Drawing.Color.Blue
        Me.lblRptName.Location = New System.Drawing.Point(94, 9)
        Me.lblRptName.Name = "lblRptName"
        Me.lblRptName.Size = New System.Drawing.Size(509, 21)
        Me.lblRptName.TabIndex = 31
        Me.lblRptName.Text = "Claims Analysis Report (Summary List Format)"
        Me.lblRptName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.Combo1)
        Me.Panel10.Controls.Add(Me.Label13)
        Me.Panel10.Location = New System.Drawing.Point(43, 630)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(484, 27)
        Me.Panel10.TabIndex = 9
        Me.Panel10.Visible = False
        '
        'Combo1
        '
        Me.Combo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo1.FormattingEnabled = True
        Me.Combo1.Location = New System.Drawing.Point(169, 5)
        Me.Combo1.Name = "Combo1"
        Me.Combo1.Size = New System.Drawing.Size(307, 20)
        Me.Combo1.TabIndex = 25
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(13, 7)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 12)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Report Format :"
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(262, 410)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(216, 37)
        Me.cmdShow.TabIndex = 29
        Me.cmdShow.Text = "&Export To Excel"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Panel1)
        Me.GroupBox2.Location = New System.Drawing.Point(123, 322)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(496, 49)
        Me.GroupBox2.TabIndex = 24
        Me.GroupBox2.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.chk_1756)
        Me.Panel1.Controls.Add(Me.chk_ext)
        Me.Panel1.Controls.Add(Me.chk_int)
        Me.Panel1.Location = New System.Drawing.Point(6, 15)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(484, 27)
        Me.Panel1.TabIndex = 23
        '
        'chk_1756
        '
        Me.chk_1756.AutoSize = True
        Me.chk_1756.Location = New System.Drawing.Point(353, 6)
        Me.chk_1756.Name = "chk_1756"
        Me.chk_1756.Size = New System.Drawing.Size(80, 16)
        Me.chk_1756.TabIndex = 27
        Me.chk_1756.Text = "華匯(1756)"
        Me.chk_1756.UseVisualStyleBackColor = True
        '
        'chk_ext
        '
        Me.chk_ext.AutoSize = True
        Me.chk_ext.Location = New System.Drawing.Point(180, 6)
        Me.chk_ext.Name = "chk_ext"
        Me.chk_ext.Size = New System.Drawing.Size(133, 16)
        Me.chk_ext.TabIndex = 26
        Me.chk_ext.Text = "External (Except 1756)"
        Me.chk_ext.UseVisualStyleBackColor = True
        '
        'chk_int
        '
        Me.chk_int.AutoSize = True
        Me.chk_int.Checked = True
        Me.chk_int.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_int.Location = New System.Drawing.Point(28, 6)
        Me.chk_int.Name = "chk_int"
        Me.chk_int.Size = New System.Drawing.Size(60, 16)
        Me.chk_int.TabIndex = 25
        Me.chk_int.Text = "Internal"
        Me.chk_int.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.saveto_folder)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(652, 421)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(335, 49)
        Me.GroupBox1.TabIndex = 37
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Optional: Save to folder (at C: drive);   (if no input,save to C: drive)"
        Me.GroupBox1.Visible = False
        '
        'saveto_folder
        '
        Me.saveto_folder.Location = New System.Drawing.Point(26, 18)
        Me.saveto_folder.Name = "saveto_folder"
        Me.saveto_folder.Size = New System.Drawing.Size(124, 22)
        Me.saveto_folder.TabIndex = 28
        '
        'txt_S_SARvsdatTo
        '
        Me.txt_S_SARvsdatTo.Location = New System.Drawing.Point(468, 298)
        Me.txt_S_SARvsdatTo.Mask = "##/##/####"
        Me.txt_S_SARvsdatTo.Name = "txt_S_SARvsdatTo"
        Me.txt_S_SARvsdatTo.Size = New System.Drawing.Size(95, 22)
        Me.txt_S_SARvsdatTo.TabIndex = 22
        '
        'txt_S_SARvsdatFm
        '
        Me.txt_S_SARvsdatFm.Location = New System.Drawing.Point(195, 299)
        Me.txt_S_SARvsdatFm.Mask = "##/##/####"
        Me.txt_S_SARvsdatFm.Name = "txt_S_SARvsdatFm"
        Me.txt_S_SARvsdatFm.Size = New System.Drawing.Size(95, 22)
        Me.txt_S_SARvsdatFm.TabIndex = 21
        '
        'txt_S_SAIssdatTo
        '
        Me.txt_S_SAIssdatTo.Location = New System.Drawing.Point(468, 270)
        Me.txt_S_SAIssdatTo.Mask = "##/##/####"
        Me.txt_S_SAIssdatTo.Name = "txt_S_SAIssdatTo"
        Me.txt_S_SAIssdatTo.Size = New System.Drawing.Size(95, 22)
        Me.txt_S_SAIssdatTo.TabIndex = 20
        '
        'txt_S_SAIssdatFm
        '
        Me.txt_S_SAIssdatFm.Location = New System.Drawing.Point(195, 269)
        Me.txt_S_SAIssdatFm.Mask = "##/##/####"
        Me.txt_S_SAIssdatFm.Name = "txt_S_SAIssdatFm"
        Me.txt_S_SAIssdatFm.Size = New System.Drawing.Size(95, 22)
        Me.txt_S_SAIssdatFm.TabIndex = 19
        '
        'chk_donot_show_dtl
        '
        Me.chk_donot_show_dtl.AutoSize = True
        Me.chk_donot_show_dtl.Location = New System.Drawing.Point(157, 382)
        Me.chk_donot_show_dtl.Name = "chk_donot_show_dtl"
        Me.chk_donot_show_dtl.Size = New System.Drawing.Size(156, 16)
        Me.chk_donot_show_dtl.TabIndex = 28
        Me.chk_donot_show_dtl.Text = "Do not show shipment detail"
        Me.chk_donot_show_dtl.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(448, 304)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(18, 12)
        Me.Label9.TabIndex = 575
        Me.Label9.Text = "To"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(292, 300)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(87, 12)
        Me.Label8.TabIndex = 574
        Me.Label8.Text = "(MM/DD/YYYY)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(569, 303)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 12)
        Me.Label7.TabIndex = 573
        Me.Label7.Text = "(MM/DD/YYYY)"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(154, 302)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 12)
        Me.Label6.TabIndex = 572
        Me.Label6.Text = "From"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 302)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 12)
        Me.Label5.TabIndex = 571
        Me.Label5.Text = "Claim Approval Date"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(154, 275)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(30, 12)
        Me.Label19.TabIndex = 570
        Me.Label19.Text = "From"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(448, 275)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(18, 12)
        Me.Label20.TabIndex = 569
        Me.Label20.Text = "To"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(569, 275)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(87, 12)
        Me.Label21.TabIndex = 568
        Me.Label21.Text = "(MM/DD/YYYY)"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(292, 273)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(87, 12)
        Me.Label22.TabIndex = 567
        Me.Label22.Text = "(MM/DD/YYYY)"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(11, 275)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(100, 12)
        Me.Label23.TabIndex = 566
        Me.Label23.Text = "Claim Creation Date"
        '
        'txt_S_CaSts
        '
        Me.txt_S_CaSts.Location = New System.Drawing.Point(195, 242)
        Me.txt_S_CaSts.MaxLength = 5000
        Me.txt_S_CaSts.Name = "txt_S_CaSts"
        Me.txt_S_CaSts.Size = New System.Drawing.Size(469, 22)
        Me.txt_S_CaSts.TabIndex = 18
        '
        'cmd_S_CaSts
        '
        Me.cmd_S_CaSts.Location = New System.Drawing.Point(123, 240)
        Me.cmd_S_CaSts.Name = "cmd_S_CaSts"
        Me.cmd_S_CaSts.Size = New System.Drawing.Size(64, 22)
        Me.cmd_S_CaSts.TabIndex = 17
        Me.cmd_S_CaSts.Text = "＞＞"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 245)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 12)
        Me.Label4.TabIndex = 563
        Me.Label4.Text = "Claim Status"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 220)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 12)
        Me.Label3.TabIndex = 562
        Me.Label3.Text = "PO No"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 195)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 12)
        Me.Label2.TabIndex = 561
        Me.Label2.Text = "SC No"
        '
        'cmd_S_PONo
        '
        Me.cmd_S_PONo.Enabled = False
        Me.cmd_S_PONo.Location = New System.Drawing.Point(123, 215)
        Me.cmd_S_PONo.Name = "cmd_S_PONo"
        Me.cmd_S_PONo.Size = New System.Drawing.Size(64, 22)
        Me.cmd_S_PONo.TabIndex = 15
        Me.cmd_S_PONo.Text = "＞＞"
        '
        'txt_S_PONo
        '
        Me.txt_S_PONo.Enabled = False
        Me.txt_S_PONo.Location = New System.Drawing.Point(195, 217)
        Me.txt_S_PONo.MaxLength = 5000
        Me.txt_S_PONo.Name = "txt_S_PONo"
        Me.txt_S_PONo.Size = New System.Drawing.Size(469, 22)
        Me.txt_S_PONo.TabIndex = 16
        '
        'txt_S_SCNo
        '
        Me.txt_S_SCNo.Enabled = False
        Me.txt_S_SCNo.Location = New System.Drawing.Point(195, 192)
        Me.txt_S_SCNo.MaxLength = 5000
        Me.txt_S_SCNo.Name = "txt_S_SCNo"
        Me.txt_S_SCNo.Size = New System.Drawing.Size(469, 22)
        Me.txt_S_SCNo.TabIndex = 14
        '
        'cmd_S_SCNo
        '
        Me.cmd_S_SCNo.Enabled = False
        Me.cmd_S_SCNo.Location = New System.Drawing.Point(123, 190)
        Me.cmd_S_SCNo.Name = "cmd_S_SCNo"
        Me.cmd_S_SCNo.Size = New System.Drawing.Size(64, 22)
        Me.cmd_S_SCNo.TabIndex = 13
        Me.cmd_S_SCNo.Text = "＞＞"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 170)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 12)
        Me.Label1.TabIndex = 556
        Me.Label1.Text = "Claim No"
        '
        'txt_S_CaOrdNo
        '
        Me.txt_S_CaOrdNo.Location = New System.Drawing.Point(195, 167)
        Me.txt_S_CaOrdNo.MaxLength = 5000
        Me.txt_S_CaOrdNo.Name = "txt_S_CaOrdNo"
        Me.txt_S_CaOrdNo.Size = New System.Drawing.Size(469, 22)
        Me.txt_S_CaOrdNo.TabIndex = 12
        '
        'cmd_S_Clmno
        '
        Me.cmd_S_Clmno.Location = New System.Drawing.Point(123, 165)
        Me.cmd_S_Clmno.Name = "cmd_S_Clmno"
        Me.cmd_S_Clmno.Size = New System.Drawing.Size(64, 22)
        Me.cmd_S_Clmno.TabIndex = 11
        Me.cmd_S_Clmno.Text = "＞＞"
        '
        'cmd_S_PV
        '
        Me.cmd_S_PV.Location = New System.Drawing.Point(123, 140)
        Me.cmd_S_PV.Name = "cmd_S_PV"
        Me.cmd_S_PV.Size = New System.Drawing.Size(64, 22)
        Me.cmd_S_PV.TabIndex = 9
        Me.cmd_S_PV.Text = "＞＞"
        '
        'lbl_S_PV
        '
        Me.lbl_S_PV.AutoSize = True
        Me.lbl_S_PV.Location = New System.Drawing.Point(11, 145)
        Me.lbl_S_PV.Name = "lbl_S_PV"
        Me.lbl_S_PV.Size = New System.Drawing.Size(94, 12)
        Me.lbl_S_PV.TabIndex = 551
        Me.lbl_S_PV.Text = "Production Vendor"
        '
        'txt_S_PV
        '
        Me.txt_S_PV.Location = New System.Drawing.Point(195, 142)
        Me.txt_S_PV.MaxLength = 5000
        Me.txt_S_PV.Name = "txt_S_PV"
        Me.txt_S_PV.Size = New System.Drawing.Size(469, 22)
        Me.txt_S_PV.TabIndex = 10
        '
        'cmd_S_SecCust
        '
        Me.cmd_S_SecCust.Location = New System.Drawing.Point(123, 90)
        Me.cmd_S_SecCust.Name = "cmd_S_SecCust"
        Me.cmd_S_SecCust.Size = New System.Drawing.Size(64, 22)
        Me.cmd_S_SecCust.TabIndex = 5
        Me.cmd_S_SecCust.Text = "＞＞"
        '
        'txt_S_SecCust
        '
        Me.txt_S_SecCust.Location = New System.Drawing.Point(195, 92)
        Me.txt_S_SecCust.MaxLength = 5000
        Me.txt_S_SecCust.Name = "txt_S_SecCust"
        Me.txt_S_SecCust.Size = New System.Drawing.Size(469, 22)
        Me.txt_S_SecCust.TabIndex = 6
        '
        'lbl_S_SecCust
        '
        Me.lbl_S_SecCust.AutoSize = True
        Me.lbl_S_SecCust.Location = New System.Drawing.Point(11, 95)
        Me.lbl_S_SecCust.Name = "lbl_S_SecCust"
        Me.lbl_S_SecCust.Size = New System.Drawing.Size(69, 12)
        Me.lbl_S_SecCust.TabIndex = 548
        Me.lbl_S_SecCust.Text = "Sec Customer"
        '
        'cmd_S_ItmNo
        '
        Me.cmd_S_ItmNo.Location = New System.Drawing.Point(123, 115)
        Me.cmd_S_ItmNo.Name = "cmd_S_ItmNo"
        Me.cmd_S_ItmNo.Size = New System.Drawing.Size(64, 22)
        Me.cmd_S_ItmNo.TabIndex = 7
        Me.cmd_S_ItmNo.Text = "＞＞"
        '
        'cmd_S_PriCust
        '
        Me.cmd_S_PriCust.Location = New System.Drawing.Point(123, 66)
        Me.cmd_S_PriCust.Name = "cmd_S_PriCust"
        Me.cmd_S_PriCust.Size = New System.Drawing.Size(64, 22)
        Me.cmd_S_PriCust.TabIndex = 3
        Me.cmd_S_PriCust.Text = "＞＞"
        '
        'cmd_S_CoCde
        '
        Me.cmd_S_CoCde.Location = New System.Drawing.Point(123, 41)
        Me.cmd_S_CoCde.Name = "cmd_S_CoCde"
        Me.cmd_S_CoCde.Size = New System.Drawing.Size(64, 22)
        Me.cmd_S_CoCde.TabIndex = 1
        Me.cmd_S_CoCde.Text = "＞＞"
        '
        'lbl_S_ItmNo
        '
        Me.lbl_S_ItmNo.AutoSize = True
        Me.lbl_S_ItmNo.Location = New System.Drawing.Point(11, 120)
        Me.lbl_S_ItmNo.Name = "lbl_S_ItmNo"
        Me.lbl_S_ItmNo.Size = New System.Drawing.Size(43, 12)
        Me.lbl_S_ItmNo.TabIndex = 541
        Me.lbl_S_ItmNo.Text = "Item No"
        '
        'txt_S_ItmNo
        '
        Me.txt_S_ItmNo.Location = New System.Drawing.Point(195, 117)
        Me.txt_S_ItmNo.MaxLength = 5000
        Me.txt_S_ItmNo.Name = "txt_S_ItmNo"
        Me.txt_S_ItmNo.Size = New System.Drawing.Size(469, 22)
        Me.txt_S_ItmNo.TabIndex = 8
        '
        'txt_S_PriCust
        '
        Me.txt_S_PriCust.Location = New System.Drawing.Point(195, 67)
        Me.txt_S_PriCust.MaxLength = 5000
        Me.txt_S_PriCust.Name = "txt_S_PriCust"
        Me.txt_S_PriCust.Size = New System.Drawing.Size(469, 22)
        Me.txt_S_PriCust.TabIndex = 4
        '
        'txt_S_CoCde
        '
        Me.txt_S_CoCde.Enabled = False
        Me.txt_S_CoCde.Location = New System.Drawing.Point(195, 42)
        Me.txt_S_CoCde.MaxLength = 5000
        Me.txt_S_CoCde.Name = "txt_S_CoCde"
        Me.txt_S_CoCde.Size = New System.Drawing.Size(469, 22)
        Me.txt_S_CoCde.TabIndex = 2
        '
        'lbl_S_PriCust
        '
        Me.lbl_S_PriCust.AutoSize = True
        Me.lbl_S_PriCust.Location = New System.Drawing.Point(11, 70)
        Me.lbl_S_PriCust.Name = "lbl_S_PriCust"
        Me.lbl_S_PriCust.Size = New System.Drawing.Size(66, 12)
        Me.lbl_S_PriCust.TabIndex = 540
        Me.lbl_S_PriCust.Text = "Pri Customer"
        '
        'lbl_S_CoCde
        '
        Me.lbl_S_CoCde.AutoSize = True
        Me.lbl_S_CoCde.Location = New System.Drawing.Point(11, 45)
        Me.lbl_S_CoCde.Name = "lbl_S_CoCde"
        Me.lbl_S_CoCde.Size = New System.Drawing.Size(79, 12)
        Me.lbl_S_CoCde.TabIndex = 539
        Me.lbl_S_CoCde.Text = "Company Code"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 343)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 12)
        Me.Label10.TabIndex = 576
        Me.Label10.Text = "Vendor Type"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(11, 383)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(79, 12)
        Me.Label11.TabIndex = 577
        Me.Label11.Text = "Shipment Detail"
        '
        'CLR00005
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(714, 471)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txt_S_SARvsdatTo)
        Me.Controls.Add(Me.txt_S_SARvsdatFm)
        Me.Controls.Add(Me.txt_S_SAIssdatTo)
        Me.Controls.Add(Me.txt_S_SAIssdatFm)
        Me.Controls.Add(Me.chk_donot_show_dtl)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.txt_S_CaSts)
        Me.Controls.Add(Me.cmd_S_CaSts)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmd_S_PONo)
        Me.Controls.Add(Me.txt_S_PONo)
        Me.Controls.Add(Me.txt_S_SCNo)
        Me.Controls.Add(Me.cmd_S_SCNo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_S_CaOrdNo)
        Me.Controls.Add(Me.cmd_S_Clmno)
        Me.Controls.Add(Me.cmd_S_PV)
        Me.Controls.Add(Me.lbl_S_PV)
        Me.Controls.Add(Me.txt_S_PV)
        Me.Controls.Add(Me.cmd_S_SecCust)
        Me.Controls.Add(Me.txt_S_SecCust)
        Me.Controls.Add(Me.lbl_S_SecCust)
        Me.Controls.Add(Me.cmd_S_ItmNo)
        Me.Controls.Add(Me.cmd_S_PriCust)
        Me.Controls.Add(Me.cmd_S_CoCde)
        Me.Controls.Add(Me.lbl_S_ItmNo)
        Me.Controls.Add(Me.txt_S_ItmNo)
        Me.Controls.Add(Me.txt_S_PriCust)
        Me.Controls.Add(Me.txt_S_CoCde)
        Me.Controls.Add(Me.lbl_S_PriCust)
        Me.Controls.Add(Me.lbl_S_CoCde)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel10)
        Me.Controls.Add(Me.lblRptName)
        Me.Controls.Add(Me.cmdShow)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(556, 283)
        Me.Name = "CLR00005"
        Me.Text = "CLR00005 - Claims Analysis Report (Summary List Format) (CLR04)"
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblRptName As System.Windows.Forms.Label
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents Combo1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents saveto_folder As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents chk_1756 As System.Windows.Forms.CheckBox
    Friend WithEvents chk_ext As System.Windows.Forms.CheckBox
    Friend WithEvents chk_int As System.Windows.Forms.CheckBox
    Friend WithEvents txt_S_SARvsdatTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_S_SARvsdatFm As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_S_SAIssdatTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_S_SAIssdatFm As System.Windows.Forms.MaskedTextBox
    Friend WithEvents chk_donot_show_dtl As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txt_S_CaSts As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_CaSts As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmd_S_PONo As System.Windows.Forms.Button
    Friend WithEvents txt_S_PONo As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_SCNo As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_SCNo As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_S_CaOrdNo As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_Clmno As System.Windows.Forms.Button
    Friend WithEvents cmd_S_PV As System.Windows.Forms.Button
    Friend WithEvents lbl_S_PV As System.Windows.Forms.Label
    Friend WithEvents txt_S_PV As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_SecCust As System.Windows.Forms.Button
    Friend WithEvents txt_S_SecCust As System.Windows.Forms.TextBox
    Friend WithEvents lbl_S_SecCust As System.Windows.Forms.Label
    Friend WithEvents cmd_S_ItmNo As System.Windows.Forms.Button
    Friend WithEvents cmd_S_PriCust As System.Windows.Forms.Button
    Friend WithEvents cmd_S_CoCde As System.Windows.Forms.Button
    Friend WithEvents lbl_S_ItmNo As System.Windows.Forms.Label
    Friend WithEvents txt_S_ItmNo As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_PriCust As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_CoCde As System.Windows.Forms.TextBox
    Friend WithEvents lbl_S_PriCust As System.Windows.Forms.Label
    Friend WithEvents lbl_S_CoCde As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
End Class
