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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MPR00001))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtMPONoFm = New System.Windows.Forms.TextBox
        Me.txtMPONoTo = New System.Windows.Forms.TextBox
        Me.cmdShow = New System.Windows.Forms.Button
        Me.dtptoTranDat = New System.Windows.Forms.DateTimePicker
        Me.dtpfromTrandat = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblRptName = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(124, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 12)
        Me.Label1.TabIndex = 387
        Me.Label1.Text = "From"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(377, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(18, 12)
        Me.Label4.TabIndex = 388
        Me.Label4.Text = "To"
        '
        'txtMPONoFm
        '
        Me.txtMPONoFm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtMPONoFm.Location = New System.Drawing.Point(172, 71)
        Me.txtMPONoFm.MaxLength = 10
        Me.txtMPONoFm.Name = "txtMPONoFm"
        Me.txtMPONoFm.Size = New System.Drawing.Size(193, 20)
        Me.txtMPONoFm.TabIndex = 0
        '
        'txtMPONoTo
        '
        Me.txtMPONoTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtMPONoTo.Location = New System.Drawing.Point(416, 71)
        Me.txtMPONoTo.MaxLength = 10
        Me.txtMPONoTo.Name = "txtMPONoTo"
        Me.txtMPONoTo.Size = New System.Drawing.Size(193, 20)
        Me.txtMPONoTo.TabIndex = 1
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(259, 244)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(140, 22)
        Me.cmdShow.TabIndex = 4
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'dtptoTranDat
        '
        Me.dtptoTranDat.CustomFormat = ""
        Me.dtptoTranDat.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtptoTranDat.Location = New System.Drawing.Point(416, 162)
        Me.dtptoTranDat.Name = "dtptoTranDat"
        Me.dtptoTranDat.Size = New System.Drawing.Size(91, 22)
        Me.dtptoTranDat.TabIndex = 3
        '
        'dtpfromTrandat
        '
        Me.dtpfromTrandat.CustomFormat = ""
        Me.dtpfromTrandat.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfromTrandat.Location = New System.Drawing.Point(172, 162)
        Me.dtpfromTrandat.Name = "dtpfromTrandat"
        Me.dtpfromTrandat.Size = New System.Drawing.Size(91, 22)
        Me.dtpfromTrandat.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(124, 166)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 12)
        Me.Label2.TabIndex = 387
        Me.Label2.Text = "From"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(377, 166)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(18, 12)
        Me.Label3.TabIndex = 388
        Me.Label3.Text = "To"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 166)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 12)
        Me.Label5.TabIndex = 389
        Me.Label5.Text = "Transaction Date"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 12)
        Me.Label6.TabIndex = 390
        Me.Label6.Text = "Purchase No. (ZS)"
        '
        'lblRptName
        '
        Me.lblRptName.AutoSize = True
        Me.lblRptName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.lblRptName.ForeColor = System.Drawing.Color.Blue
        Me.lblRptName.Location = New System.Drawing.Point(98, 12)
        Me.lblRptName.Name = "lblRptName"
        Me.lblRptName.Size = New System.Drawing.Size(419, 24)
        Me.lblRptName.TabIndex = 391
        Me.lblRptName.Text = "Manufacturing Purchase Order Exception Report"
        '
        'MPR00001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 271)
        Me.Controls.Add(Me.lblRptName)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtptoTranDat)
        Me.Controls.Add(Me.txtMPONoFm)
        Me.Controls.Add(Me.txtMPONoTo)
        Me.Controls.Add(Me.dtpfromTrandat)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmdShow)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MPR00001"
        Me.Text = "MPR00001 - Manufacturing Purchase Order Exception Report (MPR01)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMPONoFm As System.Windows.Forms.TextBox
    Friend WithEvents txtMPONoTo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpfromTrandat As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtptoTranDat As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblRptName As System.Windows.Forms.Label
End Class
