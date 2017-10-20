Public Class IMM00002

    Private recordStatus As Boolean = False
    Private saveOK As Boolean
    Private isSave As Boolean

    Public rs_IMITMDAT As DataSet
    Dim rs_IMITMDAT_dtl As DataSet
    Dim rs_BOMASSnew As New DataSet
    Dim rs_BOMASSold As New DataSet
    Dim dv_listing As DataView
    Public selected_Rowno As Integer
    Dim results As Boolean
    Dim enq_right_local As Boolean
    Dim del_right_local As Boolean

    Private Sub IMM00002_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    Private Sub mmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdFind.Click
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
        If txtPriCustFm.Text <> "" And txtPriCustTo.Text.Length = 0 Then
            txtPriCustTo.Text = txtPriCustFm.Text
        End If
        If txtPriCustFm.Text <> "" And txtPriCustTo.Text.Length = 0 Then
            txtPriCustTo.Text = txtPriCustFm.Text
        End If

        Dim itmsts As String = ""
        Dim Mode As String = ""
        Dim strChkAlias As String = ""
        selected_Rowno = -1

        If (Not chkComplete.Checked And Not chkIncomplete.Checked) Or _
            (chkComplete.Checked And chkIncomplete.Checked) Then
            itmsts = ""
        ElseIf chkComplete.Checked = True And chkIncomplete.Checked = False Then
            itmsts = "CMP"
        ElseIf chkComplete.Checked = False And chkIncomplete.Checked = True Then
            itmsts = "INC"
        End If

        If (chkInsert.Checked = False And chkUpdate.Checked = False) Or (chkInsert.Checked = True And chkUpdate.Checked = True) Then
            Mode = ""
        ElseIf chkInsert.Checked = True And chkUpdate.Checked = False Then
            Mode = "NEW"
        ElseIf chkInsert.Checked = False And chkUpdate.Checked = True Then
            Mode = "UPD"
            ' ElseIf chkInsert.Checked = True And chkUpdate.Checked = True Then
            '    Mode = "ALL"
        End If



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

        strChkAlias = IIf(Me.chkAlias.Checked = True, "Y", "N")

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        'gspStr = "sp_update_IMITMDAT_refresh '','" & LCase(gsUsrID) & "'"
        'rtnLong = execute_SQLStatement(gspStr, rs_IMITMDAT, rtnStr)

        gspStr = "sp_select_IMITMDAT '','" & itmsts & "','" & Mode & "','" & txtDateFrom.Text & _
         "','" & txtDateTo.Text & "','" & txtDesVenFrom.Text & "','" & txtDesVenTo.Text & _
         "','" & txtLineFrom.Text & "','" & txtLineTo.Text & "','" & txtVenItm.Text & _
         "','" & Int(chkApprove.Checked).ToString & "','" & Int(chkReject.Checked).ToString & _
         "','" & Int(chkWait.Checked).ToString & "','" & txtPrdVenFrom.Text & _
         "','" & txtPrdVenTo.Text & "','" & txtCusVenFrom.Text & "','" & txtCusVenTo.Text & _
         "','" & strChkAlias & "','" & txtPriCustFm.Text & "','" & txtPriCustTo.Text & "','" & _
         txtSecCustFm.Text & "','" & txtSecCustTo.Text & "','" & LCase(gsUsrID) & "'"

        rtnLong = execute_SQLStatement(gspStr, rs_IMITMDAT, rtnStr)

        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMM00002 sp_select_IMITMDAT : " & rtnStr)
            Exit Sub
        End If
        If rs_IMITMDAT.Tables("RESULT").Rows.Count = 0 Then
            setStatus("Init")
            MsgBox("No Records Found", MsgBoxStyle.Information, "Information")
        Else
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            ' Add Reason Column to Data Set
            Dim chgreason As DataColumn
            chgreason = New DataColumn("imu_chgreason", System.Type.GetType("System.String"))
            rs_IMITMDAT.Tables("RESULT").Columns.Add(chgreason)

            setStatus("Updating")
            txtApplyFrom.Text = "1"
            txtApplyTo.Text = rs_IMITMDAT.Tables("RESULT").Rows.Count
            txtApplyReasonFrom.Text = "1"
            txtApplyReasonTo.Text = rs_IMITMDAT.Tables("RESULT").Rows.Count
            'fillCount()
            DisplaySummary()
            Enable_IAR00001()
            tabFrame.SelectTab(0)
            Dim n As Integer = 0
            n = rs_IMITMDAT.Tables("RESULT").Rows.Count / 10
            If (rs_IMITMDAT.Tables("RESULT").Rows.Count Mod 10) > 0 Or _
               (rs_IMITMDAT.Tables("RESULT").Rows.Count Mod 10 = 0 And rs_IMITMDAT.Tables("RESULT").Rows.Count <> 0) Then
                n += 1
            End If
            txtApplyFrom.MaxLength = n
            txtApplyTo.MaxLength = n
            txtApplyReasonFrom.MaxLength = n
            txtApplyReasonTo.MaxLength = n
            Me.Cursor = Windows.Forms.Cursors.Default
        End If
    End Sub

    Private Sub mmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdSave.Click
        If checkFocus(Me) Then Exit Sub
        Dim IsUpdated As Boolean = False
        Dim rs_update, rs_temp As New DataSet

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        isSave = True

        If recordStatus = True Then
            For i As Integer = 0 To rs_IMITMDAT.Tables("RESULT").Rows.Count - 1
                If rs_IMITMDAT.Tables("RESULT").Rows(i)("iid_stage") <> rs_IMITMDAT.Tables("RESULT").Rows(i)("old_stage") Or rs_IMITMDAT.Tables("RESULT").Rows(i)("iid_stage") = "A" Or rs_IMITMDAT.Tables("RESULT").Rows(i)("iid_stage") = "R" Then
                    If Not checkTimeStamp(i) Then
                        MsgBox("The record has been modified by other users. Please refresh and try again.", MsgBoxStyle.Exclamation, "Overwrite Warning")
                        Me.Cursor = Windows.Forms.Cursors.Default
                        saveOK = False
                        isSave = False
                        Exit Sub
                    Else
                        gspStr = "sp_update_IMITMDAT '','" & rs_IMITMDAT.Tables("RESULT").Rows(i)("iid_venno") & _
                                 "','" & rs_IMITMDAT.Tables("RESULT").Rows(i)("iid_venitm") & _
                                 "','" & rs_IMITMDAT.Tables("RESULT").Rows(i)("iid_itmseq") & _
                                 "','" & rs_IMITMDAT.Tables("RESULT").Rows(i)("iid_recseq") & _
                                 "','" & rs_IMITMDAT.Tables("RESULT").Rows(i)("iid_stage") & _
                                 "','" & LCase(gsUsrID) & "'"
                        rtnLong = execute_SQLStatement(gspStr, rs_update, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading IMM00002 sp_update_IMITMDAT : " & rtnStr)
                            IsUpdated = False
                            Exit Sub
                        End If

                        gspStr = "sp_IMPRCCHG_tmp '','" & rs_IMITMDAT.Tables("RESULT").Rows(i)("iid_venitm") & _
                                 "','" & rs_IMITMDAT.Tables("RESULT").Rows(i)("iid_venno") & _
                                 "','" & rs_IMITMDAT.Tables("RESULT").Rows(i)("iid_prdven") & _
                                 "','" & rs_IMITMDAT.Tables("RESULT").Rows(i)("iid_untcde") & _
                                 "','" & rs_IMITMDAT.Tables("RESULT").Rows(i)("iid_inrqty") & _
                                 "','" & rs_IMITMDAT.Tables("RESULT").Rows(i)("iid_mtrqty") & _
                                 "','" & rs_IMITMDAT.Tables("RESULT").Rows(i)("iic_cus1no") & _
                                 "','" & rs_IMITMDAT.Tables("RESULT").Rows(i)("iic_cus2no") & _
                                 "','" & rs_IMITMDAT.Tables("RESULT").Rows(i)("iid_ftyprctrm") & _
                                 "','" & rs_IMITMDAT.Tables("RESULT").Rows(i)("iid_prctrm") & _
                                 "','" & rs_IMITMDAT.Tables("RESULT").Rows(i)("iid_trantrm") & _
                                 "','" & rs_IMITMDAT.Tables("RESULT").Rows(i)("imu_chgreason") & "','" & LCase(gsUsrID) & "'"
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
            ' need update here
            If chkConfirmUpload.Checked = True Then
                ' **** UPDATE TO ITEM MASTER ****
                gspStr = "sp_update_IMUPDDAT '" & LCase(gsUsrID) & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_temp, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading IMM00002 sp_update_IMUPDDAT : " & rtnStr)
                End If

                gspStr = "sp_insert_IMINSDAT '" & LCase(gsUsrID) & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_temp, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading IMM00002 sp_insert_IMINSDAT : " & rtnStr)
                End If

                'gspStr = "sp_update_IMINDDAT '" & LCase(gsUsrID) & "'"
                'rtnLong = execute_SQLStatement(gspStr, rs_temp, rtnStr)
                'If rtnLong <> RC_SUCCESS Then
                '    MsgBox("Error on loading IMM00002 sp_update_IMINDDAT : " & rtnStr)
                'End If

            End If

            gspStr = "sp_IMPRCCHG_clrtmp 'UCPP','" & LCase(gsUsrID) & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_temp, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading IMM00002 sp_IMPRCCHG_clrtmp : " & rtnStr)
            End If

        End If

        Call setStatus("Save")
        isSave = False

        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub cmdApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApply.Click
        If (optApproval.Checked = False) And (optRejection.Checked = False) And (optWait.Checked = False) Then
            MsgBox("Please select one of the following options: Approval, Rejection, or Wait for Approval", MsgBoxStyle.Exclamation, "Missing Decision")
            optApproval.Focus()
            Exit Sub
        End If

        If grdSummary.SelectedRows.Count > 0 Then
            rs_IMITMDAT.Tables("RESULT").Columns(1).ReadOnly = False
            For i As Integer = 0 To grdSummary.SelectedRows.Count - 1
                If (optApproval.Checked = True) Then
                    rs_IMITMDAT.Tables("RESULT").Rows(grdSummary.SelectedRows.Item(i).Index)(1) = "A"
                    approveReject(i)
                ElseIf (optRejection.Checked = True) Then
                    rs_IMITMDAT.Tables("RESULT").Rows(grdSummary.SelectedRows.Item(i).Index)(1) = "R"
                    approveReject(i)
                ElseIf (optWait.Checked = True) Then
                    rs_IMITMDAT.Tables("RESULT").Rows(grdSummary.SelectedRows.Item(i).Index)(1) = "W"
                End If
            Next
            rs_IMITMDAT.Tables("RESULT").Columns(1).ReadOnly = True

            'Update Checkbox DTL
            refreshTab()
            recordStatus = True
        Else
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

            ' Apply changes to indicated items from Apply Range textboxes
            For i As Integer = (txtApplyFrom.Text - 1) To (txtApplyTo.Text - 1)
                rs_IMITMDAT.Tables("RESULT").Columns("iid_stage").ReadOnly = False
                If (optApproval.Checked = True) Then
                    rs_IMITMDAT.Tables("RESULT").Rows(i)("iid_stage") = "A"
                    approveReject(i)
                ElseIf (optRejection.Checked = True) Then
                    rs_IMITMDAT.Tables("RESULT").Rows(i)("iid_stage") = "R"
                    approveReject(i)
                ElseIf (optWait.Checked = True) Then
                    rs_IMITMDAT.Tables("RESULT").Rows(i)("iid_stage") = "W"
                End If
            Next
            rs_IMITMDAT.Tables("RESULT").Columns("iid_stage").ReadOnly = True

            'Update Checkbox DTL
            refreshTab()
            recordStatus = True
        End If
    End Sub

    Private Sub approveReject(ByVal index As Integer)
        Dim rs_IMITMDAT_ASS As New DataSet
        Dim rs_IMITMDAT_REG As New DataSet
        Dim asked As Boolean, answer As Boolean
        Dim prompt As Integer

        asked = False
        answer = False

        If rs_IMITMDAT.Tables("RESULT").Rows(index)("iid_stage").ToString = "R" Then
            chkApprove_dtl.Checked = False
            chkReject_dtl.Checked = True
            chkWait_dtl.Checked = False
            chkApprove.Checked = False
            chkReject.Checked = True
            chkWait.Checked = False

            If rs_IMITMDAT.Tables("RESULT").Rows(index)("iid_itmtyp").ToString = "ASS" Then
                Me.Cursor = Windows.Forms.Cursors.WaitCursor

                gspStr = "sp_select_IMITMDAT_ASS 'UCPP','" & rs_IMITMDAT.Tables("RESULT").Rows(index)("iid_venitm").ToString & _
                            "','" & rs_IMITMDAT.Tables("RESULT").Rows(index)("iid_chkdat").ToString & _
                            "','" & rs_IMITMDAT.Tables("RESULT").Rows(index)("iid_xlsfil").ToString & "','" & LCase(gsUsrID) & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_IMITMDAT_ASS, rtnStr)

                Me.Cursor = Windows.Forms.Cursors.Default

                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading IMM00002 sp_select_IMITMDAT_ASS : " & rtnStr)
                    Exit Sub
                Else
                    If rs_IMITMDAT_ASS.Tables("RESULT").Rows.Count > 0 Then
                        Dim i As Integer, j As Integer
                        i = 0
                        j = 0
                        For i = 0 To rs_IMITMDAT.Tables("RESULT").Rows.Count - 1
                            For j = 0 To rs_IMITMDAT_ASS.Tables("RESULT").Rows.Count - 1
                                If rs_IMITMDAT.Tables("RESULT").Rows(i)("iid_venitm").ToString = rs_IMITMDAT_ASS.Tables("RESULT").Rows(j)("iad_acsno").ToString Then
                                    If asked = False Then
                                        prompt = MsgBox("Do you want to reject the related Assorted Items together?", MsgBoxStyle.YesNo, "Group Reject")
                                        If prompt = 6 Then
                                            answer = True
                                            asked = True
                                        Else
                                            answer = False
                                            asked = True
                                        End If
                                    End If
                                End If
                            Next
                        Next

                        If answer = True Then
                            rs_IMITMDAT.Tables("RESULT").Columns(1).ReadOnly = False
                            For i = 0 To rs_IMITMDAT.Tables("RESULT").Rows.Count - 1
                                For j = 0 To rs_IMITMDAT_ASS.Tables("RESULT").Rows.Count - 1
                                    If rs_IMITMDAT.Tables("RESULT").Rows(i)("iid_venitm").ToString = rs_IMITMDAT_ASS.Tables("RESULT").Rows(j)("iad_acsno").ToString Then
                                        rs_IMITMDAT.Tables("RESULT").Rows(i)(1) = "R"
                                    End If
                                Next
                            Next
                            rs_IMITMDAT.Tables("RESULT").Columns(1).ReadOnly = True
                        End If
                    End If
                End If
            ElseIf rs_IMITMDAT.Tables("RESULT").Rows(index)("iid_itmtyp").ToString = "REG" Then
                Me.Cursor = Windows.Forms.Cursors.WaitCursor

                gspStr = "sp_select_IMITMDAT_REG 'UCPP','" & rs_IMITMDAT.Tables("RESULT").Rows(index)("iid_venitm").ToString & _
                            "','" & rs_IMITMDAT.Tables("RESULT").Rows(index)("iid_chkdat").ToString & _
                            "','" & rs_IMITMDAT.Tables("RESULT").Rows(index)("iid_xlsfil").ToString & "','" & LCase(gsUsrID) & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_IMITMDAT_REG, rtnStr)

                Me.Cursor = Windows.Forms.Cursors.Default

                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading IMM00002 sp_select_IMITMDAT_REG : " & rtnStr)
                    Exit Sub
                Else
                    If rs_IMITMDAT_REG.Tables("RESULT").Rows.Count > 0 Then
                        Dim i As Integer, j As Integer
                        i = 0
                        j = 0
                        For i = 0 To rs_IMITMDAT.Tables("RESULT").Rows.Count - 1
                            For j = 0 To rs_IMITMDAT_REG.Tables("RESULT").Rows.Count - 1
                                If rs_IMITMDAT.Tables("RESULT").Rows(i)("iid_venitm").ToString = rs_IMITMDAT_REG.Tables("RESULT").Rows(j)("iad_venitm").ToString Then
                                    If asked = False Then
                                        prompt = MsgBox("Do you want to reject its Assortment Item?", MsgBoxStyle.YesNo, "Group Reject")
                                        If prompt = 6 Then
                                            answer = True
                                            asked = True
                                        Else
                                            answer = False
                                            asked = True
                                        End If
                                    End If
                                End If
                            Next
                        Next

                        If answer = True Then
                            rs_IMITMDAT.Tables("RESULT").Columns(1).ReadOnly = False
                            For i = 0 To rs_IMITMDAT.Tables("RESULT").Rows.Count - 1
                                For j = 0 To rs_IMITMDAT_REG.Tables("RESULT").Rows.Count - 1
                                    If rs_IMITMDAT.Tables("RESULT").Rows(i)("iid_venitm").ToString = rs_IMITMDAT_REG.Tables("RESULT").Rows(j)("iad_venitm").ToString Then
                                        rs_IMITMDAT.Tables("RESULT").Rows(i)(1) = "R"
                                    End If
                                Next
                            Next
                            rs_IMITMDAT.Tables("RESULT").Columns(1).ReadOnly = True
                        End If
                    End If
                End If
            End If
        ElseIf rs_IMITMDAT.Tables("RESULT").Rows(index)("iid_stage").ToString = "A" Then
            chkApprove_dtl.Checked = True
            chkReject_dtl.Checked = False
            chkWait_dtl.Checked = False
            chkApprove.Checked = True
            chkReject.Checked = False
            chkWait.Checked = False

            If rs_IMITMDAT.Tables("RESULT").Rows(index)("iid_itmtyp").ToString = "ASS" Then
                Me.Cursor = Windows.Forms.Cursors.WaitCursor

                gspStr = "sp_select_IMITMDAT_ASS 'UCPP','" & rs_IMITMDAT.Tables("RESULT").Rows(index)("iid_venitm").ToString & _
                            "','" & rs_IMITMDAT.Tables("RESULT").Rows(index)("iid_chkdat").ToString & _
                            "','" & rs_IMITMDAT.Tables("RESULT").Rows(index)("iid_xlsfil").ToString & "','" & LCase(gsUsrID) & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_IMITMDAT_ASS, rtnStr)

                Me.Cursor = Windows.Forms.Cursors.Default

                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading IMM00002 sp_select_IMITMDAT_ASS : " & rtnStr)
                    Exit Sub
                Else
                    If rs_IMITMDAT_ASS.Tables("RESULT").Rows.Count > 0 Then
                        Dim i As Integer, j As Integer
                        i = 0
                        j = 0
                        For i = 0 To rs_IMITMDAT.Tables("RESULT").Rows.Count - 1
                            For j = 0 To rs_IMITMDAT_ASS.Tables("RESULT").Rows.Count - 1
                                If rs_IMITMDAT.Tables("RESULT").Rows(i)("iid_venitm").ToString = rs_IMITMDAT_ASS.Tables("RESULT").Rows(j)("iad_acsno").ToString Then
                                    If asked = False Then
                                        prompt = MsgBox("You must approve the related Assorted Items together.  Confirm to approve the Assorted Item?", MsgBoxStyle.YesNo, "Group Reject")
                                        If prompt = 6 Then
                                            answer = True
                                            asked = True
                                        Else
                                            answer = False
                                            asked = True
                                        End If
                                    End If
                                End If
                            Next
                        Next

                        If answer = True Then
                            rs_IMITMDAT.Tables("RESULT").Columns(1).ReadOnly = False
                            For i = 0 To rs_IMITMDAT.Tables("RESULT").Rows.Count - 1
                                For j = 0 To rs_IMITMDAT_ASS.Tables("RESULT").Rows.Count - 1
                                    If rs_IMITMDAT.Tables("RESULT").Rows(i)("iid_venitm").ToString = rs_IMITMDAT_ASS.Tables("RESULT").Rows(j)("iad_acsno").ToString Then
                                        rs_IMITMDAT.Tables("RESULT").Rows(i)(1) = "A"
                                    End If
                                Next
                            Next
                            rs_IMITMDAT.Tables("RESULT").Columns(1).ReadOnly = True
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub fillCount()
        'rs_IMITMDAT.Tables("RESULT").Columns("no").ReadOnly = False
        'For i As Integer = 0 To rs_IMITMDAT.Tables("RESULT").Rows.Count - 1
        '    rs_IMITMDAT.Tables("RESULT").Rows(i)("no") = i + 1
        'Next
        'rs_IMITMDAT.Tables("RESULT").Columns("no").ReadOnly = True

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
                        .Columns(i).HeaderText = "Apv Rej"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case 3
                        .Columns(i).HeaderText = "DV"
                        .Columns(i).Width = 27
                        .Columns(i).ReadOnly = True
                    Case 4
                        .Columns(i).HeaderText = "FTY Prc Term"
                        .Columns(i).Width = 50
                        .Columns(i).ReadOnly = True
                    Case 5
                        .Columns(i).HeaderText = "HK Prc Term"
                        .Columns(i).Width = 50
                        .Columns(i).ReadOnly = True
                    Case 6
                        .Columns(i).HeaderText = "Tran Term"
                        .Columns(i).Width = 50
                        .Columns(i).ReadOnly = True
                    Case 9
                        .Columns(i).HeaderText = "Vendor Item"
                        .Columns(i).Width = 95
                        .Columns(i).ReadOnly = True
                    Case 10
                        .Columns(i).HeaderText = "Item No."
                        .Columns(i).Width = 95
                        .Columns(i).ReadOnly = True
                    Case 11
                        .Columns(i).HeaderText = "Type"
                        .Columns(i).Width = 38
                        .Columns(i).ReadOnly = True
                    Case 12
                        .Columns(i).HeaderText = "Mode"
                        .Columns(i).Width = 38
                        .Columns(i).ReadOnly = True
                    Case 13
                        .Columns(i).HeaderText = "English Desc."
                        .Columns(i).Width = 110
                        .Columns(i).ReadOnly = True
                    Case 14
                        .Columns(i).HeaderText = "Packing Instruction"
                        .Columns(i).Width = 110
                        .Columns(i).ReadOnly = True
                    Case 15
                        .Columns(i).HeaderText = "UM"
                        .Columns(i).Width = 45
                        .Columns(i).ReadOnly = True
                    Case 16
                        .Columns(i).HeaderText = "Inr Qty"
                        .Columns(i).Width = 37
                        .Columns(i).ReadOnly = True
                    Case 17
                        .Columns(i).HeaderText = "Mtr Qty"
                        .Columns(i).Width = 37
                        .Columns(i).ReadOnly = True
                    Case 18
                        .Columns(i).HeaderText = "CFT"
                        .Columns(i).Width = 55
                        .Columns(i).ReadOnly = True
                    Case 19
                        .Columns(i).HeaderText = "C. Factor"
                        .Columns(i).Width = 45
                        .Columns(i).ReadOnly = True
                    Case 20
                        .Columns(i).HeaderText = "CCY"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case 21
                        .Columns(i).HeaderText = "FTY Prc"
                        .Columns(i).Width = 60
                        .Columns(i).ReadOnly = True
                    Case 22
                        .Columns(i).HeaderText = "Prod. Line"
                        .Columns(i).Width = 65
                        .Columns(i).ReadOnly = True
                    Case 23
                        .Columns(i).HeaderText = "FTY Cst"
                        .Columns(i).Width = 60
                        .Columns(i).ReadOnly = True
                    Case 24
                        .Columns(i).HeaderText = "Neg. Prc"
                        .Columns(i).Width = 60
                        .Columns(i).ReadOnly = True
                    Case 25
                        .Columns(i).HeaderText = "Chinese Desc."
                        .Columns(i).Width = 110
                        .Columns(i).ReadOnly = True
                    Case 26
                        .Columns(i).HeaderText = "Date"
                        .Columns(i).Width = 60
                        .Columns(i).ReadOnly = True
                    Case 27
                        .Columns(i).HeaderText = "Status"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case 28
                        .Columns(i).HeaderText = "Category 4"
                        .Columns(i).Width = 75
                        .Columns(i).ReadOnly = True
                    Case 37
                        .Columns(i).HeaderText = "Period"
                        .Columns(i).Width = 60
                        .Columns(i).ReadOnly = True
                    Case 38
                        .Columns(i).HeaderText = "Cost Expiry Date"
                        .Columns(i).Width = 75
                        .Columns(i).ReadOnly = True
                    Case 48
                        .Columns(i).HeaderText = "Pri Cus"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case 49
                        .Columns(i).HeaderText = "Sec Cus"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case 50
                        .Columns(i).HeaderText = "FTY Tmp"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case 51
                        .Columns(i).HeaderText = "Change Reason"
                        .Columns(i).Width = 400
                        .Columns(i).ReadOnly = True
                    Case Else
                        .Columns(i).Visible = False
                End Select
                '.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i
        End With

        grdSummary.Columns("iic_cus1no").DisplayIndex = 4
        grdSummary.Columns("iic_cus2no").DisplayIndex = 5
        grdSummary.Columns("iid_ftytmp").DisplayIndex = 13

        grdSummary.Columns("iid_venitm").Frozen = True

        selected_Rowno = 0

        StatusBar.Items("lblRight").Text = "Created: " & rs_IMITMDAT.Tables("RESULT").Rows(selected_Rowno)("iid_credat") & " " & _
                                           "Updated: " & Format(rs_IMITMDAT.Tables("RESULT").Rows(selected_Rowno)("iid_upddat"), "MM/dd/yyyy") & " " & _
                                           "by " & rs_IMITMDAT.Tables("RESULT").Rows(selected_Rowno)("iid_updusr")
        refreshTab()
    End Sub

    Private Sub refreshTab()
        If tabFrame.SelectedIndex = 0 Then
            If results = True Then
                grdSummary.CurrentCell = grdSummary.Rows(selected_Rowno).Cells(0)
                grdSummary.ClearSelection()
            End If
        ElseIf tabFrame.SelectedIndex = 1 Then

            DetailTab()
        ElseIf tabFrame.SelectedIndex = 2 Then
            BomAssTab()
        End If
    End Sub
    Private Sub BomAssTab()

        If rs_IMITMDAT Is Nothing Then
            Exit Sub
        End If

        BomAssTab_grdOldRecord()
        BomAssTab_grdNewRecord()

        DetailandBOMTab_RecordButtonSetting()

    End Sub

    Private Sub BomAssTab_grdOldRecord()
        'Tips 1: 
        ' 'And' operation is not Short-circuit evaluation in VB. 
        ' So (Not rs_IMITMDAT Is Nothing)  does not help to avoid the null exception caused by (rs_IMITMDAT.Tables("RESULT").Rows.Count) 
        'when rs_IMITMDAT is nothing----> the '(Not rs_IMITMDAT Is Nothing) and' is meaningless. The function to avoid emtpy dataset is on method BomAssTab()
        'The '(Not rs_IMITMDAT Is Nothing) and' is more like a remark only
        'Tips 2:
        'The sp 'sp_select_BOMASS' should get the REG itmtyp only now,but in a old version, this function can also be used on ASS item. 
        'So the name and code contain some parts related to Assorted  type item. Don't be too confused
        If (Not rs_IMITMDAT Is Nothing) And rs_IMITMDAT.Tables("RESULT").Rows.Count > 0 Then

            grdOldRecord.DataSource = Nothing
            If rs_IMITMDAT.Tables("RESULT").Rows(selected_Rowno)("iid_itmtyp") = "REG" Then

                gspStr = "sp_select_BOMASS" & " 'OLD','" & rs_IMITMDAT.Tables("RESULT").Rows(selected_Rowno)("iid_itmtyp") & "','','" & rs_IMITMDAT.Tables("RESULT").Rows(selected_Rowno)("iid_venitm") & "'"

                rtnLong = execute_SQLStatement(gspStr, rs_BOMASSold, rtnStr)
                grdOldRecord.DataSource = rs_BOMASSold.Tables("RESULT").DefaultView
                If rs_IMITMDAT.Tables("RESULT").Rows(selected_Rowno)("iid_itmtyp") = "REG" Then

                    grdOldRecord.Columns(2).Width = 300
                    Me.grdOldRecord.Columns(0).HeaderText = "Item No."
                    Me.grdOldRecord.Columns(1).HeaderText = "Accessory No."
                Else
                    grdOldRecord.Columns(3).Width = 50
                    grdOldRecord.Columns(4).Width = 260

                End If
            End If
        End If
    End Sub
    Private Sub BomAssTab_grdNewRecord()
        'Tips:Read the command tips in BomAssTab_grdOldRecord()
        If (Not rs_IMITMDAT Is Nothing) And rs_IMITMDAT.Tables("RESULT").Rows.Count > 0 Then

            grdNewRecord.DataSource = Nothing
            If rs_IMITMDAT.Tables("RESULT").Rows(selected_Rowno)("iid_itmtyp") = "REG" Then

                gspStr = "sp_select_BOMASS" & " 'NEW','" & rs_IMITMDAT.Tables("RESULT").Rows(selected_Rowno)("iid_itmtyp") & "','','" & rs_IMITMDAT.Tables("RESULT").Rows(selected_Rowno)("iid_venitm") & "'"

                rtnLong = execute_SQLStatement(gspStr, rs_BOMASSnew, rtnStr)
                grdNewRecord.DataSource = rs_BOMASSnew.Tables("RESULT").DefaultView
                If rs_IMITMDAT.Tables("RESULT").Rows(selected_Rowno)("iid_itmtyp") = "REG" Then

                    grdNewRecord.Columns(2).Width = 300
                    Me.grdNewRecord.Columns(0).HeaderText = "Item No."
                    Me.grdNewRecord.Columns(1).HeaderText = "Accessory No."
                Else
                    grdNewRecord.Columns(3).Width = 50
                    grdNewRecord.Columns(4).Width = 260
                End If

            End If
        End If
    End Sub
    Private Sub DetailTab()

        DetailandBOMTab_RecordButtonSetting()
        DetailTab_ContentDisplay()
    End Sub
    Private Sub DetailandBOMTab_RecordButtonSetting()
        If Not rs_IMITMDAT Is Nothing Then
            If rs_IMITMDAT.Tables("RESULT").Rows.Count <= 1 Then
                cmdFirst_BOM.Enabled = False
                cmdFirst_dtl.Enabled = False
                cmdPrev_BOM.Enabled = False
                cmdPrev_dtl.Enabled = False
                cmdNext_BOM.Enabled = False
                cmdNext_dtl.Enabled = False
                cmdLast_BOM.Enabled = False
                cmdLast_dtl.Enabled = False
            Else
                'more than one record
                cmdFirst_BOM.Enabled = False
                cmdFirst_dtl.Enabled = False
                cmdPrev_BOM.Enabled = False
                cmdPrev_dtl.Enabled = False
                cmdNext_BOM.Enabled = False
                cmdNext_dtl.Enabled = False
                cmdLast_BOM.Enabled = False
                cmdLast_dtl.Enabled = False
                If selected_Rowno = 0 Then
                    cmdNext_BOM.Enabled = True
                    cmdNext_dtl.Enabled = True
                    cmdLast_BOM.Enabled = True
                    cmdLast_dtl.Enabled = True
                ElseIf selected_Rowno = (rs_IMITMDAT.Tables("RESULT").Rows.Count - 1) Then
                    cmdFirst_BOM.Enabled = True
                    cmdFirst_dtl.Enabled = True
                    cmdPrev_BOM.Enabled = True
                    cmdPrev_dtl.Enabled = True
                Else
                    cmdFirst_BOM.Enabled = True
                    cmdFirst_dtl.Enabled = True
                    cmdPrev_BOM.Enabled = True
                    cmdPrev_dtl.Enabled = True
                    cmdNext_BOM.Enabled = True
                    cmdNext_dtl.Enabled = True
                    cmdLast_BOM.Enabled = True
                    cmdLast_dtl.Enabled = True
                End If
            End If
        End If
    End Sub
    Private Sub DetailTab_ContentDisplay()
        If isSave = False And results = True Then
            If Not rs_IMITMDAT Is Nothing Then
                txtVenItm_dtl.Text = rs_IMITMDAT.Tables("RESULT").Rows(selected_Rowno)("iid_venitm")

                If rs_IMITMDAT.Tables("RESULT").Rows(selected_Rowno)("iid_stage") = "A" Then
                    chkApprove_dtl.Checked = True
                    chkReject_dtl.Checked = False
                    chkWait_dtl.Checked = False
                ElseIf rs_IMITMDAT.Tables("RESULT").Rows(selected_Rowno)("iid_stage") = "R" Then
                    chkApprove_dtl.Checked = False
                    chkReject_dtl.Checked = True
                    chkWait_dtl.Checked = False
                ElseIf rs_IMITMDAT.Tables("RESULT").Rows(selected_Rowno)("iid_stage") = "W" Then
                    chkApprove_dtl.Checked = False
                    chkReject_dtl.Checked = False
                    chkWait_dtl.Checked = True
                End If

                txtUM_dtl.Text = rs_IMITMDAT.Tables("RESULT").Rows(selected_Rowno)("iid_untcde")
                txtInrQty_dtl.Text = rs_IMITMDAT.Tables("RESULT").Rows(selected_Rowno)("iid_inrqty")
                txtMtrQty_dtl.Text = rs_IMITMDAT.Tables("RESULT").Rows(selected_Rowno)("iid_mtrqty")
                txtDesVenNo_dtl.Text = rs_IMITMDAT.Tables("RESULT").Rows(selected_Rowno)("iid_venno")
                txtPrdVenNo_dtl.Text = rs_IMITMDAT.Tables("RESULT").Rows(selected_Rowno)("iid_prdven")
                txtUpdDate_dtl.Text = rs_IMITMDAT.Tables("RESULT").Rows(selected_Rowno)("iid_credat")
                txtEngDesc_dtl.Text = rs_IMITMDAT.Tables("RESULT").Rows(selected_Rowno)("iid_engdsc")
                txtCusVenNo_dtl.Text = rs_IMITMDAT.Tables("RESULT").Rows(selected_Rowno)("iid_cusven")
                txtCFT.Text = rs_IMITMDAT.Tables("RESULT").Rows(selected_Rowno)("iid_cft")
                StatusBar.Items("lblRight").Text = "Created: " & rs_IMITMDAT.Tables("RESULT").Rows(selected_Rowno)("iid_credat") & " " & _
                                                   "Updated: " & Format(rs_IMITMDAT.Tables("RESULT").Rows(selected_Rowno)("iid_upddat"), "MM/dd/yyyy") & " " & _
                                                   "by " & rs_IMITMDAT.Tables("RESULT").Rows(selected_Rowno)("iid_updusr")
                If rs_IMITMDAT.Tables("RESULT").Rows(selected_Rowno)("iic_cus2no") = "" Then

                    txtCus.Text = rs_IMITMDAT.Tables("RESULT").Rows(selected_Rowno)("iic_cus1no")

                Else
                    txtCus.Text = rs_IMITMDAT.Tables("RESULT").Rows(selected_Rowno)("iic_cus1no") & " / " & rs_IMITMDAT.Tables("RESULT").Rows(selected_Rowno)("iic_cus2no")

                End If
                find_Detail()
            End If
        End If
    End Sub
    Private Sub find_Detail()
        gspStr = "sp_select_IMITMDAT_dtl2 '" & "" & _
                 "','" & rs_IMITMDAT.Tables("RESULT").Rows(selected_Rowno)("iid_venitm") & _
                 "','" & rs_IMITMDAT.Tables("RESULT").Rows(selected_Rowno)("iid_untcde") & _
                 "','" & rs_IMITMDAT.Tables("RESULT").Rows(selected_Rowno)("iid_inrqty") & _
                 "','" & rs_IMITMDAT.Tables("RESULT").Rows(selected_Rowno)("iid_mtrqty") & _
                 "','" & rs_IMITMDAT.Tables("RESULT").Rows(selected_Rowno)("iid_itmseq") & _
                 "','" & rs_IMITMDAT.Tables("RESULT").Rows(selected_Rowno)("iid_recseq") & "'"

        rtnLong = execute_SQLStatement(gspStr, rs_IMITMDAT_dtl, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMM00002 sp_select_IMITMDAT_dtl : " & rtnStr)
            Exit Sub
        End If
        If rs_IMITMDAT_dtl.Tables("RESULT").Rows.Count > 0 Then
            displayDetail()
        Else
            MsgBox("No Record History Found", MsgBoxStyle.Information, "Information")
        End If
    End Sub

    Private Sub displayDetail()
        Dim dv As DataView = rs_IMITMDAT_dtl.Tables("RESULT").DefaultView

        With grdDetail
            .DataSource = Nothing
            .DataSource = dv
            For i As Integer = 0 To .Columns.Count - 1
                Select Case i
                    Case 0
                        .Columns(i).HeaderText = "Field Name"
                        .Columns(i).Width = 130
                        .Columns(i).ReadOnly = True
                    Case 1
                        .Columns(i).HeaderText = "Mode"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case 2
                        .Columns(i).HeaderText = "Before"
                        .Columns(i).Width = 325
                        .Columns(i).ReadOnly = True
                    Case 3
                        .Columns(i).HeaderText = "After"
                        .Columns(i).Width = 325
                        .Columns(i).ReadOnly = True
                    Case 4
                        .Columns(i).HeaderText = "Change"
                        .Columns(i).Width = 50
                        .Columns(i).ReadOnly = True
                    Case Else
                        .Columns(i).Visible = False
                End Select
            Next
        End With
    End Sub

    Private Sub validateInput(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtApplyTo.KeyPress, txtApplyFrom.KeyPress, txtApplyReasonTo.KeyPress, txtApplyReasonFrom.KeyPress
        If Not ((Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub cmdFirst_dtl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFirst_dtl.Click, cmdFirst_BOM.Click
        If Not rs_IMITMDAT Is Nothing Then
            If (selected_Rowno > 0) Then
                selected_Rowno = 0
            End If
        End If
        refreshTab()
    End Sub

    Private Sub cmdPrev_dtl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrev_dtl.Click, cmdPrev_BOM.Click
        If Not rs_IMITMDAT Is Nothing Then
            If (selected_Rowno > 0) Then
                selected_Rowno = selected_Rowno - 1
            End If
        End If
        refreshTab()
    End Sub

    Private Sub cmdNext_dtl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext_dtl.Click, cmdNext_BOM.Click
        If Not rs_IMITMDAT Is Nothing Then
            If (selected_Rowno < Val(dv_listing.Count - 1)) Then
                selected_Rowno = selected_Rowno + 1
            End If
        End If
        refreshTab()
    End Sub

    Private Sub cmdLast_dtl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLast_dtl.Click, cmdLast_BOM.Click
        If Not rs_IMITMDAT Is Nothing Then
            If (selected_Rowno < Val(dv_listing.Count - 1)) Then
                selected_Rowno = dv_listing.Count - 1
            End If
        End If
        refreshTab()
    End Sub

    Private Sub chkApprove_dtl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkApprove_dtl.Click
        If isSave = False Then
            If chkApprove_dtl.Checked = True Then
                chkReject_dtl.Checked = False
                chkWait_dtl.Checked = False
                rs_IMITMDAT.Tables("RESULT").Columns(1).ReadOnly = False
                rs_IMITMDAT.Tables("RESULT").Rows(selected_Rowno)("iid_stage") = "A"
                rs_IMITMDAT.Tables("RESULT").Columns(1).ReadOnly = True
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
                rs_IMITMDAT.Tables("RESULT").Columns(1).ReadOnly = False
                rs_IMITMDAT.Tables("RESULT").Rows(selected_Rowno)("iid_stage") = "R"
                rs_IMITMDAT.Tables("RESULT").Columns(1).ReadOnly = True
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
                rs_IMITMDAT.Tables("RESULT").Columns(1).ReadOnly = False
                rs_IMITMDAT.Tables("RESULT").Rows(selected_Rowno)("iid_stage") = "W"
                rs_IMITMDAT.Tables("RESULT").Columns(1).ReadOnly = True
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
                rs_IMITMDAT.Tables("RESULT").Columns(1).ReadOnly = False
                If (rs_IMITMDAT.Tables("RESULT").Rows(grdSummary.SelectedCells.Item(0).RowIndex)(1) = "W") Then
                    rs_IMITMDAT.Tables("RESULT").Rows(grdSummary.SelectedCells.Item(0).RowIndex)(1) = "A"
                    updateRecordStatusChkBox("A")
                ElseIf (rs_IMITMDAT.Tables("RESULT").Rows(grdSummary.SelectedCells.Item(0).RowIndex)(1) = "A") Then
                    rs_IMITMDAT.Tables("RESULT").Rows(grdSummary.SelectedCells.Item(0).RowIndex)(1) = "R"
                    updateRecordStatusChkBox("R")
                ElseIf (rs_IMITMDAT.Tables("RESULT").Rows(grdSummary.SelectedCells.Item(0).RowIndex)(1) = "R") Then
                    rs_IMITMDAT.Tables("RESULT").Rows(grdSummary.SelectedCells.Item(0).RowIndex)(1) = "W"
                    updateRecordStatusChkBox("W")
                End If
                rs_IMITMDAT.Tables("RESULT").Columns(1).ReadOnly = True
                recordStatus = True
            ElseIf grdSummary.SelectedCells.Item(0).ColumnIndex = 48 Then
                rs_IMITMDAT.Tables("RESULT").Columns("iid_ftytmp").ReadOnly = False
                If Trim(rs_IMITMDAT.Tables("RESULT").Rows(grdSummary.SelectedCells.Item(0).RowIndex)("iid_ftytmp")) = "N" Then
                    rs_IMITMDAT.Tables("RESULT").Rows(grdSummary.SelectedCells.Item(0).RowIndex)("iid_ftytmp") = "Y"
                ElseIf rs_IMITMDAT.Tables("RESULT").Rows(grdSummary.SelectedCells.Item(0).RowIndex)("iid_ftytmp") = "Y" Then
                    rs_IMITMDAT.Tables("RESULT").Rows(grdSummary.SelectedCells.Item(0).RowIndex)("iid_ftytmp") = "N"
                End If
                rs_IMITMDAT.Tables("RESULT").Columns("iid_ftytmp").ReadOnly = True
            End If

            'selected_Rowno = grdSummary.Rows(grdSummary.SelectedCells.Item(0).RowIndex).Item(0).Value - 1
            selected_Rowno = grdSummary.Rows(grdSummary.SelectedCells.Item(0).RowIndex).Cells(0).Value - 1
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

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdClear.Click
        If checkFocus(Me) Then Exit Sub
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

    Private Sub Enable_IAR00001()

        cmdIAR00001.Enabled = getEnquiryRightByFormName(IAR00001.Name.ToString)
    End Sub

    Private Sub tabFrame_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabFrame.SelectedIndexChanged
        refreshTab()
    End Sub

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
            txtPriCustFm.Enabled = True
            txtPriCustFm.Text = ""
            txtPriCustTo.Enabled = True
            txtPriCustTo.Text = ""
            txtSecCustFm.Enabled = True
            txtSecCustFm.Text = ""
            txtSecCustTo.Enabled = True
            txtSecCustTo.Text = ""
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
            optApproval.Checked = False
            optRejection.Enabled = False
            optRejection.Checked = False
            optWait.Enabled = False
            optWait.Checked = False
            txtApplyFrom.Enabled = False
            txtApplyFrom.Text = ""
            txtApplyTo.Enabled = False
            txtApplyTo.Text = ""
            cmdApply.Enabled = False

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

            cmdFirst_BOM.Enabled = False
            cmdFirst_dtl.Enabled = False
            cmdPrev_BOM.Enabled = False
            cmdPrev_dtl.Enabled = False
            cmdNext_BOM.Enabled = False
            cmdNext_dtl.Enabled = False
            cmdLast_BOM.Enabled = False
            cmdLast_dtl.Enabled = False

            txtUM_dtl.Text = ""
            txtInrQty_dtl.Text = ""
            txtMtrQty_dtl.Text = ""
            txtDesVenNo_dtl.Text = ""
            txtPrdVenNo_dtl.Text = ""
            txtCusVenNo_dtl.Text = ""
            txtUpdDate_dtl.Text = ""
            txtEngDesc_dtl.Text = ""
            txtCFT.Text = ""
            grdDetail.Enabled = False

            grpStage.Enabled = False
            grpReason.Enabled = False
            chkRequote.Checked = False
            chkPacking.Checked = False
            chkMoldCst.Checked = False
            chkMrkupFTY.Checked = False
            chkHmnErrFTY.Checked = False
            chkSalesReq.Checked = False
            txtReason.Text = ""

            cmdApplyTmp.Visible = False
            radTmpYes.Visible = False
            radTmpNo.Visible = False


            resetDefaultDisp()
            SetStatusBar(Mode)

            '***Reset the flag
            recordStatus = False
            results = False
        ElseIf Mode = "Updating" Then
            mmdAdd.Enabled = False
            mmdSave.Enabled = enq_right_local
            mmdDelete.Enabled = False
            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdClear.Enabled = True

            mmdInsRow.Enabled = False
            mmdDelRow.Enabled = False

            mmdExit.Enabled = True

            cmdFirst_BOM.Enabled = True
            cmdFirst_dtl.Enabled = True
            cmdLast_BOM.Enabled = True
            cmdLast_dtl.Enabled = True
            cmdNext_BOM.Enabled = True
            cmdNext_dtl.Enabled = True
            cmdPrev_BOM.Enabled = True
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
            txtPriCustFm.Enabled = False
            txtPriCustTo.Enabled = False
            txtSecCustFm.Enabled = False
            txtSecCustTo.Enabled = False
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
            grdOldRecord.DataSource = Nothing
            grdNewRecord.DataSource = Nothing
            rs_IMITMDAT = Nothing
            rs_IMITMDAT_dtl = Nothing
            rs_BOMASSold = Nothing

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

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdExit.Click
        If checkFocus(Me) Then Exit Sub
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

    Private Sub cmdIAR00001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIAR00001.Click
        'IAR00001.ShowDialog()

        Dim frmIAR00001 As New IAR00001


        frmIAR00001.ShowDialog()
    End Sub

    Private Sub cmdIMR00021_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'IMR00021.ShowDialog()
    End Sub

    Private Sub cmdAssort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'IMM00002_2.ShowDialog()
    End Sub

    Private Sub cmdApplyReason_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApplyReason.Click
        Dim i As Integer

        If grdSummary.SelectedRows.Count > 0 Then
            rs_IMITMDAT.Tables("RESULT").Columns("imu_chgreason").ReadOnly = False
            For i = 0 To grdSummary.SelectedRows.Count - 1
                rs_IMITMDAT.Tables("RESULT").Rows(grdSummary.SelectedRows.Item(i).Index)("imu_chgreason") = txtReason.Text
            Next
            rs_IMITMDAT.Tables("RESULT").Columns("imu_chgreason").ReadOnly = True
        Else
            If Val(txtApplyReasonFrom.Text) = "0" Then
                MsgBox("The apply range cannot be 0", MsgBoxStyle.Exclamation, "Invalid Parameters")
                txtApplyFrom.SelectAll()
                Exit Sub
            End If

            If Val(txtApplyReasonTo.Text) > rs_IMITMDAT.Tables("RESULT").Rows.Count Then
                MsgBox("The apply range cannot larger than the total number of records.", MsgBoxStyle.Exclamation, "Invalid Parameters")
                txtApplyTo.SelectAll()
                Exit Sub
            End If

            If Val(txtApplyReasonFrom.Text) > Val(txtApplyReasonTo.Text) Then
                MsgBox("The apply range is invalid.", MsgBoxStyle.Exclamation, "Invalid Parameters")
                txtApplyTo.SelectAll()
                Exit Sub
            End If

            rs_IMITMDAT.Tables("RESULT").Columns("imu_chgreason").ReadOnly = False
            For i = (txtApplyReasonFrom.Text - 1) To (txtApplyReasonTo.Text - 1)
                rs_IMITMDAT.Tables("RESULT").Rows(i)("imu_chgreason") = txtReason.Text
            Next
            rs_IMITMDAT.Tables("RESULT").Columns("imu_chgreason").ReadOnly = True
        End If
    End Sub

    Private Sub CheckReason(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRequote.CheckedChanged, chkMrkupFTY.CheckedChanged, chkMoldCst.CheckedChanged, chkPacking.CheckedChanged, chkSalesReq.CheckedChanged, chkHmnErrFTY.CheckedChanged
        txtReason.Text = ""
        If chkRequote.Checked = True Then
            txtReason.Text = txtReason.Text + "REQUOTE"
        End If
        If chkPacking.Checked = True Then
            txtReason.Text = txtReason.Text + IIf(txtReason.TextLength > 0, "#", "") + "PACKING CHANGE"
        End If
        If chkMoldCst.Checked = True Then
            txtReason.Text = txtReason.Text + IIf(txtReason.TextLength > 0, "#", "") + "MOLD COST CHANGE"
        End If
        If chkMrkupFTY.Checked = True Then
            txtReason.Text = txtReason.Text + IIf(txtReason.TextLength > 0, "#", "") + "MARKUP CHANGE (FTY)"
        End If

        If chkHmnErrFTY.Checked = True Then
            txtReason.Text = txtReason.Text + IIf(txtReason.TextLength > 0, "#", "") + "HUMAN ERROR (FTY)"
        End If
        If chkSalesReq.Checked = True Then
            txtReason.Text = txtReason.Text + IIf(txtReason.TextLength > 0, "#", "") + "SALES REQUEST"
        End If
    End Sub

    Private Sub chkApplyTmp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If chkApplyTmp.Checked = False Then
        chkRequote.Enabled = True
        chkPacking.Enabled = True
        chkMoldCst.Enabled = True
        chkMrkupFTY.Enabled = True
        chkHmnErrFTY.Enabled = True
        chkSalesReq.Enabled = True
        cmdApplyReason.Visible = True
        cmdApplyTmp.Visible = False

        txtReason.Visible = True
        radTmpYes.Visible = False
        radTmpNo.Visible = False
        'Else
        '    chkRequote.Enabled = False
        '    chkPeriod.Enabled = False
        '    chkMoldCst.Enabled = False
        '    chkMrkupFTY.Enabled = False
        '    chkHmnErrFTY.Enabled = False
        '    chkHmnErrHK.Enabled = False
        '    cmdApplyReason.Visible = False
        '    cmdApplyTmp.Visible = True

        '    txtReason.Visible = False
        '    radTmpYes.Visible = True
        '    radTmpNo.Visible = True
        '    radTmpYes.Checked = True
        '    radTmpNo.Checked = False
        'End If
    End Sub

    Private Sub cmdApplyTmp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApplyTmp.Click
        Dim i As Integer

        If grdSummary.SelectedRows.Count > 0 Then
            rs_IMITMDAT.Tables("RESULT").Columns("iid_ftytmp").ReadOnly = False
            For i = 0 To grdSummary.SelectedRows.Count - 1
                If radTmpYes.Checked = True Then
                    rs_IMITMDAT.Tables("RESULT").Rows(grdSummary.SelectedRows.Item(i).Index)("iid_ftytmp") = "Y"
                ElseIf radTmpNo.Checked = True Then
                    rs_IMITMDAT.Tables("RESULT").Rows(grdSummary.SelectedRows.Item(i).Index)("iid_ftytmp") = "N"
                End If
            Next
            rs_IMITMDAT.Tables("RESULT").Columns("iid_ftytmp").ReadOnly = True
        Else
            If Val(txtApplyReasonFrom.Text) = "0" Then
                MsgBox("The apply range cannot be 0", MsgBoxStyle.Exclamation, "Invalid Parameters")
                txtApplyFrom.SelectAll()
                Exit Sub
            End If

            If Val(txtApplyReasonTo.Text) > rs_IMITMDAT.Tables("RESULT").Rows.Count Then
                MsgBox("The apply range cannot larger than the total number of records.", MsgBoxStyle.Exclamation, "Invalid Parameters")
                txtApplyTo.SelectAll()
                Exit Sub
            End If

            If Val(txtApplyReasonFrom.Text) > Val(txtApplyReasonTo.Text) Then
                MsgBox("The apply range is invalid.", MsgBoxStyle.Exclamation, "Invalid Parameters")
                txtApplyTo.SelectAll()
                Exit Sub
            End If

            rs_IMITMDAT.Tables("RESULT").Columns("iid_ftytmp").ReadOnly = False
            For i = (txtApplyReasonFrom.Text - 1) To (txtApplyReasonTo.Text - 1)
                If radTmpYes.Checked = True Then
                    rs_IMITMDAT.Tables("RESULT").Rows(i)("iid_ftytmp") = "Y"
                ElseIf radTmpNo.Checked = True Then
                    rs_IMITMDAT.Tables("RESULT").Rows(i)("iid_ftytmp") = "N"
                End If
            Next
            rs_IMITMDAT.Tables("RESULT").Columns("iid_ftytmp").ReadOnly = True
        End If
    End Sub

End Class
