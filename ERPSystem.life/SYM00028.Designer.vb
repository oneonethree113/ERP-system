<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SYM00028
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SYM00028))
        Me.StatusBar = New System.Windows.Forms.StatusStrip
        Me.lblLeft = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblRight = New System.Windows.Forms.ToolStripStatusLabel
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.ComboBox2 = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.ComboBox3 = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.ComboBox4 = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.cmdRefresh = New System.Windows.Forms.Button
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
        Me.panSalRep = New System.Windows.Forms.Panel
        Me.chkPanSalRepDefault = New System.Windows.Forms.CheckBox
        Me.cboPanSalRepSalRep = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cboPanSalRepSalTeam = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmdPanSalRepInsert = New System.Windows.Forms.Button
        Me.cmdPanSalRepCancel = New System.Windows.Forms.Button
        Me.panSalMngr = New System.Windows.Forms.Panel
        Me.cboPanSalMngrSalMngr = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboPanSalMngrSalDiv = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdPanSalMngrInsert = New System.Windows.Forms.Button
        Me.cmdPanSalMngrUpdate = New System.Windows.Forms.Button
        Me.cmdPanSalMngrCancel = New System.Windows.Forms.Button
        Me.tabFrame = New ERPSystem.BaseTabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.grpSalRep = New System.Windows.Forms.GroupBox
        Me.panSalTeam = New System.Windows.Forms.Panel
        Me.txtPanSalTeamSalTeam = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboPanSalTeamSalDiv = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmdPanSalTeamInsert = New System.Windows.Forms.Button
        Me.cmdPanSalTeamUpdate = New System.Windows.Forms.Button
        Me.cmdPanSalTeamCancel = New System.Windows.Forms.Button
        Me.dgSalRep = New System.Windows.Forms.DataGridView
        Me.cboSalesTeam = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.grpSalMngr = New System.Windows.Forms.GroupBox
        Me.dgSalMgr = New System.Windows.Forms.DataGridView
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.grpSalTeam = New System.Windows.Forms.GroupBox
        Me.dgSalTeam = New System.Windows.Forms.DataGridView
        Me.StatusBar.SuspendLayout()
        Me.menuStrip.SuspendLayout()
        Me.panSalRep.SuspendLayout()
        Me.panSalMngr.SuspendLayout()
        Me.tabFrame.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.grpSalRep.SuspendLayout()
        Me.panSalTeam.SuspendLayout()
        CType(Me.dgSalRep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.grpSalMngr.SuspendLayout()
        CType(Me.dgSalMgr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.grpSalTeam.SuspendLayout()
        CType(Me.dgSalTeam, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusBar
        '
        Me.StatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblLeft, Me.lblRight})
        Me.StatusBar.Location = New System.Drawing.Point(0, 607)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Size = New System.Drawing.Size(954, 24)
        Me.StatusBar.TabIndex = 174
        Me.StatusBar.Text = "StatusStrip1"
        '
        'lblLeft
        '
        Me.lblLeft.AutoSize = False
        Me.lblLeft.Name = "lblLeft"
        Me.lblLeft.Size = New System.Drawing.Size(400, 19)
        Me.lblLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRight
        '
        Me.lblRight.AutoSize = False
        Me.lblRight.Name = "lblRight"
        Me.lblRight.Size = New System.Drawing.Size(539, 19)
        Me.lblRight.Spring = True
        Me.lblRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(108, 45)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(201, 20)
        Me.ComboBox1.TabIndex = 135
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 134
        Me.Label3.Text = "Sales Manager"
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(108, 18)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(201, 20)
        Me.ComboBox2.TabIndex = 133
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(24, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 132
        Me.Label4.Text = "Sales Division"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(122, 83)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(65, 21)
        Me.Button1.TabIndex = 129
        Me.Button1.Text = "&Insert"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(193, 83)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(65, 21)
        Me.Button2.TabIndex = 130
        Me.Button2.Text = "&Update"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(264, 83)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(65, 22)
        Me.Button3.TabIndex = 131
        Me.Button3.Text = "&Quit"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ComboBox3
        '
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(108, 45)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(201, 20)
        Me.ComboBox3.TabIndex = 135
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(24, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 13)
        Me.Label5.TabIndex = 134
        Me.Label5.Text = "Sales Manager"
        '
        'ComboBox4
        '
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Location = New System.Drawing.Point(108, 18)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(201, 20)
        Me.ComboBox4.TabIndex = 133
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(24, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 13)
        Me.Label6.TabIndex = 132
        Me.Label6.Text = "Sales Division"
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(122, 83)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(65, 21)
        Me.Button4.TabIndex = 129
        Me.Button4.Text = "&Insert"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(193, 83)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(65, 21)
        Me.Button5.TabIndex = 130
        Me.Button5.Text = "&Update"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Location = New System.Drawing.Point(264, 83)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(65, 22)
        Me.Button6.TabIndex = 131
        Me.Button6.Text = "&Quit"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Location = New System.Drawing.Point(825, 24)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(79, 21)
        Me.cmdRefresh.TabIndex = 175
        Me.cmdRefresh.TabStop = False
        Me.cmdRefresh.Text = "Refresh"
        '
        'menuStrip
        '
        Me.menuStrip.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mmdAdd, Me.mmdSave, Me.mmdDelete, Me.mmdCopy, Me.mmdFind, Me.t1, Me.mmdClear, Me.t2, Me.mmdSearch, Me.t3, Me.mmdInsRow, Me.mmdDelRow, Me.t4, Me.mmdPrint, Me.t5, Me.mmdAttach, Me.t6, Me.mmdFunction, Me.t7, Me.mmdLink, Me.t8, Me.mmdExit})
        Me.menuStrip.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip.Name = "menuStrip"
        Me.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.menuStrip.Size = New System.Drawing.Size(954, 24)
        Me.menuStrip.TabIndex = 213
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
        'panSalRep
        '
        Me.panSalRep.BackColor = System.Drawing.Color.SkyBlue
        Me.panSalRep.Controls.Add(Me.chkPanSalRepDefault)
        Me.panSalRep.Controls.Add(Me.cboPanSalRepSalRep)
        Me.panSalRep.Controls.Add(Me.Label9)
        Me.panSalRep.Controls.Add(Me.cboPanSalRepSalTeam)
        Me.panSalRep.Controls.Add(Me.Label10)
        Me.panSalRep.Controls.Add(Me.cmdPanSalRepInsert)
        Me.panSalRep.Controls.Add(Me.cmdPanSalRepCancel)
        Me.panSalRep.Location = New System.Drawing.Point(371, 56)
        Me.panSalRep.Name = "panSalRep"
        Me.panSalRep.Size = New System.Drawing.Size(441, 137)
        Me.panSalRep.TabIndex = 3
        Me.panSalRep.Visible = False
        '
        'chkPanSalRepDefault
        '
        Me.chkPanSalRepDefault.AutoSize = True
        Me.chkPanSalRepDefault.Location = New System.Drawing.Point(126, 72)
        Me.chkPanSalRepDefault.Name = "chkPanSalRepDefault"
        Me.chkPanSalRepDefault.Size = New System.Drawing.Size(106, 16)
        Me.chkPanSalRepDefault.TabIndex = 136
        Me.chkPanSalRepDefault.Text = "Default Sales Rep"
        Me.chkPanSalRepDefault.UseVisualStyleBackColor = True
        '
        'cboPanSalRepSalRep
        '
        Me.cboPanSalRepSalRep.BackColor = System.Drawing.Color.White
        Me.cboPanSalRepSalRep.FormattingEnabled = True
        Me.cboPanSalRepSalRep.Location = New System.Drawing.Point(86, 45)
        Me.cboPanSalRepSalRep.Name = "cboPanSalRepSalRep"
        Me.cboPanSalRepSalRep.Size = New System.Drawing.Size(320, 20)
        Me.cboPanSalRepSalRep.TabIndex = 135
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(17, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(50, 12)
        Me.Label9.TabIndex = 134
        Me.Label9.Text = "Sales Rep"
        '
        'cboPanSalRepSalTeam
        '
        Me.cboPanSalRepSalTeam.BackColor = System.Drawing.Color.White
        Me.cboPanSalRepSalTeam.FormattingEnabled = True
        Me.cboPanSalRepSalTeam.Location = New System.Drawing.Point(86, 18)
        Me.cboPanSalRepSalTeam.Name = "cboPanSalRepSalTeam"
        Me.cboPanSalRepSalTeam.Size = New System.Drawing.Size(320, 20)
        Me.cboPanSalRepSalTeam.TabIndex = 133
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(17, 21)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 12)
        Me.Label10.TabIndex = 132
        Me.Label10.Text = "Sales Team"
        '
        'cmdPanSalRepInsert
        '
        Me.cmdPanSalRepInsert.Location = New System.Drawing.Point(193, 103)
        Me.cmdPanSalRepInsert.Name = "cmdPanSalRepInsert"
        Me.cmdPanSalRepInsert.Size = New System.Drawing.Size(65, 21)
        Me.cmdPanSalRepInsert.TabIndex = 129
        Me.cmdPanSalRepInsert.Text = "&Insert"
        Me.cmdPanSalRepInsert.UseVisualStyleBackColor = True
        '
        'cmdPanSalRepCancel
        '
        Me.cmdPanSalRepCancel.Location = New System.Drawing.Point(264, 103)
        Me.cmdPanSalRepCancel.Name = "cmdPanSalRepCancel"
        Me.cmdPanSalRepCancel.Size = New System.Drawing.Size(65, 22)
        Me.cmdPanSalRepCancel.TabIndex = 131
        Me.cmdPanSalRepCancel.Text = "&Quit"
        Me.cmdPanSalRepCancel.UseVisualStyleBackColor = True
        '
        'panSalMngr
        '
        Me.panSalMngr.BackColor = System.Drawing.Color.SkyBlue
        Me.panSalMngr.Controls.Add(Me.cboPanSalMngrSalMngr)
        Me.panSalMngr.Controls.Add(Me.Label2)
        Me.panSalMngr.Controls.Add(Me.cboPanSalMngrSalDiv)
        Me.panSalMngr.Controls.Add(Me.Label1)
        Me.panSalMngr.Controls.Add(Me.cmdPanSalMngrInsert)
        Me.panSalMngr.Controls.Add(Me.cmdPanSalMngrUpdate)
        Me.panSalMngr.Controls.Add(Me.cmdPanSalMngrCancel)
        Me.panSalMngr.Location = New System.Drawing.Point(347, 97)
        Me.panSalMngr.Name = "panSalMngr"
        Me.panSalMngr.Size = New System.Drawing.Size(457, 117)
        Me.panSalMngr.TabIndex = 2
        Me.panSalMngr.Visible = False
        '
        'cboPanSalMngrSalMngr
        '
        Me.cboPanSalMngrSalMngr.BackColor = System.Drawing.Color.White
        Me.cboPanSalMngrSalMngr.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.cboPanSalMngrSalMngr.FormattingEnabled = True
        Me.cboPanSalMngrSalMngr.Location = New System.Drawing.Point(108, 45)
        Me.cboPanSalMngrSalMngr.Name = "cboPanSalMngrSalMngr"
        Me.cboPanSalMngrSalMngr.Size = New System.Drawing.Size(320, 22)
        Me.cboPanSalMngrSalMngr.TabIndex = 135
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 12)
        Me.Label2.TabIndex = 134
        Me.Label2.Text = "Sales Manager"
        '
        'cboPanSalMngrSalDiv
        '
        Me.cboPanSalMngrSalDiv.BackColor = System.Drawing.Color.White
        Me.cboPanSalMngrSalDiv.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.cboPanSalMngrSalDiv.FormattingEnabled = True
        Me.cboPanSalMngrSalDiv.Location = New System.Drawing.Point(108, 18)
        Me.cboPanSalMngrSalDiv.Name = "cboPanSalMngrSalDiv"
        Me.cboPanSalMngrSalDiv.Size = New System.Drawing.Size(320, 22)
        Me.cboPanSalMngrSalDiv.TabIndex = 133
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 12)
        Me.Label1.TabIndex = 132
        Me.Label1.Text = "Sales Division"
        '
        'cmdPanSalMngrInsert
        '
        Me.cmdPanSalMngrInsert.Location = New System.Drawing.Point(144, 83)
        Me.cmdPanSalMngrInsert.Name = "cmdPanSalMngrInsert"
        Me.cmdPanSalMngrInsert.Size = New System.Drawing.Size(65, 21)
        Me.cmdPanSalMngrInsert.TabIndex = 129
        Me.cmdPanSalMngrInsert.Text = "&Insert"
        Me.cmdPanSalMngrInsert.UseVisualStyleBackColor = True
        '
        'cmdPanSalMngrUpdate
        '
        Me.cmdPanSalMngrUpdate.Location = New System.Drawing.Point(215, 83)
        Me.cmdPanSalMngrUpdate.Name = "cmdPanSalMngrUpdate"
        Me.cmdPanSalMngrUpdate.Size = New System.Drawing.Size(65, 21)
        Me.cmdPanSalMngrUpdate.TabIndex = 130
        Me.cmdPanSalMngrUpdate.Text = "&Update"
        Me.cmdPanSalMngrUpdate.UseVisualStyleBackColor = True
        '
        'cmdPanSalMngrCancel
        '
        Me.cmdPanSalMngrCancel.Location = New System.Drawing.Point(286, 83)
        Me.cmdPanSalMngrCancel.Name = "cmdPanSalMngrCancel"
        Me.cmdPanSalMngrCancel.Size = New System.Drawing.Size(65, 22)
        Me.cmdPanSalMngrCancel.TabIndex = 131
        Me.cmdPanSalMngrCancel.Text = "&Quit"
        Me.cmdPanSalMngrCancel.UseVisualStyleBackColor = True
        '
        'tabFrame
        '
        Me.tabFrame.Controls.Add(Me.TabPage1)
        Me.tabFrame.Controls.Add(Me.TabPage2)
        Me.tabFrame.Controls.Add(Me.TabPage3)
        Me.tabFrame.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.tabFrame.ItemSize = New System.Drawing.Size(120, 20)
        Me.tabFrame.Location = New System.Drawing.Point(0, 27)
        Me.tabFrame.Name = "tabFrame"
        Me.tabFrame.SelectedIndex = 0
        Me.tabFrame.Size = New System.Drawing.Size(954, 579)
        Me.tabFrame.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabFrame.TabIndex = 173
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.grpSalRep)
        Me.TabPage1.Controls.Add(Me.cboSalesTeam)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(946, 551)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "(1) Sales Rep"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'grpSalRep
        '
        Me.grpSalRep.Controls.Add(Me.panSalTeam)
        Me.grpSalRep.Controls.Add(Me.dgSalRep)
        Me.grpSalRep.Location = New System.Drawing.Point(2, 23)
        Me.grpSalRep.Name = "grpSalRep"
        Me.grpSalRep.Size = New System.Drawing.Size(944, 525)
        Me.grpSalRep.TabIndex = 1
        Me.grpSalRep.TabStop = False
        '
        'panSalTeam
        '
        Me.panSalTeam.BackColor = System.Drawing.Color.SkyBlue
        Me.panSalTeam.Controls.Add(Me.txtPanSalTeamSalTeam)
        Me.panSalTeam.Controls.Add(Me.Label7)
        Me.panSalTeam.Controls.Add(Me.cboPanSalTeamSalDiv)
        Me.panSalTeam.Controls.Add(Me.Label8)
        Me.panSalTeam.Controls.Add(Me.cmdPanSalTeamInsert)
        Me.panSalTeam.Controls.Add(Me.cmdPanSalTeamUpdate)
        Me.panSalTeam.Controls.Add(Me.cmdPanSalTeamCancel)
        Me.panSalTeam.Location = New System.Drawing.Point(286, 93)
        Me.panSalTeam.Name = "panSalTeam"
        Me.panSalTeam.Size = New System.Drawing.Size(448, 117)
        Me.panSalTeam.TabIndex = 175
        Me.panSalTeam.Visible = False
        '
        'txtPanSalTeamSalTeam
        '
        Me.txtPanSalTeamSalTeam.BackColor = System.Drawing.Color.White
        Me.txtPanSalTeamSalTeam.Location = New System.Drawing.Point(108, 45)
        Me.txtPanSalTeamSalTeam.Name = "txtPanSalTeamSalTeam"
        Me.txtPanSalTeamSalTeam.Size = New System.Drawing.Size(320, 22)
        Me.txtPanSalTeamSalTeam.TabIndex = 135
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(24, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 12)
        Me.Label7.TabIndex = 134
        Me.Label7.Text = "Sales Team"
        '
        'cboPanSalTeamSalDiv
        '
        Me.cboPanSalTeamSalDiv.BackColor = System.Drawing.Color.White
        Me.cboPanSalTeamSalDiv.FormattingEnabled = True
        Me.cboPanSalTeamSalDiv.Location = New System.Drawing.Point(108, 18)
        Me.cboPanSalTeamSalDiv.Name = "cboPanSalTeamSalDiv"
        Me.cboPanSalTeamSalDiv.Size = New System.Drawing.Size(320, 20)
        Me.cboPanSalTeamSalDiv.TabIndex = 133
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(24, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 12)
        Me.Label8.TabIndex = 132
        Me.Label8.Text = "Sales Division"
        '
        'cmdPanSalTeamInsert
        '
        Me.cmdPanSalTeamInsert.Location = New System.Drawing.Point(129, 83)
        Me.cmdPanSalTeamInsert.Name = "cmdPanSalTeamInsert"
        Me.cmdPanSalTeamInsert.Size = New System.Drawing.Size(65, 21)
        Me.cmdPanSalTeamInsert.TabIndex = 129
        Me.cmdPanSalTeamInsert.Text = "&Insert"
        Me.cmdPanSalTeamInsert.UseVisualStyleBackColor = True
        '
        'cmdPanSalTeamUpdate
        '
        Me.cmdPanSalTeamUpdate.Location = New System.Drawing.Point(200, 83)
        Me.cmdPanSalTeamUpdate.Name = "cmdPanSalTeamUpdate"
        Me.cmdPanSalTeamUpdate.Size = New System.Drawing.Size(65, 21)
        Me.cmdPanSalTeamUpdate.TabIndex = 130
        Me.cmdPanSalTeamUpdate.Text = "&Update"
        Me.cmdPanSalTeamUpdate.UseVisualStyleBackColor = True
        '
        'cmdPanSalTeamCancel
        '
        Me.cmdPanSalTeamCancel.Location = New System.Drawing.Point(271, 83)
        Me.cmdPanSalTeamCancel.Name = "cmdPanSalTeamCancel"
        Me.cmdPanSalTeamCancel.Size = New System.Drawing.Size(65, 22)
        Me.cmdPanSalTeamCancel.TabIndex = 131
        Me.cmdPanSalTeamCancel.Text = "&Quit"
        Me.cmdPanSalTeamCancel.UseVisualStyleBackColor = True
        '
        'dgSalRep
        '
        Me.dgSalRep.AllowUserToAddRows = False
        Me.dgSalRep.AllowUserToDeleteRows = False
        Me.dgSalRep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSalRep.Location = New System.Drawing.Point(13, 10)
        Me.dgSalRep.Name = "dgSalRep"
        Me.dgSalRep.ReadOnly = True
        Me.dgSalRep.RowTemplate.Height = 20
        Me.dgSalRep.Size = New System.Drawing.Size(923, 512)
        Me.dgSalRep.TabIndex = 1
        '
        'cboSalesTeam
        '
        Me.cboSalesTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSalesTeam.FormattingEnabled = True
        Me.cboSalesTeam.Location = New System.Drawing.Point(146, 4)
        Me.cboSalesTeam.Name = "cboSalesTeam"
        Me.cboSalesTeam.Size = New System.Drawing.Size(134, 20)
        Me.cboSalesTeam.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(19, 8)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(99, 12)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "View Selected Team"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.grpSalMngr)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(946, 551)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "(2) Sales Manager"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'grpSalMngr
        '
        Me.grpSalMngr.Controls.Add(Me.dgSalMgr)
        Me.grpSalMngr.Location = New System.Drawing.Point(6, 3)
        Me.grpSalMngr.Name = "grpSalMngr"
        Me.grpSalMngr.Size = New System.Drawing.Size(937, 545)
        Me.grpSalMngr.TabIndex = 1
        Me.grpSalMngr.TabStop = False
        '
        'dgSalMgr
        '
        Me.dgSalMgr.AllowUserToAddRows = False
        Me.dgSalMgr.AllowUserToDeleteRows = False
        Me.dgSalMgr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSalMgr.Location = New System.Drawing.Point(4, 12)
        Me.dgSalMgr.Name = "dgSalMgr"
        Me.dgSalMgr.ReadOnly = True
        Me.dgSalMgr.RowTemplate.Height = 20
        Me.dgSalMgr.Size = New System.Drawing.Size(933, 530)
        Me.dgSalMgr.TabIndex = 1
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.grpSalTeam)
        Me.TabPage3.Location = New System.Drawing.Point(4, 24)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(946, 551)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "(3) Sales Team"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'grpSalTeam
        '
        Me.grpSalTeam.Controls.Add(Me.dgSalTeam)
        Me.grpSalTeam.Location = New System.Drawing.Point(6, 3)
        Me.grpSalTeam.Name = "grpSalTeam"
        Me.grpSalTeam.Size = New System.Drawing.Size(937, 545)
        Me.grpSalTeam.TabIndex = 1
        Me.grpSalTeam.TabStop = False
        '
        'dgSalTeam
        '
        Me.dgSalTeam.AllowUserToAddRows = False
        Me.dgSalTeam.AllowUserToDeleteRows = False
        Me.dgSalTeam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSalTeam.Location = New System.Drawing.Point(4, 12)
        Me.dgSalTeam.Name = "dgSalTeam"
        Me.dgSalTeam.ReadOnly = True
        Me.dgSalTeam.RowTemplate.Height = 20
        Me.dgSalTeam.Size = New System.Drawing.Size(933, 530)
        Me.dgSalTeam.TabIndex = 1
        '
        'SYM00028
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(954, 631)
        Me.Controls.Add(Me.panSalMngr)
        Me.Controls.Add(Me.panSalRep)
        Me.Controls.Add(Me.cmdRefresh)
        Me.Controls.Add(Me.menuStrip)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.tabFrame)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.menuStrip
        Me.Name = "SYM00028"
        Me.Text = "SYM00028 - Sales Team Maintenance (SYM28)"
        Me.StatusBar.ResumeLayout(False)
        Me.StatusBar.PerformLayout()
        Me.menuStrip.ResumeLayout(False)
        Me.menuStrip.PerformLayout()
        Me.panSalRep.ResumeLayout(False)
        Me.panSalRep.PerformLayout()
        Me.panSalMngr.ResumeLayout(False)
        Me.panSalMngr.PerformLayout()
        Me.tabFrame.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.grpSalRep.ResumeLayout(False)
        Me.panSalTeam.ResumeLayout(False)
        Me.panSalTeam.PerformLayout()
        CType(Me.dgSalRep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.grpSalMngr.ResumeLayout(False)
        CType(Me.dgSalMgr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.grpSalTeam.ResumeLayout(False)
        CType(Me.dgSalTeam, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tabFrame As ERPSystem.BaseTabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents StatusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents lblLeft As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblRight As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents grpSalMngr As System.Windows.Forms.GroupBox
    Friend WithEvents grpSalTeam As System.Windows.Forms.GroupBox
    Friend WithEvents grpSalRep As System.Windows.Forms.GroupBox
    Friend WithEvents dgSalRep As System.Windows.Forms.DataGridView
    Friend WithEvents dgSalMgr As System.Windows.Forms.DataGridView
    Friend WithEvents dgSalTeam As System.Windows.Forms.DataGridView
    Friend WithEvents panSalMngr As System.Windows.Forms.Panel
    Friend WithEvents cmdPanSalMngrInsert As System.Windows.Forms.Button
    Friend WithEvents cmdPanSalMngrUpdate As System.Windows.Forms.Button
    Friend WithEvents cmdPanSalMngrCancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboPanSalMngrSalDiv As System.Windows.Forms.ComboBox
    Friend WithEvents cboPanSalMngrSalMngr As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents panSalTeam As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboPanSalTeamSalDiv As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmdPanSalTeamInsert As System.Windows.Forms.Button
    Friend WithEvents cmdPanSalTeamUpdate As System.Windows.Forms.Button
    Friend WithEvents cmdPanSalTeamCancel As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ComboBox4 As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents txtPanSalTeamSalTeam As System.Windows.Forms.TextBox
    Friend WithEvents panSalRep As System.Windows.Forms.Panel
    Friend WithEvents cboPanSalRepSalRep As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboPanSalRepSalTeam As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmdPanSalRepInsert As System.Windows.Forms.Button
    Friend WithEvents cmdPanSalRepCancel As System.Windows.Forms.Button
    Friend WithEvents chkPanSalRepDefault As System.Windows.Forms.CheckBox
    Friend WithEvents cboSalesTeam As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
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
