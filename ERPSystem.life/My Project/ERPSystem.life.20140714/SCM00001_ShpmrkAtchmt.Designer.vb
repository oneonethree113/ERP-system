<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SCM00001_ShpmrkAtchmt
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
        Me.txtCoNam = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtSCNo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.grdNewOrder = New System.Windows.Forms.DataGridView
        Me.Label8 = New System.Windows.Forms.Label
        Me.lstSelShipMark = New System.Windows.Forms.ListBox
        Me.imgShipMark = New System.Windows.Forms.PictureBox
        Me.chkPreview = New System.Windows.Forms.CheckBox
        CType(Me.grdNewOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgShipMark, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.Color.White
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.Location = New System.Drawing.Point(254, 9)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.Size = New System.Drawing.Size(308, 20)
        Me.txtCoNam.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(169, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Company Name:"
        '
        'cboCoCde
        '
        Me.cboCoCde.BackColor = System.Drawing.Color.White
        Me.cboCoCde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoCde.Enabled = False
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(94, 8)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(72, 21)
        Me.cboCoCde.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Company Code"
        '
        'txtSCNo
        '
        Me.txtSCNo.BackColor = System.Drawing.Color.White
        Me.txtSCNo.Enabled = False
        Me.txtSCNo.Location = New System.Drawing.Point(94, 35)
        Me.txtSCNo.MaxLength = 20
        Me.txtSCNo.Name = "txtSCNo"
        Me.txtSCNo.Size = New System.Drawing.Size(81, 20)
        Me.txtSCNo.TabIndex = 266
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(12, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 13)
        Me.Label4.TabIndex = 267
        Me.Label4.Text = "Sales Conf. No."
        '
        'grdNewOrder
        '
        Me.grdNewOrder.AllowUserToAddRows = False
        Me.grdNewOrder.AllowUserToDeleteRows = False
        Me.grdNewOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdNewOrder.Location = New System.Drawing.Point(15, 61)
        Me.grdNewOrder.Name = "grdNewOrder"
        Me.grdNewOrder.ReadOnly = True
        Me.grdNewOrder.RowHeadersWidth = 20
        Me.grdNewOrder.RowTemplate.Height = 15
        Me.grdNewOrder.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdNewOrder.Size = New System.Drawing.Size(547, 129)
        Me.grdNewOrder.TabIndex = 268
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 199)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(103, 13)
        Me.Label8.TabIndex = 270
        Me.Label8.Text = "已選擇的運輸標籤"
        '
        'lstSelShipMark
        '
        Me.lstSelShipMark.FormattingEnabled = True
        Me.lstSelShipMark.Location = New System.Drawing.Point(15, 217)
        Me.lstSelShipMark.Name = "lstSelShipMark"
        Me.lstSelShipMark.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstSelShipMark.Size = New System.Drawing.Size(215, 199)
        Me.lstSelShipMark.TabIndex = 269
        '
        'imgShipMark
        '
        Me.imgShipMark.Location = New System.Drawing.Point(236, 199)
        Me.imgShipMark.Name = "imgShipMark"
        Me.imgShipMark.Size = New System.Drawing.Size(326, 246)
        Me.imgShipMark.TabIndex = 271
        Me.imgShipMark.TabStop = False
        Me.imgShipMark.Visible = False
        '
        'chkPreview
        '
        Me.chkPreview.AutoSize = True
        Me.chkPreview.Location = New System.Drawing.Point(156, 428)
        Me.chkPreview.Name = "chkPreview"
        Me.chkPreview.Size = New System.Drawing.Size(74, 17)
        Me.chkPreview.TabIndex = 272
        Me.chkPreview.Text = "預覽標籤"
        Me.chkPreview.UseVisualStyleBackColor = True
        '
        'SCM00001_ShpmrkAtchmt
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(576, 460)
        Me.Controls.Add(Me.chkPreview)
        Me.Controls.Add(Me.imgShipMark)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lstSelShipMark)
        Me.Controls.Add(Me.grdNewOrder)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtSCNo)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "SCM00001_ShpmrkAtchmt"
        Me.Text = "SCM00001 - Shipmark Attachment Browser"
        CType(Me.grdNewOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgShipMark, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSCNo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents grdNewOrder As System.Windows.Forms.DataGridView
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lstSelShipMark As System.Windows.Forms.ListBox
    Friend WithEvents imgShipMark As System.Windows.Forms.PictureBox
    Friend WithEvents chkPreview As System.Windows.Forms.CheckBox
End Class
