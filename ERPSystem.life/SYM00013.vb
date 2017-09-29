Public Class SYM00013

    Dim rs_sydis As New DataSet
    Dim rs_syprm As New DataSet
    Dim bindSrcD As New BindingSource
    Dim bindSrcP As New BindingSource
    Dim save_ok As Boolean
    Dim CanModify As Boolean = True
    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean

    Private Sub SYM00013_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Call AccessRight(Me.Name)
            Enq_right_local = Enq_right
            Del_right_local = Del_right

            gspStr = "sp_select_SYDISPRM '" & gsCompany & "','D'"
            rtnLong = execute_SQLStatement(gspStr, rs_sydis, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00013 sp_select_SYDISPRM : " & rtnStr)
                Exit Sub
            End If

            gspStr = "sp_select_SYDISPRM '" & gsCompany & "','P'"
            rtnLong = execute_SQLStatement(gspStr, rs_syprm, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00013 sp_select_SYDISPRM : " & rtnStr)
                Exit Sub
            End If

            Call setDataRowAttr()
            Call displayGridTab(rs_sydis.Tables("RESULT").DefaultView, bindSrcD, Me.DataGridDis)
            Call displayGridTab(rs_syprm.Tables("RESULT").DefaultView, bindSrcP, Me.DataGridPrm)
            Call setStatus("Init")
            Call Formstartup(Me.Name)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub setDataRowAttr()

        For Each dc As DataColumn In rs_sydis.Tables("RESULT").Columns
            dc.ReadOnly = False
        Next
        For Each dr As DataRow In rs_sydis.Tables("RESULT").Rows
            dr.Item("ydp_status") = ""
        Next
        rs_sydis.AcceptChanges()


        For Each dc As DataColumn In rs_syprm.Tables("RESULT").Columns
            dc.ReadOnly = False
        Next
        For Each dr As DataRow In rs_syprm.Tables("RESULT").Rows
            dr.Item("ydp_status") = ""
        Next
        rs_syprm.AcceptChanges()

    End Sub

    Private Sub displayGridTab(ByVal dv As DataView, ByVal bindSrc As BindingSource, ByVal dgView As DataGridView)
        Dim i As Integer
        Me.StatusBar.Items("lblRight").Text = ""
        bindSrc.DataSource = dv

        With dgView
            .DataSource = Nothing
            .DataSource = bindSrc
            For i = 0 To .Columns.Count - 1
                Select Case i
                    Case 0
                        .Columns(i).Width = 40
                        .Columns(i).HeaderText = "Del"
                        .Columns(i).ReadOnly = True
                    Case 3
                        .Columns(i).Width = 45
                        .Columns(i).HeaderText = "Code"
                    Case 4
                        .Columns(i).Width = 45
                        .Columns(i).HeaderText = "Status"
                        .Columns(i).ReadOnly = True
                    Case 5
                        .Columns(i).Width = 250
                        .Columns(i).HeaderText = "Description"
                        .Columns(i).ReadOnly = False
                    Case 6
                        .Columns(i).Width = 75
                        .Columns(i).HeaderText = "Account"
                        .Columns(i).ReadOnly = False
                    Case 7
                        .Columns(i).Width = 105
                        .Columns(i).HeaderText = "Profit Ctr (Floral)"
                        .Columns(i).ReadOnly = False
                    Case 8
                        .Columns(i).Width = 105
                        .Columns(i).HeaderText = "Profit Ctr (X'mas)"
                        .Columns(i).ReadOnly = False
                    Case Else
                        .Columns(i).Visible = False
                End Select
                .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i
        End With

        If Not dv.Count = 0 Then
            dv.Sort = "ydp_upddat desc"
            Dim drv As DataRowView = dv(0)
            Me.StatusBar.Items("lblRight").Text = Format(drv.Item("ydp_credat"), "MM/dd/yyyy") & " " & Format(drv.Item("ydp_upddat"), "MM/dd/yyyy") & " " & drv.Item("ydp_updusr")

            dv.Sort = Nothing
        End If
    End Sub

    Private Sub setStatus(ByVal mode As String)

        If mode = "Init" Then

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

            Call ResetDefaultDisp()
            Call SetStatusBar(mode)

        ElseIf mode = "InsRow" Then

            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdSave.Enabled = Enq_right_local
            mmdDelRow.Enabled = Del_right_local
            Call SetStatusBar(mode)

        ElseIf mode = "Save" Then
            Call ResetDefaultDisp()
            Call SetStatusBar(mode)
            MsgBox("Record Saved!")
            Call SYM00013_Load(Nothing, Nothing)

        ElseIf mode = "DelRow" Then


            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdSave.Enabled = Enq_right_local
            mmdDelRow.Enabled = Del_right_local
            Call SetStatusBar(mode)

        ElseIf mode = "Clear" Then
            Call ResetDefaultDisp()
            Call SetStatusBar(mode)

        End If

        If Not CanModify Then


            mmdAdd.Enabled = False
            mmdSave.Enabled = False
            mmdDelete.Enabled = False
            mmdInsRow.Enabled = False
            mmdDelRow.Enabled = False

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

    Private Sub DataGrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridDis.CellClick, DataGridPrm.CellClick
        Dim DataGrid As DataGridView = CType(sender, DataGridView)
        Dim row As DataGridViewRow = DataGrid.CurrentRow

        If Enq_right_local = False Then
            Exit Sub
        End If

        If Not e.RowIndex = -1 Then

            If e.ColumnIndex = 0 Then
                ' Toggle Delete
                If Not row.Cells("ydp_cde").Value.ToString = "" Then
                    Call cmdDelRow_Click(sender, e)
                End If

                ' Disable code change of existing record
            ElseIf e.ColumnIndex = 3 Then
                If row.Cells("ydp_credat").Value.ToString = "" And row.Cells("ydp_status").Value.ToString = "" Then
                    row.Cells(e.ColumnIndex).ReadOnly = False
                    DataGrid.BeginEdit(True)

                    mmdSave.Enabled = Enq_right_local
                Else
                    row.Cells(e.ColumnIndex).ReadOnly = True
                End If

                ' Toggle(Status)
            ElseIf e.ColumnIndex = 4 Then
                If row.Cells("ydp_sts").Value.ToString = "A" Then
                    row.Cells("ydp_sts").Value = "I"
                Else
                    row.Cells("ydp_sts").Value = "A"
                End If
                mmdSave.Enabled = Enq_right_local

            ElseIf e.ColumnIndex = 5 OrElse e.ColumnIndex = 6 OrElse e.ColumnIndex = 7 OrElse e.ColumnIndex = 8 Then
                DataGrid.BeginEdit(True)
                mmdSave.Enabled = Enq_right_local
            End If
        End If
    End Sub

    Private Sub DataGrid_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DataGridDis.CellValidating, DataGridPrm.CellValidating
        Dim row As DataGridViewRow = CType(sender, DataGridView).CurrentRow
        Dim dt As DataTable
        Dim strNewVal As String

        If tpControl.SelectedIndex = 0 Then
            dt = rs_sydis.Tables("RESULT")
        Else
            dt = rs_syprm.Tables("RESULT")
        End If

        strNewVal = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim

        If row.Cells(e.ColumnIndex).IsInEditMode Then

            If e.ColumnIndex = 3 Then
                If Not chkGrdCellValue(row.Cells("ydp_cde"), "String", 6) Then
                    e.Cancel = True
                Else
                    For Each drr As DataGridViewRow In CType(sender, DataGridView).Rows
                        If drr.Index <> e.RowIndex Then
                            If drr.Cells("ydp_cde").Value.ToString = strNewVal Then
                                MsgBox("Duplicated discount/premium code!")
                                e.Cancel = True
                                Exit For
                            End If
                        End If
                    Next
                End If
            End If

            If e.ColumnIndex = 5 Then
                If Not chkGrdCellValue(row.Cells("ydp_dsc"), "String", 200) Then
                    e.Cancel = True
                End If
            End If

            If e.ColumnIndex = 6 Or e.ColumnIndex = 7 Or e.ColumnIndex = 8 Then
                If strNewVal.Length > 15 Then
                    MsgBox("Exceed field length!")
                    e.Cancel = True
                End If
            End If
        End If

    End Sub
    Private Sub mmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdInsRow.Click
        Dim DataGrid As DataGridView = Nothing
        Dim dt As DataTable = Nothing
        Dim dr As DataRow
        Dim strType As String = Nothing

        For Each ctrl As Control In tpControl.SelectedTab.Controls
            If TypeOf ctrl Is DataGridView Then
                DataGrid = CType(ctrl, DataGridView)
                If ctrl.Name = "DataGridDis" Then
                    dt = rs_sydis.Tables("RESULT")
                    strType = "D"
                ElseIf ctrl.Name = "DataGridPrm" Then
                    dt = rs_syprm.Tables("RESULT")
                    strType = "P"
                End If
            End If
        Next

        For Each dr In dt.Rows
            If dr.Item("ydp_cde").ToString.Trim = "" Then
                MsgBox("Please input discount/premium code.")
                Exit Sub
            End If
        Next

        dr = dt.NewRow
        dr.Item("ydp_status") = ""
        dr.Item("ydp_type") = strType
        dr.Item("ydp_sts") = "A"
        dt.Rows.Add(dr)

        For Each drr As DataGridViewRow In DataGrid.Rows
            If IsDBNull(drr.Cells(3).Value) Then
                DataGrid.CurrentCell = drr.Cells(3)
                DataGrid.CurrentCell.ReadOnly = False
                DataGrid.BeginEdit(True)
            End If
        Next
        Call setStatus("InsRow")
    End Sub

    Private Sub cmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim DataGrid As DataGridView = Nothing
        Dim dt As DataTable = Nothing
        Dim dr As DataRow
        Dim strType As String = Nothing

        For Each ctrl As Control In tpControl.SelectedTab.Controls
            If TypeOf ctrl Is DataGridView Then
                DataGrid = CType(ctrl, DataGridView)
                If ctrl.Name = "DataGridDis" Then
                    dt = rs_sydis.Tables("RESULT")
                    strType = "D"
                ElseIf ctrl.Name = "DataGridPrm" Then
                    dt = rs_syprm.Tables("RESULT")
                    strType = "P"
                End If
            End If
        Next

        For Each dr In dt.Rows
            If dr.Item("ydp_cde").ToString.Trim = "" Then
                MsgBox("Please input discount/premium code.")
                Exit Sub
            End If
        Next

        dr = dt.NewRow
        dr.Item("ydp_status") = ""
        dr.Item("ydp_type") = strType
        dr.Item("ydp_sts") = "A"
        dt.Rows.Add(dr)

        For Each drr As DataGridViewRow In DataGrid.Rows
            If IsDBNull(drr.Cells(3).Value) Then
                DataGrid.CurrentCell = drr.Cells(3)
                DataGrid.CurrentCell.ReadOnly = False
                DataGrid.BeginEdit(True)
            End If
        Next
        Call setStatus("InsRow")
    End Sub
    Private Sub mmdDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdDelRow.Click
        Dim row As DataGridViewRow = Nothing
        Dim cellStyle As New DataGridViewCellStyle

        For Each ctrl As Control In tpControl.SelectedTab.Controls
            If TypeOf ctrl Is DataGridView Then
                row = CType(ctrl, DataGridView).CurrentRow
            End If
        Next

        ' Toggle(Delete)
        If Not row Is Nothing Then
            If Not row.Cells("ydp_cde").Value.ToString = "" Then
                If row.Cells("ydp_status").Value.ToString = "" Then
                    row.Cells("ydp_status").Value = "Y"
                    cellStyle.BackColor = Color.LightBlue
                Else
                    row.Cells("ydp_status").Value = ""
                    cellStyle.BackColor = Nothing
                End If
                row.DataGridView.CurrentRow.DefaultCellStyle = cellStyle
            End If
            Call setStatus("DelRow")
        End If

    End Sub

    Private Sub cmdDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim row As DataGridViewRow = Nothing
        Dim cellStyle As New DataGridViewCellStyle

        For Each ctrl As Control In tpControl.SelectedTab.Controls
            If TypeOf ctrl Is DataGridView Then
                row = CType(ctrl, DataGridView).CurrentRow
            End If
        Next

        ' Toggle(Delete)
        If Not row Is Nothing Then
            If Not row.Cells("ydp_cde").Value.ToString = "" Then
                If row.Cells("ydp_status").Value.ToString = "" Then
                    row.Cells("ydp_status").Value = "Y"
                    cellStyle.BackColor = Color.LightBlue
                Else
                    row.Cells("ydp_status").Value = ""
                    cellStyle.BackColor = Nothing
                End If
                row.DataGridView.CurrentRow.DefaultCellStyle = cellStyle
            End If
            Call setStatus("DelRow")
        End If

    End Sub

    Private Sub cmdSaveTab(ByVal dt As DataTable, ByVal dv As DataGridView)
        Dim flgErr As Boolean = False

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            save_ok = True
            For Each row As DataGridViewRow In dv.Rows

                If row.Cells("ydp_status").Value.ToString = "" Then

                    If Not chkGrdCellValue(row.Cells("ydp_cde"), "String", 6) Then
                        save_ok = False

                    ElseIf Not chkGrdCellValue(row.Cells("ydp_dsc"), "String", 200) Then
                        save_ok = False

                    ElseIf row.Cells("ydp_account").Value.ToString.Length > 15 Then
                        MsgBox("Exceed field length!")
                        save_ok = False
                        row.DataGridView.CurrentCell = row.Cells("ydp_account")

                    ElseIf row.Cells("ydp_pca").Value.ToString.Length > 15 Then
                        MsgBox("Exceed field length!")
                        save_ok = False
                        row.DataGridView.CurrentCell = row.Cells("ydp_pca")

                    ElseIf row.Cells("ydp_pcb").Value.ToString.Length > 15 Then
                        MsgBox("Exceed field length!")
                        save_ok = False
                        row.DataGridView.CurrentCell = row.Cells("ydp_pcb")
                    Else
                        If row.Cells("ydp_credat").Value.ToString = "" Then
                            For Each drr As DataGridViewRow In dv.Rows
                                If drr.Index <> row.Index Then
                                    If drr.Cells("ydp_cde").Value.ToString = row.Cells("ydp_cde").Value.ToString And _
                                       drr.Cells("ydp_status").Value.ToString = "" Then

                                        MsgBox("Duplicated code " & drr.Cells("ydp_cde").Value.ToString & "!")
                                        save_ok = False
                                        row.DataGridView.CurrentCell = row.Cells("ydp_cde")
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
                dv.BeginEdit(True)
                Exit Sub
            Else
                gspStr = ""
                For Each dr As DataRow In dt.Rows

                    If dr.RowState = DataRowState.Modified Then
                        If dr.Item("ydp_status") = "Y" Then
                            gspStr = "sp_physical_delete_SYDISPRM '" & gsCompany & "','" & _
                                        dr.Item("ydp_type").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ydp_cde").ToString.Replace("'", "''").Trim & "'"
                        Else
                            gspStr = "sp_update_SYDISPRM '" & gsCompany & "','" & _
                                        dr.Item("ydp_type").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ydp_cde").ToString.ToUpper.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ydp_dsc").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ydp_account").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ydp_sts").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ydp_pca").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ydp_pcb").ToString.Replace("'", "''").Trim & "','" & _
                                        gsUsrID & "'"
                        End If
                    ElseIf dr.RowState = DataRowState.Added And Not dr.Item("ydp_status") = "Y" Then

                        If dr.Item("ydp_credat").ToString.Trim = "" Then
                            gspStr = "sp_insert_SYDISPRM '" & gsCompany & "','" & _
                                        dr.Item("ydp_type").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ydp_cde").ToString.ToUpper.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ydp_dsc").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ydp_account").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ydp_sts").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ydp_pca").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ydp_pcb").ToString.Replace("'", "''").Trim & "','" & _
                                        gsUsrID & "'"
                        End If
                    End If

                    If gspStr <> "" Then
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading SYM00013 sp_update_SYDISPRM : " & rtnStr)
                            flgErr = True
                            Exit For
                        End If
                        gspStr = ""
                    End If
                Next

                If Not flgErr Then
                    dt.DataSet.AcceptChanges()
                Else
                    save_ok = False
                    dt.DataSet.RejectChanges()
                End If
            End If

        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub mmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mmdSave.Click
        If checkFocus(Me) Then Exit Sub

        bindSrcP.EndEdit()
        bindSrcD.EndEdit()
        Call cmdSaveTab(rs_sydis.Tables("RESULT"), Me.DataGridDis)
        If save_ok Then
            Call cmdSaveTab(rs_syprm.Tables("RESULT"), Me.DataGridPrm)
        End If

        If save_ok Then
            Call setStatus("Save")
        Else
            MsgBox("Record Not Updated!")
        End If
    End Sub

    Private Sub SYM00013_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim YNC As Integer
        Dim flgMod As Boolean = False

        bindSrcP.EndEdit()
        bindSrcD.EndEdit()
        For Each dr As DataRow In rs_sydis.Tables("RESULT").Rows
            If dr.RowState = DataRowState.Modified Or dr.RowState = DataRowState.Added Then
                flgMod = True
            End If
        Next

        For Each dr As DataRow In rs_syprm.Tables("RESULT").Rows
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
        Else
            e.Cancel = False
        End If

    End Sub
    Private Sub MmdExit_Click() Handles mmdExit.Click
        Me.Close()
    End Sub

End Class