Public Class SYM00005
    Inherits System.Windows.Forms.Form

    Dim rs_sycatcde As New DataSet
    Dim bindSrc As New BindingSource
    Dim save_ok As Boolean
    Dim CanModify As Boolean = True
    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean

    Private Sub SYM00005_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Call AccessRight(Me.Name)
            Enq_right_local = Enq_right
            Del_right_local = Del_right

            Call FillComboLvl()

            If Not rs_sycatcde Is Nothing Then
                rs_sycatcde = Nothing
            End If

            gspStr = "sp_select_SYCATCDE_Level '" & gsCompany & "',''"
            rtnLong = execute_SQLStatement(gspStr, rs_sycatcde, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00005 sp_select_SYCATCDE_Level : " & rtnStr)
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
        Dim dt As DataTable = rs_sycatcde.Tables("RESULT")

        If Not dt Is Nothing Then
            For Each dc As DataColumn In dt.Columns
                dc.ReadOnly = False
            Next
            For Each dr As DataRow In dt.Rows
                dr.Item("ycc_status") = ""
            Next
            rs_sycatcde.AcceptChanges()
        End If
    End Sub

    Private Sub FillComboLvl()

        cboLevel.Items.Clear()
        cboLevel.Items.Add("0 - level 0")
        cboLevel.Items.Add("1 - level 1")
        cboLevel.Items.Add("2 - level 2")
        cboLevel.Items.Add("3 - level 3")
        cboLevel.Items.Add("4 - level 4")
    End Sub

    Private Sub cboLevel_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLevel.SelectedIndexChanged
        Dim strSelItem As String

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            strSelItem = Me.cboLevel.SelectedItem.Trim.Substring(0, 1)

            If Not rs_sycatcde Is Nothing Then
                rs_sycatcde = Nothing
            End If

            gspStr = "sp_select_SYCATCDE_Level '" & gsCompany & "','" & strSelItem & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_sycatcde, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00005 sp_select_SYCATCDE_Level : " & rtnStr)
            Else
                If rs_sycatcde.Tables("RESULT").Rows.Count = 0 Then
                    'cmdInsRow.Enabled = Enq_right_local
                    mmdInsRow.Enabled = Enq_right_local
                    'cmdDelRow.Enabled = False
                    mmdDelRow.Enabled = False
                Else
                    'cmdInsRow.Enabled = False
                    mmdInsRow.Enabled = False
                    'cmdDelRow.Enabled = False
                    mmdDelRow.Enabled = False
                    If Enq_right_local = True Then
                        'cmdInsRow.Enabled = Enq_right_local
                        mmdInsRow.Enabled = Enq_right_local
                        'cmdDelRow.Enabled = Del_right_local
                        mmdDelRow.Enabled = Del_right_local
                    End If
                End If
                Call setDataRowAttr()
                Call displayGrid()
            End If
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub mmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdClear.Click
        If checkFocus(Me) Then Exit Sub
        Dim YNC As Integer
        Dim flgMod As Boolean = False

        bindSrc.EndEdit()
        For Each dr As DataRow In rs_sycatcde.Tables("RESULT").Rows
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
                        Call SYM00005_Load(Nothing, Nothing)
                    Else
                        Exit Sub
                    End If
                Else
                    MsgBox("Sorry! You have not right to save!")
                End If
            ElseIf YNC = Windows.Forms.DialogResult.No Then
                Call SYM00005_Load(Nothing, Nothing)

            ElseIf YNC = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
        Else
            Call SYM00005_Load(Nothing, Nothing)
        End If

    End Sub

    Private Sub displayGrid()
        Dim i As Integer
        Dim dv As DataView = rs_sycatcde.Tables("RESULT").DefaultView
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
                    Case 3
                        .Columns(i).Width = 150
                        .Columns(i).HeaderText = "Category Name"
                    Case 4
                        .Columns(i).Width = 350
                        .Columns(i).HeaderText = "Category Description"
                        .Columns(i).ReadOnly = False
                    Case 10
                        .Columns(i).Width = 132
                        .Columns(i).HeaderText = "Force MOQ/MOA"
                        .Columns(i).ReadOnly = True
                    Case 11
                        .Columns(i).Width = 100
                        .Columns(i).HeaderText = "MOQ"
                        .Columns(i).ReadOnly = False
                    Case 12
                        .Columns(i).Width = 100
                        .Columns(i).HeaderText = "MOA (USA)"
                        .Columns(i).ReadOnly = False
                    Case Else
                        .Columns(i).Visible = False
                End Select
                .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersHeight = 28
        End With

        If Not dv.Count = 0 Then
            dv.Sort = "ycc_upddat desc"
            Dim drv As DataRowView = dv(0)
            Me.StatusBar.Items("lblRight").Text = Format(drv.Item("ycc_credat"), "MM/dd/yyyy") & " " & Format(drv.Item("ycc_upddat"), "MM/dd/yyyy") & " " & drv.Item("ycc_updusr")

            dv.Sort = Nothing
        End If

        If Enq_right_local = False Then
            DataGrid.ReadOnly = True
        End If
    End Sub

    Private Sub setStatus(ByVal mode As String)

        If mode = "Init" Then
            'cmdAdd.Enabled = False
            'cmdSave.Enabled = False
            'cmdDelete.Enabled = False
            'cmdCopy.Enabled = False
            'cmdFind.Enabled = False
            'cmdExit.Enabled = True
            'cmdClear.Enabled = True
            'cmdInsRow.Enabled = False
            'cmdDelRow.Enabled = False
            'cmdSearch.Enabled = False

            mmdAdd.Enabled = False
            mmdSave.Enabled = False
            mmdDelete.Enabled = False
            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdExit.Enabled = True
            mmdClear.Enabled = True
            mmdInsRow.Enabled = False
            mmdDelRow.Enabled = False
            mmdSearch.Enabled = False

            'cmdFirst.Enabled = False
            'cmdLast.Enabled = False
            'cmdNext.Enabled = False
            'cmdPrevious.Enabled = False
            cboLevel.Enabled = True

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
            cboLevel.Enabled = False

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
            Call SYM00005_Load(Nothing, Nothing)

        ElseIf mode = "DelRow" Then
            'cmdCopy.Enabled = False
            'cmdFind.Enabled = False
            'cmdSave.Enabled = Enq_right_local
            'cmdDelRow.Enabled = Del_right_local

            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdSave.Enabled = Enq_right_local
            mmdDelRow.Enabled = Del_right_local
            cboLevel.Enabled = False

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

    Private Sub DataGrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGrid.CellClick
        Dim row As DataGridViewRow = DataGrid.CurrentRow

        If Not e.RowIndex = -1 Then

            If e.ColumnIndex = 0 Then
                ' Toggle Delete
                If Not row.Cells("ycc_catcde").Value.ToString = "" Then
                    Call mmdDelRow_Click(sender, e)
                End If

                ' Disable category code change of existing record
            ElseIf e.ColumnIndex = 3 Then
                If row.Cells("ycc_credat").Value.ToString = "" And row.Cells("ycc_status").Value.ToString = "" Then
                    row.Cells(e.ColumnIndex).ReadOnly = False
                    DataGrid.BeginEdit(True)
                    'cmdSave.Enabled = Enq_right_local
                    mmdSave.Enabled = Enq_right_local
                    Me.cboLevel.Enabled = False
                Else
                    row.Cells(e.ColumnIndex).ReadOnly = True
                End If

            ElseIf e.ColumnIndex = 4 Then
                DataGrid.BeginEdit(True)
                'cmdSave.Enabled = Enq_right_local
                mmdSave.Enabled = Enq_right_local
                Me.cboLevel.Enabled = False

                ' Toggle Force MOQ/MOA
            ElseIf e.ColumnIndex = 10 Then
                If Enq_right_local = False Then
                    Exit Sub
                End If

                If row.Cells("ycc_fflag").Value.ToString = "N" Then
                    row.Cells("ycc_fflag").Value = "Y"
                Else
                    row.Cells("ycc_fflag").Value = "N"
                End If
                'cmdSave.Enabled = Enq_right_local
                mmdSave.Enabled = Enq_right_local
                Me.cboLevel.Enabled = False

                ' Not allow MOA > 0 and MOQ > 0
            ElseIf e.ColumnIndex = 11 Then
                If row.Cells("ycc_moa").Value > 0 Then
                    row.Cells(e.ColumnIndex).ReadOnly = True
                Else
                    row.Cells(e.ColumnIndex).ReadOnly = False
                    DataGrid.BeginEdit(True)
                    'cmdSave.Enabled = Enq_right_local
                    mmdSave.Enabled = Enq_right_local
                    Me.cboLevel.Enabled = False
                End If

                ' Not allow MOA > 0 and MOQ > 0
            ElseIf e.ColumnIndex = 12 Then
                If row.Cells("ycc_moq").Value > 0 Then
                    row.Cells(e.ColumnIndex).ReadOnly = True
                Else
                    row.Cells(e.ColumnIndex).ReadOnly = False
                    DataGrid.BeginEdit(True)
                    'cmdSave.Enabled = Enq_right_local
                    mmdSave.Enabled = Enq_right_local
                    Me.cboLevel.Enabled = False
                End If
            End If
        End If
    End Sub

    Private Sub DataGrid_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DataGrid.CellValidating
        Dim row As DataGridViewRow = DataGrid.CurrentRow
        Dim strNewVal As String

        strNewVal = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim

        If row.Cells(e.ColumnIndex).IsInEditMode Then

            If e.ColumnIndex = 3 Then
                If Not chkGrdCellValue(row.Cells("ycc_catcde"), "String", 20) Then
                    e.Cancel = True
                Else
                    For Each drr As DataGridViewRow In DataGrid.Rows
                        If drr.Index <> e.RowIndex Then
                            If drr.Cells("ycc_catcde").Value.ToString = strNewVal Then
                                MsgBox("Duplicated category code!")
                                e.Cancel = True
                                Exit For
                            End If
                        End If
                    Next
                End If
            End If

            If e.ColumnIndex = 4 Then
                If Not chkGrdCellValue(row.Cells("ycc_catdsc"), "String", 200) Then
                    e.Cancel = True
                End If
            End If

            If e.ColumnIndex = 11 Then
                If Not chkGrdCellValue(row.Cells("ycc_moq"), "Z+Integer") Then
                    e.Cancel = True
                ElseIf row.Cells("ycc_fflag").Value.ToString = "Y" And strNewVal = 0 And row.Cells("ycc_moa").Value = 0 Then
                    MsgBox("MOQ and MOA (USD) cannot be both zero.")
                    e.Cancel = True
                End If
            End If

            If e.ColumnIndex = 12 Then
                If Not chkGrdCellValue(row.Cells("ycc_moa"), "Z+Numeric") Then
                    e.Cancel = True
                ElseIf row.Cells("ycc_fflag").Value.ToString = "Y" And strNewVal = 0 And row.Cells("ycc_moq").Value = 0 Then
                    MsgBox("MOQ and MOA (USD) cannot be both zero.")
                    e.Cancel = True
                End If
            End If
        End If

    End Sub

    Private Sub mmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdInsRow.Click
        Dim dt As DataTable
        Dim dr As DataRow

        dt = rs_sycatcde.Tables("RESULT")
        For Each dr In dt.Rows
            If dr.Item("ycc_catcde").ToString.Trim = "" Then
                MsgBox("Please input category code.")
                Exit Sub
            End If
        Next

        dr = dt.NewRow
        dr.Item("ycc_status") = ""
        dr.Item("ycc_fflag") = "N"
        dr.Item("ycc_moq") = "0"
        dr.Item("ycc_moa") = "0.0000"
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
        Dim row As DataGridViewRow = DataGrid.CurrentRow
        Dim cellStyle As New DataGridViewCellStyle

        ' Toggle Delete
        If Not row Is Nothing Then
            If Not row.Cells("ycc_catcde").Value.ToString = "" Then
                If row.Cells("ycc_status").Value.ToString = "" Then
                    row.Cells("ycc_status").Value = "Y"
                    cellStyle.BackColor = Color.LightBlue
                Else
                    row.Cells("ycc_status").Value = ""
                    cellStyle.BackColor = Nothing
                End If
                row.DataGridView.CurrentRow.DefaultCellStyle = cellStyle
            End If
            Call setStatus("DelRow")
        End If

    End Sub

    Private Sub mmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mmdSave.Click
        If checkFocus(Me) Then Exit Sub
        Dim strSelItem As String
        Dim flgErr As Boolean = False

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            save_ok = True
            bindSrc.EndEdit()
            For Each row As DataGridViewRow In DataGrid.Rows

                If row.Cells("ycc_status").Value.ToString = "" Then

                    If Not chkGrdCellValue(row.Cells("ycc_catcde"), "String", 20) Then
                        save_ok = False

                    ElseIf Not chkGrdCellValue(row.Cells("ycc_catdsc"), "String", 200) Then
                        save_ok = False

                    ElseIf Not chkGrdCellValue(row.Cells("ycc_fflag"), "String", 1) Then
                        save_ok = False

                    ElseIf Not chkGrdCellValue(row.Cells("ycc_moq"), "Z+Integer") Then
                        save_ok = False

                    ElseIf Not chkGrdCellValue(row.Cells("ycc_moa"), "Z+Numeric") Then
                        save_ok = False

                    ElseIf row.Cells("ycc_fflag").Value.ToString = "Y" And row.Cells("ycc_moa").Value = 0 And row.Cells("ycc_moq").Value = 0 Then
                        MsgBox("MOQ and MOA (USD) cannot be both zero.")
                        save_ok = False
                        row.DataGridView.CurrentCell = row.Cells("ycc_moq")

                    Else
                        If row.Cells("ycc_credat").Value.ToString = "" Then
                            For Each drr As DataGridViewRow In DataGrid.Rows
                                If drr.Index <> row.Index Then
                                    If drr.Cells("ycc_catcde").Value.ToString = row.Cells("ycc_catcde").Value.ToString And _
                                       drr.Cells("ycc_status").Value.ToString = "" Then

                                        MsgBox("Duplicated category code " & drr.Cells("ycc_catcde").Value.ToString & "!")
                                        save_ok = False
                                        row.DataGridView.CurrentCell = row.Cells("ycc_catcde")
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
                DataGrid.BeginEdit(True)
                Exit Sub
            Else
                gspStr = ""
                strSelItem = Me.cboLevel.SelectedItem.Trim.Substring(0, 1).Replace("'", "''")

                For Each dr As DataRow In rs_sycatcde.Tables("RESULT").Rows

                    If dr.RowState = DataRowState.Modified Then
                        If dr.Item("ycc_status") = "Y" Then
                            gspStr = "sp_physical_delete_SYCATCDE '" & gsCompany & "','" & _
                                        strSelItem & "','" & _
                                        dr.Item("ycc_catcde").ToString.ToUpper.Replace("'", "''").Trim & "'"
                        Else
                            gspStr = "sp_update_SYCATCDE '" & gsCompany & "','" & _
                                        strSelItem & "','" & _
                                        dr.Item("ycc_catcde").ToString.ToUpper.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ycc_catdsc").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ycc_fflag").ToString.Replace("'", "''").Trim & "'," & _
                                        dr.Item("ycc_moq").ToString.Replace("'", "''").Trim & "," & _
                                        dr.Item("ycc_moa").ToString.Replace("'", "''").Trim & ",'" & _
                                        gsUsrID & "'"
                        End If
                    ElseIf dr.RowState = DataRowState.Added And Not dr.Item("ycc_status") = "Y" Then

                        If dr.Item("ycc_credat").ToString.Trim = "" Then
                            gspStr = "sp_insert_SYCATCDE '" & gsCompany & "','" & _
                                        strSelItem & "','" & _
                                        dr.Item("ycc_catcde").ToString.ToUpper.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ycc_catdsc").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ycc_fflag").ToString.Replace("'", "''").Trim & "'," & _
                                        dr.Item("ycc_moq").ToString.Replace("'", "''").Trim & "," & _
                                        dr.Item("ycc_moa").ToString.Replace("'", "''").Trim & ",'" & _
                                        gsUsrID & "'"
                        End If
                    End If

                    If gspStr <> "" Then
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading SYM00005 sp_update_SYCATCDE : " & rtnStr)
                            flgErr = True
                            Exit For
                        End If
                        gspStr = ""
                    End If
                Next

                If Not flgErr Then
                    rs_sycatcde.AcceptChanges()
                    Call setStatus("Save")
                Else
                    save_ok = False
                    rs_sycatcde.RejectChanges()
                    MsgBox("Record Not Updated!")
                End If
            End If

        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub SYM00005_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim YNC As Integer
        Dim flgMod As Boolean = False

        bindSrc.EndEdit()
        For Each dr As DataRow In rs_sycatcde.Tables("RESULT").Rows
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