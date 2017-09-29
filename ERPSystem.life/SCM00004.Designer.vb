<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SCM00004
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
        Me.grpSC = New System.Windows.Forms.GroupBox
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.cmdAppend = New System.Windows.Forms.Button
        Me.txtSCTo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtSCFm = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.tabFrame = New System.Windows.Forms.TabControl
        Me.tabMaintenance = New System.Windows.Forms.TabPage
        Me.grpMaintenance = New System.Windows.Forms.GroupBox
        Me.txtShipMarkFilter = New System.Windows.Forms.TextBox
        Me.imgShipMark = New System.Windows.Forms.PictureBox
        Me.cmdDelAllSM = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmdRight = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmdLeft = New System.Windows.Forms.Button
        Me.chkPreview = New System.Windows.Forms.CheckBox
        Me.lstShipMark = New System.Windows.Forms.ListBox
        Me.lstSelShipMark = New System.Windows.Forms.ListBox
        Me.grdNewOrder = New System.Windows.Forms.DataGridView
        Me.chkdelall = New System.Windows.Forms.CheckBox
        Me.cmdApySCRange = New System.Windows.Forms.Button
        Me.txtSelSCTo = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtSelSCFm = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.tabSummary = New System.Windows.Forms.TabPage
        Me.grpSummary = New System.Windows.Forms.GroupBox
        Me.grdJobSM = New System.Windows.Forms.DataGridView
        Me.optAll = New System.Windows.Forms.RadioButton
        Me.optUpd = New System.Windows.Forms.RadioButton
        Me.Label9 = New System.Windows.Forms.Label
        Me.grpSC.SuspendLayout()
        Me.tabFrame.SuspendLayout()
        Me.tabMaintenance.SuspendLayout()
        Me.grpMaintenance.SuspendLayout()
        CType(Me.imgShipMark, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdNewOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabSummary.SuspendLayout()
        Me.grpSummary.SuspendLayout()
        CType(Me.grdJobSM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtCoNam
        '
        Me.txtCoNam.BackColor = System.Drawing.Color.White
        Me.txtCoNam.Enabled = False
        Me.txtCoNam.Location = New System.Drawing.Point(250, 10)
        Me.txtCoNam.Name = "txtCoNam"
        Me.txtCoNam.Size = New System.Drawing.Size(330, 22)
        Me.txtCoNam.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(165, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Company Name:"
        '
        'cboCoCde
        '
        Me.cboCoCde.BackColor = System.Drawing.Color.White
        Me.cboCoCde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoCde.FormattingEnabled = True
        Me.cboCoCde.Location = New System.Drawing.Point(90, 9)
        Me.cboCoCde.Name = "cboCoCde"
        Me.cboCoCde.Size = New System.Drawing.Size(72, 20)
        Me.cboCoCde.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(8, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Company Code"
        '
        'grpSC
        '
        Me.grpSC.Controls.Add(Me.cmdSave)
        Me.grpSC.Controls.Add(Me.cmdClearAll)
        Me.grpSC.Controls.Add(Me.cmdAppend)
        Me.grpSC.Controls.Add(Me.txtSCTo)
        Me.grpSC.Controls.Add(Me.Label4)
        Me.grpSC.Controls.Add(Me.txtSCFm)
        Me.grpSC.Controls.Add(Me.Label3)
        Me.grpSC.Location = New System.Drawing.Point(12, 31)
        Me.grpSC.Name = "grpSC"
        Me.grpSC.Size = New System.Drawing.Size(690, 44)
        Me.grpSC.TabIndex = 4
        Me.grpSC.TabStop = False
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(574, 12)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(75, 23)
        Me.cmdSave.TabIndex = 11
        Me.cmdSave.Text = "&Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Location = New System.Drawing.Point(493, 12)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(75, 23)
        Me.cmdClearAll.TabIndex = 10
        Me.cmdClearAll.Text = "Cl&ear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'cmdAppend
        '
        Me.cmdAppend.Location = New System.Drawing.Point(412, 12)
        Me.cmdAppend.Name = "cmdAppend"
        Me.cmdAppend.Size = New System.Drawing.Size(75, 23)
        Me.cmdAppend.TabIndex = 9
        Me.cmdAppend.Text = "&Append"
        Me.cmdAppend.UseVisualStyleBackColor = True
        '
        'txtSCTo
        '
        Me.txtSCTo.Location = New System.Drawing.Point(244, 14)
        Me.txtSCTo.Name = "txtSCTo"
        Me.txtSCTo.Size = New System.Drawing.Size(134, 22)
        Me.txtSCTo.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(218, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(18, 12)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "To"
        '
        'txtSCFm
        '
        Me.txtSCFm.Location = New System.Drawing.Point(78, 14)
        Me.txtSCFm.Name = "txtSCFm"
        Me.txtSCFm.Size = New System.Drawing.Size(134, 22)
        Me.txtSCFm.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 12)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "SC From"
        '
        'tabFrame
        '
        Me.tabFrame.Controls.Add(Me.tabMaintenance)
        Me.tabFrame.Controls.Add(Me.tabSummary)
        Me.tabFrame.ItemSize = New System.Drawing.Size(100, 18)
        Me.tabFrame.Location = New System.Drawing.Point(11, 82)
        Me.tabFrame.Name = "tabFrame"
        Me.tabFrame.SelectedIndex = 0
        Me.tabFrame.Size = New System.Drawing.Size(691, 407)
        Me.tabFrame.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabFrame.TabIndex = 12
        '
        'tabMaintenance
        '
        Me.tabMaintenance.Controls.Add(Me.grpMaintenance)
        Me.tabMaintenance.Location = New System.Drawing.Point(4, 22)
        Me.tabMaintenance.Name = "tabMaintenance"
        Me.tabMaintenance.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMaintenance.Size = New System.Drawing.Size(683, 381)
        Me.tabMaintenance.TabIndex = 0
        Me.tabMaintenance.Text = "Maintenance"
        Me.tabMaintenance.UseVisualStyleBackColor = True
        '
        'grpMaintenance
        '
        Me.grpMaintenance.Controls.Add(Me.txtShipMarkFilter)
        Me.grpMaintenance.Controls.Add(Me.imgShipMark)
        Me.grpMaintenance.Controls.Add(Me.cmdDelAllSM)
        Me.grpMaintenance.Controls.Add(Me.Label8)
        Me.grpMaintenance.Controls.Add(Me.cmdRight)
        Me.grpMaintenance.Controls.Add(Me.Label7)
        Me.grpMaintenance.Controls.Add(Me.cmdLeft)
        Me.grpMaintenance.Controls.Add(Me.chkPreview)
        Me.grpMaintenance.Controls.Add(Me.lstShipMark)
        Me.grpMaintenance.Controls.Add(Me.lstSelShipMark)
        Me.grpMaintenance.Controls.Add(Me.grdNewOrder)
        Me.grpMaintenance.Controls.Add(Me.chkdelall)
        Me.grpMaintenance.Controls.Add(Me.cmdApySCRange)
        Me.grpMaintenance.Controls.Add(Me.txtSelSCTo)
        Me.grpMaintenance.Controls.Add(Me.Label6)
        Me.grpMaintenance.Controls.Add(Me.txtSelSCFm)
        Me.grpMaintenance.Controls.Add(Me.Label5)
        Me.grpMaintenance.Location = New System.Drawing.Point(1, -1)
        Me.grpMaintenance.Name = "grpMaintenance"
        Me.grpMaintenance.Size = New System.Drawing.Size(678, 379)
        Me.grpMaintenance.TabIndex = 0
        Me.grpMaintenance.TabStop = False
        '
        'txtShipMarkFilter
        '
        Me.txtShipMarkFilter.Location = New System.Drawing.Point(570, 33)
        Me.txtShipMarkFilter.Name = "txtShipMarkFilter"
        Me.txtShipMarkFilter.Size = New System.Drawing.Size(102, 22)
        Me.txtShipMarkFilter.TabIndex = 16
        '
        'imgShipMark
        '
        Me.imgShipMark.Location = New System.Drawing.Point(460, 99)
        Me.imgShipMark.Name = "imgShipMark"
        Me.imgShipMark.Size = New System.Drawing.Size(66, 145)
        Me.imgShipMark.TabIndex = 15
        Me.imgShipMark.TabStop = False
        Me.imgShipMark.Visible = False
        '
        'cmdDelAllSM
        '
        Me.cmdDelAllSM.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelAllSM.Location = New System.Drawing.Point(459, 291)
        Me.cmdDelAllSM.Name = "cmdDelAllSM"
        Me.cmdDelAllSM.Size = New System.Drawing.Size(67, 56)
        Me.cmdDelAllSM.TabIndex = 10
        Me.cmdDelAllSM.Text = "Delete All SC Shipmark(s) >>|"
        Me.cmdDelAllSM.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(312, 41)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(101, 12)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "已選擇的運輸標籤"
        '
        'cmdRight
        '
        Me.cmdRight.Location = New System.Drawing.Point(459, 250)
        Me.cmdRight.Name = "cmdRight"
        Me.cmdRight.Size = New System.Drawing.Size(67, 35)
        Me.cmdRight.TabIndex = 9
        Me.cmdRight.Text = ">>"
        Me.cmdRight.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(493, 41)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 12)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "運輸標籤一覽"
        '
        'cmdLeft
        '
        Me.cmdLeft.Location = New System.Drawing.Point(459, 57)
        Me.cmdLeft.Name = "cmdLeft"
        Me.cmdLeft.Size = New System.Drawing.Size(67, 35)
        Me.cmdLeft.TabIndex = 8
        Me.cmdLeft.Text = "<<"
        Me.cmdLeft.UseVisualStyleBackColor = True
        '
        'chkPreview
        '
        Me.chkPreview.AutoSize = True
        Me.chkPreview.Location = New System.Drawing.Point(563, 353)
        Me.chkPreview.Name = "chkPreview"
        Me.chkPreview.Size = New System.Drawing.Size(72, 16)
        Me.chkPreview.TabIndex = 12
        Me.chkPreview.Text = "預覽標籤"
        Me.chkPreview.UseVisualStyleBackColor = True
        '
        'lstShipMark
        '
        Me.lstShipMark.FormattingEnabled = True
        Me.lstShipMark.ItemHeight = 12
        Me.lstShipMark.Location = New System.Drawing.Point(532, 57)
        Me.lstShipMark.Name = "lstShipMark"
        Me.lstShipMark.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstShipMark.Size = New System.Drawing.Size(140, 280)
        Me.lstShipMark.TabIndex = 11
        '
        'lstSelShipMark
        '
        Me.lstSelShipMark.FormattingEnabled = True
        Me.lstSelShipMark.ItemHeight = 12
        Me.lstSelShipMark.Location = New System.Drawing.Point(313, 57)
        Me.lstSelShipMark.Name = "lstSelShipMark"
        Me.lstSelShipMark.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstSelShipMark.Size = New System.Drawing.Size(140, 280)
        Me.lstSelShipMark.TabIndex = 7
        '
        'grdNewOrder
        '
        Me.grdNewOrder.AllowUserToAddRows = False
        Me.grdNewOrder.AllowUserToDeleteRows = False
        Me.grdNewOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdNewOrder.Location = New System.Drawing.Point(9, 57)
        Me.grdNewOrder.Name = "grdNewOrder"
        Me.grdNewOrder.ReadOnly = True
        Me.grdNewOrder.RowHeadersWidth = 20
        Me.grdNewOrder.RowTemplate.Height = 15
        Me.grdNewOrder.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdNewOrder.Size = New System.Drawing.Size(298, 290)
        Me.grdNewOrder.TabIndex = 6
        '
        'chkdelall
        '
        Me.chkdelall.AutoSize = True
        Me.chkdelall.Location = New System.Drawing.Point(498, 15)
        Me.chkdelall.Name = "chkdelall"
        Me.chkdelall.Size = New System.Drawing.Size(154, 16)
        Me.chkdelall.TabIndex = 5
        Me.chkdelall.Text = "Delete all attached shipmark"
        Me.chkdelall.UseVisualStyleBackColor = True
        Me.chkdelall.Visible = False
        '
        'cmdApySCRange
        '
        Me.cmdApySCRange.Location = New System.Drawing.Point(393, 11)
        Me.cmdApySCRange.Name = "cmdApySCRange"
        Me.cmdApySCRange.Size = New System.Drawing.Size(97, 23)
        Me.cmdApySCRange.TabIndex = 4
        Me.cmdApySCRange.Text = "Select Range"
        Me.cmdApySCRange.UseVisualStyleBackColor = True
        '
        'txtSelSCTo
        '
        Me.txtSelSCTo.Location = New System.Drawing.Point(240, 13)
        Me.txtSelSCTo.Name = "txtSelSCTo"
        Me.txtSelSCTo.Size = New System.Drawing.Size(134, 22)
        Me.txtSelSCTo.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(208, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 12)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "To: "
        '
        'txtSelSCFm
        '
        Me.txtSelSCFm.Location = New System.Drawing.Point(59, 13)
        Me.txtSelSCFm.Name = "txtSelSCFm"
        Me.txtSelSCFm.Size = New System.Drawing.Size(134, 22)
        Me.txtSelSCFm.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 12)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Sort By: "
        '
        'tabSummary
        '
        Me.tabSummary.Controls.Add(Me.grpSummary)
        Me.tabSummary.Location = New System.Drawing.Point(4, 22)
        Me.tabSummary.Name = "tabSummary"
        Me.tabSummary.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSummary.Size = New System.Drawing.Size(683, 381)
        Me.tabSummary.TabIndex = 1
        Me.tabSummary.Text = "Summary"
        Me.tabSummary.UseVisualStyleBackColor = True
        '
        'grpSummary
        '
        Me.grpSummary.Controls.Add(Me.grdJobSM)
        Me.grpSummary.Controls.Add(Me.optAll)
        Me.grpSummary.Controls.Add(Me.optUpd)
        Me.grpSummary.Controls.Add(Me.Label9)
        Me.grpSummary.Location = New System.Drawing.Point(1, -1)
        Me.grpSummary.Name = "grpSummary"
        Me.grpSummary.Size = New System.Drawing.Size(678, 379)
        Me.grpSummary.TabIndex = 1
        Me.grpSummary.TabStop = False
        '
        'grdJobSM
        '
        Me.grdJobSM.AllowUserToAddRows = False
        Me.grdJobSM.AllowUserToDeleteRows = False
        Me.grdJobSM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdJobSM.Location = New System.Drawing.Point(6, 37)
        Me.grdJobSM.Name = "grdJobSM"
        Me.grdJobSM.ReadOnly = True
        Me.grdJobSM.RowTemplate.Height = 24
        Me.grdJobSM.Size = New System.Drawing.Size(666, 336)
        Me.grdJobSM.TabIndex = 3
        '
        'optAll
        '
        Me.optAll.AutoSize = True
        Me.optAll.Location = New System.Drawing.Point(618, 14)
        Me.optAll.Name = "optAll"
        Me.optAll.Size = New System.Drawing.Size(45, 16)
        Me.optAll.TabIndex = 2
        Me.optAll.TabStop = True
        Me.optAll.Text = "ALL"
        Me.optAll.UseVisualStyleBackColor = True
        '
        'optUpd
        '
        Me.optUpd.AutoSize = True
        Me.optUpd.Location = New System.Drawing.Point(528, 14)
        Me.optUpd.Name = "optUpd"
        Me.optUpd.Size = New System.Drawing.Size(82, 16)
        Me.optUpd.TabIndex = 1
        Me.optUpd.TabStop = True
        Me.optUpd.Text = "Update Only"
        Me.optUpd.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(445, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 12)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Data Selection"
        '
        'SCM00004
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(714, 501)
        Me.Controls.Add(Me.tabFrame)
        Me.Controls.Add(Me.grpSC)
        Me.Controls.Add(Me.txtCoNam)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboCoCde)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "SCM00004"
        Me.Text = "SCM00004 - Transport Shipmark Maintenance"
        Me.grpSC.ResumeLayout(False)
        Me.grpSC.PerformLayout()
        Me.tabFrame.ResumeLayout(False)
        Me.tabMaintenance.ResumeLayout(False)
        Me.grpMaintenance.ResumeLayout(False)
        Me.grpMaintenance.PerformLayout()
        CType(Me.imgShipMark, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdNewOrder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabSummary.ResumeLayout(False)
        Me.grpSummary.ResumeLayout(False)
        Me.grpSummary.PerformLayout()
        CType(Me.grdJobSM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCoNam As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboCoCde As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grpSC As System.Windows.Forms.GroupBox
    Friend WithEvents cmdAppend As System.Windows.Forms.Button
    Friend WithEvents txtSCTo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSCFm As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents tabFrame As System.Windows.Forms.TabControl
    Friend WithEvents tabMaintenance As System.Windows.Forms.TabPage
    Friend WithEvents tabSummary As System.Windows.Forms.TabPage
    Friend WithEvents grpMaintenance As System.Windows.Forms.GroupBox
    Friend WithEvents txtSelSCTo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtSelSCFm As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents grpSummary As System.Windows.Forms.GroupBox
    Friend WithEvents chkPreview As System.Windows.Forms.CheckBox
    Friend WithEvents lstShipMark As System.Windows.Forms.ListBox
    Friend WithEvents lstSelShipMark As System.Windows.Forms.ListBox
    Friend WithEvents grdNewOrder As System.Windows.Forms.DataGridView
    Friend WithEvents chkdelall As System.Windows.Forms.CheckBox
    Friend WithEvents cmdApySCRange As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmdLeft As System.Windows.Forms.Button
    Friend WithEvents cmdRight As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents grdJobSM As System.Windows.Forms.DataGridView
    Friend WithEvents optAll As System.Windows.Forms.RadioButton
    Friend WithEvents optUpd As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmdDelAllSM As System.Windows.Forms.Button
    Friend WithEvents imgShipMark As System.Windows.Forms.PictureBox
    Friend WithEvents txtShipMarkFilter As System.Windows.Forms.TextBox
End Class
