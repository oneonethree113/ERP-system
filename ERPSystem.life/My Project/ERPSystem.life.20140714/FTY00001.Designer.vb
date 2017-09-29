<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FTY00001
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
        Me.cboCoCde = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lstNewOrder = New System.Windows.Forms.ListBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lstSelShipMark = New System.Windows.Forms.ListBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.lstShipMark = New System.Windows.Forms.ListBox
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.cmdRemove = New System.Windows.Forms.Button
        Me.pboxPreview = New System.Windows.Forms.PictureBox
        Me.lblFty = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmdGenerate = New System.Windows.Forms.Button
        Me.cmdDisplay = New System.Windows.Forms.Button
        Me.cmdQuit = New System.Windows.Forms.Button
        Me.chkPreview = New System.Windows.Forms.CheckBox
        Me.txtBJNo = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmdNext = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        CType(Me.pboxPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.Color.White
        Me.txtCoNam.Location = New System.Drawing.Point(202, 52)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.ReadOnly = True
        Me.txtCoNam.Size = New System.Drawing.Size(432, 20)
        Me.txtCoNam.TabIndex = 3
        '
        'cboCoCde
        '
        Me.cboCoCde.BackColor = System.Drawing.Color.White
        Me.cboCoCde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(105, 52)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(81, 21)
        Me.cboCoCde.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(12, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Company Code"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(10, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(326, 29)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "工 作 單 編 派 及 管 理 系 統"
        '
        'lstNewOrder
        '
        Me.lstNewOrder.FormattingEnabled = True
        Me.lstNewOrder.Location = New System.Drawing.Point(15, 127)
        Me.lstNewOrder.Name = "lstNewOrder"
        Me.lstNewOrder.Size = New System.Drawing.Size(171, 407)
        Me.lstNewOrder.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Yellow
        Me.Label3.Location = New System.Drawing.Point(12, 109)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "新的工作單"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Yellow
        Me.Label4.Location = New System.Drawing.Point(192, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "已選擇的運輸標籤"
        '
        'lstSelShipMark
        '
        Me.lstSelShipMark.FormattingEnabled = True
        Me.lstSelShipMark.Location = New System.Drawing.Point(195, 127)
        Me.lstSelShipMark.Name = "lstSelShipMark"
        Me.lstSelShipMark.Size = New System.Drawing.Size(171, 225)
        Me.lstSelShipMark.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Yellow
        Me.Label5.Location = New System.Drawing.Point(463, 109)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "運輸標籤一覽"
        '
        'lstShipMark
        '
        Me.lstShipMark.FormattingEnabled = True
        Me.lstShipMark.Location = New System.Drawing.Point(466, 127)
        Me.lstShipMark.Name = "lstShipMark"
        Me.lstShipMark.Size = New System.Drawing.Size(171, 225)
        Me.lstShipMark.TabIndex = 12
        '
        'cmdAdd
        '
        Me.cmdAdd.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAdd.Location = New System.Drawing.Point(372, 179)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(88, 30)
        Me.cmdAdd.TabIndex = 13
        Me.cmdAdd.Text = "<<"
        Me.cmdAdd.UseVisualStyleBackColor = False
        '
        'cmdRemove
        '
        Me.cmdRemove.BackColor = System.Drawing.SystemColors.Control
        Me.cmdRemove.Location = New System.Drawing.Point(372, 260)
        Me.cmdRemove.Name = "cmdRemove"
        Me.cmdRemove.Size = New System.Drawing.Size(88, 30)
        Me.cmdRemove.TabIndex = 14
        Me.cmdRemove.Text = ">>"
        Me.cmdRemove.UseVisualStyleBackColor = False
        '
        'pboxPreview
        '
        Me.pboxPreview.Location = New System.Drawing.Point(466, 358)
        Me.pboxPreview.Name = "pboxPreview"
        Me.pboxPreview.Size = New System.Drawing.Size(171, 176)
        Me.pboxPreview.TabIndex = 294
        Me.pboxPreview.TabStop = False
        '
        'lblFty
        '
        Me.lblFty.BackColor = System.Drawing.Color.White
        Me.lblFty.Location = New System.Drawing.Point(195, 374)
        Me.lblFty.Name = "lblFty"
        Me.lblFty.Size = New System.Drawing.Size(64, 20)
        Me.lblFty.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Yellow
        Me.Label7.Location = New System.Drawing.Point(192, 358)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "工廠"
        '
        'cmdGenerate
        '
        Me.cmdGenerate.BackColor = System.Drawing.SystemColors.Control
        Me.cmdGenerate.Location = New System.Drawing.Point(195, 422)
        Me.cmdGenerate.Name = "cmdGenerate"
        Me.cmdGenerate.Size = New System.Drawing.Size(117, 30)
        Me.cmdGenerate.TabIndex = 18
        Me.cmdGenerate.Text = "生成工作單 (&G)"
        Me.cmdGenerate.UseVisualStyleBackColor = False
        '
        'cmdDisplay
        '
        Me.cmdDisplay.BackColor = System.Drawing.SystemColors.Control
        Me.cmdDisplay.Location = New System.Drawing.Point(195, 504)
        Me.cmdDisplay.Name = "cmdDisplay"
        Me.cmdDisplay.Size = New System.Drawing.Size(82, 30)
        Me.cmdDisplay.TabIndex = 19
        Me.cmdDisplay.Text = "檢閱 (&S)"
        Me.cmdDisplay.UseVisualStyleBackColor = False
        Me.cmdDisplay.Visible = False
        '
        'cmdQuit
        '
        Me.cmdQuit.BackColor = System.Drawing.SystemColors.Control
        Me.cmdQuit.Location = New System.Drawing.Point(371, 504)
        Me.cmdQuit.Name = "cmdQuit"
        Me.cmdQuit.Size = New System.Drawing.Size(82, 30)
        Me.cmdQuit.TabIndex = 21
        Me.cmdQuit.Text = "離開 (&Q)"
        Me.cmdQuit.UseVisualStyleBackColor = False
        '
        'chkPreview
        '
        Me.chkPreview.AutoSize = True
        Me.chkPreview.ForeColor = System.Drawing.Color.Yellow
        Me.chkPreview.Location = New System.Drawing.Point(386, 376)
        Me.chkPreview.Name = "chkPreview"
        Me.chkPreview.Size = New System.Drawing.Size(74, 17)
        Me.chkPreview.TabIndex = 17
        Me.chkPreview.Text = "預覽標籤"
        Me.chkPreview.UseVisualStyleBackColor = True
        '
        'txtBJNo
        '
        Me.txtBJNo.BackColor = System.Drawing.Color.White
        Me.txtBJNo.Location = New System.Drawing.Point(105, 79)
        Me.txtBJNo.Name = "txtBJNo"
        Me.txtBJNo.Size = New System.Drawing.Size(147, 20)
        Me.txtBJNo.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Yellow
        Me.Label8.Location = New System.Drawing.Point(12, 82)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Batch Job No."
        '
        'cmdNext
        '
        Me.cmdNext.BackColor = System.Drawing.SystemColors.Control
        Me.cmdNext.Location = New System.Drawing.Point(278, 77)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(88, 23)
        Me.cmdNext.TabIndex = 6
        Me.cmdNext.Text = "下一步 (&N)"
        Me.cmdNext.UseVisualStyleBackColor = False
        '
        'cmdClear
        '
        Me.cmdClear.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClear.Location = New System.Drawing.Point(283, 504)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(82, 30)
        Me.cmdClear.TabIndex = 20
        Me.cmdClear.Text = "清除 (&C)"
        Me.cmdClear.UseVisualStyleBackColor = False
        '
        'FTY00001
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Teal
        Me.ClientSize = New System.Drawing.Size(646, 549)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.txtBJNo)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.chkPreview)
        Me.Controls.Add(Me.cmdQuit)
        Me.Controls.Add(Me.cmdDisplay)
        Me.Controls.Add(Me.cmdGenerate)
        Me.Controls.Add(Me.lblFty)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.pboxPreview)
        Me.Controls.Add(Me.cmdRemove)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lstShipMark)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lstSelShipMark)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lstNewOrder)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FTY00001"
        Me.Text = "FTY00001 - PDO System"
        CType(Me.pboxPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lstNewOrder As System.Windows.Forms.ListBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lstSelShipMark As System.Windows.Forms.ListBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lstShipMark As System.Windows.Forms.ListBox
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents cmdRemove As System.Windows.Forms.Button
    Friend WithEvents pboxPreview As System.Windows.Forms.PictureBox
    Friend WithEvents lblFty As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmdGenerate As System.Windows.Forms.Button
    Friend WithEvents cmdDisplay As System.Windows.Forms.Button
    Friend WithEvents cmdQuit As System.Windows.Forms.Button
    Friend WithEvents chkPreview As System.Windows.Forms.CheckBox
    Friend WithEvents txtBJNo As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
End Class
