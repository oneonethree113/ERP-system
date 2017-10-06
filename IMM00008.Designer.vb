<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IMM00008
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
        Me.tcfrmCLMQuickInsert = New ERPSystem.BaseTabControl
        Me.tcfrmCLMQuickInsert_1 = New System.Windows.Forms.TabPage
        Me.txt_S_ShipNo = New System.Windows.Forms.TextBox
        Me.cmdShipNo = New System.Windows.Forms.Button
        Me.lblShipNo = New System.Windows.Forms.Label
        Me.cmdClaimPeriod = New System.Windows.Forms.Button
        Me.lblClaimPeriod = New System.Windows.Forms.Label
        Me.txt_S_ClaimPeriod = New System.Windows.Forms.TextBox
        Me.cmdExit1 = New System.Windows.Forms.Button
        Me.cmdSearch = New System.Windows.Forms.Button
        Me.cmdPV = New System.Windows.Forms.Button
        Me.lblPV = New System.Windows.Forms.Label
        Me.txt_S_PV = New System.Windows.Forms.TextBox
        Me.cmdSecCust = New System.Windows.Forms.Button
        Me.txt_S_SecCust = New System.Windows.Forms.TextBox
        Me.lblSecCust = New System.Windows.Forms.Label
        Me.cmdItmNo = New System.Windows.Forms.Button
        Me.cmdPriCust = New System.Windows.Forms.Button
        Me.cmdCoCde = New System.Windows.Forms.Button
        Me.lblItmNo = New System.Windows.Forms.Label
        Me.txt_S_ItmNo = New System.Windows.Forms.TextBox
        Me.txt_S_PriCust = New System.Windows.Forms.TextBox
        Me.txt_S_CoCde = New System.Windows.Forms.TextBox
        Me.lblPriCust = New System.Windows.Forms.Label
        Me.lblCoCde = New System.Windows.Forms.Label
        Me.tcfrmCLMQuickInsert_2 = New System.Windows.Forms.TabPage
        Me.cmdExit2 = New System.Windows.Forms.Button
        Me.chkSelectAll = New System.Windows.Forms.CheckBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdInsert = New System.Windows.Forms.Button
        Me.dgResult = New System.Windows.Forms.DataGridView
        Me.tcfrmCLMQuickInsert.SuspendLayout()
        Me.tcfrmCLMQuickInsert_1.SuspendLayout()
        Me.tcfrmCLMQuickInsert_2.SuspendLayout()
        CType(Me.dgResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tcfrmCLMQuickInsert
        '
        Me.tcfrmCLMQuickInsert.Controls.Add(Me.tcfrmCLMQuickInsert_1)
        Me.tcfrmCLMQuickInsert.Controls.Add(Me.tcfrmCLMQuickInsert_2)
        Me.tcfrmCLMQuickInsert.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.tcfrmCLMQuickInsert.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tcfrmCLMQuickInsert.Location = New System.Drawing.Point(2, 2)
        Me.tcfrmCLMQuickInsert.Name = "tcfrmCLMQuickInsert"
        Me.tcfrmCLMQuickInsert.SelectedIndex = 0
        Me.tcfrmCLMQuickInsert.Size = New System.Drawing.Size(747, 275)
        Me.tcfrmCLMQuickInsert.TabIndex = 1
        '
        'tcfrmCLMQuickInsert_1
        '
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.txt_S_ShipNo)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.cmdShipNo)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.lblShipNo)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.cmdClaimPeriod)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.lblClaimPeriod)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.txt_S_ClaimPeriod)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.cmdExit1)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.cmdSearch)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.cmdPV)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.lblPV)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.txt_S_PV)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.cmdSecCust)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.txt_S_SecCust)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.lblSecCust)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.cmdItmNo)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.cmdPriCust)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.cmdCoCde)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.lblItmNo)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.txt_S_ItmNo)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.txt_S_PriCust)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.txt_S_CoCde)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.lblPriCust)
        Me.tcfrmCLMQuickInsert_1.Controls.Add(Me.lblCoCde)
        Me.tcfrmCLMQuickInsert_1.Location = New System.Drawing.Point(4, 24)
        Me.tcfrmCLMQuickInsert_1.Name = "tcfrmCLMQuickInsert_1"
        Me.tcfrmCLMQuickInsert_1.Padding = New System.Windows.Forms.Padding(3)
        Me.tcfrmCLMQuickInsert_1.Size = New System.Drawing.Size(739, 247)
        Me.tcfrmCLMQuickInsert_1.TabIndex = 0
        Me.tcfrmCLMQuickInsert_1.Text = "Search"
        Me.tcfrmCLMQuickInsert_1.UseVisualStyleBackColor = True
        '
        'txt_S_ShipNo
        '
        Me.txt_S_ShipNo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_S_ShipNo.Location = New System.Drawing.Point(192, 175)
        Me.txt_S_ShipNo.MaxLength = 1000
        Me.txt_S_ShipNo.Name = "txt_S_ShipNo"
        Me.txt_S_ShipNo.Size = New System.Drawing.Size(530, 21)
        Me.txt_S_ShipNo.TabIndex = 209
        '
        'cmdShipNo
        '
        Me.cmdShipNo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShipNo.Location = New System.Drawing.Point(120, 172)
        Me.cmdShipNo.Name = "cmdShipNo"
        Me.cmdShipNo.Size = New System.Drawing.Size(64, 24)
        Me.cmdShipNo.TabIndex = 208
        Me.cmdShipNo.Text = "＞＞"
        '
        'lblShipNo
        '
        Me.lblShipNo.AutoSize = True
        Me.lblShipNo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShipNo.Location = New System.Drawing.Point(8, 174)
        Me.lblShipNo.Name = "lblShipNo"
        Me.lblShipNo.Size = New System.Drawing.Size(44, 15)
        Me.lblShipNo.TabIndex = 210
        Me.lblShipNo.Text = "Packing"
        '
        'cmdClaimPeriod
        '
        Me.cmdClaimPeriod.Enabled = False
        Me.cmdClaimPeriod.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClaimPeriod.Location = New System.Drawing.Point(120, 11)
        Me.cmdClaimPeriod.Name = "cmdClaimPeriod"
        Me.cmdClaimPeriod.Size = New System.Drawing.Size(64, 24)
        Me.cmdClaimPeriod.TabIndex = 205
        Me.cmdClaimPeriod.Text = "＞＞"
        '
        'lblClaimPeriod
        '
        Me.lblClaimPeriod.AutoSize = True
        Me.lblClaimPeriod.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClaimPeriod.Location = New System.Drawing.Point(8, 16)
        Me.lblClaimPeriod.Name = "lblClaimPeriod"
        Me.lblClaimPeriod.Size = New System.Drawing.Size(73, 15)
        Me.lblClaimPeriod.TabIndex = 207
        Me.lblClaimPeriod.Text = "Request Sales"
        '
        'txt_S_ClaimPeriod
        '
        Me.txt_S_ClaimPeriod.Enabled = False
        Me.txt_S_ClaimPeriod.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_S_ClaimPeriod.Location = New System.Drawing.Point(192, 13)
        Me.txt_S_ClaimPeriod.MaxLength = 1000
        Me.txt_S_ClaimPeriod.Name = "txt_S_ClaimPeriod"
        Me.txt_S_ClaimPeriod.Size = New System.Drawing.Size(530, 21)
        Me.txt_S_ClaimPeriod.TabIndex = 206
        '
        'cmdExit1
        '
        Me.cmdExit1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit1.Location = New System.Drawing.Point(373, 202)
        Me.cmdExit1.Name = "cmdExit1"
        Me.cmdExit1.Size = New System.Drawing.Size(129, 34)
        Me.cmdExit1.TabIndex = 28
        Me.cmdExit1.Text = "E&xit"
        Me.cmdExit1.UseVisualStyleBackColor = True
        '
        'cmdSearch
        '
        Me.cmdSearch.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(237, 202)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(129, 34)
        Me.cmdSearch.TabIndex = 27
        Me.cmdSearch.Text = "Searc&h"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'cmdPV
        '
        Me.cmdPV.Enabled = False
        Me.cmdPV.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPV.Location = New System.Drawing.Point(120, 119)
        Me.cmdPV.Name = "cmdPV"
        Me.cmdPV.Size = New System.Drawing.Size(64, 24)
        Me.cmdPV.TabIndex = 7
        Me.cmdPV.Text = "＞＞"
        '
        'lblPV
        '
        Me.lblPV.AutoSize = True
        Me.lblPV.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPV.Location = New System.Drawing.Point(8, 121)
        Me.lblPV.Name = "lblPV"
        Me.lblPV.Size = New System.Drawing.Size(45, 15)
        Me.lblPV.TabIndex = 191
        Me.lblPV.Text = "Factory"
        '
        'txt_S_PV
        '
        Me.txt_S_PV.Enabled = False
        Me.txt_S_PV.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_S_PV.Location = New System.Drawing.Point(192, 121)
        Me.txt_S_PV.MaxLength = 1000
        Me.txt_S_PV.Name = "txt_S_PV"
        Me.txt_S_PV.Size = New System.Drawing.Size(530, 21)
        Me.txt_S_PV.TabIndex = 8
        '
        'cmdSecCust
        '
        Me.cmdSecCust.Enabled = False
        Me.cmdSecCust.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSecCust.Location = New System.Drawing.Point(120, 92)
        Me.cmdSecCust.Name = "cmdSecCust"
        Me.cmdSecCust.Size = New System.Drawing.Size(64, 24)
        Me.cmdSecCust.TabIndex = 5
        Me.cmdSecCust.Text = "＞＞"
        '
        'txt_S_SecCust
        '
        Me.txt_S_SecCust.Enabled = False
        Me.txt_S_SecCust.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_S_SecCust.Location = New System.Drawing.Point(192, 94)
        Me.txt_S_SecCust.MaxLength = 1000
        Me.txt_S_SecCust.Name = "txt_S_SecCust"
        Me.txt_S_SecCust.Size = New System.Drawing.Size(530, 21)
        Me.txt_S_SecCust.TabIndex = 6
        '
        'lblSecCust
        '
        Me.lblSecCust.AutoSize = True
        Me.lblSecCust.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSecCust.Location = New System.Drawing.Point(8, 97)
        Me.lblSecCust.Name = "lblSecCust"
        Me.lblSecCust.Size = New System.Drawing.Size(73, 15)
        Me.lblSecCust.TabIndex = 190
        Me.lblSecCust.Text = "Sec Customer"
        '
        'cmdItmNo
        '
        Me.cmdItmNo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdItmNo.Location = New System.Drawing.Point(120, 146)
        Me.cmdItmNo.Name = "cmdItmNo"
        Me.cmdItmNo.Size = New System.Drawing.Size(64, 24)
        Me.cmdItmNo.TabIndex = 9
        Me.cmdItmNo.Text = "＞＞"
        '
        'cmdPriCust
        '
        Me.cmdPriCust.Enabled = False
        Me.cmdPriCust.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPriCust.Location = New System.Drawing.Point(120, 65)
        Me.cmdPriCust.Name = "cmdPriCust"
        Me.cmdPriCust.Size = New System.Drawing.Size(64, 24)
        Me.cmdPriCust.TabIndex = 3
        Me.cmdPriCust.Text = "＞＞"
        '
        'cmdCoCde
        '
        Me.cmdCoCde.Enabled = False
        Me.cmdCoCde.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCoCde.Location = New System.Drawing.Point(120, 38)
        Me.cmdCoCde.Name = "cmdCoCde"
        Me.cmdCoCde.Size = New System.Drawing.Size(64, 24)
        Me.cmdCoCde.TabIndex = 1
        Me.cmdCoCde.Text = "＞＞"
        '
        'lblItmNo
        '
        Me.lblItmNo.AutoSize = True
        Me.lblItmNo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItmNo.Location = New System.Drawing.Point(8, 148)
        Me.lblItmNo.Name = "lblItmNo"
        Me.lblItmNo.Size = New System.Drawing.Size(47, 15)
        Me.lblItmNo.TabIndex = 189
        Me.lblItmNo.Text = "Item No"
        '
        'txt_S_ItmNo
        '
        Me.txt_S_ItmNo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_S_ItmNo.Location = New System.Drawing.Point(192, 148)
        Me.txt_S_ItmNo.MaxLength = 1000
        Me.txt_S_ItmNo.Name = "txt_S_ItmNo"
        Me.txt_S_ItmNo.Size = New System.Drawing.Size(530, 21)
        Me.txt_S_ItmNo.TabIndex = 10
        '
        'txt_S_PriCust
        '
        Me.txt_S_PriCust.Enabled = False
        Me.txt_S_PriCust.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_S_PriCust.Location = New System.Drawing.Point(192, 67)
        Me.txt_S_PriCust.MaxLength = 1000
        Me.txt_S_PriCust.Name = "txt_S_PriCust"
        Me.txt_S_PriCust.Size = New System.Drawing.Size(530, 21)
        Me.txt_S_PriCust.TabIndex = 4
        '
        'txt_S_CoCde
        '
        Me.txt_S_CoCde.Enabled = False
        Me.txt_S_CoCde.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_S_CoCde.Location = New System.Drawing.Point(192, 40)
        Me.txt_S_CoCde.MaxLength = 1000
        Me.txt_S_CoCde.Name = "txt_S_CoCde"
        Me.txt_S_CoCde.Size = New System.Drawing.Size(530, 21)
        Me.txt_S_CoCde.TabIndex = 2
        '
        'lblPriCust
        '
        Me.lblPriCust.AutoSize = True
        Me.lblPriCust.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPriCust.Location = New System.Drawing.Point(8, 70)
        Me.lblPriCust.Name = "lblPriCust"
        Me.lblPriCust.Size = New System.Drawing.Size(71, 15)
        Me.lblPriCust.TabIndex = 188
        Me.lblPriCust.Text = "Pri Customer"
        '
        'lblCoCde
        '
        Me.lblCoCde.AutoSize = True
        Me.lblCoCde.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCoCde.Location = New System.Drawing.Point(8, 43)
        Me.lblCoCde.Name = "lblCoCde"
        Me.lblCoCde.Size = New System.Drawing.Size(72, 15)
        Me.lblCoCde.TabIndex = 187
        Me.lblCoCde.Text = "Request Date"
        '
        'tcfrmCLMQuickInsert_2
        '
        Me.tcfrmCLMQuickInsert_2.Controls.Add(Me.cmdExit2)
        Me.tcfrmCLMQuickInsert_2.Controls.Add(Me.chkSelectAll)
        Me.tcfrmCLMQuickInsert_2.Controls.Add(Me.cmdCancel)
        Me.tcfrmCLMQuickInsert_2.Controls.Add(Me.cmdInsert)
        Me.tcfrmCLMQuickInsert_2.Controls.Add(Me.dgResult)
        Me.tcfrmCLMQuickInsert_2.Location = New System.Drawing.Point(4, 24)
        Me.tcfrmCLMQuickInsert_2.Name = "tcfrmCLMQuickInsert_2"
        Me.tcfrmCLMQuickInsert_2.Padding = New System.Windows.Forms.Padding(3)
        Me.tcfrmCLMQuickInsert_2.Size = New System.Drawing.Size(739, 392)
        Me.tcfrmCLMQuickInsert_2.TabIndex = 1
        Me.tcfrmCLMQuickInsert_2.Text = "Result"
        Me.tcfrmCLMQuickInsert_2.UseVisualStyleBackColor = True
        '
        'cmdExit2
        '
        Me.cmdExit2.Location = New System.Drawing.Point(671, 348)
        Me.cmdExit2.Name = "cmdExit2"
        Me.cmdExit2.Size = New System.Drawing.Size(61, 29)
        Me.cmdExit2.TabIndex = 4
        Me.cmdExit2.Text = "E&xit"
        Me.cmdExit2.UseVisualStyleBackColor = True
        '
        'chkSelectAll
        '
        Me.chkSelectAll.AutoSize = True
        Me.chkSelectAll.Location = New System.Drawing.Point(459, 354)
        Me.chkSelectAll.Name = "chkSelectAll"
        Me.chkSelectAll.Size = New System.Drawing.Size(72, 19)
        Me.chkSelectAll.TabIndex = 1
        Me.chkSelectAll.Text = "Select All"
        Me.chkSelectAll.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(604, 348)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(61, 29)
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdInsert
        '
        Me.cmdInsert.Location = New System.Drawing.Point(537, 348)
        Me.cmdInsert.Name = "cmdInsert"
        Me.cmdInsert.Size = New System.Drawing.Size(61, 29)
        Me.cmdInsert.TabIndex = 2
        Me.cmdInsert.Text = "Insert"
        Me.cmdInsert.UseVisualStyleBackColor = True
        '
        'dgResult
        '
        Me.dgResult.AllowUserToAddRows = False
        Me.dgResult.AllowUserToDeleteRows = False
        Me.dgResult.AllowUserToResizeColumns = False
        Me.dgResult.AllowUserToResizeRows = False
        Me.dgResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgResult.Location = New System.Drawing.Point(6, 6)
        Me.dgResult.Name = "dgResult"
        Me.dgResult.RowHeadersVisible = False
        Me.dgResult.Size = New System.Drawing.Size(726, 336)
        Me.dgResult.TabIndex = 0
        '
        'IMM00008
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(750, 278)
        Me.Controls.Add(Me.tcfrmCLMQuickInsert)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "IMM00008"
        Me.Text = "IMM00008 - Price Request Searching"
        Me.tcfrmCLMQuickInsert.ResumeLayout(False)
        Me.tcfrmCLMQuickInsert_1.ResumeLayout(False)
        Me.tcfrmCLMQuickInsert_1.PerformLayout()
        Me.tcfrmCLMQuickInsert_2.ResumeLayout(False)
        Me.tcfrmCLMQuickInsert_2.PerformLayout()
        CType(Me.dgResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcfrmCLMQuickInsert As ERPSystem.BaseTabControl
    Friend WithEvents tcfrmCLMQuickInsert_1 As System.Windows.Forms.TabPage
    Friend WithEvents txt_S_ShipNo As System.Windows.Forms.TextBox
    Friend WithEvents cmdShipNo As System.Windows.Forms.Button
    Friend WithEvents lblShipNo As System.Windows.Forms.Label
    Friend WithEvents cmdClaimPeriod As System.Windows.Forms.Button
    Friend WithEvents lblClaimPeriod As System.Windows.Forms.Label
    Friend WithEvents txt_S_ClaimPeriod As System.Windows.Forms.TextBox
    Friend WithEvents cmdExit1 As System.Windows.Forms.Button
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents cmdPV As System.Windows.Forms.Button
    Friend WithEvents lblPV As System.Windows.Forms.Label
    Friend WithEvents txt_S_PV As System.Windows.Forms.TextBox
    Friend WithEvents cmdSecCust As System.Windows.Forms.Button
    Friend WithEvents txt_S_SecCust As System.Windows.Forms.TextBox
    Friend WithEvents lblSecCust As System.Windows.Forms.Label
    Friend WithEvents cmdItmNo As System.Windows.Forms.Button
    Friend WithEvents cmdPriCust As System.Windows.Forms.Button
    Friend WithEvents cmdCoCde As System.Windows.Forms.Button
    Friend WithEvents lblItmNo As System.Windows.Forms.Label
    Friend WithEvents txt_S_ItmNo As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_PriCust As System.Windows.Forms.TextBox
    Friend WithEvents txt_S_CoCde As System.Windows.Forms.TextBox
    Friend WithEvents lblPriCust As System.Windows.Forms.Label
    Friend WithEvents lblCoCde As System.Windows.Forms.Label
    Friend WithEvents tcfrmCLMQuickInsert_2 As System.Windows.Forms.TabPage
    Friend WithEvents cmdExit2 As System.Windows.Forms.Button
    Friend WithEvents chkSelectAll As System.Windows.Forms.CheckBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdInsert As System.Windows.Forms.Button
    Friend WithEvents dgResult As System.Windows.Forms.DataGridView
End Class
