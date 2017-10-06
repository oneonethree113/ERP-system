<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IMR00010
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkRecStsO = New System.Windows.Forms.CheckBox
        Me.chkRecStsW = New System.Windows.Forms.CheckBox
        Me.chkRecStsI = New System.Windows.Forms.CheckBox
        Me.chkRecStsR = New System.Windows.Forms.CheckBox
        Me.chkRecStsA = New System.Windows.Forms.CheckBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtptoTranDat = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdShow = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.dtpfromTrandat = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cboCustNoTo = New System.Windows.Forms.ComboBox
        Me.cboCustNoFm = New System.Windows.Forms.ComboBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(227, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "MM/DD/YYYY"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.chkRecStsO)
        Me.GroupBox1.Controls.Add(Me.chkRecStsW)
        Me.GroupBox1.Controls.Add(Me.chkRecStsI)
        Me.GroupBox1.Controls.Add(Me.chkRecStsR)
        Me.GroupBox1.Controls.Add(Me.chkRecStsA)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(370, 88)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Record Status"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Show"
        '
        'chkRecStsO
        '
        Me.chkRecStsO.AutoSize = True
        Me.chkRecStsO.Location = New System.Drawing.Point(64, 65)
        Me.chkRecStsO.Name = "chkRecStsO"
        Me.chkRecStsO.Size = New System.Drawing.Size(66, 17)
        Me.chkRecStsO.TabIndex = 3
        Me.chkRecStsO.Text = "Override"
        Me.chkRecStsO.UseVisualStyleBackColor = True
        '
        'chkRecStsW
        '
        Me.chkRecStsW.AutoSize = True
        Me.chkRecStsW.Location = New System.Drawing.Point(230, 42)
        Me.chkRecStsW.Name = "chkRecStsW"
        Me.chkRecStsW.Size = New System.Drawing.Size(62, 17)
        Me.chkRecStsW.TabIndex = 5
        Me.chkRecStsW.Text = "Waiting"
        Me.chkRecStsW.UseVisualStyleBackColor = True
        '
        'chkRecStsI
        '
        Me.chkRecStsI.AutoSize = True
        Me.chkRecStsI.Location = New System.Drawing.Point(64, 42)
        Me.chkRecStsI.Name = "chkRecStsI"
        Me.chkRecStsI.Size = New System.Drawing.Size(57, 17)
        Me.chkRecStsI.TabIndex = 2
        Me.chkRecStsI.Text = "Invalid"
        Me.chkRecStsI.UseVisualStyleBackColor = True
        '
        'chkRecStsR
        '
        Me.chkRecStsR.AutoSize = True
        Me.chkRecStsR.Location = New System.Drawing.Point(230, 19)
        Me.chkRecStsR.Name = "chkRecStsR"
        Me.chkRecStsR.Size = New System.Drawing.Size(69, 17)
        Me.chkRecStsR.TabIndex = 4
        Me.chkRecStsR.Text = "Rejected"
        Me.chkRecStsR.UseVisualStyleBackColor = True
        '
        'chkRecStsA
        '
        Me.chkRecStsA.AutoSize = True
        Me.chkRecStsA.Location = New System.Drawing.Point(64, 19)
        Me.chkRecStsA.Name = "chkRecStsA"
        Me.chkRecStsA.Size = New System.Drawing.Size(72, 17)
        Me.chkRecStsA.TabIndex = 1
        Me.chkRecStsA.Text = "Approved"
        Me.chkRecStsA.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(204, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(20, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "To"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(204, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "To"
        '
        'dtptoTranDat
        '
        Me.dtptoTranDat.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtptoTranDat.Location = New System.Drawing.Point(230, 19)
        Me.dtptoTranDat.Name = "dtptoTranDat"
        Me.dtptoTranDat.Size = New System.Drawing.Size(134, 20)
        Me.dtptoTranDat.TabIndex = 9
        Me.dtptoTranDat.Value = New Date(2012, 12, 21, 0, 0, 0, 0)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(61, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "MM/DD/YYYY"
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(142, 228)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(110, 30)
        Me.cmdShow.TabIndex = 10
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "From"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.dtptoTranDat)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.dtpfromTrandat)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 159)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(370, 63)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Transaction Date"
        '
        'dtpfromTrandat
        '
        Me.dtpfromTrandat.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpfromTrandat.Location = New System.Drawing.Point(64, 19)
        Me.dtpfromTrandat.Name = "dtpfromTrandat"
        Me.dtpfromTrandat.Size = New System.Drawing.Size(134, 20)
        Me.dtpfromTrandat.TabIndex = 8
        Me.dtpfromTrandat.Value = New Date(2012, 12, 21, 0, 0, 0, 0)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "From"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboCustNoTo)
        Me.GroupBox2.Controls.Add(Me.cboCustNoFm)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 106)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(370, 47)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Customer No."
        '
        'cboCustNoTo
        '
        Me.cboCustNoTo.FormattingEnabled = True
        Me.cboCustNoTo.Location = New System.Drawing.Point(230, 19)
        Me.cboCustNoTo.Name = "cboCustNoTo"
        Me.cboCustNoTo.Size = New System.Drawing.Size(134, 21)
        Me.cboCustNoTo.TabIndex = 7
        '
        'cboCustNoFm
        '
        Me.cboCustNoFm.FormattingEnabled = True
        Me.cboCustNoFm.Location = New System.Drawing.Point(64, 19)
        Me.cboCustNoFm.Name = "cboCustNoFm"
        Me.cboCustNoFm.Size = New System.Drawing.Size(134, 21)
        Me.cboCustNoFm.TabIndex = 6
        '
        'IMR00010
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(394, 270)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "IMR00010"
        Me.Text = "IMR00010 - Customer Style No. & Validation Report"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkRecStsO As System.Windows.Forms.CheckBox
    Friend WithEvents chkRecStsW As System.Windows.Forms.CheckBox
    Friend WithEvents chkRecStsI As System.Windows.Forms.CheckBox
    Friend WithEvents chkRecStsR As System.Windows.Forms.CheckBox
    Friend WithEvents chkRecStsA As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtptoTranDat As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpfromTrandat As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboCustNoTo As System.Windows.Forms.ComboBox
    Friend WithEvents cboCustNoFm As System.Windows.Forms.ComboBox
End Class
