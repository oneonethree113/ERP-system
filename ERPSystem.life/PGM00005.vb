Imports Microsoft.Office.Interop

Public Class PGM00005

    Dim enq_right_local As Boolean
    Dim del_right_local As Boolean
    Dim flag_Add As Boolean
    Dim recordStatus As Boolean
 Dim sortingColumnNo As Integer = -1

    Dim rs_PGM00005 As DataSet
    Dim rs_PGM00005_ori As DataSet
    Dim rs_PGM00005C As DataSet
    Dim rs_Report As DataSet
    Dim rs_check As DataSet
    Dim rs_Pkreqdtl As DataSet
    Dim rs_PKORDHDR As DataSet
    Dim rs_PKORDDTL As DataSet
    Dim rs_PKINVHDR As DataSet

    Dim rs_syswasge As DataSet
    Dim rs_VNCNTINF As DataSet

    Dim dgBatchJob_Confirm As Integer
    Dim newPKORDDTL_req As Integer

    Private Sub PGM00005_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)
        AccessRight(Me.Name)
        enq_right_local = Enq_right
        del_right_local = Del_right




        FillCompCombo(LCase(gsUsrID), cboCoCde)
        GetDefaultCompany(cboCoCde, txtCoNam)

        cboRptFmt.Items.Clear()
        cboRptFmt.Items.Add("Production Order Report")
        cboRptFmt.Items.Add("Batch Job Item Info")



        gspStr = "sp_list_pkwasge_02 ''"
        rtnLong = execute_SQLStatement(gspStr, rs_syswasge, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading cmdFind_Click sp_list_pkwasge :" & rtnStr)
            Exit Sub
        End If

        panelMoveTimer = New Timer()
        panelMoveTimer.Interval = 2
        panelMoveTimer.Enabled = True

        AddHandler panelMoveTimer.Tick, AddressOf panelMoveTimer_Tick
        setStatus("INIT")
    End Sub

    Private Sub setStatus(ByVal mode As String)
        If mode = "INIT" Then
            mmdAdd.Enabled = True
            mmdSave.Enabled = False
            mmdDelete.Enabled = False
            mmdCopy.Enabled = False
            mmdFind.Enabled = True
            mmdClear.Enabled = True
            mmdSearch.Enabled = False
            mmdInsRow.Enabled = False
            mmdDelRow.Enabled = False

            mmdExit.Enabled = True

            mmdPrint.Enabled = False
            mmdAttach.Enabled = False
            mmdFunction.Enabled = False
            mmdLink.Enabled = False

            cboCoCde.Enabled = True
            txtCoNam.Enabled = True
            txtCoNam.ReadOnly = True

            txtBJNo.Enabled = True
            txtRunNoFrm.Enabled = False
            txtRunNoTo.Enabled = False
            txtJobOrdFrm.Enabled = False
            txtJobOrdTo.Enabled = False

            cboRptFmt.Enabled = True
            cmdApply.Enabled = False
            cmdPrint.Enabled = True
            grpOutFmt.Enabled = True
            optPDF.Enabled = True
            optExcel.Enabled = True

            txtCount.Enabled = False
            txtMsg.ReadOnly = True

            flag_Add = False
            recordStatus = False
            chkReGen.Checked = False
            chkReqWas.Checked = False

            PanelOpt.Visible = False
            PanelResult.Visible = False
            rdoPackItem.Checked = True
            cmdCalculate.Enabled = False

            Call SetStatusBar(mode)
            clearScreen()
        ElseIf mode = "ADD" Then
            mmdAdd.Enabled = False
            mmdSave.Enabled = enq_right_local
            mmdDelete.Enabled = False
            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdClear.Enabled = True
            mmdSearch.Enabled = False
            mmdInsRow.Enabled = False
            mmdDelRow.Enabled = False

            mmdExit.Enabled = True

            cboCoCde.Enabled = False
            txtCoNam.Enabled = True
            txtCoNam.ReadOnly = True

            txtBJNo.Enabled = False
            txtRunNoFrm.Enabled = True
            txtRunNoTo.Enabled = True
            txtJobOrdFrm.Enabled = True
            txtJobOrdTo.Enabled = True

            cboRptFmt.Enabled = False
            cmdApply.Enabled = True
            cmdPrint.Enabled = False
            grpOutFmt.Enabled = False
            optPDF.Enabled = True
            optExcel.Enabled = True
            txtMsg.ReadOnly = True

            flag_Add = True
            recordStatus = False

            PanelOpt.Visible = False
            PanelResult.Visible = False
            rdoPackItem.Checked = True
            cmdCalculate.Enabled = True
            clearScreen()
            txtBJNo.Text = ""
            txtMsg.Text = ""

            Call SetStatusBar(mode)
        ElseIf mode = "UPDATE" Then
            mmdAdd.Enabled = False
            mmdSave.Enabled = False 'enq_right_local
            mmdDelete.Enabled = False
            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdClear.Enabled = True
            mmdSearch.Enabled = False
            mmdInsRow.Enabled = False
            mmdDelRow.Enabled = False
            mmdExit.Enabled = True

            cboCoCde.Enabled = False
            txtCoNam.Enabled = False 'True
            txtCoNam.ReadOnly = False 'True

            txtBJNo.Enabled = False
            txtRunNoFrm.Enabled = False 'True
            txtRunNoTo.Enabled = False 'True
            txtJobOrdFrm.Enabled = False 'True
            txtJobOrdTo.Enabled = False 'True

            cboRptFmt.Enabled = False
            cmdApply.Enabled = False 'True
            cmdPrint.Enabled = False
            grpOutFmt.Enabled = False
            optPDF.Enabled = False 'True
            optExcel.Enabled = False 'True
            txtMsg.ReadOnly = True
            flag_Add = True

            PanelOpt.Visible = False
            PanelResult.Visible = False
            rdoPackItem.Checked = True
            cmdCalculate.Enabled = True
            Call SetStatusBar(mode)
        End If
    End Sub

    Private Sub clearScreen()
        txtRunNoFrm.Text = ""
        txtRunNoTo.Text = ""
        txtJobOrdFrm.Text = ""
        txtJobOrdTo.Text = ""

        cboRptFmt.SelectedIndex = 0
        optPDF.Checked = True

        rs_PGM00005 = Nothing
        rs_PGM00005C = Nothing
        dgBatchJob.DataSource = Nothing
    End Sub

    Private Sub cboCoCde_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectionChangeCommitted
        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
    End Sub

    Private Sub txtBJNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBJNo.KeyPress
        If Asc(e.KeyChar) = 13 Then
            mmdFind.PerformClick()
        End If
    End Sub



    Private Sub txtRunNoFrm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRunNoFrm.TextChanged
        txtRunNoTo.Text = txtRunNoFrm.Text
    End Sub

    Private Sub txtJobOrdFrm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJobOrdFrm.TextChanged
        txtJobOrdTo.Text = txtJobOrdFrm.Text
    End Sub

    Private Sub cboRptFmt_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRptFmt.SelectedIndexChanged
        If cboRptFmt.SelectedIndex = 0 Then
            grpOutFmt.Enabled = True
        Else
            grpOutFmt.Enabled = False
        End If
    End Sub
   

    Private Sub cmdApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApply.Click
        gspStr = ""
        If txtJobOrdFrm.Text <> "" And txtJobOrdTo.Text <> "" Then
            gspStr = "sp_select_PGM00005 '" & cboCoCde.Text & "','" & Replace(txtJobOrdFrm.Text, "'", "''") & "','" & Replace(txtJobOrdTo.Text, "'", "''") & "'"
        ElseIf txtRunNoFrm.Text <> "" And txtRunNoTo.Text <> "" Then
            gspStr = "sp_select_PGM00005_2 '" & cboCoCde.Text & "','" & Replace(txtRunNoFrm.Text, "'", "''") & "','" & Replace(txtRunNoTo.Text, "'", "''") & "'"
        End If

        If gspStr <> "" Then
            Dim rs As New DataSet
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading PGM00005 #001 sp_select_PGM00005_2 : " & rtnStr)
                Exit Sub
            End If

            gspStr = "sp_select_PGM00005_Check '" & cboCoCde.Text & "','" & Replace(txtRunNoFrm.Text, "'", "''") & "','" & Replace(txtRunNoTo.Text, "'", "''") & "'"
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_check, rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading PGM00005 #001 sp_select_PGM00005_Check : " & rtnStr)
                Exit Sub
            End If


            For i As Integer = 0 To rs.Tables("RESULT").Columns.Count - 1
                rs.Tables("RESULT").Columns(i).ReadOnly = False
            Next

            Me.StatusBar.Items("lblRight").Text = ""
            Dim dv2 As DataView = rs.Tables("RESULT").DefaultView
            If txtJobOrdFrm.Text <> "" And txtJobOrdTo.Text <> "" Then
                If Not dv2.Count = 0 Then
                    dv2.Sort = "pod_upddat desc"
                    Dim drv As DataRowView = dv2(0)
                    Me.StatusBar.Items("lblRight").Text = Format(drv.Item("pod_credat"), "MM/dd/yyyy") & " " & Format(drv.Item("pod_upddat"), "MM/dd/yyyy") & " " & drv.Item("pod_updusr")

                    dv2.Sort = Nothing
                End If
            ElseIf txtRunNoFrm.Text <> "" And txtRunNoTo.Text <> "" Then

                If Not dv2.Count = 0 Then
                    dv2.Sort = "prd_upddat desc"
                    Dim drv As DataRowView = dv2(0)
                    Me.StatusBar.Items("lblRight").Text = Format(drv.Item("prd_credat"), "MM/dd/yyyy") & " " & Format(drv.Item("prd_upddat"), "MM/dd/yyyy") & " " & drv.Item("prd_updusr")

                    dv2.Sort = Nothing
                End If
            End If


            rs_PGM00005C = rs.Copy()
            If rs_PGM00005C.Tables("RESULT").Rows.Count = 0 Then

                gspStr = "sp_select_PGM00005_2_Check '" & cboCoCde.Text & "','" & Replace(txtRunNoFrm.Text, "'", "''") & "','" & Replace(txtRunNoTo.Text, "'", "''") & "'"
                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                Me.Cursor = Windows.Forms.Cursors.Default
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading PGM00005 #001 sp_select_PGM00005_2_Check : " & rtnStr)
                    Exit Sub
                End If

                If rs.Tables("RESULT").Rows.Count <> 0 Then
                    MsgBox("Requset not in Release Status,Please Check.", MsgBoxStyle.Information)
                    Exit Sub
                Else
                    MsgBox("No Record Found", MsgBoxStyle.Information)
                    Exit Sub
                End If


            Else
                unionRecord()
                Dim dv As DataView = rs_PGM00005.Tables("RESULT").DefaultView
                dv.Sort = "pod_ordno"
                rs_PGM00005.Tables.Remove("RESULT")
                rs_PGM00005.Tables.Add(dv.ToTable)

                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                display()
                countY()
                Me.Cursor = Windows.Forms.Cursors.Default
            End If
        End If


    End Sub

    Private Sub dgBatchJob_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgBatchJob.CellClick
        If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
            If e.ColumnIndex = dgBatchJob_Confirm Then
                If dgBatchJob.CurrentRow.Cells("pjd_confrm").Value = "Y" Then
                    dgBatchJob.CurrentRow.Cells("pjd_confrm").Value = "N"
                Else
                    dgBatchJob.CurrentRow.Cells("pjd_confrm").Value = "Y"
                End If

                recordStatus = True
                rs_PGM00005.AcceptChanges()
                dgBatchJob.ClearSelection()
                countY()
            End If
        End If
        If e.RowIndex = -1 And e.ColumnIndex >= 0 Then
            sortingColumnNo = e.ColumnIndex
            If sortingColumnNo = dgBatchJob.Columns("pjd_confrm").Index Then
            Else
                btnConfirm.Enabled = True
            End If
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        If Trim(txtBJNo.Text) = "" Then
            MsgBox("Batch Job No. cannot be empty", MsgBoxStyle.Information, "BJR0001 - Print Report")
            Exit Sub
        End If

        If cboRptFmt.SelectedIndex = 0 Then
            exportPOReport()
        Else
            exportBJItemReport()
        End If
    End Sub
    Private Sub mmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdAdd.Click
        setStatus("ADD")
        txtRunNoFrm.Focus()
    End Sub




    Private Function check_differentDesc(ByVal rs_tmp_toscdetail As DataSet) As Boolean
        'rs_tmp_toscdetail.Tables("RESULT").DefaultView.RowFilter = "R_pod_ordno = ''"

        Dim rs_tmp_toscdetail2 As DataSet
        rs_tmp_toscdetail2 = rs_tmp_toscdetail.Copy
        Dim ori_f As String

        If rbFilter_Ord.Checked = True Then
            rs_tmp_toscdetail2.Tables("RESULT").DefaultView.RowFilter = "R_pod_ordno <> ''"
        End If
        If rbFilter_Req.Checked = True Then
            rs_tmp_toscdetail2.Tables("RESULT").DefaultView.RowFilter = "R_pod_ordno = ''"
        End If
        If rbFilter_All.Checked = True Then
            rs_tmp_toscdetail2.Tables("RESULT").DefaultView.RowFilter = ""
        End If

        ori_f = rs_tmp_toscdetail2.Tables("RESULT").DefaultView.RowFilter



        Dim strMsg As String = ""
        check_differentDesc = True
        Dim distinctDT As DataTable = rs_tmp_toscdetail.Tables("RESULT").DefaultView.ToTable(True, "pod_pkgitm")
        For i As Integer = 0 To distinctDT.Rows.Count - 1
            'Dim rs_tmp_toscdetail2.Tables("RESULT").DefaultView() As DataRow = rs_tmp_toscdetail.Tables("RESULT").DefaultView.Select("pjd_confrm = 'Y' and pod_pkgitm = '" & distinctDT.Rows(i).Item(0) & "'", "pod_pkgven,pod_ordno,pod_seq")

            If ori_f = "" Then
                rs_tmp_toscdetail2.Tables("RESULT").DefaultView.RowFilter = (" pjd_confrm = 'Y' and pod_pkgitm = '" & distinctDT.Rows(i).Item(0) & "'")
            Else
                rs_tmp_toscdetail2.Tables("RESULT").DefaultView.RowFilter = (rs_tmp_toscdetail2.Tables("RESULT").DefaultView.RowFilter + " and pjd_confrm = 'Y' and pod_pkgitm = '" & distinctDT.Rows(i).Item(0) & "'")

            End If


            '            Dim rs_tmp_toscdetail2.Tables("RESULT").DefaultView() As DataRow = rs_tmp_toscdetail.Tables("RESULT").Select("R_pod_ordno = '' and pjd_confrm = 'Y' and pod_pkgitm = '" & distinctDT.Rows(i).Item(0) & "'", "pod_pkgven,pod_ordno,pod_seq")

            ' Dim rs_tmp_toscdetail2.Tables("RESULT").DefaultView() As DataRow = rs_tmp_toscdetail.Tables("RESULT").Select("pjd_confrm = 'Y' and pod_pkgitm = '" & distinctDT.Rows(i).Item(0) & "'", "pod_pkgven,pod_ordno,pod_seq")

            Dim first_prd_engdsc As String
            Dim first_prd_chndsc As String
            Dim first_prd_remark As String
            Dim first_prd_EInchL As Decimal
            Dim first_prd_EInchW As Decimal
            Dim first_prd_EInchH As Decimal
            Dim first_prd_EcmL As Decimal
            Dim first_prd_EcmW As Decimal
            Dim first_prd_EcmH As Decimal
            Dim first_prd_FInchL As Decimal
            Dim first_prd_FInchW As Decimal
            Dim first_prd_FInchH As Decimal
            Dim first_prd_FcmL As Decimal
            Dim first_prd_FcmW As Decimal
            Dim first_prd_FcmH As Decimal
            Dim first_prd_matral As String
            Dim first_prd_matDsc As String
            Dim first_prd_tiknes As String
            Dim first_prd_tikDsc As String
            Dim first_prd_prtmtd As String
            Dim first_prd_prtDsc As String
            Dim first_prd_clrfot As String
            Dim first_prd_clrbck As String
            Dim first_prd_finish As String

            If rs_tmp_toscdetail2.Tables("RESULT").DefaultView.Count <> 0 Then
                first_prd_engdsc = rs_tmp_toscdetail2.Tables("RESULT").DefaultView(0)("prd_engdsc")
                first_prd_chndsc = rs_tmp_toscdetail2.Tables("RESULT").DefaultView(0)("prd_chndsc")
                first_prd_remark = rs_tmp_toscdetail2.Tables("RESULT").DefaultView(0)("prd_remark")
                first_prd_EInchL = rs_tmp_toscdetail2.Tables("RESULT").DefaultView(0)("prd_EInchL")
                first_prd_EInchW = rs_tmp_toscdetail2.Tables("RESULT").DefaultView(0)("prd_EInchW")
                first_prd_EInchH = rs_tmp_toscdetail2.Tables("RESULT").DefaultView(0)("prd_EInchH")
                first_prd_EcmL = rs_tmp_toscdetail2.Tables("RESULT").DefaultView(0)("prd_EcmL")
                first_prd_EcmW = rs_tmp_toscdetail2.Tables("RESULT").DefaultView(0)("prd_EcmW")
                first_prd_EcmH = rs_tmp_toscdetail2.Tables("RESULT").DefaultView(0)("prd_EcmH")
                first_prd_FInchL = rs_tmp_toscdetail2.Tables("RESULT").DefaultView(0)("prd_FInchL")
                first_prd_FInchW = rs_tmp_toscdetail2.Tables("RESULT").DefaultView(0)("prd_FInchW")
                first_prd_FInchH = rs_tmp_toscdetail2.Tables("RESULT").DefaultView(0)("prd_FInchH")
                first_prd_FcmL = rs_tmp_toscdetail2.Tables("RESULT").DefaultView(0)("prd_FcmL")
                first_prd_FcmW = rs_tmp_toscdetail2.Tables("RESULT").DefaultView(0)("prd_FcmW")
                first_prd_FcmH = rs_tmp_toscdetail2.Tables("RESULT").DefaultView(0)("prd_FcmH")
                first_prd_matral = rs_tmp_toscdetail2.Tables("RESULT").DefaultView(0)("prd_matral")
                first_prd_matDsc = rs_tmp_toscdetail2.Tables("RESULT").DefaultView(0)("prd_matDsc")
                first_prd_tiknes = rs_tmp_toscdetail2.Tables("RESULT").DefaultView(0)("prd_tiknes")
                first_prd_tikDsc = rs_tmp_toscdetail2.Tables("RESULT").DefaultView(0)("prd_tikDsc")
                first_prd_prtmtd = rs_tmp_toscdetail2.Tables("RESULT").DefaultView(0)("prd_prtmtd")
                first_prd_prtDsc = rs_tmp_toscdetail2.Tables("RESULT").DefaultView(0)("prd_prtDsc")
                first_prd_clrfot = rs_tmp_toscdetail2.Tables("RESULT").DefaultView(0)("prd_clrfot")
                first_prd_clrbck = rs_tmp_toscdetail2.Tables("RESULT").DefaultView(0)("prd_clrbck")
                first_prd_finish = rs_tmp_toscdetail2.Tables("RESULT").DefaultView(0)("prd_finish")

            End If

            For ii As Integer = 0 To rs_tmp_toscdetail2.Tables("RESULT").DefaultView.Count - 1
                If first_prd_engdsc <> rs_tmp_toscdetail2.Tables("RESULT").DefaultView(ii)("prd_engdsc") Or _
                    first_prd_chndsc <> rs_tmp_toscdetail2.Tables("RESULT").DefaultView(ii)("prd_chndsc") Or _
                    first_prd_remark <> rs_tmp_toscdetail2.Tables("RESULT").DefaultView(ii)("prd_remark") Or _
                    first_prd_EInchL <> rs_tmp_toscdetail2.Tables("RESULT").DefaultView(ii)("prd_EInchL") Or _
                    first_prd_EInchW <> rs_tmp_toscdetail2.Tables("RESULT").DefaultView(ii)("prd_EInchW") Or _
                    first_prd_EInchH <> rs_tmp_toscdetail2.Tables("RESULT").DefaultView(ii)("prd_EInchH") Or _
                    first_prd_EcmL <> rs_tmp_toscdetail2.Tables("RESULT").DefaultView(ii)("prd_EcmL") Or _
                    first_prd_EcmW <> rs_tmp_toscdetail2.Tables("RESULT").DefaultView(ii)("prd_EcmW") Or _
                    first_prd_EcmH <> rs_tmp_toscdetail2.Tables("RESULT").DefaultView(ii)("prd_EcmH") Or _
                    first_prd_FInchL <> rs_tmp_toscdetail2.Tables("RESULT").DefaultView(ii)("prd_FInchL") Or _
                    first_prd_FInchW <> rs_tmp_toscdetail2.Tables("RESULT").DefaultView(ii)("prd_FInchW") Or _
                    first_prd_FInchH <> rs_tmp_toscdetail2.Tables("RESULT").DefaultView(ii)("prd_FInchH") Or _
                    first_prd_FcmL <> rs_tmp_toscdetail2.Tables("RESULT").DefaultView(ii)("prd_FcmL") Or _
                    first_prd_FcmW <> rs_tmp_toscdetail2.Tables("RESULT").DefaultView(ii)("prd_FcmW") Or _
                    first_prd_FcmH <> rs_tmp_toscdetail2.Tables("RESULT").DefaultView(ii)("prd_FcmH") Or _
                    first_prd_matral <> rs_tmp_toscdetail2.Tables("RESULT").DefaultView(ii)("prd_matral") Or _
                    first_prd_matDsc <> rs_tmp_toscdetail2.Tables("RESULT").DefaultView(ii)("prd_matDsc") Or _
                    first_prd_tiknes <> rs_tmp_toscdetail2.Tables("RESULT").DefaultView(ii)("prd_tiknes") Or _
                    first_prd_tikDsc <> rs_tmp_toscdetail2.Tables("RESULT").DefaultView(ii)("prd_tikDsc") Or _
                    first_prd_prtmtd <> rs_tmp_toscdetail2.Tables("RESULT").DefaultView(ii)("prd_prtmtd") Or _
                    first_prd_prtDsc <> rs_tmp_toscdetail2.Tables("RESULT").DefaultView(ii)("prd_prtDsc") Or _
                    first_prd_clrfot <> rs_tmp_toscdetail2.Tables("RESULT").DefaultView(ii)("prd_clrfot") Or _
                    first_prd_clrbck <> rs_tmp_toscdetail2.Tables("RESULT").DefaultView(ii)("prd_clrbck") Or _
                    first_prd_finish <> rs_tmp_toscdetail2.Tables("RESULT").DefaultView(ii)("prd_finish") Then
                    check_differentDesc = False

                    MsgBox("Packaging Item " & distinctDT.Rows(i).Item(0) & "with different description, cannot generate/update Packaging Order.")
                    Exit Function
                End If
            Next
        Next
    End Function

    Private Function check_differentPrice(ByVal rs_tmp_toscdetail As DataSet) As Boolean

        Dim strMsg As String = ""
        check_differentPrice = True
        Dim distinctDT As DataTable = rs_tmp_toscdetail.Tables("RESULT").DefaultView.ToTable(True, "pod_pkgitm")
        For i As Integer = 0 To distinctDT.Rows.Count - 1

            Dim dr_tmp_toscdetail() As DataRow

            If rbFilter_Ord.Checked = True Then
                dr_tmp_toscdetail = rs_tmp_toscdetail.Tables("RESULT").Select("pjd_confrm = 'Y' and R_pod_ordno <> '' and  pod_pkgitm = '" & distinctDT.Rows(i).Item(0) & "'", "pod_pkgven,pod_ordno,pod_seq")
                'rs_PGM00005.Tables("RESULT").DefaultView.RowFilter = "R_pod_ordno <> ''"
            End If
            If rbFilter_Req.Checked = True Then
                dr_tmp_toscdetail = rs_tmp_toscdetail.Tables("RESULT").Select("pjd_confrm = 'Y' and R_pod_ordno = '' and  pod_pkgitm = '" & distinctDT.Rows(i).Item(0) & "'", "pod_pkgven,pod_ordno,pod_seq")
                'rs_PGM00005.Tables("RESULT").DefaultView.RowFilter = "R_pod_ordno = ''"
            End If
            If rbFilter_All.Checked = True Then
                dr_tmp_toscdetail = rs_tmp_toscdetail.Tables("RESULT").Select("pjd_confrm = 'Y' and  pod_pkgitm = '" & distinctDT.Rows(i).Item(0) & "'", "pod_pkgven,pod_ordno,pod_seq")
                'rs_PGM00005.Tables("RESULT").DefaultView.RowFilter = ""
            End If
            'Dim dr_tmp_toscdetail() As DataRow = rs_tmp_toscdetail.Tables("RESULT").Select("R_pod_ordno = '' and pjd_confrm = 'Y' and pod_pkgitm = '" & distinctDT.Rows(i).Item(0) & "'", "pod_pkgven,pod_ordno,pod_seq")

            Dim currentVendor As String = ""
            Dim currentprice As Decimal = 0
            Dim currentwrongVendor As String = ""

            If dr_tmp_toscdetail.Length <> 0 Then
                currentVendor = dr_tmp_toscdetail(0)("pod_pkgven")
                currentprice = dr_tmp_toscdetail(0)("pod_untprc")
            End If

            For ii As Integer = 0 To dr_tmp_toscdetail.Length - 1
                If currentVendor = dr_tmp_toscdetail(ii)("pod_pkgven") And currentprice <> dr_tmp_toscdetail(ii)("pod_untprc") Then


                    If currentwrongVendor <> currentVendor Then
                        check_differentPrice = False
                        Dim dr_wrong_vendor() As DataRow = rs_tmp_toscdetail.Tables("RESULT").Select("R_pod_ordno = '' and pjd_confrm = 'Y' and pod_pkgitm = '" & distinctDT.Rows(i).Item(0) & "' and  pod_pkgven = '" & dr_tmp_toscdetail(ii)("pod_pkgven") & "'", "pod_pkgven,pod_ordno,pod_seq")
                        For z As Integer = 0 To dr_wrong_vendor.Length - 1
                            strMsg = strMsg & dr_wrong_vendor(z).Item("pod_ordno") & "         " & dr_wrong_vendor(z).Item("pod_seq") & "             " & dr_wrong_vendor(z).Item("pod_pkgitm") & _
                            "             " & dr_wrong_vendor(z).Item("vbi_vensna") & "             " & dr_wrong_vendor(z).Item("pod_untprc") & vbCrLf '& "\" & dr_tmp_toscdetail(i).Item("tempitem") & _
                        Next
                        currentwrongVendor = dr_tmp_toscdetail(ii)("pod_pkgven")
                    End If

                    '"\" & dr_tmp_toscdetail(i).Item("venitem") & "\" & dr_tmp_toscdetail(i).Item("venitemno") 
                End If

            Next


        Next




        If strMsg <> "" Then
            strMsg = "The following reocord(s) is/are the same Packaging Item / Vendor With different Unit Price:        " & vbCrLf & _
                     vbCrLf & "Order #         Seq #          Item #                  Vendor#                Price#" & vbCrLf & _
                    vbCrLf & strMsg & _
                    vbCrLf & vbCrLf & "" & vbCrLf & _
                    "Continue Order Generation?"

            If MsgBox(strMsg, vbYesNo + vbDefaultButton2 + vbCritical, "") = vbYes Then
                check_differentPrice = True
            End If
        End If
    End Function


    Private Function check_differentPrice_RE(ByVal rs_tmp_toscdetail As DataSet) As Boolean

        Dim strMsg As String = ""
        check_differentPrice_RE = True
        Dim distinctDT As DataTable = rs_tmp_toscdetail.Tables("RESULT").DefaultView.ToTable(True, "pod_pkgitm")
        For i As Integer = 0 To distinctDT.Rows.Count - 1

            Dim dr_tmp_toscdetail() As DataRow


            If rbFilter_Ord.Checked = True Then
                dr_tmp_toscdetail = rs_tmp_toscdetail.Tables("RESULT").Select("pjd_confrm = 'Y' and R_pod_ordno <> '' and  pod_pkgitm = '" & distinctDT.Rows(i).Item(0) & "'", "pod_pkgven,pod_ordno,pod_seq")
                'rs_PGM00005.Tables("RESULT").DefaultView.RowFilter = "R_pod_ordno <> ''"
            End If
            If rbFilter_Req.Checked = True Then
                dr_tmp_toscdetail = rs_tmp_toscdetail.Tables("RESULT").Select("pjd_confrm = 'Y' and R_pod_ordno = '' and  pod_pkgitm = '" & distinctDT.Rows(i).Item(0) & "'", "pod_pkgven,pod_ordno,pod_seq")
                'rs_PGM00005.Tables("RESULT").DefaultView.RowFilter = "R_pod_ordno = ''"
            End If
            If rbFilter_All.Checked = True Then
                dr_tmp_toscdetail = rs_tmp_toscdetail.Tables("RESULT").Select("pjd_confrm = 'Y' and  pod_pkgitm = '" & distinctDT.Rows(i).Item(0) & "'", "pod_pkgven,pod_ordno,pod_seq")
                'rs_PGM00005.Tables("RESULT").DefaultView.RowFilter = ""
            End If



            Dim currentVendor As String = ""
            Dim currentprice As Decimal = 0
            Dim currentwrongVendor As String = ""

            If dr_tmp_toscdetail.Length <> 0 Then
                currentVendor = dr_tmp_toscdetail(0)("pod_pkgven")
                currentprice = dr_tmp_toscdetail(0)("pod_untprc")
            End If

            For ii As Integer = 0 To dr_tmp_toscdetail.Length - 1
                If currentVendor = dr_tmp_toscdetail(ii)("pod_pkgven") And currentprice <> dr_tmp_toscdetail(ii)("pod_untprc") Then


                    If currentwrongVendor <> currentVendor Then
                        check_differentPrice_RE = False
                        Dim dr_wrong_vendor() As DataRow = rs_tmp_toscdetail.Tables("RESULT").Select("pjd_confrm = 'Y' and pod_pkgitm = '" & distinctDT.Rows(i).Item(0) & "' and  pod_pkgven = '" & dr_tmp_toscdetail(ii)("pod_pkgven") & "'", "pod_pkgven,pod_ordno,pod_seq")
                        For z As Integer = 0 To dr_wrong_vendor.Length - 1
                            strMsg = strMsg & dr_wrong_vendor(z).Item("pod_ordno") & "         " & dr_wrong_vendor(z).Item("pod_seq") & "             " & dr_wrong_vendor(z).Item("pod_pkgitm") & _
                            "             " & dr_wrong_vendor(z).Item("vbi_vensna") & "             " & dr_wrong_vendor(z).Item("pod_untprc") & vbCrLf '& "\" & dr_tmp_toscdetail(i).Item("tempitem") & _
                        Next
                        currentwrongVendor = dr_tmp_toscdetail(ii)("pod_pkgven")
                    End If

                    '"\" & dr_tmp_toscdetail(i).Item("venitem") & "\" & dr_tmp_toscdetail(i).Item("venitemno") 
                End If

            Next


        Next




        If strMsg <> "" Then
            strMsg = "The following reocord(s) is/are the same Packaging Item / Vendor With different Unit Price:        " & vbCrLf & _
                     vbCrLf & "Order #         Seq #          Item #                  Vendor#                Price#" & vbCrLf & _
                    vbCrLf & strMsg & _
                    vbCrLf & vbCrLf & "" & vbCrLf & _
                    "Continue Order Generation?"

            If MsgBox(strMsg, vbYesNo + vbDefaultButton2 + vbCritical, "") = vbYes Then
                check_differentPrice_RE = True
            End If
        End If
    End Function

    Private Function round(ByVal a As Double, ByVal Value As Double) As Double
        Dim S As String

        S = "0"

        If Value = 0 Then S = "0"
        If Value = 1 Then S = "0.0"
        If Value = 2 Then S = "0.00"
        If Value = 3 Then S = "0.000"
        If Value = 4 Then S = "0.0000"
        If Value = 5 Then S = "0.00000"
        If Value = 6 Then S = "0.000000"
        If Value = 7 Then S = "0.0000000"
        If Value = 8 Then S = "0.00000000"
        If Value = 9 Then S = "0.000000000"
        If Value = 10 Then S = "0.0000000000"

        round = CDbl(Format(a, S))
    End Function


    Private Sub mmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdSave.Click
        If checkFocus(Me) Then Exit Sub
        Dim rs As DataSet
        Dim msg As String = ""

        If rs_PGM00005 Is Nothing Then
            MsgBox("No record found in this Batch Job No.", MsgBoxStyle.Exclamation, "PGM00005 - Save without Record")
            Exit Sub
        End If

        If flag_Add = False And txtBJNo.Text = "" Then
            MsgBox("Process cannot save without Batch Job No.", MsgBoxStyle.Exclamation, "PGM00005 - Save without Batch Job No")
            Exit Sub
        End If

        If MsgBox("Are you sure to generate or update?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If


        'If recordStatus = False Then
        '    MsgBox("No changes have been made", MsgBoxStyle.Information, "PGM00005 - Save without changes")
        '    Exit Sub
        'End If

        'If check_groupexist() = False Then
        '    Exit Sub
        'End If




        If flag_Add = True Then

            If chkReGen.Checked = False Then

                If check_differentDesc(rs_PGM00005) = False Then
                    Exit Sub
                End If


                If check_differentPrice(rs_PGM00005) = False Then
                    Exit Sub
                End If

                If chkReqWas.Checked = True Then
                    If check_ZeroWast(rs_PGM00005) = False Then
                        Exit Sub
                    End If
                End If


                Dim rs_PGM00005_sort As DataTable
                Dim dv As DataView
                dv = rs_PGM00005.Tables("RESULT").DefaultView
                'dv.Sort = "pod_pkgven,pod_ordno,pod_seq asc"
                dv.Sort = "pod_pkgven,pod_pkgitm,pod_untprc"
                rs_PGM00005_sort = dv.ToTable

                dv = Nothing
                Dim currentVendor As String
                For i As Integer = 0 To rs_PGM00005_sort.Rows.Count - 1
                    'rs_PGM00005_sort.DefaultView.Sort = "pod_pkgven,pod_ordno,pod_seq"
                    'rs_PGM00005_sort.DefaultView.Sort = "pod_pkgven asc"
                    If rs_PGM00005_sort.Rows(i).Item("pjd_confrm") = "Y" And Trim(rs_PGM00005_sort.Rows(i).Item("R_pod_ordno").ToString) = "" Then
                        If currentVendor <> rs_PGM00005_sort.Rows(i).Item("pod_pkgven").ToString Then



                            Dim dr() As DataRow
                            Dim currcentitem As String = ""
                            Dim currcentprice As Decimal = -1
                            Dim NewOderno As String = ""
                            '                        dr = rs_PGM00005_sort.Select("pod_pkgven = " & rs_PGM00005_sort.Rows(i).Item("pod_pkgven") & " and pjd_confrm = 'Y'")
                            dr = rs_PGM00005_sort.Select("pod_pkgven = " & rs_PGM00005_sort.Rows(i).Item("pod_pkgven") & " and pjd_confrm = 'Y' and R_pod_ordno = ''")
                            For x As Integer = 0 To dr.Length - 1 ''Handel New Insert
                                If currcentitem = dr(x)("pod_pkgitm") And currcentprice = dr(x)("pod_untprc") Then 'Update PKreqdtl order no + seq



                                    gspStr = "sp_update_PKREQDTL_05 '" & txtBJNo.Text & "','" & dr(x)("pod_pkgven") & "','" & _
                                    dr(x)("pod_pkgitm") & "'," & dr(x)("pod_untprc") & ",'" & dr(x)("pod_ordno") & "'," & dr(x)("pod_seq") & ",'" & LCase(gsUsrID) & "'"
                                    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                    Me.Cursor = Windows.Forms.Cursors.Default
                                    If rtnLong <> RC_SUCCESS Then
                                        MsgBox("Error on loading PGM00005 #003 sp_update_PKREQDTL_05 : " & rtnStr)

                                    End If

                                    If dr(x)("pjd_recsts") = "new" Then
                                        gspStr = "sp_insert_PKGRPDTL '" & cboCoCde.Text & "','" & txtBJNo.Text & "','" & _
                                                    dr(x)("pod_ordno") & "'," & _
                                                    dr(x)("pod_seq") & ",'" & _
                                                    dr(x)("pod_ordno") & "'," & _
                                                   dr(x)("pod_seq") & ",'" & _
                                                    LCase(gsUsrID) & "'"
                                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                        rs = Nothing
                                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                        Me.Cursor = Windows.Forms.Cursors.Default
                                        If rtnLong <> RC_SUCCESS Then
                                            MsgBox("Error on saving PGM00005 #004 sp_insert_PKGRPDTL : " & rtnStr)
                                            Exit Sub
                                        End If

                                        gspStr = "sp_insert_PKMAPDTL '" & cboCoCde.Text & "','" & "2" & "','" & txtBJNo.Text & "'," & _
                                                     newPKORDDTL_req & ",'" & _
                                                   dr(x)("pod_ordno") & "'," & _
                                                   dr(x)("pod_seq") & ",'" & _
                                                    LCase(gsUsrID) & "'"
                                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                        rs = Nothing
                                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                        Me.Cursor = Windows.Forms.Cursors.Default
                                        If rtnLong <> RC_SUCCESS Then
                                            MsgBox("Error on saving PGM00005 #004 sp_insert_PKMAPDTL : " & rtnStr)
                                            Exit Sub
                                        End If
                                    End If


                                    currcentitem = LTrim(RTrim(dr(x)("pod_pkgitm")))
                                    currcentprice = LTrim(RTrim(dr(x)("pod_untprc")))

                                ElseIf (currcentitem = dr(x)("pod_pkgitm") And currcentprice <> dr(x)("pod_untprc")) Or _
                                (currcentitem = "" And currcentprice = -1) Then  ' New header + detail


                                    rs = Nothing 'Header Head
                                    gspStr = "sp_select_DOC_GEN '" & cboCoCde.Text & "','KG','" & LCase(gsUsrID) & "'"
                                    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                    Me.Cursor = Windows.Forms.Cursors.Default
                                    If rtnLong <> RC_SUCCESS Then
                                        MsgBox("Error on loading PGM00005 #003 sp_select_DOC_GEN : " & rtnStr)
                                        Exit Sub
                                    Else
                                        txtBJNo.Text = rs.Tables("RESULT").Rows(0)(0)
                                        msg += "Order NO. : " & txtBJNo.Text & " For Vendor " & rs_PGM00005_sort.Rows(i).Item("pod_pkgven").ToString & Environment.NewLine
                                    End If



                                    gspStr = "sp_select_VNCNTINF_PGM0005 '" & "" & "','" & rs_PGM00005_sort.Rows(i).Item("pod_pkgven") & "'"

                                    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                    rtnLong = execute_SQLStatement(gspStr, rs_VNCNTINF, rtnStr)
                                    Me.Cursor = Windows.Forms.Cursors.Default
                                    If rtnLong <> RC_SUCCESS Then
                                        MsgBox("Error on loading PGM00005 #003 sp_select_VNCNTINF_PGM0005 : " & rtnStr)
                                        Exit Sub

                                    End If 'Header End



                                    'NewOderno = txtBJNo.Text

                                    Dim poh_cocde As String = cboCoCde.Text
                                    Dim poh_ordno As String = txtBJNo.Text
                                    Dim poh_ver As Integer = 1
                                    Dim poh_issdat As DateTime = DateTime.Now.ToShortDateString
                                    Dim poh_revdat As DateTime = DateTime.Now.ToShortDateString
                                    Dim poh_status As String = "OPE"
                                    Dim poh_cus1no As String = ""
                                    Dim poh_cus2no As String = ""
                                    Dim poh_saldiv As String = ""
                                    Dim poh_saltem As String = ""
                                    Dim poh_salrep As String = ""
                                    Dim poh_ToNo As String = ""
                                    Dim poh_ToVer As String = ""
                                    Dim poh_ToSts As String = ""
                                    Dim poh_ToIsdat As DateTime = "1900/01/01"
                                    Dim poh_ToRevdat As DateTime = "1900/01/01"
                                    Dim poh_ToRefqut As String = ""
                                    Dim poh_potyp As String = ""
                                    Dim poh_ScNo As String = ""
                                    Dim poh_ScVer As String = ""
                                    Dim poh_ScSts As String = ""
                                    Dim poh_ScIsdat As DateTime = "1900/01/01"
                                    Dim poh_ScRevdat As DateTime = "1900/01/01"
                                    Dim poh_ScPodat As DateTime = "1900/01/01"
                                    Dim poh_ScCandat As DateTime = "1900/01/01"
                                    Dim poh_ScShpdatstr As DateTime = "1900/01/01"
                                    Dim poh_ScShpdatend As DateTime = "1900/01/01"
                                    Dim poh_ScRemark As String = ""
                                    Dim poh_Reqno As String = rs_PGM00005_sort.Rows(i).Item("pod_ordno")
                                    Dim poh_Pkgven As String = rs_PGM00005_sort.Rows(i).Item("pod_pkgven")
                                    Dim poh_Address As String

                                    Dim dr_Address() As DataRow
                                    dr_Address = rs_VNCNTINF.Tables("RESULT").Select("vci_cnttyp = 'M'")
                                    If dr_Address.Length <> 0 Then
                                        poh_Address = dr_Address(0)("vci_adr")
                                    Else
                                        poh_Address = ""
                                    End If

                                    Dim poh_ttlamt As Decimal = 0
                                    Dim poh_ctnper As String = ""
                                    Dim poh_tel As String = ""

                                    Dim dr_ctnper() As DataRow
                                    dr_ctnper = rs_VNCNTINF.Tables("RESULT").Select("vci_cnttyp = 'SALE' and vci_cntdef = 'Y'")
                                    If dr_ctnper.Length <> 0 Then
                                        poh_ctnper = dr_ctnper(0)("vci_cntctp") '
                                        poh_tel = dr_ctnper(0)("vci_cntphn") '
                                    Else
                                        poh_ctnper = ""
                                        poh_tel = ""
                                    End If


                                    Dim poh_Delamt As Decimal = 0
                                    Dim poh_TtlDelamt As Decimal = 0

                                    Dim poh_GenFlag As String = ""
                                    Dim poh_GenType As String = "Req"
                                    Dim poh_apvcnt As Integer = 0



                                    gspStr = "sp_insert_PKORDHDR '" & poh_cocde & "','" & poh_ordno & "'," & poh_ver & ",'" & _
                                    poh_issdat & "','" & poh_revdat & "','" & poh_status & "','" & poh_cus1no & "','" & _
                                    poh_cus2no & "','" & poh_saldiv & "','" & poh_saltem & "','" & poh_salrep & "','" & _
                                    poh_ToNo & "','" & poh_ToVer & "','" & poh_ToSts & "','" & poh_ToIsdat & "','" & _
                                    poh_ToRevdat & "','" & poh_ToRefqut & "','" & poh_potyp & "','" & poh_ScNo & "','" & _
                                    poh_ScVer & "','" & poh_ScSts & "','" & poh_ScIsdat & "','" & poh_ScRevdat & "','" & _
                                    poh_ScPodat & "','" & poh_ScCandat & "','" & poh_ScShpdatstr & "','" & poh_ScShpdatend & "','" & _
                                    poh_ScRemark & "','" & poh_Reqno & "','" & poh_Pkgven & "','" & poh_Address & "'," & poh_ttlamt & _
                                    ",'" & poh_ctnper & "','" & poh_tel & "'," & poh_Delamt & "," & poh_TtlDelamt & ",'" & _
                                    poh_GenFlag & "','" & poh_GenType & "'," & poh_apvcnt & ",'" & gsUsrID & "'"

                                    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                    Me.Cursor = Windows.Forms.Cursors.Default
                                    If rtnLong <> RC_SUCCESS Then
                                        MsgBox("Error on loading PGM00005 #003 sp_insert_PKORDHDR : " & rtnStr)
                                        Exit Sub

                                    End If 'Header End




                                    Dim ttlordqty As Decimal = 0
                                    Dim unitprice As Decimal = 0
                                    Dim ttlprice As Decimal = 0
                                    Dim wasper As Integer = 0
                                    Dim wasqty As Integer = 0
                                    Dim finalttlordqty As Decimal = 0
                                    Dim finalttlprice As Decimal = 0
                                    Dim In_was As Decimal = 0

                                    Dim drItem() As DataRow
                                    drItem = rs_PGM00005_sort.Select("pod_pkgitm = '" & dr(x)("pod_pkgitm") & "' and pod_pkgven = '" & dr(x)("pod_pkgven") & "' and pod_untprc =" & dr(x)("pod_untprc") & " and pjd_confrm = 'Y' and R_pod_ordno = ''")


                                    For y As Integer = 0 To drItem.Length - 1
                                        ttlordqty = ttlordqty + drItem(y)("pod_ttlordqty")
                                        unitprice = unitprice + drItem(y)("pod_untprc") * drItem(y)("pod_ttlordqty")
                                        In_was = In_was + drItem(y)("prd_bonqty")
                                    Next
                                    unitprice = unitprice / ttlordqty
                                    'ttlprice = unitprice * ttlordqty

                                    'sQL


                                    'Dim ordqty As Integer = txtPkgOrdQty.Text '-----------------------
                                    'Dim stkqty As Integer = txtStkqty.Text
                                    'Dim sumqty As Integer = ordqty + stkqty
                                    'Dim cate As String = Split(txtCate.Text, " - ")(0)

                                    Dim dr_wasage() As DataRow
                                    dr_wasage = rs_syswasge.Tables("RESULT").Select("pwa_code = '" & dr(x)("pod_cate") & "' and pwa_qtyfrm <= " & ttlordqty & " and pwa_qtyto >= " & ttlordqty)

                                    'gspStr = "sp_select_PKWASGE_PKG02 '" & Split(txtCate.Text, " - ")(0) & "'," & txtPkgOrdQty.Text
                                    'rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                    'If rtnLong <> RC_SUCCESS Then
                                    '    MsgBox("Error on loading txtPkgOrdQty_LostFocus sp_select_PKWASGE_PKG02 :" & rtnStr)
                                    '    Exit Sub
                                    'End If

                                    If dr_wasage.Length <> 0 Then
                                        If dr_wasage(0)("pwa_um") = "%" Then

                                            wasper = Fix(dr_wasage(0).Item("pwa_wasage"))
                                            wasqty = Math.Round(ttlordqty * dr_wasage(0).Item("pwa_wasage") / 100, 0, MidpointRounding.AwayFromZero)
                                            'Math.Round(ttlordqty * dr_wasage(0).Item("pwa_wasage") / 100)

                                        Else
                                            wasper = 0
                                            wasqty = Fix(dr_wasage(0).Item("pwa_wasage"))

                                        End If


                                    End If ' ----------------------

                                    If chkReqWas.Checked = True And In_was <> 0 Then
                                        finalttlordqty = ttlordqty + In_was
                                        finalttlprice = round(unitprice * finalttlordqty, 2)
                                    Else
                                        finalttlordqty = ttlordqty + wasqty
                                        finalttlprice = round(unitprice * finalttlordqty, 2)
                                    End If


                                    gspStr = "sp_select_New_PKORDDTL_seq '" & cboCoCde.Text & "','" & txtBJNo.Text & "'"
                                    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                    rs = Nothing
                                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                    Me.Cursor = Windows.Forms.Cursors.Default
                                    If rtnLong <> RC_SUCCESS Then
                                        MsgBox("Error on saving PGM00005 #004 sp_select_New_PKORDDTL_seq : " & rtnStr)
                                        Exit Sub
                                    End If
                                    newPKORDDTL_req = rs.Tables("RESULT").Rows(0)(0)





                                    If chkReqWas.Checked = True And In_was <> 0 Then
                                        gspStr = "sp_insert_PKORDDTL '" & cboCoCde.Text & "','" & txtBJNo.Text & "','" & newPKORDDTL_req & "','" & _
                                     dr(x)("pod_ordno") & "'," & dr(x)("pod_seq") & "," & unitprice & "," & finalttlprice & "," & ttlordqty & "," & _
                                            wasper & "," & wasqty & "," & finalttlordqty & ",'" & "Y" & "'," & In_was & ",'" & gsUsrID & "'"
                                    Else
                                        gspStr = "sp_insert_PKORDDTL '" & cboCoCde.Text & "','" & txtBJNo.Text & "','" & newPKORDDTL_req & "','" & _
                                       dr(x)("pod_ordno") & "'," & dr(x)("pod_seq") & "," & unitprice & "," & finalttlprice & "," & ttlordqty & "," & _
                                              wasper & "," & wasqty & "," & finalttlordqty & ",'" & "N" & "'," & wasqty & ",'" & gsUsrID & "'"
                                    End If



                                    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                    rs = Nothing
                                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                    Me.Cursor = Windows.Forms.Cursors.Default
                                    If rtnLong <> RC_SUCCESS Then
                                        MsgBox("Error on saving PGM00005 #004 sp_insert_PKORDDTL : " & rtnStr)
                                        Exit Sub
                                    End If





                                    If dr(x)("pjd_recsts") = "new" Then
                                        gspStr = "sp_insert_PKGRPDTL '" & cboCoCde.Text & "','" & txtBJNo.Text & "','" & _
                                                    dr(x)("pod_ordno") & "'," & _
                                                    dr(x)("pod_seq") & ",'" & _
                                                    dr(x)("pod_ordno") & "'," & _
                                                   dr(x)("pod_seq") & ",'" & _
                                                    LCase(gsUsrID) & "'"
                                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                        rs = Nothing
                                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                        Me.Cursor = Windows.Forms.Cursors.Default
                                        If rtnLong <> RC_SUCCESS Then
                                            MsgBox("Error on saving PGM00005 #004 sp_insert_PKGRPDTL : " & rtnStr)
                                            Exit Sub
                                        End If


                                        gspStr = "sp_insert_PKMAPDTL '" & cboCoCde.Text & "','" & "5" & "','" & txtBJNo.Text & "'," & _
                                                     newPKORDDTL_req & ",'" & _
                                                   dr(x)("pod_ordno") & "'," & _
                                                   dr(x)("pod_seq") & ",'" & _
                                                    LCase(gsUsrID) & "'"
                                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                        rs = Nothing
                                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                        Me.Cursor = Windows.Forms.Cursors.Default
                                        If rtnLong <> RC_SUCCESS Then
                                            MsgBox("Error on saving PGM00005 #004 sp_insert_PKMAPDTL : " & rtnStr)
                                            Exit Sub
                                        End If



                                    End If





                                    currcentitem = LTrim(RTrim(dr(x)("pod_pkgitm")))
                                    currcentprice = LTrim(RTrim(dr(x)("pod_untprc")))

                                Else 'Add detail only



                                    Dim ttlordqty As Decimal = 0
                                    Dim unitprice As Decimal = 0
                                    Dim ttlprice As Decimal = 0
                                    Dim wasper As Integer = 0
                                    Dim wasqty As Integer = 0
                                    Dim finalttlordqty As Decimal = 0
                                    Dim finalttlprice As Decimal = 0
                                    Dim In_was As Decimal = 0

                                    Dim drItem() As DataRow
                                    drItem = rs_PGM00005_sort.Select("pod_pkgitm = '" & dr(x)("pod_pkgitm") & "' and pod_pkgven = '" & dr(x)("pod_pkgven") & "' and pod_untprc =" & dr(x)("pod_untprc") & " and pjd_confrm = 'Y' and R_pod_ordno = ''")


                                    For y As Integer = 0 To drItem.Length - 1
                                        ttlordqty = ttlordqty + drItem(y)("pod_ttlordqty")
                                        unitprice = unitprice + drItem(y)("pod_untprc") * drItem(y)("pod_ttlordqty")
                                        In_was = In_was + drItem(y)("prd_bonqty")
                                    Next
                                    unitprice = unitprice / ttlordqty
                                    'ttlprice = unitprice * ttlordqty


                                    Dim dr_wasage() As DataRow
                                    dr_wasage = rs_syswasge.Tables("RESULT").Select("pwa_code = '" & dr(x)("pod_cate") & "' and pwa_qtyfrm <= " & ttlordqty & " and pwa_qtyto >= " & ttlordqty)


                                    If dr_wasage.Length <> 0 Then
                                        If dr_wasage(0)("pwa_um") = "%" Then

                                            wasper = Fix(dr_wasage(0).Item("pwa_wasage"))
                                            ' wasqty = Math.Round(ttlordqty * dr_wasage(0).Item("pwa_wasage") / 100)
                                            wasqty = Math.Round(ttlordqty * dr_wasage(0).Item("pwa_wasage") / 100, 0, MidpointRounding.AwayFromZero)

                                        Else
                                            wasper = 0
                                            wasqty = Fix(dr_wasage(0).Item("pwa_wasage"))

                                        End If


                                    End If ' ----------------------

                                    If chkReqWas.Checked = True And In_was <> 0 Then
                                        finalttlordqty = ttlordqty + In_was
                                        finalttlprice = round(unitprice * finalttlordqty, 2)
                                    Else
                                        finalttlordqty = ttlordqty + wasqty
                                        finalttlprice = round(unitprice * finalttlordqty, 2)
                                    End If


                                    'sQL


                                    gspStr = "sp_select_New_PKORDDTL_seq '" & cboCoCde.Text & "','" & txtBJNo.Text & "'"
                                    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                    rs = Nothing
                                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                    Me.Cursor = Windows.Forms.Cursors.Default
                                    If rtnLong <> RC_SUCCESS Then
                                        MsgBox("Error on saving PGM00005 #004 sp_select_New_PKORDDTL_seq : " & rtnStr)
                                        Exit Sub
                                    End If
                                    newPKORDDTL_req = rs.Tables("RESULT").Rows(0)(0)



                                    If chkReqWas.Checked = True And In_was <> 0 Then
                                        gspStr = "sp_insert_PKORDDTL '" & cboCoCde.Text & "','" & txtBJNo.Text & "','" & newPKORDDTL_req & "','" & _
                                     dr(x)("pod_ordno") & "'," & dr(x)("pod_seq") & "," & unitprice & "," & finalttlprice & "," & ttlordqty & "," & _
                                            wasper & "," & wasqty & "," & finalttlordqty & ",'" & "Y" & "'," & In_was & ",'" & gsUsrID & "'"
                                    Else
                                        gspStr = "sp_insert_PKORDDTL '" & cboCoCde.Text & "','" & txtBJNo.Text & "','" & newPKORDDTL_req & "','" & _
                                       dr(x)("pod_ordno") & "'," & dr(x)("pod_seq") & "," & unitprice & "," & finalttlprice & "," & ttlordqty & "," & _
                                              wasper & "," & wasqty & "," & finalttlordqty & ",'" & "N" & "'," & wasqty & ",'" & gsUsrID & "'"
                                    End If


                                    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                    rs = Nothing
                                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                    Me.Cursor = Windows.Forms.Cursors.Default
                                    If rtnLong <> RC_SUCCESS Then
                                        MsgBox("Error on saving PGM00005 #004 sp_insert_PKORDDTL : " & rtnStr)
                                        Exit Sub
                                    End If




                                    If dr(x)("pjd_recsts") = "new" Then
                                        gspStr = "sp_insert_PKGRPDTL '" & cboCoCde.Text & "','" & txtBJNo.Text & "','" & _
                                                    dr(x)("pod_ordno") & "'," & _
                                                    dr(x)("pod_seq") & ",'" & _
                                                    dr(x)("pod_ordno") & "'," & _
                                                   dr(x)("pod_seq") & ",'" & _
                                                    LCase(gsUsrID) & "'"
                                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                        rs = Nothing
                                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                        Me.Cursor = Windows.Forms.Cursors.Default
                                        If rtnLong <> RC_SUCCESS Then
                                            MsgBox("Error on saving PGM00005 #004 sp_insert_PKGRPDTL : " & rtnStr)
                                            Exit Sub
                                        End If

                                        gspStr = "sp_insert_PKMAPDTL '" & cboCoCde.Text & "','" & "5" & "','" & txtBJNo.Text & "'," & _
                                                     newPKORDDTL_req & ",'" & _
                                                   dr(x)("pod_ordno") & "'," & _
                                                   dr(x)("pod_seq") & ",'" & _
                                                    LCase(gsUsrID) & "'"
                                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                        rs = Nothing
                                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                        Me.Cursor = Windows.Forms.Cursors.Default
                                        If rtnLong <> RC_SUCCESS Then
                                            MsgBox("Error on saving PGM00005 #004 sp_insert_PKMAPDTL : " & rtnStr)
                                            Exit Sub
                                        End If
                                    End If



                                    currcentitem = LTrim(RTrim(dr(x)("pod_pkgitm")))
                                    currcentprice = LTrim(RTrim(dr(x)("pod_untprc")))


                                End If
                            Next


                        End If

                        'For i As Integer = 0 To rs_PGM00005.Tables("RESULT").Rows.Count - 1
                        '-------------------------------------------------------------------------------------------------'
                        'Insert grp dtl
                        'If rs_PGM00005.Tables("RESULT").Rows(i)("pjd_recsts") = "new" Then
                        '    gspStr = "sp_insert_PKGRPDTL '" & cboCoCde.Text & "','" & txtBJNo.Text & "'," & _
                        '                i + 1 & ",'" & _
                        '                rs_PGM00005.Tables("RESULT").Rows(i)("pod_ordno") & "'," & _
                        '                rs_PGM00005.Tables("RESULT").Rows(i)("pod_seq") & ",'" & _
                        '                rs_PGM00005.Tables("RESULT").Rows(i)("pod_ordno") & "'," & _
                        '                rs_PGM00005.Tables("RESULT").Rows(i)("pod_seq") & ",'" & _
                        '                LCase(gsUsrID) & "'"
                        '    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        '    rs = Nothing
                        '    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        '    Me.Cursor = Windows.Forms.Cursors.Default
                        '    If rtnLong <> RC_SUCCESS Then
                        '        MsgBox("Error on saving PGM00005 #004 sp_insert_PKGRPDTL : " & rtnStr)
                        '        Exit Sub
                        '    End If

                        '    '-----------------------------------------------------------------------------------------------------

                        '    'gspStr = "sp_insert_PKORDDTL '" & cboCoCde.Text & "','" & txtBJNo.Text & "','" & _
                        '    'rs_PGM00005_sort.Rows(i).Item("pod_ordno") & "'," & rs_PGM00005_sort.Rows(i).Item("pod_seq") & ",'" & _
                        '    'gsUsrID & "'"
                        '    'Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        '    'rs = Nothing
                        '    'rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        '    'Me.Cursor = Windows.Forms.Cursors.Default
                        '    'If rtnLong <> RC_SUCCESS Then
                        '    '    MsgBox("Error on saving PGM00005 #004 sp_insert_PKORDDTL : " & rtnStr)
                        '    '    Exit Sub
                        '    'End If


                        'Else
                        '    gspStr = "sp_update_PKGRPDTL '" & cboCoCde.Text & "','" & txtBJNo.Text & "'," & _
                        '                    i + 1 & ",'" & _
                        '                    rs_PGM00005.Tables("RESULT").Rows(i)("pod_ordno") & "'," & _
                        '                    rs_PGM00005.Tables("RESULT").Rows(i)("pod_seq") & ",'" & _
                        '                    rs_PGM00005.Tables("RESULT").Rows(i)("pod_ordno") & "'," & _
                        '                    rs_PGM00005.Tables("RESULT").Rows(i)("pod_seq") & ",'" & _
                        '                    LCase(gsUsrID) & "'"
                        '    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        '    rs = Nothing
                        '    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        '    Me.Cursor = Windows.Forms.Cursors.Default
                        '    If rtnLong <> RC_SUCCESS Then
                        '        MsgBox("Error on saving PGM00005 #005 sp_update_PKGRPDTL : " & rtnStr)
                        '        Exit Sub
                        '    End If
                        'End If
                        '----------------------------------------------------------------------------------------------------------'

                        currentVendor = rs_PGM00005_sort.Rows(i).Item("pod_pkgven")
                    End If
                Next

            ElseIf chkReGen.Checked = True Then



                If MsgBox("Are you sure that Rearrange the Order(s) by selected Request(s)? ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                Else
                    Exit Sub
                End If



                If checkExistPO() = False Then
                    Exit Sub
                End If



                If check_differentPrice_RE(rs_PGM00005) = False Then
                    Exit Sub
                End If


                If chkReqWas.Checked = True Then
                    If check_ZeroWast(rs_PGM00005) = False Then
                        Exit Sub
                    End If
                End If

                Dim rs_PGM00005_sort As DataTable
                Dim dv As DataView

                dv = rs_PGM00005.Tables("RESULT").DefaultView
                'dv.Sort = "pod_pkgven,pod_ordno,pod_seq asc"
                dv.Sort = "pod_pkgven,pod_pkgitm,pod_untprc"
                rs_PGM00005_sort = dv.ToTable

                dv = Nothing


                Dim currentVendor As String
                For i As Integer = 0 To rs_PGM00005_sort.Rows.Count - 1
                    'rs_PGM00005_sort.DefaultView.Sort = "pod_pkgven,pod_ordno,pod_seq"
                    'rs_PGM00005_sort.DefaultView.Sort = "pod_pkgven asc"
                    If rs_PGM00005_sort.Rows(i).Item("pjd_confrm") = "Y" Then
                        If currentVendor <> rs_PGM00005_sort.Rows(i).Item("pod_pkgven").ToString Then



                            Dim dr() As DataRow
                            Dim currcentitem As String = ""
                            Dim currcentprice As Decimal = -1
                            Dim NewOderno As String = ""
                            '                        dr = rs_PGM00005_sort.Select("pod_pkgven = " & rs_PGM00005_sort.Rows(i).Item("pod_pkgven") & " and pjd_confrm = 'Y'")
                            dr = rs_PGM00005_sort.Select("pod_pkgven = " & rs_PGM00005_sort.Rows(i).Item("pod_pkgven") & " and pjd_confrm = 'Y'")
                            For x As Integer = 0 To dr.Length - 1 ''Handel New Insert
                                If currcentitem = dr(x)("pod_pkgitm") And currcentprice = dr(x)("pod_untprc") Then 'Update PKreqdtl order no + seq

                                    gspStr = "sp_update_PKREQDTL_05 '" & txtBJNo.Text & "','" & dr(x)("pod_pkgven") & "','" & _
                                    dr(x)("pod_pkgitm") & "'," & dr(x)("pod_untprc") & ",'" & dr(x)("pod_ordno") & "'," & dr(x)("pod_seq") & ",'" & LCase(gsUsrID) & "'"
                                    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                    Me.Cursor = Windows.Forms.Cursors.Default
                                    If rtnLong <> RC_SUCCESS Then
                                        MsgBox("Error on loading PGM00005 #003 sp_update_PKREQDTL_05 : " & rtnStr)

                                    End If

                                    If dr(x)("pjd_recsts") = "new" Then
                                        gspStr = "sp_insert_PKGRPDTL '" & cboCoCde.Text & "','" & txtBJNo.Text & "','" & _
                                                    dr(x)("pod_ordno") & "'," & _
                                                    dr(x)("pod_seq") & ",'" & _
                                                    dr(x)("pod_ordno") & "'," & _
                                                   dr(x)("pod_seq") & ",'" & _
                                                    LCase(gsUsrID) & "'"
                                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                        rs = Nothing
                                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                        Me.Cursor = Windows.Forms.Cursors.Default
                                        If rtnLong <> RC_SUCCESS Then
                                            MsgBox("Error on saving PGM00005 #004 sp_insert_PKGRPDTL : " & rtnStr)
                                            Exit Sub
                                        End If

                                        gspStr = "sp_insert_PKMAPDTL '" & cboCoCde.Text & "','" & "5" & "','" & txtBJNo.Text & "'," & _
                                                     newPKORDDTL_req & ",'" & _
                                                   dr(x)("pod_ordno") & "'," & _
                                                   dr(x)("pod_seq") & ",'" & _
                                                    LCase(gsUsrID) & "'"
                                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                        rs = Nothing
                                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                        Me.Cursor = Windows.Forms.Cursors.Default
                                        If rtnLong <> RC_SUCCESS Then
                                            MsgBox("Error on saving PGM00005 #004 sp_insert_PKMAPDTL : " & rtnStr)
                                            Exit Sub
                                        End If
                                    End If


                                    currcentitem = LTrim(RTrim(dr(x)("pod_pkgitm")))
                                    currcentprice = LTrim(RTrim(dr(x)("pod_untprc")))

                                ElseIf (currcentitem = dr(x)("pod_pkgitm") And currcentprice <> dr(x)("pod_untprc")) Or _
                                (currcentitem = "" And currcentprice = -1) Then  ' New header + detail


                                    rs = Nothing 'Header Head
                                    gspStr = "sp_select_DOC_GEN '" & cboCoCde.Text & "','KG','" & LCase(gsUsrID) & "'"
                                    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                    Me.Cursor = Windows.Forms.Cursors.Default
                                    If rtnLong <> RC_SUCCESS Then
                                        MsgBox("Error on loading PGM00005 #003 sp_select_DOC_GEN : " & rtnStr)
                                        Exit Sub
                                    Else
                                        txtBJNo.Text = rs.Tables("RESULT").Rows(0)(0)
                                        msg += "Order NO. : " & txtBJNo.Text & " For Vendor " & rs_PGM00005_sort.Rows(i).Item("pod_pkgven").ToString & Environment.NewLine
                                    End If



                                    gspStr = "sp_select_VNCNTINF_PGM0005 '" & "" & "','" & rs_PGM00005_sort.Rows(i).Item("pod_pkgven") & "'"

                                    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                    rtnLong = execute_SQLStatement(gspStr, rs_VNCNTINF, rtnStr)
                                    Me.Cursor = Windows.Forms.Cursors.Default
                                    If rtnLong <> RC_SUCCESS Then
                                        MsgBox("Error on loading PGM00005 #003 sp_select_VNCNTINF_PGM0005 : " & rtnStr)
                                        Exit Sub

                                    End If 'Header End



                                    'NewOderno = txtBJNo.Text

                                    Dim poh_cocde As String = cboCoCde.Text
                                    Dim poh_ordno As String = txtBJNo.Text
                                    Dim poh_ver As Integer = 1
                                    Dim poh_issdat As DateTime = DateTime.Now.ToShortDateString
                                    Dim poh_revdat As DateTime = DateTime.Now.ToShortDateString
                                    Dim poh_status As String = "OPE"
                                    Dim poh_cus1no As String = ""
                                    Dim poh_cus2no As String = ""
                                    Dim poh_saldiv As String = ""
                                    Dim poh_saltem As String = ""
                                    Dim poh_salrep As String = ""
                                    Dim poh_ToNo As String = ""
                                    Dim poh_ToVer As String = ""
                                    Dim poh_ToSts As String = ""
                                    Dim poh_ToIsdat As DateTime = "1900/01/01"
                                    Dim poh_ToRevdat As DateTime = "1900/01/01"
                                    Dim poh_ToRefqut As String = ""
                                    Dim poh_potyp As String = ""
                                    Dim poh_ScNo As String = ""
                                    Dim poh_ScVer As String = ""
                                    Dim poh_ScSts As String = ""
                                    Dim poh_ScIsdat As DateTime = "1900/01/01"
                                    Dim poh_ScRevdat As DateTime = "1900/01/01"
                                    Dim poh_ScPodat As DateTime = "1900/01/01"
                                    Dim poh_ScCandat As DateTime = "1900/01/01"
                                    Dim poh_ScShpdatstr As DateTime = "1900/01/01"
                                    Dim poh_ScShpdatend As DateTime = "1900/01/01"
                                    Dim poh_ScRemark As String = ""
                                    Dim poh_Reqno As String = rs_PGM00005_sort.Rows(i).Item("pod_ordno")
                                    Dim poh_Pkgven As String = rs_PGM00005_sort.Rows(i).Item("pod_pkgven")
                                    Dim poh_Address As String

                                    Dim dr_Address() As DataRow
                                    dr_Address = rs_VNCNTINF.Tables("RESULT").Select("vci_cnttyp = 'M'")
                                    If dr_Address.Length <> 0 Then
                                        poh_Address = dr_Address(0)("vci_adr")
                                    Else
                                        poh_Address = ""
                                    End If

                                    Dim poh_ttlamt As Decimal = 0
                                    Dim poh_ctnper As String = ""
                                    Dim poh_tel As String = ""

                                    Dim dr_ctnper() As DataRow
                                    dr_ctnper = rs_VNCNTINF.Tables("RESULT").Select("vci_cnttyp = 'SALE' and vci_cntdef = 'Y'")
                                    If dr_ctnper.Length <> 0 Then
                                        poh_ctnper = dr_ctnper(0)("vci_cntctp") '
                                        poh_tel = dr_ctnper(0)("vci_cntphn") '
                                    Else
                                        poh_ctnper = ""
                                        poh_tel = ""
                                    End If


                                    Dim poh_Delamt As Decimal = 0
                                    Dim poh_TtlDelamt As Decimal = 0

                                    Dim poh_GenFlag As String = ""
                                    Dim poh_GenType As String = "Req"
                                    Dim poh_apvcnt As Integer = 0



                                    gspStr = "sp_insert_PKORDHDR '" & poh_cocde & "','" & poh_ordno & "'," & poh_ver & ",'" & _
                                    poh_issdat & "','" & poh_revdat & "','" & poh_status & "','" & poh_cus1no & "','" & _
                                    poh_cus2no & "','" & poh_saldiv & "','" & poh_saltem & "','" & poh_salrep & "','" & _
                                    poh_ToNo & "','" & poh_ToVer & "','" & poh_ToSts & "','" & poh_ToIsdat & "','" & _
                                    poh_ToRevdat & "','" & poh_ToRefqut & "','" & poh_potyp & "','" & poh_ScNo & "','" & _
                                    poh_ScVer & "','" & poh_ScSts & "','" & poh_ScIsdat & "','" & poh_ScRevdat & "','" & _
                                    poh_ScPodat & "','" & poh_ScCandat & "','" & poh_ScShpdatstr & "','" & poh_ScShpdatend & "','" & _
                                    poh_ScRemark & "','" & poh_Reqno & "','" & poh_Pkgven & "','" & poh_Address & "'," & poh_ttlamt & _
                                    ",'" & poh_ctnper & "','" & poh_tel & "'," & poh_Delamt & "," & poh_TtlDelamt & ",'" & _
                                    poh_GenFlag & "','" & poh_GenType & "'," & poh_apvcnt & ",'" & gsUsrID & "'"

                                    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                    Me.Cursor = Windows.Forms.Cursors.Default
                                    If rtnLong <> RC_SUCCESS Then
                                        MsgBox("Error on loading PGM00005 #003 sp_insert_PKORDHDR : " & rtnStr)
                                        Exit Sub

                                    End If 'Header End




                                    Dim ttlordqty As Decimal = 0
                                    Dim unitprice As Decimal = 0
                                    Dim ttlprice As Decimal = 0
                                    Dim wasper As Integer = 0
                                    Dim wasqty As Integer = 0
                                    Dim finalttlordqty As Decimal = 0
                                    Dim finalttlprice As Decimal = 0
                                    Dim In_was As Decimal = 0

                                    Dim drItem() As DataRow
                                    drItem = rs_PGM00005_sort.Select("pod_pkgitm = '" & dr(x)("pod_pkgitm") & "' and pod_pkgven = '" & dr(x)("pod_pkgven") & "' and pod_untprc =" & dr(x)("pod_untprc") & " and pjd_confrm = 'Y'")


                                    For y As Integer = 0 To drItem.Length - 1
                                        ttlordqty = ttlordqty + drItem(y)("pod_ttlordqty")
                                        unitprice = unitprice + drItem(y)("pod_untprc") * drItem(y)("pod_ttlordqty")
                                        In_was = In_was + drItem(y)("prd_bonqty")
                                    Next
                                    unitprice = unitprice / ttlordqty
                                    'ttlprice = unitprice * ttlordqty

                                    'sQL


                                    'Dim ordqty As Integer = txtPkgOrdQty.Text '-----------------------
                                    'Dim stkqty As Integer = txtStkqty.Text
                                    'Dim sumqty As Integer = ordqty + stkqty
                                    'Dim cate As String = Split(txtCate.Text, " - ")(0)

                                    Dim dr_wasage() As DataRow
                                    dr_wasage = rs_syswasge.Tables("RESULT").Select("pwa_code = '" & dr(x)("pod_cate") & "' and pwa_qtyfrm <= " & ttlordqty & " and pwa_qtyto >= " & ttlordqty)

                                    'gspStr = "sp_select_PKWASGE_PKG02 '" & Split(txtCate.Text, " - ")(0) & "'," & txtPkgOrdQty.Text
                                    'rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                    'If rtnLong <> RC_SUCCESS Then
                                    '    MsgBox("Error on loading txtPkgOrdQty_LostFocus sp_select_PKWASGE_PKG02 :" & rtnStr)
                                    '    Exit Sub
                                    'End If

                                    If dr_wasage.Length <> 0 Then
                                        If dr_wasage(0)("pwa_um") = "%" Then

                                            wasper = Fix(dr_wasage(0).Item("pwa_wasage"))
                                            wasqty = Math.Round(ttlordqty * dr_wasage(0).Item("pwa_wasage") / 100, 0, MidpointRounding.AwayFromZero)
                                            'Math.Round(ttlordqty * dr_wasage(0).Item("pwa_wasage") / 100)

                                        Else
                                            wasper = 0
                                            wasqty = Fix(dr_wasage(0).Item("pwa_wasage"))

                                        End If


                                    End If ' ----------------------

                                    If chkReqWas.Checked = True And In_was <> 0 Then
                                        finalttlordqty = ttlordqty + In_was
                                        finalttlprice = round(unitprice * finalttlordqty, 2)
                                    Else
                                        finalttlordqty = ttlordqty + wasqty
                                        finalttlprice = round(unitprice * finalttlordqty, 2)
                                    End If


                                    gspStr = "sp_select_New_PKORDDTL_seq '" & cboCoCde.Text & "','" & txtBJNo.Text & "'"
                                    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                    rs = Nothing
                                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                    Me.Cursor = Windows.Forms.Cursors.Default
                                    If rtnLong <> RC_SUCCESS Then
                                        MsgBox("Error on saving PGM00005 #004 sp_select_New_PKORDDTL_seq : " & rtnStr)
                                        Exit Sub
                                    End If
                                    newPKORDDTL_req = rs.Tables("RESULT").Rows(0)(0)



                                    If chkReqWas.Checked = True And In_was <> 0 Then
                                        gspStr = "sp_insert_PKORDDTL '" & cboCoCde.Text & "','" & txtBJNo.Text & "','" & newPKORDDTL_req & "','" & _
                                     dr(x)("pod_ordno") & "'," & dr(x)("pod_seq") & "," & unitprice & "," & finalttlprice & "," & ttlordqty & "," & _
                                            wasper & "," & wasqty & "," & finalttlordqty & ",'" & "Y" & "'," & In_was & ",'" & gsUsrID & "'"
                                    Else
                                        gspStr = "sp_insert_PKORDDTL '" & cboCoCde.Text & "','" & txtBJNo.Text & "','" & newPKORDDTL_req & "','" & _
                                       dr(x)("pod_ordno") & "'," & dr(x)("pod_seq") & "," & unitprice & "," & finalttlprice & "," & ttlordqty & "," & _
                                              wasper & "," & wasqty & "," & finalttlordqty & ",'" & "N" & "'," & wasqty & ",'" & gsUsrID & "'"
                                    End If

                                    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                    rs = Nothing
                                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                    Me.Cursor = Windows.Forms.Cursors.Default
                                    If rtnLong <> RC_SUCCESS Then
                                        MsgBox("Error on saving PGM00005 #004 sp_insert_PKORDDTL : " & rtnStr)
                                        Exit Sub
                                    End If





                                    If dr(x)("pjd_recsts") = "new" Then
                                        gspStr = "sp_insert_PKGRPDTL '" & cboCoCde.Text & "','" & txtBJNo.Text & "','" & _
                                                    dr(x)("pod_ordno") & "'," & _
                                                    dr(x)("pod_seq") & ",'" & _
                                                    dr(x)("pod_ordno") & "'," & _
                                                   dr(x)("pod_seq") & ",'" & _
                                                    LCase(gsUsrID) & "'"
                                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                        rs = Nothing
                                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                        Me.Cursor = Windows.Forms.Cursors.Default
                                        If rtnLong <> RC_SUCCESS Then
                                            MsgBox("Error on saving PGM00005 #004 sp_insert_PKGRPDTL : " & rtnStr)
                                            Exit Sub
                                        End If

                                        gspStr = "sp_insert_PKMAPDTL '" & cboCoCde.Text & "','" & "5" & "','" & txtBJNo.Text & "'," & _
                                                     newPKORDDTL_req & ",'" & _
                                                   dr(x)("pod_ordno") & "'," & _
                                                   dr(x)("pod_seq") & ",'" & _
                                                    LCase(gsUsrID) & "'"
                                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                        rs = Nothing
                                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                        Me.Cursor = Windows.Forms.Cursors.Default
                                        If rtnLong <> RC_SUCCESS Then
                                            MsgBox("Error on saving PGM00005 #004 sp_insert_PKMAPDTL : " & rtnStr)
                                            Exit Sub
                                        End If
                                    End If



                                    currcentitem = LTrim(RTrim(dr(x)("pod_pkgitm")))
                                    currcentprice = LTrim(RTrim(dr(x)("pod_untprc")))

                                Else 'Add detail only



                                    Dim ttlordqty As Decimal = 0
                                    Dim unitprice As Decimal = 0
                                    Dim ttlprice As Decimal = 0
                                    Dim wasper As Integer = 0
                                    Dim wasqty As Integer = 0
                                    Dim finalttlordqty As Decimal = 0
                                    Dim finalttlprice As Decimal = 0
                                    Dim In_was As Decimal = 0

                                    Dim drItem() As DataRow
                                    drItem = rs_PGM00005_sort.Select("pod_pkgitm = '" & dr(x)("pod_pkgitm") & "' and pod_pkgven = '" & dr(x)("pod_pkgven") & "' and pod_untprc =" & dr(x)("pod_untprc") & " and pjd_confrm = 'Y'")


                                    For y As Integer = 0 To drItem.Length - 1
                                        ttlordqty = ttlordqty + drItem(y)("pod_ttlordqty")
                                        unitprice = unitprice + drItem(y)("pod_untprc") * drItem(y)("pod_ttlordqty")
                                        In_was = In_was + drItem(y)("prd_bonqty")
                                    Next
                                    unitprice = unitprice / ttlordqty
                                    'ttlprice = unitprice * ttlordqty


                                    Dim dr_wasage() As DataRow
                                    dr_wasage = rs_syswasge.Tables("RESULT").Select("pwa_code = '" & dr(x)("pod_cate") & "' and pwa_qtyfrm <= " & ttlordqty & " and pwa_qtyto >= " & ttlordqty)


                                    If dr_wasage.Length <> 0 Then
                                        If dr_wasage(0)("pwa_um") = "%" Then

                                            wasper = Fix(dr_wasage(0).Item("pwa_wasage"))
                                            ' wasqty = Math.Round(ttlordqty * dr_wasage(0).Item("pwa_wasage") / 100)
                                            wasqty = Math.Round(ttlordqty * dr_wasage(0).Item("pwa_wasage") / 100, 0, MidpointRounding.AwayFromZero)

                                        Else
                                            wasper = 0
                                            wasqty = Fix(dr_wasage(0).Item("pwa_wasage"))

                                        End If


                                    End If ' ----------------------

                                    If chkReqWas.Checked = True And In_was <> 0 Then
                                        finalttlordqty = ttlordqty + In_was
                                        finalttlprice = round(unitprice * finalttlordqty, 2)
                                    Else
                                        finalttlordqty = ttlordqty + wasqty
                                        finalttlprice = round(unitprice * finalttlordqty, 2)
                                    End If


                                    'sQL

                                    gspStr = "sp_select_New_PKORDDTL_seq '" & cboCoCde.Text & "','" & txtBJNo.Text & "'"
                                    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                    rs = Nothing
                                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                    Me.Cursor = Windows.Forms.Cursors.Default
                                    If rtnLong <> RC_SUCCESS Then
                                        MsgBox("Error on saving PGM00005 #004 sp_select_New_PKORDDTL_seq : " & rtnStr)
                                        Exit Sub
                                    End If
                                    newPKORDDTL_req = rs.Tables("RESULT").Rows(0)(0)


                                    If chkReqWas.Checked = True And In_was <> 0 Then
                                        gspStr = "sp_insert_PKORDDTL '" & cboCoCde.Text & "','" & txtBJNo.Text & "','" & newPKORDDTL_req & "','" & _
                                     dr(x)("pod_ordno") & "'," & dr(x)("pod_seq") & "," & unitprice & "," & finalttlprice & "," & ttlordqty & "," & _
                                            wasper & "," & wasqty & "," & finalttlordqty & ",'" & "Y" & "'," & In_was & ",'" & gsUsrID & "'"
                                    Else
                                        gspStr = "sp_insert_PKORDDTL '" & cboCoCde.Text & "','" & txtBJNo.Text & "','" & newPKORDDTL_req & "','" & _
                                       dr(x)("pod_ordno") & "'," & dr(x)("pod_seq") & "," & unitprice & "," & finalttlprice & "," & ttlordqty & "," & _
                                              wasper & "," & wasqty & "," & finalttlordqty & ",'" & "N" & "'," & wasqty & ",'" & gsUsrID & "'"
                                    End If

                                    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                    rs = Nothing
                                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                    Me.Cursor = Windows.Forms.Cursors.Default
                                    If rtnLong <> RC_SUCCESS Then
                                        MsgBox("Error on saving PGM00005 #004 sp_insert_PKORDDTL : " & rtnStr)
                                        Exit Sub
                                    End If




                                    If dr(x)("pjd_recsts") = "new" Then
                                        gspStr = "sp_insert_PKGRPDTL '" & cboCoCde.Text & "','" & txtBJNo.Text & "','" & _
                                                    dr(x)("pod_ordno") & "'," & _
                                                    dr(x)("pod_seq") & ",'" & _
                                                    dr(x)("pod_ordno") & "'," & _
                                                   dr(x)("pod_seq") & ",'" & _
                                                    LCase(gsUsrID) & "'"
                                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                        rs = Nothing
                                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                        Me.Cursor = Windows.Forms.Cursors.Default
                                        If rtnLong <> RC_SUCCESS Then
                                            MsgBox("Error on saving PGM00005 #004 sp_insert_PKGRPDTL : " & rtnStr)
                                            Exit Sub
                                        End If

                                        gspStr = "sp_insert_PKMAPDTL '" & cboCoCde.Text & "','" & "5" & "','" & txtBJNo.Text & "'," & _
                                                     newPKORDDTL_req & ",'" & _
                                                   dr(x)("pod_ordno") & "'," & _
                                                   dr(x)("pod_seq") & ",'" & _
                                                    LCase(gsUsrID) & "'"
                                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                        rs = Nothing
                                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                                        Me.Cursor = Windows.Forms.Cursors.Default
                                        If rtnLong <> RC_SUCCESS Then
                                            MsgBox("Error on saving PGM00005 #004 sp_insert_PKMAPDTL : " & rtnStr)
                                            Exit Sub
                                        End If
                                    End If



                                    currcentitem = LTrim(RTrim(dr(x)("pod_pkgitm")))
                                    currcentprice = LTrim(RTrim(dr(x)("pod_untprc")))


                                End If
                            Next


                        End If

                        'For i As Integer = 0 To rs_PGM00005.Tables("RESULT").Rows.Count - 1
                        '-------------------------------------------------------------------------------------------------'
                        'Insert grp dtl
                        'If rs_PGM00005.Tables("RESULT").Rows(i)("pjd_recsts") = "new" Then
                        '    gspStr = "sp_insert_PKGRPDTL '" & cboCoCde.Text & "','" & txtBJNo.Text & "'," & _
                        '                i + 1 & ",'" & _
                        '                rs_PGM00005.Tables("RESULT").Rows(i)("pod_ordno") & "'," & _
                        '                rs_PGM00005.Tables("RESULT").Rows(i)("pod_seq") & ",'" & _
                        '                rs_PGM00005.Tables("RESULT").Rows(i)("pod_ordno") & "'," & _
                        '                rs_PGM00005.Tables("RESULT").Rows(i)("pod_seq") & ",'" & _
                        '                LCase(gsUsrID) & "'"
                        '    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        '    rs = Nothing
                        '    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        '    Me.Cursor = Windows.Forms.Cursors.Default
                        '    If rtnLong <> RC_SUCCESS Then
                        '        MsgBox("Error on saving PGM00005 #004 sp_insert_PKGRPDTL : " & rtnStr)
                        '        Exit Sub
                        '    End If

                        '    '-----------------------------------------------------------------------------------------------------

                        '    'gspStr = "sp_insert_PKORDDTL '" & cboCoCde.Text & "','" & txtBJNo.Text & "','" & _
                        '    'rs_PGM00005_sort.Rows(i).Item("pod_ordno") & "'," & rs_PGM00005_sort.Rows(i).Item("pod_seq") & ",'" & _
                        '    'gsUsrID & "'"
                        '    'Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        '    'rs = Nothing
                        '    'rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        '    'Me.Cursor = Windows.Forms.Cursors.Default
                        '    'If rtnLong <> RC_SUCCESS Then
                        '    '    MsgBox("Error on saving PGM00005 #004 sp_insert_PKORDDTL : " & rtnStr)
                        '    '    Exit Sub
                        '    'End If


                        'Else
                        '    gspStr = "sp_update_PKGRPDTL '" & cboCoCde.Text & "','" & txtBJNo.Text & "'," & _
                        '                    i + 1 & ",'" & _
                        '                    rs_PGM00005.Tables("RESULT").Rows(i)("pod_ordno") & "'," & _
                        '                    rs_PGM00005.Tables("RESULT").Rows(i)("pod_seq") & ",'" & _
                        '                    rs_PGM00005.Tables("RESULT").Rows(i)("pod_ordno") & "'," & _
                        '                    rs_PGM00005.Tables("RESULT").Rows(i)("pod_seq") & ",'" & _
                        '                    LCase(gsUsrID) & "'"
                        '    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        '    rs = Nothing
                        '    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        '    Me.Cursor = Windows.Forms.Cursors.Default
                        '    If rtnLong <> RC_SUCCESS Then
                        '        MsgBox("Error on saving PGM00005 #005 sp_update_PKGRPDTL : " & rtnStr)
                        '        Exit Sub
                        '    End If
                        'End If
                        '----------------------------------------------------------------------------------------------------------'

                        currentVendor = rs_PGM00005_sort.Rows(i).Item("pod_pkgven")
                    End If
                Next


                cancelOrder()

            End If


        End If




        If chkReGen.Checked = False Then
            If flag_Add = True Then
                Dim rs_PGM00005_sort_Update As DataTable
                Dim dv As DataView
                dv = rs_PGM00005.Tables("RESULT").DefaultView
                'dv.Sort = "pod_pkgven,pod_ordno,pod_seq asc"
                dv.Sort = "R_pod_ordno,R_pod_ordseq"
                rs_PGM00005_sort_Update = dv.ToTable

                dv = Nothing
                Dim currentOrdno As String
                Dim currentOrdseq As Integer
                Dim ttlordqty As Integer
                Dim In_was As Integer
                For i As Integer = 0 To rs_PGM00005_sort_Update.Rows.Count - 1
                    'rs_PGM00005_sort.DefaultView.Sort = "pod_pkgven,pod_ordno,pod_seq"
                    'rs_PGM00005_sort.DefaultView.Sort = "pod_pkgven asc"
                    If rs_PGM00005_sort_Update.Rows(i).Item("pjd_confrm") = "Y" And Trim(rs_PGM00005_sort_Update.Rows(i).Item("R_pod_ordno").ToString) <> "" Then
                        If currentOrdno <> rs_PGM00005_sort_Update.Rows(i).Item("R_pod_ordno").ToString Or _
                        currentOrdseq <> rs_PGM00005_sort_Update.Rows(i).Item("R_pod_ordseq") Then

                            gspStr = "sp_select_PKREQDTL_05_Update '" & cboCoCde.Text & "','" & rs_PGM00005_sort_Update.Rows(i).Item("R_pod_ordno") & "'," & _
                    rs_PGM00005_sort_Update.Rows(i).Item("R_pod_ordseq")

                            Me.Cursor = Windows.Forms.Cursors.WaitCursor
                            rs = Nothing
                            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                            Me.Cursor = Windows.Forms.Cursors.Default
                            If rtnLong <> RC_SUCCESS Then
                                MsgBox("Error on saving PGM00005 #004 sp_select_PKREQDTL_05_Update : " & rtnStr)
                                Exit Sub
                            End If

                            ttlordqty = rs.Tables("RESULT").Rows(0).Item(0)
                            In_was = rs.Tables("RESULT").Rows(0).Item(1)
                            rs = Nothing

                            If chkReqWas.Checked = True Then ' And In_was <> 0 Then 01/26/2015
                                gspStr = "sp_update_PKORDDTL_PG05 '" & cboCoCde.Text & "','" & rs_PGM00005_sort_Update.Rows(i).Item("R_pod_ordno") & "'," & _
                  rs_PGM00005_sort_Update.Rows(i).Item("R_pod_ordseq") & "," & ttlordqty & "," & In_was & ",'" & "Y" & "','" & gsUsrID & "'"
                            Else
                                gspStr = "sp_update_PKORDDTL_PG05 '" & cboCoCde.Text & "','" & rs_PGM00005_sort_Update.Rows(i).Item("R_pod_ordno") & "'," & _
                  rs_PGM00005_sort_Update.Rows(i).Item("R_pod_ordseq") & "," & ttlordqty & "," & In_was & ",'" & "N" & "','" & gsUsrID & "'"
                            End If

                            '        gspStr = "sp_update_PKORDDTL_PG05 '" & cboCoCde.Text & "','" & rs_PGM00005_sort_Update.Rows(i).Item("R_pod_ordno") & "'," & _
                            'rs_PGM00005_sort_Update.Rows(i).Item("R_pod_ordseq") & "," & ttlordqty & ",'" & gsUsrID & "'"

                            Me.Cursor = Windows.Forms.Cursors.WaitCursor
                            rs = Nothing
                            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                            Me.Cursor = Windows.Forms.Cursors.Default
                            If rtnLong <> RC_SUCCESS Then
                                MsgBox("Error on saving PGM00005 #004 sp_update_PKORDDTL_PG05 : " & rtnStr)
                                Exit Sub
                            End If

                            msg += "Order NO. : " & rs_PGM00005_sort_Update.Rows(i).Item("R_pod_ordno") & " Seq " & rs_PGM00005_sort_Update.Rows(i).Item("R_pod_ordseq") & " Updated." & Environment.NewLine




                        End If
                    End If

                    currentOrdno = rs_PGM00005_sort_Update.Rows(i).Item("R_pod_ordno")
                    currentOrdseq = rs_PGM00005_sort_Update.Rows(i).Item("R_pod_ordseq")
                Next
            End If

        End If

        'currentVendor = rs_PGM00005_sort.Rows(i).Item("pod_pkgven")




        'Next

        'gspStr = "sp_update_PGM00005 '" & cboCoCde.Text & "','" & txtBJNo.Text & "'"
        'Me.Cursor = Windows.Forms.Cursors.WaitCursor
        'rs = Nothing
        'rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        'Me.Cursor = Windows.Forms.Cursors.Default
        'If rtnLong <> RC_SUCCESS Then
        '    MsgBox("Error on saving PGM00005 #006 sp_update_PGM00005 : " & rtnStr)
        '    Exit Sub
        'End If    zx 

        MsgBox("Record Saved", MsgBoxStyle.Information, "PGM00005 - Save Complete")
        txtMsg.Text = msg
        setStatus("INIT")
        txtBJNo.Focus()
        txtBJNo.SelectAll()
    End Sub

    Private Sub mmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdFind.Click
        Dim rs As New DataSet

        gspStr = "sp_select_PKGRPDTL '" & cboCoCde.Text & "','" & txtBJNo.Text & "','" & LCase(gsUsrID) & "'"

        ''' michael 20170712 new version should use this
        '' gspStr = "sp_select_PKMAPDTL '" & cboCoCde.Text & "','" & txtBJNo.Text & "','" & LCase(gsUsrID) & "'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading PGM00005 #002 sp_select_PJDHONG : " & rtnStr)
            Exit Sub
        End If

        For i As Integer = 0 To rs.Tables("RESULT").Columns.Count - 1
            rs.Tables("RESULT").Columns(i).ReadOnly = False
        Next

        rs_PGM00005C = rs.Copy()
        rs_PGM00005_ori = rs.Copy()
        If rs_PGM00005C.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("No Record Found", MsgBoxStyle.Information)
            Exit Sub
        Else
            unionRecord()
            Dim dv As DataView = rs_PGM00005.Tables("RESULT").DefaultView
            dv.Sort = "pod_ordno"
            rs_PGM00005.Tables.Remove("RESULT")
            rs_PGM00005.Tables.Add(dv.ToTable)

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            setStatus("UPDATE")
            display()
            countY()
            Me.Cursor = Windows.Forms.Cursors.Default
        End If
        recordStatus = False


        Dim dv2 As DataView = rs.Tables("RESULT").DefaultView
        If Not dv2.Count = 0 Then
            dv2.Sort = "prd_upddat desc"
            Dim drv As DataRowView = dv2(0)
            Me.StatusBar.Items("lblRight").Text = Format(drv.Item("prd_credat"), "MM/dd/yyyy") & " " & Format(drv.Item("prd_upddat"), "MM/dd/yyyy") & " " & drv.Item("prd_updusr")

            dv2.Sort = Nothing
        End If
    End Sub

    Private Sub mmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdClear.Click
        If checkFocus(Me) Then Exit Sub
        If recordStatus = True Then
            If MsgBox("Changes have been made." & Environment.NewLine & "Are you sure you want to clear without saving?", MsgBoxStyle.YesNo, "PGM00005 - Clear Data") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        setStatus("INIT")
        ' txtBJNo.Text = ""
        txtBJNo.Focus()
    End Sub

    Private Sub mmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdExit.Click
        If checkFocus(Me) Then Exit Sub
        If recordStatus = True Then
            If MsgBox("Changes have been made." & Environment.NewLine & "Are you sure you want to exit without saving?", MsgBoxStyle.YesNo, "PGM00005 - Exit Program") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        Me.Close()


    End Sub

    Private Sub unionRecord()
        If rs_PGM00005 Is Nothing Then
            rs_PGM00005 = rs_PGM00005C.Copy()
            recordStatus = True
        End If

        If Not rs_PGM00005C Is Nothing Then
            Dim dr() As DataRow
            Dim newRow As DataRow
            For i As Integer = 0 To rs_PGM00005C.Tables("RESULT").Rows.Count - 1
                dr = Nothing
                dr = rs_PGM00005.Tables("RESULT").Select("pod_ordno = '" & rs_PGM00005C.Tables("RESULT").Rows(i)("pod_ordno") & "' and pod_seq = " & rs_PGM00005C.Tables("RESULT").Rows(i)("pod_seq"))
                newRow = Nothing

                If dr.Length = 0 Then

                    Dim dr_req() As DataRow
                    dr_req = rs_PGM00005C.Tables("RESULT").Select("pod_ordno = '" & rs_PGM00005C.Tables("RESULT").Rows(i)("pod_ordno") & "' and pod_seq = " & rs_PGM00005C.Tables("RESULT").Rows(i)("pod_seq"))


                    For x As Integer = 0 To dr_req.Length - 1
                        newRow = rs_PGM00005.Tables("RESULT").NewRow
                        newRow("pod_ordno") = dr_req(x)("pod_ordno")
                        newRow("pod_seq") = dr_req(x)("pod_seq")
                        newRow("prh_scno") = dr_req(x)("prh_scno")
                        newRow("prh_tono") = dr_req(x)("prh_tono")
                        newRow("pod_itemno") = dr_req(x)("pod_itemno")
                        newRow("pod_assitm") = dr_req(x)("pod_assitm")
                        newRow("pod_packing") = dr_req(x)("pod_packing")
                        newRow("prd_sku") = dr_req(x)("prd_sku")
                        newRow("prd_cusitm") = dr_req(x)("prd_cusitm")
                        newRow("pod_pkgitm") = dr_req(x)("pod_pkgitm")
                        newRow("pod_pkgven") = dr_req(x)("pod_pkgven")
                        'newRow("pod_reqno") = rs_PGM00005C.Tables("RESULT").Rows(i)("pod_reqno")
                        'newRow("pod_reqseq") = rs_PGM00005C.Tables("RESULT").Rows(i)("pod_reqseq")
                        newRow("vbi_vensna") = dr_req(x)("vbi_vensna")
                        newRow("pjd_confrm") = "Y"
                        newRow("R_pod_ordno") = dr_req(x)("R_pod_ordno")
                        newRow("R_pod_ordseq") = dr_req(x)("R_pod_ordseq")
                        newRow("pjd_batseq") = ""
                        newRow("pjd_recsts") = "new"
                        newRow("vencde") = dr_req(x)("vencde")
                        newRow("prd_sctoqty") = dr_req(x)("prd_sctoqty")
                        newRow("prd_bonqty") = dr_req(x)("prd_bonqty")
                        newRow("pod_ttlordqty") = dr_req(x)("pod_ttlordqty")
                        newRow("pod_untprc") = dr_req(x)("pod_untprc")
                        newRow("pod_cate") = dr_req(x)("pod_cate")
                        newRow("prd_curcde") = dr_req(x)("prd_curcde")

                        newRow("prd_engdsc") = dr_req(x)("prd_engdsc")
                        newRow("prd_chndsc") = dr_req(x)("prd_chndsc")
                        newRow("prd_remark") = dr_req(x)("prd_remark")
                        newRow("prd_EInchL") = dr_req(x)("prd_EInchL")
                        newRow("prd_EInchW") = dr_req(x)("prd_EInchW")
                        newRow("prd_EInchH") = dr_req(x)("prd_EInchH")
                        newRow("prd_EcmL") = dr_req(x)("prd_EcmL")
                        newRow("prd_EcmW") = dr_req(x)("prd_EcmW")
                        newRow("prd_EcmH") = dr_req(x)("prd_EcmH")
                        newRow("prd_FInchL") = dr_req(x)("prd_FInchL")
                        newRow("prd_FInchW") = dr_req(x)("prd_FInchW")
                        newRow("prd_FInchH") = dr_req(x)("prd_FInchH")
                        newRow("prd_FcmL") = dr_req(x)("prd_FcmL")
                        newRow("prd_FcmW") = dr_req(x)("prd_FcmW")
                        newRow("prd_FcmH") = dr_req(x)("prd_FcmH")
                        newRow("prd_matral") = dr_req(x)("prd_matral")
                        newRow("prd_matDsc") = dr_req(x)("prd_matDsc")
                        newRow("prd_tiknes") = dr_req(x)("prd_tiknes")
                        newRow("prd_tikDsc") = dr_req(x)("prd_tikDsc")
                        newRow("prd_prtmtd") = dr_req(x)("prd_prtmtd")
                        newRow("prd_prtDsc") = dr_req(x)("prd_prtDsc")
                        newRow("prd_clrfot") = dr_req(x)("prd_clrfot")
                        newRow("prd_clrbck") = dr_req(x)("prd_clrbck")
                        newRow("prd_finish") = dr_req(x)("prd_finish")

                        rs_PGM00005.Tables("RESULT").Rows.Add(newRow)
                        rs_PGM00005.AcceptChanges()

                        'recordStatus = True
                    Next
                End If
            Next
        End If
    End Sub

    Private Sub display()

        dgBatchJob.RowHeadersWidth = 18
        dgBatchJob.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgBatchJob.ColumnHeadersHeight = 18
        dgBatchJob.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgBatchJob.AllowUserToResizeColumns = True
        dgBatchJob.AllowUserToResizeRows = False
        dgBatchJob.RowTemplate.Height = 18




        dgBatchJob.DataSource = rs_PGM00005.Tables("RESULT").DefaultView
        dgBatchJob.Columns(4).Frozen = True
        For i As Integer = 0 To rs_PGM00005.Tables("RESULT").Columns.Count - 1
            With dgBatchJob
                '.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                Select Case i
                    Case 0
                        .Columns(i).HeaderText = "Request No."
                        .Columns(i).Width = 70
                        .Columns(i).ReadOnly = True
                    Case 1
                        .Columns(i).HeaderText = "Seq"
                        .Columns(i).Width = 30
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 2
                        .Columns(i).HeaderText = "SC#"
                        .Columns(i).Width = 70
                        .Columns(i).ReadOnly = True

                    Case 3
                        .Columns(i).HeaderText = "TO#"
                        .Columns(i).Width = 70
                        .Columns(i).ReadOnly = True

                    Case 4
                        .Columns(i).HeaderText = "UCP Item No."
                        .Columns(i).Width = 100
                        .Columns(i).ReadOnly = True
                    Case 5
                        .Columns(i).HeaderText = "Ass Item No."
                        .Columns(i).Width = 90
                        .Columns(i).ReadOnly = True

                    Case 6
                        .Columns(i).HeaderText = "Packing & Terms"
                        .Columns(i).Width = 160
                        .Columns(i).ReadOnly = True

                    Case 7
                        .Columns(i).HeaderText = "SKU#"
                        .Columns(i).Width = 50
                        .Columns(i).ReadOnly = True
                    Case 8
                        .Columns(i).HeaderText = "Cust Item#"
                        .Columns(i).Width = 50
                        .Columns(i).ReadOnly = True

                    Case 9
                        .Columns(i).HeaderText = "Packing IM"
                        .Columns(i).Width = 80
                        .Columns(i).ReadOnly = True
                    Case 10
                        .Columns(i).HeaderText = "Vendor"
                        .Columns(i).Width = 50
                        .Columns(i).ReadOnly = True
                    Case 11
                        .Columns(i).HeaderText = "Vendor Name"
                        .Columns(i).Width = 80
                        .Columns(i).ReadOnly = True
                    Case 12
                        dgBatchJob_Confirm = i
                        .Columns(i).HeaderText = "Confirm"
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Columns(i).Width = 45
                        .Columns(i).ReadOnly = True

                    Case 13
                        .Columns(i).HeaderText = "Order No."
                        .Columns(i).Width = 70
                        .Columns(i).ReadOnly = True
                    Case 18
                        .Columns(i).HeaderText = "SC/TO Qty"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Case 19
                        .Columns(i).HeaderText = "Order Qty"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 20
                        .Columns(i).HeaderText = "Wastage Qty"
                        .Columns(i).Width = 50
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Case 21
                        .Columns(i).HeaderText = "Unit Price"
                        .Columns(i).Width = 70
                        .Columns(i).ReadOnly = True
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Case 23
                        .Columns(i).HeaderText = "Curr"
                        .Columns(i).Width = 40
                        .Columns(i).ReadOnly = True
                    Case Else
                        .Columns(i).Visible = False
                End Select
            End With
        Next

        dgBatchJob.ClearSelection()
    End Sub

    Private Sub countY()
        If rs_PGM00005 Is Nothing Then
            txtCount.Text = ""
        Else
            Dim dr() As DataRow = rs_PGM00005.Tables("RESULT").Select("pjd_confrm = 'Y'")
            txtCount.Text = dr.Length
        End If
    End Sub

    Private Function checkChangesMade(ByVal JobNo As String) As Boolean
        Dim dr_ori() As DataRow = rs_PGM00005_ori.Tables("RESULT").Select("pod_ordno = '" & JobNo & "'")
        Dim dr() As DataRow = rs_PGM00005.Tables("RESULT").Select("pod_ordno = '" & JobNo & "'")

        If dr_ori.Length = 0 Then
            Return False
        Else
            For i As Integer = 0 To rs_PGM00005.Tables("RESULT").Columns.Count - 1
                If dr_ori(0).Item(i) <> dr(0).Item(i) Then
                    Return True
                End If
            Next
            Return False
        End If
    End Function

    Private Function check_groupexist() As Boolean

        If rs_check.Tables("RESULT").Rows.Count = 0 Then
            Return True
            Exit Function
        End If

        Dim dr() As DataRow

        dr = rs_PGM00005.Tables("RESULT").Select("pjd_confrm = 'Y'")

        For i As Integer = 0 To dr.Length - 1
            For z As Integer = 0 To rs_check.Tables("RESULT").Rows.Count - 1
                If dr(i)("pod_ordno") = rs_check.Tables("RESULT").Rows(z).Item("pgd_reqno") And _
                    dr(i)("pod_seq") = rs_check.Tables("RESULT").Rows(z).Item("pgd_reqseq") Then
                    MsgBox("Action Fail , Request : " & dr(i)("pod_ordno") & " seq " & dr(i)("pod_seq") & " already grouped with other Order.")
                    Return False
                    Exit Function
                End If
            Next

        Next

        Return True




    End Function



    Private Sub exportPOReport()
        Dim exportType As String = ""
        If optPDF.Checked = True Then
            exportType = "PDF"
        ElseIf optExcel.Checked = True Then
            exportType = "XLS"
        Else
            exportType = "XLS"
        End If

        gspStr = "sp_list_POJBBDTL_SMK_2 '" & cboCoCde.Text & "','" & Trim(txtBJNo.Text) & "','" & exportType & "'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rs_Report = Nothing
        rtnLong = execute_SQLStatement(gspStr, rs_Report, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading PGM00005 #008 sp_list_POJBBDTL_SMK_2 : " & rtnStr)
            Exit Sub
        ElseIf rs_Report.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("No Record Found", MsgBoxStyle.Information, "PGM00005 - PO Report")
            Exit Sub
        End If

        If exportType = "PDF" Then
            Dim objRpt As New POR00006Rpt
            Dim frmReportView As New frmReport

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            objRpt.Database.Tables("por00006").SetDataSource(rs_Report.Tables("RESULT"))
            frmReportView.CrystalReportViewer.ReportSource = objRpt
            frmReportView.Show()
            Me.Cursor = Windows.Forms.Cursors.Default
        ElseIf exportType = "XLS" Then
            If rs_Report.Tables("RESULT").Rows.Count > 65535 Then
                MsgBox("Record count exceed Excel maximum allowable limit.", MsgBoxStyle.Exclamation, "PGM00005 - PO Report")
                Exit Sub
            End If

            Dim xlsApp As New Excel.ApplicationClass
            Dim xlsWB As Excel.Workbook = Nothing
            Dim xlsWS As Excel.Worksheet = Nothing

            Dim hdrRow As Integer = 1

            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            xlsApp = New Excel.Application
            xlsApp.Visible = False
            xlsApp.UserControl = True

            'Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

            xlsWB = xlsApp.Workbooks.Add()
            xlsWS = xlsWB.ActiveSheet

            With xlsApp
                'Header Setup
                .Rows(hdrRow).Font.Bold = True
                .Rows(hdrRow).Font.Size = 14
                .Range(.Cells(hdrRow, 1), .Cells(hdrRow, rs_Report.Tables("RESULT").Columns.Count)).MergeCells = True
                .Range(.Cells(hdrRow, 1), .Cells(hdrRow, rs_Report.Tables("RESULT").Columns.Count)).HorizontalAlignment = Excel.Constants.xlCenter
                .Range(.Cells(hdrRow, 1), .Cells(hdrRow, rs_Report.Tables("RESULT").Columns.Count)).Value = rs_Report.Tables("RESULT").Rows(0)("conam").ToString
                hdrRow += 1
                .Rows(hdrRow).Font.Bold = True
                .Rows(hdrRow).Font.Size = 12
                .Range(.Cells(hdrRow, 1), .Cells(hdrRow, rs_Report.Tables("RESULT").Columns.Count)).MergeCells = True
                .Range(.Cells(hdrRow, 1), .Cells(hdrRow, rs_Report.Tables("RESULT").Columns.Count)).HorizontalAlignment = Excel.Constants.xlCenter
                .Range(.Cells(hdrRow, 1), .Cells(hdrRow, rs_Report.Tables("RESULT").Columns.Count)).Value = "PRODUCTION ORDER REPORT"
                hdrRow += 1
                .Rows(hdrRow).Font.Size = 10
                .Cells(hdrRow, rs_Report.Tables("RESULT").Columns.Count - 3) = "Report ID :"
                .Range(.Cells(hdrRow, rs_Report.Tables("RESULT").Columns.Count - 2), .Cells(hdrRow, rs_Report.Tables("RESULT").Columns.Count - 2)).HorizontalAlignment = Excel.Constants.xlCenter
                .Cells(hdrRow, rs_Report.Tables("RESULT").Columns.Count - 2) = "POR00006"
                hdrRow += 1
                .Rows(hdrRow).Font.Size = 10
                .Cells(hdrRow, 1) = "Batch No :"
                .Cells(hdrRow, 2) = Trim(txtBJNo.Text)
                .Cells(hdrRow, rs_Report.Tables("RESULT").Columns.Count - 3) = "Date :"
                .Range(.Cells(hdrRow, rs_Report.Tables("RESULT").Columns.Count - 2), .Cells(hdrRow, rs_Report.Tables("RESULT").Columns.Count - 2)).HorizontalAlignment = Excel.Constants.xlCenter
                .Cells(hdrRow, rs_Report.Tables("RESULT").Columns.Count - 2) = Format(Date.Today, "MM/dd/yyyy").ToString
                hdrRow += 1
                .Rows(hdrRow).Font.Size = 10
                .Cells(hdrRow, rs_Report.Tables("RESULT").Columns.Count - 3) = "Time :"
                .Range(.Cells(hdrRow, rs_Report.Tables("RESULT").Columns.Count - 2), .Cells(hdrRow, rs_Report.Tables("RESULT").Columns.Count - 2)).HorizontalAlignment = Excel.Constants.xlCenter
                .Cells(hdrRow, rs_Report.Tables("RESULT").Columns.Count - 2) = Format(Date.Now, "HH:mm:ss").ToString
                hdrRow += 1
                .Rows(hdrRow).Font.Size = 10
                For i As Integer = 0 To rs_Report.Tables("RESULT").Columns.Count - 1
                    .Cells(hdrRow, i + 1) = rs_Report.Tables("RESULT").Columns(i).ColumnName
                Next
                .Range(.Cells(hdrRow, 1), .Cells(hdrRow, rs_Report.Tables("RESULT").Columns.Count)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

                'Populate Data
                Dim entry(rs_Report.Tables("RESULT").Columns.Count - 1) As String
                For i As Integer = 0 To rs_Report.Tables("RESULT").Rows.Count - 1
                    For j As Integer = 0 To rs_Report.Tables("RESULT").Columns.Count - 1
                        entry(j) = rs_Report.Tables("RESULT").Rows(i)(j).ToString
                    Next
                    .Range(.Cells(hdrRow + i + 1, 1), .Cells(hdrRow + i + 1, rs_Report.Tables("RESULT").Columns.Count)).Value = entry
                Next

                'Delete Company Name Column
                .Range(.Cells(hdrRow, 9), .Cells(hdrRow, 9)).EntireColumn.Delete()

                'Styling
                .Columns(1).ColumnWidth = 10
                .Columns(2).ColumnWidth = 25
                .Columns(3).ColumnWidth = 15
                .Columns(4).ColumnWidth = 12
                .Columns(5).ColumnWidth = 18
                .Columns(6).ColumnWidth = 15
                .Columns(7).ColumnWidth = 15
                .Columns(8).ColumnWidth = 10
                .Columns(9).ColumnWidth = 15
            End With

            xlsApp.Visible = True

            ' Release reference
            rs_Report = Nothing
            xlsWS = Nothing
            xlsWB = Nothing
            xlsApp = Nothing

            Me.Cursor = Windows.Forms.Cursors.Default
        End If
    End Sub



    Private Sub exportBJItemReport()
        gspStr = "sp_list_POJBBDTL_excel '" & cboCoCde.Text & "','" & Trim(txtBJNo.Text) & "'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rs_Report = Nothing
        rtnLong = execute_SQLStatement(gspStr, rs_Report, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading PGM00005 #007 sp_list_POJBBDTL_excel : " & rtnStr)
            Exit Sub
        End If

        If rs_Report.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("No Record Found", MsgBoxStyle.Information, "PGM00005 - Batch Job Item Report")
            Exit Sub
        ElseIf rs_Report.Tables("RESULT").Rows.Count > 65535 Then
            MsgBox("Record count exceed Excel maximum allowable limit.", MsgBoxStyle.Exclamation, "PGM00005 - Batch Job Item Report")
            Exit Sub
        End If

        Dim xlsApp As New Excel.ApplicationClass
        Dim xlsWB As Excel.Workbook = Nothing
        Dim xlsWS As Excel.Worksheet = Nothing

        Dim hdrRow As Integer = 1

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        xlsApp = New Excel.Application
        xlsApp.Visible = False
        xlsApp.UserControl = True

        'Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        xlsWB = xlsApp.Workbooks.Add()
        xlsWS = xlsWB.ActiveSheet

        With xlsApp
            'Header Setup
            .Rows(hdrRow).Font.Bold = True
            .Rows(hdrRow).Font.Size = 10
            For i As Integer = 2 To rs_Report.Tables("RESULT").Columns.Count - 1
                .Cells(hdrRow, i - 1) = rs_Report.Tables("RESULT").Columns(i).ColumnName
            Next
            .Range(.Cells(hdrRow, 1), .Cells(hdrRow, rs_Report.Tables("RESULT").Columns.Count - 2)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

            'Populate Data
            Dim entry(rs_Report.Tables("RESULT").Columns.Count - 2) As String
            For i As Integer = 0 To rs_Report.Tables("RESULT").Rows.Count - 1
                For j As Integer = 2 To rs_Report.Tables("RESULT").Columns.Count - 1
                    entry(j - 2) = rs_Report.Tables("RESULT").Rows(i)(j).ToString
                Next
                .Range(.Cells(hdrRow + i + 1, 1), .Cells(hdrRow + i + 1, rs_Report.Tables("RESULT").Columns.Count - 2)).Value = entry
            Next

            'Styling
            .Columns(1).ColumnWidth = 10
            .Columns(2).ColumnWidth = 15
            .Columns(3).ColumnWidth = 15
            .Columns(4).ColumnWidth = 50
            .Columns(5).ColumnWidth = 50
            .Columns(6).ColumnWidth = 15
            .Columns(7).ColumnWidth = 15
            .Columns(8).ColumnWidth = 10

        End With

        xlsApp.Visible = True

        ' Release reference
        rs_Report = Nothing
        xlsWS = Nothing
        xlsWB = Nothing
        xlsApp = Nothing

        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Function checkExistPO() As Boolean


        gspStr = "sp_select_PKINVDTL ''"
        rtnLong = execute_SQLStatement(gspStr, rs_PKINVHDR, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading checkExistPO sp_select_PKINVDTL :" & rtnStr)
            Exit Function
        End If




        '1. Checking All must Confirm
        Dim dr_confirm() As DataRow
        dr_confirm = rs_PGM00005.Tables("RESULT").Select("R_pod_ordno <> '' and pjd_confrm = 'N'")



        If dr_confirm.Length <> 0 Then
            MsgBox("Please make sure every request that generated order is confirmed(Y).")
            Return False
            Exit Function
        End If
        '1 end



        Dim dt_OrderList As DataTable
        Dim tmp_dv_PGM00005C As DataView

        tmp_dv_PGM00005C = rs_PGM00005.Tables("RESULT").DefaultView
        dt_OrderList = tmp_dv_PGM00005C.ToTable(True, "R_pod_ordno")




        Dim check As String

        For i As Integer = 0 To dt_OrderList.Rows.Count - 1
            If dt_OrderList.Rows(i).Item("R_pod_ordno").ToString <> "" Then
                '2. Checking All Request must be selected
                gspStr = "sp_select_PKREQDTL_04 '" & cboCoCde.Text & "','" & dt_OrderList.Rows(i).Item("R_pod_ordno") & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_Pkreqdtl, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    Cursor = Cursors.Default
                    MsgBox("Error on loading checkExistPO sp_select_PKREQDTL_04 :" & rtnStr)
                    Return False
                    Exit Function
                End If



                For z As Integer = 0 To rs_Pkreqdtl.Tables("RESULT").Rows.Count - 1

                    Dim dr_Find() As DataRow
                    dr_Find = rs_PGM00005.Tables("RESULT").Select("pod_ordno = '" & rs_Pkreqdtl.Tables("RESULT").Rows(z).Item("prd_reqno") & "' and " & _
                                                                       "pod_seq = " & rs_Pkreqdtl.Tables("RESULT").Rows(z).Item("prd_seq"))


                    If dr_Find.Length = 0 Then
                        MsgBox("Order " & rs_Pkreqdtl.Tables("RESULT").Rows(z).Item("prd_reqno") & _
                               " Seq " & rs_Pkreqdtl.Tables("RESULT").Rows(z).Item("prd_seq") & _
                               " Not Found in Grid. Action Fail.")
                        Return False
                        Exit Function
                    End If

                Next
                '2 end



                '3 Checking Order Header Status 
                gspStr = "sp_select_PKORDHDR '" & cboCoCde.Text & "','" & dt_OrderList.Rows(i).Item("R_pod_ordno") & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_PKORDHDR, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    Cursor = Cursors.Default
                    MsgBox("Error on loading cmdFind_Click sp_select_PKORDHDR :" & rtnStr)
                    Return False
                    Exit Function
                End If

                If rs_PKORDHDR.Tables("RESULT").Rows(0).Item("poh_status") = "APV" Then
                    MsgBox("Order " & dt_OrderList.Rows(i).Item("R_pod_ordno") & " already approved , action fail.")
                    Return False
                    Exit Function
                End If


                '3 end 



                '4 Checking Detail Status 
                gspStr = " sp_select_PKORDDTL '" & cboCoCde.Text & "','" & dt_OrderList.Rows(i).Item("R_pod_ordno") & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_PKORDDTL, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    Cursor = Cursors.Default
                    MsgBox("Error on loading cmdFind_Click sp_select_PKORDDTL :" & rtnStr)
                    Return False
                    Exit Function
                End If


                For c As Integer = 0 To rs_PKORDDTL.Tables("RESULT").Rows.Count - 1
                    If rs_PKORDDTL.Tables("RESULT").Rows(c).Item("pod_status") = "APV" Then
                        MsgBox("Order " & dt_OrderList.Rows(i).Item("R_pod_ordno") & " Seq : " & rs_PKORDDTL.Tables("RESULT").Rows(c).Item("pod_seq") & " already approved , action fail.")
                        Exit Function
                    End If
                    '4 end 

                    '5 Checking Stock reserive
                    If rs_PKORDDTL.Tables("RESULT").Rows(c).Item("pod_stkqty") > 0 Then

                        Dim dr() As DataRow
                        dr = rs_PKINVHDR.Tables("RESULT").Select("pih_pkgitm ='" & rs_PKORDDTL.Tables("RESULT").Rows(c).Item("pod_pkgitm") & "'")

                        If dr.Length = 0 Then

                        ElseIf dr.Length <> 0 Then

                            Dim sumqty As Integer = 0

                            For x As Integer = 0 To dr.Length - 1
                                sumqty = sumqty + dr(x)("pih_avlqty")
                            Next

                            Dim pastqty As Integer
                            Dim pastrow() As DataRow

                            pastrow = rs_PKINVHDR.Tables("RESULT").Select("pih_pkgitm ='" & rs_PKORDDTL.Tables("RESULT").Rows(c).Item("pod_pkgitm") & "' and pid_ordno = '" & dt_OrderList.Rows(i).Item("R_pod_ordno") & "' and pid_ordseq = " & rs_PKORDDTL.Tables("RESULT").Rows(c).Item("pod_seq"))
                            If pastrow.Length <> 0 Then
                                pastqty = pastrow(0)("pih_avlqty")
                            Else
                                pastqty = 0
                            End If

                            Dim currentqty As Integer = pastqty 'Convert.ToInt32(txtStkqty.Text)
                            '  Dim wasageqty As Integer = txtPkgWast.Text
                            ' Dim ordqty As Integer = txtPkgOrdQty.Text


                            If (sumqty - pastqty) < 0 Then

                                MsgBox("Order " & dt_OrderList.Rows(i).Item("R_pod_ordno") & " Seq : " & rs_PKORDDTL.Tables("RESULT").Rows(c).Item("pod_seq") & " Stock Qty already assigned to other Order , action fail.")
                                Exit Function

                            End If

                        End If
                    End If

                Next








            End If

        Next










        Return True


    End Function

    Private Function cancelOrder() As Boolean


        Dim dt_OrderList As DataTable
        Dim tmp_dv_PGM00005C As DataView
        If rbFilter_Req.Checked = True Then
            Exit Function
        End If


        tmp_dv_PGM00005C = rs_PGM00005C.Tables("RESULT").DefaultView
        dt_OrderList = tmp_dv_PGM00005C.ToTable(True, "R_pod_ordno")



        For i As Integer = 0 To dt_OrderList.Rows.Count - 1

            If dt_OrderList.Rows(i).Item("R_pod_ordno").ToString <> "" Then

                gspStr = "sp_select_PKORDHDR_cancel '" & cboCoCde.Text & "','" & dt_OrderList.Rows(i).Item("R_pod_ordno") & "','" & gsUsrID & "'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)

                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading cancelOrder sp_select_PKORDHDR_cancel :" & rtnStr)
                    Exit Function
                End If
            End If


        Next


    End Function

    Private Sub cmdOptApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOptApply.Click

        Dim filter As String
        Dim row_name As String

        If rdoPackItem.Checked = True Then
            filter = "pod_pkgitm"
            row_name = "Packaging Item"
        ElseIf rdoAssItm.Checked = True Then
            filter = "pod_assitm"
            row_name = "Assorted Item"
        ElseIf rdoSKU.Checked = True Then
            filter = "prd_sku"
            row_name = "SKU#"
        ElseIf rdoUCPItm.Checked = True Then
            filter = "pod_itemno"
            row_name = "UCP Item"
        End If

        Dim dt_OrderList As DataTable
        Dim tmp_dv_PGM0000Calculate As DataView

        tmp_dv_PGM0000Calculate = rs_PGM00005.Tables("RESULT").DefaultView
        If rdoPackItem.Checked = True Then
            dt_OrderList = tmp_dv_PGM0000Calculate.ToTable(True, "pod_pkgitm", "prd_curcde")
        ElseIf rdoAssItm.Checked = True Then
            dt_OrderList = tmp_dv_PGM0000Calculate.ToTable(True, "pod_assitm", "prd_curcde")
        ElseIf rdoSKU.Checked = True Then
            dt_OrderList = tmp_dv_PGM0000Calculate.ToTable(True, "prd_sku", "prd_curcde")
        ElseIf rdoUCPItm.Checked = True Then
            dt_OrderList = tmp_dv_PGM0000Calculate.ToTable(True, "pod_itemno", "prd_curcde")
        End If


        Dim ttlprice As Decimal
        Dim newRow As DataRow
        Dim dt_result As New DataTable
        dt_result.Columns.Add(row_name)
        ''dt_result.Columns.Add("Print Co.")
        dt_result.Columns.Add("Total Amount")
        dt_result.Columns.Add("Currency")

        Dim currentPrintCo As String

        For i As Integer = 0 To dt_OrderList.Rows.Count - 1

            If dt_OrderList.Rows(i).Item(filter).ToString <> "" Then

                For x As Integer = 0 To rs_PGM00005.Tables("RESULT").Rows.Count - 1
                    If rs_PGM00005.Tables("RESULT").Rows(x).Item(filter).ToString = dt_OrderList.Rows(i).Item(filter).ToString And _
                        rs_PGM00005.Tables("RESULT").Rows(x).Item("prd_curcde").ToString = dt_OrderList.Rows(i).Item("prd_curcde").ToString Then
                        ttlprice = ttlprice + (rs_PGM00005.Tables("RESULT").Rows(x).Item("pod_ttlordqty") * _
                        rs_PGM00005.Tables("RESULT").Rows(x).Item("pod_untprc"))
                    End If
                Next

                newRow = dt_result.NewRow
                newRow(row_name) = dt_OrderList.Rows(i).Item(filter).ToString
                ' newRow("Print Co.") = dt_OrderList.Rows(i).Item("vbi_vensna").ToString
                newRow("Total Amount") = ttlprice
                newRow("Currency") = dt_OrderList.Rows(i).Item("prd_curcde").ToString
                dt_result.Rows.Add(newRow)
                dt_result.AcceptChanges()
                ttlprice = 0
            End If


        Next


        dgCal.DataSource = dt_result.DefaultView

        For i As Integer = 0 To dt_result.Columns.Count - 1
            With dgCal
                '.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                Select Case i
                    Case 0
                        .Columns(i).HeaderText = row_name
                        .Columns(i).Width = 100
                        .Columns(i).ReadOnly = True
                    Case 1
                        .Columns(i).HeaderText = "Total Amount"
                        .Columns(i).Width = 100
                        .Columns(i).ReadOnly = True

                    Case 2
                        .Columns(i).HeaderText = "Currency"
                        .Columns(i).Width = 100
                        .Columns(i).ReadOnly = True

                End Select
            End With
        Next

        dgCal.ClearSelection()

        lblTitle.Text = "By " + row_name

        PanelOpt.Visible = False
        PanelResult.Visible = True
        PanelResult.BringToFront()
    End Sub

    Private Sub cmdRExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRExit.Click
        PanelResult.Visible = False
    End Sub

    Private Sub cmdCalculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCalculate.Click
        If rs_PGM00005C Is Nothing Then
            Exit Sub
        End If

        If rs_PGM00005C.Tables("RESULT").Rows.Count = 0 Then
            Exit Sub
        End If


        PanelOpt.Visible = True
        PanelOpt.BringToFront()
    End Sub

    Private Sub cmdOptExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOptExit.Click
        PanelOpt.Visible = False
    End Sub

    Private Function check_ZeroWast(ByVal rs_tmp_toscdetail As DataSet) As Boolean

        Dim strMsg As String = ""
        check_ZeroWast = True


        If rbFilter_Ord.Checked = True Then
            rs_tmp_toscdetail.Tables("RESULT").DefaultView.RowFilter = "R_pod_ordno <> ''"
        End If
        If rbFilter_Req.Checked = True Then
            rs_tmp_toscdetail.Tables("RESULT").DefaultView.RowFilter = "R_pod_ordno = ''"
        End If
        If rbFilter_All.Checked = True Then
            rs_tmp_toscdetail.Tables("RESULT").DefaultView.RowFilter = ""
        End If



        For i As Integer = 0 To rs_tmp_toscdetail.Tables("RESULT").DefaultView.Count - 1

            If rs_tmp_toscdetail.Tables("RESULT").DefaultView(i).Item("prd_bonqty") = 0 Then
                check_ZeroWast = False


                strMsg = strMsg & rs_tmp_toscdetail.Tables("RESULT").DefaultView(i).Item("pod_ordno") & "         " & rs_tmp_toscdetail.Tables("RESULT").DefaultView(i).Item("pod_seq") & "             " & rs_tmp_toscdetail.Tables("RESULT").DefaultView(i).Item("pod_pkgitm") & _
                "             " & rs_tmp_toscdetail.Tables("RESULT").DefaultView(i).Item("vbi_vensna") & "             " & rs_tmp_toscdetail.Tables("RESULT").DefaultView(i).Item("prd_bonqty") & vbCrLf '& "\" & dr_tmp_toscdetail(i).Item("tempitem") & _


            End If

            '"\" & dr_tmp_toscdetail(i).Item("venitem") & "\" & dr_tmp_toscdetail(i).Item("venitemno") 

        Next




        If strMsg <> "" Then
            strMsg = "The following reocord(s) has/have ZERO Request Wastage Qty :        " & vbCrLf & _
                     vbCrLf & "Order #         Seq #          Item #                  Vendor#                Wastage#" & vbCrLf & _
                    vbCrLf & strMsg & _
                    vbCrLf & vbCrLf & "" & vbCrLf & _
                    "Continue Order Generation?"

            If MsgBox(strMsg, vbYesNo + vbDefaultButton2 + vbCritical, "") = vbYes Then
                check_ZeroWast = True
            End If
        End If
    End Function

    Private Sub rbFilter_All_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbFilter_All.CheckedChanged
        If rs_PGM00005 Is Nothing Then
            Exit Sub
        End If

        If rbFilter_All.Checked = True Then
            rs_PGM00005.Tables("RESULT").DefaultView.RowFilter = ""
            display()
        End If
    End Sub

    Private Sub rbFilter_Req_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbFilter_Req.CheckedChanged
        If rs_PGM00005 Is Nothing Then
            Exit Sub
        End If

        If rbFilter_Req.Checked = True Then
            rs_PGM00005.Tables("RESULT").DefaultView.RowFilter = "R_pod_ordno = ''"
            display()
        End If
    End Sub

    Private Sub rbFilter_Ord_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbFilter_Ord.CheckedChanged
        If rs_PGM00005 Is Nothing Then
            Exit Sub
        End If

        If rbFilter_Ord.Checked = True Then
            rs_PGM00005.Tables("RESULT").DefaultView.RowFilter = "R_pod_ordno <> ''"
            display()
        End If
    End Sub


    Private Sub btnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        If dgBatchJob.DataSource Is Nothing Then

            Exit Sub
        End If
        If dgBatchJob.Columns("pjd_confrm").Index = sortingColumnNo Then 'Bug may occurs if the datagird is sorted by confirm order
            MsgBox("It cannot be use if the table is sorted by confirm order")
            Exit Sub

        End If


        Dim row_cnt As Integer
        Dim confirmChar As String = "Y"
        If rbNo.Checked Then
            confirmChar = "N"








        End If
        'Header Grid
        row_cnt = dgBatchJob.SelectedRows.Count
        If row_cnt = 0 Then
            MsgBox("No rows are selected")
            Exit Sub
        Else
            For i As Integer = 0 To row_cnt - 1
                Dim cur_row = dgBatchJob.SelectedRows(i)


                cur_row.Cells("pjd_confrm").Value = confirmChar

            Next
        End If
        recordStatus = True
        rs_PGM00005.AcceptChanges()
        dgBatchJob.ClearSelection()
        countY()
    End Sub
    Private Sub SetStatusBar(ByVal mode As String)

        If mode = "INIT" Then
            Me.StatusBar.Items("lblLeft").Text = "Init"
        ElseIf mode = "ADD" Then
            Me.StatusBar.Items("lblLeft").Text = "Add"
        ElseIf mode = "UPDATE" Then
            Me.StatusBar.Items("lblLeft").Text = "Updating"
        ElseIf mode = "Clear" Then
            Me.StatusBar.Items("lblLeft").Text = "Clear Screen"
        End If
    End Sub


#Region "Movable Panel"

    Dim ProgramPosition, CursorPoint As Point
    Dim movePanel As String
    Dim panelMoveTimer As Timer
    Private Sub RenewPanel(ByVal panel As Panel)
        ProgramPosition = panel.Location
        CursorPoint = Cursor.Position
    End Sub

    Private Sub SetPanelPosition(ByVal panel As Panel)
        Dim X As Integer = 0
        Dim Y As Integer = 0


        Dim Xlimit As Integer
        Dim Ylimit As Integer
        If Me.FormBorderStyle = FormBorderStyle.FixedDialog Then

            Xlimit = Me.Width - panel.Width - SystemInformation.HorizontalResizeBorderThickness
            Ylimit = Me.Height - panel.Height - SystemInformation.VerticalResizeBorderThickness - SystemInformation.MenuHeight - SystemInformation.VerticalFocusThickness * 3
        Else
            Xlimit = Me.Width - panel.Width - SystemInformation.HorizontalResizeBorderThickness * 2
            Ylimit = Me.Height - panel.Height - SystemInformation.VerticalResizeBorderThickness * 2 - SystemInformation.MenuHeight - SystemInformation.VerticalFocusThickness * 3

        End If

        If (ProgramPosition - CursorPoint + Cursor.Position).X > 0 And (ProgramPosition - CursorPoint + Cursor.Position).X < Xlimit Then
            X = (ProgramPosition - CursorPoint + Cursor.Position).X
        ElseIf (ProgramPosition - CursorPoint + Cursor.Position).X <= 0 Then
            X = 0
        Else
            X = Xlimit
        End If

        If (ProgramPosition - CursorPoint + Cursor.Position).Y > 0 And (ProgramPosition - CursorPoint + Cursor.Position).Y < Ylimit Then
            Y = (ProgramPosition - CursorPoint + Cursor.Position).Y
        ElseIf (ProgramPosition - CursorPoint + Cursor.Position).Y <= 0 Then
            Y = 0
        Else
            Y = Ylimit
        End If

        panel.Location = New Point(X, Y)
    End Sub

    Private Sub panelMoveTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim X As Integer = 0
        Dim Y As Integer = 0
        Select Case movePanel
            Case PanelOpt.Name
                SetPanelPosition(PanelOpt)
            Case PanelResult.Name
                SetPanelPosition(PanelResult)
        End Select


    End Sub

    Private Sub PanelOpt_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PanelOpt.MouseDown
        movePanel = PanelOpt.Name
        panelMoveTimer.Enabled = True
        panelMoveTimer.Start()
        RenewPanel(PanelOpt)
    End Sub

    Private Sub PanelOpt_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PanelOpt.MouseUp
        panelMoveTimer.Stop()
        RenewPanel(PanelOpt)
        movePanel = ""
    End Sub

    Private Sub PanelResult_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PanelResult.MouseDown
        movePanel = PanelResult.Name
        panelMoveTimer.Enabled = True
        panelMoveTimer.Start()
        RenewPanel(PanelResult)
    End Sub

    Private Sub PanelResult_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PanelResult.MouseUp
        panelMoveTimer.Stop()
        RenewPanel(PanelResult)
        movePanel = ""
    End Sub



#End Region

End Class
