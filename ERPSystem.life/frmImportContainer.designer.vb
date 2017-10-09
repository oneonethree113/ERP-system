<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportContainer
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
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtCtrCfs_old = New System.Windows.Forms.TextBox
        Me.dgcov = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCtrCfs = New System.Windows.Forms.RichTextBox
        CType(Me.dgcov, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(229, 267)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(81, 34)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.Text = "Cancel"
        '
        'cmdOK
        '
        Me.cmdOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.Location = New System.Drawing.Point(97, 267)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(81, 34)
        Me.cmdOK.TabIndex = 4
        Me.cmdOK.Text = "OK"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(72, 196)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(90, 13)
        Me.Label15.TabIndex = 298
        Me.Label15.Text = "Import The CTR#"
        '
        'txtCtrCfs_old
        '
        Me.txtCtrCfs_old.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCtrCfs_old.Location = New System.Drawing.Point(200, 319)
        Me.txtCtrCfs_old.MaxLength = 20
        Me.txtCtrCfs_old.Name = "txtCtrCfs_old"
        Me.txtCtrCfs_old.Size = New System.Drawing.Size(186, 20)
        Me.txtCtrCfs_old.TabIndex = 297
        Me.txtCtrCfs_old.Visible = False
        '
        'dgcov
        '
        Me.dgcov.AccessibleDescription = "s"
        Me.dgcov.AllowUserToAddRows = False
        Me.dgcov.AllowUserToDeleteRows = False
        Me.dgcov.ColumnHeadersHeight = 20
        Me.dgcov.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgcov.Location = New System.Drawing.Point(75, 12)
        Me.dgcov.Name = "dgcov"
        Me.dgcov.RowHeadersWidth = 20
        Me.dgcov.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgcov.RowTemplate.Height = 16
        Me.dgcov.Size = New System.Drawing.Size(280, 161)
        Me.dgcov.TabIndex = 328
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 329
        Me.Label1.Text = "CTR List:"
        '
        'txtCtrCfs
        '
        Me.txtCtrCfs.Location = New System.Drawing.Point(179, 194)
        Me.txtCtrCfs.Name = "txtCtrCfs"
        Me.txtCtrCfs.Size = New System.Drawing.Size(169, 46)
        Me.txtCtrCfs.TabIndex = 330
        Me.txtCtrCfs.Text = ""
        '
        'frmImportContainer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(426, 335)
        Me.Controls.Add(Me.txtCtrCfs)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgcov)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtCtrCfs_old)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmImportContainer"
        Me.Text = "Import Container"
        CType(Me.dgcov, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtCtrCfs_old As System.Windows.Forms.TextBox
    Friend WithEvents dgcov As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCtrCfs As System.Windows.Forms.RichTextBox
End Class
