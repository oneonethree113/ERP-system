﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IMR00013
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IMR00013))
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cboReport = New System.Windows.Forms.ComboBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtMthTo = New System.Windows.Forms.TextBox
        Me.txtMthFm = New System.Windows.Forms.TextBox
        Me.txtYearTo = New System.Windows.Forms.TextBox
        Me.txtYearFm = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cboVenTo = New System.Windows.Forms.ComboBox
        Me.cboVenFm = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.frSDate = New System.Windows.Forms.GroupBox
        Me.txtSDateTO = New System.Windows.Forms.MaskedTextBox
        Me.txtSDateFM = New System.Windows.Forms.MaskedTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Chk_export2excel = New System.Windows.Forms.CheckBox
        Me.btn_excel = New System.Windows.Forms.Button
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.frSDate.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(199, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(228, 24)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Item Image Analyst Report"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cboReport)
        Me.GroupBox3.Location = New System.Drawing.Point(30, 167)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(574, 42)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Report Type"
        '
        'cboReport
        '
        Me.cboReport.FormattingEnabled = True
        Me.cboReport.Location = New System.Drawing.Point(66, 15)
        Me.cboReport.Name = "cboReport"
        Me.cboReport.Size = New System.Drawing.Size(205, 20)
        Me.cboReport.TabIndex = 9
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtMthTo)
        Me.GroupBox2.Controls.Add(Me.txtMthFm)
        Me.GroupBox2.Controls.Add(Me.txtYearTo)
        Me.GroupBox2.Controls.Add(Me.txtYearFm)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(30, 100)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(574, 42)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Year/Month"
        '
        'txtMthTo
        '
        Me.txtMthTo.Location = New System.Drawing.Point(424, 13)
        Me.txtMthTo.Name = "txtMthTo"
        Me.txtMthTo.Size = New System.Drawing.Size(25, 22)
        Me.txtMthTo.TabIndex = 7
        '
        'txtMthFm
        '
        Me.txtMthFm.Location = New System.Drawing.Point(150, 14)
        Me.txtMthFm.Name = "txtMthFm"
        Me.txtMthFm.Size = New System.Drawing.Size(25, 22)
        Me.txtMthFm.TabIndex = 5
        '
        'txtYearTo
        '
        Me.txtYearTo.Location = New System.Drawing.Point(377, 13)
        Me.txtYearTo.Name = "txtYearTo"
        Me.txtYearTo.Size = New System.Drawing.Size(25, 22)
        Me.txtYearTo.TabIndex = 6
        '
        'txtYearFm
        '
        Me.txtYearFm.Location = New System.Drawing.Point(103, 14)
        Me.txtYearFm.Name = "txtYearFm"
        Me.txtYearFm.Size = New System.Drawing.Size(25, 22)
        Me.txtYearFm.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(308, 17)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(18, 12)
        Me.Label9.TabIndex = 41
        Me.Label9.Text = "To"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(27, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 12)
        Me.Label7.TabIndex = 41
        Me.Label7.Text = "From"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(358, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 12)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "20            /"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(84, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 12)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "20            /"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboVenTo)
        Me.GroupBox1.Controls.Add(Me.cboVenFm)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Location = New System.Drawing.Point(30, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(574, 42)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Vendor No"
        '
        'cboVenTo
        '
        Me.cboVenTo.FormattingEnabled = True
        Me.cboVenTo.Location = New System.Drawing.Point(343, 13)
        Me.cboVenTo.Name = "cboVenTo"
        Me.cboVenTo.Size = New System.Drawing.Size(205, 20)
        Me.cboVenTo.TabIndex = 2
        '
        'cboVenFm
        '
        Me.cboVenFm.FormattingEnabled = True
        Me.cboVenFm.Location = New System.Drawing.Point(66, 13)
        Me.cboVenFm.Name = "cboVenFm"
        Me.cboVenFm.Size = New System.Drawing.Size(205, 20)
        Me.cboVenFm.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(27, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 12)
        Me.Label6.TabIndex = 40
        Me.Label6.Text = "From"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(308, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(18, 12)
        Me.Label8.TabIndex = 40
        Me.Label8.Text = "To"
        '
        'frSDate
        '
        Me.frSDate.Controls.Add(Me.txtSDateTO)
        Me.frSDate.Controls.Add(Me.txtSDateFM)
        Me.frSDate.Controls.Add(Me.Label1)
        Me.frSDate.Controls.Add(Me.Label2)
        Me.frSDate.Location = New System.Drawing.Point(30, 235)
        Me.frSDate.Name = "frSDate"
        Me.frSDate.Size = New System.Drawing.Size(574, 42)
        Me.frSDate.TabIndex = 10
        Me.frSDate.TabStop = False
        Me.frSDate.Text = "SC Issue Date (mm/dd/yyyy)"
        Me.frSDate.Visible = False
        '
        'txtSDateTO
        '
        Me.txtSDateTO.Location = New System.Drawing.Point(343, 14)
        Me.txtSDateTO.Mask = "##/##/####"
        Me.txtSDateTO.Name = "txtSDateTO"
        Me.txtSDateTO.Size = New System.Drawing.Size(205, 22)
        Me.txtSDateTO.TabIndex = 12
        '
        'txtSDateFM
        '
        Me.txtSDateFM.Location = New System.Drawing.Point(66, 14)
        Me.txtSDateFM.Mask = "##/##/####"
        Me.txtSDateFM.Name = "txtSDateFM"
        Me.txtSDateFM.Size = New System.Drawing.Size(205, 22)
        Me.txtSDateFM.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(308, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 12)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "To"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 12)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "From"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(331, 295)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(92, 21)
        Me.Button1.TabIndex = 39
        Me.Button1.Text = "Show Report"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Chk_export2excel
        '
        Me.Chk_export2excel.AutoSize = True
        Me.Chk_export2excel.Location = New System.Drawing.Point(243, 300)
        Me.Chk_export2excel.Name = "Chk_export2excel"
        Me.Chk_export2excel.Size = New System.Drawing.Size(77, 16)
        Me.Chk_export2excel.TabIndex = 38
        Me.Chk_export2excel.TabStop = False
        Me.Chk_export2excel.Text = "Show excel"
        Me.Chk_export2excel.UseVisualStyleBackColor = True
        '
        'btn_excel
        '
        Me.btn_excel.Location = New System.Drawing.Point(228, 295)
        Me.btn_excel.Name = "btn_excel"
        Me.btn_excel.Size = New System.Drawing.Size(92, 21)
        Me.btn_excel.TabIndex = 13
        Me.btn_excel.Text = "Export to Excel"
        Me.btn_excel.UseVisualStyleBackColor = True
        '
        'IMR00013
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 348)
        Me.Controls.Add(Me.btn_excel)
        Me.Controls.Add(Me.Chk_export2excel)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.frSDate)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(640, 377)
        Me.MinimumSize = New System.Drawing.Size(640, 377)
        Me.Name = "IMR00013"
        Me.Text = "IMR00013 - Item Image Analyst Report (IMR13)"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.frSDate.ResumeLayout(False)
        Me.frSDate.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboReport As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboVenTo As System.Windows.Forms.ComboBox
    Friend WithEvents cboVenFm As System.Windows.Forms.ComboBox
    Friend WithEvents frSDate As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtMthTo As System.Windows.Forms.TextBox
    Friend WithEvents txtMthFm As System.Windows.Forms.TextBox
    Friend WithEvents txtYearTo As System.Windows.Forms.TextBox
    Friend WithEvents txtYearFm As System.Windows.Forms.TextBox
    Friend WithEvents txtSDateTO As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtSDateFM As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Chk_export2excel As System.Windows.Forms.CheckBox
    Friend WithEvents btn_excel As System.Windows.Forms.Button
End Class
