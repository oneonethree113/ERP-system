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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TOM00005))
        Me.txtFromQuotNo = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.lblRptName = New System.Windows.Forms.Label
        Me.Panel10 = New System.Windows.Forms.Panel
        Me.Combo1 = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.cmdShow = New System.Windows.Forms.Button
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.opt_fty = New System.Windows.Forms.RadioButton
        Me.opt_hk = New System.Windows.Forms.RadioButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.chk_1756 = New System.Windows.Forms.CheckBox
        Me.chk_ext = New System.Windows.Forms.CheckBox
        Me.chk_int = New System.Windows.Forms.CheckBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.saveto_folder = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Panel10.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtFromQuotNo
        '
        Me.txtFromQuotNo.Location = New System.Drawing.Point(158, 80)
        Me.txtFromQuotNo.Name = "txtFromQuotNo"
        Me.txtFromQuotNo.Size = New System.Drawing.Size(176, 22)
        Me.txtFromQuotNo.TabIndex = 23
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(13, 83)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(68, 12)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Tentative No."
        '
        'lblRptName
        '
        Me.lblRptName.Font = New System.Drawing.Font("Arial", 14.0!)
        Me.lblRptName.ForeColor = System.Drawing.Color.Blue
        Me.lblRptName.Location = New System.Drawing.Point(69, 14)
        Me.lblRptName.Name = "lblRptName"
        Me.lblRptName.Size = New System.Drawing.Size(509, 21)
        Me.lblRptName.TabIndex = 31
        Me.lblRptName.Text = "Export Tentative to Excel"
        Me.lblRptName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.Combo1)
        Me.Panel10.Controls.Add(Me.Label13)
        Me.Panel10.Location = New System.Drawing.Point(594, 438)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(18, 10)
        Me.Panel10.TabIndex = 9
        Me.Panel10.Visible = False
        '
        'Combo1
        '
        Me.Combo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo1.FormattingEnabled = True
        Me.Combo1.Location = New System.Drawing.Point(169, 5)
        Me.Combo1.Name = "Combo1"
        Me.Combo1.Size = New System.Drawing.Size(307, 20)
        Me.Combo1.TabIndex = 25
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(13, 7)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 12)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Report Format :"
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(259, 244)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(140, 22)
        Me.cmdShow.TabIndex = 36
        Me.cmdShow.Text = "&Export To Excel"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.Color.White
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.Location = New System.Drawing.Point(324, 43)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.Size = New System.Drawing.Size(302, 22)
        Me.txtCoNam.TabIndex = 32
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.opt_fty)
        Me.Panel2.Controls.Add(Me.opt_hk)
        Me.Panel2.Location = New System.Drawing.Point(158, 141)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(472, 27)
        Me.Panel2.TabIndex = 8
        '
        'opt_fty
        '
        Me.opt_fty.AutoSize = True
        Me.opt_fty.Checked = True
        Me.opt_fty.Location = New System.Drawing.Point(118, 5)
        Me.opt_fty.Name = "opt_fty"
        Me.opt_fty.Size = New System.Drawing.Size(58, 16)
        Me.opt_fty.TabIndex = 122
        Me.opt_fty.TabStop = True
        Me.opt_fty.Text = "Factory"
        Me.opt_fty.UseVisualStyleBackColor = True
        '
        'opt_hk
        '
        Me.opt_hk.AutoSize = True
        Me.opt_hk.Location = New System.Drawing.Point(267, 5)
        Me.opt_hk.Name = "opt_hk"
        Me.opt_hk.Size = New System.Drawing.Size(45, 16)
        Me.opt_hk.TabIndex = 121
        Me.opt_hk.Text = "H.K."
        Me.opt_hk.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.chk_1756)
        Me.Panel1.Controls.Add(Me.chk_ext)
        Me.Panel1.Controls.Add(Me.chk_int)
        Me.Panel1.Location = New System.Drawing.Point(158, 108)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(473, 27)
        Me.Panel1.TabIndex = 8
        '
        'chk_1756
        '
        Me.chk_1756.AutoSize = True
        Me.chk_1756.Location = New System.Drawing.Point(353, 6)
        Me.chk_1756.Name = "chk_1756"
        Me.chk_1756.Size = New System.Drawing.Size(80, 16)
        Me.chk_1756.TabIndex = 25
        Me.chk_1756.Text = "華匯(1756)"
        Me.chk_1756.UseVisualStyleBackColor = True
        '
        'chk_ext
        '
        Me.chk_ext.AutoSize = True
        Me.chk_ext.Location = New System.Drawing.Point(180, 6)
        Me.chk_ext.Name = "chk_ext"
        Me.chk_ext.Size = New System.Drawing.Size(133, 16)
        Me.chk_ext.TabIndex = 24
        Me.chk_ext.Text = "External (Except 1756)"
        Me.chk_ext.UseVisualStyleBackColor = True
        '
        'chk_int
        '
        Me.chk_int.AutoSize = True
        Me.chk_int.Checked = True
        Me.chk_int.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_int.Location = New System.Drawing.Point(53, 6)
        Me.chk_int.Name = "chk_int"
        Me.chk_int.Size = New System.Drawing.Size(60, 16)
        Me.chk_int.TabIndex = 23
        Me.chk_int.Text = "Internal"
        Me.chk_int.UseVisualStyleBackColor = True
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(231, 46)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(81, 12)
        Me.Label35.TabIndex = 34
        Me.Label35.Text = "Company Name"
        '
        'cboCoCde
        '
        Me.cboCoCde.BackColor = System.Drawing.Color.White
        Me.cboCoCde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(112, 43)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(107, 20)
        Me.cboCoCde.TabIndex = 30
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.ForeColor = System.Drawing.Color.Blue
        Me.Label34.Location = New System.Drawing.Point(13, 46)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(79, 12)
        Me.Label34.TabIndex = 33
        Me.Label34.Text = "Company Code"
        '
        'saveto_folder
        '
        Me.saveto_folder.Location = New System.Drawing.Point(158, 174)
        Me.saveto_folder.Name = "saveto_folder"
        Me.saveto_folder.Size = New System.Drawing.Size(472, 22)
        Me.saveto_folder.TabIndex = 31
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 115)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 12)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Vendor Type"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 148)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 12)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "Excel Format"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 172)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(127, 12)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "Save to folder (at C drive)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(4, 188)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 12)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "  (Optional; Default C:\)"
        '
        'TOM00005
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 271)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.saveto_folder)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtFromQuotNo)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Panel10)
        Me.Controls.Add(Me.lblRptName)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.Label34)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "TOM00005"
        Me.Text = "TOM00005 - Export Tentative to Excel (TOM05)"
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtFromQuotNo As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblRptName As System.Windows.Forms.Label
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents Combo1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents saveto_folder As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents chk_1756 As System.Windows.Forms.CheckBox
    Friend WithEvents chk_ext As System.Windows.Forms.CheckBox
    Friend WithEvents chk_int As System.Windows.Forms.CheckBox
    Friend WithEvents opt_fty As System.Windows.Forms.RadioButton
    Friend WithEvents opt_hk As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
