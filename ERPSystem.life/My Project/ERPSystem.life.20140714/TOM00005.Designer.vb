<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TOM00005
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
        Me.txtFromQuotNo = New System.Windows.Forms.TextBox
        Me.Panel9 = New System.Windows.Forms.Panel
        Me.Label12 = New System.Windows.Forms.Label
        Me.lblRptName = New System.Windows.Forms.Label
        Me.Panel10 = New System.Windows.Forms.Panel
        Me.Combo1 = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.cmdShow = New System.Windows.Forms.Button
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.gb1 = New System.Windows.Forms.GroupBox
        Me.gb4 = New System.Windows.Forms.GroupBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.saveto_folder = New System.Windows.Forms.TextBox
        Me.Panel9.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.gb1.SuspendLayout()
        Me.gb4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtFromQuotNo
        '
        Me.txtFromQuotNo.Location = New System.Drawing.Point(169, 5)
        Me.txtFromQuotNo.Name = "txtFromQuotNo"
        Me.txtFromQuotNo.Size = New System.Drawing.Size(124, 20)
        Me.txtFromQuotNo.TabIndex = 23
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.txtFromQuotNo)
        Me.Panel9.Controls.Add(Me.Label12)
        Me.Panel9.Location = New System.Drawing.Point(6, 16)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(484, 29)
        Me.Panel9.TabIndex = 8
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(13, 8)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Tentative No."
        '
        'lblRptName
        '
        Me.lblRptName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRptName.ForeColor = System.Drawing.Color.Blue
        Me.lblRptName.Location = New System.Drawing.Point(20, 10)
        Me.lblRptName.Name = "lblRptName"
        Me.lblRptName.Size = New System.Drawing.Size(509, 23)
        Me.lblRptName.TabIndex = 31
        Me.lblRptName.Text = "Export Tentative to Excel"
        Me.lblRptName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.Combo1)
        Me.Panel10.Controls.Add(Me.Label13)
        Me.Panel10.Location = New System.Drawing.Point(6, 48)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(484, 29)
        Me.Panel10.TabIndex = 9
        '
        'Combo1
        '
        Me.Combo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo1.FormattingEnabled = True
        Me.Combo1.Location = New System.Drawing.Point(169, 5)
        Me.Combo1.Name = "Combo1"
        Me.Combo1.Size = New System.Drawing.Size(307, 21)
        Me.Combo1.TabIndex = 25
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(13, 8)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(80, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Report Format :"
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(413, 214)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(116, 40)
        Me.cmdShow.TabIndex = 36
        Me.cmdShow.Text = "&Export To Excel"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.Color.White
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.Location = New System.Drawing.Point(262, 42)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.Size = New System.Drawing.Size(267, 20)
        Me.txtCoNam.TabIndex = 32
        '
        'gb1
        '
        Me.gb1.Controls.Add(Me.Panel9)
        Me.gb1.Controls.Add(Me.Panel10)
        Me.gb1.Location = New System.Drawing.Point(7, 25)
        Me.gb1.Name = "gb1"
        Me.gb1.Size = New System.Drawing.Size(496, 83)
        Me.gb1.TabIndex = 11
        Me.gb1.TabStop = False
        Me.gb1.Text = "Data Range"
        '
        'gb4
        '
        Me.gb4.Controls.Add(Me.gb1)
        Me.gb4.Location = New System.Drawing.Point(20, 64)
        Me.gb4.Name = "gb4"
        Me.gb4.Size = New System.Drawing.Size(509, 125)
        Me.gb4.TabIndex = 35
        Me.gb4.TabStop = False
        Me.gb4.Text = "Selection Criteria"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(177, 44)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(85, 13)
        Me.Label35.TabIndex = 34
        Me.Label35.Text = "Company Name:"
        '
        'cboCoCde
        '
        Me.cboCoCde.BackColor = System.Drawing.Color.White
        Me.cboCoCde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(102, 41)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(72, 21)
        Me.cboCoCde.TabIndex = 30
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.Blue
        Me.Label34.Location = New System.Drawing.Point(20, 45)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(79, 13)
        Me.Label34.TabIndex = 33
        Me.Label34.Text = "Company Code"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.saveto_folder)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 208)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(345, 53)
        Me.GroupBox1.TabIndex = 37
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Optional: Save to folder (at C: drive);   (if no input,save to C: drive)"
        '
        'saveto_folder
        '
        Me.saveto_folder.Location = New System.Drawing.Point(26, 19)
        Me.saveto_folder.Name = "saveto_folder"
        Me.saveto_folder.Size = New System.Drawing.Size(124, 20)
        Me.saveto_folder.TabIndex = 31
        '
        'TOM00005
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(548, 269)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblRptName)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.gb4)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.Label34)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(556, 303)
        Me.MinimumSize = New System.Drawing.Size(556, 303)
        Me.Name = "TOM00005"
        Me.Text = "Export Tentative to Excel"
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.gb1.ResumeLayout(False)
        Me.gb4.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtFromQuotNo As System.Windows.Forms.TextBox
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblRptName As System.Windows.Forms.Label
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents Combo1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents gb1 As System.Windows.Forms.GroupBox
    Friend WithEvents gb4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents saveto_folder As System.Windows.Forms.TextBox
End Class
