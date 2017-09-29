<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SHM00110
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
        Me.cboCusNo = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_itmno = New System.Windows.Forms.TextBox
        Me.btn_packfind = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_clear = New System.Windows.Forms.Button
        Me.cbopackterms = New System.Windows.Forms.ComboBox
        Me.btn_search = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.dg_history = New System.Windows.Forms.DataGridView
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.dg_detail = New System.Windows.Forms.DataGridView
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_shipno = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_shipseq = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btn_previous = New System.Windows.Forms.Button
        Me.btn_next = New System.Windows.Forms.Button
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dg_history, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dg_detail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboCusNo
        '
        Me.cboCusNo.FormattingEnabled = True
        Me.cboCusNo.Location = New System.Drawing.Point(106, 14)
        Me.cboCusNo.Name = "cboCusNo"
        Me.cboCusNo.Size = New System.Drawing.Size(156, 21)
        Me.cboCusNo.TabIndex = 270
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(6, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 271
        Me.Label1.Text = "Customer No."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(277, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 272
        Me.Label2.Text = "Item No."
        '
        'txt_itmno
        '
        Me.txt_itmno.Location = New System.Drawing.Point(332, 15)
        Me.txt_itmno.Name = "txt_itmno"
        Me.txt_itmno.Size = New System.Drawing.Size(152, 20)
        Me.txt_itmno.TabIndex = 273
        '
        'btn_packfind
        '
        Me.btn_packfind.Location = New System.Drawing.Point(495, 13)
        Me.btn_packfind.Name = "btn_packfind"
        Me.btn_packfind.Size = New System.Drawing.Size(75, 23)
        Me.btn_packfind.TabIndex = 274
        Me.btn_packfind.Text = "Find"
        Me.btn_packfind.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.btn_packfind)
        Me.GroupBox2.Controls.Add(Me.cboCusNo)
        Me.GroupBox2.Controls.Add(Me.txt_itmno)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(580, 48)
        Me.GroupBox2.TabIndex = 275
        Me.GroupBox2.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_clear)
        Me.GroupBox1.Controls.Add(Me.cbopackterms)
        Me.GroupBox1.Controls.Add(Me.btn_search)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(19, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(602, 124)
        Me.GroupBox1.TabIndex = 278
        Me.GroupBox1.TabStop = False
        '
        'btn_clear
        '
        Me.btn_clear.Enabled = False
        Me.btn_clear.Location = New System.Drawing.Point(296, 92)
        Me.btn_clear.Name = "btn_clear"
        Me.btn_clear.Size = New System.Drawing.Size(75, 23)
        Me.btn_clear.TabIndex = 280
        Me.btn_clear.Text = "Clear"
        Me.btn_clear.UseVisualStyleBackColor = True
        '
        'cbopackterms
        '
        Me.cbopackterms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbopackterms.FormattingEnabled = True
        Me.cbopackterms.Location = New System.Drawing.Point(120, 65)
        Me.cbopackterms.Name = "cbopackterms"
        Me.cbopackterms.Size = New System.Drawing.Size(466, 21)
        Me.cbopackterms.TabIndex = 276
        '
        'btn_search
        '
        Me.btn_search.Location = New System.Drawing.Point(203, 92)
        Me.btn_search.Name = "btn_search"
        Me.btn_search.Size = New System.Drawing.Size(75, 23)
        Me.btn_search.TabIndex = 279
        Me.btn_search.Text = "Search"
        Me.btn_search.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(22, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 13)
        Me.Label3.TabIndex = 277
        Me.Label3.Text = "Packing Terms: "
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(19, 187)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(602, 463)
        Me.TabControl1.TabIndex = 279
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dg_history)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(594, 437)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "History"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dg_history
        '
        Me.dg_history.AllowUserToResizeRows = False
        Me.dg_history.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_history.Location = New System.Drawing.Point(0, 0)
        Me.dg_history.Name = "dg_history"
        Me.dg_history.Size = New System.Drawing.Size(593, 440)
        Me.dg_history.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dg_detail)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(594, 437)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Detail"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dg_detail
        '
        Me.dg_detail.AllowUserToAddRows = False
        Me.dg_detail.AllowUserToResizeRows = False
        Me.dg_detail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_detail.Location = New System.Drawing.Point(0, 0)
        Me.dg_detail.Name = "dg_detail"
        Me.dg_detail.Size = New System.Drawing.Size(593, 438)
        Me.dg_detail.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(6, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 13)
        Me.Label4.TabIndex = 280
        Me.Label4.Text = "Shipping No."
        '
        'txt_shipno
        '
        Me.txt_shipno.Enabled = False
        Me.txt_shipno.Location = New System.Drawing.Point(80, 13)
        Me.txt_shipno.Name = "txt_shipno"
        Me.txt_shipno.Size = New System.Drawing.Size(96, 20)
        Me.txt_shipno.TabIndex = 281
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(182, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 13)
        Me.Label5.TabIndex = 282
        Me.Label5.Text = "Shipping Seq."
        '
        'txt_shipseq
        '
        Me.txt_shipseq.Enabled = False
        Me.txt_shipseq.Location = New System.Drawing.Point(261, 13)
        Me.txt_shipseq.Name = "txt_shipseq"
        Me.txt_shipseq.Size = New System.Drawing.Size(96, 20)
        Me.txt_shipseq.TabIndex = 283
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.btn_previous)
        Me.GroupBox3.Controls.Add(Me.txt_shipseq)
        Me.GroupBox3.Controls.Add(Me.btn_next)
        Me.GroupBox3.Controls.Add(Me.txt_shipno)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Location = New System.Drawing.Point(249, 142)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(372, 61)
        Me.GroupBox3.TabIndex = 284
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Visible = False
        '
        'btn_previous
        '
        Me.btn_previous.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.btn_previous.Location = New System.Drawing.Point(274, 35)
        Me.btn_previous.Name = "btn_previous"
        Me.btn_previous.Size = New System.Drawing.Size(38, 20)
        Me.btn_previous.TabIndex = 286
        Me.btn_previous.TabStop = False
        Me.btn_previous.Text = "<"
        '
        'btn_next
        '
        Me.btn_next.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.btn_next.Location = New System.Drawing.Point(318, 35)
        Me.btn_next.Name = "btn_next"
        Me.btn_next.Size = New System.Drawing.Size(38, 20)
        Me.btn_next.TabIndex = 287
        Me.btn_next.TabStop = False
        Me.btn_next.Text = ">"
        '
        'SHM00110
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(636, 660)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "SHM00110"
        Me.Text = "SHM00110 - Packing Dimension History"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dg_history, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dg_detail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cboCusNo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_itmno As System.Windows.Forms.TextBox
    Friend WithEvents btn_packfind As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_search As System.Windows.Forms.Button
    Friend WithEvents cbopackterms As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dg_history As System.Windows.Forms.DataGridView
    Friend WithEvents dg_detail As System.Windows.Forms.DataGridView
    Friend WithEvents btn_clear As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_shipno As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_shipseq As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_previous As System.Windows.Forms.Button
    Friend WithEvents btn_next As System.Windows.Forms.Button
End Class
