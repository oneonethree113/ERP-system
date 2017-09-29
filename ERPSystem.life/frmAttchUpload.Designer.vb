<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAttchUpload
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
        Me.txtModule = New System.Windows.Forms.TextBox
        Me.txtDocNo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.grpSrc = New System.Windows.Forms.GroupBox
        Me.cmdSrcRemove = New System.Windows.Forms.Button
        Me.cmdSrcImport = New System.Windows.Forms.Button
        Me.cmdSrcPreview = New System.Windows.Forms.Button
        Me.cmdSrcLoad = New System.Windows.Forms.Button
        Me.dgSrc = New System.Windows.Forms.DataGridView
        Me.grpDest = New System.Windows.Forms.GroupBox
        Me.cmdDestDelete = New System.Windows.Forms.Button
        Me.cmdDestPreview = New System.Windows.Forms.Button
        Me.cmdDestRefresh = New System.Windows.Forms.Button
        Me.dgDst = New System.Windows.Forms.DataGridView
        Me.txtCoCde = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdExit = New System.Windows.Forms.Button
        Me.LoadFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.grpSrc.SuspendLayout()
        CType(Me.dgSrc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDest.SuspendLayout()
        CType(Me.dgDst, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(175, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Document Type"
        '
        'txtModule
        '
        Me.txtModule.BackColor = System.Drawing.Color.White
        Me.txtModule.Enabled = False
        Me.txtModule.ForeColor = System.Drawing.Color.Black
        Me.txtModule.Location = New System.Drawing.Point(264, 10)
        Me.txtModule.Name = "txtModule"
        Me.txtModule.Size = New System.Drawing.Size(132, 20)
        Me.txtModule.TabIndex = 1
        '
        'txtDocNo
        '
        Me.txtDocNo.BackColor = System.Drawing.Color.White
        Me.txtDocNo.Enabled = False
        Me.txtDocNo.ForeColor = System.Drawing.Color.Black
        Me.txtDocNo.Location = New System.Drawing.Point(497, 10)
        Me.txtDocNo.Name = "txtDocNo"
        Me.txtDocNo.Size = New System.Drawing.Size(132, 20)
        Me.txtDocNo.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(415, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Document No."
        '
        'grpSrc
        '
        Me.grpSrc.Controls.Add(Me.cmdSrcRemove)
        Me.grpSrc.Controls.Add(Me.cmdSrcImport)
        Me.grpSrc.Controls.Add(Me.cmdSrcPreview)
        Me.grpSrc.Controls.Add(Me.cmdSrcLoad)
        Me.grpSrc.Controls.Add(Me.dgSrc)
        Me.grpSrc.Location = New System.Drawing.Point(12, 36)
        Me.grpSrc.Name = "grpSrc"
        Me.grpSrc.Size = New System.Drawing.Size(330, 320)
        Me.grpSrc.TabIndex = 4
        Me.grpSrc.TabStop = False
        Me.grpSrc.Text = "Source Directory"
        '
        'cmdSrcRemove
        '
        Me.cmdSrcRemove.Location = New System.Drawing.Point(249, 291)
        Me.cmdSrcRemove.Name = "cmdSrcRemove"
        Me.cmdSrcRemove.Size = New System.Drawing.Size(75, 23)
        Me.cmdSrcRemove.TabIndex = 4
        Me.cmdSrcRemove.Text = "&Remo&ve"
        Me.cmdSrcRemove.UseVisualStyleBackColor = True
        '
        'cmdSrcImport
        '
        Me.cmdSrcImport.Location = New System.Drawing.Point(168, 291)
        Me.cmdSrcImport.Name = "cmdSrcImport"
        Me.cmdSrcImport.Size = New System.Drawing.Size(75, 23)
        Me.cmdSrcImport.TabIndex = 3
        Me.cmdSrcImport.Text = "&Import"
        Me.cmdSrcImport.UseVisualStyleBackColor = True
        '
        'cmdSrcPreview
        '
        Me.cmdSrcPreview.Location = New System.Drawing.Point(87, 291)
        Me.cmdSrcPreview.Name = "cmdSrcPreview"
        Me.cmdSrcPreview.Size = New System.Drawing.Size(75, 23)
        Me.cmdSrcPreview.TabIndex = 2
        Me.cmdSrcPreview.Text = "Preview"
        Me.cmdSrcPreview.UseVisualStyleBackColor = True
        '
        'cmdSrcLoad
        '
        Me.cmdSrcLoad.Location = New System.Drawing.Point(6, 291)
        Me.cmdSrcLoad.Name = "cmdSrcLoad"
        Me.cmdSrcLoad.Size = New System.Drawing.Size(75, 23)
        Me.cmdSrcLoad.TabIndex = 1
        Me.cmdSrcLoad.Text = "&Load"
        Me.cmdSrcLoad.UseVisualStyleBackColor = True
        '
        'dgSrc
        '
        Me.dgSrc.AllowUserToAddRows = False
        Me.dgSrc.AllowUserToDeleteRows = False
        Me.dgSrc.ColumnHeadersHeight = 20
        Me.dgSrc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgSrc.Location = New System.Drawing.Point(6, 21)
        Me.dgSrc.Name = "dgSrc"
        Me.dgSrc.RowHeadersWidth = 21
        Me.dgSrc.RowTemplate.Height = 20
        Me.dgSrc.Size = New System.Drawing.Size(318, 264)
        Me.dgSrc.TabIndex = 0
        '
        'grpDest
        '
        Me.grpDest.Controls.Add(Me.cmdDestDelete)
        Me.grpDest.Controls.Add(Me.cmdDestPreview)
        Me.grpDest.Controls.Add(Me.cmdDestRefresh)
        Me.grpDest.Controls.Add(Me.dgDst)
        Me.grpDest.Location = New System.Drawing.Point(352, 36)
        Me.grpDest.Name = "grpDest"
        Me.grpDest.Size = New System.Drawing.Size(330, 320)
        Me.grpDest.TabIndex = 5
        Me.grpDest.TabStop = False
        Me.grpDest.Text = "Destination Directory"
        '
        'cmdDestDelete
        '
        Me.cmdDestDelete.Location = New System.Drawing.Point(249, 291)
        Me.cmdDestDelete.Name = "cmdDestDelete"
        Me.cmdDestDelete.Size = New System.Drawing.Size(75, 23)
        Me.cmdDestDelete.TabIndex = 7
        Me.cmdDestDelete.Text = "&Delete"
        Me.cmdDestDelete.UseVisualStyleBackColor = True
        '
        'cmdDestPreview
        '
        Me.cmdDestPreview.Location = New System.Drawing.Point(87, 291)
        Me.cmdDestPreview.Name = "cmdDestPreview"
        Me.cmdDestPreview.Size = New System.Drawing.Size(75, 23)
        Me.cmdDestPreview.TabIndex = 6
        Me.cmdDestPreview.Text = "Preview"
        Me.cmdDestPreview.UseVisualStyleBackColor = True
        '
        'cmdDestRefresh
        '
        Me.cmdDestRefresh.Location = New System.Drawing.Point(6, 291)
        Me.cmdDestRefresh.Name = "cmdDestRefresh"
        Me.cmdDestRefresh.Size = New System.Drawing.Size(75, 23)
        Me.cmdDestRefresh.TabIndex = 5
        Me.cmdDestRefresh.Text = "&Refresh"
        Me.cmdDestRefresh.UseVisualStyleBackColor = True
        '
        'dgDst
        '
        Me.dgDst.AllowUserToAddRows = False
        Me.dgDst.AllowUserToDeleteRows = False
        Me.dgDst.ColumnHeadersHeight = 20
        Me.dgDst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgDst.Location = New System.Drawing.Point(6, 21)
        Me.dgDst.Name = "dgDst"
        Me.dgDst.RowHeadersWidth = 21
        Me.dgDst.RowTemplate.Height = 20
        Me.dgDst.Size = New System.Drawing.Size(318, 264)
        Me.dgDst.TabIndex = 4
        '
        'txtCoCde
        '
        Me.txtCoCde.BackColor = System.Drawing.Color.White
        Me.txtCoCde.Enabled = False
        Me.txtCoCde.ForeColor = System.Drawing.Color.Black
        Me.txtCoCde.Location = New System.Drawing.Point(100, 10)
        Me.txtCoCde.Name = "txtCoCde"
        Me.txtCoCde.Size = New System.Drawing.Size(57, 20)
        Me.txtCoCde.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Company Code"
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(601, 362)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(75, 23)
        Me.cmdExit.TabIndex = 8
        Me.cmdExit.Text = "&Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'LoadFileDialog
        '
        Me.LoadFileDialog.Multiselect = True
        '
        'frmAttchUpload
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(694, 393)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.txtCoCde)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.grpDest)
        Me.Controls.Add(Me.grpSrc)
        Me.Controls.Add(Me.txtDocNo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtModule)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(700, 425)
        Me.MinimumSize = New System.Drawing.Size(700, 425)
        Me.Name = "frmAttchUpload"
        Me.Text = "XYZ Attachment File Upload"
        Me.grpSrc.ResumeLayout(False)
        CType(Me.dgSrc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDest.ResumeLayout(False)
        CType(Me.dgDst, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtModule As System.Windows.Forms.TextBox
    Friend WithEvents txtDocNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grpSrc As System.Windows.Forms.GroupBox
    Friend WithEvents grpDest As System.Windows.Forms.GroupBox
    Friend WithEvents dgSrc As System.Windows.Forms.DataGridView
    Friend WithEvents cmdSrcLoad As System.Windows.Forms.Button
    Friend WithEvents cmdSrcImport As System.Windows.Forms.Button
    Friend WithEvents cmdSrcPreview As System.Windows.Forms.Button
    Friend WithEvents cmdDestDelete As System.Windows.Forms.Button
    Friend WithEvents cmdDestPreview As System.Windows.Forms.Button
    Friend WithEvents cmdDestRefresh As System.Windows.Forms.Button
    Friend WithEvents dgDst As System.Windows.Forms.DataGridView
    Friend WithEvents txtCoCde As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdSrcRemove As System.Windows.Forms.Button
    Friend WithEvents LoadFileDialog As System.Windows.Forms.OpenFileDialog
End Class
