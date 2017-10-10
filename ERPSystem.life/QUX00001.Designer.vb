<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QUX00001
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(QUX00001))
        Me.btcQUXLS001 = New ERPSystem.BaseTabControl
        Me.tpQUXLS001_1 = New System.Windows.Forms.TabPage
        Me.cboCus2No = New System.Windows.Forms.ComboBox
        Me.lblCus2No = New System.Windows.Forms.Label
        Me.cboCus1No = New System.Windows.Forms.ComboBox
        Me.lblCus1No = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkQutUpd = New System.Windows.Forms.CheckBox
        Me.chkQutNew = New System.Windows.Forms.CheckBox
        Me.lblCoNam = New System.Windows.Forms.Label
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.txtQutNo = New System.Windows.Forms.TextBox
        Me.lblQutNo = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtProcess = New System.Windows.Forms.TextBox
        Me.cmdOK = New System.Windows.Forms.Button
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.filSource = New System.Windows.Forms.ListBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.dirSource = New System.Windows.Forms.TreeView
        Me.drvSource = New System.Windows.Forms.ComboBox
        Me.tpQUXLS001_2 = New System.Windows.Forms.TabPage
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.chkGenTO = New System.Windows.Forms.CheckBox
        Me.chknomsg = New System.Windows.Forms.CheckBox
        Me.cmdUpload = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.chkallmatch = New System.Windows.Forms.CheckBox
        Me.txtQutNo2 = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.gbStatus = New System.Windows.Forms.GroupBox
        Me.optStatusF = New System.Windows.Forms.RadioButton
        Me.optStatusR = New System.Windows.Forms.RadioButton
        Me.optStatusN = New System.Windows.Forms.RadioButton
        Me.optStatusG = New System.Windows.Forms.RadioButton
        Me.Label5 = New System.Windows.Forms.Label
        Me.grdItem = New System.Windows.Forms.DataGridView
        Me.cmdClose = New System.Windows.Forms.Button
        Me.cmdApply = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.txtFromApply = New System.Windows.Forms.TextBox
        Me.cmdGen = New System.Windows.Forms.Button
        Me.txtToApply = New System.Windows.Forms.TextBox
        Me.btcQUXLS001.SuspendLayout()
        Me.tpQUXLS001_1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tpQUXLS001_2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.gbStatus.SuspendLayout()
        CType(Me.grdItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btcQUXLS001
        '
        Me.btcQUXLS001.Controls.Add(Me.tpQUXLS001_1)
        Me.btcQUXLS001.Controls.Add(Me.tpQUXLS001_2)
        Me.btcQUXLS001.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.btcQUXLS001.ItemSize = New System.Drawing.Size(110, 18)
        Me.btcQUXLS001.Location = New System.Drawing.Point(-1, 1)
        Me.btcQUXLS001.Name = "btcQUXLS001"
        Me.btcQUXLS001.SelectedIndex = 0
        Me.btcQUXLS001.Size = New System.Drawing.Size(959, 615)
        Me.btcQUXLS001.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.btcQUXLS001.TabIndex = 1
        '
        'tpQUXLS001_1
        '
        Me.tpQUXLS001_1.Controls.Add(Me.cboCus2No)
        Me.tpQUXLS001_1.Controls.Add(Me.lblCus2No)
        Me.tpQUXLS001_1.Controls.Add(Me.cboCus1No)
        Me.tpQUXLS001_1.Controls.Add(Me.lblCus1No)
        Me.tpQUXLS001_1.Controls.Add(Me.GroupBox1)
        Me.tpQUXLS001_1.Controls.Add(Me.lblCoNam)
        Me.tpQUXLS001_1.Controls.Add(Me.cboCoCde)
        Me.tpQUXLS001_1.Controls.Add(Me.txtCoNam)
        Me.tpQUXLS001_1.Controls.Add(Me.txtQutNo)
        Me.tpQUXLS001_1.Controls.Add(Me.lblQutNo)
        Me.tpQUXLS001_1.Controls.Add(Me.Label6)
        Me.tpQUXLS001_1.Controls.Add(Me.txtProcess)
        Me.tpQUXLS001_1.Controls.Add(Me.cmdOK)
        Me.tpQUXLS001_1.Controls.Add(Me.cmdRefresh)
        Me.tpQUXLS001_1.Controls.Add(Me.Label3)
        Me.tpQUXLS001_1.Controls.Add(Me.Label1)
        Me.tpQUXLS001_1.Controls.Add(Me.filSource)
        Me.tpQUXLS001_1.Controls.Add(Me.Label2)
        Me.tpQUXLS001_1.Controls.Add(Me.dirSource)
        Me.tpQUXLS001_1.Controls.Add(Me.drvSource)
        Me.tpQUXLS001_1.Location = New System.Drawing.Point(4, 22)
        Me.tpQUXLS001_1.Name = "tpQUXLS001_1"
        Me.tpQUXLS001_1.Padding = New System.Windows.Forms.Padding(3)
        Me.tpQUXLS001_1.Size = New System.Drawing.Size(951, 589)
        Me.tpQUXLS001_1.TabIndex = 0
        Me.tpQUXLS001_1.Text = "(1) Upload"
        Me.tpQUXLS001_1.UseVisualStyleBackColor = True
        '
        'cboCus2No
        '
        Me.cboCus2No.FormattingEnabled = True
        Me.cboCus2No.Location = New System.Drawing.Point(127, 105)
        Me.cboCus2No.Name = "cboCus2No"
        Me.cboCus2No.Size = New System.Drawing.Size(250, 20)
        Me.cboCus2No.TabIndex = 423
        '
        'lblCus2No
        '
        Me.lblCus2No.AutoSize = True
        Me.lblCus2No.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblCus2No.Location = New System.Drawing.Point(9, 108)
        Me.lblCus2No.Name = "lblCus2No"
        Me.lblCus2No.Size = New System.Drawing.Size(102, 12)
        Me.lblCus2No.TabIndex = 424
        Me.lblCus2No.Text = "Secondary Customer"
        '
        'cboCus1No
        '
        Me.cboCus1No.FormattingEnabled = True
        Me.cboCus1No.Location = New System.Drawing.Point(127, 78)
        Me.cboCus1No.Name = "cboCus1No"
        Me.cboCus1No.Size = New System.Drawing.Size(250, 20)
        Me.cboCus1No.TabIndex = 421
        '
        'lblCus1No
        '
        Me.lblCus1No.AutoSize = True
        Me.lblCus1No.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblCus1No.Location = New System.Drawing.Point(9, 81)
        Me.lblCus1No.Name = "lblCus1No"
        Me.lblCus1No.Size = New System.Drawing.Size(90, 12)
        Me.lblCus1No.TabIndex = 422
        Me.lblCus1No.Text = "Primary Customer"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkQutUpd)
        Me.GroupBox1.Controls.Add(Me.chkQutNew)
        Me.GroupBox1.Location = New System.Drawing.Point(97, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(193, 34)
        Me.GroupBox1.TabIndex = 418
        Me.GroupBox1.TabStop = False
        '
        'chkQutUpd
        '
        Me.chkQutUpd.AutoSize = True
        Me.chkQutUpd.Location = New System.Drawing.Point(112, 12)
        Me.chkQutUpd.Name = "chkQutUpd"
        Me.chkQutUpd.Size = New System.Drawing.Size(57, 16)
        Me.chkQutUpd.TabIndex = 1
        Me.chkQutUpd.Text = "Update"
        Me.chkQutUpd.UseVisualStyleBackColor = True
        '
        'chkQutNew
        '
        Me.chkQutNew.AutoSize = True
        Me.chkQutNew.Location = New System.Drawing.Point(31, 12)
        Me.chkQutNew.Name = "chkQutNew"
        Me.chkQutNew.Size = New System.Drawing.Size(45, 16)
        Me.chkQutNew.TabIndex = 0
        Me.chkQutNew.Text = "New"
        Me.chkQutNew.UseVisualStyleBackColor = True
        '
        'lblCoNam
        '
        Me.lblCoNam.AutoSize = True
        Me.lblCoNam.Location = New System.Drawing.Point(272, 53)
        Me.lblCoNam.Name = "lblCoNam"
        Me.lblCoNam.Size = New System.Drawing.Size(81, 12)
        Me.lblCoNam.TabIndex = 417
        Me.lblCoNam.Text = "Company Name"
        '
        'cboCoCde
        '
        Me.cboCoCde.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(127, 49)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(84, 21)
        Me.cboCoCde.TabIndex = 264
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.SystemColors.MenuBar
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.ForeColor = System.Drawing.Color.DimGray
        Me.txtCoNam.Location = New System.Drawing.Point(363, 49)
        Me.txtCoNam.MaxLength = 30
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.ReadOnly = True
        Me.txtCoNam.Size = New System.Drawing.Size(316, 22)
        Me.txtCoNam.TabIndex = 265
        '
        'txtQutNo
        '
        Me.txtQutNo.Location = New System.Drawing.Point(128, 81)
        Me.txtQutNo.MaxLength = 10
        Me.txtQutNo.Name = "txtQutNo"
        Me.txtQutNo.Size = New System.Drawing.Size(104, 22)
        Me.txtQutNo.TabIndex = 261
        Me.txtQutNo.Visible = False
        '
        'lblQutNo
        '
        Me.lblQutNo.AutoSize = True
        Me.lblQutNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblQutNo.ForeColor = System.Drawing.Color.Red
        Me.lblQutNo.Location = New System.Drawing.Point(8, 84)
        Me.lblQutNo.Name = "lblQutNo"
        Me.lblQutNo.Size = New System.Drawing.Size(73, 13)
        Me.lblQutNo.TabIndex = 263
        Me.lblQutNo.Text = "Quotation No:"
        Me.lblQutNo.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label6.Location = New System.Drawing.Point(8, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 12)
        Me.Label6.TabIndex = 262
        Me.Label6.Text = "Company Code"
        '
        'txtProcess
        '
        Me.txtProcess.BackColor = System.Drawing.Color.White
        Me.txtProcess.Location = New System.Drawing.Point(12, 447)
        Me.txtProcess.Multiline = True
        Me.txtProcess.Name = "txtProcess"
        Me.txtProcess.ReadOnly = True
        Me.txtProcess.Size = New System.Drawing.Size(927, 134)
        Me.txtProcess.TabIndex = 36
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(864, 419)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 35
        Me.cmdOK.Text = "&OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Location = New System.Drawing.Point(783, 419)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(75, 23)
        Me.cmdRefresh.TabIndex = 34
        Me.cmdRefresh.Text = "&Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(9, 424)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(369, 12)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Please make sure to select the correct Excel File Folder before you PRESS OK."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 131)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 12)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Source Folder "
        '
        'filSource
        '
        Me.filSource.FormattingEnabled = True
        Me.filSource.ItemHeight = 12
        Me.filSource.Location = New System.Drawing.Point(576, 148)
        Me.filSource.Name = "filSource"
        Me.filSource.Size = New System.Drawing.Size(362, 268)
        Me.filSource.Sorted = True
        Me.filSource.TabIndex = 30
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(573, 131)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 12)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Excel File Listing"
        '
        'dirSource
        '
        Me.dirSource.Location = New System.Drawing.Point(12, 175)
        Me.dirSource.Name = "dirSource"
        Me.dirSource.Size = New System.Drawing.Size(558, 241)
        Me.dirSource.TabIndex = 29
        '
        'drvSource
        '
        Me.drvSource.FormattingEnabled = True
        Me.drvSource.Location = New System.Drawing.Point(12, 148)
        Me.drvSource.Name = "drvSource"
        Me.drvSource.Size = New System.Drawing.Size(558, 20)
        Me.drvSource.TabIndex = 28
        '
        'tpQUXLS001_2
        '
        Me.tpQUXLS001_2.Controls.Add(Me.GroupBox3)
        Me.tpQUXLS001_2.Controls.Add(Me.chknomsg)
        Me.tpQUXLS001_2.Controls.Add(Me.cmdUpload)
        Me.tpQUXLS001_2.Controls.Add(Me.GroupBox2)
        Me.tpQUXLS001_2.Controls.Add(Me.txtQutNo2)
        Me.tpQUXLS001_2.Controls.Add(Me.Label7)
        Me.tpQUXLS001_2.Controls.Add(Me.gbStatus)
        Me.tpQUXLS001_2.Controls.Add(Me.Label5)
        Me.tpQUXLS001_2.Controls.Add(Me.grdItem)
        Me.tpQUXLS001_2.Controls.Add(Me.cmdClose)
        Me.tpQUXLS001_2.Controls.Add(Me.cmdApply)
        Me.tpQUXLS001_2.Controls.Add(Me.Label4)
        Me.tpQUXLS001_2.Controls.Add(Me.cmdClear)
        Me.tpQUXLS001_2.Controls.Add(Me.txtFromApply)
        Me.tpQUXLS001_2.Controls.Add(Me.cmdGen)
        Me.tpQUXLS001_2.Controls.Add(Me.txtToApply)
        Me.tpQUXLS001_2.Location = New System.Drawing.Point(4, 22)
        Me.tpQUXLS001_2.Name = "tpQUXLS001_2"
        Me.tpQUXLS001_2.Padding = New System.Windows.Forms.Padding(3)
        Me.tpQUXLS001_2.Size = New System.Drawing.Size(951, 589)
        Me.tpQUXLS001_2.TabIndex = 1
        Me.tpQUXLS001_2.Text = "(2) Approval"
        Me.tpQUXLS001_2.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkGenTO)
        Me.GroupBox3.Location = New System.Drawing.Point(659, 73)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(279, 50)
        Me.GroupBox3.TabIndex = 424
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "TO option"
        '
        'chkGenTO
        '
        Me.chkGenTO.AutoSize = True
        Me.chkGenTO.Checked = True
        Me.chkGenTO.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkGenTO.Location = New System.Drawing.Point(33, 22)
        Me.chkGenTO.Name = "chkGenTO"
        Me.chkGenTO.Size = New System.Drawing.Size(111, 16)
        Me.chkGenTO.TabIndex = 0
        Me.chkGenTO.Text = "Generate Tentative"
        Me.chkGenTO.UseVisualStyleBackColor = True
        '
        'chknomsg
        '
        Me.chknomsg.AutoSize = True
        Me.chknomsg.Location = New System.Drawing.Point(235, 95)
        Me.chknomsg.Name = "chknomsg"
        Me.chknomsg.Size = New System.Drawing.Size(103, 16)
        Me.chknomsg.TabIndex = 0
        Me.chknomsg.Text = "No Message Box"
        Me.chknomsg.UseVisualStyleBackColor = True
        Me.chknomsg.Visible = False
        '
        'cmdUpload
        '
        Me.cmdUpload.Location = New System.Drawing.Point(288, 49)
        Me.cmdUpload.Name = "cmdUpload"
        Me.cmdUpload.Size = New System.Drawing.Size(75, 23)
        Me.cmdUpload.TabIndex = 424
        Me.cmdUpload.Text = "&Re-Upload"
        Me.cmdUpload.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkallmatch)
        Me.GroupBox2.Location = New System.Drawing.Point(659, 9)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(279, 57)
        Me.GroupBox2.TabIndex = 423
        Me.GroupBox2.TabStop = False
        '
        'chkallmatch
        '
        Me.chkallmatch.AutoSize = True
        Me.chkallmatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkallmatch.ForeColor = System.Drawing.Color.SteelBlue
        Me.chkallmatch.Location = New System.Drawing.Point(11, 22)
        Me.chkallmatch.Name = "chkallmatch"
        Me.chkallmatch.Size = New System.Drawing.Size(239, 17)
        Me.chkallmatch.TabIndex = 1
        Me.chkallmatch.Text = "For Real Item: All match (Color&&Pack)"
        Me.chkallmatch.UseVisualStyleBackColor = True
        '
        'txtQutNo2
        '
        Me.txtQutNo2.Enabled = False
        Me.txtQutNo2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtQutNo2.Location = New System.Drawing.Point(373, 20)
        Me.txtQutNo2.MaxLength = 10
        Me.txtQutNo2.Name = "txtQutNo2"
        Me.txtQutNo2.Size = New System.Drawing.Size(104, 20)
        Me.txtQutNo2.TabIndex = 421
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(285, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 12)
        Me.Label7.TabIndex = 422
        Me.Label7.Text = "Quotation No:"
        '
        'gbStatus
        '
        Me.gbStatus.Controls.Add(Me.optStatusF)
        Me.gbStatus.Controls.Add(Me.optStatusR)
        Me.gbStatus.Controls.Add(Me.optStatusN)
        Me.gbStatus.Controls.Add(Me.optStatusG)
        Me.gbStatus.Location = New System.Drawing.Point(520, 6)
        Me.gbStatus.Name = "gbStatus"
        Me.gbStatus.Size = New System.Drawing.Size(116, 72)
        Me.gbStatus.TabIndex = 412
        Me.gbStatus.TabStop = False
        '
        'optStatusF
        '
        Me.optStatusF.AutoSize = True
        Me.optStatusF.Location = New System.Drawing.Point(123, 43)
        Me.optStatusF.Name = "optStatusF"
        Me.optStatusF.Size = New System.Drawing.Size(56, 16)
        Me.optStatusF.TabIndex = 413
        Me.optStatusF.Text = "F - Fail"
        Me.optStatusF.UseVisualStyleBackColor = True
        Me.optStatusF.Visible = False
        '
        'optStatusR
        '
        Me.optStatusR.AutoSize = True
        Me.optStatusR.Location = New System.Drawing.Point(123, 17)
        Me.optStatusR.Name = "optStatusR"
        Me.optStatusR.Size = New System.Drawing.Size(70, 16)
        Me.optStatusR.TabIndex = 2
        Me.optStatusR.Text = "R - Reject"
        Me.optStatusR.UseVisualStyleBackColor = True
        Me.optStatusR.Visible = False
        '
        'optStatusN
        '
        Me.optStatusN.AutoSize = True
        Me.optStatusN.Location = New System.Drawing.Point(21, 43)
        Me.optStatusN.Name = "optStatusN"
        Me.optStatusN.Size = New System.Drawing.Size(66, 16)
        Me.optStatusN.TabIndex = 1
        Me.optStatusN.Text = "N - None"
        Me.optStatusN.UseVisualStyleBackColor = True
        '
        'optStatusG
        '
        Me.optStatusG.AutoSize = True
        Me.optStatusG.Location = New System.Drawing.Point(21, 17)
        Me.optStatusG.Name = "optStatusG"
        Me.optStatusG.Size = New System.Drawing.Size(82, 16)
        Me.optStatusG.TabIndex = 0
        Me.optStatusG.Text = "Y - Generate"
        Me.optStatusG.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(378, 102)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 12)
        Me.Label5.TabIndex = 412
        Me.Label5.Text = "ID"
        '
        'grdItem
        '
        Me.grdItem.AllowUserToAddRows = False
        Me.grdItem.AllowUserToDeleteRows = False
        Me.grdItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdItem.Location = New System.Drawing.Point(6, 133)
        Me.grdItem.Name = "grdItem"
        Me.grdItem.RowHeadersWidth = 20
        Me.grdItem.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.grdItem.RowTemplate.Height = 16
        Me.grdItem.Size = New System.Drawing.Size(932, 450)
        Me.grdItem.TabIndex = 43
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(194, 49)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 23)
        Me.cmdClose.TabIndex = 39
        Me.cmdClose.Text = "&Exit"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdApply
        '
        Me.cmdApply.Location = New System.Drawing.Point(520, 96)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.Size = New System.Drawing.Size(75, 23)
        Me.cmdApply.TabIndex = 40
        Me.cmdApply.Text = "&Apply"
        Me.cmdApply.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(449, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(18, 12)
        Me.Label4.TabIndex = 411
        Me.Label4.Text = "To"
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(113, 49)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(75, 23)
        Me.cmdClear.TabIndex = 37
        Me.cmdClear.Text = "&Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'txtFromApply
        '
        Me.txtFromApply.Location = New System.Drawing.Point(402, 97)
        Me.txtFromApply.MaxLength = 4
        Me.txtFromApply.Name = "txtFromApply"
        Me.txtFromApply.Size = New System.Drawing.Size(40, 22)
        Me.txtFromApply.TabIndex = 408
        '
        'cmdGen
        '
        Me.cmdGen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGen.Location = New System.Drawing.Point(32, 49)
        Me.cmdGen.Name = "cmdGen"
        Me.cmdGen.Size = New System.Drawing.Size(75, 23)
        Me.cmdGen.TabIndex = 36
        Me.cmdGen.Text = "&Generate"
        Me.cmdGen.UseVisualStyleBackColor = True
        '
        'txtToApply
        '
        Me.txtToApply.Location = New System.Drawing.Point(474, 98)
        Me.txtToApply.MaxLength = 4
        Me.txtToApply.Name = "txtToApply"
        Me.txtToApply.Size = New System.Drawing.Size(40, 22)
        Me.txtToApply.TabIndex = 409
        '
        'QUX00001
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(954, 631)
        Me.Controls.Add(Me.btcQUXLS001)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "QUX00001"
        Me.Text = "QUX00001 - Item List Upload for Quotation Generation (QUX01)"
        Me.btcQUXLS001.ResumeLayout(False)
        Me.tpQUXLS001_1.ResumeLayout(False)
        Me.tpQUXLS001_1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tpQUXLS001_2.ResumeLayout(False)
        Me.tpQUXLS001_2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.gbStatus.ResumeLayout(False)
        Me.gbStatus.PerformLayout()
        CType(Me.grdItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btcQUXLS001 As ERPSystem.BaseTabControl
    Friend WithEvents tpQUXLS001_1 As System.Windows.Forms.TabPage
    Friend WithEvents txtProcess As System.Windows.Forms.TextBox
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents filSource As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dirSource As System.Windows.Forms.TreeView
    Friend WithEvents drvSource As System.Windows.Forms.ComboBox
    Friend WithEvents tpQUXLS001_2 As System.Windows.Forms.TabPage
    Friend WithEvents grdItem As System.Windows.Forms.DataGridView
    Friend WithEvents txtToApply As System.Windows.Forms.TextBox
    Friend WithEvents txtFromApply As System.Windows.Forms.TextBox
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents optStatusR As System.Windows.Forms.RadioButton
    Friend WithEvents optStatusN As System.Windows.Forms.RadioButton
    Friend WithEvents optStatusG As System.Windows.Forms.RadioButton
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdGen As System.Windows.Forms.Button
    Friend WithEvents gbStatus As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents optStatusF As System.Windows.Forms.RadioButton
    Friend WithEvents txtQutNo As System.Windows.Forms.TextBox
    Friend WithEvents lblQutNo As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents lblCoNam As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkQutUpd As System.Windows.Forms.CheckBox
    Friend WithEvents chkQutNew As System.Windows.Forms.CheckBox
    Friend WithEvents txtQutNo2 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboCus2No As System.Windows.Forms.ComboBox
    Friend WithEvents lblCus2No As System.Windows.Forms.Label
    Friend WithEvents cboCus1No As System.Windows.Forms.ComboBox
    Friend WithEvents lblCus1No As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkallmatch As System.Windows.Forms.CheckBox
    Friend WithEvents chknomsg As System.Windows.Forms.CheckBox
    Friend WithEvents cmdUpload As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents chkGenTO As System.Windows.Forms.CheckBox
End Class
