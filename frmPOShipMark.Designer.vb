<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPOShipMark
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
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.cmdShpmrkAttchmnt = New System.Windows.Forms.Button
        Me.txtImgPth = New System.Windows.Forms.TextBox
        Me.Label111 = New System.Windows.Forms.Label
        Me.txtChnRmk = New System.Windows.Forms.TextBox
        Me.Label110 = New System.Windows.Forms.Label
        Me.txtEngRmk = New System.Windows.Forms.TextBox
        Me.Label109 = New System.Windows.Forms.Label
        Me.txtSChnDsc = New System.Windows.Forms.TextBox
        Me.Label108 = New System.Windows.Forms.Label
        Me.txtSEngDsc = New System.Windows.Forms.TextBox
        Me.Label107 = New System.Windows.Forms.Label
        Me.txtShpMrk = New System.Windows.Forms.TextBox
        Me.Label106 = New System.Windows.Forms.Label
        Me.GroupBox9 = New System.Windows.Forms.GroupBox
        Me.optInner = New System.Windows.Forms.RadioButton
        Me.optSide = New System.Windows.Forms.RadioButton
        Me.optMain = New System.Windows.Forms.RadioButton
        Me.Label105 = New System.Windows.Forms.Label
        Me.cmdOK = New System.Windows.Forms.Button
        Me.imgShpMrk = New System.Windows.Forms.PictureBox
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        CType(Me.imgShpMrk, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.cmdShpmrkAttchmnt)
        Me.GroupBox8.Controls.Add(Me.txtImgPth)
        Me.GroupBox8.Controls.Add(Me.Label111)
        Me.GroupBox8.Controls.Add(Me.imgShpMrk)
        Me.GroupBox8.Controls.Add(Me.txtChnRmk)
        Me.GroupBox8.Controls.Add(Me.Label110)
        Me.GroupBox8.Controls.Add(Me.txtEngRmk)
        Me.GroupBox8.Controls.Add(Me.Label109)
        Me.GroupBox8.Controls.Add(Me.txtSChnDsc)
        Me.GroupBox8.Controls.Add(Me.Label108)
        Me.GroupBox8.Controls.Add(Me.txtSEngDsc)
        Me.GroupBox8.Controls.Add(Me.Label107)
        Me.GroupBox8.Controls.Add(Me.txtShpMrk)
        Me.GroupBox8.Controls.Add(Me.Label106)
        Me.GroupBox8.Controls.Add(Me.GroupBox9)
        Me.GroupBox8.Controls.Add(Me.Label105)
        Me.GroupBox8.Location = New System.Drawing.Point(9, 9)
        Me.GroupBox8.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox8.Size = New System.Drawing.Size(712, 369)
        Me.GroupBox8.TabIndex = 8
        Me.GroupBox8.TabStop = False
        '
        'cmdShpmrkAttchmnt
        '
        Me.cmdShpmrkAttchmnt.Location = New System.Drawing.Point(512, 11)
        Me.cmdShpmrkAttchmnt.Name = "cmdShpmrkAttchmnt"
        Me.cmdShpmrkAttchmnt.Size = New System.Drawing.Size(152, 23)
        Me.cmdShpmrkAttchmnt.TabIndex = 14
        Me.cmdShpmrkAttchmnt.Text = "Shipmark Attachment"
        Me.cmdShpmrkAttchmnt.UseVisualStyleBackColor = True
        '
        'txtImgPth
        '
        Me.txtImgPth.BackColor = System.Drawing.Color.White
        Me.txtImgPth.Enabled = False
        Me.txtImgPth.Location = New System.Drawing.Point(472, 291)
        Me.txtImgPth.Name = "txtImgPth"
        Me.txtImgPth.Size = New System.Drawing.Size(227, 20)
        Me.txtImgPth.TabIndex = 10
        '
        'Label111
        '
        Me.Label111.AutoSize = True
        Me.Label111.Location = New System.Drawing.Point(469, 264)
        Me.Label111.Name = "Label111"
        Me.Label111.Size = New System.Drawing.Size(67, 13)
        Me.Label111.TabIndex = 13
        Me.Label111.Text = "Image Path :"
        '
        'txtChnRmk
        '
        Me.txtChnRmk.BackColor = System.Drawing.Color.White
        Me.txtChnRmk.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChnRmk.Location = New System.Drawing.Point(119, 258)
        Me.txtChnRmk.Multiline = True
        Me.txtChnRmk.Name = "txtChnRmk"
        Me.txtChnRmk.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtChnRmk.Size = New System.Drawing.Size(336, 58)
        Me.txtChnRmk.TabIndex = 9
        '
        'Label110
        '
        Me.Label110.AutoSize = True
        Me.Label110.Location = New System.Drawing.Point(11, 261)
        Me.Label110.Name = "Label110"
        Me.Label110.Size = New System.Drawing.Size(102, 13)
        Me.Label110.TabIndex = 10
        Me.Label110.Text = "Remark in Chinese :"
        '
        'txtEngRmk
        '
        Me.txtEngRmk.BackColor = System.Drawing.Color.White
        Me.txtEngRmk.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEngRmk.Location = New System.Drawing.Point(119, 194)
        Me.txtEngRmk.Multiline = True
        Me.txtEngRmk.Name = "txtEngRmk"
        Me.txtEngRmk.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtEngRmk.Size = New System.Drawing.Size(336, 58)
        Me.txtEngRmk.TabIndex = 8
        '
        'Label109
        '
        Me.Label109.AutoSize = True
        Me.Label109.Location = New System.Drawing.Point(11, 197)
        Me.Label109.Name = "Label109"
        Me.Label109.Size = New System.Drawing.Size(98, 13)
        Me.Label109.TabIndex = 8
        Me.Label109.Text = "Remark in English :"
        '
        'txtSChnDsc
        '
        Me.txtSChnDsc.BackColor = System.Drawing.Color.White
        Me.txtSChnDsc.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSChnDsc.Location = New System.Drawing.Point(119, 130)
        Me.txtSChnDsc.Multiline = True
        Me.txtSChnDsc.Name = "txtSChnDsc"
        Me.txtSChnDsc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSChnDsc.Size = New System.Drawing.Size(336, 58)
        Me.txtSChnDsc.TabIndex = 7
        '
        'Label108
        '
        Me.Label108.AutoSize = True
        Me.Label108.Location = New System.Drawing.Point(11, 133)
        Me.Label108.Name = "Label108"
        Me.Label108.Size = New System.Drawing.Size(107, 13)
        Me.Label108.TabIndex = 6
        Me.Label108.Text = "Chinese Description :"
        '
        'txtSEngDsc
        '
        Me.txtSEngDsc.BackColor = System.Drawing.Color.White
        Me.txtSEngDsc.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSEngDsc.Location = New System.Drawing.Point(119, 67)
        Me.txtSEngDsc.Multiline = True
        Me.txtSEngDsc.Name = "txtSEngDsc"
        Me.txtSEngDsc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSEngDsc.Size = New System.Drawing.Size(336, 58)
        Me.txtSEngDsc.TabIndex = 6
        '
        'Label107
        '
        Me.Label107.AutoSize = True
        Me.Label107.Location = New System.Drawing.Point(11, 70)
        Me.Label107.Name = "Label107"
        Me.Label107.Size = New System.Drawing.Size(103, 13)
        Me.Label107.TabIndex = 4
        Me.Label107.Text = "English Description :"
        '
        'txtShpMrk
        '
        Me.txtShpMrk.BackColor = System.Drawing.Color.White
        Me.txtShpMrk.Location = New System.Drawing.Point(119, 43)
        Me.txtShpMrk.Name = "txtShpMrk"
        Me.txtShpMrk.Size = New System.Drawing.Size(336, 20)
        Me.txtShpMrk.TabIndex = 5
        '
        'Label106
        '
        Me.Label106.AutoSize = True
        Me.Label106.Location = New System.Drawing.Point(11, 46)
        Me.Label106.Name = "Label106"
        Me.Label106.Size = New System.Drawing.Size(80, 13)
        Me.Label106.TabIndex = 2
        Me.Label106.Text = "Ship Mark File :"
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.optInner)
        Me.GroupBox9.Controls.Add(Me.optSide)
        Me.GroupBox9.Controls.Add(Me.optMain)
        Me.GroupBox9.Location = New System.Drawing.Point(117, 8)
        Me.GroupBox9.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox9.Size = New System.Drawing.Size(281, 32)
        Me.GroupBox9.TabIndex = 1
        Me.GroupBox9.TabStop = False
        '
        'optInner
        '
        Me.optInner.AutoSize = True
        Me.optInner.Location = New System.Drawing.Point(184, 12)
        Me.optInner.Name = "optInner"
        Me.optInner.Size = New System.Drawing.Size(49, 17)
        Me.optInner.TabIndex = 4
        Me.optInner.TabStop = True
        Me.optInner.Text = "Inner"
        Me.optInner.UseVisualStyleBackColor = True
        '
        'optSide
        '
        Me.optSide.AutoSize = True
        Me.optSide.Location = New System.Drawing.Point(102, 12)
        Me.optSide.Name = "optSide"
        Me.optSide.Size = New System.Drawing.Size(46, 17)
        Me.optSide.TabIndex = 3
        Me.optSide.TabStop = True
        Me.optSide.Text = "Side"
        Me.optSide.UseVisualStyleBackColor = True
        '
        'optMain
        '
        Me.optMain.AutoSize = True
        Me.optMain.Checked = True
        Me.optMain.Location = New System.Drawing.Point(27, 12)
        Me.optMain.Name = "optMain"
        Me.optMain.Size = New System.Drawing.Size(48, 17)
        Me.optMain.TabIndex = 2
        Me.optMain.TabStop = True
        Me.optMain.Text = "Main"
        Me.optMain.UseVisualStyleBackColor = True
        '
        'Label105
        '
        Me.Label105.AutoSize = True
        Me.Label105.Location = New System.Drawing.Point(11, 16)
        Me.Label105.Name = "Label105"
        Me.Label105.Size = New System.Drawing.Size(88, 13)
        Me.Label105.TabIndex = 0
        Me.Label105.Text = "Ship Mark Type :"
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(332, 381)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 36)
        Me.cmdOK.TabIndex = 9
        Me.cmdOK.Text = "&OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'imgShpMrk
        '
        Me.imgShpMrk.Location = New System.Drawing.Point(470, 43)
        Me.imgShpMrk.Name = "imgShpMrk"
        Me.imgShpMrk.Size = New System.Drawing.Size(229, 208)
        Me.imgShpMrk.TabIndex = 12
        Me.imgShpMrk.TabStop = False
        '
        'frmPOShipMark
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(743, 424)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.GroupBox8)
        Me.Name = "frmPOShipMark"
        Me.Text = "PO - ShipMark"
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        CType(Me.imgShpMrk, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdShpmrkAttchmnt As System.Windows.Forms.Button
    Friend WithEvents txtImgPth As System.Windows.Forms.TextBox
    Friend WithEvents Label111 As System.Windows.Forms.Label
    Friend WithEvents imgShpMrk As System.Windows.Forms.PictureBox
    Friend WithEvents txtChnRmk As System.Windows.Forms.TextBox
    Friend WithEvents Label110 As System.Windows.Forms.Label
    Friend WithEvents txtEngRmk As System.Windows.Forms.TextBox
    Friend WithEvents Label109 As System.Windows.Forms.Label
    Friend WithEvents txtSChnDsc As System.Windows.Forms.TextBox
    Friend WithEvents Label108 As System.Windows.Forms.Label
    Friend WithEvents txtSEngDsc As System.Windows.Forms.TextBox
    Friend WithEvents Label107 As System.Windows.Forms.Label
    Friend WithEvents txtShpMrk As System.Windows.Forms.TextBox
    Friend WithEvents Label106 As System.Windows.Forms.Label
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents optInner As System.Windows.Forms.RadioButton
    Friend WithEvents optSide As System.Windows.Forms.RadioButton
    Friend WithEvents optMain As System.Windows.Forms.RadioButton
    Friend WithEvents Label105 As System.Windows.Forms.Label
    Friend WithEvents cmdOK As System.Windows.Forms.Button
End Class
