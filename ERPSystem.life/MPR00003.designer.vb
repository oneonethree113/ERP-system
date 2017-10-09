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
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtGrnNoFm = New System.Windows.Forms.TextBox
        Me.txtGrnNoTo = New System.Windows.Forms.TextBox
        Me.cmdShow = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.optShow = New System.Windows.Forms.RadioButton
        Me.cboDP = New System.Windows.Forms.ComboBox
        Me.Frame2 = New System.Windows.Forms.GroupBox
        Me.optHidden = New System.Windows.Forms.RadioButton
        Me.Frame3 = New System.Windows.Forms.GroupBox
        Me.Frame4 = New System.Windows.Forms.GroupBox
        Me.cboInvUm = New System.Windows.Forms.ComboBox
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.chkPrtGrp = New System.Windows.Forms.CheckBox
        Me.optFormat1 = New System.Windows.Forms.RadioButton
        Me.optFormat0 = New System.Windows.Forms.RadioButton
        Me.cboReport = New System.Windows.Forms.ComboBox
        Me.GroupBox3.SuspendLayout()
        Me.Frame2.SuspendLayout()
        Me.Frame3.SuspendLayout()
        Me.Frame4.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label4.Location = New System.Drawing.Point(218, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 13)
        Me.Label4.TabIndex = 388
        Me.Label4.Text = "To:"
        '
        'txtGrnNoFm
        '
        Me.txtGrnNoFm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtGrnNoFm.Location = New System.Drawing.Point(63, 22)
        Me.txtGrnNoFm.MaxLength = 10
        Me.txtGrnNoFm.Name = "txtGrnNoFm"
        Me.txtGrnNoFm.Size = New System.Drawing.Size(145, 20)
        Me.txtGrnNoFm.TabIndex = 0
        '
        'txtGrnNoTo
        '
        Me.txtGrnNoTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtGrnNoTo.Location = New System.Drawing.Point(254, 22)
        Me.txtGrnNoTo.MaxLength = 10
        Me.txtGrnNoTo.Name = "txtGrnNoTo"
        Me.txtGrnNoTo.Size = New System.Drawing.Size(145, 20)
        Me.txtGrnNoTo.TabIndex = 1
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(154, 229)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(117, 27)
        Me.cmdShow.TabIndex = 10
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.txtGrnNoFm)
        Me.GroupBox3.Controls.Add(Me.txtGrnNoTo)
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox3.Location = New System.Drawing.Point(9, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(419, 54)
        Me.GroupBox3.TabIndex = 28
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "GRN No Range"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label7.Location = New System.Drawing.Point(15, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 13)
        Me.Label7.TabIndex = 389
        Me.Label7.Text = "From :"
        '
        'optShow
        '
        Me.optShow.AutoSize = True
        Me.optShow.Checked = True
        Me.optShow.Location = New System.Drawing.Point(18, 30)
        Me.optShow.Name = "optShow"
        Me.optShow.Size = New System.Drawing.Size(52, 17)
        Me.optShow.TabIndex = 2
        Me.optShow.TabStop = True
        Me.optShow.Text = "Show"
        Me.optShow.UseVisualStyleBackColor = True
        '
        'cboDP
        '
        Me.cboDP.FormattingEnabled = True
        Me.cboDP.Location = New System.Drawing.Point(6, 26)
        Me.cboDP.Name = "cboDP"
        Me.cboDP.Size = New System.Drawing.Size(84, 21)
        Me.cboDP.TabIndex = 4
        '
        'Frame2
        '
        Me.Frame2.Controls.Add(Me.optHidden)
        Me.Frame2.Controls.Add(Me.optShow)
        Me.Frame2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Frame2.Location = New System.Drawing.Point(9, 64)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.Size = New System.Drawing.Size(146, 58)
        Me.Frame2.TabIndex = 395
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Unit Price"
        '
        'optHidden
        '
        Me.optHidden.AutoSize = True
        Me.optHidden.Location = New System.Drawing.Point(76, 30)
        Me.optHidden.Name = "optHidden"
        Me.optHidden.Size = New System.Drawing.Size(59, 17)
        Me.optHidden.TabIndex = 3
        Me.optHidden.Text = "Hidden"
        Me.optHidden.UseVisualStyleBackColor = True
        '
        'Frame3
        '
        Me.Frame3.Controls.Add(Me.cboDP)
        Me.Frame3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Frame3.Location = New System.Drawing.Point(164, 64)
        Me.Frame3.Name = "Frame3"
        Me.Frame3.Size = New System.Drawing.Size(123, 58)
        Me.Frame3.TabIndex = 396
        Me.Frame3.TabStop = False
        Me.Frame3.Text = "Decimal Places"
        '
        'Frame4
        '
        Me.Frame4.Controls.Add(Me.cboInvUm)
        Me.Frame4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Frame4.Location = New System.Drawing.Point(298, 64)
        Me.Frame4.Name = "Frame4"
        Me.Frame4.Size = New System.Drawing.Size(129, 58)
        Me.Frame4.TabIndex = 397
        Me.Frame4.TabStop = False
        Me.Frame4.Text = "Invoice UM"
        '
        'cboInvUm
        '
        Me.cboInvUm.FormattingEnabled = True
        Me.cboInvUm.Location = New System.Drawing.Point(6, 26)
        Me.cboInvUm.Name = "cboInvUm"
        Me.cboInvUm.Size = New System.Drawing.Size(84, 21)
        Me.cboInvUm.TabIndex = 5
        '
        'Frame1
        '
        Me.Frame1.Controls.Add(Me.chkPrtGrp)
        Me.Frame1.Controls.Add(Me.optFormat1)
        Me.Frame1.Controls.Add(Me.optFormat0)
        Me.Frame1.Controls.Add(Me.cboReport)
        Me.Frame1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Frame1.Location = New System.Drawing.Point(9, 124)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Size = New System.Drawing.Size(416, 86)
        Me.Frame1.TabIndex = 398
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Report Type"
        '
        'chkPrtGrp
        '
        Me.chkPrtGrp.AutoSize = True
        Me.chkPrtGrp.Checked = True
        Me.chkPrtGrp.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPrtGrp.Location = New System.Drawing.Point(304, 61)
        Me.chkPrtGrp.Name = "chkPrtGrp"
        Me.chkPrtGrp.Size = New System.Drawing.Size(79, 17)
        Me.chkPrtGrp.TabIndex = 9
        Me.chkPrtGrp.Text = "Print Group"
        Me.chkPrtGrp.UseVisualStyleBackColor = True
        '
        'optFormat1
        '
        Me.optFormat1.AutoSize = True
        Me.optFormat1.Location = New System.Drawing.Point(82, 61)
        Me.optFormat1.Name = "optFormat1"
        Me.optFormat1.Size = New System.Drawing.Size(107, 17)
        Me.optFormat1.TabIndex = 8
        Me.optFormat1.Text = "To Crystal Report"
        Me.optFormat1.UseVisualStyleBackColor = True
        '
        'optFormat0
        '
        Me.optFormat0.AutoSize = True
        Me.optFormat0.Location = New System.Drawing.Point(11, 61)
        Me.optFormat0.Name = "optFormat0"
        Me.optFormat0.Size = New System.Drawing.Size(67, 17)
        Me.optFormat0.TabIndex = 7
        Me.optFormat0.Text = "To Excel"
        Me.optFormat0.UseVisualStyleBackColor = True
        '
        'cboReport
        '
        Me.cboReport.FormattingEnabled = True
        Me.cboReport.Location = New System.Drawing.Point(6, 25)
        Me.cboReport.Name = "cboReport"
        Me.cboReport.Size = New System.Drawing.Size(387, 21)
        Me.cboReport.TabIndex = 6
        '
        'MPR00003
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(440, 269)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.Frame4)
        Me.Controls.Add(Me.Frame3)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.cmdShow)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MPR00003"
        Me.Text = "MPR00003 - GRN Transfer Reports"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Frame2.ResumeLayout(False)
        Me.Frame2.PerformLayout()
        Me.Frame3.ResumeLayout(False)
        Me.Frame4.ResumeLayout(False)
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtGrnNoFm As System.Windows.Forms.TextBox
    Friend WithEvents txtGrnNoTo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
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
End Class
