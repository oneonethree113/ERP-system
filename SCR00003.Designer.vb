<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SCR00003
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SCR00003))
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtSCTo = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtSCFm = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdShow = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.Color.SkyBlue
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.Location = New System.Drawing.Point(282, 54)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.Size = New System.Drawing.Size(318, 22)
        Me.txtCoNam.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(194, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 12)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Company Name"
        '
        'cboCoCde
        '
        Me.cboCoCde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(101, 54)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(76, 20)
        Me.cboCoCde.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(16, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 12)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Company Code"
        '
        'txtSCTo
        '
        Me.txtSCTo.Location = New System.Drawing.Point(411, 152)
        Me.txtSCTo.Name = "txtSCTo"
        Me.txtSCTo.Size = New System.Drawing.Size(189, 22)
        Me.txtSCTo.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(358, 155)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(18, 12)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "To"
        '
        'txtSCFm
        '
        Me.txtSCFm.Location = New System.Drawing.Point(158, 152)
        Me.txtSCFm.Name = "txtSCFm"
        Me.txtSCFm.Size = New System.Drawing.Size(189, 22)
        Me.txtSCFm.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(99, 155)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 12)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "From"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 155)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 12)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "SC No."
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(260, 290)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(116, 40)
        Me.cmdShow.TabIndex = 5
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(57, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(509, 23)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Print Sales Confirmation Report"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SCR00003
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(634, 412)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtSCTo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.txtSCFm)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "SCR00003"
        Me.Text = "SCR00003 - Print Cancellation SC with BOM Item (SCR03)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSCTo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSCFm As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
