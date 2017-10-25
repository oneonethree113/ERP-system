<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class COR00001
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(COR00001))
        Me.cboTable = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.grdValue = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtDateFrom = New System.Windows.Forms.MaskedTextBox
        Me.txtDateTo = New System.Windows.Forms.MaskedTextBox
        Me.cmdShow = New System.Windows.Forms.Button
        Me.CmdExit = New System.Windows.Forms.Button
        Me.txtSQL = New System.Windows.Forms.TextBox
        CType(Me.grdValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboTable
        '
        Me.cboTable.FormattingEnabled = True
        Me.cboTable.Location = New System.Drawing.Point(119, 17)
        Me.cboTable.Name = "cboTable"
        Me.cboTable.Size = New System.Drawing.Size(810, 20)
        Me.cboTable.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Table Name"
        '
        'grdValue
        '
        Me.grdValue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdValue.Location = New System.Drawing.Point(38, 51)
        Me.grdValue.Name = "grdValue"
        Me.grdValue.RowTemplate.Height = 24
        Me.grdValue.Size = New System.Drawing.Size(891, 243)
        Me.grdValue.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(37, 317)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Date Range"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(226, 317)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(18, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "To"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(370, 316)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 12)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "(MM/DD/YYYY)"
        '
        'txtDateFrom
        '
        Me.txtDateFrom.Location = New System.Drawing.Point(110, 314)
        Me.txtDateFrom.Mask = "##/##/####"
        Me.txtDateFrom.Name = "txtDateFrom"
        Me.txtDateFrom.Size = New System.Drawing.Size(100, 22)
        Me.txtDateFrom.TabIndex = 2
        '
        'txtDateTo
        '
        Me.txtDateTo.Location = New System.Drawing.Point(260, 313)
        Me.txtDateTo.Mask = "##/##/####"
        Me.txtDateTo.Name = "txtDateTo"
        Me.txtDateTo.Size = New System.Drawing.Size(100, 22)
        Me.txtDateTo.TabIndex = 3
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(355, 362)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(75, 21)
        Me.cmdShow.TabIndex = 4
        Me.cmdShow.Text = "Export"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'CmdExit
        '
        Me.CmdExit.Location = New System.Drawing.Point(509, 362)
        Me.CmdExit.Name = "CmdExit"
        Me.CmdExit.Size = New System.Drawing.Size(75, 21)
        Me.CmdExit.TabIndex = 5
        Me.CmdExit.Text = "Exit"
        Me.CmdExit.UseVisualStyleBackColor = True
        '
        'txtSQL
        '
        Me.txtSQL.Location = New System.Drawing.Point(755, 307)
        Me.txtSQL.Name = "txtSQL"
        Me.txtSQL.Size = New System.Drawing.Size(100, 22)
        Me.txtSQL.TabIndex = 10
        Me.txtSQL.Visible = False
        '
        'COR00001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(954, 423)
        Me.Controls.Add(Me.txtSQL)
        Me.Controls.Add(Me.CmdExit)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.txtDateTo)
        Me.Controls.Add(Me.txtDateFrom)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.grdValue)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboTable)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "COR00001"
        Me.Text = "COR00001 - Audit Trial Report (COR01)"
        CType(Me.grdValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboTable As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grdValue As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDateFrom As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDateTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents CmdExit As System.Windows.Forms.Button
    Friend WithEvents txtSQL As System.Windows.Forms.TextBox
End Class
