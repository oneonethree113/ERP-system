<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IMG00001
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IMG00001))
        Me.lblFilname = New System.Windows.Forms.Label
        Me.pBxImage = New System.Windows.Forms.PictureBox
        Me.statusBar = New System.Windows.Forms.StatusStrip
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.grpFolders = New System.Windows.Forms.GroupBox
        Me.optExceptImgFolder = New System.Windows.Forms.RadioButton
        Me.optUploadImgFolder = New System.Windows.Forms.RadioButton
        Me.lblOther = New System.Windows.Forms.Label
        Me.lblDup = New System.Windows.Forms.Label
        Me.lblExcept = New System.Windows.Forms.Label
        Me.lblNumFil = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblMessage = New System.Windows.Forms.Label
        Me.txtLog = New System.Windows.Forms.TextBox
        Me.tmpCount = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblNumFilSource = New System.Windows.Forms.Label
        Me.lblServerName = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdRefreshLst = New System.Windows.Forms.Button
        Me.cmdSelectAll = New System.Windows.Forms.Button
        Me.imgListFolders = New System.Windows.Forms.ImageList(Me.components)
        Me.chkViewCont = New System.Windows.Forms.CheckBox
        Me.chkView = New System.Windows.Forms.CheckBox
        Me.cmdCopyMove = New System.Windows.Forms.Button
        Me.chkOverwrite = New System.Windows.Forms.CheckBox
        Me.cmdClose = New System.Windows.Forms.Button
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.cmdDefSource = New System.Windows.Forms.Button
        Me.filDest = New System.Windows.Forms.ListBox
        Me.dirDest = New System.Windows.Forms.TreeView
        Me.drvDest = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.filSource = New System.Windows.Forms.ListBox
        Me.dirSource = New System.Windows.Forms.TreeView
        Me.drvSource = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.grpFormat = New System.Windows.Forms.GroupBox
        Me.grpPreview = New System.Windows.Forms.GroupBox
        CType(Me.pBxImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.statusBar.SuspendLayout()
        Me.grpFolders.SuspendLayout()
        Me.grpFormat.SuspendLayout()
        Me.grpPreview.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblFilname
        '
        Me.lblFilname.AutoSize = True
        Me.lblFilname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFilname.Location = New System.Drawing.Point(10, 421)
        Me.lblFilname.MaximumSize = New System.Drawing.Size(190, 13)
        Me.lblFilname.MinimumSize = New System.Drawing.Size(190, 13)
        Me.lblFilname.Name = "lblFilname"
        Me.lblFilname.Size = New System.Drawing.Size(190, 13)
        Me.lblFilname.TabIndex = 89
        Me.lblFilname.Text = "Image Filename"
        Me.lblFilname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pBxImage
        '
        Me.pBxImage.Location = New System.Drawing.Point(5, 21)
        Me.pBxImage.MaximumSize = New System.Drawing.Size(193, 204)
        Me.pBxImage.Name = "pBxImage"
        Me.pBxImage.Size = New System.Drawing.Size(193, 204)
        Me.pBxImage.TabIndex = 88
        Me.pBxImage.TabStop = False
        '
        'statusBar
        '
        Me.statusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.statusBar.Location = New System.Drawing.Point(0, 609)
        Me.statusBar.Name = "statusBar"
        Me.statusBar.Size = New System.Drawing.Size(954, 22)
        Me.statusBar.TabIndex = 91
        Me.statusBar.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(0, 17)
        '
        'grpFolders
        '
        Me.grpFolders.Controls.Add(Me.optExceptImgFolder)
        Me.grpFolders.Controls.Add(Me.optUploadImgFolder)
        Me.grpFolders.Location = New System.Drawing.Point(10, 56)
        Me.grpFolders.Name = "grpFolders"
        Me.grpFolders.Size = New System.Drawing.Size(204, 69)
        Me.grpFolders.TabIndex = 90
        Me.grpFolders.TabStop = False
        Me.grpFolders.Text = "Folders"
        '
        'optExceptImgFolder
        '
        Me.optExceptImgFolder.AutoSize = True
        Me.optExceptImgFolder.Location = New System.Drawing.Point(24, 43)
        Me.optExceptImgFolder.Name = "optExceptImgFolder"
        Me.optExceptImgFolder.Size = New System.Drawing.Size(135, 16)
        Me.optExceptImgFolder.TabIndex = 1
        Me.optExceptImgFolder.TabStop = True
        Me.optExceptImgFolder.Text = "Exception Image Folder"
        Me.optExceptImgFolder.UseVisualStyleBackColor = True
        '
        'optUploadImgFolder
        '
        Me.optUploadImgFolder.AutoSize = True
        Me.optUploadImgFolder.Location = New System.Drawing.Point(24, 19)
        Me.optUploadImgFolder.Name = "optUploadImgFolder"
        Me.optUploadImgFolder.Size = New System.Drawing.Size(122, 16)
        Me.optUploadImgFolder.TabIndex = 0
        Me.optUploadImgFolder.TabStop = True
        Me.optUploadImgFolder.Text = "Upload Image Folder"
        Me.optUploadImgFolder.UseVisualStyleBackColor = True
        '
        'lblOther
        '
        Me.lblOther.AutoSize = True
        Me.lblOther.Location = New System.Drawing.Point(887, 419)
        Me.lblOther.MaximumSize = New System.Drawing.Size(40, 13)
        Me.lblOther.MinimumSize = New System.Drawing.Size(40, 13)
        Me.lblOther.Name = "lblOther"
        Me.lblOther.Size = New System.Drawing.Size(40, 13)
        Me.lblOther.TabIndex = 87
        Me.lblOther.Text = "0"
        Me.lblOther.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDup
        '
        Me.lblDup.AutoSize = True
        Me.lblDup.Location = New System.Drawing.Point(887, 399)
        Me.lblDup.MaximumSize = New System.Drawing.Size(40, 13)
        Me.lblDup.MinimumSize = New System.Drawing.Size(40, 13)
        Me.lblDup.Name = "lblDup"
        Me.lblDup.Size = New System.Drawing.Size(40, 13)
        Me.lblDup.TabIndex = 86
        Me.lblDup.Text = "0"
        Me.lblDup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblExcept
        '
        Me.lblExcept.AutoSize = True
        Me.lblExcept.Location = New System.Drawing.Point(887, 379)
        Me.lblExcept.MaximumSize = New System.Drawing.Size(40, 13)
        Me.lblExcept.MinimumSize = New System.Drawing.Size(40, 13)
        Me.lblExcept.Name = "lblExcept"
        Me.lblExcept.Size = New System.Drawing.Size(40, 13)
        Me.lblExcept.TabIndex = 85
        Me.lblExcept.Text = "0"
        Me.lblExcept.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNumFil
        '
        Me.lblNumFil.AutoSize = True
        Me.lblNumFil.Location = New System.Drawing.Point(887, 358)
        Me.lblNumFil.MaximumSize = New System.Drawing.Size(40, 13)
        Me.lblNumFil.MinimumSize = New System.Drawing.Size(40, 13)
        Me.lblNumFil.Name = "lblNumFil"
        Me.lblNumFil.Size = New System.Drawing.Size(40, 13)
        Me.lblNumFil.TabIndex = 84
        Me.lblNumFil.Text = "0"
        Me.lblNumFil.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(747, 417)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(109, 12)
        Me.Label9.TabIndex = 83
        Me.Label9.Text = "Number of Other Files"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(747, 397)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(133, 12)
        Me.Label8.TabIndex = 82
        Me.Label8.Text = "Number of Duplicated Files"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(747, 377)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(126, 12)
        Me.Label7.TabIndex = 81
        Me.Label7.Text = "Number of Excepted Files"
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Location = New System.Drawing.Point(747, 357)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(117, 12)
        Me.lblMessage.TabIndex = 80
        Me.lblMessage.Text = "Number of Copied Files"
        '
        'txtLog
        '
        Me.txtLog.BackColor = System.Drawing.Color.White
        Me.txtLog.Location = New System.Drawing.Point(10, 450)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ReadOnly = True
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLog.Size = New System.Drawing.Size(935, 156)
        Me.txtLog.TabIndex = 79
        Me.txtLog.TabStop = False
        '
        'tmpCount
        '
        Me.tmpCount.AutoSize = True
        Me.tmpCount.Location = New System.Drawing.Point(381, 421)
        Me.tmpCount.MaximumSize = New System.Drawing.Size(50, 13)
        Me.tmpCount.MinimumSize = New System.Drawing.Size(50, 13)
        Me.tmpCount.Name = "tmpCount"
        Me.tmpCount.Size = New System.Drawing.Size(50, 13)
        Me.tmpCount.TabIndex = 78
        Me.tmpCount.Text = "0"
        Me.tmpCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(273, 421)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 12)
        Me.Label5.TabIndex = 77
        Me.Label5.Text = "File Count"
        '
        'lblNumFilSource
        '
        Me.lblNumFilSource.AutoSize = True
        Me.lblNumFilSource.Location = New System.Drawing.Point(381, 381)
        Me.lblNumFilSource.MaximumSize = New System.Drawing.Size(50, 13)
        Me.lblNumFilSource.MinimumSize = New System.Drawing.Size(50, 13)
        Me.lblNumFilSource.Name = "lblNumFilSource"
        Me.lblNumFilSource.Size = New System.Drawing.Size(50, 13)
        Me.lblNumFilSource.TabIndex = 76
        Me.lblNumFilSource.Text = "0"
        Me.lblNumFilSource.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblServerName
        '
        Me.lblServerName.AutoSize = True
        Me.lblServerName.Location = New System.Drawing.Point(273, 401)
        Me.lblServerName.MaximumSize = New System.Drawing.Size(160, 13)
        Me.lblServerName.MinimumSize = New System.Drawing.Size(160, 13)
        Me.lblServerName.Name = "lblServerName"
        Me.lblServerName.Size = New System.Drawing.Size(160, 13)
        Me.lblServerName.TabIndex = 75
        Me.lblServerName.Text = "SERVER NAME"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(273, 381)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 12)
        Me.Label4.TabIndex = 74
        Me.Label4.Text = "Number of Files"
        '
        'cboCoCde
        '
        Me.cboCoCde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(78, 17)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(109, 20)
        Me.cboCoCde.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Image Name" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Format"
        '
        'cmdRefreshLst
        '
        Me.cmdRefreshLst.Location = New System.Drawing.Point(358, 351)
        Me.cmdRefreshLst.Name = "cmdRefreshLst"
        Me.cmdRefreshLst.Size = New System.Drawing.Size(75, 23)
        Me.cmdRefreshLst.TabIndex = 73
        Me.cmdRefreshLst.Text = "Refresh"
        Me.cmdRefreshLst.UseVisualStyleBackColor = True
        '
        'cmdSelectAll
        '
        Me.cmdSelectAll.Location = New System.Drawing.Point(273, 351)
        Me.cmdSelectAll.Name = "cmdSelectAll"
        Me.cmdSelectAll.Size = New System.Drawing.Size(75, 23)
        Me.cmdSelectAll.TabIndex = 72
        Me.cmdSelectAll.Text = "Select All"
        Me.cmdSelectAll.UseVisualStyleBackColor = True
        '
        'imgListFolders
        '
        Me.imgListFolders.ImageStream = CType(resources.GetObject("imgListFolders.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgListFolders.TransparentColor = System.Drawing.Color.Transparent
        Me.imgListFolders.Images.SetKeyName(0, "closedfolder.png")
        Me.imgListFolders.Images.SetKeyName(1, "openfolder.png")
        '
        'chkViewCont
        '
        Me.chkViewCont.AutoSize = True
        Me.chkViewCont.Location = New System.Drawing.Point(547, 381)
        Me.chkViewCont.Name = "chkViewCont"
        Me.chkViewCont.Size = New System.Drawing.Size(88, 16)
        Me.chkViewCont.TabIndex = 71
        Me.chkViewCont.Text = "View Content"
        Me.chkViewCont.UseVisualStyleBackColor = True
        '
        'chkView
        '
        Me.chkView.AutoSize = True
        Me.chkView.Location = New System.Drawing.Point(547, 361)
        Me.chkView.Name = "chkView"
        Me.chkView.Size = New System.Drawing.Size(80, 16)
        Me.chkView.TabIndex = 70
        Me.chkView.Text = "View Image"
        Me.chkView.UseVisualStyleBackColor = True
        '
        'cmdCopyMove
        '
        Me.cmdCopyMove.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCopyMove.Location = New System.Drawing.Point(551, 208)
        Me.cmdCopyMove.Name = "cmdCopyMove"
        Me.cmdCopyMove.Size = New System.Drawing.Size(75, 30)
        Me.cmdCopyMove.TabIndex = 69
        Me.cmdCopyMove.Text = "-&>"
        Me.cmdCopyMove.UseVisualStyleBackColor = True
        '
        'chkOverwrite
        '
        Me.chkOverwrite.AutoSize = True
        Me.chkOverwrite.Location = New System.Drawing.Point(544, 126)
        Me.chkOverwrite.Name = "chkOverwrite"
        Me.chkOverwrite.Size = New System.Drawing.Size(94, 28)
        Me.chkOverwrite.TabIndex = 68
        Me.chkOverwrite.Text = "Overwrite" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Existing Image"
        Me.chkOverwrite.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(551, 91)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 23)
        Me.cmdClose.TabIndex = 67
        Me.cmdClose.Text = "E&xit"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Location = New System.Drawing.Point(551, 61)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(75, 23)
        Me.cmdRefresh.TabIndex = 66
        Me.cmdRefresh.Text = "Re&fresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'cmdDefSource
        '
        Me.cmdDefSource.Location = New System.Drawing.Point(551, 31)
        Me.cmdDefSource.Name = "cmdDefSource"
        Me.cmdDefSource.Size = New System.Drawing.Size(75, 23)
        Me.cmdDefSource.TabIndex = 65
        Me.cmdDefSource.Text = "&Reset All"
        Me.cmdDefSource.UseVisualStyleBackColor = True
        '
        'filDest
        '
        Me.filDest.BackColor = System.Drawing.SystemColors.Window
        Me.filDest.FormattingEnabled = True
        Me.filDest.ItemHeight = 12
        Me.filDest.Location = New System.Drawing.Point(664, 213)
        Me.filDest.Name = "filDest"
        Me.filDest.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.filDest.Size = New System.Drawing.Size(281, 124)
        Me.filDest.TabIndex = 64
        '
        'dirDest
        '
        Me.dirDest.BackColor = System.Drawing.SystemColors.Window
        Me.dirDest.ImageIndex = 0
        Me.dirDest.ImageList = Me.imgListFolders
        Me.dirDest.Location = New System.Drawing.Point(664, 58)
        Me.dirDest.Name = "dirDest"
        Me.dirDest.SelectedImageIndex = 0
        Me.dirDest.Size = New System.Drawing.Size(281, 140)
        Me.dirDest.TabIndex = 63
        '
        'drvDest
        '
        Me.drvDest.BackColor = System.Drawing.SystemColors.Window
        Me.drvDest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drvDest.Enabled = False
        Me.drvDest.FormattingEnabled = True
        Me.drvDest.Location = New System.Drawing.Point(664, 31)
        Me.drvDest.Name = "drvDest"
        Me.drvDest.Size = New System.Drawing.Size(281, 20)
        Me.drvDest.TabIndex = 62
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(664, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 61
        Me.Label3.Text = "Destination"
        '
        'filSource
        '
        Me.filSource.FormattingEnabled = True
        Me.filSource.ItemHeight = 12
        Me.filSource.Location = New System.Drawing.Point(220, 213)
        Me.filSource.Name = "filSource"
        Me.filSource.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.filSource.Size = New System.Drawing.Size(294, 124)
        Me.filSource.TabIndex = 60
        '
        'dirSource
        '
        Me.dirSource.ImageIndex = 0
        Me.dirSource.ImageList = Me.imgListFolders
        Me.dirSource.Location = New System.Drawing.Point(220, 58)
        Me.dirSource.Name = "dirSource"
        Me.dirSource.SelectedImageIndex = 0
        Me.dirSource.Size = New System.Drawing.Size(294, 140)
        Me.dirSource.TabIndex = 59
        '
        'drvSource
        '
        Me.drvSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drvSource.FormattingEnabled = True
        Me.drvSource.Location = New System.Drawing.Point(220, 31)
        Me.drvSource.Name = "drvSource"
        Me.drvSource.Size = New System.Drawing.Size(294, 20)
        Me.drvSource.TabIndex = 58
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(217, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 57
        Me.Label2.Text = "Source"
        '
        'grpFormat
        '
        Me.grpFormat.Controls.Add(Me.cboCoCde)
        Me.grpFormat.Controls.Add(Me.Label1)
        Me.grpFormat.Location = New System.Drawing.Point(10, 1)
        Me.grpFormat.Name = "grpFormat"
        Me.grpFormat.Size = New System.Drawing.Size(204, 49)
        Me.grpFormat.TabIndex = 56
        Me.grpFormat.TabStop = False
        '
        'grpPreview
        '
        Me.grpPreview.Controls.Add(Me.pBxImage)
        Me.grpPreview.Location = New System.Drawing.Point(10, 126)
        Me.grpPreview.Name = "grpPreview"
        Me.grpPreview.Size = New System.Drawing.Size(204, 238)
        Me.grpPreview.TabIndex = 92
        Me.grpPreview.TabStop = False
        Me.grpPreview.Text = "Preview Image"
        '
        'IMG00001
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(954, 631)
        Me.Controls.Add(Me.grpPreview)
        Me.Controls.Add(Me.lblFilname)
        Me.Controls.Add(Me.statusBar)
        Me.Controls.Add(Me.grpFolders)
        Me.Controls.Add(Me.lblOther)
        Me.Controls.Add(Me.lblDup)
        Me.Controls.Add(Me.lblExcept)
        Me.Controls.Add(Me.lblNumFil)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.txtLog)
        Me.Controls.Add(Me.tmpCount)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblNumFilSource)
        Me.Controls.Add(Me.lblServerName)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmdRefreshLst)
        Me.Controls.Add(Me.cmdSelectAll)
        Me.Controls.Add(Me.chkViewCont)
        Me.Controls.Add(Me.chkView)
        Me.Controls.Add(Me.cmdCopyMove)
        Me.Controls.Add(Me.chkOverwrite)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdRefresh)
        Me.Controls.Add(Me.cmdDefSource)
        Me.Controls.Add(Me.filDest)
        Me.Controls.Add(Me.dirDest)
        Me.Controls.Add(Me.drvDest)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.filSource)
        Me.Controls.Add(Me.dirSource)
        Me.Controls.Add(Me.drvSource)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.grpFormat)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "IMG00001"
        Me.Text = "IMG00001 - Image Master Image Upload (IMG01)"
        CType(Me.pBxImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.statusBar.ResumeLayout(False)
        Me.statusBar.PerformLayout()
        Me.grpFolders.ResumeLayout(False)
        Me.grpFolders.PerformLayout()
        Me.grpFormat.ResumeLayout(False)
        Me.grpFormat.PerformLayout()
        Me.grpPreview.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblFilname As System.Windows.Forms.Label
    Friend WithEvents pBxImage As System.Windows.Forms.PictureBox
    Friend WithEvents statusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents grpFolders As System.Windows.Forms.GroupBox
    Friend WithEvents optExceptImgFolder As System.Windows.Forms.RadioButton
    Friend WithEvents optUploadImgFolder As System.Windows.Forms.RadioButton
    Friend WithEvents lblOther As System.Windows.Forms.Label
    Friend WithEvents lblDup As System.Windows.Forms.Label
    Friend WithEvents lblExcept As System.Windows.Forms.Label
    Friend WithEvents lblNumFil As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents txtLog As System.Windows.Forms.TextBox
    Friend WithEvents tmpCount As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblNumFilSource As System.Windows.Forms.Label
    Friend WithEvents lblServerName As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdRefreshLst As System.Windows.Forms.Button
    Friend WithEvents cmdSelectAll As System.Windows.Forms.Button
    Friend WithEvents imgListFolders As System.Windows.Forms.ImageList
    Friend WithEvents chkViewCont As System.Windows.Forms.CheckBox
    Friend WithEvents chkView As System.Windows.Forms.CheckBox
    Friend WithEvents cmdCopyMove As System.Windows.Forms.Button
    Friend WithEvents chkOverwrite As System.Windows.Forms.CheckBox
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents cmdDefSource As System.Windows.Forms.Button
    Friend WithEvents filDest As System.Windows.Forms.ListBox
    Friend WithEvents dirDest As System.Windows.Forms.TreeView
    Friend WithEvents drvDest As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents filSource As System.Windows.Forms.ListBox
    Friend WithEvents dirSource As System.Windows.Forms.TreeView
    Friend WithEvents drvSource As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grpFormat As System.Windows.Forms.GroupBox
    Friend WithEvents grpPreview As System.Windows.Forms.GroupBox
End Class
