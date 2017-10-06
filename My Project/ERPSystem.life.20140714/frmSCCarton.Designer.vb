<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSCCarton
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
        Me.txtTotal = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdDelRow = New System.Windows.Forms.Button
        Me.cmdInsRow = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me.grdSCCarton = New System.Windows.Forms.DataGridView
        CType(Me.grdSCCarton, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(455, 366)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(143, 20)
        Me.txtTotal.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(412, 369)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Total :"
        '
        'cmdDelRow
        '
        Me.cmdDelRow.Location = New System.Drawing.Point(310, 360)
        Me.cmdDelRow.Name = "cmdDelRow"
        Me.cmdDelRow.Size = New System.Drawing.Size(75, 29)
        Me.cmdDelRow.TabIndex = 11
        Me.cmdDelRow.Text = "Del Row"
        Me.cmdDelRow.UseVisualStyleBackColor = True
        '
        'cmdInsRow
        '
        Me.cmdInsRow.Location = New System.Drawing.Point(229, 361)
        Me.cmdInsRow.Name = "cmdInsRow"
        Me.cmdInsRow.Size = New System.Drawing.Size(75, 29)
        Me.cmdInsRow.TabIndex = 10
        Me.cmdInsRow.Text = "Ins Row"
        Me.cmdInsRow.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(93, 361)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 29)
        Me.cmdCancel.TabIndex = 9
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(12, 361)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 29)
        Me.cmdOK.TabIndex = 8
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'grdSCCarton
        '
        Me.grdSCCarton.AllowUserToAddRows = False
        Me.grdSCCarton.AllowUserToDeleteRows = False
        Me.grdSCCarton.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdSCCarton.Location = New System.Drawing.Point(12, 13)
        Me.grdSCCarton.Name = "grdSCCarton"
        Me.grdSCCarton.RowHeadersWidth = 20
        Me.grdSCCarton.RowTemplate.Height = 17
        Me.grdSCCarton.Size = New System.Drawing.Size(586, 341)
        Me.grdSCCarton.TabIndex = 7
        '
        'frmSCCarton
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(611, 402)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdDelRow)
        Me.Controls.Add(Me.cmdInsRow)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.grdSCCarton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmSCCarton"
        Me.Text = "SC Carton Detail"
        CType(Me.grdSCCarton, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdDelRow As System.Windows.Forms.Button
    Friend WithEvents cmdInsRow As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents grdSCCarton As System.Windows.Forms.DataGridView
End Class
