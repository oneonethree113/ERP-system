<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SCM00001_OrgSCst
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
        Me.grpSCCost = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblVenno = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblItmCstCur_org = New System.Windows.Forms.Label
        Me.txtItmCst_org = New System.Windows.Forms.TextBox
        Me.txtTtlBOMCst_org = New System.Windows.Forms.TextBox
        Me.lblTtlBOMCstCur_org = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.lblIMPeriod = New System.Windows.Forms.Label
        Me.txtTtlCst_org = New System.Windows.Forms.TextBox
        Me.lblTtlCstCur_org = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtDVTtlCst_org = New System.Windows.Forms.TextBox
        Me.lblDVTtlCstCur_org = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtDVTtlBOMCst_org = New System.Windows.Forms.TextBox
        Me.lblDVTtlBOMCstCur_org = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtDVItmCst_org = New System.Windows.Forms.TextBox
        Me.lblDVItmCstCur_org = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.cmdOK = New System.Windows.Forms.Button
        Me.grpSCCost.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpSCCost
        '
        Me.grpSCCost.Controls.Add(Me.txtDVTtlCst_org)
        Me.grpSCCost.Controls.Add(Me.lblDVTtlCstCur_org)
        Me.grpSCCost.Controls.Add(Me.Label12)
        Me.grpSCCost.Controls.Add(Me.txtDVTtlBOMCst_org)
        Me.grpSCCost.Controls.Add(Me.lblDVTtlBOMCstCur_org)
        Me.grpSCCost.Controls.Add(Me.Label14)
        Me.grpSCCost.Controls.Add(Me.txtDVItmCst_org)
        Me.grpSCCost.Controls.Add(Me.lblDVItmCstCur_org)
        Me.grpSCCost.Controls.Add(Me.Label16)
        Me.grpSCCost.Controls.Add(Me.txtTtlCst_org)
        Me.grpSCCost.Controls.Add(Me.lblTtlCstCur_org)
        Me.grpSCCost.Controls.Add(Me.Label10)
        Me.grpSCCost.Controls.Add(Me.lblIMPeriod)
        Me.grpSCCost.Controls.Add(Me.txtTtlBOMCst_org)
        Me.grpSCCost.Controls.Add(Me.lblTtlBOMCstCur_org)
        Me.grpSCCost.Controls.Add(Me.Label8)
        Me.grpSCCost.Controls.Add(Me.txtItmCst_org)
        Me.grpSCCost.Controls.Add(Me.lblItmCstCur_org)
        Me.grpSCCost.Controls.Add(Me.Label5)
        Me.grpSCCost.Controls.Add(Me.Label4)
        Me.grpSCCost.Controls.Add(Me.Label3)
        Me.grpSCCost.Controls.Add(Me.lblVenno)
        Me.grpSCCost.Controls.Add(Me.Label1)
        Me.grpSCCost.Location = New System.Drawing.Point(12, 12)
        Me.grpSCCost.Name = "grpSCCost"
        Me.grpSCCost.Size = New System.Drawing.Size(479, 165)
        Me.grpSCCost.TabIndex = 0
        Me.grpSCCost.TabStop = False
        Me.grpSCCost.Text = "Original SC Costs"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Prod. Vendor :"
        '
        'lblVenno
        '
        Me.lblVenno.AutoSize = True
        Me.lblVenno.Location = New System.Drawing.Point(114, 27)
        Me.lblVenno.Name = "lblVenno"
        Me.lblVenno.Size = New System.Drawing.Size(35, 13)
        Me.lblVenno.TabIndex = 1
        Me.lblVenno.Text = "XXXX"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(260, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "IM Period :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(260, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "D. V. :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 82)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Itm Cst"
        '
        'lblItmCstCur_org
        '
        Me.lblItmCstCur_org.AutoSize = True
        Me.lblItmCstCur_org.Location = New System.Drawing.Point(87, 82)
        Me.lblItmCstCur_org.Name = "lblItmCstCur_org"
        Me.lblItmCstCur_org.Size = New System.Drawing.Size(30, 13)
        Me.lblItmCstCur_org.TabIndex = 7
        Me.lblItmCstCur_org.Text = "USD"
        Me.lblItmCstCur_org.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtItmCst_org
        '
        Me.txtItmCst_org.BackColor = System.Drawing.Color.White
        Me.txtItmCst_org.Enabled = False
        Me.txtItmCst_org.ForeColor = System.Drawing.Color.Black
        Me.txtItmCst_org.Location = New System.Drawing.Point(117, 79)
        Me.txtItmCst_org.Name = "txtItmCst_org"
        Me.txtItmCst_org.Size = New System.Drawing.Size(100, 20)
        Me.txtItmCst_org.TabIndex = 8
        '
        'txtTtlBOMCst_org
        '
        Me.txtTtlBOMCst_org.BackColor = System.Drawing.Color.White
        Me.txtTtlBOMCst_org.Enabled = False
        Me.txtTtlBOMCst_org.ForeColor = System.Drawing.Color.Black
        Me.txtTtlBOMCst_org.Location = New System.Drawing.Point(117, 105)
        Me.txtTtlBOMCst_org.Name = "txtTtlBOMCst_org"
        Me.txtTtlBOMCst_org.Size = New System.Drawing.Size(100, 20)
        Me.txtTtlBOMCst_org.TabIndex = 11
        '
        'lblTtlBOMCstCur_org
        '
        Me.lblTtlBOMCstCur_org.AutoSize = True
        Me.lblTtlBOMCstCur_org.Location = New System.Drawing.Point(87, 108)
        Me.lblTtlBOMCstCur_org.Name = "lblTtlBOMCstCur_org"
        Me.lblTtlBOMCstCur_org.Size = New System.Drawing.Size(30, 13)
        Me.lblTtlBOMCstCur_org.TabIndex = 10
        Me.lblTtlBOMCstCur_org.Text = "USD"
        Me.lblTtlBOMCstCur_org.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(18, 108)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 13)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "TTL BOM Cst"
        '
        'lblIMPeriod
        '
        Me.lblIMPeriod.AutoSize = True
        Me.lblIMPeriod.Location = New System.Drawing.Point(339, 27)
        Me.lblIMPeriod.Name = "lblIMPeriod"
        Me.lblIMPeriod.Size = New System.Drawing.Size(46, 13)
        Me.lblIMPeriod.TabIndex = 3
        Me.lblIMPeriod.Text = "9999-99"
        '
        'txtTtlCst_org
        '
        Me.txtTtlCst_org.BackColor = System.Drawing.Color.White
        Me.txtTtlCst_org.Enabled = False
        Me.txtTtlCst_org.ForeColor = System.Drawing.Color.Black
        Me.txtTtlCst_org.Location = New System.Drawing.Point(117, 131)
        Me.txtTtlCst_org.Name = "txtTtlCst_org"
        Me.txtTtlCst_org.Size = New System.Drawing.Size(100, 20)
        Me.txtTtlCst_org.TabIndex = 14
        '
        'lblTtlCstCur_org
        '
        Me.lblTtlCstCur_org.AutoSize = True
        Me.lblTtlCstCur_org.Location = New System.Drawing.Point(87, 134)
        Me.lblTtlCstCur_org.Name = "lblTtlCstCur_org"
        Me.lblTtlCstCur_org.Size = New System.Drawing.Size(30, 13)
        Me.lblTtlCstCur_org.TabIndex = 13
        Me.lblTtlCstCur_org.Text = "USD"
        Me.lblTtlCstCur_org.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(18, 134)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 13)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "TTL Cst"
        '
        'txtDVTtlCst_org
        '
        Me.txtDVTtlCst_org.BackColor = System.Drawing.Color.White
        Me.txtDVTtlCst_org.Enabled = False
        Me.txtDVTtlCst_org.ForeColor = System.Drawing.Color.Black
        Me.txtDVTtlCst_org.Location = New System.Drawing.Point(359, 131)
        Me.txtDVTtlCst_org.Name = "txtDVTtlCst_org"
        Me.txtDVTtlCst_org.Size = New System.Drawing.Size(100, 20)
        Me.txtDVTtlCst_org.TabIndex = 23
        '
        'lblDVTtlCstCur_org
        '
        Me.lblDVTtlCstCur_org.AutoSize = True
        Me.lblDVTtlCstCur_org.Location = New System.Drawing.Point(329, 134)
        Me.lblDVTtlCstCur_org.Name = "lblDVTtlCstCur_org"
        Me.lblDVTtlCstCur_org.Size = New System.Drawing.Size(30, 13)
        Me.lblDVTtlCstCur_org.TabIndex = 22
        Me.lblDVTtlCstCur_org.Text = "USD"
        Me.lblDVTtlCstCur_org.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(260, 134)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(45, 13)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "TTL Cst"
        '
        'txtDVTtlBOMCst_org
        '
        Me.txtDVTtlBOMCst_org.BackColor = System.Drawing.Color.White
        Me.txtDVTtlBOMCst_org.Enabled = False
        Me.txtDVTtlBOMCst_org.ForeColor = System.Drawing.Color.Black
        Me.txtDVTtlBOMCst_org.Location = New System.Drawing.Point(359, 105)
        Me.txtDVTtlBOMCst_org.Name = "txtDVTtlBOMCst_org"
        Me.txtDVTtlBOMCst_org.Size = New System.Drawing.Size(100, 20)
        Me.txtDVTtlBOMCst_org.TabIndex = 20
        '
        'lblDVTtlBOMCstCur_org
        '
        Me.lblDVTtlBOMCstCur_org.AutoSize = True
        Me.lblDVTtlBOMCstCur_org.Location = New System.Drawing.Point(329, 108)
        Me.lblDVTtlBOMCstCur_org.Name = "lblDVTtlBOMCstCur_org"
        Me.lblDVTtlBOMCstCur_org.Size = New System.Drawing.Size(30, 13)
        Me.lblDVTtlBOMCstCur_org.TabIndex = 19
        Me.lblDVTtlBOMCstCur_org.Text = "USD"
        Me.lblDVTtlBOMCstCur_org.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(260, 108)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(72, 13)
        Me.Label14.TabIndex = 18
        Me.Label14.Text = "TTL BOM Cst"
        '
        'txtDVItmCst_org
        '
        Me.txtDVItmCst_org.BackColor = System.Drawing.Color.White
        Me.txtDVItmCst_org.Enabled = False
        Me.txtDVItmCst_org.ForeColor = System.Drawing.Color.Black
        Me.txtDVItmCst_org.Location = New System.Drawing.Point(359, 79)
        Me.txtDVItmCst_org.Name = "txtDVItmCst_org"
        Me.txtDVItmCst_org.Size = New System.Drawing.Size(100, 20)
        Me.txtDVItmCst_org.TabIndex = 17
        '
        'lblDVItmCstCur_org
        '
        Me.lblDVItmCstCur_org.AutoSize = True
        Me.lblDVItmCstCur_org.Location = New System.Drawing.Point(329, 82)
        Me.lblDVItmCstCur_org.Name = "lblDVItmCstCur_org"
        Me.lblDVItmCstCur_org.Size = New System.Drawing.Size(30, 13)
        Me.lblDVItmCstCur_org.TabIndex = 16
        Me.lblDVItmCstCur_org.Text = "USD"
        Me.lblDVItmCstCur_org.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(260, 82)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(39, 13)
        Me.Label16.TabIndex = 15
        Me.Label16.Text = "Itm Cst"
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(215, 185)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 1
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'SCM00001_OrgSCst
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(503, 220)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.grpSCCost)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "SCM00001_OrgSCst"
        Me.Text = "SCM00001 - Original SC Costs"
        Me.grpSCCost.ResumeLayout(False)
        Me.grpSCCost.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpSCCost As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblVenno As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtItmCst_org As System.Windows.Forms.TextBox
    Friend WithEvents lblItmCstCur_org As System.Windows.Forms.Label
    Friend WithEvents txtTtlBOMCst_org As System.Windows.Forms.TextBox
    Friend WithEvents lblTtlBOMCstCur_org As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblIMPeriod As System.Windows.Forms.Label
    Friend WithEvents txtDVTtlCst_org As System.Windows.Forms.TextBox
    Friend WithEvents lblDVTtlCstCur_org As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtDVTtlBOMCst_org As System.Windows.Forms.TextBox
    Friend WithEvents lblDVTtlBOMCstCur_org As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtDVItmCst_org As System.Windows.Forms.TextBox
    Friend WithEvents lblDVItmCstCur_org As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtTtlCst_org As System.Windows.Forms.TextBox
    Friend WithEvents lblTtlCstCur_org As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmdOK As System.Windows.Forms.Button
End Class
