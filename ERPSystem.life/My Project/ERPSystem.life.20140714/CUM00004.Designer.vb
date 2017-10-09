<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CUM00004
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCus1no = New System.Windows.Forms.TextBox
        Me.txtCus2no = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtItmNo = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.tabFrame = New System.Windows.Forms.TabControl
        Me.tabSummary = New System.Windows.Forms.TabPage
        Me.dgSummary = New System.Windows.Forms.DataGridView
        Me.tabComponents = New System.Windows.Forms.TabPage
        Me.dgCUCPTBKD = New System.Windows.Forms.DataGridView
        Me.txtCPTColCde = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtCPTItmNo = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtCPTCust2No = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtCPTCus1No = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtColCde = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.tabFrame.SuspendLayout()
        Me.tabSummary.SuspendLayout()
        CType(Me.dgSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabComponents.SuspendLayout()
        CType(Me.dgCUCPTBKD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdDelete
        '
        Me.cmdDelete.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.cmdDelete.Location = New System.Drawing.Point(111, 0)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(56, 25)
        Me.cmdDelete.TabIndex = 2
        Me.cmdDelete.TabStop = False
        Me.cmdDelete.Text = "&Delete"
        '
        'cmdSave
        '
        Me.cmdSave.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.cmdSave.Location = New System.Drawing.Point(55, 0)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(56, 25)
        Me.cmdSave.TabIndex = 1
        Me.cmdSave.TabStop = False
        Me.cmdSave.Text = "&Save"
        '
        'cmdAdd
        '
        Me.cmdAdd.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.cmdAdd.Location = New System.Drawing.Point(-1, 0)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(56, 25)
        Me.cmdAdd.TabIndex = 0
        Me.cmdAdd.TabStop = False
        Me.cmdAdd.Text = "&Add"
        '
        'cmdLast
        '
        Me.cmdLast.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.cmdLast.Location = New System.Drawing.Point(649, 0)
        Me.cmdLast.Name = "cmdLast"
        Me.cmdLast.Size = New System.Drawing.Size(40, 25)
        Me.cmdLast.TabIndex = 12
        Me.cmdLast.TabStop = False
        Me.cmdLast.Text = ">>|"
        '
        'cmdPrevious
        '
        Me.cmdPrevious.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.cmdPrevious.Location = New System.Drawing.Point(569, 0)
        Me.cmdPrevious.Name = "cmdPrevious"
        Me.cmdPrevious.Size = New System.Drawing.Size(40, 25)
        Me.cmdPrevious.TabIndex = 10
        Me.cmdPrevious.TabStop = False
        Me.cmdPrevious.Text = "<"
        '
        'cmdNext
        '
        Me.cmdNext.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.cmdNext.Location = New System.Drawing.Point(609, 0)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(40, 25)
        Me.cmdNext.TabIndex = 11
        Me.cmdNext.TabStop = False
        Me.cmdNext.Text = ">"
        '
        'cmdFind
        '
        Me.cmdFind.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.cmdFind.Location = New System.Drawing.Point(223, 0)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(56, 25)
        Me.cmdFind.TabIndex = 4
        Me.cmdFind.TabStop = False
        Me.cmdFind.Text = "&Find"
        '
        'cmdCopy
        '
        Me.cmdCopy.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.cmdCopy.Location = New System.Drawing.Point(167, 0)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(56, 25)
        Me.cmdCopy.TabIndex = 3
        Me.cmdCopy.TabStop = False
        Me.cmdCopy.Text = "&Copy"
        '
        'cmdClear
        '
        Me.cmdClear.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.cmdClear.Location = New System.Drawing.Point(279, 0)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(56, 25)
        Me.cmdClear.TabIndex = 5
        Me.cmdClear.TabStop = False
        Me.cmdClear.Text = "Cl&ear"
        '
        'cmdExit
        '
        Me.cmdExit.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.cmdExit.Location = New System.Drawing.Point(695, 0)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(56, 25)
        Me.cmdExit.TabIndex = 13
        Me.cmdExit.TabStop = False
        Me.cmdExit.Text = "E&xit"
        '
        'cmdDelRow
        '
        Me.cmdDelRow.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.cmdDelRow.Location = New System.Drawing.Point(467, 0)
        Me.cmdDelRow.Name = "cmdDelRow"
        Me.cmdDelRow.Size = New System.Drawing.Size(56, 25)
        Me.cmdDelRow.TabIndex = 8
        Me.cmdDelRow.TabStop = False
        Me.cmdDelRow.Text = "Del Ro&w"
        '
        'cmdFirst
        '
        Me.cmdFirst.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.cmdFirst.Location = New System.Drawing.Point(529, 0)
        Me.cmdFirst.Name = "cmdFirst"
        Me.cmdFirst.Size = New System.Drawing.Size(40, 25)
        Me.cmdFirst.TabIndex = 9
        Me.cmdFirst.TabStop = False
        Me.cmdFirst.Text = "|<<"
        '
        'cmdInsRow
        '
        Me.cmdInsRow.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.cmdInsRow.Location = New System.Drawing.Point(411, 0)
        Me.cmdInsRow.Name = "cmdInsRow"
        Me.cmdInsRow.Size = New System.Drawing.Size(56, 25)
        Me.cmdInsRow.TabIndex = 7
        Me.cmdInsRow.TabStop = False
        Me.cmdInsRow.Text = "I&ns Row"
        '
        'cmdSearch
        '
        Me.cmdSearch.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.cmdSearch.Location = New System.Drawing.Point(341, 0)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(64, 25)
        Me.cmdSearch.TabIndex = 6
        Me.cmdSearch.TabStop = False
        Me.cmdSearch.Text = "Searc&h"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Primary Customer No."
        '
        'txtCus1no
        '
        Me.txtCus1no.BackColor = System.Drawing.Color.White
        Me.txtCus1no.Location = New System.Drawing.Point(143, 35)
        Me.txtCus1no.Name = "txtCus1no"
        Me.txtCus1no.Size = New System.Drawing.Size(97, 20)
        Me.txtCus1no.TabIndex = 15
        Me.txtCus1no.Text = "50000"
        '
        'txtCus2no
        '
        Me.txtCus2no.BackColor = System.Drawing.Color.White
        Me.txtCus2no.Location = New System.Drawing.Point(143, 61)
        Me.txtCus2no.Name = "txtCus2no"
        Me.txtCus2no.Size = New System.Drawing.Size(97, 20)
        Me.txtCus2no.TabIndex = 17
        Me.txtCus2no.Text = "60000"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Secondary Customer No."
        '
        'txtItmNo
        '
        Me.txtItmNo.BackColor = System.Drawing.Color.White
        Me.txtItmNo.Location = New System.Drawing.Point(143, 87)
        Me.txtItmNo.Name = "txtItmNo"
        Me.txtItmNo.Size = New System.Drawing.Size(136, 20)
        Me.txtItmNo.TabIndex = 19
        Me.txtItmNo.Text = "12A001A001A01"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Item Number"
        '
        'tabFrame
        '
        Me.tabFrame.Controls.Add(Me.tabSummary)
        Me.tabFrame.Controls.Add(Me.tabComponents)
        Me.tabFrame.ItemSize = New System.Drawing.Size(120, 19)
        Me.tabFrame.Location = New System.Drawing.Point(12, 113)
        Me.tabFrame.Name = "tabFrame"
        Me.tabFrame.SelectedIndex = 0
        Me.tabFrame.Size = New System.Drawing.Size(726, 308)
        Me.tabFrame.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabFrame.TabIndex = 20
        '
        'tabSummary
        '
        Me.tabSummary.Controls.Add(Me.dgSummary)
        Me.tabSummary.Location = New System.Drawing.Point(4, 23)
        Me.tabSummary.Name = "tabSummary"
        Me.tabSummary.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSummary.Size = New System.Drawing.Size(718, 281)
        Me.tabSummary.TabIndex = 0
        Me.tabSummary.Text = "Summary"
        Me.tabSummary.UseVisualStyleBackColor = True
        '
        'dgSummary
        '
        Me.dgSummary.AllowUserToAddRows = False
        Me.dgSummary.AllowUserToDeleteRows = False
        Me.dgSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSummary.Location = New System.Drawing.Point(6, 6)
        Me.dgSummary.Name = "dgSummary"
        Me.dgSummary.ReadOnly = True
        Me.dgSummary.RowHeadersWidth = 21
        Me.dgSummary.RowTemplate.Height = 20
        Me.dgSummary.Size = New System.Drawing.Size(706, 269)
        Me.dgSummary.TabIndex = 0
        '
        'tabComponents
        '
        Me.tabComponents.Controls.Add(Me.dgCUCPTBKD)
        Me.tabComponents.Controls.Add(Me.txtCPTColCde)
        Me.tabComponents.Controls.Add(Me.Label7)
        Me.tabComponents.Controls.Add(Me.txtCPTItmNo)
        Me.tabComponents.Controls.Add(Me.Label6)
        Me.tabComponents.Controls.Add(Me.txtCPTCust2No)
        Me.tabComponents.Controls.Add(Me.Label5)
        Me.tabComponents.Controls.Add(Me.txtCPTCus1No)
        Me.tabComponents.Controls.Add(Me.Label4)
        Me.tabComponents.Location = New System.Drawing.Point(4, 23)
        Me.tabComponents.Name = "tabComponents"
        Me.tabComponents.Padding = New System.Windows.Forms.Padding(3)
        Me.tabComponents.Size = New System.Drawing.Size(718, 281)
        Me.tabComponents.TabIndex = 1
        Me.tabComponents.Text = "Components"
        Me.tabComponents.UseVisualStyleBackColor = True
        '
        'dgCUCPTBKD
        '
        Me.dgCUCPTBKD.AllowUserToAddRows = False
        Me.dgCUCPTBKD.AllowUserToDeleteRows = False
        Me.dgCUCPTBKD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCUCPTBKD.Location = New System.Drawing.Point(6, 34)
        Me.dgCUCPTBKD.Name = "dgCUCPTBKD"
        Me.dgCUCPTBKD.ReadOnly = True
        Me.dgCUCPTBKD.RowHeadersWidth = 21
        Me.dgCUCPTBKD.Size = New System.Drawing.Size(706, 241)
        Me.dgCUCPTBKD.TabIndex = 8
        '
        'txtCPTColCde
        '
        Me.txtCPTColCde.BackColor = System.Drawing.Color.White
        Me.txtCPTColCde.Location = New System.Drawing.Point(582, 8)
        Me.txtCPTColCde.Name = "txtCPTColCde"
        Me.txtCPTColCde.Size = New System.Drawing.Size(120, 20)
        Me.txtCPTColCde.TabIndex = 7
        Me.txtCPTColCde.Text = "12A001A001A01"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(517, 11)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Color Code"
        '
        'txtCPTItmNo
        '
        Me.txtCPTItmNo.BackColor = System.Drawing.Color.White
        Me.txtCPTItmNo.Location = New System.Drawing.Point(376, 8)
        Me.txtCPTItmNo.Name = "txtCPTItmNo"
        Me.txtCPTItmNo.Size = New System.Drawing.Size(120, 20)
        Me.txtCPTItmNo.TabIndex = 5
        Me.txtCPTItmNo.Text = "12A001A001A01"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(323, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Item No."
        '
        'txtCPTCust2No
        '
        Me.txtCPTCust2No.BackColor = System.Drawing.Color.White
        Me.txtCPTCust2No.Location = New System.Drawing.Point(223, 8)
        Me.txtCPTCust2No.Name = "txtCPTCust2No"
        Me.txtCPTCust2No.Size = New System.Drawing.Size(79, 20)
        Me.txtCPTCust2No.TabIndex = 3
        Me.txtCPTCust2No.Text = "60000"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(164, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Sec Cust."
        '
        'txtCPTCus1No
        '
        Me.txtCPTCus1No.BackColor = System.Drawing.Color.White
        Me.txtCPTCus1No.Location = New System.Drawing.Point(64, 8)
        Me.txtCPTCus1No.Name = "txtCPTCus1No"
        Me.txtCPTCus1No.Size = New System.Drawing.Size(79, 20)
        Me.txtCPTCus1No.TabIndex = 1
        Me.txtCPTCus1No.Text = "50000"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Pri Cust."
        '
        'txtColCde
        '
        Me.txtColCde.BackColor = System.Drawing.Color.White
        Me.txtColCde.Location = New System.Drawing.Point(387, 87)
        Me.txtColCde.Name = "txtColCde"
        Me.txtColCde.Size = New System.Drawing.Size(136, 20)
        Me.txtColCde.TabIndex = 22
        Me.txtColCde.Text = "N/A"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(322, 90)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 13)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Color Code"
        '
        'CUM00004
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(750, 433)
        Me.Controls.Add(Me.txtColCde)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.tabFrame)
        Me.Controls.Add(Me.txtItmNo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCus2no)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCus1no)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdSave)
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
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "CUM00004"
        Me.Text = "CUM00004 - Customer Material Breakdown"
        Me.tabFrame.ResumeLayout(False)
        Me.tabSummary.ResumeLayout(False)
        CType(Me.dgSummary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabComponents.ResumeLayout(False)
        Me.tabComponents.PerformLayout()
        CType(Me.dgCUCPTBKD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCus1no As System.Windows.Forms.TextBox
    Friend WithEvents txtCus2no As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtItmNo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tabFrame As System.Windows.Forms.TabControl
    Friend WithEvents tabSummary As System.Windows.Forms.TabPage
    Friend WithEvents tabComponents As System.Windows.Forms.TabPage
    Friend WithEvents dgSummary As System.Windows.Forms.DataGridView
    Friend WithEvents txtCPTCus1No As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCPTColCde As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCPTItmNo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCPTCust2No As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dgCUCPTBKD As System.Windows.Forms.DataGridView
    Friend WithEvents txtColCde As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
