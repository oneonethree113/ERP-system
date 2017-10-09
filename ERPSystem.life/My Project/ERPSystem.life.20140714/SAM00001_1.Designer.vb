<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SAM00001_1
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
        Me.cmdOK = New System.Windows.Forms.Button
        Me.lblAss = New System.Windows.Forms.Label
        Me.grdAss = New System.Windows.Forms.DataGridView
        Me.cmdCancel = New System.Windows.Forms.Button
        CType(Me.grdAss, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(319, 267)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 37)
        Me.cmdOK.TabIndex = 0
        Me.cmdOK.Text = "&OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'lblAss
        '
        Me.lblAss.AutoSize = True
        Me.lblAss.Location = New System.Drawing.Point(17, 16)
        Me.lblAss.Name = "lblAss"
        Me.lblAss.Size = New System.Drawing.Size(143, 13)
        Me.lblAss.TabIndex = 2
        Me.lblAss.Text = "Assortment Item Information :"
        '
        'grdAss
        '
        Me.grdAss.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdAss.Location = New System.Drawing.Point(12, 40)
        Me.grdAss.Name = "grdAss"
        Me.grdAss.RowTemplate.Height = 15
        Me.grdAss.Size = New System.Drawing.Size(768, 221)
        Me.grdAss.TabIndex = 3
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(418, 267)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 37)
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'SAM00001_1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 316)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.grdAss)
        Me.Controls.Add(Me.lblAss)
        Me.Controls.Add(Me.cmdOK)
        Me.MaximumSize = New System.Drawing.Size(800, 350)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(800, 350)
        Me.Name = "SAM00001_1"
        Me.Text = "Assortment Item Information (SAM00001_1)"
        CType(Me.grdAss, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents lblAss As System.Windows.Forms.Label
    Friend WithEvents grdAss As System.Windows.Forms.DataGridView
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
End Class
