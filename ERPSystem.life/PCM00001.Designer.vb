<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PCM00001
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
        Me.cmdFind = New System.Windows.Forms.Button
        Me.cmdCopy = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdDelRow = New System.Windows.Forms.Button
        Me.cmdInsRow = New System.Windows.Forms.Button
        Me.SSTabPC = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.grdAssDgnVen = New System.Windows.Forms.DataGridView
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.grdAgyChrg = New System.Windows.Forms.DataGridView
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.grdDevChrg = New System.Windows.Forms.DataGridView
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.txtSamTerActNo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtInvAdjActNo = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtSamInvActNo = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtInvActNo = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.cboPCNo = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdSearch = New System.Windows.Forms.Button
        Me.cmdlast = New System.Windows.Forms.Button
        Me.cmdPrv = New System.Windows.Forms.Button
        Me.cmdNext = New System.Windows.Forms.Button
        Me.cmdfirst = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.grdPstDat = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.SSTabPC.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.grdAssDgnVen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.grdAgyChrg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.grdDevChrg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.grdPstDat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdDelete
        '
        Me.cmdDelete.Enabled = False
        Me.cmdDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelete.Location = New System.Drawing.Point(98, 3)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(49, 25)
        Me.cmdDelete.TabIndex = 62
        Me.cmdDelete.Text = "&Delete"
        '
        'cmdSave
        '
        Me.cmdSave.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.Location = New System.Drawing.Point(49, 3)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(50, 25)
        Me.cmdSave.TabIndex = 61
        Me.cmdSave.Text = "&Save"
        '
        'cmdAdd
        '
        Me.cmdAdd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdd.Location = New System.Drawing.Point(0, 3)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(50, 25)
        Me.cmdAdd.TabIndex = 60
        Me.cmdAdd.Text = "&Add"
        '
        'cmdFind
        '
        Me.cmdFind.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFind.Location = New System.Drawing.Point(195, 3)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(49, 25)
        Me.cmdFind.TabIndex = 64
        Me.cmdFind.Text = "&Find"
        '
        'cmdCopy
        '
        Me.cmdCopy.Enabled = False
        Me.cmdCopy.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCopy.Location = New System.Drawing.Point(147, 3)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(49, 25)
        Me.cmdCopy.TabIndex = 63
        Me.cmdCopy.Text = "&Copy"
        '
        'cmdClear
        '
        Me.cmdClear.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(243, 3)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(49, 25)
        Me.cmdClear.TabIndex = 65
        Me.cmdClear.Text = "Cl&ear"
        '
        'cmdExit
        '
        Me.cmdExit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(701, 3)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(46, 25)
        Me.cmdExit.TabIndex = 74
        Me.cmdExit.Text = "E&xit"
        '
        'cmdDelRow
        '
        Me.cmdDelRow.Enabled = False
        Me.cmdDelRow.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelRow.Location = New System.Drawing.Point(474, 3)
        Me.cmdDelRow.Name = "cmdDelRow"
        Me.cmdDelRow.Size = New System.Drawing.Size(56, 25)
        Me.cmdDelRow.TabIndex = 69
        Me.cmdDelRow.Text = "Del Ro&w"
        '
        'cmdInsRow
        '
        Me.cmdInsRow.Enabled = False
        Me.cmdInsRow.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdInsRow.Location = New System.Drawing.Point(406, 3)
        Me.cmdInsRow.Name = "cmdInsRow"
        Me.cmdInsRow.Size = New System.Drawing.Size(62, 25)
        Me.cmdInsRow.TabIndex = 68
        Me.cmdInsRow.Text = "I&ns Row"
        '
        'SSTabPC
        '
        Me.SSTabPC.Controls.Add(Me.TabPage1)
        Me.SSTabPC.Controls.Add(Me.TabPage2)
        Me.SSTabPC.Controls.Add(Me.TabPage3)
        Me.SSTabPC.Controls.Add(Me.TabPage4)
        Me.SSTabPC.Location = New System.Drawing.Point(-2, 41)
        Me.SSTabPC.Name = "SSTabPC"
        Me.SSTabPC.SelectedIndex = 0
        Me.SSTabPC.Size = New System.Drawing.Size(739, 328)
        Me.SSTabPC.TabIndex = 75
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.grdAssDgnVen)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(731, 302)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "(1) Associated Custom Vendor"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'grdAssDgnVen
        '
        Me.grdAssDgnVen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdAssDgnVen.Location = New System.Drawing.Point(3, 3)
        Me.grdAssDgnVen.Name = "grdAssDgnVen"
        Me.grdAssDgnVen.Size = New System.Drawing.Size(722, 298)
        Me.grdAssDgnVen.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.grdAgyChrg)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(731, 302)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "(2) Agency Charge"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'grdAgyChrg
        '
        Me.grdAgyChrg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdAgyChrg.Location = New System.Drawing.Point(2, 2)
        Me.grdAgyChrg.Name = "grdAgyChrg"
        Me.grdAgyChrg.Size = New System.Drawing.Size(728, 298)
        Me.grdAgyChrg.TabIndex = 1
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.grdDevChrg)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(731, 302)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "(3) Development Charge"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'grdDevChrg
        '
        Me.grdDevChrg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDevChrg.Location = New System.Drawing.Point(0, 2)
        Me.grdDevChrg.Name = "grdDevChrg"
        Me.grdDevChrg.Size = New System.Drawing.Size(728, 298)
        Me.grdDevChrg.TabIndex = 2
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.LightGray
        Me.TabPage4.Controls.Add(Me.txtSamTerActNo)
        Me.TabPage4.Controls.Add(Me.Label1)
        Me.TabPage4.Controls.Add(Me.txtInvAdjActNo)
        Me.TabPage4.Controls.Add(Me.Label11)
        Me.TabPage4.Controls.Add(Me.txtSamInvActNo)
        Me.TabPage4.Controls.Add(Me.Label14)
        Me.TabPage4.Controls.Add(Me.txtInvActNo)
        Me.TabPage4.Controls.Add(Me.Label17)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(731, 302)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "(4) Account Interface"
        '
        'txtSamTerActNo
        '
        Me.txtSamTerActNo.BackColor = System.Drawing.SystemColors.Window
        Me.txtSamTerActNo.Location = New System.Drawing.Point(320, 124)
        Me.txtSamTerActNo.Name = "txtSamTerActNo"
        Me.txtSamTerActNo.Size = New System.Drawing.Size(161, 20)
        Me.txtSamTerActNo.TabIndex = 85
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(125, 127)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 13)
        Me.Label1.TabIndex = 84
        Me.Label1.Text = "Sample Term Account Number"
        '
        'txtInvAdjActNo
        '
        Me.txtInvAdjActNo.BackColor = System.Drawing.SystemColors.Window
        Me.txtInvAdjActNo.Location = New System.Drawing.Point(320, 100)
        Me.txtInvAdjActNo.Name = "txtInvAdjActNo"
        Me.txtInvAdjActNo.Size = New System.Drawing.Size(161, 20)
        Me.txtInvAdjActNo.TabIndex = 83
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(125, 51)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(125, 13)
        Me.Label11.TabIndex = 80
        Me.Label11.Text = "Invoice Account Number"
        '
        'txtSamInvActNo
        '
        Me.txtSamInvActNo.BackColor = System.Drawing.SystemColors.Window
        Me.txtSamInvActNo.Location = New System.Drawing.Point(320, 74)
        Me.txtSamInvActNo.Name = "txtSamInvActNo"
        Me.txtSamInvActNo.Size = New System.Drawing.Size(161, 20)
        Me.txtSamInvActNo.TabIndex = 82
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(125, 77)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(163, 13)
        Me.Label14.TabIndex = 79
        Me.Label14.Text = "Sample Invoice Account Number"
        '
        'txtInvActNo
        '
        Me.txtInvActNo.BackColor = System.Drawing.SystemColors.Window
        Me.txtInvActNo.Location = New System.Drawing.Point(320, 48)
        Me.txtInvActNo.Name = "txtInvActNo"
        Me.txtInvActNo.Size = New System.Drawing.Size(161, 20)
        Me.txtInvActNo.TabIndex = 81
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(125, 103)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(180, 13)
        Me.Label17.TabIndex = 78
        Me.Label17.Text = "Invoice Adjustment Account Number"
        '
        'cboPCNo
        '
        Me.cboPCNo.FormattingEnabled = True
        Me.cboPCNo.Location = New System.Drawing.Point(77, 13)
        Me.cboPCNo.Name = "cboPCNo"
        Me.cboPCNo.Size = New System.Drawing.Size(161, 21)
        Me.cboPCNo.TabIndex = 76
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 13)
        Me.Label8.TabIndex = 77
        Me.Label8.Text = "Profit Center"
        '
        'cmdCancel
        '
        Me.cmdCancel.Enabled = False
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(298, 3)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(50, 25)
        Me.cmdCancel.TabIndex = 277
        Me.cmdCancel.Text = "Cancel"
        '
        'cmdSearch
        '
        Me.cmdSearch.Enabled = False
        Me.cmdSearch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(349, 3)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(51, 25)
        Me.cmdSearch.TabIndex = 278
        Me.cmdSearch.Text = "Searc&h"
        '
        'cmdlast
        '
        Me.cmdlast.Enabled = False
        Me.cmdlast.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdlast.Location = New System.Drawing.Point(656, 3)
        Me.cmdlast.Name = "cmdlast"
        Me.cmdlast.Size = New System.Drawing.Size(40, 25)
        Me.cmdlast.TabIndex = 286
        Me.cmdlast.Text = ">>|"
        '
        'cmdPrv
        '
        Me.cmdPrv.Enabled = False
        Me.cmdPrv.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrv.Location = New System.Drawing.Point(576, 3)
        Me.cmdPrv.Name = "cmdPrv"
        Me.cmdPrv.Size = New System.Drawing.Size(40, 25)
        Me.cmdPrv.TabIndex = 284
        Me.cmdPrv.Text = "<"
        '
        'cmdNext
        '
        Me.cmdNext.Enabled = False
        Me.cmdNext.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNext.Location = New System.Drawing.Point(616, 3)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(40, 25)
        Me.cmdNext.TabIndex = 285
        Me.cmdNext.Text = ">"
        '
        'cmdfirst
        '
        Me.cmdfirst.Enabled = False
        Me.cmdfirst.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdfirst.Location = New System.Drawing.Point(536, 3)
        Me.cmdfirst.Name = "cmdfirst"
        Me.cmdfirst.Size = New System.Drawing.Size(40, 25)
        Me.cmdfirst.TabIndex = 283
        Me.cmdfirst.Text = "|<<"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(90, 9)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(152, 25)
        Me.Button1.TabIndex = 287
        Me.Button1.Text = "Assign New Posting Date"
        '
        'grdPstDat
        '
        Me.grdPstDat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPstDat.Location = New System.Drawing.Point(7, 35)
        Me.grdPstDat.Name = "grdPstDat"
        Me.grdPstDat.Size = New System.Drawing.Size(484, 141)
        Me.grdPstDat.TabIndex = 288
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 289
        Me.Label2.Text = "Posting Date"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.SSTabPC)
        Me.GroupBox1.Controls.Add(Me.cboPCNo)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 248)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(739, 380)
        Me.GroupBox1.TabIndex = 290
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.grdPstDat)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 60)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(497, 185)
        Me.GroupBox2.TabIndex = 291
        Me.GroupBox2.TabStop = False
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(6, 12)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(86, 17)
        Me.RadioButton1.TabIndex = 292
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Posting Date"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(118, 12)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(94, 17)
        Me.RadioButton2.TabIndex = 293
        Me.RadioButton2.Text = "Posting Center"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RadioButton1)
        Me.GroupBox3.Controls.Add(Me.RadioButton2)
        Me.GroupBox3.Location = New System.Drawing.Point(5, 30)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(236, 32)
        Me.GroupBox3.TabIndex = 294
        Me.GroupBox3.TabStop = False
        '
        'PCM00001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(746, 629)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdlast)
        Me.Controls.Add(Me.cmdPrv)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.cmdfirst)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.cmdFind)
        Me.Controls.Add(Me.cmdCopy)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdDelRow)
        Me.Controls.Add(Me.cmdInsRow)
        Me.Name = "PCM00001"
        Me.Text = "PCM00001 - Account Setup Master"
        Me.SSTabPC.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.grdAssDgnVen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.grdAgyChrg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.grdDevChrg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        CType(Me.grdPstDat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents cmdFind As System.Windows.Forms.Button
    Friend WithEvents cmdCopy As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdDelRow As System.Windows.Forms.Button
    Friend WithEvents cmdInsRow As System.Windows.Forms.Button
    Friend WithEvents SSTabPC As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents grdAssDgnVen As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents cboPCNo As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents grdAgyChrg As System.Windows.Forms.DataGridView
    Friend WithEvents grdDevChrg As System.Windows.Forms.DataGridView
    Friend WithEvents txtInvAdjActNo As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtSamInvActNo As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtInvActNo As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtSamTerActNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents cmdlast As System.Windows.Forms.Button
    Friend WithEvents cmdPrv As System.Windows.Forms.Button
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents cmdfirst As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents grdPstDat As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
End Class
