<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PGM00005
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
        Me.cmdExit = New System.Windows.Forms.Button
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
        Me.cmdDelRow = New System.Windows.Forms.Button
        Me.cmdFirst = New System.Windows.Forms.Button
        Me.cmdSearch = New System.Windows.Forms.Button
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtBJNo = New System.Windows.Forms.TextBox
        Me.txtRunNoFrm = New System.Windows.Forms.TextBox
        Me.txtRunNoTo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtJobOrdTo = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtJobOrdFrm = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboRptFmt = New System.Windows.Forms.ComboBox
        Me.cmdApply = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.grpOutFmt = New System.Windows.Forms.GroupBox
        Me.optExcel = New System.Windows.Forms.RadioButton
        Me.optPDF = New System.Windows.Forms.RadioButton
        Me.dgBatchJob = New System.Windows.Forms.DataGridView
        Me.txtCount = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.txtMsg = New System.Windows.Forms.TextBox
        Me.grpOutFmt.SuspendLayout()
        CType(Me.dgBatchJob, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(923, 0)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(60, 25)
        Me.cmdExit.TabIndex = 68
        Me.cmdExit.Text = "E&xit"
        '
        'cmdInsRow
        '
        Me.cmdInsRow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdInsRow.Location = New System.Drawing.Point(531, 0)
        Me.cmdInsRow.Name = "cmdInsRow"
        Me.cmdInsRow.Size = New System.Drawing.Size(65, 25)
        Me.cmdInsRow.TabIndex = 62
        Me.cmdInsRow.TabStop = False
        Me.cmdInsRow.Text = "I&ns Row"
        Me.cmdInsRow.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelete.Location = New System.Drawing.Point(130, 0)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(65, 25)
        Me.cmdDelete.TabIndex = 57
        Me.cmdDelete.TabStop = False
        Me.cmdDelete.Text = "&Delete"
        '
        'cmdSave
        '
        Me.cmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.Location = New System.Drawing.Point(65, 0)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(65, 25)
        Me.cmdSave.TabIndex = 56
        Me.cmdSave.TabStop = False
        Me.cmdSave.Text = "&Save"
        '
        'cmdLast
        '
        Me.cmdLast.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLast.Location = New System.Drawing.Point(846, 0)
        Me.cmdLast.Name = "cmdLast"
        Me.cmdLast.Size = New System.Drawing.Size(50, 25)
        Me.cmdLast.TabIndex = 67
        Me.cmdLast.TabStop = False
        Me.cmdLast.Text = ">>|"
        '
        'cmdPrevious
        '
        Me.cmdPrevious.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrevious.Location = New System.Drawing.Point(746, 0)
        Me.cmdPrevious.Name = "cmdPrevious"
        Me.cmdPrevious.Size = New System.Drawing.Size(50, 25)
        Me.cmdPrevious.TabIndex = 65
        Me.cmdPrevious.TabStop = False
        Me.cmdPrevious.Text = "<"
        '
        'cmdAdd
        '
        Me.cmdAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdd.Location = New System.Drawing.Point(0, 0)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(65, 25)
        Me.cmdAdd.TabIndex = 55
        Me.cmdAdd.TabStop = False
        Me.cmdAdd.Text = "&Add"
        '
        'cmdNext
        '
        Me.cmdNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNext.Location = New System.Drawing.Point(796, 0)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(50, 25)
        Me.cmdNext.TabIndex = 66
        Me.cmdNext.TabStop = False
        Me.cmdNext.Text = ">"
        '
        'cmdFind
        '
        Me.cmdFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFind.Location = New System.Drawing.Point(260, 0)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(65, 25)
        Me.cmdFind.TabIndex = 59
        Me.cmdFind.TabStop = False
        Me.cmdFind.Text = "&Find"
        '
        'cmdCopy
        '
        Me.cmdCopy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCopy.Location = New System.Drawing.Point(195, 0)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(65, 25)
        Me.cmdCopy.TabIndex = 58
        Me.cmdCopy.TabStop = False
        Me.cmdCopy.Text = "&Copy"
        '
        'cmdClear
        '
        Me.cmdClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(325, 0)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(65, 25)
        Me.cmdClear.TabIndex = 60
        Me.cmdClear.TabStop = False
        Me.cmdClear.Text = "Cl&ear"
        '
        'cmdDelRow
        '
        Me.cmdDelRow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelRow.Location = New System.Drawing.Point(596, 0)
        Me.cmdDelRow.Name = "cmdDelRow"
        Me.cmdDelRow.Size = New System.Drawing.Size(65, 25)
        Me.cmdDelRow.TabIndex = 63
        Me.cmdDelRow.TabStop = False
        Me.cmdDelRow.Text = "Del Ro&w"
        '
        'cmdFirst
        '
        Me.cmdFirst.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFirst.Location = New System.Drawing.Point(696, 0)
        Me.cmdFirst.Name = "cmdFirst"
        Me.cmdFirst.Size = New System.Drawing.Size(50, 25)
        Me.cmdFirst.TabIndex = 64
        Me.cmdFirst.TabStop = False
        Me.cmdFirst.Text = "|<<"
        '
        'cmdSearch
        '
        Me.cmdSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(428, 0)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(65, 25)
        Me.cmdSearch.TabIndex = 61
        Me.cmdSearch.TabStop = False
        Me.cmdSearch.Text = "Searc&h"
        '
        'cboCoCde
        '
        Me.cboCoCde.BackColor = System.Drawing.Color.White
        Me.cboCoCde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(114, 34)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(81, 21)
        Me.cboCoCde.TabIndex = 259
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(6, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 260
        Me.Label1.Text = "Company Code"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 13)
        Me.Label2.TabIndex = 261
        Me.Label2.Text = "Packaging Order No."
        '
        'txtBJNo
        '
        Me.txtBJNo.BackColor = System.Drawing.Color.White
        Me.txtBJNo.Location = New System.Drawing.Point(114, 60)
        Me.txtBJNo.Name = "txtBJNo"
        Me.txtBJNo.Size = New System.Drawing.Size(150, 20)
        Me.txtBJNo.TabIndex = 262
        '
        'txtRunNoFrm
        '
        Me.txtRunNoFrm.BackColor = System.Drawing.Color.White
        Me.txtRunNoFrm.Location = New System.Drawing.Point(176, 87)
        Me.txtRunNoFrm.Name = "txtRunNoFrm"
        Me.txtRunNoFrm.Size = New System.Drawing.Size(150, 20)
        Me.txtRunNoFrm.TabIndex = 264
        '
        'txtRunNoTo
        '
        Me.txtRunNoTo.BackColor = System.Drawing.Color.White
        Me.txtRunNoTo.Location = New System.Drawing.Point(358, 87)
        Me.txtRunNoTo.Name = "txtRunNoTo"
        Me.txtRunNoTo.Size = New System.Drawing.Size(150, 20)
        Me.txtRunNoTo.TabIndex = 266
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(332, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(20, 13)
        Me.Label4.TabIndex = 265
        Me.Label4.Text = "To"
        '
        'txtJobOrdTo
        '
        Me.txtJobOrdTo.BackColor = System.Drawing.Color.White
        Me.txtJobOrdTo.Location = New System.Drawing.Point(902, 37)
        Me.txtJobOrdTo.Name = "txtJobOrdTo"
        Me.txtJobOrdTo.Size = New System.Drawing.Size(10, 20)
        Me.txtJobOrdTo.TabIndex = 270
        Me.txtJobOrdTo.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(876, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(20, 13)
        Me.Label5.TabIndex = 269
        Me.Label5.Text = "To"
        Me.Label5.Visible = False
        '
        'txtJobOrdFrm
        '
        Me.txtJobOrdFrm.BackColor = System.Drawing.Color.White
        Me.txtJobOrdFrm.Location = New System.Drawing.Point(859, 37)
        Me.txtJobOrdFrm.Name = "txtJobOrdFrm"
        Me.txtJobOrdFrm.Size = New System.Drawing.Size(11, 20)
        Me.txtJobOrdFrm.TabIndex = 268
        Me.txtJobOrdFrm.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(847, 67)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 13)
        Me.Label6.TabIndex = 267
        Me.Label6.Text = "Packaging Order No."
        Me.Label6.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 13)
        Me.Label3.TabIndex = 263
        Me.Label3.Text = "Packaging Request No."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(140, 90)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 271
        Me.Label7.Text = "From"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(823, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 13)
        Me.Label8.TabIndex = 272
        Me.Label8.Text = "From"
        Me.Label8.Visible = False
        '
        'cboRptFmt
        '
        Me.cboRptFmt.BackColor = System.Drawing.Color.White
        Me.cboRptFmt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRptFmt.FormattingEnabled = True
        Me.cboRptFmt.Location = New System.Drawing.Point(790, 31)
        Me.cboRptFmt.Name = "cboRptFmt"
        Me.cboRptFmt.Size = New System.Drawing.Size(30, 21)
        Me.cboRptFmt.TabIndex = 273
        Me.cboRptFmt.Visible = False
        '
        'cmdApply
        '
        Me.cmdApply.Location = New System.Drawing.Point(625, 84)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.Size = New System.Drawing.Size(85, 23)
        Me.cmdApply.TabIndex = 274
        Me.cmdApply.Text = "Apply"
        Me.cmdApply.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Location = New System.Drawing.Point(756, 62)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(85, 23)
        Me.cmdPrint.TabIndex = 275
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        Me.cmdPrint.Visible = False
        '
        'grpOutFmt
        '
        Me.grpOutFmt.Controls.Add(Me.optExcel)
        Me.grpOutFmt.Controls.Add(Me.optPDF)
        Me.grpOutFmt.Location = New System.Drawing.Point(712, 34)
        Me.grpOutFmt.Name = "grpOutFmt"
        Me.grpOutFmt.Size = New System.Drawing.Size(58, 23)
        Me.grpOutFmt.TabIndex = 276
        Me.grpOutFmt.TabStop = False
        Me.grpOutFmt.Text = "Output Format"
        Me.grpOutFmt.Visible = False
        '
        'optExcel
        '
        Me.optExcel.AutoSize = True
        Me.optExcel.Location = New System.Drawing.Point(111, 20)
        Me.optExcel.Name = "optExcel"
        Me.optExcel.Size = New System.Drawing.Size(51, 17)
        Me.optExcel.TabIndex = 1
        Me.optExcel.TabStop = True
        Me.optExcel.Text = "Excel"
        Me.optExcel.UseVisualStyleBackColor = True
        '
        'optPDF
        '
        Me.optPDF.AutoSize = True
        Me.optPDF.Location = New System.Drawing.Point(39, 20)
        Me.optPDF.Name = "optPDF"
        Me.optPDF.Size = New System.Drawing.Size(46, 17)
        Me.optPDF.TabIndex = 0
        Me.optPDF.TabStop = True
        Me.optPDF.Text = "PDF"
        Me.optPDF.UseVisualStyleBackColor = True
        '
        'dgBatchJob
        '
        Me.dgBatchJob.AllowUserToAddRows = False
        Me.dgBatchJob.AllowUserToDeleteRows = False
        Me.dgBatchJob.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgBatchJob.Location = New System.Drawing.Point(9, 113)
        Me.dgBatchJob.Name = "dgBatchJob"
        Me.dgBatchJob.ReadOnly = True
        Me.dgBatchJob.Size = New System.Drawing.Size(967, 310)
        Me.dgBatchJob.TabIndex = 277
        '
        'txtCount
        '
        Me.txtCount.BackColor = System.Drawing.Color.White
        Me.txtCount.Location = New System.Drawing.Point(863, 523)
        Me.txtCount.Name = "txtCount"
        Me.txtCount.Size = New System.Drawing.Size(99, 20)
        Me.txtCount.TabIndex = 279
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(784, 526)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 13)
        Me.Label9.TabIndex = 278
        Me.Label9.Text = "Record Count"
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.Color.White
        Me.txtCoNam.Location = New System.Drawing.Point(201, 34)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.ReadOnly = True
        Me.txtCoNam.Size = New System.Drawing.Size(389, 20)
        Me.txtCoNam.TabIndex = 280
        '
        'txtMsg
        '
        Me.txtMsg.BackColor = System.Drawing.Color.White
        Me.txtMsg.Location = New System.Drawing.Point(9, 439)
        Me.txtMsg.Multiline = True
        Me.txtMsg.Name = "txtMsg"
        Me.txtMsg.Size = New System.Drawing.Size(737, 117)
        Me.txtMsg.TabIndex = 281
        '
        'PGM00005
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(985, 568)
        Me.Controls.Add(Me.txtMsg)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.txtCount)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.dgBatchJob)
        Me.Controls.Add(Me.grpOutFmt)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.cboRptFmt)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtJobOrdTo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtJobOrdFrm)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtRunNoTo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtRunNoFrm)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtBJNo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdExit)
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
        Me.Controls.Add(Me.cmdDelRow)
        Me.Controls.Add(Me.cmdFirst)
        Me.Controls.Add(Me.cmdSearch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(991, 600)
        Me.MinimumSize = New System.Drawing.Size(991, 600)
        Me.Name = "PGM00005"
        Me.Text = "PGM00005 - Packaging Order Generation and Update"
        Me.grpOutFmt.ResumeLayout(False)
        Me.grpOutFmt.PerformLayout()
        CType(Me.dgBatchJob, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdExit As System.Windows.Forms.Button
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
    Friend WithEvents cmdDelRow As System.Windows.Forms.Button
    Friend WithEvents cmdFirst As System.Windows.Forms.Button
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBJNo As System.Windows.Forms.TextBox
    Friend WithEvents txtRunNoFrm As System.Windows.Forms.TextBox
    Friend WithEvents txtRunNoTo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtJobOrdTo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtJobOrdFrm As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboRptFmt As System.Windows.Forms.ComboBox
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents grpOutFmt As System.Windows.Forms.GroupBox
    Friend WithEvents optExcel As System.Windows.Forms.RadioButton
    Friend WithEvents optPDF As System.Windows.Forms.RadioButton
    Friend WithEvents dgBatchJob As System.Windows.Forms.DataGridView
    Friend WithEvents txtCount As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents txtMsg As System.Windows.Forms.TextBox
End Class
