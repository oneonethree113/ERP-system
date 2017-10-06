<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SYS00002
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
        Me.GrpBoxMain = New System.Windows.Forms.GroupBox
        Me.DataGrid = New System.Windows.Forms.DataGridView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.DataGridRights = New System.Windows.Forms.DataGridView
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtAccExp = New System.Windows.Forms.MaskedTextBox
        Me.txtExpDat = New System.Windows.Forms.MaskedTextBox
        Me.txtMailAd = New System.Windows.Forms.TextBox
        Me.txtConPwd = New System.Windows.Forms.TextBox
        Me.txtUsrPwd = New System.Windows.Forms.TextBox
        Me.txtUsrNam = New System.Windows.Forms.TextBox
        Me.txtUsrID = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.StatusBar = New System.Windows.Forms.StatusStrip
        Me.lblLeft = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblRight = New System.Windows.Forms.ToolStripStatusLabel
        Me.GrpBoxMain.SuspendLayout()
        CType(Me.DataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGridRights, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdDelete
        '
        Me.cmdDelete.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelete.Location = New System.Drawing.Point(113, 1)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(56, 40)
        Me.cmdDelete.TabIndex = 181
        Me.cmdDelete.TabStop = False
        Me.cmdDelete.Text = "&Delete"
        '
        'cmdSave
        '
        Me.cmdSave.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.Location = New System.Drawing.Point(57, 1)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(56, 40)
        Me.cmdSave.TabIndex = 180
        Me.cmdSave.TabStop = False
        Me.cmdSave.Text = "&Save"
        '
        'cmdAdd
        '
        Me.cmdAdd.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdd.Location = New System.Drawing.Point(1, 1)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(56, 40)
        Me.cmdAdd.TabIndex = 179
        Me.cmdAdd.TabStop = False
        Me.cmdAdd.Text = "&Add"
        '
        'cmdLast
        '
        Me.cmdLast.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLast.Location = New System.Drawing.Point(649, 1)
        Me.cmdLast.Name = "cmdLast"
        Me.cmdLast.Size = New System.Drawing.Size(40, 40)
        Me.cmdLast.TabIndex = 191
        Me.cmdLast.TabStop = False
        Me.cmdLast.Text = ">>|"
        '
        'cmdPrevious
        '
        Me.cmdPrevious.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrevious.Location = New System.Drawing.Point(569, 1)
        Me.cmdPrevious.Name = "cmdPrevious"
        Me.cmdPrevious.Size = New System.Drawing.Size(40, 40)
        Me.cmdPrevious.TabIndex = 189
        Me.cmdPrevious.TabStop = False
        Me.cmdPrevious.Text = "<"
        '
        'cmdNext
        '
        Me.cmdNext.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNext.Location = New System.Drawing.Point(609, 1)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(40, 40)
        Me.cmdNext.TabIndex = 190
        Me.cmdNext.TabStop = False
        Me.cmdNext.Text = ">"
        '
        'cmdFind
        '
        Me.cmdFind.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFind.Location = New System.Drawing.Point(225, 1)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(56, 40)
        Me.cmdFind.TabIndex = 183
        Me.cmdFind.TabStop = False
        Me.cmdFind.Text = "&Find"
        '
        'cmdCopy
        '
        Me.cmdCopy.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCopy.Location = New System.Drawing.Point(169, 1)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(56, 40)
        Me.cmdCopy.TabIndex = 182
        Me.cmdCopy.TabStop = False
        Me.cmdCopy.Text = "&Copy"
        '
        'cmdClear
        '
        Me.cmdClear.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(281, 1)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(56, 40)
        Me.cmdClear.TabIndex = 184
        Me.cmdClear.TabStop = False
        Me.cmdClear.Text = "Cl&ear"
        '
        'cmdExit
        '
        Me.cmdExit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(695, 1)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(56, 40)
        Me.cmdExit.TabIndex = 192
        Me.cmdExit.TabStop = False
        Me.cmdExit.Text = "E&xit"
        '
        'cmdDelRow
        '
        Me.cmdDelRow.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelRow.Location = New System.Drawing.Point(469, 1)
        Me.cmdDelRow.Name = "cmdDelRow"
        Me.cmdDelRow.Size = New System.Drawing.Size(56, 40)
        Me.cmdDelRow.TabIndex = 187
        Me.cmdDelRow.TabStop = False
        Me.cmdDelRow.Text = "Del Ro&w"
        '
        'cmdFirst
        '
        Me.cmdFirst.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFirst.Location = New System.Drawing.Point(529, 1)
        Me.cmdFirst.Name = "cmdFirst"
        Me.cmdFirst.Size = New System.Drawing.Size(40, 40)
        Me.cmdFirst.TabIndex = 188
        Me.cmdFirst.TabStop = False
        Me.cmdFirst.Text = "|<<"
        '
        'cmdInsRow
        '
        Me.cmdInsRow.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdInsRow.Location = New System.Drawing.Point(413, 1)
        Me.cmdInsRow.Name = "cmdInsRow"
        Me.cmdInsRow.Size = New System.Drawing.Size(56, 40)
        Me.cmdInsRow.TabIndex = 186
        Me.cmdInsRow.TabStop = False
        Me.cmdInsRow.Text = "I&ns Row"
        '
        'cmdSearch
        '
        Me.cmdSearch.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(343, 1)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(64, 40)
        Me.cmdSearch.TabIndex = 185
        Me.cmdSearch.TabStop = False
        Me.cmdSearch.Text = "Searc&h"
        '
        'GrpBoxMain
        '
        Me.GrpBoxMain.Controls.Add(Me.DataGrid)
        Me.GrpBoxMain.Controls.Add(Me.GroupBox2)
        Me.GrpBoxMain.Controls.Add(Me.Label9)
        Me.GrpBoxMain.Controls.Add(Me.Label8)
        Me.GrpBoxMain.Controls.Add(Me.txtAccExp)
        Me.GrpBoxMain.Controls.Add(Me.txtExpDat)
        Me.GrpBoxMain.Controls.Add(Me.txtMailAd)
        Me.GrpBoxMain.Controls.Add(Me.txtConPwd)
        Me.GrpBoxMain.Controls.Add(Me.txtUsrPwd)
        Me.GrpBoxMain.Controls.Add(Me.txtUsrNam)
        Me.GrpBoxMain.Controls.Add(Me.txtUsrID)
        Me.GrpBoxMain.Controls.Add(Me.Label7)
        Me.GrpBoxMain.Controls.Add(Me.Label6)
        Me.GrpBoxMain.Controls.Add(Me.Label5)
        Me.GrpBoxMain.Controls.Add(Me.Label4)
        Me.GrpBoxMain.Controls.Add(Me.Label3)
        Me.GrpBoxMain.Controls.Add(Me.Label2)
        Me.GrpBoxMain.Controls.Add(Me.Label1)
        Me.GrpBoxMain.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpBoxMain.Location = New System.Drawing.Point(6, 47)
        Me.GrpBoxMain.Name = "GrpBoxMain"
        Me.GrpBoxMain.Size = New System.Drawing.Size(739, 434)
        Me.GrpBoxMain.TabIndex = 193
        Me.GrpBoxMain.TabStop = False
        '
        'DataGrid
        '
        Me.DataGrid.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar
        Me.DataGrid.AllowUserToResizeColumns = False
        Me.DataGrid.AllowUserToResizeRows = False
        Me.DataGrid.ColumnHeadersHeight = 20
        Me.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGrid.Enabled = False
        Me.DataGrid.Location = New System.Drawing.Point(12, 227)
        Me.DataGrid.Name = "DataGrid"
        Me.DataGrid.RowHeadersWidth = 20
        Me.DataGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DataGrid.RowTemplate.Height = 20
        Me.DataGrid.Size = New System.Drawing.Size(714, 195)
        Me.DataGrid.TabIndex = 228
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DataGridRights)
        Me.GroupBox2.Location = New System.Drawing.Point(323, 20)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(403, 193)
        Me.GroupBox2.TabIndex = 225
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Access Rights"
        '
        'DataGridRights
        '
        Me.DataGridRights.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar
        Me.DataGridRights.AllowUserToResizeColumns = False
        Me.DataGridRights.AllowUserToResizeRows = False
        Me.DataGridRights.ColumnHeadersHeight = 20
        Me.DataGridRights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridRights.Enabled = False
        Me.DataGridRights.Location = New System.Drawing.Point(18, 23)
        Me.DataGridRights.Name = "DataGridRights"
        Me.DataGridRights.RowHeadersWidth = 20
        Me.DataGridRights.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DataGridRights.RowTemplate.Height = 20
        Me.DataGridRights.Size = New System.Drawing.Size(371, 156)
        Me.DataGridRights.TabIndex = 227
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(234, 164)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(89, 15)
        Me.Label9.TabIndex = 224
        Me.Label9.Text = "(MM/DD/YYYY)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(234, 139)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 15)
        Me.Label8.TabIndex = 223
        Me.Label8.Text = "(MM/DD/YYYY)"
        '
        'txtAccExp
        '
        Me.txtAccExp.Enabled = False
        Me.txtAccExp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccExp.Location = New System.Drawing.Point(140, 164)
        Me.txtAccExp.Mask = "##/##/####"
        Me.txtAccExp.Name = "txtAccExp"
        Me.txtAccExp.Size = New System.Drawing.Size(94, 21)
        Me.txtAccExp.TabIndex = 222
        '
        'txtExpDat
        '
        Me.txtExpDat.Enabled = False
        Me.txtExpDat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExpDat.Location = New System.Drawing.Point(140, 136)
        Me.txtExpDat.Mask = "##/##/####"
        Me.txtExpDat.Name = "txtExpDat"
        Me.txtExpDat.Size = New System.Drawing.Size(94, 21)
        Me.txtExpDat.TabIndex = 221
        '
        'txtMailAd
        '
        Me.txtMailAd.Enabled = False
        Me.txtMailAd.Location = New System.Drawing.Point(139, 192)
        Me.txtMailAd.MaxLength = 50
        Me.txtMailAd.Name = "txtMailAd"
        Me.txtMailAd.Size = New System.Drawing.Size(178, 21)
        Me.txtMailAd.TabIndex = 18
        '
        'txtConPwd
        '
        Me.txtConPwd.Location = New System.Drawing.Point(139, 108)
        Me.txtConPwd.MaxLength = 10
        Me.txtConPwd.Name = "txtConPwd"
        Me.txtConPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConPwd.Size = New System.Drawing.Size(156, 21)
        Me.txtConPwd.TabIndex = 17
        '
        'txtUsrPwd
        '
        Me.txtUsrPwd.Location = New System.Drawing.Point(139, 80)
        Me.txtUsrPwd.MaxLength = 10
        Me.txtUsrPwd.Name = "txtUsrPwd"
        Me.txtUsrPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtUsrPwd.Size = New System.Drawing.Size(156, 21)
        Me.txtUsrPwd.TabIndex = 16
        '
        'txtUsrNam
        '
        Me.txtUsrNam.Enabled = False
        Me.txtUsrNam.Location = New System.Drawing.Point(139, 52)
        Me.txtUsrNam.MaxLength = 100
        Me.txtUsrNam.Name = "txtUsrNam"
        Me.txtUsrNam.Size = New System.Drawing.Size(156, 21)
        Me.txtUsrNam.TabIndex = 15
        '
        'txtUsrID
        '
        Me.txtUsrID.Location = New System.Drawing.Point(139, 24)
        Me.txtUsrID.MaxLength = 12
        Me.txtUsrID.Name = "txtUsrID"
        Me.txtUsrID.Size = New System.Drawing.Size(156, 21)
        Me.txtUsrID.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(9, 193)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 15)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Email Address :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(9, 165)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(121, 15)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Account Expiry Date :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(9, 137)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(132, 15)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Passowrd Expiry Date :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(9, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 15)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Confirm Password :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(9, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 15)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Password :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(9, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 15)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Name :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(9, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 15)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "User ID :"
        '
        'StatusBar
        '
        Me.StatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblLeft, Me.lblRight})
        Me.StatusBar.Location = New System.Drawing.Point(0, 484)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Size = New System.Drawing.Size(752, 22)
        Me.StatusBar.TabIndex = 194
        Me.StatusBar.Text = "StatusStrip1"
        '
        'lblLeft
        '
        Me.lblLeft.AutoSize = False
        Me.lblLeft.Name = "lblLeft"
        Me.lblLeft.Size = New System.Drawing.Size(550, 17)
        Me.lblLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRight
        '
        Me.lblRight.AutoSize = False
        Me.lblRight.Name = "lblRight"
        Me.lblRight.Size = New System.Drawing.Size(187, 17)
        Me.lblRight.Spring = True
        Me.lblRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SYS00002
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(752, 506)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.GrpBoxMain)
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
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "SYS00002"
        Me.Text = "User Profile (SYS00002)"
        Me.GrpBoxMain.ResumeLayout(False)
        Me.GrpBoxMain.PerformLayout()
        CType(Me.DataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DataGridRights, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusBar.ResumeLayout(False)
        Me.StatusBar.PerformLayout()
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
    Friend WithEvents GrpBoxMain As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtConPwd As System.Windows.Forms.TextBox
    Friend WithEvents txtUsrPwd As System.Windows.Forms.TextBox
    Friend WithEvents txtUsrNam As System.Windows.Forms.TextBox
    Friend WithEvents txtUsrID As System.Windows.Forms.TextBox
    Friend WithEvents txtMailAd As System.Windows.Forms.TextBox
    Friend WithEvents txtAccExp As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtExpDat As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridRights As System.Windows.Forms.DataGridView
    Friend WithEvents DataGrid As System.Windows.Forms.DataGridView
    Friend WithEvents StatusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents lblLeft As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblRight As System.Windows.Forms.ToolStripStatusLabel
End Class
