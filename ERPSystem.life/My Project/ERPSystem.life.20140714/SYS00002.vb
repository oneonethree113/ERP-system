Public Class SYS00002

    Inherits System.Windows.Forms.Form
    Dim rs_syusrpr As New DataSet
    Dim rs_syusrgrp As New DataSet
    Dim rs_sycominf As New DataSet
    Dim rs_symusrco As New DataSet
    Dim rs_rights As New DataSet
    Dim bindSrc As New BindingSource
    Dim password As String
    Dim pwd_bf As String
    Dim save_ok As Boolean
    Dim Add_flag As Boolean
    Dim CanModify As Boolean = True
    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean

    Private Sub SYS00002_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Call AccessRight(Me.Name)
            Enq_right_local = Enq_right
            Del_right_local = Del_right

            gspStr = "sp_list_SYUSRPRF_1 '" & gsCompany & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_syusrpr, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYS00002 sp_list_SYUSRPRF_1 : " & rtnStr)
            Else
                gspStr = "sp_select_SYSUSERGRP '" & gsCompany & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_syusrgrp, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading SYS00002 sp_select_SYSUSERGRP : " & rtnStr)
                Else
                    gspStr = "sp_select_SYCOMINF_M '" & gsCompany & "','All'"
                    rtnLong = execute_SQLStatement(gspStr, rs_sycominf, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading SYS00002 sp_select_SYCOMINF_M : " & rtnStr)
                    Else
                        For Each ctl As Control In GrpBoxMain.Controls
                            If TypeOf (ctl) Is TextBox Or TypeOf (ctl) Is MaskedTextBox Then
                                ctl.Text = ""
                                ctl.Enabled = False
                            End If
                        Next
                        txtUsrID.Enabled = True
                        txtUsrID.Focus()
                        Add_flag = False
                        DataGrid.DataSource = Nothing
                        DataGridRights.DataSource = Nothing

                        If Enq_right_local = False Then
                            txtUsrID.Text = gsUsrID
                            txtUsrID.Enabled = False
                            Call cmdFind_Click(sender, e)
                        End If
                        'Call setStatus("Init")
                    End If
                End If
            End If
            Call Formstartup(Me.Name)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub setDataRowAttr()

        For Each dc As DataColumn In rs_symusrco.Tables("RESULT").Columns
            If dc.ColumnName = "yuc_del" Then
                dc.ColumnName = "yuc_status"
            End If
            dc.ReadOnly = False
        Next

        For Each dr As DataRow In rs_symusrco.Tables("RESULT").Rows
            dr.Item("yuc_flgcst") = IIf(dr.Item("yuc_flgcst") = "1", "Y", "N")
            dr.Item("yuc_flgcstext") = IIf(dr.Item("yuc_flgcstext") = "1", "Y", "N")
            dr.Item("yuc_flgrel") = IIf(dr.Item("yuc_flgrel") = "1", "Y", "N")
            dr.Item("yuc_status") = ""
        Next
        rs_symusrco.AcceptChanges()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        Dim YNC As Integer
        Dim flgMod As Boolean = False

        bindSrc.EndEdit()
        If Not rs_symusrco.Tables("RESULT") Is Nothing Then
            For Each dr As DataRow In rs_symusrco.Tables("RESULT").Rows
                If dr.RowState = DataRowState.Modified Or dr.RowState = DataRowState.Added Then
                    flgMod = True
                End If
            Next
        End If

        If flgMod Then
            YNC = MessageBox.Show("Record has been modified. Do you want to save?", "Question", MessageBoxButtons.YesNoCancel)

            If YNC = Windows.Forms.DialogResult.Yes Then
                If Enq_right_local Then
                    Call cmdSave_Click(sender, e)

                    If save_ok Then
                        Call SYS00002_Load(Nothing, Nothing)
                    Else
                        Exit Sub
                    End If
                Else
                    MsgBox("Sorry! You have not right to save!")
                End If
            ElseIf YNC = Windows.Forms.DialogResult.No Then
                Call SYS00002_Load(Nothing, Nothing)

            ElseIf YNC = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
        Else
            Call SYS00002_Load(Nothing, Nothing)
        End If

    End Sub

    Private Sub displayGrid()
        Dim i As Integer
        Dim dv As DataView = rs_symusrco.Tables("RESULT").DefaultView

        With DataGrid
            .DataSource = Nothing
            .DataSource = dv
            For i = 0 To .Columns.Count - 1
                Select Case i
                    Case 0
                        .Columns(i).Width = 30
                        .Columns(i).HeaderText = "Del"
                        .Columns(i).ReadOnly = True
                    Case 2
                        .Columns(i).Width = 50
                        .Columns(i).HeaderText = "Comp"
                    Case 3
                        .Columns(i).Width = 150
                        .Columns(i).HeaderText = "Company Short Name"
                        .Columns(i).ReadOnly = True
                    Case 4
                        .Columns(i).Width = 60
                        .Columns(i).HeaderText = "UsrGrp"
                    Case 5
                        .Columns(i).Width = 80
                        .Columns(i).HeaderText = "SupervisorID"
                    Case 6
                        .Columns(i).Width = 60
                        .Columns(i).HeaderText = "UsrRank"
                    Case 7
                        .Columns(i).Width = 60
                        .Columns(i).HeaderText = "IntCst/Prc"
                        .Columns(i).ReadOnly = True
                    Case 8
                        .Columns(i).Width = 60
                        .Columns(i).HeaderText = "ExtCst/Prc"
                        .Columns(i).ReadOnly = True
                    Case 9
                        .Columns(i).Width = 60
                        .Columns(i).HeaderText = "ItmSum"
                        .Columns(i).ReadOnly = True
                    Case 10
                        .Columns(i).Width = 60
                        .Columns(i).HeaderText = "DefComp"
                        .Columns(i).ReadOnly = True
                    Case 11
                        .Columns(i).Width = 50
                        .Columns(i).HeaderText = "Rmk"
                        .Columns(i).ReadOnly = False
                    Case Else
                        .Columns(i).Visible = False
                End Select
                .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i
        End With

        dv = rs_rights.Tables("RESULT").DefaultView
        bindSrc.DataSource = dv
        With DataGridRights
            .DataSource = Nothing
            .DataSource = bindSrc
            For i = 0 To .Columns.Count - 1
                Select Case i
                    Case 0
                        .Columns(i).Width = 50
                        .Columns(i).HeaderText = "Comp"
                        .Columns(i).ReadOnly = True
                    Case 2
                        .Columns(i).Width = 100
                        .Columns(i).HeaderText = "Module"
                        .Columns(i).ReadOnly = True
                    Case 3
                        .Columns(i).Width = 150
                        .Columns(i).HeaderText = "Description"
                        .Columns(i).ReadOnly = True
                    Case Else
                        .Columns(i).Visible = False
                End Select
                .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i
        End With
    End Sub

    Private Sub setStatus(ByVal mode As String)

        If mode = "Init" Then
            cmdAdd.Enabled = Enq_right_local
            cmdSave.Enabled = False
            cmdDelete.Enabled = False
            cmdCopy.Enabled = False
            cmdFind.Enabled = True
            cmdInsRow.Enabled = False
            cmdDelRow.Enabled = False
            cmdExit.Enabled = True
            cmdClear.Enabled = True
            cmdSearch.Enabled = True

            cmdFirst.Enabled = False
            cmdLast.Enabled = False
            cmdNext.Enabled = False
            cmdPrevious.Enabled = False

            Call ResetDefaultDisp()
            Call SetStatusBar(mode)

        ElseIf mode = "ADD" Then
            cmdSave.Enabled = Enq_right_local
            cmdDelete.Enabled = False
            cmdAdd.Enabled = False
            cmdFind.Enabled = False
            cmdCopy.Enabled = False
            cmdInsRow.Enabled = Enq_right_local
            Call SetStatusBar(mode)
            txtExpDat.Text = Now.AddDays(90)
            txtAccExp.Text = Now.AddYears(10)

        ElseIf mode = "InsRow" Then
            cmdCopy.Enabled = False
            cmdFind.Enabled = False
            cmdSave.Enabled = Enq_right_local
            cmdDelRow.Enabled = Del_right_local
            Call SetStatusBar(mode)

        ElseIf mode = "Updating" Then
            cmdAdd.Enabled = False
            cmdSave.Enabled = True
            cmdDelete.Enabled = Del_right_local
            cmdCopy.Enabled = False
            cmdFind.Enabled = False
            cmdInsRow.Enabled = Enq_right_local
            cmdDelRow.Enabled = False
            cmdExit.Enabled = True
            cmdClear.Enabled = True
            txtUsrID.Enabled = False

            cmdFirst.Enabled = False
            cmdLast.Enabled = False
            cmdPrevious.Enabled = False
            cmdNext.Enabled = False
            Call SetStatusBar(mode)

        ElseIf mode = "Save" Then
            Call ResetDefaultDisp()
            Call SetStatusBar(mode)
            MsgBox("Record Saved!")
            Call SYS00002_Load(Nothing, Nothing)

        ElseIf mode = "DelRow" Then
            cmdCopy.Enabled = False
            cmdFind.Enabled = False
            cmdSave.Enabled = Enq_right_local
            cmdDelRow.Enabled = Del_right_local
            Call SetStatusBar(mode)

        ElseIf mode = "Clear" Then
            Call setStatus("Init")
            Call SetStatusBar(mode)
            DataGrid.DataSource = Nothing
            DataGridRights.DataSource = Nothing
            txtUsrID.Enabled = True
            txtUsrID.Focus()
            Call ResetDefaultDisp()
            Call SetStatusBar(mode)
        End If

        If Not CanModify Then
            cmdAdd.Enabled = False
            cmdSave.Enabled = False
            cmdDelete.Enabled = False
            cmdInsRow.Enabled = False
            cmdDelRow.Enabled = False

            Call ResetDefaultDisp()
            Call SetStatusBar("ReadOnly")
        End If
    End Sub

    Private Sub SetStatusBar(ByVal mode As String)

        If mode = "Init" Then
            Me.StatusBar.Items("lblLeft").Text = "Init"
        ElseIf mode = "InsRow" Then
            Me.StatusBar.Items("lblLeft").Text = "Insert Row"
        ElseIf mode = "Updating" Then
            Me.StatusBar.Items("lblLeft").Text = "Updating"
        ElseIf mode = "Save" Then
            Me.StatusBar.Items("lblLeft").Text = "Record Saved"
        ElseIf mode = "DelRow" Then
            Me.StatusBar.Items("lblLeft").Text = "Record Row Deleted"
        ElseIf mode = "ReadOnly" Then
            Me.StatusBar.Items("lblLeft").Text = "Read Only"
        ElseIf mode = "Clear" Then
            Me.StatusBar.Items("lblLeft").Text = "Clear Screen"
        End If

    End Sub

    Private Sub ResetDefaultDisp()
        Me.StatusBar.Items("lblLeft").Text = ""
    End Sub

    Private Sub createComboBoxCell(ByVal cell As DataGridViewCell)
        Dim cboCell As New DataGridViewComboBoxCell
        Dim iCol As Integer = cell.ColumnIndex
        Dim iRow As Integer = cell.RowIndex
        Dim dgView As DataGridView = cell.DataGridView
        Dim i, iRank As Integer
        Dim drr() As DataRow

        Select Case iCol
            Case 2
                For Each dr As DataRow In rs_sycominf.Tables("RESULT").Rows
                    cboCell.Items.Add(dr.Item("yco_cocde").ToString.Trim)
                Next

            Case 4
                For Each dr As DataRow In rs_syusrgrp.Tables("RESULT").Rows
                    If Not dr.Item("yug_usrgrp").ToString.Trim = "" Then
                        cboCell.Items.Add(dr.Item("yug_usrgrp").ToString.Trim)
                    End If
                Next

            Case 5
                For Each dr As DataRow In rs_syusrpr.Tables("RESULT").Rows
                    cboCell.Items.Add(dr.Item("yup_usrid").ToString.Trim)
                Next

            Case 6
                drr = rs_syusrpr.Tables("RESULT").Select("yup_usrid = '" & dgView.Rows(iRow).Cells("yuc_supid").Value.ToString & "'")
                If Not drr.Length = 0 Then
                    iRank = drr(0).Item("yup_usrank")
                End If

                For i = iRank To 9
                    cboCell.Items.Add(i)
                Next

            Case 7, 8, 9
                cboCell.Items.Add("Y")
                cboCell.Items.Add("N")

        End Select
        cboCell.DropDownWidth = 150
        cboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

        dgView.Rows(iRow).Cells(iCol) = cboCell
        dgView.Rows(iRow).Cells(iCol).ReadOnly = False
    End Sub

    Private Sub cboOpt_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim iRow As Integer = DataGrid.CurrentCell.RowIndex
        Dim iCol As Integer = DataGrid.CurrentCell.ColumnIndex
        Dim strSelItem As String

        If TypeOf (Me.DataGrid.CurrentCell) Is DataGridViewComboBoxCell Then
            Dim cboBox As ComboBox = CType(sender, ComboBox)
            If Not cboBox Is Nothing AndAlso Not cboBox.SelectedItem Is Nothing Then

                strSelItem = cboBox.SelectedItem.ToString
                RemoveHandler cboBox.SelectedIndexChanged, AddressOf cboOpt_SelectedIndexChanged
                ' User has changed the company
                If iCol = 2 Then
                    Me.DataGrid.Rows(iRow).Cells(iCol).Value = strSelItem
                    Me.DataGrid.Rows(iRow).Cells(iCol + 1).Value = rs_sycominf.Tables("RESULT").Select("yco_cocde = '" & strSelItem & "'")(0).Item("yco_shtnam").ToString
                End If

                If iRow = 0 And (iCol = 4 Or iCol = 5 Or iCol = 6 Or iCol = 7 Or iCol = 8 Or iCol = 9) Then
                    For Each dr As DataRow In rs_symusrco.Tables("RESULT").Rows
                        dr.Item(iCol) = strSelItem
                    Next
                End If

                AddHandler cboBox.SelectedIndexChanged, AddressOf cboOpt_SelectedIndexChanged

            End If
        End If
    End Sub

    Private Sub DataGrid_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGrid.EditingControlShowing

        If DataGrid.CurrentCell.ColumnIndex = 2 Or DataGrid.CurrentCell.ColumnIndex = 4 Or DataGrid.CurrentCell.ColumnIndex = 5 Or DataGrid.CurrentCell.ColumnIndex = 6 Or _
           DataGrid.CurrentCell.ColumnIndex = 7 Or DataGrid.CurrentCell.ColumnIndex = 8 Or DataGrid.CurrentCell.ColumnIndex = 9 Then

            If TypeOf (e.Control) Is DataGridViewComboBoxEditingControl Then
                Dim cboBox As ComboBox = CType(e.Control, ComboBox)
                If Not cboBox Is Nothing Then
                    RemoveHandler cboBox.SelectedIndexChanged, AddressOf cboOpt_SelectedIndexChanged
                    AddHandler cboBox.SelectedIndexChanged, AddressOf cboOpt_SelectedIndexChanged
                End If
            End If
        End If
    End Sub

    Private Sub DataGrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGrid.CellClick
        Dim row As DataGridViewRow = DataGrid.CurrentRow
        Dim YN As Integer

        If Not e.RowIndex = -1 Then

            If e.ColumnIndex = 0 Then
                ' Toggle Delete
                If Not row.Cells("yuc_cocde").Value.ToString = "" Then
                    Call cmdDelRow_Click(sender, e)
                End If

            ElseIf e.ColumnIndex = 2 Then
                If row.Cells("yuc_creusr").Value.ToString = "" And row.Cells("yuc_status").Value.ToString = "" Then
                    If TypeOf (DataGrid.CurrentCell) Is DataGridViewTextBoxCell Then
                        createComboBoxCell(DataGrid.CurrentCell)
                        DataGrid.BeginEdit(True)
                        cmdSave.Enabled = Enq_right_local
                    End If
                Else
                    row.Cells(e.ColumnIndex).ReadOnly = True
                End If

            ElseIf e.ColumnIndex = 4 Or e.ColumnIndex = 6 Or e.ColumnIndex = 7 Or e.ColumnIndex = 8 Or e.ColumnIndex = 9 Then
                If e.RowIndex = 0 Then
                    If TypeOf (DataGrid.CurrentCell) Is DataGridViewTextBoxCell Then
                        createComboBoxCell(DataGrid.CurrentCell)
                        DataGrid.BeginEdit(True)
                        cmdSave.Enabled = Enq_right_local
                    End If
                Else
                    row.Cells(e.ColumnIndex).ReadOnly = True
                End If

            ElseIf e.ColumnIndex = 5 Then
                If TypeOf (DataGrid.CurrentCell) Is DataGridViewTextBoxCell Then
                    createComboBoxCell(DataGrid.CurrentCell)
                    DataGrid.BeginEdit(True)
                    cmdSave.Enabled = Enq_right_local
                End If

            ElseIf e.ColumnIndex = 10 Then
                If row.Cells("yuc_status").Value.ToString = "" And row.Cells("yuc_flgdef").Value.ToString = "N" Then
                    YN = MessageBox.Show("Do you want to change to default?", "Question", MessageBoxButtons.YesNo)
                    If YN = Windows.Forms.DialogResult.Yes Then
                        For Each dr As DataRow In rs_symusrco.Tables("RESULT").Rows
                            If dr.Item("yuc_flgdef").ToString = "Y" Then
                                dr.Item("yuc_flgdef") = "N"
                            End If
                        Next
                        row.Cells("yuc_flgdef").Value = "Y"
                        cmdSave.Enabled = Enq_right_local
                    End If
                End If

            ElseIf e.ColumnIndex = 11 Then
                DataGrid.BeginEdit(True)
                cmdSave.Enabled = Enq_right_local

            End If
        End If
    End Sub

    Private Sub DataGrid_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DataGrid.CellValidating
        Dim row As DataGridViewRow = DataGrid.CurrentRow
        Dim strNewVal As String

        strNewVal = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim

        If row.Cells(e.ColumnIndex).IsInEditMode Then

            If e.ColumnIndex = 2 Then
                If Not chkGrdCellValue(row.Cells("yuc_cocde"), "String", 6) Then
                    e.Cancel = True
                Else
                    For Each drr As DataGridViewRow In DataGrid.Rows
                        If drr.Index <> e.RowIndex Then
                            If drr.Cells("yuc_cocde").Value.ToString.ToUpper = strNewVal.ToUpper Then
                                MsgBox("Duplicated company code!")
                                e.Cancel = True
                                Exit For
                            End If
                        End If
                    Next
                End If
            End If

            If e.ColumnIndex = 4 Then
                If Not chkGrdCellValue(row.Cells("yuc_usrgrp"), "String", 6) Then
                    e.Cancel = True
                End If
            End If

            If e.ColumnIndex = 5 Then
                If Not chkGrdCellValue(row.Cells("yuc_supid"), "String", 12) Then
                    e.Cancel = True
                End If
            End If

            If e.ColumnIndex = 6 Then
                If strNewVal = "" Then
                    MsgBox("Please input user rank.")
                    e.Cancel = True
                End If
            End If
        End If

    End Sub

    Private Sub cmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsRow.Click
        Dim dt As DataTable
        Dim dr As DataRow
        Dim dtr() As DataRow

        dt = rs_symusrco.Tables("RESULT")
        For Each dr In dt.Rows
            If dr.Item("yuc_cocde").ToString.Trim = "" Then
                MsgBox("Please input company code.")
                Exit Sub
            End If
        Next

        If dt.Rows.Count = 0 Then
            dr = dt.NewRow
            dr.Item("yuc_usrid") = txtUsrID.Text.Trim
            dr.Item("yuc_usrank") = 9
            dr.Item("yuc_flgcst") = "N"
            dr.Item("yuc_flgcstext") = "N"
            dr.Item("yuc_flgrel") = "N"
            dr.Item("yuc_flgdef") = "Y"
        Else
            dr = dt.NewRow
            dtr = dt.Select("")
            If dtr.Length > 0 Then
                dr.Item("yuc_usrid") = dtr(0).Item("yuc_usrid").ToString
                dr.Item("yuc_usrgrp") = dtr(0).Item("yuc_usrgrp").ToString
                dr.Item("yuc_usrank") = dtr(0).Item("yuc_usrank").ToString

                dr.Item("yuc_flgcst") = dtr(0).Item("yuc_flgcst").ToString
                dr.Item("yuc_flgcstext") = dtr(0).Item("yuc_flgcstext").ToString
                dr.Item("yuc_flgrel") = dtr(0).Item("yuc_flgrel").ToString
            End If
            dr.Item("yuc_flgdef") = "N"
        End If
        dr.Item("yuc_status") = ""
        dt.Rows.Add(dr)

        For Each drr As DataGridViewRow In DataGrid.Rows
            If IsDBNull(drr.Cells(2).Value) Then
                DataGrid.CurrentCell = drr.Cells(2)
                createComboBoxCell(DataGrid.CurrentCell)
                DataGrid.BeginEdit(True)
            End If
        Next
        Call setStatus("InsRow")
    End Sub

    Private Sub cmdDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelRow.Click
        Dim row As DataGridViewRow = DataGrid.CurrentRow
        Dim cellStyle As New DataGridViewCellStyle

        ' Toggle Delete
        If Not row Is Nothing Then
            If Not row.Cells("yuc_cocde").Value.ToString = "" Then
                If row.Cells("yuc_status").Value.ToString = "" Then
                    row.Cells("yuc_status").Value = "Y"
                    cellStyle.BackColor = Color.LightBlue
                Else
                    row.Cells("yuc_status").Value = ""
                    cellStyle.BackColor = Nothing
                End If
                row.DataGridView.CurrentRow.DefaultCellStyle = cellStyle
                Call setStatus("DelRow")
            End If
        End If

    End Sub

    Private Sub txtUsrID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUsrID.LostFocus
        Dim dtr() As DataRow

        If Add_flag = True Then
            dtr = rs_syusrpr.Tables("RESULT").Select("yup_usrid = '" & txtUsrID.Text.Trim & "'")
            If Not dtr.Length = 0 Then
                MsgBox("User ID already existed.")
                txtUsrID.Focus()
                txtUsrID.Clear()
            End If
        End If
    End Sub

    Private Sub txtUsrID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUsrID.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then
            Call cmdFind_Click(sender, e)
        End If
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Add_flag = True

        txtUsrID.Text = ""
        txtUsrID.Focus()

        gspStr = "sp_select_SYMUSRCO '" & gsCompany & "',''"
        rtnLong = execute_SQLStatement(gspStr, rs_symusrco, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SYS00002 sp_select_SYMUSRCO : " & rtnStr)
        Else
            gspStr = "sp_select_SYUSRRIGHT_USER '" & gsCompany & "',''"
            rtnLong = execute_SQLStatement(gspStr, rs_rights, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYS00002 sp_select_SYUSRRIGHT_USER : " & rtnStr)
            Else
                Call setDataRowAttr()
                Call displayGrid()

                For Each ctl As Control In GrpBoxMain.Controls
                    If TypeOf (ctl) Is TextBox Or TypeOf (ctl) Is MaskedTextBox Then
                        ctl.Text = ""
                        ctl.Enabled = True
                    End If
                Next
                Call setStatus("ADD")
            End If
        End If

    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        Dim dtr() As DataRow
        Dim pwd, password As String
        Dim lenpwd, i, X, Y As Integer

        If txtUsrID.Text.Trim = "" Then
            txtUsrID.Focus()
            MsgBox("Please input your User ID.")
        Else
            dtr = rs_syusrpr.Tables("RESULT").Select("yup_usrid = '" & txtUsrID.Text.Trim & "'")
            If dtr.Length = 0 Then
                txtUsrID.Focus()
                MsgBox("User Not Found!")
            Else
                password = ""
                txtUsrID.Text = dtr(0).Item("yup_usrid")
                txtUsrNam.Text = dtr(0).Item("yup_usrnam")

                pwd = dtr(0).Item("yup_paswrd")
                lenpwd = Len(pwd)
                Y = 1

                For i = 0 To lenpwd - 1
                    If Y <= lenpwd Then
                        X = Mid(pwd, Y, 1)
                        password = password + Chr(Mid(pwd, Y + 1, X))
                        Y = Y + X + 1
                    End If
                Next

                pwd_bf = password

                txtUsrPwd.Text = password
                txtConPwd.Text = password

                txtMailAd.Text = dtr(0).Item("yup_mailad")
                txtExpDat.Text = dtr(0).Item("yup_expdat")
                txtAccExp.Text = dtr(0).Item("yup_accexp")

                For Each ctl As Control In GrpBoxMain.Controls
                    If TypeOf (ctl) Is TextBox Or TypeOf (ctl) Is MaskedTextBox Then
                        ctl.Enabled = True
                    End If
                Next

                gspStr = "sp_select_SYMUSRCO '" & gsCompany & "','" & Me.txtUsrID.Text.Trim & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_symusrco, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading SYS00002 sp_select_SYMUSRCO : " & rtnStr)
                Else
                    gspStr = "sp_select_SYUSRRIGHT_USER '" & gsCompany & "','" & Me.txtUsrID.Text.Trim & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs_rights, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading SYS00002 sp_select_SYUSRRIGHT_USER : " & rtnStr)
                    Else
                        Call setDataRowAttr()
                        Call displayGrid()
                        Call setStatus("Updating")
                    End If
                End If
            End If
        End If
        txtExpDat.Enabled = False
        txtAccExp.Enabled = False
        txtUsrNam.Enabled = False
        txtMailAd.Enabled = False
    End Sub

    Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim dtr() As DataRow
        Dim flgErr As Boolean = False
        Dim flgReAct As Boolean = False
        Dim password1 As String
        Dim password2 As String
        Dim pwd As String
        Dim i, X, lenpwd As Integer

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            save_ok = True
            bindSrc.EndEdit()

            pwd = ""
            password = ""
            password1 = ""
            password2 = ""

            If txtExpDat.Text = "" Then
                txtExpDat.Focus()
                save_ok = False
                MsgBox("Expiry Date is empty, please input again!")

            ElseIf Not IsDate(txtExpDat.Text) Or Len(txtExpDat.Text) < 10 Then
                txtExpDat.Focus()
                save_ok = False
                MsgBox("Expiry Date is not a valid date, please input again!")

            ElseIf txtAccExp.Text = "" Then
                txtAccExp.Focus()
                save_ok = False
                MsgBox("A/C Expiry Date is empty, please input again!")

            ElseIf Not IsDate(txtAccExp.Text) Or Len(txtAccExp.Text) < 10 Then
                txtAccExp.Focus()
                save_ok = False
                MsgBox("A/C Expiry Date is not a valid date, please input again!")

            ElseIf txtUsrID.Text = "" Then
                txtUsrID.Focus()
                save_ok = False
                MsgBox("Please input User ID.")

            ElseIf txtUsrNam.Text = "" Then
                txtUsrNam.Focus()
                save_ok = False
                MsgBox("Please input your User Name.")

            ElseIf txtUsrPwd.Text = "" Then
                txtUsrPwd.Focus()
                save_ok = False
                MsgBox("Please input your password.")

            ElseIf txtConPwd.Text = "" Then
                txtConPwd.Focus()
                save_ok = False
                MsgBox("Please confirm your password.")

            ElseIf Not Len(Me.txtUsrPwd.Text) >= 6 Then
                Me.txtUsrPwd.Focus()
                save_ok = False
                MsgBox("Password should contain at least 6 characters.")

            ElseIf txtUsrPwd.Text <> txtConPwd.Text Then
                txtConPwd.Text = ""
                txtConPwd.Focus()
                save_ok = False
                MsgBox("Confirmed Password does not match.")

            Else
                If rs_symusrco.Tables("RESULT").Rows.Count = 0 Then
                    save_ok = False
                    MsgBox("No Company Access Rights assigned, Please enter again!")

                Else
                    pwd = txtUsrPwd.Text
                    lenpwd = Len(txtUsrPwd.Text)

                    For i = 0 To lenpwd - 1
                        X = Asc(Mid(pwd, i + 1, 1))
                        password = password + LTrim(Str(Len(LTrim(Str((X)))))) + LTrim(Str(X))
                    Next
                End If
            End If

            If Not save_ok Then
                Exit Sub
            Else
                For Each row As DataGridViewRow In DataGrid.Rows

                    If row.Cells("yuc_status").Value.ToString = "" Then

                        If Not chkGrdCellValue(row.Cells("yuc_cocde"), "String", 6) Then
                            save_ok = False
                            flgReAct = True

                        ElseIf Not chkGrdCellValue(row.Cells("yuc_usrgrp"), "String", 6) Then
                            save_ok = False
                            flgReAct = True

                        ElseIf Not chkGrdCellValue(row.Cells("yuc_supid"), "String", 12) Then
                            save_ok = False
                            flgReAct = True

                        Else
                            If row.Cells("yuc_creusr").Value.ToString = "" Then
                                For Each drr As DataGridViewRow In DataGrid.Rows
                                    If drr.Index <> row.Index Then
                                        If drr.Cells("yuc_cocde").Value.ToString.ToUpper = row.Cells("yuc_cocde").Value.ToString.ToUpper And _
                                           drr.Cells("yuc_status").Value.ToString = "" Then

                                            MsgBox("Duplicated company code " & drr.Cells("yuc_cocde").Value.ToString & "!")
                                            save_ok = False
                                            flgReAct = True
                                            row.DataGridView.CurrentCell = row.Cells("yuc_cocde")
                                        End If
                                    End If
                                Next
                            End If
                        End If
                    End If

                    If Not save_ok Then
                        Exit For
                    End If
                Next

                If Not save_ok Then
                    With DataGrid
                        If flgReAct Then
                            ' if flgReAct = T, reactivate combo box
                            createComboBoxCell(.CurrentCell)
                        End If
                        .BeginEdit(True)
                    End With
                    Exit Sub
                Else
                    gspStr = ""
                    If Add_flag Then
                        dtr = rs_syusrpr.Tables("RESULT").Select("yup_usrid = '" & txtUsrID.Text.Replace("'", "''").Trim & "'")
                        If Not dtr.Length = 0 Then
                            MsgBox("User ID already existed.")
                            txtUsrID.Focus()
                            save_ok = False
                            Exit Sub
                        End If

                        gspStr = "sp_insert_SYUSRPRF_1 '" & gsCompany & "','" & _
                                    txtUsrID.Text.Replace("'", "''").Trim & "','" & _
                                    txtUsrNam.Text.Replace("'", "''").Trim & "','" & _
                                    password & "','" & _
                                    txtExpDat.Text.Replace("'", "''").Trim & "','" & _
                                    txtMailAd.Text.Replace("'", "''").Trim & "','" & _
                                    gsUsrID & "','" & _
                                    txtAccExp.Text.Replace("'", "''").Trim & "'"
                        If gspStr <> "" Then
                            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                            If rtnLong <> RC_SUCCESS Then
                                MsgBox("Error on loading SYS00002 sp_insert_SYUSRPRF_1 : " & rtnStr)
                                flgErr = True
                                Exit Sub
                            End If
                        End If

                        gspStr = ""
                        For Each dr As DataRow In rs_symusrco.Tables("RESULT").Rows

                            If dr.RowState = DataRowState.Added And Not dr.Item("yuc_status") = "Y" Then
                                If dr.Item("yuc_creusr").ToString.Trim = "" Then
                                    gspStr = "sp_insert_SYMUSRCO '" & gsCompany & "','" & _
                                                dr.Item("yuc_cocde").Replace("'", "''").ToString.Trim & "','" & _
                                                dr.Item("yuc_usrid").Replace("'", "''").ToString.Trim & "','" & _
                                                dr.Item("yco_shtnam").Replace("'", "''").ToString.Trim & "','" & _
                                                dr.Item("yuc_usrgrp").Replace("'", "''").ToString.Trim & "'," & _
                                                dr.Item("yuc_usrank").Replace("'", "''").ToString.Trim & ",'" & _
                                                dr.Item("yuc_supid").Replace("'", "''").ToString.Trim & "','" & _
                                                dr.Item("yuc_rmk").Replace("'", "''").ToString.Trim & "','" & _
                                                IIf(dr.Item("yuc_flgcst").ToString.Trim = "Y", 1, 0) & "','" & _
                                                IIf(dr.Item("yuc_flgcstext").ToString.Trim = "Y", 1, 0) & "','" & _
                                                IIf(dr.Item("yuc_flgrel").ToString.Trim = "Y", 1, 0) & "','" & _
                                                dr.Item("yuc_flgdef").Replace("'", "''").ToString.Trim & "','" & _
                                                gsUsrID & "','SYS00002'"
                                End If
                            End If

                            If gspStr <> "" Then
                                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                If rtnLong <> RC_SUCCESS Then
                                    MsgBox("Error on loading SYM00026 sp_insert_SYMUSRCO : " & rtnStr)
                                    flgErr = True
                                    Exit For
                                End If
                            End If
                        Next

                        gspStr = "sp_insert_SYUSRRIGHT_SUPER '" & gsCompany & "','" & _
                                    txtUsrID.Text.Replace("'", "''").Trim & "','" & _
                                    gsUsrID & "'"
                        If gspStr <> "" Then
                            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                            If rtnLong <> RC_SUCCESS Then
                                MsgBox("Error on loading SYS00002 sp_insert_SYUSRRIGHT_SUPER : " & rtnStr)
                                flgErr = True
                                Exit Sub
                            End If
                        End If

                    Else
                        ' AddFlag = False
                        dtr = rs_syusrpr.Tables("RESULT").Select("yup_usrid = '" & txtUsrID.Text.Trim & "'")
                        If Not dtr.Length = 0 Then
                            If password = dtr(0).Item("yup_paswrd1") Or password = dtr(0).Item("yup_paswrd2") Then
                                MsgBox("The new password should be different with the previous two ones.")
                                txtUsrPwd.Focus()
                                save_ok = False
                                Exit Sub
                            End If

                            If txtUsrPwd.Text = pwd_bf Then
                                If password = dtr(0).Item("yup_paswrd") Then
                                    password1 = dtr(0).Item("yup_paswrd1")
                                    password2 = dtr(0).Item("yup_paswrd2")
                                Else
                                    password2 = dtr(0).Item("yup_paswrd1")
                                    password1 = dtr(0).Item("yup_paswrd")
                                    txtExpDat.Text = CDate(txtExpDat.Text).AddDays(90)
                                End If
                            End If
                        End If

                        gspStr = "sp_update_SYUSRPRF_1 '" & gsCompany & "','" & _
                                     txtUsrID.Text.Replace("'", "''").Trim & "','" & _
                                     txtUsrNam.Text.Replace("'", "''").Trim & "','" & _
                                     password & "','" & _
                                     password1 & "','" & _
                                     password2 & "','" & _
                                     txtExpDat.Text.Replace("'", "''").Trim & "','" & _
                                     txtMailAd.Text.Replace("'", "''").Trim & "','" & _
                                     gsUsrID & "','" & _
                                     txtAccExp.Text.Replace("'", "''").Trim & "'"

                        If gspStr <> "" Then
                            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                            If rtnLong <> RC_SUCCESS Then
                                MsgBox("Error on loading SYS00002 sp_update_SYUSRPRF_1 : " & rtnStr)
                                flgErr = True
                                Exit Sub
                            End If
                        End If

                        gspStr = ""
                        For Each dr As DataRow In rs_symusrco.Tables("RESULT").Rows

                            If dr.RowState = DataRowState.Modified Then
                                If dr.Item("yuc_status") = "Y" Then
                                    gspStr = "sp_physical_delete_SYMUSRCO '" & gsCompany & "','" & _
                                                dr.Item("yuc_cocde").Replace("'", "''").ToString.Trim & "','" & _
                                                dr.Item("yuc_usrid").Replace("'", "''").ToString.Trim & "'"
                                Else
                                    gspStr = "sp_update_SYMUSRCO '" & gsCompany & "','" & _
                                                dr.Item("yuc_cocde").ToString.Replace("'", "''").Trim & "','" & _
                                                dr.Item("yuc_usrid").ToString.Replace("'", "''").Trim & "','" & _
                                                dr.Item("yco_shtnam").ToString.Replace("'", "''").Trim & "','" & _
                                                dr.Item("yuc_usrgrp").ToString.Replace("'", "''").Trim & "'," & _
                                                dr.Item("yuc_usrank").ToString.Replace("'", "''").Trim & ",'" & _
                                                dr.Item("yuc_supid").ToString.Replace("'", "''").Trim & "','" & _
                                                dr.Item("yuc_rmk").ToString.Replace("'", "''").Trim & "','" & _
                                                IIf(dr.Item("yuc_flgcst").ToString.Trim = "Y", 1, 0) & "','" & _
                                                IIf(dr.Item("yuc_flgcstext").ToString.Replace("'", "''").Trim = "Y", 1, 0) & "','" & _
                                                IIf(dr.Item("yuc_flgrel").ToString.Replace("'", "''").Trim = "Y", 1, 0) & "','" & _
                                                dr.Item("yuc_flgdef").ToString.Replace("'", "''").Trim & "','" & _
                                                gsUsrID & "','SYS00002'"
                                End If

                            ElseIf dr.RowState = DataRowState.Added And Not dr.Item("yuc_status") = "Y" Then

                                If dr.Item("yuc_creusr").ToString.Trim = "" Then
                                    gspStr = "sp_insert_SYMUSRCO '" & gsCompany & "','" & _
                                                dr.Item("yuc_cocde").ToString.Replace("'", "''").Trim & "','" & _
                                                dr.Item("yuc_usrid").ToString.Replace("'", "''").Trim & "','" & _
                                                dr.Item("yco_shtnam").ToString.Replace("'", "''").Trim & "','" & _
                                                dr.Item("yuc_usrgrp").ToString.Replace("'", "''").Trim & "'," & _
                                                dr.Item("yuc_usrank").ToString.Replace("'", "''").Trim & ",'" & _
                                                dr.Item("yuc_supid").ToString.Replace("'", "''").Trim & "','" & _
                                                dr.Item("yuc_rmk").ToString.Replace("'", "''").Trim & "','" & _
                                                IIf(dr.Item("yuc_flgcst").ToString.Trim = "Y", 1, 0) & "','" & _
                                                IIf(dr.Item("yuc_flgcstext").ToString.Trim = "Y", 1, 0) & "','" & _
                                                IIf(dr.Item("yuc_flgrel").ToString.Trim = "Y", 1, 0) & "','" & _
                                                dr.Item("yuc_flgdef").ToString.Replace("'", "''").Trim & "','" & _
                                                gsUsrID & "','SYS00002'"
                                End If
                            End If

                            If gspStr <> "" Then
                                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                If rtnLong <> RC_SUCCESS Then
                                    MsgBox("Error on loading SYS00002 sp_update_SYMUSRCO : " & rtnStr)
                                    flgErr = True
                                    Exit For
                                End If
                                gspStr = ""
                            End If
                        Next

                        gspStr = "sp_update_SYUSRRIGHT_USER '" & gsCompany & "','" & _
                                     txtUsrID.Text.Replace("'", "''").Trim & "','" & _
                                     gsUsrID & "'"

                        If gspStr <> "" Then
                            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                            If rtnLong <> RC_SUCCESS Then
                                MsgBox("Error on loading SYS00002 sp_update_SYUSRRIGHT_USER : " & rtnStr)
                                flgErr = True
                                Exit Sub
                            End If
                        End If

                    End If

                    If Not flgErr Then
                        rs_symusrco.AcceptChanges()
                        Call setStatus("Save")
                    Else
                        save_ok = False
                        rs_symusrco.RejectChanges()
                        MsgBox("Record Not Updated!")
                    End If
                End If
            End If

        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        Dim YN As Integer

        YN = MessageBox.Show("Record will be permanently removed from database. Confirm to Delete?", "Question", MessageBoxButtons.YesNo)

        If YN = Windows.Forms.DialogResult.Yes Then

            gspStr = "sp_physical_delete_SYUSRPRF '" & gsCompany & "','" & _
                        txtUsrID.Text.Replace("'", "''").Trim & "'"
            If gspStr <> "" Then
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading SYS00002 sp_physical_delete_SYUSRPRF : " & rtnStr)
                    Exit Sub
                Else

                    gspStr = "sp_physical_delete_SYMUSRCO '" & gsCompany & "','ALL','" & _
                                txtUsrID.Text.Replace("'", "''").Trim & "'"
                    If gspStr <> "" Then
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading SYS00002 sp_physical_delete_SYMUSRCO : " & rtnStr)
                            Exit Sub
                        Else

                            gspStr = "sp_physical_delete_SYUSRRIGHT_USER '" & gsCompany & "','" & _
                                        txtUsrID.Text.Replace("'", "''").Trim & "'"
                            If gspStr <> "" Then
                                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                If rtnLong <> RC_SUCCESS Then
                                    MsgBox("Error on loading SYS00002 sp_physical_delete_SYUSRRIGHT_USER : " & rtnStr)
                                    Exit Sub
                                Else
                                    Call setStatus("Save")
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub CmdExit_Click() Handles cmdExit.Click
        Me.Close()
    End Sub


    Private Sub DataGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGrid.CellContentClick

    End Sub

    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click

    End Sub
End Class