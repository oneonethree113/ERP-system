<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class INR00012
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(INR00012))
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboCocde = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.grpSearch = New System.Windows.Forms.GroupBox
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.oprRptSetC = New System.Windows.Forms.RadioButton
        Me.Label10 = New System.Windows.Forms.Label
        Me.oprRptSetB = New System.Windows.Forms.RadioButton
        Me.oprRptSetA = New System.Windows.Forms.RadioButton
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.optCBM = New System.Windows.Forms.RadioButton
        Me.optAmt = New System.Windows.Forms.RadioButton
        Me.Label17 = New System.Windows.Forms.Label
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
        Me.ChkALL = New System.Windows.Forms.CheckBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.lstVendorFrom = New System.Windows.Forms.ListBox
        Me.cmdShow = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.grpSearch.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
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
        Me.Label1.Location = New System.Drawing.Point(17, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Company Code"
        '
        'cboCocde
        '
        Me.cboCocde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCocde.FormattingEnabled = True
        Me.cboCocde.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cboCocde.Location = New System.Drawing.Point(102, 40)
        Me.cboCocde.Name = "cboCocde"
        Me.cboCocde.Size = New System.Drawing.Size(76, 20)
        Me.cboCocde.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(195, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Company Name"
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.Color.White
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.Location = New System.Drawing.Point(283, 40)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.Size = New System.Drawing.Size(339, 22)
        Me.txtCoNam.TabIndex = 2
        '
        'grpSearch
        '
        Me.grpSearch.Controls.Add(Me.GroupBox7)
        Me.grpSearch.Controls.Add(Me.GroupBox3)
        Me.grpSearch.Controls.Add(Me.GroupBox1)
        Me.grpSearch.Controls.Add(Me.GroupBox6)
        Me.grpSearch.Controls.Add(Me.GroupBox5)
        Me.grpSearch.Controls.Add(Me.GroupBox4)
        Me.grpSearch.Controls.Add(Me.GroupBox2)
        Me.grpSearch.Location = New System.Drawing.Point(5, 65)
        Me.grpSearch.Name = "grpSearch"
        Me.grpSearch.Size = New System.Drawing.Size(624, 354)
        Me.grpSearch.TabIndex = 2
        Me.grpSearch.TabStop = False
        Me.grpSearch.Text = "Selection Criteria"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.oprRptSetC)
        Me.GroupBox7.Controls.Add(Me.Label10)
        Me.GroupBox7.Controls.Add(Me.oprRptSetB)
        Me.GroupBox7.Controls.Add(Me.oprRptSetA)
        Me.GroupBox7.Location = New System.Drawing.Point(14, 309)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(600, 36)
        Me.GroupBox7.TabIndex = 14
        Me.GroupBox7.TabStop = False
        '
        'oprRptSetC
        '
        Me.oprRptSetC.AutoSize = True
        Me.oprRptSetC.Location = New System.Drawing.Point(402, 13)
        Me.oprRptSetC.Name = "oprRptSetC"
        Me.oprRptSetC.Size = New System.Drawing.Size(48, 16)
        Me.oprRptSetC.TabIndex = 16
        Me.oprRptSetC.Text = "Set C"
        Me.oprRptSetC.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(10, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 12)
        Me.Label10.TabIndex = 465
        Me.Label10.Text = "Report Set"
        '
        'oprRptSetB
        '
        Me.oprRptSetB.AutoSize = True
        Me.oprRptSetB.Location = New System.Drawing.Point(274, 13)
        Me.oprRptSetB.Name = "oprRptSetB"
        Me.oprRptSetB.Size = New System.Drawing.Size(48, 16)
        Me.oprRptSetB.TabIndex = 15
        Me.oprRptSetB.Text = "Set B"
        Me.oprRptSetB.UseVisualStyleBackColor = True
        '
        'oprRptSetA
        '
        Me.oprRptSetA.AutoSize = True
        Me.oprRptSetA.Checked = True
        Me.oprRptSetA.Location = New System.Drawing.Point(143, 13)
        Me.oprRptSetA.Name = "oprRptSetA"
        Me.oprRptSetA.Size = New System.Drawing.Size(48, 16)
        Me.oprRptSetA.TabIndex = 14
        Me.oprRptSetA.TabStop = True
        Me.oprRptSetA.Text = "Set A"
        Me.oprRptSetA.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.optCBM)
        Me.GroupBox3.Controls.Add(Me.optAmt)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Location = New System.Drawing.Point(14, 265)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(600, 36)
        Me.GroupBox3.TabIndex = 12
        Me.GroupBox3.TabStop = False
        '
        'optCBM
        '
        Me.optCBM.AutoSize = True
        Me.optCBM.Checked = True
        Me.optCBM.Location = New System.Drawing.Point(144, 13)
        Me.optCBM.Name = "optCBM"
        Me.optCBM.Size = New System.Drawing.Size(49, 16)
        Me.optCBM.TabIndex = 12
        Me.optCBM.TabStop = True
        Me.optCBM.Text = "CBM"
        Me.optCBM.UseVisualStyleBackColor = True
        '
        'optAmt
        '
        Me.optAmt.AutoSize = True
        Me.optAmt.Location = New System.Drawing.Point(274, 14)
        Me.optAmt.Name = "optAmt"
        Me.optAmt.Size = New System.Drawing.Size(61, 16)
        Me.optAmt.TabIndex = 13
        Me.optAmt.Text = "Amount"
        Me.optAmt.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(11, 15)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(73, 12)
        Me.Label17.TabIndex = 463
        Me.Label17.Text = "Report Layout"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.txtDateTo)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.txtDateFrom)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 215)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(602, 46)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(10, 19)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(59, 12)
        Me.Label21.TabIndex = 451
        Me.Label21.Text = "Date Range"
        '
        'txtDateTo
        '
        Me.txtDateTo.Location = New System.Drawing.Point(386, 15)
        Me.txtDateTo.Mask = "##/##/####"
        Me.txtDateTo.Name = "txtDateTo"
        Me.txtDateTo.Size = New System.Drawing.Size(185, 22)
        Me.txtDateTo.TabIndex = 11
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(86, 19)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(30, 12)
        Me.Label20.TabIndex = 449
        Me.Label20.Text = "From"
        '
        'txtDateFrom
        '
        Me.txtDateFrom.Location = New System.Drawing.Point(130, 15)
        Me.txtDateFrom.Mask = "##/##/####"
        Me.txtDateFrom.Name = "txtDateFrom"
        Me.txtDateFrom.Size = New System.Drawing.Size(185, 22)
        Me.txtDateFrom.TabIndex = 10
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(350, 19)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(18, 12)
        Me.Label19.TabIndex = 450
        Me.Label19.Text = "To"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label4)
        Me.GroupBox6.Controls.Add(Me.Label8)
        Me.GroupBox6.Controls.Add(Me.cboCatlevel_To)
        Me.GroupBox6.Controls.Add(Me.cboCatlevel_Fm)
        Me.GroupBox6.Controls.Add(Me.Label11)
        Me.GroupBox6.Location = New System.Drawing.Point(15, 172)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(600, 37)
        Me.GroupBox6.TabIndex = 8
        Me.GroupBox6.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(85, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 12)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "From"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 12)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Category Level"
        '
        'cboCatlevel_To
        '
        Me.cboCatlevel_To.FormattingEnabled = True
        Me.cboCatlevel_To.Location = New System.Drawing.Point(386, 12)
        Me.cboCatlevel_To.Name = "cboCatlevel_To"
        Me.cboCatlevel_To.Size = New System.Drawing.Size(185, 20)
        Me.cboCatlevel_To.TabIndex = 9
        '
        'cboCatlevel_Fm
        '
        Me.cboCatlevel_Fm.FormattingEnabled = True
        Me.cboCatlevel_Fm.Location = New System.Drawing.Point(130, 12)
        Me.cboCatlevel_Fm.Name = "cboCatlevel_Fm"
        Me.cboCatlevel_Fm.Size = New System.Drawing.Size(185, 20)
        Me.cboCatlevel_Fm.TabIndex = 8
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(350, 15)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(18, 12)
        Me.Label11.TabIndex = 18
        Me.Label11.Text = "To"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cboCatlevel)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Location = New System.Drawing.Point(15, 134)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(600, 36)
        Me.GroupBox5.TabIndex = 7
        Me.GroupBox5.TabStop = False
        '
        'cboCatlevel
        '
        Me.cboCatlevel.FormattingEnabled = True
        Me.cboCatlevel.Location = New System.Drawing.Point(130, 11)
        Me.cboCatlevel.Name = "cboCatlevel"
        Me.cboCatlevel.Size = New System.Drawing.Size(185, 20)
        Me.cboCatlevel.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 12)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Category Level"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.cboSCTo)
        Me.GroupBox4.Controls.Add(Me.cboSCFm)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Location = New System.Drawing.Point(15, 96)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(600, 37)
        Me.GroupBox4.TabIndex = 5
        Me.GroupBox4.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(85, 14)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 12)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "From"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 12)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Sub-Code"
        '
        'cboSCTo
        '
        Me.cboSCTo.FormattingEnabled = True
        Me.cboSCTo.Location = New System.Drawing.Point(386, 11)
        Me.cboSCTo.Name = "cboSCTo"
        Me.cboSCTo.Size = New System.Drawing.Size(185, 20)
        Me.cboSCTo.TabIndex = 6
        '
        'cboSCFm
        '
        Me.cboSCFm.FormattingEnabled = True
        Me.cboSCFm.Location = New System.Drawing.Point(130, 11)
        Me.cboSCFm.Name = "cboSCFm"
        Me.cboSCFm.Size = New System.Drawing.Size(185, 20)
        Me.cboSCFm.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(350, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(18, 12)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "To"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ChkALL)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.lstVendorFrom)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 11)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(600, 86)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'ChkALL
        '
        Me.ChkALL.AutoSize = True
        Me.ChkALL.Checked = True
        Me.ChkALL.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkALL.Location = New System.Drawing.Point(13, 50)
        Me.ChkALL.Name = "ChkALL"
        Me.ChkALL.Size = New System.Drawing.Size(46, 16)
        Me.ChkALL.TabIndex = 3
        Me.ChkALL.Text = "ALL"
        Me.ChkALL.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(10, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 12)
        Me.Label9.TabIndex = 457
        Me.Label9.Text = "VendorNo. From"
        '
        'lstVendorFrom
        '
        Me.lstVendorFrom.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstVendorFrom.FormattingEnabled = True
        Me.lstVendorFrom.ItemHeight = 12
        Me.lstVendorFrom.Location = New System.Drawing.Point(130, 11)
        Me.lstVendorFrom.Name = "lstVendorFrom"
        Me.lstVendorFrom.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lstVendorFrom.Size = New System.Drawing.Size(461, 64)
        Me.lstVendorFrom.TabIndex = 4
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(248, 425)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(140, 22)
        Me.cmdShow.TabIndex = 17
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(188, 5)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(232, 24)
        Me.Label13.TabIndex = 18
        Me.Label13.Text = "Shipping Schedule Report"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(61, 494)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(0, 12)
        Me.Label22.TabIndex = 486
        '
        'INR00012
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 453)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.grpSearch)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboCocde)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "INR00012"
        Me.Text = "INR00012 - Shipping Schedule Report (INR12)"
        Me.grpSearch.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
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
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents ChkALL As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents oprRptSetC As System.Windows.Forms.RadioButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents oprRptSetA As System.Windows.Forms.RadioButton
    Friend WithEvents optAmt As System.Windows.Forms.RadioButton
    Friend WithEvents oprRptSetB As System.Windows.Forms.RadioButton
    Friend WithEvents optCBM As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
End Class
