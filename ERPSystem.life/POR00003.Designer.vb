<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class POR00003
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(POR00003))
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblRptName = New System.Windows.Forms.Label
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.rdbRevisedY = New System.Windows.Forms.RadioButton
        Me.Label7 = New System.Windows.Forms.Label
        Me.OptSupN = New System.Windows.Forms.RadioButton
        Me.OptSupY = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboReportFormat = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtTo = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtFm = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdShow = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.Color.White
        Me.txtCoNam.Location = New System.Drawing.Point(281, 48)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.ReadOnly = True
        Me.txtCoNam.Size = New System.Drawing.Size(319, 22)
        Me.txtCoNam.TabIndex = 2
        '
        'cboCoCde
        '
        Me.cboCoCde.BackColor = System.Drawing.Color.White
        Me.cboCoCde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(98, 48)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(76, 20)
        Me.cboCoCde.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(188, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 12)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Company Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(13, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 12)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Company Code"
        '
        'lblRptName
        '
        Me.lblRptName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRptName.ForeColor = System.Drawing.Color.Blue
        Me.lblRptName.Location = New System.Drawing.Point(12, 13)
        Me.lblRptName.Name = "lblRptName"
        Me.lblRptName.Size = New System.Drawing.Size(610, 24)
        Me.lblRptName.TabIndex = 14
        Me.lblRptName.Text = "BOM Purchase Order"
        Me.lblRptName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(257, 3)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(37, 16)
        Me.RadioButton1.TabIndex = 6
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "No"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'rdbRevisedY
        '
        Me.rdbRevisedY.AutoSize = True
        Me.rdbRevisedY.Location = New System.Drawing.Point(3, 2)
        Me.rdbRevisedY.Name = "rdbRevisedY"
        Me.rdbRevisedY.Size = New System.Drawing.Size(40, 16)
        Me.rdbRevisedY.TabIndex = 5
        Me.rdbRevisedY.Text = "Yes"
        Me.rdbRevisedY.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 137)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 12)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Revised"
        '
        'OptSupN
        '
        Me.OptSupN.AutoSize = True
        Me.OptSupN.Location = New System.Drawing.Point(257, 3)
        Me.OptSupN.Name = "OptSupN"
        Me.OptSupN.Size = New System.Drawing.Size(37, 16)
        Me.OptSupN.TabIndex = 6
        Me.OptSupN.TabStop = True
        Me.OptSupN.Text = "No"
        Me.OptSupN.UseVisualStyleBackColor = True
        '
        'OptSupY
        '
        Me.OptSupY.AutoSize = True
        Me.OptSupY.Checked = True
        Me.OptSupY.Location = New System.Drawing.Point(3, 3)
        Me.OptSupY.Name = "OptSupY"
        Me.OptSupY.Size = New System.Drawing.Size(40, 16)
        Me.OptSupY.TabIndex = 5
        Me.OptSupY.TabStop = True
        Me.OptSupY.Text = "Yes"
        Me.OptSupY.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Suppress ZERO Qty"
        '
        'cboReportFormat
        '
        Me.cboReportFormat.BackColor = System.Drawing.Color.White
        Me.cboReportFormat.FormattingEnabled = True
        Me.cboReportFormat.Location = New System.Drawing.Point(190, 212)
        Me.cboReportFormat.Name = "cboReportFormat"
        Me.cboReportFormat.Size = New System.Drawing.Size(410, 20)
        Me.cboReportFormat.TabIndex = 7
        Me.cboReportFormat.Text = "Standard Format"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 215)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 12)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Report Format "
        '
        'txtTo
        '
        Me.txtTo.BackColor = System.Drawing.Color.White
        Me.txtTo.Location = New System.Drawing.Point(444, 168)
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Size = New System.Drawing.Size(156, 22)
        Me.txtTo.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(407, 174)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(21, 12)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "To "
        '
        'txtFm
        '
        Me.txtFm.BackColor = System.Drawing.Color.White
        Me.txtFm.Location = New System.Drawing.Point(190, 168)
        Me.txtFm.Name = "txtFm"
        Me.txtFm.Size = New System.Drawing.Size(156, 22)
        Me.txtFm.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 174)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 12)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "BOM No. "
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(257, 282)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(116, 40)
        Me.cmdShow.TabIndex = 8
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(144, 174)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 12)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "From"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.OptSupY)
        Me.Panel1.Controls.Add(Me.OptSupN)
        Me.Panel1.Location = New System.Drawing.Point(188, 87)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(412, 21)
        Me.Panel1.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rdbRevisedY)
        Me.Panel2.Controls.Add(Me.RadioButton1)
        Me.Panel2.Location = New System.Drawing.Point(188, 128)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(412, 21)
        Me.Panel2.TabIndex = 4
        '
        'POR00003
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 412)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTo)
        Me.Controls.Add(Me.cboReportFormat)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtFm)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblRptName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "POR00003"
        Me.Text = "POR00003 - BOM Purchase Order (POR03)"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblRptName As System.Windows.Forms.Label
    Friend WithEvents cboReportFormat As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFm As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents OptSupN As System.Windows.Forms.RadioButton
    Friend WithEvents OptSupY As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents rdbRevisedY As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
End Class
