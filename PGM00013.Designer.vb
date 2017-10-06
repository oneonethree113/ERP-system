<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PGM00013
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PGM00013))
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
        Me.Label12 = New System.Windows.Forms.Label
        Me.cbscpkgcst = New System.Windows.Forms.CheckBox
        Me.cbpkgestcst = New System.Windows.Forms.CheckBox
        Me.cbpcknetpo = New System.Windows.Forms.CheckBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbSCTO_TO = New System.Windows.Forms.RadioButton
        Me.rbSCTO_SC = New System.Windows.Forms.RadioButton
        Me.rbSCTO_All = New System.Windows.Forms.RadioButton
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txt_S_SCNo
        '
        Me.txt_S_SCNo.Location = New System.Drawing.Point(197, 201)
        Me.txt_S_SCNo.Name = "txt_S_SCNo"
        Me.txt_S_SCNo.Size = New System.Drawing.Size(499, 22)
        Me.txt_S_SCNo.TabIndex = 40
        '
        'cmd_S_SCNo
        '
        Me.cmd_S_SCNo.Location = New System.Drawing.Point(138, 200)
        Me.cmd_S_SCNo.Name = "cmd_S_SCNo"
        Me.cmd_S_SCNo.Size = New System.Drawing.Size(53, 21)
        Me.cmd_S_SCNo.TabIndex = 39
        Me.cmd_S_SCNo.Text = ">>"
        Me.cmd_S_SCNo.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(21, 204)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(78, 12)
        Me.Label17.TabIndex = 47
        Me.Label17.Text = "Sales Order No."
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(523, 348)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(79, 12)
        Me.Label16.TabIndex = 46
        Me.Label16.Text = "MM/DD/YYYY"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(304, 348)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(79, 12)
        Me.Label15.TabIndex = 45
        Me.Label15.Text = "MM/DD/YYYY"
        '
        'txtSCIssdatTo
        '
        Me.txtSCIssdatTo.Location = New System.Drawing.Point(452, 343)
        Me.txtSCIssdatTo.Mask = "00/00/0000"
        Me.txtSCIssdatTo.Name = "txtSCIssdatTo"
        Me.txtSCIssdatTo.Size = New System.Drawing.Size(65, 22)
        Me.txtSCIssdatTo.TabIndex = 49
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(419, 346)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(18, 12)
        Me.Label8.TabIndex = 43
        Me.Label8.Text = "To"
        '
        'txtSCIssdatFm
        '
        Me.txtSCIssdatFm.Location = New System.Drawing.Point(233, 343)
        Me.txtSCIssdatFm.Mask = "00/00/0000"
        Me.txtSCIssdatFm.Name = "txtSCIssdatFm"
        Me.txtSCIssdatFm.Size = New System.Drawing.Size(65, 22)
        Me.txtSCIssdatFm.TabIndex = 48
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(187, 346)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 12)
        Me.Label7.TabIndex = 41
        Me.Label7.Text = "From"
        '
        'txt_S_ItmNo
        '
        Me.txt_S_ItmNo.Location = New System.Drawing.Point(197, 169)
        Me.txt_S_ItmNo.Name = "txt_S_ItmNo"
        Me.txt_S_ItmNo.Size = New System.Drawing.Size(499, 22)
        Me.txt_S_ItmNo.TabIndex = 38
        '
        'cmd_S_ItmNo
        '
        Me.cmd_S_ItmNo.Location = New System.Drawing.Point(138, 167)
        Me.cmd_S_ItmNo.Name = "cmd_S_ItmNo"
        Me.cmd_S_ItmNo.Size = New System.Drawing.Size(53, 21)
        Me.cmd_S_ItmNo.TabIndex = 37
        Me.cmd_S_ItmNo.Text = ">>"
        Me.cmd_S_ItmNo.UseVisualStyleBackColor = True
        '
        'txt_S_PKGNo
        '
        Me.txt_S_PKGNo.Location = New System.Drawing.Point(652, 8)
        Me.txt_S_PKGNo.Name = "txt_S_PKGNo"
        Me.txt_S_PKGNo.Size = New System.Drawing.Size(32, 22)
        Me.txt_S_PKGNo.TabIndex = 38
        Me.txt_S_PKGNo.Visible = False
        '
        'cmd_S_PKGNo
        '
        Me.cmd_S_PKGNo.Location = New System.Drawing.Point(600, 8)
        Me.cmd_S_PKGNo.Name = "cmd_S_PKGNo"
        Me.cmd_S_PKGNo.Size = New System.Drawing.Size(53, 20)
        Me.cmd_S_PKGNo.TabIndex = 37
        Me.cmd_S_PKGNo.Text = ">>"
        Me.cmd_S_PKGNo.UseVisualStyleBackColor = True
        Me.cmd_S_PKGNo.Visible = False
        '
        'txt_S_SecCustAll
        '
        Me.txt_S_SecCustAll.Location = New System.Drawing.Point(197, 134)
        Me.txt_S_SecCustAll.Name = "txt_S_SecCustAll"
        Me.txt_S_SecCustAll.Size = New System.Drawing.Size(499, 22)
        Me.txt_S_SecCustAll.TabIndex = 36
        '
        'cmd_S_SecCust
        '
        Me.cmd_S_SecCust.Location = New System.Drawing.Point(138, 132)
        Me.cmd_S_SecCust.Name = "cmd_S_SecCust"
        Me.cmd_S_SecCust.Size = New System.Drawing.Size(53, 21)
        Me.cmd_S_SecCust.TabIndex = 35
        Me.cmd_S_SecCust.Text = ">>"
        Me.cmd_S_SecCust.UseVisualStyleBackColor = True
        '
        'txt_S_PriCustAll
        '
        Me.txt_S_PriCustAll.Location = New System.Drawing.Point(197, 102)
        Me.txt_S_PriCustAll.Name = "txt_S_PriCustAll"
        Me.txt_S_PriCustAll.Size = New System.Drawing.Size(499, 22)
        Me.txt_S_PriCustAll.TabIndex = 34
        '
        'cmd_S_PriCust
        '
        Me.cmd_S_PriCust.Location = New System.Drawing.Point(138, 100)
        Me.cmd_S_PriCust.Name = "cmd_S_PriCust"
        Me.cmd_S_PriCust.Size = New System.Drawing.Size(53, 21)
        Me.cmd_S_PriCust.TabIndex = 33
        Me.cmd_S_PriCust.Text = ">>"
        Me.cmd_S_PriCust.UseVisualStyleBackColor = True
        '
        'txt_S_CoCde
        '
        Me.txt_S_CoCde.Location = New System.Drawing.Point(197, 69)
        Me.txt_S_CoCde.Name = "txt_S_CoCde"
        Me.txt_S_CoCde.Size = New System.Drawing.Size(499, 22)
        Me.txt_S_CoCde.TabIndex = 32
        '
        'cmd_S_CoCde
        '
        Me.cmd_S_CoCde.Location = New System.Drawing.Point(138, 68)
        Me.cmd_S_CoCde.Name = "cmd_S_CoCde"
        Me.cmd_S_CoCde.Size = New System.Drawing.Size(53, 21)
        Me.cmd_S_CoCde.TabIndex = 31
        Me.cmd_S_CoCde.Text = ">>"
        Me.cmd_S_CoCde.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(22, 346)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 12)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "SC/TO Issue Date"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 172)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 12)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Item No."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(547, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 12)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Pack Ord No."
        Me.Label4.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 137)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 12)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Sec. Customer"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 105)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 12)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Pri. Customer"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 12)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Company Code"
        '
        'lblRptName
        '
        Me.lblRptName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRptName.ForeColor = System.Drawing.Color.Blue
        Me.lblRptName.Location = New System.Drawing.Point(106, 26)
        Me.lblRptName.Name = "lblRptName"
        Me.lblRptName.Size = New System.Drawing.Size(509, 30)
        Me.lblRptName.TabIndex = 50
        Me.lblRptName.Text = "Packaging Order Cost Comparsion Report"
        Me.lblRptName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_S_PkItmNo
        '
        Me.txt_S_PkItmNo.Location = New System.Drawing.Point(652, 28)
        Me.txt_S_PkItmNo.Name = "txt_S_PkItmNo"
        Me.txt_S_PkItmNo.Size = New System.Drawing.Size(32, 22)
        Me.txt_S_PkItmNo.TabIndex = 53
        Me.txt_S_PkItmNo.Visible = False
        '
        'cmd_S_PkItmNo
        '
        Me.cmd_S_PkItmNo.Location = New System.Drawing.Point(600, 27)
        Me.cmd_S_PkItmNo.Name = "cmd_S_PkItmNo"
        Me.cmd_S_PkItmNo.Size = New System.Drawing.Size(53, 20)
        Me.cmd_S_PkItmNo.TabIndex = 52
        Me.cmd_S_PkItmNo.Text = ">>"
        Me.cmd_S_PkItmNo.UseVisualStyleBackColor = True
        Me.cmd_S_PkItmNo.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(547, 30)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 12)
        Me.Label9.TabIndex = 51
        Me.Label9.Text = "Pack Item."
        Me.Label9.Visible = False
        '
        'txt_S_PV_PC
        '
        Me.txt_S_PV_PC.Location = New System.Drawing.Point(652, 43)
        Me.txt_S_PV_PC.Name = "txt_S_PV_PC"
        Me.txt_S_PV_PC.Size = New System.Drawing.Size(32, 22)
        Me.txt_S_PV_PC.TabIndex = 56
        Me.txt_S_PV_PC.Visible = False
        '
        'cmd_S_PV_PC
        '
        Me.cmd_S_PV_PC.Location = New System.Drawing.Point(600, 42)
        Me.cmd_S_PV_PC.Name = "cmd_S_PV_PC"
        Me.cmd_S_PV_PC.Size = New System.Drawing.Size(53, 20)
        Me.cmd_S_PV_PC.TabIndex = 55
        Me.cmd_S_PV_PC.Text = ">>"
        Me.cmd_S_PV_PC.UseVisualStyleBackColor = True
        Me.cmd_S_PV_PC.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(547, 46)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 12)
        Me.Label10.TabIndex = 54
        Me.Label10.Text = "Print Co."
        Me.Label10.Visible = False
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(325, 372)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(116, 37)
        Me.cmdShow.TabIndex = 50
        Me.cmdShow.Text = "&Export To Excel"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'txt_S_TONo
        '
        Me.txt_S_TONo.Location = New System.Drawing.Point(197, 236)
        Me.txt_S_TONo.Name = "txt_S_TONo"
        Me.txt_S_TONo.Size = New System.Drawing.Size(499, 22)
        Me.txt_S_TONo.TabIndex = 60
        '
        'cmd_S_TONo
        '
        Me.cmd_S_TONo.Location = New System.Drawing.Point(138, 234)
        Me.cmd_S_TONo.Name = "cmd_S_TONo"
        Me.cmd_S_TONo.Size = New System.Drawing.Size(53, 21)
        Me.cmd_S_TONo.TabIndex = 41
        Me.cmd_S_TONo.Text = ">>"
        Me.cmd_S_TONo.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(20, 238)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(98, 12)
        Me.Label11.TabIndex = 58
        Me.Label11.Text = "Tentative Order No."
        '
        'PBar
        '
        Me.PBar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PBar.Location = New System.Drawing.Point(0, 450)
        Me.PBar.Name = "PBar"
        Me.PBar.Size = New System.Drawing.Size(714, 21)
        Me.PBar.TabIndex = 61
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(20, 277)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 12)
        Me.Label12.TabIndex = 62
        Me.Label12.Text = "Cost Filter criteria"
        '
        'cbscpkgcst
        '
        Me.cbscpkgcst.AutoSize = True
        Me.cbscpkgcst.Enabled = False
        Me.cbscpkgcst.Location = New System.Drawing.Point(159, 276)
        Me.cbscpkgcst.Name = "cbscpkgcst"
        Me.cbscpkgcst.Size = New System.Drawing.Size(131, 16)
        Me.cbscpkgcst.TabIndex = 42
        Me.cbscpkgcst.Text = "SC/TO Packaging Cost"
        Me.cbscpkgcst.UseVisualStyleBackColor = True
        '
        'cbpkgestcst
        '
        Me.cbpkgestcst.AutoSize = True
        Me.cbpkgestcst.Enabled = False
        Me.cbpkgestcst.Location = New System.Drawing.Point(320, 277)
        Me.cbpkgestcst.Name = "cbpkgestcst"
        Me.cbpkgestcst.Size = New System.Drawing.Size(184, 16)
        Me.cbpkgestcst.TabIndex = 43
        Me.cbpkgestcst.Text = "Packaging Request Estimated Cost"
        Me.cbpkgestcst.UseVisualStyleBackColor = True
        '
        'cbpcknetpo
        '
        Me.cbpcknetpo.AutoSize = True
        Me.cbpcknetpo.Enabled = False
        Me.cbpcknetpo.Location = New System.Drawing.Point(546, 277)
        Me.cbpcknetpo.Name = "cbpcknetpo"
        Me.cbpcknetpo.Size = New System.Drawing.Size(126, 16)
        Me.cbpcknetpo.TabIndex = 44
        Me.cbpcknetpo.Text = "Packaging Order Cost"
        Me.cbpcknetpo.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(20, 312)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(94, 12)
        Me.Label13.TabIndex = 69
        Me.Label13.Text = "Order Filter criteria"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbSCTO_TO)
        Me.GroupBox1.Controls.Add(Me.rbSCTO_SC)
        Me.GroupBox1.Controls.Add(Me.rbSCTO_All)
        Me.GroupBox1.Location = New System.Drawing.Point(138, 297)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(558, 38)
        Me.GroupBox1.TabIndex = 70
        Me.GroupBox1.TabStop = False
        '
        'rbSCTO_TO
        '
        Me.rbSCTO_TO.AutoSize = True
        Me.rbSCTO_TO.Enabled = False
        Me.rbSCTO_TO.Location = New System.Drawing.Point(408, 14)
        Me.rbSCTO_TO.Name = "rbSCTO_TO"
        Me.rbSCTO_TO.Size = New System.Drawing.Size(122, 16)
        Me.rbSCTO_TO.TabIndex = 47
        Me.rbSCTO_TO.Text = "Tentative Order Only"
        Me.rbSCTO_TO.UseVisualStyleBackColor = True
        '
        'rbSCTO_SC
        '
        Me.rbSCTO_SC.AutoSize = True
        Me.rbSCTO_SC.Enabled = False
        Me.rbSCTO_SC.Location = New System.Drawing.Point(246, 15)
        Me.rbSCTO_SC.Name = "rbSCTO_SC"
        Me.rbSCTO_SC.Size = New System.Drawing.Size(102, 16)
        Me.rbSCTO_SC.TabIndex = 46
        Me.rbSCTO_SC.Text = "Sales Order Only"
        Me.rbSCTO_SC.UseVisualStyleBackColor = True
        '
        'rbSCTO_All
        '
        Me.rbSCTO_All.AutoSize = True
        Me.rbSCTO_All.Checked = True
        Me.rbSCTO_All.Location = New System.Drawing.Point(21, 15)
        Me.rbSCTO_All.Name = "rbSCTO_All"
        Me.rbSCTO_All.Size = New System.Drawing.Size(172, 16)
        Me.rbSCTO_All.TabIndex = 45
        Me.rbSCTO_All.TabStop = True
        Me.rbSCTO_All.Text = "Sales Order and Tentative Order"
        Me.rbSCTO_All.UseVisualStyleBackColor = True
        '
        'PGM00013
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(714, 471)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.cbpcknetpo)
        Me.Controls.Add(Me.cbpkgestcst)
        Me.Controls.Add(Me.cbscpkgcst)
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
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "PGM00013"
        Me.Text = "PGM00013 - Packaging Order Cost Comparsion Report (PGM13)"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
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
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cbscpkgcst As System.Windows.Forms.CheckBox
    Friend WithEvents cbpkgestcst As System.Windows.Forms.CheckBox
    Friend WithEvents cbpcknetpo As System.Windows.Forms.CheckBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbSCTO_TO As System.Windows.Forms.RadioButton
    Friend WithEvents rbSCTO_SC As System.Windows.Forms.RadioButton
    Friend WithEvents rbSCTO_All As System.Windows.Forms.RadioButton
End Class
