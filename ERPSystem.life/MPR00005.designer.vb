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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtItmNoFm = New System.Windows.Forms.TextBox
        Me.txtItmNoTo = New System.Windows.Forms.TextBox
        Me.cmdShow = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.optByItmCat = New System.Windows.Forms.RadioButton
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
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
        Me.Label1.Location = New System.Drawing.Point(12, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 387
        Me.Label1.Text = "Item No."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label4.Location = New System.Drawing.Point(428, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 13)
        Me.Label4.TabIndex = 388
        Me.Label4.Text = "To:"
        '
        'txtItmNoFm
        '
        Me.txtItmNoFm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtItmNoFm.Location = New System.Drawing.Point(171, 26)
        Me.txtItmNoFm.MaxLength = 10
        Me.txtItmNoFm.Name = "txtItmNoFm"
        Me.txtItmNoFm.Size = New System.Drawing.Size(229, 20)
        Me.txtItmNoFm.TabIndex = 0
        '
        'txtItmNoTo
        '
        Me.txtItmNoTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtItmNoTo.Location = New System.Drawing.Point(464, 26)
        Me.txtItmNoTo.MaxLength = 10
        Me.txtItmNoTo.Name = "txtItmNoTo"
        Me.txtItmNoTo.Size = New System.Drawing.Size(229, 20)
        Me.txtItmNoTo.TabIndex = 1
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(323, 208)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(117, 27)
        Me.cmdShow.TabIndex = 8
        Me.cmdShow.Text = "&Export to Excel"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(12, 124)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 388
        Me.Label2.Text = "Order by"
        '
        'optByItmCat
        '
        Me.optByItmCat.AutoSize = True
        Me.optByItmCat.Location = New System.Drawing.Point(363, 124)
        Me.optByItmCat.Name = "optByItmCat"
        Me.optByItmCat.Size = New System.Drawing.Size(203, 17)
        Me.optByItmCat.TabIndex = 7
        Me.optByItmCat.Text = "Custom Category + Item No. + GRN #"
        Me.optByItmCat.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtGRNDateTo)
        Me.GroupBox3.Controls.Add(Me.Label40)
        Me.GroupBox3.Controls.Add(Me.txtGRNDateFm)
        Me.GroupBox3.Controls.Add(Me.Label29)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.cboCustCatTo)
        Me.GroupBox3.Controls.Add(Me.cboCustCatFm)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.optByItmCat)
        Me.GroupBox3.Controls.Add(Me.optByItmNo)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.txtItmNoFm)
        Me.GroupBox3.Controls.Add(Me.txtItmNoTo)
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox3.Location = New System.Drawing.Point(12, 43)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(720, 155)
        Me.GroupBox3.TabIndex = 28
        Me.GroupBox3.TabStop = False
        '
        'txtGRNDateTo
        '
        Me.txtGRNDateTo.Location = New System.Drawing.Point(464, 86)
        Me.txtGRNDateTo.Mask = "##/##/####"
        Me.txtGRNDateTo.Name = "txtGRNDateTo"
        Me.txtGRNDateTo.Size = New System.Drawing.Size(176, 20)
        Me.txtGRNDateTo.TabIndex = 5
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(428, 86)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(26, 13)
        Me.Label40.TabIndex = 410
        Me.Label40.Text = "To :"
        '
        'txtGRNDateFm
        '
        Me.txtGRNDateFm.Location = New System.Drawing.Point(171, 86)
        Me.txtGRNDateFm.Mask = "##/##/####"
        Me.txtGRNDateFm.Name = "txtGRNDateFm"
        Me.txtGRNDateFm.Size = New System.Drawing.Size(176, 20)
        Me.txtGRNDateFm.TabIndex = 4
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(123, 86)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(36, 13)
        Me.Label29.TabIndex = 409
        Me.Label29.Text = "From :"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(12, 86)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(85, 13)
        Me.Label17.TabIndex = 406
        Me.Label17.Text = "GRN Issue Date"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label12.Location = New System.Drawing.Point(123, 58)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(36, 13)
        Me.Label12.TabIndex = 399
        Me.Label12.Text = "From :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label13.Location = New System.Drawing.Point(428, 58)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(23, 13)
        Me.Label13.TabIndex = 398
        Me.Label13.Text = "To:"
        '
        'cboCustCatTo
        '
        Me.cboCustCatTo.FormattingEnabled = True
        Me.cboCustCatTo.Location = New System.Drawing.Point(464, 58)
        Me.cboCustCatTo.Name = "cboCustCatTo"
        Me.cboCustCatTo.Size = New System.Drawing.Size(229, 21)
        Me.cboCustCatTo.TabIndex = 3
        '
        'cboCustCatFm
        '
        Me.cboCustCatFm.FormattingEnabled = True
        Me.cboCustCatFm.Location = New System.Drawing.Point(171, 58)
        Me.cboCustCatFm.Name = "cboCustCatFm"
        Me.cboCustCatFm.Size = New System.Drawing.Size(229, 21)
        Me.cboCustCatFm.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label9.Location = New System.Drawing.Point(12, 58)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 13)
        Me.Label9.TabIndex = 391
        Me.Label9.Text = "Cust Category"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label7.Location = New System.Drawing.Point(123, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 13)
        Me.Label7.TabIndex = 389
        Me.Label7.Text = "From :"
        '
        'optByItmNo
        '
        Me.optByItmNo.AutoSize = True
        Me.optByItmNo.Location = New System.Drawing.Point(171, 124)
        Me.optByItmNo.Name = "optByItmNo"
        Me.optByItmNo.Size = New System.Drawing.Size(108, 17)
        Me.optByItmNo.TabIndex = 6
        Me.optByItmNo.Text = "Item No + GRN #"
        Me.optByItmNo.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label3.Location = New System.Drawing.Point(15, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 389
        Me.Label3.Text = "MPR00005"
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
        Me.Label6.Location = New System.Drawing.Point(143, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(364, 22)
        Me.Label6.TabIndex = 391
        Me.Label6.Text = "GRN Transaction (Adhoc && Misc Type Only)"
        '
        'MPR00005
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(756, 260)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.cmdShow)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MPR00005"
        Me.Text = "MPR00005 - GRN Transaction List (Adhoc & Misc Type Only)"
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
    Friend WithEvents optByItmCat As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
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
End Class
