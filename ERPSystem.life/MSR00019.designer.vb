<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MSR00019
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.grpSearch = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.OptShpDat = New System.Windows.Forms.RadioButton
        Me.Label15 = New System.Windows.Forms.Label
        Me.OptSC = New System.Windows.Forms.RadioButton
        Me.OptCust = New System.Windows.Forms.RadioButton
        Me.Label27 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.optPrintAmtY = New System.Windows.Forms.RadioButton
        Me.optPrintAmtN = New System.Windows.Forms.RadioButton
        Me.Label26 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.OptPayN = New System.Windows.Forms.RadioButton
        Me.OptPayY = New System.Windows.Forms.RadioButton
        Me.DtShpEnd = New System.Windows.Forms.MaskedTextBox
        Me.DtShpStr = New System.Windows.Forms.MaskedTextBox
        Me.txtDateTo = New System.Windows.Forms.MaskedTextBox
        Me.txtDateFrom = New System.Windows.Forms.MaskedTextBox
        Me.cboReportType = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtSCTo = New System.Windows.Forms.TextBox
        Me.txtSCFm = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.cboCustNo2To = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.cboCustNo2Fm = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.cboScStatus = New System.Windows.Forms.ComboBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.cboCustNoTo = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboCustNoFm = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdShow = New System.Windows.Forms.Button
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.grpSearch.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(49, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Company Code"
        '
        'cboCoCde
        '
        Me.cboCoCde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(134, 60)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(76, 21)
        Me.cboCoCde.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(227, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Company Name"
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.Location = New System.Drawing.Point(315, 60)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.Size = New System.Drawing.Size(350, 20)
        Me.txtCoNam.TabIndex = 2
        '
        'grpSearch
        '
        Me.grpSearch.Controls.Add(Me.GroupBox2)
        Me.grpSearch.Controls.Add(Me.Label27)
        Me.grpSearch.Controls.Add(Me.GroupBox3)
        Me.grpSearch.Controls.Add(Me.Label26)
        Me.grpSearch.Controls.Add(Me.GroupBox1)
        Me.grpSearch.Controls.Add(Me.DtShpEnd)
        Me.grpSearch.Controls.Add(Me.DtShpStr)
        Me.grpSearch.Controls.Add(Me.txtDateTo)
        Me.grpSearch.Controls.Add(Me.txtDateFrom)
        Me.grpSearch.Controls.Add(Me.cboReportType)
        Me.grpSearch.Controls.Add(Me.Label11)
        Me.grpSearch.Controls.Add(Me.Label6)
        Me.grpSearch.Controls.Add(Me.Label7)
        Me.grpSearch.Controls.Add(Me.Label8)
        Me.grpSearch.Controls.Add(Me.txtSCTo)
        Me.grpSearch.Controls.Add(Me.txtSCFm)
        Me.grpSearch.Controls.Add(Me.Label23)
        Me.grpSearch.Controls.Add(Me.Label24)
        Me.grpSearch.Controls.Add(Me.Label25)
        Me.grpSearch.Controls.Add(Me.cboCustNo2To)
        Me.grpSearch.Controls.Add(Me.Label12)
        Me.grpSearch.Controls.Add(Me.cboCustNo2Fm)
        Me.grpSearch.Controls.Add(Me.Label13)
        Me.grpSearch.Controls.Add(Me.Label14)
        Me.grpSearch.Controls.Add(Me.cboScStatus)
        Me.grpSearch.Controls.Add(Me.Label22)
        Me.grpSearch.Controls.Add(Me.Label21)
        Me.grpSearch.Controls.Add(Me.Label19)
        Me.grpSearch.Controls.Add(Me.Label20)
        Me.grpSearch.Controls.Add(Me.cboCustNoTo)
        Me.grpSearch.Controls.Add(Me.Label3)
        Me.grpSearch.Controls.Add(Me.cboCustNoFm)
        Me.grpSearch.Controls.Add(Me.Label4)
        Me.grpSearch.Controls.Add(Me.Label5)
        Me.grpSearch.Location = New System.Drawing.Point(42, 92)
        Me.grpSearch.Name = "grpSearch"
        Me.grpSearch.Size = New System.Drawing.Size(678, 313)
        Me.grpSearch.TabIndex = 4
        Me.grpSearch.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.OptShpDat)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.OptSC)
        Me.GroupBox2.Controls.Add(Me.OptCust)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 221)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(304, 43)
        Me.GroupBox2.TabIndex = 28
        Me.GroupBox2.TabStop = False
        '
        'OptShpDat
        '
        Me.OptShpDat.AutoSize = True
        Me.OptShpDat.Location = New System.Drawing.Point(221, 15)
        Me.OptShpDat.Name = "OptShpDat"
        Me.OptShpDat.Size = New System.Drawing.Size(72, 17)
        Me.OptShpDat.TabIndex = 19
        Me.OptShpDat.Text = "Ship Date"
        Me.OptShpDat.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(10, 15)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(44, 13)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "Sort By:"
        '
        'OptSC
        '
        Me.OptSC.AutoSize = True
        Me.OptSC.Checked = True
        Me.OptSC.Location = New System.Drawing.Point(81, 15)
        Me.OptSC.Name = "OptSC"
        Me.OptSC.Size = New System.Drawing.Size(59, 17)
        Me.OptSC.TabIndex = 17
        Me.OptSC.TabStop = True
        Me.OptSC.Text = "SC No."
        Me.OptSC.UseVisualStyleBackColor = True
        '
        'OptCust
        '
        Me.OptCust.AutoSize = True
        Me.OptCust.Location = New System.Drawing.Point(146, 15)
        Me.OptCust.Name = "OptCust"
        Me.OptCust.Size = New System.Drawing.Size(69, 17)
        Me.OptCust.TabIndex = 18
        Me.OptCust.Text = "Customer"
        Me.OptCust.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(433, 160)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(23, 13)
        Me.Label27.TabIndex = 478
        Me.Label27.Text = "To:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.optPrintAmtY)
        Me.GroupBox3.Controls.Add(Me.optPrintAmtN)
        Me.GroupBox3.Location = New System.Drawing.Point(421, 175)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(234, 40)
        Me.GroupBox3.TabIndex = 27
        Me.GroupBox3.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(24, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 13)
        Me.Label10.TabIndex = 472
        Me.Label10.Text = "Print Amount"
        '
        'optPrintAmtY
        '
        Me.optPrintAmtY.AutoSize = True
        Me.optPrintAmtY.Checked = True
        Me.optPrintAmtY.Location = New System.Drawing.Point(119, 14)
        Me.optPrintAmtY.Name = "optPrintAmtY"
        Me.optPrintAmtY.Size = New System.Drawing.Size(43, 17)
        Me.optPrintAmtY.TabIndex = 15
        Me.optPrintAmtY.TabStop = True
        Me.optPrintAmtY.Text = "Yes"
        Me.optPrintAmtY.UseVisualStyleBackColor = True
        '
        'optPrintAmtN
        '
        Me.optPrintAmtN.AutoSize = True
        Me.optPrintAmtN.Location = New System.Drawing.Point(187, 16)
        Me.optPrintAmtN.Name = "optPrintAmtN"
        Me.optPrintAmtN.Size = New System.Drawing.Size(39, 17)
        Me.optPrintAmtN.TabIndex = 16
        Me.optPrintAmtN.Text = "No"
        Me.optPrintAmtN.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(433, 129)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(23, 13)
        Me.Label26.TabIndex = 477
        Me.Label26.Text = "To:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.OptPayN)
        Me.GroupBox1.Controls.Add(Me.OptPayY)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 175)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(305, 40)
        Me.GroupBox1.TabIndex = 26
        Me.GroupBox1.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(134, 13)
        Me.Label9.TabIndex = 469
        Me.Label9.Text = "Payment Term / Ship Mark"
        '
        'OptPayN
        '
        Me.OptPayN.AutoSize = True
        Me.OptPayN.Checked = True
        Me.OptPayN.Location = New System.Drawing.Point(241, 12)
        Me.OptPayN.Name = "OptPayN"
        Me.OptPayN.Size = New System.Drawing.Size(39, 17)
        Me.OptPayN.TabIndex = 14
        Me.OptPayN.TabStop = True
        Me.OptPayN.Text = "No"
        Me.OptPayN.UseVisualStyleBackColor = True
        '
        'OptPayY
        '
        Me.OptPayY.AutoSize = True
        Me.OptPayY.Location = New System.Drawing.Point(172, 12)
        Me.OptPayY.Name = "OptPayY"
        Me.OptPayY.Size = New System.Drawing.Size(43, 17)
        Me.OptPayY.TabIndex = 13
        Me.OptPayY.Text = "Yes"
        Me.OptPayY.UseVisualStyleBackColor = True
        '
        'DtShpEnd
        '
        Me.DtShpEnd.Location = New System.Drawing.Point(462, 157)
        Me.DtShpEnd.Mask = "##/##/####"
        Me.DtShpEnd.Name = "DtShpEnd"
        Me.DtShpEnd.Size = New System.Drawing.Size(187, 20)
        Me.DtShpEnd.TabIndex = 12
        '
        'DtShpStr
        '
        Me.DtShpStr.Location = New System.Drawing.Point(203, 154)
        Me.DtShpStr.Mask = "##/##/####"
        Me.DtShpStr.Name = "DtShpStr"
        Me.DtShpStr.Size = New System.Drawing.Size(187, 20)
        Me.DtShpStr.TabIndex = 11
        '
        'txtDateTo
        '
        Me.txtDateTo.Location = New System.Drawing.Point(462, 122)
        Me.txtDateTo.Mask = "##/##/####"
        Me.txtDateTo.Name = "txtDateTo"
        Me.txtDateTo.Size = New System.Drawing.Size(187, 20)
        Me.txtDateTo.TabIndex = 10
        '
        'txtDateFrom
        '
        Me.txtDateFrom.Location = New System.Drawing.Point(203, 123)
        Me.txtDateFrom.Mask = "##/##/####"
        Me.txtDateFrom.Name = "txtDateFrom"
        Me.txtDateFrom.Size = New System.Drawing.Size(187, 20)
        Me.txtDateFrom.TabIndex = 9
        '
        'cboReportType
        '
        Me.cboReportType.FormattingEnabled = True
        Me.cboReportType.Location = New System.Drawing.Point(124, 279)
        Me.cboReportType.Name = "cboReportType"
        Me.cboReportType.Size = New System.Drawing.Size(187, 21)
        Me.cboReportType.TabIndex = 21
        Me.cboReportType.Text = "Cystal Report Format"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(11, 282)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 13)
        Me.Label11.TabIndex = 476
        Me.Label11.Text = "Report Type"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 154)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(130, 13)
        Me.Label6.TabIndex = 468
        Me.Label6.Text = "Ship Date    (mm/dd/yyyy)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(366, 161)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(20, 13)
        Me.Label7.TabIndex = 467
        Me.Label7.Text = "To"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(157, 157)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(33, 13)
        Me.Label8.TabIndex = 466
        Me.Label8.Text = "From:"
        '
        'txtSCTo
        '
        Me.txtSCTo.Location = New System.Drawing.Point(462, 93)
        Me.txtSCTo.MaxLength = 20
        Me.txtSCTo.Name = "txtSCTo"
        Me.txtSCTo.Size = New System.Drawing.Size(187, 20)
        Me.txtSCTo.TabIndex = 8
        '
        'txtSCFm
        '
        Me.txtSCFm.Location = New System.Drawing.Point(203, 93)
        Me.txtSCFm.MaxLength = 20
        Me.txtSCFm.Name = "txtSCFm"
        Me.txtSCFm.Size = New System.Drawing.Size(187, 20)
        Me.txtSCFm.TabIndex = 7
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(433, 98)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(23, 13)
        Me.Label23.TabIndex = 462
        Me.Label23.Text = "To:"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(157, 91)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(33, 13)
        Me.Label24.TabIndex = 460
        Me.Label24.Text = "From:"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(11, 94)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(46, 13)
        Me.Label25.TabIndex = 459
        Me.Label25.Text = "S/C No."
        '
        'cboCustNo2To
        '
        Me.cboCustNo2To.FormattingEnabled = True
        Me.cboCustNo2To.Location = New System.Drawing.Point(462, 60)
        Me.cboCustNo2To.Name = "cboCustNo2To"
        Me.cboCustNo2To.Size = New System.Drawing.Size(187, 21)
        Me.cboCustNo2To.TabIndex = 6
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(433, 64)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(23, 13)
        Me.Label12.TabIndex = 457
        Me.Label12.Text = "To:"
        '
        'cboCustNo2Fm
        '
        Me.cboCustNo2Fm.FormattingEnabled = True
        Me.cboCustNo2Fm.Location = New System.Drawing.Point(203, 60)
        Me.cboCustNo2Fm.Name = "cboCustNo2Fm"
        Me.cboCustNo2Fm.Size = New System.Drawing.Size(187, 21)
        Me.cboCustNo2Fm.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(157, 61)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(33, 13)
        Me.Label13.TabIndex = 455
        Me.Label13.Text = "From:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(11, 64)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(93, 13)
        Me.Label14.TabIndex = 454
        Me.Label14.Text = "Sec Customer No."
        '
        'cboScStatus
        '
        Me.cboScStatus.FormattingEnabled = True
        Me.cboScStatus.Location = New System.Drawing.Point(462, 222)
        Me.cboScStatus.Name = "cboScStatus"
        Me.cboScStatus.Size = New System.Drawing.Size(183, 21)
        Me.cboScStatus.TabIndex = 20
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(384, 225)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(65, 13)
        Me.Label22.TabIndex = 452
        Me.Label22.Text = "S/C Status :"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(11, 119)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(128, 13)
        Me.Label21.TabIndex = 451
        Me.Label21.Text = "Issue Date  (mm/dd/yyyy)"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(366, 126)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(20, 13)
        Me.Label19.TabIndex = 450
        Me.Label19.Text = "To"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(157, 123)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(33, 13)
        Me.Label20.TabIndex = 449
        Me.Label20.Text = "From:"
        '
        'cboCustNoTo
        '
        Me.cboCustNoTo.FormattingEnabled = True
        Me.cboCustNoTo.Location = New System.Drawing.Point(462, 27)
        Me.cboCustNoTo.Name = "cboCustNoTo"
        Me.cboCustNoTo.Size = New System.Drawing.Size(187, 21)
        Me.cboCustNoTo.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(433, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "To:"
        '
        'cboCustNoFm
        '
        Me.cboCustNoFm.FormattingEnabled = True
        Me.cboCustNoFm.Location = New System.Drawing.Point(203, 27)
        Me.cboCustNoFm.Name = "cboCustNoFm"
        Me.cboCustNoFm.Size = New System.Drawing.Size(187, 21)
        Me.cboCustNoFm.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(157, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "From:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Pri Customer No."
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(311, 422)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(117, 27)
        Me.cmdShow.TabIndex = 22
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label16.Location = New System.Drawing.Point(240, 3)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(251, 25)
        Me.Label16.TabIndex = 23
        Me.Label16.Text = "Sales Confirmation Index"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label17.Location = New System.Drawing.Point(39, 18)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(61, 13)
        Me.Label17.TabIndex = 24
        Me.Label17.Text = "MSR00019"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label18.Location = New System.Drawing.Point(-9, 29)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(913, 13)
        Me.Label18.TabIndex = 25
        Me.Label18.Text = "_________________________________________________________________________________" & _
            "______________________________________________________________________"
        '
        'MSR00019
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(739, 468)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.grpSearch)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.Label1)
        Me.Name = "MSR00019"
        Me.Text = "MSR00019 - Sales Confirmation Index"
        Me.grpSearch.ResumeLayout(False)
        Me.grpSearch.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents grpSearch As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents OptSC As System.Windows.Forms.RadioButton
    Friend WithEvents OptCust As System.Windows.Forms.RadioButton
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents cboCustNoTo As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboCustNoFm As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cboScStatus As System.Windows.Forms.ComboBox
    Friend WithEvents cboCustNo2To As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboCustNo2Fm As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtSCTo As System.Windows.Forms.TextBox
    Friend WithEvents txtSCFm As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents OptPayN As System.Windows.Forms.RadioButton
    Friend WithEvents OptPayY As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents optPrintAmtN As System.Windows.Forms.RadioButton
    Friend WithEvents optPrintAmtY As System.Windows.Forms.RadioButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents OptShpDat As System.Windows.Forms.RadioButton
    Friend WithEvents cboReportType As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents DtShpEnd As System.Windows.Forms.MaskedTextBox
    Friend WithEvents DtShpStr As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDateTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDateFrom As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
End Class
