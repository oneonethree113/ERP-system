Public Class frmQutUpdItm

    Public ma As QUM00001
    Dim drNewRow As DataRow
    Dim sFilter As String
    Dim dr() As DataRow
    Dim save_ok As Boolean
    Dim rs_IMXCHK As New DataSet
    Dim CellClickRow As Integer
    Dim CellClickCol As Integer
    Dim CellClickOldItem As String
    Dim CellClickQutSeq As Integer

    Dim objBSGate As Object
    Dim cus1no As String
    Dim cus2no As String
    Dim strCurCde2 As String
    Public Quotno As String
    Private rs_Result As New DataSet
    Private rs_List As New DataSet
    Dim btnUpd As Integer
    Dim btnNewItem As Integer
    Dim btnNewPck As Integer

    Dim rs_IMBASINF As New DataSet  ' for Item Basic
    Dim rs_IMCOLINF As New DataSet  ' for Item Color
    Dim rs_IMPCKINF As New DataSet  ' for Item Packing
    Dim rs_IMMATBKD As New DataSet  ' for Component Breakdown
    Dim rs_IMBOMASS As New DataSet  ' for Assorted Item
    Dim rs_IMPRCINF As New DataSet  ' for Pricing
    Dim rs_IMVENINF As New DataSet  ' for Vendor Item (IMVENINF, IMMMRPUP, VNBASINF)Public itmdsc As String
    Dim rs_CUITMSUM As New DataSet  ' for Customer Item History Summary
    Dim rs_SYTIESTR As New DataSet  ' for MOQ & MOA of Standard Tier
    Dim rs_SYCONFTR As New DataSet  ' for Conversion Factor
    Dim rs_CUMCOVEN As New DataSet  ' for Company Vendor Relation
    Dim rs_CUMCAMRK As New DataSet  ' for Cat Mark Up
    Dim rs_CUBASINF_P As New DataSet ' for Primary Customer
    Public rs_QUOTNDTL As New DataSet ' for retrieve Quotation Details information

    Dim rs_quotation_list_tbc As DataSet
    Dim rs_select_quotation_tbc As DataSet
    Dim rs_update_quotation_tbc As DataSet
    Dim rs_IMVENINF_tbc As DataSet

    Dim qutseq As Integer
    Dim stkqty_tmp As Integer
    Dim cusqty_tmp As Integer
    Dim smpqty_tmp As Integer

    Dim ITMTYP As String
    Dim itmsts As String
    Dim itmdsc As String
    Dim cosmth As String
    Dim hrmcde As String
    Dim img As String
    Dim coldsc As String
    Dim cuscol As String
    Dim cusitm As String
    Dim hstRef As String
    Dim cususd As Double
    Dim cuscad As Double
    Dim dept As String
    Dim dtyrat As Double

    Dim venno As String
    Dim subcde As String
    Dim vensts As String
    Dim fcurcde As String
    Dim ftyprc As Double
    Dim ftycst As Double

    Dim venitm As String

    Dim basprc As Double
    Dim cus1sp As Double
    Dim cus1dp As Double
    Dim cus2sp As Double
    Dim cus2dp As Double
    Dim moq As Integer
    Dim moa As Double
    Dim smpunt As String
    Dim smpprc As Double
    Dim pckitr As String

    Dim ORI_MOQ As String
    Dim ORI_MOA As String
    Dim ORI_MOFLAG As String

    Dim CusVenNo As String

    Dim fml As String

    Dim txtInrQtyM As String
    Dim txtMtrQtyM As String
    Dim txtCftM As String
    Dim txtUMM As String
    Dim txtConFtr As String
    Dim Period As Date

    Dim txtGrsMgn As String
    Dim txtCurCde1 As String

    Dim i As Integer
    Dim VENTYP As String
    Dim pckunt As String
    Dim inrqty As Integer
    Dim mtrqty As Integer

    Dim txtDtlPrcTrm As String
    Dim txtFtyPrcTrm As String

    Dim upccde As String
    Dim imrmk As String

    Dim bolRecordstatus As Boolean

    Private Sub frmQutUpdItm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ma.cmdUpdate.Enabled = True
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub frmQutUpdItm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'flgRecFound = False
        'lstNewPck.Visible = False
        'frmNewItm.Visible = False
        Quotno = Trim(ma.txtQutNo.Text)

        cus1no = ""
        cus2no = ""
        strCurCde2 = ""

        cus1no = Trim(Split(ma.cboCus1No.Text, "-")(0))
        If InStr(ma.cboCus2No.Text, "-") > 0 Then
            cus2no = Trim(Split(ma.cboCus2No.Text, "-")(0))
        End If
        strCurCde2 = ma.txtCurCde2.Text

        Cursor = Cursors.WaitCursor

        gsCompany = Trim(ma.cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_CUBASINF_PC '" & ma.cboCoCde.Text & "','" & gsUsrID & "','QU','Primary'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_P, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading frmQutUpdItm_Load sp_select_CUBASINF_PC :" & rtnStr)
            Exit Sub
        End If

        If Len(Quotno) > 0 Then
            Call showUpdItemQuot()
        End If

        bolRecordstatus = False
        Me.KeyPreview = True

        optUpdE.Enabled = False
        optUpdE.Visible = False
    End Sub

    Private Sub showUpdItemQuot()
        Dim rs As New DataSet
        Dim id As Long

        If Len(Quotno) = 0 Then
            Quotno = "X"
        End If

        Cursor = Cursors.WaitCursor

        'S = "㊣QUOTNDTL_upditm※L※" & Quotno & "※DTL㊣QUOTNDTL_upditm※L※" & Quotno & "※LST"
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gsCompany = Trim(ma.cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_list_QUOTNDTL_upditm '" & ma.cboCoCde.Text & "','" & Quotno & "','DTL'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading showUpdItemQuot sp_list_QUOTNDTL_upditm :" & rtnStr)
            Exit Sub
        End If

        If rs.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("No Record Found!")
            Cursor = Cursors.Default
            Exit Sub
        End If

        rs_Result = rs.Copy

        'Check Update Quotation Detail
        Dim temp_filter

        If Len(ma.item_update_list) = 0 Then
            temp_filter = "9999"
        Else
            temp_filter = Microsoft.VisualBasic.Left(ma.item_update_list, Len(ma.item_update_list) - 1)
        End If

        sFilter = "qud_qutseq not in  (" & temp_filter & ")"



        rs_Result.Tables("RESULT").DefaultView.RowFilter = sFilter

        If rs_Result.Tables("RESULT").DefaultView.Count = 0 Then
            ma.gb_frmQutUpdItm_hide = True
            MsgBox("No items to update!")

            Me.Hide()


            Exit Sub
        End If

        dgResult.DataSource = rs_Result.Tables("RESULT").DefaultView

        For index As Integer = 0 To rs_Result.Tables("RESULT").Columns.Count - 1
            rs_Result.Tables("RESULT").Columns(index).ReadOnly = False
        Next


        dgResult.DataSource = rs_Result.Tables("RESULT").DefaultView
        Call Display()

        txtFm.Text = "1"
        txtTo.Text = rs_Result.Tables("RESULT").DefaultView.Count




        Cursor = Cursors.Default
    End Sub

    Private Sub Display()
        Dim col As Integer

        With dgResult
            col = 0
            btnUpd = col
            .Columns(col).Width = 40
            .Columns(col).HeaderText = "UPD"
            '.Columns(col).Button = True
            .Columns(col).ReadOnly = True

            col = col + 1
            .Columns(col).Width = 40
            .Columns(col).HeaderText = "ID"
            .Columns(col).ReadOnly = True

            col = col + 1
            .Columns(col).Width = 0
            .Columns(col).HeaderText = "QUOT #"
            .Columns(col).ReadOnly = True
            .Columns(col).Visible = False

            col = col + 1
            .Columns(col).Width = 40
            .Columns(col).HeaderText = "Q.Seq"
            .Columns(col).ReadOnly = True

            col = col + 1
            .Columns(col).Width = 140
            .Columns(col).HeaderText = "Item #"
            .Columns(col).ReadOnly = True

            col = col + 1
            .Columns(col).Width = 100
            .Columns(col).HeaderText = "Color"
            .Columns(col).ReadOnly = True

            col = col + 1
            .Columns(col).Width = 200
            .Columns(col).HeaderText = "Packing"
            .Columns(col).ReadOnly = True

            col = col + 1
            .Columns(col).Width = 0
            .Columns(col).HeaderText = "conftr1"
            .Columns(col).ReadOnly = True
            .Columns(col).Visible = False

            col = col + 1
            .Columns(col).Width = 80
            .Columns(col).HeaderText = "Fty Tmp"
            '.Columns(col).CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(col).ReadOnly = True

            col = col + 1
            .Columns(col).Width = 50
            .Columns(col).HeaderText = "Curr"
            .Columns(col).ReadOnly = True

            col = col + 1
            .Columns(col).Width = 100
            .Columns(col).HeaderText = "Basic Price"
            .Columns(col).ReadOnly = True
            '.Columns(col).CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight

            'col = col + 1
            'btnNewItem = col
            '.Columns(col).Width = 170
            '.Columns(col).HeaderText = "New Item #"
            ''.Columns(col).Button = True
            '.Columns(col).ReadOnly = True

            'col = col + 1
            '.Columns(col).Width = 125
            '.Columns(col).HeaderText = "New Color"
            '.Columns(col).ReadOnly = True

            'col = col + 1
            'btnNewPck = col
            '.Columns(col).Width = 100
            '.Columns(col).HeaderText = "New Packing"
            '.Columns(col).ReadOnly = True

            'col = col + 1
            '.Columns(col).Width = 0
            '.Columns(col).HeaderText = "conftr2"
            '.Columns(col).ReadOnly = True
            '.Columns(col).Visible = False

            'col = col + 1
            '.Columns(col).Width = 80
            '.Columns(col).HeaderText = "Fty Tmp"
            ''.Columns(col).CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns(col).ReadOnly = True

            'col = col + 1
            '.Columns(col).Width = 100
            '.Columns(col).HeaderText = "New BP"
            ''.Columns(col).CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns(col).ReadOnly = True

            'col = col + 1
            '.Columns(col).Width = 50
            '.Columns(col).HeaderText = "Curr"
            '.Columns(col).ReadOnly = True

            'col = col + 1
            '.Columns(col).Width = 100
            '.Columns(col).HeaderText = "S. PckCst"
            '.Columns(col).ReadOnly = True

            col = col + 1
            .Columns(col).Width = 150
            .Columns(col).HeaderText = "Description"
            .Columns(col).ReadOnly = True

            col = col + 1
            .Columns(col).Width = 0
            .Columns(col).HeaderText = "Alias No."
            .Columns(col).ReadOnly = True
            .Columns(col).Visible = False

            col = col + 1
            .Columns(col).Width = 0
            .Columns(col).ReadOnly = True
            .Columns(col).Visible = False
            col = col + 1
            .Columns(col).Width = 0
            .Columns(col).ReadOnly = True
            .Columns(col).Visible = False
            col = col + 1
            .Columns(col).Width = 0
            .Columns(col).ReadOnly = True
            .Columns(col).Visible = False
            col = col + 1
            .Columns(col).Width = 0
            .Columns(col).ReadOnly = True
            .Columns(col).Visible = False
            col = col + 1
            .Columns(col).Width = 0
            .Columns(col).ReadOnly = True
            .Columns(col).Visible = False
            col = col + 1
            .Columns(col).Width = 0
            .Columns(col).ReadOnly = True
            .Columns(col).Visible = False
            col = col + 1
            .Columns(col).Width = 0
            .Columns(col).ReadOnly = True
            .Columns(col).Visible = False
            col = col + 1
            .Columns(col).Width = 0
            .Columns(col).ReadOnly = True
            .Columns(col).Visible = False

            col = col + 1
            .Columns(col).Width = 0
            .Columns(col).HeaderText = "Alias Color"
            .Columns(col).ReadOnly = True
            .Columns(col).Visible = False

            col = col + 1
            .Columns(col).Width = 0
            .Columns(col).HeaderText = "Remark"
            .Columns(col).ReadOnly = True
            .Columns(col).Visible = False
        End With
    End Sub

    Private Sub CalculatePrc(ByVal strItem As String, ByVal intSeq As Integer)
        Dim dblCstEmtPert As Double
        Dim dblCstEmtAmt As Double

        dblCstEmtPert = 0
        dblCstEmtAmt = 0

        'S = "㊣QUOTNDTL_Vendor_wCust2※S※" & rs_IMPCKINF("ipi_itmno") & "※" & _
        '                        rs_IMPCKINF("ipi_pckunt") & "※" & _
        '                        rs_IMPCKINF("ipi_inrqty") & "※" & _
        '                        rs_IMPCKINF("ipi_mtrqty") & "※" & _
        '                        rs_IMPCKINF("ipi_conftr") & "※" & _
        '                        cus1no & "※" & cus2no & "※" & gsUsrID
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gsCompany = Trim(ma.cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_QUOTNDTL_Vendor '" & ma.cboCoCde.Text & "','" & _
                                                strItem & "','" & _
                                                pckunt & "','" & inrqty & "','" & mtrqty & "','" & _
                                                cus1no & "','" & cus2no & "','" & gsUsrID & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_IMVENINF, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading CalculatePrc sp_select_QUOTNDTL_Vendor :" & rtnStr)
            Cursor = Cursors.Default
            Exit Sub
        End If

        If rs_IMVENINF.Tables("RESULT").Rows.Count > 0 And _
            rs_IMVENINF.Tables("RESULT").Rows(0)("imu_ftyprc") <> 0 And _
            rs_IMVENINF.Tables("RESULT").Rows(0)("imu_ftycst") <> 0 Then

            fcurcde = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_curcde")
            ftyprc = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_ftyprc")
            ftycst = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_ftycst")

            If rs_IMVENINF.Tables("RESULT").Rows(0)("imu_bcurcde").ToString <> strCurCde2 Then
                dr = ma.rs_CUBASINF_CR.Tables("RESULT").Select("ysi_def = 'Y'")

                If strCurCde2 = dr(0)("ysi_cde") Then
                    dr = ma.rs_CUBASINF_CR.Tables("RESULT").Select("ysi_cde = " & "'" & rs_IMVENINF.Tables("RESULT").Rows(0)("imu_bcurcde").ToString & "'")
                    basprc = Format(roundup(rs_IMVENINF.Tables("RESULT").Rows(0)("imu_basprc") * dr(0)("ysi_selrat")), "########0.0000")
                Else
                    dr = ma.rs_CUBASINF_CR.Tables("RESULT").Select("ysi_cde = " & "'" & strCurCde2 & "'")
                    basprc = Format(roundup(rs_IMVENINF.Tables("RESULT").Rows(0)("imu_basprc") / dr(0)("ysi_selrat")), "########0.0000")
                End If
            Else
                basprc = Format(rs_IMVENINF.Tables("RESULT").Rows(0)("imu_basprc"), "########0.0000")
            End If

            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_trantrm") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_trantrm")
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cus1no") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_cus1no")
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cus2no") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_cus2no")
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_effdat") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_effdat")
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_expdat") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_expdat")

            If rs_IMVENINF.Tables("RESULT").Rows(0)("imu_bcurcde").ToString <> strCurCde2 Then
                dr = ma.rs_CUBASINF_CR.Tables("RESULT").Select("ysi_def = 'Y'")

                If strCurCde2 = dr(0)("ysi_cde") Then
                    dr = ma.rs_CUBASINF_CR.Tables("RESULT").Select("ysi_cde = " & "'" & rs_IMVENINF.Tables("RESULT").Rows(0)("imu_bcurcde").ToString & "'")
                    'cus1sp = Format(roundup(Eval(rs_IMVENINF.Tables("RESULT").Rows(0)("imu_basprc"), fml) * dr(0)("ysi_selrat")), "###,###,##0.0000")
                    cus1sp = Format(round2(Eval(rs_IMVENINF.Tables("RESULT").Rows(0)("imu_basprc"), fml) * dr(0)("ysi_selrat")), "###,###,##0.0000")

                    If ma.rs_QUCSTEMT.Tables.Count > 0 Then
                        If ma.rs_QUCSTEMT.Tables("RESULT").DefaultView.Count > 0 Then
                            'ma.rs_QUCSTEMT.sort = " qce_ceseq asc"
                            For i = 0 To ma.rs_QUCSTEMT.Tables("RESULT").DefaultView.Count - 1
                                If ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(i)("mode").ToString <> "DEL" Then
                                    If CDec(IIf(IsDBNull(ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(i)("qce_percent")) = True, 0, ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(i)("qce_percent"))) <> 0 Then
                                        cus1sp = ((CDec(IIf(cus1sp = 0, 0, cus1sp)) / _
                                                (100 - CDec(IIf(IsDBNull(ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(i)("qce_percent")) = True, 0, ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(i)("qce_percent"))))) * 100) * _
                                                dr(0)("ysi_selrat")
                                    End If

                                    If CDec(IIf(IsDBNull(ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(i)("qce_amt")) = True, 0, ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(i)("qce_amt"))) <> 0 Then
                                        dblCstEmtAmt = CDec(IIf(IsDBNull(ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(i)("qce_amt")) = True, 0, ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(i)("qce_amt"))) * dr(0)("ysi_selrat")
                                        cus1sp = CStr(CDec(IIf(cus1sp = 0, 0, cus1sp)) + dblCstEmtAmt)
                                    End If
                                End If
                                dblCstEmtPert = 0
                                dblCstEmtAmt = 0
                            Next
                        End If
                    End If
                    'cus1sp = Format(roundup(cus1sp), "###,###,##0.0000")
                    cus1sp = Format(round2(cus1sp), "###,###,##0.0000")

                    If cus2no <> "" Then
                        If ma.optMU.Checked = True Then
                            'cus2sp = Format(roundup(CDec(IIf(cus1sp = 0, 0, cus1sp)) * (1 + txtGrsMgn / 100)), "########0.0000")
                            cus2sp = Format(round2(CDec(IIf(cus1sp = 0, 0, cus1sp)) * (1 + txtGrsMgn / 100)), "########0.0000")
                        Else
                            'cus2sp = Format(roundup(CDec(IIf(cus1sp = 0, 0, cus1sp)) / (1 - txtGrsMgn / 100)), "########0.0000")
                            cus2sp = Format(round2(CDec(IIf(cus1sp = 0, 0, cus1sp)) / (1 - txtGrsMgn / 100)), "########0.0000")
                        End If
                    End If
                    'cus1dp = Format(roundup(Eval(rs_IMVENINF.Tables("RESULT").Rows(0)("imu_basprc"), fml) * dr(0)("ysi_selrat")), "########0.0000")
                    cus1dp = Format(round2(Eval(rs_IMVENINF.Tables("RESULT").Rows(0)("imu_basprc"), fml) * dr(0)("ysi_selrat")), "########0.0000")

                    If cus2no <> "" Then
                        If ma.optMU.Checked = True Then
                            'cus2dp = Format(roundup(CDec(IIf(cus1dp = 0, 0, cus1dp)) * (1 + txtGrsMgn / 100)), "########0.0000")
                            cus2dp = Format(round2(CDec(IIf(cus1dp = 0, 0, cus1dp)) * (1 + txtGrsMgn / 100)), "########0.0000")
                        Else
                            'cus2dp = Format(roundup(CDec(IIf(cus1dp = 0, 0, cus1dp)) / (1 - txtGrsMgn / 100)), "########0.0000")
                            cus2dp = Format(round2(CDec(IIf(cus1dp = 0, 0, cus1dp)) / (1 - txtGrsMgn / 100)), "########0.0000")
                        End If
                    End If
                Else
                    dr = ma.rs_CUBASINF_CR.Tables("RESULT").Select("ysi_cde = " & "'" & strCurCde2 & "'")
                    'cus1sp = Format(roundup(Eval(rs_IMVENINF.Tables("RESULT").Rows(0)("imu_basprc"), fml) / dr(0)("ysi_selrat")), "###,###,##0.0000")
                    cus1sp = Format(round2(Eval(rs_IMVENINF.Tables("RESULT").Rows(0)("imu_basprc"), fml) / dr(0)("ysi_selrat")), "###,###,##0.0000")

                    If ma.rs_QUCSTEMT.Tables.Count > 0 Then
                        If ma.rs_QUCSTEMT.Tables("RESULT").DefaultView.Count > 0 Then
                            'ma.rs_QUCSTEMT.sort = "qce_ceseq asc"
                            For i = 0 To ma.rs_QUCSTEMT.Tables("RESULT").DefaultView.Count - 1
                                If ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(i)("mode").ToString <> "DEL" Then
                                    If CDec(IIf(IsDBNull(ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(i)("qce_percent")) = True, 0, ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(i)("qce_percent"))) <> 0 Then
                                        cus1sp = ((CDec(IIf(cus1sp = 0, 0, cus1sp)) / _
                                                (100 - CDec(IIf(IsDBNull(ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(i)("qce_percent")) = True, 0, ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(i)("qce_percent"))))) * 100) / _
                                                dr(0)("ysi_selrat")
                                    End If

                                    If CDec(IIf(IsDBNull(ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(i)("qce_amt")) = True, 0, ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(i)("qce_amt"))) <> 0 Then
                                        dblCstEmtAmt = CDec(IIf(IsDBNull(ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(i)("qce_amt")) = True, 0, ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(i)("qce_amt"))) / _
                                                        dr(0)("ysi_selrat")
                                        cus1sp = CStr(CDec(IIf(cus1sp = 0, 0, cus1sp)) + dblCstEmtAmt)
                                    End If
                                End If
                                dblCstEmtPert = 0
                                dblCstEmtAmt = 0
                            Next
                        End If
                    End If
                    'cus1sp = Format(roundup(cus1sp), "###,###,##0.0000")
                    cus1sp = Format(round2(cus1sp), "###,###,##0.0000")

                    If cus2no <> "" Then
                        If ma.optMU.Checked = True Then
                            'cus2sp = Format(roundup(CDec(IIf(cus1sp = 0, 0, cus1sp)) * (1 + txtGrsMgn / 100)), "########0.0000")
                            cus2sp = Format(round2(CDec(IIf(cus1sp = 0, 0, cus1sp)) * (1 + txtGrsMgn / 100)), "########0.0000")
                        Else
                            'cus2sp = Format(roundup(CDec(IIf(cus1sp = 0, 0, cus1sp)) / (1 - txtGrsMgn / 100)), "########0.0000")
                            cus2sp = Format(round2(CDec(IIf(cus1sp = 0, 0, cus1sp)) / (1 - txtGrsMgn / 100)), "########0.0000")
                        End If
                    End If
                    cus1dp = Format(CDec(cus1sp), "########0.0000")

                    If cus2no <> "" Then
                        If ma.optMU.Checked = True Then
                            'cus2dp = Format(roundup(CDec(IIf(cus1dp = 0, 0, cus1dp)) * (1 + txtGrsMgn / 100)), "########0.0000")
                            cus2dp = Format(round2(CDec(IIf(cus1dp = 0, 0, cus1dp)) * (1 + txtGrsMgn / 100)), "########0.0000")
                        Else
                            'cus2dp = Format(roundup(CDec(IIf(cus1dp = 0, 0, cus1dp)) / (1 - txtGrsMgn / 100)), "########0.0000")
                            cus2dp = Format(round2(CDec(IIf(cus1dp = 0, 0, cus1dp)) / (1 - txtGrsMgn / 100)), "########0.0000")
                        End If
                    End If
                End If
            Else
                'cus1sp = Format(roundup(Eval(rs_IMVENINF.Tables("RESULT").Rows(0)("imu_basprc"), fml)), "###,###,##0.0000")
                cus1sp = Format(round2(Eval(rs_IMVENINF.Tables("RESULT").Rows(0)("imu_basprc"), fml)), "###,###,##0.0000")

                If ma.rs_QUCSTEMT.Tables.Count > 0 Then
                    If ma.rs_QUCSTEMT.Tables("RESULT").DefaultView.Count > 0 Then
                        'ma.rs_QUCSTEMT.sort = " qce_ceseq asc"
                        For i = 0 To ma.rs_QUCSTEMT.Tables("RESULT").DefaultView.Count - 1
                            If ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(i)("mode").ToString <> "DEL" Then
                                If CDec(IIf(IsDBNull(ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(i)("qce_percent")) = True, 0, ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(i)("qce_percent"))) <> 0 Then
                                    cus1sp = (CDec(IIf(cus1sp = 0, 0, cus1sp)) / _
                                            (100 - CDec(IIf(IsDBNull(ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(i)("qce_percent")) = True, 0, ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(i)("qce_percent"))))) * 100
                                End If

                                If CDec(IIf(IsDBNull(ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(i)("qce_amt")) = True, 0, ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(i)("qce_amt"))) <> 0 Then
                                    dblCstEmtAmt = CDec(IIf(IsDBNull(ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(i)("qce_amt")) = True, 0, ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(i)("qce_amt")))
                                    cus1sp = CStr(CDec(IIf(cus1sp = 0, 0, cus1sp)) + dblCstEmtAmt)
                                End If
                            End If
                            dblCstEmtPert = 0
                            dblCstEmtAmt = 0
                        Next
                    End If
                End If
                'cus1sp = Format(roundup(cus1sp), "###,###,##0.0000")
                cus1sp = Format(round2(cus1sp), "###,###,##0.0000")

                If cus2no <> "" Then
                    If ma.optMU.Checked = True Then
                        'cus2sp = Format(roundup(CDec(IIf(cus1sp = 0, 0, cus1sp)) * (1 + txtGrsMgn / 100)), "########0.0000")
                        cus2sp = Format(round2(CDec(IIf(cus1sp = 0, 0, cus1sp)) * (1 + txtGrsMgn / 100)), "########0.0000")
                    Else
                        'cus2sp = Format(roundup(CDec(IIf(cus1sp = 0, 0, cus1sp)) / (1 - txtGrsMgn / 100)), "########0.0000")
                        cus2sp = Format(round2(CDec(IIf(cus1sp = 0, 0, cus1sp)) / (1 - txtGrsMgn / 100)), "########0.0000")
                    End If
                End If
                cus1dp = Format(CDec(cus1sp), "########0.0000")

                If cus2no <> "" Then
                    If ma.optMU.Checked = True Then
                        'cus2dp = Format(roundup(CDec(IIf(cus1dp = 0, 0, cus1dp)) * (1 + txtGrsMgn / 100)), "########0.0000")
                        cus2dp = Format(round2(CDec(IIf(cus1dp = 0, 0, cus1dp)) * (1 + txtGrsMgn / 100)), "########0.0000")
                    Else
                        'cus2dp = Format(roundup(CDec(IIf(cus1dp = 0, 0, cus1dp)) / (1 - txtGrsMgn / 100)), "########0.0000")
                        cus2dp = Format(round2(CDec(IIf(cus1dp = 0, 0, cus1dp)) / (1 - txtGrsMgn / 100)), "########0.0000")
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cmdApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApply.Click
        Dim opt As String
        Dim intFm As Long
        Dim intTo As Long

        If rs_Result.Tables.Count = 0 Then Exit Sub
        If rs_Result.Tables("RESULT").DefaultView.Count <= 0 Then Exit Sub

        If Val(txtFm.Text) = "0" Then
            MsgBox("The apply range cannot be 0")
            txtFm.SelectAll()
            Exit Sub
        End If

        If Val(txtTo.Text) > rs_Result.Tables("RESULT").DefaultView.Count Then
            MsgBox("The apply range cannot larger than the total number of records.")
            txtTo.SelectAll()
            Exit Sub
        End If

        If Val(txtFm.Text) > Val(txtTo.Text) Then
            MsgBox("The apply range is invalid.")
            txtFm.SelectAll()
            Exit Sub
        End If

        intFm = CLng(txtFm.Text)
        intTo = CLng(txtTo.Text)

        If intTo > rs_Result.Tables("RESULT").DefaultView.Count Then
            intTo = rs_Result.Tables("RESULT").DefaultView.Count
        End If

        opt = "N"

        'optUpdA
        'optUpdN

        If optUpdN.Checked = True Then
            opt = "N"
        ElseIf optUpdA.Checked = True Then
            opt = "Y"
        End If

        For index As Integer = intFm To intTo
            rs_Result.Tables("RESULT").DefaultView(index - 1)("Upd") = opt
        Next
        'For index As Integer = intFm To intTo
        '    rs_Result.Tables("RESULT").DefaultView(index - 1)("UPD") = opt
        'Next
        rs_Result.Tables("RESULT").AcceptChanges()
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim temp_PckCstAmt As String
        Dim temp_ItmCommAmt As String
        Dim temp_cboColCde_SelectedText As String
        Dim temp_cboPcking_SelectedText As String

        Dim tmp_count As Integer



        If MsgBox("Are you sure to update all the item(s)?", vbQuestion + vbYesNo, "Question") = vbYes Then

            For i As Integer = 0 To ma.rs_QUOTNDTL.Tables("RESULT").Columns.Count - 1
                ma.rs_QUOTNDTL.Tables("RESULT").Columns(i).ReadOnly = False
            Next i

            gspStr = "sp_select_QUOTNDTL '" & ma.cboCoCde.Text & "','" & ma.txtQutNo.Text & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_QUOTNDTL, rtnStr)
            gspStr = ""

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading Display_Header sp_select_QUOTNDTL 1 :" & rtnStr)
                Exit Sub
            End If


            If ma.rs_QUOTNDTL.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("Quotation in initial mode, please check.")
                Exit Sub
            End If


            'save current seq
            Call ma.fill_QUOTNDTL()
            If ma.rs_QUOTNDTL.Tables("RESULT").Rows(ma.sReadingIndexQ).Item("qud_creusr") = "~*ADD*~" Or rs_QUOTNDTL.Tables("RESULT").Rows(ma.sReadingIndexQ).Item("qud_creusr") = "~*NEW*~" Then
                ma.rs_QUOTNDTL.Tables("RESULT").Rows(ma.sReadingIndexQ).Item("qud_creusr") = "~*NEW*~"
            End If

            tmp_count = 0
            For index As Integer = 0 To rs_Result.Tables("RESULT").DefaultView.Count - 1
                If rs_Result.Tables("RESULT").DefaultView(index)("UPD").ToString = "Y" Then
                    tmp_count = tmp_count + 1
                End If
            Next



            If tmp_count = 0 Then
                MsgBox("No item selected!")
                Exit Sub
            End If


            For index As Integer = 0 To rs_Result.Tables("RESULT").DefaultView.Count - 1

                If rs_Result.Tables("RESULT").DefaultView(index)("UPD").ToString = "Y" Then

                    Cursor = Cursors.WaitCursor

                    ma.Is_Updating_item = True

                    ''check & update
                    'txtitmno_press
                    temp_PckCstAmt = ma.rs_QUOTNDTL.Tables("RESULT").Rows(index).Item("qpe_pkgper")
                    temp_ItmCommAmt = ma.rs_QUOTNDTL.Tables("RESULT").Rows(index).Item("qpe_icmper")

                    '''20130909 
                    ''' pack & color 
                    temp_cboColCde_SelectedText = ma.rs_QUOTNDTL.Tables("RESULT").Rows(index).Item("qud_colcde")

                    temp_cboPcking_SelectedText = ma.rs_QUOTNDTL.Tables("RESULT").Rows(index)("qud_untcde").ToString.Trim + " / " + _
            ma.rs_QUOTNDTL.Tables("RESULT").Rows(index)("qud_inrqty").ToString.Trim + " / " + _
            ma.rs_QUOTNDTL.Tables("RESULT").Rows(index)("qud_mtrqty").ToString.Trim + " / " + _
            ma.rs_QUOTNDTL.Tables("RESULT").Rows(index)("qud_cft").ToString.Trim + " / " + _
            ma.rs_QUOTNDTL.Tables("RESULT").Rows(index)("qud_cbm").ToString.Trim + " / " + _
            ma.rs_QUOTNDTL.Tables("RESULT").Rows(index)("qud_ftyprctrm").ToString.Trim + " / " + _
            ma.rs_QUOTNDTL.Tables("RESULT").Rows(index)("qud_prctrm").ToString.Trim + " / " + _
            ma.rs_QUOTNDTL.Tables("RESULT").Rows(index)("qud_trantrm").ToString.Trim


                    '''seqno & cur_index
                    'ma.txtSeq = ma.rs_QUOTNDTL.Tables("RESULT").Rows(index).Item("qud_qutseq")
                    ma.sReadingIndexQ = index

                    If ma.rs_QUOTNDTL.Tables("RESULT").Rows(ma.sReadingIndexQ).Item("qud_creusr") = "~*ADD*~" Or rs_QUOTNDTL.Tables("RESULT").Rows(ma.sReadingIndexQ).Item("qud_creusr") = "~*NEW*~" Then
                        ma.rs_QUOTNDTL.Tables("RESULT").Rows(ma.sReadingIndexQ).Item("qud_creusr") = "~*NEW*~"
                    End If

                    Dim qutseq As Integer
                    '    qutseq = ma.rs_QUOTNDTL.Tables("RESULT").Rows(index).Item("qud_qutseq")
                    qutseq = rs_Result.Tables("RESULT").DefaultView(index)("qud_qutseq")
                    Call ma.display_Detail(qutseq)

                    '''update each item

                    Call ma.txtItmNo_Press()

                    Call display_combo(temp_cboColCde_SelectedText, ma.cboColCde)
                    Call ma.cboColCdeClick()
                    Call display_combo(temp_cboPcking_SelectedText, ma.cboPcking)
                    Call ma.cboPckingClick()



                    '''20140102 UPdate sts, CIH & TO dollar
                    gspStr = "sp_list_quotation_tbc"
                    rtnLong = execute_SQLStatement(gspStr, rs_quotation_list_tbc, rtnStr)

                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading  sp_list_quotation_tbc :" & rtnStr)
                        Exit Sub
                    End If

                    For index1 As Integer = 0 To rs_quotation_list_tbc.Tables("RESULT").Rows.Count - 1

                        If rs_Result.Tables("RESULT").DefaultView(index)("qud_qutno").ToString = rs_quotation_list_tbc.Tables("RESULT").Rows(index1)("qud_qutno").ToString And _
                            rs_Result.Tables("RESULT").DefaultView(index)("qud_qutseq") = rs_quotation_list_tbc.Tables("RESULT").Rows(index1)("qud_qutseq") Then


                            gspStr = "sp_select_QUOTNDTL_tbc '" & _
                            rs_quotation_list_tbc.Tables("RESULT").Rows(index1)("qud_qutno").ToString & "'," & _
                            rs_quotation_list_tbc.Tables("RESULT").Rows(index1)("qud_qutseq")

                            rtnLong = execute_SQLStatement(gspStr, rs_select_quotation_tbc, rtnStr)

                            If rtnLong <> RC_SUCCESS Then
                                MsgBox("Error on loading  rs_select_quotation_tbc:" & rtnStr)
                                Exit Sub
                            End If

                            gspStr = "sp_select_QUOTNDTL_Vendor '" & "" & "','" & _
                                                                    rs_select_quotation_tbc.Tables("RESULT").DefaultView(0)("qud_itmno").ToString.Trim & "','" & _
                                                                    rs_select_quotation_tbc.Tables("RESULT").DefaultView(0)("qud_untcde").ToString.Trim & "','" & _
                                                                    rs_select_quotation_tbc.Tables("RESULT").DefaultView(0)("qud_inrqty").ToString.Trim & "','" & _
                                                                    rs_select_quotation_tbc.Tables("RESULT").DefaultView(0)("qud_mtrqty").ToString.Trim & "','" & _
                                                                    rs_select_quotation_tbc.Tables("RESULT").DefaultView(0)("qud_cus1no").ToString.Trim & "','" & _
                                                                    rs_select_quotation_tbc.Tables("RESULT").DefaultView(0)("qud_cus2no").ToString.Trim & "','" & _
                                                                    rs_select_quotation_tbc.Tables("RESULT").DefaultView(0)("qud_ftyprctrm").ToString.Trim & "','" & _
                                                                    rs_select_quotation_tbc.Tables("RESULT").DefaultView(0)("qud_prctrm").ToString.Trim & "','" & _
                                                                    rs_select_quotation_tbc.Tables("RESULT").DefaultView(0)("qud_trantrm").ToString.Trim & "','" & _
                                                                    "" & "'"
                            rtnLong = execute_SQLStatement(gspStr, rs_IMVENINF_tbc, rtnStr)
                            gspStr = ""
                            If rtnLong <> RC_SUCCESS Then
                                MsgBox("Error on loading CalculatePrc sp_select_QUOTNDTL_Vendor :" & rtnStr)
                                Exit Sub
                            End If

                            If rs_select_quotation_tbc.Tables("RESULT").Rows(0)("qud_ftyprc") <> rs_IMVENINF_tbc.Tables("RESULT").Rows(0)("imu_ftyprc") Then

                                '''set TBC => CMP
                                gspStr = "sp_update_quotndtl_tbc " & "'" & rs_select_quotation_tbc.Tables("RESULT").Rows(0)("qud_qutno").ToString & "'," & rs_select_quotation_tbc.Tables("RESULT").Rows(0)("qud_qutseq") & ",'" & _
                            gsUsrID & "'"

                                rtnLong = execute_SQLStatement(gspStr, rs_update_quotation_tbc, rtnStr)

                                If rtnLong <> RC_SUCCESS Then
                                    MsgBox("Error on loading  sp_update_quotndtl_tbc :" & rtnStr)
                                    Exit Sub
                                End If

                                '''update Tentative
                                ''' add 2 filde
                                gspStr = "sp_update_TOORDDTL_tbc '" & _
                                    "T" & rs_select_quotation_tbc.Tables("RESULT").Rows(0)("qud_qutno").ToString & "'," & _
                                    rs_select_quotation_tbc.Tables("RESULT").Rows(0)("qud_qutseq") & "," & _
                                    ma.rs_QUOTNDTL.Tables("RESULT").Rows(ma.sReadingIndexQ).Item("qud_ftycst") & "," & _
                                    ma.rs_QUOTNDTL.Tables("RESULT").Rows(ma.sReadingIndexQ).Item("qud_ftyprc") & "," & _
                                    ma.rs_QUOTNDTL.Tables("RESULT").Rows(ma.sReadingIndexQ).Item("qud_basprc") & "," & _
                                    ma.rs_QUOTNDTL.Tables("RESULT").Rows(ma.sReadingIndexQ).Item("qud_cus1sp") & ",'" & _
                                    gsUsrID & "'"

                                rtnLong = execute_SQLStatement(gspStr, rs_update_quotation_tbc, rtnStr)

                                If rtnLong <> RC_SUCCESS Then
                                    MsgBox("Error on loading  sp_update_TOORDDTL_tbc :" & rtnStr)
                                    Exit Sub
                                End If


                                gspStr = "sp_update_TOORDHDR_tbc '" & _
            "T" & rs_select_quotation_tbc.Tables("RESULT").Rows(0)("qud_qutno").ToString & "','" & _
            gsUsrID & "'"

                                rtnLong = execute_SQLStatement(gspStr, rs_update_quotation_tbc, rtnStr)

                                If rtnLong <> RC_SUCCESS Then
                                    MsgBox("Error on loading  sp_list_quotation_tbc :" & rtnStr)
                                    Exit Sub
                                End If



                            End If

                        End If ''' same qn same seq
                    Next
                    '''20140102 UPdate sts, CIH & TO dollar






                    '''for check duplicate packing
                    ma.Is_Updating_item = False

                    ma.rs_QUOTNDTL.Tables("RESULT").Rows(index).Item("qpe_pkgper") = temp_PckCstAmt
                    ma.rs_QUOTNDTL.Tables("RESULT").Rows(index).Item("qpe_icmper") = temp_ItmCommAmt




                    Call ma.calculate_gbPandelCstEmt(qutseq)



                    If ma.rs_QUOTNDTL.Tables("RESULT").Rows(index).Item("qud_creusr") = "~*ADD*~" Or ma.rs_QUOTNDTL.Tables("RESULT").Rows(index).Item("qud_creusr") = "~*NEW*~" Then
                        ma.rs_QUOTNDTL.Tables("RESULT").Rows(index).Item("qud_creusr") = "~*NEW*~"
                    Else

                        ma.rs_QUOTNDTL.Tables("RESULT").Rows(index).Item("qud_creusr") = "~*UPD*~"
                    End If

                    If ma.rs_QUOTNDTL.Tables("RESULT").Rows(index).Item("qpe_creusr") = "~*ADD*~" Or ma.rs_QUOTNDTL.Tables("RESULT").Rows(index).Item("qpe_creusr") = "~*NEW*~" Then
                        ma.rs_QUOTNDTL.Tables("RESULT").Rows(index).Item("qpe_creusr") = "~*NEW*~"
                    Else
                        ma.rs_QUOTNDTL.Tables("RESULT").Rows(index).Item("qpe_creusr") = "~*UPD*~"
                    End If




                    'obopacking
                    'save

                    ma.item_update_list = ma.item_update_list & qutseq.ToString & ","

                    ma.rs_QUOTNDTL.Tables("RESULT").Rows(index)("qud_apprve") = ""
                    ma.rs_QUOTNDTL.Tables("RESULT").Rows(index)("mode") = "UPD"

                End If

            Next

        End If

        Cursor = Cursors.Default

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ma.txtRvsDat.Text = Now.ToString("MM/dd/yyyy")

        MsgBox("Item(s) Processed. Please 'save' the quotation, before closing the quotation screen!")











        'Dim strItem As String
        'Dim strColor As String
        'Dim strPacking As String
        'Dim intSeq As Integer
        'Dim strAlsItmno As String
        'Dim strAlsColcde As String
        'Dim strFtyTmp As String
        'Dim strIsNewFtyTmp As String

        'Dim blnValid As Boolean

        'If rs_Result.Tables.Count = 0 Then Exit Sub
        'If rs_Result.Tables("RESULT").DefaultView.Count<= 0 Then Exit Sub

        'sFilter = "UPD<>'N'"
        'rs_Result.Tables("RESULT").DefaultView.RowFilter = sFilter

        'If rs_Result.Tables("RESULT").DefaultView.Count = 0 Then
        '    sFilter = ""
        '    rs_Result.Tables("RESULT").DefaultView.RowFilter = sFilter
        '    dgResult.DataSource = rs_Result.Tables("RESULT").DefaultView
        '    Call Display()
        '    MsgBox("All record are marked 'N'!" & vbCrLf & "To update a record, please mark other update indicator in the Column 'UPD'.")
        '    Exit Sub
        'End If

        'sFilter = ""
        'rs_Result.Tables("RESULT").DefaultView.RowFilter = sFilter
        '' Validate the update indicators
        'If rs_Result.Tables.Count > 0 Then
        '    If rs_Result.Tables("RESULT").DefaultView.Count> 0 Then
        '        For index As Integer = 0 To rs_Result.Tables("RESULT").DefaultView.Count- 1
        '            blnValid = True
        '            If rs_Result.Tables("RESULT").Rows(index)("UPD").ToString <> "N" Then
        '                Select Case rs_Result.Tables("RESULT").Rows(index)("UPD").ToString
        '                    Case "I"
        '                        If Trim(rs_Result.Tables("RESULT").Rows(index)("vw_remark").ToString) <> "FG#" Then
        '                            blnValid = False
        '                        End If

        '                        If blnValid = False Then
        '                            MsgBox(rs_Result.Tables("RESULT").Rows(index)("qud_itmno").ToString + " cannot be updated by applying I - Item# Only")
        '                        End If
        '                    Case "A"

        '                    Case "E"
        '                        If Trim(rs_Result.Tables("RESULT").Rows(index)("vw_ftytmpitm").ToString) = "Y" And _
        '                            Trim(rs_Result.Tables("RESULT").Rows(index)("qud_ftytmpitm").ToString) = "Y" Then
        '                            blnValid = False
        '                        End If

        '                        If blnValid = False Then
        '                            MsgBox(rs_Result.Tables("RESULT").Rows(index)("qud_itmno").ToString + " cannot be updated by applying E - Except Price")
        '                        End If
        '                    Case "C"

        '                End Select
        '            End If

        '            If blnValid = False Then
        '                rs_Result.Tables("RESULT").Rows(index)("UPD") = "N"
        '                sFilter = ""
        '                rs_Result.Tables("RESULT").DefaultView.RowFilter = sFilter
        '                dgResult.DataSource = rs_Result.Tables("RESULT").DefaultView
        '                Call Display()
        '                Exit Sub
        '            End If
        '        Next
        '    End If
        'End If

        'sFilter = ""
        'rs_Result.Tables("RESULT").DefaultView.RowFilter = sFilter
        'dgResult.DataSource = rs_Result.Tables("RESULT").DefaultView
        'Call Display()

        'blnValid = True

        'For index As Integer = 0 To rs_Result.Tables("RESULT").DefaultView.Count - 1
        '    If rs_Result.Tables("RESULT").DefaultView(index)("UPD").ToString <> "N" Then
        '        If rs_Result.Tables("RESULT").DefaultView(index)("UPD").ToString = "A" Or _
        '            rs_Result.Tables("RESULT").DefaultView(index)("UPD").ToString = "E" Or _
        '            rs_Result.Tables("RESULT").DefaultView(index)("UPD").ToString = "C" Then
        '            If Trim(rs_Result.Tables("RESULT").DefaultView(index)("vw_itmno").ToString) = "" Then
        '                rs_Result.Tables("RESULT").DefaultView(index)("vw_itmno") = rs_Result.Tables("RESULT").DefaultView(index)("qud_itmno")
        '                rs_Result.Tables("RESULT").DefaultView(index)("vw_colcde") = rs_Result.Tables("RESULT").DefaultView(index)("qud_colcde")
        '                rs_Result.Tables("RESULT").DefaultView(index)("vw_pckunt") = rs_Result.Tables("RESULT").DefaultView(index)("qud_untcde")
        '                strFtyTmp = ""
        '                strIsNewFtyTmp = rs_Result.Tables("RESULT").DefaultView(index)("qud_ftytmpitm")
        '            Else
        '                If rs_Result.Tables("RESULT").DefaultView(index)("vw_ftytmpitm").ToString <> "Y" Then
        '                    strFtyTmp = Trim(rs_Result.Tables("RESULT").DefaultView(index)("qud_itmno").ToString)
        '                    strIsNewFtyTmp = ""
        '                Else
        '                    strFtyTmp = ""
        '                    strIsNewFtyTmp = "Y"
        '                End If
        '            End If
        '        End If

        '        If Trim(rs_Result.Tables("RESULT").DefaultView(index)("vw_itmno").ToString) = "" Then
        '            MsgBox("Item Number missing!")
        '            dgResult.Rows(index).Cells(btnNewItem).Selected = True
        '            If dgResult.Visible And dgResult.Enabled Then dgResult.Focus()
        '            Exit Sub
        '        End If

        '        If Trim(rs_Result.Tables("RESULT").DefaultView(index)("vw_colcde").ToString) = "" Then
        '            MsgBox("Color Code missing!")
        '            dgResult.Rows(index).Cells(btnNewItem).Selected = True
        '            If dgResult.Visible And dgResult.Enabled Then dgResult.Focus()
        '            Exit Sub
        '        End If

        '        If Trim(rs_Result.Tables("RESULT").DefaultView(index)("vw_pckunt").ToString) = "" Then
        '            MsgBox("Packing missing!")
        '            dgResult.Rows(index).Cells(btnNewItem).Selected = True
        '            If dgResult.Visible And dgResult.Enabled Then dgResult.Focus()
        '            Exit Sub
        '        End If

        '        strItem = Trim(rs_Result.Tables("RESULT").DefaultView(index)("vw_itmno"))
        '        strColor = Trim(rs_Result.Tables("RESULT").DefaultView(index)("vw_colcde"))
        '        strPacking = Trim(rs_Result.Tables("RESULT").DefaultView(index)("vw_pckunt"))
        '        strAlsItmno = Trim(rs_Result.Tables("RESULT").DefaultView(index)("vw_alsItmno"))
        '        strAlsColcde = Trim(rs_Result.Tables("RESULT").DefaultView(index)("vw_alscolcde"))
        '        intSeq = rs_Result.Tables("RESULT").DefaultView(index)("qud_qutseq")

        '        'Check Color Packing Exist
        '        '-------------------------------
        '        save_ok = True

        '        Select Case rs_Result.Tables("RESULT").DefaultView(index)("UPD").ToString
        '            Case "I"
        '                Call updateIM(intSeq, strItem, strFtyTmp, strIsNewFtyTmp)
        '            Case "A"
        '                If Trim(rs_Result.Tables("RESULT").DefaultView(index)("vw_itmno").ToString) = "" Then
        '                    rs_Result.Tables("RESULT").DefaultView(index)("vw_itmno") = rs_Result.Tables("RESULT").DefaultView(index)("qud_itmno")
        '                    rs_Result.Tables("RESULT").DefaultView(index)("vw_colcde") = rs_Result.Tables("RESULT").DefaultView(index)("qud_colcde")
        '                    rs_Result.Tables("RESULT").DefaultView(index)("vw_pckunt") = rs_Result.Tables("RESULT").DefaultView(index)("qud_untcde")
        '                End If
        '                Call updateAll(intSeq, strItem, strColor, strPacking, strAlsItmno, strAlsColcde, strFtyTmp, strIsNewFtyTmp, rs_Result.Tables("RESULT").Rows(index)("UPD"))
        '            Case "E"
        '                Call updateAll(intSeq, strItem, strColor, strPacking, strAlsItmno, strAlsColcde, strFtyTmp, strIsNewFtyTmp, rs_Result.Tables("RESULT").Rows(index)("UPD"))
        '            Case "C"
        '                Call updateAll(intSeq, strItem, strColor, strPacking, strAlsItmno, strAlsColcde, strFtyTmp, strIsNewFtyTmp, rs_Result.Tables("RESULT").Rows(index)("UPD"))
        '        End Select

        '        If Not save_ok Then
        '            txtMsg.Text = "Sequence " & intSeq & " Update Failure!" & vbCrLf & txtMsg.Text
        '            txtMsg.Refresh()
        '            Exit For
        '        End If
        '        txtMsg.Text = "Sequence " & intSeq & " Updated!" & vbCrLf & txtMsg.Text
        '        txtMsg.Refresh()
        '        'DoEvents()
        '    End If
        'Next

        'If save_ok Then
        '    MsgBox("Update Complete!")
        '    ma.cmdSave.Enabled = True
        '    ma.cmdUpdate.Enabled = False
        '    Me.Close()
        'Else
        '    ma.cmdUpdate.Enabled = True
        'End If
    End Sub

    Private Sub updateAll(ByVal intSeq As Integer, ByVal strItem As String, ByVal strColor As String, ByVal strPacking As String, ByVal strAlsItmno As String, ByVal strAlsColcde As String, ByVal strFtyTmp As String, ByVal strIsNewFtyTmp As String, ByVal UPD As String)
        qutseq = 0
        stkqty_tmp = 0
        cusqty_tmp = 0
        smpqty_tmp = 0

        ITMTYP = ""
        itmsts = ""
        itmdsc = ""
        cosmth = ""
        hrmcde = ""
        img = ""
        coldsc = ""
        cuscol = ""
        cusitm = ""
        hstRef = ""
        cususd = 0
        cuscad = 0
        dept = ""
        dtyrat = 0

        venno = ""
        subcde = ""
        vensts = ""
        fcurcde = ""
        ftyprc = 0
        ftycst = 0

        venitm = ""

        basprc = 0
        cus1sp = 0
        cus1dp = 0
        cus2sp = 0
        cus2dp = 0
        moq = 0
        moa = 0
        smpunt = ""
        smpprc = 0
        pckitr = ""

        ORI_MOQ = ""
        ORI_MOA = ""
        ORI_MOFLAG = ""

        CusVenNo = ""

        fml = ""

        txtInrQtyM = ""
        txtMtrQtyM = ""
        txtCftM = ""
        txtUMM = ""

        txtConFtr = ""

        txtGrsMgn = ""
        txtCurCde1 = ""

        i = 0
        VENTYP = ""
        pckunt = ""
        inrqty = 0
        mtrqty = 0

        txtDtlPrcTrm = ""
        txtFtyPrcTrm = ""

        upccde = ""
        imrmk = ""

        Dim strTmp As String
        Dim strMOQUNTTYP As String = ""

        rs_IMBASINF.Tables.Clear()
        rs_IMCOLINF.Tables.Clear()
        rs_IMPCKINF.Tables.Clear()
        rs_IMMATBKD.Tables.Clear()
        rs_IMBOMASS.Tables.Clear()
        rs_IMPRCINF.Tables.Clear()
        rs_CUITMSUM.Tables.Clear()
        rs_SYTIESTR.Tables.Clear()
        rs_SYCONFTR.Tables.Clear()
        rs_CUMCOVEN.Tables.Clear()
        rs_CUMCAMRK.Tables.Clear()
        'rs_IMBASINF = Nothing
        'rs_IMCOLINF = Nothing
        'rs_IMPCKINF = Nothing
        'rs_IMMATBKD = Nothing
        'rs_IMBOMASS = Nothing
        'rs_CUITMSUM = Nothing
        'rs_SYTIESTR = Nothing
        'rs_SYCONFTR = Nothing
        'rs_CUMCOVEN = Nothing
        'rs_CUMCAMRK = Nothing

        Cursor = Cursors.WaitCursor
        sFilter = "qud_qutseq=" & intSeq
        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView.RowFilter = sFilter

        If ma.rs_QUOTNDTL.Tables("RESULT").DefaultView.Count = 0 Then
            Cursor = Cursors.Default
            save_ok = False
            MsgBox("Quotation Seq [" & intSeq & "] Invalid!")
            Exit Sub
        End If

        txtGrsMgn = IIf(IsDBNull(ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_grsMgn")), 0, ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_grsMgn"))
        txtCurCde1 = IIf(IsDBNull(ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_curcde")), 0, ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_curcde"))

        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        'Private Sub stritem_KeyPress(KeyAscii As Integer)
        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        strItem = UCase(strItem)

        'S = "㊣IMBASINF_Q※S※" & strItem
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gsCompany = Trim(ma.cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_IMBASINF_Q '" & ma.cboCoCde.Text & "','" & strItem & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_IMBASINF, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            save_ok = False
            MsgBox("Error on loading updateAll sp_select_IMBASINF_Q :" & rtnStr)
            Exit Sub
        End If

        If rs_IMBASINF.Tables("RESULT").Rows.Count = 0 Then
            Cursor = Cursors.Default
            save_ok = False
            MsgBox("Item " & strItem & " Not Found or Not In Complete or Incomplete Status!")
            Exit Sub
        Else
            strAlsItmno = rs_IMBASINF.Tables("RESULT").Rows(0)("ibi_alsitmno").ToString
            strAlsColcde = rs_IMBASINF.Tables("RESULT").Rows(0)("ibi_alscolcde").ToString

            If not_Valid_Item(strItem, cus1no, " ") Then
                Exit Sub
            End If

            '*** Phase 2 comment it
            'dr = ma.rs_CUMCAMRK.Tables("RESULT").Select("ccm_cusno = '" & cus1no & _
            '                             "' and ccm_ventyp = '" & rs_IMBASINF.Tables("RESULT").Rows(0)("vbi_ventyp").ToString & _
            '                             "' and ccm_cat = '" & rs_IMBASINF.Tables("RESULT").Rows(0)("ibi_catlvl3").ToString & "'")

            'If dr.Length > 0 Then
            '    fml = dr(0)("yfi_fml")
            'Else
            '    dr = ma.rs_CUMCAMRK.Tables("RESULT").Select("ccm_cusno = '" & cus1no & _
            '                             "' and ccm_ventyp = '" & rs_IMBASINF.Tables("RESULT").Rows(0)("vbi_ventyp").ToString & _
            '                             "' and ccm_cat = 'STANDARD'")
            '    If dr.Length > 0 Then
            '        fml = dr(0)("yfi_fml")
            '    Else
            '        Cursor = Cursors.Default
            '        save_ok = False
            '        MsgBox("Missing Customer Category Markup for the item " & strItem & vbCrLf & _
            '               "Please Enter Customer Customer Category Markup before Transaction Processing.")
            '        Exit Sub
            '    End If
            'End If

            'S = "㊣IMCOLINF※S※" & strItem & "㊣IMPCKINF_Q※S※" & strItem & "㊣IMMATBKD※S※" & strItem & "㊣IMBOMASS_Q※S※" & strItem
            'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

            Cursor = Cursors.WaitCursor

            gsCompany = Trim(ma.cboCoCde.Text)
            Call Update_gs_Value(gsCompany)

            gspStr = "sp_select_IMCOLINF '" & ma.cboCoCde.Text & "','" & strItem & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_IMCOLINF, rtnStr)
            gspStr = ""

            Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                Cursor = Cursors.Default
                save_ok = False
                MsgBox("Error on loading updateAll sp_select_IMCOLINF :" & rtnStr)
                Exit Sub
            End If

            Cursor = Cursors.WaitCursor

            gsCompany = Trim(ma.cboCoCde.Text)
            Call Update_gs_Value(gsCompany)

            gspStr = "sp_select_IMPCKINF_Q '" & ma.cboCoCde.Text & "','" & strItem & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_IMPCKINF, rtnStr)
            gspStr = ""

            Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                Cursor = Cursors.Default
                save_ok = False
                MsgBox("Error on loading updateAll sp_select_IMPCKINF_Q :" & rtnStr)
                Exit Sub
            End If

            Cursor = Cursors.WaitCursor

            gsCompany = Trim(ma.cboCoCde.Text)
            Call Update_gs_Value(gsCompany)

            gspStr = "sp_select_IMMATBKD '" & ma.cboCoCde.Text & "','" & strItem & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_IMMATBKD, rtnStr)
            gspStr = ""

            Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                Cursor = Cursors.Default
                save_ok = False
                MsgBox("Error on loading updateAll sp_select_IMMATBKD :" & rtnStr)
                Exit Sub
            End If

            Cursor = Cursors.WaitCursor

            gsCompany = Trim(ma.cboCoCde.Text)
            Call Update_gs_Value(gsCompany)

            gspStr = "sp_select_IMBOMASS_Q '" & ma.cboCoCde.Text & "','" & strItem & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_IMBOMASS, rtnStr)
            gspStr = ""

            Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                Cursor = Cursors.Default
                save_ok = False
                MsgBox("Error on loading updateAll sp_select_IMBOMASS_Q :" & rtnStr)
                Exit Sub
            End If

            Cursor = Cursors.WaitCursor

            gsCompany = Trim(ma.cboCoCde.Text)
            Call Update_gs_Value(gsCompany)

            gspStr = "sp_select_IMPRCINF_Q '" & ma.cboCoCde.Text & "','" & strItem & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_IMPRCINF, rtnStr)
            gspStr = ""

            Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                Cursor = Cursors.Default
                save_ok = False
                MsgBox("Error on loading updateAll sp_select_IMBOMASS_Q :" & rtnStr)
                Exit Sub
            End If

            ITMTYP = rs_IMBASINF.Tables("RESULT").Rows(0)("ibi_typ")
            itmdsc = rs_IMBASINF.Tables("RESULT").Rows(0)("ibi_engdsc")
            itmsts = rs_IMBASINF.Tables("RESULT").Rows(0)("ibi_itmsts")
            imrmk = rs_IMBASINF.Tables("RESULT").Rows(0)("ibi_rmk")

            cosmth = IIf(IsDBNull(rs_IMBASINF.Tables("RESULT").Rows(0)("ibi_cosmth").ToString + " - " + _
                              rs_IMBASINF.Tables("RESULT").Rows(0)("ysi_dsc").ToString) = True, "", _
                              rs_IMBASINF.Tables("RESULT").Rows(0)("ibi_cosmth").ToString + " - " + _
                              rs_IMBASINF.Tables("RESULT").Rows(0)("ysi_dsc").ToString)

            venno = IIf(IsDBNull(rs_IMBASINF.Tables("RESULT").Rows(0)("ivi_venno")) = True, "", rs_IMBASINF.Tables("RESULT").Rows(0)("ivi_venno"))
            subcde = rs_IMBASINF.Tables("RESULT").Rows(0)("ivi_subcde")
            venitm = rs_IMBASINF.Tables("RESULT").Rows(0)("ivi_venitm")
            CusVenNo = IIf(IsDBNull(rs_IMBASINF.Tables("RESULT").Rows(0)("ibi_cusven")) = True, "", rs_IMBASINF.Tables("RESULT").Rows(0)("ibi_cusven"))

            hrmcde = rs_IMBASINF.Tables("RESULT").Rows(0)("ibi_hamusa")

            If hrmcde <> "" Then
                dr = ma.rs_SYHRMCDE.Tables("RESULT").Select("yhc_hrmcde = " & "'" & hrmcde & "'")

                If dr.Length > 0 Then
                    hrmcde = dr(0)("yhc_hrmcde").ToString + " - " + dr(0)("yhc_hrmdsc").ToString + _
                                        IIf(dr(0)("yhc_tarzon").ToString = "U", " (HSTU # for USA)", " (Tariff # for Europe)")
                    dtyrat = dr(0)("yhc_dtyrat")
                End If
            End If

            img = "N"
        End If

        '*******************************Check Price Valid for the Company******************************
        Dim sRealCus1no As String
        Dim sRealCus2no As String
        Dim GotActivePrice As Boolean
        Dim GotValidPrice As Boolean

        GotActivePrice = False
        GotValidPrice = False

        If ma.cboCus1No.Text = "" Then
            sRealCus1no = ""
        Else
            sRealCus1no = Microsoft.VisualBasic.Left(ma.cboCus1No.Text, InStr(ma.cboCus1No.Text, " - ") - 1)
        End If

        If ma.cboCus2No.Text = "" Then
            sRealCus2no = ""
        Else
            sRealCus2no = Microsoft.VisualBasic.Left(ma.cboCus2No.Text, InStr(ma.cboCus2No.Text, " - ") - 1)
        End If

        If rs_IMPRCINF.Tables("RESULT").Rows.Count > 0 Then
            For index As Integer = 0 To rs_IMPRCINF.Tables("RESULT").Rows.Count - 1
                If rs_IMPRCINF.Tables("RESULT").Rows(index)("imu_status").ToString = "ACT" Then
                    GotActivePrice = True
                    If rs_IMPRCINF.Tables("RESULT").Rows(index)("imu_cus1no").ToString = sRealCus1no And _
                        rs_IMPRCINF.Tables("RESULT").Rows(index)("imu_cus2no").ToString = sRealCus2no Then
                        GotValidPrice = True
                        Exit For
                    End If
                    If rs_IMPRCINF.Tables("RESULT").Rows(index)("imu_cus1no").ToString = sRealCus1no And _
                        rs_IMPRCINF.Tables("RESULT").Rows(index)("imu_cus2no").ToString = "" Then
                        GotValidPrice = True
                        Exit For
                    End If
                    ' Check if is Customer Group
                    If rs_IMPRCINF.Tables("RESULT").Rows(index)("imu_cus1no").ToString.Length <> 5 Then
                        dr = rs_CUBASINF_P.Tables("RESULT").Select("cbi_cusno = " & "'" & sRealCus1no & "'")

                        If rs_IMBASINF.Tables("RESULT").Rows(0)("vbi_ventyp").ToString = "E" Then
                            If rs_IMPRCINF.Tables("RESULT").Rows(index)("imu_cus1no") = dr(0)("cbi_cugrptyp_ext") Then
                                GotValidPrice = True
                            End If
                        Else
                            If rs_IMPRCINF.Tables("RESULT").Rows(index)("imu_cus1no") = dr(0)("cbi_cugrptyp_int") Then
                                GotValidPrice = True
                            End If
                        End If
                    End If
                    If rs_IMPRCINF.Tables("RESULT").Rows(index)("imu_cus1no").ToString = "" And _
                        rs_IMPRCINF.Tables("RESULT").Rows(index)("imu_cus2no").ToString = "" Then
                        GotValidPrice = True
                        Exit For
                    End If
                End If
            Next
        Else
            MsgBox("No valid price of this item.")
            save_ok = False
            Exit Sub
        End If

        If GotActivePrice = False Then
            MsgBox("No active price of this item.")
            save_ok = False
            Exit Sub
        Else
            If GotValidPrice = False Then
                If sRealCus2no = "" Then
                    MsgBox("No valid price of this item for customer: " & sRealCus1no)
                    save_ok = False
                    Exit Sub
                Else
                    MsgBox("No valid price of this item for customer: " & sRealCus1no & ", " & sRealCus2no)
                    save_ok = False
                    Exit Sub
                End If
            End If
        End If

        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        'Private Sub cboColCdeM_Click()
        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        sFilter = "icf_colcde='" & strColor & "'"
        rs_IMCOLINF.Tables("RESULT").DefaultView.RowFilter = sFilter

        If rs_IMCOLINF.Tables("RESULT").DefaultView.Count = 0 Then
            save_ok = False
            MsgBox("Item [" & strItem & "] color code [" & strColor & "] not found")
            Exit Sub
        Else
            coldsc = rs_IMCOLINF.Tables("RESULT").DefaultView.Item(0)("icf_coldsc")
            upccde = rs_IMCOLINF.Tables("RESULT").DefaultView.Item(0)("icf_ucpcde")
        End If

        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        'Private Sub cboPckingM_Click()
        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        txtInrQtyM = "0"
        txtMtrQtyM = "0"
        txtConFtr = "1"
        txtCftM = "0"

        If Len(strPacking) > 0 Then
            pckunt = Trim(Split(strPacking, "/")(0))
            inrqty = CLng(Trim(Split(strPacking, "/")(1)))
            mtrqty = CLng(Trim(Split(strPacking, "/")(2)))

            sFilter = "ipi_pckunt = '" & pckunt & "' and ipi_inrqty=" & inrqty & " and ipi_mtrqty=" & mtrqty
            rs_IMPCKINF.Tables("RESULT").DefaultView.RowFilter = sFilter

            txtInrQtyM = rs_IMPCKINF.Tables("RESULT").DefaultView(0)("ipi_inrqty")
            txtMtrQtyM = rs_IMPCKINF.Tables("RESULT").DefaultView(0)("ipi_mtrqty")
            txtCftM = rs_IMPCKINF.Tables("RESULT").DefaultView(0)("ipi_cft")
            txtUMM = rs_IMPCKINF.Tables("RESULT").DefaultView(0)("ipi_pckunt")
            pckitr = rs_IMPCKINF.Tables("RESULT").DefaultView(0)("ipi_pckitr")
            txtConFtr = rs_IMPCKINF.Tables("RESULT").DefaultView(0)("ipi_conftr")
            Period = rs_IMPCKINF.Tables("RESULT").DefaultView(0)("ipi_qutdat")

            If UPD <> "E" And UPD <> "C" Then
                If ma.rs_QUCSTEMT.Tables.Count > 0 Then
                    sFilter = "qce_qutseq = " & intSeq
                    ma.rs_QUCSTEMT.Tables("RESULT").DefaultView.RowFilter = sFilter

                    If ma.rs_QUCSTEMT.Tables("RESULT").DefaultView.Count > 0 Then
                        For index As Integer = 0 To ma.rs_QUCSTEMT.Tables("RESULT").DefaultView.Count - 1
                            If ma.rs_QUCSTEMT.Tables("RESULT").DefaultView.Item(index)("mode").ToString = "NEW" Then
                                ma.rs_QUCSTEMT.Tables("RESULT").DefaultView.Item(index).Delete()
                            Else
                                ma.rs_QUCSTEMT.Tables("RESULT").DefaultView.Item(index)("mode") = "DEL"
                            End If
                        Next
                        ma.rs_QUCSTEMT.Tables("RESULT").AcceptChanges()
                    End If
                End If
            End If

            sFilter = "qce_qutseq = " & intSeq & " and mode <> 'DEL'"
            ma.rs_QUCSTEMT.Tables("RESULT").DefaultView.RowFilter = sFilter

            Call CalculatePrc(strItem, intSeq)

            sFilter = ""
            ma.rs_QUCSTEMT.Tables("RESULT").DefaultView.RowFilter = sFilter

            strMOQUNTTYP = ""

            'S = "㊣CUBASINF_Q※S※" & txtUMM & "※Conversion"
            'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

            Cursor = Cursors.WaitCursor

            gsCompany = Trim(ma.cboCoCde.Text)
            Call Update_gs_Value(gsCompany)

            gspStr = "sp_select_CUBASINF_Q '" & ma.cboCoCde.Text & "','" & txtUMM & "','Conversion'"
            rtnLong = execute_SQLStatement(gspStr, rs_SYCONFTR, rtnStr)
            gspStr = ""

            Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                Cursor = Cursors.Default
                save_ok = False
                MsgBox("Error on loading updateAll sp_select_CUBASINF_Q :" & rtnStr)
                Exit Sub
            End If

            If rs_SYCONFTR.Tables("RESULT").Rows.Count = 0 Then
                smpunt = txtUMM
                smpprc = cus1dp
            Else
                smpunt = "PC"
                'smpprc = Format(roundup(cus1dp / rs_SYCONFTR.Tables("RESULT").Rows(0)("ycf_value")), "########0.0000")
                smpprc = Format(round2(cus1dp / rs_SYCONFTR.Tables("RESULT").Rows(0)("ycf_value")), "########0.0000")
            End If

            'S = "㊣ItemMaster_moq_moa_qu_wunttyp※S※" & cus1no & _
            '    "※" & cus2no & "※" & strItem & _
            '    "※" & txtUMM & "※" & txtConFtr & "※" & txtInrQtyM & "※" & txtMtrQtyM & _
            '    "※" & strColor & "※" & cus1sp & "※" & strCurCde2
            'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

            Cursor = Cursors.WaitCursor

            gsCompany = Trim(ma.cboCoCde.Text)
            Call Update_gs_Value(gsCompany)

            gspStr = "sp_select_ItemMaster_moq_moa_qu_wunttyp '" & ma.cboCoCde.Text & "','" & _
                                            cus1no & "','" & _
                                            cus2no & "','" & _
                                            strItem & "','" & _
                                            txtUMM & "','" & _
                                            txtConFtr & "','" & _
                                            txtInrQtyM & "','" & _
                                            txtMtrQtyM & "','" & _
                                            strColor & "','" & _
                                            cus1sp & "','" & _
                                            strCurCde2 & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_SYTIESTR, rtnStr)
            gspStr = ""

            Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                Cursor = Cursors.Default
                save_ok = False
                MsgBox("Error on loading updateAll sp_select_ItemMaster_moq_moa_qu_wunttyp :" & rtnStr)
                Exit Sub
            End If

            ORI_MOFLAG = ""
            ORI_MOQ = ""
            ORI_MOA = ""

            If rs_SYTIESTR.Tables("RESULT").Rows.Count = 0 Then
                save_ok = False
                MsgBox("No MOQ & MOA found of this Item [" & strItem & "]")
                txtInrQtyM = ""
                txtMtrQtyM = ""
                txtCftM = ""
                moq = ""
                moa = ""
                strMOQUNTTYP = ""
                Exit Sub
            Else
                ORI_MOFLAG = rs_SYTIESTR.Tables("RESULT").Rows(0)("MOFLAG")
                ORI_MOQ = CInt(rs_SYTIESTR.Tables("RESULT").Rows(0)("MOQ"))

                strMOQUNTTYP = "CTN"

                If txtCurCde1 <> rs_SYTIESTR.Tables("RESULT").Rows(0)("CURCDE").ToString And _
                    CDec(rs_SYTIESTR.Tables("RESULT").Rows(0)("MOA")) > 0 Then
                    dr = ma.rs_CUBASINF_CR.Tables("RESULT").Select("ysi_def = 'Y'")

                    If txtCurCde1 = dr(0)("ysi_cde") Then
                        dr = ma.rs_CUBASINF_CR.Tables("RESULT").Select("ysi_cde = " + "'" + rs_SYTIESTR.Tables("RESULT").Rows(0)("CURCDE").ToString + "'")
                        ORI_MOA = roundup(rs_SYTIESTR.Tables("RESULT").Rows(0)("MOA") * dr(0)("ysi_selrat"))
                    Else
                        dr = ma.rs_CUBASINF_CR.Tables("RESULT").Select("ysi_cde = " + "'" + txtCurCde1 + "'")
                        ORI_MOA = roundup(rs_SYTIESTR.Tables("RESULT").Rows(0)("MOA") / dr(0)("ysi_selrat"))
                    End If
                Else
                    ORI_MOA = rs_SYTIESTR.Tables("RESULT").Rows(0)("MOA")
                End If
            End If
            If ORI_MOFLAG = "Q" Then
                ORI_MOA = "0"
            End If
        End If

        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cusstyno") = GetCusSty(strItem, cus1no)

        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        'Private Sub cmdOK_Click()
        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

        '-----------------------------------------------
        'Check Fields Before Update To Quotation Detail
        '-----------------------------------------------
        '-----------------------------------------------
        'S = "㊣CUITMSUM_Q※S※" & cus1no & "※" & cus2no & "※" & _
        'strItem & "※" & strColor & "※" & txtUMM & "※" & IIf(Trim(txtInrQtyM) = "", "0", txtInrQtyM) & "※" & _
        'IIf(Trim(txtMtrQtyM) = "", "0", txtMtrQtyM) & "※" & IIf(Trim(txtConFtr) = "", "1", txtConFtr) & "※" & gsUsrID
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gsCompany = Trim(ma.cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_CUITMSUM_Q '" & ma.cboCoCde.Text & "','" & _
                                            cus1no & "','" & _
                                            cus2no & "','" & strItem & "','" & strColor & "','" & _
                                            txtUMM & "','" & IIf(Trim(txtInrQtyM) = "", "0", txtInrQtyM) & "','" & _
                                            IIf(Trim(txtMtrQtyM) = "", "0", txtMtrQtyM) & "','" & _
                                            IIf(Trim(txtConFtr) = "", "1", txtConFtr) & "','" & gsUsrID & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUITMSUM, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            save_ok = False
            MsgBox("Error on loading updateAll sp_select_CUITMSUM_Q :" & rtnStr)
            Exit Sub
        End If

        If rs_CUITMSUM.Tables("RESULT").Rows.Count > 0 Then
            cuscol = rs_CUITMSUM.Tables("RESULT").Rows(0)("cis_cuscol")
            cusitm = rs_CUITMSUM.Tables("RESULT").Rows(0)("cis_cusitm")
            coldsc = rs_CUITMSUM.Tables("RESULT").Rows(0)("cis_coldsc")
            hstRef = rs_CUITMSUM.Tables("RESULT").Rows(0)("cis_refdoc")
            cususd = rs_CUITMSUM.Tables("RESULT").Rows(0)("cis_cususd")
            cuscad = rs_CUITMSUM.Tables("RESULT").Rows(0)("cis_cuscad")

            ' Check CIH Cust Sty No
            Dim rsTmpCustSty As New DataSet

            'S = "㊣IMCUSSTY_QU※S※" & strItem & "※" & cus1no
            'rsTmpCustSty = objBSGate.Enquire(gsConnStr, "sp_general", S)

            Cursor = Cursors.WaitCursor

            gsCompany = Trim(ma.cboCoCde.Text)
            Call Update_gs_Value(gsCompany)

            gspStr = "sp_select_IMCUSSTY_QU '" & ma.cboCoCde.Text & "','" & strItem & "','" & cus1no & "'"
            rtnLong = execute_SQLStatement(gspStr, rsTmpCustSty, rtnStr)
            gspStr = ""

            Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading updateAll sp_select_IMCUSSTY_QU :" & rtnStr)
                Cursor = Cursors.Default
                Exit Sub
            End If

            If rsTmpCustSty.Tables("RESULT").Rows.Count > 0 Then
                sFilter = "ics_cusstyno = '" & rs_CUITMSUM.Tables("RESULT").Rows(0)("cis_cusstyno").ToString & "'"
                rsTmpCustSty.Tables("RESULT").DefaultView.RowFilter = sFilter

                If rsTmpCustSty.Tables("RESULT").DefaultView.Count > 0 Then
                    ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cusstyno") = rs_CUITMSUM.Tables("RESULT").Rows(0)("cis_cusstyno")
                Else
                    ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cusstyno") = ""
                End If
            Else
                ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cusstyno") = ""
            End If

            dept = rs_CUITMSUM.Tables("RESULT").Rows(0)("cis_dept")

            If rs_CUITMSUM.Tables("RESULT").Rows(0)("cis_hrmcde").ToString <> "" Then
                hrmcde = rs_CUITMSUM.Tables("RESULT").Rows(0)("cis_hrmcde")

                sFilter = "yhc_hrmcde = " & "'" & hrmcde & "'"
                ma.rs_SYHRMCDE.Tables("RESULT").DefaultView.RowFilter = sFilter

                If ma.rs_SYHRMCDE.Tables("RESULT").DefaultView.Count > 0 Then
                    hrmcde = ma.rs_SYHRMCDE.Tables("RESULT").DefaultView(0)("yhc_hrmcde").ToString + " - " + ma.rs_SYHRMCDE.Tables("RESULT").DefaultView(0)("yhc_hrmdsc").ToString + _
                             IIf(ma.rs_SYHRMCDE.Tables("RESULT").DefaultView(0)("yhc_tarzon").ToString = "U", " (HSTU # for USA", " (Tariff # for Europe)")
                    dtyrat = ma.rs_SYHRMCDE.Tables("RESULT").DefaultView(0)("yhc_dtyrat")
                End If
                dtyrat = rs_CUITMSUM.Tables("RESULT").Rows(0)("cis_dtyrat")
            End If
        End If

        If rs_IMVENINF.Tables("RESULT").Rows.Count > 0 Then
            txtDtlPrcTrm = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_prctrm")
            txtFtyPrcTrm = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_ftyprctrm")
        Else
            txtDtlPrcTrm = ""
            txtFtyPrcTrm = ""
        End If

        If ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("Del").ToString = "Y" Then
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("Del") = "N"
        End If

        If ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("mode").ToString <> "NEW" Then
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("mode") = "UPD"
        End If

        ' Header Bar Section
        '**********************************************
        If strItem <> "" Then
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_itmno") = strItem
        End If

        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_ftytmpitm") = strIsNewFtyTmp
        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_tbm") = "N"
        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_itmsts") = Microsoft.VisualBasic.Left(itmsts, 3)
        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_qutitmsts") = IIf(Len(strPacking) > 0, "COMPLETE", "INCOMPLETE")

        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_ftytmpitmno") = strFtyTmp
        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_tbmsts") = "CMP"
        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_itmtyp") = ITMTYP
        '**********************************************

        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_alsitmno") = strAlsItmno
        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_alscolcde") = strAlsColcde
        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cosmth") = cosmth

        ' Item Description Section
        '**********************************************
        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_itmdsc") = itmdsc
        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cusitm") = cusitm
        '**********************************************

        ' Color Section
        '**********************************************
        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_colcde") = strColor
        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_coldsc") = coldsc
        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cuscol") = cuscol
        '**********************************************

        ' Packing Section
        '**********************************************
        If Len(strPacking) > 0 Then
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_untcde") = txtUMM
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_inrqty") = txtInrQtyM
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_mtrqty") = txtMtrQtyM
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cft") = txtCftM
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_conftr") = txtConFtr
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_qutdat") = Period
        Else
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_untcde") = ""
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_inrqty") = 0
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_mtrqty") = 0
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cft") = 0
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_conftr") = 1
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_qutdat") = ""
        End If
        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_pckitr") = pckitr

        If Len(strPacking) > 0 Then
            sFilter = "ipi_pckunt = '" & pckunt & "' and ipi_inrqty=" & inrqty & " and ipi_mtrqty=" & mtrqty
            rs_IMPCKINF.Tables("RESULT").DefaultView.RowFilter = sFilter

            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_basprc") = basprc
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_pckseq") = rs_IMPCKINF.Tables("RESULT").DefaultView(0)("ipi_pckseq")
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_inrdin") = rs_IMPCKINF.Tables("RESULT").DefaultView(0)("ipi_inrdin")
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_inrwin") = rs_IMPCKINF.Tables("RESULT").DefaultView(0)("ipi_inrwin")
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_inrhin") = rs_IMPCKINF.Tables("RESULT").DefaultView(0)("ipi_inrhin")
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_mtrdin") = rs_IMPCKINF.Tables("RESULT").DefaultView(0)("ipi_mtrdin")
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_mtrwin") = rs_IMPCKINF.Tables("RESULT").DefaultView(0)("ipi_mtrwin")
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_mtrhin") = rs_IMPCKINF.Tables("RESULT").DefaultView(0)("ipi_mtrhin")
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_inrdcm") = rs_IMPCKINF.Tables("RESULT").DefaultView(0)("ipi_inrdcm")
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_inrwcm") = rs_IMPCKINF.Tables("RESULT").DefaultView(0)("ipi_inrwcm")
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_inrhcm") = rs_IMPCKINF.Tables("RESULT").DefaultView(0)("ipi_inrhcm")
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_mtrdcm") = rs_IMPCKINF.Tables("RESULT").DefaultView(0)("ipi_mtrdcm")
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_mtrwcm") = rs_IMPCKINF.Tables("RESULT").DefaultView(0)("ipi_mtrwcm")
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_mtrhcm") = rs_IMPCKINF.Tables("RESULT").DefaultView(0)("ipi_mtrhcm")
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("inner_in") = Format(rs_IMPCKINF.Tables("RESULT").DefaultView(0)("ipi_inrdin"), "######0.####") + "x" + _
                                                    Format(rs_IMPCKINF.Tables("RESULT").DefaultView(0)("ipi_inrwin"), "######0.####") + "x" + _
                                                    Format(rs_IMPCKINF.Tables("RESULT").DefaultView(0)("ipi_inrwin"), "######0.####")
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("master_in") = Format(rs_IMPCKINF.Tables("RESULT").DefaultView(0)("ipi_mtrdin"), "######0.####") + "x" + _
                                                     Format(rs_IMPCKINF.Tables("RESULT").DefaultView(0)("ipi_mtrwin"), "######0.####") + "x" + _
                                                     Format(rs_IMPCKINF.Tables("RESULT").DefaultView(0)("ipi_mtrwin"), "######0.####")
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("inner_cm") = Format(rs_IMPCKINF.Tables("RESULT").DefaultView(0)("ipi_inrdcm"), "######0.####") + "x" + _
                                                    Format(rs_IMPCKINF.Tables("RESULT").DefaultView(0)("ipi_inrwcm"), "######0.####") + "x" + _
                                                    Format(rs_IMPCKINF.Tables("RESULT").DefaultView(0)("ipi_inrwcm"), "######0.####")
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("master_cm") = Format(rs_IMPCKINF.Tables("RESULT").DefaultView(0)("ipi_mtrdcm"), "######0.####") + "x" + _
                                                     Format(rs_IMPCKINF.Tables("RESULT").DefaultView(0)("ipi_mtrwcm"), "######0.####") + "x" + _
                                                     Format(rs_IMPCKINF.Tables("RESULT").DefaultView(0)("ipi_mtrwcm"), "######0.####")
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_grswgt") = Format(rs_IMPCKINF.Tables("RESULT").DefaultView(0)("ipi_grswgt"), "##0.###")
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_netwgt") = Format(rs_IMPCKINF.Tables("RESULT").DefaultView(0)("ipi_netwgt"), "##0.###")
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cbm") = rs_IMPCKINF.Tables("RESULT").DefaultView(0)("ipi_cbm")
        Else
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_basprc") = 0
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_inrdin") = 0
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_inrwin") = 0
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_inrhin") = 0
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_mtrdin") = 0
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_mtrwin") = 0
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_mtrhin") = 0
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_inrdcm") = 0
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_inrwcm") = 0
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_inrhcm") = 0
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_mtrdcm") = 0
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_mtrwcm") = 0
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_mtrhcm") = 0
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("inner_in") = "0x0x0"
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("master_in") = "0x0x0"
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("inner_cm") = "0x0x0"
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("master_cm") = "0x0x0"
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_grswgt") = 0
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_netwgt") = 0
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cbm") = 0
        End If
        '**********************************************

        ' Sample Section
        '**********************************************
        ' Smp Stock Qty
        ' Cust Smp Qty
        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_smpunt") = smpunt
        ' Total Smp Qty
        If UPD <> "E" Then
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_smpprc") = Format(smpprc, "########0.0000")
        End If
        '**********************************************

        ' Remark Section
        '**********************************************
        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_upc") = upccde
        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_hstref") = hstRef
        ' Notes
        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_imrmk") = imrmk
        '**********************************************

        ' Footer Section
        '**********************************************
        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_image") = img
        '**********************************************

        ' MOQ/MOA Section
        '**********************************************
        If Trim(ORI_MOQ) = "" Then
            ORI_MOQ = "0"
        End If
        If Trim(ORI_MOA) = "" Then
            ORI_MOA = "0"
        End If

        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_moflag") = ORI_MOFLAG
        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_orgmoq") = ORI_MOQ
        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_orgmoa") = ORI_MOA

        If ORI_MOFLAG = "Q" Then
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_moq") = ORI_MOQ
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_moa") = 0
        ElseIf ORI_MOFLAG = "A" Then
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_moq") = ORI_MOQ
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_moa") = ORI_MOA
        End If
        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_dept") = dept

        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_moqunttyp") = strMOQUNTTYP
        '**********************************************

        ' Price Section
        '**********************************************
        ' Sec. Cust. GM or MU - Missing
        If UPD <> "E" Then
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_discnt") = 0
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_prctrm") = txtDtlPrcTrm

            If Len(strPacking) > 0 Then
                ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cus1sp") = cus1sp
                ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cus2sp") = cus2sp
                ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cus1dp") = cus1dp
                ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cus2dp") = cus2dp
                ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cus1no") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_cus1no")
                ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cus2no") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_cus2no")
                ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_effdat") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_effdat")
                ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_expdat") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_expdat")
            Else
                ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cus1sp") = 0
                ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cus2sp") = 0
                ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cus1dp") = 0
                ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cus2dp") = 0
                ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cus1no") = ""
                ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cus2no") = ""
                ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_effdat") = "1900-01-01"
                ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_expdat") = "1900-01-01"
            End If

        End If
        ' CIH Price - Missing
        '**********************************************

        ' Cust. Retail Section
        '**********************************************
        If UPD <> "E" Then
            strTmp = SetCustItmCat()

            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_custitmcat") = Trim(Split(strTmp, "-")(0)) '""
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_custitmcatfml") = Trim(Split(strTmp, "-")(1)) '""
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_custitmcatamt") = CDbl(Trim(Split(strTmp, "-")(3)))
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_pmu") = Trim(Split(strTmp, "-")(2)) '""
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_calpmu") = 0
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cususd") = cususd
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cuscad") = cuscad
        End If
        '**********************************************

        ' Vendor Section
        '**********************************************
        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_venno") = venno
        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_subcde") = subcde
        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cusven") = CusVenNo
        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cussub") = ""
        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_venitm") = venitm
        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_ftyprctrm") = txtFtyPrcTrm

        If Len(strPacking) > 0 Then
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_fcurcde") = fcurcde
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_ftyprc") = ftyprc
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_ftycst") = ftycst
        Else
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_fcurcde") = ""
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_ftyprc") = 0
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_ftycst") = 0
        End If
        '**********************************************

        ' Assortment Section
        '**********************************************
        If ma.rs_QUASSINF.Tables.Count > 0 Then
            sFilter = "qai_qutseq = " & intSeq
            ma.rs_QUASSINF.Tables("RESULT").DefaultView.RowFilter = sFilter

            If ma.rs_QUASSINF.Tables("RESULT").DefaultView.Count > 0 Then
                For index As Integer = 0 To ma.rs_QUASSINF.Tables("RESULT").DefaultView.Count - 1
                    If ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("mode").ToString = "NEW" Then
                        ma.rs_QUASSINF.Tables("RESULT").DefaultView(index).Delete()
                    Else
                        ma.rs_QUASSINF.Tables("RESULT").DefaultView(index)("mode") = "DEL"
                    End If
                Next
                ma.rs_QUASSINF.Tables("RESULT").AcceptChanges()
            End If

            If rs_IMBOMASS.Tables("RESULT").Rows.Count > 0 Then
                For index As Integer = 0 To rs_IMBOMASS.Tables("RESULT").Rows.Count - 1
                    drNewRow = ma.rs_QUASSINF.Tables("RESULT").NewRow
                    drNewRow("mode") = "NEW"
                    drNewRow("qai_qutno") = ma.txtQutNo.Text
                    drNewRow("qai_qutseq") = intSeq
                    drNewRow("qai_itmno") = strItem
                    drNewRow("qai_assitm") = rs_IMBOMASS.Tables("RESULT").Rows(index)("iba_assitm")
                    drNewRow("qai_assdsc") = rs_IMBOMASS.Tables("RESULT").Rows(index)("ibi_engdsc")
                    drNewRow("qai_colcde") = rs_IMBOMASS.Tables("RESULT").Rows(index)("iba_colcde")
                    drNewRow("qai_coldsc") = rs_IMBOMASS.Tables("RESULT").Rows(index)("icf_coldsc")
                    drNewRow("qai_untcde") = rs_IMBOMASS.Tables("RESULT").Rows(index)("iba_pckunt")
                    drNewRow("qai_inrqty") = rs_IMBOMASS.Tables("RESULT").Rows(index)("iba_inrqty")
                    drNewRow("qai_mtrqty") = rs_IMBOMASS.Tables("RESULT").Rows(index)("iba_mtrqty")
                    drNewRow("qai_imperiod") = rs_IMBOMASS.Tables("RESULT").Rows(index)("iba_period")
                    ma.rs_QUASSINF.Tables("RESULT").Rows.Add(drNewRow)
                Next
                ma.rs_QUASSINF.Tables("RESULT").AcceptChanges()
            End If

            sFilter = ""
            ma.rs_QUASSINF.Tables("RESULT").DefaultView.RowFilter = sFilter
        End If
        '**********************************************

        Dim rsTmp As New DataSet
        Dim strCusno As String
        Dim strCus1No As String
        Dim strCus2No As String

        strCusno = ""
        strCus1No = ""
        strCus2No = ""

        If UPD <> "E" And UPD <> "C" Then
            ' Cost Element Section
            '**********************************************
            ' Begin Get Cost Element

            strCusno = ""
            If ma.cboCus2No.Text <> "" Then
                strCusno = Microsoft.VisualBasic.Left(ma.cboCus2No.Text, InStr(ma.cboCus2No.Text, " - ") - 1)

                'S = "㊣cucstemt_qu※S※" & strCusno
                'rsTmp = objBSGate.Enquire(gsConnStr, "sp_general", S)

                Cursor = Cursors.WaitCursor

                gsCompany = Trim(ma.cboCoCde.Text)
                Call Update_gs_Value(gsCompany)

                gspStr = "sp_select_cucstemt_qu '" & ma.cboCoCde.Text & "','" & strCusno & "'"
                rtnLong = execute_SQLStatement(gspStr, rsTmp, rtnStr)
                gspStr = ""

                Cursor = Cursors.Default

                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading updateAll sp_select_cucstemt_qu 1 :" & rtnStr)
                    Exit Sub
                End If

                If rsTmp.Tables("RESULT").Rows.Count = 0 Then
                    strCusno = Microsoft.VisualBasic.Left(ma.cboCus1No.Text, InStr(ma.cboCus1No.Text, " - ") - 1)
                End If
            Else
                strCusno = Microsoft.VisualBasic.Left(ma.cboCus1No.Text, InStr(ma.cboCus1No.Text, " - ") - 1)
            End If

            If strCusno = Microsoft.VisualBasic.Left(ma.cboCus1No.Text, InStr(ma.cboCus1No.Text, " - ") - 1) Then
                'S = "㊣cucstemt_qu※S※" & strCusno
                'rsTmp = objBSGate.Enquire(gsConnStr, "sp_general", S)

                Cursor = Cursors.WaitCursor

                gsCompany = Trim(ma.cboCoCde.Text)
                Call Update_gs_Value(gsCompany)

                gspStr = "sp_select_cucstemt_qu '" & ma.cboCoCde.Text & "','" & strCusno & "'"
                rtnLong = execute_SQLStatement(gspStr, rsTmp, rtnStr)
                gspStr = ""

                Cursor = Cursors.Default

                If rtnLong <> RC_SUCCESS Then
                    save_ok = False
                    MsgBox("Error on loading updateAll sp_select_cucstemt_qu 2 :" & rtnStr)
                    Exit Sub
                End If
            End If

            If ma.rs_QUCSTEMT.Tables.Count > 0 Then
                sFilter = "qce_qutseq = " & intSeq
                ma.rs_QUCSTEMT.Tables("RESULT").DefaultView.RowFilter = sFilter

                If ma.rs_QUCSTEMT.Tables("RESULT").DefaultView.Count > 0 Then
                    For index As Integer = 0 To ma.rs_QUCSTEMT.Tables("RESULT").DefaultView.Count - 1
                        If ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(index)("mode").ToString = "NEW" Then
                            ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(index).Delete()
                        Else
                            ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(index)("mode") = "DEL"
                        End If
                    Next
                    ma.rs_QUCSTEMT.Tables("RESULT").AcceptChanges()
                End If

                If rsTmp.Tables("RESULT").Rows.Count > 0 Then
                    For index As Integer = 0 To rsTmp.Tables("RESULT").Rows.Count - 1
                        drNewRow = ma.rs_QUCSTEMT.Tables("RESULT").NewRow
                        drNewRow("mode") = "NEW"
                        drNewRow("qce_qutno") = ma.txtQutNo.Text
                        drNewRow("qce_qutseq") = intSeq
                        drNewRow("qce_cecde") = rsTmp.Tables("RESULT").Rows(index)("cce_cecde")
                        drNewRow("qce_ceseq") = rsTmp.Tables("RESULT").Rows(index)("cce_seq")
                        drNewRow("cce_cedsc") = rsTmp.Tables("RESULT").Rows(index)("cce_cedsc")
                        drNewRow("cce_percent_d") = rsTmp.Tables("RESULT").Rows(index)("cce_percent_d")
                        drNewRow("qce_percent") = rsTmp.Tables("RESULT").Rows(index)("cce_percent")
                        drNewRow("qce_curcde") = rsTmp.Tables("RESULT").Rows(index)("cce_curcde")
                        drNewRow("cce_amt_d") = rsTmp.Tables("RESULT").Rows(index)("cce_amt_d")
                        drNewRow("qce_amt") = rsTmp.Tables("RESULT").Rows(index)("cce_amt")
                        drNewRow("cce_chg") = rsTmp.Tables("RESULT").Rows(index)("cce_chg")
                        ma.rs_QUCSTEMT.Tables("RESULT").Rows.Add(drNewRow)
                    Next
                    ma.rs_QUCSTEMT.Tables("RESULT").AcceptChanges()
                End If

                strCusno = ""
                If ma.cboCus2No.Text <> "" Then
                    strCusno = Microsoft.VisualBasic.Left(ma.cboCus2No.Text, InStr(ma.cboCus2No.Text, " - ") - 1)

                    'S = "㊣CUCSTAMT_qu※S※" & strCusno
                    'rsTmp = objBSGate.Enquire(gsConnStr, "sp_general", S)

                    Cursor = Cursors.WaitCursor

                    gsCompany = Trim(ma.cboCoCde.Text)
                    Call Update_gs_Value(gsCompany)

                    gspStr = "sp_select_CUCSTAMT_qu '" & ma.cboCoCde.Text & "','" & strCusno & "'"
                    rtnLong = execute_SQLStatement(gspStr, rsTmp, rtnStr)
                    gspStr = ""

                    Cursor = Cursors.Default

                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading updateAll sp_select_CUCSTAMT_qu 1 :" & rtnStr)
                        Exit Sub
                    End If

                    If rsTmp.Tables("RESULT").Rows.Count = 0 Then
                        strCusno = Microsoft.VisualBasic.Left(ma.cboCus1No.Text, InStr(ma.cboCus1No.Text, " - ") - 1)
                    End If
                Else
                    strCusno = Microsoft.VisualBasic.Left(ma.cboCus1No.Text, InStr(ma.cboCus1No.Text, " - ") - 1)
                End If

                If strCusno = Microsoft.VisualBasic.Left(ma.cboCus1No.Text, InStr(ma.cboCus1No.Text, " - ") - 1) Then
                    'S = "㊣CUCSTAMT_qu※S※" & strCusno
                    'rsTmp = objBSGate.Enquire(gsConnStr, "sp_general", S)

                    Cursor = Cursors.WaitCursor

                    gsCompany = Trim(ma.cboCoCde.Text)
                    Call Update_gs_Value(gsCompany)

                    gspStr = "sp_select_CUCSTAMT_qu '" & ma.cboCoCde.Text & "','" & strCusno & "'"
                    rtnLong = execute_SQLStatement(gspStr, rsTmp, rtnStr)
                    gspStr = ""

                    Cursor = Cursors.Default

                    If rtnLong <> RC_SUCCESS Then
                        save_ok = False
                        MsgBox("Error on loading updateAll sp_select_CUCSTAMT_qu 2 :" & rtnStr)
                        Exit Sub
                    End If
                End If

                Dim strBasPrc As String

                If IsDBNull(ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_basprc")) = True Then
                    strBasPrc = "0"
                Else
                    strBasPrc = CStr(ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_basprc"))
                End If

                If rsTmp.Tables("RESULT").Rows.Count > 0 Then
                    For index As Integer = 0 To ma.rs_QUCSTEMT.Tables("RESULT").DefaultView.Count - 1
                        sFilter = "cca_cecde = '" + ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(index)("qce_cecde") + "' and " + _
                                        " cca_bp2 >= " + strBasPrc + "  and cca_bp1 <= " + strBasPrc
                        rsTmp.Tables("RESULT").DefaultView.RowFilter = sFilter

                        If rsTmp.Tables("RESULT").DefaultView.Count > 0 Then
                            ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(index)("cce_amt_d") = ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(index)("cce_amt_d") / rsTmp.Tables("RESULT").DefaultView(0)("cca_estqty")
                            ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(index)("qce_amt") = ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(index)("cce_amt_d")
                        End If
                    Next
                End If

                sFilter = ""
                ma.rs_QUCSTEMT.Tables("RESULT").DefaultView.RowFilter = sFilter
            End If
            ' End Get Cost Element
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_specpck") = ""
        End If

        If UPD <> "E" Then
            If ma.rs_QUCSTEMT.Tables.Count > 0 Then
                If ma.rs_QUCSTEMT.Tables("RESULT").DefaultView.Count > 0 Then
                    sFilter = "qce_qutseq = " & intSeq & " and mode <> 'DEL'"
                Else
                    sFilter = ""
                End If
                ma.rs_QUCSTEMT.Tables("RESULT").DefaultView.RowFilter = sFilter
            End If

            '**********************************************
            Call CalculatePrc(strItem, intSeq)
            ' Refresh Price after calculate Cost Element

            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_discnt") = 0

            If Len(strPacking) > 0 Then
                ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cus1sp") = cus1sp
                ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cus2sp") = cus2sp
                ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cus1dp") = cus1dp
                ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cus2dp") = cus2dp
            Else
                ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cus1sp") = 0
                ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cus2sp") = 0
                ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cus1dp") = 0
                ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cus2dp") = 0
            End If

            ' Element Landed Cost Section
            '**********************************************
            If hrmcde <> "" Then
                ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_hrmcde") = Split(hrmcde, "-")(0)
            Else
                ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_hrmcde") = ""
            End If
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_dtyrat") = dtyrat

            'Begin Get ELC
            strCusno = ""
            If ma.cboCus2No.Text <> "" Then
                strCusno = Microsoft.VisualBasic.Left(ma.cboCus2No.Text, InStr(ma.cboCus2No.Text, " - ") - 1)

                'S = "㊣cuelc_qu※S※" & strCusno
                'rsTmp = objBSGate.Enquire(gsConnStr, "sp_general", S)

                Cursor = Cursors.WaitCursor

                gsCompany = Trim(ma.cboCoCde.Text)
                Call Update_gs_Value(gsCompany)

                gspStr = "sp_select_cuelc_qu '" & ma.cboCoCde.Text & "','" & strCusno & "'"
                rtnLong = execute_SQLStatement(gspStr, rsTmp, rtnStr)
                gspStr = ""

                Cursor = Cursors.Default

                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading updateAll sp_select_cuelc_qu 1 :" & rtnStr)
                    Exit Sub
                End If

                If rsTmp.Tables("RESULT").Rows.Count = 0 Then
                    strCusno = Microsoft.VisualBasic.Left(ma.cboCus1No.Text, InStr(ma.cboCus1No.Text, " - ") - 1)
                End If
            Else
                strCusno = Microsoft.VisualBasic.Left(ma.cboCus1No.Text, InStr(ma.cboCus1No.Text, " - ") - 1)
            End If

            If strCusno = Microsoft.VisualBasic.Left(ma.cboCus1No.Text, InStr(ma.cboCus1No.Text, " - ") - 1) Then
                'S = "㊣cuelc_qu※S※" & strCusno
                'rsTmp = objBSGate.Enquire(gsConnStr, "sp_general", S)

                Cursor = Cursors.WaitCursor

                gsCompany = Trim(ma.cboCoCde.Text)
                Call Update_gs_Value(gsCompany)

                gspStr = "sp_select_cuelc_qu '" & ma.cboCoCde.Text & "','" & strCusno & "'"
                rtnLong = execute_SQLStatement(gspStr, rsTmp, rtnStr)
                gspStr = ""

                Cursor = Cursors.Default

                If rtnLong <> RC_SUCCESS Then
                    save_ok = False
                    MsgBox("Error on loading updateAll sp_select_cuelc_qu 2 :" & rtnStr)
                    Exit Sub
                End If
            End If

            If ma.rs_QUELC.Tables.Count > 0 Then
                sFilter = "qec_qutseq = " & intSeq
                ma.rs_QUELC.Tables("RESULT").DefaultView.RowFilter = sFilter

                If ma.rs_QUELC.Tables("RESULT").DefaultView.Count > 0 Then
                    For index As Integer = 0 To ma.rs_QUELC.Tables("RESULT").DefaultView.Count - 1
                        If ma.rs_QUELC.Tables("RESULT").DefaultView(index)("mode").ToString = "NEW" Then
                            ma.rs_QUELC.Tables("RESULT").DefaultView(index).Delete()
                        Else
                            ma.rs_QUELC.Tables("RESULT").DefaultView(index)("mode") = "DEL"
                        End If
                    Next
                    ma.rs_QUELC.Tables("RESULT").AcceptChanges()
                End If

                If rsTmp.Tables("RESULT").Rows.Count > 0 Then
                    For index As Integer = 0 To rsTmp.Tables("RESULT").Rows.Count - 1
                        drNewRow = ma.rs_QUELC.Tables("RESULT").NewRow
                        drNewRow("mode") = "NEW"
                        drNewRow("qec_qutno") = ma.txtQutNo.Text
                        drNewRow("qec_qutseq") = intSeq
                        drNewRow("qec_grpcde") = rsTmp.Tables("RESULT").Rows(index)("cec_grpcde")
                        drNewRow("cec_grpdsc") = rsTmp.Tables("RESULT").Rows(index)("cec_grpdsc")
                        drNewRow("qec_curcde") = strCurCde2
                        drNewRow("qec_amt") = 0
                        ma.rs_QUELC.Tables("RESULT").Rows.Add(drNewRow)
                    Next
                    ma.rs_QUELC.Tables("RESULT").AcceptChanges()
                End If

                sFilter = ""
                ma.rs_QUELC.Tables("RESULT").DefaultView.RowFilter = sFilter
            End If
            ' End Get ELC

            'Begin Get ELCDTL
            strCusno = ""
            If ma.cboCus2No.Text <> "" Then
                strCusno = Microsoft.VisualBasic.Left(ma.cboCus2No.Text, InStr(ma.cboCus2No.Text, " - ") - 1)

                'S = "㊣cuelcdtl_qu※S※" & strCusno
                'rsTmp = objBSGate.Enquire(gsConnStr, "sp_general", S)

                Cursor = Cursors.WaitCursor

                gsCompany = Trim(ma.cboCoCde.Text)
                Call Update_gs_Value(gsCompany)

                gspStr = "sp_select_cuelcdtl_qu '" & ma.cboCoCde.Text & "','" & strCusno & "'"
                rtnLong = execute_SQLStatement(gspStr, rsTmp, rtnStr)
                gspStr = ""

                Cursor = Cursors.Default

                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading updateAll sp_select_cuelcdtl_qu 1 :" & rtnStr)
                    Exit Sub
                End If

                If rsTmp.Tables("RESULT").Rows.Count = 0 Then
                    strCusno = Microsoft.VisualBasic.Left(ma.cboCus1No.Text, InStr(ma.cboCus1No.Text, " - ") - 1)
                End If
            Else
                strCusno = Microsoft.VisualBasic.Left(ma.cboCus1No.Text, InStr(ma.cboCus1No.Text, " - ") - 1)
            End If

            If strCusno = Microsoft.VisualBasic.Left(ma.cboCus1No.Text, InStr(ma.cboCus1No.Text, " - ") - 1) Then
                'S = "㊣cuelcdtl_qu※S※" & strCusno
                'rsTmp = objBSGate.Enquire(gsConnStr, "sp_general", S)

                Cursor = Cursors.WaitCursor

                gsCompany = Trim(ma.cboCoCde.Text)
                Call Update_gs_Value(gsCompany)

                gspStr = "sp_select_cuelcdtl_qu '" & ma.cboCoCde.Text & "','" & strCusno & "'"
                rtnLong = execute_SQLStatement(gspStr, rsTmp, rtnStr)
                gspStr = ""

                Cursor = Cursors.Default

                If rtnLong <> RC_SUCCESS Then
                    save_ok = False
                    MsgBox("Error on loading updateAll sp_select_cuelcdtl_qu 2 :" & rtnStr)
                    Exit Sub
                End If
            End If

            If ma.rs_QUELCDTL.Tables.Count > 0 Then
                sFilter = "qed_qutseq = " & intSeq
                ma.rs_QUELCDTL.Tables("RESULT").DefaultView.RowFilter = sFilter

                If ma.rs_QUELCDTL.Tables("RESULT").DefaultView.Count > 0 Then
                    For index As Integer = 0 To ma.rs_QUELCDTL.Tables("RESULT").DefaultView.Count - 1
                        If ma.rs_QUELCDTL.Tables("RESULT").DefaultView(index)("mode").ToString = "NEW" Then
                            ma.rs_QUELCDTL.Tables("RESULT").DefaultView(index).Delete()
                        Else
                            ma.rs_QUELCDTL.Tables("RESULT").DefaultView(index)("mode") = "DEL"
                        End If
                    Next
                    ma.rs_QUELCDTL.Tables("RESULT").AcceptChanges()
                End If

                If rsTmp.Tables("RESULT").Rows.Count > 0 Then
                    For index As Integer = 0 To rsTmp.Tables("RESULT").Rows.Count - 1
                        drNewRow = ma.rs_QUELCDTL.Tables("RESULT").NewRow
                        drNewRow("mode") = "NEW"
                        drNewRow("qed_qutno") = ma.txtQutNo.Text
                        drNewRow("qed_qutseq") = intSeq
                        drNewRow("qed_grpcde") = rsTmp.Tables("RESULT").Rows(index)("ced_grpcde")
                        drNewRow("ced_grpdsc") = rsTmp.Tables("RESULT").Rows(index)("ced_grpdsc")
                        drNewRow("qed_seq") = rsTmp.Tables("RESULT").Rows(index)("ced_seq")
                        drNewRow("qed_cecde") = rsTmp.Tables("RESULT").Rows(index)("ced_cecde")
                        drNewRow("ced_cedsc") = rsTmp.Tables("RESULT").Rows(index)("ced_cedsc")
                        drNewRow("qed_percent") = rsTmp.Tables("RESULT").Rows(index)("ced_percent")
                        drNewRow("ced_chg") = rsTmp.Tables("RESULT").Rows(index)("ced_chg")
                        drNewRow("qed_curcde") = strCurCde2
                        drNewRow("qed_amt") = 0
                        ma.rs_QUELCDTL.Tables("RESULT").Rows.Add(drNewRow)
                        Call CalculateELC()
                    Next
                    ma.rs_QUELCDTL.Tables("RESULT").AcceptChanges()
                End If

                sFilter = "qed_qutseq = " + CStr(intSeq) + " and mode = 'NEW'"
                ma.rs_QUELCDTL.Tables("RESULT").DefaultView.RowFilter = sFilter

                Call CalculateELCDuty(CDbl(ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_dtyrat")))
                Call CalculateELCTran()

                sFilter = ""
                ma.rs_QUELCDTL.Tables("RESULT").DefaultView.RowFilter = sFilter
            End If
            ' End Get ELCDTL
            '**********************************************
        End If

        Call CalculateMatBkd(intSeq)
        ' Do once more timr after the ELC is calculated

        strTmp = SetCustItmCat()

        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_custitmcat") = Trim(Split(strTmp, "-")(0))
        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_custitmcatfml") = Trim(Split(strTmp, "-")(1))
        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_custitmcatamt") = CDbl(Trim(Split(strTmp, "-")(3)))
        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_pmu") = Trim(Split(strTmp, "-")(2))

        If CDbl(ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cususd")) = 0 Then
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cususd") = ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_custitmcatamt")
        End If

        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_calpmu") = CalculatePMU()

        If ma.rs_QUCSTEMT.Tables.Count > 0 Then
            sFilter = ""
            ma.rs_QUCSTEMT.Tables("RESULT").DefaultView.RowFilter = sFilter
        End If

        If ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_contopc") = "Y" And ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cus1sp") <> 0 Then
            'ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_pcprc") = Format(roundup(ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cus1sp") / ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_conftr")), "###,###,##0.0000")
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_pcprc") = Format(round2(ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cus1sp") / ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_conftr")), "###,###,##0.0000")
        Else
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_pcprc") = 0
        End If

        sFilter = ""
        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView.RowFilter = sFilter

        rs_IMBASINF.Tables.Clear()
        rs_IMCOLINF.Tables.Clear()
        rs_IMPCKINF.Tables.Clear()
        rs_IMMATBKD.Tables.Clear()
        rs_IMBOMASS.Tables.Clear()
        rs_IMPRCINF.Tables.Clear()
        rs_IMVENINF.Tables.Clear()
        rs_CUITMSUM.Tables.Clear()
        rs_SYTIESTR.Tables.Clear()
        rs_SYCONFTR.Tables.Clear()
        rs_CUMCOVEN.Tables.Clear()
        rs_CUMCAMRK.Tables.Clear()
        'rs_IMBASINF = Nothing
        'rs_IMCOLINF = Nothing
        'rs_IMPCKINF = Nothing
        'rs_IMMATBKD = Nothing
        'rs_IMBOMASS = Nothing
        'rs_IMVENINF = Nothing
        'rs_CUITMSUM = Nothing
        'rs_SYTIESTR = Nothing
        'rs_SYCONFTR = Nothing
        'rs_CUMCOVEN = Nothing
        'rs_CUMCAMRK = Nothing

        Cursor = Cursors.Default
    End Sub

    Private Function CalculatePMU() As Double
        Dim dblELC As Double

        dblELC = 0

        If ma.rs_QUELC.Tables.Count > 0 Then
            If ma.rs_QUELC.Tables("RESULT").DefaultView.Count > 0 Then
                For index As Integer = 0 To ma.rs_QUELC.Tables("RESULT").DefaultView.Count - 1
                    If ma.rs_QUELC.Tables("RESULT").DefaultView(index)("mode").ToString <> "DEL" Then
                        If ma.rs_QUELC.Tables("RESULT").DefaultView(index)("qec_grpcde").ToString = "001" Then
                            dblELC = CDec(IIf(IsDBNull(ma.rs_QUELC.Tables("RESULT").DefaultView(index)("qec_amt")) = True, 0, ma.rs_QUELC.Tables("RESULT").DefaultView(index)("qec_amt")))
                            Exit For
                        End If
                    End If
                Next
            End If
        End If

        If Trim(ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cususd").ToString) = "" Then
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cususd") = 0
        End If

        If CDbl(Trim(ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cususd").ToString)) <> 0 Then
            CalculatePMU = round(((CDec(ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cususd")) - dblELC) / CDec(ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cususd"))) * 100, 2)
            'CalculatePMU = roundup(((CDec(ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cususd")) - dblELC) / CDec(ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cususd"))) * 100)
        Else
            CalculatePMU = 0
        End If
    End Function

    Private Sub CalculateELC()
        Dim decAjdPrc As Double
        Dim rsTmp As New DataSet
        Dim strQudSeq As String
        Dim strGrpCde As String
        Dim strGrpCde_old As String
        Dim dblTtl As Double

        dblTtl = 0

        If ma.rs_QUELCDTL.Tables.Count > 0 Then
            If ma.rs_QUELCDTL.Tables("RESULT").DefaultView.Count > 0 Then
                If CDec(IIf(Trim(ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cus2dp").ToString()) = "", "0", ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cus2dp"))) <> 0 Then
                    decAjdPrc = CDec(ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cus2dp"))
                Else
                    decAjdPrc = CDec(ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cus1dp"))
                End If

                For index As Integer = 0 To ma.rs_QUELCDTL.Tables("RESULT").DefaultView.Count - 1
                    If Trim(ma.rs_QUELCDTL.Tables("RESULT").DefaultView(index)("ced_cedsc").ToString) = "Transportation" And _
                        ma.rs_QUELCDTL.Tables("RESULT").DefaultView(index)("mode").ToString <> "DEL" Then
                        If decAjdPrc = 0 Then
                            ma.rs_QUELCDTL.Tables("RESULT").DefaultView(index)("qed_amt") = 0
                            ma.rs_QUELCDTL.Tables("RESULT").DefaultView(index)("qed_percent") = 0
                        Else
                            ma.rs_QUELCDTL.Tables("RESULT").DefaultView(index)("qed_percent") = round((ma.rs_QUELCDTL.Tables("RESULT").DefaultView(index)("qed_amt") / decAjdPrc) * 100, 2)
                        End If
                    Else
                        ma.rs_QUELCDTL.Tables("RESULT").DefaultView(index)("qed_amt") = (ma.rs_QUELCDTL.Tables("RESULT").DefaultView(index)("qed_percent") * decAjdPrc) / 100
                    End If
                Next

                strGrpCde_old = ma.rs_QUELCDTL.Tables("RESULT").DefaultView(0)("qed_grpcde")

                For index As Integer = 0 To ma.rs_QUELCDTL.Tables("RESULT").DefaultView.Count - 1
                    strGrpCde = ma.rs_QUELCDTL.Tables("RESULT").DefaultView(index)("qed_grpcde")
                    strQudSeq = ma.rs_QUELCDTL.Tables("RESULT").DefaultView(index)("qed_qutseq")

                    If strGrpCde <> strGrpCde_old Then
                        dblTtl = 0
                    End If

                    If ma.rs_QUELCDTL.Tables("RESULT").DefaultView(index)("qed_qutseq").ToString = strQudSeq And _
                        ma.rs_QUELCDTL.Tables("RESULT").DefaultView(index)("qed_grpcde").ToString = strGrpCde Then
                        If ma.rs_QUELCDTL.Tables("RESULT").DefaultView(index)("mode") <> "DEL" Then
                            dblTtl = dblTtl + CDec(IIf(IsDBNull(ma.rs_QUELCDTL.Tables("RESULT").DefaultView(index)("qed_amt")) = True, 0, ma.rs_QUELCDTL.Tables("RESULT").DefaultView(index)("qed_amt")))
                        End If
                    End If

                    If ma.rs_QUELC.Tables("RESULT").DefaultView.Count > 0 Then
                        For index1 As Integer = 0 To ma.rs_QUELC.Tables("RESULT").DefaultView.Count - 1
                            If ma.rs_QUELC.Tables("RESULT").DefaultView(index1)("mode").ToString <> "DEL" Then
                                If ma.rs_QUELC.Tables("RESULT").DefaultView(index1)("qec_grpcde").ToString = strGrpCde Then
                                    ma.rs_QUELC.Tables("RESULT").DefaultView(index1)("qec_amt") = dblTtl + decAjdPrc
                                    'Exit Sub
                                End If
                            End If
                        Next
                    End If
                    strGrpCde_old = strGrpCde
                Next
            End If
        End If
    End Sub

    Private Function not_Valid_Item(ByVal itmNo As String, ByVal cus1no As String, ByVal colcde As String) As Boolean
        'S = "㊣IMXChk※S※" & cus1no & "※" & colcde & "※" & itmNo
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gsCompany = Trim(ma.cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_IMXChk '" & ma.cboCoCde.Text & "','" & cus1no & "','" & colcde & "','" & itmNo & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_IMXCHK, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            not_Valid_Item = True
            save_ok = False
            MsgBox("Error on loading not_Valid_Item sp_select_IMXChk :" & rtnStr)
            Exit Function
        End If

        If rs_IMXCHK.Tables("RESULT").Rows.Count = 0 Then
            not_Valid_Item = True
            save_ok = False
            MsgBox("Item cannot Quot by this Company! Customer and Compnay Relation Missing.")
        Else
            If rs_IMXCHK.Tables("RESULT").Rows(0)("imx_vendef").ToString <> "Y" Then
                If MsgBox("This is not the default company to quot this item, Do you continue the quot?", vbYesNo) = vbYes Then
                    not_Valid_Item = False
                Else
                    save_ok = False
                    not_Valid_Item = True
                End If
            Else
                not_Valid_Item = False
            End If
        End If
    End Function

    Private Function Eval(ByVal p As Double, ByVal S As String) As Double
        On Error GoTo EvalErr

        Dim Op As String = "* 1"
        Dim end_pos As Integer
        Dim r As Double, temp As Double

        S = Replace(S, " ", "") '*** Remove any space in the string

        '*** If the first character is not '*' or '/',
        '*** Just pack a '*' at the beginning of the string
        If (Mid(S, 1, 1) <> "*") And (Mid(S, 1, 1) <> "/") Then
            S = "*" & S
        End If

        r = p

        While (Len(S) <> 0)
            S = LTrim(S)
            Op = Mid(S, 1, 1)
            S = Mid(LTrim(S), 2, Len(S))

            If (InStr(S, "*") = 0 And InStr(S, "/") = 0) Then
                end_pos = Len(S) + 1
            ElseIf (InStr(S, "*") = 0) Then
                end_pos = InStr(S, "/")
            ElseIf (InStr(S, "/") = 0) Then
                end_pos = InStr(S, "*")
            Else
                If (InStr(S, "*") < InStr(S, "/")) Then
                    end_pos = InStr(S, "*")
                Else
                    end_pos = InStr(S, "/")
                End If
            End If

            temp = CDbl(Mid(S, 1, end_pos - 1))

            If Op = "*" Then
                r = r * temp
            ElseIf Op = "/" Then
                r = r / temp
            End If

            S = Mid(S, end_pos, Len(S))
        End While

        Eval = r
        Exit Function

EvalErr:
        Eval = -1

    End Function

    Private Function round2(ByVal Value As Double) As Double
        Dim tmp As String

        Value = round(Value, 4)
        tmp = CStr(Value)

        If InStr(tmp, ".") > 0 Then
            If Len(Microsoft.VisualBasic.Right(tmp, Len(tmp) - InStr(tmp, "."))) > 2 Then
                If CDec(Microsoft.VisualBasic.Right(Microsoft.VisualBasic.Left(Microsoft.VisualBasic.Right(tmp, Len(tmp) - InStr(tmp, ".")), 3), 1)) > 0 Then
                    round2 = CDec(tmp) + 0.01
                    round2 = CDec(Microsoft.VisualBasic.Left(CStr(round2), InStr(round2, ".") + 2))
                Else
                    round2 = round(CDec(tmp), 2)
                    Exit Function
                End If
            Else
                round2 = CDec(tmp)
                Exit Function
            End If
        Else
            round2 = CDec(tmp)
            Exit Function
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

    Private Function roundup(ByVal Value As Double) As Double
        Dim tmp As String

        Value = round(Value, 5)
        tmp = CStr(Value)

        If InStr(tmp, ".") > 0 Then
            If Len(Microsoft.VisualBasic.Right(tmp, Len(tmp) - InStr(tmp, "."))) > 4 Then
                roundup = CDec(tmp) + 0.0001
                roundup = CDec(Microsoft.VisualBasic.Left(CStr(roundup), InStr(roundup, ".") + 4))
                Exit Function
            Else
                roundup = CDec(tmp)
                Exit Function
            End If
        Else
            roundup = CDec(tmp)
            Exit Function
        End If
    End Function

    Private Sub updateIM(ByVal intSeq As Integer, ByVal strItem As String, ByVal strFtyTmp As String, ByVal strIsNewFtyTmp As String)
        sFilter = "qud_qutseq=" & intSeq
        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView.RowFilter = sFilter

        If ma.rs_QUOTNDTL.Tables("RESULT").DefaultView.Count = 0 Then
            Cursor = Cursors.Default
            save_ok = False
            MsgBox("Quotation Seq [" & intSeq & "] Invalid!")
            Exit Sub
        End If

        'S = "㊣IMBASINF_Q※S※" & strItem
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gsCompany = Trim(ma.cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_IMBASINF_Q '" & ma.cboCoCde.Text & "','" & strItem & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_IMBASINF, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            save_ok = False
            MsgBox("Error on loading updateIM sp_select_IMBASINF_Q :" & rtnStr)
            Exit Sub
        End If

        If rs_IMBASINF.Tables("RESULT").Rows.Count = 0 Then
            Cursor = Cursors.Default
            save_ok = False
            MsgBox("Item " & strItem & " Not Found or Not In Complete or Incomplete Status!")
            Exit Sub
        End If

        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView.Item(0)("qud_itmsts") = Microsoft.VisualBasic.Left(rs_IMBASINF.Tables("RESULT").Rows(0)("ibi_itmsts").ToString, 3)
        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView.Item(0)("qud_itmno") = strItem
        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView.Item(0)("qud_ftytmpitm") = strIsNewFtyTmp

        If strFtyTmp <> "" Then
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView.Item(0)("qud_ftytmpitmno") = strFtyTmp
        End If

        If ma.rs_QUOTNDTL.Tables("RESULT").DefaultView.Item(0)("mode") <> "NEW" Then
            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView.Item(0)("mode") = "UPD"
        End If

        sFilter = ""
        ma.rs_QUOTNDTL.Tables("RESULT").DefaultView.RowFilter = sFilter
    End Sub

    Private Function GetCusSty(ByVal strItmNo As String, ByVal strCusno As String) As String
        ' Show Customer Alias
        Dim rsCusals As New DataSet

        'S = "㊣IMCUSSTY_QU※S※" & strItmNo & "※" & strCusno
        'rsTmp = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gsCompany = Trim(ma.cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_IMCUSSTY_QU '" & ma.cboCoCde.Text & "','" & strItmNo & "','" & strCusno & "'"
        rtnLong = execute_SQLStatement(gspStr, rsCusals, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading GetCusSty sp_select_IMCUSSTY_QU :" & rtnStr)
            GetCusSty = ""
            Exit Function
        End If

        If rsCusals.Tables("RESULT").Rows.Count > 0 Then
            GetCusSty = IIf(Trim(rsCusals.Tables("RESULT").Rows(0)("ics_cusstyno").ToString) = "", "", rsCusals.Tables("RESULT").Rows(0)("ics_cusstyno").ToString)
        Else
            GetCusSty = ""
        End If
    End Function

    Private Function SetCustItmCat() As String
        Dim S As String
        Dim strCust As String
        Dim strDef As String
        Dim rs_CustItmCat As New DataSet
        Dim strFml As String
        Dim strPMU As String
        Dim dblELC As Double

        If Trim(cus2no) <> "" Then
            strCust = cus2no
            'S = "㊣CURETPRC※S※" & strCust
            'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

            Cursor = Cursors.WaitCursor

            gsCompany = Trim(ma.cboCoCde.Text)
            Call Update_gs_Value(gsCompany)

            gspStr = "sp_select_CURETPRC '" & ma.cboCoCde.Text & "','" & strCust & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_CustItmCat, rtnStr)
            gspStr = ""

            Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SetCustItmCat sp_select_CURETPRC 1 :" & rtnStr)
                Cursor = Cursors.Default
                SetCustItmCat = "-" + "-" + "-0"
                Exit Function
            End If

            If rs_CustItmCat.Tables("RESULT").Rows.Count = 0 Then
                strCust = cus1no
            End If
        Else
            strCust = cus1no
        End If

        If strCust = cus1no Then
            'S = "㊣CURETPRC※S※" & strCust
            'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

            Cursor = Cursors.WaitCursor

            gsCompany = Trim(ma.cboCoCde.Text)
            Call Update_gs_Value(gsCompany)

            gspStr = "sp_select_CURETPRC '" & ma.cboCoCde.Text & "','" & strCust & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_CustItmCat, rtnStr)
            gspStr = ""

            Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading SetCustItmCat sp_select_CURETPRC 2 :" & rtnStr)
                Cursor = Cursors.Default
                SetCustItmCat = "-" + "-" + "-0"
                Exit Function
            End If
        End If

        If rs_CustItmCat.Tables("RESULT").Rows.Count > 0 Then
            For index As Integer = 0 To rs_CustItmCat.Tables("RESULT").Rows.Count - 1
                If rs_CustItmCat.Tables("RESULT").Rows(index)("crp_default").ToString = "Y" Then
                    strDef = rs_CustItmCat.Tables("RESULT").Rows(index)("crp_rpdsc")
                    strFml = rs_CustItmCat.Tables("RESULT").Rows(index)("crp_fmldsc")
                    strPMU = rs_CustItmCat.Tables("RESULT").Rows(index)("crp_pmu")
                    Exit For
                End If
            Next

            If strFml <> "" Then
                If ma.rs_QUELC.Tables.Count > 0 Then
                    If ma.rs_QUELC.Tables("RESULT").DefaultView.Count > 0 Then
                        For index As Integer = 0 To ma.rs_QUELC.Tables("RESULT").DefaultView.Count - 1
                            If ma.rs_QUELC.Tables("RESULT").DefaultView(index)("mode").ToString <> "DEL" Then
                                If ma.rs_QUELC.Tables("RESULT").DefaultView(index)("qec_grpcde").ToString = "001" Then
                                    dblELC = CDec(ma.rs_QUELC.Tables("RESULT").DefaultView(index)("qec_amt"))
                                    Exit For
                                End If
                            End If
                        Next
                    End If
                End If

                If dblELC <> 0 Then
                    S = CalculateRetPrc(dblELC, strFml)
                Else
                    S = "0"
                End If
            Else
                S = "0"
            End If

            SetCustItmCat = strDef + "-" + strFml + "-" + strPMU + "-" + S
        Else
            SetCustItmCat = "-" + "-" + "-0"
        End If
    End Function

    Private Function CalculateRetPrc(ByVal AdjPrc As Double, ByVal fml As String) As String
        Dim d As Double
        d = Eval(AdjPrc, fml)

        If d = -1 Then
            'CalculateRetPrc = Format(roundup(AdjPrc), "###,###,##0.0000")
            CalculateRetPrc = Format(round2(AdjPrc), "###,###,##0.0000")
        Else
            'CalculateRetPrc = Format(roundup(d), "###,###,##0.0000")
            CalculateRetPrc = Format(round2(d), "###,###,##0.0000")
        End If
    End Function

    Private Sub CalculateMatBkd(ByVal intSeq As Integer)
        Dim dblDp As Double

        dblDp = 0

        If ma.rs_QUCPTBKD.Tables.Count > 0 Then
            sFilter = "qcb_qutseq = " & CStr(intSeq) & " and mode <> 'DEL'"
            ma.rs_QUCPTBKD.Tables("RESULT").DefaultView.RowFilter = sFilter

            If ma.rs_QUCPTBKD.Tables("RESULT").DefaultView.Count > 0 Then
                If Trim(ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cus2dp").ToString) = "" Then
                    ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cus2dp") = 0
                End If

                If Trim(ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cus1dp").ToString) = "" Then
                    ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cus1dp") = 0
                End If

                If CDbl(ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cus2dp")) <> 0 Then
                    dblDp = CDbl(ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cus2dp"))
                Else
                    dblDp = CDbl(ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cus1dp"))
                End If

                For index As Integer = 0 To ma.rs_QUCPTBKD.Tables("RESULT").DefaultView.Count - 1
                    If ma.rs_QUCPTBKD.Tables("RESULT").DefaultView(index)("mode").ToString <> "NEW" And _
                        ma.rs_QUCPTBKD.Tables("RESULT").DefaultView(index)("mode").ToString <> "DEL" Then
                        ma.rs_QUCPTBKD.Tables("RESULT").DefaultView(index)("mode") = "UPD"
                    End If

                    If IsDBNull(ma.rs_QUCPTBKD.Tables("RESULT").DefaultView(index)("qcb_pct")) = True Then
                        ma.rs_QUCPTBKD.Tables("RESULT").DefaultView(index)("qcb_pct") = ma.rs_QUCPTBKD.Tables("RESULT").DefaultView(index)("qcb_cstpct")
                    End If

                    If CDbl(ma.rs_QUCPTBKD.Tables("RESULT").DefaultView(index)("qcb_pct")) = 0 Then
                        ma.rs_QUCPTBKD.Tables("RESULT").DefaultView(index)("qcb_pct") = ma.rs_QUCPTBKD.Tables("RESULT").DefaultView(index)("qcb_cstpct")
                    End If

                    ma.rs_QUCPTBKD.Tables("RESULT").DefaultView(index)("qcb_cst") = (dblDp * CDbl(ma.rs_QUCPTBKD.Tables("RESULT").DefaultView(index)("qcb_cstpct"))) / 100
                Next
            End If

            sFilter = ""
            ma.rs_QUCPTBKD.Tables("RESULT").DefaultView.RowFilter = sFilter
        End If
    End Sub

    Private Sub CalculateELCDuty(ByVal dblDuty As Double)
        If ma.rs_QUELCDTL.Tables.Count > 0 Then
            If ma.rs_QUELCDTL.Tables("RESULT").DefaultView.Count > 0 Then
                For index As Integer = 0 To ma.rs_QUELCDTL.Tables("RESULT").DefaultView.Count - 1
                    If ma.rs_QUELCDTL.Tables("RESULT").DefaultView(index)("ced_cedsc").ToString = "Duty" And _
                        ma.rs_QUELCDTL.Tables("RESULT").DefaultView(index)("mode").ToString <> "DEL" Then
                        ma.rs_QUELCDTL.Tables("RESULT").DefaultView(index)("qed_percent") = dblDuty

                        Call CalculateELC()
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub CalculateELCTran()
        Dim intMtr As Integer
        Dim dblTrans As Double
        Dim rs As New DataSet
        Dim dblFlgRat As Double
        Dim strCusno As String
        Dim strPrcTrm As String
        Dim decAjdPrc As Double

        If ma.rs_QUELCDTL.Tables.Count > 0 Then
            If ma.rs_QUELCDTL.Tables("RESULT").DefaultView.Count > 0 Then
                For index As Integer = 0 To ma.rs_QUELCDTL.Tables("RESULT").DefaultView.Count - 1
                    If Trim(ma.rs_QUELCDTL.Tables("RESULT").DefaultView(index)("ced_cedsc").ToString) = "Transportation" And _
                            ma.rs_QUELCDTL.Tables("RESULT").DefaultView(index)("mode").ToString <> "DEL" Then

                        '*** Get Frieght Rate From Customer
                        If Trim(txtDtlPrcTrm) <> "" Then
                            strPrcTrm = Microsoft.VisualBasic.Left(txtDtlPrcTrm, InStr(txtDtlPrcTrm, " - ") - 1)
                        Else
                            strPrcTrm = ""
                        End If

                        If Trim(cus2no) <> "" Then
                            strCusno = cus2no

                            'S = "㊣CUFLGRAT_qu※S※" & strCusno & "※" & strPrcTrm & "※" & gsUsrID
                            'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

                            Cursor = Cursors.WaitCursor

                            gsCompany = Trim(ma.cboCoCde.Text)
                            Call Update_gs_Value(gsCompany)

                            gspStr = "sp_select_CUFLGRAT_qu '" & ma.cboCoCde.Text & "','" & strCusno & "','" & strPrcTrm & "','" & gsUsrID & "'"
                            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                            gspStr = ""

                            Cursor = Cursors.Default

                            If rtnLong <> RC_SUCCESS Then
                                MsgBox("Error on loading CalculateELCTran sp_select_CUFLGRAT_qu 1 :" & rtnStr)
                                Exit Sub
                            End If

                            If rs.Tables("RESULT").Rows.Count = 0 Then
                                strCusno = cus1no
                            End If
                        Else
                            strCusno = cus1no
                        End If

                        If strCusno = cus1no Then
                            'S = "㊣CUFLGRAT_qu※S※" & strCusno & "※" & strPrcTrm & "※" & gsUsrID
                            'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

                            Cursor = Cursors.WaitCursor

                            gsCompany = Trim(ma.cboCoCde.Text)
                            Call Update_gs_Value(gsCompany)

                            gspStr = "sp_select_CUFLGRAT_qu '" & ma.cboCoCde.Text & "','" & strCusno & "','" & strPrcTrm & "','" & gsUsrID & "'"
                            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                            gspStr = ""

                            Cursor = Cursors.Default

                            If rtnLong <> RC_SUCCESS Then
                                MsgBox("Error on loading CalculateELCTran sp_select_CUFLGRAT_qu 2 :" & rtnStr)
                                Exit Sub
                            End If
                        End If

                        If rs.Tables("RESULT").Rows.Count > 0 Then
                            dblFlgRat = CDbl(IIf(IsDBNull(rs.Tables("RESULT").Rows(0)("cfr_flgrat")) = True, 0, rs.Tables("RESULT").Rows(0)("cfr_flgrat")))
                        Else
                            dblFlgRat = 0
                        End If

                        If Trim(ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_mtrqty").ToString) <> "" Then
                            intMtr = CInt(ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_mtrqty"))
                        Else
                            intMtr = 0
                        End If

                        If CDec(IIf(Trim(ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cus2dp")) = "", "0", ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cus2dp"))) <> 0 Then
                            decAjdPrc = CDec(IIf(Trim(ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cus2dp")) = "", "0", ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cus2dp")))
                        Else
                            decAjdPrc = CDec(IIf(Trim(ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cus1dp")) = "", "0", ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cus1dp")))
                        End If

                        If Trim(ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cft").ToString) = "" Then
                            ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cft") = "0"
                        End If

                        dblTrans = ((CDbl(IIf(ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cft") = 0, 0, ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(0)("qud_cft")))) / intMtr) * dblFlgRat

                        If decAjdPrc = 0 Then
                            ma.rs_QUELCDTL.Tables("RESULT").DefaultView(index)("qed_amt") = 0
                            ma.rs_QUELCDTL.Tables("RESULT").DefaultView(index)("qed_percent") = 0
                        Else
                            ma.rs_QUELCDTL.Tables("RESULT").DefaultView(index)("qed_amt") = dblTrans
                            ma.rs_QUELCDTL.Tables("RESULT").DefaultView(index)("qed_percent") = round((dblTrans / decAjdPrc) * 100, 2)
                            'ma.rs_QUELCDTL.Tables("RESULT").DefaultView(index)("qed_percent") = roundup((dblTrans / decAjdPrc) * 100)
                        End If

                        Call CalculateELC()
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub txtFm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFm.KeyPress
        If (InStr("0123456789", Chr(Asc(e.KeyChar))) = 0) And (e.KeyChar > Chr(31) Or e.KeyChar < Chr(0)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub txtTo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTo.KeyPress
        If (InStr("0123456789", Chr(Asc(e.KeyChar))) = 0) And (e.KeyChar > Chr(31) Or e.KeyChar < Chr(0)) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub dgResult_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgResult.CellClick
        Dim newitem As String
        Dim newcolor As String
        Dim newpck As String

        If rs_Result.Tables.Count = 0 Then Exit Sub
        If rs_Result.Tables("RESULT").DefaultView.Count <= 0 Then Exit Sub

        If e.RowIndex >= 0 And e.ColumnIndex = 0 Then
            dgResult.Columns(e.ColumnIndex).ReadOnly = False
            If dgResult.Columns(e.ColumnIndex).ReadOnly = False Then
                If rs_Result.Tables("RESULT").DefaultView(e.RowIndex)("UPD").ToString = "Y" Then
                    rs_Result.Tables("RESULT").DefaultView(e.RowIndex)("UPD") = "N"

                Else
                    rs_Result.Tables("RESULT").DefaultView(e.RowIndex)("UPD") = "Y"
                End If
                rs_Result.Tables("RESULT").AcceptChanges()
            End If
        End If


    End Sub

    Private Sub dropdownCombo(ByVal dgv As DataGridView, ByVal typ As String)
        Dim cboCell As New DataGridViewComboBoxCell
        Dim iCol As Integer = dgv.CurrentCell.ColumnIndex
        Dim iRow As Integer = dgv.CurrentCell.RowIndex

        Dim newitem As String
        Dim newcolor As String
        Dim newpck As String

        cboCell.Items.Clear()

        Select Case typ
            Case "Item"
                newitem = ""
                newcolor = ""
                newpck = ""

                sFilter = "qud_itmno = '" & CellClickOldItem & "' and qud_qutseq = " & CellClickQutSeq
                rs_List.Tables("RESULT").DefaultView.RowFilter = sFilter

                If rs_List.Tables("RESULT").DefaultView.Count > 0 Then
                    For index As Integer = 0 To rs_List.Tables("RESULT").DefaultView.Count - 1
                        If Not (newitem = rs_List.Tables("RESULT").DefaultView(index)("vw_itmno").ToString And _
                                newcolor = rs_List.Tables("RESULT").DefaultView(index)("vw_colcde").ToString And _
                                newpck = rs_List.Tables("RESULT").DefaultView(index)("vw_pckunt").ToString) Then
                            cboCell.Items.Add(rs_List.Tables("RESULT").DefaultView(index)("vw_itmno").ToString & _
                                                " - " & rs_List.Tables("RESULT").DefaultView(index)("vw_colcde").ToString)
                            newitem = Trim(rs_List.Tables("RESULT").DefaultView(index)("vw_itmno").ToString)
                            newcolor = Trim(rs_List.Tables("RESULT").DefaultView(index)("vw_colcde").ToString)
                            newpck = Trim(rs_List.Tables("RESULT").DefaultView(index)("vw_pckunt").ToString)
                        End If
                    Next
                End If
                sFilter = ""
                rs_List.Tables("RESULT").DefaultView.RowFilter = sFilter
        End Select

        cboCell.DropDownWidth = 300
        cboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox

        dgv.Rows(iRow).Cells(iCol) = cboCell
        dgv.Rows(iRow).Cells(iCol).ReadOnly = False
    End Sub

    Private Sub textboxCombo(ByVal dgv As DataGridView, ByVal typ As String)
        Dim txtCell As New DataGridViewTextBoxCell
        Dim iCol As Integer = CellClickRow
        Dim iRow As Integer = CellClickCol

        Select Case typ
            Case "Item"
                Dim strTemp As String
                Dim strChkItmno As String
                Dim strChkColcde As String
                Dim strChkPck As String
                Dim strQutSeq As String

                strTemp = dgv.Rows(iRow).Cells(iCol).Value

                If InStr(strTemp, "-") > 0 Then
                    If rs_List.Tables.Count > 0 Then
                        If rs_List.Tables("RESULT").DefaultView.Count > 0 Then
                            sFilter = "qud_itmno='" & dgv.Rows(iRow).Cells("qud_itmno").Value & "' and " & _
                                         "vw_itmno='" & Trim(Split(strTemp, " - ")(0)) & "' and " & _
                                         "vw_colcde='" & Trim(Split(strTemp, " - ")(1)) & "'"
                            rs_List.Tables("RESULT").DefaultView.RowFilter = sFilter

                            If rs_List.Tables("RESULT").DefaultView.Count > 0 Then
                                dgv.Rows(iRow).Cells("vw_pckunt").Value = ""

                                dgv.Rows(iRow).Cells("vw_alsitmno").Value = rs_List.Tables("RESULT").DefaultView(0)("ibi_alsitmno")
                                dgv.Rows(iRow).Cells("vw_alscolcde").Value = rs_List.Tables("RESULT").DefaultView(0)("ibi_alscolcde")

                                strChkItmno = Trim(Split(strTemp, " - ")(0))
                                strChkColcde = Trim(Split(strTemp, " - ")(1))
                                strChkPck = Trim(Split(strTemp, " - ")(2))
                                strQutSeq = dgv.Rows(iRow).Cells("qud_qutseq").Value

                                For index As Integer = 0 To rs_List.Tables("RESULT").DefaultView.Count - 1
                                    If rs_List.Tables("RESULT").DefaultView(index)("vw_pckunt") = dgv.Rows(iRow).Cells("qud_untcde").Value Then
                                        If rs_Result.Tables("RESULT").DefaultView.Count > 0 Then
                                            For index1 As Integer = 0 To rs_Result.Tables("RESULT").DefaultView.Count - 1
                                                If rs_Result.Tables("RESULT").DefaultView(index1)("qud_qutseq").ToString <> strQutSeq And _
                                                    rs_Result.Tables("RESULT").DefaultView(index1)("vw_itmno").ToString = strChkItmno And _
                                                    rs_Result.Tables("RESULT").DefaultView(index1)("vw_colcde").ToString = strChkColcde And _
                                                    rs_Result.Tables("RESULT").DefaultView(index1)("vw_pckunt").ToString = strChkPck Then
                                                    MsgBox("Duplicated Item, Color & Packing!", vbCritical, "Invalid Input")
                                                    Exit Sub
                                                End If
                                                If rs_Result.Tables("RESULT").DefaultView(index1)("qud_qutseq").ToString <> strQutSeq And _
                                                    rs_Result.Tables("RESULT").DefaultView(index1)("qud_itmno").ToString = strChkItmno And _
                                                    rs_Result.Tables("RESULT").DefaultView(index1)("qud_colcde").ToString = strChkColcde And _
                                                    rs_Result.Tables("RESULT").DefaultView(index1)("qud_pckunt").ToString = strChkPck Then
                                                    MsgBox("Duplicated Item, Color & Packing", vbCritical, "Invalid Input")
                                                    Exit Sub
                                                End If
                                            Next
                                        End If

                                        dgv.Rows(iRow).Cells("vw_pckunt").Value = rs_List.Tables("RESULT").DefaultView(index)("vw_pckunt")
                                        dgv.Rows(iRow).Cells("vw_basprc").Value = rs_List.Tables("RESULT").DefaultView(index)("vw_basprc")
                                        dgv.Rows(iRow).Cells("vw_ftytmpitm").Value = rs_List.Tables("RESULT").DefaultView(index)("vw_ftytmpitm")
                                        dgv.Rows(iRow).Cells("vw_engdsc").Value = rs_List.Tables("RESULT").DefaultView(index)("Remarks")
                                    End If
                                Next
                            End If
                            sFilter = ""
                            rs_List.Tables("RESULT").DefaultView.RowFilter = sFilter
                        End If
                    End If

                    dgv.Rows(iRow).Cells("vw_itmno").Value = Trim(Split(strTemp, " - ")(0))
                    dgv.Rows(iRow).Cells("vw_colcde").Value = Trim(Split(strTemp, " - ")(1))

                    If dgv.Rows(iRow).Cells("vw_pckunt").Value = "" Then
                        MsgBox("No Packing " & dgv.Rows(iRow).Cells("qud_untcde").Value & " available for this item!")
                    End If
                    bolRecordstatus = True
                End If
        End Select

        dgv.Rows(iRow).Cells(iCol) = txtCell
        dgv.Refresh()
        dgv.Rows(iRow).Cells(iCol).ReadOnly = False
        If dgResult.Visible = True And dgResult.Enabled = True Then dgResult.Focus()
    End Sub

    Private Sub dgResult_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgResult.CellEndEdit
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 11 Then
                textboxCombo(dgResult, "Item")
            End If
        End If
    End Sub

    Private Sub dgResult_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgResult.DataError
        'Catch DataGridViewComboBoxCell error
    End Sub













    Private Sub dgResult_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgResult.CellContentClick

    End Sub
End Class