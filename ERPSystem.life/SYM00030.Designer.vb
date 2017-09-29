<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SYM00030
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SYM00030))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Txt_PriCustno = New System.Windows.Forms.TextBox
        Me.Txt_SecCustno = New System.Windows.Forms.TextBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.dg_shipping = New System.Windows.Forms.DataGridView
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.dg_invoice = New System.Windows.Forms.DataGridView
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.dg_packing = New System.Windows.Forms.DataGridView
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.dg_label = New System.Windows.Forms.DataGridView
        Me.dg_usv = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.mypanel = New System.Windows.Forms.Panel
        Me.cbo_fielddesc = New System.Windows.Forms.ComboBox
        Me.txt_fieldvalue = New System.Windows.Forms.TextBox
        Me.txt_fielddesc = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmdPanConfim = New System.Windows.Forms.Button
        Me.cmdPanCancel = New System.Windows.Forms.Button
        Me.chk_globalview = New System.Windows.Forms.CheckBox
        Me.txt_valuepreview = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.StatusBar = New System.Windows.Forms.StatusStrip
        Me.lblLeft = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblRight = New System.Windows.Forms.ToolStripStatusLabel
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
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dg_shipping, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dg_invoice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.dg_packing, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.dg_label, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg_usv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.mypanel.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.StatusBar.SuspendLayout()
        Me.menuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 12)
        Me.Label1.TabIndex = 215
        Me.Label1.Text = "Primary Customer No"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 12)
        Me.Label2.TabIndex = 216
        Me.Label2.Text = "Secondary Customer No"
        '
        'Txt_PriCustno
        '
        Me.Txt_PriCustno.Location = New System.Drawing.Point(169, 31)
        Me.Txt_PriCustno.Name = "Txt_PriCustno"
        Me.Txt_PriCustno.Size = New System.Drawing.Size(165, 22)
        Me.Txt_PriCustno.TabIndex = 217
        '
        'Txt_SecCustno
        '
        Me.Txt_SecCustno.Location = New System.Drawing.Point(169, 53)
        Me.Txt_SecCustno.Name = "Txt_SecCustno"
        Me.Txt_SecCustno.Size = New System.Drawing.Size(165, 22)
        Me.Txt_SecCustno.TabIndex = 218
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(12, 78)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(216, 277)
        Me.TabControl1.TabIndex = 219
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dg_shipping)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(208, 251)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Shipping"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dg_shipping
        '
        Me.dg_shipping.AllowUserToAddRows = False
        Me.dg_shipping.AllowUserToResizeColumns = False
        Me.dg_shipping.AllowUserToResizeRows = False
        Me.dg_shipping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_shipping.Location = New System.Drawing.Point(1, 0)
        Me.dg_shipping.Name = "dg_shipping"
        Me.dg_shipping.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dg_shipping.RowTemplate.Height = 24
        Me.dg_shipping.Size = New System.Drawing.Size(207, 249)
        Me.dg_shipping.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dg_invoice)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(208, 251)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Invoice"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dg_invoice
        '
        Me.dg_invoice.AllowUserToAddRows = False
        Me.dg_invoice.AllowUserToResizeColumns = False
        Me.dg_invoice.AllowUserToResizeRows = False
        Me.dg_invoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_invoice.Location = New System.Drawing.Point(1, 0)
        Me.dg_invoice.Name = "dg_invoice"
        Me.dg_invoice.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dg_invoice.RowTemplate.Height = 24
        Me.dg_invoice.Size = New System.Drawing.Size(207, 249)
        Me.dg_invoice.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.dg_packing)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(208, 251)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Packing"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'dg_packing
        '
        Me.dg_packing.AllowUserToAddRows = False
        Me.dg_packing.AllowUserToResizeColumns = False
        Me.dg_packing.AllowUserToResizeRows = False
        Me.dg_packing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_packing.Location = New System.Drawing.Point(1, 0)
        Me.dg_packing.Name = "dg_packing"
        Me.dg_packing.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dg_packing.RowTemplate.Height = 24
        Me.dg_packing.Size = New System.Drawing.Size(207, 249)
        Me.dg_packing.TabIndex = 1
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.dg_label)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(208, 251)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Label"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'dg_label
        '
        Me.dg_label.AllowUserToAddRows = False
        Me.dg_label.AllowUserToResizeColumns = False
        Me.dg_label.AllowUserToResizeRows = False
        Me.dg_label.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_label.Location = New System.Drawing.Point(1, 0)
        Me.dg_label.Name = "dg_label"
        Me.dg_label.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dg_label.RowTemplate.Height = 24
        Me.dg_label.Size = New System.Drawing.Size(207, 249)
        Me.dg_label.TabIndex = 1
        '
        'dg_usv
        '
        Me.dg_usv.AllowUserToResizeColumns = False
        Me.dg_usv.AllowUserToResizeRows = False
        Me.dg_usv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_usv.Location = New System.Drawing.Point(2, 17)
        Me.dg_usv.Name = "dg_usv"
        Me.dg_usv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dg_usv.RowTemplate.Height = 24
        Me.dg_usv.Size = New System.Drawing.Size(716, 256)
        Me.dg_usv.TabIndex = 220
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.mypanel)
        Me.GroupBox1.Controls.Add(Me.dg_usv)
        Me.GroupBox1.Location = New System.Drawing.Point(234, 81)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(720, 274)
        Me.GroupBox1.TabIndex = 221
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "User Defied Value"
        '
        'mypanel
        '
        Me.mypanel.BackColor = System.Drawing.Color.CadetBlue
        Me.mypanel.Controls.Add(Me.cbo_fielddesc)
        Me.mypanel.Controls.Add(Me.txt_fieldvalue)
        Me.mypanel.Controls.Add(Me.txt_fielddesc)
        Me.mypanel.Controls.Add(Me.Label9)
        Me.mypanel.Controls.Add(Me.Label10)
        Me.mypanel.Controls.Add(Me.cmdPanConfim)
        Me.mypanel.Controls.Add(Me.cmdPanCancel)
        Me.mypanel.Location = New System.Drawing.Point(2, 16)
        Me.mypanel.Name = "mypanel"
        Me.mypanel.Size = New System.Drawing.Size(716, 257)
        Me.mypanel.TabIndex = 222
        Me.mypanel.Visible = False
        '
        'cbo_fielddesc
        '
        Me.cbo_fielddesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cbo_fielddesc.FormattingEnabled = True
        Me.cbo_fielddesc.Location = New System.Drawing.Point(82, 193)
        Me.cbo_fielddesc.Name = "cbo_fielddesc"
        Me.cbo_fielddesc.Size = New System.Drawing.Size(609, 21)
        Me.cbo_fielddesc.TabIndex = 137
        '
        'txt_fieldvalue
        '
        Me.txt_fieldvalue.Font = New System.Drawing.Font("Courier New", 8.25!)
        Me.txt_fieldvalue.Location = New System.Drawing.Point(82, 17)
        Me.txt_fieldvalue.Multiline = True
        Me.txt_fieldvalue.Name = "txt_fieldvalue"
        Me.txt_fieldvalue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_fieldvalue.Size = New System.Drawing.Size(609, 169)
        Me.txt_fieldvalue.TabIndex = 136
        '
        'txt_fielddesc
        '
        Me.txt_fielddesc.Font = New System.Drawing.Font("Courier New", 8.25!)
        Me.txt_fielddesc.Location = New System.Drawing.Point(82, 193)
        Me.txt_fielddesc.Name = "txt_fielddesc"
        Me.txt_fielddesc.Size = New System.Drawing.Size(609, 20)
        Me.txt_fielddesc.TabIndex = 135
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label9.Location = New System.Drawing.Point(8, 195)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 15)
        Me.Label9.TabIndex = 134
        Me.Label9.Text = "Description"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label10.Location = New System.Drawing.Point(10, 19)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 15)
        Me.Label10.TabIndex = 132
        Me.Label10.Text = "Field Value"
        '
        'cmdPanConfim
        '
        Me.cmdPanConfim.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPanConfim.Location = New System.Drawing.Point(297, 219)
        Me.cmdPanConfim.Name = "cmdPanConfim"
        Me.cmdPanConfim.Size = New System.Drawing.Size(65, 19)
        Me.cmdPanConfim.TabIndex = 129
        Me.cmdPanConfim.Text = "Insert"
        Me.cmdPanConfim.UseVisualStyleBackColor = True
        '
        'cmdPanCancel
        '
        Me.cmdPanCancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPanCancel.Location = New System.Drawing.Point(369, 219)
        Me.cmdPanCancel.Name = "cmdPanCancel"
        Me.cmdPanCancel.Size = New System.Drawing.Size(65, 20)
        Me.cmdPanCancel.TabIndex = 131
        Me.cmdPanCancel.Text = "Cancel"
        Me.cmdPanCancel.UseVisualStyleBackColor = True
        '
        'chk_globalview
        '
        Me.chk_globalview.AutoSize = True
        Me.chk_globalview.Location = New System.Drawing.Point(351, 35)
        Me.chk_globalview.Name = "chk_globalview"
        Me.chk_globalview.Size = New System.Drawing.Size(82, 16)
        Me.chk_globalview.TabIndex = 222
        Me.chk_globalview.Text = "Global View"
        Me.chk_globalview.UseVisualStyleBackColor = True
        '
        'txt_valuepreview
        '
        Me.txt_valuepreview.Font = New System.Drawing.Font("Courier New", 8.25!)
        Me.txt_valuepreview.Location = New System.Drawing.Point(6, 18)
        Me.txt_valuepreview.Multiline = True
        Me.txt_valuepreview.Name = "txt_valuepreview"
        Me.txt_valuepreview.ReadOnly = True
        Me.txt_valuepreview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_valuepreview.Size = New System.Drawing.Size(930, 223)
        Me.txt_valuepreview.TabIndex = 223
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txt_valuepreview)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 357)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(942, 247)
        Me.GroupBox2.TabIndex = 224
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Value Preview"
        '
        'StatusBar
        '
        Me.StatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblLeft, Me.lblRight})
        Me.StatusBar.Location = New System.Drawing.Point(0, 607)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Size = New System.Drawing.Size(954, 24)
        Me.StatusBar.TabIndex = 225
        Me.StatusBar.Text = "StatusStrip1"
        '
        'lblLeft
        '
        Me.lblLeft.AutoSize = False
        Me.lblLeft.Name = "lblLeft"
        Me.lblLeft.Size = New System.Drawing.Size(550, 19)
        Me.lblLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRight
        '
        Me.lblRight.AutoSize = False
        Me.lblRight.Name = "lblRight"
        Me.lblRight.Size = New System.Drawing.Size(389, 19)
        Me.lblRight.Spring = True
        Me.lblRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'menuStrip
        '
        Me.menuStrip.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mmdAdd, Me.mmdSave, Me.mmdDelete, Me.mmdCopy, Me.mmdFind, Me.t1, Me.mmdClear, Me.t2, Me.mmdSearch, Me.t3, Me.mmdInsRow, Me.mmdDelRow, Me.t4, Me.mmdPrint, Me.t5, Me.mmdAttach, Me.t6, Me.mmdFunction, Me.t7, Me.mmdLink, Me.t8, Me.mmdExit})
        Me.menuStrip.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip.Name = "menuStrip"
        Me.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.menuStrip.Size = New System.Drawing.Size(954, 24)
        Me.menuStrip.TabIndex = 305
        Me.menuStrip.Text = "MenuStrip1"
        '
        'mmdAdd
        '
        Me.mmdAdd.BackColor = System.Drawing.SystemColors.Control
        Me.mmdAdd.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdAdd.Name = "mmdAdd"
        Me.mmdAdd.Size = New System.Drawing.Size(40, 20)
        Me.mmdAdd.Tag = "Add"
        Me.mmdAdd.Text = "&Add"
        '
        'mmdSave
        '
        Me.mmdSave.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdSave.Name = "mmdSave"
        Me.mmdSave.Size = New System.Drawing.Size(46, 20)
        Me.mmdSave.Text = "&Save"
        '
        'mmdDelete
        '
        Me.mmdDelete.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdDelete.Name = "mmdDelete"
        Me.mmdDelete.Size = New System.Drawing.Size(55, 20)
        Me.mmdDelete.Text = "&Delete"
        '
        'mmdCopy
        '
        Me.mmdCopy.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdCopy.Name = "mmdCopy"
        Me.mmdCopy.Size = New System.Drawing.Size(47, 20)
        Me.mmdCopy.Text = "&Copy"
        '
        'mmdFind
        '
        Me.mmdFind.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdFind.Name = "mmdFind"
        Me.mmdFind.Size = New System.Drawing.Size(43, 20)
        Me.mmdFind.Text = "&Find"
        '
        't1
        '
        Me.t1.AutoSize = False
        Me.t1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.t1.Enabled = False
        Me.t1.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.t1.Name = "t1"
        Me.t1.Size = New System.Drawing.Size(8, 20)
        Me.t1.Text = "|"
        '
        'mmdClear
        '
        Me.mmdClear.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdClear.Name = "mmdClear"
        Me.mmdClear.Size = New System.Drawing.Size(49, 20)
        Me.mmdClear.Text = "Cl&ear"
        '
        't2
        '
        Me.t2.AutoSize = False
        Me.t2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.t2.Enabled = False
        Me.t2.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.t2.Name = "t2"
        Me.t2.Size = New System.Drawing.Size(8, 20)
        Me.t2.Text = "|"
        '
        'mmdSearch
        '
        Me.mmdSearch.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdSearch.Name = "mmdSearch"
        Me.mmdSearch.Size = New System.Drawing.Size(58, 20)
        Me.mmdSearch.Text = "Searc&h"
        '
        't3
        '
        Me.t3.AutoSize = False
        Me.t3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.t3.Enabled = False
        Me.t3.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.t3.Name = "t3"
        Me.t3.Size = New System.Drawing.Size(8, 20)
        Me.t3.Text = "|"
        '
        'mmdInsRow
        '
        Me.mmdInsRow.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdInsRow.Name = "mmdInsRow"
        Me.mmdInsRow.Size = New System.Drawing.Size(64, 20)
        Me.mmdInsRow.Text = "In&s Row"
        '
        'mmdDelRow
        '
        Me.mmdDelRow.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdDelRow.Name = "mmdDelRow"
        Me.mmdDelRow.Size = New System.Drawing.Size(66, 20)
        Me.mmdDelRow.Text = "Del Ro&w"
        '
        't4
        '
        Me.t4.AutoSize = False
        Me.t4.Enabled = False
        Me.t4.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.t4.Name = "t4"
        Me.t4.Size = New System.Drawing.Size(8, 20)
        Me.t4.Text = "|"
        '
        'mmdPrint
        '
        Me.mmdPrint.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdPrint.Name = "mmdPrint"
        Me.mmdPrint.Size = New System.Drawing.Size(44, 20)
        Me.mmdPrint.Text = "&Print"
        '
        't5
        '
        Me.t5.AutoSize = False
        Me.t5.Enabled = False
        Me.t5.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.t5.Name = "t5"
        Me.t5.Size = New System.Drawing.Size(8, 20)
        Me.t5.Text = "|"
        '
        'mmdAttach
        '
        Me.mmdAttach.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdAttach.Name = "mmdAttach"
        Me.mmdAttach.Size = New System.Drawing.Size(52, 20)
        Me.mmdAttach.Text = "Attach"
        '
        't6
        '
        Me.t6.AutoSize = False
        Me.t6.Enabled = False
        Me.t6.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.t6.Name = "t6"
        Me.t6.Size = New System.Drawing.Size(8, 20)
        Me.t6.Text = "|"
        '
        'mmdFunction
        '
        Me.mmdFunction.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mmdRel, Me.mmdApv})
        Me.mmdFunction.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdFunction.Name = "mmdFunction"
        Me.mmdFunction.Size = New System.Drawing.Size(66, 20)
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
        Me.t7.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.t7.Name = "t7"
        Me.t7.Size = New System.Drawing.Size(8, 20)
        Me.t7.Text = "|"
        '
        'mmdLink
        '
        Me.mmdLink.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdLink.Name = "mmdLink"
        Me.mmdLink.Size = New System.Drawing.Size(42, 20)
        Me.mmdLink.Text = "Link"
        '
        't8
        '
        Me.t8.AutoSize = False
        Me.t8.Enabled = False
        Me.t8.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.t8.Name = "t8"
        Me.t8.Size = New System.Drawing.Size(8, 20)
        Me.t8.Text = "|"
        '
        'mmdExit
        '
        Me.mmdExit.Name = "mmdExit"
        Me.mmdExit.Size = New System.Drawing.Size(38, 20)
        Me.mmdExit.Text = "E&xit"
        '
        'SYM00030
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(954, 631)
        Me.Controls.Add(Me.menuStrip)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.chk_globalview)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Txt_SecCustno)
        Me.Controls.Add(Me.Txt_PriCustno)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.menuStrip
        Me.MaximizeBox = False
        Me.Name = "SYM00030"
        Me.Text = "SYM00030 - Customer Self-defined Maintenance (SYM30)"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dg_shipping, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dg_invoice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.dg_packing, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        CType(Me.dg_label, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg_usv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.mypanel.ResumeLayout(False)
        Me.mypanel.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.StatusBar.ResumeLayout(False)
        Me.StatusBar.PerformLayout()
        Me.menuStrip.ResumeLayout(False)
        Me.menuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Txt_PriCustno As System.Windows.Forms.TextBox
    Friend WithEvents Txt_SecCustno As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dg_usv As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dg_shipping As System.Windows.Forms.DataGridView
    Friend WithEvents dg_invoice As System.Windows.Forms.DataGridView
    Friend WithEvents mypanel As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmdPanConfim As System.Windows.Forms.Button
    Friend WithEvents cmdPanCancel As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_fieldvalue As System.Windows.Forms.TextBox
    Friend WithEvents txt_fielddesc As System.Windows.Forms.TextBox
    Friend WithEvents chk_globalview As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents dg_packing As System.Windows.Forms.DataGridView
    Friend WithEvents txt_valuepreview As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents StatusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents lblLeft As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblRight As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents dg_label As System.Windows.Forms.DataGridView
    Friend WithEvents cbo_fielddesc As System.Windows.Forms.ComboBox
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
