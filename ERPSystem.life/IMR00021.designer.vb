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
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
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
        Me.grpSearch.Location = New System.Drawing.Point(12, 64)
        Me.grpSearch.Name = "grpSearch"
        Me.grpSearch.Size = New System.Drawing.Size(616, 257)
        Me.grpSearch.TabIndex = 4
        Me.grpSearch.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnExporttoExcel)
        Me.GroupBox3.Controls.Add(Me.cmdShow)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.optResult_Ass)
        Me.GroupBox3.Location = New System.Drawing.Point(18, 172)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(598, 68)
        Me.GroupBox3.TabIndex = 34
        Me.GroupBox3.TabStop = False
        '
        'btnExporttoExcel
        '
        Me.btnExporttoExcel.Location = New System.Drawing.Point(307, 23)
        Me.btnExporttoExcel.Name = "btnExporttoExcel"
        Me.btnExporttoExcel.Size = New System.Drawing.Size(95, 27)
        Me.btnExporttoExcel.TabIndex = 7
        Me.btnExporttoExcel.Text = "&Export to excel"
        Me.btnExporttoExcel.UseVisualStyleBackColor = True
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(196, 23)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(95, 27)
        Me.cmdShow.TabIndex = 5
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(35, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Result Item Type : "
        Me.Label2.Visible = False
        '
        'optResult_Ass
        '
        Me.optResult_Ass.AutoSize = True
        Me.optResult_Ass.Enabled = False
        Me.optResult_Ass.Location = New System.Drawing.Point(156, 33)
        Me.optResult_Ass.Name = "optResult_Ass"
        Me.optResult_Ass.Size = New System.Drawing.Size(77, 17)
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
        Me.GroupBox2.Location = New System.Drawing.Point(17, 98)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(598, 68)
        Me.GroupBox2.TabIndex = 33
        Me.GroupBox2.TabStop = False
        '
        'optItmTyp_ASS
        '
        Me.optItmTyp_ASS.AutoSize = True
        Me.optItmTyp_ASS.Location = New System.Drawing.Point(340, 34)
        Me.optItmTyp_ASS.Name = "optItmTyp_ASS"
        Me.optItmTyp_ASS.Size = New System.Drawing.Size(46, 17)
        Me.optItmTyp_ASS.TabIndex = 4
        Me.optItmTyp_ASS.Text = "ASS"
        Me.optItmTyp_ASS.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(35, 36)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(63, 13)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "Item Type : "
        '
        'optItmTyp_REG
        '
        Me.optItmTyp_REG.AutoSize = True
        Me.optItmTyp_REG.Location = New System.Drawing.Point(234, 33)
        Me.optItmTyp_REG.Name = "optItmTyp_REG"
        Me.optItmTyp_REG.Size = New System.Drawing.Size(48, 17)
        Me.optItmTyp_REG.TabIndex = 3
        Me.optItmTyp_REG.Text = "REG"
        Me.optItmTyp_REG.UseVisualStyleBackColor = True
        '
        'optItmTyp_BOM
        '
        Me.optItmTyp_BOM.AutoSize = True
        Me.optItmTyp_BOM.Checked = True
        Me.optItmTyp_BOM.Location = New System.Drawing.Point(156, 33)
        Me.optItmTyp_BOM.Name = "optItmTyp_BOM"
        Me.optItmTyp_BOM.Size = New System.Drawing.Size(49, 17)
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
        Me.GroupBox1.Location = New System.Drawing.Point(12, 20)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(604, 72)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Item List"
        '
        'cmdItemList
        '
        Me.cmdItemList.Location = New System.Drawing.Point(539, 20)
        Me.cmdItemList.Name = "cmdItemList"
        Me.cmdItemList.Size = New System.Drawing.Size(45, 20)
        Me.cmdItemList.TabIndex = 2
        Me.cmdItemList.Text = " ... "
        Me.cmdItemList.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(70, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(206, 13)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "(Separate each item by comma sign  "" , "" )"
        '
        'txtItemList
        '
        Me.txtItemList.BackColor = System.Drawing.Color.SkyBlue
        Me.txtItemList.Location = New System.Drawing.Point(73, 20)
        Me.txtItemList.Name = "txtItemList"
        Me.txtItemList.Size = New System.Drawing.Size(452, 20)
        Me.txtItemList.TabIndex = 1
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label23.Location = New System.Drawing.Point(200, 9)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(183, 25)
        Me.Label23.TabIndex = 20
        Me.Label23.Text = "Assorted Item List"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(9, 21)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(61, 13)
        Me.Label24.TabIndex = 22
        Me.Label24.Text = "MSR00021"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(-30, 34)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(745, 13)
        Me.Label25.TabIndex = 23
        Me.Label25.Text = "_________________________________________________________________________________" & _
            "__________________________________________"
        '
        'IMR00021
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(672, 356)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.grpSearch)
        Me.Name = "IMR00021"
        Me.Text = "IMR00021 - Assorted Item List"
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
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents btnExporttoExcel As System.Windows.Forms.Button
End Class
