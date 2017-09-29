<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PGR00001
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PGR00001))
        Me.txt_S_SCNo = New System.Windows.Forms.TextBox
        Me.cmd_S_SCNo = New System.Windows.Forms.Button
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtSCIssdatTo = New System.Windows.Forms.MaskedTextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtSCIssdatFm = New System.Windows.Forms.MaskedTextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_S_ItmNo = New System.Windows.Forms.TextBox
        Me.cmd_S_ItmNo = New System.Windows.Forms.Button
        Me.txt_S_PKGNo = New System.Windows.Forms.TextBox
        Me.cmd_S_PKGNo = New System.Windows.Forms.Button
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
        Me.lblRptName = New System.Windows.Forms.Label
        Me.txt_S_PkItmNo = New System.Windows.Forms.TextBox
        Me.cmd_S_PkItmNo = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.txt_S_PV_PC = New System.Windows.Forms.TextBox
        Me.cmd_S_PV_PC = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmdShow = New System.Windows.Forms.Button
        Me.txt_S_TONo = New System.Windows.Forms.TextBox
        Me.cmd_S_TONo = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.PBar = New System.Windows.Forms.ProgressBar
        Me.txt_S_SKUNo = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.txt_S_CusStyleNo = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rdoQutNew = New System.Windows.Forms.RadioButton
        Me.rdoQutUpd = New System.Windows.Forms.RadioButton
        Me.chkQutUpd = New System.Windows.Forms.CheckBox
        Me.chkQutNew = New System.Windows.Forms.CheckBox
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txt_S_SCNo
        '
        Me.txt_S_SCNo.Location = New System.Drawing.Point(186, 334)
        Me.txt_S_SCNo.Name = "txt_S_SCNo"
        Me.txt_S_SCNo.Size = New System.Drawing.Size(502, 22)
        Me.txt_S_SCNo.TabIndex = 23
        '
        'cmd_S_SCNo
        '
        Me.cmd_S_SCNo.Location = New System.Drawing.Point(127, 332)
        Me.cmd_S_SCNo.Name = "cmd_S_SCNo"
        Me.cmd_S_SCNo.Size = New System.Drawing.Size(53, 21)
        Me.cmd_S_SCNo.TabIndex = 22
        Me.cmd_S_SCNo.Text = ">>"
        Me.cmd_S_SCNo.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(13, 334)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(19, 12)
        Me.Label17.TabIndex = 47
        Me.Label17.Text = "SC"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(417, 419)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(79, 12)
        Me.Label16.TabIndex = 46
        Me.Label16.Text = "MM/DD/YYYY"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(246, 419)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(79, 12)
        Me.Label15.TabIndex = 45
        Me.Label15.Text = "MM/DD/YYYY"
        '
        'txtSCIssdatTo
        '
        Me.txtSCIssdatTo.Location = New System.Drawing.Point(417, 397)
        Me.txtSCIssdatTo.Mask = "00/00/0000"
        Me.txtSCIssdatTo.Name = "txtSCIssdatTo"
        Me.txtSCIssdatTo.Size = New System.Drawing.Size(100, 22)
        Me.txtSCIssdatTo.TabIndex = 27
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(384, 400)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(18, 12)
        Me.Label8.TabIndex = 43
        Me.Label8.Text = "To"
        '
        'txtSCIssdatFm
        '
        Me.txtSCIssdatFm.Location = New System.Drawing.Point(247, 397)
        Me.txtSCIssdatFm.Mask = "00/00/0000"
        Me.txtSCIssdatFm.Name = "txtSCIssdatFm"
        Me.txtSCIssdatFm.Size = New System.Drawing.Size(100, 22)
        Me.txtSCIssdatFm.TabIndex = 26
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(201, 400)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 12)
        Me.Label7.TabIndex = 41
        Me.Label7.Text = "From"
        '
        'txt_S_ItmNo
        '
        Me.txt_S_ItmNo.Location = New System.Drawing.Point(186, 246)
        Me.txt_S_ItmNo.Name = "txt_S_ItmNo"
        Me.txt_S_ItmNo.Size = New System.Drawing.Size(502, 22)
        Me.txt_S_ItmNo.TabIndex = 17
        '
        'cmd_S_ItmNo
        '
        Me.cmd_S_ItmNo.Location = New System.Drawing.Point(127, 244)
        Me.cmd_S_ItmNo.Name = "cmd_S_ItmNo"
        Me.cmd_S_ItmNo.Size = New System.Drawing.Size(53, 21)
        Me.cmd_S_ItmNo.TabIndex = 16
        Me.cmd_S_ItmNo.Text = ">>"
        Me.cmd_S_ItmNo.UseVisualStyleBackColor = True
        '
        'txt_S_PKGNo
        '
        Me.txt_S_PKGNo.Location = New System.Drawing.Point(186, 151)
        Me.txt_S_PKGNo.Name = "txt_S_PKGNo"
        Me.txt_S_PKGNo.Size = New System.Drawing.Size(502, 22)
        Me.txt_S_PKGNo.TabIndex = 11
        '
        'cmd_S_PKGNo
        '
        Me.cmd_S_PKGNo.Location = New System.Drawing.Point(127, 148)
        Me.cmd_S_PKGNo.Name = "cmd_S_PKGNo"
        Me.cmd_S_PKGNo.Size = New System.Drawing.Size(53, 21)
        Me.cmd_S_PKGNo.TabIndex = 10
        Me.cmd_S_PKGNo.Text = ">>"
        Me.cmd_S_PKGNo.UseVisualStyleBackColor = True
        '
        'txt_S_SecCustAll
        '
        Me.txt_S_SecCustAll.Location = New System.Drawing.Point(186, 118)
        Me.txt_S_SecCustAll.Name = "txt_S_SecCustAll"
        Me.txt_S_SecCustAll.Size = New System.Drawing.Size(502, 22)
        Me.txt_S_SecCustAll.TabIndex = 9
        '
        'cmd_S_SecCust
        '
        Me.cmd_S_SecCust.Location = New System.Drawing.Point(127, 116)
        Me.cmd_S_SecCust.Name = "cmd_S_SecCust"
        Me.cmd_S_SecCust.Size = New System.Drawing.Size(53, 21)
        Me.cmd_S_SecCust.TabIndex = 8
        Me.cmd_S_SecCust.Text = ">>"
        Me.cmd_S_SecCust.UseVisualStyleBackColor = True
        '
        'txt_S_PriCustAll
        '
        Me.txt_S_PriCustAll.Location = New System.Drawing.Point(186, 86)
        Me.txt_S_PriCustAll.Name = "txt_S_PriCustAll"
        Me.txt_S_PriCustAll.Size = New System.Drawing.Size(502, 22)
        Me.txt_S_PriCustAll.TabIndex = 7
        '
        'cmd_S_PriCust
        '
        Me.cmd_S_PriCust.Location = New System.Drawing.Point(127, 84)
        Me.cmd_S_PriCust.Name = "cmd_S_PriCust"
        Me.cmd_S_PriCust.Size = New System.Drawing.Size(53, 21)
        Me.cmd_S_PriCust.TabIndex = 6
        Me.cmd_S_PriCust.Text = ">>"
        Me.cmd_S_PriCust.UseVisualStyleBackColor = True
        '
        'txt_S_CoCde
        '
        Me.txt_S_CoCde.Location = New System.Drawing.Point(186, 54)
        Me.txt_S_CoCde.Name = "txt_S_CoCde"
        Me.txt_S_CoCde.Size = New System.Drawing.Size(502, 22)
        Me.txt_S_CoCde.TabIndex = 5
        '
        'cmd_S_CoCde
        '
        Me.cmd_S_CoCde.Location = New System.Drawing.Point(127, 52)
        Me.cmd_S_CoCde.Name = "cmd_S_CoCde"
        Me.cmd_S_CoCde.Size = New System.Drawing.Size(53, 21)
        Me.cmd_S_CoCde.TabIndex = 4
        Me.cmd_S_CoCde.Text = ">>"
        Me.cmd_S_CoCde.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 398)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 12)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Pack Req Create Date"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 246)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 12)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Item No."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 152)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 12)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Pack Req No."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 119)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 12)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Sec. Customer"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 12)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Pri. Customer"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 12)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Company Code"
        '
        'lblRptName
        '
        Me.lblRptName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRptName.ForeColor = System.Drawing.Color.Blue
        Me.lblRptName.Location = New System.Drawing.Point(98, 8)
        Me.lblRptName.Name = "lblRptName"
        Me.lblRptName.Size = New System.Drawing.Size(509, 28)
        Me.lblRptName.TabIndex = 50
        Me.lblRptName.Text = "Packaging Request Information Export"
        Me.lblRptName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_S_PkItmNo
        '
        Me.txt_S_PkItmNo.Location = New System.Drawing.Point(186, 183)
        Me.txt_S_PkItmNo.Name = "txt_S_PkItmNo"
        Me.txt_S_PkItmNo.Size = New System.Drawing.Size(502, 22)
        Me.txt_S_PkItmNo.TabIndex = 13
        '
        'cmd_S_PkItmNo
        '
        Me.cmd_S_PkItmNo.Location = New System.Drawing.Point(127, 181)
        Me.cmd_S_PkItmNo.Name = "cmd_S_PkItmNo"
        Me.cmd_S_PkItmNo.Size = New System.Drawing.Size(53, 21)
        Me.cmd_S_PkItmNo.TabIndex = 12
        Me.cmd_S_PkItmNo.Text = ">>"
        Me.cmd_S_PkItmNo.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 184)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 12)
        Me.Label9.TabIndex = 51
        Me.Label9.Text = "Pack Item."
        '
        'txt_S_PV_PC
        '
        Me.txt_S_PV_PC.Location = New System.Drawing.Point(186, 214)
        Me.txt_S_PV_PC.Name = "txt_S_PV_PC"
        Me.txt_S_PV_PC.Size = New System.Drawing.Size(502, 22)
        Me.txt_S_PV_PC.TabIndex = 15
        '
        'cmd_S_PV_PC
        '
        Me.cmd_S_PV_PC.Location = New System.Drawing.Point(127, 212)
        Me.cmd_S_PV_PC.Name = "cmd_S_PV_PC"
        Me.cmd_S_PV_PC.Size = New System.Drawing.Size(53, 21)
        Me.cmd_S_PV_PC.TabIndex = 14
        Me.cmd_S_PV_PC.Text = ">>"
        Me.cmd_S_PV_PC.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 215)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 12)
        Me.Label10.TabIndex = 54
        Me.Label10.Text = "Print Co."
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(569, 395)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(116, 37)
        Me.cmdShow.TabIndex = 28
        Me.cmdShow.Text = "&Export To Excel"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'txt_S_TONo
        '
        Me.txt_S_TONo.Location = New System.Drawing.Point(186, 368)
        Me.txt_S_TONo.Name = "txt_S_TONo"
        Me.txt_S_TONo.Size = New System.Drawing.Size(502, 22)
        Me.txt_S_TONo.TabIndex = 25
        '
        'cmd_S_TONo
        '
        Me.cmd_S_TONo.Location = New System.Drawing.Point(127, 366)
        Me.cmd_S_TONo.Name = "cmd_S_TONo"
        Me.cmd_S_TONo.Size = New System.Drawing.Size(53, 21)
        Me.cmd_S_TONo.TabIndex = 24
        Me.cmd_S_TONo.Text = ">>"
        Me.cmd_S_TONo.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 368)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(20, 12)
        Me.Label11.TabIndex = 58
        Me.Label11.Text = "TO"
        '
        'PBar
        '
        Me.PBar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PBar.Location = New System.Drawing.Point(0, 437)
        Me.PBar.Name = "PBar"
        Me.PBar.Size = New System.Drawing.Size(704, 24)
        Me.PBar.TabIndex = 61
        '
        'txt_S_SKUNo
        '
        Me.txt_S_SKUNo.Location = New System.Drawing.Point(187, 275)
        Me.txt_S_SKUNo.Name = "txt_S_SKUNo"
        Me.txt_S_SKUNo.Size = New System.Drawing.Size(502, 22)
        Me.txt_S_SKUNo.TabIndex = 19
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(128, 273)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(53, 21)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = ">>"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(13, 276)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(44, 12)
        Me.Label12.TabIndex = 62
        Me.Label12.Text = "SKU No"
        '
        'txt_S_CusStyleNo
        '
        Me.txt_S_CusStyleNo.Location = New System.Drawing.Point(187, 304)
        Me.txt_S_CusStyleNo.Name = "txt_S_CusStyleNo"
        Me.txt_S_CusStyleNo.Size = New System.Drawing.Size(502, 22)
        Me.txt_S_CusStyleNo.TabIndex = 21
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(128, 302)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(53, 21)
        Me.Button2.TabIndex = 20
        Me.Button2.Text = ">>"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(13, 305)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(96, 12)
        Me.Label13.TabIndex = 65
        Me.Label13.Text = "Customer Style No."
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rdoQutNew)
        Me.GroupBox2.Controls.Add(Me.rdoQutUpd)
        Me.GroupBox2.Location = New System.Drawing.Point(542, 11)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(145, 40)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'rdoQutNew
        '
        Me.rdoQutNew.AutoSize = True
        Me.rdoQutNew.Location = New System.Drawing.Point(71, 14)
        Me.rdoQutNew.Name = "rdoQutNew"
        Me.rdoQutNew.Size = New System.Drawing.Size(44, 16)
        Me.rdoQutNew.TabIndex = 5
        Me.rdoQutNew.Text = "New"
        Me.rdoQutNew.UseVisualStyleBackColor = True
        '
        'rdoQutUpd
        '
        Me.rdoQutUpd.AutoSize = True
        Me.rdoQutUpd.Checked = True
        Me.rdoQutUpd.Location = New System.Drawing.Point(9, 14)
        Me.rdoQutUpd.Name = "rdoQutUpd"
        Me.rdoQutUpd.Size = New System.Drawing.Size(56, 16)
        Me.rdoQutUpd.TabIndex = 4
        Me.rdoQutUpd.TabStop = True
        Me.rdoQutUpd.Text = "Update"
        Me.rdoQutUpd.UseVisualStyleBackColor = True
        '
        'chkQutUpd
        '
        Me.chkQutUpd.AutoSize = True
        Me.chkQutUpd.Location = New System.Drawing.Point(63, 18)
        Me.chkQutUpd.Margin = New System.Windows.Forms.Padding(2)
        Me.chkQutUpd.Name = "chkQutUpd"
        Me.chkQutUpd.Size = New System.Drawing.Size(57, 16)
        Me.chkQutUpd.TabIndex = 2
        Me.chkQutUpd.Text = "Update"
        Me.chkQutUpd.UseVisualStyleBackColor = True
        Me.chkQutUpd.Visible = False
        '
        'chkQutNew
        '
        Me.chkQutNew.AutoSize = True
        Me.chkQutNew.Location = New System.Drawing.Point(128, 20)
        Me.chkQutNew.Margin = New System.Windows.Forms.Padding(2)
        Me.chkQutNew.Name = "chkQutNew"
        Me.chkQutNew.Size = New System.Drawing.Size(45, 16)
        Me.chkQutNew.TabIndex = 3
        Me.chkQutNew.Text = "New"
        Me.chkQutNew.UseVisualStyleBackColor = True
        Me.chkQutNew.Visible = False
        '
        'PGR00001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(704, 461)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.txt_S_CusStyleNo)
        Me.Controls.Add(Me.chkQutNew)
        Me.Controls.Add(Me.chkQutUpd)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txt_S_SKUNo)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.PBar)
        Me.Controls.Add(Me.txt_S_TONo)
        Me.Controls.Add(Me.cmd_S_TONo)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.txt_S_PV_PC)
        Me.Controls.Add(Me.cmd_S_PV_PC)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txt_S_PkItmNo)
        Me.Controls.Add(Me.cmd_S_PkItmNo)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblRptName)
        Me.Controls.Add(Me.txt_S_SCNo)
        Me.Controls.Add(Me.cmd_S_SCNo)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtSCIssdatTo)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtSCIssdatFm)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txt_S_ItmNo)
        Me.Controls.Add(Me.cmd_S_ItmNo)
        Me.Controls.Add(Me.txt_S_PKGNo)
        Me.Controls.Add(Me.cmd_S_PKGNo)
        Me.Controls.Add(Me.txt_S_SecCustAll)
        Me.Controls.Add(Me.cmd_S_SecCust)
        Me.Controls.Add(Me.txt_S_PriCustAll)
        Me.Controls.Add(Me.cmd_S_PriCust)
        Me.Controls.Add(Me.txt_S_CoCde)
        Me.Controls.Add(Me.cmd_S_CoCde)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "PGR00001"
        Me.Text = "PGR00001 - Packaging Request Information Export (PGR01)"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_S_SCNo As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_SCNo As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtSCIssdatTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtSCIssdatFm As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_S_ItmNo As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_ItmNo As System.Windows.Forms.Button
    Friend WithEvents txt_S_PKGNo As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_PKGNo As System.Windows.Forms.Button
    Friend WithEvents txt_S_SecCustAll As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_SecCust As System.Windows.Forms.Button
    Friend WithEvents txt_S_PriCustAll As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_PriCust As System.Windows.Forms.Button
    Friend WithEvents txt_S_CoCde As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_CoCde As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblRptName As System.Windows.Forms.Label
    Friend WithEvents txt_S_PkItmNo As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_PkItmNo As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_S_PV_PC As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_PV_PC As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents txt_S_TONo As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_TONo As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents PBar As System.Windows.Forms.ProgressBar
    Friend WithEvents txt_S_SKUNo As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txt_S_CusStyleNo As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkQutUpd As System.Windows.Forms.CheckBox
    Friend WithEvents chkQutNew As System.Windows.Forms.CheckBox
    Friend WithEvents rdoQutUpd As System.Windows.Forms.RadioButton
    Friend WithEvents rdoQutNew As System.Windows.Forms.RadioButton
End Class
