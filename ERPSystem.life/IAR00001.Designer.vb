﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IAR00001))
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.optNewWithTemp = New System.Windows.Forms.RadioButton
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
        Me.optItmPrcHis = New System.Windows.Forms.RadioButton
        Me.optNewWithAlias = New System.Windows.Forms.RadioButton
        Me.optIMupd = New System.Windows.Forms.RadioButton
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
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(223, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(211, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Impact Analysis Report"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optNewWithTemp)
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
        Me.GroupBox1.Controls.Add(Me.optItmPrcHis)
        Me.GroupBox1.Controls.Add(Me.optNewWithAlias)
        Me.GroupBox1.Controls.Add(Me.optIMupd)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 47)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(610, 248)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Selection Criteria"
        '
        'optNewWithTemp
        '
        Me.optNewWithTemp.AutoSize = True
        Me.optNewWithTemp.Location = New System.Drawing.Point(321, 21)
        Me.optNewWithTemp.Name = "optNewWithTemp"
        Me.optNewWithTemp.Size = New System.Drawing.Size(159, 16)
        Me.optNewWithTemp.TabIndex = 85
        Me.optNewWithTemp.TabStop = True
        Me.optNewWithTemp.Text = "Excel upload data with Temp"
        Me.optNewWithTemp.UseVisualStyleBackColor = True
        '
        'txtItmNo
        '
        Me.txtItmNo.Location = New System.Drawing.Point(187, 87)
        Me.txtItmNo.Name = "txtItmNo"
        Me.txtItmNo.Size = New System.Drawing.Size(377, 22)
        Me.txtItmNo.TabIndex = 9
        '
        'txt_S_DV
        '
        Me.txt_S_DV.Location = New System.Drawing.Point(186, 173)
        Me.txt_S_DV.Name = "txt_S_DV"
        Me.txt_S_DV.Size = New System.Drawing.Size(377, 22)
        Me.txt_S_DV.TabIndex = 83
        '
        'cmd_S_DV
        '
        Me.cmd_S_DV.Location = New System.Drawing.Point(136, 173)
        Me.cmd_S_DV.Name = "cmd_S_DV"
        Me.cmd_S_DV.Size = New System.Drawing.Size(45, 22)
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
        Me.txt_S_SecCustAll.Size = New System.Drawing.Size(377, 22)
        Me.txt_S_SecCustAll.TabIndex = 81
        '
        'cmd_S_SecCustAll
        '
        Me.cmd_S_SecCustAll.Location = New System.Drawing.Point(136, 146)
        Me.cmd_S_SecCustAll.Name = "cmd_S_SecCustAll"
        Me.cmd_S_SecCustAll.Size = New System.Drawing.Size(45, 22)
        Me.cmd_S_SecCustAll.TabIndex = 80
        Me.cmd_S_SecCustAll.Text = "＞＞"
        '
        'txt_S_PriCustAll
        '
        Me.txt_S_PriCustAll.Location = New System.Drawing.Point(186, 118)
        Me.txt_S_PriCustAll.Name = "txt_S_PriCustAll"
        Me.txt_S_PriCustAll.Size = New System.Drawing.Size(377, 22)
        Me.txt_S_PriCustAll.TabIndex = 79
        '
        'cmd_S_PriCustAll
        '
        Me.cmd_S_PriCustAll.Location = New System.Drawing.Point(136, 118)
        Me.cmd_S_PriCustAll.Name = "cmd_S_PriCustAll"
        Me.cmd_S_PriCustAll.Size = New System.Drawing.Size(45, 22)
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
        Me.cmd_S_ItmNo.Size = New System.Drawing.Size(45, 22)
        Me.cmd_S_ItmNo.TabIndex = 8
        Me.cmd_S_ItmNo.Text = "＞＞"
        '
        'lblTranDateTo
        '
        Me.lblTranDateTo.AutoSize = True
        Me.lblTranDateTo.Location = New System.Drawing.Point(298, 57)
        Me.lblTranDateTo.Name = "lblTranDateTo"
        Me.lblTranDateTo.Size = New System.Drawing.Size(18, 12)
        Me.lblTranDateTo.TabIndex = 7
        Me.lblTranDateTo.Text = "To"
        '
        'txtTranToDate
        '
        Me.txtTranToDate.Location = New System.Drawing.Point(353, 54)
        Me.txtTranToDate.Mask = "00/00/0000"
        Me.txtTranToDate.Name = "txtTranToDate"
        Me.txtTranToDate.Size = New System.Drawing.Size(78, 22)
        Me.txtTranToDate.TabIndex = 6
        Me.txtTranToDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTranFromDate
        '
        Me.txtTranFromDate.Location = New System.Drawing.Point(186, 54)
        Me.txtTranFromDate.Mask = "00/00/0000"
        Me.txtTranFromDate.Name = "txtTranFromDate"
        Me.txtTranFromDate.Size = New System.Drawing.Size(78, 22)
        Me.txtTranFromDate.TabIndex = 5
        Me.txtTranFromDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblSearchParam
        '
        Me.lblSearchParam.AutoSize = True
        Me.lblSearchParam.Location = New System.Drawing.Point(8, 57)
        Me.lblSearchParam.Name = "lblSearchParam"
        Me.lblSearchParam.Size = New System.Drawing.Size(83, 12)
        Me.lblSearchParam.TabIndex = 4
        Me.lblSearchParam.Text = "Transaction Date"
        '
        'optItmPrcHis
        '
        Me.optItmPrcHis.AutoSize = True
        Me.optItmPrcHis.Location = New System.Drawing.Point(482, 21)
        Me.optItmPrcHis.Name = "optItmPrcHis"
        Me.optItmPrcHis.Size = New System.Drawing.Size(122, 16)
        Me.optItmPrcHis.TabIndex = 2
        Me.optItmPrcHis.TabStop = True
        Me.optItmPrcHis.Text = "Price Change History"
        Me.optItmPrcHis.UseVisualStyleBackColor = True
        '
        'optNewWithAlias
        '
        Me.optNewWithAlias.AutoSize = True
        Me.optNewWithAlias.Location = New System.Drawing.Point(162, 21)
        Me.optNewWithAlias.Name = "optNewWithAlias"
        Me.optNewWithAlias.Size = New System.Drawing.Size(155, 16)
        Me.optNewWithAlias.TabIndex = 1
        Me.optNewWithAlias.TabStop = True
        Me.optNewWithAlias.Text = "Excel upload data with Alias"
        Me.optNewWithAlias.UseVisualStyleBackColor = True
        '
        'optIMupd
        '
        Me.optIMupd.AutoSize = True
        Me.optIMupd.Location = New System.Drawing.Point(10, 21)
        Me.optIMupd.Name = "optIMupd"
        Me.optIMupd.Size = New System.Drawing.Size(146, 16)
        Me.optIMupd.TabIndex = 0
        Me.optIMupd.TabStop = True
        Me.optIMupd.Text = "Excel upload data with IM"
        Me.optIMupd.UseVisualStyleBackColor = True
        '
        'chkExcel
        '
        Me.chkExcel.AutoSize = True
        Me.chkExcel.Location = New System.Drawing.Point(505, 306)
        Me.chkExcel.Name = "chkExcel"
        Me.chkExcel.Size = New System.Drawing.Size(97, 16)
        Me.chkExcel.TabIndex = 2
        Me.chkExcel.Text = "Export to Excel"
        Me.chkExcel.UseVisualStyleBackColor = True
        Me.chkExcel.Visible = False
        '
        'cmdShowReport
        '
        Me.cmdShowReport.Location = New System.Drawing.Point(494, 301)
        Me.cmdShowReport.Name = "cmdShowReport"
        Me.cmdShowReport.Size = New System.Drawing.Size(108, 24)
        Me.cmdShowReport.TabIndex = 3
        Me.cmdShowReport.Text = "&Show Report"
        Me.cmdShowReport.UseVisualStyleBackColor = True
        Me.cmdShowReport.Visible = False
        '
        'btnExExcel
        '
        Me.btnExExcel.Location = New System.Drawing.Point(289, 301)
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
        Me.ClientSize = New System.Drawing.Size(634, 339)
        Me.Controls.Add(Me.btnExExcel)
        Me.Controls.Add(Me.cmdShowReport)
        Me.Controls.Add(Me.chkExcel)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "IAR00001"
        Me.Text = "IAR00001 - Impact Analysis Report (IAR01)"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblSearchParam As System.Windows.Forms.Label
    Friend WithEvents optItmPrcHis As System.Windows.Forms.RadioButton
    Friend WithEvents optNewWithAlias As System.Windows.Forms.RadioButton
    Friend WithEvents optIMupd As System.Windows.Forms.RadioButton
    Friend WithEvents txtTranFromDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTranDateTo As System.Windows.Forms.Label
    Friend WithEvents txtTranToDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtItmNo As System.Windows.Forms.TextBox
    Friend WithEvents chkExcel As System.Windows.Forms.CheckBox
    Friend WithEvents cmdShowReport As System.Windows.Forms.Button
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
    Friend WithEvents optNewWithTemp As System.Windows.Forms.RadioButton
End Class
