<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MPR00005
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MPR00005))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtItmNoFm = New System.Windows.Forms.TextBox
        Me.txtItmNoTo = New System.Windows.Forms.TextBox
        Me.cmdShow = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.optByItmCat = New System.Windows.Forms.RadioButton
        Me.txtGRNDateTo = New System.Windows.Forms.MaskedTextBox
        Me.Label40 = New System.Windows.Forms.Label
        Me.txtGRNDateFm = New System.Windows.Forms.MaskedTextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.cboCustCatTo = New System.Windows.Forms.ComboBox
        Me.cboCustCatFm = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.optByItmNo = New System.Windows.Forms.RadioButton
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 12)
        Me.Label1.TabIndex = 387
        Me.Label1.Text = "Item No."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(377, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(18, 12)
        Me.Label4.TabIndex = 388
        Me.Label4.Text = "To"
        '
        'txtItmNoFm
        '
        Me.txtItmNoFm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtItmNoFm.Location = New System.Drawing.Point(172, 50)
        Me.txtItmNoFm.MaxLength = 10
        Me.txtItmNoFm.Name = "txtItmNoFm"
        Me.txtItmNoFm.Size = New System.Drawing.Size(193, 20)
        Me.txtItmNoFm.TabIndex = 0
        '
        'txtItmNoTo
        '
        Me.txtItmNoTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtItmNoTo.Location = New System.Drawing.Point(416, 50)
        Me.txtItmNoTo.MaxLength = 10
        Me.txtItmNoTo.Name = "txtItmNoTo"
        Me.txtItmNoTo.Size = New System.Drawing.Size(193, 20)
        Me.txtItmNoTo.TabIndex = 1
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(259, 244)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(140, 22)
        Me.cmdShow.TabIndex = 8
        Me.cmdShow.Text = "&Export to Excel"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 187)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 12)
        Me.Label2.TabIndex = 388
        Me.Label2.Text = "Order by"
        '
        'optByItmCat
        '
        Me.optByItmCat.AutoSize = True
        Me.optByItmCat.Location = New System.Drawing.Point(379, 185)
        Me.optByItmCat.Name = "optByItmCat"
        Me.optByItmCat.Size = New System.Drawing.Size(214, 16)
        Me.optByItmCat.TabIndex = 7
        Me.optByItmCat.Text = "Custom Category + Item No. + GRN No."
        Me.optByItmCat.UseVisualStyleBackColor = True
        '
        'txtGRNDateTo
        '
        Me.txtGRNDateTo.Location = New System.Drawing.Point(416, 138)
        Me.txtGRNDateTo.Mask = "##/##/####"
        Me.txtGRNDateTo.Name = "txtGRNDateTo"
        Me.txtGRNDateTo.Size = New System.Drawing.Size(75, 22)
        Me.txtGRNDateTo.TabIndex = 5
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(377, 142)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(18, 12)
        Me.Label40.TabIndex = 410
        Me.Label40.Text = "To"
        '
        'txtGRNDateFm
        '
        Me.txtGRNDateFm.Location = New System.Drawing.Point(172, 138)
        Me.txtGRNDateFm.Mask = "##/##/####"
        Me.txtGRNDateFm.Name = "txtGRNDateFm"
        Me.txtGRNDateFm.Size = New System.Drawing.Size(76, 22)
        Me.txtGRNDateFm.TabIndex = 4
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(124, 143)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(30, 12)
        Me.Label29.TabIndex = 409
        Me.Label29.Text = "From"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(13, 142)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(79, 12)
        Me.Label17.TabIndex = 406
        Me.Label17.Text = "GRN Issue Date"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(124, 98)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(30, 12)
        Me.Label12.TabIndex = 399
        Me.Label12.Text = "From"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(377, 98)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(18, 12)
        Me.Label13.TabIndex = 398
        Me.Label13.Text = "To"
        '
        'cboCustCatTo
        '
        Me.cboCustCatTo.FormattingEnabled = True
        Me.cboCustCatTo.Location = New System.Drawing.Point(416, 95)
        Me.cboCustCatTo.Name = "cboCustCatTo"
        Me.cboCustCatTo.Size = New System.Drawing.Size(193, 20)
        Me.cboCustCatTo.TabIndex = 3
        '
        'cboCustCatFm
        '
        Me.cboCustCatFm.FormattingEnabled = True
        Me.cboCustCatFm.Location = New System.Drawing.Point(172, 95)
        Me.cboCustCatFm.Name = "cboCustCatFm"
        Me.cboCustCatFm.Size = New System.Drawing.Size(193, 20)
        Me.cboCustCatFm.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(13, 97)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 12)
        Me.Label9.TabIndex = 391
        Me.Label9.Text = "Cust Category"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(124, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 12)
        Me.Label7.TabIndex = 389
        Me.Label7.Text = "From"
        '
        'optByItmNo
        '
        Me.optByItmNo.AutoSize = True
        Me.optByItmNo.Location = New System.Drawing.Point(125, 185)
        Me.optByItmNo.Name = "optByItmNo"
        Me.optByItmNo.Size = New System.Drawing.Size(117, 16)
        Me.optByItmNo.TabIndex = 6
        Me.optByItmNo.Text = "Item No + GRN No."
        Me.optByItmNo.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(143, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(364, 22)
        Me.Label6.TabIndex = 391
        Me.Label6.Text = "GRN Transaction (Adhoc && Misc Type Only)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label5.Location = New System.Drawing.Point(-5, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 13)
        Me.Label5.TabIndex = 390
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(259, 142)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(87, 12)
        Me.Label37.TabIndex = 411
        Me.Label37.Text = "(MM/DD/YYYY)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(503, 142)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 12)
        Me.Label3.TabIndex = 412
        Me.Label3.Text = "(MM/DD/YYYY)"
        '
        'MPR00005
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 271)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.txtGRNDateTo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtGRNDateFm)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.optByItmNo)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtItmNoTo)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtItmNoFm)
        Me.Controls.Add(Me.cboCustCatTo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboCustCatFm)
        Me.Controls.Add(Me.optByItmCat)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MPR00005"
        Me.Text = "MPR00005 - GRN Transaction List (Adhoc & Misc Type Only) (MPR05)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtItmNoFm As System.Windows.Forms.TextBox
    Friend WithEvents txtItmNoTo As System.Windows.Forms.TextBox
    Friend WithEvents optByItmCat As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboCustCatTo As System.Windows.Forms.ComboBox
    Friend WithEvents cboCustCatFm As System.Windows.Forms.ComboBox
    Friend WithEvents txtGRNDateTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents txtGRNDateFm As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents optByItmNo As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
