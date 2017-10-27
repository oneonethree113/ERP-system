<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class INR00015
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(INR00015))
        Me.cboVenTo = New System.Windows.Forms.ComboBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.cboVenFm = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmdShow = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'cboVenTo
        '
        Me.cboVenTo.FormattingEnabled = True
        Me.cboVenTo.Location = New System.Drawing.Point(417, 42)
        Me.cboVenTo.Name = "cboVenTo"
        Me.cboVenTo.Size = New System.Drawing.Size(176, 20)
        Me.cboVenTo.TabIndex = 4
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(390, 46)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(18, 12)
        Me.Label31.TabIndex = 36
        Me.Label31.Text = "To"
        '
        'cboVenFm
        '
        Me.cboVenFm.FormattingEnabled = True
        Me.cboVenFm.Location = New System.Drawing.Point(203, 42)
        Me.cboVenFm.Name = "cboVenFm"
        Me.cboVenFm.Size = New System.Drawing.Size(176, 20)
        Me.cboVenFm.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(188, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(248, 24)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Production Capacity in CBM "
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(161, 47)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(30, 12)
        Me.Label20.TabIndex = 14
        Me.Label20.Text = "From"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(25, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 12)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Vendor No."
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(224, 239)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(140, 22)
        Me.cmdShow.TabIndex = 7
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'INR00015
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 285)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.cboVenTo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.cboVenFm)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label20)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "INR00015"
        Me.Text = "INR00015 – Search Photo & Desc. Report (INR15)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboVenTo As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents cboVenFm As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdShow As System.Windows.Forms.Button
End Class
