<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPOShip
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
        Me.grdPOShip = New System.Windows.Forms.DataGridView
        Me.cmdInsRow = New System.Windows.Forms.Button
        Me.lblTotal = New System.Windows.Forms.Label
        Me.txtTotal = New System.Windows.Forms.TextBox
        Me.cmdDelRow = New System.Windows.Forms.Button
        CType(Me.grdPOShip, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(115, 318)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 36)
        Me.cmdCancel.TabIndex = 8
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.Enabled = False
        Me.cmdOK.Location = New System.Drawing.Point(26, 318)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 36)
        Me.cmdOK.TabIndex = 7
        Me.cmdOK.Text = "&OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        Me.cmdOK.Visible = False
        '
        'grdPOShip
        '
        Me.grdPOShip.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPOShip.Location = New System.Drawing.Point(15, 12)
        Me.grdPOShip.Name = "grdPOShip"
        Me.grdPOShip.RowTemplate.Height = 15
        Me.grdPOShip.Size = New System.Drawing.Size(612, 296)
        Me.grdPOShip.TabIndex = 6
        '
        'cmdInsRow
        '
        Me.cmdInsRow.Enabled = False
        Me.cmdInsRow.Location = New System.Drawing.Point(253, 318)
        Me.cmdInsRow.Name = "cmdInsRow"
        Me.cmdInsRow.Size = New System.Drawing.Size(75, 36)
        Me.cmdInsRow.TabIndex = 7
        Me.cmdInsRow.Text = "I&ns Row"
        Me.cmdInsRow.UseVisualStyleBackColor = True
        Me.cmdInsRow.Visible = False
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Location = New System.Drawing.Point(437, 330)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(37, 13)
        Me.lblTotal.TabIndex = 9
        Me.lblTotal.Text = "Total :"
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(476, 325)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(145, 20)
        Me.txtTotal.TabIndex = 10
        '
        'cmdDelRow
        '
        Me.cmdDelRow.Enabled = False
        Me.cmdDelRow.Location = New System.Drawing.Point(334, 318)
        Me.cmdDelRow.Name = "cmdDelRow"
        Me.cmdDelRow.Size = New System.Drawing.Size(75, 36)
        Me.cmdDelRow.TabIndex = 7
        Me.cmdDelRow.Text = "Del Ro&w"
        Me.cmdDelRow.UseVisualStyleBackColor = True
        Me.cmdDelRow.Visible = False
        '
        'frmPOShip
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(642, 366)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.cmdDelRow)
        Me.Controls.Add(Me.cmdInsRow)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.grdPOShip)
        Me.MaximumSize = New System.Drawing.Size(650, 400)
        Me.MinimumSize = New System.Drawing.Size(650, 400)
        Me.Name = "frmPOShip"
        Me.Text = "PO - Shipment Schedule"
        CType(Me.grdPOShip, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents grdPOShip As System.Windows.Forms.DataGridView
    Friend WithEvents cmdInsRow As System.Windows.Forms.Button
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents cmdDelRow As System.Windows.Forms.Button
End Class
