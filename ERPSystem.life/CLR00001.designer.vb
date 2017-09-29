<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CLR00001
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CLR00001))
        Me.cmdShow = New System.Windows.Forms.Button
        Me.txtdocno = New System.Windows.Forms.TextBox
        Me.gbClaimBy = New System.Windows.Forms.GroupBox
        Me.cmdShow2 = New System.Windows.Forms.Button
        Me.lblClaimNo = New System.Windows.Forms.Label
        Me.cboClaimNo = New System.Windows.Forms.ComboBox
        Me.rbClaimBy_U = New System.Windows.Forms.RadioButton
        Me.lblClaimBy = New System.Windows.Forms.Label
        Me.cboVendor = New System.Windows.Forms.ComboBox
        Me.lblVendor = New System.Windows.Forms.Label
        Me.cboSecCust = New System.Windows.Forms.ComboBox
        Me.lblSecCust = New System.Windows.Forms.Label
        Me.cboPriCust = New System.Windows.Forms.ComboBox
        Me.lblPriCust = New System.Windows.Forms.Label
        Me.rbClaimBy_V = New System.Windows.Forms.RadioButton
        Me.rbClaimBy_C = New System.Windows.Forms.RadioButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdExport = New System.Windows.Forms.Button
        Me.gbClaimBy.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(79, 89)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(98, 32)
        Me.cmdShow.TabIndex = 2
        Me.cmdShow.Text = "Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'txtdocno
        '
        Me.txtdocno.Location = New System.Drawing.Point(148, 38)
        Me.txtdocno.Name = "txtdocno"
        Me.txtdocno.Size = New System.Drawing.Size(170, 21)
        Me.txtdocno.TabIndex = 0
        '
        'gbClaimBy
        '
        Me.gbClaimBy.Controls.Add(Me.cmdShow2)
        Me.gbClaimBy.Controls.Add(Me.lblClaimNo)
        Me.gbClaimBy.Controls.Add(Me.cboClaimNo)
        Me.gbClaimBy.Controls.Add(Me.rbClaimBy_U)
        Me.gbClaimBy.Controls.Add(Me.lblClaimBy)
        Me.gbClaimBy.Controls.Add(Me.cboVendor)
        Me.gbClaimBy.Controls.Add(Me.lblVendor)
        Me.gbClaimBy.Controls.Add(Me.cboSecCust)
        Me.gbClaimBy.Controls.Add(Me.lblSecCust)
        Me.gbClaimBy.Controls.Add(Me.cboPriCust)
        Me.gbClaimBy.Controls.Add(Me.lblPriCust)
        Me.gbClaimBy.Controls.Add(Me.rbClaimBy_V)
        Me.gbClaimBy.Controls.Add(Me.rbClaimBy_C)
        Me.gbClaimBy.Enabled = False
        Me.gbClaimBy.Location = New System.Drawing.Point(52, 399)
        Me.gbClaimBy.Name = "gbClaimBy"
        Me.gbClaimBy.Size = New System.Drawing.Size(542, 167)
        Me.gbClaimBy.TabIndex = 88
        Me.gbClaimBy.TabStop = False
        Me.gbClaimBy.Visible = False
        '
        'cmdShow2
        '
        Me.cmdShow2.Location = New System.Drawing.Point(438, 127)
        Me.cmdShow2.Name = "cmdShow2"
        Me.cmdShow2.Size = New System.Drawing.Size(98, 32)
        Me.cmdShow2.TabIndex = 95
        Me.cmdShow2.Text = "Show"
        Me.cmdShow2.UseVisualStyleBackColor = True
        '
        'lblClaimNo
        '
        Me.lblClaimNo.AutoSize = True
        Me.lblClaimNo.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblClaimNo.Location = New System.Drawing.Point(9, 137)
        Me.lblClaimNo.Name = "lblClaimNo"
        Me.lblClaimNo.Size = New System.Drawing.Size(53, 15)
        Me.lblClaimNo.TabIndex = 93
        Me.lblClaimNo.Text = "Claim No"
        '
        'cboClaimNo
        '
        Me.cboClaimNo.FormattingEnabled = True
        Me.cboClaimNo.Location = New System.Drawing.Point(123, 134)
        Me.cboClaimNo.Name = "cboClaimNo"
        Me.cboClaimNo.Size = New System.Drawing.Size(283, 23)
        Me.cboClaimNo.TabIndex = 92
        '
        'rbClaimBy_U
        '
        Me.rbClaimBy_U.AutoSize = True
        Me.rbClaimBy_U.Location = New System.Drawing.Point(273, 20)
        Me.rbClaimBy_U.Name = "rbClaimBy_U"
        Me.rbClaimBy_U.Size = New System.Drawing.Size(76, 19)
        Me.rbClaimBy_U.TabIndex = 38
        Me.rbClaimBy_U.Text = "HK Office"
        Me.rbClaimBy_U.UseVisualStyleBackColor = True
        '
        'lblClaimBy
        '
        Me.lblClaimBy.AutoSize = True
        Me.lblClaimBy.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblClaimBy.Location = New System.Drawing.Point(6, 24)
        Me.lblClaimBy.Name = "lblClaimBy"
        Me.lblClaimBy.Size = New System.Drawing.Size(53, 15)
        Me.lblClaimBy.TabIndex = 37
        Me.lblClaimBy.Text = "Claim By"
        '
        'cboVendor
        '
        Me.cboVendor.FormattingEnabled = True
        Me.cboVendor.Location = New System.Drawing.Point(123, 107)
        Me.cboVendor.Name = "cboVendor"
        Me.cboVendor.Size = New System.Drawing.Size(283, 23)
        Me.cboVendor.TabIndex = 35
        '
        'lblVendor
        '
        Me.lblVendor.AutoSize = True
        Me.lblVendor.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblVendor.Location = New System.Drawing.Point(8, 110)
        Me.lblVendor.Name = "lblVendor"
        Me.lblVendor.Size = New System.Drawing.Size(41, 15)
        Me.lblVendor.TabIndex = 36
        Me.lblVendor.Text = "Vendor"
        '
        'cboSecCust
        '
        Me.cboSecCust.FormattingEnabled = True
        Me.cboSecCust.Items.AddRange(New Object() {"01 - Markdown Support"})
        Me.cboSecCust.Location = New System.Drawing.Point(123, 78)
        Me.cboSecCust.Name = "cboSecCust"
        Me.cboSecCust.Size = New System.Drawing.Size(283, 23)
        Me.cboSecCust.TabIndex = 33
        '
        'lblSecCust
        '
        Me.lblSecCust.AutoSize = True
        Me.lblSecCust.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblSecCust.Location = New System.Drawing.Point(8, 81)
        Me.lblSecCust.Name = "lblSecCust"
        Me.lblSecCust.Size = New System.Drawing.Size(107, 15)
        Me.lblSecCust.TabIndex = 34
        Me.lblSecCust.Text = "Secondary Customer"
        '
        'cboPriCust
        '
        Me.cboPriCust.FormattingEnabled = True
        Me.cboPriCust.Items.AddRange(New Object() {"01 - Markdown Support"})
        Me.cboPriCust.Location = New System.Drawing.Point(123, 49)
        Me.cboPriCust.Name = "cboPriCust"
        Me.cboPriCust.Size = New System.Drawing.Size(283, 23)
        Me.cboPriCust.TabIndex = 31
        '
        'lblPriCust
        '
        Me.lblPriCust.AutoSize = True
        Me.lblPriCust.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblPriCust.Location = New System.Drawing.Point(8, 52)
        Me.lblPriCust.Name = "lblPriCust"
        Me.lblPriCust.Size = New System.Drawing.Size(96, 15)
        Me.lblPriCust.TabIndex = 32
        Me.lblPriCust.Text = "Primary Customer"
        '
        'rbClaimBy_V
        '
        Me.rbClaimBy_V.AutoSize = True
        Me.rbClaimBy_V.Location = New System.Drawing.Point(207, 20)
        Me.rbClaimBy_V.Name = "rbClaimBy_V"
        Me.rbClaimBy_V.Size = New System.Drawing.Size(59, 19)
        Me.rbClaimBy_V.TabIndex = 21
        Me.rbClaimBy_V.Text = "Vendor"
        Me.rbClaimBy_V.UseVisualStyleBackColor = True
        '
        'rbClaimBy_C
        '
        Me.rbClaimBy_C.AutoSize = True
        Me.rbClaimBy_C.Checked = True
        Me.rbClaimBy_C.Location = New System.Drawing.Point(123, 20)
        Me.rbClaimBy_C.Name = "rbClaimBy_C"
        Me.rbClaimBy_C.Size = New System.Drawing.Size(72, 19)
        Me.rbClaimBy_C.TabIndex = 20
        Me.rbClaimBy_C.TabStop = True
        Me.rbClaimBy_C.Text = "Customer"
        Me.rbClaimBy_C.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label3.Location = New System.Drawing.Point(75, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 15)
        Me.Label3.TabIndex = 94
        Me.Label3.Text = "Claim No"
        '
        'cmdExport
        '
        Me.cmdExport.Location = New System.Drawing.Point(210, 89)
        Me.cmdExport.Name = "cmdExport"
        Me.cmdExport.Size = New System.Drawing.Size(98, 32)
        Me.cmdExport.TabIndex = 95
        Me.cmdExport.Text = "Export to PDF"
        Me.cmdExport.UseVisualStyleBackColor = True
        '
        'CLR00001
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(402, 180)
        Me.Controls.Add(Me.cmdExport)
        Me.Controls.Add(Me.txtdocno)
        Me.Controls.Add(Me.gbClaimBy)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmdShow)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "CLR00001"
        Me.Text = "CLR00001 - Claims Transaction Report (CLR01)"
        Me.gbClaimBy.ResumeLayout(False)
        Me.gbClaimBy.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents txtdocno As System.Windows.Forms.TextBox
    Friend WithEvents gbClaimBy As System.Windows.Forms.GroupBox
    Friend WithEvents rbClaimBy_U As System.Windows.Forms.RadioButton
    Friend WithEvents lblClaimBy As System.Windows.Forms.Label
    Friend WithEvents cboVendor As System.Windows.Forms.ComboBox
    Friend WithEvents lblVendor As System.Windows.Forms.Label
    Friend WithEvents cboSecCust As System.Windows.Forms.ComboBox
    Friend WithEvents lblSecCust As System.Windows.Forms.Label
    Friend WithEvents cboPriCust As System.Windows.Forms.ComboBox
    Friend WithEvents lblPriCust As System.Windows.Forms.Label
    Friend WithEvents rbClaimBy_V As System.Windows.Forms.RadioButton
    Friend WithEvents rbClaimBy_C As System.Windows.Forms.RadioButton
    Friend WithEvents lblClaimNo As System.Windows.Forms.Label
    Friend WithEvents cboClaimNo As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdShow2 As System.Windows.Forms.Button
    Friend WithEvents cmdExport As System.Windows.Forms.Button
End Class
