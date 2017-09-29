Public Class QUM00001_2

    Public ma As QUM00001
    Dim drNewRow As DataRow
    Dim sFilter As String
    Dim dr() As DataRow
    Dim rs_IMXCHK As New DataSet
    Dim fml As String
    Dim sReadingIndexP As Integer

    Dim rs_IMBASINF As New DataSet  ' for Item Basic
    Dim rs_IMCOLINF As New DataSet  ' for Item Color
    Dim rs_IMPCKINF As New DataSet  ' for Item Packing
    Dim rs_IMMATBKD As New DataSet  ' for Component Breakdown
    Dim rs_IMBOMASS As New DataSet  ' for Assorted Item
    Dim rs_IMVENINF As New DataSet  ' for Vendor Item (IMVENINF, IMMMRPUP, VNBASINF)Public itmdsc As String
    Dim rs_CUITMSUM As New DataSet  ' for Customer Item History Summary
    Dim rs_SYTIESTR As New DataSet  ' for MOQ & MOA of Standard Tier
    Dim rs_SYCONFTR As New DataSet  ' for Conversion Factor
    Dim rs_CUMCOVEN As New DataSet  ' for Company Vendor Relation
    Dim rs_CUMCAMRK As New DataSet  ' for Cat Mark Up

    Dim qutseq As Integer
    Dim stkqty_tmp As Integer
    Dim cusqty_tmp As Integer
    Dim smpqty_tmp As Integer

    Public ITMTYP As String
    Public itmsts As String
    Public itmdsc As String
    Public cosmth As String
    Public hrmcde As String
    Public img As String
    Public coldsc As String
    Public cuscol As String
    Public cusitm As String
    Public hstRef As String
    Public cususd As Double
    Public cuscad As Double
    Public dept As String
    Public dtyrat As Double

    Public venno As String
    Public subcde As String
    Public vensts As String
    Public fcurcde As String
    Public ftyprc As Double
    Public ftycst As Double

    Public venitm As String

    Public basprc As Double
    Public cus1sp As Double
    Public cus1dp As Double
    Public cus2sp As Double
    Public cus2dp As Double
    Public moq As Integer
    Public moa As Double
    Public smpunt As String
    Public smpprc As Double
    Public pckitr As String

    Dim ORI_MOQ As String
    Dim ORI_MOA As String
    Dim ORI_MOFLAG As String
    Dim strMOQUNTTYP As String

    Dim CusVenNo As String

    Dim txtcontopc As String
    Dim txtPCPrc As Double

    Dim txtIMRmk As String

    Private Sub QUM00001_2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        stkqty_tmp = Val(ma.txtStkQty.Text)
        cusqty_tmp = Val(ma.txtCusQty.Text)
        smpqty_tmp = Val(ma.txtSmpQty.Text)

        qutseq = ma.rs_QUOTNDTL.Tables("RESULT").Rows(ma.sReadingIndexQ)("qud_qutseq")
        'qutseq = ma.txtSeq.Text

        txtItmNoO.Text = ma.txtItmNo.Text
        cboColCdeO.Text = ma.cboColCde.Text
        cboPckingO.Text = ma.cboPcking.Text
        txtInrQtyO.Text = ma.txtInrQty.Text
        txtMtrQtyO.Text = ma.txtMtrQty.Text
        txtCftO.Text = ma.txtCft.Text
        txtUMO.Text = ma.cboUM.Text

        txtItmNoO.Enabled = False
        cboColCdeO.Enabled = False
        cboPckingO.Enabled = False
        txtInrQtyO.Enabled = False
        txtMtrQtyO.Enabled = False
        txtCftO.Enabled = False
        txtUMO.Enabled = False
        txtInrQtyM.Enabled = False
        txtMtrQtyM.Enabled = False
        txtCftM.Enabled = False
        txtUMM.Enabled = False

        txtUMftro.Text = ma.txtUMFtr.Text
        txtUMftro.Enabled = False
        txtUMftr.Enabled = False

        If isABUAssortment(txtItmNoO.Text) = True Then
            Call ABUASST(txtItmNoO.Text, "SHOW")
            txtUMftro.Visible = True
        Else
            Call ABUASST(txtItmNoO.Text, "HIDE")
            txtUMftro.Visible = False
        End If

        rs_IMBASINF.Tables.Clear()
        rs_IMCOLINF.Tables.Clear()
        rs_IMPCKINF.Tables.Clear()
        rs_IMMATBKD.Tables.Clear()
        rs_IMBOMASS.Tables.Clear()
        'rs_IMBASINF = Nothing
        'rs_IMCOLINF = Nothing
        'rs_IMPCKINF = Nothing
        'rs_IMMATBKD = Nothing
        'rs_IMBOMASS = Nothing
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Function isABUAssortment(ByVal itmNo As String) As Boolean
        '*** FOR ALL ASSORTMENT
        Dim rs_ABUASST As New DataSet

        isABUAssortment = False

        'S = "㊣CHECK_ASST_FOR_PC※S※" & IIf(itmNo = "", "X", itmNo)

        Cursor = Cursors.WaitCursor

        gsCompany = Trim(ma.cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_CHECK_ASST_FOR_PC '" & ma.cboCoCde.Text & "','" & IIf(itmNo = "", "X", itmNo) & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_ABUASST, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading isABUAssortment sp_select_CHECK_ASST_FOR_PC :" & rtnStr)
            Cursor = Cursors.Default
            Exit Function
        End If

        If rs_ABUASST.Tables("RESULT").Rows.Count > 0 Then
            isABUAssortment = True
        Else
            isABUAssortment = False
        End If
    End Function

    Private Sub ABUASST(ByVal itmNo As String, ByVal Action As String)
        Select Case Action
            Case "SHOW"
                txtUMftr.Visible = True
            Case "HIDE"
                txtUMftr.Visible = False
                txtUMftr.Text = ""
            Case "CHKPCK_A"
                If isABUAssortment(itmNo) = True Then
                    If rs_IMPCKINF.Tables("RESULT").Rows.Count > 0 Then
                        sFilter = "ipi_pckunt = '" & Split(cboPckingM.Text, " / ")(0) & "' and ipi_inrqty = " & Split(cboPckingM.Text, " / ")(1) & " and ipi_mtrqty = " & Split(cboPckingM.Text, " / ")(2)
                        rs_IMPCKINF.Tables("RESULT").DefaultView.RowFilter = sFilter

                        If rs_IMPCKINF.Tables("RESULT").DefaultView(0)("ipi_conftr").ToString <> "" Then
                            txtUMftr.Text = rs_IMPCKINF.Tables("RESULT").DefaultView(0)("ipi_conftr")
                            Call ABUASST(txtItmNoO.Text, "SHOW")
                        End If

                        sFilter = ""
                        rs_IMPCKINF.Tables("RESULT").DefaultView.RowFilter = sFilter
                    End If
                End If
        End Select
    End Sub

    Private Sub txtItmNoM_Change()
        cboColCdeM.Items.Clear()
        cboPckingM.Items.Clear()
        txtInrQtyM.Text = ""
        txtMtrQtyM.Text = ""
        txtCftM.Text = ""
        txtUMM.Text = ""
    End Sub

    Private Sub txtItmNoM_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItmNoM.GotFocus
        txtItmNoM.SelectAll()
    End Sub

    Private Sub txtItmNoM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItmNoM.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then
            txtItmNoM.Text = UCase(Trim(txtItmNoM.Text))
        End If

        If e.KeyChar.Equals(Chr(13)) And txtItmNoM.Text <> "" Then
            Call txtItmNoM_Press()
        End If
    End Sub

    Private Sub txtItmNoM_Press()
        txtItmNoM.Text = UCase(txtItmNoM.Text)

        'S = "㊣IMBASINF_TBM※S※" & txtItmNoM.Text & "※" & txtItmNoO.Text
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gsCompany = Trim(ma.cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_IMBASINF_TBM '" & ma.cboCoCde.Text & "','" & txtItmNoM.Text & "','" & txtItmNoO.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_IMBASINF, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading txtItmNoM_Press sp_select_IMBASINF_TBM :" & rtnStr)
            Exit Sub
        End If

        If rs_IMBASINF.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("Item not found or the Item type between the Original and To Be Modified are different.")
            txtItmNoM.SelectAll()
            Exit Sub
        Else
            Dim itmNo As String

            If InStr(1, "00050006000700080009", Microsoft.VisualBasic.Right(Split(txtItmNoM.Text, "-")(0), 4)) > 0 Then
                itmNo = rs_IMBASINF.Tables("RESULT").Rows(0)("ivi_venitm")
            Else
                itmNo = txtItmNoM.Text
            End If

            If not_Valid_Item(itmNo, ma.cboCus1No.Text, " ") Then
                txtItmNoM.SelectAll()
                If txtItmNoM.Enabled And txtItmNoM.Visible Then txtItmNoM.Focus()
                Exit Sub
            End If

            '*********************************************** Get Cat Markup ****************************
            '*** Phase 2 comment it
            'dr = ma.rs_CUMCAMRK.Tables("RESULT").Select("ccm_cusno = '" & Trim(Split(ma.cboCus1No.Text, "-")(0)) & _
            '                 "' and ccm_ventyp = '" & rs_IMBASINF.Tables("RESULT").Rows(0)("vbi_ventyp").ToString & _
            '                 "' and ccm_cat = '" & rs_IMBASINF.Tables("RESULT").Rows(0)("ibi_catlvl3").ToString & "'")

            'If dr.Length > 0 Then
            '    fml = dr(0)("yfi_fml")
            'Else
            '    dr = ma.rs_CUMCAMRK.Tables("RESULT").Select("ccm_cusno = '" & Trim(Split(ma.cboCus1No.Text, "-")(0)) & _
            '                             "' and ccm_ventyp = '" & rs_IMBASINF.Tables("RESULT").Rows(0)("vbi_ventyp").ToString & _
            '                             "' and ccm_cat = 'STANDARD'")
            '    If dr.Length > 0 Then
            '        fml = dr(0)("yfi_fml")
            '    Else
            '        Cursor = Cursors.Default
            '        MsgBox("Missing Customer Category Markup, Please Enter Customer Customer Category Markup before Transaction Processing.")
            '        Exit Sub
            '    End If
            'End If

            'S = "㊣IMCOLINF※S※" & itmNo & "㊣IMPCKINF_Q※S※" & itmNo & "㊣IMMATBKD※S※" & itmNo & "㊣IMBOMASS_Q※S※" & itmNo
            'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

            Cursor = Cursors.WaitCursor

            gsCompany = Trim(ma.cboCoCde.Text)
            Call Update_gs_Value(gsCompany)

            gspStr = "sp_select_IMCOLINF '" & ma.cboCoCde.Text & "','" & itmNo & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_IMCOLINF, rtnStr)
            gspStr = ""

            Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                Cursor = Cursors.Default
                MsgBox("Error on loading txtItmNoM_Press sp_select_IMCOLINF :" & rtnStr)
                Exit Sub
            End If

            Cursor = Cursors.WaitCursor

            gsCompany = Trim(ma.cboCoCde.Text)
            Call Update_gs_Value(gsCompany)

            gspStr = "sp_select_IMPCKINF_Q '" & ma.cboCoCde.Text & "','" & itmNo & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_IMPCKINF, rtnStr)
            gspStr = ""

            Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                Cursor = Cursors.Default
                MsgBox("Error on loading txtItmNoM_Press sp_select_IMPCKINF_Q :" & rtnStr)
                Exit Sub
            End If

            Cursor = Cursors.WaitCursor

            gsCompany = Trim(ma.cboCoCde.Text)
            Call Update_gs_Value(gsCompany)

            gspStr = "sp_select_IMMATBKD '" & ma.cboCoCde.Text & "','" & itmNo & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_IMMATBKD, rtnStr)
            gspStr = ""

            Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                Cursor = Cursors.Default
                MsgBox("Error on loading txtItmNoM_Press sp_select_IMMATBKD :" & rtnStr)
                Exit Sub
            End If

            Cursor = Cursors.WaitCursor

            gsCompany = Trim(ma.cboCoCde.Text)
            Call Update_gs_Value(gsCompany)

            gspStr = "sp_select_IMBOMASS_Q '" & ma.cboCoCde.Text & "','" & itmNo & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_IMBOMASS, rtnStr)
            gspStr = ""

            Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                Cursor = Cursors.Default
                MsgBox("Error on loading txtItmNoM_Press sp_select_IMBOMASS_Q :" & rtnStr)
                Exit Sub
            End If

            ITMTYP = rs_IMBASINF.Tables("RESULT").Rows(0)("ibi_typ")
            itmdsc = rs_IMBASINF.Tables("RESULT").Rows(0)("ibi_engdsc")
            itmsts = rs_IMBASINF.Tables("RESULT").Rows(0)("ibi_itmsts")
            txtIMRmk = rs_IMBASINF.Tables("RESULT").Rows(0)("ibi_rmk")

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

            Dim pth As String

            img = "N"

            On Error Resume Next

            pth = rs_IMBASINF.Tables("RESULT").Rows(0)("ibi_imgpath")

            If UCase(Dir(pth)) = "" Then
                img = "N"
            Else
                img = "Y"
            End If
        End If

        If rs_IMCOLINF.Tables("RESULT").Rows.Count = 0 Then
            cboColCdeM.Enabled = False
            cboColCdeM.Items.Clear()
        Else
            cboColCdeM.Enabled = True
            cboColCdeM.Items.Clear()

            For index As Integer = 0 To rs_IMCOLINF.Tables("RESULT").Rows.Count - 1
                cboColCdeM.Items.Add(rs_IMCOLINF.Tables("RESULT").Rows(index)("icf_colcde").ToString)
            Next

            cboColCdeM.Text = rs_IMCOLINF.Tables("RESULT").Rows(0)("icf_colcde")
        End If

        If rs_IMPCKINF.Tables("RESULT").Rows.Count = 0 Then
            cboPckingM.Enabled = False
            cboPckingM.Items.Clear()
        Else
            cboPckingM.Enabled = True
            cboPckingM.Items.Clear()

            For index As Integer = 0 To rs_IMPCKINF.Tables("RESULT").Rows.Count - 1
                cboPckingM.Items.Add(rs_IMPCKINF.Tables("RESULT").Rows(index)("ipi_pckunt").ToString + " / " + _
                                    rs_IMPCKINF.Tables("RESULT").Rows(index)("ipi_inrqty").ToString + " / " + _
                                    rs_IMPCKINF.Tables("RESULT").Rows(index)("ipi_mtrqty").ToString)

                '*** Assume 1 packing only for assortment
                If rs_IMPCKINF.Tables("RESULT").Rows(index)("max_seq") = 1 And _
                    rs_IMBASINF.Tables("RESULT").Rows(index)("ibi_typ") = "ASS" And _
                    isABUAssortment(rs_IMBASINF.Tables("RESULT").Rows(index)("ibi_itmno").ToString) = True Then
                    txtUMftr.Text = rs_IMPCKINF.Tables("RESULT").Rows(index)("ipi_conftr")
                    Call ABUASST(txtItmNoO.Text, "SHOW")
                Else
                    txtUMftr.Text = ""
                    Call ABUASST(txtItmNoO.Text, "HIDE")
                End If

            Next

            cboPckingM.SelectedIndex = 0
        End If
    End Sub

    Private Sub txtItmNoM_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItmNoM.TextChanged
        Call txtItmNoM_Change()
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
            MsgBox("Error on loading not_Valid_Item sp_select_IMXChk :" & rtnStr)
            Exit Function
        End If

        If rs_IMXCHK.Tables("RESULT").Rows.Count = 0 Then
            not_Valid_Item = True
            MsgBox("Item cannot Quot by this Company! Customer and Compnay Relation Missing.")
        Else
            If rs_IMXCHK.Tables("RESULT").Rows(0)("imx_vendef").ToString <> "Y" Then
                If MsgBox("This is not the default company to quot this item, Do you continue the quot?", vbYesNo) = vbYes Then
                    not_Valid_Item = False
                Else
                    not_Valid_Item = True
                End If
            Else
                not_Valid_Item = False
            End If
        End If
    End Function

    Private Sub cboColCdeM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboColCdeM.Click
        Dim i As Integer

        If cboColCdeM.Text <> "" Then
            i = cboColCdeM.SelectedIndex
            coldsc = rs_IMCOLINF.Tables("RESULT").Rows(i)("icf_coldsc")
        End If
    End Sub

    Private Sub cboColCdeM_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboColCdeM.LostFocus
        Dim i As Integer
        Dim Y As Integer
        Dim inCombo As Boolean

        i = cboColCdeM.Items.Count

        If cboColCdeM.Text <> "" And cboColCdeM.Enabled = True And cboColCdeM.Items.Count > 0 Then
            For Y = 0 To i - 1
                If cboColCdeM.Text = cboColCdeM.Items(Y) Then
                    inCombo = True
                End If
            Next

            If inCombo = False And cboColCdeM.Enabled = True Then
                MsgBox("Color Code - Data is Invalid, please select in Drop Down List.")
                If cboColCdeM.Enabled And cboColCdeM.Visible Then cboColCdeM.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub cboPckingM_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPckingM.SelectedIndexChanged
        Call cboPckingMClick()
    End Sub

    Private Sub cboPckingMClick()
        Dim i As Integer

        If cboPckingM.Text <> "" Then
            i = cboPckingM.SelectedIndex
            sReadingIndexP = i

            txtInrQtyM.Text = rs_IMPCKINF.Tables("RESULT").Rows(i)("ipi_inrqty")
            txtMtrQtyM.Text = rs_IMPCKINF.Tables("RESULT").Rows(i)("ipi_mtrqty")
            txtCftM.Text = rs_IMPCKINF.Tables("RESULT").Rows(i)("ipi_cft")
            txtUMM.Text = rs_IMPCKINF.Tables("RESULT").Rows(i)("ipi_pckunt")
            pckitr = rs_IMPCKINF.Tables("RESULT").Rows(i)("ipi_pckitr")
            txtUMftr.Text = rs_IMPCKINF.Tables("RESULT").Rows(i)("ipi_conftr")

            Call CalculatePrc()

            'S = "㊣ItemMaster_moq_moa_qu_wunttyp※S※" & QUM00001.GetCtrlValue(QUM00001.cboCus1No) & _
            '    "※" & QUM00001.GetCtrlValue(QUM00001.cboCus2No) & "※" & Me.txtItmNoM.Text & _
            '    "※" & Me.txtUMM.Text & "※" & IIf(txtUMftr.Text = "", 1, txtUMftr.Text) & "※" & Me.txtInrQtyM.Text & "※" & Me.txtMtrQtyM.Text & _
            '    "※" & cboColCdeM.Text & "※" & cus1sp & "※" & QUM00001.txtCurCde2.Text
            'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

            Cursor = Cursors.WaitCursor

            gsCompany = Trim(ma.cboCoCde.Text)
            Call Update_gs_Value(gsCompany)

            gspStr = "sp_select_ItemMaster_moq_moa_qu_wunttyp '" & ma.cboCoCde.Text & "','" & _
                                            Trim(Split(ma.cboCus1No.Text, "-")(0)) & "','" & _
                                            Trim(Split(ma.cboCus2No.Text, "-")(0)) & "','" & _
                                            txtItmNoM.Text & "','" & _
                                            txtUMM.Text & "','" & _
                                            IIf(txtUMftr.Text = "", 1, txtUMftr.Text) & "','" & _
                                            txtInrQtyM.Text & "','" & _
                                            txtMtrQtyM.Text & "','" & _
                                            cboColCdeM.Text & "','" & _
                                            cus1sp & "','" & _
                                            ma.txtCurCde2.Text & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_SYTIESTR, rtnStr)
            gspStr = ""

            Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                Cursor = Cursors.Default
                MsgBox("Error on loading updateAll sp_select_ItemMaster_moq_moa_qu_wunttyp :" & rtnStr)
                Exit Sub
            End If

            strMOQUNTTYP = ""

            '*** Set Original MOQ/MOA
            ORI_MOFLAG = ""
            ORI_MOQ = ""
            ORI_MOA = ""
            '---------------------

            If rs_SYTIESTR.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("No MOQ & MOA found of this Item")
                cboPckingM.Text = ""
                txtInrQtyM.Text = ""
                txtMtrQtyM.Text = ""
                txtCftM.Text = ""
                moq = ""
                moa = ""
                strMOQUNTTYP = ""
                If cboPckingM.Enabled And cboPckingM.Visible Then cboPckingM.Focus()
                Exit Sub
            Else
                ORI_MOFLAG = rs_SYTIESTR.Tables("RESULT").Rows(0)("MOFLAG")
                ORI_MOQ = CInt(rs_SYTIESTR.Tables("RESULT").Rows(0)("MOQ"))

                strMOQUNTTYP = "CTN"

                If ma.txtCurCde1.Text <> rs_SYTIESTR.Tables("RESULT").Rows(0)("CURCDE").ToString And _
                    CDec(rs_SYTIESTR.Tables("RESULT").Rows(0)("MOA")) > 0 Then
                    dr = ma.rs_CUBASINF_CR.Tables("RESULT").Select("ysi_def = 'Y'")

                    If ma.txtCurCde1.Text = dr(0)("ysi_cde") Then
                        dr = ma.rs_CUBASINF_CR.Tables("RESULT").Select("ysi_cde = " + "'" + rs_SYTIESTR.Tables("RESULT").Rows(0)("CURCDE").ToString + "'")
                        ORI_MOA = roundup(rs_SYTIESTR.Tables("RESULT").Rows(0)("MOA") * dr(0)("ysi_selrat"))
                    Else
                        dr = ma.rs_CUBASINF_CR.Tables("RESULT").Select("ysi_cde = " + "'" + ma.txtCurCde1.Text + "'")
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
    End Sub

    Private Sub cboPckingM_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPckingM.LostFocus
        Dim i As Integer
        Dim Y As Integer
        Dim inCombo As Boolean

        i = cboPckingM.Items.Count

        If cboPckingM.Text <> "" And cboPckingM.Text <> " /  0 /  0" And cboPckingM.Enabled = True And cboPckingM.Items.Count > 0 Then
            For Y = 0 To i - 1
                If cboPckingM.Text = cboPckingM.Items(Y) Then
                    inCombo = True
                    ABUASST(txtItmNoO.Text, "CHKPCK_A")
                End If
            Next

            If inCombo = False And cboPckingM.Enabled = True Then
                MsgBox("Packing - Data is Invalid, please select in Drop Down List.")
                If cboPckingM.Enabled And cboPckingM.Visible Then cboPckingM.Focus()
                ABUASST(txtItmNoO.Text, "HIDE")
                Exit Sub
            End If
        Else
            txtInrQtyM.Text = ""
            txtMtrQtyM.Text = ""
            txtCftM.Text = ""
            txtUMM.Text = ""
            txtUMftr.Text = ""
        End If
    End Sub

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

    Private Sub CalculatePrc()
        ' New logic to get Price Info
        Dim cus1no As String
        Dim cus2no As String

        If Trim(ma.cboCus1No.Text) = "" Then
            cus1no = ""
        Else
            cus1no = Trim(Split(ma.cboCus1No.Text, "-")(0))
        End If

        If Trim(ma.cboCus2No.Text) = "" Then
            cus2no = ""
        Else
            cus2no = Trim(Split(ma.cboCus2No.Text, "-")(0))
        End If

        'S = "㊣QUOTNDTL_Vendor_wCust※S※" & txtItmNoM.Text & "※" & rs_IMPCKINF("ipi_pckseq") & "※" & cus1no & "※" & cus2no & "※" & gsUsrID
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gsCompany = Trim(ma.cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_QUOTNDTL_Vendor '" & ma.cboCoCde.Text & "','" & _
                                                txtItmNoM.Text & "','" & _
                                                rs_IMPCKINF.Tables("RESULT").Rows(sReadingIndexP)("ipi_pckunt").ToString & "','" & _
                                                rs_IMPCKINF.Tables("RESULT").Rows(sReadingIndexP)("ipi_inrqty").ToString & "','" & _
                                                rs_IMPCKINF.Tables("RESULT").Rows(sReadingIndexP)("ipi_mtrqty").ToString & "','" & _
                                                cus1no & "','" & cus2no & "','" & gsUsrID & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_IMVENINF, rtnStr)
        gspStr = ""
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading CalculatePrc sp_select_QUOTNDTL_Vendor :" & rtnStr)
            Cursor = Cursors.Default
            Exit Sub
        End If

        Cursor = Cursors.Default

        If rs_IMVENINF.Tables("RESULT").Rows.Count > 0 And _
            rs_IMVENINF.Tables("RESULT").Rows(0)("imu_ftyprc") <> 0 And _
            rs_IMVENINF.Tables("RESULT").Rows(0)("imu_ftycst") <> 0 Then

            fcurcde = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_curcde")
            ftyprc = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_ftyprc")
            ftycst = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_ftycst")

            '*** Calcualte Basic Price in Customer Currency
            If rs_IMVENINF.Tables("RESULT").Rows(0)("imu_bcurcde").ToString <> ma.txtCurCde2.Text Then
                dr = ma.rs_CUBASINF_CR.Tables("RESULT").Select("ysi_def = 'Y'")

                If ma.txtCurCde2.Text = dr(0)("ysi_cde") Then
                    dr = ma.rs_CUBASINF_CR.Tables("RESULT").Select("ysi_cde = " & "'" & rs_IMVENINF.Tables("RESULT").Rows(0)("imu_bcurcde").ToString & "'")
                    basprc = Format(roundup(rs_IMVENINF.Tables("RESULT").Rows(0)("imu_basprc") * dr(0)("ysi_selrat")), "########0.0000")
                Else
                    dr = ma.rs_CUBASINF_CR.Tables("RESULT").Select("ysi_cde = " & "'" & ma.txtCurCde2.Text & "'")
                    basprc = Format(roundup(rs_IMVENINF.Tables("RESULT").Rows(0)("imu_basprc") / dr(0)("ysi_selrat")), "########0.0000")
                End If
            Else
                basprc = Format(rs_IMVENINF.Tables("RESULT").Rows(0)("imu_basprc"), "########0.0000")
            End If

            ma.rs_QUOTNDTL.Tables("RESULT").Rows(ma.sReadingIndexQ)("qud_trantrm") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_trantrm")
            ma.rs_QUOTNDTL.Tables("RESULT").Rows(ma.sReadingIndexQ)("qud_cus1no") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_cus1no")
            ma.rs_QUOTNDTL.Tables("RESULT").Rows(ma.sReadingIndexQ)("qud_cus2no") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_cus2no")
            ma.rs_QUOTNDTL.Tables("RESULT").Rows(ma.sReadingIndexQ)("qud_effdat") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_effdat")
            ma.rs_QUOTNDTL.Tables("RESULT").Rows(ma.sReadingIndexQ)("qud_expdat") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_expdat")

            Dim dblCstEmtPert As Double
            Dim dblCstEmtAmt As Double
            Dim strCstEmtPert As String
            Dim i As Integer

            dblCstEmtPert = 0
            dblCstEmtAmt = 0
            strCstEmtPert = ""

            If ma.rs_QUCSTEMT.Tables.Count > 0 Then
                If ma.rs_QUCSTEMT.Tables("RESULT").DefaultView.Count > 0 Then
                    For i = 0 To ma.rs_QUCSTEMT.Tables("RESULT").DefaultView.Count - 1
                        dblCstEmtPert = dblCstEmtPert + CDec(ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(i)("qce_percent"))
                        dblCstEmtAmt = dblCstEmtAmt + CDec(ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(i)("qce_amt"))
                    Next
                End If
            End If
            dblCstEmtPert = dblCstEmtPert / 100

            If rs_IMVENINF.Tables("RESULT").Rows(0)("imu_bcurcde").ToString <> ma.txtCurCde2.Text Then
                dr = ma.rs_CUBASINF_CR.Tables("RESULT").Select("ysi_def = 'Y'")

                If ma.txtCurCde2.Text = dr(0)("ysi_cde") Then
                    dr = ma.rs_CUBASINF_CR.Tables("RESULT").Select("ysi_cde = " & "'" & rs_IMVENINF.Tables("RESULT").Rows(0)("imu_bcurcde").ToString & "'")
                    'cus1sp = Format(roundup(Eval(rs_IMVENINF.Tables("RESULT").Rows(0)("imu_basprc"), fml) * dr(0)("ysi_selrat")), "###,###,##0.0000")
                    cus1sp = Format(round2(Eval(rs_IMVENINF.Tables("RESULT").Rows(0)("imu_basprc"), fml) * dr(0)("ysi_selrat")), "###,###,##0.0000")

                    If ma.cboCus2No.Text <> "" Then
                        If ma.optMU.Checked = True Then
                            'cus2sp = Format(roundup(CDec(cus1sp) * (1 + ma.txtGrsMgn.Text / 100)), "########0.0000")
                            cus2sp = Format(round2(CDec(cus1sp) * (1 + ma.txtGrsMgn.Text / 100)), "########0.0000")
                        Else
                            'cus2sp = Format(roundup(CDec(cus1sp) / (1 - ma.txtGrsMgn.Text / 100)), "########0.0000")
                            cus2sp = Format(round2(CDec(cus1sp) / (1 - ma.txtGrsMgn.Text / 100)), "########0.0000")
                        End If
                    End If
                    'cus1sp = Format(roundup(Eval(rs_IMVENINF.Tables("RESULT").Rows(0)("imu_basprc"), fml) * dr(0)("ysi_selrat") + _
                    cus1sp = Format(round2(Eval(rs_IMVENINF.Tables("RESULT").Rows(0)("imu_basprc"), fml) * dr(0)("ysi_selrat") + _
                                ((CDec(rs_IMVENINF.Tables("RESULT").Rows(0)("imu_basprc")) * dblCstEmtPert) * dr(0)("ysi_selrat")) + _
                                (dblCstEmtAmt * dr(0)("ysi_selrat"))), "###,###,##0.0000")

                    If ma.cboCus2No.Text <> "" Then
                        If ma.optMU.Checked = True Then
                            'cus2dp = Format(roundup(CDec(cus1dp) * (1 + ma.txtGrsMgn.Text / 100)), "########0.0000")
                            cus2dp = Format(round2(CDec(cus1dp) * (1 + ma.txtGrsMgn.Text / 100)), "########0.0000")
                        Else
                            'cus2dp = Format(roundup(CDec(cus1dp) / (1 - ma.txtGrsMgn.Text / 100)), "########0.0000")
                            cus2dp = Format(round2(CDec(cus1dp) / (1 - ma.txtGrsMgn.Text / 100)), "########0.0000")
                        End If
                    End If
                Else
                    dr = ma.rs_CUBASINF_CR.Tables("RESULT").Select("ysi_cde = " & "'" & ma.txtCurCde2.Text & "'")
                    'cus1sp = Format(roundup(Eval(rs_IMVENINF.Tables("RESULT").Rows(0)("imu_basprc"), fml) / dr(0)("ysi_selrat") + _
                    cus1sp = Format(round2(Eval(rs_IMVENINF.Tables("RESULT").Rows(0)("imu_basprc"), fml) / dr(0)("ysi_selrat") + _
                                 ((CDec(rs_IMVENINF.Tables("RESULT").Rows(0)("imu_basprc")) * dblCstEmtPert) / dr(0)("ysi_selrat")) + _
                                 (dblCstEmtAmt / dr(0)("ysi_selrat"))), "###,###,##0.0000")

                    If ma.cboCus2No.Text <> "" Then
                        If ma.optMU.Checked = True Then
                            'cus2sp = Format(roundup(CDec(cus1sp) * (1 + ma.txtGrsMgn.Text / 100)), "########0.0000")
                            cus2sp = Format(round2(CDec(cus1sp) * (1 + ma.txtGrsMgn.Text / 100)), "########0.0000")
                        Else
                            'cus2sp = Format(roundup(CDec(cus1sp) / (1 - ma.txtGrsMgn.Text / 100)), "########0.0000")
                            cus2sp = Format(round2(CDec(cus1sp) / (1 - ma.txtGrsMgn.Text / 100)), "########0.0000")
                        End If
                    End If
                    cus1dp = Format(CDec(cus1sp), "########0.0000")

                    If ma.cboCus2No.Text <> "" Then
                        If ma.optMU.Checked = True Then
                            'cus2dp = Format(roundup(CDec(cus1dp) * (1 + ma.txtGrsMgn.Text / 100)), "########0.0000")
                            cus2dp = Format(round2(CDec(cus1dp) * (1 + ma.txtGrsMgn.Text / 100)), "########0.0000")
                        Else
                            'cus2dp = Format(roundup(CDec(cus1dp) / (1 - ma.txtGrsMgn.Text / 100)), "########0.0000")
                            cus2dp = Format(round2(CDec(cus1dp) / (1 - ma.txtGrsMgn.Text / 100)), "########0.0000")
                        End If
                    End If
                End If
            Else
                'cus1sp = Format(roundup(Eval(rs_IMVENINF.Tables("RESULT").Rows(0)("imu_basprc"), fml) + _
                cus1sp = Format(round2(Eval(rs_IMVENINF.Tables("RESULT").Rows(0)("imu_basprc"), fml) + _
                             (CDec(rs_IMVENINF.Tables("RESULT").Rows(0)("imu_basprc")) * dblCstEmtPert) + _
                             dblCstEmtAmt), "###,###,##0.0000")

                If ma.cboCus2No.Text <> "" Then
                    If ma.optMU.Checked = True Then
                        'cus2sp = Format(roundup(CDec(cus1sp) * (1 + ma.txtGrsMgn.Text / 100)), "########0.0000")
                        cus2sp = Format(round2(CDec(cus1sp) * (1 + ma.txtGrsMgn.Text / 100)), "########0.0000")
                    Else
                        'cus2sp = Format(roundup(CDec(cus1sp) / (1 - ma.txtGrsMgn.Text / 100)), "########0.0000")
                        cus2sp = Format(round2(CDec(cus1sp) / (1 - ma.txtGrsMgn.Text / 100)), "########0.0000")
                    End If
                End If
                cus1dp = Format(cus1sp, "########0.0000")

                If ma.cboCus2No.Text <> "" Then
                    If ma.optMU.Checked = True Then
                        'cus2dp = Format(roundup(CDec(cus1dp) * (1 + ma.txtGrsMgn.Text / 100)), "########0.0000")
                        cus2dp = Format(round2(CDec(cus1dp) * (1 + ma.txtGrsMgn.Text / 100)), "########0.0000")
                    Else
                        'cus2dp = Format(roundup(CDec(cus1dp) / (1 - ma.txtGrsMgn.Text / 100)), "########0.0000")
                        cus2dp = Format(round2(CDec(cus1dp) / (1 - ma.txtGrsMgn.Text / 100)), "########0.0000")
                    End If
                End If
            End If
        End If

        '*** Conversion Factor
        'S = "㊣CUBASINF_Q※S※" & txtUMM.Text & "※Conversion"
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gsCompany = Trim(ma.cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_CUBASINF_Q '" & ma.cboCoCde.Text & "','" & txtUMM.Text & "','Conversion'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYCONFTR, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading updateAll sp_select_CUBASINF_Q :" & rtnStr)
            Exit Sub
        End If

        If rs_SYCONFTR.Tables("RESULT").Rows.Count = 0 Then
            smpunt = txtUMM.Text
            smpprc = cus1dp
        Else
            smpunt = "PC"
            'smpprc = Format(roundup(cus1dp / rs_SYCONFTR.Tables("RESULT").Rows(0)("ycf_value")), "########0.0000")
            smpprc = Format(round2(cus1dp / rs_SYCONFTR.Tables("RESULT").Rows(0)("ycf_value")), "########0.0000")
        End If

        If isABUAssortment(txtItmNoO.Text) = True Then
            smpunt = "PC"
            If cus1dp = 0 Then
                smpprc = cus1dp
            Else
                'smpprc = Format(roundup(cus1dp / txtUMftr.Text), "###,###,##0.0000")
                smpprc = Format(round2(cus1dp / txtUMftr.Text), "###,###,##0.0000")
            End If
        End If
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        If txtItmNoM.Text = "" Then
            MsgBox("Please input Item No.")
            If txtItmNoM.Enabled And txtItmNoM.Visible Then txtItmNoM.Focus()
            Exit Sub
        End If

        If cboColCdeM.Text = "" Then
            MsgBox("Color Code must be assigned.")
            If cboColCdeM.Enabled And cboColCdeM.Visible Then
                cboColCdeM.Focus()
            End If
            Exit Sub
        End If

        If cboPckingM.Text = "" Then
            MsgBox("Packing must be assigned.")
            If cboPckingM.Enabled And cboPckingM.Visible Then
                cboPckingM.Focus()
            End If
            Exit Sub
        End If

        '*** Check Dupliate Packing
        If check_dup_Packing = True Then
            MsgBox("The Packing & Color are already exists.")
            Exit Sub
        End If

        Dim cus2no As String

        If ma.cboCus2No.Text = "" Then
            cus2no = ""
        Else
            cus2no = Microsoft.VisualBasic.Left(ma.cboCus2No.Text, InStr(ma.cboCus2No.Text, " - ") - 1)
        End If

        'S = "㊣CUITMSUM_Q※S※" & Left(QUM00001.cboCus1No.Text, InStr(QUM00001.cboCus1No.Text, " - ") - 1) & "※" & _
        '    cus2no & "※" & _
        '    txtItmNoM.Text & "※" & cboColCdeM.Text & "※" & txtUMM.Text & "※" & txtInrQtyM.Text & "※" & _
        '    txtMtrQtyM.Text & "※" & IIf(txtUMftr.Text = "", 1, txtUMftr.Text) & "※" & gsUsrID
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gsCompany = Trim(ma.cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_CUITMSUM_Q '" & ma.cboCoCde.Text & "','" & _
                                            Microsoft.VisualBasic.Left(ma.cboCus1No.Text, InStr(ma.cboCus1No.Text, " - ") - 1) & "','" & _
                                            cus2no & "','" & txtItmNoM.Text & "','" & cboColCdeM.Text & "','" & _
                                            txtUMM.Text & "','" & txtInrQtyM.Text & "','" & _
                                            txtMtrQtyM.Text & "','" & _
                                            IIf(txtUMftr.Text = "", 1, txtUMftr.Text) & "','" & gsUsrID & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUITMSUM, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading cboPcking_MouseUp sp_select_CUITMSUM_Q :" & rtnStr)
            Exit Sub
        End If

        If rs_CUITMSUM.Tables("RESULT").Rows.Count > 0 Then
            cuscol = rs_CUITMSUM.Tables("RESULT").Rows(0)("cis_cuscol")
            cusitm = rs_CUITMSUM.Tables("RESULT").Rows(0)("cis_cusitm")
            coldsc = rs_CUITMSUM.Tables("RESULT").Rows(0)("cis_coldsc")
            hstRef = rs_CUITMSUM.Tables("RESULT").Rows(0)("cis_refdoc")
            cususd = rs_CUITMSUM.Tables("RESULT").Rows(0)("cis_cususd")
            cuscad = rs_CUITMSUM.Tables("RESULT").Rows(0)("cis_cuscad")
            txtcontopc = rs_CUITMSUM.Tables("RESULT").Rows(0)("cis_contopc")
            txtPCPrc = rs_CUITMSUM.Tables("RESULT").Rows(0)("cis_pcprc")

            dept = rs_CUITMSUM.Tables("RESULT").Rows(0)("cis_dept")
            If rs_CUITMSUM.Tables("RESULT").Rows(0)("cis_hrmcde").ToString <> "" Then
                hrmcde = rs_CUITMSUM.Tables("RESULT").Rows(0)("cis_hrmcde")

                dr = ma.rs_SYHRMCDE.Tables("RESULT").Select("yhc_hrmcde = " & "'" & hrmcde & "'")

                If dr.Length > 0 Then
                    hrmcde = dr(0)("yhc_hrmcde").ToString + " - " + _
                                        dr(0)("yhc_hrmdsc").ToString + _
                                        IIf(dr(0)("yhc_tarzon").ToString = "U", " (HSTU # for USA)", " (Tariff # for Europe)")
                    dtyrat = dr(0)("yhc_dtyrat")
                End If
                dtyrat = rs_CUITMSUM.Tables("RESULT").Rows(0)("cis_dtyrat")
            End If
        End If

        ma.rs_QUOTNDTL.Tables("RESULT").Rows(ma.sReadingIndexQ)("qud_itmtyp") = ITMTYP
        ma.txtItmNo.Text = txtItmNoM.Text
        '
        Dim cus1no As String
        Dim rs As New DataSet

        If Trim(ma.cboCus1No.Text) = "" Then
            cus1no = ""
        Else
            cus1no = Trim(Split(ma.cboCus1No.Text, "-")(0))
        End If

        If Trim(ma.cboCus2No.Text) = "" Then
            cus2no = ""
        Else
            cus2no = Trim(Split(ma.cboCus2No.Text, "-")(0))
        End If

        'S = "㊣QUOTNDTL_Vendor_P_wCust※S※" & txtItmNoM.Text & "※" & txtUMM.Text & "※" & _
        '    txtInrQtyM.Text & "※" & txtMtrQtyM.Text & "※" & IIf(txtUMftr.Text = "", 1, txtUMftr.Text) & "※" & cus1no & "※" & cus2no & "※" & gsUsrID
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gsCompany = Trim(ma.cboCoCde.Text)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_QUOTNDTL_Vendor '" & ma.cboCoCde.Text & "','" & _
                                                txtItmNoM.Text & "','" & _
                                                txtUMM.Text & "','" & _
                                                txtInrQtyM.Text & "','" & _
                                                txtMtrQtyM.Text & "','" & _
                                                cus1no & "','" & cus2no & "','" & gsUsrID & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading CalculatePrc sp_select_QUOTNDTL_Vendor :" & rtnStr)
            Exit Sub
        End If

        If rs.Tables("RESULT").Rows.Count > 0 Then
            ma.cboDtlPrcTrm.Text = rs.Tables("RESULT").Rows(0)("imu_prctrm")
            ma.cboFtyPrcTrm.Text = rs.Tables("RESULT").Rows(0)("imu_ftyprctrm")   ' update factory price term
        Else
            ma.cboDtlPrcTrm.Text = ""
            ma.cboFtyPrcTrm.Text = ""    ' update factory price term
        End If

        ma.txtItmDsc.Text = itmdsc
        ma.cboColCde.Items.Clear()
        ma.cboColCde.Text = cboColCdeM.Text
        ma.cboColCde.Enabled = False
        ma.txtCusCol.Text = cuscol
        ma.txtCusItm.Text = cusitm
        ma.txtColDsc.Text = coldsc
        ma.cboPcking.Items.Clear()
        ma.cboPcking.Text = cboPckingM.Text
        ma.cboPcking.Enabled = False
        '.Text = hstRef
        ma.txtInrQty.Text = txtInrQtyM.Text
        ma.txtMtrQty.Text = txtMtrQtyM.Text
        ma.txtCft.Text = txtCftM.Text
        ma.txtUMFtr.Text = txtUMftr.Text
        ma.chkPC.Checked = False
        ma.chkPC.Checked = IIf(txtcontopc = "Y", True, False)

        '*** Update MOQ/MOA value base on MOQ/MOA Flag
        ma.ORI_MOFLAG = ORI_MOFLAG
        ma.ORI_MOQ = ORI_MOQ
        ma.ORI_MOA = ORI_MOA

        If Trim(strMOQUNTTYP) <> "" Then
            ma.lblCurrMOQ.Text = strMOQUNTTYP & " ="
            'ma.Label4.Caption = strMOQUNTTYP & " ="
        Else
            ma.lblCurrMOQ.Text = strMOQUNTTYP
            'ma.Label4.Caption = strMOQUNTTYP
        End If

        ma.optMOQ.Checked = False
        ma.optMOA.Checked = False

        ma.optMOQ.Enabled = False
        ma.optMOQ.Enabled = False

        If ORI_MOFLAG = "Q" Then
            ma.optMOQ.Checked = True

            ma.txtMoa.Enabled = False
            ma.txtMoq.Enabled = True

            ma.txtMoq.Text = ORI_MOQ
            ma.txtMoa.Text = ""
        ElseIf ORI_MOFLAG = "A" Then
            ma.optMOA.Checked = True

            ma.optMOQ.Enabled = True
            ma.optMOA.Enabled = True

            ma.txtMoq.Enabled = False
            ma.txtMoa.Enabled = True

            ma.txtMoq.Text = ORI_MOQ
            ma.txtMoa.Text = Format(ORI_MOA, "###,###,##0")
        End If

        '*** Cal MOQ Amount
        ma.txtAmountMOQ.Text = ORI_MOQ * cus1sp * Val(IIf(txtMtrQtyM.Text = "", 0, txtMtrQtyM.Text))
        ma.cboUM.Text = txtUMM.Text
        ma.cboItmSts.Text = itmsts
        ma.txtQutItmSts.Text = "COMPLETE"
        ma.txtPckItr.Text = pckitr
        ma.txtDiscnt.Text = "0"

        ma.txtCus1Sp.Text = Format(cus1sp, "###,###,##0.0000")
        ma.txtCus1Dp.Text = Format(cus1dp, "###,###,##0.0000")
        ma.txtCus2Sp.Text = Format(cus2sp, "###,###,##0.0000")
        ma.txtCus2Dp.Text = Format(cus2dp, "###,###,##0.0000")
        ma.cboHrmCde.Text = hrmcde
        ma.txtDtyRat.Text = dtyrat
        ma.txtSmpPrc.Text = Format(smpprc, "###,###,##0.0000")
        ma.txtSmpUnt.Text = smpunt

        If cususd = 0 Then
            ma.txtCusUsd.Text = ""
        Else
            ma.txtCusUsd.Text = cususd
        End If
        If cuscad = 0 Then
            ma.txtCusCad.Text = ""
        Else
            ma.txtCusCad.Text = cuscad
        End If

        ma.txtDept.Text = dept
        ma.cboVenNo.Text = venno
        ma.txtSubCde.Text = subcde
        '*** show Custom Vendor and Sub Code
        ma.cboCusVen.Text = CusVenNo
        ma.txtCusSub.Text = ""

        ma.txtVenItm.Text = venitm
        ma.txtFCurCde.Text = fcurcde
        ma.txtFtyPrc.Text = ftyprc
        ma.txtFtyCst.Text = ftycst
        ma.chkTBM.Checked = False
        ma.cmdTBM.Enabled = False
        If img = "Y" Then
            ma.optImageY.Checked = True
            ma.optImageN.Checked = False
        Else
            ma.optImageY.Checked = False
            ma.optImageN.Checked = True
        End If
        ma.txtCosMth.Text = cosmth

        ma.rs_QUOTNDTL.Tables("RESULT").Rows(ma.sReadingIndexQ)("qud_tbmsts") = "CMP"
        If ma.rs_QUOTNDTL.Tables("RESULT").Rows(ma.sReadingIndexQ)("mode").ToString <> "NEW" Then
            ma.rs_QUOTNDTL.Tables("RESULT").Rows(ma.sReadingIndexQ)("mode") = "UPD"
        End If

        ma.rs_QUOTNDTL.Tables("RESULT").Rows(ma.sReadingIndexQ)("qud_basprc") = basprc
        ma.rs_QUOTNDTL.Tables("RESULT").Rows(ma.sReadingIndexQ)("qud_pckseq") = rs_IMPCKINF.Tables("RESULT").Rows(sReadingIndexP)("ipi_pckseq")
        ma.rs_QUOTNDTL.Tables("RESULT").Rows(ma.sReadingIndexQ)("qud_inrdin") = rs_IMPCKINF.Tables("RESULT").Rows(sReadingIndexP)("ipi_inrdin")
        ma.rs_QUOTNDTL.Tables("RESULT").Rows(ma.sReadingIndexQ)("qud_inrwin") = rs_IMPCKINF.Tables("RESULT").Rows(sReadingIndexP)("ipi_inrwin")
        ma.rs_QUOTNDTL.Tables("RESULT").Rows(ma.sReadingIndexQ)("qud_inrhin") = rs_IMPCKINF.Tables("RESULT").Rows(sReadingIndexP)("ipi_inrhin")
        ma.rs_QUOTNDTL.Tables("RESULT").Rows(ma.sReadingIndexQ)("qud_mtrdin") = rs_IMPCKINF.Tables("RESULT").Rows(sReadingIndexP)("ipi_mtrdin")
        ma.rs_QUOTNDTL.Tables("RESULT").Rows(ma.sReadingIndexQ)("qud_mtrwin") = rs_IMPCKINF.Tables("RESULT").Rows(sReadingIndexP)("ipi_mtrwin")
        ma.rs_QUOTNDTL.Tables("RESULT").Rows(ma.sReadingIndexQ)("qud_mtrhin") = rs_IMPCKINF.Tables("RESULT").Rows(sReadingIndexP)("ipi_mtrhin")
        ma.rs_QUOTNDTL.Tables("RESULT").Rows(ma.sReadingIndexQ)("qud_inrdcm") = rs_IMPCKINF.Tables("RESULT").Rows(sReadingIndexP)("ipi_inrdcm")
        ma.rs_QUOTNDTL.Tables("RESULT").Rows(ma.sReadingIndexQ)("qud_inrwcm") = rs_IMPCKINF.Tables("RESULT").Rows(sReadingIndexP)("ipi_inrwcm")
        ma.rs_QUOTNDTL.Tables("RESULT").Rows(ma.sReadingIndexQ)("qud_inrhcm") = rs_IMPCKINF.Tables("RESULT").Rows(sReadingIndexP)("ipi_inrhcm")
        ma.rs_QUOTNDTL.Tables("RESULT").Rows(ma.sReadingIndexQ)("qud_mtrdcm") = rs_IMPCKINF.Tables("RESULT").Rows(sReadingIndexP)("ipi_mtrdcm")
        ma.rs_QUOTNDTL.Tables("RESULT").Rows(ma.sReadingIndexQ)("qud_mtrwcm") = rs_IMPCKINF.Tables("RESULT").Rows(sReadingIndexP)("ipi_mtrwcm")
        ma.rs_QUOTNDTL.Tables("RESULT").Rows(ma.sReadingIndexQ)("qud_mtrhcm") = rs_IMPCKINF.Tables("RESULT").Rows(sReadingIndexP)("ipi_mtrhcm")
        ma.rs_QUOTNDTL.Tables("RESULT").Rows(ma.sReadingIndexQ)("inner_in") = Format(Str(rs_IMPCKINF.Tables("RESULT").Rows(sReadingIndexP)("ipi_inrdin")), "######0.####") + "x" + _
                                                Format(Str(rs_IMPCKINF.Tables("RESULT").Rows(sReadingIndexP)("ipi_inrwin")), "######0.####") + "x" + _
                                                Format(Str(rs_IMPCKINF.Tables("RESULT").Rows(sReadingIndexP)("ipi_inrwin")), "######0.####")
        ma.rs_QUOTNDTL.Tables("RESULT").Rows(ma.sReadingIndexQ)("master_in") = Format(Str(rs_IMPCKINF.Tables("RESULT").Rows(sReadingIndexP)("ipi_mtrdin")), "######0.####") + "x" + _
                                                 Format(Str(rs_IMPCKINF.Tables("RESULT").Rows(sReadingIndexP)("ipi_mtrwin")), "######0.####") + "x" + _
                                                 Format(Str(rs_IMPCKINF.Tables("RESULT").Rows(sReadingIndexP)("ipi_mtrwin")), "######0.####")
        ma.rs_QUOTNDTL.Tables("RESULT").Rows(ma.sReadingIndexQ)("inner_cm") = Format(Str(rs_IMPCKINF.Tables("RESULT").Rows(sReadingIndexP)("ipi_inrdcm")), "######0.####") + "x" + _
                                                Format(Str(rs_IMPCKINF.Tables("RESULT").Rows(sReadingIndexP)("ipi_inrwcm")), "######0.####") + "x" + _
                                                Format(Str(rs_IMPCKINF.Tables("RESULT").Rows(sReadingIndexP)("ipi_inrwcm")), "######0.####")
        ma.rs_QUOTNDTL.Tables("RESULT").Rows(ma.sReadingIndexQ)("master_cm") = Format(Str(rs_IMPCKINF.Tables("RESULT").Rows(sReadingIndexP)("ipi_mtrdcm")), "######0.####") + "x" + _
                                                 Format(Str(rs_IMPCKINF.Tables("RESULT").Rows(sReadingIndexP)("ipi_mtrwcm")), "######0.####") + "x" + _
                                                 Format(Str(rs_IMPCKINF.Tables("RESULT").Rows(sReadingIndexP)("ipi_mtrwcm")), "######0.####")
        ma.rs_QUOTNDTL.Tables("RESULT").Rows(ma.sReadingIndexQ)("qud_grswgt") = Format(rs_IMPCKINF.Tables("RESULT").Rows(sReadingIndexP)("ipi_grswgt"), "##0.###")
        ma.rs_QUOTNDTL.Tables("RESULT").Rows(ma.sReadingIndexQ)("qud_netwgt") = Format(rs_IMPCKINF.Tables("RESULT").Rows(sReadingIndexP)("ipi_netwgt"), "##0.###")

        If txtcontopc = "Y" Then
            ma.txtPCPrcGotFocus()
            ma.txtPCPrc.Text = txtPCPrc
            ma.txtPCPrcLostFocus()
        End If

        '*** Mark DEL to the Old one
        If ma.rs_QUCPTBKD.Tables("RESULT").DefaultView.Count > 0 Then
            For index As Integer = 0 To ma.rs_QUCPTBKD.Tables("RESULT").DefaultView.Count - 1
                ma.rs_QUCPTBKD.Tables("RESULT").DefaultView(index)("mode") = "DEL"
            Next
            ma.dgMatBkd.DataSource = Nothing
        End If

        '*** Component Breakdown
        If rs_IMMATBKD.Tables("RESULT").Rows.Count > 0 Then
            For index As Integer = 0 To rs_IMMATBKD.Tables("RESULT").Rows.Count - 1
                drNewRow = ma.rs_QUCPTBKD.Tables("RESULT").NewRow
                drNewRow("mode") = "NEW"
                drNewRow("Del") = " "
                drNewRow("qcb_qutno") = ma.txtQutNo.Text
                drNewRow("qcb_qutseq") = ma.txtSeq.Text
                drNewRow("qcb_itmno") = ma.txtItmNo.Text
                drNewRow("qcb_cptseq") = rs_IMMATBKD.Tables("RESULT").Rows(index)("ibm_matseq")
                drNewRow("qcb_cpt") = rs_IMMATBKD.Tables("RESULT").Rows(index)("ibm_mat")
                drNewRow("qcb_curcde") = rs_IMMATBKD.Tables("RESULT").Rows(index)("ibm_curcde")
                drNewRow("qcb_cst") = rs_IMMATBKD.Tables("RESULT").Rows(index)("ibm_cst")
                drNewRow("qcb_cstpct") = rs_IMMATBKD.Tables("RESULT").Rows(index)("ibm_cstper")
                drNewRow("qcb_pct") = rs_IMMATBKD.Tables("RESULT").Rows(index)("ibm_wgtper")
                ma.rs_QUCPTBKD.Tables("RESULT").Rows.Add(drNewRow)
            Next

            If ma.txtSeq.Text <> "" Then
                sFilter = "qcb_qutseq = " & ma.txtSeq.Text & " and mode = 'NEW'"
            Else
                sFilter = ""
            End If
            ma.rs_QUCPTBKD.Tables("RESULT").DefaultView.RowFilter = sFilter

            ma.dgMatBkd.DataSource = ma.rs_QUCPTBKD.Tables("RESULT").DefaultView
            Call Display_Component()
        End If

        '*** Mark DEL to the Old one
        If ma.rs_QUASSINF.Tables("RESULT").DefaultView.Count > 0 Then
            For index As Integer = 0 To ma.rs_QUASSINF.Tables("RESULT").DefaultView.Count - 1
                If ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(ma.sReadingIndexQ)("mode").ToString = "NEW" Then
                    ma.rs_QUASSINF.Tables("RESULT").DefaultView(index).Delete()
                Else
                    ma.rs_QUASSINF.Tables("RESULT").DefaultView(index)("mode") = "DEL"
                End If
            Next
            ma.rs_QUASSINF.Tables("RESULT").AcceptChanges()
        End If

        '*** Assortment Item
        If rs_IMBOMASS.Tables("RESULT").Rows.Count = 0 Then
            ma.cmdAss.Enabled = False
        Else
            ma.cmdAss.Enabled = True
            For index As Integer = 0 To rs_IMBOMASS.Tables("RESULT").Rows.Count - 1
                drNewRow = ma.rs_QUASSINF.Tables("RESULT").NewRow
                drNewRow("mode") = "NEW"
                drNewRow("qai_qutno") = ma.txtQutNo.Text
                drNewRow("qai_qutseq") = ma.txtSeq.Text
                drNewRow("qai_itmno") = txtItmNoM.Text
                drNewRow("qai_assitm") = rs_IMBOMASS.Tables("RESULT").Rows(index)("iba_assitm")
                drNewRow("qai_assdsc") = rs_IMBOMASS.Tables("RESULT").Rows(index)("ibi_engdsc")
                drNewRow("qai_colcde") = rs_IMBOMASS.Tables("RESULT").Rows(index)("iba_colcde")
                drNewRow("qai_coldsc") = rs_IMBOMASS.Tables("RESULT").Rows(index)("icf_coldsc")
                drNewRow("qai_untcde") = rs_IMBOMASS.Tables("RESULT").Rows(index)("iba_pckunt")
                drNewRow("qai_inrqty") = rs_IMBOMASS.Tables("RESULT").Rows(index)("iba_inrqty")
                drNewRow("qai_mtrqty") = rs_IMBOMASS.Tables("RESULT").Rows(index)("iba_mtrqty")
                drNewRow("qai_alsitmno") = rs_IMBOMASS.Tables("RESULT").Rows(index)("ibi_alsitmno")
                drNewRow("qai_alscolcde") = rs_IMBOMASS.Tables("RESULT").Rows(index)("ibi_alscolcde")
                drNewRow("ibi_itmsts") = rs_IMBOMASS.Tables("RESULT").Rows(index)("ibi_itmsts")
                drNewRow("qai_imperiod") = rs_IMBOMASS.Tables("RESULT").Rows(index)("iba_period")
                ma.rs_QUASSINF.Tables("RESULT").Rows.Add(drNewRow)
            Next

            If ma.txtSeq.Text <> "" Then
                sFilter = "qai_qutseq = " & ma.txtSeq.Text & " and mode = 'NEW'"
                ma.rs_QUASSINF.Tables("RESULT").DefaultView.RowFilter = sFilter
            End If

            'Call Display_Assortment()
        End If

        '** Keep originally Sample Qty
        ma.txtStkQty.Text = stkqty_tmp
        ma.txtCusQty.Text = cusqty_tmp
        ma.txtSmpQty.Text = smpqty_tmp

        Dim strCusno As String
        Dim rsTmp As New DataSet

        If Trim(ma.cboCus2No.Text) <> "" Then
            strCusno = Trim(ma.cboCus2No.Text)
        Else
            strCusno = Trim(ma.cboCus1No.Text)
        End If

        ' Begin Get Cost Element
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
            MsgBox("Error on loading cmdOK_Click sp_select_cucstemt_qu :" & rtnStr)
            Exit Sub
        End If

        If rsTmp.Tables("RESULT").Rows.Count = 0 Then
            If ma.txtSeq.Text <> "" Then
                sFilter = "qce_qutseq = " & ma.txtSeq.Text & " and mode <> 'DEL'"
            Else
                sFilter = ""
            End If
            ma.rs_QUCSTEMT.Tables("RESULT").DefaultView.RowFilter = sFilter

            If ma.rs_QUCSTEMT.Tables("RESULT").DefaultView.Count > 0 Then
                Dim index As Integer = ma.rs_QUCSTEMT.Tables("RESULT").DefaultView.Count

                While index > 0
                    If ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(0)("qce_qutno").ToString = ma.txtQutNo.Text And _
                        ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(0)("qce_qutseq").ToString = ma.txtSeq.Text Then
                        ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(0).Delete()
                        index -= 1
                    End If
                End While
                ma.rs_QUCSTEMT.Tables("RESULT").AcceptChanges()
            End If
        Else
            If ma.rs_QUCSTEMT.Tables("RESULT").DefaultView.Count > 0 Then
                Dim index As Integer = ma.rs_QUCSTEMT.Tables("RESULT").DefaultView.Count

                While index > 0
                    If ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(0)("qce_qutno").ToString = ma.txtQutNo.Text And _
                        ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(0)("qce_qutseq").ToString = ma.txtSeq.Text Then
                        ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(0).Delete()
                        index -= 1
                    End If
                End While
                ma.rs_QUCSTEMT.Tables("RESULT").AcceptChanges()
            End If

            For index As Integer = 0 To rsTmp.Tables("RESULT").Rows.Count - 1
                drNewRow = ma.rs_QUCSTEMT.Tables("RESULT").NewRow
                drNewRow("mode") = "NEW"
                drNewRow("qce_qutno") = ma.txtQutNo.Text
                drNewRow("qce_qutseq") = ma.txtSeq.Text
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
                MsgBox("Error on loading cmdOK_Click sp_select_CUCSTAMT_qu :" & rtnStr)
                Exit Sub
            End If

            If rsTmp.Tables("RESULT").Rows.Count > 0 Then
                For index As Integer = 0 To ma.rs_QUCSTEMT.Tables("RESULT").DefaultView.Count - 1
                    sFilter = "cca_cecde = '" + ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(index)("qce_cecde") + "' and " + _
                                    " cca_bp2 >= " + CStr(ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(ma.sReadingIndexQ)("qud_basprc")) + _
                                    "  and cca_bp1 <= " + CStr(ma.rs_QUOTNDTL.Tables("RESULT").DefaultView(ma.sReadingIndexQ)("qud_basprc"))
                    rsTmp.Tables("RESULT").DefaultView.RowFilter = sFilter

                    If rsTmp.Tables("RESULT").DefaultView.Count > 0 Then
                        ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(index)("cce_amt_d") = ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(index)("cce_amt_d") / rsTmp.Tables("RESULT").DefaultView(0)("cca_estqty")
                        ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(index)("qce_amt") = ma.rs_QUCSTEMT.Tables("RESULT").DefaultView(index)("cce_amt_d")
                    End If
                Next
            End If

            sFilter = "qce_qutseq = " & ma.txtSeq.Text & " and mode <> 'DEL'"
            ma.rs_QUCSTEMT.Tables("RESULT").DefaultView.RowFilter = sFilter
            '.DataSource = ma.rs_QUCSTEMT.Tables("RESULT").DefaultView
            Call ShowGrdCstEmt()
        End If
        ' End Get Cost Element

        Call CalculatePrc()

        ' Refresh the price
        ma.txtDiscnt.Text = "0"
        ma.txtCus1Sp.Text = Format(cus1sp, "###,###,##0.0000")
        ma.txtCus1Dp.Text = Format(cus1dp, "###,###,##0.0000")
        ma.txtCus2Sp.Text = Format(cus2sp, "###,###,##0.0000")
        ma.txtCus2Dp.Text = Format(cus2dp, "###,###,##0.0000")

        'Begin Get ELC
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
            MsgBox("Error on loading cmdOK_Click sp_select_cuelc_qu :" & rtnStr)
            Exit Sub
        End If

        If rsTmp.Tables("RESULT").Rows.Count = 0 Then
            If ma.txtSeq.Text <> "" Then
                sFilter = "qec_qutseq = " & ma.txtSeq.Text & " and mode <> 'DEL'"
            Else
                sFilter = ""
            End If
            ma.rs_QUELC.Tables("RESULT").DefaultView.RowFilter = sFilter

            If ma.rs_QUELC.Tables("RESULT").DefaultView.Count > 0 Then
                Dim index As Integer = ma.rs_QUELC.Tables("RESULT").DefaultView.Count

                While index > 0
                    If ma.rs_QUELC.Tables("RESULT").DefaultView(0)("qec_qutno").ToString = ma.txtQutNo.Text And _
                        ma.rs_QUELC.Tables("RESULT").DefaultView(0)("qec_qutseq").ToString = ma.txtSeq.Text Then
                        ma.rs_QUELC.Tables("RESULT").DefaultView(0).Delete()
                        index -= 1
                    End If
                End While
                ma.rs_QUELC.Tables("RESULT").AcceptChanges()
            End If
        Else
            If ma.rs_QUELC.Tables("RESULT").DefaultView.Count > 0 Then
                Dim index As Integer = ma.rs_QUELC.Tables("RESULT").DefaultView.Count

                While index > 0
                    If ma.rs_QUELC.Tables("RESULT").DefaultView(0)("qec_qutno").ToString = ma.txtQutNo.Text And _
                        ma.rs_QUELC.Tables("RESULT").DefaultView(0)("qec_qutseq").ToString = ma.txtSeq.Text Then
                        ma.rs_QUELC.Tables("RESULT").DefaultView(0).Delete()
                        index -= 1
                    End If
                End While
                ma.rs_QUELC.Tables("RESULT").AcceptChanges()
            End If

            If rsTmp.Tables("RESULT").Rows.Count > 0 Then
                For index As Integer = 0 To rsTmp.Tables("RESULT").Rows.Count - 1
                    drNewRow = ma.rs_QUELC.Tables("RESULT").NewRow
                    drNewRow("mode") = "NEW"
                    drNewRow("qec_qutno") = ma.txtQutNo.Text
                    drNewRow("qec_qutseq") = ma.txtSeq.Text
                    drNewRow("qec_grpcde") = rsTmp.Tables("RESULT").Rows(index)("cec_grpcde")
                    drNewRow("cec_grpdsc") = rsTmp.Tables("RESULT").Rows(index)("cec_grpdsc")
                    drNewRow("qec_curcde") = ma.txtCurCde2.Text
                    drNewRow("qec_amt") = 0
                    ma.rs_QUELC.Tables("RESULT").Rows.Add(drNewRow)
                Next
                ma.rs_QUELC.Tables("RESULT").AcceptChanges()
            End If

            sFilter = "qec_qutseq = " & ma.txtSeq.Text & " and mode <> 'DEL'"
            ma.rs_QUELC.Tables("RESULT").DefaultView.RowFilter = sFilter
            '.DataSource = ma.rs_QUELC.Tables("RESULT").DefaultView
            Call ShowGrdELC()
        End If
        ' End Get ELC

        'Begin Get ELCDTL
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
            MsgBox("Error on loading cmdOK_Click sp_select_cuelcdtl_qu :" & rtnStr)
            Exit Sub
        End If

        If rsTmp.Tables("RESULT").Rows.Count = 0 Then
            If ma.txtSeq.Text <> "" Then
                sFilter = "qed_qutseq = " & ma.txtSeq.Text & " and mode <> 'DEL'"
            Else
                sFilter = ""
            End If
            ma.rs_QUELCDTL.Tables("RESULT").DefaultView.RowFilter = sFilter

            If ma.rs_QUELCDTL.Tables("RESULT").DefaultView.Count > 0 Then
                Dim index As Integer = ma.rs_QUELCDTL.Tables("RESULT").DefaultView.Count

                While index > 0
                    If ma.rs_QUELCDTL.Tables("RESULT").DefaultView(0)("qed_qutno").ToString = ma.txtQutNo.Text And _
                        ma.rs_QUELCDTL.Tables("RESULT").DefaultView(0)("qed_qutseq").ToString = ma.txtSeq.Text Then
                        ma.rs_QUELCDTL.Tables("RESULT").DefaultView(0).Delete()
                        index -= 1
                    End If
                End While
                ma.rs_QUELCDTL.Tables("RESULT").AcceptChanges()
            End If
        Else
            If ma.rs_QUELCDTL.Tables("RESULT").DefaultView.Count > 0 Then
                Dim index As Integer = ma.rs_QUELCDTL.Tables("RESULT").DefaultView.Count

                While index > 0
                    If ma.rs_QUELCDTL.Tables("RESULT").DefaultView(0)("qed_qutno").ToString = ma.txtQutNo.Text And _
                        ma.rs_QUELCDTL.Tables("RESULT").DefaultView(0)("qed_qutseq").ToString = ma.txtSeq.Text Then
                        ma.rs_QUELCDTL.Tables("RESULT").DefaultView(0).Delete()
                        index -= 1
                    End If
                End While
            End If


            For index As Integer = 0 To rsTmp.Tables("RESULT").Rows.Count - 1
                drNewRow = ma.rs_QUELCDTL.Tables("RESULT").NewRow
                drNewRow("mode") = "NEW"
                drNewRow("qed_qutno") = ma.txtQutNo.Text
                drNewRow("qed_qutseq") = ma.txtSeq.Text
                drNewRow("qed_grpcde") = rsTmp.Tables("RESULT").Rows(index)("ced_grpcde")
                drNewRow("ced_grpdsc") = rsTmp.Tables("RESULT").Rows(index)("ced_grpdsc")
                drNewRow("qed_seq") = rsTmp.Tables("RESULT").Rows(index)("ced_seq")
                drNewRow("qed_cecde") = rsTmp.Tables("RESULT").Rows(index)("ced_cecde")
                drNewRow("ced_cedsc") = rsTmp.Tables("RESULT").Rows(index)("ced_cedsc")
                drNewRow("qed_percent") = rsTmp.Tables("RESULT").Rows(index)("ced_percent")
                drNewRow("ced_chg") = rsTmp.Tables("RESULT").Rows(index)("ced_chg")
                drNewRow("qed_curcde") = ma.txtCurCde2.Text
                drNewRow("qed_amt") = 0
                ma.rs_QUELCDTL.Tables("RESULT").Rows.Add(drNewRow)
                Call CalculateELC()
            Next
            ma.rs_QUELCDTL.Tables("RESULT").AcceptChanges()

            sFilter = "qed_qutseq = " & ma.txtSeq.Text & " and mode <> 'DEL'"
            ma.rs_QUELCDTL.Tables("RESULT").DefaultView.RowFilter = sFilter
            '.DataSource = ma.rs_QUELCDTL.Tables("RESULT").DefaultView
            Call ShowGrdELCDtl()
        End If
        ' End Get ELCDTL

        '.Items.Clear()
        '.Text = ""
        Call SetCustItmCat()
        ma.rs_QUOTNDTL.Tables("RESULT").Rows(ma.sReadingIndexQ)("qud_specpck") = ""
        ma.txtIMRmk.Text = txtIMRmk
        ma.cboCusals.Text = GetCusSty(ma.txtItmNo.Text, Microsoft.VisualBasic.Left(ma.cboCus1No.Text, InStr(ma.cboCus1No.Text, " - ") - 1))

        Me.Close()
    End Sub

    Private Function check_dup_Packing() As Boolean
        '*** Check duplicate packing
        If ma.rs_QUOTNDTL.Tables("RESULT").Rows.Count > 0 Then
            Dim tmp As Integer
            Dim tmp_itmno As String
            Dim tmp_colcde As String
            Dim tmp_inrqty As String
            Dim tmp_mtrqty As String
            Dim tmp_untcde As String
            Dim is_Dup As Boolean
            Dim tmp_cbo As Integer

            is_Dup = False
            tmp = ma.sReadingIndexQ
            tmp_itmno = txtItmNoM.Text
            tmp_colcde = cboColCdeM.Text
            tmp_inrqty = txtInrQtyM.Text
            tmp_mtrqty = txtMtrQtyM.Text
            tmp_untcde = txtUMM.Text
            tmp_cbo = cboPckingM.SelectedIndex

            ma.no_Display_Detail = True

            For index As Integer = 0 To ma.rs_QUOTNDTL.Tables("RESULT").Rows.Count - 1
                If index <> tmp Then
                    If tmp_itmno = ma.rs_QUOTNDTL.Tables("RESULT").Rows(index)("qud_itmno").ToString And _
                           tmp_colcde = ma.rs_QUOTNDTL.Tables("RESULT").Rows(index)("qud_colcde").ToString And _
                           tmp_inrqty = LTrim(ma.rs_QUOTNDTL.Tables("RESULT").Rows(index)("qud_inrqty").ToString) And _
                           tmp_mtrqty = LTrim(ma.rs_QUOTNDTL.Tables("RESULT").Rows(index)("qud_mtrqty").ToString) And _
                           tmp_untcde = ma.rs_QUOTNDTL.Tables("RESULT").Rows(index)("qud_untcde").ToString Then
                        is_Dup = True
                        Exit For
                    End If
                End If
            Next

            ma.no_Display_Detail = True

            If is_Dup = True Then
                check_dup_Packing = True
                cboColCdeM.Text = ""
                cboPckingM.Text = ""
                txtInrQtyM.Text = ""
                txtMtrQtyM.Text = ""
                txtUMM.Text = ""
                txtCftM.Text = ""
            Else
                check_dup_Packing = False
            End If
            is_Dup = False
        End If
    End Function

    Private Sub Display_Component()
        Dim intCol As Integer

        intCol = 0

        With ma.dgMatBkd
            .Columns(intCol).HeaderText = "Del"
            .Columns(intCol).Width = 50
            '.Columns(intCol).Button = True
            .Columns(intCol).Visible = True
            .Columns(intCol).ReadOnly = False
            intCol = intCol + 1

            .Columns(intCol).Visible = False
            .Columns(intCol).Width = 0
            .Columns(intCol).ReadOnly = True
            intCol = intCol + 1

            .Columns(intCol).Visible = False
            .Columns(intCol).Width = 0
            .Columns(intCol).ReadOnly = True
            intCol = intCol + 1

            .Columns(intCol).Visible = False
            .Columns(intCol).Width = 0
            .Columns(intCol).ReadOnly = True
            intCol = intCol + 1

            .Columns(intCol).Visible = False
            .Columns(intCol).Width = 0
            .Columns(intCol).ReadOnly = True
            intCol = intCol + 1

            .Columns(intCol).Visible = False
            .Columns(intCol).Width = 0
            .Columns(intCol).ReadOnly = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Material"
            .Columns(intCol).Width = 150
            .Columns(intCol).ReadOnly = False
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Curr."
            .Columns(intCol).ReadOnly = False
            .Columns(intCol).Width = 80
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Cost$"
            .Columns(intCol).ReadOnly = False
            .Columns(intCol).Width = 80
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "Cost%"
            .Columns(intCol).ReadOnly = False
            .Columns(intCol).Width = 80
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).HeaderText = "WGT%"
            .Columns(intCol).ReadOnly = False
            .Columns(intCol).Width = 80
            .Columns(intCol).Visible = True
            intCol = intCol + 1

            .Columns(intCol).Visible = False
            .Columns(intCol).Width = 0
            .Columns(intCol).ReadOnly = True
            intCol = intCol + 1

            .Columns(intCol).Visible = False
            .Columns(intCol).Width = 0
            .Columns(intCol).ReadOnly = True
            intCol = intCol + 1

            .Columns(intCol).Visible = False
            .Columns(intCol).Width = 0
            .Columns(intCol).ReadOnly = True
            intCol = intCol + 1

            .Columns(intCol).Visible = False
            .Columns(intCol).Width = 0
            .Columns(intCol).ReadOnly = True
            intCol = intCol + 1

            .Columns(intCol).Visible = False
            .Columns(intCol).Width = 0
            .Columns(intCol).ReadOnly = True
            intCol = intCol + 1

            .Columns(intCol).Visible = False
            .Columns(intCol).Width = 0
            .Columns(intCol).ReadOnly = True
            intCol = intCol + 1
        End With
    End Sub

    'Private Sub Display_Assortment()
    '    Dim i As Integer

    '    i = 3

    '    With ma.dgAss
    '        .Columns(0).Visible = False
    '        .Columns(1).Visible = False
    '        .Columns(2).Visible = False

    '        .Columns(3).Visible = False

    '        .Columns(4).HeaderText = "Assorted Item"
    '        .Columns(4).ReadOnly = True
    '        .Columns(4).width = 130

    '        .Columns(5).HeaderText = "Assorted Item Description"
    '        .Columns(5).width = 190

    '        .Columns(6).HeaderText = "Cust. Item"
    '        .Columns(6).width = 130

    '        .Columns(7).HeaderText = "Color Code"
    '        .Columns(7).ReadOnly = True
    '        .Columns(7).width = 140

    '        .Columns(8).HeaderText = "Color Desc."
    '        .Columns(8).width = 190

    '        .Columns(9).HeaderText = "Alias No."
    '        .Columns(9).ReadOnly = True
    '        .Columns(9).width = 0
    '        .Columns(9).Visible = False

    '        .Columns(10).HeaderText = "Alias Color Code"
    '        .Columns(10).ReadOnly = True
    '        .Columns(10).width = 0
    '        .Columns(10).Visible = False

    '        .Columns(11).HeaderText = "Item Status"
    '        .Columns(11).ReadOnly = True
    '        .Columns(11).width = 150

    '        .Columns(9 + i).HeaderText = "SKU #"
    '        .Columns(9 + i).width = 110

    '        .Columns(10 + i).HeaderText = "UPC/EAN #"
    '        .Columns(10 + i).width = 110

    '        .Columns(11 + i).HeaderText = "Cust. Retail"
    '        .Columns(11 + i).width = 90

    '        .Columns(12 + i).HeaderText = "UM"
    '        .Columns(12 + i).ReadOnly = True
    '        .Columns(12 + i).width = 70

    '        .Columns(13 + i).HeaderText = "Inner"
    '        .Columns(13 + i).ReadOnly = True
    '        .Columns(13 + i).width = 80

    '        .Columns(14 + i).HeaderText = "Master"
    '        .Columns(14 + i).ReadOnly = True
    '        .Columns(14 + i).width = 80

    '        .Columns(15 + i).Visible = False
    '    End With
    'End Sub

    Private Sub ShowGrdCstEmt()
        Dim i As Integer

        'With ma.dgCstEmt
        '    If ma.rs_QUCSTEMT.Tables("RESULT").Rows.Count > 0 Then
        '        For i = 0 To ma.rs_QUCSTEMT.Tables("RESULT").Columns.Count - 1
        '            .Columns(i).Width = 0
        '            .Columns(i).ReadOnly = True
        '            .Columns(i).Visible = False
        '        Next

        '        .Columns(4).Width = 200
        '        .Columns(4).HeaderText = "Cost Element"
        '        .Columns(4).ReadOnly = True
        '        .Columns(4).Visible = True
        '        .Columns(5).Width = 50
        '        .Columns(5).HeaderText = ""
        '        .Columns(5).ReadOnly = True
        '        .Columns(5).Visible = True
        '        .Columns(6).Width = 50
        '        .Columns(6).HeaderText = "%"
        '        .Columns(6).ReadOnly = False
        '        .Columns(6).Visible = True
        '        .Columns(7).Width = 50
        '        .Columns(7).HeaderText = ""
        '        .Columns(7).ReadOnly = True
        '        .Columns(7).Visible = True
        '        .Columns(8).Width = 80
        '        .Columns(8).HeaderText = ""
        '        .Columns(8).ReadOnly = True
        '        .Columns(8).Visible = True
        '        .Columns(9).Width = 80
        '        .Columns(9).HeaderText = "Amt"
        '        .Columns(9).ReadOnly = False
        '        .Columns(9).Visible = True
        '    End If
        'End With
    End Sub

    Private Sub ShowGrdELC()
        Dim i As Integer

        'With ma.dgELC
        '    If ma.rs_QUELC.Tables("RESULT").Rows.Count > 0 Then
        '        For i = 0 To ma.rs_QUELC.Tables("RESULT").Columns.Count - 1
        '            .Columns(i).Width = 0
        '            .Columns(i).ReadOnly = True
        '            .Columns(i).Visible = False
        '        Next

        '        .Columns(3).Width = 60
        '        .Columns(3).HeaderText = "Group"
        '        .Columns(3).ReadOnly = True
        '        .Columns(3).Visible = True
        '        .Columns(4).Width = 120
        '        .Columns(4).HeaderText = "Desc"
        '        .Columns(4).ReadOnly = True
        '        .Columns(4).Visible = True
        '        .Columns(5).Width = 60
        '        .Columns(5).HeaderText = "Curr."
        '        .Columns(5).ReadOnly = True
        '        .Columns(5).Visible = True
        '        .Columns(6).Width = 100
        '        .Columns(6).HeaderText = "Total Amt"
        '        .Columns(6).ReadOnly = True
        '        .Columns(6).Visible = True
        '    End If
        'End With
    End Sub

    Private Sub ShowGrdELCDtl()
        Dim i As Integer

        'With ma.dgELCDtl
        '    If ma.rs_QUELCDTL.Tables("RESULT").Rows.Count > 0 Then
        '        For i = 0 To ma.rs_QUELCDTL.Tables("RESULT").Columns.Count - 1
        '            .Columns(i).Width = 0
        '            .Columns(i).ReadOnly = True
        '            .Columns(i).Visible = False
        '        Next

        '        .Columns(3).Width = 60
        '        .Columns(3).HeaderText = "Group"
        '        .Columns(3).ReadOnly = True
        '        .Columns(3).Visible = True
        '        .Columns(4).Width = 120
        '        .Columns(4).HeaderText = "Desc"
        '        .Columns(4).ReadOnly = True
        '        .Columns(4).Visible = True
        '        .Columns(5).Width = 50
        '        .Columns(5).HeaderText = "Seq"
        '        .Columns(5).ReadOnly = True
        '        .Columns(5).Visible = True
        '        .Columns(7).Width = 120
        '        .Columns(7).HeaderText = "Cost Element"
        '        .Columns(7).ReadOnly = True
        '        .Columns(7).Visible = True
        '        .Columns(8).Width = 40
        '        .Columns(8).HeaderText = "%"
        '        .Columns(8).ReadOnly = False
        '        .Columns(8).Visible = True
        '        .Columns(9).Width = 60
        '        .Columns(9).HeaderText = "Curr."
        '        .Columns(9).ReadOnly = True
        '        .Columns(9).Visible = True
        '        .Columns(10).Width = 70
        '        .Columns(10).HeaderText = "Total Amt"
        '        .Columns(10).ReadOnly = True
        '        .Columns(10).Visible = True
        '    End If
        'End With
    End Sub

    Private Sub CalculateELC()
        Dim decAjdPrc As Double
        Dim rsTmp As New DataSet
        Dim strQudSeq As String
        Dim strGrpCde As String
        Dim dblTtl As Double

        dblTtl = 0

        If ma.rs_QUELCDTL.Tables.Count > 0 Then
            If ma.rs_QUELCDTL.Tables("RESULT").DefaultView.Count > 0 Then
                If CDec(IIf(Trim(ma.txtCus2Dp.Text) = "", "0", ma.txtCus2Dp.Text)) <> 0 Then
                    decAjdPrc = CDec(ma.txtCus2Dp.Text)
                Else
                    decAjdPrc = CDec(ma.txtCus1Dp.Text)
                End If

                ma.rs_QUELCDTL.Tables("RESULT").DefaultView(ma.rs_QUELCDTL.Tables("RESULT").DefaultView.Count - 1)("qed_amt") = (ma.rs_QUELCDTL.Tables("RESULT").DefaultView(ma.rs_QUELCDTL.Tables("RESULT").DefaultView.Count - 1)("qed_percent") * decAjdPrc) / 100

                strQudSeq = ma.rs_QUELCDTL.Tables("RESULT").DefaultView(ma.rs_QUELCDTL.Tables("RESULT").DefaultView.Count - 1)("qed_qutseq")
                strGrpCde = ma.rs_QUELCDTL.Tables("RESULT").DefaultView(ma.rs_QUELCDTL.Tables("RESULT").DefaultView.Count - 1)("qed_grpcde")

                For index As Integer = 0 To ma.rs_QUELCDTL.Tables("RESULT").DefaultView.Count - 1
                    If ma.rs_QUELCDTL.Tables("RESULT").DefaultView(index)("qed_qutseq").ToString = strQudSeq And _
                        ma.rs_QUELCDTL.Tables("RESULT").DefaultView(index)("qed_grpcde").ToString = strGrpCde Then
                        dblTtl = dblTtl + CDec(IIf(IsDBNull(ma.rs_QUELCDTL.Tables("RESULT").DefaultView(index)("qed_amt")) = True, 0, ma.rs_QUELCDTL.Tables("RESULT").DefaultView(index)("qed_amt")))
                    End If
                Next

                If ma.rs_QUELC.Tables("RESULT").DefaultView.Count > 0 Then
                    For index1 As Integer = 0 To ma.rs_QUELC.Tables("RESULT").DefaultView.Count - 1
                        If ma.rs_QUELC.Tables("RESULT").DefaultView(index1)("qec_grpcde").ToString = strGrpCde Then
                            ma.rs_QUELC.Tables("RESULT").DefaultView(index1)("qec_amt") = dblTtl
                            'ma.rs_QUELC.Tables("RESULT").DefaultView(index1)("qec_amt") = dblTtl + decAjdPrc

                            If ma.rs_QUELC.Tables("RESULT").DefaultView(index1)("mode").ToString <> "NEW" And _
                                ma.rs_QUELC.Tables("RESULT").DefaultView(index1)("mode").ToString <> "DEL" Then
                                ma.rs_QUELC.Tables("RESULT").DefaultView(index1)("mode") = "UPD"
                            End If
                            Exit Sub
                        End If
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub SetCustItmCat()
        Dim strCust As String
        Dim rs_CustItmCat As New DataSet

        If Trim(ma.cboCus2No.Text) <> "" Then
            strCust = Trim(ma.cboCus2No.Text)
        Else
            strCust = Trim(ma.cboCus1No.Text)
        End If

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
            MsgBox("Error on loading SetCustItmCat sp_select_CURETPRC :" & rtnStr)
            Cursor = Cursors.Default
            Exit Sub
        End If

        'ma.cboCustItmCat.Items.Clear()
        'ma.txtPMU.Text = ""

        If rs_CustItmCat.Tables("RESULT").Rows.Count > 0 Then
            For index As Integer = 0 To rs_CustItmCat.Tables("RESULT").Rows.Count - 1
                '.Items.Add(rs_CustItmCat.Tables("RESULT").Rows(index)("crp_rpdsc"))
            Next
            '.Enabled = True
        Else
            'ma.cboCustItmCat.Enabled = False
        End If
    End Sub

    Private Function GetCusSty(ByVal strItmNo As String, ByVal strCusno As String) As String
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
            Cursor = Cursors.Default
            GetCusSty = ""
            Exit Function
        End If

        If rsCusals.Tables("RESULT").Rows.Count > 0 Then
            GetCusSty = IIf(Trim(rsCusals.Tables("RESULT").Rows(0)("ics_cusstyno")) = "", "", rsCusals.Tables("RESULT").Rows(0)("ics_cusstyno"))
        Else
            GetCusSty = ""
        End If
    End Function









End Class