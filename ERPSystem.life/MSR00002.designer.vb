<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MSR00002
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MSR00002))
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.optSortQ = New System.Windows.Forms.RadioButton
        Me.optSortC = New System.Windows.Forms.RadioButton
        Me.cmdShow = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboCustNoFm = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboCustNoTo = New System.Windows.Forms.ComboBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.cboQutSts = New System.Windows.Forms.ComboBox
        Me.grpSearch = New System.Windows.Forms.GroupBox
        Me.txtDateFrom = New System.Windows.Forms.MaskedTextBox
        Me.txtDateTo = New System.Windows.Forms.MaskedTextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.grpSearch.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(30, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Company Code"
        '
        'cboCoCde
        '
        Me.cboCoCde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(115, 50)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(76, 20)
        Me.cboCoCde.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(208, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Company Name"
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.Color.White
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.Location = New System.Drawing.Point(296, 50)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.Size = New System.Drawing.Size(350, 22)
        Me.txtCoNam.TabIndex = 2
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(19, 169)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(41, 12)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "Sort By"
        '
        'optSortQ
        '
        Me.optSortQ.AutoSize = True
        Me.optSortQ.Location = New System.Drawing.Point(193, 165)
        Me.optSortQ.Name = "optSortQ"
        Me.optSortQ.Size = New System.Drawing.Size(89, 16)
        Me.optSortQ.TabIndex = 8
        Me.optSortQ.Text = "Quotation No."
        Me.optSortQ.UseVisualStyleBackColor = True
        '
        'optSortC
        '
        Me.optSortC.AutoSize = True
        Me.optSortC.Checked = True
        Me.optSortC.Location = New System.Drawing.Point(397, 165)
        Me.optSortC.Name = "optSortC"
        Me.optSortC.Size = New System.Drawing.Size(68, 16)
        Me.optSortC.TabIndex = 9
        Me.optSortC.TabStop = True
        Me.optSortC.Text = "Customer"
        Me.optSortC.UseVisualStyleBackColor = True
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(296, 311)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(140, 22)
        Me.cmdShow.TabIndex = 10
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(19, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 12)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Customer No."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(157, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 12)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "From"
        '
        'cboCustNoFm
        '
        Me.cboCustNoFm.FormattingEnabled = True
        Me.cboCustNoFm.Location = New System.Drawing.Point(193, 76)
        Me.cboCustNoFm.Name = "cboCustNoFm"
        Me.cboCustNoFm.Size = New System.Drawing.Size(205, 20)
        Me.cboCustNoFm.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(404, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(18, 12)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "To"
        '
        'cboCustNoTo
        '
        Me.cboCustNoTo.FormattingEnabled = True
        Me.cboCustNoTo.Location = New System.Drawing.Point(431, 76)
        Me.cboCustNoTo.Name = "cboCustNoTo"
        Me.cboCustNoTo.Size = New System.Drawing.Size(205, 20)
        Me.cboCustNoTo.TabIndex = 6
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(157, 34)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(30, 12)
        Me.Label20.TabIndex = 449
        Me.Label20.Text = "From"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(404, 34)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(18, 12)
        Me.Label19.TabIndex = 450
        Me.Label19.Text = "To"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(19, 34)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(132, 12)
        Me.Label21.TabIndex = 451
        Me.Label21.Text = "Issue Date    (mm/dd/yyyy)"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(19, 125)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(81, 12)
        Me.Label22.TabIndex = 452
        Me.Label22.Text = "Quotation Status"
        '
        'cboQutSts
        '
        Me.cboQutSts.FormattingEnabled = True
        Me.cboQutSts.Location = New System.Drawing.Point(193, 121)
        Me.cboQutSts.Name = "cboQutSts"
        Me.cboQutSts.Size = New System.Drawing.Size(205, 20)
        Me.cboQutSts.TabIndex = 7
        '
        'grpSearch
        '
        Me.grpSearch.Controls.Add(Me.txtDateFrom)
        Me.grpSearch.Controls.Add(Me.txtDateTo)
        Me.grpSearch.Controls.Add(Me.cboQutSts)
        Me.grpSearch.Controls.Add(Me.Label22)
        Me.grpSearch.Controls.Add(Me.optSortC)
        Me.grpSearch.Controls.Add(Me.optSortQ)
        Me.grpSearch.Controls.Add(Me.Label21)
        Me.grpSearch.Controls.Add(Me.Label15)
        Me.grpSearch.Controls.Add(Me.Label19)
        Me.grpSearch.Controls.Add(Me.Label20)
        Me.grpSearch.Controls.Add(Me.cboCustNoTo)
        Me.grpSearch.Controls.Add(Me.Label3)
        Me.grpSearch.Controls.Add(Me.cboCustNoFm)
        Me.grpSearch.Controls.Add(Me.Label4)
        Me.grpSearch.Controls.Add(Me.Label5)
        Me.grpSearch.Location = New System.Drawing.Point(30, 80)
        Me.grpSearch.Name = "grpSearch"
        Me.grpSearch.Size = New System.Drawing.Size(661, 210)
        Me.grpSearch.TabIndex = 4
        Me.grpSearch.TabStop = False
        '
        'txtDateFrom
        '
        Me.txtDateFrom.Location = New System.Drawing.Point(193, 30)
        Me.txtDateFrom.Mask = "##/##/####"
        Me.txtDateFrom.Name = "txtDateFrom"
        Me.txtDateFrom.Size = New System.Drawing.Size(205, 22)
        Me.txtDateFrom.TabIndex = 3
        '
        'txtDateTo
        '
        Me.txtDateTo.Location = New System.Drawing.Point(431, 30)
        Me.txtDateTo.Mask = "##/##/####"
        Me.txtDateTo.Name = "txtDateTo"
        Me.txtDateTo.Size = New System.Drawing.Size(205, 22)
        Me.txtDateTo.TabIndex = 4
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.Location = New System.Drawing.Point(263, 7)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(163, 25)
        Me.Label16.TabIndex = 26
        Me.Label16.Text = "Quotation Index"
        '
        'MSR00002
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(714, 359)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.grpSearch)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MSR00002"
        Me.Text = "MSR00002 - Quotation Index (MSR02)"
        Me.grpSearch.ResumeLayout(False)
        Me.grpSearch.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents optSortQ As System.Windows.Forms.RadioButton
    Friend WithEvents optSortC As System.Windows.Forms.RadioButton
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboCustNoFm As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboCustNoTo As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cboQutSts As System.Windows.Forms.ComboBox
    Friend WithEvents grpSearch As System.Windows.Forms.GroupBox
    Friend WithEvents txtDateTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDateFrom As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
End Class
