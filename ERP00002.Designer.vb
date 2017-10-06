<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ERP00002
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtUsrnam = New System.Windows.Forms.TextBox
        Me.txtPaswrd = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdOK = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(214, 26)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "System has been timed out due to inactivity." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Please enter password to unlock."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Username"
        '
        'txtUsrnam
        '
        Me.txtUsrnam.BackColor = System.Drawing.Color.White
        Me.txtUsrnam.ForeColor = System.Drawing.Color.Black
        Me.txtUsrnam.Location = New System.Drawing.Point(85, 52)
        Me.txtUsrnam.Name = "txtUsrnam"
        Me.txtUsrnam.Size = New System.Drawing.Size(141, 20)
        Me.txtUsrnam.TabIndex = 2
        '
        'txtPaswrd
        '
        Me.txtPaswrd.BackColor = System.Drawing.Color.White
        Me.txtPaswrd.ForeColor = System.Drawing.Color.Black
        Me.txtPaswrd.Location = New System.Drawing.Point(85, 78)
        Me.txtPaswrd.Name = "txtPaswrd"
        Me.txtPaswrd.Size = New System.Drawing.Size(141, 20)
        Me.txtPaswrd.TabIndex = 4
        Me.txtPaswrd.UseSystemPasswordChar = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Password"
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(80, 114)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(90, 23)
        Me.cmdOK.TabIndex = 5
        Me.cmdOK.Text = "&OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'ERP00002
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(251, 149)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.txtPaswrd)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtUsrnam)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ERP00002"
        Me.ShowIcon = False
        Me.Text = "ERP System - Time Out"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtUsrnam As System.Windows.Forms.TextBox
    Friend WithEvents txtPaswrd As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdOK As System.Windows.Forms.Button
End Class
