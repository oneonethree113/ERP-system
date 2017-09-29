<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCopySC
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
        Me.components = New System.ComponentModel.Container
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdCopy = New System.Windows.Forms.Button
        Me.pBar = New System.Windows.Forms.ProgressBar
        Me.lblCount = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.grdValid = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblFail = New System.Windows.Forms.Label
        Me.grdInvalid = New System.Windows.Forms.DataGridView
        Me.LoadTimer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.grdValid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdInvalid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(560, 13)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdCopy
        '
        Me.cmdCopy.Location = New System.Drawing.Point(479, 13)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(75, 23)
        Me.cmdCopy.TabIndex = 0
        Me.cmdCopy.Text = "Copy"
        Me.cmdCopy.UseVisualStyleBackColor = True
        '
        'pBar
        '
        Me.pBar.Location = New System.Drawing.Point(12, 42)
        Me.pBar.Name = "pBar"
        Me.pBar.Size = New System.Drawing.Size(623, 15)
        Me.pBar.TabIndex = 2
        '
        'lblCount
        '
        Me.lblCount.AutoSize = True
        Me.lblCount.Location = New System.Drawing.Point(13, 64)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(50, 13)
        Me.lblCount.TabIndex = 3
        Me.lblCount.Text = "XX of XX"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(70, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Successful Copied Items"
        '
        'grdValid
        '
        Me.grdValid.AllowUserToAddRows = False
        Me.grdValid.AllowUserToDeleteRows = False
        Me.grdValid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdValid.Location = New System.Drawing.Point(12, 81)
        Me.grdValid.Name = "grdValid"
        Me.grdValid.ReadOnly = True
        Me.grdValid.RowHeadersWidth = 20
        Me.grdValid.RowTemplate.Height = 17
        Me.grdValid.Size = New System.Drawing.Size(623, 150)
        Me.grdValid.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(70, 246)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Items Fail to Copy"
        '
        'lblFail
        '
        Me.lblFail.AutoSize = True
        Me.lblFail.Location = New System.Drawing.Point(13, 246)
        Me.lblFail.Name = "lblFail"
        Me.lblFail.Size = New System.Drawing.Size(50, 13)
        Me.lblFail.TabIndex = 6
        Me.lblFail.Text = "XX of XX"
        '
        'grdInvalid
        '
        Me.grdInvalid.AllowUserToAddRows = False
        Me.grdInvalid.AllowUserToDeleteRows = False
        Me.grdInvalid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdInvalid.Location = New System.Drawing.Point(12, 262)
        Me.grdInvalid.Name = "grdInvalid"
        Me.grdInvalid.ReadOnly = True
        Me.grdInvalid.RowHeadersWidth = 20
        Me.grdInvalid.RowTemplate.Height = 17
        Me.grdInvalid.Size = New System.Drawing.Size(623, 150)
        Me.grdInvalid.TabIndex = 8
        '
        'LoadTimer
        '
        Me.LoadTimer.Interval = 2000
        '
        'frmCopySC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(647, 427)
        Me.Controls.Add(Me.grdInvalid)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblFail)
        Me.Controls.Add(Me.grdValid)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.pBar)
        Me.Controls.Add(Me.cmdCopy)
        Me.Controls.Add(Me.cmdCancel)
        Me.Name = "frmCopySC"
        Me.Text = "Copy Sales Confirmation"
        CType(Me.grdValid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdInvalid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdCopy As System.Windows.Forms.Button
    Friend WithEvents pBar As System.Windows.Forms.ProgressBar
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grdValid As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblFail As System.Windows.Forms.Label
    Friend WithEvents grdInvalid As System.Windows.Forms.DataGridView
    Friend WithEvents LoadTimer As System.Windows.Forms.Timer
End Class
