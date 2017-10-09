<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QCM00010
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(QCM00010))
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboCocde = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmd_S_CustPONo = New System.Windows.Forms.Button
        Me.cmd_S_CV = New System.Windows.Forms.Button
        Me.cmd_S_SecCustAll = New System.Windows.Forms.Button
        Me.cmd_S_PriCustAll = New System.Windows.Forms.Button
        Me.txtSCShipDateTo = New System.Windows.Forms.MaskedTextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtSCShipDateFm = New System.Windows.Forms.MaskedTextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.cmdShow = New System.Windows.Forms.Button
        Me.txt_S_CV = New System.Windows.Forms.TextBox
        Me.txt_S_CustPONo = New System.Windows.Forms.TextBox
        Me.SLabel_8 = New System.Windows.Forms.Label
        Me.txt_S_SecCustAll = New System.Windows.Forms.TextBox
        Me.txt_S_PriCustAll = New System.Windows.Forms.TextBox
        Me.txtPOShipDateTo = New System.Windows.Forms.MaskedTextBox
        Me.Label41 = New System.Windows.Forms.Label
        Me.txtPOShipDateFm = New System.Windows.Forms.MaskedTextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.SLabel_3 = New System.Windows.Forms.Label
        Me.SLabel_2 = New System.Windows.Forms.Label
        Me.SLabel_1 = New System.Windows.Forms.Label
        Me.chkCanPo = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'txtCoNam
        '
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.Location = New System.Drawing.Point(318, 28)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.Size = New System.Drawing.Size(302, 22)
        Me.txtCoNam.TabIndex = 48
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(227, 30)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 12)
        Me.Label6.TabIndex = 50
        Me.Label6.Text = "Company Name:"
        '
        'cboCocde
        '
        Me.cboCocde.FormattingEnabled = True
        Me.cboCocde.Location = New System.Drawing.Point(137, 27)
        Me.cboCocde.Name = "cboCocde"
        Me.cboCocde.Size = New System.Drawing.Size(70, 20)
        Me.cboCocde.TabIndex = 47
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(51, 30)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 12)
        Me.Label7.TabIndex = 49
        Me.Label7.Text = "Company Code:"
        '
        'cmd_S_CustPONo
        '
        Me.cmd_S_CustPONo.Location = New System.Drawing.Point(151, 167)
        Me.cmd_S_CustPONo.Name = "cmd_S_CustPONo"
        Me.cmd_S_CustPONo.Size = New System.Drawing.Size(45, 18)
        Me.cmd_S_CustPONo.TabIndex = 96
        Me.cmd_S_CustPONo.Text = "＞＞"
        '
        'cmd_S_CV
        '
        Me.cmd_S_CV.Location = New System.Drawing.Point(151, 140)
        Me.cmd_S_CV.Name = "cmd_S_CV"
        Me.cmd_S_CV.Size = New System.Drawing.Size(45, 18)
        Me.cmd_S_CV.TabIndex = 95
        Me.cmd_S_CV.Text = "＞＞"
        '
        'cmd_S_SecCustAll
        '
        Me.cmd_S_SecCustAll.Location = New System.Drawing.Point(151, 111)
        Me.cmd_S_SecCustAll.Name = "cmd_S_SecCustAll"
        Me.cmd_S_SecCustAll.Size = New System.Drawing.Size(45, 18)
        Me.cmd_S_SecCustAll.TabIndex = 94
        Me.cmd_S_SecCustAll.Text = "＞＞"
        '
        'cmd_S_PriCustAll
        '
        Me.cmd_S_PriCustAll.Location = New System.Drawing.Point(151, 85)
        Me.cmd_S_PriCustAll.Name = "cmd_S_PriCustAll"
        Me.cmd_S_PriCustAll.Size = New System.Drawing.Size(45, 18)
        Me.cmd_S_PriCustAll.TabIndex = 62
        Me.cmd_S_PriCustAll.Text = "＞＞"
        '
        'txtSCShipDateTo
        '
        Me.txtSCShipDateTo.Location = New System.Drawing.Point(462, 390)
        Me.txtSCShipDateTo.Mask = "##/##/####"
        Me.txtSCShipDateTo.Name = "txtSCShipDateTo"
        Me.txtSCShipDateTo.Size = New System.Drawing.Size(164, 22)
        Me.txtSCShipDateTo.TabIndex = 91
        Me.txtSCShipDateTo.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(430, 392)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(24, 12)
        Me.Label15.TabIndex = 93
        Me.Label15.Text = "To :"
        Me.Label15.Visible = False
        '
        'txtSCShipDateFm
        '
        Me.txtSCShipDateFm.Location = New System.Drawing.Point(248, 390)
        Me.txtSCShipDateFm.Mask = "##/##/####"
        Me.txtSCShipDateFm.Name = "txtSCShipDateFm"
        Me.txtSCShipDateFm.Size = New System.Drawing.Size(161, 22)
        Me.txtSCShipDateFm.TabIndex = 90
        Me.txtSCShipDateFm.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(206, 393)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(36, 12)
        Me.Label17.TabIndex = 92
        Me.Label17.Text = "From :"
        Me.Label17.Visible = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(58, 392)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(138, 12)
        Me.Label18.TabIndex = 89
        Me.Label18.Text = "SC Ship Date (mm/dd/yyyy)"
        Me.Label18.Visible = False
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(297, 281)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(100, 31)
        Me.cmdShow.TabIndex = 41
        Me.cmdShow.Text = "Gen Excel"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'txt_S_CV
        '
        Me.txt_S_CV.Location = New System.Drawing.Point(202, 137)
        Me.txt_S_CV.Name = "txt_S_CV"
        Me.txt_S_CV.Size = New System.Drawing.Size(500, 22)
        Me.txt_S_CV.TabIndex = 75
        '
        'txt_S_CustPONo
        '
        Me.txt_S_CustPONo.Location = New System.Drawing.Point(202, 164)
        Me.txt_S_CustPONo.Name = "txt_S_CustPONo"
        Me.txt_S_CustPONo.Size = New System.Drawing.Size(500, 22)
        Me.txt_S_CustPONo.TabIndex = 67
        '
        'SLabel_8
        '
        Me.SLabel_8.AutoSize = True
        Me.SLabel_8.Location = New System.Drawing.Point(24, 169)
        Me.SLabel_8.Name = "SLabel_8"
        Me.SLabel_8.Size = New System.Drawing.Size(84, 12)
        Me.SLabel_8.TabIndex = 65
        Me.SLabel_8.Text = "Customer PO No"
        '
        'txt_S_SecCustAll
        '
        Me.txt_S_SecCustAll.Location = New System.Drawing.Point(202, 111)
        Me.txt_S_SecCustAll.Name = "txt_S_SecCustAll"
        Me.txt_S_SecCustAll.Size = New System.Drawing.Size(500, 22)
        Me.txt_S_SecCustAll.TabIndex = 64
        '
        'txt_S_PriCustAll
        '
        Me.txt_S_PriCustAll.Location = New System.Drawing.Point(202, 84)
        Me.txt_S_PriCustAll.Name = "txt_S_PriCustAll"
        Me.txt_S_PriCustAll.Size = New System.Drawing.Size(500, 22)
        Me.txt_S_PriCustAll.TabIndex = 62
        Me.txt_S_PriCustAll.Text = "50155"
        '
        'txtPOShipDateTo
        '
        Me.txtPOShipDateTo.Location = New System.Drawing.Point(431, 201)
        Me.txtPOShipDateTo.Mask = "##/##/####"
        Me.txtPOShipDateTo.Name = "txtPOShipDateTo"
        Me.txtPOShipDateTo.Size = New System.Drawing.Size(164, 22)
        Me.txtPOShipDateTo.TabIndex = 24
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(399, 204)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(24, 12)
        Me.Label41.TabIndex = 46
        Me.Label41.Text = "To :"
        '
        'txtPOShipDateFm
        '
        Me.txtPOShipDateFm.Location = New System.Drawing.Point(217, 201)
        Me.txtPOShipDateFm.Mask = "##/##/####"
        Me.txtPOShipDateFm.Name = "txtPOShipDateFm"
        Me.txtPOShipDateFm.Size = New System.Drawing.Size(161, 22)
        Me.txtPOShipDateFm.TabIndex = 23
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(175, 204)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(36, 12)
        Me.Label30.TabIndex = 24
        Me.Label30.Text = "From :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(27, 204)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(149, 12)
        Me.Label16.TabIndex = 10
        Me.Label16.Text = "SC Cancel Date (mm/dd/yyyy)"
        '
        'SLabel_3
        '
        Me.SLabel_3.AutoSize = True
        Me.SLabel_3.Location = New System.Drawing.Point(24, 142)
        Me.SLabel_3.Name = "SLabel_3"
        Me.SLabel_3.Size = New System.Drawing.Size(21, 12)
        Me.SLabel_3.TabIndex = 6
        Me.SLabel_3.Text = "CV"
        '
        'SLabel_2
        '
        Me.SLabel_2.AutoSize = True
        Me.SLabel_2.Location = New System.Drawing.Point(24, 115)
        Me.SLabel_2.Name = "SLabel_2"
        Me.SLabel_2.Size = New System.Drawing.Size(119, 12)
        Me.SLabel_2.TabIndex = 1
        Me.SLabel_2.Text = "Secondary Customer No"
        '
        'SLabel_1
        '
        Me.SLabel_1.AutoSize = True
        Me.SLabel_1.Location = New System.Drawing.Point(24, 87)
        Me.SLabel_1.Name = "SLabel_1"
        Me.SLabel_1.Size = New System.Drawing.Size(107, 12)
        Me.SLabel_1.TabIndex = 0
        Me.SLabel_1.Text = "Primary Customer No"
        '
        'chkCanPo
        '
        Me.chkCanPo.AutoSize = True
        Me.chkCanPo.Location = New System.Drawing.Point(177, 241)
        Me.chkCanPo.Name = "chkCanPo"
        Me.chkCanPo.Size = New System.Drawing.Size(99, 16)
        Me.chkCanPo.TabIndex = 284
        Me.chkCanPo.Text = "With Cancel PO"
        Me.chkCanPo.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 242)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 12)
        Me.Label1.TabIndex = 285
        Me.Label1.Text = "Option"
        '
        'QCM00010
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(714, 471)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkCanPo)
        Me.Controls.Add(Me.cmd_S_CustPONo)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.cmd_S_CV)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmd_S_SecCustAll)
        Me.Controls.Add(Me.cboCocde)
        Me.Controls.Add(Me.cmd_S_PriCustAll)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtSCShipDateTo)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.SLabel_1)
        Me.Controls.Add(Me.txtSCShipDateFm)
        Me.Controls.Add(Me.SLabel_2)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.SLabel_3)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.txt_S_CV)
        Me.Controls.Add(Me.txtPOShipDateFm)
        Me.Controls.Add(Me.txt_S_CustPONo)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.SLabel_8)
        Me.Controls.Add(Me.txtPOShipDateTo)
        Me.Controls.Add(Me.txt_S_SecCustAll)
        Me.Controls.Add(Me.txt_S_PriCustAll)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "QCM00010"
        Me.Text = "QCM00010 - Inspection Certificate (QCM10)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboCocde As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSCShipDateTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtSCShipDateFm As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents txt_S_CV As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_CustPONo As System.Windows.Forms.TextBox
    Friend WithEvents SLabel_8 As System.Windows.Forms.Label
    Friend WithEvents txt_S_SecCustAll As System.Windows.Forms.TextBox
    Friend WithEvents txtPOShipDateTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents txtPOShipDateFm As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents SLabel_3 As System.Windows.Forms.Label
    Friend WithEvents SLabel_2 As System.Windows.Forms.Label
    Friend WithEvents txt_S_PriCustAll As System.Windows.Forms.TextBox
    Friend WithEvents SLabel_1 As System.Windows.Forms.Label
    Friend WithEvents cmd_S_PriCustAll As System.Windows.Forms.Button
    Friend WithEvents cmd_S_SecCustAll As System.Windows.Forms.Button
    Friend WithEvents cmd_S_CV As System.Windows.Forms.Button
    Friend WithEvents cmd_S_CustPONo As System.Windows.Forms.Button
    Friend WithEvents chkCanPo As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
