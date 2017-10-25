<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class INR00004
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(INR00004))
        Me.cboSCTo = New System.Windows.Forms.ComboBox
        Me.cboVenTo = New System.Windows.Forms.ComboBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.cboSCFm = New System.Windows.Forms.ComboBox
        Me.cboVenFm = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txtYear = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmdShow = New System.Windows.Forms.Button
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.cboCocde = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboSCTo
        '
        Me.cboSCTo.FormattingEnabled = True
        Me.cboSCTo.Location = New System.Drawing.Point(402, 100)
        Me.cboSCTo.Name = "cboSCTo"
        Me.cboSCTo.Size = New System.Drawing.Size(176, 20)
        Me.cboSCTo.TabIndex = 6
        '
        'cboVenTo
        '
        Me.cboVenTo.FormattingEnabled = True
        Me.cboVenTo.Location = New System.Drawing.Point(402, 72)
        Me.cboVenTo.Name = "cboVenTo"
        Me.cboVenTo.Size = New System.Drawing.Size(176, 20)
        Me.cboVenTo.TabIndex = 4
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(375, 103)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(18, 12)
        Me.Label32.TabIndex = 37
        Me.Label32.Text = "To"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(375, 76)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(18, 12)
        Me.Label31.TabIndex = 36
        Me.Label31.Text = "To"
        '
        'cboSCFm
        '
        Me.cboSCFm.FormattingEnabled = True
        Me.cboSCFm.Location = New System.Drawing.Point(188, 100)
        Me.cboSCFm.Name = "cboSCFm"
        Me.cboSCFm.Size = New System.Drawing.Size(176, 20)
        Me.cboSCFm.TabIndex = 5
        '
        'cboVenFm
        '
        Me.cboVenFm.FormattingEnabled = True
        Me.cboVenFm.Location = New System.Drawing.Point(188, 72)
        Me.cboVenFm.Name = "cboVenFm"
        Me.cboVenFm.Size = New System.Drawing.Size(176, 20)
        Me.cboVenFm.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(188, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(248, 24)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Production Capacity in CBM "
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(146, 104)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(30, 12)
        Me.Label21.TabIndex = 15
        Me.Label21.Text = "From"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(146, 77)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(30, 12)
        Me.Label20.TabIndex = 14
        Me.Label20.Text = "From"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 12)
        Me.Label4.TabIndex = 37
        Me.Label4.Text = "Company Code"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.cboSCTo)
        Me.GroupBox1.Controls.Add(Me.cboVenTo)
        Me.GroupBox1.Controls.Add(Me.Label32)
        Me.GroupBox1.Controls.Add(Me.Label31)
        Me.GroupBox1.Controls.Add(Me.cboSCFm)
        Me.GroupBox1.Controls.Add(Me.cboVenFm)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 68)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(595, 144)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Selection Criteria"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtYear)
        Me.GroupBox4.Controls.Add(Me.Label19)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 16)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(572, 44)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        '
        'txtYear
        '
        Me.txtYear.Enabled = False
        Me.txtYear.Location = New System.Drawing.Point(144, 15)
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(119, 22)
        Me.txtYear.TabIndex = 2
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(4, 18)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(126, 12)
        Me.Label19.TabIndex = 54
        Me.Label19.Text = "Production Schedule Year"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 104)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 12)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Sub Code"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 77)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 12)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Vendor No."
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(224, 239)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(140, 22)
        Me.cmdShow.TabIndex = 7
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'txtCoNam
        '
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.Location = New System.Drawing.Point(280, 45)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.Size = New System.Drawing.Size(302, 22)
        Me.txtCoNam.TabIndex = 1
        '
        'cboCocde
        '
        Me.cboCocde.FormattingEnabled = True
        Me.cboCocde.Location = New System.Drawing.Point(99, 44)
        Me.cboCocde.Name = "cboCocde"
        Me.cboCocde.Size = New System.Drawing.Size(70, 20)
        Me.cboCocde.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(189, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 12)
        Me.Label5.TabIndex = 38
        Me.Label5.Text = "Company Name"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(17, 215)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(268, 13)
        Me.Label8.TabIndex = 40
        Me.Label8.Text = "* Just for Internal && Joint Venture Vendor Only"
        '
        'INR00004
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 285)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.cboCocde)
        Me.Controls.Add(Me.Label5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "INR00004"
        Me.Text = "INR00004 - Production Capacity in CBM  (INR04)"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboSCTo As System.Windows.Forms.ComboBox
    Friend WithEvents cboVenTo As System.Windows.Forms.ComboBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents cboSCFm As System.Windows.Forms.ComboBox
    Friend WithEvents cboVenFm As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents txtCoNam As System.Windows.Forms.TextBox
    Public WithEvents cboCocde As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtYear As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
