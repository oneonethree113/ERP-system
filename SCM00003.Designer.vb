<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SCM00003
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SCM00003))
        Me.grpUpdate = New System.Windows.Forms.GroupBox
        Me.txtToApply = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Button32 = New System.Windows.Forms.Button
        Me.cmdApply = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtFromApply = New System.Windows.Forms.TextBox
        Me.Button30 = New System.Windows.Forms.Button
        Me.optNo = New System.Windows.Forms.RadioButton
        Me.optYes = New System.Windows.Forms.RadioButton
        Me.Button29 = New System.Windows.Forms.Button
        Me.Button17 = New System.Windows.Forms.Button
        Me.Button18 = New System.Windows.Forms.Button
        Me.Button28 = New System.Windows.Forms.Button
        Me.Button19 = New System.Windows.Forms.Button
        Me.Button20 = New System.Windows.Forms.Button
        Me.Button27 = New System.Windows.Forms.Button
        Me.Button21 = New System.Windows.Forms.Button
        Me.Button22 = New System.Windows.Forms.Button
        Me.Button26 = New System.Windows.Forms.Button
        Me.Button23 = New System.Windows.Forms.Button
        Me.Button24 = New System.Windows.Forms.Button
        Me.Button25 = New System.Windows.Forms.Button
        Me.grpJobOrd = New System.Windows.Forms.GroupBox
        Me.cmdJobOrd = New System.Windows.Forms.Button
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
        Me.t7 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdLink = New System.Windows.Forms.ToolStripMenuItem
        Me.t8 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdExit = New System.Windows.Forms.ToolStripMenuItem
        Me.tabFrame = New ERPSystem.BaseTabControl
        Me.tabExceptionRecord = New System.Windows.Forms.TabPage
        Me.grdSummary = New System.Windows.Forms.DataGridView
        Me.cmdExportExp = New System.Windows.Forms.Button
        Me.tabUpdateLog = New System.Windows.Forms.TabPage
        Me.grdErrLog = New System.Windows.Forms.DataGridView
        Me.cmdExportLog = New System.Windows.Forms.Button
        Me.grpUpdate.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.grpJobOrd.SuspendLayout()
        Me.StatusBar.SuspendLayout()
        Me.menuStrip.SuspendLayout()
        Me.tabFrame.SuspendLayout()
        Me.tabExceptionRecord.SuspendLayout()
        CType(Me.grdSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabUpdateLog.SuspendLayout()
        CType(Me.grdErrLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpUpdate
        '
        Me.grpUpdate.Controls.Add(Me.txtToApply)
        Me.grpUpdate.Controls.Add(Me.GroupBox4)
        Me.grpUpdate.Controls.Add(Me.cmdApply)
        Me.grpUpdate.Controls.Add(Me.Label1)
        Me.grpUpdate.Controls.Add(Me.txtFromApply)
        Me.grpUpdate.Controls.Add(Me.Button30)
        Me.grpUpdate.Controls.Add(Me.optNo)
        Me.grpUpdate.Controls.Add(Me.optYes)
        Me.grpUpdate.Controls.Add(Me.Button29)
        Me.grpUpdate.Controls.Add(Me.Button17)
        Me.grpUpdate.Controls.Add(Me.Button18)
        Me.grpUpdate.Controls.Add(Me.Button28)
        Me.grpUpdate.Controls.Add(Me.Button19)
        Me.grpUpdate.Controls.Add(Me.Button20)
        Me.grpUpdate.Controls.Add(Me.Button27)
        Me.grpUpdate.Controls.Add(Me.Button21)
        Me.grpUpdate.Controls.Add(Me.Button22)
        Me.grpUpdate.Controls.Add(Me.Button26)
        Me.grpUpdate.Controls.Add(Me.Button23)
        Me.grpUpdate.Controls.Add(Me.Button24)
        Me.grpUpdate.Controls.Add(Me.Button25)
        Me.grpUpdate.Location = New System.Drawing.Point(13, 27)
        Me.grpUpdate.Name = "grpUpdate"
        Me.grpUpdate.Size = New System.Drawing.Size(295, 42)
        Me.grpUpdate.TabIndex = 15
        Me.grpUpdate.TabStop = False
        Me.grpUpdate.Text = "Update"
        '
        'txtToApply
        '
        Me.txtToApply.Location = New System.Drawing.Point(181, 16)
        Me.txtToApply.Name = "txtToApply"
        Me.txtToApply.Size = New System.Drawing.Size(51, 22)
        Me.txtToApply.TabIndex = 4
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Button32)
        Me.GroupBox4.Location = New System.Drawing.Point(301, 0)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(86, 42)
        Me.GroupBox4.TabIndex = 16
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Job Order"
        '
        'Button32
        '
        Me.Button32.Location = New System.Drawing.Point(17, 14)
        Me.Button32.Name = "Button32"
        Me.Button32.Size = New System.Drawing.Size(52, 21)
        Me.Button32.TabIndex = 0
        Me.Button32.Text = "..."
        Me.Button32.UseVisualStyleBackColor = True
        '
        'cmdApply
        '
        Me.cmdApply.Location = New System.Drawing.Point(238, 14)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.Size = New System.Drawing.Size(51, 21)
        Me.cmdApply.TabIndex = 5
        Me.cmdApply.Text = "Apply"
        Me.cmdApply.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(159, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(14, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "to"
        '
        'txtFromApply
        '
        Me.txtFromApply.Location = New System.Drawing.Point(102, 16)
        Me.txtFromApply.Name = "txtFromApply"
        Me.txtFromApply.Size = New System.Drawing.Size(51, 22)
        Me.txtFromApply.TabIndex = 2
        '
        'Button30
        '
        Me.Button30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button30.Location = New System.Drawing.Point(63, -26)
        Me.Button30.Name = "Button30"
        Me.Button30.Size = New System.Drawing.Size(56, 23)
        Me.Button30.TabIndex = 7
        Me.Button30.TabStop = False
        Me.Button30.Text = "I&ns Row"
        Me.Button30.UseVisualStyleBackColor = True
        '
        'optNo
        '
        Me.optNo.AutoSize = True
        Me.optNo.Location = New System.Drawing.Point(57, 17)
        Me.optNo.Name = "optNo"
        Me.optNo.Size = New System.Drawing.Size(37, 16)
        Me.optNo.TabIndex = 1
        Me.optNo.TabStop = True
        Me.optNo.Text = "No"
        Me.optNo.UseVisualStyleBackColor = True
        '
        'optYes
        '
        Me.optYes.AutoSize = True
        Me.optYes.Checked = True
        Me.optYes.Location = New System.Drawing.Point(7, 17)
        Me.optYes.Name = "optYes"
        Me.optYes.Size = New System.Drawing.Size(40, 16)
        Me.optYes.TabIndex = 0
        Me.optYes.TabStop = True
        Me.optYes.Text = "Yes"
        Me.optYes.UseVisualStyleBackColor = True
        '
        'Button29
        '
        Me.Button29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button29.Location = New System.Drawing.Point(-237, -26)
        Me.Button29.Name = "Button29"
        Me.Button29.Size = New System.Drawing.Size(56, 23)
        Me.Button29.TabIndex = 2
        Me.Button29.TabStop = False
        Me.Button29.Text = "&Delete"
        '
        'Button17
        '
        Me.Button17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button17.Location = New System.Drawing.Point(-7, -26)
        Me.Button17.Name = "Button17"
        Me.Button17.Size = New System.Drawing.Size(64, 23)
        Me.Button17.TabIndex = 6
        Me.Button17.TabStop = False
        Me.Button17.Text = "Searc&h"
        '
        'Button18
        '
        Me.Button18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button18.Location = New System.Drawing.Point(181, -26)
        Me.Button18.Name = "Button18"
        Me.Button18.Size = New System.Drawing.Size(40, 23)
        Me.Button18.TabIndex = 9
        Me.Button18.TabStop = False
        Me.Button18.Text = "|<<"
        '
        'Button28
        '
        Me.Button28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button28.Location = New System.Drawing.Point(-293, -26)
        Me.Button28.Name = "Button28"
        Me.Button28.Size = New System.Drawing.Size(56, 23)
        Me.Button28.TabIndex = 1
        Me.Button28.TabStop = False
        Me.Button28.Text = "&Save"
        '
        'Button19
        '
        Me.Button19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button19.Location = New System.Drawing.Point(119, -26)
        Me.Button19.Name = "Button19"
        Me.Button19.Size = New System.Drawing.Size(56, 23)
        Me.Button19.TabIndex = 8
        Me.Button19.TabStop = False
        Me.Button19.Text = "Del Ro&w"
        '
        'Button20
        '
        Me.Button20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button20.Location = New System.Drawing.Point(347, -26)
        Me.Button20.Name = "Button20"
        Me.Button20.Size = New System.Drawing.Size(56, 23)
        Me.Button20.TabIndex = 13
        Me.Button20.TabStop = False
        Me.Button20.Text = "E&xit"
        '
        'Button27
        '
        Me.Button27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button27.Location = New System.Drawing.Point(301, -26)
        Me.Button27.Name = "Button27"
        Me.Button27.Size = New System.Drawing.Size(40, 23)
        Me.Button27.TabIndex = 12
        Me.Button27.TabStop = False
        Me.Button27.Text = ">>|"
        '
        'Button21
        '
        Me.Button21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button21.Location = New System.Drawing.Point(-69, -26)
        Me.Button21.Name = "Button21"
        Me.Button21.Size = New System.Drawing.Size(56, 23)
        Me.Button21.TabIndex = 5
        Me.Button21.TabStop = False
        Me.Button21.Text = "Cl&ear"
        '
        'Button22
        '
        Me.Button22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button22.Location = New System.Drawing.Point(-181, -26)
        Me.Button22.Name = "Button22"
        Me.Button22.Size = New System.Drawing.Size(56, 23)
        Me.Button22.TabIndex = 3
        Me.Button22.TabStop = False
        Me.Button22.Text = "&Copy"
        '
        'Button26
        '
        Me.Button26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button26.Location = New System.Drawing.Point(221, -26)
        Me.Button26.Name = "Button26"
        Me.Button26.Size = New System.Drawing.Size(40, 23)
        Me.Button26.TabIndex = 10
        Me.Button26.TabStop = False
        Me.Button26.Text = "<"
        '
        'Button23
        '
        Me.Button23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button23.Location = New System.Drawing.Point(-125, -26)
        Me.Button23.Name = "Button23"
        Me.Button23.Size = New System.Drawing.Size(56, 23)
        Me.Button23.TabIndex = 4
        Me.Button23.TabStop = False
        Me.Button23.Text = "&Find"
        '
        'Button24
        '
        Me.Button24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button24.Location = New System.Drawing.Point(261, -26)
        Me.Button24.Name = "Button24"
        Me.Button24.Size = New System.Drawing.Size(40, 23)
        Me.Button24.TabIndex = 11
        Me.Button24.TabStop = False
        Me.Button24.Text = ">"
        '
        'Button25
        '
        Me.Button25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button25.Location = New System.Drawing.Point(-349, -26)
        Me.Button25.Name = "Button25"
        Me.Button25.Size = New System.Drawing.Size(56, 23)
        Me.Button25.TabIndex = 0
        Me.Button25.TabStop = False
        Me.Button25.Text = "&Add"
        '
        'grpJobOrd
        '
        Me.grpJobOrd.Controls.Add(Me.cmdJobOrd)
        Me.grpJobOrd.Location = New System.Drawing.Point(320, 27)
        Me.grpJobOrd.Name = "grpJobOrd"
        Me.grpJobOrd.Size = New System.Drawing.Size(86, 42)
        Me.grpJobOrd.TabIndex = 16
        Me.grpJobOrd.TabStop = False
        Me.grpJobOrd.Text = "Job Order"
        '
        'cmdJobOrd
        '
        Me.cmdJobOrd.Location = New System.Drawing.Point(17, 14)
        Me.cmdJobOrd.Name = "cmdJobOrd"
        Me.cmdJobOrd.Size = New System.Drawing.Size(52, 21)
        Me.cmdJobOrd.TabIndex = 0
        Me.cmdJobOrd.Text = "..."
        Me.cmdJobOrd.UseVisualStyleBackColor = True
        '
        'StatusBar
        '
        Me.StatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblLeft, Me.lblRight})
        Me.StatusBar.Location = New System.Drawing.Point(0, 610)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Size = New System.Drawing.Size(954, 22)
        Me.StatusBar.TabIndex = 278
        Me.StatusBar.Text = "StatusStrip1"
        '
        'lblLeft
        '
        Me.lblLeft.AutoSize = False
        Me.lblLeft.Name = "lblLeft"
        Me.lblLeft.Size = New System.Drawing.Size(808, 17)
        Me.lblLeft.Spring = True
        Me.lblLeft.Text = "1900"
        Me.lblLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRight
        '
        Me.lblRight.Name = "lblRight"
        Me.lblRight.Size = New System.Drawing.Size(131, 17)
        Me.lblRight.Text = "ToolStripStatusLabel1"
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
        Me.menuStrip.TabIndex = 279
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
        Me.mmdInsRow.Text = "In&s Row"
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
        Me.mmdFunction.Name = "mmdFunction"
        Me.mmdFunction.Size = New System.Drawing.Size(66, 19)
        Me.mmdFunction.Text = "Function"
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
        'tabFrame
        '
        Me.tabFrame.Controls.Add(Me.tabExceptionRecord)
        Me.tabFrame.Controls.Add(Me.tabUpdateLog)
        Me.tabFrame.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.tabFrame.ItemSize = New System.Drawing.Size(110, 20)
        Me.tabFrame.Location = New System.Drawing.Point(12, 75)
        Me.tabFrame.Name = "tabFrame"
        Me.tabFrame.SelectedIndex = 0
        Me.tabFrame.Size = New System.Drawing.Size(920, 509)
        Me.tabFrame.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabFrame.TabIndex = 14
        '
        'tabExceptionRecord
        '
        Me.tabExceptionRecord.Controls.Add(Me.grdSummary)
        Me.tabExceptionRecord.Controls.Add(Me.cmdExportExp)
        Me.tabExceptionRecord.Location = New System.Drawing.Point(4, 24)
        Me.tabExceptionRecord.Name = "tabExceptionRecord"
        Me.tabExceptionRecord.Padding = New System.Windows.Forms.Padding(3)
        Me.tabExceptionRecord.Size = New System.Drawing.Size(912, 481)
        Me.tabExceptionRecord.TabIndex = 0
        Me.tabExceptionRecord.Text = "Exception Record"
        Me.tabExceptionRecord.UseVisualStyleBackColor = True
        '
        'grdSummary
        '
        Me.grdSummary.AllowUserToAddRows = False
        Me.grdSummary.AllowUserToDeleteRows = False
        Me.grdSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdSummary.Location = New System.Drawing.Point(6, 6)
        Me.grdSummary.Name = "grdSummary"
        Me.grdSummary.ReadOnly = True
        Me.grdSummary.RowTemplate.Height = 15
        Me.grdSummary.Size = New System.Drawing.Size(900, 440)
        Me.grdSummary.TabIndex = 19
        '
        'cmdExportExp
        '
        Me.cmdExportExp.Location = New System.Drawing.Point(397, 452)
        Me.cmdExportExp.Name = "cmdExportExp"
        Me.cmdExportExp.Size = New System.Drawing.Size(116, 23)
        Me.cmdExportExp.TabIndex = 18
        Me.cmdExportExp.Text = "Export Exception"
        Me.cmdExportExp.UseVisualStyleBackColor = True
        '
        'tabUpdateLog
        '
        Me.tabUpdateLog.Controls.Add(Me.grdErrLog)
        Me.tabUpdateLog.Controls.Add(Me.cmdExportLog)
        Me.tabUpdateLog.Location = New System.Drawing.Point(4, 24)
        Me.tabUpdateLog.Name = "tabUpdateLog"
        Me.tabUpdateLog.Padding = New System.Windows.Forms.Padding(3)
        Me.tabUpdateLog.Size = New System.Drawing.Size(912, 481)
        Me.tabUpdateLog.TabIndex = 1
        Me.tabUpdateLog.Text = "Update Log"
        Me.tabUpdateLog.UseVisualStyleBackColor = True
        '
        'grdErrLog
        '
        Me.grdErrLog.AllowUserToAddRows = False
        Me.grdErrLog.AllowUserToDeleteRows = False
        Me.grdErrLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdErrLog.Location = New System.Drawing.Point(6, 6)
        Me.grdErrLog.Name = "grdErrLog"
        Me.grdErrLog.ReadOnly = True
        Me.grdErrLog.RowTemplate.Height = 15
        Me.grdErrLog.Size = New System.Drawing.Size(900, 440)
        Me.grdErrLog.TabIndex = 20
        '
        'cmdExportLog
        '
        Me.cmdExportLog.Location = New System.Drawing.Point(397, 452)
        Me.cmdExportLog.Name = "cmdExportLog"
        Me.cmdExportLog.Size = New System.Drawing.Size(116, 23)
        Me.cmdExportLog.TabIndex = 19
        Me.cmdExportLog.Text = "Export Log"
        Me.cmdExportLog.UseVisualStyleBackColor = True
        '
        'SCM00003
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(954, 632)
        Me.Controls.Add(Me.menuStrip)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.grpJobOrd)
        Me.Controls.Add(Me.grpUpdate)
        Me.Controls.Add(Me.tabFrame)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "SCM00003"
        Me.Text = "SCM00003 - SC Factory Data Approval & Rejection (SCM03)"
        Me.grpUpdate.ResumeLayout(False)
        Me.grpUpdate.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.grpJobOrd.ResumeLayout(False)
        Me.StatusBar.ResumeLayout(False)
        Me.StatusBar.PerformLayout()
        Me.menuStrip.ResumeLayout(False)
        Me.menuStrip.PerformLayout()
        Me.tabFrame.ResumeLayout(False)
        Me.tabExceptionRecord.ResumeLayout(False)
        CType(Me.grdSummary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabUpdateLog.ResumeLayout(False)
        CType(Me.grdErrLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tabFrame As ERPSystem.BaseTabControl
    Friend WithEvents tabExceptionRecord As System.Windows.Forms.TabPage
    Friend WithEvents tabUpdateLog As System.Windows.Forms.TabPage
    Friend WithEvents grpUpdate As System.Windows.Forms.GroupBox
    Friend WithEvents optNo As System.Windows.Forms.RadioButton
    Friend WithEvents optYes As System.Windows.Forms.RadioButton
    Friend WithEvents txtToApply As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFromApply As System.Windows.Forms.TextBox
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents grpJobOrd As System.Windows.Forms.GroupBox
    Friend WithEvents cmdJobOrd As System.Windows.Forms.Button
    Friend WithEvents grdSummary As System.Windows.Forms.DataGridView
    Friend WithEvents cmdExportExp As System.Windows.Forms.Button
    Friend WithEvents grdErrLog As System.Windows.Forms.DataGridView
    Friend WithEvents cmdExportLog As System.Windows.Forms.Button
    Friend WithEvents StatusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents lblLeft As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblRight As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Button32 As System.Windows.Forms.Button
    Friend WithEvents Button30 As System.Windows.Forms.Button
    Friend WithEvents Button29 As System.Windows.Forms.Button
    Friend WithEvents Button17 As System.Windows.Forms.Button
    Friend WithEvents Button18 As System.Windows.Forms.Button
    Friend WithEvents Button28 As System.Windows.Forms.Button
    Friend WithEvents Button19 As System.Windows.Forms.Button
    Friend WithEvents Button20 As System.Windows.Forms.Button
    Friend WithEvents Button27 As System.Windows.Forms.Button
    Friend WithEvents Button21 As System.Windows.Forms.Button
    Friend WithEvents Button22 As System.Windows.Forms.Button
    Friend WithEvents Button26 As System.Windows.Forms.Button
    Friend WithEvents Button23 As System.Windows.Forms.Button
    Friend WithEvents Button24 As System.Windows.Forms.Button
    Friend WithEvents Button25 As System.Windows.Forms.Button
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
    Friend WithEvents t7 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdLink As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t8 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdExit As System.Windows.Forms.ToolStripMenuItem
End Class
