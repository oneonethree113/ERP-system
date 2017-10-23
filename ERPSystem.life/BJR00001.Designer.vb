<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BJR00001
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BJR00001))
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtBJNo = New System.Windows.Forms.TextBox
        Me.txtRunNoFrm = New System.Windows.Forms.TextBox
        Me.txtRunNoTo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtJobOrdTo = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtJobOrdFrm = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboRptFmt = New System.Windows.Forms.ComboBox
        Me.cmdApply = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.grpOutFmt = New System.Windows.Forms.GroupBox
        Me.optExcel = New System.Windows.Forms.RadioButton
        Me.optPDF = New System.Windows.Forms.RadioButton
        Me.dgBatchJob = New System.Windows.Forms.DataGridView
        Me.txtCount = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.menuStrip = New System.Windows.Forms.MenuStrip
        Me.mmdAdd = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdSave = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdCopy = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdFind = New System.Windows.Forms.ToolStripMenuItem
        Me.t1 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdClear = New System.Windows.Forms.ToolStripMenuItem
        Me.t2 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdSearch = New System.Windows.Forms.ToolStripMenuItem
        Me.t3 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdInsRow = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdDelRow = New System.Windows.Forms.ToolStripMenuItem
        Me.t4 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdPrint = New System.Windows.Forms.ToolStripMenuItem
        Me.tsiPrintItmPrcRpt = New System.Windows.Forms.ToolStripMenuItem
        Me.t5 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdAttach = New System.Windows.Forms.ToolStripMenuItem
        Me.t6 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdFunction = New System.Windows.Forms.ToolStripMenuItem
        Me.tsiHldRel = New System.Windows.Forms.ToolStripMenuItem
        Me.t7 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdLink = New System.Windows.Forms.ToolStripMenuItem
        Me.t8 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdExit = New System.Windows.Forms.ToolStripMenuItem
        Me.grpOutFmt.SuspendLayout()
        CType(Me.dgBatchJob, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboCoCde
        '
        Me.cboCoCde.BackColor = System.Drawing.Color.White
        Me.cboCoCde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(109, 27)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(81, 20)
        Me.cboCoCde.TabIndex = 259
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(6, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 12)
        Me.Label1.TabIndex = 260
        Me.Label1.Text = "Company Code"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 12)
        Me.Label2.TabIndex = 261
        Me.Label2.Text = "Batch Job No."
        '
        'txtBJNo
        '
        Me.txtBJNo.BackColor = System.Drawing.Color.White
        Me.txtBJNo.Location = New System.Drawing.Point(109, 52)
        Me.txtBJNo.Name = "txtBJNo"
        Me.txtBJNo.Size = New System.Drawing.Size(150, 22)
        Me.txtBJNo.TabIndex = 262
        '
        'txtRunNoFrm
        '
        Me.txtRunNoFrm.BackColor = System.Drawing.Color.White
        Me.txtRunNoFrm.Location = New System.Drawing.Point(109, 76)
        Me.txtRunNoFrm.Name = "txtRunNoFrm"
        Me.txtRunNoFrm.Size = New System.Drawing.Size(150, 22)
        Me.txtRunNoFrm.TabIndex = 264
        '
        'txtRunNoTo
        '
        Me.txtRunNoTo.BackColor = System.Drawing.Color.White
        Me.txtRunNoTo.Location = New System.Drawing.Point(291, 76)
        Me.txtRunNoTo.Name = "txtRunNoTo"
        Me.txtRunNoTo.Size = New System.Drawing.Size(150, 22)
        Me.txtRunNoTo.TabIndex = 266
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(265, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(18, 12)
        Me.Label4.TabIndex = 265
        Me.Label4.Text = "To"
        '
        'txtJobOrdTo
        '
        Me.txtJobOrdTo.BackColor = System.Drawing.Color.White
        Me.txtJobOrdTo.Location = New System.Drawing.Point(291, 100)
        Me.txtJobOrdTo.Name = "txtJobOrdTo"
        Me.txtJobOrdTo.Size = New System.Drawing.Size(150, 22)
        Me.txtJobOrdTo.TabIndex = 270
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(265, 103)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(18, 12)
        Me.Label5.TabIndex = 269
        Me.Label5.Text = "To"
        '
        'txtJobOrdFrm
        '
        Me.txtJobOrdFrm.BackColor = System.Drawing.Color.White
        Me.txtJobOrdFrm.Location = New System.Drawing.Point(109, 100)
        Me.txtJobOrdFrm.Name = "txtJobOrdFrm"
        Me.txtJobOrdFrm.Size = New System.Drawing.Size(150, 22)
        Me.txtJobOrdFrm.TabIndex = 268
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 103)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 12)
        Me.Label6.TabIndex = 267
        Me.Label6.Text = "Job No."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 12)
        Me.Label3.TabIndex = 263
        Me.Label3.Text = "Running No."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(73, 79)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 12)
        Me.Label7.TabIndex = 271
        Me.Label7.Text = "From"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(73, 103)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 12)
        Me.Label8.TabIndex = 272
        Me.Label8.Text = "From"
        '
        'cboRptFmt
        '
        Me.cboRptFmt.BackColor = System.Drawing.Color.White
        Me.cboRptFmt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRptFmt.FormattingEnabled = True
        Me.cboRptFmt.Location = New System.Drawing.Point(620, 27)
        Me.cboRptFmt.Name = "cboRptFmt"
        Me.cboRptFmt.Size = New System.Drawing.Size(200, 20)
        Me.cboRptFmt.TabIndex = 273
        '
        'cmdApply
        '
        Me.cmdApply.Location = New System.Drawing.Point(620, 98)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.Size = New System.Drawing.Size(85, 21)
        Me.cmdApply.TabIndex = 274
        Me.cmdApply.Text = "Apply"
        Me.cmdApply.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Location = New System.Drawing.Point(735, 98)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(85, 21)
        Me.cmdPrint.TabIndex = 275
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'grpOutFmt
        '
        Me.grpOutFmt.Controls.Add(Me.optExcel)
        Me.grpOutFmt.Controls.Add(Me.optPDF)
        Me.grpOutFmt.Location = New System.Drawing.Point(620, 50)
        Me.grpOutFmt.Name = "grpOutFmt"
        Me.grpOutFmt.Size = New System.Drawing.Size(200, 42)
        Me.grpOutFmt.TabIndex = 276
        Me.grpOutFmt.TabStop = False
        Me.grpOutFmt.Text = "Output Format"
        '
        'optExcel
        '
        Me.optExcel.AutoSize = True
        Me.optExcel.Location = New System.Drawing.Point(111, 18)
        Me.optExcel.Name = "optExcel"
        Me.optExcel.Size = New System.Drawing.Size(49, 16)
        Me.optExcel.TabIndex = 1
        Me.optExcel.TabStop = True
        Me.optExcel.Text = "Excel"
        Me.optExcel.UseVisualStyleBackColor = True
        '
        'optPDF
        '
        Me.optPDF.AutoSize = True
        Me.optPDF.Location = New System.Drawing.Point(39, 18)
        Me.optPDF.Name = "optPDF"
        Me.optPDF.Size = New System.Drawing.Size(43, 16)
        Me.optPDF.TabIndex = 0
        Me.optPDF.TabStop = True
        Me.optPDF.Text = "PDF"
        Me.optPDF.UseVisualStyleBackColor = True
        '
        'dgBatchJob
        '
        Me.dgBatchJob.AllowUserToAddRows = False
        Me.dgBatchJob.AllowUserToDeleteRows = False
        Me.dgBatchJob.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgBatchJob.Location = New System.Drawing.Point(12, 141)
        Me.dgBatchJob.Name = "dgBatchJob"
        Me.dgBatchJob.ReadOnly = True
        Me.dgBatchJob.RowTemplate.Height = 24
        Me.dgBatchJob.Size = New System.Drawing.Size(930, 450)
        Me.dgBatchJob.TabIndex = 277
        '
        'txtCount
        '
        Me.txtCount.BackColor = System.Drawing.Color.White
        Me.txtCount.Location = New System.Drawing.Point(843, 597)
        Me.txtCount.Name = "txtCount"
        Me.txtCount.Size = New System.Drawing.Size(99, 22)
        Me.txtCount.TabIndex = 279
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(764, 600)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 12)
        Me.Label9.TabIndex = 278
        Me.Label9.Text = "Record Count"
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.Color.White
        Me.txtCoNam.Location = New System.Drawing.Point(196, 27)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.ReadOnly = True
        Me.txtCoNam.Size = New System.Drawing.Size(389, 22)
        Me.txtCoNam.TabIndex = 280
        '
        'menuStrip
        '
        Me.menuStrip.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mmdAdd, Me.mmdSave, Me.mmdDelete, Me.mmdCopy, Me.mmdFind, Me.t1, Me.mmdClear, Me.t2, Me.mmdSearch, Me.t3, Me.mmdInsRow, Me.mmdDelRow, Me.t4, Me.mmdPrint, Me.t5, Me.mmdAttach, Me.t6, Me.mmdFunction, Me.t7, Me.mmdLink, Me.t8, Me.mmdExit})
        Me.menuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.menuStrip.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip.Name = "menuStrip"
        Me.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.menuStrip.Size = New System.Drawing.Size(954, 24)
        Me.menuStrip.TabIndex = 779
        Me.menuStrip.Text = "MenuStrip1"
        '
        'mmdAdd
        '
        Me.mmdAdd.BackColor = System.Drawing.SystemColors.Control
        Me.mmdAdd.Name = "mmdAdd"
        Me.mmdAdd.Size = New System.Drawing.Size(40, 19)
        Me.mmdAdd.Tag = "Add"
        Me.mmdAdd.Text = "&Add"
        '
        'mmdSave
        '
        Me.mmdSave.Name = "mmdSave"
        Me.mmdSave.Size = New System.Drawing.Size(46, 19)
        Me.mmdSave.Text = "&Save"
        '
        'mmdDelete
        '
        Me.mmdDelete.Name = "mmdDelete"
        Me.mmdDelete.Size = New System.Drawing.Size(55, 19)
        Me.mmdDelete.Text = "&Delete"
        '
        'mmdCopy
        '
        Me.mmdCopy.Name = "mmdCopy"
        Me.mmdCopy.Size = New System.Drawing.Size(47, 19)
        Me.mmdCopy.Text = "&Copy"
        '
        'mmdFind
        '
        Me.mmdFind.Name = "mmdFind"
        Me.mmdFind.Size = New System.Drawing.Size(43, 19)
        Me.mmdFind.Text = "&Find"
        '
        't1
        '
        Me.t1.AutoSize = False
        Me.t1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.t1.Enabled = False
        Me.t1.Name = "t1"
        Me.t1.Size = New System.Drawing.Size(8, 20)
        Me.t1.Text = "|"
        '
        'mmdClear
        '
        Me.mmdClear.Name = "mmdClear"
        Me.mmdClear.Size = New System.Drawing.Size(49, 19)
        Me.mmdClear.Text = "Cl&ear"
        '
        't2
        '
        Me.t2.AutoSize = False
        Me.t2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.t2.Enabled = False
        Me.t2.Name = "t2"
        Me.t2.Size = New System.Drawing.Size(8, 20)
        Me.t2.Text = "|"
        '
        'mmdSearch
        '
        Me.mmdSearch.Name = "mmdSearch"
        Me.mmdSearch.Size = New System.Drawing.Size(58, 19)
        Me.mmdSearch.Text = "Searc&h"
        '
        't3
        '
        Me.t3.AutoSize = False
        Me.t3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.t3.Enabled = False
        Me.t3.Name = "t3"
        Me.t3.Size = New System.Drawing.Size(8, 20)
        Me.t3.Text = "|"
        '
        'mmdInsRow
        '
        Me.mmdInsRow.Name = "mmdInsRow"
        Me.mmdInsRow.Size = New System.Drawing.Size(64, 19)
        Me.mmdInsRow.Text = "I&ns Row"
        '
        'mmdDelRow
        '
        Me.mmdDelRow.Name = "mmdDelRow"
        Me.mmdDelRow.Size = New System.Drawing.Size(66, 19)
        Me.mmdDelRow.Text = "Del Ro&w"
        '
        't4
        '
        Me.t4.AutoSize = False
        Me.t4.Enabled = False
        Me.t4.Name = "t4"
        Me.t4.Size = New System.Drawing.Size(8, 20)
        Me.t4.Text = "|"
        '
        'mmdPrint
        '
        Me.mmdPrint.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsiPrintItmPrcRpt})
        Me.mmdPrint.Name = "mmdPrint"
        Me.mmdPrint.Size = New System.Drawing.Size(44, 19)
        Me.mmdPrint.Text = "&Print"
        '
        'tsiPrintItmPrcRpt
        '
        Me.tsiPrintItmPrcRpt.Name = "tsiPrintItmPrcRpt"
        Me.tsiPrintItmPrcRpt.Size = New System.Drawing.Size(179, 22)
        Me.tsiPrintItmPrcRpt.Text = "Item Pricing Report"
        '
        't5
        '
        Me.t5.AutoSize = False
        Me.t5.Enabled = False
        Me.t5.Name = "t5"
        Me.t5.Size = New System.Drawing.Size(8, 20)
        Me.t5.Text = "|"
        '
        'mmdAttach
        '
        Me.mmdAttach.Name = "mmdAttach"
        Me.mmdAttach.Size = New System.Drawing.Size(52, 19)
        Me.mmdAttach.Text = "Attach"
        '
        't6
        '
        Me.t6.AutoSize = False
        Me.t6.Enabled = False
        Me.t6.Name = "t6"
        Me.t6.Size = New System.Drawing.Size(8, 20)
        Me.t6.Text = "|"
        '
        'mmdFunction
        '
        Me.mmdFunction.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsiHldRel})
        Me.mmdFunction.Name = "mmdFunction"
        Me.mmdFunction.Size = New System.Drawing.Size(66, 19)
        Me.mmdFunction.Text = "Function"
        '
        'tsiHldRel
        '
        Me.tsiHldRel.Name = "tsiHldRel"
        Me.tsiHldRel.Size = New System.Drawing.Size(183, 22)
        Me.tsiHldRel.Text = "Hold / Release Item"
        '
        't7
        '
        Me.t7.AutoSize = False
        Me.t7.Enabled = False
        Me.t7.Name = "t7"
        Me.t7.Size = New System.Drawing.Size(8, 20)
        Me.t7.Text = "|"
        '
        'mmdLink
        '
        Me.mmdLink.Name = "mmdLink"
        Me.mmdLink.Size = New System.Drawing.Size(42, 19)
        Me.mmdLink.Text = "Link"
        '
        't8
        '
        Me.t8.AutoSize = False
        Me.t8.Enabled = False
        Me.t8.Name = "t8"
        Me.t8.Size = New System.Drawing.Size(8, 20)
        Me.t8.Text = "|"
        '
        'mmdExit
        '
        Me.mmdExit.Name = "mmdExit"
        Me.mmdExit.Size = New System.Drawing.Size(38, 19)
        Me.mmdExit.Text = "E&xit"
        '
        'BJR00001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(954, 631)
        Me.Controls.Add(Me.menuStrip)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.txtCount)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.dgBatchJob)
        Me.Controls.Add(Me.grpOutFmt)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.cboRptFmt)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtJobOrdTo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtJobOrdFrm)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtRunNoTo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtRunNoFrm)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtBJNo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "BJR00001"
        Me.Text = "BJR00001 - Batch Job Entry (BJR01)"
        Me.grpOutFmt.ResumeLayout(False)
        Me.grpOutFmt.PerformLayout()
        CType(Me.dgBatchJob, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuStrip.ResumeLayout(False)
        Me.menuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBJNo As System.Windows.Forms.TextBox
    Friend WithEvents txtRunNoFrm As System.Windows.Forms.TextBox
    Friend WithEvents txtRunNoTo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtJobOrdTo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtJobOrdFrm As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboRptFmt As System.Windows.Forms.ComboBox
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents grpOutFmt As System.Windows.Forms.GroupBox
    Friend WithEvents optExcel As System.Windows.Forms.RadioButton
    Friend WithEvents optPDF As System.Windows.Forms.RadioButton
    Friend WithEvents dgBatchJob As System.Windows.Forms.DataGridView
    Friend WithEvents txtCount As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents menuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents mmdAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdFind As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdClear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdInsRow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdDelRow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsiPrintItmPrcRpt As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdAttach As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdFunction As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsiHldRel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t7 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdLink As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t8 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdExit As System.Windows.Forms.ToolStripMenuItem
End Class
