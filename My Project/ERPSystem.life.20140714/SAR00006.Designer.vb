<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SAR00006
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
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.cboReportFormat = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.lblReportFormat = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.optExtVenNotShow = New System.Windows.Forms.RadioButton
        Me.optExtVenShow = New System.Windows.Forms.RadioButton
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.optSortItmNo = New System.Windows.Forms.RadioButton
        Me.optSortSeq = New System.Windows.Forms.RadioButton
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtTo = New System.Windows.Forms.TextBox
        Me.lblTo = New System.Windows.Forms.Label
        Me.txtFm = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblNoFm = New System.Windows.Forms.Label
        Me.cmdShow = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblRptName
        '
        Me.lblRptName.AutoSize = True
        Me.lblRptName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRptName.ForeColor = System.Drawing.Color.Blue
        Me.lblRptName.Location = New System.Drawing.Point(220, 14)
        Me.lblRptName.Name = "lblRptName"
        Me.lblRptName.Size = New System.Drawing.Size(210, 24)
        Me.lblRptName.TabIndex = 1
        Me.lblRptName.Text = "Sample Request Report"
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.Color.White
        Me.txtCoNam.Location = New System.Drawing.Point(327, 45)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.ReadOnly = True
        Me.txtCoNam.Size = New System.Drawing.Size(303, 20)
        Me.txtCoNam.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(233, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Company Name :"
        '
        'cboCoCde
        '
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(102, 45)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(121, 21)
        Me.cboCoCde.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(17, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Company Code"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(39, 72)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(567, 172)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " Input Criteria "
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cboReportFormat)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.lblReportFormat)
        Me.GroupBox5.Location = New System.Drawing.Point(26, 124)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox5.Size = New System.Drawing.Size(517, 37)
        Me.GroupBox5.TabIndex = 7
        Me.GroupBox5.TabStop = False
        '
        'cboReportFormat
        '
        Me.cboReportFormat.FormattingEnabled = True
        Me.cboReportFormat.Location = New System.Drawing.Point(190, 11)
        Me.cboReportFormat.Name = "cboReportFormat"
        Me.cboReportFormat.Size = New System.Drawing.Size(230, 21)
        Me.cboReportFormat.TabIndex = 2
        Me.cboReportFormat.Text = "Sample Request Report Format"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(152, 13)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(13, 13)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = " :"
        '
        'lblReportFormat
        '
        Me.lblReportFormat.AutoSize = True
        Me.lblReportFormat.Location = New System.Drawing.Point(29, 13)
        Me.lblReportFormat.Name = "lblReportFormat"
        Me.lblReportFormat.Size = New System.Drawing.Size(74, 13)
        Me.lblReportFormat.TabIndex = 0
        Me.lblReportFormat.Text = "Report Format"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.optExtVenNotShow)
        Me.GroupBox4.Controls.Add(Me.optExtVenShow)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Location = New System.Drawing.Point(26, 87)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox4.Size = New System.Drawing.Size(517, 37)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
        '
        'optExtVenNotShow
        '
        Me.optExtVenNotShow.AutoSize = True
        Me.optExtVenNotShow.Checked = True
        Me.optExtVenNotShow.Location = New System.Drawing.Point(330, 14)
        Me.optExtVenNotShow.Name = "optExtVenNotShow"
        Me.optExtVenNotShow.Size = New System.Drawing.Size(72, 17)
        Me.optExtVenNotShow.TabIndex = 2
        Me.optExtVenNotShow.TabStop = True
        Me.optExtVenNotShow.Text = "Not Show"
        Me.optExtVenNotShow.UseVisualStyleBackColor = True
        '
        'optExtVenShow
        '
        Me.optExtVenShow.AutoSize = True
        Me.optExtVenShow.Location = New System.Drawing.Point(194, 12)
        Me.optExtVenShow.Name = "optExtVenShow"
        Me.optExtVenShow.Size = New System.Drawing.Size(52, 17)
        Me.optExtVenShow.TabIndex = 1
        Me.optExtVenShow.Text = "Show"
        Me.optExtVenShow.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(29, 14)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(135, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Ext. Vendor Contact Info   :"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.optSortItmNo)
        Me.GroupBox3.Controls.Add(Me.optSortSeq)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Location = New System.Drawing.Point(26, 50)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox3.Size = New System.Drawing.Size(517, 37)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        '
        'optSortItmNo
        '
        Me.optSortItmNo.AutoSize = True
        Me.optSortItmNo.Location = New System.Drawing.Point(330, 13)
        Me.optSortItmNo.Name = "optSortItmNo"
        Me.optSortItmNo.Size = New System.Drawing.Size(85, 17)
        Me.optSortItmNo.TabIndex = 3
        Me.optSortItmNo.Text = "Item Number"
        Me.optSortItmNo.UseVisualStyleBackColor = True
        '
        'optSortSeq
        '
        Me.optSortSeq.AutoSize = True
        Me.optSortSeq.Checked = True
        Me.optSortSeq.Location = New System.Drawing.Point(194, 14)
        Me.optSortSeq.Name = "optSortSeq"
        Me.optSortSeq.Size = New System.Drawing.Size(91, 17)
        Me.optSortSeq.TabIndex = 2
        Me.optSortSeq.TabStop = True
        Me.optSortSeq.Text = "Sequence No"
        Me.optSortSeq.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(149, 14)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(13, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = " :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(29, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Sort By"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtTo)
        Me.GroupBox2.Controls.Add(Me.lblTo)
        Me.GroupBox2.Controls.Add(Me.txtFm)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.lblNoFm)
        Me.GroupBox2.Location = New System.Drawing.Point(26, 13)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox2.Size = New System.Drawing.Size(517, 37)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        '
        'txtTo
        '
        Me.txtTo.Location = New System.Drawing.Point(336, 12)
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Size = New System.Drawing.Size(100, 20)
        Me.txtTo.TabIndex = 4
        '
        'lblTo
        '
        Me.lblTo.AutoSize = True
        Me.lblTo.Location = New System.Drawing.Point(301, 15)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(29, 13)
        Me.lblTo.TabIndex = 3
        Me.lblTo.Text = "To : "
        '
        'txtFm
        '
        Me.txtFm.Location = New System.Drawing.Point(171, 12)
        Me.txtFm.Name = "txtFm"
        Me.txtFm.Size = New System.Drawing.Size(100, 20)
        Me.txtFm.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(123, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = " From :"
        '
        'lblNoFm
        '
        Me.lblNoFm.AutoSize = True
        Me.lblNoFm.Location = New System.Drawing.Point(29, 17)
        Me.lblNoFm.Name = "lblNoFm"
        Me.lblNoFm.Size = New System.Drawing.Size(67, 13)
        Me.lblNoFm.TabIndex = 0
        Me.lblNoFm.Text = "Request No."
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(269, 248)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(140, 34)
        Me.cmdShow.TabIndex = 8
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'SAR00006
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(642, 286)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblRptName)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(650, 320)
        Me.MinimumSize = New System.Drawing.Size(650, 320)
        Me.Name = "SAR00006"
        Me.Text = "Sample Request Report (SAR00006)"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblRptName As System.Windows.Forms.Label
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents cboReportFormat As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblReportFormat As System.Windows.Forms.Label
    Friend WithEvents optExtVenNotShow As System.Windows.Forms.RadioButton
    Friend WithEvents optExtVenShow As System.Windows.Forms.RadioButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents optSortItmNo As System.Windows.Forms.RadioButton
    Friend WithEvents optSortSeq As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTo As System.Windows.Forms.TextBox
    Friend WithEvents lblTo As System.Windows.Forms.Label
    Friend WithEvents txtFm As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblNoFm As System.Windows.Forms.Label
End Class
