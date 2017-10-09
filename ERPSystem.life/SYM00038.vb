Public Class SYM00038

    Inherits System.Windows.Forms.Form

    Dim rs_curex As New DataSet
    Dim rs_curEffDat As New DataSet
    Dim bindSrc As New BindingSource
    Dim save_ok As Boolean
    Dim CanModify As Boolean = True
    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean

    Private Sub SYM00038_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Microsoft.VisualBasic.Left(gsUsrID, 3) <> "ACT" Then
            mmdSave.Enabled = False
        Else
            mmdSave.Enabled = True
        End If

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Call AccessRight(Me.Name)
            Enq_right_local = Enq_right
            Del_right_local = Del_right

            If Not rs_curex Is Nothing Then
                rs_curex = Nothing
            End If

            gspStr = "sp_select_CLCUREX '" & gsCompany & "','','N'"
            rtnLong = execute_SQLStatement(gspStr, rs_curex, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00038 sp_select_CLCUREX : " & rtnStr)
            Else
                Call FillComboEffDate()
                Call setDataRowAttr()
                Call displayGrid()
                txt_tor.Text = rs_curex.Tables("RESULT").Rows(0).Item("cce_tor")


                Call setStatus("Init")
            End If
            Call Formstartup(Me.Name)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub setDataRowAttr()
        Dim dt As DataTable = rs_curex.Tables("RESULT")

        If Not dt Is Nothing Then
            For Each dc As DataColumn In dt.Columns
                dc.ReadOnly = False
            Next
            rs_curex.Tables("RESULT").Columns("DEL").ColumnName = "cce_status"
            For Each dr As DataRow In dt.Rows
                dr.Item("cce_status") = ""
            Next
            rs_curex.AcceptChanges()
        End If

        rs_curEffDat.Tables("RESULT").Columns("cce_effdat").ReadOnly = False
        rs_curEffDat.Tables("RESULT").Columns("cce_iseff").ReadOnly = False
    End Sub

    Private Sub FillComboEffDate()
        Dim i, intDef As Integer

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            gspStr = "sp_select_CLCUREX '" & gsCompany & "','','Y'"
            rtnLong = execute_SQLStatement(gspStr, rs_curEffDat, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00038 sp_select_CLCUREX : " & rtnStr)
            Else
                Me.cboEffDat.Items.Clear()
                i = 0
                Dim dv As DataView = rs_curEffDat.Tables("RESULT").DefaultView
                dv.Sort = "cce_effdat DESC"

                For Each drv As DataRowView In dv
                    If drv.Item("cce_iseff") = "Y" Then
                        intDef = i
                    End If
                    Me.cboEffDat.Items.Add(Format(drv.Item("cce_effdat"), "MM/dd/yyyy"))
                    i += 1
                Next
                Me.cboEffDat.SelectedIndex = intDef
            End If
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub cboEffDat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboEffDat.SelectedIndexChanged
        Dim dr() As DataRow

        If Not cboEffDat.SelectedItem Is Nothing Then
            dr = rs_curEffDat.Tables("RESULT").Select("cce_iseff = 'Y' and cce_effdat = #" & cboEffDat.SelectedItem & "#")
            If dr.Length > 0 Then
                Me.chkEff.Checked = True
            Else
                Me.chkEff.Checked = False
            End If

            Dim dv As DataView = rs_curex.Tables("RESULT").DefaultView
            dv.RowFilter = "cce_display = 'Y' and cce_effdat = #" & cboEffDat.SelectedItem & "#"
            Call displayGrid(dv)
        End If
    End Sub

    Private Sub cmdAddEffDat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddEffDat.Click
        Dim drr() As DataRow
        Dim dr As DataRow
        Dim dt As DataTable
        Dim i As Integer

        If cmdAddEffDat.Text = "Add" Then
            Call setStatus("Add")
            cmdAddEffDat.Text = "OK"
            chkEff.Checked = False
            txtEffDat.Clear()
            txtEffDat.Focus()
        Else
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
                dt = rs_curEffDat.Tables("RESULT")
                drr = dt.Select("cce_effdat = #" & txtEffDat.Text & "#")
                If drr.Length > 0 Then
                    txtEffDat.Clear()
                    txtEffDat.Focus()
                    MsgBox("Effective date is duplicate, please input again!")

                Else
                    dt = rs_curex.Tables("RESULT")
                    drr = dt.Select("cce_iseff = 'Y'")
                    For i = 0 To drr.Length - 1
                        dr = dt.NewRow
                        dr.Item("cce_status") = ""
                        dr.Item("cce_frmcur") = drr(i).Item("cce_frmcur")
                        dr.Item("cce_tocur") = drr(i).Item("cce_tocur")
                        dr.Item("cce_buyrat") = drr(i).Item("cce_buyrat")
                        dr.Item("cce_selrat") = drr(i).Item("cce_selrat")
                        dr.Item("cce_display") = drr(i).Item("cce_display")
                        dr.Item("cce_effdat") = CType(txtEffDat.Text, DateTime)
                        If chkEff.Checked Then
                            dr.Item("cce_iseff") = "Y"
                            drr(i).Item("cce_iseff") = "N"
                        Else
                            dr.Item("cce_iseff") = "N"
                        End If
                        dt.Rows.Add(dr)
                    Next

                    dt = rs_curEffDat.Tables("RESULT")
                    drr = dt.Select("cce_iseff = 'Y'")
                    For i = 0 To drr.Length - 1
                        dr = dt.NewRow
                        dr.Item("cce_effdat") = CType(txtEffDat.Text, DateTime)
                        If chkEff.Checked Then
                            dr.Item("cce_iseff") = "Y"
                            drr(i).Item("cce_iseff") = "N"
                        Else
                            dr.Item("cce_iseff") = "N"
                        End If
                        dt.Rows.Add(dr)
                    Next

                    cboEffDat.Items.Add(txtEffDat.Text)
                    cboEffDat.SelectedIndex = cboEffDat.Items.Count - 1
                    cmdAddEffDat.Text = "Add"
                    Call setStatus("InsRow")
                End If
            End If
        End If

    End Sub

    Private Sub mmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdClear.Click
        Dim YNC As Integer
        Dim flgMod As Boolean = False

        bindSrc.EndEdit()
        For Each dr As DataRow In rs_curex.Tables("RESULT").Rows
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
                        Call SYM00038_Load(Nothing, Nothing)
                    Else
                        Exit Sub
                    End If
                Else
                    MsgBox("Sorry! You have not right to save!")
                End If
            ElseIf YNC = Windows.Forms.DialogResult.No Then
                Call SYM00038_Load(Nothing, Nothing)

            ElseIf YNC = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
        Else
            Call SYM00038_Load(Nothing, Nothing)
        End If

    End Sub

    Private Sub displayGrid(Optional ByVal dv As DataView = Nothing)
        Dim i As Integer

        If dv Is Nothing Then dv = rs_curex.Tables("RESULT").DefaultView
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
                        .Columns(i).Width = 100
                        .Columns(i).HeaderText = "From Curr."
                        .Columns(i).ReadOnly = True
                    Case 3
                        .Columns(i).Width = 100
                        .Columns(i).HeaderText = "To Curr."
                    Case 4
                        .Columns(i).Width = 150
                        .Columns(i).HeaderText = "Buy Rate"
                    Case 5
                        .Columns(i).Width = 150
                        .Columns(i).HeaderText = "Sell Rate"
                    Case Else
                        .Columns(i).Visible = False
                End Select
                .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i
        End With
        Me.StatusBar.Items("lblRight").Text = ""
        If Not dv.Count = 0 Then
            dv.Sort = "cce_upddat desc"
            Dim drv As DataRowView = dv(0)
            If drv.Item("cce_credat").ToString = "" Then
                Me.StatusBar.Items("lblRight").Text = ""
            Else
                Me.StatusBar.Items("lblRight").Text = Format(drv.Item("cce_upddat"), "MM/dd/yyyy") & " " & Format(drv.Item("cce_upddat"), "MM/dd/yyyy") & " " & drv.Item("cce_updusr")
            End If
            dv.Sort = Nothing
        End If
    End Sub

    Private Sub setStatus(ByVal mode As String)

        If mode = "Init" Then
            mmdAdd.Enabled = False
            mmdSave.Enabled = Enq_right_local
            mmdDelete.Enabled = False
            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdExit.Enabled = True
            mmdClear.Enabled = True
            mmdInsRow.Enabled = False
            mmdDelRow.Enabled = False
            mmdSearch.Enabled = False

            txtEffDat.Visible = False
            cboEffDat.Visible = True
            cmdAddEffDat.Text = "Add"

            Call ResetDefaultDisp()
            Call SetStatusBar(mode)

            mmdPrint.Enabled = False
            mmdAttach.Enabled = False
            mmdFunction.Enabled = False
            mmdLink.Enabled = False


        ElseIf mode = "Add" Then
            mmdAdd.Enabled = False
            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdClear.Enabled = True
            mmdSave.Enabled = False

            mmdInsRow.Enabled = False
            mmdDelRow.Enabled = False
            txtEffDat.Visible = True
            cboEffDat.Visible = False
            Call SetStatusBar(mode)

        ElseIf mode = "InsRow" Then
            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdSave.Enabled = Enq_right_local
            mmdInsRow.Enabled = False
            mmdDelRow.Enabled = False
            txtEffDat.Visible = False
            cboEffDat.Visible = True
            Call SetStatusBar(mode)

        ElseIf mode = "Save" Then
            Call ResetDefaultDisp()
            Call SetStatusBar(mode)
            MsgBox("Record Saved!")
            Call SYM00038_Load(Nothing, Nothing)

        ElseIf mode = "DelRow" Then
            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdSave.Enabled = Enq_right_local
            mmdDelRow.Enabled = Del_right_local
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

    Private Sub DataGrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGrid.CellClick
        Dim row As DataGridViewRow = DataGrid.CurrentRow

        If Not e.RowIndex = -1 Then

            If e.ColumnIndex = 4 Or e.ColumnIndex = 5 Then
                If row.Cells("cce_credat").Value.ToString = "" And row.Cells("cce_status").Value.ToString = "" Then
                    row.Cells(e.ColumnIndex).ReadOnly = False
                    DataGrid.BeginEdit(True)
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
                If Not chkGrdCellValue(row.Cells("cce_buyrat"), "+Numeric") Then
                    e.Cancel = True
                Else
                    ConvertExRate(row.Cells("cce_frmcur").Value, row.Cells("cce_tocur").Value, row.Cells("cce_effdat").Value, CType(strNewVal, Double), CType(row.Cells("cce_selrat").Value, Double))
                End If
            End If

            If e.ColumnIndex = 5 Then
                If Not chkGrdCellValue(row.Cells("cce_selrat"), "+Numeric") Then
                    e.Cancel = True
                Else
                    ConvertExRate(row.Cells("cce_frmcur").Value, row.Cells("cce_tocur").Value, row.Cells("cce_effdat").Value, CType(row.Cells("cce_buyrat").Value, Double), CType(strNewVal, Double))
                End If
            End If
        End If

    End Sub

    Private Sub ConvertExRate(ByVal strFrmCur As String, ByVal strToCur As String, ByVal strEffDat As String, ByVal dblBuyRat As Double, ByVal dblSelRat As Double)
        Dim dr() As DataRow

        dr = rs_curex.Tables("RESULT").Select("cce_tocur = '" & strFrmCur & "' and cce_frmcur = '" & strToCur & "' and cce_effdat = #" & strEffDat & "#")
        If dr.Length > 0 Then
            dr(0).Item("cce_buyrat") = 1 / dblBuyRat
            dr(0).Item("cce_selrat") = 1 / dblSelRat
        End If
    End Sub

    Private Sub chkEff_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkEff.Click

        If Not cboEffDat.SelectedItem Is Nothing Then
            If chkEff.Checked Then
                For Each dr As DataRow In rs_curEffDat.Tables("RESULT").Rows
                    If dr.Item("cce_effdat") = CType(cboEffDat.SelectedItem, DateTime) Then
                        dr.Item("cce_iseff") = "Y"
                    Else
                        dr.Item("cce_iseff") = "N"
                    End If
                Next

                For Each dr As DataRow In rs_curex.Tables("RESULT").Rows
                    If dr.Item("cce_effdat") = CType(cboEffDat.SelectedItem, DateTime) Then
                        dr.Item("cce_iseff") = "Y"
                    Else
                        dr.Item("cce_iseff") = "N"
                    End If
                Next
            Else
                For Each dr As DataRow In rs_curEffDat.Tables("RESULT").Rows
                    If dr.Item("cce_effdat") = CType(cboEffDat.SelectedItem, DateTime) Then
                        dr.Item("cce_iseff") = "N"
                    End If
                Next

                For Each dr As DataRow In rs_curex.Tables("RESULT").Rows
                    If dr.Item("cce_effdat") = CType(cboEffDat.SelectedItem, DateTime) Then
                        dr.Item("cce_iseff") = "N"
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub mmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mmdSave.Click

        gspStr = "sp_update_CLCUREX_tor '" & txt_tor.Text.Trim & "','" & gsUsrID & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SYM00038 sp_update_CLCUREX : " & rtnStr)

            Exit Sub
        End If


        Dim drr() As DataRow
        Dim flgErr As Boolean = False
        Dim flgReAct As Boolean = False

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            save_ok = True
            bindSrc.EndEdit()
            For Each row As DataGridViewRow In DataGrid.Rows

                If row.Cells("cce_status").Value.ToString = "" Then

                    If Not chkGrdCellValue(row.Cells("cce_buyrat"), "+Numeric") Then
                        save_ok = False

                    ElseIf Not chkGrdCellValue(row.Cells("cce_selrat"), "+Numeric") Then
                        save_ok = False

                    End If
                End If

                If Not save_ok Then
                    DataGrid.BeginEdit(True)
                    Exit For
                End If
            Next

            drr = rs_curEffDat.Tables("RESULT").Select("cce_iseff = 'Y'")
            If drr.Length = 0 Then
                save_ok = False
                MsgBox("No effective date is set!")
            End If

            If Not save_ok Then
                Exit Sub
            Else
                gspStr = ""
                For Each dr As DataRow In rs_curex.Tables("RESULT").Rows

                    If dr.RowState = DataRowState.Modified Then

                        If Not dr.Item("cce_status") = "Y" Then
                            gspStr = "sp_update_CLCUREX '" & gsCompany & "','" & _
                                        dr.Item("cce_frmcur").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("cce_tocur").ToString.Replace("'", "''").Trim & "'," & _
                                        dr.Item("cce_buyrat").ToString.Replace("'", "''").Trim & "," & _
                                        dr.Item("cce_selrat").ToString.Replace("'", "''").Trim & ",'" & _
                                        dr.Item("cce_effdat").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("cce_iseff").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("cce_display").ToString.Replace("'", "''").Trim & "','" & _
                                        gsUsrID & "'"
                        End If
                    ElseIf dr.RowState = DataRowState.Added And Not dr.Item("cce_status") = "Y" Then

                        If dr.Item("cce_credat").ToString.Trim = "" Then
                            gspStr = "sp_insert_CLCUREX '" & gsCompany & "','" & _
                                        dr.Item("cce_frmcur").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("cce_tocur").ToString.Replace("'", "''").Trim & "'," & _
                                        dr.Item("cce_buyrat").ToString.Replace("'", "''").Trim & "," & _
                                        dr.Item("cce_selrat").ToString.Replace("'", "''").Trim & ",'" & _
                                        dr.Item("cce_effdat").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("cce_iseff").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("cce_display").ToString.Replace("'", "''").Trim & "','" & _
                                        gsUsrID & "'"
                        End If
                    End If

                    If gspStr <> "" Then
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading SYM00038 sp_update_CLCUREX : " & rtnStr)
                            flgErr = True
                            Exit For
                        End If
                        gspStr = ""
                    End If
                Next

                If Not flgErr Then
                    rs_curex.AcceptChanges()
                    Call setStatus("Save")
                Else
                    save_ok = False
                    rs_curex.RejectChanges()
                    MsgBox("Record Not Updated!")
                End If
            End If

        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub SYM00038_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim YNC As Integer
        Dim flgMod As Boolean = False

        bindSrc.EndEdit()
        For Each dr As DataRow In rs_curex.Tables("RESULT").Rows
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
        Me.Close()
    End Sub

End Class
