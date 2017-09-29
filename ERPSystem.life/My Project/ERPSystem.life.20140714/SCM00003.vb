Imports Microsoft.Office.Interop

Public Class SCM00003

    Const strModule As String = "SC"

    Private Enum enumProc
        eCheckSCSts = 1
        eUnReleaseSC
        eUpdateSC
        eReleaseSC
        eReleasePO
        eEmpty
    End Enum

    Dim itmLst As frmItemList

    Dim r As DataSet
    Dim rs As DataSet
    Dim rs_ErrLog As DataSet

    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean
    Dim strJobOrdList As String

    Private Sub SCM00003_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)
        AccessRight(Me.Name)
        Enq_right_local = Enq_right
        Del_right_local = Del_right

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        Me.KeyPreview = True

        If gsCompanyGroup = "MSG" Then
            If gsCompany <> "MS" Then
                gsCompany = "MS"
                Update_gs_Value(gsCompany)
            End If
        Else
            '--- Update Company Code before execute ---
            If gsCompany = "ALL" Or gsCompany = "UC-G" Then
                gsCompany = gsDefaultCompany
                Update_gs_Value(gsCompany)
            End If
            '-----------------------------------------
        End If
        ClearValue()
        setStatus("Init")

        Me.Cursor = Windows.Forms.Cursors.Default
        cmdExportLog.Visible = False
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If Not r Is Nothing Then
            If r.Tables("RESULT").Rows.Count > 0 Then
                Dim dr() As DataRow = r.Tables("RESULT").Select("sbe_apprv = 'Y'")
                If dr.Length > 0 Then
                    For i As Integer = 0 To dr.Length - 1
                        gspStr = "sp_update_SCFDBEXP '" & gsCompany & "','U','" & dr(i).Item("sbe_lotno").ToString & _
                                 "','" & dr(i).Item("sbe_filename").ToString & "','" & dr(i).Item("sbe_jobord").ToString & _
                                 "','" & dr(i).Item("abe_apprv").ToString & "'"

                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        rs = Nothing
                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        Me.Cursor = Windows.Forms.Cursors.Default
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on saving SCM00003 #002 sp_update_SCFDBEXP : " & rtnStr)
                        End If
                    Next

                    GetData()
                    setStatus("Save")
                    MsgBox("Update Successfully.")
                    SetErrLogGrid()
                Else
                    MsgBox("Please select records to update.")
                    grdSummary.DataSource = Nothing
                    grdSummary.DataSource = r.Tables("RESULT").DefaultView
                    SetSummaryGrid()
                End If
            End If
        End If
    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        gspStr = "sp_select_SCFDBEXP '" & gsCompany & "','','N','" & gsUsrID & "','" & strModule & "'"

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        gspStr = execute_SQLStatement(gspStr, rs, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SCM00003 #001 sp_select_SCFDBEXP : " & rtnStr)
            Exit Sub
        Else
            r = rs.Copy()
            rs_ErrLog = rs.Clone()
            If r.Tables("RESULT").Rows.Count > 0 Then
                fillCount()
                SetSBPanel()
                grdSummary.DataSource = Nothing
                grdSummary.DataSource = r.Tables("RESULT").DefaultView
                SetSummaryGrid()

                setStatus("Updating")

                grdSummary.ClearSelection()
            Else
                MsgBox("No exception found.")

            End If
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        grdSummary.DataSource = Nothing
        lblLeft.Text = ""
        lblRight.Text = ""
        ClearValue()
        setStatus("Init")
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Close()
    End Sub

    Private Sub ClearValue()
        txtFromApply.Text = "0"
        txtToApply.Text = "0"
        optYes.Checked = True
        rs_ErrLog = Nothing
        r = Nothing
    End Sub

    Private Sub setStatus(ByVal Mode As String)
        If Mode = "Init" Then
            cmdAdd.Enabled = False
            cmdSave.Enabled = False
            cmdDelete.Enabled = False
            cmdCopy.Enabled = False
            cmdFind.Enabled = True
            cmdInsRow.Enabled = False
            cmdDelRow.Enabled = False
            cmdExit.Enabled = True
            cmdClear.Enabled = True
            cmdSearch.Enabled = False
            cmdFirst.Enabled = False
            cmdLast.Enabled = False
            cmdNext.Enabled = False
            cmdPrevious.Enabled = False
            tabFrame.TabPages(1).Enabled = False
            tabFrame.TabPages(0).Enabled = True
            tabFrame.SelectTab(0)
            cmdExportExp.Enabled = False
            cmdExportLog.Enabled = False
            grpUpdate.Enabled = False
            grpJobOrd.Enabled = False
            strJobOrdList = ""

            lblLeft.Text = ""
            lblRight.Text = ""
        ElseIf Mode = "Updating" Then
            cmdAdd.Enabled = False
            cmdSave.Enabled = Enq_right_local
            cmdDelete.Enabled = False
            cmdCopy.Enabled = False
            cmdFind.Enabled = True
            cmdInsRow.Enabled = False
            cmdDelRow.Enabled = False
            cmdExit.Enabled = True
            cmdClear.Enabled = True
            cmdSearch.Enabled = False
            cmdFirst.Enabled = False
            cmdLast.Enabled = False
            cmdNext.Enabled = False
            cmdPrevious.Enabled = False
            tabFrame.TabPages(1).Enabled = False
            tabFrame.TabPages(0).Enabled = True
            tabFrame.SelectTab(0)
            cmdExportExp.Enabled = True
            cmdExportLog.Enabled = True
            grpUpdate.Enabled = True
            grpJobOrd.Enabled = True
        ElseIf Mode = "Save" Then
            setStatus("Init")
            cmdClear.Enabled = True
            cmdFind.Enabled = False
        ElseIf Mode = "Delete" Then

        ElseIf Mode = "Clear" Then

        End If
    End Sub

    Private Sub fillCount()
        If Not r Is Nothing Then
            If r.Tables("RESULT").Rows.Count > 0 Then
                r.Tables("RESULT").Columns("reccount").ReadOnly = False
                For i As Integer = 0 To r.Tables("RESULT").Rows.Count - 1
                    r.Tables("RESULT").Rows(i)("reccount") = i + 1
                Next
                r.Tables("RESULT").Columns("reccount").ReadOnly = True
                txtFromApply.Text = "1"
                txtToApply.Text = CStr(r.Tables("RESULT").Rows.Count)
            Else
                txtFromApply.Text = "0"
                txtToApply.Text = "0"
            End If
        End If
    End Sub

    Private Sub SetSBPanel()
        Dim strTotal As String = "0"
        Dim strAppr As String = "0"

        If Not r Is Nothing Then
            If r.Tables("RESULT").Rows.Count > 0 Then
                strTotal = CStr(r.Tables("RESULT").Rows.Count)
            End If
        End If

        If strAppr = "0" Then
            lblLeft.Text = strTotal & " record(s) found."
        Else
            lblLeft.Text = strTotal & " record(s) found. " & strAppr & " record(s) is/are approved."
        End If

    End Sub

    Private Sub SetSummaryGrid()

        Dim intCol As Integer
        intCol = 0
        With grdSummary
            For i As Integer = 0 To grdSummary.Columns.Count - 1
                .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                Select Case i
                    Case 0
                        .Columns(i).HeaderText = ""
                        .Columns(i).Width = 50
                        .Columns(i).ReadOnly = True
                    Case 1
                        .Columns(i).HeaderText = "Apprv"
                        .Columns(i).Width = 60
                        .Columns(i).ReadOnly = True
                    Case 7
                        .Columns(i).HeaderText = "Exp. Typ."
                        .Columns(i).Width = 140
                        .Columns(i).ReadOnly = True
                    Case 12
                        .Columns(i).HeaderText = "Co. Cde."
                        .Columns(i).Width = 65
                        .Columns(i).ReadOnly = True
                    Case 13
                        .Columns(i).HeaderText = "SC. Sts."
                        .Columns(i).Width = 60
                        .Columns(i).ReadOnly = True
                    Case 14
                        .Columns(i).HeaderText = "SC No."
                        .Columns(i).Width = 85
                        .Columns(i).ReadOnly = True
                    Case 15
                        .Columns(i).HeaderText = "Cus No."
                        .Columns(i).Width = 110
                        .Columns(i).ReadOnly = True
                    Case 16
                        .Columns(i).HeaderText = "Job. Ord."
                        .Columns(i).Width = 100
                        .Columns(i).ReadOnly = True
                    Case 17
                        .Columns(i).HeaderText = "Itm. No."
                        .Columns(i).Width = 100
                        .Columns(i).ReadOnly = True
                    Case 18
                        .Columns(i).HeaderText = "Fty. UM"
                        .Columns(i).Width = 50
                        .Columns(i).ReadOnly = True
                    Case 19
                        .Columns(i).HeaderText = "Fty. Inr."
                        .Columns(i).Width = 5
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Case 20
                        .Columns(i).HeaderText = "Fty. Mtr."
                        .Columns(i).Width = 55
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Case 21
                        .Columns(i).HeaderText = "HK UM"
                        .Columns(i).Width = 50
                        .Columns(i).ReadOnly = True
                    Case 22
                        .Columns(i).HeaderText = "HK Inr."
                        .Columns(i).Width = 50
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Case 23
                        .Columns(i).HeaderText = "HK Mtr."
                        .Columns(i).Width = 50
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Case 24
                        .Columns(i).HeaderText = "Ord. Qty."
                        .Columns(i).Width = 85
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Case 25
                        .Columns(i).HeaderText = "Shp. Qty."
                        .Columns(i).Width = 85
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Case 26
                        .Columns(i).HeaderText = "O/S Qty."
                        .Columns(i).Width = 85
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Case 27
                        .Columns(i).HeaderText = "Fty. CV"
                        .Columns(i).Width = 85
                        .Columns(i).ReadOnly = True
                    Case 28
                        .Columns(i).HeaderText = "HK CV"
                        .Columns(i).Width = 85
                        .Columns(i).ReadOnly = True
                    Case 30
                        .Columns(i).HeaderText = "Fty. PV"
                        .Columns(i).Width = 85
                        .Columns(i).ReadOnly = True
                    Case 31
                        .Columns(i).HeaderText = "HK PV"
                        .Columns(i).Width = 85
                        .Columns(i).ReadOnly = True
                    Case 33
                        .Columns(i).HeaderText = "Fty. ZI03 Curr."
                        .Columns(i).Width = 85
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Case 34
                        .Columns(i).HeaderText = "Fty. ZI03"
                        .Columns(i).Width = 70
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Case 35
                        .Columns(i).HeaderText = "HK DV Fty. Prc. Curr."
                        .Columns(i).Width = 85
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Case 36
                        .Columns(i).HeaderText = "HK DV Fty. Prc."
                        .Columns(i).Width = 70
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Case 37
                        .Columns(i).HeaderText = "Fty. ZI01 Curr."
                        .Columns(i).Width = 85
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Case 38
                        .Columns(i).HeaderText = "Fty. ZI01"
                        .Columns(i).Width = 70
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Case 39
                        .Columns(i).HeaderText = "HK PV Fty. Prc. Curr."
                        .Columns(i).Width = 85
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Case 40
                        .Columns(i).HeaderText = "HK PV Fty. Prc."
                        .Columns(i).Width = 70
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Case 41
                        .Columns(i).HeaderText = "Fty. ZI02 Curr."
                        .Columns(i).Width = 85
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Case 42
                        .Columns(i).HeaderText = "Fty. ZI02"
                        .Columns(i).Width = 70
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Case 43
                        .Columns(i).HeaderText = "Fty. ZI04 Curr."
                        .Columns(i).Width = 85
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Case 44
                        .Columns(i).HeaderText = "Fty. ZI04"
                        .Columns(i).Width = 70
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Case 45
                        .Columns(i).HeaderText = "Fty. ZI05 Curr."
                        .Columns(i).Width = 85
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Case 46
                        .Columns(i).HeaderText = "Fty. ZI05"
                        .Columns(i).Width = 70
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Case 47
                        .Columns(i).HeaderText = "PO Shp. Str."
                        .Columns(i).Width = 85
                        .Columns(i).ReadOnly = True
                    Case 48
                        .Columns(i).HeaderText = "PO Shp. End"
                        .Columns(i).Width = 85
                        .Columns(i).ReadOnly = True
                    Case 49
                        .Columns(i).HeaderText = "Fty. SAP SO No."
                        .Columns(i).Width = 85
                        .Columns(i).ReadOnly = True
                    Case 50
                        .Columns(i).HeaderText = "Fty. SAP SO Ln."
                        .Columns(i).Width = 85
                        .Columns(i).ReadOnly = True
                    Case 51
                        .Columns(i).HeaderText = "HK SAP SO No."
                        .Columns(i).Width = 85
                        .Columns(i).ReadOnly = True
                    Case 52
                        .Columns(i).HeaderText = "HK SAP SO Ln."
                        .Columns(i).Width = 85
                        .Columns(i).ReadOnly = True
                    Case Else
                        .Columns(i).Visible = False
                End Select
            Next
        End With

        grdSummary.ClearSelection()
    End Sub

    Private Sub grdSummary_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdSummary.CellClick
        If grdSummary.SelectedCells.Count = 1 Then
            If grdSummary.CurrentCell.ColumnIndex = 1 Then
                If r.Tables("RESULT").Rows(grdSummary.CurrentCell.RowIndex)("tmp_ordsts") <> "REL" Then
                    MsgBox("SC not in release status.")
                    Exit Sub
                End If
                ' ZI01 = 0
                If r.Tables("RESULT").Rows(grdSummary.CurrentCell.RowIndex)("tmp_fty01prc") = 0 Then
                    MsgBox("ZI01 prc is 0.")
                    Exit Sub
                End If

                If r.Tables("RESULT").Rows(grdSummary.CurrentCell.RowIndex)("yet_cde") = "04" Or _
                   r.Tables("RESULT").Rows(grdSummary.CurrentCell.RowIndex)("yet_cde") = "08" Then
                    MsgBox("System cannot determine CV.")
                    Exit Sub
                End If

                r.Tables("RESULT").Columns("sbe_apprv").ReadOnly = False
                r.Tables("RESULT").Columns("sbe_updusr").ReadOnly = False
                If r.Tables("RESULT").Rows(grdSummary.CurrentCell.RowIndex)("sbe_apprv") = "N" Then
                    r.Tables("RESULT").Rows(grdSummary.CurrentCell.RowIndex)("sbe_apprv") = "Y"
                ElseIf r.Tables("RESULT").Rows(grdSummary.CurrentCell.RowIndex)("sbe_apprv") = "Y" Then
                    r.Tables("RESULT").Rows(grdSummary.CurrentCell.RowIndex)("sbe_apprv") = "N"
                End If
                r.Tables("RESULT").Rows(grdSummary.CurrentCell.RowIndex)("sbe_updusr") = "*~UPD~*"
                r.Tables("RESULT").Columns("sbe_apprv").ReadOnly = True
                r.Tables("RESULT").Columns("sbe_updusr").ReadOnly = True

                SetSBPanel()
            End If
        End If
    End Sub

    Private Sub GetData()

        Dim r_scno As DataSet

        gspStr = "sp_select_SCFDBEXP '" & gsCompany & "','','Y','" & gsUsrID & "','" & strModule & "'"
        rs = Nothing
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        '*** An error has occured
        If rtnLong <> RC_SUCCESS Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Error on loading SCM00003 #003 sp_select_SCFDBEXP : " & rtnStr)
            Exit Sub
        Else
            r_scno = rs.Copy()
        End If


        If r_scno.Tables("RESULT").Rows.Count > 0 Then
            Dim dr_scno() As DataRow = r_scno.Tables("RESULT").Select("tmp_do = 'Y'")

            If dr_scno.Length > 0 Then
                Dim dr() As DataRow
                For i As Integer = 0 To dr_scno.Length - 1
                    dr = Nothing
                    dr = r.Tables("RESULT").Select("sbe_apprv = 'Y' and tmp_cocde = '" & dr_scno(i).Item("tmp_cocde") & "' and tmp_scno = '" & dr_scno(i).Item("tmp_scno") & "'")

                    If dr.Length > 0 Then
                        CheckSCSts(dr_scno(i).Item("tmp_cocde"), dr_scno(i).Item("tmp_scno"), dr)
                    End If
                Next
            End If

            dr_scno = Nothing
            dr_scno = r_scno.Tables("RESULT").Select("tmp_do = 'N'")

            If dr_scno.Length > 0 Then
                Dim dr() As DataRow
                For i As Integer = 0 To dr_scno.Length - 1
                    dr = Nothing
                    dr = r.Tables("RESULT").Select("sbe_apprv = 'Y' and tmp_cocde = '" & dr_scno(i).Item("tmp_cocde") & "' and tmp_scno = '" & dr_scno(i).Item("tmp_scno") & "'")

                    If dr.Length > 0 Then
                        RemoveApprvRec(dr(0).Item("sbe_lotno"), dr(0).Item("sbe_filename"), dr(0).Item("sbe_jobord"))
                        SetErrLog(dr(0).Item("tmp_cocde"), dr(0).Item("sbe_jobord"), "Update is not required.", enumProc.eEmpty)
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub SetErrLogGrid()
        If Not rs_ErrLog Is Nothing Then
            If rs_ErrLog.Tables("RESULT").Rows.Count > 0 Then

                tabFrame.TabPages(1).Enabled = True
                tabFrame.TabPages(0).Enabled = False
                tabFrame.SelectTab(1)

                grdErrLog.DataSource = Nothing
                grdErrLog.DataSource = rs_ErrLog.Tables("RESULT").DefaultView

                With grdErrLog
                    For i As Integer = 0 To grdErrLog.Columns.Count - 1
                        .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                        Select Case i
                            Case 2
                                .Columns(i).HeaderText = "Co. Cde"
                                .Columns(i).Width = 80
                                .Columns(i).ReadOnly = True
                            Case 5
                                .Columns(i).HeaderText = "Doc. No."
                                .Columns(i).Width = 150
                                .Columns(i).ReadOnly = True
                            Case 7
                                .Columns(i).HeaderText = "Msg."
                                .Columns(i).Width = 400
                                .Columns(i).ReadOnly = True
                            Case 15
                                .Columns(i).HeaderText = "Proc."
                                .Columns(i).Width = 120
                                .Columns(i).ReadOnly = True
                            Case Else
                                .Columns(i).Visible = False
                        End Select
                    Next
                End With
                lblLeft.Text = CStr(rs_ErrLog.Tables("RESULT").Rows.Count) & " log(s) found."
            Else
                cmdClear.PerformClick()
            End If
        Else
            cmdClear.PerformClick()
        End If

        grdErrLog.ClearSelection()

    End Sub

    Private Sub CheckSCSts(ByVal strCocde As String, ByVal strSCNo As String, ByVal dr_details() As DataRow)
        ' This Section is to check the sc whether is in 'Release' Status
        Dim r_tmp As DataSet
        Dim S As String

        gsCompany = strCocde
        Update_gs_Value(gsCompany)

        S = "sp_select_SCORDHDRR '" & gsCompany & "','" & strSCNo & "','" & strSCNo & "','N'"
        rs = Nothing
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        '*** An error has occured
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SCM00003 #004 sp_select_SCORDHDRR : " & rtnStr)
            Exit Sub
        Else
            r_tmp = rs.Copy()

            If r_tmp.Tables("RESULT").Rows.Count > 0 Then
                ' SC not in "Release" Status
                SetErrLog(strCocde, strSCNo, "SC not in Release Status.", enumProc.eCheckSCSts)

                For i As Integer = 0 To dr_details.Length - 1
                    ResetApprvStatus(dr_details(i).Item("sbe_lotno"), dr_details(i).Item("sbe_filename"), dr_details(i).Item("sbe_jobord"))
                Next
            Else
                UnReleaseSC(strCocde, strSCNo, dr_details)
            End If
        End If
    End Sub

    Private Sub SetErrLog(ByVal strCocde As String, ByVal strDocNo As String, ByVal strMsg As String, ByVal Proc As enumProc)
        Dim strProc As String

        Dim newRow As DataRow = rs_ErrLog.Tables("RESULT").NewRow
        newRow.Item("sbe_cocde") = strCocde
        newRow.Item("sbe_jobord") = strDocNo
        newRow.Item("sbe_exptyp") = strMsg

        Select Case Proc
            Case 1
                strProc = "CheckSCSts"
            Case 2
                strProc = "UnReleaseSC"
            Case 3
                strProc = "UpdateSC"
            Case 4
                strProc = "ReleaseSC"
            Case 5
                strProc = "ReleasePO"
            Case 6
                strProc = ""
            Case Else
                strProc = ""
        End Select
        newRow.Item("tmp_cusno") = strProc

        rs_ErrLog.Tables("RESULT").Rows.Add(newRow)
        rs_ErrLog.AcceptChanges()
    End Sub

    Private Sub ResetApprvStatus(ByVal strLotno As String, ByVal strFileName As String, ByVal strJobOrd As String)

        gspStr = "sp_update_SCFDBEXP '" & gsCompany & "','" & strLotno & "','" & strFileName & "','" & strJobOrd & _
                 "','N','" & gsUsrID & "'"

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        gspStr = execute_SQLStatement(gspStr, rs, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            'MsgBox rs(0)(0)
            MsgBox("Error on saving SCM00003 #005 sp_update_SCFDBEXP : " & rtnStr)
        End If
    End Sub

    Private Sub UnReleaseSC(ByVal strCocde As String, ByVal strSCNo As String, ByVal dr_details() As DataRow)
        ' This section is to unrelease SC

        Dim r_tmp As ADOR.Recordset
        Dim S As String

        gsCompany = strCocde
        Update_gs_Value(gsCompany)

        gspStr = "sp_select_SCFTYDAT_bat_SCM00002 '" & gsCompany & "','" & strSCNo & "','" & strSCNo & "','N','" & _
                 dr_details(0).Item("sbe_lotno") & "','" & dr_details(0).Item("sbe_filename") & "','SCM03-ERP'"
        rs = Nothing
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        '*** An error has occured
        If rtnLong <> RC_SUCCESS Then
            ' Error
            MsgBox("Error on loading SCM00003 #006 sp_select_SCFTYDAT_bat_SCM00002 : " & rtnStr)
            SetErrLog(strCocde, strSCNo, "SQL Error #006", enumProc.eUnReleaseSC)

            For i As Integer = 0 To dr_details.Length - 1
                ResetApprvStatus(dr_details(i).Item("sbe_lotno"), dr_details(i).Item("sbe_filename"), dr_details(i).Item("sbe_jobord"))
            Next
        Else
            UpdateSC(strCocde, strSCNo, dr_details)
        End If
    End Sub

    Private Sub UpdateSC(ByVal strCocde As String, ByVal strSCNo As String, ByVal dr_details() As DataRow)
        ' This section is to update the details of SC
        Dim strFileName As String

        strFileName = ""

        gsCompany = strCocde
        Update_gs_Value(gsCompany)

        For i As Integer = 0 To dr_details.Length - 1
            gspStr = "sp_update_scftydat_bat_SC '" & gsCompany & "','" & dr_details(i).Item("sbe_lotno") & "','" & _
                     dr_details(i).Item("sbe_filename") & "','" & dr_details(i).Item("sbe_jobord") & "','" & _
                     dr_details(i).Item("tmp_fty01prc") & "','" & dr_details(i).Item("tmp_fty01Curr") & "','" & _
                     Trim(Split(dr_details(i).Item("tmp_ftycv"), "-")(0)) & "','" & _
                     Trim(Split(dr_details(i).Item("tmp_ftypv"), "-")(0)) & "','SCM03-ERP'"

            rs = Nothing
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            If rtnLong <> RC_SUCCESS Then
                ' Error
                MsgBox("Error on saving SCM00003 #007 sp_update_scftydat_bat_SC : " & rtnStr)
                SetErrLog(strCocde, dr_details(i).Item("sbe_jobord"), "SQL Error #007", enumProc.eUpdateSC)
                ResetApprvStatus(dr_details(i).Item("sbe_lotno"), dr_details(i).Item("sbe_filename"), dr_details(i).Item("sbe_jobord"))
            End If
        Next

        ReleaseSC(strCocde, strSCNo, dr_details)
    End Sub

    Private Sub ReleaseSC(ByVal strCocde As String, ByVal strSCNo As String, ByVal dr_details() As DataRow)
        ' This section is to release the SC and update the details to PO

        Dim r_tmp As ADOR.Recordset
        Dim S As String

        gsCompany = strCocde
        Update_gs_Value(gsCompany)

        gspStr = "sp_select_scftydat_bat_SCM00002 '" & gsCompany & "','" & strSCNo & "','" & strSCNo & "','Y','" & _
                 dr_details(0).Item("sbe_lotno") & "','" & dr_details(0).Item("sbe_filename") & "','SCM03-ERP'"

        rs = Nothing
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default

        '*** An error has occured
        If rtnLong <> RC_SUCCESS Then
            ' Error
            MsgBox("Error on loading SCM00003 #008 sp_select_scftydat_bat_SCM00002 : " & rtnStr)
            SetErrLog(strCocde, strSCNo, "SQL Error #008", enumProc.eReleaseSC)
        Else
            ReleasePO(strCocde, strSCNo, dr_details(0).Item("sbe_filename"))
        End If

        For i As Integer = 0 To dr_details.Length - 1
            RemoveApprvRec(dr_details(i).Item("sbe_lotno"), dr_details(i).Item("sbe_filename"), dr_details(i).Item("sbe_jobord"))
            SetErrLog(strCocde, dr_details(i).Item("sbe_jobord"), "Update Successfully", enumProc.eEmpty)
        Next
    End Sub

    Private Sub ReleasePO(ByVal strCocde As String, ByVal strSCNo As String, ByVal strFileName As String)
        Dim r_tmp As DataSet
        Dim rs_PO As DataSet

        gsCompany = strCocde
        Update_gs_Value(gsCompany)

        gspStr = "sp_select_scftydat_bat_get_po '" & gsCompany & "','" & strSCNo & "'"
        rs = Nothing
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading SCM00003 #009 sp_select_scftydat_bat_get_po : " & rtnStr)
            SetErrLog(strCocde, strSCNo, "SQL Error #009", enumProc.eReleasePO)
        Else
            rs_PO = rs.Copy()

            If rs_PO.Tables("RESULT").Rows.Count > 0 Then
                For i As Integer = 0 To rs_PO.Tables("RESULT").Rows.Count - 1
                    gspStr = "sp_select_POORDHDRR '" & gsCompany & "','" & rs_PO.Tables("RESULT").Rows(i)("pod_purord") & _
                             "','" & rs_PO.Tables("RESULT").Rows(i)("pod_purord") & "','Y'"
                    rs = Nothing
                    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    Me.Cursor = Windows.Forms.Cursors.Default
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading SCM00003 #010 sp_select_POORDHDRR : " & rtnStr)
                    Else
                        r_tmp = rs.Copy()
                        If r_tmp.Tables("RESULT").Rows.Count > 0 Then
                            ' PO already in "Release" Status
                        Else
                            ' Release PO
                            gspStr = "sp_select_scftydat_bat_POM00004 '" & gsCompany & "','" & _
                                     rs_PO.Tables("RESULT").Rows(i)("pod_purord") & "','" & _
                                     rs_PO.Tables("RESULT").Rows(i)("pod_purord") & "','Y','SCM03-BAT'"

                            rs = Nothing
                            Me.Cursor = Windows.Forms.Cursors.WaitCursor
                            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                            Me.Cursor = Windows.Forms.Cursors.Default

                            If rtnLong <> RC_SUCCESS Then
                                ' Error
                                MsgBox("Error on loading SCM00003 #011 sp_select_scftydat_bat_POM00004 : " & rtnStr)
                                SetErrLog(strCocde, rs_PO.Tables("RESULT").Rows(i)("pod_purord"), "SQL Error #011", enumProc.eReleasePO)
                            End If
                        End If
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub RemoveApprvRec(ByVal strLotno As String, ByVal strFileName As String, ByVal strJobOrd As String)

        gspStr = "sp_insert_SCFDBEXPH '" & gsCompany & "','" & strLotno & "','" & strFileName & "','" & strJobOrd & "','" & gsUsrID

        rs = Nothing
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            'MsgBox rs(0)(0)
            MsgBox("Error on loading SCM00003 #012 sp_insert_SCFDBEXPH : " & rtnStr)
        Else

        End If

    End Sub

    Private Sub cmdApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApply.Click
        If CInt(Trim(txtFromApply.Text)) > CInt(Trim(txtToApply.Text)) Then
            MsgBox("Invalid Input.")
            Exit Sub
        End If

        If Not r Is Nothing Then
            If r.Tables("RESULT").Rows.Count > 0 Then
                Dim dr() As DataRow = r.Tables("RESULT").Select(" reccount >= " & Trim(txtFromApply.Text) & " and reccount <= " & Trim(txtToApply.Text))

                If dr.Length > 0 Then
                    r.Tables("RESULT").Columns("sbe_apprv").ReadOnly = False
                    r.Tables("RESULT").Columns("sbe_updusr").ReadOnly = False
                    For i As Integer = 0 To dr.Length - 1
                        If dr(i).Item("tmp_ordsts") <> "REL" Then
                        ElseIf dr(i).Item("tmp_fty01prc") = 0 Then
                        ElseIf dr(i).Item("yet_cde") = "04" Or dr(i).Item("yet_cde") = "08" Then
                        Else
                            If optYes.Checked = True Then
                                dr(i).Item("sbe_apprv") = "Y"
                            ElseIf optNo.Checked = True Then
                                dr(i).Item("sbe_apprv") = "N"
                            End If
                            dr(i).Item("sbe_updusr") = "*~UPD~*"
                        End If
                    Next
                    r.Tables("RESULT").Columns("sbe_apprv").ReadOnly = True
                    r.Tables("RESULT").Columns("sbe_updusr").ReadOnly = True
                End If

                r.AcceptChanges()
                SetSBPanel()
                grdSummary.DataSource = Nothing
                grdSummary.DataSource = r.Tables("RESULT").DefaultView
                SetSummaryGrid()
            End If

        End If
    End Sub

    Private Sub cmdJobOrd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdJobOrd.Click
        itmLst = New frmItemList
        itmLst.myOwner = Me
        itmLst.txtSelitm.MaxLength = 9999
        itmLst.strItem = strJobOrdList
        itmLst.Label1.Text = "Please maintain a list of Job Order No. (each separated by an ENTER):"
        itmLst.ShowDialog()
        strJobOrdList = itmLst.strSel
        ApprJobOrdList()
    End Sub

    Private Sub ApprJobOrdList()
        Dim strTmp() As String
        Dim i As Long

        strTmp = Split(strJobOrdList & ",", ",")

        If UBound(strTmp) > 0 Then

            If Not r Is Nothing Then
                If r.Tables("RESULT").Rows.Count > 0 Then
                    For i = 0 To UBound(strTmp) - 1
                        Dim dr() As DataRow = r.Tables("RESULT").Select("tmp_jobord = '" & strTmp(i) & "'")
                        If dr.Length > 0 Then
                            For j As Integer = 0 To dr.Length - 1
                                If dr(j).Item("tmp_ordsts") <> "REL Then" Then
                                ElseIf dr(j).Item("tmp_fty01prc") = 0 Then
                                ElseIf dr(j).Item("yet_cde") = "04" Or dr(j).Item("yet_cde") = "08" Then
                                Else
                                    dr(j).Item("sbe_apprv") = "Y"
                                    dr(j).Item("sbe_updusr") = "*~UPD~*"
                                End If
                            Next
                        End If
                    Next

                    r.AcceptChanges()
                    SetSBPanel()
                    grdSummary.DataSource = Nothing
                    grdSummary.DataSource = r.Tables("RESULT").DefaultView
                    SetSummaryGrid()
                End If
            End If
        End If
    End Sub

    Private Sub cmdExportExp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportExp.Click
        If r.Tables("RESULT").Rows.Count > 0 Then
            ExportException()
        End If
    End Sub

    Private Sub ExportException()
        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWB As Excel.Workbook = Nothing
        Dim xlsWS As Excel.Worksheet = Nothing

        If r.Tables("RESULT").Rows.Count >= 65535 Then
            MsgBox("There are more than 65535 records!")
            Exit Sub
        End If

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        xlsApp = New Excel.Application
        xlsApp.Visible = True
        xlsApp.UserControl = True

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        xlsWB = xlsApp.Workbooks.Add()
        xlsWS = xlsWB.ActiveSheet

        Dim headerRow As Integer = 3
        Dim headerCol As Integer = 1

        With xlsApp
            .Cells(1, headerCol) = "Factory Data Batch Exception Report"

            .Cells(headerRow, headerCol) = "Proc. Dat."
            headerCol = headerCol + 1
            .Cells(headerRow, headerCol) = "Exception"
            headerCol = headerCol + 1
            .Cells(headerRow, headerCol) = "Co."
            headerCol = headerCol + 1
            .Cells(headerRow, headerCol) = "SC No#"
            headerCol = headerCol + 1
            .Cells(headerRow, headerCol) = "Pri Cus"
            headerCol = headerCol + 1
            .Cells(headerRow, headerCol) = "Job No#"
            headerCol = headerCol + 1
            .Cells(headerRow, headerCol) = "Item#"
            headerCol = headerCol + 1
            .Cells(headerRow, headerCol) = "UM"
            headerCol = headerCol + 1
            .Cells(headerRow, headerCol) = "Inr"
            headerCol = headerCol + 1
            .Cells(headerRow, headerCol) = "Mtr"
            headerCol = headerCol + 1
            .Cells(headerRow, headerCol) = "OdrQty"
            headerCol = headerCol + 1
            .Cells(headerRow, headerCol) = "ShpQty"
            headerCol = headerCol + 1
            .Cells(headerRow, headerCol) = "OSQty"
            headerCol = headerCol + 1
            .Cells(headerRow, headerCol) = "SAP CV"
            headerCol = headerCol + 1
            .Cells(headerRow, headerCol) = "HK CV"
            headerCol = headerCol + 1
            .Cells(headerRow, headerCol) = "SAP PV"
            headerCol = headerCol + 1
            .Cells(headerRow, headerCol) = "HK PV"
            headerCol = headerCol + 1
            .Cells(headerRow, headerCol) = "Curr"
            headerCol = headerCol + 1
            .Cells(headerRow, headerCol) = "ZI03"
            headerCol = headerCol + 1
            .Cells(headerRow, headerCol) = "HK DV FtyPrc"
            headerCol = headerCol + 1
            .Cells(headerRow, headerCol) = "ZI01"
            headerCol = headerCol + 1
            .Cells(headerRow, headerCol) = "HK PV FtyPrc"
            headerCol = headerCol + 1
            .Cells(headerRow, headerCol) = "ZI02"
            headerCol = headerCol + 1
            .Cells(headerRow, headerCol) = "ZI04"
            headerCol = headerCol + 1
            .Cells(headerRow, headerCol) = "ZI05"
            headerCol = headerCol + 1
            .Cells(headerRow, headerCol) = "PO Shpstr"
            headerCol = headerCol + 1
            .Cells(headerRow, headerCol) = "PO Shpend"
            headerCol = headerCol + 1
            .Cells(headerRow, headerCol) = "SAP SO#"
            headerCol = headerCol + 1
            .Cells(headerRow, headerCol) = "Line#"
            headerCol = headerCol + 1
            .Cells(headerRow, headerCol) = "Latest"
            headerCol = headerCol + 1
            .Cells(headerRow, headerCol) = "PV Approve Flag"
            headerCol = headerCol + 1
            .Cells(headerRow, headerCol) = "PV Approve Date"
            headerCol = headerCol + 1
            .Cells(headerRow, headerCol) = "CV Approve Flag"
            headerCol = headerCol + 1
            .Cells(headerRow, headerCol) = "CV Approve Date"
        End With

        Try
            'Data
            Dim entry(33) As String
            With xlsApp
                '.Range(.Cells(3, 1), .Cells(3, r.Tables("RESULT").Columns.Count)).Value = entry

                For i As Integer = 0 To r.Tables("RESULT").Rows.Count - 1
                    entry(0) = Format(r.Tables("RESULT").Rows(i)("sbe_credat"), "MM/dd/yyyy")
                    entry(1) = r.Tables("RESULT").Rows(i)("sbe_exptyp")
                    entry(2) = r.Tables("RESULT").Rows(i)("tmp_cocde")
                    entry(3) = r.Tables("RESULT").Rows(i)("tmp_scno")
                    entry(4) = r.Tables("RESULT").Rows(i)("tmp_cusno")
                    entry(5) = r.Tables("RESULT").Rows(i)("tmp_jobord")
                    entry(6) = r.Tables("RESULT").Rows(i)("tmp_itmno")
                    entry(7) = r.Tables("RESULT").Rows(i)("tmp_HKuntcde")
                    entry(8) = r.Tables("RESULT").Rows(i)("tmp_HKinrqty").ToString
                    entry(9) = r.Tables("RESULT").Rows(i)("tmp_HKmtrqty").ToString
                    entry(10) = r.Tables("RESULT").Rows(i)("tmp_odrqty")
                    entry(11) = r.Tables("RESULT").Rows(i)("tmp_shpqty")
                    entry(12) = r.Tables("RESULT").Rows(i)("tmp_osqty")
                    entry(13) = r.Tables("RESULT").Rows(i)("tmp_ftyCV")
                    entry(14) = r.Tables("RESULT").Rows(i)("tmp_HKCV")
                    entry(15) = r.Tables("RESULT").Rows(i)("tmp_ftyPV")
                    entry(16) = r.Tables("RESULT").Rows(i)("tmp_HKPV")
                    entry(17) = r.Tables("RESULT").Rows(i)("tmp_HKPVftyprcCurr")
                    entry(18) = IIf(Val(r.Tables("RESULT").Rows(i)("tmp_fty03prc")) = 0, "0", r.Tables("RESULT").Rows(i)("tmp_fty03prc"))
                    entry(19) = IIf(Val(r.Tables("RESULT").Rows(i)("tmp_HKDVftyprc")) = 0, "0", r.Tables("RESULT").Rows(i)("tmp_HKDVftyprc"))
                    entry(20) = IIf(Val(r.Tables("RESULT").Rows(i)("tmp_fty01prc")) = 0, "0", r.Tables("RESULT").Rows(i)("tmp_fty01prc"))
                    entry(21) = IIf(Val(r.Tables("RESULT").Rows(i)("tmp_HKPVftyprc")) = 0, "0", r.Tables("RESULT").Rows(i)("tmp_HKPVftyprc"))
                    entry(22) = IIf(Val(r.Tables("RESULT").Rows(i)("tmp_fty02prc")) = 0, "0", r.Tables("RESULT").Rows(i)("tmp_fty02prc"))
                    entry(23) = IIf(Val(r.Tables("RESULT").Rows(i)("tmp_fty04prc")) = 0, "0", r.Tables("RESULT").Rows(i)("tmp_fty04prc"))
                    entry(24) = IIf(Val(r.Tables("RESULT").Rows(i)("tmp_fty05prc")) = 0, "0", r.Tables("RESULT").Rows(i)("tmp_fty05prc"))
                    entry(25) = Format(r.Tables("RESULT").Rows(i)("tmp_poshpstr"), "MM/dd/yyyy")
                    entry(26) = Format(r.Tables("RESULT").Rows(i)("tmp_poshpend"), "MM/dd/yyyy")
                    entry(27) = r.Tables("RESULT").Rows(i)("tmp_HKSAPSONo")
                    entry(28) = r.Tables("RESULT").Rows(i)("tmp_HKSAPSOLine")
                    entry(29) = r.Tables("RESULT").Rows(i)("tmp_lastest")
                    entry(30) = r.Tables("RESULT").Rows(i)("tmp_apprvflg")
                    entry(31) = r.Tables("RESULT").Rows(i)("tmp_apprvdt")
                    entry(32) = r.Tables("RESULT").Rows(i)("tmp_zflgapprcv")
                    entry(33) = r.Tables("RESULT").Rows(i)("tmp_zapprcvdat")

                    .Range(.Cells(headerRow + 1 + i, 1), .Cells(headerRow + 1 + i, entry.Length)).Value = entry
                Next
            End With

            'Styling
            With xlsApp
                .Columns("A:AH").Font.Name = "Arial"
                .Columns("A:AH").Font.Size = 8
                .Rows("1:1").Font.Size = 20

                For i As Integer = 1 To headerCol
                    If i = 1 Then
                        .Columns(i).ColumnWidth = 8
                    Else
                        .Columns(i).EntireColumn.AutoFit()
                    End If
                Next
                .Rows(CStr(headerRow + 1) & ":" & CStr(headerRow + r.Tables("RESULT").Rows.Count)).EntireRow.AutoFit()
            End With
        Catch ex As Exception
            If ex.Message = "Exception from HRESULT: 0x800AC472" Then
                If (MsgBox("User has interrupted Data Extraction Process. An error has occured" & Environment.NewLine & "Please close Excel application and click ""Retry""", MsgBoxStyle.RetryCancel, "Excel Error")) = MsgBoxResult.Retry Then
                    xlsWS = Nothing
                    xlsWB = Nothing
                    xlsApp = Nothing
                    ExportException()
                End If
            Else
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "IMR00034 - Excel Error")
            End If
        End Try

        ' Release reference
        xlsWS = Nothing
        xlsWB = Nothing
        xlsApp = Nothing

        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub
End Class