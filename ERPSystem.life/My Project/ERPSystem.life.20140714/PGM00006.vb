Public Class PGM00006

    Dim Del_right_local As Boolean
    Dim Enq_right_local As Boolean
    Dim rs_PGM00006HDR As DataSet
    Dim rs_PGM00006HDR_ori As DataSet
    Dim rs_PGM00006DTL As DataSet
    Dim rs_PGM00006DTL_ori As DataSet

    Private Sub PGM00006_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim response As Integer

        If checkChangesMade() = True Then
            response = MsgBox("Do you want to save the changes made?", MsgBoxStyle.YesNoCancel, "PGM00006 - Closing")
            If response = MsgBoxResult.Yes Then
                If cmdSave.Enabled = True Then
                    cmdSave.PerformClick()
                Else
                    MsgBox("You do not have authority to save changes", MsgBoxStyle.Critical, "PGM00006 - Saving")
                    e.Cancel = True
                End If
            ElseIf response = MsgBoxResult.Cancel Then
                e.Cancel = True
            End If
        End If
    End Sub
    Private Sub PGM00006_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)
        AccessRight(Me.Name)
        Enq_right_local = Enq_right
        Del_right_local = Del_right




        setStatus("INIT")


        Dim rs_load As DataSet
        Dim strCocde As String = ""

        gspStr = "sp_select_SYMUSRCO '" & gsCompany & "','" & gsUsrID & "'"

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rs_load = Nothing
        rtnLong = execute_SQLStatement(gspStr, rs_load, rtnStr)
        gspStr = ""
        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading #001 sp_select_SYMUSRCO : " & rtnStr)
            Exit Sub
        Else
            If rs_load.Tables("RESULT").Rows.Count > 0 Then
                For i As Integer = 0 To rs_load.Tables("RESULT").Rows.Count - 1
                    If rs_load.Tables("RESULT").Rows(i)("yuc_cocde") <> "MS" Then
                        strCocde = strCocde & IIf(strCocde.Length > 0, ",", "") & rs_load.Tables("RESULT").Rows(i)("yuc_cocde")
                        If gsCompany = "" Then
                            gsCompany = rs_load.Tables("RESULT").Rows(i)("yuc_cocde")
                        End If
                    ElseIf gsDefaultCompany = "MS" Then
                        strCocde = "MS"
                    End If
                Next
            End If
        End If

        If gsDefaultCompany = "MS" Then
            txt_S_CoCde.Text = "MS"
            gsCompany = "MS"
        Else
            txt_S_CoCde.Text = strCocde
        End If

    End Sub



    Private Sub setStatus(ByVal mode As String)
        If mode = "INIT" Then
            cmdAdd.Enabled = False
            cmdSave.Enabled = False
            cmdDelete.Enabled = False
            cmdCopy.Enabled = False
            'If gsUsrRank <= 4 Or gsUsrGrp = "MGT-S" Then 'Wt right
            cmdFind.Enabled = True
            'Else
            '   cmdFind.Enabled = False
            'End If
            cmdClear.Enabled = True
            cmdSearch.Enabled = False
            cmdInsRow.Enabled = False
            cmdDelRow.Enabled = False
            cmdFirst.Enabled = False
            cmdPrevious.Enabled = False
            cmdNext.Enabled = False
            cmdLast.Enabled = False
            cmdExit.Enabled = True

            rs_PGM00006DTL = Nothing
            rs_PGM00006DTL_ori = Nothing
            rs_PGM00006HDR = Nothing
            rs_PGM00006HDR_ori = Nothing

            dgHeader.DataSource = Nothing
            dgDetail.DataSource = Nothing

            tabFrame_Search.Enabled = True
            tabFrame_Header.Enabled = False
            tabFrame_Detail.Enabled = False

            'txt_S_CoCde.Text = ""
            txt_S_PriCust.Text = ""
            txt_S_SecCust.Text = ""
            txt_S_PKGNo.Text = ""
            txt_S_ItmNo.Text = ""
            txt_S_PV.Text = ""
            'txtSCIssdatFm.Text = "  /  /"
            'txtSCIssdatTo.Text = "  /  /"
            txtSCIssdatFm.Text = Format(DateAdd(DateInterval.Month, -1, Date.Now), "MM/dd/yyyy")
            txtSCIssdatTo.Text = Format(Date.Now, "MM/dd/yyyy")

            optHdrAprvN.Checked = False
            optHdrAprvW.Checked = False
            optHdrAprvY.Checked = False

            optHdrAprvN.Enabled = False
            optHdrAprvW.Enabled = False
            optHdrAprvY.Enabled = False

            'txtCoCde.Text = ""
            txtPONo.Text = ""
            txtOrdSts.Text = ""
            txtIssDat.Text = ""
            txtPriCus.Text = ""
            txtSecCus.Text = ""
            txtDtlSCNo.Text = ""
            txtDtlTONo.Text = ""
            txtpkgitm.Text = ""

            txtCoCde.Enabled = False
            txtPONo.Enabled = False
            txtOrdSts.Enabled = False
            txtIssDat.Enabled = False
            txtPriCus.Enabled = False
            txtSecCus.Enabled = False
            txtDtlSCNo.Enabled = False
            txtDtlTONo.Enabled = False
            txtpkgitm.Enabled = False

            optDtlAprvN.Checked = False
            optDtlAprvW.Checked = False
            optDtlAprvY.Checked = False

            optDtlAprvN.Enabled = False
            optDtlAprvW.Enabled = False
            optDtlAprvY.Enabled = False

            optRpt1.Checked = False
            optRpt2.Checked = False
            optRpt3.Checked = False

            optRpt1.Enabled = False
            optRpt2.Enabled = False
            optRpt3.Enabled = False

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

            optRpt1.Enabled = False
            optRpt2.Enabled = False
            optRpt3.Enabled = False

            tabFrame.SelectedTab = tabFrame_Header
        End If
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

    Private Sub cmd_S_SCNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_PKGNo.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_PKGNo.Name
        frmComSearch.callFmString = txt_S_PKGNo.Text

        frmComSearch.show_frmS(Me.cmd_S_PKGNo)
    End Sub

    Private Sub cmd_S_ItmNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_ItmNo.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_ItmNo.Name
        frmComSearch.callFmString = txt_S_ItmNo.Text

        frmComSearch.show_frmS(Me.cmd_S_ItmNo)
    End Sub

    Private Sub cmd_S_PV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_S_PV.Click
        Dim frmComSearch As New frmComSearch

        frmComSearch.callFmForm = Me.Name
        frmComSearch.callFmCriteria = txt_S_PV.Name
        frmComSearch.callFmString = txt_S_PV.Text

        frmComSearch.show_frmS(Me.cmd_S_PV)
    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        Dim cocde As String
        Dim cus1no As String
        Dim cus2no As String
        Dim ordno As String
        Dim itmno As String
        Dim PV As String
        Dim issdatFm As String
        Dim issdatTo As String

        'If gsUsrRank > 4 And gsUsrGrp <> "MGT-S" Then
        '    MsgBox("You do not have the rights to use this feature.", MsgBoxStyle.Critical, "SCM00006 - Access Rights")
        '    Exit Sub
        'End If

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

        If txt_S_PKGNo.Text.Length > 1000 Then
            MsgBox("Order No List is too long (1000 Char)")
            txt_S_PKGNo.Focus()
            txt_S_PKGNo.SelectAll()
            Exit Sub
        Else
            ordno = Replace(Trim(txt_S_PKGNo.Text), "'", "''")
        End If

        If txt_S_ItmNo.Text.Length > 1000 Then
            MsgBox("Item No List is too long (1000 Char)")
            txt_S_ItmNo.Focus()
            txt_S_ItmNo.SelectAll()
            Exit Sub
        Else
            itmno = Replace(Trim(txt_S_ItmNo.Text), "'", "''")
        End If


        If txt_S_PV.Text.Length > 1000 Then
            MsgBox("PV List is too long (1000 Char)")
            txt_S_PV.Focus()
            txt_S_PV.SelectAll()
            Exit Sub
        Else
            PV = Replace(Trim(txt_S_PV.Text), "'", "''")
        End If


        If txtSCIssdatFm.Text = "  /  /" Then
            MsgBox("Issue Date (From) cannot be empty")
            txtSCIssdatFm.Focus()
            txtSCIssdatFm.SelectAll()
            Exit Sub
        Else
            If txtSCIssdatFm.Text.Length <> 10 Or IsDate(txtSCIssdatFm.Text) = False Then
                MsgBox("Invalid Issue Date (From)")
                txtSCIssdatFm.Focus()
                txtSCIssdatFm.SelectAll()
                Exit Sub
            End If
        End If

        If txtSCIssdatTo.Text = "  /  /" Then
            MsgBox("Issue Date (To) cannot be empty")
            txtSCIssdatTo.Focus()
            txtSCIssdatTo.SelectAll()
            Exit Sub
        Else
            If txtSCIssdatTo.Text.Length <> 10 Or IsDate(txtSCIssdatTo.Text) = False Then
                MsgBox("Invalid Issue Date (To)")
                txtSCIssdatTo.Focus()
                txtSCIssdatTo.SelectAll()
                Exit Sub
            End If
        End If

        If CDate(txtSCIssdatFm.Text) > CDate(txtSCIssdatTo.Text) Then
            MsgBox("Issue Date (From) > Issue End Date (To)")
            txtSCIssdatFm.Focus()
            txtSCIssdatFm.SelectAll()
            Exit Sub
        End If

        issdatFm = txtSCIssdatFm.Text
        issdatTo = txtSCIssdatTo.Text

        gspStr = "sp_select_PGM00006_HDR '','" & cocde & "','" & cus1no & "','" & cus2no & "','" & _
                 ordno & "','" & itmno & "','" & PV & "','" & issdatFm & "','" & issdatTo & "','" & gsUsrID & "'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_PGM00006HDR, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Error on loading PGM00006 #001 sp_select_PGM00006_HDR : " & rtnStr)
            Exit Sub
        Else
            For i As Integer = 0 To rs_PGM00006HDR.Tables("RESULT").Columns.Count - 1
                rs_PGM00006HDR.Tables("RESULT").Columns(i).ReadOnly = False
            Next
            rs_PGM00006HDR_ori = rs_PGM00006HDR.Copy()
        End If

        If rs_PGM00006HDR.Tables("RESULT").Rows.Count = 0 Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("No record found")
            Exit Sub
        End If

        gspStr = "sp_select_PGM00006_DTL '','" & cocde & "','" & cus1no & "','" & cus2no & "','" & _
                     ordno & "','" & itmno & "','" & PV & "','" & issdatFm & "','" & issdatTo & "','" & gsUsrID & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_PGM00006DTL, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SCM00006 #002 sp_select_PGM00006_DTL : " & rtnStr)
            Exit Sub
        Else
            For i As Integer = 0 To rs_PGM00006DTL.Tables("RESULT").Columns.Count - 1
                rs_PGM00006DTL.Tables("RESULT").Columns(i).ReadOnly = False
            Next
            rs_PGM00006DTL_ori = rs_PGM00006DTL.Copy()
        End If

        If rs_PGM00006DTL.Tables("RESULT").Rows.Count = 0 Then
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
    Private Sub display_Header()
        dgHeader.DataSource = rs_PGM00006HDR.Tables("RESULT").DefaultView
        With dgHeader
            For i As Integer = 0 To .Columns.Count - 1
                Select Case i
                    Case 0
                        .Columns(i).HeaderText = "Act"
                        .Columns(i).Width = 30
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Case 1
                        .Columns(i).HeaderText = "Comp"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case 2
                        .Columns(i).HeaderText = "Ord No"
                        .Columns(i).Width = 70
                        .Columns(i).ReadOnly = True
                    Case 3
                        .Columns(i).HeaderText = "Status"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case 4
                        .Columns(i).HeaderText = "Ver"
                        .Columns(i).Width = 25
                        .Columns(i).ReadOnly = True
                    Case 5
                        .Columns(i).HeaderText = "Printer"
                        .Columns(i).Width = 180
                        .Columns(i).ReadOnly = True
                    Case 6
                        .Columns(i).HeaderText = "Issue Date"
                        .Columns(i).Width = 70
                        .Columns(i).ReadOnly = True
                    Case 7
                        .Columns(i).HeaderText = "Revised Date"
                        .Columns(i).Width = 70
                        .Columns(i).ReadOnly = True
                    Case 8
                        .Columns(i).HeaderText = "Curr"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case 9
                        .Columns(i).HeaderText = "Order Amt"
                        .Columns(i).Width = 80
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        '.Columns(i).DefaultCellStyle.Format = "#.00"
                        .Columns(i).ReadOnly = True
                    Case 10
                        .Columns(i).HeaderText = "Delivery Amt"
                        .Columns(i).Width = 80
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        '.Columns(i).DefaultCellStyle.Format = "#.00"
                        .Columns(i).ReadOnly = True
                    Case 11
                        .Columns(i).HeaderText = "Total Order Amt"
                        .Columns(i).Width = 80
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        '.Columns(i).DefaultCellStyle.Format = "#.00"
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
        dgDetail.DataSource = rs_PGM00006DTL.Tables("RESULT").DefaultView
        With dgDetail
            For i As Integer = 0 To .Columns.Count - 1
                Select Case i
                    Case 0
                        .Columns(i).HeaderText = "Act"
                        .Columns(i).Width = 30
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Case 1
                        .Columns(i).HeaderText = "Comp"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case 2
                        .Columns(i).HeaderText = "Ord No"
                        .Columns(i).Width = 70
                        .Columns(i).ReadOnly = True
                    Case 3
                        .Columns(i).HeaderText = "Seq"
                        .Columns(i).Width = 20
                        .Columns(i).ReadOnly = True
                    Case 4
                        .Columns(i).HeaderText = "Status"
                        .Columns(i).Width = 30
                        .Columns(i).ReadOnly = True
                    Case 5
                        .Columns(i).HeaderText = "Printer"
                        .Columns(i).Width = 90
                        .Columns(i).ReadOnly = True
                    Case 6
                        .Columns(i).HeaderText = "Pkg Item"
                        .Columns(i).Width = 80
                        .Columns(i).ReadOnly = True
                    Case 7
                        .Columns(i).HeaderText = "Desc"
                        .Columns(i).Width = 100
                        .Columns(i).ReadOnly = True
                    Case 8
                        .Columns(i).HeaderText = "Ord Qty"
                        .Columns(i).Width = 50
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(i).ReadOnly = True
                    Case 9
                        .Columns(i).HeaderText = "Wast age"
                        .Columns(i).Width = 40
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(i).ReadOnly = True
                    Case 10
                        .Columns(i).HeaderText = "Stk Qty"
                        .Columns(i).Width = 50
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(i).ReadOnly = True
                    Case 11
                        .Columns(i).HeaderText = "Ttl Qty"
                        .Columns(i).Width = 50
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(i).ReadOnly = True
                    Case 12
                        .Columns(i).HeaderText = "UM"
                        .Columns(i).Width = 30
                        .Columns(i).ReadOnly = True
                    Case 13
                        .Columns(i).HeaderText = "Curr"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case 14
                        .Columns(i).HeaderText = "Unit Prc"
                        .Columns(i).Width = 50
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        '.Columns(i).DefaultCellStyle.Format = "#.00"
                        .Columns(i).ReadOnly = True
                    Case 15
                        .Columns(i).HeaderText = "Ttl Amt"
                        .Columns(i).Width = 60
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        '.Columns(i).DefaultCellStyle.Format = "#.00"
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

    Private Sub dgHeader_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgHeader.CellClick
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

    Private Sub dgHeader_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgHeader.CellContentClick

    End Sub

    Private Sub dgHeader_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgHeader.CellValueChanged
        If cmdHdrApply.Focused = True Or dgHeader.Focused = True Then
            Dim approval As String
            approval = dgHeader.Rows(e.RowIndex).Cells("action").Value

            Dim detailRows() As DataRow
            detailRows = rs_PGM00006DTL.Tables("RESULT").Select("pod_ordno = '" & dgHeader.Rows(e.RowIndex).Cells("poh_ordno").Value & "'")
            If detailRows.Length > 0 Then
                For i As Integer = 0 To detailRows.Length - 1
                    detailRows(i).Item("action") = approval
                Next
            End If
        End If
    End Sub

    Private Sub cmdHdrSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHdrSelectAll.Click
        dgHeader.SelectAll()
    End Sub

    Private Sub cmdHdrApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHdrApply.Click
        If dgHeader.SelectedRows.Count = 0 Then
            MsgBox("No Rows have been selected", , "PGM00006 - Header")
            Exit Sub
        End If

        If optHdrAprvN.Checked = False And optHdrAprvW.Checked = False And optHdrAprvY.Checked = False Then
            MsgBox("No approval option has been selected", , "PGM00006 - Header")
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
            MsgBox("No Rows have been selected", , "PGM00006 - Detail")
            Exit Sub
        End If

        If optDtlAprvN.Checked = False And optDtlAprvW.Checked = False And optDtlAprvY.Checked = False Then
            MsgBox("No approval option has been selected", , "PGM00006 - Detail")
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

    Private Sub dgDetail_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetail.CellClick
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

    Private Sub dgDetail_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetail.CellContentClick

    End Sub

    Private Sub dgDetail_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetail.CellValueChanged
        If cmdDtlApply.Focused = True Or dgDetail.Focused = True Then
            Dim approval As String
            approval = dgDetail.Rows(e.RowIndex).Cells("action").Value

            Dim headerRows() As DataRow
            headerRows = rs_PGM00006HDR.Tables("RESULT").Select("poh_ordno = '" & dgDetail.Rows(e.RowIndex).Cells("pod_ordno").Value & "'")
            If headerRows.Length > 0 Then
                If approval = "W" Then
                    For i As Integer = 0 To headerRows.Length - 1
                        headerRows(i).Item("action") = approval
                    Next
                ElseIf approval = "Y" Then
                    Dim detailRows() As DataRow
                    detailRows = rs_PGM00006DTL.Tables("RESULT").Select("pod_ordno = '" & dgDetail.Rows(e.RowIndex).Cells("pod_ordno").Value & "'")
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

    Private Sub dgDetail_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetail.RowEnter
        If sender.Focused = True Then
            txtCoCde.Text = dgDetail.Rows(e.RowIndex).Cells("pod_cocde").Value
            txtPONo.Text = dgDetail.Rows(e.RowIndex).Cells("pod_ordno").Value
            txtOrdSts.Text = dgDetail.Rows(e.RowIndex).Cells("pod_status").Value
            txtIssDat.Text = dgDetail.Rows(e.RowIndex).Cells("poh_issdat").Value
            txtPriCus.Text = dgDetail.Rows(e.RowIndex).Cells("pri_cusnam").Value
            txtSecCus.Text = dgDetail.Rows(e.RowIndex).Cells("sec_cusnam").Value

            ' new field to be added Marco
            txtDtlSCNo.Text = dgDetail.Rows(e.RowIndex).Cells("prd_ScToNo").Value
            txtDtlTONo.Text = ""
            txtpkgitm.Text = dgDetail.Rows(e.RowIndex).Cells("pod_pkgitm").Value
            rpt_option("ENABLE")
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim before() As DataRow
        Dim rs_sql As DataSet

        ' Saving Detail
        For i As Integer = 0 To rs_PGM00006DTL.Tables("RESULT").Rows.Count - 1
            before = Nothing
            before = rs_PGM00006DTL_ori.Tables("RESULT").Select("pod_ordno = '" & rs_PGM00006DTL.Tables("RESULT").Rows(i)("pod_ordno") & "' and " & _
                                                                "pod_seq = '" & rs_PGM00006DTL.Tables("RESULT").Rows(i)("pod_seq") & "'")
            If before.Length > 0 Then
                If checkChangesMade(before(0), rs_PGM00006DTL.Tables("RESULT").Rows(i)) = True Then
                    If checkTimestamp(rs_PGM00006DTL.Tables("RESULT").Rows(i), "DTL") = True Then
                        gspStr = "sp_update_PGM00006_DTL '" & rs_PGM00006DTL.Tables("RESULT").Rows(i)("pod_cocde") & "','" & _
                                 rs_PGM00006DTL.Tables("RESULT").Rows(i)("pod_ordno") & "','" & _
                                 rs_PGM00006DTL.Tables("RESULT").Rows(i)("pod_seq") & "','" & _
                                 rs_PGM00006DTL.Tables("RESULT").Rows(i)("action") & "','" & LCase(gsUsrID) & "'"
                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        rtnLong = execute_SQLStatement(gspStr, rs_sql, rtnStr)
                        Me.Cursor = Windows.Forms.Cursors.Default
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading PGM00006 #004 sp_update_PGM00006_DTL : " & rtnStr)
                            Exit Sub
                        End If
                    Else
                        MsgBox("The record has been modified by other users. Please refresh and try again.", MsgBoxStyle.Exclamation, "PGM00006 - Overwrite Warning (DETAIL)")
                        Exit Sub
                    End If
                End If
            Else
                MsgBox("Missing original detail entry")
                Exit Sub
            End If
        Next

        ' Saving Detail
        For i As Integer = 0 To rs_PGM00006HDR.Tables("RESULT").Rows.Count - 1
            before = Nothing
            before = rs_PGM00006HDR_ori.Tables("RESULT").Select("poh_ordno = '" & rs_PGM00006HDR.Tables("RESULT").Rows(i)("poh_ordno") & "'")

            If before.Length > 0 Then
                If checkChangesMade(before(0), rs_PGM00006HDR.Tables("RESULT").Rows(i)) = True Then
                    If checkTimestamp(rs_PGM00006HDR.Tables("RESULT").Rows(i), "HDR") = True Then
                        gspStr = "sp_update_PGM00006_HDR '" & rs_PGM00006HDR.Tables("RESULT").Rows(i)("poh_cocde") & "','" & _
                                 rs_PGM00006HDR.Tables("RESULT").Rows(i)("poh_ordno") & "','" & _
                                 rs_PGM00006HDR.Tables("RESULT").Rows(i)("action") & "','" & LCase(gsUsrID) & "'"
                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        rtnLong = execute_SQLStatement(gspStr, rs_sql, rtnStr)
                        Me.Cursor = Windows.Forms.Cursors.Default
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading PGM00006 #005 sp_update_PGM00006_HDR : " & rtnStr)
                            Exit Sub
                        End If
                    Else
                        MsgBox("The record has been modified by other users. Please refresh and try again.", MsgBoxStyle.Exclamation, "PGM00006 - Overwrite Warning (HEADER)")
                        Exit Sub
                    End If
                End If
            End If
        Next

        MsgBox("Save Complete")
        setStatus("INIT")
    End Sub


    Private Function checkChangesMade() As Boolean
        If rs_PGM00006DTL Is Nothing And rs_PGM00006DTL_ori Is Nothing And rs_PGM00006HDR Is Nothing And rs_PGM00006HDR_ori Is Nothing Then
            Return False
        End If

        Dim row() As DataRow

        If rs_PGM00006HDR.Tables("RESULT").Rows.Count > 0 Then
            For i As Integer = 0 To rs_PGM00006HDR.Tables("RESULT").Rows.Count - 1
                row = Nothing
                row = rs_PGM00006HDR_ori.Tables("RESULT").Select("poh_ordno = '" & rs_PGM00006HDR.Tables("RESULT").Rows(i)("poh_ordno") & "'")
                If row.Length > 0 Then
                    If row(0)("action") <> rs_PGM00006HDR.Tables("RESULT").Rows(i)("action") Then
                        Return True
                    End If
                Else
                    Return True
                End If
            Next
        Else
            Return False
        End If

        If rs_PGM00006DTL.Tables("RESULT").Rows.Count > 0 Then
            For i As Integer = 0 To rs_PGM00006DTL.Tables("RESULT").Rows.Count - 1
                row = Nothing
                row = rs_PGM00006DTL_ori.Tables("RESULT").Select("pod_ordno = '" & rs_PGM00006DTL.Tables("RESULT").Rows(i)("pod_ordno") & "' and " & _
                                                                 "pod_seq = '" & rs_PGM00006DTL.Tables("RESULT").Rows(i)("pod_seq") & "'")
                If row.Length > 0 Then
                    If row(0)("action") <> rs_PGM00006DTL.Tables("RESULT").Rows(i)("action") Then
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
            gspStr = "sp_select_PGM00006_timstp '','" & UCase(mode) & "','" & row("poh_ordno") & "','','" & gsUsrID & "'"
        ElseIf UCase(mode) = "DTL" Then
            gspStr = "sp_select_PGM00006_timstp '','" & UCase(mode) & "','" & row("pod_ordno") & "','" & row("pod_seq") & "','" & gsUsrID & "'"
        Else
            Return False
        End If

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_timstp, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Error on loading PGM00006 #003 sp_select_PGM00006_timstp : " & rtnStr)
            Exit Function
        Else
            If rs_timstp.Tables("RESULT").Rows.Count > 0 Then
                'If UCase(mode) = "HDR" Then
                '    If row("poh_timstp") = rs_timstp.Tables("RESULT").Rows(0)("poh_timstp") Then
                '        Return True
                '    Else
                '        Return False
                '    End If
                'ElseIf UCase(mode) = "DTL" Then
                '    If row("pod_timstp") = rs_timstp.Tables("RESULT").Rows(0)("pod_timstp") Then
                '        Return True
                '    Else
                '        Return False
                '    End If
                'End If   Cancel at 05/23/2014 casuse sp cant handel
            Else
                Return False
            End If
        End If

        Return True '< Always true Change at 05/23/2014 casuse sp cant handel

    End Function


    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        If checkChangesMade() = True Then
            Dim response As Integer
            response = MsgBox("Changes have been made. Would you like to save changes before clearing?", MsgBoxStyle.YesNoCancel)

            If response = MsgBoxResult.Yes Then
                If cmdSave.Enabled = True Then
                    cmdSave.PerformClick()
                    Exit Sub
                Else
                    MsgBox("You do not have authority to save changes", MsgBoxStyle.Critical, "PGM00006 - Saving")
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

    Private Sub rpt_option(ByVal mode As String)
        optRpt1.Checked = False
        optRpt1.Checked = False
        optRpt1.Checked = False

        If mode = "ENABLE" Then
            If txtDtlSCNo.Text <> "" Then
                optRpt1.Enabled = True
                optRpt1.Checked = True
            Else
                optRpt1.Enabled = False
                optRpt1.Checked = False
            End If

            If txtPONo.Text <> "" Then
                optRpt2.Enabled = True
            Else
                optRpt2.Enabled = False
            End If

            If txtpkgitm.Text <> "" Then
                optRpt3.Enabled = True
            Else
                optRpt3.Enabled = False
            End If
        Else
            optRpt1.Enabled = False
            optRpt2.Enabled = False
            optRpt3.Enabled = False
        End If
    End Sub


    Private Sub cmdRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRpt.Click


        If optRpt1.Checked = True Then
            Dim rs_PKA00001 As DataSet

            gspStr = "sp_select_PKA00001 '" & txtCoCde.Text & "','" & txtDtlSCNo.Text & "'"

            rs_PKA00001 = Nothing

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_PKA00001, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading sp_select_PKA00001 : " & rtnStr)
                Exit Sub
            Else
                For i As Integer = 0 To rs_PKA00001.Tables("RESULT").Columns.Count - 1
                    rs_PKA00001.Tables("RESULT").Columns(i).ReadOnly = False
                Next
            End If

            If rs_PKA00001.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("No Record Found", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim objRpt As New PKA00001Rpt
            objRpt.Database.Tables("PKA00001").SetDataSource(rs_PKA00001.Tables("RESULT"))
            Dim frmReportView As New frmReport
            frmReportView.CrystalReportViewer.ReportSource = objRpt
            frmReportView.Show()
        ElseIf optRpt2.Checked = True Then
            Dim rs_PKA00002 As DataSet

            gspStr = "sp_select_PKA00002 '" & txtCoCde.Text & "','" & txtPONo.Text & "'"

            rs_PKA00002 = Nothing

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_PKA00002, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading sp_select_PKA00002 : " & rtnStr)
                Exit Sub
            Else
                For i As Integer = 0 To rs_PKA00002.Tables("RESULT").Columns.Count - 1
                    rs_PKA00002.Tables("RESULT").Columns(i).ReadOnly = False
                Next
            End If

            If rs_PKA00002.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("No Record Found", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim objRpt As New PKA00002Rpt
            objRpt.Database.Tables("PKA00002").SetDataSource(rs_PKA00002.Tables("RESULT"))
            Dim frmReportView As New frmReport
            frmReportView.CrystalReportViewer.ReportSource = objRpt
            frmReportView.Show()
        ElseIf optRpt3.Checked = True Then
            Dim rs_PKA00003 As DataSet

            gspStr = "sp_select_PKA00003 '" & txtCoCde.Text & "','" & txtpkgitm.Text & "'"

            rs_PKA00003 = Nothing

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_PKA00003, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading sp_select_PKA00003 : " & rtnStr)
                Exit Sub
            Else
                For i As Integer = 0 To rs_PKA00003.Tables("RESULT").Columns.Count - 1
                    rs_PKA00003.Tables("RESULT").Columns(i).ReadOnly = False
                Next
            End If

            If rs_PKA00003.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("No Record Found", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim objRpt As New PKA00003Rpt
            objRpt.Database.Tables("PKA00003").SetDataSource(rs_PKA00003.Tables("RESULT"))
            Dim frmReportView As New frmReport
            frmReportView.CrystalReportViewer.ReportSource = objRpt
            frmReportView.Show()

        End If

    End Sub
End Class