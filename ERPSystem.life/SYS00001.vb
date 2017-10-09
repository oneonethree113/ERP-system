Public Class SYS00001

    Inherits System.Windows.Forms.Form

    Dim rs_syusrfun As New DataSet
    Dim rs_syusrgrp As New DataSet
    Dim bindSrc As New BindingSource
    Dim save_ok As Boolean
    Dim CanModify As Boolean = True
    Dim AddMode As Boolean = False
    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean

    Dim current_mode As String
    Dim last_mode As String

    Dim fun_short_list As New ArrayList
    Dim fun_long_list As New ArrayList

    Private Sub SYS00001_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Call AccessRight(Me.Name)
            Enq_right_local = Enq_right
            Del_right_local = Del_right

            Call FillComboUsrGrp()
            Call FillComboComGrp()
            Me.txtDesc.Text = ""

            If Not rs_syusrgrp Is Nothing Then
                rs_syusrgrp = Nothing
            End If

            gspStr = "sp_select_SYUSRGRP_access_right '','','',''"
            rtnLong = execute_SQLStatement(gspStr, rs_syusrgrp, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYS00001 sp_select_SYUSRGRP_access_right : " & rtnStr)
            Else
                AddMode = False
                Call setDataRowAttr()
                Call displayGrid()
                Call setStatus("Init")
            End If
            Call Formstartup(Me.Name)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub setDataRowAttr()
        Dim dt As DataTable = rs_syusrgrp.Tables("RESULT")

        If Not dt Is Nothing Then
            For Each dc As DataColumn In dt.Columns
                dc.ReadOnly = False
            Next
            rs_syusrgrp.Tables("RESULT").Columns("DEL").ColumnName = "yug_status"
            For Each dr As DataRow In dt.Rows
                dr.Item("yug_status") = ""
            Next
            rs_syusrgrp.AcceptChanges()
        End If
    End Sub

    Private Sub FillComboUsrGrp()
        Dim rs_usrgrp As New DataSet
        Dim i As Integer

        Try
            gspStr = "sp_select_SYSUSERGRP '" & gsCompany & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_usrgrp, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYS00001 sp_select_SYSUSERGRP : " & rtnStr)
            Else
                Me.cboUsrGrp.Items.Clear()
                Dim dr() As DataRow = rs_usrgrp.Tables("RESULT").Select("")
                For i = 0 To dr.Length - 1
                    Me.cboUsrGrp.Items.Add(dr(i).Item("yug_usrgrp").ToString)
                Next i
            End If
        Finally
            rs_usrgrp = Nothing
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub FillComboComGrp()
        Dim rs_comgrp As New DataSet
        Dim i As Integer

        Try
            gspStr = "sp_select_SYCOMGRP '" & gsCompany & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_comgrp, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYS00001 sp_select_SYCOMGRP : " & rtnStr)
            Else
                Me.cboComGrp.Items.Clear()
                Dim dr() As DataRow = rs_comgrp.Tables("RESULT").Select("")
                For i = 0 To dr.Length - 1
                    Me.cboComGrp.Items.Add(dr(i).Item("compgrp").ToString)
                Next i
            End If
        Finally
            rs_comgrp = Nothing
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub cboUsrGrp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUsrGrp.SelectedIndexChanged
        If last_mode = "DelUsrGrp" And current_mode = "Init" Then
            mmdFind.Enabled = True
            Exit Sub
        End If

        If Not (cboUsrGrp.SelectedItem = "" Or cboUsrGrp.SelectedItem Is Nothing) Then
            Call setStatus("UsrGrp_Selected")
        End If
    End Sub

    Private Sub cboComGrp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboComGrp.SelectedIndexChanged
        If Not (cboUsrGrp.SelectedItem = "" Or cboUsrGrp.SelectedItem Is Nothing) Then
            Call ShowGrdDtl()
        End If
    End Sub

    Private Sub mmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdAdd.Click

        Call setStatus("Add")
        txtUsrGrp.Text = ""
        cboUsrGrp.Items.Clear()
        cboComGrp.SelectedItem = gsCompanyGroup
        AddMode = True
        Call ShowGrdDtl()
        Me.txtUsrGrp.Focus()
    End Sub

    'Delete Button Handle
    Private Sub mmdDelUsrGrp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdDelete.Click
        Dim strUsrGrp, strComGrp As String
        Dim YNC As Integer

        YNC = MessageBox.Show("Confirm to delete this user group?", "Question", MessageBoxButtons.YesNoCancel)

        'Check messagebox condition and permission to delete
        If YNC = Windows.Forms.DialogResult.Yes Then
            If Not Del_right_local Then
                MsgBox("Sorry! You have not right to delete!")
                Exit Sub
            End If
        Else
            Exit Sub
        End If

        'Delete Group End
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            strUsrGrp = cboUsrGrp.SelectedItem.ToString.ToUpper.Replace("'", "''").Trim
            strComGrp = cboComGrp.SelectedItem.ToString.ToUpper.Replace("'", "''").Trim

            gspStr = "sp_physical_delete_SYUSRGRPALL '" & gsCompany & "','" & strUsrGrp & "','" & strComGrp & "'"

            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            MsgBox("Record Deleted!")
        Finally
            setStatus("DelUsrGrp")
            Call SYS00001_Load(Nothing, Nothing)
        End Try
        'Delete Group End

    End Sub

    'Find Button Handle
    Private Sub mmdFind_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdFind.Click
        Call setStatus("Find")
        Call cboUsrGrp_SelectedIndexChanged(Nothing, Nothing)
    End Sub


    Private Sub mmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdClear.Click
        If checkFocus(Me) Then Exit Sub
        Dim YNC As Integer
        Dim flgMod As Boolean = False


        bindSrc.EndEdit()
        For Each dr As DataRow In rs_syusrgrp.Tables("RESULT").Rows
            If dr.RowState = DataRowState.Modified Or dr.RowState = DataRowState.Added Then
                flgMod = True
            End If
        Next

        If flgMod Then
            YNC = MessageBox.Show("Record has been modified. Do you want to save?", "Question", MessageBoxButtons.YesNoCancel)

            If YNC = Windows.Forms.DialogResult.Yes Then
                If Enq_right_local Then
                    Call mmdSave_Click(sender, e)

                    If save_ok Then
                        Call SYS00001_Load(Nothing, Nothing)
                    Else
                        Exit Sub
                    End If
                Else
                    MsgBox("Sorry! You have not right to save!")
                End If
            ElseIf YNC = Windows.Forms.DialogResult.No Then
                Call SYS00001_Load(Nothing, Nothing)

            ElseIf YNC = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
        Else
            Call SYS00001_Load(Nothing, Nothing)

        End If

    End Sub

    Private Sub ShowGrdDtl()
        Dim strUsrGrp, strComGrp As String

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            strUsrGrp = cboUsrGrp.SelectedItem
            strComGrp = cboComGrp.SelectedItem

            If Not rs_syusrfun Is Nothing Then
                rs_syusrfun = Nothing
            End If

            If Not rs_syusrgrp Is Nothing Then
                rs_syusrgrp = Nothing
            End If

            gspStr = "sp_list_SYUSRFUN '" & gsCompany & "','" & gsUsrID & "','" & strComGrp & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_syusrfun, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYS00001 sp_list_SYUSRFUN : " & rtnStr)
            Else
                If AddMode Then
                    gspStr = "sp_select_SYUSRGRP_access_right '" & gsCompany & "','@','@','@'"
                Else
                    gspStr = "sp_select_SYUSRGRP_access_right '" & gsCompany & "','" & strUsrGrp & "','XXXXXXXXXX','" & strComGrp & "'"
                End If
                rtnLong = execute_SQLStatement(gspStr, rs_syusrgrp, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading SYS00001 sp_select_SYUSRGRP_access_right : " & rtnStr)
                Else
                    If rs_syusrgrp.Tables("RESULT").Rows.Count = 0 Then
                        mmdInsRow.Enabled = Enq_right_local
                        mmdDelRow.Enabled = False
                    Else

                        mmdInsRow.Enabled = False
                        mmdDelRow.Enabled = False
                        If Enq_right_local = True Then

                            mmdInsRow.Enabled = Enq_right_local
                            mmdDelRow.Enabled = True
                        End If
                        Me.txtDesc.Text = rs_syusrgrp.Tables("RESULT").Rows(0)("yug_grpdsc").ToString
                    End If

                    mmdAdd.Enabled = False
                    Call setDataRowAttr()
                    Call displayGrid()
                End If
                Call setfunlist()
            End If
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub displayGrid()
        Dim i As Integer
        Dim dv As DataView = rs_syusrgrp.Tables("RESULT").DefaultView

        bindSrc.DataSource = dv
        With DataGrid
            .DataSource = Nothing
            .DataSource = bindSrc
            For i = 0 To .Columns.Count - 1
                Select Case i
                    Case 0
                        .Columns(i).Width = 50
                        .Columns(i).HeaderText = "Del"
                        .Columns(i).ReadOnly = True
                    Case 1
                        .Columns(i).Width = 100
                        .Columns(i).HeaderText = "User Function"
                    Case 2
                        .Columns(i).Width = 300
                        .Columns(i).HeaderText = "Function Description"
                        .Columns(i).ReadOnly = True
                    Case 3
                        .Columns(i).Width = 230
                        .Columns(i).HeaderText = "Access Right"
                    Case Else
                        .Columns(i).Visible = False
                End Select
                .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i
        End With

        If Not dv.Count = 0 Then
            dv.Sort = "yug_upddat desc"
            Dim drv As DataRowView = dv(0)
            Me.StatusBar.Items("lblRight").Text = Format(drv.Item("yug_credat"), "MM/dd/yyyy") & " " & Format(drv.Item("yug_upddat"), "MM/dd/yyyy") & " " & drv.Item("yug_updusr")

            dv.Sort = Nothing
        End If
    End Sub

    Private Sub setStatus(ByVal mode As String)
        setCurrentStatus(mode)

        If mode = "Init" Then
            mmdAdd.Enabled = Enq_right_local
            mmdSave.Enabled = False
            mmdDelete.Enabled = False
            mmdCopy.Enabled = False
            mmdFind.Enabled = False

            mmdClear.Enabled = True
            mmdSearch.Enabled = False

            mmdInsRow.Enabled = False
            mmdDelRow.Enabled = False

            mmdPrint.Enabled = False
            mmdFunction.Enabled = False
            mmdAttach.Enabled = False
            mmdLink.Enabled = False

            mmdExit.Enabled = True






            txtDesc.ReadOnly = True
            txtUsrGrp.Visible = False
            cboUsrGrp.Visible = True
            cboUsrGrp.Enabled = True
            cboComGrp.Enabled = True

            Call ResetDefaultDisp()
            Call SetStatusBar(mode)

        ElseIf mode = "Add" Then

            mmdAdd.Enabled = False
            mmdSave.Enabled = Enq_right_local
            mmdDelete.Enabled = False
            mmdCopy.Enabled = False
            mmdFind.Enabled = False

            mmdClear.Enabled = True
            mmdSearch.Enabled = False

            mmdInsRow.Enabled = Enq_right_local
            mmdDelRow.Enabled = False

            mmdPrint.Enabled = False
            mmdFunction.Enabled = False
            mmdAttach.Enabled = False

            mmdExit.Enabled = True









            txtDesc.ReadOnly = False
            txtUsrGrp.Visible = True
            cboUsrGrp.Visible = False
            cboUsrGrp.Enabled = False
            cboComGrp.Enabled = True
            Call SetStatusBar(mode)

        ElseIf mode = "UsrGrp_Selected" Then

            mmdAdd.Enabled = False
            mmdSave.Enabled = Enq_right_local
            mmdDelete.Enabled = Del_right_local
            mmdCopy.Enabled = False
            mmdFind.Enabled = False

            mmdClear.Enabled = True
            mmdSearch.Enabled = False

            mmdInsRow.Enabled = Enq_right_local
            mmdDelRow.Enabled = Del_right_local

            mmdPrint.Enabled = False
            mmdFunction.Enabled = False
            mmdAttach.Enabled = False

            mmdExit.Enabled = True







            txtDesc.ReadOnly = True
            txtUsrGrp.Visible = False
            cboUsrGrp.Visible = True
            cboUsrGrp.Enabled = False
            cboComGrp.Enabled = True
            cboComGrp.SelectedIndex = -1
            cboComGrp.SelectedItem = gsCompanyGroup

            Call SetStatusBar("Updating")

        ElseIf mode = "InsRow" Then

            mmdAdd.Enabled = False
            mmdSave.Enabled = Enq_right_local
            mmdDelete.Enabled = Del_right_local
            mmdCopy.Enabled = False
            mmdFind.Enabled = False

            mmdClear.Enabled = True
            mmdSearch.Enabled = False

            mmdInsRow.Enabled = Enq_right_local
            mmdDelRow.Enabled = Del_right_local

            mmdPrint.Enabled = False
            mmdFunction.Enabled = False
            mmdAttach.Enabled = False

            mmdExit.Enabled = True





            cboUsrGrp.Enabled = False
            cboComGrp.Enabled = False
            Call SetStatusBar(mode)

        ElseIf mode = "Save" Then
            Call ResetDefaultDisp()
            Call SetStatusBar(mode)
            MsgBox("Record Saved!")
            Call SYS00001_Load(Nothing, Nothing)

        ElseIf mode = "DelRow" Then

            mmdAdd.Enabled = False
            mmdSave.Enabled = Enq_right_local
            mmdDelete.Enabled = Del_right_local
            mmdCopy.Enabled = False
            mmdFind.Enabled = False

            mmdClear.Enabled = True
            mmdSearch.Enabled = False

            mmdInsRow.Enabled = Enq_right_local
            mmdDelRow.Enabled = Del_right_local

            mmdPrint.Enabled = False
            mmdFunction.Enabled = False
            mmdAttach.Enabled = False

            mmdExit.Enabled = True





            cboUsrGrp.Enabled = False
            cboComGrp.Enabled = False
            Call SetStatusBar(mode)
        ElseIf mode = "Find" Then
            'Do nothing
        ElseIf mode = "DelUsrGrp" Then
            'Do nothing
        ElseIf mode = "Clear" Then
            Call ResetDefaultDisp()
            Call SetStatusBar(mode)
        End If

        If Not CanModify Then

            mmdAdd.Enabled = False
            mmdSave.Enabled = False
            mmdDelete.Enabled = False
            mmdCopy.Enabled = False
            mmdFind.Enabled = False

            mmdClear.Enabled = True
            mmdSearch.Enabled = False

            mmdInsRow.Enabled = False
            mmdDelRow.Enabled = False

            mmdPrint.Enabled = False
            mmdFunction.Enabled = False
            mmdAttach.Enabled = False

            mmdExit.Enabled = True


            Call ResetDefaultDisp()
            Call SetStatusBar("ReadOnly")
        End If
    End Sub

    Private Sub setCurrentStatus(ByVal mode As String)
        last_mode = current_mode
        current_mode = mode
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
        ElseIf mode = "Add" Then
            Me.StatusBar.Items("lblLeft").Text = "Add Record"
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

        If iCol = 1 Then
            For Each dr As DataRow In rs_syusrfun.Tables("RESULT").Rows
                cboCell.Items.Add(dr.Item("yuf_usrfun").ToString.Trim)
            Next
        ElseIf iCol = 3 Then
            cboCell.Items.Add("MWD - Maintenace with Delete")
            cboCell.Items.Add("MOD - Maintenance without Delete")
            cboCell.Items.Add("ENQ - Enquiry Only")
        End If
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
                ' User has changed the function
                If iCol = 1 Then
                    Me.DataGrid.Rows(iRow).Cells(iCol).Value = strSelItem
                    Me.DataGrid.Rows(iRow).Cells(iCol + 1).Value = fun_long_list(cboBox.SelectedIndex)
                    'Me.DataGrid.Rows(iRow).Cells(iCol + 1).Value = rs_syusrfun.Tables("RESULT").Select("yuf_usrfun = '" & strSelItem & "'")(0).Item("yuf_fundsc").ToString
                ElseIf iCol = 3 Then
                    Me.DataGrid.Rows(iRow).Cells(iCol).Value = strSelItem
                End If
                AddHandler cboBox.SelectedIndexChanged, AddressOf cboOpt_SelectedIndexChanged

            End If
        End If
    End Sub

    Private Sub cboOpt_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cbobox As ComboBox = CType(sender, ComboBox)
        If DataGrid.CurrentCell.ColumnIndex = 1 Then
            If Not cbobox Is Nothing AndAlso Not cbobox.SelectedItem Is Nothing Then
                Dim tmp_index = cbobox.SelectedIndex
                cbobox.DataSource = fun_short_list
                cbobox.SelectedIndex = tmp_index

            End If
        End If
    End Sub

    Private Sub cboOpt_click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cbobox As ComboBox = CType(sender, ComboBox)
        If DataGrid.CurrentCell.ColumnIndex = 1 Then
            If Not cbobox Is Nothing AndAlso Not cbobox.SelectedItem Is Nothing Then
                Dim tmp_index = cbobox.SelectedIndex
                cbobox.DataSource = fun_long_list
                cbobox.SelectedIndex = tmp_index
                cbobox.Width = 400
            End If
        End If
    End Sub

    Private Sub DataGrid_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGrid.DataError

    End Sub


    Private Sub DataGrid_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGrid.EditingControlShowing

        If DataGrid.CurrentCell.ColumnIndex = 1 Or DataGrid.CurrentCell.ColumnIndex = 3 Then
            If TypeOf (e.Control) Is DataGridViewComboBoxEditingControl Then
                Dim cboBox As ComboBox = CType(e.Control, ComboBox)
                If Not cboBox Is Nothing Then
                    If DataGrid.CurrentCell.ColumnIndex = 1 Then
                        RemoveHandler cboBox.SelectedIndexChanged, AddressOf cboOpt_SelectedIndexChanged
                        RemoveHandler cboBox.SelectionChangeCommitted, AddressOf cboOpt_SelectionChangeCommitted
                        RemoveHandler cboBox.Click, AddressOf cboOpt_click
                        Dim tmp_index = cboBox.SelectedIndex
                        cboBox.DataSource = fun_long_list
                        cboBox.SelectedIndex = tmp_index
                        cboBox.Width = 400
                        AddHandler cboBox.SelectedIndexChanged, AddressOf cboOpt_SelectedIndexChanged
                        AddHandler cboBox.SelectionChangeCommitted, AddressOf cboOpt_SelectionChangeCommitted
                        AddHandler cboBox.Click, AddressOf cboOpt_click
                    ElseIf DataGrid.CurrentCell.ColumnIndex = 3 Then
                        RemoveHandler cboBox.SelectedIndexChanged, AddressOf cboOpt_SelectedIndexChanged
                        AddHandler cboBox.SelectedIndexChanged, AddressOf cboOpt_SelectedIndexChanged
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub DataGrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGrid.CellClick
        Dim row As DataGridViewRow = DataGrid.CurrentRow

        If Not e.RowIndex = -1 Then

            If e.ColumnIndex = 0 Then
                ' Toggle Delete
                If Not row.Cells("yug_usrfun").Value.ToString = "" Then
                    Call mmdDelRow_Click(sender, e)
                End If

            ElseIf e.ColumnIndex = 1 Or e.ColumnIndex = 3 Then
                If row.Cells("yug_status").Value.ToString = "" Then
                    If TypeOf (DataGrid.CurrentCell) Is DataGridViewTextBoxCell Then
                        createComboBoxCell(DataGrid.CurrentCell)
                        DataGrid.BeginEdit(True)
                        mmdSave.Enabled = Enq_right_local
                    ElseIf TypeOf (DataGrid.CurrentCell) Is DataGridViewComboBoxCell And e.ColumnIndex = 1 Then
                        'cboOpt_click(sender, Nothing)
                    End If
                Else
                    row.Cells(e.ColumnIndex).ReadOnly = True
                End If

            End If
        End If
    End Sub

    Private Sub DataGrid_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DataGrid.CellValidating
        Dim row As DataGridViewRow = DataGrid.CurrentRow
        Dim strNewVal As String

        strNewVal = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim

        If row.Cells(e.ColumnIndex).IsInEditMode Then

            If e.ColumnIndex = 1 Then
                If Not chkGrdCellValue(row.Cells("yug_usrfun"), "String", 10) Then
                    e.Cancel = True
                Else
                    For Each drr As DataGridViewRow In DataGrid.Rows
                        If drr.Index <> e.RowIndex Then
                            If drr.Cells("yug_usrfun").Value.ToString.ToUpper = strNewVal.ToUpper Then
                                MsgBox("Duplicated function code!")
                                e.Cancel = True
                                Exit For
                            End If
                        End If
                    Next
                End If
            End If

            If e.ColumnIndex = 3 Then
                If Not chkGrdCellValue(row.Cells("yug_assrig"), "String", 40) Then
                    e.Cancel = True
                End If
            End If
        End If

    End Sub

    Private Sub mmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdInsRow.Click
        Dim dt As DataTable
        Dim dr As DataRow

        dt = rs_syusrgrp.Tables("RESULT")
        For Each dr In dt.Rows
            If dr.Item("yug_usrfun").ToString.Trim = "" Then
                MsgBox("Please input function code.")
                Exit Sub
            End If
        Next

        dr = dt.NewRow
        dr.Item("yug_status") = ""
        dt.Rows.Add(dr)

        For Each drr As DataGridViewRow In DataGrid.Rows
            If IsDBNull(drr.Cells(1).Value) Then
                DataGrid.CurrentCell = drr.Cells(1)
                createComboBoxCell(DataGrid.CurrentCell)
                DataGrid.BeginEdit(True)
            End If
        Next
        Call setStatus("InsRow")
    End Sub

    Private Sub mmdDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdDelRow.Click
        Dim row As DataGridViewRow = DataGrid.CurrentRow
        Dim cellStyle As New DataGridViewCellStyle

        ' Toggle Delete
        If Not row Is Nothing Then
            If Not row.Cells("yug_usrfun").Value.ToString = "" Then
                If row.Cells("yug_status").Value.ToString = "" Then
                    row.Cells("yug_status").Value = "Y"
                    cellStyle.BackColor = Color.LightBlue
                Else
                    row.Cells("yug_status").Value = ""
                    cellStyle.BackColor = Nothing
                End If
                row.DataGridView.CurrentRow.DefaultCellStyle = cellStyle
                Call setStatus("DelRow")
            End If
        End If

    End Sub

    Private Sub mmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mmdSave.Click
        If checkFocus(Me) Then Exit Sub
        Dim strUsrGrp, strComGrp As String
        Dim flgErr As Boolean = False
        Dim flgReAct As Boolean = False

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            save_ok = True
            bindSrc.EndEdit()
            For Each row As DataGridViewRow In DataGrid.Rows

                If row.Cells("yug_status").Value.ToString = "" Then

                    If Not chkGrdCellValue(row.Cells("yug_usrfun"), "String", 10) Then
                        save_ok = False
                        flgReAct = True

                    ElseIf Not chkGrdCellValue(row.Cells("yug_assrig"), "String", 40) Then
                        save_ok = False
                        flgReAct = True

                    Else
                        If row.Cells("yug_credat").Value.ToString = "" Then
                            For Each drr As DataGridViewRow In DataGrid.Rows
                                If drr.Index <> row.Index Then
                                    If drr.Cells("yug_usrfun").Value.ToString.ToUpper = row.Cells("yug_usrfun").Value.ToString.ToUpper And _
                                       drr.Cells("yug_status").Value.ToString = "" Then

                                        MsgBox("Duplicated function code " & drr.Cells("yug_usrfun").Value.ToString & "!")
                                        save_ok = False
                                        flgReAct = True
                                        row.DataGridView.CurrentCell = row.Cells("yug_usrfun")
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

                If AddMode Then
                    If txtUsrGrp.Text = "" Then
                        MsgBox("User code is empty, please input again!")
                        save_ok = False
                    ElseIf txtDesc.Text = "" Then
                        MsgBox("Description is empty, please input again!")
                        save_ok = False
                    ElseIf DataGrid.Rows.Count = 0 Then
                        MsgBox("No Records Found")
                        save_ok = False
                    End If
                End If

                If save_ok Then

                    gspStr = ""

                    If AddMode Then
                        strUsrGrp = txtUsrGrp.Text.ToUpper.Replace("'", "''").Trim
                    Else
                        strUsrGrp = cboUsrGrp.SelectedItem.ToString.ToUpper.Replace("'", "''").Trim
                    End If
                    strComGrp = cboComGrp.SelectedItem.ToString.ToUpper.Replace("'", "''").Trim

                    For Each dr As DataRow In rs_syusrgrp.Tables("RESULT").Rows
                        If dr.RowState = DataRowState.Modified Then

                            If dr.Item("yug_status") = "Y" Then
                                gspStr = "sp_physical_delete_SYUSRGRP '" & gsCompany & "','" & _
                                            strUsrGrp & "','" & _
                                            dr.Item("yug_usrfun").ToString.Replace("'", "''").Trim & "','" & _
                                            strComGrp & "'"
                            Else
                                gspStr = "sp_update_SYUSRGRP '" & gsCompany & "','" & _
                                            strUsrGrp & "','" & _
                                            dr.Item("yug_usrfun").ToString.Replace("'", "''").Trim & "','" & _
                                            dr.Item("yug_fundsc").ToString.Replace("'", "''").Trim & "','" & _
                                            dr.Item("yug_assrig").ToString.Replace("'", "''").Trim & "','" & _
                                            dr.Item("yug_usrfun", DataRowVersion.Original).ToString.Replace("'", "''").Trim & "','" & _
                                            gsUsrID & "','" & _
                                            strComGrp & "'"
                            End If
                        ElseIf dr.RowState = DataRowState.Added And Not dr.Item("yug_status") = "Y" Then

                            If dr.Item("yug_credat").ToString.Trim = "" Then
                                gspStr = "sp_insert_SYUSRGRP '" & gsCompany & "','" & _
                                                strUsrGrp & "','" & _
                                                dr.Item("yug_usrfun").ToString.Replace("'", "''").Trim & "','" & _
                                                dr.Item("yug_fundsc").ToString.Replace("'", "''").Trim & "','" & _
                                                dr.Item("yug_assrig").ToString.Replace("'", "''").Trim & "','" & _
                                                gsUsrID & "','" & _
                                                Me.txtDesc.Text.Replace("'", "''").Trim & "','" & _
                                                strComGrp & "'"
                            End If
                        End If

                        If gspStr <> "" Then
                            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                            If rtnLong <> RC_SUCCESS Then
                                MsgBox("Error on loading SYS00001 sp_update_SYUSRGRP : " & rtnStr)
                                flgErr = True
                                Exit For
                            End If
                            gspStr = ""
                        End If
                    Next

                    If Not flgErr Then
                        rs_syusrgrp.AcceptChanges()
                        Call setStatus("Save")
                    Else
                        save_ok = False
                        rs_syusrgrp.RejectChanges()
                        MsgBox("Record Not Updated!")
                    End If
                End If
            End If

        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub SYS00001_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If checkFocus(Me) Then Exit Sub
        Dim YNC As Integer
        Dim flgMod As Boolean = False

        bindSrc.EndEdit()
        For Each dr As DataRow In rs_syusrgrp.Tables("RESULT").Rows
            If dr.RowState = DataRowState.Modified Or dr.RowState = DataRowState.Added Then
                flgMod = True
            End If
        Next

        If flgMod Then
            YNC = MessageBox.Show("Record has been modified. Do you want to save before exit?", "Question", MessageBoxButtons.YesNoCancel)

            If YNC = Windows.Forms.DialogResult.Yes Then
                If Enq_right_local Then
                    Call mmdSave_Click(sender, e)

                    If save_ok Then
                        e.Cancel = False
                    Else
                        e.Cancel = True
                    End If
                Else
                    MsgBox("Sorry! You have not right to save!")
                End If
            ElseIf YNC = Windows.Forms.DialogResult.No Then
                e.Cancel = False
            ElseIf YNC = Windows.Forms.DialogResult.Cancel Then
                e.Cancel = True
            End If
        End If

    End Sub


    Private Sub setfunlist()
        Dim tmp_string_short, tmp_string_long As String
        fun_short_list.Clear()
        fun_long_list.Clear()
        For Each dr As DataRow In rs_syusrfun.Tables("RESULT").Rows
            tmp_string_short = dr.Item("yuf_usrfun").ToString.Trim
            tmp_string_long = tmp_string_short + " - " + dr.Item("yuf_fundsc").ToString.Trim
            fun_short_list.Add(tmp_string_short)
            fun_long_list.Add(tmp_string_long)
        Next
    End Sub


    Private Sub MmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdExit.Click
        If checkFocus(Me) Then Exit Sub

        Me.Close()
    End Sub
End Class

