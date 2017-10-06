<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QUM00001_1
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
        Me.cmdOK = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.dgASS = New System.Windows.Forms.DataGridView
        CType(Me.dgASS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblAss
        '
        Me.lblAss.Location = New System.Drawing.Point(12, 9)
        Me.lblAss.Name = "lblAss"
        Me.lblAss.Size = New System.Drawing.Size(365, 19)
        Me.lblAss.TabIndex = 396
        Me.lblAss.Text = "Assortment Item Information :"
        '
        'cmdOK
        '
        Me.cmdOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.Location = New System.Drawing.Point(260, 316)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 40)
        Me.cmdOK.TabIndex = 1
        Me.cmdOK.Text = "OK"
        '
        'cmdCancel
        '
        Me.cmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(413, 316)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 40)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Text = "Cancel"
        '
        'dgASS
        '
        Me.dgASS.AllowUserToAddRows = False
        Me.dgASS.AllowUserToDeleteRows = False
        Me.dgASS.ColumnHeadersHeight = 20
        Me.dgASS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgASS.Location = New System.Drawing.Point(12, 31)
        Me.dgASS.Name = "dgASS"
        Me.dgASS.RowHeadersWidth = 20
        Me.dgASS.RowTemplate.Height = 15
        Me.dgASS.Size = New System.Drawing.Size(728, 279)
        Me.dgASS.TabIndex = 399
        '
        'QUM00001_1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(752, 368)
        Me.Controls.Add(Me.dgASS)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.lblAss)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "QUM00001_1"
        Me.Text = "Assortment Item Information (QUM00001_1)"
        CType(Me.dgASS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblAss As System.Windows.Forms.Label
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents dgASS As System.Windows.Forms.DataGridView
End Class
