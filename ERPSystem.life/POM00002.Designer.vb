<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class POM00002
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(POM00002))
        Me.lblHead = New System.Windows.Forms.Label
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboDocTyp = New System.Windows.Forms.ComboBox
        Me.cmdShow = New System.Windows.Forms.Button
        Me.txtResult = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtFromFactory = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtToFactory = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.optRel = New System.Windows.Forms.RadioButton
        Me.optUnr = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblHead
        '
        Me.lblHead.AutoSize = True
        Me.lblHead.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.lblHead.ForeColor = System.Drawing.Color.Blue
        Me.lblHead.Location = New System.Drawing.Point(140, 4)
        Me.lblHead.Name = "lblHead"
        Me.lblHead.Size = New System.Drawing.Size(352, 25)
        Me.lblHead.TabIndex = 1
        Me.lblHead.Text = "Release/Unrelease Purchase Order"
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.Color.White
        Me.txtCoNam.Location = New System.Drawing.Point(309, 39)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.ReadOnly = True
        Me.txtCoNam.Size = New System.Drawing.Size(297, 22)
        Me.txtCoNam.TabIndex = 2
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(215, 41)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(81, 12)
        Me.Label35.TabIndex = 7
        Me.Label35.Text = "Company Name"
        '
        'cboCoCde
        '
        Me.cboCoCde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(122, 38)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(72, 20)
        Me.cboCoCde.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.Blue
        Me.Label15.Location = New System.Drawing.Point(30, 41)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(79, 12)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "Company Code"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(114, 164)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 12)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Doc. Type"
        Me.Label1.Visible = False
        '
        'cboDocTyp
        '
        Me.cboDocTyp.FormattingEnabled = True
        Me.cboDocTyp.Location = New System.Drawing.Point(177, 162)
        Me.cboDocTyp.Name = "cboDocTyp"
        Me.cboDocTyp.Size = New System.Drawing.Size(74, 20)
        Me.cboDocTyp.TabIndex = 8
        Me.cboDocTyp.Visible = False
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(279, 162)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(75, 25)
        Me.cmdShow.TabIndex = 9
        Me.cmdShow.Text = "&Run"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'txtResult
        '
        Me.txtResult.BackColor = System.Drawing.Color.White
        Me.txtResult.ForeColor = System.Drawing.Color.Black
        Me.txtResult.Location = New System.Drawing.Point(2, 202)
        Me.txtResult.Multiline = True
        Me.txtResult.Name = "txtResult"
        Me.txtResult.ReadOnly = True
        Me.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtResult.Size = New System.Drawing.Size(629, 207)
        Me.txtResult.TabIndex = 10
        Me.txtResult.Text = "Text1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 12)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "From"
        '
        'txtFromFactory
        '
        Me.txtFromFactory.Location = New System.Drawing.Point(63, 23)
        Me.txtFromFactory.Name = "txtFromFactory"
        Me.txtFromFactory.Size = New System.Drawing.Size(121, 22)
        Me.txtFromFactory.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(212, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(18, 12)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "To"
        '
        'txtToFactory
        '
        Me.txtToFactory.Location = New System.Drawing.Point(256, 23)
        Me.txtToFactory.Name = "txtToFactory"
        Me.txtToFactory.Size = New System.Drawing.Size(121, 22)
        Me.txtToFactory.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Action"
        '
        'optRel
        '
        Me.optRel.AutoSize = True
        Me.optRel.Checked = True
        Me.optRel.Location = New System.Drawing.Point(108, 57)
        Me.optRel.Name = "optRel"
        Me.optRel.Size = New System.Drawing.Size(58, 16)
        Me.optRel.TabIndex = 6
        Me.optRel.TabStop = True
        Me.optRel.Text = "Release"
        Me.optRel.UseVisualStyleBackColor = True
        '
        'optUnr
        '
        Me.optUnr.AutoSize = True
        Me.optUnr.Location = New System.Drawing.Point(239, 57)
        Me.optUnr.Name = "optUnr"
        Me.optUnr.Size = New System.Drawing.Size(68, 16)
        Me.optUnr.TabIndex = 7
        Me.optUnr.TabStop = True
        Me.optUnr.Text = "Unrelease"
        Me.optUnr.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optUnr)
        Me.GroupBox1.Controls.Add(Me.optRel)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtToFactory)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtFromFactory)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(117, 70)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(400, 80)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Document No."
        '
        'POM00002
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 412)
        Me.Controls.Add(Me.txtResult)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.cboDocTyp)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.lblHead)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "POM00002"
        Me.Text = "POM00002 - Release/Unrelease Purchase Order"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblHead As System.Windows.Forms.Label
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboDocTyp As System.Windows.Forms.ComboBox
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents txtResult As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFromFactory As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtToFactory As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents optRel As System.Windows.Forms.RadioButton
    Friend WithEvents optUnr As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
