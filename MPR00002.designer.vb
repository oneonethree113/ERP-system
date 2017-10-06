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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtFromQuotNo = New System.Windows.Forms.TextBox
        Me.txtToQuotNo = New System.Windows.Forms.TextBox
        Me.cmdShow = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.chnRvsNo = New System.Windows.Forms.RadioButton
        Me.chnRvsYes = New System.Windows.Forms.RadioButton
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtFromQuotNo)
        Me.GroupBox1.Controls.Add(Me.txtToQuotNo)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox1.Location = New System.Drawing.Point(6, 19)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(508, 50)
        Me.GroupBox1.TabIndex = 26
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(24, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 13)
        Me.Label1.TabIndex = 387
        Me.Label1.Text = "Purchase Order No. From :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label4.Location = New System.Drawing.Point(325, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 13)
        Me.Label4.TabIndex = 388
        Me.Label4.Text = "To:"
        '
        'txtFromQuotNo
        '
        Me.txtFromQuotNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFromQuotNo.Location = New System.Drawing.Point(170, 16)
        Me.txtFromQuotNo.MaxLength = 10
        Me.txtFromQuotNo.Name = "txtFromQuotNo"
        Me.txtFromQuotNo.Size = New System.Drawing.Size(126, 20)
        Me.txtFromQuotNo.TabIndex = 0
        '
        'txtToQuotNo
        '
        Me.txtToQuotNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtToQuotNo.Location = New System.Drawing.Point(354, 16)
        Me.txtToQuotNo.MaxLength = 10
        Me.txtToQuotNo.Name = "txtToQuotNo"
        Me.txtToQuotNo.Size = New System.Drawing.Size(126, 20)
        Me.txtToQuotNo.TabIndex = 1
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(227, 174)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(117, 27)
        Me.cmdShow.TabIndex = 4
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.chnRvsNo)
        Me.GroupBox2.Controls.Add(Me.chnRvsYes)
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox2.Location = New System.Drawing.Point(6, 75)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(508, 41)
        Me.GroupBox2.TabIndex = 27
        Me.GroupBox2.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(24, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 388
        Me.Label2.Text = "Revised"
        '
        'chnRvsNo
        '
        Me.chnRvsNo.AutoSize = True
        Me.chnRvsNo.Checked = True
        Me.chnRvsNo.Location = New System.Drawing.Point(354, 15)
        Me.chnRvsNo.Name = "chnRvsNo"
        Me.chnRvsNo.Size = New System.Drawing.Size(39, 17)
        Me.chnRvsNo.TabIndex = 3
        Me.chnRvsNo.TabStop = True
        Me.chnRvsNo.Text = "No"
        Me.chnRvsNo.UseVisualStyleBackColor = True
        '
        'chnRvsYes
        '
        Me.chnRvsYes.AutoSize = True
        Me.chnRvsYes.Location = New System.Drawing.Point(176, 15)
        Me.chnRvsYes.Name = "chnRvsYes"
        Me.chnRvsYes.Size = New System.Drawing.Size(43, 17)
        Me.chnRvsYes.TabIndex = 2
        Me.chnRvsYes.Text = "Yes"
        Me.chnRvsYes.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.GroupBox1)
        Me.GroupBox3.Controls.Add(Me.GroupBox2)
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox3.Location = New System.Drawing.Point(12, 43)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(520, 125)
        Me.GroupBox3.TabIndex = 28
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Selection Criteria :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label3.Location = New System.Drawing.Point(15, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 389
        Me.Label3.Text = "MPR00002"
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
        Me.Label6.Location = New System.Drawing.Point(126, 1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(356, 22)
        Me.Label6.TabIndex = 391
        Me.Label6.Text = "Print Manufacturing Purchase Order Report"
        '
        'MPR00002
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(568, 213)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.cmdShow)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MPR00002"
        Me.Text = "MPR00002 - Manufacturing Purchase Order Document"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFromQuotNo As System.Windows.Forms.TextBox
    Friend WithEvents txtToQuotNo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chnRvsNo As System.Windows.Forms.RadioButton
    Friend WithEvents chnRvsYes As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
