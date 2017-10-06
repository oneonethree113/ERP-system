<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IMR00009
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IMR00009))
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtToSCNo = New System.Windows.Forms.TextBox
        Me.txtFromSCNo = New System.Windows.Forms.TextBox
        Me.cmdExport = New System.Windows.Forms.Button
        Me.cbo_pricustto = New System.Windows.Forms.ComboBox
        Me.cbo_pricustfrom = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(62, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(511, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Document Report for Label"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.Color.White
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.Location = New System.Drawing.Point(270, 46)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.Size = New System.Drawing.Size(336, 22)
        Me.txtCoNam.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(185, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Company Name:"
        '
        'cboCoCde
        '
        Me.cboCoCde.BackColor = System.Drawing.Color.White
        Me.cboCoCde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(95, 45)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(72, 20)
        Me.cboCoCde.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(13, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Company Code"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(136, 180)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(30, 12)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "From"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(387, 177)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(18, 12)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "To"
        '
        'txtToSCNo
        '
        Me.txtToSCNo.Location = New System.Drawing.Point(419, 177)
        Me.txtToSCNo.Name = "txtToSCNo"
        Me.txtToSCNo.Size = New System.Drawing.Size(187, 22)
        Me.txtToSCNo.TabIndex = 6
        '
        'txtFromSCNo
        '
        Me.txtFromSCNo.Location = New System.Drawing.Point(172, 177)
        Me.txtFromSCNo.Name = "txtFromSCNo"
        Me.txtFromSCNo.Size = New System.Drawing.Size(187, 22)
        Me.txtFromSCNo.TabIndex = 5
        '
        'cmdExport
        '
        Me.cmdExport.Location = New System.Drawing.Point(258, 252)
        Me.cmdExport.Name = "cmdExport"
        Me.cmdExport.Size = New System.Drawing.Size(116, 40)
        Me.cmdExport.TabIndex = 7
        Me.cmdExport.Text = "E&xport to Excel"
        Me.cmdExport.UseVisualStyleBackColor = True
        '
        'cbo_pricustto
        '
        Me.cbo_pricustto.FormattingEnabled = True
        Me.cbo_pricustto.Location = New System.Drawing.Point(419, 114)
        Me.cbo_pricustto.Name = "cbo_pricustto"
        Me.cbo_pricustto.Size = New System.Drawing.Size(187, 20)
        Me.cbo_pricustto.TabIndex = 4
        '
        'cbo_pricustfrom
        '
        Me.cbo_pricustfrom.FormattingEnabled = True
        Me.cbo_pricustfrom.Location = New System.Drawing.Point(172, 114)
        Me.cbo_pricustfrom.Name = "cbo_pricustfrom"
        Me.cbo_pricustfrom.Size = New System.Drawing.Size(187, 20)
        Me.cbo_pricustfrom.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(136, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 12)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "From"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(387, 117)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(18, 12)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "To"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 117)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 12)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Primary Customer No."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 180)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(114, 12)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Sales Confirmation No."
        '
        'IMR00009
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(634, 412)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.cbo_pricustto)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.cbo_pricustfrom)
        Me.Controls.Add(Me.txtToSCNo)
        Me.Controls.Add(Me.txtFromSCNo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmdExport)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "IMR00009"
        Me.Text = "IMR00009 - Print Product Label List (IMR09)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtToSCNo As System.Windows.Forms.TextBox
    Friend WithEvents txtFromSCNo As System.Windows.Forms.TextBox
    Friend WithEvents cmdExport As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbo_pricustto As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_pricustfrom As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
