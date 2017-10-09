<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IMR00035
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
        Me.txt_S_UpddatTo = New System.Windows.Forms.MaskedTextBox
        Me.txt_S_UpddatFm = New System.Windows.Forms.MaskedTextBox
        Me.cmdReport = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_S_ItmNo = New System.Windows.Forms.TextBox
        Me.cmd_S_ItmNoAll = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.chkIntRpt = New System.Windows.Forms.CheckBox
        Me.chkExtRpt = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'txt_S_UpddatTo
        '
        Me.txt_S_UpddatTo.Location = New System.Drawing.Point(396, 58)
        Me.txt_S_UpddatTo.Mask = "00/00/0000"
        Me.txt_S_UpddatTo.Name = "txt_S_UpddatTo"
        Me.txt_S_UpddatTo.Size = New System.Drawing.Size(85, 20)
        Me.txt_S_UpddatTo.TabIndex = 34
        '
        'txt_S_UpddatFm
        '
        Me.txt_S_UpddatFm.Location = New System.Drawing.Point(216, 58)
        Me.txt_S_UpddatFm.Mask = "00/00/0000"
        Me.txt_S_UpddatFm.Name = "txt_S_UpddatFm"
        Me.txt_S_UpddatFm.Size = New System.Drawing.Size(88, 20)
        Me.txt_S_UpddatFm.TabIndex = 33
        '
        'cmdReport
        '
        Me.cmdReport.Location = New System.Drawing.Point(189, 130)
        Me.cmdReport.Name = "cmdReport"
        Me.cmdReport.Size = New System.Drawing.Size(155, 27)
        Me.cmdReport.TabIndex = 38
        Me.cmdReport.Text = "&Show Report"
        Me.cmdReport.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(393, 79)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 13)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "MM/DD/YYYY"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(338, 61)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(20, 13)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "To"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(213, 79)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "MM/DD/YYYY"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(168, 61)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 13)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "From"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 13)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Update Date"
        '
        'txt_S_ItmNo
        '
        Me.txt_S_ItmNo.Location = New System.Drawing.Point(171, 21)
        Me.txt_S_ItmNo.Name = "txt_S_ItmNo"
        Me.txt_S_ItmNo.Size = New System.Drawing.Size(350, 20)
        Me.txt_S_ItmNo.TabIndex = 21
        '
        'cmd_S_ItmNoAll
        '
        Me.cmd_S_ItmNoAll.Location = New System.Drawing.Point(81, 19)
        Me.cmd_S_ItmNoAll.Name = "cmd_S_ItmNoAll"
        Me.cmd_S_ItmNoAll.Size = New System.Drawing.Size(75, 23)
        Me.cmd_S_ItmNoAll.TabIndex = 20
        Me.cmd_S_ItmNoAll.Text = "> >"
        Me.cmd_S_ItmNoAll.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Item No."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Report"
        '
        'chkIntRpt
        '
        Me.chkIntRpt.AutoSize = True
        Me.chkIntRpt.Location = New System.Drawing.Point(171, 100)
        Me.chkIntRpt.Name = "chkIntRpt"
        Me.chkIntRpt.Size = New System.Drawing.Size(55, 17)
        Me.chkIntRpt.TabIndex = 35
        Me.chkIntRpt.Text = "Interal"
        Me.chkIntRpt.UseVisualStyleBackColor = True
        '
        'chkExtRpt
        '
        Me.chkExtRpt.AutoSize = True
        Me.chkExtRpt.Location = New System.Drawing.Point(341, 100)
        Me.chkExtRpt.Name = "chkExtRpt"
        Me.chkExtRpt.Size = New System.Drawing.Size(64, 17)
        Me.chkExtRpt.TabIndex = 37
        Me.chkExtRpt.Text = "External"
        Me.chkExtRpt.UseVisualStyleBackColor = True
        '
        'IMR00035
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(536, 168)
        Me.Controls.Add(Me.chkExtRpt)
        Me.Controls.Add(Me.chkIntRpt)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_S_UpddatTo)
        Me.Controls.Add(Me.txt_S_UpddatFm)
        Me.Controls.Add(Me.cmdReport)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_S_ItmNo)
        Me.Controls.Add(Me.cmd_S_ItmNoAll)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "IMR00035"
        Me.Text = "IMR00035  - Item Master Price Change Report"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_S_UpddatTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txt_S_UpddatFm As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cmdReport As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_S_ItmNo As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_ItmNoAll As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkIntRpt As System.Windows.Forms.CheckBox
    Friend WithEvents chkExtRpt As System.Windows.Forms.CheckBox
End Class
