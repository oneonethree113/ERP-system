<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QUM00004
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
        Me.gbSelection = New System.Windows.Forms.GroupBox
        Me.btnClear = New System.Windows.Forms.Button
        Me.btnLoad = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboSecCust = New System.Windows.Forms.ComboBox
        Me.lblSecCust = New System.Windows.Forms.Label
        Me.txtDateTo = New System.Windows.Forms.MaskedTextBox
        Me.lblDateTo = New System.Windows.Forms.Label
        Me.txtDateFrom = New System.Windows.Forms.MaskedTextBox
        Me.lblDateFrom = New System.Windows.Forms.Label
        Me.lblSessionDate = New System.Windows.Forms.Label
        Me.txtTmpQutNo = New System.Windows.Forms.TextBox
        Me.lblTmpQutNo = New System.Windows.Forms.Label
        Me.cboPriCust = New System.Windows.Forms.ComboBox
        Me.lblPriCust = New System.Windows.Forms.Label
        Me.gbPDA = New System.Windows.Forms.GroupBox
        Me.btcPDA = New ERPSystem.BaseTabControl
        Me.tpQUM00004_1 = New System.Windows.Forms.TabPage
        Me.dgTempQ = New System.Windows.Forms.DataGridView
        Me.tpQUM00004_2 = New System.Windows.Forms.TabPage
        Me.dgTempAss = New System.Windows.Forms.DataGridView
        Me.tpQUM00004_3 = New System.Windows.Forms.TabPage
        Me.dgResult = New System.Windows.Forms.DataGridView
        Me.btnUpload = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.lblProgress = New System.Windows.Forms.Label
        Me.gbSelection.SuspendLayout()
        Me.gbPDA.SuspendLayout()
        Me.btcPDA.SuspendLayout()
        Me.tpQUM00004_1.SuspendLayout()
        CType(Me.dgTempQ, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpQUM00004_2.SuspendLayout()
        CType(Me.dgTempAss, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpQUM00004_3.SuspendLayout()
        CType(Me.dgResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbSelection
        '
        Me.gbSelection.Controls.Add(Me.btnClear)
        Me.gbSelection.Controls.Add(Me.btnLoad)
        Me.gbSelection.Controls.Add(Me.Label5)
        Me.gbSelection.Controls.Add(Me.cboSecCust)
        Me.gbSelection.Controls.Add(Me.lblSecCust)
        Me.gbSelection.Controls.Add(Me.txtDateTo)
        Me.gbSelection.Controls.Add(Me.lblDateTo)
        Me.gbSelection.Controls.Add(Me.txtDateFrom)
        Me.gbSelection.Controls.Add(Me.lblDateFrom)
        Me.gbSelection.Controls.Add(Me.lblSessionDate)
        Me.gbSelection.Controls.Add(Me.txtTmpQutNo)
        Me.gbSelection.Controls.Add(Me.lblTmpQutNo)
        Me.gbSelection.Controls.Add(Me.cboPriCust)
        Me.gbSelection.Controls.Add(Me.lblPriCust)
        Me.gbSelection.Location = New System.Drawing.Point(12, 12)
        Me.gbSelection.Name = "gbSelection"
        Me.gbSelection.Size = New System.Drawing.Size(665, 110)
        Me.gbSelection.TabIndex = 0
        Me.gbSelection.TabStop = False
        Me.gbSelection.Text = "Selection Criteria"
        '
        'btnClear
        '
        Me.btnClear.Enabled = False
        Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.Location = New System.Drawing.Point(586, 76)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(73, 21)
        Me.btnClear.TabIndex = 7
        Me.btnClear.Text = "Clear"
        '
        'btnLoad
        '
        Me.btnLoad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoad.Location = New System.Drawing.Point(507, 76)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(73, 21)
        Me.btnLoad.TabIndex = 6
        Me.btnLoad.Text = "Load"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(408, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 13)
        Me.Label5.TabIndex = 572
        Me.Label5.Text = "(MM/DD/YYYY)"
        '
        'cboSecCust
        '
        Me.cboSecCust.FormattingEnabled = True
        Me.cboSecCust.Location = New System.Drawing.Point(403, 47)
        Me.cboSecCust.Name = "cboSecCust"
        Me.cboSecCust.Size = New System.Drawing.Size(160, 21)
        Me.cboSecCust.TabIndex = 3
        '
        'lblSecCust
        '
        Me.lblSecCust.AutoSize = True
        Me.lblSecCust.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSecCust.Location = New System.Drawing.Point(290, 50)
        Me.lblSecCust.Name = "lblSecCust"
        Me.lblSecCust.Size = New System.Drawing.Size(105, 13)
        Me.lblSecCust.TabIndex = 571
        Me.lblSecCust.Text = "Secondary Customer"
        '
        'txtDateTo
        '
        Me.txtDateTo.Location = New System.Drawing.Point(322, 77)
        Me.txtDateTo.Mask = "00/00/0000"
        Me.txtDateTo.Name = "txtDateTo"
        Me.txtDateTo.Size = New System.Drawing.Size(80, 20)
        Me.txtDateTo.TabIndex = 5
        '
        'lblDateTo
        '
        Me.lblDateTo.AutoSize = True
        Me.lblDateTo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDateTo.Location = New System.Drawing.Point(290, 80)
        Me.lblDateTo.Name = "lblDateTo"
        Me.lblDateTo.Size = New System.Drawing.Size(26, 13)
        Me.lblDateTo.TabIndex = 568
        Me.lblDateTo.Text = "To :"
        '
        'txtDateFrom
        '
        Me.txtDateFrom.Location = New System.Drawing.Point(163, 77)
        Me.txtDateFrom.Mask = "00/00/0000"
        Me.txtDateFrom.Name = "txtDateFrom"
        Me.txtDateFrom.Size = New System.Drawing.Size(80, 20)
        Me.txtDateFrom.TabIndex = 4
        '
        'lblDateFrom
        '
        Me.lblDateFrom.AutoSize = True
        Me.lblDateFrom.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDateFrom.Location = New System.Drawing.Point(121, 80)
        Me.lblDateFrom.Name = "lblDateFrom"
        Me.lblDateFrom.Size = New System.Drawing.Size(36, 13)
        Me.lblDateFrom.TabIndex = 264
        Me.lblDateFrom.Text = "From :"
        '
        'lblSessionDate
        '
        Me.lblSessionDate.AutoSize = True
        Me.lblSessionDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSessionDate.Location = New System.Drawing.Point(11, 80)
        Me.lblSessionDate.Name = "lblSessionDate"
        Me.lblSessionDate.Size = New System.Drawing.Size(104, 13)
        Me.lblSessionDate.TabIndex = 262
        Me.lblSessionDate.Text = "Session Create Date"
        '
        'txtTmpQutNo
        '
        Me.txtTmpQutNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtTmpQutNo.Location = New System.Drawing.Point(124, 18)
        Me.txtTmpQutNo.MaxLength = 10
        Me.txtTmpQutNo.Name = "txtTmpQutNo"
        Me.txtTmpQutNo.Size = New System.Drawing.Size(160, 20)
        Me.txtTmpQutNo.TabIndex = 1
        '
        'lblTmpQutNo
        '
        Me.lblTmpQutNo.AutoSize = True
        Me.lblTmpQutNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblTmpQutNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTmpQutNo.Location = New System.Drawing.Point(11, 21)
        Me.lblTmpQutNo.Name = "lblTmpQutNo"
        Me.lblTmpQutNo.Size = New System.Drawing.Size(80, 13)
        Me.lblTmpQutNo.TabIndex = 261
        Me.lblTmpQutNo.Text = "Temp. Qut. No."
        '
        'cboPriCust
        '
        Me.cboPriCust.FormattingEnabled = True
        Me.cboPriCust.Location = New System.Drawing.Point(124, 47)
        Me.cboPriCust.Name = "cboPriCust"
        Me.cboPriCust.Size = New System.Drawing.Size(160, 21)
        Me.cboPriCust.TabIndex = 2
        '
        'lblPriCust
        '
        Me.lblPriCust.AutoSize = True
        Me.lblPriCust.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPriCust.Location = New System.Drawing.Point(11, 50)
        Me.lblPriCust.Name = "lblPriCust"
        Me.lblPriCust.Size = New System.Drawing.Size(88, 13)
        Me.lblPriCust.TabIndex = 105
        Me.lblPriCust.Text = "Primary Customer"
        '
        'gbPDA
        '
        Me.gbPDA.Controls.Add(Me.btcPDA)
        Me.gbPDA.Location = New System.Drawing.Point(12, 128)
        Me.gbPDA.Name = "gbPDA"
        Me.gbPDA.Size = New System.Drawing.Size(665, 275)
        Me.gbPDA.TabIndex = 1
        Me.gbPDA.TabStop = False
        Me.gbPDA.Text = "Quotation From PDA"
        '
        'btcPDA
        '
        Me.btcPDA.Controls.Add(Me.tpQUM00004_1)
        Me.btcPDA.Controls.Add(Me.tpQUM00004_2)
        Me.btcPDA.Controls.Add(Me.tpQUM00004_3)
        Me.btcPDA.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.btcPDA.Location = New System.Drawing.Point(6, 20)
        Me.btcPDA.Name = "btcPDA"
        Me.btcPDA.SelectedIndex = 0
        Me.btcPDA.Size = New System.Drawing.Size(653, 249)
        Me.btcPDA.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.btcPDA.TabIndex = 0
        '
        'tpQUM00004_1
        '
        Me.tpQUM00004_1.Controls.Add(Me.dgTempQ)
        Me.tpQUM00004_1.Location = New System.Drawing.Point(4, 22)
        Me.tpQUM00004_1.Name = "tpQUM00004_1"
        Me.tpQUM00004_1.Padding = New System.Windows.Forms.Padding(3)
        Me.tpQUM00004_1.Size = New System.Drawing.Size(645, 223)
        Me.tpQUM00004_1.TabIndex = 0
        Me.tpQUM00004_1.Text = "Quoted Items"
        Me.tpQUM00004_1.UseVisualStyleBackColor = True
        '
        'dgTempQ
        '
        Me.dgTempQ.AllowUserToAddRows = False
        Me.dgTempQ.AllowUserToDeleteRows = False
        Me.dgTempQ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgTempQ.Location = New System.Drawing.Point(3, 3)
        Me.dgTempQ.Name = "dgTempQ"
        Me.dgTempQ.RowHeadersWidth = 20
        Me.dgTempQ.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.dgTempQ.RowTemplate.Height = 16
        Me.dgTempQ.Size = New System.Drawing.Size(639, 217)
        Me.dgTempQ.TabIndex = 8
        '
        'tpQUM00004_2
        '
        Me.tpQUM00004_2.Controls.Add(Me.dgTempAss)
        Me.tpQUM00004_2.Location = New System.Drawing.Point(4, 22)
        Me.tpQUM00004_2.Name = "tpQUM00004_2"
        Me.tpQUM00004_2.Padding = New System.Windows.Forms.Padding(3)
        Me.tpQUM00004_2.Size = New System.Drawing.Size(645, 223)
        Me.tpQUM00004_2.TabIndex = 1
        Me.tpQUM00004_2.Text = "Assorted Items"
        Me.tpQUM00004_2.UseVisualStyleBackColor = True
        '
        'dgTempAss
        '
        Me.dgTempAss.AllowUserToAddRows = False
        Me.dgTempAss.AllowUserToDeleteRows = False
        Me.dgTempAss.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgTempAss.Location = New System.Drawing.Point(3, 3)
        Me.dgTempAss.Name = "dgTempAss"
        Me.dgTempAss.RowHeadersWidth = 20
        Me.dgTempAss.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.dgTempAss.RowTemplate.Height = 16
        Me.dgTempAss.Size = New System.Drawing.Size(639, 217)
        Me.dgTempAss.TabIndex = 9
        '
        'tpQUM00004_3
        '
        Me.tpQUM00004_3.Controls.Add(Me.dgResult)
        Me.tpQUM00004_3.Location = New System.Drawing.Point(4, 22)
        Me.tpQUM00004_3.Name = "tpQUM00004_3"
        Me.tpQUM00004_3.Padding = New System.Windows.Forms.Padding(3)
        Me.tpQUM00004_3.Size = New System.Drawing.Size(645, 223)
        Me.tpQUM00004_3.TabIndex = 2
        Me.tpQUM00004_3.Text = "Result"
        Me.tpQUM00004_3.UseVisualStyleBackColor = True
        '
        'dgResult
        '
        Me.dgResult.AllowUserToAddRows = False
        Me.dgResult.AllowUserToDeleteRows = False
        Me.dgResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgResult.Location = New System.Drawing.Point(3, 3)
        Me.dgResult.Name = "dgResult"
        Me.dgResult.RowHeadersWidth = 20
        Me.dgResult.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.dgResult.RowTemplate.Height = 16
        Me.dgResult.Size = New System.Drawing.Size(639, 217)
        Me.dgResult.TabIndex = 10
        '
        'btnUpload
        '
        Me.btnUpload.Enabled = False
        Me.btnUpload.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpload.Location = New System.Drawing.Point(503, 409)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(81, 34)
        Me.btnUpload.TabIndex = 11
        Me.btnUpload.TabStop = False
        Me.btnUpload.Text = "Upload"
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(590, 409)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(81, 34)
        Me.btnExit.TabIndex = 12
        Me.btnExit.TabStop = False
        Me.btnExit.Text = "Exit"
        '
        'lblProgress
        '
        Me.lblProgress.AutoSize = True
        Me.lblProgress.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblProgress.Location = New System.Drawing.Point(325, 420)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(0, 13)
        Me.lblProgress.TabIndex = 263
        '
        'QUM00004
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(691, 453)
        Me.Controls.Add(Me.lblProgress)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnUpload)
        Me.Controls.Add(Me.gbPDA)
        Me.Controls.Add(Me.gbSelection)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "QUM00004"
        Me.Text = "Upload Quotation Approve / Reject"
        Me.gbSelection.ResumeLayout(False)
        Me.gbSelection.PerformLayout()
        Me.gbPDA.ResumeLayout(False)
        Me.btcPDA.ResumeLayout(False)
        Me.tpQUM00004_1.ResumeLayout(False)
        CType(Me.dgTempQ, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpQUM00004_2.ResumeLayout(False)
        CType(Me.dgTempAss, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpQUM00004_3.ResumeLayout(False)
        CType(Me.dgResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbSelection As System.Windows.Forms.GroupBox
    Friend WithEvents cboPriCust As System.Windows.Forms.ComboBox
    Friend WithEvents lblPriCust As System.Windows.Forms.Label
    Friend WithEvents lblDateFrom As System.Windows.Forms.Label
    Friend WithEvents lblSessionDate As System.Windows.Forms.Label
    Friend WithEvents txtTmpQutNo As System.Windows.Forms.TextBox
    Friend WithEvents lblTmpQutNo As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboSecCust As System.Windows.Forms.ComboBox
    Friend WithEvents lblSecCust As System.Windows.Forms.Label
    Friend WithEvents txtDateTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblDateTo As System.Windows.Forms.Label
    Friend WithEvents txtDateFrom As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents gbPDA As System.Windows.Forms.GroupBox
    Friend WithEvents btcPDA As ERPSystem.BaseTabControl
    Friend WithEvents tpQUM00004_1 As System.Windows.Forms.TabPage
    Friend WithEvents tpQUM00004_2 As System.Windows.Forms.TabPage
    Friend WithEvents tpQUM00004_3 As System.Windows.Forms.TabPage
    Friend WithEvents btnUpload As System.Windows.Forms.Button
    Friend WithEvents dgTempQ As System.Windows.Forms.DataGridView
    Friend WithEvents dgTempAss As System.Windows.Forms.DataGridView
    Friend WithEvents dgResult As System.Windows.Forms.DataGridView
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents lblProgress As System.Windows.Forms.Label
End Class
