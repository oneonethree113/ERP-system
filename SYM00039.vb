Public Class SYM00039

    Inherits System.Windows.Forms.Form

    Dim rs_SYSALTQC As New DataSet
    Dim rs_CUBASINF_P As New DataSet
    Dim rs_list_SYSALINF As New DataSet
    Dim rs_usr As New DataSet



    Dim bindSrc As New BindingSource
    Dim save_ok As Boolean
    Dim CanModify As Boolean = True
    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean

    Private Sub SYM00039_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Call AccessRight(Me.Name)
            Enq_right_local = Enq_right
            Del_right_local = Del_right

            gspStr = "sp_select_SYSALTQC '" & gsCompany & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_SYSALTQC, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00039 sp_select_SYSALTQC : " & rtnStr)
            Else
                Call setDataRowAttr()
                Call displayGrid()
                Call setStatus("Init")



                Call fillcboPriCust()
                Call fillcboUsr()
                Call fillcboTeam()
                mmdSave.Enabled = Enq_right_local
            End If
            Call Formstartup(Me.Name)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub setDataRowAttr()
        Dim dt As DataTable = rs_SYSALTQC.Tables("RESULT")

        If Not dt Is Nothing Then
            For Each dc As DataColumn In dt.Columns
                dc.ReadOnly = False
            Next
            For Each dr As DataRow In dt.Rows
                dr.Item("yst_status") = ""
            Next
            rs_SYSALTQC.AcceptChanges()
        End If
    End Sub

    Private Sub displayGrid()
        Dim i As Integer
        DataGrid.DataSource = rs_SYSALTQC.Tables("RESULT")

        'Dim dv As DataView = rs_SYSALTQC.Tables("RESULT").DefaultView
        'bindSrc.DataSource = dv

        With DataGrid
            '.DataSource = Nothing
            '.DataSource = bindSrc
            For i = 0 To .Columns.Count - 1
                Select Case i
                    Case 0
                        .Columns(i).Width = 40
                        .Columns(i).HeaderText = "Del"
                        .Columns(i).ReadOnly = True
                    Case 2
                        .Columns(i).Width = 180 / 2
                        .Columns(i).HeaderText = "Sales Team"
                    Case 3
                        .Columns(i).Width = 500 / 2
                        .Columns(i).HeaderText = "Customer"
                        .Columns(i).ReadOnly = False
                    Case 4
                        .Columns(i).Width = 340 / 2
                        .Columns(i).HeaderText = "Team Leader"
                        .Columns(i).ReadOnly = False
                    Case 5
                        .Columns(i).Width = 340 / 2
                        .Columns(i).HeaderText = "Production/Shipment"
                        .Columns(i).ReadOnly = False
                    Case 6
                        .Columns(i).Width = 340 / 2
                        .Columns(i).HeaderText = "Sample Testing"
                        .Columns(i).ReadOnly = False
                    Case Else
                        .Columns(i).Visible = False
                End Select
                .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i
        End With

        Dim dv2 As DataView = rs_SYSALTQC.Tables("RESULT").DefaultView
        If Not dv2.Count = 0 Then
            dv2.Sort = "yst_upddat desc"
            Dim drv As DataRowView = dv2(0)
            Me.StatusBar.Items("lblRight").Text = Format(drv.Item("yst_credat"), "MM/dd/yyyy") & " " & Format(drv.Item("yst_upddat"), "MM/dd/yyyy") & " " & drv.Item("yst_updusr")

            dv2.Sort = Nothing
        End If
        'If Not dv.Count = 0 Then
        '    dv.Sort = "yst_upddat desc"
        '    Dim drv As DataRowView = dv(0)
        '    Me.StatusBar.Items("lblRight").Text = Format(drv.Item("yst_credat"), "MM/dd/yyyy") & " " & Format(drv.Item("yst_upddat"), "MM/dd/yyyy") & " " & drv.Item("yst_updusr")

        '    dv.Sort = Nothing
        'End If
    End Sub

    Private Sub setStatus(ByVal mode As String)

        If mode = "Init" Then
            mmdAdd.Enabled = False
            mmdSave.Enabled = False
            mmdDelete.Enabled = False
            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdInsRow.Enabled = Enq_right_local
            mmdDelRow.Enabled = False

            mmdExit.Enabled = True
            mmdClear.Enabled = False
            mmdSearch.Enabled = False


            Call ResetDefaultDisp()
            Call SetStatusBar(mode)

            mmdPrint.Enabled = False
            mmdAttach.Enabled = False
            mmdFunction.Enabled = False
            mmdLink.Enabled = False
        ElseIf mode = "InsRow" Then
            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdSave.Enabled = Enq_right_local
            'cmdDelRow.Enabled = Del_right_local
            Call SetStatusBar(mode)

        ElseIf mode = "Save" Then
            Call ResetDefaultDisp()

            Call SYM00039_Load(Nothing, Nothing)
            Call SetStatusBar(mode)

        ElseIf mode = "DelRow" Then
            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdSave.Enabled = Enq_right_local
            'cmdDelRow.Enabled = Del_right_local
            Call SetStatusBar(mode)

        ElseIf mode = "Clear" Then
            Call ResetDefaultDisp()
            Call SetStatusBar(mode)
        End If

        ' If Not CanModify Then
        'cmdAdd.Enabled = False
        'cmdSave.Enabled = False
        'cmdDelete.Enabled = False
        'cmdInsRow.Enabled = False
        'cmdDelRow.Enabled = False

        'Call ResetDefaultDisp()
        If Not Enq_right_local Then
            Call SetStatusBar("ReadOnly")
        End If
    End Sub

    Private Sub SetStatusBar(ByVal mode As String)

        If mode = "Init" Then
            Me.StatusBar.Items("lblLeft").Text = "Initialized  "
        ElseIf mode = "InsRow" Then
            Me.StatusBar.Items("lblLeft").Text = "Insert Row"
        ElseIf mode = "Updating" Then
            Me.StatusBar.Items("lblLeft").Text = "Updated "
        ElseIf mode = "Save" Then
            Me.StatusBar.Items("lblLeft").Text = "Record Saved"
        ElseIf mode = "DelRow" Then
            Me.StatusBar.Items("lblLeft").Text = "Record Row Deleted"
        ElseIf mode = "ReadOnly" Then
            Me.StatusBar.Items("lblLeft").Text = "Read Only  "
        ElseIf mode = "Clear" Then
            Me.StatusBar.Items("lblLeft").Text = "Cleared  "
        End If

    End Sub

    Private Sub ResetDefaultDisp()
        Me.StatusBar.Items("lblLeft").Text = ""
    End Sub

    Private Sub txtFml_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If DataGrid.CurrentCell.ColumnIndex = 4 Then
            If Not (e.KeyChar.ToString = vbBack Or e.KeyChar.ToString = "/" Or e.KeyChar.ToString = "*" Or e.KeyChar.ToString = "." Or (e.KeyChar.ToString >= "0" And e.KeyChar.ToString <= "9")) Then
                e.KeyChar = ""
            End If
        End If
    End Sub

    Private Sub DataGrid_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGrid.DataError
        Try
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DataGrid_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGrid.EditingControlShowing

        'If DataGrid.CurrentCell.ColumnIndex = 4 Then
        '    If TypeOf (DataGrid.CurrentCell) Is DataGridViewTextBoxCell Then
        '        Dim txtBox As TextBox = CType(e.Control, TextBox)
        '        If Not txtBox Is Nothing Then
        '            RemoveHandler txtBox.KeyPress, AddressOf txtFml_KeyPress
        '            AddHandler txtBox.KeyPress, AddressOf txtFml_KeyPress
        '        End If
        '    End If
        'End If
    End Sub

    Private Sub DataGrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGrid.CellClick



        Dim row As DataGridViewRow = DataGrid.CurrentRow

        If Not e.RowIndex = -1 Then

            If DataGrid.RowCount = 0 Then
                Exit Sub
            End If

            Select Case DataGrid.CurrentCell.ColumnIndex
                Case 0
                    '                    MsgBox(rs_SYSALTQC.Tables("result").Rows(DataGrid.CurrentCell.RowIndex)(0))
                    If rs_SYSALTQC.Tables("result").Rows(DataGrid.CurrentCell.RowIndex)(0) = "Y" Then
                        rs_SYSALTQC.Tables("result").Rows(DataGrid.CurrentCell.RowIndex)(0) = "N"
                    Else
                        rs_SYSALTQC.Tables("result").Rows(DataGrid.CurrentCell.RowIndex)(0) = "Y"
                    End If

                Case 2
                    comboBoxCell(DataGrid, "Sal")
                Case 3
                    comboBoxCell(DataGrid, "Cus")
                Case 4
                    comboBoxCell(DataGrid, "Usr")
                Case 5
                    comboBoxCell(DataGrid, "Usr")
                Case 6
                    comboBoxCell(DataGrid, "Usr")

            End Select


        End If
    End Sub

    'Private Sub DataGrid_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DataGrid.CellValidating
    '    Dim row As DataGridViewRow = DataGrid.CurrentRow
    '    Dim strNewVal As String

    '    strNewVal = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim

    '    If row.Cells(e.ColumnIndex).IsInEditMode Then

    '        If e.ColumnIndex = 2 Then
    '            If Not chkGrdCellValue(row.Cells("yst_team"), "String", 5) Then
    '                e.Cancel = True
    '            Else
    '                For Each drr As DataGridViewRow In DataGrid.Rows
    '                    If drr.Index <> e.RowIndex Then
    '                        If drr.Cells("yst_team").Value.ToString.ToUpper = strNewVal.ToUpper Then
    '                            MsgBox("Duplicated option code!")
    '                            e.Cancel = True
    '                            Exit For
    '                        End If
    '                    End If
    '                Next
    '            End If
    '        End If

    '        If e.ColumnIndex = 3 Then
    '            If strNewVal.Length > 50 Then
    '                MsgBox("Exceed field length!")
    '                e.Cancel = True
    '            End If
    '        End If

    '        If e.ColumnIndex = 4 Then
    '            If Not chkGrdCellValue(row.Cells("yst_fml"), "String", 300) Then
    '                e.Cancel = True
    '            End If
    '        End If
    '    End If

    'End Sub

    Private Sub mmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdInsRow.Click
        Dim dt As DataTable
        Dim dr As DataRow

        dt = rs_SYSALTQC.Tables("RESULT")
        For Each dr In dt.Rows
        Next

        dr = dt.NewRow
        dr.Item("yst_status") = ""
        dt.Rows.Add(dr)
        Call setStatus("InsRow")
    End Sub

    Private Sub mmdDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdDelRow.Click
        'Dim row As DataGridViewRow = DataGrid.CurrentRow
        'Dim cellStyle As New DataGridViewCellStyle

        '' Toggle Delete
        'If Not row Is Nothing Then
        '    If Not row.Cells("yst_team").Value.ToString = "" Then
        '        If row.Cells("yst_status").Value.ToString = "" Then
        '            row.Cells("yst_status").Value = "Y"
        '            cellStyle.BackColor = Color.LightBlue
        '        Else
        '            row.Cells("yst_status").Value = ""
        '            cellStyle.BackColor = Nothing
        '        End If
        '        row.DataGridView.CurrentRow.DefaultCellStyle = cellStyle
        '    End If
        '    Call setStatus("DelRow")
        'End If

    End Sub

    Private Sub mmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mmdSave.Click
        Dim flgErr As Boolean = False
        Dim tmp_count As Integer = 0

        For Each dr As DataRow In rs_SYSALTQC.Tables("RESULT").Rows ''check if the rows fill complete information
            If (dr.Item("yst_team").ToString.Replace("'", "''").Trim = "" Or dr.Item("yst_cus").ToString.Replace("'", "''").Trim = "" _
            Or dr.Item("yst_leader").ToString.Replace("'", "''").Trim = "" Or dr.Item("yst_prdshp").ToString.Replace("'", "''").Trim = "" _
            Or dr.Item("yst_smptst").ToString.Replace("'", "''").Trim = "") And Not dr.Item("yst_status") = "Y" Then
                MsgBox("Please fill in complete information")
                Exit Sub
            End If
        Next

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            save_ok = True
            bindSrc.EndEdit()
            'The following for loop seems to do nothing and meningless, so it is commaned

            'For Each row As DataGridViewRow In DataGrid.Rows
            '    If row.Cells("yst_status").Value.ToString = "" Then
            '    End If
            '    If Not save_ok Then
            '        Exit For
            '    End If
            'Next

            If Not save_ok Then
                DataGrid.BeginEdit(True)
                Exit Sub
            Else
                gspStr = ""
                For Each dr As DataRow In rs_SYSALTQC.Tables("RESULT").Rows

                    If dr.RowState = DataRowState.Modified Then
                        'PS: the PK of the record is dr.Item("yst_seq")
                        If dr.Item("yst_status") = "Y" Then
                            'Delete the record 
                            tmp_count = tmp_count + 1
                            gspStr = "sp_physical_delete_SYSALTQC '" & gsCompany & "','" & _
                                        dr.Item("yst_team").ToString.ToUpper.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yst_cus").ToString.ToUpper.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yst_seq").ToString.ToUpper.Replace("'", "''").Trim & "'"
                        Else
                            'Update the record 
                            tmp_count = tmp_count + 1
                            gspStr = "sp_update_SYSALTQC '" & gsCompany & "','" & _
                                        dr.Item("yst_team").ToString.ToUpper.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yst_cus").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yst_leader").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yst_prdshp").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yst_smptst").ToString.Replace("'", "''").Trim & "','" & _
                                        gsUsrID & "','" & _
                                        dr.Item("yst_seq").ToString.ToUpper.Replace("'", "''").Trim & "'" 'the gsUsrID will be used to updated the "yst_updusr" column
                        End If
                    ElseIf dr.RowState = DataRowState.Added And Not dr.Item("yst_status") = "Y" Then
                        If dr.Item("yst_credat").ToString.Trim = "" Then
                            tmp_count = tmp_count + 1
                            gspStr = "sp_insert_SYSALTQC '" & gsCompany & "','" & _
                                        dr.Item("yst_team").ToString.ToUpper.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yst_cus").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yst_leader").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yst_prdshp").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yst_smptst").ToString.Replace("'", "''").Trim & "','" & _
                                        gsUsrID & "'"
                        End If

                    Else
                        'Do nothing becuase the record is created and deleted at the same time

                        'gspStr = "sp_update_SYSALTQC '" & gsCompany & "','" & _
                        '            dr.Item("yst_team").ToString.ToUpper.Replace("'", "''").Trim & "','" & _
                        '            dr.Item("yst_cus").ToString.Replace("'", "''").Trim & "','" & _
                        '            dr.Item("yst_leader").ToString.Replace("'", "''").Trim & "','" & _
                        '            dr.Item("yst_prdshp").ToString.Replace("'", "''").Trim & "','" & _
                        '            dr.Item("yst_smptst").ToString.Replace("'", "''").Trim & "','" & _
                        '            gsUsrID & "'"
                        'tmp_count = tmp_count + 1

                    End If

                    If gspStr <> "" Then
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading SYM00039 sp_update_SYSALTQC : " & rtnStr)
                            flgErr = True
                            Exit For
                        End If
                        gspStr = ""
                    End If
                Next

                If Not flgErr Then
                    rs_SYSALTQC.AcceptChanges()
                    Call setStatus("Save")
                    If tmp_count > 0 Then
                        MsgBox("Record Saved!")
                    Else
                        MsgBox("No Record Updated!")
                    End If
                Else
                    save_ok = False
                    rs_SYSALTQC.RejectChanges()
                    MsgBox("Record Not Updated!")
                End If
            End If

        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub SYM00039_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Dim YNC As Integer
        'Dim flgMod As Boolean = False

        'bindSrc.EndEdit()
        'For Each dr As DataRow In rs_SYSALTQC.Tables("RESULT").Rows
        '    If dr.RowState = DataRowState.Modified Or dr.RowState = DataRowState.Added Then
        '        flgMod = True
        '    End If
        'Next

        'If flgMod Then
        '    YNC = MessageBox.Show("Record has been modified. Do you want to save before exit?", "Question", MessageBoxButtons.YesNoCancel)

        '    If YNC = Windows.Forms.DialogResult.Yes Then
        '        If Enq_right_local Then
        '            Call cmdSave_Click(sender, e)

        '            If save_ok Then
        '                e.Cancel = False
        '            Else
        '                e.Cancel = True
        '            End If
        '        Else
        '            MsgBox("Sorry! You have not right to save!")
        '        End If
        '    ElseIf YNC = Windows.Forms.DialogResult.No Then
        '        e.Cancel = False
        '    ElseIf YNC = Windows.Forms.DialogResult.Cancel Then
        '        e.Cancel = True
        '    End If
        'End If

    End Sub

    Private Sub mmdExit_Click() Handles mmdExit.Click
        Me.Close()
    End Sub
    Private Sub comboBoxCell(ByVal dgv As DataGridView, ByVal typ As String)
        Dim cboCell As New DataGridViewComboBoxCell

        Dim iCol As Integer = dgv.CurrentCell.ColumnIndex
        Dim iRow As Integer = dgv.CurrentCell.RowIndex

        Dim row As DataGridViewRow = dgv.CurrentRow

        'dgv.Rows(iRow).Cells(iCol).ReadOnly = True

        Dim i As Integer

        Select Case typ
            Case "Sal"
                cboCell.Items.Add("Team 1")
                cboCell.Items.Add("Team 2")
                cboCell.Items.Add("Team 3")
                cboCell.Items.Add("Team 4")
                For i = 0 To rs_list_SYSALINF.Tables("RESULT").Rows.Count - 1
                    cboCell.Items.Add("Team " & rs_list_SYSALINF.Tables("RESULT").Rows(i).Item("ssi_saltem"))
                Next i
            Case "Cus"

                Dim dr() As DataRow
                dr = rs_CUBASINF_P.Tables("RESULT").Select("cbi_cusno >= '50000'")
                If dr.Length > 0 Then
                    cboCell.Items.Clear()
                    For j As Integer = 0 To dr.Length - 1
                        cboCell.Items.Add(dr(j).Item("cbi_cusno") & " - " & dr(j).Item("cbi_cussna"))
                    Next
                End If

            Case "Usr"
                For i = 0 To rs_usr.Tables("RESULT").Rows.Count - 1
                    cboCell.Items.Add(rs_usr.Tables("RESULT").Rows(i).Item("yup_usrid"))
                Next i



        End Select

        cboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox

        dgv.Rows(iRow).Cells(iCol) = cboCell
        dgv.Rows(iRow).Cells(iCol).ReadOnly = False

    End Sub


    Private Sub fillcboPriCust()
        gspStr = "sp_select_CUBASINF_P '','Primary'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_P, rtnStr)
        gspStr = ""

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_select_CUBASINF_P " & rtnStr)
        End If

    End Sub


    Private Sub fillcboUsr()
        gspStr = "sp_select_SYUSRPRF_All '' "
        rtnLong = execute_SQLStatement(gspStr, rs_usr, rtnStr)
        gspStr = ""

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_select_SYUSRPRF_All  " & rtnStr)
        End If


    End Sub

    Private Sub fillcboTeam()
        gspStr = "sp_list_SYSALINF '','TEAM'"
        rtnLong = execute_SQLStatement(gspStr, rs_list_SYSALINF, rtnStr)
        gspStr = ""

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_list_SYSALINF  " & rtnStr)
        End If

    End Sub


    Private Sub mmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdExit.Click

    End Sub
End Class

