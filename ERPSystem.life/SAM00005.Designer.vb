<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SAM00005
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SAM00005))
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtReqNoSet = New System.Windows.Forms.TextBox
        Me.grdDetailSet = New System.Windows.Forms.DataGridView
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.cmdGen = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdInsertItem = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtReqNo = New System.Windows.Forms.TextBox
        Me.grdDetail = New System.Windows.Forms.DataGridView
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdFind = New System.Windows.Forms.Button
        Me.txtCus2Na = New System.Windows.Forms.TextBox
        Me.txtCus1Na = New System.Windows.Forms.TextBox
        Me.lblSec = New System.Windows.Forms.Label
        Me.txtQutNo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblQutno = New System.Windows.Forms.Label
        Me.StatusBar = New System.Windows.Forms.StatusStrip
        Me.lblLeft = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblRight = New System.Windows.Forms.ToolStripStatusLabel
        Me.GroupBox3.SuspendLayout()
        CType(Me.grdDetailSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grdDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtReqNoSet)
        Me.GroupBox3.Controls.Add(Me.grdDetailSet)
        Me.GroupBox3.Location = New System.Drawing.Point(2, 355)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(945, 209)
        Me.GroupBox3.TabIndex = 39
        Me.GroupBox3.TabStop = False
        '
        'txtReqNoSet
        '
        Me.txtReqNoSet.BackColor = System.Drawing.Color.White
        Me.txtReqNoSet.Location = New System.Drawing.Point(7, 140)
        Me.txtReqNoSet.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtReqNoSet.Multiline = True
        Me.txtReqNoSet.Name = "txtReqNoSet"
        Me.txtReqNoSet.ReadOnly = True
        Me.txtReqNoSet.Size = New System.Drawing.Size(927, 62)
        Me.txtReqNoSet.TabIndex = 20
        '
        'grdDetailSet
        '
        Me.grdDetailSet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDetailSet.Location = New System.Drawing.Point(7, 12)
        Me.grdDetailSet.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grdDetailSet.Name = "grdDetailSet"
        Me.grdDetailSet.RowTemplate.Height = 15
        Me.grdDetailSet.Size = New System.Drawing.Size(927, 120)
        Me.grdDetailSet.TabIndex = 19
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(552, 573)
        Me.cmdCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(80, 25)
        Me.cmdCancel.TabIndex = 44
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Location = New System.Drawing.Point(433, 573)
        Me.cmdClearAll.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(80, 25)
        Me.cmdClearAll.TabIndex = 43
        Me.cmdClearAll.Text = "Clea&r All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'cmdGen
        '
        Me.cmdGen.Location = New System.Drawing.Point(314, 573)
        Me.cmdGen.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmdGen.Name = "cmdGen"
        Me.cmdGen.Size = New System.Drawing.Size(80, 25)
        Me.cmdGen.TabIndex = 42
        Me.cmdGen.Text = "&Generate"
        Me.cmdGen.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(496, 330)
        Me.cmdClear.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(80, 25)
        Me.cmdClear.TabIndex = 41
        Me.cmdClear.Text = "Cl&ear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdInsertItem
        '
        Me.cmdInsertItem.Location = New System.Drawing.Point(363, 330)
        Me.cmdInsertItem.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmdInsertItem.Name = "cmdInsertItem"
        Me.cmdInsertItem.Size = New System.Drawing.Size(84, 25)
        Me.cmdInsertItem.TabIndex = 40
        Me.cmdInsertItem.Text = "&Insert Item"
        Me.cmdInsertItem.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtReqNo)
        Me.GroupBox2.Controls.Add(Me.grdDetail)
        Me.GroupBox2.Location = New System.Drawing.Point(2, 121)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(945, 208)
        Me.GroupBox2.TabIndex = 38
        Me.GroupBox2.TabStop = False
        '
        'txtReqNo
        '
        Me.txtReqNo.BackColor = System.Drawing.Color.White
        Me.txtReqNo.Location = New System.Drawing.Point(7, 140)
        Me.txtReqNo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtReqNo.Multiline = True
        Me.txtReqNo.Name = "txtReqNo"
        Me.txtReqNo.ReadOnly = True
        Me.txtReqNo.Size = New System.Drawing.Size(927, 62)
        Me.txtReqNo.TabIndex = 16
        '
        'grdDetail
        '
        Me.grdDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDetail.Location = New System.Drawing.Point(7, 12)
        Me.grdDetail.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grdDetail.Name = "grdDetail"
        Me.grdDetail.RowTemplate.Height = 15
        Me.grdDetail.Size = New System.Drawing.Size(927, 120)
        Me.grdDetail.TabIndex = 15
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.Color.White
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.Location = New System.Drawing.Point(437, 6)
        Me.txtCoNam.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.Size = New System.Drawing.Size(509, 22)
        Me.txtCoNam.TabIndex = 26
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(329, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 12)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "Company Name :"
        '
        'cboCoCde
        '
        Me.cboCoCde.BackColor = System.Drawing.Color.White
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(145, 6)
        Me.cboCoCde.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(117, 20)
        Me.cboCoCde.TabIndex = 25
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 12)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Company Code"
        '
        'cmdFind
        '
        Me.cmdFind.Location = New System.Drawing.Point(268, 35)
        Me.cmdFind.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(49, 22)
        Me.cmdFind.TabIndex = 24
        Me.cmdFind.Text = "&Show"
        Me.cmdFind.UseVisualStyleBackColor = True
        '
        'txtCus2Na
        '
        Me.txtCus2Na.BackColor = System.Drawing.Color.White
        Me.txtCus2Na.Enabled = False
        Me.txtCus2Na.Location = New System.Drawing.Point(145, 98)
        Me.txtCus2Na.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCus2Na.Name = "txtCus2Na"
        Me.txtCus2Na.Size = New System.Drawing.Size(392, 22)
        Me.txtCus2Na.TabIndex = 27
        '
        'txtCus1Na
        '
        Me.txtCus1Na.BackColor = System.Drawing.Color.White
        Me.txtCus1Na.Enabled = False
        Me.txtCus1Na.Location = New System.Drawing.Point(145, 66)
        Me.txtCus1Na.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCus1Na.Name = "txtCus1Na"
        Me.txtCus1Na.Size = New System.Drawing.Size(392, 22)
        Me.txtCus1Na.TabIndex = 26
        '
        'lblSec
        '
        Me.lblSec.AutoSize = True
        Me.lblSec.Location = New System.Drawing.Point(9, 103)
        Me.lblSec.Name = "lblSec"
        Me.lblSec.Size = New System.Drawing.Size(84, 12)
        Me.lblSec.TabIndex = 25
        Me.lblSec.Text = "Secondary Cust. "
        '
        'txtQutNo
        '
        Me.txtQutNo.BackColor = System.Drawing.Color.White
        Me.txtQutNo.Location = New System.Drawing.Point(145, 36)
        Me.txtQutNo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtQutNo.Name = "txtQutNo"
        Me.txtQutNo.Size = New System.Drawing.Size(117, 22)
        Me.txtQutNo.TabIndex = 22
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 12)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Primary Cust."
        '
        'lblQutno
        '
        Me.lblQutno.AutoSize = True
        Me.lblQutno.Location = New System.Drawing.Point(9, 41)
        Me.lblQutno.Name = "lblQutno"
        Me.lblQutno.Size = New System.Drawing.Size(71, 12)
        Me.lblQutno.TabIndex = 21
        Me.lblQutno.Text = "Quotation No."
        '
        'StatusBar
        '
        Me.StatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblLeft, Me.lblRight})
        Me.StatusBar.Location = New System.Drawing.Point(0, 613)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Size = New System.Drawing.Size(954, 22)
        Me.StatusBar.TabIndex = 203
        Me.StatusBar.Text = "StatusStrip1"
        '
        'lblLeft
        '
        Me.lblLeft.AutoSize = False
        Me.lblLeft.Name = "lblLeft"
        Me.lblLeft.Size = New System.Drawing.Size(400, 17)
        Me.lblLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRight
        '
        Me.lblRight.AutoSize = False
        Me.lblRight.Name = "lblRight"
        Me.lblRight.Size = New System.Drawing.Size(539, 17)
        Me.lblRight.Spring = True
        Me.lblRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SAM00005
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(954, 635)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.cmdFind)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.txtCus2Na)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.txtCus1Na)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.lblSec)
        Me.Controls.Add(Me.cmdGen)
        Me.Controls.Add(Me.txtQutNo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.lblQutno)
        Me.Controls.Add(Me.cmdInsertItem)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(960, 660)
        Me.MinimumSize = New System.Drawing.Size(960, 660)
        Me.Name = "SAM00005"
        Me.Text = "SAM00005 - Sample Invoice Generation (SAM05)"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.grdDetailSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.grdDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusBar.ResumeLayout(False)
        Me.StatusBar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtReqNoSet As System.Windows.Forms.TextBox
    Friend WithEvents grdDetailSet As System.Windows.Forms.DataGridView
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents cmdGen As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdInsertItem As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtReqNo As System.Windows.Forms.TextBox
    Friend WithEvents grdDetail As System.Windows.Forms.DataGridView
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdFind As System.Windows.Forms.Button
    Friend WithEvents txtCus2Na As System.Windows.Forms.TextBox
    Friend WithEvents txtCus1Na As System.Windows.Forms.TextBox
    Friend WithEvents lblSec As System.Windows.Forms.Label
    Friend WithEvents txtQutNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblQutno As System.Windows.Forms.Label
    Friend WithEvents StatusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents lblLeft As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblRight As System.Windows.Forms.ToolStripStatusLabel
End Class
