<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QUR00003
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(QUR00003))
        Me.lblRptName = New System.Windows.Forms.Label
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.txtFromQuotNo = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Combo1 = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.cmdShow = New System.Windows.Forms.Button
        Me.saveto_folder = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lblRptName
        '
        Me.lblRptName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRptName.ForeColor = System.Drawing.Color.Blue
        Me.lblRptName.Location = New System.Drawing.Point(65, 5)
        Me.lblRptName.Name = "lblRptName"
        Me.lblRptName.Size = New System.Drawing.Size(509, 21)
        Me.lblRptName.TabIndex = 1
        Me.lblRptName.Text = "Export Quotation to Excel"
        Me.lblRptName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.Color.White
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.Location = New System.Drawing.Point(324, 43)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.Size = New System.Drawing.Size(302, 22)
        Me.txtCoNam.TabIndex = 2
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(231, 46)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(81, 12)
        Me.Label35.TabIndex = 7
        Me.Label35.Text = "Company Name"
        '
        'cboCoCde
        '
        Me.cboCoCde.BackColor = System.Drawing.Color.White
        Me.cboCoCde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(112, 43)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(107, 20)
        Me.cboCoCde.TabIndex = 1
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.ForeColor = System.Drawing.Color.Blue
        Me.Label34.Location = New System.Drawing.Point(13, 46)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(79, 12)
        Me.Label34.TabIndex = 5
        Me.Label34.Text = "Company Code"
        '
        'txtFromQuotNo
        '
        Me.txtFromQuotNo.Location = New System.Drawing.Point(219, 78)
        Me.txtFromQuotNo.Name = "txtFromQuotNo"
        Me.txtFromQuotNo.Size = New System.Drawing.Size(124, 22)
        Me.txtFromQuotNo.TabIndex = 23
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(13, 82)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(71, 12)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Quotation No."
        '
        'Combo1
        '
        Me.Combo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo1.FormattingEnabled = True
        Me.Combo1.Location = New System.Drawing.Point(112, 214)
        Me.Combo1.Name = "Combo1"
        Me.Combo1.Size = New System.Drawing.Size(514, 20)
        Me.Combo1.TabIndex = 25
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(13, 216)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(76, 12)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Report Format "
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(259, 244)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(140, 22)
        Me.cmdShow.TabIndex = 29
        Me.cmdShow.Text = "&Export To Excel"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'saveto_folder
        '
        Me.saveto_folder.Location = New System.Drawing.Point(219, 142)
        Me.saveto_folder.Name = "saveto_folder"
        Me.saveto_folder.Size = New System.Drawing.Size(307, 22)
        Me.saveto_folder.TabIndex = 31
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 141)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 12)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Save to folder (at C: drive):"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 155)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(148, 12)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = " (Optional; Default save to C:\)"
        '
        'QUR00003
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 271)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.saveto_folder)
        Me.Controls.Add(Me.txtFromQuotNo)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Combo1)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.lblRptName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "QUR00003"
        Me.Text = "QUR00003 - Export Quotation to Excel (QUR03)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblRptName As System.Windows.Forms.Label
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Combo1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtFromQuotNo As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents saveto_folder As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
