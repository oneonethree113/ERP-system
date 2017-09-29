<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IMR00025
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
        Me.txtMOQSCFm = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtSCFm = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.grpSCNo = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtItmTo = New System.Windows.Forms.TextBox
        Me.txtItmFm = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.optINT = New System.Windows.Forms.RadioButton
        Me.optEXT = New System.Windows.Forms.RadioButton
        Me.optBOTH = New System.Windows.Forms.RadioButton
        Me.cmdShow = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.grpSCNo.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtMOQSCFm)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(500, 46)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "MOQ SC No."
        '
        'txtMOQSCFm
        '
        Me.txtMOQSCFm.Location = New System.Drawing.Point(168, 17)
        Me.txtMOQSCFm.Name = "txtMOQSCFm"
        Me.txtMOQSCFm.Size = New System.Drawing.Size(124, 20)
        Me.txtMOQSCFm.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtSCFm)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 64)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(500, 46)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'txtSCFm
        '
        Me.txtSCFm.Location = New System.Drawing.Point(168, 17)
        Me.txtSCFm.Name = "txtSCFm"
        Me.txtSCFm.Size = New System.Drawing.Size(124, 20)
        Me.txtSCFm.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Sales Confirmation No."
        '
        'grpSCNo
        '
        Me.grpSCNo.Controls.Add(Me.Label4)
        Me.grpSCNo.Controls.Add(Me.Label15)
        Me.grpSCNo.Controls.Add(Me.Label14)
        Me.grpSCNo.Controls.Add(Me.txtItmTo)
        Me.grpSCNo.Controls.Add(Me.txtItmFm)
        Me.grpSCNo.Location = New System.Drawing.Point(12, 116)
        Me.grpSCNo.Name = "grpSCNo"
        Me.grpSCNo.Size = New System.Drawing.Size(500, 46)
        Me.grpSCNo.TabIndex = 17
        Me.grpSCNo.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Item No."
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(119, 19)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(36, 13)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "From :"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(319, 19)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(26, 13)
        Me.Label14.TabIndex = 7
        Me.Label14.Text = "To :"
        '
        'txtItmTo
        '
        Me.txtItmTo.Location = New System.Drawing.Point(351, 16)
        Me.txtItmTo.Name = "txtItmTo"
        Me.txtItmTo.Size = New System.Drawing.Size(124, 20)
        Me.txtItmTo.TabIndex = 8
        '
        'txtItmFm
        '
        Me.txtItmFm.Location = New System.Drawing.Point(168, 16)
        Me.txtItmFm.Name = "txtItmFm"
        Me.txtItmFm.Size = New System.Drawing.Size(124, 20)
        Me.txtItmFm.TabIndex = 6
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.optBOTH)
        Me.GroupBox3.Controls.Add(Me.optEXT)
        Me.GroupBox3.Controls.Add(Me.optINT)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 168)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(500, 46)
        Me.GroupBox3.TabIndex = 18
        Me.GroupBox3.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Vendor Type"
        '
        'optINT
        '
        Me.optINT.AutoSize = True
        Me.optINT.Checked = True
        Me.optINT.Location = New System.Drawing.Point(168, 18)
        Me.optINT.Name = "optINT"
        Me.optINT.Size = New System.Drawing.Size(134, 17)
        Me.optINT.TabIndex = 2
        Me.optINT.TabStop = True
        Me.optINT.Text = "Internal && Joint Venture"
        Me.optINT.UseVisualStyleBackColor = True
        '
        'optEXT
        '
        Me.optEXT.AutoSize = True
        Me.optEXT.Location = New System.Drawing.Point(331, 18)
        Me.optEXT.Name = "optEXT"
        Me.optEXT.Size = New System.Drawing.Size(63, 17)
        Me.optEXT.TabIndex = 3
        Me.optEXT.TabStop = True
        Me.optEXT.Text = "External"
        Me.optEXT.UseVisualStyleBackColor = True
        '
        'optBOTH
        '
        Me.optBOTH.AutoSize = True
        Me.optBOTH.Location = New System.Drawing.Point(428, 18)
        Me.optBOTH.Name = "optBOTH"
        Me.optBOTH.Size = New System.Drawing.Size(47, 17)
        Me.optBOTH.TabIndex = 4
        Me.optBOTH.TabStop = True
        Me.optBOTH.Text = "Both"
        Me.optBOTH.UseVisualStyleBackColor = True
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(208, 224)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(111, 32)
        Me.cmdShow.TabIndex = 19
        Me.cmdShow.Text = "E&xport to Excel"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'IMR00025
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(525, 269)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.grpSCNo)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "IMR00025"
        Me.Text = "IMR00025 - MOQ SC Records"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.grpSCNo.ResumeLayout(False)
        Me.grpSCNo.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMOQSCFm As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSCFm As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grpSCNo As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtItmTo As System.Windows.Forms.TextBox
    Friend WithEvents txtItmFm As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents optBOTH As System.Windows.Forms.RadioButton
    Friend WithEvents optEXT As System.Windows.Forms.RadioButton
    Friend WithEvents optINT As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdShow As System.Windows.Forms.Button
End Class
