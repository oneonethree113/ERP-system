<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PCM00001
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PCM00001))
        Me.SSTabPC = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.grdAssDgnVen = New System.Windows.Forms.DataGridView
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.grdAgyChrg = New System.Windows.Forms.DataGridView
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.grdDevChrg = New System.Windows.Forms.DataGridView
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.txtSamTerActNo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtInvAdjActNo = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtSamInvActNo = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtInvActNo = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.cboPCNo = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.grdPstDat = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.menuStrip = New System.Windows.Forms.MenuStrip
        Me.mmdAdd = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdSave = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdCopy = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdFind = New System.Windows.Forms.ToolStripMenuItem
        Me.t1 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdClear = New System.Windows.Forms.ToolStripMenuItem
        Me.t2 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdSearch = New System.Windows.Forms.ToolStripMenuItem
        Me.t3 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdInsRow = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdDelRow = New System.Windows.Forms.ToolStripMenuItem
        Me.t4 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdPrint = New System.Windows.Forms.ToolStripMenuItem
        Me.tsiPrintQuotation = New System.Windows.Forms.ToolStripMenuItem
        Me.tsiExportToExcel = New System.Windows.Forms.ToolStripMenuItem
        Me.t5 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdAttach = New System.Windows.Forms.ToolStripMenuItem
        Me.t6 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdFunction = New System.Windows.Forms.ToolStripMenuItem
        Me.tsiCIH = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsiUpdate = New System.Windows.Forms.ToolStripMenuItem
        Me.tsiRenew = New System.Windows.Forms.ToolStripMenuItem
        Me.tsiRequote = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.tsiGenTent = New System.Windows.Forms.ToolStripMenuItem
        Me.tsiGenSmp = New System.Windows.Forms.ToolStripMenuItem
        Me.t7 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdLink = New System.Windows.Forms.ToolStripMenuItem
        Me.t8 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdExit = New System.Windows.Forms.ToolStripMenuItem
        Me.SSTabPC.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.grdAssDgnVen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.grdAgyChrg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.grdDevChrg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.grdPstDat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.menuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'SSTabPC
        '
        Me.SSTabPC.Controls.Add(Me.TabPage1)
        Me.SSTabPC.Controls.Add(Me.TabPage2)
        Me.SSTabPC.Controls.Add(Me.TabPage3)
        Me.SSTabPC.Controls.Add(Me.TabPage4)
        Me.SSTabPC.Location = New System.Drawing.Point(-2, 38)
        Me.SSTabPC.Name = "SSTabPC"
        Me.SSTabPC.SelectedIndex = 0
        Me.SSTabPC.Size = New System.Drawing.Size(953, 357)
        Me.SSTabPC.TabIndex = 75
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.grdAssDgnVen)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(945, 331)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "(1) Associated Custom Vendor"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'grdAssDgnVen
        '
        Me.grdAssDgnVen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdAssDgnVen.Location = New System.Drawing.Point(3, 3)
        Me.grdAssDgnVen.Name = "grdAssDgnVen"
        Me.grdAssDgnVen.RowTemplate.Height = 24
        Me.grdAssDgnVen.Size = New System.Drawing.Size(939, 325)
        Me.grdAssDgnVen.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.grdAgyChrg)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(945, 331)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "(2) Agency Charge"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'grdAgyChrg
        '
        Me.grdAgyChrg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdAgyChrg.Location = New System.Drawing.Point(2, 2)
        Me.grdAgyChrg.Name = "grdAgyChrg"
        Me.grdAgyChrg.RowTemplate.Height = 24
        Me.grdAgyChrg.Size = New System.Drawing.Size(940, 326)
        Me.grdAgyChrg.TabIndex = 1
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.grdDevChrg)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(945, 331)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "(3) Development Charge"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'grdDevChrg
        '
        Me.grdDevChrg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDevChrg.Location = New System.Drawing.Point(0, 2)
        Me.grdDevChrg.Name = "grdDevChrg"
        Me.grdDevChrg.RowTemplate.Height = 24
        Me.grdDevChrg.Size = New System.Drawing.Size(942, 326)
        Me.grdDevChrg.TabIndex = 2
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.LightGray
        Me.TabPage4.Controls.Add(Me.txtSamTerActNo)
        Me.TabPage4.Controls.Add(Me.Label1)
        Me.TabPage4.Controls.Add(Me.txtInvAdjActNo)
        Me.TabPage4.Controls.Add(Me.Label11)
        Me.TabPage4.Controls.Add(Me.txtSamInvActNo)
        Me.TabPage4.Controls.Add(Me.Label14)
        Me.TabPage4.Controls.Add(Me.txtInvActNo)
        Me.TabPage4.Controls.Add(Me.Label17)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(945, 331)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "(4) Account Interface"
        '
        'txtSamTerActNo
        '
        Me.txtSamTerActNo.BackColor = System.Drawing.SystemColors.Window
        Me.txtSamTerActNo.Location = New System.Drawing.Point(320, 114)
        Me.txtSamTerActNo.Name = "txtSamTerActNo"
        Me.txtSamTerActNo.Size = New System.Drawing.Size(161, 22)
        Me.txtSamTerActNo.TabIndex = 85
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(125, 117)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(150, 12)
        Me.Label1.TabIndex = 84
        Me.Label1.Text = "Sample Term Account Number"
        '
        'txtInvAdjActNo
        '
        Me.txtInvAdjActNo.BackColor = System.Drawing.SystemColors.Window
        Me.txtInvAdjActNo.Location = New System.Drawing.Point(320, 92)
        Me.txtInvAdjActNo.Name = "txtInvAdjActNo"
        Me.txtInvAdjActNo.Size = New System.Drawing.Size(161, 22)
        Me.txtInvAdjActNo.TabIndex = 83
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(125, 47)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(123, 12)
        Me.Label11.TabIndex = 80
        Me.Label11.Text = "Invoice Account Number"
        '
        'txtSamInvActNo
        '
        Me.txtSamInvActNo.BackColor = System.Drawing.SystemColors.Window
        Me.txtSamInvActNo.Location = New System.Drawing.Point(320, 68)
        Me.txtSamInvActNo.Name = "txtSamInvActNo"
        Me.txtSamInvActNo.Size = New System.Drawing.Size(161, 22)
        Me.txtSamInvActNo.TabIndex = 82
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(125, 71)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(160, 12)
        Me.Label14.TabIndex = 79
        Me.Label14.Text = "Sample Invoice Account Number"
        '
        'txtInvActNo
        '
        Me.txtInvActNo.BackColor = System.Drawing.SystemColors.Window
        Me.txtInvActNo.Location = New System.Drawing.Point(320, 44)
        Me.txtInvActNo.Name = "txtInvActNo"
        Me.txtInvActNo.Size = New System.Drawing.Size(161, 22)
        Me.txtInvActNo.TabIndex = 81
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(125, 95)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(179, 12)
        Me.Label17.TabIndex = 78
        Me.Label17.Text = "Invoice Adjustment Account Number"
        '
        'cboPCNo
        '
        Me.cboPCNo.FormattingEnabled = True
        Me.cboPCNo.Location = New System.Drawing.Point(77, 12)
        Me.cboPCNo.Name = "cboPCNo"
        Me.cboPCNo.Size = New System.Drawing.Size(161, 20)
        Me.cboPCNo.TabIndex = 76
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 12)
        Me.Label8.TabIndex = 77
        Me.Label8.Text = "Profit Center"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(90, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(152, 23)
        Me.Button1.TabIndex = 287
        Me.Button1.Text = "Assign New Posting Date"
        '
        'grdPstDat
        '
        Me.grdPstDat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPstDat.Location = New System.Drawing.Point(7, 32)
        Me.grdPstDat.Name = "grdPstDat"
        Me.grdPstDat.RowTemplate.Height = 24
        Me.grdPstDat.Size = New System.Drawing.Size(484, 130)
        Me.grdPstDat.TabIndex = 288
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 12)
        Me.Label2.TabIndex = 289
        Me.Label2.Text = "Posting Date"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.SSTabPC)
        Me.GroupBox1.Controls.Add(Me.cboPCNo)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 229)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(951, 401)
        Me.GroupBox1.TabIndex = 290
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.grdPstDat)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 55)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(497, 171)
        Me.GroupBox2.TabIndex = 291
        Me.GroupBox2.TabStop = False
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(6, 11)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(81, 16)
        Me.RadioButton1.TabIndex = 292
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Posting Date"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(118, 11)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(91, 16)
        Me.RadioButton2.TabIndex = 293
        Me.RadioButton2.Text = "Posting Center"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RadioButton1)
        Me.GroupBox3.Controls.Add(Me.RadioButton2)
        Me.GroupBox3.Location = New System.Drawing.Point(5, 28)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(218, 30)
        Me.GroupBox3.TabIndex = 294
        Me.GroupBox3.TabStop = False
        '
        'menuStrip
        '
        Me.menuStrip.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mmdAdd, Me.mmdSave, Me.mmdDelete, Me.mmdCopy, Me.mmdFind, Me.t1, Me.mmdClear, Me.t2, Me.mmdSearch, Me.t3, Me.mmdInsRow, Me.mmdDelRow, Me.t4, Me.mmdPrint, Me.t5, Me.mmdAttach, Me.t6, Me.mmdFunction, Me.t7, Me.mmdLink, Me.t8, Me.mmdExit})
        Me.menuStrip.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip.Name = "menuStrip"
        Me.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.menuStrip.Size = New System.Drawing.Size(954, 24)
        Me.menuStrip.TabIndex = 534
        Me.menuStrip.Text = "MenuStrip1"
        '
        'mmdAdd
        '
        Me.mmdAdd.BackColor = System.Drawing.SystemColors.Control
        Me.mmdAdd.Name = "mmdAdd"
        Me.mmdAdd.Size = New System.Drawing.Size(40, 20)
        Me.mmdAdd.Tag = "Add"
        Me.mmdAdd.Text = "&Add"
        '
        'mmdSave
        '
        Me.mmdSave.Name = "mmdSave"
        Me.mmdSave.Size = New System.Drawing.Size(46, 20)
        Me.mmdSave.Text = "&Save"
        '
        'mmdDelete
        '
        Me.mmdDelete.Name = "mmdDelete"
        Me.mmdDelete.Size = New System.Drawing.Size(55, 20)
        Me.mmdDelete.Text = "&Delete"
        '
        'mmdCopy
        '
        Me.mmdCopy.Name = "mmdCopy"
        Me.mmdCopy.Size = New System.Drawing.Size(47, 20)
        Me.mmdCopy.Text = "&Copy"
        '
        'mmdFind
        '
        Me.mmdFind.Name = "mmdFind"
        Me.mmdFind.Size = New System.Drawing.Size(43, 20)
        Me.mmdFind.Text = "&Find"
        '
        't1
        '
        Me.t1.AutoSize = False
        Me.t1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.t1.Enabled = False
        Me.t1.Name = "t1"
        Me.t1.Size = New System.Drawing.Size(8, 20)
        Me.t1.Text = "|"
        '
        'mmdClear
        '
        Me.mmdClear.Name = "mmdClear"
        Me.mmdClear.Size = New System.Drawing.Size(49, 20)
        Me.mmdClear.Text = "Cl&ear"
        '
        't2
        '
        Me.t2.AutoSize = False
        Me.t2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.t2.Enabled = False
        Me.t2.Name = "t2"
        Me.t2.Size = New System.Drawing.Size(8, 20)
        Me.t2.Text = "|"
        '
        'mmdSearch
        '
        Me.mmdSearch.Name = "mmdSearch"
        Me.mmdSearch.Size = New System.Drawing.Size(58, 20)
        Me.mmdSearch.Text = "Searc&h"
        '
        't3
        '
        Me.t3.AutoSize = False
        Me.t3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.t3.Enabled = False
        Me.t3.Name = "t3"
        Me.t3.Size = New System.Drawing.Size(8, 20)
        Me.t3.Text = "|"
        '
        'mmdInsRow
        '
        Me.mmdInsRow.Name = "mmdInsRow"
        Me.mmdInsRow.Size = New System.Drawing.Size(64, 20)
        Me.mmdInsRow.Text = "I&ns Row"
        '
        'mmdDelRow
        '
        Me.mmdDelRow.Name = "mmdDelRow"
        Me.mmdDelRow.Size = New System.Drawing.Size(66, 20)
        Me.mmdDelRow.Text = "Del Ro&w"
        '
        't4
        '
        Me.t4.AutoSize = False
        Me.t4.Enabled = False
        Me.t4.Name = "t4"
        Me.t4.Size = New System.Drawing.Size(8, 20)
        Me.t4.Text = "|"
        '
        'mmdPrint
        '
        Me.mmdPrint.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsiPrintQuotation, Me.tsiExportToExcel})
        Me.mmdPrint.Name = "mmdPrint"
        Me.mmdPrint.Size = New System.Drawing.Size(44, 20)
        Me.mmdPrint.Text = "&Print"
        '
        'tsiPrintQuotation
        '
        Me.tsiPrintQuotation.Name = "tsiPrintQuotation"
        Me.tsiPrintQuotation.Size = New System.Drawing.Size(155, 22)
        Me.tsiPrintQuotation.Text = "Print Quotation"
        '
        'tsiExportToExcel
        '
        Me.tsiExportToExcel.Name = "tsiExportToExcel"
        Me.tsiExportToExcel.Size = New System.Drawing.Size(155, 22)
        Me.tsiExportToExcel.Text = "Export to Excel"
        '
        't5
        '
        Me.t5.AutoSize = False
        Me.t5.Enabled = False
        Me.t5.Name = "t5"
        Me.t5.Size = New System.Drawing.Size(8, 20)
        Me.t5.Text = "|"
        '
        'mmdAttach
        '
        Me.mmdAttach.Name = "mmdAttach"
        Me.mmdAttach.Size = New System.Drawing.Size(52, 20)
        Me.mmdAttach.Text = "Attach"
        '
        't6
        '
        Me.t6.AutoSize = False
        Me.t6.Enabled = False
        Me.t6.Name = "t6"
        Me.t6.Size = New System.Drawing.Size(8, 20)
        Me.t6.Text = "|"
        '
        'mmdFunction
        '
        Me.mmdFunction.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsiCIH, Me.ToolStripSeparator1, Me.tsiUpdate, Me.tsiRenew, Me.tsiRequote, Me.ToolStripSeparator2, Me.tsiGenTent, Me.tsiGenSmp})
        Me.mmdFunction.Name = "mmdFunction"
        Me.mmdFunction.Size = New System.Drawing.Size(66, 20)
        Me.mmdFunction.Text = "Function"
        '
        'tsiCIH
        '
        Me.tsiCIH.Name = "tsiCIH"
        Me.tsiCIH.Size = New System.Drawing.Size(197, 22)
        Me.tsiCIH.Text = "Customer Item History"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(194, 6)
        '
        'tsiUpdate
        '
        Me.tsiUpdate.Name = "tsiUpdate"
        Me.tsiUpdate.Size = New System.Drawing.Size(197, 22)
        Me.tsiUpdate.Text = "Update Item(s)"
        '
        'tsiRenew
        '
        Me.tsiRenew.Name = "tsiRenew"
        Me.tsiRenew.Size = New System.Drawing.Size(197, 22)
        Me.tsiRenew.Text = "Renew Item(s)"
        '
        'tsiRequote
        '
        Me.tsiRequote.Name = "tsiRequote"
        Me.tsiRequote.Size = New System.Drawing.Size(197, 22)
        Me.tsiRequote.Text = "Requote Item(s)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(194, 6)
        '
        'tsiGenTent
        '
        Me.tsiGenTent.Name = "tsiGenTent"
        Me.tsiGenTent.Size = New System.Drawing.Size(197, 22)
        Me.tsiGenTent.Text = "Generate Tentative"
        '
        'tsiGenSmp
        '
        Me.tsiGenSmp.Name = "tsiGenSmp"
        Me.tsiGenSmp.Size = New System.Drawing.Size(197, 22)
        Me.tsiGenSmp.Text = "Generate Sample"
        '
        't7
        '
        Me.t7.AutoSize = False
        Me.t7.Enabled = False
        Me.t7.Name = "t7"
        Me.t7.Size = New System.Drawing.Size(8, 20)
        Me.t7.Text = "|"
        '
        'mmdLink
        '
        Me.mmdLink.Name = "mmdLink"
        Me.mmdLink.Size = New System.Drawing.Size(42, 20)
        Me.mmdLink.Text = "Link"
        '
        't8
        '
        Me.t8.AutoSize = False
        Me.t8.Enabled = False
        Me.t8.Name = "t8"
        Me.t8.Size = New System.Drawing.Size(8, 20)
        Me.t8.Text = "|"
        '
        'mmdExit
        '
        Me.mmdExit.Name = "mmdExit"
        Me.mmdExit.Size = New System.Drawing.Size(38, 20)
        Me.mmdExit.Text = "E&xit"
        '
        'PCM00001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(954, 631)
        Me.Controls.Add(Me.menuStrip)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "PCM00001"
        Me.Text = "PCM00001 - Account Setup Master (PCM01)"
        Me.SSTabPC.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.grdAssDgnVen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.grdAgyChrg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.grdDevChrg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        CType(Me.grdPstDat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.menuStrip.ResumeLayout(False)
        Me.menuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SSTabPC As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents grdAssDgnVen As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents cboPCNo As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents grdAgyChrg As System.Windows.Forms.DataGridView
    Friend WithEvents grdDevChrg As System.Windows.Forms.DataGridView
    Friend WithEvents txtInvAdjActNo As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtSamInvActNo As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtInvActNo As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtSamTerActNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents grdPstDat As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents menuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents mmdAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdFind As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdClear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdInsRow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdDelRow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsiPrintQuotation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsiExportToExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdAttach As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdFunction As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsiCIH As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsiUpdate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsiRenew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsiRequote As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsiGenTent As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsiGenSmp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t7 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdLink As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t8 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdExit As System.Windows.Forms.ToolStripMenuItem
End Class
