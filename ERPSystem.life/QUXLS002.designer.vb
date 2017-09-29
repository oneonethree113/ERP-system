<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QUXLS002
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
        Me.btcQUXLS002 = New ERPSystem.BaseTabControl
        Me.tpQUXLS002_1 = New System.Windows.Forms.TabPage
        Me.cboSalDiv = New System.Windows.Forms.ComboBox
        Me.lblSalDiv = New System.Windows.Forms.Label
        Me.cboCus1No = New System.Windows.Forms.ComboBox
        Me.lblCus1No = New System.Windows.Forms.Label
        Me.lblCoNam = New System.Windows.Forms.Label
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.gbStatus = New System.Windows.Forms.GroupBox
        Me.optStatusB = New System.Windows.Forms.RadioButton
        Me.optStatusE = New System.Windows.Forms.RadioButton
        Me.optStatusI = New System.Windows.Forms.RadioButton
        Me.txtProcess = New System.Windows.Forms.TextBox
        Me.cmdOK = New System.Windows.Forms.Button
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dirSource = New System.Windows.Forms.TreeView
        Me.drvSource = New System.Windows.Forms.ComboBox
        Me.btcQUXLS002.SuspendLayout()
        Me.tpQUXLS002_1.SuspendLayout()
        Me.gbStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'btcQUXLS002
        '
        Me.btcQUXLS002.Controls.Add(Me.tpQUXLS002_1)
        Me.btcQUXLS002.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.btcQUXLS002.ItemSize = New System.Drawing.Size(110, 18)
        Me.btcQUXLS002.Location = New System.Drawing.Point(-1, 1)
        Me.btcQUXLS002.Name = "btcQUXLS002"
        Me.btcQUXLS002.SelectedIndex = 0
        Me.btcQUXLS002.Size = New System.Drawing.Size(929, 615)
        Me.btcQUXLS002.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.btcQUXLS002.TabIndex = 1
        '
        'tpQUXLS002_1
        '
        Me.tpQUXLS002_1.Controls.Add(Me.cboSalDiv)
        Me.tpQUXLS002_1.Controls.Add(Me.lblSalDiv)
        Me.tpQUXLS002_1.Controls.Add(Me.cboCus1No)
        Me.tpQUXLS002_1.Controls.Add(Me.lblCus1No)
        Me.tpQUXLS002_1.Controls.Add(Me.lblCoNam)
        Me.tpQUXLS002_1.Controls.Add(Me.cboCoCde)
        Me.tpQUXLS002_1.Controls.Add(Me.txtCoNam)
        Me.tpQUXLS002_1.Controls.Add(Me.Label6)
        Me.tpQUXLS002_1.Controls.Add(Me.gbStatus)
        Me.tpQUXLS002_1.Controls.Add(Me.txtProcess)
        Me.tpQUXLS002_1.Controls.Add(Me.cmdOK)
        Me.tpQUXLS002_1.Controls.Add(Me.cmdRefresh)
        Me.tpQUXLS002_1.Controls.Add(Me.Label3)
        Me.tpQUXLS002_1.Controls.Add(Me.Label1)
        Me.tpQUXLS002_1.Controls.Add(Me.dirSource)
        Me.tpQUXLS002_1.Controls.Add(Me.drvSource)
        Me.tpQUXLS002_1.Location = New System.Drawing.Point(4, 22)
        Me.tpQUXLS002_1.Name = "tpQUXLS002_1"
        Me.tpQUXLS002_1.Padding = New System.Windows.Forms.Padding(3)
        Me.tpQUXLS002_1.Size = New System.Drawing.Size(921, 589)
        Me.tpQUXLS002_1.TabIndex = 0
        Me.tpQUXLS002_1.Text = "(1) Excel"
        Me.tpQUXLS002_1.UseVisualStyleBackColor = True
        '
        'cboSalDiv
        '
        Me.cboSalDiv.FormattingEnabled = True
        Me.cboSalDiv.Location = New System.Drawing.Point(185, 75)
        Me.cboSalDiv.Name = "cboSalDiv"
        Me.cboSalDiv.Size = New System.Drawing.Size(250, 21)
        Me.cboSalDiv.TabIndex = 431
        '
        'lblSalDiv
        '
        Me.lblSalDiv.AutoSize = True
        Me.lblSalDiv.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblSalDiv.Location = New System.Drawing.Point(67, 78)
        Me.lblSalDiv.Name = "lblSalDiv"
        Me.lblSalDiv.Size = New System.Drawing.Size(109, 13)
        Me.lblSalDiv.TabIndex = 432
        Me.lblSalDiv.Text = "Sales Division (Team)"
        '
        'cboCus1No
        '
        Me.cboCus1No.FormattingEnabled = True
        Me.cboCus1No.Location = New System.Drawing.Point(185, 108)
        Me.cboCus1No.Name = "cboCus1No"
        Me.cboCus1No.Size = New System.Drawing.Size(250, 21)
        Me.cboCus1No.TabIndex = 429
        '
        'lblCus1No
        '
        Me.lblCus1No.AutoSize = True
        Me.lblCus1No.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblCus1No.Location = New System.Drawing.Point(67, 111)
        Me.lblCus1No.Name = "lblCus1No"
        Me.lblCus1No.Size = New System.Drawing.Size(88, 13)
        Me.lblCus1No.TabIndex = 430
        Me.lblCus1No.Text = "Primary Customer"
        '
        'lblCoNam
        '
        Me.lblCoNam.AutoSize = True
        Me.lblCoNam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblCoNam.Location = New System.Drawing.Point(246, 47)
        Me.lblCoNam.Name = "lblCoNam"
        Me.lblCoNam.Size = New System.Drawing.Size(85, 13)
        Me.lblCoNam.TabIndex = 428
        Me.lblCoNam.Text = "Company Name:"
        '
        'cboCoCde
        '
        Me.cboCoCde.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(156, 43)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(84, 21)
        Me.cboCoCde.TabIndex = 426
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.SystemColors.MenuBar
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCoNam.ForeColor = System.Drawing.Color.DimGray
        Me.txtCoNam.Location = New System.Drawing.Point(337, 43)
        Me.txtCoNam.MaxLength = 30
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.ReadOnly = True
        Me.txtCoNam.Size = New System.Drawing.Size(316, 20)
        Me.txtCoNam.TabIndex = 427
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label6.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label6.Location = New System.Drawing.Point(67, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 13)
        Me.Label6.TabIndex = 425
        Me.Label6.Text = "Company Code:"
        '
        'gbStatus
        '
        Me.gbStatus.Controls.Add(Me.optStatusB)
        Me.gbStatus.Controls.Add(Me.optStatusE)
        Me.gbStatus.Controls.Add(Me.optStatusI)
        Me.gbStatus.Location = New System.Drawing.Point(582, 76)
        Me.gbStatus.Name = "gbStatus"
        Me.gbStatus.Size = New System.Drawing.Size(298, 51)
        Me.gbStatus.TabIndex = 413
        Me.gbStatus.TabStop = False
        '
        'optStatusB
        '
        Me.optStatusB.AutoSize = True
        Me.optStatusB.Checked = True
        Me.optStatusB.Location = New System.Drawing.Point(19, 21)
        Me.optStatusB.Name = "optStatusB"
        Me.optStatusB.Size = New System.Drawing.Size(62, 17)
        Me.optStatusB.TabIndex = 2
        Me.optStatusB.TabStop = True
        Me.optStatusB.Text = "B - both"
        Me.optStatusB.UseVisualStyleBackColor = True
        '
        'optStatusE
        '
        Me.optStatusE.AutoSize = True
        Me.optStatusE.Location = New System.Drawing.Point(200, 21)
        Me.optStatusE.Name = "optStatusE"
        Me.optStatusE.Size = New System.Drawing.Size(78, 17)
        Me.optStatusE.TabIndex = 1
        Me.optStatusE.Text = "E - external"
        Me.optStatusE.UseVisualStyleBackColor = True
        '
        'optStatusI
        '
        Me.optStatusI.AutoSize = True
        Me.optStatusI.Location = New System.Drawing.Point(110, 21)
        Me.optStatusI.Name = "optStatusI"
        Me.optStatusI.Size = New System.Drawing.Size(71, 17)
        Me.optStatusI.TabIndex = 0
        Me.optStatusI.Text = "I - internal"
        Me.optStatusI.UseVisualStyleBackColor = True
        '
        'txtProcess
        '
        Me.txtProcess.BackColor = System.Drawing.Color.White
        Me.txtProcess.Location = New System.Drawing.Point(46, 484)
        Me.txtProcess.Multiline = True
        Me.txtProcess.Name = "txtProcess"
        Me.txtProcess.ReadOnly = True
        Me.txtProcess.Size = New System.Drawing.Size(728, 12)
        Me.txtProcess.TabIndex = 36
        Me.txtProcess.Visible = False
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(682, 346)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(90, 23)
        Me.cmdOK.TabIndex = 35
        Me.cmdOK.Text = "&Gen Template"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Location = New System.Drawing.Point(601, 346)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(75, 23)
        Me.cmdRefresh.TabIndex = 34
        Me.cmdRefresh.Text = "&Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(33, 390)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(482, 15)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Please make sure to select the correct Excel File Folder for Save before you PRES" & _
            "S OK."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(43, 161)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(166, 13)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = " Excel Templates Save to Folder :"
        '
        'dirSource
        '
        Me.dirSource.Location = New System.Drawing.Point(36, 204)
        Me.dirSource.Name = "dirSource"
        Me.dirSource.Size = New System.Drawing.Size(476, 185)
        Me.dirSource.TabIndex = 29
        '
        'drvSource
        '
        Me.drvSource.FormattingEnabled = True
        Me.drvSource.Location = New System.Drawing.Point(36, 177)
        Me.drvSource.Name = "drvSource"
        Me.drvSource.Size = New System.Drawing.Size(476, 21)
        Me.drvSource.TabIndex = 28
        '
        'QUXLS002
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(929, 615)
        Me.Controls.Add(Me.btcQUXLS002)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "QUXLS002"
        Me.Text = "QUXLS002 - Excel Template Generation for Quotation "
        Me.btcQUXLS002.ResumeLayout(False)
        Me.tpQUXLS002_1.ResumeLayout(False)
        Me.tpQUXLS002_1.PerformLayout()
        Me.gbStatus.ResumeLayout(False)
        Me.gbStatus.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btcQUXLS002 As ERPSystem.BaseTabControl
    Friend WithEvents tpQUXLS002_1 As System.Windows.Forms.TabPage
    Friend WithEvents txtProcess As System.Windows.Forms.TextBox
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dirSource As System.Windows.Forms.TreeView
    Friend WithEvents drvSource As System.Windows.Forms.ComboBox
    Friend WithEvents gbStatus As System.Windows.Forms.GroupBox
    Friend WithEvents optStatusB As System.Windows.Forms.RadioButton
    Friend WithEvents optStatusE As System.Windows.Forms.RadioButton
    Friend WithEvents optStatusI As System.Windows.Forms.RadioButton
    Friend WithEvents cboCus1No As System.Windows.Forms.ComboBox
    Friend WithEvents lblCus1No As System.Windows.Forms.Label
    Friend WithEvents lblCoNam As System.Windows.Forms.Label
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboSalDiv As System.Windows.Forms.ComboBox
    Friend WithEvents lblSalDiv As System.Windows.Forms.Label
End Class
