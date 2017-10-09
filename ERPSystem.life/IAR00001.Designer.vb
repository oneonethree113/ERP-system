<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IAR00001
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtItmNo = New System.Windows.Forms.TextBox
        Me.txt_S_DV = New System.Windows.Forms.TextBox
        Me.cmd_S_DV = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.txt_S_SecCustAll = New System.Windows.Forms.TextBox
        Me.cmd_S_SecCustAll = New System.Windows.Forms.Button
        Me.txt_S_PriCustAll = New System.Windows.Forms.TextBox
        Me.cmd_S_PriCustAll = New System.Windows.Forms.Button
        Me.SLabel_2 = New System.Windows.Forms.Label
        Me.SLabel_1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmd_S_ItmNo = New System.Windows.Forms.Button
        Me.lblTranDateTo = New System.Windows.Forms.Label
        Me.txtTranToDate = New System.Windows.Forms.MaskedTextBox
        Me.txtTranFromDate = New System.Windows.Forms.MaskedTextBox
        Me.lblSearchParam = New System.Windows.Forms.Label
        Me.optBOMItm = New System.Windows.Forms.RadioButton
        Me.optItmMtr = New System.Windows.Forms.RadioButton
        Me.optByExcel_New = New System.Windows.Forms.RadioButton
        Me.optByExcel = New System.Windows.Forms.RadioButton
        Me.chkAssort = New System.Windows.Forms.CheckBox
        Me.chkExcel = New System.Windows.Forms.CheckBox
        Me.cmdShowReport = New System.Windows.Forms.Button
        Me.btnExExcel = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(173, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(211, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Impact Analysis Report"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtItmNo)
        Me.GroupBox1.Controls.Add(Me.txt_S_DV)
        Me.GroupBox1.Controls.Add(Me.cmd_S_DV)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txt_S_SecCustAll)
        Me.GroupBox1.Controls.Add(Me.cmd_S_SecCustAll)
        Me.GroupBox1.Controls.Add(Me.txt_S_PriCustAll)
        Me.GroupBox1.Controls.Add(Me.cmd_S_PriCustAll)
        Me.GroupBox1.Controls.Add(Me.SLabel_2)
        Me.GroupBox1.Controls.Add(Me.SLabel_1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmd_S_ItmNo)
        Me.GroupBox1.Controls.Add(Me.lblTranDateTo)
        Me.GroupBox1.Controls.Add(Me.txtTranToDate)
        Me.GroupBox1.Controls.Add(Me.txtTranFromDate)
        Me.GroupBox1.Controls.Add(Me.lblSearchParam)
        Me.GroupBox1.Controls.Add(Me.optBOMItm)
        Me.GroupBox1.Controls.Add(Me.optItmMtr)
        Me.GroupBox1.Controls.Add(Me.optByExcel_New)
        Me.GroupBox1.Controls.Add(Me.optByExcel)
        Me.GroupBox1.Controls.Add(Me.chkAssort)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 47)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(535, 248)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Selection Criteria"
        '
        'txtItmNo
        '
        Me.txtItmNo.Location = New System.Drawing.Point(187, 87)
        Me.txtItmNo.Name = "txtItmNo"
        Me.txtItmNo.Size = New System.Drawing.Size(319, 22)
        Me.txtItmNo.TabIndex = 9
        '
        'txt_S_DV
        '
        Me.txt_S_DV.Location = New System.Drawing.Point(186, 173)
        Me.txt_S_DV.Name = "txt_S_DV"
        Me.txt_S_DV.Size = New System.Drawing.Size(319, 22)
        Me.txt_S_DV.TabIndex = 83
        '
        'cmd_S_DV
        '
        Me.cmd_S_DV.Location = New System.Drawing.Point(136, 173)
        Me.cmd_S_DV.Name = "cmd_S_DV"
        Me.cmd_S_DV.Size = New System.Drawing.Size(45, 21)
        Me.cmd_S_DV.TabIndex = 82
        Me.cmd_S_DV.Text = "＞＞"
        Me.cmd_S_DV.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 178)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 12)
        Me.Label9.TabIndex = 84
        Me.Label9.Text = "Design Vendor"
        '
        'txt_S_SecCustAll
        '
        Me.txt_S_SecCustAll.Location = New System.Drawing.Point(186, 146)
        Me.txt_S_SecCustAll.Name = "txt_S_SecCustAll"
        Me.txt_S_SecCustAll.Size = New System.Drawing.Size(319, 22)
        Me.txt_S_SecCustAll.TabIndex = 81
        '
        'cmd_S_SecCustAll
        '
        Me.cmd_S_SecCustAll.Location = New System.Drawing.Point(136, 146)
        Me.cmd_S_SecCustAll.Name = "cmd_S_SecCustAll"
        Me.cmd_S_SecCustAll.Size = New System.Drawing.Size(45, 21)
        Me.cmd_S_SecCustAll.TabIndex = 80
        Me.cmd_S_SecCustAll.Text = "＞＞"
        '
        'txt_S_PriCustAll
        '
        Me.txt_S_PriCustAll.Location = New System.Drawing.Point(186, 118)
        Me.txt_S_PriCustAll.Name = "txt_S_PriCustAll"
        Me.txt_S_PriCustAll.Size = New System.Drawing.Size(319, 22)
        Me.txt_S_PriCustAll.TabIndex = 79
        '
        'cmd_S_PriCustAll
        '
        Me.cmd_S_PriCustAll.Location = New System.Drawing.Point(136, 118)
        Me.cmd_S_PriCustAll.Name = "cmd_S_PriCustAll"
        Me.cmd_S_PriCustAll.Size = New System.Drawing.Size(45, 21)
        Me.cmd_S_PriCustAll.TabIndex = 78
        Me.cmd_S_PriCustAll.Text = "＞＞"
        '
        'SLabel_2
        '
        Me.SLabel_2.AutoSize = True
        Me.SLabel_2.Location = New System.Drawing.Point(8, 150)
        Me.SLabel_2.Name = "SLabel_2"
        Me.SLabel_2.Size = New System.Drawing.Size(119, 12)
        Me.SLabel_2.TabIndex = 77
        Me.SLabel_2.Text = "Secondary Customer No"
        '
        'SLabel_1
        '
        Me.SLabel_1.AutoSize = True
        Me.SLabel_1.Location = New System.Drawing.Point(8, 121)
        Me.SLabel_1.Name = "SLabel_1"
        Me.SLabel_1.Size = New System.Drawing.Size(107, 12)
        Me.SLabel_1.TabIndex = 76
        Me.SLabel_1.Text = "Primary Customer No"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 12)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Item No."
        '
        'cmd_S_ItmNo
        '
        Me.cmd_S_ItmNo.Location = New System.Drawing.Point(136, 87)
        Me.cmd_S_ItmNo.Name = "cmd_S_ItmNo"
        Me.cmd_S_ItmNo.Size = New System.Drawing.Size(45, 21)
        Me.cmd_S_ItmNo.TabIndex = 74
        Me.cmd_S_ItmNo.Text = "＞＞"
        '
        'lblTranDateTo
        '
        Me.lblTranDateTo.AutoSize = True
        Me.lblTranDateTo.Location = New System.Drawing.Point(253, 53)
        Me.lblTranDateTo.Name = "lblTranDateTo"
        Me.lblTranDateTo.Size = New System.Drawing.Size(18, 12)
        Me.lblTranDateTo.TabIndex = 7
        Me.lblTranDateTo.Text = "To"
        '
        'txtTranToDate
        '
        Me.txtTranToDate.Location = New System.Drawing.Point(308, 50)
        Me.txtTranToDate.Mask = "00/00/0000"
        Me.txtTranToDate.Name = "txtTranToDate"
        Me.txtTranToDate.Size = New System.Drawing.Size(78, 22)
        Me.txtTranToDate.TabIndex = 6
        Me.txtTranToDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTranFromDate
        '
        Me.txtTranFromDate.Location = New System.Drawing.Point(142, 50)
        Me.txtTranFromDate.Mask = "00/00/0000"
        Me.txtTranFromDate.Name = "txtTranFromDate"
        Me.txtTranFromDate.Size = New System.Drawing.Size(78, 22)
        Me.txtTranFromDate.TabIndex = 5
        Me.txtTranFromDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblSearchParam
        '
        Me.lblSearchParam.AutoSize = True
        Me.lblSearchParam.Location = New System.Drawing.Point(16, 53)
        Me.lblSearchParam.Name = "lblSearchParam"
        Me.lblSearchParam.Size = New System.Drawing.Size(83, 12)
        Me.lblSearchParam.TabIndex = 4
        Me.lblSearchParam.Text = "Transaction Date"
        '
        'optBOMItm
        '
        Me.optBOMItm.AutoSize = True
        Me.optBOMItm.Location = New System.Drawing.Point(282, 215)
        Me.optBOMItm.Name = "optBOMItm"
        Me.optBOMItm.Size = New System.Drawing.Size(129, 16)
        Me.optBOMItm.TabIndex = 3
        Me.optBOMItm.TabStop = True
        Me.optBOMItm.Text = "By BOM Item(useless)"
        Me.optBOMItm.UseVisualStyleBackColor = True
        Me.optBOMItm.Visible = False
        '
        'optItmMtr
        '
        Me.optItmMtr.AutoSize = True
        Me.optItmMtr.Location = New System.Drawing.Point(411, 22)
        Me.optItmMtr.Name = "optItmMtr"
        Me.optItmMtr.Size = New System.Drawing.Size(95, 16)
        Me.optItmMtr.TabIndex = 2
        Me.optItmMtr.TabStop = True
        Me.optItmMtr.Text = "By Item Master"
        Me.optItmMtr.UseVisualStyleBackColor = True
        '
        'optByExcel_New
        '
        Me.optByExcel_New.AutoSize = True
        Me.optByExcel_New.Location = New System.Drawing.Point(204, 22)
        Me.optByExcel_New.Name = "optByExcel_New"
        Me.optByExcel_New.Size = New System.Drawing.Size(138, 16)
        Me.optByExcel_New.TabIndex = 1
        Me.optByExcel_New.TabStop = True
        Me.optByExcel_New.Text = "By Excel (New w/ Alias)"
        Me.optByExcel_New.UseVisualStyleBackColor = True
        '
        'optByExcel
        '
        Me.optByExcel.AutoSize = True
        Me.optByExcel.Location = New System.Drawing.Point(16, 22)
        Me.optByExcel.Name = "optByExcel"
        Me.optByExcel.Size = New System.Drawing.Size(99, 16)
        Me.optByExcel.TabIndex = 0
        Me.optByExcel.TabStop = True
        Me.optByExcel.Text = "By Excel (UPD)"
        Me.optByExcel.UseVisualStyleBackColor = True
        '
        'chkAssort
        '
        Me.chkAssort.AutoSize = True
        Me.chkAssort.Location = New System.Drawing.Point(142, 52)
        Me.chkAssort.Name = "chkAssort"
        Me.chkAssort.Size = New System.Drawing.Size(15, 14)
        Me.chkAssort.TabIndex = 10
        Me.chkAssort.UseVisualStyleBackColor = True
        '
        'chkExcel
        '
        Me.chkExcel.AutoSize = True
        Me.chkExcel.Location = New System.Drawing.Point(163, 306)
        Me.chkExcel.Name = "chkExcel"
        Me.chkExcel.Size = New System.Drawing.Size(97, 16)
        Me.chkExcel.TabIndex = 2
        Me.chkExcel.Text = "Export to Excel"
        Me.chkExcel.UseVisualStyleBackColor = True
        Me.chkExcel.Visible = False
        '
        'cmdShowReport
        '
        Me.cmdShowReport.Location = New System.Drawing.Point(288, 301)
        Me.cmdShowReport.Name = "cmdShowReport"
        Me.cmdShowReport.Size = New System.Drawing.Size(108, 24)
        Me.cmdShowReport.TabIndex = 3
        Me.cmdShowReport.Text = "&Show Report"
        Me.cmdShowReport.UseVisualStyleBackColor = True
        '
        'btnExExcel
        '
        Me.btnExExcel.Location = New System.Drawing.Point(154, 301)
        Me.btnExExcel.Name = "btnExExcel"
        Me.btnExExcel.Size = New System.Drawing.Size(108, 24)
        Me.btnExExcel.TabIndex = 4
        Me.btnExExcel.Text = "Export to Excel"
        Me.btnExExcel.UseVisualStyleBackColor = True
        '
        'IAR00001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(559, 339)
        Me.Controls.Add(Me.btnExExcel)
        Me.Controls.Add(Me.cmdShowReport)
        Me.Controls.Add(Me.chkExcel)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "IAR00001"
        Me.Text = "IAR00001 - Impact Analysis Report"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblSearchParam As System.Windows.Forms.Label
    Friend WithEvents optBOMItm As System.Windows.Forms.RadioButton
    Friend WithEvents optItmMtr As System.Windows.Forms.RadioButton
    Friend WithEvents optByExcel_New As System.Windows.Forms.RadioButton
    Friend WithEvents optByExcel As System.Windows.Forms.RadioButton
    Friend WithEvents txtTranFromDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTranDateTo As System.Windows.Forms.Label
    Friend WithEvents txtTranToDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtItmNo As System.Windows.Forms.TextBox
    Friend WithEvents chkExcel As System.Windows.Forms.CheckBox
    Friend WithEvents cmdShowReport As System.Windows.Forms.Button
    Friend WithEvents chkAssort As System.Windows.Forms.CheckBox
    Friend WithEvents btnExExcel As System.Windows.Forms.Button
    Friend WithEvents cmd_S_ItmNo As System.Windows.Forms.Button
    Friend WithEvents txt_S_SecCustAll As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_SecCustAll As System.Windows.Forms.Button
    Friend WithEvents txt_S_PriCustAll As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_PriCustAll As System.Windows.Forms.Button
    Friend WithEvents SLabel_2 As System.Windows.Forms.Label
    Friend WithEvents SLabel_1 As System.Windows.Forms.Label
    Friend WithEvents txt_S_DV As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_DV As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
