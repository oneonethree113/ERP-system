<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmShipMarkSelect
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
        Me.grpSrc = New System.Windows.Forms.GroupBox
        Me.txtSC = New System.Windows.Forms.RichTextBox
        Me.cmdSc = New System.Windows.Forms.Button
        Me.cmdcust = New System.Windows.Forms.Button
        Me.grpDest = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboSMT = New System.Windows.Forms.ComboBox
        Me.txtCust = New System.Windows.Forms.RichTextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.LoadFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.grpSrc.SuspendLayout()
        Me.grpDest.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpSrc
        '
        Me.grpSrc.Controls.Add(Me.txtSC)
        Me.grpSrc.Controls.Add(Me.cmdSc)
        Me.grpSrc.Location = New System.Drawing.Point(12, 5)
        Me.grpSrc.Name = "grpSrc"
        Me.grpSrc.Size = New System.Drawing.Size(330, 336)
        Me.grpSrc.TabIndex = 4
        Me.grpSrc.TabStop = False
        Me.grpSrc.Text = "Ship Mark From SC"
        '
        'txtSC
        '
        Me.txtSC.Location = New System.Drawing.Point(28, 47)
        Me.txtSC.Name = "txtSC"
        Me.txtSC.Size = New System.Drawing.Size(257, 233)
        Me.txtSC.TabIndex = 359
        Me.txtSC.Text = ""
        '
        'cmdSc
        '
        Me.cmdSc.Location = New System.Drawing.Point(109, 297)
        Me.cmdSc.Name = "cmdSc"
        Me.cmdSc.Size = New System.Drawing.Size(125, 23)
        Me.cmdSc.TabIndex = 2
        Me.cmdSc.Text = "Import from &SC"
        Me.cmdSc.UseVisualStyleBackColor = True
        '
        'cmdcust
        '
        Me.cmdcust.Location = New System.Drawing.Point(107, 297)
        Me.cmdcust.Name = "cmdcust"
        Me.cmdcust.Size = New System.Drawing.Size(129, 23)
        Me.cmdcust.TabIndex = 3
        Me.cmdcust.Text = "Import from &Customer Setting"
        Me.cmdcust.UseVisualStyleBackColor = True
        '
        'grpDest
        '
        Me.grpDest.Controls.Add(Me.Label4)
        Me.grpDest.Controls.Add(Me.cboSMT)
        Me.grpDest.Controls.Add(Me.txtCust)
        Me.grpDest.Controls.Add(Me.Button1)
        Me.grpDest.Controls.Add(Me.cmdcust)
        Me.grpDest.Location = New System.Drawing.Point(352, 5)
        Me.grpDest.Name = "grpDest"
        Me.grpDest.Size = New System.Drawing.Size(330, 336)
        Me.grpDest.TabIndex = 5
        Me.grpDest.TabStop = False
        Me.grpDest.Text = "Ship Mark From Customer (Shipping)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Green
        Me.Label4.Location = New System.Drawing.Point(6, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 14)
        Me.Label4.TabIndex = 365
        Me.Label4.Text = "Type"
        '
        'cboSMT
        '
        Me.cboSMT.FormattingEnabled = True
        Me.cboSMT.Location = New System.Drawing.Point(37, 16)
        Me.cboSMT.Name = "cboSMT"
        Me.cboSMT.Size = New System.Drawing.Size(257, 21)
        Me.cboSMT.TabIndex = 364
        '
        'txtCust
        '
        Me.txtCust.Location = New System.Drawing.Point(37, 48)
        Me.txtCust.Name = "txtCust"
        Me.txtCust.Size = New System.Drawing.Size(257, 233)
        Me.txtCust.TabIndex = 360
        Me.txtCust.Text = ""
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(-216, 322)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(125, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Import from &SC"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(598, 358)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(75, 23)
        Me.cmdExit.TabIndex = 8
        Me.cmdExit.Text = "&Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'LoadFileDialog
        '
        Me.LoadFileDialog.Multiselect = True
        '
        'frmShipMarkSelect
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(694, 393)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.grpDest)
        Me.Controls.Add(Me.grpSrc)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(700, 425)
        Me.MinimumSize = New System.Drawing.Size(700, 425)
        Me.Name = "frmShipMarkSelect"
        Me.Text = "Invoice ShipMark Selection"
        Me.grpSrc.ResumeLayout(False)
        Me.grpDest.ResumeLayout(False)
        Me.grpDest.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpSrc As System.Windows.Forms.GroupBox
    Friend WithEvents grpDest As System.Windows.Forms.GroupBox
    Friend WithEvents cmdcust As System.Windows.Forms.Button
    Friend WithEvents cmdSc As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents LoadFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtSC As System.Windows.Forms.RichTextBox
    Friend WithEvents txtCust As System.Windows.Forms.RichTextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboSMT As System.Windows.Forms.ComboBox
End Class
