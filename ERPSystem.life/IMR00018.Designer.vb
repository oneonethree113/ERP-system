<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IMR00018
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IMR00018))
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkRecStsO = New System.Windows.Forms.CheckBox
        Me.chkRecStsW = New System.Windows.Forms.CheckBox
        Me.chkRecStsI = New System.Windows.Forms.CheckBox
        Me.chkRecStsR = New System.Windows.Forms.CheckBox
        Me.chkRecStsA = New System.Windows.Forms.CheckBox
        Me.txtToVenNc = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtFromVenNc = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.dtpToTrand = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtpFromTrand = New System.Windows.Forms.DateTimePicker
        Me.cmdShow = New System.Windows.Forms.Button
        Me.cmdExcel = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(62, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 12)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Record Status"
        '
        'chkRecStsO
        '
        Me.chkRecStsO.AutoSize = True
        Me.chkRecStsO.Location = New System.Drawing.Point(216, 77)
        Me.chkRecStsO.Name = "chkRecStsO"
        Me.chkRecStsO.Size = New System.Drawing.Size(65, 16)
        Me.chkRecStsO.TabIndex = 4
        Me.chkRecStsO.Text = "Override"
        Me.chkRecStsO.UseVisualStyleBackColor = True
        '
        'chkRecStsW
        '
        Me.chkRecStsW.AutoSize = True
        Me.chkRecStsW.Location = New System.Drawing.Point(423, 53)
        Me.chkRecStsW.Name = "chkRecStsW"
        Me.chkRecStsW.Size = New System.Drawing.Size(61, 16)
        Me.chkRecStsW.TabIndex = 3
        Me.chkRecStsW.Text = "Waiting"
        Me.chkRecStsW.UseVisualStyleBackColor = True
        '
        'chkRecStsI
        '
        Me.chkRecStsI.AutoSize = True
        Me.chkRecStsI.Location = New System.Drawing.Point(216, 53)
        Me.chkRecStsI.Name = "chkRecStsI"
        Me.chkRecStsI.Size = New System.Drawing.Size(57, 16)
        Me.chkRecStsI.TabIndex = 2
        Me.chkRecStsI.Text = "Invalid"
        Me.chkRecStsI.UseVisualStyleBackColor = True
        '
        'chkRecStsR
        '
        Me.chkRecStsR.AutoSize = True
        Me.chkRecStsR.Location = New System.Drawing.Point(423, 29)
        Me.chkRecStsR.Name = "chkRecStsR"
        Me.chkRecStsR.Size = New System.Drawing.Size(64, 16)
        Me.chkRecStsR.TabIndex = 1
        Me.chkRecStsR.Text = "Rejected"
        Me.chkRecStsR.UseVisualStyleBackColor = True
        '
        'chkRecStsA
        '
        Me.chkRecStsA.AutoSize = True
        Me.chkRecStsA.Location = New System.Drawing.Point(216, 29)
        Me.chkRecStsA.Name = "chkRecStsA"
        Me.chkRecStsA.Size = New System.Drawing.Size(71, 16)
        Me.chkRecStsA.TabIndex = 0
        Me.chkRecStsA.Text = "Approved"
        Me.chkRecStsA.UseVisualStyleBackColor = True
        '
        'txtToVenNc
        '
        Me.txtToVenNc.Location = New System.Drawing.Point(480, 119)
        Me.txtToVenNc.Name = "txtToVenNc"
        Me.txtToVenNc.Size = New System.Drawing.Size(95, 22)
        Me.txtToVenNc.TabIndex = 3
        Me.txtToVenNc.Text = "9999"
        Me.txtToVenNc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(421, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(18, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "To"
        '
        'txtFromVenNc
        '
        Me.txtFromVenNc.Location = New System.Drawing.Point(258, 119)
        Me.txtFromVenNc.Name = "txtFromVenNc"
        Me.txtFromVenNc.Size = New System.Drawing.Size(95, 22)
        Me.txtFromVenNc.TabIndex = 1
        Me.txtFromVenNc.Text = "0001"
        Me.txtFromVenNc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(214, 122)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 12)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "From"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(481, 189)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 12)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "MM/DD/YYYY"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(421, 171)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(18, 12)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "To"
        '
        'dtpToTrand
        '
        Me.dtpToTrand.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToTrand.Location = New System.Drawing.Point(480, 167)
        Me.dtpToTrand.Name = "dtpToTrand"
        Me.dtpToTrand.Size = New System.Drawing.Size(95, 22)
        Me.dtpToTrand.TabIndex = 3
        Me.dtpToTrand.Value = New Date(2012, 5, 29, 0, 0, 0, 0)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(259, 189)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 12)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "MM/DD/YYYY"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(214, 171)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 12)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "From"
        '
        'dtpFromTrand
        '
        Me.dtpFromTrand.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFromTrand.Location = New System.Drawing.Point(258, 167)
        Me.dtpFromTrand.Name = "dtpFromTrand"
        Me.dtpFromTrand.Size = New System.Drawing.Size(95, 22)
        Me.dtpFromTrand.TabIndex = 0
        Me.dtpFromTrand.Value = New Date(2012, 5, 29, 0, 0, 0, 0)
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(164, 222)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(140, 22)
        Me.cmdShow.TabIndex = 3
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'cmdExcel
        '
        Me.cmdExcel.Location = New System.Drawing.Point(344, 222)
        Me.cmdExcel.Name = "cmdExcel"
        Me.cmdExcel.Size = New System.Drawing.Size(140, 22)
        Me.cmdExcel.TabIndex = 4
        Me.cmdExcel.Text = "Export to E&xcel"
        Me.cmdExcel.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(62, 171)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 12)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Transaction Date"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(62, 122)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 12)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "Vender No."
        '
        'IMR00018
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(634, 271)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkRecStsO)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.chkRecStsW)
        Me.Controls.Add(Me.txtToVenNc)
        Me.Controls.Add(Me.chkRecStsI)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.chkRecStsR)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.chkRecStsA)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtFromVenNc)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdExcel)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.dtpToTrand)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtpFromTrand)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "IMR00018"
        Me.Text = "IMR0018 - Item Validation Report (External Item) (IMR18)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkRecStsI As System.Windows.Forms.CheckBox
    Friend WithEvents chkRecStsR As System.Windows.Forms.CheckBox
    Friend WithEvents chkRecStsA As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkRecStsO As System.Windows.Forms.CheckBox
    Friend WithEvents chkRecStsW As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFromVenNc As System.Windows.Forms.TextBox
    Friend WithEvents txtToVenNc As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpFromTrand As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpToTrand As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents cmdExcel As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
