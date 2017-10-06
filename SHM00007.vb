Public Class SHM00007
    Inherits System.Windows.Forms.Form


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtdocno As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCredat As System.Windows.Forms.TextBox
    Friend WithEvents txtUpddat As System.Windows.Forms.TextBox
    Friend WithEvents pDocTyp As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents rbDocTyp_D As System.Windows.Forms.RadioButton
    Friend WithEvents rbDocTyp_C As System.Windows.Forms.RadioButton
    Friend WithEvents btcSHM00007 As ERPSystem.BaseTabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgSHCHGDTL_CORE As System.Windows.Forms.DataGridView
    Friend WithEvents gbDocTyp_D_Entry As System.Windows.Forms.GroupBox
    Friend WithEvents txtCustList As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtInvNoList As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents gbDocTyp_C_Entry As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCtn As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmdInvMore As System.Windows.Forms.Button
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents lstVendor As System.Windows.Forms.ListBox
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtCusNoList As System.Windows.Forms.TextBox
    Friend WithEvents dgINVMORE As System.Windows.Forms.DataGridView
    Friend WithEvents mskETDDat As System.Windows.Forms.DateTimePicker
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents gbHeaderMain As System.Windows.Forms.GroupBox
    Friend WithEvents rtxtRmk As System.Windows.Forms.RichTextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cboBCurr As System.Windows.Forms.ComboBox
    Friend WithEvents cboFCurr As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents mskExchRat As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtFwdInv As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dgSHCHGDTL_Distribute As System.Windows.Forms.DataGridView
    Friend WithEvents cmdBck As System.Windows.Forms.Button
    Friend WithEvents cmdNxt As System.Windows.Forms.Button
    Friend WithEvents txtShpSeq As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cbofwd As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents chkDel As System.Windows.Forms.CheckBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboCtnSiz As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents mskPckDat As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgSHCHGFWD As System.Windows.Forms.DataGridView
    Friend WithEvents txtconsol As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cbofwdnam As System.Windows.Forms.ComboBox
    Friend WithEvents cbofcrno As System.Windows.Forms.ComboBox
    Friend WithEvents cms_CopyNPaste As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents smi_Copy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smi_Paste As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConvertToPlainTextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UndoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents mskExchRat_show As System.Windows.Forms.MaskedTextBox
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
    Friend WithEvents StatusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents lblLeft As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblRight As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents mmdExit As System.Windows.Forms.ToolStripMenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SHM00007))
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtdocno = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtCredat = New System.Windows.Forms.TextBox
        Me.txtUpddat = New System.Windows.Forms.TextBox
        Me.pDocTyp = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.rbDocTyp_D = New System.Windows.Forms.RadioButton
        Me.rbDocTyp_C = New System.Windows.Forms.RadioButton
        Me.txtStatus = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.cms_CopyNPaste = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.smi_Copy = New System.Windows.Forms.ToolStripMenuItem
        Me.smi_Paste = New System.Windows.Forms.ToolStripMenuItem
        Me.ConvertToPlainTextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UndoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
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
        Me.StatusBar = New System.Windows.Forms.StatusStrip
        Me.lblLeft = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblRight = New System.Windows.Forms.ToolStripStatusLabel
        Me.btcSHM00007 = New ERPSystem.BaseTabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.dgSHCHGFWD = New System.Windows.Forms.DataGridView
        Me.cmdInvMore = New System.Windows.Forms.Button
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.gbDocTyp_D_Entry = New System.Windows.Forms.GroupBox
        Me.txtCusNoList = New System.Windows.Forms.TextBox
        Me.dgINVMORE = New System.Windows.Forms.DataGridView
        Me.txtCustList = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtInvNoList = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboCtnSiz = New System.Windows.Forms.ComboBox
        Me.mskPckDat = New System.Windows.Forms.DateTimePicker
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.gbDocTyp_C_Entry = New System.Windows.Forms.GroupBox
        Me.txtconsol = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.mskETDDat = New System.Windows.Forms.DateTimePicker
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtCtn = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.gbHeaderMain = New System.Windows.Forms.GroupBox
        Me.cbofcrno = New System.Windows.Forms.ComboBox
        Me.cbofwdnam = New System.Windows.Forms.ComboBox
        Me.chkDel = New System.Windows.Forms.CheckBox
        Me.txtShpSeq = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.cmdBck = New System.Windows.Forms.Button
        Me.cmdNxt = New System.Windows.Forms.Button
        Me.dgSHCHGDTL_Distribute = New System.Windows.Forms.DataGridView
        Me.rtxtRmk = New System.Windows.Forms.RichTextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.cboBCurr = New System.Windows.Forms.ComboBox
        Me.cboFCurr = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.mskExchRat = New System.Windows.Forms.MaskedTextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtFwdInv = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Label23 = New System.Windows.Forms.Label
        Me.mskExchRat_show = New System.Windows.Forms.MaskedTextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.cbofwd = New System.Windows.Forms.ComboBox
        Me.lstVendor = New System.Windows.Forms.ListBox
        Me.dgSHCHGDTL_CORE = New System.Windows.Forms.DataGridView
        Me.pDocTyp.SuspendLayout()
        Me.cms_CopyNPaste.SuspendLayout()
        Me.menuStrip.SuspendLayout()
        Me.StatusBar.SuspendLayout()
        Me.btcSHM00007.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgSHCHGFWD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDocTyp_D_Entry.SuspendLayout()
        CType(Me.dgINVMORE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDocTyp_C_Entry.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.gbHeaderMain.SuspendLayout()
        CType(Me.dgSHCHGDTL_Distribute, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgSHCHGDTL_CORE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Doc No"
        '
        'txtdocno
        '
        Me.txtdocno.Location = New System.Drawing.Point(62, 31)
        Me.txtdocno.Name = "txtdocno"
        Me.txtdocno.Size = New System.Drawing.Size(127, 22)
        Me.txtdocno.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(459, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 12)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Create"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(597, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 12)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Update"
        '
        'txtCredat
        '
        Me.txtCredat.Enabled = False
        Me.txtCredat.Location = New System.Drawing.Point(495, 30)
        Me.txtCredat.Name = "txtCredat"
        Me.txtCredat.Size = New System.Drawing.Size(76, 22)
        Me.txtCredat.TabIndex = 17
        '
        'txtUpddat
        '
        Me.txtUpddat.Enabled = False
        Me.txtUpddat.Location = New System.Drawing.Point(639, 30)
        Me.txtUpddat.Name = "txtUpddat"
        Me.txtUpddat.Size = New System.Drawing.Size(76, 22)
        Me.txtUpddat.TabIndex = 18
        '
        'pDocTyp
        '
        Me.pDocTyp.Controls.Add(Me.Label4)
        Me.pDocTyp.Controls.Add(Me.rbDocTyp_D)
        Me.pDocTyp.Controls.Add(Me.rbDocTyp_C)
        Me.pDocTyp.Location = New System.Drawing.Point(195, 28)
        Me.pDocTyp.Name = "pDocTyp"
        Me.pDocTyp.Size = New System.Drawing.Size(241, 30)
        Me.pDocTyp.TabIndex = 26
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 12)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Doc Type :"
        '
        'rbDocTyp_D
        '
        Me.rbDocTyp_D.AutoSize = True
        Me.rbDocTyp_D.Location = New System.Drawing.Point(164, 7)
        Me.rbDocTyp_D.Name = "rbDocTyp_D"
        Me.rbDocTyp_D.Size = New System.Drawing.Size(47, 16)
        Me.rbDocTyp_D.TabIndex = 16
        Me.rbDocTyp_D.Text = "床砯"
        Me.rbDocTyp_D.UseVisualStyleBackColor = True
        '
        'rbDocTyp_C
        '
        Me.rbDocTyp_C.AutoSize = True
        Me.rbDocTyp_C.Location = New System.Drawing.Point(99, 7)
        Me.rbDocTyp_C.Name = "rbDocTyp_C"
        Me.rbDocTyp_C.Size = New System.Drawing.Size(47, 16)
        Me.rbDocTyp_C.TabIndex = 15
        Me.rbDocTyp_C.Text = "螥砯"
        Me.rbDocTyp_C.UseVisualStyleBackColor = True
        '
        'txtStatus
        '
        Me.txtStatus.Enabled = False
        Me.txtStatus.Location = New System.Drawing.Point(792, 30)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(72, 22)
        Me.txtStatus.TabIndex = 52
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(748, 35)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(32, 12)
        Me.Label20.TabIndex = 53
        Me.Label20.Text = "Status"
        '
        'cms_CopyNPaste
        '
        Me.cms_CopyNPaste.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smi_Copy, Me.smi_Paste, Me.ConvertToPlainTextToolStripMenuItem, Me.UndoToolStripMenuItem})
        Me.cms_CopyNPaste.Name = "cms_CopyNPaste"
        Me.cms_CopyNPaste.Size = New System.Drawing.Size(145, 92)
        '
        'smi_Copy
        '
        Me.smi_Copy.AutoSize = False
        Me.smi_Copy.Name = "smi_Copy"
        Me.smi_Copy.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.smi_Copy.Size = New System.Drawing.Size(152, 22)
        Me.smi_Copy.Text = "Copy"
        Me.smi_Copy.ToolTipText = "Copy"
        '
        'smi_Paste
        '
        Me.smi_Paste.AutoSize = False
        Me.smi_Paste.Name = "smi_Paste"
        Me.smi_Paste.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.smi_Paste.Size = New System.Drawing.Size(170, 22)
        Me.smi_Paste.Text = "Paste"
        Me.smi_Paste.ToolTipText = "Paste"
        '
        'ConvertToPlainTextToolStripMenuItem
        '
        Me.ConvertToPlainTextToolStripMenuItem.Name = "ConvertToPlainTextToolStripMenuItem"
        Me.ConvertToPlainTextToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.T), System.Windows.Forms.Keys)
        Me.ConvertToPlainTextToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.ConvertToPlainTextToolStripMenuItem.Text = "Convert"
        '
        'UndoToolStripMenuItem
        '
        Me.UndoToolStripMenuItem.Name = "UndoToolStripMenuItem"
        Me.UndoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.U), System.Windows.Forms.Keys)
        Me.UndoToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.UndoToolStripMenuItem.Text = "Undo"
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
        Me.menuStrip.TabIndex = 336
        Me.menuStrip.Text = "MenuStrip1"
        '
        'mmdAdd
        '
        Me.mmdAdd.BackColor = System.Drawing.SystemColors.Control
        Me.mmdAdd.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdAdd.Name = "mmdAdd"
        Me.mmdAdd.Size = New System.Drawing.Size(40, 19)
        Me.mmdAdd.Tag = "Add"
        Me.mmdAdd.Text = "&Add"
        '
        'mmdSave
        '
        Me.mmdSave.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdSave.Name = "mmdSave"
        Me.mmdSave.Size = New System.Drawing.Size(46, 19)
        Me.mmdSave.Text = "&Save"
        '
        'mmdDelete
        '
        Me.mmdDelete.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdDelete.Name = "mmdDelete"
        Me.mmdDelete.Size = New System.Drawing.Size(55, 19)
        Me.mmdDelete.Text = "&Delete"
        '
        'mmdCopy
        '
        Me.mmdCopy.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdCopy.Name = "mmdCopy"
        Me.mmdCopy.Size = New System.Drawing.Size(47, 19)
        Me.mmdCopy.Text = "&Copy"
        '
        'mmdFind
        '
        Me.mmdFind.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdFind.Name = "mmdFind"
        Me.mmdFind.Size = New System.Drawing.Size(43, 19)
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
        Me.mmdClear.Size = New System.Drawing.Size(49, 19)
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
        Me.mmdSearch.Size = New System.Drawing.Size(58, 19)
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
        Me.mmdInsRow.Size = New System.Drawing.Size(64, 19)
        Me.mmdInsRow.Text = "In&s Row"
        '
        'mmdDelRow
        '
        Me.mmdDelRow.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdDelRow.Name = "mmdDelRow"
        Me.mmdDelRow.Size = New System.Drawing.Size(66, 19)
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
        Me.mmdPrint.Size = New System.Drawing.Size(44, 19)
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
        Me.mmdAttach.Size = New System.Drawing.Size(52, 19)
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
        Me.t7.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.t7.Name = "t7"
        Me.t7.Size = New System.Drawing.Size(8, 20)
        Me.t7.Text = "|"
        '
        'mmdLink
        '
        Me.mmdLink.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.mmdLink.Name = "mmdLink"
        Me.mmdLink.Size = New System.Drawing.Size(42, 19)
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
        Me.mmdExit.Size = New System.Drawing.Size(38, 19)
        Me.mmdExit.Text = "E&xit"
        '
        'StatusBar
        '
        Me.StatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblLeft, Me.lblRight})
        Me.StatusBar.Location = New System.Drawing.Point(0, 613)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Size = New System.Drawing.Size(954, 22)
        Me.StatusBar.TabIndex = 337
        Me.StatusBar.Text = "StatusStrip1"
        '
        'lblLeft
        '
        Me.lblLeft.AutoSize = False
        Me.lblLeft.Name = "lblLeft"
        Me.lblLeft.Size = New System.Drawing.Size(300, 17)
        Me.lblLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRight
        '
        Me.lblRight.AutoSize = False
        Me.lblRight.Name = "lblRight"
        Me.lblRight.Size = New System.Drawing.Size(639, 17)
        Me.lblRight.Spring = True
        Me.lblRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btcSHM00007
        '
        Me.btcSHM00007.Controls.Add(Me.TabPage1)
        Me.btcSHM00007.Controls.Add(Me.TabPage3)
        Me.btcSHM00007.Controls.Add(Me.TabPage2)
        Me.btcSHM00007.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.btcSHM00007.Location = New System.Drawing.Point(2, 62)
        Me.btcSHM00007.Name = "btcSHM00007"
        Me.btcSHM00007.SelectedIndex = 0
        Me.btcSHM00007.Size = New System.Drawing.Size(952, 547)
        Me.btcSHM00007.TabIndex = 51
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgSHCHGFWD)
        Me.TabPage1.Controls.Add(Me.cmdInvMore)
        Me.TabPage1.Controls.Add(Me.cmdRefresh)
        Me.TabPage1.Controls.Add(Me.gbDocTyp_D_Entry)
        Me.TabPage1.Controls.Add(Me.gbDocTyp_C_Entry)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(944, 521)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "(1) Header"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgSHCHGFWD
        '
        Me.dgSHCHGFWD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSHCHGFWD.Location = New System.Drawing.Point(4, 215)
        Me.dgSHCHGFWD.Name = "dgSHCHGFWD"
        Me.dgSHCHGFWD.RowHeadersWidth = 30
        Me.dgSHCHGFWD.RowTemplate.Height = 24
        Me.dgSHCHGFWD.Size = New System.Drawing.Size(940, 303)
        Me.dgSHCHGFWD.TabIndex = 99
        '
        'cmdInvMore
        '
        Me.cmdInvMore.Location = New System.Drawing.Point(875, 58)
        Me.cmdInvMore.Name = "cmdInvMore"
        Me.cmdInvMore.Size = New System.Drawing.Size(27, 23)
        Me.cmdInvMore.TabIndex = 84
        Me.cmdInvMore.Text = ".."
        Me.cmdInvMore.UseVisualStyleBackColor = True
        Me.cmdInvMore.Visible = False
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Location = New System.Drawing.Point(875, 9)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(61, 34)
        Me.cmdRefresh.TabIndex = 83
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        Me.cmdRefresh.Visible = False
        '
        'gbDocTyp_D_Entry
        '
        Me.gbDocTyp_D_Entry.Controls.Add(Me.txtCusNoList)
        Me.gbDocTyp_D_Entry.Controls.Add(Me.dgINVMORE)
        Me.gbDocTyp_D_Entry.Controls.Add(Me.txtCustList)
        Me.gbDocTyp_D_Entry.Controls.Add(Me.Label10)
        Me.gbDocTyp_D_Entry.Controls.Add(Me.txtInvNoList)
        Me.gbDocTyp_D_Entry.Controls.Add(Me.Label7)
        Me.gbDocTyp_D_Entry.Controls.Add(Me.cboCtnSiz)
        Me.gbDocTyp_D_Entry.Controls.Add(Me.mskPckDat)
        Me.gbDocTyp_D_Entry.Controls.Add(Me.Label14)
        Me.gbDocTyp_D_Entry.Controls.Add(Me.Label19)
        Me.gbDocTyp_D_Entry.Location = New System.Drawing.Point(6, 39)
        Me.gbDocTyp_D_Entry.Name = "gbDocTyp_D_Entry"
        Me.gbDocTyp_D_Entry.Size = New System.Drawing.Size(703, 175)
        Me.gbDocTyp_D_Entry.TabIndex = 81
        Me.gbDocTyp_D_Entry.TabStop = False
        '
        'txtCusNoList
        '
        Me.txtCusNoList.Enabled = False
        Me.txtCusNoList.Location = New System.Drawing.Point(87, 55)
        Me.txtCusNoList.Name = "txtCusNoList"
        Me.txtCusNoList.Size = New System.Drawing.Size(580, 22)
        Me.txtCusNoList.TabIndex = 75
        Me.txtCusNoList.Visible = False
        '
        'dgINVMORE
        '
        Me.dgINVMORE.AllowUserToAddRows = False
        Me.dgINVMORE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgINVMORE.Location = New System.Drawing.Point(6, 15)
        Me.dgINVMORE.Name = "dgINVMORE"
        Me.dgINVMORE.RowHeadersWidth = 30
        Me.dgINVMORE.RowTemplate.Height = 24
        Me.dgINVMORE.Size = New System.Drawing.Size(682, 132)
        Me.dgINVMORE.TabIndex = 85
        '
        'txtCustList
        '
        Me.txtCustList.Enabled = False
        Me.txtCustList.Location = New System.Drawing.Point(87, 43)
        Me.txtCustList.Name = "txtCustList"
        Me.txtCustList.Size = New System.Drawing.Size(580, 22)
        Me.txtCustList.TabIndex = 22
        Me.txtCustList.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 43)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 12)
        Me.Label10.TabIndex = 74
        Me.Label10.Text = "Customer :"
        Me.Label10.Visible = False
        '
        'txtInvNoList
        '
        Me.txtInvNoList.Location = New System.Drawing.Point(87, 15)
        Me.txtInvNoList.Name = "txtInvNoList"
        Me.txtInvNoList.Size = New System.Drawing.Size(580, 22)
        Me.txtInvNoList.TabIndex = 21
        Me.txtInvNoList.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 12)
        Me.Label7.TabIndex = 71
        Me.Label7.Text = "Invoice No :"
        Me.Label7.Visible = False
        '
        'cboCtnSiz
        '
        Me.cboCtnSiz.FormattingEnabled = True
        Me.cboCtnSiz.ItemHeight = 12
        Me.cboCtnSiz.Location = New System.Drawing.Point(131, 148)
        Me.cboCtnSiz.Name = "cboCtnSiz"
        Me.cboCtnSiz.Size = New System.Drawing.Size(122, 20)
        Me.cboCtnSiz.TabIndex = 26
        '
        'mskPckDat
        '
        Me.mskPckDat.CustomFormat = ""
        Me.mskPckDat.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.mskPckDat.Location = New System.Drawing.Point(399, 147)
        Me.mskPckDat.Name = "mskPckDat"
        Me.mskPckDat.Size = New System.Drawing.Size(91, 22)
        Me.mskPckDat.TabIndex = 97
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(14, 151)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(79, 12)
        Me.Label14.TabIndex = 94
        Me.Label14.Text = "Container Size :"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(301, 151)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(74, 12)
        Me.Label19.TabIndex = 96
        Me.Label19.Text = "杆螥/óら戳 :"
        '
        'gbDocTyp_C_Entry
        '
        Me.gbDocTyp_C_Entry.Controls.Add(Me.txtconsol)
        Me.gbDocTyp_C_Entry.Controls.Add(Me.Label22)
        Me.gbDocTyp_C_Entry.Controls.Add(Me.mskETDDat)
        Me.gbDocTyp_C_Entry.Controls.Add(Me.Label18)
        Me.gbDocTyp_C_Entry.Controls.Add(Me.Label6)
        Me.gbDocTyp_C_Entry.Controls.Add(Me.txtCtn)
        Me.gbDocTyp_C_Entry.Controls.Add(Me.Label5)
        Me.gbDocTyp_C_Entry.Location = New System.Drawing.Point(6, -2)
        Me.gbDocTyp_C_Entry.Name = "gbDocTyp_C_Entry"
        Me.gbDocTyp_C_Entry.Size = New System.Drawing.Size(703, 42)
        Me.gbDocTyp_C_Entry.TabIndex = 80
        Me.gbDocTyp_C_Entry.TabStop = False
        '
        'txtconsol
        '
        Me.txtconsol.Location = New System.Drawing.Point(105, 14)
        Me.txtconsol.Name = "txtconsol"
        Me.txtconsol.Size = New System.Drawing.Size(174, 22)
        Me.txtconsol.TabIndex = 77
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(8, 18)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(78, 12)
        Me.Label22.TabIndex = 78
        Me.Label22.Text = "Console No :    "
        '
        'mskETDDat
        '
        Me.mskETDDat.CustomFormat = ""
        Me.mskETDDat.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.mskETDDat.Location = New System.Drawing.Point(405, 14)
        Me.mskETDDat.Name = "mskETDDat"
        Me.mskETDDat.Size = New System.Drawing.Size(123, 22)
        Me.mskETDDat.TabIndex = 76
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(534, 18)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(79, 12)
        Me.Label18.TabIndex = 74
        Me.Label18.Text = "MM/DD/YYYY"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(321, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 12)
        Me.Label6.TabIndex = 71
        Me.Label6.Text = "ETD Date :"
        '
        'txtCtn
        '
        Me.txtCtn.Location = New System.Drawing.Point(105, 14)
        Me.txtCtn.Name = "txtCtn"
        Me.txtCtn.Size = New System.Drawing.Size(112, 22)
        Me.txtCtn.TabIndex = 19
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 12)
        Me.Label5.TabIndex = 69
        Me.Label5.Text = "Container No :"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.gbHeaderMain)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(944, 521)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "(2) Forwarder"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'gbHeaderMain
        '
        Me.gbHeaderMain.Controls.Add(Me.cbofcrno)
        Me.gbHeaderMain.Controls.Add(Me.cbofwdnam)
        Me.gbHeaderMain.Controls.Add(Me.chkDel)
        Me.gbHeaderMain.Controls.Add(Me.txtShpSeq)
        Me.gbHeaderMain.Controls.Add(Me.Label15)
        Me.gbHeaderMain.Controls.Add(Me.cmdBck)
        Me.gbHeaderMain.Controls.Add(Me.cmdNxt)
        Me.gbHeaderMain.Controls.Add(Me.dgSHCHGDTL_Distribute)
        Me.gbHeaderMain.Controls.Add(Me.rtxtRmk)
        Me.gbHeaderMain.Controls.Add(Me.Label17)
        Me.gbHeaderMain.Controls.Add(Me.cboBCurr)
        Me.gbHeaderMain.Controls.Add(Me.cboFCurr)
        Me.gbHeaderMain.Controls.Add(Me.Label16)
        Me.gbHeaderMain.Controls.Add(Me.Label13)
        Me.gbHeaderMain.Controls.Add(Me.mskExchRat)
        Me.gbHeaderMain.Controls.Add(Me.Label12)
        Me.gbHeaderMain.Controls.Add(Me.Label11)
        Me.gbHeaderMain.Controls.Add(Me.Label9)
        Me.gbHeaderMain.Controls.Add(Me.txtFwdInv)
        Me.gbHeaderMain.Controls.Add(Me.Label8)
        Me.gbHeaderMain.Location = New System.Drawing.Point(7, 3)
        Me.gbHeaderMain.Name = "gbHeaderMain"
        Me.gbHeaderMain.Size = New System.Drawing.Size(941, 511)
        Me.gbHeaderMain.TabIndex = 83
        Me.gbHeaderMain.TabStop = False
        '
        'cbofcrno
        '
        Me.cbofcrno.FormattingEnabled = True
        Me.cbofcrno.Location = New System.Drawing.Point(126, 98)
        Me.cbofcrno.Name = "cbofcrno"
        Me.cbofcrno.Size = New System.Drawing.Size(318, 20)
        Me.cbofcrno.TabIndex = 103
        '
        'cbofwdnam
        '
        Me.cbofwdnam.FormattingEnabled = True
        Me.cbofwdnam.Location = New System.Drawing.Point(126, 38)
        Me.cbofwdnam.Name = "cbofwdnam"
        Me.cbofwdnam.Size = New System.Drawing.Size(318, 20)
        Me.cbofwdnam.TabIndex = 101
        '
        'chkDel
        '
        Me.chkDel.AutoSize = True
        Me.chkDel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.chkDel.Location = New System.Drawing.Point(687, 469)
        Me.chkDel.Name = "chkDel"
        Me.chkDel.Size = New System.Drawing.Size(57, 17)
        Me.chkDel.TabIndex = 341
        Me.chkDel.Text = "Delete"
        Me.chkDel.UseVisualStyleBackColor = True
        '
        'txtShpSeq
        '
        Me.txtShpSeq.Enabled = False
        Me.txtShpSeq.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtShpSeq.Location = New System.Drawing.Point(87, 17)
        Me.txtShpSeq.MaxLength = 10
        Me.txtShpSeq.Name = "txtShpSeq"
        Me.txtShpSeq.Size = New System.Drawing.Size(30, 20)
        Me.txtShpSeq.TabIndex = 339
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.Red
        Me.Label15.Location = New System.Drawing.Point(22, 18)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(42, 12)
        Me.Label15.TabIndex = 340
        Me.Label15.Text = "Seq No."
        '
        'cmdBck
        '
        Me.cmdBck.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdBck.Location = New System.Drawing.Point(759, 463)
        Me.cmdBck.Name = "cmdBck"
        Me.cmdBck.Size = New System.Drawing.Size(48, 27)
        Me.cmdBck.TabIndex = 337
        Me.cmdBck.TabStop = False
        Me.cmdBck.Text = "&Back"
        '
        'cmdNxt
        '
        Me.cmdNxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdNxt.Location = New System.Drawing.Point(812, 463)
        Me.cmdNxt.Name = "cmdNxt"
        Me.cmdNxt.Size = New System.Drawing.Size(48, 27)
        Me.cmdNxt.TabIndex = 338
        Me.cmdNxt.TabStop = False
        Me.cmdNxt.Text = "&Next"
        '
        'dgSHCHGDTL_Distribute
        '
        Me.dgSHCHGDTL_Distribute.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSHCHGDTL_Distribute.Location = New System.Drawing.Point(2, 223)
        Me.dgSHCHGDTL_Distribute.Name = "dgSHCHGDTL_Distribute"
        Me.dgSHCHGDTL_Distribute.RowHeadersWidth = 30
        Me.dgSHCHGDTL_Distribute.RowTemplate.Height = 24
        Me.dgSHCHGDTL_Distribute.Size = New System.Drawing.Size(932, 234)
        Me.dgSHCHGDTL_Distribute.TabIndex = 98
        '
        'rtxtRmk
        '
        Me.rtxtRmk.ContextMenuStrip = Me.cms_CopyNPaste
        Me.rtxtRmk.Location = New System.Drawing.Point(478, 34)
        Me.rtxtRmk.Name = "rtxtRmk"
        Me.rtxtRmk.Size = New System.Drawing.Size(451, 145)
        Me.rtxtRmk.TabIndex = 27
        Me.rtxtRmk.Text = ""
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Cursor = System.Windows.Forms.Cursors.No
        Me.Label17.ForeColor = System.Drawing.Color.Green
        Me.Label17.Location = New System.Drawing.Point(20, 45)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(83, 12)
        Me.Label17.TabIndex = 92
        Me.Label17.Text = "Forwarder Name"
        '
        'cboBCurr
        '
        Me.cboBCurr.FormattingEnabled = True
        Me.cboBCurr.Location = New System.Drawing.Point(324, 194)
        Me.cboBCurr.Name = "cboBCurr"
        Me.cboBCurr.Size = New System.Drawing.Size(65, 20)
        Me.cboBCurr.TabIndex = 29
        '
        'cboFCurr
        '
        Me.cboFCurr.FormattingEnabled = True
        Me.cboFCurr.Location = New System.Drawing.Point(122, 194)
        Me.cboFCurr.Name = "cboFCurr"
        Me.cboFCurr.Size = New System.Drawing.Size(70, 20)
        Me.cboFCurr.TabIndex = 104
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(475, 15)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(46, 12)
        Me.Label16.TabIndex = 88
        Me.Label16.Text = "Remarks"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Green
        Me.Label13.Location = New System.Drawing.Point(444, 200)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 12)
        Me.Label13.TabIndex = 87
        Me.Label13.Text = "Exch Rate"
        '
        'mskExchRat
        '
        Me.mskExchRat.Location = New System.Drawing.Point(505, 193)
        Me.mskExchRat.Mask = "#.########"
        Me.mskExchRat.Name = "mskExchRat"
        Me.mskExchRat.Size = New System.Drawing.Size(99, 22)
        Me.mskExchRat.TabIndex = 30
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(255, 199)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(55, 12)
        Me.Label12.TabIndex = 85
        Me.Label12.Text = "Base Curr."
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Green
        Me.Label11.Location = New System.Drawing.Point(28, 196)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 12)
        Me.Label11.TabIndex = 84
        Me.Label11.Text = "Forwarder Curr."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(65, 101)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 12)
        Me.Label9.TabIndex = 82
        Me.Label9.Text = "FCR No"
        '
        'txtFwdInv
        '
        Me.txtFwdInv.Location = New System.Drawing.Point(126, 70)
        Me.txtFwdInv.Name = "txtFwdInv"
        Me.txtFwdInv.Size = New System.Drawing.Size(318, 22)
        Me.txtFwdInv.TabIndex = 102
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(20, 73)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 12)
        Me.Label8.TabIndex = 80
        Me.Label8.Text = "Forwarder Invoice"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label23)
        Me.TabPage2.Controls.Add(Me.mskExchRat_show)
        Me.TabPage2.Controls.Add(Me.Label21)
        Me.TabPage2.Controls.Add(Me.cbofwd)
        Me.TabPage2.Controls.Add(Me.lstVendor)
        Me.TabPage2.Controls.Add(Me.dgSHCHGDTL_CORE)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(944, 521)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "(3) Detail"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(247, 12)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(53, 12)
        Me.Label23.TabIndex = 97
        Me.Label23.Text = "Exch Rate"
        '
        'mskExchRat_show
        '
        Me.mskExchRat_show.Enabled = False
        Me.mskExchRat_show.Location = New System.Drawing.Point(312, 8)
        Me.mskExchRat_show.Mask = "#.########"
        Me.mskExchRat_show.Name = "mskExchRat_show"
        Me.mskExchRat_show.Size = New System.Drawing.Size(99, 22)
        Me.mskExchRat_show.TabIndex = 96
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(24, 12)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(53, 12)
        Me.Label21.TabIndex = 95
        Me.Label21.Text = "Forwarder"
        '
        'cbofwd
        '
        Me.cbofwd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbofwd.FormattingEnabled = True
        Me.cbofwd.ItemHeight = 12
        Me.cbofwd.Location = New System.Drawing.Point(85, 8)
        Me.cbofwd.Name = "cbofwd"
        Me.cbofwd.Size = New System.Drawing.Size(122, 20)
        Me.cbofwd.TabIndex = 27
        '
        'lstVendor
        '
        Me.lstVendor.FormattingEnabled = True
        Me.lstVendor.ItemHeight = 12
        Me.lstVendor.Location = New System.Drawing.Point(169, 177)
        Me.lstVendor.Name = "lstVendor"
        Me.lstVendor.Size = New System.Drawing.Size(161, 124)
        Me.lstVendor.TabIndex = 17
        Me.lstVendor.Visible = False
        '
        'dgSHCHGDTL_CORE
        '
        Me.dgSHCHGDTL_CORE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSHCHGDTL_CORE.Location = New System.Drawing.Point(6, 37)
        Me.dgSHCHGDTL_CORE.Name = "dgSHCHGDTL_CORE"
        Me.dgSHCHGDTL_CORE.RowHeadersWidth = 30
        Me.dgSHCHGDTL_CORE.RowTemplate.Height = 24
        Me.dgSHCHGDTL_CORE.Size = New System.Drawing.Size(935, 474)
        Me.dgSHCHGDTL_CORE.TabIndex = 16
        '
        'SHM00007
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 15)
        Me.ClientSize = New System.Drawing.Size(954, 635)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.menuStrip)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.btcSHM00007)
        Me.Controls.Add(Me.pDocTyp)
        Me.Controls.Add(Me.txtUpddat)
        Me.Controls.Add(Me.txtCredat)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtdocno)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.menuStrip
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(960, 660)
        Me.MinimumSize = New System.Drawing.Size(960, 660)
        Me.Name = "SHM00007"
        Me.Text = "SHM00007 -Shipping Charges Maintenance (SHM07)"
        Me.pDocTyp.ResumeLayout(False)
        Me.pDocTyp.PerformLayout()
        Me.cms_CopyNPaste.ResumeLayout(False)
        Me.menuStrip.ResumeLayout(False)
        Me.menuStrip.PerformLayout()
        Me.StatusBar.ResumeLayout(False)
        Me.StatusBar.PerformLayout()
        Me.btcSHM00007.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgSHCHGFWD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDocTyp_D_Entry.ResumeLayout(False)
        Me.gbDocTyp_D_Entry.PerformLayout()
        CType(Me.dgINVMORE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDocTyp_C_Entry.ResumeLayout(False)
        Me.gbDocTyp_C_Entry.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.gbHeaderMain.ResumeLayout(False)
        Me.gbHeaderMain.PerformLayout()
        CType(Me.dgSHCHGDTL_Distribute, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dgSHCHGDTL_CORE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Dim dsNewRow As DataRow

    Dim mode As String

    Dim Recordstatus As Boolean
    Dim sFilter As String
    Dim Add_flag_A(100) As Boolean
    Dim upd_flag_A(100) As Boolean
    Dim flag_sub_value_change(100) As Boolean

    Public FrmSHR00010 As SHR00010

    Public rs_SYMSHC_ALL As New DataSet
    Public rs_SYMSHC_D As New DataSet
    Public rs_VNBASINF As New DataSet

    Public rs_SHCHGDTL_Distribute As New DataSet
    Public rs_SHCHGDTL_CORE As New DataSet

    Public rs_SHIPGDTL_CTNETD As New DataSet
    Public rs_SHIPGDTL_CTNETD_add As New DataSet
    Public rs_SHIPGDTL_co As New DataSet
    Public rs_SHIPGDTL_Console As New DataSet


    Public rs_SHCHGHDR As New DataSet
    Public rs_SHCHGDTL As New DataSet
    Public rs_SHCHGDTL_org As New DataSet
    Public rs_SHCHGDTL_compare As New DataSet

    Public rs_SHCHGFWD As New DataSet

    Public rs_DOC_GEN As New DataSet

    Public rs_INVMORE As New DataSet

    Public rs_tmp As New DataSet
    Public rs_SHIPGDTL_CTNETD_date As New DataSet

    Dim PreviousTab As Integer = 0
    Dim ReadingIndex As Integer = 0
    Dim last_ReadingIndex As Integer

    Dim Add_flag As Boolean
    Dim Upd_flag As Boolean
    Dim Insert_flag As Boolean

    Dim calculate_dgSHCHGDTL_CORE_flag As Boolean

    Dim changeManualCBM As Boolean
    Dim flag_cbofwd_KeyPress As Boolean
    Dim FLAG_cbofcrno_GotFocus As Boolean
    Dim FLAG_txtFwdInv_GotFocus As Boolean
    Dim flag_cmdInsRow_Click As Boolean
    Dim flag_cmdFind_Click As Boolean
    Dim sfcrNo As String()
    Dim flag_more_than_one_fcr As Boolean
    Dim flag_distribute_changed As Boolean
    Dim counter_format_dgSHCHGDTL_CORE As Integer




    Dim mmdPrint_Right As Boolean = False



    Private Sub SHM00007_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Call AccessRight("SHR00010")
        mmdPrint_Right = Enq_right

        Call formInit("INIT")


        ReDim Preserve Add_flag_A(100)
        ReDim Preserve upd_flag_A(100)
        Call FillComboForwarder()

        gspStr = "sp_select_SYMSHC '','ALL'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYMSHC_ALL, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SHM00007 #001 sp_select_SYMSHC : " & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_select_SYMSHC '','D'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYMSHC_D, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SHM00007 #002 sp_select_SYMSHC : " & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_list_VNBASINF_vensna ''"
        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SHM00007 #003 sp_list_VNBASINF_vensna : " & rtnStr)
            Exit Sub
        End If


        Call format_ComboBox()
        Call format_lstVendor()


        mode = "INIT"
        Call formInit(mode)

        Call format_dgSHCHGDTL_Distribute("NONE")
        Call format_dgSHCHGDTL_CORE()

        Call format_dgINVMORE()


        ' dgSHCHGDTL.DataSource = rs_SYMSHC.Tables("RESULT").DefaultView

        'rs_SYMSHC.Tables("RESULT").Columns(0).ReadOnly = False

        Call Formstartup(Me.Name)


        'for testing
        'Me.txtCtn.Text = "MOFU0718132"
        'Me.mskETDDat.Text = "07/14/2009"

    End Sub
    Private Sub mmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdExit.Click
        Me.Close()
    End Sub



    Private Sub format_ComboBox()
        cboFCurr.Text = ""
        cboFCurr.Items.Add("HKD")
        cboFCurr.Items.Add("CNY")
        cboFCurr.Items.Add("USD")

        cboBCurr.Text = ""
        cboBCurr.Items.Add("HKD")
        cboBCurr.Items.Add("CNY")
        cboBCurr.Items.Add("USD")
        cboBCurr.Text = "HKD"
        cboBCurr.Enabled = False

        cboCtnSiz.Text = ""
        cboCtnSiz.Items.Add("20'")
        cboCtnSiz.Items.Add("40' (8.5')")
        cboCtnSiz.Items.Add("40' (HQ)")
        cboCtnSiz.Items.Add("40' (HR)")
        cboCtnSiz.Items.Add("45'")


    End Sub

    Private Sub format_lstVendor()
        Dim i As Integer
        For i = 0 To rs_VNBASINF.Tables("RESULT").Rows.Count - 1
            If rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_vensts") = "A" Then
                lstVendor.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_vensna"))
            End If
        Next i
    End Sub
    Private Sub format_cbofwd()
        Dim i As Integer
        cbofwd.Items.Clear()

        If Not rs_SHCHGFWD.Tables("RESULT") Is Nothing Then
            For i = 0 To rs_SHCHGFWD.Tables("RESULT").Rows.Count - 1
                cbofwd.Items.Add(rs_SHCHGFWD.Tables("RESULT").Rows(i).Item("scf_fwdnam"))
            Next i

        End If
    End Sub

    Private Sub format_dgINVMORE()
        If rs_INVMORE.Tables.Count = 0 Then
            rs_INVMORE.Tables.Add("RESULT")
            'column 0 Invoice No
            rs_INVMORE.Tables("RESULT").Columns.Add("INVNO")
            rs_INVMORE.Tables("RESULT").Columns.Add("CUSNO")
            rs_INVMORE.Tables("RESULT").Columns.Add("CUSNAME")
        End If

        dgINVMORE.DataSource = rs_INVMORE.Tables("RESULT").DefaultView


        dgINVMORE.Columns(0).HeaderText = "Invoice No"
        dgINVMORE.Columns(0).Width = 100
        dgINVMORE.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable

        dgINVMORE.Columns(1).HeaderText = "Customer No"
        dgINVMORE.Columns(1).Width = 100
        dgINVMORE.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable

        dgINVMORE.Columns(2).HeaderText = "Cust. Name"
        dgINVMORE.Columns(2).Width = 100
        dgINVMORE.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable


    End Sub

    Private Sub display_dgINVMORE()
        Dim sInvNo As String()
        Dim sCusNo As String()
        Dim sCusName As String()

        sInvNo = Split(Me.txtInvNoList.Text, ",")
        sCusNo = Split(Me.txtCusNoList.Text, ",")
        sCusName = Split(Me.txtCustList.Text, ",")

        If sInvNo.Length <> sCusNo.Length Or sCusNo.Length <> sCusName.Length Then
            MsgBox("Error on loading SHM00007 #018 : Invalid Invoice vs Customer List")
            Exit Sub
        End If

        Dim i As Integer
        If rs_INVMORE.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If

        If rs_INVMORE.Tables("RESULT").Rows.Count > 0 Then
            rs_INVMORE.Tables("RESULT").Rows.Clear()
        End If

        For i = 0 To sInvNo.Length - 1
            dsNewRow = rs_INVMORE.Tables("RESULT").NewRow()
            dsNewRow.Item("INVNO") = sInvNo(i)
            dsNewRow.Item("CUSNO") = sCusNo(i)
            dsNewRow.Item("CUSNAME") = sCusName(i)

            rs_INVMORE.Tables("RESULT").Rows.Add(dsNewRow)
        Next i

    End Sub

    Private Sub format_dgSHCHGDTL_Distribute(ByVal m As String)
        Dim i As Integer

        If rs_SHCHGDTL_Distribute.Tables.Count = 0 Then
            rs_SHCHGDTL_Distribute.Tables.Add("RESULT")

            'column Vendor
            rs_SHCHGDTL_Distribute.Tables("RESULT").Columns.Add("VENDOR")

            For i = 0 To rs_SYMSHC_D.Tables("RESULT").Rows.Count - 1
                rs_SHCHGDTL_Distribute.Tables("RESULT").Columns.Add(rs_SYMSHC_D.Tables("RESULT").Rows(i).Item("ysc_chgcde"))
            Next i

            ' last column 'Total'
            rs_SHCHGDTL_Distribute.Tables("RESULT").Columns.Add("TOTAL")
            rs_SHCHGDTL_Distribute.Tables("RESULT").Columns.Add("fn")
        End If


        dgSHCHGDTL_Distribute.DataSource = rs_SHCHGDTL_Distribute.Tables("RESULT").DefaultView


        For i = 0 To dgSHCHGDTL_Distribute.Columns.Count - 1
            Select Case i
                Case 0
                    dgSHCHGDTL_Distribute.Columns(i).HeaderText = ""
                    dgSHCHGDTL_Distribute.Columns(i).Width = 92
                    dgSHCHGDTL_Distribute.Columns(i).CellTemplate.Style.BackColor = SystemColors.Control
                Case dgSHCHGDTL_Distribute.Columns.Count - 2
                    dgSHCHGDTL_Distribute.Columns(i).HeaderText = "璸"
                    dgSHCHGDTL_Distribute.Columns(i).Width = 65
                    dgSHCHGDTL_Distribute.Columns(i).CellTemplate.Style.BackColor = SystemColors.Control
                Case dgSHCHGDTL_Distribute.Columns.Count - 1
                    dgSHCHGDTL_Distribute.Columns(i).HeaderText = ""
                    dgSHCHGDTL_Distribute.Columns(i).Width = 0
                    dgSHCHGDTL_Distribute.Columns(i).Visible = False
                Case Else
                    dgSHCHGDTL_Distribute.Columns(i).HeaderText = rs_SYMSHC_D.Tables("RESULT").Rows(i - 1).Item("ysc_chgdsc")

                    If Len(rs_SYMSHC_D.Tables("RESULT").Rows(i - 1).Item("ysc_chgdsc")) > 7 Then
                        dgSHCHGDTL_Distribute.Columns(i).Width = 90
                    Else
                        dgSHCHGDTL_Distribute.Columns(i).Width = 70
                    End If
            End Select

            dgSHCHGDTL_Distribute.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next i

        If rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Count > 0 Then
            rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Clear()
        End If

        ' row 0 
        If m = "CNY" Then
            dsNewRow = rs_SHCHGDTL_Distribute.Tables("RESULT").NewRow()
            dsNewRow.Item("VENDOR") = "舥だ计(CNY)"
            rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Add(dsNewRow)
        End If
        If m = "USD" Then
            dsNewRow = rs_SHCHGDTL_Distribute.Tables("RESULT").NewRow()
            dsNewRow.Item("VENDOR") = "舥だ计(USD)"
            rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Add(dsNewRow)
        End If

        ' row 1
        '        If m = "ALL" Or m = "HKD" Then
        dsNewRow = rs_SHCHGDTL_Distribute.Tables("RESULT").NewRow()
        dsNewRow.Item("VENDOR") = "舥だ计(HKD)"
        rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Add(dsNewRow)
        'End If


        dgSHCHGDTL_Distribute.AllowUserToAddRows = False
        dgSHCHGDTL_Distribute.Columns(0).ReadOnly = True



    End Sub


    Private Sub add_rows_dgSHCHGDTL_Distribute(ByVal m As String)
        Dim i As Integer

        dgSHCHGDTL_Distribute.DataSource = rs_SHCHGDTL_Distribute.Tables("RESULT").DefaultView

        ' row 0 
        If m = "ALL" Or m <> "HKD" Then
            dsNewRow = rs_SHCHGDTL_Distribute.Tables("RESULT").NewRow()
            dsNewRow.Item("VENDOR") = "舥だ计(CNY)"
            rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Add(dsNewRow)
        End If

        ' row 1
        If m = "ALL" Or m = "HKD" Then
            dsNewRow = rs_SHCHGDTL_Distribute.Tables("RESULT").NewRow()
            dsNewRow.Item("VENDOR") = "舥だ计(HKD)"
            rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Add(dsNewRow)
        End If


        dgSHCHGDTL_Distribute.AllowUserToAddRows = False
        dgSHCHGDTL_Distribute.Columns(0).ReadOnly = True
    End Sub

    Private Sub format_dgSHCHGDTL_CORE()
        counter_format_dgSHCHGDTL_CORE = counter_format_dgSHCHGDTL_CORE + 1


        Dim i As Integer

        If rs_SHCHGDTL_CORE.Tables.Count = 0 Then
            rs_SHCHGDTL_CORE.Tables.Add("RESULT")

            'column 0 Vendor Name
            rs_SHCHGDTL_CORE.Tables("RESULT").Columns.Add("VENDOR")

            'column 1 PV CBM By system
            rs_SHCHGDTL_CORE.Tables("RESULT").Columns.Add("SYSCBM")
            'column 2 PV CBM By manual
            rs_SHCHGDTL_CORE.Tables("RESULT").Columns.Add("MANCBM")

            For i = 0 To rs_SYMSHC_ALL.Tables("RESULT").Rows.Count - 1
                rs_SHCHGDTL_CORE.Tables("RESULT").Columns.Add(rs_SYMSHC_ALL.Tables("RESULT").Rows(i).Item("ysc_chgcde"))
            Next i

            ' last column 'Total'
            rs_SHCHGDTL_CORE.Tables("RESULT").Columns.Add("TOTAL")
            rs_SHCHGDTL_CORE.Tables("RESULT").Columns.Add("VENCDE")
            rs_SHCHGDTL_CORE.Tables("RESULT").Columns.Add("fn")
        End If

        dgSHCHGDTL_CORE.DataSource = rs_SHCHGDTL_CORE.Tables("RESULT").DefaultView


        'For i = 0 To dgSHCHGDTL_CORE.Columns.Count - 5
        For i = 0 To dgSHCHGDTL_CORE.Columns.Count - 1
            '2015temp

            Select Case i
                Case 0
                    dgSHCHGDTL_CORE.Columns(i).HeaderText = ""
                    dgSHCHGDTL_CORE.Columns(i).Width = 100
                    dgSHCHGDTL_CORE.Columns(i).ReadOnly = True
                    dgSHCHGDTL_CORE.Columns(i).CellTemplate.Style.BackColor = SystemColors.Control

                Case 1
                    dgSHCHGDTL_CORE.Columns(i).HeaderText = "CBM from SC"
                    dgSHCHGDTL_CORE.Columns(i).Width = 65
                    dgSHCHGDTL_CORE.Columns(i).CellTemplate.Style.BackColor = Color.Green
                    dgSHCHGDTL_CORE.Columns(i).ReadOnly = True
                Case 2
                    dgSHCHGDTL_CORE.Columns(i).HeaderText = "Actual CBM"
                    dgSHCHGDTL_CORE.Columns(i).Width = 65
                    dgSHCHGDTL_CORE.Columns(i).ReadOnly = True

                    'If rbDocTyp_C.Checked = True Then
                    '    dgSHCHGDTL_CORE.Columns(i).ReadOnly = True
                    'Else
                    '    dgSHCHGDTL_CORE.Columns(i).ReadOnly = False
                    'End If

                    dgSHCHGDTL_CORE.Columns(i).CellTemplate.Style.BackColor = Color.Orange

                Case dgSHCHGDTL_CORE.Columns.Count - 3
                    dgSHCHGDTL_CORE.Columns(i).CellTemplate.Style.BackColor = SystemColors.Control
                Case dgSHCHGDTL_CORE.Columns.Count - 2
                    dgSHCHGDTL_CORE.Columns(i).CellTemplate.Style.BackColor = SystemColors.Control
                Case dgSHCHGDTL_CORE.Columns.Count - 1
                    dgSHCHGDTL_CORE.Columns(i).HeaderText = "璸"
                    dgSHCHGDTL_CORE.Columns(i).Width = 80
                    dgSHCHGDTL_CORE.Columns(i).ReadOnly = True
                    dgSHCHGDTL_CORE.Columns(i).CellTemplate.Style.BackColor = SystemColors.Control
                    'Case dgSHCHGDTL_CORE.Columns.Count
                    '    dgSHCHGDTL_CORE.Columns(i).HeaderText = ""
                    '    dgSHCHGDTL_CORE.Columns(i).Width = 0
                    '    dgSHCHGDTL_CORE.Columns(i).ReadOnly = True
                    '    dgSHCHGDTL_CORE.Columns(i).CellTemplate.Style.BackColor = SystemColors.Control
                Case Else

                    dgSHCHGDTL_CORE.Columns(i).HeaderText = rs_SYMSHC_ALL.Tables("RESULT").Rows(i - 3).Item("ysc_chgdsc")

                    If Len(rs_SYMSHC_ALL.Tables("RESULT").Rows(i - 3).Item("ysc_chgdsc")) > 5 Then
                        dgSHCHGDTL_CORE.Columns(i).Width = 66
                    Else
                        dgSHCHGDTL_CORE.Columns(i).Width = 50
                    End If
            End Select

            dgSHCHGDTL_CORE.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next i

        dgSHCHGDTL_CORE.AllowUserToAddRows = False

    End Sub



    Private Sub formInit(ByVal m As String)
        If m = "INIT" Then
            txtShpSeq.Text = ""
            cbofwdnam.Enabled = False
            counter_format_dgSHCHGDTL_CORE = 0

            flag_distribute_changed = False
            cbofwd.Text = ""
            cbofwdnam.Text = ""

            flag_more_than_one_fcr = False

            dgINVMORE.DataSource = Nothing
            dgINVMORE.Refresh()
            txtconsol.Text = ""
            chkDel.Checked = False

            FLAG_txtFwdInv_GotFocus = False
            FLAG_cbofcrno_GotFocus = False

            ReadingIndex = 0
            'last_ReadingIndex = 0



            Me.mmdAdd.Enabled = True
            Me.mmdSave.Enabled = False
            Me.mmdDelete.Enabled = False
            Me.mmdCopy.Enabled = False
            Me.mmdFind.Enabled = True
            Me.mmdClear.Enabled = False
            Me.mmdSearch.Enabled = False
            Me.mmdInsRow.Enabled = False
            Me.mmdDelRow.Enabled = False


            Me.mmdExit.Enabled = True

            Me.cmdRefresh.Enabled = False
            Me.cmdInvMore.Enabled = False

            Me.txtdocno.Enabled = True
            Me.pDocTyp.Enabled = False

            mmdPrint.Enabled = False
            mmdAttach.Enabled = False
            mmdFunction.Enabled = False
            mmdLink.Enabled = False


            '            Me.txtdocno.Text = ""
            Me.txtCtn.Text = ""
            Me.mskETDDat.Text = ""
            Me.txtCredat.Text = ""
            Me.txtUpddat.Text = ""
            Me.rbDocTyp_C.Checked = False
            Me.rbDocTyp_D.Checked = False
            Me.txtInvNoList.Text = ""
            Me.txtCusNoList.Text = ""
            Me.txtCustList.Text = ""

            Me.cbofwdnam.Text = ""
            Me.cbofcrno.Text = ""
            Me.cbofcrno.Text = ""
            Me.cboCtnSiz.Text = ""
            Me.mskPckDat.Text = ""
            Me.rtxtRmk.Text = ""
            Me.cboFCurr.Text = ""
            Me.cboBCurr.Text = "HKD"
            Me.mskExchRat.Text = ""

            Add_flag_A(ReadingIndex) = False
            upd_flag_A(ReadingIndex) = False
            Insert_flag = False
            Add_flag = False

            changeManualCBM = False

            Me.btcSHM00007.SelectedIndex = 0
            Me.btcSHM00007.Enabled = False

            If rs_SHCHGDTL_CORE.Tables.Count > 0 Then
                If rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count > 0 Then
                    rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Clear()
                End If
            End If
            dgSHCHGDTL_CORE.DataSource = Nothing
            dgSHCHGDTL_CORE.Refresh()



            If rs_SHCHGDTL_Distribute.Tables.Count > 0 Then
                If rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Count > 0 Then
                    rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Clear()
                End If
            End If
            dgSHCHGDTL_Distribute.DataSource = Nothing
            dgSHCHGDTL_Distribute.Refresh()



            If rs_SHCHGHDR.Tables.Count > 0 Then
                If rs_SHCHGHDR.Tables("RESULT").Rows.Count > 0 Then
                    rs_SHCHGHDR.Tables("RESULT").Rows.Clear()
                End If
            End If

            If rs_SHCHGFWD.Tables.Count > 0 Then
                If rs_SHCHGFWD.Tables("RESULT").Rows.Count > 0 Then
                    rs_SHCHGFWD.Tables("RESULT").Rows.Clear()
                End If
            End If


            If rs_SHCHGDTL.Tables.Count > 0 Then
                If rs_SHCHGDTL.Tables("RESULT").Rows.Count > 0 Then
                    rs_SHCHGDTL.Tables("RESULT").Rows.Clear()
                End If
            End If
            If rs_SHCHGDTL_org.Tables.Count > 0 Then
                If rs_SHCHGDTL_org.Tables("RESULT").Rows.Count > 0 Then
                    rs_SHCHGDTL_org.Tables("RESULT").Rows.Clear()
                End If
            End If


            If rs_SHIPGDTL_CTNETD.Tables.Count > 0 Then
                If rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows.Count > 0 Then
                    rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows.Clear()
                End If
            End If
            If rs_SHIPGDTL_CTNETD_add.Tables.Count > 0 Then
                If rs_SHIPGDTL_CTNETD_add.Tables("RESULT").Rows.Count > 0 Then
                    rs_SHIPGDTL_CTNETD_add.Tables("RESULT").Rows.Clear()
                End If
            End If



            If rs_INVMORE.Tables.Count > 0 Then
                If rs_INVMORE.Tables("RESULT").Rows.Count > 0 Then
                    rs_INVMORE.Tables("RESULT").Rows.Clear()
                End If
            End If
            If rs_SHIPGDTL_CTNETD_date.Tables.Count > 0 Then
                If rs_SHIPGDTL_CTNETD_date.Tables("RESULT").Rows.Count > 0 Then
                    rs_SHIPGDTL_CTNETD_date.Tables("RESULT").Rows.Clear()
                End If
            End If
            If rs_SHIPGDTL_co.Tables.Count > 0 Then
                If rs_SHIPGDTL_co.Tables("RESULT").Rows.Count > 0 Then
                    rs_SHIPGDTL_co.Tables("RESULT").Rows.Clear()
                End If
            End If
            If rs_SHIPGDTL_Console.Tables.Count > 0 Then
                If rs_SHIPGDTL_Console.Tables("RESULT").Rows.Count > 0 Then
                    rs_SHIPGDTL_Console.Tables("RESULT").Rows.Clear()
                End If
            End If

            ''''''''''''''


            For i As Integer = 0 To UBound(Add_flag_A)
                Add_flag_A(i) = False
            Next
            For i As Integer = 0 To UBound(upd_flag_A)
                upd_flag_A(i) = False
            Next
            For i As Integer = 0 To UBound(flag_sub_value_change)
                flag_sub_value_change(i) = False
            Next



            'rs_SHCHGDTL_Distribute = Nothing
            'rs_SHCHGDTL_CORE = Nothing
            'rs_SHIPGDTL_CTNETD = Nothing
            'rs_SHIPGDTL_CTNETD_add = Nothing
            '            rs_SHIPGDTL_co = Nothing '
            '           rs_SHIPGDTL_Console = Nothing '

            'rs_SHCHGHDR = Nothing
            'rs_SHCHGDTL = Nothing
            'rs_SHCHGDTL_org = Nothing
            'rs_SHCHGDTL_compare = Nothing

            '            rs_SHCHGFWD = Nothing
            '           rs_DOC_GEN = Nothing

            '          rs_INVMORE = Nothing '
            '         rs_SHIPGDTL_CTNETD_date = Nothing '


            PreviousTab = 0
            ReadingIndex = 0
            last_ReadingIndex = 0

            Add_flag = False
            Upd_flag = False
            Insert_flag = False

            calculate_dgSHCHGDTL_CORE_flag = False

            changeManualCBM = False
            flag_cbofwd_KeyPress = False
            FLAG_cbofcrno_GotFocus = False
            FLAG_txtFwdInv_GotFocus = False
            flag_cmdInsRow_Click = False
            flag_cmdFind_Click = False
            flag_more_than_one_fcr = False
            ''''''''''''''

            Call SetStatusBar(mode)
        ElseIf m = "ADD" Then


            Me.mmdAdd.Enabled = False
            Me.mmdSave.Enabled = True
            Me.mmdDelete.Enabled = False
            Me.mmdCopy.Enabled = False
            Me.mmdFind.Enabled = False
            Me.mmdClear.Enabled = True
            Me.mmdSearch.Enabled = False
            Me.mmdInsRow.Enabled = True
            Me.mmdDelRow.Enabled = True


            Me.mmdExit.Enabled = True

            Me.cmdRefresh.Enabled = False
            Me.cmdInvMore.Enabled = True

            Me.txtdocno.Text = ""
            Me.txtdocno.Enabled = False
            Me.pDocTyp.Enabled = True


            If rs_SHCHGHDR.Tables.Count > 0 Then
                If rs_SHCHGHDR.Tables("RESULT").Rows.Count > 0 Then
                    rs_SHCHGHDR.Tables("RESULT").Rows.Clear()

                    rs_SHCHGHDR.Tables("RESULT").Rows.Add()
                End If
            End If
            Call SetStatusBar(mode)

        ElseIf m = "UPD" Then


            Me.mmdAdd.Enabled = False
            Me.mmdSave.Enabled = True
            Me.mmdDelete.Enabled = True
            Me.mmdCopy.Enabled = False
            Me.mmdFind.Enabled = False
            Me.mmdClear.Enabled = True
            Me.mmdSearch.Enabled = False
            Me.mmdInsRow.Enabled = True
            Me.mmdDelRow.Enabled = True

            Me.mmdExit.Enabled = True
            Me.mmdPrint.Enabled = mmdPrint_Right

            Me.cmdRefresh.Enabled = True
            Me.cmdInvMore.Enabled = True

            Me.txtdocno.Enabled = False
            Me.pDocTyp.Enabled = False
            Me.txtCredat.Enabled = False
            Me.txtUpddat.Enabled = False

            Me.btcSHM00007.Enabled = True
            Me.btcSHM00007.TabPages(0).Enabled = True
            'Me.gbDocTyp_C_Entry.Enabled = False
            'Me.gbDocTyp_D_Entry.Enabled = False
            '   Me.cboFCurr.Enabled = True
            'Me.cboFCurr.Enabled = false

            Me.btcSHM00007.TabPages(1).Enabled = True
            Me.btcSHM00007.TabPages(2).Enabled = True
            dgSHCHGDTL_Distribute.Enabled = True
            Upd_flag = True
            Call SetStatusBar(mode)
        ElseIf m = "READ" Then


            Me.mmdAdd.Enabled = False
            Me.mmdSave.Enabled = False
            Me.mmdDelete.Enabled = False
            Me.mmdCopy.Enabled = False
            Me.mmdFind.Enabled = False
            Me.mmdClear.Enabled = True
            Me.mmdSearch.Enabled = False
            Me.mmdInsRow.Enabled = False
            Me.mmdDelRow.Enabled = False


            Me.mmdExit.Enabled = True
            Me.mmdPrint.Enabled = mmdPrint_Right

            Me.cmdRefresh.Enabled = False
            Me.cmdInvMore.Enabled = False

            Me.txtdocno.Enabled = False
            Me.pDocTyp.Enabled = False
            Me.txtCredat.Enabled = False
            Me.txtUpddat.Enabled = False

            Me.btcSHM00007.Enabled = False
            Me.btcSHM00007.TabPages(0).Enabled = False
            'Me.gbDocTyp_C_Entry.Enabled = False
            'Me.gbDocTyp_D_Entry.Enabled = False
            Me.cboFCurr.Enabled = False

            Me.btcSHM00007.TabPages(1).Enabled = False
            Call SetStatusBar(mode)

        End If


    End Sub


    Private Sub mmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdAdd.Click
        Add_flag = True

        gspStr = "sp_select_SHCHGHDR '','" & "" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SHCHGHDR, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SHM00007 #008 sp_select_SHCHGHDR : " & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_select_SHCHGFWD '','" & "Awef78fq3gf" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SHCHGFWD, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SHM00007 #008 sp_select_SHCHGFWD : " & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_select_SHCHGDTL '','" & "" & "','ALL',''"
        rtnLong = execute_SQLStatement(gspStr, rs_SHCHGDTL, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SHM00007 #009 sp_select_SHCHGDTL : " & rtnStr)
            Exit Sub
        End If

        Call formInit("ADD")



    End Sub



    Private Sub rbDocTyp_C_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDocTyp_C.CheckedChanged

        If Add_flag = True Then
            Me.pDocTyp.Enabled = False



            gbDocTyp_D_Entry.Enabled = True
            'gbHeaderMain_Enter.Enabled = True

            Me.btcSHM00007.TabPages(0).Enabled = True
            btcSHM00007.Enabled = True

            Me.btcSHM00007.Enabled = True
            'Me.gbDocTyp_C_Entry.Enabled = True
            'Me.gbDocTyp_D_Entry.Enabled = False
            Me.gbHeaderMain.Enabled = False
            Me.dgSHCHGDTL_Distribute.Enabled = False
            Me.btcSHM00007.TabPages(1).Enabled = False
            Me.btcSHM00007.TabPages(2).Enabled = False

            Label5.Enabled = True
            txtCtn.Enabled = True
            Label6.Enabled = True
            mskETDDat.Enabled = True
            Label18.Enabled = True
            Label14.Enabled = False
            cboCtnSiz.Enabled = False
            Label19.Enabled = False
            'mskPckDat.Enabled = False
            Label5.Visible = True
            txtCtn.Visible = True
            Label6.Visible = True
            mskETDDat.Visible = True
            Label18.Visible = True
            Label14.Visible = True
            cboCtnSiz.Visible = True
            Label19.Visible = True
            mskPckDat.Visible = True

            Label22.Enabled = False
            txtconsol.Enabled = False
            Label22.Visible = False
            txtconsol.Visible = False

            Me.txtCtn.Focus()



        End If
    End Sub

    Private Sub rbDocTyp_D_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDocTyp_D.CheckedChanged
        If Add_flag = True Then
            '''temp
            Me.pDocTyp.Enabled = False
            Me.btcSHM00007.Enabled = True
            ' 'Me.gbDocTyp_C_Entry.Enabled = False
            '            'Me.gbDocTyp_D_Entry.Enabled = True
            Me.gbHeaderMain.Enabled = False
            Me.btcSHM00007.TabPages(1).Enabled = False
            Me.dgSHCHGDTL_Distribute.Enabled = False



            Label5.Enabled = False
            txtCtn.Enabled = False
            Label6.Enabled = False
            mskETDDat.Enabled = False
            Label18.Enabled = False
            Label14.Enabled = False
            cboCtnSiz.Enabled = False
            Label19.Enabled = False
            'mskPckDat.Enabled = False
            Label5.Visible = False
            txtCtn.Visible = False
            Label6.Visible = False
            mskETDDat.Visible = False
            Label18.Visible = False
            Label14.Visible = False
            cboCtnSiz.Visible = False
            Label19.Visible = False
            mskPckDat.Visible = False

            Label22.Enabled = True
            txtconsol.Enabled = True
            Label22.Visible = True
            txtconsol.Visible = True


        End If
    End Sub

    Private Sub mmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdClear.Click

        Dim YesNoCancel As Integer

        YesNoCancel = MsgBox("Do you want to save before clear the screen?", MsgBoxStyle.YesNoCancel)
        If YesNoCancel = vbYes Then
            Call cmdSaveClick()
            Call formInit("INIT")
        ElseIf YesNoCancel = vbNo Then
            Call formInit("INIT")
            Call formInit("INIT")
        ElseIf YesNoCancel = vbCancel Then
            Cursor = Cursors.Default
            Exit Sub
        End If

        'If Add_flag = True Then
        '    MsgBox("Record not yet saved!", MsgBoxStyle.YesNoCancel)
        '    Call formInit("INIT")
        'Else
        '    Call formInit("INIT")
        'End If

    End Sub


    Private Sub cboFCurr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFCurr.KeyPress
        If cboFCurr.Text.Trim = "" Then
            Exit Sub
        End If

        If e.KeyChar.Equals(Chr(13)) Then
            cboFCurr.Enabled = False
            If cboFCurr.Text = "CNY" Then
                Me.mskExchRat.Text = ""
                Me.mskExchRat.Enabled = True
                Me.mskExchRat.Focus()
            ElseIf cboFCurr.Text = "USD" Then
                Me.mskExchRat.Text = ""
                Me.mskExchRat.Enabled = True
                Me.mskExchRat.Focus()
            ElseIf (cboFCurr.Text.Trim <> "CNY" _
                    And cboFCurr.Text.Trim <> "USD" _
                    And cboFCurr.Text.Trim <> "HKD") Then
                cboFCurr.Text = ""
                cboFCurr.Enabled = True
            Else                                                                     'HKD
                Call format_dgSHCHGDTL_Distribute("HKD")
                Me.mskExchRat.Text = 1
                Me.mskExchRat.Enabled = False

                dgSHCHGDTL_Distribute.ReadOnly = False
                mskExchRat.Enabled = False

            End If


            If check_exchrate() = True Then
                Call display_dgSHCHGDTL_Distribute(cbofwdnam.Text.Trim)
                ' ''calculate_dgSHCHGDTL_CORE_flag = True
                ' ''Call calculate_dgSHCHGDTL_CORE("MANCBM")
                ' ''changeManualCBM = True
                ' ''Call calculate_dgSHCHGDTL_CORE("NONE")
                ' ''update_dtl(cbofwd.Text.Trim())
                'tempz

            End If

        End If


    End Sub

    Private Sub cboFCurr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFCurr.SelectedIndexChanged

    End Sub

    Private Sub mskETDDat_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.mskETDDat.SelectAll()
    End Sub

    Private Sub mskETDDat_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles mskETDDat.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then
            Cursor = Cursors.WaitCursor

            If check_ctnno_etddat() Then
                'Me.gbDocTyp_C_Entry.Enabled = False
                Me.txtInvNoList.Text = rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(0).Item("tmp_invlist")
                Me.txtCustList.Text = rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(0).Item("tmp_cuslist")
                Me.txtCusNoList.Text = rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(0).Item("tmp_cusnolist")
                Me.cboCtnSiz.Text = rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(0).Item("tmp_ctrsiz")

                Me.gbHeaderMain.Enabled = True
                Me.cboFCurr.Enabled = True

                Call display_dgINVMORE()
                dgINVMORE.Visible = True
                If Not rs_INVMORE.Tables("RESULT") Is Nothing Then
                    dgINVMORE.DataSource = rs_INVMORE.Tables("RESULT").DefaultView
                    dgINVMORE.Refresh()

                End If


                Me.btcSHM00007.TabPages(0).Enabled = False
                Me.btcSHM00007.TabPages(0).Enabled = True

            End If

            mskPckDat.Enabled = True
            gbDocTyp_D_Entry.Enabled = True
            'gbHeaderMain_Enter.Enabled = True

            Me.btcSHM00007.TabPages(0).Enabled = False
            Me.btcSHM00007.TabPages(0).Enabled = True
            Me.btcSHM00007.TabPages(1).Enabled = False
            Me.btcSHM00007.TabPages(1).Enabled = True
            btcSHM00007.Enabled = True

        End If
        Cursor = Cursors.Default
    End Sub

    Private Function find_ctnno_etddat() As Boolean

        If Me.txtCtn.Text = "" Then
            MsgBox("Container No cannot empty!")
            Me.txtCtn.Focus()
            find_ctnno_etddat = False
            Exit Function
        End If


        gspStr = "sp_select_SHIPGDTL_CTNETD_date '','" & Me.txtCtn.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SHIPGDTL_CTNETD_date, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SHM00007 #004 sp_select_SHIPGDTL_CTNETD : " & rtnStr)
            find_ctnno_etddat = False
            Exit Function
        Else
            If rs_SHIPGDTL_CTNETD_date.Tables("RESULT").Rows.Count = 0 Then
                'MsgBox("Record not found!")
                mskETDDat.Text = "__/__/____"
                mskETDDat.Focus()
                find_ctnno_etddat = False
            Else
                If Not IsDBNull(rs_SHIPGDTL_CTNETD_date.Tables("RESULT").Rows(0)("hih_slnonb")) Then
                    mskETDDat.Text = Microsoft.VisualBasic.Left(rs_SHIPGDTL_CTNETD_date.Tables("RESULT").Rows(0)("hih_slnonb"), 10)
                    mskETDDat.Focus()
                    find_ctnno_etddat = True
                Else
                    mskETDDat.Text = Format(Date.Today, "MM/dd/yyyy").ToString
                    mskETDDat.Focus()
                    find_ctnno_etddat = False

                End If
            End If
        End If


    End Function
    Private Function check_consol() As Boolean

        If Me.txtconsol.Text = "" Then
            MsgBox("Console No cannot empty!")
            Me.txtconsol.Focus()
            check_consol = False
            Exit Function
        End If


        gspStr = "sp_select_SHIPGDTL_Consol '','" & Me.txtconsol.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SHIPGDTL_CTNETD, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SHM00007 #004 sp_select_SHIPGDTL_Console : " & rtnStr)
            check_consol = False
            Exit Function
        Else
            If rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("Record not found!")
                check_consol = False
                Me.txtconsol.Focus()
                Exit Function
            Else
                check_consol = True
                rs_SHIPGDTL_CTNETD.Tables("RESULT").Columns("tmp_creusr").ReadOnly = False
                rs_SHIPGDTL_CTNETD.Tables("RESULT").Columns("tmp_mancbm").ReadOnly = False


                rs_SHIPGDTL_CTNETD_add = rs_SHIPGDTL_CTNETD.Copy

                gspStr = "sp_select_SHIPGDTL_co_consol '','" & Me.txtconsol.Text & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_SHIPGDTL_co, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading SHM00007 #004 sp_select_SHIPGDTL_Console : " & rtnStr)
                    check_consol = False
                    Exit Function
                Else

                    For index9 As Integer = 0 To rs_SHIPGDTL_co.Tables("RESULT").Rows.Count - 1
                        lstVendor.Items.Add(rs_SHIPGDTL_co.Tables("RESULT").Rows(index9)("company"))
                    Next


                End If



                '
            End If
        End If


    End Function

    Private Sub txtCtn_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCtn.GotFocus
        Me.txtCtn.SelectAll()
    End Sub

    Private Sub dgSHCHGDTL_Distribute_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSHCHGDTL_Distribute.CellValueChanged
        If rs_SHCHGFWD.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If

        If rs_SHCHGFWD.Tables("result").Rows.Count = 0 Then
            Exit Sub
        End If
        ' ''If e.ToString.Trim = "System.Windows.Forms.DataGridViewCellEventArgs" Then
        ' ''    Exit Sub
        ' ''End If
        If e.ToString.Trim <> "" Then
            '    If e.ToString.Trim <> "" And e.ToString.Trim <> "System.Windows.Forms.DataGridViewCellEventArgs" Then
            If Add_flag_A(ReadingIndex) = False And upd_flag_A(ReadingIndex) = False Then
                upd_flag_A(ReadingIndex) = True
            End If

            If display_dgSHCHGDTL_Distribute(cbofwdnam.Text.Trim) = True Then

                calculate_dgSHCHGDTL_CORE_flag = True
                Call calculate_dgSHCHGDTL_CORE("MANCBM")
                changeManualCBM = True
                Call calculate_dgSHCHGDTL_CORE("NONE")
                update_dtl(rs_SHCHGFWD.Tables("result").Rows(ReadingIndex)("scf_fwdnam"))

                flag_distribute_changed = True


                ' ''Call reset_and_display_dgSHCHGDTL_CORE(cbofwdnam.Text.Trim)
                ' ''Me.btcSHM00007.TabPages(1).Enabled = True
            End If


            'If display_dgSHCHGDTL_Distribute(cbofwdnam.Text.Trim) = True Then
            '    reset_and_display_SHCHGDTL(cbofwdnam.Text.Trim)
            '    For index9 As Integer = 0 To rs_SHCHGFWD.Tables("RESULT").Rows.Count - 1
            '        If Not IsDBNull(rs_SHCHGFWD.Tables("RESULT").Rows(index9)("scf_fwdnam")) Then
            '            If rs_SHCHGFWD.Tables("RESULT").Rows(index9)("scf_fwdnam") = cbofwdnam.Text.Trim Then
            '                'last_ReadingIndex = index9
            '            End If
            '        End If
            '    Next
            'End If




        End If



    End Sub

    Private Sub dgSHCHGDTL_Distribute_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgSHCHGDTL_Distribute.CurrentCellChanged
        If e.ToString = "System.EventArgs" Then
            Exit Sub
        End If
        If display_dgSHCHGDTL_Distribute(cbofwdnam.Text.Trim) = True Then
            Call reset_and_display_dgSHCHGDTL_CORE(cbofwdnam.Text.Trim)
            Me.btcSHM00007.TabPages(1).Enabled = True
        End If
    End Sub

    Private Sub dgSHCHGDTL_Distribute_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgSHCHGDTL_Distribute.EditingControlShowing
        Dim txtbox_dgSHCHGDTL_Distribute As TextBox = CType(e.Control, TextBox)
        If Not (txtbox_dgSHCHGDTL_Distribute Is Nothing) Then
            AddHandler txtbox_dgSHCHGDTL_Distribute.KeyPress, AddressOf txtBox_dgSHCHGDTL_Distribute_KeyPress
        End If
    End Sub

    Private Sub txtBox_dgSHCHGDTL_Distribute_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If check_exchrate() = True Then
            If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
                e.KeyChar = ""
            Else
                If rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Count > 1 Then
                    If dgSHCHGDTL_Distribute.CurrentCell.RowIndex = 1 Or dgSHCHGDTL_Distribute.CurrentCell.ColumnIndex = 0 Or dgSHCHGDTL_Distribute.CurrentCell.ColumnIndex = dgSHCHGDTL_Distribute.Columns.Count - 1 Then
                        e.KeyChar = ""

                    End If


                End If

            End If
        Else
            e.KeyChar = ""
            MsgBox("Please enter Exchange Rate!")
            Me.mskExchRat.Focus()
            Me.mskExchRat.SelectAll()
        End If
    End Sub

    Private Function display_dgSHCHGDTL_Distribute(ByVal fn As String) As Boolean
        Dim i As Integer
        Dim totalHKD As Decimal
        Dim totalCNY As Decimal

        If rs_SHCHGFWD.Tables("RESULT") Is Nothing Then
            display_dgSHCHGDTL_Distribute = True
            Exit Function
        End If

        For index9 As Integer = 0 To rs_SHCHGFWD.Tables("RESULT").Rows.Count - 1
            If Not IsDBNull(rs_SHCHGFWD.Tables("RESULT").Rows(index9)("scf_fwdnam")) Then
                If rs_SHCHGFWD.Tables("RESULT").Rows(index9)("scf_fwdnam") = fn Then
                    ReadingIndex = index9
                End If
            End If
        Next


        If rs_SHCHGFWD.Tables("RESULT").Rows.Count = 0 Then
            display_dgSHCHGDTL_Distribute = True
            Exit Function
        End If
        If rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("DEL") = "Y" Then
            display_dgSHCHGDTL_Distribute = True
            Exit Function
        End If

        totalHKD = 0.0
        totalCNY = 0.0


        If rs_SHCHGFWD.Tables("RESULT").Rows.Count = 0 Then
            display_dgSHCHGDTL_Distribute = True
            Exit Function
        End If


        If rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Count > 0 Then
            For i = 1 To dgSHCHGDTL_Distribute.Columns.Count - 3
                '                For i = 1 To dgSHCHGDTL_Distribute.Columns.Count - 2

                If rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fcurcde") <> "HKD" Then
                    If IsNumeric(rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(0).Item(i)) Then
                        totalCNY = totalCNY + rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(0).Item(i)
                        If rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Count > 1 Then
                            rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(1).Item(i) = System.Decimal.Round(rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(0).Item(i) * IIf(IsNumeric(Me.mskExchRat.Text), Me.mskExchRat.Text, 1), 2)
                        End If
                    Else ' CNY empty and HKD is not empty
                        If rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Count > 1 Then
                            rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(1).Item(i) = ""
                        End If
                    End If
                    If rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Count > 1 Then
                        If IsNumeric(rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(1).Item(i)) Then
                            totalHKD = totalHKD + rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(1).Item(i)
                        End If
                    End If
                    If dgSHCHGDTL_Distribute.Rows.Count > 1 Then
                        dgSHCHGDTL_Distribute.Rows(1).Cells(i).Style.BackColor = SystemColors.Control
                    End If

                Else
                    If IsNumeric(rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(0).Item(i)) Then
                        totalHKD = totalHKD + rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(0).Item(i)
                    End If
                End If

            Next i

            '       MsgBox(totalCNY & " : " & totalHKD)
            If rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fcurcde") <> "HKD" Then
                rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(0).Item("TOTAL") = totalCNY
                If rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Count > 1 Then
                    rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(1).Item("TOTAL") = totalHKD
                    rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(1).Item("fn") = fn
                End If
                '                rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_ttlamt") = totalCNY
            Else
                rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(0).Item("TOTAL") = totalHKD
                rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(0).Item("fn") = fn
                '              rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_ttlamt") = totalHKD
            End If




            'sFilter = "FN = '" & fn & "'"
            'rs_SHCHGDTL_Distribute.Tables("RESULT").DefaultView.RowFilter = sFilter

            dgSHCHGDTL_Distribute.Refresh()
            '2015
        End If





        display_dgSHCHGDTL_Distribute = True
        If rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Count > 0 And totalHKD = 0 And totalCNY = 0 Then
            display_dgSHCHGDTL_Distribute = False
        End If
    End Function

    Private Function calculate_dgSHCHGDTL_CORE(ByVal cal_colname As String) As Boolean
        calculate_dgSHCHGDTL_CORE = True

        If calculate_dgSHCHGDTL_CORE_flag = False Then
            Exit Function
        End If

        If rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count = 0 Then
            Exit Function
        End If

        If rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count = 0 Or rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fcurcde") = "" Then
            Exit Function
        End If
        If (rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fcurcde") <> "HKD" And rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count < 7) Or (rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fcurcde") = "HKD" And rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count < 5) Then
            Exit Function
        End If

        Dim i As Integer
        Dim j As Integer
        Dim colname As String

        Dim rowspace As Integer
        Dim locHKD As Integer
        rowspace = 0
        locHKD = 0

        If rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fcurcde") <> "HKD" Then
            rowspace = 3
            locHKD = 1
        Else
            rowspace = 2
            locHKD = 0
        End If

        If cal_colname = "MANCBM" Then
            'Recalculate Manual Input CBM
            Dim mancbmttl As Decimal
            mancbmttl = 0.0

            For i = rowspace To rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - rowspace - 1
                If IsNumeric(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item("MANCBM")) Then
                    mancbmttl = mancbmttl + System.Decimal.Round(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item("MANCBM"), 2)
                End If
            Next i

            If mancbmttl = 0.0 Then
                MsgBox("Manual CBM Total cannot be zero!")
                Exit Function
            End If

            For i = 0 To rs_SYMSHC_D.Tables("RESULT").Rows.Count - 1
                colname = rs_SYMSHC_D.Tables("RESULT").Rows(i).Item("ysc_chgcde")
                For j = rowspace To rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - rowspace - 1
                    If IsNumeric(rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(locHKD).Item(colname)) And IsNumeric(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(j).Item("MANCBM")) Then
                        rs_SHCHGDTL_CORE.Tables("RESULT").Rows(j).Item(colname) = System.Decimal.Round(rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(locHKD).Item(colname) * rs_SHCHGDTL_CORE.Tables("RESULT").Rows(j).Item("MANCBM") / mancbmttl, 2)
                    End If
                Next j
            Next i

            rs_SHCHGDTL_CORE.Tables("RESULT").Rows(rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - locHKD - 1).Item("MANCBM") = mancbmttl
        End If

        'Recalculate(Total - vert)
        Dim vendorttl As Decimal
        For i = rowspace To rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - rowspace - 1
            vendorttl = 0.0
            For j = 3 To rs_SHCHGDTL_CORE.Tables("RESULT").Columns.Count - 4
                'For j = 3 To rs_SHCHGDTL_CORE.Tables("RESULT").Columns.Count - 3
                If IsNumeric(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item(j)) Then
                    vendorttl = vendorttl + System.Decimal.Round(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item(j), 2)
                End If
            Next j
            If vendorttl >= 0 Then
                rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item("TOTAL") = System.Decimal.Round(vendorttl, 2)
            End If
        Next i

        'Recalculate(Total - horiz)
        Dim horizttl As Decimal
        For i = 2 To rs_SHCHGDTL_CORE.Tables("RESULT").Columns.Count - 2
            horizttl = 0.0
            For j = rowspace To rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - rowspace - 1
                If IsNumeric(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(j).Item(i)) Then
                    horizttl = horizttl + System.Decimal.Round(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(j).Item(i), 2)
                End If
            Next j
            If horizttl > 0 Then
                rs_SHCHGDTL_CORE.Tables("RESULT").Rows(rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - locHKD - 1).Item(i) = System.Math.Round(horizttl, 2)
                If rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fcurcde") <> "HKD" And i > 2 Then
                    rs_SHCHGDTL_CORE.Tables("RESULT").Rows(rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - locHKD + 1 - 1).Item(i) = System.Math.Round((System.Math.Round(horizttl, 2) / Me.mskExchRat.Text), 2)
                End If
            End If
        Next i

        calculate_dgSHCHGDTL_CORE_flag = False

        dgSHCHGDTL_CORE.Refresh()

        ' rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_ttlamt") = rs_SHCHGDTL_CORE.Tables("RESULT").Rows(rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - 1)("total")

    End Function
    Private Function reset_and_display_dgSHCHGDTL_CORE(ByVal fn As String) As Boolean


        Dim i As Integer
        Dim colname As String

        Dim locHKD As Integer
        Dim last_locHKD As Integer

        locHKD = 0
        If rs_SHCHGFWD.Tables("RESULT") Is Nothing Then
            reset_and_display_dgSHCHGDTL_CORE = True
            Exit Function
        End If
        If rs_SHCHGFWD.Tables("RESULT").Rows.Count = 0 Then
            reset_and_display_dgSHCHGDTL_CORE = True
            Exit Function
        End If


        If rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fcurcde") <> "HKD" Then
            locHKD = 1
        Else
            locHKD = 0
        End If


        If rs_SHCHGFWD.Tables("RESULT").Rows(last_ReadingIndex)("scf_fcurcde") <> "HKD" Then
            last_locHKD = 3
        Else
            last_locHKD = 2
        End If
        'If rs_SHCHGFWD.Tables("RESULT").Rows(last_ReadingIndex)("scf_fcurcde") <> "HKD" Then
        '    last_locHKD = 1
        'Else
        '    last_locHKD = 0
        'End If

        If Not ((rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fcurcde") <> "HKD" And rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Count > 1) Or (rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fcurcde") = "HKD" And rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Count > 0)) Then
            Exit Function
        End If




        If rs_SHIPGDTL_CTNETD.Tables("RESULT") Is Nothing Then
            reset_and_display_dgSHCHGDTL_CORE = True
            Exit Function
        End If


        If rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count > 0 Then
            'store manual input CBM
            'If changeManualCBM = True Then


            For i = last_locHKD To rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - (last_locHKD + 1)
                'For i = last_locHKD + 2 To rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - (last_locHKD + 2) - 1
                If Not IsDBNull(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item("MANCBM")) Then

                    For index9 As Integer = 0 To rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows.Count - 1
                        If rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(index9)("tmp_fwdnam") = rs_SHCHGFWD.Tables("result").Rows(last_ReadingIndex)("scf_fwdnam") And _
                        rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(index9)("tmp_vbi_venno") = rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item("VENCDE") Then
                            rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(index9).Item("tmp_mancbm") = rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item("MANCBM")
                        End If
                    Next

                    'sFilter = "tmp_fwdnam = '" & rs_SHCHGFWD.Tables("result").Rows(last_ReadingIndex)("scf_fwdnam") _
                    '& "' and tmp_vbi_venno ='" & rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item("VENCDE") & "' "

                    'rs_SHIPGDTL_CTNETD.Tables("RESULT").DefaultView.RowFilter = sFilter

                    'If rs_SHIPGDTL_CTNETD.Tables("RESULT").DefaultView.Count > 0 Then
                    '    rs_SHIPGDTL_CTNETD.Tables("RESULT").DefaultView(0).Item("tmp_mancbm") = rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item("MANCBM")
                    'End If


                End If
            Next i
        End If


        For index9 As Integer = 0 To rs_SHCHGFWD.Tables("RESULT").Rows.Count - 1
            If Not IsDBNull(rs_SHCHGFWD.Tables("RESULT").Rows(index9)("scf_fwdnam")) Then
                If rs_SHCHGFWD.Tables("RESULT").Rows(index9)("scf_fwdnam") = fn Then
                    last_ReadingIndex = index9
                End If
            End If
        Next


        'tempz


        'If rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count > 0 Then
        '    'store manual input CBM
        '    'If changeManualCBM = True Then

        '    sFilter = "tmp_fwdnam = '" & rs_SHCHGFWD.Tables("result").Rows(last_ReadingIndex)("scf_fwdnam") & "'"
        '    rs_SHIPGDTL_CTNETD.Tables("RESULT").DefaultView.RowFilter = sFilter

        '    For i = last_locHKD + 2 To rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - (last_locHKD + 2) - 1
        '        If Not IsDBNull(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item("MANCBM")) Then
        '            If i - last_locHKD - 2 <= rs_SHIPGDTL_CTNETD.Tables("RESULT").DefaultView.Count - 1 Then
        '                'temp

        '                rs_SHIPGDTL_CTNETD.Tables("RESULT").DefaultView(i - last_locHKD - 2).Item("tmp_mancbm") = rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item("MANCBM")

        '            End If
        '        End If
        '    Next i
        'End If

        rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Clear()


        sFilter = "tmp_fwdnam = '" & fn & "'"
        rs_SHIPGDTL_CTNETD.Tables("RESULT").DefaultView.RowFilter = sFilter

        If rs_SHIPGDTL_CTNETD.Tables("RESULT").DefaultView.Count = 0 Then
            Exit Function
        End If


        ' row 0 
        If rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fcurcde") = "CNY" Then
            dsNewRow = rs_SHCHGDTL_CORE.Tables("RESULT").NewRow()
            dsNewRow.Item("fn") = fn

            dsNewRow.Item("VENDOR") = "舥だ计(CNY)"
            rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Add(dsNewRow)
        End If
        If rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fcurcde") = "USD" Then
            dsNewRow = rs_SHCHGDTL_CORE.Tables("RESULT").NewRow()
            dsNewRow.Item("fn") = fn

            dsNewRow.Item("VENDOR") = "舥だ计(USD)"
            rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Add(dsNewRow)
        End If

        ' row 1
        dsNewRow = rs_SHCHGDTL_CORE.Tables("RESULT").NewRow()
        dsNewRow.Item("fn") = fn
        dsNewRow.Item("VENDOR") = "舥だ计(HKD)"
        rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Add(dsNewRow)



        If rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fcurcde") <> "HKD" Then
            For i = 1 To rs_SHCHGDTL_Distribute.Tables("RESULT").Columns.Count - 1
                colname = rs_SHCHGDTL_Distribute.Tables("RESULT").Columns(i).ColumnName
                If IsNumeric(rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(0).Item(colname)) Then
                    rs_SHCHGDTL_CORE.Tables("RESULT").Rows(0).Item(colname) = rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(0).Item(colname)
                End If
                If IsNumeric(rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(1).Item(colname)) Then
                    If rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count > 1 Then
                        'temp
                        rs_SHCHGDTL_CORE.Tables("RESULT").Rows(1).Item(colname) = rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(1).Item(colname)

                    End If

                End If
            Next i
        Else
            For i = 1 To rs_SHCHGDTL_Distribute.Tables("RESULT").Columns.Count - 1
                colname = rs_SHCHGDTL_Distribute.Tables("RESULT").Columns(i).ColumnName
                If IsNumeric(rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(0).Item(colname)) Then
                    rs_SHCHGDTL_CORE.Tables("RESULT").Rows(0).Item(colname) = rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(0).Item(colname)
                End If
            Next
        End If


        ' row 2
        dsNewRow = rs_SHCHGDTL_CORE.Tables("RESULT").NewRow()
        dsNewRow.Item("fn") = fn
        dsNewRow.Item("VENDOR") = ""
        dsNewRow.Item("VENCDE") = ""
        rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Add(dsNewRow)


        'calculate rounded mancbmttl
        Dim mancbmttl As Decimal
        mancbmttl = 0.0
        For i = 0 To rs_SHIPGDTL_CTNETD.Tables("RESULT").DefaultView.Count - 1
            If IsNumeric(rs_SHIPGDTL_CTNETD.Tables("RESULT").DefaultView(i).Item("tmp_mancbm")) Then
                mancbmttl = mancbmttl + System.Decimal.Round(rs_SHIPGDTL_CTNETD.Tables("RESULT").DefaultView(i).Item("tmp_mancbm"), 2)
            End If
        Next i

        Dim j As Integer
        Dim vendorttl As Decimal

        vendorttl = 0.0
        'row 3 after (Vendor)



        For i = 0 To rs_SHIPGDTL_CTNETD.Tables("RESULT").DefaultView.Count - 1
            dsNewRow = rs_SHCHGDTL_CORE.Tables("RESULT").NewRow()
            dsNewRow.Item("fn") = fn

            dsNewRow.Item("VENCDE") = rs_SHIPGDTL_CTNETD.Tables("RESULT").DefaultView(i).Item("tmp_vbi_venno")
            dsNewRow.Item("VENDOR") = rs_SHIPGDTL_CTNETD.Tables("RESULT").DefaultView(i).Item("tmp_vbi_vensna")
            '''this will be wrong for ttl row, since ctn record  has no ttl vendor

            dsNewRow.Item("SYSCBM") = rs_SHIPGDTL_CTNETD.Tables("RESULT").DefaultView(i).Item("tmp_cbm")
            If IsNumeric(rs_SHIPGDTL_CTNETD.Tables("RESULT").DefaultView(i).Item("tmp_mancbm")) Then
                dsNewRow.Item("MANCBM") = System.Decimal.Round(rs_SHIPGDTL_CTNETD.Tables("RESULT").DefaultView(i).Item("tmp_mancbm"), 2)
            Else
                dsNewRow.Item("MANCBM") = 0
            End If
            If IsNumeric(dsNewRow.Item("SYSCBM")) Then
                If dsNewRow.Item("SYSCBM") = 0.0 Then
                    dsNewRow.Item("SYSCBM") = ""
                End If
            Else
                dsNewRow.Item("SYSCBM") = ""
            End If


            Dim sFee As Decimal
            sFee = 0
            vendorttl = 0.0

            If flag_sub_value_change(ReadingIndex) = False Then
                ''''temp20150521
                'If Insert_flag = True Or Add_flag_A(ReadingIndex) = True Then
                For j = 1 To rs_SHCHGDTL_Distribute.Tables("RESULT").Columns.Count - 2
                    colname = rs_SHCHGDTL_Distribute.Tables("RESULT").Columns(j).ColumnName

                    If rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Count > 0 Then
                        If IsNumeric(rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(locHKD).Item(colname)) And IsNumeric(dsNewRow.Item("MANCBM")) Then
                            If mancbmttl <> 0 Then
                                dsNewRow.Item(colname) = System.Decimal.Round(rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(locHKD).Item(colname) * dsNewRow.Item("MANCBM") / mancbmttl, 2)
                                vendorttl = vendorttl + dsNewRow.Item(colname)
                            Else
                                dsNewRow.Item(colname) = 0
                                'temp
                            End If
                            'temp
                        End If
                    End If
                Next j
            Else
                For j = 2 + locHKD To rs_SHCHGDTL_CORE.Tables("RESULT").Columns.Count - (2 + locHKD)
                    colname = rs_SHCHGDTL_CORE.Tables("RESULT").Columns(j).ColumnName

                    sFee = search_SHCHGDTL_By_Vendor_ChgCde_Curr(fn, dsNewRow.Item("VENCDE"), colname, "HKD")
                    If sFee <> 0 Then
                        dsNewRow.Item(colname) = System.Decimal.Round(sFee, 2)
                        vendorttl = vendorttl + dsNewRow.Item(colname)
                    End If
                Next j

            End If
            dsNewRow.Item("TOTAL") = System.Decimal.Round(vendorttl, 2)

            rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Add(dsNewRow)
        Next i

        If Insert_flag = True Then
            Insert_flag = False
            'TEMP 20150521
            '     If Add_flag_A(ReadingIndex) = True Then
            'temp
            dsNewRow = rs_SHCHGDTL_CORE.Tables("RESULT").NewRow()
            dsNewRow.Item("fn") = fn

            rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Add(dsNewRow)
            Call display_lstVendor(rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count)
        End If

        ' row 97
        dsNewRow = rs_SHCHGDTL_CORE.Tables("RESULT").NewRow()
        dsNewRow.Item("fn") = fn

        dsNewRow.Item("VENDOR") = ""
        dsNewRow.Item("VENCDE") = ""
        rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Add(dsNewRow)


        ' row 98
        dsNewRow = rs_SHCHGDTL_CORE.Tables("RESULT").NewRow()
        dsNewRow.Item("fn") = fn

        dsNewRow.Item("VENDOR") = "羆璸(HKD)"
        dsNewRow.Item("VENCDE") = ""
        dsNewRow.Item("MANCBM") = mancbmttl
        dsNewRow.Item("SYSCBM") = rs_SHIPGDTL_CTNETD.Tables("RESULT").DefaultView(0).Item("tmp_ttlcbm")



        Dim tmpTtl As Decimal
        For i = 1 To rs_SHCHGDTL_CORE.Tables("RESULT").Columns.Count - 2
            tmpTtl = 0
            colname = rs_SHCHGDTL_CORE.Tables("RESULT").Columns(i).ColumnName
            For j = 2 + locHKD To rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - (1 + locHKD)
                If IsNumeric(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(j).Item(colname)) Then
                    tmpTtl = tmpTtl + rs_SHCHGDTL_CORE.Tables("RESULT").Rows(j).Item(colname)
                End If
            Next j
            If tmpTtl <> 0 Then
                dsNewRow.Item(colname) = System.Decimal.Round(tmpTtl, 2)


            End If
        Next i

        rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Add(dsNewRow)


        Dim lastrow As Integer
        lastrow = rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - 1

        If rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fcurcde") <> "HKD" Then
            ' row 99
            dsNewRow = rs_SHCHGDTL_CORE.Tables("RESULT").NewRow()
            dsNewRow.Item("fn") = fn

            dsNewRow.Item("VENDOR") = "羆璸(" & rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fcurcde") & ")"
            dsNewRow.Item("VENCDE") = ""



            For i = 3 To rs_SHCHGDTL_CORE.Tables("RESULT").Columns.Count - 2
                colname = rs_SHCHGDTL_CORE.Tables("RESULT").Columns(i).ColumnName
                If IsNumeric(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(lastrow).Item(colname)) Then
                    dsNewRow.Item(colname) = System.Decimal.Round(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(lastrow).Item(colname) / Me.mskExchRat.Text, 2)


                End If
            Next i
            rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Add(dsNewRow)
        End If

        If IsDBNull(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - 1)("total")) Then
            rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_ttlamt") = rs_SHCHGDTL_CORE.Tables("RESULT").Rows(0)("total")
        Else
            rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_ttlamt") = rs_SHCHGDTL_CORE.Tables("RESULT").Rows(rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - 1)("total")
        End If

        dgSHCHGDTL_CORE.DataSource = rs_SHCHGDTL_CORE.Tables("RESULT")
        dgSHCHGDTL_CORE.Refresh()

        Call update_dtl(fn)
        '        Call update_dtl(cbofwdnam.Text.Trim())
        '        Call update_dtl(cbofwd.Text.Trim())

        If rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fcurcde") <> "HKD" Then
            For i = 0 To dgSHCHGDTL_CORE.Columns.Count - 1
                'For i = 0 To dgSHCHGDTL_CORE.Columns.Count - 1
                If i <> 1 And i <> 2 Then
                    dgSHCHGDTL_CORE.Rows(0).Cells(i).Style.BackColor = SystemColors.Control
                    dgSHCHGDTL_CORE.Rows(1).Cells(i).Style.BackColor = SystemColors.Control
                    dgSHCHGDTL_CORE.Rows(2).Cells(i).Style.BackColor = SystemColors.Control
                    dgSHCHGDTL_CORE.Rows(dgSHCHGDTL_CORE.Rows.Count - 3).Cells(i).Style.BackColor = SystemColors.Control
                    dgSHCHGDTL_CORE.Rows(dgSHCHGDTL_CORE.Rows.Count - 2).Cells(i).Style.BackColor = SystemColors.Control
                    dgSHCHGDTL_CORE.Rows(dgSHCHGDTL_CORE.Rows.Count - 1).Cells(i).Style.BackColor = SystemColors.Control
                End If
            Next i
            For j = 0 To dgSHCHGDTL_CORE.Rows.Count - 1
                If j + 3 < dgSHCHGDTL_CORE.Rows.Count - 3 Then
                    dgSHCHGDTL_CORE.Rows(j + 3).Cells(2).Style.BackColor = Color.White
                End If
            Next

        Else
            For i = 0 To dgSHCHGDTL_CORE.Columns.Count - 1
                If i <> 1 And i <> 2 Then
                    dgSHCHGDTL_CORE.Rows(0).Cells(i).Style.BackColor = SystemColors.Control
                    dgSHCHGDTL_CORE.Rows(1).Cells(i).Style.BackColor = SystemColors.Control
                    dgSHCHGDTL_CORE.Rows(dgSHCHGDTL_CORE.Rows.Count - 2).Cells(i).Style.BackColor = SystemColors.Control
                    dgSHCHGDTL_CORE.Rows(dgSHCHGDTL_CORE.Rows.Count - 1).Cells(i).Style.BackColor = SystemColors.Control
                End If
            Next i
            For j = 0 To dgSHCHGDTL_CORE.Rows.Count - 1
                If j + 2 < dgSHCHGDTL_CORE.Rows.Count - 2 Then
                    dgSHCHGDTL_CORE.Rows(j + 2).Cells(2).Style.BackColor = Color.White
                End If
            Next

        End If


        'dgSHCHGDTL_CORE.DataSource = rs_SHCHGDTL_CORE.Tables("RESULT")
        'dgSHCHGDTL_CORE.Refresh()


        If dgSHCHGDTL_CORE.Columns.Count - 3 >= 0 Then
            dgSHCHGDTL_CORE.Columns(dgSHCHGDTL_CORE.Columns.Count - 3).ReadOnly = True
            dgSHCHGDTL_CORE.Columns(dgSHCHGDTL_CORE.Columns.Count - 2).Visible = False
            dgSHCHGDTL_CORE.Columns(dgSHCHGDTL_CORE.Columns.Count - 1).Visible = False
        End If
        'tempzz

        dgSHCHGDTL_CORE.Focus()
        If dgSHCHGDTL_CORE.Columns.Count > 11 Then
            If rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fcurcde") <> "HKD" Then
                dgSHCHGDTL_CORE.CurrentCell = dgSHCHGDTL_CORE.Item(10, 3)
            Else
                dgSHCHGDTL_CORE.CurrentCell = dgSHCHGDTL_CORE.Item(10, 2)
            End If

            dgSHCHGDTL_CORE.BeginEdit(True)

        End If
        'tempzz

        'dgSHCHGDTL_CORE.DataSource = rs_SHCHGDTL_CORE.Tables("RESULT")
        'dgSHCHGDTL_CORE.Refresh()
        'dgSHCHGDTL_CORE.Refresh()



    End Function




    Private Function add_dgSHCHGDTL_CORE() As Boolean


        'Dim i As Integer
        'Dim colname As String

        'Dim locHKD As Integer
        'locHKD = 0
        'If Me.cboFCurr.Text <> "HKD" Then
        '    locHKD = 1
        'Else
        '    locHKD = 0
        'End If


        'If Not ((Me.cboFCurr.Text <> "HKD" And rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Count > 1) Or (Me.cboFCurr.Text = "HKD" And rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Count > 0)) Then
        '    Exit Function
        'End If

        'If rs_SHIPGDTL_CTNETD.Tables("RESULT").defaultview.Count = 0 Then
        '    Exit Function
        'End If

        'If rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count > 0 Then

        '    'store manual input CBM
        '    If changeManualCBM = True Then
        '        For i = locHKD + 2 To rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - (locHKD + 2) - 1
        '            rs_SHIPGDTL_CTNETD.Tables("RESULT").defaultview(i - locHKD - 2).Item("tmp_mancbm") = rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item("MANCBM")
        '        Next i
        '    End If

        '    rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Clear()
        'End If

        '' row 0 
        'If Me.cboFCurr.Text <> "HKD" Then
        '    dsNewRow = rs_SHCHGDTL_CORE.Tables("RESULT").NewRow()
        '    dsNewRow.Item("VENDOR") = "舥だ计(CNY)"
        '    rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Add(dsNewRow)
        'End If

        '' row 1
        'dsNewRow = rs_SHCHGDTL_CORE.Tables("RESULT").NewRow()
        'dsNewRow.Item("VENDOR") = "舥だ计(HKD)"
        'rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Add(dsNewRow)



        'If Me.cboFCurr.Text <> "HKD" Then
        '    For i = 1 To rs_SHCHGDTL_Distribute.Tables("RESULT").Columns.Count - 1
        '        colname = rs_SHCHGDTL_Distribute.Tables("RESULT").Columns(i).ColumnName
        '        If IsNumeric(rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(0).Item(colname)) Then
        '            rs_SHCHGDTL_CORE.Tables("RESULT").Rows(0).Item(colname) = rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(0).Item(colname)
        '        End If
        '        If IsNumeric(rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(1).Item(colname)) Then
        '            rs_SHCHGDTL_CORE.Tables("RESULT").Rows(1).Item(colname) = rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(1).Item(colname)
        '        End If
        '    Next i
        'Else
        '    For i = 1 To rs_SHCHGDTL_Distribute.Tables("RESULT").Columns.Count - 1
        '        colname = rs_SHCHGDTL_Distribute.Tables("RESULT").Columns(i).ColumnName
        '        If IsNumeric(rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(0).Item(colname)) Then
        '            rs_SHCHGDTL_CORE.Tables("RESULT").Rows(0).Item(colname) = rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(0).Item(colname)
        '        End If
        '    Next
        'End If


        '' row 2
        'dsNewRow = rs_SHCHGDTL_CORE.Tables("RESULT").NewRow()
        'dsNewRow.Item("VENDOR") = ""
        'dsNewRow.Item("VENCDE") = ""
        'rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Add(dsNewRow)


        ''calculate rounded mancbmttl
        'Dim mancbmttl As Decimal
        'mancbmttl = 0.0
        'For i = 0 To rs_SHIPGDTL_CTNETD.Tables("RESULT").defaultview.Count - 1
        '    If IsNumeric(rs_SHIPGDTL_CTNETD.Tables("RESULT").defaultview(i).Item("tmp_mancbm")) Then
        '        mancbmttl = mancbmttl + System.Decimal.Round(rs_SHIPGDTL_CTNETD.Tables("RESULT").defaultview(i).Item("tmp_mancbm"), 2)
        '    End If
        'Next i

        'Dim j As Integer
        'Dim vendorttl As Decimal

        'vendorttl = 0.0
        ''row 3 after (Vendor)
        'For i = 0 To rs_SHIPGDTL_CTNETD.Tables("RESULT").defaultview.Count - 1
        '    dsNewRow = rs_SHCHGDTL_CORE.Tables("RESULT").NewRow()

        '    dsNewRow.Item("VENCDE") = rs_SHIPGDTL_CTNETD.Tables("RESULT").defaultview(i).Item("tmp_vbi_venno")
        '    dsNewRow.Item("VENDOR") = rs_SHIPGDTL_CTNETD.Tables("RESULT").defaultview(i).Item("tmp_vbi_vensna")
        '    dsNewRow.Item("SYSCBM") = rs_SHIPGDTL_CTNETD.Tables("RESULT").defaultview(i).Item("tmp_cbm")
        '    If IsNumeric(rs_SHIPGDTL_CTNETD.Tables("RESULT").defaultview(i).Item("tmp_mancbm")) Then
        '        dsNewRow.Item("MANCBM") = System.Decimal.Round(rs_SHIPGDTL_CTNETD.Tables("RESULT").defaultview(i).Item("tmp_mancbm"), 2)
        '    Else
        '        dsNewRow.Item("MANCBM") = 0
        '    End If
        '    If IsNumeric(dsNewRow.Item("SYSCBM")) Then
        '        If dsNewRow.Item("SYSCBM") = 0.0 Then
        '            dsNewRow.Item("SYSCBM") = ""
        '        End If
        '    Else
        '        dsNewRow.Item("SYSCBM") = ""
        '    End If

        '    'Dim tmpsyscbm As String
        '    'Dim tmpmancbm As String

        '    'If IsNumeric(dsNewRow.Item("MANCBM")) Then
        '    '    If dsNewRow.Item("MANCBM") = 0.0 Then
        '    '        For j = 0 To rs_SYMSHC_D.Tables("RESULT").Rows.Count - 1
        '    '            colname = rs_SYMSHC_D.Tables("RESULT").Rows(j).Item("ysc_chgcde")
        '    '            tmpsyscbm = 0.0
        '    '            tmpmancbm = 0.0
        '    '            Call search_SHCHGDTL_CBM(dsNewRow.Item("VENCDE"), colname, "HKD", tmpsyscbm, tmpmancbm)

        '    '            If tmpmancbm <> "" Then
        '    '                Dim tmpdecimal As Decimal
        '    '                tmpdecimal = tmpmancbm
        '    '                dsNewRow.Item("MANCBM") = System.Decimal.Round(tmpdecimal, 2)
        '    '                Exit For
        '    '            End If
        '    '        Next j
        '    '    End If
        '    'End If



        '    Dim sFee As Decimal
        '    sFee = 0
        '    vendorttl = 0.0

        '    If Insert_flag = True Or Add_flag_A(ReadingIndex) = True Then
        '        For j = 1 To rs_SHCHGDTL_Distribute.Tables("RESULT").Columns.Count - 2
        '            colname = rs_SHCHGDTL_Distribute.Tables("RESULT").Columns(j).ColumnName

        '            If rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Count > 0 Then
        '                If IsNumeric(rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(locHKD).Item(colname)) And IsNumeric(dsNewRow.Item("MANCBM")) Then
        '                    dsNewRow.Item(colname) = System.Decimal.Round(rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(locHKD).Item(colname) * dsNewRow.Item("MANCBM") / mancbmttl, 2)
        '                    vendorttl = vendorttl + dsNewRow.Item(colname)
        '                End If
        '            End If
        '        Next j
        '    Else
        '        For j = 2 + locHKD To rs_SHCHGDTL_CORE.Tables("RESULT").Columns.Count - (2 + locHKD)
        '            colname = rs_SHCHGDTL_CORE.Tables("RESULT").Columns(j).ColumnName

        '            sFee = search_SHCHGDTL_By_Vendor_ChgCde_Curr(dsNewRow.Item("VENCDE"), colname, "HKD")
        '            If sFee <> 0 Then
        '                dsNewRow.Item(colname) = System.Decimal.Round(sFee, 2)
        '                vendorttl = vendorttl + dsNewRow.Item(colname)
        '            End If
        '        Next j

        '    End If
        '    dsNewRow.Item("TOTAL") = System.Decimal.Round(vendorttl, 2)

        '    rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Add(dsNewRow)
        'Next i


        'If Insert_flag = True Then
        '    dsNewRow = rs_SHCHGDTL_CORE.Tables("RESULT").NewRow()
        '    rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Add(dsNewRow)
        '    Call display_lstVendor(rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count)
        'End If

        '' row 97
        'dsNewRow = rs_SHCHGDTL_CORE.Tables("RESULT").NewRow()
        'dsNewRow.Item("VENDOR") = ""
        'dsNewRow.Item("VENCDE") = ""
        'rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Add(dsNewRow)


        '' row 98
        'dsNewRow = rs_SHCHGDTL_CORE.Tables("RESULT").NewRow()
        'dsNewRow.Item("VENDOR") = "羆璸(HKD)"
        'dsNewRow.Item("VENCDE") = ""
        'dsNewRow.Item("MANCBM") = mancbmttl
        'dsNewRow.Item("SYSCBM") = rs_SHIPGDTL_CTNETD.Tables("RESULT").defaultview(0).Item("tmp_ttlcbm")
        'Dim tmpTtl As Decimal
        'For i = 1 To rs_SHCHGDTL_CORE.Tables("RESULT").Columns.Count - 2
        '    tmpTtl = 0
        '    colname = rs_SHCHGDTL_CORE.Tables("RESULT").Columns(i).ColumnName
        '    For j = 2 + locHKD To rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - (1 + locHKD)
        '        If IsNumeric(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(j).Item(colname)) Then
        '            tmpTtl = tmpTtl + rs_SHCHGDTL_CORE.Tables("RESULT").Rows(j).Item(colname)
        '        End If
        '    Next j
        '    If tmpTtl <> 0 Then
        '        dsNewRow.Item(colname) = System.Decimal.Round(tmpTtl, 2)
        '    End If
        'Next i

        'rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Add(dsNewRow)


        'Dim lastrow As Integer
        'lastrow = rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - 1

        'If Me.cboFCurr.Text <> "HKD" Then
        '    ' row 99
        '    dsNewRow = rs_SHCHGDTL_CORE.Tables("RESULT").NewRow()
        '    dsNewRow.Item("VENDOR") = "羆璸(CNY)"
        '    dsNewRow.Item("VENCDE") = ""


        '    For i = 3 To rs_SHCHGDTL_CORE.Tables("RESULT").Columns.Count - 2
        '        colname = rs_SHCHGDTL_CORE.Tables("RESULT").Columns(i).ColumnName
        '        If IsNumeric(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(lastrow).Item(colname)) Then
        '            dsNewRow.Item(colname) = System.Decimal.Round(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(lastrow).Item(colname) / Me.mskExchRat.Text, 2)
        '        End If
        '    Next i
        '    rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Add(dsNewRow)
        'End If

        'dgSHCHGDTL_CORE.Refresh()

    End Function

    Private Function check_exchrate() As Boolean
        If IsNumeric(Me.mskExchRat.Text) = True Then
            check_exchrate = True
        Else
            check_exchrate = False
        End If
    End Function

    Private Sub mskExchRat_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles mskExchRat.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then
            If cboFCurr.Text = "CNY" Then
                Call format_dgSHCHGDTL_Distribute("CNY")

                dgSHCHGDTL_Distribute.Focus()
                dgSHCHGDTL_Distribute.CurrentCell = dgSHCHGDTL_Distribute.Item(1, 0)
                dgSHCHGDTL_Distribute.BeginEdit(True)



            ElseIf cboFCurr.Text = "USD" Then
                Call format_dgSHCHGDTL_Distribute("USD")
                dgSHCHGDTL_Distribute.Focus()
                dgSHCHGDTL_Distribute.CurrentCell = dgSHCHGDTL_Distribute.Item(1, 0)
                dgSHCHGDTL_Distribute.BeginEdit(True)
            Else
            End If




            If check_exchrate() = True Then
                Call display_dgSHCHGDTL_Distribute(cbofwdnam.Text.Trim)
                ' ''calculate_dgSHCHGDTL_Distribute_flag = True
                ' ''Call calculate_dgSHCHGDTL_Distribute("MANCBM")
                ' ''changeManualCBM = True
                ' ''Call calculate_dgSHCHGDTL_Distribute("NONE")
                ' ''update_dtl(cbofwd.Text.Trim())
                'tempz
            End If

            dgSHCHGDTL_Distribute.ReadOnly = False
            mskExchRat.Enabled = False


        End If
    End Sub

    Private Sub mskExchRat_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskExchRat.LostFocus

    End Sub
    Private Sub mmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdSave.Click
        Call cmdSaveClick()

    End Sub


    Private Sub dgSHCHGDTL_CORE_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgSHCHGDTL_CORE.CellBeginEdit
        flag_sub_value_change(ReadingIndex) = True

    End Sub

    Private Sub dgSHCHGDTL_CORE_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSHCHGDTL_CORE.CellValueChanged


        'If e.ToString.Trim = "System.Windows.Forms.DataGridViewCellEventArgs" Then
        '    Exit Sub
        'End If

        If rs_SHCHGFWD.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If
        If rs_SHCHGFWD.Tables("RESULT").Rows.Count = 0 Then
            Exit Sub
        End If

        If Add_flag_A(ReadingIndex) = False And upd_flag_A(ReadingIndex) = False Then
            upd_flag_A(ReadingIndex) = True
        End If
        If e.ColumnIndex = 2 Then
            Call calculate_dgSHCHGDTL_CORE("MANCBM")
            If rs_SHIPGDTL_CTNETD.Tables.Count > 0 Then
                If rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fcurcde") <> "HKD" Then
                    If e.RowIndex - 3 >= 0 Then
                        rs_SHIPGDTL_CTNETD.Tables("RESULT").DefaultView(e.RowIndex - 3).Item("tmp_creusr") = "~*UPD*~"
                    End If


                Else
                    If e.RowIndex - 2 >= 0 Then
                        rs_SHIPGDTL_CTNETD.Tables("RESULT").DefaultView(e.RowIndex - 2).Item("tmp_creusr") = "~*UPD*~"

                    End If

                End If
            End If
            changeManualCBM = True
        Else
            Call calculate_dgSHCHGDTL_CORE("NONE")
        End If

        update_dtl(cbofwd.Text.Trim())
        '''Call reset_and_display_dgSHCHGDTL_CORE(cbofwdnam.Text.Trim)


    End Sub

    Private Sub dgSHCHGDTL_CORE_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgSHCHGDTL_CORE.CurrentCellChanged
        Call calculate_dgSHCHGDTL_CORE("NONE")
    End Sub

    Private Sub dgSHCHGDTL_CORE_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgSHCHGDTL_CORE.EditingControlShowing
        Dim txtbox_dgSHCHGDTL_CORE As TextBox = CType(e.Control, TextBox)
        If Not (txtbox_dgSHCHGDTL_CORE Is Nothing) Then
            AddHandler txtbox_dgSHCHGDTL_CORE.KeyPress, AddressOf txtBox_dgSHCHGDTL_CORE_KeyPress
        End If
    End Sub

    Private Sub txtBox_dgSHCHGDTL_CORE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        Else
            If rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count > 1 Then
                If dgSHCHGDTL_CORE.CurrentCell.RowIndex = 0 Then
                    e.KeyChar = ""
                ElseIf dgSHCHGDTL_CORE.CurrentCell.RowIndex = 1 Then
                    e.KeyChar = ""
                ElseIf dgSHCHGDTL_CORE.CurrentCell.RowIndex = 2 And rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fcurcde") <> "HKD" Then
                    e.KeyChar = ""
                ElseIf dgSHCHGDTL_CORE.CurrentCell.RowIndex = rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - 1 Then
                    e.KeyChar = ""
                ElseIf dgSHCHGDTL_CORE.CurrentCell.RowIndex = rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - 2 Then
                    e.KeyChar = ""
                ElseIf dgSHCHGDTL_CORE.CurrentCell.RowIndex = rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - 3 And rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fcurcde") <> "HKD" Then
                    e.KeyChar = ""
                Else
                    calculate_dgSHCHGDTL_CORE_flag = True
                End If
            End If
        End If
    End Sub

    Private Sub mmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdInsRow.Click


        If btcSHM00007.SelectedIndex = 1 Then
            flag_cmdInsRow_Click = True
            gbHeaderMain.Enabled = True
            Call fill_fwd()
            Call ins_leavepage()

            If check_fwd() = False And rs_SHCHGFWD.Tables("result").Rows.Count > 0 Then
                Exit Sub
            End If


            'last_ReadingIndex = ReadingIndex
            ReadingIndex = rs_SHCHGFWD.Tables("result").Rows.Count

            ReDim Preserve Add_flag_A(ReadingIndex)
            ReDim Preserve upd_flag_A(ReadingIndex)
            Add_flag_A(ReadingIndex) = True
            upd_flag_A(ReadingIndex) = False
            Call add_forward()
            Call display_fwd_header("")

            cbofwdnam.Enabled = True

            txtFwdInv.Enabled = False
            cbofcrno.Enabled = False
            cboFCurr.Enabled = False
            rtxtRmk.Enabled = False
            mskExchRat.Enabled = False


            Me.btcSHM00007.TabPages(2).Enabled = True

        ElseIf btcSHM00007.SelectedIndex = 2 Then

            Insert_flag = True
            If cbofwd.Text.Trim = "" Then
                MsgBox("Please select forwarder!")
                Exit Sub
            End If
            Call reset_and_display_dgSHCHGDTL_CORE(cbofwdnam.Text.Trim)


        End If

    End Sub

    Private Sub mmdDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdDelRow.Click
        rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("Del") = "Y"
        chkDel.Checked = True

        ''Dim locHKD As Integer
        ''locHKD = 0
        ''If Me.cboFCurr.Text <> "HKD" Then
        ''    locHKD = 1
        ''Else
        ''    locHKD = 0
        ''End If

        ''Dim delLoc As Integer
        ''delLoc = 0

        ''If rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count >= 5 + locHKD Then
        ''    If dgSHCHGDTL_CORE.CurrentCell.RowIndex >= locHKD + 2 And dgSHCHGDTL_CORE.CurrentCell.RowIndex < dgSHCHGDTL_CORE.Rows.Count - 2 - locHKD Then
        ''        delLoc = dgSHCHGDTL_CORE.CurrentCell.RowIndex
        ''    End If
        ''End If

        ''If delLoc > 0 Then
        ''    rs_SHCHGDTL_CORE.Tables("RESULT").Rows(delLoc).Item("MANCBM") = "0"
        ''    changeManualCBM = True
        ''    calculate_dgSHCHGDTL_CORE_flag = True
        ''    Call calculate_dgSHCHGDTL_CORE("MANCBM")
        ''End If


        'If btcSHM00007.SelectedIndex = 2 Then
        'Insert_flag = False
        'Call reset_and_display_dgSHCHGDTL_CORE()
        'End If
    End Sub




    Private Sub lstVendor_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstVendor.DoubleClick
        lstVendor.Visible = False
        Dim venno As String
        Dim vennam As String
        venno = Split(lstVendor.Text, " - ")(0)
        If venno = "UCP" _
           Or venno = "UCPP" _
           Or venno = "HX" _
           Or venno = "PG" _
           Or venno = "TT" _
           Or venno = "EW" _
       Then
            vennam = venno
        Else
            vennam = Split(lstVendor.Text, " - ")(1)
        End If

        If rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fcurcde") <> "HKD" Then
            rs_SHCHGDTL_CORE.Tables("RESULT").Rows(rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - 4).Item("VENDOR") = vennam
            rs_SHCHGDTL_CORE.Tables("RESULT").Rows(rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - 4).Item("VENCDE") = venno
        Else
            rs_SHCHGDTL_CORE.Tables("RESULT").Rows(rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - 3).Item("VENDOR") = vennam
            rs_SHCHGDTL_CORE.Tables("RESULT").Rows(rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - 3).Item("VENCDE") = venno
        End If

        dsNewRow = rs_SHIPGDTL_CTNETD.Tables("RESULT").NewRow()

        dsNewRow.Item("tmp_fwdnam") = rs_SHCHGFWD.Tables("result").Rows(ReadingIndex)("scf_fwdnam")
        dsNewRow.Item("tmp_vbi_vensna") = vennam
        dsNewRow.Item("tmp_vbi_venno") = venno
        dsNewRow.Item("tmp_creusr") = "~*ADD*~"
        dsNewRow.Item("tmp_mancbm") = 0

        rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows.Add(dsNewRow)


    End Sub

    Private Sub display_lstVendor(ByVal rowcount As Integer)
        lstVendor.Visible = True
        lstVendor.BringToFront()

        lstVendor.Top = dgSHCHGDTL_CORE.Item(0, 0).DataGridView.Top + dgSHCHGDTL_CORE.Item(0, 0).DataGridView.ColumnHeadersHeight + dgSHCHGDTL_CORE.RowTemplate.Height * rowcount
        lstVendor.Left = dgSHCHGDTL_CORE.Item(0, 0).DataGridView.Left + dgSHCHGDTL_CORE.Item(0, 0).DataGridView.RowHeadersWidth
    End Sub

    Private Function check_SHCHGHDR_SHCHGDTL() As Boolean
        If Me.rbDocTyp_C.Checked = False And Me.rbDocTyp_D.Checked = False Then
            MsgBox("Document Type cannot empty!")
            check_SHCHGHDR_SHCHGDTL = False
            Exit Function
        End If
        If rbDocTyp_C.Checked = True Then
            If Me.txtCtn.Text = "" Then
                MsgBox("Container Number cannot empty!")
                Me.txtCtn.Focus()
                check_SHCHGHDR_SHCHGDTL = False
                Exit Function
            End If

            If Me.mskETDDat.Text = "  /  /" Then
                MsgBox("Container Number cannot empty!")
                Me.mskETDDat.Focus()
                check_SHCHGHDR_SHCHGDTL = False
                Exit Function
            End If

            If Me.cboCtnSiz.Text = "" Then
                MsgBox("Container Size cannot empty!")
                Me.cboCtnSiz.Focus()
                check_SHCHGHDR_SHCHGDTL = False
                Exit Function
            End If


        End If




        For i As Integer = 0 To rs_SHCHGFWD.Tables("result").Rows.Count - 1

            If rs_SHCHGFWD.Tables("result").Rows(i).Item("scf_fwdinv") = "" Then
                MsgBox("Forwarder Invoice cannot empty!")
                display_fwd(rs_SHCHGFWD.Tables("result").Rows(i).Item("scf_fwdnam"))
                reset_and_display_SHCHGDTL(rs_SHCHGFWD.Tables("result").Rows(i).Item("scf_fwdnam"))

                ''''''''''''' reset_and_display_SHCHGDTL
                ''''''''''''' reset_and_display_SHCHGDTL

                btcSHM00007.SelectedIndex = 1
                txtFwdInv.Focus()
                check_SHCHGHDR_SHCHGDTL = False
                Exit Function
            End If

            'If rs_SHCHGFWD.Tables("result").Rows(i).Item("scf_fcrno") = "" Then
            '    MsgBox("FCR No cannot empty!")
            '    display_fwd(rs_SHCHGFWD.Tables("result").Rows(i).Item("scf_fwdnam"))
            '    btcSHM00007.SelectedIndex = 1
            '    Me.cbofcrno.Focus()
            '    check_SHCHGHDR_SHCHGDTL = False
            '    Exit Function

            'End If
        Next


        'If Me.cbofwdnam.Text = "" Then
        '    MsgBox("Forwarder Name cannot empty!")
        '    Me.cbofwdnam.Focus()
        '    check_SHCHGHDR_SHCHGDTL = False
        '    Exit Function
        'End If

        'If txtFwdInv.Text.Trim = "" Then
        '    MsgBox("Forwarder Invoice cannot empty!")
        '    Me.cbofcrno.Focus()
        '    check_SHCHGHDR_SHCHGDTL = False
        '    Exit Function
        'End If

        'If Me.cbofcrno.Text = "" Then
        '    MsgBox("FCR No cannot empty!")
        '    Me.cbofcrno.Focus()
        '    check_SHCHGHDR_SHCHGDTL = False
        '    Exit Function
        'End If

        'If rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fcurcde") = "" Then
        '    MsgBox("Forwarder Currency cannot empty!")
        '    Me.cboFCurr.Focus()
        '    check_SHCHGHDR_SHCHGDTL = False
        '    Exit Function
        'End If

        'If Me.cboBCurr.Text = "" Then
        '    MsgBox("Base Currency cannot empty!")
        '    Me.cboBCurr.Focus()
        '    check_SHCHGHDR_SHCHGDTL = False
        '    Exit Function
        'End If

        'If Me.mskExchRat.Text = " ." Then
        '    MsgBox("Exchange Rate cannot empty!")
        '    Me.mskExchRat.Focus()
        '    check_SHCHGHDR_SHCHGDTL = False
        '    Exit Function
        'End If

        ''If rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Count = 0 Then
        ''    MsgBox("SHCHGDTL Distribute cannot empty!")
        ''    check_SHCHGHDR_SHCHGDTL = False
        ''    Exit Function
        ''End If

        ''If rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Count > 0 Then
        ''    If rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(0).Item("TOTAL") = 0 Then
        ''        MsgBox("SHCHGDTL Distribute CNY/HKD total is 0!")
        ''        check_SHCHGHDR_SHCHGDTL = False
        ''        Exit Function
        ''    End If
        ''End If

        ''If rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count = 0 Then
        ''    MsgBox("SHCHGDTL CORE cannot empty!")
        ''    check_SHCHGHDR_SHCHGDTL = False
        ''    Exit Function
        ''End If

        'Check for no vendor detail
        ''If rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fcurcde") <> "HKD" Then
        ''    If rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count < 6 Then
        ''        MsgBox("No Vendor Detail CNY!")
        ''        check_SHCHGHDR_SHCHGDTL = False
        ''        Exit Function
        ''    End If
        ''Else
        ''    If rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count < 4 Then
        ''        MsgBox("No Vendor Detail HKD!")
        ''        check_SHCHGHDR_SHCHGDTL = False
        ''        Exit Function
        ''    End If
        ''End If



        check_SHCHGHDR_SHCHGDTL = True
    End Function

    Private Function save_SHCHGHDR(ByRef rtnDocNo As String) As Boolean
        Dim sDocNo As String
        sDocNo = ""

        If Add_flag = True Then
            gspStr = "sp_select_DOC_GEN 'SHCHG','SH','" & gsUsrID & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_DOC_GEN, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SHM00007 #005 sp_select_DOC_GEN : " & rtnStr)
                save_SHCHGHDR = False
                Exit Function
            End If

            sDocNo = rs_DOC_GEN.Tables("RESULT").Rows(0).Item(0)
            sDocNo = Mid(sDocNo, 1, 2) & Year(Today) & Mid(sDocNo, 5, 5)
        ElseIf Upd_flag = True Then
            'temp
            sDocNo = Me.txtdocno.Text
        End If


        Dim SCH_DOCNO As String
        Dim SCH_TYP As String
        Dim SCH_STS As String
        Dim SCH_FWDNAM As String
        Dim SCH_FWDINV As String
        Dim SCH_FCRNO As String
        Dim SCH_FCURCDE As String
        Dim SCH_CURCDE As String
        Dim SCH_EXCHRAT As String
        Dim SCH_PCKDAT As String
        Dim SCH_CTRCFS As String
        Dim SCH_CTRSIZ As String
        Dim SCH_INVLST As String
        Dim SCH_CUSLST As String
        Dim SCH_CUSNOLST As String
        Dim SCH_ETDDAT As String
        Dim SCH_RMK As String


        SCH_DOCNO = sDocNo
        If Me.rbDocTyp_C.Checked = True Then
            SCH_TYP = "C"
        Else
            SCH_TYP = "D"
        End If

        If Add_flag = True Then
            SCH_STS = "OPE"
        ElseIf Upd_flag = True Then
            SCH_STS = Me.txtStatus.Text
        Else
            SCH_STS = ""
        End If

        'SCH_FWDNAM = Replace(Me.cbofwdnam.Text, "'", "''")
        'SCH_FWDINV = Replace(Me.cbofcrno.Text, "'", "''")
        'SCH_FCRNO = Replace(Me.cbofcrno.Text, "'", "''")
        'SCH_FCURCDE = Replace(Me.cboFCurr.Text, "'", "''")
        SCH_CURCDE = Replace(Me.cboBCurr.Text, "'", "''")
        SCH_EXCHRAT = Replace(Me.mskExchRat.Text, "'", "''")
        SCH_PCKDAT = Replace(Me.mskPckDat.Text, "'", "''")
        SCH_CTRCFS = Replace(Me.txtCtn.Text, "'", "''")
        SCH_CTRSIZ = Replace(Me.cboCtnSiz.Text, "'", "''")
        SCH_INVLST = Replace(Me.txtInvNoList.Text, "'", "''")
        SCH_CUSLST = Replace(Me.txtCustList.Text, "'", "''")
        SCH_CUSNOLST = Replace(Me.txtCusNoList.Text, "'", "''")
        SCH_ETDDAT = Replace(Me.mskETDDat.Text, "'", "''")
        SCH_RMK = Replace(Me.rtxtRmk.Text, "'", "''")


        If Add_flag = True Then
            'temp
            gspStr = "sp_insert_SHCHGHDR '','" & SCH_DOCNO & "','" & SCH_TYP & "','" & SCH_STS & "','" & SCH_CURCDE & "','" & SCH_EXCHRAT & "','" & SCH_PCKDAT & "','" & SCH_CTRCFS & "','" & SCH_CTRSIZ & "','" & SCH_INVLST & "','" & SCH_CUSLST & "','" & SCH_CUSNOLST & "','" & SCH_ETDDAT & "','" & SCH_RMK & "','" & gsUsrID & "'"

            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SHM00007 #006 sp_insert_SHCHGHDR : " & rtnStr)
                save_SHCHGHDR = False
                Exit Function
            End If
        Else
            'temp 2015
            'ElseIf upd_flag_A(ReadingIndex) = True Then

            gspStr = "sp_update_SHCHGHDR '','" & SCH_DOCNO & "','" & SCH_TYP & "','" & SCH_STS & "','" & SCH_CURCDE & "','" & SCH_EXCHRAT & "','" & SCH_PCKDAT & "','" & SCH_CTRCFS & "','" & SCH_CTRSIZ & "','" & SCH_INVLST & "','" & SCH_CUSLST & "','" & SCH_CUSNOLST & "','" & SCH_ETDDAT & "','" & SCH_RMK & "','" & gsUsrID & "'"

            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SHM00007 #011 sp_update_SHCHGHDR : " & rtnStr)
                save_SHCHGHDR = False
                Exit Function
            End If

        End If


        Dim scf_docno As String
        Dim scf_fwdnam As String
        Dim scf_fwdinv As String
        Dim scf_fcrno As String
        Dim scf_fcurcde As String
        Dim scf_exrate As String
        Dim scf_rmk As String
        Dim scf_ttlamt As Decimal
        Dim scf_CREUSR As String

        Dim i As Integer

        For i = 0 To rs_SHCHGFWD.Tables("RESULT").Rows.Count - 1

            scf_docno = SCH_DOCNO
            scf_fwdnam = rs_SHCHGFWD.Tables("RESULT").Rows(i).Item("scf_fwdnam")
            scf_fwdnam = Replace(scf_fwdnam, "'", "''")

            scf_fwdinv = rs_SHCHGFWD.Tables("RESULT").Rows(i).Item("scf_fwdinv")
            scf_fcrno = rs_SHCHGFWD.Tables("RESULT").Rows(i).Item("scf_fcrno")
            scf_fcurcde = rs_SHCHGFWD.Tables("RESULT").Rows(i).Item("scf_fcurcde")
            scf_exrate = rs_SHCHGFWD.Tables("RESULT").Rows(i).Item("scf_exrate")

            scf_rmk = rs_SHCHGFWD.Tables("RESULT").Rows(i).Item("scf_rmk")
            scf_rmk = Replace(scf_rmk, "'", "''")

            If IsDBNull(rs_SHCHGFWD.Tables("RESULT").Rows(i).Item("scf_ttlamt")) Then
                Call reset_and_display_SHCHGDTL(rs_SHCHGFWD.Tables("RESULT").Rows(i).Item("scf_fwdnam"))
            End If
            If IsDBNull(rs_SHCHGFWD.Tables("RESULT").Rows(i).Item("scf_ttlamt")) Then
                scf_ttlamt = 0
            Else
                scf_ttlamt = rs_SHCHGFWD.Tables("RESULT").Rows(i).Item("scf_ttlamt")
            End If
            scf_CREUSR = rs_SHCHGFWD.Tables("RESULT").Rows(i).Item("scf_CREUSR")

            gspStr = ""

            If rs_SHCHGFWD.Tables("RESULT").Rows(i)("Del") = "Y" Then
                scf_CREUSR = "~*DEL*~"
            End If
            If scf_CREUSR = "~*DEL*~" Then

                gspStr = "sp_physical_delete_SHCHGFWD '', '" & _
                                                 scf_docno & "','" & _
                                     scf_fwdnam & "'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_Shchghdr sp_physical_delete_SHCHGFWD:" & rtnStr)
                    save_SHCHGHDR = False
                    Exit Function
                End If


            ElseIf scf_CREUSR = "~*ADD*~" Or scf_CREUSR = "~*NEW*~" Or Add_flag_A(i) = True Then

                gspStr = "sp_insert_SHCHGFWD '" & _
                                                 scf_docno & "','" & _
                                                 scf_fwdnam & "','" & _
                                                 scf_fwdinv & "','" & _
                                                 scf_fcrno & "','" & _
                                                 scf_fcurcde & "','" & _
                                                 scf_exrate & "','" & _
                                                 scf_rmk & "'," & _
                                                 scf_ttlamt & ",'" & _
                                                gsUsrID & "'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_Shchghdr sp_insert_SHCHGFWD :" & rtnStr & "   Seq:" & scf_fwdinv)
                    save_SHCHGHDR = False
                    Exit Function
                End If

            ElseIf scf_CREUSR = "~*UPD*~" Or upd_flag_A(i) = True Then

                gspStr = "sp_update_SHCHGFWD '" & _
                                          scf_docno & "','" & _
                                          scf_fwdnam & "','" & _
                                          scf_fwdinv & "','" & _
                                          scf_fcrno & "','" & _
                                          scf_fcurcde & "','" & _
                                                 scf_exrate & "','" & _
                                                 scf_rmk & "'," & _
                                                 scf_ttlamt & ",'" & _
                                         gsUsrID & "'"


                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)

                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_Shchghdr sp_update_SHCHGFWD :" & rtnStr & "   Seq:" & scf_fwdinv)
                    save_SHCHGHDR = False
                    Exit Function
                End If

            End If

        Next i
        'fwd


        Dim scd_docno As String
        Dim scd_fwdnam As String
        Dim scd_venno As String
        Dim scd_chgcde As String
        Dim scd_syscbm As String
        Dim scd_mancbm As String
        Dim scd_curcde As String
        Dim scd_fee As String
        Dim scd_CREUSR As String


        For i = 0 To rs_SHCHGDTL.Tables("RESULT").Rows.Count - 1

            scd_docno = SCH_DOCNO
            scd_fwdnam = rs_SHCHGDTL.Tables("RESULT").Rows(i).Item("scd_fwdnam")

            scd_venno = rs_SHCHGDTL.Tables("RESULT").Rows(i).Item("scd_venno")
            scd_chgcde = rs_SHCHGDTL.Tables("RESULT").Rows(i).Item("scd_chgcde")
            scd_syscbm = rs_SHCHGDTL.Tables("RESULT").Rows(i).Item("scd_syscbm")
            scd_mancbm = rs_SHCHGDTL.Tables("RESULT").Rows(i).Item("scd_mancbm")

            scd_curcde = rs_SHCHGDTL.Tables("RESULT").Rows(i).Item("scd_curcde")
            scd_fee = rs_SHCHGDTL.Tables("RESULT").Rows(i).Item("scd_fee")

            scd_CREUSR = rs_SHCHGDTL.Tables("RESULT").Rows(i).Item("scd_CREUSR")
            scd_CREUSR = check_dtl_row(scd_fwdnam, scd_venno, scd_chgcde, scd_syscbm, scd_mancbm, scd_curcde, scd_fee, scd_CREUSR)

            gspStr = ""


            'ad one checking with loaded, if find, then *UPD
            sFilter = "scf_fwdnam = '" & rs_SHCHGDTL.Tables("RESULT").Rows(i).Item("scd_fwdnam") & "'"
            rs_SHCHGFWD.Tables("RESULT").DefaultView.RowFilter = sFilter

            If rs_SHCHGFWD.Tables("RESULT").DefaultView(0)("DEL") = "Y" Then
                scd_CREUSR = "~*DEL*~"
            End If
            If scd_curcde = "" Then
                scd_CREUSR = "~*DEL*~"
            End If

            scd_fwdnam = Replace(scd_fwdnam, "'", "''")


            If scd_CREUSR = "~*DEL*~" Then

                gspStr = "sp_physical_delete_SHCHGDTL '','" & _
                                 scd_docno & "','" & _
                                 scd_fwdnam & "','" & _
                                 scd_venno & "','" & _
                                 scd_chgcde & "','" & _
                                     scd_curcde & "'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_Shchghdr sp_physical_delete_SHCHGDTL:" & rtnStr)
                    save_SHCHGHDR = False
                    Exit Function
                End If


            ElseIf scd_CREUSR = "~*ADD*~" Or scd_CREUSR = "~*NEW*~" Then

                gspStr = "sp_insert_SHCHGDTL '','" & _
                                                 scd_docno & "','" & _
                                                 scd_fwdnam & "','" & _
                                                 scd_venno & "','" & _
                                                 scd_chgcde & "','" & _
                                                 scd_syscbm & "','" & _
                                                 scd_mancbm & "','" & _
                                                 scd_curcde & "','" & _
                                                 scd_fee & "','" & _
                                                 gsUsrID & "'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_Shchghdr sp_insert_SHCHGDTL :" & rtnStr & "   Seq:" & scd_venno)
                    save_SHCHGHDR = False
                    Exit Function
                End If

            ElseIf scd_CREUSR = "~*UPD*~" Then

                gspStr = "sp_update_SHCHGDTL '','" & _
                                          scd_docno & "','" & _
                                          scd_fwdnam & "','" & _
                                          scd_venno & "','" & _
                                          scd_chgcde & "','" & _
                                          scd_syscbm & "','" & _
                                          scd_mancbm & "','" & _
                                          scd_curcde & "','" & _
                                          scd_fee & "','" & _
                                          gsUsrID & "'"


                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)

                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_Shchghdr sp_update_SHCHGDTL :" & rtnStr & "   Seq:" & scd_venno)
                    save_SHCHGHDR = False
                    Exit Function
                End If

            End If

        Next i
        'dtl

        ''Dim scf_docno As String
        ''Dim scf_fwdnam As String
        ''Dim scf_fwdinv As String
        ''Dim scf_fcrno As String
        ''Dim scf_fcurcde As String
        ''Dim scf_rmk As String
        ''Dim scf_creusr As String
        ''Dim scf_updusr As String
        ''Dim scf_credat As String
        ''Dim scf_upddat As String



        ''If Add_flag_A(readingindex) = True Then
        ''    gspStr = "sp_insert_SHCHGFWD '','" & scf_docno & "','" & scf_fwdnam & "','" & scf_fwdinv & "','" & scf_fcrno & "','" & scf_fcurcde & "','" & scf_rmk & "','" & gsUsrID & "'"

        ''    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        ''    If rtnLong <> RC_SUCCESS Then
        ''        MsgBox("Error on loading SHM00007 #006 sp_insert_SHCHGFWD : " & rtnStr)
        ''        save_SHCHGHDR = False
        ''        Exit Function
        ''    End If

        ''ElseIf Upd_flag_A(readingindex) = True Then

        ''    gspStr = "sp_update_SHCHGFWD '','" & scf_docno & "','" & scf_fwdnam & "','" & scf_fwdinv & "','" & scf_fcrno & "','" & scf_fcurcde & "','" & scf_rmk & "','" & gsUsrID & "'"

        ''    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        ''    If rtnLong <> RC_SUCCESS Then
        ''        MsgBox("Error on loading SHM00007 #011 sp_update_SHCHGFWD : " & rtnStr)
        ''        save_SHCHGHDR = False
        ''        Exit Function
        ''    End If

        ''End If










        'Dim SCD_DOCNO As String
        'Dim SCD_VENNO As String
        'Dim SCD_CHGCDE As String
        'Dim SCD_SYSCBM As String
        'Dim SCD_MANCBM As String
        'Dim SCD_CURCDE As String
        'Dim SCD_FEE As String
        'Dim SCD_FEE_UPD As String
        'Dim SCD_FN As String

        'Dim SCD_MANCBM_UPD As String

        'SCD_DOCNO = ""
        'SCD_VENNO = ""
        'SCD_CHGCDE = ""
        'SCD_SYSCBM = ""
        'SCD_MANCBM = ""
        'SCD_CURCDE = ""
        'SCD_FEE = ""
        'SCD_FEE_UPD = ""

        'SCD_MANCBM_UPD = ""

        'Dim i As Integer
        'Dim j As Integer



        'Dim rowspace As Integer
        'Dim locHKD As Integer
        'rowspace = 0
        'locHKD = 0

        'If Me.cboFCurr.Text <> "HKD" Then
        '    rowspace = 3
        '    locHKD = 1
        'Else
        '    rowspace = 2
        '    locHKD = 0
        'End If

        'For i = 0 To rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - rowspace - 1
        '    SCD_DOCNO = SCH_DOCNO

        '    ' Save Manual Total
        '    If i < rowspace Then
        '        SCD_VENNO = "TOTAL"
        '        For j = 0 To rs_SYMSHC_D.Tables("RESULT").Rows.Count - 1
        '            SCD_SYSCBM = rs_SHCHGDTL_CORE.Tables("RESULT").Rows(rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - locHKD - 1).Item("SYSCBM")
        '            SCD_MANCBM = rs_SHCHGDTL_CORE.Tables("RESULT").Rows(rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - locHKD - 1).Item("MANCBM")
        '            SCD_CURCDE = ""
        '            If Me.cboFCurr.Text <> "HKD" And i = 0 Then
        '                SCD_CURCDE <> "HKD"
        '            Else
        '                SCD_CURCDE = "HKD"
        '            End If
        '            SCD_CHGCDE = rs_SYMSHC_D.Tables("RESULT").Rows(j).Item("ysc_chgcde")
        '            If IsNumeric(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item(SCD_CHGCDE)) Then
        '                SCD_FEE = rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item(SCD_CHGCDE)
        '            Else
        '                SCD_FEE = ""
        '            End If

        '            If SCD_FEE <> "" Then
        '                If Add_flag_A(ReadingIndex) = True Then
        '                    gspStr = "sp_insert_SHCHGDTL '','" & SCD_DOCNO & "','" & SCD_FN & "','" & SCD_VENNO & "','" & SCD_CHGCDE & "','" & SCD_SYSCBM & "','" & SCD_MANCBM & "','" & SCD_CURCDE & "','" & SCD_FEE & "','" & gsUsrID & "'"

        '                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        '                    If rtnLong <> RC_SUCCESS Then
        '                        MsgBox("Error on loading SHM00007 #007a sp_insert_SHCHGDTL : " & rtnStr)
        '                        save_SHCHGHDR = False
        '                        Exit Function
        '                    End If
        '                ElseIf upd_flag_A(ReadingIndex) = True Then
        '                    SCD_FEE_UPD = search_SHCHGDTL_By_Vendor_ChgCde_Curr(SCD_VENNO, SCD_CHGCDE, SCD_CURCDE)
        '                    SCD_MANCBM_UPD = search_SHCHGDTL_MANCBM_By_Vendor_ChgCde_Curr(SCD_VENNO, SCD_CHGCDE, SCD_CURCDE)
        '                    If SCD_FEE_UPD = 0 Then
        '                        gspStr = "sp_insert_SHCHGDTL '','" & SCD_DOCNO & "','" & SCD_FN & "','" & SCD_VENNO & "','" & SCD_CHGCDE & "','" & SCD_SYSCBM & "','" & SCD_MANCBM & "','" & SCD_CURCDE & "','" & SCD_FEE & "','" & gsUsrID & "'"

        '                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        '                        If rtnLong <> RC_SUCCESS Then
        '                            MsgBox("Error on loading SHM00007 #012 sp_insert_SHCHGDTL : " & rtnStr)
        '                            save_SHCHGHDR = False
        '                            Exit Function
        '                        End If
        '                    ElseIf SCD_FEE <> SCD_FEE_UPD Then
        '                        If SCD_FEE = "" And SCD_FEE_UPD <> 0 Then
        '                            'del
        '                            gspStr = "sp_physical_delete_SHCHGDTL '','" & SCD_DOCNO & "','" & SCD_VENNO & "','" & SCD_CHGCDE & "','" & SCD_CURCDE & "'"

        '                            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        '                            If rtnLong <> RC_SUCCESS Then
        '                                MsgBox("Error on loading SHM00007 #013 sp_physical_delete_SHCHGDTL : " & rtnStr)
        '                                save_SHCHGHDR = False
        '                                Exit Function
        '                            End If

        '                        Else
        '                            'upd
        '                            gspStr = "sp_update_SHCHGDTL '','" & SCD_DOCNO & "','" & SCD_FN & "','" & SCD_VENNO & "','" & SCD_CHGCDE & "','" & SCD_SYSCBM & "','" & SCD_MANCBM & "','" & SCD_CURCDE & "','" & SCD_FEE & "','" & gsUsrID & "'"

        '                            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        '                            If rtnLong <> RC_SUCCESS Then
        '                                MsgBox("Error on loading SHM00007 #014 sp_update_SHCHGDTL : " & rtnStr)
        '                                save_SHCHGHDR = False
        '                                Exit Function
        '                            End If
        '                        End If
        '                    ElseIf SCD_MANCBM <> SCD_MANCBM_UPD Then
        '                        'upd
        '                        gspStr = "sp_update_SHCHGDTL '','" & SCD_DOCNO & "','" & SCD_FN & "','" & SCD_VENNO & "','" & SCD_CHGCDE & "','" & SCD_SYSCBM & "','" & SCD_MANCBM & "','" & SCD_CURCDE & "','" & SCD_FEE & "','" & gsUsrID & "'"

        '                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        '                        If rtnLong <> RC_SUCCESS Then
        '                            MsgBox("Error on loading SHM00007 #014e sp_update_SHCHGDTL : " & rtnStr)
        '                            save_SHCHGHDR = False
        '                            Exit Function
        '                        End If
        '                    End If
        '                End If
        '            End If
        '        Next j
        '    Else
        '        SCD_VENNO = rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item("VENCDE")
        '        If SCD_VENNO <> "" Then
        '            If IsNumeric(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item("SYSCBM")) Then
        '                SCD_SYSCBM = rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item("SYSCBM")
        '            Else
        '                SCD_SYSCBM = "0"
        '            End If
        '            If IsNumeric(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item("MANCBM")) Then
        '                SCD_MANCBM = rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item("MANCBM")
        '            Else
        '                SCD_MANCBM = "0"
        '            End If

        '            SCD_CURCDE = Me.cboBCurr.Text

        '            For j = 0 To rs_SYMSHC_ALL.Tables("RESULT").Rows.Count - 1
        '                SCD_CHGCDE = rs_SYMSHC_ALL.Tables("RESULT").Rows(j).Item("ysc_chgcde")
        '                If IsNumeric(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item(SCD_CHGCDE)) Then
        '                    SCD_FEE = rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item(SCD_CHGCDE)
        '                Else
        '                    SCD_FEE = "0"
        '                End If
        '                If SCD_FEE <> "0" Then
        '                    If Add_flag_A(ReadingIndex) = True Then
        '                        gspStr = "sp_insert_SHCHGDTL '','" & SCD_DOCNO & "','" & SCD_FN & "','" & SCD_VENNO & "','" & SCD_CHGCDE & "','" & SCD_SYSCBM & "','" & SCD_MANCBM & "','" & SCD_CURCDE & "','" & SCD_FEE & "','" & gsUsrID & "'"

        '                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        '                        If rtnLong <> RC_SUCCESS Then
        '                            MsgBox("Error on loading SHM00007 #007b sp_insert_SHCHGDTL : " & rtnStr)
        '                            save_SHCHGHDR = False
        '                            Exit Function
        '                        End If
        '                    ElseIf upd_flag_A(ReadingIndex) = True Then
        '                        SCD_FEE_UPD = search_SHCHGDTL_By_Vendor_ChgCde_Curr(SCD_VENNO, SCD_CHGCDE, SCD_CURCDE)
        '                        SCD_MANCBM_UPD = search_SHCHGDTL_MANCBM_By_Vendor_ChgCde_Curr(SCD_VENNO, SCD_CHGCDE, SCD_CURCDE)
        '                        If SCD_FEE_UPD = 0 Then
        '                            gspStr = "sp_insert_SHCHGDTL '','" & SCD_DOCNO & "','" & SCD_FN & "','" & SCD_VENNO & "','" & SCD_CHGCDE & "','" & SCD_SYSCBM & "','" & SCD_MANCBM & "','" & SCD_CURCDE & "','" & SCD_FEE & "','" & gsUsrID & "'"

        '                            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        '                            If rtnLong <> RC_SUCCESS Then
        '                                MsgBox("Error on loading SHM00007 #015 sp_insert_SHCHGDTL : " & rtnStr)
        '                                save_SHCHGHDR = False
        '                                Exit Function
        '                            End If
        '                        ElseIf SCD_FEE <> SCD_FEE_UPD Then
        '                            If SCD_FEE = "0" And SCD_FEE_UPD <> 0 Then
        '                                'del
        '                                gspStr = "sp_physical_delete_SHCHGDTL '','" & SCD_DOCNO & "','" & SCD_VENNO & "','" & SCD_CHGCDE & "','" & SCD_CURCDE & "'"

        '                                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        '                                If rtnLong <> RC_SUCCESS Then
        '                                    MsgBox("Error on loading SHM00007 #016 sp_physical_delete_SHCHGDTL : " & rtnStr)
        '                                    save_SHCHGHDR = False
        '                                    Exit Function
        '                                End If

        '                            Else
        '                                'upd
        '                                gspStr = "sp_update_SHCHGDTL '','" & SCD_DOCNO & "','" & SCD_FN & "','" & SCD_VENNO & "','" & SCD_CHGCDE & "','" & SCD_SYSCBM & "','" & SCD_MANCBM & "','" & SCD_CURCDE & "','" & SCD_FEE & "','" & gsUsrID & "'"

        '                                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        '                                If rtnLong <> RC_SUCCESS Then
        '                                    MsgBox("Error on loading SHM00007 #017 sp_update_SHCHGDTL : " & rtnStr)
        '                                    save_SHCHGHDR = False
        '                                    Exit Function
        '                                End If
        '                            End If
        '                        ElseIf SCD_MANCBM <> SCD_MANCBM_UPD Then
        '                            'upd
        '                            gspStr = "sp_update_SHCHGDTL '','" & SCD_DOCNO & "','" & SCD_FN & "','" & SCD_VENNO & "','" & SCD_CHGCDE & "','" & SCD_SYSCBM & "','" & SCD_MANCBM & "','" & SCD_CURCDE & "','" & SCD_FEE & "','" & gsUsrID & "'"

        '                            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        '                            If rtnLong <> RC_SUCCESS Then
        '                                MsgBox("Error on loading SHM00007 #014e sp_update_SHCHGDTL : " & rtnStr)
        '                                save_SHCHGHDR = False
        '                                Exit Function
        '                            End If
        '                        End If
        '                    End If
        '                Else
        '                    gspStr = "sp_physical_delete_SHCHGDTL '','" & SCD_DOCNO & "','" & SCD_VENNO & "','" & SCD_CHGCDE & "','" & SCD_CURCDE & "'"

        '                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        '                    If rtnLong <> RC_SUCCESS Then
        '                        MsgBox("Error on loading SHM00007 #016c sp_physical_delete_SHCHGDTL : " & rtnStr)
        '                        save_SHCHGHDR = False
        '                        Exit Function
        '                    End If

        '                End If
        '            Next j
        '        End If
        '    End If
        'Next i

        rtnDocNo = sDocNo
        save_SHCHGHDR = True
    End Function


    Private Sub mmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdFind.Click
        Cursor = Cursors.WaitCursor

        flag_cmdFind_Click = True

        If Me.txtdocno.Text = "" Then
            MsgBox("Please enter Document No")
            Me.txtdocno.SelectAll()
            Me.txtdocno.Focus()
            Exit Sub
        End If
        If Len(Me.txtdocno.Text) <> 11 Then
            MsgBox("Invalid Document No")
            Me.txtdocno.SelectAll()
            Me.txtdocno.Focus()
            Exit Sub
        End If


        gspStr = "sp_select_SHCHGHDR '','" & Me.txtdocno.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SHCHGHDR, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SHM00007 #008 sp_select_SHCHGHDR : " & rtnStr)
            Exit Sub
        End If

        If rs_SHCHGHDR.Tables.Count = 0 Then
            MsgBox("Record not found!")
            Me.txtdocno.SelectAll()
            Me.txtdocno.Focus()
            Exit Sub
        End If

        If rs_SHCHGHDR.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("Record not found!")
            Me.txtdocno.SelectAll()
            Me.txtdocno.Focus()
            Exit Sub
        End If

        gspStr = "sp_select_SHCHGDTL '','" & Me.txtdocno.Text & "','ALL',''"
        rtnLong = execute_SQLStatement(gspStr, rs_SHCHGDTL, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SHM00007 #009 sp_select_SHCHGDTL : " & rtnStr)
            Exit Sub
        Else
            rs_SHCHGDTL_org = rs_SHCHGDTL.Copy
        End If


        '        gspStr = "sp_select_SHCHGFWD '','" & Me.txtdocno.Text & "','ALL',''"
        gspStr = "sp_select_SHCHGFWD '','" & Me.txtdocno.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SHCHGFWD, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SHM00007 #009 sp_select_SHCHGFWD : " & rtnStr)
            Exit Sub
        Else
            For j As Integer = 0 To rs_SHCHGFWD.Tables("RESULT").Columns.Count - 1
                rs_SHCHGFWD.Tables("RESULT").Columns(j).ReadOnly = False
            Next

        End If

        Dim ttlrecord As Integer
        ttlrecord = rs_SHCHGFWD.Tables("result").Rows.Count
        ReDim Preserve Add_flag_A(ttlrecord)
        ReDim Preserve upd_flag_A(ttlrecord)
        For index9 As Integer = 0 To UBound(Add_flag_A)
            Add_flag_A(index9) = False
        Next
        For index99 As Integer = 0 To UBound(upd_flag_A)
            upd_flag_A(index99) = False
        Next

        For index999 As Integer = 0 To ttlrecord - 1
            flag_sub_value_change(index999) = True
        Next


        Dim fn As String
        If rs_SHCHGFWD.Tables("RESULT").Rows.Count >= 1 Then
            fn = rs_SHCHGFWD.Tables("RESULT").Rows(0).Item("scf_fwdnam")
        Else
            fn = ""
        End If

        Call display_SHCHGHDR()


        Dim dtl_fwd_A() As String
        Dim flag_found_fwd As Boolean

        For index99 As Integer = 0 To rs_SHCHGDTL.Tables("RESULT").Rows.Count - 1

            flag_found_fwd = False
            If Not dtl_fwd_A Is Nothing Then
                For index9 As Integer = 0 To UBound(dtl_fwd_A)
                    If dtl_fwd_A(index9) = rs_SHCHGDTL.Tables("RESULT").Rows(index99)("scd_fwdnam") Then
                        flag_found_fwd = True
                    End If
                Next
            End If

            If flag_found_fwd = False Then

                If dtl_fwd_A Is Nothing Then
                    ReDim Preserve dtl_fwd_A(0)
                Else
                    ReDim Preserve dtl_fwd_A(UBound(dtl_fwd_A) + 1)
                End If


                dtl_fwd_A(UBound(dtl_fwd_A)) = rs_SHCHGDTL.Tables("RESULT").Rows(index99)("scd_fwdnam")
            End If

        Next
        If Not dtl_fwd_A Is Nothing Then
            For index99 As Integer = 0 To UBound(dtl_fwd_A)
                Call load_and_fill_ctnetd_each_fwd(dtl_fwd_A(index99))
            Next
        End If




        Call format_cbofwd()
        Call display_dgSHCHGFWD()


        For index9 As Integer = 0 To rs_SHCHGFWD.Tables("RESULT").Rows.Count - 1
            If Not IsDBNull(rs_SHCHGFWD.Tables("RESULT").Rows(index9)("scf_fwdnam")) Then
                If rs_SHCHGFWD.Tables("RESULT").Rows(index9)("scf_fwdnam") = fn Then
                    ReadingIndex = index9
                End If
            End If
        Next

        Call display_fwd(fn)
        cbofwd.Text = fn

        Call reset_and_display_SHCHGDTL(cbofwd.Text.Trim)
        'If display_dgSHCHGDTL_Distribute(cbofwd.Text.Trim) = False Then
        '    MsgBox("Please input fees!")
        '    Exit Sub
        'End If


        For index9 As Integer = 0 To rs_SHCHGFWD.Tables("RESULT").Rows.Count - 1
            If Not IsDBNull(rs_SHCHGFWD.Tables("RESULT").Rows(index9)("scf_fwdnam")) Then
                If rs_SHCHGFWD.Tables("RESULT").Rows(index9)("scf_fwdnam") = cbofwd.Text.Trim Then
                    'last_ReadingIndex = index9
                End If
            End If
        Next

        If rbDocTyp_C.Checked = True Then
            gspStr = "sp_select_SHIPGDTL_co '','" & Me.txtCtn.Text & "','" & Me.mskETDDat.Text & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_SHIPGDTL_co, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SHM00007 #004 sp_select_SHIPGDTL_CTNETD : " & rtnStr)
                Exit Sub
            Else
                For index9 As Integer = 0 To rs_SHIPGDTL_co.Tables("RESULT").Rows.Count - 1
                    lstVendor.Items.Add(rs_SHIPGDTL_co.Tables("RESULT").Rows(index9)("company") & " - " & rs_SHIPGDTL_co.Tables("RESULT").Rows(index9)("company"))
                Next
            End If
        End If





        btcSHM00007.Enabled = True

        Me.btcSHM00007.TabPages(1).Enabled = False
        Me.btcSHM00007.TabPages(1).Enabled = True
        Me.btcSHM00007.TabPages(2).Enabled = False
        Me.btcSHM00007.TabPages(2).Enabled = True
        gbHeaderMain.Enabled = True
        mmdInsRow.Enabled = True
        mmdDelRow.Enabled = True
        mmdClear.Enabled = True
        mmdSave.Enabled = True

        Call display_dgINVMORE()
        dgINVMORE.Visible = True
        dgINVMORE.DataSource = rs_INVMORE.Tables("RESULT").DefaultView
        dgINVMORE.Refresh()
        txtconsol.Enabled = False
        btcSHM00007.SelectedIndex = 0


        If Me.txtStatus.Text = "CAN" Then
            formInit("READ")
        End If
        flag_cmdFind_Click = False

        Cursor = Cursors.Default

        Dim dv As DataView = rs_SHCHGHDR.Tables("RESULT").DefaultView
        If Not dv.Count = 0 Then
            dv.Sort = "sch_upddat desc"
            Dim drv As DataRowView = dv(0)
            If drv.Item("sch_credat").ToString = "" Then
                Me.StatusBar.Items("lblRight").Text = ""
            Else
                Me.StatusBar.Items("lblRight").Text = Format(drv.Item("sch_upddat"), "MM/dd/yyyy") & " " & Format(drv.Item("sch_upddat"), "MM/dd/yyyy") & " " & drv.Item("sch_updusr")
            End If
            dv.Sort = Nothing
        End If


    End Sub



    Private Sub display_SHCHGHDR()

        Dim SCH_DOCNO As String
        Dim SCH_TYP As String
        Dim SCH_STS As String
        Dim SCH_FWDNAM As String
        Dim SCH_FWDINV As String
        Dim SCH_FCRNO As String
        Dim SCH_FCURCDE As String
        Dim SCH_CURCDE As String
        Dim SCH_EXCHRAT As String
        Dim SCH_PCKDAT As String
        Dim SCH_CTRCFS As String
        Dim SCH_CTRSIZ As String
        Dim SCH_INVLST As String
        Dim SCH_CUSLST As String
        Dim SCH_CUSNOLST As String
        Dim SCH_ETDDAT As String
        Dim SCH_RMK As String
        Dim SCH_CREDAT As String
        Dim SCH_UPDDAT As String
        Dim SCH_CREUSR As String
        Dim SCH_UPDUSR As String



        If rs_SHCHGHDR.Tables("RESULT").Rows.Count <> 1 Then
            Exit Sub
        End If
        SCH_DOCNO = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_docno")
        SCH_TYP = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_typ")
        SCH_STS = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_sts")
        'SCH_FWDNAM = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_fwdnam")
        'SCH_FWDINV = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_fwdinv")
        'SCH_FCRNO = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_fcrno")
        'SCH_FCURCDE = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_fcurcde")
        SCH_CURCDE = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_curcde")
        SCH_EXCHRAT = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_exchrat")
        SCH_PCKDAT = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_pckdat")
        SCH_CTRCFS = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_ctrcfs")
        SCH_CTRSIZ = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_ctrsiz")
        SCH_INVLST = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_invlst")
        SCH_CUSLST = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_cuslst")
        SCH_CUSNOLST = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_cusnolst")
        SCH_ETDDAT = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_etddat")
        SCH_RMK = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_rmk")
        SCH_CREDAT = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_credat")
        SCH_UPDDAT = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_upddat")
        SCH_CREUSR = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_creusr")
        SCH_UPDUSR = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_updusr")

        If SCH_TYP = "C" Then
            Me.rbDocTyp_C.Checked = True
            Label5.Enabled = True
            txtCtn.Enabled = True
            Label6.Enabled = True
            mskETDDat.Enabled = True
            Label18.Enabled = True
            Label14.Enabled = False
            cboCtnSiz.Enabled = False
            Label19.Enabled = False
            'mskPckDat.Enabled = False
            Label5.Visible = True
            txtCtn.Visible = True
            Label6.Visible = True
            mskETDDat.Visible = True
            Label18.Visible = True
            Label14.Visible = True
            cboCtnSiz.Visible = True
            Label19.Visible = True
            mskPckDat.Visible = True

            Label22.Enabled = False
            txtconsol.Enabled = False
            Label22.Visible = False
            txtconsol.Visible = False

        Else
            Me.rbDocTyp_D.Checked = True


            Label5.Enabled = False
            txtCtn.Enabled = False
            Label6.Enabled = False
            mskETDDat.Enabled = False
            Label18.Enabled = False
            Label14.Enabled = False
            cboCtnSiz.Enabled = False
            Label19.Enabled = False

            'mskPckDat.Enabled = False

            Label5.Visible = False
            txtCtn.Visible = False
            Label6.Visible = False
            mskETDDat.Visible = False
            Label18.Visible = False
            Label14.Visible = False
            cboCtnSiz.Visible = False
            Label19.Visible = False
            mskPckDat.Visible = False

            Label22.Enabled = True
            txtconsol.Enabled = True
            Label22.Visible = True
            txtconsol.Visible = True
        End If

        Me.txtStatus.Text = SCH_STS

        Me.cbofwdnam.Text = SCH_FWDNAM
        Me.cbofcrno.Text = SCH_FWDINV
        Me.cbofcrno.Text = SCH_FCRNO
        Me.cboFCurr.Text = SCH_FCURCDE
        Me.cboBCurr.Text = SCH_CURCDE
        Me.mskExchRat.Text = SCH_EXCHRAT
        Me.mskPckDat.Text = SCH_PCKDAT
        Me.txtCtn.Text = SCH_CTRCFS
        Me.cboCtnSiz.Text = SCH_CTRSIZ
        Me.txtInvNoList.Text = SCH_INVLST
        Me.txtCustList.Text = SCH_CUSLST
        Me.txtCusNoList.Text = SCH_CUSNOLST
        Me.mskETDDat.Text = SCH_ETDDAT
        ' Me.rtxtRmk.Text = SCH_RMK
        Me.txtCredat.Text = SCH_CREDAT
        Me.txtUpddat.Text = SCH_UPDDAT


        'Me.ssBar.Text = "Create User : [" & SCH_CREUSR & "]  Update User : [" & SCH_UPDUSR & "]"
    End Sub


    Private Sub reset_and_display_SHCHGDTL(ByVal fn As String)

        Call format_dgSHCHGDTL_CORE()
        Call format_dgSHCHGDTL_Distribute("none")
        '''''''''temp


        Dim i As Integer

        If fn = "" Then
            Call format_dgSHCHGDTL_CORE()
            Call reset_and_display_dgSHCHGDTL_CORE(fn)
            Exit Sub
        End If


        sFilter = "scd_fwdnam = '" & fn & "'"
        rs_SHCHGDTL.Tables("RESULT").DefaultView.RowFilter = sFilter

        If rs_SHCHGDTL_Distribute.Tables.Count > 0 Then
            If rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Count > 0 Then
                rs_SHCHGDTL_Distribute.Tables("RESULT").Rows.Clear()
            End If
        End If

        'If rs_SHIPGDTL_CTNETD.Tables.Count > 0 Then
        '    If rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows.Count > 0 Then
        '        rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows.Clear()
        '    End If
        'End If


        If rs_SHCHGDTL.Tables("RESULT").DefaultView.Count > 0 Then
            cboFCurr.Text = rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fcurcde")
            '      cboFCurr.Text = rs_SHCHGDTL.Tables("RESULT").DefaultView(0)("scd_curcde")
        End If

        '        If rs_SHCHGDTL.Tables("RESULT").DefaultView(0)("scd_curcde") <> "HKD" Then
        If rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fcurcde") = "CNY" Then
            Call format_dgSHCHGDTL_Distribute("CNY")
        ElseIf rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fcurcde") = "USD" Then
            Call format_dgSHCHGDTL_Distribute("USD")
        Else
            Call format_dgSHCHGDTL_Distribute("HKD")
        End If

        If rs_SHCHGDTL_CORE.Tables.Count > 0 Then
            If rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count > 0 Then




                Dim last_locHKD As Integer

                If rs_SHCHGFWD.Tables("RESULT").Rows(last_ReadingIndex)("scf_fcurcde") <> "HKD" Then
                    last_locHKD = 1
                Else
                    last_locHKD = 0
                End If



                If rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count > 0 Then
                    'store manual input CBM
                    'If changeManualCBM = True Then


                    For i = last_locHKD + 2 To rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - (last_locHKD + 2) - 1
                        If Not IsDBNull(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item("MANCBM")) Then

                            ' ''For index9 As Integer = 0 To rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows.Count - 1
                            ' ''    If rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(index9)("tmp_fwdnam") = rs_SHCHGFWD.Tables("result").Rows(last_ReadingIndex)("scf_fwdnam") And _
                            ' ''    rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(index9)("tmp_vbi_venno") = rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item("VENCDE") Then
                            ' ''        rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(index9).Item("tmp_mancbm") = rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item("MANCBM")
                            ' ''    End If
                            ' ''Next

                            'sFilter = "tmp_fwdnam = '" & rs_SHCHGFWD.Tables("result").Rows(last_ReadingIndex)("scf_fwdnam") _
                            '& "' and tmp_vbi_venno ='" & rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item("VENCDE") & "' "

                            'rs_SHIPGDTL_CTNETD.Tables("RESULT").DefaultView.RowFilter = sFilter

                            'If rs_SHIPGDTL_CTNETD.Tables("RESULT").DefaultView.Count > 0 Then
                            '    rs_SHIPGDTL_CTNETD.Tables("RESULT").DefaultView(0).Item("tmp_mancbm") = rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item("MANCBM")
                            'End If


                        End If
                    Next i
                End If


                ' ''If rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count > 0 Then
                ' ''    'store manual input CBM
                ' ''    For i = last_locHKD + 2 To rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - (last_locHKD + 2) - 1
                ' ''        sFilter = "tmp_fwdnam = '" & rs_SHCHGFWD.Tables("result").Rows(last_ReadingIndex)("scf_fwdnam") _
                ' ''                            & "' and tmp_vbi_venno ='" & rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item("VENCDE") & "' "
                ' ''        rs_SHIPGDTL_CTNETD.Tables("RESULT").DefaultView.RowFilter = sFilter

                ' ''        If rs_SHIPGDTL_CTNETD.Tables("RESULT").DefaultView.Count - 1 > i - last_locHKD - 2 Then
                ' ''            '''''temp

                ' ''            If Not IsDBNull(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item("MANCBM")) Then
                ' ''                rs_SHIPGDTL_CTNETD.Tables("RESULT").DefaultView(i - last_locHKD - 2).Item("tmp_mancbm") = rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item("MANCBM")
                ' ''            End If

                ' ''        End If
                ' ''    Next i
                ' ''End If
                rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Clear()


            End If
        End If

        Call format_dgSHCHGDTL_CORE()

        Dim rowspace As Integer
        Dim locHKD As Integer
        rowspace = 0
        locHKD = 0

        If rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fcurcde") <> "HKD" Then
            rowspace = 3
            locHKD = 1
        Else
            rowspace = 2
            locHKD = 0
        End If


        Dim sVendor As String
        Dim sVendorName As String
        Dim sColumn As String
        Dim sCurr As String
        Dim sFee As Decimal

        Dim sTtlSYSCBM As String
        Dim sTtlMANCBM As String
        Dim ttlcbm_flag As Boolean

        sTtlSYSCBM = 0
        sTtlMANCBM = 0
        ttlcbm_flag = False

        sVendor = "TOTAL"

        If rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fcurcde") = "CNY" Then
            'CNY Row
            sCurr = "CNY"
            For i = 1 To rs_SHCHGDTL_Distribute.Tables("RESULT").Columns.Count - 2
                sColumn = rs_SHCHGDTL_Distribute.Tables("RESULT").Columns(i).ColumnName
                sFee = search_SHCHGDTL_By_Vendor_ChgCde_Curr(fn, sVendor, sColumn, sCurr)
                If sFee <> 0 Then
                    rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(0).Item(sColumn) = System.Decimal.Round(sFee, 2)
                End If
            Next i
        End If
        If rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fcurcde") = "USD" Then
            sCurr = "USD"
            For i = 1 To rs_SHCHGDTL_Distribute.Tables("RESULT").Columns.Count - 2
                sColumn = rs_SHCHGDTL_Distribute.Tables("RESULT").Columns(i).ColumnName
                sFee = search_SHCHGDTL_By_Vendor_ChgCde_Curr(fn, sVendor, sColumn, sCurr)
                If sFee <> 0 Then
                    rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(0).Item(sColumn) = System.Decimal.Round(sFee, 2)
                End If
            Next i
        End If
        'HKD Row

        sCurr = "HKD"
        For i = 1 To rs_SHCHGDTL_Distribute.Tables("RESULT").Columns.Count - 2
            sColumn = rs_SHCHGDTL_Distribute.Tables("RESULT").Columns(i).ColumnName
            sFee = search_SHCHGDTL_By_Vendor_ChgCde_Curr(fn, sVendor, sColumn, sCurr)
            If sFee <> 0 Then
                rs_SHCHGDTL_Distribute.Tables("RESULT").Rows(locHKD).Item(sColumn) = sFee
                If ttlcbm_flag = False Then
                    Call search_SHCHGDTL_CBM(fn, sVendor, sColumn, sCurr, sTtlSYSCBM, sTtlMANCBM)
                    ttlcbm_flag = True
                End If
            End If
        Next i

        Dim sInvList As String
        Dim sCusList As String
        Dim sCusNoList As String
        Dim sCtrsiz As String

        If Not rs_SHCHGHDR.Tables("RESULT") Is Nothing Then
            If rs_SHCHGHDR.Tables("RESULT").Rows.Count = 0 Then
                rs_SHCHGHDR.Tables("RESULT").Rows.Add()
            End If

            If Not IsDBNull(rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_invlst")) Then
                sInvList = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_invlst")
                sCusList = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_cuslst")
                sCusNoList = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_cusnolst")
                sCtrsiz = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_ctrsiz")
            End If
        End If



        Dim sLastVendor As String
        sLastVendor = ""


        Dim loc As String

        If rs_SHIPGDTL_CTNETD.Tables("RESULT") Is Nothing Then
            gspStr = "sp_select_SHIPGDTL_CTNETD '','',''"
            rtnLong = execute_SQLStatement(gspStr, rs_SHIPGDTL_CTNETD, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SHM00007 #010 sp_select_SHIPGDTL_CTNETD : " & rtnStr)
                Exit Sub
            Else
                For i = 0 To rs_SHIPGDTL_CTNETD.Tables("RESULT").Columns.Count - 1
                    rs_SHIPGDTL_CTNETD.Tables("RESULT").Columns(i).ReadOnly = False
                Next i
            End If
        End If

        For i = 0 To rs_SHCHGDTL.Tables("RESULT").DefaultView.Count - 1

            If Not IsDBNull(rs_SHCHGDTL.Tables("RESULT").DefaultView(i).Item("scd_venno")) Then
                sVendor = rs_SHCHGDTL.Tables("RESULT").DefaultView(i).Item("scd_venno")
                sVendorName = rs_SHCHGDTL.Tables("RESULT").DefaultView(i).Item("scd_vensna")
                If sVendor = "UCP" _
                    Or sVendor = "UCPP" _
                    Or sVendor = "HX" _
                    Or sVendor = "PG" _
                    Or sVendor = "TT" _
                    Or sVendor = "EW" _
                Then
                    sVendorName = sVendor
                End If
                sFee = rs_SHCHGDTL.Tables("RESULT").DefaultView(i).Item("scd_fee")

            End If

            Dim flag_vendor_notfound As Boolean
            flag_vendor_notfound = True

            If Not rs_SHIPGDTL_CTNETD.Tables("RESULT") Is Nothing Then
                sFilter = "tmp_fwdnam = '" & rs_SHCHGFWD.Tables("result").Rows(ReadingIndex)("scf_fwdnam") & "'"
                rs_SHIPGDTL_CTNETD.Tables("RESULT").DefaultView.RowFilter = sFilter

                For index99 As Integer = 0 To rs_SHIPGDTL_CTNETD.Tables("RESULT").DefaultView.Count - 1
                    If sVendor = rs_SHIPGDTL_CTNETD.Tables("RESULT").DefaultView(index99)("tmp_vbi_venno") Then
                        flag_vendor_notfound = False
                    End If
                Next
                'not in the defaultview list
            End If

            If sVendor <> "TOTAL" And flag_vendor_notfound Then
                '                If sVendor <> "TOTAL" And sVendor <> sLastVendor Then

                rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows.Add()

                loc = rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows.Count - 1
                For j As Integer = 0 To rs_SHIPGDTL_CTNETD.Tables("RESULT").Columns.Count - 1
                    rs_SHIPGDTL_CTNETD.Tables("RESULT").Columns(j).ReadOnly = False
                Next

                rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(loc).Item("tmp_fwdnam") = fn
                rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(loc).Item("tmp_invlist") = sInvList
                rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(loc).Item("tmp_cuslist") = sCusList
                rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(loc).Item("tmp_cusnolist") = sCusNoList
                rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(loc).Item("tmp_ttlcbm") = sTtlSYSCBM
                rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(loc).Item("tmp_ctrsiz") = sCtrsiz
                rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(loc).Item("tmp_creusr") = ""
                rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(loc).Item("tmp_vbi_venno") = sVendor
                rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(loc).Item("tmp_vbi_vensna") = sVendorName
                rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(loc).Item("tmp_cbm") = rs_SHCHGDTL.Tables("RESULT").DefaultView(i).Item("scd_syscbm")
                rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(loc).Item("tmp_mancbm") = rs_SHCHGDTL.Tables("RESULT").DefaultView(i).Item("scd_mancbm")

                sLastVendor = sVendor
            End If


        Next i

        If display_fwd(fn) = True Then
            Call reset_and_display_dgSHCHGDTL_CORE(fn)

            Call formInit("UPD")
        End If
    End Sub

    Private Function search_SHCHGDTL_By_Vendor_ChgCde_Curr(ByVal fn As String, ByVal ven As String, ByVal chgcde As String, ByVal curr As String) As String
        sFilter = "scd_fwdnam = '" & fn & "'"
        rs_SHCHGDTL.Tables("RESULT").DefaultView.RowFilter = sFilter


        Dim i As Integer
        If rs_SHCHGDTL.Tables.Count = 0 Then
            search_SHCHGDTL_By_Vendor_ChgCde_Curr = 0
            Exit Function
        End If
        search_SHCHGDTL_By_Vendor_ChgCde_Curr = 0

        Dim sVendor As String
        Dim sChgCde As String
        Dim sCurr As String
        Dim sFee As Decimal


        For i = 0 To rs_SHCHGDTL.Tables("RESULT").DefaultView.Count - 1
            If Not IsDBNull(rs_SHCHGDTL.Tables("RESULT").DefaultView(i).Item("scd_venno")) Then
                sVendor = rs_SHCHGDTL.Tables("RESULT").DefaultView(i).Item("scd_venno")
                sChgCde = rs_SHCHGDTL.Tables("RESULT").DefaultView(i).Item("scd_chgcde")
                sCurr = rs_SHCHGDTL.Tables("RESULT").DefaultView(i).Item("scd_curcde")
                sFee = rs_SHCHGDTL.Tables("RESULT").DefaultView(i).Item("scd_fee")
            End If

            If sVendor = ven And sChgCde = chgcde And sCurr = curr Then
                search_SHCHGDTL_By_Vendor_ChgCde_Curr = System.Decimal.Round(sFee, 2)
                Exit For
            End If
        Next i


    End Function



    Private Function search_SHCHGDTL_MANCBM_By_Vendor_ChgCde_Curr(ByVal fn As String, ByVal ven As String, ByVal chgcde As String, ByVal curr As String) As String
        sFilter = "scd_fwdnam = '" & fn & "'"
        rs_SHCHGDTL.Tables("RESULT").DefaultView.RowFilter = sFilter

        Dim i As Integer
        If rs_SHCHGDTL.Tables.Count = 0 Then
            search_SHCHGDTL_MANCBM_By_Vendor_ChgCde_Curr = 0
            Exit Function
        End If
        search_SHCHGDTL_MANCBM_By_Vendor_ChgCde_Curr = 0

        Dim sVendor As String
        Dim sChgCde As String
        Dim sCurr As String
        Dim sManCBM As Decimal


        For i = 0 To rs_SHCHGDTL.Tables("RESULT").DefaultView.Count - 1
            sVendor = rs_SHCHGDTL.Tables("RESULT").DefaultView(i).Item("scd_venno")
            sChgCde = rs_SHCHGDTL.Tables("RESULT").DefaultView(i).Item("scd_chgcde")
            sCurr = rs_SHCHGDTL.Tables("RESULT").DefaultView(i).Item("scd_curcde")
            sManCBM = rs_SHCHGDTL.Tables("RESULT").DefaultView(i).Item("scd_mancbm")

            If sVendor = ven And sChgCde = chgcde And sCurr = curr Then
                search_SHCHGDTL_MANCBM_By_Vendor_ChgCde_Curr = System.Decimal.Round(sManCBM, 2)
                Exit For
            End If
        Next i


    End Function

    Private Sub search_SHCHGDTL_CBM(ByVal fn As String, ByVal ven As String, ByVal chgcde As String, ByVal curr As String, ByRef ttlsyscbm As String, ByRef ttlmancbm As String)
        sFilter = "scd_fwdnam = '" & fn & "'"
        rs_SHCHGDTL.Tables("RESULT").DefaultView.RowFilter = sFilter

        Dim i As Integer

        Dim sVendor As String
        Dim sChgCde As String
        Dim sCurr As String

        ttlsyscbm = 0
        ttlmancbm = 0

        If rs_SHCHGDTL.Tables.Count = 0 Then
            Exit Sub
        End If

        For i = 0 To rs_SHCHGDTL.Tables("RESULT").DefaultView.Count - 1
            sVendor = rs_SHCHGDTL.Tables("RESULT").DefaultView(i).Item("scd_venno")
            sChgCde = rs_SHCHGDTL.Tables("RESULT").DefaultView(i).Item("scd_chgcde")
            sCurr = rs_SHCHGDTL.Tables("RESULT").DefaultView(i).Item("scd_curcde")
            If sVendor = ven And sChgCde = chgcde And sCurr = curr Then
                ttlsyscbm = rs_SHCHGDTL.Tables("RESULT").DefaultView(i).Item("scd_syscbm")
                ttlmancbm = rs_SHCHGDTL.Tables("RESULT").DefaultView(i).Item("scd_mancbm")
                Exit For
            End If
        Next i


    End Sub

    Private Sub cbofwdnam_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    End Sub

    'Private Sub cbofwdnam_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbofwdnam.TextChanged
    '    If Add_flag_A(ReadingIndex) = False And upd_flag_A(ReadingIndex) = False Then
    '        upd_flag_A(ReadingIndex) = True
    '    End If


    '    Dim tmpstr
    '    tmpstr = cbofwdnam.Text.Trim
    '    If Not IsDBNull(rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex).Item("scf_fwdnam")) Then
    '        If tmpstr <> rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex).Item("scf_fwdnam") Then
    '            Recordstatus = True
    '            If rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex).Item("scf_creusr") <> "~*ADD*~" And rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex).Item("scf_creusr") <> "~*NEW*~" Then
    '                rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex).Item("scf_creusr") = "~*UPD*~"
    '            End If
    '            rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex).Item("scf_fwdnam") = tmpstr
    '        End If
    '    End If




    'End Sub


    'Private Sub cbofcrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    FLAG_cbofcrno_GotFocus = True
    'End Sub

    'Private Sub cbofcrno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbofcrno.TextChanged
    '    If FLAG_cbofcrno_GotFocus = True Then
    '        FLAG_cbofcrno_GotFocus = False
    '        If Add_flag_A(ReadingIndex) = False And upd_flag_A(ReadingIndex) = False Then
    '            upd_flag_A(ReadingIndex) = True
    '        End If


    '        Dim tmpstr
    '        tmpstr = cbofcrno.Text.Trim
    '        If Not IsDBNull(rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex).Item("scf_fcrno")) Then
    '            If tmpstr <> rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex).Item("scf_fcrno") Then
    '                Recordstatus = True
    '                If rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex).Item("scf_creusr") <> "~*ADD*~" And rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex).Item("scf_creusr") <> "~*NEW*~" Then
    '                    rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex).Item("scf_creusr") = "~*UPD*~"
    '                End If
    '                rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex).Item("scf_fcrno") = tmpstr
    '            End If
    '        End If


    '    End If


    'End Sub

    Private Sub cboCtnSiz_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCtnSiz.SelectedIndexChanged
        If Add_flag_A(ReadingIndex) = False And upd_flag_A(ReadingIndex) = False Then
            upd_flag_A(ReadingIndex) = True
        End If
    End Sub

    Private Sub mskPckDat_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs)
        If Add_flag_A(ReadingIndex) = False And upd_flag_A(ReadingIndex) = False Then
            upd_flag_A(ReadingIndex) = True
        End If
    End Sub

    Private Sub rtxtRmk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles rtxtRmk.GotFocus
        'richtext_focus = "rtxtRmk"
    End Sub

    Private Sub rtxtRmk_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rtxtRmk.TextChanged
        If Add_flag_A(ReadingIndex) = False And upd_flag_A(ReadingIndex) = False Then
            upd_flag_A(ReadingIndex) = True
        End If


        Dim tmpstr
        tmpstr = rtxtRmk.Text.Trim
        If Not IsDBNull(rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex).Item("scf_rmk")) Then
            If tmpstr <> rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex).Item("scf_rmk") Then
                Recordstatus = True
                If rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex).Item("scf_creusr") <> "~*ADD*~" And rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex).Item("scf_creusr") <> "~*NEW*~" Then
                    rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex).Item("scf_creusr") = "~*UPD*~"
                End If
                rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex).Item("scf_rmk") = tmpstr
            End If
        End If

    End Sub



    Private Sub mskExchRat_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskExchRat.TextChanged
        If Add_flag_A(ReadingIndex) = False And upd_flag_A(ReadingIndex) = False Then
            upd_flag_A(ReadingIndex) = True
        End If
    End Sub

    Private Sub cmdInvMore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInvMore.Click
        Call display_dgINVMORE()
        dgINVMORE.Visible = True
        dgINVMORE.Select()
    End Sub

    'Private Sub dgINVMORE_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgINVMORE.LostFocus
    '    dgINVMORE.Visible = False
    'End Sub

    Private Sub txtdocno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdocno.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then
            Call mmdFind_Click(sender, e)
        End If
    End Sub


    Private Sub txtInvNoList_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInvNoList.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then
            If check_INVMORE() Then
                'Me.gbDocTyp_D_Entry.Enabled = False
                Me.txtInvNoList.Text = rs_SHIPGDTL_CTNETD.Tables("RESULT").DefaultView(0).Item("tmp_invlist")
                Me.txtCustList.Text = rs_SHIPGDTL_CTNETD.Tables("RESULT").DefaultView(0).Item("tmp_cuslist")
                Me.txtCusNoList.Text = rs_SHIPGDTL_CTNETD.Tables("RESULT").DefaultView(0).Item("tmp_cusnolist")
                Me.cboCtnSiz.Text = rs_SHIPGDTL_CTNETD.Tables("RESULT").DefaultView(0).Item("tmp_ctrsiz")


                Call display_dgINVMORE()

                Me.gbHeaderMain.Enabled = True
                Me.cboFCurr.Enabled = True

            End If
        End If
    End Sub

    Private Function check_INVMORE() As Boolean
        gspStr = "sp_select_SHIPGDTL_INVMORE '','" & Me.txtInvNoList.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SHIPGDTL_CTNETD, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            check_INVMORE = False
            MsgBox("Error on loading SHM00007 #019 sp_select_SHIPGDTL_INVMORE : " & rtnStr)
            Exit Function
        Else
            If rs_SHIPGDTL_CTNETD.Tables("RESULT").DefaultView.Count = 0 Then
                MsgBox("Record not found!")
                check_INVMORE = False
                Me.txtCtn.Focus()
                Exit Function
            Else
                check_INVMORE = True
                rs_SHIPGDTL_CTNETD.Tables("RESULT").Columns("tmp_creusr").ReadOnly = False
            End If
        End If
    End Function

    Private Sub btcSHM00007_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btcSHM00007.GotFocus
        'Me.btcSHM00007.TabPages(1).Enabled = False
        'Me.btcSHM00007.TabPages(1).Enabled = True
        'Me.btcSHM00007.TabPages(2).Enabled = False
        'Me.btcSHM00007.TabPages(2).Enabled = True
    End Sub

    Private Sub btcSHM00007_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btcSHM00007.MouseClick
        'Me.btcSHM00007.TabPages(1).Enabled = False
        'Me.btcSHM00007.TabPages(1).Enabled = True
        'Me.btcSHM00007.TabPages(2).Enabled = False
        'Me.btcSHM00007.TabPages(2).Enabled = True
    End Sub

    Private Sub txtCtn_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCtn.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then
            Cursor = Cursors.WaitCursor


            If find_ctnno_etddat() Then
                ''Me.gbDocTyp_C_Entry.Enabled = False
                'Me.txtInvNoList.Text = rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(0).Item("tmp_invlist")
                'Me.txtCustList.Text = rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(0).Item("tmp_cuslist")
                'Me.txtCusNoList.Text = rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(0).Item("tmp_cusnolist")
                'Me.cboCtnSiz.Text = rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(0).Item("tmp_ctrsiz")


                'Me.gbHeaderMain.Enabled = True
                'Me.cboFCurr.Enabled = True
                'Call display_dgINVMORE()
                'dgINVMORE.DataSource = rs_INVMORE.Tables("RESULT")

                'dgINVMORE.Visible = True
                'dgINVMORE.Refresh()
                'gbDocTyp_D_Entry.Enabled = True
                'gbDocTyp_D_Entry.Visible = True



                'Me.btcSHM00007.TabPages(1).Enabled = False
                'Me.btcSHM00007.TabPages(1).Enabled = True


                'btcSHM00007.SelectedIndex = 0

            Else
                MsgBox("ETD date not found!")

                gbDocTyp_D_Entry.Enabled = False
                'gbHeaderMain_Enter.Enabled = True

                Me.btcSHM00007.TabPages(0).Enabled = False
                Me.btcSHM00007.TabPages(1).Enabled = False
                btcSHM00007.Enabled = False

            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub mmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdDelete.Click
        Dim docno As String

        docno = Me.txtdocno.Text
        If MsgBox("Are you sure to cancel " & docno & " ?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            gspStr = "sp_update_SHCHGHDR_cancel '','" & docno & "','" & Me.rtxtRmk.Text & "','" & gsUsrID & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_tmp, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SHM00007 #010 sp_update_SHCHGHDR_cancel : " & rtnStr)
                Exit Sub
            End If

            MsgBox("Record Saved!")
            Call formInit("INIT")
            Me.txtdocno.Text = docno

        End If

    End Sub




    Private Sub dgSHCHGDTL_CORE_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSHCHGDTL_CORE.CellContentClick

    End Sub

    Private Sub TabPage3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage3.Click

    End Sub

    Private Sub gbHeaderMain_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gbHeaderMain.Enter

    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click

    End Sub

    Private Sub cbofwd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbofwd.Click
        flag_cbofwd_KeyPress = True
    End Sub

    Private Sub cbofwd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbofwd.GotFocus
        flag_cbofwd_KeyPress = True
    End Sub

    Private Sub cbofwd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbofwd.KeyDown
        flag_cbofwd_KeyPress = True
    End Sub

    Private Sub cbofwd_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbofwd.KeyUp
        flag_cbofwd_KeyPress = True
    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbofwd.SelectedIndexChanged
        Dim tmp_index As Integer

        For index9 As Integer = 0 To rs_SHCHGFWD.Tables("RESULT").Rows.Count - 1
            If Not IsDBNull(rs_SHCHGFWD.Tables("RESULT").Rows(index9)("scf_fwdnam")) Then
                If rs_SHCHGFWD.Tables("RESULT").Rows(index9)("scf_fwdnam") = cbofwd.Text.Trim Then
                    tmp_index = index9
                End If
            End If
        Next

        If rs_SHCHGFWD.Tables("RESULT").Rows(tmp_index)("DEL") = "Y" Then
            ''''''''''''''''  Exit Sub
        End If

        If flag_cbofwd_KeyPress = True Then
            flag_cbofwd_KeyPress = False
            If flag_cmdFind_Click = True Then
                Exit Sub
            End If

            If display_dgSHCHGDTL_Distribute(cbofwd.Text.Trim) = False Then
                'MsgBox("Please input fees!")
                'Exit Sub
            End If
            'tempzzzzzz()
            Dim tempindex As Integer
            tempindex = ReadingIndex
            ReadingIndex = last_ReadingIndex
            reset_and_display_dgSHCHGDTL_CORE(rs_SHCHGFWD.Tables("RESULT").Rows(last_ReadingIndex)("scf_fwdnam"))
            'tempz

            ReadingIndex = tempindex
            reset_and_display_SHCHGDTL(cbofwd.Text.Trim)


            For index9 As Integer = 0 To rs_SHCHGFWD.Tables("RESULT").Rows.Count - 1
                If Not IsDBNull(rs_SHCHGFWD.Tables("RESULT").Rows(index9)("scf_fwdnam")) Then
                    If rs_SHCHGFWD.Tables("RESULT").Rows(index9)("scf_fwdnam") = cbofwd.Text.Trim Then
                        'last_ReadingIndex = index9
                    End If
                End If
            Next

        End If





        '''display each fowarder
    End Sub

    Sub add_forward()

        rs_SHCHGFWD.Tables("result").Rows.Add()

        For j As Integer = 0 To rs_SHCHGFWD.Tables("RESULT").Columns.Count - 1
            rs_SHCHGFWD.Tables("RESULT").Columns(j).ReadOnly = False
        Next

        rs_SHCHGFWD.Tables("result").Rows(ReadingIndex)("scf_docno") = ""

        rs_SHCHGFWD.Tables("result").Rows(ReadingIndex)("scf_fwdnam") = ""


        rs_SHCHGFWD.Tables("result").Rows(ReadingIndex)("scf_fcrno") = cbofcrno.Text
        rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_rmk") = ""
        If ReadingIndex > 0 Then
            If Not IsDBNull(rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex - 1)("scf_rmk")) Then
                rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_rmk") = rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex - 1)("scf_rmk")
            End If
        End If


        rs_SHCHGFWD.Tables("result").Rows(ReadingIndex)("scf_fcurcde") = ""
        rs_SHCHGFWD.Tables("result").Rows(ReadingIndex)("DEL") = ""
        rs_SHCHGFWD.Tables("result").Rows(ReadingIndex)("scf_creusr") = "~*ADD*~"

        dgSHCHGDTL_Distribute.DataSource = Nothing
        dgSHCHGDTL_Distribute.Refresh()
        Me.dgSHCHGDTL_Distribute.Enabled = True


        ''''''''''''''''Call reset_and_display_SHCHGDTL(cbofwdnam.Text.Trim)
        'temp







        'Me.dgSHCHGDTL_Distribute.Enabled = True

        'If ReadingIndex = 0 And Add_flag_A(readingindex) = True Then
        '    If cboFCurr.Text <> "HKD" Then                 'CNY
        '        Call format_dgSHCHGDTL_Distribute("ALL")
        '        Me.mskExchRat.Text = ""
        '        Me.mskExchRat.Enabled = True
        '    Else                                                                     'HKD
        '        Call format_dgSHCHGDTL_Distribute("HKD")
        '        Me.mskExchRat.Text = 1
        '        Me.mskExchRat.Enabled = False
        '    End If
        'Else
        '    rs_SHCHGFWD.Tables("RESULT").Rows.Add()
        '    ReadingIndex = ReadingIndex + 1

        '    If cboFCurr.Text <> "HKD" Then                 'CNY
        '        Call add_rows_dgSHCHGDTL_Distribute("ALL")
        '        Me.mskExchRat.Text = ""
        '        Me.mskExchRat.Enabled = True
        '    Else                                                                     'HKD
        '        Call add_rows_dgSHCHGDTL_Distribute("HKD")
        '        Me.mskExchRat.Text = 1
        '        Me.mskExchRat.Enabled = False
        '    End If

        'End If


    End Sub

    Private Sub lstVendor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstVendor.SelectedIndexChanged

    End Sub

    Private Sub btcSHM00007_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btcSHM00007.SelectedIndexChanged
        'Select Case PreviousTab

        '    Case 0 'Header page check - check for Add mode
        '    Case 1
        '    Case 2
        'End Select

        Select Case btcSHM00007.SelectedIndex
            Case 0
                Call leavepage()
                'Call display_SHCHGHDR()
            Case 1
                txtconsol.Enabled = False
                mskETDDat.Enabled = False
                txtCtn.Enabled = False

                If rs_SHCHGFWD.Tables("RESULT").Rows.Count = 0 Then
                    gbHeaderMain.Enabled = False
                Else
                    gbHeaderMain.Enabled = True
                End If

                If PreviousTab = 2 Then
                    If rs_SHCHGFWD.Tables("RESULT").Rows.Count > 0 Then
                        reset_and_display_dgSHCHGDTL_CORE(rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fwdnam"))
                    End If
                    'tempz
                End If

                ''''''''                'last_ReadingIndex = ReadingIndex
                ''''''''''''''        Call reset_and_display_dgSHCHGDTL_CORE(cbofwdnam.Text.Trim)
                'If display_dgSHCHGDTL_Distribute(rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fwdnam")) = False Then
                '    MsgBox("Please input fees!")
                '    Exit Sub
                'End If

                '    reset_and_display_dgSHCHGDTL_CORE(rs_SHCHGFWD.Tables("RESULT").Rows(last_ReadingIndex)("scf_fwdnam"))
                'tempz

                '   reset_and_display_SHCHGDTL(rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fwdnam"))

                '    'last_ReadingIndex = ReadingIndex
                'For index9 As Integer = 0 To rs_SHCHGFWD.Tables("RESULT").Rows.Count - 1
                '    If Not IsDBNull(rs_SHCHGFWD.Tables("RESULT").Rows(index9)("scf_fwdnam")) Then
                '        If rs_SHCHGFWD.Tables("RESULT").Rows(index9)("scf_fwdnam") = rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fwdnam") Then
                '            'last_ReadingIndex = index9
                '        End If
                '    End If
                'Next

                '                Call display_SHCHGFWD()
            Case 2
                Call leavepage()

                If fill_fwd() = False Then
                    Exit Sub
                End If
                Call format_cbofwd()
                cbofwd.Text = cbofwdnam.Text.Trim
                Call display_fwd_header(cbofwd.Text)


                ''' Call reset_and_display_dgSHCHGDTL_CORE(cbofwdnam.Text.Trim)

                '                If display_dgSHCHGDTL_Distribute(cbofwdnam.Text.Trim) = True Then
                'Call reset_and_display_SHCHGDTL(cbofwd.Text.Trim)
                'Call reset_and_display_dgSHCHGDTL_CORE(cbofwdnam.Text.Trim)
                'Me.btcSHM00007.TabPages(1).Enabled = True
                ' Else
                'MsgBox("Please input fees!")
                'btcSHM00007.SelectedIndex = 1
                'Me.btcSHM00007.TabPages(1).Enabled = True
                'End If
                '
                '''''''''''''reset_and_display_dgSHCHGDTL_CORE(cbofwdnam.Text.Trim)
                ''''''''''''''update_dtl(cbofwdnam.Text.Trim)
                'reset_and_display_SHCHGDTL(cbofwdnam.Text.Trim)


        End Select

        PreviousTab = btcSHM00007.SelectedIndex
    End Sub

    Private Sub btcSHM00007_Selecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles btcSHM00007.Selecting


        'If rs_SHIPGDTL Is Nothing Then
        '    Exit Sub
        'End If
        'If rs_SHIPGDTL.Tables("RESULT") Is Nothing Then
        '    '    Call insert_SHIPGDTL(True)
        '    txtOrdNo.Enabled = False
        '    txtJobNo.Enabled = False
        'End If

        'If Not rs_SHIPGDTL.Tables("RESULT") Is Nothing Then
        '    Call display_Detail(Val(txtShpSeq.Text))
        'End If


        ''     Call reset_detail_control("Detail_Init")
    End Sub
    Function display_fwd(ByVal fn As String) As Boolean
        display_fwd = False
        If display_fwd_header(fn) = False Then
            Exit Function
        End If
        If display_dgSHCHGDTL_Distribute(fn) = False Then
            Exit Function
        End If
        cbofwd.Text = fn
        display_fwd = True
    End Function

    Function display_fwd_header(ByVal fn As String) As Boolean
        display_fwd_header = False

        For index9 As Integer = 0 To rs_SHCHGFWD.Tables("RESULT").Rows.Count - 1
            If Not IsDBNull(rs_SHCHGFWD.Tables("RESULT").Rows(index9)("scf_fwdnam")) Then

                If rs_SHCHGFWD.Tables("RESULT").Rows(index9)("scf_fwdnam") = fn Then
                    ReadingIndex = index9
                End If

            End If

        Next

        txtShpSeq.Text = ReadingIndex + 1
        If rs_SHCHGFWD.Tables("RESULT").Rows.Count = 0 Then
            display_fwd_header = True
            Exit Function
        End If
        cbofwdnam.Text = rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fwdnam")
        If Not IsDBNull(rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fwdinv")) Then
            txtFwdInv.Text = rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fwdinv")
        Else
            txtFwdInv.Text = ""
            'temp
        End If

        If Not IsDBNull(rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fcrno")) Then
            cbofcrno.Text = rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fcrno")
        Else
            cbofcrno.Text = ""
            'temp
        End If

        If Not IsDBNull(rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fcurcde")) Then
            cboFCurr.Text = rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fcurcde")
        End If

        If Not IsDBNull(rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_rmk")) Then
            rtxtRmk.Text = rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_rmk")
        End If

        If Not IsDBNull(rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_exrate")) Then
            mskExchRat.Text = rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_exrate")
            mskExchRat_show.Text = rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_exrate")
        End If


        If Not IsDBNull(rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("DEL")) Then
            If rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("DEL") = "Y" Then
                chkDel.Checked = True
            Else
                chkDel.Checked = False
            End If
        End If

        If ReadingIndex = rs_SHCHGFWD.Tables("RESULT").Rows.Count - 1 And rs_SHCHGFWD.Tables("RESULT").Rows.Count > 1 Then
            cmdBck.Enabled = True
            cmdNxt.Enabled = False
        ElseIf ReadingIndex = 0 And rs_SHCHGFWD.Tables("RESULT").Rows.Count > 1 Then
            cmdBck.Enabled = False
            cmdNxt.Enabled = True
        ElseIf ReadingIndex = 0 And rs_SHCHGFWD.Tables("RESULT").Rows.Count = 1 Then
            cmdBck.Enabled = False
            cmdNxt.Enabled = False
        ElseIf ReadingIndex > 0 And rs_SHCHGFWD.Tables("RESULT").Rows.Count > 1 And ReadingIndex < rs_SHCHGFWD.Tables("RESULT").Rows.Count - 1 Then
            cmdBck.Enabled = True
            cmdNxt.Enabled = True
        End If



        display_fwd_header = True
    End Function

    Sub update_dtl(ByVal fn As String)
        rs_SHCHGDTL_compare = rs_SHCHGDTL.Copy

        If rs_SHCHGDTL.Tables("RESULT") Is Nothing Then
            Exit Sub
        End If

        If fn = "" Then
            Exit Sub
        End If


        sFilter = "scd_fwdnam = '" & fn & "'"
        '        sFilter = "scd_fwdnam = '" & fn & "'  and scd_venno= 'TOTAL'"
        rs_SHCHGDTL.Tables("RESULT").DefaultView.RowFilter = sFilter

        Dim SCD_DOCNO As String
        Dim SCD_VENNO As String
        Dim scd_vensna As String
        Dim SCD_CHGCDE As String
        Dim SCD_SYSCBM As String
        Dim SCD_MANCBM As String
        Dim SCD_CURCDE As String
        Dim SCD_FEE As String
        Dim SCD_FEE_UPD As String
        Dim SCD_FN As String

        Dim SCD_MANCBM_UPD As String
        Dim SCD_CREUSR


        SCD_CREUSR = "~*UPD*~"
        SCD_DOCNO = ""
        SCD_VENNO = ""
        SCD_CHGCDE = ""
        SCD_SYSCBM = ""
        SCD_MANCBM = ""
        SCD_CURCDE = ""
        SCD_FEE = ""
        SCD_FEE_UPD = ""

        SCD_MANCBM_UPD = ""
        SCD_FN = fn

        Dim i As Integer
        Dim j As Integer



        Dim rowspace As Integer
        Dim locHKD As Integer
        rowspace = 0
        locHKD = 0

        If rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fcurcde") <> "HKD" Then
            rowspace = 3
            locHKD = 1
        Else
            rowspace = 2
            locHKD = 0
        End If
        Dim ctner As Integer

        sFilter = "tmp_fwdnam = '" & fn & "'"
        rs_SHIPGDTL_CTNETD.Tables("RESULT").DefaultView.RowFilter = sFilter
        ctner = rs_SHIPGDTL_CTNETD.Tables("RESULT").DefaultView.Count
        If ctner = 0 Then
            gspStr = "sp_select_SHIPGDTL_CTNETD '','" & Me.txtCtn.Text & "','" & Me.mskETDDat.Text & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_SHIPGDTL_CTNETD_add, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SHM00007 #004 sp_select_SHIPGDTL_CTNETD : " & rtnStr)
                Exit Sub
            Else
                ctner = rs_SHIPGDTL_CTNETD_add.Tables("RESULT").Rows.Count
            End If
        End If



        'tempzzzzzzzzzzz

        '- (ctner - 1)
        For i = 0 To (rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count) - rowspace - 1
            'tempzzzzzz

            'SCD_DOCNO = SCH_DOCNO

            ' Save Manual Total
            If i < rowspace Then
                SCD_VENNO = "TOTAL"
                scd_vensna = ""

                For j = 0 To rs_SYMSHC_D.Tables("RESULT").Rows.Count - 1
                    If Not IsDBNull(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - (ctner - 1) - locHKD - 1).Item("SYSCBM")) Then
                        SCD_SYSCBM = rs_SHCHGDTL_CORE.Tables("RESULT").Rows(rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - (ctner - 1) - locHKD - 1).Item("SYSCBM")
                    End If
                    If Not IsDBNull(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - (ctner - 1) - locHKD - 1).Item("MANCBM")) Then
                        SCD_MANCBM = rs_SHCHGDTL_CORE.Tables("RESULT").Rows(rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - (ctner - 1) - locHKD - 1).Item("MANCBM")
                    End If
                    If Not IsDBNull(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - locHKD - 1).Item("SYSCBM")) Then
                        SCD_SYSCBM = rs_SHCHGDTL_CORE.Tables("RESULT").Rows(rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - locHKD - 1).Item("SYSCBM")
                        'Else
                        '    MsgBox("!")
                    End If
                    If Not IsDBNull(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - locHKD - 1).Item("MANCBM")) Then
                        SCD_MANCBM = rs_SHCHGDTL_CORE.Tables("RESULT").Rows(rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - locHKD - 1).Item("MANCBM")
                        'Else
                        '    MsgBox("!")
                    End If
                    'tempzzzzzzzzz


                    '                    SCD_SYSCBM = rs_SHCHGDTL_CORE.Tables("RESULT").Rows(rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - locHKD - 1).Item("SYSCBM")
                    '                   SCD_MANCBM = rs_SHCHGDTL_CORE.Tables("RESULT").Rows(rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - locHKD - 1).Item("MANCBM")
                    SCD_CURCDE = ""
                    If rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fcurcde") = "CNY" And i = 0 Then
                        SCD_CURCDE = "CNY"
                    End If
                    If rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fcurcde") = "HKD" And i = 0 Then
                        SCD_CURCDE = "HKD"
                    End If
                    If rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fcurcde") = "USD" And i = 0 Then
                        SCD_CURCDE = "USD"
                    End If
                    SCD_CHGCDE = rs_SYMSHC_D.Tables("RESULT").Rows(j).Item("ysc_chgcde")
                    If IsNumeric(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item(SCD_CHGCDE)) Then
                        SCD_FEE = rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item(SCD_CHGCDE)
                    Else
                        SCD_FEE = ""
                    End If


                    If SCD_FEE <> "" Then

                        If Add_flag_A(ReadingIndex) = True Then
                            'gspStr = "sp_insert_SHCHGDTL '','" & SCD_DOCNO & "','" & SCD_FN & "','" & SCD_VENNO & "','" & SCD_CHGCDE & "','" & SCD_SYSCBM & "','" & SCD_MANCBM & "','" & SCD_CURCDE & "','" & SCD_FEE & "','" & gsUsrID & "'"
                            SCD_CREUSR = "~*ADD*~"
                            Call add_dtl_row(SCD_FN, SCD_VENNO, scd_vensna, SCD_CHGCDE, SCD_SYSCBM, SCD_MANCBM, SCD_CURCDE, SCD_FEE, SCD_CREUSR)

                        ElseIf upd_flag_A(ReadingIndex) = True Then
                            SCD_FEE_UPD = search_SHCHGDTL_By_Vendor_ChgCde_Curr(fn, SCD_VENNO, SCD_CHGCDE, SCD_CURCDE)
                            SCD_MANCBM_UPD = search_SHCHGDTL_MANCBM_By_Vendor_ChgCde_Curr(fn, SCD_VENNO, SCD_CHGCDE, SCD_CURCDE)
                            If SCD_FEE_UPD = 0 Then
                                SCD_CREUSR = "~*ADD*~"
                                'gspStr = "sp_insert_SHCHGDTL '','" & SCD_DOCNO & "','" & SCD_FN & "','" & SCD_VENNO & "','" & SCD_CHGCDE & "','" & SCD_SYSCBM & "','" & SCD_MANCBM & "','" & SCD_CURCDE & "','" & SCD_FEE & "','" & gsUsrID & "'"
                                Call add_dtl_row(SCD_FN, SCD_VENNO, scd_vensna, SCD_CHGCDE, SCD_SYSCBM, SCD_MANCBM, SCD_CURCDE, SCD_FEE, SCD_CREUSR)

                            ElseIf SCD_FEE <> SCD_FEE_UPD Then
                                If SCD_FEE = "" And SCD_FEE_UPD <> 0 Then
                                    'del
                                    'gspStr = "sp_physical_delete_SHCHGDTL '','" & SCD_DOCNO & "','" & SCD_VENNO & "','" & SCD_CHGCDE & "','" & SCD_CURCDE & "'"
                                    SCD_CREUSR = "~*DEL*~"
                                    Call update_dtl_row(SCD_FN, SCD_VENNO, SCD_CHGCDE, SCD_SYSCBM, SCD_MANCBM, SCD_CURCDE, SCD_FEE, SCD_CREUSR)

                                Else
                                    SCD_CREUSR = "~*UPD*~"
                                    'upd
                                    'gspStr = "sp_update_SHCHGDTL '','" & SCD_DOCNO & "','" & SCD_FN & "','" & SCD_VENNO & "','" & SCD_CHGCDE & "','" & SCD_SYSCBM & "','" & SCD_MANCBM & "','" & SCD_CURCDE & "','" & SCD_FEE & "','" & gsUsrID & "'"
                                    Call update_dtl_row(SCD_FN, SCD_VENNO, SCD_CHGCDE, SCD_SYSCBM, SCD_MANCBM, SCD_CURCDE, SCD_FEE, SCD_CREUSR)

                                End If
                            ElseIf SCD_MANCBM <> SCD_MANCBM_UPD Then
                                SCD_CREUSR = "~*UPD*~"
                                'upd
                                'gspStr = "sp_update_SHCHGDTL '','" & SCD_DOCNO & "','" & SCD_FN & "','" & SCD_VENNO & "','" & SCD_CHGCDE & "','" & SCD_SYSCBM & "','" & SCD_MANCBM & "','" & SCD_CURCDE & "','" & SCD_FEE & "','" & gsUsrID & "'"
                                Call update_dtl_row(SCD_FN, SCD_VENNO, SCD_CHGCDE, SCD_SYSCBM, SCD_MANCBM, SCD_CURCDE, SCD_FEE, SCD_CREUSR)

                            End If
                        End If
                    End If
                Next j
            Else

                If IsDBNull(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item("VENCDE")) Then
                    Exit Sub ''temp
                End If

                SCD_VENNO = rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item("VENCDE")
                scd_vensna = rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item("VENDOR")
                If SCD_VENNO <> "" Then
                    If IsNumeric(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item("SYSCBM")) Then
                        SCD_SYSCBM = rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item("SYSCBM")
                    Else
                        SCD_SYSCBM = "0"
                    End If
                    If IsNumeric(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item("MANCBM")) Then
                        SCD_MANCBM = rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item("MANCBM")
                    Else
                        SCD_MANCBM = "0"
                    End If

                    SCD_CURCDE = Me.cboBCurr.Text

                    For j = 0 To rs_SYMSHC_ALL.Tables("RESULT").Rows.Count - 1
                        SCD_CHGCDE = rs_SYMSHC_ALL.Tables("RESULT").Rows(j).Item("ysc_chgcde")
                        If IsNumeric(rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item(SCD_CHGCDE)) Then
                            SCD_FEE = rs_SHCHGDTL_CORE.Tables("RESULT").Rows(i).Item(SCD_CHGCDE)
                        Else
                            SCD_FEE = "0"
                        End If
                        If SCD_FEE <> "0" Then
                            If Add_flag_A(ReadingIndex) = True Then
                                SCD_CREUSR = "~*ADD*~"
                                'gspStr = "sp_insert_SHCHGDTL '','" & SCD_DOCNO & "','" & SCD_FN & "','" & SCD_VENNO & "','" & SCD_CHGCDE & "','" & SCD_SYSCBM & "','" & SCD_MANCBM & "','" & SCD_CURCDE & "','" & SCD_FEE & "','" & gsUsrID & "'"
                                Call add_dtl_row(SCD_FN, SCD_VENNO, scd_vensna, SCD_CHGCDE, SCD_SYSCBM, SCD_MANCBM, SCD_CURCDE, SCD_FEE, SCD_CREUSR)

                            ElseIf upd_flag_A(ReadingIndex) = True Then
                                SCD_FEE_UPD = search_SHCHGDTL_By_Vendor_ChgCde_Curr(fn, SCD_VENNO, SCD_CHGCDE, SCD_CURCDE)
                                SCD_MANCBM_UPD = search_SHCHGDTL_MANCBM_By_Vendor_ChgCde_Curr(fn, SCD_VENNO, SCD_CHGCDE, SCD_CURCDE)
                                If SCD_FEE_UPD = 0 Then
                                    SCD_CREUSR = "~*ADD*~"
                                    'gspStr = "sp_insert_SHCHGDTL '','" & SCD_DOCNO & "','" & SCD_FN & "','" & SCD_VENNO & "','" & SCD_CHGCDE & "','" & SCD_SYSCBM & "','" & SCD_MANCBM & "','" & SCD_CURCDE & "','" & SCD_FEE & "','" & gsUsrID & "'"
                                    Call add_dtl_row(SCD_FN, SCD_VENNO, scd_vensna, SCD_CHGCDE, SCD_SYSCBM, SCD_MANCBM, SCD_CURCDE, SCD_FEE, SCD_CREUSR)

                                ElseIf SCD_FEE <> SCD_FEE_UPD Then
                                    If SCD_FEE = "0" And SCD_FEE_UPD <> 0 Then
                                        'del
                                        'gspStr = "sp_physical_delete_SHCHGDTL '','" & SCD_DOCNO & "','" & SCD_VENNO & "','" & SCD_CHGCDE & "','" & SCD_CURCDE & "'"
                                        SCD_CREUSR = "~*DEL*~"
                                        Call update_dtl_row(SCD_FN, SCD_VENNO, SCD_CHGCDE, SCD_SYSCBM, SCD_MANCBM, SCD_CURCDE, SCD_FEE, SCD_CREUSR)

                                    Else
                                        SCD_CREUSR = "~*UPD*~"
                                        'upd
                                        'gspStr = "sp_update_SHCHGDTL '','" & SCD_DOCNO & "','" & SCD_FN & "','" & SCD_VENNO & "','" & SCD_CHGCDE & "','" & SCD_SYSCBM & "','" & SCD_MANCBM & "','" & SCD_CURCDE & "','" & SCD_FEE & "','" & gsUsrID & "'"
                                        Call update_dtl_row(SCD_FN, SCD_VENNO, SCD_CHGCDE, SCD_SYSCBM, SCD_MANCBM, SCD_CURCDE, SCD_FEE, SCD_CREUSR)
                                    End If
                                ElseIf SCD_MANCBM <> SCD_MANCBM_UPD Then
                                    SCD_CREUSR = "~*UPD*~"
                                    'upd
                                    'gspStr = "sp_update_SHCHGDTL '','" & SCD_DOCNO & "','" & SCD_FN & "','" & SCD_VENNO & "','" & SCD_CHGCDE & "','" & SCD_SYSCBM & "','" & SCD_MANCBM & "','" & SCD_CURCDE & "','" & SCD_FEE & "','" & gsUsrID & "'"
                                    Call update_dtl_row(SCD_FN, SCD_VENNO, SCD_CHGCDE, SCD_SYSCBM, SCD_MANCBM, SCD_CURCDE, SCD_FEE, SCD_CREUSR)

                                End If
                            End If
                        Else
                            'gspStr = "sp_physical_delete_SHCHGDTL '','" & SCD_DOCNO & "','" & SCD_VENNO & "','" & SCD_CHGCDE & "','" & SCD_CURCDE & "'"
                            SCD_CREUSR = "~*DEL*~"
                            Call update_dtl_row(SCD_FN, SCD_VENNO, SCD_CHGCDE, SCD_SYSCBM, SCD_MANCBM, SCD_CURCDE, SCD_FEE, SCD_CREUSR)


                        End If
                    Next j
                End If
            End If
        Next i


    End Sub

    Sub update_dtl_row(ByVal SCD_FN, ByVal SCD_VENNO, ByVal SCD_CHGCDE, ByVal SCD_SYSCBM, ByVal SCD_MANCBM, ByVal SCD_CURCDE, ByVal SCD_FEE, ByVal SCD_CREUSR)
        Dim FLAG_TTL_found As Boolean

        If SCD_CURCDE = "" Then
            MsgBox("code:" & SCD_FN & SCD_VENNO & SCD_CHGCDE & SCD_MANCBM)
            Exit Sub
        End If

        For index9 As Integer = 0 To rs_SHCHGDTL.Tables("RESULT").Columns.Count - 1
            rs_SHCHGDTL.Tables("RESULT").Columns(index9).ReadOnly = False
        Next
        For i As Integer = 0 To rs_SHCHGDTL.Tables("RESULT").Rows.Count - 1
            If rs_SHCHGDTL.Tables("RESULT").Rows(i)("scd_fwdnam") = SCD_FN And _
            rs_SHCHGDTL.Tables("RESULT").Rows(i)("SCD_VENNO") = SCD_VENNO And _
            rs_SHCHGDTL.Tables("RESULT").Rows(i)("SCD_CHGCDE") = SCD_CHGCDE And _
            rs_SHCHGDTL.Tables("RESULT").Rows(i)("SCD_CURCDE") = SCD_CURCDE Then

                'FLAG_TTL_found = False
                'For index999 As Integer = 0 To rs_SHCHGDTL_compare.Tables("RESULT").Rows.Count - 1
                '    If rs_SHCHGDTL.Tables("RESULT").Rows(index999)("scd_fwdnam") = SCD_FN And _
                '    Microsoft.VisualBasic.Left(rs_SHCHGDTL.Tables("RESULT").Rows(index999)("SCD_VENNO"), 6) = "舥だ计" And _
                '    rs_SHCHGDTL.Tables("RESULT").Rows(index999)("SCD_CHGCDE") = SCD_CHGCDE And _
                '    rs_SHCHGDTL.Tables("RESULT").Rows(index999)("SCD_FEE") <> 0 Then
                '        FLAG_TTL_found = True
                '    End If
                'Next
                'If FLAG_TTL_found = False Then
                '    SCD_CREUSR = "~*DEL*~"
                '    SCD_FEE = 0
                'End If


                rs_SHCHGDTL.Tables("RESULT").Rows(i)("SCD_SYSCBM") = SCD_SYSCBM
                rs_SHCHGDTL.Tables("RESULT").Rows(i)("SCD_MANCBM") = SCD_MANCBM
                rs_SHCHGDTL.Tables("RESULT").Rows(i)("SCD_FEE") = SCD_FEE
                rs_SHCHGDTL.Tables("RESULT").Rows(i)("SCD_CREUSR") = "~*UPD*~"     'SCD_CREUSR

            End If
        Next


    End Sub

    Sub add_dtl_row(ByVal SCD_FN, ByVal SCD_VENNO, ByVal scd_vensna, ByVal SCD_CHGCDE, ByVal SCD_SYSCBM, ByVal SCD_MANCBM, ByVal SCD_CURCDE, ByVal SCD_FEE, ByVal SCD_CREUSR)
        Dim FLAG_TTL_found As Boolean

        If SCD_CURCDE = "" Then
            '  MsgBox("code:" & SCD_FN & SCD_VENNO & SCD_CHGCDE & SCD_MANCBM)
            Exit Sub
        End If

        sFilter = "scd_fwdnam = '" & SCD_FN & "'  and scd_venno= '" & SCD_VENNO & "' and   SCD_CHGCDE= '" & SCD_CHGCDE & "'  and  SCD_CURCDE = '" & SCD_CURCDE & "'"
        rs_SHCHGDTL.Tables("RESULT").DefaultView.RowFilter = sFilter

        If rs_SHCHGDTL.Tables("RESULT").DefaultView.Count = 0 Then
            rs_SHCHGDTL.Tables("RESULT").Rows.Add()
            For index9 As Integer = 0 To rs_SHCHGDTL.Tables("RESULT").Columns.Count - 1
                rs_SHCHGDTL.Tables("RESULT").Columns(index9).ReadOnly = False
            Next

            'FLAG_TTL_found = False
            'For index999 As Integer = 0 To rs_SHCHGDTL_compare.Tables("RESULT").Rows.Count - 1
            '    If rs_SHCHGDTL.Tables("RESULT").Rows(index999)("scd_fwdnam") = SCD_FN And _
            '    Microsoft.VisualBasic.Left(rs_SHCHGDTL.Tables("RESULT").Rows(index999)("SCD_VENNO"), 3) = "舥だ计" And _
            '    rs_SHCHGDTL.Tables("RESULT").Rows(index999)("SCD_CHGCDE") = SCD_CHGCDE And _
            '    rs_SHCHGDTL.Tables("RESULT").Rows(index999)("SCD_FEE") <> 0 Then
            '        FLAG_TTL_found = True
            '    End If
            'Next
            'If FLAG_TTL_found = False Then
            '    SCD_CREUSR = "~*DEL*~"
            '    SCD_FEE = 0
            'End If



            rs_SHCHGDTL.Tables("RESULT").Rows(rs_SHCHGDTL.Tables("RESULT").Rows.Count - 1)("scd_fwdnam") = SCD_FN
            rs_SHCHGDTL.Tables("RESULT").Rows(rs_SHCHGDTL.Tables("RESULT").Rows.Count - 1)("SCD_VENNO") = SCD_VENNO
            rs_SHCHGDTL.Tables("RESULT").Rows(rs_SHCHGDTL.Tables("RESULT").Rows.Count - 1)("scd_vensna") = scd_vensna

            rs_SHCHGDTL.Tables("RESULT").Rows(rs_SHCHGDTL.Tables("RESULT").Rows.Count - 1)("SCD_CHGCDE") = SCD_CHGCDE
            rs_SHCHGDTL.Tables("RESULT").Rows(rs_SHCHGDTL.Tables("RESULT").Rows.Count - 1)("SCD_SYSCBM") = SCD_SYSCBM
            rs_SHCHGDTL.Tables("RESULT").Rows(rs_SHCHGDTL.Tables("RESULT").Rows.Count - 1)("SCD_MANCBM") = SCD_MANCBM

            rs_SHCHGDTL.Tables("RESULT").Rows(rs_SHCHGDTL.Tables("RESULT").Rows.Count - 1)("SCD_CURCDE") = SCD_CURCDE
            rs_SHCHGDTL.Tables("RESULT").Rows(rs_SHCHGDTL.Tables("RESULT").Rows.Count - 1)("SCD_FEE") = SCD_FEE
            rs_SHCHGDTL.Tables("RESULT").Rows(rs_SHCHGDTL.Tables("RESULT").Rows.Count - 1)("SCD_CREUSR") = SCD_CREUSR


            rs_SHCHGDTL.Tables("RESULT").Rows(rs_SHCHGDTL.Tables("RESULT").Rows.Count - 1)("SCD_SYSCBM") = SCD_SYSCBM
            rs_SHCHGDTL.Tables("RESULT").Rows(rs_SHCHGDTL.Tables("RESULT").Rows.Count - 1)("SCD_MANCBM") = SCD_MANCBM
            rs_SHCHGDTL.Tables("RESULT").Rows(rs_SHCHGDTL.Tables("RESULT").Rows.Count - 1)("SCD_FEE") = SCD_FEE
            rs_SHCHGDTL.Tables("RESULT").Rows(rs_SHCHGDTL.Tables("RESULT").Rows.Count - 1)("SCD_CREUSR") = SCD_CREUSR
        Else
            Call update_dtl_row(SCD_FN, SCD_VENNO, SCD_CHGCDE, SCD_SYSCBM, SCD_MANCBM, SCD_CURCDE, SCD_FEE, SCD_CREUSR)
            '            SCD_CREUSR = "*~UPD~*"
            'temp
        End If
    End Sub

    Function check_dtl_row(ByVal SCD_FN, ByVal SCD_VENNO, ByVal SCD_CHGCDE, ByVal SCD_SYSCBM, ByVal SCD_MANCBM, ByVal SCD_CURCDE, ByVal SCD_FEE, ByVal SCD_CREUSR) As String
        sFilter = "scd_fwdnam = '" & SCD_FN & "'  and scd_venno= '" & SCD_VENNO & "' and   SCD_CHGCDE= '" & SCD_CHGCDE & "'  and  SCD_CURCDE = '" & SCD_CURCDE & "'"
        If rs_SHCHGDTL_org.Tables("RESULT") Is Nothing Then
            check_dtl_row = "~*ADD*~"
            'tempz
            Exit Function
        End If
        rs_SHCHGDTL_org.Tables("RESULT").DefaultView.RowFilter = sFilter

        If rs_SHCHGDTL_org.Tables("RESULT").DefaultView.Count > 0 Then
            If SCD_CREUSR = "~*ADD*~" Then
                check_dtl_row = "~*UPD*~"
            Else
                check_dtl_row = SCD_CREUSR
            End If
        Else
            If SCD_CREUSR = "~*UPD*~" Then
                check_dtl_row = "~*ADD*~"
            Else
                check_dtl_row = SCD_CREUSR
            End If



        End If
    End Function

    Public Function fill_fwd() As Boolean
        fill_fwd = True

        If rs_SHCHGFWD Is Nothing Then
            Exit Function
        End If

        If rs_SHCHGFWD.Tables("RESULT") Is Nothing Then
            gspStr = "sp_select_SHCHGFWD '','" & "" & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_SHCHGFWD, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SHM00007 #009 sp_select_SHCHGFWD : " & rtnStr)
                Exit Function
            End If

            '            Exit Sub
        End If


        If Not rs_SHCHGFWD.Tables("RESULT").Rows.Count > 0 Then
            '            rs_SHCHGFWD.Tables("RESULT").Rows.Add()
            Exit Function
        End If


        'For i As Integer = 0 To rs_SHCHGFWD.Tables("RESULT").Rows.Count - 1
        '    If Not IsDBNull(rs_SHCHGFWD.Tables("RESULT").Rows(i).Item("scf_fwdnam")) Then
        '        If cbofwdnam.Text.Trim = "" Then
        '            MsgBox("Please Input Forwarder name!")
        '            btcSHM00007.SelectedIndex = 1
        '            cbofwdnam.Focus()
        '            fill_fwd = False
        '        ElseIf cbofwdnam.Text.Trim = rs_SHCHGFWD.Tables("RESULT").Rows(i).Item("scf_fwdnam") Then
        '            btcSHM00007.SelectedIndex = 1
        '            cbofwdnam.Focus()
        '            MsgBox("Forwarder already exist!")
        '            fill_fwd = False
        '        End If
        '    End If
        'Next i
        'temp2015


        For i As Integer = 0 To rs_SHCHGFWD.Tables("RESULT").Columns.Count - 1
            rs_SHCHGFWD.Tables("RESULT").Columns(i).ReadOnly = False
        Next i

        rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fwdnam") = cbofwdnam.Text.Trim

        rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fwdinv") = txtFwdInv.Text.Trim

        rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fcrno") = cbofcrno.Text.Trim
        rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fcurcde") = cboFCurr.Text.Trim
        rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_rmk") = rtxtRmk.Text
        If IsNumeric(mskExchRat.Text.Trim) Then
            rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_exrate") = mskExchRat.Text.Trim
        Else
            rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_exrate") = 1
        End If


        If chkDel.Checked = True Then
            rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("DEL") = "Y"
        Else
            rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("DEL") = "N"
        End If
    End Function

    Private Sub mskETDDat_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mskETDDat.ValueChanged

    End Sub

    Private Sub dgSHCHGDTL_Distribute_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSHCHGDTL_Distribute.CellContentClick

    End Sub

    Private Sub cmdBck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBck.Click
        Dim fn As String
        Call leavepage()
        If fill_fwd() = False Then
            Exit Sub
        End If
        If display_dgSHCHGDTL_Distribute(cbofwdnam.Text.Trim) = False Then
            MsgBox("Please input fees!")
            Exit Sub
        End If


        ReadingIndex = ReadingIndex - 1
        If ReadingIndex < 0 Then
            ReadingIndex = 0
        End If
        fn = rs_SHCHGFWD.Tables("result").Rows(ReadingIndex)("scf_fwdnam")

        If flag_distribute_changed = True Then
            flag_sub_value_change(ReadingIndex) = False
            Call reset_and_display_SHCHGDTL(fn)
        Else
            flag_sub_value_change(ReadingIndex) = True
            Call reset_and_display_SHCHGDTL(fn)
        End If

        Call display_dgSHCHGDTL_Distribute(fn)

        'last_ReadingIndex = ReadingIndex

    End Sub

    Private Sub cmdNxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNxt.Click
        Dim fn As String
        Call leavepage()
        If fill_fwd() = False Then
            Exit Sub
        End If

        If display_dgSHCHGDTL_Distribute(cbofwdnam.Text.Trim) = False Then
            MsgBox("Please input fees!")
            Exit Sub
        End If




        ReadingIndex = ReadingIndex + 1
        If ReadingIndex > rs_SHCHGFWD.Tables("result").Rows.Count - 1 Then
            ReadingIndex = rs_SHCHGFWD.Tables("result").Rows.Count - 1
        End If

        fn = rs_SHCHGFWD.Tables("result").Rows(ReadingIndex)("scf_fwdnam")

        If flag_distribute_changed = True Then
            flag_sub_value_change(ReadingIndex) = False
            Call reset_and_display_SHCHGDTL(fn)
        Else
            flag_sub_value_change(ReadingIndex) = True
            Call reset_and_display_SHCHGDTL(fn)
        End If        'last_ReadingIndex = ReadingIndex

    End Sub



    Function check_fwd() As Boolean
        If rs_SHCHGFWD.Tables("result").Rows.Count = 0 Then
            check_fwd = True
            Exit Function
        End If
        If rs_SHCHGFWD.Tables("result").Rows(ReadingIndex)("DEL") = "Y" Then
            check_fwd = True
            Exit Function
        End If

        If cboFCurr.Text.Trim = "" Then
            check_fwd = False
            ' MsgBox("please select the forwarder currency!")
            'temp

            Exit Function
        End If
        If cbofwdnam.Text.Trim = "" Then
            check_fwd = False
            MsgBox("please Input forwarder name!")
            Exit Function
        End If


        check_fwd = False

        For i As Integer = 0 To rs_SHCHGFWD.Tables("result").Rows.Count - 1
            If cbofwdnam.Text.Trim = rs_SHCHGFWD.Tables("result").Rows(i).Item("scf_fwdnam") Then
                If rs_SHCHGFWD.Tables("result").Rows(i).Item("DEL") <> "Y" _
                And rs_SHCHGFWD.Tables("result").Rows(ReadingIndex).Item("DEL") <> "Y" Then
                    If i <> ReadingIndex Then
                        btcSHM00007.SelectedIndex = 1
                        cbofwdnam.Focus()
                        MsgBox("forwarder name already exist!")
                        Exit Function
                    End If
                End If
            End If
        Next i

        If txtShpSeq.Text.Trim <> "" _
And _
display_dgSHCHGDTL_Distribute(cbofwdnam.Text.Trim) = False _
Then
            If rs_SHCHGFWD.Tables("result").Rows(ReadingIndex)("DEL") <> "Y" Then
                check_fwd = False
                MsgBox("Please input fees! for  seq#:" & txtShpSeq.Text.Trim & " ")
                Exit Function
            End If

        End If



        check_fwd = True

    End Function


    Private Sub addctnetd(ByVal fn As String)
        Dim Loc As Integer

        If rs_SHIPGDTL_CTNETD_add.Tables("RESULT") Is Nothing Then
            gspStr = "sp_select_SHIPGDTL_CTNETD '','" & Me.txtCtn.Text & "','" & Me.mskETDDat.Text & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_SHIPGDTL_CTNETD_add, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SHM00007 #004 sp_select_SHIPGDTL_CTNETD : " & rtnStr)

                Exit Sub
            Else
                If rs_SHIPGDTL_CTNETD_add.Tables("RESULT").Rows.Count = 0 Then
                    MsgBox("Record not found!")
                    Me.txtCtn.Focus()
                    Exit Sub
                Else

                    rs_SHIPGDTL_CTNETD_add.Tables("RESULT").Columns("tmp_creusr").ReadOnly = False
                    rs_SHIPGDTL_CTNETD_add.Tables("RESULT").Columns("tmp_mancbm").ReadOnly = False

                    '        rs_SHIPGDTL_CTNETD_add = rs_SHIPGDTL_CTNETD.Copy
                    '
                End If
            End If

        End If

        If Not rs_SHIPGDTL_CTNETD_add.Tables("RESULT") Is Nothing Then
            If rs_SHIPGDTL_CTNETD_add.Tables("RESULT").Rows.Count = 0 Then
                gspStr = "sp_select_SHIPGDTL_CTNETD '','" & Me.txtCtn.Text & "','" & Me.mskETDDat.Text & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_SHIPGDTL_CTNETD_add, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading SHM00007 #004 sp_select_SHIPGDTL_CTNETD : " & rtnStr)

                    Exit Sub
                Else
                    If rs_SHIPGDTL_CTNETD_add.Tables("RESULT").Rows.Count = 0 Then
                        MsgBox("Record not found!")
                        Me.txtCtn.Focus()
                        Exit Sub
                    Else

                        rs_SHIPGDTL_CTNETD_add.Tables("RESULT").Columns("tmp_creusr").ReadOnly = False
                        rs_SHIPGDTL_CTNETD_add.Tables("RESULT").Columns("tmp_mancbm").ReadOnly = False

                        '        rs_SHIPGDTL_CTNETD_add = rs_SHIPGDTL_CTNETD.Copy
                        '
                    End If
                End If

            End If
        End If


        If rs_SHIPGDTL_CTNETD.Tables("RESULT") Is Nothing Then
            gspStr = "sp_select_SHIPGDTL_CTNETD '','" & Me.txtCtn.Text & "','" & Me.mskETDDat.Text & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_SHIPGDTL_CTNETD, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SHM00007 #004 sp_select_SHIPGDTL_CTNETD : " & rtnStr)

                Exit Sub
            Else
                If rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows.Count = 0 Then
                    MsgBox("Record not found!")
                    Me.txtCtn.Focus()
                    Exit Sub
                Else

                    rs_SHIPGDTL_CTNETD.Tables("RESULT").Columns("tmp_creusr").ReadOnly = False
                    rs_SHIPGDTL_CTNETD.Tables("RESULT").Columns("tmp_mancbm").ReadOnly = False

                    '        rs_SHIPGDTL_CTNETD = rs_SHIPGDTL_CTNETD.Copy
                    '
                End If
            End If

        End If


        For index999 As Integer = 0 To rs_SHIPGDTL_CTNETD_add.Tables("RESULT").Rows.Count - 1
            Dim flag_vendor_notfound As Boolean
            flag_vendor_notfound = True

            If Not rs_SHIPGDTL_CTNETD.Tables("RESULT") Is Nothing Then
                sFilter = "tmp_fwdnam = '" & fn & "'"
                rs_SHIPGDTL_CTNETD.Tables("RESULT").DefaultView.RowFilter = sFilter

                For index99 As Integer = 0 To rs_SHIPGDTL_CTNETD.Tables("RESULT").DefaultView.Count - 1
                    If rs_SHIPGDTL_CTNETD_add.Tables("RESULT").Rows(index999).Item("tmp_vbi_venno") = rs_SHIPGDTL_CTNETD.Tables("RESULT").DefaultView(index99)("tmp_vbi_venno") Then
                        flag_vendor_notfound = False
                    End If
                Next
                'not in the defaultview list
            End If

            If flag_vendor_notfound = False Then
                Exit Sub
            End If

            rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows.Add()

            Loc = rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows.Count - 1

            For i As Integer = 0 To rs_SHIPGDTL_CTNETD.Tables("RESULT").Columns.Count - 1
                rs_SHIPGDTL_CTNETD.Tables("RESULT").Columns(i).ReadOnly = False
            Next i

            rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(Loc).Item("tmp_fwdnam") = fn
            rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(Loc).Item("tmp_invlist") = rs_SHIPGDTL_CTNETD_add.Tables("RESULT").Rows(index999).Item("tmp_invlist")
            rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(Loc).Item("tmp_cuslist") = rs_SHIPGDTL_CTNETD_add.Tables("RESULT").Rows(index999).Item("tmp_cuslist")
            rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(Loc).Item("tmp_cusnolist") = rs_SHIPGDTL_CTNETD_add.Tables("RESULT").Rows(index999).Item("tmp_cusnolist")
            rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(Loc).Item("tmp_ttlcbm") = rs_SHIPGDTL_CTNETD_add.Tables("RESULT").Rows(index999).Item("tmp_ttlcbm")
            rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(Loc).Item("tmp_ctrsiz") = rs_SHIPGDTL_CTNETD_add.Tables("RESULT").Rows(index999).Item("tmp_ctrsiz")
            rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(Loc).Item("tmp_creusr") = rs_SHIPGDTL_CTNETD_add.Tables("RESULT").Rows(index999).Item("tmp_creusr")
            rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(Loc).Item("tmp_vbi_venno") = rs_SHIPGDTL_CTNETD_add.Tables("RESULT").Rows(index999).Item("tmp_vbi_venno")
            rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(Loc).Item("tmp_vbi_vensna") = rs_SHIPGDTL_CTNETD_add.Tables("RESULT").Rows(index999).Item("tmp_vbi_vensna")
            rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(Loc).Item("tmp_cbm") = rs_SHIPGDTL_CTNETD_add.Tables("RESULT").Rows(index999).Item("tmp_cbm")
            rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(Loc).Item("tmp_mancbm") = rs_SHIPGDTL_CTNETD_add.Tables("RESULT").Rows(index999).Item("tmp_mancbm")

        Next
        'add ad a


    End Sub

    Private Sub load_and_fill_ctnetd_each_fwd(ByVal fn As String)
        '''''''''''' Call addctnetd(fn)
        'temp



        'Dim i As Integer

        'sFilter = "scd_fwdnam = '" & fn & "'"
        'rs_SHCHGDTL.Tables("RESULT").DefaultView.RowFilter = sFilter





        'Dim sVendor As String
        'Dim sVendorName As String
        'Dim sColumn As String
        'Dim sCurr As String
        'Dim sFee As Decimal

        'Dim sTtlSYSCBM As String
        'Dim sTtlMANCBM As String
        'Dim ttlcbm_flag As Boolean

        'sTtlSYSCBM = 0
        'sTtlMANCBM = 0
        'ttlcbm_flag = False

        'sVendor = "TOTAL"



        'Dim sInvList As String
        'Dim sCusList As String
        'Dim sCusNoList As String
        'Dim sCtrsiz As String

        'If Not IsDBNull(rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_invlst")) Then
        '    sInvList = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_invlst")
        '    sCusList = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_cuslst")
        '    sCusNoList = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_cusnolst")
        '    sCtrsiz = rs_SHCHGHDR.Tables("RESULT").Rows(0).Item("sch_ctrsiz")
        'End If


        'Dim sLastVendor As String
        'sLastVendor = ""


        'Dim loc As String

        'For i = 0 To rs_SHCHGDTL.Tables("RESULT").DefaultView.Count - 1

        '    If Not IsDBNull(rs_SHCHGDTL.Tables("RESULT").DefaultView(i).Item("scd_venno")) Then
        '        sVendor = rs_SHCHGDTL.Tables("RESULT").DefaultView(i).Item("scd_venno")
        '        sVendorName = rs_SHCHGDTL.Tables("RESULT").DefaultView(i).Item("scd_vensna")
        '        sFee = rs_SHCHGDTL.Tables("RESULT").DefaultView(i).Item("scd_fee")

        '    End If

        '    If sVendor <> "TOTAL" And sVendor <> sLastVendor Then

        '        rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows.Add()

        '        loc = rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows.Count - 1

        '        rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(loc).Item("tmp_fwdnam") = fn
        '        rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(loc).Item("tmp_invlist") = sInvList
        '        rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(loc).Item("tmp_cuslist") = sCusList
        '        rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(loc).Item("tmp_cusnolist") = sCusNoList
        '        rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(loc).Item("tmp_ttlcbm") = sTtlSYSCBM
        '        rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(loc).Item("tmp_ctrsiz") = sCtrsiz
        '        rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(loc).Item("tmp_creusr") = ""
        '        rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(loc).Item("tmp_vbi_venno") = sVendor
        '        rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(loc).Item("tmp_vbi_vensna") = sVendorName
        '        rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(loc).Item("tmp_cbm") = rs_SHCHGDTL.Tables("RESULT").DefaultView(i).Item("scd_syscbm")
        '        rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(loc).Item("tmp_mancbm") = rs_SHCHGDTL.Tables("RESULT").DefaultView(i).Item("scd_mancbm")

        '        sLastVendor = sVendor
        '    End If


        'Next i



    End Sub

    Private Function display_dgSHCHGFWD()
        Dim i As Integer

        If rs_SHCHGFWD.Tables("RESULT") Is Nothing Then
            Exit Function
        End If

        dgSHCHGFWD.DataSource = rs_SHCHGFWD.Tables("RESULT")


        For i = 0 To dgSHCHGFWD.Columns.Count - 1
            Select Case i
                Case 1
                    dgSHCHGFWD.Columns(i).HeaderText = "Forwarder Name"
                    dgSHCHGFWD.Columns(i).Width = 290
                    dgSHCHGFWD.Columns(i).CellTemplate.Style.BackColor = SystemColors.Control
                Case 2
                    dgSHCHGFWD.Columns(i).HeaderText = "Invoice #"
                    dgSHCHGFWD.Columns(i).Width = 130
                    dgSHCHGFWD.Columns(i).CellTemplate.Style.BackColor = SystemColors.Control
                Case 3
                    dgSHCHGFWD.Columns(i).HeaderText = "Amount"
                    dgSHCHGFWD.Columns(i).Width = 90
                    dgSHCHGFWD.Columns(i).CellTemplate.Style.BackColor = SystemColors.Control
                Case 4
                    dgSHCHGFWD.Columns(i).HeaderText = "Currency"
                    dgSHCHGFWD.Columns(i).Width = 90
                    dgSHCHGFWD.Columns(i).CellTemplate.Style.BackColor = SystemColors.Control
                Case 5
                    dgSHCHGFWD.Columns(i).HeaderText = "FCR #"
                    dgSHCHGFWD.Columns(i).Width = 130
                    dgSHCHGFWD.Columns(i).CellTemplate.Style.BackColor = SystemColors.Control
                Case 6
                    dgSHCHGFWD.Columns(i).HeaderText = "Remark"
                    dgSHCHGFWD.Columns(i).Width = 170
                    dgSHCHGFWD.Columns(i).CellTemplate.Style.BackColor = SystemColors.Control
                Case Else
                    dgSHCHGFWD.Columns(i).HeaderText = ""
                    dgSHCHGFWD.Columns(i).Width = 0
                    dgSHCHGFWD.Columns(i).Visible = False

            End Select

            dgSHCHGFWD.Columns(i).SortMode = DataGridViewColumnSortMode.Automatic

        Next i



        dgSHCHGFWD.Refresh()



    End Function


    Private Sub dgSHCHGFWD_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSHCHGFWD.CellContentClick

    End Sub

    Private Sub dgSHCHGFWD_RowHeaderMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgSHCHGFWD.RowHeaderMouseDoubleClick

        'Exit Sub
        ''''''''''''''''''''''
        'tempz

        Dim curvalue As String

        curvalue = Trim(dgSHCHGFWD.Item(1, dgSHCHGFWD.CurrentCell.RowIndex).Value)

        For index9 As Integer = 0 To rs_SHCHGFWD.Tables("RESULT").Rows.Count - 1
            If Not IsDBNull(rs_SHCHGFWD.Tables("RESULT").Rows(index9)("scf_fwdnam")) Then
                If rs_SHCHGFWD.Tables("RESULT").Rows(index9)("scf_fwdnam") = curvalue Then
                    ReadingIndex = index9
                End If
            End If
        Next

        Call display_fwd(curvalue)
        cbofwd.Text = curvalue

        'If display_dgSHCHGDTL_Distribute(cbofwd.Text.Trim) = False Then
        '    MsgBox("Please input fees!")
        '    Exit Sub
        'End If

        flag_sub_value_change(ReadingIndex) = True
        reset_and_display_SHCHGDTL(cbofwd.Text.Trim)



        btcSHM00007.SelectedIndex = 1

        For index9 As Integer = 0 To rs_SHCHGFWD.Tables("RESULT").Rows.Count - 1
            If Not IsDBNull(rs_SHCHGFWD.Tables("RESULT").Rows(index9)("scf_fwdnam")) Then
                If rs_SHCHGFWD.Tables("RESULT").Rows(index9)("scf_fwdnam") = cbofwd.Text.Trim Then
                    'last_ReadingIndex = index9
                End If
            End If
        Next

    End Sub

    Private Sub chkDel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDel.CheckedChanged

    End Sub

    Private Sub chkDel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDel.Click
        If rs_SHCHGFWD.Tables("RESULT").Rows.Count >= 1 Then
            If chkDel.Checked = True Then
                rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("Del") = "Y"
            Else
                rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("Del") = "N"
            End If
        End If

    End Sub

    Private Sub txtconsol_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtconsol.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then
            If check_consol() Then
                Me.txtInvNoList.Text = rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(0).Item("tmp_invlist")
                Me.txtCustList.Text = rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(0).Item("tmp_cuslist")
                Me.txtCusNoList.Text = rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(0).Item("tmp_cusnolist")
                Me.cboCtnSiz.Text = rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(0).Item("tmp_ctrsiz")

                Me.gbHeaderMain.Enabled = True
                Me.cboFCurr.Enabled = True

                Call display_dgINVMORE()
                dgINVMORE.DataSource = rs_INVMORE.Tables("RESULT")

                dgINVMORE.Visible = True
                dgINVMORE.Refresh()
                gbDocTyp_D_Entry.Enabled = True
                gbDocTyp_D_Entry.Visible = True



                Me.btcSHM00007.TabPages(1).Enabled = False
                Me.btcSHM00007.TabPages(1).Enabled = True


                btcSHM00007.SelectedIndex = 0



            End If
        End If

    End Sub

    Private Sub txtconsol_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtconsol.TextChanged

    End Sub

    Sub leavepage()

        If check_fwd() = False Then
            If rs_SHCHGFWD.Tables("RESULT").Rows.Count > 0 Then
                btcSHM00007.SelectedIndex = 1
            End If
            Exit Sub
        End If

        Call fill_fwd()
        If flag_cmdInsRow_Click = True Then
            flag_cmdInsRow_Click = False
            Call addctnetd(cbofwdnam.Text.Trim)
        End If


        Dim tmp_fwd

        If rs_SHCHGFWD.Tables("RESULT").Rows.Count = 0 Then
            Exit Sub
        End If
        tmp_fwd = rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex).Item("scf_fwdnam")

        If flag_distribute_changed = True Then
            flag_distribute_changed = False
            If counter_format_dgSHCHGDTL_CORE = 0 Then
                Call format_dgSHCHGDTL_CORE()
            End If
            Call reset_and_display_dgSHCHGDTL_CORE(tmp_fwd)
        Else
            flag_sub_value_change(ReadingIndex) = True
            Call reset_and_display_SHCHGDTL(tmp_fwd)
        End If

        Me.btcSHM00007.TabPages(2).Enabled = True
    End Sub
    Sub ins_leavepage()

        If check_fwd() = False Then
            If rs_SHCHGFWD.Tables("RESULT").Rows.Count > 0 Then
                btcSHM00007.SelectedIndex = 1
            End If
            Exit Sub
        End If

        Call fill_fwd()
        If flag_cmdInsRow_Click = True Then

            Call addctnetd(cbofwdnam.Text.Trim)
        End If

        '        Call reset_and_display_SHCHGDTL(cbofwdnam.Text.Trim)
        Dim tmp_fwd
        If rs_SHCHGFWD.Tables("RESULT").Rows.Count = 0 Then
            Exit Sub
        End If
        tmp_fwd = rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex).Item("scf_fwdnam")

        If flag_distribute_changed = True Then
            flag_distribute_changed = False
            If counter_format_dgSHCHGDTL_CORE = 0 Then
                Call format_dgSHCHGDTL_CORE()
            End If
            Call reset_and_display_dgSHCHGDTL_CORE(tmp_fwd)
        Else
            flag_sub_value_change(ReadingIndex) = True
            Call reset_and_display_SHCHGDTL(tmp_fwd)
        End If

        Me.btcSHM00007.TabPages(2).Enabled = True
    End Sub


    Private Sub txtFwdInv_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFwdInv.GotFocus
        FLAG_txtFwdInv_GotFocus = True

    End Sub

    Private Sub txtFwdInv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFwdInv.KeyPress

        If e.KeyChar.Equals(Chr(13)) Then
            cboFCurr.Focus()
        End If
    End Sub

    Private Sub txtFwdInv_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFwdInv.LostFocus
        'If cbofcrno.Enabled = True Then
        '    cbofcrno.Focus()
        'Else
        '    cboFCurr.Focus()
        'End If
    End Sub

    Private Sub txtFwdInv_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFwdInv.TextChanged
        If FLAG_txtFwdInv_GotFocus = True Then
            FLAG_txtFwdInv_GotFocus = False

            If Add_flag_A(ReadingIndex) = False And upd_flag_A(ReadingIndex) = False Then
                upd_flag_A(ReadingIndex) = True
            End If

            Dim tmpstr
            tmpstr = txtFwdInv.Text.Trim
            If Not IsDBNull(rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex).Item("scf_fwdinv")) Then
                If tmpstr <> rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex).Item("scf_fwdinv") Then
                    Recordstatus = True
                    If rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex).Item("scf_creusr") <> "~*ADD*~" And rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex).Item("scf_creusr") <> "~*NEW*~" Then
                        rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex).Item("scf_creusr") = "~*UPD*~"
                    End If
                    rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex).Item("scf_fwdinv") = tmpstr
                End If
            End If


        End If
    End Sub



    Private Function check_ctnno_etddat() As Boolean

        If Me.txtCtn.Text = "" Then
            MsgBox("Container No cannot empty!")
            Me.txtCtn.Focus()
            check_ctnno_etddat = False
            Exit Function
        End If

        If IsDate(Me.mskETDDat.Text) = False Then
            MsgBox("ETD Date is invalid!")
            Me.mskETDDat.Focus()
            check_ctnno_etddat = False
            Exit Function
        End If

        gspStr = "sp_select_SHIPGDTL_CTNETD '','" & Me.txtCtn.Text & "','" & Me.mskETDDat.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SHIPGDTL_CTNETD, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SHM00007 #004 sp_select_SHIPGDTL_CTNETD : " & rtnStr)
            check_ctnno_etddat = False
            Exit Function
        Else
            If rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("Record not found!")
                check_ctnno_etddat = False
                Me.txtCtn.Focus()
                Exit Function
            Else
                cboCtnSiz.Text = rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(0)("tmp_ctrsiz")

                sfcrNo = Split(rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows(0).Item("tmp_fcrlist"), ",")
                For index99 As Integer = 0 To sfcrNo.Length - 1
                    cbofcrno.Items.Add(sfcrNo(index99))
                Next

                flag_more_than_one_fcr = False
                For j As Integer = 0 To sfcrNo.Length - 1
                    For jj As Integer = 0 To sfcrNo.Length - 1
                        If j <> jj Then
                            If sfcrNo(j) <> sfcrNo(jj) Then
                                flag_more_than_one_fcr = True
                            End If
                        End If
                    Next
                Next

                If (Not flag_more_than_one_fcr = True) And Trim(sfcrNo(0)) = "" Then
                    flag_more_than_one_fcr = True
                End If

                If flag_more_than_one_fcr = True Then
                    cbofcrno.Text = ""
                    cbofcrno.Enabled = True
                Else
                    cbofcrno.Text = sfcrNo(0)
                    cbofcrno.Enabled = False
                End If

                check_ctnno_etddat = True
                rs_SHIPGDTL_CTNETD.Tables("RESULT").Columns("tmp_creusr").ReadOnly = False
                rs_SHIPGDTL_CTNETD.Tables("RESULT").Columns("tmp_mancbm").ReadOnly = False


                rs_SHIPGDTL_CTNETD_add = rs_SHIPGDTL_CTNETD.Copy

                gspStr = "sp_select_SHIPGDTL_co '','" & Me.txtCtn.Text & "','" & Me.mskETDDat.Text & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_SHIPGDTL_co, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading SHM00007 #004 sp_select_SHIPGDTL_CTNETD : " & rtnStr)
                    check_ctnno_etddat = False
                    Exit Function
                Else

                    For index9 As Integer = 0 To rs_SHIPGDTL_co.Tables("RESULT").Rows.Count - 1
                        lstVendor.Items.Add(rs_SHIPGDTL_co.Tables("RESULT").Rows(index9)("company") & " - " & rs_SHIPGDTL_co.Tables("RESULT").Rows(index9)("company"))
                    Next


                End If



                '
            End If
        End If


    End Function




    Private Sub FillComboForwarder()
        Dim rs_syfwdcde As New DataSet

        Try
            gspStr = "sp_list_SYFWDINF '" & "" & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_syfwdcde, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00109 sp_list_SYFWDINF : " & rtnStr)
            Else
                Me.cbofwdnam.Items.Clear()
                For Each dr As DataRow In rs_syfwdcde.Tables("RESULT").Rows
                    Me.cbofwdnam.Items.Add(dr.Item("yfi_fulnam").ToString)
                Next
            End If
        Finally
            rs_syfwdcde = Nothing
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub cbofwdnam_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbofwdnam.KeyPress

        If e.KeyChar.Equals(Chr(13)) Then



            cbofwdnam.Enabled = False

            txtFwdInv.Enabled = True
            If flag_more_than_one_fcr = True Then
                cbofcrno.Text = ""
                cbofcrno.Enabled = True
            Else
                cbofcrno.Enabled = False
            End If
            cboFCurr.Enabled = True
            rtxtRmk.Enabled = True
            txtFwdInv.Focus()


            For i As Integer = 0 To rs_SHCHGFWD.Tables("result").Rows.Count - 1
                If cbofwdnam.Text.Trim = rs_SHCHGFWD.Tables("result").Rows(i).Item("scf_fwdnam") Then
                    If rs_SHCHGFWD.Tables("result").Rows(i).Item("DEL") <> "Y" _
                    And rs_SHCHGFWD.Tables("result").Rows(ReadingIndex).Item("DEL") <> "Y" Then
                        If i <> ReadingIndex Then
                            btcSHM00007.SelectedIndex = 1

                            cbofwdnam.Text = ""
                            cbofwdnam.Enabled = True

                            MsgBox("forwarder name already exist!")
                            cbofwdnam.Focus()
                            Exit Sub
                        End If
                    End If
                End If
            Next i
            '''''''''''''  dgSHCHGDTL_Distribute.Enabled = False
            dgSHCHGDTL_Distribute.ReadOnly = True


        End If

        cbofwdnam.Enabled = False
        '20150723

        '623
    End Sub

    Private Sub cbofwdnam_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbofwdnam.SelectedIndexChanged
        Dim flag_fwd_notfound
        flag_fwd_notfound = True
        For index99 As Integer = 0 To rs_SHCHGFWD.Tables("RESULT").Rows.Count - 1
            If cbofwdnam.Text.Trim = Trim(rs_SHCHGFWD.Tables("RESULT").Rows(index99)("scf_fwdnam")) _
            And Trim(rs_SHCHGFWD.Tables("RESULT").Rows(index99)("DEL")) <> "Y" _
            And ReadingIndex <> index99 Then
                flag_fwd_notfound = False
            End If
        Next

        If flag_fwd_notfound = False Then
            MsgBox("The forward name already exist!")
            cbofwdnam.SelectedIndex = -1
            cbofwdnam.Text = ""

        End If
        'check fwd name
    End Sub


    Public Sub cmdSaveClick()
        Dim modify_flag As Boolean

        Me.Cursor = Cursors.WaitCursor

        modify_flag = False
        For index9 As Integer = 0 To UBound(Add_flag_A)
            If Add_flag_A(index9) = True Then
                modify_flag = True
            End If
        Next

        For index99 As Integer = 0 To UBound(upd_flag_A)
            If upd_flag_A(index99) = True Then
                modify_flag = True
            End If
        Next

        If modify_flag = False Then
            MsgBox("Record not saved, no data change!")
            Exit Sub
        End If
        If rs_SHCHGFWD.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("No forwarder detail, Record NOT Saved! ")
            Call formInit("INIT")
            Me.txtdocno.Text = ""
            Cursor = Cursors.Default
            Exit Sub

        End If
        ' cbofwd.Text = cbofwdnam.Text.Trim

        Call leavepage()
        If fill_fwd() = False Then
            Exit Sub
        End If
        Call format_cbofwd()
        cbofwd.Text = cbofwdnam.Text.Trim

        reset_and_display_dgSHCHGDTL_CORE(rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fwdnam"))
        reset_and_display_dgSHCHGDTL_CORE(rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fwdnam"))
        Call leavepage()
        reset_and_display_dgSHCHGDTL_CORE(rs_SHCHGFWD.Tables("RESULT").Rows(ReadingIndex)("scf_fwdnam"))
        Call leavepage()
        'For index999 As Integer = 0 To rs_SHCHGFWD.Tables("RESULT").Rows.Count - 1
        '    reset_and_display_SHCHGDTL(rs_SHCHGFWD.Tables("RESULT").Rows(index999)("scf_fwdnam"))
        '    '  reset_and_display_SHCHGDTL(rs_SHCHGFWD.Tables("RESULT").Rows(index999)("scf_fwdnam"))
        '    ' calculate_dgSHCHGDTL_CORE_flag = True
        '    '   Call calculate_dgSHCHGDTL_CORE("none")
        '    '           changeManualCBM = True
        'Next

        ' Call fill_fwd()

        'If Add_flag_A(readingindex) = True Then
        If check_SHCHGHDR_SHCHGDTL() = True Then
            Dim docno As String
            docno = ""
            If save_SHCHGHDR(docno) = True Then
                MsgBox("Record Saved! Document No: " & docno)
                Call formInit("INIT")
                Me.txtdocno.Text = docno
            End If
        End If
        'End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub mskExchRat_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles mskExchRat.MaskInputRejected

    End Sub




    Private Sub smi_Copy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smi_Copy.Click
        Call menu_copy((rtxtRmk))
    End Sub

    Private Sub smi_Paste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smi_Paste.Click
        Call menu_paste((rtxtRmk))

    End Sub
    Function menu_paste(ByVal sender As RichTextBox)

        sender.Paste()


    End Function
    Function menu_undo(ByVal sender As RichTextBox)
        If sender.CanUndo = True Then
            ' Undo the last operation.
            sender.Undo()
            ' Clear the undo buffer to prevent last action from being redone.
            'sender.ClearUndo()
        End If


    End Function
    Function menu_copy(ByVal sender As RichTextBox)
        If sender.SelectionLength > 0 Then
            ' Copy the selected text to the Clipboard.
            sender.Copy()
        End If


    End Function
    Function menu_convert(ByVal sender As RichTextBox)
        '   sender.Rtf = sender.Text
        sender.Text = sender.Text.ToString



    End Function
    Private Sub ConvertToPlainTextToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConvertToPlainTextToolStripMenuItem.Click
        Call menu_convert((rtxtRmk))

        '''
    End Sub

    Private Sub UndoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UndoToolStripMenuItem.Click

        Call menu_undo((rtxtRmk))

    End Sub

    'Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click

    '    'Dim frmSYM00018 As New SYM00018


    '    ''20130909  
    '    'gsCompany = ""
    '    ''tempz
    '    'Call Update_gs_Value(gsCompany)


    '    'frmSYM00018.keyName = txtGRNNo.Name
    '    'frmSYM00018.strModule = "GT"

    '    'frmSYM00018.show_frmSYM00018(Me)



    'End Sub


    Private Sub SetStatusBar(ByVal mode As String)

        If mode = "INIT" Then
            Me.StatusBar.Items("lblLeft").Text = "Init"
        ElseIf mode = "UPD" Then
            Me.StatusBar.Items("lblLeft").Text = "Updating"
        ElseIf mode = "READ" Then
            Me.StatusBar.Items("lblLeft").Text = "Read Only"
        ElseIf mode = "ADD" Then
            Me.StatusBar.Items("lblLeft").Text = "Insert Record"
        End If

    End Sub

    Private Sub mmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdPrint.Click
        FrmSHR00010 = New SHR00010
        FrmSHR00010.txtdocno.Text = txtdocno.Text
        FrmSHR00010.txtdocno.Enabled = False
        FrmSHR00010.cmdShow.Enabled = True
        FrmSHR00010.ShowDialog()
    End Sub

    
End Class













