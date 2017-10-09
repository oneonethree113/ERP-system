<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PGX00001
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
        Me.cboCus2No = New System.Windows.Forms.ComboBox
        Me.lblCus2No = New System.Windows.Forms.Label
        Me.cboCus1No = New System.Windows.Forms.ComboBox
        Me.lblCus1No = New System.Windows.Forms.Label
        Me.lblCoNam = New System.Windows.Forms.Label
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.btcPGXLS001 = New ERPSystem.BaseTabControl
        Me.tpPGXLS001_1 = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkQutUpd = New System.Windows.Forms.CheckBox
        Me.chkQutNew = New System.Windows.Forms.CheckBox
        Me.txtQutNo = New System.Windows.Forms.TextBox
        Me.lblQutNo = New System.Windows.Forms.Label
        Me.txtProcess = New System.Windows.Forms.TextBox
        Me.cmdOK = New System.Windows.Forms.Button
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.filSource = New System.Windows.Forms.ListBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.dirSource = New System.Windows.Forms.TreeView
        Me.drvSource = New System.Windows.Forms.ComboBox
        Me.tpPGXLS001_2 = New System.Windows.Forms.TabPage
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
        Me.cmdApply = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtFromApply = New System.Windows.Forms.TextBox
        Me.cmdGen = New System.Windows.Forms.Button
        Me.txtToApply = New System.Windows.Forms.TextBox
        Me.tpPGXLS001_3 = New System.Windows.Forms.TabPage
        Me.Button1 = New System.Windows.Forms.Button
        Me.txtReqNo = New System.Windows.Forms.TextBox
        Me.btcPGXLS001.SuspendLayout()
        Me.tpPGXLS001_1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tpPGXLS001_2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.gbStatus.SuspendLayout()
        CType(Me.grdItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpPGXLS001_3.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboCus2No
        '
        Me.cboCus2No.FormattingEnabled = True
        Me.cboCus2No.Location = New System.Drawing.Point(1004, 172)
        Me.cboCus2No.Name = "cboCus2No"
        Me.cboCus2No.Size = New System.Drawing.Size(250, 20)
        Me.cboCus2No.TabIndex = 423
        Me.cboCus2No.Visible = False
        '
        'lblCus2No
        '
        Me.lblCus2No.AutoSize = True
        Me.lblCus2No.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblCus2No.Location = New System.Drawing.Point(967, 166)
        Me.lblCus2No.Name = "lblCus2No"
        Me.lblCus2No.Size = New System.Drawing.Size(102, 12)
        Me.lblCus2No.TabIndex = 424
        Me.lblCus2No.Text = "Secondary Customer"
        Me.lblCus2No.Visible = False
        '
        'cboCus1No
        '
        Me.cboCus1No.FormattingEnabled = True
        Me.cboCus1No.Location = New System.Drawing.Point(974, 166)
        Me.cboCus1No.Name = "cboCus1No"
        Me.cboCus1No.Size = New System.Drawing.Size(250, 20)
        Me.cboCus1No.TabIndex = 421
        Me.cboCus1No.Visible = False
        '
        'lblCus1No
        '
        Me.lblCus1No.AutoSize = True
        Me.lblCus1No.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblCus1No.Location = New System.Drawing.Point(967, 149)
        Me.lblCus1No.Name = "lblCus1No"
        Me.lblCus1No.Size = New System.Drawing.Size(90, 12)
        Me.lblCus1No.TabIndex = 422
        Me.lblCus1No.Text = "Primary Customer"
        Me.lblCus1No.Visible = False
        '
        'lblCoNam
        '
        Me.lblCoNam.AutoSize = True
        Me.lblCoNam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblCoNam.Location = New System.Drawing.Point(934, 172)
        Me.lblCoNam.Name = "lblCoNam"
        Me.lblCoNam.Size = New System.Drawing.Size(85, 13)
        Me.lblCoNam.TabIndex = 417
        Me.lblCoNam.Text = "Company Name:"
        Me.lblCoNam.Visible = False
        '
        'cboCoCde
        '
        Me.cboCoCde.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(949, 164)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(84, 21)
        Me.cboCoCde.TabIndex = 264
        Me.cboCoCde.Visible = False
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.SystemColors.MenuBar
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCoNam.ForeColor = System.Drawing.Color.DimGray
        Me.txtCoNam.Location = New System.Drawing.Point(1004, 149)
        Me.txtCoNam.MaxLength = 30
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.ReadOnly = True
        Me.txtCoNam.Size = New System.Drawing.Size(316, 20)
        Me.txtCoNam.TabIndex = 265
        Me.txtCoNam.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label6.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label6.Location = New System.Drawing.Point(990, 153)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 13)
        Me.Label6.TabIndex = 262
        Me.Label6.Text = "Company Code:"
        '
        'btcPGXLS001
        '
        Me.btcPGXLS001.Controls.Add(Me.tpPGXLS001_1)
        Me.btcPGXLS001.Controls.Add(Me.tpPGXLS001_2)
        Me.btcPGXLS001.Controls.Add(Me.tpPGXLS001_3)
        Me.btcPGXLS001.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.btcPGXLS001.ItemSize = New System.Drawing.Size(110, 18)
        Me.btcPGXLS001.Location = New System.Drawing.Point(-1, 1)
        Me.btcPGXLS001.Name = "btcPGXLS001"
        Me.btcPGXLS001.SelectedIndex = 0
        Me.btcPGXLS001.Size = New System.Drawing.Size(957, 632)
        Me.btcPGXLS001.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.btcPGXLS001.TabIndex = 1
        '
        'tpPGXLS001_1
        '
        Me.tpPGXLS001_1.Controls.Add(Me.GroupBox1)
        Me.tpPGXLS001_1.Controls.Add(Me.txtQutNo)
        Me.tpPGXLS001_1.Controls.Add(Me.lblQutNo)
        Me.tpPGXLS001_1.Controls.Add(Me.txtProcess)
        Me.tpPGXLS001_1.Controls.Add(Me.cmdOK)
        Me.tpPGXLS001_1.Controls.Add(Me.cmdRefresh)
        Me.tpPGXLS001_1.Controls.Add(Me.Label3)
        Me.tpPGXLS001_1.Controls.Add(Me.Label1)
        Me.tpPGXLS001_1.Controls.Add(Me.filSource)
        Me.tpPGXLS001_1.Controls.Add(Me.Label2)
        Me.tpPGXLS001_1.Controls.Add(Me.dirSource)
        Me.tpPGXLS001_1.Controls.Add(Me.drvSource)
        Me.tpPGXLS001_1.Location = New System.Drawing.Point(4, 22)
        Me.tpPGXLS001_1.Name = "tpPGXLS001_1"
        Me.tpPGXLS001_1.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPGXLS001_1.Size = New System.Drawing.Size(949, 606)
        Me.tpPGXLS001_1.TabIndex = 0
        Me.tpPGXLS001_1.Text = "(1) Upload"
        Me.tpPGXLS001_1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkQutUpd)
        Me.GroupBox1.Controls.Add(Me.chkQutNew)
        Me.GroupBox1.Location = New System.Drawing.Point(924, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(193, 34)
        Me.GroupBox1.TabIndex = 418
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Visible = False
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
        'txtQutNo
        '
        Me.txtQutNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtQutNo.Location = New System.Drawing.Point(801, 4)
        Me.txtQutNo.MaxLength = 10
        Me.txtQutNo.Name = "txtQutNo"
        Me.txtQutNo.Size = New System.Drawing.Size(117, 20)
        Me.txtQutNo.TabIndex = 261
        Me.txtQutNo.Visible = False
        '
        'lblQutNo
        '
        Me.lblQutNo.AutoSize = True
        Me.lblQutNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblQutNo.ForeColor = System.Drawing.Color.Red
        Me.lblQutNo.Location = New System.Drawing.Point(722, 7)
        Me.lblQutNo.Name = "lblQutNo"
        Me.lblQutNo.Size = New System.Drawing.Size(67, 13)
        Me.lblQutNo.TabIndex = 263
        Me.lblQutNo.Text = "Request No:"
        Me.lblQutNo.Visible = False
        '
        'txtProcess
        '
        Me.txtProcess.BackColor = System.Drawing.Color.White
        Me.txtProcess.Location = New System.Drawing.Point(6, 466)
        Me.txtProcess.Multiline = True
        Me.txtProcess.Name = "txtProcess"
        Me.txtProcess.ReadOnly = True
        Me.txtProcess.Size = New System.Drawing.Size(937, 134)
        Me.txtProcess.TabIndex = 36
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(868, 425)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 35
        Me.cmdOK.Text = "&OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Location = New System.Drawing.Point(787, 425)
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
        Me.Label3.Location = New System.Drawing.Point(9, 451)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(369, 12)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Please make sure to select the correct Excel File Folder before you PRESS OK."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 12)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Source Folder "
        '
        'filSource
        '
        Me.filSource.FormattingEnabled = True
        Me.filSource.ItemHeight = 12
        Me.filSource.Location = New System.Drawing.Point(634, 27)
        Me.filSource.Name = "filSource"
        Me.filSource.Size = New System.Drawing.Size(309, 388)
        Me.filSource.Sorted = True
        Me.filSource.TabIndex = 30
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(633, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 12)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Excel File Listing"
        '
        'dirSource
        '
        Me.dirSource.Location = New System.Drawing.Point(12, 50)
        Me.dirSource.Name = "dirSource"
        Me.dirSource.Size = New System.Drawing.Size(616, 398)
        Me.dirSource.TabIndex = 29
        '
        'drvSource
        '
        Me.drvSource.FormattingEnabled = True
        Me.drvSource.Location = New System.Drawing.Point(12, 21)
        Me.drvSource.Name = "drvSource"
        Me.drvSource.Size = New System.Drawing.Size(616, 20)
        Me.drvSource.TabIndex = 28
        '
        'tpPGXLS001_2
        '
        Me.tpPGXLS001_2.Controls.Add(Me.GroupBox3)
        Me.tpPGXLS001_2.Controls.Add(Me.cmdUpload)
        Me.tpPGXLS001_2.Controls.Add(Me.GroupBox2)
        Me.tpPGXLS001_2.Controls.Add(Me.txtQutNo2)
        Me.tpPGXLS001_2.Controls.Add(Me.Label7)
        Me.tpPGXLS001_2.Controls.Add(Me.gbStatus)
        Me.tpPGXLS001_2.Controls.Add(Me.Label5)
        Me.tpPGXLS001_2.Controls.Add(Me.grdItem)
        Me.tpPGXLS001_2.Controls.Add(Me.cmdApply)
        Me.tpPGXLS001_2.Controls.Add(Me.Label4)
        Me.tpPGXLS001_2.Controls.Add(Me.txtFromApply)
        Me.tpPGXLS001_2.Controls.Add(Me.cmdGen)
        Me.tpPGXLS001_2.Controls.Add(Me.txtToApply)
        Me.tpPGXLS001_2.Location = New System.Drawing.Point(4, 22)
        Me.tpPGXLS001_2.Name = "tpPGXLS001_2"
        Me.tpPGXLS001_2.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPGXLS001_2.Size = New System.Drawing.Size(949, 606)
        Me.tpPGXLS001_2.TabIndex = 1
        Me.tpPGXLS001_2.Text = "(2) Confirmation"
        Me.tpPGXLS001_2.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkGenTO)
        Me.GroupBox3.Controls.Add(Me.chknomsg)
        Me.GroupBox3.Location = New System.Drawing.Point(921, 11)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(232, 50)
        Me.GroupBox3.TabIndex = 424
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "TO option"
        Me.GroupBox3.Visible = False
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
        Me.chknomsg.Location = New System.Drawing.Point(33, 22)
        Me.chknomsg.Name = "chknomsg"
        Me.chknomsg.Size = New System.Drawing.Size(103, 16)
        Me.chknomsg.TabIndex = 0
        Me.chknomsg.Text = "No Message Box"
        Me.chknomsg.UseVisualStyleBackColor = True
        Me.chknomsg.Visible = False
        '
        'cmdUpload
        '
        Me.cmdUpload.Location = New System.Drawing.Point(831, 8)
        Me.cmdUpload.Name = "cmdUpload"
        Me.cmdUpload.Size = New System.Drawing.Size(84, 22)
        Me.cmdUpload.TabIndex = 424
        Me.cmdUpload.Text = "&Re-Upload"
        Me.cmdUpload.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkallmatch)
        Me.GroupBox2.Location = New System.Drawing.Point(954, 71)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(232, 57)
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
        Me.txtQutNo2.Location = New System.Drawing.Point(965, 47)
        Me.txtQutNo2.MaxLength = 10
        Me.txtQutNo2.Name = "txtQutNo2"
        Me.txtQutNo2.Size = New System.Drawing.Size(88, 20)
        Me.txtQutNo2.TabIndex = 421
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(946, 54)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 13)
        Me.Label7.TabIndex = 422
        Me.Label7.Text = "Quotation No:"
        '
        'gbStatus
        '
        Me.gbStatus.Controls.Add(Me.optStatusF)
        Me.gbStatus.Controls.Add(Me.optStatusR)
        Me.gbStatus.Controls.Add(Me.optStatusN)
        Me.gbStatus.Controls.Add(Me.optStatusG)
        Me.gbStatus.Location = New System.Drawing.Point(22, 11)
        Me.gbStatus.Name = "gbStatus"
        Me.gbStatus.Size = New System.Drawing.Size(257, 45)
        Me.gbStatus.TabIndex = 412
        Me.gbStatus.TabStop = False
        '
        'optStatusF
        '
        Me.optStatusF.AutoSize = True
        Me.optStatusF.Location = New System.Drawing.Point(317, 40)
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
        Me.optStatusR.Location = New System.Drawing.Point(297, 17)
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
        Me.optStatusN.Location = New System.Drawing.Point(153, 17)
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
        Me.Label5.Location = New System.Drawing.Point(297, 28)
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
        Me.grdItem.Location = New System.Drawing.Point(6, 62)
        Me.grdItem.Name = "grdItem"
        Me.grdItem.RowHeadersWidth = 20
        Me.grdItem.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.grdItem.RowTemplate.Height = 16
        Me.grdItem.Size = New System.Drawing.Size(934, 541)
        Me.grdItem.TabIndex = 43
        '
        'cmdApply
        '
        Me.cmdApply.Location = New System.Drawing.Point(440, 23)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.Size = New System.Drawing.Size(73, 24)
        Me.cmdApply.TabIndex = 40
        Me.cmdApply.Text = "&Apply"
        Me.cmdApply.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(367, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(20, 15)
        Me.Label4.TabIndex = 411
        Me.Label4.Text = "To"
        '
        'txtFromApply
        '
        Me.txtFromApply.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFromApply.Location = New System.Drawing.Point(321, 25)
        Me.txtFromApply.MaxLength = 4
        Me.txtFromApply.Name = "txtFromApply"
        Me.txtFromApply.Size = New System.Drawing.Size(40, 20)
        Me.txtFromApply.TabIndex = 408
        '
        'cmdGen
        '
        Me.cmdGen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGen.Location = New System.Drawing.Point(605, 23)
        Me.cmdGen.Name = "cmdGen"
        Me.cmdGen.Size = New System.Drawing.Size(112, 23)
        Me.cmdGen.TabIndex = 36
        Me.cmdGen.Text = "&Generate"
        Me.cmdGen.UseVisualStyleBackColor = True
        '
        'txtToApply
        '
        Me.txtToApply.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtToApply.Location = New System.Drawing.Point(393, 25)
        Me.txtToApply.MaxLength = 4
        Me.txtToApply.Name = "txtToApply"
        Me.txtToApply.Size = New System.Drawing.Size(40, 20)
        Me.txtToApply.TabIndex = 409
        '
        'tpPGXLS001_3
        '
        Me.tpPGXLS001_3.Controls.Add(Me.Button1)
        Me.tpPGXLS001_3.Controls.Add(Me.txtReqNo)
        Me.tpPGXLS001_3.Location = New System.Drawing.Point(4, 22)
        Me.tpPGXLS001_3.Name = "tpPGXLS001_3"
        Me.tpPGXLS001_3.Size = New System.Drawing.Size(949, 606)
        Me.tpPGXLS001_3.TabIndex = 2
        Me.tpPGXLS001_3.Text = "(3) Result"
        Me.tpPGXLS001_3.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(714, 17)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(180, 23)
        Me.Button1.TabIndex = 425
        Me.Button1.Text = "&Show Detail"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtReqNo
        '
        Me.txtReqNo.BackColor = System.Drawing.Color.White
        Me.txtReqNo.Location = New System.Drawing.Point(8, 48)
        Me.txtReqNo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtReqNo.Multiline = True
        Me.txtReqNo.Name = "txtReqNo"
        Me.txtReqNo.ReadOnly = True
        Me.txtReqNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtReqNo.Size = New System.Drawing.Size(935, 552)
        Me.txtReqNo.TabIndex = 18
        '
        'PGX00001
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(954, 631)
        Me.Controls.Add(Me.cboCus2No)
        Me.Controls.Add(Me.btcPGXLS001)
        Me.Controls.Add(Me.lblCus2No)
        Me.Controls.Add(Me.lblCoNam)
        Me.Controls.Add(Me.cboCus1No)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblCus1No)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.cboCoCde)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "PGX00001"
        Me.Text = "PGX00001 - Excel Upload for Packaging Request Generation (PGX01)"
        Me.btcPGXLS001.ResumeLayout(False)
        Me.tpPGXLS001_1.ResumeLayout(False)
        Me.tpPGXLS001_1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tpPGXLS001_2.ResumeLayout(False)
        Me.tpPGXLS001_2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.gbStatus.ResumeLayout(False)
        Me.gbStatus.PerformLayout()
        CType(Me.grdItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpPGXLS001_3.ResumeLayout(False)
        Me.tpPGXLS001_3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btcPGXLS001 As ERPSystem.BaseTabControl
    Friend WithEvents tpPGXLS001_1 As System.Windows.Forms.TabPage
    Friend WithEvents txtProcess As System.Windows.Forms.TextBox
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents filSource As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dirSource As System.Windows.Forms.TreeView
    Friend WithEvents drvSource As System.Windows.Forms.ComboBox
    Friend WithEvents tpPGXLS001_2 As System.Windows.Forms.TabPage
    Friend WithEvents grdItem As System.Windows.Forms.DataGridView
    Friend WithEvents txtToApply As System.Windows.Forms.TextBox
    Friend WithEvents txtFromApply As System.Windows.Forms.TextBox
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents optStatusR As System.Windows.Forms.RadioButton
    Friend WithEvents optStatusN As System.Windows.Forms.RadioButton
    Friend WithEvents optStatusG As System.Windows.Forms.RadioButton
    Friend WithEvents cmdGen As System.Windows.Forms.Button
    Friend WithEvents gbStatus As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents optStatusF As System.Windows.Forms.RadioButton
    Friend WithEvents txtQutNo As System.Windows.Forms.TextBox
    Friend WithEvents lblQutNo As System.Windows.Forms.Label
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
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tpPGXLS001_3 As System.Windows.Forms.TabPage
    Friend WithEvents txtReqNo As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
