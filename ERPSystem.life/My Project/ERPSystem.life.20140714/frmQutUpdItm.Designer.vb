<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQutUpdItm
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
        Me.dgResult = New System.Windows.Forms.DataGridView
        Me.Label3 = New System.Windows.Forms.Label
        Me.gbUpd = New System.Windows.Forms.GroupBox
        Me.optUpdE = New System.Windows.Forms.RadioButton
        Me.optUpdN = New System.Windows.Forms.RadioButton
        Me.optUpdA = New System.Windows.Forms.RadioButton
        Me.optUpdC = New System.Windows.Forms.RadioButton
        Me.optUpdI = New System.Windows.Forms.RadioButton
        Me.cmdUpdate = New System.Windows.Forms.Button
        Me.cmdcancel = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtFm = New System.Windows.Forms.TextBox
        Me.txtTo = New System.Windows.Forms.TextBox
        Me.cmdApply = New System.Windows.Forms.Button
        Me.txtMsg = New System.Windows.Forms.RichTextBox
        CType(Me.dgResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbUpd.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgResult
        '
        Me.dgResult.AllowUserToAddRows = False
        Me.dgResult.AllowUserToDeleteRows = False
        Me.dgResult.ColumnHeadersHeight = 20
        Me.dgResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgResult.Location = New System.Drawing.Point(12, 12)
        Me.dgResult.Name = "dgResult"
        Me.dgResult.RowHeadersWidth = 20
        Me.dgResult.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.dgResult.RowTemplate.Height = 16
        Me.dgResult.Size = New System.Drawing.Size(728, 259)
        Me.dgResult.TabIndex = 394
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label3.Location = New System.Drawing.Point(51, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 395
        Me.Label3.Text = "Update :"
        Me.Label3.Visible = False
        '
        'gbUpd
        '
        Me.gbUpd.Controls.Add(Me.optUpdE)
        Me.gbUpd.Controls.Add(Me.optUpdN)
        Me.gbUpd.Controls.Add(Me.optUpdA)
        Me.gbUpd.Controls.Add(Me.optUpdC)
        Me.gbUpd.Controls.Add(Me.optUpdI)
        Me.gbUpd.Controls.Add(Me.Label3)
        Me.gbUpd.Location = New System.Drawing.Point(13, 277)
        Me.gbUpd.Name = "gbUpd"
        Me.gbUpd.Size = New System.Drawing.Size(481, 73)
        Me.gbUpd.TabIndex = 396
        Me.gbUpd.TabStop = False
        '
        'optUpdE
        '
        Me.optUpdE.AutoSize = True
        Me.optUpdE.Enabled = False
        Me.optUpdE.Location = New System.Drawing.Point(321, 42)
        Me.optUpdE.Name = "optUpdE"
        Me.optUpdE.Size = New System.Drawing.Size(139, 17)
        Me.optUpdE.TabIndex = 5
        Me.optUpdE.Text = "E - Except Price Update"
        Me.optUpdE.UseVisualStyleBackColor = True
        Me.optUpdE.Visible = False
        '
        'optUpdN
        '
        Me.optUpdN.AutoSize = True
        Me.optUpdN.Location = New System.Drawing.Point(254, 30)
        Me.optUpdN.Name = "optUpdN"
        Me.optUpdN.Size = New System.Drawing.Size(94, 17)
        Me.optUpdN.TabIndex = 4
        Me.optUpdN.Text = "N - No Update"
        Me.optUpdN.UseVisualStyleBackColor = True
        '
        'optUpdA
        '
        Me.optUpdA.AutoSize = True
        Me.optUpdA.Checked = True
        Me.optUpdA.Location = New System.Drawing.Point(77, 30)
        Me.optUpdA.Name = "optUpdA"
        Me.optUpdA.Size = New System.Drawing.Size(114, 17)
        Me.optUpdA.TabIndex = 3
        Me.optUpdA.TabStop = True
        Me.optUpdA.Text = "Y - Update All Info "
        Me.optUpdA.UseVisualStyleBackColor = True
        '
        'optUpdC
        '
        Me.optUpdC.AutoSize = True
        Me.optUpdC.Enabled = False
        Me.optUpdC.Location = New System.Drawing.Point(29, 56)
        Me.optUpdC.Name = "optUpdC"
        Me.optUpdC.Size = New System.Drawing.Size(177, 17)
        Me.optUpdC.TabIndex = 2
        Me.optUpdC.Text = "C - Except Cost Element Update"
        Me.optUpdC.UseVisualStyleBackColor = True
        Me.optUpdC.Visible = False
        '
        'optUpdI
        '
        Me.optUpdI.AutoSize = True
        Me.optUpdI.Enabled = False
        Me.optUpdI.Location = New System.Drawing.Point(42, 48)
        Me.optUpdI.Name = "optUpdI"
        Me.optUpdI.Size = New System.Drawing.Size(88, 17)
        Me.optUpdI.TabIndex = 1
        Me.optUpdI.Text = "I - Item# Only"
        Me.optUpdI.UseVisualStyleBackColor = True
        Me.optUpdI.Visible = False
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUpdate.Location = New System.Drawing.Point(572, 316)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(81, 34)
        Me.cmdUpdate.TabIndex = 9
        Me.cmdUpdate.Text = "Update"
        '
        'cmdcancel
        '
        Me.cmdcancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.Location = New System.Drawing.Point(659, 316)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(81, 34)
        Me.cmdcancel.TabIndex = 10
        Me.cmdcancel.Text = "Exit"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(519, 286)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 401
        Me.Label1.Text = "From"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(598, 286)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 13)
        Me.Label2.TabIndex = 402
        Me.Label2.Text = "To"
        '
        'txtFm
        '
        Me.txtFm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFm.Location = New System.Drawing.Point(555, 283)
        Me.txtFm.MaxLength = 4
        Me.txtFm.Name = "txtFm"
        Me.txtFm.Size = New System.Drawing.Size(37, 20)
        Me.txtFm.TabIndex = 6
        '
        'txtTo
        '
        Me.txtTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtTo.Location = New System.Drawing.Point(624, 283)
        Me.txtTo.MaxLength = 4
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Size = New System.Drawing.Size(37, 20)
        Me.txtTo.TabIndex = 7
        '
        'cmdApply
        '
        Me.cmdApply.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdApply.Location = New System.Drawing.Point(667, 282)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.Size = New System.Drawing.Size(73, 21)
        Me.cmdApply.TabIndex = 8
        Me.cmdApply.Text = "Apply"
        '
        'txtMsg
        '
        Me.txtMsg.Location = New System.Drawing.Point(13, 356)
        Me.txtMsg.MaxLength = 0
        Me.txtMsg.Name = "txtMsg"
        Me.txtMsg.ReadOnly = True
        Me.txtMsg.Size = New System.Drawing.Size(727, 52)
        Me.txtMsg.TabIndex = 406
        Me.txtMsg.Text = ""
        '
        'frmQutUpdItm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(752, 420)
        Me.Controls.Add(Me.txtMsg)
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.txtTo)
        Me.Controls.Add(Me.txtFm)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdcancel)
        Me.Controls.Add(Me.cmdUpdate)
        Me.Controls.Add(Me.gbUpd)
        Me.Controls.Add(Me.dgResult)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmQutUpdItm"
        Me.Text = "Update Item"
        CType(Me.dgResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbUpd.ResumeLayout(False)
        Me.gbUpd.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgResult As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents gbUpd As System.Windows.Forms.GroupBox
    Friend WithEvents optUpdE As System.Windows.Forms.RadioButton
    Friend WithEvents optUpdN As System.Windows.Forms.RadioButton
    Friend WithEvents optUpdA As System.Windows.Forms.RadioButton
    Friend WithEvents optUpdC As System.Windows.Forms.RadioButton
    Friend WithEvents optUpdI As System.Windows.Forms.RadioButton
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFm As System.Windows.Forms.TextBox
    Friend WithEvents txtTo As System.Windows.Forms.TextBox
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents txtMsg As System.Windows.Forms.RichTextBox
End Class
