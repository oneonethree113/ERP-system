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
        Me.cmdInsRow = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdLast = New System.Windows.Forms.Button
        Me.cmdPrevious = New System.Windows.Forms.Button
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.cmdNext = New System.Windows.Forms.Button
        Me.cmdFind = New System.Windows.Forms.Button
        Me.cmdCopy = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdDelRow = New System.Windows.Forms.Button
        Me.cmdFirst = New System.Windows.Forms.Button
        Me.cmdSearch = New System.Windows.Forms.Button
        Me.grpUpdate = New System.Windows.Forms.GroupBox
        Me.optYes = New System.Windows.Forms.RadioButton
        Me.optNo = New System.Windows.Forms.RadioButton
        Me.txtFromApply = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtToApply = New System.Windows.Forms.TextBox
        Me.cmdApply = New System.Windows.Forms.Button
        Me.grpJobOrd = New System.Windows.Forms.GroupBox
        Me.cmdJobOrd = New System.Windows.Forms.Button
        Me.StatusBar = New System.Windows.Forms.StatusStrip
        Me.lblLeft = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblRight = New System.Windows.Forms.ToolStripStatusLabel
        Me.tabFrame = New ERPSystem.BaseTabControl
        Me.tabExceptionRecord = New System.Windows.Forms.TabPage
        Me.grdSummary = New System.Windows.Forms.DataGridView
        Me.cmdExportExp = New System.Windows.Forms.Button
        Me.tabUpdateLog = New System.Windows.Forms.TabPage
        Me.grdErrLog = New System.Windows.Forms.DataGridView
        Me.cmdExportLog = New System.Windows.Forms.Button
        Me.grpUpdate.SuspendLayout()
        Me.grpJobOrd.SuspendLayout()
        Me.StatusBar.SuspendLayout()
        Me.tabFrame.SuspendLayout()
        Me.tabExceptionRecord.SuspendLayout()
        CType(Me.grdSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabUpdateLog.SuspendLayout()
        CType(Me.grdErrLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdInsRow
        '
        Me.cmdInsRow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdInsRow.Location = New System.Drawing.Point(412, 0)
        Me.cmdInsRow.Name = "cmdInsRow"
        Me.cmdInsRow.Size = New System.Drawing.Size(56, 25)
        Me.cmdInsRow.TabIndex = 7
        Me.cmdInsRow.TabStop = False
        Me.cmdInsRow.Text = "I&ns Row"
        Me.cmdInsRow.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelete.Location = New System.Drawing.Point(112, 0)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(56, 25)
        Me.cmdDelete.TabIndex = 2
        Me.cmdDelete.TabStop = False
        Me.cmdDelete.Text = "&Delete"
        '
        'cmdSave
        '
        Me.cmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.Location = New System.Drawing.Point(56, 0)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(56, 25)
        Me.cmdSave.TabIndex = 1
        Me.cmdSave.TabStop = False
        Me.cmdSave.Text = "&Save"
        '
        'cmdLast
        '
        Me.cmdLast.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLast.Location = New System.Drawing.Point(650, 0)
        Me.cmdLast.Name = "cmdLast"
        Me.cmdLast.Size = New System.Drawing.Size(40, 25)
        Me.cmdLast.TabIndex = 12
        Me.cmdLast.TabStop = False
        Me.cmdLast.Text = ">>|"
        '
        'cmdPrevious
        '
        Me.cmdPrevious.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrevious.Location = New System.Drawing.Point(570, 0)
        Me.cmdPrevious.Name = "cmdPrevious"
        Me.cmdPrevious.Size = New System.Drawing.Size(40, 25)
        Me.cmdPrevious.TabIndex = 10
        Me.cmdPrevious.TabStop = False
        Me.cmdPrevious.Text = "<"
        '
        'cmdAdd
        '
        Me.cmdAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdd.Location = New System.Drawing.Point(0, 0)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(56, 25)
        Me.cmdAdd.TabIndex = 0
        Me.cmdAdd.TabStop = False
        Me.cmdAdd.Text = "&Add"
        '
        'cmdNext
        '
        Me.cmdNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNext.Location = New System.Drawing.Point(610, 0)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(40, 25)
        Me.cmdNext.TabIndex = 11
        Me.cmdNext.TabStop = False
        Me.cmdNext.Text = ">"
        '
        'cmdFind
        '
        Me.cmdFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFind.Location = New System.Drawing.Point(224, 0)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(56, 25)
        Me.cmdFind.TabIndex = 4
        Me.cmdFind.TabStop = False
        Me.cmdFind.Text = "&Find"
        '
        'cmdCopy
        '
        Me.cmdCopy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCopy.Location = New System.Drawing.Point(168, 0)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(56, 25)
        Me.cmdCopy.TabIndex = 3
        Me.cmdCopy.TabStop = False
        Me.cmdCopy.Text = "&Copy"
        '
        'cmdClear
        '
        Me.cmdClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(280, 0)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(56, 25)
        Me.cmdClear.TabIndex = 5
        Me.cmdClear.TabStop = False
        Me.cmdClear.Text = "Cl&ear"
        '
        'cmdExit
        '
        Me.cmdExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(696, 0)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(56, 25)
        Me.cmdExit.TabIndex = 13
        Me.cmdExit.TabStop = False
        Me.cmdExit.Text = "E&xit"
        '
        'cmdDelRow
        '
        Me.cmdDelRow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelRow.Location = New System.Drawing.Point(468, 0)
        Me.cmdDelRow.Name = "cmdDelRow"
        Me.cmdDelRow.Size = New System.Drawing.Size(56, 25)
        Me.cmdDelRow.TabIndex = 8
        Me.cmdDelRow.TabStop = False
        Me.cmdDelRow.Text = "Del Ro&w"
        '
        'cmdFirst
        '
        Me.cmdFirst.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFirst.Location = New System.Drawing.Point(530, 0)
        Me.cmdFirst.Name = "cmdFirst"
        Me.cmdFirst.Size = New System.Drawing.Size(40, 25)
        Me.cmdFirst.TabIndex = 9
        Me.cmdFirst.TabStop = False
        Me.cmdFirst.Text = "|<<"
        '
        'cmdSearch
        '
        Me.cmdSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(342, 0)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(64, 25)
        Me.cmdSearch.TabIndex = 6
        Me.cmdSearch.TabStop = False
        Me.cmdSearch.Text = "Searc&h"
        '
        'grpUpdate
        '
        Me.grpUpdate.Controls.Add(Me.txtToApply)
        Me.grpUpdate.Controls.Add(Me.cmdApply)
        Me.grpUpdate.Controls.Add(Me.Label1)
        Me.grpUpdate.Controls.Add(Me.txtFromApply)
        Me.grpUpdate.Controls.Add(Me.optNo)
        Me.grpUpdate.Controls.Add(Me.optYes)
        Me.grpUpdate.Location = New System.Drawing.Point(349, 28)
        Me.grpUpdate.Name = "grpUpdate"
        Me.grpUpdate.Size = New System.Drawing.Size(295, 45)
        Me.grpUpdate.TabIndex = 15
        Me.grpUpdate.TabStop = False
        Me.grpUpdate.Text = "Update"
        '
        'optYes
        '
        Me.optYes.AutoSize = True
        Me.optYes.Checked = True
        Me.optYes.Location = New System.Drawing.Point(7, 18)
        Me.optYes.Name = "optYes"
        Me.optYes.Size = New System.Drawing.Size(43, 17)
        Me.optYes.TabIndex = 0
        Me.optYes.TabStop = True
        Me.optYes.Text = "Yes"
        Me.optYes.UseVisualStyleBackColor = True
        '
        'optNo
        '
        Me.optNo.AutoSize = True
        Me.optNo.Location = New System.Drawing.Point(57, 18)
        Me.optNo.Name = "optNo"
        Me.optNo.Size = New System.Drawing.Size(39, 17)
        Me.optNo.TabIndex = 1
        Me.optNo.TabStop = True
        Me.optNo.Text = "No"
        Me.optNo.UseVisualStyleBackColor = True
        '
        'txtFromApply
        '
        Me.txtFromApply.Location = New System.Drawing.Point(102, 17)
        Me.txtFromApply.Name = "txtFromApply"
        Me.txtFromApply.Size = New System.Drawing.Size(51, 20)
        Me.txtFromApply.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(159, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "to"
        '
        'txtToApply
        '
        Me.txtToApply.Location = New System.Drawing.Point(181, 17)
        Me.txtToApply.Name = "txtToApply"
        Me.txtToApply.Size = New System.Drawing.Size(51, 20)
        Me.txtToApply.TabIndex = 4
        '
        'cmdApply
        '
        Me.cmdApply.Location = New System.Drawing.Point(238, 15)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.Size = New System.Drawing.Size(51, 23)
        Me.cmdApply.TabIndex = 5
        Me.cmdApply.Text = "Apply"
        Me.cmdApply.UseVisualStyleBackColor = True
        '
        'grpJobOrd
        '
        Me.grpJobOrd.Controls.Add(Me.cmdJobOrd)
        Me.grpJobOrd.Location = New System.Drawing.Point(650, 28)
        Me.grpJobOrd.Name = "grpJobOrd"
        Me.grpJobOrd.Size = New System.Drawing.Size(86, 45)
        Me.grpJobOrd.TabIndex = 16
        Me.grpJobOrd.TabStop = False
        Me.grpJobOrd.Text = "Job Order"
        '
        'cmdJobOrd
        '
        Me.cmdJobOrd.Location = New System.Drawing.Point(17, 15)
        Me.cmdJobOrd.Name = "cmdJobOrd"
        Me.cmdJobOrd.Size = New System.Drawing.Size(52, 23)
        Me.cmdJobOrd.TabIndex = 0
        Me.cmdJobOrd.Text = "..."
        Me.cmdJobOrd.UseVisualStyleBackColor = True
        '
        'StatusBar
        '
        Me.StatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblLeft, Me.lblRight})
        Me.StatusBar.Location = New System.Drawing.Point(0, 511)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Size = New System.Drawing.Size(748, 22)
        Me.StatusBar.TabIndex = 278
        Me.StatusBar.Text = "StatusStrip1"
        '
        'lblLeft
        '
        Me.lblLeft.AutoSize = False
        Me.lblLeft.Name = "lblLeft"
        Me.lblLeft.Size = New System.Drawing.Size(622, 17)
        Me.lblLeft.Spring = True
        Me.lblLeft.Text = "1900"
        Me.lblLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRight
        '
        Me.lblRight.Name = "lblRight"
        Me.lblRight.Size = New System.Drawing.Size(111, 17)
        Me.lblRight.Text = "ToolStripStatusLabel1"
        '
        'tabFrame
        '
        Me.tabFrame.Controls.Add(Me.tabExceptionRecord)
        Me.tabFrame.Controls.Add(Me.tabUpdateLog)
        Me.tabFrame.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.tabFrame.ItemSize = New System.Drawing.Size(110, 20)
        Me.tabFrame.Location = New System.Drawing.Point(12, 58)
        Me.tabFrame.Name = "tabFrame"
        Me.tabFrame.SelectedIndex = 0
        Me.tabFrame.Size = New System.Drawing.Size(724, 450)
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
        Me.tabExceptionRecord.Size = New System.Drawing.Size(716, 422)
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
        Me.grdSummary.Size = New System.Drawing.Size(704, 379)
        Me.grdSummary.TabIndex = 19
        '
        'cmdExportExp
        '
        Me.cmdExportExp.Location = New System.Drawing.Point(594, 391)
        Me.cmdExportExp.Name = "cmdExportExp"
        Me.cmdExportExp.Size = New System.Drawing.Size(116, 25)
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
        Me.tabUpdateLog.Size = New System.Drawing.Size(716, 422)
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
        Me.grdErrLog.Size = New System.Drawing.Size(704, 379)
        Me.grdErrLog.TabIndex = 20
        '
        'cmdExportLog
        '
        Me.cmdExportLog.Location = New System.Drawing.Point(594, 391)
        Me.cmdExportLog.Name = "cmdExportLog"
        Me.cmdExportLog.Size = New System.Drawing.Size(116, 25)
        Me.cmdExportLog.TabIndex = 19
        Me.cmdExportLog.Text = "Export Log"
        Me.cmdExportLog.UseVisualStyleBackColor = True
        '
        'SCM00003
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(748, 533)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.grpJobOrd)
        Me.Controls.Add(Me.grpUpdate)
        Me.Controls.Add(Me.tabFrame)
        Me.Controls.Add(Me.cmdInsRow)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdLast)
        Me.Controls.Add(Me.cmdPrevious)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.cmdFind)
        Me.Controls.Add(Me.cmdCopy)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdDelRow)
        Me.Controls.Add(Me.cmdFirst)
        Me.Controls.Add(Me.cmdSearch)
        Me.Name = "SCM00003"
        Me.Text = "SCM00003 - SC Factory Data Approval & Rejection"
        Me.grpUpdate.ResumeLayout(False)
        Me.grpUpdate.PerformLayout()
        Me.grpJobOrd.ResumeLayout(False)
        Me.StatusBar.ResumeLayout(False)
        Me.StatusBar.PerformLayout()
        Me.tabFrame.ResumeLayout(False)
        Me.tabExceptionRecord.ResumeLayout(False)
        CType(Me.grdSummary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabUpdateLog.ResumeLayout(False)
        CType(Me.grdErrLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdInsRow As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdLast As System.Windows.Forms.Button
    Friend WithEvents cmdPrevious As System.Windows.Forms.Button
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents cmdFind As System.Windows.Forms.Button
    Friend WithEvents cmdCopy As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdDelRow As System.Windows.Forms.Button
    Friend WithEvents cmdFirst As System.Windows.Forms.Button
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
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
End Class
