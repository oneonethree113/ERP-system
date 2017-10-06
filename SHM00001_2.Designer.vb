<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SHM00001_2
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
        Me.DataGrid1 = New System.Windows.Forms.DataGridView
        Me.Label76 = New System.Windows.Forms.Label
        Me.cmdOK = New System.Windows.Forms.Button
        Me.cboCtr = New System.Windows.Forms.ComboBox
        Me.txtActVol = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.cboInv = New System.Windows.Forms.ComboBox
        Me.cboSort1 = New System.Windows.Forms.ComboBox
        Me.cboSort2 = New System.Windows.Forms.ComboBox
        Me.cboSort3 = New System.Windows.Forms.ComboBox
        Me.cboUntAmt = New System.Windows.Forms.ComboBox
        Me.txtTtlGrs = New System.Windows.Forms.TextBox
        Me.txtTtlCtn = New System.Windows.Forms.TextBox
        Me.txtTtlNet = New System.Windows.Forms.TextBox
        Me.txtTtlAmt = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGrid1
        '
        Me.DataGrid1.AllowUserToAddRows = False
        Me.DataGrid1.AllowUserToDeleteRows = False
        Me.DataGrid1.ColumnHeadersHeight = 20
        Me.DataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGrid1.Location = New System.Drawing.Point(11, 89)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.RowHeadersWidth = 20
        Me.DataGrid1.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGrid1.RowTemplate.Height = 16
        Me.DataGrid1.Size = New System.Drawing.Size(735, 239)
        Me.DataGrid1.TabIndex = 374
        '
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.Location = New System.Drawing.Point(7, 74)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(77, 13)
        Me.Label76.TabIndex = 373
        Me.Label76.Text = "Shipping Item :"
        '
        'cmdOK
        '
        Me.cmdOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdOK.Location = New System.Drawing.Point(281, 361)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(64, 34)
        Me.cmdOK.TabIndex = 372
        Me.cmdOK.TabStop = False
        Me.cmdOK.Text = "&OK"
        '
        'cboCtr
        '
        Me.cboCtr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboCtr.FormattingEnabled = True
        Me.cboCtr.Location = New System.Drawing.Point(174, 12)
        Me.cboCtr.Name = "cboCtr"
        Me.cboCtr.Size = New System.Drawing.Size(118, 21)
        Me.cboCtr.TabIndex = 375
        '
        'txtActVol
        '
        Me.txtActVol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtActVol.Location = New System.Drawing.Point(487, 334)
        Me.txtActVol.MaxLength = 10
        Me.txtActVol.Name = "txtActVol"
        Me.txtActVol.Size = New System.Drawing.Size(86, 20)
        Me.txtActVol.TabIndex = 376
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label18.Location = New System.Drawing.Point(387, 336)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(85, 13)
        Me.Label18.TabIndex = 377
        Me.Label18.Text = "Total MOD CBM"
        '
        'cboInv
        '
        Me.cboInv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboInv.FormattingEnabled = True
        Me.cboInv.Location = New System.Drawing.Point(359, 12)
        Me.cboInv.Name = "cboInv"
        Me.cboInv.Size = New System.Drawing.Size(118, 21)
        Me.cboInv.TabIndex = 378
        '
        'cboSort1
        '
        Me.cboSort1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboSort1.FormattingEnabled = True
        Me.cboSort1.Location = New System.Drawing.Point(107, 39)
        Me.cboSort1.Name = "cboSort1"
        Me.cboSort1.Size = New System.Drawing.Size(118, 21)
        Me.cboSort1.TabIndex = 379
        '
        'cboSort2
        '
        Me.cboSort2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboSort2.FormattingEnabled = True
        Me.cboSort2.Location = New System.Drawing.Point(299, 39)
        Me.cboSort2.Name = "cboSort2"
        Me.cboSort2.Size = New System.Drawing.Size(118, 21)
        Me.cboSort2.TabIndex = 380
        '
        'cboSort3
        '
        Me.cboSort3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboSort3.FormattingEnabled = True
        Me.cboSort3.Location = New System.Drawing.Point(513, 34)
        Me.cboSort3.Name = "cboSort3"
        Me.cboSort3.Size = New System.Drawing.Size(118, 21)
        Me.cboSort3.TabIndex = 381
        '
        'cboUntAmt
        '
        Me.cboUntAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboUntAmt.FormattingEnabled = True
        Me.cboUntAmt.Location = New System.Drawing.Point(487, 388)
        Me.cboUntAmt.Name = "cboUntAmt"
        Me.cboUntAmt.Size = New System.Drawing.Size(70, 21)
        Me.cboUntAmt.TabIndex = 382
        '
        'txtTtlGrs
        '
        Me.txtTtlGrs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtTtlGrs.Location = New System.Drawing.Point(660, 336)
        Me.txtTtlGrs.MaxLength = 10
        Me.txtTtlGrs.Name = "txtTtlGrs"
        Me.txtTtlGrs.Size = New System.Drawing.Size(86, 20)
        Me.txtTtlGrs.TabIndex = 383
        '
        'txtTtlCtn
        '
        Me.txtTtlCtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtTtlCtn.Location = New System.Drawing.Point(487, 361)
        Me.txtTtlCtn.MaxLength = 10
        Me.txtTtlCtn.Name = "txtTtlCtn"
        Me.txtTtlCtn.Size = New System.Drawing.Size(86, 20)
        Me.txtTtlCtn.TabIndex = 384
        '
        'txtTtlNet
        '
        Me.txtTtlNet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtTtlNet.Location = New System.Drawing.Point(660, 361)
        Me.txtTtlNet.MaxLength = 10
        Me.txtTtlNet.Name = "txtTtlNet"
        Me.txtTtlNet.Size = New System.Drawing.Size(86, 20)
        Me.txtTtlNet.TabIndex = 385
        '
        'txtTtlAmt
        '
        Me.txtTtlAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtTtlAmt.Location = New System.Drawing.Point(568, 387)
        Me.txtTtlAmt.MaxLength = 10
        Me.txtTtlAmt.Name = "txtTtlAmt"
        Me.txtTtlAmt.Size = New System.Drawing.Size(86, 20)
        Me.txtTtlAmt.TabIndex = 386
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 387
        Me.Label1.Text = "Selection :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(111, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 388
        Me.Label2.Text = "(Container)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(309, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 389
        Me.Label3.Text = "(Invoice)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 390
        Me.Label4.Text = "Sorting :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(278, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(19, 13)
        Me.Label5.TabIndex = 391
        Me.Label5.Text = "(2)"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(478, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(19, 13)
        Me.Label6.TabIndex = 392
        Me.Label6.Text = "(3)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(87, 41)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(19, 13)
        Me.Label7.TabIndex = 393
        Me.Label7.Text = "(1)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label8.Location = New System.Drawing.Point(387, 364)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 13)
        Me.Label8.TabIndex = 394
        Me.Label8.Text = "Total CTN"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label9.Location = New System.Drawing.Point(387, 388)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 26)
        Me.Label9.TabIndex = 395
        Me.Label9.Text = "Grand Total " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Item Amount"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label10.Location = New System.Drawing.Point(577, 339)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(81, 13)
        Me.Label10.TabIndex = 396
        Me.Label10.Text = "Total MOD GW"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label11.Location = New System.Drawing.Point(577, 361)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 13)
        Me.Label11.TabIndex = 397
        Me.Label11.Text = "Total MOD NW"
        '
        'SHM00001_2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(765, 424)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTtlAmt)
        Me.Controls.Add(Me.txtTtlNet)
        Me.Controls.Add(Me.txtTtlCtn)
        Me.Controls.Add(Me.txtTtlGrs)
        Me.Controls.Add(Me.cboUntAmt)
        Me.Controls.Add(Me.cboSort3)
        Me.Controls.Add(Me.cboSort2)
        Me.Controls.Add(Me.cboSort1)
        Me.Controls.Add(Me.cboInv)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtActVol)
        Me.Controls.Add(Me.cboCtr)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.Label76)
        Me.Controls.Add(Me.cmdOK)
        Me.Name = "SHM00001_2"
        Me.Text = "Container / Invoice Details Information (SHM00001_2)"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cboCtr As System.Windows.Forms.ComboBox
    Friend WithEvents txtActVol As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cboInv As System.Windows.Forms.ComboBox
    Friend WithEvents cboSort1 As System.Windows.Forms.ComboBox
    Friend WithEvents cboSort2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboSort3 As System.Windows.Forms.ComboBox
    Friend WithEvents cboUntAmt As System.Windows.Forms.ComboBox
    Friend WithEvents txtTtlGrs As System.Windows.Forms.TextBox
    Friend WithEvents txtTtlCtn As System.Windows.Forms.TextBox
    Friend WithEvents txtTtlNet As System.Windows.Forms.TextBox
    Friend WithEvents txtTtlAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
End Class
