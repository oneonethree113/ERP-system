<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPOQCRpt
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
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me.dgQCRpt = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtPONo = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        CType(Me.dgQCRpt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(223, 3)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(56, 23)
        Me.cmdClear.TabIndex = 8
        Me.cmdClear.Text = "&Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(163, 3)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(54, 23)
        Me.cmdOK.TabIndex = 7
        Me.cmdOK.Text = "&OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'dgQCRpt
        '
        Me.dgQCRpt.AllowUserToAddRows = False
        Me.dgQCRpt.AllowUserToDeleteRows = False
        Me.dgQCRpt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgQCRpt.Location = New System.Drawing.Point(3, 29)
        Me.dgQCRpt.Name = "dgQCRpt"
        Me.dgQCRpt.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgQCRpt.RowTemplate.Height = 18
        Me.dgQCRpt.Size = New System.Drawing.Size(786, 352)
        Me.dgQCRpt.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 12)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "PO No"
        '
        'txtPONo
        '
        Me.txtPONo.Location = New System.Drawing.Point(57, 5)
        Me.txtPONo.Name = "txtPONo"
        Me.txtPONo.Size = New System.Drawing.Size(100, 22)
        Me.txtPONo.TabIndex = 10
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(410, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(98, 21)
        Me.Button1.TabIndex = 17
        Me.Button1.Text = "&Show QC Report"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmPOQCRpt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 379)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtPONo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.dgQCRpt)
        Me.MaximumSize = New System.Drawing.Size(800, 417)
        Me.MinimumSize = New System.Drawing.Size(800, 417)
        Me.Name = "frmPOQCRpt"
        Me.Text = "PO - QC Report History"
        CType(Me.dgQCRpt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents dgQCRpt As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPONo As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
