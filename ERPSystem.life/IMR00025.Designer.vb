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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IMR00025))
        Me.txtMOQSCFm = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtSCFm = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtItmTo = New System.Windows.Forms.TextBox
        Me.txtItmFm = New System.Windows.Forms.TextBox
        Me.optBOTH = New System.Windows.Forms.RadioButton
        Me.optEXT = New System.Windows.Forms.RadioButton
        Me.optINT = New System.Windows.Forms.RadioButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdShow = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'txtMOQSCFm
        '
        Me.txtMOQSCFm.Location = New System.Drawing.Point(184, 50)
        Me.txtMOQSCFm.Name = "txtMOQSCFm"
        Me.txtMOQSCFm.Size = New System.Drawing.Size(389, 22)
        Me.txtMOQSCFm.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "MOQ SC No."
        '
        'txtSCFm
        '
        Me.txtSCFm.Location = New System.Drawing.Point(184, 100)
        Me.txtSCFm.Name = "txtSCFm"
        Me.txtSCFm.Size = New System.Drawing.Size(389, 22)
        Me.txtSCFm.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 12)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Sales Confirmation No."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 151)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 12)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Item No."
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(135, 151)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(30, 12)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "From"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(379, 151)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(21, 12)
        Me.Label14.TabIndex = 7
        Me.Label14.Text = "To "
        '
        'txtItmTo
        '
        Me.txtItmTo.Location = New System.Drawing.Point(411, 148)
        Me.txtItmTo.Name = "txtItmTo"
        Me.txtItmTo.Size = New System.Drawing.Size(162, 22)
        Me.txtItmTo.TabIndex = 4
        '
        'txtItmFm
        '
        Me.txtItmFm.Location = New System.Drawing.Point(184, 148)
        Me.txtItmFm.Name = "txtItmFm"
        Me.txtItmFm.Size = New System.Drawing.Size(162, 22)
        Me.txtItmFm.TabIndex = 3
        '
        'optBOTH
        '
        Me.optBOTH.AutoSize = True
        Me.optBOTH.Location = New System.Drawing.Point(459, 198)
        Me.optBOTH.Name = "optBOTH"
        Me.optBOTH.Size = New System.Drawing.Size(46, 16)
        Me.optBOTH.TabIndex = 7
        Me.optBOTH.TabStop = True
        Me.optBOTH.Text = "Both"
        Me.optBOTH.UseVisualStyleBackColor = True
        '
        'optEXT
        '
        Me.optEXT.AutoSize = True
        Me.optEXT.Location = New System.Drawing.Point(363, 198)
        Me.optEXT.Name = "optEXT"
        Me.optEXT.Size = New System.Drawing.Size(62, 16)
        Me.optEXT.TabIndex = 6
        Me.optEXT.TabStop = True
        Me.optEXT.Text = "External"
        Me.optEXT.UseVisualStyleBackColor = True
        '
        'optINT
        '
        Me.optINT.AutoSize = True
        Me.optINT.Checked = True
        Me.optINT.Location = New System.Drawing.Point(184, 198)
        Me.optINT.Name = "optINT"
        Me.optINT.Size = New System.Drawing.Size(136, 16)
        Me.optINT.TabIndex = 5
        Me.optINT.TabStop = True
        Me.optINT.Text = "Internal && Joint Venture"
        Me.optINT.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 200)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 12)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Vendor Type"
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(259, 275)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(116, 40)
        Me.cmdShow.TabIndex = 8
        Me.cmdShow.Text = "E&xport to Excel"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(62, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(511, 23)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Attachment Update History"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'IMR00025
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(634, 412)
        Me.Controls.Add(Me.optBOTH)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.optEXT)
        Me.Controls.Add(Me.txtSCFm)
        Me.Controls.Add(Me.optINT)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtMOQSCFm)
        Me.Controls.Add(Me.txtItmTo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtItmFm)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmdShow)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "IMR00025"
        Me.Text = "IMR00025 - MOQ SC Records (IMR25)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMOQSCFm As System.Windows.Forms.TextBox
    Friend WithEvents txtSCFm As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtItmTo As System.Windows.Forms.TextBox
    Friend WithEvents txtItmFm As System.Windows.Forms.TextBox
    Friend WithEvents optBOTH As System.Windows.Forms.RadioButton
    Friend WithEvents optEXT As System.Windows.Forms.RadioButton
    Friend WithEvents optINT As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
