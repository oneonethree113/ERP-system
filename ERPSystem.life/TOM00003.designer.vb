<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TOM00003
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TOM00003))
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.grpDocNo = New System.Windows.Forms.GroupBox
        Me.optUnr = New System.Windows.Forms.RadioButton
        Me.optRel = New System.Windows.Forms.RadioButton
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtToFactory = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtFromFactory = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtResult = New System.Windows.Forms.TextBox
        Me.cmdShow = New System.Windows.Forms.Button
        Me.lblNoFm = New System.Windows.Forms.Label
        Me.grpDocNo.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(171, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(306, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tentative Order Release/Unrelease"
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.Color.White
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.Location = New System.Drawing.Point(324, 43)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.Size = New System.Drawing.Size(303, 22)
        Me.txtCoNam.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(231, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Company Name"
        '
        'cboCoCde
        '
        Me.cboCoCde.BackColor = System.Drawing.Color.White
        Me.cboCoCde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(112, 43)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(107, 20)
        Me.cboCoCde.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(13, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 12)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Company Code"
        '
        'grpDocNo
        '
        Me.grpDocNo.Controls.Add(Me.optUnr)
        Me.grpDocNo.Controls.Add(Me.optRel)
        Me.grpDocNo.Location = New System.Drawing.Point(160, 104)
        Me.grpDocNo.Name = "grpDocNo"
        Me.grpDocNo.Size = New System.Drawing.Size(467, 30)
        Me.grpDocNo.TabIndex = 5
        Me.grpDocNo.TabStop = False
        '
        'optUnr
        '
        Me.optUnr.AutoSize = True
        Me.optUnr.Location = New System.Drawing.Point(281, 10)
        Me.optUnr.Name = "optUnr"
        Me.optUnr.Size = New System.Drawing.Size(68, 16)
        Me.optUnr.TabIndex = 5
        Me.optUnr.Text = "Unrelease"
        Me.optUnr.UseVisualStyleBackColor = True
        '
        'optRel
        '
        Me.optRel.AutoSize = True
        Me.optRel.Checked = True
        Me.optRel.Location = New System.Drawing.Point(78, 10)
        Me.optRel.Name = "optRel"
        Me.optRel.Size = New System.Drawing.Size(58, 16)
        Me.optRel.TabIndex = 4
        Me.optRel.TabStop = True
        Me.optRel.Text = "Release"
        Me.optRel.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 114)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 12)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Action"
        '
        'txtToFactory
        '
        Me.txtToFactory.Location = New System.Drawing.Point(453, 78)
        Me.txtToFactory.Name = "txtToFactory"
        Me.txtToFactory.Size = New System.Drawing.Size(121, 22)
        Me.txtToFactory.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(402, 83)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(18, 12)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "To"
        '
        'txtFromFactory
        '
        Me.txtFromFactory.Location = New System.Drawing.Point(219, 78)
        Me.txtFromFactory.Name = "txtFromFactory"
        Me.txtFromFactory.Size = New System.Drawing.Size(121, 22)
        Me.txtFromFactory.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(158, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 12)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "From"
        '
        'txtResult
        '
        Me.txtResult.BackColor = System.Drawing.Color.White
        Me.txtResult.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtResult.ForeColor = System.Drawing.Color.Black
        Me.txtResult.Location = New System.Drawing.Point(2, 195)
        Me.txtResult.Multiline = True
        Me.txtResult.Name = "txtResult"
        Me.txtResult.ReadOnly = True
        Me.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtResult.Size = New System.Drawing.Size(630, 216)
        Me.txtResult.TabIndex = 6
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(259, 167)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(140, 22)
        Me.cmdShow.TabIndex = 7
        Me.cmdShow.Text = "Run"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'lblNoFm
        '
        Me.lblNoFm.AutoSize = True
        Me.lblNoFm.Location = New System.Drawing.Point(13, 82)
        Me.lblNoFm.Name = "lblNoFm"
        Me.lblNoFm.Size = New System.Drawing.Size(98, 12)
        Me.lblNoFm.TabIndex = 8
        Me.lblNoFm.Text = "Tentative Order No."
        '
        'TOM00003
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(634, 411)
        Me.Controls.Add(Me.lblNoFm)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.txtToFactory)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtResult)
        Me.Controls.Add(Me.txtFromFactory)
        Me.Controls.Add(Me.grpDocNo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "TOM00003"
        Me.Text = "TOM00003 - Release/Unrelease Tentative Order (TOM03)"
        Me.grpDocNo.ResumeLayout(False)
        Me.grpDocNo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grpDocNo As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents optUnr As System.Windows.Forms.RadioButton
    Friend WithEvents optRel As System.Windows.Forms.RadioButton
    Friend WithEvents txtToFactory As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFromFactory As System.Windows.Forms.TextBox
    Friend WithEvents txtResult As System.Windows.Forms.TextBox
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblNoFm As System.Windows.Forms.Label
End Class
