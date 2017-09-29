<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BOR00001
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
        Me.txtVenPOTo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtVenPOFm = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.optShow = New System.Windows.Forms.RadioButton
        Me.optGen = New System.Windows.Forms.RadioButton
        Me.cmdShow = New System.Windows.Forms.Button
        Me.Frame3 = New System.Windows.Forms.GroupBox
        Me.optDtl = New System.Windows.Forms.RadioButton
        Me.optHdr = New System.Windows.Forms.RadioButton
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Frame3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtVenPOTo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtVenPOFm)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(308, 45)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Vendor Purchase Order (BOM)"
        '
        'txtVenPOTo
        '
        Me.txtVenPOTo.Location = New System.Drawing.Point(191, 19)
        Me.txtVenPOTo.Name = "txtVenPOTo"
        Me.txtVenPOTo.Size = New System.Drawing.Size(100, 20)
        Me.txtVenPOTo.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(155, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "To :"
        '
        'txtVenPOFm
        '
        Me.txtVenPOFm.Location = New System.Drawing.Point(47, 19)
        Me.txtVenPOFm.Name = "txtVenPOFm"
        Me.txtVenPOFm.Size = New System.Drawing.Size(100, 20)
        Me.txtVenPOFm.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "From :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.optShow)
        Me.GroupBox2.Controls.Add(Me.optGen)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 65)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(308, 45)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Action"
        '
        'optShow
        '
        Me.optShow.AutoSize = True
        Me.optShow.Checked = True
        Me.optShow.Location = New System.Drawing.Point(175, 19)
        Me.optShow.Name = "optShow"
        Me.optShow.Size = New System.Drawing.Size(87, 17)
        Me.optShow.TabIndex = 0
        Me.optShow.TabStop = True
        Me.optShow.Text = "Show Report"
        Me.optShow.UseVisualStyleBackColor = True
        '
        'optGen
        '
        Me.optGen.AutoSize = True
        Me.optGen.Location = New System.Drawing.Point(50, 19)
        Me.optGen.Name = "optGen"
        Me.optGen.Size = New System.Drawing.Size(69, 17)
        Me.optGen.TabIndex = 0
        Me.optGen.Text = "Generate"
        Me.optGen.UseVisualStyleBackColor = True
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(116, 175)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(110, 38)
        Me.cmdShow.TabIndex = 1
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'Frame3
        '
        Me.Frame3.Controls.Add(Me.optDtl)
        Me.Frame3.Controls.Add(Me.optHdr)
        Me.Frame3.Location = New System.Drawing.Point(12, 119)
        Me.Frame3.Name = "Frame3"
        Me.Frame3.Size = New System.Drawing.Size(308, 45)
        Me.Frame3.TabIndex = 0
        Me.Frame3.TabStop = False
        Me.Frame3.Text = "Report Type"
        '
        'optDtl
        '
        Me.optDtl.AutoSize = True
        Me.optDtl.Location = New System.Drawing.Point(175, 19)
        Me.optDtl.Name = "optDtl"
        Me.optDtl.Size = New System.Drawing.Size(52, 17)
        Me.optDtl.TabIndex = 0
        Me.optDtl.Text = "Detail"
        Me.optDtl.UseVisualStyleBackColor = True
        '
        'optHdr
        '
        Me.optHdr.AutoSize = True
        Me.optHdr.Checked = True
        Me.optHdr.Location = New System.Drawing.Point(50, 19)
        Me.optHdr.Name = "optHdr"
        Me.optHdr.Size = New System.Drawing.Size(68, 17)
        Me.optHdr.TabIndex = 0
        Me.optHdr.TabStop = True
        Me.optHdr.Text = "Summary"
        Me.optHdr.UseVisualStyleBackColor = True
        '
        'BOR00001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(332, 226)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.Frame3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(340, 260)
        Me.MinimumSize = New System.Drawing.Size(340, 260)
        Me.Name = "BOR00001"
        Me.Text = "BOR00001 - Vendor Purchase Report (BOM)"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Frame3.ResumeLayout(False)
        Me.Frame3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtVenPOTo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtVenPOFm As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents optShow As System.Windows.Forms.RadioButton
    Friend WithEvents optGen As System.Windows.Forms.RadioButton
    Friend WithEvents Frame3 As System.Windows.Forms.GroupBox
    Friend WithEvents optDtl As System.Windows.Forms.RadioButton
    Friend WithEvents optHdr As System.Windows.Forms.RadioButton
End Class
