<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MSR00009
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MSR00009))
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.text_etddateto = New System.Windows.Forms.MaskedTextBox
        Me.text_etddatefrom = New System.Windows.Forms.MaskedTextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rb_toexcel2 = New System.Windows.Forms.RadioButton
        Me.rb_toexcel1 = New System.Windows.Forms.RadioButton
        Me.Label14 = New System.Windows.Forms.Label
        Me.cb_custnoto = New System.Windows.Forms.ComboBox
        Me.cb_custnofrom = New System.Windows.Forms.ComboBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rb_sort_csn = New System.Windows.Forms.RadioButton
        Me.rb_sort_inv = New System.Windows.Forms.RadioButton
        Me.Label16 = New System.Windows.Forms.Label
        Me.cb_invstatus = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.text_invdateto = New System.Windows.Forms.MaskedTextBox
        Me.text_invdatefrom = New System.Windows.Forms.MaskedTextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtToInvoice = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtFromInvoice = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdShow = New System.Windows.Forms.Button
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(217, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(246, 25)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Invoice Summary Report"
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.Color.White
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.Location = New System.Drawing.Point(335, 63)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.Size = New System.Drawing.Size(367, 22)
        Me.txtCoNam.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(238, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 12)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Company Name:"
        '
        'cboCoCde
        '
        Me.cboCoCde.BackColor = System.Drawing.Color.White
        Me.cboCoCde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(136, 61)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(87, 20)
        Me.cboCoCde.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(29, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 12)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Company Code"
        '
        'text_etddateto
        '
        Me.text_etddateto.Location = New System.Drawing.Point(455, 219)
        Me.text_etddateto.Mask = "00/00/0000"
        Me.text_etddateto.Name = "text_etddateto"
        Me.text_etddateto.Size = New System.Drawing.Size(217, 22)
        Me.text_etddateto.TabIndex = 13
        '
        'text_etddatefrom
        '
        Me.text_etddatefrom.Location = New System.Drawing.Point(205, 219)
        Me.text_etddatefrom.Mask = "00/00/0000"
        Me.text_etddatefrom.Name = "text_etddatefrom"
        Me.text_etddatefrom.Size = New System.Drawing.Size(198, 22)
        Me.text_etddatefrom.TabIndex = 12
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(30, 227)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(87, 12)
        Me.Label17.TabIndex = 9
        Me.Label17.Text = "[MM/DD/YYYY]"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(30, 215)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(51, 12)
        Me.Label18.TabIndex = 8
        Me.Label18.Text = "ETD Date"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(429, 224)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(18, 12)
        Me.Label19.TabIndex = 6
        Me.Label19.Text = "To"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(169, 224)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(30, 12)
        Me.Label20.TabIndex = 4
        Me.Label20.Text = "From"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rb_toexcel2)
        Me.GroupBox2.Controls.Add(Me.rb_toexcel1)
        Me.GroupBox2.Location = New System.Drawing.Point(182, 333)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(478, 39)
        Me.GroupBox2.TabIndex = 19
        Me.GroupBox2.TabStop = False
        '
        'rb_toexcel2
        '
        Me.rb_toexcel2.AutoSize = True
        Me.rb_toexcel2.Location = New System.Drawing.Point(235, 14)
        Me.rb_toexcel2.Name = "rb_toexcel2"
        Me.rb_toexcel2.Size = New System.Drawing.Size(37, 16)
        Me.rb_toexcel2.TabIndex = 21
        Me.rb_toexcel2.TabStop = True
        Me.rb_toexcel2.Text = "No"
        Me.rb_toexcel2.UseVisualStyleBackColor = True
        '
        'rb_toexcel1
        '
        Me.rb_toexcel1.AutoSize = True
        Me.rb_toexcel1.Location = New System.Drawing.Point(100, 17)
        Me.rb_toexcel1.Name = "rb_toexcel1"
        Me.rb_toexcel1.Size = New System.Drawing.Size(40, 16)
        Me.rb_toexcel1.TabIndex = 20
        Me.rb_toexcel1.TabStop = True
        Me.rb_toexcel1.Text = "Yes"
        Me.rb_toexcel1.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(30, 352)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(78, 12)
        Me.Label14.TabIndex = 8
        Me.Label14.Text = "Export to Excel"
        '
        'cb_custnoto
        '
        Me.cb_custnoto.FormattingEnabled = True
        Me.cb_custnoto.ItemHeight = 12
        Me.cb_custnoto.Location = New System.Drawing.Point(455, 145)
        Me.cb_custnoto.Name = "cb_custnoto"
        Me.cb_custnoto.Size = New System.Drawing.Size(217, 20)
        Me.cb_custnoto.TabIndex = 7
        '
        'cb_custnofrom
        '
        Me.cb_custnofrom.FormattingEnabled = True
        Me.cb_custnofrom.ItemHeight = 12
        Me.cb_custnofrom.Location = New System.Drawing.Point(205, 145)
        Me.cb_custnofrom.Name = "cb_custnofrom"
        Me.cb_custnofrom.Size = New System.Drawing.Size(198, 20)
        Me.cb_custnofrom.TabIndex = 6
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rb_sort_csn)
        Me.GroupBox3.Controls.Add(Me.rb_sort_inv)
        Me.GroupBox3.Location = New System.Drawing.Point(182, 288)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(478, 39)
        Me.GroupBox3.TabIndex = 16
        Me.GroupBox3.TabStop = False
        '
        'rb_sort_csn
        '
        Me.rb_sort_csn.AutoSize = True
        Me.rb_sort_csn.Location = New System.Drawing.Point(235, 17)
        Me.rb_sort_csn.Name = "rb_sort_csn"
        Me.rb_sort_csn.Size = New System.Drawing.Size(126, 16)
        Me.rb_sort_csn.TabIndex = 18
        Me.rb_sort_csn.TabStop = True
        Me.rb_sort_csn.Text = "Customer Short Name"
        Me.rb_sort_csn.UseVisualStyleBackColor = True
        '
        'rb_sort_inv
        '
        Me.rb_sort_inv.AutoSize = True
        Me.rb_sort_inv.Location = New System.Drawing.Point(100, 15)
        Me.rb_sort_inv.Name = "rb_sort_inv"
        Me.rb_sort_inv.Size = New System.Drawing.Size(58, 16)
        Me.rb_sort_inv.TabIndex = 17
        Me.rb_sort_inv.TabStop = True
        Me.rb_sort_inv.Text = "Invoice"
        Me.rb_sort_inv.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(30, 305)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(41, 12)
        Me.Label16.TabIndex = 8
        Me.Label16.Text = "Sort By"
        '
        'cb_invstatus
        '
        Me.cb_invstatus.FormattingEnabled = True
        Me.cb_invstatus.ItemHeight = 12
        Me.cb_invstatus.Location = New System.Drawing.Point(204, 257)
        Me.cb_invstatus.Name = "cb_invstatus"
        Me.cb_invstatus.Size = New System.Drawing.Size(198, 20)
        Me.cb_invstatus.TabIndex = 15
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(30, 262)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(73, 12)
        Me.Label15.TabIndex = 8
        Me.Label15.Text = "Invoice Status:"
        '
        'text_invdateto
        '
        Me.text_invdateto.Location = New System.Drawing.Point(455, 181)
        Me.text_invdateto.Mask = "00/00/0000"
        Me.text_invdateto.Name = "text_invdateto"
        Me.text_invdateto.Size = New System.Drawing.Size(217, 22)
        Me.text_invdateto.TabIndex = 10
        '
        'text_invdatefrom
        '
        Me.text_invdatefrom.Location = New System.Drawing.Point(205, 180)
        Me.text_invdatefrom.Mask = "00/00/0000"
        Me.text_invdatefrom.Name = "text_invdatefrom"
        Me.text_invdatefrom.Size = New System.Drawing.Size(198, 22)
        Me.text_invdatefrom.TabIndex = 9
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(30, 188)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(87, 12)
        Me.Label13.TabIndex = 9
        Me.Label13.Text = "[MM/DD/YYYY]"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(30, 176)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 12)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "Invoice Date"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(428, 186)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(18, 12)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "To"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(169, 185)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(30, 12)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "From"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(30, 148)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 12)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Customer No."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(427, 149)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(18, 12)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "To"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(169, 148)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(30, 12)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "From"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(30, 113)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 12)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Invoice No."
        '
        'txtToInvoice
        '
        Me.txtToInvoice.Location = New System.Drawing.Point(454, 111)
        Me.txtToInvoice.Name = "txtToInvoice"
        Me.txtToInvoice.Size = New System.Drawing.Size(218, 22)
        Me.txtToInvoice.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(427, 115)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(18, 12)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "To"
        '
        'txtFromInvoice
        '
        Me.txtFromInvoice.Location = New System.Drawing.Point(205, 110)
        Me.txtFromInvoice.Name = "txtFromInvoice"
        Me.txtFromInvoice.Size = New System.Drawing.Size(198, 22)
        Me.txtFromInvoice.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(169, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 12)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "From"
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(284, 396)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(145, 25)
        Me.cmdShow.TabIndex = 22
        Me.cmdShow.Text = "Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'MSR00009
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(714, 471)
        Me.Controls.Add(Me.cb_invstatus)
        Me.Controls.Add(Me.text_invdateto)
        Me.Controls.Add(Me.text_etddateto)
        Me.Controls.Add(Me.text_invdatefrom)
        Me.Controls.Add(Me.text_etddatefrom)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cb_custnoto)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.cb_custnofrom)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtFromInvoice)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtToInvoice)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MSR00009"
        Me.Text = "MSR00009 - Invoice Summary Report (MSR09)"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtToInvoice As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFromInvoice As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rb_sort_csn As System.Windows.Forms.RadioButton
    Friend WithEvents rb_sort_inv As System.Windows.Forms.RadioButton
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cb_invstatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents cb_custnoto As System.Windows.Forms.ComboBox
    Friend WithEvents cb_custnofrom As System.Windows.Forms.ComboBox
    Friend WithEvents text_invdatefrom As System.Windows.Forms.MaskedTextBox
    Friend WithEvents text_invdateto As System.Windows.Forms.MaskedTextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rb_toexcel2 As System.Windows.Forms.RadioButton
    Friend WithEvents rb_toexcel1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents text_etddateto As System.Windows.Forms.MaskedTextBox
    Friend WithEvents text_etddatefrom As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
End Class
