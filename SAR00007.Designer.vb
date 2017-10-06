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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SAR00007))
        Me.lblRptName = New System.Windows.Forms.Label
        Me.cboReportFormat = New System.Windows.Forms.ComboBox
        Me.lblReportFormat = New System.Windows.Forms.Label
        Me.txtTo = New System.Windows.Forms.TextBox
        Me.lblTo = New System.Windows.Forms.Label
        Me.txtFm = New System.Windows.Forms.TextBox
        Me.lblNoFm = New System.Windows.Forms.Label
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdShow = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lblRptName
        '
        Me.lblRptName.AutoSize = True
        Me.lblRptName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.lblRptName.ForeColor = System.Drawing.Color.Blue
        Me.lblRptName.Location = New System.Drawing.Point(229, 12)
        Me.lblRptName.Name = "lblRptName"
        Me.lblRptName.Size = New System.Drawing.Size(170, 24)
        Me.lblRptName.TabIndex = 11
        Me.lblRptName.Text = "Packing List Report"
        '
        'cboReportFormat
        '
        Me.cboReportFormat.BackColor = System.Drawing.Color.White
        Me.cboReportFormat.FormattingEnabled = True
        Me.cboReportFormat.Location = New System.Drawing.Point(160, 214)
        Me.cboReportFormat.Name = "cboReportFormat"
        Me.cboReportFormat.Size = New System.Drawing.Size(467, 20)
        Me.cboReportFormat.TabIndex = 2
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
        'txtTo
        '
        Me.txtTo.BackColor = System.Drawing.Color.White
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
        Me.txtFm.BackColor = System.Drawing.Color.White
        Me.txtFm.Location = New System.Drawing.Point(219, 78)
        Me.txtFm.Name = "txtFm"
        Me.txtFm.Size = New System.Drawing.Size(174, 22)
        Me.txtFm.TabIndex = 2
        '
        'lblNoFm
        '
        Me.lblNoFm.AutoSize = True
        Me.lblNoFm.Location = New System.Drawing.Point(13, 82)
        Me.lblNoFm.Name = "lblNoFm"
        Me.lblNoFm.Size = New System.Drawing.Size(60, 12)
        Me.lblNoFm.TabIndex = 0
        Me.lblNoFm.Text = "Invoice No."
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.Color.White
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.Location = New System.Drawing.Point(324, 43)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.ReadOnly = True
        Me.txtCoNam.Size = New System.Drawing.Size(303, 22)
        Me.txtCoNam.TabIndex = 15
        Me.txtCoNam.Text = "United Chinese Plastics Products Co., Ltd."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(231, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 12)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Company Name :"
        '
        'cboCoCde
        '
        Me.cboCoCde.BackColor = System.Drawing.Color.White
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(112, 43)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(107, 20)
        Me.cboCoCde.TabIndex = 13
        Me.cboCoCde.Text = "UCPP"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(13, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 12)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Company Code"
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(259, 244)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(140, 22)
        Me.cmdShow.TabIndex = 17
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(158, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 12)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "From :"
        '
        'SAR00007
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(634, 271)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboReportFormat)
        Me.Controls.Add(Me.txtTo)
        Me.Controls.Add(Me.lblTo)
        Me.Controls.Add(Me.lblReportFormat)
        Me.Controls.Add(Me.lblRptName)
        Me.Controls.Add(Me.txtFm)
        Me.Controls.Add(Me.lblNoFm)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdShow)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "SAR00007"
        Me.Text = "SAR00007 - Packing List Report (SAR07)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblRptName As System.Windows.Forms.Label
    Friend WithEvents cboReportFormat As System.Windows.Forms.ComboBox
    Friend WithEvents lblReportFormat As System.Windows.Forms.Label
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents txtTo As System.Windows.Forms.TextBox
    Friend WithEvents lblTo As System.Windows.Forms.Label
    Friend WithEvents txtFm As System.Windows.Forms.TextBox
    Friend WithEvents lblNoFm As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
