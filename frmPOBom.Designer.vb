<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPOBom
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
        Me.grdPOBom = New System.Windows.Forms.DataGridView
        Me.cmdOK = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.LstVen = New System.Windows.Forms.ListBox
        Me.LstVenSub = New System.Windows.Forms.ListBox
        CType(Me.grdPOBom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdPOBom
        '
        Me.grdPOBom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPOBom.Location = New System.Drawing.Point(15, 11)
        Me.grdPOBom.Name = "grdPOBom"
        Me.grdPOBom.RowTemplate.Height = 15
        Me.grdPOBom.Size = New System.Drawing.Size(612, 296)
        Me.grdPOBom.TabIndex = 0
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(222, 317)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 36)
        Me.cmdOK.TabIndex = 1
        Me.cmdOK.Text = "&OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(340, 317)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 36)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'LstVen
        '
        Me.LstVen.FormattingEnabled = True
        Me.LstVen.Location = New System.Drawing.Point(127, 102)
        Me.LstVen.Name = "LstVen"
        Me.LstVen.Size = New System.Drawing.Size(120, 56)
        Me.LstVen.TabIndex = 3
        Me.LstVen.Visible = False
        '
        'LstVenSub
        '
        Me.LstVenSub.FormattingEnabled = True
        Me.LstVenSub.Location = New System.Drawing.Point(370, 159)
        Me.LstVenSub.Name = "LstVenSub"
        Me.LstVenSub.Size = New System.Drawing.Size(120, 43)
        Me.LstVenSub.TabIndex = 4
        Me.LstVenSub.Visible = False
        '
        'frmPOBom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(642, 366)
        Me.Controls.Add(Me.LstVenSub)
        Me.Controls.Add(Me.LstVen)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.grdPOBom)
        Me.MaximumSize = New System.Drawing.Size(650, 400)
        Me.MinimumSize = New System.Drawing.Size(650, 400)
        Me.Name = "frmPOBom"
        Me.Text = "PO - BOM"
        CType(Me.grdPOBom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdPOBom As System.Windows.Forms.DataGridView
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents LstVen As System.Windows.Forms.ListBox
    Friend WithEvents LstVenSub As System.Windows.Forms.ListBox
End Class
