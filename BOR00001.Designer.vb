<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BOR00001
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BOR00001))
        Me.txtVenPOTo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtVenPOFm = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.optShow = New System.Windows.Forms.RadioButton
        Me.optGen = New System.Windows.Forms.RadioButton
        Me.cmdShow = New System.Windows.Forms.Button
        Me.optDtl = New System.Windows.Forms.RadioButton
        Me.optHdr = New System.Windows.Forms.RadioButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblRptName = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtVenPOTo
        '
        Me.txtVenPOTo.Location = New System.Drawing.Point(425, 56)
        Me.txtVenPOTo.Name = "txtVenPOTo"
        Me.txtVenPOTo.Size = New System.Drawing.Size(128, 22)
        Me.txtVenPOTo.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(394, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 12)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "To"
        '
        'txtVenPOFm
        '
        Me.txtVenPOFm.Location = New System.Drawing.Point(231, 56)
        Me.txtVenPOFm.Name = "txtVenPOFm"
        Me.txtVenPOFm.Size = New System.Drawing.Size(128, 22)
        Me.txtVenPOFm.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(195, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "From"
        '
        'optShow
        '
        Me.optShow.AutoSize = True
        Me.optShow.Checked = True
        Me.optShow.Location = New System.Drawing.Point(197, 3)
        Me.optShow.Name = "optShow"
        Me.optShow.Size = New System.Drawing.Size(84, 16)
        Me.optShow.TabIndex = 0
        Me.optShow.TabStop = True
        Me.optShow.Text = "Show Report"
        Me.optShow.UseVisualStyleBackColor = True
        '
        'optGen
        '
        Me.optGen.AutoSize = True
        Me.optGen.Location = New System.Drawing.Point(3, 3)
        Me.optGen.Name = "optGen"
        Me.optGen.Size = New System.Drawing.Size(64, 16)
        Me.optGen.TabIndex = 0
        Me.optGen.Text = "Generate"
        Me.optGen.UseVisualStyleBackColor = True
        '
        'cmdShow
        '
        Me.cmdShow.Location = New System.Drawing.Point(258, 268)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(112, 40)
        Me.cmdShow.TabIndex = 5
        Me.cmdShow.Text = "&Show Report"
        Me.cmdShow.UseVisualStyleBackColor = True
        '
        'optDtl
        '
        Me.optDtl.AutoSize = True
        Me.optDtl.Location = New System.Drawing.Point(197, 2)
        Me.optDtl.Name = "optDtl"
        Me.optDtl.Size = New System.Drawing.Size(50, 16)
        Me.optDtl.TabIndex = 0
        Me.optDtl.Text = "Detail"
        Me.optDtl.UseVisualStyleBackColor = True
        '
        'optHdr
        '
        Me.optHdr.AutoSize = True
        Me.optHdr.Checked = True
        Me.optHdr.Location = New System.Drawing.Point(3, 2)
        Me.optHdr.Name = "optHdr"
        Me.optHdr.Size = New System.Drawing.Size(68, 16)
        Me.optHdr.TabIndex = 0
        Me.optHdr.TabStop = True
        Me.optHdr.Text = "Summary"
        Me.optHdr.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(29, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(151, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Vendor Purchase Order (BOM)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(29, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 12)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Action"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(29, 183)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 12)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Report Type"
        '
        'lblRptName
        '
        Me.lblRptName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRptName.ForeColor = System.Drawing.Color.Blue
        Me.lblRptName.Location = New System.Drawing.Point(12, 9)
        Me.lblRptName.Name = "lblRptName"
        Me.lblRptName.Size = New System.Drawing.Size(610, 22)
        Me.lblRptName.TabIndex = 20
        Me.lblRptName.Text = "Vendor Purchase Report (BOM)"
        Me.lblRptName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.optGen)
        Me.Panel1.Controls.Add(Me.optShow)
        Me.Panel1.Location = New System.Drawing.Point(229, 113)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(324, 21)
        Me.Panel1.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.optHdr)
        Me.Panel2.Controls.Add(Me.optDtl)
        Me.Panel2.Location = New System.Drawing.Point(229, 181)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(324, 21)
        Me.Panel2.TabIndex = 4
        '
        'BOR00001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 412)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblRptName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtVenPOTo)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtVenPOFm)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "BOR00001"
        Me.Text = "BOR00001 - Vendor Purchase Report (BOM) (BOR01)"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtVenPOTo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtVenPOFm As System.Windows.Forms.TextBox
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    Friend WithEvents optShow As System.Windows.Forms.RadioButton
    Friend WithEvents optGen As System.Windows.Forms.RadioButton
    Friend WithEvents optDtl As System.Windows.Forms.RadioButton
    Friend WithEvents optHdr As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblRptName As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
End Class
