<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QCM00005
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(QCM00005))
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboCocde = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox_Search = New System.Windows.Forms.GroupBox
        Me.cbo_status = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_DateTo = New System.Windows.Forms.MaskedTextBox
        Me.Label41 = New System.Windows.Forms.Label
        Me.txt_DateFm = New System.Windows.Forms.MaskedTextBox
        Me.cbo_insptype = New System.Windows.Forms.ComboBox
        Me.cbo_inspyear = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_WeekTo = New System.Windows.Forms.TextBox
        Me.cmdShow = New System.Windows.Forms.Button
        Me.SLabel_4 = New System.Windows.Forms.Label
        Me.txt_WeekFm = New System.Windows.Forms.TextBox
        Me.txt_S_PV = New System.Windows.Forms.TextBox
        Me.cmd_S_PV = New System.Windows.Forms.Button
        Me.txt_S_SecCustAll = New System.Windows.Forms.TextBox
        Me.cmd_S_SecCustAll = New System.Windows.Forms.Button
        Me.txt_S_PriCustAll = New System.Windows.Forms.TextBox
        Me.cmd_S_PriCustAll = New System.Windows.Forms.Button
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
        Me.txtCoNam.Location = New System.Drawing.Point(331, 25)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.Size = New System.Drawing.Size(302, 22)
        Me.txtCoNam.TabIndex = 53
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(236, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 12)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "Company Name"
        '
        'cboCocde
        '
        Me.cboCocde.FormattingEnabled = True
        Me.cboCocde.Location = New System.Drawing.Point(136, 26)
        Me.cboCocde.Name = "cboCocde"
        Me.cboCocde.Size = New System.Drawing.Size(70, 20)
        Me.cboCocde.TabIndex = 52
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(45, 29)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 12)
        Me.Label7.TabIndex = 54
        Me.Label7.Text = "Company Code"
        '
        'GroupBox_Search
        '
        Me.GroupBox_Search.Controls.Add(Me.cbo_status)
        Me.GroupBox_Search.Controls.Add(Me.Label3)
        Me.GroupBox_Search.Controls.Add(Me.Label2)
        Me.GroupBox_Search.Controls.Add(Me.txt_DateTo)
        Me.GroupBox_Search.Controls.Add(Me.Label41)
        Me.GroupBox_Search.Controls.Add(Me.txt_DateFm)
        Me.GroupBox_Search.Controls.Add(Me.cbo_insptype)
        Me.GroupBox_Search.Controls.Add(Me.cbo_inspyear)
        Me.GroupBox_Search.Controls.Add(Me.Label6)
        Me.GroupBox_Search.Controls.Add(Me.txt_WeekTo)
        Me.GroupBox_Search.Controls.Add(Me.cmdShow)
        Me.GroupBox_Search.Controls.Add(Me.SLabel_4)
        Me.GroupBox_Search.Controls.Add(Me.txt_WeekFm)
        Me.GroupBox_Search.Controls.Add(Me.txt_S_PV)
        Me.GroupBox_Search.Controls.Add(Me.cmd_S_PV)
        Me.GroupBox_Search.Controls.Add(Me.txt_S_SecCustAll)
        Me.GroupBox_Search.Controls.Add(Me.cmd_S_SecCustAll)
        Me.GroupBox_Search.Controls.Add(Me.txt_S_PriCustAll)
        Me.GroupBox_Search.Controls.Add(Me.cmd_S_PriCustAll)
        Me.GroupBox_Search.Controls.Add(Me.SLabel_5)
        Me.GroupBox_Search.Controls.Add(Me.SLabel_3)
        Me.GroupBox_Search.Controls.Add(Me.SLabel_6)
        Me.GroupBox_Search.Controls.Add(Me.SLabel_2)
        Me.GroupBox_Search.Controls.Add(Me.SLabel_1)
        Me.GroupBox_Search.Location = New System.Drawing.Point(11, 59)
        Me.GroupBox_Search.Name = "GroupBox_Search"
        Me.GroupBox_Search.Size = New System.Drawing.Size(690, 400)
        Me.GroupBox_Search.TabIndex = 51
        Me.GroupBox_Search.TabStop = False
        '
        'cbo_status
        '
        Me.cbo_status.BackColor = System.Drawing.Color.White
        Me.cbo_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_status.FormattingEnabled = True
        Me.cbo_status.Location = New System.Drawing.Point(154, 225)
        Me.cbo_status.Name = "cbo_status"
        Me.cbo_status.Size = New System.Drawing.Size(193, 20)
        Me.cbo_status.TabIndex = 330
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 229)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 12)
        Me.Label3.TabIndex = 329
        Me.Label3.Text = "Inspection Status"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 142)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 12)
        Me.Label2.TabIndex = 328
        Me.Label2.Text = "Inspection Date From"
        '
        'txt_DateTo
        '
        Me.txt_DateTo.Location = New System.Drawing.Point(470, 138)
        Me.txt_DateTo.Mask = "##/##/####"
        Me.txt_DateTo.Name = "txt_DateTo"
        Me.txt_DateTo.Size = New System.Drawing.Size(204, 22)
        Me.txt_DateTo.TabIndex = 326
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(357, 143)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(93, 12)
        Me.Label41.TabIndex = 327
        Me.Label41.Text = "Inspection Date To"
        '
        'txt_DateFm
        '
        Me.txt_DateFm.Location = New System.Drawing.Point(154, 138)
        Me.txt_DateFm.Mask = "##/##/####"
        Me.txt_DateFm.Name = "txt_DateFm"
        Me.txt_DateFm.Size = New System.Drawing.Size(193, 22)
        Me.txt_DateFm.TabIndex = 324
        '
        'cbo_insptype
        '
        Me.cbo_insptype.BackColor = System.Drawing.Color.White
        Me.cbo_insptype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_insptype.FormattingEnabled = True
        Me.cbo_insptype.Location = New System.Drawing.Point(154, 196)
        Me.cbo_insptype.Name = "cbo_insptype"
        Me.cbo_insptype.Size = New System.Drawing.Size(193, 20)
        Me.cbo_insptype.TabIndex = 323
        '
        'cbo_inspyear
        '
        Me.cbo_inspyear.BackColor = System.Drawing.Color.White
        Me.cbo_inspyear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_inspyear.FormattingEnabled = True
        Me.cbo_inspyear.Location = New System.Drawing.Point(154, 109)
        Me.cbo_inspyear.Name = "cbo_inspyear"
        Me.cbo_inspyear.Size = New System.Drawing.Size(193, 20)
        Me.cbo_inspyear.TabIndex = 322
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(357, 169)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 12)
        Me.Label6.TabIndex = 87
        Me.Label6.Text = "Inspection Week To"
        '
        'txt_WeekTo
        '
        Me.txt_WeekTo.Location = New System.Drawing.Point(470, 166)
        Me.txt_WeekTo.Name = "txt_WeekTo"
        Me.txt_WeekTo.Size = New System.Drawing.Size(204, 22)
        Me.txt_WeekTo.TabIndex = 86
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(308, 281)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(75, 21)
        Me.cmdShow.TabIndex = 41
        Me.cmdShow.Text = "Generate"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'SLabel_4
        '
        Me.SLabel_4.AutoSize = True
        Me.SLabel_4.Location = New System.Drawing.Point(19, 115)
        Me.SLabel_4.Name = "SLabel_4"
        Me.SLabel_4.Size = New System.Drawing.Size(78, 12)
        Me.SLabel_4.TabIndex = 83
        Me.SLabel_4.Text = "Inspection Year"
        '
        'txt_WeekFm
        '
        Me.txt_WeekFm.Location = New System.Drawing.Point(154, 166)
        Me.txt_WeekFm.Name = "txt_WeekFm"
        Me.txt_WeekFm.Size = New System.Drawing.Size(193, 22)
        Me.txt_WeekFm.TabIndex = 77
        '
        'txt_S_PV
        '
        Me.txt_S_PV.Location = New System.Drawing.Point(205, 80)
        Me.txt_S_PV.Name = "txt_S_PV"
        Me.txt_S_PV.Size = New System.Drawing.Size(469, 22)
        Me.txt_S_PV.TabIndex = 75
        '
        'cmd_S_PV
        '
        Me.cmd_S_PV.Location = New System.Drawing.Point(155, 81)
        Me.cmd_S_PV.Name = "cmd_S_PV"
        Me.cmd_S_PV.Size = New System.Drawing.Size(45, 18)
        Me.cmd_S_PV.TabIndex = 74
        Me.cmd_S_PV.Text = "＞＞"
        '
        'txt_S_SecCustAll
        '
        Me.txt_S_SecCustAll.Location = New System.Drawing.Point(205, 51)
        Me.txt_S_SecCustAll.Name = "txt_S_SecCustAll"
        Me.txt_S_SecCustAll.Size = New System.Drawing.Size(469, 22)
        Me.txt_S_SecCustAll.TabIndex = 64
        '
        'cmd_S_SecCustAll
        '
        Me.cmd_S_SecCustAll.Location = New System.Drawing.Point(155, 51)
        Me.cmd_S_SecCustAll.Name = "cmd_S_SecCustAll"
        Me.cmd_S_SecCustAll.Size = New System.Drawing.Size(45, 18)
        Me.cmd_S_SecCustAll.TabIndex = 63
        Me.cmd_S_SecCustAll.Text = "＞＞"
        '
        'txt_S_PriCustAll
        '
        Me.txt_S_PriCustAll.Location = New System.Drawing.Point(204, 19)
        Me.txt_S_PriCustAll.Name = "txt_S_PriCustAll"
        Me.txt_S_PriCustAll.Size = New System.Drawing.Size(469, 22)
        Me.txt_S_PriCustAll.TabIndex = 62
        '
        'cmd_S_PriCustAll
        '
        Me.cmd_S_PriCustAll.Location = New System.Drawing.Point(154, 19)
        Me.cmd_S_PriCustAll.Name = "cmd_S_PriCustAll"
        Me.cmd_S_PriCustAll.Size = New System.Drawing.Size(45, 18)
        Me.cmd_S_PriCustAll.TabIndex = 61
        Me.cmd_S_PriCustAll.Text = "＞＞"
        '
        'SLabel_5
        '
        Me.SLabel_5.AutoSize = True
        Me.SLabel_5.Location = New System.Drawing.Point(19, 170)
        Me.SLabel_5.Name = "SLabel_5"
        Me.SLabel_5.Size = New System.Drawing.Size(111, 12)
        Me.SLabel_5.TabIndex = 7
        Me.SLabel_5.Text = "Inspection Week From"
        '
        'SLabel_3
        '
        Me.SLabel_3.AutoSize = True
        Me.SLabel_3.Location = New System.Drawing.Point(20, 85)
        Me.SLabel_3.Name = "SLabel_3"
        Me.SLabel_3.Size = New System.Drawing.Size(40, 12)
        Me.SLabel_3.TabIndex = 6
        Me.SLabel_3.Text = "Vendor"
        '
        'SLabel_6
        '
        Me.SLabel_6.AutoSize = True
        Me.SLabel_6.Location = New System.Drawing.Point(19, 200)
        Me.SLabel_6.Name = "SLabel_6"
        Me.SLabel_6.Size = New System.Drawing.Size(80, 12)
        Me.SLabel_6.TabIndex = 3
        Me.SLabel_6.Text = "Inspection Type"
        '
        'SLabel_2
        '
        Me.SLabel_2.AutoSize = True
        Me.SLabel_2.Location = New System.Drawing.Point(19, 55)
        Me.SLabel_2.Name = "SLabel_2"
        Me.SLabel_2.Size = New System.Drawing.Size(119, 12)
        Me.SLabel_2.TabIndex = 1
        Me.SLabel_2.Text = "Secondary Customer No"
        '
        'SLabel_1
        '
        Me.SLabel_1.AutoSize = True
        Me.SLabel_1.Location = New System.Drawing.Point(18, 24)
        Me.SLabel_1.Name = "SLabel_1"
        Me.SLabel_1.Size = New System.Drawing.Size(107, 12)
        Me.SLabel_1.TabIndex = 0
        Me.SLabel_1.Text = "Primary Customer No"
        '
        'QCM00005
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(714, 471)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboCocde)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox_Search)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "QCM00005"
        Me.Text = "QCM00005 - Export QC Inspection Request List (QCM05)"
        Me.GroupBox_Search.ResumeLayout(False)
        Me.GroupBox_Search.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboCocde As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox_Search As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_status As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_DateTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents txt_DateFm As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cbo_insptype As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_inspyear As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_WeekTo As System.Windows.Forms.TextBox
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents SLabel_4 As System.Windows.Forms.Label
    Friend WithEvents txt_WeekFm As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_PV As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_PV As System.Windows.Forms.Button
    Friend WithEvents txt_S_SecCustAll As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_SecCustAll As System.Windows.Forms.Button
    Friend WithEvents txt_S_PriCustAll As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_PriCustAll As System.Windows.Forms.Button
    Friend WithEvents SLabel_5 As System.Windows.Forms.Label
    Friend WithEvents SLabel_3 As System.Windows.Forms.Label
    Friend WithEvents SLabel_6 As System.Windows.Forms.Label
    Friend WithEvents SLabel_2 As System.Windows.Forms.Label
    Friend WithEvents SLabel_1 As System.Windows.Forms.Label
End Class
