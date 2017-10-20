<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SAR00005
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SAR00005))
        Me.lblRptName = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.optGroupYes = New System.Windows.Forms.RadioButton
        Me.optGroupNo = New System.Windows.Forms.RadioButton
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.optAliasNo = New System.Windows.Forms.RadioButton
        Me.optAliasYes = New System.Windows.Forms.RadioButton
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboReportFormat = New System.Windows.Forms.ComboBox
        Me.lblReportFormat = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtTo = New System.Windows.Forms.TextBox
        Me.lblTo = New System.Windows.Forms.Label
        Me.txtFm = New System.Windows.Forms.TextBox
        Me.lblNoFm = New System.Windows.Forms.Label
        Me.cmdShow = New System.Windows.Forms.Button
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblRptName
        '
        Me.lblRptName.AutoSize = True
        Me.lblRptName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.lblRptName.ForeColor = System.Drawing.Color.Blue
        Me.lblRptName.Location = New System.Drawing.Point(221, 12)
        Me.lblRptName.Name = "lblRptName"
        Me.lblRptName.Size = New System.Drawing.Size(200, 24)
        Me.lblRptName.TabIndex = 0
        Me.lblRptName.Text = "Sample Invoice Report"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(13, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Company Code"
        '
        'cboCoCde
        '
        Me.cboCoCde.BackColor = System.Drawing.Color.White
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(112, 43)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(107, 20)
        Me.cboCoCde.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(231, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 12)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Company Name :"
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.Color.White
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.Location = New System.Drawing.Point(324, 43)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.ReadOnly = True
        Me.txtCoNam.Size = New System.Drawing.Size(302, 22)
        Me.txtCoNam.TabIndex = 4
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.optGroupYes)
        Me.GroupBox5.Controls.Add(Me.optGroupNo)
        Me.GroupBox5.Location = New System.Drawing.Point(160, 104)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(466, 30)
        Me.GroupBox5.TabIndex = 4
        Me.GroupBox5.TabStop = False
        '
        'optGroupYes
        '
        Me.optGroupYes.AutoSize = True
        Me.optGroupYes.Checked = True
        Me.optGroupYes.Location = New System.Drawing.Point(78, 10)
        Me.optGroupYes.Name = "optGroupYes"
        Me.optGroupYes.Size = New System.Drawing.Size(40, 16)
        Me.optGroupYes.TabIndex = 1
        Me.optGroupYes.TabStop = True
        Me.optGroupYes.Text = "Yes"
        Me.optGroupYes.UseVisualStyleBackColor = True
        '
        'optGroupNo
        '
        Me.optGroupNo.AutoSize = True
        Me.optGroupNo.Location = New System.Drawing.Point(281, 10)
        Me.optGroupNo.Name = "optGroupNo"
        Me.optGroupNo.Size = New System.Drawing.Size(37, 16)
        Me.optGroupNo.TabIndex = 2
        Me.optGroupNo.Text = "No"
        Me.optGroupNo.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 146)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(146, 12)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Group The New Format Item :"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.optAliasNo)
        Me.GroupBox6.Controls.Add(Me.optAliasYes)
        Me.GroupBox6.Location = New System.Drawing.Point(160, 134)
        Me.GroupBox6.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(466, 30)
        Me.GroupBox6.TabIndex = 5
        Me.GroupBox6.TabStop = False
        '
        'optAliasNo
        '
        Me.optAliasNo.AutoSize = True
        Me.optAliasNo.Location = New System.Drawing.Point(281, 11)
        Me.optAliasNo.Name = "optAliasNo"
        Me.optAliasNo.Size = New System.Drawing.Size(37, 16)
        Me.optAliasNo.TabIndex = 7
        Me.optAliasNo.Text = "No"
        Me.optAliasNo.UseVisualStyleBackColor = True
        '
        'optAliasYes
        '
        Me.optAliasYes.AutoSize = True
        Me.optAliasYes.Checked = True
        Me.optAliasYes.Location = New System.Drawing.Point(78, 11)
        Me.optAliasYes.Name = "optAliasYes"
        Me.optAliasYes.Size = New System.Drawing.Size(40, 16)
        Me.optAliasYes.TabIndex = 6
        Me.optAliasYes.TabStop = True
        Me.optAliasYes.Text = "Yes"
        Me.optAliasYes.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 114)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 12)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Print Alias No. :"
        '
        'cboReportFormat
        '
        Me.cboReportFormat.BackColor = System.Drawing.Color.White
        Me.cboReportFormat.FormattingEnabled = True
        Me.cboReportFormat.Location = New System.Drawing.Point(160, 214)
        Me.cboReportFormat.Name = "cboReportFormat"
        Me.cboReportFormat.Size = New System.Drawing.Size(466, 20)
        Me.cboReportFormat.TabIndex = 1
        Me.cboReportFormat.Text = "Sample Invoice Standard Format"
        '
        'lblReportFormat
        '
        Me.lblReportFormat.AutoSize = True
        Me.lblReportFormat.Location = New System.Drawing.Point(13, 216)
        Me.lblReportFormat.Name = "lblReportFormat"
        Me.lblReportFormat.Size = New System.Drawing.Size(79, 12)
        Me.lblReportFormat.TabIndex = 0
        Me.lblReportFormat.Text = "Report Format :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(158, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 12)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "From :"
        '
        'txtTo
        '
        Me.txtTo.BackColor = System.Drawing.Color.White
        Me.txtTo.Location = New System.Drawing.Point(453, 78)
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Size = New System.Drawing.Size(174, 22)
        Me.txtTo.TabIndex = 3
        '
        'lblTo
        '
        Me.lblTo.AutoSize = True
        Me.lblTo.Location = New System.Drawing.Point(402, 83)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(27, 12)
        Me.lblTo.TabIndex = 2
        Me.lblTo.Text = "To : "
        '
        'txtFm
        '
        Me.txtFm.BackColor = System.Drawing.Color.White
        Me.txtFm.Location = New System.Drawing.Point(219, 78)
        Me.txtFm.Name = "txtFm"
        Me.txtFm.Size = New System.Drawing.Size(174, 22)
        Me.txtFm.TabIndex = 1
        '
        'lblNoFm
        '
        Me.lblNoFm.AutoSize = True
        Me.lblNoFm.Location = New System.Drawing.Point(13, 82)
        Me.lblNoFm.Name = "lblNoFm"
        Me.lblNoFm.Size = New System.Drawing.Size(63, 12)
        Me.lblNoFm.TabIndex = 0
        Me.lblNoFm.Text = "Invoice No. "
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(259, 244)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(140, 22)
        Me.cmdShow.TabIndex = 3
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'SAR00005
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 271)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.txtTo)
        Me.Controls.Add(Me.cboReportFormat)
        Me.Controls.Add(Me.lblTo)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.txtFm)
        Me.Controls.Add(Me.lblReportFormat)
        Me.Controls.Add(Me.lblNoFm)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblRptName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "SAR00005"
        Me.Text = "SAR00005 - Sample Invoice Report (SAR05)"
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblRptName As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents optGroupNo As System.Windows.Forms.RadioButton
    Friend WithEvents optGroupYes As System.Windows.Forms.RadioButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTo As System.Windows.Forms.TextBox
    Friend WithEvents lblTo As System.Windows.Forms.Label
    Friend WithEvents txtFm As System.Windows.Forms.TextBox
    Friend WithEvents lblNoFm As System.Windows.Forms.Label
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents cboReportFormat As System.Windows.Forms.ComboBox
    Friend WithEvents lblReportFormat As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents optAliasNo As System.Windows.Forms.RadioButton
    Friend WithEvents optAliasYes As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
