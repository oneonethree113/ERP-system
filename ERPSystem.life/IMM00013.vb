Public Class IMM00013

    Private recordStatus As Boolean = False
    Private saveOK As Boolean

    Dim rs_IMITMDAT As DataSet
    Dim dv_listing As DataView
    Dim selected_no As Integer
    Dim enq_right_local As Boolean
    Dim del_right_local As Boolean

    Private Sub IMM00013_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)

        Call AccessRight(Me.Name)
        enq_right_local = Enq_right
        del_right_local = Del_right

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        If gsCompanyGroup = "MSG" Then
            If gsCompany <> "MS" Then
                gsCompany = "MS"
                Call Update_gs_Value(gsCompany)
            End If
        Else
            '--- Update Company Code before execute ---
            If gsCompany = "ALL" Or gsCompany = "UC-G" Then
                '    gsCompany = SYM00001.cboCocde.Text
                gsCompany = gsDefaultCompany
                Call Update_gs_Value(gsCompany)
            End If
            '-----------------------------------------
        End If

        setStatus("Init")
        Me.Cursor = Windows.Forms.Cursors.Default
        txtVenItm.SelectionStart = 0

    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If txtCusVenFrom.Text <> "" And txtCusVenTo.TextLength = 0 Then
            txtCusVenTo.Text = txtCusVenFrom.Text
        End If
        If txtDesVenFrom.Text <> "" And txtDesVenTo.TextLength = 0 Then
            txtDesVenTo.Text = txtDesVenFrom.Text
        End If
        If txtPrdVenFrom.Text <> "" And txtPrdVenTo.TextLength = 0 Then
            txtPrdVenTo.Text = txtPrdVenFrom.Text
        End If
        If txtDateFrom.Text <> "" And txtDateTo.TextLength = 0 Then
            txtDateTo.Text = txtDateFrom.Text
        End If
        If txtLineFrom.Text <> "" And txtLineTo.TextLength = 0 Then
            txtLineTo.Text = txtLineFrom.Text
        End If

        selected_no = -1

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        'gspStr = "sp_update_IMITMDAT_refresh '','" & gsUsrID & "'"
        'rtnLong = execute_SQLStatement(gspStr, rs_IMITMDAT, rtnStr)

        gspStr = "sp_select_IMITMDAT_invld 'UCPP','" & txtDateFrom.Text & "','" & txtDateTo.Text & _
                 "','" & txtDesVenFrom.Text & "','" & txtDesVenTo.Text & "','" & txtLineFrom.Text & _
                 "','" & txtLineTo.Text & "','" & txtVenItm.Text & "','" & txtPrdVenFrom.Text & _
                 "','" & txtPrdVenTo.Text & "','" & txtCusVenFrom.Text & "','" & txtCusVenTo.Text & _
                 "','" & gsUsrID & "'"

        rtnLong = execute_SQLStatement(gspStr, rs_IMITMDAT, rtnStr)

        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMM00013 sp_select_IMITMDAT_invld : " & rtnStr)
            Exit Sub
        End If
        If rs_IMITMDAT.Tables("RESULT").Rows.Count = 0 Then
            setStatus("Init")
            MsgBox("No Records Found", MsgBoxStyle.Information, "Information")
        Else
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            setStatus("Updating")
            txtApplyFrom.Text = "1"
            txtApplyTo.Text = rs_IMITMDAT.Tables("RESULT").Rows.Count
            fillCount()
            DisplaySummary()
            'Enable_IAR00001()
            'tabFrame.SelectTab(0)
            Dim n As Integer = 0
            n = rs_IMITMDAT.Tables("RESULT").Rows.Count / 10
            If (rs_IMITMDAT.Tables("RESULT").Rows.Count Mod 10) > 0 Then
                n += 1
            End If
            txtApplyFrom.MaxLength = n
            txtApplyTo.MaxLength = n
            Me.Cursor = Windows.Forms.Cursors.Default
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim IsUpdated As Boolean = False
        Dim newFormat As Boolean
        Dim rs_exec As New DataSet

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        If recordStatus = True Then
            For i As Integer = 0 To rs_IMITMDAT.Tables("RESULT").Rows.Count - 1
                If Not (rs_IMITMDAT.Tables("RESULT").Rows(i)("iid_stage") = rs_IMITMDAT.Tables("RESULT").Rows(i)("old_stage")) Then
                    If Not checkTimeStamp(i) Then
                        Me.Cursor = Windows.Forms.Cursors.Default
                        MsgBox("The record has been modified by other users. Please refresh and try again.", MsgBoxStyle.Exclamation, "Overwrite Warning")
                        saveOK = False
                        Exit Sub
                    Else
                        newFormat = isNewItemFormat(rs_IMITMDAT.Tables("RESULT").Rows(i)("iid_venitm"))

                        gspStr = "sp_insert_IMITMDAT_invld 'UCPP','" & rs_IMITMDAT.Tables("RESULT").Rows(i)("iid_venno") & _
                                 "','" & rs_IMITMDAT.Tables("RESULT").Rows(i)("iid_venitm") & _
                                 "','" & rs_IMITMDAT.Tables("RESULT").Rows(i)("iid_itmseq") & _
                                 "','" & rs_IMITMDAT.Tables("RESULT").Rows(i)("iid_recseq") & _
                                 "','" & rs_IMITMDAT.Tables("RESULT").Rows(i)("iid_stage") & _
                                 "','" & gsUsrID & "','" & newFormat & "'"

                        rtnLong = execute_SQLStatement(gspStr, rs_exec, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading IMM00013 sp_insert_IMITMDAT_invld : " & rtnStr)
                            IsUpdated = False
                            Exit Sub
                        Else
                            IsUpdated = True
                        End If

                    End If
                End If
            Next

            If IsUpdated = True Then
                saveOK = True
            Else
                saveOK = False
            End If

            gspStr = "sp_IMITMDAT_itmtyp"
            rtnLong = execute_SQLStatement(gspStr, rs_exec, rtnStr)
            Application.DoEvents()

            gspStr = "sp_update_IMITMDAT_UM"
            rtnLong = execute_SQLStatement(gspStr, rs_exec, rtnStr)
            Application.DoEvents()

            gspStr = "sp_update_BasicPrice 'UCPP'"
            rtnLong = execute_SQLStatement(gspStr, rs_exec, rtnStr)
            Application.DoEvents()
        End If

        Call setStatus("Reactivate")

        Me.Cursor = Windows.Forms.Cursors.Default

    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If recordStatus = True Then
            Dim ans As Integer = MsgBox("Record has been modified. Do you want to save before clearing the screen?", MsgBoxStyle.YesNoCancel, "Clear Screen")
            If ans = 6 Then         'Yes
                If mmdSave.Enabled = True Then
                    mmdSave.PerformClick()
                    If saveOK = True Then
                        setStatus("Clear")
                    Else
                        Exit Sub
                    End If
                Else
                    If enq_right_local = False Then
                        MsgBox("You have no right to save this document", MsgBoxStyle.Information, "Information")
                        Call setStatus("Clear")
                    End If
                End If
            ElseIf ans = 7 Then     'No
                setStatus("Clear")
            ElseIf ans = 2 Then     'Cancel
                Exit Sub
            End If
        Else
            setStatus("Clear")
        End If
    End Sub

    Private Sub cmdApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApply.Click
        If Val(txtApplyFrom.Text) = "0" Then
            MsgBox("The apply range cannot be 0", MsgBoxStyle.Exclamation, "Invalid Parameters")
            txtApplyFrom.SelectAll()
            Exit Sub
        End If

        If Val(txtApplyTo.Text) > rs_IMITMDAT.Tables("RESULT").Rows.Count Then
            MsgBox("The apply range cannot larger than the total number of records.", MsgBoxStyle.Exclamation, "Invalid Parameters")
            txtApplyTo.SelectAll()
            Exit Sub
        End If

        If Val(txtApplyFrom.Text) > Val(txtApplyTo.Text) Then
            MsgBox("The apply range is invalid.", MsgBoxStyle.Exclamation, "Invalid Parameters")
            txtApplyTo.SelectAll()
            Exit Sub
        End If

        If (optInvalid.Checked = False) And (optWait.Checked = False) Then
            MsgBox("Please select one of the following options: Invalid or Wait for Approval", MsgBoxStyle.Exclamation, "Missing Decision")
            optInvalid.Focus()
            Exit Sub
        End If

        ' Apply changes to indicated items from Apply Range textboxes
        rs_IMITMDAT.Tables("RESULT").Columns(1).ReadOnly = False
        For i As Integer = (txtApplyFrom.Text - 1) To (txtApplyTo.Text - 1)
            If (optInvalid.Checked = True) Then
                rs_IMITMDAT.Tables("RESULT").Rows(i)(1) = "I"
            ElseIf (optWait.Checked = True) Then
                rs_IMITMDAT.Tables("RESULT").Rows(i)(1) = "W"
            End If
        Next
        rs_IMITMDAT.Tables("RESULT").Columns(1).ReadOnly = True

        recordStatus = True
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim answer As Integer

        If recordStatus = True Then
            answer = MsgBox("Record has been modified. Do you want to save before exit?", MsgBoxStyle.YesNoCancel, "Close")
            If answer = 2 Then      'Cancel
                Exit Sub
            ElseIf answer = 6 Then  'Yes
                If mmdSave.Enabled Then
                    mmdSave.PerformClick()
                    If saveOK = True Then
                        setStatus("Clear")
                    Else
                        Exit Sub
                    End If
                Else
                    MsgBox("You have no right to save this document", MsgBoxStyle.Information, "Information")
                End If
            ElseIf answer = 7 Then  'No
                Close()
            End If
        Else
            Close()
        End If
    End Sub

    Private Sub fillCount()
        rs_IMITMDAT.Tables("RESULT").Columns("no").ReadOnly = False
        For i As Integer = 0 To rs_IMITMDAT.Tables("RESULT").Rows.Count - 1
            rs_IMITMDAT.Tables("RESULT").Rows(i)("no") = i + 1
        Next
        rs_IMITMDAT.Tables("RESULT").Columns("no").ReadOnly = True

    End Sub

    Private Sub DisplaySummary()

        dv_listing = rs_IMITMDAT.Tables("RESULT").DefaultView

        With grdSummary
            .DataSource = Nothing
            .DataSource = dv_listing
            For i As Integer = 0 To .Columns.Count - 1
                Select Case i
                    Case 0
                        .Columns(i).HeaderText = "No."
                        .Columns(i).Width = 30
                        .Columns(i).ReadOnly = True
                    Case 1
                        .Columns(i).HeaderText = "Inv/Wait"
                        .Columns(i).Width = 55
                        .Columns(i).ReadOnly = True
                    Case 3
                        .Columns(i).HeaderText = "D. Vendor"
                        .Columns(i).Width = 65
                        .Columns(i).ReadOnly = True
                    Case 4
                        .Columns(i).HeaderText = "Price Term"
                        .Columns(i).Width = 55
                        .Columns(i).ReadOnly = True
                    Case 7
                        .Columns(i).HeaderText = "Vendor Item"
                        .Columns(i).Width = 100
                        .Columns(i).ReadOnly = True
                    Case 8
                        .Columns(i).HeaderText = "Item No."
                        .Columns(i).Width = 100
                        .Columns(i).ReadOnly = True
                    Case 9
                        .Columns(i).HeaderText = "Type"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case 10
                        .Columns(i).HeaderText = "Mode"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case 11
                        .Columns(i).HeaderText = "English Desc."
                        .Columns(i).Width = 110
                        .Columns(i).ReadOnly = True
                    Case 12
                        .Columns(i).HeaderText = "Packing Instruction"
                        .Columns(i).Width = 110
                        .Columns(i).ReadOnly = True
                    Case 13
                        .Columns(i).HeaderText = "System Message"
                        .Columns(i).Width = 400
                        .Columns(i).ReadOnly = True
                    Case 14
                        .Columns(i).HeaderText = "UM"
                        .Columns(i).Width = 45
                        .Columns(i).ReadOnly = True
                    Case 15
                        .Columns(i).HeaderText = "Inner Qty"
                        .Columns(i).Width = 60
                        .Columns(i).ReadOnly = True
                    Case 16
                        .Columns(i).HeaderText = "Master Qty"
                        .Columns(i).Width = 65
                        .Columns(i).ReadOnly = True
                    Case 17
                        .Columns(i).HeaderText = "CFT"
                        .Columns(i).Width = 60
                        .Columns(i).ReadOnly = True
                    Case 18
                        .Columns(i).HeaderText = "C. Factor"
                        .Columns(i).Width = 50
                        .Columns(i).ReadOnly = True
                    Case 19
                        .Columns(i).HeaderText = "CCY"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case 20
                        .Columns(i).HeaderText = "FTY Price"
                        .Columns(i).Width = 60
                        .Columns(i).ReadOnly = True
                    Case 21
                        .Columns(i).HeaderText = "Prod. Line"
                        .Columns(i).Width = 60
                        .Columns(i).ReadOnly = True
                    Case 22
                        .Columns(i).HeaderText = "FTY Cost"
                        .Columns(i).Width = 60
                        .Columns(i).ReadOnly = True
                    Case 23
                        .Columns(i).HeaderText = "Neg. Prc."
                        .Columns(i).Width = 60
                        .Columns(i).ReadOnly = True
                    Case 24
                        .Columns(i).HeaderText = "Chinese Desc."
                        .Columns(i).Width = 110
                        .Columns(i).ReadOnly = True
                    Case 25
                        .Columns(i).HeaderText = "Date"
                        .Columns(i).Width = 60
                        .Columns(i).ReadOnly = True
                    Case 26
                        .Columns(i).HeaderText = "Status"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case 27
                        .Columns(i).HeaderText = "Category 4"
                        .Columns(i).Width = 75
                        .Columns(i).ReadOnly = True
                    Case 36
                        .Columns(i).HeaderText = "Period"
                        .Columns(i).Width = 60
                        .Columns(i).ReadOnly = True
                    Case 37
                        .Columns(i).HeaderText = "Cost Expiry Date"
                        .Columns(i).Width = 75
                        .Columns(i).ReadOnly = True
                    Case Else
                        .Columns(i).Visible = False
                End Select
                '.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i
        End With

        'dv_listing.Sort = "ied_recseq"

        Dim drv As DataRowView = dv_listing(0)
        selected_no = 0

        StatusBar.Items("lblRight").Text = "Created: " & rs_IMITMDAT.Tables("RESULT").Rows(selected_no)("iid_credat") & " " & _
                                           "Updated: " & Format(rs_IMITMDAT.Tables("RESULT").Rows(selected_no)("iid_upddat"), "MM/dd/yyyy") & " " & _
                                           "by " & rs_IMITMDAT.Tables("RESULT").Rows(selected_no)("iid_updusr")

        grdSummary.CurrentCell = grdSummary.Rows(selected_no).Cells(0)
        grdSummary.ClearSelection()
    End Sub

    Private Sub grdSummary_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdSummary.CellMouseClick
        If grdSummary.SelectedRows.Count = 1 Or grdSummary.SelectedCells.Count = 1 Then
            ' Change Approve/Reject Status For Selected Item
            If grdSummary.SelectedCells.Item(0).ColumnIndex = 1 Then
                rs_IMITMDAT.Tables("RESULT").Columns(1).ReadOnly = False
                If (rs_IMITMDAT.Tables("RESULT").Rows(grdSummary.SelectedCells.Item(0).RowIndex)(1) = "I") Then
                    rs_IMITMDAT.Tables("RESULT").Rows(grdSummary.SelectedCells.Item(0).RowIndex)(1) = "W"
                ElseIf (rs_IMITMDAT.Tables("RESULT").Rows(grdSummary.SelectedCells.Item(0).RowIndex)(1) = "W") Then
                    rs_IMITMDAT.Tables("RESULT").Rows(grdSummary.SelectedCells.Item(0).RowIndex)(1) = "I"
                End If
                rs_IMITMDAT.Tables("RESULT").Columns(1).ReadOnly = True
                recordStatus = True
            End If

            selected_no = grdSummary.SelectedCells.Item(0).RowIndex
            'grdSummary.ClearSelection()
        End If
    End Sub

    Private Sub validateInput(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtApplyFrom.KeyPress, txtApplyTo.KeyPress
        If Not ((Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Function checkTimeStamp(ByVal index As Integer) As Boolean

        Dim rs_time As New DataSet
        Dim save_timestamp As Long

        gspStr = "sp_select_IMITMDAT_timstp '" & "" & _
                 "','" & rs_IMITMDAT.Tables("RESULT").Rows(index)("iid_venno") & _
                 "','" & rs_IMITMDAT.Tables("RESULT").Rows(index)("iid_venitm") & _
                 "','" & rs_IMITMDAT.Tables("RESULT").Rows(index)("iid_itmseq") & _
                 "','" & rs_IMITMDAT.Tables("RESULT").Rows(index)("iid_recseq") & "'"

        rtnLong = execute_SQLStatement(gspStr, rs_time, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMM00002 sp_select_IMITMDAT_timstp : " & rtnStr)
            Exit Function
        End If

        If rs_time.Tables("RESULT").Rows.Count > 0 Then
            save_timestamp = rs_time.Tables("RESULT").Rows(0)("iid_timstp")
        Else
            save_timestamp = 9999
        End If

        If rs_IMITMDAT.Tables("RESULT").Rows(index)("iid_timstp") <> save_timestamp Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Function isNewItemFormat(ByVal strItem As String) As Boolean
        strItem = UCase(strItem)
        If strItem.Length < 11 Then
            Return False
        End If
        If strItem.IndexOf("-") >= 0 Or strItem.IndexOf("/") >= 0 Then
            Return False
        End If

        If Not (strItem.Substring(2, 1) = "A" Or strItem.Substring(2, 1) = "B" Or strItem.Substring(2, 1) = "U" Or _
                strItem.Substring(2, 1) = "C" Or strItem.Substring(2, 1) = "D" Or strItem.Substring(2, 1) = "T" Or _
                strItem.Substring(2, 1) = "V" Or strItem.Substring(2, 1) = "X") Then
            Return False
        End If

        If strItem.Substring(6, 2) = "AS" And strItem.Substring(strItem.Length - 2, 2) <> "00" And _
            strItem.Substring(2, 1) <> "C" And strItem.Substring(2, 1) <> "D" Then
            Return False
        End If

        If strItem.Substring(6, 2) <> "AS" Then
            If strItem.Substring(2, 1) = "B" Or strItem.Substring(2, 1) = "U" Then
                If Not (strItem.Substring(3, 1) >= "0" And strItem.Substring(3, 1) <= "9" Or _
                        strItem.Substring(3, 1) >= "A" And strItem.Substring(3, 1) <= "Z") Then
                    Return False
                End If
                If Not (strItem.Substring(4, 1) >= "0" And strItem.Substring(4, 1) <= "9") Then
                    Return False
                End If
                If Not (strItem.Substring(5, 1) >= "0" And strItem.Substring(5, 1) <= "9" Or _
                        strItem.Substring(5, 1) >= "A" And strItem.Substring(5, 1) <= "Z") Then
                    Return False
                End If
                If strItem.Substring(3, 1) >= "A" And strItem.Substring(3, 1) <= "Z" And _
                   strItem.Substring(5, 1) >= "A" And strItem.Substring(5, 1) <= "Z" Then
                    Return False
                End If
            End If
        End If
        Return True
    End Function

    Private Sub setStatus(ByVal Mode As String)

        If Mode = "Init" Then
            mmdAdd.Enabled = False
            mmdSave.Enabled = False
            mmdDelete.Enabled = False
            mmdCopy.Enabled = False
            mmdFind.Enabled = True
            mmdClear.Enabled = True

            'disable button which without any function
            mmdSearch.Enabled = False
            mmdInsRow.Enabled = False
            mmdDelRow.Enabled = False


            mmdPrint.Enabled = False
            mmdAttach.Enabled = False
            mmdFunction.Enabled = False
            mmdLink.Enabled = False

            mmdExit.Enabled = True

            txtVenItm.Enabled = True
            txtVenItm.Text = ""
            txtCusVenFrom.Enabled = True
            txtCusVenFrom.Text = ""
            txtCusVenTo.Enabled = True
            txtCusVenTo.Text = ""
            txtDesVenFrom.Enabled = True
            txtDesVenFrom.Text = ""
            txtDesVenTo.Enabled = True
            txtDesVenTo.Text = ""
            txtPrdVenFrom.Enabled = True
            txtPrdVenFrom.Text = ""
            txtPrdVenTo.Enabled = True
            txtPrdVenTo.Text = ""
            txtDateFrom.Enabled = True
            txtDateFrom.Text = ""
            txtDateTo.Enabled = True
            txtDateTo.Text = ""
            txtLineFrom.Enabled = True
            txtLineFrom.Text = ""
            txtLineTo.Enabled = True
            txtLineTo.Text = ""

            optInvalid.Enabled = False
            optInvalid.Checked = False
            optWait.Enabled = False
            optWait.Checked = False
            txtApplyFrom.Enabled = False
            txtApplyFrom.Text = ""
            txtApplyTo.Enabled = False
            txtApplyTo.Text = ""
            cmdApply.Enabled = False

            'Summary Tab
            grdSummary.Enabled = False

            resetDefaultDisp()
            SetStatusBar(Mode)

            '***Reset the flag
            recordStatus = False
        ElseIf Mode = "Updating" Then
            mmdAdd.Enabled = False
            mmdSave.Enabled = enq_right_local 'True
            mmdDelete.Enabled = False
            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdClear.Enabled = True

            mmdInsRow.Enabled = False
            mmdDelRow.Enabled = False

            mmdExit.Enabled = True

            cmdApply.Enabled = True
            optInvalid.Enabled = True
            optWait.Enabled = True
            txtApplyFrom.Enabled = True
            txtApplyTo.Enabled = True

            txtDateFrom.Enabled = False
            txtDateTo.Enabled = False
            txtCusVenFrom.Enabled = False
            txtCusVenTo.Enabled = False
            txtDesVenFrom.Enabled = False
            txtDesVenTo.Enabled = False
            txtPrdVenFrom.Enabled = False
            txtPrdVenTo.Enabled = False
            txtLineFrom.Enabled = False
            txtLineTo.Enabled = False
            txtVenItm.Enabled = False
            grdSummary.Enabled = True

            '***Reset the flag
            recordStatus = False

            SetStatusBar(Mode)
            'Add your codes here
        ElseIf Mode = "Reactivate" Then
            MsgBox("Item Reactivation Complete")
            SetStatusBar(Mode)
            setStatus("Init")
            grdSummary.DataSource = Nothing
            grdSummary.Refresh()
        ElseIf Mode = "Delete" Then
            SetStatusBar(Mode)
            'Add your codes here
        ElseIf Mode = "Clear" Then
            resetDefaultDisp()
            setStatus("Init")
            SetStatusBar(Mode)
            grdSummary.DataSource = Nothing
            rs_IMITMDAT = Nothing
        End If
    End Sub

    Private Sub resetDefaultDisp()
        lblLeft.Text = ""
        lblRight.Text = ""
    End Sub

    Private Sub SetStatusBar(ByVal Mode As String)

        If Mode = "Init" Then
            lblLeft.Text = "Init"

        ElseIf Mode = "ADD" Then
            lblLeft.Text = "ADD"

        ElseIf Mode = "Updating" Then
            lblLeft.Text = "Updating"

        ElseIf Mode = "Reactivate" Then
            lblLeft.Text = "Item Reactivated"

        ElseIf Mode = "Delete" Then
            lblLeft.Text = "Record Deleted"

        ElseIf Mode = "ReadOnly" Then
            lblLeft.Text = "Read Only"

        ElseIf Mode = "Clear" Then
            lblLeft.Text = "Clear Screen"

        End If
    End Sub
End Class

