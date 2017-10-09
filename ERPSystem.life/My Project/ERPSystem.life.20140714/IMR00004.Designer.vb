<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IMR00004
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
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.dtpToTrand = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtpFromTrand = New System.Windows.Forms.DateTimePicker
        Me.GrpRecSts = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkRecStsO = New System.Windows.Forms.CheckBox
        Me.chkRecStsW = New System.Windows.Forms.CheckBox
        Me.chkRecStsI = New System.Windows.Forms.CheckBox
        Me.chkRecStsR = New System.Windows.Forms.CheckBox
        Me.chkRecStsA = New System.Windows.Forms.CheckBox
        Me.txtToVenNc = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtFromVenNc = New System.Windows.Forms.TextBox
        Me.cmdShow = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmdExcel = New System.Windows.Forms.Button
        Me.chkBOM = New System.Windows.Forms.CheckBox
        Me.GroupBox3.SuspendLayout()
        Me.GrpRecSts.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
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
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.dtpToTrand)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.dtpFromTrand)
        Me.GroupBox3.Location = New System.Drawing.Point(66, 179)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(375, 81)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Transaction Date"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(190, 33)
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
        Me.dtpFromTrand.Size = New System.Drawing.Size(90, 20)
        Me.dtpFromTrand.TabIndex = 0
        Me.dtpFromTrand.Value = New Date(2012, 5, 29, 0, 0, 0, 0)
        '
        'GrpRecSts
        '
        Me.GrpRecSts.Controls.Add(Me.chkBOM)
        Me.GrpRecSts.Controls.Add(Me.Label1)
        Me.GrpRecSts.Controls.Add(Me.chkRecStsO)
        Me.GrpRecSts.Controls.Add(Me.chkRecStsW)
        Me.GrpRecSts.Controls.Add(Me.chkRecStsI)
        Me.GrpRecSts.Controls.Add(Me.chkRecStsR)
        Me.GrpRecSts.Controls.Add(Me.chkRecStsA)
        Me.GrpRecSts.Location = New System.Drawing.Point(66, 12)
        Me.GrpRecSts.Name = "GrpRecSts"
        Me.GrpRecSts.Size = New System.Drawing.Size(375, 95)
        Me.GrpRecSts.TabIndex = 4
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
        'txtToVenNc
        '
        Me.txtToVenNc.Location = New System.Drawing.Point(249, 23)
        Me.txtToVenNc.Name = "txtToVenNc"
        Me.txtToVenNc.Size = New System.Drawing.Size(90, 20)
        Me.txtToVenNc.TabIndex = 3
        Me.txtToVenNc.Text = "Z"
        Me.txtToVenNc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(190, 26)
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
        Me.txtFromVenNc.Text = "A"
        Me.txtFromVenNc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(110, 270)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(110, 30)
        Me.cmdShow.TabIndex = 7
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtToVenNc)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtFromVenNc)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(66, 114)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(375, 58)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Vender No."
        '
        'cmdExcel
        '
        Me.cmdExcel.Location = New System.Drawing.Point(290, 270)
        Me.cmdExcel.Name = "cmdExcel"
        Me.cmdExcel.Size = New System.Drawing.Size(110, 30)
        Me.cmdExcel.TabIndex = 8
        Me.cmdExcel.Text = "Export to E&xcel"
        Me.cmdExcel.UseVisualStyleBackColor = True
        '
        'chkBOM
        '
        Me.chkBOM.AutoSize = True
        Me.chkBOM.Location = New System.Drawing.Point(249, 67)
        Me.chkBOM.Name = "chkBOM"
        Me.chkBOM.Size = New System.Drawing.Size(116, 17)
        Me.chkBOM.TabIndex = 6
        Me.chkBOM.Text = "Include BOM Items"
        Me.chkBOM.UseVisualStyleBackColor = True
        '
        'IMR00004
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(506, 311)
        Me.Controls.Add(Me.cmdExcel)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GrpRecSts)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "IMR00004"
        Me.Text = "IMR00004 - Item Validation Report (Internal & Joint Venture Item)"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GrpRecSts.ResumeLayout(False)
        Me.GrpRecSts.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpToTrand As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpFromTrand As System.Windows.Forms.DateTimePicker
    Friend WithEvents GrpRecSts As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkRecStsO As System.Windows.Forms.CheckBox
    Friend WithEvents chkRecStsW As System.Windows.Forms.CheckBox
    Friend WithEvents chkRecStsI As System.Windows.Forms.CheckBox
    Friend WithEvents chkRecStsR As System.Windows.Forms.CheckBox
    Friend WithEvents chkRecStsA As System.Windows.Forms.CheckBox
    Friend WithEvents txtToVenNc As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFromVenNc As System.Windows.Forms.TextBox
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdExcel As System.Windows.Forms.Button
    Friend WithEvents chkBOM As System.Windows.Forms.CheckBox
End Class
