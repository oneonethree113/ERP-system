<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SCR00004
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SCR00004))
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton3 = New System.Windows.Forms.RadioButton
        Me.RadioButton4 = New System.Windows.Forms.RadioButton
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtSCRvsdatTo = New System.Windows.Forms.MaskedTextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtSCRvsdatFm = New System.Windows.Forms.MaskedTextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_S_CustPONo = New System.Windows.Forms.TextBox
        Me.cmd_S_ItmNo = New System.Windows.Forms.Button
        Me.txt_S_SCNo = New System.Windows.Forms.TextBox
        Me.cmd_S_SCNo = New System.Windows.Forms.Button
        Me.txt_S_SecCustAll = New System.Windows.Forms.TextBox
        Me.cmd_S_SecCust = New System.Windows.Forms.Button
        Me.txt_S_PriCustAll = New System.Windows.Forms.TextBox
        Me.cmd_S_PriCust = New System.Windows.Forms.Button
        Me.txt_S_CoCde = New System.Windows.Forms.TextBox
        Me.cmd_S_CoCde = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdShow = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.Panel11 = New System.Windows.Forms.Panel
        Me.optStsALL = New System.Windows.Forms.RadioButton
        Me.optStsHLD = New System.Windows.Forms.RadioButton
        Me.Label18 = New System.Windows.Forms.Label
        Me.Panel11.SuspendLayout()
        Me.SuspendLayout()
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(116, 10)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(127, 17)
        Me.RadioButton1.TabIndex = 64
        Me.RadioButton1.Text = "W - Wait for Approval"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Checked = True
        Me.RadioButton2.Location = New System.Drawing.Point(16, 9)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(83, 17)
        Me.RadioButton2.TabIndex = 63
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Y - Approval"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(116, 10)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(127, 17)
        Me.RadioButton3.TabIndex = 64
        Me.RadioButton3.Text = "W - Wait for Approval"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Checked = True
        Me.RadioButton4.Location = New System.Drawing.Point(16, 9)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(83, 17)
        Me.RadioButton4.TabIndex = 63
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "Y - Approval"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(504, 231)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(87, 12)
        Me.Label16.TabIndex = 21
        Me.Label16.Text = "(MM/DD/YYYY)"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(298, 229)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(87, 12)
        Me.Label15.TabIndex = 20
        Me.Label15.Text = "(MM/DD/YYYY)"
        '
        'txtSCRvsdatTo
        '
        Me.txtSCRvsdatTo.Location = New System.Drawing.Point(431, 226)
        Me.txtSCRvsdatTo.Mask = "00/00/0000"
        Me.txtSCRvsdatTo.Name = "txtSCRvsdatTo"
        Me.txtSCRvsdatTo.Size = New System.Drawing.Size(72, 22)
        Me.txtSCRvsdatTo.TabIndex = 19
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(395, 229)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(18, 12)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "To"
        '
        'txtSCRvsdatFm
        '
        Me.txtSCRvsdatFm.Location = New System.Drawing.Point(226, 226)
        Me.txtSCRvsdatFm.Mask = "00/00/0000"
        Me.txtSCRvsdatFm.Name = "txtSCRvsdatFm"
        Me.txtSCRvsdatFm.Size = New System.Drawing.Size(72, 22)
        Me.txtSCRvsdatFm.TabIndex = 17
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(146, 229)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 12)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "From"
        '
        'txt_S_CustPONo
        '
        Me.txt_S_CustPONo.Location = New System.Drawing.Point(226, 188)
        Me.txt_S_CustPONo.Name = "txt_S_CustPONo"
        Me.txt_S_CustPONo.Size = New System.Drawing.Size(361, 22)
        Me.txt_S_CustPONo.TabIndex = 15
        '
        'cmd_S_ItmNo
        '
        Me.cmd_S_ItmNo.Location = New System.Drawing.Point(147, 187)
        Me.cmd_S_ItmNo.Name = "cmd_S_ItmNo"
        Me.cmd_S_ItmNo.Size = New System.Drawing.Size(42, 20)
        Me.cmd_S_ItmNo.TabIndex = 14
        Me.cmd_S_ItmNo.Text = "->"
        Me.cmd_S_ItmNo.UseVisualStyleBackColor = True
        '
        'txt_S_SCNo
        '
        Me.txt_S_SCNo.Location = New System.Drawing.Point(226, 150)
        Me.txt_S_SCNo.Name = "txt_S_SCNo"
        Me.txt_S_SCNo.Size = New System.Drawing.Size(361, 22)
        Me.txt_S_SCNo.TabIndex = 13
        '
        'cmd_S_SCNo
        '
        Me.cmd_S_SCNo.Location = New System.Drawing.Point(148, 148)
        Me.cmd_S_SCNo.Name = "cmd_S_SCNo"
        Me.cmd_S_SCNo.Size = New System.Drawing.Size(42, 20)
        Me.cmd_S_SCNo.TabIndex = 12
        Me.cmd_S_SCNo.Text = "->"
        Me.cmd_S_SCNo.UseVisualStyleBackColor = True
        '
        'txt_S_SecCustAll
        '
        Me.txt_S_SecCustAll.Location = New System.Drawing.Point(226, 112)
        Me.txt_S_SecCustAll.Name = "txt_S_SecCustAll"
        Me.txt_S_SecCustAll.Size = New System.Drawing.Size(361, 22)
        Me.txt_S_SecCustAll.TabIndex = 11
        '
        'cmd_S_SecCust
        '
        Me.cmd_S_SecCust.Location = New System.Drawing.Point(148, 110)
        Me.cmd_S_SecCust.Name = "cmd_S_SecCust"
        Me.cmd_S_SecCust.Size = New System.Drawing.Size(42, 20)
        Me.cmd_S_SecCust.TabIndex = 10
        Me.cmd_S_SecCust.Text = "->"
        Me.cmd_S_SecCust.UseVisualStyleBackColor = True
        '
        'txt_S_PriCustAll
        '
        Me.txt_S_PriCustAll.Location = New System.Drawing.Point(226, 74)
        Me.txt_S_PriCustAll.Name = "txt_S_PriCustAll"
        Me.txt_S_PriCustAll.Size = New System.Drawing.Size(361, 22)
        Me.txt_S_PriCustAll.TabIndex = 9
        '
        'cmd_S_PriCust
        '
        Me.cmd_S_PriCust.Location = New System.Drawing.Point(148, 72)
        Me.cmd_S_PriCust.Name = "cmd_S_PriCust"
        Me.cmd_S_PriCust.Size = New System.Drawing.Size(42, 20)
        Me.cmd_S_PriCust.TabIndex = 8
        Me.cmd_S_PriCust.Text = "->"
        Me.cmd_S_PriCust.UseVisualStyleBackColor = True
        '
        'txt_S_CoCde
        '
        Me.txt_S_CoCde.Location = New System.Drawing.Point(226, 37)
        Me.txt_S_CoCde.Name = "txt_S_CoCde"
        Me.txt_S_CoCde.Size = New System.Drawing.Size(361, 22)
        Me.txt_S_CoCde.TabIndex = 7
        '
        'cmd_S_CoCde
        '
        Me.cmd_S_CoCde.Location = New System.Drawing.Point(148, 36)
        Me.cmd_S_CoCde.Name = "cmd_S_CoCde"
        Me.cmd_S_CoCde.Size = New System.Drawing.Size(42, 20)
        Me.cmd_S_CoCde.TabIndex = 6
        Me.cmd_S_CoCde.Text = "->"
        Me.cmd_S_CoCde.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(29, 229)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 12)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "SC Revised Date"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(28, 191)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 12)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Customer PO No"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(29, 153)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 12)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "SC No."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(29, 115)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Sec. Customer"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Pri. Customer"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Company Code"
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(258, 313)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(116, 40)
        Me.cmdShow.TabIndex = 22
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(11, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(611, 20)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Sales Confirmation Approval Report"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.optStsALL)
        Me.Panel11.Controls.Add(Me.optStsHLD)
        Me.Panel11.Location = New System.Drawing.Point(224, 266)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(367, 21)
        Me.Panel11.TabIndex = 25
        Me.Panel11.Visible = False
        '
        'optStsALL
        '
        Me.optStsALL.AutoSize = True
        Me.optStsALL.Location = New System.Drawing.Point(318, 2)
        Me.optStsALL.Name = "optStsALL"
        Me.optStsALL.Size = New System.Drawing.Size(45, 16)
        Me.optStsALL.TabIndex = 21
        Me.optStsALL.Text = "ALL"
        Me.optStsALL.UseVisualStyleBackColor = True
        '
        'optStsHLD
        '
        Me.optStsHLD.AutoSize = True
        Me.optStsHLD.Checked = True
        Me.optStsHLD.Location = New System.Drawing.Point(3, 2)
        Me.optStsHLD.Name = "optStsHLD"
        Me.optStsHLD.Size = New System.Drawing.Size(124, 16)
        Me.optStsHLD.TabIndex = 20
        Me.optStsHLD.TabStop = True
        Me.optStsHLD.Text = "Waiting for Approval"
        Me.optStsHLD.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(28, 270)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(32, 12)
        Me.Label18.TabIndex = 24
        Me.Label18.Text = "Status"
        Me.Label18.Visible = False
        '
        'SCR00004
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 411)
        Me.Controls.Add(Me.Panel11)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtSCRvsdatTo)
        Me.Controls.Add(Me.txtSCRvsdatFm)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_S_CustPONo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmd_S_ItmNo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_S_SCNo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmd_S_SCNo)
        Me.Controls.Add(Me.cmd_S_CoCde)
        Me.Controls.Add(Me.txt_S_SecCustAll)
        Me.Controls.Add(Me.txt_S_CoCde)
        Me.Controls.Add(Me.cmd_S_SecCust)
        Me.Controls.Add(Me.cmd_S_PriCust)
        Me.Controls.Add(Me.txt_S_PriCustAll)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "SCR00004"
        Me.Text = "SCR00004 - Sales Confirmation Approval Report (SCR04)"
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSCRvsdatTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtSCRvsdatFm As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_S_CustPONo As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_ItmNo As System.Windows.Forms.Button
    Friend WithEvents txt_S_SCNo As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_SCNo As System.Windows.Forms.Button
    Friend WithEvents txt_S_SecCustAll As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_SecCust As System.Windows.Forms.Button
    Friend WithEvents txt_S_PriCustAll As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_PriCust As System.Windows.Forms.Button
    Friend WithEvents txt_S_CoCde As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_CoCde As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents optStsALL As System.Windows.Forms.RadioButton
    Friend WithEvents optStsHLD As System.Windows.Forms.RadioButton
    Friend WithEvents Label18 As System.Windows.Forms.Label
End Class
