﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MSR00022
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MSR00022))
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.grpSearch = New System.Windows.Forms.GroupBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.optVendor = New System.Windows.Forms.RadioButton
        Me.Label15 = New System.Windows.Forms.Label
        Me.optPO = New System.Windows.Forms.RadioButton
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtDateTo = New System.Windows.Forms.MaskedTextBox
        Me.txtDateFrom = New System.Windows.Forms.MaskedTextBox
        Me.cboVenCdeTo = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.cboVenCdeFm = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtPOTo = New System.Windows.Forms.TextBox
        Me.txtPOFm = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.cmdShow = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.grpSearch.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(23, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Company Code"
        '
        'cboCoCde
        '
        Me.cboCoCde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(108, 57)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(76, 20)
        Me.cboCoCde.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(201, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Company Name"
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.Color.White
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.Location = New System.Drawing.Point(289, 57)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.Size = New System.Drawing.Size(350, 22)
        Me.txtCoNam.TabIndex = 2
        '
        'grpSearch
        '
        Me.grpSearch.Controls.Add(Me.GroupBox1)
        Me.grpSearch.Controls.Add(Me.Label6)
        Me.grpSearch.Controls.Add(Me.Label5)
        Me.grpSearch.Controls.Add(Me.txtDateTo)
        Me.grpSearch.Controls.Add(Me.txtDateFrom)
        Me.grpSearch.Controls.Add(Me.cboVenCdeTo)
        Me.grpSearch.Controls.Add(Me.Label12)
        Me.grpSearch.Controls.Add(Me.cboVenCdeFm)
        Me.grpSearch.Controls.Add(Me.Label13)
        Me.grpSearch.Controls.Add(Me.Label14)
        Me.grpSearch.Controls.Add(Me.txtPOTo)
        Me.grpSearch.Controls.Add(Me.txtPOFm)
        Me.grpSearch.Controls.Add(Me.Label23)
        Me.grpSearch.Controls.Add(Me.Label24)
        Me.grpSearch.Controls.Add(Me.Label25)
        Me.grpSearch.Controls.Add(Me.Label21)
        Me.grpSearch.Controls.Add(Me.Label19)
        Me.grpSearch.Controls.Add(Me.Label20)
        Me.grpSearch.Location = New System.Drawing.Point(23, 88)
        Me.grpSearch.Name = "grpSearch"
        Me.grpSearch.Size = New System.Drawing.Size(652, 153)
        Me.grpSearch.TabIndex = 4
        Me.grpSearch.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optVendor)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.optPO)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 98)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(599, 43)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        '
        'optVendor
        '
        Me.optVendor.AutoSize = True
        Me.optVendor.Checked = True
        Me.optVendor.Location = New System.Drawing.Point(164, 14)
        Me.optVendor.Name = "optVendor"
        Me.optVendor.Size = New System.Drawing.Size(115, 16)
        Me.optVendor.TabIndex = 9
        Me.optVendor.TabStop = True
        Me.optVendor.Text = "BOM Vendor Code"
        Me.optVendor.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(13, 18)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(41, 12)
        Me.Label15.TabIndex = 483
        Me.Label15.Text = "Sort By"
        '
        'optPO
        '
        Me.optPO.AutoSize = True
        Me.optPO.Location = New System.Drawing.Point(311, 14)
        Me.optPO.Name = "optPO"
        Me.optPO.Size = New System.Drawing.Size(86, 16)
        Me.optPO.TabIndex = 10
        Me.optPO.Text = "BOM PO No."
        Me.optPO.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(521, 77)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 12)
        Me.Label6.TabIndex = 485
        Me.Label6.Text = "(MM/DD/YYYY)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(283, 77)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 12)
        Me.Label5.TabIndex = 484
        Me.Label5.Text = "(MM/DD/YYYY)"
        '
        'txtDateTo
        '
        Me.txtDateTo.Location = New System.Drawing.Point(419, 74)
        Me.txtDateTo.Mask = "##/##/####"
        Me.txtDateTo.Name = "txtDateTo"
        Me.txtDateTo.Size = New System.Drawing.Size(101, 22)
        Me.txtDateTo.TabIndex = 8
        '
        'txtDateFrom
        '
        Me.txtDateFrom.Location = New System.Drawing.Point(181, 74)
        Me.txtDateFrom.Mask = "##/##/####"
        Me.txtDateFrom.Name = "txtDateFrom"
        Me.txtDateFrom.Size = New System.Drawing.Size(101, 22)
        Me.txtDateFrom.TabIndex = 7
        '
        'cboVenCdeTo
        '
        Me.cboVenCdeTo.FormattingEnabled = True
        Me.cboVenCdeTo.Location = New System.Drawing.Point(419, 18)
        Me.cboVenCdeTo.Name = "cboVenCdeTo"
        Me.cboVenCdeTo.Size = New System.Drawing.Size(187, 20)
        Me.cboVenCdeTo.TabIndex = 4
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(389, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(18, 12)
        Me.Label12.TabIndex = 481
        Me.Label12.Text = "To"
        '
        'cboVenCdeFm
        '
        Me.cboVenCdeFm.FormattingEnabled = True
        Me.cboVenCdeFm.Location = New System.Drawing.Point(181, 18)
        Me.cboVenCdeFm.Name = "cboVenCdeFm"
        Me.cboVenCdeFm.Size = New System.Drawing.Size(187, 20)
        Me.cboVenCdeFm.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(104, 20)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(30, 12)
        Me.Label13.TabIndex = 479
        Me.Label13.Text = "From"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(29, 20)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(57, 12)
        Me.Label14.TabIndex = 478
        Me.Label14.Text = "Vendor No"
        '
        'txtPOTo
        '
        Me.txtPOTo.Location = New System.Drawing.Point(419, 45)
        Me.txtPOTo.MaxLength = 20
        Me.txtPOTo.Name = "txtPOTo"
        Me.txtPOTo.Size = New System.Drawing.Size(187, 22)
        Me.txtPOTo.TabIndex = 6
        '
        'txtPOFm
        '
        Me.txtPOFm.Location = New System.Drawing.Point(181, 45)
        Me.txtPOFm.MaxLength = 20
        Me.txtPOFm.Name = "txtPOFm"
        Me.txtPOFm.Size = New System.Drawing.Size(187, 22)
        Me.txtPOFm.TabIndex = 5
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(389, 50)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(18, 12)
        Me.Label23.TabIndex = 462
        Me.Label23.Text = "To"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(104, 50)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(30, 12)
        Me.Label24.TabIndex = 460
        Me.Label24.Text = "From"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(29, 50)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(68, 12)
        Me.Label25.TabIndex = 459
        Me.Label25.Text = "BOM PO No."
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(29, 77)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(52, 12)
        Me.Label21.TabIndex = 451
        Me.Label21.Text = "Issue Date"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(390, 78)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(18, 12)
        Me.Label19.TabIndex = 450
        Me.Label19.Text = "To"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(104, 77)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(30, 12)
        Me.Label20.TabIndex = 449
        Me.Label20.Text = "From"
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(288, 247)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(140, 22)
        Me.cmdShow.TabIndex = 11
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(274, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(154, 25)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "BOM PO Index"
        '
        'MSR00022
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(714, 286)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.grpSearch)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MSR00022"
        Me.Text = "MSR00022 - BOM PO Index (MSR22)"
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
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtPOTo As System.Windows.Forms.TextBox
    Friend WithEvents txtPOFm As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cboVenCdeTo As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboVenCdeFm As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents optPO As System.Windows.Forms.RadioButton
    Friend WithEvents optVendor As System.Windows.Forms.RadioButton
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtDateTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDateFrom As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
