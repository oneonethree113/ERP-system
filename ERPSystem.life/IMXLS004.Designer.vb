<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IMXLS004
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IMXLS004))
        Me.imgListFolders = New System.Windows.Forms.ImageList(Me.components)
        Me.btcIMXLS004 = New ERPSystem.BaseTabControl
        Me.tpIMXLS004_1 = New System.Windows.Forms.TabPage
        Me.txtProcess = New System.Windows.Forms.TextBox
        Me.cmdOK = New System.Windows.Forms.Button
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.filSource = New System.Windows.Forms.ListBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.dirSource = New System.Windows.Forms.TreeView
        Me.drvSource = New System.Windows.Forms.ComboBox
        Me.tpIMXLS004_2 = New System.Windows.Forms.TabPage
        Me.grdItem = New System.Windows.Forms.DataGridView
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.txtToApply = New System.Windows.Forms.TextBox
        Me.txtFromApply = New System.Windows.Forms.TextBox
        Me.cmdApply = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.optStatusR = New System.Windows.Forms.RadioButton
        Me.optStatusA = New System.Windows.Forms.RadioButton
        Me.optStatusW = New System.Windows.Forms.RadioButton
        Me.cmdClose = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdShow = New System.Windows.Forms.Button
        Me.btcIMXLS004.SuspendLayout()
        Me.tpIMXLS004_1.SuspendLayout()
        Me.tpIMXLS004_2.SuspendLayout()
        CType(Me.grdItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'imgListFolders
        '
        Me.imgListFolders.ImageStream = CType(resources.GetObject("imgListFolders.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgListFolders.TransparentColor = System.Drawing.Color.Transparent
        Me.imgListFolders.Images.SetKeyName(0, "closedfolder.png")
        Me.imgListFolders.Images.SetKeyName(1, "openfolder.png")
        '
        'btcIMXLS004
        '
        Me.btcIMXLS004.Controls.Add(Me.tpIMXLS004_1)
        Me.btcIMXLS004.Controls.Add(Me.tpIMXLS004_2)
        Me.btcIMXLS004.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.btcIMXLS004.Location = New System.Drawing.Point(2, 2)
        Me.btcIMXLS004.Name = "btcIMXLS004"
        Me.btcIMXLS004.SelectedIndex = 0
        Me.btcIMXLS004.Size = New System.Drawing.Size(748, 331)
        Me.btcIMXLS004.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.btcIMXLS004.TabIndex = 0
        '
        'tpIMXLS004_1
        '
        Me.tpIMXLS004_1.Controls.Add(Me.txtProcess)
        Me.tpIMXLS004_1.Controls.Add(Me.cmdOK)
        Me.tpIMXLS004_1.Controls.Add(Me.cmdRefresh)
        Me.tpIMXLS004_1.Controls.Add(Me.Label3)
        Me.tpIMXLS004_1.Controls.Add(Me.Label1)
        Me.tpIMXLS004_1.Controls.Add(Me.filSource)
        Me.tpIMXLS004_1.Controls.Add(Me.Label2)
        Me.tpIMXLS004_1.Controls.Add(Me.dirSource)
        Me.tpIMXLS004_1.Controls.Add(Me.drvSource)
        Me.tpIMXLS004_1.Location = New System.Drawing.Point(4, 22)
        Me.tpIMXLS004_1.Name = "tpIMXLS004_1"
        Me.tpIMXLS004_1.Padding = New System.Windows.Forms.Padding(3)
        Me.tpIMXLS004_1.Size = New System.Drawing.Size(740, 305)
        Me.tpIMXLS004_1.TabIndex = 0
        Me.tpIMXLS004_1.Text = "(1) Upload"
        Me.tpIMXLS004_1.UseVisualStyleBackColor = True
        '
        'txtProcess
        '
        Me.txtProcess.BackColor = System.Drawing.Color.White
        Me.txtProcess.Location = New System.Drawing.Point(6, 201)
        Me.txtProcess.Multiline = True
        Me.txtProcess.Name = "txtProcess"
        Me.txtProcess.ReadOnly = True
        Me.txtProcess.Size = New System.Drawing.Size(728, 98)
        Me.txtProcess.TabIndex = 36
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(659, 173)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 35
        Me.cmdOK.Text = "&OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Location = New System.Drawing.Point(578, 173)
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
        Me.Label3.Location = New System.Drawing.Point(3, 178)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(381, 13)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Please make sure to select the correct Excel File Folder before you PRESS OK."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Source Folder "
        '
        'filSource
        '
        Me.filSource.FormattingEnabled = True
        Me.filSource.Location = New System.Drawing.Point(488, 22)
        Me.filSource.Name = "filSource"
        Me.filSource.Size = New System.Drawing.Size(246, 147)
        Me.filSource.TabIndex = 30
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(485, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Excel File Listing"
        '
        'dirSource
        '
        Me.dirSource.ImageIndex = 0
        Me.dirSource.ImageList = Me.imgListFolders
        Me.dirSource.Location = New System.Drawing.Point(6, 49)
        Me.dirSource.Name = "dirSource"
        Me.dirSource.SelectedImageIndex = 1
        Me.dirSource.Size = New System.Drawing.Size(476, 120)
        Me.dirSource.TabIndex = 29
        '
        'drvSource
        '
        Me.drvSource.FormattingEnabled = True
        Me.drvSource.Location = New System.Drawing.Point(6, 22)
        Me.drvSource.Name = "drvSource"
        Me.drvSource.Size = New System.Drawing.Size(476, 21)
        Me.drvSource.TabIndex = 28
        '
        'tpIMXLS004_2
        '
        Me.tpIMXLS004_2.Controls.Add(Me.grdItem)
        Me.tpIMXLS004_2.Controls.Add(Me.Panel2)
        Me.tpIMXLS004_2.Controls.Add(Me.Panel1)
        Me.tpIMXLS004_2.Controls.Add(Me.cmdClose)
        Me.tpIMXLS004_2.Controls.Add(Me.cmdSave)
        Me.tpIMXLS004_2.Controls.Add(Me.cmdClear)
        Me.tpIMXLS004_2.Controls.Add(Me.cmdShow)
        Me.tpIMXLS004_2.Location = New System.Drawing.Point(4, 22)
        Me.tpIMXLS004_2.Name = "tpIMXLS004_2"
        Me.tpIMXLS004_2.Padding = New System.Windows.Forms.Padding(3)
        Me.tpIMXLS004_2.Size = New System.Drawing.Size(740, 305)
        Me.tpIMXLS004_2.TabIndex = 1
        Me.tpIMXLS004_2.Text = "(2) Approval"
        Me.tpIMXLS004_2.UseVisualStyleBackColor = True
        '
        'grdItem
        '
        Me.grdItem.AllowUserToAddRows = False
        Me.grdItem.AllowUserToDeleteRows = False
        Me.grdItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdItem.Location = New System.Drawing.Point(9, 60)
        Me.grdItem.Name = "grdItem"
        Me.grdItem.RowHeadersWidth = 20
        Me.grdItem.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.grdItem.RowTemplate.Height = 16
        Me.grdItem.Size = New System.Drawing.Size(725, 239)
        Me.grdItem.TabIndex = 43
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txtToApply)
        Me.Panel2.Controls.Add(Me.txtFromApply)
        Me.Panel2.Controls.Add(Me.cmdApply)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Location = New System.Drawing.Point(533, 7)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(201, 47)
        Me.Panel2.TabIndex = 42
        '
        'txtToApply
        '
        Me.txtToApply.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtToApply.Location = New System.Drawing.Point(76, 13)
        Me.txtToApply.MaxLength = 4
        Me.txtToApply.Name = "txtToApply"
        Me.txtToApply.Size = New System.Drawing.Size(37, 20)
        Me.txtToApply.TabIndex = 409
        '
        'txtFromApply
        '
        Me.txtFromApply.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFromApply.Location = New System.Drawing.Point(7, 13)
        Me.txtFromApply.MaxLength = 4
        Me.txtFromApply.Name = "txtFromApply"
        Me.txtFromApply.Size = New System.Drawing.Size(37, 20)
        Me.txtFromApply.TabIndex = 408
        '
        'cmdApply
        '
        Me.cmdApply.Location = New System.Drawing.Point(119, 11)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.Size = New System.Drawing.Size(75, 23)
        Me.cmdApply.TabIndex = 40
        Me.cmdApply.Text = "&Apply"
        Me.cmdApply.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label4.Location = New System.Drawing.Point(50, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(20, 13)
        Me.Label4.TabIndex = 411
        Me.Label4.Text = "To"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.optStatusR)
        Me.Panel1.Controls.Add(Me.optStatusA)
        Me.Panel1.Controls.Add(Me.optStatusW)
        Me.Panel1.Location = New System.Drawing.Point(334, 7)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(193, 47)
        Me.Panel1.TabIndex = 41
        '
        'optStatusR
        '
        Me.optStatusR.AutoSize = True
        Me.optStatusR.Location = New System.Drawing.Point(106, 24)
        Me.optStatusR.Name = "optStatusR"
        Me.optStatusR.Size = New System.Drawing.Size(73, 17)
        Me.optStatusR.TabIndex = 2
        Me.optStatusR.Text = "R - Reject"
        Me.optStatusR.UseVisualStyleBackColor = True
        '
        'optStatusA
        '
        Me.optStatusA.AutoSize = True
        Me.optStatusA.Location = New System.Drawing.Point(13, 24)
        Me.optStatusA.Name = "optStatusA"
        Me.optStatusA.Size = New System.Drawing.Size(87, 17)
        Me.optStatusA.TabIndex = 1
        Me.optStatusA.Text = "A - Approved"
        Me.optStatusA.UseVisualStyleBackColor = True
        '
        'optStatusW
        '
        Me.optStatusW.AutoSize = True
        Me.optStatusW.Checked = True
        Me.optStatusW.Location = New System.Drawing.Point(13, 5)
        Me.optStatusW.Name = "optStatusW"
        Me.optStatusW.Size = New System.Drawing.Size(125, 17)
        Me.optStatusW.TabIndex = 0
        Me.optStatusW.TabStop = True
        Me.optStatusW.Text = "W - Wait for Approve"
        Me.optStatusW.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(252, 18)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 23)
        Me.cmdClose.TabIndex = 39
        Me.cmdClose.Text = "&Exit"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(171, 18)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(75, 23)
        Me.cmdSave.TabIndex = 38
        Me.cmdSave.Text = "&Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(90, 18)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(75, 23)
        Me.cmdClear.TabIndex = 37
        Me.cmdClear.Text = "&Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(9, 18)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(75, 23)
        Me.cmdShow.TabIndex = 36
        Me.cmdShow.Text = "&Show"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'IMXLS004
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(752, 335)
        Me.Controls.Add(Me.btcIMXLS004)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "IMXLS004"
        Me.Text = "IMXLS004 - Customer Style Number"
        Me.btcIMXLS004.ResumeLayout(False)
        Me.tpIMXLS004_1.ResumeLayout(False)
        Me.tpIMXLS004_1.PerformLayout()
        Me.tpIMXLS004_2.ResumeLayout(False)
        CType(Me.grdItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btcIMXLS004 As ERPSystem.BaseTabControl
    Friend WithEvents tpIMXLS004_1 As System.Windows.Forms.TabPage
    Friend WithEvents tpIMXLS004_2 As System.Windows.Forms.TabPage
    Friend WithEvents txtProcess As System.Windows.Forms.TextBox
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents filSource As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dirSource As System.Windows.Forms.TreeView
    Friend WithEvents drvSource As System.Windows.Forms.ComboBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents optStatusR As System.Windows.Forms.RadioButton
    Friend WithEvents optStatusA As System.Windows.Forms.RadioButton
    Friend WithEvents optStatusW As System.Windows.Forms.RadioButton
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents txtToApply As System.Windows.Forms.TextBox
    Friend WithEvents txtFromApply As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents grdItem As System.Windows.Forms.DataGridView
    Friend WithEvents imgListFolders As System.Windows.Forms.ImageList
End Class
