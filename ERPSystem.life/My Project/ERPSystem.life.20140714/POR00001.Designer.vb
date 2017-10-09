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
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.grpCriteria = New System.Windows.Forms.GroupBox
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.optAmtN = New System.Windows.Forms.RadioButton
        Me.optAmtY = New System.Windows.Forms.RadioButton
        Me.Label10 = New System.Windows.Forms.Label
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.optGroupN = New System.Windows.Forms.RadioButton
        Me.optGroupY = New System.Windows.Forms.RadioButton
        Me.Label9 = New System.Windows.Forms.Label
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.optRvsNo = New System.Windows.Forms.RadioButton
        Me.optRvsYes = New System.Windows.Forms.RadioButton
        Me.Label8 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Label7 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.txtTo = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtFm = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.optSupN = New System.Windows.Forms.RadioButton
        Me.optSupY = New System.Windows.Forms.RadioButton
        Me.Label5 = New System.Windows.Forms.Label
        Me.panShpDatFormat = New System.Windows.Forms.Panel
        Me.optExact = New System.Windows.Forms.RadioButton
        Me.optApprox = New System.Windows.Forms.RadioButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.grpSortBy = New System.Windows.Forms.GroupBox
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.optInpseq = New System.Windows.Forms.RadioButton
        Me.optItem = New System.Windows.Forms.RadioButton
        Me.optCust = New System.Windows.Forms.RadioButton
        Me.cboReportFormat = New System.Windows.Forms.ComboBox
        Me.cmdShow = New System.Windows.Forms.Button
        Me.grpCriteria.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.panShpDatFormat.SuspendLayout()
        Me.grpSortBy.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(550, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Purchase Order Report"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.Location = New System.Drawing.Point(268, 43)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.Size = New System.Drawing.Size(294, 20)
        Me.txtCoNam.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(180, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Company Name"
        '
        'cboCoCde
        '
        Me.cboCoCde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(99, 43)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(76, 21)
        Me.cboCoCde.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label3.Location = New System.Drawing.Point(14, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Company Code"
        '
        'grpCriteria
        '
        Me.grpCriteria.Controls.Add(Me.Panel6)
        Me.grpCriteria.Controls.Add(Me.Panel5)
        Me.grpCriteria.Controls.Add(Me.Panel4)
        Me.grpCriteria.Controls.Add(Me.Panel3)
        Me.grpCriteria.Controls.Add(Me.Panel2)
        Me.grpCriteria.Controls.Add(Me.Panel1)
        Me.grpCriteria.Controls.Add(Me.panShpDatFormat)
        Me.grpCriteria.Location = New System.Drawing.Point(17, 70)
        Me.grpCriteria.Name = "grpCriteria"
        Me.grpCriteria.Size = New System.Drawing.Size(545, 306)
        Me.grpCriteria.TabIndex = 8
        Me.grpCriteria.TabStop = False
        Me.grpCriteria.Text = "Input Criteria"
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.optAmtN)
        Me.Panel6.Controls.Add(Me.optAmtY)
        Me.Panel6.Controls.Add(Me.Label10)
        Me.Panel6.Location = New System.Drawing.Point(6, 265)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(533, 35)
        Me.Panel6.TabIndex = 6
        '
        'optAmtN
        '
        Me.optAmtN.AutoSize = True
        Me.optAmtN.Location = New System.Drawing.Point(385, 8)
        Me.optAmtN.Name = "optAmtN"
        Me.optAmtN.Size = New System.Drawing.Size(39, 17)
        Me.optAmtN.TabIndex = 2
        Me.optAmtN.TabStop = True
        Me.optAmtN.Text = "No"
        Me.optAmtN.UseVisualStyleBackColor = True
        '
        'optAmtY
        '
        Me.optAmtY.AutoSize = True
        Me.optAmtY.Checked = True
        Me.optAmtY.Location = New System.Drawing.Point(200, 8)
        Me.optAmtY.Name = "optAmtY"
        Me.optAmtY.Size = New System.Drawing.Size(43, 17)
        Me.optAmtY.TabIndex = 1
        Me.optAmtY.TabStop = True
        Me.optAmtY.Text = "Yes"
        Me.optAmtY.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 10)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(73, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Print Amount :"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.optGroupN)
        Me.Panel5.Controls.Add(Me.optGroupY)
        Me.Panel5.Controls.Add(Me.Label9)
        Me.Panel5.Location = New System.Drawing.Point(6, 224)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(533, 35)
        Me.Panel5.TabIndex = 5
        '
        'optGroupN
        '
        Me.optGroupN.AutoSize = True
        Me.optGroupN.Location = New System.Drawing.Point(385, 8)
        Me.optGroupN.Name = "optGroupN"
        Me.optGroupN.Size = New System.Drawing.Size(39, 17)
        Me.optGroupN.TabIndex = 2
        Me.optGroupN.TabStop = True
        Me.optGroupN.Text = "No"
        Me.optGroupN.UseVisualStyleBackColor = True
        '
        'optGroupY
        '
        Me.optGroupY.AutoSize = True
        Me.optGroupY.Checked = True
        Me.optGroupY.Location = New System.Drawing.Point(200, 8)
        Me.optGroupY.Name = "optGroupY"
        Me.optGroupY.Size = New System.Drawing.Size(43, 17)
        Me.optGroupY.TabIndex = 1
        Me.optGroupY.TabStop = True
        Me.optGroupY.Text = "Yes"
        Me.optGroupY.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 10)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(125, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Group New Item Format :"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.optRvsNo)
        Me.Panel4.Controls.Add(Me.optRvsYes)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Location = New System.Drawing.Point(6, 183)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(533, 35)
        Me.Panel4.TabIndex = 4
        '
        'optRvsNo
        '
        Me.optRvsNo.AutoSize = True
        Me.optRvsNo.Checked = True
        Me.optRvsNo.Location = New System.Drawing.Point(385, 8)
        Me.optRvsNo.Name = "optRvsNo"
        Me.optRvsNo.Size = New System.Drawing.Size(39, 17)
        Me.optRvsNo.TabIndex = 2
        Me.optRvsNo.TabStop = True
        Me.optRvsNo.Text = "No"
        Me.optRvsNo.UseVisualStyleBackColor = True
        '
        'optRvsYes
        '
        Me.optRvsYes.AutoSize = True
        Me.optRvsYes.Location = New System.Drawing.Point(200, 8)
        Me.optRvsYes.Name = "optRvsYes"
        Me.optRvsYes.Size = New System.Drawing.Size(43, 17)
        Me.optRvsYes.TabIndex = 1
        Me.optRvsYes.TabStop = True
        Me.optRvsYes.Text = "Yes"
        Me.optRvsYes.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Revised :"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.cboReportFormat)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Location = New System.Drawing.Point(6, 142)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(533, 35)
        Me.Panel3.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 10)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Report Format :"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txtTo)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.txtFm)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Location = New System.Drawing.Point(6, 101)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(533, 35)
        Me.Panel2.TabIndex = 2
        '
        'txtTo
        '
        Me.txtTo.Location = New System.Drawing.Point(364, 7)
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Size = New System.Drawing.Size(145, 20)
        Me.txtTo.TabIndex = 4
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(338, 10)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(20, 13)
        Me.Label12.TabIndex = 3
        Me.Label12.Text = "To"
        '
        'txtFm
        '
        Me.txtFm.Location = New System.Drawing.Point(182, 7)
        Me.txtFm.Name = "txtFm"
        Me.txtFm.Size = New System.Drawing.Size(145, 20)
        Me.txtFm.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(146, 10)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(30, 13)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "From"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Purchase Order No. :"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.optSupN)
        Me.Panel1.Controls.Add(Me.optSupY)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Location = New System.Drawing.Point(6, 60)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(533, 35)
        Me.Panel1.TabIndex = 1
        '
        'optSupN
        '
        Me.optSupN.AutoSize = True
        Me.optSupN.Location = New System.Drawing.Point(385, 8)
        Me.optSupN.Name = "optSupN"
        Me.optSupN.Size = New System.Drawing.Size(39, 17)
        Me.optSupN.TabIndex = 2
        Me.optSupN.TabStop = True
        Me.optSupN.Text = "No"
        Me.optSupN.UseVisualStyleBackColor = True
        '
        'optSupY
        '
        Me.optSupY.AutoSize = True
        Me.optSupY.Checked = True
        Me.optSupY.Location = New System.Drawing.Point(200, 8)
        Me.optSupY.Name = "optSupY"
        Me.optSupY.Size = New System.Drawing.Size(43, 17)
        Me.optSupY.TabIndex = 1
        Me.optSupY.TabStop = True
        Me.optSupY.Text = "Yes"
        Me.optSupY.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(109, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Suppress ZERO Qty :"
        '
        'panShpDatFormat
        '
        Me.panShpDatFormat.Controls.Add(Me.optExact)
        Me.panShpDatFormat.Controls.Add(Me.optApprox)
        Me.panShpDatFormat.Controls.Add(Me.Label4)
        Me.panShpDatFormat.Location = New System.Drawing.Point(6, 19)
        Me.panShpDatFormat.Name = "panShpDatFormat"
        Me.panShpDatFormat.Size = New System.Drawing.Size(533, 35)
        Me.panShpDatFormat.TabIndex = 0
        '
        'optExact
        '
        Me.optExact.AutoSize = True
        Me.optExact.Checked = True
        Me.optExact.Location = New System.Drawing.Point(385, 8)
        Me.optExact.Name = "optExact"
        Me.optExact.Size = New System.Drawing.Size(52, 17)
        Me.optExact.TabIndex = 2
        Me.optExact.TabStop = True
        Me.optExact.Text = "Exact"
        Me.optExact.UseVisualStyleBackColor = True
        '
        'optApprox
        '
        Me.optApprox.AutoSize = True
        Me.optApprox.Location = New System.Drawing.Point(200, 8)
        Me.optApprox.Name = "optApprox"
        Me.optApprox.Size = New System.Drawing.Size(58, 17)
        Me.optApprox.TabIndex = 1
        Me.optApprox.TabStop = True
        Me.optApprox.Text = "Approx"
        Me.optApprox.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Ship Date Format :"
        '
        'grpSortBy
        '
        Me.grpSortBy.Controls.Add(Me.Panel7)
        Me.grpSortBy.Location = New System.Drawing.Point(17, 382)
        Me.grpSortBy.Name = "grpSortBy"
        Me.grpSortBy.Size = New System.Drawing.Size(545, 61)
        Me.grpSortBy.TabIndex = 9
        Me.grpSortBy.TabStop = False
        Me.grpSortBy.Text = "Sort By"
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.optInpseq)
        Me.Panel7.Controls.Add(Me.optItem)
        Me.Panel7.Controls.Add(Me.optCust)
        Me.Panel7.Location = New System.Drawing.Point(6, 19)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(533, 35)
        Me.Panel7.TabIndex = 1
        '
        'optInpseq
        '
        Me.optInpseq.AutoSize = True
        Me.optInpseq.Enabled = False
        Me.optInpseq.Location = New System.Drawing.Point(385, 8)
        Me.optInpseq.Name = "optInpseq"
        Me.optInpseq.Size = New System.Drawing.Size(74, 17)
        Me.optInpseq.TabIndex = 3
        Me.optInpseq.Text = "Input Seq."
        Me.optInpseq.UseVisualStyleBackColor = True
        '
        'optItem
        '
        Me.optItem.AutoSize = True
        Me.optItem.Location = New System.Drawing.Point(245, 8)
        Me.optItem.Name = "optItem"
        Me.optItem.Size = New System.Drawing.Size(65, 17)
        Me.optItem.TabIndex = 2
        Me.optItem.TabStop = True
        Me.optItem.Text = "Item No."
        Me.optItem.UseVisualStyleBackColor = True
        '
        'optCust
        '
        Me.optCust.AutoSize = True
        Me.optCust.Checked = True
        Me.optCust.Location = New System.Drawing.Point(76, 8)
        Me.optCust.Name = "optCust"
        Me.optCust.Size = New System.Drawing.Size(112, 17)
        Me.optCust.TabIndex = 1
        Me.optCust.TabStop = True
        Me.optCust.Text = "Customer Item No."
        Me.optCust.UseVisualStyleBackColor = True
        '
        'cboReportFormat
        '
        Me.cboReportFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReportFormat.FormattingEnabled = True
        Me.cboReportFormat.Location = New System.Drawing.Point(182, 7)
        Me.cboReportFormat.Name = "cboReportFormat"
        Me.cboReportFormat.Size = New System.Drawing.Size(327, 21)
        Me.cboReportFormat.TabIndex = 1
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(229, 449)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(118, 29)
        Me.cmdShow.TabIndex = 11
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'POR00001
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(574, 491)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.grpSortBy)
        Me.Controls.Add(Me.grpCriteria)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "POR00001"
        Me.Text = "POR00001 - Purchase Order Report"
        Me.grpCriteria.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.panShpDatFormat.ResumeLayout(False)
        Me.panShpDatFormat.PerformLayout()
        Me.grpSortBy.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grpCriteria As System.Windows.Forms.GroupBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents optGroupN As System.Windows.Forms.RadioButton
    Friend WithEvents optGroupY As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents optRvsNo As System.Windows.Forms.RadioButton
    Friend WithEvents optRvsYes As System.Windows.Forms.RadioButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents optSupN As System.Windows.Forms.RadioButton
    Friend WithEvents optSupY As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents panShpDatFormat As System.Windows.Forms.Panel
    Friend WithEvents optExact As System.Windows.Forms.RadioButton
    Friend WithEvents optApprox As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents optAmtN As System.Windows.Forms.RadioButton
    Friend WithEvents optAmtY As System.Windows.Forms.RadioButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents grpSortBy As System.Windows.Forms.GroupBox
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents optItem As System.Windows.Forms.RadioButton
    Friend WithEvents optCust As System.Windows.Forms.RadioButton
    Friend WithEvents optInpseq As System.Windows.Forms.RadioButton
    Friend WithEvents txtTo As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtFm As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboReportFormat As System.Windows.Forms.ComboBox
    Friend WithEvents cmdShow As System.Windows.Forms.Button
End Class
