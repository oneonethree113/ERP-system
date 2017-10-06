<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSCShip
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
        Me.grdSCShip = New System.Windows.Forms.DataGridView
        Me.cmdOK = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdInsRow = New System.Windows.Forms.Button
        Me.cmdDelRow = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtTotal = New System.Windows.Forms.TextBox
        CType(Me.grdSCShip, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdSCShip
        '
        Me.grdSCShip.AllowUserToAddRows = False
        Me.grdSCShip.AllowUserToDeleteRows = False
        Me.grdSCShip.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdSCShip.Location = New System.Drawing.Point(13, 13)
        Me.grdSCShip.Name = "grdSCShip"
        Me.grdSCShip.RowHeadersWidth = 20
        Me.grdSCShip.RowTemplate.Height = 17
        Me.grdSCShip.Size = New System.Drawing.Size(586, 341)
        Me.grdSCShip.TabIndex = 0
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(13, 361)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 29)
        Me.cmdOK.TabIndex = 1
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(94, 361)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 29)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdInsRow
        '
        Me.cmdInsRow.Location = New System.Drawing.Point(230, 361)
        Me.cmdInsRow.Name = "cmdInsRow"
        Me.cmdInsRow.Size = New System.Drawing.Size(75, 29)
        Me.cmdInsRow.TabIndex = 3
        Me.cmdInsRow.Text = "Ins Row"
        Me.cmdInsRow.UseVisualStyleBackColor = True
        '
        'cmdDelRow
        '
        Me.cmdDelRow.Location = New System.Drawing.Point(311, 360)
        Me.cmdDelRow.Name = "cmdDelRow"
        Me.cmdDelRow.Size = New System.Drawing.Size(75, 29)
        Me.cmdDelRow.TabIndex = 4
        Me.cmdDelRow.Text = "Del Row"
        Me.cmdDelRow.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(413, 369)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Total :"
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(456, 366)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(143, 20)
        Me.txtTotal.TabIndex = 6
        '
        'frmSCShip
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(611, 402)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdDelRow)
        Me.Controls.Add(Me.cmdInsRow)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.grdSCShip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmSCShip"
        Me.Text = "SC Ship Date Detail"
        CType(Me.grdSCShip, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdSCShip As System.Windows.Forms.DataGridView
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdInsRow As System.Windows.Forms.Button
    Friend WithEvents cmdDelRow As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
End Class
