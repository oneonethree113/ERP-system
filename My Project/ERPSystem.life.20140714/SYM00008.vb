Public Class SYM00008
    Inherits System.Windows.Forms.Form

    Dim rs_sysetinf As New DataSet
    Dim bindsrc As New BindingSource
    Dim save_ok As Boolean
    Dim CanModify As Boolean = True
    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean
    Dim intDesigner As String = "15"
    Dim strType As String

    Private Sub SYM00008_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Call AccessRight(Me.Name)
            Enq_right_local = Enq_right
            Del_right_local = Del_right

            Call FillComboType()

            strType = ""
            If Not rs_sysetinf Is Nothing Then
                rs_sysetinf = Nothing
            End If

            gspStr = "sp_select_SYSETINF_All '" & gsCompany & "',''"
            rtnLong = execute_SQLStatement(gspStr, rs_sysetinf, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00008 sp_select_SYSETINF_All : " & rtnStr)
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
        Dim dt As DataTable = rs_sysetinf.Tables("RESULT")

        If Not dt Is Nothing Then
            For Each dc As DataColumn In dt.Columns
                dc.ReadOnly = False
            Next
            For Each dr As DataRow In dt.Rows
                dr.Item("ysi_status") = ""
            Next
            rs_sysetinf.AcceptChanges()
        End If
    End Sub

    Private Sub FillComboType()

        cboType.Items.Clear()
        cboType.Items.Add("01 - Region")
        cboType.Items.Add("02 - Country")
        cboType.Items.Add("03 - Price Term")
        cboType.Items.Add("04 - Payment Term")
        cboType.Items.Add("05 - Unit of Measure")
        cboType.Items.Add("06 - Currency")
        cboType.Items.Add("07 - Construction Method")
        cboType.Items.Add("08 - Market Type")
        If gsCompany = "UCP" Then
            cboType.Items.Add("09 - Vendor Sub-Code")
        End If
        cboType.Items.Add("10 - Virtual Bin Loaction")
        cboType.Items.Add("11 - Remarks for Packing List")
        cboType.Items.Add("12 - Commission Term")
        cboType.Items.Add("13 - Nature(Customer & Vendor)")
        cboType.Items.Add("14 - Banks")
        cboType.Items.Add(intDesigner & " - Designer")
        cboType.Items.Add("16 - PRC Import Contract")
        cboType.Items.Add("17 - Cost Element Setup (CU)")
        cboType.Items.Add("18 - Customer Item Category Setup (CU)")
        cboType.Items.Add("19 - Quotation Season Code (QU)")
        cboType.Items.Add("20 - Item Nature (IM) - Internal")

        cboType.Items.Add("24 - Product Group (IM)")
        cboType.Items.Add("25 - Material (IM)")
        cboType.Items.Add("26 - Product Size Type (IM)")
        cboType.Items.Add("27 - Product Size Unit (IM)")
        cboType.Items.Add("28 - Product Icons (IM)")
        cboType.Items.Add("29 - Item Nature (IM) - External")

        cboType.Items.Add("30 - Transport Term (IM) - Internal")

    End Sub

    Private Sub cboType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboType.SelectedIndexChanged

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            strType = Me.cboType.SelectedItem.Trim.Substring(0, 2)

            If strType = "02" Then
                lblDesc.Text = "ISO3166 Internet Standard"
                lblDesc.Refresh()
            ElseIf strType = "06" Then
                lblDesc.Text = "ISO4217 Currency Standard"
                lblDesc.Refresh()
            Else
                lblDesc.Text = ""
                lblDesc.Refresh()
            End If

            If Not rs_sysetinf Is Nothing Then
                rs_sysetinf = Nothing
            End If

            gspStr = "sp_select_SYSETINF_All '" & gsCompany & "','" & strType & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_sysetinf, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00008 sp_select_SYSETINF_All : " & rtnStr)
            Else
                If rs_sysetinf.Tables("RESULT").Rows.Count = 0 Then
                    cmdInsRow.Enabled = Enq_right_local
                    cmdDelRow.Enabled = False
                Else
                    cmdInsRow.Enabled = False
                    cmdDelRow.Enabled = False
                    If Enq_right_local = True Then
                        cmdInsRow.Enabled = Enq_right_local
                        cmdDelRow.Enabled = True
                    End If
                End If
                Call setDataRowAttr()
                Call displayGrid()
            End If
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        Dim YNC As Integer
        Dim flgMod As Boolean = False

        bindsrc.EndEdit()
        For Each dr As DataRow In rs_sysetinf.Tables("RESULT").Rows
            If dr.RowState = DataRowState.Modified Or dr.RowState = DataRowState.Added Then
                flgMod = True
            End If
        Next

        If flgMod Then
            YNC = MessageBox.Show("Record has been modified. Do you want to save?", "Question", MessageBoxButtons.YesNoCancel)

            If YNC = Windows.Forms.DialogResult.Yes Then
                If Enq_right_local Then
                    Call cmdSave_Click(sender, e)

                    If save_ok Then
                        Call SYM00008_Load(Nothing, Nothing)
                    Else
                        Exit Sub
                    End If
                Else
                    MsgBox("Sorry! You have not right to save!")
                End If
            ElseIf YNC = Windows.Forms.DialogResult.No Then
                Call SYM00008_Load(Nothing, Nothing)

            ElseIf YNC = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
        Else
            Call SYM00008_Load(Nothing, Nothing)
        End If

    End Sub

    Private Sub displayGrid()
        Dim i As Integer
        Dim dv As DataView = rs_sysetinf.Tables("RESULT").DefaultView
        bindsrc.DataSource = dv

        With DataGrid
            .DataSource = Nothing
            .DataSource = bindsrc
            For i = 0 To .Columns.Count - 1

                Select Case i
                    Case 0
                        .Columns(i).Width = 40
                        .Columns(i).HeaderText = "Del"
                        .Columns(i).ReadOnly = True
                    Case 3
                        .Columns(i).Width = 100
                        .Columns(i).HeaderText = "Code"
                    Case 4
                        If strType = "05" Then
                            .Columns(i).Width = 200
                            .Columns(i).HeaderText = "English Description"
                        ElseIf strType = "06" Then
                            .Columns(i).Width = 200
                            .Columns(i).HeaderText = "Description"
                        Else
                            .Columns(i).Width = 300
                            .Columns(i).HeaderText = "Description"
                        End If
                        .Columns(i).ReadOnly = False
                    Case 5
                        If strType = "02" Then
                            .Columns(i).Width = 100
                            .Columns(i).HeaderText = "Region"
                        ElseIf strType = "05" Then
                            .Columns(i).Width = 200
                            .Columns(i).HeaderText = "Chinese Description"
                        Else
                            .Columns(i).Visible = False
                            .Columns(i).HeaderText = "Value"
                        End If
                        .Columns(i).ReadOnly = False
                    Case 6
                        .Columns(i).HeaderText = "Default"
                        .Columns(i).ReadOnly = True
                        If strType = "09" Or strType = intDesigner Or strType = "16" Then
                            .Columns(i).Visible = False
                        Else
                            .Columns(i).Width = 60
                        End If
                    Case 7
                        .Columns(i).HeaderText = "System"
                        .Columns(i).ReadOnly = True
                        If strType = "09" Or strType = intDesigner Or strType = "16" Then
                            .Columns(i).Visible = False
                        Else
                            .Columns(i).Width = 60
                        End If
                    Case 8
                        .Columns(i).HeaderText = "Buy Rate"
                        .Columns(i).ReadOnly = False
                        If strType = "06" Then
                            .Columns(i).Width = 110
                        Else
                            .Columns(i).Visible = False
                        End If
                    Case 9
                        .Columns(i).HeaderText = "Sell Rate"
                        .Columns(i).ReadOnly = False
                        If strType = "06" Then
                            .Columns(i).Width = 110
                        Else
                            .Columns(i).Visible = False
                        End If
                    Case Else
                        .Columns(i).Visible = False
                End Select
                .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i
        End With

        If Not dv.Count = 0 Then
            dv.Sort = "ysi_upddat desc"
            Dim drv As DataRowView = dv(0)
            Me.StatusBar.Items("lblRight").Text = Format(drv.Item("ysi_credat"), "MM/dd/yyyy") & " " & Format(drv.Item("ysi_upddat"), "MM/dd/yyyy") & " " & drv.Item("ysi_updusr")

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
            cmdExit.Enabled = True
            cmdClear.Enabled = True
            cmdInsRow.Enabled = False
            cmdDelRow.Enabled = False
            cmdSearch.Enabled = False

            cmdFirst.Enabled = False
            cmdLast.Enabled = False
            cmdNext.Enabled = False
            cmdPrevious.Enabled = False
            cboType.Enabled = True

            Call ResetDefaultDisp()
            Call SetStatusBar(mode)

        ElseIf mode = "InsRow" Then
            cmdCopy.Enabled = False
            cmdFind.Enabled = False
            cmdSave.Enabled = Enq_right_local
            cmdDelRow.Enabled = Del_right_local
            cboType.Enabled = False
            Call SetStatusBar(mode)

        ElseIf mode = "Save" Then
            Call ResetDefaultDisp()
            Call SetStatusBar(mode)
            MsgBox("Record Saved!")
            Call SYM00008_Load(Nothing, Nothing)

        ElseIf mode = "DelRow" Then
            cmdCopy.Enabled = False
            cmdFind.Enabled = False
            cmdSave.Enabled = Enq_right_local
            cmdDelRow.Enabled = Del_right_local
            cboType.Enabled = False
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
        Me.lblDesc.Text = ""
        Me.lblDesc.Refresh()
    End Sub

    Private Sub DataGrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGrid.CellClick
        Dim row As DataGridViewRow = DataGrid.CurrentRow
        Dim YN As Integer

        If Not e.RowIndex = -1 Then

            If e.ColumnIndex = 0 Then
                ' Toggle Delete
                If Not row.Cells("ysi_cde").Value.ToString = "" Then
                    Call cmdDelRow_Click(sender, e)
                End If

                ' Disable setup code change of existing record
            ElseIf e.ColumnIndex = 3 Then
                If row.Cells("ysi_credat").Value.ToString = "" And row.Cells("ysi_status").Value.ToString = "" Then
                    row.Cells(e.ColumnIndex).ReadOnly = False
                    DataGrid.BeginEdit(True)
                    cmdSave.Enabled = Enq_right_local
                    Me.cboType.Enabled = False
                Else
                    row.Cells(e.ColumnIndex).ReadOnly = True
                End If

                ' Toggle Default
            ElseIf e.ColumnIndex = 6 Then
                If row.Cells("ysi_status").Value.ToString = "" And row.Cells("ysi_def").Value.ToString = "N" Then
                    YN = MessageBox.Show("Do you want to change to default?", "Question", MessageBoxButtons.YesNo)
                    If YN = Windows.Forms.DialogResult.Yes Then
                        For Each dr As DataRow In rs_sysetinf.Tables("RESULT").Rows
                            If dr.Item("ysi_def").ToString = "Y" Then
                                dr.Item("ysi_def") = "N"
                            End If
                        Next
                        row.Cells("ysi_def").Value = "Y"
                        cmdSave.Enabled = Enq_right_local
                        Me.cboType.Enabled = False
                    End If
                End If

                ' Toggle System
            ElseIf e.ColumnIndex = 7 Then
                If row.Cells("ysi_sys").Value.ToString = "N" Then
                    row.Cells("ysi_sys").Value = "Y"
                Else
                    row.Cells("ysi_sys").Value = "N"
                End If
                cmdSave.Enabled = Enq_right_local
                Me.cboType.Enabled = False

            ElseIf e.ColumnIndex = 4 Or e.ColumnIndex = 5 Or e.ColumnIndex = 8 Or e.ColumnIndex = 9 Then
                DataGrid.BeginEdit(True)
                cmdSave.Enabled = Enq_right_local
                Me.cboType.Enabled = False
            End If
            End If

    End Sub

    Private Sub DataGrid_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DataGrid.CellValidating
        Dim row As DataGridViewRow = DataGrid.CurrentRow
        Dim strNewVal As String

        strNewVal = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim

        If row.Cells(e.ColumnIndex).IsInEditMode Then

            If e.ColumnIndex = 3 Then
                If Not chkGrdCellValue(row.Cells("ysi_cde"), "String", 6) Then
                    e.Cancel = True
                Else
                    For Each drr As DataGridViewRow In DataGrid.Rows
                        If drr.Index <> e.RowIndex Then
                            If drr.Cells("ysi_cde").Value.ToString = strNewVal Then
                                MsgBox("Duplicated setup code!")
                                e.Cancel = True
                                Exit For
                            End If
                        End If
                    Next
                End If
            End If

            If e.ColumnIndex = 4 Then
                If Not chkGrdCellValue(row.Cells("ysi_dsc"), "String", 200) Then
                    e.Cancel = True
                End If
            End If

            If e.ColumnIndex = 8 And strType = "06" Then
                If Not chkGrdCellValue(row.Cells("ysi_buyrat"), "+Numeric") Then
                    e.Cancel = True
                End If
            End If

            If e.ColumnIndex = 9 And strType = "06" Then
                If Not chkGrdCellValue(row.Cells("ysi_selrat"), "+Numeric") Then
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub cmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsRow.Click
        Dim dt As DataTable
        Dim dr As DataRow

        dt = rs_sysetinf.Tables("RESULT")
        For Each dr In dt.Rows
            If dr.Item("ysi_cde").ToString.Trim = "" Then
                MsgBox("Please input setup code.")
                Exit Sub
            End If
        Next

        dr = dt.NewRow
        dr.Item("ysi_status") = ""
        dr.Item("ysi_typ") = strType
        dr.Item("ysi_def") = "N"
        dr.Item("ysi_sys") = "N"
        dr.Item("ysi_buyrat") = "0.00000000000"
        dr.Item("ysi_selrat") = "0.00000000000"
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

    Private Sub cmdDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelRow.Click
        Dim row As DataGridViewRow = DataGrid.CurrentRow
        Dim cellStyle As New DataGridViewCellStyle

        ' Toggle Delete
        If Not row Is Nothing Then
            If Not (row.Cells("ysi_cde").Value.ToString = "" Or row.Cells("ysi_def").Value.ToString = "Y") Then
                If row.Cells("ysi_status").Value.ToString = "" Then
                    row.Cells("ysi_status").Value = "Y"
                    cellStyle.BackColor = Color.LightBlue
                Else
                    row.Cells("ysi_status").Value = ""
                    cellStyle.BackColor = Nothing
                End If
                row.DataGridView.CurrentRow.DefaultCellStyle = cellStyle
                Call setStatus("DelRow")
            End If
        End If

    End Sub

    Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim flgErr As Boolean = False

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            save_ok = True
            bindsrc.EndEdit()
            For Each row As DataGridViewRow In DataGrid.Rows

                If row.Cells("ysi_cde").Value.ToString = "" Then

                    If Not chkGrdCellValue(row.Cells("ysi_cde"), "String", 6) Then
                        save_ok = False

                    ElseIf Not chkGrdCellValue(row.Cells("ysi_dsc"), "String", 200) Then
                        save_ok = False

                    Else
                        If strType = "06" Then

                            If Not chkGrdCellValue(row.Cells("ysi_buyrat"), "+Numeric") Then
                                save_ok = False

                            ElseIf Not chkGrdCellValue(row.Cells("ysi_selrat"), "+Numeric") Then
                                save_ok = False

                            End If
                        End If

                        If row.Cells("ysi_credat").Value.ToString = "" Then
                            For Each drr As DataGridViewRow In DataGrid.Rows
                                If drr.Index <> row.Index Then
                                    If drr.Cells("ysi_cde").Value.ToString = row.Cells("ysi_cde").Value.ToString And _
                                       drr.Cells("ysi_status").Value.ToString = "" Then

                                        MsgBox("Duplicated setup code " & drr.Cells("ysi_cde").Value.ToString & "!")
                                        save_ok = False
                                        row.DataGridView.CurrentCell = row.Cells("ysi_cde")
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

                For Each dr As DataRow In rs_sysetinf.Tables("RESULT").Rows

                    If dr.RowState = DataRowState.Modified Then
                        If dr.Item("ysi_status") = "Y" Then
                            gspStr = "sp_physical_delete_SYSETINF '" & gsCompany & "','" & _
                                        strType & "','" & _
                                        dr.Item("ysi_cde").ToString.ToUpper.Replace("'", "''").Trim & "'"
                        Else
                            gspStr = "sp_update_SYSETINF_All '" & gsCompany & "','" & _
                                        strType & "','" & _
                                        dr.Item("ysi_cde").ToString.ToUpper.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ysi_dsc").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ysi_value").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ysi_def").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ysi_sys").ToString.Replace("'", "''").Trim & "'," & _
                                        dr.Item("ysi_buyrat").ToString.Replace("'", "''").Trim & "," & _
                                        dr.Item("ysi_selrat").ToString.Replace("'", "''").Trim & ",'" & _
                                        gsUsrID & "'"
                        End If
                    ElseIf dr.RowState = DataRowState.Added And Not dr.Item("ysi_status") = "Y" Then
                        If dr.Item("ysi_credat").ToString.Trim = "" Then
                            gspStr = "sp_insert_SYSETINF '" & gsCompany & "','" & _
                                        strType & "','" & _
                                        dr.Item("ysi_cde").ToString.ToUpper.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ysi_dsc").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ysi_value").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ysi_def").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ysi_sys").ToString.Replace("'", "''").Trim & "'," & _
                                        dr.Item("ysi_buyrat").ToString.Replace("'", "''").Trim & "," & _
                                        dr.Item("ysi_selrat").ToString.Replace("'", "''").Trim & ",'" & _
                                        gsUsrID & "'"
                        End If
                    End If

                    If gspStr <> "" Then
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading SYM00008 sp_update_SYSETINF_All : " & rtnStr)
                            flgErr = True
                            Exit For
                        End If
                        gspStr = ""
                    End If
                Next

                If Not flgErr Then
                    rs_sysetinf.AcceptChanges()
                    Call setStatus("Save")
                Else
                    save_ok = False
                    rs_sysetinf.RejectChanges()
                    MsgBox("Record Not Updated!")
                End If
            End If

        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub SYM00008_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim YNC As Integer
        Dim flgMod As Boolean = False

        bindsrc.EndEdit()
        For Each dr As DataRow In rs_sysetinf.Tables("RESULT").Rows
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

