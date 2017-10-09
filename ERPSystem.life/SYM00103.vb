Public Class SYM00103
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
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdLast As System.Windows.Forms.Button
    Friend WithEvents cmdPrevious As System.Windows.Forms.Button
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents cmdFind As System.Windows.Forms.Button
    Friend WithEvents cmdCopy As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdDelRow As System.Windows.Forms.Button
    Friend WithEvents cmdFirst As System.Windows.Forms.Button
    Friend WithEvents cmdInsRow As System.Windows.Forms.Button
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents dgCharge As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_ContP As System.Windows.Forms.Label
    Friend WithEvents txt_ContP As System.Windows.Forms.TextBox
    Friend WithEvents lstVendor As System.Windows.Forms.ListBox
    Friend WithEvents cboVendor As System.Windows.Forms.ComboBox
    Friend WithEvents lblVendor As System.Windows.Forms.Label
    Friend WithEvents ssBar As System.Windows.Forms.StatusBar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.ssBar = New System.Windows.Forms.StatusBar
        Me.cmdLast = New System.Windows.Forms.Button
        Me.cmdPrevious = New System.Windows.Forms.Button
        Me.cmdNext = New System.Windows.Forms.Button
        Me.cmdFind = New System.Windows.Forms.Button
        Me.cmdCopy = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdDelRow = New System.Windows.Forms.Button
        Me.cmdFirst = New System.Windows.Forms.Button
        Me.cmdInsRow = New System.Windows.Forms.Button
        Me.cmdSearch = New System.Windows.Forms.Button
        Me.dgCharge = New System.Windows.Forms.DataGridView
        Me.lbl_ContP = New System.Windows.Forms.Label
        Me.txt_ContP = New System.Windows.Forms.TextBox
        Me.lstVendor = New System.Windows.Forms.ListBox
        Me.cboVendor = New System.Windows.Forms.ComboBox
        Me.lblVendor = New System.Windows.Forms.Label
        CType(Me.dgCharge, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdAdd
        '
        Me.cmdAdd.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdd.Location = New System.Drawing.Point(0, 0)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(56, 40)
        Me.cmdAdd.TabIndex = 0
        Me.cmdAdd.Text = "&Add"
        '
        'cmdSave
        '
        Me.cmdSave.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.Location = New System.Drawing.Point(56, 0)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(56, 40)
        Me.cmdSave.TabIndex = 1
        Me.cmdSave.Text = "&Save"
        '
        'cmdDelete
        '
        Me.cmdDelete.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelete.Location = New System.Drawing.Point(112, 0)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(56, 40)
        Me.cmdDelete.TabIndex = 2
        Me.cmdDelete.Text = "&Delete"
        '
        'ssBar
        '
        Me.ssBar.Location = New System.Drawing.Point(0, 476)
        Me.ssBar.Name = "ssBar"
        Me.ssBar.Size = New System.Drawing.Size(752, 22)
        Me.ssBar.TabIndex = 14
        Me.ssBar.Text = "StatusBar1"
        '
        'cmdLast
        '
        Me.cmdLast.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLast.Location = New System.Drawing.Point(646, 0)
        Me.cmdLast.Name = "cmdLast"
        Me.cmdLast.Size = New System.Drawing.Size(40, 40)
        Me.cmdLast.TabIndex = 12
        Me.cmdLast.Text = ">>|"
        '
        'cmdPrevious
        '
        Me.cmdPrevious.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrevious.Location = New System.Drawing.Point(566, 0)
        Me.cmdPrevious.Name = "cmdPrevious"
        Me.cmdPrevious.Size = New System.Drawing.Size(40, 40)
        Me.cmdPrevious.TabIndex = 10
        Me.cmdPrevious.Text = "<"
        '
        'cmdNext
        '
        Me.cmdNext.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNext.Location = New System.Drawing.Point(606, 0)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(40, 40)
        Me.cmdNext.TabIndex = 11
        Me.cmdNext.Text = ">"
        '
        'cmdFind
        '
        Me.cmdFind.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFind.Location = New System.Drawing.Point(224, 0)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(56, 40)
        Me.cmdFind.TabIndex = 4
        Me.cmdFind.Text = "&Find"
        '
        'cmdCopy
        '
        Me.cmdCopy.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCopy.Location = New System.Drawing.Point(168, 0)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(56, 40)
        Me.cmdCopy.TabIndex = 3
        Me.cmdCopy.Text = "&Copy"
        '
        'cmdClear
        '
        Me.cmdClear.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(280, 0)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(56, 40)
        Me.cmdClear.TabIndex = 5
        Me.cmdClear.Text = "Cl&ear"
        '
        'cmdExit
        '
        Me.cmdExit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(696, 0)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(56, 40)
        Me.cmdExit.TabIndex = 13
        Me.cmdExit.Text = "E&xit"
        '
        'cmdDelRow
        '
        Me.cmdDelRow.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelRow.Location = New System.Drawing.Point(464, 0)
        Me.cmdDelRow.Name = "cmdDelRow"
        Me.cmdDelRow.Size = New System.Drawing.Size(56, 40)
        Me.cmdDelRow.TabIndex = 8
        Me.cmdDelRow.Text = "Del Ro&w"
        '
        'cmdFirst
        '
        Me.cmdFirst.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFirst.Location = New System.Drawing.Point(526, 0)
        Me.cmdFirst.Name = "cmdFirst"
        Me.cmdFirst.Size = New System.Drawing.Size(40, 40)
        Me.cmdFirst.TabIndex = 9
        Me.cmdFirst.Text = "|<<"
        '
        'cmdInsRow
        '
        Me.cmdInsRow.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdInsRow.Location = New System.Drawing.Point(408, 0)
        Me.cmdInsRow.Name = "cmdInsRow"
        Me.cmdInsRow.Size = New System.Drawing.Size(56, 40)
        Me.cmdInsRow.TabIndex = 7
        Me.cmdInsRow.Text = "I&ns Row"
        '
        'cmdSearch
        '
        Me.cmdSearch.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSearch.Location = New System.Drawing.Point(340, 0)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(64, 40)
        Me.cmdSearch.TabIndex = 6
        Me.cmdSearch.Text = "Searc&h"
        '
        'dgCharge
        '
        Me.dgCharge.AllowUserToOrderColumns = True
        Me.dgCharge.AllowUserToResizeColumns = False
        Me.dgCharge.AllowUserToResizeRows = False
        Me.dgCharge.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCharge.Location = New System.Drawing.Point(12, 134)
        Me.dgCharge.Name = "dgCharge"
        Me.dgCharge.RowHeadersWidth = 30
        Me.dgCharge.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgCharge.Size = New System.Drawing.Size(728, 334)
        Me.dgCharge.TabIndex = 15
        Me.dgCharge.Tag = ""
        '
        'lbl_ContP
        '
        Me.lbl_ContP.AutoSize = True
        Me.lbl_ContP.Location = New System.Drawing.Point(14, 101)
        Me.lbl_ContP.Name = "lbl_ContP"
        Me.lbl_ContP.Size = New System.Drawing.Size(98, 16)
        Me.lbl_ContP.TabIndex = 19
        Me.lbl_ContP.Text = "Contact Person"
        '
        'txt_ContP
        '
        Me.txt_ContP.Location = New System.Drawing.Point(129, 98)
        Me.txt_ContP.Name = "txt_ContP"
        Me.txt_ContP.Size = New System.Drawing.Size(181, 22)
        Me.txt_ContP.TabIndex = 21
        '
        'lstVendor
        '
        Me.lstVendor.FormattingEnabled = True
        Me.lstVendor.ItemHeight = 16
        Me.lstVendor.Location = New System.Drawing.Point(12, 400)
        Me.lstVendor.Name = "lstVendor"
        Me.lstVendor.Size = New System.Drawing.Size(473, 68)
        Me.lstVendor.TabIndex = 22
        Me.lstVendor.Visible = False
        '
        'cboVendor
        '
        Me.cboVendor.FormattingEnabled = True
        Me.cboVendor.Location = New System.Drawing.Point(129, 56)
        Me.cboVendor.Name = "cboVendor"
        Me.cboVendor.Size = New System.Drawing.Size(557, 24)
        Me.cboVendor.TabIndex = 23
        '
        'lblVendor
        '
        Me.lblVendor.AutoSize = True
        Me.lblVendor.Location = New System.Drawing.Point(14, 64)
        Me.lblVendor.Name = "lblVendor"
        Me.lblVendor.Size = New System.Drawing.Size(49, 16)
        Me.lblVendor.TabIndex = 24
        Me.lblVendor.Text = "Vendor"
        '
        'SYM00103
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(752, 498)
        Me.Controls.Add(Me.lblVendor)
        Me.Controls.Add(Me.cboVendor)
        Me.Controls.Add(Me.lstVendor)
        Me.Controls.Add(Me.txt_ContP)
        Me.Controls.Add(Me.lbl_ContP)
        Me.Controls.Add(Me.dgCharge)
        Me.Controls.Add(Me.ssBar)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.cmdLast)
        Me.Controls.Add(Me.cmdPrevious)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.cmdFind)
        Me.Controls.Add(Me.cmdCopy)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdDelRow)
        Me.Controls.Add(Me.cmdFirst)
        Me.Controls.Add(Me.cmdInsRow)
        Me.Controls.Add(Me.cmdSearch)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "SYM00103"
        Me.Text = "SYM00103 - Vendor Trading Terms Maintenance"
        CType(Me.dgCharge, System.ComponentModel.ISupportInitialize).EndInit()
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

            cmdFind.Enabled = True
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


    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click

        Dim YNC As Integer
        Dim flgMod As Boolean = False

        bindSrc.EndEdit()
        If Me.ssBar.Text = "Init" Then
            Me.Close()
        Else

            If Me.ssBar.Text = "Insert Row" Or Me.ssBar.Text = "Record Row Deleted" Then
                YNC = MessageBox.Show("Record has been modified. Do you want to save before exit?", "Question", MessageBoxButtons.YesNoCancel)

                If YNC = Windows.Forms.DialogResult.Yes Then

                    Call cmdSave_Click(sender, e)

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
            Me.cmdAdd.Enabled = False
            Me.cmdSave.Enabled = False
            Me.cmdDelete.Enabled = False
            Me.cmdCopy.Enabled = False
            Me.cmdFind.Enabled = False
            Me.cmdClear.Enabled = False

            Me.cmdSearch.Enabled = False

            Me.cmdInsRow.Enabled = False
            Me.cmdDelRow.Enabled = False
            Me.cmdFirst.Enabled = False
            Me.cmdPrevious.Enabled = False
            Me.cmdNext.Enabled = False
            Me.cmdLast.Enabled = False

            Me.cmdExit.Enabled = True
            'Frankie Cheung 20111031
            'txt_VnCde.Focus()
            cboVendor.Focus()
            Call SetStatusBar(mode)
        ElseIf mode = "InsRow" Then
            Me.cmdCopy.Enabled = False
            Me.cmdFind.Enabled = False
            Me.cmdSave.Enabled = Enq_right_local
            Me.cmdDelRow.Enabled = Del_right_local
            Call SetStatusBar(mode)

        ElseIf mode = "Save" Then
            Call ResetDefaultDisp()
            Call SetStatusBar(mode)
            MsgBox("Record Saved!")
            'Call SYM00103_Load(Nothing, Nothing)

        ElseIf mode = "DelRow" Then
            Me.cmdCopy.Enabled = False
            Me.cmdFind.Enabled = False
            Me.cmdSave.Enabled = Enq_right_local
            Me.cmdDelRow.Enabled = Del_right_local
            Call SetStatusBar(mode)

        ElseIf mode = "Clear" Then
            Call ResetDefaultDisp()
            Call SetStatusBar(mode)
        End If

        If Not CanModify Then
            Me.cmdAdd.Enabled = False
            Me.cmdSave.Enabled = False
            Me.cmdDelete.Enabled = False
            Me.cmdInsRow.Enabled = False
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
                            cmdSave.Enabled = Enq_right_local
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
                            cmdSave.Enabled = Enq_right_local
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
                    Call cmdDelRow_Click(sender, e)
                    row.Cells("vtt_del").ReadOnly = True
                End If
            End If
            If e.ColumnIndex = 4 Then
                If row.Cells("vtt_del").Value.ToString = "" And row.Cells("vtt_creusr").Value.ToString = "~*ADD*~" Then
                    If TypeOf (dgCharge.CurrentCell) Is DataGridViewTextBoxCell Then
                        createComboBoxCell(dgCharge.CurrentCell)
                        dgCharge.BeginEdit(True)
                        cmdSave.Enabled = Enq_right_local
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
                                    cmdSave.Enabled = Enq_right_local
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
                                cmdSave.Enabled = Enq_right_local
                            End If
                            Exit Sub
                        End If
                    End If
                Next
            End If
        End If





    End Sub




    Private Sub cmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsRow.Click

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




    Private Sub cmdDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelRow.Click
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
        cmdClear.Enabled = True
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
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
                            cmdSave.Enabled = Enq_right_local
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
                                        cmdSave.Enabled = Enq_right_local
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

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click

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
                    Me.cmdInsRow.Enabled = True
                    Me.cmdDelRow.Enabled = True
                    Me.cmdSave.Enabled = True
                    Me.cmdFind.Enabled = False
                    Me.cmdClear.Enabled = True
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

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
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

                Call cmdSave_Click(sender, e)

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
            Call cmdFind_Click(sender, e)
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



