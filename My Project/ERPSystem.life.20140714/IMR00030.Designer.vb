<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IMR00030
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
        Me.grpProcessDate = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtProcDatTo = New System.Windows.Forms.MaskedTextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtProcDatFm = New System.Windows.Forms.MaskedTextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmdShow = New System.Windows.Forms.Button
        Me.grpProcessDate.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpProcessDate
        '
        Me.grpProcessDate.Controls.Add(Me.Label4)
        Me.grpProcessDate.Controls.Add(Me.Label3)
        Me.grpProcessDate.Controls.Add(Me.txtProcDatTo)
        Me.grpProcessDate.Controls.Add(Me.Label2)
        Me.grpProcessDate.Controls.Add(Me.Label1)
        Me.grpProcessDate.Controls.Add(Me.txtProcDatFm)
        Me.grpProcessDate.Controls.Add(Me.Label6)
        Me.grpProcessDate.Location = New System.Drawing.Point(12, 12)
        Me.grpProcessDate.Name = "grpProcessDate"
        Me.grpProcessDate.Size = New System.Drawing.Size(500, 58)
        Me.grpProcessDate.TabIndex = 0
        Me.grpProcessDate.TabStop = False
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(354, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "MM/DD/YYYY"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(175, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "MM/DD/YYYY"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtProcDatTo
        '
        Me.txtProcDatTo.Location = New System.Drawing.Point(354, 15)
        Me.txtProcDatTo.Mask = "00/00/0000"
        Me.txtProcDatTo.Name = "txtProcDatTo"
        Me.txtProcDatTo.Size = New System.Drawing.Size(100, 20)
        Me.txtProcDatTo.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(328, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "To"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(139, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "From"
        '
        'txtProcDatFm
        '
        Me.txtProcDatFm.Location = New System.Drawing.Point(175, 15)
        Me.txtProcDatFm.Mask = "00/00/0000"
        Me.txtProcDatFm.Name = "txtProcDatFm"
        Me.txtProcDatFm.Size = New System.Drawing.Size(100, 20)
        Me.txtProcDatFm.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(20, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Process Date"
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(219, 78)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(92, 30)
        Me.cmdShow.TabIndex = 1
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'IMR00030
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(525, 120)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.grpProcessDate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "IMR00030"
        Me.Text = "IMR00030 - Factory Approve Data Batch Report"
        Me.grpProcessDate.ResumeLayout(False)
        Me.grpProcessDate.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpProcessDate As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtProcDatTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtProcDatFm As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cmdShow As System.Windows.Forms.Button
End Class
