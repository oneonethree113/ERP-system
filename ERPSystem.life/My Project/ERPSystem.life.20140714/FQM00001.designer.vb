<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FQM00001
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
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
        Me.lblFtyNo = New System.Windows.Forms.Label
        Me.txtFtyNo = New System.Windows.Forms.TextBox
        Me.txtFtyName = New System.Windows.Forms.TextBox
        Me.lblFtyName = New System.Windows.Forms.Label
        Me.lblFtySts = New System.Windows.Forms.Label
        Me.txtCont = New System.Windows.Forms.TextBox
        Me.txtTelNo = New System.Windows.Forms.TextBox
        Me.txtFtyAddr = New System.Windows.Forms.TextBox
        Me.lblFtyAddr = New System.Windows.Forms.Label
        Me.lblTelNo = New System.Windows.Forms.Label
        Me.lblCont = New System.Windows.Forms.Label
        Me.dgFactory = New System.Windows.Forms.DataGridView
        Me.StatusBar1 = New System.Windows.Forms.StatusBar
        Me.txtVdrName = New System.Windows.Forms.TextBox
        Me.txtFtySts = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.tcFQM00001 = New ERPSystem.BaseTabControl
        Me.tcFQC00001_1 = New System.Windows.Forms.TabPage
        Me.dgRecent = New System.Windows.Forms.DataGridView
        Me.tcFQC00001_2 = New System.Windows.Forms.TabPage
        Me.dgPrevious = New System.Windows.Forms.DataGridView
        Me.tcFQC00001_3 = New System.Windows.Forms.TabPage
        Me.dgOrder = New System.Windows.Forms.DataGridView
        CType(Me.dgFactory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.tcFQM00001.SuspendLayout()
        Me.tcFQC00001_1.SuspendLayout()
        CType(Me.dgRecent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tcFQC00001_2.SuspendLayout()
        CType(Me.dgPrevious, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tcFQC00001_3.SuspendLayout()
        CType(Me.dgOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdDelete
        '
        Me.cmdDelete.Enabled = False
        Me.cmdDelete.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelete.Location = New System.Drawing.Point(112, 0)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(56, 40)
        Me.cmdDelete.TabIndex = 16
        Me.cmdDelete.TabStop = False
        Me.cmdDelete.Text = "&Delete"
        '
        'cmdSave
        '
        Me.cmdSave.Enabled = False
        Me.cmdSave.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.Location = New System.Drawing.Point(56, 0)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(56, 40)
        Me.cmdSave.TabIndex = 15
        Me.cmdSave.TabStop = False
        Me.cmdSave.Text = "&Save"
        '
        'cmdAdd
        '
        Me.cmdAdd.Enabled = False
        Me.cmdAdd.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdd.Location = New System.Drawing.Point(0, 0)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(56, 40)
        Me.cmdAdd.TabIndex = 14
        Me.cmdAdd.TabStop = False
        Me.cmdAdd.Text = "&Add"
        '
        'cmdLast
        '
        Me.cmdLast.Enabled = False
        Me.cmdLast.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLast.Location = New System.Drawing.Point(650, 0)
        Me.cmdLast.Name = "cmdLast"
        Me.cmdLast.Size = New System.Drawing.Size(40, 40)
        Me.cmdLast.TabIndex = 26
        Me.cmdLast.TabStop = False
        Me.cmdLast.Text = ">>|"
        '
        'cmdPrevious
        '
        Me.cmdPrevious.Enabled = False
        Me.cmdPrevious.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrevious.Location = New System.Drawing.Point(570, 0)
        Me.cmdPrevious.Name = "cmdPrevious"
        Me.cmdPrevious.Size = New System.Drawing.Size(40, 40)
        Me.cmdPrevious.TabIndex = 24
        Me.cmdPrevious.TabStop = False
        Me.cmdPrevious.Text = "<"
        '
        'cmdNext
        '
        Me.cmdNext.Enabled = False
        Me.cmdNext.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNext.Location = New System.Drawing.Point(610, 0)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(40, 40)
        Me.cmdNext.TabIndex = 25
        Me.cmdNext.TabStop = False
        Me.cmdNext.Text = ">"
        '
        'cmdFind
        '
        Me.cmdFind.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFind.Location = New System.Drawing.Point(224, 0)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(56, 40)
        Me.cmdFind.TabIndex = 1
        Me.cmdFind.TabStop = False
        Me.cmdFind.Text = "&Find"
        '
        'cmdCopy
        '
        Me.cmdCopy.Enabled = False
        Me.cmdCopy.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCopy.Location = New System.Drawing.Point(168, 0)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(56, 40)
        Me.cmdCopy.TabIndex = 17
        Me.cmdCopy.TabStop = False
        Me.cmdCopy.Text = "&Copy"
        '
        'cmdClear
        '
        Me.cmdClear.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(280, 0)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(56, 40)
        Me.cmdClear.TabIndex = 2
        Me.cmdClear.TabStop = False
        Me.cmdClear.Text = "Cl&ear"
        '
        'cmdExit
        '
        Me.cmdExit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(696, 0)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(56, 40)
        Me.cmdExit.TabIndex = 3
        Me.cmdExit.TabStop = False
        Me.cmdExit.Text = "E&xit"
        '
        'cmdDelRow
        '
        Me.cmdDelRow.Enabled = False
        Me.cmdDelRow.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelRow.Location = New System.Drawing.Point(468, 0)
        Me.cmdDelRow.Name = "cmdDelRow"
        Me.cmdDelRow.Size = New System.Drawing.Size(56, 40)
        Me.cmdDelRow.TabIndex = 22
        Me.cmdDelRow.TabStop = False
        Me.cmdDelRow.Text = "Del Ro&w"
        '
        'cmdFirst
        '
        Me.cmdFirst.Enabled = False
        Me.cmdFirst.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFirst.Location = New System.Drawing.Point(530, 0)
        Me.cmdFirst.Name = "cmdFirst"
        Me.cmdFirst.Size = New System.Drawing.Size(40, 40)
        Me.cmdFirst.TabIndex = 23
        Me.cmdFirst.TabStop = False
        Me.cmdFirst.Text = "|<<"
        '
        'cmdInsRow
        '
        Me.cmdInsRow.Enabled = False
        Me.cmdInsRow.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdInsRow.Location = New System.Drawing.Point(412, 0)
        Me.cmdInsRow.Name = "cmdInsRow"
        Me.cmdInsRow.Size = New System.Drawing.Size(56, 40)
        Me.cmdInsRow.TabIndex = 21
        Me.cmdInsRow.TabStop = False
        Me.cmdInsRow.Text = "I&ns Row"
        '
        'cmdSearch
        '
        Me.cmdSearch.Enabled = False
        Me.cmdSearch.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(342, 0)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(64, 40)
        Me.cmdSearch.TabIndex = 20
        Me.cmdSearch.TabStop = False
        Me.cmdSearch.Text = "Searc&h"
        '
        'lblFtyNo
        '
        Me.lblFtyNo.AutoSize = True
        Me.lblFtyNo.Location = New System.Drawing.Point(9, 49)
        Me.lblFtyNo.Name = "lblFtyNo"
        Me.lblFtyNo.Size = New System.Drawing.Size(43, 15)
        Me.lblFtyNo.TabIndex = 68
        Me.lblFtyNo.Text = "Fty No"
        '
        'txtFtyNo
        '
        Me.txtFtyNo.Location = New System.Drawing.Point(73, 47)
        Me.txtFtyNo.Name = "txtFtyNo"
        Me.txtFtyNo.Size = New System.Drawing.Size(109, 21)
        Me.txtFtyNo.TabIndex = 1
        Me.txtFtyNo.Text = "1616"
        '
        'txtFtyName
        '
        Me.txtFtyName.Location = New System.Drawing.Point(73, 100)
        Me.txtFtyName.Name = "txtFtyName"
        Me.txtFtyName.ReadOnly = True
        Me.txtFtyName.Size = New System.Drawing.Size(263, 21)
        Me.txtFtyName.TabIndex = 71
        Me.txtFtyName.TabStop = False
        '
        'lblFtyName
        '
        Me.lblFtyName.AutoSize = True
        Me.lblFtyName.Location = New System.Drawing.Point(9, 103)
        Me.lblFtyName.Name = "lblFtyName"
        Me.lblFtyName.Size = New System.Drawing.Size(45, 15)
        Me.lblFtyName.TabIndex = 72
        Me.lblFtyName.Text = "Factory"
        '
        'lblFtySts
        '
        Me.lblFtySts.AutoSize = True
        Me.lblFtySts.Location = New System.Drawing.Point(9, 76)
        Me.lblFtySts.Name = "lblFtySts"
        Me.lblFtySts.Size = New System.Drawing.Size(58, 15)
        Me.lblFtySts.TabIndex = 73
        Me.lblFtySts.Text = "Fty Status"
        '
        'txtCont
        '
        Me.txtCont.Location = New System.Drawing.Point(395, 73)
        Me.txtCont.Name = "txtCont"
        Me.txtCont.ReadOnly = True
        Me.txtCont.Size = New System.Drawing.Size(172, 21)
        Me.txtCont.TabIndex = 74
        Me.txtCont.TabStop = False
        '
        'txtTelNo
        '
        Me.txtTelNo.Location = New System.Drawing.Point(620, 73)
        Me.txtTelNo.Name = "txtTelNo"
        Me.txtTelNo.ReadOnly = True
        Me.txtTelNo.Size = New System.Drawing.Size(120, 21)
        Me.txtTelNo.TabIndex = 75
        Me.txtTelNo.TabStop = False
        '
        'txtFtyAddr
        '
        Me.txtFtyAddr.Location = New System.Drawing.Point(395, 100)
        Me.txtFtyAddr.Name = "txtFtyAddr"
        Me.txtFtyAddr.ReadOnly = True
        Me.txtFtyAddr.Size = New System.Drawing.Size(345, 21)
        Me.txtFtyAddr.TabIndex = 76
        Me.txtFtyAddr.TabStop = False
        Me.txtFtyAddr.Text = "深圳市龍崗鎮龍東蘭水坡蘭三路"
        '
        'lblFtyAddr
        '
        Me.lblFtyAddr.AutoSize = True
        Me.lblFtyAddr.Location = New System.Drawing.Point(342, 103)
        Me.lblFtyAddr.Name = "lblFtyAddr"
        Me.lblFtyAddr.Size = New System.Drawing.Size(47, 15)
        Me.lblFtyAddr.TabIndex = 77
        Me.lblFtyAddr.Text = "Address"
        '
        'lblTelNo
        '
        Me.lblTelNo.AutoSize = True
        Me.lblTelNo.Location = New System.Drawing.Point(573, 76)
        Me.lblTelNo.Name = "lblTelNo"
        Me.lblTelNo.Size = New System.Drawing.Size(41, 15)
        Me.lblTelNo.TabIndex = 78
        Me.lblTelNo.Text = "Tel No"
        '
        'lblCont
        '
        Me.lblCont.AutoSize = True
        Me.lblCont.Location = New System.Drawing.Point(342, 76)
        Me.lblCont.Name = "lblCont"
        Me.lblCont.Size = New System.Drawing.Size(45, 15)
        Me.lblCont.TabIndex = 79
        Me.lblCont.Text = "Contact"
        '
        'dgFactory
        '
        Me.dgFactory.AllowUserToAddRows = False
        Me.dgFactory.AllowUserToDeleteRows = False
        Me.dgFactory.AllowUserToResizeColumns = False
        Me.dgFactory.AllowUserToResizeRows = False
        Me.dgFactory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgFactory.Location = New System.Drawing.Point(10, 20)
        Me.dgFactory.MultiSelect = False
        Me.dgFactory.Name = "dgFactory"
        Me.dgFactory.ReadOnly = True
        Me.dgFactory.RowHeadersVisible = False
        Me.dgFactory.RowHeadersWidth = 30
        Me.dgFactory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgFactory.Size = New System.Drawing.Size(712, 107)
        Me.dgFactory.TabIndex = 5
        Me.dgFactory.TabStop = False
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 480)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(752, 16)
        Me.StatusBar1.TabIndex = 82
        '
        'txtVdrName
        '
        Me.txtVdrName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtVdrName.Location = New System.Drawing.Point(188, 50)
        Me.txtVdrName.Name = "txtVdrName"
        Me.txtVdrName.ReadOnly = True
        Me.txtVdrName.Size = New System.Drawing.Size(552, 14)
        Me.txtVdrName.TabIndex = 4
        Me.txtVdrName.TabStop = False
        Me.txtVdrName.Text = "DUNHUANG (敦煌)"
        '
        'txtFtySts
        '
        Me.txtFtySts.Location = New System.Drawing.Point(73, 73)
        Me.txtFtySts.Name = "txtFtySts"
        Me.txtFtySts.ReadOnly = True
        Me.txtFtySts.Size = New System.Drawing.Size(109, 21)
        Me.txtFtySts.TabIndex = 70
        Me.txtFtySts.TabStop = False
        Me.txtFtySts.Text = "A Active"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgFactory)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 122)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(732, 133)
        Me.GroupBox1.TabIndex = 84
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Overview"
        '
        'tcFQM00001
        '
        Me.tcFQM00001.Controls.Add(Me.tcFQC00001_1)
        Me.tcFQM00001.Controls.Add(Me.tcFQC00001_2)
        Me.tcFQM00001.Controls.Add(Me.tcFQC00001_3)
        Me.tcFQM00001.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.tcFQM00001.Location = New System.Drawing.Point(8, 261)
        Me.tcFQM00001.Name = "tcFQM00001"
        Me.tcFQM00001.SelectedIndex = 0
        Me.tcFQM00001.Size = New System.Drawing.Size(732, 213)
        Me.tcFQM00001.TabIndex = 6
        Me.tcFQM00001.TabStop = False
        '
        'tcFQC00001_1
        '
        Me.tcFQC00001_1.Controls.Add(Me.dgRecent)
        Me.tcFQC00001_1.Location = New System.Drawing.Point(4, 24)
        Me.tcFQC00001_1.Name = "tcFQC00001_1"
        Me.tcFQC00001_1.Padding = New System.Windows.Forms.Padding(3)
        Me.tcFQC00001_1.Size = New System.Drawing.Size(724, 185)
        Me.tcFQC00001_1.TabIndex = 0
        Me.tcFQC00001_1.Text = "(1) Recent Audit Records"
        Me.tcFQC00001_1.UseVisualStyleBackColor = True
        '
        'dgRecent
        '
        Me.dgRecent.AllowUserToAddRows = False
        Me.dgRecent.AllowUserToDeleteRows = False
        Me.dgRecent.AllowUserToResizeColumns = False
        Me.dgRecent.AllowUserToResizeRows = False
        Me.dgRecent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgRecent.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgRecent.Location = New System.Drawing.Point(6, 6)
        Me.dgRecent.MultiSelect = False
        Me.dgRecent.Name = "dgRecent"
        Me.dgRecent.ReadOnly = True
        Me.dgRecent.RowHeadersVisible = False
        Me.dgRecent.RowHeadersWidth = 30
        Me.dgRecent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgRecent.Size = New System.Drawing.Size(712, 173)
        Me.dgRecent.TabIndex = 81
        Me.dgRecent.TabStop = False
        '
        'tcFQC00001_2
        '
        Me.tcFQC00001_2.Controls.Add(Me.dgPrevious)
        Me.tcFQC00001_2.Location = New System.Drawing.Point(4, 22)
        Me.tcFQC00001_2.Name = "tcFQC00001_2"
        Me.tcFQC00001_2.Padding = New System.Windows.Forms.Padding(3)
        Me.tcFQC00001_2.Size = New System.Drawing.Size(724, 187)
        Me.tcFQC00001_2.TabIndex = 1
        Me.tcFQC00001_2.Text = "(2) Previous Audit Records"
        Me.tcFQC00001_2.UseVisualStyleBackColor = True
        '
        'dgPrevious
        '
        Me.dgPrevious.AllowUserToAddRows = False
        Me.dgPrevious.AllowUserToDeleteRows = False
        Me.dgPrevious.AllowUserToResizeColumns = False
        Me.dgPrevious.AllowUserToResizeRows = False
        Me.dgPrevious.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgPrevious.Location = New System.Drawing.Point(6, 6)
        Me.dgPrevious.MultiSelect = False
        Me.dgPrevious.Name = "dgPrevious"
        Me.dgPrevious.ReadOnly = True
        Me.dgPrevious.RowHeadersVisible = False
        Me.dgPrevious.RowHeadersWidth = 30
        Me.dgPrevious.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgPrevious.Size = New System.Drawing.Size(712, 173)
        Me.dgPrevious.TabIndex = 82
        Me.dgPrevious.TabStop = False
        '
        'tcFQC00001_3
        '
        Me.tcFQC00001_3.Controls.Add(Me.dgOrder)
        Me.tcFQC00001_3.Location = New System.Drawing.Point(4, 22)
        Me.tcFQC00001_3.Name = "tcFQC00001_3"
        Me.tcFQC00001_3.Padding = New System.Windows.Forms.Padding(3)
        Me.tcFQC00001_3.Size = New System.Drawing.Size(724, 187)
        Me.tcFQC00001_3.TabIndex = 2
        Me.tcFQC00001_3.Text = "(3) Factory Order Records"
        Me.tcFQC00001_3.UseVisualStyleBackColor = True
        '
        'dgOrder
        '
        Me.dgOrder.AllowUserToAddRows = False
        Me.dgOrder.AllowUserToDeleteRows = False
        Me.dgOrder.AllowUserToResizeColumns = False
        Me.dgOrder.AllowUserToResizeRows = False
        Me.dgOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgOrder.Location = New System.Drawing.Point(6, 6)
        Me.dgOrder.MultiSelect = False
        Me.dgOrder.Name = "dgOrder"
        Me.dgOrder.ReadOnly = True
        Me.dgOrder.RowHeadersVisible = False
        Me.dgOrder.RowHeadersWidth = 30
        Me.dgOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgOrder.Size = New System.Drawing.Size(712, 173)
        Me.dgOrder.TabIndex = 83
        Me.dgOrder.TabStop = False
        '
        'FQM00001
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(752, 496)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtVdrName)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.tcFQM00001)
        Me.Controls.Add(Me.lblCont)
        Me.Controls.Add(Me.lblTelNo)
        Me.Controls.Add(Me.lblFtyAddr)
        Me.Controls.Add(Me.txtFtyAddr)
        Me.Controls.Add(Me.txtTelNo)
        Me.Controls.Add(Me.txtCont)
        Me.Controls.Add(Me.lblFtySts)
        Me.Controls.Add(Me.lblFtyName)
        Me.Controls.Add(Me.txtFtyName)
        Me.Controls.Add(Me.txtFtySts)
        Me.Controls.Add(Me.txtFtyNo)
        Me.Controls.Add(Me.lblFtyNo)
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
        Me.Font = New System.Drawing.Font("Times New Roman", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "FQM00001"
        Me.Text = "FQM00001 - Factory Audit Enquiry"
        CType(Me.dgFactory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.tcFQM00001.ResumeLayout(False)
        Me.tcFQC00001_1.ResumeLayout(False)
        CType(Me.dgRecent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tcFQC00001_2.ResumeLayout(False)
        CType(Me.dgPrevious, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tcFQC00001_3.ResumeLayout(False)
        CType(Me.dgOrder, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents lblFtyNo As System.Windows.Forms.Label
    Friend WithEvents txtFtyNo As System.Windows.Forms.TextBox
    Friend WithEvents txtFtyName As System.Windows.Forms.TextBox
    Friend WithEvents lblFtyName As System.Windows.Forms.Label
    Friend WithEvents lblFtySts As System.Windows.Forms.Label
    Friend WithEvents txtCont As System.Windows.Forms.TextBox
    Friend WithEvents txtTelNo As System.Windows.Forms.TextBox
    Friend WithEvents txtFtyAddr As System.Windows.Forms.TextBox
    Friend WithEvents lblFtyAddr As System.Windows.Forms.Label
    Friend WithEvents lblTelNo As System.Windows.Forms.Label
    Friend WithEvents lblCont As System.Windows.Forms.Label
    Friend WithEvents dgFactory As System.Windows.Forms.DataGridView
    Friend WithEvents tcFQM00001 As ERPSystem.BaseTabControl
    Friend WithEvents tcFQC00001_1 As System.Windows.Forms.TabPage
    Friend WithEvents tcFQC00001_2 As System.Windows.Forms.TabPage
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents dgRecent As System.Windows.Forms.DataGridView
    Friend WithEvents dgPrevious As System.Windows.Forms.DataGridView
    Friend WithEvents tcFQC00001_3 As System.Windows.Forms.TabPage
    Friend WithEvents dgOrder As System.Windows.Forms.DataGridView
    Friend WithEvents txtVdrName As System.Windows.Forms.TextBox
    Friend WithEvents txtFtySts As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
