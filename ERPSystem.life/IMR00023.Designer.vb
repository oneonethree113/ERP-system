<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IMR00023
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IMR00023))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.drvSource = New System.Windows.Forms.ComboBox
        Me.filSource = New System.Windows.Forms.ListBox
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me.txtProcess = New System.Windows.Forms.RichTextBox
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.dirSource = New System.Windows.Forms.TreeView
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Source Folder"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Crimson
        Me.Label2.Location = New System.Drawing.Point(12, 200)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(269, 24)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Please make sure you select the correct Excel File Folder " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "before you PRESS OK."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 237)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 12)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Processing :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(371, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 12)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Excel File Listing"
        '
        'drvSource
        '
        Me.drvSource.FormattingEnabled = True
        Me.drvSource.Location = New System.Drawing.Point(5, 32)
        Me.drvSource.Name = "drvSource"
        Me.drvSource.Size = New System.Drawing.Size(362, 20)
        Me.drvSource.TabIndex = 1
        '
        'filSource
        '
        Me.filSource.FormattingEnabled = True
        Me.filSource.ItemHeight = 12
        Me.filSource.Location = New System.Drawing.Point(373, 32)
        Me.filSource.Name = "filSource"
        Me.filSource.Size = New System.Drawing.Size(247, 148)
        Me.filSource.TabIndex = 3
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Location = New System.Drawing.Point(449, 186)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(75, 21)
        Me.cmdRefresh.TabIndex = 4
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(545, 186)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 21)
        Me.cmdOK.TabIndex = 5
        Me.cmdOK.Text = "Process"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'txtProcess
        '
        Me.txtProcess.Location = New System.Drawing.Point(5, 252)
        Me.txtProcess.Name = "txtProcess"
        Me.txtProcess.Size = New System.Drawing.Size(617, 96)
        Me.txtProcess.TabIndex = 6
        Me.txtProcess.Text = ""
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(5, 350)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(617, 21)
        Me.ProgressBar1.TabIndex = 10
        '
        'dirSource
        '
        Me.dirSource.Location = New System.Drawing.Point(5, 57)
        Me.dirSource.Name = "dirSource"
        Me.dirSource.Size = New System.Drawing.Size(362, 123)
        Me.dirSource.TabIndex = 2
        '
        'IMR00023
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 377)
        Me.Controls.Add(Me.dirSource)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.txtProcess)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmdRefresh)
        Me.Controls.Add(Me.filSource)
        Me.Controls.Add(Me.drvSource)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(640, 406)
        Me.MinimumSize = New System.Drawing.Size(640, 406)
        Me.Name = "IMR00023"
        Me.Text = "IMR00023 - Export Item Image to Excel (IMR23)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents drvSource As System.Windows.Forms.ComboBox
    Friend WithEvents filSource As System.Windows.Forms.ListBox
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents txtProcess As System.Windows.Forms.RichTextBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents dirSource As System.Windows.Forms.TreeView
End Class
