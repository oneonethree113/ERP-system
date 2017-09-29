<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SAM00002
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SAM00002))
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.cmdlast = New System.Windows.Forms.Button
        Me.cmdPrv = New System.Windows.Forms.Button
        Me.cmdNext = New System.Windows.Forms.Button
        Me.cmdFind = New System.Windows.Forms.Button
        Me.cmdCopy = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdDelRow = New System.Windows.Forms.Button
        Me.cmdfirst = New System.Windows.Forms.Button
        Me.cmdInsRow = New System.Windows.Forms.Button
        Me.cmdSearch = New System.Windows.Forms.Button
        Me.StatusBar = New System.Windows.Forms.StatusStrip
        Me.lblLeft = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblRight = New System.Windows.Forms.ToolStripStatusLabel
        Me.Label15 = New System.Windows.Forms.Label
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtCusNo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtItmNo = New System.Windows.Forms.TextBox
        Me.cmdMapping = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtColCde = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtUpdDat = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmd_S_ItmNo = New System.Windows.Forms.Button
        Me.txtVenItmNo = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtVendor = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.rdbitmno = New System.Windows.Forms.RadioButton
        Me.rdbvenitm = New System.Windows.Forms.RadioButton
        Me.cmd_S_ItmNo2 = New System.Windows.Forms.Button
        Me.TabPageMain = New ERPSystem.BaseTabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.grdSum = New System.Windows.Forms.DataGridView
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.grdDtl = New System.Windows.Forms.DataGridView
        Me.StatusBar.SuspendLayout()
        Me.TabPageMain.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.grdSum, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.grdDtl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdDelete
        '
        Me.cmdDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelete.Location = New System.Drawing.Point(99, 4)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(49, 25)
        Me.cmdDelete.TabIndex = 47
        Me.cmdDelete.Text = "&Delete"
        '
        'cmdCancel
        '
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(305, 4)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(50, 25)
        Me.cmdCancel.TabIndex = 51
        Me.cmdCancel.Text = "Cancel"
        '
        'cmdSave
        '
        Me.cmdSave.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.Location = New System.Drawing.Point(50, 4)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(50, 25)
        Me.cmdSave.TabIndex = 46
        Me.cmdSave.Text = "&Save"
        '
        'cmdAdd
        '
        Me.cmdAdd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdd.Location = New System.Drawing.Point(1, 4)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(50, 25)
        Me.cmdAdd.TabIndex = 45
        Me.cmdAdd.Text = "&Add"
        '
        'cmdlast
        '
        Me.cmdlast.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdlast.Location = New System.Drawing.Point(656, 4)
        Me.cmdlast.Name = "cmdlast"
        Me.cmdlast.Size = New System.Drawing.Size(40, 25)
        Me.cmdlast.TabIndex = 58
        Me.cmdlast.Text = ">>|"
        '
        'cmdPrv
        '
        Me.cmdPrv.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrv.Location = New System.Drawing.Point(576, 4)
        Me.cmdPrv.Name = "cmdPrv"
        Me.cmdPrv.Size = New System.Drawing.Size(40, 25)
        Me.cmdPrv.TabIndex = 56
        Me.cmdPrv.Text = "<"
        '
        'cmdNext
        '
        Me.cmdNext.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNext.Location = New System.Drawing.Point(616, 4)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(40, 25)
        Me.cmdNext.TabIndex = 57
        Me.cmdNext.Text = ">"
        '
        'cmdFind
        '
        Me.cmdFind.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFind.Location = New System.Drawing.Point(196, 4)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(49, 25)
        Me.cmdFind.TabIndex = 49
        Me.cmdFind.Text = "&Find"
        '
        'cmdCopy
        '
        Me.cmdCopy.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCopy.Location = New System.Drawing.Point(148, 4)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(49, 25)
        Me.cmdCopy.TabIndex = 48
        Me.cmdCopy.Text = "&Copy"
        '
        'cmdClear
        '
        Me.cmdClear.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(244, 4)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(49, 25)
        Me.cmdClear.TabIndex = 50
        Me.cmdClear.Text = "Cl&ear"
        '
        'cmdExit
        '
        Me.cmdExit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(703, 4)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(46, 25)
        Me.cmdExit.TabIndex = 59
        Me.cmdExit.Text = "E&xit"
        '
        'cmdDelRow
        '
        Me.cmdDelRow.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelRow.Location = New System.Drawing.Point(474, 4)
        Me.cmdDelRow.Name = "cmdDelRow"
        Me.cmdDelRow.Size = New System.Drawing.Size(56, 25)
        Me.cmdDelRow.TabIndex = 54
        Me.cmdDelRow.Text = "Del Ro&w"
        '
        'cmdfirst
        '
        Me.cmdfirst.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdfirst.Location = New System.Drawing.Point(536, 4)
        Me.cmdfirst.Name = "cmdfirst"
        Me.cmdfirst.Size = New System.Drawing.Size(40, 25)
        Me.cmdfirst.TabIndex = 55
        Me.cmdfirst.Text = "|<<"
        '
        'cmdInsRow
        '
        Me.cmdInsRow.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdInsRow.Location = New System.Drawing.Point(413, 4)
        Me.cmdInsRow.Name = "cmdInsRow"
        Me.cmdInsRow.Size = New System.Drawing.Size(62, 25)
        Me.cmdInsRow.TabIndex = 53
        Me.cmdInsRow.Text = "I&ns Row"
        '
        'cmdSearch
        '
        Me.cmdSearch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(356, 4)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(51, 25)
        Me.cmdSearch.TabIndex = 52
        Me.cmdSearch.Text = "Searc&h"
        '
        'StatusBar
        '
        Me.StatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblLeft, Me.lblRight})
        Me.StatusBar.Location = New System.Drawing.Point(0, 544)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Size = New System.Drawing.Size(752, 22)
        Me.StatusBar.TabIndex = 250
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
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(22, 39)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(79, 13)
        Me.Label15.TabIndex = 277
        Me.Label15.Text = "Company Code"
        '
        'cboCoCde
        '
        Me.cboCoCde.BackColor = System.Drawing.Color.White
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(121, 36)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(121, 21)
        Me.cboCoCde.TabIndex = 1
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(267, 39)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(88, 13)
        Me.Label22.TabIndex = 279
        Me.Label22.Text = "Company Name :"
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.Color.White
        Me.txtCoNam.Location = New System.Drawing.Point(361, 37)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.Size = New System.Drawing.Size(384, 20)
        Me.txtCoNam.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 13)
        Me.Label5.TabIndex = 281
        Me.Label5.Text = "Primary Cust Code"
        '
        'txtCusNo
        '
        Me.txtCusNo.BackColor = System.Drawing.Color.White
        Me.txtCusNo.Location = New System.Drawing.Point(121, 59)
        Me.txtCusNo.Name = "txtCusNo"
        Me.txtCusNo.Size = New System.Drawing.Size(273, 20)
        Me.txtCusNo.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 283
        Me.Label1.Text = "Temp / Item No."
        '
        'txtItmNo
        '
        Me.txtItmNo.BackColor = System.Drawing.Color.White
        Me.txtItmNo.Location = New System.Drawing.Point(121, 82)
        Me.txtItmNo.Name = "txtItmNo"
        Me.txtItmNo.Size = New System.Drawing.Size(137, 20)
        Me.txtItmNo.TabIndex = 4
        '
        'cmdMapping
        '
        Me.cmdMapping.Image = CType(resources.GetObject("cmdMapping.Image"), System.Drawing.Image)
        Me.cmdMapping.Location = New System.Drawing.Point(264, 80)
        Me.cmdMapping.Name = "cmdMapping"
        Me.cmdMapping.Size = New System.Drawing.Size(25, 25)
        Me.cmdMapping.TabIndex = 5
        Me.cmdMapping.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 162)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 286
        Me.Label2.Text = "VD. Color Code"
        '
        'txtColCde
        '
        Me.txtColCde.BackColor = System.Drawing.Color.White
        Me.txtColCde.Location = New System.Drawing.Point(121, 159)
        Me.txtColCde.Name = "txtColCde"
        Me.txtColCde.Size = New System.Drawing.Size(191, 20)
        Me.txtColCde.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 186)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 288
        Me.Label3.Text = "Update Date"
        '
        'txtUpdDat
        '
        Me.txtUpdDat.BackColor = System.Drawing.Color.White
        Me.txtUpdDat.Location = New System.Drawing.Point(121, 183)
        Me.txtUpdDat.MaxLength = 10
        Me.txtUpdDat.Name = "txtUpdDat"
        Me.txtUpdDat.Size = New System.Drawing.Size(100, 20)
        Me.txtUpdDat.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(227, 186)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 290
        Me.Label4.Text = "(MM/DD/YYYY)"
        '
        'cmd_S_ItmNo
        '
        Me.cmd_S_ItmNo.Location = New System.Drawing.Point(295, 81)
        Me.cmd_S_ItmNo.Name = "cmd_S_ItmNo"
        Me.cmd_S_ItmNo.Size = New System.Drawing.Size(75, 23)
        Me.cmd_S_ItmNo.TabIndex = 291
        Me.cmd_S_ItmNo.Text = "＞＞"
        Me.cmd_S_ItmNo.UseVisualStyleBackColor = True
        '
        'txtVenItmNo
        '
        Me.txtVenItmNo.BackColor = System.Drawing.Color.White
        Me.txtVenItmNo.Location = New System.Drawing.Point(121, 108)
        Me.txtVenItmNo.Name = "txtVenItmNo"
        Me.txtVenItmNo.Size = New System.Drawing.Size(137, 20)
        Me.txtVenItmNo.TabIndex = 292
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(22, 111)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 13)
        Me.Label6.TabIndex = 293
        Me.Label6.Text = "Vendor Item No."
        '
        'txtVendor
        '
        Me.txtVendor.BackColor = System.Drawing.Color.White
        Me.txtVendor.Location = New System.Drawing.Point(121, 133)
        Me.txtVendor.Name = "txtVendor"
        Me.txtVendor.Size = New System.Drawing.Size(137, 20)
        Me.txtVendor.TabIndex = 294
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(22, 136)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 13)
        Me.Label7.TabIndex = 295
        Me.Label7.Text = "Vendor"
        '
        'rdbitmno
        '
        Me.rdbitmno.AutoSize = True
        Me.rdbitmno.Checked = True
        Me.rdbitmno.Location = New System.Drawing.Point(6, 85)
        Me.rdbitmno.Name = "rdbitmno"
        Me.rdbitmno.Size = New System.Drawing.Size(103, 17)
        Me.rdbitmno.TabIndex = 296
        Me.rdbitmno.TabStop = True
        Me.rdbitmno.Text = "Temp / Item No."
        Me.rdbitmno.UseVisualStyleBackColor = True
        '
        'rdbvenitm
        '
        Me.rdbvenitm.AutoSize = True
        Me.rdbvenitm.Location = New System.Drawing.Point(6, 111)
        Me.rdbvenitm.Name = "rdbvenitm"
        Me.rdbvenitm.Size = New System.Drawing.Size(102, 17)
        Me.rdbvenitm.TabIndex = 297
        Me.rdbvenitm.Text = "Vendor Item No."
        Me.rdbvenitm.UseVisualStyleBackColor = True
        '
        'cmd_S_ItmNo2
        '
        Me.cmd_S_ItmNo2.Location = New System.Drawing.Point(264, 108)
        Me.cmd_S_ItmNo2.Name = "cmd_S_ItmNo2"
        Me.cmd_S_ItmNo2.Size = New System.Drawing.Size(75, 23)
        Me.cmd_S_ItmNo2.TabIndex = 298
        Me.cmd_S_ItmNo2.Text = "＞＞"
        Me.cmd_S_ItmNo2.UseVisualStyleBackColor = True
        '
        'TabPageMain
        '
        Me.TabPageMain.Controls.Add(Me.TabPage1)
        Me.TabPageMain.Controls.Add(Me.TabPage2)
        Me.TabPageMain.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.TabPageMain.ItemSize = New System.Drawing.Size(62, 18)
        Me.TabPageMain.Location = New System.Drawing.Point(12, 212)
        Me.TabPageMain.Name = "TabPageMain"
        Me.TabPageMain.SelectedIndex = 0
        Me.TabPageMain.Size = New System.Drawing.Size(728, 312)
        Me.TabPageMain.TabIndex = 276
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.grdSum)
        Me.TabPage1.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(720, 286)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "(1) Summary "
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'grdSum
        '
        Me.grdSum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdSum.Location = New System.Drawing.Point(6, 3)
        Me.grdSum.Name = "grdSum"
        Me.grdSum.RowTemplate.Height = 15
        Me.grdSum.Size = New System.Drawing.Size(708, 277)
        Me.grdSum.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.grdDtl)
        Me.TabPage2.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(720, 286)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "(2) Details "
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'grdDtl
        '
        Me.grdDtl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDtl.Location = New System.Drawing.Point(6, 3)
        Me.grdDtl.Name = "grdDtl"
        Me.grdDtl.RowTemplate.Height = 15
        Me.grdDtl.Size = New System.Drawing.Size(708, 277)
        Me.grdDtl.TabIndex = 1
        '
        'SAM00002
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(752, 566)
        Me.Controls.Add(Me.cmd_S_ItmNo2)
        Me.Controls.Add(Me.rdbvenitm)
        Me.Controls.Add(Me.rdbitmno)
        Me.Controls.Add(Me.txtVendor)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtVenItmNo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmd_S_ItmNo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtUpdDat)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtColCde)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdMapping)
        Me.Controls.Add(Me.txtItmNo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCusNo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.TabPageMain)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.cmdlast)
        Me.Controls.Add(Me.cmdPrv)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.cmdFind)
        Me.Controls.Add(Me.cmdCopy)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdDelRow)
        Me.Controls.Add(Me.cmdfirst)
        Me.Controls.Add(Me.cmdInsRow)
        Me.Controls.Add(Me.cmdSearch)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(760, 600)
        Me.MinimumSize = New System.Drawing.Size(760, 600)
        Me.Name = "SAM00002"
        Me.Text = "Sample Order Summary (SAM00002)"
        Me.StatusBar.ResumeLayout(False)
        Me.StatusBar.PerformLayout()
        Me.TabPageMain.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.grdSum, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.grdDtl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents cmdlast As System.Windows.Forms.Button
    Friend WithEvents cmdPrv As System.Windows.Forms.Button
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents cmdFind As System.Windows.Forms.Button
    Friend WithEvents cmdCopy As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdDelRow As System.Windows.Forms.Button
    Friend WithEvents cmdfirst As System.Windows.Forms.Button
    Friend WithEvents cmdInsRow As System.Windows.Forms.Button
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents StatusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents lblLeft As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblRight As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TabPageMain As ERPSystem.BaseTabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCusNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtItmNo As System.Windows.Forms.TextBox
    Friend WithEvents cmdMapping As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtColCde As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtUpdDat As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents grdSum As System.Windows.Forms.DataGridView
    Friend WithEvents grdDtl As System.Windows.Forms.DataGridView
    Friend WithEvents cmd_S_ItmNo As System.Windows.Forms.Button
    Friend WithEvents txtVenItmNo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtVendor As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents rdbitmno As System.Windows.Forms.RadioButton
    Friend WithEvents rdbvenitm As System.Windows.Forms.RadioButton
    Friend WithEvents cmd_S_ItmNo2 As System.Windows.Forms.Button
End Class
