<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MPR00006
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
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtItmNoFm = New System.Windows.Forms.TextBox
        Me.txtItmNoTo = New System.Windows.Forms.TextBox
        Me.cmdShow = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.optByItemNo = New System.Windows.Forms.RadioButton
        Me.OptByItemCat = New System.Windows.Forms.RadioButton
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.optByVendor = New System.Windows.Forms.RadioButton
        Me.txtMPODateTo = New System.Windows.Forms.MaskedTextBox
        Me.Label40 = New System.Windows.Forms.Label
        Me.txtMPODateFm = New System.Windows.Forms.MaskedTextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.cboVenTo = New System.Windows.Forms.ComboBox
        Me.cboVenFm = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.OptByCustCat = New System.Windows.Forms.RadioButton
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.cboCustCatTo = New System.Windows.Forms.ComboBox
        Me.cboCustCatFm = New System.Windows.Forms.ComboBox
        Me.cboItemCatTo = New System.Windows.Forms.ComboBox
        Me.cboItemCatFm = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(12, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 387
        Me.Label1.Text = "Item No."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label4.Location = New System.Drawing.Point(428, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 13)
        Me.Label4.TabIndex = 388
        Me.Label4.Text = "To:"
        '
        'txtItmNoFm
        '
        Me.txtItmNoFm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtItmNoFm.Location = New System.Drawing.Point(171, 45)
        Me.txtItmNoFm.MaxLength = 10
        Me.txtItmNoFm.Name = "txtItmNoFm"
        Me.txtItmNoFm.Size = New System.Drawing.Size(229, 20)
        Me.txtItmNoFm.TabIndex = 2
        '
        'txtItmNoTo
        '
        Me.txtItmNoTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtItmNoTo.Location = New System.Drawing.Point(464, 45)
        Me.txtItmNoTo.MaxLength = 10
        Me.txtItmNoTo.Name = "txtItmNoTo"
        Me.txtItmNoTo.Size = New System.Drawing.Size(229, 20)
        Me.txtItmNoTo.TabIndex = 3
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(323, 272)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(117, 27)
        Me.cmdShow.TabIndex = 13
        Me.cmdShow.Text = "&Export to Excel"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(12, 173)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 388
        Me.Label2.Text = "Order by"
        '
        'optByItemNo
        '
        Me.optByItemNo.AutoSize = True
        Me.optByItemNo.Location = New System.Drawing.Point(259, 173)
        Me.optByItemNo.Name = "optByItemNo"
        Me.optByItemNo.Size = New System.Drawing.Size(62, 17)
        Me.optByItemNo.TabIndex = 11
        Me.optByItemNo.Text = "Item No"
        Me.optByItemNo.UseVisualStyleBackColor = True
        '
        'OptByItemCat
        '
        Me.OptByItemCat.AutoSize = True
        Me.OptByItemCat.Location = New System.Drawing.Point(363, 173)
        Me.OptByItemCat.Name = "OptByItemCat"
        Me.OptByItemCat.Size = New System.Drawing.Size(142, 17)
        Me.OptByItemCat.TabIndex = 12
        Me.OptByItemCat.Text = "Item Category + Item No."
        Me.OptByItemCat.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.optByVendor)
        Me.GroupBox3.Controls.Add(Me.txtMPODateTo)
        Me.GroupBox3.Controls.Add(Me.Label40)
        Me.GroupBox3.Controls.Add(Me.txtMPODateFm)
        Me.GroupBox3.Controls.Add(Me.Label29)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.cboVenTo)
        Me.GroupBox3.Controls.Add(Me.cboVenFm)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.OptByCustCat)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.cboCustCatTo)
        Me.GroupBox3.Controls.Add(Me.cboCustCatFm)
        Me.GroupBox3.Controls.Add(Me.cboItemCatTo)
        Me.GroupBox3.Controls.Add(Me.cboItemCatFm)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.OptByItemCat)
        Me.GroupBox3.Controls.Add(Me.optByItemNo)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.txtItmNoFm)
        Me.GroupBox3.Controls.Add(Me.txtItmNoTo)
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox3.Location = New System.Drawing.Point(12, 43)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(720, 209)
        Me.GroupBox3.TabIndex = 28
        Me.GroupBox3.TabStop = False
        '
        'optByVendor
        '
        Me.optByVendor.AutoSize = True
        Me.optByVendor.Checked = True
        Me.optByVendor.Location = New System.Drawing.Point(126, 173)
        Me.optByVendor.Name = "optByVendor"
        Me.optByVendor.Size = New System.Drawing.Size(111, 17)
        Me.optByVendor.TabIndex = 10
        Me.optByVendor.TabStop = True
        Me.optByVendor.Text = "Vendor + Item No."
        Me.optByVendor.UseVisualStyleBackColor = True
        '
        'txtMPODateTo
        '
        Me.txtMPODateTo.Location = New System.Drawing.Point(464, 136)
        Me.txtMPODateTo.Mask = "##/##/####"
        Me.txtMPODateTo.Name = "txtMPODateTo"
        Me.txtMPODateTo.Size = New System.Drawing.Size(176, 20)
        Me.txtMPODateTo.TabIndex = 9
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(428, 140)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(26, 13)
        Me.Label40.TabIndex = 410
        Me.Label40.Text = "To :"
        '
        'txtMPODateFm
        '
        Me.txtMPODateFm.Location = New System.Drawing.Point(171, 137)
        Me.txtMPODateFm.Mask = "##/##/####"
        Me.txtMPODateFm.Name = "txtMPODateFm"
        Me.txtMPODateFm.Size = New System.Drawing.Size(176, 20)
        Me.txtMPODateFm.TabIndex = 8
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(123, 140)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(36, 13)
        Me.Label29.TabIndex = 409
        Me.Label29.Text = "From :"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(12, 140)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(91, 13)
        Me.Label17.TabIndex = 406
        Me.Label17.Text = "MPO Create Date"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label14.Location = New System.Drawing.Point(123, 17)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(36, 13)
        Me.Label14.TabIndex = 405
        Me.Label14.Text = "From :"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label15.Location = New System.Drawing.Point(428, 20)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(23, 13)
        Me.Label15.TabIndex = 404
        Me.Label15.Text = "To:"
        '
        'cboVenTo
        '
        Me.cboVenTo.FormattingEnabled = True
        Me.cboVenTo.Location = New System.Drawing.Point(464, 17)
        Me.cboVenTo.Name = "cboVenTo"
        Me.cboVenTo.Size = New System.Drawing.Size(229, 21)
        Me.cboVenTo.TabIndex = 1
        '
        'cboVenFm
        '
        Me.cboVenFm.FormattingEnabled = True
        Me.cboVenFm.Location = New System.Drawing.Point(171, 13)
        Me.cboVenFm.Name = "cboVenFm"
        Me.cboVenFm.Size = New System.Drawing.Size(229, 21)
        Me.cboVenFm.TabIndex = 0
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label16.Location = New System.Drawing.Point(12, 20)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(41, 13)
        Me.Label16.TabIndex = 401
        Me.Label16.Text = "Vendor"
        '
        'OptByCustCat
        '
        Me.OptByCustCat.AutoSize = True
        Me.OptByCustCat.Location = New System.Drawing.Point(538, 173)
        Me.OptByCustCat.Name = "OptByCustCat"
        Me.OptByCustCat.Size = New System.Drawing.Size(143, 17)
        Me.OptByCustCat.TabIndex = 400
        Me.OptByCustCat.Text = "Cust Category + Item No."
        Me.OptByCustCat.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label12.Location = New System.Drawing.Point(123, 109)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(36, 13)
        Me.Label12.TabIndex = 399
        Me.Label12.Text = "From :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label13.Location = New System.Drawing.Point(428, 112)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(23, 13)
        Me.Label13.TabIndex = 398
        Me.Label13.Text = "To:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label10.Location = New System.Drawing.Point(123, 81)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 13)
        Me.Label10.TabIndex = 397
        Me.Label10.Text = "From :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label11.Location = New System.Drawing.Point(428, 84)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(23, 13)
        Me.Label11.TabIndex = 396
        Me.Label11.Text = "To:"
        '
        'cboCustCatTo
        '
        Me.cboCustCatTo.FormattingEnabled = True
        Me.cboCustCatTo.Location = New System.Drawing.Point(464, 109)
        Me.cboCustCatTo.Name = "cboCustCatTo"
        Me.cboCustCatTo.Size = New System.Drawing.Size(229, 21)
        Me.cboCustCatTo.TabIndex = 7
        '
        'cboCustCatFm
        '
        Me.cboCustCatFm.FormattingEnabled = True
        Me.cboCustCatFm.Location = New System.Drawing.Point(171, 105)
        Me.cboCustCatFm.Name = "cboCustCatFm"
        Me.cboCustCatFm.Size = New System.Drawing.Size(229, 21)
        Me.cboCustCatFm.TabIndex = 6
        '
        'cboItemCatTo
        '
        Me.cboItemCatTo.FormattingEnabled = True
        Me.cboItemCatTo.Location = New System.Drawing.Point(464, 75)
        Me.cboItemCatTo.Name = "cboItemCatTo"
        Me.cboItemCatTo.Size = New System.Drawing.Size(229, 21)
        Me.cboItemCatTo.TabIndex = 5
        '
        'cboItemCatFm
        '
        Me.cboItemCatFm.FormattingEnabled = True
        Me.cboItemCatFm.Location = New System.Drawing.Point(171, 78)
        Me.cboItemCatFm.Name = "cboItemCatFm"
        Me.cboItemCatFm.Size = New System.Drawing.Size(229, 21)
        Me.cboItemCatFm.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label9.Location = New System.Drawing.Point(12, 112)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 13)
        Me.Label9.TabIndex = 391
        Me.Label9.Text = "Cust Category"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label8.Location = New System.Drawing.Point(12, 78)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 13)
        Me.Label8.TabIndex = 390
        Me.Label8.Text = "Item Category"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label7.Location = New System.Drawing.Point(123, 45)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 13)
        Me.Label7.TabIndex = 389
        Me.Label7.Text = "From :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label3.Location = New System.Drawing.Point(15, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 389
        Me.Label3.Text = "MPR00006"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label5.Location = New System.Drawing.Point(-5, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 13)
        Me.Label5.TabIndex = 390
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(253, 1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(286, 22)
        Me.Label6.TabIndex = 391
        Me.Label6.Text = "MPO Transaction Statistics Report"
        '
        'MPR00006
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(759, 313)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.cmdShow)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MPR00006"
        Me.Text = "MPR00006 - MPO Transaction Statistics Report"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtItmNoFm As System.Windows.Forms.TextBox
    Friend WithEvents txtItmNoTo As System.Windows.Forms.TextBox
    Friend WithEvents optByItemNo As System.Windows.Forms.RadioButton
    Friend WithEvents OptByItemCat As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboItemCatFm As System.Windows.Forms.ComboBox
    Friend WithEvents OptByCustCat As System.Windows.Forms.RadioButton
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboCustCatTo As System.Windows.Forms.ComboBox
    Friend WithEvents cboCustCatFm As System.Windows.Forms.ComboBox
    Friend WithEvents cboItemCatTo As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cboVenTo As System.Windows.Forms.ComboBox
    Friend WithEvents cboVenFm As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtMPODateTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents txtMPODateFm As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents optByVendor As System.Windows.Forms.RadioButton
End Class
