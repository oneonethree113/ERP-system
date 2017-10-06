<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SHR00001
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.grpContainNo = New System.Windows.Forms.GroupBox
        Me.txtToContain = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtFromContain = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.grp1 = New System.Windows.Forms.GroupBox
        Me.ComboBox_rpformat = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmdShow = New System.Windows.Forms.Button
        Me.grpContainNo.SuspendLayout()
        Me.grp1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(200, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(195, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Print Container List"
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.Color.White
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.Location = New System.Drawing.Point(263, 56)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.Size = New System.Drawing.Size(298, 20)
        Me.txtCoNam.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(178, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Company Name:"
        '
        'cboCoCde
        '
        Me.cboCoCde.BackColor = System.Drawing.Color.White
        Me.cboCoCde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(103, 55)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(72, 21)
        Me.cboCoCde.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(21, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Company Code"
        '
        'grpContainNo
        '
        Me.grpContainNo.Controls.Add(Me.txtToContain)
        Me.grpContainNo.Controls.Add(Me.Label5)
        Me.grpContainNo.Controls.Add(Me.txtFromContain)
        Me.grpContainNo.Controls.Add(Me.Label4)
        Me.grpContainNo.Location = New System.Drawing.Point(103, 96)
        Me.grpContainNo.Name = "grpContainNo"
        Me.grpContainNo.Size = New System.Drawing.Size(400, 59)
        Me.grpContainNo.TabIndex = 9
        Me.grpContainNo.TabStop = False
        Me.grpContainNo.Text = "Container #"
        '
        'txtToContain
        '
        Me.txtToContain.Location = New System.Drawing.Point(256, 23)
        Me.txtToContain.Name = "txtToContain"
        Me.txtToContain.Size = New System.Drawing.Size(121, 20)
        Me.txtToContain.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(212, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(20, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "To"
        '
        'txtFromContain
        '
        Me.txtFromContain.Location = New System.Drawing.Point(63, 23)
        Me.txtFromContain.Name = "txtFromContain"
        Me.txtFromContain.Size = New System.Drawing.Size(121, 20)
        Me.txtFromContain.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "From"
        '
        'grp1
        '
        Me.grp1.Controls.Add(Me.ComboBox_rpformat)
        Me.grp1.Controls.Add(Me.Label6)
        Me.grp1.Location = New System.Drawing.Point(103, 169)
        Me.grp1.Name = "grp1"
        Me.grp1.Size = New System.Drawing.Size(400, 59)
        Me.grp1.TabIndex = 10
        Me.grp1.TabStop = False
        '
        'ComboBox_rpformat
        '
        Me.ComboBox_rpformat.FormattingEnabled = True
        Me.ComboBox_rpformat.Location = New System.Drawing.Point(111, 23)
        Me.ComboBox_rpformat.Name = "ComboBox_rpformat"
        Me.ComboBox_rpformat.Size = New System.Drawing.Size(266, 21)
        Me.ComboBox_rpformat.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Report Format"
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(263, 248)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(75, 25)
        Me.cmdShow.TabIndex = 11
        Me.cmdShow.Text = "Run"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'SHR00001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 285)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.grp1)
        Me.Controls.Add(Me.grpContainNo)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "SHR00001"
        Me.Text = "SHR00001"
        Me.grpContainNo.ResumeLayout(False)
        Me.grpContainNo.PerformLayout()
        Me.grp1.ResumeLayout(False)
        Me.grp1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grpContainNo As System.Windows.Forms.GroupBox
    Friend WithEvents txtToContain As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFromContain As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents grp1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ComboBox_rpformat As System.Windows.Forms.ComboBox
    Friend WithEvents cmdShow As System.Windows.Forms.Button
End Class
