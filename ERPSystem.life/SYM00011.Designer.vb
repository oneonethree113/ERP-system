<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SYM00011
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SYM00011))
        Me.Label5 = New System.Windows.Forms.Label
        Me.CboVCde = New System.Windows.Forms.ComboBox
        Me.cboUnttyp = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtEffDat = New System.Windows.Forms.MaskedTextBox
        Me.cboEffDat = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdAddEffDat = New System.Windows.Forms.Button
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
        Me.tpA = New System.Windows.Forms.TabPage
        Me.DataGridC = New System.Windows.Forms.DataGridView
        Me.tpM = New System.Windows.Forms.TabPage
        Me.DataGridM = New System.Windows.Forms.DataGridView
        Me.tpControl = New System.Windows.Forms.TabControl
        Me.StatusBar.SuspendLayout()
        Me.menuStrip.SuspendLayout()
        Me.tpA.SuspendLayout()
        CType(Me.DataGridC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpM.SuspendLayout()
        CType(Me.DataGridM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpControl.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 36)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 12)
        Me.Label5.TabIndex = 143
        Me.Label5.Text = "Vendor "
        '
        'CboVCde
        '
        Me.CboVCde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboVCde.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.CboVCde.FormattingEnabled = True
        Me.CboVCde.Location = New System.Drawing.Point(78, 33)
        Me.CboVCde.Name = "CboVCde"
        Me.CboVCde.Size = New System.Drawing.Size(300, 23)
        Me.CboVCde.TabIndex = 142
        '
        'cboUnttyp
        '
        Me.cboUnttyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUnttyp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.cboUnttyp.FormattingEnabled = True
        Me.cboUnttyp.Location = New System.Drawing.Point(78, 64)
        Me.cboUnttyp.Name = "cboUnttyp"
        Me.cboUnttyp.Size = New System.Drawing.Size(98, 23)
        Me.cboUnttyp.TabIndex = 145
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 12)
        Me.Label2.TabIndex = 147
        Me.Label2.Text = "Unit Type "
        '
        'txtEffDat
        '
        Me.txtEffDat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txtEffDat.Location = New System.Drawing.Point(583, 33)
        Me.txtEffDat.Mask = "##/##/####"
        Me.txtEffDat.Name = "txtEffDat"
        Me.txtEffDat.Size = New System.Drawing.Size(98, 21)
        Me.txtEffDat.TabIndex = 223
        '
        'cboEffDat
        '
        Me.cboEffDat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEffDat.FormattingEnabled = True
        Me.cboEffDat.Location = New System.Drawing.Point(583, 33)
        Me.cboEffDat.Name = "cboEffDat"
        Me.cboEffDat.Size = New System.Drawing.Size(98, 20)
        Me.cboEffDat.TabIndex = 222
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(405, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(156, 12)
        Me.Label1.TabIndex = 221
        Me.Label1.Text = "Effective Date (MM/DD/YYYY)"
        '
        'cmdAddEffDat
        '
        Me.cmdAddEffDat.Location = New System.Drawing.Point(697, 33)
        Me.cmdAddEffDat.Name = "cmdAddEffDat"
        Me.cmdAddEffDat.Size = New System.Drawing.Size(56, 22)
        Me.cmdAddEffDat.TabIndex = 224
        Me.cmdAddEffDat.Text = "OK"
        Me.cmdAddEffDat.UseVisualStyleBackColor = True
        '
        'StatusBar
        '
        Me.StatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblLeft, Me.lblRight})
        Me.StatusBar.Location = New System.Drawing.Point(0, 607)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Size = New System.Drawing.Size(954, 24)
        Me.StatusBar.TabIndex = 239
        Me.StatusBar.Text = "StatusStrip1"
        '
        'lblLeft
        '
        Me.lblLeft.AutoSize = False
        Me.lblLeft.Name = "lblLeft"
        Me.lblLeft.Size = New System.Drawing.Size(150, 19)
        Me.lblLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRight
        '
        Me.lblRight.AutoSize = False
        Me.lblRight.Name = "lblRight"
        Me.lblRight.Size = New System.Drawing.Size(789, 19)
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
        Me.menuStrip.TabIndex = 240
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
        'tpA
        '
        Me.tpA.Controls.Add(Me.DataGridC)
        Me.tpA.Location = New System.Drawing.Point(4, 22)
        Me.tpA.Name = "tpA"
        Me.tpA.Padding = New System.Windows.Forms.Padding(3)
        Me.tpA.Size = New System.Drawing.Size(946, 480)
        Me.tpA.TabIndex = 1
        Me.tpA.Text = "Commission Rate"
        Me.tpA.UseVisualStyleBackColor = True
        '
        'DataGridC
        '
        Me.DataGridC.AllowUserToResizeColumns = False
        Me.DataGridC.AllowUserToResizeRows = False
        Me.DataGridC.ColumnHeadersHeight = 20
        Me.DataGridC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridC.Location = New System.Drawing.Point(0, 6)
        Me.DataGridC.Name = "DataGridC"
        Me.DataGridC.RowHeadersWidth = 20
        Me.DataGridC.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DataGridC.RowTemplate.Height = 20
        Me.DataGridC.Size = New System.Drawing.Size(945, 479)
        Me.DataGridC.TabIndex = 76
        '
        'tpM
        '
        Me.tpM.Controls.Add(Me.DataGridM)
        Me.tpM.Location = New System.Drawing.Point(4, 22)
        Me.tpM.Name = "tpM"
        Me.tpM.Padding = New System.Windows.Forms.Padding(3)
        Me.tpM.Size = New System.Drawing.Size(946, 480)
        Me.tpM.TabIndex = 0
        Me.tpM.Text = "MOQ / MOA"
        Me.tpM.UseVisualStyleBackColor = True
        '
        'DataGridM
        '
        Me.DataGridM.AllowUserToResizeColumns = False
        Me.DataGridM.AllowUserToResizeRows = False
        Me.DataGridM.ColumnHeadersHeight = 20
        Me.DataGridM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridM.Location = New System.Drawing.Point(0, 6)
        Me.DataGridM.Name = "DataGridM"
        Me.DataGridM.RowHeadersWidth = 20
        Me.DataGridM.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DataGridM.RowTemplate.Height = 20
        Me.DataGridM.ShowRowErrors = False
        Me.DataGridM.Size = New System.Drawing.Size(943, 493)
        Me.DataGridM.TabIndex = 77
        '
        'tpControl
        '
        Me.tpControl.Controls.Add(Me.tpM)
        Me.tpControl.Controls.Add(Me.tpA)
        Me.tpControl.ItemSize = New System.Drawing.Size(100, 18)
        Me.tpControl.Location = New System.Drawing.Point(0, 98)
        Me.tpControl.Name = "tpControl"
        Me.tpControl.SelectedIndex = 0
        Me.tpControl.Size = New System.Drawing.Size(954, 506)
        Me.tpControl.TabIndex = 126
        '
        'SYM00011
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(954, 631)
        Me.Controls.Add(Me.menuStrip)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.cmdAddEffDat)
        Me.Controls.Add(Me.txtEffDat)
        Me.Controls.Add(Me.cboEffDat)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboUnttyp)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.CboVCde)
        Me.Controls.Add(Me.tpControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "SYM00011"
        Me.Text = "SYM00011 - MOQ / MOA and Commission (SYM11)"
        Me.StatusBar.ResumeLayout(False)
        Me.StatusBar.PerformLayout()
        Me.menuStrip.ResumeLayout(False)
        Me.menuStrip.PerformLayout()
        Me.tpA.ResumeLayout(False)
        CType(Me.DataGridC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpM.ResumeLayout(False)
        CType(Me.DataGridM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpControl.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CboVCde As System.Windows.Forms.ComboBox
    Friend WithEvents cboUnttyp As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtEffDat As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cboEffDat As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdAddEffDat As System.Windows.Forms.Button
    Friend WithEvents StatusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents lblLeft As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblRight As System.Windows.Forms.ToolStripStatusLabel
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
    Friend WithEvents tpA As System.Windows.Forms.TabPage
    Friend WithEvents DataGridC As System.Windows.Forms.DataGridView
    Friend WithEvents tpM As System.Windows.Forms.TabPage
    Friend WithEvents DataGridM As System.Windows.Forms.DataGridView
    Friend WithEvents tpControl As System.Windows.Forms.TabControl
End Class
