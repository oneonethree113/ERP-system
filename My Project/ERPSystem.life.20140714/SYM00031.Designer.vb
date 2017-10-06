<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SYM00031
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
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.lblLeft = New System.Windows.Forms.ToolStripStatusLabel
        Me.StatusBar = New System.Windows.Forms.StatusStrip
        Me.lblRight = New System.Windows.Forms.ToolStripStatusLabel
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.cmdLast = New System.Windows.Forms.Button
        Me.cmdPrevious = New System.Windows.Forms.Button
        Me.cmdNext = New System.Windows.Forms.Button
        Me.cmdFind = New System.Windows.Forms.Button
        Me.cmdCopy = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdDelRow = New System.Windows.Forms.Button
        Me.cmdFirst = New System.Windows.Forms.Button
        Me.cmdInsRow = New System.Windows.Forms.Button
        Me.cmdSearch = New System.Windows.Forms.Button
        Me.grdSYMPKGCAT = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.grdCATWAG = New System.Windows.Forms.DataGridView
        Me.StatusBar.SuspendLayout()
        CType(Me.grdSYMPKGCAT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grdCATWAG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdDelete
        '
        Me.cmdDelete.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelete.Location = New System.Drawing.Point(138, 0)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(56, 40)
        Me.cmdDelete.TabIndex = 211
        Me.cmdDelete.TabStop = False
        Me.cmdDelete.Text = "&Delete"
        '
        'cmdSave
        '
        Me.cmdSave.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.Location = New System.Drawing.Point(76, 0)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(56, 40)
        Me.cmdSave.TabIndex = 210
        Me.cmdSave.TabStop = False
        Me.cmdSave.Text = "&Save"
        '
        'lblLeft
        '
        Me.lblLeft.AutoSize = False
        Me.lblLeft.Name = "lblLeft"
        Me.lblLeft.Size = New System.Drawing.Size(550, 17)
        Me.lblLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'StatusBar
        '
        Me.StatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblLeft, Me.lblRight})
        Me.StatusBar.Location = New System.Drawing.Point(0, 482)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Size = New System.Drawing.Size(942, 22)
        Me.StatusBar.TabIndex = 223
        Me.StatusBar.Text = "StatusStrip1"
        '
        'lblRight
        '
        Me.lblRight.AutoSize = False
        Me.lblRight.Name = "lblRight"
        Me.lblRight.Size = New System.Drawing.Size(377, 17)
        Me.lblRight.Spring = True
        Me.lblRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdAdd
        '
        Me.cmdAdd.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdd.Location = New System.Drawing.Point(16, 0)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(56, 40)
        Me.cmdAdd.TabIndex = 209
        Me.cmdAdd.TabStop = False
        Me.cmdAdd.Text = "&Add"
        '
        'cmdLast
        '
        Me.cmdLast.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLast.Location = New System.Drawing.Point(828, 0)
        Me.cmdLast.Name = "cmdLast"
        Me.cmdLast.Size = New System.Drawing.Size(40, 40)
        Me.cmdLast.TabIndex = 221
        Me.cmdLast.TabStop = False
        Me.cmdLast.Text = ">>|"
        '
        'cmdPrevious
        '
        Me.cmdPrevious.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrevious.Location = New System.Drawing.Point(748, 0)
        Me.cmdPrevious.Name = "cmdPrevious"
        Me.cmdPrevious.Size = New System.Drawing.Size(40, 40)
        Me.cmdPrevious.TabIndex = 219
        Me.cmdPrevious.TabStop = False
        Me.cmdPrevious.Text = "<"
        '
        'cmdNext
        '
        Me.cmdNext.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNext.Location = New System.Drawing.Point(788, 0)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(40, 40)
        Me.cmdNext.TabIndex = 220
        Me.cmdNext.TabStop = False
        Me.cmdNext.Text = ">"
        '
        'cmdFind
        '
        Me.cmdFind.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFind.Location = New System.Drawing.Point(284, 0)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(56, 40)
        Me.cmdFind.TabIndex = 213
        Me.cmdFind.TabStop = False
        Me.cmdFind.Text = "&Find"
        '
        'cmdCopy
        '
        Me.cmdCopy.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCopy.Location = New System.Drawing.Point(222, 0)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(56, 40)
        Me.cmdCopy.TabIndex = 212
        Me.cmdCopy.TabStop = False
        Me.cmdCopy.Text = "&Copy"
        '
        'cmdClear
        '
        Me.cmdClear.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(346, 0)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(56, 40)
        Me.cmdClear.TabIndex = 214
        Me.cmdClear.TabStop = False
        Me.cmdClear.Text = "Cl&ear"
        '
        'cmdExit
        '
        Me.cmdExit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(874, 0)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(56, 40)
        Me.cmdExit.TabIndex = 222
        Me.cmdExit.TabStop = False
        Me.cmdExit.Text = "E&xit"
        '
        'cmdDelRow
        '
        Me.cmdDelRow.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelRow.Location = New System.Drawing.Point(626, 0)
        Me.cmdDelRow.Name = "cmdDelRow"
        Me.cmdDelRow.Size = New System.Drawing.Size(56, 40)
        Me.cmdDelRow.TabIndex = 217
        Me.cmdDelRow.TabStop = False
        Me.cmdDelRow.Text = "Del Ro&w"
        '
        'cmdFirst
        '
        Me.cmdFirst.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFirst.Location = New System.Drawing.Point(708, 0)
        Me.cmdFirst.Name = "cmdFirst"
        Me.cmdFirst.Size = New System.Drawing.Size(40, 40)
        Me.cmdFirst.TabIndex = 218
        Me.cmdFirst.TabStop = False
        Me.cmdFirst.Text = "|<<"
        '
        'cmdInsRow
        '
        Me.cmdInsRow.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdInsRow.Location = New System.Drawing.Point(570, 0)
        Me.cmdInsRow.Name = "cmdInsRow"
        Me.cmdInsRow.Size = New System.Drawing.Size(56, 40)
        Me.cmdInsRow.TabIndex = 216
        Me.cmdInsRow.TabStop = False
        Me.cmdInsRow.Text = "I&ns Row"
        '
        'cmdSearch
        '
        Me.cmdSearch.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(450, 0)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(64, 40)
        Me.cmdSearch.TabIndex = 215
        Me.cmdSearch.TabStop = False
        Me.cmdSearch.Text = "Searc&h"
        '
        'grdSYMPKGCAT
        '
        Me.grdSYMPKGCAT.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar
        Me.grdSYMPKGCAT.AllowUserToResizeColumns = False
        Me.grdSYMPKGCAT.AllowUserToResizeRows = False
        Me.grdSYMPKGCAT.ColumnHeadersHeight = 20
        Me.grdSYMPKGCAT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.grdSYMPKGCAT.Location = New System.Drawing.Point(6, 35)
        Me.grdSYMPKGCAT.Name = "grdSYMPKGCAT"
        Me.grdSYMPKGCAT.RowHeadersWidth = 20
        Me.grdSYMPKGCAT.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.grdSYMPKGCAT.RowTemplate.Height = 20
        Me.grdSYMPKGCAT.Size = New System.Drawing.Size(523, 392)
        Me.grdSYMPKGCAT.TabIndex = 74
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.grdSYMPKGCAT)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox1.Location = New System.Drawing.Point(11, 46)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(535, 433)
        Me.GroupBox1.TabIndex = 204
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(6, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(135, 15)
        Me.Label1.TabIndex = 75
        Me.Label1.Text = "Packaging Component "
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.grdCATWAG)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox2.Location = New System.Drawing.Point(552, 46)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(378, 433)
        Me.GroupBox2.TabIndex = 205
        Me.GroupBox2.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(6, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 15)
        Me.Label2.TabIndex = 76
        Me.Label2.Text = "Wastage Setup"
        '
        'grdCATWAG
        '
        Me.grdCATWAG.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar
        Me.grdCATWAG.AllowUserToResizeColumns = False
        Me.grdCATWAG.AllowUserToResizeRows = False
        Me.grdCATWAG.ColumnHeadersHeight = 20
        Me.grdCATWAG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.grdCATWAG.Location = New System.Drawing.Point(6, 35)
        Me.grdCATWAG.Name = "grdCATWAG"
        Me.grdCATWAG.RowHeadersWidth = 20
        Me.grdCATWAG.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.grdCATWAG.RowTemplate.Height = 20
        Me.grdCATWAG.Size = New System.Drawing.Size(360, 392)
        Me.grdCATWAG.TabIndex = 74
        '
        'SYM00031
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(942, 504)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.cmdLast)
        Me.Controls.Add(Me.cmdPrevious)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.cmdFind)
        Me.Controls.Add(Me.cmdCopy)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdDelRow)
        Me.Controls.Add(Me.cmdFirst)
        Me.Controls.Add(Me.cmdInsRow)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(950, 538)
        Me.MinimumSize = New System.Drawing.Size(950, 538)
        Me.Name = "SYM00031"
        Me.Text = "SYM00031 - Packaging Component Maintenance"
        Me.StatusBar.ResumeLayout(False)
        Me.StatusBar.PerformLayout()
        CType(Me.grdSYMPKGCAT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.grdCATWAG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents lblLeft As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents lblRight As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents cmdLast As System.Windows.Forms.Button
    Friend WithEvents cmdPrevious As System.Windows.Forms.Button
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents cmdFind As System.Windows.Forms.Button
    Friend WithEvents cmdCopy As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdDelRow As System.Windows.Forms.Button
    Friend WithEvents cmdFirst As System.Windows.Forms.Button
    Friend WithEvents cmdInsRow As System.Windows.Forms.Button
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents grdSYMPKGCAT As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents grdCATWAG As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
