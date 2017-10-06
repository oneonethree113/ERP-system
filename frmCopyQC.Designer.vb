<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCopyQC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCopyQC))
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.cbo_week = New System.Windows.Forms.ComboBox
        Me.cbo_year = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(175, 86)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(81, 31)
        Me.cmdCancel.TabIndex = 111
        Me.cmdCancel.Text = "Cancel"
        '
        'cmdOK
        '
        Me.cmdOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.Location = New System.Drawing.Point(88, 86)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(81, 31)
        Me.cmdOK.TabIndex = 110
        Me.cmdOK.Text = "OK"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(25, 39)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(108, 12)
        Me.Label9.TabIndex = 290
        Me.Label9.Text = "Inspection Req. Week"
        '
        'cbo_week
        '
        Me.cbo_week.BackColor = System.Drawing.Color.White
        Me.cbo_week.FormattingEnabled = True
        Me.cbo_week.Location = New System.Drawing.Point(163, 36)
        Me.cbo_week.Name = "cbo_week"
        Me.cbo_week.Size = New System.Drawing.Size(180, 20)
        Me.cbo_week.TabIndex = 291
        '
        'cbo_year
        '
        Me.cbo_year.BackColor = System.Drawing.Color.White
        Me.cbo_year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_year.Enabled = False
        Me.cbo_year.FormattingEnabled = True
        Me.cbo_year.Location = New System.Drawing.Point(163, 11)
        Me.cbo_year.Name = "cbo_year"
        Me.cbo_year.Size = New System.Drawing.Size(180, 20)
        Me.cbo_year.TabIndex = 322
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.Location = New System.Drawing.Point(25, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(103, 12)
        Me.Label11.TabIndex = 323
        Me.Label11.Text = "Inspection Req. Year"
        '
        'frmCopyQC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(365, 128)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cbo_year)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cbo_week)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCopyQC"
        Me.Text = "frmCopyQC"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbo_week As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_year As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
End Class
