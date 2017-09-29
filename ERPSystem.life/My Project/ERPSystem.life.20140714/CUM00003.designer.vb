<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CUM00003
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CUM00003))
        Me.StatusBar = New System.Windows.Forms.StatusBar
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel
        Me.StatusBarPanel2 = New System.Windows.Forms.StatusBarPanel
        Me.chbAlias = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.tpCUM00002_2 = New System.Windows.Forms.TabPage
        Me.grdCuItmPRC = New System.Windows.Forms.DataGridView
        Me.txtCusStyNo = New System.Windows.Forms.TextBox
        Me.txtCusItm = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtItmNo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btcCUM00002 = New System.Windows.Forms.TabControl
        Me.tpCUM00002_1 = New System.Windows.Forms.TabPage
        Me.grdCuItmHis = New System.Windows.Forms.DataGridView
        Me.cmdBrowse = New System.Windows.Forms.Button
        Me.cmdMapping = New System.Windows.Forms.Button
        Me.txtSecSna = New System.Windows.Forms.TextBox
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtCusNam = New System.Windows.Forms.TextBox
        Me.txtSecCus = New System.Windows.Forms.TextBox
        Me.txtCusNo = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
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
        Me.Button1 = New System.Windows.Forms.Button
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpCUM00002_2.SuspendLayout()
        CType(Me.grdCuItmPRC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.btcCUM00002.SuspendLayout()
        Me.tpCUM00002_1.SuspendLayout()
        CType(Me.grdCuItmHis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusBar
        '
        Me.StatusBar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusBar.Location = New System.Drawing.Point(0, 478)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanel1, Me.StatusBarPanel2})
        Me.StatusBar.ShowPanels = True
        Me.StatusBar.Size = New System.Drawing.Size(750, 16)
        Me.StatusBar.TabIndex = 301
        '
        'StatusBarPanel1
        '
        Me.StatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanel1.Name = "StatusBarPanel1"
        Me.StatusBarPanel1.Width = 366
        '
        'StatusBarPanel2
        '
        Me.StatusBarPanel2.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.StatusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanel2.Name = "StatusBarPanel2"
        Me.StatusBarPanel2.Width = 366
        '
        'chbAlias
        '
        Me.chbAlias.AutoSize = True
        Me.chbAlias.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chbAlias.Location = New System.Drawing.Point(584, 144)
        Me.chbAlias.Name = "chbAlias"
        Me.chbAlias.Size = New System.Drawing.Size(145, 17)
        Me.chbAlias.TabIndex = 290
        Me.chbAlias.Text = "Alias Customer Included :"
        Me.chbAlias.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chbAlias.UseVisualStyleBackColor = True
        Me.chbAlias.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label3.Location = New System.Drawing.Point(302, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(123, 13)
        Me.Label3.TabIndex = 300
        Me.Label3.Text = "Customer Style Number :"
        '
        'tpCUM00002_2
        '
        Me.tpCUM00002_2.Controls.Add(Me.grdCuItmPRC)
        Me.tpCUM00002_2.Location = New System.Drawing.Point(4, 22)
        Me.tpCUM00002_2.Name = "tpCUM00002_2"
        Me.tpCUM00002_2.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCUM00002_2.Size = New System.Drawing.Size(720, 303)
        Me.tpCUM00002_2.TabIndex = 1
        Me.tpCUM00002_2.Text = "(2) Pricing"
        Me.tpCUM00002_2.UseVisualStyleBackColor = True
        '
        'grdCuItmPRC
        '
        Me.grdCuItmPRC.AllowUserToAddRows = False
        Me.grdCuItmPRC.AllowUserToDeleteRows = False
        Me.grdCuItmPRC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCuItmPRC.Location = New System.Drawing.Point(6, 6)
        Me.grdCuItmPRC.Name = "grdCuItmPRC"
        Me.grdCuItmPRC.RowHeadersWidth = 20
        Me.grdCuItmPRC.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdCuItmPRC.RowTemplate.Height = 16
        Me.grdCuItmPRC.Size = New System.Drawing.Size(708, 291)
        Me.grdCuItmPRC.TabIndex = 25
        '
        'txtCusStyNo
        '
        Me.txtCusStyNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCusStyNo.Location = New System.Drawing.Point(431, 119)
        Me.txtCusStyNo.MaxLength = 50
        Me.txtCusStyNo.Name = "txtCusStyNo"
        Me.txtCusStyNo.Size = New System.Drawing.Size(138, 20)
        Me.txtCusStyNo.TabIndex = 292
        '
        'txtCusItm
        '
        Me.txtCusItm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCusItm.Location = New System.Drawing.Point(148, 119)
        Me.txtCusItm.MaxLength = 50
        Me.txtCusItm.Name = "txtCusItm"
        Me.txtCusItm.Size = New System.Drawing.Size(138, 20)
        Me.txtCusItm.TabIndex = 291
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label4.Location = New System.Drawing.Point(11, 122)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 13)
        Me.Label4.TabIndex = 299
        Me.Label4.Text = "Customer Item Number :"
        '
        'txtItmNo
        '
        Me.txtItmNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtItmNo.Location = New System.Drawing.Point(148, 93)
        Me.txtItmNo.MaxLength = 100
        Me.txtItmNo.Name = "txtItmNo"
        Me.txtItmNo.Size = New System.Drawing.Size(421, 20)
        Me.txtItmNo.TabIndex = 287
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label1.Location = New System.Drawing.Point(11, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 298
        Me.Label1.Text = "Item Number :"
        '
        'btcCUM00002
        '
        Me.btcCUM00002.Controls.Add(Me.tpCUM00002_1)
        Me.btcCUM00002.Controls.Add(Me.tpCUM00002_2)
        Me.btcCUM00002.Location = New System.Drawing.Point(11, 145)
        Me.btcCUM00002.Name = "btcCUM00002"
        Me.btcCUM00002.SelectedIndex = 0
        Me.btcCUM00002.Size = New System.Drawing.Size(728, 329)
        Me.btcCUM00002.TabIndex = 293
        '
        'tpCUM00002_1
        '
        Me.tpCUM00002_1.Controls.Add(Me.grdCuItmHis)
        Me.tpCUM00002_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.tpCUM00002_1.Location = New System.Drawing.Point(4, 22)
        Me.tpCUM00002_1.Name = "tpCUM00002_1"
        Me.tpCUM00002_1.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCUM00002_1.Size = New System.Drawing.Size(720, 303)
        Me.tpCUM00002_1.TabIndex = 0
        Me.tpCUM00002_1.Text = "(1) History"
        Me.tpCUM00002_1.UseVisualStyleBackColor = True
        '
        'grdCuItmHis
        '
        Me.grdCuItmHis.AllowUserToAddRows = False
        Me.grdCuItmHis.AllowUserToDeleteRows = False
        Me.grdCuItmHis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCuItmHis.Location = New System.Drawing.Point(6, 6)
        Me.grdCuItmHis.Name = "grdCuItmHis"
        Me.grdCuItmHis.RowHeadersWidth = 20
        Me.grdCuItmHis.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdCuItmHis.RowTemplate.Height = 16
        Me.grdCuItmHis.Size = New System.Drawing.Size(708, 291)
        Me.grdCuItmHis.TabIndex = 24
        '
        'cmdBrowse
        '
        Me.cmdBrowse.Image = CType(resources.GetObject("cmdBrowse.Image"), System.Drawing.Image)
        Me.cmdBrowse.Location = New System.Drawing.Point(579, 90)
        Me.cmdBrowse.Name = "cmdBrowse"
        Me.cmdBrowse.Size = New System.Drawing.Size(25, 25)
        Me.cmdBrowse.TabIndex = 288
        Me.ToolTip.SetToolTip(Me.cmdBrowse, "New Format Item's Color Mapping")
        Me.cmdBrowse.UseVisualStyleBackColor = True
        '
        'cmdMapping
        '
        Me.cmdMapping.Image = CType(resources.GetObject("cmdMapping.Image"), System.Drawing.Image)
        Me.cmdMapping.Location = New System.Drawing.Point(610, 90)
        Me.cmdMapping.Name = "cmdMapping"
        Me.cmdMapping.Size = New System.Drawing.Size(25, 25)
        Me.cmdMapping.TabIndex = 289
        Me.ToolTip.SetToolTip(Me.cmdMapping, "Old & New Item Mapping")
        Me.cmdMapping.UseVisualStyleBackColor = True
        '
        'txtSecSna
        '
        Me.txtSecSna.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtSecSna.Location = New System.Drawing.Point(233, 57)
        Me.txtSecSna.MaxLength = 10
        Me.txtSecSna.Name = "txtSecSna"
        Me.txtSecSna.Size = New System.Drawing.Size(336, 20)
        Me.txtSecSna.TabIndex = 297
        '
        'txtCusNam
        '
        Me.txtCusNam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCusNam.Location = New System.Drawing.Point(233, 31)
        Me.txtCusNam.MaxLength = 10
        Me.txtCusNam.Name = "txtCusNam"
        Me.txtCusNam.Size = New System.Drawing.Size(336, 20)
        Me.txtCusNam.TabIndex = 296
        '
        'txtSecCus
        '
        Me.txtSecCus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtSecCus.Location = New System.Drawing.Point(148, 57)
        Me.txtSecCus.MaxLength = 20
        Me.txtSecCus.Name = "txtSecCus"
        Me.txtSecCus.Size = New System.Drawing.Size(85, 20)
        Me.txtSecCus.TabIndex = 286
        '
        'txtCusNo
        '
        Me.txtCusNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCusNo.Location = New System.Drawing.Point(148, 31)
        Me.txtCusNo.MaxLength = 20
        Me.txtCusNo.Name = "txtCusNo"
        Me.txtCusNo.Size = New System.Drawing.Size(85, 20)
        Me.txtCusNo.TabIndex = 285
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label5.Location = New System.Drawing.Point(11, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(131, 13)
        Me.Label5.TabIndex = 295
        Me.Label5.Text = "Secondary Customer No. :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(11, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 13)
        Me.Label2.TabIndex = 294
        Me.Label2.Text = "Primary Customer No. :"
        '
        'cmdInsRow
        '
        Me.cmdInsRow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdInsRow.Location = New System.Drawing.Point(411, 0)
        Me.cmdInsRow.Name = "cmdInsRow"
        Me.cmdInsRow.Size = New System.Drawing.Size(56, 25)
        Me.cmdInsRow.TabIndex = 278
        Me.cmdInsRow.Text = "I&ns Row"
        Me.cmdInsRow.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelete.Location = New System.Drawing.Point(111, 0)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(56, 25)
        Me.cmdDelete.TabIndex = 273
        Me.cmdDelete.Text = "&Delete"
        '
        'cmdSave
        '
        Me.cmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.Location = New System.Drawing.Point(55, 0)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(56, 25)
        Me.cmdSave.TabIndex = 272
        Me.cmdSave.Text = "&Save"
        '
        'cmdLast
        '
        Me.cmdLast.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLast.Location = New System.Drawing.Point(649, 0)
        Me.cmdLast.Name = "cmdLast"
        Me.cmdLast.Size = New System.Drawing.Size(40, 25)
        Me.cmdLast.TabIndex = 283
        Me.cmdLast.Text = ">>|"
        '
        'cmdPrevious
        '
        Me.cmdPrevious.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrevious.Location = New System.Drawing.Point(569, 0)
        Me.cmdPrevious.Name = "cmdPrevious"
        Me.cmdPrevious.Size = New System.Drawing.Size(40, 25)
        Me.cmdPrevious.TabIndex = 281
        Me.cmdPrevious.Text = "<"
        '
        'cmdAdd
        '
        Me.cmdAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdd.Location = New System.Drawing.Point(-1, 0)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(56, 25)
        Me.cmdAdd.TabIndex = 271
        Me.cmdAdd.Text = "&Add"
        '
        'cmdNext
        '
        Me.cmdNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNext.Location = New System.Drawing.Point(609, 0)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(40, 25)
        Me.cmdNext.TabIndex = 282
        Me.cmdNext.Text = ">"
        '
        'cmdFind
        '
        Me.cmdFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFind.Location = New System.Drawing.Point(223, 0)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(56, 25)
        Me.cmdFind.TabIndex = 275
        Me.cmdFind.Text = "&Find"
        '
        'cmdCopy
        '
        Me.cmdCopy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCopy.Location = New System.Drawing.Point(167, 0)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(56, 25)
        Me.cmdCopy.TabIndex = 274
        Me.cmdCopy.Text = "&Copy"
        '
        'cmdClear
        '
        Me.cmdClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(279, 0)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(56, 25)
        Me.cmdClear.TabIndex = 276
        Me.cmdClear.Text = "Cl&ear"
        '
        'cmdExit
        '
        Me.cmdExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(695, 0)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(56, 25)
        Me.cmdExit.TabIndex = 284
        Me.cmdExit.Text = "E&xit"
        '
        'cmdDelRow
        '
        Me.cmdDelRow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelRow.Location = New System.Drawing.Point(467, 0)
        Me.cmdDelRow.Name = "cmdDelRow"
        Me.cmdDelRow.Size = New System.Drawing.Size(56, 25)
        Me.cmdDelRow.TabIndex = 279
        Me.cmdDelRow.Text = "Del Ro&w"
        '
        'cmdFirst
        '
        Me.cmdFirst.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFirst.Location = New System.Drawing.Point(529, 0)
        Me.cmdFirst.Name = "cmdFirst"
        Me.cmdFirst.Size = New System.Drawing.Size(40, 25)
        Me.cmdFirst.TabIndex = 280
        Me.cmdFirst.Text = "|<<"
        '
        'cmdSearch
        '
        Me.cmdSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(341, 0)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(64, 25)
        Me.cmdSearch.TabIndex = 277
        Me.cmdSearch.Text = "Searc&h"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(639, 90)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(40, 25)
        Me.Button1.TabIndex = 302
        Me.Button1.Text = "＞＞"
        '
        'CUM00003
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(750, 494)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.chbAlias)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCusStyNo)
        Me.Controls.Add(Me.txtCusItm)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtItmNo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btcCUM00002)
        Me.Controls.Add(Me.cmdBrowse)
        Me.Controls.Add(Me.cmdMapping)
        Me.Controls.Add(Me.txtSecSna)
        Me.Controls.Add(Me.txtCusNam)
        Me.Controls.Add(Me.txtSecCus)
        Me.Controls.Add(Me.txtCusNo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
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
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(758, 528)
        Me.MinimumSize = New System.Drawing.Size(758, 528)
        Me.Name = "CUM00003"
        Me.Text = "CUM00003 - Customer Item History Maintenance"
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpCUM00002_2.ResumeLayout(False)
        CType(Me.grdCuItmPRC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.btcCUM00002.ResumeLayout(False)
        Me.tpCUM00002_1.ResumeLayout(False)
        CType(Me.grdCuItmHis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusBar As System.Windows.Forms.StatusBar
    Friend WithEvents StatusBarPanel1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents StatusBarPanel2 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents chbAlias As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tpCUM00002_2 As System.Windows.Forms.TabPage
    Friend WithEvents grdCuItmPRC As System.Windows.Forms.DataGridView
    Friend WithEvents txtCusStyNo As System.Windows.Forms.TextBox
    Friend WithEvents txtCusItm As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtItmNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btcCUM00002 As System.Windows.Forms.TabControl
    Friend WithEvents tpCUM00002_1 As System.Windows.Forms.TabPage
    Friend WithEvents grdCuItmHis As System.Windows.Forms.DataGridView
    Friend WithEvents cmdBrowse As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents cmdMapping As System.Windows.Forms.Button
    Friend WithEvents txtSecSna As System.Windows.Forms.TextBox
    Friend WithEvents txtCusNam As System.Windows.Forms.TextBox
    Friend WithEvents txtSecCus As System.Windows.Forms.TextBox
    Friend WithEvents txtCusNo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
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
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
