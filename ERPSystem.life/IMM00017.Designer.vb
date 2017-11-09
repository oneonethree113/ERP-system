<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IMM00017
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IMM00017))
        Me.txtProcess = New System.Windows.Forms.TextBox
        Me.cmdOK = New System.Windows.Forms.Button
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.filSource = New System.Windows.Forms.ListBox
        Me.imgListFolders = New System.Windows.Forms.ImageList(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.dirSource = New System.Windows.Forms.TreeView
        Me.drvSource = New System.Windows.Forms.ComboBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.txtfake = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'txtProcess
        '
        Me.txtProcess.BackColor = System.Drawing.Color.White
        Me.txtProcess.Location = New System.Drawing.Point(12, 280)
        Me.txtProcess.Multiline = True
        Me.txtProcess.Name = "txtProcess"
        Me.txtProcess.ReadOnly = True
        Me.txtProcess.Size = New System.Drawing.Size(619, 119)
        Me.txtProcess.TabIndex = 27
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(556, 251)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 26
        Me.cmdOK.Text = "&Process"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Location = New System.Drawing.Point(475, 251)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(75, 23)
        Me.cmdRefresh.TabIndex = 25
        Me.cmdRefresh.Text = "&Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(10, 256)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(372, 12)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Make sure to select the correct Excel File Folder before you PRESS PROCESS."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 12)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Source Folder "
        '
        'filSource
        '
        Me.filSource.FormattingEnabled = True
        Me.filSource.ItemHeight = 12
        Me.filSource.Location = New System.Drawing.Point(417, 24)
        Me.filSource.Name = "filSource"
        Me.filSource.Size = New System.Drawing.Size(214, 220)
        Me.filSource.TabIndex = 21
        '
        'imgListFolders
        '
        Me.imgListFolders.ImageStream = CType(resources.GetObject("imgListFolders.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgListFolders.TransparentColor = System.Drawing.Color.Transparent
        Me.imgListFolders.Images.SetKeyName(0, "closedfolder.png")
        Me.imgListFolders.Images.SetKeyName(1, "openfolder.png")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(417, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 12)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Excel File Listing"
        '
        'dirSource
        '
        Me.dirSource.ImageIndex = 0
        Me.dirSource.ImageList = Me.imgListFolders
        Me.dirSource.Location = New System.Drawing.Point(12, 51)
        Me.dirSource.Name = "dirSource"
        Me.dirSource.SelectedImageIndex = 1
        Me.dirSource.Size = New System.Drawing.Size(399, 193)
        Me.dirSource.TabIndex = 20
        '
        'drvSource
        '
        Me.drvSource.FormattingEnabled = True
        Me.drvSource.Location = New System.Drawing.Point(12, 24)
        Me.drvSource.Name = "drvSource"
        Me.drvSource.Size = New System.Drawing.Size(399, 20)
        Me.drvSource.TabIndex = 19
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(454, 410)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 22)
        Me.Button1.TabIndex = 28
        Me.Button1.Text = "Fake"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'txtfake
        '
        Me.txtfake.Location = New System.Drawing.Point(207, 410)
        Me.txtfake.Name = "txtfake"
        Me.txtfake.Size = New System.Drawing.Size(241, 22)
        Me.txtfake.TabIndex = 29
        Me.txtfake.Text = "16A001A001A01"
        Me.txtfake.Visible = False
        '
        'IMM00017
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(634, 411)
        Me.Controls.Add(Me.txtfake)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtProcess)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmdRefresh)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.filSource)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dirSource)
        Me.Controls.Add(Me.drvSource)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "IMM00017"
        Me.Text = "IMM00017 - IM Quote Chase Export Excel (IMM17)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtProcess As System.Windows.Forms.TextBox
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents filSource As System.Windows.Forms.ListBox
    Friend WithEvents imgListFolders As System.Windows.Forms.ImageList
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dirSource As System.Windows.Forms.TreeView
    Friend WithEvents drvSource As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtfake As System.Windows.Forms.TextBox
End Class
