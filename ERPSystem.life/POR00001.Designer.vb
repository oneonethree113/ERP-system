<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class POR00001
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(POR00001))
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.optAmtN = New System.Windows.Forms.RadioButton
        Me.optAmtY = New System.Windows.Forms.RadioButton
        Me.Label10 = New System.Windows.Forms.Label
        Me.optGroupN = New System.Windows.Forms.RadioButton
        Me.optGroupY = New System.Windows.Forms.RadioButton
        Me.Label9 = New System.Windows.Forms.Label
        Me.optRvsNo = New System.Windows.Forms.RadioButton
        Me.optRvsYes = New System.Windows.Forms.RadioButton
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboReportFormat = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtTo = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtFm = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.optSupN = New System.Windows.Forms.RadioButton
        Me.optSupY = New System.Windows.Forms.RadioButton
        Me.Label5 = New System.Windows.Forms.Label
        Me.optExact = New System.Windows.Forms.RadioButton
        Me.optApprox = New System.Windows.Forms.RadioButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.optInpseq = New System.Windows.Forms.RadioButton
        Me.optItem = New System.Windows.Forms.RadioButton
        Me.optCust = New System.Windows.Forms.RadioButton
        Me.cmdShow = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(610, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Purchase Order Report"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.SystemColors.Window
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.Location = New System.Drawing.Point(268, 43)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.Size = New System.Drawing.Size(329, 22)
        Me.txtCoNam.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(180, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 12)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Company Name"
        '
        'cboCoCde
        '
        Me.cboCoCde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(99, 43)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(76, 20)
        Me.cboCoCde.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(14, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Company Code"
        '
        'optAmtN
        '
        Me.optAmtN.AutoSize = True
        Me.optAmtN.Location = New System.Drawing.Point(273, 2)
        Me.optAmtN.Name = "optAmtN"
        Me.optAmtN.Size = New System.Drawing.Size(37, 16)
        Me.optAmtN.TabIndex = 2
        Me.optAmtN.TabStop = True
        Me.optAmtN.Text = "No"
        Me.optAmtN.UseVisualStyleBackColor = True
        '
        'optAmtY
        '
        Me.optAmtY.AutoSize = True
        Me.optAmtY.Checked = True
        Me.optAmtY.Location = New System.Drawing.Point(3, 2)
        Me.optAmtY.Name = "optAmtY"
        Me.optAmtY.Size = New System.Drawing.Size(40, 16)
        Me.optAmtY.TabIndex = 1
        Me.optAmtY.TabStop = True
        Me.optAmtY.Text = "Yes"
        Me.optAmtY.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(14, 259)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(68, 12)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Print Amount"
        '
        'optGroupN
        '
        Me.optGroupN.AutoSize = True
        Me.optGroupN.Location = New System.Drawing.Point(273, 3)
        Me.optGroupN.Name = "optGroupN"
        Me.optGroupN.Size = New System.Drawing.Size(37, 16)
        Me.optGroupN.TabIndex = 2
        Me.optGroupN.TabStop = True
        Me.optGroupN.Text = "No"
        Me.optGroupN.UseVisualStyleBackColor = True
        '
        'optGroupY
        '
        Me.optGroupY.AutoSize = True
        Me.optGroupY.Checked = True
        Me.optGroupY.Location = New System.Drawing.Point(3, 3)
        Me.optGroupY.Name = "optGroupY"
        Me.optGroupY.Size = New System.Drawing.Size(40, 16)
        Me.optGroupY.TabIndex = 1
        Me.optGroupY.TabStop = True
        Me.optGroupY.Text = "Yes"
        Me.optGroupY.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 232)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(119, 12)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Group New Item Format"
        '
        'optRvsNo
        '
        Me.optRvsNo.AutoSize = True
        Me.optRvsNo.Checked = True
        Me.optRvsNo.Location = New System.Drawing.Point(273, 3)
        Me.optRvsNo.Name = "optRvsNo"
        Me.optRvsNo.Size = New System.Drawing.Size(37, 16)
        Me.optRvsNo.TabIndex = 2
        Me.optRvsNo.TabStop = True
        Me.optRvsNo.Text = "No"
        Me.optRvsNo.UseVisualStyleBackColor = True
        '
        'optRvsYes
        '
        Me.optRvsYes.AutoSize = True
        Me.optRvsYes.Location = New System.Drawing.Point(3, 3)
        Me.optRvsYes.Name = "optRvsYes"
        Me.optRvsYes.Size = New System.Drawing.Size(40, 16)
        Me.optRvsYes.TabIndex = 1
        Me.optRvsYes.TabStop = True
        Me.optRvsYes.Text = "Yes"
        Me.optRvsYes.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 205)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 12)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Revised"
        '
        'cboReportFormat
        '
        Me.cboReportFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReportFormat.FormattingEnabled = True
        Me.cboReportFormat.Location = New System.Drawing.Point(182, 169)
        Me.cboReportFormat.Name = "cboReportFormat"
        Me.cboReportFormat.Size = New System.Drawing.Size(415, 20)
        Me.cboReportFormat.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 172)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 12)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Report Format"
        '
        'txtTo
        '
        Me.txtTo.Location = New System.Drawing.Point(452, 139)
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Size = New System.Drawing.Size(145, 22)
        Me.txtTo.TabIndex = 6
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(428, 140)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(18, 12)
        Me.Label12.TabIndex = 3
        Me.Label12.Text = "To"
        '
        'txtFm
        '
        Me.txtFm.Location = New System.Drawing.Point(182, 139)
        Me.txtFm.Name = "txtFm"
        Me.txtFm.Size = New System.Drawing.Size(145, 22)
        Me.txtFm.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(146, 142)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(30, 12)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "From"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 142)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 12)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Purchase Order No."
        '
        'optSupN
        '
        Me.optSupN.AutoSize = True
        Me.optSupN.Location = New System.Drawing.Point(273, 3)
        Me.optSupN.Name = "optSupN"
        Me.optSupN.Size = New System.Drawing.Size(37, 16)
        Me.optSupN.TabIndex = 2
        Me.optSupN.TabStop = True
        Me.optSupN.Text = "No"
        Me.optSupN.UseVisualStyleBackColor = True
        '
        'optSupY
        '
        Me.optSupY.AutoSize = True
        Me.optSupY.Checked = True
        Me.optSupY.Location = New System.Drawing.Point(3, 3)
        Me.optSupY.Name = "optSupY"
        Me.optSupY.Size = New System.Drawing.Size(40, 16)
        Me.optSupY.TabIndex = 1
        Me.optSupY.TabStop = True
        Me.optSupY.Text = "Yes"
        Me.optSupY.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 114)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 12)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Suppress ZERO Qty"
        '
        'optExact
        '
        Me.optExact.AutoSize = True
        Me.optExact.Checked = True
        Me.optExact.Location = New System.Drawing.Point(273, 3)
        Me.optExact.Name = "optExact"
        Me.optExact.Size = New System.Drawing.Size(49, 16)
        Me.optExact.TabIndex = 2
        Me.optExact.TabStop = True
        Me.optExact.Text = "Exact"
        Me.optExact.UseVisualStyleBackColor = True
        '
        'optApprox
        '
        Me.optApprox.AutoSize = True
        Me.optApprox.Location = New System.Drawing.Point(3, 3)
        Me.optApprox.Name = "optApprox"
        Me.optApprox.Size = New System.Drawing.Size(59, 16)
        Me.optApprox.TabIndex = 1
        Me.optApprox.TabStop = True
        Me.optApprox.Text = "Approx"
        Me.optApprox.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 12)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Ship Date Format"
        '
        'optInpseq
        '
        Me.optInpseq.AutoSize = True
        Me.optInpseq.Enabled = False
        Me.optInpseq.Location = New System.Drawing.Point(273, 3)
        Me.optInpseq.Name = "optInpseq"
        Me.optInpseq.Size = New System.Drawing.Size(71, 16)
        Me.optInpseq.TabIndex = 3
        Me.optInpseq.Text = "Input Seq."
        Me.optInpseq.UseVisualStyleBackColor = True
        '
        'optItem
        '
        Me.optItem.AutoSize = True
        Me.optItem.Location = New System.Drawing.Point(161, 3)
        Me.optItem.Name = "optItem"
        Me.optItem.Size = New System.Drawing.Size(64, 16)
        Me.optItem.TabIndex = 2
        Me.optItem.TabStop = True
        Me.optItem.Text = "Item No."
        Me.optItem.UseVisualStyleBackColor = True
        '
        'optCust
        '
        Me.optCust.AutoSize = True
        Me.optCust.Checked = True
        Me.optCust.Location = New System.Drawing.Point(3, 3)
        Me.optCust.Name = "optCust"
        Me.optCust.Size = New System.Drawing.Size(112, 16)
        Me.optCust.TabIndex = 1
        Me.optCust.TabStop = True
        Me.optCust.Text = "Customer Item No."
        Me.optCust.UseVisualStyleBackColor = True
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(257, 331)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(116, 40)
        Me.cmdShow.TabIndex = 12
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(15, 286)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 12)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Sort By"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.optApprox)
        Me.Panel1.Controls.Add(Me.optExact)
        Me.Panel1.Location = New System.Drawing.Point(179, 87)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(418, 21)
        Me.Panel1.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.optSupY)
        Me.Panel2.Controls.Add(Me.optSupN)
        Me.Panel2.Location = New System.Drawing.Point(179, 114)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(418, 21)
        Me.Panel2.TabIndex = 4
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.optRvsYes)
        Me.Panel3.Controls.Add(Me.optRvsNo)
        Me.Panel3.Location = New System.Drawing.Point(179, 196)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(418, 21)
        Me.Panel3.TabIndex = 8
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.optGroupY)
        Me.Panel4.Controls.Add(Me.optGroupN)
        Me.Panel4.Location = New System.Drawing.Point(179, 223)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(418, 21)
        Me.Panel4.TabIndex = 9
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.optAmtY)
        Me.Panel5.Controls.Add(Me.optAmtN)
        Me.Panel5.Location = New System.Drawing.Point(179, 250)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(418, 21)
        Me.Panel5.TabIndex = 10
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.optCust)
        Me.Panel6.Controls.Add(Me.optItem)
        Me.Panel6.Controls.Add(Me.optInpseq)
        Me.Panel6.Location = New System.Drawing.Point(179, 277)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(418, 21)
        Me.Panel6.TabIndex = 11
        '
        'POR00001
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(634, 412)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cboReportFormat)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtTo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtFm)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "POR00001"
        Me.Text = "POR00001 - Purchase Order Report (POR01)"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents optGroupN As System.Windows.Forms.RadioButton
    Friend WithEvents optGroupY As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents optRvsNo As System.Windows.Forms.RadioButton
    Friend WithEvents optRvsYes As System.Windows.Forms.RadioButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents optSupN As System.Windows.Forms.RadioButton
    Friend WithEvents optSupY As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents optExact As System.Windows.Forms.RadioButton
    Friend WithEvents optApprox As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents optAmtN As System.Windows.Forms.RadioButton
    Friend WithEvents optAmtY As System.Windows.Forms.RadioButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents optItem As System.Windows.Forms.RadioButton
    Friend WithEvents optCust As System.Windows.Forms.RadioButton
    Friend WithEvents optInpseq As System.Windows.Forms.RadioButton
    Friend WithEvents txtTo As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtFm As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboReportFormat As System.Windows.Forms.ComboBox
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
End Class
