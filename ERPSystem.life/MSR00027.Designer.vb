<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MSR00027
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MSR00027))
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cb_sort = New System.Windows.Forms.ComboBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.cmdShow = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txt_S_CustPONo = New System.Windows.Forms.TextBox
        Me.cmd_S_CustPONo = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtETDTo = New System.Windows.Forms.MaskedTextBox
        Me.txtETDFm = New System.Windows.Forms.MaskedTextBox
        Me.txt_S_PriceTerm = New System.Windows.Forms.TextBox
        Me.txt_S_CustItmNo = New System.Windows.Forms.TextBox
        Me.txt_S_ItmNo = New System.Windows.Forms.TextBox
        Me.txt_S_SCNo = New System.Windows.Forms.TextBox
        Me.txt_S_SecCustAll = New System.Windows.Forms.TextBox
        Me.txt_S_PriCustAll = New System.Windows.Forms.TextBox
        Me.cmd_S_PriceTerm = New System.Windows.Forms.Button
        Me.cmd_S_CustItmNo = New System.Windows.Forms.Button
        Me.cmd_S_ItmNo = New System.Windows.Forms.Button
        Me.cmd_S_SCNo = New System.Windows.Forms.Button
        Me.cmd_S_SecCustAll = New System.Windows.Forms.Button
        Me.cmd_S_PriCustAll = New System.Windows.Forms.Button
        Me.cmd_S_ContainNo = New System.Windows.Forms.Button
        Me.txt_S_ContainNo = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(211, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(249, 25)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Container Search Report"
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.Color.White
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.Location = New System.Drawing.Point(348, 60)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.Size = New System.Drawing.Size(345, 22)
        Me.txtCoNam.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(244, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 12)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Company Name:"
        '
        'cboCoCde
        '
        Me.cboCoCde.BackColor = System.Drawing.Color.White
        Me.cboCoCde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(133, 61)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(87, 20)
        Me.cboCoCde.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(23, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 12)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Company Code"
        '
        'cb_sort
        '
        Me.cb_sort.BackColor = System.Drawing.Color.White
        Me.cb_sort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_sort.FormattingEnabled = True
        Me.cb_sort.Location = New System.Drawing.Point(199, 378)
        Me.cb_sort.Name = "cb_sort"
        Me.cb_sort.Size = New System.Drawing.Size(104, 20)
        Me.cb_sort.TabIndex = 15
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(25, 381)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(41, 12)
        Me.Label19.TabIndex = 8
        Me.Label19.Text = "Sort By"
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(284, 416)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(145, 25)
        Me.cmdShow.TabIndex = 19
        Me.cmdShow.Text = "Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(23, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 12)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Container No"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(23, 129)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(107, 12)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Primary Customer No"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(23, 191)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 12)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "SC No"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(23, 220)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(43, 12)
        Me.Label13.TabIndex = 27
        Me.Label13.Text = "Item No"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(23, 249)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(91, 12)
        Me.Label16.TabIndex = 32
        Me.Label16.Text = "Customer Item No"
        '
        'txt_S_CustPONo
        '
        Me.txt_S_CustPONo.Location = New System.Drawing.Point(247, 303)
        Me.txt_S_CustPONo.Name = "txt_S_CustPONo"
        Me.txt_S_CustPONo.Size = New System.Drawing.Size(424, 22)
        Me.txt_S_CustPONo.TabIndex = 91
        '
        'cmd_S_CustPONo
        '
        Me.cmd_S_CustPONo.Location = New System.Drawing.Point(196, 303)
        Me.cmd_S_CustPONo.Name = "cmd_S_CustPONo"
        Me.cmd_S_CustPONo.Size = New System.Drawing.Size(45, 18)
        Me.cmd_S_CustPONo.TabIndex = 90
        Me.cmd_S_CustPONo.Text = "＞＞"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(23, 162)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(119, 12)
        Me.Label12.TabIndex = 89
        Me.Label12.Text = "Secondary Customer No"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(355, 343)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(24, 12)
        Me.Label11.TabIndex = 88
        Me.Label11.Text = "To :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(141, 343)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(36, 12)
        Me.Label9.TabIndex = 87
        Me.Label9.Text = "From :"
        '
        'txtETDTo
        '
        Me.txtETDTo.Location = New System.Drawing.Point(385, 339)
        Me.txtETDTo.Mask = "##/##/####"
        Me.txtETDTo.Name = "txtETDTo"
        Me.txtETDTo.Size = New System.Drawing.Size(114, 22)
        Me.txtETDTo.TabIndex = 86
        '
        'txtETDFm
        '
        Me.txtETDFm.Location = New System.Drawing.Point(197, 339)
        Me.txtETDFm.Mask = "##/##/####"
        Me.txtETDFm.Name = "txtETDFm"
        Me.txtETDFm.Size = New System.Drawing.Size(114, 22)
        Me.txtETDFm.TabIndex = 85
        '
        'txt_S_PriceTerm
        '
        Me.txt_S_PriceTerm.Location = New System.Drawing.Point(247, 273)
        Me.txt_S_PriceTerm.Name = "txt_S_PriceTerm"
        Me.txt_S_PriceTerm.Size = New System.Drawing.Size(424, 22)
        Me.txt_S_PriceTerm.TabIndex = 77
        '
        'txt_S_CustItmNo
        '
        Me.txt_S_CustItmNo.Location = New System.Drawing.Point(247, 245)
        Me.txt_S_CustItmNo.Name = "txt_S_CustItmNo"
        Me.txt_S_CustItmNo.Size = New System.Drawing.Size(424, 22)
        Me.txt_S_CustItmNo.TabIndex = 76
        '
        'txt_S_ItmNo
        '
        Me.txt_S_ItmNo.Location = New System.Drawing.Point(247, 216)
        Me.txt_S_ItmNo.Name = "txt_S_ItmNo"
        Me.txt_S_ItmNo.Size = New System.Drawing.Size(424, 22)
        Me.txt_S_ItmNo.TabIndex = 75
        '
        'txt_S_SCNo
        '
        Me.txt_S_SCNo.Location = New System.Drawing.Point(247, 187)
        Me.txt_S_SCNo.Name = "txt_S_SCNo"
        Me.txt_S_SCNo.Size = New System.Drawing.Size(424, 22)
        Me.txt_S_SCNo.TabIndex = 74
        '
        'txt_S_SecCustAll
        '
        Me.txt_S_SecCustAll.Location = New System.Drawing.Point(247, 158)
        Me.txt_S_SecCustAll.Name = "txt_S_SecCustAll"
        Me.txt_S_SecCustAll.Size = New System.Drawing.Size(424, 22)
        Me.txt_S_SecCustAll.TabIndex = 73
        '
        'txt_S_PriCustAll
        '
        Me.txt_S_PriCustAll.Location = New System.Drawing.Point(247, 129)
        Me.txt_S_PriCustAll.Name = "txt_S_PriCustAll"
        Me.txt_S_PriCustAll.Size = New System.Drawing.Size(424, 22)
        Me.txt_S_PriCustAll.TabIndex = 72
        '
        'cmd_S_PriceTerm
        '
        Me.cmd_S_PriceTerm.Location = New System.Drawing.Point(196, 273)
        Me.cmd_S_PriceTerm.Name = "cmd_S_PriceTerm"
        Me.cmd_S_PriceTerm.Size = New System.Drawing.Size(45, 18)
        Me.cmd_S_PriceTerm.TabIndex = 70
        Me.cmd_S_PriceTerm.Text = "＞＞"
        '
        'cmd_S_CustItmNo
        '
        Me.cmd_S_CustItmNo.Location = New System.Drawing.Point(196, 245)
        Me.cmd_S_CustItmNo.Name = "cmd_S_CustItmNo"
        Me.cmd_S_CustItmNo.Size = New System.Drawing.Size(45, 18)
        Me.cmd_S_CustItmNo.TabIndex = 69
        Me.cmd_S_CustItmNo.Text = "＞＞"
        '
        'cmd_S_ItmNo
        '
        Me.cmd_S_ItmNo.Location = New System.Drawing.Point(196, 217)
        Me.cmd_S_ItmNo.Name = "cmd_S_ItmNo"
        Me.cmd_S_ItmNo.Size = New System.Drawing.Size(45, 18)
        Me.cmd_S_ItmNo.TabIndex = 68
        Me.cmd_S_ItmNo.Text = "＞＞"
        '
        'cmd_S_SCNo
        '
        Me.cmd_S_SCNo.Location = New System.Drawing.Point(196, 188)
        Me.cmd_S_SCNo.Name = "cmd_S_SCNo"
        Me.cmd_S_SCNo.Size = New System.Drawing.Size(45, 18)
        Me.cmd_S_SCNo.TabIndex = 67
        Me.cmd_S_SCNo.Text = "＞＞"
        '
        'cmd_S_SecCustAll
        '
        Me.cmd_S_SecCustAll.Location = New System.Drawing.Point(196, 158)
        Me.cmd_S_SecCustAll.Name = "cmd_S_SecCustAll"
        Me.cmd_S_SecCustAll.Size = New System.Drawing.Size(45, 18)
        Me.cmd_S_SecCustAll.TabIndex = 66
        Me.cmd_S_SecCustAll.Text = "＞＞"
        '
        'cmd_S_PriCustAll
        '
        Me.cmd_S_PriCustAll.Location = New System.Drawing.Point(196, 128)
        Me.cmd_S_PriCustAll.Name = "cmd_S_PriCustAll"
        Me.cmd_S_PriCustAll.Size = New System.Drawing.Size(45, 18)
        Me.cmd_S_PriCustAll.TabIndex = 65
        Me.cmd_S_PriCustAll.Text = "＞＞"
        '
        'cmd_S_ContainNo
        '
        Me.cmd_S_ContainNo.Location = New System.Drawing.Point(196, 99)
        Me.cmd_S_ContainNo.Name = "cmd_S_ContainNo"
        Me.cmd_S_ContainNo.Size = New System.Drawing.Size(45, 18)
        Me.cmd_S_ContainNo.TabIndex = 64
        Me.cmd_S_ContainNo.Text = "＞＞"
        '
        'txt_S_ContainNo
        '
        Me.txt_S_ContainNo.Location = New System.Drawing.Point(247, 98)
        Me.txt_S_ContainNo.Name = "txt_S_ContainNo"
        Me.txt_S_ContainNo.Size = New System.Drawing.Size(424, 22)
        Me.txt_S_ContainNo.TabIndex = 63
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(23, 343)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(122, 12)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "ETD Date (mm/dd/yyyy)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 307)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 12)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Customer PO"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 277)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 12)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Price Terms"
        '
        'MSR00027
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(714, 471)
        Me.Controls.Add(Me.txt_S_CustPONo)
        Me.Controls.Add(Me.cb_sort)
        Me.Controls.Add(Me.cmd_S_CustPONo)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.txtETDTo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtETDFm)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.txt_S_PriceTerm)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_S_CustItmNo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_S_ItmNo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt_S_SCNo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txt_S_SecCustAll)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txt_S_PriCustAll)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.cmd_S_PriceTerm)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.cmd_S_CustItmNo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmd_S_ItmNo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmd_S_SCNo)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cmd_S_SecCustAll)
        Me.Controls.Add(Me.txt_S_ContainNo)
        Me.Controls.Add(Me.cmd_S_PriCustAll)
        Me.Controls.Add(Me.cmd_S_ContainNo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MSR00027"
        Me.Text = "MSR00027 - Container Search Report (MSR27)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cb_sort As System.Windows.Forms.ComboBox
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_S_ContainNo As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_ContainNo As System.Windows.Forms.Button
    Friend WithEvents txt_S_PriCustAll As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_PriceTerm As System.Windows.Forms.Button
    Friend WithEvents cmd_S_CustItmNo As System.Windows.Forms.Button
    Friend WithEvents cmd_S_ItmNo As System.Windows.Forms.Button
    Friend WithEvents cmd_S_SCNo As System.Windows.Forms.Button
    Friend WithEvents cmd_S_SecCustAll As System.Windows.Forms.Button
    Friend WithEvents cmd_S_PriCustAll As System.Windows.Forms.Button
    Friend WithEvents txt_S_SCNo As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_SecCustAll As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_PriceTerm As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_CustItmNo As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_ItmNo As System.Windows.Forms.TextBox
    Friend WithEvents txtETDFm As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtETDTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txt_S_CustPONo As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_CustPONo As System.Windows.Forms.Button
End Class
