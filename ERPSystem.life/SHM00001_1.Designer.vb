<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SHM00001_1
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
        Me.grdAss = New System.Windows.Forms.DataGridView
        Me.Label76 = New System.Windows.Forms.Label
        Me.cmdOK = New System.Windows.Forms.Button
        CType(Me.grdAss, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdAss
        '
        Me.grdAss.AllowUserToAddRows = False
        Me.grdAss.AllowUserToDeleteRows = False
        Me.grdAss.ColumnHeadersHeight = 20
        Me.grdAss.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.grdAss.Location = New System.Drawing.Point(12, 25)
        Me.grdAss.Name = "grdAss"
        Me.grdAss.RowHeadersWidth = 20
        Me.grdAss.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdAss.RowTemplate.Height = 16
        Me.grdAss.Size = New System.Drawing.Size(733, 239)
        Me.grdAss.TabIndex = 371
        '
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.Location = New System.Drawing.Point(12, 9)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(143, 13)
        Me.Label76.TabIndex = 370
        Me.Label76.Text = "Assortment Item Information :"
        '
        'cmdOK
        '
        Me.cmdOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdOK.Location = New System.Drawing.Point(342, 270)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(54, 34)
        Me.cmdOK.TabIndex = 369
        Me.cmdOK.TabStop = False
        Me.cmdOK.Text = "&OK"
        '
        'SHM00001_1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(757, 316)
        Me.Controls.Add(Me.grdAss)
        Me.Controls.Add(Me.Label76)
        Me.Controls.Add(Me.cmdOK)
        Me.Name = "SHM00001_1"
        Me.Text = "Assortment Item Information (SHM00001_1)"
        CType(Me.grdAss, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdAss As System.Windows.Forms.DataGridView
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents cmdOK As System.Windows.Forms.Button
End Class
