<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SAM00003_1
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
        Me.lblAss = New System.Windows.Forms.Label
        Me.grdAss = New System.Windows.Forms.DataGridView
        Me.cmdOK = New System.Windows.Forms.Button
        CType(Me.grdAss, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblAss
        '
        Me.lblAss.AutoSize = True
        Me.lblAss.Location = New System.Drawing.Point(8, 9)
        Me.lblAss.Name = "lblAss"
        Me.lblAss.Size = New System.Drawing.Size(143, 13)
        Me.lblAss.TabIndex = 0
        Me.lblAss.Text = "Assortment Item Information :"
        '
        'grdAss
        '
        Me.grdAss.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdAss.Location = New System.Drawing.Point(12, 31)
        Me.grdAss.Name = "grdAss"
        Me.grdAss.RowTemplate.Height = 15
        Me.grdAss.Size = New System.Drawing.Size(768, 221)
        Me.grdAss.TabIndex = 5
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(356, 262)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 37)
        Me.cmdOK.TabIndex = 4
        Me.cmdOK.Text = "&OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'SAM00003_1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 316)
        Me.Controls.Add(Me.grdAss)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.lblAss)
        Me.MaximumSize = New System.Drawing.Size(800, 350)
        Me.MinimumSize = New System.Drawing.Size(800, 350)
        Me.Name = "SAM00003_1"
        Me.Text = "SAM00003_1 - Sample Invoice Assortment"
        CType(Me.grdAss, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblAss As System.Windows.Forms.Label
    Friend WithEvents grdAss As System.Windows.Forms.DataGridView
    Friend WithEvents cmdOK As System.Windows.Forms.Button
End Class
