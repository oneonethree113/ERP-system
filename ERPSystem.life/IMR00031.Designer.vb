<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IMR00031
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IMR00031))
        Me.Label1 = New System.Windows.Forms.Label
        Me.optRptCheck = New System.Windows.Forms.RadioButton
        Me.optRptSCSH = New System.Windows.Forms.RadioButton
        Me.optRptSC = New System.Windows.Forms.RadioButton
        Me.Label30 = New System.Windows.Forms.Label
        Me.optPrintAmtN = New System.Windows.Forms.RadioButton
        Me.optPrintAmtY = New System.Windows.Forms.RadioButton
        Me.Label29 = New System.Windows.Forms.Label
        Me.cboSortBy = New System.Windows.Forms.ComboBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.optOSAll = New System.Windows.Forms.RadioButton
        Me.optOSOS = New System.Windows.Forms.RadioButton
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtCusPODatTo = New System.Windows.Forms.MaskedTextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.txtCusPODatFm = New System.Windows.Forms.MaskedTextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtShpDatTo = New System.Windows.Forms.MaskedTextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtShpDatFm = New System.Windows.Forms.MaskedTextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtIssDatTo = New System.Windows.Forms.MaskedTextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtIssDatFm = New System.Windows.Forms.MaskedTextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cndtlSalesTeam = New System.Windows.Forms.Button
        Me.txtSalesTeam = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.cmdtlPV = New System.Windows.Forms.Button
        Me.txtPV = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmdtlDV = New System.Windows.Forms.Button
        Me.txtDV = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmdtlCV = New System.Windows.Forms.Button
        Me.txtCV = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmdtlitmno = New System.Windows.Forms.Button
        Me.txtItmNo = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmdtlSCNo = New System.Windows.Forms.Button
        Me.txtSCNo = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmdtlCusPONo = New System.Windows.Forms.Button
        Me.txtCusPONo = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdtlCus2no = New System.Windows.Forms.Button
        Me.txtCus2no = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdtlCus1no = New System.Windows.Forms.Button
        Me.txtCus1no = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdtlCocde = New System.Windows.Forms.Button
        Me.txtCocde = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdShow = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(690, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Sales Confirmation List to Excel"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'optRptCheck
        '
        Me.optRptCheck.AutoSize = True
        Me.optRptCheck.Location = New System.Drawing.Point(325, 3)
        Me.optRptCheck.Name = "optRptCheck"
        Me.optRptCheck.Size = New System.Drawing.Size(77, 16)
        Me.optRptCheck.TabIndex = 3
        Me.optRptCheck.TabStop = True
        Me.optRptCheck.Text = "Check Data"
        Me.optRptCheck.UseVisualStyleBackColor = True
        '
        'optRptSCSH
        '
        Me.optRptSCSH.AutoSize = True
        Me.optRptSCSH.Location = New System.Drawing.Point(161, 3)
        Me.optRptSCSH.Name = "optRptSCSH"
        Me.optRptSCSH.Size = New System.Drawing.Size(84, 16)
        Me.optRptSCSH.TabIndex = 2
        Me.optRptSCSH.TabStop = True
        Me.optRptSCSH.Text = "SC + Invoice"
        Me.optRptSCSH.UseVisualStyleBackColor = True
        '
        'optRptSC
        '
        Me.optRptSC.AutoSize = True
        Me.optRptSC.Checked = True
        Me.optRptSC.Location = New System.Drawing.Point(3, 3)
        Me.optRptSC.Name = "optRptSC"
        Me.optRptSC.Size = New System.Drawing.Size(37, 16)
        Me.optRptSC.TabIndex = 1
        Me.optRptSC.TabStop = True
        Me.optRptSC.Text = "SC"
        Me.optRptSC.UseVisualStyleBackColor = True
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(27, 394)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(64, 12)
        Me.Label30.TabIndex = 0
        Me.Label30.Text = "Report Type"
        '
        'optPrintAmtN
        '
        Me.optPrintAmtN.AutoSize = True
        Me.optPrintAmtN.Location = New System.Drawing.Point(161, 3)
        Me.optPrintAmtN.Name = "optPrintAmtN"
        Me.optPrintAmtN.Size = New System.Drawing.Size(37, 16)
        Me.optPrintAmtN.TabIndex = 2
        Me.optPrintAmtN.TabStop = True
        Me.optPrintAmtN.Text = "No"
        Me.optPrintAmtN.UseVisualStyleBackColor = True
        '
        'optPrintAmtY
        '
        Me.optPrintAmtY.AutoSize = True
        Me.optPrintAmtY.Checked = True
        Me.optPrintAmtY.Location = New System.Drawing.Point(3, 3)
        Me.optPrintAmtY.Name = "optPrintAmtY"
        Me.optPrintAmtY.Size = New System.Drawing.Size(40, 16)
        Me.optPrintAmtY.TabIndex = 1
        Me.optPrintAmtY.TabStop = True
        Me.optPrintAmtY.Text = "Yes"
        Me.optPrintAmtY.UseVisualStyleBackColor = True
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(27, 374)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(69, 12)
        Me.Label29.TabIndex = 0
        Me.Label29.Text = "Price Amount"
        '
        'cboSortBy
        '
        Me.cboSortBy.FormattingEnabled = True
        Me.cboSortBy.Location = New System.Drawing.Point(470, 350)
        Me.cboSortBy.Name = "cboSortBy"
        Me.cboSortBy.Size = New System.Drawing.Size(196, 20)
        Me.cboSortBy.TabIndex = 51
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(416, 353)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(41, 12)
        Me.Label28.TabIndex = 52
        Me.Label28.Text = "Sort By"
        '
        'optOSAll
        '
        Me.optOSAll.AutoSize = True
        Me.optOSAll.Checked = True
        Me.optOSAll.Location = New System.Drawing.Point(161, 3)
        Me.optOSAll.Name = "optOSAll"
        Me.optOSAll.Size = New System.Drawing.Size(37, 16)
        Me.optOSAll.TabIndex = 2
        Me.optOSAll.TabStop = True
        Me.optOSAll.Text = "All"
        Me.optOSAll.UseVisualStyleBackColor = True
        '
        'optOSOS
        '
        Me.optOSOS.AutoSize = True
        Me.optOSOS.Location = New System.Drawing.Point(3, 3)
        Me.optOSOS.Name = "optOSOS"
        Me.optOSOS.Size = New System.Drawing.Size(79, 16)
        Me.optOSOS.TabIndex = 1
        Me.optOSOS.TabStop = True
        Me.optOSOS.Text = "Outstanding"
        Me.optOSOS.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(29, 353)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(46, 12)
        Me.Label27.TabIndex = 0
        Me.Label27.Text = "SC Type"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(544, 329)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(87, 12)
        Me.Label22.TabIndex = 50
        Me.Label22.Text = "(MM/DD/YYYY)"
        '
        'txtCusPODatTo
        '
        Me.txtCusPODatTo.Location = New System.Drawing.Point(470, 326)
        Me.txtCusPODatTo.Mask = "00/00/0000"
        Me.txtCusPODatTo.Name = "txtCusPODatTo"
        Me.txtCusPODatTo.Size = New System.Drawing.Size(72, 22)
        Me.txtCusPODatTo.TabIndex = 49
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(416, 329)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(18, 12)
        Me.Label23.TabIndex = 48
        Me.Label23.Text = "To"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(302, 329)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(87, 12)
        Me.Label24.TabIndex = 47
        Me.Label24.Text = "(MM/DD/YYYY)"
        '
        'txtCusPODatFm
        '
        Me.txtCusPODatFm.Location = New System.Drawing.Point(224, 326)
        Me.txtCusPODatFm.Mask = "00/00/0000"
        Me.txtCusPODatFm.Name = "txtCusPODatFm"
        Me.txtCusPODatFm.Size = New System.Drawing.Size(72, 22)
        Me.txtCusPODatFm.TabIndex = 46
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(146, 329)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(30, 12)
        Me.Label25.TabIndex = 45
        Me.Label25.Text = "From"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(27, 330)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(67, 12)
        Me.Label26.TabIndex = 44
        Me.Label26.Text = "Cust PO Date"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(544, 305)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(87, 12)
        Me.Label17.TabIndex = 43
        Me.Label17.Text = "(MM/DD/YYYY)"
        '
        'txtShpDatTo
        '
        Me.txtShpDatTo.Location = New System.Drawing.Point(470, 302)
        Me.txtShpDatTo.Mask = "00/00/0000"
        Me.txtShpDatTo.Name = "txtShpDatTo"
        Me.txtShpDatTo.Size = New System.Drawing.Size(72, 22)
        Me.txtShpDatTo.TabIndex = 42
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(416, 305)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(18, 12)
        Me.Label18.TabIndex = 41
        Me.Label18.Text = "To"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(302, 305)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(87, 12)
        Me.Label19.TabIndex = 40
        Me.Label19.Text = "(MM/DD/YYYY)"
        '
        'txtShpDatFm
        '
        Me.txtShpDatFm.Location = New System.Drawing.Point(224, 302)
        Me.txtShpDatFm.Mask = "00/00/0000"
        Me.txtShpDatFm.Name = "txtShpDatFm"
        Me.txtShpDatFm.Size = New System.Drawing.Size(72, 22)
        Me.txtShpDatFm.TabIndex = 39
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(146, 305)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(30, 12)
        Me.Label20.TabIndex = 38
        Me.Label20.Text = "From"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(27, 306)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(67, 12)
        Me.Label21.TabIndex = 37
        Me.Label21.Text = "SC Ship Date"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(544, 281)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(87, 12)
        Me.Label15.TabIndex = 36
        Me.Label15.Text = "(MM/DD/YYYY)"
        '
        'txtIssDatTo
        '
        Me.txtIssDatTo.Location = New System.Drawing.Point(470, 278)
        Me.txtIssDatTo.Mask = "00/00/0000"
        Me.txtIssDatTo.Name = "txtIssDatTo"
        Me.txtIssDatTo.Size = New System.Drawing.Size(72, 22)
        Me.txtIssDatTo.TabIndex = 35
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(416, 281)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(18, 12)
        Me.Label16.TabIndex = 34
        Me.Label16.Text = "To"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(302, 281)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(87, 12)
        Me.Label14.TabIndex = 33
        Me.Label14.Text = "(MM/DD/YYYY)"
        '
        'txtIssDatFm
        '
        Me.txtIssDatFm.Location = New System.Drawing.Point(224, 278)
        Me.txtIssDatFm.Mask = "00/00/0000"
        Me.txtIssDatFm.Name = "txtIssDatFm"
        Me.txtIssDatFm.Size = New System.Drawing.Size(72, 22)
        Me.txtIssDatFm.TabIndex = 32
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(146, 281)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(30, 12)
        Me.Label13.TabIndex = 31
        Me.Label13.Text = "From"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(27, 282)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(69, 12)
        Me.Label12.TabIndex = 30
        Me.Label12.Text = "SC Issue Date"
        '
        'cndtlSalesTeam
        '
        Me.cndtlSalesTeam.Location = New System.Drawing.Point(148, 253)
        Me.cndtlSalesTeam.Name = "cndtlSalesTeam"
        Me.cndtlSalesTeam.Size = New System.Drawing.Size(42, 20)
        Me.cndtlSalesTeam.TabIndex = 29
        Me.cndtlSalesTeam.Text = "->"
        Me.cndtlSalesTeam.UseVisualStyleBackColor = True
        '
        'txtSalesTeam
        '
        Me.txtSalesTeam.BackColor = System.Drawing.Color.White
        Me.txtSalesTeam.ForeColor = System.Drawing.Color.Black
        Me.txtSalesTeam.Location = New System.Drawing.Point(224, 254)
        Me.txtSalesTeam.Name = "txtSalesTeam"
        Me.txtSalesTeam.Size = New System.Drawing.Size(442, 22)
        Me.txtSalesTeam.TabIndex = 28
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(29, 257)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(57, 12)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "Sales Team"
        '
        'cmdtlPV
        '
        Me.cmdtlPV.Location = New System.Drawing.Point(148, 228)
        Me.cmdtlPV.Name = "cmdtlPV"
        Me.cmdtlPV.Size = New System.Drawing.Size(42, 20)
        Me.cmdtlPV.TabIndex = 26
        Me.cmdtlPV.Text = "->"
        Me.cmdtlPV.UseVisualStyleBackColor = True
        '
        'txtPV
        '
        Me.txtPV.BackColor = System.Drawing.Color.White
        Me.txtPV.ForeColor = System.Drawing.Color.Black
        Me.txtPV.Location = New System.Drawing.Point(224, 229)
        Me.txtPV.Name = "txtPV"
        Me.txtPV.Size = New System.Drawing.Size(442, 22)
        Me.txtPV.TabIndex = 25
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(29, 232)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(94, 12)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "Production Vendor"
        '
        'cmdtlDV
        '
        Me.cmdtlDV.Location = New System.Drawing.Point(148, 204)
        Me.cmdtlDV.Name = "cmdtlDV"
        Me.cmdtlDV.Size = New System.Drawing.Size(42, 20)
        Me.cmdtlDV.TabIndex = 23
        Me.cmdtlDV.Text = "->"
        Me.cmdtlDV.UseVisualStyleBackColor = True
        '
        'txtDV
        '
        Me.txtDV.BackColor = System.Drawing.Color.White
        Me.txtDV.ForeColor = System.Drawing.Color.Black
        Me.txtDV.Location = New System.Drawing.Point(224, 205)
        Me.txtDV.Name = "txtDV"
        Me.txtDV.Size = New System.Drawing.Size(442, 22)
        Me.txtDV.TabIndex = 22
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(29, 210)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 12)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Design Vendor"
        '
        'cmdtlCV
        '
        Me.cmdtlCV.Location = New System.Drawing.Point(148, 180)
        Me.cmdtlCV.Name = "cmdtlCV"
        Me.cmdtlCV.Size = New System.Drawing.Size(42, 20)
        Me.cmdtlCV.TabIndex = 20
        Me.cmdtlCV.Text = "->"
        Me.cmdtlCV.UseVisualStyleBackColor = True
        '
        'txtCV
        '
        Me.txtCV.BackColor = System.Drawing.Color.White
        Me.txtCV.ForeColor = System.Drawing.Color.Black
        Me.txtCV.Location = New System.Drawing.Point(224, 181)
        Me.txtCV.Name = "txtCV"
        Me.txtCV.Size = New System.Drawing.Size(442, 22)
        Me.txtCV.TabIndex = 19
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(29, 184)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 12)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Custom Vendor"
        '
        'cmdtlitmno
        '
        Me.cmdtlitmno.Location = New System.Drawing.Point(148, 156)
        Me.cmdtlitmno.Name = "cmdtlitmno"
        Me.cmdtlitmno.Size = New System.Drawing.Size(42, 20)
        Me.cmdtlitmno.TabIndex = 17
        Me.cmdtlitmno.Text = "->"
        Me.cmdtlitmno.UseVisualStyleBackColor = True
        '
        'txtItmNo
        '
        Me.txtItmNo.BackColor = System.Drawing.Color.White
        Me.txtItmNo.ForeColor = System.Drawing.Color.Black
        Me.txtItmNo.Location = New System.Drawing.Point(224, 157)
        Me.txtItmNo.Name = "txtItmNo"
        Me.txtItmNo.Size = New System.Drawing.Size(442, 22)
        Me.txtItmNo.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(29, 160)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 12)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Item No"
        '
        'cmdtlSCNo
        '
        Me.cmdtlSCNo.Location = New System.Drawing.Point(148, 132)
        Me.cmdtlSCNo.Name = "cmdtlSCNo"
        Me.cmdtlSCNo.Size = New System.Drawing.Size(42, 20)
        Me.cmdtlSCNo.TabIndex = 14
        Me.cmdtlSCNo.Text = "->"
        Me.cmdtlSCNo.UseVisualStyleBackColor = True
        '
        'txtSCNo
        '
        Me.txtSCNo.BackColor = System.Drawing.Color.White
        Me.txtSCNo.ForeColor = System.Drawing.Color.Black
        Me.txtSCNo.Location = New System.Drawing.Point(224, 133)
        Me.txtSCNo.Name = "txtSCNo"
        Me.txtSCNo.Size = New System.Drawing.Size(442, 22)
        Me.txtSCNo.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(29, 138)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 12)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "SC No"
        '
        'cmdtlCusPONo
        '
        Me.cmdtlCusPONo.Location = New System.Drawing.Point(148, 108)
        Me.cmdtlCusPONo.Name = "cmdtlCusPONo"
        Me.cmdtlCusPONo.Size = New System.Drawing.Size(42, 20)
        Me.cmdtlCusPONo.TabIndex = 11
        Me.cmdtlCusPONo.Text = "->"
        Me.cmdtlCusPONo.UseVisualStyleBackColor = True
        '
        'txtCusPONo
        '
        Me.txtCusPONo.BackColor = System.Drawing.Color.White
        Me.txtCusPONo.ForeColor = System.Drawing.Color.Black
        Me.txtCusPONo.Location = New System.Drawing.Point(224, 109)
        Me.txtCusPONo.Name = "txtCusPONo"
        Me.txtCusPONo.Size = New System.Drawing.Size(442, 22)
        Me.txtCusPONo.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(29, 112)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 12)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Cust. PO No"
        '
        'cmdtlCus2no
        '
        Me.cmdtlCus2no.Location = New System.Drawing.Point(148, 84)
        Me.cmdtlCus2no.Name = "cmdtlCus2no"
        Me.cmdtlCus2no.Size = New System.Drawing.Size(42, 20)
        Me.cmdtlCus2no.TabIndex = 8
        Me.cmdtlCus2no.Text = "->"
        Me.cmdtlCus2no.UseVisualStyleBackColor = True
        '
        'txtCus2no
        '
        Me.txtCus2no.BackColor = System.Drawing.Color.White
        Me.txtCus2no.ForeColor = System.Drawing.Color.Black
        Me.txtCus2no.Location = New System.Drawing.Point(224, 85)
        Me.txtCus2no.Name = "txtCus2no"
        Me.txtCus2no.Size = New System.Drawing.Size(442, 22)
        Me.txtCus2no.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(29, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 12)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Sec. Customer"
        '
        'cmdtlCus1no
        '
        Me.cmdtlCus1no.Location = New System.Drawing.Point(148, 60)
        Me.cmdtlCus1no.Name = "cmdtlCus1no"
        Me.cmdtlCus1no.Size = New System.Drawing.Size(42, 20)
        Me.cmdtlCus1no.TabIndex = 5
        Me.cmdtlCus1no.Text = "->"
        Me.cmdtlCus1no.UseVisualStyleBackColor = True
        '
        'txtCus1no
        '
        Me.txtCus1no.BackColor = System.Drawing.Color.White
        Me.txtCus1no.ForeColor = System.Drawing.Color.Black
        Me.txtCus1no.Location = New System.Drawing.Point(224, 61)
        Me.txtCus1no.Name = "txtCus1no"
        Me.txtCus1no.Size = New System.Drawing.Size(442, 22)
        Me.txtCus1no.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(29, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 12)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Pri. Customer"
        '
        'cmdtlCocde
        '
        Me.cmdtlCocde.Location = New System.Drawing.Point(148, 36)
        Me.cmdtlCocde.Name = "cmdtlCocde"
        Me.cmdtlCocde.Size = New System.Drawing.Size(42, 20)
        Me.cmdtlCocde.TabIndex = 2
        Me.cmdtlCocde.Text = "->"
        Me.cmdtlCocde.UseVisualStyleBackColor = True
        '
        'txtCocde
        '
        Me.txtCocde.BackColor = System.Drawing.Color.White
        Me.txtCocde.ForeColor = System.Drawing.Color.Black
        Me.txtCocde.Location = New System.Drawing.Point(224, 37)
        Me.txtCocde.Name = "txtCocde"
        Me.txtCocde.Size = New System.Drawing.Size(442, 22)
        Me.txtCocde.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 12)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Company Code"
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(299, 414)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(116, 40)
        Me.cmdShow.TabIndex = 54
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.optOSOS)
        Me.Panel1.Controls.Add(Me.optOSAll)
        Me.Panel1.Location = New System.Drawing.Point(145, 349)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(244, 21)
        Me.Panel1.TabIndex = 50
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.optPrintAmtY)
        Me.Panel2.Controls.Add(Me.optPrintAmtN)
        Me.Panel2.Location = New System.Drawing.Point(145, 370)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(245, 21)
        Me.Panel2.TabIndex = 52
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.optRptSC)
        Me.Panel3.Controls.Add(Me.optRptSCSH)
        Me.Panel3.Controls.Add(Me.optRptCheck)
        Me.Panel3.Location = New System.Drawing.Point(145, 391)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(521, 21)
        Me.Panel3.TabIndex = 53
        '
        'IMR00031
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(714, 472)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.cboSortBy)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.cmdtlCocde)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.txtCocde)
        Me.Controls.Add(Me.txtCusPODatTo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.txtCus1no)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.cmdtlCus1no)
        Me.Controls.Add(Me.txtCusPODatFm)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.txtCus2no)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.cmdtlCus2no)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtShpDatTo)
        Me.Controls.Add(Me.txtCusPONo)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.cmdtlCusPONo)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtShpDatFm)
        Me.Controls.Add(Me.txtSCNo)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.cmdtlSCNo)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtItmNo)
        Me.Controls.Add(Me.txtIssDatTo)
        Me.Controls.Add(Me.cmdtlitmno)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtCV)
        Me.Controls.Add(Me.txtIssDatFm)
        Me.Controls.Add(Me.cmdtlCV)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtDV)
        Me.Controls.Add(Me.cndtlSalesTeam)
        Me.Controls.Add(Me.cmdtlDV)
        Me.Controls.Add(Me.txtSalesTeam)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtPV)
        Me.Controls.Add(Me.cmdtlPV)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "IMR00031"
        Me.Text = "IMR00031 - Sales Confirmation List to Excel (IMR31)"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cndtlSalesTeam As System.Windows.Forms.Button
    Friend WithEvents txtSalesTeam As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmdtlPV As System.Windows.Forms.Button
    Friend WithEvents txtPV As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmdtlDV As System.Windows.Forms.Button
    Friend WithEvents txtDV As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmdtlCV As System.Windows.Forms.Button
    Friend WithEvents txtCV As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmdtlitmno As System.Windows.Forms.Button
    Friend WithEvents txtItmNo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmdtlSCNo As System.Windows.Forms.Button
    Friend WithEvents txtSCNo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdtlCusPONo As System.Windows.Forms.Button
    Friend WithEvents txtCusPONo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdtlCus2no As System.Windows.Forms.Button
    Friend WithEvents txtCus2no As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdtlCus1no As System.Windows.Forms.Button
    Friend WithEvents txtCus1no As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdtlCocde As System.Windows.Forms.Button
    Friend WithEvents txtCocde As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtIssDatTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtIssDatFm As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtCusPODatTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtCusPODatFm As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtShpDatTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtShpDatFm As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents optRptSCSH As System.Windows.Forms.RadioButton
    Friend WithEvents optRptSC As System.Windows.Forms.RadioButton
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents optPrintAmtN As System.Windows.Forms.RadioButton
    Friend WithEvents optPrintAmtY As System.Windows.Forms.RadioButton
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents cboSortBy As System.Windows.Forms.ComboBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents optOSAll As System.Windows.Forms.RadioButton
    Friend WithEvents optOSOS As System.Windows.Forms.RadioButton
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents optRptCheck As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
End Class
