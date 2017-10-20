<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IMM00015
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IMM00015))
        Me.grpItem = New System.Windows.Forms.GroupBox
        Me.cmdItmAdd = New System.Windows.Forms.Button
        Me.cmdItmAll = New System.Windows.Forms.Button
        Me.cmdItmClr = New System.Windows.Forms.Button
        Me.dgItem = New System.Windows.Forms.DataGridView
        Me.cmdItmSearch = New System.Windows.Forms.Button
        Me.txtItmNo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.grpExport = New System.Windows.Forms.GroupBox
        Me.cmdXLSRemove = New System.Windows.Forms.Button
        Me.cmdExport = New System.Windows.Forms.Button
        Me.cmdXLSAll = New System.Windows.Forms.Button
        Me.cmdXLSClr = New System.Windows.Forms.Button
        Me.dgExport = New System.Windows.Forms.DataGridView
        Me.cmdFilNamReset = New System.Windows.Forms.Button
        Me.txtFilNam = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtItmCount = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
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
        Me.t5 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdAttach = New System.Windows.Forms.ToolStripMenuItem
        Me.t6 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdFunction = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdRel = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdApv = New System.Windows.Forms.ToolStripMenuItem
        Me.t7 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdLink = New System.Windows.Forms.ToolStripMenuItem
        Me.t8 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdExit = New System.Windows.Forms.ToolStripMenuItem
        Me.grpItem.SuspendLayout()
        CType(Me.dgItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpExport.SuspendLayout()
        CType(Me.dgExport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpItem
        '
        Me.grpItem.Controls.Add(Me.cmdItmAdd)
        Me.grpItem.Controls.Add(Me.cmdItmAll)
        Me.grpItem.Controls.Add(Me.cmdItmClr)
        Me.grpItem.Controls.Add(Me.dgItem)
        Me.grpItem.Controls.Add(Me.cmdItmSearch)
        Me.grpItem.Controls.Add(Me.txtItmNo)
        Me.grpItem.Controls.Add(Me.Label1)
        Me.grpItem.Location = New System.Drawing.Point(6, 27)
        Me.grpItem.Name = "grpItem"
        Me.grpItem.Size = New System.Drawing.Size(942, 300)
        Me.grpItem.TabIndex = 14
        Me.grpItem.TabStop = False
        Me.grpItem.Text = "Item Master Search"
        '
        'cmdItmAdd
        '
        Me.cmdItmAdd.Location = New System.Drawing.Point(505, 17)
        Me.cmdItmAdd.Name = "cmdItmAdd"
        Me.cmdItmAdd.Size = New System.Drawing.Size(104, 23)
        Me.cmdItmAdd.TabIndex = 6
        Me.cmdItmAdd.Text = "Add Selected"
        Me.cmdItmAdd.UseVisualStyleBackColor = True
        '
        'cmdItmAll
        '
        Me.cmdItmAll.Location = New System.Drawing.Point(409, 17)
        Me.cmdItmAll.Name = "cmdItmAll"
        Me.cmdItmAll.Size = New System.Drawing.Size(90, 23)
        Me.cmdItmAll.TabIndex = 5
        Me.cmdItmAll.Text = "Select All"
        Me.cmdItmAll.UseVisualStyleBackColor = True
        '
        'cmdItmClr
        '
        Me.cmdItmClr.Location = New System.Drawing.Point(313, 17)
        Me.cmdItmClr.Name = "cmdItmClr"
        Me.cmdItmClr.Size = New System.Drawing.Size(90, 23)
        Me.cmdItmClr.TabIndex = 4
        Me.cmdItmClr.Text = "Clear Selection"
        Me.cmdItmClr.UseVisualStyleBackColor = True
        '
        'dgItem
        '
        Me.dgItem.AllowUserToAddRows = False
        Me.dgItem.AllowUserToDeleteRows = False
        Me.dgItem.ColumnHeadersHeight = 18
        Me.dgItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgItem.Location = New System.Drawing.Point(9, 46)
        Me.dgItem.Name = "dgItem"
        Me.dgItem.ReadOnly = True
        Me.dgItem.RowHeadersWidth = 20
        Me.dgItem.RowTemplate.Height = 20
        Me.dgItem.Size = New System.Drawing.Size(927, 248)
        Me.dgItem.TabIndex = 3
        '
        'cmdItmSearch
        '
        Me.cmdItmSearch.Location = New System.Drawing.Point(208, 17)
        Me.cmdItmSearch.Name = "cmdItmSearch"
        Me.cmdItmSearch.Size = New System.Drawing.Size(75, 23)
        Me.cmdItmSearch.TabIndex = 2
        Me.cmdItmSearch.Text = "Search"
        Me.cmdItmSearch.UseVisualStyleBackColor = True
        '
        'txtItmNo
        '
        Me.txtItmNo.Location = New System.Drawing.Point(79, 19)
        Me.txtItmNo.Name = "txtItmNo"
        Me.txtItmNo.Size = New System.Drawing.Size(123, 22)
        Me.txtItmNo.TabIndex = 1
        Me.txtItmNo.Text = "F12TD01235MIC"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Item Number"
        '
        'grpExport
        '
        Me.grpExport.Controls.Add(Me.cmdXLSRemove)
        Me.grpExport.Controls.Add(Me.cmdExport)
        Me.grpExport.Controls.Add(Me.cmdXLSAll)
        Me.grpExport.Controls.Add(Me.cmdXLSClr)
        Me.grpExport.Controls.Add(Me.dgExport)
        Me.grpExport.Controls.Add(Me.cmdFilNamReset)
        Me.grpExport.Controls.Add(Me.txtFilNam)
        Me.grpExport.Controls.Add(Me.Label3)
        Me.grpExport.Controls.Add(Me.txtItmCount)
        Me.grpExport.Controls.Add(Me.Label2)
        Me.grpExport.Location = New System.Drawing.Point(6, 328)
        Me.grpExport.Name = "grpExport"
        Me.grpExport.Size = New System.Drawing.Size(942, 300)
        Me.grpExport.TabIndex = 15
        Me.grpExport.TabStop = False
        Me.grpExport.Text = "Items Pending for Export"
        '
        'cmdXLSRemove
        '
        Me.cmdXLSRemove.Location = New System.Drawing.Point(334, 17)
        Me.cmdXLSRemove.Name = "cmdXLSRemove"
        Me.cmdXLSRemove.Size = New System.Drawing.Size(105, 23)
        Me.cmdXLSRemove.TabIndex = 7
        Me.cmdXLSRemove.Text = "Remove Selected"
        Me.cmdXLSRemove.UseVisualStyleBackColor = True
        '
        'cmdExport
        '
        Me.cmdExport.Location = New System.Drawing.Point(818, 17)
        Me.cmdExport.Name = "cmdExport"
        Me.cmdExport.Size = New System.Drawing.Size(104, 23)
        Me.cmdExport.TabIndex = 11
        Me.cmdExport.Text = "Export to Excel"
        Me.cmdExport.UseVisualStyleBackColor = True
        '
        'cmdXLSAll
        '
        Me.cmdXLSAll.Location = New System.Drawing.Point(238, 17)
        Me.cmdXLSAll.Name = "cmdXLSAll"
        Me.cmdXLSAll.Size = New System.Drawing.Size(90, 23)
        Me.cmdXLSAll.TabIndex = 6
        Me.cmdXLSAll.Text = "Select All"
        Me.cmdXLSAll.UseVisualStyleBackColor = True
        '
        'cmdXLSClr
        '
        Me.cmdXLSClr.Location = New System.Drawing.Point(142, 17)
        Me.cmdXLSClr.Name = "cmdXLSClr"
        Me.cmdXLSClr.Size = New System.Drawing.Size(90, 23)
        Me.cmdXLSClr.TabIndex = 5
        Me.cmdXLSClr.Text = "Clear Selection"
        Me.cmdXLSClr.UseVisualStyleBackColor = True
        '
        'dgExport
        '
        Me.dgExport.AllowUserToAddRows = False
        Me.dgExport.AllowUserToDeleteRows = False
        Me.dgExport.ColumnHeadersHeight = 18
        Me.dgExport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgExport.Location = New System.Drawing.Point(9, 45)
        Me.dgExport.Name = "dgExport"
        Me.dgExport.ReadOnly = True
        Me.dgExport.RowHeadersWidth = 20
        Me.dgExport.RowTemplate.Height = 20
        Me.dgExport.Size = New System.Drawing.Size(927, 246)
        Me.dgExport.TabIndex = 4
        '
        'cmdFilNamReset
        '
        Me.cmdFilNamReset.Location = New System.Drawing.Point(712, 17)
        Me.cmdFilNamReset.Name = "cmdFilNamReset"
        Me.cmdFilNamReset.Size = New System.Drawing.Size(100, 23)
        Me.cmdFilNamReset.TabIndex = 10
        Me.cmdFilNamReset.Text = "Reset Filename"
        Me.cmdFilNamReset.UseVisualStyleBackColor = True
        '
        'txtFilNam
        '
        Me.txtFilNam.Location = New System.Drawing.Point(513, 19)
        Me.txtFilNam.Name = "txtFilNam"
        Me.txtFilNam.Size = New System.Drawing.Size(193, 22)
        Me.txtFilNam.TabIndex = 9
        Me.txtFilNam.Text = "abc.xls"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(458, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 12)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Filename"
        '
        'txtItmCount
        '
        Me.txtItmCount.Location = New System.Drawing.Point(96, 19)
        Me.txtItmCount.Name = "txtItmCount"
        Me.txtItmCount.Size = New System.Drawing.Size(34, 22)
        Me.txtItmCount.TabIndex = 3
        Me.txtItmCount.Text = "123"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Number of Items"
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
        Me.menuStrip.TabIndex = 215
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
        Me.mmdPrint.Name = "mmdPrint"
        Me.mmdPrint.Size = New System.Drawing.Size(44, 19)
        Me.mmdPrint.Text = "&Print"
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
        Me.mmdFunction.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mmdRel, Me.mmdApv})
        Me.mmdFunction.Name = "mmdFunction"
        Me.mmdFunction.Size = New System.Drawing.Size(66, 19)
        Me.mmdFunction.Text = "Function"
        '
        'mmdRel
        '
        Me.mmdRel.Name = "mmdRel"
        Me.mmdRel.Size = New System.Drawing.Size(121, 22)
        Me.mmdRel.Text = "Release"
        '
        'mmdApv
        '
        Me.mmdApv.Name = "mmdApv"
        Me.mmdApv.Size = New System.Drawing.Size(121, 22)
        Me.mmdApv.Text = "Approval"
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
        'IMM00015
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(954, 631)
        Me.Controls.Add(Me.menuStrip)
        Me.Controls.Add(Me.grpExport)
        Me.Controls.Add(Me.grpItem)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "IMM00015"
        Me.Text = "IMM00015 - Item Master Data Export (External Item) (IMM15)"
        Me.grpItem.ResumeLayout(False)
        Me.grpItem.PerformLayout()
        CType(Me.dgItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpExport.ResumeLayout(False)
        Me.grpExport.PerformLayout()
        CType(Me.dgExport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuStrip.ResumeLayout(False)
        Me.menuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpItem As System.Windows.Forms.GroupBox
    Friend WithEvents grpExport As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdItmSearch As System.Windows.Forms.Button
    Friend WithEvents txtItmNo As System.Windows.Forms.TextBox
    Friend WithEvents cmdItmAdd As System.Windows.Forms.Button
    Friend WithEvents cmdItmAll As System.Windows.Forms.Button
    Friend WithEvents cmdItmClr As System.Windows.Forms.Button
    Friend WithEvents dgItem As System.Windows.Forms.DataGridView
    Friend WithEvents txtItmCount As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdExport As System.Windows.Forms.Button
    Friend WithEvents cmdXLSAll As System.Windows.Forms.Button
    Friend WithEvents cmdXLSClr As System.Windows.Forms.Button
    Friend WithEvents dgExport As System.Windows.Forms.DataGridView
    Friend WithEvents cmdFilNamReset As System.Windows.Forms.Button
    Friend WithEvents txtFilNam As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdXLSRemove As System.Windows.Forms.Button
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
    Friend WithEvents t5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdAttach As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdFunction As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdRel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdApv As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t7 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdLink As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t8 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdExit As System.Windows.Forms.ToolStripMenuItem
End Class
