Public Class SYS00004

    Dim rs_usr As New DataSet
    Dim rs_rights As New DataSet
    Dim rs_super As New DataSet
    Dim rs_lvl As New DataSet
    Dim rs_para As New DataSet
    Dim bindSrc As New BindingSource
    Dim save_ok As Boolean
    Dim CanModify As Boolean = True
    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean

    Private Sub SYS00004_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Call AccessRight(Me.Name)
            Enq_right_local = Enq_right
            Del_right_local = Del_right

            If Not rs_usr Is Nothing Then
                rs_usr = Nothing
            End If

            gspStr = "sp_select_SYUSRPRF_All '" & gsCompany & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_usr, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYS00004 sp_select_SYUSRPRF_All : " & rtnStr)
            Else
                Call FillComboUsrGrp()
                Call FillComboComGrp()
                Me.txtDesc.Text = ""
                CboModule.Items.Clear()
                CboModule.Enabled = False
                chkSuper.Checked = False
                chkSuper.Enabled = False
                DataGrid.DataSource = Nothing

                Call displayGrid(rs_usr.Tables("RESULT").DefaultView)
                Call setStatus("Init")
            End If
            Call Formstartup(Me.Name)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub setDataRowAttr()

        If Not rs_rights.Tables("RESULT") Is Nothing Then
            For Each dc As DataColumn In rs_rights.Tables("RESULT").Columns
                dc.ReadOnly = False
            Next
            For Each dr As DataRow In rs_rights.Tables("RESULT").Rows
                dr.Item("yur_status") = ""
            Next
            rs_rights.AcceptChanges()
        End If

        If Not rs_super.Tables("RESULT") Is Nothing Then
            For Each dc As DataColumn In rs_super.Tables("RESULT").Columns
                dc.ReadOnly = False
            Next
            For Each dr As DataRow In rs_super.Tables("RESULT").Rows
                dr.Item("yur_status") = ""
            Next
            rs_super.AcceptChanges()
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
                Me.cboUsrGrp.Items.Add("")
                Dim dr() As DataRow = rs_usrgrp.Tables("RESULT").Select("")
                For i = 0 To dr.Length - 1
                    If Not dr(i).Item("yug_usrgrp").ToString = "" Then
                        Me.cboUsrGrp.Items.Add(dr(i).Item("yug_usrgrp").ToString)
                    End If
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
                Me.cboComGrp.Items.Add("")
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

    Private Sub displayGrid(ByVal dv As DataView)
        Dim i As Integer

        With DataGridUsr
            .DataSource = Nothing
            .DataSource = dv

            For i = 0 To .Columns.Count - 1
                Select Case i
                    Case 0
                        .Columns(i).Width = 100
                        .Columns(i).HeaderText = "User ID"
                        .Columns(i).ReadOnly = True
                    Case 1
                        .Columns(i).Width = 150
                        .Columns(i).HeaderText = "User Name"
                        .Columns(i).ReadOnly = True
                    Case 2
                        .Columns(i).Width = 80
                        .Columns(i).HeaderText = "User Group"
                        .Columns(i).ReadOnly = True
                    Case 3
                        .Columns(i).Width = 80
                        .Columns(i).HeaderText = "Co. Group"
                        .Columns(i).ReadOnly = True
                    Case Else
                        .Columns(i).Visible = False
                End Select
                .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i
        End With
    End Sub

    Private Sub displayGridRights(ByVal dv As DataView)
        Dim i As Integer

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
                    Case 4
                        .Columns(i).Width = 90
                        .Columns(i).HeaderText = "Level"
                    Case 5
                        .Columns(i).Width = 80
                        .Columns(i).HeaderText = "Parameter"
                    Case 6
                        .Columns(i).Width = 120
                        .Columns(i).HeaderText = "Description"
                        .Columns(i).ReadOnly = True
                    Case Else
                        .Columns(i).Visible = False
                End Select
                .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i
        End With
    End Sub

    Private Sub setStatus(ByVal mode As String)

        If mode = "Init" Then
            cmdAdd.Enabled = False
            cmdSave.Enabled = True
            cmdDelete.Enabled = False
            cmdCopy.Enabled = False
            cmdFind.Enabled = False
            cmdExit.Enabled = True
            cmdClear.Enabled = False
            cmdInsRow.Enabled = False
            cmdDelRow.Enabled = False
            cmdSearch.Enabled = True

            cmdFirst.Enabled = False
            cmdLast.Enabled = False
            cmdNext.Enabled = False
            cmdPrevious.Enabled = False
            txtDesc.ReadOnly = True
            cboUsrGrp.Visible = True
            cboUsrGrp.Enabled = True
            cboComGrp.Enabled = True

            Call ResetDefaultDisp()
            Call SetStatusBar(mode)

        ElseIf mode = "Add" Then
            cmdAdd.Enabled = False
            cmdCopy.Enabled = False
            cmdFind.Enabled = False
            cmdClear.Enabled = True
            cmdSave.Enabled = Enq_right_local

            cmdInsRow.Enabled = Enq_right_local
            cmdDelRow.Enabled = False
            txtDesc.ReadOnly = False
            cboUsrGrp.Visible = False
            cboUsrGrp.Enabled = False
            cboComGrp.Enabled = True
            Call SetStatusBar(mode)

        ElseIf mode = "InsRow" Then
            cmdCopy.Enabled = False
            cmdFind.Enabled = False
            cmdSave.Enabled = Enq_right_local
            cmdDelRow.Enabled = Del_right_local
            cboUsrGrp.Enabled = False
            cboComGrp.Enabled = False
            Call SetStatusBar(mode)

        ElseIf mode = "Save" Then
            Call ResetDefaultDisp()
            Call SetStatusBar(mode)
            MsgBox("Record Saved!")
            Call SYS00004_Load(Nothing, Nothing)

        ElseIf mode = "DelRow" Then
            cmdCopy.Enabled = False
            cmdFind.Enabled = False
            cmdSave.Enabled = Enq_right_local
            cmdDelRow.Enabled = Del_right_local
            cboUsrGrp.Enabled = False
            cboComGrp.Enabled = False
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
        Dim strModule, strCoGrp, strLvl As String

        Try
            If iCol = 4 Then
                strCoGrp = DataGridUsr.CurrentRow.Cells("yco_cogrp").Value.ToString
                strModule = Split(CboModule.SelectedItem, " - ")(0).Trim

                If Not rs_lvl Is Nothing Then
                    rs_lvl = Nothing
                End If

                gspStr = "sp_select_SYUSRLVL '" & gsCompany & "','" & strCoGrp & "','" & strModule & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_lvl, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading SYS00004 sp_select_SYUSRLVL : " & rtnStr)
                Else
                    For Each dr As DataRow In rs_lvl.Tables("RESULT").Rows
                        If Not dr.Item("yul_lvl") = 0 Then
                            cboCell.Items.Add(dr.Item("yul_desc").ToString.Trim)
                        End If
                    Next
                    cboCell.DropDownWidth = 150
                    cboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

                    dgView.Rows(iRow).Cells(iCol) = cboCell
                    dgView.Rows(iRow).Cells(iCol).ReadOnly = False
                End If

            ElseIf iCol = 5 Then
                strLvl = dgView.Rows(iRow).Cells(3).Value.ToString

                If Not strLvl = "" Then

                    If Not rs_para Is Nothing Then
                        rs_para = Nothing
                    End If

                    gspStr = "sp_select_SYUSRPARA '" & gsCompany & "','" & strLvl & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs_para, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading SYS00004 sp_select_SYUSRLVL : " & rtnStr)
                    Else
                        For Each dr As DataRow In rs_para.Tables("RESULT").Rows
                            cboCell.Items.Add(dr.Item("yul_para").ToString.Trim)
                        Next
                        cboCell.DropDownWidth = 150
                        cboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

                        dgView.Rows(iRow).Cells(iCol) = cboCell
                        dgView.Rows(iRow).Cells(iCol).ReadOnly = False
                    End If
                End If
            End If
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
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
                If iCol = 4 Then
                    Me.DataGrid.Rows(iRow).Cells(iCol).Value = strSelItem
                    Me.DataGrid.Rows(iRow).Cells(iCol - 1).Value = rs_lvl.Tables("RESULT").Select("yul_desc = '" & strSelItem & "'")(0).Item("yul_lvl").ToString

                    Dim cboText As New DataGridViewTextBoxCell
                    Me.DataGrid.Rows(iRow).Cells(iCol + 1).Value = ""
                    Me.DataGrid.Rows(iRow).Cells(iCol + 1) = cboText

                ElseIf iCol = 5 Then
                    Me.DataGrid.Rows(iRow).Cells(iCol).Value = strSelItem
                    Me.DataGrid.Rows(iRow).Cells(iCol + 1).Value = rs_para.Tables("RESULT").Select("yul_para = '" & strSelItem & "'")(0).Item("yul_pdesc").ToString
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
                If Not row.Cells("yur_lvl").Value.ToString = "" Then
                    Call cmdDelRow_Click(sender, e)
                End If

            ElseIf e.ColumnIndex = 4 Or e.ColumnIndex = 5 Then
                If row.Cells("yur_credat").Value.ToString = "" And row.Cells("yur_status").Value.ToString = "" Then
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

            If e.ColumnIndex = 5 Then
                If Not chkGrdCellValue(row.Cells("yur_para"), "String", 30) Then
                    e.Cancel = True
                Else
                    For Each drr As DataGridViewRow In DataGrid.Rows
                        If drr.Index <> e.RowIndex Then
                            If drr.Cells("yur_para").Value.ToString.ToUpper = strNewVal.ToUpper Then
                                MsgBox("Duplicated parameters!")
                                e.Cancel = True
                                Exit For
                            End If
                        End If
                    Next
                End If
            End If

            If e.ColumnIndex = 4 Then
                If (row.Cells("yur_para").Value <> "") Then
                    If Not chkGrdCellValue(row.Cells("yur_desc"), "String", 100) Then
                        e.Cancel = True
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub cmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsRow.Click
        Dim dt As DataTable
        Dim dr As DataRow

        dt = rs_rights.Tables("RESULT")
        For Each dr In dt.Rows
            If dr.Item("yur_lvl").ToString.Trim = "" Then
                MsgBox("Please input level code.")
                Exit Sub
            End If
        Next

        dr = dt.NewRow
        dr.Item("yur_status") = ""
        dr.Item("yur_cogrp") = DataGridUsr.CurrentRow.Cells("yco_cogrp").Value.ToString.Trim
        dr.Item("yur_usrid") = DataGridUsr.CurrentRow.Cells("yup_usrid").Value.ToString.Trim
        dr.Item("yur_doctyp") = Split(CboModule.SelectedItem, " - ")(0).Trim
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
            If Not row.Cells("yur_lvl").Value.ToString = "" Then
                If row.Cells("yur_status").Value.ToString = "" Then
                    row.Cells("yur_status").Value = "Y"
                    cellStyle.BackColor = Color.LightBlue
                Else
                    row.Cells("yur_status").Value = ""
                    cellStyle.BackColor = Nothing
                End If
                row.DataGridView.CurrentRow.DefaultCellStyle = cellStyle
                Call setStatus("DelRow")
            End If
        End If
    End Sub

    Private Sub cboUsrGrp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUsrGrp.SelectedIndexChanged
        Dim dr() As DataRow

        Call FilterUsr()

        If cboUsrGrp.SelectedItem Is Nothing Then
            txtDesc.Text = ""
        Else
            dr = rs_usr.Tables("RESULT").Select("yuc_usrgrp = '" & cboUsrGrp.SelectedItem & "'")
            If dr.Length > 0 Then
                txtDesc.Text = dr(0).Item("yug_grpdsc").ToString
            Else
                txtDesc.Text = ""
            End If
        End If
    End Sub

    Private Sub cboComGrp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboComGrp.SelectedIndexChanged
        Call FilterUsr()
    End Sub

    Private Sub CboModule_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboModule.SelectedIndexChanged
        Dim dv As DataView
        Dim dr() As DataRow
        Dim StrModule As String

        If Not CboModule.SelectedItem Is Nothing Then
            StrModule = Split(CboModule.SelectedItem, " - ")(0).Trim

            If Not rs_rights.Tables("RESULT") Is Nothing Then
                dv = rs_rights.Tables("RESULT").DefaultView
                dv.RowFilter = "yur_doctyp = '" & StrModule & "'"
                displayGridRights(dv)

                Dim cellStyle As New DataGridViewCellStyle
                For Each row As DataGridViewRow In DataGrid.Rows
                    cellStyle.BackColor = Color.LightBlue
                    If row.Cells("yur_status").Value.ToString = "Y" Then
                        row.DefaultCellStyle = cellStyle
                    Else
                        row.DefaultCellStyle = Nothing
                    End If
                Next

                If dv.Count > 0 Then
                    cmdInsRow.Enabled = True
                    cmdDelRow.Enabled = True
                Else
                    cmdInsRow.Enabled = True
                    cmdDelRow.Enabled = False
                End If
            End If

            If Not rs_super.Tables("RESULT") Is Nothing Then
                dr = rs_super.Tables("RESULT").Select("yur_doctyp = '" & StrModule & "'")
                If dr.Length = 0 Then
                    chkSuper.Checked = False
                Else
                    If dr(0).Item("yur_status") = "Y" Then
                        chkSuper.Checked = False
                    Else
                        chkSuper.Checked = True
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub FilterUsr()
        Dim dv As DataView
        Dim strUsrGrp, strComGrp As String

        If Not rs_usr.Tables("RESULT") Is Nothing Then
            dv = rs_usr.Tables("RESULT").DefaultView

            If cboUsrGrp.SelectedItem Is Nothing Then
                strUsrGrp = ""
            Else
                strUsrGrp = cboUsrGrp.SelectedItem.ToString.Trim
            End If

            If cboComGrp.SelectedItem Is Nothing Then
                strComGrp = ""
            Else
                strComGrp = cboComGrp.SelectedItem.ToString.Trim
            End If

            If strUsrGrp = "" And strComGrp <> "" Then
                dv.RowFilter = "yco_cogrp = '" & strComGrp & "'"
            ElseIf strUsrGrp <> "" And strComGrp = "" Then
                dv.RowFilter = "yuc_usrgrp = '" & strUsrGrp & "'"
            ElseIf strUsrGrp <> "" And strComGrp <> "" Then
                dv.RowFilter = "yuc_usrgrp = '" & strUsrGrp & "' and yco_cogrp = '" & strComGrp & "'"
            Else
                dv.RowFilter = ""
            End If
            displayGrid(dv)
            CboModule.Items.Clear()
            CboModule.Enabled = False
            chkSuper.Checked = False
            chkSuper.Enabled = False
            DataGrid.DataSource = Nothing
        End If

    End Sub

    Private Sub DataGridUsr_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridUsr.MouseUp
        Dim hit As DataGridView.HitTestInfo = DataGridUsr.HitTest(e.X, e.Y)
        Dim strCoGrp, strUsrID As String

        If hit.Type = DataGridViewHitTestType.RowHeader Then
            DataGridUsr.ClearSelection()
            DataGridUsr.Rows(hit.RowIndex).Selected = True

            strUsrID = DataGridUsr.Rows(hit.RowIndex).Cells("yup_usrid").Value.ToString
            strCoGrp = DataGridUsr.Rows(hit.RowIndex).Cells("yco_cogrp").Value.ToString
            Call GetRightsByUser(strUsrID, strCoGrp)
            Call GetDocAll(strCoGrp)
            CboModule.Enabled = True
            chkSuper.Enabled = True
        Else
            CboModule.Items.Clear()
            CboModule.Enabled = False
            chkSuper.Checked = False
            chkSuper.Enabled = False
            DataGrid.DataSource = Nothing
        End If
    End Sub

    Private Sub GetDocAll(ByVal strCoGrp As String)
        Dim rs_doc As New DataSet
        Dim dr() As DataRow
        Dim i, iDef As Integer

        Try
            gspStr = "sp_select_SYUSRDOC_ALL '" & gsCompany & "','" & strCoGrp & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_doc, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYS00001 sp_select_SYCOMGRP : " & rtnStr)
            Else
                Me.CboModule.Items.Clear()
                dr = rs_doc.Tables("RESULT").Select("")
                For i = 0 To dr.Length - 1
                    Me.CboModule.Items.Add(dr(i).Item("yud_doctyp").ToString & " - " & dr(i).Item("yud_desc").ToString)
                    If dr(i).Item("yud_doctyp").ToString = "QU" Then
                        iDef = i
                    End If
                Next
                CboModule.SelectedIndex = iDef
            End If
        Finally
            rs_doc = Nothing
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub GetRightsByUser(ByVal strUsrID As String, ByVal strCoGrp As String)

        Try
            If Not rs_rights Is Nothing Then
                rs_rights = Nothing
            End If

            If Not rs_super Is Nothing Then
                rs_super = Nothing
            End If

            gspStr = "sp_select_SYUSRRIGHT '" & gsCompany & "','" & strCoGrp & "','" & strUsrID & "','1'"
            rtnLong = execute_SQLStatement(gspStr, rs_rights, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYS00004 sp_select_SYUSRRIGHT : " & rtnStr)
            Else
                gspStr = "sp_select_SYUSRRIGHT '" & gsCompany & "','" & strCoGrp & "','" & strUsrID & "','0'"
                rtnLong = execute_SQLStatement(gspStr, rs_super, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading SYS00004 sp_select_SYUSRRIGHT : " & rtnStr)
                Else
                    setDataRowAttr()
                End If
            End If
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub chkSuper_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSuper.Click
        Dim strModule, strCoGrp, strUsrID As String
        Dim dt_rights, dt_super As DataTable
        Dim dr As DataRow
        Dim drr() As DataRow
        Dim i As Integer

        If Not CboModule.SelectedItem Is Nothing Then
            strModule = Split(CboModule.SelectedItem, " - ")(0).Trim
            strCoGrp = DataGridUsr.CurrentRow.Cells("yco_cogrp").Value.trim
            strUsrID = DataGridUsr.CurrentRow.Cells("yup_usrid").Value.trim

            dt_super = rs_super.Tables("RESULT")
            dt_rights = rs_rights.Tables("RESULT")

            If chkSuper.Checked Then
                cmdInsRow.Enabled = False
                cmdDelRow.Enabled = False
                drr = dt_super.Select("yur_doctyp = '" & strModule & "' and yur_status = 'Y'")
                If drr.Length > 0 Then
                    drr(0).Item("yur_status") = ""
                Else
                    dr = dt_super.NewRow
                    dr.Item("yur_status") = ""
                    dr.Item("yur_cogrp") = DataGridUsr.CurrentRow.Cells("yco_cogrp").Value.ToString.Trim
                    dr.Item("yur_usrid") = DataGridUsr.CurrentRow.Cells("yup_usrid").Value.ToString.Trim
                    dr.Item("yur_doctyp") = strModule
                    dr.Item("yur_lvl") = 0
                    dr.Item("yur_para") = "S"
                    dr.Item("yur_desc") = "Super User"
                    dt_super.Rows.Add(dr)
                End If
                drr = dt_rights.Select("yur_doctyp = '" & strModule & "'")
                For i = 0 To drr.Length - 1
                    drr(i).Item("yur_status") = "Y"
                Next
                Dim cellStyle As New DataGridViewCellStyle
                For Each row As DataGridViewRow In DataGrid.Rows
                    cellStyle.BackColor = Color.LightBlue
                    row.DefaultCellStyle = cellStyle
                Next
            Else
                cmdInsRow.Enabled = Enq_right_local
                drr = dt_super.Select("yur_doctyp = '" & strModule & "' and yur_status = ''")
                If drr.Length > 0 Then
                    drr(0).Item("yur_status") = "Y"
                End If
                drr = dt_rights.Select("yur_doctyp = '" & strModule & "'")
                If drr.Length = 0 Then
                    cmdInsRow.Enabled = True
                    cmdDelRow.Enabled = False
                Else
                    cmdInsRow.Enabled = True
                    cmdDelRow.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim flgErr As Boolean = False
        Dim flgReAct As Boolean = False

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            save_ok = True
            For Each row As DataGridViewRow In DataGrid.Rows

                If row.Cells("yur_status").Value.ToString = "" Then

                    If Not chkGrdCellValue(row.Cells("yur_desc"), "String", 100) Then
                        save_ok = False
                        flgReAct = True

                    ElseIf Not chkGrdCellValue(row.Cells("yur_para"), "String", 30) Then
                        save_ok = False
                        flgReAct = True

                    Else
                        If row.Cells("yur_credat").Value.ToString = "" Then
                            For Each drr As DataGridViewRow In DataGrid.Rows
                                If drr.Index <> row.Index Then
                                    If drr.Cells("yur_para").Value.ToString.ToUpper = row.Cells("yur_para").Value.ToString.ToUpper And _
                                       drr.Cells("yur_status").Value.ToString = "" Then

                                        MsgBox("Duplicated parameter " & drr.Cells("yur_para").Value.ToString & "!")
                                        save_ok = False
                                        flgReAct = True
                                        row.DataGridView.CurrentCell = row.Cells("yur_para")
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
                rs_rights.Tables("RESULT").Merge(rs_super.Tables("RESULT"), True)
                For Each dr As DataRow In rs_rights.Tables("RESULT").Rows
                    If dr.RowState = DataRowState.Modified Then
                        If dr.Item("yur_status") = "Y" Then
                            gspStr = "sp_physical_delete_SYUSRRIGHT '" & gsCompany & "','" & _
                                        dr.Item("yur_cogrp").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yur_usrid").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yur_doctyp").ToString.Replace("'", "''").Trim & "'," & _
                                        dr.Item("yur_lvl").ToString.Replace("'", "''").Trim & ",'" & _
                                        dr.Item("yur_para").ToString.Replace("'", "''").Trim & "','" & _
                                        gsUsrID & "'"
                        End If
                    ElseIf dr.RowState = DataRowState.Added And Not dr.Item("yur_status") = "Y" Then

                        If dr.Item("yur_credat").ToString.Trim = "" Then
                            gspStr = "sp_insert_SYUSRRIGHT '" & gsCompany & "','" & _
                                        dr.Item("yur_cogrp").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yur_usrid").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yur_doctyp").ToString.Replace("'", "''").Trim & "'," & _
                                        dr.Item("yur_lvl").ToString.Replace("'", "''").Trim & ",'" & _
                                        dr.Item("yur_para").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yur_desc").ToString.Replace("'", "''").Trim & "','" & _
                                        gsUsrID & "'"
                        End If
                    End If

                    If gspStr <> "" Then
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading SYS00004 sp_insert_SYUSRRIGHT : " & rtnStr)
                            flgErr = True
                            Exit For
                        End If
                        gspStr = ""
                    End If
                Next

                If Not flgErr Then
                    rs_rights.AcceptChanges()
                    Call setStatus("Save")
                Else
                    save_ok = False
                    rs_rights.RejectChanges()
                    MsgBox("Record Not Updated!")
                End If
            End If

        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub SYS00004_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim YNC As Integer
        Dim flgMod As Boolean = False

        bindSrc.EndEdit()
        If Not rs_rights.Tables("RESULT") Is Nothing Then
            For Each dr As DataRow In rs_rights.Tables("RESULT").Rows
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

    Private Sub DataGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGrid.CellContentClick

    End Sub
End Class