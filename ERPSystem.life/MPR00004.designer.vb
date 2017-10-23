<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MPR00004
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MPR00004))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtItmNoFm = New System.Windows.Forms.TextBox
        Me.txtItmNoTo = New System.Windows.Forms.TextBox
        Me.cmdShow = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.optByItmNo = New System.Windows.Forms.RadioButton
        Me.optByItmCat = New System.Windows.Forms.RadioButton
        Me.optByCustCat = New System.Windows.Forms.RadioButton
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
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
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
        Me.cmdShow.TabIndex = 9
        Me.cmdShow.Text = "&Export to Excel"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 188)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 12)
        Me.Label2.TabIndex = 388
        Me.Label2.Text = "Order by"
        '
        'optByItmNo
        '
        Me.optByItmNo.AutoSize = True
        Me.optByItmNo.Checked = True
        Me.optByItmNo.Location = New System.Drawing.Point(128, 188)
        Me.optByItmNo.Name = "optByItmNo"
        Me.optByItmNo.Size = New System.Drawing.Size(61, 16)
        Me.optByItmNo.TabIndex = 6
        Me.optByItmNo.TabStop = True
        Me.optByItmNo.Text = "Item No"
        Me.optByItmNo.UseVisualStyleBackColor = True
        '
        'optByItmCat
        '
        Me.optByItmCat.AutoSize = True
        Me.optByItmCat.Location = New System.Drawing.Point(261, 188)
        Me.optByItmCat.Name = "optByItmCat"
        Me.optByItmCat.Size = New System.Drawing.Size(143, 16)
        Me.optByItmCat.TabIndex = 7
        Me.optByItmCat.Text = "Item Category + Item No."
        Me.optByItmCat.UseVisualStyleBackColor = True
        '
        'optByCustCat
        '
        Me.optByCustCat.AutoSize = True
        Me.optByCustCat.Location = New System.Drawing.Point(457, 188)
        Me.optByCustCat.Name = "optByCustCat"
        Me.optByCustCat.Size = New System.Drawing.Size(158, 16)
        Me.optByCustCat.TabIndex = 8
        Me.optByCustCat.Text = "Custum Category + Item No."
        Me.optByCustCat.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(124, 143)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(30, 12)
        Me.Label12.TabIndex = 399
        Me.Label12.Text = "From"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(377, 142)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(18, 12)
        Me.Label13.TabIndex = 398
        Me.Label13.Text = "To"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(124, 98)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(30, 12)
        Me.Label10.TabIndex = 397
        Me.Label10.Text = "From"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(377, 98)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(18, 12)
        Me.Label11.TabIndex = 396
        Me.Label11.Text = "To"
        '
        'cboCustCatTo
        '
        Me.cboCustCatTo.FormattingEnabled = True
        Me.cboCustCatTo.Location = New System.Drawing.Point(416, 138)
        Me.cboCustCatTo.Name = "cboCustCatTo"
        Me.cboCustCatTo.Size = New System.Drawing.Size(193, 20)
        Me.cboCustCatTo.TabIndex = 5
        '
        'cboCustCatFm
        '
        Me.cboCustCatFm.FormattingEnabled = True
        Me.cboCustCatFm.Location = New System.Drawing.Point(172, 138)
        Me.cboCustCatFm.Name = "cboCustCatFm"
        Me.cboCustCatFm.Size = New System.Drawing.Size(193, 20)
        Me.cboCustCatFm.TabIndex = 4
        '
        'cboItemCatTo
        '
        Me.cboItemCatTo.FormattingEnabled = True
        Me.cboItemCatTo.Location = New System.Drawing.Point(416, 95)
        Me.cboItemCatTo.Name = "cboItemCatTo"
        Me.cboItemCatTo.Size = New System.Drawing.Size(193, 20)
        Me.cboItemCatTo.TabIndex = 3
        '
        'cboItemCatFm
        '
        Me.cboItemCatFm.FormattingEnabled = True
        Me.cboItemCatFm.Location = New System.Drawing.Point(172, 95)
        Me.cboItemCatFm.Name = "cboItemCatFm"
        Me.cboItemCatFm.Size = New System.Drawing.Size(193, 20)
        Me.cboItemCatFm.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(13, 142)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 12)
        Me.Label9.TabIndex = 391
        Me.Label9.Text = "Cust Category"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 97)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 12)
        Me.Label8.TabIndex = 390
        Me.Label8.Text = "Item Category"
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
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label5.Location = New System.Drawing.Point(-5, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 13)
        Me.Label5.TabIndex = 390
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(229, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(204, 22)
        Me.Label6.TabIndex = 391
        Me.Label6.Text = "MPO Item Master Listing"
        '
        'MPR00004
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 271)
        Me.Controls.Add(Me.optByCustCat)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboCustCatTo)
        Me.Controls.Add(Me.txtItmNoTo)
        Me.Controls.Add(Me.cboCustCatFm)
        Me.Controls.Add(Me.txtItmNoFm)
        Me.Controls.Add(Me.cboItemCatTo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboItemCatFm)
        Me.Controls.Add(Me.optByItmNo)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.optByItmCat)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label7)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MPR00004"
        Me.Text = "MPR00004 - MPO Item Master Listing (MPR04)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtItmNoFm As System.Windows.Forms.TextBox
    Friend WithEvents txtItmNoTo As System.Windows.Forms.TextBox
    Friend WithEvents optByItmNo As System.Windows.Forms.RadioButton
    Friend WithEvents optByItmCat As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboItemCatFm As System.Windows.Forms.ComboBox
    Friend WithEvents optByCustCat As System.Windows.Forms.RadioButton
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboCustCatTo As System.Windows.Forms.ComboBox
    Friend WithEvents cboCustCatFm As System.Windows.Forms.ComboBox
    Friend WithEvents cboItemCatTo As System.Windows.Forms.ComboBox
End Class
