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
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtSCFm = New System.Windows.Forms.TextBox
        Me.txtSCTo = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdShow = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.Location = New System.Drawing.Point(282, 16)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.Size = New System.Drawing.Size(350, 20)
        Me.txtCoNam.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(194, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Company Name"
        '
        'cboCoCde
        '
        Me.cboCoCde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(101, 16)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(76, 21)
        Me.cboCoCde.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(16, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Company Code"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtSCTo)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtSCFm)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(19, 43)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(613, 61)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Search Criteria"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "SC No."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(119, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "From"
        '
        'txtSCFm
        '
        Me.txtSCFm.Location = New System.Drawing.Point(178, 25)
        Me.txtSCFm.Name = "txtSCFm"
        Me.txtSCFm.Size = New System.Drawing.Size(142, 20)
        Me.txtSCFm.TabIndex = 2
        '
        'txtSCTo
        '
        Me.txtSCTo.Location = New System.Drawing.Point(429, 25)
        Me.txtSCTo.Name = "txtSCTo"
        Me.txtSCTo.Size = New System.Drawing.Size(142, 20)
        Me.txtSCTo.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(376, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(20, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "To"
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(278, 114)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(95, 27)
        Me.cmdShow.TabIndex = 9
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'SCR00003
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(650, 155)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "SCR00003"
        Me.Text = "SCR00003 - Print Cancellation SC with BOM Item"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSCTo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSCFm As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdShow As System.Windows.Forms.Button
End Class
