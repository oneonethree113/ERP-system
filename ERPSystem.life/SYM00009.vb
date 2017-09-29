Public Class SYM00009
    Inherits System.Windows.Forms.Form

    Dim rs_syconftr As New DataSet
    Dim rs_sycode As New DataSet
    Dim bindSrc As New BindingSource
    Dim save_ok As Boolean
    Dim CanModify As Boolean = True
    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean

    Private Sub SYM00009_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Call AccessRight(Me.Name)
            Enq_right_local = Enq_right
            Del_right_local = Del_right

            ' Get conversion code list
            gspStr = "sp_select_SYSETINF '" & gsCompany & "','05'"
            rtnLong = execute_SQLStatement(gspStr, rs_sycode, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00009 sp_select_SYSETINF : " & rtnStr)
            Else
                gspStr = "sp_select_SYCONFTR '" & gsCompany & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_syconftr, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading SYM00009 sp_select_SYCONFTR : " & rtnStr)
                Else
                    Call setDataRowAttr()
                    Call displayGrid()
                    Call setStatus("Init")
                End If
            End If
            Call Formstartup(Me.Name)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub setDataRowAttr()
        Dim dt As DataTable = rs_syconftr.Tables("RESULT")

        If Not dt Is Nothing Then
            For Each dc As DataColumn In dt.Columns
                dc.ReadOnly = False
            Next
            For Each dr As DataRow In dt.Rows
                dr.Item("ycf_status") = ""
                dr.Item("ycf_value") = CDbl(dr.Item("ycf_value"))


            Next
            rs_syconftr.AcceptChanges()
        End If
    End Sub




    Private Sub displayGrid()
        Dim i As Integer
        Dim dv As DataView = rs_syconftr.Tables("RESULT").DefaultView
        bindSrc.DataSource = dv

        With DataGrid
            .DataSource = Nothing
            .DataSource = bindSrc

            For i = 0 To .Columns.Count - 1
                Select Case i
                    Case 0
                        .Columns(i).Width = 40
                        .Columns(i).HeaderText = "Del"
                        .Columns(i).ReadOnly = True
                    Case 2
                        .Columns(i).Width = 100
                        .Columns(i).HeaderText = "Code 1"
                    Case 3
                        .Columns(i).Width = 211
                        .Columns(i).HeaderText = "Description"
                        .Columns(i).ReadOnly = True
                    Case 4
                        .Columns(i).Width = 100
                        .Columns(i).HeaderText = "Code 2"
                    Case 5
                        .Columns(i).Width = 211
                        .Columns(i).HeaderText = "Description"
                        .Columns(i).ReadOnly = True
                    Case 7
                        .Columns(i).Width = 120
                        .Columns(i).HeaderText = "Code 2 to Code 1"
                    Case 8
                        .Columns(i).Width = 90
                        .Columns(i).HeaderText = "System Type"
                        .Columns(i).ReadOnly = True
                    Case Else
                        .Columns(i).Visible = False
                End Select
                .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersHeight = 28
        End With

        If Not dv.Count = 0 Then
            dv.Sort = "ycf_upddat desc"
            Dim drv As DataRowView = dv(0)
            Me.StatusBar.Items("lblRight").Text = Format(drv.Item("ycf_credat"), "MM/dd/yyyy") & " " & Format(drv.Item("ycf_upddat"), "MM/dd/yyyy") & " " & drv.Item("ycf_updusr")

            dv.Sort = Nothing
        End If
    End Sub

    Private Sub setStatus(ByVal mode As String)

        If mode = "Init" Then
            'cmdAdd.Enabled = False
            'cmdSave.Enabled = False
            'cmdDelete.Enabled = False
            'cmdCopy.Enabled = False
            'cmdFind.Enabled = False
            'cmdInsRow.Enabled = Enq_right_local
            'cmdDelRow.Enabled = Del_right_local
            'cmdExit.Enabled = True
            'cmdClear.Enabled = False
            'cmdSearch.Enabled = False

            mmdAdd.Enabled = False
            mmdSave.Enabled = False
            mmdDelete.Enabled = False
            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdInsRow.Enabled = Enq_right_local
            mmdDelRow.Enabled = Del_right_local
            mmdExit.Enabled = True
            mmdClear.Enabled = False
            mmdSearch.Enabled = False

            mmdPrint.Enabled = False
            mmdAttach.Enabled = False
            mmdFunction.Enabled = False
            mmdLink.Enabled = False

            'cmdFirst.Enabled = False
            'cmdLast.Enabled = False
            'cmdNext.Enabled = False
            'cmdPrevious.Enabled = False

            Call ResetDefaultDisp()
            Call SetStatusBar(mode)

        ElseIf mode = "InsRow" Then
            'cmdCopy.Enabled = False
            'cmdFind.Enabled = False
            'cmdSave.Enabled = Enq_right_local
            'cmdDelRow.Enabled = Del_right_local

            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdSave.Enabled = Enq_right_local
            mmdDelRow.Enabled = Del_right_local

            mmdPrint.Enabled = False
            mmdAttach.Enabled = False
            mmdFunction.Enabled = False
            mmdLink.Enabled = False

            Call SetStatusBar(mode)

        ElseIf mode = "Save" Then
            Call ResetDefaultDisp()
            Call SetStatusBar(mode)
            MsgBox("Record Saved!")
            Call SYM00009_Load(Nothing, Nothing)

        ElseIf mode = "DelRow" Then
            'cmdCopy.Enabled = False
            'cmdFind.Enabled = False
            'cmdSave.Enabled = Enq_right_local
            'cmdDelRow.Enabled = Del_right_local

            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdSave.Enabled = Enq_right_local
            mmdDelRow.Enabled = Del_right_local

            mmdPrint.Enabled = False
            mmdAttach.Enabled = False
            mmdFunction.Enabled = False
            mmdLink.Enabled = False

            Call SetStatusBar(mode)

        ElseIf mode = "Clear" Then
            Call ResetDefaultDisp()
            Call SetStatusBar(mode)
        End If

        If Not CanModify Then
            'cmdAdd.Enabled = False
            'cmdSave.Enabled = False
            'cmdDelete.Enabled = False
            'cmdInsRow.Enabled = False
            'cmdDelRow.Enabled = False

            mmdAdd.Enabled = False
            mmdSave.Enabled = False
            mmdDelete.Enabled = False
            mmdInsRow.Enabled = False
            mmdDelRow.Enabled = False

            mmdPrint.Enabled = False
            mmdAttach.Enabled = False
            mmdFunction.Enabled = False
            mmdLink.Enabled = False

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

        For Each dr As DataRow In rs_sycode.Tables("RESULT").Rows
            cboCell.Items.Add(dr.Item("ysi_cde").ToString.Trim)
        Next
        cboCell.DropDownWidth = 150
        cboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

        dgView.Rows(iRow).Cells(iCol) = cboCell
        dgView.Rows(iRow).Cells(iCol).ReadOnly = False
    End Sub

    Private Sub cboCode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim iRow As Integer = DataGrid.CurrentCell.RowIndex
        Dim iCol As Integer = DataGrid.CurrentCell.ColumnIndex
        Dim strSelItem As String

        If TypeOf (Me.DataGrid.CurrentCell) Is DataGridViewComboBoxCell Then
            Dim cboBox As ComboBox = CType(sender, ComboBox)
            If Not cboBox Is Nothing AndAlso Not cboBox.SelectedItem Is Nothing Then

                strSelItem = cboBox.SelectedItem.ToString
                RemoveHandler cboBox.SelectedIndexChanged, AddressOf cboCode_SelectedIndexChanged
                ' User has changed the code
                If iCol = 2 Then
                    Me.DataGrid.Rows(iRow).Cells(iCol).Value = strSelItem
                    Me.DataGrid.Rows(iRow).Cells(iCol + 1).Value = rs_sycode.Tables("RESULT").Select("ysi_cde = '" & strSelItem & "'")(0).Item("ysi_dsc").ToString
                ElseIf iCol = 4 Then
                    Me.DataGrid.Rows(iRow).Cells(iCol).Value = strSelItem
                    Me.DataGrid.Rows(iRow).Cells(iCol + 1).Value = rs_sycode.Tables("RESULT").Select("ysi_cde = '" & strSelItem & "'")(0).Item("ysi_dsc").ToString
                End If
                AddHandler cboBox.SelectedIndexChanged, AddressOf cboCode_SelectedIndexChanged

            End If
        End If
    End Sub

    Private Sub DataGrid_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGrid.EditingControlShowing

        If DataGrid.CurrentCell.ColumnIndex = 2 Or DataGrid.CurrentCell.ColumnIndex = 4 Then
            If TypeOf (DataGrid.CurrentCell) Is DataGridViewComboBoxCell Then
                Dim cboBox As ComboBox = CType(e.Control, ComboBox)
                If Not cboBox Is Nothing Then
                    RemoveHandler cboBox.SelectedIndexChanged, AddressOf cboCode_SelectedIndexChanged
                    AddHandler cboBox.SelectedIndexChanged, AddressOf cboCode_SelectedIndexChanged
                End If
            End If
        End If
    End Sub

    Private Sub DataGrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGrid.CellClick
        Dim row As DataGridViewRow = DataGrid.CurrentRow

        If Enq_right_local = False Then
            Exit Sub
        End If

        If Not e.RowIndex = -1 Then

            If e.ColumnIndex = 0 Then
                ' Toggle Delete
                If Not row.Cells("ycf_code1").Value.ToString = "" Then
                    Call mmdDelRow_Click(sender, e)
                End If

            ElseIf e.ColumnIndex = 2 Or e.ColumnIndex = 4 Then
                If row.Cells("ycf_credat").Value.ToString = "" And row.Cells("ycf_status").Value.ToString = "" Then
                    If TypeOf (DataGrid.CurrentCell) Is DataGridViewTextBoxCell Then
                        createComboBoxCell(DataGrid.CurrentCell)
                        DataGrid.BeginEdit(True)
                        'cmdSave.Enabled = Enq_right_local
                        mmdSave.Enabled = Enq_right_local
                    End If
                Else
                    row.Cells(e.ColumnIndex).ReadOnly = True
                End If

            ElseIf e.ColumnIndex = 7 Then
                DataGrid.BeginEdit(True)
                'cmdSave.Enabled = Enq_right_local
                mmdSave.Enabled = Enq_right_local

            ElseIf e.ColumnIndex = 8 Then
                If row.Cells("ycf_systyp").Value.ToString = "N" Then
                    row.Cells("ycf_systyp").Value = "Y"
                Else
                    row.Cells("ycf_systyp").Value = "N"
                End If
                'cmdSave.Enabled = Enq_right_local
                mmdSave.Enabled = Enq_right_local
            End If
        End If

    End Sub

    Private Sub DataGrid_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DataGrid.CellValidating
        Dim row As DataGridViewRow = DataGrid.CurrentRow
        Dim strNewVal As String

        strNewVal = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim
        If row.Cells(e.ColumnIndex).IsInEditMode Then

            If e.ColumnIndex = 2 Then
                If Not chkGrdCellValue(row.Cells("ycf_code1"), "String", 6) Then
                    e.Cancel = True
                Else
                    For Each drr As DataGridViewRow In DataGrid.Rows
                        If drr.Index <> e.RowIndex Then
                            If drr.Cells("ycf_code2").Value.ToString = row.Cells("ycf_code2").Value.ToString And drr.Cells("ycf_code1").Value.ToString = strNewVal Then
                                MsgBox("Duplicated conversion code!")
                                e.Cancel = True
                                Exit For
                            End If
                        End If
                    Next
                End If
            End If

            If e.ColumnIndex = 4 Then
                If Not chkGrdCellValue(row.Cells("ycf_code2"), "String", 6) Then
                    e.Cancel = True
                Else
                    For Each drr As DataGridViewRow In DataGrid.Rows
                        If drr.Index <> e.RowIndex Then
                            If drr.Cells("ycf_code1").Value.ToString = row.Cells("ycf_code1").Value And drr.Cells("ycf_code2").Value.ToString = strNewVal Then
                                MsgBox("Duplicated conversion code!")
                                e.Cancel = True
                                Exit For
                            End If
                        End If
                    Next
                End If
            End If

            If e.ColumnIndex = 7 Then
                If Not chkGrdCellValue(row.Cells("ycf_value"), "+Numeric") Then
                    e.Cancel = True
                End If
            End If
        End If

    End Sub

    Private Sub mmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdInsRow.Click
        Dim dt As DataTable
        Dim dr As DataRow

        dt = rs_syconftr.Tables("RESULT")
        For Each dr In dt.Rows
            If dr.Item("ycf_code1").ToString.Trim = "" Then
                MsgBox("Please input conversion code.")
                Exit Sub
            End If
        Next

        dr = dt.NewRow
        dr.Item("ycf_status") = ""
        dr.Item("ycf_value") = "0"
        dr.Item("ycf_systyp") = "N"
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

    Private Sub mmdDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdDelRow.Click
        Dim row As DataGridViewRow = DataGrid.CurrentRow
        Dim cellStyle As New DataGridViewCellStyle

        ' Toggle Delete
        If Not row Is Nothing Then
            If Not row.Cells("ycf_code1").Value.ToString = "" Then
                If row.Cells("ycf_status").Value.ToString = "" Then
                    row.Cells("ycf_status").Value = "Y"
                    cellStyle.BackColor = Color.LightBlue
                Else
                    row.Cells("ycf_status").Value = ""
                    cellStyle.BackColor = Nothing
                End If
                row.DataGridView.CurrentRow.DefaultCellStyle = cellStyle
            End If
            Call setStatus("DelRow")
        End If

    End Sub

    Private Sub mmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mmdSave.Click
        If checkFocus(Me) Then Exit Sub
        Dim flgErr As Boolean = False
        Dim flgReAct As Boolean = False

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            save_ok = True
            bindSrc.EndEdit()
            For Each row As DataGridViewRow In DataGrid.Rows

                If row.Cells("ycf_status").Value.ToString = "" Then

                    If Not chkGrdCellValue(row.Cells("ycf_code1"), "String", 6) Then
                        save_ok = False
                        flgReAct = True

                    ElseIf Not chkGrdCellValue(row.Cells("ycf_code2"), "String", 6) Then
                        save_ok = False
                        flgReAct = True

                    ElseIf Not chkGrdCellValue(row.Cells("ycf_value"), "+Numeric") Then
                        save_ok = False

                    Else
                        If row.Cells("ycf_credat").Value.ToString = "" Then
                            For Each drr As DataGridViewRow In DataGrid.Rows
                                If drr.Index <> row.Index Then
                                    If drr.Cells("ycf_code2").Value.ToString = row.Cells("ycf_code2").Value.ToString And _
                                       drr.Cells("ycf_code1").Value.ToString = row.Cells("ycf_code1").Value.ToString And _
                                       drr.Cells("ycf_status").Value.ToString = "" Then

                                        MsgBox("Duplicated conversion code " & drr.Cells("ycf_code2").Value.ToString & "!")
                                        save_ok = False
                                        flgReAct = True
                                        row.DataGridView.CurrentCell = row.Cells("ycf_code2")
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
                    Exit Sub
                End With
            Else
                gspStr = ""
                For Each dr As DataRow In rs_syconftr.Tables("RESULT").Rows

                    If dr.RowState = DataRowState.Modified Then
                        If dr.Item("ycf_status") = "Y" Then
                            gspStr = "sp_physical_delete_SYCONFTR '" & gsCompany & "','" & _
                                        dr.Item("ycf_code1").ToString.ToUpper.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ycf_code2").ToString.ToUpper.Replace("'", "''").Trim & "','" & _
                                        gsUsrID & "'"
                        Else

                            gspStr = "sp_update_SYCONFTR '" & gsCompany & "','" & _
                                        dr.Item("ycf_code1").ToString.ToUpper.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ycf_dsc1").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ycf_code2").ToString.ToUpper.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ycf_dsc2").ToString.Replace("'", "''").Trim & "'," & _
                                        dr.Item("ycf_value").ToString.Replace("'", "''").Trim & ",'" & _
                                        dr.Item("ycf_systyp").ToString.Replace("'", "''").Trim & "','" & _
                                        gsUsrID & "'"
                        End If
                    ElseIf dr.RowState = DataRowState.Added And Not dr.Item("ycf_status") = "Y" Then

                        If dr.Item("ycf_credat").ToString.Trim = "" Then
                            gspStr = "sp_insert_SYCONFTR '" & gsCompany & "','" & _
                                        dr.Item("ycf_code1").ToString.ToUpper.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ycf_dsc1").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ycf_code2").ToString.ToUpper.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ycf_dsc2").ToString.Replace("'", "''").Trim & "'," & _
                                        dr.Item("ycf_value").ToString.Replace("'", "''").Trim & ",'" & _
                                        dr.Item("ycf_systyp").ToString.Replace("'", "''").Trim & "','" & _
                                        gsUsrID & "'"
                        End If
                    End If

                    If gspStr <> "" Then
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading SYM00009 sp_update_SYCONFTR : " & rtnStr)
                            flgErr = True
                            Exit For
                        End If
                        gspStr = ""
                    End If
                Next

                If Not flgErr Then
                    rs_syconftr.AcceptChanges()
                    Call setStatus("Save")
                Else
                    save_ok = False
                    rs_syconftr.RejectChanges()
                    MsgBox("Record Not Updated!")
                End If
            End If

        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub SYM00009_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim YNC As Integer
        Dim flgMod As Boolean = False

        bindSrc.EndEdit()
        For Each dr As DataRow In rs_syconftr.Tables("RESULT").Rows
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

    Private Sub mmdExit_Click() Handles mmdExit.Click
        If checkFocus(Me) Then Exit Sub
        Me.Close()
    End Sub

    Private Sub mmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdExit.Click

    End Sub
End Class