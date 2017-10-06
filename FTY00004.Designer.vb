<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FTY00004
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
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtBatNoFm = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtJobOrdFm = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtJobOrdTo = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtGenDatFm = New System.Windows.Forms.MaskedTextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtGenDatTo = New System.Windows.Forms.MaskedTextBox
        Me.cmdSearch = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.dgResults = New System.Windows.Forms.DataGridView
        Me.txtBatNoTo = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        CType(Me.dgResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboCoCde
        '
        Me.cboCoCde.BackColor = System.Drawing.Color.White
        Me.cboCoCde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(105, 11)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(81, 21)
        Me.cboCoCde.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Yellow
        Me.Label1.Location = New System.Drawing.Point(12, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Company Code"
        '
        'txtBatNoFm
        '
        Me.txtBatNoFm.BackColor = System.Drawing.Color.White
        Me.txtBatNoFm.Location = New System.Drawing.Point(105, 38)
        Me.txtBatNoFm.Name = "txtBatNoFm"
        Me.txtBatNoFm.Size = New System.Drawing.Size(110, 20)
        Me.txtBatNoFm.TabIndex = 3
        Me.txtBatNoFm.Text = "XX9999999"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Yellow
        Me.Label8.Location = New System.Drawing.Point(12, 41)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Batch Job No."
        '
        'txtJobOrdFm
        '
        Me.txtJobOrdFm.BackColor = System.Drawing.Color.White
        Me.txtJobOrdFm.Location = New System.Drawing.Point(105, 64)
        Me.txtJobOrdFm.Name = "txtJobOrdFm"
        Me.txtJobOrdFm.Size = New System.Drawing.Size(110, 20)
        Me.txtJobOrdFm.TabIndex = 7
        Me.txtJobOrdFm.Text = "XX9999999-J999"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(12, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Job Order No."
        '
        'txtJobOrdTo
        '
        Me.txtJobOrdTo.BackColor = System.Drawing.Color.White
        Me.txtJobOrdTo.Location = New System.Drawing.Point(243, 65)
        Me.txtJobOrdTo.Name = "txtJobOrdTo"
        Me.txtJobOrdTo.Size = New System.Drawing.Size(110, 20)
        Me.txtJobOrdTo.TabIndex = 9
        Me.txtJobOrdTo.Text = "XX9999999-J999"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Yellow
        Me.Label3.Location = New System.Drawing.Point(221, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(16, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "to"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Yellow
        Me.Label4.Location = New System.Drawing.Point(12, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Create Date"
        '
        'txtGenDatFm
        '
        Me.txtGenDatFm.BackColor = System.Drawing.Color.White
        Me.txtGenDatFm.Location = New System.Drawing.Point(105, 91)
        Me.txtGenDatFm.Mask = "00/00/0000"
        Me.txtGenDatFm.Name = "txtGenDatFm"
        Me.txtGenDatFm.Size = New System.Drawing.Size(110, 20)
        Me.txtGenDatFm.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Yellow
        Me.Label5.Location = New System.Drawing.Point(221, 94)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(16, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "to"
        '
        'txtGenDatTo
        '
        Me.txtGenDatTo.BackColor = System.Drawing.Color.White
        Me.txtGenDatTo.Location = New System.Drawing.Point(243, 91)
        Me.txtGenDatTo.Mask = "00/00/0000"
        Me.txtGenDatTo.Name = "txtGenDatTo"
        Me.txtGenDatTo.Size = New System.Drawing.Size(110, 20)
        Me.txtGenDatTo.TabIndex = 13
        '
        'cmdSearch
        '
        Me.cmdSearch.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSearch.Location = New System.Drawing.Point(278, 120)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(75, 23)
        Me.cmdSearch.TabIndex = 14
        Me.cmdSearch.Text = "&Search"
        Me.cmdSearch.UseVisualStyleBackColor = False
        '
        'cmdClear
        '
        Me.cmdClear.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClear.Location = New System.Drawing.Point(369, 120)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(75, 23)
        Me.cmdClear.TabIndex = 16
        Me.cmdClear.Text = "&Clear"
        Me.cmdClear.UseVisualStyleBackColor = False
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExit.Location = New System.Drawing.Point(450, 120)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(75, 23)
        Me.cmdExit.TabIndex = 17
        Me.cmdExit.Text = "&Exit"
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        'dgResults
        '
        Me.dgResults.AllowUserToAddRows = False
        Me.dgResults.AllowUserToDeleteRows = False
        Me.dgResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgResults.Location = New System.Drawing.Point(12, 149)
        Me.dgResults.Name = "dgResults"
        Me.dgResults.ReadOnly = True
        Me.dgResults.RowHeadersWidth = 20
        Me.dgResults.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgResults.RowTemplate.Height = 20
        Me.dgResults.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgResults.Size = New System.Drawing.Size(513, 319)
        Me.dgResults.TabIndex = 15
        '
        'txtBatNoTo
        '
        Me.txtBatNoTo.BackColor = System.Drawing.Color.White
        Me.txtBatNoTo.Location = New System.Drawing.Point(243, 38)
        Me.txtBatNoTo.Name = "txtBatNoTo"
        Me.txtBatNoTo.Size = New System.Drawing.Size(110, 20)
        Me.txtBatNoTo.TabIndex = 5
        Me.txtBatNoTo.Text = "XX9999999"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Yellow
        Me.Label6.Location = New System.Drawing.Point(221, 41)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(16, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "to"
        '
        'FTY00004
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Teal
        Me.ClientSize = New System.Drawing.Size(537, 485)
        Me.Controls.Add(Me.txtBatNoTo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dgResults)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.txtGenDatTo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtGenDatFm)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtJobOrdTo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtJobOrdFm)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtBatNoFm)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FTY00004"
        Me.Text = "FTY00004 - PDO Document History"
        CType(Me.dgResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBatNoFm As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtJobOrdFm As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtJobOrdTo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtGenDatFm As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtGenDatTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents dgResults As System.Windows.Forms.DataGridView
    Friend WithEvents txtBatNoTo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
