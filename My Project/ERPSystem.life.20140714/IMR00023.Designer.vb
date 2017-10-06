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
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Source Folder:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Crimson
        Me.Label2.Location = New System.Drawing.Point(12, 217)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(279, 26)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Please make sure you select the correct Excel File Folder " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "before you PRESS OK."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 257)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Processing :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(319, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Excel File Listing"
        '
        'drvSource
        '
        Me.drvSource.FormattingEnabled = True
        Me.drvSource.Location = New System.Drawing.Point(5, 35)
        Me.drvSource.Name = "drvSource"
        Me.drvSource.Size = New System.Drawing.Size(286, 21)
        Me.drvSource.TabIndex = 1
        '
        'filSource
        '
        Me.filSource.FormattingEnabled = True
        Me.filSource.Location = New System.Drawing.Point(322, 35)
        Me.filSource.Name = "filSource"
        Me.filSource.Size = New System.Drawing.Size(247, 160)
        Me.filSource.TabIndex = 3
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Location = New System.Drawing.Point(398, 201)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(75, 23)
        Me.cmdRefresh.TabIndex = 4
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(494, 201)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 5
        Me.cmdOK.Text = "Process"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'txtProcess
        '
        Me.txtProcess.Location = New System.Drawing.Point(5, 273)
        Me.txtProcess.Name = "txtProcess"
        Me.txtProcess.Size = New System.Drawing.Size(564, 104)
        Me.txtProcess.TabIndex = 6
        Me.txtProcess.Text = ""
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(5, 379)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(564, 23)
        Me.ProgressBar1.TabIndex = 10
        '
        'dirSource
        '
        Me.dirSource.Location = New System.Drawing.Point(5, 62)
        Me.dirSource.Name = "dirSource"
        Me.dirSource.Size = New System.Drawing.Size(286, 133)
        Me.dirSource.TabIndex = 2
        '
        'IMR00023
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(575, 403)
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
        Me.MaximumSize = New System.Drawing.Size(583, 437)
        Me.MinimumSize = New System.Drawing.Size(583, 437)
        Me.Name = "IMR00023"
        Me.Text = "IMR00023 - Export Item Image to Excel"
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
