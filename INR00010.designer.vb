<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class INR00010
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboCocde = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.grpSearch = New System.Windows.Forms.GroupBox
        Me.GroupBox9 = New System.Windows.Forms.GroupBox
        Me.opt4w = New System.Windows.Forms.RadioButton
        Me.Label18 = New System.Windows.Forms.Label
        Me.opt1w = New System.Windows.Forms.RadioButton
        Me.opt2w = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtDateTo = New System.Windows.Forms.MaskedTextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtDateFrom = New System.Windows.Forms.MaskedTextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboCatlevel_To = New System.Windows.Forms.ComboBox
        Me.cboCatlevel_Fm = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.cboCatlevel = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboSCTo = New System.Windows.Forms.ComboBox
        Me.cboSCFm = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lstVendorFrom = New System.Windows.Forms.ListBox
        Me.ChkALL = New System.Windows.Forms.CheckBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmdShow = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.grpSearch.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(17, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Company Code"
        '
        'cboCocde
        '
        Me.cboCocde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCocde.FormattingEnabled = True
        Me.cboCocde.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cboCocde.Location = New System.Drawing.Point(102, 48)
        Me.cboCocde.Name = "cboCocde"
        Me.cboCocde.Size = New System.Drawing.Size(76, 21)
        Me.cboCocde.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(195, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Company Name"
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.Location = New System.Drawing.Point(283, 48)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.Size = New System.Drawing.Size(350, 20)
        Me.txtCoNam.TabIndex = 2
        '
        'grpSearch
        '
        Me.grpSearch.Controls.Add(Me.GroupBox9)
        Me.grpSearch.Controls.Add(Me.GroupBox1)
        Me.grpSearch.Controls.Add(Me.GroupBox6)
        Me.grpSearch.Controls.Add(Me.GroupBox5)
        Me.grpSearch.Controls.Add(Me.GroupBox4)
        Me.grpSearch.Controls.Add(Me.GroupBox2)
        Me.grpSearch.Location = New System.Drawing.Point(9, 70)
        Me.grpSearch.Name = "grpSearch"
        Me.grpSearch.Size = New System.Drawing.Size(649, 386)
        Me.grpSearch.TabIndex = 2
        Me.grpSearch.TabStop = False
        Me.grpSearch.Text = "Selection Criteria :"
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.opt4w)
        Me.GroupBox9.Controls.Add(Me.Label18)
        Me.GroupBox9.Controls.Add(Me.opt1w)
        Me.GroupBox9.Controls.Add(Me.opt2w)
        Me.GroupBox9.Location = New System.Drawing.Point(15, 336)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(618, 44)
        Me.GroupBox9.TabIndex = 13
        Me.GroupBox9.TabStop = False
        '
        'opt4w
        '
        Me.opt4w.AutoSize = True
        Me.opt4w.Location = New System.Drawing.Point(401, 16)
        Me.opt4w.Name = "opt4w"
        Me.opt4w.Size = New System.Drawing.Size(65, 17)
        Me.opt4w.TabIndex = 15
        Me.opt4w.Text = "4 weeks"
        Me.opt4w.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(4, 18)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(66, 13)
        Me.Label18.TabIndex = 47
        Me.Label18.Text = "Report Type"
        '
        'opt1w
        '
        Me.opt1w.AutoSize = True
        Me.opt1w.Checked = True
        Me.opt1w.Location = New System.Drawing.Point(131, 16)
        Me.opt1w.Name = "opt1w"
        Me.opt1w.Size = New System.Drawing.Size(60, 17)
        Me.opt1w.TabIndex = 13
        Me.opt1w.TabStop = True
        Me.opt1w.Text = "1 week"
        Me.opt1w.UseVisualStyleBackColor = True
        '
        'opt2w
        '
        Me.opt2w.AutoSize = True
        Me.opt2w.Location = New System.Drawing.Point(253, 16)
        Me.opt2w.Name = "opt2w"
        Me.opt2w.Size = New System.Drawing.Size(65, 17)
        Me.opt2w.TabIndex = 14
        Me.opt2w.Text = "2 weeks"
        Me.opt2w.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.txtDateTo)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.txtDateFrom)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 280)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(620, 48)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(6, 16)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(65, 13)
        Me.Label21.TabIndex = 451
        Me.Label21.Text = "Date Range"
        '
        'txtDateTo
        '
        Me.txtDateTo.Location = New System.Drawing.Point(386, 16)
        Me.txtDateTo.Mask = "##/##/####"
        Me.txtDateTo.Name = "txtDateTo"
        Me.txtDateTo.Size = New System.Drawing.Size(185, 20)
        Me.txtDateTo.TabIndex = 12
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(86, 16)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(36, 13)
        Me.Label20.TabIndex = 449
        Me.Label20.Text = "From :"
        '
        'txtDateFrom
        '
        Me.txtDateFrom.Location = New System.Drawing.Point(130, 16)
        Me.txtDateFrom.Mask = "##/##/####"
        Me.txtDateFrom.Name = "txtDateFrom"
        Me.txtDateFrom.Size = New System.Drawing.Size(185, 20)
        Me.txtDateFrom.TabIndex = 11
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(350, 16)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(26, 13)
        Me.Label19.TabIndex = 450
        Me.Label19.Text = "To :"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label4)
        Me.GroupBox6.Controls.Add(Me.Label8)
        Me.GroupBox6.Controls.Add(Me.cboCatlevel_To)
        Me.GroupBox6.Controls.Add(Me.cboCatlevel_Fm)
        Me.GroupBox6.Controls.Add(Me.Label11)
        Me.GroupBox6.Location = New System.Drawing.Point(15, 237)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(618, 40)
        Me.GroupBox6.TabIndex = 8
        Me.GroupBox6.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(85, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "From :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(5, 14)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Category Level"
        '
        'cboCatlevel_To
        '
        Me.cboCatlevel_To.FormattingEnabled = True
        Me.cboCatlevel_To.Location = New System.Drawing.Point(386, 11)
        Me.cboCatlevel_To.Name = "cboCatlevel_To"
        Me.cboCatlevel_To.Size = New System.Drawing.Size(185, 21)
        Me.cboCatlevel_To.TabIndex = 10
        '
        'cboCatlevel_Fm
        '
        Me.cboCatlevel_Fm.FormattingEnabled = True
        Me.cboCatlevel_Fm.Location = New System.Drawing.Point(130, 11)
        Me.cboCatlevel_Fm.Name = "cboCatlevel_Fm"
        Me.cboCatlevel_Fm.Size = New System.Drawing.Size(185, 21)
        Me.cboCatlevel_Fm.TabIndex = 9
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(350, 14)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(26, 13)
        Me.Label11.TabIndex = 18
        Me.Label11.Text = "To :"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cboCatlevel)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Location = New System.Drawing.Point(15, 196)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(618, 39)
        Me.GroupBox5.TabIndex = 7
        Me.GroupBox5.TabStop = False
        '
        'cboCatlevel
        '
        Me.cboCatlevel.FormattingEnabled = True
        Me.cboCatlevel.Location = New System.Drawing.Point(130, 12)
        Me.cboCatlevel.Name = "cboCatlevel"
        Me.cboCatlevel.Size = New System.Drawing.Size(185, 21)
        Me.cboCatlevel.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Category Level :"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.cboSCTo)
        Me.GroupBox4.Controls.Add(Me.cboSCFm)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Location = New System.Drawing.Point(15, 155)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(618, 40)
        Me.GroupBox4.TabIndex = 5
        Me.GroupBox4.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(85, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "From :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Sub-Code"
        '
        'cboSCTo
        '
        Me.cboSCTo.FormattingEnabled = True
        Me.cboSCTo.Location = New System.Drawing.Point(386, 12)
        Me.cboSCTo.Name = "cboSCTo"
        Me.cboSCTo.Size = New System.Drawing.Size(185, 21)
        Me.cboSCTo.TabIndex = 6
        '
        'cboSCFm
        '
        Me.cboSCFm.FormattingEnabled = True
        Me.cboSCFm.Location = New System.Drawing.Point(130, 12)
        Me.cboSCFm.Name = "cboSCFm"
        Me.cboSCFm.Size = New System.Drawing.Size(185, 21)
        Me.cboSCFm.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(350, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "To :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lstVendorFrom)
        Me.GroupBox2.Controls.Add(Me.ChkALL)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(618, 140)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'lstVendorFrom
        '
        Me.lstVendorFrom.FormattingEnabled = True
        Me.lstVendorFrom.Location = New System.Drawing.Point(130, 12)
        Me.lstVendorFrom.Name = "lstVendorFrom"
        Me.lstVendorFrom.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lstVendorFrom.Size = New System.Drawing.Size(459, 121)
        Me.lstVendorFrom.TabIndex = 4
        '
        'ChkALL
        '
        Me.ChkALL.AutoSize = True
        Me.ChkALL.Checked = True
        Me.ChkALL.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkALL.Location = New System.Drawing.Point(11, 54)
        Me.ChkALL.Name = "ChkALL"
        Me.ChkALL.Size = New System.Drawing.Size(45, 17)
        Me.ChkALL.TabIndex = 3
        Me.ChkALL.Text = "ALL"
        Me.ChkALL.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(90, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "VendorNo. From :"
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(265, 461)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(111, 38)
        Me.cmdShow.TabIndex = 16
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label13.Location = New System.Drawing.Point(142, 3)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(406, 25)
        Me.Label13.TabIndex = 18
        Me.Label13.Text = "CBM Ordered Report (Factory Ship-Date)"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(12, 10)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 13)
        Me.Label14.TabIndex = 20
        Me.Label14.Text = "INR00010"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(-5, 29)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(835, 13)
        Me.Label15.TabIndex = 21
        Me.Label15.Text = "_________________________________________________________________________________" & _
            "_________________________________________________________"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(61, 535)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(0, 13)
        Me.Label22.TabIndex = 486
        '
        'INR00010
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(670, 512)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.grpSearch)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboCocde)
        Me.Controls.Add(Me.Label1)
        Me.Name = "INR00010"
        Me.Text = "INR00010 - CBM Ordered Report (Factory Ship-Date)"
        Me.grpSearch.ResumeLayout(False)
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents cboCocde As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents grpSearch As System.Windows.Forms.GroupBox
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents cboSCTo As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboSCFm As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtDateFrom As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDateTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ChkALL As System.Windows.Forms.CheckBox
    Friend WithEvents lstVendorFrom As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboCatlevel As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboCatlevel_To As System.Windows.Forms.ComboBox
    Friend WithEvents cboCatlevel_Fm As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents opt1w As System.Windows.Forms.RadioButton
    Friend WithEvents opt2w As System.Windows.Forms.RadioButton
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents opt4w As System.Windows.Forms.RadioButton
End Class
