<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MPR00002
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MPR00002))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtFromQuotNo = New System.Windows.Forms.TextBox
        Me.txtToQuotNo = New System.Windows.Forms.TextBox
        Me.cmdShow = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.chnRvsNo = New System.Windows.Forms.RadioButton
        Me.chnRvsYes = New System.Windows.Forms.RadioButton
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 12)
        Me.Label1.TabIndex = 387
        Me.Label1.Text = "Purchase Order No."
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
        'txtFromQuotNo
        '
        Me.txtFromQuotNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFromQuotNo.Location = New System.Drawing.Point(172, 71)
        Me.txtFromQuotNo.MaxLength = 10
        Me.txtFromQuotNo.Name = "txtFromQuotNo"
        Me.txtFromQuotNo.Size = New System.Drawing.Size(193, 20)
        Me.txtFromQuotNo.TabIndex = 0
        '
        'txtToQuotNo
        '
        Me.txtToQuotNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtToQuotNo.Location = New System.Drawing.Point(416, 71)
        Me.txtToQuotNo.MaxLength = 10
        Me.txtToQuotNo.Name = "txtToQuotNo"
        Me.txtToQuotNo.Size = New System.Drawing.Size(193, 20)
        Me.txtToQuotNo.TabIndex = 1
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 166)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 12)
        Me.Label2.TabIndex = 388
        Me.Label2.Text = "Revised"
        '
        'chnRvsNo
        '
        Me.chnRvsNo.AutoSize = True
        Me.chnRvsNo.Checked = True
        Me.chnRvsNo.Location = New System.Drawing.Point(377, 164)
        Me.chnRvsNo.Name = "chnRvsNo"
        Me.chnRvsNo.Size = New System.Drawing.Size(37, 16)
        Me.chnRvsNo.TabIndex = 3
        Me.chnRvsNo.TabStop = True
        Me.chnRvsNo.Text = "No"
        Me.chnRvsNo.UseVisualStyleBackColor = True
        '
        'chnRvsYes
        '
        Me.chnRvsYes.AutoSize = True
        Me.chnRvsYes.Location = New System.Drawing.Point(126, 164)
        Me.chnRvsYes.Name = "chnRvsYes"
        Me.chnRvsYes.Size = New System.Drawing.Size(40, 16)
        Me.chnRvsYes.TabIndex = 2
        Me.chnRvsYes.Text = "Yes"
        Me.chnRvsYes.UseVisualStyleBackColor = True
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
        Me.Label6.Location = New System.Drawing.Point(158, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(356, 22)
        Me.Label6.TabIndex = 391
        Me.Label6.Text = "Print Manufacturing Purchase Order Report"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(124, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 12)
        Me.Label3.TabIndex = 392
        Me.Label3.Text = "From"
        '
        'MPR00002
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 271)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtFromQuotNo)
        Me.Controls.Add(Me.chnRvsNo)
        Me.Controls.Add(Me.txtToQuotNo)
        Me.Controls.Add(Me.chnRvsYes)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmdShow)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MPR00002"
        Me.Text = "MPR00002 - Manufacturing Purchase Order Document (MPR02)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFromQuotNo As System.Windows.Forms.TextBox
    Friend WithEvents txtToQuotNo As System.Windows.Forms.TextBox
    Friend WithEvents chnRvsNo As System.Windows.Forms.RadioButton
    Friend WithEvents chnRvsYes As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
