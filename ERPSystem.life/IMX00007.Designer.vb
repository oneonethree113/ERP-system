<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IMX00007
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IMX00007))
        Me.browseFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.cmdClear = New System.Windows.Forms.Button
        Me.tabFrame = New ERPSystem.BaseTabControl
        Me.tabUpload = New System.Windows.Forms.TabPage
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdBrowse = New System.Windows.Forms.Button
        Me.txtFilePath = New System.Windows.Forms.TextBox
        Me.cmdUpload = New System.Windows.Forms.Button
        Me.TabApproval = New System.Windows.Forms.TabPage
        Me.cmdSave = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdApply = New System.Windows.Forms.Button
        Me.optReject = New System.Windows.Forms.RadioButton
        Me.optApprove = New System.Windows.Forms.RadioButton
        Me.txtApplyFrom = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtApplyTo = New System.Windows.Forms.TextBox
        Me.grdApproval = New System.Windows.Forms.DataGridView
        Me.tabInvalid = New System.Windows.Forms.TabPage
        Me.grdInvalid = New System.Windows.Forms.DataGridView
        Me.tabFrame.SuspendLayout()
        Me.tabUpload.SuspendLayout()
        Me.TabApproval.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdApproval, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabInvalid.SuspendLayout()
        CType(Me.grdInvalid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'browseFileDialog
        '
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(553, 2)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(75, 20)
        Me.cmdClear.TabIndex = 3
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'tabFrame
        '
        Me.tabFrame.Controls.Add(Me.tabUpload)
        Me.tabFrame.Controls.Add(Me.TabApproval)
        Me.tabFrame.Controls.Add(Me.tabInvalid)
        Me.tabFrame.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.tabFrame.Location = New System.Drawing.Point(0, 3)
        Me.tabFrame.Name = "tabFrame"
        Me.tabFrame.SelectedIndex = 0
        Me.tabFrame.Size = New System.Drawing.Size(632, 405)
        Me.tabFrame.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabFrame.TabIndex = 2
        '
        'tabUpload
        '
        Me.tabUpload.Controls.Add(Me.Label3)
        Me.tabUpload.Controls.Add(Me.cmdBrowse)
        Me.tabUpload.Controls.Add(Me.txtFilePath)
        Me.tabUpload.Controls.Add(Me.cmdUpload)
        Me.tabUpload.Location = New System.Drawing.Point(4, 22)
        Me.tabUpload.Name = "tabUpload"
        Me.tabUpload.Padding = New System.Windows.Forms.Padding(3)
        Me.tabUpload.Size = New System.Drawing.Size(624, 379)
        Me.tabUpload.TabIndex = 0
        Me.tabUpload.Text = "Upload"
        Me.tabUpload.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(132, 181)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(339, 12)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Make sure to select the correct Excel File before you PRESS PROCESS."
        '
        'cmdBrowse
        '
        Me.cmdBrowse.Location = New System.Drawing.Point(462, 93)
        Me.cmdBrowse.Name = "cmdBrowse"
        Me.cmdBrowse.Size = New System.Drawing.Size(86, 23)
        Me.cmdBrowse.TabIndex = 4
        Me.cmdBrowse.Text = "Browse"
        Me.cmdBrowse.UseVisualStyleBackColor = True
        '
        'txtFilePath
        '
        Me.txtFilePath.BackColor = System.Drawing.SystemColors.Window
        Me.txtFilePath.Location = New System.Drawing.Point(79, 95)
        Me.txtFilePath.Name = "txtFilePath"
        Me.txtFilePath.ReadOnly = True
        Me.txtFilePath.Size = New System.Drawing.Size(377, 22)
        Me.txtFilePath.TabIndex = 2
        '
        'cmdUpload
        '
        Me.cmdUpload.Location = New System.Drawing.Point(248, 239)
        Me.cmdUpload.Name = "cmdUpload"
        Me.cmdUpload.Size = New System.Drawing.Size(112, 28)
        Me.cmdUpload.TabIndex = 1
        Me.cmdUpload.Text = "PROCESS"
        Me.cmdUpload.UseVisualStyleBackColor = True
        '
        'TabApproval
        '
        Me.TabApproval.Controls.Add(Me.cmdSave)
        Me.TabApproval.Controls.Add(Me.GroupBox1)
        Me.TabApproval.Controls.Add(Me.grdApproval)
        Me.TabApproval.Location = New System.Drawing.Point(4, 22)
        Me.TabApproval.Name = "TabApproval"
        Me.TabApproval.Padding = New System.Windows.Forms.Padding(3)
        Me.TabApproval.Size = New System.Drawing.Size(624, 379)
        Me.TabApproval.TabIndex = 1
        Me.TabApproval.Text = "Approval"
        Me.TabApproval.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(474, 337)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(75, 36)
        Me.cmdSave.TabIndex = 5
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdApply)
        Me.GroupBox1.Controls.Add(Me.optReject)
        Me.GroupBox1.Controls.Add(Me.optApprove)
        Me.GroupBox1.Controls.Add(Me.txtApplyFrom)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtApplyTo)
        Me.GroupBox1.Location = New System.Drawing.Point(45, 330)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(396, 45)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'cmdApply
        '
        Me.cmdApply.Location = New System.Drawing.Point(306, 15)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.Size = New System.Drawing.Size(82, 23)
        Me.cmdApply.TabIndex = 6
        Me.cmdApply.Text = "Apply"
        Me.cmdApply.UseVisualStyleBackColor = True
        '
        'optReject
        '
        Me.optReject.AutoSize = True
        Me.optReject.Location = New System.Drawing.Point(236, 19)
        Me.optReject.Name = "optReject"
        Me.optReject.Size = New System.Drawing.Size(52, 16)
        Me.optReject.TabIndex = 5
        Me.optReject.TabStop = True
        Me.optReject.Text = "Reject"
        Me.optReject.UseVisualStyleBackColor = True
        '
        'optApprove
        '
        Me.optApprove.AutoSize = True
        Me.optApprove.Location = New System.Drawing.Point(156, 19)
        Me.optApprove.Name = "optApprove"
        Me.optApprove.Size = New System.Drawing.Size(64, 16)
        Me.optApprove.TabIndex = 4
        Me.optApprove.TabStop = True
        Me.optApprove.Text = "Approve"
        Me.optApprove.UseVisualStyleBackColor = True
        '
        'txtApplyFrom
        '
        Me.txtApplyFrom.Location = New System.Drawing.Point(12, 16)
        Me.txtApplyFrom.Name = "txtApplyFrom"
        Me.txtApplyFrom.Size = New System.Drawing.Size(44, 22)
        Me.txtApplyFrom.TabIndex = 1
        Me.txtApplyFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(61, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(20, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "TO"
        '
        'txtApplyTo
        '
        Me.txtApplyTo.Location = New System.Drawing.Point(88, 16)
        Me.txtApplyTo.Name = "txtApplyTo"
        Me.txtApplyTo.Size = New System.Drawing.Size(44, 22)
        Me.txtApplyTo.TabIndex = 2
        Me.txtApplyTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'grdApproval
        '
        Me.grdApproval.AllowUserToAddRows = False
        Me.grdApproval.AllowUserToDeleteRows = False
        Me.grdApproval.AllowUserToResizeRows = False
        Me.grdApproval.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdApproval.Location = New System.Drawing.Point(7, 7)
        Me.grdApproval.Name = "grdApproval"
        Me.grdApproval.RowHeadersWidth = 20
        Me.grdApproval.RowTemplate.Height = 24
        Me.grdApproval.Size = New System.Drawing.Size(614, 317)
        Me.grdApproval.TabIndex = 0
        '
        'tabInvalid
        '
        Me.tabInvalid.Controls.Add(Me.grdInvalid)
        Me.tabInvalid.Location = New System.Drawing.Point(4, 22)
        Me.tabInvalid.Name = "tabInvalid"
        Me.tabInvalid.Padding = New System.Windows.Forms.Padding(3)
        Me.tabInvalid.Size = New System.Drawing.Size(624, 379)
        Me.tabInvalid.TabIndex = 2
        Me.tabInvalid.Text = "Invalid"
        Me.tabInvalid.UseVisualStyleBackColor = True
        '
        'grdInvalid
        '
        Me.grdInvalid.AllowUserToAddRows = False
        Me.grdInvalid.AllowUserToDeleteRows = False
        Me.grdInvalid.AllowUserToResizeRows = False
        Me.grdInvalid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdInvalid.Location = New System.Drawing.Point(7, 7)
        Me.grdInvalid.Name = "grdInvalid"
        Me.grdInvalid.RowHeadersVisible = False
        Me.grdInvalid.RowHeadersWidth = 20
        Me.grdInvalid.RowTemplate.Height = 24
        Me.grdInvalid.Size = New System.Drawing.Size(611, 366)
        Me.grdInvalid.TabIndex = 1
        '
        'IMX00007
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(634, 411)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.tabFrame)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "IMX00007"
        Me.Text = "IMX00007 - Temp Item and Real Item Matching Excel File Upload (IMX07)"
        Me.tabFrame.ResumeLayout(False)
        Me.tabUpload.ResumeLayout(False)
        Me.tabUpload.PerformLayout()
        Me.TabApproval.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grdApproval, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabInvalid.ResumeLayout(False)
        CType(Me.grdInvalid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdUpload As System.Windows.Forms.Button
    Friend WithEvents tabFrame As ERPSystem.BaseTabControl
    Friend WithEvents tabUpload As System.Windows.Forms.TabPage
    Friend WithEvents TabApproval As System.Windows.Forms.TabPage
    Friend WithEvents txtFilePath As System.Windows.Forms.TextBox
    Friend WithEvents browseFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cmdBrowse As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grdApproval As System.Windows.Forms.DataGridView
    Friend WithEvents tabInvalid As System.Windows.Forms.TabPage
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents grdInvalid As System.Windows.Forms.DataGridView
    Friend WithEvents txtApplyTo As System.Windows.Forms.TextBox
    Friend WithEvents txtApplyFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents optApprove As System.Windows.Forms.RadioButton
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents optReject As System.Windows.Forms.RadioButton
    Friend WithEvents cmdSave As System.Windows.Forms.Button
End Class
