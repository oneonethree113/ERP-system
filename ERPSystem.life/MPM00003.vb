Imports System.Collections.Generic
Class MPM00003

    Inherits System.Windows.Forms.Form

    Dim objBSGate As Object
    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean
    Dim Recordstatus As Boolean

    Dim rs_MPM00003 As New DataSet
    Dim rs_DLVHDR As New DataSet
    Dim rs_DLVHDR_blank As New DataSet
    Dim rs_DLVDTL As New DataSet
    Dim rs_tmp As New DataSet

    Dim bolDisplay As Boolean
    Dim colDelivery As Integer
    Dim colSelect As Integer
    Dim colDlvDate As Integer

    Dim colMPODelivery As Integer

    Const STS_INIT As Byte = 0
    Const STS_UPDATE As Byte = 1
    Const STS_CLEAR As Byte = 2
    Const STS_EXIT As Byte = 3
    Const STS_SAVE As Byte = 4

    Dim save_ok As Boolean
    Dim DocMax As Integer

    Dim strAction As String

    Dim bolUpdate As Boolean
    Dim lngPos As Long

    Dim bolUPDFlg As Boolean
    Dim gi_dgselstart As Integer


#Region " Windows Form Designer generated code"
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents StatusBarPanel1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents StatusBarPanel2 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox6 As System.Windows.Forms.ComboBox
    Friend WithEvents RichTextBox3 As System.Windows.Forms.RichTextBox
    Friend WithEvents gbRelation As System.Windows.Forms.GroupBox
    Friend WithEvents lblAction As System.Windows.Forms.Label
    Friend WithEvents optModify As System.Windows.Forms.RadioButton
    Friend WithEvents optAdd As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents grdDelivery As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtItmNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDlvNo As System.Windows.Forms.TextBox
    Friend WithEvents cmdInsRow As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdDelRow As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents grdMPO As System.Windows.Forms.DataGridView
    Friend WithEvents cmdReset As System.Windows.Forms.Button
    Friend WithEvents txtSeqTo As System.Windows.Forms.TextBox
    Friend WithEvents txtSeqFm As System.Windows.Forms.TextBox
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents cmdSelect As System.Windows.Forms.Button

    Public rs_POM00010_AppList As New DataSet

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdShow As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdShow = New System.Windows.Forms.Button
        Me.StatusBar1 = New System.Windows.Forms.StatusBar
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel
        Me.StatusBarPanel2 = New System.Windows.Forms.StatusBarPanel
        Me.TextBox11 = New System.Windows.Forms.TextBox
        Me.ComboBox6 = New System.Windows.Forms.ComboBox
        Me.RichTextBox3 = New System.Windows.Forms.RichTextBox
        Me.gbRelation = New System.Windows.Forms.GroupBox
        Me.optModify = New System.Windows.Forms.RadioButton
        Me.optAdd = New System.Windows.Forms.RadioButton
        Me.lblAction = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.grdDelivery = New System.Windows.Forms.DataGridView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmdInsRow = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdDelRow = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtItmNo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtDlvNo = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.grdMPO = New System.Windows.Forms.DataGridView
        Me.cmdReset = New System.Windows.Forms.Button
        Me.txtSeqTo = New System.Windows.Forms.TextBox
        Me.txtSeqFm = New System.Windows.Forms.TextBox
        Me.cmdApply = New System.Windows.Forms.Button
        Me.cmdSelect = New System.Windows.Forms.Button
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbRelation.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdDelivery, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.grdMPO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdClear
        '
        Me.cmdClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdClear.Location = New System.Drawing.Point(337, 78)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(66, 24)
        Me.cmdClear.TabIndex = 5
        Me.cmdClear.TabStop = False
        Me.cmdClear.Text = "&Clear"
        '
        'cmdShow
        '
        Me.cmdShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdShow.Location = New System.Drawing.Point(268, 78)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.Size = New System.Drawing.Size(66, 24)
        Me.cmdShow.TabIndex = 4
        Me.cmdShow.TabStop = False
        Me.cmdShow.Text = "&Show"
        '
        'StatusBar1
        '
        Me.StatusBar1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusBar1.Location = New System.Drawing.Point(0, 510)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanel1, Me.StatusBarPanel2})
        Me.StatusBar1.ShowPanels = True
        Me.StatusBar1.Size = New System.Drawing.Size(892, 26)
        Me.StatusBar1.TabIndex = 276
        '
        'StatusBarPanel1
        '
        Me.StatusBarPanel1.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.StatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanel1.Name = "StatusBarPanel1"
        Me.StatusBarPanel1.Width = 437
        '
        'StatusBarPanel2
        '
        Me.StatusBarPanel2.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.StatusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanel2.Name = "StatusBarPanel2"
        Me.StatusBarPanel2.Width = 437
        '
        'TextBox11
        '
        Me.TextBox11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TextBox11.Location = New System.Drawing.Point(112, 40)
        Me.TextBox11.MaxLength = 20
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New System.Drawing.Size(105, 20)
        Me.TextBox11.TabIndex = 281
        '
        'ComboBox6
        '
        Me.ComboBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ComboBox6.FormattingEnabled = True
        Me.ComboBox6.Location = New System.Drawing.Point(112, 15)
        Me.ComboBox6.Name = "ComboBox6"
        Me.ComboBox6.Size = New System.Drawing.Size(683, 21)
        Me.ComboBox6.TabIndex = 271
        '
        'RichTextBox3
        '
        Me.RichTextBox3.Location = New System.Drawing.Point(112, 64)
        Me.RichTextBox3.Name = "RichTextBox3"
        Me.RichTextBox3.Size = New System.Drawing.Size(683, 58)
        Me.RichTextBox3.TabIndex = 17
        Me.RichTextBox3.Text = ""
        '
        'gbRelation
        '
        Me.gbRelation.Controls.Add(Me.optModify)
        Me.gbRelation.Controls.Add(Me.optAdd)
        Me.gbRelation.Location = New System.Drawing.Point(98, 14)
        Me.gbRelation.Name = "gbRelation"
        Me.gbRelation.Size = New System.Drawing.Size(131, 30)
        Me.gbRelation.TabIndex = 283
        Me.gbRelation.TabStop = False
        '
        'optModify
        '
        Me.optModify.AutoSize = True
        Me.optModify.Location = New System.Drawing.Point(62, 10)
        Me.optModify.Name = "optModify"
        Me.optModify.Size = New System.Drawing.Size(63, 19)
        Me.optModify.TabIndex = 1
        Me.optModify.TabStop = True
        Me.optModify.Text = "Modify"
        Me.optModify.UseVisualStyleBackColor = True
        '
        'optAdd
        '
        Me.optAdd.AutoSize = True
        Me.optAdd.Location = New System.Drawing.Point(8, 10)
        Me.optAdd.Name = "optAdd"
        Me.optAdd.Size = New System.Drawing.Size(46, 19)
        Me.optAdd.TabIndex = 0
        Me.optAdd.TabStop = True
        Me.optAdd.Text = "Add"
        Me.optAdd.UseVisualStyleBackColor = True
        '
        'lblAction
        '
        Me.lblAction.AutoSize = True
        Me.lblAction.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblAction.Location = New System.Drawing.Point(20, 25)
        Me.lblAction.Name = "lblAction"
        Me.lblAction.Size = New System.Drawing.Size(37, 13)
        Me.lblAction.TabIndex = 279
        Me.lblAction.Text = "Action"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.grdDelivery)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox1.Location = New System.Drawing.Point(12, 126)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(868, 188)
        Me.GroupBox1.TabIndex = 284
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Delivery Record(s)"
        '
        'grdDelivery
        '
        Me.grdDelivery.AllowUserToAddRows = False
        Me.grdDelivery.AllowUserToDeleteRows = False
        Me.grdDelivery.ColumnHeadersHeight = 20
        Me.grdDelivery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.grdDelivery.Location = New System.Drawing.Point(6, 20)
        Me.grdDelivery.Name = "grdDelivery"
        Me.grdDelivery.RowHeadersWidth = 20
        Me.grdDelivery.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDelivery.RowTemplate.Height = 16
        Me.grdDelivery.Size = New System.Drawing.Size(856, 162)
        Me.grdDelivery.TabIndex = 9
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdInsRow)
        Me.GroupBox2.Controls.Add(Me.cmdSave)
        Me.GroupBox2.Controls.Add(Me.cmdDelRow)
        Me.GroupBox2.Controls.Add(Me.lblAction)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtItmNo)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtDlvNo)
        Me.GroupBox2.Controls.Add(Me.cmdClear)
        Me.GroupBox2.Controls.Add(Me.gbRelation)
        Me.GroupBox2.Controls.Add(Me.cmdShow)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(868, 121)
        Me.GroupBox2.TabIndex = 285
        Me.GroupBox2.TabStop = False
        '
        'cmdInsRow
        '
        Me.cmdInsRow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdInsRow.Location = New System.Drawing.Point(551, 78)
        Me.cmdInsRow.Name = "cmdInsRow"
        Me.cmdInsRow.Size = New System.Drawing.Size(66, 24)
        Me.cmdInsRow.TabIndex = 7
        Me.cmdInsRow.TabStop = False
        Me.cmdInsRow.Text = "I&ns Row"
        '
        'cmdSave
        '
        Me.cmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdSave.Location = New System.Drawing.Point(406, 78)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(66, 24)
        Me.cmdSave.TabIndex = 6
        Me.cmdSave.TabStop = False
        Me.cmdSave.Text = "&Save"
        '
        'cmdDelRow
        '
        Me.cmdDelRow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdDelRow.Location = New System.Drawing.Point(621, 78)
        Me.cmdDelRow.Name = "cmdDelRow"
        Me.cmdDelRow.Size = New System.Drawing.Size(66, 24)
        Me.cmdDelRow.TabIndex = 8
        Me.cmdDelRow.TabStop = False
        Me.cmdDelRow.Text = "Del Ro&w"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label3.Location = New System.Drawing.Point(20, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 287
        Me.Label3.Text = "Item No   : "
        '
        'txtItmNo
        '
        Me.txtItmNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtItmNo.Location = New System.Drawing.Point(98, 78)
        Me.txtItmNo.MaxLength = 10
        Me.txtItmNo.Name = "txtItmNo"
        Me.txtItmNo.Size = New System.Drawing.Size(129, 20)
        Me.txtItmNo.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(20, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 285
        Me.Label2.Text = "Delivery No : "
        '
        'txtDlvNo
        '
        Me.txtDlvNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtDlvNo.Location = New System.Drawing.Point(98, 51)
        Me.txtDlvNo.MaxLength = 10
        Me.txtDlvNo.Name = "txtDlvNo"
        Me.txtDlvNo.Size = New System.Drawing.Size(129, 20)
        Me.txtDlvNo.TabIndex = 2
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.grdMPO)
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GroupBox3.Location = New System.Drawing.Point(12, 320)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(868, 188)
        Me.GroupBox3.TabIndex = 286
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "MPO Record(s)"
        '
        'grdMPO
        '
        Me.grdMPO.AllowUserToAddRows = False
        Me.grdMPO.AllowUserToDeleteRows = False
        Me.grdMPO.ColumnHeadersHeight = 20
        Me.grdMPO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.grdMPO.Location = New System.Drawing.Point(6, 20)
        Me.grdMPO.Name = "grdMPO"
        Me.grdMPO.RowHeadersWidth = 20
        Me.grdMPO.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdMPO.RowTemplate.Height = 16
        Me.grdMPO.Size = New System.Drawing.Size(856, 162)
        Me.grdMPO.TabIndex = 10
        '
        'cmdReset
        '
        Me.cmdReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdReset.Location = New System.Drawing.Point(3000, 300)
        Me.cmdReset.Name = "cmdReset"
        Me.cmdReset.Size = New System.Drawing.Size(66, 24)
        Me.cmdReset.TabIndex = 295
        Me.cmdReset.TabStop = False
        Me.cmdReset.Text = "&Save"
        Me.cmdReset.Visible = False
        '
        'txtSeqTo
        '
        Me.txtSeqTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtSeqTo.Location = New System.Drawing.Point(3000, 300)
        Me.txtSeqTo.MaxLength = 10
        Me.txtSeqTo.Name = "txtSeqTo"
        Me.txtSeqTo.Size = New System.Drawing.Size(129, 20)
        Me.txtSeqTo.TabIndex = 294
        Me.txtSeqTo.Visible = False
        '
        'txtSeqFm
        '
        Me.txtSeqFm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtSeqFm.Location = New System.Drawing.Point(3000, 300)
        Me.txtSeqFm.MaxLength = 10
        Me.txtSeqFm.Name = "txtSeqFm"
        Me.txtSeqFm.Size = New System.Drawing.Size(129, 20)
        Me.txtSeqFm.TabIndex = 293
        Me.txtSeqFm.Visible = False
        '
        'cmdApply
        '
        Me.cmdApply.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdApply.Location = New System.Drawing.Point(3000, 300)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.Size = New System.Drawing.Size(66, 24)
        Me.cmdApply.TabIndex = 292
        Me.cmdApply.TabStop = False
        Me.cmdApply.Text = "&Clear"
        Me.cmdApply.Visible = False
        '
        'cmdSelect
        '
        Me.cmdSelect.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmdSelect.Location = New System.Drawing.Point(3000, 300)
        Me.cmdSelect.Name = "cmdSelect"
        Me.cmdSelect.Size = New System.Drawing.Size(66, 24)
        Me.cmdSelect.TabIndex = 291
        Me.cmdSelect.TabStop = False
        Me.cmdSelect.Text = "&Show"
        Me.cmdSelect.Visible = False
        '
        'MPM00003
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(892, 536)
        Me.Controls.Add(Me.cmdReset)
        Me.Controls.Add(Me.txtSeqTo)
        Me.Controls.Add(Me.txtSeqFm)
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.cmdSelect)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.StatusBar1)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MPM00003"
        Me.Text = "MPM00003 - Supplier Delivery Maintenance"
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbRelation.ResumeLayout(False)
        Me.gbRelation.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.grdDelivery, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.grdMPO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region


    Private Sub set_StatusPanel()
        If rs_MPM00003 Is Nothing Then Exit Sub
        If rs_MPM00003.Tables("result") Is Nothing Then Exit Sub
        If rs_MPM00003.Tables("result").Rows.Count <= 0 Then Exit Sub
        If bolDisplay = True Then Exit Sub
        Me.StatusBar1.Panels(1).Text = rs_MPM00003.Tables("result").Rows(0)("Mpd_UpdUsr") & "  " & rs_MPM00003.Tables("result").Rows(0)("Mpd_UpdDat") & "  " & rs_MPM00003.Tables("result").Rows(0)("Mpd_CreDat")
    End Sub

    Private Sub setStatus(ByVal sts As Byte)
        Select Case sts
            Case STS_INIT
                Me.txtItmNo.MaxLength = 20
                Me.txtItmNo.Enabled = True
                Me.txtItmNo.Text = ""

                Me.txtDlvNo.MaxLength = 20
                Me.txtDlvNo.Enabled = True
                Me.txtDlvNo.Text = ""

                Me.cmdShow.Enabled = True
                Me.cmdClear.Enabled = False
                Me.cmdSave.Enabled = False

                Me.cmdInsRow.Enabled = False
                Me.cmdDelRow.Enabled = False

                Me.txtSeqFm.Enabled = False
                Me.txtSeqTo.Enabled = False

                Me.cmdApply.Enabled = False
                Me.cmdReset.Enabled = False

                Me.optAdd.Checked = True
                Me.txtDlvNo.Text = ""
                Me.txtItmNo.Text = ""
                Me.txtDlvNo.Enabled = False
                Me.txtItmNo.Enabled = True
                grdDelivery.DataSource = Nothing
                bolUPDFlg = False

            Case STS_UPDATE
                Me.optAdd.Enabled = False
                Me.optModify.Enabled = False

                Me.txtItmNo.Enabled = False
                Me.txtDlvNo.Enabled = False

                Me.cmdShow.Enabled = False
                Me.cmdClear.Enabled = True
                Me.cmdSave.Enabled = Enq_right_local

                If strAction = "ADD" Then
                    Me.cmdInsRow.Enabled = Enq_right_local
                    Me.cmdDelRow.Enabled = Del_right_local
                Else
                    Me.cmdInsRow.Enabled = False
                    Me.cmdDelRow.Enabled = Del_right_local
                End If

                Me.txtSeqFm.Enabled = True
                Me.txtSeqTo.Enabled = True
                Me.cmdSelect.Enabled = True
                Me.cmdApply.Enabled = True
                Me.cmdReset.Enabled = True

                bolUPDFlg = False

            Case STS_CLEAR
                Me.optAdd.Enabled = True
                Me.optModify.Enabled = True

                Me.txtItmNo.Enabled = True
                Me.txtDlvNo.Enabled = True

                Me.cmdShow.Enabled = True
                Me.cmdClear.Enabled = False
                Me.cmdSave.Enabled = False

                Me.cmdInsRow.Enabled = False
                Me.cmdDelRow.Enabled = False

                Me.grdDelivery.DataSource = Nothing
                Me.grdMPO.DataSource = Nothing

                rs_MPM00003 = Nothing
                rs_DLVHDR = Nothing
                rs_DLVDTL = Nothing

                bolUPDFlg = False
            Case STS_EXIT


            Case STS_SAVE

            Case Else
        End Select
    End Sub

    Private Sub setFocus_Combo(ByVal cbo As ComboBox)
        If cbo.Enabled = True And cbo.Visible = True Then
            cbo.Focus()
            cbo.SelectionStart = 0
            cbo.SelectionLength = Len(cbo.Text)
        End If
    End Sub

    Private Sub setFocus_text(ByVal txt As TextBox)
        If txt.Enabled = True And txt.Visible = True Then
            txt.Focus()
            txt.SelectionStart = 0
            txt.SelectionLength = Len(txt.Text)
        End If
    End Sub
    '
    Private Sub cmdApply_Click()
        'Dim seqFm As Integer
        'Dim seqTo As Integer

        'Dim bolPositive As Boolean
        'Dim bolNegative As Boolean

        'Dim i As Integer
        'Dim j As Integer


        'Dim qty As Integer
        'Dim ttlQty As Double
        'Dim OSQty As Double

        ''    Dim qty As Double
        ''    Dim ttlQty As Double
        ''    Dim OSQty As Double


        'If rs_DLVHDR Is Nothing Then Exit Sub
        'If rs_DLVHDR.Tables("result").Rows.Count <= 0 Then Exit Sub
        'If rs_MPM00003 Is Nothing Then Exit Sub
        'If rs_MPM00003.Tables("result").Rows.Count <= 0 Then Exit Sub

        'bolDisplay = True

        'bolPositive = False
        'With rs_DLVHDR

        '    .Tables("RESULT").DefaultView.RowFilter = "STS = 'N' and Mdh_DQty > 0"
        '    If .Tables("result").DefaultView.Count > 0 Then
        '        bolPositive = True
        '    End If
        '    .Tables("RESULT").DefaultView.RowFilter = ""
        'End With

        'bolNegative = False
        'With rs_DLVHDR
        '    .Tables("RESULT").DefaultView.RowFilter = "STS = 'N' and Mdh_DQty < 0"
        '    If .Tables("result").DefaultView.Count > 0 Then
        '        bolNegative = True
        '    End If
        '    .Tables("RESULT").DefaultView.RowFilter = ""
        'End With
        'bolDisplay = False

        'Call Display_grdDelivery()
        'If bolPositive = True And bolNegative = True Then
        '    MsgBox("System cannot handle both +ve and -ve Delivery Qty at the same time!" & vbCrLf & _
        '           "Please delete either record(s).")
        '    Exit Sub
        'ElseIf bolPositive = False And bolNegative = False Then
        '    MsgBox("There is no delivery record or the delivery qty is/are zero!" & vbCrLf & _
        '           "Please delete either record(s).")
        '    Exit Sub
        'End If

        'If Not IsNumeric(seqFm) Then
        '    MsgBox("Seq # From should be an integer!")
        '    Exit Sub
        'End If
        'If Not IsNumeric(seqTo) Then
        '    MsgBox("Seq # To should be an integer!")
        '    Exit Sub
        'End If
        'seqFm = CInt(Me.txtSeqFm.Text)
        'seqTo = CInt(Me.txtSeqTo.Text)

        'If CInt(seqFm) < 1 Then
        '    MsgBox("Seq From should greater than ZERO!")
        '    Exit Sub
        'End If

        'If CInt(seqFm) > rs_MPM00003.Tables("result").Rows.Count Then
        '    MsgBox("Seq From should less than " & Trim(Str(rs_MPM00003.Tables("result").Rows.Count)) & "!")
        '    Exit Sub
        'End If

        'If CInt(seqTo) < 1 Then
        '    MsgBox("Seq To should greater than ZERO!")
        '    Exit Sub
        'End If

        'If CInt(seqTo) > rs_MPM00003.Tables("result").Rows.Count Then
        '    MsgBox("Seq To should less than " & Trim(Str(rs_MPM00003.Tables("result").Rows.Count)) & "!")
        '    Exit Sub
        'End If

        'If seqFm > seqTo Then
        '    MsgBox("Seq From should less than Seq To!")
        '    Exit Sub
        'End If


        '' -----------------------------------------------------------------------------------------
        '' -----------------------------------------------------------------------------------------
        'If bolPositive = True Then
        '    ' -- Check +ve Value
        '    ttlQty = 0
        '    bolDisplay = True
        '    With rs_DLVHDR
        '        .Tables("RESULT").DefaultView.RowFilter = "STS = 'N' and Mdh_DQty > 0"
        '        If .Tables("result").DefaultView.Count > 0 Then
        '            For index9 As Integer = 0 To .Tables("RESULT").DefaultView.Count - 1
        '                ttlQty = ttlQty + .Tables("result").DefaultView(index9)("Mdh_DQty")                    Next
        '            Next
        '        End If

        '        .Tables("RESULT").DefaultView.RowFilter = ""
        '    End With
        '    bolDisplay = False
        '    Call Display_grdDelivery()

        '    If ttlQty = 0 Then Exit Sub

        '    OSQty = 0
        '    With rs_MPM00003
        '        .Tables("RESULT").DefaultView.RowFilter = "Seq >=" & seqFm & " and Seq <= " & seqTo
        '        If .Tables("result").DefaultView.Count > 0 Then
        '            For index9 As Integer = 0 To .Tables("RESULT").DefaultView.Count - 1
        '                OSQty = OSQty + (.Tables("result").DefaultView(index9)("OS_Qty") - .Tables("result").DefaultView(index9)("Adjust Qty"))
        '            Next
        '        End If

        '        .Tables("RESULT").DefaultView.RowFilter = ""
        '    End With

        '    Call display_grdMPO()
        '    If ttlQty > OSQty Then
        '        MsgBox("Delivery Qty (" & ttlQty & ") > OS Qty (" & OSQty & ")!")
        '        Exit Sub
        '    End If
        'Else
        '    ' -- Check -ve Value
        '    ttlQty = 0
        '    With rs_DLVHDR
        '        .Tables("RESULT").DefaultView.RowFilter = "STS = 'N' and Mdh_DQty < 0"

        '        If .Tables("result").DefaultView.Count > 0 Then
        '            For index9 As Integer = 0 To .Tables("RESULT").DefaultView.Count - 1
        '                ttlQty = ttlQty + .Tables("result").DefaultView(index9)("Mdh_DQty")
        '            Next
        '        End If

        '        .Tables("RESULT").DefaultView.RowFilter = ""
        '    End With
        '    Call Display_grdDelivery()
        '    If ttlQty = 0 Then Exit Sub
        '    OSQty = 0
        '    With rs_MPM00003
        '        .Tables("RESULT").DefaultView.RowFilter = "Seq >=" & seqFm & " and Seq <= " & seqTo
        '        If .Tables("result").DefaultView.Count > 0 Then
        '            For index9 As Integer = 0 To .Tables("RESULT").DefaultView.Count - 1
        '                OSQty = OSQty + (.Tables("result").DefaultView(index9)("Ori_DQty") + .Tables("result").DefaultView(index9)("Adjust Qty"))
        '            Next
        '        End If

        '        .Tables("RESULT").DefaultView.RowFilter = ""
        '    End With
        '    Call display_grdMPO()

        '    If (OSQty + ttlQty) < 0 Then
        '        MsgBox("Deduct Qty (" & ttlQty & ") > Received Qty (" & OSQty & ")!")
        '        Exit Sub
        '    End If

        'End If
        '' -----------------------------------------------------------------------------------------
        '' -----------------------------------------------------------------------------------------
        'bolDisplay = True
        ''goto

        'With rs_DLVHDR
        '    .Tables("RESULT").DefaultView.RowFilter = "STS='N'"
        '    If .Tables("result").DefaultView.Count > 0 Then
        '        For index9 As Integer = 0 To .Tables("RESULT").DefaultView.Count - 1
        '            ttlQty = .Tables("result").DefaultView(index9)("Mdh_DQty")
        '            OSQty = ttlQty
        '            With rs_MPM00003
        '                If .Tables("result").Rows.Count > 0 Then
        '                    For index As Integer = 0 To .Tables("RESULT").Rows.Count - 1
        '                        If OSQty <> 0 Then
        '                            'tempzzzzzzzzzzzzzzzzzzzz
        '                            If .Tables("result").Rows(index)("Seq") >= seqFm And .Tables("result").Rows(index)("Seq") <= seqTo Then
        '                                If OSQty >= 0 Then
        '                                    If (.Tables("result").Rows(index)("OS_Qty") - .Tables("result").Rows(index)("Adjust Qty")) > 0 Then
        '                                        If (.Tables("result").Rows(index)("OS_Qty") - .Tables("result").Rows(index)("Adjust Qty")) >= OSQty Then
        '                                            qty = OSQty
        '                                            .Tables("result").Rows(index)("Adjust Qty") = .Tables("result").Rows(index)("Adjust Qty") + OSQty
        '                                            OSQty = 0
        '                                            Call Add_To_DlvDtl(rs_DLVHDR.Tables("result").Rows(0)("Mdh_DocNo"), rs_DLVHDR.Tables("result").Rows(0)("Mdh_DocSeq"), .Tables("result").Rows(index)("Mph_MPONo"), .Tables("result").Rows(index)("Mpd_MPOseq"), Me.txtItmNo.Text, qty)

        '                                            'grdMPO.SelBookmarks.Add(grdMPO.bookmark)
        '                                            ''''''''''''
        '                                            'tempzzzzzzzzzzzzzz
        '                                        Else
        '                                            qty = .Tables("result").Rows(index)("OS_Qty") - .Tables("result").Rows(index)("Adjust Qty")
        '                                            OSQty = OSQty - qty
        '                                            .Tables("result").Rows(index)("Adjust Qty") = .Tables("result").Rows(index)("Adjust Qty") + qty
        '                                            Call Add_To_DlvDtl(rs_DLVHDR.Tables("result").Rows(0)("Mdh_DocNo"), rs_DLVHDR.Tables("result").Rows(0)("Mdh_DocSeq"), .Tables("result").Rows(index)("Mph_MPONo"), .Tables("result").Rows(index)("Mpd_MPOseq"), Me.txtItmNo.Text, qty)
        '                                            'grdMPO.SelBookmarks.Add(grdMPO.bookmark)
        '                                            'tempzzzzzzzzzzzzzz
        '                                        End If
        '                                    End If
        '                                Else
        '                                    If (.Tables("result").Rows(index)("Ori_DQty") + .Tables("result").Rows(index)("Adjust Qty")) > 0 Then
        '                                        If (.Tables("result").Rows(index)("Ori_DQty") + .Tables("result").Rows(index)("Adjust Qty") + OSQty) >= 0 Then
        '                                            qty = OSQty
        '                                            .Tables("result").Rows(index)("Adjust Qty") = .Tables("result").Rows(index)("Adjust Qty") + qty
        '                                            OSQty = 0
        '                                            Call Add_To_DlvDtl(rs_DLVHDR.Tables("result").Rows(0)("Mdh_DocNo"), rs_DLVHDR.Tables("result").Rows(0)("Mdh_DocSeq"), .Tables("result").Rows(index)("Mph_MPONo"), .Tables("result").Rows(index)("Mpd_MPOseq"), Me.txtItmNo.Text, qty)
        '                                            'grdMPO.SelBookmarks.Add(grdMPO.bookmark)
        '                                            'tempzzzzzzzzzzzzzz
        '                                        Else
        '                                            qty = .Tables("result").Rows(index)("Ori_DQty") + .Tables("result").Rows(index)("Adjust Qty")
        '                                            OSQty = OSQty + (.Tables("result").Rows(index)("Ori_DQty") + .Tables("result").Rows(index)("Adjust Qty"))
        '                                            .Tables("result").Rows(index)("Adjust Qty") = 0 - .Tables("result").Rows(index)("Ori_DQty")
        '                                            Call Add_To_DlvDtl(rs_DLVHDR.Tables("result").Rows(0)("Mdh_DocNo"), rs_DLVHDR.Tables("result").Rows(0)("Mdh_DocSeq"), .Tables("result").Rows(index)("Mph_MPONo"), .Tables("result").Rows(index)("Mpd_MPOseq"), Me.txtItmNo.Text, qty)
        '                                            'grdMPO.SelBookmarks.Add(grdMPO.bookmark)
        '                                            'tempzzzzzzzzzzzzzz

        '                                        End If
        '                                    End If
        '                                End If
        '                            End If
        '                        End If
        '                    Next
        '                End If


        '            End With
        '        Next
        '    End If

        '    .Tables("result").DefaultView(index9)("STS") = "A"
        '    'tempzzzzzzzzzzzzzzzzzzzzzzzz
        '    'tempzzzzzzzzzzzzzzzzzzzzzzzz
        '    .Tables("RESULT").DefaultView.RowFilter = ""
        'End With


        ' ''    With rs_DLVDTL
        ' ''        .MoveFirst
        ' ''        For i = 0 To .Tables("result").Rows.Count  - 1
        ' ''            For j = 0 To .Tables("result").Rows(index9).count - 2
        ' ''                Debug.Print i & " > " & .Tables("result").Rows(index9)(j).Name & " : " & .Tables("result").Rows(index9)(j).value
        ' ''            Next
        ' ''            Debug.Print "--------------------------------------------"
        ' ''            .MoveNext
        ' ''        Next
        ' ''    End With
        ''    Call display_grdMPO
        'Call Display_grdDelivery()
        'bolDisplay = False

    End Sub

    Private Sub Add_To_DlvDtl(ByVal docno As String, ByVal SeqNo As Integer, ByVal MpoNo As String, ByVal mposeqno As Integer, ByVal itmNo As String, ByVal qty As Integer)
        'On Error Resume Next
        If rs_DLVDTL Is Nothing Then
            MsgBox("Error when update MPO record!" & vbCrLf & "Please contact system administrator.", , "Delivery Detail")
            Exit Sub
        End If

        With rs_DLVDTL
            .Tables("result").Rows.Add()
            .Tables("result").Rows(.Tables("result").Rows.Count - 1)("STS") = "N"
            .Tables("result").Rows(.Tables("result").Rows.Count - 1)("Mdd_DocNo") = docno
            .Tables("result").Rows(.Tables("result").Rows.Count - 1)("Mdd_DocSeq") = SeqNo
            .Tables("result").Rows(.Tables("result").Rows.Count - 1)("Mdd_MpoNo") = MpoNo
            .Tables("result").Rows(.Tables("result").Rows.Count - 1)("Mdd_MpoSeq") = mposeqno
            .Tables("result").Rows(.Tables("result").Rows.Count - 1)("Mdd_ItemNo") = itmNo
            .Tables("result").Rows(.Tables("result").Rows.Count - 1)("Mdd_DQty") = qty
            .Tables("result").Rows(.Tables("result").Rows.Count - 1)("Mdd_CreDat") = Now()
            .Tables("result").Rows(.Tables("result").Rows.Count - 1)("Mdd_CreUsr") = gsUsrID
            '            .Update()
        End With
    End Sub
    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        Dim YNC As Integer
        ' Check Update
        ''    If check_NonApply_Record Then
        ''        YNC = MsgBox("There is/are delivery record(s) not applied!" & vbCrLf & "Would you like to apply the record?", vbQuestion + vbYesNo + vbDefaultButton1, "Delivery record(s) not applied")
        ''        If YNC = vbYes Then Exit Sub
        ''    End If
        If check_Update_Record() Then
            YNC = MsgBox("The record(s) is/are updated!" & vbCrLf & "Save before clear the screen?", vbQuestion + vbYesNoCancel + vbDefaultButton1, "Record not save")
            If YNC = vbCancel Then
                Exit Sub
            ElseIf YNC = vbYes Then
                If Enq_right_local = True Then
                    Call cmdsaveclick()
                    If save_ok = False Then Exit Sub
                Else
                    MsgBox("You do not have rights to save!" & vbCrLf & "Screen will be cleared without save!", vbInformation + vbOKOnly)
                End If
            End If
        End If
        ' Clear Screen

        Call setStatus(STS_CLEAR)

    End Sub

    Private Sub cmdClear_Click()
    End Sub
    Private Sub cmdDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelRow.Click
        If rs_DLVHDR Is Nothing Then Exit Sub
        If rs_DLVHDR.Tables("result") Is Nothing Then Exit Sub
        If rs_DLVHDR.Tables("result").Rows.Count <= 0 Then Exit Sub

        If strAction = "ADD" Then
            rs_DLVHDR.Tables("result").Rows(0).Delete()
            DocMax = DocMax - 1
            Call Display_grdDelivery()
        Else
            If bolUpdate = False Or rs_DLVHDR.Tables("result").Rows(0)("STS") = "U" Then
                rs_DLVHDR.Tables("result").Rows(0)("Mdh_DQty") = 0
            Else
                MsgBox("Please save updated information first!")
                Exit Sub
            End If
        End If

    End Sub

    Private Sub cmdDelRow_Click()
    End Sub
    Private Sub cmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsRow.Click
        If rs_DLVHDR Is Nothing Then Exit Sub
        If rs_DLVHDR.Tables("result") Is Nothing Then Exit Sub
        'If rs_DLVHDR.Tables("result").Rows.Count  <= 0 Then Exit Sub
        If DocMax > 1 Then
            MsgBox("Please save before insert a new Delivery Record!")
            Exit Sub
        End If

        With rs_DLVHDR
            .Tables("RESULT").DefaultView.RowFilter = "STS = 'N' and Mdh_DQty = 0"
            If .Tables("result").DefaultView.Count > 0 Then
                .Tables("RESULT").DefaultView.RowFilter = ""
                Call Display_grdDelivery()
                MsgBox("Delivery Qty cannot be zero!")
                Exit Sub
            End If
        End With
        rs_DLVHDR.Tables("RESULT").DefaultView.RowFilter = ""
        If rs_DLVHDR.Tables("result").DefaultView.Count > 0 Then
            Call Display_grdDelivery()
        End If
        With rs_DLVHDR
            For i2 As Integer = 0 To .Tables("RESULT").Columns.Count - 1
                .Tables("RESULT").Columns(i2).ReadOnly = False
            Next i2

            '        If .Tables("result").Rows.Count  > 0 Then .MoveLast
            .Tables("result").Rows.Add()
            .Tables("result").Rows(.Tables("result").Rows.Count - 1)("STS") = "N"
            .Tables("result").Rows(.Tables("result").Rows.Count - 1)("Mdh_DocNo") = "tmp_" & Microsoft.VisualBasic.Right("000" & Trim(Str(DocMax)), 4)
            .Tables("result").Rows(.Tables("result").Rows.Count - 1)("Mdh_DocSeq") = 0
            .Tables("result").Rows(.Tables("result").Rows.Count - 1)("Mdh_MpoNo") = ""
            .Tables("result").Rows(.Tables("result").Rows.Count - 1)("Mdh_ItmNo") = Me.txtItmNo.Text
            .Tables("result").Rows(.Tables("result").Rows.Count - 1)("Mdh_DQty") = 0
            .Tables("result").Rows(.Tables("result").Rows.Count - 1)("Mdh_FreeQty") = 0
            .Tables("result").Rows(.Tables("result").Rows.Count - 1)("Mdh_DlvDat") = Format(Now(), "MM/dd/yyyy")
            .Tables("result").Rows(.Tables("result").Rows.Count - 1)("Mdh_CreUsr") = gsUsrID
            '    .Update()
            DocMax = DocMax + 1
        End With
        If rs_DLVHDR.Tables("result").Rows.Count > 0 Then
            Call Display_grdDelivery()
        End If
        '    grdDelivery.col = colDelivery
        '    grdDelivery.LeftCol = 0
        '    grdDelivery.SetFocus
        Call grdDelivery_RowColChange(grdDelivery.RowCount, grdDelivery.ColumnCount)
        'tempzzzzzzzz

        '    Call Display_grdDelivery

    End Sub

    Private Sub cmdInsRow_Click()
    End Sub

    Private Sub cmdReset_Click()
        If (MsgBox("All modification will be erase, and, data will be reload" & vbCrLf & "Confirm to reset?", vbQuestion + vbYesNo) = vbNo) Then Exit Sub
        Cursor = Cursors.WaitCursor

        Me.grdDelivery.DataSource = Nothing
        Me.grdMPO.DataSource = Nothing

        rs_MPM00003 = Nothing
        rs_DLVHDR = Nothing
        rs_DLVDTL = Nothing
        Call setStatus(STS_CLEAR)
        Call cmdShowClick()
        Cursor = Cursors.Default
    End Sub

    'Private Function check_NonApply_Record() As Boolean
    '    'Check non-applied delivery records or not
    '    check_NonApply_Record = False
    '    If rs_DLVHDR Is Nothing Then Exit Function
    '    If rs_DLVHDR.Tables("result").Rows.Count <= 0 Then Exit Function
    '    rs_DLVHDR.Tables("RESULT").DefaultView.RowFilter = "STS='N'"
    '    If rs_DLVHDR.Tables("result").DefaultView.Count > 0 Then
    '        'rs_DLVHDR.MoveFirst()
    '        'Do While Not rs_DLVHDR.EOF
    '        '    grdDelivery.SelBookmarks.Add(grdDelivery.bookmark)
    '        '    rs_DLVHDR.MoveNext()
    '        'Loop
    '        'tempzzzzzzzzzzzzzzzzzzzzzzz
    '        'tempzzzzzzzzzzzzzzzzzzzzzzz
    '        check_NonApply_Record = True
    '    End If
    '    rs_DLVHDR.Tables("RESULT").DefaultView.RowFilter = ""
    '    Call Display_grdDelivery()
    'End Function

    Private Function check_Update_Record() As Boolean
        'Check non-applied delivery records or not
        check_Update_Record = False
        If rs_MPM00003 Is Nothing Then Exit Function
        If rs_MPM00003.Tables("result") Is Nothing Then Exit Function

        If rs_MPM00003.Tables("result").Rows.Count <= 0 Then Exit Function
        rs_MPM00003.Tables("RESULT").DefaultView.RowFilter = "[Adjust Qty]<>0"
        If rs_MPM00003.Tables("result").DefaultView.Count > 0 Then
            check_Update_Record = True
        End If
        rs_MPM00003.Tables("RESULT").DefaultView.RowFilter = ""
        Call display_grdMPO()
    End Function

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Call cmdsaveclick()
    End Sub

    Public Sub cmdsaveclick()
        Dim S As String
        Dim docno As String
        Dim currDOcNo As String
        Dim isHdrUpdate As Boolean
        Dim isDtlUpdate As Boolean
        Dim Index As Integer

        Dim ttlDlvQty As Double
        Dim ttlMPOQty As Double

        save_ok = True
        If rs_DLVHDR Is Nothing Then Exit Sub
        If rs_DLVDTL Is Nothing Then Exit Sub
        If rs_DLVHDR.Tables("result") Is Nothing Then Exit Sub
        If rs_DLVDTL.Tables("result") Is Nothing Then Exit Sub
        If rs_DLVHDR.Tables("result").Rows.Count <= 0 Then Exit Sub
        '    If rs_DLVDTL.Tables("result").Rows.Count  <= 0 Then Exit Sub
        save_ok = False

        If strAction = "ADD" Then

            ttlDlvQty = 0
            ttlMPOQty = 0

            'Obtain Delivery Total Qty
            If Not rs_DLVHDR Is Nothing Then
                If Not rs_DLVHDR.Tables("result") Is Nothing Then
                    bolDisplay = True
                    With rs_DLVHDR
                        If .Tables("result").Rows.Count > 0 Then
                            For index9 As Integer = 0 To .Tables("RESULT").Rows.Count - 1
                                ttlDlvQty = ttlDlvQty + IIf(IsDBNull(.Tables("result").Rows(index9)("Mdh_DQty")), 0, .Tables("result").Rows(index9)("Mdh_DQty"))
                                'Check Trigger Row Col Update or not
                            Next
                        End If
                    End With
                    bolDisplay = False
                End If
            End If

            If ttlDlvQty <= 0 Then
                MsgBox("Please Input Delivery Qty!")
                Exit Sub
            End If


            'Obtain MPO Distributed Total Qty
            If Not rs_MPM00003 Is Nothing Then
                If Not rs_MPM00003.Tables("result") Is Nothing Then
                    bolDisplay = True
                    With rs_MPM00003
                        If .Tables("result").Rows.Count > 0 Then

                            For index9 As Integer = 0 To .Tables("RESULT").Rows.Count - 1
                                ttlMPOQty = ttlMPOQty + IIf(IsDBNull(.Tables("result").Rows(index9)("Mpd_DQty")), 0, .Tables("result").Rows(index9)("Mpd_DQty"))
                            Next

                        End If
                    End With
                    bolDisplay = False
                End If
            End If
        Else
            ttlDlvQty = 0
            ttlMPOQty = 0

            'Obtain Delivery Total Qty
            If Not rs_DLVHDR Is Nothing Then
                If Not rs_DLVHDR.Tables("result") Is Nothing Then
                    bolDisplay = True
                    With rs_DLVHDR
                        If .Tables("result").Rows.Count > 0 Then

                            For index9 As Integer = 0 To .Tables("RESULT").Rows.Count - 1
                                ttlDlvQty = ttlDlvQty + IIf(IsDBNull(.Tables("result").Rows(index9)("Mdh_DQty")), 0, .Tables("result").Rows(index9)("Mdh_DQty"))
                                docno = .Tables("result").Rows(index9)("Mdh_DocNo")
                            Next
                            currDOcNo = .Tables("result").Rows(0)("Mdh_DocNo")

                        End If
                    End With
                    bolDisplay = False
                End If
            End If

            If Not rs_MPM00003 Is Nothing Then
                If Not rs_MPM00003.Tables("RESULT") Is Nothing Then
                    rs_MPM00003.Tables("RESULT").DefaultView.RowFilter = " Mdd_DocNo='" & docno & "'"

                    bolDisplay = True
                    With rs_MPM00003
                        If .Tables("result").DefaultView.Count > 0 Then
                            For index9 As Integer = 0 To .Tables("RESULT").DefaultView.Count - 1
                                ttlMPOQty = ttlMPOQty + IIf(IsDBNull(.Tables("result").DefaultView(index9)("Mpd_DQty")), 0, .Tables("result").DefaultView(index9)("Mpd_DQty"))
                            Next
                        End If
                    End With
                    bolDisplay = False
                    rs_MPM00003.Tables("RESULT").DefaultView.RowFilter = "Mdd_DocNo='" & currDOcNo & "'"
                    Call display_grdMPO()
                End If
            End If
        End If

        'Prompt if delivery qty not match
        If ttlDlvQty <> ttlMPOQty Then
            MsgBox("Delivery Qty (" & Str(ttlDlvQty) & ") is not match with Distributed Qty (" & Str(ttlMPOQty) & ")!")
            Exit Sub
        End If

        'Retrieve Document No
        '-------------------------------------------------------------------------
        If strAction = "ADD" Then
            If txtDlvNo.Text.Trim <> "" Then
                MsgBox("Saving error, please clear the screen and input the data again.")
                Exit Sub
            End If
            'in this case, last saving is not successed, not clear, and try to re-save.
            gsCompany = IIf(gsCompanyGroup = "UCG", "UCPP", "MS")
            Call Update_gs_Value(gsCompany)
            gspStr = "sp_select_DOC_GEN '" & "UCPP" & "','MD','" & gsUsrID & "'"
            'tempzzzzzzzzzzzzzzzzz   co
            rtnLong = execute_SQLStatement(gspStr, rs_tmp, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cmdSaveClick sp_select_DOC_GEN :" & rtnStr)
                Cursor = Cursors.Default
                Exit Sub
            End If
            docno = rs_tmp.Tables("RESULT").Rows(0)(0).ToString
            If docno = "" Then Exit Sub
            Me.txtDlvNo.Text = docno
            '-------------------------------------------------------------------------

            With rs_DLVHDR
                .Tables("RESULT").DefaultView.RowFilter = "Mdh_DQty > 0"
                If .Tables("result").Rows.Count > 0 Then

                    For index9 As Integer = 0 To .Tables("RESULT").DefaultView.Count - 1
                        gspStr = "sp_insert_MPDLVHDR '" & "" & "','" & docno & _
                                         "','1" & _
                                         "','" & .Tables("result").DefaultView(index9)("Mdh_MpoNo") & _
                                         "','" & .Tables("result").DefaultView(index9)("Mdh_ItmNo") & _
                                         "','" & .Tables("result").DefaultView(index9)("Mdh_DQty") & _
                                         "','" & .Tables("result").DefaultView(index9)("Mdh_FreeQty") & _
                                         "','" & .Tables("result").DefaultView(index9)("Mdh_DlvDat") & _
                                         "','" & gsUsrID & "'"

                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading cmdSaveClick sp_insert_MPDLVHDR :" & rtnStr)
                            Cursor = Cursors.Default
                            Exit Sub
                        End If
                    Next


                End If
                .Tables("RESULT").DefaultView.RowFilter = ""
                Call Display_grdDelivery()
            End With
        Else

            With rs_DLVHDR
                '.Tables("RESULT").defaultview.rowFilter = "Mdh_DQty <> Ori_DQty"
                If .Tables("result").Rows.Count > 0 Then
                    If .Tables("result").Rows(0)("Mdh_DQty") <> .Tables("result").Rows(0)("Ori_DQty") Then
                        gspStr = "sp_update_MPDLVHDR '" & "" & "','" & docno & _
                                         "','" & .Tables("result").Rows(0)("Mdh_DocSeq") & _
                                         "','" & .Tables("result").Rows(0)("Mdh_MpoNo") & _
                                         "','" & .Tables("result").Rows(0)("Mdh_ItmNo") & _
                                         "','" & .Tables("result").Rows(0)("Mdh_DQty") - .Tables("result").Rows(0)("Ori_DQty") & _
                                         "','" & .Tables("result").Rows(0)("Mdh_FreeQty") & _
                                         "','" & .Tables("result").Rows(0)("Mdh_DlvDat") & _
                                         "','" & gsUsrID & "'"
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading cmdSaveClick sp_update_MPDLVHDR:" & rtnStr)
                            Cursor = Cursors.Default
                            Exit Sub
                        End If
                    End If
                End If
                '.Tables("RESULT").defaultview.rowFilter = ""
                Call Display_grdDelivery()
            End With
        End If
        '-------------------------------------------------------------------------
        With rs_MPM00003
            .Tables("RESULT").DefaultView.RowFilter = "[Adjust Qty] <> 0"
            If .Tables("result").DefaultView.Count > 0 Then
                For index9 As Integer = 0 To .Tables("RESULT").DefaultView.Count - 1
                    gspStr = "sp_update_MPORDDTL_MPO03'" & "" & "','" & .Tables("result").DefaultView(index9)("Mph_MpoNo") & _
                                       "','" & .Tables("result").DefaultView(index9)("Mpd_MPOseq") & _
                                       "','" & .Tables("result").DefaultView(index9)("Adjust Qty") & _
                                       "','" & gsUsrID & _
                                       "','" & docno & _
                                       "','1" & _
                                       "','" & Me.txtItmNo.Text & _
                                       "','" & strAction & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading cmdSaveClick sp_update_MPORDDTL_MPO03:" & rtnStr)
                        Cursor = Cursors.Default
                        Exit Sub
                    End If
                Next

            End If
            .Tables("RESULT").DefaultView.RowFilter = ""
        End With
        '-------------------------------------------------------------------------


        rs_DLVHDR.Tables("RESULT").DefaultView.RowFilter = ""
        rs_DLVDTL.Tables("RESULT").DefaultView.RowFilter = ""
        rs_MPM00003.Tables("RESULT").DefaultView.RowFilter = ""
        Call Display_grdDelivery()
        Call display_grdMPO()

        MsgBox("Record Save!")
        Call setStatus(STS_CLEAR)
    End Sub
    Public Sub cmdShowClick()

        Dim S As String
        '        Dim rs() As New DataSet

        strAction = "ADD"
        If Me.optModify.Checked = True Then
            strAction = "MODIFY"
            bolUpdate = False
        End If

        If strAction = "ADD" Then
            Me.txtItmNo.Text = UCase(Me.txtItmNo.Text)
            Me.txtDlvNo.Text = ""
        Else
            Me.txtItmNo.Text = UCase(Me.txtItmNo.Text)
            Me.txtDlvNo.Text = UCase(Me.txtDlvNo.Text)
        End If
        If Trim(Me.txtItmNo.Text) = "" Then
            MsgBox("Please Input Item No!")
            Call setFocus_text(Me.txtItmNo)
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor

        If gsCompanyGroup = "MSG" Then
            If gsCompany <> "MS" Then
                gsCompany = "MS"
            End If
        Else
            If gsCompany = "ALL" Or gsCompany = "UC-G" Then
                gsCompany = gsDefaultCompany
            End If
        End If
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_MPM00003_MPO  '','" & Trim(Me.txtDlvNo.Text) & "','" & Trim(Me.txtItmNo.Text) & "','" & strAction & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_MPM00003, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp_select_MPO00003  :" & rtnStr)
            Exit Sub
        End If
        If rs_MPM00003.Tables("result").Rows.Count <= 0 Then
            MsgBox("No record found!")
            Exit Sub
        End If

        gspStr = "sp_select_MPM00003_DLVHDR  '','" & Trim(Me.txtDlvNo.Text) & "','" & Trim(Me.txtItmNo.Text) & "','" & strAction & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_DLVHDR, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp_select_MPM00003_DLVHDR:" & rtnStr)
            Exit Sub
        End If
        With rs_DLVHDR
            For i2 As Integer = 0 To .Tables("RESULT").Columns.Count - 1
                .Tables("RESULT").Columns(i2).ReadOnly = False
            Next i2
        End With

        rs_DLVHDR_blank = rs_DLVHDR.Copy


        gspStr = "sp_select_MPM00003_DLVDTL  '' "
        rtnLong = execute_SQLStatement(gspStr, rs_DLVDTL, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading  sp_select_MPM00003_DLVDTL  :" & rtnStr)
            Exit Sub
        End If

        With rs_DLVDTL
            For i2 As Integer = 0 To .Tables("RESULT").Columns.Count - 1
                .Tables("RESULT").Columns(i2).ReadOnly = False
            Next i2
        End With

        DocMax = 1
        Call set_Sequence(rs_MPM00003)
        Call Display_grdDelivery()
        Call display_grdMPO()
        If strAction = "MODIFY" Then
            Call grdDelivery_RowColChange(1, 1)
            'tempzz

        End If
        Call setStatus(STS_UPDATE)
        Call set_StatusPanel()
        Cursor = Cursors.Default



    End Sub



    Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
        Call cmdShowClick()
    End Sub
    'goto
    Private Function set_Sequence(ByRef rs_SEQ As DataSet)
        Dim seq As Long
        If rs_SEQ Is Nothing Then Exit Function
        If rs_SEQ.Tables("result") Is Nothing Then Exit Function

        If rs_SEQ.Tables("result").Rows.Count <= 0 Then Exit Function
        If strAction = "ADD" Then
            With rs_SEQ
                If .Tables("result").Rows.Count > 0 Then
                    seq = 0
                    Me.txtSeqFm.Text = seq + 1
                    For index9 As Integer = 0 To .Tables("RESULT").Rows.Count - 1
                        seq = seq + 1

                        For i2 As Integer = 0 To .Tables("RESULT").Columns.Count - 1
                            .Tables("RESULT").Columns(i2).ReadOnly = False
                        Next i2


                        .Tables("result").Rows(index9)("seq") = seq
                        'tempzzzzzz
                        .Tables("result").Rows(index9)("Ori_DQty") = 0
                        .Tables("result").Rows(index9)("Mpd_DQty") = 0
                        .Tables("result").Rows(index9)("Mdd_DQty") = 0
                        .Tables("result").Rows(index9)("Adjust Qty") = 0
                        .Tables("result").Rows(index9)("Prv_DQty") = 0
                    Next
                End If
                Me.txtSeqTo.Text = seq
            End With
        Else
            With rs_SEQ
                For i2 As Integer = 0 To .Tables("RESULT").Columns.Count - 1
                    .Tables("RESULT").Columns(i2).ReadOnly = False
                Next i2


                If .Tables("result").Rows.Count > 0 Then
                    seq = 0
                    Me.txtSeqFm.Text = seq + 1
                    For index9 As Integer = 0 To .Tables("RESULT").Rows.Count - 1
                        seq = seq + 1
                        .Tables("result").Rows(index9)("Seq") = seq
                        '.Tables("result").Rows(index9)("Ori_DQty") = 0
                        '.Tables("result").Rows(index9)("Mpd_DQty") = 0
                        '.Tables("result").Rows(index9)("Mdd_DQty") = 0
                        .Tables("result").Rows(index9)("Adjust Qty") = 0
                        '.Tables("result").Rows(index9)("Prv_DQty") = 0
                    Next
                End If
                Me.txtSeqTo.Text = seq
            End With

        End If
    End Function

    Private Function Display_grdDelivery()

        Dim intCol As Integer

        If Not Me.grdDelivery.DataSource Is Nothing Then Me.grdDelivery.DataSource = Nothing
        If rs_DLVHDR Is Nothing Then Exit Function
        If rs_DLVHDR.Tables("result") Is Nothing Then Exit Function
        If rs_DLVHDR.Tables("result").Rows.Count <= 0 Then Exit Function


        bolDisplay = True

        Me.grdDelivery.DataSource = rs_DLVHDR.Tables("result")

        With Me.grdDelivery
            intCol = 0
            .Columns(intCol).HeaderText = "Status"
            .Columns(intCol).Width = 600 / 10
            .Columns(intCol).ReadOnly = True

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Ref No"
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Ref Seq"
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "MPO No"
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False
            '.Columns(intCol).readonly = True

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Item No"
            .Columns(intCol).Width = 1200 / 10
            .Columns(intCol).ReadOnly = True

            '        If strAction = "ADD" Then
            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Ori Delivery Qty"
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False
            '        Else
            '            intCol = intCol + 1
            '            .Columns(intCol).headertext= "Ori Delivery Qty"
            '            .Columns(intCol).width = 1400
            '        End If


            intCol = intCol + 1
            colDelivery = intCol
            .Columns(intCol).HeaderText = "Delivery Qty"
            .Columns(intCol).Width = 1200 / 10

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Free Qty"
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

            intCol = intCol + 1
            colDlvDate = intCol
            .Columns(intCol).HeaderText = "Delivery Date"
            .Columns(intCol).Width = 1200 / 10

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Create Date"
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Create User"
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False


        End With
        bolDisplay = False

    End Function

    Private Function display_grdMPO()
        Dim intCol As Integer
        bolDisplay = True
        Me.grdMPO.DataSource = rs_MPM00003.Tables("result")
        With grdMPO
            intCol = 0
            .Columns(intCol).HeaderText = "Seq"
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Width = 400 / 13

            intCol = intCol + 1
            colSelect = intCol
            .Columns(intCol).HeaderText = "Status"
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Width = 500 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "MPO No"
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Width = 1100 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "MPO Seq"
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Width = 800 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "PO No"
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Width = 1100 / 13


            intCol = intCol + 1
            .Columns(intCol).HeaderText = "PO Seq"
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Width = 700 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Item No"
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Width = 1300 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "UM"
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Width = 600 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Order Qty"
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Width = 800 / 13


            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Ship Qty"
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Width = 900 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "OS Qty"
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Width = 800 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Ori DQty"
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

            intCol = intCol + 1
            colMPODelivery = intCol
            .Columns(intCol).HeaderText = "Delivery Qty"
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Width = 1000 / 13

            If strAction = "ADD" Then
                intCol = intCol + 1
                .Columns(intCol).HeaderText = "Distributed DQty"
                .Columns(intCol).ReadOnly = True
                .Columns(intCol).Width = 0
                .Columns(intCol).Visible = False
            Else
                intCol = intCol + 1
                .Columns(intCol).HeaderText = "Distributed DQty"
                .Columns(intCol).ReadOnly = True
                .Columns(intCol).Width = 1200 / 13
            End If

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Adjust Qty"
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Width = 800 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Prv Delivery Qty"
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Item Name"
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Width = 2400 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Vendor No"
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Width = 800 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Import Fty"
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Width = 1000 / 13

            intCol = intCol + 1
            .Columns(intCol).HeaderText = "Ship Place"
            .Columns(intCol).ReadOnly = True
            .Columns(intCol).Width = 1000 / 13

            intCol = intCol + 1
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

            intCol = intCol + 1
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

            intCol = intCol + 1
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

            intCol = intCol + 1
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False

            intCol = intCol + 1
            .Columns(intCol).Width = 0
            .Columns(intCol).Visible = False
        End With



        bolDisplay = False
    End Function

    Private Sub MPM00003_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Cursor = Cursors.WaitCursor

        Me.Icon = ERP00000.Icon

        AccessRight(Me.Name) '*** For Access Right use, added by Tommy on 5 Oct 2001
        Enq_right_local = Enq_right
        Del_right_local = Del_right

        Call Formstartup(Me.Name)

        '#If useMTS Then
        '        Set objBSGate = CreateObject("ucpBS_Gate.clsBSGate", serverName)
        '#Else
        '        objBSGate = CreateObject("ucpBS_Gate.clsBSGate")
        '#End If

        'If gsConnStr = "" Then
        '    gsConnStr = getConnectionString()
        'End If

        Recordstatus = False
        Call Formstartup(Me.Name)

        Call setStatus(STS_INIT)

        Cursor = Cursors.Default

    End Sub
    Private Sub MPM00003_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' Check any update record before exit
        Dim YNC As Integer
        ' Check Update
        ''    If check_NonApply_Record Then
        ''        YNC = MsgBox("There is/are delivery record(s) not applied!" & vbCrLf & "Would you like to apply the record before exit?", vbQuestion + vbYesNo + vbDefaultButton1, "Delivery record(s) not applied")
        ''        If YNC = vbYes Then Exit Sub
        ''    End If
        If check_Update_Record() Then

            YNC = MsgBox("The MPO record(s) is/are updated!" & vbCrLf & "Save before exit?", vbQuestion + vbYesNoCancel + vbDefaultButton1, "Record not save")
            If YNC = vbCancel Then
                Exit Sub
            ElseIf YNC = vbYes Then
                If Enq_right_local = True Then
                    Call cmdsaveclick()
                    If save_ok = False Then Exit Sub
                Else
                    MsgBox("You do not have rights to save!" & vbCrLf & "Program will exit without save.", vbInformation + vbOKOnly)
                End If
            End If

        End If

        ' advise user to save before exit if there is any update

        grdDelivery.DataSource = Nothing
        grdMPO.DataSource = Nothing

        rs_MPM00003 = Nothing
        rs_DLVHDR = Nothing
        rs_DLVDTL = Nothing


    End Sub


    Private Sub Form_Unload(ByVal Cancel As Integer)
    End Sub




    Private Sub grdDelivery_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDelivery.CellEndEdit
        Dim ColIndex As Integer
        On Error GoTo err_Handle_rt
        Dim strDate As String
        ColIndex = e.ColumnIndex

        If ColIndex = colDelivery Then

            If Trim(grdDelivery.Item(ColIndex, grdDelivery.CurrentCell.RowIndex).Value()) = "" Then
                grdDelivery.Item(ColIndex, grdDelivery.CurrentCell.RowIndex).Value() = "0"
            End If
            With rs_DLVHDR
                'tempzzzzzzzzzz  row(0)
                If IsDBNull(.Tables("result").Rows(0)("Mdh_DQty")) Then
                    .Tables("result").Rows(0)("Mdh_DQty") = 0
                End If
                If IsDBNull(.Tables("result").Rows(0)("Ori_DQty")) Then
                    .Tables("result").Rows(0)("Ori_DQty") = 0
                End If
                If .Tables("result").Rows(0)("Mdh_DQty") <> .Tables("result").Rows(0)("Ori_DQty") Then
                    .Tables("result").Rows(0)("STS") = "U"
                    bolUpdate = True
                    bolUPDFlg = True
                    '      lngPos = .AbsolutePosition
                    lngPos = e.RowIndex
                    'tempzzzzzzzzzzzzzzzzzzzzzzzzzzzz
                Else
                    .Tables("result").Rows(0)("STS") = "O"
                    bolUpdate = False
                    bolUPDFlg = False
                End If
            End With
            '        rs_DLVHDR.Tables("result").Rows(0)("Adjust Qty") = rs_DLVHDR.Tables("result").Rows(0)("Mpd_DQty") - rs_DLVHDR.Tables("result").Rows(0)("Ori_DQty")
        ElseIf ColIndex = colDlvDate Then
            strDate = grdDelivery.Item(ColIndex, grdDelivery.CurrentCell.RowIndex).Value()
            'tempzzzzzzzzzzzzzzzzzzzzz
            If Len(strDate) = 0 Then
                MsgBox("Please input Delivery Date!")
                Exit Sub
            Else
                If InStr(strDate, "/") > 0 Then
                    If UBound(Split(strDate, "/")) <> 2 Then
                        MsgBox("Invalid Delivery Date Fromat (MM/dd/yyyy)!")
                        'grdDelivery.col = ColIndex
                        'tempz
                        If grdDelivery.Visible And grdDelivery.Enabled Then grdDelivery.Focus()
                        Exit Sub
                    Else
                        If Not IsDate(strDate) Then
                            MsgBox("Invalid Delivery Date Format (MM/dd/yyyy)!")
                            'grdDelivery.col = ColIndex
                            If grdDelivery.Visible And grdDelivery.Enabled Then grdDelivery.Focus()
                            Exit Sub
                        End If
                    End If
                Else
                    MsgBox("Invalid Delivery Date Format (MM/dd/yyyy)!")
                    '                    grdDelivery.col = ColIndex
                    If grdDelivery.Visible And grdDelivery.Enabled Then grdDelivery.Focus()
                    Exit Sub
                End If
            End If
            ''            grdDelivery.Columns(grdDelivery.col).Value = Format(strDate, "MM/dd/yyyy")
            grdDelivery.Item(ColIndex, grdDelivery.CurrentCell.RowIndex).Value() = Format(strDate, "MM/dd/yyyy")
        End If

        Exit Sub
err_Handle_rt:
        Err.Clear()

    End Sub
    Private Sub grdDelivery_AfterColEdit(ByVal ColIndex As Integer)

    End Sub

    Private Sub grdDelivery_ColEdit(ByVal ColIndex As Integer)
        '    If ColIndex = colDlvDate Then
        '        grdDelivery.Columns(ColIndex).Text = Format(grdDelivery.Columns(ColIndex).Text, "##/##/####")
        '    End If
    End Sub

    Private Sub grdDelivery_Error(ByVal DataError As Integer, ByVal Response As Integer)
        '    MsgBox DataError
        Response = 0
        'temp
    End Sub
    Private Sub grdDelivery_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles grdDelivery.DataError

    End Sub



    Private Sub grdDelivery_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDelivery.GotFocus
        '    If Not grdDelivery.DataSource Is Nothing Then
        '        grdDelivery.col = colDelivery
        '    End If

        If grdDelivery.ColumnCount > 2 Then
            If grdDelivery.CurrentCell.ColumnIndex = colDlvDate Then
                'grdDelivery.selectionStart = 0
                'grdDelivery.SelectionLength = 10
                'tempzzzzzzzzzzzzzzzzzzzzzzzzz
            End If
        End If

    End Sub
    Private Sub grdDelivery_GotFocus()
    End Sub
    Private Sub grdDelivery_KeyPress(ByVal KeyAscii As Integer)

    End Sub
    Private Sub grdDelivery_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDelivery.CurrentCellChanged
        Dim dlvno As String

        If strAction <> "MODIFY" Then Exit Sub
        If bolDisplay = True Then Exit Sub
        If rs_DLVHDR Is Nothing Then Exit Sub
        If rs_DLVHDR.Tables("result") Is Nothing Then Exit Sub
        If rs_DLVHDR.Tables("result").Rows.Count <= 0 Then Exit Sub

        dlvno = rs_DLVHDR.Tables("result").Rows(0)("Mdh_DocNo")
        With rs_MPM00003
            .Tables("RESULT").DefaultView.RowFilter = "Mdd_DocNo='" & dlvno & "'"
        End With
        Call display_grdMPO()



        If Not grdDelivery.CurrentCell Is Nothing Then
            If grdDelivery.CurrentCell.ColumnIndex > 0 Then
                If bolUpdate Then
                    '                If bolUpdate And rs_DLVHDR.AbsolutePosition <> lngPos Then
                    If bolUpdate And grdDelivery.CurrentCell.RowIndex <> lngPos Then
                        grdDelivery.Columns(colDelivery).ReadOnly = True
                        grdDelivery.Columns(colDlvDate).ReadOnly = True
                    Else
                        grdDelivery.Columns(colDelivery).ReadOnly = False
                        grdDelivery.Columns(colDlvDate).ReadOnly = False
                    End If
                End If
            End If

        End If




    End Sub

    Private Sub grdDelivery_RowColChange(ByVal LastRow As Object, ByVal LastCol As Integer)
        Dim dlvno As String

        If strAction <> "MODIFY" Then Exit Sub
        If bolDisplay = True Then Exit Sub
        If rs_DLVHDR Is Nothing Then Exit Sub
        If rs_DLVHDR.Tables("result") Is Nothing Then Exit Sub
        If rs_DLVHDR.Tables("result").Rows.Count <= 0 Then Exit Sub

        dlvno = rs_DLVHDR.Tables("result").Rows(0)("Mdh_DocNo")
        With rs_MPM00003
            .Tables("RESULT").DefaultView.RowFilter = "Mdd_DocNo='" & dlvno & "'"
        End With
        Call display_grdMPO()




        If Not grdDelivery.CurrentCell Is Nothing Then
            If grdDelivery.CurrentCell.ColumnIndex > 0 Then
                If bolUpdate Then
                    '                If bolUpdate And rs_DLVHDR.AbsolutePosition <> lngPos Then
                    If bolUpdate And grdDelivery.CurrentCell.RowIndex <> lngPos Then
                        grdDelivery.Columns(colDelivery).ReadOnly = True
                        grdDelivery.Columns(colDlvDate).ReadOnly = True
                    Else
                        grdDelivery.Columns(colDelivery).ReadOnly = False
                        grdDelivery.Columns(colDlvDate).ReadOnly = False
                    End If
                End If
            End If

        End If
        'tempzzzzzzzzzzzz
    End Sub

    Private Sub grdMPO_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdMPO.CellEndEdit
        'tempzzzzzzzzzzz
        Dim lngAdjQty As Double
        Dim lngDeductQty As Double
        Dim ColIndex As Integer
        Dim index9 As Integer
        ColIndex = e.ColumnIndex
        index9 = e.RowIndex

        If ColIndex = colMPODelivery Then
            If Not IsDBNull(grdMPO.Item(ColIndex, grdDelivery.CurrentCell.RowIndex).Value()) Then
                If grdMPO.Item(ColIndex, grdDelivery.CurrentCell.RowIndex).Value.ToString.Trim = "" Then
                    grdMPO.Item(ColIndex, grdDelivery.CurrentCell.RowIndex).Value() = 0
                End If
            Else
                grdMPO.Item(ColIndex, grdDelivery.CurrentCell.RowIndex).Value() = 0
                Exit Sub
            End If
            With rs_MPM00003
                lngAdjQty = .Tables("result").Rows(index9)("Mpd_DQty") - .Tables("result").Rows(index9)("Ori_DQty")
                If lngAdjQty > 0 Then
                    If lngAdjQty > .Tables("result").Rows(index9)("OS_Qty") Then
                        MsgBox("Adjust Qty > OS Qty!" & vbCrLf & "Delivery will be set to previous value")
                        .Tables("result").Rows(index9)("Mpd_DQty") = .Tables("result").Rows(index9)("Prv_DQty")
                        Exit Sub
                    End If
                ElseIf lngAdjQty < 0 Then
                    lngDeductQty = .Tables("result").Rows(index9)("Mpd_Qty") - .Tables("result").Rows(index9)("OS_Qty") - .Tables("result").Rows(index9)("Mpd_ShpQty")
                    If lngDeductQty > .Tables("result").Rows(index9)("Mdd_DQty") Then
                        lngDeductQty = .Tables("result").Rows(index9)("Mdd_DQty")
                    End If
                    If Math.Abs(lngAdjQty) > lngDeductQty Then
                        MsgBox("Adjust Qty (" & lngAdjQty & ") > Deductable Qty!")
                        .Tables("result").Rows(index9)("Mpd_DQty") = .Tables("result").Rows(index9)("Prv_DQty")
                        Exit Sub
                    End If
                End If
                .Tables("result").Rows(index9)("Prv_DQty") = .Tables("result").Rows(index9)("Mpd_DQty")
                .Tables("result").Rows(index9)("Adjust Qty") = .Tables("result").Rows(index9)("Mpd_DQty") - .Tables("result").Rows(index9)("Ori_DQty")
            End With
        End If

    End Sub
    Private Sub grdMPO_AfterColEdit(ByVal ColIndex As Integer)
    End Sub
    Private Sub grdMPO_RowHeaderMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdMPO.RowHeaderMouseDoubleClick
        


    End Sub

    Private Sub grdMPO_HeadClick(ByVal ColIndex As Integer)
    End Sub
    Private Sub grdMPO_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdMPO.EditingControlShowing
        '        gi_dgselstart2 = CType(e.Control, TextBox).SelectionStart

        Dim txtEdit2 As TextBox = e.Control
        'remove any existing handler
        RemoveHandler txtEdit2.KeyPress, AddressOf txtEdit2_Keypress
        AddHandler txtEdit2.KeyPress, AddressOf txtEdit2_Keypress


    End Sub
    Private Sub txtEdit2_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'tempzzz

        If grdMPO.CurrentCell.ColumnIndex = colDelivery Then

            e.KeyChar = Chr(check_numeric_size(sender.text, Asc(e.KeyChar), sender.selectionstart, 18, 2))

        End If

        'If grdMPO.col = colMPODelivery Then
        '    'If KeyAscii <> 9 And KeyAscii <> 8 And KeyAscii <> 20 And InStr("0123456789", Chr(KeyAscii)) <= 0 Then e.KeyChar = Chr( 0
        '    e.KeyChar = Chr( check_numeric_size(grdMPO.Columns(colMPODelivery).Text, KeyAscii, grdMPO.selStart, 18, 2)
        'End If

    End Sub

    Private Sub grdMPO_KeyPress(ByVal KeyAscii As Integer)
        'If grdMPO.col = colMPODelivery Then
        '    'If KeyAscii <> 9 And KeyAscii <> 8 And KeyAscii <> 20 And InStr("0123456789", Chr(KeyAscii)) <= 0 Then e.KeyChar = Chr( 0
        '    e.KeyChar = Chr( check_numeric_size(grdMPO.Columns(colMPODelivery).Text, KeyAscii, grdMPO.selStart, 18, 2)
        'End If
    End Sub

    Private Sub grdMPO_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdMPO.CurrentCellChanged
        Call set_StatusPanel()
        If rs_MPM00003 Is Nothing Then Exit Sub
        If rs_MPM00003.Tables("result") Is Nothing Then Exit Sub
        If rs_MPM00003.Tables("result").Rows.Count <= 0 Then Exit Sub
        If bolDisplay Then Exit Sub

        bolUPDFlg = False
        On Error Resume Next
        If Not rs_DLVHDR Is Nothing Then
            If Not rs_DLVHDR.Tables("result") Is Nothing Then
                If rs_DLVHDR.Tables("result").Rows.Count > 0 Then
                    If rs_DLVHDR.Tables("result").Rows(0)("STS") = "U" Then bolUPDFlg = True
                End If
            End If
        End If
        On Error GoTo 0

        If rs_MPM00003.Tables("result").Rows(0)("Mph_MpoSts") = "ACT" Then
            grdMPO.Columns(colMPODelivery).ReadOnly = Not bolUPDFlg
        Else
            grdMPO.Columns(colMPODelivery).ReadOnly = True
        End If

    End Sub

    Private Sub grdMPO_RowColChange(ByVal LastRow As Object, ByVal LastCol As Integer)

    End Sub

    Private Sub optAdd_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles optAdd.Click
        strAction = "ADD"
        Me.txtDlvNo.Text = ""
        Me.txtDlvNo.Enabled = False
        If Me.txtItmNo.Enabled = True Then Me.txtItmNo.Focus()

    End Sub


    Private Sub optAdd_Click()
    End Sub
    Private Sub optModify_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles optModify.Click
        strAction = "MODIFY"
        '    Me.txtDlvNo.Text = ""
        Me.txtDlvNo.Enabled = True
        Me.txtDlvNo.Focus()
    End Sub

    Private Sub optModify_Click()
    End Sub
    Private Sub txtItmNo_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItmNo.KeyPress
        If e.KeyChar = Chr(13) Then cmdShowClick()

    End Sub
    Private Sub txtDlvNo_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDlvNo.KeyPress
        If e.KeyChar = Chr(13) And Me.txtItmNo.Enabled = True Then Me.txtItmNo.Focus()
    End Sub


    'Private Sub txtSeqFm_GotFocus()
    '    Call setFocus_text(Me.txtSeqFm)
    'End Sub

    'Private Sub txtSeqFm_KeyPress(ByVal KeyAscii As Integer)
    '    If e.KeyChar = Chr( 8 Or InStr("0123456789", Chr(KeyAscii)) > 0 Then Exit Sub
    '    e.KeyChar = Chr( 0
    'End Sub

    'Private Sub txtSeqFm_LostFocus()
    '    If Trim(txtSeqFm.Text) = "" Then txtSeqFm.Text = "0"
    'End Sub

    'Private Sub txtSeqTo_GotFocus()
    '    Call setFocus_text(Me.txtSeqTo)
    'End Sub

    'Private Sub txtSeqTo_KeyPress(ByVal KeyAscii As Integer)
    '    If e.KeyChar = Chr( 8 Or InStr("0123456789", Chr(KeyAscii)) > 0 Then Exit Sub
    '    e.KeyChar = Chr( 0
    'End Sub

    'Private Sub txtSeqTo_LostFocus()
    '    If Trim(txtSeqTo.Text) = "" Then txtSeqTo.Text = "0"
    'End Sub

    Private Sub grdDelivery_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDelivery.CellContentClick

    End Sub

    Private Sub grdDelivery_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdDelivery.EditingControlShowing
        gi_dgselstart = CType(e.Control, TextBox).SelectionStart

        Dim txtEdit As TextBox = e.Control
        'remove any existing handler
        RemoveHandler txtEdit.KeyPress, AddressOf txtEdit_Keypress
        AddHandler txtEdit.KeyPress, AddressOf txtEdit_Keypress

    End Sub

    Private Sub txtEdit_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        On Error GoTo err_Handle_dlv

        If grdDelivery.CurrentCell.ColumnIndex = colDelivery Then

            e.KeyChar = Chr(check_numeric_size(sender.text, Asc(e.KeyChar), sender.selectionstart, 18, 2))

        ElseIf grdDelivery.CurrentCell.ColumnIndex = colDlvDate Then
            If e.KeyChar <> Chr(9) And e.KeyChar <> Chr(8) And e.KeyChar <> Chr(20) And Len(grdDelivery.Item(colDlvDate, grdDelivery.CurrentCell.RowIndex).Value()) > 9 Then e.KeyChar = Chr(0)
        End If
err_Handle_dlv:
        Err.Clear()

    End Sub

    Public Function check_numeric_size(ByVal val As String, ByVal key As Integer, ByVal pos As Integer, ByVal p As Integer, ByVal d As Integer) As Integer

        val = Trim(val)



        If ((InStr("0123456789.", Chr(key)) = 0) And key > 31) Or _
            ((InStr(val, ".") <> 0) And key > 31 And Chr(key) = ".") Then
            check_numeric_size = 0

        ElseIf UBound(Split(val, ".")) = 0 Then
            If (Len(val) + 1 > p) And key > 31 And (Chr(key) <> ".") Then
                check_numeric_size = 0
            Else
                check_numeric_size = key
            End If

        ElseIf UBound(Split(val, ".")) > 0 Then

            If pos <= Len(Split(val, ".")(0)) Then

                If (Len(Split(val, ".")(0)) + 1 > p) And key > 31 Then
                    check_numeric_size = 0
                Else
                    check_numeric_size = key
                End If
            Else
                If (Len(Split(val, ".")(1)) + 1 > d) And key > 31 Then
                    check_numeric_size = 0
                Else
                    check_numeric_size = key
                End If
            End If
        Else
            check_numeric_size = key
        End If

    End Function

    Private Sub optAdd_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optAdd.CheckedChanged

    End Sub

    Private Sub grdMPO_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdMPO.ColumnHeaderMouseClick
        If rs_MPM00003 Is Nothing Then Exit Sub
        If rs_MPM00003.Tables("result") Is Nothing Then Exit Sub
        If rs_MPM00003.Tables("result").Rows.Count <= 0 Then Exit Sub
        If e.ColumnIndex = colSelect And grdMPO.Columns.Count > 2 Then

            For i As Integer = 0 To grdMPO.RowCount - 1
                If Trim(grdMPO.Item(e.ColumnIndex, i).Value()) = "N" Then
                    grdMPO.Item(e.ColumnIndex, i).Value() = "N"
                Else
                    grdMPO.Item(e.ColumnIndex, i).Value() = "Y"
                End If
            Next
            'tempzzzzzzzzzzzzzzzzzzzzz
        End If

    End Sub

    Private Sub optModify_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optModify.CheckedChanged

    End Sub
End Class
