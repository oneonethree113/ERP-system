<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class POR00005
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
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblRptName = New System.Windows.Forms.Label
        Me.cmdShow = New System.Windows.Forms.Button
        Me.gbInputCri = New System.Windows.Forms.GroupBox
        Me.gbReportFormat = New System.Windows.Forms.GroupBox
        Me.cboReportFormat = New System.Windows.Forms.ComboBox
        Me.lblReportFormat = New System.Windows.Forms.Label
        Me.gbItmNo = New System.Windows.Forms.GroupBox
        Me.optRunNo = New System.Windows.Forms.RadioButton
        Me.optBat = New System.Windows.Forms.RadioButton
        Me.optPO = New System.Windows.Forms.RadioButton
        Me.optJob = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtRunNoTo = New System.Windows.Forms.TextBox
        Me.txtPOTo = New System.Windows.Forms.TextBox
        Me.txtTo = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtBatNo = New System.Windows.Forms.TextBox
        Me.txtRunNoFm = New System.Windows.Forms.TextBox
        Me.txtPOFm = New System.Windows.Forms.TextBox
        Me.txtFm = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.lblbomNoFm = New System.Windows.Forms.Label
        Me.gbItmSelect = New System.Windows.Forms.GroupBox
        Me.optSAP = New System.Windows.Forms.RadioButton
        Me.optALL = New System.Windows.Forms.RadioButton
        Me.Label6 = New System.Windows.Forms.Label
        Me.gbGroup = New System.Windows.Forms.GroupBox
        Me.optGroupN = New System.Windows.Forms.RadioButton
        Me.optGroupY = New System.Windows.Forms.RadioButton
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.gbInputCri.SuspendLayout()
        Me.gbReportFormat.SuspendLayout()
        Me.gbItmNo.SuspendLayout()
        Me.gbItmSelect.SuspendLayout()
        Me.gbGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboCoCde
        '
        Me.cboCoCde.BackColor = System.Drawing.SystemColors.Window
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(97, 42)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(66, 21)
        Me.cboCoCde.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(165, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Company Name :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(12, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Company Code :"
        '
        'lblRptName
        '
        Me.lblRptName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRptName.ForeColor = System.Drawing.Color.Blue
        Me.lblRptName.Location = New System.Drawing.Point(12, 9)
        Me.lblRptName.Name = "lblRptName"
        Me.lblRptName.Size = New System.Drawing.Size(515, 24)
        Me.lblRptName.TabIndex = 19
        Me.lblRptName.Text = "Print Production Note (Job Order)"
        Me.lblRptName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(206, 408)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(124, 45)
        Me.cmdShow.TabIndex = 19
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'gbInputCri
        '
        Me.gbInputCri.Controls.Add(Me.gbReportFormat)
        Me.gbInputCri.Controls.Add(Me.gbItmNo)
        Me.gbInputCri.Controls.Add(Me.gbItmSelect)
        Me.gbInputCri.Controls.Add(Me.gbGroup)
        Me.gbInputCri.Location = New System.Drawing.Point(12, 69)
        Me.gbInputCri.Name = "gbInputCri"
        Me.gbInputCri.Size = New System.Drawing.Size(515, 333)
        Me.gbInputCri.TabIndex = 3
        Me.gbInputCri.TabStop = False
        Me.gbInputCri.Text = "Input Criteria"
        '
        'gbReportFormat
        '
        Me.gbReportFormat.Controls.Add(Me.cboReportFormat)
        Me.gbReportFormat.Controls.Add(Me.lblReportFormat)
        Me.gbReportFormat.Location = New System.Drawing.Point(18, 223)
        Me.gbReportFormat.Name = "gbReportFormat"
        Me.gbReportFormat.Size = New System.Drawing.Size(476, 43)
        Me.gbReportFormat.TabIndex = 15
        Me.gbReportFormat.TabStop = False
        '
        'cboReportFormat
        '
        Me.cboReportFormat.BackColor = System.Drawing.SystemColors.Window
        Me.cboReportFormat.FormattingEnabled = True
        Me.cboReportFormat.Location = New System.Drawing.Point(123, 13)
        Me.cboReportFormat.Name = "cboReportFormat"
        Me.cboReportFormat.Size = New System.Drawing.Size(254, 21)
        Me.cboReportFormat.TabIndex = 16
        Me.cboReportFormat.Text = "Production Note Standard Format"
        '
        'lblReportFormat
        '
        Me.lblReportFormat.AutoSize = True
        Me.lblReportFormat.Location = New System.Drawing.Point(10, 16)
        Me.lblReportFormat.Name = "lblReportFormat"
        Me.lblReportFormat.Size = New System.Drawing.Size(89, 13)
        Me.lblReportFormat.TabIndex = 0
        Me.lblReportFormat.Text = "Report Format   : "
        '
        'gbItmNo
        '
        Me.gbItmNo.Controls.Add(Me.optRunNo)
        Me.gbItmNo.Controls.Add(Me.optBat)
        Me.gbItmNo.Controls.Add(Me.optPO)
        Me.gbItmNo.Controls.Add(Me.optJob)
        Me.gbItmNo.Controls.Add(Me.Label1)
        Me.gbItmNo.Controls.Add(Me.txtRunNoTo)
        Me.gbItmNo.Controls.Add(Me.txtPOTo)
        Me.gbItmNo.Controls.Add(Me.txtTo)
        Me.gbItmNo.Controls.Add(Me.Label12)
        Me.gbItmNo.Controls.Add(Me.Label10)
        Me.gbItmNo.Controls.Add(Me.Label5)
        Me.gbItmNo.Controls.Add(Me.txtBatNo)
        Me.gbItmNo.Controls.Add(Me.txtRunNoFm)
        Me.gbItmNo.Controls.Add(Me.txtPOFm)
        Me.gbItmNo.Controls.Add(Me.txtFm)
        Me.gbItmNo.Controls.Add(Me.Label13)
        Me.gbItmNo.Controls.Add(Me.Label11)
        Me.gbItmNo.Controls.Add(Me.Label9)
        Me.gbItmNo.Controls.Add(Me.lblbomNoFm)
        Me.gbItmNo.Location = New System.Drawing.Point(18, 19)
        Me.gbItmNo.Name = "gbItmNo"
        Me.gbItmNo.Size = New System.Drawing.Size(476, 147)
        Me.gbItmNo.TabIndex = 4
        Me.gbItmNo.TabStop = False
        '
        'optRunNo
        '
        Me.optRunNo.AutoSize = True
        Me.optRunNo.Location = New System.Drawing.Point(275, 14)
        Me.optRunNo.Name = "optRunNo"
        Me.optRunNo.Size = New System.Drawing.Size(82, 17)
        Me.optRunNo.TabIndex = 5
        Me.optRunNo.Text = "Running No"
        Me.optRunNo.UseVisualStyleBackColor = True
        '
        'optBat
        '
        Me.optBat.AutoSize = True
        Me.optBat.Enabled = False
        Me.optBat.Location = New System.Drawing.Point(373, 14)
        Me.optBat.Name = "optBat"
        Me.optBat.Size = New System.Drawing.Size(90, 17)
        Me.optBat.TabIndex = 5
        Me.optBat.Text = "Batch Job No"
        Me.optBat.UseVisualStyleBackColor = True
        '
        'optPO
        '
        Me.optPO.AutoSize = True
        Me.optPO.Location = New System.Drawing.Point(200, 14)
        Me.optPO.Name = "optPO"
        Me.optPO.Size = New System.Drawing.Size(57, 17)
        Me.optPO.TabIndex = 5
        Me.optPO.Text = "PO No"
        Me.optPO.UseVisualStyleBackColor = True
        '
        'optJob
        '
        Me.optJob.AutoSize = True
        Me.optJob.Checked = True
        Me.optJob.Location = New System.Drawing.Point(123, 14)
        Me.optJob.Name = "optJob"
        Me.optJob.Size = New System.Drawing.Size(59, 17)
        Me.optJob.TabIndex = 5
        Me.optJob.TabStop = True
        Me.optJob.Text = "Job No"
        Me.optJob.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Selection :"
        '
        'txtRunNoTo
        '
        Me.txtRunNoTo.BackColor = System.Drawing.SystemColors.Window
        Me.txtRunNoTo.Location = New System.Drawing.Point(323, 89)
        Me.txtRunNoTo.Name = "txtRunNoTo"
        Me.txtRunNoTo.Size = New System.Drawing.Size(140, 20)
        Me.txtRunNoTo.TabIndex = 11
        '
        'txtPOTo
        '
        Me.txtPOTo.BackColor = System.Drawing.SystemColors.Window
        Me.txtPOTo.Location = New System.Drawing.Point(323, 63)
        Me.txtPOTo.Name = "txtPOTo"
        Me.txtPOTo.Size = New System.Drawing.Size(140, 20)
        Me.txtPOTo.TabIndex = 9
        '
        'txtTo
        '
        Me.txtTo.BackColor = System.Drawing.SystemColors.Window
        Me.txtTo.Location = New System.Drawing.Point(323, 37)
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Size = New System.Drawing.Size(140, 20)
        Me.txtTo.TabIndex = 7
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(283, 92)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(29, 13)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "To : "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(283, 66)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(29, 13)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "To : "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(283, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "To : "
        '
        'txtBatNo
        '
        Me.txtBatNo.BackColor = System.Drawing.SystemColors.Window
        Me.txtBatNo.Enabled = False
        Me.txtBatNo.Location = New System.Drawing.Point(123, 115)
        Me.txtBatNo.Name = "txtBatNo"
        Me.txtBatNo.ReadOnly = True
        Me.txtBatNo.Size = New System.Drawing.Size(140, 20)
        Me.txtBatNo.TabIndex = 12
        '
        'txtRunNoFm
        '
        Me.txtRunNoFm.BackColor = System.Drawing.SystemColors.Window
        Me.txtRunNoFm.Location = New System.Drawing.Point(123, 89)
        Me.txtRunNoFm.Name = "txtRunNoFm"
        Me.txtRunNoFm.Size = New System.Drawing.Size(140, 20)
        Me.txtRunNoFm.TabIndex = 10
        '
        'txtPOFm
        '
        Me.txtPOFm.BackColor = System.Drawing.SystemColors.Window
        Me.txtPOFm.Location = New System.Drawing.Point(123, 63)
        Me.txtPOFm.Name = "txtPOFm"
        Me.txtPOFm.Size = New System.Drawing.Size(140, 20)
        Me.txtPOFm.TabIndex = 8
        '
        'txtFm
        '
        Me.txtFm.BackColor = System.Drawing.SystemColors.Window
        Me.txtFm.Location = New System.Drawing.Point(123, 37)
        Me.txtFm.Name = "txtFm"
        Me.txtFm.Size = New System.Drawing.Size(140, 20)
        Me.txtFm.TabIndex = 6
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(10, 118)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(78, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Batch Job No :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(10, 92)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(96, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Running No From :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(10, 66)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "PO No From :"
        '
        'lblbomNoFm
        '
        Me.lblbomNoFm.AutoSize = True
        Me.lblbomNoFm.Location = New System.Drawing.Point(10, 40)
        Me.lblbomNoFm.Name = "lblbomNoFm"
        Me.lblbomNoFm.Size = New System.Drawing.Size(76, 13)
        Me.lblbomNoFm.TabIndex = 0
        Me.lblbomNoFm.Text = "Job No  From :"
        '
        'gbItmSelect
        '
        Me.gbItmSelect.Controls.Add(Me.optSAP)
        Me.gbItmSelect.Controls.Add(Me.optALL)
        Me.gbItmSelect.Controls.Add(Me.Label6)
        Me.gbItmSelect.Location = New System.Drawing.Point(18, 272)
        Me.gbItmSelect.Name = "gbItmSelect"
        Me.gbItmSelect.Size = New System.Drawing.Size(476, 42)
        Me.gbItmSelect.TabIndex = 17
        Me.gbItmSelect.TabStop = False
        '
        'optSAP
        '
        Me.optSAP.AutoSize = True
        Me.optSAP.Enabled = False
        Me.optSAP.Location = New System.Drawing.Point(274, 14)
        Me.optSAP.Name = "optSAP"
        Me.optSAP.Size = New System.Drawing.Size(161, 17)
        Me.optSAP.TabIndex = 18
        Me.optSAP.TabStop = True
        Me.optSAP.Text = "SAP Items (Factory A, B && U)"
        Me.optSAP.UseVisualStyleBackColor = True
        '
        'optALL
        '
        Me.optALL.AutoSize = True
        Me.optALL.Checked = True
        Me.optALL.Enabled = False
        Me.optALL.Location = New System.Drawing.Point(123, 14)
        Me.optALL.Name = "optALL"
        Me.optALL.Size = New System.Drawing.Size(64, 17)
        Me.optALL.TabIndex = 18
        Me.optALL.TabStop = True
        Me.optALL.Text = "All Items"
        Me.optALL.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Items Selection :"
        '
        'gbGroup
        '
        Me.gbGroup.Controls.Add(Me.optGroupN)
        Me.gbGroup.Controls.Add(Me.optGroupY)
        Me.gbGroup.Controls.Add(Me.Label8)
        Me.gbGroup.Location = New System.Drawing.Point(18, 172)
        Me.gbGroup.Name = "gbGroup"
        Me.gbGroup.Size = New System.Drawing.Size(476, 45)
        Me.gbGroup.TabIndex = 13
        Me.gbGroup.TabStop = False
        '
        'optGroupN
        '
        Me.optGroupN.AutoSize = True
        Me.optGroupN.Enabled = False
        Me.optGroupN.Location = New System.Drawing.Point(274, 15)
        Me.optGroupN.Name = "optGroupN"
        Me.optGroupN.Size = New System.Drawing.Size(39, 17)
        Me.optGroupN.TabIndex = 14
        Me.optGroupN.TabStop = True
        Me.optGroupN.Text = "No"
        Me.optGroupN.UseVisualStyleBackColor = True
        '
        'optGroupY
        '
        Me.optGroupY.AutoSize = True
        Me.optGroupY.Checked = True
        Me.optGroupY.Enabled = False
        Me.optGroupY.Location = New System.Drawing.Point(199, 15)
        Me.optGroupY.Name = "optGroupY"
        Me.optGroupY.Size = New System.Drawing.Size(43, 17)
        Me.optGroupY.TabIndex = 14
        Me.optGroupY.TabStop = True
        Me.optGroupY.Text = "Yes"
        Me.optGroupY.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(167, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Group The New Format Item No. :"
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.SystemColors.MenuBar
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.ForeColor = System.Drawing.Color.DimGray
        Me.txtCoNam.Location = New System.Drawing.Point(256, 42)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.ReadOnly = True
        Me.txtCoNam.Size = New System.Drawing.Size(271, 20)
        Me.txtCoNam.TabIndex = 22
        '
        'POR00005
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(539, 464)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.gbInputCri)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblRptName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "POR00005"
        Me.Text = "Print Production Note (Job Order)"
        Me.gbInputCri.ResumeLayout(False)
        Me.gbReportFormat.ResumeLayout(False)
        Me.gbReportFormat.PerformLayout()
        Me.gbItmNo.ResumeLayout(False)
        Me.gbItmNo.PerformLayout()
        Me.gbItmSelect.ResumeLayout(False)
        Me.gbItmSelect.PerformLayout()
        Me.gbGroup.ResumeLayout(False)
        Me.gbGroup.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblRptName As System.Windows.Forms.Label
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents gbInputCri As System.Windows.Forms.GroupBox
    Friend WithEvents gbReportFormat As System.Windows.Forms.GroupBox
    Friend WithEvents cboReportFormat As System.Windows.Forms.ComboBox
    Friend WithEvents lblReportFormat As System.Windows.Forms.Label
    Friend WithEvents gbItmNo As System.Windows.Forms.GroupBox
    Friend WithEvents txtTo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFm As System.Windows.Forms.TextBox
    Friend WithEvents lblbomNoFm As System.Windows.Forms.Label
    Friend WithEvents gbItmSelect As System.Windows.Forms.GroupBox
    Friend WithEvents optSAP As System.Windows.Forms.RadioButton
    Friend WithEvents optALL As System.Windows.Forms.RadioButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents gbGroup As System.Windows.Forms.GroupBox
    Friend WithEvents optGroupN As System.Windows.Forms.RadioButton
    Friend WithEvents optGroupY As System.Windows.Forms.RadioButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents optRunNo As System.Windows.Forms.RadioButton
    Friend WithEvents optBat As System.Windows.Forms.RadioButton
    Friend WithEvents optPO As System.Windows.Forms.RadioButton
    Friend WithEvents optJob As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRunNoTo As System.Windows.Forms.TextBox
    Friend WithEvents txtPOTo As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtBatNo As System.Windows.Forms.TextBox
    Friend WithEvents txtRunNoFm As System.Windows.Forms.TextBox
    Friend WithEvents txtPOFm As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
End Class
