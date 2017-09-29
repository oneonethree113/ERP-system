<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PGM00008
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
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.optRel = New System.Windows.Forms.RadioButton
        Me.cmdShow = New System.Windows.Forms.Button
        Me.optUnr = New System.Windows.Forms.RadioButton
        Me.txtTo = New System.Windows.Forms.TextBox
        Me.txtResult = New System.Windows.Forms.TextBox
        Me.grpDocNo = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtFrom = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.grpDocNo.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.Color.White
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.Location = New System.Drawing.Point(383, 36)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.Size = New System.Drawing.Size(298, 20)
        Me.txtCoNam.TabIndex = 20
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(141, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Company Code"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(298, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Company Name:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 59)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Action"
        '
        'cboCoCde
        '
        Me.cboCoCde.BackColor = System.Drawing.Color.White
        Me.cboCoCde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(223, 35)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(72, 21)
        Me.cboCoCde.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(228, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(362, 25)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Packaging Order Release/Unrelease"
        '
        'optRel
        '
        Me.optRel.AutoSize = True
        Me.optRel.Checked = True
        Me.optRel.Location = New System.Drawing.Point(108, 57)
        Me.optRel.Name = "optRel"
        Me.optRel.Size = New System.Drawing.Size(64, 17)
        Me.optRel.TabIndex = 4
        Me.optRel.TabStop = True
        Me.optRel.Text = "Release"
        Me.optRel.UseVisualStyleBackColor = True
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(372, 159)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(75, 25)
        Me.cmdShow.TabIndex = 23
        Me.cmdShow.Text = "Run"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'optUnr
        '
        Me.optUnr.AutoSize = True
        Me.optUnr.Location = New System.Drawing.Point(239, 57)
        Me.optUnr.Name = "optUnr"
        Me.optUnr.Size = New System.Drawing.Size(73, 17)
        Me.optUnr.TabIndex = 5
        Me.optUnr.Text = "Unrelease"
        Me.optUnr.UseVisualStyleBackColor = True
        '
        'txtTo
        '
        Me.txtTo.Location = New System.Drawing.Point(256, 23)
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Size = New System.Drawing.Size(121, 20)
        Me.txtTo.TabIndex = 3
        '
        'txtResult
        '
        Me.txtResult.BackColor = System.Drawing.Color.White
        Me.txtResult.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtResult.ForeColor = System.Drawing.Color.Black
        Me.txtResult.Location = New System.Drawing.Point(1, 190)
        Me.txtResult.Multiline = True
        Me.txtResult.Name = "txtResult"
        Me.txtResult.ReadOnly = True
        Me.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtResult.Size = New System.Drawing.Size(790, 248)
        Me.txtResult.TabIndex = 22
        '
        'grpDocNo
        '
        Me.grpDocNo.Controls.Add(Me.Label6)
        Me.grpDocNo.Controls.Add(Me.optUnr)
        Me.grpDocNo.Controls.Add(Me.optRel)
        Me.grpDocNo.Controls.Add(Me.txtTo)
        Me.grpDocNo.Controls.Add(Me.Label5)
        Me.grpDocNo.Controls.Add(Me.txtFrom)
        Me.grpDocNo.Controls.Add(Me.Label4)
        Me.grpDocNo.Location = New System.Drawing.Point(205, 64)
        Me.grpDocNo.Name = "grpDocNo"
        Me.grpDocNo.Size = New System.Drawing.Size(400, 87)
        Me.grpDocNo.TabIndex = 21
        Me.grpDocNo.TabStop = False
        Me.grpDocNo.Text = "Document No."
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
        'txtFrom
        '
        Me.txtFrom.Location = New System.Drawing.Point(63, 23)
        Me.txtFrom.Name = "txtFrom"
        Me.txtFrom.Size = New System.Drawing.Size(121, 20)
        Me.txtFrom.TabIndex = 1
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
        'PGM00008
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 443)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.txtResult)
        Me.Controls.Add(Me.grpDocNo)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(800, 477)
        Me.MinimumSize = New System.Drawing.Size(800, 477)
        Me.Name = "PGM00008"
        Me.Text = "PGM00008 - Release/Unrelease Packaging Order"
        Me.grpDocNo.ResumeLayout(False)
        Me.grpDocNo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents optRel As System.Windows.Forms.RadioButton
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents optUnr As System.Windows.Forms.RadioButton
    Friend WithEvents txtTo As System.Windows.Forms.TextBox
    Friend WithEvents txtResult As System.Windows.Forms.TextBox
    Friend WithEvents grpDocNo As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
