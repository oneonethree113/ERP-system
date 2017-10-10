<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RIR00001
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RIR00001))
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboCocde = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_S_QutNo = New System.Windows.Forms.TextBox
        Me.cmd_S_QutNo = New System.Windows.Forms.Button
        Me.txtQutdatTo = New System.Windows.Forms.MaskedTextBox
        Me.Label41 = New System.Windows.Forms.Label
        Me.txtQutdatFm = New System.Windows.Forms.MaskedTextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.SLabel_3 = New System.Windows.Forms.Label
        Me.txt_S_SecCustAll = New System.Windows.Forms.TextBox
        Me.cmd_S_SecCustAll = New System.Windows.Forms.Button
        Me.txt_S_PriCustAll = New System.Windows.Forms.TextBox
        Me.cmd_S_PriCustAll = New System.Windows.Forms.Button
        Me.SLabel_2 = New System.Windows.Forms.Label
        Me.SLabel_1 = New System.Windows.Forms.Label
        Me.cmdShow = New System.Windows.Forms.Button
        Me.Label37 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'txtCoNam
        '
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.Location = New System.Drawing.Point(324, 43)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.Size = New System.Drawing.Size(302, 22)
        Me.txtCoNam.TabIndex = 41
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(231, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 12)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "Company Name"
        '
        'cboCocde
        '
        Me.cboCocde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCocde.FormattingEnabled = True
        Me.cboCocde.Location = New System.Drawing.Point(112, 43)
        Me.cboCocde.Name = "cboCocde"
        Me.cboCocde.Size = New System.Drawing.Size(107, 20)
        Me.cboCocde.TabIndex = 39
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(13, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 12)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "Company Code"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(231, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(183, 24)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Requote Item Report"
        '
        'txt_S_QutNo
        '
        Me.txt_S_QutNo.Location = New System.Drawing.Point(223, 143)
        Me.txt_S_QutNo.Name = "txt_S_QutNo"
        Me.txt_S_QutNo.Size = New System.Drawing.Size(403, 22)
        Me.txt_S_QutNo.TabIndex = 78
        '
        'cmd_S_QutNo
        '
        Me.cmd_S_QutNo.Location = New System.Drawing.Point(173, 143)
        Me.cmd_S_QutNo.Name = "cmd_S_QutNo"
        Me.cmd_S_QutNo.Size = New System.Drawing.Size(45, 22)
        Me.cmd_S_QutNo.TabIndex = 77
        Me.cmd_S_QutNo.Text = "＞＞"
        '
        'txtQutdatTo
        '
        Me.txtQutdatTo.Location = New System.Drawing.Point(468, 175)
        Me.txtQutdatTo.Mask = "##/##/####"
        Me.txtQutdatTo.Name = "txtQutdatTo"
        Me.txtQutdatTo.Size = New System.Drawing.Size(68, 22)
        Me.txtQutdatTo.TabIndex = 74
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(434, 178)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(18, 12)
        Me.Label41.TabIndex = 76
        Me.Label41.Text = "To"
        '
        'txtQutdatFm
        '
        Me.txtQutdatFm.Location = New System.Drawing.Point(223, 175)
        Me.txtQutdatFm.Mask = "##/##/####"
        Me.txtQutdatFm.Name = "txtQutdatFm"
        Me.txtQutdatFm.Size = New System.Drawing.Size(68, 22)
        Me.txtQutdatFm.TabIndex = 73
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(172, 178)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(30, 12)
        Me.Label30.TabIndex = 75
        Me.Label30.Text = "From"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(13, 178)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(108, 12)
        Me.Label16.TabIndex = 72
        Me.Label16.Text = "Quotation Create Date"
        '
        'SLabel_3
        '
        Me.SLabel_3.AutoSize = True
        Me.SLabel_3.Location = New System.Drawing.Point(13, 146)
        Me.SLabel_3.Name = "SLabel_3"
        Me.SLabel_3.Size = New System.Drawing.Size(71, 12)
        Me.SLabel_3.TabIndex = 71
        Me.SLabel_3.Text = "Quotation No."
        '
        'txt_S_SecCustAll
        '
        Me.txt_S_SecCustAll.Location = New System.Drawing.Point(223, 111)
        Me.txt_S_SecCustAll.Name = "txt_S_SecCustAll"
        Me.txt_S_SecCustAll.Size = New System.Drawing.Size(403, 22)
        Me.txt_S_SecCustAll.TabIndex = 70
        '
        'cmd_S_SecCustAll
        '
        Me.cmd_S_SecCustAll.Location = New System.Drawing.Point(173, 111)
        Me.cmd_S_SecCustAll.Name = "cmd_S_SecCustAll"
        Me.cmd_S_SecCustAll.Size = New System.Drawing.Size(45, 22)
        Me.cmd_S_SecCustAll.TabIndex = 69
        Me.cmd_S_SecCustAll.Text = "＞＞"
        '
        'txt_S_PriCustAll
        '
        Me.txt_S_PriCustAll.Location = New System.Drawing.Point(223, 79)
        Me.txt_S_PriCustAll.Name = "txt_S_PriCustAll"
        Me.txt_S_PriCustAll.Size = New System.Drawing.Size(403, 22)
        Me.txt_S_PriCustAll.TabIndex = 68
        '
        'cmd_S_PriCustAll
        '
        Me.cmd_S_PriCustAll.Location = New System.Drawing.Point(173, 79)
        Me.cmd_S_PriCustAll.Name = "cmd_S_PriCustAll"
        Me.cmd_S_PriCustAll.Size = New System.Drawing.Size(45, 22)
        Me.cmd_S_PriCustAll.TabIndex = 67
        Me.cmd_S_PriCustAll.Text = "＞＞"
        '
        'SLabel_2
        '
        Me.SLabel_2.AutoSize = True
        Me.SLabel_2.Location = New System.Drawing.Point(13, 114)
        Me.SLabel_2.Name = "SLabel_2"
        Me.SLabel_2.Size = New System.Drawing.Size(122, 12)
        Me.SLabel_2.TabIndex = 66
        Me.SLabel_2.Text = "Secondary Customer No."
        '
        'SLabel_1
        '
        Me.SLabel_1.AutoSize = True
        Me.SLabel_1.Location = New System.Drawing.Point(13, 82)
        Me.SLabel_1.Name = "SLabel_1"
        Me.SLabel_1.Size = New System.Drawing.Size(110, 12)
        Me.SLabel_1.TabIndex = 65
        Me.SLabel_1.Text = "Primary Customer No."
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(259, 244)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(140, 22)
        Me.cmdShow.TabIndex = 47
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(293, 178)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(87, 12)
        Me.Label37.TabIndex = 375
        Me.Label37.Text = "(MM/DD/YYYY)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(539, 178)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 12)
        Me.Label3.TabIndex = 376
        Me.Label3.Text = "(MM/DD/YYYY)"
        '
        'RIR00001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 271)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.txt_S_QutNo)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.cmd_S_QutNo)
        Me.Controls.Add(Me.txtQutdatTo)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtQutdatFm)
        Me.Controls.Add(Me.cboCocde)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.SLabel_3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_S_SecCustAll)
        Me.Controls.Add(Me.cmd_S_SecCustAll)
        Me.Controls.Add(Me.txt_S_PriCustAll)
        Me.Controls.Add(Me.SLabel_1)
        Me.Controls.Add(Me.cmd_S_PriCustAll)
        Me.Controls.Add(Me.SLabel_2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "RIR00001"
        Me.Text = "RIR00001 - ReQuote Item List (RIR01)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboCocde As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_S_SecCustAll As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_SecCustAll As System.Windows.Forms.Button
    Friend WithEvents txt_S_PriCustAll As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_PriCustAll As System.Windows.Forms.Button
    Friend WithEvents SLabel_2 As System.Windows.Forms.Label
    Friend WithEvents SLabel_1 As System.Windows.Forms.Label
    Friend WithEvents SLabel_3 As System.Windows.Forms.Label
    Friend WithEvents txt_S_QutNo As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_QutNo As System.Windows.Forms.Button
    Friend WithEvents txtQutdatTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents txtQutdatFm As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
