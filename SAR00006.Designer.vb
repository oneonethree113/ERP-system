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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SAR00006))
        Me.lblRptName = New System.Windows.Forms.Label
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboReportFormat = New System.Windows.Forms.ComboBox
        Me.lblReportFormat = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.optExtVenNotShow = New System.Windows.Forms.RadioButton
        Me.optExtVenShow = New System.Windows.Forms.RadioButton
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.optSortItmNo = New System.Windows.Forms.RadioButton
        Me.optSortSeq = New System.Windows.Forms.RadioButton
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtTo = New System.Windows.Forms.TextBox
        Me.lblTo = New System.Windows.Forms.Label
        Me.txtFm = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblNoFm = New System.Windows.Forms.Label
        Me.cmdShow = New System.Windows.Forms.Button
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblRptName
        '
        Me.lblRptName.AutoSize = True
        Me.lblRptName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.lblRptName.ForeColor = System.Drawing.Color.Blue
        Me.lblRptName.Location = New System.Drawing.Point(221, 12)
        Me.lblRptName.Name = "lblRptName"
        Me.lblRptName.Size = New System.Drawing.Size(210, 24)
        Me.lblRptName.TabIndex = 1
        Me.lblRptName.Text = "Sample Request Report"
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.Color.White
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.Location = New System.Drawing.Point(324, 43)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.ReadOnly = True
        Me.txtCoNam.Size = New System.Drawing.Size(303, 22)
        Me.txtCoNam.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(231, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 12)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Company Name :"
        '
        'cboCoCde
        '
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(112, 43)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(107, 20)
        Me.cboCoCde.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(13, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 12)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Company Code"
        '
        'cboReportFormat
        '
        Me.cboReportFormat.FormattingEnabled = True
        Me.cboReportFormat.Location = New System.Drawing.Point(160, 214)
        Me.cboReportFormat.Name = "cboReportFormat"
        Me.cboReportFormat.Size = New System.Drawing.Size(466, 20)
        Me.cboReportFormat.TabIndex = 2
        Me.cboReportFormat.Text = "Sample Request Report Format"
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
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.optExtVenNotShow)
        Me.GroupBox4.Controls.Add(Me.optExtVenShow)
        Me.GroupBox4.Location = New System.Drawing.Point(160, 134)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox4.Size = New System.Drawing.Size(467, 30)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
        '
        'optExtVenNotShow
        '
        Me.optExtVenNotShow.AutoSize = True
        Me.optExtVenNotShow.Checked = True
        Me.optExtVenNotShow.Location = New System.Drawing.Point(281, 10)
        Me.optExtVenNotShow.Name = "optExtVenNotShow"
        Me.optExtVenNotShow.Size = New System.Drawing.Size(69, 16)
        Me.optExtVenNotShow.TabIndex = 2
        Me.optExtVenNotShow.TabStop = True
        Me.optExtVenNotShow.Text = "Not Show"
        Me.optExtVenNotShow.UseVisualStyleBackColor = True
        '
        'optExtVenShow
        '
        Me.optExtVenShow.AutoSize = True
        Me.optExtVenShow.Location = New System.Drawing.Point(78, 10)
        Me.optExtVenShow.Name = "optExtVenShow"
        Me.optExtVenShow.Size = New System.Drawing.Size(49, 16)
        Me.optExtVenShow.TabIndex = 1
        Me.optExtVenShow.Text = "Show"
        Me.optExtVenShow.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 146)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(130, 12)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Ext. Vendor Contact Info :"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.optSortItmNo)
        Me.GroupBox3.Controls.Add(Me.optSortSeq)
        Me.GroupBox3.Location = New System.Drawing.Point(160, 104)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox3.Size = New System.Drawing.Size(467, 30)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        '
        'optSortItmNo
        '
        Me.optSortItmNo.AutoSize = True
        Me.optSortItmNo.Location = New System.Drawing.Point(281, 10)
        Me.optSortItmNo.Name = "optSortItmNo"
        Me.optSortItmNo.Size = New System.Drawing.Size(85, 16)
        Me.optSortItmNo.TabIndex = 3
        Me.optSortItmNo.Text = "Item Number"
        Me.optSortItmNo.UseVisualStyleBackColor = True
        '
        'optSortSeq
        '
        Me.optSortSeq.AutoSize = True
        Me.optSortSeq.Checked = True
        Me.optSortSeq.Location = New System.Drawing.Point(78, 10)
        Me.optSortSeq.Name = "optSortSeq"
        Me.optSortSeq.Size = New System.Drawing.Size(84, 16)
        Me.optSortSeq.TabIndex = 2
        Me.optSortSeq.TabStop = True
        Me.optSortSeq.Text = "Sequence No"
        Me.optSortSeq.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 114)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 12)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Sort By :"
        '
        'txtTo
        '
        Me.txtTo.Location = New System.Drawing.Point(453, 78)
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Size = New System.Drawing.Size(174, 22)
        Me.txtTo.TabIndex = 4
        '
        'lblTo
        '
        Me.lblTo.AutoSize = True
        Me.lblTo.Location = New System.Drawing.Point(402, 83)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(27, 12)
        Me.lblTo.TabIndex = 3
        Me.lblTo.Text = "To : "
        '
        'txtFm
        '
        Me.txtFm.Location = New System.Drawing.Point(219, 78)
        Me.txtFm.Name = "txtFm"
        Me.txtFm.Size = New System.Drawing.Size(174, 22)
        Me.txtFm.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(158, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 12)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "From :"
        '
        'lblNoFm
        '
        Me.lblNoFm.AutoSize = True
        Me.lblNoFm.Location = New System.Drawing.Point(13, 82)
        Me.lblNoFm.Name = "lblNoFm"
        Me.lblNoFm.Size = New System.Drawing.Size(62, 12)
        Me.lblNoFm.TabIndex = 0
        Me.lblNoFm.Text = "Request No."
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(259, 244)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(140, 22)
        Me.cmdShow.TabIndex = 8
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'SAR00006
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 271)
        Me.Controls.Add(Me.txtTo)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblTo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.txtFm)
        Me.Controls.Add(Me.cboReportFormat)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblNoFm)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.lblReportFormat)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblRptName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "SAR00006"
        Me.Text = "SAR00006 - Sample Request Report (SAR06)"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblRptName As System.Windows.Forms.Label
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents cboReportFormat As System.Windows.Forms.ComboBox
    Friend WithEvents lblReportFormat As System.Windows.Forms.Label
    Friend WithEvents optExtVenNotShow As System.Windows.Forms.RadioButton
    Friend WithEvents optExtVenShow As System.Windows.Forms.RadioButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents optSortItmNo As System.Windows.Forms.RadioButton
    Friend WithEvents optSortSeq As System.Windows.Forms.RadioButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTo As System.Windows.Forms.TextBox
    Friend WithEvents lblTo As System.Windows.Forms.Label
    Friend WithEvents txtFm As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblNoFm As System.Windows.Forms.Label
End Class
