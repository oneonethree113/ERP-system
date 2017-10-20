<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IMM00013
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
        Me.txtDateTo = New System.Windows.Forms.TextBox
        Me.txtDateFrom = New System.Windows.Forms.TextBox
        Me.txtLineTo = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtLineFrom = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtPrdVenTo = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtPrdVenFrom = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtDesVenTo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtDesVenFrom = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtCusVenTo = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtCusVenFrom = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtVenItm = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.grdSummary = New System.Windows.Forms.DataGridView
        Me.cmdApply = New System.Windows.Forms.Button
        Me.txtApplyTo = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtApplyFrom = New System.Windows.Forms.TextBox
        Me.lblLeft = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblRight = New System.Windows.Forms.ToolStripStatusLabel
        Me.StatusBar = New System.Windows.Forms.StatusStrip
        Me.optInvalid = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.optWait = New System.Windows.Forms.RadioButton
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
        CType(Me.grdSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusBar.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtDateTo
        '
        Me.txtDateTo.Location = New System.Drawing.Point(662, 57)
        Me.txtDateTo.MaxLength = 10
        Me.txtDateTo.Name = "txtDateTo"
        Me.txtDateTo.Size = New System.Drawing.Size(70, 20)
        Me.txtDateTo.TabIndex = 181
        '
        'txtDateFrom
        '
        Me.txtDateFrom.Location = New System.Drawing.Point(558, 57)
        Me.txtDateFrom.MaxLength = 10
        Me.txtDateFrom.Name = "txtDateFrom"
        Me.txtDateFrom.Size = New System.Drawing.Size(70, 20)
        Me.txtDateFrom.TabIndex = 179
        '
        'txtLineTo
        '
        Me.txtLineTo.Location = New System.Drawing.Point(662, 80)
        Me.txtLineTo.MaxLength = 10
        Me.txtLineTo.Name = "txtLineTo"
        Me.txtLineTo.Size = New System.Drawing.Size(70, 20)
        Me.txtLineTo.TabIndex = 185
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(634, 83)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(22, 13)
        Me.Label10.TabIndex = 184
        Me.Label10.Text = "TO"
        '
        'txtLineFrom
        '
        Me.txtLineFrom.Location = New System.Drawing.Point(558, 80)
        Me.txtLineFrom.MaxLength = 10
        Me.txtLineFrom.Name = "txtLineFrom"
        Me.txtLineFrom.Size = New System.Drawing.Size(70, 20)
        Me.txtLineFrom.TabIndex = 183
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.Location = New System.Drawing.Point(402, 83)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(127, 13)
        Me.Label11.TabIndex = 182
        Me.Label11.Text = "Prod Line / Season Code"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(634, 60)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(22, 13)
        Me.Label8.TabIndex = 180
        Me.Label8.Text = "TO"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(402, 60)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(120, 13)
        Me.Label9.TabIndex = 178
        Me.Label9.Text = "Processing Date Range"
        '
        'txtPrdVenTo
        '
        Me.txtPrdVenTo.Location = New System.Drawing.Point(285, 80)
        Me.txtPrdVenTo.MaxLength = 6
        Me.txtPrdVenTo.Name = "txtPrdVenTo"
        Me.txtPrdVenTo.Size = New System.Drawing.Size(70, 20)
        Me.txtPrdVenTo.TabIndex = 177
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(257, 83)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(22, 13)
        Me.Label6.TabIndex = 176
        Me.Label6.Text = "TO"
        '
        'txtPrdVenFrom
        '
        Me.txtPrdVenFrom.Location = New System.Drawing.Point(181, 80)
        Me.txtPrdVenFrom.MaxLength = 6
        Me.txtPrdVenFrom.Name = "txtPrdVenFrom"
        Me.txtPrdVenFrom.Size = New System.Drawing.Size(70, 20)
        Me.txtPrdVenFrom.TabIndex = 175
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(25, 83)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 13)
        Me.Label7.TabIndex = 174
        Me.Label7.Text = "Prod. Vendor Range"
        '
        'txtDesVenTo
        '
        Me.txtDesVenTo.Location = New System.Drawing.Point(285, 57)
        Me.txtDesVenTo.MaxLength = 6
        Me.txtDesVenTo.Name = "txtDesVenTo"
        Me.txtDesVenTo.Size = New System.Drawing.Size(70, 20)
        Me.txtDesVenTo.TabIndex = 173
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(257, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(22, 13)
        Me.Label4.TabIndex = 172
        Me.Label4.Text = "TO"
        '
        'txtDesVenFrom
        '
        Me.txtDesVenFrom.Location = New System.Drawing.Point(181, 57)
        Me.txtDesVenFrom.MaxLength = 6
        Me.txtDesVenFrom.Name = "txtDesVenFrom"
        Me.txtDesVenFrom.Size = New System.Drawing.Size(70, 20)
        Me.txtDesVenFrom.TabIndex = 171
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(25, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 13)
        Me.Label5.TabIndex = 170
        Me.Label5.Text = "Design Vendor Range"
        '
        'txtCusVenTo
        '
        Me.txtCusVenTo.Location = New System.Drawing.Point(662, 34)
        Me.txtCusVenTo.MaxLength = 6
        Me.txtCusVenTo.Name = "txtCusVenTo"
        Me.txtCusVenTo.Size = New System.Drawing.Size(70, 20)
        Me.txtCusVenTo.TabIndex = 169
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(634, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(22, 13)
        Me.Label3.TabIndex = 168
        Me.Label3.Text = "TO"
        '
        'txtCusVenFrom
        '
        Me.txtCusVenFrom.Location = New System.Drawing.Point(558, 34)
        Me.txtCusVenFrom.MaxLength = 6
        Me.txtCusVenFrom.Name = "txtCusVenFrom"
        Me.txtCusVenFrom.Size = New System.Drawing.Size(70, 20)
        Me.txtCusVenFrom.TabIndex = 167
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(402, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 13)
        Me.Label2.TabIndex = 166
        Me.Label2.Text = "Custom Vendor Range"
        '
        'txtVenItm
        '
        Me.txtVenItm.Location = New System.Drawing.Point(181, 34)
        Me.txtVenItm.MaxLength = 20
        Me.txtVenItm.Name = "txtVenItm"
        Me.txtVenItm.Size = New System.Drawing.Size(174, 20)
        Me.txtVenItm.TabIndex = 165
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(25, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 164
        Me.Label1.Text = "Vendor Item No."
        '
        'grdSummary
        '
        Me.grdSummary.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.grdSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdSummary.Location = New System.Drawing.Point(12, 149)
        Me.grdSummary.Name = "grdSummary"
        Me.grdSummary.Size = New System.Drawing.Size(728, 298)
        Me.grdSummary.TabIndex = 186
        '
        'cmdApply
        '
        Me.cmdApply.Location = New System.Drawing.Point(512, 112)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.Size = New System.Drawing.Size(89, 23)
        Me.cmdApply.TabIndex = 190
        Me.cmdApply.Text = "&Apply"
        Me.cmdApply.UseVisualStyleBackColor = True
        '
        'txtApplyTo
        '
        Me.txtApplyTo.Location = New System.Drawing.Point(461, 114)
        Me.txtApplyTo.MaxLength = 6
        Me.txtApplyTo.Name = "txtApplyTo"
        Me.txtApplyTo.Size = New System.Drawing.Size(30, 20)
        Me.txtApplyTo.TabIndex = 189
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(439, 117)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(16, 13)
        Me.Label15.TabIndex = 188
        Me.Label15.Text = "to"
        '
        'txtApplyFrom
        '
        Me.txtApplyFrom.Location = New System.Drawing.Point(403, 114)
        Me.txtApplyFrom.MaxLength = 6
        Me.txtApplyFrom.Name = "txtApplyFrom"
        Me.txtApplyFrom.Size = New System.Drawing.Size(30, 20)
        Me.txtApplyFrom.TabIndex = 187
        '
        'lblLeft
        '
        Me.lblLeft.AutoSize = False
        Me.lblLeft.Name = "lblLeft"
        Me.lblLeft.Size = New System.Drawing.Size(500, 17)
        Me.lblLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRight
        '
        Me.lblRight.AutoSize = False
        Me.lblRight.Name = "lblRight"
        Me.lblRight.Size = New System.Drawing.Size(330, 17)
        Me.lblRight.Spring = True
        Me.lblRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'StatusBar
        '
        Me.StatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblLeft, Me.lblRight})
        Me.StatusBar.Location = New System.Drawing.Point(0, 461)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Size = New System.Drawing.Size(752, 22)
        Me.StatusBar.TabIndex = 192
        Me.StatusBar.Text = "StatusStrip1"
        '
        'optInvalid
        '
        Me.optInvalid.AutoSize = True
        Me.optInvalid.Location = New System.Drawing.Point(13, 14)
        Me.optInvalid.Name = "optInvalid"
        Me.optInvalid.Size = New System.Drawing.Size(56, 17)
        Me.optInvalid.TabIndex = 0
        Me.optInvalid.TabStop = True
        Me.optInvalid.Text = "Invalid"
        Me.optInvalid.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optWait)
        Me.GroupBox1.Controls.Add(Me.optInvalid)
        Me.GroupBox1.Location = New System.Drawing.Point(157, 102)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(209, 39)
        Me.GroupBox1.TabIndex = 193
        Me.GroupBox1.TabStop = False
        '
        'optWait
        '
        Me.optWait.AutoSize = True
        Me.optWait.Location = New System.Drawing.Point(93, 14)
        Me.optWait.Name = "optWait"
        Me.optWait.Size = New System.Drawing.Size(107, 17)
        Me.optWait.TabIndex = 2
        Me.optWait.TabStop = True
        Me.optWait.Text = "Wait for Approval"
        Me.optWait.UseVisualStyleBackColor = True
        '
        'cmdInsRow
        '
        Me.cmdInsRow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdInsRow.Location = New System.Drawing.Point(412, 0)
        Me.cmdInsRow.Name = "cmdInsRow"
        Me.cmdInsRow.Size = New System.Drawing.Size(56, 25)
        Me.cmdInsRow.TabIndex = 251
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
        Me.cmdDelete.TabIndex = 246
        Me.cmdDelete.TabStop = False
        Me.cmdDelete.Text = "&Delete"
        '
        'cmdSave
        '
        Me.cmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.Location = New System.Drawing.Point(56, 0)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(56, 25)
        Me.cmdSave.TabIndex = 245
        Me.cmdSave.TabStop = False
        Me.cmdSave.Text = "&Save"
        '
        'cmdLast
        '
        Me.cmdLast.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLast.Location = New System.Drawing.Point(650, 0)
        Me.cmdLast.Name = "cmdLast"
        Me.cmdLast.Size = New System.Drawing.Size(40, 25)
        Me.cmdLast.TabIndex = 256
        Me.cmdLast.TabStop = False
        Me.cmdLast.Text = ">>|"
        '
        'cmdPrevious
        '
        Me.cmdPrevious.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrevious.Location = New System.Drawing.Point(570, 0)
        Me.cmdPrevious.Name = "cmdPrevious"
        Me.cmdPrevious.Size = New System.Drawing.Size(40, 25)
        Me.cmdPrevious.TabIndex = 254
        Me.cmdPrevious.TabStop = False
        Me.cmdPrevious.Text = "<"
        '
        'cmdAdd
        '
        Me.cmdAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdd.Location = New System.Drawing.Point(0, 0)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(56, 25)
        Me.cmdAdd.TabIndex = 244
        Me.cmdAdd.TabStop = False
        Me.cmdAdd.Text = "&Add"
        '
        'cmdNext
        '
        Me.cmdNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNext.Location = New System.Drawing.Point(610, 0)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(40, 25)
        Me.cmdNext.TabIndex = 255
        Me.cmdNext.TabStop = False
        Me.cmdNext.Text = ">"
        '
        'cmdFind
        '
        Me.cmdFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFind.Location = New System.Drawing.Point(224, 0)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(56, 25)
        Me.cmdFind.TabIndex = 248
        Me.cmdFind.TabStop = False
        Me.cmdFind.Text = "&Find"
        '
        'cmdCopy
        '
        Me.cmdCopy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCopy.Location = New System.Drawing.Point(168, 0)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(56, 25)
        Me.cmdCopy.TabIndex = 247
        Me.cmdCopy.TabStop = False
        Me.cmdCopy.Text = "&Copy"
        '
        'cmdClear
        '
        Me.cmdClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(280, 0)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(56, 25)
        Me.cmdClear.TabIndex = 249
        Me.cmdClear.TabStop = False
        Me.cmdClear.Text = "Cl&ear"
        '
        'cmdExit
        '
        Me.cmdExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(696, 0)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(56, 25)
        Me.cmdExit.TabIndex = 257
        Me.cmdExit.TabStop = False
        Me.cmdExit.Text = "E&xit"
        '
        'cmdDelRow
        '
        Me.cmdDelRow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelRow.Location = New System.Drawing.Point(468, 0)
        Me.cmdDelRow.Name = "cmdDelRow"
        Me.cmdDelRow.Size = New System.Drawing.Size(56, 25)
        Me.cmdDelRow.TabIndex = 252
        Me.cmdDelRow.TabStop = False
        Me.cmdDelRow.Text = "Del Ro&w"
        '
        'cmdFirst
        '
        Me.cmdFirst.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFirst.Location = New System.Drawing.Point(530, 0)
        Me.cmdFirst.Name = "cmdFirst"
        Me.cmdFirst.Size = New System.Drawing.Size(40, 25)
        Me.cmdFirst.TabIndex = 253
        Me.cmdFirst.TabStop = False
        Me.cmdFirst.Text = "|<<"
        '
        'cmdSearch
        '
        Me.cmdSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(342, 0)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(64, 25)
        Me.cmdSearch.TabIndex = 250
        Me.cmdSearch.TabStop = False
        Me.cmdSearch.Text = "Searc&h"
        '
        'IMM00013
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(752, 483)
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
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.txtApplyTo)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtApplyFrom)
        Me.Controls.Add(Me.grdSummary)
        Me.Controls.Add(Me.txtDateTo)
        Me.Controls.Add(Me.txtDateFrom)
        Me.Controls.Add(Me.txtLineTo)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtLineFrom)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtPrdVenTo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtPrdVenFrom)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtDesVenTo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtDesVenFrom)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtCusVenTo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCusVenFrom)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtVenItm)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "IMM00013"
        Me.Text = "IMM00013 - Item Master Invalid Item Reactivation (Interal & Joint Venture Item)"
        CType(Me.grdSummary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusBar.ResumeLayout(False)
        Me.StatusBar.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtDateTo As System.Windows.Forms.TextBox
    Friend WithEvents txtDateFrom As System.Windows.Forms.TextBox
    Friend WithEvents txtLineTo As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtLineFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtPrdVenTo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPrdVenFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDesVenTo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDesVenFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCusVenTo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCusVenFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtVenItm As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grdSummary As System.Windows.Forms.DataGridView
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents txtApplyTo As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtApplyFrom As System.Windows.Forms.TextBox
    Friend WithEvents lblLeft As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblRight As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents optInvalid As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents optWait As System.Windows.Forms.RadioButton
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
End Class
