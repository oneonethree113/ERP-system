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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(POR00005))
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblRptName = New System.Windows.Forms.Label
        Me.cmdShow = New System.Windows.Forms.Button
        Me.cboReportFormat = New System.Windows.Forms.ComboBox
        Me.lblReportFormat = New System.Windows.Forms.Label
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
        Me.optSAP = New System.Windows.Forms.RadioButton
        Me.optALL = New System.Windows.Forms.RadioButton
        Me.Label6 = New System.Windows.Forms.Label
        Me.optGroupN = New System.Windows.Forms.RadioButton
        Me.optGroupY = New System.Windows.Forms.RadioButton
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboCoCde
        '
        Me.cboCoCde.BackColor = System.Drawing.SystemColors.Window
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(97, 39)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(85, 20)
        Me.cboCoCde.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(188, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 12)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Company Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(12, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 12)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Company Code"
        '
        'lblRptName
        '
        Me.lblRptName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRptName.ForeColor = System.Drawing.Color.Blue
        Me.lblRptName.Location = New System.Drawing.Point(12, 8)
        Me.lblRptName.Name = "lblRptName"
        Me.lblRptName.Size = New System.Drawing.Size(610, 22)
        Me.lblRptName.TabIndex = 19
        Me.lblRptName.Text = "Print Production Note (Job Order)"
        Me.lblRptName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(243, 339)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(116, 40)
        Me.cmdShow.TabIndex = 13
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'cboReportFormat
        '
        Me.cboReportFormat.BackColor = System.Drawing.SystemColors.Window
        Me.cboReportFormat.Enabled = False
        Me.cboReportFormat.FormattingEnabled = True
        Me.cboReportFormat.Location = New System.Drawing.Point(190, 267)
        Me.cboReportFormat.Name = "cboReportFormat"
        Me.cboReportFormat.Size = New System.Drawing.Size(395, 20)
        Me.cboReportFormat.TabIndex = 11
        Me.cboReportFormat.Text = "Production Note Standard Format"
        '
        'lblReportFormat
        '
        Me.lblReportFormat.AutoSize = True
        Me.lblReportFormat.Location = New System.Drawing.Point(12, 270)
        Me.lblReportFormat.Name = "lblReportFormat"
        Me.lblReportFormat.Size = New System.Drawing.Size(76, 12)
        Me.lblReportFormat.TabIndex = 0
        Me.lblReportFormat.Text = "Report Format "
        '
        'optRunNo
        '
        Me.optRunNo.AutoSize = True
        Me.optRunNo.Location = New System.Drawing.Point(198, 3)
        Me.optRunNo.Name = "optRunNo"
        Me.optRunNo.Size = New System.Drawing.Size(81, 16)
        Me.optRunNo.TabIndex = 3
        Me.optRunNo.Text = "Running No"
        Me.optRunNo.UseVisualStyleBackColor = True
        '
        'optBat
        '
        Me.optBat.AutoSize = True
        Me.optBat.Enabled = False
        Me.optBat.Location = New System.Drawing.Point(312, 3)
        Me.optBat.Name = "optBat"
        Me.optBat.Size = New System.Drawing.Size(86, 16)
        Me.optBat.TabIndex = 4
        Me.optBat.Text = "Batch Job No"
        Me.optBat.UseVisualStyleBackColor = True
        '
        'optPO
        '
        Me.optPO.AutoSize = True
        Me.optPO.Location = New System.Drawing.Point(102, 3)
        Me.optPO.Name = "optPO"
        Me.optPO.Size = New System.Drawing.Size(54, 16)
        Me.optPO.TabIndex = 2
        Me.optPO.Text = "PO No"
        Me.optPO.UseVisualStyleBackColor = True
        '
        'optJob
        '
        Me.optJob.AutoSize = True
        Me.optJob.Checked = True
        Me.optJob.Location = New System.Drawing.Point(3, 3)
        Me.optJob.Name = "optJob"
        Me.optJob.Size = New System.Drawing.Size(56, 16)
        Me.optJob.TabIndex = 1
        Me.optJob.TabStop = True
        Me.optJob.Text = "Job No"
        Me.optJob.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 12)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Selection"
        '
        'txtRunNoTo
        '
        Me.txtRunNoTo.BackColor = System.Drawing.SystemColors.Window
        Me.txtRunNoTo.Location = New System.Drawing.Point(426, 179)
        Me.txtRunNoTo.Name = "txtRunNoTo"
        Me.txtRunNoTo.Size = New System.Drawing.Size(159, 22)
        Me.txtRunNoTo.TabIndex = 8
        '
        'txtPOTo
        '
        Me.txtPOTo.BackColor = System.Drawing.SystemColors.Window
        Me.txtPOTo.Location = New System.Drawing.Point(426, 146)
        Me.txtPOTo.Name = "txtPOTo"
        Me.txtPOTo.Size = New System.Drawing.Size(159, 22)
        Me.txtPOTo.TabIndex = 6
        '
        'txtTo
        '
        Me.txtTo.BackColor = System.Drawing.SystemColors.Window
        Me.txtTo.Location = New System.Drawing.Point(426, 113)
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Size = New System.Drawing.Size(159, 22)
        Me.txtTo.TabIndex = 4
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(383, 182)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(21, 12)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "To "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(383, 149)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(21, 12)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "To "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(383, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(21, 12)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "To "
        '
        'txtBatNo
        '
        Me.txtBatNo.BackColor = System.Drawing.SystemColors.Window
        Me.txtBatNo.Enabled = False
        Me.txtBatNo.Location = New System.Drawing.Point(190, 207)
        Me.txtBatNo.Name = "txtBatNo"
        Me.txtBatNo.ReadOnly = True
        Me.txtBatNo.Size = New System.Drawing.Size(159, 22)
        Me.txtBatNo.TabIndex = 9
        '
        'txtRunNoFm
        '
        Me.txtRunNoFm.BackColor = System.Drawing.SystemColors.Window
        Me.txtRunNoFm.Location = New System.Drawing.Point(190, 179)
        Me.txtRunNoFm.Name = "txtRunNoFm"
        Me.txtRunNoFm.Size = New System.Drawing.Size(159, 22)
        Me.txtRunNoFm.TabIndex = 7
        '
        'txtPOFm
        '
        Me.txtPOFm.BackColor = System.Drawing.SystemColors.Window
        Me.txtPOFm.Location = New System.Drawing.Point(190, 146)
        Me.txtPOFm.Name = "txtPOFm"
        Me.txtPOFm.Size = New System.Drawing.Size(159, 22)
        Me.txtPOFm.TabIndex = 5
        '
        'txtFm
        '
        Me.txtFm.BackColor = System.Drawing.SystemColors.Window
        Me.txtFm.Location = New System.Drawing.Point(190, 113)
        Me.txtFm.Name = "txtFm"
        Me.txtFm.Size = New System.Drawing.Size(159, 22)
        Me.txtFm.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 210)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(68, 12)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Batch Job No"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 182)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 12)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Running No"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 149)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 12)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "PO No From"
        '
        'lblbomNoFm
        '
        Me.lblbomNoFm.AutoSize = True
        Me.lblbomNoFm.Location = New System.Drawing.Point(12, 116)
        Me.lblbomNoFm.Name = "lblbomNoFm"
        Me.lblbomNoFm.Size = New System.Drawing.Size(69, 12)
        Me.lblbomNoFm.TabIndex = 0
        Me.lblbomNoFm.Text = "Job No  From"
        '
        'optSAP
        '
        Me.optSAP.AutoSize = True
        Me.optSAP.Enabled = False
        Me.optSAP.Location = New System.Drawing.Point(198, 3)
        Me.optSAP.Name = "optSAP"
        Me.optSAP.Size = New System.Drawing.Size(165, 16)
        Me.optSAP.TabIndex = 2
        Me.optSAP.TabStop = True
        Me.optSAP.Text = "SAP Items (Factory A, B && U)"
        Me.optSAP.UseVisualStyleBackColor = True
        '
        'optALL
        '
        Me.optALL.AutoSize = True
        Me.optALL.Checked = True
        Me.optALL.Enabled = False
        Me.optALL.Location = New System.Drawing.Point(3, 3)
        Me.optALL.Name = "optALL"
        Me.optALL.Size = New System.Drawing.Size(65, 16)
        Me.optALL.TabIndex = 1
        Me.optALL.TabStop = True
        Me.optALL.Text = "All Items"
        Me.optALL.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 298)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 12)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Items Selection"
        '
        'optGroupN
        '
        Me.optGroupN.AutoSize = True
        Me.optGroupN.Enabled = False
        Me.optGroupN.Location = New System.Drawing.Point(198, 2)
        Me.optGroupN.Name = "optGroupN"
        Me.optGroupN.Size = New System.Drawing.Size(37, 16)
        Me.optGroupN.TabIndex = 2
        Me.optGroupN.TabStop = True
        Me.optGroupN.Text = "No"
        Me.optGroupN.UseVisualStyleBackColor = True
        '
        'optGroupY
        '
        Me.optGroupY.AutoSize = True
        Me.optGroupY.Checked = True
        Me.optGroupY.Enabled = False
        Me.optGroupY.Location = New System.Drawing.Point(3, 3)
        Me.optGroupY.Name = "optGroupY"
        Me.optGroupY.Size = New System.Drawing.Size(40, 16)
        Me.optGroupY.TabIndex = 1
        Me.optGroupY.TabStop = True
        Me.optGroupY.Text = "Yes"
        Me.optGroupY.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 242)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(160, 12)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Group The New Format Item No."
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.SystemColors.MenuBar
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.ForeColor = System.Drawing.Color.DimGray
        Me.txtCoNam.Location = New System.Drawing.Point(275, 39)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.ReadOnly = True
        Me.txtCoNam.Size = New System.Drawing.Size(310, 22)
        Me.txtCoNam.TabIndex = 22
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(142, 116)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 12)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "From"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(142, 149)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 12)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "From"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(142, 182)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(30, 12)
        Me.Label14.TabIndex = 25
        Me.Label14.Text = "From"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.optJob)
        Me.Panel1.Controls.Add(Me.optPO)
        Me.Panel1.Controls.Add(Me.optBat)
        Me.Panel1.Controls.Add(Me.optRunNo)
        Me.Panel1.Location = New System.Drawing.Point(188, 86)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(399, 21)
        Me.Panel1.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.optGroupY)
        Me.Panel2.Controls.Add(Me.optGroupN)
        Me.Panel2.Location = New System.Drawing.Point(188, 240)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(399, 21)
        Me.Panel2.TabIndex = 10
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.optALL)
        Me.Panel3.Controls.Add(Me.optSAP)
        Me.Panel3.Location = New System.Drawing.Point(188, 293)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(399, 21)
        Me.Panel3.TabIndex = 12
        '
        'POR00005
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 412)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboReportFormat)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblReportFormat)
        Me.Controls.Add(Me.txtBatNo)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtRunNoTo)
        Me.Controls.Add(Me.txtPOTo)
        Me.Controls.Add(Me.txtRunNoFm)
        Me.Controls.Add(Me.txtTo)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtPOFm)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFm)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblRptName)
        Me.Controls.Add(Me.lblbomNoFm)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "POR00005"
        Me.Text = "POR00005 - Print Production Note (Job Order) (POR05)"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblRptName As System.Windows.Forms.Label
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents cboReportFormat As System.Windows.Forms.ComboBox
    Friend WithEvents lblReportFormat As System.Windows.Forms.Label
    Friend WithEvents txtTo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFm As System.Windows.Forms.TextBox
    Friend WithEvents lblbomNoFm As System.Windows.Forms.Label
    Friend WithEvents optSAP As System.Windows.Forms.RadioButton
    Friend WithEvents optALL As System.Windows.Forms.RadioButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
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
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
End Class
