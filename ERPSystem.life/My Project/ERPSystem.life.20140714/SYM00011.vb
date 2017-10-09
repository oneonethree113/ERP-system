Public Class SYM00011

    Dim rs_SYM As New DataSet
    Dim rs_SYC As New DataSet
    Dim rs_venno As New DataSet
    Dim rs_effdat As New DataSet
    Dim bindSrcM As New BindingSource
    Dim bindSrcC As New BindingSource
    Dim strVenTyp As String
    Dim save_ok As Boolean
    Dim CanModify As Boolean = True
    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean

    Private Sub SYM00011_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Call AccessRight(Me.Name)
            Enq_right_local = Enq_right
            Del_right_local = Del_right

            Call FillComboVenno()
            Call FillComboUnitType()

            gspStr = "sp_select_SYTIESTR '" & gsCompany & "','','M'"
            rtnLong = execute_SQLStatement(gspStr, rs_SYM, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00011 sp_select_SYTIESTR : " & rtnStr)
            Else
                gspStr = "sp_select_SYTIESTR '" & gsCompany & "','','C'"
                rtnLong = execute_SQLStatement(gspStr, rs_SYC, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading SYM00011 sp_select_SYTIESTR : " & rtnStr)
                Else
                    Call setDataRowAttr()
                    Call displayGridTab(rs_SYM.Tables("RESULT").DefaultView, bindSrcM, Me.DataGridM)
                    Call displayGridTab(rs_SYC.Tables("RESULT").DefaultView, bindSrcC, Me.DataGridC)
                    Me.tpControl.SelectedIndex = 0
                    Call setStatus("Init")
                    Call Formstartup(Me.Name)
                End If
            End If
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub setDataRowAttr()

        For Each dc As DataColumn In rs_SYM.Tables("RESULT").Columns
            dc.ReadOnly = False
        Next
        For Each dr As DataRow In rs_SYM.Tables("RESULT").Rows
            dr.Item("yts_status") = ""
        Next
        rs_SYM.AcceptChanges()


        For Each dc As DataColumn In rs_SYC.Tables("RESULT").Columns
            dc.ReadOnly = False
        Next
        For Each dr As DataRow In rs_SYC.Tables("RESULT").Rows
            dr.Item("yts_status") = ""
        Next
        rs_SYC.AcceptChanges()

    End Sub

    Private Sub displayGridTab(ByVal dv As DataView, ByVal bindSrc As BindingSource, ByVal dgView As DataGridView)
        Dim i As Integer

        bindSrc.DataSource = dv
        With dgView
            .DataSource = Nothing
            .DataSource = bindSrc
            For i = 0 To .Columns.Count - 1

                If strVenTyp = "E" Then
                    Select Case i
                        Case 0
                            .Columns(i).Width = 40
                            .Columns(i).HeaderText = "Del"
                            .Columns(i).ReadOnly = True
                        Case 5
                            .Columns(i).Width = 90
                            .Columns(i).HeaderText = "Item Type"
                        Case 6
                            .Columns(i).Width = 160
                            .Columns(i).HeaderText = "From Qty (PC/MST CTN)"
                        Case 7
                            .Columns(i).Width = 150
                            .Columns(i).HeaderText = "To Qty (PC/MST CTN)"
                        Case 8
                            .Columns(i).Width = 90
                            .Columns(i).HeaderText = "MOQ (CTN)"
                        Case 9
                            .Columns(i).Width = 90
                            .Columns(i).HeaderText = "MOA (US$)"
                        Case Else
                            .Columns(i).Visible = False
                    End Select
                Else
                    Select Case i
                        Case 0
                            .Columns(i).Width = 40
                            .Columns(i).HeaderText = "Del"
                            .Columns(i).ReadOnly = True
                        Case 5
                            .Columns(i).Width = 90
                            .Columns(i).HeaderText = "Item Type"
                        Case 6
                            .Columns(i).Width = 160
                            .Columns(i).HeaderText = "From Qty (PC/MST CTN)"
                        Case 7
                            .Columns(i).Width = 150
                            .Columns(i).HeaderText = "To Qty (PC/MST CTN)"
                        Case 8
                            .Columns(i).Width = 90
                            .Columns(i).HeaderText = "MOQ (CTN)"
                        Case 9
                            .Columns(i).Width = 90
                            .Columns(i).HeaderText = "MOA (US$)"
                        Case 11
                            .Columns(i).Width = 120
                            .Columns(i).HeaderText = "Order CTN From"
                        Case 12
                            .Columns(i).Width = 100
                            .Columns(i).HeaderText = "Order CTN To"
                        Case 13
                            .Columns(i).Width = 100
                            .Columns(i).HeaderText = "MOQ Charge %"
                        Case 14
                            .Columns(i).Width = 100
                            .Columns(i).HeaderText = "Fty Rebate %"
                        Case 15
                            .Columns(i).Width = 100
                            .Columns(i).HeaderText = "Effective Date"
                            .Columns(i).ReadOnly = True
                        Case Else
                            .Columns(i).Visible = False
                    End Select
                End If
                .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i
        End With

        If Not dv.Count = 0 Then
            dv.Sort = "yts_upddat desc"
            Dim drv As DataRowView = dv(0)
            Me.StatusBar.Items("lblRight").Text = Format(drv.Item("yts_credat"), "MM/dd/yyyy") & " " & Format(drv.Item("yts_upddat"), "MM/dd/yyyy") & " " & drv.Item("yts_updusr")

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
            cmdInsRow.Enabled = False
            cmdDelRow.Enabled = False
            cmdExit.Enabled = True
            cmdClear.Enabled = True
            cmdSearch.Enabled = False

            cmdFirst.Enabled = False
            cmdLast.Enabled = False
            cmdNext.Enabled = False
            cmdPrevious.Enabled = False

            CboVCde.Enabled = True
            cboEffDat.Enabled = True
            cboUnttyp.Enabled = False
            cmdAddEffDat.Enabled = False
            txtEffDat.Visible = False
            cboEffDat.Visible = True

            Call ResetDefaultDisp()
            Call SetStatusBar(mode)

        ElseIf mode = "InsRow" Then
            cmdCopy.Enabled = False
            cmdFind.Enabled = False
            cmdSave.Enabled = Enq_right_local
            cmdDelRow.Enabled = Del_right_local

            CboVCde.Enabled = False
            cboEffDat.Enabled = False
            cboUnttyp.Enabled = True
            cmdAddEffDat.Enabled = False

            Call SetStatusBar(mode)

        ElseIf mode = "Save" Then
            Call ResetDefaultDisp()
            Call SetStatusBar(mode)
            MsgBox("Record Saved!")
            Call SYM00011_Load(Nothing, Nothing)

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

    Private Sub FillComboVenno()
        Dim dr() As DataRow = Nothing
        Dim i As Integer

        Try
            If Not rs_venno Is Nothing Then
                rs_venno = Nothing
            End If

            gspStr = "sp_select_VNBASINF_VENNO '" & gsCompany & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_venno, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00011 sp_select_VNBASINF_VENN : " & rtnStr)
            Else
                Me.CboVCde.Items.Clear()
                If gsFlgCst = 1 And gsFlgCstExt = 0 Then
                    dr = rs_venno.Tables("RESULT").Select("vbi_ventyp <> 'E'")
                ElseIf gsFlgCstExt = 1 And gsFlgCst = 0 Then
                    dr = rs_venno.Tables("RESULT").Select("vbi_ventyp = 'E'")
                ElseIf gsFlgCstExt = 1 And gsFlgCst = 1 Then
                    dr = rs_venno.Tables("RESULT").Select("")
                End If

                For i = 0 To dr.Length - 1
                    Me.CboVCde.Items.Add(dr(i).Item("vbi_venno").ToString & " - " & dr(i).Item("vbi_vensna").ToString)
                Next
            End If
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub FillComboUnitType()
        Dim rs_unttyp As New DataSet

        Try
            gspStr = "sp_list_SYTIESTR_unttyp '" & gsCompany & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_unttyp, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00011 sp_list_SYTIESTR_unttyp : " & rtnStr)
            Else
                Me.cboUnttyp.Items.Clear()
                Me.cboEffDat.Items.Clear()
                For Each dr As DataRow In rs_unttyp.Tables("RESULT").Rows
                    Me.cboUnttyp.Items.Add(dr.Item("ycf_code1").ToString)
                Next
            End If
        Finally
            rs_unttyp = Nothing
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub FillComboEffDat(ByVal strVenno As String)

        Try
            If Not rs_effdat Is Nothing Then
                rs_effdat = Nothing
            End If

            gspStr = "sp_select_SYTIESTR_Grp '" & gsCompany & "','" & strVenno & "','M'"
            rtnLong = execute_SQLStatement(gspStr, rs_effdat, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00011 sp_select_SYTIESTR_Grp : " & rtnStr)
            Else
                Me.cboEffDat.Items.Clear()
                For Each dr As DataRow In rs_effdat.Tables("RESULT").Rows
                    Me.cboEffDat.Items.Add(Format(dr.Item("yts_effdat"), "MM/dd/yyyy"))
                Next
            End If
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub CboVCde_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboVCde.SelectedIndexChanged
        If Not CboVCde.SelectedItem Is Nothing Then
            Call GetDataSet()
            If Not cboEffDat.Items.Count = 0 Then
                cboEffDat.SelectedIndex = 0
            Else
                Call ShowGrdDtl()
            End If
        End If
    End Sub

    Private Sub CboEffDat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboEffDat.SelectedIndexChanged
        Call ShowGrdDtl()
    End Sub

    Private Sub cboUnttyp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUnttyp.SelectedIndexChanged

        If Not cboUnttyp.SelectedItem Is Nothing Then
            For Each dr As DataRow In rs_SYM.Tables("RESULT").Rows
                dr.Item("yts_unttyp") = cboUnttyp.SelectedItem
            Next
            Me.DataGridM.Columns(8).HeaderText = "MOQ (" & cboUnttyp.SelectedItem & ")"
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        Dim YNC As Integer
        Dim flgMod As Boolean = False

        bindSrcC.EndEdit()
        bindSrcM.EndEdit()
        For Each dr As DataRow In rs_SYM.Tables("RESULT").Rows
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
                        Call SYM00011_Load(Nothing, Nothing)
                    Else
                        Exit Sub
                    End If
                Else
                    MsgBox("Sorry! You have not right to save!")
                End If
            ElseIf YNC = Windows.Forms.DialogResult.No Then
                Call SYM00011_Load(Nothing, Nothing)

            ElseIf YNC = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
        Else
            Call SYM00011_Load(Nothing, Nothing)
        End If

    End Sub

    Private Sub GetDataSet()
        Dim dr() As DataRow
        Dim strVenno As String

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            strVenno = Split(CboVCde.SelectedItem, " - ")(0).Trim
            dr = rs_venno.Tables("RESULT").Select("vbi_venno = '" & strVenno & "'")
            strVenTyp = dr(0).Item("vbi_ventyp").ToString

            If Not rs_SYM Is Nothing Then
                rs_SYM = Nothing
            End If

            If Not rs_SYC Is Nothing Then
                rs_SYC = Nothing
            End If

            gspStr = "sp_select_SYTIESTR '" & gsCompany & "','" & strVenno & "','C'"
            rtnLong = execute_SQLStatement(gspStr, rs_SYC, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00011 sp_select_SYTIESTR : " & rtnStr)
            Else
                gspStr = "sp_select_SYTIESTR '" & gsCompany & "','" & strVenno & "','M'"
                rtnLong = execute_SQLStatement(gspStr, rs_SYM, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading SYM00011 sp_select_SYTIESTR : " & rtnStr)
                Else
                    FillComboEffDat(strVenno)
                End If
            End If

        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub ShowGrdDtl()
        Dim dvM, dvC As DataView

        dvM = rs_SYM.Tables("RESULT").DefaultView
        dvC = rs_SYC.Tables("RESULT").DefaultView

        If cboEffDat.SelectedItem Is Nothing Then
            dvM.RowFilter = "yts_effdat = ''"
        Else
            dvM.RowFilter = "yts_effdat = #" & cboEffDat.SelectedItem & "#"
        End If

        If dvM.Count = 0 Then
            cmdInsRow.Enabled = Enq_right_local
            cmdDelRow.Enabled = False
            cmdAdd.Enabled = Enq_right_local
        Else
            cmdInsRow.Enabled = False
            cmdDelRow.Enabled = False
            If Enq_right_local = True Then
                cmdInsRow.Enabled = Enq_right_local
                cmdAdd.Enabled = Enq_right_local
                cmdDelRow.Enabled = True
            End If
        End If
        Call setDataRowAttr()
        Call displayGridTab(dvM, bindSrcM, Me.DataGridM)
        Call displayGridTab(dvC, bindSrcC, Me.DataGridC)
    End Sub

    Private Sub createComboBoxCell(ByVal cell As DataGridViewCell)
        Dim cboCell As New DataGridViewComboBoxCell
        Dim iCol As Integer = cell.ColumnIndex
        Dim iRow As Integer = cell.RowIndex
        Dim dgView As DataGridView = cell.DataGridView

        If iCol = 5 Then
            If strVenTyp = "E" Then
                cboCell.Items.Add("All")
            ElseIf strVenTyp = "I" Or strVenTyp = "J" Then
                cboCell.Items.Add("Assortment")
                cboCell.Items.Add("BOM")
                cboCell.Items.Add("Regular")
            End If
        End If
        cboCell.DropDownWidth = 150
        cboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

        dgView.Rows(iRow).Cells(iCol) = cboCell
        dgView.Rows(iRow).Cells(iCol).ReadOnly = False
    End Sub

    Private Sub DataGrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridM.CellClick, DataGridC.CellClick
        Dim DataGrid As DataGridView = CType(sender, DataGridView)
        Dim row As DataGridViewRow = DataGrid.CurrentRow

        If Not e.RowIndex = -1 Then

            If e.ColumnIndex = 0 Then
                ' Toggle Delete
                If Not row.Cells("yts_itmtyp").Value.ToString = "" Then
                    Call cmdDelRow_Click(sender, e)
                End If

            ElseIf e.ColumnIndex = 5 Then
                If row.Cells("yts_credat").Value.ToString = "" And row.Cells("yts_status").Value.ToString = "" Then
                    If TypeOf (DataGrid.CurrentCell) Is DataGridViewTextBoxCell Then
                        createComboBoxCell(DataGrid.CurrentCell)
                        DataGrid.BeginEdit(True)
                        cmdSave.Enabled = Enq_right_local
                    End If
                Else
                    row.Cells(e.ColumnIndex).ReadOnly = True
                End If

            ElseIf e.ColumnIndex >= 6 Or e.ColumnIndex <= 15 Then
                DataGrid.BeginEdit(True)
                cmdSave.Enabled = Enq_right_local
            End If
        End If
    End Sub

    Private Sub DataGrid_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DataGridM.CellValidating, DataGridC.CellValidating
        Dim row As DataGridViewRow = CType(sender, DataGridView).CurrentRow
        Dim dt As DataTable
        Dim strNewVal As String

        If tpControl.SelectedIndex = 0 Then
            dt = rs_SYM.Tables("RESULT")
        Else
            dt = rs_SYC.Tables("RESULT")
        End If

        strNewVal = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim

        If row.Cells(e.ColumnIndex).IsInEditMode Then

            If e.ColumnIndex = 6 Then
                If Not chkGrdCellValue(row.Cells("yts_qtyfr"), "+Integer") Then
                    e.Cancel = True
                End If
            End If

            If e.ColumnIndex = 7 Then
                If Not chkGrdCellValue(row.Cells("yts_qtyto"), "+Integer") Then
                    e.Cancel = True
                End If
            End If

            If e.ColumnIndex = 8 Then
                If Not chkGrdCellValue(row.Cells("yts_moq"), "Z+Integer") Then
                    e.Cancel = True
                End If
            End If

            If e.ColumnIndex = 9 Then
                If Not chkGrdCellValue(row.Cells("yts_moa"), "Z+Numeric") Then
                    e.Cancel = True
                End If
            End If

            If e.ColumnIndex = 11 Then
                If Not chkGrdCellValue(row.Cells("yts_moqchgfr"), "Z+Integer") Then
                    e.Cancel = True
                End If
            End If

            If e.ColumnIndex = 12 Then
                If Not chkGrdCellValue(row.Cells("yts_moqchgto"), "Z+Integer") Then
                    e.Cancel = True
                End If
            End If

            If e.ColumnIndex = 13 Then
                If Not chkGrdCellValue(row.Cells("yts_moqchg"), "Z+Integer") Then
                    e.Cancel = True
                End If
            End If

            If e.ColumnIndex = 14 Then
                If Not chkGrdCellValue(row.Cells("yts_moqrbe"), "Z+Integer") Then
                    e.Cancel = True
                End If
            End If
        End If

    End Sub

    Private Sub cmdAddEffDat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddEffDat.Click
        Dim drr() As DataRow
        Dim dr As DataRow
        Dim dt As DataTable

        If txtEffDat.Text = "" Then
            txtEffDat.Clear()
            txtEffDat.Focus()
            MsgBox("Effective date is empty, please input again!")

        ElseIf Not IsDate(txtEffDat.Text) Or Len(txtEffDat.Text) < 10 Then
            txtEffDat.Clear()
            txtEffDat.Focus()
            MsgBox("Effective date is not a valid date, please input again!")

        ElseIf DateTime.Compare(CType(txtEffDat.Text, Date), System.DateTime.Now) < 0 Then
            txtEffDat.Clear()
            txtEffDat.Focus()
            MsgBox("Effective date cannot earlier than today date, please input again!")

        Else
            dt = rs_effdat.Tables("RESULT")
            drr = dt.Select("yts_effdat = #" & txtEffDat.Text & "#")
            If drr.Length > 0 Then
                txtEffDat.Clear()
                txtEffDat.Focus()
                MsgBox("Effective date is duplicate, please input again!")
            Else
                dt = rs_effdat.Tables("RESULT")
                dr = dt.NewRow
                dr.Item("yts_effdat") = txtEffDat.Text
                dt.Rows.Add(dr)

                cboEffDat.Items.Add(txtEffDat.Text)
                cboEffDat.SelectedIndex = cboEffDat.Items.Count - 1
                Call cmdInsRow_Click(sender, e)
            End If
        End If

    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click

        cboEffDat.Visible = False
        txtEffDat.Visible = True
        cmdAddEffDat.Enabled = True
        txtEffDat.Focus()
        cboUnttyp.Enabled = True
    End Sub

    Private Sub cmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsRow.Click
        Dim DataGrid As DataGridView = Nothing
        Dim dt As DataTable = Nothing
        Dim dr As DataRow
        Dim strType As String = Nothing

        For Each ctrl As Control In tpControl.SelectedTab.Controls
            If TypeOf ctrl Is DataGridView Then
                DataGrid = CType(ctrl, DataGridView)
                If ctrl.Name = "DataGridM" Then
                    dt = rs_SYM.Tables("RESULT")
                    strType = "M"
                ElseIf ctrl.Name = "DataGridC" Then
                    dt = rs_SYC.Tables("RESULT")
                    strType = "C"
                End If
            End If
        Next

        For Each dr In dt.Rows
            If dr.Item("yts_itmtyp").ToString.Trim = "" Then
                MsgBox("Please input item type.")
                Exit Sub
            End If
        Next

        If cboEffDat.SelectedItem Is Nothing Then
            MsgBox("Effective Date is empty!")

        ElseIf strVenTyp = "E" And strType = "M" And dt.Rows.Count = 1 Then
            MsgBox("Only 1 record is allowed for External Vendor!")

        Else
            dr = dt.NewRow
            dr.Item("yts_status") = ""
            dr.Item("yts_tirtyp") = strType
            dr.Item("yts_venno") = Split(CboVCde.SelectedItem, " -")(0).Trim

            If cboEffDat.SelectedItem Is Nothing Then
                dr.Item("yts_effdat") = ""
            Else
                dr.Item("yts_effdat") = cboEffDat.SelectedItem
            End If

            dr.Item("yts_qtyfr") = 1

            If strVenTyp = "E" Then
                dr.Item("yts_itmtyp") = "All"
                dr.Item("yts_qtyto") = 9999
                If cboUnttyp.SelectedItem Is Nothing Then
                    dr.Item("yts_unttyp") = ""
                Else
                    dr.Item("yts_unttyp") = cboUnttyp.SelectedItem
                End If
            Else
                dr.Item("yts_unttyp") = "CTN"
                dr.Item("yts_qtyto") = 1
            End If

            dr.Item("yts_MOQ") = 0
            dr.Item("yts_MOA") = 0

            dr.Item("yts_comrat") = 0
            dr.Item("yts_moqchgfr") = 0
            dr.Item("yts_moqchgto") = 0
            dr.Item("yts_moqchg") = 0
            dr.Item("yts_moqrbe") = 0
            dt.Rows.Add(dr)

            For Each drr As DataGridViewRow In DataGrid.Rows
                If IsDBNull(drr.Cells(5).Value) Then
                    DataGrid.CurrentCell = drr.Cells(5)
                    createComboBoxCell(DataGrid.CurrentCell)
                    DataGrid.BeginEdit(True)
                End If
            Next
            Call setStatus("InsRow")
        End If
    End Sub

    Private Sub cmdDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelRow.Click
        Dim row As DataGridViewRow = Nothing
        Dim cellStyle As New DataGridViewCellStyle

        For Each ctrl As Control In tpControl.SelectedTab.Controls
            If TypeOf ctrl Is DataGridView Then
                row = CType(ctrl, DataGridView).CurrentRow
            End If
        Next

        ' Toggle(Delete)
        If Not row Is Nothing Then
            If Not row.Cells("yts_itmtyp").Value.ToString = "" Then
                If row.Cells("yts_status").Value.ToString = "" Then
                    row.Cells("yts_status").Value = "Y"
                    cellStyle.BackColor = Color.LightBlue
                Else
                    row.Cells("yts_status").Value = ""
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
            If strVenTyp = "E" Then
                If Not rs_SYM.Tables("RESULT") Is Nothing Then
                    If rs_SYM.Tables("RESULT").Rows.Count > 0 Then
                        For Each drr As DataRow In rs_SYM.Tables("RESULT").Rows
                            If drr.Item("yts_unttyp").ToString = "" Then
                                save_ok = False
                                Exit Sub
                            End If
                        Next
                    End If
                End If
            End If

            For Each row As DataGridViewRow In dv.Rows

                If row.Cells("yts_status").Value.ToString = "" Then

                    If Not chkGrdCellValue(row.Cells("yts_itmtyp"), "String") Then
                        save_ok = False

                    ElseIf Not chkGrdCellValue(row.Cells("yts_qtyfr"), "+Integer") Then
                        save_ok = False

                    ElseIf Not chkGrdCellValue(row.Cells("yts_qtyto"), "+Integer") Then
                        save_ok = False

                    ElseIf Not chkGrdCellValue(row.Cells("yts_moq"), "Z+Integer") Then
                        save_ok = False

                    ElseIf Not chkGrdCellValue(row.Cells("yts_moa"), "Z+Numeric") Then
                        save_ok = False

                    ElseIf Not chkGrdCellValue(row.Cells("yts_moqchg"), "Z+Integer") Then
                        save_ok = False

                    ElseIf Not chkGrdCellValue(row.Cells("yts_moqchgfr"), "Z+Integer") Then
                        save_ok = False

                    ElseIf Not chkGrdCellValue(row.Cells("yts_moqchgto"), "Z+Integer") Then
                        save_ok = False

                    ElseIf Not chkGrdCellValue(row.Cells("yts_moqrbe"), "Z+Integer") Then
                        save_ok = False

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
                        If dr.Item("yts_status") = "Y" Then
                            gspStr = "sp_physical_delete_SYTIESTR '" & gsCompany & "','" & _
                                        dr.Item("yts_venno").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yts_tirtyp").ToString.Replace("'", "''").Trim & "'," & _
                                        dr.Item("yts_tirseq").ToString.Replace("'", "''").Trim
                        Else
                            gspStr = "sp_update_SYTIESTR '" & gsCompany & "','" & _
                                        dr.Item("yts_venno").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yts_tirtyp").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yts_itmtyp").ToString.Replace("'", "''").Trim & "'," & _
                                        dr.Item("yts_tirseq").ToString.Replace("'", "''").Trim & "," & _
                                        dr.Item("yts_qtyfr").ToString.Replace("'", "''").Trim & "," & _
                                        dr.Item("yts_qtyto").ToString.Replace("'", "''").Trim & "," & _
                                        dr.Item("yts_MOQ").ToString.Replace("'", "''").Trim & "," & _
                                        dr.Item("yts_MOA").ToString.Replace("'", "''").Trim & "," & _
                                        dr.Item("yts_comrat").ToString.Replace("'", "''").Trim & "," & _
                                        dr.Item("yts_moqchgfr").ToString.Replace("'", "''").Trim & "," & _
                                        dr.Item("yts_moqchgto").ToString.Replace("'", "''").Trim & "," & _
                                        dr.Item("yts_moqchg").ToString.Replace("'", "''").Trim & "," & _
                                        dr.Item("yts_moqrbe").ToString.Replace("'", "''").Trim & ",'" & _
                                        dr.Item("yts_effdat").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yts_unttyp").ToString.Replace("'", "''").Trim & "','" & _
                                        gsUsrID & "'"
                        End If
                    ElseIf dr.RowState = DataRowState.Added And Not dr.Item("yts_status") = "Y" Then

                        If dr.Item("yts_credat").ToString.Trim = "" Then
                            gspStr = "sp_insert_SYTIESTR '" & gsCompany & "','" & _
                                        dr.Item("yts_venno").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yts_tirtyp").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yts_itmtyp").ToString.Replace("'", "''").Trim & "'," & _
                                        dr.Item("yts_qtyfr").ToString.Replace("'", "''").Trim & "," & _
                                        dr.Item("yts_qtyto").ToString.Replace("'", "''").Trim & "," & _
                                        dr.Item("yts_MOQ").ToString.Replace("'", "''").Trim & "," & _
                                        dr.Item("yts_MOA").ToString.Replace("'", "''").Trim & "," & _
                                        dr.Item("yts_comrat").ToString.Replace("'", "''").Trim & "," & _
                                        dr.Item("yts_moqchgfr").ToString.Replace("'", "''").Trim & "," & _
                                        dr.Item("yts_moqchgto").ToString.Replace("'", "''").Trim & "," & _
                                        dr.Item("yts_moqchg").ToString.Replace("'", "''").Trim & "," & _
                                        dr.Item("yts_moqrbe").ToString.Replace("'", "''").Trim & ",'" & _
                                        dr.Item("yts_effdat").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yts_unttyp").ToString.Replace("'", "''").Trim & "','" & _
                                        gsUsrID & "'"
                        End If
                    End If

                    If gspStr <> "" Then
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading SYM00011 sp_update_SYTIESTR : " & rtnStr)
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

    Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSave.Click

        bindSrcC.EndEdit()
        bindSrcM.EndEdit()
        Call cmdSaveTab(rs_SYM.Tables("RESULT"), Me.DataGridM)
        If save_ok Then
            Call cmdSaveTab(rs_SYC.Tables("RESULT"), Me.DataGridC)
        End If

        If save_ok Then
            Call setStatus("Save")
        Else
            MsgBox("Record Not Updated!")
        End If
    End Sub

    Private Sub SYM00011_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim YNC As Integer
        Dim flgMod As Boolean = False

        bindSrcC.EndEdit()
        bindSrcM.EndEdit()

        For Each dr As DataRow In rs_SYM.Tables("RESULT").Rows
            If dr.RowState = DataRowState.Modified Or dr.RowState = DataRowState.Added Then
                flgMod = True
            End If
        Next

        For Each dr As DataRow In rs_SYC.Tables("RESULT").Rows
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
        Else
            e.Cancel = False
        End If

    End Sub

    Private Sub CmdExit_Click() Handles cmdExit.Click
        Me.Close()
    End Sub

End Class