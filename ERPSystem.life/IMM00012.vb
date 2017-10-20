Public Class IMM00012

    Private recordStatus As Boolean = False
    Private saveOK As Boolean
    Private isSave As Boolean

    Dim rs_IMITMEXDAT As DataSet
    Dim rs_IMITMEXDAT_dtl As DataSet
    Dim dv_listing As DataView
    Dim selected_no As Integer

    Dim results As Boolean
    Dim enq_right_local As Boolean
    Dim del_right_local As Boolean

    Private Sub IMM00012_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)

        Call AccessRight(Me.Name)
        enq_right_local = Enq_right
        del_right_local = Del_right

        tabFrame.SelectedTab = tabSummary

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

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
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

        Dim itmsts As String = ""
        Dim Mode As String = ""
        Dim strChkAlias As String = ""
        selected_no = -1

        If (Not chkComplete.Checked And Not chkIncomplete.Checked) Or _
            (chkComplete.Checked And chkIncomplete.Checked) Then
            itmsts = ""
        ElseIf chkComplete.Checked = True And chkIncomplete.Checked = False Then
            itmsts = "CMP"
        ElseIf chkComplete.Checked = False And chkIncomplete.Checked = True Then
            itmsts = "INC"
        End If

        If (chkInsert.Checked = False And chkUpdate.Checked = False) Then
            Mode = ""
        ElseIf chkInsert.Checked = True And chkUpdate.Checked = False Then
            Mode = "NEW"
        ElseIf chkInsert.Checked = False And chkUpdate.Checked = True Then
            Mode = "UPD"
        ElseIf chkInsert.Checked = True And chkUpdate.Checked = True Then
            Mode = "ALL"
        End If

        strChkAlias = IIf(Me.chkAlias.Checked = True, "Y", "N")

        If chkComplete.Checked = False And chkIncomplete.Checked = False Then
            chkComplete.Checked = True
            chkIncomplete.Checked = True
        End If

        If chkInsert.Checked = False And chkUpdate.Checked = False And chkAlias.Checked = False Then
            chkInsert.Checked = True
            chkUpdate.Checked = True
            chkAlias.Checked = True
        End If

        If chkApprove.Checked = False And chkReject.Checked = False And chkWait.Checked = False Then
            chkApprove.Checked = True
            chkReject.Checked = True
            chkWait.Checked = True
        End If

        gspStr = "sp_select_IMITMEXDAT '','" & itmsts & "','" & Mode & "','" & txtDateFrom.Text & _
                 "','" & txtDateTo.Text & "','" & txtDesVenFrom.Text & "','" & txtDesVenTo.Text & _
                 "','" & txtLineFrom.Text & "','" & txtLineTo.Text & "','" & txtVenItm.Text & _
                 "','" & Int(chkApprove.Checked).ToString & "','" & Int(chkReject.Checked).ToString & _
                 "','" & Int(chkWait.Checked).ToString & "','" & txtPrdVenFrom.Text & _
                 "','" & txtPrdVenTo.Text & "','" & txtCusVenFrom.Text & "','" & txtCusVenTo.Text & _
                 "','" & strChkAlias & "','" & gsUsrID & "'"

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        rtnLong = execute_SQLStatement(gspStr, rs_IMITMEXDAT, rtnStr)

        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMM00012 sp_select_IMITMEXDAT : " & rtnStr)
            Exit Sub
        End If
        If rs_IMITMEXDAT.Tables("RESULT").Rows.Count = 0 Then
            setStatus("Init")
            MsgBox("No Records Found", MsgBoxStyle.Information, "Information")
        Else
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            ' Add Reason Column to Data Set
            Dim chgreason As DataColumn
            chgreason = New DataColumn("imu_chgreason", System.Type.GetType("System.String"))
            rs_IMITMEXDAT.Tables("RESULT").Columns.Add(chgreason)

            setStatus("Updating")
            txtApplyFrom.Text = "1"
            txtApplyTo.Text = rs_IMITMEXDAT.Tables("RESULT").Rows.Count
            fillCount()
            DisplaySummary()
            Enable_IAR00001()
            tabFrame.SelectTab(0)
            Dim n As Integer = 0
            n = rs_IMITMEXDAT.Tables("RESULT").Rows.Count / 10
            If (rs_IMITMEXDAT.Tables("RESULT").Rows.Count Mod 10) > 0 Then
                n += 1
            End If
            txtApplyFrom.MaxLength = n
            txtApplyTo.MaxLength = n
            Me.Cursor = Windows.Forms.Cursors.Default
        End If

    End Sub

    Private Sub fillCount()
        rs_IMITMEXDAT.Tables("RESULT").Columns("no").ReadOnly = False
        For i As Integer = 0 To rs_IMITMEXDAT.Tables("RESULT").Rows.Count - 1
            rs_IMITMEXDAT.Tables("RESULT").Rows(i)("no") = i + 1
        Next
        rs_IMITMEXDAT.Tables("RESULT").Columns("no").ReadOnly = True

    End Sub

    Private Sub DisplaySummary()

        dv_listing = rs_IMITMEXDAT.Tables("RESULT").DefaultView

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
                        .Columns(i).HeaderText = "Apv/Rej"
                        .Columns(i).Width = 55
                        .Columns(i).ReadOnly = True
                    Case 3
                        .Columns(i).HeaderText = "D. Vendor"
                        .Columns(i).Width = 65
                        .Columns(i).ReadOnly = True
                    Case 4
                        .Columns(i).HeaderText = "C. Vendor"
                        .Columns(i).Width = 65
                        .Columns(i).ReadOnly = True
                    Case 5
                        .Columns(i).HeaderText = "P. Vendor"
                        .Columns(i).Width = 65
                        .Columns(i).ReadOnly = True
                    Case 6
                        .Columns(i).HeaderText = "P. Cust."
                        .Columns(i).Width = 65
                        .Columns(i).ReadOnly = True
                    Case 7
                        .Columns(i).HeaderText = "S. Cust"
                        .Columns(i).Width = 65
                        .Columns(i).ReadOnly = True
                    Case 8
                        .Columns(i).HeaderText = "Cust. Type"
                        .Columns(i).Width = 80
                        .Columns(i).ReadOnly = True
                    Case 9
                        .Columns(i).HeaderText = "Vendor Item"
                        .Columns(i).Width = 100
                        .Columns(i).ReadOnly = True
                    Case 10
                        .Columns(i).HeaderText = "Item No."
                        .Columns(i).Width = 100
                        .Columns(i).ReadOnly = True
                    Case 11
                        .Columns(i).HeaderText = "Design Item No."
                        .Columns(i).Width = 100
                        .Columns(i).ReadOnly = True
                    Case 12
                        .Columns(i).HeaderText = "Type"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case 13
                        .Columns(i).HeaderText = "Mode"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case 14
                        .Columns(i).HeaderText = "English Desc."
                        .Columns(i).Width = 110
                        .Columns(i).ReadOnly = True
                    Case 15
                        .Columns(i).HeaderText = "UM"
                        .Columns(i).Width = 35
                        .Columns(i).ReadOnly = True
                    Case 16
                        .Columns(i).HeaderText = "Inner Qty"
                        .Columns(i).Width = 60
                        .Columns(i).ReadOnly = True
                    Case 17
                        .Columns(i).HeaderText = "Master Qty"
                        .Columns(i).Width = 65
                        .Columns(i).ReadOnly = True
                    Case 18
                        .Columns(i).HeaderText = "CFT"
                        .Columns(i).Width = 60
                        .Columns(i).ReadOnly = True
                    Case 19
                        .Columns(i).HeaderText = "Conv. Factor to PCS"
                        .Columns(i).Width = 50
                        .Columns(i).ReadOnly = True
                    Case 20
                        .Columns(i).HeaderText = "CCY"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case 21
                        .Columns(i).HeaderText = "FTY Price"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case 22
                        .Columns(i).HeaderText = "Prod. Line"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case 23
                        .Columns(i).HeaderText = "FTY Cost"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case 24
                        .Columns(i).HeaderText = "FTY Price Term"
                        .Columns(i).Width = 45
                        .Columns(i).ReadOnly = True
                    Case 25
                        .Columns(i).HeaderText = "HK Price Term"
                        .Columns(i).Width = 45
                        .Columns(i).ReadOnly = True
                    Case 26
                        .Columns(i).HeaderText = "Transport Term"
                        .Columns(i).Width = 45
                        .Columns(i).ReadOnly = True
                    Case 27
                        .Columns(i).HeaderText = "Chinese Desc."
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case 28
                        .Columns(i).HeaderText = "Date"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case 29
                        .Columns(i).HeaderText = "Status"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case 30
                        .Columns(i).HeaderText = "Category 4"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case 31
                        .Columns(i).HeaderText = "Pack Meas."
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case 32
                        .Columns(i).HeaderText = "Inner L"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case 33
                        .Columns(i).HeaderText = "Inner W"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case 34
                        .Columns(i).HeaderText = "Inner H"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case 35
                        .Columns(i).HeaderText = "Master L"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case 36
                        .Columns(i).HeaderText = "Master W"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case 37
                        .Columns(i).HeaderText = "Master H"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case 38
                        .Columns(i).HeaderText = "GW"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case 39
                        .Columns(i).HeaderText = "NW"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case 40
                        .Columns(i).HeaderText = "Packing Instruction"
                        .Columns(i).Width = 110
                        .Columns(i).ReadOnly = True
                    Case 41
                        .Columns(i).HeaderText = "Internal Remark"
                        .Columns(i).Width = 110
                        .Columns(i).ReadOnly = True
                    Case 42
                        .Columns(i).HeaderText = "Cost Remark"
                        .Columns(i).Width = 110
                        .Columns(i).ReadOnly = True
                    Case 52
                        .Columns(i).HeaderText = "Price Change Reason"
                        .Columns(i).Width = 400
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

        StatusBar.Items("lblRight").Text = "Created: " & rs_IMITMEXDAT.Tables("RESULT").Rows(selected_no)("ied_credat") & " " & _
                                           "Updated: " & Format(rs_IMITMEXDAT.Tables("RESULT").Rows(selected_no)("ied_upddat"), "MM/dd/yyyy") & " " & _
                                           "by " & rs_IMITMEXDAT.Tables("RESULT").Rows(selected_no)("ied_updusr")
        refreshTab()
    End Sub

    Private Sub cmdApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApply.Click
        If grdSummary.SelectedRows.Count > 0 Then
            rs_IMITMEXDAT.Tables("RESULT").Columns(1).ReadOnly = False
            For i As Integer = 0 To grdSummary.SelectedRows.Count - 1
                If (optApproval.Checked = True) Then
                    rs_IMITMEXDAT.Tables("RESULT").Rows(grdSummary.SelectedRows.Item(i).Index)(1) = "A"
                ElseIf (optRejection.Checked = True) Then
                    rs_IMITMEXDAT.Tables("RESULT").Rows(grdSummary.SelectedRows.Item(i).Index)(1) = "R"
                ElseIf (optWait.Checked = True) Then
                    rs_IMITMEXDAT.Tables("RESULT").Rows(grdSummary.SelectedRows.Item(i).Index)(1) = "W"
                End If
            Next
            rs_IMITMEXDAT.Tables("RESULT").Columns(1).ReadOnly = True

            'Update Checkbox DTL
            refreshTab()
            recordStatus = True
        Else
            If Val(txtApplyFrom.Text) = "0" Then
                MsgBox("The apply range cannot be 0", MsgBoxStyle.Exclamation, "Invalid Parameters")
                txtApplyFrom.SelectAll()
                Exit Sub
            End If

            If Val(txtApplyTo.Text) > rs_IMITMEXDAT.Tables("RESULT").Rows.Count Then
                MsgBox("The apply range cannot larger than the total number of records.", MsgBoxStyle.Exclamation, "Invalid Parameters")
                txtApplyTo.SelectAll()
                Exit Sub
            End If

            If Val(txtApplyFrom.Text) > Val(txtApplyTo.Text) Then
                MsgBox("The apply range is invalid.", MsgBoxStyle.Exclamation, "Invalid Parameters")
                txtApplyTo.SelectAll()
                Exit Sub
            End If

            If (optApproval.Checked = False) And (optRejection.Checked = False) And (optWait.Checked = False) Then
                MsgBox("Please select one of the following options: Approval, Rejection, or Wait for Approval", MsgBoxStyle.Exclamation, "Missing Decision")
                optApproval.Focus()
                Exit Sub
            End If

            ' Apply changes to indicated items from Apply Range textboxes
            rs_IMITMEXDAT.Tables("RESULT").Columns(1).ReadOnly = False
            For i As Integer = (txtApplyFrom.Text - 1) To (txtApplyTo.Text - 1)
                If (optApproval.Checked = True) Then
                    rs_IMITMEXDAT.Tables("RESULT").Rows(i)(1) = "A"
                ElseIf (optRejection.Checked = True) Then
                    rs_IMITMEXDAT.Tables("RESULT").Rows(i)(1) = "R"
                ElseIf (optWait.Checked = True) Then
                    rs_IMITMEXDAT.Tables("RESULT").Rows(i)(1) = "W"
                End If
            Next
            rs_IMITMEXDAT.Tables("RESULT").Columns(1).ReadOnly = True

            'Update Checkbox DTL
            refreshTab()
            recordStatus = True
        End If
    End Sub

    Private Sub Enable_IAR00001()
        cmdIAR00001.Enabled = getEnquiryRightByFormName("IAR00001")
    End Sub

    Private Sub setStatus(ByVal Mode As String)

        If Mode = "Init" Then
            cmdAdd.Enabled = False
            cmdSave.Enabled = False
            cmdDelete.Enabled = False
            cmdCopy.Enabled = False
            cmdFind.Enabled = True
            cmdClear.Enabled = True

            'disable button which without any function
            cmdSearch.Enabled = False
            cmdQuickInsert.Enabled = False
            cmdDelRow.Enabled = False
            cmdFirst.Enabled = False
            cmdLast.Enabled = False
            cmdNext.Enabled = False
            cmdPrevious.Enabled = False

            cmdExit.Enabled = True

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

            chkComplete.Enabled = True
            chkComplete.Checked = 0
            chkIncomplete.Enabled = True
            chkIncomplete.Checked = 0
            chkInsert.Enabled = True
            chkInsert.Checked = 0
            chkUpdate.Enabled = True
            chkUpdate.Checked = 0
            chkAlias.Enabled = True
            chkAlias.Checked = 0
            chkApprove.Enabled = True
            chkApprove.Checked = 0
            chkReject.Enabled = True
            chkReject.Checked = 0
            chkWait.Enabled = True
            chkWait.Checked = 0
            optApproval.Enabled = False
            optRejection.Enabled = False
            optWait.Enabled = False
            txtApplyFrom.Enabled = False
            txtApplyFrom.Text = ""
            txtApplyTo.Enabled = False
            txtApplyTo.Text = ""
            cmdApply.Enabled = False
            cmdAssort.Enabled = False

            cmdPrintList.Enabled = False
            cmdIAR00001.Enabled = False
            'Confirm Upload Checkbox
            chkConfirmUpload.Checked = True

            'Summary Tab
            grdSummary.Enabled = False
            'Detail Tab
            txtVenItm_dtl.Text = ""
            chkApprove_dtl.Checked = False
            chkApprove_dtl.Enabled = False
            chkReject_dtl.Checked = False
            chkReject_dtl.Enabled = False
            chkWait_dtl.Checked = False
            chkWait_dtl.Enabled = False

            cmdFirst_dtl.Enabled = False
            cmdPrev_dtl.Enabled = False
            cmdNext_dtl.Enabled = False
            cmdLast_dtl.Enabled = False

            txtUM_dtl.Text = ""
            txtInrQty_dtl.Text = ""
            txtMtrQty_dtl.Text = ""
            txtDesVenNo_dtl.Text = ""
            txtPrdVenNo_dtl.Text = ""
            txtCusVenNo_dtl.Text = ""
            txtUpdDate_dtl.Text = ""
            txtEngDesc_dtl.Text = ""
            grdDetail.Enabled = False

            grpStage.Enabled = False
            grpReason.Enabled = False
            chkRequote.Checked = False
            chkPeriod.Checked = False
            chkMoldCst.Checked = False
            chkMrkupFTY.Checked = False
            chkMrkupHK.Checked = False
            chkHmnErrFTY.Checked = False
            chkHmnErrHK.Checked = False
            txtReason.Text = ""

            ResetDefaultDisp()
            SetStatusBar(Mode)

            '***Reset the flag
            recordStatus = False
            results = False
        ElseIf Mode = "Updating" Then
            cmdAdd.Enabled = False
            cmdSave.Enabled = enq_right_local
            cmdDelete.Enabled = False
            cmdCopy.Enabled = False
            cmdFind.Enabled = False
            cmdClear.Enabled = True

            cmdQuickInsert.Enabled = False
            cmdDelRow.Enabled = False

            cmdExit.Enabled = True

            cmdFirst_dtl.Enabled = True
            cmdLast_dtl.Enabled = True
            cmdNext_dtl.Enabled = True
            cmdPrev_dtl.Enabled = True

            cmdApply.Enabled = True
            optApproval.Enabled = True
            optRejection.Enabled = True
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
            chkComplete.Enabled = False
            chkIncomplete.Enabled = False
            chkInsert.Enabled = False
            chkUpdate.Enabled = False
            chkAlias.Enabled = False
            chkApprove.Enabled = False
            chkReject.Enabled = False
            chkWait.Enabled = False
            'cboItmSts.Enabled = False
            'cboMode.Enabled = False
            chkApprove_dtl.Enabled = True
            chkReject_dtl.Enabled = True
            chkWait_dtl.Enabled = True
            grdSummary.Enabled = True
            grdDetail.Enabled = True

            grpStage.Enabled = True
            grpReason.Enabled = True

            '***Reset the flag
            recordStatus = False
            results = True

            SetStatusBar(Mode)
            'Add your codes here
        ElseIf Mode = "Save" Then
            MsgBox("Record Saved!")
            SetStatusBar(Mode)
            setStatus("Init")
            grdSummary.DataSource = Nothing
            grdSummary.Refresh()
            grdDetail.DataSource = Nothing
        ElseIf Mode = "Delete" Then
            SetStatusBar(Mode)
            'Add your codes here
        ElseIf Mode = "Clear" Then
            resetDefaultDisp()
            setStatus("Init")
            SetStatusBar(Mode)
            grdSummary.DataSource = Nothing
            grdDetail.DataSource = Nothing
            rs_IMITMEXDAT = Nothing
            rs_IMITMEXDAT_dtl = Nothing
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

        ElseIf Mode = "Save" Then
            lblLeft.Text = "Record Saved"

        ElseIf Mode = "Delete" Then
            lblLeft.Text = "Record Deleted"

        ElseIf Mode = "ReadOnly" Then
            lblLeft.Text = "Read Only"

        ElseIf Mode = "Clear" Then
            lblLeft.Text = "Clear Screen"

        End If
    End Sub

    Private Sub verifyDate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDateFrom.Leave, txtDateTo.Leave, TextBox11.Leave, TextBox10.Leave
        'Check Date Format
        If (sender.Text.Length > 0) Then
            On Error GoTo DATE_ERROR
            Dim dat As Date = CDate(sender.Text)
            If (dat.Year < 1950 Or dat.Year > 2049) Then
                GoTo DATE_ERROR
            End If
        End If
        Exit Sub
DATE_ERROR:
        Err.Clear()
        MsgBox("Invalid Date Input", MsgBoxStyle.Exclamation, "ERROR")
        sender.Focus()
        sender.SelectAll()
    End Sub

    Private Sub verifyDateFormat(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDateFrom.KeyPress, txtDateTo.KeyPress, TextBox11.KeyPress, TextBox10.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If sender.TextLength = 2 Then
                sender.Text = sender.Text + "/"
                sender.Select(3, 0)
            ElseIf sender.TextLength = 5 Then
                sender.Text = sender.Text + "/"
                sender.Select(6, 0)
            End If

            If Not ((Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8) Then
                e.KeyChar = Chr(0)
            End If

            'If (InStr("0123456789", Chr(Asc(e.KeyChar))) = 0) And (Asc(e.KeyChar) > 31 Or Asc(e.KeyChar) < 0) Then
            ' e.KeyChar = Chr(0)
            'ElseIf (sender.TextLength + 1 > 10) And (Asc(e.KeyChar) > 31 Or Asc(e.KeyChar) < 0) Then
            'e.KeyChar = Chr(0)
            'End If
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        If recordStatus = True Then
            Dim ans As Integer = MsgBox("Record has been modified. Do you want to save before clearing the screen?", MsgBoxStyle.YesNoCancel, "Clear Screen")
            If ans = 6 Then         'Yes
                If cmdSave.Enabled = True Then
                    cmdSave.PerformClick()
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

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Dim answer As Integer

        If recordStatus = True Then
            answer = MsgBox("Record has been modified. Do you want to save before exit?", MsgBoxStyle.YesNoCancel, "Close")
            If answer = 2 Then      'Cancel
                Exit Sub
            ElseIf answer = 6 Then  'Yes
                If cmdSave.Enabled Then
                    cmdSave.PerformClick()
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


    Private Sub cmdIAR00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIAR00001.Click
        IAR00001.ShowDialog()
    End Sub

    Private Sub cmdAssort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAssort.Click
        'IMM00002_2.ShowDialog()
    End Sub

    Private Sub cmdPrintList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintList.Click
        'NOT COMPLETED YET
        'IAR00001.txtItmNo.Text = IAR00001.txtItmNo.Text + IIf(IAR00001.txtItmNo.Text = "", rs_IMITMEXDAT("ied_venitm"), "*" + rs_IMITMEXDAT("ied_venitm"))
    End Sub

    Private Sub tabFrame_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabFrame.SelectedIndexChanged
        refreshTab()
    End Sub

    Private Sub refreshTab()
        If tabFrame.SelectedIndex = 1 Then
            If Not rs_IMITMEXDAT Is Nothing Then
                If rs_IMITMEXDAT.Tables("RESULT").Rows.Count <= 1 Then
                    cmdFirst_dtl.Enabled = False
                    cmdPrev_dtl.Enabled = False
                    cmdNext_dtl.Enabled = False
                    cmdLast_dtl.Enabled = False
                Else
                    'more than one record
                    cmdFirst_dtl.Enabled = False
                    cmdPrev_dtl.Enabled = False
                    cmdNext_dtl.Enabled = False
                    cmdLast_dtl.Enabled = False
                    If selected_no = 0 Then
                        cmdNext_dtl.Enabled = True
                        cmdLast_dtl.Enabled = True
                    ElseIf selected_no = (rs_IMITMEXDAT.Tables("RESULT").Rows.Count - 1) Then
                        cmdFirst_dtl.Enabled = True
                        cmdPrev_dtl.Enabled = True
                    Else
                        cmdFirst_dtl.Enabled = True
                        cmdPrev_dtl.Enabled = True
                        cmdNext_dtl.Enabled = True
                        cmdLast_dtl.Enabled = True
                    End If
                End If
            End If
            If isSave = False Then
                If results = True Then
                    If Not rs_IMITMEXDAT Is Nothing Then
                        txtVenItm_dtl.Text = rs_IMITMEXDAT.Tables("RESULT").Rows(selected_no)("ied_venitm")

                        If rs_IMITMEXDAT.Tables("RESULT").Rows(selected_no)("ied_stage") = "A" Then
                            chkApprove_dtl.Checked = True
                            chkReject_dtl.Checked = False
                            chkWait_dtl.Checked = False
                        ElseIf rs_IMITMEXDAT.Tables("RESULT").Rows(selected_no)("ied_stage") = "R" Then
                            chkApprove_dtl.Checked = False
                            chkReject_dtl.Checked = True
                            chkWait_dtl.Checked = False
                        ElseIf rs_IMITMEXDAT.Tables("RESULT").Rows(selected_no)("ied_stage") = "W" Then
                            chkApprove_dtl.Checked = False
                            chkReject_dtl.Checked = False
                            chkWait_dtl.Checked = True
                        End If

                        txtUM_dtl.Text = rs_IMITMEXDAT.Tables("RESULT").Rows(selected_no)("ied_untcde")
                        txtInrQty_dtl.Text = rs_IMITMEXDAT.Tables("RESULT").Rows(selected_no)("ied_inrqty")
                        txtMtrQty_dtl.Text = rs_IMITMEXDAT.Tables("RESULT").Rows(selected_no)("ied_mtrqty")
                        txtDesVenNo_dtl.Text = rs_IMITMEXDAT.Tables("RESULT").Rows(selected_no)("ied_venno")
                        txtPrdVenNo_dtl.Text = rs_IMITMEXDAT.Tables("RESULT").Rows(selected_no)("ied_prdven")
                        txtUpdDate_dtl.Text = rs_IMITMEXDAT.Tables("RESULT").Rows(selected_no)("ied_credat")
                        txtEngDesc_dtl.Text = rs_IMITMEXDAT.Tables("RESULT").Rows(selected_no)("ied_engdsc")
                        txtCusVenNo_dtl.Text = rs_IMITMEXDAT.Tables("RESULT").Rows(selected_no)("ied_cusven")

                        StatusBar.Items("lblRight").Text = "Created: " & rs_IMITMEXDAT.Tables("RESULT").Rows(selected_no)("ied_credat") & " " & _
                                                           "Updated: " & Format(rs_IMITMEXDAT.Tables("RESULT").Rows(selected_no)("ied_upddat"), "MM/dd/yyyy") & " " & _
                                                           "by " & rs_IMITMEXDAT.Tables("RESULT").Rows(selected_no)("ied_updusr")
                        find_Detail()
                    End If
                End If
            End If
        Else
            If results = True Then
                grdSummary.CurrentCell = grdSummary.Rows(selected_no).Cells(0)
                grdSummary.ClearSelection()
            End If
        End If
    End Sub

    Private Sub find_Detail()
        gspStr = "sp_select_IMITMEXDAT_dtl '','" & rs_IMITMEXDAT.Tables("RESULT").Rows(selected_no)("ied_ucpno") & _
                 "','" & rs_IMITMEXDAT.Tables("RESULT").Rows(selected_no)("ied_venno") & _
                 "','" & rs_IMITMEXDAT.Tables("RESULT").Rows(selected_no)("ied_prdven") & _
                 "','" & rs_IMITMEXDAT.Tables("RESULT").Rows(selected_no)("ied_untcde") & _
                 "','" & rs_IMITMEXDAT.Tables("RESULT").Rows(selected_no)("ied_cus1no") & _
                 "','" & rs_IMITMEXDAT.Tables("RESULT").Rows(selected_no)("ied_cus2no") & _
                 "','" & rs_IMITMEXDAT.Tables("RESULT").Rows(selected_no)("ied_mtrqty") & _
                 "','" & rs_IMITMEXDAT.Tables("RESULT").Rows(selected_no)("ied_inrqty") & _
                 "','" & rs_IMITMEXDAT.Tables("RESULT").Rows(selected_no)("ied_itmseq") & _
                 "','" & rs_IMITMEXDAT.Tables("RESULT").Rows(selected_no)("ied_chkdat") & _
                 "','" & rs_IMITMEXDAT.Tables("RESULT").Rows(selected_no)("ied_xlsfil") & "'"

        rtnLong = execute_SQLStatement(gspStr, rs_IMITMEXDAT_dtl, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMM00012 sp_select_IMITMEXDAT_dtl : " & rtnStr)
            Exit Sub
        End If
        If rs_IMITMEXDAT_dtl.Tables("RESULT").Rows.Count > 0 Then
            displayDetail()
        Else
            MsgBox("No Record History Found", MsgBoxStyle.Information, "Information")
        End If
    End Sub

    Private Sub displayDetail()
        Dim dv As DataView = rs_IMITMEXDAT_dtl.Tables("RESULT").DefaultView

        With grdDetail
            .DataSource = Nothing
            .DataSource = dv
            For i As Integer = 0 To .Columns.Count - 1
                Select Case i
                    Case 0
                        .Columns(i).HeaderText = "Field Name"
                        .Columns(i).Width = 150
                        .Columns(i).ReadOnly = True
                    Case 1
                        .Columns(i).HeaderText = "Mode"
                        .Columns(i).Width = 80
                        .Columns(i).ReadOnly = True
                    Case 2
                        .Columns(i).HeaderText = "Before"
                        .Columns(i).Width = 200
                        .Columns(i).ReadOnly = True
                    Case 3
                        .Columns(i).HeaderText = "After"
                        .Columns(i).Width = 200
                        .Columns(i).ReadOnly = True
                    Case Else
                        .Columns(i).Visible = False
                End Select
            Next
        End With
    End Sub

    Private Sub validateInput(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtApplyFrom.KeyPress, txtApplyTo.KeyPress
        If Not ((Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub cmdFirst_dtl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFirst_dtl.Click
        If Not rs_IMITMEXDAT Is Nothing Then
            If (selected_no > 0) Then
                selected_no = 0
            End If
        End If
        refreshTab()
    End Sub

    Private Sub cmdPrev_dtl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrev_dtl.Click
        If Not rs_IMITMEXDAT Is Nothing Then
            If (selected_no > 0) Then
                selected_no = selected_no - 1
            End If
        End If
        refreshTab()
    End Sub

    Private Sub cmdNext_dtl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext_dtl.Click
        If Not rs_IMITMEXDAT Is Nothing Then
            If (selected_no < Val(dv_listing.Count - 1)) Then
                selected_no = selected_no + 1
            End If
        End If
        refreshTab()
    End Sub

    Private Sub cmdLast_dtl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLast_dtl.Click
        If Not rs_IMITMEXDAT Is Nothing Then
            If (selected_no < Val(dv_listing.Count - 1)) Then
                selected_no = dv_listing.Count - 1
            End If
        End If
        refreshTab()
    End Sub

    Private Sub chkApprove_dtl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkApprove_dtl.Click
        If isSave = False Then
            If chkApprove_dtl.Checked = True Then
                chkReject_dtl.Checked = False
                chkWait_dtl.Checked = False
                rs_IMITMEXDAT.Tables("RESULT").Columns(1).ReadOnly = False
                rs_IMITMEXDAT.Tables("RESULT").Rows(selected_no)("ied_stage") = "A"
                rs_IMITMEXDAT.Tables("RESULT").Columns(1).ReadOnly = True
            End If
        End If
        If tabFrame.SelectedIndex = 1 Then
            recordStatus = True
        End If
    End Sub

    Private Sub chkReject_dtl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkReject_dtl.Click
        If isSave = False Then
            If chkReject_dtl.Checked = True Then
                chkApprove_dtl.Checked = False
                chkWait_dtl.Checked = False
                rs_IMITMEXDAT.Tables("RESULT").Columns(1).ReadOnly = False
                rs_IMITMEXDAT.Tables("RESULT").Rows(selected_no)("ied_stage") = "R"
                rs_IMITMEXDAT.Tables("RESULT").Columns(1).ReadOnly = True
            End If
        End If
        If tabFrame.SelectedIndex = 1 Then
            recordStatus = True
        End If
    End Sub

    Private Sub chkWait_dtl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkWait_dtl.Click
        If isSave = False Then
            If chkWait_dtl.Checked = True Then
                chkApprove_dtl.Checked = False
                chkReject_dtl.Checked = False
                rs_IMITMEXDAT.Tables("RESULT").Columns(1).ReadOnly = False
                rs_IMITMEXDAT.Tables("RESULT").Rows(selected_no)("ied_stage") = "W"
                rs_IMITMEXDAT.Tables("RESULT").Columns(1).ReadOnly = True
            End If
        End If
        If tabFrame.SelectedIndex = 1 Then
            recordStatus = True
        End If
    End Sub

    Private Sub grdSummary_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdSummary.CellMouseClick
        If grdSummary.SelectedRows.Count = 1 Or grdSummary.SelectedCells.Count = 1 Then
            ' Change Approve/Reject Status For Selected Item
            If grdSummary.SelectedCells.Item(0).ColumnIndex = 1 Then
                rs_IMITMEXDAT.Tables("RESULT").Columns("ied_stage").ReadOnly = False
                If (rs_IMITMEXDAT.Tables("RESULT").Rows(grdSummary.SelectedCells.Item(0).RowIndex)("ied_stage") = "W") Then
                    rs_IMITMEXDAT.Tables("RESULT").Rows(grdSummary.SelectedCells.Item(0).RowIndex)("ied_stage") = "A"
                    updateRecordStatusChkBox("A")
                ElseIf (rs_IMITMEXDAT.Tables("RESULT").Rows(grdSummary.SelectedCells.Item(0).RowIndex)("ied_stage") = "A") Then
                    rs_IMITMEXDAT.Tables("RESULT").Rows(grdSummary.SelectedCells.Item(0).RowIndex)("ied_stage") = "R"
                    updateRecordStatusChkBox("R")
                ElseIf (rs_IMITMEXDAT.Tables("RESULT").Rows(grdSummary.SelectedCells.Item(0).RowIndex)("ied_stage") = "R") Then
                    rs_IMITMEXDAT.Tables("RESULT").Rows(grdSummary.SelectedCells.Item(0).RowIndex)("ied_stage") = "W"
                    updateRecordStatusChkBox("W")
                End If
                rs_IMITMEXDAT.Tables("RESULT").Columns("ied_stage").ReadOnly = True
                recordStatus = True
            End If

            selected_no = grdSummary.SelectedCells.Item(0).RowIndex
            'grdSummary.ClearSelection()
        End If
    End Sub

    Private Sub updateRecordStatusChkBox(ByVal status As String)
        If (status = "A") Then
            chkApprove.Checked = True
            chkReject.Checked = False
            chkWait.Checked = False
        ElseIf (status = "R") Then
            chkApprove.Checked = False
            chkReject.Checked = True
            chkWait.Checked = False
        ElseIf (status = "W") Then
            chkApprove.Checked = False
            chkReject.Checked = False
            chkWait.Checked = True
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If verifyApproval() = False Then
            Exit Sub
        End If

        Dim IsUpdated As Boolean = False
        Dim rs_update, rs_temp As New DataSet

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        isSave = True

        If recordStatus = True Then
            For i As Integer = 0 To rs_IMITMEXDAT.Tables("RESULT").Rows.Count - 1
                If Not (rs_IMITMEXDAT.Tables("RESULT").Rows(i)("ied_stage") = rs_IMITMEXDAT.Tables("RESULT").Rows(i)("old_stage")) Then
                    If Not checkTimeStamp(i) Then
                        MsgBox("The record has been modified by other users. Please refresh and try again.", MsgBoxStyle.Exclamation, "Overwrite Warning")
                        Me.Cursor = Windows.Forms.Cursors.Default
                        saveOK = False
                        isSave = False
                        Exit Sub
                    Else
                        gspStr = "sp_update_IMITMEXDAT '','" & rs_IMITMEXDAT.Tables("RESULT").Rows(i)("ied_venno") & _
                                 "','" & rs_IMITMEXDAT.Tables("RESULT").Rows(i)("ied_ucpno") & _
                                 "','" & rs_IMITMEXDAT.Tables("RESULT").Rows(i)("ied_itmseq") & _
                                 "','" & rs_IMITMEXDAT.Tables("RESULT").Rows(i)("ied_recseq") & _
                                 "','" & rs_IMITMEXDAT.Tables("RESULT").Rows(i)("ied_stage") & _
                                 "','" & gsUsrID & "'"
                        rtnLong = execute_SQLStatement(gspStr, rs_update, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading IMM00012 sp_update_IMITMEXDAT : " & rtnStr)
                            IsUpdated = False
                            Exit Sub
                        End If

                        gspStr = "sp_IMPRCCHG_tmp '','" & rs_IMITMEXDAT.Tables("RESULT").Rows(i)("ied_ucpno") & _
                                 "','" & rs_IMITMEXDAT.Tables("RESULT").Rows(i)("ied_venno") & _
                                 "','" & rs_IMITMEXDAT.Tables("RESULT").Rows(i)("ied_prdven") & _
                                 "','" & rs_IMITMEXDAT.Tables("RESULT").Rows(i)("ied_untcde") & _
                                 "','" & rs_IMITMEXDAT.Tables("RESULT").Rows(i)("ied_inrqty") & _
                                 "','" & rs_IMITMEXDAT.Tables("RESULT").Rows(i)("ied_mtrqty") & _
                                 "','" & rs_IMITMEXDAT.Tables("RESULT").Rows(i)("ied_cus1no") & _
                                 "','" & rs_IMITMEXDAT.Tables("RESULT").Rows(i)("ied_cus2no") & _
                                 "','" & rs_IMITMEXDAT.Tables("RESULT").Rows(i)("ied_prctrm") & _
                                 "','" & rs_IMITMEXDAT.Tables("RESULT").Rows(i)("ied_hkprctrm") & _
                                 "','" & rs_IMITMEXDAT.Tables("RESULT").Rows(i)("ied_trantrm") & _
                                 "','" & rs_IMITMEXDAT.Tables("RESULT").Rows(i)("imu_chgreason") & "','" & gsUsrID & "'"
                        rtnLong = execute_SQLStatement(gspStr, rs_temp, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading IMM00002 sp_insert_IMPRCCHG_tmp : " & rtnStr)
                            IsUpdated = False
                            Me.Cursor = Windows.Forms.Cursors.Default
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

            If chkConfirmUpload.Checked = True Then
                ' **** UPDATE TO ITEM MASTER ****
                gspStr = "sp_update_IMITMEXDAT_refresh '','" & gsUsrID & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_temp, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading IMM00012 sp_update_IMITMEXDAT_refresh : " & rtnStr)
                End If

                gspStr = "sp_update_IMUPDEXDAT '','" & gsUsrID & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_temp, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading IMM00012 sp_update_IMUPDEXDAT : " & rtnStr)
                End If

                gspStr = "sp_insert_IMINSEXDAT '','" & gsUsrID & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_temp, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading IMM00012 sp_insert_IMINSEXDAT : " & rtnStr)
                End If
            End If

        End If

        Call setStatus("Save")
        isSave = False

        Me.Cursor = Windows.Forms.Cursors.Default

    End Sub

    Private Function checkTimeStamp(ByVal index As Integer) As Boolean

        Dim rs_time As New DataSet
        Dim save_timestamp As Long

        gspStr = "sp_select_IMITMEXDAT_timstp '','" & rs_IMITMEXDAT.Tables("RESULT").Rows(index)("ied_venno") & _
                 "','" & rs_IMITMEXDAT.Tables("RESULT").Rows(index)("ied_ucpno") & _
                 "','" & rs_IMITMEXDAT.Tables("RESULT").Rows(index)("ied_itmseq") & _
                 "','" & rs_IMITMEXDAT.Tables("RESULT").Rows(index)("ied_recseq") & "'"

        rtnLong = execute_SQLStatement(gspStr, rs_time, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMM00012 sp_select_IMITMEXDAT_timstp : " & rtnStr)
            Exit Function
        End If

        If rs_time.Tables("RESULT").Rows.Count > 0 Then
            save_timestamp = rs_time.Tables("RESULT").Rows(0)("ied_timstp")
        Else
            save_timestamp = 9999
        End If

        If rs_IMITMEXDAT.Tables("RESULT").Rows(index)("ied_timstp") <> save_timestamp Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub cmdApplyReason_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApplyReason.Click
        Dim i As Integer

        If grdSummary.SelectedRows.Count > 0 Then
            rs_IMITMEXDAT.Tables("RESULT").Columns("imu_chgreason").ReadOnly = False
            For i = 0 To grdSummary.SelectedRows.Count - 1
                rs_IMITMEXDAT.Tables("RESULT").Rows(grdSummary.SelectedRows.Item(i).Index)("imu_chgreason") = txtReason.Text
            Next
            rs_IMITMEXDAT.Tables("RESULT").Columns("imu_chgreason").ReadOnly = True
        Else
            If Val(txtApplyReasonFrom.Text) = "0" Then
                MsgBox("The apply range cannot be 0", MsgBoxStyle.Exclamation, "Invalid Parameters")
                txtApplyFrom.SelectAll()
                Exit Sub
            End If

            If Val(txtApplyReasonTo.Text) > rs_IMITMEXDAT.Tables("RESULT").Rows.Count Then
                MsgBox("The apply range cannot larger than the total number of records.", MsgBoxStyle.Exclamation, "Invalid Parameters")
                txtApplyTo.SelectAll()
                Exit Sub
            End If

            If Val(txtApplyReasonFrom.Text) > Val(txtApplyReasonTo.Text) Then
                MsgBox("The apply range is invalid.", MsgBoxStyle.Exclamation, "Invalid Parameters")
                txtApplyTo.SelectAll()
                Exit Sub
            End If

            rs_IMITMEXDAT.Tables("RESULT").Columns("imu_chgreason").ReadOnly = False
            For i = (txtApplyReasonFrom.Text - 1) To (txtApplyReasonTo.Text - 1)
                rs_IMITMEXDAT.Tables("RESULT").Rows(i)("imu_chgreason") = txtReason.Text
            Next
            rs_IMITMEXDAT.Tables("RESULT").Columns("imu_chgreason").ReadOnly = True
        End If
    End Sub

    Private Sub CheckReason(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRequote.CheckedChanged, chkMrkupHK.CheckedChanged, chkMrkupFTY.CheckedChanged, chkMoldCst.CheckedChanged, chkPeriod.CheckedChanged, chkHmnErrHK.CheckedChanged, chkHmnErrFTY.CheckedChanged
        txtReason.Text = ""
        If chkRequote.Checked = True Then
            txtReason.Text = txtReason.Text + "REQUOTE"
        End If
        If chkPeriod.Checked = True Then
            txtReason.Text = txtReason.Text + IIf(txtReason.TextLength > 0, "#", "") + "PERIOD CHANGE"
        End If
        If chkMoldCst.Checked = True Then
            txtReason.Text = txtReason.Text + IIf(txtReason.TextLength > 0, "#", "") + "MOLD COST CHANGE"
        End If
        If chkMrkupFTY.Checked = True Then
            txtReason.Text = txtReason.Text + IIf(txtReason.TextLength > 0, "#", "") + "MARKUP CHANGE (FTY)"
        End If
        If chkMrkupHK.Checked = True Then
            txtReason.Text = txtReason.Text + IIf(txtReason.TextLength > 0, "#", "") + "MARKUP CHANGE (HK)"
        End If
        If chkHmnErrFTY.Checked = True Then
            txtReason.Text = txtReason.Text + IIf(txtReason.TextLength > 0, "#", "") + "HUMAN ERROR (FTY)"
        End If
        If chkHmnErrHK.Checked = True Then
            txtReason.Text = txtReason.Text + IIf(txtReason.TextLength > 0, "#", "") + "HUMAN ERROR (HK)"
        End If
    End Sub

    Private Function verifyApproval() As Boolean
        Dim dr() As DataRow = rs_IMITMEXDAT.Tables("RESULT").Select("ied_stage = 'A' and ied_cusgrp = 'GROUP'")
        If dr.Length = 0 Then
            Return True
        End If

        For i As Integer = 0 To dr.Length - 1
            Dim dr_affiliated() As DataRow
            dr_affiliated = rs_IMITMEXDAT.Tables("RESULT").Select("ied_ucpno = '" & dr(i).Item("ied_ucpno") & "' and " & _
                                                                  "ied_venno = '" & dr(i).Item("ied_venno") & "' and " & _
                                                                  "ied_prdven = '" & dr(i).Item("ied_prdven") & "' and " & _
                                                                  "ied_untcde = '" & dr(i).Item("ied_untcde") & "' and " & _
                                                                  "ied_inrqty = " & dr(i).Item("ied_inrqty") & " and " & _
                                                                  "ied_mtrqty = " & dr(i).Item("ied_mtrqty") & " and " & _
                                                                  "ied_prctrm = '" & dr(i).Item("ied_prctrm") & "' and " & _
                                                                  "ied_hkprctrm = '" & dr(i).Item("ied_hkprctrm") & "' and " & _
                                                                  "ied_trantrm = '" & dr(i).Item("ied_trantrm") & "' and " & _
                                                                  "ied_cusgrp = 'GROUP' and ied_stage = 'W'")
            If dr_affiliated.Length > 0 Then
                MsgBox("Not all related items have been approved." & Environment.NewLine & "All related items must be approved at the same time.", MsgBoxStyle.ApplicationModal, "Approval Conflict")
                MsgBox("Save Cancelled")
                Return False
            End If
        Next

        Return True
    End Function
End Class