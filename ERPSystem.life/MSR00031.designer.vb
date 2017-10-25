<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MSR00031
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MSR00031))
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.grpSearch = New System.Windows.Forms.GroupBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtDateTo = New System.Windows.Forms.MaskedTextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtDateFrom = New System.Windows.Forms.MaskedTextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.cboSortBy = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.cboSIStatus = New System.Windows.Forms.ComboBox
        Me.Label22 = New System.Windows.Forms.Label
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
        Me.cmdShow = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.grpSearch.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(32, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Company Code"
        '
        'cboCoCde
        '
        Me.cboCoCde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cboCoCde.Location = New System.Drawing.Point(117, 54)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(76, 20)
        Me.cboCoCde.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(210, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Company Name"
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.Color.White
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.Location = New System.Drawing.Point(298, 54)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.Size = New System.Drawing.Size(350, 22)
        Me.txtCoNam.TabIndex = 2
        '
        'grpSearch
        '
        Me.grpSearch.Controls.Add(Me.GroupBox1)
        Me.grpSearch.Controls.Add(Me.cboSortBy)
        Me.grpSearch.Controls.Add(Me.Label12)
        Me.grpSearch.Controls.Add(Me.cboSIStatus)
        Me.grpSearch.Controls.Add(Me.Label22)
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
        Me.grpSearch.Location = New System.Drawing.Point(32, 83)
        Me.grpSearch.Name = "grpSearch"
        Me.grpSearch.Size = New System.Drawing.Size(616, 169)
        Me.grpSearch.TabIndex = 4
        Me.grpSearch.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.txtDateTo)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.txtDateFrom)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 113)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(583, 49)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(3, 27)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(87, 12)
        Me.Label16.TabIndex = 485
        Me.Label16.Text = "(MM/DD/YYYY)"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(6, 15)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(64, 12)
        Me.Label21.TabIndex = 451
        Me.Label21.Text = "Invoice Date"
        '
        'txtDateTo
        '
        Me.txtDateTo.Location = New System.Drawing.Point(386, 15)
        Me.txtDateTo.Mask = "##/##/####"
        Me.txtDateTo.Name = "txtDateTo"
        Me.txtDateTo.Size = New System.Drawing.Size(185, 22)
        Me.txtDateTo.TabIndex = 12
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(95, 15)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(30, 12)
        Me.Label20.TabIndex = 449
        Me.Label20.Text = "From"
        '
        'txtDateFrom
        '
        Me.txtDateFrom.Location = New System.Drawing.Point(138, 15)
        Me.txtDateFrom.Mask = "##/##/####"
        Me.txtDateFrom.Name = "txtDateFrom"
        Me.txtDateFrom.Size = New System.Drawing.Size(185, 22)
        Me.txtDateFrom.TabIndex = 11
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(360, 15)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(18, 12)
        Me.Label19.TabIndex = 450
        Me.Label19.Text = "To"
        '
        'cboSortBy
        '
        Me.cboSortBy.FormattingEnabled = True
        Me.cboSortBy.Location = New System.Drawing.Point(404, 87)
        Me.cboSortBy.Name = "cboSortBy"
        Me.cboSortBy.Size = New System.Drawing.Size(185, 20)
        Me.cboSortBy.TabIndex = 10
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(357, 90)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(44, 12)
        Me.Label12.TabIndex = 454
        Me.Label12.Text = "Sort By "
        '
        'cboSIStatus
        '
        Me.cboSIStatus.FormattingEnabled = True
        Me.cboSIStatus.Location = New System.Drawing.Point(154, 88)
        Me.cboSIStatus.Name = "cboSIStatus"
        Me.cboSIStatus.Size = New System.Drawing.Size(185, 20)
        Me.cboSIStatus.TabIndex = 9
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(20, 90)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(70, 12)
        Me.Label22.TabIndex = 452
        Me.Label22.Text = "Invoice Status"
        '
        'cboCustNoTo
        '
        Me.cboCustNoTo.FormattingEnabled = True
        Me.cboCustNoTo.Location = New System.Drawing.Point(404, 23)
        Me.cboCustNoTo.Name = "cboCustNoTo"
        Me.cboCustNoTo.Size = New System.Drawing.Size(185, 20)
        Me.cboCustNoTo.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(374, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(18, 12)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "To"
        '
        'cboCustNoFm
        '
        Me.cboCustNoFm.FormattingEnabled = True
        Me.cboCustNoFm.Location = New System.Drawing.Point(154, 23)
        Me.cboCustNoFm.Name = "cboCustNoFm"
        Me.cboCustNoFm.Size = New System.Drawing.Size(185, 20)
        Me.cboCustNoFm.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(113, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 12)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "From"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 12)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Customer No."
        '
        'cboVenCdeTo
        '
        Me.cboVenCdeTo.FormattingEnabled = True
        Me.cboVenCdeTo.Location = New System.Drawing.Point(404, 54)
        Me.cboVenCdeTo.Name = "cboVenCdeTo"
        Me.cboVenCdeTo.Size = New System.Drawing.Size(185, 20)
        Me.cboVenCdeTo.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(374, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(18, 12)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "To"
        '
        'cboVenCdeFm
        '
        Me.cboVenCdeFm.FormattingEnabled = True
        Me.cboVenCdeFm.Location = New System.Drawing.Point(154, 54)
        Me.cboVenCdeFm.Name = "cboVenCdeFm"
        Me.cboVenCdeFm.Size = New System.Drawing.Size(185, 20)
        Me.cboVenCdeFm.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(113, 57)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 12)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "From"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(20, 57)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 12)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Vendor No"
        '
        'cboVenSubCdeTo
        '
        Me.cboVenSubCdeTo.FormattingEnabled = True
        Me.cboVenSubCdeTo.Location = New System.Drawing.Point(471, 277)
        Me.cboVenSubCdeTo.Name = "cboVenSubCdeTo"
        Me.cboVenSubCdeTo.Size = New System.Drawing.Size(187, 20)
        Me.cboVenSubCdeTo.TabIndex = 8
        Me.cboVenSubCdeTo.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(441, 280)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(18, 12)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "To"
        Me.Label9.Visible = False
        '
        'cboVenSubCdeFm
        '
        Me.cboVenSubCdeFm.FormattingEnabled = True
        Me.cboVenSubCdeFm.Location = New System.Drawing.Point(488, 274)
        Me.cboVenSubCdeFm.Name = "cboVenSubCdeFm"
        Me.cboVenSubCdeFm.Size = New System.Drawing.Size(187, 20)
        Me.cboVenSubCdeFm.TabIndex = 7
        Me.cboVenSubCdeFm.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(485, 282)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(30, 12)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "From"
        Me.Label10.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(485, 277)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(90, 12)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Vendor Sub-Code"
        Me.Label11.Visible = False
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(311, 261)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(140, 22)
        Me.cmdShow.TabIndex = 13
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(284, 11)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(138, 25)
        Me.Label13.TabIndex = 18
        Me.Label13.Text = "Invoice Index"
        '
        'MSR00031
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(714, 305)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.grpSearch)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cboVenSubCdeFm)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cboVenSubCdeTo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MSR00031"
        Me.Text = "MSR00031 - Invoice Index (MSR31)"
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
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents cboCustNoTo As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboCustNoFm As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cboSIStatus As System.Windows.Forms.ComboBox
    Friend WithEvents cboSortBy As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtDateFrom As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDateTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
End Class
