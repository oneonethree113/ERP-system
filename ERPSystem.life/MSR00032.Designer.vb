﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MSR00032
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MSR00032))
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.grpSearch = New System.Windows.Forms.GroupBox
        Me.cmd_S_ItmNo = New System.Windows.Forms.Button
        Me.txtItmNo = New System.Windows.Forms.TextBox
        Me.cboCUTo = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.cboCUFm = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.cboVenTo = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboVenFm = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboSCTo = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cboSCFm = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtToItmno = New System.Windows.Forms.TextBox
        Me.txtFromItmno = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.optExcel = New System.Windows.Forms.RadioButton
        Me.optCR = New System.Windows.Forms.RadioButton
        Me.cmdShow = New System.Windows.Forms.Button
        Me.Label16 = New System.Windows.Forms.Label
        Me.btnExportExcel = New System.Windows.Forms.Button
        Me.grpSearch.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(18, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Company Code"
        '
        'cboCoCde
        '
        Me.cboCoCde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(103, 53)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(76, 20)
        Me.cboCoCde.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(196, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Company Name"
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.Color.White
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.ForeColor = System.Drawing.Color.Black
        Me.txtCoNam.Location = New System.Drawing.Point(284, 53)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.Size = New System.Drawing.Size(338, 22)
        Me.txtCoNam.TabIndex = 2
        '
        'grpSearch
        '
        Me.grpSearch.Controls.Add(Me.cmd_S_ItmNo)
        Me.grpSearch.Controls.Add(Me.txtItmNo)
        Me.grpSearch.Controls.Add(Me.cboCUTo)
        Me.grpSearch.Controls.Add(Me.Label12)
        Me.grpSearch.Controls.Add(Me.cboCUFm)
        Me.grpSearch.Controls.Add(Me.Label13)
        Me.grpSearch.Controls.Add(Me.Label14)
        Me.grpSearch.Controls.Add(Me.cboVenTo)
        Me.grpSearch.Controls.Add(Me.Label6)
        Me.grpSearch.Controls.Add(Me.cboVenFm)
        Me.grpSearch.Controls.Add(Me.Label7)
        Me.grpSearch.Controls.Add(Me.Label8)
        Me.grpSearch.Controls.Add(Me.Label3)
        Me.grpSearch.Location = New System.Drawing.Point(18, 90)
        Me.grpSearch.Name = "grpSearch"
        Me.grpSearch.Size = New System.Drawing.Size(604, 173)
        Me.grpSearch.TabIndex = 4
        Me.grpSearch.TabStop = False
        '
        'cmd_S_ItmNo
        '
        Me.cmd_S_ItmNo.Location = New System.Drawing.Point(105, 29)
        Me.cmd_S_ItmNo.Name = "cmd_S_ItmNo"
        Me.cmd_S_ItmNo.Size = New System.Drawing.Size(43, 20)
        Me.cmd_S_ItmNo.TabIndex = 20
        Me.cmd_S_ItmNo.Text = "＞＞"
        '
        'txtItmNo
        '
        Me.txtItmNo.Location = New System.Drawing.Point(151, 28)
        Me.txtItmNo.MaxLength = 0
        Me.txtItmNo.Name = "txtItmNo"
        Me.txtItmNo.Size = New System.Drawing.Size(437, 22)
        Me.txtItmNo.TabIndex = 19
        '
        'cboCUTo
        '
        Me.cboCUTo.FormattingEnabled = True
        Me.cboCUTo.Location = New System.Drawing.Point(401, 126)
        Me.cboCUTo.Name = "cboCUTo"
        Me.cboCUTo.Size = New System.Drawing.Size(187, 20)
        Me.cboCUTo.TabIndex = 10
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(371, 129)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(18, 12)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "To"
        '
        'cboCUFm
        '
        Me.cboCUFm.FormattingEnabled = True
        Me.cboCUFm.Location = New System.Drawing.Point(151, 126)
        Me.cboCUFm.Name = "cboCUFm"
        Me.cboCUFm.Size = New System.Drawing.Size(187, 20)
        Me.cboCUFm.TabIndex = 9
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(110, 129)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(30, 12)
        Me.Label13.TabIndex = 16
        Me.Label13.Text = "From"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(17, 129)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(70, 12)
        Me.Label14.TabIndex = 15
        Me.Label14.Text = "Customer No."
        '
        'cboVenTo
        '
        Me.cboVenTo.FormattingEnabled = True
        Me.cboVenTo.Location = New System.Drawing.Point(401, 75)
        Me.cboVenTo.Name = "cboVenTo"
        Me.cboVenTo.Size = New System.Drawing.Size(187, 20)
        Me.cboVenTo.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(371, 78)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(18, 12)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "To"
        '
        'cboVenFm
        '
        Me.cboVenFm.FormattingEnabled = True
        Me.cboVenFm.Location = New System.Drawing.Point(151, 75)
        Me.cboVenFm.Name = "cboVenFm"
        Me.cboVenFm.Size = New System.Drawing.Size(187, 20)
        Me.cboVenFm.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(110, 78)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 12)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "From"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(17, 78)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(19, 12)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "PV"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 12)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Item No."
        '
        'cboSCTo
        '
        Me.cboSCTo.FormattingEnabled = True
        Me.cboSCTo.Location = New System.Drawing.Point(447, 293)
        Me.cboSCTo.Name = "cboSCTo"
        Me.cboSCTo.Size = New System.Drawing.Size(187, 20)
        Me.cboSCTo.TabIndex = 8
        Me.cboSCTo.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(417, 296)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(18, 12)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "To"
        Me.Label9.Visible = False
        '
        'cboSCFm
        '
        Me.cboSCFm.FormattingEnabled = True
        Me.cboSCFm.Location = New System.Drawing.Point(430, 306)
        Me.cboSCFm.Name = "cboSCFm"
        Me.cboSCFm.Size = New System.Drawing.Size(187, 20)
        Me.cboSCFm.TabIndex = 7
        Me.cboSCFm.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(389, 309)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(30, 12)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "From"
        Me.Label10.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(296, 309)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 12)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Sub Code"
        Me.Label11.Visible = False
        '
        'txtToItmno
        '
        Me.txtToItmno.Location = New System.Drawing.Point(435, 303)
        Me.txtToItmno.MaxLength = 20
        Me.txtToItmno.Name = "txtToItmno"
        Me.txtToItmno.Size = New System.Drawing.Size(187, 22)
        Me.txtToItmno.TabIndex = 4
        Me.txtToItmno.Visible = False
        '
        'txtFromItmno
        '
        Me.txtFromItmno.Location = New System.Drawing.Point(435, 286)
        Me.txtFromItmno.MaxLength = 20
        Me.txtFromItmno.Name = "txtFromItmno"
        Me.txtFromItmno.Size = New System.Drawing.Size(187, 22)
        Me.txtFromItmno.TabIndex = 3
        Me.txtFromItmno.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(405, 306)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(18, 12)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "To"
        Me.Label5.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(394, 289)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 12)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "From"
        Me.Label4.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(410, 271)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(78, 12)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "Export to Excel"
        Me.Label15.Visible = False
        '
        'optExcel
        '
        Me.optExcel.AutoSize = True
        Me.optExcel.Location = New System.Drawing.Point(512, 269)
        Me.optExcel.Name = "optExcel"
        Me.optExcel.Size = New System.Drawing.Size(40, 16)
        Me.optExcel.TabIndex = 11
        Me.optExcel.Text = "Yes"
        Me.optExcel.UseVisualStyleBackColor = True
        Me.optExcel.Visible = False
        '
        'optCR
        '
        Me.optCR.AutoSize = True
        Me.optCR.Checked = True
        Me.optCR.Location = New System.Drawing.Point(575, 269)
        Me.optCR.Name = "optCR"
        Me.optCR.Size = New System.Drawing.Size(37, 16)
        Me.optCR.TabIndex = 12
        Me.optCR.TabStop = True
        Me.optCR.Text = "No"
        Me.optCR.UseVisualStyleBackColor = True
        Me.optCR.Visible = False
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(478, 303)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(96, 25)
        Me.cmdShow.TabIndex = 13
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        Me.cmdShow.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.Location = New System.Drawing.Point(233, 9)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(194, 24)
        Me.Label16.TabIndex = 18
        Me.Label16.Text = "Document List by item"
        '
        'btnExportExcel
        '
        Me.btnExportExcel.Location = New System.Drawing.Point(267, 281)
        Me.btnExportExcel.Name = "btnExportExcel"
        Me.btnExportExcel.Size = New System.Drawing.Size(140, 22)
        Me.btnExportExcel.TabIndex = 19
        Me.btnExportExcel.Text = "Export Excel"
        Me.btnExportExcel.UseVisualStyleBackColor = True
        '
        'MSR00032
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 329)
        Me.Controls.Add(Me.btnExportExcel)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtToItmno)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.txtFromItmno)
        Me.Controls.Add(Me.optCR)
        Me.Controls.Add(Me.optExcel)
        Me.Controls.Add(Me.cboSCFm)
        Me.Controls.Add(Me.cboSCTo)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.grpSearch)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MSR00032"
        Me.Text = "MSR00032 - Document List by item (MSR32)"
        Me.grpSearch.ResumeLayout(False)
        Me.grpSearch.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents grpSearch As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboVenTo As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboVenFm As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboCUTo As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboCUFm As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboSCTo As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboSCFm As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents optExcel As System.Windows.Forms.RadioButton
    Friend WithEvents optCR As System.Windows.Forms.RadioButton
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents txtToItmno As System.Windows.Forms.TextBox
    Friend WithEvents txtFromItmno As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents btnExportExcel As System.Windows.Forms.Button
    Friend WithEvents txtItmNo As System.Windows.Forms.TextBox
    Friend WithEvents cmd_S_ItmNo As System.Windows.Forms.Button
End Class
