Public Class SYM00002
    Inherits System.Windows.Forms.Form

    Dim rs_sydocctl As New DataSet
    Dim bindSrc As New BindingSource
    Dim save_ok As Boolean
    Dim CanModify As Boolean = True
    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean

    Private Sub SYM00002_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Call AccessRight(Me.Name)
            Enq_right_local = Enq_right
            Del_right_local = Del_right

            Call FillCompCombo(gsUsrID, cboCoCde)
            Call GetDefaultCompany(cboCoCde, txtCoNam)

            gspStr = "sp_select_SYDOCCTL '" & Me.cboCoCde.SelectedItem & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_sydocctl, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00002 sp_select_SYDOCCTL : " & rtnStr)
            Else
                If Not rs_sydocctl.Tables("RESULT").Rows.Count = 0 Then
                    rs_sydocctl.Tables("RESULT").Columns("ydc_docdsc").ReadOnly = False
                End If
                Call displayGrid()
                Call setStatus("Init")
            End If
            Call Formstartup(Me.Name)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub displayGrid()
        Dim i As Integer
        Dim dv As DataView = rs_sydocctl.Tables("RESULT").DefaultView
        bindSrc.DataSource = dv

        With DataGrid
            .DataSource = Nothing
            .DataSource = bindSrc
            For i = 0 To .Columns.Count - 1
                Select Case i
                    Case 1
                        .Columns(i).Width = 120
                        .Columns(i).HeaderText = "Document Type"
                    Case 2
                        .Columns(i).Width = 250
                        .Columns(i).HeaderText = "Document Description"
                    Case 3
                        .Columns(i).Width = 80
                        .Columns(i).HeaderText = "Prefix"
                    Case 4
                        .Columns(i).Width = 80
                        .Columns(i).HeaderText = "Suffix"
                    Case 5
                        .Columns(i).Width = 130
                        .Columns(i).HeaderText = "Running Number"
                    Case Else
                        .Columns(i).Visible = False
                End Select
                .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i
        End With

        If Not dv.Count = 0 Then
            dv.Sort = "ydc_upddat desc"
            Dim drv As DataRowView = dv(0)
            Me.StatusBar.Items("lblRight").Text = Format(drv.Item("ydc_credat"), "MM/dd/yyyy") & " " & Format(drv.Item("ydc_upddat"), "MM/dd/yyyy") & " " & drv.Item("ydc_updusr")

            dv.Sort = Nothing
        End If
    End Sub

    Private Sub setStatus(ByVal mode As String)

        If mode = "Init" Then
            cmdAdd.Enabled = False
            CmdDelete.Enabled = False
            CmdCopy.Enabled = False
            CmdSave.Enabled = False
            CmdFind.Enabled = False
            cmdclear.Enabled = False
            cmdsearch.Enabled = False
            cmdInsRow.Enabled = False
            cmdDelRow.Enabled = False
            cmdfirst.Enabled = False
            cmdPrevious.Enabled = False
            cmdNext.Enabled = False
            cmdlast.Enabled = False
            Call SetStatusBar(mode)
        End If

        If mode = "Save" Then
            CmdAdd.Enabled = False
            CmdDelete.Enabled = False
            CmdCopy.Enabled = False
            CmdSave.Enabled = False
            CmdFind.Enabled = False
            cmdclear.Enabled = False
            cmdsearch.Enabled = False
            cmdInsRow.Enabled = False
            cmdDelRow.Enabled = False
            cmdfirst.Enabled = False
            cmdPrevious.Enabled = False
            cmdNext.Enabled = False
            cmdlast.Enabled = False
            Call SetStatusBar(mode)
        End If

        If Not CanModify Then
            Call SetStatusBar("ReadOnly")
        End If
    End Sub

    Private Sub SetStatusBar(ByVal mode As String)

        If mode = "ReadOnly" Or mode = "Init" Or mode = "Updating" Or mode = "save" Then
            Me.StatusBar.Items("lblLeft").Text = mode
        End If
    End Sub

    Private Sub DataGrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGrid.CellClick
        Dim row As DataGridViewRow = DataGrid.CurrentRow

        If Not e.RowIndex = -1 Then

            If e.ColumnIndex = 2 Then
                row.Cells(e.ColumnIndex).ReadOnly = False
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
                If Not chkGrdCellValue(row.Cells("ydc_docdsc"), "String", 100) Then
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            txtCoNam.Text = ChangeCompany(cboCoCde.SelectedItem, Me.Name)
            Enq_right_local = Enq_right
            Del_right_local = Del_right

            gspStr = "sp_select_SYDOCCTL '" & Me.cboCoCde.SelectedItem & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_sydocctl, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SYM00002 sp_select_SYDOCCTL : " & rtnStr)
            Else
                If rs_sydocctl.Tables("RESULT").Rows.Count = 0 Then
                    Call displayGrid()
                    Call setStatus("Updating")
                Else
                    rs_sydocctl.Tables("RESULT").Columns("ydc_docdsc").ReadOnly = False
                    Call displayGrid()
                    Call setStatus("Init")
                End If
            End If
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim flgErr As Boolean = False

        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            save_ok = True
            bindSrc.EndEdit()
            For Each row As DataGridViewRow In DataGrid.Rows
                If Not chkGrdCellValue(row.Cells("ydc_docdsc"), "String", 100) Then
                    save_ok = False
                End If
            Next

            If Not save_ok Then
                DataGrid.BeginEdit(True)
                Exit Sub
            Else
                For Each dr As DataRow In rs_sydocctl.Tables("RESULT").Rows
                    If dr.RowState = DataRowState.Modified Then

                        gspStr = "sp_update_SYDOCCTL '" & _
                                    Me.cboCoCde.Text & "','" & _
                                    dr.Item("ydc_doctyp").ToString.Replace("'", "''").Trim & "','" & _
                                    dr.Item("ydc_docdsc").ToString.Replace("'", "''").Trim & "','" & _
                                    dr.Item("ydc_prefix").ToString.Replace("'", "''").Trim & "','" & _
                                    dr.Item("ydc_suffix").ToString.Replace("'", "''").Trim & "','" & _
                                    dr.Item("ydc_seqno").ToString.Replace("'", "''").Trim & "','" & _
                                    gsUsrID & "'"

                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading SYM00002 sp_update_SYDOCCTL : " & rtnStr)
                            flgErr = True
                            Exit For
                        End If
                    End If
                Next

                If Not flgErr Then
                    rs_sydocctl.AcceptChanges()
                    Call setStatus("Save")
                Else
                    save_ok = False
                    rs_sydocctl.RejectChanges()
                    MsgBox("Record Not Updated!")
                End If
            End If
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try

    End Sub

    Private Sub SYM00002_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim YNC As Integer
        Dim flgMod As Boolean = False

        bindSrc.EndEdit()
        For Each dr As DataRow In rs_sydocctl.Tables("RESULT").Rows
            If dr.RowState = DataRowState.Modified Then
                flgMod = True
            End If
        Next

        If flgMod Then
            YNC = MessageBox.Show("Record has been modified  Do you want to save before exit?", "Question", MessageBoxButtons.YesNoCancel)

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