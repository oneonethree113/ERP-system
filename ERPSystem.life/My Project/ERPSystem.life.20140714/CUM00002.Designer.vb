<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CUM00002
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CUM00002))
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtCusNo = New System.Windows.Forms.TextBox
        Me.txtSecCus = New System.Windows.Forms.TextBox
        Me.txtCusNam = New System.Windows.Forms.TextBox
        Me.txtSecSna = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtItmNo = New System.Windows.Forms.TextBox
        Me.txtCusItm = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtCusStyNo = New System.Windows.Forms.TextBox
        Me.chbAlias = New System.Windows.Forms.CheckBox
        Me.StatusBar = New System.Windows.Forms.StatusBar
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel
        Me.StatusBarPanel2 = New System.Windows.Forms.StatusBarPanel
        Me.cmdMapping = New System.Windows.Forms.Button
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdBrowse = New System.Windows.Forms.Button
        Me.btcCUM00002 = New System.Windows.Forms.TabControl
        Me.tpCUM00002_1 = New System.Windows.Forms.TabPage
        Me.grdCuItmSum = New System.Windows.Forms.DataGridView
        Me.tpCUM00002_2 = New System.Windows.Forms.TabPage
        Me.grdCuItmDtl = New System.Windows.Forms.DataGridView
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.btcCUM00002.SuspendLayout()
        Me.tpCUM00002_1.SuspendLayout()
        CType(Me.grdCuItmSum, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpCUM00002_2.SuspendLayout()
        CType(Me.grdCuItmDtl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdInsRow
        '
        Me.cmdInsRow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdInsRow.Location = New System.Drawing.Point(412, 0)
        Me.cmdInsRow.Name = "cmdInsRow"
        Me.cmdInsRow.Size = New System.Drawing.Size(56, 25)
        Me.cmdInsRow.TabIndex = 8
        Me.cmdInsRow.Text = "I&ns Row"
        Me.cmdInsRow.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelete.Location = New System.Drawing.Point(112, 0)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(56, 25)
        Me.cmdDelete.TabIndex = 3
        Me.cmdDelete.Text = "&Delete"
        '
        'cmdSave
        '
        Me.cmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.Location = New System.Drawing.Point(56, 0)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(56, 25)
        Me.cmdSave.TabIndex = 2
        Me.cmdSave.Text = "&Save"
        '
        'cmdLast
        '
        Me.cmdLast.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLast.Location = New System.Drawing.Point(650, 0)
        Me.cmdLast.Name = "cmdLast"
        Me.cmdLast.Size = New System.Drawing.Size(40, 25)
        Me.cmdLast.TabIndex = 13
        Me.cmdLast.Text = ">>|"
        '
        'cmdPrevious
        '
        Me.cmdPrevious.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrevious.Location = New System.Drawing.Point(570, 0)
        Me.cmdPrevious.Name = "cmdPrevious"
        Me.cmdPrevious.Size = New System.Drawing.Size(40, 25)
        Me.cmdPrevious.TabIndex = 11
        Me.cmdPrevious.Text = "<"
        '
        'cmdAdd
        '
        Me.cmdAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdd.Location = New System.Drawing.Point(0, 0)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(56, 25)
        Me.cmdAdd.TabIndex = 1
        Me.cmdAdd.Text = "&Add"
        '
        'cmdNext
        '
        Me.cmdNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNext.Location = New System.Drawing.Point(610, 0)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(40, 25)
        Me.cmdNext.TabIndex = 12
        Me.cmdNext.Text = ">"
        '
        'cmdFind
        '
        Me.cmdFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFind.Location = New System.Drawing.Point(224, 0)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(56, 25)
        Me.cmdFind.TabIndex = 5
        Me.cmdFind.Text = "&Find"
        '
        'cmdCopy
        '
        Me.cmdCopy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCopy.Location = New System.Drawing.Point(168, 0)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(56, 25)
        Me.cmdCopy.TabIndex = 4
        Me.cmdCopy.Text = "&Copy"
        '
        'cmdClear
        '
        Me.cmdClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(280, 0)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(56, 25)
        Me.cmdClear.TabIndex = 6
        Me.cmdClear.Text = "Cl&ear"
        '
        'cmdExit
        '
        Me.cmdExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(696, 0)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(56, 25)
        Me.cmdExit.TabIndex = 14
        Me.cmdExit.Text = "E&xit"
        '
        'cmdDelRow
        '
        Me.cmdDelRow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelRow.Location = New System.Drawing.Point(468, 0)
        Me.cmdDelRow.Name = "cmdDelRow"
        Me.cmdDelRow.Size = New System.Drawing.Size(56, 25)
        Me.cmdDelRow.TabIndex = 9
        Me.cmdDelRow.Text = "Del Ro&w"
        '
        'cmdFirst
        '
        Me.cmdFirst.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFirst.Location = New System.Drawing.Point(530, 0)
        Me.cmdFirst.Name = "cmdFirst"
        Me.cmdFirst.Size = New System.Drawing.Size(40, 25)
        Me.cmdFirst.TabIndex = 10
        Me.cmdFirst.Text = "|<<"
        '
        'cmdSearch
        '
        Me.cmdSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(342, 0)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(64, 25)
        Me.cmdSearch.TabIndex = 7
        Me.cmdSearch.Text = "Searc&h"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(12, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 13)
        Me.Label2.TabIndex = 105
        Me.Label2.Text = "Primary Customer No. :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label5.Location = New System.Drawing.Point(12, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(131, 13)
        Me.Label5.TabIndex = 106
        Me.Label5.Text = "Secondary Customer No. :"
        '
        'txtCusNo
        '
        Me.txtCusNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCusNo.Location = New System.Drawing.Point(149, 31)
        Me.txtCusNo.MaxLength = 10
        Me.txtCusNo.Name = "txtCusNo"
        Me.txtCusNo.Size = New System.Drawing.Size(85, 20)
        Me.txtCusNo.TabIndex = 15
        '
        'txtSecCus
        '
        Me.txtSecCus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtSecCus.Location = New System.Drawing.Point(149, 57)
        Me.txtSecCus.MaxLength = 10
        Me.txtSecCus.Name = "txtSecCus"
        Me.txtSecCus.Size = New System.Drawing.Size(85, 20)
        Me.txtSecCus.TabIndex = 16
        '
        'txtCusNam
        '
        Me.txtCusNam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCusNam.Location = New System.Drawing.Point(234, 31)
        Me.txtCusNam.MaxLength = 50
        Me.txtCusNam.Name = "txtCusNam"
        Me.txtCusNam.Size = New System.Drawing.Size(336, 20)
        Me.txtCusNam.TabIndex = 109
        '
        'txtSecSna
        '
        Me.txtSecSna.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtSecSna.Location = New System.Drawing.Point(234, 57)
        Me.txtSecSna.MaxLength = 50
        Me.txtSecSna.Name = "txtSecSna"
        Me.txtSecSna.Size = New System.Drawing.Size(336, 20)
        Me.txtSecSna.TabIndex = 110
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label1.Location = New System.Drawing.Point(12, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 111
        Me.Label1.Text = "Item Number :"
        '
        'txtItmNo
        '
        Me.txtItmNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtItmNo.Location = New System.Drawing.Point(149, 93)
        Me.txtItmNo.MaxLength = 20
        Me.txtItmNo.Name = "txtItmNo"
        Me.txtItmNo.Size = New System.Drawing.Size(138, 20)
        Me.txtItmNo.TabIndex = 17
        '
        'txtCusItm
        '
        Me.txtCusItm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCusItm.Location = New System.Drawing.Point(149, 119)
        Me.txtCusItm.MaxLength = 20
        Me.txtCusItm.Name = "txtCusItm"
        Me.txtCusItm.Size = New System.Drawing.Size(138, 20)
        Me.txtCusItm.TabIndex = 21
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label4.Location = New System.Drawing.Point(12, 122)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 13)
        Me.Label4.TabIndex = 113
        Me.Label4.Text = "Customer Item Number :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label3.Location = New System.Drawing.Point(303, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(123, 13)
        Me.Label3.TabIndex = 115
        Me.Label3.Text = "Customer Style Number :"
        '
        'txtCusStyNo
        '
        Me.txtCusStyNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCusStyNo.Location = New System.Drawing.Point(432, 119)
        Me.txtCusStyNo.MaxLength = 20
        Me.txtCusStyNo.Name = "txtCusStyNo"
        Me.txtCusStyNo.Size = New System.Drawing.Size(138, 20)
        Me.txtCusStyNo.TabIndex = 22
        '
        'chbAlias
        '
        Me.chbAlias.AutoSize = True
        Me.chbAlias.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chbAlias.Location = New System.Drawing.Point(425, 95)
        Me.chbAlias.Name = "chbAlias"
        Me.chbAlias.Size = New System.Drawing.Size(145, 17)
        Me.chbAlias.TabIndex = 20
        Me.chbAlias.Text = "Alias Customer Included :"
        Me.chbAlias.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chbAlias.UseVisualStyleBackColor = True
        '
        'StatusBar
        '
        Me.StatusBar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusBar.Location = New System.Drawing.Point(0, 480)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanel1, Me.StatusBarPanel2})
        Me.StatusBar.ShowPanels = True
        Me.StatusBar.Size = New System.Drawing.Size(752, 16)
        Me.StatusBar.TabIndex = 270
        '
        'StatusBarPanel1
        '
        Me.StatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanel1.Name = "StatusBarPanel1"
        Me.StatusBarPanel1.Width = 367
        '
        'StatusBarPanel2
        '
        Me.StatusBarPanel2.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.StatusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanel2.Name = "StatusBarPanel2"
        Me.StatusBarPanel2.Width = 367
        '
        'cmdMapping
        '
        Me.cmdMapping.Image = CType(resources.GetObject("cmdMapping.Image"), System.Drawing.Image)
        Me.cmdMapping.Location = New System.Drawing.Point(337, 90)
        Me.cmdMapping.Name = "cmdMapping"
        Me.cmdMapping.Size = New System.Drawing.Size(25, 25)
        Me.cmdMapping.TabIndex = 19
        Me.ToolTip.SetToolTip(Me.cmdMapping, "Old & New Item Mapping")
        Me.cmdMapping.UseVisualStyleBackColor = True
        '
        'cmdBrowse
        '
        Me.cmdBrowse.Image = CType(resources.GetObject("cmdBrowse.Image"), System.Drawing.Image)
        Me.cmdBrowse.Location = New System.Drawing.Point(306, 90)
        Me.cmdBrowse.Name = "cmdBrowse"
        Me.cmdBrowse.Size = New System.Drawing.Size(25, 25)
        Me.cmdBrowse.TabIndex = 18
        Me.ToolTip.SetToolTip(Me.cmdBrowse, "New Format Item's Color Mapping")
        Me.cmdBrowse.UseVisualStyleBackColor = True
        '
        'btcCUM00002
        '
        Me.btcCUM00002.Controls.Add(Me.tpCUM00002_1)
        Me.btcCUM00002.Controls.Add(Me.tpCUM00002_2)
        Me.btcCUM00002.Location = New System.Drawing.Point(12, 145)
        Me.btcCUM00002.Name = "btcCUM00002"
        Me.btcCUM00002.SelectedIndex = 0
        Me.btcCUM00002.Size = New System.Drawing.Size(728, 329)
        Me.btcCUM00002.TabIndex = 23
        '
        'tpCUM00002_1
        '
        Me.tpCUM00002_1.Controls.Add(Me.grdCuItmSum)
        Me.tpCUM00002_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.tpCUM00002_1.Location = New System.Drawing.Point(4, 22)
        Me.tpCUM00002_1.Name = "tpCUM00002_1"
        Me.tpCUM00002_1.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCUM00002_1.Size = New System.Drawing.Size(720, 303)
        Me.tpCUM00002_1.TabIndex = 0
        Me.tpCUM00002_1.Text = "(1) Summary"
        Me.tpCUM00002_1.UseVisualStyleBackColor = True
        '
        'grdCuItmSum
        '
        Me.grdCuItmSum.AllowUserToAddRows = False
        Me.grdCuItmSum.AllowUserToDeleteRows = False
        Me.grdCuItmSum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCuItmSum.Location = New System.Drawing.Point(6, 6)
        Me.grdCuItmSum.Name = "grdCuItmSum"
        Me.grdCuItmSum.RowHeadersWidth = 20
        Me.grdCuItmSum.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdCuItmSum.RowTemplate.Height = 16
        Me.grdCuItmSum.Size = New System.Drawing.Size(708, 291)
        Me.grdCuItmSum.TabIndex = 24
        '
        'tpCUM00002_2
        '
        Me.tpCUM00002_2.Controls.Add(Me.grdCuItmDtl)
        Me.tpCUM00002_2.Location = New System.Drawing.Point(4, 22)
        Me.tpCUM00002_2.Name = "tpCUM00002_2"
        Me.tpCUM00002_2.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCUM00002_2.Size = New System.Drawing.Size(720, 303)
        Me.tpCUM00002_2.TabIndex = 1
        Me.tpCUM00002_2.Text = "(2) Details"
        Me.tpCUM00002_2.UseVisualStyleBackColor = True
        '
        'grdCuItmDtl
        '
        Me.grdCuItmDtl.AllowUserToAddRows = False
        Me.grdCuItmDtl.AllowUserToDeleteRows = False
        Me.grdCuItmDtl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCuItmDtl.Location = New System.Drawing.Point(6, 6)
        Me.grdCuItmDtl.Name = "grdCuItmDtl"
        Me.grdCuItmDtl.RowHeadersWidth = 20
        Me.grdCuItmDtl.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdCuItmDtl.RowTemplate.Height = 16
        Me.grdCuItmDtl.Size = New System.Drawing.Size(708, 291)
        Me.grdCuItmDtl.TabIndex = 25
        '
        'CUM00002
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(752, 496)
        Me.Controls.Add(Me.btcCUM00002)
        Me.Controls.Add(Me.cmdBrowse)
        Me.Controls.Add(Me.cmdMapping)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.chbAlias)
        Me.Controls.Add(Me.txtCusStyNo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCusItm)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtItmNo)
        Me.Controls.Add(Me.Label1)
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
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "CUM00002"
        Me.Text = "CUM00002 - Customer Item History Maintenance"
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.btcCUM00002.ResumeLayout(False)
        Me.tpCUM00002_1.ResumeLayout(False)
        CType(Me.grdCuItmSum, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpCUM00002_2.ResumeLayout(False)
        CType(Me.grdCuItmDtl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCusNo As System.Windows.Forms.TextBox
    Friend WithEvents txtSecCus As System.Windows.Forms.TextBox
    Friend WithEvents txtCusNam As System.Windows.Forms.TextBox
    Friend WithEvents txtSecSna As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtItmNo As System.Windows.Forms.TextBox
    Friend WithEvents txtCusItm As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCusStyNo As System.Windows.Forms.TextBox
    Friend WithEvents chbAlias As System.Windows.Forms.CheckBox
    Friend WithEvents StatusBar As System.Windows.Forms.StatusBar
    Friend WithEvents StatusBarPanel1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents StatusBarPanel2 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents cmdMapping As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents cmdBrowse As System.Windows.Forms.Button
    Friend WithEvents btcCUM00002 As System.Windows.Forms.TabControl
    Friend WithEvents tpCUM00002_1 As System.Windows.Forms.TabPage
    Friend WithEvents tpCUM00002_2 As System.Windows.Forms.TabPage
    Friend WithEvents grdCuItmSum As System.Windows.Forms.DataGridView
    Friend WithEvents grdCuItmDtl As System.Windows.Forms.DataGridView
End Class
