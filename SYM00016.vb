Public Class SYM00016
    Inherits System.Windows.Forms.Form

    Dim rs_symrkfml As New DataSet
    Dim rs_fmlInf As New DataSet
    Dim bindSrc As New BindingSource
    Dim save_ok As Boolean
    Dim CanModify As Boolean = True
    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean

    Private Sub SYM00016_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Call AccessRight(Me.Name)
            Enq_right_local = Enq_right
            Del_right_local = Del_right

            Call FillComboDVPV()

            If Not rs_symrkfml Is Nothing Then
                rs_symrkfml = Nothing
            End If

            gspStr = "sp_select_SYMRKFML '" & gsCompany & "','',''"
            rtnLong = execute_SQLStatement(gspStr, rs_symrkfml, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00016 sp_select_SYMRKFML : " & rtnStr)
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
        Dim dt As DataTable = rs_symrkfml.Tables("RESULT")

        If Not dt Is Nothing Then
            For Each dc As DataColumn In dt.Columns
                dc.ReadOnly = False
            Next
            For Each dr As DataRow In dt.Rows
                dr.Item("ymf_status") = ""
            Next
            rs_symrkfml.AcceptChanges()
        End If
    End Sub

    Private Sub FillComboDVPV()
        Dim rs_venno As New DataSet

        Try
            gspStr = "sp_list_VNBASINF_SYM00016 '" & gsCompany & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_venno, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00016 sp_list_SYSVNFOR : " & rtnStr)
            Else
                Me.cboDV.Items.Clear()
                Me.cboPV.Items.Clear()
                For Each dr As DataRow In rs_venno.Tables("RESULT").Rows
                    Me.cboDV.Items.Add(dr.Item("vbi_venno").ToString & " - " & dr.Item("vbi_vensna").ToString)
                    Me.cboPV.Items.Add(dr.Item("vbi_venno").ToString & " - " & dr.Item("vbi_vensna").ToString)
                Next
            End If
        Finally
            rs_venno = Nothing
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub cboDV_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDV.SelectedIndexChanged
        cboPV.SelectedIndex = -1
        Call setStatus("Init")
    End Sub

    Private Sub cboPV_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPV.SelectedIndexChanged
        If Not cboDV.SelectedItem Is Nothing Then
            Call ShowGrdDtl()
        End If
    End Sub
    Private Sub mmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdClear.Click
        If checkFocus(Me) Then Exit Sub
        Dim YNC As Integer
        Dim flgMod As Boolean = False

        bindSrc.EndEdit()
        For Each dr As DataRow In rs_symrkfml.Tables("RESULT").Rows
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
                        Call SYM00016_Load(Nothing, Nothing)
                    Else
                        Exit Sub
                    End If
                Else
                    MsgBox("Sorry! You have not right to save!")
                End If
            ElseIf YNC = Windows.Forms.DialogResult.No Then
                Call SYM00016_Load(Nothing, Nothing)

            ElseIf YNC = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
        Else
            Call SYM00016_Load(Nothing, Nothing)
        End If

    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim YNC As Integer
        Dim flgMod As Boolean = False

        bindSrc.EndEdit()
        For Each dr As DataRow In rs_symrkfml.Tables("RESULT").Rows
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
                        Call SYM00016_Load(Nothing, Nothing)
                    Else
                        Exit Sub
                    End If
                Else
                    MsgBox("Sorry! You have not right to save!")
                End If
            ElseIf YNC = Windows.Forms.DialogResult.No Then
                Call SYM00016_Load(Nothing, Nothing)

            ElseIf YNC = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
        Else
            Call SYM00016_Load(Nothing, Nothing)
        End If

    End Sub

    Private Sub ShowGrdDtl()
        Dim strDV, strPV As String

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            strDV = Split(cboDV.SelectedItem, " - ")(0).Trim
            strPV = Split(cboPV.SelectedItem, " - ")(0).Trim

            If Not rs_fmlInf Is Nothing Then
                rs_fmlInf = Nothing
            End If

            If Not rs_symrkfml Is Nothing Then
                rs_symrkfml = Nothing
            End If

            gspStr = "sp_list_SYFMLINF '" & gsCompany & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_fmlInf, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00016 sp_list_SYFMLINF : " & rtnStr)
            Else
                gspStr = "sp_select_SYMRKFML '" & gsCompany & "','" & strDV & "','" & strPV & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_symrkfml, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading SYM00016 sp_select_SYMRKFML : " & rtnStr)
                Else
                    If rs_symrkfml.Tables("RESULT").Rows.Count = 0 Then
                  
                        mmdInsRow.Enabled = Enq_right_local
                        mmdDelRow.Enabled = False
                    Else

                        mmdInsRow.Enabled = False
                        mmdDelRow.Enabled = False
                        If Enq_right_local = True Then
                            mmdInsRow.Enabled = Enq_right_local
                            mmdDelRow.Enabled = True
                        End If
                    End If
                    Call setDataRowAttr()
                    Call displayGrid()
                End If
            End If
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub displayGrid()
        Dim i As Integer
        Dim dv As DataView = rs_symrkfml.Tables("RESULT").DefaultView
        bindsrc.DataSource = dv
        Me.StatusBar.Items("lblRight").Text = ""
        With DataGrid
            .DataSource = Nothing
            .DataSource = bindsrc
            For i = 0 To .Columns.Count - 1
                Select Case i
                    Case 0
                        .Columns(i).Width = 40
                        .Columns(i).HeaderText = "Del"
                        .Columns(i).ReadOnly = True
                    Case 5
                        .Columns(i).Width = 80
                        .Columns(i).HeaderText = "Option"
                    Case 6
                        .Columns(i).Width = 210
                        .Columns(i).HeaderText = "Formula Description"
                        .Columns(i).ReadOnly = True
                    Case 7
                        .Columns(i).Width = 150
                        .Columns(i).HeaderText = "Price Markup Formula"
                        .Columns(i).ReadOnly = True
                    Case 8
                        .Columns(i).Width = 80
                        .Columns(i).HeaderText = "Option"
                    Case 9
                        .Columns(i).Width = 200
                        .Columns(i).HeaderText = "Formula Description"
                        .Columns(i).ReadOnly = True
                    Case 10
                        .Columns(i).Width = 150
                        .Columns(i).HeaderText = "Cal.Fty Price Formula"
                        .Columns(i).ReadOnly = True
                    Case Else
                        .Columns(i).Visible = False
                End Select
                .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i
        End With

        If Not dv.Count = 0 Then
            dv.Sort = "ymf_upddat desc"
            Dim drv As DataRowView = dv(0)
            Me.StatusBar.Items("lblRight").Text = Format(drv.Item("ymf_credat"), "MM/dd/yyyy") & " " & Format(drv.Item("ymf_upddat"), "MM/dd/yyyy") & " " & drv.Item("ymf_updusr")

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
            mmdExit.Enabled = True
            mmdClear.Enabled = True
            mmdInsRow.Enabled = False
            mmdDelRow.Enabled = False
            mmdSearch.Enabled = False

            mmdPrint.Enabled = False
            mmdAttach.Enabled = False
            mmdFunction.Enabled = False
            mmdLink.Enabled = False

            cboDV.Enabled = True
            cboPV.Enabled = True

            Call ResetDefaultDisp()
            Call SetStatusBar(mode)

        ElseIf mode = "InsRow" Then

            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdSave.Enabled = Enq_right_local
            mmdDelRow.Enabled = Del_right_local
            cboDV.Enabled = False
            cboPV.Enabled = False
            Call SetStatusBar(mode)

        ElseIf mode = "Save" Then
            Call ResetDefaultDisp()
            Call SetStatusBar(mode)
            MsgBox("Record Saved!")
            Call SYM00016_Load(Nothing, Nothing)

        ElseIf mode = "DelRow" Then


            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdSave.Enabled = Enq_right_local
            mmdDelRow.Enabled = Del_right_local

            cboDV.Enabled = False
            cboPV.Enabled = False
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

    Private Sub createComboBoxCell(ByVal cell As DataGridViewCell)
        Dim cboCell As New DataGridViewComboBoxCell
        Dim iCol As Integer = cell.ColumnIndex
        Dim iRow As Integer = cell.RowIndex
        Dim dgView As DataGridView = cell.DataGridView

        For Each dr As DataRow In rs_fmlInf.Tables("RESULT").Rows
            cboCell.Items.Add(dr.Item("yfi_fmlopt").ToString.Trim)
        Next
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
                ' User has changed the option
                If iCol = 5 Then
                    Me.DataGrid.Rows(iRow).Cells(iCol).Value = strSelItem
                    Me.DataGrid.Rows(iRow).Cells(iCol + 1).Value = rs_fmlInf.Tables("RESULT").Select("yfi_fmlopt = '" & strSelItem & "'")(0).Item("yfi_prcfml").ToString
                    Me.DataGrid.Rows(iRow).Cells(iCol + 2).Value = rs_fmlInf.Tables("RESULT").Select("yfi_fmlopt = '" & strSelItem & "'")(0).Item("yfi_fml").ToString
                ElseIf iCol = 8 Then
                    Me.DataGrid.Rows(iRow).Cells(iCol).Value = strSelItem
                    Me.DataGrid.Rows(iRow).Cells(iCol + 1).Value = rs_fmlInf.Tables("RESULT").Select("yfi_fmlopt = '" & strSelItem & "'")(0).Item("yfi_prcfml").ToString
                    Me.DataGrid.Rows(iRow).Cells(iCol + 2).Value = rs_fmlInf.Tables("RESULT").Select("yfi_fmlopt = '" & strSelItem & "'")(0).Item("yfi_fml").ToString
                End If
                AddHandler cboBox.SelectedIndexChanged, AddressOf cboOpt_SelectedIndexChanged

            End If
        End If
    End Sub

    Private Sub DataGrid_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGrid.EditingControlShowing

        If DataGrid.CurrentCell.ColumnIndex = 5 Or DataGrid.CurrentCell.ColumnIndex = 8 Then
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

        If Enq_right_local = False Then
            Exit Sub
        End If

        If Not e.RowIndex = -1 Then

            If e.ColumnIndex = 0 Then
                ' Toggle Delete
                If Not row.Cells("ymf_mkpopt").Value.ToString = "" Then
                    Call mmdDelRow_Click(sender, e)
                End If

            ElseIf e.ColumnIndex = 5 Or e.ColumnIndex = 8 Then
                If row.Cells("ymf_credat").Value.ToString = "" And row.Cells("ymf_status").Value.ToString = "" Then
                    If TypeOf (DataGrid.CurrentCell) Is DataGridViewTextBoxCell Then
                        createComboBoxCell(DataGrid.CurrentCell)
                        DataGrid.BeginEdit(True)

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

        strNewVal = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim

        If row.Cells(e.ColumnIndex).IsInEditMode Then

            If e.ColumnIndex = 5 Then
                If Not chkGrdCellValue(row.Cells("ymf_mkpopt"), "String", 5) Then
                    e.Cancel = True
                Else
                    For Each drr As DataGridViewRow In DataGrid.Rows
                        If drr.Index <> e.RowIndex Then
                            If drr.Cells("ymf_mkpopt").Value.ToString.ToUpper = strNewVal.ToUpper Then
                                MsgBox("Duplicated option code!")
                                e.Cancel = True
                                Exit For
                            End If
                        End If
                    Next
                End If
            End If

            If e.ColumnIndex = 8 Then
                If Not chkGrdCellValue(row.Cells("ymf_fmlopt"), "String", 5) Then
                    e.Cancel = True
                End If
            End If
        End If

    End Sub
    Private Sub mmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdInsRow.Click
        Dim dt As DataTable
        Dim dr As DataRow

        dt = rs_symrkfml.Tables("RESULT")
        For Each dr In dt.Rows
            If dr.Item("ymf_mkpopt").ToString.Trim = "" Then
                MsgBox("Please input option code.")
                Exit Sub
            End If
        Next

        dr = dt.NewRow
        dr.Item("ymf_status") = ""
        dr.Item("ymf_effdat") = System.DateTime.Now.ToString("MM/dd/yyyy")
        dt.Rows.Add(dr)

        For Each drr As DataGridViewRow In DataGrid.Rows
            If IsDBNull(drr.Cells(5).Value) Then
                DataGrid.CurrentCell = drr.Cells(5)
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
            If Not row.Cells("ymf_mkpopt").Value.ToString = "" Then
                If row.Cells("ymf_status").Value.ToString = "" Then
                    row.Cells("ymf_status").Value = "Y"
                    cellStyle.BackColor = Color.LightBlue
                Else
                    row.Cells("ymf_status").Value = ""
                    cellStyle.BackColor = Nothing
                End If
                row.DataGridView.CurrentRow.DefaultCellStyle = cellStyle
                Call setStatus("DelRow")
            End If
        End If

    End Sub


    Private Sub mmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mmdSave.Click
        If checkFocus(Me) Then Exit Sub
        Dim strDV, strPV As String
        Dim flgErr As Boolean = False
        Dim flgReAct As Boolean = False

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            save_ok = True
            bindSrc.EndEdit()
            For Each row As DataGridViewRow In DataGrid.Rows

                If row.Cells("ymf_status").Value.ToString = "" Then

                    If Not chkGrdCellValue(row.Cells("ymf_mkpopt"), "String", 5) Then
                        save_ok = False
                        flgReAct = True

                    ElseIf Not chkGrdCellValue(row.Cells("ymf_fmlopt"), "String", 5) Then
                        save_ok = False
                        flgReAct = True

                    Else
                        If row.Cells("ymf_credat").Value.ToString = "" Then
                            For Each drr As DataGridViewRow In DataGrid.Rows
                                If drr.Index <> row.Index Then
                                    If drr.Cells("ymf_mkpopt").Value.ToString.ToUpper = row.Cells("ymf_mkpopt").Value.ToString.ToUpper And _
                                       drr.Cells("ymf_status").Value.ToString = "" Then

                                        MsgBox("Duplicated option code " & drr.Cells("ymf_mkpopt").Value.ToString & "!")
                                        save_ok = False
                                        flgReAct = True
                                        row.DataGridView.CurrentCell = row.Cells("ymf_mkpopt")
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
                strDV = Split(cboDV.SelectedItem, " - ")(0).ToString.Replace("'", "''").Trim
                strPV = Split(cboPV.SelectedItem, " - ")(0).ToString.Replace("'", "''").Trim
                For Each dr As DataRow In rs_symrkfml.Tables("RESULT").Rows

                    If dr.RowState = DataRowState.Modified Then
                        If dr.Item("ymf_status") = "Y" Then
                            gspStr = "sp_physical_delete_SYMRKFML '" & gsCompany & "','" & _
                                        strDV & "','" & _
                                        strPV & "'," & _
                                        dr.Item("ymf_seq").ToString.Replace("'", "''").Trim
                        Else
                            gspStr = "sp_update_SYMRKFML '" & gsCompany & "','" & _
                                        strDV & "','" & _
                                        strPV & "'," & _
                                        dr.Item("ymf_seq").ToString.Replace("'", "''").Trim & ",'" & _
                                        dr.Item("ymf_mkpopt").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ymf_fmlopt").ToString.Replace("'", "''").Trim & "','" & _
                                        gsUsrID & "','" & _
                                        dr.Item("ymf_effdat").ToString.Replace("'", "''").Trim & "'"
                        End If
                    ElseIf dr.RowState = DataRowState.Added And Not dr.Item("ymf_status") = "Y" Then

                        If dr.Item("ymf_credat").ToString.Trim = "" Then
                            gspStr = "sp_insert_SYMRKFML '" & gsCompany & "','" & _
                                        strDV & "','" & _
                                        strPV & "','" & _
                                        dr.Item("ymf_mkpopt").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ymf_fmlopt").ToString.Replace("'", "''").Trim & "','" & _
                                        gsUsrID & "','" & _
                                        dr.Item("ymf_effdat").ToString.Replace("'", "''").Trim & "'"
                        End If
                    End If

                    If gspStr <> "" Then
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading SYM00016 sp_update_SYMRKFML : " & rtnStr)
                            flgErr = True
                            Exit For
                        End If
                        gspStr = ""
                    End If
                Next

                If Not flgErr Then
                    rs_symrkfml.AcceptChanges()
                    Call setStatus("Save")
                Else
                    save_ok = False
                    rs_symrkfml.RejectChanges()
                    MsgBox("Record Not Updated!")
                End If
            End If

        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub SYM00016_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim YNC As Integer
        Dim flgMod As Boolean = False

        bindSrc.EndEdit()
        For Each dr As DataRow In rs_symrkfml.Tables("RESULT").Rows
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

    Private Sub MmdExit_Click() Handles mmdExit.Click
        Me.Close()
    End Sub

  

End Class