<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SAR00007
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
        Me.lblRptName = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.cboReportFormat = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.lblReportFormat = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtTo = New System.Windows.Forms.TextBox
        Me.lblTo = New System.Windows.Forms.Label
        Me.txtFm = New System.Windows.Forms.TextBox
        Me.lblNoFm = New System.Windows.Forms.Label
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdShow = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblRptName
        '
        Me.lblRptName.AutoSize = True
        Me.lblRptName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRptName.ForeColor = System.Drawing.Color.Blue
        Me.lblRptName.Location = New System.Drawing.Point(237, 11)
        Me.lblRptName.Name = "lblRptName"
        Me.lblRptName.Size = New System.Drawing.Size(170, 24)
        Me.lblRptName.TabIndex = 11
        Me.lblRptName.Text = "Packing List Report"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(37, 82)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(567, 142)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " Input Criteria "
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cboReportFormat)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.lblReportFormat)
        Me.GroupBox5.Location = New System.Drawing.Point(26, 75)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox5.Size = New System.Drawing.Size(517, 54)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        '
        'cboReportFormat
        '
        Me.cboReportFormat.BackColor = System.Drawing.Color.White
        Me.cboReportFormat.FormattingEnabled = True
        Me.cboReportFormat.Location = New System.Drawing.Point(140, 20)
        Me.cboReportFormat.Name = "cboReportFormat"
        Me.cboReportFormat.Size = New System.Drawing.Size(268, 21)
        Me.cboReportFormat.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(118, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(13, 13)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = " :"
        '
        'lblReportFormat
        '
        Me.lblReportFormat.AutoSize = True
        Me.lblReportFormat.Location = New System.Drawing.Point(29, 22)
        Me.lblReportFormat.Name = "lblReportFormat"
        Me.lblReportFormat.Size = New System.Drawing.Size(74, 13)
        Me.lblReportFormat.TabIndex = 0
        Me.lblReportFormat.Text = "Report Format"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtTo)
        Me.GroupBox2.Controls.Add(Me.lblTo)
        Me.GroupBox2.Controls.Add(Me.txtFm)
        Me.GroupBox2.Controls.Add(Me.lblNoFm)
        Me.GroupBox2.Location = New System.Drawing.Point(26, 18)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox2.Size = New System.Drawing.Size(517, 54)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'txtTo
        '
        Me.txtTo.BackColor = System.Drawing.Color.White
        Me.txtTo.Location = New System.Drawing.Point(352, 21)
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Size = New System.Drawing.Size(100, 20)
        Me.txtTo.TabIndex = 4
        '
        'lblTo
        '
        Me.lblTo.AutoSize = True
        Me.lblTo.Location = New System.Drawing.Point(307, 24)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(29, 13)
        Me.lblTo.TabIndex = 3
        Me.lblTo.Text = "To : "
        '
        'txtFm
        '
        Me.txtFm.BackColor = System.Drawing.Color.White
        Me.txtFm.Location = New System.Drawing.Point(140, 21)
        Me.txtFm.Name = "txtFm"
        Me.txtFm.Size = New System.Drawing.Size(100, 20)
        Me.txtFm.TabIndex = 2
        '
        'lblNoFm
        '
        Me.lblNoFm.AutoSize = True
        Me.lblNoFm.Location = New System.Drawing.Point(30, 24)
        Me.lblNoFm.Name = "lblNoFm"
        Me.lblNoFm.Size = New System.Drawing.Size(100, 13)
        Me.lblNoFm.TabIndex = 0
        Me.lblNoFm.Text = "Invoice No.   From :"
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.Color.White
        Me.txtCoNam.Location = New System.Drawing.Point(325, 45)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.ReadOnly = True
        Me.txtCoNam.Size = New System.Drawing.Size(303, 20)
        Me.txtCoNam.TabIndex = 15
        Me.txtCoNam.Text = "United Chinese Plastics Products Co., Ltd."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(231, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Company Name :"
        '
        'cboCoCde
        '
        Me.cboCoCde.BackColor = System.Drawing.Color.White
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(100, 45)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(121, 21)
        Me.cboCoCde.TabIndex = 13
        Me.cboCoCde.Text = "UCPP"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(15, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Company Code"
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(259, 228)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(140, 47)
        Me.cmdShow.TabIndex = 17
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'SAR00007
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(642, 286)
        Me.Controls.Add(Me.lblRptName)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdShow)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(650, 320)
        Me.MinimumSize = New System.Drawing.Size(650, 320)
        Me.Name = "SAR00007"
        Me.Text = "Packing List Report (SAR00007)"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblRptName As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents cboReportFormat As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblReportFormat As System.Windows.Forms.Label
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTo As System.Windows.Forms.TextBox
    Friend WithEvents lblTo As System.Windows.Forms.Label
    Friend WithEvents txtFm As System.Windows.Forms.TextBox
    Friend WithEvents lblNoFm As System.Windows.Forms.Label
End Class
