Public Class SYM00004

    Dim rs_sylneinf As New DataSet
    Dim rs_sycatfml As New DataSet
    Dim rs_syfmlinf As New DataSet
    Dim rs_vnbasinf As New DataSet
    Dim rs_sysetinf As New DataSet
    Dim rs_sycatlvl As New DataSet

    Dim bindSrc As New BindingSource
    Dim save_ok As Boolean
    Dim CanModify As Boolean = True
    Dim Add_flag As Boolean
    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean

    Private Sub SYM00004_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Call AccessRight(Me.Name)
            Enq_right_local = Enq_right
            Del_right_local = Del_right

            gspStr = "sp_list_VNBASINF '" & gsCompany & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_vnbasinf, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00004 sp_list_VNBASINF : " & rtnStr)
                Exit Sub
            End If

            gspStr = "sp_select_SYSETINF '" & gsCompany & "','15'"
            rtnLong = execute_SQLStatement(gspStr, rs_sysetinf, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00004 sp_select_SYSETINF : " & rtnStr)
                Exit Sub
            End If

            gspStr = "sp_select_SYCATCDE_level '" & gsCompany & "','4'"
            rtnLong = execute_SQLStatement(gspStr, rs_sycatlvl, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00004 sp_select_SYCATCDE_level : " & rtnStr)
                Exit Sub
            End If

            gspStr = "sp_select_SYLNEINF_SYM00004 '" & gsCompany & "',''"
            rtnLong = execute_SQLStatement(gspStr, rs_sylneinf, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00004 sp_select_SYLNEINF_SYM00004 : " & rtnStr)
                Exit Sub
            End If

            gspStr = "sp_list_SYFMLINF '" & gsCompany & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_syfmlinf, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00004 sp_list_SYFMLINF : " & rtnStr)
                Exit Sub
            End If

            gspStr = "sp_select_SYCATFML '" & gsCompany & "',''"
            rtnLong = execute_SQLStatement(gspStr, rs_sycatfml, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00004 sp_select_SYCATFML : " & rtnStr)
                Exit Sub
            Else
                cboDesign.Items.Clear()
                cboFml.Items.Clear()
                cboPcFac.Items.Clear()
                Txtlnedsc.Text = ""
                txtFromApply.Text = ""
                txtToApply.Text = ""
                Add_flag = False
                Call setDataRowAttr()
                Call displayGrid()
                Call setStatus("Init")
                Call Formstartup(Me.Name)
                Txtlne.Focus()
            End If
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            If Txtlne.Text.Trim = "" Then
                MsgBox("Please input Product Line/Season Code.")
            Else
                gspStr = "sp_select_SYLNEINF_SYM00004 '" & gsCompany & "','" & Txtlne.Text.Trim & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_sylneinf, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading SYM00004 sp_select_SYLNEINF_SYM00004 : " & rtnStr)
                Else
                    If rs_sylneinf.Tables("RESULT").Rows.Count > 0 Then
                        MsgBox("Product Line/Season Code is already existed.")
                        Exit Sub
                    Else
                        gspStr = "sp_select_SYCATFML '" & gsCompany & "',''"
                        rtnLong = execute_SQLStatement(gspStr, rs_sycatfml, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading SYM00004 sp_select_SYCATFML : " & rtnStr)
                        Else
                            Call setDataRowAttr()
                            Call displayGrid()
                            Add_flag = True
                            cmdInsRow.Enabled = Enq_right_local
                            cmdDelRow.Enabled = False
                            cmdSave.Enabled = Enq_right_local
                            cmdAdd.Enabled = False
                            Txtlne.Enabled = False
                            Call FillComboFml()
                            Call FillComboPCFac("")
                            Call FillComboDesigner("")
                        End If
                    End If
                End If
            End If

        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try

    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        Dim dtr() As DataRow

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            If Not Txtlne.Text.Trim = "" Then

                gspStr = "sp_select_SYLNEINF_SYM00004 '" & gsCompany & "','" & Txtlne.Text.Trim & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_sylneinf, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading SYM00004 sp_select_SYLNEINF_SYM00004 : " & rtnStr)
                Else
                    gspStr = "sp_select_SYCATFML '" & gsCompany & "','" & Txtlne.Text.Trim & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs_sycatfml, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading SYM00004 sp_select_SYCATFML : " & rtnStr)
                    Else
                        Call setDataRowAttr()
                        Call displayGrid()

                        dtr = rs_sylneinf.Tables("RESULT").Select("")
                        If dtr.Length > 0 Then
                            Txtlne.Text = dtr(0).Item("yli_lnecde")
                            Txtlnedsc.Text = dtr(0).Item("yli_lnedsc")
                            Txtlne.Enabled = False

                            If gsDefaultCompany = "UCP" Then
                                cmdInsRow.Enabled = True
                                cmdDelRow.Enabled = True
                            Else
                                cmdInsRow.Enabled = Enq_right_local
                                cmdDelRow.Enabled = Del_right_local
                            End If
                            cmdSave.Enabled = Enq_right_local
                            cmdAdd.Enabled = False

                            Call FillComboFml()
                            Call FillComboPCFac(dtr(0).Item("yli_pcfty"))
                            Call FillComboDesigner(dtr(0).Item("yli_dsgcde"))
                        Else
                            MsgBox("No record found")
                            Txtlne.Focus()
                        End If
                    End If
                End If
            Else
                MsgBox("Please input product line/season code")
            End If

        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub setDataRowAttr()
        Dim i As Integer

        If Not rs_sylneinf.Tables("RESULT") Is Nothing Then
            For Each dc As DataColumn In rs_sylneinf.Tables("RESULT").Columns
                dc.ReadOnly = False
            Next
            For Each dr As DataRow In rs_sylneinf.Tables("RESULT").Rows
                dr.Item("yci_status") = ""
            Next
            rs_sylneinf.AcceptChanges()
        End If

        If Not rs_sycatfml.Tables("RESULT") Is Nothing Then
            For Each dc As DataColumn In rs_sycatfml.Tables("RESULT").Columns
                dc.ReadOnly = False
            Next
            For Each dr As DataRow In rs_sycatfml.Tables("RESULT").Rows
                i += 1
                dr.Item("yaf_status") = ""
                dr.Item("no") = i
            Next
            rs_sycatfml.AcceptChanges()
        End If
    End Sub

    Private Sub displayGrid()
        Dim i As Integer
        Dim dv As DataView = rs_sycatfml.Tables("RESULT").DefaultView
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
                        .Columns(i).Width = 50
                        .Columns(i).HeaderText = "No"
                    Case 4
                        .Columns(i).Width = 250
                        .Columns(i).HeaderText = "Category Code Level 4"
                    Case 5
                        .Columns(i).Width = 250
                        .Columns(i).HeaderText = "Formula"
                    Case Else
                        .Columns(i).Visible = False
                End Select
                .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i
        End With

        If Not dv.Count = 0 Then
            dv.Sort = "yaf_upddat desc"
            Dim drv As DataRowView = dv(0)
            Me.StatusBar.Items("lblRight").Text = Format(drv.Item("yaf_credat"), "MM/dd/yyyy") & " " & Format(drv.Item("yaf_upddat"), "MM/dd/yyyy") & " " & drv.Item("yaf_updusr")

            dv.Sort = Nothing
        End If
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
            cmdSearch.Enabled = False

            cmdFirst.Enabled = False
            cmdLast.Enabled = False
            cmdNext.Enabled = False
            cmdPrevious.Enabled = False
            Txtlne.Enabled = True

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
            Call SYM00004_Load(Nothing, Nothing)

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

    Private Sub cmdApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApply.Click
        Dim strLnFr, strLnTo As String

        strLnFr = txtFromApply.Text.Trim
        strLnTo = txtToApply.Text.Trim

        If strLnFr <> "" AndAlso IsNumeric(strLnFr) AndAlso strLnFr >= 0 Then

            If strLnTo <> "" AndAlso IsNumeric(strLnTo) AndAlso strLnTo >= 0 Then

                If Not cboFml.SelectedItem Is Nothing AndAlso strLnTo >= strLnFr Then

                    For Each dr As DataRow In rs_sycatfml.Tables("RESULT").Rows
                        If dr.Item("no") >= strLnFr And dr.Item("no") <= strLnTo Then
                            dr.Item("yaf_fmlopt") = cboFml.SelectedItem
                        End If
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        Dim YNC As Integer
        Dim flgMod As Boolean = False

        bindSrc.EndEdit()
        If Not rs_sycatfml.Tables("RESULT") Is Nothing Then
            For Each dr As DataRow In rs_sycatfml.Tables("RESULT").Rows
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
                        Call SYM00004_Load(Nothing, Nothing)
                    Else
                        Exit Sub
                    End If
                Else
                    MsgBox("Sorry! You have not right to save!")
                End If
            ElseIf YNC = Windows.Forms.DialogResult.No Then
                Call SYM00004_Load(Nothing, Nothing)

            ElseIf YNC = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
        Else
            Call SYM00004_Load(Nothing, Nothing)
        End If

    End Sub

    Private Sub FillComboFml()

        Me.cboFml.Items.Clear()
        For Each dr As DataRow In rs_syfmlinf.Tables("RESULT").Rows
            Me.cboFml.Items.Add(dr.Item("yfi_fmlopt").ToString & " - " & dr.Item("yfi_fml").ToString)
        Next
    End Sub

    Private Sub FillComboPCFac(ByVal strPCFac As String)
        Dim dr() As DataRow
        Dim i As Integer

        Me.cboPcFac.Items.Clear()
        dr = rs_vnbasinf.Tables("RESULT").Select("vbi_venno >= 'A'")
        For i = 0 To dr.Length - 1
            Me.cboPcFac.Items.Add(dr(i).Item("vbi_venno").ToString & " - " & dr(i).Item("vbi_vensna").ToString)
        Next
        Me.cboPcFac.SelectedItem = strPCFac

    End Sub

    Private Sub FillComboDesigner(ByVal strDesign As String)
        Dim dr() As DataRow
        Dim i As Integer

        Me.cboDesign.Items.Clear()
        dr = rs_sysetinf.Tables("RESULT").Select("")
        For i = 0 To dr.Length - 1
            Me.cboDesign.Items.Add(dr(i).Item("ysi_cde").ToString & " - " & dr(i).Item("ysi_dsc").ToString)
        Next
        Me.cboDesign.SelectedItem = strDesign

    End Sub

    Private Sub createComboBoxCell(ByVal cell As DataGridViewCell)
        Dim cboCell As New DataGridViewComboBoxCell
        Dim iCol As Integer = cell.ColumnIndex
        Dim iRow As Integer = cell.RowIndex
        Dim dgView As DataGridView = cell.DataGridView

        If iCol = 4 Then
            For Each dr As DataRow In rs_sycatlvl.Tables("RESULT").Rows
                cboCell.Items.Add(dr.Item("ycc_catcde").ToString.Trim)
            Next
        ElseIf iCol = 5 Then
            For Each dr As DataRow In rs_syfmlinf.Tables("RESULT").Rows
                cboCell.Items.Add(dr.Item("yfi_fmlopt").ToString.Trim & " - " & dr.Item("yfi_fml").ToString.Trim)
            Next
        End If

        cboCell.DropDownWidth = 150
        cboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

        dgView.Rows(iRow).Cells(iCol) = cboCell
        dgView.Rows(iRow).Cells(iCol).ReadOnly = False
    End Sub

    Private Sub cboOpt_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim iCol As Integer = DataGrid.CurrentCell.ColumnIndex
        Dim iRow As Integer = DataGrid.CurrentCell.RowIndex
        Dim strSelItem As String

        If TypeOf (Me.DataGrid.CurrentCell) Is DataGridViewComboBoxCell Then
            Dim cboBox As ComboBox = CType(sender, ComboBox)
            If Not cboBox Is Nothing AndAlso Not cboBox.SelectedItem Is Nothing Then

                ' User has changed the option
                strSelItem = cboBox.SelectedItem.ToString
                RemoveHandler cboBox.SelectedIndexChanged, AddressOf cboOpt_SelectedIndexChanged
                If iCol = 4 Then
                    Me.DataGrid.Rows(iRow).Cells("yaf_catcde").Value = strSelItem
                ElseIf iCol = 5 Then
                    Me.DataGrid.Rows(iRow).Cells("yaf_fmlopt").Value = strSelItem
                End If
                AddHandler cboBox.SelectedIndexChanged, AddressOf cboOpt_SelectedIndexChanged
            End If
        End If
    End Sub

    Private Sub DataGrid_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGrid.EditingControlShowing

        If DataGrid.CurrentCell.ColumnIndex = 4 Or DataGrid.CurrentCell.ColumnIndex = 5 Then
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

        If Not e.RowIndex = -1 Then

            If e.ColumnIndex = 0 Then
                ' Toggle Delete
                If Not row.Cells("yaf_catcde").Value.ToString = "" Then
                    Call cmdDelRow_Click(sender, e)
                End If

            ElseIf e.ColumnIndex = 4 Or e.ColumnIndex = 5 Then
                If row.Cells("yaf_credat").Value.ToString = "" And row.Cells("yaf_status").Value.ToString = "" Then
                    If TypeOf (DataGrid.CurrentCell) Is DataGridViewTextBoxCell Then
                        createComboBoxCell(DataGrid.CurrentCell)
                        DataGrid.BeginEdit(True)
                        cmdSave.Enabled = Enq_right_local
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

            If e.ColumnIndex = 4 Then
                If Not chkGrdCellValue(row.Cells("yaf_catcde"), "String", 12) Then
                    e.Cancel = True
                Else
                    For Each drr As DataGridViewRow In DataGrid.Rows
                        If drr.Index <> e.RowIndex Then
                            If drr.Cells("yaf_catcde").Value.ToString.ToUpper = strNewVal.ToUpper Then
                                MsgBox("Duplicated category code!")
                                e.Cancel = True
                                Exit For
                            End If
                        End If
                    Next
                End If
            End If

            If e.ColumnIndex = 5 Then
                If chkGrdCellValue(row.Cells("yaf_fmlopt"), "String", 50) Then
                    e.Cancel = True
                End If
            End If
        End If

    End Sub

    Private Sub cmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsRow.Click
        Dim dt As DataTable
        Dim dr As DataRow
        Dim iMax As Integer

        dt = rs_sycatfml.Tables("RESULT")
        For Each drr As DataRow In dt.Rows
            If iMax < drr.Item("no") Then
                iMax = drr.Item("no")
            End If
        Next

        For Each dr In dt.Rows
            If dr.Item("yaf_catcde").ToString.Trim = "" Then
                MsgBox("Please input category code.")
                Exit Sub
            End If
        Next

        dr = dt.NewRow
        dr.Item("yaf_status") = ""
        dr.Item("no") = iMax + 1
        dr.Item("yaf_lnecde") = Txtlne.Text.Trim
        dt.Rows.Add(dr)

        For Each drr As DataGridViewRow In DataGrid.Rows
            If IsDBNull(drr.Cells(4).Value) Then
                DataGrid.CurrentCell = drr.Cells(4)
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
            If Not row.Cells("yaf_catcde").Value.ToString = "" Then
                If row.Cells("yaf_status").Value.ToString = "" Then
                    row.Cells("yaf_status").Value = "Y"
                    cellStyle.BackColor = Color.LightBlue
                Else
                    row.Cells("yaf_status").Value = ""
                    cellStyle.BackColor = Nothing
                End If
                row.DataGridView.CurrentRow.DefaultCellStyle = cellStyle
                Call setStatus("DelRow")
            End If
        End If

    End Sub

    Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim flgErr As Boolean = False
        Dim flgReAct As Boolean = False
        Dim strPcFac, strDesign As String
        Dim strFmlOpt, strFml As String

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            save_ok = True
            bindSrc.EndEdit()
            For Each row As DataGridViewRow In DataGrid.Rows

                If row.Cells("yaf_status").Value.ToString = "" Then

                    If Not chkGrdCellValue(row.Cells("yaf_catcde"), "String", 12) Then
                        save_ok = False
                        flgReAct = True

                    ElseIf Not chkGrdCellValue(row.Cells("yaf_fmlopt"), "String", 50) Then
                        save_ok = False
                        flgReAct = True

                    Else
                        If row.Cells("yaf_credat").Value.ToString = "" Then
                            For Each drr As DataGridViewRow In DataGrid.Rows
                                If drr.Index <> row.Index Then
                                    If drr.Cells("yaf_catcde").Value.ToString.ToUpper = row.Cells("yaf_catcde").Value.ToString.ToUpper And _
                                       drr.Cells("yaf_status").Value.ToString = "" Then

                                        MsgBox("Duplicated category code " & drr.Cells("yaf_catcde").Value.ToString & "!")
                                        save_ok = False
                                        flgReAct = True
                                        row.DataGridView.CurrentCell = row.Cells("yaf_catcde")
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
                strPcFac = Split(cboPcFac.SelectedItem, " - ")(0).ToString.Replace("'", "''").Trim
                strDesign = Split(cboDesign.SelectedItem, " - ")(0).ToString.Replace("'", "''").Trim

                If Add_flag Then
                    gspStr = "sp_insert_SYLNEINF '" & gsCompany & "','" & _
                                 Txtlne.Text.Replace("'", "''").ToUpper.Trim & "','" & _
                                 Txtlnedsc.Text.Replace("'", "''").Trim & "','" & _
                                 strPcFac & "','" & _
                                 strDesign & "','" & _
                                 gsUsrID & "'"
                Else
                    gspStr = "sp_update_SYLNEINF '" & gsCompany & "','" & _
                                 Txtlne.Text.Replace("'", "''").ToUpper.Trim & "','" & _
                                 Txtlnedsc.Text.Replace("'", "''").Trim & "','" & _
                                 strPcFac & "','" & _
                                 strDesign & "','" & _
                                 gsUsrID & "'"
                End If

                If gspStr <> "" Then
                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading SYM00004 sp_update_SYLNEINF : " & rtnStr)
                        flgErr = True
                        Exit Sub
                    End If
                End If

                gspStr = ""
                For Each dr As DataRow In rs_sycatfml.Tables("RESULT").Rows

                    strFmlOpt = Split(dr.Item("yaf_fmlopt").ToString.Trim, " - ")(0).ToString.Replace("'", "''").Trim
                    strFml = Split(dr.Item("yaf_fmlopt").ToString.Trim, " - ")(1).ToString.Replace("'", "''").Trim

                    If dr.RowState = DataRowState.Modified Then
                        If dr.Item("yaf_status") = "Y" Then
                            gspStr = "sp_physical_delete_SYCATFML '" & gsCompany & "','" & _
                                        Txtlne.Text.Replace("'", "''").ToUpper.Trim & "','" & _
                                        dr.Item("yaf_catcde").ToString.Replace("'", "''").Trim & "','" & _
                                        gsUsrID & "'"
                        Else
                            gspStr = "sp_update_SYCATFML '" & gsCompany & "','" & _
                                        Txtlne.Text.Replace("'", "''").ToUpper.Trim & "','" & _
                                        dr.Item("yaf_catcde").ToString.Replace("'", "''").Trim & "','" & _
                                        strFmlOpt & "','" & _
                                        strFml & "','" & _
                                        gsUsrID & "'"
                        End If
                    ElseIf dr.RowState = DataRowState.Added And Not dr.Item("yaf_status") = "Y" Then

                        If dr.Item("yaf_credat").ToString.Trim = "" Then
                            gspStr = "sp_insert_SYCATFML '" & gsCompany & "','" & _
                                        Txtlne.Text.Replace("'", "''").ToUpper.Trim & "','" & _
                                        dr.Item("yaf_catcde").ToString.Replace("'", "''").Trim & "','" & _
                                        strFmlOpt & "','" & _
                                        strFml & "','" & _
                                        gsUsrID & "'"
                        End If
                    End If

                    If gspStr <> "" Then
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading SYM00004 sp_update_SYCATFML : " & rtnStr)
                            flgErr = True
                            Exit For
                        End If
                        gspStr = ""
                    End If
                Next

                If Not flgErr Then
                    rs_sycatfml.AcceptChanges()
                    Call setStatus("Save")
                Else
                    save_ok = False
                    rs_sycatfml.RejectChanges()
                    MsgBox("Record Not Updated!")
                End If
            End If

        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub SYM00004_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim YNC As Integer
        Dim flgMod As Boolean = False

        bindSrc.EndEdit()
        If Not rs_sycatfml.Tables("RESULT") Is Nothing Then
            For Each dr As DataRow In rs_sycatfml.Tables("RESULT").Rows
                If dr.RowState = DataRowState.Modified Or dr.RowState = DataRowState.Added Then
                    flgMod = True
                End If
            Next
        End If

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