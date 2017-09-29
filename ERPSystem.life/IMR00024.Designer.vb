<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IMR00024
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
        Me.cmdShow = New System.Windows.Forms.Button
        Me.grpSCNo = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtSCTo = New System.Windows.Forms.TextBox
        Me.txtSCFm = New System.Windows.Forms.TextBox
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtJobTo = New System.Windows.Forms.TextBox
        Me.txtJobFm = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.optLate = New System.Windows.Forms.RadioButton
        Me.optUPD = New System.Windows.Forms.RadioButton
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txt_S_SecCustAll = New System.Windows.Forms.TextBox
        Me.cmd_S_SecCustAll = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txt_S_PriCustAll = New System.Windows.Forms.TextBox
        Me.cmd_S_PriCustAll = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.grpSCNo.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(211, 310)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(111, 32)
        Me.cmdShow.TabIndex = 28
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'grpSCNo
        '
        Me.grpSCNo.Controls.Add(Me.Label4)
        Me.grpSCNo.Controls.Add(Me.Label15)
        Me.grpSCNo.Controls.Add(Me.Label14)
        Me.grpSCNo.Controls.Add(Me.txtSCTo)
        Me.grpSCNo.Controls.Add(Me.txtSCFm)
        Me.grpSCNo.Location = New System.Drawing.Point(17, 162)
        Me.grpSCNo.Name = "grpSCNo"
        Me.grpSCNo.Size = New System.Drawing.Size(507, 46)
        Me.grpSCNo.TabIndex = 12
        Me.grpSCNo.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 12)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Sales Confirmation"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(123, 19)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(36, 12)
        Me.Label15.TabIndex = 14
        Me.Label15.Text = "From :"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(323, 19)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(24, 12)
        Me.Label14.TabIndex = 16
        Me.Label14.Text = "To :"
        '
        'txtSCTo
        '
        Me.txtSCTo.Location = New System.Drawing.Point(355, 16)
        Me.txtSCTo.Name = "txtSCTo"
        Me.txtSCTo.Size = New System.Drawing.Size(124, 22)
        Me.txtSCTo.TabIndex = 17
        '
        'txtSCFm
        '
        Me.txtSCFm.Location = New System.Drawing.Point(172, 16)
        Me.txtSCFm.Name = "txtSCFm"
        Me.txtSCFm.Size = New System.Drawing.Size(124, 22)
        Me.txtSCFm.TabIndex = 15
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.Color.White
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.Location = New System.Drawing.Point(256, 43)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.Size = New System.Drawing.Size(268, 22)
        Me.txtCoNam.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(171, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Company Name:"
        '
        'cboCoCde
        '
        Me.cboCoCde.BackColor = System.Drawing.Color.White
        Me.cboCoCde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(96, 42)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(72, 20)
        Me.cboCoCde.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(14, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Company Code"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(13, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(511, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Attachment Update History"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtJobTo)
        Me.GroupBox1.Controls.Add(Me.txtJobFm)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 206)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(507, 46)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 12)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Job No."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(123, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 12)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "From :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(323, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 12)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "To :"
        '
        'txtJobTo
        '
        Me.txtJobTo.Location = New System.Drawing.Point(355, 16)
        Me.txtJobTo.Name = "txtJobTo"
        Me.txtJobTo.Size = New System.Drawing.Size(124, 22)
        Me.txtJobTo.TabIndex = 23
        '
        'txtJobFm
        '
        Me.txtJobFm.Location = New System.Drawing.Point(172, 16)
        Me.txtJobFm.Name = "txtJobFm"
        Me.txtJobFm.Size = New System.Drawing.Size(124, 22)
        Me.txtJobFm.TabIndex = 21
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.optLate)
        Me.GroupBox2.Controls.Add(Me.optUPD)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 258)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(507, 46)
        Me.GroupBox2.TabIndex = 24
        Me.GroupBox2.TabStop = False
        '
        'optLate
        '
        Me.optLate.AutoSize = True
        Me.optLate.Checked = True
        Me.optLate.Location = New System.Drawing.Point(351, 17)
        Me.optLate.Name = "optLate"
        Me.optLate.Size = New System.Drawing.Size(106, 16)
        Me.optLate.TabIndex = 27
        Me.optLate.Text = "Latest Attachment"
        Me.optLate.UseVisualStyleBackColor = True
        '
        'optUPD
        '
        Me.optUPD.AutoSize = True
        Me.optUPD.Location = New System.Drawing.Point(168, 17)
        Me.optUPD.Name = "optUPD"
        Me.optUPD.Size = New System.Drawing.Size(93, 16)
        Me.optUPD.TabIndex = 26
        Me.optUPD.Text = "Update History"
        Me.optUPD.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 12)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Select Option"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txt_S_SecCustAll)
        Me.GroupBox3.Controls.Add(Me.cmd_S_SecCustAll)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Location = New System.Drawing.Point(17, 120)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(507, 46)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        '
        'txt_S_SecCustAll
        '
        Me.txt_S_SecCustAll.Location = New System.Drawing.Point(172, 13)
        Me.txt_S_SecCustAll.Name = "txt_S_SecCustAll"
        Me.txt_S_SecCustAll.Size = New System.Drawing.Size(307, 22)
        Me.txt_S_SecCustAll.TabIndex = 11
        '
        'cmd_S_SecCustAll
        '
        Me.cmd_S_SecCustAll.Location = New System.Drawing.Point(121, 15)
        Me.cmd_S_SecCustAll.Name = "cmd_S_SecCustAll"
        Me.cmd_S_SecCustAll.Size = New System.Drawing.Size(45, 18)
        Me.cmd_S_SecCustAll.TabIndex = 10
        Me.cmd_S_SecCustAll.Text = "＞＞"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(117, 12)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Secordary Customer No"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txt_S_PriCustAll)
        Me.GroupBox4.Controls.Add(Me.cmd_S_PriCustAll)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Location = New System.Drawing.Point(17, 76)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(507, 46)
        Me.GroupBox4.TabIndex = 5
        Me.GroupBox4.TabStop = False
        '
        'txt_S_PriCustAll
        '
        Me.txt_S_PriCustAll.Location = New System.Drawing.Point(172, 16)
        Me.txt_S_PriCustAll.Name = "txt_S_PriCustAll"
        Me.txt_S_PriCustAll.Size = New System.Drawing.Size(307, 22)
        Me.txt_S_PriCustAll.TabIndex = 8
        '
        'cmd_S_PriCustAll
        '
        Me.cmd_S_PriCustAll.Location = New System.Drawing.Point(121, 16)
        Me.cmd_S_PriCustAll.Name = "cmd_S_PriCustAll"
        Me.cmd_S_PriCustAll.Size = New System.Drawing.Size(45, 18)
        Me.cmd_S_PriCustAll.TabIndex = 7
        Me.cmd_S_PriCustAll.Text = "＞＞"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(107, 12)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Primary Customer No"
        '
        'IMR00024
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(537, 362)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.grpSCNo)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "IMR00024"
        Me.Text = "IMR00024 - Attachment Update History"
        Me.grpSCNo.ResumeLayout(False)
        Me.grpSCNo.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents grpSCNo As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtSCTo As System.Windows.Forms.TextBox
    Friend WithEvents txtSCFm As System.Windows.Forms.TextBox
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtJobTo As System.Windows.Forms.TextBox
    Friend WithEvents txtJobFm As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents optLate As System.Windows.Forms.RadioButton
    Friend WithEvents optUPD As System.Windows.Forms.RadioButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmd_S_PriCustAll As System.Windows.Forms.Button
    Friend WithEvents txt_S_PriCustAll As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_SecCustAll As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_SecCustAll As System.Windows.Forms.Button
End Class
