<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TOM00002
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TOM00002))
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.lblQutno = New System.Windows.Forms.Label
        Me.lblPri = New System.Windows.Forms.Label
        Me.txtQutNo = New System.Windows.Forms.TextBox
        Me.lblSec = New System.Windows.Forms.Label
        Me.txtCus1Na = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtCus2Na = New System.Windows.Forms.TextBox
        Me.lblFrom = New System.Windows.Forms.Label
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.cmdFind = New System.Windows.Forms.Button
        Me.chkZeroQty = New System.Windows.Forms.CheckBox
        Me.cmdSearch = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdApply = New System.Windows.Forms.Button
        Me.txtTo = New System.Windows.Forms.TextBox
        Me.txtFrom = New System.Windows.Forms.TextBox
        Me.lblTo = New System.Windows.Forms.Label
        Me.txtCusQty = New System.Windows.Forms.TextBox
        Me.txtStkQty = New System.Windows.Forms.TextBox
        Me.lblCusQty = New System.Windows.Forms.Label
        Me.lblStkQty = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtReqNo = New System.Windows.Forms.TextBox
        Me.grdDetail = New System.Windows.Forms.DataGridView
        Me.cmdInsertItem = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdGen = New System.Windows.Forms.Button
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtReqNoSet = New System.Windows.Forms.TextBox
        Me.grdDetailSet = New System.Windows.Forms.DataGridView
        Me.cmdApplyA = New System.Windows.Forms.Button
        Me.StatusBar = New System.Windows.Forms.StatusStrip
        Me.lblLeft = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblRight = New System.Windows.Forms.ToolStripStatusLabel
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grdDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.grdDetailSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Company Code"
        '
        'cboCoCde
        '
        Me.cboCoCde.BackColor = System.Drawing.Color.White
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(145, 6)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(117, 20)
        Me.cboCoCde.TabIndex = 1
        '
        'lblQutno
        '
        Me.lblQutno.AutoSize = True
        Me.lblQutno.Location = New System.Drawing.Point(9, 41)
        Me.lblQutno.Name = "lblQutno"
        Me.lblQutno.Size = New System.Drawing.Size(71, 12)
        Me.lblQutno.TabIndex = 2
        Me.lblQutno.Text = "Quotation No."
        '
        'lblPri
        '
        Me.lblPri.AutoSize = True
        Me.lblPri.Location = New System.Drawing.Point(9, 73)
        Me.lblPri.Name = "lblPri"
        Me.lblPri.Size = New System.Drawing.Size(90, 12)
        Me.lblPri.TabIndex = 3
        Me.lblPri.Text = "Primary Customer"
        '
        'txtQutNo
        '
        Me.txtQutNo.BackColor = System.Drawing.Color.White
        Me.txtQutNo.Location = New System.Drawing.Point(145, 36)
        Me.txtQutNo.Name = "txtQutNo"
        Me.txtQutNo.Size = New System.Drawing.Size(117, 22)
        Me.txtQutNo.TabIndex = 3
        '
        'lblSec
        '
        Me.lblSec.AutoSize = True
        Me.lblSec.Location = New System.Drawing.Point(9, 103)
        Me.lblSec.Name = "lblSec"
        Me.lblSec.Size = New System.Drawing.Size(102, 12)
        Me.lblSec.TabIndex = 5
        Me.lblSec.Text = "Secondary Customer"
        '
        'txtCus1Na
        '
        Me.txtCus1Na.BackColor = System.Drawing.Color.White
        Me.txtCus1Na.Enabled = False
        Me.txtCus1Na.Location = New System.Drawing.Point(145, 66)
        Me.txtCus1Na.Name = "txtCus1Na"
        Me.txtCus1Na.Size = New System.Drawing.Size(392, 22)
        Me.txtCus1Na.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(329, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 12)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Company Name "
        '
        'txtCus2Na
        '
        Me.txtCus2Na.BackColor = System.Drawing.Color.White
        Me.txtCus2Na.Enabled = False
        Me.txtCus2Na.Location = New System.Drawing.Point(145, 98)
        Me.txtCus2Na.Name = "txtCus2Na"
        Me.txtCus2Na.Size = New System.Drawing.Size(392, 22)
        Me.txtCus2Na.TabIndex = 7
        '
        'lblFrom
        '
        Me.lblFrom.AutoSize = True
        Me.lblFrom.Location = New System.Drawing.Point(7, 26)
        Me.lblFrom.Name = "lblFrom"
        Me.lblFrom.Size = New System.Drawing.Size(56, 12)
        Me.lblFrom.TabIndex = 9
        Me.lblFrom.Text = "Seq.  From"
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.Color.White
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.Location = New System.Drawing.Point(437, 6)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.Size = New System.Drawing.Size(509, 22)
        Me.txtCoNam.TabIndex = 2
        '
        'cmdFind
        '
        Me.cmdFind.Location = New System.Drawing.Point(268, 35)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(49, 22)
        Me.cmdFind.TabIndex = 4
        Me.cmdFind.Text = "&Show"
        Me.cmdFind.UseVisualStyleBackColor = True
        '
        'chkZeroQty
        '
        Me.chkZeroQty.AutoSize = True
        Me.chkZeroQty.Checked = True
        Me.chkZeroQty.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkZeroQty.Location = New System.Drawing.Point(436, 36)
        Me.chkZeroQty.Name = "chkZeroQty"
        Me.chkZeroQty.Size = New System.Drawing.Size(190, 16)
        Me.chkZeroQty.TabIndex = 5
        Me.chkZeroQty.Text = "Include Item with Tentative Qty = 0"
        Me.chkZeroQty.UseVisualStyleBackColor = True
        Me.chkZeroQty.Visible = False
        '
        'cmdSearch
        '
        Me.cmdSearch.Location = New System.Drawing.Point(563, 66)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(76, 55)
        Me.cmdSearch.TabIndex = 8
        Me.cmdSearch.Text = "&Quotation Search"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdApply)
        Me.GroupBox1.Controls.Add(Me.txtTo)
        Me.GroupBox1.Controls.Add(Me.lblFrom)
        Me.GroupBox1.Controls.Add(Me.txtFrom)
        Me.GroupBox1.Controls.Add(Me.lblTo)
        Me.GroupBox1.Location = New System.Drawing.Point(647, 62)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(294, 61)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'cmdApply
        '
        Me.cmdApply.Location = New System.Drawing.Point(203, 18)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.Size = New System.Drawing.Size(73, 26)
        Me.cmdApply.TabIndex = 12
        Me.cmdApply.Text = "&Apply"
        Me.cmdApply.UseVisualStyleBackColor = True
        '
        'txtTo
        '
        Me.txtTo.BackColor = System.Drawing.Color.White
        Me.txtTo.Location = New System.Drawing.Point(146, 20)
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Size = New System.Drawing.Size(35, 22)
        Me.txtTo.TabIndex = 11
        '
        'txtFrom
        '
        Me.txtFrom.BackColor = System.Drawing.Color.White
        Me.txtFrom.Location = New System.Drawing.Point(76, 20)
        Me.txtFrom.Name = "txtFrom"
        Me.txtFrom.Size = New System.Drawing.Size(35, 22)
        Me.txtFrom.TabIndex = 10
        '
        'lblTo
        '
        Me.lblTo.AutoSize = True
        Me.lblTo.Location = New System.Drawing.Point(120, 26)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(18, 12)
        Me.lblTo.TabIndex = 0
        Me.lblTo.Text = "To"
        '
        'txtCusQty
        '
        Me.txtCusQty.BackColor = System.Drawing.Color.White
        Me.txtCusQty.Location = New System.Drawing.Point(911, 581)
        Me.txtCusQty.Name = "txtCusQty"
        Me.txtCusQty.Size = New System.Drawing.Size(31, 22)
        Me.txtCusQty.TabIndex = 14
        Me.txtCusQty.Visible = False
        '
        'txtStkQty
        '
        Me.txtStkQty.BackColor = System.Drawing.Color.White
        Me.txtStkQty.Location = New System.Drawing.Point(780, 581)
        Me.txtStkQty.Name = "txtStkQty"
        Me.txtStkQty.Size = New System.Drawing.Size(30, 22)
        Me.txtStkQty.TabIndex = 13
        Me.txtStkQty.Visible = False
        '
        'lblCusQty
        '
        Me.lblCusQty.AutoSize = True
        Me.lblCusQty.Location = New System.Drawing.Point(817, 584)
        Me.lblCusQty.Name = "lblCusQty"
        Me.lblCusQty.Size = New System.Drawing.Size(86, 12)
        Me.lblCusQty.TabIndex = 4
        Me.lblCusQty.Text = "Cust. Sample Qty"
        Me.lblCusQty.Visible = False
        '
        'lblStkQty
        '
        Me.lblStkQty.AutoSize = True
        Me.lblStkQty.Location = New System.Drawing.Point(720, 584)
        Me.lblStkQty.Name = "lblStkQty"
        Me.lblStkQty.Size = New System.Drawing.Size(51, 12)
        Me.lblStkQty.TabIndex = 2
        Me.lblStkQty.Text = "Stock Qty"
        Me.lblStkQty.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtReqNo)
        Me.GroupBox2.Controls.Add(Me.grdDetail)
        Me.GroupBox2.Location = New System.Drawing.Point(2, 121)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(945, 441)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        '
        'txtReqNo
        '
        Me.txtReqNo.BackColor = System.Drawing.Color.White
        Me.txtReqNo.Location = New System.Drawing.Point(7, 364)
        Me.txtReqNo.Multiline = True
        Me.txtReqNo.Name = "txtReqNo"
        Me.txtReqNo.ReadOnly = True
        Me.txtReqNo.Size = New System.Drawing.Size(926, 71)
        Me.txtReqNo.TabIndex = 16
        '
        'grdDetail
        '
        Me.grdDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDetail.Location = New System.Drawing.Point(7, 12)
        Me.grdDetail.Name = "grdDetail"
        Me.grdDetail.RowTemplate.Height = 15
        Me.grdDetail.Size = New System.Drawing.Size(927, 346)
        Me.grdDetail.TabIndex = 15
        '
        'cmdInsertItem
        '
        Me.cmdInsertItem.Location = New System.Drawing.Point(849, 573)
        Me.cmdInsertItem.Name = "cmdInsertItem"
        Me.cmdInsertItem.Size = New System.Drawing.Size(25, 20)
        Me.cmdInsertItem.TabIndex = 17
        Me.cmdInsertItem.Text = "&Insert Item"
        Me.cmdInsertItem.UseVisualStyleBackColor = True
        Me.cmdInsertItem.Visible = False
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(433, 573)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(80, 25)
        Me.cmdClear.TabIndex = 18
        Me.cmdClear.Text = "Cl&ear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdGen
        '
        Me.cmdGen.Location = New System.Drawing.Point(314, 573)
        Me.cmdGen.Name = "cmdGen"
        Me.cmdGen.Size = New System.Drawing.Size(80, 25)
        Me.cmdGen.TabIndex = 21
        Me.cmdGen.Text = "&Generate"
        Me.cmdGen.UseVisualStyleBackColor = True
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Location = New System.Drawing.Point(880, 575)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(17, 20)
        Me.cmdClearAll.TabIndex = 22
        Me.cmdClearAll.Text = "Clea&r All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        Me.cmdClearAll.Visible = False
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(552, 573)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(80, 25)
        Me.cmdCancel.TabIndex = 23
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtReqNoSet)
        Me.GroupBox3.Controls.Add(Me.grdDetailSet)
        Me.GroupBox3.Location = New System.Drawing.Point(774, 565)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(60, 30)
        Me.GroupBox3.TabIndex = 16
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Visible = False
        '
        'txtReqNoSet
        '
        Me.txtReqNoSet.BackColor = System.Drawing.Color.White
        Me.txtReqNoSet.Location = New System.Drawing.Point(91, 10)
        Me.txtReqNoSet.Multiline = True
        Me.txtReqNoSet.Name = "txtReqNoSet"
        Me.txtReqNoSet.ReadOnly = True
        Me.txtReqNoSet.Size = New System.Drawing.Size(111, 14)
        Me.txtReqNoSet.TabIndex = 20
        Me.txtReqNoSet.Visible = False
        '
        'grdDetailSet
        '
        Me.grdDetailSet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDetailSet.Location = New System.Drawing.Point(6, 10)
        Me.grdDetailSet.Name = "grdDetailSet"
        Me.grdDetailSet.RowTemplate.Height = 15
        Me.grdDetailSet.Size = New System.Drawing.Size(79, 14)
        Me.grdDetailSet.TabIndex = 19
        Me.grdDetailSet.Visible = False
        '
        'cmdApplyA
        '
        Me.cmdApplyA.Location = New System.Drawing.Point(839, 592)
        Me.cmdApplyA.Name = "cmdApplyA"
        Me.cmdApplyA.Size = New System.Drawing.Size(15, 11)
        Me.cmdApplyA.TabIndex = 24
        Me.cmdApplyA.Text = "&Apply all"
        Me.cmdApplyA.UseVisualStyleBackColor = True
        Me.cmdApplyA.Visible = False
        '
        'StatusBar
        '
        Me.StatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblLeft, Me.lblRight})
        Me.StatusBar.Location = New System.Drawing.Point(0, 609)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Size = New System.Drawing.Size(954, 22)
        Me.StatusBar.TabIndex = 204
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
        'TOM00002
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(954, 631)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.cmdApplyA)
        Me.Controls.Add(Me.txtCusQty)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.txtStkQty)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.lblCusQty)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.cmdGen)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.lblStkQty)
        Me.Controls.Add(Me.cmdInsertItem)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.chkZeroQty)
        Me.Controls.Add(Me.cmdFind)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.txtCus2Na)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtCus1Na)
        Me.Controls.Add(Me.lblSec)
        Me.Controls.Add(Me.txtQutNo)
        Me.Controls.Add(Me.lblPri)
        Me.Controls.Add(Me.lblQutno)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "TOM00002"
        Me.Text = "TOM00002 - Tentative Order Generation (TOM02)"
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.grdDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.grdDetailSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusBar.ResumeLayout(False)
        Me.StatusBar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents lblQutno As System.Windows.Forms.Label
    Friend WithEvents lblPri As System.Windows.Forms.Label
    Friend WithEvents txtQutNo As System.Windows.Forms.TextBox
    Friend WithEvents lblSec As System.Windows.Forms.Label
    Friend WithEvents txtCus1Na As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCus2Na As System.Windows.Forms.TextBox
    Friend WithEvents lblFrom As System.Windows.Forms.Label
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents cmdFind As System.Windows.Forms.Button
    Friend WithEvents chkZeroQty As System.Windows.Forms.CheckBox
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtStkQty As System.Windows.Forms.TextBox
    Friend WithEvents lblCusQty As System.Windows.Forms.Label
    Friend WithEvents txtTo As System.Windows.Forms.TextBox
    Friend WithEvents lblStkQty As System.Windows.Forms.Label
    Friend WithEvents txtFrom As System.Windows.Forms.TextBox
    Friend WithEvents lblTo As System.Windows.Forms.Label
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents txtCusQty As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtReqNo As System.Windows.Forms.TextBox
    Friend WithEvents grdDetail As System.Windows.Forms.DataGridView
    Friend WithEvents cmdInsertItem As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdGen As System.Windows.Forms.Button
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtReqNoSet As System.Windows.Forms.TextBox
    Friend WithEvents grdDetailSet As System.Windows.Forms.DataGridView
    Friend WithEvents cmdApplyA As System.Windows.Forms.Button
    Friend WithEvents StatusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents lblLeft As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblRight As System.Windows.Forms.ToolStripStatusLabel
End Class
