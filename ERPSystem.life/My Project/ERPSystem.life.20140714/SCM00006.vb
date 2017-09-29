Public Class SCM00006

    Dim Del_right_local As Boolean
    Dim Enq_right_local As Boolean

    Dim rs_SCM00006DTL As DataSet
    Dim rs_SCM00006HDR As DataSet
    Dim rs_SCM00006DTL_ori As DataSet
    Dim rs_SCM00006HDR_ori As DataSet

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
        Dim response As Integer

        If checkChangesMade() = True Then
            response = MsgBox("Do you want to save the changes made?", MsgBoxStyle.YesNoCancel, "SCM00006 - Closing")
            If response = MsgBoxResult.Yes Then
                If cmdSave.Enabled = True Then
                    cmdSave.PerformClick()
                Else
                    MsgBox("You do not have authority to save changes", MsgBoxStyle.Critical, "SCM00006 - Saving")
                    e.Cancel = True
                End If
            ElseIf response = MsgBoxResult.Cancel Then
                e.Cancel = True
            End If
        End If
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
                                 rs_SCM00006DTL.Tables("RESULT").Rows(i)("action") & "','" & LCase(gsUsrID) & "'"
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
                                 rs_SCM00006HDR.Tables("RESULT").Rows(i)("action") & "','" & LCase(gsUsrID) & "'"
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

        If txt_S_PriCust.Text.Length > 1000 Then
            MsgBox("Primary Customer List is too long (1000 Char)")
            txt_S_PriCust.Focus()
            txt_S_PriCust.SelectAll()
            Exit Sub
        Else
            cus1no = Replace(Trim(txt_S_PriCust.Text), "'", "''")
        End If

        If txt_S_SecCust.Text.Length > 1000 Then
            MsgBox("Secondary Customer List is too long (1000 Char)")
            txt_S_SecCust.Focus()
            txt_S_SecCust.SelectAll()
            Exit Sub
        Else
            cus2no = Replace(Trim(txt_S_SecCust.Text), "'", "''")
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

        If rs_SCM00006DTL.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("No detail record found")
            Exit Sub
        End If

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        setStatus("UPDATE")
        tabFrame.SelectedTab = tabFrame_Header
        display_Header()
        tabFrame.SelectedTab = tabFrame_Detail
        display_Detail()
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
        frmComSearch.callFmCriteria = txt_S_PriCust.Name
        frmComSearch.callFmString = txt_S_PriCust.Text

        frmComSearch.show_frmS(Me.cmd_S_PriCust)
    End Sub

    Private Sub cmd_S_SecCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_SecCust.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_SecCust.Name
        frmComSearch.callFmString = txt_S_SecCust.Text

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
        If dgHeader.SelectedRows.Count = 0 Then
            MsgBox("No Rows have been selected", , "SCM00006 - Header")
            Exit Sub
        End If

        If optHdrAprvN.Checked = False And optHdrAprvW.Checked = False And optHdrAprvY.Checked = False Then
            MsgBox("No approval option has been selected", , "SCM00006 - Header")
            Exit Sub
        End If

        Dim approval As String = "W"
        If optHdrAprvN.Checked = True Then
            approval = "N"
        ElseIf optHdrAprvW.Checked = True Then
            approval = "W"
        ElseIf optHdrAprvY.Checked = True Then
            approval = "Y"
        End If

        'Dim detailRows() As DataRow
        For i As Integer = 0 To dgHeader.SelectedRows.Count - 1
            dgHeader.SelectedRows(i).Cells("action").Value = approval
        Next
    End Sub

    Private Sub cmdDtlSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDtlSelectAll.Click
        dgDetail.SelectAll()
    End Sub

    Private Sub cmdDtlApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDtlApply.Click
        If dgDetail.SelectedRows.Count = 0 Then
            MsgBox("No Rows have been selected", , "SCM00006 - Detail")
            Exit Sub
        End If

        If optDtlAprvN.Checked = False And optDtlAprvW.Checked = False And optDtlAprvY.Checked = False Then
            MsgBox("No approval option has been selected", , "SCM00006 - Detail")
            Exit Sub
        End If

        Dim approval As String = "W"
        If optDtlAprvN.Checked = True Then
            approval = "N"
        ElseIf optDtlAprvW.Checked = True Then
            approval = "W"
        ElseIf optDtlAprvY.Checked = True Then
            approval = "Y"
        End If

        For i As Integer = 0 To dgDetail.SelectedRows.Count - 1
            dgDetail.SelectedRows(i).Cells("action").Value = approval
        Next
    End Sub

    Private Sub display_Header()
        dgHeader.DataSource = rs_SCM00006HDR.Tables("RESULT").DefaultView
        With dgHeader
            For i As Integer = 0 To .Columns.Count - 1
                Select Case i
                    Case 0
                        .Columns(i).HeaderText = "Action"
                        .Columns(i).Width = 45
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Case 1
                        .Columns(i).HeaderText = "Company"
                        .Columns(i).Width = 60
                        .Columns(i).ReadOnly = True
                    Case 2
                        .Columns(i).HeaderText = "SC No"
                        .Columns(i).Width = 80
                        .Columns(i).ReadOnly = True
                    Case 3
                        .Columns(i).HeaderText = "Status"
                        .Columns(i).Width = 50
                        .Columns(i).ReadOnly = True
                    Case 5
                        .Columns(i).HeaderText = "Primary Customer"
                        .Columns(i).Width = 180
                        .Columns(i).ReadOnly = True
                    Case 7
                        .Columns(i).HeaderText = "Secondary Customer"
                        .Columns(i).Width = 180
                        .Columns(i).ReadOnly = True
                    Case 8
                        .Columns(i).HeaderText = "Revised Date"
                        .Columns(i).Width = 70
                        .Columns(i).ReadOnly = True
                    Case Else
                        .Columns(i).Visible = False
                End Select
            Next
        End With

        dgHeader.ClearSelection()
        dgHeader.CurrentCell = Nothing
        dgHeader.Refresh()
    End Sub

    Private Sub display_Detail()
        dgDetail.DataSource = rs_SCM00006DTL.Tables("RESULT").DefaultView
        With dgDetail
            For i As Integer = 0 To .Columns.Count - 1
                Select Case i
                    Case 0
                        .Columns(i).HeaderText = "Action"
                        .Columns(i).Width = 45
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Case 2
                        .Columns(i).HeaderText = "SC No"
                        .Columns(i).Width = 80
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
                        .Columns(i).Width = 130
                        .Columns(i).ReadOnly = True
                    Case 17
                        .Columns(i).HeaderText = "Below MOQ/MOA"
                        .Columns(i).Width = 65
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Case 18
                        .Columns(i).HeaderText = "Below Basic/MinMU"
                        .Columns(i).Width = 80
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Case 19
                        .Columns(i).HeaderText = "CCY"
                        .Columns(i).Width = 45
                        .Columns(i).ReadOnly = True
                    Case 20
                        .Columns(i).HeaderText = "Price"
                        .Columns(i).Width = 50
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Case 21
                        .Columns(i).HeaderText = "Selling Price"
                        .Columns(i).Width = 50
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Case 23
                        .Columns(i).HeaderText = "Order CTN"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case 24
                        .Columns(i).HeaderText = "MOQ"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
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
                    If row(0)("action") <> rs_SCM00006HDR.Tables("RESULT").Rows(i)("action") Then
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
                    If row(0)("action") <> rs_SCM00006DTL.Tables("RESULT").Rows(i)("action") Then
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

    Private Sub dgHeader_ActionClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgHeader.CellClick
        If dgHeader.Focused = True And e.RowIndex >= 0 Then
            If e.ColumnIndex = 0 Then
                If dgHeader.Rows(e.RowIndex).Cells("action").Value = "W" Then
                    dgHeader.Rows(e.RowIndex).Cells("action").Value = "Y"
                ElseIf dgHeader.Rows(e.RowIndex).Cells("action").Value = "Y" Then
                    dgHeader.Rows(e.RowIndex).Cells("action").Value = "W"
                End If
            End If
        End If
    End Sub

    Private Sub dgHeader_ActionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgHeader.CellValueChanged
        If cmdHdrApply.Focused = True Or dgHeader.Focused = True Then
            Dim approval As String
            approval = dgHeader.Rows(e.RowIndex).Cells("action").Value

            Dim detailRows() As DataRow
            detailRows = rs_SCM00006DTL.Tables("RESULT").Select("sod_ordno = '" & dgHeader.Rows(e.RowIndex).Cells("soh_ordno").Value & "'")
            If detailRows.Length > 0 Then
                For i As Integer = 0 To detailRows.Length - 1
                    detailRows(i).Item("action") = approval
                Next
            End If
        End If
    End Sub

    Private Sub dgDetail_ActionClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetail.CellClick
        If dgDetail.Focused = True And e.RowIndex >= 0 Then
            If e.ColumnIndex = 0 Then
                If dgDetail.Rows(e.RowIndex).Cells("action").Value = "W" Then
                    dgDetail.Rows(e.RowIndex).Cells("action").Value = "Y"
                ElseIf dgDetail.Rows(e.RowIndex).Cells("action").Value = "Y" Then
                    dgDetail.Rows(e.RowIndex).Cells("action").Value = "W"
                End If
            End If
        End If
    End Sub

    Private Sub dgDetail_ActioneChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetail.CellValueChanged
        If cmdDtlApply.Focused = True Or dgDetail.Focused = True Then
            Dim approval As String
            approval = dgDetail.Rows(e.RowIndex).Cells("action").Value

            Dim headerRows() As DataRow
            headerRows = rs_SCM00006HDR.Tables("RESULT").Select("soh_ordno = '" & dgDetail.Rows(e.RowIndex).Cells("sod_ordno").Value & "'")
            If headerRows.Length > 0 Then
                If approval = "W" Then
                    For i As Integer = 0 To headerRows.Length - 1
                        headerRows(i).Item("action") = approval
                    Next
                ElseIf approval = "Y" Then
                    Dim detailRows() As DataRow
                    detailRows = rs_SCM00006DTL.Tables("RESULT").Select("sod_ordno = '" & dgDetail.Rows(e.RowIndex).Cells("sod_ordno").Value & "'")
                    If detailRows.Length > 0 Then
                        For i As Integer = 0 To detailRows.Length - 1
                            If detailRows(i).Item("action") = "W" Then
                                Exit Sub
                            End If
                        Next

                        For j As Integer = 0 To headerRows.Length - 1
                            headerRows(j).Item("action") = approval
                        Next
                    End If
                End If
            End If
        End If
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
            txt_S_PriCust.Text = ""
            txt_S_SecCust.Text = ""
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
End Class