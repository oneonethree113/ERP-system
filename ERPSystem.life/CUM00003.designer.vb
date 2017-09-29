<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CUM00003
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CUM00003))
        Me.StatusBar = New System.Windows.Forms.StatusBar
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel
        Me.StatusBarPanel2 = New System.Windows.Forms.StatusBarPanel
        Me.chbAlias = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.tpCUM00002_2 = New System.Windows.Forms.TabPage
        Me.grdCuItmPRC = New System.Windows.Forms.DataGridView
        Me.txtCusStyNo = New System.Windows.Forms.TextBox
        Me.txtCusItm = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtItmNo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btcCUM00002 = New System.Windows.Forms.TabControl
        Me.tpCUM00002_1 = New System.Windows.Forms.TabPage
        Me.grdCuItmHis = New System.Windows.Forms.DataGridView
        Me.tpCUM00002_3 = New System.Windows.Forms.TabPage
        Me.grdCuItmPrcDtl = New System.Windows.Forms.DataGridView
        Me.cmdBrowse = New System.Windows.Forms.Button
        Me.cmdMapping = New System.Windows.Forms.Button
        Me.txtSecSna = New System.Windows.Forms.TextBox
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtCusNam = New System.Windows.Forms.TextBox
        Me.txtSecCus = New System.Windows.Forms.TextBox
        Me.txtCusNo = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
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
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpCUM00002_2.SuspendLayout()
        CType(Me.grdCuItmPRC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.btcCUM00002.SuspendLayout()
        Me.tpCUM00002_1.SuspendLayout()
        CType(Me.grdCuItmHis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpCUM00002_3.SuspendLayout()
        CType(Me.grdCuItmPrcDtl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusBar
        '
        Me.StatusBar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusBar.Location = New System.Drawing.Point(0, 610)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanel1, Me.StatusBarPanel2})
        Me.StatusBar.ShowPanels = True
        Me.StatusBar.Size = New System.Drawing.Size(954, 21)
        Me.StatusBar.TabIndex = 301
        '
        'StatusBarPanel1
        '
        Me.StatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanel1.Name = "StatusBarPanel1"
        Me.StatusBarPanel1.Width = 469
        '
        'StatusBarPanel2
        '
        Me.StatusBarPanel2.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.StatusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanel2.Name = "StatusBarPanel2"
        Me.StatusBarPanel2.Width = 469
        '
        'chbAlias
        '
        Me.chbAlias.AutoSize = True
        Me.chbAlias.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chbAlias.Location = New System.Drawing.Point(769, 80)
        Me.chbAlias.Name = "chbAlias"
        Me.chbAlias.Size = New System.Drawing.Size(139, 16)
        Me.chbAlias.TabIndex = 290
        Me.chbAlias.Text = "Alias Customer Included"
        Me.chbAlias.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chbAlias.UseVisualStyleBackColor = True
        Me.chbAlias.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label3.Location = New System.Drawing.Point(494, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 12)
        Me.Label3.TabIndex = 300
        Me.Label3.Text = "Customer Style Number"
        '
        'tpCUM00002_2
        '
        Me.tpCUM00002_2.Controls.Add(Me.grdCuItmPRC)
        Me.tpCUM00002_2.Location = New System.Drawing.Point(4, 22)
        Me.tpCUM00002_2.Name = "tpCUM00002_2"
        Me.tpCUM00002_2.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCUM00002_2.Size = New System.Drawing.Size(948, 494)
        Me.tpCUM00002_2.TabIndex = 1
        Me.tpCUM00002_2.Text = "(2) Pricing"
        Me.tpCUM00002_2.UseVisualStyleBackColor = True
        '
        'grdCuItmPRC
        '
        Me.grdCuItmPRC.AllowUserToAddRows = False
        Me.grdCuItmPRC.AllowUserToDeleteRows = False
        Me.grdCuItmPRC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCuItmPRC.Location = New System.Drawing.Point(1, 4)
        Me.grdCuItmPRC.Name = "grdCuItmPRC"
        Me.grdCuItmPRC.RowHeadersWidth = 20
        Me.grdCuItmPRC.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdCuItmPRC.RowTemplate.Height = 16
        Me.grdCuItmPRC.Size = New System.Drawing.Size(937, 475)
        Me.grdCuItmPRC.TabIndex = 25
        '
        'txtCusStyNo
        '
        Me.txtCusStyNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCusStyNo.Location = New System.Drawing.Point(628, 77)
        Me.txtCusStyNo.MaxLength = 50
        Me.txtCusStyNo.Name = "txtCusStyNo"
        Me.txtCusStyNo.Size = New System.Drawing.Size(138, 20)
        Me.txtCusStyNo.TabIndex = 292
        '
        'txtCusItm
        '
        Me.txtCusItm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCusItm.Location = New System.Drawing.Point(628, 51)
        Me.txtCusItm.MaxLength = 50
        Me.txtCusItm.Name = "txtCusItm"
        Me.txtCusItm.Size = New System.Drawing.Size(138, 20)
        Me.txtCusItm.TabIndex = 291
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label4.Location = New System.Drawing.Point(493, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 12)
        Me.Label4.TabIndex = 299
        Me.Label4.Text = "Customer Item No."
        '
        'txtItmNo
        '
        Me.txtItmNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtItmNo.Location = New System.Drawing.Point(628, 27)
        Me.txtItmNo.MaxLength = 100
        Me.txtItmNo.Name = "txtItmNo"
        Me.txtItmNo.Size = New System.Drawing.Size(138, 20)
        Me.txtItmNo.TabIndex = 287
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label1.Location = New System.Drawing.Point(492, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 12)
        Me.Label1.TabIndex = 298
        Me.Label1.Text = "Item No."
        '
        'btcCUM00002
        '
        Me.btcCUM00002.Controls.Add(Me.tpCUM00002_1)
        Me.btcCUM00002.Controls.Add(Me.tpCUM00002_2)
        Me.btcCUM00002.Controls.Add(Me.tpCUM00002_3)
        Me.btcCUM00002.Location = New System.Drawing.Point(0, 99)
        Me.btcCUM00002.Name = "btcCUM00002"
        Me.btcCUM00002.SelectedIndex = 0
        Me.btcCUM00002.Size = New System.Drawing.Size(956, 520)
        Me.btcCUM00002.TabIndex = 293
        '
        'tpCUM00002_1
        '
        Me.tpCUM00002_1.Controls.Add(Me.grdCuItmHis)
        Me.tpCUM00002_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.tpCUM00002_1.Location = New System.Drawing.Point(4, 22)
        Me.tpCUM00002_1.Name = "tpCUM00002_1"
        Me.tpCUM00002_1.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCUM00002_1.Size = New System.Drawing.Size(948, 494)
        Me.tpCUM00002_1.TabIndex = 0
        Me.tpCUM00002_1.Text = "(1) History"
        Me.tpCUM00002_1.UseVisualStyleBackColor = True
        '
        'grdCuItmHis
        '
        Me.grdCuItmHis.AllowUserToAddRows = False
        Me.grdCuItmHis.AllowUserToDeleteRows = False
        Me.grdCuItmHis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCuItmHis.Location = New System.Drawing.Point(1, 2)
        Me.grdCuItmHis.Name = "grdCuItmHis"
        Me.grdCuItmHis.RowHeadersWidth = 20
        Me.grdCuItmHis.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdCuItmHis.RowTemplate.Height = 16
        Me.grdCuItmHis.Size = New System.Drawing.Size(946, 485)
        Me.grdCuItmHis.TabIndex = 24
        '
        'tpCUM00002_3
        '
        Me.tpCUM00002_3.Controls.Add(Me.grdCuItmPrcDtl)
        Me.tpCUM00002_3.Location = New System.Drawing.Point(4, 22)
        Me.tpCUM00002_3.Name = "tpCUM00002_3"
        Me.tpCUM00002_3.Size = New System.Drawing.Size(948, 494)
        Me.tpCUM00002_3.TabIndex = 2
        Me.tpCUM00002_3.Text = "(3) Pricing Detail"
        Me.tpCUM00002_3.UseVisualStyleBackColor = True
        '
        'grdCuItmPrcDtl
        '
        Me.grdCuItmPrcDtl.AllowUserToAddRows = False
        Me.grdCuItmPrcDtl.AllowUserToDeleteRows = False
        Me.grdCuItmPrcDtl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCuItmPrcDtl.Location = New System.Drawing.Point(1, 4)
        Me.grdCuItmPrcDtl.Name = "grdCuItmPrcDtl"
        Me.grdCuItmPrcDtl.RowHeadersWidth = 20
        Me.grdCuItmPrcDtl.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdCuItmPrcDtl.RowTemplate.Height = 16
        Me.grdCuItmPrcDtl.Size = New System.Drawing.Size(937, 475)
        Me.grdCuItmPrcDtl.TabIndex = 25
        '
        'cmdBrowse
        '
        Me.cmdBrowse.Image = CType(resources.GetObject("cmdBrowse.Image"), System.Drawing.Image)
        Me.cmdBrowse.Location = New System.Drawing.Point(804, 24)
        Me.cmdBrowse.Name = "cmdBrowse"
        Me.cmdBrowse.Size = New System.Drawing.Size(25, 23)
        Me.cmdBrowse.TabIndex = 288
        Me.ToolTip.SetToolTip(Me.cmdBrowse, "New Format Item's Color Mapping")
        Me.cmdBrowse.UseVisualStyleBackColor = True
        '
        'cmdMapping
        '
        Me.cmdMapping.Image = CType(resources.GetObject("cmdMapping.Image"), System.Drawing.Image)
        Me.cmdMapping.Location = New System.Drawing.Point(835, 24)
        Me.cmdMapping.Name = "cmdMapping"
        Me.cmdMapping.Size = New System.Drawing.Size(25, 23)
        Me.cmdMapping.TabIndex = 289
        Me.ToolTip.SetToolTip(Me.cmdMapping, "Old & New Item Mapping")
        Me.cmdMapping.UseVisualStyleBackColor = True
        '
        'txtSecSna
        '
        Me.txtSecSna.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtSecSna.Location = New System.Drawing.Point(238, 51)
        Me.txtSecSna.MaxLength = 10
        Me.txtSecSna.Name = "txtSecSna"
        Me.txtSecSna.Size = New System.Drawing.Size(234, 20)
        Me.txtSecSna.TabIndex = 297
        '
        'txtCusNam
        '
        Me.txtCusNam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCusNam.Location = New System.Drawing.Point(238, 27)
        Me.txtCusNam.MaxLength = 10
        Me.txtCusNam.Name = "txtCusNam"
        Me.txtCusNam.Size = New System.Drawing.Size(234, 20)
        Me.txtCusNam.TabIndex = 296
        '
        'txtSecCus
        '
        Me.txtSecCus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtSecCus.Location = New System.Drawing.Point(153, 51)
        Me.txtSecCus.MaxLength = 20
        Me.txtSecCus.Name = "txtSecCus"
        Me.txtSecCus.Size = New System.Drawing.Size(85, 20)
        Me.txtSecCus.TabIndex = 286
        '
        'txtCusNo
        '
        Me.txtCusNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCusNo.Location = New System.Drawing.Point(153, 27)
        Me.txtCusNo.MaxLength = 20
        Me.txtCusNo.Name = "txtCusNo"
        Me.txtCusNo.Size = New System.Drawing.Size(85, 20)
        Me.txtCusNo.TabIndex = 285
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label5.Location = New System.Drawing.Point(16, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(122, 12)
        Me.Label5.TabIndex = 295
        Me.Label5.Text = "Secondary Customer No."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(16, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 12)
        Me.Label2.TabIndex = 294
        Me.Label2.Text = "Primary Customer No."
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(864, 24)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(40, 23)
        Me.Button1.TabIndex = 302
        Me.Button1.Text = "＞＞"
        '
        'menuStrip
        '
        Me.menuStrip.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mmdAdd, Me.mmdSave, Me.mmdDelete, Me.mmdCopy, Me.mmdFind, Me.t1, Me.mmdClear, Me.t2, Me.mmdSearch, Me.t3, Me.mmdInsRow, Me.mmdDelRow, Me.t4, Me.mmdPrint, Me.t5, Me.mmdAttach, Me.t6, Me.mmdFunction, Me.t7, Me.mmdLink, Me.t8, Me.mmdExit})
        Me.menuStrip.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip.Name = "menuStrip"
        Me.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.menuStrip.Size = New System.Drawing.Size(954, 24)
        Me.menuStrip.TabIndex = 303
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
        'CUM00003
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(954, 631)
        Me.Controls.Add(Me.menuStrip)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.chbAlias)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCusStyNo)
        Me.Controls.Add(Me.txtCusItm)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtItmNo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btcCUM00002)
        Me.Controls.Add(Me.cmdBrowse)
        Me.Controls.Add(Me.cmdMapping)
        Me.Controls.Add(Me.txtSecSna)
        Me.Controls.Add(Me.txtCusNam)
        Me.Controls.Add(Me.txtSecCus)
        Me.Controls.Add(Me.txtCusNo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.menuStrip
        Me.MaximizeBox = False
        Me.Name = "CUM00003"
        Me.Text = "CUM00003 - Customer Item History Maintenance (CUM03)"
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpCUM00002_2.ResumeLayout(False)
        CType(Me.grdCuItmPRC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.btcCUM00002.ResumeLayout(False)
        Me.tpCUM00002_1.ResumeLayout(False)
        CType(Me.grdCuItmHis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpCUM00002_3.ResumeLayout(False)
        CType(Me.grdCuItmPrcDtl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuStrip.ResumeLayout(False)
        Me.menuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusBar As System.Windows.Forms.StatusBar
    Friend WithEvents StatusBarPanel1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents StatusBarPanel2 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents chbAlias As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tpCUM00002_2 As System.Windows.Forms.TabPage
    Friend WithEvents grdCuItmPRC As System.Windows.Forms.DataGridView
    Friend WithEvents txtCusStyNo As System.Windows.Forms.TextBox
    Friend WithEvents txtCusItm As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtItmNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btcCUM00002 As System.Windows.Forms.TabControl
    Friend WithEvents tpCUM00002_1 As System.Windows.Forms.TabPage
    Friend WithEvents grdCuItmHis As System.Windows.Forms.DataGridView
    Friend WithEvents cmdBrowse As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents cmdMapping As System.Windows.Forms.Button
    Friend WithEvents txtSecSna As System.Windows.Forms.TextBox
    Friend WithEvents txtCusNam As System.Windows.Forms.TextBox
    Friend WithEvents txtSecCus As System.Windows.Forms.TextBox
    Friend WithEvents txtCusNo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents tpCUM00002_3 As System.Windows.Forms.TabPage
    Friend WithEvents grdCuItmPrcDtl As System.Windows.Forms.DataGridView
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
