Public Class SYM00023
    Inherits System.Windows.Forms.Form

    Dim rs_fmlInf As New DataSet
    Dim rs_sycstset As New DataSet
    Dim bindSrc As New BindingSource
    Dim save_ok As Boolean
    Dim CanModify As Boolean = True
    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean

    Private Sub SYM00023_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Call AccessRight(Me.Name)
            Enq_right_local = Enq_right
            Del_right_local = Del_right

            Call FillComboPriCus()
            Call FillComboItmCat()
            Me.cboSecCus.Items.Clear()

            If Not rs_sycstset Is Nothing Then
                rs_sycstset = Nothing
            End If

            gspStr = "sp_select_SYCSTSET '" & gsCompany & "','','',''"
            rtnLong = execute_SQLStatement(gspStr, rs_sycstset, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00023 sp_select_SYCSTSET : " & rtnStr)
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
        Dim dt As DataTable = rs_sycstset.Tables("RESULT")

        If Not dt Is Nothing Then
            For Each dc As DataColumn In dt.Columns
                dc.ReadOnly = False
            Next
            For Each dr As DataRow In dt.Rows
                dr.Item("ycs_status") = ""
            Next
            rs_sycstset.AcceptChanges()
        End If
    End Sub

    Private Sub FillComboPriCus()
        Dim rs_pricus As New DataSet
        Dim i As Integer

        Try
            gspStr = "sp_list_CUBASINF '" & gsCompany & "','PA'"
            rtnLong = execute_SQLStatement(gspStr, rs_pricus, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00023 sp_list_CUBASINF : " & rtnStr)
            Else
                Me.cboPriCus.Items.Clear()
                Dim dr() As DataRow = rs_pricus.Tables("RESULT").Select("cbi_cusno >= '50000'")
                For i = 0 To dr.Length - 1
                    Me.cboPriCus.Items.Add(dr(i).Item("cbi_cusno").ToString & " - " & dr(i).Item("cbi_cussna").ToString)
                Next i
            End If
        Finally
            rs_pricus = Nothing
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub FillComboItmCat()
        Dim rs_sycatcde As New DataSet
        Dim i As Integer

        Try
            gspStr = "sp_select_SYCATCDE_level'" & gsCompany & "','2'"
            rtnLong = execute_SQLStatement(gspStr, rs_sycatcde, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00023 sp_select_SYCATCDE_level : " & rtnStr)
            Else
                Me.cboItmCat.Items.Clear()
                Dim dr() As DataRow = rs_sycatcde.Tables("RESULT").Select("")
                For i = 0 To dr.Length - 1
                    Me.cboItmCat.Items.Add(dr(i).Item("ycc_catcde").ToString & " - " & dr(i).Item("ycc_catdsc").ToString)
                Next i
            End If
        Finally
            rs_sycatcde = Nothing
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub FillComboSecCus()
        Dim rs_seccus As New DataSet
        Dim i As Integer

        Try
            gspStr = "sp_select_CUBASINF_Q '" & gsCompany & "','" & Split(cboPriCus.SelectedItem, " - ")(0) & "','Secondary'"
            rtnLong = execute_SQLStatement(gspStr, rs_seccus, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00023 sp_select_CUBASINF_Q : " & rtnStr)
            Else
                Me.cboSecCus.Items.Clear()
                Dim dr() As DataRow = rs_seccus.Tables("RESULT").Select("csc_seccus >= '60000'")
                Me.cboSecCus.Items.Add("")
                For i = 0 To dr.Length - 1
                    Me.cboSecCus.Items.Add(dr(i).Item("csc_seccus").ToString & " - " & dr(i).Item("cbi_cussna").ToString)
                Next i
            End If
        Finally
            rs_seccus = Nothing
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub cboPriCus_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPriCus.SelectedIndexChanged
        Call FillComboSecCus()
        cboSecCus.SelectedIndex = -1
        cboItmCat.SelectedIndex = -1

        Call ShowGrdDtl()
        Call setStatus("Init")
        cboItmCat.Enabled = True
    End Sub

    Private Sub cboSecCus_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSecCus.SelectedIndexChanged
        If Not cboPriCus.SelectedItem Is Nothing Then
            Call ShowGrdDtl()
        End If
    End Sub

    Private Sub cboItmCat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboItmCat.SelectedIndexChanged
        If Not cboPriCus.SelectedItem Is Nothing Then
            Call ShowGrdDtl()
        End If
    End Sub
    Private Sub mmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdClear.Click
        If checkFocus(Me) Then Exit Sub
        Dim YNC As Integer
        Dim flgMod As Boolean = False

        bindSrc.EndEdit()
        For Each dr As DataRow In rs_sycstset.Tables("RESULT").Rows
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
                        Call SYM00023_Load(Nothing, Nothing)
                    Else
                        Exit Sub
                    End If
                Else
                    MsgBox("Sorry! You have not right to save!")
                End If
            ElseIf YNC = Windows.Forms.DialogResult.No Then
                Call SYM00023_Load(Nothing, Nothing)

            ElseIf YNC = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
        Else
            Call SYM00023_Load(Nothing, Nothing)
        End If

    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim YNC As Integer
        Dim flgMod As Boolean = False

        bindSrc.EndEdit()
        For Each dr As DataRow In rs_sycstset.Tables("RESULT").Rows
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
                        Call SYM00023_Load(Nothing, Nothing)
                    Else
                        Exit Sub
                    End If
                Else
                    MsgBox("Sorry! You have not right to save!")
                End If
            ElseIf YNC = Windows.Forms.DialogResult.No Then
                Call SYM00023_Load(Nothing, Nothing)

            ElseIf YNC = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
        Else
            Call SYM00023_Load(Nothing, Nothing)
        End If

    End Sub

    Private Sub ShowGrdDtl()
        Dim strPriCus, strSecCus, strItmCat As String

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            strPriCus = Split(cboPriCus.SelectedItem, " - ")(0).Trim
            strSecCus = Split(cboSecCus.SelectedItem, " - ")(0).Trim
            strItmCat = Split(cboItmCat.SelectedItem, " - ")(0).Trim

            If Not rs_fmlInf Is Nothing Then
                rs_fmlInf = Nothing
            End If

            If Not rs_sycstset Is Nothing Then
                rs_sycstset = Nothing
            End If

            gspStr = "sp_list_SYFMLINF '" & gsCompany & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_fmlInf, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00023 sp_list_SYFMLINF : " & rtnStr)
            Else
                gspStr = "sp_select_SYCSTSET '" & gsCompany & "','" & strPriCus & "','" & strSecCus & "','" & strItmCat & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_sycstset, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading SYM00023 sp_select_SYCSTSET : " & rtnStr)
                Else
                    If rs_sycstset.Tables("RESULT").Rows.Count = 0 Then
                        If strItmCat = "" Then
                            mmdInsRow.Enabled = False
                            mmdDelRow.Enabled = False
                        Else
                            mmdInsRow.Enabled = Enq_right_local
                            mmdDelRow.Enabled = False
                        End If
                    Else
                        mmdInsRow.Enabled = False
                        mmdDelRow.Enabled = False
                        If Enq_right_local = True Then
                            mmdInsRow.Enabled = Enq_right_local
                            mmdDelRow.Enabled = True
                        End If
                    End If
                    mmdClear.Enabled = True
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
        Dim dv As DataView = rs_sycstset.Tables("RESULT").DefaultView
        bindSrc.DataSource = dv
        Me.StatusBar.Items("lblRight").Text = ""
        With DataGrid
            .DataSource = Nothing
            .DataSource = bindSrc
            For i = 0 To .Columns.Count - 1
                Select Case i
                    Case 0
                        .Columns(i).Width = 40
                        .Columns(i).HeaderText = "Del"
                        .Columns(i).ReadOnly = True
                    Case 5
                        .Columns(i).Width = 70
                        .Columns(i).HeaderText = "Cost Type"
                    Case 6
                        .Columns(i).Width = 60
                        .Columns(i).HeaderText = "Option"
                    Case 7
                        .Columns(i).Width = 140
                        .Columns(i).HeaderText = "Markup Description"
                        .Columns(i).ReadOnly = True
                    Case 8
                        .Columns(i).Width = 80
                        .Columns(i).HeaderText = "Fty Formula"
                        .Columns(i).ReadOnly = True
                    Case 9
                        .Columns(i).Width = 60
                        .Columns(i).HeaderText = "Option"
                    Case 10
                        .Columns(i).Width = 140
                        .Columns(i).HeaderText = "Markup Description"
                        .Columns(i).ReadOnly = True
                    Case 11
                        .Columns(i).Width = 80
                        .Columns(i).HeaderText = "HK Formula"
                        .Columns(i).ReadOnly = True
                    Case Else
                        .Columns(i).Visible = False
                End Select
                .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i
        End With

        If Not dv.Count = 0 Then
            dv.Sort = "ycs_upddat desc"
            Dim drv As DataRowView = dv(0)
            Me.StatusBar.Items("lblRight").Text = Format(drv.Item("ycs_credat"), "MM/dd/yyyy") & " " & Format(drv.Item("ycs_upddat"), "MM/dd/yyyy") & " " & drv.Item("ycs_updusr")

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
            mmdClear.Enabled = False
            mmdInsRow.Enabled = False
            mmdDelRow.Enabled = False
            mmdSearch.Enabled = False

            mmdPrint.Enabled = False
            mmdAttach.Enabled = False
            mmdFunction.Enabled = False
            mmdLink.Enabled = False

            cboPriCus.Enabled = True
            cboSecCus.Enabled = True
            cboItmCat.Enabled = False

            Call ResetDefaultDisp()
            Call SetStatusBar(mode)

        ElseIf mode = "InsRow" Then

            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdSave.Enabled = Enq_right_local
            mmdDelRow.Enabled = Del_right_local
            mmdClear.Enabled = True

            cboPriCus.Enabled = False
            cboSecCus.Enabled = False
            cboItmCat.Enabled = False
            Call SetStatusBar(mode)

        ElseIf mode = "Save" Then
            Call ResetDefaultDisp()
            Call SetStatusBar(mode)
            MsgBox("Record Saved!")
            Call SYM00023_Load(Nothing, Nothing)

        ElseIf mode = "DelRow" Then


            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdSave.Enabled = Enq_right_local
            mmdDelRow.Enabled = Del_right_local

            cboPriCus.Enabled = False
            cboSecCus.Enabled = False
            cboItmCat.Enabled = False
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

        If iCol = 5 Then
            cboCell.Items.Add("A")
            cboCell.Items.Add("B")
            cboCell.Items.Add("C")
            cboCell.Items.Add("D")
            cboCell.Items.Add("TRAN")
            cboCell.Items.Add("PACK")
        Else
            For Each dr As DataRow In rs_fmlInf.Tables("RESULT").Rows
                cboCell.Items.Add(dr.Item("yfi_fmlopt").ToString.Trim)
            Next
        End If
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
                If iCol = 6 Then
                    Me.DataGrid.Rows(iRow).Cells(iCol).Value = strSelItem
                    Me.DataGrid.Rows(iRow).Cells(iCol + 1).Value = rs_fmlInf.Tables("RESULT").Select("yfi_fmlopt = '" & strSelItem & "'")(0).Item("yfi_prcfml").ToString
                    Me.DataGrid.Rows(iRow).Cells(iCol + 2).Value = rs_fmlInf.Tables("RESULT").Select("yfi_fmlopt = '" & strSelItem & "'")(0).Item("yfi_fml").ToString
                ElseIf iCol = 9 Then
                    Me.DataGrid.Rows(iRow).Cells(iCol).Value = strSelItem
                    Me.DataGrid.Rows(iRow).Cells(iCol + 1).Value = rs_fmlInf.Tables("RESULT").Select("yfi_fmlopt = '" & strSelItem & "'")(0).Item("yfi_prcfml").ToString
                    Me.DataGrid.Rows(iRow).Cells(iCol + 2).Value = rs_fmlInf.Tables("RESULT").Select("yfi_fmlopt = '" & strSelItem & "'")(0).Item("yfi_fml").ToString
                End If
                AddHandler cboBox.SelectedIndexChanged, AddressOf cboOpt_SelectedIndexChanged

            End If
        End If
    End Sub

    Private Sub DataGrid_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGrid.EditingControlShowing

        If DataGrid.CurrentCell.ColumnIndex = 6 Or DataGrid.CurrentCell.ColumnIndex = 9 Then
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
                If Not row.Cells("ycs_csttyp").Value.ToString = "" Then
                    Call cmdDelRow_Click(sender, e)
                End If

            ElseIf e.ColumnIndex = 5 Then
                If row.Cells("ycs_credat").Value.ToString = "" And row.Cells("ycs_status").Value.ToString = "" Then
                    If TypeOf (DataGrid.CurrentCell) Is DataGridViewTextBoxCell Then
                        createComboBoxCell(DataGrid.CurrentCell)
                        DataGrid.BeginEdit(True)

                        mmdSave.Enabled = Enq_right_local
                    End If
                Else
                    row.Cells(e.ColumnIndex).ReadOnly = True
                End If

            ElseIf e.ColumnIndex = 6 Or e.ColumnIndex = 9 Then
                If row.Cells("ycs_status").Value.ToString = "" Then
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
                If Not chkGrdCellValue(row.Cells("ycs_csttyp"), "String", 255) Then
                    e.Cancel = True
                Else
                    For Each drr As DataGridViewRow In DataGrid.Rows
                        If drr.Index <> e.RowIndex Then
                            If drr.Cells("ycs_csttyp").Value.ToString.ToUpper = strNewVal.ToUpper Then
                                MsgBox("Duplicated cost type!")
                                e.Cancel = True
                                Exit For
                            End If
                        End If
                    Next
                End If
            End If

            If e.ColumnIndex = 6 Then
                If Not chkGrdCellValue(row.Cells("ycs_ftyfmlopt"), "String", 5) Then
                    e.Cancel = True
                End If
            End If

            If e.ColumnIndex = 9 Then
                If Not chkGrdCellValue(row.Cells("ycs_hkfmlopt"), "String", 5) Then
                    e.Cancel = True
                End If
            End If
        End If

    End Sub
    Private Sub mmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdInsRow.Click
        Dim dt As DataTable
        Dim dr As DataRow

        dt = rs_sycstset.Tables("RESULT")
        For Each dr In dt.Rows
            If dr.Item("ycs_csttyp").ToString.Trim = "" Then
                MsgBox("Please input cost type.")
                Exit Sub
            End If
        Next

        dr = dt.NewRow
        dr.Item("ycs_status") = ""
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

    Private Sub cmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim dt As DataTable
        Dim dr As DataRow

        dt = rs_sycstset.Tables("RESULT")
        For Each dr In dt.Rows
            If dr.Item("ycs_csttyp").ToString.Trim = "" Then
                MsgBox("Please input cost type.")
                Exit Sub
            End If
        Next

        dr = dt.NewRow
        dr.Item("ycs_status") = ""
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
            If Not row.Cells("ycs_csttyp").Value.ToString = "" Then
                If row.Cells("ycs_status").Value.ToString = "" Then
                    row.Cells("ycs_status").Value = "Y"
                    cellStyle.BackColor = Color.LightBlue
                Else
                    row.Cells("ycs_status").Value = ""
                    cellStyle.BackColor = Nothing
                End If
                row.DataGridView.CurrentRow.DefaultCellStyle = cellStyle
                Call setStatus("DelRow")
            End If
        End If

    End Sub

    Private Sub cmdDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim row As DataGridViewRow = DataGrid.CurrentRow
        Dim cellStyle As New DataGridViewCellStyle

        ' Toggle Delete
        If Not row Is Nothing Then
            If Not row.Cells("ycs_csttyp").Value.ToString = "" Then
                If row.Cells("ycs_status").Value.ToString = "" Then
                    row.Cells("ycs_status").Value = "Y"
                    cellStyle.BackColor = Color.LightBlue
                Else
                    row.Cells("ycs_status").Value = ""
                    cellStyle.BackColor = Nothing
                End If
                row.DataGridView.CurrentRow.DefaultCellStyle = cellStyle
                Call setStatus("DelRow")
            End If
        End If

    End Sub
    Private Sub mmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mmdSave.Click
        If checkFocus(Me) Then Exit Sub
        Dim strPriCus, strSecCus, strItmCat As String
        Dim flgErr As Boolean = False
        Dim flgReAct As Boolean = False

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            save_ok = True
            bindSrc.EndEdit()
            For Each row As DataGridViewRow In DataGrid.Rows

                If row.Cells("ycs_status").Value.ToString = "" Then

                    If Not chkGrdCellValue(row.Cells("ycs_csttyp"), "String", 255) Then
                        save_ok = False
                        flgReAct = True

                    ElseIf Not chkGrdCellValue(row.Cells("ycs_ftyfmlopt"), "String", 5) Then
                        save_ok = False
                        flgReAct = True

                    ElseIf Not chkGrdCellValue(row.Cells("ycs_hkfmlopt"), "String", 5) Then
                        save_ok = False
                        flgReAct = True

                    Else
                        If row.Cells("ycs_credat").Value.ToString = "" Then
                            For Each drr As DataGridViewRow In DataGrid.Rows
                                If drr.Index <> row.Index Then
                                    If drr.Cells("ycs_csttyp").Value.ToString.ToUpper = row.Cells("ycs_csttyp").Value.ToString.ToUpper And _
                                       drr.Cells("ycs_status").Value.ToString = "" Then

                                        MsgBox("Duplicated cost type " & drr.Cells("ycs_csttyp").Value.ToString & "!")
                                        save_ok = False
                                        flgReAct = True
                                        row.DataGridView.CurrentCell = row.Cells("ycs_csttyp")
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
                strPriCus = Split(cboPriCus.SelectedItem, " - ")(0).Replace("'", "''").Trim
                strSecCus = Split(cboSecCus.SelectedItem, " - ")(0).Replace("'", "''").Trim
                strItmCat = Split(cboItmCat.SelectedItem, " - ")(0).Replace("'", "''").Trim

                For Each dr As DataRow In rs_sycstset.Tables("RESULT").Rows

                    If dr.RowState = DataRowState.Modified Then
                        If dr.Item("ycs_status") = "Y" Then
                            gspStr = "sp_physical_delete_SYCSTSET '" & gsCompany & "','" & _
                                        strPriCus & "','" & _
                                        strSecCus & "','" & _
                                        strItmCat & "','" & _
                                        dr.Item("ycs_csttyp").ToString.Replace("'", "''").Trim & "'"
                        Else
                            gspStr = "sp_update_SYCSTSET '" & gsCompany & "','" & _
                                        strPriCus & "','" & _
                                        strSecCus & "','" & _
                                        strItmCat & "','" & _
                                        dr.Item("ycs_csttyp").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ycs_ftyfmlopt").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ycs_hkfmlopt").ToString.Replace("'", "''").Trim & "','" & _
                                        gsUsrID & "'"
                        End If
                    ElseIf dr.RowState = DataRowState.Added And Not dr.Item("ycs_status") = "Y" Then

                        If dr.Item("ycs_credat").ToString.Trim = "" Then
                            gspStr = "sp_insert_SYCSTSET '" & gsCompany & "','" & _
                                        strPriCus & "','" & _
                                        strSecCus & "','" & _
                                        strItmCat & "','" & _
                                        dr.Item("ycs_csttyp").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ycs_ftyfmlopt").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ycs_hkfmlopt").ToString.Replace("'", "''").Trim & "','" & _
                                        gsUsrID & "'"
                        End If
                    End If

                    If gspStr <> "" Then
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading SYM00023 sp_update_SYCSTSET : " & rtnStr)
                            flgErr = True
                            Exit For
                        End If
                        gspStr = ""
                    End If
                Next

                If Not flgErr Then
                    rs_sycstset.AcceptChanges()
                    Call setStatus("Save")
                Else
                    save_ok = False
                    rs_sycstset.RejectChanges()
                    MsgBox("Record Not Updated!")
                End If
            End If

        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim strPriCus, strSecCus, strItmCat As String
        Dim flgErr As Boolean = False
        Dim flgReAct As Boolean = False

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            save_ok = True
            bindSrc.EndEdit()
            For Each row As DataGridViewRow In DataGrid.Rows

                If row.Cells("ycs_status").Value.ToString = "" Then

                    If Not chkGrdCellValue(row.Cells("ycs_csttyp"), "String", 255) Then
                        save_ok = False
                        flgReAct = True

                    ElseIf Not chkGrdCellValue(row.Cells("ycs_ftyfmlopt"), "String", 5) Then
                        save_ok = False
                        flgReAct = True

                    ElseIf Not chkGrdCellValue(row.Cells("ycs_hkfmlopt"), "String", 5) Then
                        save_ok = False
                        flgReAct = True

                    Else
                        If row.Cells("ycs_credat").Value.ToString = "" Then
                            For Each drr As DataGridViewRow In DataGrid.Rows
                                If drr.Index <> row.Index Then
                                    If drr.Cells("ycs_csttyp").Value.ToString.ToUpper = row.Cells("ycs_csttyp").Value.ToString.ToUpper And _
                                       drr.Cells("ycs_status").Value.ToString = "" Then

                                        MsgBox("Duplicated cost type " & drr.Cells("ycs_csttyp").Value.ToString & "!")
                                        save_ok = False
                                        flgReAct = True
                                        row.DataGridView.CurrentCell = row.Cells("ycs_csttyp")
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
                strPriCus = Split(cboPriCus.SelectedItem, " - ")(0).Replace("'", "''").Trim
                strSecCus = Split(cboSecCus.SelectedItem, " - ")(0).Replace("'", "''").Trim
                strItmCat = Split(cboItmCat.SelectedItem, " - ")(0).Replace("'", "''").Trim

                For Each dr As DataRow In rs_sycstset.Tables("RESULT").Rows

                    If dr.RowState = DataRowState.Modified Then
                        If dr.Item("ycs_status") = "Y" Then
                            gspStr = "sp_physical_delete_SYCSTSET '" & gsCompany & "','" & _
                                        strPriCus & "','" & _
                                        strSecCus & "','" & _
                                        strItmCat & "','" & _
                                        dr.Item("ycs_csttyp").ToString.Replace("'", "''").Trim & "'"
                        Else
                            gspStr = "sp_update_SYCSTSET '" & gsCompany & "','" & _
                                        strPriCus & "','" & _
                                        strSecCus & "','" & _
                                        strItmCat & "','" & _
                                        dr.Item("ycs_csttyp").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ycs_ftyfmlopt").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ycs_hkfmlopt").ToString.Replace("'", "''").Trim & "','" & _
                                        gsUsrID & "'"
                        End If
                    ElseIf dr.RowState = DataRowState.Added And Not dr.Item("ycs_status") = "Y" Then

                        If dr.Item("ycs_credat").ToString.Trim = "" Then
                            gspStr = "sp_insert_SYCSTSET '" & gsCompany & "','" & _
                                        strPriCus & "','" & _
                                        strSecCus & "','" & _
                                        strItmCat & "','" & _
                                        dr.Item("ycs_csttyp").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ycs_ftyfmlopt").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("ycs_hkfmlopt").ToString.Replace("'", "''").Trim & "','" & _
                                        gsUsrID & "'"
                        End If
                    End If

                    If gspStr <> "" Then
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading SYM00023 sp_update_SYCSTSET : " & rtnStr)
                            flgErr = True
                            Exit For
                        End If
                        gspStr = ""
                    End If
                Next

                If Not flgErr Then
                    rs_sycstset.AcceptChanges()
                    Call setStatus("Save")
                Else
                    save_ok = False
                    rs_sycstset.RejectChanges()
                    MsgBox("Record Not Updated!")
                End If
            End If

        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub SYM00023_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim YNC As Integer
        Dim flgMod As Boolean = False

        bindSrc.EndEdit()
        For Each dr As DataRow In rs_sycstset.Tables("RESULT").Rows
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

    Private Sub mmdExit_Click() Handles mmdExit.Click
        Me.Close()
    End Sub

   
    Private Sub lblLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblLeft.Click

    End Sub
    Private Sub lblRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRight.Click

    End Sub
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub
    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub
    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub
    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class