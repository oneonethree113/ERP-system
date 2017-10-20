<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SMR00002
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SMR00002))
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboVenNoTo = New System.Windows.Forms.ComboBox
        Me.cboVenNoFm = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.txtEtdDatTo = New System.Windows.Forms.MaskedTextBox
        Me.txtEtdDatFm = New System.Windows.Forms.MaskedTextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.cmdShow = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(56, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(539, 29)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Shipment Matching Report Summary (Export to Excel)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.SystemColors.MenuBar
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.ForeColor = System.Drawing.Color.DimGray
        Me.txtCoNam.Location = New System.Drawing.Point(272, 42)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.ReadOnly = True
        Me.txtCoNam.Size = New System.Drawing.Size(288, 22)
        Me.txtCoNam.TabIndex = 26
        '
        'cboCoCde
        '
        Me.cboCoCde.BackColor = System.Drawing.SystemColors.Window
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(106, 42)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(66, 20)
        Me.cboCoCde.TabIndex = 25
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(178, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 12)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Company Name "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(21, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 12)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Company Code"
        '
        'cboVenNoTo
        '
        Me.cboVenNoTo.FormattingEnabled = True
        Me.cboVenNoTo.Location = New System.Drawing.Point(386, 87)
        Me.cboVenNoTo.Name = "cboVenNoTo"
        Me.cboVenNoTo.Size = New System.Drawing.Size(161, 20)
        Me.cboVenNoTo.TabIndex = 32
        '
        'cboVenNoFm
        '
        Me.cboVenNoFm.FormattingEnabled = True
        Me.cboVenNoFm.Location = New System.Drawing.Point(184, 87)
        Me.cboVenNoFm.Name = "cboVenNoFm"
        Me.cboVenNoFm.Size = New System.Drawing.Size(161, 20)
        Me.cboVenNoFm.TabIndex = 31
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(360, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(18, 12)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "To"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(142, 90)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 12)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "From"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(21, 12)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "CV"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(19, 166)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(90, 12)
        Me.Label39.TabIndex = 41
        Me.Label39.Text = "Invoice Issue Date"
        '
        'txtEtdDatTo
        '
        Me.txtEtdDatTo.Location = New System.Drawing.Point(386, 163)
        Me.txtEtdDatTo.Mask = "##/##/####"
        Me.txtEtdDatTo.Name = "txtEtdDatTo"
        Me.txtEtdDatTo.Size = New System.Drawing.Size(80, 22)
        Me.txtEtdDatTo.TabIndex = 40
        '
        'txtEtdDatFm
        '
        Me.txtEtdDatFm.Location = New System.Drawing.Point(184, 163)
        Me.txtEtdDatFm.Mask = "##/##/####"
        Me.txtEtdDatFm.Name = "txtEtdDatFm"
        Me.txtEtdDatFm.Size = New System.Drawing.Size(80, 22)
        Me.txtEtdDatFm.TabIndex = 39
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(360, 166)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(18, 12)
        Me.Label28.TabIndex = 38
        Me.Label28.Text = "To"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(472, 166)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(79, 12)
        Me.Label27.TabIndex = 35
        Me.Label27.Text = "MM/DD/YYYY"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(270, 166)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(79, 12)
        Me.Label26.TabIndex = 36
        Me.Label26.Text = "MM/DD/YYYY"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(142, 166)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(30, 12)
        Me.Label25.TabIndex = 37
        Me.Label25.Text = "From"
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(259, 244)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(140, 22)
        Me.cmdShow.TabIndex = 42
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'SMR00002
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 271)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.txtEtdDatTo)
        Me.Controls.Add(Me.txtEtdDatFm)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.cboVenNoTo)
        Me.Controls.Add(Me.cboVenNoFm)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "SMR00002"
        Me.Text = "SMR00002 -  Shipment Matching Report (Summary) (SMR02)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboVenNoTo As System.Windows.Forms.ComboBox
    Friend WithEvents cboVenNoFm As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents txtEtdDatTo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtEtdDatFm As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cmdShow As System.Windows.Forms.Button
End Class
