<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IMR00032
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
        Me.txtDateRange = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtETDDateFm = New System.Windows.Forms.MaskedTextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtETDDateTo = New System.Windows.Forms.MaskedTextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboCustomer = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.optPrintAmtYes = New System.Windows.Forms.RadioButton
        Me.optPrintAmtNo = New System.Windows.Forms.RadioButton
        Me.cmdShow = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(500, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Shipment and Penalty Report"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtDateRange
        '
        Me.txtDateRange.AutoSize = True
        Me.txtDateRange.Location = New System.Drawing.Point(13, 44)
        Me.txtDateRange.Name = "txtDateRange"
        Me.txtDateRange.Size = New System.Drawing.Size(71, 13)
        Me.txtDateRange.TabIndex = 2
        Me.txtDateRange.Text = "Date Range :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(100, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "From"
        '
        'txtETDDateFm
        '
        Me.txtETDDateFm.Location = New System.Drawing.Point(136, 41)
        Me.txtETDDateFm.Mask = "00/00/0000"
        Me.txtETDDateFm.Name = "txtETDDateFm"
        Me.txtETDDateFm.Size = New System.Drawing.Size(77, 20)
        Me.txtETDDateFm.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(215, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "(MM/DD/YYYY)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(312, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(20, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "To"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(417, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "(MM/DD/YYYY)"
        '
        'txtETDDateTo
        '
        Me.txtETDDateTo.Location = New System.Drawing.Point(338, 41)
        Me.txtETDDateTo.Mask = "00/00/0000"
        Me.txtETDDateTo.Name = "txtETDDateTo"
        Me.txtETDDateTo.Size = New System.Drawing.Size(77, 20)
        Me.txtETDDateTo.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 73)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Report Type :"
        '
        'cboCustomer
        '
        Me.cboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCustomer.FormattingEnabled = True
        Me.cboCustomer.Location = New System.Drawing.Point(103, 70)
        Me.cboCustomer.Name = "cboCustomer"
        Me.cboCustomer.Size = New System.Drawing.Size(399, 21)
        Me.cboCustomer.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 102)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(93, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Print Factory Price"
        '
        'optPrintAmtYes
        '
        Me.optPrintAmtYes.AutoSize = True
        Me.optPrintAmtYes.Checked = True
        Me.optPrintAmtYes.Location = New System.Drawing.Point(136, 100)
        Me.optPrintAmtYes.Name = "optPrintAmtYes"
        Me.optPrintAmtYes.Size = New System.Drawing.Size(43, 17)
        Me.optPrintAmtYes.TabIndex = 12
        Me.optPrintAmtYes.TabStop = True
        Me.optPrintAmtYes.Text = "Yes"
        Me.optPrintAmtYes.UseVisualStyleBackColor = True
        '
        'optPrintAmtNo
        '
        Me.optPrintAmtNo.AutoSize = True
        Me.optPrintAmtNo.Location = New System.Drawing.Point(218, 100)
        Me.optPrintAmtNo.Name = "optPrintAmtNo"
        Me.optPrintAmtNo.Size = New System.Drawing.Size(39, 17)
        Me.optPrintAmtNo.TabIndex = 13
        Me.optPrintAmtNo.Text = "No"
        Me.optPrintAmtNo.UseVisualStyleBackColor = True
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(215, 131)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(93, 26)
        Me.cmdShow.TabIndex = 14
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'IMR00032
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(525, 172)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.optPrintAmtNo)
        Me.Controls.Add(Me.optPrintAmtYes)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboCustomer)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtETDDateTo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtETDDateFm)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtDateRange)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "IMR00032"
        Me.Text = "IMR00032 - Late Shipment Report"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDateRange As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtETDDateFm As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtETDDateTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents optPrintAmtYes As System.Windows.Forms.RadioButton
    Friend WithEvents optPrintAmtNo As System.Windows.Forms.RadioButton
    Friend WithEvents cmdShow As System.Windows.Forms.Button
End Class
