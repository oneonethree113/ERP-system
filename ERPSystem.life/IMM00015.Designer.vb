<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IMM00015
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
        Me.grpItem = New System.Windows.Forms.GroupBox
        Me.cmdItmAdd = New System.Windows.Forms.Button
        Me.cmdItmAll = New System.Windows.Forms.Button
        Me.cmdItmClr = New System.Windows.Forms.Button
        Me.dgItem = New System.Windows.Forms.DataGridView
        Me.cmdItmSearch = New System.Windows.Forms.Button
        Me.txtItmNo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.grpExport = New System.Windows.Forms.GroupBox
        Me.cmdXLSRemove = New System.Windows.Forms.Button
        Me.cmdExport = New System.Windows.Forms.Button
        Me.cmdXLSAll = New System.Windows.Forms.Button
        Me.cmdXLSClr = New System.Windows.Forms.Button
        Me.dgExport = New System.Windows.Forms.DataGridView
        Me.cmdFilNamReset = New System.Windows.Forms.Button
        Me.txtFilNam = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtItmCount = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.grpItem.SuspendLayout()
        CType(Me.dgItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpExport.SuspendLayout()
        CType(Me.dgExport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(894, 0)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(60, 25)
        Me.cmdExit.TabIndex = 13
        Me.cmdExit.Text = "E&xit"
        '
        'cmdInsRow
        '
        Me.cmdInsRow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdInsRow.Location = New System.Drawing.Point(520, 0)
        Me.cmdInsRow.Name = "cmdInsRow"
        Me.cmdInsRow.Size = New System.Drawing.Size(65, 25)
        Me.cmdInsRow.TabIndex = 7
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
        Me.cmdDelete.TabIndex = 2
        Me.cmdDelete.TabStop = False
        Me.cmdDelete.Text = "&Delete"
        '
        'cmdSave
        '
        Me.cmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.Location = New System.Drawing.Point(65, 0)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(65, 25)
        Me.cmdSave.TabIndex = 1
        Me.cmdSave.TabStop = False
        Me.cmdSave.Text = "&Save"
        '
        'cmdLast
        '
        Me.cmdLast.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLast.Location = New System.Drawing.Point(820, 0)
        Me.cmdLast.Name = "cmdLast"
        Me.cmdLast.Size = New System.Drawing.Size(50, 25)
        Me.cmdLast.TabIndex = 12
        Me.cmdLast.TabStop = False
        Me.cmdLast.Text = ">>|"
        '
        'cmdPrevious
        '
        Me.cmdPrevious.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrevious.Location = New System.Drawing.Point(720, 0)
        Me.cmdPrevious.Name = "cmdPrevious"
        Me.cmdPrevious.Size = New System.Drawing.Size(50, 25)
        Me.cmdPrevious.TabIndex = 10
        Me.cmdPrevious.TabStop = False
        Me.cmdPrevious.Text = "<"
        '
        'cmdAdd
        '
        Me.cmdAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdd.Location = New System.Drawing.Point(0, 0)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(65, 25)
        Me.cmdAdd.TabIndex = 0
        Me.cmdAdd.TabStop = False
        Me.cmdAdd.Text = "&Add"
        '
        'cmdNext
        '
        Me.cmdNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNext.Location = New System.Drawing.Point(770, 0)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(50, 25)
        Me.cmdNext.TabIndex = 11
        Me.cmdNext.TabStop = False
        Me.cmdNext.Text = ">"
        '
        'cmdFind
        '
        Me.cmdFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFind.Location = New System.Drawing.Point(260, 0)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(65, 25)
        Me.cmdFind.TabIndex = 4
        Me.cmdFind.TabStop = False
        Me.cmdFind.Text = "&Find"
        '
        'cmdCopy
        '
        Me.cmdCopy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCopy.Location = New System.Drawing.Point(195, 0)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(65, 25)
        Me.cmdCopy.TabIndex = 3
        Me.cmdCopy.TabStop = False
        Me.cmdCopy.Text = "&Copy"
        '
        'cmdClear
        '
        Me.cmdClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(325, 0)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(65, 25)
        Me.cmdClear.TabIndex = 5
        Me.cmdClear.TabStop = False
        Me.cmdClear.Text = "Cl&ear"
        '
        'cmdDelRow
        '
        Me.cmdDelRow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelRow.Location = New System.Drawing.Point(585, 0)
        Me.cmdDelRow.Name = "cmdDelRow"
        Me.cmdDelRow.Size = New System.Drawing.Size(65, 25)
        Me.cmdDelRow.TabIndex = 8
        Me.cmdDelRow.TabStop = False
        Me.cmdDelRow.Text = "Del Ro&w"
        '
        'cmdFirst
        '
        Me.cmdFirst.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFirst.Location = New System.Drawing.Point(670, 0)
        Me.cmdFirst.Name = "cmdFirst"
        Me.cmdFirst.Size = New System.Drawing.Size(50, 25)
        Me.cmdFirst.TabIndex = 9
        Me.cmdFirst.TabStop = False
        Me.cmdFirst.Text = "|<<"
        '
        'cmdSearch
        '
        Me.cmdSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(420, 0)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(65, 25)
        Me.cmdSearch.TabIndex = 6
        Me.cmdSearch.TabStop = False
        Me.cmdSearch.Text = "Searc&h"
        '
        'grpItem
        '
        Me.grpItem.Controls.Add(Me.cmdItmAdd)
        Me.grpItem.Controls.Add(Me.cmdItmAll)
        Me.grpItem.Controls.Add(Me.cmdItmClr)
        Me.grpItem.Controls.Add(Me.dgItem)
        Me.grpItem.Controls.Add(Me.cmdItmSearch)
        Me.grpItem.Controls.Add(Me.txtItmNo)
        Me.grpItem.Controls.Add(Me.Label1)
        Me.grpItem.Location = New System.Drawing.Point(12, 31)
        Me.grpItem.Name = "grpItem"
        Me.grpItem.Size = New System.Drawing.Size(928, 240)
        Me.grpItem.TabIndex = 14
        Me.grpItem.TabStop = False
        Me.grpItem.Text = "Item Master Search"
        '
        'cmdItmAdd
        '
        Me.cmdItmAdd.Location = New System.Drawing.Point(505, 17)
        Me.cmdItmAdd.Name = "cmdItmAdd"
        Me.cmdItmAdd.Size = New System.Drawing.Size(104, 23)
        Me.cmdItmAdd.TabIndex = 6
        Me.cmdItmAdd.Text = "Add Selected"
        Me.cmdItmAdd.UseVisualStyleBackColor = True
        '
        'cmdItmAll
        '
        Me.cmdItmAll.Location = New System.Drawing.Point(409, 17)
        Me.cmdItmAll.Name = "cmdItmAll"
        Me.cmdItmAll.Size = New System.Drawing.Size(90, 23)
        Me.cmdItmAll.TabIndex = 5
        Me.cmdItmAll.Text = "Select All"
        Me.cmdItmAll.UseVisualStyleBackColor = True
        '
        'cmdItmClr
        '
        Me.cmdItmClr.Location = New System.Drawing.Point(313, 17)
        Me.cmdItmClr.Name = "cmdItmClr"
        Me.cmdItmClr.Size = New System.Drawing.Size(90, 23)
        Me.cmdItmClr.TabIndex = 4
        Me.cmdItmClr.Text = "Clear Selection"
        Me.cmdItmClr.UseVisualStyleBackColor = True
        '
        'dgItem
        '
        Me.dgItem.AllowUserToAddRows = False
        Me.dgItem.AllowUserToDeleteRows = False
        Me.dgItem.ColumnHeadersHeight = 18
        Me.dgItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgItem.Location = New System.Drawing.Point(9, 46)
        Me.dgItem.Name = "dgItem"
        Me.dgItem.ReadOnly = True
        Me.dgItem.RowHeadersWidth = 20
        Me.dgItem.RowTemplate.Height = 20
        Me.dgItem.Size = New System.Drawing.Size(913, 188)
        Me.dgItem.TabIndex = 3
        '
        'cmdItmSearch
        '
        Me.cmdItmSearch.Location = New System.Drawing.Point(208, 17)
        Me.cmdItmSearch.Name = "cmdItmSearch"
        Me.cmdItmSearch.Size = New System.Drawing.Size(75, 23)
        Me.cmdItmSearch.TabIndex = 2
        Me.cmdItmSearch.Text = "Search"
        Me.cmdItmSearch.UseVisualStyleBackColor = True
        '
        'txtItmNo
        '
        Me.txtItmNo.Location = New System.Drawing.Point(79, 19)
        Me.txtItmNo.Name = "txtItmNo"
        Me.txtItmNo.Size = New System.Drawing.Size(123, 20)
        Me.txtItmNo.TabIndex = 1
        Me.txtItmNo.Text = "F12TD01235MIC"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Item Number"
        '
        'grpExport
        '
        Me.grpExport.Controls.Add(Me.cmdXLSRemove)
        Me.grpExport.Controls.Add(Me.cmdExport)
        Me.grpExport.Controls.Add(Me.cmdXLSAll)
        Me.grpExport.Controls.Add(Me.cmdXLSClr)
        Me.grpExport.Controls.Add(Me.dgExport)
        Me.grpExport.Controls.Add(Me.cmdFilNamReset)
        Me.grpExport.Controls.Add(Me.txtFilNam)
        Me.grpExport.Controls.Add(Me.Label3)
        Me.grpExport.Controls.Add(Me.txtItmCount)
        Me.grpExport.Controls.Add(Me.Label2)
        Me.grpExport.Location = New System.Drawing.Point(12, 277)
        Me.grpExport.Name = "grpExport"
        Me.grpExport.Size = New System.Drawing.Size(928, 240)
        Me.grpExport.TabIndex = 15
        Me.grpExport.TabStop = False
        Me.grpExport.Text = "Items Pending for Export"
        '
        'cmdXLSRemove
        '
        Me.cmdXLSRemove.Location = New System.Drawing.Point(334, 17)
        Me.cmdXLSRemove.Name = "cmdXLSRemove"
        Me.cmdXLSRemove.Size = New System.Drawing.Size(105, 23)
        Me.cmdXLSRemove.TabIndex = 7
        Me.cmdXLSRemove.Text = "Remove Selected"
        Me.cmdXLSRemove.UseVisualStyleBackColor = True
        '
        'cmdExport
        '
        Me.cmdExport.Location = New System.Drawing.Point(818, 17)
        Me.cmdExport.Name = "cmdExport"
        Me.cmdExport.Size = New System.Drawing.Size(104, 23)
        Me.cmdExport.TabIndex = 11
        Me.cmdExport.Text = "Export to Excel"
        Me.cmdExport.UseVisualStyleBackColor = True
        '
        'cmdXLSAll
        '
        Me.cmdXLSAll.Location = New System.Drawing.Point(238, 17)
        Me.cmdXLSAll.Name = "cmdXLSAll"
        Me.cmdXLSAll.Size = New System.Drawing.Size(90, 23)
        Me.cmdXLSAll.TabIndex = 6
        Me.cmdXLSAll.Text = "Select All"
        Me.cmdXLSAll.UseVisualStyleBackColor = True
        '
        'cmdXLSClr
        '
        Me.cmdXLSClr.Location = New System.Drawing.Point(142, 17)
        Me.cmdXLSClr.Name = "cmdXLSClr"
        Me.cmdXLSClr.Size = New System.Drawing.Size(90, 23)
        Me.cmdXLSClr.TabIndex = 5
        Me.cmdXLSClr.Text = "Clear Selection"
        Me.cmdXLSClr.UseVisualStyleBackColor = True
        '
        'dgExport
        '
        Me.dgExport.AllowUserToAddRows = False
        Me.dgExport.AllowUserToDeleteRows = False
        Me.dgExport.ColumnHeadersHeight = 18
        Me.dgExport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgExport.Location = New System.Drawing.Point(9, 45)
        Me.dgExport.Name = "dgExport"
        Me.dgExport.ReadOnly = True
        Me.dgExport.RowHeadersWidth = 20
        Me.dgExport.RowTemplate.Height = 20
        Me.dgExport.Size = New System.Drawing.Size(913, 188)
        Me.dgExport.TabIndex = 4
        '
        'cmdFilNamReset
        '
        Me.cmdFilNamReset.Location = New System.Drawing.Point(712, 17)
        Me.cmdFilNamReset.Name = "cmdFilNamReset"
        Me.cmdFilNamReset.Size = New System.Drawing.Size(100, 23)
        Me.cmdFilNamReset.TabIndex = 10
        Me.cmdFilNamReset.Text = "Reset Filename"
        Me.cmdFilNamReset.UseVisualStyleBackColor = True
        '
        'txtFilNam
        '
        Me.txtFilNam.Location = New System.Drawing.Point(513, 19)
        Me.txtFilNam.Name = "txtFilNam"
        Me.txtFilNam.Size = New System.Drawing.Size(193, 20)
        Me.txtFilNam.TabIndex = 9
        Me.txtFilNam.Text = "abc.xls"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(458, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Filename"
        '
        'txtItmCount
        '
        Me.txtItmCount.Location = New System.Drawing.Point(96, 19)
        Me.txtItmCount.Name = "txtItmCount"
        Me.txtItmCount.Size = New System.Drawing.Size(34, 20)
        Me.txtItmCount.TabIndex = 3
        Me.txtItmCount.Text = "123"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Number of Items"
        '
        'IMM00015
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(952, 528)
        Me.Controls.Add(Me.grpExport)
        Me.Controls.Add(Me.grpItem)
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
        Me.Name = "IMM00015"
        Me.Text = "IMM00015 - Item Master Data Export (External Item)"
        Me.grpItem.ResumeLayout(False)
        Me.grpItem.PerformLayout()
        CType(Me.dgItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpExport.ResumeLayout(False)
        Me.grpExport.PerformLayout()
        CType(Me.dgExport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

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
    Friend WithEvents grpItem As System.Windows.Forms.GroupBox
    Friend WithEvents grpExport As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdItmSearch As System.Windows.Forms.Button
    Friend WithEvents txtItmNo As System.Windows.Forms.TextBox
    Friend WithEvents cmdItmAdd As System.Windows.Forms.Button
    Friend WithEvents cmdItmAll As System.Windows.Forms.Button
    Friend WithEvents cmdItmClr As System.Windows.Forms.Button
    Friend WithEvents dgItem As System.Windows.Forms.DataGridView
    Friend WithEvents txtItmCount As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdExport As System.Windows.Forms.Button
    Friend WithEvents cmdXLSAll As System.Windows.Forms.Button
    Friend WithEvents cmdXLSClr As System.Windows.Forms.Button
    Friend WithEvents dgExport As System.Windows.Forms.DataGridView
    Friend WithEvents cmdFilNamReset As System.Windows.Forms.Button
    Friend WithEvents txtFilNam As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdXLSRemove As System.Windows.Forms.Button
End Class
