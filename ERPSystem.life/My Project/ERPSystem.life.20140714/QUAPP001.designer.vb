<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QUAPP001
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
        Me.btcQUAPP001 = New ERPSystem.BaseTabControl
        Me.tpQUXLS001_1 = New System.Windows.Forms.TabPage
        Me.cboCus2No = New System.Windows.Forms.ComboBox
        Me.lblCus2No = New System.Windows.Forms.Label
        Me.cboCus1No = New System.Windows.Forms.ComboBox
        Me.lblCus1No = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkQutUpd = New System.Windows.Forms.CheckBox
        Me.chkQutNew = New System.Windows.Forms.CheckBox
        Me.lblCoNam = New System.Windows.Forms.Label
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.txtQutNo = New System.Windows.Forms.TextBox
        Me.lblQutNo = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmdOK = New System.Windows.Forms.Button
        Me.tpQUXLS001_2 = New System.Windows.Forms.TabPage
        Me.cmdUpload = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.chkallmatch = New System.Windows.Forms.CheckBox
        Me.chknomsg = New System.Windows.Forms.CheckBox
        Me.txtQutNo2 = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.gbStatus = New System.Windows.Forms.GroupBox
        Me.optStatusF = New System.Windows.Forms.RadioButton
        Me.optStatusR = New System.Windows.Forms.RadioButton
        Me.optStatusN = New System.Windows.Forms.RadioButton
        Me.optStatusG = New System.Windows.Forms.RadioButton
        Me.Label5 = New System.Windows.Forms.Label
        Me.grdItem = New System.Windows.Forms.DataGridView
        Me.cmdClose = New System.Windows.Forms.Button
        Me.cmdApply = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdClear = New System.Windows.Forms.Button
        Me.txtFromApply = New System.Windows.Forms.TextBox
        Me.cmdGen = New System.Windows.Forms.Button
        Me.txtToApply = New System.Windows.Forms.TextBox
        Me.btcQUAPP001.SuspendLayout()
        Me.tpQUXLS001_1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tpQUXLS001_2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.gbStatus.SuspendLayout()
        CType(Me.grdItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btcQUAPP001
        '
        Me.btcQUAPP001.Controls.Add(Me.tpQUXLS001_1)
        Me.btcQUAPP001.Controls.Add(Me.tpQUXLS001_2)
        Me.btcQUAPP001.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.btcQUAPP001.ItemSize = New System.Drawing.Size(110, 18)
        Me.btcQUAPP001.Location = New System.Drawing.Point(-1, 1)
        Me.btcQUAPP001.Name = "btcQUAPP001"
        Me.btcQUAPP001.SelectedIndex = 0
        Me.btcQUAPP001.Size = New System.Drawing.Size(929, 615)
        Me.btcQUAPP001.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.btcQUAPP001.TabIndex = 1
        '
        'tpQUXLS001_1
        '
        Me.tpQUXLS001_1.Controls.Add(Me.cboCus2No)
        Me.tpQUXLS001_1.Controls.Add(Me.lblCus2No)
        Me.tpQUXLS001_1.Controls.Add(Me.cboCus1No)
        Me.tpQUXLS001_1.Controls.Add(Me.lblCus1No)
        Me.tpQUXLS001_1.Controls.Add(Me.GroupBox1)
        Me.tpQUXLS001_1.Controls.Add(Me.lblCoNam)
        Me.tpQUXLS001_1.Controls.Add(Me.cboCoCde)
        Me.tpQUXLS001_1.Controls.Add(Me.txtCoNam)
        Me.tpQUXLS001_1.Controls.Add(Me.txtQutNo)
        Me.tpQUXLS001_1.Controls.Add(Me.lblQutNo)
        Me.tpQUXLS001_1.Controls.Add(Me.Label6)
        Me.tpQUXLS001_1.Controls.Add(Me.cmdOK)
        Me.tpQUXLS001_1.Location = New System.Drawing.Point(4, 22)
        Me.tpQUXLS001_1.Name = "tpQUXLS001_1"
        Me.tpQUXLS001_1.Padding = New System.Windows.Forms.Padding(3)
        Me.tpQUXLS001_1.Size = New System.Drawing.Size(921, 589)
        Me.tpQUXLS001_1.TabIndex = 0
        Me.tpQUXLS001_1.Text = "(1) Apps#"
        Me.tpQUXLS001_1.UseVisualStyleBackColor = True
        '
        'cboCus2No
        '
        Me.cboCus2No.FormattingEnabled = True
        Me.cboCus2No.Location = New System.Drawing.Point(263, 157)
        Me.cboCus2No.Name = "cboCus2No"
        Me.cboCus2No.Size = New System.Drawing.Size(250, 21)
        Me.cboCus2No.TabIndex = 423
        '
        'lblCus2No
        '
        Me.lblCus2No.AutoSize = True
        Me.lblCus2No.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblCus2No.Location = New System.Drawing.Point(145, 160)
        Me.lblCus2No.Name = "lblCus2No"
        Me.lblCus2No.Size = New System.Drawing.Size(105, 13)
        Me.lblCus2No.TabIndex = 424
        Me.lblCus2No.Text = "Secondary Customer"
        '
        'cboCus1No
        '
        Me.cboCus1No.FormattingEnabled = True
        Me.cboCus1No.Location = New System.Drawing.Point(263, 128)
        Me.cboCus1No.Name = "cboCus1No"
        Me.cboCus1No.Size = New System.Drawing.Size(250, 21)
        Me.cboCus1No.TabIndex = 421
        '
        'lblCus1No
        '
        Me.lblCus1No.AutoSize = True
        Me.lblCus1No.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblCus1No.Location = New System.Drawing.Point(145, 131)
        Me.lblCus1No.Name = "lblCus1No"
        Me.lblCus1No.Size = New System.Drawing.Size(88, 13)
        Me.lblCus1No.TabIndex = 422
        Me.lblCus1No.Text = "Primary Customer"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkQutUpd)
        Me.GroupBox1.Controls.Add(Me.chkQutNew)
        Me.GroupBox1.Location = New System.Drawing.Point(664, 462)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(193, 34)
        Me.GroupBox1.TabIndex = 418
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Visible = False
        '
        'chkQutUpd
        '
        Me.chkQutUpd.AutoSize = True
        Me.chkQutUpd.Location = New System.Drawing.Point(112, 12)
        Me.chkQutUpd.Name = "chkQutUpd"
        Me.chkQutUpd.Size = New System.Drawing.Size(61, 17)
        Me.chkQutUpd.TabIndex = 1
        Me.chkQutUpd.Text = "Update"
        Me.chkQutUpd.UseVisualStyleBackColor = True
        Me.chkQutUpd.Visible = False
        '
        'chkQutNew
        '
        Me.chkQutNew.AutoSize = True
        Me.chkQutNew.Checked = True
        Me.chkQutNew.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkQutNew.Location = New System.Drawing.Point(31, 12)
        Me.chkQutNew.Name = "chkQutNew"
        Me.chkQutNew.Size = New System.Drawing.Size(48, 17)
        Me.chkQutNew.TabIndex = 0
        Me.chkQutNew.Text = "New"
        Me.chkQutNew.UseVisualStyleBackColor = True
        Me.chkQutNew.Visible = False
        '
        'lblCoNam
        '
        Me.lblCoNam.AutoSize = True
        Me.lblCoNam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblCoNam.Location = New System.Drawing.Point(332, 99)
        Me.lblCoNam.Name = "lblCoNam"
        Me.lblCoNam.Size = New System.Drawing.Size(85, 13)
        Me.lblCoNam.TabIndex = 417
        Me.lblCoNam.Text = "Company Name:"
        '
        'cboCoCde
        '
        Me.cboCoCde.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(242, 95)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(84, 21)
        Me.cboCoCde.TabIndex = 264
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.SystemColors.MenuBar
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCoNam.ForeColor = System.Drawing.Color.DimGray
        Me.txtCoNam.Location = New System.Drawing.Point(423, 95)
        Me.txtCoNam.MaxLength = 30
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.ReadOnly = True
        Me.txtCoNam.Size = New System.Drawing.Size(316, 20)
        Me.txtCoNam.TabIndex = 265
        '
        'txtQutNo
        '
        Me.txtQutNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtQutNo.Location = New System.Drawing.Point(304, 241)
        Me.txtQutNo.MaxLength = 10
        Me.txtQutNo.Name = "txtQutNo"
        Me.txtQutNo.Size = New System.Drawing.Size(143, 20)
        Me.txtQutNo.TabIndex = 261
        '
        'lblQutNo
        '
        Me.lblQutNo.AutoSize = True
        Me.lblQutNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblQutNo.ForeColor = System.Drawing.Color.Red
        Me.lblQutNo.Location = New System.Drawing.Point(165, 244)
        Me.lblQutNo.Name = "lblQutNo"
        Me.lblQutNo.Size = New System.Drawing.Size(130, 13)
        Me.lblQutNo.TabIndex = 263
        Me.lblQutNo.Text = "Apps Temp Quotation No:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label6.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label6.Location = New System.Drawing.Point(145, 99)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 13)
        Me.Label6.TabIndex = 262
        Me.Label6.Text = "Company Code:"
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(554, 248)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(156, 23)
        Me.cmdOK.TabIndex = 35
        Me.cmdOK.Text = "&OK (apps)"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'tpQUXLS001_2
        '
        Me.tpQUXLS001_2.Controls.Add(Me.cmdUpload)
        Me.tpQUXLS001_2.Controls.Add(Me.GroupBox2)
        Me.tpQUXLS001_2.Controls.Add(Me.txtQutNo2)
        Me.tpQUXLS001_2.Controls.Add(Me.Label7)
        Me.tpQUXLS001_2.Controls.Add(Me.gbStatus)
        Me.tpQUXLS001_2.Controls.Add(Me.Label5)
        Me.tpQUXLS001_2.Controls.Add(Me.grdItem)
        Me.tpQUXLS001_2.Controls.Add(Me.cmdClose)
        Me.tpQUXLS001_2.Controls.Add(Me.cmdApply)
        Me.tpQUXLS001_2.Controls.Add(Me.Label4)
        Me.tpQUXLS001_2.Controls.Add(Me.cmdClear)
        Me.tpQUXLS001_2.Controls.Add(Me.txtFromApply)
        Me.tpQUXLS001_2.Controls.Add(Me.cmdGen)
        Me.tpQUXLS001_2.Controls.Add(Me.txtToApply)
        Me.tpQUXLS001_2.Location = New System.Drawing.Point(4, 22)
        Me.tpQUXLS001_2.Name = "tpQUXLS001_2"
        Me.tpQUXLS001_2.Padding = New System.Windows.Forms.Padding(3)
        Me.tpQUXLS001_2.Size = New System.Drawing.Size(921, 589)
        Me.tpQUXLS001_2.TabIndex = 1
        Me.tpQUXLS001_2.Text = "(2) Approval"
        Me.tpQUXLS001_2.UseVisualStyleBackColor = True
        '
        'cmdUpload
        '
        Me.cmdUpload.Location = New System.Drawing.Point(288, 49)
        Me.cmdUpload.Name = "cmdUpload"
        Me.cmdUpload.Size = New System.Drawing.Size(164, 23)
        Me.cmdUpload.TabIndex = 424
        Me.cmdUpload.Text = "&Re-Upload Apps"
        Me.cmdUpload.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkallmatch)
        Me.GroupBox2.Controls.Add(Me.chknomsg)
        Me.GroupBox2.Location = New System.Drawing.Point(659, 9)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(226, 69)
        Me.GroupBox2.TabIndex = 423
        Me.GroupBox2.TabStop = False
        '
        'chkallmatch
        '
        Me.chkallmatch.AutoSize = True
        Me.chkallmatch.Location = New System.Drawing.Point(31, 40)
        Me.chkallmatch.Name = "chkallmatch"
        Me.chkallmatch.Size = New System.Drawing.Size(147, 17)
        Me.chkallmatch.TabIndex = 1
        Me.chkallmatch.Text = "Gen. All match Items Only"
        Me.chkallmatch.UseVisualStyleBackColor = True
        '
        'chknomsg
        '
        Me.chknomsg.AutoSize = True
        Me.chknomsg.Location = New System.Drawing.Point(31, 12)
        Me.chknomsg.Name = "chknomsg"
        Me.chknomsg.Size = New System.Drawing.Size(107, 17)
        Me.chknomsg.TabIndex = 0
        Me.chknomsg.Text = "No Message Box"
        Me.chknomsg.UseVisualStyleBackColor = True
        '
        'txtQutNo2
        '
        Me.txtQutNo2.Enabled = False
        Me.txtQutNo2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtQutNo2.Location = New System.Drawing.Point(373, 20)
        Me.txtQutNo2.MaxLength = 10
        Me.txtQutNo2.Name = "txtQutNo2"
        Me.txtQutNo2.Size = New System.Drawing.Size(104, 20)
        Me.txtQutNo2.TabIndex = 421
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(285, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 13)
        Me.Label7.TabIndex = 422
        Me.Label7.Text = "Quotation No:"
        '
        'gbStatus
        '
        Me.gbStatus.Controls.Add(Me.optStatusF)
        Me.gbStatus.Controls.Add(Me.optStatusR)
        Me.gbStatus.Controls.Add(Me.optStatusN)
        Me.gbStatus.Controls.Add(Me.optStatusG)
        Me.gbStatus.Location = New System.Drawing.Point(520, 6)
        Me.gbStatus.Name = "gbStatus"
        Me.gbStatus.Size = New System.Drawing.Size(116, 72)
        Me.gbStatus.TabIndex = 412
        Me.gbStatus.TabStop = False
        '
        'optStatusF
        '
        Me.optStatusF.AutoSize = True
        Me.optStatusF.Location = New System.Drawing.Point(123, 43)
        Me.optStatusF.Name = "optStatusF"
        Me.optStatusF.Size = New System.Drawing.Size(56, 17)
        Me.optStatusF.TabIndex = 413
        Me.optStatusF.Text = "F - Fail"
        Me.optStatusF.UseVisualStyleBackColor = True
        Me.optStatusF.Visible = False
        '
        'optStatusR
        '
        Me.optStatusR.AutoSize = True
        Me.optStatusR.Location = New System.Drawing.Point(123, 17)
        Me.optStatusR.Name = "optStatusR"
        Me.optStatusR.Size = New System.Drawing.Size(73, 17)
        Me.optStatusR.TabIndex = 2
        Me.optStatusR.Text = "R - Reject"
        Me.optStatusR.UseVisualStyleBackColor = True
        Me.optStatusR.Visible = False
        '
        'optStatusN
        '
        Me.optStatusN.AutoSize = True
        Me.optStatusN.Location = New System.Drawing.Point(21, 43)
        Me.optStatusN.Name = "optStatusN"
        Me.optStatusN.Size = New System.Drawing.Size(68, 17)
        Me.optStatusN.TabIndex = 1
        Me.optStatusN.Text = "N - None"
        Me.optStatusN.UseVisualStyleBackColor = True
        '
        'optStatusG
        '
        Me.optStatusG.AutoSize = True
        Me.optStatusG.Location = New System.Drawing.Point(21, 17)
        Me.optStatusG.Name = "optStatusG"
        Me.optStatusG.Size = New System.Drawing.Size(85, 17)
        Me.optStatusG.TabIndex = 0
        Me.optStatusG.Text = "Y - Generate"
        Me.optStatusG.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(517, 94)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(18, 13)
        Me.Label5.TabIndex = 412
        Me.Label5.Text = "ID"
        '
        'grdItem
        '
        Me.grdItem.AllowUserToAddRows = False
        Me.grdItem.AllowUserToDeleteRows = False
        Me.grdItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdItem.Location = New System.Drawing.Point(6, 118)
        Me.grdItem.Name = "grdItem"
        Me.grdItem.RowHeadersWidth = 20
        Me.grdItem.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.grdItem.RowTemplate.Height = 16
        Me.grdItem.Size = New System.Drawing.Size(912, 468)
        Me.grdItem.TabIndex = 43
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(194, 49)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 23)
        Me.cmdClose.TabIndex = 39
        Me.cmdClose.Text = "&Exit"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdApply
        '
        Me.cmdApply.Location = New System.Drawing.Point(659, 89)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.Size = New System.Drawing.Size(75, 23)
        Me.cmdApply.TabIndex = 40
        Me.cmdApply.Text = "&Apply"
        Me.cmdApply.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label4.Location = New System.Drawing.Point(587, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(20, 13)
        Me.Label4.TabIndex = 411
        Me.Label4.Text = "To"
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(113, 49)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(75, 23)
        Me.cmdClear.TabIndex = 37
        Me.cmdClear.Text = "&Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'txtFromApply
        '
        Me.txtFromApply.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtFromApply.Location = New System.Drawing.Point(541, 91)
        Me.txtFromApply.MaxLength = 4
        Me.txtFromApply.Name = "txtFromApply"
        Me.txtFromApply.Size = New System.Drawing.Size(40, 20)
        Me.txtFromApply.TabIndex = 408
        '
        'cmdGen
        '
        Me.cmdGen.Location = New System.Drawing.Point(32, 49)
        Me.cmdGen.Name = "cmdGen"
        Me.cmdGen.Size = New System.Drawing.Size(75, 23)
        Me.cmdGen.TabIndex = 36
        Me.cmdGen.Text = "&Generate"
        Me.cmdGen.UseVisualStyleBackColor = True
        '
        'txtToApply
        '
        Me.txtToApply.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtToApply.Location = New System.Drawing.Point(613, 91)
        Me.txtToApply.MaxLength = 4
        Me.txtToApply.Name = "txtToApply"
        Me.txtToApply.Size = New System.Drawing.Size(40, 20)
        Me.txtToApply.TabIndex = 409
        '
        'QUAPP001
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(929, 615)
        Me.Controls.Add(Me.btcQUAPP001)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "QUAPP001"
        Me.Text = "QUAPP001 - Apps Upload for Quotation Generation"
        Me.btcQUAPP001.ResumeLayout(False)
        Me.tpQUXLS001_1.ResumeLayout(False)
        Me.tpQUXLS001_1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tpQUXLS001_2.ResumeLayout(False)
        Me.tpQUXLS001_2.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.gbStatus.ResumeLayout(False)
        Me.gbStatus.PerformLayout()
        CType(Me.grdItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btcQUAPP001 As ERPSystem.BaseTabControl
    Friend WithEvents tpQUXLS001_1 As System.Windows.Forms.TabPage
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents tpQUXLS001_2 As System.Windows.Forms.TabPage
    Friend WithEvents grdItem As System.Windows.Forms.DataGridView
    Friend WithEvents txtToApply As System.Windows.Forms.TextBox
    Friend WithEvents txtFromApply As System.Windows.Forms.TextBox
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents optStatusR As System.Windows.Forms.RadioButton
    Friend WithEvents optStatusN As System.Windows.Forms.RadioButton
    Friend WithEvents optStatusG As System.Windows.Forms.RadioButton
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdGen As System.Windows.Forms.Button
    Friend WithEvents gbStatus As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents optStatusF As System.Windows.Forms.RadioButton
    Friend WithEvents txtQutNo As System.Windows.Forms.TextBox
    Friend WithEvents lblQutNo As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents lblCoNam As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkQutUpd As System.Windows.Forms.CheckBox
    Friend WithEvents chkQutNew As System.Windows.Forms.CheckBox
    Friend WithEvents txtQutNo2 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboCus2No As System.Windows.Forms.ComboBox
    Friend WithEvents lblCus2No As System.Windows.Forms.Label
    Friend WithEvents cboCus1No As System.Windows.Forms.ComboBox
    Friend WithEvents lblCus1No As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkallmatch As System.Windows.Forms.CheckBox
    Friend WithEvents chknomsg As System.Windows.Forms.CheckBox
    Friend WithEvents cmdUpload As System.Windows.Forms.Button
End Class
