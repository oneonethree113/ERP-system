Public Class CLM00005

    Inherits System.Windows.Forms.Form

    Dim rs_curex As New DataSet
    Dim rs_curEffDat As New DataSet
    Dim bindSrc As New BindingSource
    Dim save_ok As Boolean
    Dim CanModify As Boolean = True
    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean

    Private Sub CLM00005_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Call AccessRight(Me.Name)
            Enq_right_local = Enq_right
            Del_right_local = Del_right

            If Not rs_curex Is Nothing Then
                rs_curex = Nothing
            End If

            gspStr = "sp_select_SYCUREX '" & gsCompany & "','','N'"
            rtnLong = execute_SQLStatement(gspStr, rs_curex, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading CLM00005 sp_select_SYCUREX : " & rtnStr)
            Else
                Call FillComboEffDate()
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
        Dim dt As DataTable = rs_curex.Tables("RESULT")

        If Not dt Is Nothing Then
            For Each dc As DataColumn In dt.Columns
                dc.ReadOnly = False
            Next
            rs_curex.Tables("RESULT").Columns("DEL").ColumnName = "yce_status"
            For Each dr As DataRow In dt.Rows
                dr.Item("yce_status") = ""
            Next
            rs_curex.AcceptChanges()
        End If

        rs_curEffDat.Tables("RESULT").Columns("yce_effdat").ReadOnly = False
        rs_curEffDat.Tables("RESULT").Columns("yce_iseff").ReadOnly = False
    End Sub

    Private Sub FillComboEffDate()
        Dim i, intDef As Integer

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            gspStr = "sp_select_SYCUREX '" & gsCompany & "','','Y'"
            rtnLong = execute_SQLStatement(gspStr, rs_curEffDat, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading CLM00005 sp_select_SYCUREX : " & rtnStr)
            Else
                Me.cboEffDat.Items.Clear()
                i = 0
                Dim dv As DataView = rs_curEffDat.Tables("RESULT").DefaultView
                dv.Sort = "yce_effdat DESC"

                For Each drv As DataRowView In dv
                    If drv.Item("yce_iseff") = "Y" Then
                        intDef = i
                    End If
                    Me.cboEffDat.Items.Add(Format(drv.Item("yce_effdat"), "MM/dd/yyyy"))
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
            dr = rs_curEffDat.Tables("RESULT").Select("yce_iseff = 'Y' and yce_effdat = #" & cboEffDat.SelectedItem & "#")
            If dr.Length > 0 Then
                Me.chkEff.Checked = True
            Else
                Me.chkEff.Checked = False
            End If

            Dim dv As DataView = rs_curex.Tables("RESULT").DefaultView
            dv.RowFilter = "yce_display = 'Y' and yce_effdat = #" & cboEffDat.SelectedItem & "#"
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
                drr = dt.Select("yce_effdat = #" & txtEffDat.Text & "#")
                If drr.Length > 0 Then
                    txtEffDat.Clear()
                    txtEffDat.Focus()
                    MsgBox("Effective date is duplicate, please input again!")

                Else
                    dt = rs_curex.Tables("RESULT")
                    drr = dt.Select("yce_iseff = 'Y'")
                    For i = 0 To drr.Length - 1
                        dr = dt.NewRow
                        dr.Item("yce_status") = ""
                        dr.Item("yce_frmcur") = drr(i).Item("yce_frmcur")
                        dr.Item("yce_tocur") = drr(i).Item("yce_tocur")
                        dr.Item("yce_buyrat") = drr(i).Item("yce_buyrat")
                        dr.Item("yce_selrat") = drr(i).Item("yce_selrat")
                        dr.Item("yce_display") = drr(i).Item("yce_display")
                        dr.Item("yce_effdat") = CType(txtEffDat.Text, DateTime)
                        If chkEff.Checked Then
                            dr.Item("yce_iseff") = "Y"
                            drr(i).Item("yce_iseff") = "N"
                        Else
                            dr.Item("yce_iseff") = "N"
                        End If
                        dt.Rows.Add(dr)
                    Next

                    dt = rs_curEffDat.Tables("RESULT")
                    drr = dt.Select("yce_iseff = 'Y'")
                    For i = 0 To drr.Length - 1
                        dr = dt.NewRow
                        dr.Item("yce_effdat") = CType(txtEffDat.Text, DateTime)
                        If chkEff.Checked Then
                            dr.Item("yce_iseff") = "Y"
                            drr(i).Item("yce_iseff") = "N"
                        Else
                            dr.Item("yce_iseff") = "N"
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

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
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
                    Call cmdSave_Click(sender, e)

                    If save_ok Then
                        Call CLM00005_Load(Nothing, Nothing)
                    Else
                        Exit Sub
                    End If
                Else
                    MsgBox("Sorry! You have not right to save!")
                End If
            ElseIf YNC = Windows.Forms.DialogResult.No Then
                Call CLM00005_Load(Nothing, Nothing)

            ElseIf YNC = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
        Else
            Call CLM00005_Load(Nothing, Nothing)
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

        If Not dv.Count = 0 Then
            dv.Sort = "yce_upddat desc"
            Dim drv As DataRowView = dv(0)
            If drv.Item("yce_credat").ToString = "" Then
                Me.StatusBar.Items("lblRight").Text = ""
            Else
                Me.StatusBar.Items("lblRight").Text = Format(drv.Item("yce_upddat"), "MM/dd/yyyy") & " " & Format(drv.Item("yce_upddat"), "MM/dd/yyyy") & " " & drv.Item("yce_updusr")
            End If
            dv.Sort = Nothing
        End If
    End Sub

    Private Sub setStatus(ByVal mode As String)

        If mode = "Init" Then
            cmdAdd.Enabled = False
            cmdSave.Enabled = Enq_right_local
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
            txtEffDat.Visible = False
            cboEffDat.Visible = True
            cmdAddEffDat.Text = "Add"

            Call ResetDefaultDisp()
            Call SetStatusBar(mode)

        ElseIf mode = "Add" Then
            cmdAdd.Enabled = False
            cmdCopy.Enabled = False
            cmdFind.Enabled = False
            cmdClear.Enabled = True
            cmdSave.Enabled = False

            cmdInsRow.Enabled = False
            cmdDelRow.Enabled = False
            txtEffDat.Visible = True
            cboEffDat.Visible = False
            Call SetStatusBar(mode)

        ElseIf mode = "InsRow" Then
            cmdCopy.Enabled = False
            cmdFind.Enabled = False
            cmdSave.Enabled = Enq_right_local
            cmdInsRow.Enabled = False
            cmdDelRow.Enabled = False
            txtEffDat.Visible = False
            cboEffDat.Visible = True
            Call SetStatusBar(mode)

        ElseIf mode = "Save" Then
            Call ResetDefaultDisp()
            Call SetStatusBar(mode)
            MsgBox("Record Saved!")
            Call CLM00005_Load(Nothing, Nothing)

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

    Private Sub DataGrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGrid.CellClick
        Dim row As DataGridViewRow = DataGrid.CurrentRow

        If Not e.RowIndex = -1 Then

            If e.ColumnIndex = 4 Or e.ColumnIndex = 5 Then
                If row.Cells("yce_credat").Value.ToString = "" And row.Cells("yce_status").Value.ToString = "" Then
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
                If Not chkGrdCellValue(row.Cells("yce_buyrat"), "+Numeric") Then
                    e.Cancel = True
                Else
                    ConvertExRate(row.Cells("yce_frmcur").Value, row.Cells("yce_tocur").Value, row.Cells("yce_effdat").Value, CType(strNewVal, Double), CType(row.Cells("yce_selrat").Value, Double))
                End If
            End If

            If e.ColumnIndex = 5 Then
                If Not chkGrdCellValue(row.Cells("yce_selrat"), "+Numeric") Then
                    e.Cancel = True
                Else
                    ConvertExRate(row.Cells("yce_frmcur").Value, row.Cells("yce_tocur").Value, row.Cells("yce_effdat").Value, CType(row.Cells("yce_buyrat").Value, Double), CType(strNewVal, Double))
                End If
            End If
        End If

    End Sub

    Private Sub ConvertExRate(ByVal strFrmCur As String, ByVal strToCur As String, ByVal strEffDat As String, ByVal dblBuyRat As Double, ByVal dblSelRat As Double)
        Dim dr() As DataRow

        dr = rs_curex.Tables("RESULT").Select("yce_tocur = '" & strFrmCur & "' and yce_frmcur = '" & strToCur & "' and yce_effdat = #" & strEffDat & "#")
        If dr.Length > 0 Then
            dr(0).Item("yce_buyrat") = 1 / dblBuyRat
            dr(0).Item("yce_selrat") = 1 / dblSelRat
        End If
    End Sub

    Private Sub chkEff_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkEff.Click

        If Not cboEffDat.SelectedItem Is Nothing Then
            If chkEff.Checked Then
                For Each dr As DataRow In rs_curEffDat.Tables("RESULT").Rows
                    If dr.Item("yce_effdat") = CType(cboEffDat.SelectedItem, DateTime) Then
                        dr.Item("yce_iseff") = "Y"
                    Else
                        dr.Item("yce_iseff") = "N"
                    End If
                Next

                For Each dr As DataRow In rs_curex.Tables("RESULT").Rows
                    If dr.Item("yce_effdat") = CType(cboEffDat.SelectedItem, DateTime) Then
                        dr.Item("yce_iseff") = "Y"
                    Else
                        dr.Item("yce_iseff") = "N"
                    End If
                Next
            Else
                For Each dr As DataRow In rs_curEffDat.Tables("RESULT").Rows
                    If dr.Item("yce_effdat") = CType(cboEffDat.SelectedItem, DateTime) Then
                        dr.Item("yce_iseff") = "N"
                    End If
                Next

                For Each dr As DataRow In rs_curex.Tables("RESULT").Rows
                    If dr.Item("yce_effdat") = CType(cboEffDat.SelectedItem, DateTime) Then
                        dr.Item("yce_iseff") = "N"
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim drr() As DataRow
        Dim flgErr As Boolean = False
        Dim flgReAct As Boolean = False

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            save_ok = True
            bindSrc.EndEdit()
            For Each row As DataGridViewRow In DataGrid.Rows

                If row.Cells("yce_status").Value.ToString = "" Then

                    If Not chkGrdCellValue(row.Cells("yce_buyrat"), "+Numeric") Then
                        save_ok = False

                    ElseIf Not chkGrdCellValue(row.Cells("yce_selrat"), "+Numeric") Then
                        save_ok = False

                    End If
                End If

                If Not save_ok Then
                    DataGrid.BeginEdit(True)
                    Exit For
                End If
            Next

            drr = rs_curEffDat.Tables("RESULT").Select("yce_iseff = 'Y'")
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

                        If Not dr.Item("yce_status") = "Y" Then
                            gspStr = "sp_update_SYCUREX '" & gsCompany & "','" & _
                                        dr.Item("yce_frmcur").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yce_tocur").ToString.Replace("'", "''").Trim & "'," & _
                                        dr.Item("yce_buyrat").ToString.Replace("'", "''").Trim & "," & _
                                        dr.Item("yce_selrat").ToString.Replace("'", "''").Trim & ",'" & _
                                        dr.Item("yce_effdat").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yce_iseff").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yce_display").ToString.Replace("'", "''").Trim & "','" & _
                                        gsUsrID & "'"
                        End If
                    ElseIf dr.RowState = DataRowState.Added And Not dr.Item("yce_status") = "Y" Then

                        If dr.Item("yce_credat").ToString.Trim = "" Then
                            gspStr = "sp_insert_SYCUREX '" & gsCompany & "','" & _
                                        dr.Item("yce_frmcur").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yce_tocur").ToString.Replace("'", "''").Trim & "'," & _
                                        dr.Item("yce_buyrat").ToString.Replace("'", "''").Trim & "," & _
                                        dr.Item("yce_selrat").ToString.Replace("'", "''").Trim & ",'" & _
                                        dr.Item("yce_effdat").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yce_iseff").ToString.Replace("'", "''").Trim & "','" & _
                                        dr.Item("yce_display").ToString.Replace("'", "''").Trim & "','" & _
                                        gsUsrID & "'"
                        End If
                    End If

                    If gspStr <> "" Then
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading CLM00005 sp_update_SYCUREX : " & rtnStr)
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

    Private Sub CLM00005_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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