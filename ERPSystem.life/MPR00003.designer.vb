<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MPR00003
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MPR00003))
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtGrnNoFm = New System.Windows.Forms.TextBox
        Me.txtGrnNoTo = New System.Windows.Forms.TextBox
        Me.cmdShow = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.optShow = New System.Windows.Forms.RadioButton
        Me.cboDP = New System.Windows.Forms.ComboBox
        Me.Frame2 = New System.Windows.Forms.GroupBox
        Me.optHidden = New System.Windows.Forms.RadioButton
        Me.Frame3 = New System.Windows.Forms.GroupBox
        Me.Frame4 = New System.Windows.Forms.GroupBox
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.cboInvUm = New System.Windows.Forms.ComboBox
        Me.chkPrtGrp = New System.Windows.Forms.CheckBox
        Me.optFormat1 = New System.Windows.Forms.RadioButton
        Me.optFormat0 = New System.Windows.Forms.RadioButton
        Me.cboReport = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Frame4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(377, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(18, 12)
        Me.Label4.TabIndex = 388
        Me.Label4.Text = "To"
        '
        'txtGrnNoFm
        '
        Me.txtGrnNoFm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtGrnNoFm.Location = New System.Drawing.Point(172, 50)
        Me.txtGrnNoFm.MaxLength = 10
        Me.txtGrnNoFm.Name = "txtGrnNoFm"
        Me.txtGrnNoFm.Size = New System.Drawing.Size(193, 20)
        Me.txtGrnNoFm.TabIndex = 0
        '
        'txtGrnNoTo
        '
        Me.txtGrnNoTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtGrnNoTo.Location = New System.Drawing.Point(416, 50)
        Me.txtGrnNoTo.MaxLength = 10
        Me.txtGrnNoTo.Name = "txtGrnNoTo"
        Me.txtGrnNoTo.Size = New System.Drawing.Size(193, 20)
        Me.txtGrnNoTo.TabIndex = 1
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(259, 244)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(140, 22)
        Me.cmdShow.TabIndex = 10
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(124, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 12)
        Me.Label7.TabIndex = 389
        Me.Label7.Text = "From"
        '
        'optShow
        '
        Me.optShow.AutoSize = True
        Me.optShow.Checked = True
        Me.optShow.Location = New System.Drawing.Point(8, 8)
        Me.optShow.Name = "optShow"
        Me.optShow.Size = New System.Drawing.Size(49, 16)
        Me.optShow.TabIndex = 2
        Me.optShow.TabStop = True
        Me.optShow.Text = "Show"
        Me.optShow.UseVisualStyleBackColor = True
        '
        'cboDP
        '
        Me.cboDP.FormattingEnabled = True
        Me.cboDP.Location = New System.Drawing.Point(126, 114)
        Me.cboDP.Name = "cboDP"
        Me.cboDP.Size = New System.Drawing.Size(128, 20)
        Me.cboDP.TabIndex = 4
        '
        'Frame2
        '
        Me.Frame2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Frame2.Location = New System.Drawing.Point(620, 248)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.Size = New System.Drawing.Size(10, 11)
        Me.Frame2.TabIndex = 395
        Me.Frame2.TabStop = False
        Me.Frame2.Visible = False
        '
        'optHidden
        '
        Me.optHidden.AutoSize = True
        Me.optHidden.Location = New System.Drawing.Point(66, 8)
        Me.optHidden.Name = "optHidden"
        Me.optHidden.Size = New System.Drawing.Size(57, 16)
        Me.optHidden.TabIndex = 3
        Me.optHidden.Text = "Hidden"
        Me.optHidden.UseVisualStyleBackColor = True
        '
        'Frame3
        '
        Me.Frame3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Frame3.Location = New System.Drawing.Point(594, 256)
        Me.Frame3.Name = "Frame3"
        Me.Frame3.Size = New System.Drawing.Size(14, 10)
        Me.Frame3.TabIndex = 396
        Me.Frame3.TabStop = False
        Me.Frame3.Text = "Decimal Places"
        Me.Frame3.Visible = False
        '
        'Frame4
        '
        Me.Frame4.Controls.Add(Me.Frame1)
        Me.Frame4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Frame4.Location = New System.Drawing.Point(614, 256)
        Me.Frame4.Name = "Frame4"
        Me.Frame4.Size = New System.Drawing.Size(10, 10)
        Me.Frame4.TabIndex = 397
        Me.Frame4.TabStop = False
        Me.Frame4.Text = "Invoice UM"
        Me.Frame4.Visible = False
        '
        'Frame1
        '
        Me.Frame1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Frame1.Location = New System.Drawing.Point(145, 34)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Size = New System.Drawing.Size(117, 41)
        Me.Frame1.TabIndex = 398
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Report Type"
        Me.Frame1.Visible = False
        '
        'cboInvUm
        '
        Me.cboInvUm.FormattingEnabled = True
        Me.cboInvUm.Location = New System.Drawing.Point(126, 148)
        Me.cboInvUm.Name = "cboInvUm"
        Me.cboInvUm.Size = New System.Drawing.Size(128, 20)
        Me.cboInvUm.TabIndex = 5
        '
        'chkPrtGrp
        '
        Me.chkPrtGrp.AutoSize = True
        Me.chkPrtGrp.Checked = True
        Me.chkPrtGrp.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPrtGrp.Location = New System.Drawing.Point(126, 210)
        Me.chkPrtGrp.Name = "chkPrtGrp"
        Me.chkPrtGrp.Size = New System.Drawing.Size(79, 16)
        Me.chkPrtGrp.TabIndex = 9
        Me.chkPrtGrp.Text = "Print Group"
        Me.chkPrtGrp.UseVisualStyleBackColor = True
        '
        'optFormat1
        '
        Me.optFormat1.AutoSize = True
        Me.optFormat1.Location = New System.Drawing.Point(74, 3)
        Me.optFormat1.Name = "optFormat1"
        Me.optFormat1.Size = New System.Drawing.Size(107, 16)
        Me.optFormat1.TabIndex = 8
        Me.optFormat1.Text = "To Crystal Report"
        Me.optFormat1.UseVisualStyleBackColor = True
        '
        'optFormat0
        '
        Me.optFormat0.AutoSize = True
        Me.optFormat0.Location = New System.Drawing.Point(3, 3)
        Me.optFormat0.Name = "optFormat0"
        Me.optFormat0.Size = New System.Drawing.Size(65, 16)
        Me.optFormat0.TabIndex = 7
        Me.optFormat0.Text = "To Excel"
        Me.optFormat0.UseVisualStyleBackColor = True
        '
        'cboReport
        '
        Me.cboReport.FormattingEnabled = True
        Me.cboReport.Location = New System.Drawing.Point(126, 181)
        Me.cboReport.Name = "cboReport"
        Me.cboReport.Size = New System.Drawing.Size(482, 20)
        Me.cboReport.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 12)
        Me.Label1.TabIndex = 399
        Me.Label1.Text = "GRN No Range"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 12)
        Me.Label2.TabIndex = 400
        Me.Label2.Text = "Unit Price"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.optHidden)
        Me.Panel1.Controls.Add(Me.optShow)
        Me.Panel1.Location = New System.Drawing.Point(118, 76)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(136, 27)
        Me.Panel1.TabIndex = 401
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 117)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 12)
        Me.Label3.TabIndex = 402
        Me.Label3.Text = "Decimal Places"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 151)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 12)
        Me.Label5.TabIndex = 403
        Me.Label5.Text = "Invoice UM"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.optFormat1)
        Me.Panel2.Controls.Add(Me.optFormat0)
        Me.Panel2.Location = New System.Drawing.Point(123, 207)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(215, 27)
        Me.Panel2.TabIndex = 402
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(238, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(191, 22)
        Me.Label8.TabIndex = 405
        Me.Label8.Text = "GRN Transfer Reports"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 184)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 12)
        Me.Label6.TabIndex = 404
        Me.Label6.Text = "Report Type"
        '
        'MPR00003
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 271)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.chkPrtGrp)
        Me.Controls.Add(Me.cboInvUm)
        Me.Controls.Add(Me.cboReport)
        Me.Controls.Add(Me.cboDP)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Frame4)
        Me.Controls.Add(Me.txtGrnNoFm)
        Me.Controls.Add(Me.txtGrnNoTo)
        Me.Controls.Add(Me.Frame3)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MPR00003"
        Me.Text = "MPR00003 - GRN Transfer Reports (MPR03)"
        Me.Frame4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtGrnNoFm As System.Windows.Forms.TextBox
    Friend WithEvents txtGrnNoTo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents optShow As System.Windows.Forms.RadioButton
    Friend WithEvents cboDP As System.Windows.Forms.ComboBox
    Friend WithEvents Frame2 As System.Windows.Forms.GroupBox
    Friend WithEvents optHidden As System.Windows.Forms.RadioButton
    Friend WithEvents Frame3 As System.Windows.Forms.GroupBox
    Friend WithEvents Frame4 As System.Windows.Forms.GroupBox
    Friend WithEvents cboInvUm As System.Windows.Forms.ComboBox
    Friend WithEvents Frame1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboReport As System.Windows.Forms.ComboBox
    Friend WithEvents optFormat1 As System.Windows.Forms.RadioButton
    Friend WithEvents optFormat0 As System.Windows.Forms.RadioButton
    Friend WithEvents chkPrtGrp As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
