<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCombineImage
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UploadImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DiscardImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReloadImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdCombine = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.txtItmNo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(547, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UploadImageToolStripMenuItem, Me.DiscardImageToolStripMenuItem, Me.ReloadImageToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'UploadImageToolStripMenuItem
        '
        Me.UploadImageToolStripMenuItem.Name = "UploadImageToolStripMenuItem"
        Me.UploadImageToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.UploadImageToolStripMenuItem.Text = "Upload Image"
        '
        'DiscardImageToolStripMenuItem
        '
        Me.DiscardImageToolStripMenuItem.Enabled = False
        Me.DiscardImageToolStripMenuItem.Name = "DiscardImageToolStripMenuItem"
        Me.DiscardImageToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.DiscardImageToolStripMenuItem.Text = "Discard Image"
        '
        'ReloadImageToolStripMenuItem
        '
        Me.ReloadImageToolStripMenuItem.Name = "ReloadImageToolStripMenuItem"
        Me.ReloadImageToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.ReloadImageToolStripMenuItem.Text = "Reload Image"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'cmdCombine
        '
        Me.cmdCombine.Location = New System.Drawing.Point(478, 0)
        Me.cmdCombine.Name = "cmdCombine"
        Me.cmdCombine.Size = New System.Drawing.Size(62, 26)
        Me.cmdCombine.TabIndex = 1
        Me.cmdCombine.Text = "Combine"
        Me.cmdCombine.UseVisualStyleBackColor = True
        Me.cmdCombine.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Location = New System.Drawing.Point(0, 27)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(540, 540)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'txtItmNo
        '
        Me.txtItmNo.Location = New System.Drawing.Point(307, 4)
        Me.txtItmNo.Name = "txtItmNo"
        Me.txtItmNo.Size = New System.Drawing.Size(150, 20)
        Me.txtItmNo.TabIndex = 3
        Me.txtItmNo.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(103, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Label1"
        Me.Label1.Visible = False
        '
        'frmCombineImage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(547, 576)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtItmNo)
        Me.Controls.Add(Me.cmdCombine)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.PictureBox1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCombineImage"
        Me.Text = "frmCombineImage"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdCombine As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtItmNo As System.Windows.Forms.TextBox
    Friend WithEvents UploadImageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DiscardImageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReloadImageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
