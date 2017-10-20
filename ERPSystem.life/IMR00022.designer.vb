<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IMR00022
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IMR00022))
        Me.grpSearch = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.cboCustNoFm = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboCustNoTo = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmdItemLstCust = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtCustAls = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdItemList = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtItemList = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.optItm = New System.Windows.Forms.RadioButton
        Me.optCust = New System.Windows.Forms.RadioButton
        Me.cmdShow = New System.Windows.Forms.Button
        Me.optAls = New System.Windows.Forms.RadioButton
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.grpSearch.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpSearch
        '
        Me.grpSearch.Controls.Add(Me.GroupBox4)
        Me.grpSearch.Controls.Add(Me.GroupBox2)
        Me.grpSearch.Controls.Add(Me.GroupBox1)
        Me.grpSearch.Location = New System.Drawing.Point(12, 11)
        Me.grpSearch.Name = "grpSearch"
        Me.grpSearch.Size = New System.Drawing.Size(616, 233)
        Me.grpSearch.TabIndex = 4
        Me.grpSearch.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cboCustNoFm)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.cboCustNoTo)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Location = New System.Drawing.Point(16, 13)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(591, 59)
        Me.GroupBox4.TabIndex = 34
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Primary Customer No."
        '
        'cboCustNoFm
        '
        Me.cboCustNoFm.FormattingEnabled = True
        Me.cboCustNoFm.Location = New System.Drawing.Point(73, 22)
        Me.cboCustNoFm.Name = "cboCustNoFm"
        Me.cboCustNoFm.Size = New System.Drawing.Size(187, 20)
        Me.cboCustNoFm.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(31, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 12)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "From"
        '
        'cboCustNoTo
        '
        Me.cboCustNoTo.FormattingEnabled = True
        Me.cboCustNoTo.Location = New System.Drawing.Point(322, 22)
        Me.cboCustNoTo.Name = "cboCustNoTo"
        Me.cboCustNoTo.Size = New System.Drawing.Size(187, 20)
        Me.cboCustNoTo.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(292, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(18, 12)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "To"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdItemLstCust)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtCustAls)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 149)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(591, 66)
        Me.GroupBox2.TabIndex = 33
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Customer Alias Item"
        '
        'cmdItemLstCust
        '
        Me.cmdItemLstCust.Location = New System.Drawing.Point(539, 18)
        Me.cmdItemLstCust.Name = "cmdItemLstCust"
        Me.cmdItemLstCust.Size = New System.Drawing.Size(45, 18)
        Me.cmdItemLstCust.TabIndex = 6
        Me.cmdItemLstCust.Text = " ... "
        Me.cmdItemLstCust.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(70, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(201, 12)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "(Separate each item by comma sign  "" , "" )"
        '
        'txtCustAls
        '
        Me.txtCustAls.BackColor = System.Drawing.Color.White
        Me.txtCustAls.Location = New System.Drawing.Point(73, 18)
        Me.txtCustAls.Name = "txtCustAls"
        Me.txtCustAls.Size = New System.Drawing.Size(452, 22)
        Me.txtCustAls.TabIndex = 5
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdItemList)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtItemList)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 78)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(591, 66)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Item List"
        '
        'cmdItemList
        '
        Me.cmdItemList.Location = New System.Drawing.Point(539, 18)
        Me.cmdItemList.Name = "cmdItemList"
        Me.cmdItemList.Size = New System.Drawing.Size(45, 18)
        Me.cmdItemList.TabIndex = 4
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
        Me.txtItemList.TabIndex = 3
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(99, 19)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(44, 12)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "Sort By:"
        '
        'optItm
        '
        Me.optItm.AutoSize = True
        Me.optItm.Checked = True
        Me.optItm.Location = New System.Drawing.Point(178, 18)
        Me.optItm.Name = "optItm"
        Me.optItm.Size = New System.Drawing.Size(44, 16)
        Me.optItm.TabIndex = 7
        Me.optItm.TabStop = True
        Me.optItm.Text = "Item"
        Me.optItm.UseVisualStyleBackColor = True
        '
        'optCust
        '
        Me.optCust.AutoSize = True
        Me.optCust.Location = New System.Drawing.Point(259, 18)
        Me.optCust.Name = "optCust"
        Me.optCust.Size = New System.Drawing.Size(68, 16)
        Me.optCust.TabIndex = 8
        Me.optCust.Text = "Customer"
        Me.optCust.UseVisualStyleBackColor = True
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(266, 331)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(121, 25)
        Me.cmdShow.TabIndex = 10
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'optAls
        '
        Me.optAls.AutoSize = True
        Me.optAls.Location = New System.Drawing.Point(354, 18)
        Me.optAls.Name = "optAls"
        Me.optAls.Size = New System.Drawing.Size(97, 16)
        Me.optAls.TabIndex = 9
        Me.optAls.Text = "Cust. Alias Item"
        Me.optAls.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.optItm)
        Me.GroupBox3.Controls.Add(Me.optAls)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.optCust)
        Me.GroupBox3.Location = New System.Drawing.Point(14, 254)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(614, 56)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(14, 331)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(205, 12)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "Primary Customer, Item List and Customer"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(14, 350)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(163, 12)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Alias Item are in [AND] operation"
        '
        'IMR00022
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 402)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.grpSearch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "IMR00022"
        Me.Text = "IMR00022 - Customer Alias Item List (Sales use) (IMR32)"
        Me.grpSearch.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpSearch As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents optItm As System.Windows.Forms.RadioButton
    Friend WithEvents optCust As System.Windows.Forms.RadioButton
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents cboCustNoTo As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboCustNoFm As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtItemList As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdItemLstCust As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCustAls As System.Windows.Forms.TextBox
    Friend WithEvents cmdItemList As System.Windows.Forms.Button
    Friend WithEvents optAls As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
End Class
