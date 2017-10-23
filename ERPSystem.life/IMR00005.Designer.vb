<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IMR00005
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IMR00005))
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.dtpToTrand = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtpFromTrand = New System.Windows.Forms.DateTimePicker
        Me.txtToItmno = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtFromItmno = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt_S_SecCustAll = New System.Windows.Forms.TextBox
        Me.cmd_S_SecCustAll = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.txt_S_PriCustAll = New System.Windows.Forms.TextBox
        Me.cmd_S_PriCustAll = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmdShowExcel = New System.Windows.Forms.Button
        Me.cmdShow = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(437, 199)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 12)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "MM/DD/YYYY"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(380, 178)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(18, 12)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "To"
        '
        'dtpToTrand
        '
        Me.dtpToTrand.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToTrand.Location = New System.Drawing.Point(436, 175)
        Me.dtpToTrand.Name = "dtpToTrand"
        Me.dtpToTrand.Size = New System.Drawing.Size(90, 22)
        Me.dtpToTrand.TabIndex = 8
        Me.dtpToTrand.Value = New Date(2012, 5, 29, 0, 0, 0, 0)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(183, 199)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 12)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "MM/DD/YYYY"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(138, 178)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 12)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "From"
        '
        'dtpFromTrand
        '
        Me.dtpFromTrand.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFromTrand.Location = New System.Drawing.Point(182, 175)
        Me.dtpFromTrand.Name = "dtpFromTrand"
        Me.dtpFromTrand.Size = New System.Drawing.Size(95, 22)
        Me.dtpFromTrand.TabIndex = 7
        Me.dtpFromTrand.Value = New Date(2012, 5, 29, 0, 0, 0, 0)
        '
        'txtToItmno
        '
        Me.txtToItmno.Location = New System.Drawing.Point(436, 28)
        Me.txtToItmno.MaxLength = 20
        Me.txtToItmno.Name = "txtToItmno"
        Me.txtToItmno.Size = New System.Drawing.Size(124, 22)
        Me.txtToItmno.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(380, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(18, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "To"
        '
        'txtFromItmno
        '
        Me.txtFromItmno.Location = New System.Drawing.Point(182, 28)
        Me.txtFromItmno.MaxLength = 20
        Me.txtFromItmno.Name = "txtFromItmno"
        Me.txtFromItmno.Size = New System.Drawing.Size(124, 22)
        Me.txtFromItmno.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(138, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 12)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "From"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 178)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 12)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Transaction Date"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(17, 31)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 12)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Item No."
        '
        'txt_S_SecCustAll
        '
        Me.txt_S_SecCustAll.Location = New System.Drawing.Point(182, 122)
        Me.txt_S_SecCustAll.Name = "txt_S_SecCustAll"
        Me.txt_S_SecCustAll.Size = New System.Drawing.Size(378, 22)
        Me.txt_S_SecCustAll.TabIndex = 6
        '
        'cmd_S_SecCustAll
        '
        Me.cmd_S_SecCustAll.Location = New System.Drawing.Point(125, 122)
        Me.cmd_S_SecCustAll.Name = "cmd_S_SecCustAll"
        Me.cmd_S_SecCustAll.Size = New System.Drawing.Size(45, 22)
        Me.cmd_S_SecCustAll.TabIndex = 5
        Me.cmd_S_SecCustAll.Text = "＞＞"
        Me.cmd_S_SecCustAll.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(17, 125)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 12)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Sec. Cust."
        '
        'txt_S_PriCustAll
        '
        Me.txt_S_PriCustAll.Location = New System.Drawing.Point(182, 71)
        Me.txt_S_PriCustAll.Name = "txt_S_PriCustAll"
        Me.txt_S_PriCustAll.Size = New System.Drawing.Size(378, 22)
        Me.txt_S_PriCustAll.TabIndex = 4
        '
        'cmd_S_PriCustAll
        '
        Me.cmd_S_PriCustAll.Location = New System.Drawing.Point(125, 71)
        Me.cmd_S_PriCustAll.Name = "cmd_S_PriCustAll"
        Me.cmd_S_PriCustAll.Size = New System.Drawing.Size(45, 22)
        Me.cmd_S_PriCustAll.TabIndex = 3
        Me.cmd_S_PriCustAll.Text = "＞＞"
        Me.cmd_S_PriCustAll.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(17, 74)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 12)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Pri. Cust."
        '
        'cmdShowExcel
        '
        Me.cmdShowExcel.Location = New System.Drawing.Point(270, 246)
        Me.cmdShowExcel.Name = "cmdShowExcel"
        Me.cmdShowExcel.Size = New System.Drawing.Size(140, 22)
        Me.cmdShowExcel.TabIndex = 10
        Me.cmdShowExcel.Text = "&Show Report (excel)"
        Me.cmdShowExcel.UseVisualStyleBackColor = True
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(12, 228)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(140, 40)
        Me.cmdShow.TabIndex = 9
        Me.cmdShow.Text = "Show Report (PDF) (invisible)"
        Me.cmdShow.UseVisualStyleBackColor = True
        Me.cmdShow.Visible = False
        '
        'IMR00005
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 271)
        Me.Controls.Add(Me.cmdShowExcel)
        Me.Controls.Add(Me.txt_S_SecCustAll)
        Me.Controls.Add(Me.cmd_S_SecCustAll)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txt_S_PriCustAll)
        Me.Controls.Add(Me.cmd_S_PriCustAll)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtToItmno)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtFromItmno)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.dtpToTrand)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtpFromTrand)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "IMR00005"
        Me.Text = "IMR00005 - Excel File Search Report (Internal & Joint Venture Item) (IMR05)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpToTrand As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpFromTrand As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtToItmno As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFromItmno As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_S_SecCustAll As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_SecCustAll As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_S_PriCustAll As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_PriCustAll As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmdShowExcel As System.Windows.Forms.Button
    Friend WithEvents cmdShow As System.Windows.Forms.Button
End Class
