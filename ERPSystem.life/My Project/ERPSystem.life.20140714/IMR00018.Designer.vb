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
        Me.GrpRecSts = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkRecStsO = New System.Windows.Forms.CheckBox
        Me.chkRecStsW = New System.Windows.Forms.CheckBox
        Me.chkRecStsI = New System.Windows.Forms.CheckBox
        Me.chkRecStsR = New System.Windows.Forms.CheckBox
        Me.chkRecStsA = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtToVenNc = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtFromVenNc = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.dtpToTrand = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtpFromTrand = New System.Windows.Forms.DateTimePicker
        Me.cmdShow = New System.Windows.Forms.Button
        Me.cmdExcel = New System.Windows.Forms.Button
        Me.GrpRecSts.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpRecSts
        '
        Me.GrpRecSts.Controls.Add(Me.Label1)
        Me.GrpRecSts.Controls.Add(Me.chkRecStsO)
        Me.GrpRecSts.Controls.Add(Me.chkRecStsW)
        Me.GrpRecSts.Controls.Add(Me.chkRecStsI)
        Me.GrpRecSts.Controls.Add(Me.chkRecStsR)
        Me.GrpRecSts.Controls.Add(Me.chkRecStsA)
        Me.GrpRecSts.Location = New System.Drawing.Point(13, 13)
        Me.GrpRecSts.Name = "GrpRecSts"
        Me.GrpRecSts.Size = New System.Drawing.Size(375, 95)
        Me.GrpRecSts.TabIndex = 0
        Me.GrpRecSts.TabStop = False
        Me.GrpRecSts.Text = "Record Status"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(56, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Show"
        '
        'chkRecStsO
        '
        Me.chkRecStsO.AutoSize = True
        Me.chkRecStsO.Location = New System.Drawing.Point(132, 67)
        Me.chkRecStsO.Name = "chkRecStsO"
        Me.chkRecStsO.Size = New System.Drawing.Size(66, 17)
        Me.chkRecStsO.TabIndex = 4
        Me.chkRecStsO.Text = "Override"
        Me.chkRecStsO.UseVisualStyleBackColor = True
        '
        'chkRecStsW
        '
        Me.chkRecStsW.AutoSize = True
        Me.chkRecStsW.Location = New System.Drawing.Point(249, 43)
        Me.chkRecStsW.Name = "chkRecStsW"
        Me.chkRecStsW.Size = New System.Drawing.Size(62, 17)
        Me.chkRecStsW.TabIndex = 3
        Me.chkRecStsW.Text = "Waiting"
        Me.chkRecStsW.UseVisualStyleBackColor = True
        '
        'chkRecStsI
        '
        Me.chkRecStsI.AutoSize = True
        Me.chkRecStsI.Location = New System.Drawing.Point(132, 43)
        Me.chkRecStsI.Name = "chkRecStsI"
        Me.chkRecStsI.Size = New System.Drawing.Size(57, 17)
        Me.chkRecStsI.TabIndex = 2
        Me.chkRecStsI.Text = "Invalid"
        Me.chkRecStsI.UseVisualStyleBackColor = True
        '
        'chkRecStsR
        '
        Me.chkRecStsR.AutoSize = True
        Me.chkRecStsR.Location = New System.Drawing.Point(249, 19)
        Me.chkRecStsR.Name = "chkRecStsR"
        Me.chkRecStsR.Size = New System.Drawing.Size(69, 17)
        Me.chkRecStsR.TabIndex = 1
        Me.chkRecStsR.Text = "Rejected"
        Me.chkRecStsR.UseVisualStyleBackColor = True
        '
        'chkRecStsA
        '
        Me.chkRecStsA.AutoSize = True
        Me.chkRecStsA.Location = New System.Drawing.Point(132, 19)
        Me.chkRecStsA.Name = "chkRecStsA"
        Me.chkRecStsA.Size = New System.Drawing.Size(72, 17)
        Me.chkRecStsA.TabIndex = 0
        Me.chkRecStsA.Text = "Approved"
        Me.chkRecStsA.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtToVenNc)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtFromVenNc)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 115)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(375, 58)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Vender No."
        '
        'txtToVenNc
        '
        Me.txtToVenNc.Location = New System.Drawing.Point(249, 23)
        Me.txtToVenNc.Name = "txtToVenNc"
        Me.txtToVenNc.Size = New System.Drawing.Size(90, 20)
        Me.txtToVenNc.TabIndex = 3
        Me.txtToVenNc.Text = "9999"
        Me.txtToVenNc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(195, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "To"
        '
        'txtFromVenNc
        '
        Me.txtFromVenNc.Location = New System.Drawing.Point(69, 23)
        Me.txtFromVenNc.Name = "txtFromVenNc"
        Me.txtFromVenNc.Size = New System.Drawing.Size(90, 20)
        Me.txtFromVenNc.TabIndex = 1
        Me.txtFromVenNc.Text = "0001"
        Me.txtFromVenNc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "From"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.dtpToTrand)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.dtpFromTrand)
        Me.GroupBox3.Location = New System.Drawing.Point(13, 180)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(375, 81)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Transaction Date"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(250, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "MM/DD/YYYY"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(195, 33)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(20, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "To"
        '
        'dtpToTrand
        '
        Me.dtpToTrand.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToTrand.Location = New System.Drawing.Point(249, 29)
        Me.dtpToTrand.Name = "dtpToTrand"
        Me.dtpToTrand.Size = New System.Drawing.Size(90, 20)
        Me.dtpToTrand.TabIndex = 3
        Me.dtpToTrand.Value = New Date(2012, 5, 29, 0, 0, 0, 0)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(70, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "MM/DD/YYYY"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(25, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "From"
        '
        'dtpFromTrand
        '
        Me.dtpFromTrand.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFromTrand.Location = New System.Drawing.Point(69, 29)
        Me.dtpFromTrand.Name = "dtpFromTrand"
        Me.dtpFromTrand.Size = New System.Drawing.Size(95, 20)
        Me.dtpFromTrand.TabIndex = 0
        Me.dtpFromTrand.Value = New Date(2012, 5, 29, 0, 0, 0, 0)
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(80, 271)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(110, 30)
        Me.cmdShow.TabIndex = 3
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'cmdExcel
        '
        Me.cmdExcel.Location = New System.Drawing.Point(211, 271)
        Me.cmdExcel.Name = "cmdExcel"
        Me.cmdExcel.Size = New System.Drawing.Size(110, 30)
        Me.cmdExcel.TabIndex = 4
        Me.cmdExcel.Text = "Export to E&xcel"
        Me.cmdExcel.UseVisualStyleBackColor = True
        '
        'IMR00018
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(400, 313)
        Me.Controls.Add(Me.cmdExcel)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GrpRecSts)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "IMR00018"
        Me.Text = "IMR0018 - Item Validation Report (External Item)"
        Me.GrpRecSts.ResumeLayout(False)
        Me.GrpRecSts.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpRecSts As System.Windows.Forms.GroupBox
    Friend WithEvents chkRecStsI As System.Windows.Forms.CheckBox
    Friend WithEvents chkRecStsR As System.Windows.Forms.CheckBox
    Friend WithEvents chkRecStsA As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkRecStsO As System.Windows.Forms.CheckBox
    Friend WithEvents chkRecStsW As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFromVenNc As System.Windows.Forms.TextBox
    Friend WithEvents txtToVenNc As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFromTrand As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpToTrand As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents cmdExcel As System.Windows.Forms.Button
End Class
