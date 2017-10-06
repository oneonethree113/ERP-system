<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MPR00001
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtMPONoFm = New System.Windows.Forms.TextBox
        Me.txtMPONoTo = New System.Windows.Forms.TextBox
        Me.cmdShow = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dtptoTranDat = New System.Windows.Forms.DateTimePicker
        Me.dtpfromTrandat = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtMPONoFm)
        Me.GroupBox1.Controls.Add(Me.txtMPONoTo)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(391, 56)
        Me.GroupBox1.TabIndex = 26
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Purchase No. (ZS)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(24, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 387
        Me.Label1.Text = "From:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label4.Location = New System.Drawing.Point(199, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 13)
        Me.Label4.TabIndex = 388
        Me.Label4.Text = "To:"
        '
        'txtMPONoFm
        '
        Me.txtMPONoFm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtMPONoFm.Location = New System.Drawing.Point(70, 16)
        Me.txtMPONoFm.MaxLength = 10
        Me.txtMPONoFm.Name = "txtMPONoFm"
        Me.txtMPONoFm.Size = New System.Drawing.Size(114, 20)
        Me.txtMPONoFm.TabIndex = 0
        '
        'txtMPONoTo
        '
        Me.txtMPONoTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtMPONoTo.Location = New System.Drawing.Point(228, 16)
        Me.txtMPONoTo.MaxLength = 10
        Me.txtMPONoTo.Name = "txtMPONoTo"
        Me.txtMPONoTo.Size = New System.Drawing.Size(114, 20)
        Me.txtMPONoTo.TabIndex = 1
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(151, 145)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(117, 27)
        Me.cmdShow.TabIndex = 4
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dtptoTranDat)
        Me.GroupBox2.Controls.Add(Me.dtpfromTrandat)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox2.Location = New System.Drawing.Point(12, 74)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(391, 56)
        Me.GroupBox2.TabIndex = 27
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Transaction Date"
        '
        'dtptoTranDat
        '
        Me.dtptoTranDat.CustomFormat = ""
        Me.dtptoTranDat.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtptoTranDat.Location = New System.Drawing.Point(229, 12)
        Me.dtptoTranDat.Name = "dtptoTranDat"
        Me.dtptoTranDat.Size = New System.Drawing.Size(91, 20)
        Me.dtptoTranDat.TabIndex = 3
        '
        'dtpfromTrandat
        '
        Me.dtpfromTrandat.CustomFormat = ""
        Me.dtpfromTrandat.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfromTrandat.Location = New System.Drawing.Point(70, 12)
        Me.dtpfromTrandat.Name = "dtpfromTrandat"
        Me.dtpfromTrandat.Size = New System.Drawing.Size(91, 20)
        Me.dtpfromTrandat.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(24, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 387
        Me.Label2.Text = "From:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label3.Location = New System.Drawing.Point(199, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 13)
        Me.Label3.TabIndex = 388
        Me.Label3.Text = "To:"
        '
        'MPR00001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(423, 183)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdShow)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MPR00001"
        Me.Text = "MPR00001 - Manufacturing Purchase Order Exception Report"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMPONoFm As System.Windows.Forms.TextBox
    Friend WithEvents txtMPONoTo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpfromTrandat As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtptoTranDat As System.Windows.Forms.DateTimePicker
End Class
