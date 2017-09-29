Public Class SCM00006

    Dim Del_right_local As Boolean
    Dim Enq_right_local As Boolean

    Dim rs_SCM00006DTL As DataSet
    Dim rs_SCM00006HDR As DataSet
    Dim rs_SCM00006DTL_ori As DataSet
    Dim rs_SCM00006HDR_ori As DataSet
    Dim rs_SCM00006DTL_select As DataSet
    Dim rs_SCM00006HDR_select As DataSet
    Dim rs_SYMUSRCO As DataSet

    Dim HdrApvSeq As Integer
    Dim HdrPrcTrmApvSeq As Integer
    Dim HdrPayTrmApvSeq As Integer
    Dim HdrRepOrdApvSeq As Integer
    Dim HdrCloOrdApvSeq As Integer
    Dim HdrApvCheckSeq As Integer
    Dim HdrApvMsgSeq As Integer

    Dim HdrApvSelAllSeq As Integer
    Dim HdrPrcTrmApvSelAllSeq As Integer
    Dim HdrPayTrmApvSelAllSeq As Integer
    Dim HdrRepOrdApvSelAllSeq As Integer
    Dim HdrCloOrdApvSelAllSeq As Integer
    Dim HdrKeepSelectSeq As Integer

    Dim DtlApvSeq As Integer
    Dim DtlMOQApvSeq As Integer
    Dim DtlMinMUApvSeq As Integer
    Dim DtlChgFtyCstApvSeq As Integer
    Dim DtlOneTimeApvSeq As Integer
    Dim DtlApvCheckSeq As Integer
    Dim DtlApvMsgSeq As Integer
    Dim DtlChgUntPrcApvSeq As Integer

    Dim DtlApvSelAllSeq As Integer
    Dim DtlMOQApvSelAllSeq As Integer
    Dim DtlMinMUApvSelAllSeq As Integer
    Dim DtlChgFtyCstApvSelAllSeq As Integer
    Dim DtlOneTimeApvSelAllSeq As Integer
    Dim DtlChgUntPrcApvSelAllSeq As Integer
    Dim DtlKeepSelectSeq As Integer


    Private Sub SCM00006_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)
        AccessRight(Me.Name)
        Enq_right_local = Enq_right
        Del_right_local = Del_right

        setStatus("INIT")


    End Sub

    Private Sub SCM00006_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.Alt = True Then
            Select Case e.KeyValue
                Case 1
                    tabFrame.SelectedTab = tabFrame_Search
                Case 2
                    tabFrame.SelectedTab = tabFrame_Header
                Case 3
                    tabFrame.SelectedTab = tabFrame_Detail
                Case Else
                    Exit Sub
            End Select
        End If
    End Sub

    Private Sub SCM00006_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Dim response As Integer

        'If checkChangesMade() = True Then
        '    response = MsgBox("Do you want to save the changes made?", MsgBoxStyle.YesNoCancel, "SCM00006 - Closing")
        '    If response = MsgBoxResult.Yes Then
        '        If cmdSave.Enabled = True Then
        '            cmdSave.PerformClick()
        '        Else
        '            MsgBox("You do not have authority to save changes", MsgBoxStyle.Critical, "SCM00006 - Saving")
        '            e.Cancel = True
        '        End If
        '    ElseIf response = MsgBoxResult.Cancel Then
        '        e.Cancel = True
        '    End If
        'End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim before() As DataRow
        Dim rs_sql As DataSet

        ' Saving Detail
        For i As Integer = 0 To rs_SCM00006DTL.Tables("RESULT").Rows.Count - 1
            before = Nothing
            before = rs_SCM00006DTL_ori.Tables("RESULT").Select("sod_ordno = '" & rs_SCM00006DTL.Tables("RESULT").Rows(i)("sod_ordno") & "' and " & _
                                                                "sod_ordseq = '" & rs_SCM00006DTL.Tables("RESULT").Rows(i)("sod_ordseq") & "'")
            If before.Length > 0 Then
                If checkChangesMade(before(0), rs_SCM00006DTL.Tables("RESULT").Rows(i)) = True Then
                    If checkTimestamp(rs_SCM00006DTL.Tables("RESULT").Rows(i), "DTL") = True Then
                        gspStr = "sp_update_SCM00006_DTL '" & rs_SCM00006DTL.Tables("RESULT").Rows(i)("sod_cocde") & "','" & _
                                 rs_SCM00006DTL.Tables("RESULT").Rows(i)("sod_ordno") & "','" & _
                                 rs_SCM00006DTL.Tables("RESULT").Rows(i)("sod_ordseq") & "','" & _
                                 rs_SCM00006DTL.Tables("RESULT").Rows(i)("action") & "','" & _
                                 rs_SCM00006DTL.Tables("RESULT").Rows(i)("sod_moqmoaflg") & "','" & _
                                 rs_SCM00006DTL.Tables("RESULT").Rows(i)("sod_onetimeflg") & "','" & _
                                 rs_SCM00006DTL.Tables("RESULT").Rows(i)("sod_belprcflg") & "','" & _
                                 rs_SCM00006DTL.Tables("RESULT").Rows(i)("sod_chgftycstflg") & "','" & _
                                 rs_SCM00006DTL.Tables("RESULT").Rows(i)("sod_chguntprcflg") & "','" & _
                                 LCase(gsUsrID) & "'"
                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        rtnLong = execute_SQLStatement(gspStr, rs_sql, rtnStr)
                        Me.Cursor = Windows.Forms.Cursors.Default
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading SCM00006 #004 sp_update_SCM00006_DTL : " & rtnStr)
                            Exit Sub
                        End If
                    Else
                        MsgBox("The record has been modified by other users. Please refresh and try again.", MsgBoxStyle.Exclamation, "SCM00006 - Overwrite Warning (DETAIL)")
                        Exit Sub
                    End If
                End If
            Else
                MsgBox("Missing original detail entry")
                Exit Sub
            End If
        Next

        ' Saving Detail
        For i As Integer = 0 To rs_SCM00006HDR.Tables("RESULT").Rows.Count - 1
            before = Nothing
            before = rs_SCM00006HDR_ori.Tables("RESULT").Select("soh_ordno = '" & rs_SCM00006HDR.Tables("RESULT").Rows(i)("soh_ordno") & "'")

            If before.Length > 0 Then
                If checkChangesMade(before(0), rs_SCM00006HDR.Tables("RESULT").Rows(i)) = True Then
                    If checkTimestamp(rs_SCM00006HDR.Tables("RESULT").Rows(i), "HDR") = True Then
                        gspStr = "sp_update_SCM00006_HDR '" & rs_SCM00006HDR.Tables("RESULT").Rows(i)("soh_cocde") & "','" & _
                                 rs_SCM00006HDR.Tables("RESULT").Rows(i)("soh_ordno") & "','" & _
                                 rs_SCM00006HDR.Tables("RESULT").Rows(i)("action") & "','" & _
                                 rs_SCM00006HDR.Tables("RESULT").Rows(i)("soh_prctrmflg") & "','" & _
                                 rs_SCM00006HDR.Tables("RESULT").Rows(i)("soh_paytrmflg") & "','" & _
                                 rs_SCM00006HDR.Tables("RESULT").Rows(i)("soh_rplflg") & "','" & _
                                 rs_SCM00006HDR.Tables("RESULT").Rows(i)("soh_clsflg") & "','" & _
                                 LCase(gsUsrID) & "'"
                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        rtnLong = execute_SQLStatement(gspStr, rs_sql, rtnStr)
                        Me.Cursor = Windows.Forms.Cursors.Default
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading SCM00006 #005 sp_update_SCM00006_HDR : " & rtnStr)
                            Exit Sub
                        End If
                    Else
                        MsgBox("The record has been modified by other users. Please refresh and try again.", MsgBoxStyle.Exclamation, "SCM00006 - Overwrite Warning (HEADER)")
                        Exit Sub
                    End If
                End If
            End If
        Next

        MsgBox("Save Complete")
        setStatus("INIT")
    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        Dim cocde As String
        Dim cus1no As String
        Dim cus2no As String
        Dim ordno As String
        Dim itmno As String
        Dim rvsdatFm As String
        Dim rvsdatTo As String

        If gsUsrRank > 4 And gsUsrGrp <> "MGT-S" Then
            MsgBox("You do not have the rights to use this feature.", MsgBoxStyle.Critical, "SCM00006 - Access Rights")
            Exit Sub
        End If

        If txt_S_CoCde.Text = "" Then
            MsgBox("Company Code List cannot be empty")
            txt_S_CoCde.Focus()
            Exit Sub
        Else
            If txt_S_CoCde.Text.Length > 1000 Then
                MsgBox("Company Code List is too long (1000 Char)")
                txt_S_CoCde.Focus()
                txt_S_CoCde.SelectAll()
                Exit Sub
            Else
                cocde = Replace(Trim(txt_S_CoCde.Text), "'", "''")
            End If
        End If

        If txt_S_PriCustAll.Text.Length > 1000 Then
            MsgBox("Primary Customer List is too long (1000 Char)")
            txt_S_PriCustAll.Focus()
            txt_S_PriCustAll.SelectAll()
            Exit Sub
        Else
            cus1no = Replace(Trim(txt_S_PriCustAll.Text), "'", "''")
        End If

        If txt_S_SecCustAll.Text.Length > 1000 Then
            MsgBox("Secondary Customer List is too long (1000 Char)")
            txt_S_SecCustAll.Focus()
            txt_S_SecCustAll.SelectAll()
            Exit Sub
        Else
            cus2no = Replace(Trim(txt_S_SecCustAll.Text), "'", "''")
        End If

        If txt_S_SCNo.Text.Length > 1000 Then
            MsgBox("SC No List is too long (1000 Char)")
            txt_S_SCNo.Focus()
            txt_S_SCNo.SelectAll()
            Exit Sub
        Else
            ordno = Replace(Trim(txt_S_SCNo.Text), "'", "''")
        End If

        If txt_S_ItmNo.Text.Length > 1000 Then
            MsgBox("Item No List is too long (1000 Char)")
            txt_S_ItmNo.Focus()
            txt_S_ItmNo.SelectAll()
            Exit Sub
        Else
            itmno = Replace(Trim(txt_S_ItmNo.Text), "'", "''")
        End If

        If txtSCRvsdatFm.Text = "  /  /" Then
            MsgBox("SC Issue Date (From) cannot be empty")
            txtSCRvsdatFm.Focus()
            txtSCRvsdatFm.SelectAll()
            Exit Sub
        Else
            If txtSCRvsdatFm.Text.Length <> 10 Or IsDate(txtSCRvsdatFm.Text) = False Then
                MsgBox("Invalid SC Issue Date (From)")
                txtSCRvsdatFm.Focus()
                txtSCRvsdatFm.SelectAll()
                Exit Sub
            End If
        End If

        If txtSCRvsdatTo.Text = "  /  /" Then
            MsgBox("SC Issue Date (To) cannot be empty")
            txtSCRvsdatTo.Focus()
            txtSCRvsdatTo.SelectAll()
            Exit Sub
        Else
            If txtSCRvsdatTo.Text.Length <> 10 Or IsDate(txtSCRvsdatTo.Text) = False Then
                MsgBox("Invalid SC Issue Date (To)")
                txtSCRvsdatTo.Focus()
                txtSCRvsdatTo.SelectAll()
                Exit Sub
            End If
        End If

        If CDate(txtSCRvsdatFm.Text) > CDate(txtSCRvsdatTo.Text) Then
            MsgBox("SC Issue Date (From) > SC Issue End Date (To)")
            txtSCRvsdatFm.Focus()
            txtSCRvsdatFm.SelectAll()
            Exit Sub
        End If

        rvsdatFm = txtSCRvsdatFm.Text
        rvsdatTo = txtSCRvsdatTo.Text

        gspStr = "sp_select_SCM00006_HDR '','" & cocde & "','" & cus1no & "','" & cus2no & "','" & _
                 ordno & "','" & itmno & "','" & rvsdatFm & "','" & rvsdatTo & "','" & gsUsrID & "'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_SCM00006HDR, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Error on loading SCM00006 #001 sp_select_SCM00006_HDR : " & rtnStr)
            Exit Sub
        Else
            For i As Integer = 0 To rs_SCM00006HDR.Tables("RESULT").Columns.Count - 1
                rs_SCM00006HDR.Tables("RESULT").Columns(i).ReadOnly = False
            Next
            rs_SCM00006HDR_ori = rs_SCM00006HDR.Copy()
        End If

        If rs_SCM00006HDR.Tables("RESULT").Rows.Count = 0 Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("No record found")
            Exit Sub
        End If

        gspStr = "sp_select_SCM00006_DTL '','" & cocde & "','" & cus1no & "','" & cus2no & "','" & _
                 ordno & "','" & itmno & "','" & rvsdatFm & "','" & rvsdatTo & "','" & gsUsrID & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SCM00006DTL, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SCM00006 #002 sp_select_SCM00006_DTL : " & rtnStr)
            Exit Sub
        Else
            For i As Integer = 0 To rs_SCM00006DTL.Tables("RESULT").Columns.Count - 1
                rs_SCM00006DTL.Tables("RESULT").Columns(i).ReadOnly = False
            Next
            rs_SCM00006DTL_ori = rs_SCM00006DTL.Copy()
        End If

        If rs_SCM00006HDR.Tables("RESULT").Rows.Count = 0 And rs_SCM00006DTL.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("No detail record found")
            Exit Sub
        End If

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        setStatus("UPDATE")
        tabFrame.SelectedTab = tabFrame_Header
        display_Header("All")
        tabFrame.SelectedTab = tabFrame_Detail
        display_Detail("All")
        tabFrame.SelectedTab = tabFrame_Header
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        If checkChangesMade() = True Then
            Dim response As Integer
            response = MsgBox("Changes have been made. Would you like to save changes before clearing?", MsgBoxStyle.YesNoCancel)

            If response = MsgBoxResult.Yes Then
                If cmdSave.Enabled = True Then
                    cmdSave.PerformClick()
                    Exit Sub
                Else
                    MsgBox("You do not have authority to save changes", MsgBoxStyle.Critical, "SCM00006 - Saving")
                    Exit Sub
                End If
            ElseIf response = MsgBoxResult.No Then
                setStatus("INIT")
                Exit Sub
            Else
                Exit Sub
            End If
        End If
        setStatus("INIT")
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Close()
    End Sub

    Private Sub cmd_S_CoCde_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_CoCde.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_CoCde.Name
        frmComSearch.callFmString = txt_S_CoCde.Text

        frmComSearch.show_frmS(Me.cmd_S_CoCde)
    End Sub

    Private Sub cmd_S_PriCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_PriCust.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_PriCustAll.Name
        frmComSearch.callFmString = txt_S_PriCustAll.Text

        frmComSearch.show_frmS(Me.cmd_S_PriCust)
    End Sub

    Private Sub cmd_S_SecCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_SecCust.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_SecCustAll.Name
        frmComSearch.callFmString = txt_S_SecCustAll.Text

        frmComSearch.show_frmS(Me.cmd_S_SecCust)
    End Sub

    Private Sub cmd_S_SCNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_SCNo.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_SCNo.Name
        frmComSearch.callFmString = txt_S_SCNo.Text

        frmComSearch.show_frmS(Me.cmd_S_SCNo)
    End Sub

    Private Sub cmd_S_ItmNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_ItmNo.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_ItmNo.Name
        frmComSearch.callFmString = txt_S_ItmNo.Text

        frmComSearch.show_frmS(Me.cmd_S_ItmNo)
    End Sub

    Private Sub cmdHdrSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHdrSelectAll.Click
        dgHeader.SelectAll()
    End Sub

    Private Sub cmdHdrApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHdrApply.Click
        'If dgHeader.SelectedRows.Count = 0 Then
        '    MsgBox("No Rows have been selected", , "SCM00006 - Header")
        '    Exit Sub
        'End If

        'If optHdrAprvN.Checked = False And optHdrAprvW.Checked = False And optHdrAprvY.Checked = False Then
        '    MsgBox("No approval option has been selected", , "SCM00006 - Header")
        '    Exit Sub
        'End If

        'Dim approval As String = "W"
        'If optHdrAprvN.Checked = True Then
        '    approval = "N"
        'ElseIf optHdrAprvW.Checked = True Then
        '    approval = "W"
        'ElseIf optHdrAprvY.Checked = True Then
        '    approval = "Y"
        'End If

        ''Dim detailRows() As DataRow
        'For i As Integer = 0 To dgHeader.SelectedRows.Count - 1
        '    dgHeader.SelectedRows(i).Cells("action").Value = approval
        'Next
    End Sub

    Private Sub cmdDtlSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDtlSelectAll.Click
        dgDetail.SelectAll()
    End Sub

    Private Sub cmdDtlApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDtlApply.Click
        'If dgDetail.SelectedRows.Count = 0 Then
        '    MsgBox("No Rows have been selected", , "SCM00006 - Detail")
        '    Exit Sub
        'End If

        'If optDtlAprvN.Checked = False And optDtlAprvW.Checked = False And optDtlAprvY.Checked = False Then
        '    MsgBox("No approval option has been selected", , "SCM00006 - Detail")
        '    Exit Sub
        'End If

        'Dim approval As String = "W"
        'If optDtlAprvN.Checked = True Then
        '    approval = "N"
        'ElseIf optDtlAprvW.Checked = True Then
        '    approval = "W"
        'ElseIf optDtlAprvY.Checked = True Then
        '    approval = "Y"
        'End If

        'For i As Integer = 0 To dgDetail.SelectedRows.Count - 1
        '    dgDetail.SelectedRows(i).Cells("action").Value = approval
        'Next
    End Sub

    Private Sub display_Header(ByVal typ As String)
        If rs_SCM00006HDR Is Nothing Then
            Exit Sub
        End If
        dgHeader.DataSource = rs_SCM00006HDR.Tables("RESULT").DefaultView
        With dgHeader
            For i As Integer = 0 To .Columns.Count - 1
                Select Case i
                    Case 0
                        .Columns(i).HeaderText = "Hdr Apv"
                        .Columns(i).Width = 35
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.BackColor = Color.LightBlue
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        HdrApvSeq = i
                    Case 1
                        .Columns(i).HeaderText = "Comp"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                        .Columns(i).Visible = False
                    Case 2
                        .Columns(i).HeaderText = "SC No"
                        .Columns(i).Width = 70
                        .Columns(i).ReadOnly = True
                    Case 3
                        .Columns(i).HeaderText = "Status"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                        .Columns(i).Visible = False
                    Case 5
                        .Columns(i).HeaderText = "Primary Customer"
                        .Columns(i).Width = 100
                        .Columns(i).ReadOnly = True
                    Case 7
                        .Columns(i).HeaderText = "Secondary Customer"
                        .Columns(i).Width = 100
                        .Columns(i).ReadOnly = True
                    Case 8
                        .Columns(i).HeaderText = "Revised Date"
                        .Columns(i).Width = 70
                        .Columns(i).ReadOnly = True
                        .Columns(i).Visible = False
                    Case 9
                        .Columns(i).HeaderText = "Price Term Apv"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Columns(i).DefaultCellStyle.BackColor = Color.LightBlue
                        Select Case typ
                            Case "All", "PriceTerm"
                                .Columns(i).Visible = True
                            Case Else
                                .Columns(i).Visible = False
                        End Select
                        HdrPrcTrmApvSeq = i
                    Case 10
                        .Columns(i).HeaderText = "Curr Price Term"
                        .Columns(i).Width = 120
                        .Columns(i).ReadOnly = True
                        Select Case typ
                            Case "All", "PriceTerm"
                                .Columns(i).Visible = True
                            Case Else
                                .Columns(i).Visible = False
                        End Select
                    Case 11
                        .Columns(i).HeaderText = "Org Price Term"
                        .Columns(i).Width = 120
                        .Columns(i).ReadOnly = True
                        Select Case typ
                            Case "All", "PriceTerm"
                                .Columns(i).Visible = True
                            Case Else
                                .Columns(i).Visible = False
                        End Select
                    Case 12
                        .Columns(i).HeaderText = "Pay Term Apv"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Columns(i).DefaultCellStyle.BackColor = Color.LightBlue
                        Select Case typ
                            Case "All", "PaymentTerm"
                                .Columns(i).Visible = True
                            Case Else
                                .Columns(i).Visible = False
                        End Select
                        HdrPayTrmApvSeq = i
                    Case 13
                        .Columns(i).HeaderText = "Curr Pay Term"
                        .Columns(i).Width = 120
                        .Columns(i).ReadOnly = True
                        Select Case typ
                            Case "All", "PaymentTerm"
                                .Columns(i).Visible = True
                            Case Else
                                .Columns(i).Visible = False
                        End Select
                    Case 14
                        .Columns(i).HeaderText = "Org Pay Term"
                        .Columns(i).Width = 120
                        .Columns(i).ReadOnly = True
                        Select Case typ
                            Case "All", "PaymentTerm"
                                .Columns(i).Visible = True
                            Case Else
                                .Columns(i).Visible = False
                        End Select
                    Case 15
                        .Columns(i).HeaderText = "Repl Order Apv"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Columns(i).DefaultCellStyle.BackColor = Color.LightBlue
                        Select Case typ
                            Case "All", "Replacement"
                                .Columns(i).Visible = True
                            Case Else
                                .Columns(i).Visible = False
                        End Select
                        HdrRepOrdApvSeq = i
                    Case 16
                        .Columns(i).HeaderText = "Close Out Apv"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Columns(i).DefaultCellStyle.BackColor = Color.LightBlue
                        Select Case typ
                            Case "All", "CloseOut"
                                .Columns(i).Visible = True
                            Case Else
                                .Columns(i).Visible = False
                        End Select
                        HdrCloOrdApvSeq = i
                    Case 18
                        .Columns(i).Width = 32
                        .Columns(i).HeaderText = "Apv Check"
                        .Columns(i).ReadOnly = True
                        HdrApvCheckSeq = i
                    Case 19
                        .Columns(i).Width = 150
                        .Columns(i).HeaderText = "Check Reason"
                        .Columns(i).ReadOnly = True
                        HdrApvMsgSeq = i
                    Case 20
                        HdrApvSelAllSeq = i
                        .Columns(i).Visible = False
                    Case 21
                        HdrPrcTrmApvSelAllSeq = i
                        .Columns(i).Visible = False
                    Case 22
                        HdrPayTrmApvSelAllSeq = i
                        .Columns(i).Visible = False
                    Case 23
                        HdrRepOrdApvSelAllSeq = i
                        .Columns(i).Visible = False
                    Case 24
                        HdrCloOrdApvSelAllSeq = i
                        .Columns(i).Visible = False
                    Case 25
                        HdrKeepSelectSeq = i
                        .Columns(i).Visible = False
                    Case Else
                        .Columns(i).Visible = False
                End Select
            Next
        End With

        dgHeader.ClearSelection()
        dgHeader.CurrentCell = Nothing
        dgHeader.Refresh()
    End Sub

    Private Sub display_Detail(ByVal typ As String)
        If rs_SCM00006DTL Is Nothing Then
            Exit Sub
        End If

        dgDetail.DataSource = rs_SCM00006DTL.Tables("RESULT").DefaultView
        With dgDetail
            For i As Integer = 0 To .Columns.Count - 1
                Select Case i
                    Case 0
                        .Columns(i).HeaderText = "Dtl Apv"
                        .Columns(i).Width = 35
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.BackColor = Color.LightBlue
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        DtlApvSeq = i
                    Case 2
                        .Columns(i).HeaderText = "SC No"
                        .Columns(i).Width = 70
                        .Columns(i).ReadOnly = True
                    Case 9
                        .Columns(i).HeaderText = "SC Seq"
                        .Columns(i).Width = 35
                        .Columns(i).ReadOnly = True
                    Case 10
                        .Columns(i).HeaderText = "Item No"
                        .Columns(i).Width = 95
                        .Columns(i).ReadOnly = True
                    Case 11
                        .Columns(i).HeaderText = "Color"
                        .Columns(i).Width = 95
                        .Columns(i).ReadOnly = True
                    Case 16
                        .Columns(i).HeaderText = "Packing"
                        .Columns(i).Width = 180
                        .Columns(i).ReadOnly = True
                    Case 17
                        .Columns(i).HeaderText = "Below MOQ/MOA"
                        .Columns(i).Width = 65
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Columns(i).Visible = False
                    Case 18
                        .Columns(i).HeaderText = "Below Basic/MinMU"
                        .Columns(i).Width = 80
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Columns(i).Visible = False
                    Case 19
                        .Columns(i).HeaderText = "MOQ Apv"
                        .Columns(i).Width = 35
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.BackColor = Color.LightBlue
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Select Case typ
                            Case "All", "MOQMOA"
                                .Columns(i).Visible = True
                            Case Else
                                .Columns(i).Visible = False
                        End Select
                        DtlMOQApvSeq = i
                    Case 21
                        .Columns(i).HeaderText = "Order CTN"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                        Select Case typ
                            Case "All", "MOQMOA"
                                .Columns(i).Visible = True
                            Case Else
                                .Columns(i).Visible = False
                        End Select
                    Case 22
                        .Columns(i).HeaderText = "MOQ"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                        Select Case typ
                            Case "All", "MOQMOA"
                                .Columns(i).Visible = True
                            Case Else
                                .Columns(i).Visible = False
                        End Select
                    Case 23
                        .Columns(i).HeaderText = "Chg Sel Apv"
                        .Columns(i).Width = 35
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.BackColor = Color.LightBlue
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Select Case typ
                            Case "All", "ChgPrc"
                                .Columns(i).Visible = True
                            Case Else
                                .Columns(i).Visible = False
                        End Select
                        DtlChgUntPrcApvSeq = i
                    Case 24
                        .Columns(i).HeaderText = "Bel Prc Apv"
                        .Columns(i).Width = 35
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.BackColor = Color.LightBlue
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Select Case typ
                            Case "All", "BelPrc"
                                .Columns(i).Visible = True
                            Case Else
                                .Columns(i).Visible = False
                        End Select
                        DtlMinMUApvSeq = i
                    Case 25
                        .Columns(i).HeaderText = "One Time Apv"
                        .Columns(i).Width = 35
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.BackColor = Color.LightBlue
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Select Case typ
                            Case "All", "OneTime"
                                .Columns(i).Visible = True
                            Case Else
                                .Columns(i).Visible = False
                        End Select
                        DtlOneTimeApvSeq = i

                    Case 26
                        .Columns(i).HeaderText = "CCY"
                        .Columns(i).Width = 35
                        .Columns(i).ReadOnly = True
                        Select Case typ
                            Case "All", "BelPrc", "OneTime", "ChgPrc"
                                .Columns(i).Visible = True
                            Case Else
                                .Columns(i).Visible = False
                        End Select
                    Case 27
                        .Columns(i).HeaderText = "Min MU Price"
                        .Columns(i).Width = 60
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        Select Case typ
                            Case "All", "BelPrc", "OneTime", "ChgPrc"
                                .Columns(i).Visible = True
                            Case Else
                                .Columns(i).Visible = False
                        End Select
                    Case 28
                        .Columns(i).HeaderText = "Selling Price"
                        .Columns(i).Width = 60
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        Select Case typ
                            Case "All", "BelPrc", "OneTime", "ChgPrc"
                                .Columns(i).Visible = True
                            Case Else
                                .Columns(i).Visible = False
                        End Select
                    Case 29
                        .Columns(i).HeaderText = "Org Selling Price"
                        .Columns(i).Width = 60
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        Select Case typ
                            Case "All", "BelPrc", "OneTime", "ChgPrc"
                                .Columns(i).Visible = True
                            Case Else
                                .Columns(i).Visible = False
                        End Select
                    Case 30
                        .Columns(i).HeaderText = "Chg Cst Apv"
                        .Columns(i).Width = 35
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.BackColor = Color.LightBlue
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Select Case typ
                            Case "All", "ChgCst"
                                .Columns(i).Visible = True
                            Case Else
                                .Columns(i).Visible = False
                        End Select
                        DtlChgFtyCstApvSeq = i
                    Case 31
                        .Columns(i).HeaderText = "CCY"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                        Select Case typ
                            Case "All", "ChgCst"
                                .Columns(i).Visible = True
                            Case Else
                                .Columns(i).Visible = False
                        End Select
                    Case 32
                        .Columns(i).HeaderText = "FtyCst"
                        .Columns(i).Width = 60
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        Select Case typ
                            Case "All", "ChgCst"
                                .Columns(i).Visible = True
                            Case Else
                                .Columns(i).Visible = False
                        End Select
                    Case 33
                        .Columns(i).HeaderText = "Org FtyCst"
                        .Columns(i).Width = 60
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        Select Case typ
                            Case "All", "ChgCst"
                                .Columns(i).Visible = True
                            Case Else
                                .Columns(i).Visible = False
                        End Select
                    Case 34
                        .Columns(i).HeaderText = "DV FtyCst"
                        .Columns(i).Width = 60
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        Select Case typ
                            Case "All", "ChgCst"
                                .Columns(i).Visible = True
                            Case Else
                                .Columns(i).Visible = False
                        End Select
                    Case 35
                        .Columns(i).HeaderText = "Org DV FtyCst"
                        .Columns(i).Width = 60
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        Select Case typ
                            Case "All", "ChgCst"
                                .Columns(i).Visible = True
                            Case Else
                                .Columns(i).Visible = False
                        End Select
                    Case 37
                        .Columns(i).Width = 32
                        .Columns(i).HeaderText = "Apv Check"
                        .Columns(i).ReadOnly = True
                        DtlApvCheckSeq = i
                    Case 38
                        .Columns(i).Width = 150
                        .Columns(i).HeaderText = "Check Reason"
                        .Columns(i).ReadOnly = True
                        DtlApvMsgSeq = i
                    Case 39
                        DtlApvSelAllSeq = i
                        .Columns(i).Visible = False
                    Case 40
                        DtlMOQApvSelAllSeq = i
                        .Columns(i).Visible = False
                    Case 41
                        DtlChgUntPrcApvSelAllSeq = i
                        .Columns(i).Visible = False
                    Case 42
                        DtlMinMUApvSelAllSeq = i
                        .Columns(i).Visible = False
                    Case 43
                        DtlOneTimeApvSelAllSeq = i
                        .Columns(i).Visible = False
                    Case 44
                        DtlChgFtyCstApvSelAllSeq = i
                        .Columns(i).Visible = False
                    Case 45
                        DtlKeepSelectSeq = i
                        .Columns(i).Visible = False
                    Case Else
                        .Columns(i).Visible = False
                End Select
            Next
        End With

        dgDetail.ClearSelection()
        dgDetail.CurrentCell = Nothing
        dgDetail.Refresh()
    End Sub

    Private Sub dgDetail_txtUpdate(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetail.RowEnter
        If sender.Focused = True Then
            txtCoCde.Text = dgDetail.Rows(e.RowIndex).Cells("sod_cocde").Value
            txtSCNo.Text = dgDetail.Rows(e.RowIndex).Cells("sod_ordno").Value
            txtOrdSts.Text = dgDetail.Rows(e.RowIndex).Cells("soh_ordsts").Value
            txtRvsDat.Text = dgDetail.Rows(e.RowIndex).Cells("soh_rvsdat").Value
            txtPriCus.Text = dgDetail.Rows(e.RowIndex).Cells("pri_cusnam").Value
            txtSecCus.Text = dgDetail.Rows(e.RowIndex).Cells("sec_cusnam").Value
        End If
    End Sub

    Private Function checkChangesMade() As Boolean
        If rs_SCM00006DTL Is Nothing And rs_SCM00006DTL_ori Is Nothing And rs_SCM00006HDR Is Nothing And rs_SCM00006HDR_ori Is Nothing Then
            Return False
        End If

        Dim row() As DataRow

        If rs_SCM00006HDR.Tables("RESULT").Rows.Count > 0 Then
            For i As Integer = 0 To rs_SCM00006HDR.Tables("RESULT").Rows.Count - 1
                row = Nothing
                row = rs_SCM00006HDR_ori.Tables("RESULT").Select("soh_ordno = '" & rs_SCM00006HDR.Tables("RESULT").Rows(i)("soh_ordno") & "'")
                If row.Length > 0 Then
                    If row(0)(HdrApvSeq) <> rs_SCM00006HDR.Tables("RESULT").Rows(i)(HdrApvSeq) Or _
                        row(0)(HdrCloOrdApvSeq) <> rs_SCM00006HDR.Tables("RESULT").Rows(i)(HdrCloOrdApvSeq) Or _
                        row(0)(HdrPayTrmApvSeq) <> rs_SCM00006HDR.Tables("RESULT").Rows(i)(HdrPayTrmApvSeq) Or _
                        row(0)(HdrPrcTrmApvSeq) <> rs_SCM00006HDR.Tables("RESULT").Rows(i)(HdrPrcTrmApvSeq) Or _
                        row(0)(HdrRepOrdApvSeq) <> rs_SCM00006HDR.Tables("RESULT").Rows(i)(HdrRepOrdApvSeq) Then
                        Return True
                    End If
                Else
                    Return True
                End If
            Next
        Else
            Return False
        End If

        If rs_SCM00006DTL.Tables("RESULT").Rows.Count > 0 Then
            For i As Integer = 0 To rs_SCM00006DTL.Tables("RESULT").Rows.Count - 1
                row = Nothing
                row = rs_SCM00006DTL_ori.Tables("RESULT").Select("sod_ordno = '" & rs_SCM00006DTL.Tables("RESULT").Rows(i)("sod_ordno") & "' and " & _
                                                                 "sod_ordseq = '" & rs_SCM00006DTL.Tables("RESULT").Rows(i)("sod_ordseq") & "'")
                If row.Length > 0 Then
                    If row(0)(DtlApvSeq) <> rs_SCM00006DTL.Tables("RESULT").Rows(i)(DtlApvSeq) Or _
                        row(0)(DtlChgFtyCstApvSeq) <> rs_SCM00006DTL.Tables("RESULT").Rows(i)(DtlChgFtyCstApvSeq) Or _
                        row(0)(DtlMinMUApvSeq) <> rs_SCM00006DTL.Tables("RESULT").Rows(i)(DtlMinMUApvSeq) Or _
                        row(0)(DtlMOQApvSeq) <> rs_SCM00006DTL.Tables("RESULT").Rows(i)(DtlMOQApvSeq) Or _
                        row(0)(DtlOneTimeApvSeq) <> rs_SCM00006DTL.Tables("RESULT").Rows(i)(DtlOneTimeApvSeq) Then
                        Return True
                    End If
                Else
                    Return True
                End If
            Next

        Else
            Return False
        End If

        Return False
    End Function

    Private Function checkChangesMade(ByVal before As DataRow, ByVal after As DataRow) As Boolean
        If before Is Nothing Or after Is Nothing Then
            Return False
        End If

        For i As Integer = 0 To after.ItemArray.Length - 1
            If before.Item(i).ToString <> after.Item(i).ToString Then
                Return True
            End If
        Next

        Return False
    End Function

    Private Function checkTimestamp(ByVal row As DataRow, ByVal mode As String) As Boolean
        Dim rs_timstp As DataSet
        If UCase(mode) = "HDR" Then
            gspStr = "sp_select_SCM00006_timstp '','" & UCase(mode) & "','" & row("soh_ordno") & "','','" & gsUsrID & "'"
        ElseIf UCase(mode) = "DTL" Then
            gspStr = "sp_select_SCM00006_timstp '','" & UCase(mode) & "','" & row("sod_ordno") & "','" & row("sod_ordseq") & "','" & gsUsrID & "'"
        Else
            Return False
        End If

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_timstp, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Error on loading SCM00006 #003 sp_select_SCM00006_timstp : " & rtnStr)
            Exit Function
        Else
            If rs_timstp.Tables("RESULT").Rows.Count > 0 Then
                If UCase(mode) = "HDR" Then
                    If row("soh_timstp") = rs_timstp.Tables("RESULT").Rows(0)("soh_timstp") Then
                        Return True
                    Else
                        Return False
                    End If
                ElseIf UCase(mode) = "DTL" Then
                    If row("sod_timstp") = rs_timstp.Tables("RESULT").Rows(0)("sod_timstp") Then
                        Return True
                    Else
                        Return False
                    End If
                End If
            Else
                Return False
            End If
        End If
    End Function

    Private Sub focusHighlightText(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSCRvsdatFm.GotFocus, txtSCRvsdatTo.GotFocus
        sender.SelectAll()
    End Sub

    Private Sub cmdHdrApvApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHdrApvApply.Click
        Dim i As Integer
        Dim k As Integer
        Dim s As String
        If rbHdrApv_Y.Checked = True Then
            s = "Y"
        Else
            s = "W"
        End If


        Dim applyType As String

        If rbHdrApvFilter_All.Checked Then
            applyType = "ALL"
        ElseIf rbHdrApvFilter_PriceTerm.Checked Then
            applyType = "PRICETERM"
        ElseIf rbHdrApvFilter_PaymentTerm.Checked Then
            applyType = "PAYMENTTERM"
        ElseIf rbHdrApvFilter_Replacement.Checked Then
            applyType = "REPLACEMENT"
        ElseIf rbHdrApvFilter_CloseOut.Checked Then
            applyType = "CLOSEOUT"
        End If




        Dim check As Boolean
        Dim checkmsg As String
        check = True
        checkmsg = ""

        For i = 0 To dgHeader.SelectedRows.Count - 1
            If s = "Y" And dgHeader.SelectedRows(i).Cells(HdrApvSeq).Value = "W" Then
                If dgHeader.SelectedRows(i).Cells(HdrApvCheckSeq).Value = "Pass" Then
                ElseIf dgHeader.SelectedRows(i).Cells(HdrApvCheckSeq).Value = "Fail" Then
                    checkmsg = checkmsg & dgHeader.SelectedRows(i).Cells(2).Value & "; "
                    check = False
                End If
            End If
        Next i

        For k = 0 To dgHeader.RowCount - 1
            dgHeader.Rows(k).Cells(HdrKeepSelectSeq).Value = ""
        Next k

        If check = False Then
            If MsgBox("The following SC cannot be approved, Are you sure to continue? " & checkmsg, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                check = True
            End If
        End If

        If check = True Then
            dgDetail.ClearSelection()

            'Apply Header All case
            For i = 0 To dgHeader.SelectedRows.Count - 1
                dgHeader.SelectedRows(i).Cells(HdrKeepSelectSeq).Value = "Y"
                If dgHeader.SelectedRows(i).Cells(HdrApvCheckSeq).Value = "Pass" Then
                    Select applyType
                        Case "ALL"
                            If s = "Y" And dgHeader.SelectedRows(i).Cells(HdrApvSeq).Value = "W" Then

                                dgHeader.SelectedRows(i).Cells(HdrApvSelAllSeq).Value = "Y"
                                ApprovalActionSelAll("APV_ALL_HDR", dgHeader.SelectedRows(i).Cells(0).RowIndex, HdrApvSelAllSeq)

                                ' apv all related details
                                Dim sFilter1 As String
                                sFilter1 = "sod_ordno = '" & dgHeader.Rows(dgHeader.SelectedRows(i).Cells(0).RowIndex).Cells("soh_ordno").Value & "'"
                                rs_SCM00006DTL.Tables("RESULT").DefaultView.RowFilter = sFilter1
                                dgDetail.DataSource = rs_SCM00006DTL.Tables("RESULT").DefaultView

                                If dgDetail.RowCount > 0 Then
                                    For ii As Integer = 0 To dgDetail.RowCount - 1
                                        If dgDetail.Rows(ii).Cells(DtlApvSeq).Value = "W" Then
                                            dgDetail.Rows(ii).Cells(DtlApvSeq).Value = "Y"
                                            ApprovalAction("APV_ALL_DTL", ii, DtlApvSeq)
                                        End If
                                    Next ii
                                End If
                                sFilter1 = ""
                                rs_SCM00006DTL.Tables("RESULT").DefaultView.RowFilter = sFilter1
                                dgDetail.DataSource = rs_SCM00006DTL.Tables("RESULT").DefaultView
                            ElseIf s = "W" And dgHeader.SelectedRows(i).Cells(HdrApvSeq).Value = "Y" Then
                                dgHeader.SelectedRows(i).Cells(HdrApvSelAllSeq).Value = "W"
                                ApprovalActionSelAll("WIP_ALL_HDR", dgHeader.SelectedRows(i).Cells(0).RowIndex, HdrApvSelAllSeq)

                                ' wip all related details
                                Dim sFilter2 As String
                                sFilter2 = "sod_ordno = '" & dgHeader.Rows(dgHeader.SelectedRows(i).Cells(0).RowIndex).Cells("soh_ordno").Value & "'"
                                rs_SCM00006DTL.Tables("RESULT").DefaultView.RowFilter = sFilter2
                                dgDetail.DataSource = rs_SCM00006DTL.Tables("RESULT").DefaultView

                                If dgDetail.RowCount > 0 Then
                                    For ii As Integer = 0 To dgDetail.RowCount - 1
                                        If dgDetail.Rows(ii).Cells(DtlApvSeq).Value = "Y" Then
                                            dgDetail.Rows(ii).Cells(DtlApvSeq).Value = "W"
                                            ApprovalAction("WIP_ALL_DTL", ii, DtlApvSeq)
                                        End If
                                    Next ii
                                End If
                                sFilter2 = ""
                                rs_SCM00006DTL.Tables("RESULT").DefaultView.RowFilter = sFilter2
                                dgDetail.DataSource = rs_SCM00006DTL.Tables("RESULT").DefaultView
                            End If
                        Case "PRICETERM"
                            If s = "Y" And dgHeader.SelectedRows(i).Cells(HdrPrcTrmApvSeq).Value = "W" Then
                                dgHeader.SelectedRows(i).Cells(HdrPrcTrmApvSelAllSeq).Value = "Y"
                                ApprovalActionSelAll("CHECK_APV_HDR", dgHeader.SelectedRows(i).Cells(0).RowIndex, HdrPrcTrmApvSelAllSeq)
                            ElseIf s = "W" And dgHeader.SelectedRows(i).Cells(HdrPrcTrmApvSeq).Value = "Y" Then
                                dgHeader.SelectedRows(i).Cells(HdrPrcTrmApvSelAllSeq).Value = "W"
                                ApprovalActionSelAll("CHECK_WIP_HDR", dgHeader.SelectedRows(i).Cells(0).RowIndex, HdrPrcTrmApvSelAllSeq)
                            End If
                    Case "PAYMENTTERM"
                            If s = "Y" And dgHeader.SelectedRows(i).Cells(HdrPayTrmApvSeq).Value = "W" Then
                                dgHeader.SelectedRows(i).Cells(HdrPayTrmApvSelAllSeq).Value = "Y"
                                ApprovalActionSelAll("CHECK_APV_HDR", dgHeader.SelectedRows(i).Cells(0).RowIndex, HdrPayTrmApvSelAllSeq)
                            ElseIf s = "W" And dgHeader.SelectedRows(i).Cells(HdrPayTrmApvSeq).Value = "Y" Then
                                dgHeader.SelectedRows(i).Cells(HdrPayTrmApvSelAllSeq).Value = "W"
                                ApprovalActionSelAll("CHECK_WIP_HDR", dgHeader.SelectedRows(i).Cells(0).RowIndex, HdrPayTrmApvSelAllSeq)
                            End If
                    Case "REPLACEMENT"
                            If s = "Y" And dgHeader.SelectedRows(i).Cells(HdrRepOrdApvSeq).Value = "W" Then
                                dgHeader.SelectedRows(i).Cells(HdrRepOrdApvSelAllSeq).Value = "Y"
                                ApprovalActionSelAll("CHECK_APV_HDR", dgHeader.SelectedRows(i).Cells(0).RowIndex, HdrRepOrdApvSelAllSeq)
                            ElseIf s = "W" And dgHeader.SelectedRows(i).Cells(HdrRepOrdApvSeq).Value = "Y" Then
                                dgHeader.SelectedRows(i).Cells(HdrRepOrdApvSelAllSeq).Value = "W"
                                ApprovalActionSelAll("CHECK_WIP_HDR", dgHeader.SelectedRows(i).Cells(0).RowIndex, HdrRepOrdApvSelAllSeq)
                            End If
                    Case "CLOSEOUT"
                            If s = "Y" And dgHeader.SelectedRows(i).Cells(HdrCloOrdApvSeq).Value = "W" Then
                                dgHeader.SelectedRows(i).Cells(HdrCloOrdApvSelAllSeq).Value = "Y"
                                ApprovalActionSelAll("CHECK_APV_HDR", dgHeader.SelectedRows(i).Cells(0).RowIndex, HdrCloOrdApvSelAllSeq)
                            ElseIf s = "W" And dgHeader.SelectedRows(i).Cells(HdrCloOrdApvSeq).Value = "Y" Then
                                dgHeader.SelectedRows(i).Cells(HdrCloOrdApvSelAllSeq).Value = "W"
                                ApprovalActionSelAll("CHECK_WIP_HDR", dgHeader.SelectedRows(i).Cells(0).RowIndex, HdrCloOrdApvSelAllSeq)
                            End If
                    End Select
                End If
            Next i

            Dim hdrApvAllRevised As Boolean
            Dim hdrApvDtlRevised As Boolean

            hdrApvAllRevised = False
            hdrApvDtlRevised = False

            If dgHeader.SortedColumn Is Nothing Then
                hdrApvDtlRevised = False
                hdrApvAllRevised = False
            Else
                Select Case dgHeader.SortedColumn.Index
                    Case HdrApvSeq
                        hdrApvDtlRevised = False
                        hdrApvAllRevised = False
                    Case HdrPrcTrmApvSeq, HdrPayTrmApvSeq, HdrRepOrdApvSeq, HdrCloOrdApvSeq
                        If dgHeader.SortOrder = SortOrder.Ascending Then
                            hdrApvDtlRevised = True
                            hdrApvAllRevised = False
                        ElseIf dgHeader.SortOrder = SortOrder.Descending Then
                            hdrApvDtlRevised = False
                            hdrApvAllRevised = False
                        Else
                            hdrApvDtlRevised = False
                            hdrApvAllRevised = False
                        End If
                    Case Else
                        hdrApvDtlRevised = False
                        hdrApvAllRevised = False
                End Select

            End If



            If hdrApvDtlRevised = True Then
                For k = dgHeader.RowCount - 1 To 0 Step -1
                    dgHeader.Rows(k).Cells(HdrPrcTrmApvSeq).Value = dgHeader.Rows(k).Cells(HdrPrcTrmApvSelAllSeq).Value
                Next k
                For k = dgHeader.RowCount - 1 To 0 Step -1
                    dgHeader.Rows(k).Cells(HdrPayTrmApvSeq).Value = dgHeader.Rows(k).Cells(HdrPayTrmApvSelAllSeq).Value
                Next k
                For k = dgHeader.RowCount - 1 To 0 Step -1
                    dgHeader.Rows(k).Cells(HdrRepOrdApvSeq).Value = dgHeader.Rows(k).Cells(HdrRepOrdApvSelAllSeq).Value
                Next k
                For k = dgHeader.RowCount - 1 To 0 Step -1
                    dgHeader.Rows(k).Cells(HdrCloOrdApvSeq).Value = dgHeader.Rows(k).Cells(HdrCloOrdApvSelAllSeq).Value
                Next k
                For k = dgHeader.RowCount - 1 To 0 Step -1
                    dgHeader.Rows(k).Cells(HdrApvSeq).Value = dgHeader.Rows(k).Cells(HdrApvSelAllSeq).Value
                Next k
            Else
                For k = 0 To dgHeader.RowCount - 1
                    dgHeader.Rows(k).Cells(HdrPrcTrmApvSeq).Value = dgHeader.Rows(k).Cells(HdrPrcTrmApvSelAllSeq).Value
                Next k
                For k = 0 To dgHeader.RowCount - 1
                    dgHeader.Rows(k).Cells(HdrPayTrmApvSeq).Value = dgHeader.Rows(k).Cells(HdrPayTrmApvSelAllSeq).Value
                Next k
                For k = 0 To dgHeader.RowCount - 1
                    dgHeader.Rows(k).Cells(HdrRepOrdApvSeq).Value = dgHeader.Rows(k).Cells(HdrRepOrdApvSelAllSeq).Value
                Next k
                For k = 0 To dgHeader.RowCount - 1
                    dgHeader.Rows(k).Cells(HdrCloOrdApvSeq).Value = dgHeader.Rows(k).Cells(HdrCloOrdApvSelAllSeq).Value
                Next k
                For k = 0 To dgHeader.RowCount - 1
                    dgHeader.Rows(k).Cells(HdrApvSeq).Value = dgHeader.Rows(k).Cells(HdrApvSelAllSeq).Value
                Next k
            End If

            dgHeader.ClearSelection()


            If hdrApvAllRevised = True Then
                For k = dgHeader.RowCount - 1 To 0 Step -1
                    If dgHeader.Rows(k).Cells(HdrKeepSelectSeq).Value = "Y" Then
                        dgHeader.Rows(k).Selected = True
                    End If
                Next k
            Else
                For k = 0 To dgHeader.RowCount - 1
                    If dgHeader.Rows(k).Cells(HdrKeepSelectSeq).Value = "Y" Then
                        dgHeader.Rows(k).Selected = True
                    End If
                Next k
            End If


        End If

    End Sub


    Private Sub dgHeader_ActionClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgHeader.CellClick
        If dgHeader.Focused = True And e.RowIndex >= 0 Then
            Select Case e.ColumnIndex
                Case HdrApvSeq
                    If dgHeader.Rows(e.RowIndex).Cells(HdrApvCheckSeq).Value = "Fail" Then
                        MsgBox(dgHeader.Rows(e.RowIndex).Cells(HdrApvMsgSeq).Value.ToString())
                    Else
                        If dgHeader.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "W" Then
                            dgHeader.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "Y"
                            ApprovalAction("APV_ALL_HDR", e.RowIndex, e.ColumnIndex)
                            ' apv all related details
                            Dim sFilter1 As String
                            sFilter1 = "sod_ordno = '" & dgHeader.Rows(e.RowIndex).Cells("soh_ordno").Value & "'"
                            rs_SCM00006DTL.Tables("RESULT").DefaultView.RowFilter = sFilter1
                            dgDetail.DataSource = rs_SCM00006DTL.Tables("RESULT").DefaultView

                            If dgDetail.RowCount > 0 Then
                                For i As Integer = 0 To dgDetail.RowCount - 1
                                    If dgDetail.Rows(i).Cells(DtlApvSeq).Value = "W" Then
                                        dgDetail.Rows(i).Cells(DtlApvSeq).Value = "Y"
                                        ApprovalAction("APV_ALL_DTL", i, DtlApvSeq)
                                    End If
                                Next i
                            End If
                            sFilter1 = ""
                            rs_SCM00006DTL.Tables("RESULT").DefaultView.RowFilter = sFilter1
                            dgDetail.DataSource = rs_SCM00006DTL.Tables("RESULT").DefaultView
                        ElseIf dgHeader.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "Y" Then
                            dgHeader.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "W"
                            ApprovalAction("WIP_ALL_HDR", e.RowIndex, e.ColumnIndex)
                            ' wip all related details
                            Dim sFilter2 As String
                            sFilter2 = "sod_ordno = '" & dgHeader.Rows(e.RowIndex).Cells("soh_ordno").Value & "'"
                            rs_SCM00006DTL.Tables("RESULT").DefaultView.RowFilter = sFilter2
                            dgDetail.DataSource = rs_SCM00006DTL.Tables("RESULT").DefaultView

                            If dgDetail.RowCount > 0 Then
                                For i As Integer = 0 To dgDetail.RowCount - 1
                                    If dgDetail.Rows(i).Cells(DtlApvSeq).Value = "Y" Then
                                        dgDetail.Rows(i).Cells(DtlApvSeq).Value = "W"
                                        ApprovalAction("WIP_ALL_DTL", i, DtlApvSeq)
                                    End If
                                Next i
                            End If
                            sFilter2 = ""
                            rs_SCM00006DTL.Tables("RESULT").DefaultView.RowFilter = sFilter2
                            dgDetail.DataSource = rs_SCM00006DTL.Tables("RESULT").DefaultView
                        End If
                    End If
                Case HdrPrcTrmApvSeq, HdrPayTrmApvSeq, HdrRepOrdApvSeq, HdrCloOrdApvSeq
                    If dgHeader.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " " Then
                        ' do nothing
                    ElseIf dgHeader.Rows(e.RowIndex).Cells(HdrApvCheckSeq).Value = "Fail" Then
                        MsgBox(dgHeader.Rows(e.RowIndex).Cells(HdrApvMsgSeq).Value.ToString())
                    Else
                        If dgHeader.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "W" Then
                            dgHeader.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "Y"
                            ApprovalAction("CHECK_APV_HDR", e.RowIndex, e.ColumnIndex)
                        ElseIf dgHeader.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "Y" Then
                            dgHeader.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "W"
                            ApprovalAction("CHECK_WIP_HDR", e.RowIndex, e.ColumnIndex)
                        End If
                    End If
            End Select
        End If
    End Sub

    Private Sub cmdDtlApvApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDtlApvApply.Click
        Dim selectColIndex As Integer
        Dim selectRowIndex As Integer
        selectColIndex = 0
        selectRowIndex = 0

        Dim i As Integer
        Dim k As Integer
        Dim s As String


        If rbDtlApv_Y.Checked = True Then
            s = "Y"
        Else
            s = "W"
        End If

        Dim applyType As String

        If rbDtlApvFilter_All.Checked Then
            applyType = "ALL"
        ElseIf rbDtlApvFilter_BelowMinMU.Checked Then
            applyType = "BELOWMINMU"
        ElseIf rbDtlApvFilter_ChgDVPVFtyCst.Checked Then
            applyType = "CHANGEFTYCST"
        ElseIf rbDtlApvFilter_ChgSelPrc.Checked Then
            applyType = "CHANGESELPRC"
        ElseIf rbDtlApvFilter_MOQ.Checked Then
            applyType = "BELOWMOQ"
        ElseIf rbDtlApvFilter_OneTime.Checked Then
            applyType = "ONETIME"
        End If

        Dim check As Boolean
        Dim checkmsg As String
        check = True
        checkmsg = ""

        For i = 0 To dgDetail.SelectedRows.Count - 1
            If s = "Y" And dgDetail.SelectedRows(i).Cells(DtlApvSeq).Value = "W" Then
                If dgDetail.SelectedRows(i).Cells(DtlApvCheckSeq).Value = "Pass" Then
                ElseIf dgDetail.SelectedRows(i).Cells(DtlApvCheckSeq).Value = "Fail" Then
                    checkmsg = checkmsg & "[" & dgDetail.SelectedRows(i).Cells(2).Value & "-" & dgDetail.SelectedRows(i).Cells(10).Value & "]" & "; "
                    check = False
                End If
            End If
        Next

        For k = 0 To dgDetail.RowCount - 1
            dgDetail.Rows(k).Cells(DtlKeepSelectSeq).Value = ""
        Next k

        If check = False Then
            If MsgBox("The following SC cannot be approved, Are you sure to continue? " & checkmsg, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                check = True
            End If
        End If

        If check = True Then
            dgHeader.ClearSelection()

            For i = 0 To dgDetail.SelectedRows.Count - 1
                dgDetail.SelectedRows(i).Cells(DtlKeepSelectSeq).Value = "Y"
            Next

            For i = 0 To dgDetail.Rows.Count - 1
                If dgDetail.Rows(i).Cells(DtlKeepSelectSeq).Value = "Y" Then
                    If dgDetail.Rows(i).Cells(DtlApvCheckSeq).Value = "Pass" Then
                        Select Case applyType
                            Case "ALL"
                                If s = "Y" And dgDetail.Rows(i).Cells(DtlApvSeq).Value = "W" Then
                                    dgDetail.Rows(i).Cells(DtlApvSelAllSeq).Value = "Y"
                                    ApprovalActionSelAll("APV_ALL_DTL", dgDetail.Rows(i).Cells(0).RowIndex, DtlApvSelAllSeq)

                                    'check detail
                                    Dim sFilter1 As String
                                    Dim sFilter1_key As String
                                    sFilter1_key = dgDetail.Rows(i).Cells("sod_ordno").Value
                                    sFilter1 = "sod_ordno = '" & dgDetail.Rows(i).Cells("sod_ordno").Value & "'"
                                    rs_SCM00006DTL.Tables("RESULT").DefaultView.RowFilter = sFilter1
                                    dgDetail.DataSource = rs_SCM00006DTL.Tables("RESULT").DefaultView

                                    Dim check_detail As Boolean
                                    check_detail = True
                                    If dgDetail.RowCount > 0 Then
                                        For ii As Integer = 0 To dgDetail.RowCount - 1
                                            If dgDetail.Rows(ii).Cells(DtlApvSelAllSeq).Value = "W" Then
                                                check_detail = False
                                            End If
                                        Next ii
                                    End If
                                    sFilter1 = ""
                                    rs_SCM00006DTL.Tables("RESULT").DefaultView.RowFilter = sFilter1
                                    dgDetail.DataSource = rs_SCM00006DTL.Tables("RESULT").DefaultView

                                    If check_detail = True Then
                                        'check header
                                        Dim sFilter2 As String
                                        sFilter2 = "soh_ordno = '" & sFilter1_key & "'"
                                        rs_SCM00006HDR.Tables("RESULT").DefaultView.RowFilter = sFilter2
                                        dgHeader.DataSource = rs_SCM00006HDR.Tables("RESULT").DefaultView

                                        If dgHeader.RowCount = 1 Then
                                            If (dgHeader.Rows(0).Cells(HdrPrcTrmApvSeq).Value = "Y" Or dgHeader.Rows(0).Cells(HdrPrcTrmApvSeq).Value = " ") And _
                                                (dgHeader.Rows(0).Cells(HdrPayTrmApvSeq).Value = "Y" Or dgHeader.Rows(0).Cells(HdrPayTrmApvSeq).Value = " ") And _
                                                (dgHeader.Rows(0).Cells(HdrRepOrdApvSeq).Value = "Y" Or dgHeader.Rows(0).Cells(HdrRepOrdApvSeq).Value = " ") And _
                                                (dgHeader.Rows(0).Cells(HdrCloOrdApvSeq).Value = "Y" Or dgHeader.Rows(0).Cells(HdrCloOrdApvSeq).Value = " ") Then
                                                dgHeader.Rows(0).Cells(HdrApvSeq).Value = "Y"
                                            End If
                                        End If
                                        sFilter2 = ""
                                        rs_SCM00006HDR.Tables("RESULT").DefaultView.RowFilter = sFilter2
                                        dgHeader.DataSource = rs_SCM00006HDR.Tables("RESULT").DefaultView
                                    End If
                                ElseIf s = "W" And dgDetail.Rows(i).Cells(DtlApvSeq).Value = "Y" Then
                                    dgDetail.Rows(i).Cells(DtlApvSelAllSeq).Value = "W"
                                    ApprovalActionSelAll("WIP_ALL_DTL", dgDetail.Rows(i).Cells(0).RowIndex, DtlApvSelAllSeq)
                                    'check header
                                    Dim sFilter3 As String
                                    sFilter3 = "soh_ordno = '" & dgDetail.Rows(i).Cells("sod_ordno").Value & "'"
                                    rs_SCM00006HDR.Tables("RESULT").DefaultView.RowFilter = sFilter3
                                    dgHeader.DataSource = rs_SCM00006HDR.Tables("RESULT").DefaultView

                                    If dgHeader.RowCount = 1 Then
                                        If dgHeader.Rows(0).Cells(HdrApvSeq).Value = "Y" Then
                                            dgHeader.Rows(0).Cells(HdrApvSeq).Value = "W"
                                        End If
                                    End If
                                    sFilter3 = ""
                                    rs_SCM00006HDR.Tables("RESULT").DefaultView.RowFilter = sFilter3
                                    dgHeader.DataSource = rs_SCM00006HDR.Tables("RESULT").DefaultView
                                End If
                            Case "BELOWMINMU"
                                If s = "Y" And dgDetail.Rows(i).Cells(DtlMinMUApvSeq).Value = "W" Then
                                    dgDetail.Rows(i).Cells(DtlMinMUApvSelAllSeq).Value = "Y"
                                    ApprovalActionSelAll("CHECK_APV_DTL", dgDetail.Rows(i).Cells(0).RowIndex, DtlMinMUApvSelAllSeq)
                                ElseIf s = "W" And dgDetail.Rows(i).Cells(DtlMinMUApvSeq).Value = "Y" Then
                                    dgDetail.Rows(i).Cells(DtlMinMUApvSelAllSeq).Value = "W"
                                    ApprovalActionSelAll("CHECK_WIP_DTL", dgDetail.Rows(i).Cells(0).RowIndex, DtlMinMUApvSelAllSeq)
                                End If
                            Case "CHANGEFTYCST"
                                If s = "Y" And dgDetail.Rows(i).Cells(DtlChgFtyCstApvSeq).Value = "W" Then
                                    dgDetail.Rows(i).Cells(DtlChgFtyCstApvSelAllSeq).Value = "Y"
                                    ApprovalActionSelAll("CHECK_APV_DTL", dgDetail.Rows(i).Cells(0).RowIndex, DtlChgFtyCstApvSelAllSeq)
                                ElseIf s = "W" And dgDetail.Rows(i).Cells(DtlChgFtyCstApvSeq).Value = "Y" Then
                                    dgDetail.Rows(i).Cells(DtlChgFtyCstApvSelAllSeq).Value = "W"
                                    ApprovalActionSelAll("CHECK_WIP_DTL", dgDetail.Rows(i).Cells(0).RowIndex, DtlChgFtyCstApvSelAllSeq)
                                End If
                            Case "CHANGESELPRC"
                                If s = "Y" And dgDetail.Rows(i).Cells(DtlChgUntPrcApvSeq).Value = "W" Then
                                    dgDetail.Rows(i).Cells(DtlChgUntPrcApvSelAllSeq).Value = "Y"
                                    ApprovalActionSelAll("CHECK_APV_DTL", dgDetail.Rows(i).Cells(0).RowIndex, DtlChgUntPrcApvSelAllSeq)
                                ElseIf s = "W" And dgDetail.Rows(i).Cells(DtlChgUntPrcApvSeq).Value = "Y" Then
                                    dgDetail.Rows(i).Cells(DtlChgUntPrcApvSelAllSeq).Value = "W"
                                    ApprovalActionSelAll("CHECK_WIP_DTL", dgDetail.Rows(i).Cells(0).RowIndex, DtlChgUntPrcApvSelAllSeq)
                                End If
                            Case "BELOWMOQ"
                                If s = "Y" And dgDetail.Rows(i).Cells(DtlMOQApvSeq).Value = "W" Then
                                    dgDetail.Rows(i).Cells(DtlMOQApvSelAllSeq).Value = "Y"
                                    ApprovalActionSelAll("CHECK_APV_DTL", dgDetail.Rows(i).Cells(0).RowIndex, DtlMOQApvSelAllSeq)
                                ElseIf s = "W" And dgDetail.Rows(i).Cells(DtlMOQApvSeq).Value = "Y" Then
                                    dgDetail.Rows(i).Cells(DtlMOQApvSelAllSeq).Value = "W"
                                    ApprovalActionSelAll("CHECK_WIP_DTL", dgDetail.Rows(i).Cells(0).RowIndex, DtlMOQApvSelAllSeq)
                                End If
                            Case "ONETIME"
                                If s = "Y" And dgDetail.Rows(i).Cells(DtlOneTimeApvSeq).Value = "W" Then
                                    dgDetail.Rows(i).Cells(DtlOneTimeApvSelAllSeq).Value = "Y"
                                    ApprovalActionSelAll("CHECK_APV_DTL", dgDetail.Rows(i).Cells(0).RowIndex, DtlOneTimeApvSelAllSeq)
                                ElseIf s = "W" And dgDetail.Rows(i).Cells(DtlOneTimeApvSeq).Value = "Y" Then
                                    dgDetail.Rows(i).Cells(DtlOneTimeApvSelAllSeq).Value = "W"
                                    ApprovalActionSelAll("CHECK_WIP_DTL", dgDetail.Rows(i).Cells(0).RowIndex, DtlOneTimeApvSelAllSeq)
                                End If
                        End Select
                    End If
                End If
            Next i


            Dim dtlApvAllRevised As Boolean
            Dim dtlApvDtlRevised As Boolean

            dtlApvAllRevised = False
            dtlApvDtlRevised = False

            If dgDetail.SortedColumn Is Nothing Then
                dtlApvDtlRevised = False
                dtlApvAllRevised = False
            Else
                Select Case dgDetail.SortedColumn.Index
                    Case DtlApvSeq
                        dtlApvDtlRevised = False
                        dtlApvAllRevised = False
                    Case DtlMOQApvSeq, DtlMinMUApvSeq, DtlChgFtyCstApvSeq, DtlOneTimeApvSeq, DtlChgUntPrcApvSeq
                        If dgDetail.SortOrder = SortOrder.Ascending Then
                            dtlApvDtlRevised = True
                            dtlApvAllRevised = False
                        ElseIf dgDetail.SortOrder = SortOrder.Descending Then
                            dtlApvDtlRevised = False
                            dtlApvAllRevised = False
                        Else
                            dtlApvDtlRevised = False
                            dtlApvAllRevised = False
                        End If
                    Case Else
                        dtlApvDtlRevised = False
                        dtlApvAllRevised = False
                End Select
            End If



            If dtlApvDtlRevised = True Then
                For k = dgDetail.RowCount - 1 To 0 Step -1
                    dgDetail.Rows(k).Cells(DtlMOQApvSeq).Value = dgDetail.Rows(k).Cells(DtlMOQApvSelAllSeq).Value
                Next k
                For k = dgDetail.RowCount - 1 To 0 Step -1
                    dgDetail.Rows(k).Cells(DtlMinMUApvSeq).Value = dgDetail.Rows(k).Cells(DtlMinMUApvSelAllSeq).Value
                Next k
                For k = dgDetail.RowCount - 1 To 0 Step -1
                    dgDetail.Rows(k).Cells(DtlChgFtyCstApvSeq).Value = dgDetail.Rows(k).Cells(DtlChgFtyCstApvSelAllSeq).Value
                Next k
                For k = dgDetail.RowCount - 1 To 0 Step -1
                    dgDetail.Rows(k).Cells(DtlOneTimeApvSeq).Value = dgDetail.Rows(k).Cells(DtlOneTimeApvSelAllSeq).Value
                Next k
                For k = dgDetail.RowCount - 1 To 0 Step -1
                    dgDetail.Rows(k).Cells(DtlChgUntPrcApvSeq).Value = dgDetail.Rows(k).Cells(DtlChgUntPrcApvSelAllSeq).Value
                Next k
                For k = dgDetail.RowCount - 1 To 0 Step -1
                    dgDetail.Rows(k).Cells(DtlApvSeq).Value = dgDetail.Rows(k).Cells(DtlApvSelAllSeq).Value
                Next k
            Else
                For k = 0 To dgDetail.RowCount - 1
                    dgDetail.Rows(k).Cells(DtlMOQApvSeq).Value = dgDetail.Rows(k).Cells(DtlMOQApvSelAllSeq).Value
                Next k
                For k = 0 To dgDetail.RowCount - 1
                    dgDetail.Rows(k).Cells(DtlMinMUApvSeq).Value = dgDetail.Rows(k).Cells(DtlMinMUApvSelAllSeq).Value
                Next k
                For k = 0 To dgDetail.RowCount - 1
                    dgDetail.Rows(k).Cells(DtlChgFtyCstApvSeq).Value = dgDetail.Rows(k).Cells(DtlChgFtyCstApvSelAllSeq).Value
                Next k
                For k = 0 To dgDetail.RowCount - 1
                    dgDetail.Rows(k).Cells(DtlOneTimeApvSeq).Value = dgDetail.Rows(k).Cells(DtlOneTimeApvSelAllSeq).Value
                Next k
                For k = 0 To dgDetail.RowCount - 1
                    dgDetail.Rows(k).Cells(DtlChgUntPrcApvSeq).Value = dgDetail.Rows(k).Cells(DtlChgUntPrcApvSelAllSeq).Value
                Next k
                For k = 0 To dgDetail.RowCount - 1
                    dgDetail.Rows(k).Cells(DtlApvSeq).Value = dgDetail.Rows(k).Cells(DtlApvSelAllSeq).Value
                Next k
            End If

            dgDetail.ClearSelection()

            Dim curr_row As Boolean
            curr_row = False

            If dtlApvAllRevised = True Then
                For k = dgDetail.RowCount - 1 To 0 Step -1
                    If dgDetail.Rows(k).Cells(DtlKeepSelectSeq).Value = "Y" Then
                        If curr_row = False Then
                            dgDetail.CurrentCell = dgDetail.Rows(k).Cells(0)
                            curr_row = True
                        End If
                        dgDetail.Rows(k).Selected = True
                    End If
                Next k
            Else
                For k = 0 To dgDetail.RowCount - 1
                    If dgDetail.Rows(k).Cells(DtlKeepSelectSeq).Value = "Y" Then
                        If curr_row = False Then
                            dgDetail.CurrentCell = dgDetail.Rows(k).Cells(0)
                            curr_row = True
                        End If
                        dgDetail.Rows(k).Selected = True
                    End If
                Next k
            End If

        Else
            For i = 0 To dgDetail.RowCount - 1
                dgDetail.Rows(i).Cells(DtlKeepSelectSeq).Value = ""
            Next
            dgDetail.ClearSelection()
        End If



    End Sub


    Private Sub dgDetail_ActionClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetail.CellClick
        Dim selectColIndex As Integer
        Dim selectRowIndex As Integer


        If dgDetail.Focused = True And e.RowIndex >= 0 Then
            selectColIndex = e.ColumnIndex
            selectRowIndex = e.RowIndex

            Select Case e.ColumnIndex
                Case DtlApvSeq
                    If dgDetail.Rows(e.RowIndex).Cells(DtlApvCheckSeq).Value = "Fail" Then
                        MsgBox(dgDetail.Rows(e.RowIndex).Cells(DtlApvMsgSeq).Value.ToString())
                    Else
                        If dgDetail.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "W" Then
                            dgDetail.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "Y"
                            ApprovalAction("APV_ALL_DTL", e.RowIndex, e.ColumnIndex)

                            'check detail
                            Dim sFilter1 As String
                            Dim sFilter1_key As String
                            sFilter1_key = dgDetail.Rows(e.RowIndex).Cells("sod_ordno").Value
                            sFilter1 = "sod_ordno = '" & dgDetail.Rows(e.RowIndex).Cells("sod_ordno").Value & "'"
                            rs_SCM00006DTL.Tables("RESULT").DefaultView.RowFilter = sFilter1
                            dgDetail.DataSource = rs_SCM00006DTL.Tables("RESULT").DefaultView

                            Dim check_detail As Boolean
                            check_detail = True
                            If dgDetail.RowCount > 0 Then
                                For i As Integer = 0 To dgDetail.RowCount - 1
                                    If dgDetail.Rows(i).Cells(DtlApvSeq).Value = "W" Then
                                        check_detail = False
                                    End If
                                Next i
                            End If
                            sFilter1 = ""
                            rs_SCM00006DTL.Tables("RESULT").DefaultView.RowFilter = sFilter1
                            dgDetail.DataSource = rs_SCM00006DTL.Tables("RESULT").DefaultView

                            If check_detail = True Then
                                'check header
                                Dim sFilter2 As String
                                sFilter2 = "soh_ordno = '" & sFilter1_key & "'"
                                rs_SCM00006HDR.Tables("RESULT").DefaultView.RowFilter = sFilter2
                                dgHeader.DataSource = rs_SCM00006HDR.Tables("RESULT").DefaultView

                                If dgHeader.RowCount = 1 Then
                                    If (dgHeader.Rows(0).Cells(HdrPrcTrmApvSeq).Value = "Y" Or dgHeader.Rows(0).Cells(HdrPrcTrmApvSeq).Value = " ") And _
                                        (dgHeader.Rows(0).Cells(HdrPayTrmApvSeq).Value = "Y" Or dgHeader.Rows(0).Cells(HdrPayTrmApvSeq).Value = " ") And _
                                        (dgHeader.Rows(0).Cells(HdrRepOrdApvSeq).Value = "Y" Or dgHeader.Rows(0).Cells(HdrRepOrdApvSeq).Value = " ") And _
                                        (dgHeader.Rows(0).Cells(HdrCloOrdApvSeq).Value = "Y" Or dgHeader.Rows(0).Cells(HdrCloOrdApvSeq).Value = " ") Then
                                        dgHeader.Rows(0).Cells(HdrApvSeq).Value = "Y"
                                    End If
                                End If
                                sFilter2 = ""
                                rs_SCM00006HDR.Tables("RESULT").DefaultView.RowFilter = sFilter2
                                dgHeader.DataSource = rs_SCM00006HDR.Tables("RESULT").DefaultView
                            End If



                        ElseIf dgDetail.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "Y" Then
                            dgDetail.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "W"
                            ApprovalAction("WIP_ALL_DTL", e.RowIndex, e.ColumnIndex)
                            'check header
                            Dim sFilter3 As String
                            sFilter3 = "soh_ordno = '" & dgDetail.Rows(e.RowIndex).Cells("sod_ordno").Value & "'"
                            rs_SCM00006HDR.Tables("RESULT").DefaultView.RowFilter = sFilter3
                            dgHeader.DataSource = rs_SCM00006HDR.Tables("RESULT").DefaultView

                            If dgHeader.RowCount = 1 Then
                                If dgHeader.Rows(0).Cells(HdrApvSeq).Value = "Y" Then
                                    dgHeader.Rows(0).Cells(HdrApvSeq).Value = "W"
                                End If
                            End If
                            sFilter3 = ""
                            rs_SCM00006HDR.Tables("RESULT").DefaultView.RowFilter = sFilter3
                            dgHeader.DataSource = rs_SCM00006HDR.Tables("RESULT").DefaultView
                        End If
                    End If
                Case DtlChgFtyCstApvSeq, DtlMinMUApvSeq, DtlMOQApvSeq, DtlOneTimeApvSeq, DtlChgUntPrcApvSeq
                    If dgDetail.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = " " Then
                        ' do nothing
                    ElseIf dgDetail.Rows(e.RowIndex).Cells(DtlApvCheckSeq).Value = "Fail" Then
                        MsgBox(dgDetail.Rows(e.RowIndex).Cells(DtlApvMsgSeq).Value.ToString())
                    Else
                        If dgDetail.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "W" Then
                            dgDetail.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "Y"
                            ApprovalAction("CHECK_APV_DTL", e.RowIndex, e.ColumnIndex)
                        ElseIf dgDetail.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "Y" Then
                            dgDetail.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "W"
                            ApprovalAction("CHECK_WIP_DTL", e.RowIndex, e.ColumnIndex)
                        End If
                    End If
            End Select

            If selectRowIndex >= 0 And selectColIndex >= 0 Then
                dgDetail.CurrentCell = dgDetail.Rows(selectRowIndex).Cells(selectColIndex)
            End If
        End If

    End Sub

    Private Sub ApprovalAction(ByVal type As String, ByVal row As Integer, ByVal col As Integer)
        Select Case type
            Case "APV_ALL_HDR" 'h1
                If dgHeader.Rows(row).Cells(HdrPrcTrmApvSeq).Value = "W" Then
                    dgHeader.Rows(row).Cells(HdrPrcTrmApvSeq).Value = "Y"
                End If
                If dgHeader.Rows(row).Cells(HdrPayTrmApvSeq).Value = "W" Then
                    dgHeader.Rows(row).Cells(HdrPayTrmApvSeq).Value = "Y"
                End If
                If dgHeader.Rows(row).Cells(HdrRepOrdApvSeq).Value = "W" Then
                    dgHeader.Rows(row).Cells(HdrRepOrdApvSeq).Value = "Y"
                End If
                If dgHeader.Rows(row).Cells(HdrCloOrdApvSeq).Value = "W" Then
                    dgHeader.Rows(row).Cells(HdrCloOrdApvSeq).Value = "Y"
                End If
            Case "WIP_ALL_HDR" 'h2
                If dgHeader.Rows(row).Cells(HdrPrcTrmApvSeq).Value = "Y" Then
                    dgHeader.Rows(row).Cells(HdrPrcTrmApvSeq).Value = "W"
                End If
                If dgHeader.Rows(row).Cells(HdrPayTrmApvSeq).Value = "Y" Then
                    dgHeader.Rows(row).Cells(HdrPayTrmApvSeq).Value = "W"
                End If
                If dgHeader.Rows(row).Cells(HdrRepOrdApvSeq).Value = "Y" Then
                    dgHeader.Rows(row).Cells(HdrRepOrdApvSeq).Value = "W"
                End If
                If dgHeader.Rows(row).Cells(HdrCloOrdApvSeq).Value = "Y" Then
                    dgHeader.Rows(row).Cells(HdrCloOrdApvSeq).Value = "W"
                End If
            Case "CHECK_APV_HDR" 'h3
                'check header
                If (dgHeader.Rows(row).Cells(HdrPrcTrmApvSeq).Value = "Y" Or dgHeader.Rows(row).Cells(HdrPrcTrmApvSeq).Value = " ") And _
                    (dgHeader.Rows(row).Cells(HdrPayTrmApvSeq).Value = "Y" Or dgHeader.Rows(row).Cells(HdrPayTrmApvSeq).Value = " ") And _
                    (dgHeader.Rows(row).Cells(HdrRepOrdApvSeq).Value = "Y" Or dgHeader.Rows(row).Cells(HdrRepOrdApvSeq).Value = " ") And _
                    (dgHeader.Rows(row).Cells(HdrCloOrdApvSeq).Value = "Y" Or dgHeader.Rows(row).Cells(HdrCloOrdApvSeq).Value = " ") Then
                    'check detail
                    Dim sFilter_h3d As String
                    sFilter_h3d = "sod_ordno = '" & dgHeader.Rows(row).Cells("soh_ordno").Value & "'"
                    rs_SCM00006DTL.Tables("RESULT").DefaultView.RowFilter = sFilter_h3d
                    dgDetail.DataSource = rs_SCM00006DTL.Tables("RESULT").DefaultView

                    Dim check_detail As Boolean
                    check_detail = True
                    If dgDetail.RowCount > 0 Then
                        For i As Integer = 0 To dgDetail.RowCount - 1
                            If dgDetail.Rows(i).Cells(DtlApvSeq).Value = "W" Then
                                check_detail = False
                            End If
                        Next i
                    End If
                    sFilter_h3d = ""
                    rs_SCM00006DTL.Tables("RESULT").DefaultView.RowFilter = sFilter_h3d
                    dgDetail.DataSource = rs_SCM00006DTL.Tables("RESULT").DefaultView

                    If check_detail = True Then
                        dgHeader.Rows(row).Cells(HdrApvSeq).Value = "Y"
                    End If
                End If
            Case "CHECK_WIP_HDR" 'h4
                If Not ((dgHeader.Rows(row).Cells(HdrPrcTrmApvSeq).Value = "Y" Or dgHeader.Rows(row).Cells(HdrPrcTrmApvSeq).Value = " ") And _
                    (dgHeader.Rows(row).Cells(HdrPayTrmApvSeq).Value = "Y" Or dgHeader.Rows(row).Cells(HdrPayTrmApvSeq).Value = " ") And _
                    (dgHeader.Rows(row).Cells(HdrRepOrdApvSeq).Value = "Y" Or dgHeader.Rows(row).Cells(HdrRepOrdApvSeq).Value = " ") And _
                    (dgHeader.Rows(row).Cells(HdrCloOrdApvSeq).Value = "Y" Or dgHeader.Rows(row).Cells(HdrCloOrdApvSeq).Value = " ")) Then
                    dgHeader.Rows(row).Cells(HdrApvSeq).Value = "W"
                End If
            Case "APV_ALL_DTL" 'd1
                If dgDetail.Rows(row).Cells(DtlChgFtyCstApvSeq).Value = "W" Then
                    dgDetail.Rows(row).Cells(DtlChgFtyCstApvSeq).Value = "Y"
                End If
                If dgDetail.Rows(row).Cells(DtlMinMUApvSeq).Value = "W" Then
                    dgDetail.Rows(row).Cells(DtlMinMUApvSeq).Value = "Y"
                End If
                If dgDetail.Rows(row).Cells(DtlMOQApvSeq).Value = "W" Then
                    dgDetail.Rows(row).Cells(DtlMOQApvSeq).Value = "Y"
                End If
                If dgDetail.Rows(row).Cells(DtlOneTimeApvSeq).Value = "W" Then
                    dgDetail.Rows(row).Cells(DtlOneTimeApvSeq).Value = "Y"
                End If
                If dgDetail.Rows(row).Cells(DtlChgUntPrcApvSeq).Value = "W" Then
                    dgDetail.Rows(row).Cells(DtlChgUntPrcApvSeq).Value = "Y"
                End If
            Case "WIP_ALL_DTL" 'd2
                If dgDetail.Rows(row).Cells(DtlChgFtyCstApvSeq).Value = "Y" Then
                    dgDetail.Rows(row).Cells(DtlChgFtyCstApvSeq).Value = "W"
                End If
                If dgDetail.Rows(row).Cells(DtlMinMUApvSeq).Value = "Y" Then
                    dgDetail.Rows(row).Cells(DtlMinMUApvSeq).Value = "W"
                End If
                If dgDetail.Rows(row).Cells(DtlMOQApvSeq).Value = "Y" Then
                    dgDetail.Rows(row).Cells(DtlMOQApvSeq).Value = "W"
                End If
                If dgDetail.Rows(row).Cells(DtlOneTimeApvSeq).Value = "Y" Then
                    dgDetail.Rows(row).Cells(DtlOneTimeApvSeq).Value = "W"
                End If
                If dgDetail.Rows(row).Cells(DtlChgUntPrcApvSeq).Value = "Y" Then
                    dgDetail.Rows(row).Cells(DtlChgUntPrcApvSeq).Value = "W"
                End If
            Case "CHECK_APV_DTL" 'd3
                If (dgDetail.Rows(row).Cells(DtlChgFtyCstApvSeq).Value = "Y" Or dgDetail.Rows(row).Cells(DtlChgFtyCstApvSeq).Value = " ") And _
                   (dgDetail.Rows(row).Cells(DtlMinMUApvSeq).Value = "Y" Or dgDetail.Rows(row).Cells(DtlMinMUApvSeq).Value = " ") And _
                   (dgDetail.Rows(row).Cells(DtlMOQApvSeq).Value = "Y" Or dgDetail.Rows(row).Cells(DtlMOQApvSeq).Value = " ") And _
                   (dgDetail.Rows(row).Cells(DtlOneTimeApvSeq).Value = "Y" Or dgDetail.Rows(row).Cells(DtlOneTimeApvSeq).Value = " ") And _
                   (dgDetail.Rows(row).Cells(DtlChgUntPrcApvSeq).Value = "Y" Or dgDetail.Rows(row).Cells(DtlChgUntPrcApvSeq).Value = " ") Then
                    dgDetail.Rows(row).Cells(DtlApvSeq).Value = "Y"

                    'check detail
                    Dim sFilter_d3d As String
                    Dim sFilter_d3d_key As String
                    sFilter_d3d_key = dgDetail.Rows(row).Cells("sod_ordno").Value
                    sFilter_d3d = "sod_ordno = '" & sFilter_d3d_key & "'"
                    rs_SCM00006DTL.Tables("RESULT").DefaultView.RowFilter = sFilter_d3d
                    dgDetail.DataSource = rs_SCM00006DTL.Tables("RESULT").DefaultView

                    Dim check_detail As Boolean
                    check_detail = True
                    If dgDetail.RowCount > 0 Then
                        For i As Integer = 0 To dgDetail.RowCount - 1
                            If dgDetail.Rows(i).Cells(DtlApvSeq).Value = "W" Then
                                check_detail = False
                            End If
                        Next i
                    End If
                    sFilter_d3d = ""
                    rs_SCM00006DTL.Tables("RESULT").DefaultView.RowFilter = sFilter_d3d
                    dgDetail.DataSource = rs_SCM00006DTL.Tables("RESULT").DefaultView

                    If check_detail = True Then
                        'check header
                        Dim sFilter_d3h As String
                        sFilter_d3h = "soh_ordno = '" & sFilter_d3d_key & "'"
                        rs_SCM00006HDR.Tables("RESULT").DefaultView.RowFilter = sFilter_d3h
                        dgHeader.DataSource = rs_SCM00006HDR.Tables("RESULT").DefaultView

                        If dgHeader.RowCount = 1 Then
                            If (dgHeader.Rows(0).Cells(HdrPrcTrmApvSeq).Value = "Y" Or dgHeader.Rows(0).Cells(HdrPrcTrmApvSeq).Value = " ") And _
                                (dgHeader.Rows(0).Cells(HdrPayTrmApvSeq).Value = "Y" Or dgHeader.Rows(0).Cells(HdrPayTrmApvSeq).Value = " ") And _
                                (dgHeader.Rows(0).Cells(HdrRepOrdApvSeq).Value = "Y" Or dgHeader.Rows(0).Cells(HdrRepOrdApvSeq).Value = " ") And _
                                (dgHeader.Rows(0).Cells(HdrCloOrdApvSeq).Value = "Y" Or dgHeader.Rows(0).Cells(HdrCloOrdApvSeq).Value = " ") And _
                                dgHeader.Rows(0).Cells(HdrApvSeq).Value = "W" Then
                                dgHeader.Rows(0).Cells(HdrApvSeq).Value = "Y"
                            End If
                        End If
                        sFilter_d3h = ""
                        rs_SCM00006HDR.Tables("RESULT").DefaultView.RowFilter = sFilter_d3h
                        dgHeader.DataSource = rs_SCM00006HDR.Tables("RESULT").DefaultView
                    End If
                End If
            Case "CHECK_WIP_DTL" 'd4
                If Not ((dgDetail.Rows(row).Cells(DtlChgFtyCstApvSeq).Value = "Y" Or dgDetail.Rows(row).Cells(DtlChgFtyCstApvSeq).Value = " ") And _
                   (dgDetail.Rows(row).Cells(DtlMinMUApvSeq).Value = "Y" Or dgDetail.Rows(row).Cells(DtlMinMUApvSeq).Value = " ") And _
                   (dgDetail.Rows(row).Cells(DtlMOQApvSeq).Value = "Y" Or dgDetail.Rows(row).Cells(DtlMOQApvSeq).Value = " ") And _
                   (dgDetail.Rows(row).Cells(DtlOneTimeApvSeq).Value = "Y" Or dgDetail.Rows(row).Cells(DtlOneTimeApvSeq).Value = " ") And _
                   (dgDetail.Rows(row).Cells(DtlChgUntPrcApvSeq).Value = "Y" Or dgDetail.Rows(row).Cells(DtlChgUntPrcApvSeq).Value = " ")) Then
                    dgDetail.Rows(row).Cells(DtlApvSeq).Value = "W"
                    'check header
                    'check header
                    Dim sFilter_d4h As String
                    sFilter_d4h = "soh_ordno = '" & dgDetail.Rows(row).Cells("sod_ordno").Value & "'"
                    rs_SCM00006HDR.Tables("RESULT").DefaultView.RowFilter = sFilter_d4h
                    dgHeader.DataSource = rs_SCM00006HDR.Tables("RESULT").DefaultView

                    If dgHeader.RowCount = 1 Then
                        If dgHeader.Rows(0).Cells(HdrApvSeq).Value = "Y" Then
                            dgHeader.Rows(0).Cells(HdrApvSeq).Value = "W"
                        End If
                    End If
                    sFilter_d4h = ""
                    rs_SCM00006HDR.Tables("RESULT").DefaultView.RowFilter = sFilter_d4h
                    dgHeader.DataSource = rs_SCM00006HDR.Tables("RESULT").DefaultView
                End If

        End Select
    End Sub


    Private Sub ApprovalActionSelAll(ByVal type As String, ByVal row As Integer, ByVal col As Integer)
        Select Case type
            Case "APV_ALL_HDR" 'h1
                If dgHeader.Rows(row).Cells(HdrPrcTrmApvSelAllSeq).Value = "W" Then
                    dgHeader.Rows(row).Cells(HdrPrcTrmApvSelAllSeq).Value = "Y"
                End If
                If dgHeader.Rows(row).Cells(HdrPayTrmApvSelAllSeq).Value = "W" Then
                    dgHeader.Rows(row).Cells(HdrPayTrmApvSelAllSeq).Value = "Y"
                End If
                If dgHeader.Rows(row).Cells(HdrRepOrdApvSelAllSeq).Value = "W" Then
                    dgHeader.Rows(row).Cells(HdrRepOrdApvSelAllSeq).Value = "Y"
                End If
                If dgHeader.Rows(row).Cells(HdrCloOrdApvSelAllSeq).Value = "W" Then
                    dgHeader.Rows(row).Cells(HdrCloOrdApvSelAllSeq).Value = "Y"
                End If
            Case "WIP_ALL_HDR" 'h2
                If dgHeader.Rows(row).Cells(HdrPrcTrmApvSelAllSeq).Value = "Y" Then
                    dgHeader.Rows(row).Cells(HdrPrcTrmApvSelAllSeq).Value = "W"
                End If
                If dgHeader.Rows(row).Cells(HdrPayTrmApvSelAllSeq).Value = "Y" Then
                    dgHeader.Rows(row).Cells(HdrPayTrmApvSelAllSeq).Value = "W"
                End If
                If dgHeader.Rows(row).Cells(HdrRepOrdApvSelAllSeq).Value = "Y" Then
                    dgHeader.Rows(row).Cells(HdrRepOrdApvSelAllSeq).Value = "W"
                End If
                If dgHeader.Rows(row).Cells(HdrCloOrdApvSelAllSeq).Value = "Y" Then
                    dgHeader.Rows(row).Cells(HdrCloOrdApvSelAllSeq).Value = "W"
                End If
            Case "CHECK_APV_HDR" 'h3
                'check header
                If (dgHeader.Rows(row).Cells(HdrPrcTrmApvSelAllSeq).Value = "Y" Or dgHeader.Rows(row).Cells(HdrPrcTrmApvSelAllSeq).Value = " ") And _
                    (dgHeader.Rows(row).Cells(HdrPayTrmApvSelAllSeq).Value = "Y" Or dgHeader.Rows(row).Cells(HdrPayTrmApvSelAllSeq).Value = " ") And _
                    (dgHeader.Rows(row).Cells(HdrRepOrdApvSelAllSeq).Value = "Y" Or dgHeader.Rows(row).Cells(HdrRepOrdApvSelAllSeq).Value = " ") And _
                    (dgHeader.Rows(row).Cells(HdrCloOrdApvSelAllSeq).Value = "Y" Or dgHeader.Rows(row).Cells(HdrCloOrdApvSelAllSeq).Value = " ") Then
                    'check detail
                    Dim sFilter_h3d As String
                    sFilter_h3d = "sod_ordno = '" & dgHeader.Rows(row).Cells("soh_ordno").Value & "'"
                    rs_SCM00006DTL.Tables("RESULT").DefaultView.RowFilter = sFilter_h3d
                    dgDetail.DataSource = rs_SCM00006DTL.Tables("RESULT").DefaultView

                    Dim check_detail As Boolean
                    check_detail = True
                    If dgDetail.RowCount > 0 Then
                        For i As Integer = 0 To dgDetail.RowCount - 1
                            If dgDetail.Rows(i).Cells(DtlApvSeq).Value = "W" Then
                                check_detail = False
                            End If
                        Next i
                    End If
                    sFilter_h3d = ""
                    rs_SCM00006DTL.Tables("RESULT").DefaultView.RowFilter = sFilter_h3d
                    dgDetail.DataSource = rs_SCM00006DTL.Tables("RESULT").DefaultView

                    If check_detail = True Then
                        dgHeader.Rows(row).Cells(HdrApvSelAllSeq).Value = "Y"
                    End If
                End If
            Case "CHECK_WIP_HDR" 'h4
                If Not ((dgHeader.Rows(row).Cells(HdrPrcTrmApvSelAllSeq).Value = "Y" Or dgHeader.Rows(row).Cells(HdrPrcTrmApvSelAllSeq).Value = " ") And _
                    (dgHeader.Rows(row).Cells(HdrPayTrmApvSelAllSeq).Value = "Y" Or dgHeader.Rows(row).Cells(HdrPayTrmApvSelAllSeq).Value = " ") And _
                    (dgHeader.Rows(row).Cells(HdrRepOrdApvSelAllSeq).Value = "Y" Or dgHeader.Rows(row).Cells(HdrRepOrdApvSelAllSeq).Value = " ") And _
                    (dgHeader.Rows(row).Cells(HdrCloOrdApvSelAllSeq).Value = "Y" Or dgHeader.Rows(row).Cells(HdrCloOrdApvSelAllSeq).Value = " ")) Then
                    dgHeader.Rows(row).Cells(HdrApvSelAllSeq).Value = "W"
                End If
            Case "APV_ALL_DTL" 'd1
                If dgDetail.Rows(row).Cells(DtlChgFtyCstApvSelAllSeq).Value = "W" Then
                    dgDetail.Rows(row).Cells(DtlChgFtyCstApvSelAllSeq).Value = "Y"
                End If
                If dgDetail.Rows(row).Cells(DtlMinMUApvSelAllSeq).Value = "W" Then
                    dgDetail.Rows(row).Cells(DtlMinMUApvSelAllSeq).Value = "Y"
                End If
                If dgDetail.Rows(row).Cells(DtlMOQApvSelAllSeq).Value = "W" Then
                    dgDetail.Rows(row).Cells(DtlMOQApvSelAllSeq).Value = "Y"
                End If
                If dgDetail.Rows(row).Cells(DtlOneTimeApvSelAllSeq).Value = "W" Then
                    dgDetail.Rows(row).Cells(DtlOneTimeApvSelAllSeq).Value = "Y"
                End If
                If dgDetail.Rows(row).Cells(DtlChgUntPrcApvSelAllSeq).Value = "W" Then
                    dgDetail.Rows(row).Cells(DtlChgUntPrcApvSelAllSeq).Value = "Y"
                End If
            Case "WIP_ALL_DTL" 'd2
                If dgDetail.Rows(row).Cells(DtlChgFtyCstApvSelAllSeq).Value = "Y" Then
                    dgDetail.Rows(row).Cells(DtlChgFtyCstApvSelAllSeq).Value = "W"
                End If
                If dgDetail.Rows(row).Cells(DtlMinMUApvSelAllSeq).Value = "Y" Then
                    dgDetail.Rows(row).Cells(DtlMinMUApvSelAllSeq).Value = "W"
                End If
                If dgDetail.Rows(row).Cells(DtlMOQApvSelAllSeq).Value = "Y" Then
                    dgDetail.Rows(row).Cells(DtlMOQApvSelAllSeq).Value = "W"
                End If
                If dgDetail.Rows(row).Cells(DtlOneTimeApvSelAllSeq).Value = "Y" Then
                    dgDetail.Rows(row).Cells(DtlOneTimeApvSelAllSeq).Value = "W"
                End If
                If dgDetail.Rows(row).Cells(DtlChgUntPrcApvSelAllSeq).Value = "Y" Then
                    dgDetail.Rows(row).Cells(DtlChgUntPrcApvSelAllSeq).Value = "W"
                End If
            Case "CHECK_APV_DTL" 'd3
                If (dgDetail.Rows(row).Cells(DtlChgFtyCstApvSelAllSeq).Value = "Y" Or dgDetail.Rows(row).Cells(DtlChgFtyCstApvSelAllSeq).Value = " ") And _
                   (dgDetail.Rows(row).Cells(DtlMinMUApvSelAllSeq).Value = "Y" Or dgDetail.Rows(row).Cells(DtlMinMUApvSelAllSeq).Value = " ") And _
                   (dgDetail.Rows(row).Cells(DtlMOQApvSelAllSeq).Value = "Y" Or dgDetail.Rows(row).Cells(DtlMOQApvSelAllSeq).Value = " ") And _
                   (dgDetail.Rows(row).Cells(DtlOneTimeApvSelAllSeq).Value = "Y" Or dgDetail.Rows(row).Cells(DtlOneTimeApvSelAllSeq).Value = " ") And _
                   (dgDetail.Rows(row).Cells(DtlChgUntPrcApvSelAllSeq).Value = "Y" Or dgDetail.Rows(row).Cells(DtlChgUntPrcApvSelAllSeq).Value = " ") Then
                    dgDetail.Rows(row).Cells(DtlApvSelAllSeq).Value = "Y"

                    'check detail
                    Dim sFilter_d3d As String
                    Dim sFilter_d3d_key As String
                    sFilter_d3d_key = dgDetail.Rows(row).Cells("sod_ordno").Value
                    sFilter_d3d = "sod_ordno = '" & sFilter_d3d_key & "'"
                    rs_SCM00006DTL.Tables("RESULT").DefaultView.RowFilter = sFilter_d3d
                    dgDetail.DataSource = rs_SCM00006DTL.Tables("RESULT").DefaultView

                    Dim check_detail As Boolean
                    check_detail = True
                    If dgDetail.RowCount > 0 Then
                        For i As Integer = 0 To dgDetail.RowCount - 1
                            If dgDetail.Rows(i).Cells(DtlApvSelAllSeq).Value = "W" Then
                                check_detail = False
                            End If
                        Next i
                    End If
                    sFilter_d3d = ""
                    rs_SCM00006DTL.Tables("RESULT").DefaultView.RowFilter = sFilter_d3d
                    dgDetail.DataSource = rs_SCM00006DTL.Tables("RESULT").DefaultView

                    If check_detail = True Then
                        'check header
                        Dim sFilter_d3h As String
                        sFilter_d3h = "soh_ordno = '" & sFilter_d3d_key & "'"
                        rs_SCM00006HDR.Tables("RESULT").DefaultView.RowFilter = sFilter_d3h
                        dgHeader.DataSource = rs_SCM00006HDR.Tables("RESULT").DefaultView

                        If dgHeader.RowCount = 1 Then
                            If (dgHeader.Rows(0).Cells(HdrPrcTrmApvSeq).Value = "Y" Or dgHeader.Rows(0).Cells(HdrPrcTrmApvSeq).Value = " ") And _
                                (dgHeader.Rows(0).Cells(HdrPayTrmApvSeq).Value = "Y" Or dgHeader.Rows(0).Cells(HdrPayTrmApvSeq).Value = " ") And _
                                (dgHeader.Rows(0).Cells(HdrRepOrdApvSeq).Value = "Y" Or dgHeader.Rows(0).Cells(HdrRepOrdApvSeq).Value = " ") And _
                                (dgHeader.Rows(0).Cells(HdrCloOrdApvSeq).Value = "Y" Or dgHeader.Rows(0).Cells(HdrCloOrdApvSeq).Value = " ") And _
                                dgHeader.Rows(0).Cells(HdrApvSeq).Value = "W" Then
                                dgHeader.Rows(0).Cells(HdrApvSeq).Value = "Y"
                            End If
                        End If
                        sFilter_d3h = ""
                        rs_SCM00006HDR.Tables("RESULT").DefaultView.RowFilter = sFilter_d3h
                        dgHeader.DataSource = rs_SCM00006HDR.Tables("RESULT").DefaultView
                    End If
                End If
            Case "CHECK_WIP_DTL" 'd4
                If Not ((dgDetail.Rows(row).Cells(DtlChgFtyCstApvSelAllSeq).Value = "Y" Or dgDetail.Rows(row).Cells(DtlChgFtyCstApvSelAllSeq).Value = " ") And _
                   (dgDetail.Rows(row).Cells(DtlMinMUApvSelAllSeq).Value = "Y" Or dgDetail.Rows(row).Cells(DtlMinMUApvSelAllSeq).Value = " ") And _
                   (dgDetail.Rows(row).Cells(DtlMOQApvSelAllSeq).Value = "Y" Or dgDetail.Rows(row).Cells(DtlMOQApvSelAllSeq).Value = " ") And _
                   (dgDetail.Rows(row).Cells(DtlOneTimeApvSelAllSeq).Value = "Y" Or dgDetail.Rows(row).Cells(DtlOneTimeApvSelAllSeq).Value = " ") And _
                   (dgDetail.Rows(row).Cells(DtlChgUntPrcApvSelAllSeq).Value = "Y" Or dgDetail.Rows(row).Cells(DtlChgUntPrcApvSelAllSeq).Value = " ")) Then
                    dgDetail.Rows(row).Cells(DtlApvSelAllSeq).Value = "W"
                    'check header
                    'check header
                    Dim sFilter_d4h As String
                    sFilter_d4h = "soh_ordno = '" & dgDetail.Rows(row).Cells("sod_ordno").Value & "'"
                    rs_SCM00006HDR.Tables("RESULT").DefaultView.RowFilter = sFilter_d4h
                    dgHeader.DataSource = rs_SCM00006HDR.Tables("RESULT").DefaultView

                    If dgHeader.RowCount = 1 Then
                        If dgHeader.Rows(0).Cells(HdrApvSeq).Value = "Y" Then
                            dgHeader.Rows(0).Cells(HdrApvSeq).Value = "W"
                        End If
                    End If
                    sFilter_d4h = ""
                    rs_SCM00006HDR.Tables("RESULT").DefaultView.RowFilter = sFilter_d4h
                    dgHeader.DataSource = rs_SCM00006HDR.Tables("RESULT").DefaultView
                End If

        End Select
    End Sub




    Private Sub setStatus(ByVal mode As String)
        If mode = "INIT" Then
            cmdAdd.Enabled = False
            cmdSave.Enabled = False
            cmdDelete.Enabled = False
            cmdCopy.Enabled = False
            If gsUsrRank <= 4 Or gsUsrGrp = "MGT-S" Then
                cmdFind.Enabled = True
            Else
                cmdFind.Enabled = False
            End If
            cmdClear.Enabled = True
            cmdSearch.Enabled = False
            cmdInsRow.Enabled = False
            cmdDelRow.Enabled = False
            cmdFirst.Enabled = False
            cmdPrevious.Enabled = False
            cmdNext.Enabled = False
            cmdLast.Enabled = False
            cmdExit.Enabled = True

            rs_SCM00006DTL = Nothing
            rs_SCM00006DTL_ori = Nothing
            rs_SCM00006HDR = Nothing
            rs_SCM00006HDR_ori = Nothing

            dgHeader.DataSource = Nothing
            dgDetail.DataSource = Nothing

            tabFrame_Search.Enabled = True
            tabFrame_Header.Enabled = False
            tabFrame_Detail.Enabled = False

            txt_S_CoCde.Text = ""
            txt_S_PriCustAll.Text = ""
            txt_S_SecCustAll.Text = ""
            txt_S_SCNo.Text = ""
            txt_S_ItmNo.Text = ""
            'txtSCrvsdatFm.Text = "  /  /"
            'txtSCrvsdatTo.Text = "  /  /"
            txtSCRvsdatFm.Text = Format(DateAdd(DateInterval.Month, -1, Date.Now), "MM/dd/yyyy")
            txtSCRvsdatTo.Text = Format(Date.Now, "MM/dd/yyyy")

            optHdrAprvN.Checked = False
            optHdrAprvW.Checked = False
            optHdrAprvY.Checked = False

            optHdrAprvN.Enabled = False
            optHdrAprvW.Enabled = False
            optHdrAprvY.Enabled = False

            txtCoCde.Text = ""
            txtSCNo.Text = ""
            txtOrdSts.Text = ""
            txtRvsDat.Text = ""
            txtPriCus.Text = ""
            txtSecCus.Text = ""

            txtCoCde.Enabled = False
            txtSCNo.Enabled = False
            txtOrdSts.Enabled = False
            txtRvsDat.Enabled = False
            txtPriCus.Enabled = False
            txtSecCus.Enabled = False

            optDtlAprvN.Checked = False
            optDtlAprvW.Checked = False
            optDtlAprvY.Checked = False

            optDtlAprvN.Enabled = False
            optDtlAprvW.Enabled = False
            optDtlAprvY.Enabled = False

            tabFrame.SelectedTab = tabFrame_Search

            gspStr = "sp_select_SYMUSRCO '','" & gsUsrID & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_SYMUSRCO, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SCM00006_Load #001 sp_select_SYMUSRCO : " & rtnStr)
            Else
                Dim i As Integer
                Dim strCocde As String
                strCocde = ""

                If rs_SYMUSRCO.Tables("RESULT").Rows.Count > 0 Then
                    For i = 0 To rs_SYMUSRCO.Tables("RESULT").Rows.Count - 1
                        If rs_SYMUSRCO.Tables("RESULT").Rows(i).Item("yuc_cocde") <> "MS" Then
                            If i <> rs_SYMUSRCO.Tables("RESULT").Rows.Count - 1 Then
                                strCocde = strCocde + rs_SYMUSRCO.Tables("RESULT").Rows(i).Item("yuc_cocde") + ","
                            Else
                                strCocde = strCocde + rs_SYMUSRCO.Tables("RESULT").Rows(i).Item("yuc_cocde")
                            End If
                        End If
                    Next i
                End If

                Me.txt_S_CoCde.Text = strCocde
            End If


            rbHdrApvFilter_All.Checked = True
            rbDtlApvFilter_All.Checked = True

        ElseIf mode = "UPDATE" Then
            cmdAdd.Enabled = False
            cmdSave.Enabled = Enq_right_local
            cmdDelete.Enabled = False
            cmdCopy.Enabled = False
            cmdFind.Enabled = False
            cmdClear.Enabled = True
            cmdSearch.Enabled = False
            cmdInsRow.Enabled = False
            cmdDelRow.Enabled = False
            cmdFirst.Enabled = False
            cmdPrevious.Enabled = False
            cmdNext.Enabled = False
            cmdLast.Enabled = False
            cmdExit.Enabled = True

            tabFrame_Search.Enabled = False
            tabFrame_Header.Enabled = True
            tabFrame_Detail.Enabled = True

            optHdrAprvN.Enabled = False
            optHdrAprvW.Enabled = True
            optHdrAprvY.Enabled = True

            optDtlAprvN.Enabled = False
            optDtlAprvW.Enabled = True
            optDtlAprvY.Enabled = True

            tabFrame.SelectedTab = tabFrame_Header
        End If
    End Sub

    Private Sub rbHdrApvFilter_All_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbHdrApvFilter_All.CheckedChanged
        If rbHdrApvFilter_All.Checked = True Then
            display_Header("All")
        End If
    End Sub

    Private Sub rbHdrApvFilter_PriceTerm_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbHdrApvFilter_PriceTerm.CheckedChanged
        If rbHdrApvFilter_PriceTerm.Checked = True Then
            display_Header("PriceTerm")
        End If
    End Sub

    Private Sub rbHdrApvFilter_PaymentTerm_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbHdrApvFilter_PaymentTerm.CheckedChanged
        If rbHdrApvFilter_PaymentTerm.Checked = True Then
            display_Header("PaymentTerm")
        End If
    End Sub

    Private Sub rbHdrApvFilter_Replacement_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbHdrApvFilter_Replacement.CheckedChanged
        If rbHdrApvFilter_Replacement.Checked = True Then
            display_Header("Replacement")
        End If
    End Sub

    Private Sub rbHdrApvFilter_CloseOut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbHdrApvFilter_CloseOut.CheckedChanged
        If rbHdrApvFilter_CloseOut.Checked = True Then
            display_Header("CloseOut")
        End If
    End Sub


    Private Sub rbDtlApvFilter_MOQ_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDtlApvFilter_MOQ.CheckedChanged
        If rbDtlApvFilter_MOQ.Checked = True Then
            display_Detail("MOQMOA")
        End If
    End Sub

    Private Sub rbDtlApvFilter_All_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDtlApvFilter_All.CheckedChanged
        If rbDtlApvFilter_All.Checked = True Then
            display_Detail("All")
        End If
    End Sub

    Private Sub rbDtlApvFilter_BelowMinMU_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDtlApvFilter_BelowMinMU.CheckedChanged
        If rbDtlApvFilter_BelowMinMU.Checked = True Then
            display_Detail("BelPrc")
        End If
    End Sub

    Private Sub rbDtlApvFilter_OneTime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDtlApvFilter_OneTime.CheckedChanged
        If rbDtlApvFilter_OneTime.Checked = True Then
            display_Detail("OneTime")
        End If
    End Sub

    Private Sub rbDtlApvFilter_ChgDVPVFtyCst_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDtlApvFilter_ChgDVPVFtyCst.CheckedChanged
        If rbDtlApvFilter_ChgDVPVFtyCst.Checked = True Then
            display_Detail("ChgCst")
        End If
    End Sub

    Private Sub rbDtlApvFilter_ChgSelPrc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDtlApvFilter_ChgSelPrc.CheckedChanged
        If rbDtlApvFilter_ChgSelPrc.Checked = True Then
            display_Detail("ChgPrc")
        End If
    End Sub






End Class