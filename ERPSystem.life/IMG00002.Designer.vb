<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IMG00002
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IMG00002))
        Me.grpFormat = New System.Windows.Forms.GroupBox
        Me.cboImgNamFormat = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.filSource = New System.Windows.Forms.ListBox
        Me.dirSource = New System.Windows.Forms.TreeView
        Me.imgListFolders = New System.Windows.Forms.ImageList(Me.components)
        Me.drvSource = New System.Windows.Forms.ComboBox
        Me.filDest = New System.Windows.Forms.ListBox
        Me.dirDest = New System.Windows.Forms.TreeView
        Me.drvDest = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdDefSource = New System.Windows.Forms.Button
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.cmdClose = New System.Windows.Forms.Button
        Me.chkOverwrite = New System.Windows.Forms.CheckBox
        Me.cmdCopyMove = New System.Windows.Forms.Button
        Me.chkView = New System.Windows.Forms.CheckBox
        Me.chkViewCont = New System.Windows.Forms.CheckBox
        Me.cmdSelectAll = New System.Windows.Forms.Button
        Me.cmdRefreshLst = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblServerName = New System.Windows.Forms.Label
        Me.lblNumFilSource = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.tmpCount = New System.Windows.Forms.Label
        Me.txtLog = New System.Windows.Forms.TextBox
        Me.lblMessage = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.lblNumFil = New System.Windows.Forms.Label
        Me.lblExcept = New System.Windows.Forms.Label
        Me.lblDup = New System.Windows.Forms.Label
        Me.lblOther = New System.Windows.Forms.Label
        Me.pBxImage = New System.Windows.Forms.PictureBox
        Me.grpFolders = New System.Windows.Forms.GroupBox
        Me.optExceptImgFolder = New System.Windows.Forms.RadioButton
        Me.optUploadImgFolder = New System.Windows.Forms.RadioButton
        Me.statusBar = New System.Windows.Forms.StatusStrip
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblFilname = New System.Windows.Forms.Label
        Me.grpFormat.SuspendLayout()
        CType(Me.pBxImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFolders.SuspendLayout()
        Me.statusBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpFormat
        '
        Me.grpFormat.Controls.Add(Me.cboImgNamFormat)
        Me.grpFormat.Controls.Add(Me.Label1)
        Me.grpFormat.Location = New System.Drawing.Point(10, 3)
        Me.grpFormat.Name = "grpFormat"
        Me.grpFormat.Size = New System.Drawing.Size(193, 49)
        Me.grpFormat.TabIndex = 0
        Me.grpFormat.TabStop = False
        '
        'cboImgNamFormat
        '
        Me.cboImgNamFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboImgNamFormat.FormattingEnabled = True
        Me.cboImgNamFormat.Location = New System.Drawing.Point(78, 17)
        Me.cboImgNamFormat.Name = "cboImgNamFormat"
        Me.cboImgNamFormat.Size = New System.Drawing.Size(109, 24)
        Me.cboImgNamFormat.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 34)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Image Name" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Format"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(217, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Source"
        '
        'filSource
        '
        Me.filSource.FormattingEnabled = True
        Me.filSource.ItemHeight = 16
        Me.filSource.Location = New System.Drawing.Point(220, 213)
        Me.filSource.Name = "filSource"
        Me.filSource.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.filSource.Size = New System.Drawing.Size(294, 132)
        Me.filSource.TabIndex = 24
        '
        'dirSource
        '
        Me.dirSource.ImageIndex = 0
        Me.dirSource.ImageList = Me.imgListFolders
        Me.dirSource.Location = New System.Drawing.Point(220, 58)
        Me.dirSource.Name = "dirSource"
        Me.dirSource.SelectedImageIndex = 0
        Me.dirSource.Size = New System.Drawing.Size(294, 140)
        Me.dirSource.TabIndex = 23
        '
        'imgListFolders
        '
        Me.imgListFolders.ImageStream = CType(resources.GetObject("imgListFolders.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgListFolders.TransparentColor = System.Drawing.Color.Transparent
        Me.imgListFolders.Images.SetKeyName(0, "closedfolder.png")
        Me.imgListFolders.Images.SetKeyName(1, "openfolder.png")
        '
        'drvSource
        '
        Me.drvSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drvSource.FormattingEnabled = True
        Me.drvSource.Location = New System.Drawing.Point(220, 31)
        Me.drvSource.Name = "drvSource"
        Me.drvSource.Size = New System.Drawing.Size(294, 24)
        Me.drvSource.TabIndex = 22
        '
        'filDest
        '
        Me.filDest.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.filDest.FormattingEnabled = True
        Me.filDest.ItemHeight = 16
        Me.filDest.Location = New System.Drawing.Point(664, 213)
        Me.filDest.Name = "filDest"
        Me.filDest.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.filDest.Size = New System.Drawing.Size(281, 132)
        Me.filDest.TabIndex = 28
        '
        'dirDest
        '
        Me.dirDest.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.dirDest.ImageIndex = 0
        Me.dirDest.ImageList = Me.imgListFolders
        Me.dirDest.Location = New System.Drawing.Point(664, 58)
        Me.dirDest.Name = "dirDest"
        Me.dirDest.SelectedImageIndex = 0
        Me.dirDest.Size = New System.Drawing.Size(281, 140)
        Me.dirDest.TabIndex = 27
        '
        'drvDest
        '
        Me.drvDest.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.drvDest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.drvDest.Enabled = False
        Me.drvDest.FormattingEnabled = True
        Me.drvDest.Location = New System.Drawing.Point(664, 31)
        Me.drvDest.Name = "drvDest"
        Me.drvDest.Size = New System.Drawing.Size(281, 24)
        Me.drvDest.TabIndex = 26
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(664, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 17)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Destination"
        '
        'cmdDefSource
        '
        Me.cmdDefSource.Location = New System.Drawing.Point(551, 31)
        Me.cmdDefSource.Name = "cmdDefSource"
        Me.cmdDefSource.Size = New System.Drawing.Size(75, 23)
        Me.cmdDefSource.TabIndex = 29
        Me.cmdDefSource.Text = "&Reset All"
        Me.cmdDefSource.UseVisualStyleBackColor = True
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Location = New System.Drawing.Point(551, 61)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(75, 23)
        Me.cmdRefresh.TabIndex = 30
        Me.cmdRefresh.Text = "Re&fresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(551, 91)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 23)
        Me.cmdClose.TabIndex = 31
        Me.cmdClose.Text = "E&xit"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'chkOverwrite
        '
        Me.chkOverwrite.AutoSize = True
        Me.chkOverwrite.Location = New System.Drawing.Point(544, 126)
        Me.chkOverwrite.Name = "chkOverwrite"
        Me.chkOverwrite.Size = New System.Drawing.Size(120, 38)
        Me.chkOverwrite.TabIndex = 32
        Me.chkOverwrite.Text = "Overwrite" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Existing Image"
        Me.chkOverwrite.UseVisualStyleBackColor = True
        '
        'cmdCopyMove
        '
        Me.cmdCopyMove.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCopyMove.Location = New System.Drawing.Point(551, 208)
        Me.cmdCopyMove.Name = "cmdCopyMove"
        Me.cmdCopyMove.Size = New System.Drawing.Size(75, 30)
        Me.cmdCopyMove.TabIndex = 33
        Me.cmdCopyMove.Text = "-&>"
        Me.cmdCopyMove.UseVisualStyleBackColor = True
        '
        'chkView
        '
        Me.chkView.AutoSize = True
        Me.chkView.Location = New System.Drawing.Point(661, 366)
        Me.chkView.Name = "chkView"
        Me.chkView.Size = New System.Drawing.Size(101, 21)
        Me.chkView.TabIndex = 34
        Me.chkView.Text = "View Image"
        Me.chkView.UseVisualStyleBackColor = True
        '
        'chkViewCont
        '
        Me.chkViewCont.AutoSize = True
        Me.chkViewCont.Location = New System.Drawing.Point(661, 386)
        Me.chkViewCont.Name = "chkViewCont"
        Me.chkViewCont.Size = New System.Drawing.Size(112, 21)
        Me.chkViewCont.TabIndex = 35
        Me.chkViewCont.Text = "View Content"
        Me.chkViewCont.UseVisualStyleBackColor = True
        '
        'cmdSelectAll
        '
        Me.cmdSelectAll.Location = New System.Drawing.Point(290, 357)
        Me.cmdSelectAll.Name = "cmdSelectAll"
        Me.cmdSelectAll.Size = New System.Drawing.Size(75, 23)
        Me.cmdSelectAll.TabIndex = 36
        Me.cmdSelectAll.Text = "Select All"
        Me.cmdSelectAll.UseVisualStyleBackColor = True
        '
        'cmdRefreshLst
        '
        Me.cmdRefreshLst.Location = New System.Drawing.Point(375, 357)
        Me.cmdRefreshLst.Name = "cmdRefreshLst"
        Me.cmdRefreshLst.Size = New System.Drawing.Size(75, 23)
        Me.cmdRefreshLst.TabIndex = 37
        Me.cmdRefreshLst.Text = "Refresh"
        Me.cmdRefreshLst.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(287, 387)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 17)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "Number of Files"
        '
        'lblServerName
        '
        Me.lblServerName.AutoSize = True
        Me.lblServerName.Location = New System.Drawing.Point(287, 407)
        Me.lblServerName.MaximumSize = New System.Drawing.Size(160, 13)
        Me.lblServerName.MinimumSize = New System.Drawing.Size(160, 13)
        Me.lblServerName.Name = "lblServerName"
        Me.lblServerName.Size = New System.Drawing.Size(160, 13)
        Me.lblServerName.TabIndex = 39
        Me.lblServerName.Text = "SERVER NAME"
        '
        'lblNumFilSource
        '
        Me.lblNumFilSource.AutoSize = True
        Me.lblNumFilSource.Location = New System.Drawing.Point(395, 387)
        Me.lblNumFilSource.MaximumSize = New System.Drawing.Size(50, 13)
        Me.lblNumFilSource.MinimumSize = New System.Drawing.Size(50, 13)
        Me.lblNumFilSource.Name = "lblNumFilSource"
        Me.lblNumFilSource.Size = New System.Drawing.Size(50, 13)
        Me.lblNumFilSource.TabIndex = 40
        Me.lblNumFilSource.Text = "0"
        Me.lblNumFilSource.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(287, 427)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 17)
        Me.Label5.TabIndex = 41
        Me.Label5.Text = "File Count"
        '
        'tmpCount
        '
        Me.tmpCount.AutoSize = True
        Me.tmpCount.Location = New System.Drawing.Point(395, 427)
        Me.tmpCount.MaximumSize = New System.Drawing.Size(50, 13)
        Me.tmpCount.MinimumSize = New System.Drawing.Size(50, 13)
        Me.tmpCount.Name = "tmpCount"
        Me.tmpCount.Size = New System.Drawing.Size(50, 13)
        Me.tmpCount.TabIndex = 42
        Me.tmpCount.Text = "0"
        Me.tmpCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtLog
        '
        Me.txtLog.BackColor = System.Drawing.Color.White
        Me.txtLog.Location = New System.Drawing.Point(13, 450)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ReadOnly = True
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLog.Size = New System.Drawing.Size(945, 81)
        Me.txtLog.TabIndex = 43
        Me.txtLog.TabStop = False
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Location = New System.Drawing.Point(774, 362)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(155, 17)
        Me.lblMessage.TabIndex = 44
        Me.lblMessage.Text = "Number of Copied Files"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(774, 382)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(169, 17)
        Me.Label7.TabIndex = 45
        Me.Label7.Text = "Number of Excepted Files"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(774, 402)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(178, 17)
        Me.Label8.TabIndex = 46
        Me.Label8.Text = "Number of Duplicated Files"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(774, 422)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(147, 17)
        Me.Label9.TabIndex = 47
        Me.Label9.Text = "Number of Other Files"
        '
        'lblNumFil
        '
        Me.lblNumFil.AutoSize = True
        Me.lblNumFil.Location = New System.Drawing.Point(914, 366)
        Me.lblNumFil.MaximumSize = New System.Drawing.Size(40, 13)
        Me.lblNumFil.MinimumSize = New System.Drawing.Size(40, 13)
        Me.lblNumFil.Name = "lblNumFil"
        Me.lblNumFil.Size = New System.Drawing.Size(40, 13)
        Me.lblNumFil.TabIndex = 48
        Me.lblNumFil.Text = "0"
        Me.lblNumFil.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblExcept
        '
        Me.lblExcept.AutoSize = True
        Me.lblExcept.Location = New System.Drawing.Point(914, 387)
        Me.lblExcept.MaximumSize = New System.Drawing.Size(40, 13)
        Me.lblExcept.MinimumSize = New System.Drawing.Size(40, 13)
        Me.lblExcept.Name = "lblExcept"
        Me.lblExcept.Size = New System.Drawing.Size(40, 13)
        Me.lblExcept.TabIndex = 49
        Me.lblExcept.Text = "0"
        Me.lblExcept.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDup
        '
        Me.lblDup.AutoSize = True
        Me.lblDup.Location = New System.Drawing.Point(914, 407)
        Me.lblDup.MaximumSize = New System.Drawing.Size(40, 13)
        Me.lblDup.MinimumSize = New System.Drawing.Size(40, 13)
        Me.lblDup.Name = "lblDup"
        Me.lblDup.Size = New System.Drawing.Size(40, 13)
        Me.lblDup.TabIndex = 50
        Me.lblDup.Text = "0"
        Me.lblDup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblOther
        '
        Me.lblOther.AutoSize = True
        Me.lblOther.Location = New System.Drawing.Point(914, 427)
        Me.lblOther.MaximumSize = New System.Drawing.Size(40, 13)
        Me.lblOther.MinimumSize = New System.Drawing.Size(40, 13)
        Me.lblOther.Name = "lblOther"
        Me.lblOther.Size = New System.Drawing.Size(40, 13)
        Me.lblOther.TabIndex = 51
        Me.lblOther.Text = "0"
        Me.lblOther.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblOther.Visible = False
        '
        'pBxImage
        '
        Me.pBxImage.Location = New System.Drawing.Point(10, 134)
        Me.pBxImage.MaximumSize = New System.Drawing.Size(193, 204)
        Me.pBxImage.Name = "pBxImage"
        Me.pBxImage.Size = New System.Drawing.Size(193, 204)
        Me.pBxImage.TabIndex = 52
        Me.pBxImage.TabStop = False
        '
        'grpFolders
        '
        Me.grpFolders.Controls.Add(Me.optExceptImgFolder)
        Me.grpFolders.Controls.Add(Me.optUploadImgFolder)
        Me.grpFolders.Location = New System.Drawing.Point(10, 58)
        Me.grpFolders.Name = "grpFolders"
        Me.grpFolders.Size = New System.Drawing.Size(193, 69)
        Me.grpFolders.TabIndex = 54
        Me.grpFolders.TabStop = False
        Me.grpFolders.Text = "Folders"
        '
        'optExceptImgFolder
        '
        Me.optExceptImgFolder.AutoSize = True
        Me.optExceptImgFolder.Location = New System.Drawing.Point(24, 43)
        Me.optExceptImgFolder.Name = "optExceptImgFolder"
        Me.optExceptImgFolder.Size = New System.Drawing.Size(176, 21)
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
        Me.optUploadImgFolder.Size = New System.Drawing.Size(160, 21)
        Me.optUploadImgFolder.TabIndex = 0
        Me.optUploadImgFolder.TabStop = True
        Me.optUploadImgFolder.Text = "Upload Image Folder"
        Me.optUploadImgFolder.UseVisualStyleBackColor = True
        '
        'statusBar
        '
        Me.statusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.statusBar.Location = New System.Drawing.Point(0, 545)
        Me.statusBar.Name = "statusBar"
        Me.statusBar.Size = New System.Drawing.Size(970, 22)
        Me.statusBar.TabIndex = 55
        Me.statusBar.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(0, 17)
        '
        'lblFilname
        '
        Me.lblFilname.AutoSize = True
        Me.lblFilname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFilname.Location = New System.Drawing.Point(13, 426)
        Me.lblFilname.MaximumSize = New System.Drawing.Size(190, 13)
        Me.lblFilname.MinimumSize = New System.Drawing.Size(190, 13)
        Me.lblFilname.Name = "lblFilname"
        Me.lblFilname.Size = New System.Drawing.Size(190, 13)
        Me.lblFilname.TabIndex = 53
        Me.lblFilname.Text = "Image Filename"
        Me.lblFilname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'IMG00002
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(970, 567)
        Me.Controls.Add(Me.lblFilname)
        Me.Controls.Add(Me.pBxImage)
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
        Me.MaximizeBox = False
        Me.Name = "IMG00002"
        Me.Text = "IMG00002 - Image Master Image Upload (External Item)"
        Me.grpFormat.ResumeLayout(False)
        Me.grpFormat.PerformLayout()
        CType(Me.pBxImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFolders.ResumeLayout(False)
        Me.grpFolders.PerformLayout()
        Me.statusBar.ResumeLayout(False)
        Me.statusBar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpFormat As System.Windows.Forms.GroupBox
    Friend WithEvents cboImgNamFormat As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents filSource As System.Windows.Forms.ListBox
    Friend WithEvents dirSource As System.Windows.Forms.TreeView
    Friend WithEvents drvSource As System.Windows.Forms.ComboBox
    Friend WithEvents filDest As System.Windows.Forms.ListBox
    Friend WithEvents dirDest As System.Windows.Forms.TreeView
    Friend WithEvents drvDest As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdDefSource As System.Windows.Forms.Button
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents chkOverwrite As System.Windows.Forms.CheckBox
    Friend WithEvents cmdCopyMove As System.Windows.Forms.Button
    Friend WithEvents chkView As System.Windows.Forms.CheckBox
    Friend WithEvents chkViewCont As System.Windows.Forms.CheckBox
    Friend WithEvents cmdSelectAll As System.Windows.Forms.Button
    Friend WithEvents cmdRefreshLst As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblServerName As System.Windows.Forms.Label
    Friend WithEvents lblNumFilSource As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tmpCount As System.Windows.Forms.Label
    Friend WithEvents txtLog As System.Windows.Forms.TextBox
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblNumFil As System.Windows.Forms.Label
    Friend WithEvents lblExcept As System.Windows.Forms.Label
    Friend WithEvents lblDup As System.Windows.Forms.Label
    Friend WithEvents lblOther As System.Windows.Forms.Label
    Friend WithEvents pBxImage As System.Windows.Forms.PictureBox
    Friend WithEvents grpFolders As System.Windows.Forms.GroupBox
    Friend WithEvents optExceptImgFolder As System.Windows.Forms.RadioButton
    Friend WithEvents optUploadImgFolder As System.Windows.Forms.RadioButton
    Friend WithEvents imgListFolders As System.Windows.Forms.ImageList
    Friend WithEvents statusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblFilname As System.Windows.Forms.Label
End Class
