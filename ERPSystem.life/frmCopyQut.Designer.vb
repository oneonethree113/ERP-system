<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCopyQut
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
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.lblCoCde = New System.Windows.Forms.Label
        Me.cboPriCus = New System.Windows.Forms.ComboBox
        Me.lblCus1No = New System.Windows.Forms.Label
        Me.cboSecCus = New System.Windows.Forms.ComboBox
        Me.lblCus2No = New System.Windows.Forms.Label
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'cboCoCde
        '
        Me.cboCoCde.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(141, 27)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(66, 21)
        Me.cboCoCde.TabIndex = 1
        '
        'lblCoCde
        '
        Me.lblCoCde.AutoSize = True
        Me.lblCoCde.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblCoCde.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCoCde.Location = New System.Drawing.Point(30, 30)
        Me.lblCoCde.Name = "lblCoCde"
        Me.lblCoCde.Size = New System.Drawing.Size(82, 13)
        Me.lblCoCde.TabIndex = 32
        Me.lblCoCde.Text = "Company Code:"
        '
        'cboPriCus
        '
        Me.cboPriCus.FormattingEnabled = True
        Me.cboPriCus.Location = New System.Drawing.Point(141, 54)
        Me.cboPriCus.Name = "cboPriCus"
        Me.cboPriCus.Size = New System.Drawing.Size(180, 21)
        Me.cboPriCus.TabIndex = 2
        '
        'lblCus1No
        '
        Me.lblCus1No.AutoSize = True
        Me.lblCus1No.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCus1No.Location = New System.Drawing.Point(30, 57)
        Me.lblCus1No.Name = "lblCus1No"
        Me.lblCus1No.Size = New System.Drawing.Size(88, 13)
        Me.lblCus1No.TabIndex = 105
        Me.lblCus1No.Text = "Primary Customer"
        '
        'cboSecCus
        '
        Me.cboSecCus.FormattingEnabled = True
        Me.cboSecCus.Location = New System.Drawing.Point(141, 81)
        Me.cboSecCus.Name = "cboSecCus"
        Me.cboSecCus.Size = New System.Drawing.Size(180, 21)
        Me.cboSecCus.TabIndex = 3
        '
        'lblCus2No
        '
        Me.lblCus2No.AutoSize = True
        Me.lblCus2No.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCus2No.Location = New System.Drawing.Point(30, 84)
        Me.lblCus2No.Name = "lblCus2No"
        Me.lblCus2No.Size = New System.Drawing.Size(105, 13)
        Me.lblCus2No.TabIndex = 107
        Me.lblCus2No.Text = "Secondary Customer"
        '
        'cmdCancel
        '
        Me.cmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(181, 108)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(81, 34)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.Text = "Cancel"
        '
        'cmdOK
        '
        Me.cmdOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.Location = New System.Drawing.Point(94, 108)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(81, 34)
        Me.cmdOK.TabIndex = 4
        Me.cmdOK.Text = "OK"
        '
        'frmCopyQut
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(355, 165)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cboSecCus)
        Me.Controls.Add(Me.lblCus2No)
        Me.Controls.Add(Me.cboPriCus)
        Me.Controls.Add(Me.lblCus1No)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.lblCoCde)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmCopyQut"
        Me.Text = "Copy Quotation"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents lblCoCde As System.Windows.Forms.Label
    Friend WithEvents cboPriCus As System.Windows.Forms.ComboBox
    Friend WithEvents lblCus1No As System.Windows.Forms.Label
    Friend WithEvents cboSecCus As System.Windows.Forms.ComboBox
    Friend WithEvents lblCus2No As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
End Class
