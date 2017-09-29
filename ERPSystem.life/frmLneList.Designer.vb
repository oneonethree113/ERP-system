<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLneList
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
        Me.Command2 = New System.Windows.Forms.Button
        Me.Command1 = New System.Windows.Forms.Button
        Me.Command3 = New System.Windows.Forms.Button
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lstTo = New System.Windows.Forms.ListBox
        Me.lstFrom = New System.Windows.Forms.ListBox
        Me.txtResult = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(18, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 43)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "From"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Command2
        '
        Me.Command2.Location = New System.Drawing.Point(25, 337)
        Me.Command2.Name = "Command2"
        Me.Command2.Size = New System.Drawing.Size(75, 23)
        Me.Command2.TabIndex = 2
        Me.Command2.Text = "Clear"
        Me.Command2.UseVisualStyleBackColor = True
        '
        'Command1
        '
        Me.Command1.Location = New System.Drawing.Point(326, 337)
        Me.Command1.Name = "Command1"
        Me.Command1.Size = New System.Drawing.Size(75, 23)
        Me.Command1.TabIndex = 3
        Me.Command1.Text = "OK"
        Me.Command1.UseVisualStyleBackColor = True
        '
        'Command3
        '
        Me.Command3.Location = New System.Drawing.Point(423, 337)
        Me.Command3.Name = "Command3"
        Me.Command3.Size = New System.Drawing.Size(75, 23)
        Me.Command3.TabIndex = 4
        Me.Command3.Text = "Cancel"
        Me.Command3.UseVisualStyleBackColor = True
        '
        'cmdAdd
        '
        Me.cmdAdd.Location = New System.Drawing.Point(195, 124)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(75, 23)
        Me.cmdAdd.TabIndex = 6
        Me.cmdAdd.Text = "(&Add)  >>"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Location = New System.Drawing.Point(195, 187)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(75, 23)
        Me.cmdDelete.TabIndex = 7
        Me.cmdDelete.Text = "<< (&Del)"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(307, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 43)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "To"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lstTo)
        Me.GroupBox1.Controls.Add(Me.lstFrom)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmdDelete)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmdAdd)
        Me.GroupBox1.Location = New System.Drawing.Point(25, 37)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(470, 294)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'lstTo
        '
        Me.lstTo.FormattingEnabled = True
        Me.lstTo.Location = New System.Drawing.Point(285, 51)
        Me.lstTo.Name = "lstTo"
        Me.lstTo.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstTo.Size = New System.Drawing.Size(159, 225)
        Me.lstTo.TabIndex = 10
        '
        'lstFrom
        '
        Me.lstFrom.FormattingEnabled = True
        Me.lstFrom.Location = New System.Drawing.Point(21, 51)
        Me.lstFrom.Name = "lstFrom"
        Me.lstFrom.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstFrom.Size = New System.Drawing.Size(159, 225)
        Me.lstFrom.TabIndex = 9
        '
        'txtResult
        '
        Me.txtResult.Location = New System.Drawing.Point(25, 11)
        Me.txtResult.Name = "txtResult"
        Me.txtResult.Size = New System.Drawing.Size(465, 20)
        Me.txtResult.TabIndex = 10
        '
        'frmLneList
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(527, 381)
        Me.Controls.Add(Me.txtResult)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Command3)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.Command2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmLneList"
        Me.Text = "List of Selected Items"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Command2 As System.Windows.Forms.Button
    Friend WithEvents Command1 As System.Windows.Forms.Button
    Friend WithEvents Command3 As System.Windows.Forms.Button
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtResult As System.Windows.Forms.TextBox
    Friend WithEvents lstTo As System.Windows.Forms.ListBox
    Friend WithEvents lstFrom As System.Windows.Forms.ListBox
End Class
