<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IMR00019
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
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtItmCreDatFm = New System.Windows.Forms.MaskedTextBox
        Me.txtItmCreDatTo = New System.Windows.Forms.MaskedTextBox
        Me.cboVnFm = New System.Windows.Forms.ComboBox
        Me.cboRptTyp = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdShow = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.Location = New System.Drawing.Point(146, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(343, 20)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "External Item Image List (Export to Excel)"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtItmCreDatFm)
        Me.GroupBox1.Controls.Add(Me.txtItmCreDatTo)
        Me.GroupBox1.Controls.Add(Me.cboVnFm)
        Me.GroupBox1.Controls.Add(Me.cboRptTyp)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(32, 74)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(581, 183)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txtItmCreDatFm
        '
        Me.txtItmCreDatFm.Location = New System.Drawing.Point(157, 115)
        Me.txtItmCreDatFm.Mask = "##/##/####"
        Me.txtItmCreDatFm.Name = "txtItmCreDatFm"
        Me.txtItmCreDatFm.Size = New System.Drawing.Size(100, 20)
        Me.txtItmCreDatFm.TabIndex = 3
        '
        'txtItmCreDatTo
        '
        Me.txtItmCreDatTo.Location = New System.Drawing.Point(386, 115)
        Me.txtItmCreDatTo.Mask = "##/##/####"
        Me.txtItmCreDatTo.Name = "txtItmCreDatTo"
        Me.txtItmCreDatTo.Size = New System.Drawing.Size(100, 20)
        Me.txtItmCreDatTo.TabIndex = 4
        '
        'cboVnFm
        '
        Me.cboVnFm.FormattingEnabled = True
        Me.cboVnFm.Location = New System.Drawing.Point(103, 62)
        Me.cboVnFm.Name = "cboVnFm"
        Me.cboVnFm.Size = New System.Drawing.Size(239, 21)
        Me.cboVnFm.TabIndex = 2
        '
        'cboRptTyp
        '
        Me.cboRptTyp.FormattingEnabled = True
        Me.cboRptTyp.Location = New System.Drawing.Point(103, 19)
        Me.cboRptTyp.Name = "cboRptTyp"
        Me.cboRptTyp.Size = New System.Drawing.Size(239, 21)
        Me.cboRptTyp.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(496, 118)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(79, 13)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "MM/DD/YYYY"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(115, 118)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 13)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "From :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(263, 118)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "MM/DD/YYYY"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(348, 118)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = " To : "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 118)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Item Create Date"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(30, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Vendor No. :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Report Type :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(-4, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(661, 13)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "_________________________________________________________________________________" & _
            "____________________________"
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(289, 269)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(85, 41)
        Me.cmdShow.TabIndex = 5
        Me.cmdShow.Text = "Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'IMR00019
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(643, 330)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label3)
        Me.MaximumSize = New System.Drawing.Size(651, 364)
        Me.MinimumSize = New System.Drawing.Size(651, 364)
        Me.Name = "IMR00019"
        Me.Text = "IMR00019 - External Item Image List (Export to Excel)"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtItmCreDatFm As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtItmCreDatTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cboVnFm As System.Windows.Forms.ComboBox
    Friend WithEvents cboRptTyp As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdShow As System.Windows.Forms.Button
End Class
