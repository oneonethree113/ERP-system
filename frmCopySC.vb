Public Class frmCopySC

    Public myOwner As SCM00001

    Public rs_SCORDDTL_Copy As DataSet
    Public rs_SCORDDTL_Fail As DataSet
    Public rs_SCASSINF_Copy As DataSet
    Public rs_SCBOMINF_Copy As DataSet
    Public rs_CUITMSUM As DataSet
    Public rs_SCASSINF_old As DataSet

    Public PriCust As String
    Public SecCust As String
    Public CuFml As String
    Public totalR As Integer
    Public strCurExRat As String
    Public strCurExEffDat As String
    Public strNewCocde As String
    Public strOldCocde As String

    Public rs_SCVENMRK_DV As DataSet
    Public strDVTtlCst As String
    Public strDVItmCst As String
    Public strDVBOMCst As String
    Public strDVftyunt As String
    Public strDV As String
    Public strVenType As String
    Public strDVfcurcde As String

    Dim rs_CUBASINF_P As DataSet
    Dim rsIMBOMASS As DataSet
    Dim rsIMBOMINF As DataSet
    Dim rs_IMCUSVEN As DataSet

    Dim dr_PriCust_Info() As DataRow

    Dim Dtl_seq As Integer

    Private Sub frmCopySC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        totalR = rs_SCORDDTL_Copy.Tables("RESULT").Rows.Count
        pBar.Maximum = totalR
        lblCount.Text = "0 of " & totalR
        lblFail.Text = "0 of " & totalR
        pBar.Value = 0
        cmdCopy.Enabled = False
        strCurExRat = "0"
        strCurExEffDat = ""
        strNewCocde = myOwner.CopySC_Cust_SUB.cboCoCde.Text
        strOldCocde = myOwner.cboCoCde.Text
        LoadTimer.Enabled = True
        LoadTimer.Start()
    End Sub

    Private Sub cmdCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCopy.Click
        clear_More()
        rs_SCORDDTL_Copy.AcceptChanges()
        myOwner.rs_SCORDDTL = rs_SCORDDTL_Copy.Copy()
        rs_SCASSINF_Copy.AcceptChanges()
        myOwner.rs_SCASSINF = rs_SCASSINF_Copy.Copy()
        rs_SCBOMINF_Copy.AcceptChanges()
        myOwner.rs_SCBOMINF = rs_SCBOMINF_Copy.Copy()
        myOwner.copyFlag = True
        myOwner.MaxSeq = Dtl_seq
        Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Close()
    End Sub

    Private Sub LoadTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadTimer.Tick
        LoadTimer.Stop()
        LoadTimer.Enabled = False
        SC_Check()
    End Sub

    Public Sub SC_Check()
        Dim rs As New DataSet
        'Dim i, j As Integer
        Dim Success As Integer
        Dim Fail As Integer
        Dim sCUITMSUM As String
        Dim ssql As String
        Success = 0
        Fail = 0
        Dtl_seq = 1

        Dim old_dtlseq As Integer

        gspStr = "sp_select_SCASSINF '" & strNewCocde & "','" & rs_SCORDDTL_Copy.Tables("RESULT").Rows(0)("sod_ordno").ToString & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SCASSINF_old, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading frmCopySC #001 sp_select_SCASSINF : " & rtnStr)
            Exit Sub
        End If

        ASS_Check(0, "DEL", 0)

        ' Added by Mark Lau 20090518
        GetPriCustInfo()

        ' Added by Mark Lau 20091014
        gsCompany = strNewCocde
        Update_gs_Value(gsCompany)

        'grdInvalid.DataSource = rs_SCORDDTL_Fail.Tables("RESULT").DefaultView
        'grdValid.DataSource = rs_SCORDDTL_Copy.Tables("RESULT").DefaultView
        'Display_Summary()
        'Display_Invalid()

        Dim newRow As DataRow

        For i As Integer = 0 To rs_SCORDDTL_Copy.Tables("RESULT").Rows.Count - 1
            old_dtlseq = rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_ordseq")
            rs_CUITMSUM = Nothing

            gspStr = "sp_select_CUITMSUM_SCCopy2 '" & strNewCocde & "','" & rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_itmno").ToString & _
                     "','" & SecCust & "','" & PriCust & "','" & rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_pckunt").ToString & "','" & _
                     rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_colcde").ToString & "','" & _
                     rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_inrctn").ToString & "','" & _
                     rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_mtrctn").ToString & "','" & _
                     IIf(rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_conftr").ToString = "", 1, rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_conftr").ToString) & "'"

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            rtnLong = execute_SQLStatement(gspStr, rs_CUITMSUM, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading frmCopySC #003 sp_select_CUITMSUM_SCCopy2 : " & rtnStr)
                Me.Cursor = Windows.Forms.Cursors.Default
                Exit Sub
            End If

            newRow = Nothing

            If rs_CUITMSUM.Tables("RESULT").Rows.Count = 0 Then
                newRow = rs_SCORDDTL_Fail.Tables("RESULT").NewRow

                For j As Integer = 0 To rs_SCORDDTL_Copy.Tables("RESULT").Columns.Count - 1
                    newRow.Item(j) = IIf(IsDBNull(rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)(j)), "", rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)(j))
                Next
                newRow.Item("sod_coldsc") = "Record Not Exist in CIH"
                rs_SCORDDTL_Fail.Tables("RESULT").Rows.Add(newRow)
                rs_SCORDDTL_Fail.AcceptChanges()
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i).Delete()
                Fail = Fail + 1
                lblFail.Text = Fail & " of " & totalR
                lblFail.Refresh()
            ElseIf rs_CUITMSUM.Tables("RESULT").Rows(0)("ibi_itmsts").ToString = "N/A" Then
                newRow = rs_SCORDDTL_Fail.Tables("RESULT").NewRow

                For j As Integer = 0 To rs_SCORDDTL_Copy.Tables("RESULT").Columns.Count - 1
                    newRow.Item(j) = IIf(IsDBNull(rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)(j)), "", rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)(j))
                Next
                newRow.Item("sod_coldsc") = "Item in History or not in Item Master"
                rs_SCORDDTL_Fail.Tables("RESULT").Rows.Add(newRow)
                rs_SCORDDTL_Fail.AcceptChanges()
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i).Delete()
                Fail = Fail + 1
                lblFail.Text = Fail & " of " & totalR
                lblFail.Refresh()
            ElseIf rs_CUITMSUM.Tables("RESULT").Rows(0)("ibi_itmsts").ToString.Substring(0, 3) = "OLD" Then
                newRow = rs_SCORDDTL_Fail.Tables("RESULT").NewRow

                For j As Integer = 0 To rs_SCORDDTL_Copy.Tables("RESULT").Columns.Count - 1
                    newRow.Item(j) = IIf(IsDBNull(rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)(j)), "", rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)(j))
                Next
                newRow.Item("sod_coldsc") = "Old Item Status"
                rs_SCORDDTL_Fail.Tables("RESULT").Rows.Add(newRow)
                rs_SCORDDTL_Fail.AcceptChanges()
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i).Delete()
                Fail = Fail + 1
                lblFail.Text = Fail & " of " & totalR
                lblFail.Refresh()
            ElseIf rs_CUITMSUM.Tables("RESULT").Rows(0)("imu_bcurcde").ToString = "N/A" And rs_CUITMSUM.Tables("RESULT").Rows(0)("icf_colcde").ToString = "@#" Then
                newRow = rs_SCORDDTL_Fail.Tables("RESULT").NewRow

                For j As Integer = 0 To rs_SCORDDTL_Copy.Tables("RESULT").Columns.Count - 1
                    newRow.Item(j) = IIf(IsDBNull(rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)(j)), "", rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)(j))
                Next
                newRow.Item("sod_coldsc") = "Packing/Color not in Item Master"
                rs_SCORDDTL_Fail.Tables("RESULT").Rows.Add(newRow)
                rs_SCORDDTL_Fail.AcceptChanges()
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i).Delete()
                Fail = Fail + 1
                lblFail.Text = Fail & " of " & totalR
                lblFail.Refresh()
            ElseIf rs_CUITMSUM.Tables("RESULT").Rows(0)("imu_bcurcde").ToString = "N/A" Then
                newRow = rs_SCORDDTL_Fail.Tables("RESULT").NewRow

                For j As Integer = 0 To rs_SCORDDTL_Copy.Tables("RESULT").Columns.Count - 1
                    newRow.Item(j) = IIf(IsDBNull(rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)(j)), "", rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)(j))
                Next
                newRow.Item("sod_coldsc") = "Packing not in Item Master"
                rs_SCORDDTL_Fail.Tables("RESULT").Rows.Add(newRow)
                rs_SCORDDTL_Fail.AcceptChanges()
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i).Delete()
                Fail = Fail + 1
                lblFail.Text = Fail & " of " & totalR
                lblFail.Refresh()
            ElseIf rs_CUITMSUM.Tables("RESULT").Rows(0)("icf_colcde").ToString = "@#" Then
                newRow = rs_SCORDDTL_Fail.Tables("RESULT").NewRow

                For j As Integer = 0 To rs_SCORDDTL_Copy.Tables("RESULT").Columns.Count - 1
                    newRow.Item(j) = IIf(IsDBNull(rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)(j)), "", rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)(j))
                Next
                newRow.Item("sod_coldsc") = "Color not in Item Master"
                rs_SCORDDTL_Fail.Tables("RESULT").Rows.Add(newRow)
                rs_SCORDDTL_Fail.AcceptChanges()
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i).Delete()
                Fail = Fail + 1
                lblFail.Text = Fail & " of " & totalR
                lblFail.Refresh()
            ElseIf (rs_CUITMSUM.Tables("RESULT").Rows(0)("ibi_itmsts").ToString <> "CMP - Active Item with complete Info." _
                    And rs_CUITMSUM.Tables("RESULT").Rows(0)("ibi_itmsts").ToString <> "INC - Active Item with incomplete Info.") Then
                newRow = rs_SCORDDTL_Fail.Tables("RESULT").NewRow

                For j As Integer = 0 To rs_SCORDDTL_Copy.Tables("RESULT").Columns.Count - 1
                    newRow.Item(j) = IIf(IsDBNull(rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)(j)), "", rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)(j))
                Next
                newRow.Item("sod_coldsc") = "Item not in Active Status"
                rs_SCORDDTL_Fail.Tables("RESULT").Rows.Add(newRow)
                rs_SCORDDTL_Fail.AcceptChanges()
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i).Delete()
                Fail = Fail + 1
                lblFail.Text = Fail & " of " & totalR
                lblFail.Refresh()
            ElseIf rs_CUITMSUM.Tables("RESULT").Rows(0)("vbi_vensts").ToString <> "A" Then
                newRow = rs_SCORDDTL_Fail.Tables("RESULT").NewRow

                For j As Integer = 0 To rs_SCORDDTL_Copy.Tables("RESULT").Columns.Count - 1
                    newRow.Item(j) = IIf(IsDBNull(rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)(j)), "", rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)(j))
                Next
                newRow.Item("sod_coldsc") = "Default Vendor not in Active status"
                rs_SCORDDTL_Fail.Tables("RESULT").Rows.Add(newRow)
                rs_SCORDDTL_Fail.AcceptChanges()
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i).Delete()
                Fail = Fail + 1
                lblFail.Text = Fail & " of " & totalR
                lblFail.Refresh()
            ElseIf rs_CUITMSUM.Tables("RESULT").Rows(0)("imu_status").ToString <> "ACT" Then
                newRow = rs_SCORDDTL_Fail.Tables("RESULT").NewRow

                For j As Integer = 0 To rs_SCORDDTL_Copy.Tables("RESULT").Columns.Count - 1
                    newRow.Item(j) = IIf(IsDBNull(rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)(j)), "", rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)(j))
                Next
                newRow.Item("sod_coldsc") = "Item Pricing not ACT status"
                rs_SCORDDTL_Fail.Tables("RESULT").Rows.Add(newRow)
                rs_SCORDDTL_Fail.AcceptChanges()
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i).Delete()
                Fail = Fail + 1
                lblFail.Text = Fail & " of " & totalR
                lblFail.Refresh()

            Else
                For j As Integer = 0 To rs_SCORDDTL_Copy.Tables("RESULT").Columns.Count - 1
                    rs_SCORDDTL_Copy.Tables("RESULT").Columns(j).ReadOnly = False
                Next

                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_ordseq") = Dtl_seq
                '*********Copy From IM*****************

                'Frankie Cheung 20110718 Correct cannot copy of ASSD item if detail seq in linar.
                If rs_CUITMSUM.Tables("RESULT").Rows(0)("ibi_typ").ToString = "ASS" Then
                    CheckASS(Dtl_seq, old_dtlseq, rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_itmno"))
                End If
                CheckBOM(Dtl_seq, rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_itmno"))


                ' Changed by Mark Lau 20090518
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_itmprc") = SalRate(dr_PriCust_Info(0).Item("cpi_curcde"), rs_CUITMSUM.Tables("RESULT").Rows(0)("imu_bcurcde"), rs_CUITMSUM.Tables("RESULT").Rows(0)("imu_basprc"), "IM")

                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("ibi_itmsts") = rs_CUITMSUM.Tables("RESULT").Rows(0)("ibi_itmsts")

                ' **** Anita Request to update CFT from Item Master at 24/02/2002 ****
                If rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_cft") <> rs_CUITMSUM.Tables("RESULT").Rows(0)("imu_cft") Then
                    rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_cft") = Format(rs_CUITMSUM.Tables("RESULT").Rows(0)("imu_cft"), "#0.0000")
                End If
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_ftyprc") = Format(rs_CUITMSUM.Tables("RESULT").Rows(0)("imu_ftyprc"), "#0.0000")
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_ftycst") = Format(rs_CUITMSUM.Tables("RESULT").Rows(0)("imu_ftycst"), "#0.0000")
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_orgfty") = Format(rs_CUITMSUM.Tables("RESULT").Rows(0)("imu_ftyprc"), "#0.0000")
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_bomcst") = Format(rs_CUITMSUM.Tables("RESULT").Rows(0)("imu_bomcst"), "#0.0000")

                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_subcde") = rs_CUITMSUM.Tables("RESULT").Rows(0)("ivi_subcde")
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_venno") = rs_CUITMSUM.Tables("RESULT").Rows(0)("ivi_venno")
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_vensna") = rs_CUITMSUM.Tables("RESULT").Rows(0)("ivi_vensna")

                '*********No Need to Copy**************
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("pod_purord") = ""
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("pod_jobord") = ""
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_cuspo") = ""
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_runno") = ""
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_resppo") = ""
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_clmno") = ""
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_shpqty") = 0
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_oneprc") = "N"
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_apprve") = "N"
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_updpo") = "Y"
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_ctnstr") = 0
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_ctnend") = 0
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_purord") = ""
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_oldpurord") = ""
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_pjobno") = ""
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_purseq") = 0
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_invqty") = 0
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_discnt") = 0
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_shpstr") = Format(Date.Now, "MM/dd/yyyy")
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_shpend") = Format(Date.Now, "MM/dd/yyyy")
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_candat") = Format(Date.Now, "MM/dd/yyyy")

                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_zorvbeln") = ""
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_zorposnr") = ""



                '********Copy from CIH*****************
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_qutno") = rs_CUITMSUM.Tables("RESULT").Rows(0)("cis_refdoc")
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_refdat") = Format(rs_CUITMSUM.Tables("RESULT").Rows(0)("cis_docdat"), "MM/dd/yyyy")
                ' Changed by Mark Lau 20090518
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_untprc") = SalRate(dr_PriCust_Info(0).Item("cpi_curcde"), rs_CUITMSUM.Tables("RESULT").Rows(0)("cis_curcde"), rs_CUITMSUM.Tables("RESULT").Rows(0)("cis_selprc"), "SC")

                ' Added by Mark Lau 20090518
                If IsSamePriCust() = True Then
                    rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_untprc") = Cal_DtlPrc(rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_untprc"), rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_discnt"), rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_ordqty"), "UNT")
                    rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_selprc") = Cal_DtlPrc(rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_untprc"), rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_discnt"), rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_ordqty"), "TTL")
                Else
                    rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_untprc") = Cal_DtlPrc(rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_untprc"), 0, rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_ordqty"), "UNT")
                    rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_selprc") = Cal_DtlPrc(rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_untprc"), 0, rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_ordqty"), "TTL")
                End If

                'Added by Mark Lau 20070623
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_contopc") = rs_CUITMSUM.Tables("RESULT").Rows(0)("cis_contopc")
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_pcprc") = rs_CUITMSUM.Tables("RESULT").Rows(0)("cis_pcprc")

                'Added by Mark Lau 20080826
                '----------------------------------------
                LoadDVTtlCst(rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_itmno"), rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_pckunt"), rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_inrctn"), rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_mtrctn"), strVenType, True, i)


                If strDV <> "" Then
                    rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_dv") = Trim(Split(strDV, "-")(0))
                Else
                    rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_dv") = ""
                End If

                LoadDVTtlCst(rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_itmno"), rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_pckunt"), rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_inrctn"), rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_mtrctn"), strVenType, True, i)

                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_dvftycst") = IIf(strDVItmCst = "", 0, strDVItmCst)
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_dvftyprc") = IIf(strDVTtlCst = "", 0, strDVTtlCst)
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_dvbomcst") = IIf(strDVBOMCst = "", 0, strDVBOMCst)

                If strDVfcurcde <> "" Then
                    rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_dvfcurcde") = strDVfcurcde
                Else
                    rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_dvfcurcde") = ""
                End If

                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_dvftyunt") = strDVftyunt


                '---------------------------------------------------------------------
                'Frankie Cheung 20110228 Add CIH Period
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_qutdat") = rs_CUITMSUM.Tables("RESULT").Rows(0)("cis_qutdat")


                '----------------------------------------

                ' Added by Mark Lau 2008-11-07
                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_cusstyno") = GetCusSty(rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_itmno"), PriCust)

                If rs_CUITMSUM.Tables("RESULT").Rows(0)("cis_cusstyno").ToString <> "" Then
                    rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_cusstyno") = rs_CUITMSUM.Tables("RESULT").Rows(0)("cis_cusstyno")
                End If

                rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_creusr") = "~*ADD*~"


                ' Record Custom Vendor'

                gspStr = "sp_select_IMCUSVEN '" & strNewCocde & "','" & rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_itmno") & "'"
                rs_IMCUSVEN = Nothing
                rtnLong = execute_SQLStatement(gspStr, rs_IMCUSVEN, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    Me.Cursor = Windows.Forms.Cursors.Default
                    MsgBox("Error on loading frmCopySC #006 sp_select_IMCUSVEN : " & rtnStr)
                    Exit Sub
                End If

                If rs_IMCUSVEN.Tables("RESULT").Rows.Count > 0 Then
                    rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_cusven") = rs_IMCUSVEN.Tables("RESULT").Rows(0)("default_venno")
                Else
                    rs_SCORDDTL_Copy.Tables("RESULT").Rows(i)("sod_cusven") = ""
                End If

                For j As Integer = 0 To rs_SCORDDTL_Copy.Tables("RESULT").Columns.Count - 1
                    rs_SCORDDTL_Copy.Tables("RESULT").Columns(j).ReadOnly = True
                Next

                Success = Success + 1
                lblCount.Text = Success & " of " & totalR
                lblCount.Refresh()
                Dtl_seq = Dtl_seq + 1
            End If
            pBar.Value = pBar.Value + 1
            pBar.Refresh()

        Next
        Me.Cursor = Windows.Forms.Cursors.Default
        rs_SCORDDTL_Copy.AcceptChanges()
        grdInvalid.DataSource = rs_SCORDDTL_Fail.Tables("RESULT").DefaultView
        grdValid.DataSource = rs_SCORDDTL_Copy.Tables("RESULT").DefaultView
        Display_Summary()
        Display_Invalid()
        If Success > 0 Then
            cmdCopy.Enabled = True
        End If

        gsCompany = strOldCocde
        Update_gs_Value(gsCompany)
    End Sub

    Private Sub ASS_Check(ByVal ordseq As Integer, ByVal Act As String, ByVal oldordseq As Integer, Optional ByVal itmno As String = "")

        Select Case Act

            '*************Add Assort to RS*********************
            Case "ADD"
                Dim dr() As DataRow = rs_SCASSINF_Copy.Tables("RESULT").Select("sai_ordseq = " & "'" & ordseq & "'")
                If dr.Length = 0 Then
                    Dim dr_old() As DataRow
                    Dim newRow As DataRow
                    For k As Integer = 0 To rsIMBOMASS.Tables("RESULT").Rows.Count - 1
                        newRow = Nothing
                        newRow = rs_SCASSINF_Copy.Tables("RESULT").NewRow

                        newRow.Item("sai_ordseq") = ordseq
                        newRow.Item("sai_itmno") = itmno
                        newRow.Item("sai_assitm") = rsIMBOMASS.Tables("RESULT").Rows(k)("iba_assitm")
                        newRow.Item("sai_colcde") = rsIMBOMASS.Tables("RESULT").Rows(k)("iba_colcde")
                        newRow.Item("sai_untcde") = rsIMBOMASS.Tables("RESULT").Rows(k)("iba_pckunt")
                        newRow.Item("sai_inrqty") = rsIMBOMASS.Tables("RESULT").Rows(k)("iba_inrqty")
                        newRow.Item("sai_mtrqty") = rsIMBOMASS.Tables("RESULT").Rows(k)("iba_mtrqty")

                        dr_old = Nothing
                        dr_old = rs_SCASSINF_old.Tables("RESULT").Select("sai_ordseq = " & "'" & oldordseq & "' and " & _
                                                "sai_itmno = '" & itmno & "' and " & _
                                                "sai_assitm = '" & rsIMBOMASS.Tables("RESULT").Rows(k)("iba_assitm") & "' and " & _
                                                "sai_colcde = '" & rsIMBOMASS.Tables("RESULT").Rows(k)("iba_colcde") & "' and " & _
                                                "sai_untcde = '" & rsIMBOMASS.Tables("RESULT").Rows(k)("iba_pckunt") & "' and " & _
                                                "sai_inrqty = '" & rsIMBOMASS.Tables("RESULT").Rows(k)("iba_inrqty") & "' and " & _
                                                "sai_mtrqty = '" & rsIMBOMASS.Tables("RESULT").Rows(k)("iba_mtrqty") & "'")
                        If dr_old.Length > 0 Then
                            newRow.Item("sai_coldsc") = dr_old(0).Item("sai_coldsc")
                            newRow.Item("sai_assdsc") = dr_old(0).Item("sai_assdsc")
                            newRow.Item("sai_cusrtl") = dr_old(0).Item("sai_cusrtl")
                            newRow.Item("sai_cusitm") = dr_old(0).Item("sai_cusitm")
                            newRow.Item("sai_cussku") = dr_old(0).Item("sai_cussku")
                            newRow.Item("sai_upcean") = dr_old(0).Item("sai_upcean")
                            newRow.Item("sai_imperiod") = dr_old(0).Item("sai_imperiod")
                        Else
                            newRow.Item("sai_coldsc") = rsIMBOMASS.Tables("RESULT").Rows(k)("icf_coldsc")
                            newRow.Item("sai_assdsc") = rsIMBOMASS.Tables("RESULT").Rows(k)("ibi_engdsc")
                            newRow.Item("sai_cusrtl") = 0
                            newRow.Item("sai_cusitm") = ""
                            newRow.Item("sai_cussku") = ""
                            newRow.Item("sai_upcean") = ""
                            newRow.Item("sai_imperiod") = ""
                        End If

                        newRow.Item("sai_creusr") = "~*ADD*~"
                        rs_SCASSINF_Copy.Tables("RESULT").Rows.Add(newRow)
                        rs_SCASSINF_Copy.AcceptChanges()
                    Next
                Else
                    MsgBox("This Record already existed!", MsgBoxStyle.Information, "Message")
                End If

                '*************Del Assort to RS*********************
            Case "DEL"
                If rs_SCASSINF_Copy.Tables("RESULT").Rows.Count > 0 Then
                    For i As Integer = 0 To rs_SCASSINF_Copy.Tables("RESULT").Rows.Count - 1
                        rs_SCASSINF_Copy.Tables("RESULT").Rows(0).Delete()
                    Next
                    rs_SCASSINF_Copy.AcceptChanges()
                End If
        End Select

    End Sub

    Private Sub GetPriCustInfo()
        ' Added by Mark Lau 20090518
        ' This sub-routine is to get the information of the primary customer
        gspStr = "sp_select_CUBASINF_P '" & strNewCocde & "','Primary'"

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_P, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> RC_SUCCESS Then  '*** An error has occured
            MsgBox("Error on loading frmCopySC #002 sp_select_CUBASINF_P : " & rtnStr)
        Else
            If rs_CUBASINF_P.Tables("RESULT").Rows.Count > 0 Then
                dr_PriCust_Info = rs_CUBASINF_P.Tables("RESULT").Select("cbi_cusno = " & "'" & PriCust & "'")
            End If
        End If
    End Sub

    Private Sub CheckASS(ByVal seq As Integer, ByVal oldseq As Integer, ByVal itmno As String)
        gspStr = "sp_select_IMBOMASS_SC '" & strNewCocde & "','" & itmno & "'"
        rsIMBOMASS = Nothing
        rtnLong = execute_SQLStatement(gspStr, rsIMBOMASS, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Error on loading frmCopySC #004 sp_select_IMBOMASS_SC : " & rtnStr)
            Exit Sub
        Else
            If rsIMBOMASS.Tables("RESULT").Rows.Count > 0 Then
                ASS_Check(seq, "ADD", oldseq, itmno)
            End If
        End If
    End Sub
    Private Sub CheckBOM(ByVal seq As Integer, ByVal itmno As String)
        gspStr = "sp_select_IMBOM_SC '" & strNewCocde & "','" & itmno & "'"
        rsIMBOMINF = Nothing
        rtnLong = execute_SQLStatement(gspStr, rsIMBOMINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Error on loading frmCopySC #005 sp_select_IMBOM_SC : " & rtnStr)
            Exit Sub
        Else
            If rsIMBOMINF.Tables("RESULT").Rows.Count > 0 Then
                BOM_Check(seq, "ADD", itmno)
            End If
        End If
    End Sub

    Private Sub BOM_Check(ByVal ordseq As Integer, ByVal Act As String, Optional ByVal itmno As String = "")

        Select Case Act

            '*************Add Assort to RS*********************
            Case "ADD"
                Dim dr() As DataRow = rs_SCBOMINF_Copy.Tables("RESULT").Select("sbi_ordseq = " & "'" & ordseq & "'")
                If dr.Length = 0 Then
                    Dim newRow As DataRow
                    For k As Integer = 0 To rsIMBOMINF.Tables("RESULT").Rows.Count - 1
                        newRow = rs_SCBOMINF_Copy.Tables("RESULT").NewRow

                        newRow.Item("sbi_ordseq") = ordseq
                        newRow.Item("sbi_itmno") = itmno
                        newRow.Item("sbi_assitm") = rsIMBOMINF.Tables("RESULT").Rows(k)("sbi_assitm")
                        newRow.Item("sbi_assinrqty") = rsIMBOMINF.Tables("RESULT").Rows(k)("sbi_assinrqty")
                        newRow.Item("sbi_assmtrqty") = rsIMBOMINF.Tables("RESULT").Rows(k)("sbi_assmtrqty")
                        newRow.Item("sbi_bomitm") = rsIMBOMINF.Tables("RESULT").Rows(k)("sbi_bomitm")
                        newRow.Item("sbi_venno") = rsIMBOMINF.Tables("RESULT").Rows(k)("sbi_venno")
                        newRow.Item("sbi_bomdsce") = rsIMBOMINF.Tables("RESULT").Rows(k)("sbi_bomdsce")
                        newRow.Item("sbi_bomdscc") = rsIMBOMINF.Tables("RESULT").Rows(k)("sbi_bomdscc")
                        newRow.Item("sbi_colcde") = rsIMBOMINF.Tables("RESULT").Rows(k)("sbi_colcde")
                        newRow.Item("sbi_coldsc") = rsIMBOMINF.Tables("RESULT").Rows(k)("sbi_coldsc")
                        newRow.Item("sbi_pckunt") = rsIMBOMINF.Tables("RESULT").Rows(k)("sbi_pckunt")
                        newRow.Item("sbi_ordqty") = rsIMBOMINF.Tables("RESULT").Rows(k)("sbi_ordqty")
                        newRow.Item("sbi_fcurcde") = rsIMBOMINF.Tables("RESULT").Rows(k)("sbi_fcurcde")
                        newRow.Item("sbi_ftyprc") = rsIMBOMINF.Tables("RESULT").Rows(k)("sbi_ftyprc")
                        newRow.Item("sbi_bcurcde") = rsIMBOMINF.Tables("RESULT").Rows(k)("sbi_bcurcde")
                        newRow.Item("sbi_bomcst") = rsIMBOMINF.Tables("RESULT").Rows(k)("sbi_bomcst")
                        newRow.Item("sbi_obcurcde") = rsIMBOMINF.Tables("RESULT").Rows(k)("sbi_obcurcde")
                        newRow.Item("sbi_obomcst") = rsIMBOMINF.Tables("RESULT").Rows(k)("sbi_obomcst")
                        newRow.Item("sbi_obomprc") = rsIMBOMINF.Tables("RESULT").Rows(k)("sbi_obomprc")
                        newRow.Item("sbi_creusr") = "~*ADD*~"
                        newRow.Item("sbi_bompoflg") = rsIMBOMINF.Tables("RESULT").Rows(k)("sbi_bompoflg")
                        newRow.Item("sbi_imperiod") = rsIMBOMINF.Tables("RESULT").Rows(k)("sbi_imperiod")

                        rs_SCBOMINF_Copy.Tables("RESULT").Rows.Add(newRow)
                        rs_SCBOMINF_Copy.AcceptChanges()
                    Next
                Else
                    MsgBox("This Record already existed!", MsgBoxStyle.Information, "Message")
                End If

                '*************Del Assort to RS*********************
            Case "DEL"
                If rs_SCBOMINF_Copy.Tables("RESULT").Rows.Count > 0 Then
                    For i As Integer = 0 To rs_SCBOMINF_Copy.Tables("RESULT").Rows.Count - 1
                        rs_SCBOMINF_Copy.Tables("RESULT").Rows(i).Delete()
                    Next
                    rs_SCBOMINF_Copy.AcceptChanges()
                End If
        End Select

    End Sub

    Private Function SalRate(ByVal Custcurcde As String, ByVal CurCde As String, ByVal prc As Double, ByVal typ As String) As Double
        Dim SelRat As Double

        ' Added by Mark Lau 20090831
        Dim strDate As String = ""
        Dim dblRate As Double

        Select Case typ
            Case "IM"
                If CDbl(strCurExRat) = 0 Then
                    dblRate = GetSelRat(CurCde, Custcurcde, strDate)
                    strCurExRat = CStr(dblRate)
                    strCurExEffDat = Format(CDate(strDate), "yyyy-MM-dd")
                Else
                    dblRate = CDbl(strCurExRat)
                End If

                SelRat = dblRate

                SalRate = Format(roundup(prc * SelRat), "######0.0000")


            Case "SC"

                If Custcurcde = CurCde Then
                    SalRate = Format(roundup(prc), "#0.0000")
                Else
                    ' Added by Mark Lau 20090831
                    dblRate = GetSelRat(CurCde, Custcurcde, strDate)
                    SelRat = dblRate
                    SalRate = Format(roundup(prc * SelRat), "#0.0000")
                End If

            Case "MOA"
                dblRate = GetSelRat(CurCde, Custcurcde, strDate)
                SelRat = dblRate
                SalRate = Format(roundup(prc * SelRat), "#0.0000")

        End Select
    End Function

    Private Function IsSamePriCust() As Boolean
        ' Added by Mark Lau 20090518
        ' Return True for same Pri Cust with the original SC
        ' Return False for different Pri Cust with original SC
        If myOwner.cboPriCust.Text <> myOwner.CopySC_Cust_SUB.cboPriCust.Text Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Function Cal_DtlPrc(ByVal basprc As Double, ByVal Discount As Double, ByVal ordqty As Long, ByVal typ As String) As Double
        Dim prc As Double
        Select Case typ
            Case "UNT"
                prc = basprc * (1 - Val(Discount) / 100)
                Cal_DtlPrc = Format(roundup(prc), "######0.0000")
            Case "TTL"
                prc = basprc * (1 - Val(Discount) / 100) * ordqty
                Cal_DtlPrc = Format(roundup(prc), "######0.0000")
        End Select
    End Function

    Private Sub LoadDVTtlCst(ByVal strItmNo As String, ByVal strUM As String, ByVal strInner As String, ByVal strMaster As String, ByVal strVendorType As String, ByVal blnSetValue As Boolean, ByVal index As Integer)

        Dim rs() As ADOR.Recordset
        Dim S As String

        Dim IBOMStartDate As Date
        IBOMStartDate = "04/01/2006"

        strDVTtlCst = 0
        strDVBOMCst = 0
        strDVItmCst = 0
        strDVftyunt = ""
        strDV = ""
        strDVfcurcde = ""



        If Format(Date.Now, "MM/dd/yyyy") >= IBOMStartDate Then
            gspStr = "sp_select_SCVENMRK_DV_wCust2 '" & strNewCocde & "','" & strItmNo & "','" & strUM & "','" & strInner & _
                     "','" & strMaster & "','" & strVendorType & "','" & rs_SCORDDTL_Copy.Tables("RESULT").Rows(index)("sod_cus1no") & _
                     "','" & rs_SCORDDTL_Copy.Tables("RESULT").Rows(index)("sod_cus2no") & "','" & _
                     rs_SCORDDTL_Copy.Tables("RESULT").Rows(index)("sod_hkprctrm") & "','" & _
                     rs_SCORDDTL_Copy.Tables("RESULT").Rows(index)("sod_ftyprctrm") & "','" & _
                     rs_SCORDDTL_Copy.Tables("RESULT").Rows(index)("sod_trantrm") & "','" & "1" & "'"
        Else
            gspStr = "sp_select_SCVENMRK_DV_wCust2 '" & strNewCocde & "','" & strItmNo & "','" & strUM & "','" & strInner & _
                     "','" & strMaster & "','" & strVendorType & "','" & rs_SCORDDTL_Copy.Tables("RESULT").Rows(index)("sod_cus1no") & _
                     "','" & rs_SCORDDTL_Copy.Tables("RESULT").Rows(index)("sod_cus2no") & "','" & _
                     rs_SCORDDTL_Copy.Tables("RESULT").Rows(index)("sod_hkprctrm") & "','" & _
                     rs_SCORDDTL_Copy.Tables("RESULT").Rows(index)("sod_ftyprctrm") & "','" & _
                     rs_SCORDDTL_Copy.Tables("RESULT").Rows(index)("sod_trantrm") & "','0'"
        End If

        rs_SCVENMRK_DV = Nothing
        rtnLong = execute_SQLStatement(gspStr, rs_SCVENMRK_DV, rtnStr)
        If rtnLong <> RC_SUCCESS Then    '*** An error has occured
            MsgBox("Error on loading frmCopySC #008 sp_select_SCVENMRK_DV_wCust : " & rtnStr)
        Else
            If rs_SCVENMRK_DV.Tables("RESULT").Rows.Count = 0 Then
                '****************query Item in history Table****************************
                If Format(Date.Now, "MM/dd/yyyy") >= IBOMStartDate Then
                    '***********Carlos Lui changed 20120901**********
                    gspStr = "sp_select_SCVENMRK_H_DV_wCust2 '" & strNewCocde & "','" & strItmNo & "','" & strUM & "','" & strInner & _
                             "','" & strMaster & "','" & strVendorType & "','" & rs_SCORDDTL_Copy.Tables("RESULT").Rows(index)("sod_cus1no") & _
                             "','" & rs_SCORDDTL_Copy.Tables("RESULT").Rows(index)("sod_cus2no") & "','" & _
                             rs_SCORDDTL_Copy.Tables("RESULT").Rows(index)("sod_hkprctrm") & "','" & _
                             rs_SCORDDTL_Copy.Tables("RESULT").Rows(index)("sod_ftyprctrm") & "','" & _
                             rs_SCORDDTL_Copy.Tables("RESULT").Rows(index)("sod_trantrm") & "','1'"
                    '***********Carlos Lui changed 20120901**********
                Else
                    '***********Carlos Lui changed 20120901**********
                    gspStr = "sp_select_SCVENMRK_H_DV_wCust2 '" & strNewCocde & "','" & strItmNo & "','" & strUM & "','" & strInner & _
                             "','" & strMaster & "','" & strVendorType & "','" & rs_SCORDDTL_Copy.Tables("RESULT").Rows(index)("sod_cus1no") & _
                             "','" & rs_SCORDDTL_Copy.Tables("RESULT").Rows(index)("sod_cus2no") & "','" & _
                             rs_SCORDDTL_Copy.Tables("RESULT").Rows(index)("sod_hkprctrm") & "','" & _
                             rs_SCORDDTL_Copy.Tables("RESULT").Rows(index)("sod_ftyprctrm") & "','" & _
                             rs_SCORDDTL_Copy.Tables("RESULT").Rows(index)("sod_trantrm") & "','0'"
                    '***********Carlos Lui changed 20120901**********
                End If
                rtnLong = execute_SQLStatement(gspStr, rs_SCVENMRK_DV, rtnStr)
                If rtnLong <> RC_SUCCESS Then    '*** An error has occured
                    MsgBox("Error on loading frmCopySC #009 sp_select_SCVENMRK_H_DV_wCust : " & rtnStr)
                    'Else
                    'If rs_SCVENMRK_DV.recordCount > 0 Then

                    'Else
                    '    'MsgBox ("DV FtyPrc not found !")
                    'End If
                End If
            End If
        End If

        If rs_SCVENMRK_DV.Tables("RESULT").Rows.Count > 0 Then

            strVenType = rs_SCVENMRK_DV.Tables("RESULT").Rows(0)("vendortype")

            If rs_SCVENMRK_DV.Tables("RESULT").Rows(0)("imu_curcde").ToString = "" Then
                strDVfcurcde = ""
            Else
                strDVfcurcde = rs_SCVENMRK_DV.Tables("RESULT").Rows(0)("imu_curcde")
            End If

            strDV = rs_SCVENMRK_DV.Tables("RESULT").Rows(0)("ivi_venno").ToString & " - " & rs_SCVENMRK_DV.Tables("RESULT").Rows(0)("vbi_vensna").ToString

            If strVenType = "I" Or strVenType = "J" Then

                strDVItmCst = Format(rs_SCVENMRK_DV.Tables("RESULT").Rows(0)("imu_ftyprc"), "#0.0000")
                strDVBOMCst = Format(rs_SCVENMRK_DV.Tables("RESULT").Rows(0)("imu_bomcst"), "#0.0000")

                If rs_SCVENMRK_DV.Tables("RESULT").Rows(0)("imu_bomcst") = 0 Then
                    strDVTtlCst = Format(Val(rs_SCVENMRK_DV.Tables("RESULT").Rows(0)("imu_ftyprc")) + Val(rs_SCVENMRK_DV.Tables("RESULT").Rows(0)("imu_bomcst")), "#0.0000")
                Else
                    strDVTtlCst = Format(Int((Val(rs_SCVENMRK_DV.Tables("RESULT").Rows(0)("imu_ftyprc")) + Val(rs_SCVENMRK_DV.Tables("RESULT").Rows(0)("imu_bomcst"))) * 100 + 0.00000001) / 100, "#0.0000")
                End If

            ElseIf strVenType = "E" Then

                strDVItmCst = Format(rs_SCVENMRK_DV.Tables("RESULT").Rows(0)("imu_ftycst"), "#0.0000")
                strDVBOMCst = Format(rs_SCVENMRK_DV.Tables("RESULT").Rows(0)("imu_bomcst"), "#0.0000")

                If rs_SCVENMRK_DV.Tables("RESULT").Rows(0)("imu_bomcst") = 0 Then
                    strDVTtlCst = Format(Val(rs_SCVENMRK_DV.Tables("RESULT").Rows(0)("imu_ftycst")) + Val(rs_SCVENMRK_DV.Tables("RESULT").Rows(0)("imu_bomcst")), "#0.0000")
                Else
                    strDVTtlCst = Format(Math.Round(((Val(rs_SCVENMRK_DV.Tables("RESULT").Rows(0)("imu_ftycst")) + Val(rs_SCVENMRK_DV.Tables("RESULT").Rows(0)("imu_bomcst"))) * 100) / 100, 2), "#0.0000")
                End If

            End If

            strDVftyunt = rs_SCVENMRK_DV.Tables("RESULT").Rows(0)("imu_pckunt").ToString
        Else

            strDVTtlCst = 0
            strDVBOMCst = 0
            strDVItmCst = 0
            strDVftyunt = ""
            strDV = ""
            strDVfcurcde = ""
        End If
    End Sub

    Private Function GetCusSty(ByVal strItmNo As String, ByVal strCusno As String) As String
        ' Show Customer Alias
        ' Added by Lester Wu 20080917
        Dim rsCusals As New DataSet

        gspStr = "sp_select_IMCUSSTY_QU '" & strNewCocde & "','" & strItmNo & "','" & strCusno & "'"

        rtnLong = execute_SQLStatement(gspStr, rsCusals, rtnStr)
        If rtnLong <> RC_SUCCESS Then  '*** An error has occured
            MsgBox("Error on loading frmCopySC #007 sp_select_IMCUSSTY_QU : " & rtnStr)
            Return ""
        End If

        If rsCusals.Tables("RESULT").Rows.Count > 0 Then
            GetCusSty = IIf(Trim(rsCusals.Tables("RESULT").Rows(0)("ics_cusstyno").ToString) = "", "", rsCusals.Tables("RESULT").Rows(0)("ics_cusstyno").ToString)
        Else
            GetCusSty = ""
        End If
    End Function

    Private Sub clear_More()
        If myOwner.rs_SCDTLSHP.Tables("RESULT").Rows.Count > 0 Then
            For i As Integer = 0 To myOwner.rs_SCDTLSHP.Tables("RESULT").Rows.Count - 1
                myOwner.rs_SCDTLSHP.Tables("RESULT").Rows(i).Delete()
            Next
            myOwner.rs_SCDTLSHP.AcceptChanges()
        End If

        'If myOwner.rs_SCDTLCTN.Tables("RESULT").Rows.Count > 0 Then
        '    For i As Integer = 0 To myOwner.rs_SCDTLCTN.Tables("RESULT").Rows.Count - 1
        '        myOwner.rs_SCDTLCTN.Tables("RESULT").Rows(i).Delete()
        '    Next
        '    myOwner.rs_SCDTLCTN.AcceptChanges()
        'End If
    End Sub

    Private Sub Display_Invalid()
        With grdInvalid
            For i As Integer = 0 To rs_SCORDDTL_Fail.Tables("RESULT").Columns.Count - 1
                .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                Select Case i
                    Case 5
                        .Columns(i).HeaderText = "Vendor"
                        .Columns(i).Width = 100
                        .Columns(i).ReadOnly = True
                    Case 6
                        .Columns(i).HeaderText = "Sub-Code"
                        .Columns(i).Width = 80
                        .Columns(i).ReadOnly = True
                    Case 13
                        .Columns(i).HeaderText = "Item #"
                        .Columns(i).Width = 150
                        .Columns(i).ReadOnly = True
                    Case 25
                        .Columns(i).HeaderText = "(Color/UM/Inner/Master/CFT/CBM)"
                        .Columns(i).Width = 200
                        .Columns(i).ReadOnly = True
                    Case 32
                        .Columns(i).HeaderText = "Reason"
                        .Columns(i).Width = 400
                        .Columns(i).ReadOnly = True
                    Case Else
                        .Columns(i).Visible = False
                End Select
            Next
        End With
    End Sub

    Private Sub Display_Summary()
        With grdValid
            For i As Integer = 0 To rs_SCORDDTL_Copy.Tables("RESULT").Columns.Count - 1
                .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                Select Case i
                    Case 5
                        .Columns(i).HeaderText = "Vendor"
                        .Columns(i).Width = 100
                        .Columns(i).ReadOnly = True
                    Case 6
                        .Columns(i).HeaderText = "Sub-Code"
                        .Columns(i).Width = 80
                        .Columns(i).ReadOnly = True
                    Case 13
                        .Columns(i).HeaderText = "Item #"
                        .Columns(i).Width = 150
                        .Columns(i).ReadOnly = True
                    Case 14
                        .Columns(i).HeaderText = "Cust Sty #"
                        .Columns(i).Width = 100
                        .Columns(i).ReadOnly = True
                    Case 15
                        .Columns(i).HeaderText = "Cust Item #"
                        .Columns(i).Width = 100
                        .Columns(i).ReadOnly = True
                    Case 16
                        .Columns(i).HeaderText = "Cust SKU #"
                        .Columns(i).Width = 100
                        .Columns(i).ReadOnly = True
                    Case 25
                        .Columns(i).HeaderText = "(Color/UM/Inner/Master/CFT/CBM)"
                        .Columns(i).Width = 200
                        .Columns(i).ReadOnly = True
                    Case 32
                        .Columns(i).HeaderText = "Color Desc."
                        .Columns(i).Width = 90
                        .Columns(i).ReadOnly = True
                    Case Else
                        .Columns(i).Visible = False
                End Select
            Next
        End With
    End Sub

    Private Function roundup(ByVal Value As Double) As Double
        Dim tmp As String
        Dim tmpValue As Double

        tmpValue = Math.Round(Value, 5)
        tmp = CStr(Value)

        If InStr(tmp, ".") > 0 Then
            If tmp.Substring(tmp.Length - (tmp.Length - InStr(tmp, ".")), tmp.Length - InStr(tmp, ".")).Length > 4 Then
                Return (Math.Round(Math.Ceiling(Value * 10000)) / 10000)
            Else
                Return tmpValue
            End If
        Else
            Return tmpValue
        End If
    End Function

    Public Function GetSelRat(ByVal strFrmCur As String, ByVal strToCur As String, ByRef strEffDat As String) As Double
        Dim rs As DataSet

        If strEffDat = "" Then
            gspStr = "sp_select_SYCUREX_transaction '','" & strFrmCur & "','" & strToCur & "','1900-01-01',''"
        Else
            gspStr = "sp_select_SYCUREX_transaction '','" & strFrmCur & "','" & strToCur & "','" & strEffDat & "',''"
        End If

        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Error on loading SCM00001 #023 sp_select_SYCUREX_transaction : " & rtnStr)
            Return 0
        Else
            If rs.Tables("RESULT").Rows.Count > 0 Then
                If strEffDat = "" Then
                    strEffDat = Format(rs.Tables("RESULT").Rows(0)("yce_effdat"), "yyyy-MM-dd")
                End If
                Return CDbl(rs.Tables("RESULT").Rows(0)("yce_selrat"))
            Else
                Return 0
            End If
        End If
    End Function
End Class