Public Class SYM00035
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

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
    Friend WithEvents dgCharge As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_ContP As System.Windows.Forms.Label
    Friend WithEvents txt_ContP As System.Windows.Forms.TextBox
    Friend WithEvents lstVendor As System.Windows.Forms.ListBox
    Friend WithEvents cboVendor As System.Windows.Forms.ComboBox
    Friend WithEvents lblVendor As System.Windows.Forms.Label
    Friend WithEvents menuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents mmdAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdFind As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdClear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdInsRow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdDelRow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdAttach As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdFunction As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t7 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdLink As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents t8 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mmdExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ssBar As System.Windows.Forms.StatusBar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SYM00035))
        Me.ssBar = New System.Windows.Forms.StatusBar
        Me.dgCharge = New System.Windows.Forms.DataGridView
        Me.lbl_ContP = New System.Windows.Forms.Label
        Me.txt_ContP = New System.Windows.Forms.TextBox
        Me.lstVendor = New System.Windows.Forms.ListBox
        Me.cboVendor = New System.Windows.Forms.ComboBox
        Me.lblVendor = New System.Windows.Forms.Label
        Me.menuStrip = New System.Windows.Forms.MenuStrip
        Me.mmdAdd = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdSave = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdCopy = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdFind = New System.Windows.Forms.ToolStripMenuItem
        Me.t1 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdClear = New System.Windows.Forms.ToolStripMenuItem
        Me.t2 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdSearch = New System.Windows.Forms.ToolStripMenuItem
        Me.t3 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdInsRow = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdDelRow = New System.Windows.Forms.ToolStripMenuItem
        Me.t4 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdPrint = New System.Windows.Forms.ToolStripMenuItem
        Me.t5 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdAttach = New System.Windows.Forms.ToolStripMenuItem
        Me.t6 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdFunction = New System.Windows.Forms.ToolStripMenuItem
        Me.t7 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdLink = New System.Windows.Forms.ToolStripMenuItem
        Me.t8 = New System.Windows.Forms.ToolStripMenuItem
        Me.mmdExit = New System.Windows.Forms.ToolStripMenuItem
        CType(Me.dgCharge, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'ssBar
        '
        Me.ssBar.Location = New System.Drawing.Point(0, 609)
        Me.ssBar.Name = "ssBar"
        Me.ssBar.Size = New System.Drawing.Size(954, 22)
        Me.ssBar.TabIndex = 14
        Me.ssBar.Text = "StatusBar1"
        '
        'dgCharge
        '
        Me.dgCharge.AllowUserToOrderColumns = True
        Me.dgCharge.AllowUserToResizeColumns = False
        Me.dgCharge.AllowUserToResizeRows = False
        Me.dgCharge.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCharge.Location = New System.Drawing.Point(5, 95)
        Me.dgCharge.Name = "dgCharge"
        Me.dgCharge.RowHeadersWidth = 30
        Me.dgCharge.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgCharge.RowTemplate.Height = 24
        Me.dgCharge.Size = New System.Drawing.Size(942, 508)
        Me.dgCharge.TabIndex = 15
        Me.dgCharge.Tag = ""
        '
        'lbl_ContP
        '
        Me.lbl_ContP.AutoSize = True
        Me.lbl_ContP.Location = New System.Drawing.Point(10, 70)
        Me.lbl_ContP.Name = "lbl_ContP"
        Me.lbl_ContP.Size = New System.Drawing.Size(75, 12)
        Me.lbl_ContP.TabIndex = 19
        Me.lbl_ContP.Text = "Contact Person"
        '
        'txt_ContP
        '
        Me.txt_ContP.Location = New System.Drawing.Point(129, 67)
        Me.txt_ContP.Name = "txt_ContP"
        Me.txt_ContP.Size = New System.Drawing.Size(181, 22)
        Me.txt_ContP.TabIndex = 21
        '
        'lstVendor
        '
        Me.lstVendor.FormattingEnabled = True
        Me.lstVendor.ItemHeight = 12
        Me.lstVendor.Location = New System.Drawing.Point(12, 400)
        Me.lstVendor.Name = "lstVendor"
        Me.lstVendor.Size = New System.Drawing.Size(473, 64)
        Me.lstVendor.TabIndex = 22
        Me.lstVendor.Visible = False
        '
        'cboVendor
        '
        Me.cboVendor.FormattingEnabled = True
        Me.cboVendor.Location = New System.Drawing.Point(129, 35)
        Me.cboVendor.Name = "cboVendor"
        Me.cboVendor.Size = New System.Drawing.Size(557, 20)
        Me.cboVendor.TabIndex = 23
        '
        'lblVendor
        '
        Me.lblVendor.AutoSize = True
        Me.lblVendor.Location = New System.Drawing.Point(14, 38)
        Me.lblVendor.Name = "lblVendor"
        Me.lblVendor.Size = New System.Drawing.Size(40, 12)
        Me.lblVendor.TabIndex = 24
        Me.lblVendor.Text = "Vendor"
        '
        'menuStrip
        '
        Me.menuStrip.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mmdAdd, Me.mmdSave, Me.mmdDelete, Me.mmdCopy, Me.mmdFind, Me.t1, Me.mmdClear, Me.t2, Me.mmdSearch, Me.t3, Me.mmdInsRow, Me.mmdDelRow, Me.t4, Me.mmdPrint, Me.t5, Me.mmdAttach, Me.t6, Me.mmdFunction, Me.t7, Me.mmdLink, Me.t8, Me.mmdExit})
        Me.menuStrip.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip.Name = "menuStrip"
        Me.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.menuStrip.Size = New System.Drawing.Size(954, 24)
        Me.menuStrip.TabIndex = 260
        Me.menuStrip.Text = "MenuStrip1"
        '
        'mmdAdd
        '
        Me.mmdAdd.BackColor = System.Drawing.SystemColors.Control
        Me.mmdAdd.Name = "mmdAdd"
        Me.mmdAdd.Size = New System.Drawing.Size(40, 20)
        Me.mmdAdd.Tag = "Add"
        Me.mmdAdd.Text = "&Add"
        '
        'mmdSave
        '
        Me.mmdSave.Name = "mmdSave"
        Me.mmdSave.Size = New System.Drawing.Size(46, 20)
        Me.mmdSave.Text = "&Save"
        '
        'mmdDelete
        '
        Me.mmdDelete.Name = "mmdDelete"
        Me.mmdDelete.Size = New System.Drawing.Size(55, 20)
        Me.mmdDelete.Text = "&Delete"
        '
        'mmdCopy
        '
        Me.mmdCopy.Name = "mmdCopy"
        Me.mmdCopy.Size = New System.Drawing.Size(47, 20)
        Me.mmdCopy.Text = "&Copy"
        '
        'mmdFind
        '
        Me.mmdFind.Name = "mmdFind"
        Me.mmdFind.Size = New System.Drawing.Size(43, 20)
        Me.mmdFind.Text = "&Find"
        '
        't1
        '
        Me.t1.AutoSize = False
        Me.t1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.t1.Enabled = False
        Me.t1.Name = "t1"
        Me.t1.Size = New System.Drawing.Size(8, 20)
        Me.t1.Text = "|"
        '
        'mmdClear
        '
        Me.mmdClear.Name = "mmdClear"
        Me.mmdClear.Size = New System.Drawing.Size(49, 20)
        Me.mmdClear.Text = "Cl&ear"
        '
        't2
        '
        Me.t2.AutoSize = False
        Me.t2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.t2.Enabled = False
        Me.t2.Name = "t2"
        Me.t2.Size = New System.Drawing.Size(8, 20)
        Me.t2.Text = "|"
        '
        'mmdSearch
        '
        Me.mmdSearch.Name = "mmdSearch"
        Me.mmdSearch.Size = New System.Drawing.Size(58, 20)
        Me.mmdSearch.Text = "Searc&h"
        '
        't3
        '
        Me.t3.AutoSize = False
        Me.t3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.t3.Enabled = False
        Me.t3.Name = "t3"
        Me.t3.Size = New System.Drawing.Size(8, 20)
        Me.t3.Text = "|"
        '
        'mmdInsRow
        '
        Me.mmdInsRow.Name = "mmdInsRow"
        Me.mmdInsRow.Size = New System.Drawing.Size(64, 20)
        Me.mmdInsRow.Text = "In&s Row"
        '
        'mmdDelRow
        '
        Me.mmdDelRow.Name = "mmdDelRow"
        Me.mmdDelRow.Size = New System.Drawing.Size(66, 20)
        Me.mmdDelRow.Text = "Del Ro&w"
        '
        't4
        '
        Me.t4.AutoSize = False
        Me.t4.Enabled = False
        Me.t4.Name = "t4"
        Me.t4.Size = New System.Drawing.Size(8, 20)
        Me.t4.Text = "|"
        '
        'mmdPrint
        '
        Me.mmdPrint.Name = "mmdPrint"
        Me.mmdPrint.Size = New System.Drawing.Size(44, 20)
        Me.mmdPrint.Text = "&Print"
        '
        't5
        '
        Me.t5.AutoSize = False
        Me.t5.Enabled = False
        Me.t5.Name = "t5"
        Me.t5.Size = New System.Drawing.Size(8, 20)
        Me.t5.Text = "|"
        '
        'mmdAttach
        '
        Me.mmdAttach.Name = "mmdAttach"
        Me.mmdAttach.Size = New System.Drawing.Size(52, 20)
        Me.mmdAttach.Text = "Attach"
        '
        't6
        '
        Me.t6.AutoSize = False
        Me.t6.Enabled = False
        Me.t6.Name = "t6"
        Me.t6.Size = New System.Drawing.Size(8, 20)
        Me.t6.Text = "|"
        '
        'mmdFunction
        '
        Me.mmdFunction.Name = "mmdFunction"
        Me.mmdFunction.Size = New System.Drawing.Size(66, 20)
        Me.mmdFunction.Text = "Function"
        '
        't7
        '
        Me.t7.AutoSize = False
        Me.t7.Enabled = False
        Me.t7.Name = "t7"
        Me.t7.Size = New System.Drawing.Size(8, 20)
        Me.t7.Text = "|"
        '
        'mmdLink
        '
        Me.mmdLink.Name = "mmdLink"
        Me.mmdLink.Size = New System.Drawing.Size(42, 20)
        Me.mmdLink.Text = "Link"
        '
        't8
        '
        Me.t8.AutoSize = False
        Me.t8.Enabled = False
        Me.t8.Name = "t8"
        Me.t8.Size = New System.Drawing.Size(8, 20)
        Me.t8.Text = "|"
        '
        'mmdExit
        '
        Me.mmdExit.Name = "mmdExit"
        Me.mmdExit.Size = New System.Drawing.Size(38, 20)
        Me.mmdExit.Text = "E&xit"
        '
        'SYM00035
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 15)
        Me.ClientSize = New System.Drawing.Size(954, 631)
        Me.Controls.Add(Me.menuStrip)
        Me.Controls.Add(Me.lblVendor)
        Me.Controls.Add(Me.cboVendor)
        Me.Controls.Add(Me.lstVendor)
        Me.Controls.Add(Me.txt_ContP)
        Me.Controls.Add(Me.lbl_ContP)
        Me.Controls.Add(Me.dgCharge)
        Me.Controls.Add(Me.ssBar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "SYM00035"
        Me.Text = "SYM00035 - Vendor Trading Terms Maintenance (SYM35)"
        CType(Me.dgCharge, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuStrip.ResumeLayout(False)
        Me.menuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Dim dsNewRow As DataRow

    Dim mode As String

    Dim Recordstatus As Boolean

    Public rs_SYTRDTRM As New DataSet
    Public rs_VNBASINF As New DataSet
    Public rs_VNCNTINF As New DataSet
    Public rs_VNTRDTRM As New DataSet
    Dim rs_rights As New DataSet

    Dim bindSrc As New BindingSource
    Dim save_ok As Boolean
    Dim CanModify As Boolean = True
    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean
    Public validcheck As Integer



    Private Sub SYM00103_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        validcheck = 1
        ''add on 11/8/2011
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Call AccessRight(Me.Name)
            Enq_right_local = Enq_right
            Del_right_local = Del_right
            ''end of add

            gsCompany = "UCP"
            gspStr = "sp_select_SYTRDTRM'" & gsCompany & "','AL'"
            rtnLong = execute_SQLStatement(gspStr, rs_SYTRDTRM, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00103 sp_select_SYTRDTRM : " & rtnStr)
                gspStr = "sp_select_SYSUSERGRP '" & gsCompany & "'"
            Else
                gspStr = "sp_list_VNBASINF'" & gsCompany & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading SYM00103 sp_select_VNBASINF : " & rtnStr)
                Else
                    gspStr = "sp_list_VNCNTINF'" & gsCompany & "','','','CMM'"
                    rtnLong = execute_SQLStatement(gspStr, rs_VNCNTINF, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading SYS00002 sp_select_SYCOMINF_M : " & rtnStr)
                    Else
                        'gspStr = "sp_list_VNTRDTRM'" & gsCompany & "','" & txt_VnCde.Text.ToUpper.Trim & "'"
                        'Frankie Cheung 20111031
                        gspStr = "sp_list_VNTRDTRM'" & gsCompany & "','" & Split(cboVendor.Text, " - ")(0).ToUpper.Trim() & "'"
                        rtnLong = execute_SQLStatement(gspStr, rs_VNTRDTRM, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading SYM00103 sp_list_VNTRDTRM : " & rtnStr)

                        Else
                            'For Each ctl As Control In GrpBoxMain.Controls
                            'If TypeOf (ctl) Is TextBox Or TypeOf (ctl) Is MaskedTextBox Then
                            'ctl.Text = ""
                            'ctl.Enabled = False
                            'End If
                            'Next
                            dgCharge.DataSource = rs_VNTRDTRM.Tables("RESULT").DefaultView

                            rs_VNTRDTRM.Tables("RESULT").Columns(0).ReadOnly = False

                            'Frankie Cheung 20111031
                            'txt_VnCde.Text = ""
                            'txt_VnName.Enabled = False
                            'txt_VnName.Text = ""
                            txt_ContP.Enabled = False
                            txt_ContP.Text = ""
                            'Frankie Cheung 20111031
                            'txt_VnCde.Enabled = True
                            'txt_VnCde.Focus()
                            cboVendor.Enabled = True
                            cboVendor.Focus()

                            lstVendor.Visible = False

                            'Add_flag = False
                            dgCharge.DataSource = Nothing



                            Call SetStatusBar("Init")
                            mode = "INIT"
                            Call setStatus(mode)

                        End If
                    End If
                End If
            End If
            Call Formstartup(Me.Name)
            cboVendor.Items.Clear()
            cboVendor.Text = Nothing

            'Frankie Cheung 20111031 fill combo venno
            Call format_cboVenno()

            mmdFind.Enabled = True
            '' add on 11/8/2011
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try


    End Sub



    Private Sub setDataRowAttr()
        Dim dt As DataTable = rs_rights.Tables("RESULT")


        If Not dt Is Nothing Then
            For Each dc As DataColumn In dt.Columns
                dc.ReadOnly = False
            Next

            For Each dr As DataRow In dt.Rows
                dr.Item("vtt_del") = ""
            Next
            rs_VNTRDTRM.AcceptChanges()
        End If
    End Sub


    Private Sub mmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdExit.Click

        Dim YNC As Integer
        Dim flgMod As Boolean = False

        bindSrc.EndEdit()
        If Me.ssBar.Text = "Init" Then
            Me.Close()
        Else

            If Me.ssBar.Text = "Insert Row" Or Me.ssBar.Text = "Record Row Deleted" Then
                YNC = MessageBox.Show("Record has been modified. Do you want to save before exit?", "Question", MessageBoxButtons.YesNoCancel)

                If YNC = Windows.Forms.DialogResult.Yes Then

                    Call mmdSave_Click(sender, e)

                    If save_ok Then

                        'Me.Close()
                        'Else
                        Exit Sub
                    End If

                ElseIf YNC = Windows.Forms.DialogResult.No Then
                    Me.Close()

                ElseIf YNC = Windows.Forms.DialogResult.Cancel Then
                    Exit Sub
                End If
            Else
                Me.Close()
            End If
        End If
    End Sub

    Private Sub format_dgCharge()
        Dim i As Integer
        i = 0
        Dim dv As DataView = rs_rights.Tables("RESULT").DefaultView

        With dgCharge
            .DataSource = Nothing
            .DataSource = dv
            For i = 0 To .Columns.Count - 1
                Select Case i
                    '0
                    Case 0
                        .Columns(i).Width = 30
                        .Columns(i).HeaderText = "Del"
                    Case 4
                        '4
                        .Columns(i).Width = 45
                        .Columns(i).HeaderText = "Code"
                        'i = i + 1
                    Case 5
                        .Columns(i).Width = 45
                        .Columns(i).HeaderText = "Type"
                        .Columns(i).ReadOnly = True
                        'i = i + 1
                    Case 6
                        .Columns(i).Width = 90
                        .Columns(i).HeaderText = "Group"
                        .Columns(i).ReadOnly = True
                        'i = i + 1
                    Case 7
                        .Columns(i).Width = 485
                        .Columns(i).HeaderText = "Desc"
                        .Columns(i).ReadOnly = True
                        'i = i + 1
                    Case Else
                        .Columns(i).Visible = False
                End Select

            Next i


        End With


    End Sub



    Private Sub setStatus(ByVal mode As String)
        If mode = "INIT" Then
            Me.mmdAdd.Enabled = False
            Me.mmdSave.Enabled = False
            Me.mmdDelete.Enabled = False
            Me.mmdCopy.Enabled = False
            Me.mmdFind.Enabled = False
            Me.mmdClear.Enabled = False

            Me.mmdSearch.Enabled = False

            Me.mmdInsRow.Enabled = False
            Me.mmdDelRow.Enabled = False

            Me.mmdPrint.Enabled = False
            Me.mmdAttach.Enabled = False
            Me.mmdFunction.Enabled = False
            Me.mmdLink.Enabled = False

            Me.mmdExit.Enabled = True
            'Frankie Cheung 20111031
            'txt_VnCde.Focus()
            cboVendor.Focus()
            Call SetStatusBar(mode)
        ElseIf mode = "InsRow" Then
            Me.mmdCopy.Enabled = False
            Me.mmdFind.Enabled = False
            Me.mmdSave.Enabled = Enq_right_local
            Me.mmdDelRow.Enabled = Del_right_local
            Call SetStatusBar(mode)

        ElseIf mode = "Save" Then
            Call ResetDefaultDisp()
            Call SetStatusBar(mode)
            MsgBox("Record Saved!")
            'Call SYM00103_Load(Nothing, Nothing)

        ElseIf mode = "DelRow" Then
            Me.mmdCopy.Enabled = False
            Me.mmdFind.Enabled = False
            Me.mmdSave.Enabled = Enq_right_local
            Me.mmdDelRow.Enabled = Del_right_local
            Call SetStatusBar(mode)

        ElseIf mode = "Clear" Then
            Call ResetDefaultDisp()
            Call SetStatusBar(mode)
        End If

        If Not CanModify Then
            Me.mmdAdd.Enabled = False
            Me.mmdSave.Enabled = False
            Me.mmdDelete.Enabled = False
            Me.mmdInsRow.Enabled = False
            'Me.cmdDelRow.Enabled = False

            Call ResetDefaultDisp()
            Call SetStatusBar("ReadOnly")
        End If
    End Sub




    ''/*add by 11/08/2011*/


    Private Sub SetStatusBar(ByVal m As String)

        If m = "Init" Then
            Me.ssBar.Text = "Init"
        ElseIf m = "InsRow" Then
            Me.ssBar.Text = "Insert Row"
        ElseIf m = "Updating" Then
            Me.ssBar.Text = "Updating"
        ElseIf m = "Save" Then
            Me.ssBar.Text = "Record Saved"
        ElseIf m = "DelRow" Then
            Me.ssBar.Text = "Record Row Deleted"
        ElseIf m = "ReadOnly" Then
            Me.ssBar.Text = "Read Only"
        ElseIf m = "Clear" Then
            Me.ssBar.Text = "Clear Screen"
        End If

    End Sub

    Private Sub ResetDefaultDisp()
        Me.ssBar.Text = ""
        dgCharge.Enabled = False
    End Sub
    ''end add


    Private Sub createComboBoxCell(ByVal cell As DataGridViewCell)
        Dim cboCell As New DataGridViewComboBoxCell
        Dim iCol As Integer = cell.ColumnIndex
        Dim iRow As Integer = cell.RowIndex
        Dim dgView As DataGridView = cell.DataGridView

        Dim row As DataGridViewRow = dgCharge.CurrentRow

        If iCol = 4 And row.Cells("vtt_creusr").Value.ToString = "~*ADD*~" Then

            lstVendor.Visible = True
            Call format_lstVendor()

        End If
        Call display_lstVendor(rs_rights.Tables("RESULT").Rows.Count)
        dgView.Rows(iRow).Cells(iCol).ReadOnly = True
    End Sub


    Private Sub format_lstVendor()

        Dim cbostring As String
        Dim row As DataGridViewRow = dgCharge.CurrentRow

        lstVendor.Items.Clear()

        If row.Cells("vtt_creusr").Value.ToString = "~*ADD*~" Then
            For Each dr As DataRow In rs_SYTRDTRM.Tables("RESULT").Rows

                cbostring = "" & dr.Item("ytt_cde").ToString.Trim & " - " & dr.Item("ytt_typ").ToString.Trim & " - " & dr.Item("ytt_grp").ToString.Trim & " - " & dr.Item("ytt_dsc").ToString.Trim
                lstVendor.Items.Add(cbostring)

            Next
            lstVendor.Focus()
        End If
    End Sub
    'Frankie Cheung 20111031 Add cboVenno fill data
    Private Sub format_cboVenno()
        Dim i As Integer
        Dim strList As String

        cboVendor.Items.Clear()

        If rs_VNBASINF.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_VNBASINF.Tables("RESULT").Rows.Count - 1
                strList = rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_vensna")
                If strList <> "" Then
                    cboVendor.Items.Add(strList)
                End If
            Next i
        End If
    End Sub

    Private Sub format_inputVendorBy_after()

        'cboClaimType.Enabled = True
        'cboClaimType.Select()
        'gbClaimBy.Enabled = False
        'cbAdhoc.Enabled = False
        'txtClaimIssDate.Enabled = False

        'If cboVendor.Text = "" Then
        '    rs_VNTRDTRM.Tables("RESULT").Rows(0).Item("vtt_venno") = ""
        'Else
        '    rs_VNTRDTRM.Tables("RESULT").Rows(0).Item("vtt_venno") = Split(cboVendor.Text, " - ")(0)
        'End If

    End Sub

    Private Sub lstVendor_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstVendor.DoubleClick

        Dim iRow As Integer = dgCharge.CurrentCell.RowIndex
        Dim iCol As Integer = dgCharge.CurrentCell.ColumnIndex
        Dim strSelItem As String
        Dim row As DataGridViewRow = dgCharge.CurrentRow


        lstVendor.Visible = False


        strSelItem = Split(lstVendor.Text, " ")(0)

        If iCol = 4 And row.Cells("vtt_creusr").Value.ToString = "~*ADD*~" Then

            Me.dgCharge.Rows(iRow).Cells(iCol).Value = rs_SYTRDTRM.Tables("RESULT").Select("ytt_cde = '" & strSelItem & "'")(0).Item("ytt_cde")
            For Each drr As DataGridViewRow In dgCharge.Rows


                If drr.Index <> row.Index Then
                    If drr.Cells("vtt_ttcde").Value.ToString.ToUpper = row.Cells("vtt_ttcde").Value.ToString.ToUpper And _
                       drr.Cells("vtt_del").Value.ToString = "" Then

                        MsgBox("Duplicated function code " & drr.Cells("vtt_ttcde").Value.ToString & "!")
                        row.DataGridView.CurrentCell = row.Cells("vtt_ttcde")

                        If TypeOf (dgCharge.CurrentCell) Is DataGridViewTextBoxCell Then
                            createComboBoxCell(dgCharge.CurrentCell)
                            dgCharge.BeginEdit(True)
                            mmdSave.Enabled = Enq_right_local
                            validcheck = 0
                            Exit Sub
                        End If

                    End If

                End If
            Next


            For Each drr As DataGridViewRow In dgCharge.Rows


                If drr.Index <> row.Index Then
                    If drr.Cells("vtt_ttcde").Value.ToString.ToUpper <> row.Cells("vtt_ttcde").Value.ToString.ToUpper Then
                        validcheck = 1
                    Else
                        If TypeOf (dgCharge.CurrentCell) Is DataGridViewTextBoxCell Then
                            createComboBoxCell(dgCharge.CurrentCell)
                            dgCharge.BeginEdit(True)
                            mmdSave.Enabled = Enq_right_local
                            validcheck = 0
                            Exit Sub
                        End If

                    End If

                End If
            Next
            Me.dgCharge.Rows(iRow).Cells(iCol + 1).Value = rs_SYTRDTRM.Tables("RESULT").Select("ytt_cde = '" & strSelItem & "'")(0).Item("ytt_typ")
            Me.dgCharge.Rows(iRow).Cells(iCol + 2).Value = rs_SYTRDTRM.Tables("RESULT").Select("ytt_cde = '" & strSelItem & "'")(0).Item("ytt_grp")
            Me.dgCharge.Rows(iRow).Cells(iCol + 3).Value = rs_SYTRDTRM.Tables("RESULT").Select("ytt_cde = '" & strSelItem & "'")(0).Item("ytt_dsc")

        End If



    End Sub

    Private Sub display_lstVendor(ByVal rowcount As Integer)
        lstVendor.Visible = True

        lstVendor.Top = dgCharge.Item(0, 0).DataGridView.Top + dgCharge.Item(0, 0).DataGridView.ColumnHeadersHeight + dgCharge.RowTemplate.Height * rowcount
        lstVendor.Left = dgCharge.Item(0, 0).DataGridView.Left + dgCharge.Item(0, 0).DataGridView.RowHeadersWidth
    End Sub



    Private Sub DataGrid_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgCharge.EditingControlShowing

        If dgCharge.CurrentCell.ColumnIndex = 4 Then
            If TypeOf (e.Control) Is DataGridViewComboBoxEditingControl Then
                Dim cboBox As ComboBox = CType(e.Control, ComboBox)
                If Not cboBox Is Nothing Then

                    RemoveHandler cboBox.SelectedIndexChanged, AddressOf lstVendor_DoubleClick
                    AddHandler cboBox.SelectedIndexChanged, AddressOf lstVendor_DoubleClick
                End If
            End If
        End If
    End Sub


    Private Sub DataGrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCharge.CellClick
        Dim row As DataGridViewRow = dgCharge.CurrentRow
        Dim i As Integer

        If Not e.RowIndex = -1 Then

            If e.ColumnIndex = 0 Then
                ''Toggle(Delete)


                If Not row.Cells("vtt_ttcde").Value.ToString = "" Then
                    Call mmdDelRow_Click(sender, e)
                    row.Cells("vtt_del").ReadOnly = True
                End If
            End If
            If e.ColumnIndex = 4 Then
                If row.Cells("vtt_del").Value.ToString = "" And row.Cells("vtt_creusr").Value.ToString = "~*ADD*~" Then
                    If TypeOf (dgCharge.CurrentCell) Is DataGridViewTextBoxCell Then
                        createComboBoxCell(dgCharge.CurrentCell)
                        dgCharge.BeginEdit(True)
                        mmdSave.Enabled = Enq_right_local
                        row.Cells("vtt_del").ReadOnly = True
                    End If
                Else
                    row.Cells(e.ColumnIndex).ReadOnly = True
                End If


            End If

        End If
        For i = 0 To dgCharge.ColumnCount - 1
            dgCharge.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next

    End Sub




    Private Sub DataGrid_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgCharge.CellValidating
        Dim row As DataGridViewRow = dgCharge.CurrentRow
        Dim strNewVal As String

        strNewVal = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim

        If row.Cells(e.ColumnIndex).IsInEditMode Then

            If e.ColumnIndex = 4 Then
                If Not chkGrdCellValue(row.Cells("vtt_ttcde"), "String", 2) Then
                    e.Cancel = True
                Else
                    For Each drr As DataGridViewRow In dgCharge.Rows
                        If drr.Index <> e.RowIndex Then
                            If drr.Cells("vtt_ttcde").Value.ToString.ToUpper = strNewVal.ToUpper Then
                                MsgBox("Duplicated function code!")
                                e.Cancel = True
                                validcheck = 0
                                If TypeOf (dgCharge.CurrentCell) Is DataGridViewTextBoxCell Then
                                    createComboBoxCell(dgCharge.CurrentCell)
                                    dgCharge.BeginEdit(True)
                                    mmdSave.Enabled = Enq_right_local
                                End If
                                Exit Sub
                            End If
                        End If
                    Next
                End If




                For Each drr As DataGridViewRow In dgCharge.Rows
                    If drr.Index <> e.RowIndex Then
                        If drr.Cells("vtt_ttcde").Value.ToString.ToUpper <> strNewVal.ToUpper Then
                            validcheck = 1
                        Else
                            validcheck = 0
                            If TypeOf (dgCharge.CurrentCell) Is DataGridViewTextBoxCell Then
                                createComboBoxCell(dgCharge.CurrentCell)
                                dgCharge.BeginEdit(True)
                                mmdSave.Enabled = Enq_right_local
                            End If
                            Exit Sub
                        End If
                    End If
                Next
            End If
        End If





    End Sub




    Private Sub mmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdInsRow.Click

        Dim addnewrow As Boolean

        addnewrow = False




        If rs_rights.Tables("RESULT").Rows.Count = 0 Then
            addnewrow = True
        ElseIf rs_rights.Tables("RESULT").Rows(rs_rights.Tables("RESULT").Rows.Count - 1).Item("vtt_ttcde").ToString = "" Then
            addnewrow = False
            MsgBox("Please insert the function code first before add the new row")
        ElseIf rs_rights.Tables("RESULT").Rows(rs_rights.Tables("RESULT").Rows.Count - 1).Item("vtt_creusr").ToString <> "~*NEW*~" Then
            If validcheck = 1 Then
                addnewrow = True
            Else
                MsgBox("The function code should not be duplicated before adding new row")
                addnewrow = False

            End If
        End If

        If addnewrow = True Then
            dsNewRow = rs_rights.Tables("RESULT").NewRow()


            dsNewRow.Item("vtt_creusr") = "~*ADD*~"
            dsNewRow.Item("vtt_del") = ""

            rs_rights.Tables("RESULT").Rows.Add(dsNewRow)
            For Each drr As DataGridViewRow In dgCharge.Rows
                If IsDBNull(drr.Cells(4).Value) Then
                    dgCharge.CurrentCell = drr.Cells(4)
                    createComboBoxCell(dgCharge.CurrentCell)
                    dgCharge.BeginEdit(True)
                End If
            Next

        End If


        Call SetStatusBar("InsRow")
        Call setStatus("InsRow")
    End Sub




    Private Sub mmdDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdDelRow.Click
        Dim row As DataGridViewRow = dgCharge.CurrentRow
        Dim cellStyle As New DataGridViewCellStyle

        ' Toggle Delete
        If Not row Is Nothing Then
            If Not row.Cells("vtt_ttcde").Value.ToString = "" Then
                If row.Cells("vtt_del").Value.ToString = "" Then
                    row.Cells("vtt_del").Value = "Y"
                    cellStyle.BackColor = Color.LightBlue
                Else
                    row.Cells("vtt_del").Value = ""
                    cellStyle.BackColor = Nothing
                End If
                row.DataGridView.CurrentRow.DefaultCellStyle = cellStyle
                Call setStatus("DelRow")
                Call SetStatusBar("DelRow")
            End If
        End If
        mmdClear.Enabled = True
    End Sub

    Private Sub mmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdSave.Click
        ''Dim strUsrGrp, strComGrp As String
        Dim flgErr As Boolean = False
        Dim flgReAct As Boolean = False
        Dim VnCde As String
        Dim VnName As String
        'Frankie Cheung 20111031
        Dim dtr() As DataRow

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            save_ok = True
            'VnCde = txt_VnCde.Text.ToUpper
            'Frankie Cheung 20111031
            If cboVendor.Text.IndexOf(" - ") <> -1 Then
                VnCde = Split(cboVendor.Text, " - ")(0).ToUpper.Trim()
                dtr = rs_VNBASINF.Tables("RESULT").Select("vbi_venno = '" & VnCde & "'")
                If dtr.Length <> 0 Then
                    VnName = dtr(0).Item("vbi_vensna")
                Else
                    VnName = Split(cboVendor.Text, " - ")(1).ToUpper.Trim()
                End If
            End If

            bindSrc.EndEdit()
            For Each row As DataGridViewRow In dgCharge.Rows

                If Not chkGrdCellValue(row.Cells("vtt_ttcde"), "String", 2) Then
                    save_ok = False
                    flgReAct = True
                    row.DataGridView.CurrentCell = row.Cells("vtt_ttcde")
                    If row.Cells("vtt_del").Value.ToString = "" And row.Cells("vtt_venno").Value.ToString = "" Then
                        If TypeOf (dgCharge.CurrentCell) Is DataGridViewTextBoxCell Then
                            createComboBoxCell(dgCharge.CurrentCell)
                            dgCharge.BeginEdit(True)
                            mmdSave.Enabled = Enq_right_local
                        End If


                    End If
                End If

                If Not save_ok Then
                    Exit For
                End If

                If row.Cells("vtt_del").Value.ToString = "" Then


                    If row.Cells("vtt_credat").Value.ToString = "" Then
                        For Each drr As DataGridViewRow In dgCharge.Rows

                            If drr.Index <> row.Index Then
                                If drr.Cells("vtt_ttcde").Value.ToString.ToUpper = row.Cells("vtt_ttcde").Value.ToString.ToUpper And _
                                   drr.Cells("vtt_del").Value.ToString = "" Then

                                    MsgBox("Duplicated function code " & drr.Cells("vtt_ttcde").Value.ToString & "!")
                                    save_ok = False
                                    flgReAct = True
                                    row.DataGridView.CurrentCell = row.Cells("vtt_ttcde")

                                    If TypeOf (dgCharge.CurrentCell) Is DataGridViewTextBoxCell Then
                                        createComboBoxCell(dgCharge.CurrentCell)
                                        dgCharge.BeginEdit(True)
                                        mmdSave.Enabled = Enq_right_local
                                    End If
                                End If


                            End If
                        Next
                    End If
                End If


                If Not save_ok Then
                    Exit For
                End If
                'End If
            Next

            If Not save_ok Then
                dgCharge.BeginEdit(True)
                Exit Sub
            Else

                gspStr = ""
                For Each dr As DataRow In rs_rights.Tables("RESULT").Rows

                    If dr.RowState = DataRowState.Modified Then

                        If dr.Item("vtt_del") = "Y" Then

                            'gspStr = "sp_physical_delete_VNTRDTRM '" & gsCompany & "','" & _
                            '            txt_VnCde.Text.ToUpper & "','" & _
                            '            dr.Item("vtt_ttcde").ToString.Replace("'", "''").Trim & "'"
                            gspStr = "sp_physical_delete_VNTRDTRM '" & gsCompany & "','" & _
                                        VnCde.ToUpper & "','" & _
                                        dr.Item("vtt_ttcde").ToString.Replace("'", "''").Trim & "'"

                            If gspStr <> "" Then
                                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                If rtnLong <> RC_SUCCESS Then
                                    MsgBox("Error on loading SYS00002 sp_physical_delete_VNTRDTRM : " & rtnStr)
                                    flgErr = True
                                    Exit For
                                End If
                            End If
                        Else

                            'gspStr = "sp_update_VNTRDTRM '" & gsCompany & "','" & _
                            '            txt_VnCde.Text.ToUpper.Replace("'", "''").Trim & "','" & _
                            '            txt_VnName.Text.Replace("'", "''").Trim & "','" & _
                            '            txt_ContP.Text.Replace("'", "''").Trim & "','" & _
                            '            dr.Item("vtt_ttcde").ToString.Replace("'", "''").Trim & "','" & _
                            '            dr.Item("vtt_tttyp").ToString.Replace("'", "''").Trim & "','" & _
                            '            dr.Item("vtt_ttgrp").ToString.Replace("'", "''").Trim & "','" & _
                            '            dr.Item("vtt_ttdsc").ToString.Replace("'", "''").Trim & "','" & _
                            '            gsUsrID & "'"
                            'Frankie Cheung 20111031
                            gspStr = "sp_update_VNTRDTRM '" & gsCompany & "','" & _
                                        VnCde.ToUpper.Replace("'", "''").Trim & "','" & _
                                        VnName.Replace("'", "''").Trim & "','" & _
                                        txt_ContP.Text.Replace("'", "''").Trim & "','" & _
                                        dr.Item("vtt_ttcde").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("vtt_tttyp").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("vtt_ttgrp").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("vtt_ttdsc").ToString.Replace("'", "''").Trim & "','" & _
                                        gsUsrID & "'"


                            If gspStr <> "" Then
                                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                If rtnLong <> RC_SUCCESS Then
                                    MsgBox("Error on loading SYM00103 sp_update_VNTRDTRM : " & rtnStr)
                                    flgErr = True
                                    Exit For
                                End If
                                gspStr = ""
                            End If


                        End If



                    ElseIf dr.RowState = DataRowState.Added And Not dr.Item("vtt_del") = "Y" Then

                        If dr.Item("vtt_credat").ToString.Trim = "" Then
                            'gspStr = "sp_insert_VNTRDTRM '" & gsCompany & "','" & _
                            '            txt_VnCde.Text.ToUpper.Replace("'", "''").Trim & "','" & _
                            '            txt_VnName.Text.Replace("'", "''").Trim & "','" & _
                            '            txt_ContP.Text.Replace("'", "''").Trim & "','" & _
                            '            dr.Item("vtt_ttcde").ToString.Replace("'", "''").Trim & "','" & _
                            '            dr.Item("vtt_tttyp").ToString.Replace("'", "''").Trim & "','" & _
                            '            dr.Item("vtt_ttgrp").ToString.Replace("'", "''").Trim & "','" & _
                            '            dr.Item("vtt_ttdsc").ToString.Replace("'", "''").Trim & "','" & _
                            '            gsUsrID & "'"

                            gspStr = "sp_insert_VNTRDTRM '" & gsCompany & "','" & _
                                        VnCde.ToUpper.Replace("'", "''").Trim & "','" & _
                                        VnName.Replace("'", "''").Trim & "','" & _
                                        txt_ContP.Text.Replace("'", "''").Trim & "','" & _
                                        dr.Item("vtt_ttcde").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("vtt_tttyp").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("vtt_ttgrp").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("vtt_ttdsc").ToString.Replace("'", "''").Trim & "','" & _
                                        gsUsrID & "'"

                        End If

                        If gspStr <> "" Then
                            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                            If rtnLong <> RC_SUCCESS Then
                                MsgBox("Error on loading SYM00103 sp_insert_VNTRDTRM : " & rtnStr)
                                flgErr = True
                                Exit For
                            End If
                            gspStr = ""
                        End If

                    End If


                Next

                If Not flgErr Then
                    rs_SYTRDTRM.AcceptChanges()
                    'Call setStatus("Save")


                    'gspStr = "sp_list_VNTRDTRM '" & gsCompany & "','" & txt_VnCde.Text.ToUpper.Trim & "'"
                    'Frankie Cheung 20111031
                    gspStr = "sp_list_VNTRDTRM '" & gsCompany & "','" & VnCde.ToUpper.Trim & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs_rights, rtnStr)

                    Call setDataRowAttr()
                    Call format_dgCharge()

                    'Call ResetDefaultDisp()

                    MsgBox("Record Saved!")
                    Call SetStatusBar("Updating")
                    Call SYM00103_Load(sender, e)
                    'Frankie Cheung 20111031
                    'Me.txt_VnCde.Text = VnCde
                Else
                    save_ok = False
                    rs_SYTRDTRM.RejectChanges()
                    MsgBox("Record Not Updated!")
                End If
            End If

        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub mmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdFind.Click

        If Not checkValidCombo(cboVendor, cboVendor.Text) Then
            Exit Sub
        End If

        Dim dtr() As DataRow
        Dim dtr2() As DataRow

        Dim vncde As String
        Dim VnName As String

        'If txt_VnCde.Text.Trim = "" Then
        '    txt_VnCde.Focus()
        '    MsgBox("Please input Vendor Code.")
        'Else
        '    dtr = rs_VNBASINF.Tables("RESULT").Select("vbi_venno = '" & txt_VnCde.Text.ToUpper.Trim & "'")
        '    If dtr.Length = 0 Then
        '        txt_VnCde.Focus()
        '        MsgBox("User Not Found!")
        '    Else


        If cboVendor.Text.Trim = "" Then
            cboVendor.Focus()
            MsgBox("Please input Vendor Code.")
        ElseIf cboVendor.Text.IndexOf(" - ") = -1 Then
            MsgBox("User Not Found!")
        Else
            vncde = Split(cboVendor.Text, " - ")(0).ToUpper.Trim
            dtr = rs_VNBASINF.Tables("RESULT").Select("vbi_venno = '" & vncde & "'")
            If dtr.Length = 0 Then
                cboVendor.Focus()
                MsgBox("User Not Found!")
            Else

                'txt_VnName.Text = dtr(0).Item("vbi_vensna")
                'dtr2 = rs_VNCNTINF.Tables("RESULT").Select("vci_venno = '" & txt_VnCde.Text.ToUpper.Trim & "' and vci_cnttyp = 'MAGT'")
                'Frankie Cheung 20111031
                VnName = dtr(0).Item("vbi_vensna")
                dtr2 = rs_VNCNTINF.Tables("RESULT").Select("vci_venno = '" & vncde & "' and vci_cnttyp = 'GENL' and vci_seq = '1'")

                If dtr2.Length = 0 Then
                    cboVendor.Focus()
                    txt_ContP.Text = "The contact person has not been added into database"
                Else
                    txt_ContP.Text = dtr2(0).Item("vci_cntctp")
                End If

                gspStr = "sp_list_VNTRDTRM '" & gsCompany & "','" & vncde.ToUpper.Trim & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_rights, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading SYM00103 sp_list_VNTRDTRM : " & rtnStr)
                Else
                    Me.mmdInsRow.Enabled = True
                    Me.mmdDelRow.Enabled = True
                    Me.mmdSave.Enabled = True
                    Me.mmdFind.Enabled = False
                    Me.mmdClear.Enabled = True
                    'Frankie Cheung 20111031
                    'Me.txt_VnCde.Enabled = False
                    'Me.txt_VnCde.Text = Me.txt_VnCde.Text.ToUpper
                    Me.cboVendor.Enabled = False
                    Call setDataRowAttr()
                    Call format_dgCharge()
                    Call SetStatusBar("ReadOnly")
                End If

            End If
        End If
    End Sub

    Private Sub mmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdClear.Click
        Dim YNC As Integer
        Dim flgMod As Boolean = False

        bindSrc.EndEdit()
        If Not rs_VNTRDTRM.Tables("RESULT") Is Nothing Then
            For Each dr As DataRow In rs_rights.Tables("RESULT").Rows
                If dr.RowState = DataRowState.Modified Or dr.RowState = DataRowState.Added Then
                    flgMod = True
                End If
            Next
        End If

        'If flgMod Then
        If Me.ssBar.Text = "Insert Row" Or Me.ssBar.Text = "Record Row Deleted" Then
            YNC = MessageBox.Show("Record has been modified. Do you want to save?", "Question", MessageBoxButtons.YesNoCancel)

            If YNC = Windows.Forms.DialogResult.Yes Then

                Call mmdSave_Click(sender, e)

                If save_ok Then
                    Call SYM00103_Load(sender, e)
                Else
                    MsgBox("The record has not been saved")
                    Exit Sub
                End If

            ElseIf YNC = Windows.Forms.DialogResult.No Then
                Call SYM00103_Load(sender, e)

            ElseIf YNC = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
        Else
            Call SYM00103_Load(Nothing, Nothing)
        End If
    End Sub

    Private Sub cboVendor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboVendor.KeyPress

        If e.KeyChar.Equals(Chr(13)) Then
            'If checkValidCombo(cboVendor, cboVendor.Text) Then
            Call mmdFind_Click(sender, e)
            'End If
        Else
            If Char.IsLetter(e.KeyChar) Then
                e.KeyChar = Char.ToUpper(e.KeyChar)
            End If
        End If
    End Sub

    Private Sub cboVendor_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVendor.KeyUp
        auto_search_combo(cboVendor)
    End Sub

End Class




