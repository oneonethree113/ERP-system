<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SAM00002
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SAM00002))
        Me.StatusBar = New System.Windows.Forms.StatusStrip
        Me.lblLeft = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblRight = New System.Windows.Forms.ToolStripStatusLabel
        Me.Label15 = New System.Windows.Forms.Label
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtCusNo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtItmNo = New System.Windows.Forms.TextBox
        Me.cmdMapping = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtColCde = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtUpdDat = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmd_S_ItmNo = New System.Windows.Forms.Button
        Me.txtVenItmNo = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtVendor = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.rdbitmno = New System.Windows.Forms.RadioButton
        Me.rdbvenitm = New System.Windows.Forms.RadioButton
        Me.cmd_S_ItmNo2 = New System.Windows.Forms.Button
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
        Me.menuStrip = New System.Windows.Forms.MenuStrip
        Me.TabPageMain = New ERPSystem.BaseTabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.grdSum = New System.Windows.Forms.DataGridView
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.grdDtl = New System.Windows.Forms.DataGridView
        Me.StatusBar.SuspendLayout()
        Me.menuStrip.SuspendLayout()
        Me.TabPageMain.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.grdSum, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.grdDtl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusBar
        '
        Me.StatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblLeft, Me.lblRight})
        Me.StatusBar.Location = New System.Drawing.Point(0, 609)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.StatusBar.Size = New System.Drawing.Size(954, 22)
        Me.StatusBar.TabIndex = 250
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
        Me.lblRight.Size = New System.Drawing.Size(537, 17)
        Me.lblRight.Spring = True
        Me.lblRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(22, 38)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(79, 12)
        Me.Label15.TabIndex = 277
        Me.Label15.Text = "Company Code"
        '
        'cboCoCde
        '
        Me.cboCoCde.BackColor = System.Drawing.Color.White
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(136, 35)
        Me.cboCoCde.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(116, 20)
        Me.cboCoCde.TabIndex = 1
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(255, 38)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(84, 12)
        Me.Label22.TabIndex = 279
        Me.Label22.Text = "Company Name "
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.Color.White
        Me.txtCoNam.Location = New System.Drawing.Point(365, 35)
        Me.txtCoNam.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.Size = New System.Drawing.Size(327, 22)
        Me.txtCoNam.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 12)
        Me.Label5.TabIndex = 281
        Me.Label5.Text = "Primary Customer"
        '
        'txtCusNo
        '
        Me.txtCusNo.BackColor = System.Drawing.Color.White
        Me.txtCusNo.Location = New System.Drawing.Point(136, 61)
        Me.txtCusNo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCusNo.Name = "txtCusNo"
        Me.txtCusNo.Size = New System.Drawing.Size(208, 22)
        Me.txtCusNo.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 12)
        Me.Label1.TabIndex = 283
        Me.Label1.Text = "Temp / Item No."
        '
        'txtItmNo
        '
        Me.txtItmNo.BackColor = System.Drawing.Color.White
        Me.txtItmNo.Location = New System.Drawing.Point(185, 88)
        Me.txtItmNo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtItmNo.Name = "txtItmNo"
        Me.txtItmNo.Size = New System.Drawing.Size(159, 22)
        Me.txtItmNo.TabIndex = 4
        '
        'cmdMapping
        '
        Me.cmdMapping.Image = CType(resources.GetObject("cmdMapping.Image"), System.Drawing.Image)
        Me.cmdMapping.Location = New System.Drawing.Point(351, 87)
        Me.cmdMapping.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmdMapping.Name = "cmdMapping"
        Me.cmdMapping.Size = New System.Drawing.Size(25, 23)
        Me.cmdMapping.TabIndex = 5
        Me.cmdMapping.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 168)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 12)
        Me.Label2.TabIndex = 286
        Me.Label2.Text = "Color Code"
        '
        'txtColCde
        '
        Me.txtColCde.BackColor = System.Drawing.Color.White
        Me.txtColCde.Location = New System.Drawing.Point(136, 164)
        Me.txtColCde.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtColCde.Name = "txtColCde"
        Me.txtColCde.Size = New System.Drawing.Size(208, 22)
        Me.txtColCde.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 193)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 12)
        Me.Label3.TabIndex = 288
        Me.Label3.Text = "Update Date"
        '
        'txtUpdDat
        '
        Me.txtUpdDat.BackColor = System.Drawing.Color.White
        Me.txtUpdDat.Location = New System.Drawing.Point(136, 189)
        Me.txtUpdDat.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtUpdDat.MaxLength = 10
        Me.txtUpdDat.Name = "txtUpdDat"
        Me.txtUpdDat.Size = New System.Drawing.Size(116, 22)
        Me.txtUpdDat.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(261, 194)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 12)
        Me.Label4.TabIndex = 290
        Me.Label4.Text = "(MM/DD/YYYY)"
        '
        'cmd_S_ItmNo
        '
        Me.cmd_S_ItmNo.Location = New System.Drawing.Point(136, 89)
        Me.cmd_S_ItmNo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmd_S_ItmNo.Name = "cmd_S_ItmNo"
        Me.cmd_S_ItmNo.Size = New System.Drawing.Size(43, 20)
        Me.cmd_S_ItmNo.TabIndex = 291
        Me.cmd_S_ItmNo.Text = "＞＞"
        Me.cmd_S_ItmNo.UseVisualStyleBackColor = True
        '
        'txtVenItmNo
        '
        Me.txtVenItmNo.BackColor = System.Drawing.Color.White
        Me.txtVenItmNo.Location = New System.Drawing.Point(185, 113)
        Me.txtVenItmNo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtVenItmNo.Name = "txtVenItmNo"
        Me.txtVenItmNo.Size = New System.Drawing.Size(159, 22)
        Me.txtVenItmNo.TabIndex = 292
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(22, 115)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 12)
        Me.Label6.TabIndex = 293
        Me.Label6.Text = "Vendor Item No."
        '
        'txtVendor
        '
        Me.txtVendor.BackColor = System.Drawing.Color.White
        Me.txtVendor.Location = New System.Drawing.Point(136, 139)
        Me.txtVendor.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtVendor.Name = "txtVendor"
        Me.txtVendor.Size = New System.Drawing.Size(208, 22)
        Me.txtVendor.TabIndex = 294
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(22, 143)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 12)
        Me.Label7.TabIndex = 295
        Me.Label7.Text = "Vendor"
        '
        'rdbitmno
        '
        Me.rdbitmno.AutoSize = True
        Me.rdbitmno.Checked = True
        Me.rdbitmno.Location = New System.Drawing.Point(3, 89)
        Me.rdbitmno.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rdbitmno.Name = "rdbitmno"
        Me.rdbitmno.Size = New System.Drawing.Size(100, 16)
        Me.rdbitmno.TabIndex = 296
        Me.rdbitmno.TabStop = True
        Me.rdbitmno.Text = "Temp / Item No."
        Me.rdbitmno.UseVisualStyleBackColor = True
        '
        'rdbvenitm
        '
        Me.rdbvenitm.AutoSize = True
        Me.rdbvenitm.Location = New System.Drawing.Point(3, 115)
        Me.rdbvenitm.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rdbvenitm.Name = "rdbvenitm"
        Me.rdbvenitm.Size = New System.Drawing.Size(102, 16)
        Me.rdbvenitm.TabIndex = 297
        Me.rdbvenitm.Text = "Vendor Item No."
        Me.rdbvenitm.UseVisualStyleBackColor = True
        '
        'cmd_S_ItmNo2
        '
        Me.cmd_S_ItmNo2.Location = New System.Drawing.Point(136, 114)
        Me.cmd_S_ItmNo2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmd_S_ItmNo2.Name = "cmd_S_ItmNo2"
        Me.cmd_S_ItmNo2.Size = New System.Drawing.Size(43, 20)
        Me.cmd_S_ItmNo2.TabIndex = 298
        Me.cmd_S_ItmNo2.Text = "＞＞"
        Me.cmd_S_ItmNo2.UseVisualStyleBackColor = True
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
        'menuStrip
        '
        Me.menuStrip.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mmdAdd, Me.mmdSave, Me.mmdDelete, Me.mmdCopy, Me.mmdFind, Me.t1, Me.mmdClear, Me.t2, Me.mmdSearch, Me.t3, Me.mmdInsRow, Me.mmdDelRow, Me.t4, Me.mmdPrint, Me.t5, Me.mmdAttach, Me.t6, Me.mmdFunction, Me.t7, Me.mmdLink, Me.t8, Me.mmdExit})
        Me.menuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.menuStrip.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip.Name = "menuStrip"
        Me.menuStrip.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.menuStrip.Size = New System.Drawing.Size(954, 24)
        Me.menuStrip.TabIndex = 299
        Me.menuStrip.Text = "MenuStrip1"
        '
        'TabPageMain
        '
        Me.TabPageMain.Controls.Add(Me.TabPage1)
        Me.TabPageMain.Controls.Add(Me.TabPage2)
        Me.TabPageMain.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.TabPageMain.ItemSize = New System.Drawing.Size(62, 18)
        Me.TabPageMain.Location = New System.Drawing.Point(4, 219)
        Me.TabPageMain.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPageMain.Name = "TabPageMain"
        Me.TabPageMain.SelectedIndex = 0
        Me.TabPageMain.Size = New System.Drawing.Size(947, 386)
        Me.TabPageMain.TabIndex = 276
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.grdSum)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage1.Size = New System.Drawing.Size(939, 360)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "(1) Summary "
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'grdSum
        '
        Me.grdSum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdSum.Location = New System.Drawing.Point(7, 4)
        Me.grdSum.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grdSum.Name = "grdSum"
        Me.grdSum.RowTemplate.Height = 15
        Me.grdSum.Size = New System.Drawing.Size(929, 352)
        Me.grdSum.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.grdDtl)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage2.Size = New System.Drawing.Size(939, 360)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "(2) Details "
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'grdDtl
        '
        Me.grdDtl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDtl.Location = New System.Drawing.Point(7, 4)
        Me.grdDtl.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grdDtl.Name = "grdDtl"
        Me.grdDtl.RowTemplate.Height = 15
        Me.grdDtl.Size = New System.Drawing.Size(929, 352)
        Me.grdDtl.TabIndex = 1
        '
        'SAM00002
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(954, 631)
        Me.Controls.Add(Me.menuStrip)
        Me.Controls.Add(Me.cmd_S_ItmNo2)
        Me.Controls.Add(Me.rdbvenitm)
        Me.Controls.Add(Me.rdbitmno)
        Me.Controls.Add(Me.txtVendor)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtVenItmNo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmd_S_ItmNo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtUpdDat)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtColCde)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdMapping)
        Me.Controls.Add(Me.txtItmNo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCusNo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.TabPageMain)
        Me.Controls.Add(Me.StatusBar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "SAM00002"
        Me.Text = "SAM00002 - Sample Order Summary (SAM02)"
        Me.StatusBar.ResumeLayout(False)
        Me.StatusBar.PerformLayout()
        Me.menuStrip.ResumeLayout(False)
        Me.menuStrip.PerformLayout()
        Me.TabPageMain.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.grdSum, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.grdDtl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents lblLeft As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblRight As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TabPageMain As ERPSystem.BaseTabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCusNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtItmNo As System.Windows.Forms.TextBox
    Friend WithEvents cmdMapping As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtColCde As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtUpdDat As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents grdSum As System.Windows.Forms.DataGridView
    Friend WithEvents grdDtl As System.Windows.Forms.DataGridView
    Friend WithEvents cmd_S_ItmNo As System.Windows.Forms.Button
    Friend WithEvents txtVenItmNo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtVendor As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents rdbitmno As System.Windows.Forms.RadioButton
    Friend WithEvents rdbvenitm As System.Windows.Forms.RadioButton
    Friend WithEvents cmd_S_ItmNo2 As System.Windows.Forms.Button
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
    Friend WithEvents menuStrip As System.Windows.Forms.MenuStrip
End Class
