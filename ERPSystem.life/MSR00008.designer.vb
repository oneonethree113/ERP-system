<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MSR00008
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MSR00008))
        Me.cboVnTo = New System.Windows.Forms.ComboBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.cboVnFm = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtYear = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cboMonth = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtInvnoTo = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtInvnoFrom = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.cboCuTo = New System.Windows.Forms.ComboBox
        Me.cboCuFm = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmdShow = New System.Windows.Forms.Button
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.cboCocde = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboVnTo
        '
        Me.cboVnTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboVnTo.FormattingEnabled = True
        Me.cboVnTo.Location = New System.Drawing.Point(398, 25)
        Me.cboVnTo.Name = "cboVnTo"
        Me.cboVnTo.Size = New System.Drawing.Size(174, 21)
        Me.cboVnTo.TabIndex = 3
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(369, 57)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(18, 12)
        Me.Label34.TabIndex = 39
        Me.Label34.Text = "To"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(369, 30)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(18, 12)
        Me.Label31.TabIndex = 36
        Me.Label31.Text = "To"
        '
        'cboVnFm
        '
        Me.cboVnFm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboVnFm.FormattingEnabled = True
        Me.cboVnFm.Location = New System.Drawing.Point(182, 25)
        Me.cboVnFm.Name = "cboVnFm"
        Me.cboVnFm.Size = New System.Drawing.Size(175, 21)
        Me.cboVnFm.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(124, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(335, 24)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Monthly Statement for Sample Charges"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(141, 57)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(30, 12)
        Me.Label23.TabIndex = 17
        Me.Label23.Text = "From"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(141, 30)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(30, 12)
        Me.Label20.TabIndex = 14
        Me.Label20.Text = "From"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(27, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 12)
        Me.Label4.TabIndex = 37
        Me.Label4.Text = "Company Code"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtInvnoTo)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtInvnoFrom)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.cboCuTo)
        Me.GroupBox1.Controls.Add(Me.cboCuFm)
        Me.GroupBox1.Controls.Add(Me.cboVnTo)
        Me.GroupBox1.Controls.Add(Me.Label34)
        Me.GroupBox1.Controls.Add(Me.Label31)
        Me.GroupBox1.Controls.Add(Me.cboVnFm)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(19, 74)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(599, 162)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " Input Criteria "
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtYear)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Location = New System.Drawing.Point(353, 108)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(231, 44)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        '
        'txtYear
        '
        Me.txtYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtYear.Location = New System.Drawing.Point(103, 16)
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(79, 20)
        Me.txtYear.TabIndex = 9
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(43, 18)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(27, 12)
        Me.Label12.TabIndex = 60
        Me.Label12.Text = "Year"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboMonth)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Location = New System.Drawing.Point(33, 108)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(314, 45)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        '
        'cboMonth
        '
        Me.cboMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Location = New System.Drawing.Point(77, 15)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(176, 21)
        Me.cboMonth.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(35, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 12)
        Me.Label7.TabIndex = 61
        Me.Label7.Text = "Month"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(29, 85)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 12)
        Me.Label8.TabIndex = 57
        Me.Label8.Text = "Sample Invoice "
        '
        'txtInvnoTo
        '
        Me.txtInvnoTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvnoTo.Location = New System.Drawing.Point(398, 82)
        Me.txtInvnoTo.Name = "txtInvnoTo"
        Me.txtInvnoTo.Size = New System.Drawing.Size(174, 20)
        Me.txtInvnoTo.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(369, 85)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(18, 12)
        Me.Label10.TabIndex = 55
        Me.Label10.Text = "To"
        '
        'txtInvnoFrom
        '
        Me.txtInvnoFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvnoFrom.Location = New System.Drawing.Point(182, 82)
        Me.txtInvnoFrom.Name = "txtInvnoFrom"
        Me.txtInvnoFrom.Size = New System.Drawing.Size(175, 20)
        Me.txtInvnoFrom.TabIndex = 6
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(141, 85)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(30, 12)
        Me.Label11.TabIndex = 53
        Me.Label11.Text = "From"
        '
        'cboCuTo
        '
        Me.cboCuTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCuTo.FormattingEnabled = True
        Me.cboCuTo.Location = New System.Drawing.Point(398, 53)
        Me.cboCuTo.Name = "cboCuTo"
        Me.cboCuTo.Size = New System.Drawing.Size(174, 21)
        Me.cboCuTo.TabIndex = 5
        '
        'cboCuFm
        '
        Me.cboCuFm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCuFm.FormattingEnabled = True
        Me.cboCuFm.Location = New System.Drawing.Point(182, 53)
        Me.cboCuFm.Name = "cboCuFm"
        Me.cboCuFm.Size = New System.Drawing.Size(175, 21)
        Me.cboCuFm.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(29, 56)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 12)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Customer No."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(29, 30)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 12)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Vendor No."
        '
        'cmdShow
        '
        Me.cmdShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShow.Location = New System.Drawing.Point(254, 254)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(140, 22)
        Me.cmdShow.TabIndex = 10
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'txtCoNam
        '
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCoNam.Location = New System.Drawing.Point(294, 51)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.Size = New System.Drawing.Size(302, 20)
        Me.txtCoNam.TabIndex = 1
        '
        'cboCocde
        '
        Me.cboCocde.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCocde.FormattingEnabled = True
        Me.cboCocde.Location = New System.Drawing.Point(113, 50)
        Me.cboCocde.Name = "cboCocde"
        Me.cboCocde.Size = New System.Drawing.Size(70, 21)
        Me.cboCocde.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(203, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 12)
        Me.Label5.TabIndex = 38
        Me.Label5.Text = "Company Name"
        '
        'MSR00008
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 288)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.cboCocde)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmdShow)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MSR00008"
        Me.Text = "MSR00008 - Monthly Statement for Sample Charges (MSR08)"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboVnTo As System.Windows.Forms.ComboBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents cboVnFm As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents txtCoNam As System.Windows.Forms.TextBox
    Public WithEvents cboCocde As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents cboCuTo As System.Windows.Forms.ComboBox
    Friend WithEvents cboCuFm As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtInvnoTo As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtInvnoFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtYear As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboMonth As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
