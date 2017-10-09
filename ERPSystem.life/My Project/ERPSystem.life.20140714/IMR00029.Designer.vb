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
        Me.grpDate = New System.Windows.Forms.GroupBox
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
        Me.grpStatus = New System.Windows.Forms.GroupBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.optE_SAPSONo = New System.Windows.Forms.RadioButton
        Me.optE_Pck = New System.Windows.Forms.RadioButton
        Me.optE_FtyCst = New System.Windows.Forms.RadioButton
        Me.optE_CVPV = New System.Windows.Forms.RadioButton
        Me.optE_All = New System.Windows.Forms.RadioButton
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmdShow = New System.Windows.Forms.Button
        Me.grpDate.SuspendLayout()
        Me.grpStatus.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpDate
        '
        Me.grpDate.Controls.Add(Me.Label4)
        Me.grpDate.Controls.Add(Me.dtpTo)
        Me.grpDate.Controls.Add(Me.Label5)
        Me.grpDate.Controls.Add(Me.dtpFrom)
        Me.grpDate.Controls.Add(Me.Label3)
        Me.grpDate.Controls.Add(Me.Label2)
        Me.grpDate.Controls.Add(Me.Label1)
        Me.grpDate.Enabled = False
        Me.grpDate.Location = New System.Drawing.Point(12, 12)
        Me.grpDate.Name = "grpDate"
        Me.grpDate.Size = New System.Drawing.Size(500, 57)
        Me.grpDate.TabIndex = 0
        Me.grpDate.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(325, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "MM/DD/YYYY"
        '
        'dtpTo
        '
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTo.Location = New System.Drawing.Point(324, 14)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(124, 20)
        Me.dtpTo.TabIndex = 7
        Me.dtpTo.Value = New Date(2012, 5, 29, 0, 0, 0, 0)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(142, 36)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "MM/DD/YYYY"
        '
        'dtpFrom
        '
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrom.Location = New System.Drawing.Point(141, 14)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(124, 20)
        Me.dtpFrom.TabIndex = 5
        Me.dtpFrom.Value = New Date(2012, 5, 29, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(298, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "To"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(104, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "From"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Date"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(20, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Status"
        '
        'optLatest
        '
        Me.optLatest.AutoSize = True
        Me.optLatest.Checked = True
        Me.optLatest.Location = New System.Drawing.Point(141, 16)
        Me.optLatest.Name = "optLatest"
        Me.optLatest.Size = New System.Drawing.Size(54, 17)
        Me.optLatest.TabIndex = 1
        Me.optLatest.TabStop = True
        Me.optLatest.Text = "Latest"
        Me.optLatest.UseVisualStyleBackColor = True
        '
        'optHistory
        '
        Me.optHistory.AutoSize = True
        Me.optHistory.Location = New System.Drawing.Point(325, 16)
        Me.optHistory.Name = "optHistory"
        Me.optHistory.Size = New System.Drawing.Size(57, 17)
        Me.optHistory.TabIndex = 2
        Me.optHistory.Text = "History"
        Me.optHistory.UseVisualStyleBackColor = True
        '
        'grpStatus
        '
        Me.grpStatus.Controls.Add(Me.optHistory)
        Me.grpStatus.Controls.Add(Me.optLatest)
        Me.grpStatus.Controls.Add(Me.Label6)
        Me.grpStatus.Enabled = False
        Me.grpStatus.Location = New System.Drawing.Point(12, 75)
        Me.grpStatus.Name = "grpStatus"
        Me.grpStatus.Size = New System.Drawing.Size(500, 45)
        Me.grpStatus.TabIndex = 1
        Me.grpStatus.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optE_SAPSONo)
        Me.GroupBox1.Controls.Add(Me.optE_Pck)
        Me.GroupBox1.Controls.Add(Me.optE_FtyCst)
        Me.GroupBox1.Controls.Add(Me.optE_CVPV)
        Me.GroupBox1.Controls.Add(Me.optE_All)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(12, 126)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(500, 45)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'optE_SAPSONo
        '
        Me.optE_SAPSONo.AutoSize = True
        Me.optE_SAPSONo.Location = New System.Drawing.Point(422, 16)
        Me.optE_SAPSONo.Name = "optE_SAPSONo"
        Me.optE_SAPSONo.Size = New System.Drawing.Size(74, 17)
        Me.optE_SAPSONo.TabIndex = 6
        Me.optE_SAPSONo.Text = "SAP PO #"
        Me.optE_SAPSONo.UseVisualStyleBackColor = True
        '
        'optE_Pck
        '
        Me.optE_Pck.AutoSize = True
        Me.optE_Pck.Location = New System.Drawing.Point(352, 16)
        Me.optE_Pck.Name = "optE_Pck"
        Me.optE_Pck.Size = New System.Drawing.Size(64, 17)
        Me.optE_Pck.TabIndex = 5
        Me.optE_Pck.Text = "Packing"
        Me.optE_Pck.UseVisualStyleBackColor = True
        '
        'optE_FtyCst
        '
        Me.optE_FtyCst.AutoSize = True
        Me.optE_FtyCst.Location = New System.Drawing.Point(262, 16)
        Me.optE_FtyCst.Name = "optE_FtyCst"
        Me.optE_FtyCst.Size = New System.Drawing.Size(84, 17)
        Me.optE_FtyCst.TabIndex = 4
        Me.optE_FtyCst.Text = "Factory Cost"
        Me.optE_FtyCst.UseVisualStyleBackColor = True
        '
        'optE_CVPV
        '
        Me.optE_CVPV.AutoSize = True
        Me.optE_CVPV.Location = New System.Drawing.Point(191, 16)
        Me.optE_CVPV.Name = "optE_CVPV"
        Me.optE_CVPV.Size = New System.Drawing.Size(65, 17)
        Me.optE_CVPV.TabIndex = 3
        Me.optE_CVPV.Text = "CV && PV"
        Me.optE_CVPV.UseVisualStyleBackColor = True
        '
        'optE_All
        '
        Me.optE_All.AutoSize = True
        Me.optE_All.Checked = True
        Me.optE_All.Location = New System.Drawing.Point(141, 16)
        Me.optE_All.Name = "optE_All"
        Me.optE_All.Size = New System.Drawing.Size(44, 17)
        Me.optE_All.TabIndex = 1
        Me.optE_All.TabStop = True
        Me.optE_All.Text = "ALL"
        Me.optE_All.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(20, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Exception Type"
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(207, 179)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(111, 32)
        Me.cmdShow.TabIndex = 20
        Me.cmdShow.Text = "E&xport to Excel"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'IMR00029
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(525, 222)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grpStatus)
        Me.Controls.Add(Me.grpDate)
        Me.Name = "IMR00029"
        Me.Text = "IMR00029 - Factory Approve Data Comparison Report"
        Me.grpDate.ResumeLayout(False)
        Me.grpDate.PerformLayout()
        Me.grpStatus.ResumeLayout(False)
        Me.grpStatus.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpDate As System.Windows.Forms.GroupBox
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
    Friend WithEvents grpStatus As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents optE_Pck As System.Windows.Forms.RadioButton
    Friend WithEvents optE_FtyCst As System.Windows.Forms.RadioButton
    Friend WithEvents optE_CVPV As System.Windows.Forms.RadioButton
    Friend WithEvents optE_All As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents optE_SAPSONo As System.Windows.Forms.RadioButton
    Friend WithEvents cmdShow As System.Windows.Forms.Button
End Class
