<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QCM00009
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(QCM00009))
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.grpSC = New System.Windows.Forms.GroupBox
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.cmdAppend = New System.Windows.Forms.Button
        Me.txtSCTo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtSCFm = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.tabFrame = New System.Windows.Forms.TabControl
        Me.tabMaintenance = New System.Windows.Forms.TabPage
        Me.grpMaintenance = New System.Windows.Forms.GroupBox
        Me.lbl_dir = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmd_Download = New System.Windows.Forms.Button
        Me.lstSelDesFiles = New System.Windows.Forms.ListBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.tmpCount = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.lblNumFilSource = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmdRefreshLst = New System.Windows.Forms.Button
        Me.cmdSelectAll = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.filSource = New System.Windows.Forms.ListBox
        Me.dirSource = New System.Windows.Forms.TreeView
        Me.drvSource = New System.Windows.Forms.ComboBox
        Me.cmdRight = New System.Windows.Forms.Button
        Me.cmdLeft = New System.Windows.Forms.Button
        Me.grdNewOrder = New System.Windows.Forms.DataGridView
        Me.cmdApySCRange = New System.Windows.Forms.Button
        Me.txtSelSCTo = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtSelSCFm = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Opt_P = New System.Windows.Forms.RadioButton
        Me.Opt_H = New System.Windows.Forms.RadioButton
        Me.Opt_Q = New System.Windows.Forms.RadioButton
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtQCNo = New System.Windows.Forms.TextBox
        Me.grpQC = New System.Windows.Forms.GroupBox
        Me.StatusBar = New System.Windows.Forms.StatusStrip
        Me.lblLeft = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblRight = New System.Windows.Forms.ToolStripStatusLabel
        Me.grpSC.SuspendLayout()
        Me.tabFrame.SuspendLayout()
        Me.tabMaintenance.SuspendLayout()
        Me.grpMaintenance.SuspendLayout()
        CType(Me.grdNewOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.grpQC.SuspendLayout()
        Me.StatusBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.Color.White
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.Location = New System.Drawing.Point(289, 12)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.Size = New System.Drawing.Size(330, 22)
        Me.txtCoNam.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(182, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Company Name:"
        '
        'cboCoCde
        '
        Me.cboCoCde.BackColor = System.Drawing.Color.White
        Me.cboCoCde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(107, 11)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(72, 20)
        Me.cboCoCde.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(18, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Company Code"
        '
        'grpSC
        '
        Me.grpSC.Controls.Add(Me.cmdClearAll)
        Me.grpSC.Controls.Add(Me.cmdAppend)
        Me.grpSC.Controls.Add(Me.txtSCTo)
        Me.grpSC.Controls.Add(Me.Label4)
        Me.grpSC.Controls.Add(Me.txtSCFm)
        Me.grpSC.Controls.Add(Me.Label3)
        Me.grpSC.Location = New System.Drawing.Point(12, 73)
        Me.grpSC.Name = "grpSC"
        Me.grpSC.Size = New System.Drawing.Size(690, 44)
        Me.grpSC.TabIndex = 4
        Me.grpSC.TabStop = False
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Location = New System.Drawing.Point(505, 12)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(75, 23)
        Me.cmdClearAll.TabIndex = 10
        Me.cmdClearAll.Text = "Cl&ear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'cmdAppend
        '
        Me.cmdAppend.Location = New System.Drawing.Point(424, 12)
        Me.cmdAppend.Name = "cmdAppend"
        Me.cmdAppend.Size = New System.Drawing.Size(75, 23)
        Me.cmdAppend.TabIndex = 9
        Me.cmdAppend.Text = "&Append"
        Me.cmdAppend.UseVisualStyleBackColor = True
        '
        'txtSCTo
        '
        Me.txtSCTo.Location = New System.Drawing.Point(256, 14)
        Me.txtSCTo.Name = "txtSCTo"
        Me.txtSCTo.Size = New System.Drawing.Size(134, 22)
        Me.txtSCTo.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(230, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(18, 12)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "To"
        '
        'txtSCFm
        '
        Me.txtSCFm.Location = New System.Drawing.Point(90, 14)
        Me.txtSCFm.Name = "txtSCFm"
        Me.txtSCFm.Size = New System.Drawing.Size(134, 22)
        Me.txtSCFm.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 12)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "QC From"
        '
        'tabFrame
        '
        Me.tabFrame.Controls.Add(Me.tabMaintenance)
        Me.tabFrame.ItemSize = New System.Drawing.Size(100, 18)
        Me.tabFrame.Location = New System.Drawing.Point(1, 125)
        Me.tabFrame.Name = "tabFrame"
        Me.tabFrame.SelectedIndex = 0
        Me.tabFrame.Size = New System.Drawing.Size(955, 481)
        Me.tabFrame.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabFrame.TabIndex = 12
        '
        'tabMaintenance
        '
        Me.tabMaintenance.Controls.Add(Me.grpMaintenance)
        Me.tabMaintenance.Location = New System.Drawing.Point(4, 22)
        Me.tabMaintenance.Name = "tabMaintenance"
        Me.tabMaintenance.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMaintenance.Size = New System.Drawing.Size(947, 455)
        Me.tabMaintenance.TabIndex = 0
        Me.tabMaintenance.Text = "Maintenance"
        Me.tabMaintenance.UseVisualStyleBackColor = True
        '
        'grpMaintenance
        '
        Me.grpMaintenance.Controls.Add(Me.lbl_dir)
        Me.grpMaintenance.Controls.Add(Me.Label12)
        Me.grpMaintenance.Controls.Add(Me.cmd_Download)
        Me.grpMaintenance.Controls.Add(Me.lstSelDesFiles)
        Me.grpMaintenance.Controls.Add(Me.Label7)
        Me.grpMaintenance.Controls.Add(Me.tmpCount)
        Me.grpMaintenance.Controls.Add(Me.Label8)
        Me.grpMaintenance.Controls.Add(Me.lblNumFilSource)
        Me.grpMaintenance.Controls.Add(Me.Label10)
        Me.grpMaintenance.Controls.Add(Me.cmdRefreshLst)
        Me.grpMaintenance.Controls.Add(Me.cmdSelectAll)
        Me.grpMaintenance.Controls.Add(Me.Label11)
        Me.grpMaintenance.Controls.Add(Me.filSource)
        Me.grpMaintenance.Controls.Add(Me.dirSource)
        Me.grpMaintenance.Controls.Add(Me.drvSource)
        Me.grpMaintenance.Controls.Add(Me.cmdRight)
        Me.grpMaintenance.Controls.Add(Me.cmdLeft)
        Me.grpMaintenance.Controls.Add(Me.grdNewOrder)
        Me.grpMaintenance.Controls.Add(Me.cmdApySCRange)
        Me.grpMaintenance.Controls.Add(Me.txtSelSCTo)
        Me.grpMaintenance.Controls.Add(Me.Label6)
        Me.grpMaintenance.Controls.Add(Me.txtSelSCFm)
        Me.grpMaintenance.Controls.Add(Me.Label5)
        Me.grpMaintenance.Location = New System.Drawing.Point(1, -2)
        Me.grpMaintenance.Name = "grpMaintenance"
        Me.grpMaintenance.Size = New System.Drawing.Size(940, 457)
        Me.grpMaintenance.TabIndex = 0
        Me.grpMaintenance.TabStop = False
        '
        'lbl_dir
        '
        Me.lbl_dir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_dir.Location = New System.Drawing.Point(96, 436)
        Me.lbl_dir.Name = "lbl_dir"
        Me.lbl_dir.Size = New System.Drawing.Size(659, 16)
        Me.lbl_dir.TabIndex = 90
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 437)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(94, 12)
        Me.Label12.TabIndex = 89
        Me.Label12.Text = "Current Directory: "
        '
        'cmd_Download
        '
        Me.cmd_Download.Location = New System.Drawing.Point(615, 63)
        Me.cmd_Download.Name = "cmd_Download"
        Me.cmd_Download.Size = New System.Drawing.Size(79, 23)
        Me.cmd_Download.TabIndex = 88
        Me.cmd_Download.Text = "Download"
        Me.cmd_Download.UseVisualStyleBackColor = True
        '
        'lstSelDesFiles
        '
        Me.lstSelDesFiles.FormattingEnabled = True
        Me.lstSelDesFiles.ItemHeight = 12
        Me.lstSelDesFiles.Location = New System.Drawing.Point(698, 62)
        Me.lstSelDesFiles.Name = "lstSelDesFiles"
        Me.lstSelDesFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstSelDesFiles.Size = New System.Drawing.Size(242, 364)
        Me.lstSelDesFiles.TabIndex = 87
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(700, 44)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 12)
        Me.Label7.TabIndex = 86
        Me.Label7.Text = "Files in Server"
        '
        'tmpCount
        '
        Me.tmpCount.AutoSize = True
        Me.tmpCount.Location = New System.Drawing.Point(884, 410)
        Me.tmpCount.MaximumSize = New System.Drawing.Size(50, 13)
        Me.tmpCount.MinimumSize = New System.Drawing.Size(50, 13)
        Me.tmpCount.Name = "tmpCount"
        Me.tmpCount.Size = New System.Drawing.Size(50, 13)
        Me.tmpCount.TabIndex = 85
        Me.tmpCount.Text = "0"
        Me.tmpCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tmpCount.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(896, 408)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 12)
        Me.Label8.TabIndex = 84
        Me.Label8.Text = "File Count"
        Me.Label8.Visible = False
        '
        'lblNumFilSource
        '
        Me.lblNumFilSource.AutoSize = True
        Me.lblNumFilSource.Location = New System.Drawing.Point(866, 436)
        Me.lblNumFilSource.MaximumSize = New System.Drawing.Size(50, 13)
        Me.lblNumFilSource.MinimumSize = New System.Drawing.Size(50, 13)
        Me.lblNumFilSource.Name = "lblNumFilSource"
        Me.lblNumFilSource.Size = New System.Drawing.Size(50, 13)
        Me.lblNumFilSource.TabIndex = 83
        Me.lblNumFilSource.Text = "0"
        Me.lblNumFilSource.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblNumFilSource.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(765, 434)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 12)
        Me.Label10.TabIndex = 82
        Me.Label10.Text = "Number of Files"
        Me.Label10.Visible = False
        '
        'cmdRefreshLst
        '
        Me.cmdRefreshLst.Location = New System.Drawing.Point(455, 414)
        Me.cmdRefreshLst.Name = "cmdRefreshLst"
        Me.cmdRefreshLst.Size = New System.Drawing.Size(75, 23)
        Me.cmdRefreshLst.TabIndex = 81
        Me.cmdRefreshLst.Text = "Refresh"
        Me.cmdRefreshLst.UseVisualStyleBackColor = True
        '
        'cmdSelectAll
        '
        Me.cmdSelectAll.Location = New System.Drawing.Point(363, 414)
        Me.cmdSelectAll.Name = "cmdSelectAll"
        Me.cmdSelectAll.Size = New System.Drawing.Size(75, 23)
        Me.cmdSelectAll.TabIndex = 80
        Me.cmdSelectAll.Text = "Select All"
        Me.cmdSelectAll.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(339, 44)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 12)
        Me.Label11.TabIndex = 79
        Me.Label11.Text = "Source"
        '
        'filSource
        '
        Me.filSource.FormattingEnabled = True
        Me.filSource.ItemHeight = 12
        Me.filSource.Location = New System.Drawing.Point(337, 229)
        Me.filSource.Name = "filSource"
        Me.filSource.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.filSource.Size = New System.Drawing.Size(276, 184)
        Me.filSource.TabIndex = 63
        '
        'dirSource
        '
        Me.dirSource.Location = New System.Drawing.Point(337, 89)
        Me.dirSource.Name = "dirSource"
        Me.dirSource.Size = New System.Drawing.Size(276, 139)
        Me.dirSource.TabIndex = 62
        '
        'drvSource
        '
        Me.drvSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drvSource.FormattingEnabled = True
        Me.drvSource.Location = New System.Drawing.Point(337, 62)
        Me.drvSource.Name = "drvSource"
        Me.drvSource.Size = New System.Drawing.Size(276, 20)
        Me.drvSource.TabIndex = 61
        '
        'cmdRight
        '
        Me.cmdRight.Location = New System.Drawing.Point(614, 280)
        Me.cmdRight.Name = "cmdRight"
        Me.cmdRight.Size = New System.Drawing.Size(81, 35)
        Me.cmdRight.TabIndex = 9
        Me.cmdRight.Text = ">>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Upload"
        Me.cmdRight.UseVisualStyleBackColor = True
        '
        'cmdLeft
        '
        Me.cmdLeft.Location = New System.Drawing.Point(614, 146)
        Me.cmdLeft.Name = "cmdLeft"
        Me.cmdLeft.Size = New System.Drawing.Size(81, 35)
        Me.cmdLeft.TabIndex = 8
        Me.cmdLeft.Text = "<<" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Delete)"
        Me.cmdLeft.UseVisualStyleBackColor = True
        '
        'grdNewOrder
        '
        Me.grdNewOrder.AllowUserToAddRows = False
        Me.grdNewOrder.AllowUserToDeleteRows = False
        Me.grdNewOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdNewOrder.Location = New System.Drawing.Point(9, 57)
        Me.grdNewOrder.Name = "grdNewOrder"
        Me.grdNewOrder.ReadOnly = True
        Me.grdNewOrder.RowHeadersWidth = 20
        Me.grdNewOrder.RowTemplate.Height = 15
        Me.grdNewOrder.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdNewOrder.Size = New System.Drawing.Size(322, 378)
        Me.grdNewOrder.TabIndex = 6
        '
        'cmdApySCRange
        '
        Me.cmdApySCRange.Location = New System.Drawing.Point(393, 11)
        Me.cmdApySCRange.Name = "cmdApySCRange"
        Me.cmdApySCRange.Size = New System.Drawing.Size(97, 23)
        Me.cmdApySCRange.TabIndex = 4
        Me.cmdApySCRange.Text = "Select Range"
        Me.cmdApySCRange.UseVisualStyleBackColor = True
        '
        'txtSelSCTo
        '
        Me.txtSelSCTo.Location = New System.Drawing.Point(240, 13)
        Me.txtSelSCTo.Name = "txtSelSCTo"
        Me.txtSelSCTo.Size = New System.Drawing.Size(134, 22)
        Me.txtSelSCTo.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(208, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 12)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "To: "
        '
        'txtSelSCFm
        '
        Me.txtSelSCFm.Location = New System.Drawing.Point(59, 13)
        Me.txtSelSCFm.Name = "txtSelSCFm"
        Me.txtSelSCFm.Size = New System.Drawing.Size(134, 22)
        Me.txtSelSCFm.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 12)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Sort By: "
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Opt_P)
        Me.GroupBox1.Controls.Add(Me.Opt_H)
        Me.GroupBox1.Controls.Add(Me.Opt_Q)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(690, 44)
        Me.GroupBox1.TabIndex = 93
        Me.GroupBox1.TabStop = False
        '
        'Opt_P
        '
        Me.Opt_P.AutoSize = True
        Me.Opt_P.Location = New System.Drawing.Point(418, 16)
        Me.Opt_P.Name = "Opt_P"
        Me.Opt_P.Size = New System.Drawing.Size(67, 16)
        Me.Opt_P.TabIndex = 229
        Me.Opt_P.TabStop = True
        Me.Opt_P.Text = "PO Detail"
        Me.Opt_P.UseVisualStyleBackColor = True
        '
        'Opt_H
        '
        Me.Opt_H.AutoSize = True
        Me.Opt_H.Location = New System.Drawing.Point(242, 16)
        Me.Opt_H.Name = "Opt_H"
        Me.Opt_H.Size = New System.Drawing.Size(73, 16)
        Me.Opt_H.TabIndex = 228
        Me.Opt_H.TabStop = True
        Me.Opt_H.Text = "PO Header"
        Me.Opt_H.UseVisualStyleBackColor = True
        '
        'Opt_Q
        '
        Me.Opt_Q.AutoSize = True
        Me.Opt_Q.Checked = True
        Me.Opt_Q.Location = New System.Drawing.Point(47, 16)
        Me.Opt_Q.Name = "Opt_Q"
        Me.Opt_Q.Size = New System.Drawing.Size(111, 16)
        Me.Opt_Q.TabIndex = 227
        Me.Opt_Q.TabStop = True
        Me.Opt_Q.Text = "Inspection Request"
        Me.Opt_Q.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(23, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 12)
        Me.Label9.TabIndex = 94
        Me.Label9.Text = "QC No"
        '
        'txtQCNo
        '
        Me.txtQCNo.Location = New System.Drawing.Point(72, 14)
        Me.txtQCNo.Name = "txtQCNo"
        Me.txtQCNo.Size = New System.Drawing.Size(160, 22)
        Me.txtQCNo.TabIndex = 95
        '
        'grpQC
        '
        Me.grpQC.Controls.Add(Me.Label9)
        Me.grpQC.Controls.Add(Me.txtQCNo)
        Me.grpQC.Enabled = False
        Me.grpQC.Location = New System.Drawing.Point(708, 73)
        Me.grpQC.Name = "grpQC"
        Me.grpQC.Size = New System.Drawing.Size(244, 44)
        Me.grpQC.TabIndex = 11
        Me.grpQC.TabStop = False
        Me.grpQC.Visible = False
        '
        'StatusBar
        '
        Me.StatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblLeft, Me.lblRight})
        Me.StatusBar.Location = New System.Drawing.Point(0, 607)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Size = New System.Drawing.Size(954, 24)
        Me.StatusBar.TabIndex = 2118
        Me.StatusBar.Text = "StatusStrip1"
        '
        'lblLeft
        '
        Me.lblLeft.AutoSize = False
        Me.lblLeft.Name = "lblLeft"
        Me.lblLeft.Size = New System.Drawing.Size(400, 19)
        Me.lblLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRight
        '
        Me.lblRight.AutoSize = False
        Me.lblRight.Name = "lblRight"
        Me.lblRight.Size = New System.Drawing.Size(539, 19)
        Me.lblRight.Spring = True
        Me.lblRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'QCM00009
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(954, 631)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.grpQC)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tabFrame)
        Me.Controls.Add(Me.grpSC)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "QCM00009"
        Me.Text = "QCM00009 - File Upload Maintenance (QCM09)"
        Me.grpSC.ResumeLayout(False)
        Me.grpSC.PerformLayout()
        Me.tabFrame.ResumeLayout(False)
        Me.tabMaintenance.ResumeLayout(False)
        Me.grpMaintenance.ResumeLayout(False)
        Me.grpMaintenance.PerformLayout()
        CType(Me.grdNewOrder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpQC.ResumeLayout(False)
        Me.grpQC.PerformLayout()
        Me.StatusBar.ResumeLayout(False)
        Me.StatusBar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grpSC As System.Windows.Forms.GroupBox
    Friend WithEvents cmdAppend As System.Windows.Forms.Button
    Friend WithEvents txtSCTo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSCFm As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents tabFrame As System.Windows.Forms.TabControl
    Friend WithEvents tabMaintenance As System.Windows.Forms.TabPage
    Friend WithEvents grpMaintenance As System.Windows.Forms.GroupBox
    Friend WithEvents txtSelSCTo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtSelSCFm As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents grdNewOrder As System.Windows.Forms.DataGridView
    Friend WithEvents cmdApySCRange As System.Windows.Forms.Button
    Friend WithEvents cmdLeft As System.Windows.Forms.Button
    Friend WithEvents cmdRight As System.Windows.Forms.Button
    Friend WithEvents filSource As System.Windows.Forms.ListBox
    Friend WithEvents dirSource As System.Windows.Forms.TreeView
    Friend WithEvents drvSource As System.Windows.Forms.ComboBox
    Friend WithEvents tmpCount As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblNumFilSource As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmdRefreshLst As System.Windows.Forms.Button
    Friend WithEvents cmdSelectAll As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lstSelDesFiles As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Opt_P As System.Windows.Forms.RadioButton
    Friend WithEvents Opt_H As System.Windows.Forms.RadioButton
    Friend WithEvents Opt_Q As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtQCNo As System.Windows.Forms.TextBox
    Friend WithEvents grpQC As System.Windows.Forms.GroupBox
    Friend WithEvents cmd_Download As System.Windows.Forms.Button
    Friend WithEvents lbl_dir As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents StatusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents lblLeft As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblRight As System.Windows.Forms.ToolStripStatusLabel
End Class
