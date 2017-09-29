Public Class SYM00006
    Inherits System.Windows.Forms.Form

    Dim rs_sycatrel As New DataSet
    Dim bindSrc As New BindingSource
    Dim save_ok As Boolean
    Dim CanModify As Boolean = True
    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean

    Private Sub SYM00006_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Call AccessRight(Me.Name)
            Enq_right_local = Enq_right
            Del_right_local = Del_right

            gspStr = "sp_select_SYCATREL_SYS '" & gsCompany & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_sycatrel, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00006 sp_select_SYCATREL_SYS : " & rtnStr)
            Else
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
        Dim dt As DataTable = rs_sycatrel.Tables("RESULT")

        If Not dt Is Nothing Then
            For Each dc As DataColumn In dt.Columns
                dc.ReadOnly = False
            Next
            For Each dr As DataRow In dt.Rows
                dr.Item("ycr_status") = ""
            Next
            rs_sycatrel.AcceptChanges()
        End If
    End Sub

    Private Sub displayGrid()
        Dim i As Integer
        Dim dv As DataView = rs_sycatrel.Tables("RESULT").DefaultView
        bindSrc.DataSource = dv

        With DataGrid
            .DataSource = Nothing
            .DataSource = bindSrc
            For i = 0 To .Columns.Count - 1
                Select Case i
                    Case 0
                        .Columns(i).Width = 32
                        .Columns(i).HeaderText = "Del"
                        .Columns(i).ReadOnly = True
                    Case 3
                        .Columns(i).Width = 168
                        .Columns(i).HeaderText = "Level 0 - Desc"
                    Case 4
                        .Columns(i).Width = 168
                        .Columns(i).HeaderText = "Level 1 - Desc"
                    Case 5
                        .Columns(i).Width = 168
                        .Columns(i).HeaderText = "Level 2 - Desc"
                    Case 6
                        .Columns(i).Width = 168
                        .Columns(i).HeaderText = "Level 3 - Desc"
                    Case 7
                        .Columns(i).Width = 168
                        .Columns(i).HeaderText = "Level 4 - Desc"
                    Case Else
                        .Columns(i).Visible = False
                End Select
                .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersHeight = 28
        End With

        If Not dv.Count = 0 Then
            dv.Sort = "ycr_upddat desc"
            Dim drv As DataRowView = dv(0)
            Me.StatusBar.Items("lblRight").Text = Format(drv.Item("ycr_credat"), "MM/dd/yyyy") & " " & Format(drv.Item("ycr_upddat"), "MM/dd/yyyy") & " " & drv.Item("ycr_updusr")

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

            'cmdFirst.Enabled = False
            'cmdLast.Enabled = False
            'cmdNext.Enabled = False
            'cmdPrevious.Enabled = False

            mmdPrint.Enabled = False
            mmdAttach.Enabled = False
            mmdFunction.Enabled = False
            mmdLink.Enabled = False
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
            Call SYM00006_Load(Nothing, Nothing)

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

    Private Sub createComboBoxCell(ByVal cell As DataGridViewCell, ByVal strlvl As String)
        Dim rs_Lvl As New DataSet
        Dim cboCell As New DataGridViewComboBoxCell
        Dim iCol As Integer = cell.ColumnIndex
        Dim iRow As Integer = cell.RowIndex
        Dim dgView As DataGridView = cell.DataGridView

        gspStr = "sp_select_SYCATCDE_level '" & gsCompany & "', '" & strlvl & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_Lvl, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SYM00006 sp_select_SYCATCDE_level : " & rtnStr)
        Else
            For Each dr As DataRow In rs_Lvl.Tables("RESULT").Rows
                cboCell.Items.Add(dr.Item("ycc_catcde").ToString.Trim)
            Next
        End If
        cboCell.DropDownWidth = 150
        cboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

        dgView.Rows(iRow).Cells(iCol) = cboCell
        dgView.Rows(iRow).Cells(iCol).ReadOnly = False
    End Sub

    Private Sub cboLvl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim iRow As Integer = DataGrid.CurrentCell.RowIndex
        Dim iCol As Integer = DataGrid.CurrentCell.ColumnIndex
        Dim strSelItem As String

        If TypeOf (Me.DataGrid.CurrentCell) Is DataGridViewComboBoxCell Then
            Dim cboBox As ComboBox = CType(sender, ComboBox)
            If Not cboBox Is Nothing AndAlso Not cboBox.SelectedItem Is Nothing Then

                strSelItem = cboBox.SelectedItem.ToString
                RemoveHandler cboBox.SelectedIndexChanged, AddressOf cboLvl_SelectedIndexChanged
                ' User has changed the code
                If iCol >= 3 And iCol <= 7 Then
                    Me.DataGrid.Rows(iRow).Cells(iCol).Value = strSelItem
                End If
                AddHandler cboBox.SelectedIndexChanged, AddressOf cboLvl_SelectedIndexChanged

            End If
        End If
    End Sub

    Private Sub DataGrid_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGrid.EditingControlShowing

        If DataGrid.CurrentCell.ColumnIndex >= 3 And DataGrid.CurrentCell.ColumnIndex <= 7 Then
            If TypeOf (DataGrid.CurrentCell) Is DataGridViewComboBoxCell Then
                Dim cboBox As ComboBox = CType(e.Control, ComboBox)
                If Not cboBox Is Nothing Then
                    RemoveHandler cboBox.SelectedIndexChanged, AddressOf cboLvl_SelectedIndexChanged
                    AddHandler cboBox.SelectedIndexChanged, AddressOf cboLvl_SelectedIndexChanged
                End If
            End If
        End If
    End Sub

    Private Sub DataGrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGrid.CellClick
        Dim row As DataGridViewRow = DataGrid.CurrentRow

        If Not e.RowIndex = -1 Then

            If e.ColumnIndex = 0 Then
                ' Toggle Delete
                If Enq_right_local = False Then
                    Exit Sub
                End If

                If Not row.Cells("ycr_catlvl0").Value.ToString = "" Then
                    Call mmdDelRow_Click(sender, e)
                End If

            ElseIf e.ColumnIndex >= 3 And e.ColumnIndex <= 7 Then
                If row.Cells("ycr_credat").Value.ToString = "" And row.Cells("ycr_status").Value.ToString = "" Then
                    ' ColumnIndex 3 => Lvl 0, ColumnIndex 4 => Lvl 1 ...
                    If TypeOf (DataGrid.CurrentCell) Is DataGridViewTextBoxCell Then
                        createComboBoxCell(DataGrid.CurrentCell, (e.ColumnIndex - 3).ToString)
                        DataGrid.BeginEdit(True)
                        'cmdSave.Enabled = Enq_right_local
                        mmdSave.Enabled = Enq_right_local
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
        Dim i As Integer
        Dim arr(4) As String

        strNewVal = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim

        If row.Cells(e.ColumnIndex).IsInEditMode Then

            If e.ColumnIndex >= 3 And e.ColumnIndex <= 7 Then
                If strNewVal = "" Then
                    MsgBox("Please input category code.")
                    e.Cancel = True
                End If

                ' Column 3 to 7
                For i = 3 To 7
                    If i = e.ColumnIndex Then
                        arr(i - 3) = row.Cells(i).EditedFormattedValue.ToString.Trim
                    Else
                        arr(i - 3) = row.Cells(i).Value.ToString.Trim
                    End If
                Next

                For Each drr As DataGridViewRow In DataGrid.Rows
                    If drr.Index <> e.RowIndex Then
                        If drr.Cells("ycr_catlvl0").Value.ToString = arr(0) And _
                           drr.Cells("ycr_catlvl1").Value.ToString = arr(1) And _
                           drr.Cells("ycr_catlvl2").Value.ToString = arr(2) And _
                           drr.Cells("ycr_catlvl3").Value.ToString = arr(3) And _
                           drr.Cells("ycr_catlvl4").Value.ToString = arr(4) Then

                            MsgBox("Duplicated category relation!")
                            e.Cancel = True
                            Exit For
                        End If
                    End If
                Next
            End If
        End If

    End Sub

    Private Sub mmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdInsRow.Click
        Dim dt As DataTable
        Dim dr As DataRow

        dt = rs_sycatrel.Tables("RESULT")
        For Each dr In dt.Rows
            If dr.Item("ycr_catlvl0").ToString.Trim = "" Then
                MsgBox("Please input level 0 category code.")
                Exit Sub
            End If
        Next

        dr = dt.NewRow
        dr.Item("ycr_status") = ""
        dt.Rows.Add(dr)

        For Each drr As DataGridViewRow In DataGrid.Rows
            If IsDBNull(drr.Cells(3).Value) Then
                DataGrid.CurrentCell = drr.Cells(3)
                createComboBoxCell(DataGrid.CurrentCell, "0")
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
            If Not row.Cells("ycr_catlvl0").Value.ToString = "" Then
                If row.Cells("ycr_status").Value.ToString = "" Then
                    row.Cells("ycr_status").Value = "Y"
                    cellStyle.BackColor = Color.LightBlue
                Else
                    row.Cells("ycr_status").Value = ""
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
        Dim arr(4) As String
        Dim i As Integer

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            save_ok = True
            bindSrc.EndEdit()
            For Each row As DataGridViewRow In DataGrid.Rows

                If row.Cells("ycr_status").Value.ToString = "" Then

                    If Not chkGrdCellValue(row.Cells("ycr_catlvl0"), "String", 20) Then
                        save_ok = False

                    ElseIf Not chkGrdCellValue(row.Cells("ycr_catlvl1"), "String", 20) Then
                        save_ok = False

                    ElseIf Not chkGrdCellValue(row.Cells("ycr_catlvl2"), "String", 20) Then
                        save_ok = False

                    ElseIf Not chkGrdCellValue(row.Cells("ycr_catlvl3"), "String", 20) Then
                        save_ok = False

                    ElseIf Not chkGrdCellValue(row.Cells("ycr_catlvl4"), "String", 20) Then
                        save_ok = False

                    Else
                        If row.Cells("ycr_credat").Value.ToString = "" Then
                            ' Column 3 to 7
                            For i = 3 To 7
                                arr(i - 3) = row.Cells(i).Value.ToString.Trim
                            Next i

                            For Each drr As DataGridViewRow In DataGrid.Rows
                                If drr.Index <> row.Index Then
                                    If drr.Cells("ycr_catlvl0").Value.ToString = arr(0) And _
                                       drr.Cells("ycr_catlvl1").Value.ToString = arr(1) And _
                                       drr.Cells("ycr_catlvl2").Value.ToString = arr(2) And _
                                       drr.Cells("ycr_catlvl3").Value.ToString = arr(3) And _
                                       drr.Cells("ycr_catlvl4").Value.ToString = arr(4) And _
                                       drr.Cells("ycr_status").Value.ToString = "" Then

                                        MsgBox("Duplicated category relation!")
                                        save_ok = False
                                        flgReAct = True
                                        row.DataGridView.CurrentCell = row.Cells("ycr_catlvl4")
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
                        createComboBoxCell(.CurrentCell, (.CurrentCell.ColumnIndex - 3).ToString)
                    End If
                    .BeginEdit(True)
                    Exit Sub
                End With
            Else
                gspStr = ""
                For Each dr As DataRow In rs_sycatrel.Tables("RESULT").Rows

                    If dr.RowState = DataRowState.Modified Then
                        If dr.Item("ycr_status") = "Y" Then
                            gspStr = "sp_physical_delete_SYCATREL '" & gsCompany & "'," & _
                                        dr.Item("ycr_catseq").ToString.Replace("'", "''").Trim & ",'" & _
                                        dr.Item("ycr_catlvl0").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ycr_catlvl1").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ycr_catlvl2").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ycr_catlvl3").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ycr_catlvl4").ToString.Replace("'", "''").Trim & "'"
                        End If
                    ElseIf dr.RowState = DataRowState.Added And Not dr.Item("ycr_status") = "Y" Then

                        If dr.Item("ycr_credat").ToString.Trim = "" Then
                            gspStr = "sp_insert_SYCATREL '" & gsCompany & "','" & _
                                        dr.Item("ycr_catlvl0").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ycr_catlvl1").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ycr_catlvl2").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ycr_catlvl3").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ycr_catlvl4").ToString.Replace("'", "''").Trim & "','" & _
                                        gsUsrID & "'"
                        End If
                    End If

                    If gspStr <> "" Then
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading SYM00006 sp_update_SYCATREL : " & rtnStr)
                            flgErr = True
                            Exit For
                        End If
                        gspStr = ""
                    End If
                Next

                If Not flgErr Then
                    rs_sycatrel.AcceptChanges()
                    Call setStatus("Save")
                Else
                    save_ok = False
                    rs_sycatrel.RejectChanges()
                    MsgBox("Record Not Updated!")
                End If
            End If

        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub SYM00006_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim YNC As Integer
        Dim flgMod As Boolean = False

        bindSrc.EndEdit()
        For Each dr As DataRow In rs_sycatrel.Tables("RESULT").Rows
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