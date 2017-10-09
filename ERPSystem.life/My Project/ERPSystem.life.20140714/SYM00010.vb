Public Class SYM00010
    Inherits System.Windows.Forms.Form

    Dim rs_sysalrep As New DataSet
    Dim rs_syusrid As New DataSet
    Dim rs_usrprf As New DataSet
    Dim bindSrc As New BindingSource
    Dim save_ok As Boolean
    Dim CanModify As Boolean = True
    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean

    Private Sub SYM00010_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Call AccessRight(Me.Name)
            Enq_right_local = Enq_right
            Del_right_local = Del_right

            ' Get user list
            gsCompany = "UCP"
            gspStr = "sp_select_SYUSERPRF_SYS '" & gsCompany & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_syusrid, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00010 sp_select_SYUSERPRF_SYS : " & rtnStr)
            Else
                ' Get sales rep. list
                gspStr = "sp_select_SYSALREP_ALL '" & gsCompany & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_sysalrep, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading SYM00010 sp_select_SYSALREP : " & rtnStr)
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
        Dim dt As DataTable = rs_sysalrep.Tables("RESULT")

        If Not dt Is Nothing Then
            For Each dc As DataColumn In dt.Columns
                dc.ReadOnly = False
            Next
            For Each dr As DataRow In dt.Rows
                dr.Item("ysr_status") = ""
            Next
            rs_sysalrep.AcceptChanges()
        End If
    End Sub

    Private Sub displayGrid()
        Dim i As Integer
        Dim dv As DataView = rs_sysalrep.Tables("RESULT").DefaultView
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
                        .Columns(i).Width = 80
                        .Columns(i).HeaderText = "Code"
                    Case 3
                        .Columns(i).Width = 120
                        .Columns(i).HeaderText = "User ID"
                    Case 4
                        .Columns(i).Width = 200
                        .Columns(i).HeaderText = "Sales Name"
                        .Columns(i).ReadOnly = True
                    Case 5
                        .Columns(i).Width = 140
                        .Columns(i).HeaderText = "Sales Manager"
                        .Columns(i).ReadOnly = True
                    Case 6
                        .Columns(i).Width = 80
                        .Columns(i).HeaderText = "Sales Team"
                        .Columns(i).ReadOnly = False
                    Case Else
                        .Columns(i).Visible = False
                End Select
                .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i
        End With

        If Not dv.Count = 0 Then
            dv.Sort = "ysr_upddat desc"
            Dim drv As DataRowView = dv(0)
            Me.StatusBar.Items("lblRight").Text = Format(drv.Item("ysr_credat"), "MM/dd/yyyy") & " " & Format(drv.Item("ysr_upddat"), "MM/dd/yyyy") & " " & drv.Item("ysr_updusr")

            dv.Sort = Nothing
        End If
    End Sub

    Private Sub setStatus(ByVal mode As String)

        If mode = "Init" Then
            cmdAdd.Enabled = False
            cmdSave.Enabled = False
            cmdDelete.Enabled = False
            cmdCopy.Enabled = False
            cmdFind.Enabled = False
            cmdInsRow.Enabled = Enq_right_local
            cmdDelRow.Enabled = Del_right_local
            cmdExit.Enabled = True
            cmdClear.Enabled = False
            cmdSearch.Enabled = False

            cmdFirst.Enabled = False
            cmdLast.Enabled = False
            cmdNext.Enabled = False
            cmdPrevious.Enabled = False

            Call ResetDefaultDisp()
            Call SetStatusBar(mode)

        ElseIf mode = "InsRow" Then
            cmdCopy.Enabled = False
            cmdFind.Enabled = False
            cmdSave.Enabled = Enq_right_local
            cmdDelRow.Enabled = Del_right_local
            Call SetStatusBar(mode)

        ElseIf mode = "Save" Then
            Call ResetDefaultDisp()
            Call SetStatusBar(mode)
            MsgBox("Record Saved!")
            Call SYM00010_Load(Nothing, Nothing)

        ElseIf mode = "DelRow" Then
            cmdCopy.Enabled = False
            cmdFind.Enabled = False
            cmdSave.Enabled = Enq_right_local
            cmdDelRow.Enabled = Del_right_local
            Call SetStatusBar(mode)

        ElseIf mode = "Clear" Then
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

    Private Sub getUserInfo(ByVal strUserID As String)

        gspStr = "sp_select_SYUSRPRF '" & gsCompany & "','" & strUserID & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_usrprf, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SYM00010 sp_select_SYUSRPRF : " & rtnStr)
        End If
    End Sub

    Private Sub createComboBoxCell(ByVal cell As DataGridViewCell)
        Dim cboCell As New DataGridViewComboBoxCell
        Dim iCol As Integer = cell.ColumnIndex
        Dim iRow As Integer = cell.RowIndex
        Dim dgView As DataGridView = cell.DataGridView

        For Each dr As DataRow In rs_syusrid.Tables("RESULT").Rows
            cboCell.Items.Add(dr.Item("yup_usrid").ToString)
        Next
        cboCell.DropDownWidth = 150
        cboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

        dgView.Rows(iRow).Cells(iCol) = cboCell
        dgView.Rows(iRow).Cells(iCol).ReadOnly = False
    End Sub

    Private Sub cboUser_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim dr(), drr() As DataRow
        Dim iRow As Integer = DataGrid.CurrentCell.RowIndex
        Dim iCol As Integer = DataGrid.CurrentCell.ColumnIndex ' iCol =3
        Dim strSelItem As String

        If TypeOf (Me.DataGrid.CurrentCell) Is DataGridViewComboBoxCell Then
            Dim cboBox As ComboBox = CType(sender, ComboBox)

            Call getUserInfo(cboBox.Text.Trim)
            dr = rs_usrprf.Tables("RESULT").Select("")

            If dr.Length > 0 Then

                strSelItem = cboBox.SelectedItem.ToString
                RemoveHandler cboBox.SelectedIndexChanged, AddressOf cboUser_SelectedIndexChanged
                Me.DataGrid.Rows(iRow).Cells(iCol).Value = strSelItem
                If dr(0).Item("yup_supid").ToString = "" Then
                    Me.DataGrid.Rows(iRow).Cells("ysr_dsc").Value = dr(0).Item("yup_usrnam").ToString
                    Me.DataGrid.Rows(iRow).Cells("ysr_salmgr").Value = ""
                Else
                    Call getUserInfo(dr(0).Item("yup_supid").ToString)
                    drr = rs_usrprf.Tables("RESULT").Select("")
                    If drr.Length > 0 Then
                        Me.DataGrid.Rows(iRow).Cells("ysr_dsc").Value = dr(0).Item("yup_usrnam").ToString
                        Me.DataGrid.Rows(iRow).Cells("ysr_salmgr").Value = drr(0).Item("yup_usrnam").ToString
                    Else
                        Me.DataGrid.Rows(iRow).Cells("ysr_dsc").Value = dr(0).Item("yup_usrnam").ToString
                        Me.DataGrid.Rows(iRow).Cells("ysr_salmgr").Value = ""
                    End If
                End If
                AddHandler cboBox.SelectedIndexChanged, AddressOf cboUser_SelectedIndexChanged
            End If
        End If
    End Sub

    Private Sub DataGrid_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGrid.EditingControlShowing

        If DataGrid.CurrentCell.ColumnIndex = 3 Then
            If TypeOf (DataGrid.CurrentCell) Is DataGridViewComboBoxCell Then
                Dim cboBox As ComboBox = CType(e.Control, ComboBox)
                If Not cboBox Is Nothing Then
                    RemoveHandler cboBox.SelectedIndexChanged, AddressOf cboUser_SelectedIndexChanged
                    AddHandler cboBox.SelectedIndexChanged, AddressOf cboUser_SelectedIndexChanged
                End If
            End If
        End If
    End Sub

    Private Sub DataGrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGrid.CellClick
        Dim row As DataGridViewRow = DataGrid.CurrentRow

        If Not e.RowIndex = -1 Then

            ' Toggle Delete
            If e.ColumnIndex = 0 Then
                If Not row.Cells("ysr_code1").Value.ToString = "" Then
                    Call cmdDelRow_Click(sender, e)
                End If

                ' Disable sales rep. code change of existing record
            ElseIf e.ColumnIndex = 2 Then
                If row.Cells("ysr_credat").Value.ToString = "" And row.Cells("ysr_status").Value.ToString = "" Then
                    row.Cells(e.ColumnIndex).ReadOnly = False
                    DataGrid.BeginEdit(True)
                    cmdSave.Enabled = Enq_right_local
                Else
                    row.Cells(e.ColumnIndex).ReadOnly = True
                End If

            ElseIf e.ColumnIndex = 3 Then
                If row.Cells("ysr_credat").Value.ToString = "" And row.Cells("ysr_status").Value.ToString = "" Then
                    If TypeOf (DataGrid.CurrentCell) Is DataGridViewTextBoxCell Then
                        createComboBoxCell(DataGrid.CurrentCell)
                        DataGrid.BeginEdit(True)
                        cmdSave.Enabled = Enq_right_local
                    End If
                Else
                    row.Cells(e.ColumnIndex).ReadOnly = True
                End If

                ElseIf e.ColumnIndex = 6 Then
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
                If Not chkGrdCellValue(row.Cells("ysr_code1"), "String", 5) Then
                    e.Cancel = True
                Else
                    For Each drr As DataGridViewRow In DataGrid.Rows
                        If drr.Index <> e.RowIndex Then
                            If drr.Cells("ysr_code1").Value.ToString = strNewVal Then
                                MsgBox("Duplicated sales rep. code!")
                                e.Cancel = True
                                Exit For
                            End If
                        End If
                    Next
                End If
            End If

            If e.ColumnIndex = 3 Then
                If Not chkGrdCellValue(row.Cells("ysr_code"), "String", 12) Then
                    e.Cancel = True
                Else
                    For Each drr As DataGridViewRow In DataGrid.Rows
                        If drr.Index <> e.RowIndex Then
                            If drr.Cells("ysr_code").Value.ToString = strNewVal Then
                                MsgBox("Duplicated user id with sales rep. code " & drr.Cells("ysr_code1").Value.ToString & "!")
                                e.Cancel = True
                                Exit For
                            End If
                        End If
                    Next
                End If
            End If

            If e.ColumnIndex = 6 Then
                If Not chkGrdCellValue(row.Cells("ysr_saltem"), "String", 6) Then
                    e.Cancel = True
                End If
            End If
        End If

    End Sub

    Private Sub cmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)	Handles cmdInsRow.Click
        Dim dt As DataTable
        Dim dr As DataRow

        dt = rs_sysalrep.Tables("RESULT")
        For Each dr In dt.Rows
            If dr.Item("ysr_code1").ToString.Trim = "" Then
                MsgBox("Please input sales rep. code.")
                Exit Sub
            End If
        Next

        dr = dt.NewRow
        dr.Item("ysr_status") = ""
        dt.Rows.Add(dr)

        For Each drr As DataGridViewRow In DataGrid.Rows
            If IsDBNull(drr.Cells(2).Value) Then
                DataGrid.CurrentCell = drr.Cells(2)
                DataGrid.CurrentCell.ReadOnly = False
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
            If Not row.Cells("ysr_code1").Value.ToString = "" Then
                If row.Cells("ysr_status").Value.ToString = "" Then
                    row.Cells("ysr_status").Value = "Y"
                    cellStyle.BackColor = Color.LightBlue
                Else
                    row.Cells("ysr_status").Value = ""
                    cellStyle.BackColor = Nothing
                End If
                row.DataGridView.CurrentRow.DefaultCellStyle = cellStyle
            End If
            Call setStatus("DelRow")
        End If

    End Sub

    Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim flgErr As Boolean = False
        Dim flgReAct As Boolean = False

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            save_ok = True
            bindSrc.EndEdit()
            For Each row As DataGridViewRow In DataGrid.Rows

                If row.Cells("ysr_status").Value.ToString = "" Then

                    If Not chkGrdCellValue(row.Cells("ysr_code1"), "String", 5) Then
                        save_ok = False

                    ElseIf Not chkGrdCellValue(row.Cells("ysr_code"), "String", 12) Then
                        save_ok = False
                        flgReAct = True

                    ElseIf Not chkGrdCellValue(row.Cells("ysr_saltem"), "String", 6) Then
                        save_ok = False

                    Else
                        If row.Cells("ysr_credat").Value.ToString = "" Then
                            For Each drr As DataGridViewRow In DataGrid.Rows
                                If drr.Index <> row.Index Then
                                    If drr.Cells("ysr_code").Value.ToString = row.Cells("ysr_code").Value.ToString And _
                                       drr.Cells("ysr_status").Value.ToString = "" Then
                                        MsgBox("Duplicated user id with sales rep. code " & drr.Cells("ysr_code1").Value.ToString & "!")
                                        save_ok = False
                                        flgReAct = True
                                        row.DataGridView.CurrentCell = row.Cells("ysr_code")
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
                For Each dr As DataRow In rs_sysalrep.Tables("RESULT").Rows

                    If dr.RowState = DataRowState.Modified Then
                        If dr.Item("ysr_status") = "Y" Then
                            gspStr = "sp_physical_delete_SYSALREP '" & gsCompany & "','" & _
                                        dr.Item("ysr_code1").ToString.ToUpper.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ysr_code").ToString.Replace("'", "''").Trim & "'"
                        Else
                            gspStr = "sp_update_SYSALREP '" & gsCompany & "','" & _
                                        dr.Item("ysr_code1").ToString.ToUpper.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ysr_code").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ysr_dsc").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ysr_salmgr").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ysr_saltem").ToString.ToUpper.Replace("'", "''").Trim & "','','" & _
                                        gsUsrID & "'"
                        End If
                    ElseIf dr.RowState = DataRowState.Added And Not dr.Item("ysr_status") = "Y" Then

                        If dr.Item("ysr_credat").ToString.Trim = "" Then
                            gspStr = "sp_insert_SYSALREP '" & gsCompany & "','" & _
                                        dr.Item("ysr_code1").ToString.ToUpper.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ysr_code").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ysr_dsc").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ysr_salmgr").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ysr_saltem").ToString.ToUpper.Replace("'", "''").Trim & "','','" & _
                                        gsUsrID & "'"
                        End If
                    End If

                    If gspStr <> "" Then
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading SYM00010 sp_update_SYSALREP : " & rtnStr)
                            flgErr = True
                            Exit For
                        End If
                        gspStr = ""
                    End If
                Next

                If Not flgErr Then
                    rs_sysalrep.AcceptChanges()
                    Call setStatus("Save")
                Else
                    save_ok = False
                    rs_sysalrep.RejectChanges()
                    MsgBox("Record Not Updated!")
                End If
            End If

        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub SYM00010_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim YNC As Integer
        Dim flgMod As Boolean = False

        bindSrc.EndEdit()
        For Each dr As DataRow In rs_sysalrep.Tables("RESULT").Rows
            If dr.RowState = DataRowState.Modified Or dr.RowState = DataRowState.Added Then
                flgMod = True
            End If
        Next

        If flgMod Then
            YNC = MessageBox.Show("Record has been modified. Do you want to save before exit?", "Question", MessageBoxButtons.YesNoCancel)

            If YNC = Windows.Forms.DialogResult.Yes Then
                If Enq_right_local Then
                    Call cmdSave_Click(sender, e)

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

    Private Sub CmdExit_Click() Handles cmdExit.Click
        Me.Close()
    End Sub

End Class