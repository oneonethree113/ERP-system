<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MSR00033
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MSR00033))
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.grpSearch = New System.Windows.Forms.GroupBox
        Me.txtDateTo = New System.Windows.Forms.MaskedTextBox
        Me.txtDateFrom = New System.Windows.Forms.MaskedTextBox
        Me.cboSIStatus = New System.Windows.Forms.ComboBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtSITo = New System.Windows.Forms.TextBox
        Me.txtSIFm = New System.Windows.Forms.TextBox
        Me.cboVenTypTo = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.cboVenTypFm = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.cboCustNoTo = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboCustNoFm = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboVenCdeTo = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboVenCdeFm = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboVenSubCdeTo = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cboVenSubCdeFm = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.OptSI = New System.Windows.Forms.RadioButton
        Me.OptCust = New System.Windows.Forms.RadioButton
        Me.cmdShow = New System.Windows.Forms.Button
        Me.Label23 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.grpSearch.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(44, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Company Code"
        '
        'cboCoCde
        '
        Me.cboCoCde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(129, 47)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(76, 20)
        Me.cboCoCde.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(222, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Company Name"
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.Color.White
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.Location = New System.Drawing.Point(310, 47)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.Size = New System.Drawing.Size(350, 22)
        Me.txtCoNam.TabIndex = 2
        '
        'grpSearch
        '
        Me.grpSearch.Controls.Add(Me.txtDateTo)
        Me.grpSearch.Controls.Add(Me.txtDateFrom)
        Me.grpSearch.Controls.Add(Me.cboSIStatus)
        Me.grpSearch.Controls.Add(Me.Label22)
        Me.grpSearch.Controls.Add(Me.Label21)
        Me.grpSearch.Controls.Add(Me.Label19)
        Me.grpSearch.Controls.Add(Me.Label20)
        Me.grpSearch.Controls.Add(Me.txtSITo)
        Me.grpSearch.Controls.Add(Me.txtSIFm)
        Me.grpSearch.Controls.Add(Me.cboVenTypTo)
        Me.grpSearch.Controls.Add(Me.Label16)
        Me.grpSearch.Controls.Add(Me.cboVenTypFm)
        Me.grpSearch.Controls.Add(Me.Label17)
        Me.grpSearch.Controls.Add(Me.Label18)
        Me.grpSearch.Controls.Add(Me.Label12)
        Me.grpSearch.Controls.Add(Me.Label13)
        Me.grpSearch.Controls.Add(Me.Label14)
        Me.grpSearch.Controls.Add(Me.cboCustNoTo)
        Me.grpSearch.Controls.Add(Me.Label3)
        Me.grpSearch.Controls.Add(Me.cboCustNoFm)
        Me.grpSearch.Controls.Add(Me.Label4)
        Me.grpSearch.Controls.Add(Me.Label5)
        Me.grpSearch.Controls.Add(Me.cboVenCdeTo)
        Me.grpSearch.Controls.Add(Me.Label6)
        Me.grpSearch.Controls.Add(Me.cboVenCdeFm)
        Me.grpSearch.Controls.Add(Me.Label7)
        Me.grpSearch.Controls.Add(Me.Label8)
        Me.grpSearch.Location = New System.Drawing.Point(44, 77)
        Me.grpSearch.Name = "grpSearch"
        Me.grpSearch.Size = New System.Drawing.Size(622, 212)
        Me.grpSearch.TabIndex = 4
        Me.grpSearch.TabStop = False
        '
        'txtDateTo
        '
        Me.txtDateTo.Location = New System.Drawing.Point(418, 140)
        Me.txtDateTo.Mask = "##/##/####"
        Me.txtDateTo.Name = "txtDateTo"
        Me.txtDateTo.Size = New System.Drawing.Size(187, 22)
        Me.txtDateTo.TabIndex = 14
        '
        'txtDateFrom
        '
        Me.txtDateFrom.Location = New System.Drawing.Point(185, 140)
        Me.txtDateFrom.Mask = "##/##/####"
        Me.txtDateFrom.Name = "txtDateFrom"
        Me.txtDateFrom.Size = New System.Drawing.Size(187, 22)
        Me.txtDateFrom.TabIndex = 13
        '
        'cboSIStatus
        '
        Me.cboSIStatus.FormattingEnabled = True
        Me.cboSIStatus.Location = New System.Drawing.Point(185, 172)
        Me.cboSIStatus.Name = "cboSIStatus"
        Me.cboSIStatus.Size = New System.Drawing.Size(187, 20)
        Me.cboSIStatus.TabIndex = 15
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(18, 172)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(107, 12)
        Me.Label22.TabIndex = 452
        Me.Label22.Text = "Sample Invoice Status"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(18, 144)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(123, 12)
        Me.Label21.TabIndex = 451
        Me.Label21.Text = "Issue Date (mm/dd/yyyy)"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(392, 144)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(18, 12)
        Me.Label19.TabIndex = 450
        Me.Label19.Text = "To"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(149, 144)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(30, 12)
        Me.Label20.TabIndex = 449
        Me.Label20.Text = "From"
        '
        'txtSITo
        '
        Me.txtSITo.BackColor = System.Drawing.Color.White
        Me.txtSITo.Location = New System.Drawing.Point(418, 53)
        Me.txtSITo.Name = "txtSITo"
        Me.txtSITo.Size = New System.Drawing.Size(187, 22)
        Me.txtSITo.TabIndex = 6
        '
        'txtSIFm
        '
        Me.txtSIFm.BackColor = System.Drawing.Color.White
        Me.txtSIFm.Location = New System.Drawing.Point(185, 53)
        Me.txtSIFm.Name = "txtSIFm"
        Me.txtSIFm.Size = New System.Drawing.Size(187, 22)
        Me.txtSIFm.TabIndex = 5
        '
        'cboVenTypTo
        '
        Me.cboVenTypTo.FormattingEnabled = True
        Me.cboVenTypTo.Location = New System.Drawing.Point(418, 112)
        Me.cboVenTypTo.Name = "cboVenTypTo"
        Me.cboVenTypTo.Size = New System.Drawing.Size(187, 20)
        Me.cboVenTypTo.TabIndex = 12
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(392, 114)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(18, 12)
        Me.Label16.TabIndex = 28
        Me.Label16.Text = "To"
        '
        'cboVenTypFm
        '
        Me.cboVenTypFm.FormattingEnabled = True
        Me.cboVenTypFm.Location = New System.Drawing.Point(185, 112)
        Me.cboVenTypFm.Name = "cboVenTypFm"
        Me.cboVenTypFm.Size = New System.Drawing.Size(187, 20)
        Me.cboVenTypFm.TabIndex = 11
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(149, 115)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(30, 12)
        Me.Label17.TabIndex = 26
        Me.Label17.Text = "From"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(18, 115)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(67, 12)
        Me.Label18.TabIndex = 25
        Me.Label18.Text = "Vendor Type"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(392, 55)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(18, 12)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "To"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(149, 57)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(30, 12)
        Me.Label13.TabIndex = 21
        Me.Label13.Text = "From"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(18, 57)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(97, 12)
        Me.Label14.TabIndex = 20
        Me.Label14.Text = "Sample Invoice No."
        '
        'cboCustNoTo
        '
        Me.cboCustNoTo.FormattingEnabled = True
        Me.cboCustNoTo.Location = New System.Drawing.Point(418, 23)
        Me.cboCustNoTo.Name = "cboCustNoTo"
        Me.cboCustNoTo.Size = New System.Drawing.Size(187, 20)
        Me.cboCustNoTo.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(392, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(18, 12)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "To"
        '
        'cboCustNoFm
        '
        Me.cboCustNoFm.FormattingEnabled = True
        Me.cboCustNoFm.Location = New System.Drawing.Point(185, 23)
        Me.cboCustNoFm.Name = "cboCustNoFm"
        Me.cboCustNoFm.Size = New System.Drawing.Size(187, 20)
        Me.cboCustNoFm.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(149, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 12)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "From"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 12)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Customer No."
        '
        'cboVenCdeTo
        '
        Me.cboVenCdeTo.FormattingEnabled = True
        Me.cboVenCdeTo.Location = New System.Drawing.Point(418, 82)
        Me.cboVenCdeTo.Name = "cboVenCdeTo"
        Me.cboVenCdeTo.Size = New System.Drawing.Size(187, 20)
        Me.cboVenCdeTo.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(392, 86)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(18, 12)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "To"
        '
        'cboVenCdeFm
        '
        Me.cboVenCdeFm.FormattingEnabled = True
        Me.cboVenCdeFm.Location = New System.Drawing.Point(185, 82)
        Me.cboVenCdeFm.Name = "cboVenCdeFm"
        Me.cboVenCdeFm.Size = New System.Drawing.Size(187, 20)
        Me.cboVenCdeFm.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(149, 86)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 12)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "From"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(18, 86)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 12)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Vendor No"
        '
        'cboVenSubCdeTo
        '
        Me.cboVenSubCdeTo.FormattingEnabled = True
        Me.cboVenSubCdeTo.Location = New System.Drawing.Point(568, 456)
        Me.cboVenSubCdeTo.Name = "cboVenSubCdeTo"
        Me.cboVenSubCdeTo.Size = New System.Drawing.Size(187, 20)
        Me.cboVenSubCdeTo.TabIndex = 10
        Me.cboVenSubCdeTo.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(576, 456)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(18, 12)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "To"
        Me.Label9.Visible = False
        '
        'cboVenSubCdeFm
        '
        Me.cboVenSubCdeFm.FormattingEnabled = True
        Me.cboVenSubCdeFm.Location = New System.Drawing.Point(546, 456)
        Me.cboVenSubCdeFm.Name = "cboVenSubCdeFm"
        Me.cboVenSubCdeFm.Size = New System.Drawing.Size(187, 20)
        Me.cboVenSubCdeFm.TabIndex = 9
        Me.cboVenSubCdeFm.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(576, 459)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(30, 12)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "From"
        Me.Label10.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(543, 456)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(90, 12)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Vendor Sub-Code"
        Me.Label11.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(26, 19)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(41, 12)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "Sort By"
        '
        'OptSI
        '
        Me.OptSI.AutoSize = True
        Me.OptSI.Checked = True
        Me.OptSI.Location = New System.Drawing.Point(176, 19)
        Me.OptSI.Name = "OptSI"
        Me.OptSI.Size = New System.Drawing.Size(115, 16)
        Me.OptSI.TabIndex = 16
        Me.OptSI.TabStop = True
        Me.OptSI.Text = "Sample Invoice No."
        Me.OptSI.UseVisualStyleBackColor = True
        '
        'OptCust
        '
        Me.OptCust.AutoSize = True
        Me.OptCust.Location = New System.Drawing.Point(303, 18)
        Me.OptCust.Name = "OptCust"
        Me.OptCust.Size = New System.Drawing.Size(68, 16)
        Me.OptCust.TabIndex = 17
        Me.OptCust.Text = "Customer"
        Me.OptCust.UseVisualStyleBackColor = True
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(298, 346)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(140, 22)
        Me.cmdShow.TabIndex = 18
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Blue
        Me.Label23.Location = New System.Drawing.Point(261, 8)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(216, 25)
        Me.Label23.TabIndex = 19
        Me.Label23.Text = "Sample Invoice Index"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.OptCust)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.OptSI)
        Me.GroupBox1.Location = New System.Drawing.Point(44, 294)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(622, 46)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        '
        'MSR00033
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(714, 385)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.grpSearch)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboVenSubCdeTo)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cboVenSubCdeFm)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MSR00033"
        Me.Text = "MSR00033 - Sample Invoice Index (MSR33)"
        Me.grpSearch.ResumeLayout(False)
        Me.grpSearch.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents grpSearch As System.Windows.Forms.GroupBox
    Friend WithEvents cboVenCdeTo As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboVenCdeFm As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboVenSubCdeTo As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboVenSubCdeFm As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents OptSI As System.Windows.Forms.RadioButton
    Friend WithEvents OptCust As System.Windows.Forms.RadioButton
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents cboVenTypTo As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cboVenTypFm As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboCustNoTo As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboCustNoFm As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSITo As System.Windows.Forms.TextBox
    Friend WithEvents txtSIFm As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cboSIStatus As System.Windows.Forms.ComboBox
    Friend WithEvents txtDateFrom As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDateTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
