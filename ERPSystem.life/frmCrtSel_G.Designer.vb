<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCrtSel_G
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
        Me.lblCrtName = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdClsSng = New System.Windows.Forms.Button
        Me.txtSngVal = New System.Windows.Forms.TextBox
        Me.txtRange = New System.Windows.Forms.TextBox
        Me.cmdClsRange = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtPartial = New System.Windows.Forms.TextBox
        Me.cmdClsPartial = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdAllCls = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me.tabFrame = New ERPSystem.BaseTabControl
        Me.tabSingle = New System.Windows.Forms.TabPage
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.lstTo = New System.Windows.Forms.ListBox
        Me.lstFrom = New System.Windows.Forms.ListBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.tabRange = New System.Windows.Forms.TabPage
        Me.txtRangeTo3 = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtRangeFm3 = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtRangeTo2 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtRangeFm2 = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtRangeTo1 = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtRangeFm1 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboFm1 = New System.Windows.Forms.ComboBox
        Me.cboFm2 = New System.Windows.Forms.ComboBox
        Me.cboFm3 = New System.Windows.Forms.ComboBox
        Me.cboTo1 = New System.Windows.Forms.ComboBox
        Me.cboTo2 = New System.Windows.Forms.ComboBox
        Me.cboTo3 = New System.Windows.Forms.ComboBox
        Me.tabPartial = New System.Windows.Forms.TabPage
        Me.txtPartial3 = New System.Windows.Forms.TextBox
        Me.txtPartial2 = New System.Windows.Forms.TextBox
        Me.txtPartial1 = New System.Windows.Forms.TextBox
        Me.tabFrame.SuspendLayout()
        Me.tabSingle.SuspendLayout()
        Me.tabRange.SuspendLayout()
        Me.tabPartial.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCrtName
        '
        Me.lblCrtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCrtName.ForeColor = System.Drawing.Color.Blue
        Me.lblCrtName.Location = New System.Drawing.Point(12, 9)
        Me.lblCrtName.Name = "lblCrtName"
        Me.lblCrtName.Size = New System.Drawing.Size(430, 23)
        Me.lblCrtName.TabIndex = 0
        Me.lblCrtName.Text = "Input Criteria: "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Single Values List"
        '
        'cmdClsSng
        '
        Me.cmdClsSng.Location = New System.Drawing.Point(105, 41)
        Me.cmdClsSng.Name = "cmdClsSng"
        Me.cmdClsSng.Size = New System.Drawing.Size(45, 23)
        Me.cmdClsSng.TabIndex = 2
        Me.cmdClsSng.Text = "Clear"
        Me.cmdClsSng.UseVisualStyleBackColor = True
        '
        'txtSngVal
        '
        Me.txtSngVal.Location = New System.Drawing.Point(12, 66)
        Me.txtSngVal.Name = "txtSngVal"
        Me.txtSngVal.Size = New System.Drawing.Size(138, 20)
        Me.txtSngVal.TabIndex = 3
        '
        'txtRange
        '
        Me.txtRange.Location = New System.Drawing.Point(156, 66)
        Me.txtRange.Name = "txtRange"
        Me.txtRange.Size = New System.Drawing.Size(138, 20)
        Me.txtRange.TabIndex = 6
        '
        'cmdClsRange
        '
        Me.cmdClsRange.Location = New System.Drawing.Point(249, 41)
        Me.cmdClsRange.Name = "cmdClsRange"
        Me.cmdClsRange.Size = New System.Drawing.Size(45, 23)
        Me.cmdClsRange.TabIndex = 5
        Me.cmdClsRange.Text = "Clear"
        Me.cmdClsRange.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(153, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Range List"
        '
        'txtPartial
        '
        Me.txtPartial.Location = New System.Drawing.Point(300, 66)
        Me.txtPartial.Name = "txtPartial"
        Me.txtPartial.Size = New System.Drawing.Size(138, 20)
        Me.txtPartial.TabIndex = 9
        '
        'cmdClsPartial
        '
        Me.cmdClsPartial.Location = New System.Drawing.Point(393, 41)
        Me.cmdClsPartial.Name = "cmdClsPartial"
        Me.cmdClsPartial.Size = New System.Drawing.Size(45, 23)
        Me.cmdClsPartial.TabIndex = 8
        Me.cmdClsPartial.Text = "Clear"
        Me.cmdClsPartial.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(297, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Partial List"
        '
        'cmdAllCls
        '
        Me.cmdAllCls.Location = New System.Drawing.Point(12, 400)
        Me.cmdAllCls.Name = "cmdAllCls"
        Me.cmdAllCls.Size = New System.Drawing.Size(75, 23)
        Me.cmdAllCls.TabIndex = 11
        Me.cmdAllCls.Text = "All Clear"
        Me.cmdAllCls.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(381, 400)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(57, 23)
        Me.cmdCancel.TabIndex = 12
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(318, 400)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(57, 23)
        Me.cmdOK.TabIndex = 13
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'tabFrame
        '
        Me.tabFrame.Controls.Add(Me.tabSingle)
        Me.tabFrame.Controls.Add(Me.tabRange)
        Me.tabFrame.Controls.Add(Me.tabPartial)
        Me.tabFrame.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.tabFrame.ItemSize = New System.Drawing.Size(140, 18)
        Me.tabFrame.Location = New System.Drawing.Point(12, 94)
        Me.tabFrame.Name = "tabFrame"
        Me.tabFrame.SelectedIndex = 0
        Me.tabFrame.Size = New System.Drawing.Size(426, 300)
        Me.tabFrame.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabFrame.TabIndex = 10
        '
        'tabSingle
        '
        Me.tabSingle.Controls.Add(Me.cmdDelete)
        Me.tabSingle.Controls.Add(Me.cmdAdd)
        Me.tabSingle.Controls.Add(Me.lstTo)
        Me.tabSingle.Controls.Add(Me.lstFrom)
        Me.tabSingle.Controls.Add(Me.Label4)
        Me.tabSingle.Location = New System.Drawing.Point(4, 22)
        Me.tabSingle.Name = "tabSingle"
        Me.tabSingle.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSingle.Size = New System.Drawing.Size(418, 274)
        Me.tabSingle.TabIndex = 0
        Me.tabSingle.Text = "Single Values"
        Me.tabSingle.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Location = New System.Drawing.Point(173, 191)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(73, 23)
        Me.cmdDelete.TabIndex = 5
        Me.cmdDelete.Text = "<< (&Del)"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdAdd
        '
        Me.cmdAdd.Location = New System.Drawing.Point(173, 71)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(73, 23)
        Me.cmdAdd.TabIndex = 4
        Me.cmdAdd.Text = "(&Add) >>"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'lstTo
        '
        Me.lstTo.FormattingEnabled = True
        Me.lstTo.Location = New System.Drawing.Point(252, 25)
        Me.lstTo.Name = "lstTo"
        Me.lstTo.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstTo.Size = New System.Drawing.Size(156, 238)
        Me.lstTo.TabIndex = 3
        '
        'lstFrom
        '
        Me.lstFrom.FormattingEnabled = True
        Me.lstFrom.Location = New System.Drawing.Point(11, 25)
        Me.lstFrom.Name = "lstFrom"
        Me.lstFrom.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstFrom.Size = New System.Drawing.Size(156, 238)
        Me.lstFrom.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "From"
        '
        'tabRange
        '
        Me.tabRange.Controls.Add(Me.txtRangeTo3)
        Me.tabRange.Controls.Add(Me.Label10)
        Me.tabRange.Controls.Add(Me.txtRangeFm3)
        Me.tabRange.Controls.Add(Me.Label11)
        Me.tabRange.Controls.Add(Me.txtRangeTo2)
        Me.tabRange.Controls.Add(Me.Label8)
        Me.tabRange.Controls.Add(Me.txtRangeFm2)
        Me.tabRange.Controls.Add(Me.Label9)
        Me.tabRange.Controls.Add(Me.txtRangeTo1)
        Me.tabRange.Controls.Add(Me.Label7)
        Me.tabRange.Controls.Add(Me.txtRangeFm1)
        Me.tabRange.Controls.Add(Me.Label6)
        Me.tabRange.Controls.Add(Me.cboFm1)
        Me.tabRange.Controls.Add(Me.cboFm2)
        Me.tabRange.Controls.Add(Me.cboFm3)
        Me.tabRange.Controls.Add(Me.cboTo1)
        Me.tabRange.Controls.Add(Me.cboTo2)
        Me.tabRange.Controls.Add(Me.cboTo3)
        Me.tabRange.Location = New System.Drawing.Point(4, 22)
        Me.tabRange.Name = "tabRange"
        Me.tabRange.Padding = New System.Windows.Forms.Padding(3)
        Me.tabRange.Size = New System.Drawing.Size(418, 274)
        Me.tabRange.TabIndex = 1
        Me.tabRange.Text = "Range"
        Me.tabRange.UseVisualStyleBackColor = True
        '
        'txtRangeTo3
        '
        Me.txtRangeTo3.Location = New System.Drawing.Point(239, 155)
        Me.txtRangeTo3.Name = "txtRangeTo3"
        Me.txtRangeTo3.Size = New System.Drawing.Size(161, 20)
        Me.txtRangeTo3.TabIndex = 11
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(213, 158)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(20, 13)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "To"
        '
        'txtRangeFm3
        '
        Me.txtRangeFm3.Location = New System.Drawing.Point(46, 155)
        Me.txtRangeFm3.Name = "txtRangeFm3"
        Me.txtRangeFm3.Size = New System.Drawing.Size(161, 20)
        Me.txtRangeFm3.TabIndex = 9
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(10, 158)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(30, 13)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "From"
        '
        'txtRangeTo2
        '
        Me.txtRangeTo2.Location = New System.Drawing.Point(239, 119)
        Me.txtRangeTo2.Name = "txtRangeTo2"
        Me.txtRangeTo2.Size = New System.Drawing.Size(161, 20)
        Me.txtRangeTo2.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(213, 122)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(20, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "To"
        '
        'txtRangeFm2
        '
        Me.txtRangeFm2.Location = New System.Drawing.Point(46, 119)
        Me.txtRangeFm2.Name = "txtRangeFm2"
        Me.txtRangeFm2.Size = New System.Drawing.Size(161, 20)
        Me.txtRangeFm2.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(10, 122)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(30, 13)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "From"
        '
        'txtRangeTo1
        '
        Me.txtRangeTo1.Location = New System.Drawing.Point(239, 79)
        Me.txtRangeTo1.Name = "txtRangeTo1"
        Me.txtRangeTo1.Size = New System.Drawing.Size(161, 20)
        Me.txtRangeTo1.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(213, 82)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(20, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "To"
        '
        'txtRangeFm1
        '
        Me.txtRangeFm1.Location = New System.Drawing.Point(46, 79)
        Me.txtRangeFm1.Name = "txtRangeFm1"
        Me.txtRangeFm1.Size = New System.Drawing.Size(161, 20)
        Me.txtRangeFm1.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 82)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "From"
        '
        'cboFm1
        '
        Me.cboFm1.FormattingEnabled = True
        Me.cboFm1.Location = New System.Drawing.Point(46, 78)
        Me.cboFm1.Name = "cboFm1"
        Me.cboFm1.Size = New System.Drawing.Size(161, 21)
        Me.cboFm1.TabIndex = 12
        '
        'cboFm2
        '
        Me.cboFm2.FormattingEnabled = True
        Me.cboFm2.Location = New System.Drawing.Point(46, 118)
        Me.cboFm2.Name = "cboFm2"
        Me.cboFm2.Size = New System.Drawing.Size(161, 21)
        Me.cboFm2.TabIndex = 13
        '
        'cboFm3
        '
        Me.cboFm3.FormattingEnabled = True
        Me.cboFm3.Location = New System.Drawing.Point(46, 154)
        Me.cboFm3.Name = "cboFm3"
        Me.cboFm3.Size = New System.Drawing.Size(161, 21)
        Me.cboFm3.TabIndex = 14
        '
        'cboTo1
        '
        Me.cboTo1.FormattingEnabled = True
        Me.cboTo1.Location = New System.Drawing.Point(239, 78)
        Me.cboTo1.Name = "cboTo1"
        Me.cboTo1.Size = New System.Drawing.Size(161, 21)
        Me.cboTo1.TabIndex = 15
        '
        'cboTo2
        '
        Me.cboTo2.FormattingEnabled = True
        Me.cboTo2.Location = New System.Drawing.Point(239, 118)
        Me.cboTo2.Name = "cboTo2"
        Me.cboTo2.Size = New System.Drawing.Size(161, 21)
        Me.cboTo2.TabIndex = 16
        '
        'cboTo3
        '
        Me.cboTo3.FormattingEnabled = True
        Me.cboTo3.Location = New System.Drawing.Point(239, 154)
        Me.cboTo3.Name = "cboTo3"
        Me.cboTo3.Size = New System.Drawing.Size(161, 21)
        Me.cboTo3.TabIndex = 17
        '
        'tabPartial
        '
        Me.tabPartial.Controls.Add(Me.txtPartial3)
        Me.tabPartial.Controls.Add(Me.txtPartial2)
        Me.tabPartial.Controls.Add(Me.txtPartial1)
        Me.tabPartial.Location = New System.Drawing.Point(4, 22)
        Me.tabPartial.Name = "tabPartial"
        Me.tabPartial.Size = New System.Drawing.Size(418, 274)
        Me.tabPartial.TabIndex = 2
        Me.tabPartial.Text = "Partial List"
        Me.tabPartial.UseVisualStyleBackColor = True
        '
        'txtPartial3
        '
        Me.txtPartial3.Location = New System.Drawing.Point(85, 155)
        Me.txtPartial3.Name = "txtPartial3"
        Me.txtPartial3.Size = New System.Drawing.Size(237, 20)
        Me.txtPartial3.TabIndex = 14
        '
        'txtPartial2
        '
        Me.txtPartial2.Location = New System.Drawing.Point(85, 119)
        Me.txtPartial2.Name = "txtPartial2"
        Me.txtPartial2.Size = New System.Drawing.Size(237, 20)
        Me.txtPartial2.TabIndex = 13
        '
        'txtPartial1
        '
        Me.txtPartial1.Location = New System.Drawing.Point(85, 79)
        Me.txtPartial1.Name = "txtPartial1"
        Me.txtPartial1.Size = New System.Drawing.Size(237, 20)
        Me.txtPartial1.TabIndex = 12
        '
        'frmCrtSel_G
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(450, 430)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdAllCls)
        Me.Controls.Add(Me.tabFrame)
        Me.Controls.Add(Me.txtPartial)
        Me.Controls.Add(Me.cmdClsPartial)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtRange)
        Me.Controls.Add(Me.cmdClsRange)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtSngVal)
        Me.Controls.Add(Me.cmdClsSng)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblCrtName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCrtSel_G"
        Me.Text = "frmCrtSel_G"
        Me.tabFrame.ResumeLayout(False)
        Me.tabSingle.ResumeLayout(False)
        Me.tabSingle.PerformLayout()
        Me.tabRange.ResumeLayout(False)
        Me.tabRange.PerformLayout()
        Me.tabPartial.ResumeLayout(False)
        Me.tabPartial.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCrtName As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdClsSng As System.Windows.Forms.Button
    Friend WithEvents txtSngVal As System.Windows.Forms.TextBox
    Friend WithEvents txtRange As System.Windows.Forms.TextBox
    Friend WithEvents cmdClsRange As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPartial As System.Windows.Forms.TextBox
    Friend WithEvents cmdClsPartial As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tabFrame As ERPSystem.BaseTabControl
    Friend WithEvents tabSingle As System.Windows.Forms.TabPage
    Friend WithEvents tabRange As System.Windows.Forms.TabPage
    Friend WithEvents cmdAllCls As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents tabPartial As System.Windows.Forms.TabPage
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents lstTo As System.Windows.Forms.ListBox
    Friend WithEvents lstFrom As System.Windows.Forms.ListBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtRangeTo3 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtRangeFm3 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtRangeTo2 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtRangeFm2 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtRangeTo1 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtRangeFm1 As System.Windows.Forms.TextBox
    Friend WithEvents txtPartial3 As System.Windows.Forms.TextBox
    Friend WithEvents txtPartial2 As System.Windows.Forms.TextBox
    Friend WithEvents txtPartial1 As System.Windows.Forms.TextBox
    Friend WithEvents cboFm1 As System.Windows.Forms.ComboBox
    Friend WithEvents cboFm2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboFm3 As System.Windows.Forms.ComboBox
    Friend WithEvents cboTo1 As System.Windows.Forms.ComboBox
    Friend WithEvents cboTo2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboTo3 As System.Windows.Forms.ComboBox
End Class
