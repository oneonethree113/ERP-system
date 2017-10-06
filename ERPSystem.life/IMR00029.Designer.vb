<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IMR00029
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IMR00029))
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtpTo = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.optLatest = New System.Windows.Forms.RadioButton
        Me.optHistory = New System.Windows.Forms.RadioButton
        Me.optE_SAPSONo = New System.Windows.Forms.RadioButton
        Me.optE_Pck = New System.Windows.Forms.RadioButton
        Me.optE_FtyCst = New System.Windows.Forms.RadioButton
        Me.optE_CVPV = New System.Windows.Forms.RadioButton
        Me.optE_All = New System.Windows.Forms.RadioButton
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmdShow = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(376, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 12)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "MM/DD/YYYY"
        '
        'dtpTo
        '
        Me.dtpTo.Enabled = False
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTo.Location = New System.Drawing.Point(375, 49)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(131, 22)
        Me.dtpTo.TabIndex = 7
        Me.dtpTo.Value = New Date(2012, 5, 29, 0, 0, 0, 0)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(150, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 12)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "MM/DD/YYYY"
        '
        'dtpFrom
        '
        Me.dtpFrom.Enabled = False
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrom.Location = New System.Drawing.Point(149, 49)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(131, 22)
        Me.dtpFrom.TabIndex = 5
        Me.dtpFrom.Value = New Date(2012, 5, 29, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(349, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(18, 12)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "To"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(112, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "From"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Date"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(28, 122)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 12)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Status"
        '
        'optLatest
        '
        Me.optLatest.AutoSize = True
        Me.optLatest.Checked = True
        Me.optLatest.Location = New System.Drawing.Point(3, 3)
        Me.optLatest.Name = "optLatest"
        Me.optLatest.Size = New System.Drawing.Size(50, 16)
        Me.optLatest.TabIndex = 1
        Me.optLatest.TabStop = True
        Me.optLatest.Text = "Latest"
        Me.optLatest.UseVisualStyleBackColor = True
        '
        'optHistory
        '
        Me.optHistory.AutoSize = True
        Me.optHistory.Location = New System.Drawing.Point(229, 3)
        Me.optHistory.Name = "optHistory"
        Me.optHistory.Size = New System.Drawing.Size(57, 16)
        Me.optHistory.TabIndex = 2
        Me.optHistory.Text = "History"
        Me.optHistory.UseVisualStyleBackColor = True
        '
        'optE_SAPSONo
        '
        Me.optE_SAPSONo.AutoSize = True
        Me.optE_SAPSONo.Location = New System.Drawing.Point(304, 2)
        Me.optE_SAPSONo.Name = "optE_SAPSONo"
        Me.optE_SAPSONo.Size = New System.Drawing.Size(69, 16)
        Me.optE_SAPSONo.TabIndex = 6
        Me.optE_SAPSONo.Text = "SAP PO #"
        Me.optE_SAPSONo.UseVisualStyleBackColor = True
        '
        'optE_Pck
        '
        Me.optE_Pck.AutoSize = True
        Me.optE_Pck.Location = New System.Drawing.Point(229, 2)
        Me.optE_Pck.Name = "optE_Pck"
        Me.optE_Pck.Size = New System.Drawing.Size(60, 16)
        Me.optE_Pck.TabIndex = 5
        Me.optE_Pck.Text = "Packing"
        Me.optE_Pck.UseVisualStyleBackColor = True
        '
        'optE_FtyCst
        '
        Me.optE_FtyCst.AutoSize = True
        Me.optE_FtyCst.Location = New System.Drawing.Point(134, 2)
        Me.optE_FtyCst.Name = "optE_FtyCst"
        Me.optE_FtyCst.Size = New System.Drawing.Size(82, 16)
        Me.optE_FtyCst.TabIndex = 4
        Me.optE_FtyCst.Text = "Factory Cost"
        Me.optE_FtyCst.UseVisualStyleBackColor = True
        '
        'optE_CVPV
        '
        Me.optE_CVPV.AutoSize = True
        Me.optE_CVPV.Location = New System.Drawing.Point(58, 2)
        Me.optE_CVPV.Name = "optE_CVPV"
        Me.optE_CVPV.Size = New System.Drawing.Size(68, 16)
        Me.optE_CVPV.TabIndex = 3
        Me.optE_CVPV.Text = "CV && PV"
        Me.optE_CVPV.UseVisualStyleBackColor = True
        '
        'optE_All
        '
        Me.optE_All.AutoSize = True
        Me.optE_All.Checked = True
        Me.optE_All.Location = New System.Drawing.Point(3, 2)
        Me.optE_All.Name = "optE_All"
        Me.optE_All.Size = New System.Drawing.Size(45, 16)
        Me.optE_All.TabIndex = 1
        Me.optE_All.TabStop = True
        Me.optE_All.Text = "ALL"
        Me.optE_All.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(28, 187)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 12)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Exception Type"
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(255, 269)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(116, 40)
        Me.cmdShow.TabIndex = 10
        Me.cmdShow.Text = "E&xport to Excel"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(62, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(511, 23)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = " Factory Approve Data Comparison Report"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.optLatest)
        Me.Panel1.Controls.Add(Me.optHistory)
        Me.Panel1.Enabled = False
        Me.Panel1.Location = New System.Drawing.Point(149, 117)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(432, 21)
        Me.Panel1.TabIndex = 8
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.optE_All)
        Me.Panel2.Controls.Add(Me.optE_CVPV)
        Me.Panel2.Controls.Add(Me.optE_SAPSONo)
        Me.Panel2.Controls.Add(Me.optE_FtyCst)
        Me.Panel2.Controls.Add(Me.optE_Pck)
        Me.Panel2.Enabled = False
        Me.Panel2.Location = New System.Drawing.Point(149, 183)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(432, 21)
        Me.Panel2.TabIndex = 9
        '
        'IMR00029
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 412)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.dtpTo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.dtpFrom)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "IMR00029"
        Me.Text = "IMR00029 - Factory Approve Data Comparison Report (IMR29)"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents optLatest As System.Windows.Forms.RadioButton
    Friend WithEvents optHistory As System.Windows.Forms.RadioButton
    Friend WithEvents optE_Pck As System.Windows.Forms.RadioButton
    Friend WithEvents optE_FtyCst As System.Windows.Forms.RadioButton
    Friend WithEvents optE_CVPV As System.Windows.Forms.RadioButton
    Friend WithEvents optE_All As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents optE_SAPSONo As System.Windows.Forms.RadioButton
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
End Class
