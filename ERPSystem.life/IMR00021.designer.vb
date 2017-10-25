<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IMR00021
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IMR00021))
        Me.grpSearch = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btnExporttoExcel = New System.Windows.Forms.Button
        Me.cmdShow = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.optResult_Ass = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.optItmTyp_ASS = New System.Windows.Forms.RadioButton
        Me.Label15 = New System.Windows.Forms.Label
        Me.optItmTyp_REG = New System.Windows.Forms.RadioButton
        Me.optItmTyp_BOM = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdItemList = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtItemList = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.grpSearch.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpSearch
        '
        Me.grpSearch.Controls.Add(Me.GroupBox3)
        Me.grpSearch.Controls.Add(Me.GroupBox2)
        Me.grpSearch.Controls.Add(Me.GroupBox1)
        Me.grpSearch.Location = New System.Drawing.Point(12, 37)
        Me.grpSearch.Name = "grpSearch"
        Me.grpSearch.Size = New System.Drawing.Size(616, 237)
        Me.grpSearch.TabIndex = 4
        Me.grpSearch.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnExporttoExcel)
        Me.GroupBox3.Controls.Add(Me.cmdShow)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.optResult_Ass)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 159)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(592, 63)
        Me.GroupBox3.TabIndex = 34
        Me.GroupBox3.TabStop = False
        '
        'btnExporttoExcel
        '
        Me.btnExporttoExcel.Location = New System.Drawing.Point(307, 21)
        Me.btnExporttoExcel.Name = "btnExporttoExcel"
        Me.btnExporttoExcel.Size = New System.Drawing.Size(95, 25)
        Me.btnExporttoExcel.TabIndex = 7
        Me.btnExporttoExcel.Text = "&Export to excel"
        Me.btnExporttoExcel.UseVisualStyleBackColor = True
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(196, 21)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(95, 25)
        Me.cmdShow.TabIndex = 5
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(35, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 12)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Result Item Type : "
        Me.Label2.Visible = False
        '
        'optResult_Ass
        '
        Me.optResult_Ass.AutoSize = True
        Me.optResult_Ass.Enabled = False
        Me.optResult_Ass.Location = New System.Drawing.Point(156, 30)
        Me.optResult_Ass.Name = "optResult_Ass"
        Me.optResult_Ass.Size = New System.Drawing.Size(75, 16)
        Me.optResult_Ass.TabIndex = 6
        Me.optResult_Ass.Text = "Assortment"
        Me.optResult_Ass.UseVisualStyleBackColor = True
        Me.optResult_Ass.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.optItmTyp_ASS)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.optItmTyp_REG)
        Me.GroupBox2.Controls.Add(Me.optItmTyp_BOM)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 90)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(592, 63)
        Me.GroupBox2.TabIndex = 33
        Me.GroupBox2.TabStop = False
        '
        'optItmTyp_ASS
        '
        Me.optItmTyp_ASS.AutoSize = True
        Me.optItmTyp_ASS.Location = New System.Drawing.Point(340, 30)
        Me.optItmTyp_ASS.Name = "optItmTyp_ASS"
        Me.optItmTyp_ASS.Size = New System.Drawing.Size(43, 16)
        Me.optItmTyp_ASS.TabIndex = 4
        Me.optItmTyp_ASS.Text = "ASS"
        Me.optItmTyp_ASS.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(36, 30)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(53, 12)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "Item Type"
        '
        'optItmTyp_REG
        '
        Me.optItmTyp_REG.AutoSize = True
        Me.optItmTyp_REG.Location = New System.Drawing.Point(246, 30)
        Me.optItmTyp_REG.Name = "optItmTyp_REG"
        Me.optItmTyp_REG.Size = New System.Drawing.Size(46, 16)
        Me.optItmTyp_REG.TabIndex = 3
        Me.optItmTyp_REG.Text = "REG"
        Me.optItmTyp_REG.UseVisualStyleBackColor = True
        '
        'optItmTyp_BOM
        '
        Me.optItmTyp_BOM.AutoSize = True
        Me.optItmTyp_BOM.Checked = True
        Me.optItmTyp_BOM.Location = New System.Drawing.Point(156, 30)
        Me.optItmTyp_BOM.Name = "optItmTyp_BOM"
        Me.optItmTyp_BOM.Size = New System.Drawing.Size(49, 16)
        Me.optItmTyp_BOM.TabIndex = 6
        Me.optItmTyp_BOM.TabStop = True
        Me.optItmTyp_BOM.Text = "BOM"
        Me.optItmTyp_BOM.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdItemList)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtItemList)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 18)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(592, 66)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Item List"
        '
        'cmdItemList
        '
        Me.cmdItemList.Location = New System.Drawing.Point(539, 18)
        Me.cmdItemList.Name = "cmdItemList"
        Me.cmdItemList.Size = New System.Drawing.Size(45, 18)
        Me.cmdItemList.TabIndex = 2
        Me.cmdItemList.Text = " ... "
        Me.cmdItemList.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(70, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(201, 12)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "(Separate each item by comma sign  "" , "" )"
        '
        'txtItemList
        '
        Me.txtItemList.BackColor = System.Drawing.Color.White
        Me.txtItemList.Location = New System.Drawing.Point(73, 18)
        Me.txtItemList.Name = "txtItemList"
        Me.txtItemList.Size = New System.Drawing.Size(452, 22)
        Me.txtItemList.TabIndex = 1
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Blue
        Me.Label23.Location = New System.Drawing.Point(215, 9)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(183, 25)
        Me.Label23.TabIndex = 20
        Me.Label23.Text = "Assorted Item List"
        '
        'IMR00021
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 294)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.grpSearch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "IMR00021"
        Me.Text = "IMR00021 - Assorted Item List (IMR21)"
        Me.grpSearch.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpSearch As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents optItmTyp_BOM As System.Windows.Forms.RadioButton
    Friend WithEvents optItmTyp_REG As System.Windows.Forms.RadioButton
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents txtItemList As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdItemList As System.Windows.Forms.Button
    Friend WithEvents optItmTyp_ASS As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents optResult_Ass As System.Windows.Forms.RadioButton
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents btnExporttoExcel As System.Windows.Forms.Button
End Class
