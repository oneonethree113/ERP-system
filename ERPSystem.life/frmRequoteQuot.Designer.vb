<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRequoteQuot
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
        Me.txtMsg = New System.Windows.Forms.RichTextBox
        Me.cmdcancel = New System.Windows.Forms.Button
        Me.cmdUpdate = New System.Windows.Forms.Button
        Me.cmdApply = New System.Windows.Forms.Button
        Me.txtTo = New System.Windows.Forms.TextBox
        Me.txtFm = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.gbUpd = New System.Windows.Forms.GroupBox
        Me.optUpdN = New System.Windows.Forms.RadioButton
        Me.optUpdY = New System.Windows.Forms.RadioButton
        Me.Label3 = New System.Windows.Forms.Label
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
        Me.dgResult.Location = New System.Drawing.Point(11, 12)
        Me.dgResult.Name = "dgResult"
        Me.dgResult.RowHeadersWidth = 20
        Me.dgResult.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.dgResult.RowTemplate.Height = 16
        Me.dgResult.Size = New System.Drawing.Size(945, 259)
        Me.dgResult.TabIndex = 396
        '
        'txtMsg
        '
        Me.txtMsg.Location = New System.Drawing.Point(13, 322)
        Me.txtMsg.MaxLength = 0
        Me.txtMsg.Name = "txtMsg"
        Me.txtMsg.ReadOnly = True
        Me.txtMsg.Size = New System.Drawing.Size(943, 52)
        Me.txtMsg.TabIndex = 423
        Me.txtMsg.Text = ""
        '
        'cmdcancel
        '
        Me.cmdcancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.Location = New System.Drawing.Point(870, 282)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(81, 34)
        Me.cmdcancel.TabIndex = 419
        Me.cmdcancel.Text = "Exit"
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUpdate.Location = New System.Drawing.Point(783, 282)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(81, 34)
        Me.cmdUpdate.TabIndex = 418
        Me.cmdUpdate.Text = "Update"
        '
        'cmdApply
        '
        Me.cmdApply.Enabled = False
        Me.cmdApply.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdApply.Location = New System.Drawing.Point(322, 289)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.Size = New System.Drawing.Size(73, 21)
        Me.cmdApply.TabIndex = 417
        Me.cmdApply.Text = "Apply"
        '
        'txtTo
        '
        Me.txtTo.Enabled = False
        Me.txtTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtTo.Location = New System.Drawing.Point(279, 290)
        Me.txtTo.MaxLength = 4
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Size = New System.Drawing.Size(37, 20)
        Me.txtTo.TabIndex = 416
        '
        'txtFm
        '
        Me.txtFm.Enabled = False
        Me.txtFm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFm.Location = New System.Drawing.Point(210, 290)
        Me.txtFm.MaxLength = 4
        Me.txtFm.Name = "txtFm"
        Me.txtFm.Size = New System.Drawing.Size(37, 20)
        Me.txtFm.TabIndex = 415
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Enabled = False
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(253, 293)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 13)
        Me.Label2.TabIndex = 422
        Me.Label2.Text = "To"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Enabled = False
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(174, 293)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 421
        Me.Label1.Text = "From"
        '
        'gbUpd
        '
        Me.gbUpd.Controls.Add(Me.optUpdN)
        Me.gbUpd.Controls.Add(Me.optUpdY)
        Me.gbUpd.Controls.Add(Me.Label3)
        Me.gbUpd.Enabled = False
        Me.gbUpd.Location = New System.Drawing.Point(12, 277)
        Me.gbUpd.Name = "gbUpd"
        Me.gbUpd.Size = New System.Drawing.Size(156, 40)
        Me.gbUpd.TabIndex = 420
        Me.gbUpd.TabStop = False
        '
        'optUpdN
        '
        Me.optUpdN.AutoSize = True
        Me.optUpdN.Location = New System.Drawing.Point(109, 14)
        Me.optUpdN.Name = "optUpdN"
        Me.optUpdN.Size = New System.Drawing.Size(39, 17)
        Me.optUpdN.TabIndex = 2
        Me.optUpdN.Text = "No"
        Me.optUpdN.UseVisualStyleBackColor = True
        '
        'optUpdY
        '
        Me.optUpdY.AutoSize = True
        Me.optUpdY.Checked = True
        Me.optUpdY.Location = New System.Drawing.Point(60, 14)
        Me.optUpdY.Name = "optUpdY"
        Me.optUpdY.Size = New System.Drawing.Size(43, 17)
        Me.optUpdY.TabIndex = 1
        Me.optUpdY.TabStop = True
        Me.optUpdY.Text = "Yes"
        Me.optUpdY.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label3.Location = New System.Drawing.Point(6, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 395
        Me.Label3.Text = "Update :"
        '
        'frmRequoteQuot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(968, 386)
        Me.Controls.Add(Me.txtMsg)
        Me.Controls.Add(Me.cmdcancel)
        Me.Controls.Add(Me.cmdUpdate)
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.txtTo)
        Me.Controls.Add(Me.txtFm)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gbUpd)
        Me.Controls.Add(Me.dgResult)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(976, 420)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(976, 420)
        Me.Name = "frmRequoteQuot"
        Me.Text = "frmRequoteQuot"
        CType(Me.dgResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbUpd.ResumeLayout(False)
        Me.gbUpd.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgResult As System.Windows.Forms.DataGridView
    Friend WithEvents txtMsg As System.Windows.Forms.RichTextBox
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents txtTo As System.Windows.Forms.TextBox
    Friend WithEvents txtFm As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gbUpd As System.Windows.Forms.GroupBox
    Friend WithEvents optUpdN As System.Windows.Forms.RadioButton
    Friend WithEvents optUpdY As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
