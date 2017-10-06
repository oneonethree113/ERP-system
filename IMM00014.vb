Public Class IMM00014

    Private recordStatus As Boolean = False
    Private saveOK As Boolean
    Private isSave As Boolean

    Dim rs_IMPCITMDAT As DataSet
    Dim rs_IMPCITMDAT_dtl As DataSet
    Dim dv_listing As DataView
    Dim selected_no As Integer
    Dim enq_right_local As Boolean
    Dim del_right_local As Boolean

    Private Sub IMM00014_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)

        Call AccessRight(Me.Name)
        enq_right_local = Enq_right
        enq_right_local = True      '**********************REMOVE AFTER TESTING
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
        If txtDateFrom.Text <> "" And txtDateTo.TextLength = 0 Then
            txtDateTo.Text = txtDateFrom.Text
        End If
        If txtLineFrom.Text <> "" And txtLineTo.TextLength = 0 Then
            txtLineTo.Text = txtLineFrom.Text
        End If

        Dim itmsts As String = ""
        Dim Mode As String = ""

        If (Not chkComplete.Checked And Not chkIncomplete.Checked) Or _
            (chkComplete.Checked And chkIncomplete.Checked) Then
            itmsts = ""
        ElseIf chkComplete.Checked = True And chkIncomplete.Checked = False Then
            itmsts = "CMP"
        ElseIf chkComplete.Checked = False And chkIncomplete.Checked = True Then
            itmsts = "INC"
        End If

        If (chkNew.Checked = False And chkUpdate.Checked = False) Then
            Mode = ""
        ElseIf chkNew.Checked = True And chkUpdate.Checked = False Then
            Mode = "NEW"
        ElseIf chkNew.Checked = False And chkUpdate.Checked = True Then
            Mode = "UPD"
        ElseIf chkNew.Checked = True And chkUpdate.Checked = False Then
            Mode = "ALL"
        End If

        If chkComplete.Checked = False And chkIncomplete.Checked = False Then
            chkComplete.Checked = True
            chkIncomplete.Checked = True
        End If

        If chkNew.Checked = False And chkUpdate.Checked = False Then
            chkNew.Checked = True
            chkUpdate.Checked = True
        End If

        If chkApprove.Checked = False And chkReject.Checked = False And chkWait.Checked = False Then
            chkApprove.Checked = True
            chkReject.Checked = True
            chkWait.Checked = True
        End If

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        gspStr = "sp_update_IMPCITMDAT_refresh '','" & gsUsrID & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_IMPCITMDAT, rtnStr)

        gspStr = "sp_select_IMPCITMDAT 'UCPP','" & itmsts & "','" & Mode & "','" & txtDateFrom.Text & _
         "','" & txtDateTo.Text & "','" & txtLineFrom.Text & "','" & txtLineTo.Text & _
         "','" & txtVenItm.Text & "','" & Int(chkApprove.Checked).ToString & _
         "','" & Int(chkReject.Checked).ToString & "','" & Int(chkWait.Checked).ToString & _
         "','" & gsUsrID & "'"

        rtnLong = execute_SQLStatement(gspStr, rs_IMPCITMDAT, rtnStr)

        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMM00014 sp_select_IMPCITMDAT : " & rtnStr)
            Exit Sub
        End If
        If rs_IMPCITMDAT.Tables("RESULT").Rows.Count = 0 Then
            setStatus("Init")
            MsgBox("No Records Found", MsgBoxStyle.Information, "Information")
        Else
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            setStatus("Updating")
            txtApplyFrom.Text = "1"
            txtApplyTo.Text = rs_IMPCITMDAT.Tables("RESULT").Rows.Count
            fillCount()
            DisplaySummary()
            Enable_IAR00001()
            tabFrame.SelectTab(0)
            Dim n As Integer = 0
            n = rs_IMPCITMDAT.Tables("RESULT").Rows.Count / 10
            If (rs_IMPCITMDAT.Tables("RESULT").Rows.Count Mod 10) > 0 Then
                n += 1
            End If
            txtApplyFrom.MaxLength = n
            txtApplyTo.MaxLength = n
            Me.Cursor = Windows.Forms.Cursors.Default
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim IsUpdated As Boolean = False
        Dim rs_update, rs_temp As New DataSet

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        isSave = True

        If recordStatus = True Then
            For i As Integer = 0 To rs_IMPCITMDAT.Tables("RESULT").Rows.Count - 1
                If Not (rs_IMPCITMDAT.Tables("RESULT").Rows(i)("ipd_stage") = rs_IMPCITMDAT.Tables("RESULT").Rows(i)("old_stage")) Then
                    If Not checkTimeStamp(i) Then
                        MsgBox("The record has been modified by other users. Please refresh and try again.", MsgBoxStyle.Exclamation, "Overwrite Warning")
                        Me.Cursor = Windows.Forms.Cursors.Default
                        saveOK = False
                        isSave = False
                        Exit Sub
                    Else
                        gspStr = "sp_update_IMPCITMDAT 'UCPP','" & rs_IMPCITMDAT.Tables("RESULT").Rows(i)("ipd_venitm") & _
                                 "','" & rs_IMPCITMDAT.Tables("RESULT").Rows(i)("ipd_itmseq") & _
                                 "','" & rs_IMPCITMDAT.Tables("RESULT").Rows(i)("ipd_recseq") & _
                                 "','" & rs_IMPCITMDAT.Tables("RESULT").Rows(i)("ipd_stage") & _
                                 "','" & gsUsrID & "'"
                        rtnLong = execute_SQLStatement(gspStr, rs_update, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading IMM00014 sp_update_IMPCITMDAT : " & rtnStr)
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
            ' need update here
            If chkConfirmUpload.Checked = True Then
                ' **** UPDATE TO ITEM MASTER ****
                gspStr = "sp_update_IMPCUPDDAT 'UCPP','" & gsUsrID & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_temp, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading IMM00014 sp_update_IMPCUPDDAT : " & rtnStr)
                End If

                gspStr = "sp_insert_IMPCINSDAT 'UCPP','" & gsUsrID & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_temp, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading IMM00014 sp_insert_IMPCINSDAT : " & rtnStr)
                End If

                'gspStr = "sp_update_IMPCINDDAT 'UCPP','" & gsUsrID & "'"
                'rtnLong = execute_SQLStatement(gspStr, rs_temp, rtnStr)
                'If rtnLong <> RC_SUCCESS Then
                '    MsgBox("Error on loading IMM00014 sp_update_IMPCINDDAT : " & rtnStr)
                'End If
            End If

        End If

        Call setStatus("Save")
        isSave = False

        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub cmdApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApply.Click
        If Val(txtApplyFrom.Text) = "0" Then
            MsgBox("The apply range cannot be 0", MsgBoxStyle.Exclamation, "Invalid Parameters")
            txtApplyFrom.SelectAll()
            Exit Sub
        End If

        If Val(txtApplyTo.Text) > rs_IMPCITMDAT.Tables("RESULT").Rows.Count Then
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
        rs_IMPCITMDAT.Tables("RESULT").Columns(1).ReadOnly = False
        For i As Integer = (txtApplyFrom.Text - 1) To (txtApplyTo.Text - 1)
            If (optApproval.Checked = True) Then
                rs_IMPCITMDAT.Tables("RESULT").Rows(i)(1) = "A"
                approveReject(i)
            ElseIf (optRejection.Checked = True) Then
                rs_IMPCITMDAT.Tables("RESULT").Rows(i)(1) = "R"
                approveReject(i)
            ElseIf (optWait.Checked = True) Then
                rs_IMPCITMDAT.Tables("RESULT").Rows(i)(1) = "W"
            End If
        Next
        rs_IMPCITMDAT.Tables("RESULT").Columns(1).ReadOnly = True

        'Update Checkbox DTL
        refreshTab()
        recordStatus = True
    End Sub

    Private Sub approveReject(ByVal index As Integer)
        'Dim rs_IMPCITMDAT_ASS As New DataSet
        'Dim rs_IMPCITMDAT_REG As New DataSet
        'Dim asked As Boolean
        'Dim ans As Boolean
        'Dim question As Integer
        'Dim tempRow() As DataRow

        'asked = False

        'If rs_IMPCITMDAT.Tables("RESULT").Rows(index)("iid_stage") = "R" Then
        '    chkApprove_dtl.Checked = False
        '    chkReject_dtl.Checked = True
        '    chkWait_dtl.Checked = False
        '    chkApprove.Checked = False
        '    chkReject.Checked = True
        '    chkWait.Checked = False

        '    If rs_IMPCITMDAT.Tables("RESULT").Rows(index)("iid_itmtyp") = "ASS" Then
        '        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        '        gspStr = "sp_select_IMPCITMDAT_ASS '" & "UCPP" & _
        '                 "','" & rs_IMPCITMDAT.Tables("RESULT").Rows(index)("iid_venitm") & _
        '                 "','" & rs_IMPCITMDAT.Tables("RESULT").Rows(index)("iid_chkdat") & _
        '                 "','" & rs_IMPCITMDAT.Tables("RESULT").Rows(index)("iid_xlsfil") & _
        '                 "','" & gsUsrID & "'"
        '        rtnLong = execute_SQLStatement(gspStr, rs_IMPCITMDAT_ASS, rtnStr)

        '        Me.Cursor = Windows.Forms.Cursors.Default

        '        If rtnLong <> RC_SUCCESS Then
        '            MsgBox("Error on loading IMM00002 sp_select_IMITMDAT_ASS : " & rtnStr)
        '            Exit Sub
        '        End If

        '        '    If rs_IMPCITMDAT_ASS.Tables("RESULT").Rows.Count > 0 Then
        '        '        For j As Integer = 0 To rs_IMPCITMDAT_ASS.Tables("RESULT").Rows.Count - 1
        '        '            If Not rs_IMPCITMDAT.Tables("RESULT").Select("iid_venitm = " & "'" & rs_IMPCITMDAT_ASS.Tables("RESULT").Rows(j)("iad_acsno") & "'") Is Nothing And asked = False Then
        '        '                question = MsgBox("You must approve the related Assorted Item together. Confirm to approve the Assorted Item", MsgBoxStyle.YesNo, "Rejection Confirmation")
        '        '                If question = 6 Then
        '        '                    ans = True
        '        '                    asked = True
        '        '                Else
        '        '                    ans = False
        '        '                    asked = True
        '        '                End If
        '        '            End If

        '        '            tempRow = rs_IMPCITMDAT.Tables("RESULT").Select("iid_venitm = " & "'" & rs_IMPCITMDAT_ASS.Tables("RESULT").Rows(j)("iad_acsno") & "'")

        '        '            If tempRow.Length > 0 Then
        '        '                If ans = True Then
        '        '                    rs_IMPCITMDAT.Tables("RESULT").Columns(1).ReadOnly = False
        '        '                    'rs_IMPCITMDAT.Tables("RESULT").Rows(tempRow.Items("no") - 1)(1) = "R"
        '        '                    rs_IMPCITMDAT.Tables("RESULT").Columns(1).ReadOnly = True
        '        '                End If
        '        '            End If

        '        '        Next
        '        '    End If
        '    End If

        '    If rs_IMPCITMDAT.Tables("RESULT").Rows(index)("iid_itmtyp") = "REG" Then
        '        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        '        gspStr = "sp_select_IMPCITMDAT_REG '" & "UCPP" & _
        '                 "','" & rs_IMPCITMDAT.Tables("RESULT").Rows(index)("iid_venitm") & _
        '                 "','" & rs_IMPCITMDAT.Tables("RESULT").Rows(index)("iid_chkdat") & _
        '                 "','" & rs_IMPCITMDAT.Tables("RESULT").Rows(index)("iid_xlsfil") & _
        '                 "','" & gsUsrID & "'"

        '        rtnLong = execute_SQLStatement(gspStr, rs_IMPCITMDAT_REG, rtnStr)

        '        Me.Cursor = Windows.Forms.Cursors.Default

        '        If rtnLong <> RC_SUCCESS Then
        '            MsgBox("Error on loading IMM00014 sp_select_IMPCITMDAT_REG : " & rtnStr)
        '            Exit Sub
        '        End If

        '        If rs_IMPCITMDAT_REG.Tables("RESULT").Rows.Count > 0 Then
        '            For j As Integer = 0 To rs_IMPCITMDAT_REG.Tables("RESULT").Rows.Count - 1
        '                If Not rs_IMPCITMDAT.Tables("RESULT").Select("iid_venitm = " & "'" & rs_IMPCITMDAT_REG.Tables("RESULT").Rows(j)("iad_venitm") & "'") Is Nothing And asked = False Then
        '                    question = MsgBox("Its assortment Item will be rejected.", MsgBoxStyle.YesNo, "Rejection Confirmation")
        '                    If question = 6 Then 'Yes
        '                        ans = True
        '                        asked = True
        '                    Else
        '                        ans = False
        '                        asked = True
        '                    End If
        '                End If
        '            Next
        '        End If
        '    End If
        'End If


        ''Dim tmp_BK As Integer
        ''Dim rs() As ADOR.Recordset
        ''Dim S As String
        ''Dim ans As Boolean
        ''Dim asked As Boolean
        ''Dim norecord As Boolean

        ''If rs_IMPCITMDAT("iid_stage") = "R" Then

        ''    chkReject_dtl.Value = 1
        ''    chkApprove_dtl.Value = 0
        ''    chkWait_dtl.Value = 0
        ''    chkApprove.Value = 0
        ''    chkReject.Value = 1
        ''    chkWait.Value = 0

        ''    If rs_IMPCITMDAT("iid_itmtyp") = "ASS" Then

        ''        Screen.MousePointer = vbHourglass

        ''        S = "㊣IMITMDAT_ASS※S※" & rs_IMPCITMDAT("iid_venitm") & "※" & rs_IMPCITMDAT("iid_chkdat") & "※" & _
        ''             rs_IMPCITMDAT("iid_xlsfil") & "※" & gsUsrID

        ''        rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        ''        Screen.MousePointer = vbDefault

        ''        If rs(0)(0) <> "0" Then  '*** An error has occured
        ''            MsgBox(rs(0)(0))
        ''        Else

        ''            rs_IMPCITMDAT_ASS = rs(1)

        ''            If rs_IMPCITMDAT_ASS.recordCount > 0 Then
        ''                tmp_BK = rs_IMPCITMDAT.AbsolutePosition

        ''                rs_IMPCITMDAT_ASS.MoveFirst()
        ''                While Not rs_IMPCITMDAT_ASS.EOF
        ''                    rs_IMPCITMDAT.MoveFirst()
        ''                    rs_IMPCITMDAT.Find("iid_venitm = " & "'" & rs_IMPCITMDAT_ASS("iad_acsno") & "'")

        ''                    If Not rs_IMPCITMDAT.EOF And asked = False Then
        ''                        If msg("M00436") = vbYes Then
        ''                            ans = True
        ''                            asked = True
        ''                        Else
        ''                            ans = False
        ''                            asked = True
        ''                        End If
        ''                    End If

        ''                    rs_IMPCITMDAT.MoveFirst()
        ''                    rs_IMPCITMDAT.Find("iid_venitm = " & "'" & rs_IMPCITMDAT_ASS("iad_acsno") & "'")

        ''                    If Not rs_IMPCITMDAT.EOF Then

        ''                        If ans = True Then
        ''                            rs_IMPCITMDAT("iid_stage").Value = "R"
        ''                        End If

        ''                    End If

        ''                    rs_IMPCITMDAT_ASS.MoveNext()
        ''                End While
        ''                rs_IMPCITMDAT.MoveFirst()
        ''                rs_IMPCITMDAT.Move(tmp_BK - 1)
        ''            End If

        ''        End If

        ''    End If

        ''    Dim assort As String

        ''    If rs_IMPCITMDAT("iid_itmtyp") = "REG" Then

        ''        Screen.MousePointer = vbHourglass

        ''        S = "㊣IMITMDAT_REG※S※" & rs_IMPCITMDAT("iid_venitm") & "※" & rs_IMPCITMDAT("iid_chkdat") & "※" & _
        ''             rs_IMPCITMDAT("iid_xlsfil") & "※" & gsUsrID

        ''        rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        ''        Screen.MousePointer = vbDefault

        ''        If rs(0)(0) <> "0" Then  '*** An error has occured
        ''            MsgBox(rs(0)(0))
        ''        Else

        ''            rs_IMPCITMDAT_REG = rs(1)

        ''            If rs_IMPCITMDAT_REG.recordCount > 0 Then
        ''                tmp_BK = rs_IMPCITMDAT.AbsolutePosition


        ''                rs_IMPCITMDAT_REG.MoveFirst()
        ''                While Not rs_IMPCITMDAT_REG.EOF
        ''                    rs_IMPCITMDAT.MoveFirst()
        ''                    rs_IMPCITMDAT.Find("iid_venitm = " & "'" & rs_IMPCITMDAT_REG("iad_venitm") & "'")

        ''                    If Not rs_IMPCITMDAT.EOF And asked = False Then
        ''                        If msg("M00437") = vbYes Then
        ''                            ans = True
        ''                            asked = True
        ''                        Else
        ''                            ans = False
        ''                            asked = True
        ''                        End If
        ''                    End If

        ''                    rs_IMPCITMDAT.MoveFirst()
        ''                    rs_IMPCITMDAT.Find("iid_venitm = " & "'" & rs_IMPCITMDAT_REG("iad_venitm") & "'")

        ''                    If Not rs_IMPCITMDAT.EOF Then

        ''                        If ans = True Then
        ''                            rs_IMPCITMDAT("iid_stage").Value = "R"
        ''                        End If

        ''                    End If
        ''                    rs_IMPCITMDAT_REG.MoveNext()
        ''                End While
        ''                rs_IMPCITMDAT.MoveFirst()
        ''                rs_IMPCITMDAT.Move(tmp_BK - 1)
        ''                If ans = False Then
        ''                    rs_IMPCITMDAT("iid_stage").Value = "A"
        ''                End If
        ''            End If

        ''        End If

        ''    End If
        ''ElseIf rs_IMPCITMDAT("iid_stage") = "A" Then

        ''    chkReject_dtl.Value = 0
        ''    chkApprove_dtl.Value = 1
        ''    chkWait_dtl.Value = 0
        ''    chkApprove.Value = 1
        ''    chkReject.Value = 0
        ''    chkWait.Value = 0

        ''    If rs_IMPCITMDAT("iid_itmtyp") = "ASS" Then

        ''        Screen.MousePointer = vbHourglass

        ''        S = "㊣IMITMDAT_ASS※S※" & rs_IMPCITMDAT("iid_venitm") & "※" & rs_IMPCITMDAT("iid_chkdat") & "※" & _
        ''             rs_IMPCITMDAT("iid_xlsfil") & "※" & gsUsrID

        ''        rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        ''        Screen.MousePointer = vbDefault

        ''        If rs(0)(0) <> "0" Then  '*** An error has occured
        ''            MsgBox(rs(0)(0))
        ''        Else

        ''            rs_IMPCITMDAT_ASS = rs(1)

        ''            If rs_IMPCITMDAT_ASS.recordCount > 0 Then
        ''                tmp_BK = rs_IMPCITMDAT.AbsolutePosition

        ''                rs_IMPCITMDAT_ASS.MoveFirst()
        ''                While Not rs_IMPCITMDAT_ASS.EOF
        ''                    rs_IMPCITMDAT.MoveFirst()
        ''                    rs_IMPCITMDAT.Find("iid_venitm = " & "'" & rs_IMPCITMDAT_ASS("iad_acsno") & "'")

        ''                    If Not rs_IMPCITMDAT.EOF And asked = False Then
        ''                        If msg("M00435") = vbYes Then
        ''                            ans = True
        ''                            asked = True
        ''                        Else
        ''                            ans = False
        ''                            asked = True
        ''                        End If
        ''                    End If

        ''                    rs_IMPCITMDAT.MoveFirst()
        ''                    rs_IMPCITMDAT.Find("iid_venitm = " & "'" & rs_IMPCITMDAT_ASS("iad_acsno") & "'")

        ''                    If Not rs_IMPCITMDAT.EOF Then
        ''                        asked = True
        ''                        If ans = True Then
        ''                            rs_IMPCITMDAT("iid_stage").Value = "A"
        ''                        End If
        ''                    Else
        ''                        If norecord = False Then
        ''                            norecord = True
        ''                        End If
        ''                    End If

        ''                    rs_IMPCITMDAT_ASS.MoveNext()
        ''                End While
        ''                rs_IMPCITMDAT.MoveFirst()
        ''                rs_IMPCITMDAT.Move(tmp_BK - 1)
        ''                If ans = False And norecord = False Then
        ''                    rs_IMPCITMDAT("iid_stage").Value = "W"
        ''                ElseIf norecord = True Then
        ''                    rs_IMPCITMDAT("iid_stage").Value = "A"
        ''                End If
        ''            End If

        ''        End If

        ''    End If

        ''End If
        ''Recordstatus = True

    End Sub

    Private Sub fillCount()
        rs_IMPCITMDAT.Tables("RESULT").Columns("no").ReadOnly = False
        For i As Integer = 0 To rs_IMPCITMDAT.Tables("RESULT").Rows.Count - 1
            rs_IMPCITMDAT.Tables("RESULT").Rows(i)("no") = i + 1
        Next
        rs_IMPCITMDAT.Tables("RESULT").Columns("no").ReadOnly = True

    End Sub

    Private Sub DisplaySummary()

        dv_listing = rs_IMPCITMDAT.Tables("RESULT").DefaultView

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
                        .Columns(i).HeaderText = "Vendor Item"
                        .Columns(i).Width = 100
                        .Columns(i).ReadOnly = True
                    Case 4
                        .Columns(i).HeaderText = "Item No."
                        .Columns(i).Width = 100
                        .Columns(i).ReadOnly = True
                    Case 5
                        .Columns(i).HeaderText = "Pri Cus"
                        .Columns(i).Width = 65
                        .Columns(i).ReadOnly = True
                    Case 6
                        .Columns(i).HeaderText = "Sec Cus"
                        .Columns(i).Width = 65
                        .Columns(i).ReadOnly = True
                    Case 7
                        .Columns(i).HeaderText = "Type"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case 8
                        .Columns(i).HeaderText = "Mode"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case 9
                        .Columns(i).HeaderText = "English Desc."
                        .Columns(i).Width = 110
                        .Columns(i).ReadOnly = True
                    Case 10
                        .Columns(i).HeaderText = "Packing Instruction"
                        .Columns(i).Width = 110
                        .Columns(i).ReadOnly = True
                    Case 11
                        .Columns(i).HeaderText = "UM"
                        .Columns(i).Width = 45
                        .Columns(i).ReadOnly = True
                    Case 12
                        .Columns(i).HeaderText = "Inner Qty"
                        .Columns(i).Width = 60
                        .Columns(i).ReadOnly = True
                    Case 13
                        .Columns(i).HeaderText = "Master Qty"
                        .Columns(i).Width = 65
                        .Columns(i).ReadOnly = True
                    Case 14
                        .Columns(i).HeaderText = "CFT"
                        .Columns(i).Width = 60
                        .Columns(i).ReadOnly = True
                    Case 15
                        .Columns(i).HeaderText = "C. Factor"
                        .Columns(i).Width = 50
                        .Columns(i).ReadOnly = True
                    Case 16
                        .Columns(i).HeaderText = "CCY"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case 17
                        .Columns(i).HeaderText = "FTY Cost"
                        .Columns(i).Width = 60
                        .Columns(i).ReadOnly = True
                    Case 18
                        .Columns(i).HeaderText = "Price Term"
                        .Columns(i).Width = 55
                        .Columns(i).ReadOnly = True
                    Case 19
                        .Columns(i).HeaderText = "Transport Term"
                        .Columns(i).Width = 55
                        .Columns(i).ReadOnly = True
                    Case 20
                        .Columns(i).HeaderText = "Date"
                        .Columns(i).Width = 60
                        .Columns(i).ReadOnly = True
                    Case 21
                        .Columns(i).HeaderText = "Status"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case 22
                        .Columns(i).HeaderText = "Prod. Line"
                        .Columns(i).Width = 60
                        .Columns(i).ReadOnly = True
                    Case 23
                        .Columns(i).HeaderText = "Category 4"
                        .Columns(i).Width = 75
                        .Columns(i).ReadOnly = True
                    Case 26
                        .Columns(i).HeaderText = "Period"
                        .Columns(i).Width = 60
                        .Columns(i).ReadOnly = True
                    Case 35
                        .Columns(i).HeaderText = "Cost Expiry Date"
                        .Columns(i).Width = 75
                        .Columns(i).ReadOnly = True
                    Case Else
                        .Columns(i).Visible = False
                End Select
                '.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next i
        End With

        selected_no = 0

        StatusBar.Items("lblRight").Text = "Created: " & rs_IMPCITMDAT.Tables("RESULT").Rows(selected_no)("ipd_credat") & " " & _
                                           "Updated: " & Format(rs_IMPCITMDAT.Tables("RESULT").Rows(selected_no)("ipd_upddat"), "MM/dd/yyyy") & " " & _
                                           "by " & rs_IMPCITMDAT.Tables("RESULT").Rows(selected_no)("ipd_updusr")
        refreshTab()
    End Sub

    Private Sub refreshTab()
        If tabFrame.SelectedIndex = 1 Then
            If Not rs_IMPCITMDAT Is Nothing Then
                If rs_IMPCITMDAT.Tables("RESULT").Rows.Count <= 1 Then
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
                    ElseIf selected_no = (rs_IMPCITMDAT.Tables("RESULT").Rows.Count - 1) Then
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
                If Not rs_IMPCITMDAT Is Nothing Then
                    txtVenItm_dtl.Text = rs_IMPCITMDAT.Tables("RESULT").Rows(selected_no)("ipd_venitm")

                    If rs_IMPCITMDAT.Tables("RESULT").Rows(selected_no)("ipd_stage") = "A" Then
                        chkApprove_dtl.Checked = True
                        chkReject_dtl.Checked = False
                        chkWait_dtl.Checked = False
                    ElseIf rs_IMPCITMDAT.Tables("RESULT").Rows(selected_no)("ipd_stage") = "R" Then
                        chkApprove_dtl.Checked = False
                        chkReject_dtl.Checked = True
                        chkWait_dtl.Checked = False
                    ElseIf rs_IMPCITMDAT.Tables("RESULT").Rows(selected_no)("ipd_stage") = "W" Then
                        chkApprove_dtl.Checked = False
                        chkReject_dtl.Checked = False
                        chkWait_dtl.Checked = True
                    End If

                    txtUM_dtl.Text = rs_IMPCITMDAT.Tables("RESULT").Rows(selected_no)("ipd_untcde")
                    txtInrQty_dtl.Text = rs_IMPCITMDAT.Tables("RESULT").Rows(selected_no)("ipd_inrqty")
                    txtMtrQty_dtl.Text = rs_IMPCITMDAT.Tables("RESULT").Rows(selected_no)("ipd_mtrqty")
                    'txtDesVenNo_dtl.Text = rs_IMPCITMDAT.Tables("RESULT").Rows(selected_no)("iid_venno")
                    'txtPrdVenNo_dtl.Text = rs_IMPCITMDAT.Tables("RESULT").Rows(selected_no)("iid_prdven")
                    txtUpdDate_dtl.Text = rs_IMPCITMDAT.Tables("RESULT").Rows(selected_no)("ipd_credat")
                    txtEngDesc_dtl.Text = rs_IMPCITMDAT.Tables("RESULT").Rows(selected_no)("ipd_engdsc")
                    'txtCusVenNo_dtl.Text = rs_IMPCITMDAT.Tables("RESULT").Rows(selected_no)("iid_cusven")

                    StatusBar.Items("lblRight").Text = "Created: " & rs_IMPCITMDAT.Tables("RESULT").Rows(selected_no)("ipd_credat") & " " & _
                                                       "Updated: " & Format(rs_IMPCITMDAT.Tables("RESULT").Rows(selected_no)("ipd_upddat"), "MM/dd/yyyy") & " " & _
                                                       "by " & rs_IMPCITMDAT.Tables("RESULT").Rows(selected_no)("ipd_updusr")
                    find_Detail()
                End If
            End If
        Else
            If selected_no <> -1 Then
                grdSummary.CurrentCell = grdSummary.Rows(selected_no).Cells(0)
                grdSummary.ClearSelection()
            End If
        End If
    End Sub

    Private Sub find_Detail()
        If rs_IMPCITMDAT.Tables("RESULT").Rows(selected_no)("ipd_mode") = "UPD" Then
            gspStr = "sp_select_IMPCITMDAT_dtl '" & "" & _
                     "','" & rs_IMPCITMDAT.Tables("RESULT").Rows(selected_no)("ipd_venitm") & _
                     "','" & rs_IMPCITMDAT.Tables("RESULT").Rows(selected_no)("ipd_untcde") & _
                     "','" & rs_IMPCITMDAT.Tables("RESULT").Rows(selected_no)("ipd_inrqty") & _
                     "','" & rs_IMPCITMDAT.Tables("RESULT").Rows(selected_no)("ipd_mtrqty") & _
                     "','" & rs_IMPCITMDAT.Tables("RESULT").Rows(selected_no)("ipd_itmseq") & _
                     "','" & rs_IMPCITMDAT.Tables("RESULT").Rows(selected_no)("ipd_recseq") & "'"

            rtnLong = execute_SQLStatement(gspStr, rs_IMPCITMDAT_dtl, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading IMM00014 sp_select_IMPCITMDAT_dtl : " & rtnStr)
                Exit Sub
            End If
            If rs_IMPCITMDAT_dtl.Tables("RESULT").Rows.Count > 0 Then
                displayDetail()
            Else
                MsgBox("No Record History Found", MsgBoxStyle.Information, "Information")
            End If
        End If
    End Sub

    Private Sub displayDetail()
        Dim dv As DataView = rs_IMPCITMDAT_dtl.Tables("RESULT").DefaultView

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
        If Not rs_IMPCITMDAT Is Nothing Then
            If (selected_no > 0) Then
                selected_no = 0
            End If
        End If
        refreshTab()
    End Sub

    Private Sub cmdPrev_dtl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrev_dtl.Click
        If Not rs_IMPCITMDAT Is Nothing Then
            If (selected_no > 0) Then
                selected_no = selected_no - 1
            End If
        End If
        refreshTab()
    End Sub

    Private Sub cmdNext_dtl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext_dtl.Click
        If Not rs_IMPCITMDAT Is Nothing Then
            If (selected_no < Val(dv_listing.Count - 1)) Then
                selected_no = selected_no + 1
            End If
        End If
        refreshTab()
    End Sub

    Private Sub cmdLast_dtl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLast_dtl.Click
        If Not rs_IMPCITMDAT Is Nothing Then
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
                rs_IMPCITMDAT.Tables("RESULT").Columns(1).ReadOnly = False
                rs_IMPCITMDAT.Tables("RESULT").Rows(selected_no)("ipd_stage") = "A"
                rs_IMPCITMDAT.Tables("RESULT").Columns(1).ReadOnly = True
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
                rs_IMPCITMDAT.Tables("RESULT").Columns(1).ReadOnly = False
                rs_IMPCITMDAT.Tables("RESULT").Rows(selected_no)("ipd_stage") = "R"
                rs_IMPCITMDAT.Tables("RESULT").Columns(1).ReadOnly = True
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
                rs_IMPCITMDAT.Tables("RESULT").Columns(1).ReadOnly = False
                rs_IMPCITMDAT.Tables("RESULT").Rows(selected_no)("ipd_stage") = "W"
                rs_IMPCITMDAT.Tables("RESULT").Columns(1).ReadOnly = True
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
                rs_IMPCITMDAT.Tables("RESULT").Columns(1).ReadOnly = False
                If (rs_IMPCITMDAT.Tables("RESULT").Rows(grdSummary.SelectedCells.Item(0).RowIndex)(1) = "W") Then
                    rs_IMPCITMDAT.Tables("RESULT").Rows(grdSummary.SelectedCells.Item(0).RowIndex)(1) = "A"
                    updateRecordStatusChkBox("A")
                ElseIf (rs_IMPCITMDAT.Tables("RESULT").Rows(grdSummary.SelectedCells.Item(0).RowIndex)(1) = "A") Then
                    rs_IMPCITMDAT.Tables("RESULT").Rows(grdSummary.SelectedCells.Item(0).RowIndex)(1) = "R"
                    updateRecordStatusChkBox("R")
                ElseIf (rs_IMPCITMDAT.Tables("RESULT").Rows(grdSummary.SelectedCells.Item(0).RowIndex)(1) = "R") Then
                    rs_IMPCITMDAT.Tables("RESULT").Rows(grdSummary.SelectedCells.Item(0).RowIndex)(1) = "W"
                    updateRecordStatusChkBox("W")
                End If
                rs_IMPCITMDAT.Tables("RESULT").Columns(1).ReadOnly = True
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

    Private Sub tabFrame_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabFrame.SelectedIndexChanged
        refreshTab()
    End Sub

    Private Sub Enable_IAR00001()

        'If ERP00000.mnuIAR00001.Enabled = False Then
        'cmdIAR00001.Enabled = False
        'Else
        'cmdIAR00001.Enabled = True
        'End If
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
            cmdInsRow.Enabled = False
            cmdDelRow.Enabled = False
            cmdFirst.Enabled = False
            cmdLast.Enabled = False
            cmdNext.Enabled = False
            cmdPrevious.Enabled = False

            cmdExit.Enabled = True

            txtVenItm.Enabled = True
            txtVenItm.Text = ""
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
            chkNew.Enabled = True
            chkNew.Checked = 0
            chkUpdate.Enabled = True
            chkUpdate.Checked = 0
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
            cmdAssort.Enabled = False

            cmdPrintList.Enabled = False
            cmdIAR00001.Enabled = False
            cmdIMR00021.Enabled = False
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

            selected_no = -1

            resetDefaultDisp()
            SetStatusBar(Mode)

            '***Reset the flag
            recordStatus = False
        ElseIf Mode = "Updating" Then
            cmdAdd.Enabled = False
            cmdSave.Enabled = enq_right_local
            cmdDelete.Enabled = False
            cmdCopy.Enabled = False
            cmdFind.Enabled = False
            cmdClear.Enabled = True

            cmdInsRow.Enabled = False
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
            txtLineFrom.Enabled = False
            txtLineTo.Enabled = False
            txtVenItm.Enabled = False
            chkComplete.Enabled = False
            chkIncomplete.Enabled = False
            chkNew.Enabled = False
            chkUpdate.Enabled = False
            chkApprove.Enabled = False
            chkReject.Enabled = False
            chkWait.Enabled = False
            chkApprove_dtl.Enabled = True
            chkReject_dtl.Enabled = True
            chkWait_dtl.Enabled = True
            grdSummary.Enabled = True
            grdDetail.Enabled = True

            '***Reset the flag
            recordStatus = False

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
            rs_IMPCITMDAT = Nothing
            rs_IMPCITMDAT_dtl = Nothing
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

    Private Function checkTimeStamp(ByVal index As Integer) As Boolean

        Dim rs_time As New DataSet
        Dim save_timestamp As Long

        gspStr = "sp_select_IMPCITMDAT_timstp '" & "" & _
                 "','" & rs_IMPCITMDAT.Tables("RESULT").Rows(index)("ipd_venitm") & _
                 "','" & rs_IMPCITMDAT.Tables("RESULT").Rows(index)("ipd_itmseq") & _
                 "','" & rs_IMPCITMDAT.Tables("RESULT").Rows(index)("ipd_recseq") & "'"

        rtnLong = execute_SQLStatement(gspStr, rs_time, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading IMM00014 sp_select_IMPCITMDAT_timstp : " & rtnStr)
            Exit Function
        End If

        If rs_time.Tables("RESULT").Rows.Count > 0 Then
            save_timestamp = rs_time.Tables("RESULT").Rows(0)("ipd_timstp")
        Else
            save_timestamp = 9999
        End If

        If rs_IMPCITMDAT.Tables("RESULT").Rows(index)("ipd_timstp") <> save_timestamp Then
            Return False
        Else
            Return True
        End If
    End Function

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
End Class