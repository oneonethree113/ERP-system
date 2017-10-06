<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QCM00006
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(QCM00006))
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboCocde = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox_Search = New System.Windows.Forms.GroupBox
        Me.txtSCShipDateTo = New System.Windows.Forms.MaskedTextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtSCShipDateFm = New System.Windows.Forms.MaskedTextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.txt_S_PONo = New System.Windows.Forms.TextBox
        Me.cmd_S_PONo = New System.Windows.Forms.Button
        Me.SLabel_7 = New System.Windows.Forms.Label
        Me.txt_S_CV = New System.Windows.Forms.TextBox
        Me.cmdShow = New System.Windows.Forms.Button
        Me.cmd_S_CV = New System.Windows.Forms.Button
        Me.SLabel_4 = New System.Windows.Forms.Label
        Me.txt_S_FA = New System.Windows.Forms.TextBox
        Me.cmd_S_FA = New System.Windows.Forms.Button
        Me.txt_S_PV = New System.Windows.Forms.TextBox
        Me.cmd_S_PV = New System.Windows.Forms.Button
        Me.txt_S_SCNo = New System.Windows.Forms.TextBox
        Me.cmd_S_SCNo = New System.Windows.Forms.Button
        Me.txt_S_CustPONo = New System.Windows.Forms.TextBox
        Me.cmd_S_CustPONo = New System.Windows.Forms.Button
        Me.SLabel_8 = New System.Windows.Forms.Label
        Me.txt_S_SecCustAll = New System.Windows.Forms.TextBox
        Me.cmd_S_SecCustAll = New System.Windows.Forms.Button
        Me.txt_S_PriCustAll = New System.Windows.Forms.TextBox
        Me.cmd_S_PriCustAll = New System.Windows.Forms.Button
        Me.txtPOShipDateTo = New System.Windows.Forms.MaskedTextBox
        Me.Label41 = New System.Windows.Forms.Label
        Me.txtPOShipDateFm = New System.Windows.Forms.MaskedTextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.SLabel_5 = New System.Windows.Forms.Label
        Me.SLabel_3 = New System.Windows.Forms.Label
        Me.SLabel_6 = New System.Windows.Forms.Label
        Me.SLabel_2 = New System.Windows.Forms.Label
        Me.SLabel_1 = New System.Windows.Forms.Label
        Me.GroupBox_Search.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtCoNam
        '
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.Location = New System.Drawing.Point(348, 28)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.Size = New System.Drawing.Size(302, 22)
        Me.txtCoNam.TabIndex = 48
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(250, 32)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 12)
        Me.Label6.TabIndex = 50
        Me.Label6.Text = "Company Name"
        '
        'cboCocde
        '
        Me.cboCocde.FormattingEnabled = True
        Me.cboCocde.Location = New System.Drawing.Point(154, 27)
        Me.cboCocde.Name = "cboCocde"
        Me.cboCocde.Size = New System.Drawing.Size(70, 20)
        Me.cboCocde.TabIndex = 47
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(59, 30)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 12)
        Me.Label7.TabIndex = 49
        Me.Label7.Text = "Company Code"
        '
        'GroupBox_Search
        '
        Me.GroupBox_Search.Controls.Add(Me.txtSCShipDateTo)
        Me.GroupBox_Search.Controls.Add(Me.Label15)
        Me.GroupBox_Search.Controls.Add(Me.txtSCShipDateFm)
        Me.GroupBox_Search.Controls.Add(Me.Label17)
        Me.GroupBox_Search.Controls.Add(Me.Label18)
        Me.GroupBox_Search.Controls.Add(Me.txt_S_PONo)
        Me.GroupBox_Search.Controls.Add(Me.cmd_S_PONo)
        Me.GroupBox_Search.Controls.Add(Me.SLabel_7)
        Me.GroupBox_Search.Controls.Add(Me.txt_S_CV)
        Me.GroupBox_Search.Controls.Add(Me.cmdShow)
        Me.GroupBox_Search.Controls.Add(Me.cmd_S_CV)
        Me.GroupBox_Search.Controls.Add(Me.SLabel_4)
        Me.GroupBox_Search.Controls.Add(Me.txt_S_FA)
        Me.GroupBox_Search.Controls.Add(Me.cmd_S_FA)
        Me.GroupBox_Search.Controls.Add(Me.txt_S_PV)
        Me.GroupBox_Search.Controls.Add(Me.cmd_S_PV)
        Me.GroupBox_Search.Controls.Add(Me.txt_S_SCNo)
        Me.GroupBox_Search.Controls.Add(Me.cmd_S_SCNo)
        Me.GroupBox_Search.Controls.Add(Me.txt_S_CustPONo)
        Me.GroupBox_Search.Controls.Add(Me.cmd_S_CustPONo)
        Me.GroupBox_Search.Controls.Add(Me.SLabel_8)
        Me.GroupBox_Search.Controls.Add(Me.txt_S_SecCustAll)
        Me.GroupBox_Search.Controls.Add(Me.cmd_S_SecCustAll)
        Me.GroupBox_Search.Controls.Add(Me.txt_S_PriCustAll)
        Me.GroupBox_Search.Controls.Add(Me.cmd_S_PriCustAll)
        Me.GroupBox_Search.Controls.Add(Me.txtPOShipDateTo)
        Me.GroupBox_Search.Controls.Add(Me.Label41)
        Me.GroupBox_Search.Controls.Add(Me.txtPOShipDateFm)
        Me.GroupBox_Search.Controls.Add(Me.Label30)
        Me.GroupBox_Search.Controls.Add(Me.Label16)
        Me.GroupBox_Search.Controls.Add(Me.SLabel_5)
        Me.GroupBox_Search.Controls.Add(Me.SLabel_3)
        Me.GroupBox_Search.Controls.Add(Me.SLabel_6)
        Me.GroupBox_Search.Controls.Add(Me.SLabel_2)
        Me.GroupBox_Search.Controls.Add(Me.SLabel_1)
        Me.GroupBox_Search.Location = New System.Drawing.Point(14, 56)
        Me.GroupBox_Search.Name = "GroupBox_Search"
        Me.GroupBox_Search.Size = New System.Drawing.Size(688, 403)
        Me.GroupBox_Search.TabIndex = 46
        Me.GroupBox_Search.TabStop = False
        '
        'txtSCShipDateTo
        '
        Me.txtSCShipDateTo.Location = New System.Drawing.Point(444, 255)
        Me.txtSCShipDateTo.Mask = "##/##/####"
        Me.txtSCShipDateTo.Name = "txtSCShipDateTo"
        Me.txtSCShipDateTo.Size = New System.Drawing.Size(164, 22)
        Me.txtSCShipDateTo.TabIndex = 91
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(412, 260)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(18, 12)
        Me.Label15.TabIndex = 93
        Me.Label15.Text = "To"
        '
        'txtSCShipDateFm
        '
        Me.txtSCShipDateFm.Location = New System.Drawing.Point(230, 255)
        Me.txtSCShipDateFm.Mask = "##/##/####"
        Me.txtSCShipDateFm.Name = "txtSCShipDateFm"
        Me.txtSCShipDateFm.Size = New System.Drawing.Size(161, 22)
        Me.txtSCShipDateFm.TabIndex = 90
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(179, 260)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(30, 12)
        Me.Label17.TabIndex = 92
        Me.Label17.Text = "From"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(13, 260)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(138, 12)
        Me.Label18.TabIndex = 89
        Me.Label18.Text = "SC Ship Date (mm/dd/yyyy)"
        '
        'txt_S_PONo
        '
        Me.txt_S_PONo.Location = New System.Drawing.Point(208, 181)
        Me.txt_S_PONo.Name = "txt_S_PONo"
        Me.txt_S_PONo.Size = New System.Drawing.Size(474, 22)
        Me.txt_S_PONo.TabIndex = 88
        '
        'cmd_S_PONo
        '
        Me.cmd_S_PONo.Location = New System.Drawing.Point(158, 184)
        Me.cmd_S_PONo.Name = "cmd_S_PONo"
        Me.cmd_S_PONo.Size = New System.Drawing.Size(45, 18)
        Me.cmd_S_PONo.TabIndex = 87
        Me.cmd_S_PONo.Text = "＞＞"
        '
        'SLabel_7
        '
        Me.SLabel_7.AutoSize = True
        Me.SLabel_7.Location = New System.Drawing.Point(13, 184)
        Me.SLabel_7.Name = "SLabel_7"
        Me.SLabel_7.Size = New System.Drawing.Size(60, 12)
        Me.SLabel_7.TabIndex = 86
        Me.SLabel_7.Text = "PO Number"
        '
        'txt_S_CV
        '
        Me.txt_S_CV.Location = New System.Drawing.Point(208, 97)
        Me.txt_S_CV.Name = "txt_S_CV"
        Me.txt_S_CV.Size = New System.Drawing.Size(474, 22)
        Me.txt_S_CV.TabIndex = 85
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(306, 323)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(75, 21)
        Me.cmdShow.TabIndex = 41
        Me.cmdShow.Text = "Search"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'cmd_S_CV
        '
        Me.cmd_S_CV.Location = New System.Drawing.Point(158, 99)
        Me.cmd_S_CV.Name = "cmd_S_CV"
        Me.cmd_S_CV.Size = New System.Drawing.Size(45, 18)
        Me.cmd_S_CV.TabIndex = 84
        Me.cmd_S_CV.Text = "＞＞"
        '
        'SLabel_4
        '
        Me.SLabel_4.AutoSize = True
        Me.SLabel_4.Location = New System.Drawing.Point(13, 100)
        Me.SLabel_4.Name = "SLabel_4"
        Me.SLabel_4.Size = New System.Drawing.Size(21, 12)
        Me.SLabel_4.TabIndex = 83
        Me.SLabel_4.Text = "CV"
        '
        'txt_S_FA
        '
        Me.txt_S_FA.Location = New System.Drawing.Point(208, 125)
        Me.txt_S_FA.Name = "txt_S_FA"
        Me.txt_S_FA.Size = New System.Drawing.Size(474, 22)
        Me.txt_S_FA.TabIndex = 77
        '
        'cmd_S_FA
        '
        Me.cmd_S_FA.Location = New System.Drawing.Point(158, 128)
        Me.cmd_S_FA.Name = "cmd_S_FA"
        Me.cmd_S_FA.Size = New System.Drawing.Size(45, 18)
        Me.cmd_S_FA.TabIndex = 76
        Me.cmd_S_FA.Text = "＞＞"
        '
        'txt_S_PV
        '
        Me.txt_S_PV.Location = New System.Drawing.Point(208, 69)
        Me.txt_S_PV.Name = "txt_S_PV"
        Me.txt_S_PV.Size = New System.Drawing.Size(474, 22)
        Me.txt_S_PV.TabIndex = 75
        '
        'cmd_S_PV
        '
        Me.cmd_S_PV.Location = New System.Drawing.Point(158, 69)
        Me.cmd_S_PV.Name = "cmd_S_PV"
        Me.cmd_S_PV.Size = New System.Drawing.Size(45, 18)
        Me.cmd_S_PV.TabIndex = 74
        Me.cmd_S_PV.Text = "＞＞"
        '
        'txt_S_SCNo
        '
        Me.txt_S_SCNo.Location = New System.Drawing.Point(208, 153)
        Me.txt_S_SCNo.Name = "txt_S_SCNo"
        Me.txt_S_SCNo.Size = New System.Drawing.Size(474, 22)
        Me.txt_S_SCNo.TabIndex = 69
        '
        'cmd_S_SCNo
        '
        Me.cmd_S_SCNo.Location = New System.Drawing.Point(158, 155)
        Me.cmd_S_SCNo.Name = "cmd_S_SCNo"
        Me.cmd_S_SCNo.Size = New System.Drawing.Size(45, 18)
        Me.cmd_S_SCNo.TabIndex = 68
        Me.cmd_S_SCNo.Text = "＞＞"
        '
        'txt_S_CustPONo
        '
        Me.txt_S_CustPONo.Location = New System.Drawing.Point(208, 208)
        Me.txt_S_CustPONo.Name = "txt_S_CustPONo"
        Me.txt_S_CustPONo.Size = New System.Drawing.Size(474, 22)
        Me.txt_S_CustPONo.TabIndex = 67
        '
        'cmd_S_CustPONo
        '
        Me.cmd_S_CustPONo.Location = New System.Drawing.Point(158, 210)
        Me.cmd_S_CustPONo.Name = "cmd_S_CustPONo"
        Me.cmd_S_CustPONo.Size = New System.Drawing.Size(45, 18)
        Me.cmd_S_CustPONo.TabIndex = 66
        Me.cmd_S_CustPONo.Text = "＞＞"
        '
        'SLabel_8
        '
        Me.SLabel_8.AutoSize = True
        Me.SLabel_8.Location = New System.Drawing.Point(13, 212)
        Me.SLabel_8.Name = "SLabel_8"
        Me.SLabel_8.Size = New System.Drawing.Size(84, 12)
        Me.SLabel_8.TabIndex = 65
        Me.SLabel_8.Text = "Customer PO No"
        '
        'txt_S_SecCustAll
        '
        Me.txt_S_SecCustAll.Location = New System.Drawing.Point(208, 42)
        Me.txt_S_SecCustAll.Name = "txt_S_SecCustAll"
        Me.txt_S_SecCustAll.Size = New System.Drawing.Size(474, 22)
        Me.txt_S_SecCustAll.TabIndex = 64
        '
        'cmd_S_SecCustAll
        '
        Me.cmd_S_SecCustAll.Location = New System.Drawing.Point(158, 42)
        Me.cmd_S_SecCustAll.Name = "cmd_S_SecCustAll"
        Me.cmd_S_SecCustAll.Size = New System.Drawing.Size(45, 18)
        Me.cmd_S_SecCustAll.TabIndex = 63
        Me.cmd_S_SecCustAll.Text = "＞＞"
        '
        'txt_S_PriCustAll
        '
        Me.txt_S_PriCustAll.Location = New System.Drawing.Point(208, 15)
        Me.txt_S_PriCustAll.Name = "txt_S_PriCustAll"
        Me.txt_S_PriCustAll.Size = New System.Drawing.Size(474, 22)
        Me.txt_S_PriCustAll.TabIndex = 62
        '
        'cmd_S_PriCustAll
        '
        Me.cmd_S_PriCustAll.Location = New System.Drawing.Point(158, 15)
        Me.cmd_S_PriCustAll.Name = "cmd_S_PriCustAll"
        Me.cmd_S_PriCustAll.Size = New System.Drawing.Size(45, 18)
        Me.cmd_S_PriCustAll.TabIndex = 61
        Me.cmd_S_PriCustAll.Text = "＞＞"
        '
        'txtPOShipDateTo
        '
        Me.txtPOShipDateTo.Location = New System.Drawing.Point(444, 282)
        Me.txtPOShipDateTo.Mask = "##/##/####"
        Me.txtPOShipDateTo.Name = "txtPOShipDateTo"
        Me.txtPOShipDateTo.Size = New System.Drawing.Size(164, 22)
        Me.txtPOShipDateTo.TabIndex = 24
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(412, 288)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(18, 12)
        Me.Label41.TabIndex = 46
        Me.Label41.Text = "To"
        '
        'txtPOShipDateFm
        '
        Me.txtPOShipDateFm.Location = New System.Drawing.Point(230, 282)
        Me.txtPOShipDateFm.Mask = "##/##/####"
        Me.txtPOShipDateFm.Name = "txtPOShipDateFm"
        Me.txtPOShipDateFm.Size = New System.Drawing.Size(161, 22)
        Me.txtPOShipDateFm.TabIndex = 23
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(179, 287)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(30, 12)
        Me.Label30.TabIndex = 24
        Me.Label30.Text = "From"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(13, 288)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(138, 12)
        Me.Label16.TabIndex = 10
        Me.Label16.Text = "PO Ship Date (mm/dd/yyyy)"
        '
        'SLabel_5
        '
        Me.SLabel_5.AutoSize = True
        Me.SLabel_5.Location = New System.Drawing.Point(13, 128)
        Me.SLabel_5.Name = "SLabel_5"
        Me.SLabel_5.Size = New System.Drawing.Size(19, 12)
        Me.SLabel_5.TabIndex = 7
        Me.SLabel_5.Text = "FA"
        '
        'SLabel_3
        '
        Me.SLabel_3.AutoSize = True
        Me.SLabel_3.Location = New System.Drawing.Point(13, 73)
        Me.SLabel_3.Name = "SLabel_3"
        Me.SLabel_3.Size = New System.Drawing.Size(19, 12)
        Me.SLabel_3.TabIndex = 6
        Me.SLabel_3.Text = "PV"
        '
        'SLabel_6
        '
        Me.SLabel_6.AutoSize = True
        Me.SLabel_6.Location = New System.Drawing.Point(13, 157)
        Me.SLabel_6.Name = "SLabel_6"
        Me.SLabel_6.Size = New System.Drawing.Size(36, 12)
        Me.SLabel_6.TabIndex = 3
        Me.SLabel_6.Text = "SC No"
        '
        'SLabel_2
        '
        Me.SLabel_2.AutoSize = True
        Me.SLabel_2.Location = New System.Drawing.Point(13, 46)
        Me.SLabel_2.Name = "SLabel_2"
        Me.SLabel_2.Size = New System.Drawing.Size(119, 12)
        Me.SLabel_2.TabIndex = 1
        Me.SLabel_2.Text = "Secondary Customer No"
        '
        'SLabel_1
        '
        Me.SLabel_1.AutoSize = True
        Me.SLabel_1.Location = New System.Drawing.Point(13, 18)
        Me.SLabel_1.Name = "SLabel_1"
        Me.SLabel_1.Size = New System.Drawing.Size(107, 12)
        Me.SLabel_1.TabIndex = 0
        Me.SLabel_1.Text = "Primary Customer No"
        '
        'QCM00006
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(714, 471)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cboCocde)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox_Search)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "QCM00006"
        Me.Text = "QCM00006 - Export QC Inspection Request CheckList (QCM06)"
        Me.GroupBox_Search.ResumeLayout(False)
        Me.GroupBox_Search.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboCocde As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox_Search As System.Windows.Forms.GroupBox
    Friend WithEvents txtSCShipDateTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtSCShipDateFm As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txt_S_PONo As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_PONo As System.Windows.Forms.Button
    Friend WithEvents SLabel_7 As System.Windows.Forms.Label
    Friend WithEvents txt_S_CV As System.Windows.Forms.TextBox
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents cmd_S_CV As System.Windows.Forms.Button
    Friend WithEvents SLabel_4 As System.Windows.Forms.Label
    Friend WithEvents txt_S_FA As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_FA As System.Windows.Forms.Button
    Friend WithEvents txt_S_PV As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_PV As System.Windows.Forms.Button
    Friend WithEvents txt_S_SCNo As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_SCNo As System.Windows.Forms.Button
    Friend WithEvents txt_S_CustPONo As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_CustPONo As System.Windows.Forms.Button
    Friend WithEvents SLabel_8 As System.Windows.Forms.Label
    Friend WithEvents txt_S_SecCustAll As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_SecCustAll As System.Windows.Forms.Button
    Friend WithEvents txt_S_PriCustAll As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_PriCustAll As System.Windows.Forms.Button
    Friend WithEvents txtPOShipDateTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents txtPOShipDateFm As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents SLabel_5 As System.Windows.Forms.Label
    Friend WithEvents SLabel_3 As System.Windows.Forms.Label
    Friend WithEvents SLabel_6 As System.Windows.Forms.Label
    Friend WithEvents SLabel_2 As System.Windows.Forms.Label
    Friend WithEvents SLabel_1 As System.Windows.Forms.Label
End Class
