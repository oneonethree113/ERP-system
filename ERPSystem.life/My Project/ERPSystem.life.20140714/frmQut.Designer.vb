<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQut
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
        Me.cmdNo = New System.Windows.Forms.Button
        Me.cmdYes = New System.Windows.Forms.Button
        Me.PBar = New System.Windows.Forms.ProgressBar
        Me.lblCopy = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgValid = New System.Windows.Forms.DataGridView
        Me.dgInvalid = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblNotCopy = New System.Windows.Forms.Label
        Me.txtQutNo2 = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        CType(Me.dgValid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgInvalid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdNo
        '
        Me.cmdNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNo.Location = New System.Drawing.Point(659, 12)
        Me.cmdNo.Name = "cmdNo"
        Me.cmdNo.Size = New System.Drawing.Size(81, 34)
        Me.cmdNo.TabIndex = 2
        Me.cmdNo.Text = "Cancel"
        '
        'cmdYes
        '
        Me.cmdYes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdYes.Location = New System.Drawing.Point(572, 12)
        Me.cmdYes.Name = "cmdYes"
        Me.cmdYes.Size = New System.Drawing.Size(81, 34)
        Me.cmdYes.TabIndex = 1
        Me.cmdYes.Text = "Copy"
        '
        'PBar
        '
        Me.PBar.Location = New System.Drawing.Point(13, 52)
        Me.PBar.Name = "PBar"
        Me.PBar.Size = New System.Drawing.Size(727, 12)
        Me.PBar.TabIndex = 5
        '
        'lblCopy
        '
        Me.lblCopy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblCopy.Location = New System.Drawing.Point(12, 70)
        Me.lblCopy.Name = "lblCopy"
        Me.lblCopy.Size = New System.Drawing.Size(60, 13)
        Me.lblCopy.TabIndex = 416
        Me.lblCopy.Text = "0 of 0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(78, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 417
        Me.Label1.Text = "Items to be copied :"
        '
        'dgValid
        '
        Me.dgValid.AllowUserToAddRows = False
        Me.dgValid.AllowUserToDeleteRows = False
        Me.dgValid.ColumnHeadersHeight = 20
        Me.dgValid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgValid.Location = New System.Drawing.Point(12, 89)
        Me.dgValid.Name = "dgValid"
        Me.dgValid.RowHeadersWidth = 20
        Me.dgValid.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.dgValid.RowTemplate.Height = 16
        Me.dgValid.Size = New System.Drawing.Size(728, 160)
        Me.dgValid.TabIndex = 3
        '
        'dgInvalid
        '
        Me.dgInvalid.AllowUserToAddRows = False
        Me.dgInvalid.AllowUserToDeleteRows = False
        Me.dgInvalid.ColumnHeadersHeight = 20
        Me.dgInvalid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgInvalid.Location = New System.Drawing.Point(12, 274)
        Me.dgInvalid.Name = "dgInvalid"
        Me.dgInvalid.RowHeadersWidth = 20
        Me.dgInvalid.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.dgInvalid.RowTemplate.Height = 16
        Me.dgInvalid.Size = New System.Drawing.Size(728, 160)
        Me.dgInvalid.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(78, 255)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 13)
        Me.Label2.TabIndex = 421
        Me.Label2.Text = "Items cannot be copied :"
        '
        'lblNotCopy
        '
        Me.lblNotCopy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblNotCopy.Location = New System.Drawing.Point(12, 255)
        Me.lblNotCopy.Name = "lblNotCopy"
        Me.lblNotCopy.Size = New System.Drawing.Size(60, 13)
        Me.lblNotCopy.TabIndex = 420
        Me.lblNotCopy.Text = "0 of 0"
        '
        'txtQutNo2
        '
        Me.txtQutNo2.Enabled = False
        Me.txtQutNo2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtQutNo2.Location = New System.Drawing.Point(340, 12)
        Me.txtQutNo2.MaxLength = 10
        Me.txtQutNo2.Name = "txtQutNo2"
        Me.txtQutNo2.Size = New System.Drawing.Size(104, 20)
        Me.txtQutNo2.TabIndex = 423
        Me.txtQutNo2.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(225, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(109, 13)
        Me.Label7.TabIndex = 424
        Me.Label7.Text = "Cory to Quotation No:"
        Me.Label7.Visible = False
        '
        'frmQut
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(752, 446)
        Me.Controls.Add(Me.txtQutNo2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblNotCopy)
        Me.Controls.Add(Me.dgInvalid)
        Me.Controls.Add(Me.dgValid)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblCopy)
        Me.Controls.Add(Me.PBar)
        Me.Controls.Add(Me.cmdNo)
        Me.Controls.Add(Me.cmdYes)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmQut"
        Me.Text = "Copy Quotation"
        CType(Me.dgValid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgInvalid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdNo As System.Windows.Forms.Button
    Friend WithEvents cmdYes As System.Windows.Forms.Button
    Friend WithEvents PBar As System.Windows.Forms.ProgressBar
    Friend WithEvents lblCopy As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgValid As System.Windows.Forms.DataGridView
    Friend WithEvents dgInvalid As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblNotCopy As System.Windows.Forms.Label
    Friend WithEvents txtQutNo2 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
