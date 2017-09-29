<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PGM00007
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PGM00007))
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.cmdShow = New System.Windows.Forms.Button
        Me.lblRptName = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.cmd_S_PKGNo = New System.Windows.Forms.Button
        Me.Combo1 = New System.Windows.Forms.ComboBox
        Me.txt_S_PKGNo = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.Color.White
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.Location = New System.Drawing.Point(307, 77)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.Size = New System.Drawing.Size(302, 22)
        Me.txtCoNam.TabIndex = 39
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(217, 81)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(84, 12)
        Me.Label35.TabIndex = 41
        Me.Label35.Text = "Company Name:"
        '
        'cboCoCde
        '
        Me.cboCoCde.BackColor = System.Drawing.Color.White
        Me.cboCoCde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(115, 76)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(93, 20)
        Me.cboCoCde.TabIndex = 37
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(259, 212)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(116, 37)
        Me.cmdShow.TabIndex = 43
        Me.cmdShow.Text = "Print Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'lblRptName
        '
        Me.lblRptName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRptName.ForeColor = System.Drawing.Color.Blue
        Me.lblRptName.Location = New System.Drawing.Point(60, 30)
        Me.lblRptName.Name = "lblRptName"
        Me.lblRptName.Size = New System.Drawing.Size(509, 29)
        Me.lblRptName.TabIndex = 38
        Me.lblRptName.Text = "Packaging Document Printing Report"
        Me.lblRptName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.ForeColor = System.Drawing.Color.Blue
        Me.Label34.Location = New System.Drawing.Point(24, 80)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(79, 12)
        Me.Label34.TabIndex = 40
        Me.Label34.Text = "Company Code"
        '
        'cmd_S_PKGNo
        '
        Me.cmd_S_PKGNo.Location = New System.Drawing.Point(164, 119)
        Me.cmd_S_PKGNo.Name = "cmd_S_PKGNo"
        Me.cmd_S_PKGNo.Size = New System.Drawing.Size(53, 21)
        Me.cmd_S_PKGNo.TabIndex = 44
        Me.cmd_S_PKGNo.Text = ">>"
        Me.cmd_S_PKGNo.UseVisualStyleBackColor = True
        '
        'Combo1
        '
        Me.Combo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo1.FormattingEnabled = True
        Me.Combo1.Location = New System.Drawing.Point(164, 172)
        Me.Combo1.Name = "Combo1"
        Me.Combo1.Size = New System.Drawing.Size(445, 20)
        Me.Combo1.TabIndex = 25
        '
        'txt_S_PKGNo
        '
        Me.txt_S_PKGNo.Location = New System.Drawing.Point(234, 119)
        Me.txt_S_PKGNo.Name = "txt_S_PKGNo"
        Me.txt_S_PKGNo.Size = New System.Drawing.Size(375, 22)
        Me.txt_S_PKGNo.TabIndex = 23
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(24, 123)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(123, 12)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Packaging Order No. List"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(26, 175)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 12)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Report Format :"
        '
        'PGM00007
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 275)
        Me.Controls.Add(Me.cmd_S_PKGNo)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.Combo1)
        Me.Controls.Add(Me.txt_S_PKGNo)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.lblRptName)
        Me.Controls.Add(Me.Label34)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(640, 300)
        Me.MinimumSize = New System.Drawing.Size(640, 300)
        Me.Name = "PGM00007"
        Me.Text = "PGM00007 - Packaging Document Printing Report (PGM07)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents lblRptName As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents cmd_S_PKGNo As System.Windows.Forms.Button
    Friend WithEvents Combo1 As System.Windows.Forms.ComboBox
    Friend WithEvents txt_S_PKGNo As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
