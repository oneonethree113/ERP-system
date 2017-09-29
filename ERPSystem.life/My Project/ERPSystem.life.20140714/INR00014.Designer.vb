<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class INR00014
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(INR00014))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.optALL = New System.Windows.Forms.RadioButton
        Me.optOS = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.opt4w = New System.Windows.Forms.RadioButton
        Me.opt1w = New System.Windows.Forms.RadioButton
        Me.opt2w = New System.Windows.Forms.RadioButton
        Me.btnShow = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txt_S_DateTo = New AxMSMask.AxMaskEdBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txt_S_DateFm = New AxMSMask.AxMaskEdBox
        Me.cmd_S_VdrCde = New System.Windows.Forms.Button
        Me.cmd_S_CoCde = New System.Windows.Forms.Button
        Me.txt_S_VdrCde = New System.Windows.Forms.TextBox
        Me.txt_S_CoCde = New System.Windows.Forms.TextBox
        Me.lbl_S_PriCust = New System.Windows.Forms.Label
        Me.lbl_S_CoCde = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.optView1 = New System.Windows.Forms.RadioButton
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.txt_S_DateTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_S_DateFm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.btnShow)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txt_S_DateTo)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txt_S_DateFm)
        Me.GroupBox1.Controls.Add(Me.cmd_S_VdrCde)
        Me.GroupBox1.Controls.Add(Me.cmd_S_CoCde)
        Me.GroupBox1.Controls.Add(Me.txt_S_VdrCde)
        Me.GroupBox1.Controls.Add(Me.txt_S_CoCde)
        Me.GroupBox1.Controls.Add(Me.lbl_S_PriCust)
        Me.GroupBox1.Controls.Add(Me.lbl_S_CoCde)
        Me.GroupBox1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(14, 14)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(768, 372)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Selection Criteria"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.optALL)
        Me.GroupBox3.Controls.Add(Me.optOS)
        Me.GroupBox3.Location = New System.Drawing.Point(16, 196)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(435, 54)
        Me.GroupBox3.TabIndex = 114
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Order Status"
        '
        'optALL
        '
        Me.optALL.AutoSize = True
        Me.optALL.Location = New System.Drawing.Point(176, 20)
        Me.optALL.Name = "optALL"
        Me.optALL.Size = New System.Drawing.Size(49, 19)
        Me.optALL.TabIndex = 108
        Me.optALL.TabStop = True
        Me.optALL.Text = "ALL"
        Me.optALL.UseVisualStyleBackColor = True
        '
        'optOS
        '
        Me.optOS.AutoSize = True
        Me.optOS.Location = New System.Drawing.Point(98, 20)
        Me.optOS.Name = "optOS"
        Me.optOS.Size = New System.Drawing.Size(41, 19)
        Me.optOS.TabIndex = 107
        Me.optOS.TabStop = True
        Me.optOS.Text = "OS"
        Me.optOS.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.opt4w)
        Me.GroupBox2.Controls.Add(Me.opt1w)
        Me.GroupBox2.Controls.Add(Me.opt2w)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 257)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(435, 62)
        Me.GroupBox2.TabIndex = 113
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Report Period"
        '
        'opt4w
        '
        Me.opt4w.AutoSize = True
        Me.opt4w.Location = New System.Drawing.Point(259, 31)
        Me.opt4w.Name = "opt4w"
        Me.opt4w.Size = New System.Drawing.Size(65, 19)
        Me.opt4w.TabIndex = 112
        Me.opt4w.TabStop = True
        Me.opt4w.Text = "4 Week"
        Me.opt4w.UseVisualStyleBackColor = True
        '
        'opt1w
        '
        Me.opt1w.AutoSize = True
        Me.opt1w.Location = New System.Drawing.Point(95, 31)
        Me.opt1w.Name = "opt1w"
        Me.opt1w.Size = New System.Drawing.Size(65, 19)
        Me.opt1w.TabIndex = 110
        Me.opt1w.TabStop = True
        Me.opt1w.Text = "1 Week"
        Me.opt1w.UseVisualStyleBackColor = True
        '
        'opt2w
        '
        Me.opt2w.AutoSize = True
        Me.opt2w.Location = New System.Drawing.Point(176, 31)
        Me.opt2w.Name = "opt2w"
        Me.opt2w.Size = New System.Drawing.Size(65, 19)
        Me.opt2w.TabIndex = 111
        Me.opt2w.TabStop = True
        Me.opt2w.Text = "2 Week"
        Me.opt2w.UseVisualStyleBackColor = True
        '
        'btnShow
        '
        Me.btnShow.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShow.Location = New System.Drawing.Point(345, 331)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(106, 35)
        Me.btnShow.TabIndex = 105
        Me.btnShow.Text = "Show"
        Me.btnShow.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 15)
        Me.Label1.TabIndex = 104
        Me.Label1.Text = "Date Range :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(153, 96)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 15)
        Me.Label8.TabIndex = 103
        Me.Label8.Text = "From"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(446, 96)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(22, 15)
        Me.Label9.TabIndex = 102
        Me.Label9.Text = "To"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(566, 93)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(117, 18)
        Me.Label10.TabIndex = 101
        Me.Label10.Text = "(MM/DD/YYYY)"
        '
        'txt_S_DateTo
        '
        Me.txt_S_DateTo.Location = New System.Drawing.Point(472, 91)
        Me.txt_S_DateTo.Name = "txt_S_DateTo"
        Me.txt_S_DateTo.OcxState = CType(resources.GetObject("txt_S_DateTo.OcxState"), System.Windows.Forms.AxHost.State)
        Me.txt_S_DateTo.Size = New System.Drawing.Size(88, 23)
        Me.txt_S_DateTo.TabIndex = 100
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(286, 93)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(117, 18)
        Me.Label11.TabIndex = 98
        Me.Label11.Text = "(MM/DD/YYYY)"
        '
        'txt_S_DateFm
        '
        Me.txt_S_DateFm.Location = New System.Drawing.Point(192, 91)
        Me.txt_S_DateFm.Name = "txt_S_DateFm"
        Me.txt_S_DateFm.OcxState = CType(resources.GetObject("txt_S_DateFm.OcxState"), System.Windows.Forms.AxHost.State)
        Me.txt_S_DateFm.Size = New System.Drawing.Size(88, 23)
        Me.txt_S_DateFm.TabIndex = 99
        '
        'cmd_S_VdrCde
        '
        Me.cmd_S_VdrCde.Location = New System.Drawing.Point(111, 62)
        Me.cmd_S_VdrCde.Name = "cmd_S_VdrCde"
        Me.cmd_S_VdrCde.Size = New System.Drawing.Size(75, 28)
        Me.cmd_S_VdrCde.TabIndex = 95
        Me.cmd_S_VdrCde.Text = "＞＞"
        '
        'cmd_S_CoCde
        '
        Me.cmd_S_CoCde.Location = New System.Drawing.Point(111, 33)
        Me.cmd_S_CoCde.Name = "cmd_S_CoCde"
        Me.cmd_S_CoCde.Size = New System.Drawing.Size(75, 28)
        Me.cmd_S_CoCde.TabIndex = 93
        Me.cmd_S_CoCde.Text = "＞＞"
        '
        'txt_S_VdrCde
        '
        Me.txt_S_VdrCde.Location = New System.Drawing.Point(192, 64)
        Me.txt_S_VdrCde.MaxLength = 5000
        Me.txt_S_VdrCde.Name = "txt_S_VdrCde"
        Me.txt_S_VdrCde.Size = New System.Drawing.Size(563, 22)
        Me.txt_S_VdrCde.TabIndex = 96
        '
        'txt_S_CoCde
        '
        Me.txt_S_CoCde.Enabled = False
        Me.txt_S_CoCde.Location = New System.Drawing.Point(192, 38)
        Me.txt_S_CoCde.MaxLength = 5000
        Me.txt_S_CoCde.Name = "txt_S_CoCde"
        Me.txt_S_CoCde.Size = New System.Drawing.Size(563, 22)
        Me.txt_S_CoCde.TabIndex = 94
        '
        'lbl_S_PriCust
        '
        Me.lbl_S_PriCust.AutoSize = True
        Me.lbl_S_PriCust.Location = New System.Drawing.Point(13, 66)
        Me.lbl_S_PriCust.Name = "lbl_S_PriCust"
        Me.lbl_S_PriCust.Size = New System.Drawing.Size(83, 15)
        Me.lbl_S_PriCust.TabIndex = 92
        Me.lbl_S_PriCust.Text = "Vendor Code :"
        '
        'lbl_S_CoCde
        '
        Me.lbl_S_CoCde.AutoSize = True
        Me.lbl_S_CoCde.Location = New System.Drawing.Point(13, 36)
        Me.lbl_S_CoCde.Name = "lbl_S_CoCde"
        Me.lbl_S_CoCde.Size = New System.Drawing.Size(95, 15)
        Me.lbl_S_CoCde.TabIndex = 91
        Me.lbl_S_CoCde.Text = "Company Code :"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.optView1)
        Me.GroupBox4.Location = New System.Drawing.Point(16, 131)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(435, 54)
        Me.GroupBox4.TabIndex = 115
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Report Type"
        '
        'optView1
        '
        Me.optView1.AutoSize = True
        Me.optView1.Location = New System.Drawing.Point(98, 20)
        Me.optView1.Name = "optView1"
        Me.optView1.Size = New System.Drawing.Size(242, 19)
        Me.optView1.TabIndex = 107
        Me.optView1.TabStop = True
        Me.optView1.Text = "Scheduled Shipment vs Actual Shipment"
        Me.optView1.UseVisualStyleBackColor = True
        '
        'INR00014
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(789, 398)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "INR00014"
        Me.Text = "INR00014 - CBM Report"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.txt_S_DateTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_S_DateFm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_S_DateTo As AxMSMask.AxMaskEdBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txt_S_DateFm As AxMSMask.AxMaskEdBox
    Friend WithEvents cmd_S_VdrCde As System.Windows.Forms.Button
    Friend WithEvents cmd_S_CoCde As System.Windows.Forms.Button
    Friend WithEvents txt_S_VdrCde As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_CoCde As System.Windows.Forms.TextBox
    Friend WithEvents lbl_S_PriCust As System.Windows.Forms.Label
    Friend WithEvents lbl_S_CoCde As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnShow As System.Windows.Forms.Button
    Friend WithEvents optALL As System.Windows.Forms.RadioButton
    Friend WithEvents optOS As System.Windows.Forms.RadioButton
    Friend WithEvents opt4w As System.Windows.Forms.RadioButton
    Friend WithEvents opt2w As System.Windows.Forms.RadioButton
    Friend WithEvents opt1w As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents optView1 As System.Windows.Forms.RadioButton
End Class
