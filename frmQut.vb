Public Class frmQut

    Public ma As QUM00001
    Public ma2 As frmCopyQut

    Dim drNewRow As DataRow
    Dim sFilter As String
    Dim dr() As DataRow
    Private Const sMODULE As String = "QU"
    Public rs_QUOTNDTL_copy As New DataSet
    Dim rs As New DataSet
    Dim drNewRowYFI As DataRow
    Dim drNewRowIBM As DataRow
    Dim drNewRowIBA As DataRow
    Dim drNewRowYQA As DataRow
    Dim drNewRowCCE As DataRow
    Dim drNewRowCEC As DataRow
    Dim drNewRowCED As DataRow
    Dim rs_ToBeCopy_Count As Integer = 0

    Public rs_valid As New DataSet
    Public rs_invaild As New DataSet
    Public rs_QUOTNDTL_fail As New DataSet
    Public rs_checking As New DataSet
    Public rs_ToBeCopy As New DataSet
    Public rs_QUCPTBKD_copy As New DataSet
    Public rs_QUASSINF_copy As New DataSet
    Public rs_CUBASINF_CR As New DataSet
    Public rs_SYTIESTR As New DataSet
    Public rs_IMPRCINF As New DataSet
    Public rs_IMVENINF As New DataSet
    Public rs_IMMATBKD As New DataSet
    Public rs_IMBOMASS As New DataSet
    Public rs_CUMCAMRK As New DataSet
    Public rs_CUBASINF_P As New DataSet ' for Primary Customer
    Dim rs_CUBASINF_CP As New DataSet ' for Contact person of the Customer
    Dim rs_IMXCHK As New DataSet
    Public rs_QUOTNDTL As New DataSet ' for retrieve Quotation Details information
    Dim rs_IMBASINF As New DataSet ' for Item Basic
    Dim rs_IMCOLINF As New DataSet  ' for Item Color
    Dim rs_IMPCKINF As New DataSet ' for Item Packing
    Dim rs_IMPRCINF_NewAddItem As New DataSet
    Public rs_IMBASINF_A As New DataSet
    Public rs_QUASSINF As New DataSet ' for Assortment Item information
    Public rs_SYSALREL As New DataSet

    Dim rs_CUBASINF_A As New DataSet ' for Agent of Primary Customer

    Public rs_QUCPTBKD As New DataSet ' for Component Breakdown information

    Dim rs_IMTMPREL As New DataSet


    Public totalR As Integer
    Public CopyR As Integer
    Public NotCopyR As Integer
    Public cus1no As String
    Public cus2no As String

    Public rs_QUADDINF_copy As New DataSet
    Public rs_QUCSTEMT_copy As New DataSet
    Public rs_QUELC_copy As New DataSet
    Public rs_QUELCDTL_copy As New DataSet
    Public rs_SYQUADDINF As New DataSet


    Public strCurExRat As String
    Public strCurExEffDat As String

    Public strOriCocde As String
    Public strNewCocde As String
    Public sRealCus1no As String
    Public sRealCus2no As String


    Dim rs_IMPRCINF_CopyItem As New DataSet
    Dim rs_IMVENINF_CopyItem As New DataSet

    Public rs_CUCNTINF_C As New DataSet
    Public rs_CUBASINF_S As New DataSet

    Public rs_SYCONFTR As New DataSet

    Dim txt_itmno As String

    Dim txt_CusAgt_Text As String
    Dim txt_SalDiv_Text As String
    Dim txt_SalRep_Text As String
    Dim txt_Srname_Text As String
    Dim txt_SmpPrd_Text As String
    Dim txt_SmpFgt_Text As String
    Dim txtCurCde1 As String
    Dim quh_cugrptyp_int As String
    Dim quh_cugrptyp_ext As String

    Dim txt_PrcTrm_Text As String
    Dim txt_PayTrm_Text As String

    Dim txt_Cus1Ad_Text As String
    Dim txt_Cus1St_Text As String
    Dim txt_Cus1Cy_Text As String
    Dim txt_Cus1Zp_Text As String

    Dim txt_Cus1Cp_Text As String

    Dim txt_Cus1CgInt_Text As String
    Dim txt_Cus1CgExt_Text As String

    Dim txt_quh_conalltopc As String
    Dim txtCusItm_Text As String
    Dim txtcih_curcde_Text As String
    Dim txtcih_prc_Text As String



    Public ORI_MOFLAG As String ' Define Variable to Store Original/Modified MOQ/MOA Flag
    Public ORI_MOA As String ' Define Variable to Store Original MOQ/MOA
    Public ORI_MOQ As String ' Define Variable to Store Original MOQ/MOA

    Dim org_MOFLAG_tmp As String
    Dim org_MOQ_tmp As String
    Dim org_MOA_tmp As String

    Dim org_IM_MOQ_tmp As String
    Dim org_IM_MOA_tmp As String

    Dim gs_company_for_default As String
    Dim pth As String
    Public cus1_rounding As Integer
    Public rs_CUBASINF_rounding As New DataSet
    Dim flag_copy_success As Boolean






    Private Sub cmdNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNo.Click
        If strNewCocde.Trim = "" Then
            strNewCocde = gs_company_for_default
        End If

        Call ma.qutcopied(ma.cboCoCde.Text, ma.txtQutNo.Text)
        '        Call ma.qutcopied(strNewCocde, txtQutNo2.Text)
        Me.Close()




    End Sub

    Private Sub frmQut_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed


    End Sub

    Private Sub frmQut_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub frmQut_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If strNewCocde.Trim = "" Then
            strNewCocde = gs_company_for_default
        End If


        If flag_copy_success = True Then
            Call ma.qutcopied(strNewCocde, txtQutNo2.Text)
        Else
            Call ma.qutcopied(ma.cboCoCde.Text, ma.txtQutNo.Text)
        End If
        ''Me.Close()

    End Sub

    Private Sub frmQut_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave

    End Sub

    Private Sub frmQut_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim rs As New DataSet

        totalR = 0
        CopyR = 0
        NotCopyR = 0
        cmdYes.Enabled = False

        strNewCocde = ma.pub_copy_to_new_cocde
        sRealCus1no = ma.pub_copy_to_new_cus1no
        sRealCus2no = ma.pub_copy_to_new_cus2no

        'S = "㊣QUOTNDTL_checking※S※" & strQutNo
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gsCompany = Trim(strNewCocde)
        gs_company_for_default = gsCompany
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_QUOTNDTL_checking '" & strNewCocde & "','" & ma.txtQutNo.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading frmQut_Load sp_select_QUOTNDTL_checking :" & rtnStr)
            Cursor = Cursors.Default
            Exit Sub
        End If

        '''for checking
        rs_QUOTNDTL_copy = rs.Copy
        rs_QUOTNDTL_copy.Tables("RESULT").DefaultView.Sort = "ibi_itmno, icf_colcde, ipi_pckunt, ipi_inrqty, ipi_mtrqty"

        For index As Integer = 0 To rs_QUOTNDTL_copy.Tables("RESULT").Columns.Count - 1
            rs_QUOTNDTL_copy.Tables("RESULT").Columns(index).ReadOnly = False
        Next

        '''''''''''''''''''''''''copy only "Y" Items'
        rs_ToBeCopy = ma.rs_QUOTNDTL.Copy
        rs_QUCPTBKD_copy = ma.rs_QUCPTBKD.Clone
        rs_QUASSINF_copy = ma.rs_QUASSINF.Clone
        rs_QUCSTEMT_copy = ma.rs_QUCSTEMT.Clone
        rs_QUELC_copy = ma.rs_QUELC.Clone
        rs_QUELCDTL_copy = ma.rs_QUELCDTL.Clone
        rs_QUADDINF_copy = ma.rs_QUADDINF.Clone

        totalR = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView.Count

        '*** Currency Rate
        '*** MultiCurrency
        'S = "㊣CUBASINF_Curex※S" & "※※0※※N"
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gsCompany = Trim(strNewCocde)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_CUBASINF_Curex '" & ma.copyQutCoCde & "','','0','','N'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_CR, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading frmQut_Load sp_select_CUBASINF_Curex :" & rtnStr)
            Cursor = Cursors.Default
            Exit Sub
        End If

        If rs_CUBASINF_CR.Tables("RESULT").Rows.Count = 0 Then       '***  Not Found Record
            MsgBox("No Currency in System.")
        End If

        Cursor = Cursors.WaitCursor

        gsCompany = Trim(strNewCocde)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_CUBASINF_PC '" & ma.copyQutCoCde & "','" & gsUsrID & "','" & sMODULE & "','Primary'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_P, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading frmQut_Load sp_select_CUBASINF_PC :" & rtnStr)
        End If

        strOriCocde = strNewCocde
        ''strNewCocde = ma.copyQutCoCde

        txt_SalRep_Text = ""
        txt_Srname_Text = ""
        txt_SalDiv_Text = ""

        Call checking()
    End Sub

    Private Sub checking()
        Cursor = Cursors.WaitCursor

        Dim itmNo As String
        Dim colcde As String
        Dim untcde As String
        Dim inrqty As Integer
        Dim mtrqty As Integer
        Dim tmp_hkprctrm As String
        Dim tmp_ftyprctrm As String
        Dim tmp_trantrm As String
        Dim tmp_colcde As String

        Dim rs As New DataSet

        Dim ta1 As Integer
        Dim ta2 As String
        Dim ta3 As String
        Dim ta4 As String
        Dim ta5 As String
        Dim ta6 As String
        Dim ta7 As String
        Dim ta8 As String


        itmNo = ""
        colcde = ""
        untcde = ""
        inrqty = 0
        mtrqty = 0
        tmp_hkprctrm = "'"
        tmp_ftyprctrm = "'"
        tmp_trantrm = "'"

        PBar.Maximum = totalR
        PBar.Value = 0

        lblCopy.Text = "0 of " + LTrim(Str(totalR))
        lblNotCopy.Text = "0 of " + LTrim(Str(totalR))

        strNewCocde = ma.pub_copy_to_new_cocde
        sRealCus1no = ma.pub_copy_to_new_cus1no
        sRealCus2no = ma.pub_copy_to_new_cus2no

        If sRealCus1no = "" Then
            MsgBox("Please Select Customer 1 name!")
            Exit Sub
        End If


        For index As Integer = 0 To rs_QUOTNDTL_copy.Tables("RESULT").DefaultView.Count - 1
            If rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ibi_itmno").ToString = "" Then
                rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("copy") = "N"
                rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("message") = "Item not exists"
                NotCopyR = NotCopyR + 1
                lblNotCopy.Text = LTrim(Str(NotCopyR)) + " of " + LTrim(Str(totalR))
            ElseIf rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ibi_itmsts").ToString = "INA" Then
                rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("copy") = "N"
                rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("message") = "Item in History"
                NotCopyR = NotCopyR + 1
                lblNotCopy.Text = LTrim(Str(NotCopyR)) + " of " + LTrim(Str(totalR))
            ElseIf rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ibi_itmsts").ToString = "DIS" Or _
                rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ibi_itmsts").ToString = "OLD" Or _
                rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ibi_itmsts").ToString = "HLD" Or _
                rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ibi_itmsts").ToString = "TBC" Then
                rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("copy") = "N"
                rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("message") = "Item not in Active Status"
                NotCopyR = NotCopyR + 1
                lblNotCopy.Text = LTrim(Str(NotCopyR)) + " of " + LTrim(Str(totalR))
            ElseIf rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("vbi_venno").ToString = "" Then
                rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("copy") = "N"
                rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("message") = "Vendor not in Active Status"
                NotCopyR = NotCopyR + 1
                lblNotCopy.Text = LTrim(Str(NotCopyR)) + " of " + LTrim(Str(totalR))
            ElseIf rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("qud_cusven").ToString = "" Then
                rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("copy") = "N"
                rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("message") = "Custom Vendor not in Active Status"
                NotCopyR = NotCopyR + 1
                lblNotCopy.Text = LTrim(Str(NotCopyR)) + " of " + LTrim(Str(totalR))
                ''ElseIf itmNo = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ibi_itmno").ToString And _
                ''        colcde = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("icf_colcde").ToString And _
                ''        untcde = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_pckunt").ToString And _
                ''        inrqty = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_inrqty").ToString And _
                ''        mtrqty = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_mtrqty").ToString Then
                ''    rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("copy") = "N"
                ''    rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("message") = "Duplicate Color and Packing"
                ''    NotCopyR = NotCopyR + 1
                ''    lblNotCopy.Text = LTrim(Str(NotCopyR)) + " of " + LTrim(Str(totalR))
            ElseIf not_Valid_Item(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ibi_itmno").ToString, sRealCus1no, rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("icf_colcde").ToString) Then
                rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("copy") = "N"
                rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("message") = "Item cannot Quot by this Company! Customer and Company Relation Missing."
                NotCopyR = NotCopyR + 1
                lblNotCopy.Text = LTrim(Str(NotCopyR)) + " of " + LTrim(Str(totalR))
                ''ElseIf cat_not_exist(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ibi_itmno").ToString, sRealCus1no) Then
                ''    rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("copy") = "N"
                ''    rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("message") = "Category Mark Up not Set"
                ''    NotCopyR = NotCopyR + 1
                ''    lblNotCopy.Text = LTrim(Str(NotCopyR)) + " of " + LTrim(Str(totalR))
                'ElseIf CheckVenCo(sRealCus1no, rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("icf_colcde").ToString, rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ibi_itmno").ToString) = False Then
                '    rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("copy") = "N"
                '    rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("message") = "Item cannot Quot by this Company! Customer and Company Relation Missing."
                '    NotCopyR = NotCopyR + 1
                '    lblNotCopy.Text = LTrim(Str(NotCopyR)) + " of " + LTrim(Str(totalR))
            ElseIf rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("qud_colcde").ToString <> "" And _
                    rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("qud_untcde").ToString <> "" And _
                    rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("icf_colcde").ToString = "" And _
                    rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_pckunt").ToString = "" Then
                rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("copy") = "N"
                rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("message") = "Packing / Color not in IM"
                NotCopyR = NotCopyR + 1
                lblNotCopy.Text = LTrim(Str(NotCopyR)) + " of " + LTrim(Str(totalR))
            ElseIf rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("qud_colcde").ToString <> "" And _
                    rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("icf_colcde").ToString = "" Then
                ''20130826 color = N/A??
                rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("copy") = "N"
                rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("message") = "Color not in IM"
                NotCopyR = NotCopyR + 1
                lblCopy.Text = LTrim(Str(NotCopyR)) + " of " + LTrim(Str(totalR))
            ElseIf rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("qud_untcde").ToString <> "" And _
                    rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_pckunt").ToString = "" Then
                rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("copy") = "N"
                rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("message") = "Packing not in IM"
                NotCopyR = NotCopyR + 1
                lblNotCopy.Text = LTrim(Str(NotCopyR)) + " of " + LTrim(Str(totalR))
            Else
                rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("copy") = "Y"
                CopyR = CopyR + 1
                lblCopy.Text = LTrim(Str(CopyR)) + " of " + LTrim(Str(totalR))
            End If

            '*******************************Check Price Valid for the Company******************************
            Dim GotActivePrice As Boolean
            Dim GotValidPrice As Boolean

            GotActivePrice = False
            GotValidPrice = False

            'S = "㊣IMPRCINF_Q_wPck※S※" & rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ibi_itmno") & "※" & _
            '                                rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_pckunt") & "※" & _
            '                                rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_inrqty") & "※" & _
            '                                rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_mtrqty") & "※" & _
            '                                rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_conftr")
            'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

            'Cursor = Cursors.WaitCursor

            'gsCompany = Trim(strNewCocde)
            'Call Update_gs_Value(gsCompany)

            gspStr = "sp_select_IMPRCINF_Q_wPck '" & strNewCocde & "','" & _
                                                    rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ibi_itmno") & "','" & _
                                                    rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_pckunt") & "','" & _
                                                    rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_inrqty") & "','" & _
                                                    rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_mtrqty") & "','" & _
                                                    rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_conftr") & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_IMPRCINF, rtnStr)
            gspStr = ""

            Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading checking sp_select_IMPRCINF_Q_wPck :" & rtnStr)
                Exit Sub
            End If

            ''If sRealCus1no = "" Then
            ''    sRealCus1no = ""
            ''Else
            ''    sRealCus1no = sRealCus1no
            ''End If

            ''If sRealCus2no = "" Then
            ''    sRealCus2no = ""
            ''Else
            ''    sRealCus2no = sRealCus2no
            ''End If


            If rs_IMPRCINF.Tables("RESULT").Rows.Count > 0 Then
                For index1 As Integer = 0 To rs_IMPRCINF.Tables("RESULT").Rows.Count - 1
                    If rs_IMPRCINF.Tables("RESULT").Rows(index1)("imu_status") = "ACT" Then
                        GotActivePrice = True
                        If rs_IMPRCINF.Tables("RESULT").Rows(index1)("imu_cus1no").ToString = sRealCus1no And _
                            rs_IMPRCINF.Tables("RESULT").Rows(index1)("imu_cus2no").ToString = sRealCus2no Then
                            GotValidPrice = True
                            Exit For
                        End If
                        If rs_IMPRCINF.Tables("RESULT").Rows(index1)("imu_cus1no").ToString = sRealCus1no And _
                            rs_IMPRCINF.Tables("RESULT").Rows(index1)("imu_cus2no").ToString = "" Then
                            GotValidPrice = True
                            Exit For
                        End If
                        ' Check if is Customer Group

                        If rs_IMPRCINF.Tables("RESULT").Rows.Count > index1 Then
                            If rs_IMPRCINF.Tables("RESULT").Rows(index1)("imu_cus1no").ToString.Length <> 5 Then
                                dr = rs_CUBASINF_P.Tables("RESULT").Select("cbi_cusno = " & "'" & sRealCus1no & "'")

                                If rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("vbi_ventyp").ToString = "E" Then

                                    If rs_IMPRCINF.Tables("RESULT").Rows(index1)("imu_cus1no") = dr(0)("cbi_cugrptyp_ext") Then
                                        GotValidPrice = True
                                        Exit For
                                    End If
                                Else
                                    If rs_IMPRCINF.Tables("RESULT").Rows(index1)("imu_cus1no") = dr(0)("cbi_cugrptyp_int") Then
                                        GotValidPrice = True
                                        Exit For
                                    End If
                                End If

                            End If
                        End If
                        If rs_IMPRCINF.Tables("RESULT").Rows(index1)("imu_cus1no").ToString = "" And _
                            rs_IMPRCINF.Tables("RESULT").Rows(index1)("imu_cus2no").ToString = "" Then
                            GotValidPrice = True
                            Exit For
                        End If
                        GotActivePrice = False
                    End If
                Next
            Else
                rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("copy") = "N"
                rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("message") = "No valid price of this item."
                NotCopyR = NotCopyR + 1
                CopyR = CopyR - 1
                lblNotCopy.Text = LTrim(Str(NotCopyR)) + " of " + LTrim(Str(totalR))
            End If

            If GotActivePrice = False Then
                rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("copy") = "N"
                rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("message") = "No valid price of this item."
                NotCopyR = NotCopyR + 1
                CopyR = CopyR - 1
                lblNotCopy.Text = LTrim(Str(NotCopyR)) + " of " + LTrim(Str(totalR))
            Else
                If GotValidPrice = False Then
                    If sRealCus2no = "" Then
                        rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("copy") = "N"
                        rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("message") = "No valid price of this item for customer: " & sRealCus1no
                        NotCopyR = NotCopyR + 1
                        CopyR = CopyR - 1
                        lblNotCopy.Text = LTrim(Str(NotCopyR)) + " of " + LTrim(Str(totalR))
                    Else
                        rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("copy") = "N"
                        rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("message") = "No valid price of this item for customer: " & sRealCus1no & ", " & sRealCus2no
                        NotCopyR = NotCopyR + 1
                        CopyR = CopyR - 1
                        lblNotCopy.Text = LTrim(Str(NotCopyR)) + " of " + LTrim(Str(totalR))
                    End If
                End If
            End If


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If DateDiff("d", ma.rs_QUOTNHDR.Tables("RESULT").Rows(0).Item("quh_credat"), "09/09/2003") > 0 Then
                'old qut
            Else
                'new qut
                'check fromula here
                'calcaulate Price Elements, has price elements  then Insert
                ta1 = rs_QUOTNDTL_copy.Tables("RESULT").Rows(index).Item("qud_qutseq")
                ta1 = IIf(IsDBNull(ta1), 0, ta1)
                ta2 = sRealCus1no
                ta3 = sRealCus2no
                ta4 = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("vbi_ventyp")
                ta4 = IIf(IsDBNull(ta4), "", ta4)

                ta5 = IIf(IsDBNull(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ibi_catlvl3")), "", rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ibi_catlvl3"))
                ta6 = IIf(IsDBNull(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("qud_venno")), "", rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("qud_venno"))
                ta7 = IIf(IsDBNull(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_prctrm").ToString.Trim), "", rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_prctrm").ToString.Trim)
                ta8 = IIf(IsDBNull(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_trantrm").ToString.Trim), "", rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_trantrm").ToString.Trim)
                If check_QUPRCEMT_CU(ta1, ta2, ta3, ta4, ta5, ta6, ta7, ta8) <> True Then
                    rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("copy") = "N"
                    rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("message") = "No formula"
                End If

            End If



            If rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("copy").ToString = "Y" Then
                itmNo = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ibi_itmno")
                colcde = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("icf_colcde")
                untcde = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_pckunt")
                inrqty = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_inrqty")
                mtrqty = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_mtrqty")

                tmp_hkprctrm = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_prctrm")
                tmp_ftyprctrm = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_ftyprctrm")
                tmp_trantrm = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_trantrm")

                tmp_hkprctrm = Trim(Split(tmp_hkprctrm, "-")(0))
                tmp_ftyprctrm = Trim(Split(tmp_ftyprctrm, "-")(0))
                tmp_trantrm = Trim(Split(tmp_trantrm, "-")(0))



                'S = "㊣QUOTNDTL_Vendor_wCust2※S※" & itmNo & "※" & _
                '                    untcde & "※" & _
                '                    inrqty & "※" & _
                '                    mtrqty & "※" & _
                '                    rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_conftr") & "※" & _
                '                    sRealCus1no & "※" & sRealCus2no & "※" & gsUsrID
                'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

                Cursor = Cursors.WaitCursor

                gsCompany = Trim(strNewCocde)
                Call Update_gs_Value(gsCompany)

                gspStr = "sp_select_QUOTNDTL_Vendor '" & strNewCocde & "','" & _
                                                        itmNo & "','" & _
                                                        untcde & "','" & inrqty & "','" & mtrqty & "','" & _
                                                        sRealCus1no & "','" & sRealCus2no & "','" & _
                                                         tmp_ftyprctrm & "','" & _
                                                         tmp_hkprctrm & "','" & _
                                                         tmp_trantrm & "','" & _
                                                        gsUsrID & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_IMVENINF, rtnStr)
                gspStr = ""

                Cursor = Cursors.Default

                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading checking sp_select_QUOTNDTL_Vendor :" & rtnStr)
                    Exit Sub
                End If

                If Not rs_IMVENINF.Tables("RESULT").Rows.Count > 0 Then
                    ' MsgBox("Vendor for " & itmNo & " not found!")
                    '  Exit Sub
                Else
                    rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_ftyprc") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_ftyprc")
                    rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_ftycst") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_ftycst")

                    rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_curcde") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_curcde")
                    rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_bcurcde") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_bcurcde")
                    rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_basprc") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_basprc")

                    rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_prctrm") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_prctrm")
                    rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_ftyprctrm") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_ftyprctrm")
                    rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_cus1no") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_cus1no")
                    rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_cus2no") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_cus2no")
                    rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_trantrm") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_trantrm")
                    rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_effdat") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_effdat")
                    rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_expdat") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_expdat")


                End If

                'Call fill_QUOTNDTL(index)
                'Call fill_QUCPTBKD()
                'Call fill_CIHItem(index)

                'If rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ibi_typ").ToString = "ASS" Then
                '    Call fill_QUASSINF(index)
                'End If

                'Call fill_QUADDINF()
                'Call fill_QUCSTEMT()

                ''If rs_QUCSTEMT_copy.Tables.Count > 0 Then
                ''    If rs_QUCSTEMT_copy.Tables("RESULT").DefaultView.Count > 0 Then
                ''        sFilter = "qce_qutseq = " & CStr(rs_ToBeCopy_Count) & " and mode <> 'DEL'"
                ''    Else
                ''        sFilter = ""
                ''    End If
                ''    rs_QUCSTEMT_copy.Tables("RESULT").DefaultView.RowFilter = sFilter
                ''End If

                'Call Cal_Price(index)

                'Call fill_QUELC()
                'Call fill_QUELCDTL(index)

                ''*** Do once more timr after the ELC is calculated
                'Dim strTmp As String

                'strTmp = SetCustItmCat()

                'drNewRow("qud_custitmcat") = Trim(Split(strTmp, "-")(0))
                'drNewRow("qud_custitmcatfml") = Trim(Split(strTmp, "-")(1))
                'drNewRow("qud_custitmcatamt") = CDbl(Trim(Split(strTmp, "-")(3)))
                'drNewRow("qud_pmu") = Trim(Split(strTmp, "-")(2))

                'If CDbl(drNewRow("qud_cususd")) = 0 Then
                '    drNewRow("qud_cususd") = drNewRow("qud_custitmcatamt")
                'End If

                'drNewRow("qud_calpmu") = CalculatePMU()

                'rs_ToBeCopy.Tables("RESULT").Rows.Add(drNewRow)

                'If rs_QUCSTEMT_copy.Tables.Count > 0 Then
                '    sFilter = ""
                '    rs_QUCSTEMT_copy.Tables("RESULT").DefaultView.RowFilter = sFilter
                '    'End If
            End If

            'PBar.Value = PBar.Value + 1
        Next

        '''for copying
        rs_valid = rs_QUOTNDTL_copy.Copy

        sFilter = "copy = 'Y'"
        rs_valid.Tables("RESULT").DefaultView.RowFilter = sFilter

        If rs_valid.Tables("RESULT").DefaultView.Count = 0 Then
            MsgBox("No Item has complete info. to copy!")
            cmdYes.Enabled = False
        End If


        dgValid.DataSource = rs_valid.Tables("RESULT").DefaultView
        lblCopy.Text = LTrim(Str(dgValid.RowCount)) + " of " + LTrim(Str(totalR))

        If rs_QUOTNDTL_copy.Tables("RESULT").DefaultView.Count >= 1 Then
            cmdYes.Enabled = True
        Else
            cmdYes.Enabled = False
        End If

        If rs_valid.Tables("RESULT").DefaultView.Count = 0 Then
            cmdYes.Enabled = False
        End If

        Call Display_Valid()

        '''for display
        rs_invaild = rs_QUOTNDTL_copy.Copy

        sFilter = "copy = 'N'"
        rs_invaild.Tables("RESULT").DefaultView.RowFilter = sFilter

        dgInvalid.DataSource = rs_invaild.Tables("RESULT").DefaultView
        lblNotCopy.Text = LTrim(Str(dgInvalid.RowCount)) + " of " + LTrim(Str(totalR))

        Call Display_Invalid()

        Cursor = Cursors.Default
    End Sub

    Private Function not_Valid_Item(ByVal itmNo As String, ByVal cus1no As String, ByVal colcde As String) As Boolean
        'S = "㊣IMXChk※S※" & cus1no & "※" & colcde & "※" & itmNo
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gsCompany = Trim(strNewCocde)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_IMXChk '" & strNewCocde & "','" & cus1no & "','" & colcde & "','" & itmNo & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_IMXCHK, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            not_Valid_Item = True
            MsgBox("Error on loading not_Valid_Item sp_select_IMXChk :" & rtnStr)
            Exit Function
        End If

        Cursor = Cursors.WaitCursor

        gsCompany = Trim(strOriCocde)
        Call Update_gs_Value(gsCompany)

        Cursor = Cursors.Default

        If rs_IMXCHK.Tables("RESULT").Rows.Count = 0 Then
            not_Valid_Item = True
        Else
            not_Valid_Item = False
        End If
    End Function

    Private Function cat_not_exist(ByVal itmNo As String, ByVal cus1no As String) As Boolean
        Dim rs As New DataSet

        'S = "㊣CUMCAMRK_item※S※" & Trim(Split(cus1no, "-")(0)) & "※" & itmNo
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gspStr = "sp_select_CUMCAMRK_item '" & strNewCocde & "','" & Trim(Split(cus1no, "-")(0)) & "','" & itmNo & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            cat_not_exist = True
            MsgBox("Error on loading cat_not_exist sp_select_IMXChk :" & rtnStr)
            Exit Function
        End If

        If rs.Tables("RESULT").Rows.Count > 0 Then
            cat_not_exist = False
        Else
            cat_not_exist = True
        End If
    End Function

    Private Function CheckVenCo(ByVal cus1no As String, ByVal colcde As String, ByVal itmNo As String) As Boolean
        CheckVenCo = False

        'S = "㊣IMXChk※S※" & cus1no & "※" & colcde & "※" & itmNo
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gsCompany = Trim(strNewCocde)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_IMXChk '" & strNewCocde & "','" & cus1no & "','" & colcde & "','" & itmNo & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_IMXCHK, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            CheckVenCo = False
            MsgBox("Error on loading CheckVenCo sp_select_IMXChk :" & rtnStr)
            Exit Function
        End If

        Cursor = Cursors.WaitCursor

        gsCompany = Trim(strOriCocde)
        Call Update_gs_Value(gsCompany)

        Cursor = Cursors.Default

        If rs_IMXCHK.Tables("RESULT").Rows.Count = 0 Then
            CheckVenCo = False
        Else
            CheckVenCo = True
        End If
    End Function

    Private Sub fill_QUOTNDTL(ByVal index As Integer)
        drNewRow = rs_ToBeCopy.Tables("RESULT").NewRow()
        rs_ToBeCopy_Count += 1
        drNewRow("Del") = "N"
        drNewRow("mode") = "NEW"
        drNewRow("qud_apprve") = ""
        drNewRow("qud_qutseq") = rs_ToBeCopy_Count

        drNewRow("qud_itmno") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ibi_itmno")

        drNewRow("qud_alsitmno") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ibi_alsitmno")
        drNewRow("qud_alscolcde") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ibi_alscolcde")

        drNewRow("qud_conftr") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_conftr")
        drNewRow("qud_contopc") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("qud_contopc")

        drNewRow("qud_itmtyp") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ibi_typ")
        drNewRow("qud_tbm") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("qud_tbm")
        drNewRow("qud_itmsts") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ibi_itmsts")
        drNewRow("qud_itmdsc") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ibi_engdsc")
        drNewRow("qud_itmdsc") = Replace(drNewRow("qud_itmdsc"), "'", "''")

        drNewRow("qud_hstref") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("qud_hstref")

        drNewRow("qud_colcde") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("icf_colcde")
        drNewRow("qud_untcde") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_pckunt")
        drNewRow("qud_inrqty") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_inrqty")
        drNewRow("qud_mtrqty") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_mtrqty")

        drNewRow("qud_qutdat") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_qutdat")

        drNewRow("qud_cbm") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_cbm")
        drNewRow("qud_upc") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("icf_ucpcde")
        drNewRow("qud_ftytmpitm") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("qud_ftytmpitm")
        drNewRow("qud_ftytmpitmno") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("qud_ftytmpitmno")

        drNewRow("qud_specpck") = ""

        Dim strTmp As String

        strTmp = SetCustItmCat()

        drNewRow("qud_custitmcat") = Trim(Split(strTmp, "-")(0))
        drNewRow("qud_custitmcatfml") = Trim(Split(strTmp, "-")(1))
        drNewRow("qud_custitmcatamt") = CDbl(Trim(Split(strTmp, "-")(3)))
        drNewRow("qud_calpmu") = 0
        drNewRow("qud_pmu") = Trim(Split(strTmp, "-")(2))

        drNewRow("qud_cusstyno") = GetCusSty(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ibi_itmno"), Trim(Split(frmCopyQut.cboPriCus.Text, " - ")(0)), index)
        drNewRow("qud_imrmk") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ibi_rmk")

        drNewRow("qud_imrmk") = Replace(drNewRow("qud_imrmk"), "'", "''")


        drNewRow("qud_rndsts") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("qud_rndsts")

        drNewRow("qud_cus1no") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_cus1no")
        drNewRow("qud_cus2no") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_cus2no")
        drNewRow("qud_trantrm") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_trantrm")
        drNewRow("qud_effdat") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_effdat")
        drNewRow("qud_expdat") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_expdat")

        ''Get ELC
        drNewRow("qud_prctrm") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_prctrm")
        drNewRow("qud_ftyprctrm") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_ftyprctrm")

        drNewRow("vbi_ventyp") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("vbi_ventyp")

        drNewRow("qud_cft") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_cft")

        If sRealCus2no <> "" Then
            Cursor = Cursors.WaitCursor

            gsCompany = Trim(ma.copyQutCoCde)
            Call Update_gs_Value(gsCompany)

            gspStr = "sp_select_CUBASINF_Q '" & ma.copyQutCoCde & "','" & sRealCus1no & "','Secondary'"
            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            gspStr = ""

            Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading fill_QUOTNDTL sp_select_CUBASINF_Q :" & rtnStr)
                Cursor = Cursors.Default
                Exit Sub
            End If

            dr = rs.Tables("RESULT").Select("csc_seccus = " & "'" & sRealCus2no & "'")

            drNewRow("qud_prcsec") = dr(0)("cpi_prcsec")
            drNewRow("qud_grsmgn") = dr(0)("cpi_grsmgn")
        Else
            drNewRow("qud_prcsec") = ""
            drNewRow("qud_grsmgn") = 0
        End If

        If rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("icf_colcde").ToString <> "" And _
            rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_pckunt").ToString <> "" And _
            Val(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_basprc")) > 0 Then
            drNewRow("qud_qutitmsts") = "A"
        Else
            drNewRow("qud_qutitmsts") = "I"
        End If

        Cursor = Cursors.WaitCursor

        gsCompany = Trim(ma.copyQutCoCde)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_CUBASINF_PC '" & ma.copyQutCoCde & "','" & gsUsrID & "','" & sMODULE & "','Primary'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading fill_QUOTNDTL sp_select_CUBASINF_PC :" & rtnStr)
            Exit Sub
        End If

        dr = rs.Tables("RESULT").Select("cbi_cusno = " & "'" & sRealCus1no & "'")

        drNewRow("qud_curcde") = dr(0)("cpi_curcde")
        drNewRow("qud_onetim") = "N"

        drNewRow("qud_discnt") = 0

        '*** To execute b4 MOQ/MOA calculation
        '-------------START--------------------------------------
        If drNewRow("qud_untcde").ToString <> "" Then
            Call Cal_Price(index)
        Else
            drNewRow("qud_cus1sp") = 0
            drNewRow("qud_cus2sp") = 0
            drNewRow("qud_cus1dp") = 0
            drNewRow("qud_cus2dp") = 0
            drNewRow("qud_smpprc") = 0
            drNewRow("qud_smpunt") = ""
            drNewRow("qud_fcurcde") = ""
            drNewRow("qud_ftycst") = 0
            drNewRow("qud_ftyprc") = 0
            drNewRow("qud_basprc") = 0
        End If

        If drNewRow("qud_contopc").ToString = "Y" And drNewRow("qud_cus1sp") <> 0 Then
            drNewRow("qud_pcprc") = Format(drNewRow("qud_cus1sp") / drNewRow("qud_conftr"), "###,###,##0.0000")
        Else
            drNewRow("qud_pcprc") = 0
        End If
        '--------------END----------------------------------------

        'S = "㊣ItemMaster_moq_moa_qu_wunttyp※S※" & QUM00001.GetCtrlValue(frmCopyQut.cboPriCus) & "※" & _
        '    QUM00001.GetCtrlValue(frmCopyQut.cboSecCus) & "※" & rs_ToBeCopy("qud_itmno") & _
        '    "※" & rs_ToBeCopy("qud_untcde") & "※" & IIf(rs_ToBeCopy("qud_conftr") = "", 1, rs_ToBeCopy("qud_conftr")) & "※" & rs_ToBeCopy("qud_inrqty") & "※" & _
        '    rs_ToBeCopy("qud_mtrqty") & "※" & rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("icf_colcde") & "※" & _
        '       rs_ToBeCopy("qud_cus1sp") & "※" & frmCopyQut.rs_CUBASINF_P("cpi_curcde")
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gsCompany = Trim(ma.copyQutCoCde)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_ItemMaster_moq_moa_qu_wunttyp '" & ma.copyQutCoCde & "','" & _
                                        sRealCus1no & "','" & _
                                        sRealCus2no & "','" & _
                                        rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ibi_itmno") & "','" & _
                                        rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_pckunt") & "','" & _
                                        rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_conftr") & "','" & _
                                        rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_inrqty") & "','" & _
                                        rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_mtrqty") & "','" & _
                                        rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("icf_colcde") & "','" & _
                                        drNewRow("qud_cus1sp") & "','" & _
                                        drNewRow("qud_curcde") & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYTIESTR, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading updateQuotation sp_select_ItemMaster_moq_moa_qu_wunttyp :" & rtnStr)
            Exit Sub
        End If

        drNewRow("qud_moa") = 0
        drNewRow("qud_moq") = 0

        '*** Cater Original MOQ/MOA value
        Dim ORI_MOQ As Long
        Dim ORI_MOA As Long
        Dim ORI_MOFLAG As String
        ORI_MOQ = 0
        ORI_MOA = 0
        ORI_MOFLAG = ""

        Dim strMOQUNTTYP As String = ""

        If rs_SYTIESTR.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("No MOQ & MOA found of this Item")
        Else
            ORI_MOFLAG = rs_SYTIESTR.Tables("RESULT").Rows(0)("MOFLAG")
            ORI_MOQ = CInt(rs_SYTIESTR.Tables("RESULT").Rows(0)("MOQ"))

            strMOQUNTTYP = "CTN"

            If IIf(IsDBNull(rs_SYTIESTR.Tables("RESULT").Rows(0)("DATASRC")), "", rs_SYTIESTR.Tables("RESULT").Rows(0)("DATASRC")).ToString = "I" Then
                If Len(IIf(IsDBNull(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("message")), "", Trim(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("message"))).ToString) = 0 Then
                    rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("message") = "CIH MOQ/MOA < IM or Change of MOQ/MOA"
                Else
                    rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("message") = Microsoft.VisualBasic.Left(Trim(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("message").ToString) & "," & "CIH MOQ/MOA value lower than Item Master", 100)
                End If
            End If

            If drNewRow("qud_curcde") <> rs_SYTIESTR.Tables("RESULT").Rows(0)("CURCDE") And _
                CDec(rs_SYTIESTR.Tables("RESULT").Rows(0)("MOA")) > 0 Then
                dr = ma.rs_CUBASINF_CR.Tables("RESULT").Select("ysi_def = 'Y'")

                If drNewRow("qud_curcde") = dr(0)("ysi_cde") Then
                    dr = ma.rs_CUBASINF_CR.Tables("RESULT").Select("ysi_cde = " + "'" + rs_SYTIESTR.Tables("RESULT").Rows(0)("CURCDE").ToString + "'")
                    ORI_MOA = roundup(rs_SYTIESTR.Tables("RESULT").Rows(0)("MOA") * dr(0)("ysi_selrat"))
                Else
                    dr = ma.rs_CUBASINF_CR.Tables("RESULT").Select("ysi_cde = " + "'" + drNewRow("qud_curcde") + "'")
                    ORI_MOA = roundup(rs_SYTIESTR.Tables("RESULT").Rows(0)("MOA") / dr(0)("ysi_selrat"))
                End If
            Else
                ORI_MOA = rs_SYTIESTR.Tables("RESULT").Rows(0)("MOA")
            End If
        End If

        If ORI_MOFLAG = "Q" Then
            ORI_MOA = "0"
        End If

        drNewRow("qud_moqunttyp") = strMOQUNTTYP

        drNewRow("qud_moflag") = ORI_MOFLAG

        If ORI_MOFLAG = "Q" Then
            drNewRow("qud_orgmoq") = ORI_MOQ
            drNewRow("qud_orgmoa") = 0
            drNewRow("qud_moq") = ORI_MOQ
            drNewRow("qud_moa") = 0
        ElseIf ORI_MOFLAG = "A" Then
            drNewRow("qud_orgmoq") = ORI_MOQ
            drNewRow("qud_orgmoa") = ORI_MOA
            drNewRow("qud_moq") = ORI_MOQ
            drNewRow("qud_moa") = ORI_MOA
        End If

        '        Dim pth As String

        drNewRow("qud_image") = "N"

        On Error Resume Next

        If gsCompanyGroup = "MSG" Then
            If rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("vbi_ventyp").ToString = "I" Or _
                rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("vbi_ventyp").ToString = "J" Then
                pth = ItmImg_pth & ma.SearchImgPath(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ibi_lnecde")) & "\" & _
                        ma.revisedItmno(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ivi_venitm")) + ".JPG"
            Else
                pth = ItmImg_pth & rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ivi_venno") & "\" & _
                        ma.revisedItmno(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ivi_venitm")) & "_" & _
                        rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ivi_venno") + ".JPG"
            End If

            If UCase(Dir(pth)) <> "" Then
                drNewRow("qud_image") = "Y"
            Else
                drNewRow("qud_image") = "N"
            End If

        Else
            If rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("vbi_ventyp").ToString = "I" Or _
                rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("vbi_ventyp").ToString = "J" Then
                pth = ItmImg_pth & ma.SearchImgPath(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ibi_lnecde")) & "\" & _
                        ma.revisedItmno(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ivi_venitm")) + ".JPG"

                If UCase(Dir(pth)) <> "" Then
                    drNewRow("qud_image") = "Y"
                Else
                    drNewRow("qud_image") = "N"
                End If
            ElseIf rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ivi_venno").ToString = "0005" Then
                pth = ItmImg_pth & rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ivi_venno") & "\" & _
                        ma.revisedItmno(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ivi_venitm")) & "_" & _
                        rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ivi_venno") + ".JPG"

                If Dir(pth & ".jpg") = "" Then
                    pth = ItmImg_pth_6 & ma.SearchImgPath(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ibi_lnecde")) & "\" & _
                            ma.revisedItmno(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ivi_venitm")) + ".JPG"
                End If

                If UCase(Dir(pth)) <> "" Then
                    drNewRow("qud_image") = "Y"
                Else
                    drNewRow("qud_image") = "N"
                End If
            Else
                pth = ItmImg_pth & rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ivi_venno") & "\" & _
                        ma.revisedItmno(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ivi_venitm")) & "_" & _
                        rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ivi_venno") + ".JPG"

                If UCase(Dir(pth)) <> "" Then
                    drNewRow("qud_image") = "Y"
                Else
                    drNewRow("qud_image") = "N"
                End If
            End If
        End If

        drNewRow("qud_pckseq") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_pckseq")
        drNewRow("qud_inrdin") = Format(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_inrdin"), "######0.####")
        drNewRow("qud_inrwin") = Format(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_inrwin"), "######0.####")
        drNewRow("qud_inrhin") = Format(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_inrhin"), "######0.####")
        drNewRow("qud_mtrdin") = Format(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_mtrdin"), "######0.####")
        drNewRow("qud_mtrwin") = Format(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_mtrwin"), "######0.####")
        drNewRow("qud_mtrhin") = Format(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_mtrhin"), "######0.####")
        drNewRow("qud_inrdcm") = Format(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_inrdcm"), "######0.####")
        drNewRow("qud_inrwcm") = Format(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_inrwcm"), "######0.####")
        drNewRow("qud_inrhcm") = Format(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_inrhcm"), "######0.####")
        drNewRow("qud_mtrdcm") = Format(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_mtrdcm"), "######0.####")
        drNewRow("qud_mtrwcm") = Format(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_mtrwcm"), "######0.####")
        drNewRow("qud_mtrhcm") = Format(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_mtrhcm"), "######0.####")
        drNewRow("inner_in") = Format(Str(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_inrdin")), "######0.####") + "x" + _
                                        Format(Str(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_inrwin")), "######0.####") + "x" + _
                                        Format(Str(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_inrhin")), "######0.####")
        drNewRow("master_in") = Format(Str(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_mtrdin")), "######0.####") + "x" + _
                                        Format(Str(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_mtrwin")), "######0.####") + "x" + _
                                        Format(Str(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_mtrhin")), "######0.####")
        drNewRow("inner_cm") = Format(Str(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_inrdcm")), "######0.####") + "x" + _
                                        Format(Str(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_inrwcm")), "######0.####") + "x" + _
                                        Format(Str(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_inrhcm")), "######0.####")
        drNewRow("master_cm") = Format(Str(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_mtrdcm")), "######0.####") + "x" + _
                                            Format(Str(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_mtrwcm")), "######0.####") + "x" + _
                                            Format(Str(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_mtrhcm")), "######0.####")
        drNewRow("qud_grswgt") = Format(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_grswgt"), "##0.###")
        drNewRow("qud_netwgt") = Format(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_netwgt"), "##0.###")

        drNewRow("qud_venno") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ivi_venno")
        drNewRow("qud_venitm") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ivi_venitm")
        drNewRow("qud_subcde") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ivi_subcde")

        drNewRow("qud_cosmth") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ibi_cosmth")

        '*** copy custom vendor and custom sub code
        drNewRow("qud_cusven") = IIf(IsDBNull(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("qud_cusven")), "", rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("qud_cusven"))
        drNewRow("qud_cussub") = IIf(IsDBNull(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("qud_cussub")), "", rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("qud_cussub"))

        '*** Keep the originally values
        drNewRow("qud_cuscol") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("qud_cuscol")
        drNewRow("qud_cusitm") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("qud_cusitm")
        drNewRow("qud_coldsc") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("qud_coldsc")
        drNewRow("qud_coldsc") = Replace(drNewRow("qud_coldsc"), "'", "''")

        drNewRow("qud_note") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("qud_note")
        drNewRow("qud_note") = Replace(drNewRow("qud_note"), "'", "''")

        drNewRow("qud_stkqty") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("qud_stkqty")
        drNewRow("qud_cusqty") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("qud_cusqty")
        drNewRow("qud_smpqty") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("qud_smpqty")
        drNewRow("qud_hrmcde") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("qud_hrmcde")
        drNewRow("qud_dtyrat") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("qud_dtyrat")
        drNewRow("qud_cususd") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("qud_cususd")
        drNewRow("qud_cuscad") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("qud_cuscad")
        drNewRow("qud_dept") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("qud_dept")
        drNewRow("qud_pckitr") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("qud_pckitr")
        '*** Keep the originally values

        drNewRow("imu_cus1no") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_cus1no")
        drNewRow("imu_cus2no") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_cus2no")
        drNewRow("imu_trantrm") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_trantrm")
        drNewRow("imu_effdat") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_effdat")
        drNewRow("imu_expdat") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_expdat")
    End Sub

    Private Sub Display_Valid()
        With dgValid
            For i As Integer = 0 To dgValid.ColumnCount - 1
                .Columns(i).Width = 0
                .Columns(i).ReadOnly = True
                .Columns(i).Visible = False
            Next

            .Columns(24).Width = 100
            .Columns(24).HeaderText = "Item"
            .Columns(24).Visible = True

            .Columns(38).Width = 80
            .Columns(38).HeaderText = "Color Code"
            .Columns(38).Visible = True

            .Columns(44).Width = 80
            .Columns(44).HeaderText = "Packing"
            .Columns(44).Visible = True

            .Columns(78).Width = 50
            .Columns(78).HeaderText = "Remarks"
            .Columns(78).Visible = True

            .Columns(97).Width = 80
            .Columns(97).HeaderText = "Pri Customer"
            .Columns(97).Visible = True

            .Columns(98).Width = 80
            .Columns(98).HeaderText = "Sec Customer"
            .Columns(98).Visible = True

            .Columns(99).Width = 120
            .Columns(99).HeaderText = "HK Price Term"
            .Columns(99).Visible = True

            .Columns(100).Width = 120
            .Columns(100).HeaderText = "Fty Price Term"
            .Columns(100).Visible = True

            .Columns(101).Width = 120
            .Columns(101).HeaderText = "Transport Term"
            .Columns(101).Visible = True

            .Columns(102).Width = 75
            .Columns(102).HeaderText = "Effect Date"
            .Columns(102).Visible = True

            .Columns(103).Width = 75
            .Columns(103).HeaderText = "Expiry Date"
            .Columns(103).Visible = True
        End With
    End Sub

    Private Sub Display_Invalid()
        With dgInvalid
            For i As Integer = 0 To dgInvalid.ColumnCount - 1
                .Columns(i).Width = 0
                .Columns(i).ReadOnly = True
                .Columns(i).Visible = False
            Next

            .Columns(24).Width = 100
            .Columns(24).HeaderText = "Item"
            .Columns(24).Visible = True

            .Columns(38).Width = 80
            .Columns(38).HeaderText = "Color Code"
            .Columns(38).Visible = True

            .Columns(44).Width = 80
            .Columns(44).HeaderText = "Packing"
            .Columns(44).Visible = True

            .Columns(78).Width = 400
            .Columns(78).HeaderText = "Reason"
            .Columns(78).Visible = True

            .Columns(97).Width = 80
            .Columns(97).HeaderText = "Pri Customer"
            .Columns(97).Visible = True

            .Columns(98).Width = 80
            .Columns(98).HeaderText = "Sec Customer"
            .Columns(98).Visible = True

            .Columns(99).Width = 120
            .Columns(99).HeaderText = "HK Price Term"
            .Columns(99).Visible = True

            .Columns(100).Width = 120
            .Columns(100).HeaderText = "Fty Price Term"
            .Columns(100).Visible = True

            .Columns(101).Width = 120
            .Columns(101).HeaderText = "Transport Term"
            .Columns(101).Visible = True

            .Columns(102).Width = 75
            .Columns(102).HeaderText = "Effect Date"
            .Columns(102).Visible = True

            .Columns(103).Width = 75
            .Columns(103).HeaderText = "Expiry Date"
            .Columns(103).Visible = True
        End With
    End Sub

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

            gsCompany = Trim(ma.copyQutCoCde)
            Call Update_gs_Value(gsCompany)

            gspStr = "sp_select_CURETPRC '" & ma.copyQutCoCde & "','" & strCust & "'"
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

            gsCompany = Trim(ma.copyQutCoCde)
            Call Update_gs_Value(gsCompany)

            gspStr = "sp_select_CURETPRC '" & ma.copyQutCoCde & "','" & strCust & "'"
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
                If rs_QUELC_copy.Tables.Count > 0 Then
                    If rs_QUELC_copy.Tables("RESULT").Rows.Count > 0 Then
                        For index As Integer = 0 To rs_QUELC_copy.Tables("RESULT").Rows.Count - 1
                            If rs_QUELC_copy.Tables("RESULT").Rows(index)("mode").ToString <> "DEL" Then
                                If rs_QUELC_copy.Tables("RESULT").Rows(index)("qec_grpcde").ToString = "001" Then
                                    dblELC = CDec(rs_QUELC_copy.Tables("RESULT").Rows(index)("qec_amt"))
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

    Private Function GetCusSty(ByVal strItmNo As String, ByVal strCusno As String, ByVal index As Integer) As String
        '*** Show Customer Alias
        Dim rs As New DataSet

        ' Get Cust Style No. from CIH
        'S = "㊣CUITMSUM_Q※S※" & cus1no & "※" & _
        '    cus2no & "※" & _
        '    strItmNo & "※" & rs_ToBeCopy("qud_colcde").Value & "※" & rs_ToBeCopy("qud_untcde").Value & "※" & rs_ToBeCopy("qud_inrqty").Value & "※" & _
        '   rs_ToBeCopy("qud_mtrqty").Value & "※" & IIf(rs_ToBeCopy("qud_conftr").Value = "", 1, rs_ToBeCopy("qud_conftr").Value) & "※" & gsUsrID
        'rsTmp = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gsCompany = Trim(ma.copyQutCoCde)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_CUITMHIS_Q '" & ma.copyQutCoCde & "','" & _
                                            sRealCus1no & "','" & _
                                            sRealCus2no & "','" & _
                                            strItmNo & "','" & _
                                            rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("icf_colcde") & "','" & _
                                            rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_pckunt") & "','" & _
                                            rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_inrqty") & "','" & _
                                            rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_mtrqty") & "','" & _
                                            IIf(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_conftr") = 0, 1, rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ipi_conftr")) & "','" & _
                                            gsUsrID & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading GetCusSty sp_select_CUITMSUM_Q :" & rtnStr)
            GetCusSty = ""
            Exit Function
        End If

        If rs.Tables("RESULT").Rows.Count > 0 Then
            GetCusSty = IIf(Trim(rs.Tables("RESULT").Rows(0)("cis_cusstyno")) = "", "", rs.Tables("RESULT").Rows(0)("cis_cusstyno"))

            txtCusItm_Text = rs.Tables("RESULT").Rows(0)("cis_cusitm")

        Else
            ' Get Cust Style No. from IM
            Dim rsCusals As New DataSet

            'S = "㊣IMCUSSTY_QU※S※" & strItmNo & "※" & strCusno
            'rsTmp = objBSGate.Enquire(gsConnStr, "sp_general", S)

            Cursor = Cursors.WaitCursor

            gsCompany = Trim(ma.copyQutCoCde)
            Call Update_gs_Value(gsCompany)

            gspStr = "sp_select_IMCUSSTY_QU '" & ma.copyQutCoCde & "','" & strItmNo & "','" & strCusno & "'"
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
        End If
    End Function
    Private Function GetCusSty2(ByVal strItmNo As String, ByVal strCusno As String, ByVal index As Integer) As String
        '*** Show Customer Alias
        Dim rs As New DataSet

        ' Get Cust Style No. from CIH
        'S = "㊣CUITMSUM_Q※S※" & cus1no & "※" & _
        '    cus2no & "※" & _
        '    strItmNo & "※" & rs_ToBeCopy("qud_colcde").Value & "※" & rs_ToBeCopy("qud_untcde").Value & "※" & rs_ToBeCopy("qud_inrqty").Value & "※" & _
        '   rs_ToBeCopy("qud_mtrqty").Value & "※" & IIf(rs_ToBeCopy("qud_conftr").Value = "", 1, rs_ToBeCopy("qud_conftr").Value) & "※" & gsUsrID
        'rsTmp = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gsCompany = Trim(ma.copyQutCoCde)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_CUITMHIS_Q '" & ma.copyQutCoCde & "','" & _
                                            sRealCus1no & "','" & _
                                            sRealCus2no & "','" & _
                                            strItmNo & "','" & _
                                            rs_QUOTNDTL.Tables("RESULT").DefaultView(index)("qud_colcde") & "','" & _
                                            rs_QUOTNDTL.Tables("RESULT").DefaultView(index)("qud_untcde") & "','" & _
                                            rs_QUOTNDTL.Tables("RESULT").DefaultView(index)("qud_inrqty") & "','" & _
                                            rs_QUOTNDTL.Tables("RESULT").DefaultView(index)("qud_mtrqty") & "','" & _
                                            IIf(rs_QUOTNDTL.Tables("RESULT").DefaultView(index)("qud_conftr") = 0, 1, rs_QUOTNDTL.Tables("RESULT").DefaultView(index)("qud_conftr")) & "','" & _
                                            rs_QUOTNDTL.Tables("RESULT").DefaultView(index)("qud_ftyprctrm") & "','" & _
                                            rs_QUOTNDTL.Tables("RESULT").DefaultView(index)("qud_prctrm") & "','" & _
                                            rs_QUOTNDTL.Tables("RESULT").DefaultView(index)("qud_trantrm") & "','" & _
                                            gsUsrID & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading GetCusSty2 sp_select_CUITMSUM_Q :" & rtnStr)
            GetCusSty2 = ""
            Exit Function
        End If

        If rs.Tables("RESULT").Rows.Count > 0 Then
            GetCusSty2 = IIf(Trim(rs.Tables("RESULT").Rows(0)("cis_cusstyno")) = "", "", rs.Tables("RESULT").Rows(0)("cis_cusstyno"))

            txtCusItm_Text = rs.Tables("RESULT").Rows(0)("cis_cusitm")

        Else
            '' '' Get Cust Style No. from IM
            ' ''Dim rsCusals As New DataSet

            '' ''S = "㊣IMCUSSTY_QU※S※" & strItmNo & "※" & strCusno
            '' ''rsTmp = objBSGate.Enquire(gsConnStr, "sp_general", S)

            ' ''Cursor = Cursors.WaitCursor

            ' ''gsCompany = Trim(ma.copyQutCoCde)
            ' ''Call Update_gs_Value(gsCompany)

            ' ''gspStr = "sp_select_IMCUSSTY_QU '" & ma.copyQutCoCde & "','" & strItmNo & "','" & strCusno & "'"
            ' ''rtnLong = execute_SQLStatement(gspStr, rsCusals, rtnStr)
            ' ''gspStr = ""

            ' ''Cursor = Cursors.Default

            ' ''If rtnLong <> RC_SUCCESS Then
            ' ''    MsgBox("Error on loading GetCusSty2 sp_select_IMCUSSTY_QU :" & rtnStr)
            ' ''    GetCusSty2 = ""
            ' ''    Exit Function
            ' ''End If

            ' ''If rsCusals.Tables("RESULT").Rows.Count > 0 Then
            ' ''    GetCusSty2 = IIf(Trim(rsCusals.Tables("RESULT").Rows(0)("ics_cusstyno").ToString) = "", "", rsCusals.Tables("RESULT").Rows(0)("ics_cusstyno").ToString)
            ' ''Else
            ' ''    GetCusSty2 = ""
            ' ''End If
        End If
    End Function

    Private Sub Cal_Price(ByVal index As Integer)
        '*** Calculate Cost Element
        Dim dblCstEmtPert As Double
        Dim dblCstEmtAmt As Double
        Dim i As Integer

        dblCstEmtPert = 0
        dblCstEmtAmt = 0

        '*************************** get markup information  ***************************
        'S = "㊣CUMCAMRK_item※S※" & Trim(Split(frmCopyQut.cboPriCus.Text, " - ")(0)) & "※" & frmCopyQut.rs_QUOTNDTL_COPY("ibi_itmno").Value
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gspStr = "sp_select_CUMCAMRK_item '" & strNewCocde & "','" & Trim(Split(sRealCus1no, "-")(0)) & "','" & rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ibi_itmno") & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUMCAMRK, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading Cal_Price sp_select_CUMCAMRK_item :" & rtnStr)
            Exit Sub
        End If

        If rs_CUMCAMRK.Tables("RESULT").Rows.Count = 0 Then
            drNewRowYFI = rs_CUMCAMRK.Tables("RESULT").NewRow
            drNewRowYFI("yfi_fml") = ""
            rs_CUMCAMRK.Tables("RESULT").Rows.Add(drNewRowYFI)
            rs_CUMCAMRK.Tables("RESULT").AcceptChanges()
        End If

        drNewRow("qud_fcurcde") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_curcde")
        drNewRow("qud_ftyprc") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_ftyprc")
        drNewRow("qud_ftycst") = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_ftycst")

        '*** Calcualte Basic Price in Customer Currency
        If rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_bcurcde") <> drNewRow("qud_curcde") Then
            dr = rs_CUBASINF_CR.Tables("RESULT").Select("ysi_def = 'Y'")

            If drNewRow("qud_curcde") = dr(0)("ysi_cde") Then
                dr = rs_CUBASINF_CR.Tables("RESULT").Select("ysi_cde = " & "'" & rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_bcurcde") & "'")
                drNewRow("qud_basprc") = Format(roundup(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_basprc") * dr(0)("ysi_selrat")), "########0.0000")
            Else
                dr = rs_CUBASINF_CR.Tables("RESULT").Select("ysi_cde = " & "'" & drNewRow("qud_curcde") & "'")
                drNewRow("qud_basprc") = Format(roundup(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_basprc") / dr(0)("ysi_selrat")), "########0.0000")
            End If
        Else
            drNewRow("qud_basprc") = Format(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_basprc"), "########0.0000")
        End If

        If rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_bcurcde") <> drNewRow("qud_curcde") Then
            dr = rs_CUBASINF_CR.Tables("RESULT").Select("ysi_def = 'Y'")

            If drNewRow("qud_curcde") <> dr(0)("ysi_cde") Then
                dr = rs_CUBASINF_CR.Tables("RESULT").Select("ysi_cde = " & "'" & drNewRow("qud_curcde") & "'")

                'drNewRow("qud_cus1sp") = Format(roundup(Eval(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_basprc"), rs_CUMCAMRK.Tables("RESULT").Rows(0)("yfi_fml")) / dr(0)("ysi_selrat")), "########0.0000")
                drNewRow("qud_cus1sp") = Format(round2(Eval(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_basprc"), rs_CUMCAMRK.Tables("RESULT").Rows(0)("yfi_fml")) / dr(0)("ysi_selrat")), "########0.0000")

                strCurExRat = CStr(dr(0)("ysi_selrat"))
                strCurExEffDat = Format(dr(0)("yce_effdat"), "yyyy-MM-dd")

                If rs_QUCSTEMT_copy.Tables.Count > 0 Then
                    If rs_QUCSTEMT_copy.Tables("RESULT").Rows.Count > 0 Then
                        'rs_QUCSTEMT_copy.sort = " qce_ceseq asc"
                        For i = 0 To rs_QUCSTEMT_copy.Tables("RESULT").Rows.Count - 1
                            If rs_QUCSTEMT_copy.Tables("RESULT").Rows(i)("mode").ToString <> "DEL" Then
                                If CDec(IIf(IsDBNull(rs_QUCSTEMT_copy.Tables("RESULT").Rows(i)("qce_percent")) = True, 0, rs_QUCSTEMT_copy.Tables("RESULT").Rows(i)("qce_percent"))) <> 0 Then
                                    drNewRow("qud_cus1sp") = ((CDec(drNewRow("qud_cus1sp")) / _
                                                            (100 - CDec(IIf(IsDBNull(rs_QUCSTEMT_copy.Tables("RESULT").Rows(i)("qce_percent")) = True, 0, rs_QUCSTEMT_copy.Tables("RESULT").Rows(i)("qce_percent"))))) * 100) / dr(0)("ysi_selrat")
                                End If

                                If CDec(IIf(IsDBNull(rs_QUCSTEMT_copy.Tables("RESULT").Rows(i)("qce_amt")) = True, 0, rs_QUCSTEMT_copy.Tables("RESULT").Rows(i)("qce_amt"))) <> 0 Then
                                    dblCstEmtAmt = CDec(IIf(IsDBNull(rs_QUCSTEMT_copy.Tables("RESULT").Rows(i)("qce_amt")) = True, 0, rs_QUCSTEMT_copy.Tables("RESULT").Rows(i)("qce_amt"))) / dr(0)("ysi_selrat")
                                    drNewRow("qud_cus1sp") = CDec(IIf(drNewRow("qud_cus1sp") = 0, 0, drNewRow("qud_cus1sp"))) + dblCstEmtAmt
                                End If
                            End If
                            dblCstEmtPert = 0
                            dblCstEmtAmt = 0
                        Next
                    End If
                End If
                'drNewRow("qud_cus1sp") = Format(roundup(drNewRow("qud_cus1sp")), "########0.0000")
                drNewRow("qud_cus1sp") = Format(round2(drNewRow("qud_cus1sp")), "########0.0000")

                If sRealCus2no <> "" Then
                    If drNewRow("qud_prcsec").ToString = "MU" Then
                        'drNewRow("qud_cus2sp") = Format(roundup(CDec(drNewRow("qud_cus1sp")) * (1 + drNewRow("qud_grsmgn") / 100)), "########0.0000")
                        drNewRow("qud_cus2sp") = Format(round2(CDec(drNewRow("qud_cus1sp")) * (1 + drNewRow("qud_grsmgn") / 100)), "########0.0000")
                    Else
                        'drNewRow("qud_cus2sp") = Format(roundup(CDec(drNewRow("qud_cus1sp")) / (1 - drNewRow("qud_grsmgn") / 100)), "########0.0000")
                        drNewRow("qud_cus2sp") = Format(round2(CDec(drNewRow("qud_cus1sp")) / (1 - drNewRow("qud_grsmgn") / 100)), "########0.0000")
                    End If
                End If

                If drNewRow("qud_discnt") > 0 Then
                    'drNewRow("qud_cus1dp") = Format(roundup(drNewRow("qud_cus1sp") * (1 - (drNewRow("qud_discnt") / 100))), "########0.0000")
                    drNewRow("qud_cus1dp") = Format(round2(drNewRow("qud_cus1sp") * (1 - (drNewRow("qud_discnt") / 100))), "########0.0000")
                Else
                    drNewRow("qud_cus1dp") = drNewRow("qud_cus1sp")
                End If

                If sRealCus2no <> "" Then
                    If drNewRow("qud_prcsec").ToString = "MU" Then
                        'drNewRow("qud_cus2dp") = Format(roundup(CDec(drNewRow("qud_cus1dp")) * (1 + drNewRow("qud_grsmgn") / 100)), "########0.0000")
                        drNewRow("qud_cus2dp") = Format(round2(CDec(drNewRow("qud_cus1dp")) * (1 + drNewRow("qud_grsmgn") / 100)), "########0.0000")
                    Else
                        'drNewRow("qud_cus2dp") = Format(roundup(CDec(drNewRow("qud_cus1dp")) / (1 - drNewRow("qud_grsmgn") / 100)), "########0.0000")
                        drNewRow("qud_cus2dp") = Format(round2(CDec(drNewRow("qud_cus1dp")) / (1 - drNewRow("qud_grsmgn") / 100)), "########0.0000")
                    End If
                End If
            Else
                dr = rs_CUBASINF_CR.Tables("RESULT").Select("ysi_cde = " & "'" & drNewRow("qud_curcde") & "'")

                'drNewRow("qud_cus1sp") = Format(roundup(Eval((rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_basprc") * dr(0)("ysi_selrat")), rs_CUMCAMRK.Tables("RESULT").Rows(0)("yfi_fml"))), "########0.0000")
                drNewRow("qud_cus1sp") = Format(round2(Eval((rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_basprc") * dr(0)("ysi_selrat")), rs_CUMCAMRK.Tables("RESULT").Rows(0)("yfi_fml"))), "########0.0000")

                strCurExRat = CStr(dr(0)("ysi_selrat"))
                strCurExEffDat = Format(dr(0)("yce_effdat"), "yyyy-MM-dd")

                If rs_QUCSTEMT_copy.Tables.Count > 0 Then
                    If rs_QUCSTEMT_copy.Tables("RESULT").Rows.Count > 0 Then
                        'rs_QUCSTEMT_copy.sort = " qce_ceseq asc"
                        For i = 0 To rs_QUCSTEMT_copy.Tables("RESULT").Rows.Count - 1
                            If rs_QUCSTEMT_copy.Tables("RESULT").Rows(i)("mode").ToString <> "DEL" Then
                                If CDec(IIf(IsDBNull(rs_QUCSTEMT_copy.Tables("RESULT").Rows(i)("qce_percent")) = True, 0, rs_QUCSTEMT_copy.Tables("RESULT").Rows(i)("qce_percent"))) <> 0 Then
                                    drNewRow("qud_cus1sp") = ((CDec(drNewRow("qud_cus1sp")) / _
                                                            (100 - CDec(IIf(IsDBNull(rs_QUCSTEMT_copy.Tables("RESULT").Rows(i)("qce_percent")) = True, 0, rs_QUCSTEMT_copy.Tables("RESULT").Rows(i)("qce_percent"))))) * 100) * dr(0)("ysi_selrat")
                                End If

                                If CDec(IIf(IsDBNull(rs_QUCSTEMT_copy.Tables("RESULT").Rows(i)("qce_amt")) = True, 0, rs_QUCSTEMT_copy.Tables("RESULT").Rows(i)("qce_amt"))) <> 0 Then
                                    dblCstEmtAmt = CDec(IIf(IsDBNull(rs_QUCSTEMT_copy.Tables("RESULT").Rows(i)("qce_amt")) = True, 0, rs_QUCSTEMT_copy.Tables("RESULT").Rows(i)("qce_amt"))) * dr(0)("ysi_selrat")
                                    drNewRow("qud_cus1sp") = CDec(IIf(drNewRow("qud_cus1sp") = 0, 0, drNewRow("qud_cus1sp"))) + dblCstEmtAmt
                                End If
                            End If
                            dblCstEmtPert = 0
                            dblCstEmtAmt = 0
                        Next
                    End If
                End If
                'drNewRow("qud_cus1sp") = Format(roundup(round(drNewRow("qud_cus1sp"), 3)), "###,###,##0.0000")
                drNewRow("qud_cus1sp") = Format(round2(round(drNewRow("qud_cus1sp"), 3)), "###,###,##0.0000")

                If sRealCus2no <> "" Then
                    If drNewRow("qud_prcsec").ToString = "MU" Then
                        'drNewRow("qud_cus2sp") = Format(roundup(CDec(drNewRow("qud_cus1sp")) * (1 + drNewRow("qud_grsmgn") / 100)), "########0.0000")
                        drNewRow("qud_cus2sp") = Format(round2(CDec(drNewRow("qud_cus1sp")) * (1 + drNewRow("qud_grsmgn") / 100)), "########0.0000")
                    Else
                        'drNewRow("qud_cus2sp") = Format(roundup(CDec(drNewRow("qud_cus1sp")) / (1 - drNewRow("qud_grsmgn") / 100)), "########0.0000")
                        drNewRow("qud_cus2sp") = Format(round2(CDec(drNewRow("qud_cus1sp")) / (1 - drNewRow("qud_grsmgn") / 100)), "########0.0000")
                    End If
                End If

                If drNewRow("qud_discnt") > 0 Then
                    'drNewRow("qud_cus1dp") = Format(roundup(drNewRow("qud_cus1sp") * (1 - (drNewRow("qud_discnt") / 100))), "########0.0000")
                    drNewRow("qud_cus1dp") = Format(round2(drNewRow("qud_cus1sp") * (1 - (drNewRow("qud_discnt") / 100))), "########0.0000")
                Else
                    drNewRow("qud_cus1dp") = drNewRow("qud_cus1sp")
                End If

                If sRealCus2no <> "" Then
                    If drNewRow("qud_prcsec").ToString = "MU" Then
                        'drNewRow("qud_cus2dp") = Format(roundup(CDec(drNewRow("qud_cus1dp")) * (1 + drNewRow("qud_grsmgn") / 100)), "########0.0000")
                        drNewRow("qud_cus2dp") = Format(round2(CDec(drNewRow("qud_cus1dp")) * (1 + drNewRow("qud_grsmgn") / 100)), "########0.0000")
                    Else
                        'drNewRow("qud_cus2dp") = Format(roundup(CDec(drNewRow("qud_cus1dp")) / (1 - drNewRow("qud_grsmgn") / 100)), "########0.0000")
                        drNewRow("qud_cus2dp") = Format(round2(CDec(drNewRow("qud_cus1dp")) / (1 - drNewRow("qud_grsmgn") / 100)), "########0.0000")
                    End If
                End If
            End If
        Else                                                                                                                '*******'Formula ******
            'drNewRow("qud_cus1sp") = Format(roundup(Eval(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_basprc"), rs_CUMCAMRK.Tables("RESULT").Rows(0)("yfi_fml"))), "########0.0000")
            drNewRow("qud_cus1sp") = Format(round2(Eval(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("imu_basprc"), rs_CUMCAMRK.Tables("RESULT").Rows(0)("yfi_fml"))), "########0.0000")

            dr = rs_CUBASINF_CR.Tables("RESULT").Select("ysi_def = 'Y'")

            strCurExRat = CStr(dr(0)("ysi_selrat"))
            strCurExEffDat = Format(dr(0)("yce_effdat"), "yyyy-MM-dd")

            If rs_QUCSTEMT_copy.Tables.Count > 0 Then
                If rs_QUCSTEMT_copy.Tables("RESULT").Rows.Count > 0 Then
                    If CDbl(drNewRow("qud_cus1sp")) > 0 Then
                        'rs_QUCSTEMT_copy.sort = " qce_ceseq asc"
                        For i = 0 To rs_QUCSTEMT_copy.Tables("RESULT").Rows.Count - 1
                            If rs_QUCSTEMT_copy.Tables("RESULT").Rows(i)("mode").ToString <> "DEL" Then
                                If CDec(IIf(IsDBNull(rs_QUCSTEMT_copy.Tables("RESULT").Rows(i)("qce_percent")) = True, 0, rs_QUCSTEMT_copy.Tables("RESULT").Rows(i)("qce_percent"))) <> 0 Then
                                    drNewRow("qud_cus1sp") = ((CDec(drNewRow("qud_cus1sp")) / _
                                                            (100 - CDec(IIf(IsDBNull(rs_QUCSTEMT_copy.Tables("RESULT").Rows(i)("qce_percent")) = True, 0, rs_QUCSTEMT_copy.Tables("RESULT").Rows(i)("qce_percent"))))) * 100)
                                End If

                                If CDec(IIf(IsDBNull(rs_QUCSTEMT_copy.Tables("RESULT").Rows(i)("qce_amt")) = True, 0, rs_QUCSTEMT_copy.Tables("RESULT").Rows(i)("qce_amt"))) <> 0 Then
                                    dblCstEmtAmt = CDec(IIf(IsDBNull(rs_QUCSTEMT_copy.Tables("RESULT").Rows(i)("qce_amt")) = True, 0, rs_QUCSTEMT_copy.Tables("RESULT").Rows(i)("qce_amt")))
                                    drNewRow("qud_cus1sp") = CDec(IIf(drNewRow("qud_cus1sp") = 0, 0, drNewRow("qud_cus1sp"))) + dblCstEmtAmt
                                End If
                            End If
                            dblCstEmtPert = 0
                            dblCstEmtAmt = 0
                        Next
                    End If
                End If
            End If
            drNewRow("qud_cus1sp") = round2(round(drNewRow("qud_cus1sp"), 3))
            'drNewRow("qud_cus1sp") = roundup(drNewRow("qud_cus1sp"))

            If sRealCus2no <> "" Then
                If drNewRow("qud_prcsec").ToString = "MU" Then
                    'drNewRow("qud_cus2sp") = Format(roundup(CDec(drNewRow("qud_cus1sp")) * (1 + drNewRow("qud_grsmgn") / 100)), "########0.0000")
                    drNewRow("qud_cus2sp") = Format(round2(CDec(drNewRow("qud_cus1sp")) * (1 + drNewRow("qud_grsmgn") / 100)), "########0.0000")
                Else
                    'drNewRow("qud_cus2sp") = Format(roundup(CDec(drNewRow("qud_cus1sp")) / (1 - drNewRow("qud_grsmgn") / 100)), "########0.0000")
                    drNewRow("qud_cus2sp") = Format(round2(CDec(drNewRow("qud_cus1sp")) / (1 - drNewRow("qud_grsmgn") / 100)), "########0.0000")
                End If
            End If

            If drNewRow("qud_discnt") > 0 Then
                'drNewRow("qud_cus1dp") = Format(roundup(drNewRow("qud_cus1sp") * (1 - (drNewRow("qud_discnt") / 100))), "########0.0000")
                drNewRow("qud_cus1dp") = Format(round2(drNewRow("qud_cus1sp") * (1 - (drNewRow("qud_discnt") / 100))), "########0.0000")
            Else
                drNewRow("qud_cus1dp") = drNewRow("qud_cus1sp")
            End If

            If sRealCus2no <> "" Then
                If drNewRow("qud_prcsec").ToString = "MU" Then
                    'drNewRow("qud_cus2dp") = Format(roundup(CDec(drNewRow("qud_cus1dp")) * (1 + drNewRow("qud_grsmgn") / 100)), "########0.0000")
                    drNewRow("qud_cus2dp") = Format(round2(CDec(drNewRow("qud_cus1dp")) * (1 + drNewRow("qud_grsmgn") / 100)), "########0.0000")
                Else
                    'drNewRow("qud_cus2dp") = Format(roundup(CDec(drNewRow("qud_cus1dp")) / (1 - drNewRow("qud_grsmgn") / 100)), "########0.0000")
                    drNewRow("qud_cus2dp") = Format(round2(CDec(drNewRow("qud_cus1dp")) / (1 - drNewRow("qud_grsmgn") / 100)), "########0.0000")
                End If
            End If
        End If

        If IIf(IsDBNull(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ycf_value")) = True, 0, rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ycf_value")) = 0 Then
            drNewRow("qud_smpunt") = drNewRow("qud_untcde")
            drNewRow("qud_smpprc") = Format(drNewRow("qud_cus1dp"), "########0.0000")
        Else
            drNewRow("qud_smpunt") = "PC"
            'drNewRow("qud_smpprc") = Format(roundup(drNewRow("qud_cus1dp") / rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ycf_value")), "########0.0000")
            drNewRow("qud_smpprc") = Format(round2(drNewRow("qud_cus1dp") / rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ycf_value")), "########0.0000")
        End If

        If isABUAssortment(drNewRow("qud_itmno")) = True Then
            drNewRow("qud_smpunt") = "PC"
            'drNewRow("qud_smpprc") = Format(roundup(drNewRow("qud_cus1dp") / drNewRow("qud_conftr")), "########0.0000")
            drNewRow("qud_smpprc") = Format(round2(drNewRow("qud_cus1dp") / drNewRow("qud_conftr")), "########0.0000")
        End If
    End Sub

    Private Function isABUAssortment(ByVal itmNo As String) As Boolean
        '*** FOR ALL ASSORTMENT
        Dim rs_ABUASST As New DataSet

        isABUAssortment = False

        'S = "㊣CHECK_ASST_FOR_PC※S※" & IIf(itmNo = "", "X", itmNo)

        Cursor = Cursors.WaitCursor

        gsCompany = Trim(ma.copyQutCoCde)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_CHECK_ASST_FOR_PC '" & ma.copyQutCoCde & "','" & IIf(itmNo = "", "X", itmNo) & "'"
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

    Private Sub fill_QUCPTBKD()
        'S = "㊣IMMATBKD※S※" & rs_ToBeCopy("qud_itmno")
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gsCompany = Trim(ma.copyQutCoCde)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_IMMATBKD '" & ma.copyQutCoCde & "','" & drNewRow("qud_itmno") & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_IMMATBKD, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading fill_QUCPTBKD sp_select_IMMATBKD :" & rtnStr)
            Exit Sub
        End If

        If rs_IMMATBKD.Tables("RESULT").Rows.Count > 0 Then
            For index As Integer = 0 To rs_IMMATBKD.Tables("RESULT").Rows.Count - 1
                drNewRowIBM = rs_QUCPTBKD_copy.Tables("RESULT").NewRow
                drNewRowIBM("mode") = "NEW"
                drNewRowIBM("Del") = " "
                drNewRowIBM("qcb_qutno") = ""
                drNewRowIBM("qcb_qutseq") = rs_ToBeCopy_Count
                drNewRowIBM("qcb_itmno") = drNewRow("qud_itmno")
                drNewRowIBM("qcb_cptseq") = rs_IMMATBKD.Tables("RESULT").Rows(index)("ibm_matseq")
                drNewRowIBM("qcb_cpt") = rs_IMMATBKD.Tables("RESULT").Rows(index)("ibm_mat")
                drNewRowIBM("qcb_curcde") = rs_IMMATBKD.Tables("RESULT").Rows(index)("ibm_curcde")
                drNewRowIBM("qcb_cst") = rs_IMMATBKD.Tables("RESULT").Rows(index)("ibm_cst")
                drNewRowIBM("qcb_cstpct") = rs_IMMATBKD.Tables("RESULT").Rows(index)("ibm_cstper")
                drNewRowIBM("qcb_pct") = rs_IMMATBKD.Tables("RESULT").Rows(index)("ibm_wgtper")
                rs_QUCPTBKD_copy.Tables("RESULT").Rows.Add(drNewRowIBM)
            Next
        End If
    End Sub

    Private Sub fill_CIHItem(ByVal index As Integer)
        Dim rs As New DataSet
        Dim itmNo As String

        itmNo = rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("qud_itmno")

        'S = "㊣CUITMSUM_Q_check※S※" & cus1no & "※" & cus2no & "※" & itmNo
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gsCompany = Trim(ma.copyQutCoCde)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_CUITMSUM_Q_check '" & ma.copyQutCoCde & "','" & sRealCus1no & "','" & sRealCus2no & "','" & itmNo & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading fill_CIHItem sp_select_CUITMSUM_Q_check :" & rtnStr)
            Exit Sub
        End If

        If rs.Tables("RESULT").Rows.Count > 0 Then
            drNewRow("qud_itmno") = itmNo
            rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("ibi_itmno") = itmNo
        End If
    End Sub

    Private Sub fill_QUASSINF(ByVal index As Integer)
        'S = "㊣IMBOMASS_Q_copy※S※" & rs_ToBeCopy("qud_itmno") & "※" & _
        '    frmCopyQut.rs_QUOTNDTL_COPY("qud_qutno") & "※" & _
        '    frmCopyQut.rs_QUOTNDTL_COPY("qud_qutseq") & "※" & _
        '    gsUsrID
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gsCompany = Trim(ma.copyQutCoCde)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_IMBOMASS_Q_copy '" & ma.copyQutCoCde & "','" & _
                                                drNewRow("qud_itmno") & "','" & _
                                                rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("qud_qutno") & "','" & _
                                                rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("qud_qutseq") & "','" & _
                                                gsUsrID & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_IMBOMASS, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading fill_QUASSINF sp_select_IMBOMASS_Q_copy :" & rtnStr)
            Exit Sub
        End If

        If rs_IMBOMASS.Tables("RESULT").Rows.Count > 0 Then
            For i As Integer = 0 To rs_IMBOMASS.Tables("RESULT").Rows.Count - 1
                drNewRowIBA = rs_QUASSINF_copy.Tables("RESULT").NewRow
                drNewRowIBA("mode") = "NEW"
                drNewRowIBA("qai_qutno") = ""
                drNewRowIBA("qai_qutseq") = rs_ToBeCopy_Count
                drNewRowIBA("qai_itmno") = drNewRow("qud_itmno")
                drNewRowIBA("qai_assitm") = rs_IMBOMASS.Tables("RESULT").Rows(i)("iba_assitm")
                drNewRowIBA("qai_assdsc") = rs_IMBOMASS.Tables("RESULT").Rows(i)("ibi_engdsc")
                drNewRowIBA("qai_colcde") = rs_IMBOMASS.Tables("RESULT").Rows(i)("iba_colcde")
                drNewRowIBA("qai_coldsc") = rs_IMBOMASS.Tables("RESULT").Rows(i)("icf_coldsc")
                drNewRowIBA("qai_coldsc") = Replace(drNewRowIBA("qai_coldsc"), "'", "''")


                drNewRowIBA("qai_alsitmno") = rs_IMBOMASS.Tables("RESULT").Rows(i)("ibi_alsitmno")
                drNewRowIBA("qai_alscolcde") = rs_IMBOMASS.Tables("RESULT").Rows(i)("ibi_alscolcde")
                drNewRowIBA("qai_untcde") = rs_IMBOMASS.Tables("RESULT").Rows(i)("iba_pckunt")
                drNewRowIBA("qai_inrqty") = rs_IMBOMASS.Tables("RESULT").Rows(i)("iba_inrqty")
                drNewRowIBA("qai_mtrqty") = rs_IMBOMASS.Tables("RESULT").Rows(i)("iba_mtrqty")
                drNewRowIBA("qai_cusitm") = rs_IMBOMASS.Tables("RESULT").Rows(i)("qai_cusitm")
                drNewRowIBA("qai_cussku") = rs_IMBOMASS.Tables("RESULT").Rows(i)("qai_cussku")
                drNewRowIBA("qai_upcean") = rs_IMBOMASS.Tables("RESULT").Rows(i)("qai_upcean")
                drNewRowIBA("qai_cusrtl") = rs_IMBOMASS.Tables("RESULT").Rows(i)("qai_cusrtl")
                drNewRowIBA("qai_imperiod") = rs_IMBOMASS.Tables("RESULT").Rows(i)("iba_period")
                rs_QUASSINF_copy.Tables("RESULT").Rows.Add(drNewRowIBA)
            Next
        End If
    End Sub

    Private Sub fill_QUADDINF()
        'S = "㊣syquaddinf※S※" & cus1no & "※" & cus2no & "※1"
        'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

        Cursor = Cursors.WaitCursor

        gsCompany = Trim(ma.copyQutCoCde)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_syquaddinf '" & ma.copyQutCoCde & "','" & sRealCus1no & "','" & sRealCus2no & "','1'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYQUADDINF, rtnStr)
        gspStr = ""

        Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading fill_QUADDINF sp_select_syquaddinf :" & rtnStr)
            Exit Sub
        End If

        If rs_SYQUADDINF.Tables("RESULT").Rows.Count > 0 Then
            For index As Integer = 0 To rs_SYQUADDINF.Tables("RESULT").Rows.Count - 1
                drNewRowYQA = rs_QUADDINF_copy.Tables("RESULT").NewRow
                drNewRowYQA("mode") = "NEW"
                drNewRowYQA("qdi_qutno") = ""
                drNewRowYQA("qdi_qutseq") = rs_ToBeCopy_Count
                drNewRowYQA("qdi_fldid") = rs_SYQUADDINF.Tables("RESULT").Rows(index)("yqa_fldid")
                drNewRowYQA("yqa_flddesc") = rs_SYQUADDINF.Tables("RESULT").Rows(index)("yqa_flddesc")
                drNewRowYQA("qdi_value") = rs_SYQUADDINF.Tables("RESULT").Rows(index)("yqa_defval")
                drNewRowYQA("yqa_display") = rs_SYQUADDINF.Tables("RESULT").Rows(index)("yqa_display")
                rs_QUADDINF_copy.Tables("RESULT").Rows.Add(drNewRowYQA)
            Next
        End If
    End Sub

    Private Sub fill_QUCSTEMT()
        Dim strCusno As String
        Dim rsTmp As New DataSet
        Dim strBasPrc As String

        If sRealCus2no <> "" Then
            strCusno = sRealCus2no

            'S = "㊣cucstemt_qu※S※" & strCusno
            'rsTmp = objBSGate.Enquire(gsConnStr, "sp_general", S)

            Cursor = Cursors.WaitCursor

            gsCompany = Trim(ma.copyQutCoCde)
            Call Update_gs_Value(gsCompany)

            gspStr = "sp_select_cucstemt_qu '" & ma.copyQutCoCde & "','" & strCusno & "'"
            rtnLong = execute_SQLStatement(gspStr, rsTmp, rtnStr)
            gspStr = ""

            Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading fill_QUCSTEMT sp_select_cucstemt_qu 1 :" & rtnStr)
                Exit Sub
            End If

            If rsTmp.Tables("RESULT").Rows.Count = 0 Then
                strCusno = cus1no
            End If
        Else
            strCusno = sRealCus1no
        End If

        If strCusno = sRealCus1no Then
            'S = "㊣cucstemt_qu※S※" & strCusno
            'rsTmp = objBSGate.Enquire(gsConnStr, "sp_general", S)

            Cursor = Cursors.WaitCursor

            gsCompany = Trim(ma.copyQutCoCde)
            Call Update_gs_Value(gsCompany)

            gspStr = "sp_select_cucstemt_qu '" & ma.copyQutCoCde & "','" & strCusno & "'"
            rtnLong = execute_SQLStatement(gspStr, rsTmp, rtnStr)
            gspStr = ""

            Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading fill_QUCSTEMT sp_select_cucstemt_qu 2 :" & rtnStr)
                Exit Sub
            End If
        End If

        If rsTmp.Tables("RESULT").Rows.Count > 0 Then
            For index As Integer = 0 To rsTmp.Tables("RESULT").Rows.Count - 1
                drNewRowCCE = rs_QUCSTEMT_copy.Tables("RESULT").NewRow
                drNewRowCCE("mode") = "NEW"
                drNewRowCCE("qce_qutno") = ""
                drNewRowCCE("qce_qutseq") = rs_ToBeCopy_Count
                drNewRowCCE("qce_cecde") = rsTmp.Tables("RESULT").Rows(index)("cce_cecde")
                drNewRowCCE("qce_ceseq") = rsTmp.Tables("RESULT").Rows(index)("cce_seq")
                drNewRowCCE("cce_cedsc") = rsTmp.Tables("RESULT").Rows(index)("cce_cedsc")
                drNewRowCCE("cce_percent_d") = rsTmp.Tables("RESULT").Rows(index)("cce_percent_d")
                drNewRowCCE("qce_percent") = rsTmp.Tables("RESULT").Rows(index)("cce_percent")
                drNewRowCCE("qce_curcde") = rsTmp.Tables("RESULT").Rows(index)("cce_curcde")
                drNewRowCCE("cce_amt_d") = rsTmp.Tables("RESULT").Rows(index)("cce_amt_d")
                drNewRowCCE("qce_amt") = rsTmp.Tables("RESULT").Rows(index)("cce_amt")
                drNewRowCCE("cce_chg") = rsTmp.Tables("RESULT").Rows(index)("cce_chg")
                rs_QUCSTEMT_copy.Tables("RESULT").Rows.Add(drNewRowCCE)
            Next
            rs_QUCSTEMT_copy.Tables("RESULT").AcceptChanges()

            If sRealCus2no <> "" Then
                strCusno = sRealCus2no

                'S = "㊣CUCSTAMT_qu※S※" & strCusno
                'rsTmp = objBSGate.Enquire(gsConnStr, "sp_general", S)

                Cursor = Cursors.WaitCursor

                gsCompany = Trim(ma.copyQutCoCde)
                Call Update_gs_Value(gsCompany)

                gspStr = "sp_select_CUCSTAMT_qu '" & ma.copyQutCoCde & "','" & strCusno & "'"
                rtnLong = execute_SQLStatement(gspStr, rsTmp, rtnStr)
                gspStr = ""

                Cursor = Cursors.Default

                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading fill_QUCSTEMT sp_select_CUCSTAMT_qu 1 :" & rtnStr)
                    Exit Sub
                End If

                If rsTmp.Tables("RESULT").Rows.Count = 0 Then
                    strCusno = cus1no
                End If
            Else
                strCusno = sRealCus1no
            End If

            If strCusno = sRealCus1no Then
                'S = "㊣CUCSTAMT_qu※S※" & strCusno
                'rsTmp = objBSGate.Enquire(gsConnStr, "sp_general", S)

                Cursor = Cursors.WaitCursor

                gsCompany = Trim(ma.copyQutCoCde)
                Call Update_gs_Value(gsCompany)

                gspStr = "sp_select_CUCSTAMT_qu '" & ma.copyQutCoCde & "','" & strCusno & "'"
                rtnLong = execute_SQLStatement(gspStr, rsTmp, rtnStr)
                gspStr = ""

                Cursor = Cursors.Default

                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading fill_QUCSTEMT sp_select_CUCSTAMT_qu 2 :" & rtnStr)
                    Exit Sub
                End If
            End If

            If IsDBNull(drNewRow("qud_basprc")) = True Then
                strBasPrc = "0"
            Else
                strBasPrc = CStr(drNewRow("qud_basprc"))
            End If

            If rsTmp.Tables("RESULT").Rows.Count > 0 Then
                sFilter = "qce_qutseq = " & CStr(rs_ToBeCopy_Count) & " and mode <> 'DEL'"
                rs_QUCSTEMT_copy.Tables("RESULT").DefaultView.RowFilter = sFilter

                For index As Integer = 0 To rs_QUCSTEMT_copy.Tables("RESULT").DefaultView.Count - 1
                    sFilter = "cca_cecde = '" + rs_QUCSTEMT_copy.Tables("RESULT").DefaultView(index)("qce_cecde") + "' and " + _
                                    " cca_bp2 >= " + strBasPrc + "  and cca_bp1 <= " + strBasPrc
                    rsTmp.Tables("RESULT").DefaultView.RowFilter = sFilter

                    If rsTmp.Tables("RESULT").DefaultView.Count > 0 Then
                        rs_QUCSTEMT_copy.Tables("RESULT").DefaultView(index)("cce_amt_d") = rs_QUCSTEMT_copy.Tables("RESULT").DefaultView(index)("cce_amt_d") / rsTmp.Tables("RESULT").DefaultView(0)("cca_estqty")
                        rs_QUCSTEMT_copy.Tables("RESULT").DefaultView(index)("qce_amt") = rs_QUCSTEMT_copy.Tables("RESULT").DefaultView(index)("cce_amt_d")
                    End If
                Next
            End If

            sFilter = ""
            rs_QUCSTEMT_copy.Tables("RESULT").DefaultView.RowFilter = sFilter
        End If
    End Sub

    Private Sub fill_QUELC()
        Dim strCusno As String
        Dim rsTmp As New DataSet

        If sRealCus2no <> "" Then
            strCusno = sRealCus2no

            'S = "㊣cuelc_qu※S※" & strCusno
            'rsTmp = objBSGate.Enquire(gsConnStr, "sp_general", S)

            Cursor = Cursors.WaitCursor

            gsCompany = Trim(ma.copyQutCoCde)
            Call Update_gs_Value(gsCompany)

            gspStr = "sp_select_cuelc_qu '" & ma.copyQutCoCde & "','" & strCusno & "'"
            rtnLong = execute_SQLStatement(gspStr, rsTmp, rtnStr)
            gspStr = ""

            Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading fill_QUELC sp_select_cuelc_qu 1 :" & rtnStr)
                Exit Sub
            End If

            If rsTmp.Tables("RESULT").Rows.Count = 0 Then
                strCusno = sRealCus1no
            End If
        Else
            strCusno = sRealCus1no
        End If

        If strCusno = sRealCus1no Then
            'S = "㊣cuelc_qu※S※" & strCusno
            'rsTmp = objBSGate.Enquire(gsConnStr, "sp_general", S)

            Cursor = Cursors.WaitCursor

            gsCompany = Trim(ma.copyQutCoCde)
            Call Update_gs_Value(gsCompany)

            gspStr = "sp_select_cuelc_qu '" & ma.copyQutCoCde & "','" & strCusno & "'"
            rtnLong = execute_SQLStatement(gspStr, rsTmp, rtnStr)
            gspStr = ""

            Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading fill_QUELC sp_select_cuelc_qu 2 :" & rtnStr)
                Exit Sub
            End If
        End If

        If rsTmp.Tables("RESULT").Rows.Count > 0 Then
            For index As Integer = 0 To rsTmp.Tables("RESULT").Rows.Count - 1
                drNewRowCEC = rs_QUELC_copy.Tables("RESULT").NewRow
                drNewRowCEC("mode") = "NEW"
                drNewRowCEC("qec_qutno") = ""
                drNewRowCEC("qec_qutseq") = rs_ToBeCopy_Count
                drNewRowCEC("qec_grpcde") = rsTmp.Tables("RESULT").Rows(index)("cec_grpcde")
                drNewRowCEC("cec_grpdsc") = rsTmp.Tables("RESULT").Rows(index)("cec_grpdsc")
                drNewRowCEC("qec_curcde") = drNewRow("qud_curcde")
                drNewRowCEC("qec_amt") = 0
                rs_QUELC_copy.Tables("RESULT").Rows.Add(drNewRowCEC)
            Next
            rs_QUELC_copy.Tables("RESULT").AcceptChanges()
        End If

        sFilter = ""
        'rs_QUELC_copy.Tables("RESULT").DefaultView.RowFilter = sFilter
    End Sub

    Private Sub fill_QUELCDTL(ByVal index As Integer)
        Dim strCusno As String
        Dim rsTmp As New DataSet

        If sRealCus2no <> "" Then
            strCusno = sRealCus2no

            'S = "㊣cuelcdtl_qu※S※" & strCusno
            'rsTmp = objBSGate.Enquire(gsConnStr, "sp_general", S)

            Cursor = Cursors.WaitCursor

            gsCompany = Trim(ma.copyQutCoCde)
            Call Update_gs_Value(gsCompany)

            gspStr = "sp_select_cuelcdtl_qu '" & ma.copyQutCoCde & "','" & strCusno & "'"
            rtnLong = execute_SQLStatement(gspStr, rsTmp, rtnStr)
            gspStr = ""

            Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading fill_QUELCDTL sp_select_cuelcdtl_qu 1 :" & rtnStr)
                Exit Sub
            End If

            If rsTmp.Tables("RESULT").Rows.Count = 0 Then
                strCusno = sRealCus1no
            End If
        Else
            strCusno = sRealCus1no
        End If

        If strCusno = sRealCus1no Then
            'S = "㊣cuelcdtl_qu※S※" & strCusno
            'rsTmp = objBSGate.Enquire(gsConnStr, "sp_general", S)

            Cursor = Cursors.WaitCursor

            gsCompany = Trim(ma.copyQutCoCde)
            Call Update_gs_Value(gsCompany)

            gspStr = "sp_select_cuelcdtl_qu '" & ma.copyQutCoCde & "','" & strCusno & "'"
            rtnLong = execute_SQLStatement(gspStr, rsTmp, rtnStr)
            gspStr = ""

            Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading fill_QUELCDTL sp_select_cuelcdtl_qu 2 :" & rtnStr)
                Exit Sub
            End If
        End If

        If rsTmp.Tables("RESULT").Rows.Count > 0 Then
            For index1 As Integer = 0 To rsTmp.Tables("RESULT").Rows.Count - 1
                drNewRowCED = rs_QUELCDTL_copy.Tables("RESULT").NewRow
                drNewRowCED("mode") = "NEW"
                drNewRowCED("qed_qutno") = ""
                drNewRowCED("qed_qutseq") = rs_ToBeCopy_Count
                drNewRowCED("qed_grpcde") = rsTmp.Tables("RESULT").Rows(index1)("ced_grpcde")
                drNewRowCED("ced_grpdsc") = rsTmp.Tables("RESULT").Rows(index1)("ced_grpdsc")
                drNewRowCED("qed_seq") = rsTmp.Tables("RESULT").Rows(index1)("ced_seq")
                drNewRowCED("qed_cecde") = rsTmp.Tables("RESULT").Rows(index1)("ced_cecde")
                drNewRowCED("ced_cedsc") = rsTmp.Tables("RESULT").Rows(index1)("ced_cedsc")
                drNewRowCED("qed_percent") = rsTmp.Tables("RESULT").Rows(index1)("ced_percent")
                drNewRowCED("ced_chg") = rsTmp.Tables("RESULT").Rows(index1)("ced_chg")
                drNewRowCED("qed_curcde") = drNewRow("qud_curcde")
                drNewRowCED("qed_amt") = 0
                rs_QUELCDTL_copy.Tables("RESULT").Rows.Add(drNewRowCED)
                Call CalculateELC()
            Next
            rs_QUELCDTL_copy.Tables("RESULT").AcceptChanges()

            sFilter = "qed_qutseq = " + CStr(rs_ToBeCopy_Count) + " and mode = 'NEW'"
            rs_QUELCDTL_copy.Tables("RESULT").DefaultView.RowFilter = sFilter

            Call CalculateELCDuty(CDbl(rs_QUOTNDTL_copy.Tables("RESULT").DefaultView(index)("qud_dtyrat")))
            Call CalculateELCTran()

            sFilter = ""
            rs_QUELCDTL_copy.Tables("RESULT").DefaultView.RowFilter = sFilter
        End If
    End Sub

    Private Sub CalculateELC()
        Dim decAjdPrc As Double
        Dim rsTmp As New DataSet
        Dim strQudSeq As String
        Dim strGrpCde As String
        Dim strGrpCde_old As String
        Dim dblTtl As Double

        dblTtl = 0

        If rs_QUELCDTL_copy.Tables.Count > 0 Then
            If rs_QUELCDTL_copy.Tables("RESULT").DefaultView.Count > 0 Then
                If CDec(IIf(Trim(drNewRow("qud_cus2dp").ToString()) = "", "0", drNewRow("qud_cus2dp"))) <> 0 Then
                    decAjdPrc = CDec(drNewRow("qud_cus2dp"))
                Else
                    decAjdPrc = CDec(drNewRow("qud_cus1dp"))
                End If

                For index As Integer = 0 To rs_QUELCDTL_copy.Tables("RESULT").DefaultView.Count - 1
                    If Trim(rs_QUELCDTL_copy.Tables("RESULT").DefaultView(index)("ced_cedsc").ToString) = "Transportation" And _
                        rs_QUELCDTL_copy.Tables("RESULT").DefaultView(index)("mode").ToString <> "DEL" Then
                        If decAjdPrc = 0 Then
                            rs_QUELCDTL_copy.Tables("RESULT").DefaultView(index)("qed_amt") = 0
                            rs_QUELCDTL_copy.Tables("RESULT").DefaultView(index)("qed_percent") = 0
                        Else
                            rs_QUELCDTL_copy.Tables("RESULT").DefaultView(index)("qed_percent") = round((rs_QUELCDTL_copy.Tables("RESULT").DefaultView(index)("qed_amt") / decAjdPrc) * 100, 2)
                        End If
                    Else
                        rs_QUELCDTL_copy.Tables("RESULT").DefaultView(index)("qed_amt") = (rs_QUELCDTL_copy.Tables("RESULT").DefaultView(index)("qed_percent") * decAjdPrc) / 100
                    End If
                Next

                strGrpCde_old = rs_QUELCDTL_copy.Tables("RESULT").DefaultView(0)("qed_grpcde")

                For index As Integer = 0 To rs_QUELCDTL_copy.Tables("RESULT").DefaultView.Count - 1
                    strGrpCde = rs_QUELCDTL_copy.Tables("RESULT").DefaultView(index)("qed_grpcde")
                    strQudSeq = rs_QUELCDTL_copy.Tables("RESULT").DefaultView(index)("qed_qutseq")

                    If strGrpCde <> strGrpCde_old Then
                        dblTtl = 0
                    End If

                    If rs_QUELCDTL_copy.Tables("RESULT").DefaultView(index)("qed_qutseq").ToString = strQudSeq And _
                        rs_QUELCDTL_copy.Tables("RESULT").DefaultView(index)("qed_grpcde").ToString = strGrpCde Then
                        If rs_QUELCDTL_copy.Tables("RESULT").DefaultView(index)("mode") <> "DEL" Then
                            dblTtl = dblTtl + CDec(IIf(IsDBNull(rs_QUELCDTL_copy.Tables("RESULT").DefaultView(index)("qed_amt")) = True, 0, rs_QUELCDTL_copy.Tables("RESULT").DefaultView(index)("qed_amt")))
                        End If
                    End If

                    If rs_QUELC_copy.Tables("RESULT").DefaultView.Count > 0 Then
                        For index1 As Integer = 0 To rs_QUELC_copy.Tables("RESULT").DefaultView.Count - 1
                            If rs_QUELC_copy.Tables("RESULT").DefaultView(index1)("qec_grpcde").ToString = strGrpCde Then
                                rs_QUELC_copy.Tables("RESULT").DefaultView(index1)("qec_amt") = dblTtl + decAjdPrc

                                If rs_QUELC_copy.Tables("RESULT").DefaultView(index1)("mode").ToString <> "NEW" Then
                                    rs_QUELC_copy.Tables("RESULT").DefaultView(index1)("mode") = "UPD"
                                End If
                                'Exit Sub
                            End If
                        Next
                    End If
                    strGrpCde_old = strGrpCde
                Next
            End If
        End If
    End Sub

    Private Sub CalculateELCDuty(ByVal dblDuty As Double)
        If rs_QUELCDTL_copy.Tables.Count > 0 Then
            If rs_QUELCDTL_copy.Tables("RESULT").Rows.Count > 0 Then
                For index As Integer = 0 To rs_QUELCDTL_copy.Tables("RESULT").Rows.Count - 1
                    If rs_QUELCDTL_copy.Tables("RESULT").Rows(index)("ced_cedsc").ToString = "Duty" And _
                        rs_QUELCDTL_copy.Tables("RESULT").Rows(index)("mode").ToString <> "DEL" Then
                        rs_QUELCDTL_copy.Tables("RESULT").Rows(index)("qed_percent") = dblDuty

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

        If rs_QUELCDTL_copy.Tables.Count > 0 Then
            If rs_QUELCDTL_copy.Tables("RESULT").Rows.Count > 0 Then
                For index As Integer = 0 To rs_QUELCDTL_copy.Tables("RESULT").Rows.Count - 1
                    If Trim(rs_QUELCDTL_copy.Tables("RESULT").Rows(index)("ced_cedsc").ToString) = "Transportation" And _
                        rs_QUELCDTL_copy.Tables("RESULT").Rows(index)("mode").ToString <> "DEL" Then

                        ' Get Frieght Rate From Customer
                        If Trim(drNewRow("qud_prctrm")) <> "" Then
                            strPrcTrm = Microsoft.VisualBasic.Left(drNewRow("qud_prctrm"), InStr(drNewRow("qud_prctrm"), " - ") - 1)
                        Else
                            strPrcTrm = ""
                        End If

                        If Trim(sRealCus2no) <> "" Then
                            strCusno = sRealCus2no

                            'S = "㊣CUFLGRAT_qu※S※" & strCusno & "※" & strPrcTrm & "※" & gsUsrID
                            'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

                            Cursor = Cursors.WaitCursor

                            gsCompany = Trim(ma.copyQutCoCde)
                            Call Update_gs_Value(gsCompany)

                            gspStr = "sp_select_CUFLGRAT_qu '" & ma.copyQutCoCde & "','" & strCusno & "','" & strPrcTrm & "','" & gsUsrID & "'"
                            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                            gspStr = ""

                            Cursor = Cursors.Default

                            If rtnLong <> RC_SUCCESS Then
                                MsgBox("Error on loading CalculateELCTran sp_select_CUFLGRAT_qu 1 :" & rtnStr)
                                Exit Sub
                            End If

                            If rs.Tables("RESULT").Rows.Count = 0 Then
                                strCusno = sRealCus1no
                            End If
                        Else
                            strCusno = sRealCus1no
                        End If

                        If strCusno = sRealCus1no Then
                            'S = "㊣CUFLGRAT_qu※S※" & strCusno & "※" & strPrcTrm & "※" & gsUsrID
                            'rs = objBSGate.Enquire(gsConnStr, "sp_general", S)

                            Cursor = Cursors.WaitCursor

                            gsCompany = Trim(ma.copyQutCoCde)
                            Call Update_gs_Value(gsCompany)

                            gspStr = "sp_select_CUFLGRAT_qu '" & ma.copyQutCoCde & "','" & strCusno & "','" & strPrcTrm & "','" & gsUsrID & "'"
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

                        If Trim(drNewRow("qud_mtrqty").ToString) <> "" Then
                            intMtr = CInt(drNewRow("qud_mtrqty"))
                        Else
                            intMtr = 0
                        End If

                        If CDec(IIf(IsDBNull(drNewRow("qud_cus2dp")) = True, "0", drNewRow("qud_cus2dp"))) <> 0 Then
                            decAjdPrc = CDec(IIf(Trim(drNewRow("qud_cus2dp")) = "", "0", drNewRow("qud_cus2dp")))
                        Else
                            decAjdPrc = CDec(IIf(Trim(drNewRow("qud_cus1dp")) = "", "0", drNewRow("qud_cus1dp")))
                        End If

                        If Trim(drNewRow("qud_cft").ToString) = "" Then
                            drNewRow("qud_cft") = "0"
                        End If

                        dblTrans = ((CDbl(IIf(drNewRow("qud_cft") = 0, 0, drNewRow("qud_cft")))) / intMtr) * dblFlgRat

                        If decAjdPrc = 0 Then
                            rs_QUELCDTL_copy.Tables("RESULT").Rows(index)("qed_amt") = 0
                            rs_QUELCDTL_copy.Tables("RESULT").Rows(index)("qed_percent") = 0
                        Else
                            rs_QUELCDTL_copy.Tables("RESULT").Rows(index)("qed_amt") = dblTrans
                            rs_QUELCDTL_copy.Tables("RESULT").Rows(index)("qed_percent") = round((dblTrans / decAjdPrc) * 100, 2)
                        End If

                        Call CalculateELC()
                    End If
                Next
            End If
        End If
    End Sub

    Private Function CalculatePMU() As Double
        Dim dblELC As Double

        dblELC = 0

        If rs_QUELC_copy.Tables.Count > 0 Then
            If rs_QUELC_copy.Tables("RESULT").Rows.Count > 0 Then
                For index As Integer = 0 To rs_QUELC_copy.Tables("RESULT").Rows.Count - 1
                    If rs_QUELC_copy.Tables("RESULT").Rows(index)("mode").ToString <> "DEL" Then
                        If rs_QUELC_copy.Tables("RESULT").Rows(index)("qec_grpcde").ToString = "001" Then
                            dblELC = CDec(IIf(IsDBNull(rs_QUELC_copy.Tables("RESULT").Rows(index)("qec_amt")) = True, 0, rs_QUELC_copy.Tables("RESULT").Rows(index)("qec_amt")))
                            Exit For
                        End If
                    End If
                Next
            End If
        End If

        If Trim(drNewRow("qud_cususd").ToString) = "" Then
            drNewRow("qud_cususd") = 0
        End If

        If CDbl(Trim(drNewRow("qud_cususd").ToString)) <> 0 Then
            CalculatePMU = round(((CDec(drNewRow("qud_cususd")) - dblELC) / CDec(drNewRow("qud_cususd"))) * 100, 2)
            'CalculatePMU = roundup(((CDec(drNewRow("qud_cususd")) - dblELC) / CDec(drNewRow("qud_cususd"))) * 100)
        Else
            CalculatePMU = 0
        End If
    End Function



    Private Sub cmdYes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdYes.Click

        Dim i As Integer
        Dim temp_qud_itmtyp As String
        Dim temp_qud_contopc As String


        Dim Message As String
        Dim txt_itmrealno As String
        Dim txt_icf_colcde As String
        Dim txt_inner_in As String
        Dim txt_master_in As String
        Dim txt_inner_cm As String
        Dim txt_master_cm As String
        Dim txt_inrdin As String
        Dim txt_inrwin As String
        Dim txt_inrhin As String
        Dim txt_mtrdin As String
        Dim txt_mtrwin As String
        Dim txt_mtrhin As String
        Dim txt_inrdcm As String
        Dim txt_inrwcm As String
        Dim txt_inrhcm As String
        Dim txt_mtrdcm As String
        Dim txt_mtrwcm As String
        Dim txt_mtrhcm As String
        Dim txt_ipi_grswgt As String
        Dim txt_ipi_netwgt As String
        Dim txt_ipi_pckitr As String
        Dim txt_ipi_pckseq As String
        Dim txt_ipi_cft As String
        Dim txt_ipi_cbm As String
        Dim txt_ipi_qutdat As String

        Dim txt_cus1na As String
        Dim txt_cus2na As String

        Dim sFilter As String
        Dim tmp_hkprctrm As String
        Dim tmp_ftyprctrm As String
        Dim tmp_trantrm As String
        Dim tmp_colcde As String


        Dim li_index_insert As Integer
        Dim li_index_seq As Integer

        Dim max_seq_insert As Integer


        Dim ta1 As Integer
        Dim ta2 As String
        Dim ta3 As String
        Dim ta4 As String
        Dim ta5 As String
        Dim ta6 As String
        Dim ta7 As String
        Dim ta8 As String

        Dim index_for_copy As Integer

        Dim temp_cus1_for_name As String
        Dim temp_cus2_for_name As String

        flag_copy_success = False

        txt_icf_colcde = ""
        txt_inner_in = "0"
        txt_master_in = "0"
        txt_inner_cm = "0"
        txt_master_cm = "0"
        txt_inrdin = "0"
        txt_inrwin = "0"
        txt_inrhin = "0"
        txt_mtrdin = "0"
        txt_mtrwin = "0"
        txt_mtrhin = "0"
        txt_inrdcm = "0"
        txt_inrwcm = "0"
        txt_inrhcm = "0"
        txt_mtrdcm = "0"
        txt_mtrwcm = "0"
        txt_mtrhcm = "0"
        txt_ipi_grswgt = "0"
        txt_ipi_netwgt = "0"
        txt_ipi_pckitr = ""
        txt_ipi_pckseq = "0"
        txt_ipi_cft = "0"
        txt_ipi_cbm = "0"

        li_index_seq = 0
        index_for_copy = 0


        Dim cus1no As String
        Dim cus2no As String

        ''If rs_IMVENINF.Tables.Count = 0 Then
        '*** New logic to get Price Info
        If Trim(sRealCus1no) = "" Then
            cus1no = ""
        Else
            cus1no = Trim(Split(sRealCus1no, "-")(0))
        End If

        If Trim(sRealCus2no) = "" Then
            cus2no = ""
        Else
            cus2no = Trim(Split(sRealCus2no, "-")(0))
        End If



        'Gen Qutno
        gsCompany = Trim(strNewCocde)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_DOC_GEN '" & Trim(strNewCocde) & "','QO','" & gsUsrID & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        gspStr = ""

        '' Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdSaveClick sp_select_DOC_GEN :" & rtnStr)
            Exit Sub
        End If

        txtQutNo2.Text = rs.Tables("RESULT").Rows(0)(0).ToString

        'Copying each Item


        'get customer name
        gspStr = "sp_select_CUBASINF_P '" & strNewCocde & "','Primary'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_P, rtnStr)
        gspStr = ""
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading QUXLS001  sp_select_CUBASINF_P : " & rtnStr)
            Exit Sub
        End If

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        Call cboCus1NoClick2()

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Insert 
        If ma.chkPC_hdr.Checked = True Then
            txt_quh_conalltopc = "Y"
        Else
            txt_quh_conalltopc = "N"
        End If

        Dim tmp_cus2 As String
        tmp_cus2 = ma.get_qutcopied_cus2

        txt_SalRep_Text = Trim(Split(txt_SalRep_Text, "(")(0))
        txt_SalRep_Text = Microsoft.VisualBasic.Left(txt_SalRep_Text, 12)

        gspStr = "sp_insert_QUOTNHDR_copy '" & _
                Trim(Split(strNewCocde, "-")(0)) & "','" & _
            Trim(txtQutNo2.Text) & "','" & _
            Trim(Split(sRealCus1no, "-")(0)) & "','" & _
            Trim(Split(tmp_cus2, "-")(0)) & "','" & _
            "" & "','" & _
            Trim(Split(ma.txtCurCde.Text, "-")(0)) & "','" & _
                              txt_SalDiv_Text & "','" & _
                              txt_SalRep_Text & "','" & _
                      txt_Srname_Text & "','" & _
        ma.txtRmk.Text & "','" & _
        ma.txtDeptH.Text & "','" & _
        "" & "','" & _
        "" & " ','" & _
        "" & "','" & _
        txt_Cus1Cp_Text & "','" & _
        txt_quh_conalltopc & "','" & _
        txt_Cus1CgInt_Text & "','" & _
        txt_Cus1CgExt_Text & "','" & _
        gsUsrID & "'"


        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        gspStr = ""

        '' Cursor = Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading save_Detail sp_insert_QUOTNHDR :" & rtnStr)
            Exit Sub
        End If


        ''
        gspStr = "sp_select_CUBASINF_rounding '" & Trim(Split(strNewCocde, "-")(0)) & "','" & sRealCus1no & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_rounding, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading Display_Header rs_CUBASINF_rounding:" & rtnStr)
            'Exit Sub
        End If
        ''
        cus1_rounding = 4
        If rs_CUBASINF_rounding.Tables("RESULT").Rows.Count > 0 Then
            cus1_rounding = rs_CUBASINF_rounding.Tables("RESULT").Rows(0)("cbi_rounding")

        End If





        gspStr = "sp_select_QUOTNDTL '" & "" & "',''"
        rtnLong = execute_SQLStatement(gspStr, rs_QUOTNDTL, rtnStr)
        gspStr = ""

        li_index_insert = -1

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ''''''''''''For Each Row , Gen
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        For index As Integer = 0 To rs_valid.Tables("RESULT").DefaultView.Count - 1



            'NOT seq#
            li_index_insert = li_index_insert + 1

            li_index_seq = li_index_seq + 1

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            txt_itmno = rs_valid.Tables("RESULT").DefaultView(index)("qud_itmno").ToString.Trim()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



            ''find index
            'lloop to filer
            For index3 As Integer = 0 To rs_ToBeCopy.Tables("RESULT").Rows.Count - 1


                If rs_valid.Tables("RESULT").DefaultView(index)("qud_untcde").ToString.Trim = rs_ToBeCopy.Tables("RESULT").Rows(index3)("qud_untcde").ToString.Trim And _
                 rs_valid.Tables("RESULT").DefaultView(index)("qud_inrqty").ToString.Trim = rs_ToBeCopy.Tables("RESULT").Rows(index3)("qud_inrqty").ToString.Trim And _
                  rs_valid.Tables("RESULT").DefaultView(index)("qud_mtrqty").ToString.Trim = rs_ToBeCopy.Tables("RESULT").Rows(index3)("qud_mtrqty").ToString.Trim And _
                  rs_valid.Tables("RESULT").DefaultView(index)("qud_itmno").ToString.Trim = rs_ToBeCopy.Tables("RESULT").Rows(index3)("qud_itmno").ToString.Trim And _
                  rs_valid.Tables("RESULT").DefaultView(index)("imu_prctrm").ToString.Trim = rs_ToBeCopy.Tables("RESULT").Rows(index3)("qud_prctrm").ToString.Trim And _
                  rs_valid.Tables("RESULT").DefaultView(index)("imu_ftyprctrm").ToString.Trim = rs_ToBeCopy.Tables("RESULT").Rows(index3)("qud_ftyprctrm").ToString.Trim And _
                  rs_valid.Tables("RESULT").DefaultView(index)("imu_trantrm").ToString.Trim = rs_ToBeCopy.Tables("RESULT").Rows(index3)("qud_trantrm").ToString.Trim _
                  Then

                    index_for_copy = index3

                End If

            Next

            gsCompany = Trim(strNewCocde)
            Call Update_gs_Value(gsCompany)


            ''??
            gspStr = "sp_select_IMBASINF_Q '" & strNewCocde & "','" & txt_itmno & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_IMBASINF, rtnStr)
            gspStr = ""

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading txtItmNo_Press sp_select_IMBASINF_Q :" & rtnStr)
                Exit Sub
            End If

            'Check If not in Item Master table
            If rs_IMBASINF.Tables("RESULT").Rows.Count = 0 Then 'not in IM?

                ''''''''''start''''''''''''''''''''not in IM'''''''''''''''''''''''''''''''''''''''
                Call insert_QUOTNDTL_ext(index_for_copy)

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'calcaulate Price Elements, has price elements  then Insert

                ta1 = rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_qutseq")
                ta1 = IIf(IsDBNull(ta1), 0, ta1)
                ta2 = cus1no
                ta3 = cus2no
                ta4 = rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("vbi_ventyp")
                ta4 = IIf(IsDBNull(ta4), "", ta4)

                ta5 = IIf(IsDBNull(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("ibi_catlvl3")), "", rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("ibi_catlvl3"))
                ta6 = IIf(IsDBNull(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_venno")), "", rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_venno"))

                ta7 = IIf(IsDBNull(rs_QUOTNDTL.Tables("RESULT").DefaultView(index)("qud_prctrm").ToString.Trim), "", rs_QUOTNDTL.Tables("RESULT").DefaultView(index)("qud_prctrm").ToString.Trim)
                ta8 = IIf(IsDBNull(rs_QUOTNDTL.Tables("RESULT").DefaultView(index)("qud_trantrm").ToString.Trim), "", rs_QUOTNDTL.Tables("RESULT").DefaultView(index)("qud_trantrm").ToString.Trim)

                If get_QUPRCEMT_CU(ta1, ta2, ta3, ta4, ta5, ta6, ta7, ta8) = True Then


                    'If get_QUPRCEMT_CU(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_qutseq"), Split(sRealCus1no, "-")(0).Trim, Split(sRealCus2no, "-")(0).Trim, rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_fml_cat"), rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_itmnovenno"), rs_valid.Tables("RESULT").DefaultView(index)("imu_prctrm").ToString.Trim, rs_valid.Tables("RESULT").DefaultView(index)("imu_trantrm").ToString.Trim) = True Then
                    Call calculate_gbPandelCstEmt(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_qutseq"))


                    '*** Conversion Factor
                    '' Cursor = Cursors.WaitCursor

                    ''gsCompany = Trim(strNewCocde)
                    ''Call Update_gs_Value(gsCompany)

                    ''gspStr = "sp_select_CUBASINF_Q '" & strNewCocde & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_untcde") & "','Conversion'"
                    ''rtnLong = execute_SQLStatement(gspStr, rs_SYCONFTR, rtnStr)
                    ''gspStr = ""

                    '' '' Cursor = Cursors.Default

                    ''If rtnLong <> RC_SUCCESS Then
                    ''    '                            MsgBox("Error on loading refresh_Price sp_select_CUBASINF_Q :" & rtnStr)
                    ''    '                           Exit Sub
                    ''End If

                    ''If rs_SYCONFTR.Tables("RESULT").Rows.Count = 0 Then
                    ''    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_smpunt") = rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_untcde")

                    ''    If rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cus1dp") = "0" Then
                    ''        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_smpprc") = "0"
                    ''    Else
                    ''        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_smpprc") = Format(Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cus1dp")), "###,###,##0.0000")
                    ''    End If
                    ''Else
                    ''    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_smpunt") = "PC"

                    ''    If rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cus1dp") = "0" Then
                    ''        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_smpprc") = "0"
                    ''    Else
                    ''        'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_smpprc")= Format(round2(txtCus1Dp.Text / rs_SYCONFTR.Tables("RESULT").Rows(0)("ycf_value")), "###,###,##0.0000")
                    ''        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_smpprc") = Format(round(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cus1dp") / rs_SYCONFTR.Tables("RESULT").Rows(0)("ycf_value"), "4.0000"), "###,###,##0.0000")
                    ''    End If
                    ''End If


                    ''''''''''''''''start Insert''''''''''''''''''''''''''''''


                    gspStr = "sp_insert_QUOTNDTL '" & _
                            strNewCocde & _
                            "','" & txtQutNo2.Text & _
                             "','" & li_index_seq & _
                             "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_itmno") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_itmsts") & "','" & Replace(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_itmdsc").ToString, "'", "''") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_alsitmno") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_alscolcde") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_conftr") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_contopc") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_pcprc") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_hstref") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_colcde") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cuscol") & "','" & Replace(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_coldsc").ToString, "'", "''") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_pckseq") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_untcde") & "','" & Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_inrqty").ToString) & "','" & _
                        Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_mtrqty").ToString) & "','" & Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cft").ToString) & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_curcde") & "','" & _
                        Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cus1sp").ToString) & "','" & Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cus2sp").ToString) & "','" & Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cus1dp").ToString) & "','" & _
                        Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cus2dp").ToString) & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_onetim") & "','" & Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_discnt").ToString) & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_moflag") & "','" & Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_orgmoq").ToString) & "','" & Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_orgmoa").ToString) & "','" & _
                        Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_moq").ToString) & "','" & Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_moa").ToString) & "','" & Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_smpqty").ToString) & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_hrmcde") & "','" & Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_dtyrat").ToString) & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_dept") & "','" & _
                        Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cususd").ToString) & "','" & Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cuscad").ToString) & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_venno") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_subcde") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_venitm") & "','" & Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_ftyprc").ToString) & "','" & _
                        Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_ftycst").ToString) & "','" & Replace(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_note").ToString, "'", "''") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_image") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_inrdin") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_inrwin") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_inrhin") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_mtrdin") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_mtrwin") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_mtrhin") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_inrdcm") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_inrwcm") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_inrhcm") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_mtrdcm") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_mtrwcm") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_mtrhcm") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_grswgt") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_netwgt") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cosmth") & "','" & _
                        Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_smpprc").ToString) & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cusitm") & "','" & _
                         rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cus1no") & _
                        "','" & Replace(txt_cus1na, "'", "''") & _
                        "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cus2no") & _
                        "','" & Replace(txt_cus2na, "'", "''") & "','" & _
                        IIf(IsDBNull(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_prcsec")) = True, "", rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_prcsec")) & "','" & Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_grsmgn").ToString) & "','" & _
                        IIf(IsDBNull(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_basprc")) = True, 0, rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_basprc")) & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_tbm") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_tbmsts") & "','" & _
                        Format(Date.Now, "MM/dd/yyyy") & _
                        "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_apprve") & "','" & Replace(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_pckitr").ToString, "'", "''") & "','" & _
                        Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_stkqty").ToString) & "','" & Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cusqty").ToString) & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_smpunt") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_qutitmsts") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_fcurcde") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_itmtyp") & "','" & _
                        "A" & _
                        "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_prctrm") & "','" & _
                       rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cusven") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cussub") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_ftyprctrm") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cusstyno") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cbm") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_upc") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_specpck") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_ftytmpitm") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_ftytmpitmno") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_custitmcat") & _
                        "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_custitmcatfml") & "','" & IIf(IsDBNull(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_custitmcatamt")), 0, rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_custitmcatamt")) & "','" & _
                        IIf(IsDBNull(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_pmu")), "", rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_pmu")) & "','" & _
                        Replace(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_imrmk").ToString, "'", "''") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_rndsts") & "','" & _
                        IIf(IsDBNull(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_calpmu")), 0, rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_calpmu")) & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_moqunttyp") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_qutdat") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cus1no") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cus2no") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_trantrm") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_effdat") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_expdat") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_itmnotyp") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_itmnoreal") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_itmnotmp") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_itmnoven") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_itmnovenno") & _
                        "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_imgpth") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cususdcur") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cuscadcur") & "','" & _
                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_DV") & "','" & _
                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_TV") & "','" & _
                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_ftyaud") & "','" & _
                        "" & "','" & _
                    "" & " ','" & _
                    "" & " ','" & _
                        "01/01/1900" & " ','" & _
                       "01/01/1900" & "','" & _
                       "01/01/1900" & "','" & _
                        "01/01/1900" & "','" & _
                        "" & "','" & _
                        gsUsrID & "'"





                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    gspStr = ""

                    '' Cursor = Cursors.Default

                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading save_Detail sp_insert_QUOTNDTL :" & rtnStr)
                        Exit Sub
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''
                    ''PRCEMT
                    gspStr = "sp_insert_QUPRCEMT '" & _
        strNewCocde & "','" & _
         txtQutNo2.Text & "','" & _
        li_index_seq & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_itmno") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_untcde") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_inrqty") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_mtrqty") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_cft") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_cbm") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_ftyprctrm") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_prctrm") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_trantrm") & "','" & _
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_fml_cus1no") & "','" & _
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_fml_cus2no") & "','" & _
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_fml_cat") & "','" & _
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_fml_venno") & "','" & _
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_fml_ventranflg") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_fcurcde") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_ftycst") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_ftyprc") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_curcde") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_basprc") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_mu") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_mumin") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_muprc") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_muminprc") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_cus1sp") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_cus1dp") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_cushcstbufper") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_cushcstbufamt") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_othdisper") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_maxapvper") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_maxapvamt") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_spmuper") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_dpmuper") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_cumu") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_pm") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_cush") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_thccusper") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_upsper") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_labper") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_faper") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_cstbufper") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_othper") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_pliper") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_dmdper") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_rbtper") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_subttlper") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_pkgper") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_comper") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_icmper") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_stdprc") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_ftycstA") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_ftycstB") & "','" & _
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_ftycstC") & "','" & _
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_ftycstD") & "','" & _
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_ftycstE") & "','" & _
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_ftycstTran") & "','" & _
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_ftycstPack") & "','" & _
        "" & "','" & _
        gsUsrID & "'"






                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    gspStr = ""


                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading save_Detail sp_insert_QUPRCEMT:" & rtnStr)
                        Exit Sub
                    End If


                End If

                '''''''''''''OK not in IM'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Else


                'If (rs_IMBASINF.Tables("RESULT").DefaultView(li_index_insert)("ivi_venno") >= "A" And _
                '                    rs_IMBASINF.Tables("RESULT").DefaultView(li_index_insert)("ivi_venno") <= "Z") _
                '                   Or _
                '                     (rs_IMBASINF.Tables("RESULT").DefaultView(li_index_insert)("ivi_venno") >= "a" And _
                '                    rs_IMBASINF.Tables("RESULT").DefaultView(li_index_insert)("ivi_venno") <= "z") Then

                '    Call insert_QUOTNDTL_int(li_index_insert)

                'Else
                '    Call insert_QUOTNDTL_ext(li_index_insert)

                'End If


                Call insert_QUOTNDTL_int(index_for_copy)



                'get Item Price
                gsCompany = Trim(strNewCocde)
                Call Update_gs_Value(gsCompany)

                gspStr = "sp_select_IMPRCINF_Q '" & strNewCocde & "','" & txt_itmno & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_IMPRCINF_NewAddItem, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading txtItmNo_Press sp_select_IMPRCINF_Q 2 :" & rtnStr)
                    '   Exit Sub
                End If



                gsCompany = Trim(strNewCocde)
                Call Update_gs_Value(gsCompany)

                gspStr = "sp_select_IMCOLINF '" & strNewCocde & "','" & txt_itmno & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_IMCOLINF, rtnStr)
                gspStr = ""

                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading txtItmNo_Press sp_select_IMCOLINF :" & rtnStr)
                    Exit Sub
                End If

                '                txt_icf_colcde = rs_IMCOLINF.Tables("RESULT").Rows(0)("icf_colcde").ToString

       



                gspStr = "sp_select_IMPCKINF_Q '" & strNewCocde & "','" & txt_itmno & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_IMPCKINF, rtnStr)
                gspStr = ""

                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading txtItmNo_Press sp_select_IMPCKINF_Q :" & rtnStr)
                    Exit Sub
                End If

                'lloop to filer
                For index2 As Integer = 0 To rs_IMPCKINF.Tables("RESULT").DefaultView.Count - 1
                    If rs_valid.Tables("RESULT").DefaultView(index)("qud_untcde").ToString.Trim = rs_IMPCKINF.Tables("RESULT").Rows(index2)("ipi_pckunt").ToString.Trim And _
                     rs_valid.Tables("RESULT").DefaultView(index)("qud_inrqty").ToString.Trim = rs_IMPCKINF.Tables("RESULT").Rows(index2)("ipi_inrqty").ToString.Trim And _
                      rs_valid.Tables("RESULT").DefaultView(index)("qud_mtrqty").ToString.Trim = rs_IMPCKINF.Tables("RESULT").Rows(index2)("ipi_mtrqty").ToString.Trim _
                      Then
                        txt_inner_in = rs_IMPCKINF.Tables("RESULT").Rows(index2)("inner_in").ToString.Trim
                        txt_master_in = rs_IMPCKINF.Tables("RESULT").Rows(index2)("master_in").ToString.Trim
                        txt_inner_cm = rs_IMPCKINF.Tables("RESULT").Rows(index2)("inner_cm").ToString.Trim
                        txt_master_cm = rs_IMPCKINF.Tables("RESULT").Rows(index2)("master_cm").ToString.Trim

                        txt_inrdin = rs_IMPCKINF.Tables("RESULT").Rows(index2)("ipi_inrdin").ToString.Trim
                        txt_inrwin = rs_IMPCKINF.Tables("RESULT").Rows(index2)("ipi_inrwin").ToString.Trim
                        txt_inrhin = rs_IMPCKINF.Tables("RESULT").Rows(index2)("ipi_inrhin").ToString.Trim
                        txt_mtrdin = rs_IMPCKINF.Tables("RESULT").Rows(index2)("ipi_mtrdin").ToString.Trim
                        txt_mtrwin = rs_IMPCKINF.Tables("RESULT").Rows(index2)("ipi_mtrwin").ToString.Trim
                        txt_mtrhin = rs_IMPCKINF.Tables("RESULT").Rows(index2)("ipi_mtrhin").ToString.Trim
                        txt_inrdcm = rs_IMPCKINF.Tables("RESULT").Rows(index2)("ipi_inrdcm").ToString.Trim
                        txt_inrwcm = rs_IMPCKINF.Tables("RESULT").Rows(index2)("ipi_inrwcm").ToString.Trim
                        txt_inrhcm = rs_IMPCKINF.Tables("RESULT").Rows(index2)("ipi_inrhcm").ToString.Trim
                        txt_mtrdcm = rs_IMPCKINF.Tables("RESULT").Rows(index2)("ipi_mtrdcm").ToString.Trim
                        txt_mtrwcm = rs_IMPCKINF.Tables("RESULT").Rows(index2)("ipi_mtrwcm").ToString.Trim
                        txt_mtrhcm = rs_IMPCKINF.Tables("RESULT").Rows(index2)("ipi_mtrhcm").ToString.Trim
                        txt_ipi_grswgt = rs_IMPCKINF.Tables("RESULT").Rows(index2)("ipi_grswgt").ToString.Trim
                        txt_ipi_netwgt = rs_IMPCKINF.Tables("RESULT").Rows(index2)("ipi_netwgt").ToString.Trim
                        txt_ipi_pckitr = rs_IMPCKINF.Tables("RESULT").Rows(index2)("ipi_pckitr").ToString.Trim
                        txt_ipi_pckseq = rs_IMPCKINF.Tables("RESULT").Rows(index2)("ipi_pckseq").ToString.Trim
                        txt_ipi_cft = Format(Val(rs_IMPCKINF.Tables("RESULT").Rows(index2)("ipi_cft").ToString), "##0.####")
                        txt_ipi_cbm = Format(Val(rs_IMPCKINF.Tables("RESULT").Rows(index2)("ipi_cbm").ToString), "##0.####")
                        txt_ipi_qutdat = rs_IMPCKINF.Tables("RESULT").Rows(index2)("ipi_qutdat").ToString
                    End If

                Next


                ''' Material BreakDown
                gspStr = "sp_select_IMMATBKD '" & strNewCocde & "','" & txt_itmno & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_IMMATBKD, rtnStr)
                gspStr = ""

                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading txtItmNo_Press sp_select_IMMATBKD :" & rtnStr)
                    Exit Sub
                End If


                '''ASS
                gspStr = "sp_select_IMBOMASS_Q '" & strNewCocde & "','" & txt_itmno & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_IMBOMASS, rtnStr)
                gspStr = ""

                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading txtItmNo_Press sp_select_IMBOMASS_Q :" & rtnStr)
                    Exit Sub
                End If



                'update fields 
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("Del") = ""
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("mode") = ""
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("upditmdtl") = "N"
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("updmoqmoa") = "N"
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("updassbom") = "N"
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("converttopc") = "N"
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cocde") = strNewCocde
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_qutno") = txtQutNo2.Text
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_qutseq") = li_index_insert + 1


                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'pricing
                'start get the price and status for the item
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim dblCstEmtPert As Double
                Dim dblCstEmtAmt As Double

                Dim IsNthVenInf As Boolean
                Dim IsNthCaMrk As Boolean
                Dim IsNthIM As Boolean
                Dim txtCurCde2_Text As String

                IsNthVenInf = False
                IsNthCaMrk = False
                IsNthIM = False

                dblCstEmtPert = 0
                dblCstEmtAmt = 0

                '' Cursor = Cursors.WaitCursor

                gsCompany = Trim(strNewCocde)
                Call Update_gs_Value(gsCompany)

                tmp_hkprctrm = "'"
                tmp_ftyprctrm = "'"
                tmp_trantrm = "'"
                tmp_colcde = "'"

                tmp_ftyprctrm = rs_valid.Tables("RESULT").DefaultView(index)("imu_ftyprctrm").ToString.Trim
                tmp_hkprctrm = rs_valid.Tables("RESULT").DefaultView(index)("imu_prctrm").ToString.Trim
                tmp_trantrm = rs_valid.Tables("RESULT").DefaultView(index)("imu_trantrm").ToString.Trim
                tmp_colcde = rs_valid.Tables("RESULT").DefaultView(index)("icf_colcde").ToString.Trim
                txt_icf_colcde = tmp_colcde

                tmp_ftyprctrm = Trim(Split(tmp_ftyprctrm, "-")(0))
                tmp_hkprctrm = Trim(Split(tmp_hkprctrm, "-")(0))
                tmp_trantrm = Trim(Split(tmp_trantrm, "-")(0))


                '*** Phase 3
                ''assume ftyprctrm = prctrm    

                '''20131219

                gspStr = "sp_select_CUBASINF_PC '" & strNewCocde & "','" & gsUsrID & "','" & sMODULE & "','Primary'"
                rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_P, rtnStr)
                gspStr = ""

                '''''' Cursor = Cursors.Default

                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading fillParameter sp_select_CUBASINF_PC :" & rtnStr)
                    Exit Sub
                End If

                If rs_CUBASINF_P.Tables("RESULT").Rows.Count > 0 Then
                    dr = rs_CUBASINF_P.Tables("RESULT").Select("cbi_cusno = " & "'" & cus1no & "'")
                End If

                txtCurCde2_Text = dr(0)("cpi_curcde").ToString

                gspStr = "sp_select_QUOTNDTL_Vendor '" & strNewCocde & "','" & txt_itmno & "','" & _
                                                        rs_valid.Tables("RESULT").DefaultView(index)("qud_untcde").ToString.Trim & "','" & _
                                                        rs_valid.Tables("RESULT").DefaultView(index)("qud_inrqty").ToString.Trim & "','" & _
                                                        rs_valid.Tables("RESULT").DefaultView(index)("qud_mtrqty").ToString.Trim & "','" & _
                                                        cus1no & "','" & cus2no & "','" & _
                                                         tmp_ftyprctrm & "','" & _
                                                        tmp_hkprctrm & "','" & _
                                                         tmp_trantrm & "','" & _
                                                        gsUsrID & "'"
                'gspStr = "sp_select_QUOTNDTL_Vendor '" & strNewCocde & "','" & _
                '                                                txtItmNo.Text & "','" & _
                '                                                rs_IMPCKINF.Tables("RESULT").Rows(sReadingIndexP)("ipi_pckunt").ToString & "','" & _
                '                                                rs_IMPCKINF.Tables("RESULT").Rows(sReadingIndexP)("ipi_inrqty").ToString & "','" & _
                '                                                rs_IMPCKINF.Tables("RESULT").Rows(sReadingIndexP)("ipi_mtrqty").ToString & "','" & _
                '                                                cus1no & "','" & cus2no & "','" & gsUsrID & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_IMVENINF, rtnStr)
                gspStr = ""

                '' Cursor = Cursors.Default

                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading CalculatePrc sp_select_QUOTNDTL_Vendor :" & rtnStr)
                    Exit Sub
                Else
                    IsNthVenInf = True
                End If
                ''End If

                If rs_IMVENINF.Tables("RESULT").Rows.Count > 0 Then


                    '''20131219 for same curcde
                    If rs_IMVENINF.Tables("RESULT").Rows(0)("imu_bcurcde").ToString <> txtCurCde2_Text Then
                        dr = rs_CUBASINF_CR.Tables("RESULT").Select("ysi_def = 'Y'")
                        If txtCurCde2_Text = dr(0)("ysi_cde") Then
                            dr = rs_CUBASINF_CR.Tables("RESULT").Select("ysi_cde = " & "'" & rs_IMVENINF.Tables("RESULT").Rows(0)("imu_bcurcde").ToString & "'")
                            'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_basprc") = Format(roundup(rs_IMVENINF.Tables("RESULT").Rows(0)("imu_basprc") * dr(0)("ysi_selrat")), "########0.0000")
                            rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_basprc") = Format(round(rs_IMVENINF.Tables("RESULT").Rows(0)("imu_basprc") * dr(0)("ysi_selrat"), cus1_rounding), "########0.0000")
                        Else
                            dr = rs_CUBASINF_CR.Tables("RESULT").Select("ysi_cde = " & "'" & txtCurCde2_Text & "'")
                            'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_basprc") = Format(roundup(rs_IMVENINF.Tables("RESULT").Rows(0)("imu_basprc") / dr(0)("ysi_selrat")), "########0.0000")
                            If dr.Length > 0 Then
                                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_basprc") = Format(round(rs_IMVENINF.Tables("RESULT").Rows(0)("imu_basprc") / dr(0)("ysi_selrat"), cus1_rounding), "########0.0000")
                            End If
                        End If
                    Else
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_basprc") = Format(rs_IMVENINF.Tables("RESULT").Rows(0)("imu_basprc"), "########0.0000")
                    End If
                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_curcde") = txtCurCde2_Text

                    '''20131219
                    'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_basprc") = Format(rs_IMVENINF.Tables("RESULT").Rows(0)("imu_basprc"), "########0.0000")
                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_venno") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_prdven")   'shortform , but: ivi_venno long form, 'qud_venno or imu_prdven

                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_trantrm") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_trantrm")
                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cus1no") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_cus1no")
                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cus2no") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_cus2no")
                    ''rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cus2no") = ""
                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_effdat") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_effdat")
                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_expdat") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_expdat")

                    'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_curcde") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_bcurcde")
                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_fcurcde") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_curcde")
                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_ftyprc") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_ftyprc")
                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_ftycst") = rs_IMVENINF.Tables("RESULT").Rows(0)("imu_ftycst")
                    '                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_basprc") = rs_IMVENINF.Tables("RESULT").Rows(0).Item("imu_basprc")

                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_fcurcde") = rs_IMVENINF.Tables("RESULT").Rows(0).Item("imu_curcde")
                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_ftycst") = rs_IMVENINF.Tables("RESULT").Rows(0).Item("imu_ftycst")

                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_ftycstA") = rs_IMVENINF.Tables("RESULT").Rows(0).Item("imu_ftycstA")
                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_ftycstB") = rs_IMVENINF.Tables("RESULT").Rows(0).Item("imu_ftycstB")
                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_ftycstC") = rs_IMVENINF.Tables("RESULT").Rows(0).Item("imu_ftycstC")
                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_ftycstD") = rs_IMVENINF.Tables("RESULT").Rows(0).Item("imu_ftycstD")
                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_ftycstE") = rs_IMVENINF.Tables("RESULT").Rows(0).Item("imu_ftycstE")
                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_ftycstTran") = rs_IMVENINF.Tables("RESULT").Rows(0).Item("imu_ftycstTran")
                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_ftycstPack") = rs_IMVENINF.Tables("RESULT").Rows(0).Item("imu_ftycstPack")


                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_ftyprc") = rs_IMVENINF.Tables("RESULT").Rows(0).Item("imu_ftyprc")
                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_curcde") = rs_IMVENINF.Tables("RESULT").Rows(0).Item("imu_curcde")
                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_basprc") = rs_IMVENINF.Tables("RESULT").Rows(0).Item("imu_basprc")


                End If

                'check
                If Not IsNumeric(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_ftycstA")) Then
                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_ftycstA") = "0"
                End If
                If Not IsNumeric(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_ftycstB")) Then
                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_ftycstB") = "0"
                End If
                If Not IsNumeric(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_ftycstC")) Then
                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_ftycstC") = "0"
                End If
                If Not IsNumeric(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_ftycstD")) Then
                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_ftycstD") = "0"
                End If
                If Not IsNumeric(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_ftycstE")) Then
                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_ftycstE") = "0"
                End If
                If Not IsNumeric(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_ftycstTran")) Then
                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_ftycstTran") = "0"
                End If
                If Not IsNumeric(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_ftycstPack")) Then
                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_ftycstPack") = "0"
                End If


                '''''''''''''''''''''''''''''''''''''''''''''''''''
                'end pring
                ''''''''''''''''''''''''''''''''''''''''''''''''''''
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_itmsts") = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_itmsts")

                If Not IsDBNull(rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_itmsts")) Then
                    If (Microsoft.VisualBasic.Left(rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_itmsts"), 3) = "CMP") Then
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_qutitmsts") = "A"
                    ElseIf (Microsoft.VisualBasic.Left(rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_itmsts"), 3) = "INC") Then
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_qutitmsts") = "I"
                    End If
                End If


                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_itmno") = txt_itmno
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_itmtyp") = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_typ")





                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_imrmk") = rs_IMBASINF.Tables("RESULT").Rows(0)("ibi_rmk")

                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_itmnoreal") = rs_valid.Tables("RESULT").Rows(i).Item("qud_itmno")  'same?
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_itmnotmp") = ""
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_itmnoven") = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ven.vbi_vensna")
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_itmnovenno") = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_venno")



                '----------------real & temp---------------
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_itmnoreal") = txt_itmno

                '  'case     --   temp ITEM ONLY
                If Not IsDBNull(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_itmnoreal")) Then
                    rs_IMTMPREL.Clear()

                    gspStr = "sp_select_IMTMPREL_Q2  '" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_itmnoreal") & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs_IMTMPREL, rtnStr)
                    gspStr = ""

                    '''' Cursor = Cursors.Default

                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading cmdItmNoSelect_Click sp_select_IMTMPREL :" & rtnStr)
                        Exit Sub
                    End If


                    If rs_IMTMPREL.Tables("RESULT").Rows.Count >= 1 Then
                        ''
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_itmnoreal") = ""
                        ''
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_itmnotmp") = txt_itmno
                        ''MsgBox("The item is a tempory item!")
                        ''Call txtItmNo_Press()
                        ''Exit Sub
                    End If
                End If


                'case     -- real#   with temp item #
                rs_IMTMPREL.Clear()

                gspStr = "sp_select_IMTMPREL_Q1  '" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_itmnoreal") & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_IMTMPREL, rtnStr)
                gspStr = ""

                '''' Cursor = Cursors.Default

                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading cmdItmNoSelect_Click sp_select_IMTMPREL :" & rtnStr)
                    Exit Sub
                End If

                If rs_IMTMPREL.Tables("RESULT").Rows.Count >= 1 Then
                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_itmnotmp") = rs_IMTMPREL.Tables("RESULT").Rows(0)("itr_tmpitm")
                Else
                    'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_itmnotmp") = ""
                End If
                '----------------real & temp---------------



                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_itmnotyp") = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_itmnotyp")
                If rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_itmnoreal").trim <> "" Then
                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_itmnotyp") = "R"
                ElseIf rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_itmnotmp").trim <> "" Then
                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_itmnotyp") = "T"
                Else
                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_itmnotyp") = "V"
                End If





                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_itmdsc") = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_engdsc")

                ''GetCusSty(rs_QUOTNDTL.Tables("RESULT").DefaultView(index)("qud_itmno"), Trim(Split(frmCopyQut.cboPriCus.Text, " - ")(0)), index)


                gspStr = "sp_select_IMBASINF_Q_A '" & strNewCocde & "','" & txt_itmno & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_IMBASINF_A, rtnStr)
                gspStr = ""

                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading not_exist_ITEM sp_select_IMBASINF_Q_A :" & rtnStr)
                    'Exit Sub
                End If

                'If rs_IMBASINF_A.Tables("RESULT").Rows.Count = 0 Then
                '    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_alsitmno") = ""
                'Else
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_alsitmno") = rs_IMBASINF.Tables("RESULT").Rows(0)("ibi_alsitmno")
                'End If

                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_colcde") = txt_icf_colcde


                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_upc") = ""               '?
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_coldsc") = ""

                'coldsc
                For index6 As Integer = 0 To rs_IMCOLINF.Tables("RESULT").Rows.Count - 1
                    If txt_icf_colcde = rs_IMCOLINF.Tables("RESULT").Rows(index6)("icf_colcde") Then
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_coldsc") = rs_IMCOLINF.Tables("RESULT").Rows(index6)("icf_coldsc")
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_upc") = rs_IMCOLINF.Tables("RESULT").Rows(index6)("icf_ucpcde")
                    End If
                Next



                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_alscolcde") = rs_IMBASINF.Tables("RESULT").Rows(0)("ibi_alscolcde")

                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_qutdat") = txt_ipi_qutdat 'rs_IMBASINF.Tables("RESULT").Rows(0)("ibi_qutdat")


                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cuscol") = ""
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_pckseq") = txt_ipi_pckseq
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_packterm") = ""
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_untcde") = rs_valid.Tables("RESULT").DefaultView(index)("qud_untcde").ToString.Trim
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_inrqty") = rs_valid.Tables("RESULT").DefaultView(index)("qud_inrqty").ToString.Trim
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_mtrqty") = rs_valid.Tables("RESULT").DefaultView(index)("qud_mtrqty").ToString.Trim
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_prctrm") = tmp_hkprctrm
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_ftyprctrm") = tmp_ftyprctrm
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_trantrm") = tmp_trantrm

                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_prctrm") = rs_IMPRCINF_NewAddItem.Tables("RESULT").Rows(0).Item("imu_hkprctrm")
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_ftyprctrm") = rs_IMPRCINF_NewAddItem.Tables("RESULT").Rows(0).Item("imu_ftyprctrm")
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_trantrm") = rs_IMPRCINF_NewAddItem.Tables("RESULT").Rows(0).Item("imu_trantrm")
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_conftr") = rs_IMPRCINF_NewAddItem.Tables("RESULT").Rows(0).Item("imu_conftr")
                ' rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_effdat") = rs_IMPRCINF_NewAddItem.Tables("RESULT").Rows(0).Item("imu_effdat")
                ' rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_expdat") = rs_IMPRCINF_NewAddItem.Tables("RESULT").Rows(0).Item("imu_expdat")

                'cus1   
                temp_cus1_for_name = Microsoft.VisualBasic.Left(sRealCus1no.Trim, 5)

                'Get Customer Name by No
                If rs_CUBASINF_P.Tables("RESULT").Rows.Count > 0 Then

                    dr = rs_CUBASINF_P.Tables("RESULT").Select("cbi_cusno >= '50000'")

                    If Not dr Is Nothing Then
                        If dr.Length > 0 Then
                            For index2 As Integer = 0 To dr.Length - 1
                                If temp_cus1_for_name = dr(index2)("cbi_cusno") Then
                                    txt_cus1na = dr(index2)("cbi_cussna")
                                End If
                            Next index2
                        End If
                    End If
                Else
                    txt_cus1na = ""
                End If

                'cus2  
                temp_cus2_for_name = Microsoft.VisualBasic.Left(sRealCus2no.Trim, 5)


                gspStr = "sp_select_CUBASINF_Q '" & strNewCocde & "','" & temp_cus1_for_name & "','Secondary'"
                rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_CP, rtnStr)
                gspStr = ""

                'Get 2nd Customer Name by No
                If rs_CUBASINF_P.Tables("RESULT").Rows.Count > 0 Then

                    dr = rs_CUBASINF_CP.Tables("RESULT").Select("csc_seccus >= '50000'")

                    If Not dr Is Nothing Then
                        If dr.Length > 0 Then
                            For index2 As Integer = 0 To dr.Length - 1


                                If Not IsDBNull(temp_cus2_for_name) Then
                                    If Not IsDBNull(dr(index2)("csc_seccus")) Then
                                        If temp_cus2_for_name = dr(index2)("csc_seccus") Then
                                            txt_cus2na = dr(index2)("cbi_cussna")
                                        End If
                                    End If
                                End If

                            Next index2
                        End If
                    End If
                Else
                    txt_cus2na = ""
                End If

                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cft") = txt_ipi_cft
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cbm") = txt_ipi_cbm
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("inner_in") = txt_inner_in
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("master_in") = txt_master_in
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("inner_cm") = txt_inner_cm
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("master_cm") = txt_master_cm
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_inrdin") = txt_inrdin
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_inrwin") = txt_inrwin
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_inrhin") = txt_inrhin
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_mtrdin") = txt_mtrdin
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_mtrwin") = txt_mtrwin
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_mtrhin") = txt_mtrhin
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_inrdcm") = txt_inrdcm
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_inrwcm") = txt_inrwcm
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_inrhcm") = txt_inrhcm
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_mtrdcm") = txt_mtrdcm
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_mtrwcm") = txt_mtrwcm
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_mtrhcm") = txt_mtrhcm
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_qutdat") = DateTime.Now.Month.ToString("00") & "/" & DateTime.Now.Day.ToString("00") & "/" & DateTime.Now.Year.ToString
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_grswgt") = txt_ipi_grswgt
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_netwgt") = txt_ipi_netwgt
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_pckitr") = txt_ipi_pckitr
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_dept") = ""
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_hstref") = ""
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_moq") = 0
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_moqunttyp") = ""
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_moa") = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_moa")

                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_prcsec") = ""
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_grsmgn") = 0

                If sRealCus2no.Trim <> "" Then
                    dr = rs_CUBASINF_S.Tables("RESULT").Select("csc_seccus = " & "'" & Microsoft.VisualBasic.Left(sRealCus2no.Trim, 5) & "'")

                    If dr(0)("cpi_prcsec").ToString = "GM" Then
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_prcsec") = "GM"
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_grsmgn") = dr(0)("cpi_grsmgn")
                    Else
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_prcsec") = "MU"
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_grsmgn") = dr(0)("cpi_grsmgn")
                    End If
                End If

                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_curcde") = rs_IMPRCINF_NewAddItem.Tables("RESULT").Rows(0).Item("imu_curcde")

                'If rs_QUOTNDTL.Tables("RESULT").Rows.Count = 1 Then
                '    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_curcde") = rs_CUBASINF_P.Tables("RESULT").Rows(0).Item("cpi_curcde")
                'Else
                '    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_curcde") = rs_QUOTNDTL.Tables("RESULT").Rows(0).Item("qud_curcde")
                'End If


                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cus1sp") = 0
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cus2sp") = 0
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cus1dp") = 0
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cus2dp") = 0
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_discnt") = 0
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_contopc") = ""
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_pcprc") = 0
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_fcurcde") = rs_IMPRCINF_NewAddItem.Tables("RESULT").Rows(0).Item("imu_curcde")
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_ftyprc") = rs_IMPRCINF_NewAddItem.Tables("RESULT").Rows(0).Item("imu_ftyprc")
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_ftycst") = rs_IMPRCINF_NewAddItem.Tables("RESULT").Rows(0).Item("imu_ftycst")
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_basprc") = rs_IMPRCINF_NewAddItem.Tables("RESULT").Rows(0).Item("imu_basprc")
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_cocde") = strNewCocde
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_qutno") = txtQutNo2.Text

                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_qutseq") = li_index_insert + 1
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_itmno") = txt_itmno
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_untcde") = rs_valid.Tables("RESULT").DefaultView(index)("qud_untcde").ToString.Trim
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_inrqty") = rs_valid.Tables("RESULT").DefaultView(index)("qud_inrqty").ToString.Trim

                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_mtrqty") = rs_valid.Tables("RESULT").DefaultView(index)("qud_mtrqty").ToString.Trim
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_cft") = rs_IMPRCINF_NewAddItem.Tables("RESULT").Rows(0).Item("imu_cft")
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_cbm") = 0
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_ftyprctrm") = rs_IMPRCINF_NewAddItem.Tables("RESULT").Rows(0).Item("imu_ftyprctrm")
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_prctrm") = rs_IMPRCINF_NewAddItem.Tables("RESULT").Rows(0).Item("imu_hkprctrm")
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_trantrm") = rs_IMPRCINF_NewAddItem.Tables("RESULT").Rows(0).Item("imu_trantrm")
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_fml_cus1no") = Microsoft.VisualBasic.Left(sRealCus1no.Trim, 5)
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_fml_cus2no") = Microsoft.VisualBasic.Left(sRealCus2no.Trim, 5)

                ''?? rs_IMVENINF.Tables("RESULT").Rows(0)("ibi_catlvl3").ToString
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_fml_cat") = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_catlvl3")

                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_fml_cat") = xlsApp.Range("A" + (tmp_id + 1).ToString).Value

                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_ventyp") = rs_IMBASINF.Tables("RESULT").Rows(0).Item("vbi_ventyp")
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_fml_ventranflg") = xlsApp.Range("AP" + (tmp_id + 1).ToString).Value
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_fml_cus1no") = xlsApp.Range("D" + (tmp_id + 1).ToString).Value
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_fml_cus2no") = xlsApp.Range("E" + (tmp_id + 1).ToString).Value
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_fml_cat") = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_catlvl3")
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_ventyp") = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_venno")
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_ventyp") = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_venno")
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_fml_ventranflg") = ""
                '                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_prctrm") = xlsApp.Range("AM" + (tmp_id + 1).ToString).Value
                '                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_trantrm") = xlsApp.Range("AN" + (tmp_id + 1).ToString).Value
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_fcurcde") = rs_IMPRCINF_NewAddItem.Tables("RESULT").Rows(0).Item("imu_curcde")
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_ftycst") = rs_IMPRCINF_NewAddItem.Tables("RESULT").Rows(0).Item("imu_ftycst")

                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_ftycstA") = rs_IMPRCINF_NewAddItem.Tables("RESULT").Rows(0).Item("imu_ftycstA")
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_ftycstB") = rs_IMPRCINF_NewAddItem.Tables("RESULT").Rows(0).Item("imu_ftycstB")
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_ftycstC") = rs_IMPRCINF_NewAddItem.Tables("RESULT").Rows(0).Item("imu_ftycstC")
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_ftycstD") = rs_IMPRCINF_NewAddItem.Tables("RESULT").Rows(0).Item("imu_ftycstD")
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_ftycstTran") = rs_IMPRCINF_NewAddItem.Tables("RESULT").Rows(0).Item("imu_ftycstTran")
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_ftycstPack") = rs_IMPRCINF_NewAddItem.Tables("RESULT").Rows(0).Item("imu_ftycstPack")

                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_ftyprc") = rs_IMPRCINF_NewAddItem.Tables("RESULT").Rows(0).Item("imu_ftyprc")
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_curcde") = rs_IMPRCINF_NewAddItem.Tables("RESULT").Rows(0).Item("imu_curcde")
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_basprc") = rs_IMPRCINF_NewAddItem.Tables("RESULT").Rows(0).Item("imu_basprc")
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_mu") = xlsApp.Range("BA" + (tmp_id + 1).ToString).Value
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_mumin") = xlsApp.Range("AZ" + (tmp_id + 1).ToString).Value
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_muprc") = 0
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_cus1sp") = 0
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_cus1dp") = 0
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_cushcstbufper") = xlsApp.Range("AW" + (tmp_id + 1).ToString).Value
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_cushcstbufamt") = 0
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_othdisper") = xlsApp.Range("AX" + (tmp_id + 1).ToString).Value
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_maxapvper") = 0
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_maxapvamt") = 0
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_spmuper") = 0
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_dpmuper") = 0
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_cumu") = 0
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_pm") = 0
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_cush") = 0

                ''get values from CUCALFML by cus & terms
                'gspStr = "sp_select_QUPRCEMT_CU '','" & _
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_fml_cus1no") & _
                '"','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_fml_cus2no") & _
                '"','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_ventyp") & _
                '"','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_fml_cat") & _
                '"','" & rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_venno") & _
                '"','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_prctrm") & _
                '"','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_TranTrm") & "'"

                'rtnLong = execute_SQLStatement(gspStr, rs_QUOTNDTL_CU, rtnStr)
                'gspStr = ""

                ' '' Cursor = Cursors.Default

                'If rtnLong <> RC_SUCCESS Then
                '    MsgBox("Error on loading LoadPrcEmtFromCU sp_select_QUPRCEMT_CU :" & rtnStr)
                '    Exit Sub
                'End If

                'If rs_QUOTNDTL_CU.Tables("RESULT").Rows.Count > 0 Then
                '    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_thccusper") = rs_QUOTNDTL_CU.Tables("RESULT").Rows(0).Item("ccf_thccusper")
                '    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_upsper") = rs_QUOTNDTL_CU.Tables("RESULT").Rows(0).Item("ccf_upsper")
                '    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_labper") = rs_QUOTNDTL_CU.Tables("RESULT").Rows(0).Item("ccf_labper")
                '    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_faper") = rs_QUOTNDTL_CU.Tables("RESULT").Rows(0).Item("ccf_faper")
                '    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_cstbufper") = rs_QUOTNDTL_CU.Tables("RESULT").Rows(0).Item("ccf_cstbufper")
                '    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_othper") = rs_QUOTNDTL_CU.Tables("RESULT").Rows(0).Item("ccf_othper")
                '    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_pliper") = rs_QUOTNDTL_CU.Tables("RESULT").Rows(0).Item("ccf_pliper")
                '    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_dmdper") = rs_QUOTNDTL_CU.Tables("RESULT").Rows(0).Item("ccf_dmdper")
                '    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_rbtper") = rs_QUOTNDTL_CU.Tables("RESULT").Rows(0).Item("ccf_rbtper")
                'End If

                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_subttlper") = IIf(IsNumeric(xlsApp.Range("AQ" + (tmp_id + 1).ToString).Value), xlsApp.Range("AQ" + (tmp_id + 1).ToString).Value, 0)
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_pkgper") = 0
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_comper") = 0
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_icmper") = 0
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_stdprc") = 0
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_creusr") = ""
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_updusr") = ""
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_credat") = DateTime.Now.Month.ToString("00") & "/" & DateTime.Now.Day.ToString("00") & "/" & DateTime.Now.Year.ToString
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_upddat") = DateTime.Now.Month.ToString("00") & "/" & DateTime.Now.Day.ToString("00") & "/" & DateTime.Now.Year.ToString
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_timstp") = 0
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_stkqty") = 0
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cusqty") = 0
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_smpqty") = 0
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_smpunt") = "PC"
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_smpprc") = 0
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_rndsts") = ""
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_buyer") = ""
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_toqty") = 0
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_tormk") = ""
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_ftyshpstr") = "01/01/1900"
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_ftyshpend") = "01/01/1900"
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cushpstr") = "01/01/1900"
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cushpend") = "01/01/1900"
                ''rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_venno") = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_venno")
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("vensts") = ""
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_venitm") = ""
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cusven") = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_cusven")
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_DV") = ""
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_TV") = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_tradeven")
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_ftyaud") = ""
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cususdcur") = "USD"
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cususd") = 0
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cuscadcur") = "CAD"
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cuscad") = 0
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_note") = ""

                '                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_imgpth") = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_imgpth")
                If IIf(IsDBNull(rs_IMBASINF.Tables("RESULT").Rows(0)("ibi_imgpth")), "", Trim(rs_IMBASINF.Tables("RESULT").Rows(0)("ibi_imgpth").ToString)) <> "" Then
                    pth = Trim(rs_IMBASINF.Tables("RESULT").Rows(0)("ibi_imgpth").ToString)
                Else
                    If gsCompanyGroup = "MSG" Then
                        If rs_IMBASINF.Tables("RESULT").Rows(0)("vbi_ventyp").ToString = "I" Or _
                            rs_IMBASINF.Tables("RESULT").Rows(0)("vbi_ventyp").ToString = "J" Then
                            pth = ItmImg_pth & SearchImgPath(rs_IMBASINF.Tables("RESULT").Rows(0)("ibi_lnecde")) & "\" & _
                                    revisedItmno(rs_IMBASINF.Tables("RESULT").Rows(0)("ivi_venitm"))
                        Else
                            pth = ItmImg_pth & rs_IMBASINF.Tables("RESULT").Rows(0)("venno") & "\" & _
                                    revisedItmno(rs_IMBASINF.Tables("RESULT").Rows(0)("ivi_venitm")) & "_" & _
                                    rs_IMBASINF.Tables("RESULT").Rows(0)("venno")
                        End If
                    Else
                        If rs_IMBASINF.Tables("RESULT").Rows(0)("vbi_ventyp").ToString = "I" Or _
                            rs_IMBASINF.Tables("RESULT").Rows(0)("vbi_ventyp").ToString = "J" Then
                            If ItmImg_pth_6 <> "" Then
                                pth = ItmImg_pth_6 & SearchImgPath(rs_IMBASINF.Tables("RESULT").Rows(0)("ibi_lnecde")) & "\" & _
                                        revisedItmno(rs_IMBASINF.Tables("RESULT").Rows(0)("ivi_venitm"))
                            Else
                                pth = ItmImg_pth & SearchImgPath(rs_IMBASINF.Tables("RESULT").Rows(0)("ibi_lnecde")) & "\" & _
                                        revisedItmno(rs_IMBASINF.Tables("RESULT").Rows(0)("ivi_venitm"))
                            End If
                        ElseIf rs_IMBASINF.Tables("RESULT").Rows(0)("venno").ToString = "0005" Then
                            pth = ItmImg_pth & rs_IMBASINF.Tables("RESULT").Rows(0)("venno") & "\" & _
                                    revisedItmno(rs_IMBASINF.Tables("RESULT").Rows(0)("ivi_venitm")) & "_" & rs_IMBASINF.Tables("RESULT").Rows(0)("venno")
                        Else
                            If rs_IMBASINF.Tables("RESULT").Rows(0)("vbi_ventyp").ToString = "E" Then
                                pth = Mid(ItmImg_pth, 1, 25) & "ucp\itemimg\" & rs_IMBASINF.Tables("RESULT").Rows(0)("venno") & "\" & _
                                        revisedItmno(rs_IMBASINF.Tables("RESULT").Rows(0)("ivi_venitm")) & "_" & _
                                        rs_IMBASINF.Tables("RESULT").Rows(0)("venno")
                            Else
                                pth = ItmImg_pth & rs_IMBASINF.Tables("RESULT").Rows(0)("venno") & "\" & _
                                        revisedItmno(rs_IMBASINF.Tables("RESULT").Rows(0)("ivi_venitm")) & "_" & _
                                        rs_IMBASINF.Tables("RESULT").Rows(0)("venno")
                            End If
                        End If
                    End If
                End If

                If UCase(Microsoft.VisualBasic.Right(pth, 3)) <> "JPG" Then
                    pth = pth & ".JPG"
                End If

                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_imgpth") = IIf(IsDBNull(pth), "", pth)


                If rs_IMBASINF.Tables("RESULT").Rows(0)("ibi_imgpth").ToString <> "" Then
                    'If rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_imgpth") <> "" Then
                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_image") = "Y"
                Else
                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_image") = "N"
                End If


                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_hrmcde") = ""
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_dtyrat") = 0
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cosmth") = ""
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("ysi_dsc") = ""
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_apprve") = ""

                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("ibi_catlvl3") = rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_catlvl3")
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("vbi_ventyp") = rs_IMBASINF.Tables("RESULT").Rows(0).Item("vbi_ventyp")
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("CIHCURR") = ""
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("CIHAMT") = 0
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_onetim") = "N"
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_pdabpdiff") = ""


                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_ftytmpitm") = ""

                If rs_IMBASINF.Tables("RESULT").Rows(0)("ibi_ftytmp").ToString = "Y" Then
                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_ftytmpitm") = "Y"
                Else
                    '    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_ftytmpitm") = "N"
                End If

                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_ftytmpitmno") = ""
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qce_amt") = 0
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_subcde") = ""
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_tbm") = ""
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_tbmsts") = ""
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_moflag") = ""
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_orgmoq") = 0
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_orgmoa") = 0
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cussub") = ""
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_specpck") = ""
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_custitmcat") = ""
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_custitmcatfml") = ""
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_custitmcatamt") = 0
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_pmu") = 0
                '' 
                'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_imrmk") = ""
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_calpmu") = 0
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_creusr") = ""
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_updusr") = ""
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_credat") = DateTime.Now.Month.ToString("00") & "/" & DateTime.Now.Day.ToString("00") & "/" & DateTime.Now.Year.ToString
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_upddat") = DateTime.Now.Month.ToString("00") & "/" & DateTime.Now.Day.ToString("00") & "/" & DateTime.Now.Year.ToString
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_timstp") = 0

                If rs_IMBASINF.Tables("RESULT").Rows.Count > 0 Then
                    ''rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_venno") = rs_IMBASINF.Tables("RESULT").Rows(0)("ibi_venno")   'shortform , but: ivi_venno long form, 'qud_venno or imu_prdven
                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_subcde") = rs_IMBASINF.Tables("RESULT").Rows(0)("ivi_subcde")
                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_venitm") = rs_IMBASINF.Tables("RESULT").Rows(0)("ivi_venitm")

                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cusven") = Split(rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_cusven"), "-")(0)
                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_dv") = Split(rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_venno"), "-")(0)
                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_tv") = Split(rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_tradeven"), "-")(0)
                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_ftyaud") = Split(rs_IMBASINF.Tables("RESULT").Rows(0).Item("ibi_examven"), "-")(0)
                End If

                Call retrieveMOQMOA(li_index_insert)


                txtCusItm_Text = ""

                ''temp comment '' 20130902
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cusstyno") = GetCusSty2(rs_QUOTNDTL.Tables("RESULT").DefaultView(li_index_insert)("qud_itmno"), Trim(Split(frmCopyQut.cboPriCus.Text, " - ")(0)), li_index_insert)
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cusitm") = txtCusItm_Text
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_prctrm") = tmp_hkprctrm
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_ftyprctrm") = tmp_ftyprctrm
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_trantrm") = tmp_trantrm



                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'calcaulate Price Elements, has price elements  then Insert

                ta1 = rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_qutseq")
                ta1 = IIf(IsDBNull(ta1), 0, ta1)
                ta2 = cus1no
                ta3 = cus2no
                ta4 = rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("vbi_ventyp")
                ta4 = IIf(IsDBNull(ta4), "", ta4)


                ta5 = IIf(IsDBNull(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("ibi_catlvl3")), "", rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("ibi_catlvl3"))

                ta6 = IIf(IsDBNull(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_venno")), "", rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_venno"))

                ta7 = IIf(IsDBNull(rs_QUOTNDTL.Tables("RESULT").DefaultView(index)("qud_prctrm").ToString.Trim), "", rs_QUOTNDTL.Tables("RESULT").DefaultView(index)("qud_prctrm").ToString.Trim)
                ta8 = IIf(IsDBNull(rs_QUOTNDTL.Tables("RESULT").DefaultView(index)("qud_trantrm").ToString.Trim), "", rs_QUOTNDTL.Tables("RESULT").DefaultView(index)("qud_trantrm").ToString.Trim)

                If get_QUPRCEMT_CU(ta1, ta2, ta3, ta4, ta5, ta6, ta7, ta8) = True Then


                    'If get_QUPRCEMT_CU(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_qutseq"), Split(sRealCus1no, "-")(0).Trim, Split(sRealCus2no, "-")(0).Trim, rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qpe_fml_cat"), rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_itmnovenno"), rs_valid.Tables("RESULT").DefaultView(index)("imu_prctrm").ToString.Trim, rs_valid.Tables("RESULT").DefaultView(index)("imu_trantrm").ToString.Trim) = True Then
                    Call calculate_gbPandelCstEmt(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_qutseq"))


                    '*** Conversion Factor
                    '' Cursor = Cursors.WaitCursor

                    ''gsCompany = Trim(strNewCocde)
                    ''Call Update_gs_Value(gsCompany)

                    ''gspStr = "sp_select_CUBASINF_Q '" & strNewCocde & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_untcde") & "','Conversion'"
                    ''rtnLong = execute_SQLStatement(gspStr, rs_SYCONFTR, rtnStr)
                    ''gspStr = ""

                    '' '' Cursor = Cursors.Default

                    ''If rtnLong <> RC_SUCCESS Then
                    ''    '                            MsgBox("Error on loading refresh_Price sp_select_CUBASINF_Q :" & rtnStr)
                    ''    '                           Exit Sub
                    ''End If

                    ''If rs_SYCONFTR.Tables("RESULT").Rows.Count = 0 Then
                    ''    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_smpunt") = rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_untcde")

                    ''    If rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cus1dp") = "0" Then
                    ''        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_smpprc") = "0"
                    ''    Else
                    ''        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_smpprc") = Format(Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cus1dp")), "###,###,##0.0000")
                    ''    End If
                    ''Else
                    ''    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_smpunt") = "PC"

                    ''    If rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cus1dp") = "0" Then
                    ''        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_smpprc") = "0"
                    ''    Else
                    ''        'rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_smpprc")= Format(round2(txtCus1Dp.Text / rs_SYCONFTR.Tables("RESULT").Rows(0)("ycf_value")), "###,###,##0.0000")
                    ''        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_smpprc") = Format(round(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cus1dp") / rs_SYCONFTR.Tables("RESULT").Rows(0)("ycf_value"), "4.0000"), "###,###,##0.0000")
                    ''    End If
                    ''End If

                    ''''''''''''''''start Insert''''''''''''''''''''''''''''''


                    gspStr = "sp_insert_QUOTNDTL '" & _
                            strNewCocde & _
                            "','" & txtQutNo2.Text & _
                             "','" & li_index_seq & _
                             "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_itmno") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_itmsts") & "','" & Replace(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_itmdsc").ToString, "'", "''") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_alsitmno") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_alscolcde") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_conftr") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_contopc") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_pcprc") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_hstref") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_colcde") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cuscol") & "','" & Replace(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_coldsc").ToString, "'", "''") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_pckseq") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_untcde") & "','" & Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_inrqty").ToString) & "','" & _
                        Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_mtrqty").ToString) & "','" & Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cft").ToString) & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_curcde") & "','" & _
                        Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cus1sp").ToString) & "','" & Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cus2sp").ToString) & "','" & Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cus1dp").ToString) & "','" & _
                        Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cus2dp").ToString) & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_onetim") & "','" & Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_discnt").ToString) & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_moflag") & "','" & Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_orgmoq").ToString) & "','" & Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_orgmoa").ToString) & "','" & _
                        Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_moq").ToString) & "','" & Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_moa").ToString) & "','" & Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_smpqty").ToString) & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_hrmcde") & "','" & Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_dtyrat").ToString) & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_dept") & "','" & _
                        Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cususd").ToString) & "','" & Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cuscad").ToString) & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_venno") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_subcde") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_venitm") & "','" & Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_ftyprc").ToString) & "','" & _
                        Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_ftycst").ToString) & "','" & Replace(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_note").ToString, "'", "''") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_image") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_inrdin") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_inrwin") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_inrhin") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_mtrdin") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_mtrwin") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_mtrhin") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_inrdcm") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_inrwcm") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_inrhcm") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_mtrdcm") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_mtrwcm") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_mtrhcm") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_grswgt") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_netwgt") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cosmth") & "','" & _
                        Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_smpprc").ToString) & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cusitm") & "','" & _
                         rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cus1no") & _
                        "','" & Replace(txt_cus1na, "'", "''") & _
                        "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_cus1no") & _
                        "','" & Replace(txt_cus2na, "'", "''") & "','" & _
                        IIf(IsDBNull(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_prcsec")) = True, "", rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_prcsec")) & "','" & Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_grsmgn").ToString) & "','" & _
                        IIf(IsDBNull(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_basprc")) = True, 0, rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_basprc")) & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_tbm") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_tbmsts") & "','" & _
                        Format(Date.Now, "MM/dd/yyyy") & _
                        "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_apprve") & "','" & Replace(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_pckitr").ToString, "'", "''") & "','" & _
                        Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_stkqty").ToString) & "','" & Val(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cusqty").ToString) & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_smpunt") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_qutitmsts") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_fcurcde") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_itmtyp") & "','" & _
                        "A" & _
                        "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_prctrm") & "','" & _
                       rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cusven") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cussub") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_ftyprctrm") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cusstyno") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cbm") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_upc") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_specpck") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_ftytmpitm") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_ftytmpitmno") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_custitmcat") & _
                        "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_custitmcatfml") & "','" & IIf(IsDBNull(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_custitmcatamt")), 0, rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_custitmcatamt")) & "','" & _
                        IIf(IsDBNull(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_pmu")), "", rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_pmu")) & "','" & _
                        Replace(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_imrmk").ToString, "'", "''") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_rndsts") & "','" & _
                        IIf(IsDBNull(rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_calpmu")), 0, rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_calpmu")) & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_moqunttyp") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_qutdat") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cus1no") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cus2no") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_trantrm") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_effdat") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_expdat") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_itmnotyp") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_itmnoreal") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_itmnotmp") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_itmnoven") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_itmnovenno") & _
                        "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_imgpth") & "','" & rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cususdcur") & "','" & _
                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cuscadcur") & "','" & _
                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_DV") & "','" & _
                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_TV") & "','" & _
                    rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert).Item("qud_ftyaud") & "','" & _
                        "" & "','" & _
                    "" & " ','" & _
                    "" & " ','" & _
                        "01/01/1900" & " ','" & _
                       "01/01/1900" & "','" & _
                       "01/01/1900" & "','" & _
                        "01/01/1900" & "','" & _
                        "" & "','" & _
                        gsUsrID & "'"





                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    gspStr = ""

                    '' Cursor = Cursors.Default

                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading save_Detail sp_insert_QUOTNDTL :" & rtnStr)
                        Exit Sub
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''
                    ''PRCEMT
                    gspStr = "sp_insert_QUPRCEMT '" & _
        strNewCocde & "','" & _
         txtQutNo2.Text & "','" & _
        li_index_seq & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_itmno") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_untcde") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_inrqty") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_mtrqty") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_cft") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_cbm") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_ftyprctrm") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_prctrm") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_trantrm") & "','" & _
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_fml_cus1no") & "','" & _
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_fml_cus2no") & "','" & _
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_fml_cat") & "','" & _
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_fml_venno") & "','" & _
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_fml_ventranflg") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_fcurcde") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_ftycst") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_ftyprc") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_curcde") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_basprc") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_mu") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_mumin") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_muprc") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_muminprc") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_cus1sp") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_cus1dp") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_cushcstbufper") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_cushcstbufamt") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_othdisper") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_maxapvper") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_maxapvamt") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_spmuper") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_dpmuper") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_cumu") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_pm") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_cush") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_thccusper") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_upsper") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_labper") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_faper") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_cstbufper") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_othper") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_pliper") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_dmdper") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_rbtper") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_subttlper") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_pkgper") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_comper") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_icmper") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_stdprc") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_ftycstA") & "','" & _
        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_ftycstB") & "','" & _
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_ftycstC") & "','" & _
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_ftycstD") & "','" & _
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_ftycstE") & "','" & _
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_ftycstTran") & "','" & _
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qpe_ftycstPack") & "','" & _
        "" & "','" & _
        gsUsrID & "'"






                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    gspStr = ""


                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading save_Detail sp_insert_QUPRCEMT:" & rtnStr)
                        Exit Sub
                    End If


                    '''''''''''''''''''''''''''''ass & b''''
                    ''get the max seq_number for insert
                    max_seq_insert = li_index_seq


                    'INI Assortment
                    gsCompany = Trim(strNewCocde)
                    Call Update_gs_Value(gsCompany)

                    gspStr = "sp_select_QUASSINF '" & strNewCocde & "','" & txtQutNo2.Text.ToString.Trim & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs_QUASSINF, rtnStr)
                    gspStr = ""

                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading setStatus sp_select_QUASSINF :" & rtnStr)
                        Exit Sub
                    End If

                    For i2 As Integer = 0 To rs_QUASSINF.Tables("RESULT").Columns.Count - 1
                        rs_QUASSINF.Tables("RESULT").Columns(i2).ReadOnly = False
                    Next i2



                    '*** Assortment Item
                    If rs_IMBOMASS.Tables("RESULT").Rows.Count = 0 Then
                        'cmdAss.Enabled = False

                        If li_index_insert <> 0 Then
                            sFilter = "qai_qutseq = " & li_index_seq & " and mode <> 'DEL'"
                            rs_QUASSINF.Tables("RESULT").DefaultView.RowFilter = sFilter
                        End If

                        If rs_QUASSINF.Tables("RESULT").DefaultView.Count > 0 Then
                            Dim index3 As Integer = rs_QUASSINF.Tables("RESULT").DefaultView.Count

                            While index3 > 0
                                If rs_QUASSINF.Tables("RESULT").DefaultView(0)("qai_qutno").ToString = txtQutNo2.Text And _
                                    rs_QUASSINF.Tables("RESULT").DefaultView(0)("qai_qutseq").ToString = li_index_seq Then
                                    rs_QUASSINF.Tables("RESULT").DefaultView(0).Delete()
                                    'index3 -= 1  
                                End If
                                index3 -= 1
                            End While
                            rs_QUASSINF.Tables("RESULT").AcceptChanges()
                        End If
                    Else
                        'cmdAss.Enabled = True

                        If rs_QUASSINF.Tables("RESULT").DefaultView.Count > 0 Then
                            Dim index4 As Integer = rs_QUASSINF.Tables("RESULT").DefaultView.Count

                            While index4 > 0
                                If rs_QUASSINF.Tables("RESULT").DefaultView(0)("qai_qutno").ToString = txtQutNo2.Text And _
                                    rs_QUASSINF.Tables("RESULT").DefaultView(0)("qai_qutseq").ToString = li_index_seq Then
                                    rs_QUASSINF.Tables("RESULT").DefaultView(0).Delete()
                                    'index4 -= 1
                                End If
                                index4 -= 1
                            End While
                            rs_QUASSINF.Tables("RESULT").AcceptChanges()
                        End If

                        For index4 As Integer = 0 To rs_IMBOMASS.Tables("RESULT").Rows.Count - 1
                            drNewRow = rs_QUASSINF.Tables("RESULT").NewRow
                            drNewRow("mode") = "NEW"
                            drNewRow("qai_qutno") = txtQutNo2.Text
                            drNewRow("qai_qutseq") = li_index_seq
                            drNewRow("qai_itmno") = txt_itmno
                            drNewRow("qai_assitm") = rs_IMBOMASS.Tables("RESULT").Rows(index4)("iba_assitm")
                            drNewRow("qai_assdsc") = Replace(rs_IMBOMASS.Tables("RESULT").Rows(index4)("ibi_engdsc"), "'", "''")
                            drNewRow("qai_colcde") = rs_IMBOMASS.Tables("RESULT").Rows(index4)("iba_colcde")
                            drNewRow("qai_coldsc") = Replace(rs_IMBOMASS.Tables("RESULT").Rows(index4)("icf_coldsc"), "'", "''")
                            drNewRow("qai_untcde") = rs_IMBOMASS.Tables("RESULT").Rows(index4)("iba_pckunt")
                            drNewRow("qai_inrqty") = rs_IMBOMASS.Tables("RESULT").Rows(index4)("iba_inrqty")
                            drNewRow("qai_mtrqty") = rs_IMBOMASS.Tables("RESULT").Rows(index4)("iba_mtrqty")
                            drNewRow("qai_alsitmno") = rs_IMBOMASS.Tables("RESULT").Rows(index4)("ibi_alsitmno")
                            drNewRow("qai_alscolcde") = rs_IMBOMASS.Tables("RESULT").Rows(index4)("ibi_alscolcde")
                            drNewRow("ibi_itmsts") = rs_IMBOMASS.Tables("RESULT").Rows(index4)("ibi_itmsts")
                            drNewRow("qai_imperiod") = rs_IMBOMASS.Tables("RESULT").Rows(index4)("iba_period")
                            rs_QUASSINF.Tables("RESULT").Rows.Add(drNewRow)
                        Next

                        If li_index_insert <> 0 Then
                            sFilter = "qai_qutseq = " & li_index_seq & " and mode <> 'DEL'"
                            rs_QUASSINF.Tables("RESULT").DefaultView.RowFilter = sFilter
                        End If
                    End If


                    Dim drAss() As DataRow
                    drAss = rs_QUASSINF.Tables("RESULT").Select("qai_qutseq = '" & li_index_seq & "' and qai_itmno = '" & txt_itmno & "'")

                    If drAss.Length > 0 Then
                        For index5 As Integer = 0 To drAss.Length - 1

                            gsCompany = Trim(strNewCocde)
                            Call Update_gs_Value(gsCompany)

                            gspStr = "sp_insert_QUASSINF '" & strNewCocde & "','" & txtQutNo2.Text & "','" & max_seq_insert & "','" & _
                                                        UCase(drAss(index5)("qai_itmno").ToString) & "','" & _
                                                        UCase(drAss(index5)("qai_assitm").ToString) & "','" & _
                                                        drAss(index5)("qai_assdsc").ToString & "','" & _
                                                         IIf(IsDBNull(drAss(index5)("qai_cusstyno")) = True, "", drAss(index5)("qai_cusstyno")) & "','" & _
                                                         IIf(IsDBNull(drAss(index5)("qai_cusitm")) = True, "", drAss(index5)("qai_cusitm")) & "','" & _
                                                        drAss(index5)("qai_colcde").ToString & "','" & _
                                                        drAss(index5)("qai_coldsc").ToString & "','" & _
                                                        drAss(index5)("qai_alsitmno").ToString & "','" & _
                                                        drAss(index5)("qai_alscolcde").ToString & "','" & _
                                                        drAss(index5)("qai_cussku").ToString & "','" & _
                                                        drAss(index5)("qai_upcean").ToString & "','" & _
                                                        drAss(index5)("qai_cusrtl").ToString & "','" & _
                                                        drAss(index5)("qai_untcde").ToString & "','" & _
                                                        drAss(index5)("qai_inrqty").ToString & "','" & _
                                                        drAss(index5)("qai_mtrqty").ToString & "','" & _
                                                        IIf(Trim(drAss(index5)("qai_imperiod").ToString) = "" Or _
                                                            IsDBNull(drAss(index5)("qai_imperiod")), _
                                                            "1900-01-01", drAss(index5)("qai_imperiod").ToString & "-01") & "','" & _
                                                        gsUsrID & "'"


                            Message = "sp_insert_QUASSINF"
                            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                            gspStr = ""

                            If rtnLong <> RC_SUCCESS Then
                                MsgBox("Error on loading save_Assortment at result grip row:" & (index + 1) & ".     " & Message & " :" & rtnStr)
                                Exit Sub
                            End If
                        Next
                    End If

                    '''***!component
                    ''Call save_QUCPTBKD(txt_itmno, li_index_seq)


                    '''''''''''''''''''''''''''''ass & b'''

                    ''''''''''''''''End Insert''''''''''''''''''''''''''''''

                Else     'Do NOT has Price Elements
                    'Exit Sub
                    'Just Gen Next Item
                End If



            End If    ''''''''''''''''''''''''''''ITEM NOT found



        Next




        'ma.rs_QUOTNDTL_Copy = rs_ToBeCopy.Copy
        'ma.rs_QUCPTBKD_Copy = rs_QUCPTBKD_copy.Copy
        'ma.rs_QUASSINF_Copy = rs_QUASSINF_copy.Copy
        'ma.rs_QUCSTEMT_Copy = rs_QUCSTEMT_copy.Copy
        'ma.rs_QUADDINF_Copy = rs_QUADDINF_copy.Copy
        'ma.rs_QUELC_Copy = rs_QUELC_copy.Copy
        'ma.rs_QUELCDTL_Copy = rs_QUELCDTL_copy.Copy
        'Call ma.copyQuotation()




        Call save_QUCPTBKD()



        MsgBox(" Qutation Copied to " & txtQutNo2.Text & "!")

        Call ma.qutcopied(strNewCocde, txtQutNo2.Text)
        flag_copy_success = True
        Me.Close()

    End Sub

    Private Function insert_QUOTNDTL_ext(ByVal li_index_insert As Integer) As Boolean
        ''If check_insert_QUOTNDTL() = False Then
        ''    insert_QUOTNDTL = False
        ''    Exit Function
        ''End If

        Dim i As Integer
        Dim qutseq As Integer
        qutseq = 0

        For i = 0 To rs_QUOTNDTL.Tables("RESULT").Rows.Count - 1
            If rs_QUOTNDTL.Tables("RESULT").Rows(i).Item("qud_qutseq") > qutseq Then
                qutseq = rs_QUOTNDTL.Tables("RESULT").Rows(i).Item("qud_qutseq")
            End If
        Next i
        qutseq = qutseq + 1


        drNewRow = rs_QUOTNDTL.Tables("RESULT").NewRow()
        drNewRow("mode") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("Del")
        rs_QUOTNDTL.Tables("RESULT").Rows.Add(drNewRow)
        rs_QUOTNDTL.Tables("RESULT").AcceptChanges()

        '        rs_QUOTNDTL.Tables("RESULT").Rows.Add()

        Dim loc As Integer
        loc = rs_QUOTNDTL.Tables("RESULT").Rows.Count - 1

        For li_i As Integer = 0 To rs_QUOTNDTL.Tables("RESULT").Columns.Count - 1
            rs_QUOTNDTL.Tables("RESULT").Columns(li_i).ReadOnly = False
        Next li_i


        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("Del") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("Del")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("mode") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("mode")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("upditmdtl") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("upditmdtl")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("updmoqmoa") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("updmoqmoa")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("updassbom") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("updassbom")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("converttopc") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("converttopc")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cocde") = strNewCocde
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_qutno") = txtQutNo2.Text
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_qutseq") = qutseq
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_itmsts") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_itmsts")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_qutitmsts") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_qutitmsts")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_itmno") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_itmno")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_itmtyp") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_itmtyp")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_itmnotyp") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_itmnotyp")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_itmnoreal") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_itmnoreal")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_itmnotmp") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_itmnotmp")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_itmnoven") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_itmnoven")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_itmnovenno") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_itmnovenno")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_itmdsc") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_itmdsc")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cusstyno") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_cusstyno")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cusitm") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_cusitm")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_alsitmno") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_alsitmno")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_upc") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_upc")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_colcde") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_colcde")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_coldsc") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_coldsc")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_alscolcde") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_alscolcde")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cuscol") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_cuscol")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_pckseq") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_pckseq")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_packterm") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_packterm")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_untcde") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_untcde")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_inrqty") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_inrqty")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_mtrqty") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_mtrqty")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_prctrm") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_prctrm")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_ftyprctrm") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_ftyprctrm")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_trantrm") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_trantrm")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_conftr") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_conftr")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_effdat") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_effdat")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_expdat") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_expdat")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cus1no") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_cus1no")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cus2no") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_cus2no")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cft") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_cft")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cbm") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_cbm")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("inner_in") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("inner_in")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("master_in") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("master_in")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("inner_cm") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("inner_cm")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("master_cm") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("master_cm")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_inrdin") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_inrdin")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_inrwin") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_inrwin")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_inrhin") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_inrhin")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_mtrdin") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_mtrdin")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_mtrwin") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_mtrwin")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_mtrhin") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_mtrhin")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_inrdcm") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_inrdcm")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_inrwcm") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_inrwcm")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_inrhcm") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_inrhcm")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_mtrdcm") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_mtrdcm")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_mtrwcm") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_mtrwcm")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_mtrhcm") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_mtrhcm")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_qutdat") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_qutdat")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_grswgt") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_grswgt")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_netwgt") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_netwgt")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_pckitr") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_pckitr")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_dept") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_dept")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_hstref") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_hstref")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_moq") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_moq")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_moqunttyp") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_moqunttyp")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_moa") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_moa")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_prcsec") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_prcsec")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_grsmgn") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_grsmgn")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_curcde") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_curcde")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cus1sp") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_cus1sp")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cus2sp") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_cus2sp")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cus1dp") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_cus1dp")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cus2dp") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_cus2dp")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_discnt") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_discnt")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_contopc") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_contopc")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_pcprc") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_pcprc")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_fcurcde") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_fcurcde")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_ftyprc") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_ftyprc")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_ftycst") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_ftycst")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_basprc") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_basprc")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_cocde") = strNewCocde
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_qutno") = txtQutNo2.Text
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_qutseq") = qutseq
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_itmno") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_itmno")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_untcde") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_untcde")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_inrqty") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_inrqty")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_mtrqty") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_mtrqty")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_cft") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_cft")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_cbm") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_cbm")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_ftyprctrm") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_ftyprctrm")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_prctrm") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_prctrm")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_trantrm") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_trantrm")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_fml_cus1no") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_fml_cus1no")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_fml_cus2no") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_fml_cus2no")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_fml_cat") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_fml_cat")
        'rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_ventyp") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("Del")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_fml_ventranflg") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_fml_ventranflg")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_fml_cus1no") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_fml_cus1no")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_fml_cus2no") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_fml_cus2no")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_fml_cat") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_fml_cat")
        ' rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_venno") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("Del")
        'rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_ventyp") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("Del")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_fml_ventranflg") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_fml_ventranflg")
        'rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_prctrm") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("Del")
        'rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_trantrm") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("Del")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_fcurcde") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_fcurcde")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_ftycst") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_ftycst")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_ftyprc") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_ftyprc")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_curcde") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_curcde")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_basprc") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_basprc")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_mu") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_mu")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_mumin") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_mumin")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_muminprc") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_muminprc")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_muprc") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_muprc")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_cus1sp") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_cus1sp")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_cus1dp") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_cus1dp")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_cushcstbufper") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_cushcstbufper")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_cushcstbufamt") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_cushcstbufamt")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_othdisper") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_othdisper")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_maxapvper") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_maxapvper")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_maxapvamt") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_maxapvamt")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_spmuper") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_spmuper")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_dpmuper") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_dpmuper")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_cumu") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_cumu")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_pm") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_pm")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_cush") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_cush")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_thccusper") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_thccusper")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_upsper") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_upsper")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_labper") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_labper")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_faper") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_faper")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_cstbufper") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_cstbufper")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_othper") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_othper")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_pliper") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_pliper")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_dmdper") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_dmdper")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_rbtper") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_rbtper")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_subttlper") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_subttlper")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_pkgper") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_pkgper")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_comper") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_comper")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_icmper") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_icmper")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_stdprc") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_stdprc")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_creusr") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_creusr")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_updusr") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_updusr")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_credat") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_credat")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_upddat") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_upddat")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_timstp") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qpe_timstp")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_stkqty") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_stkqty")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cusqty") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_cusqty")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_smpqty") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_smpqty")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_smpunt") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_smpunt")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_smpprc") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_smpprc")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_rndsts") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_rndsts")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_buyer") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_buyer")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_toqty") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_toqty")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_tormk") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_tormk")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_ftyshpstr") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_ftyshpstr")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_ftyshpend") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_ftyshpend")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cushpstr") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_cushpstr")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cushpend") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_cushpend")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_venno") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_venno")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("vbi_vensts") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("vbi_vensts")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_venitm") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_venitm")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cusven") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_cusven")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_DV") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_DV")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_TV") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_TV")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_ftyaud") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_ftyaud")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cususdcur") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_cususdcur")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cususd") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_cususd")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cuscadcur") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_cuscadcur")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cuscad") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_cuscad")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_note") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_note")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_image") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_image")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_imgpth") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_imgpth")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_hrmcde") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_hrmcde")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_dtyrat") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_dtyrat")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cosmth") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_cosmth")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("ysi_dsc") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("ysi_dsc")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_apprve") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_apprve")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("ibi_catlvl3") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("ibi_catlvl3")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("vbi_ventyp") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("vbi_ventyp")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("CIHCURR") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("CIHCURR")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("CIHAMT") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("CIHAMT")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_onetim") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_onetim")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_pdabpdiff") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_pdabpdiff")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_ftytmpitm") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_ftytmpitm")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_ftytmpitmno") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_ftytmpitmno")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qce_amt") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qce_amt")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_subcde") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_subcde")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_tbm") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_tbm")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_tbmsts") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_tbmsts")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_moflag") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_moflag")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_orgmoq") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_orgmoq")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_orgmoa") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_orgmoa")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cussub") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_cussub")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_specpck") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_specpck")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_custitmcat") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_custitmcat")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_custitmcatfml") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_custitmcatfml")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_custitmcatamt") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_custitmcatamt")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_pmu") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_pmu")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_imrmk") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_imrmk")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_calpmu") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_calpmu")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_creusr") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_creusr")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_updusr") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_updusr")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_credat") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_credat")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_upddat") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_upddat")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_timstp") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_timstp")
    End Function

    Private Function insert_QUOTNDTL_int(ByVal li_index_insert As Integer) As Boolean
        ''If check_insert_QUOTNDTL() = False Then
        ''    insert_QUOTNDTL = False
        ''    Exit Function
        ''End If

        Dim i As Integer
        Dim qutseq As Integer
        qutseq = 0

        For i = 0 To rs_QUOTNDTL.Tables("RESULT").Rows.Count - 1
            If rs_QUOTNDTL.Tables("RESULT").Rows(i).Item("qud_qutseq") > qutseq Then
                qutseq = rs_QUOTNDTL.Tables("RESULT").Rows(i).Item("qud_qutseq")
            End If
        Next i
        qutseq = qutseq + 1


        drNewRow = rs_QUOTNDTL.Tables("RESULT").NewRow()
        drNewRow("mode") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows.Add(drNewRow)
        rs_QUOTNDTL.Tables("RESULT").AcceptChanges()

        '        rs_QUOTNDTL.Tables("RESULT").Rows.Add()

        Dim loc As Integer
        loc = rs_QUOTNDTL.Tables("RESULT").Rows.Count - 1

        For li_i As Integer = 0 To rs_QUOTNDTL.Tables("RESULT").Columns.Count - 1
            rs_QUOTNDTL.Tables("RESULT").Columns(li_i).ReadOnly = False
        Next li_i


        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("Del") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("mode") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("upditmdtl") = "N"
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("updmoqmoa") = "N"
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("updassbom") = "N"
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("converttopc") = "N"
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cocde") = strNewCocde
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_qutno") = txtQutNo2.Text
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_qutseq") = qutseq
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_itmsts") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_qutitmsts") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_itmno") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_itmtyp") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_itmnotyp") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_itmnoreal") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_itmnotmp") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_itmnoven") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_itmnovenno") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_itmdsc") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cusstyno") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cusitm") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_alsitmno") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_upc") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_colcde") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_coldsc") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_alscolcde") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cuscol") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_pckseq") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_packterm") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_untcde") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_inrqty") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_mtrqty") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_prctrm") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_ftyprctrm") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_trantrm") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_conftr") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_effdat") = "01/01/1900"
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_expdat") = "01/01/1900"
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cus1no") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cus2no") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cft") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cbm") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("inner_in") = "0x0x0"
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("master_in") = "0x0x0"
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("inner_cm") = "0x0x0"
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("master_cm") = "0x0x0"
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_inrdin") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_inrwin") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_inrhin") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_mtrdin") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_mtrwin") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_mtrhin") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_inrdcm") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_inrwcm") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_inrhcm") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_mtrdcm") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_mtrwcm") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_mtrhcm") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_qutdat") = rs_ToBeCopy.Tables("RESULT").Rows(li_index_insert).Item("qud_qutdat")
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_grswgt") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_netwgt") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_pckitr") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_dept") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_hstref") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_moq") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_moqunttyp") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_moa") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_prcsec") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_grsmgn") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_curcde") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cus1sp") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cus2sp") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cus1dp") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cus2dp") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_discnt") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_contopc") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_pcprc") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_fcurcde") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_ftyprc") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_ftycst") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_basprc") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_cocde") = strNewCocde
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_qutno") = txtQutNo2.Text
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_qutseq") = qutseq
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_itmno") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_untcde") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_inrqty") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_mtrqty") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_cft") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_cbm") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_ftyprctrm") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_prctrm") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_trantrm") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_fml_cus1no") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_fml_cus2no") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_fml_cat") = ""
        'rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_ventyp") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_fml_ventranflg") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_fml_cus1no") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_fml_cus2no") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_fml_cat") = ""
        ' rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_venno") = ""
        'rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_ventyp") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_fml_ventranflg") = ""
        'rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_prctrm") = ""
        'rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_trantrm") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_fcurcde") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_ftycst") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_ftyprc") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_curcde") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_basprc") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_mu") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_mumin") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_muminprc") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_muprc") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_cus1sp") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_cus1dp") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_cushcstbufper") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_cushcstbufamt") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_othdisper") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_maxapvper") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_maxapvamt") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_spmuper") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_dpmuper") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_cumu") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_pm") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_cush") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_thccusper") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_upsper") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_labper") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_faper") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_cstbufper") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_othper") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_pliper") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_dmdper") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_rbtper") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_subttlper") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_pkgper") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_comper") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_icmper") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_stdprc") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_creusr") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_updusr") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_credat") = "01/01/1900"
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_upddat") = "01/01/1900"
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_timstp") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_stkqty") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cusqty") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_smpqty") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_smpunt") = "PC"
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_smpprc") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_rndsts") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_buyer") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_toqty") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_tormk") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_ftyshpstr") = "01/01/1900"
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_ftyshpend") = "01/01/1900"
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cushpstr") = "01/01/1900"
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cushpend") = "01/01/1900"
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_venno") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("vbi_vensts") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_venitm") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cusven") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_DV") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_TV") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_ftyaud") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cususdcur") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cususd") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cuscadcur") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cuscad") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_note") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_image") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_imgpth") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_hrmcde") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_dtyrat") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cosmth") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("ysi_dsc") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_apprve") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("ibi_catlvl3") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("vbi_ventyp") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("CIHCURR") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("CIHAMT") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_onetim") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_pdabpdiff") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_ftytmpitm") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_ftytmpitmno") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qce_amt") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_subcde") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_tbm") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_tbmsts") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_moflag") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_orgmoq") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_orgmoa") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cussub") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_specpck") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_custitmcat") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_custitmcatfml") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_custitmcatamt") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_pmu") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_imrmk") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_calpmu") = 0
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_creusr") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_updusr") = ""
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_credat") = "01/01/1900"
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_upddat") = "01/01/1900"
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_timstp") = 0
    End Function

    Private Function retrieveMOQMOA(ByVal li_index_insert) As Boolean
        org_MOFLAG_tmp = ""
        org_MOQ_tmp = "0"
        org_MOA_tmp = "0"
        'org_Curr_tmp = ""
        'org_QUTNO_tmp = ""
        org_IM_MOQ_tmp = "0"
        org_IM_MOA_tmp = "0"
        'org_DATASRC_tmp = ""

        '*** Phase 2
        'If txtItmNoVen.Text = "" Then
        '    If cboPcking.Text = "" Or cboPcking.Text = " / 0 / 0 / 0 / 0 / / /" Then Exit Function
        '    'If cboPcking.Text = "" Or cboPcking.Text = " / 0 / 0" Then Exit Function
        'Else
        '    If cboUM.Text = "" Or txtCft.Text = "0" Then Exit Function
        'End If

        Dim cus1no As String
        Dim cus2no As String
        Dim txtUMFtr_Text As String

        If Trim(sRealCus1no) = "" Then
            cus1no = ""
        Else
            cus1no = Trim(Split(sRealCus1no, "-")(0))
        End If

        If Trim(sRealCus2no) = "" Then
            cus2no = ""
        Else
            cus2no = Trim(Split(sRealCus2no, "-")(0))
        End If


        If rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_conftr").ToString = "" Then
            txtUMFtr_Text = "1"
        Else
            txtUMFtr_Text = rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_conftr").ToString
        End If

        Try
            '' Cursor = Cursors.WaitCursor

            gsCompany = Trim(strNewCocde)
            Call Update_gs_Value(gsCompany)

            gspStr = "sp_select_ItemMaster_moq_moa_qu_wunttyp '" & strNewCocde & "','" & _
                                                        cus1no & "','" & _
                                                        cus2no & "','" & _
                                                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_itmno").ToString & "','" & _
                                                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_untcde").ToString & "','" & _
                                                        IIf(txtUMFtr_Text = "", 1, txtUMFtr_Text) & "','" & _
                                                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_inrqty").ToString & "','" & _
                                                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_mtrqty").ToString & "','" & _
                                                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_colcde").ToString & "','" & _
                                                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_cus1sp").ToString & "','" & _
                                                        rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_curcde").ToString & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_SYTIESTR, rtnStr)
            gspStr = ""

            '' Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                'MsgBox("Error on loading retrieveMOQMOA sp_select_ItemMaster_moq_moa_qu_wunttyp :" & rtnStr)
                Exit Function
            End If

            If rs_SYTIESTR.Tables("RESULT").Rows.Count = 0 Then
                'MsgBox("No MOQ & MOA found for this Item")
                'bolUPdate_MOQ_MOA = False
                Exit Function
            Else
                '               org_QUTNO_tmp = IIf(IsDBNull(rs_SYTIESTR.Tables("RESULT").Rows(0)("LAST_QUOT")), "", rs_SYTIESTR.Tables("RESULT").Rows(0)("LAST_QUOT"))
                org_MOFLAG_tmp = IIf(IsDBNull(rs_SYTIESTR.Tables("RESULT").Rows(0)("MOFLAG")), "", rs_SYTIESTR.Tables("RESULT").Rows(0)("MOFLAG"))
                org_MOQ_tmp = CInt(IIf(IsDBNull(rs_SYTIESTR.Tables("RESULT").Rows(0)("MOQ")), "0", IIf(rs_SYTIESTR.Tables("RESULT").Rows(0)("MOQ").ToString = "", "0", rs_SYTIESTR.Tables("RESULT").Rows(0)("MOQ"))))

                '                org_asscnt = IIf(IsDBNull(rs_SYTIESTR.Tables("RESULT").Rows(0)("ASSCNT")), 1, rs_SYTIESTR.Tables("RESULT").Rows(0)("ASSCNT"))

                If org_MOFLAG_tmp = "A" Then
                    org_MOA_tmp = CInt(IIf(IsDBNull(rs_SYTIESTR.Tables("RESULT").Rows(0)("MOA")), "0", IIf(rs_SYTIESTR.Tables("RESULT").Rows(0)("MOA").ToString = "", "0", rs_SYTIESTR.Tables("RESULT").Rows(0)("MOA"))))
                Else
                    org_MOA_tmp = "0"
                End If

                org_IM_MOQ_tmp = IIf(IsDBNull(rs_SYTIESTR.Tables("RESULT").Rows(0)("IMMOQ")), "0", rs_SYTIESTR.Tables("RESULT").Rows(0)("IMMOQ"))
                org_IM_MOA_tmp = IIf(IsDBNull(rs_SYTIESTR.Tables("RESULT").Rows(0)("IMMOA")), "0", rs_SYTIESTR.Tables("RESULT").Rows(0)("IMMOA"))

                ' rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_moq") = org_IM_MOQ_tmp
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_moq") = org_MOQ_tmp


                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_moqunttyp") = IIf(IsDBNull(rs_SYTIESTR.Tables("RESULT").Rows(0)("UNTTYP")), "0", rs_SYTIESTR.Tables("RESULT").Rows(0)("UNTTYP"))
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_moflag") = org_MOFLAG_tmp
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_orgmoq") = org_MOQ_tmp
                rs_QUOTNDTL.Tables("RESULT").Rows(li_index_insert)("qud_orgmoa") = org_MOA_tmp


            End If
        Catch ex As Exception

        End Try
    End Function

    ' ''Private Function get_QUPRCEMT_CU(ByVal qutseq As Integer, ByVal cusno As String, ByVal cusno2 As String, ByVal itmcat As String, ByVal venno As String, ByVal PrcTrm As String, ByVal TranTrm As String) As Boolean
    ' ''    get_QUPRCEMT_CU = False

    ' ''    Dim i As Integer
    ' ''    i = 0

    ' ''    Dim loc As Integer
    ' ''    loc = -1

    ' ''    For i = 0 To rs_QUOTNDTL.Tables("RESULT").Rows.Count - 1
    ' ''        If rs_QUOTNDTL.Tables("RESULT").Rows(i).Item("qud_qutseq") = qutseq Then
    ' ''            loc = i
    ' ''        End If
    ' ''    Next i

    ' ''    If loc = -1 Then
    ' ''        Exit Function
    ' ''    End If

    ' ''    Dim tmp As New DataSet

    ' ''    gsCompany = Trim(strNewCocde)
    ' ''    Call Update_gs_Value(gsCompany)

    ' ''    gspStr = "sp_select_QUPRCEMT_CU '','" & cusno & "','" & cusno2 & "','" & "" & "','" & itmcat & "','" & venno & "','" & PrcTrm & "','" & TranTrm & "'"
    ' ''    rtnLong = execute_SQLStatement(gspStr, tmp, rtnStr)

    ' ''    If rtnLong <> RC_SUCCESS Then
    ' ''        MsgBox("Error on loading get_QUPRCEMT_CU sp_select_QUPRCEMT_CU :" & rtnStr)
    ' ''        Exit Function
    ' ''    End If

    ' ''    If tmp.Tables("RESULT").Rows.Count > 0 Then
    ' ''        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_cocde") = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cocde")
    ' ''        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_qutno") = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_qutno")
    ' ''        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_qutseq") = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_qutseq")
    ' ''        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_itmno") = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_itmno")
    ' ''        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_untcde") = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_untcde")
    ' ''        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_inrqty") = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_inrqty")
    ' ''        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_mtrqty") = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_mtrqty")
    ' ''        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_cft") = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cft")
    ' ''        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_cbm") = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cbm")
    ' ''        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_ftyprctrm") = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_ftyprctrm")
    ' ''        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_prctrm") = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_prctrm")
    ' ''        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_trantrm") = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_trantrm")

    ' ''        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_fml_cus1no") = tmp.Tables("RESULT").Rows(0).Item("ccf_cus1no")
    ' ''        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_fml_cus2no") = tmp.Tables("RESULT").Rows(0).Item("ccf_cus2no")
    ' ''        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_fml_cat") = tmp.Tables("RESULT").Rows(0).Item("ccf_cat")
    ' ''        'rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_fml_venno") = tmp.Tables("RESULT").Rows(0).Item("ccf_venno")
    ' ''        'rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_fml_prctrm") = tmp.Tables("RESULT").Rows(0).Item("ccf_prctrm")
    ' ''        'rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_fml_trantrm") = tmp.Tables("RESULT").Rows(0).Item("ccf_trantrm")
    ' ''        'rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_fml_ventranflg") = tmp.Tables("RESULT").Rows(0).Item("ccf_ventranflg")

    ' ''        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_fcurcde") = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_fcurcde")
    ' ''        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_ftycst") = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_ftycst")
    ' ''        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_ftyprc") = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_ftyprc")
    ' ''        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_curcde") = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_curcde")
    ' ''        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_basprc") = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_basprc")

    ' ''        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_cushcstbufper") = tmp.Tables("RESULT").Rows(0).Item("ccf_cush") + tmp.Tables("RESULT").Rows(0).Item("ccf_cstbufper")
    ' ''        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_othdisper") = tmp.Tables("RESULT").Rows(0).Item("ccf_upsper") + tmp.Tables("RESULT").Rows(0).Item("ccf_labper") + tmp.Tables("RESULT").Rows(0).Item("ccf_faper") + tmp.Tables("RESULT").Rows(0).Item("ccf_othper")
    ' ''        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_maxapvamt") = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_cushcstbufper") + rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_othdisper")

    ' ''        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_cumu") = tmp.Tables("RESULT").Rows(0).Item("ccf_cumu")
    ' ''        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_pm") = tmp.Tables("RESULT").Rows(0).Item("ccf_pm")
    ' ''        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_cush") = tmp.Tables("RESULT").Rows(0).Item("ccf_cush")
    ' ''        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_thccusper") = tmp.Tables("RESULT").Rows(0).Item("ccf_thccusper")
    ' ''        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_upsper") = tmp.Tables("RESULT").Rows(0).Item("ccf_upsper")
    ' ''        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_labper") = tmp.Tables("RESULT").Rows(0).Item("ccf_labper")
    ' ''        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_faper") = tmp.Tables("RESULT").Rows(0).Item("ccf_faper")
    ' ''        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_cstbufper") = tmp.Tables("RESULT").Rows(0).Item("ccf_cstbufper")
    ' ''        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_othper") = tmp.Tables("RESULT").Rows(0).Item("ccf_othper")
    ' ''        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_pliper") = tmp.Tables("RESULT").Rows(0).Item("ccf_pliper")
    ' ''        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_dmdper") = tmp.Tables("RESULT").Rows(0).Item("ccf_dmdper")
    ' ''        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_rbtper") = tmp.Tables("RESULT").Rows(0).Item("ccf_rbtper")
    ' ''        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_pkgper") = tmp.Tables("RESULT").Rows(0).Item("ccf_pkgper")
    ' ''        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_comper") = tmp.Tables("RESULT").Rows(0).Item("ccf_comper")
    ' ''        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_icmper") = tmp.Tables("RESULT").Rows(0).Item("ccf_icmper")

    ' ''        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_subttlper") = tmp.Tables("RESULT").Rows(0).Item("ccf_cumu") + _
    ' ''                                                                        tmp.Tables("RESULT").Rows(0).Item("ccf_pm") + _
    ' ''                                                                        tmp.Tables("RESULT").Rows(0).Item("ccf_cush") + _
    ' ''                                                                        tmp.Tables("RESULT").Rows(0).Item("ccf_thccusper") + _
    ' ''                                                                        tmp.Tables("RESULT").Rows(0).Item("ccf_upsper") + _
    ' ''                                                                        tmp.Tables("RESULT").Rows(0).Item("ccf_labper") + _
    ' ''                                                                        tmp.Tables("RESULT").Rows(0).Item("ccf_faper") + _
    ' ''                                                                        tmp.Tables("RESULT").Rows(0).Item("ccf_cstbufper") + _
    ' ''                                                                        tmp.Tables("RESULT").Rows(0).Item("ccf_othper") + _
    ' ''                                                                        tmp.Tables("RESULT").Rows(0).Item("ccf_pliper") + _
    ' ''                                                                        tmp.Tables("RESULT").Rows(0).Item("ccf_dmdper") + _
    ' ''                                                                        tmp.Tables("RESULT").Rows(0).Item("ccf_rbtper")

    ' ''        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_mu") = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_subttlper")

    ' ''        get_QUPRCEMT_CU = True
    ' ''    Else
    ' ''        MsgBox("Item " & txt_itmno & " cannot be quoted due to no Quotation Pricing formula!")
    ' ''        'Exit Function
    ' ''    End If
    ' ''End Function
    Private Function get_QUPRCEMT_CU(ByVal qutseq As Integer, ByVal cusno As String, ByVal cusno2 As String, ByVal ventyp As String, ByVal itmcat As String, ByVal venno As String, ByVal PrcTrm As String, ByVal TranTrm As String) As Boolean
        get_QUPRCEMT_CU = False

        Dim i As Integer
        i = 0

        Dim loc As Integer
        loc = -1

        For i = 0 To rs_QUOTNDTL.Tables("RESULT").Rows.Count - 1
            If rs_QUOTNDTL.Tables("RESULT").Rows(i).Item("qud_qutseq") = qutseq Then
                loc = i
            End If
        Next i

        If loc = -1 Then
            Exit Function
        End If

        Dim tmp As New DataSet

        gsCompany = Trim(strNewCocde)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_QUPRCEMT_CU '','" & cusno & "','" & cusno2 & "','" & ventyp & "','" & itmcat & "','" & venno & "','" & PrcTrm & "','" & TranTrm & "'"
        rtnLong = execute_SQLStatement(gspStr, tmp, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading get_QUPRCEMT_CU sp_select_QUPRCEMT_CU :" & rtnStr)
            Exit Function
        End If

        If tmp.Tables("RESULT").Rows.Count > 0 Then
            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_cocde") = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cocde")
            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_qutno") = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_qutno")
            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_qutseq") = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_qutseq")
            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_itmno") = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_itmno")
            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_untcde") = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_untcde")
            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_inrqty") = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_inrqty")
            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_mtrqty") = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_mtrqty")
            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_cft") = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cft")
            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_cbm") = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cbm")
            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_ftyprctrm") = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_ftyprctrm")
            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_prctrm") = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_prctrm")
            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_trantrm") = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_trantrm")

            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_fml_cus1no") = tmp.Tables("RESULT").Rows(0).Item("ccf_cus1no")
            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_fml_cus2no") = tmp.Tables("RESULT").Rows(0).Item("ccf_cus2no")
            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_fml_cat") = tmp.Tables("RESULT").Rows(0).Item("ccf_cat")
            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_fml_venno") = tmp.Tables("RESULT").Rows(0).Item("ccf_venno")
            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_fml_prctrm") = tmp.Tables("RESULT").Rows(0).Item("ccf_prctrm")
            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_fml_trantrm") = tmp.Tables("RESULT").Rows(0).Item("ccf_trantrm")
            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_fml_ventranflg") = tmp.Tables("RESULT").Rows(0).Item("ccf_ventranflg")

            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_fcurcde") = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_fcurcde")
            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_ftycst") = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_ftycst")
            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_ftyprc") = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_ftyprc")
            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_curcde") = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_curcde")
            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_basprc") = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_basprc")

            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_cushcstbufper") = tmp.Tables("RESULT").Rows(0).Item("ccf_cush") + tmp.Tables("RESULT").Rows(0).Item("ccf_cstbufper")
            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_othdisper") = tmp.Tables("RESULT").Rows(0).Item("ccf_upsper") + tmp.Tables("RESULT").Rows(0).Item("ccf_labper") + tmp.Tables("RESULT").Rows(0).Item("ccf_faper") + tmp.Tables("RESULT").Rows(0).Item("ccf_othper")
            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_maxapvper") = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_cushcstbufper") + rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_othdisper")

            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_cumu") = tmp.Tables("RESULT").Rows(0).Item("ccf_cumu")
            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_pm") = tmp.Tables("RESULT").Rows(0).Item("ccf_pm")
            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_cush") = tmp.Tables("RESULT").Rows(0).Item("ccf_cush")
            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_thccusper") = tmp.Tables("RESULT").Rows(0).Item("ccf_thccusper")
            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_upsper") = tmp.Tables("RESULT").Rows(0).Item("ccf_upsper")
            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_labper") = tmp.Tables("RESULT").Rows(0).Item("ccf_labper")
            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_faper") = tmp.Tables("RESULT").Rows(0).Item("ccf_faper")
            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_cstbufper") = tmp.Tables("RESULT").Rows(0).Item("ccf_cstbufper")
            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_othper") = tmp.Tables("RESULT").Rows(0).Item("ccf_othper")
            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_pliper") = tmp.Tables("RESULT").Rows(0).Item("ccf_pliper")
            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_dmdper") = tmp.Tables("RESULT").Rows(0).Item("ccf_dmdper")
            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_rbtper") = tmp.Tables("RESULT").Rows(0).Item("ccf_rbtper")
            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_pkgper") = tmp.Tables("RESULT").Rows(0).Item("ccf_pkgper")
            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_comper") = tmp.Tables("RESULT").Rows(0).Item("ccf_comper")
            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_icmper") = tmp.Tables("RESULT").Rows(0).Item("ccf_icmper")

            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_subttlper") = tmp.Tables("RESULT").Rows(0).Item("ccf_cumu") + _
                                                                            tmp.Tables("RESULT").Rows(0).Item("ccf_pm") + _
                                                                            tmp.Tables("RESULT").Rows(0).Item("ccf_thccusper") + _
                                                                            tmp.Tables("RESULT").Rows(0).Item("ccf_upsper") + _
                                                                            tmp.Tables("RESULT").Rows(0).Item("ccf_labper") + _
                                                                            tmp.Tables("RESULT").Rows(0).Item("ccf_faper") + _
                                                                            tmp.Tables("RESULT").Rows(0).Item("ccf_cstbufper") + _
                                                                            tmp.Tables("RESULT").Rows(0).Item("ccf_othper") + _
                                                                            tmp.Tables("RESULT").Rows(0).Item("ccf_pliper") + _
                                                                            tmp.Tables("RESULT").Rows(0).Item("ccf_dmdper") + _
                                                                            tmp.Tables("RESULT").Rows(0).Item("ccf_rbtper")

            rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_mu") = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_subttlper")

            get_QUPRCEMT_CU = True
        Else
            MsgBox("Item " & rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_itmno") & " cannot be quoted due to no Quotation Pricing formula!")
            Exit Function
        End If
    End Function



    Private Function check_QUPRCEMT_CU(ByVal qutseq As Integer, ByVal cusno As String, ByVal cusno2 As String, ByVal ventyp As String, ByVal itmcat As String, ByVal venno As String, ByVal PrcTrm As String, ByVal TranTrm As String) As Boolean
        check_QUPRCEMT_CU = False

        Dim i As Integer
        i = 0

        Dim loc As Integer
        loc = -1


        Dim tmp As New DataSet

        gsCompany = Trim(strNewCocde)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_QUPRCEMT_CU '','" & cusno & "','" & cusno2 & "','" & ventyp & "','" & itmcat & "','" & venno & "','" & PrcTrm & "','" & TranTrm & "'"
        rtnLong = execute_SQLStatement(gspStr, tmp, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading check_QUPRCEMT_CU sp_select_QUPRCEMT_CU :" & rtnStr)
            Exit Function
        End If

        If tmp.Tables("RESULT").Rows.Count > 0 Then
            check_QUPRCEMT_CU = True
        Else
            check_QUPRCEMT_CU = False
        End If
    End Function



    Private Sub calculate_gbPandelCstEmt(ByVal qutseq As Integer)
        Dim i As Integer
        i = 0

        Dim loc As Integer
        loc = -1

        For i = 0 To rs_QUOTNDTL.Tables("RESULT").Rows.Count - 1
            If rs_QUOTNDTL.Tables("RESULT").Rows(i).Item("qud_qutseq") = qutseq Then
                loc = i
            End If
        Next i

        If loc = -1 Then
            Exit Sub
        End If

        Dim calBasicPrice As Decimal

        Dim calMarkup_Org As Decimal
        Dim calMarkup_Usr As Decimal

        Dim calPckCstAmt As Decimal
        Dim calCommPer As Decimal
        Dim calCommAmt As Decimal

        Dim calCURounding As Integer

        ' StdPrc = BP * MU Org = MU Prc Org + PckCst Amt * CommPer + CommAmt
        ' AdjPrc = BP * MU Usr = MU Prc Usr + PckCst Amt * CommPer + CommAmt

        ''avoid DBNULL
        If Not rs_QUOTNDTL.Tables("RESULT").Rows.Count > loc Then
            Exit Sub
        End If

        calBasicPrice = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_basprc")
        calMarkup_Org = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_subttlper")
        calMarkup_Usr = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_mu")

        calPckCstAmt = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_pkgper")
        calCommPer = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_comper")
        calCommAmt = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_icmper")

        calCURounding = cus1_rounding 'temporary hard code : used in Standard Price and Adjusted Price

        Dim calMarkupPrice_Org As Decimal
        Dim calMarkupPrice_Usr As Decimal

        Dim resStandardPrice As Decimal
        Dim resAdjustedPrice As Decimal

        '1. Calculate Standard Price
        If calMarkup_Org <> 100 Then
            calMarkupPrice_Org = round(calBasicPrice / ((1 - calMarkup_Org / 100)), 4)
        End If
        If calCommPer <> 100 Then
            resStandardPrice = round(round((calMarkupPrice_Org + calPckCstAmt) / ((1 - calCommPer / 100)), 4) + round(calCommAmt, 4), calCURounding)
        End If

        '2 Calculate Adjusted Price
        If calMarkup_Usr <> 100 Then
            calMarkupPrice_Usr = round(calBasicPrice / ((1 - calMarkup_Usr / 100)), 4)
        End If

        If calCommPer <> 100 Then
            resAdjustedPrice = round(round((calMarkupPrice_Usr + calPckCstAmt) / ((1 - calCommPer / 100)), 4) + round(calCommAmt, 4), calCURounding)
        End If

        '3 Calculate Minimun Markup
        Dim calCushCstbufPer As Decimal
        Dim calOthDisPer As Decimal
        Dim calThcCusPer As Decimal
        Dim calVenTranFlag As String

        calCushCstbufPer = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_cushcstbufper")
        calOthDisPer = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_othdisper")
        calThcCusPer = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_thccusper")

        If IsDBNull(rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_fml_ventranflg")) Then
            calVenTranFlag = "N"

        Else
            calVenTranFlag = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_fml_ventranflg")

        End If

        Dim resMinMarkupPer As Decimal

        If calVenTranFlag = "Y" Then
            resMinMarkupPer = calMarkup_Org - calCushCstbufPer - calOthDisPer - calThcCusPer
        Else
            resMinMarkupPer = calMarkup_Org - calCushCstbufPer - calOthDisPer
        End If

        '4 Calculate Minimum Markup Price
        Dim resMinMarkupPrc As Decimal
        'resMinMarkupPrc = round((calBasicPrice / (1 - resMinMarkupPer / 100)) + calPckCstAmt + calCommAmt, 4)
        resMinMarkupPrc = round(((calBasicPrice / (1 - resMinMarkupPer / 100)) / (1 - calCommPer / 100)) + calPckCstAmt + calCommAmt, 4)

        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_mumin") = resMinMarkupPer
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_muprc") = calMarkupPrice_Usr
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_muminprc") = resMinMarkupPrc
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_pkgper") = calPckCstAmt
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_comper") = calCommPer
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_icmper") = calCommAmt

        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cus1sp") = resStandardPrice
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_cus1dp") = resAdjustedPrice

        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_cus1sp") = resStandardPrice
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_cus1dp") = resAdjustedPrice

        'Call check_mu(sReadingIndexQ)


        '5 Calculate Sample Price
        Dim strUM As String
        Dim samplePrice As Decimal
        Dim itmtyp As String
        Dim umftr As Decimal

        strUM = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_untcde")
        gspStr = "sp_select_CUBASINF_Q '','" & strUM & "','Conversion'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYCONFTR, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading calculate_gbPandelCstEmt sp_select_CUBASINF_Q :" & rtnStr)
            Exit Sub
        End If

        If rs_SYCONFTR.Tables("RESULT").Rows.Count = 0 Then
            samplePrice = Format(round(resAdjustedPrice, calCURounding), "###,###,##0.0000")
        Else
            samplePrice = Format(round(resAdjustedPrice / rs_SYCONFTR.Tables("RESULT").Rows(0)("ycf_value"), calCURounding), "###,###,##0.0000")
        End If

        itmtyp = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_itmtyp")


        If itmtyp = "ASS" Then
            If Not IsNumeric(rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_conftr")) Then
                umftr = 1
            Else
                umftr = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_conftr")
            End If

            samplePrice = Format(round(resAdjustedPrice / umftr, calCURounding), "###,###,##0.0000")
        Else

            '''20140211
            If rs_SYCONFTR.Tables("RESULT").Rows.Count = 0 Then
                umftr = 1
            Else
                umftr = rs_SYCONFTR.Tables("RESULT").Rows(0)("ycf_value")
            End If
            samplePrice = Format(round(resAdjustedPrice / umftr, calCURounding), "###,###,##0.0000")

        End If




        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_smpprc") = samplePrice

        '20130909
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_pcprc") = samplePrice


    End Sub

    Private Sub cboCus1NoClick2()
        Dim sFilter As String


        If sRealCus1no <> "" And Validate() = True Then


            dr = rs_CUBASINF_P.Tables("RESULT").Select("cbi_cusno = " & "'" & Split(sRealCus1no, "-")(0) & "'")

            Dim srname As String
            srname = dr(0).Item("cbi_srname")

            txt_Cus1Ad_Text = dr(0)("cci_cntadr").ToString
            txt_Cus1St_Text = dr(0)("cci_cntstt").ToString
            txt_Cus1Cy_Text = dr(0)("cci_cntcty").ToString
            txt_Cus1Zp_Text = dr(0)("cci_cntpst").ToString
            txt_PrcTrm_Text = Microsoft.VisualBasic.Left(dr(0)("prctrm").ToString, 6)
            txt_PayTrm_Text = Microsoft.VisualBasic.Left(dr(0)("paytrm").ToString, 3)

            txt_SmpPrd_Text = Microsoft.VisualBasic.Left(dr(0)("smpprd").ToString, 5)
            txt_SmpFgt_Text = Microsoft.VisualBasic.Left(dr(0)("smpfgt").ToString, 5)

            txtCurCde1 = dr(0)("cpi_curcde").ToString
            quh_cugrptyp_int = "0"
            quh_cugrptyp_ext = "0"

            'modify
            If rs_CUBASINF_P.Tables("RESULT").Columns.Contains("cbi_cugrptyp_int") And rs_CUBASINF_P.Tables("RESULT").Columns.Contains("cbi_cugrptyp_ext") Then
                txt_Cus1CgInt_Text = dr(0)("cbi_cugrptyp_int")
                txt_Cus1CgExt_Text = dr(0)("cbi_cugrptyp_ext")
            Else
                txt_Cus1CgInt_Text = ""
                txt_Cus1CgExt_Text = ""
            End If

            txt_Cus1Cp_Text = ""

            '*** Contact Person for Primary Customer
            '' Cursor = Cursors.WaitCursor
            gsCompany = Trim(strNewCocde)
            Call Update_gs_Value(gsCompany)
            '1
            'gspStr = "sp_list_CUCNTINF '','" & Replace(sRealCus1no, "'", "''") & "','C'"
            'rtnLong = execute_SQLStatement(gspStr, rs_CUCNTINF_C, rtnStr)
            'If rtnLong <> RC_SUCCESS Then
            '    MsgBox("Error on loading QUM00001 sp_list_CUCNTINF_C :" & rtnStr)
            '    Exit Sub
            'End If

            'If rs_CUCNTINF_C.Tables("RESULT").Rows.Count > 0 Then
            '    txt_Cus1Cp_Text = rs_CUCNTINF_C.Tables("RESULT").Rows(0).Item("cci_cntctp").ToString.Trim
            'End If


            gspStr = "sp_list_CUCNTINF '','" & Replace(sRealCus1no, "'", "''") & "','C'"
            rtnLong = execute_SQLStatement(gspStr, rs_CUCNTINF_C, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading frmQut sp_list_CUCNTINF_C :" & rtnStr)
                Exit Sub
            End If

            'If rs_CUCNTINF_C.Tables("RESULT").Rows.Count > 0 Then
            '    cboCus1Cp.Items.Add(rs_CUCNTINF_C.Tables("RESULT").Rows(0).Item("cci_cntctp").ToString.Trim)
            '    cboCus1Cp.Text = rs_CUCNTINF_C.Tables("RESULT").Rows(0).Item("cci_cntctp").ToString.Trim
            'End If

            If rs_CUCNTINF_C.Tables("RESULT").Rows.Count > 0 Then
                Dim dr() As DataRow = rs_CUCNTINF_C.Tables("RESULT").Select("cci_cntdef = 'Y' and cci_cnttyp = 'BUYR'")
                If dr.Length = 0 Then
                    dr = Nothing
                    dr = rs_CUCNTINF_C.Tables("RESULT").Select("cci_cntdef = 'Y' and cci_cnttyp = 'SALE'")
                    If dr.Length = 0 Then
                        dr = Nothing
                        dr = rs_CUCNTINF_C.Tables("RESULT").Select("cci_cntdef = 'Y' and cci_cnttyp = 'SALE'")
                        If dr.Length = 0 Then
                            dr = Nothing
                            dr = rs_CUCNTINF_C.Tables("RESULT").Select("cci_cntdef = 'Y' and cci_cnttyp = 'MAGT'")
                            If dr.Length = 0 Then
                                dr = Nothing
                                dr = rs_CUCNTINF_C.Tables("RESULT").Select("cci_cntdef = 'Y'")
                                If dr.Length > 0 Then
                                    txt_Cus1Cp_Text = (dr(0).Item("cci_cntctp").ToString.Trim)
                                    'cboCus1Cp.Items.Add(dr(0).Item("cci_cntctp").ToString.Trim)
                                    'display_combo(dr(0).Item("cci_cntctp").ToString.Trim, cboCus1Cp)
                                End If
                            Else
                                txt_Cus1Cp_Text = (dr(0).Item("cci_cntctp").ToString.Trim)
                                'cboCus1Cp.Items.Add(dr(0).Item("cci_cntctp").ToString.Trim)
                                'display_combo(dr(0).Item("cci_cntctp").ToString.Trim, cboCus1Cp)
                            End If
                        Else
                            txt_Cus1Cp_Text = (dr(0).Item("cci_cntctp").ToString.Trim)
                            'cboCus1Cp.Items.Add(dr(0).Item("cci_cntctp").ToString.Trim)
                            'display_combo(dr(0).Item("cci_cntctp").ToString.Trim, cboCus1Cp)
                        End If
                    Else
                        txt_Cus1Cp_Text = (dr(0).Item("cci_cntctp").ToString.Trim)

                        'cboCus1Cp.Items.Add(dr(0).Item("cci_cntctp").ToString.Trim)
                        'display_combo(dr(0).Item("cci_cntctp").ToString.Trim, cboCus1Cp)
                    End If
                Else
                    txt_Cus1Cp_Text = (dr(0).Item("cci_cntctp").ToString.Trim)

                    'cboCus1Cp.Items.Add(dr(0).Item("cci_cntctp").ToString.Trim)
                    'display_combo(dr(0).Item("cci_cntctp").ToString.Trim, cboCus1Cp)
                End If
            End If









            '2
            gspStr = "sp_select_CUBASINF_Q '" & strNewCocde & "','" & Split(sRealCus1no, "-")(0) & "','Contact Person'"
            rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_CP, rtnStr)
            gspStr = ""

            '' Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cboCus1NoClick sp_select_CUBASINF_Q 1 :" & rtnStr)
                '' Cursor = Cursors.Default
                Exit Sub
            End If

            If rs_CUBASINF_CP.Tables("RESULT").Rows.Count = 0 Then       '***  Not Found Record
                'txt_Cus1Cp.Enabled = False
            Else
                ''txt_Cus1Cp.Enabled = True
                'txt_Cus1Cp.Items.Clear()  'see1
                'txt_Cus1Cp_Text = ""     'see1
                For index As Integer = 0 To rs_CUBASINF_CP.Tables("RESULT").Rows.Count - 1
                    If Not (txt_Cus1Cp_Text = rs_CUBASINF_CP.Tables("RESULT").Rows(index)("cci_cntctp").ToString.Trim) Then  'see 1
                    End If
                Next

                dr = rs_CUBASINF_CP.Tables("RESULT").Select("buyrY = 'BUYR - Y'")
                If dr.Length > 0 Then
                    'txt_Cus1Cp_Text = dr(0)("cci_cntctp")
                End If
            End If

            '*** Secondary Customer for Primary Customer
            '' Cursor = Cursors.WaitCursor

            gsCompany = Trim(strNewCocde)
            Call Update_gs_Value(gsCompany)

            gspStr = "sp_select_CUBASINF_Q '" & strNewCocde & "','" & Split(sRealCus1no, "-")(0) & "','Secondary'"
            rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_S, rtnStr)
            gspStr = ""

            '' Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cboCus1NoClick sp_select_CUBASINF_Q 2 :" & rtnStr)
                '' Cursor = Cursors.Default
                Exit Sub
            End If


            '*** Agent for Primary Customer
            '' Cursor = Cursors.WaitCursor

            gsCompany = Trim(strNewCocde)
            Call Update_gs_Value(gsCompany)

            gspStr = "sp_select_CUBASINF_Q '" & strNewCocde & "','" & Split(sRealCus1no, "-")(0) & "','Agent'"
            rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_A, rtnStr)
            gspStr = ""

            '' Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cboCus1NoClick sp_select_CUBASINF_Q 3 :" & rtnStr)
                '' Cursor = Cursors.Default
                Exit Sub
            End If

            If rs_CUBASINF_A.Tables("RESULT").Rows.Count = 0 Then       '***  Not Found Record
            Else
                dr = rs_CUBASINF_A.Tables("RESULT").Select("cai_cusdef = 'Y'")
                If dr.Length > 0 Then
                    txt_CusAgt_Text = dr(0)("cai_cusagt").ToString + " - " + dr(0)("yai_stnam").ToString
                End If
            End If

            dr = rs_CUBASINF_P.Tables("RESULT").Select("cbi_cusno = " & "'" & Split(sRealCus1no, "-")(0) & "'")





            ''''''''''''''''''''''''''''''2

            '*** Phase 2
            '*** Sales Division, Team, & Sales Rep. for Primary Customer
            '' Cursor = Cursors.WaitCursor

            gsCompany = Trim(strNewCocde)
            Call Update_gs_Value(gsCompany)

            gspStr = "sp_list_SYSALREL '" & strNewCocde & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_SYSALREL, rtnStr)
            gspStr = ""

            '' Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cboCus1NoClick sp_list_SYSALREL :" & rtnStr)
                '' Cursor = Cursors.Default
                Exit Sub
            End If

            If rs_SYSALREL.Tables("RESULT").Rows.Count = 0 Then       '***  Not Found Record
                'cboSalDiv.Enabled = False
                'cboSalDiv.Items.Clear()
                'cboSalDiv.Text = ""

                'cboSalRep.Enabled = False
                'cboSalRep.Items.Clear()
                'cboSalRep.Text = ""
            Else
                sFilter = "ssr_saltem = " & "'" & dr(0)("cbi_saltem").ToString.Trim & "'"
                rs_SYSALREL.Tables("RESULT").DefaultView.RowFilter = sFilter
                rs_SYSALREL.Tables("RESULT").DefaultView.Sort = "ssr_saldiv, ssr_saltem"
                sFilter = ""

                If rs_SYSALREL.Tables("RESULT").DefaultView.Count = 0 Then
                    'cboSalDiv.Enabled = False
                    'cboSalDiv.Items.Clear()
                    'cboSalDiv.Text = ""

                    'cboSalRep.Enabled = False
                    'cboSalRep.Items.Clear()
                    'cboSalRep.Text = ""
                Else

                    'cboSalDiv.Enabled = True
                    'cboSalDiv.Items.Clear()
                    'cboSalDiv.Text = ""

                    Dim sTmpDiv, sTmpTeam As String

                    sTmpDiv = rs_SYSALREL.Tables("RESULT").DefaultView(0)("ssr_saldiv").ToString.Trim
                    sTmpTeam = rs_SYSALREL.Tables("RESULT").DefaultView(0)("ssr_saltem").ToString.Trim

                    '  cboSalDiv.Items.Add("")
                    '  cboSalDiv.Items.Add("Division " & sTmpDiv & " (Team " & sTmpTeam & ")")

                    If rs_SYSALREL.Tables("RESULT").DefaultView.Count > 1 Then
                        For index As Integer = 1 To rs_SYSALREL.Tables("RESULT").DefaultView.Count - 1
                            If sTmpDiv <> rs_SYSALREL.Tables("RESULT").DefaultView(index)("ssr_saldiv").ToString.Trim Or _
                                sTmpTeam <> rs_SYSALREL.Tables("RESULT").DefaultView(index)("ssr_saltem").ToString.Trim Then

                                sTmpDiv = rs_SYSALREL.Tables("RESULT").DefaultView(index)("ssr_saldiv").ToString.Trim
                                sTmpTeam = rs_SYSALREL.Tables("RESULT").DefaultView(index)("ssr_saltem").ToString.Trim

                                ' cboSalDiv.Items.Add("Division " & sTmpDiv & " (Team " & sTmpTeam & ")")
                            End If
                        Next
                        txt_SalDiv_Text = "Division " & sTmpDiv & " (Team " & sTmpTeam & ")"
                        ' display_combo("Division " & sTmpDiv & " (Team " & sTmpTeam & ")", cboSalDiv)
                    End If

                    '        'Modify 2013
                    'cboSalDiv.Enabled = False
                    'cboSalRep.Enabled = True
                    'cboSalRep.Items.Clear()
                    'cboSalRep.Text = ""
                    Dim usrname As String

                    ''cboSalRep.Items.Add("")
                    'For index As Integer = 0 To rs_SYSALREL.Tables("RESULT").DefaultView.Count - 1
                    '    'cboSalRep.Items.Add(rs_SYSALREL.Tables("RESULT").DefaultView(index)("ssr_usrnam").ToString.Trim & " (" & _
                    '    'rs_SYSALREL.Tables("RESULT").DefaultView(index)("ssr_salrep").ToString.Trim & ")")
                    'Next

                    'cboSalRep.Items.Add("")
                    For index As Integer = 0 To rs_SYSALREL.Tables("RESULT").DefaultView.Count - 1
                        'cboSalRep.Items.Add(rs_SYSALREL.Tables("RESULT").DefaultView(index)("ssr_usrnam").ToString.Trim & " (" & _
                        'rs_SYSALREL.Tables("RESULT").DefaultView(index)("ssr_salrep").ToString.Trim & ")")
                        If srname = rs_SYSALREL.Tables("RESULT").DefaultView(index)("ssr_salrep").ToString.Trim Then
                            usrname = rs_SYSALREL.Tables("RESULT").DefaultView(index)("ssr_usrnam").ToString.Trim
                        End If
                    Next


                    sFilter = "ssr_saltem = " & "'" & dr(0)("cbi_saltem").ToString.Trim & "' and " & "ssr_default = 'Y'"
                    rs_SYSALREL.Tables("RESULT").DefaultView.RowFilter = sFilter
                    sFilter = ""

                    'If rs_SYSALREL.Tables("RESULT").DefaultView.Count > 0 Then

                    '    txt_SalRep_Text = rs_SYSALREL.Tables("RESULT").DefaultView(0)("ssr_usrnam").ToString.Trim
                    '    txt_Srname_Text = rs_SYSALREL.Tables("RESULT").DefaultView(0)("ssr_salrep").ToString.Trim

                    '    'display_combo(rs_SYSALREL.Tables("RESULT").DefaultView(0)("ssr_usrnam").ToString.Trim & " (" & _
                    '    '                    rs_SYSALREL.Tables("RESULT").DefaultView(0)("ssr_salrep").ToString.Trim & ")", cboSalRep)
                    'End If

                    If srname <> "" Then
                        'display_combo(usrname & " (" & srname & ")", cboSalRep)
                        txt_SalRep_Text = usrname
                        txt_Srname_Text = srname
                    Else
                        If rs_SYSALREL.Tables("RESULT").DefaultView.Count > 0 Then
                            txt_SalRep_Text = rs_SYSALREL.Tables("RESULT").DefaultView(0)("ssr_usrnam").ToString.Trim
                            txt_Srname_Text = rs_SYSALREL.Tables("RESULT").DefaultView(0)("ssr_salrep").ToString.Trim

                            'display_combo(rs_SYSALREL.Tables("RESULT").DefaultView(0)("ssr_usrnam").ToString.Trim & " (" & _
                            '                    rs_SYSALREL.Tables("RESULT").DefaultView(0)("ssr_salrep").ToString.Trim & ")", cboSalRep)
                        End If
                    End If



                End If
            End If

            ''''''''''''''''''''''''''2

        End If
    End Sub

    'Private Sub cboCus1NoClick3()
    '    If cboCus1No.Text <> "" And Validate() = True Then
    '        cboCus2No.Items.Clear()
    '        cboCus2No.Text = ""
    '        txtCus2Ad.Text = ""
    '        txtCus2St.Text = ""
    '        txtCus2Cy.Text = ""
    '        txtCus2Zp.Text = ""
    '        cboCus2Cp.Items.Clear()
    '        cboCus2Cp.Text = ""
    '        optActive.Checked = False
    '        optPassive.Checked = False
    '        cboCusAgt.Items.Clear()
    '        cboCusAgt.Text = ""
    '        '*** Phase 2
    '        cboSalDiv.Items.Clear()
    '        cboSalDiv.Text = ""

    '        cboSalRep.Items.Clear()
    '        cboSalRep.Text = ""
    '        cboSmpPrd.Items.Clear()
    '        cboSmpPrd.Text = ""
    '        cboSmpFgt.Items.Clear()
    '        cboSmpFgt.Text = ""
    '        txtPrcTrm.Text = ""
    '        txtPayTrm.Text = ""
    '        txtCurCde.Text = ""
    '        If InStr(cboCus1No.Text, " - ") - 1 >= 0 Then
    '            dr = rs_CUBASINF_P.Tables("RESULT").Select("cbi_cusno = " & "'" & Microsoft.VisualBasic.Left(cboCus1No.Text, InStr(cboCus1No.Text, " - ") - 1) & "'")
    '        End If

    '        txtCus1Ad.Text = dr(0)("cci_cntadr").ToString
    '        txtCus1St.Text = dr(0)("cci_cntstt").ToString
    '        txtCus1Cy.Text = dr(0)("cci_cntcty").ToString
    '        txtCus1Zp.Text = dr(0)("cci_cntpst").ToString
    '        txtPrcTrm.Text = dr(0)("prctrm").ToString
    '        txtPayTrm.Text = dr(0)("paytrm").ToString
    '        cboSmpPrd.Text = dr(0)("smpprd").ToString
    '        cboSmpFgt.Text = dr(0)("smpfgt").ToString
    '        txtCurCde.Text = dr(0)("curcde").ToString
    '        txtCurCde1.Text = dr(0)("cpi_curcde").ToString
    '        '*** set enable of txtCurrMOQ
    '        txtCurrMOQ.Text = dr(0)("cpi_curcde").ToString
    '        txtCurCde2.Text = dr(0)("cpi_curcde").ToString
    '        txtCurCde3.Text = dr(0)("cpi_curcde").ToString
    '        txtCurCde7.Text = dr(0)("cpi_curcde").ToString
    '        '*** Phase 2
    '        lblPckCstAmt.Text = "Amt (" & txtCurCde2.Text & ")"
    '        lblItmCommAmt.Text = "Amt (" & txtCurCde2.Text & ")"

    '        txtPCPrcCur.Text = dr(0)("cpi_curcde").ToString

    '        rs_QUOTNDTL.Tables("RESULT").Rows(0).Item("qud_curcde") = dr(0)("cpi_curcde").ToString

    '        Dim srname As String
    '        srname = dr(0).Item("cbi_srname")

    '        'modify
    '        If rs_CUBASINF_P.Tables("RESULT").Columns.Contains("cbi_cugrptyp_int") And rs_CUBASINF_P.Tables("RESULT").Columns.Contains("cbi_cugrptyp_ext") Then 'bug
    '            If dr(0)("cbi_cugrptyp_int").ToString.Trim <> "" Or dr(0)("cbi_cugrptyp_ext").ToString.Trim <> "" Then
    '                display_combo(dr(0)("cbi_cugrptyp_int").ToString.Trim, cboCus1CgInt)
    '                display_combo(dr(0)("cbi_cugrptyp_ext").ToString.Trim, cboCus1CgExt)
    '            End If
    '        Else
    '            cboCus1CgInt.Text = ""
    '            cboCus1CgExt.Text = ""
    '        End If

    '        cboCus1Cp.Items.Clear()
    '        cboCus1Cp.Text = ""

    '        '*** Contact Person for Primary Customer
    '        '' Cursor = Cursors.WaitCursor
    '        gsCompany = Trim(cboCoCde.Text)
    '        Call Update_gs_Value(gsCompany)
    '        '1
    '        gspStr = "sp_list_CUCNTINF '','" & Replace(cboCus1No.Text, "'", "''") & "','C'"
    '        rtnLong = execute_SQLStatement(gspStr, rs_CUCNTINF_C, rtnStr)
    '        If rtnLong <> RC_SUCCESS Then
    '            MsgBox("Error on loading QUM00001 sp_list_CUCNTINF_C :" & rtnStr)
    '            Exit Sub
    '        End If

    '        'If rs_CUCNTINF_C.Tables("RESULT").Rows.Count > 0 Then
    '        '    cboCus1Cp.Items.Add(rs_CUCNTINF_C.Tables("RESULT").Rows(0).Item("cci_cntctp").ToString.Trim)
    '        '    cboCus1Cp.Text = rs_CUCNTINF_C.Tables("RESULT").Rows(0).Item("cci_cntctp").ToString.Trim
    '        'End If

    '        If rs_CUCNTINF_C.Tables("RESULT").Rows.Count > 0 Then
    '            Dim dr() As DataRow = rs_CUCNTINF_C.Tables("RESULT").Select("cci_cntdef = 'Y' and cci_cnttyp = 'BUYR'")
    '            If dr.Length = 0 Then
    '                dr = Nothing
    '                dr = rs_CUCNTINF_C.Tables("RESULT").Select("cci_cntdef = 'Y' and cci_cnttyp = 'SALE'")
    '                If dr.Length = 0 Then
    '                    dr = Nothing
    '                    dr = rs_CUCNTINF_C.Tables("RESULT").Select("cci_cntdef = 'Y' and cci_cnttyp = 'SALE'")
    '                    If dr.Length = 0 Then
    '                        dr = Nothing
    '                        dr = rs_CUCNTINF_C.Tables("RESULT").Select("cci_cntdef = 'Y' and cci_cnttyp = 'MAGT'")
    '                        If dr.Length = 0 Then
    '                            dr = Nothing
    '                            dr = rs_CUCNTINF_C.Tables("RESULT").Select("cci_cntdef = 'Y'")
    '                            If dr.Length > 0 Then
    '                                cboCus1Cp.Items.Add(dr(0).Item("cci_cntctp").ToString.Trim)
    '                                display_combo(dr(0).Item("cci_cntctp").ToString.Trim, cboCus1Cp)
    '                            End If
    '                        Else
    '                            cboCus1Cp.Items.Add(dr(0).Item("cci_cntctp").ToString.Trim)
    '                            display_combo(dr(0).Item("cci_cntctp").ToString.Trim, cboCus1Cp)
    '                        End If
    '                    Else
    '                        cboCus1Cp.Items.Add(dr(0).Item("cci_cntctp").ToString.Trim)
    '                        display_combo(dr(0).Item("cci_cntctp").ToString.Trim, cboCus1Cp)
    '                    End If
    '                Else
    '                    cboCus1Cp.Items.Add(dr(0).Item("cci_cntctp").ToString.Trim)
    '                    display_combo(dr(0).Item("cci_cntctp").ToString.Trim, cboCus1Cp)
    '                End If
    '            Else
    '                cboCus1Cp.Items.Add(dr(0).Item("cci_cntctp").ToString.Trim)
    '                display_combo(dr(0).Item("cci_cntctp").ToString.Trim, cboCus1Cp)
    '            End If
    '        End If


    '        '2
    '        gspStr = "sp_select_CUBASINF_Q '" & cboCoCde.Text & "','" & Microsoft.VisualBasic.Left(cboCus1No.Text, InStr(cboCus1No.Text, " - ") - 1) & "','Contact Person'"
    '        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_CP, rtnStr)
    '        gspStr = ""

    '        '' Cursor = Cursors.Default

    '        If rtnLong <> RC_SUCCESS Then
    '            MsgBox("Error on loading cboCus1NoClick sp_select_CUBASINF_Q 1 :" & rtnStr)
    '            '' Cursor = Cursors.Default
    '            Exit Sub
    '        End If

    '        If rs_CUBASINF_CP.Tables("RESULT").Rows.Count = 0 Then       '***  Not Found Record
    '            cboCus1Cp.Enabled = False
    '        Else
    '            cboCus1Cp.Enabled = True
    '            'cboCus1Cp.Items.Clear()  'see1
    '            'cboCus1Cp.Text = ""     'see1
    '            For index As Integer = 0 To rs_CUBASINF_CP.Tables("RESULT").Rows.Count - 1
    '                If Not (cboCus1Cp.Text = rs_CUBASINF_CP.Tables("RESULT").Rows(index)("cci_cntctp").ToString.Trim) Then  'see 1
    '                    cboCus1Cp.Items.Add(rs_CUBASINF_CP.Tables("RESULT").Rows(index)("cci_cntctp").ToString)
    '                End If
    '            Next

    '            dr = rs_CUBASINF_CP.Tables("RESULT").Select("buyrY = 'BUYR - Y'")
    '            If dr.Length > 0 Then
    '                'cboCus1Cp.Text = dr(0)("cci_cntctp")
    '            End If
    '        End If

    '        '*** Secondary Customer for Primary Customer
    '        '' Cursor = Cursors.WaitCursor

    '        gsCompany = Trim(cboCoCde.Text)
    '        Call Update_gs_Value(gsCompany)

    '        gspStr = "sp_select_CUBASINF_Q '" & cboCoCde.Text & "','" & Microsoft.VisualBasic.Left(cboCus1No.Text, InStr(cboCus1No.Text, " - ") - 1) & "','Secondary'"
    '        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_S, rtnStr)
    '        gspStr = ""

    '        '' Cursor = Cursors.Default

    '        If rtnLong <> RC_SUCCESS Then
    '            MsgBox("Error on loading cboCus1NoClick sp_select_CUBASINF_Q 2 :" & rtnStr)
    '            '' Cursor = Cursors.Default
    '            Exit Sub
    '        End If

    '        If rs_CUBASINF_S.Tables("RESULT").Rows.Count = 0 Then       '***  Not Found Record
    '            cboCus2No.Enabled = False
    '            cboCus2Cp.Enabled = False
    '        Else
    '            cboCus2No.Enabled = True
    '            cboCus2No.Items.Clear()
    '            cboCus2No.Text = ""

    '            If Add_flag = True Then
    '                dr = rs_CUBASINF_S.Tables("RESULT").Select("csc_seccus >= 60000")
    '            End If

    '            If Not dr Is Nothing Then
    '                'possible bug ?
    '                'If dr.Length > 1 Then
    '                If dr.Length > 0 Then
    '                    For index As Integer = 0 To dr.Length - 1
    '                        cboCus2No.Items.Add(dr(index)("csc_seccus").ToString + " - " + dr(index)("cbi_cussna").ToString)
    '                    Next
    '                End If
    '            End If
    '        End If

    '        '*** Agent for Primary Customer
    '        '' Cursor = Cursors.WaitCursor

    '        gsCompany = Trim(cboCoCde.Text)
    '        Call Update_gs_Value(gsCompany)

    '        gspStr = "sp_select_CUBASINF_Q '" & cboCoCde.Text & "','" & Microsoft.VisualBasic.Left(cboCus1No.Text, InStr(cboCus1No.Text, " - ") - 1) & "','Agent'"
    '        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_A, rtnStr)
    '        gspStr = ""

    '        '' Cursor = Cursors.Default

    '        If rtnLong <> RC_SUCCESS Then
    '            MsgBox("Error on loading cboCus1NoClick sp_select_CUBASINF_Q 3 :" & rtnStr)
    '            '' Cursor = Cursors.Default
    '            Exit Sub
    '        End If

    '        If rs_CUBASINF_A.Tables("RESULT").Rows.Count = 0 Then       '***  Not Found Record
    '            cboCusAgt.Enabled = False
    '        Else
    '            cboCusAgt.Enabled = True
    '            cboCusAgt.Items.Clear()
    '            cboCusAgt.Text = ""
    '            For index As Integer = 0 To rs_CUBASINF_A.Tables("RESULT").Rows.Count - 1
    '                cboCusAgt.Items.Add(rs_CUBASINF_A.Tables("RESULT").Rows(index)("cai_cusagt").ToString + " - " + rs_CUBASINF_A.Tables("RESULT").Rows(index)("yai_stnam").ToString)
    '            Next

    '            dr = rs_CUBASINF_A.Tables("RESULT").Select("cai_cusdef = 'Y'")
    '            If dr.Length > 0 Then
    '                cboCusAgt.Text = dr(0)("cai_cusagt").ToString + " - " + dr(0)("yai_stnam").ToString
    '            End If
    '        End If

    '        dr = rs_CUBASINF_P.Tables("RESULT").Select("cbi_cusno = " & "'" & Microsoft.VisualBasic.Left(cboCus1No.Text, InStr(cboCus1No.Text, " - ") - 1) & "'")

    '        '*** Phase 2
    '        '*** Sales Division, Team, & Sales Rep. for Primary Customer
    '        '' Cursor = Cursors.WaitCursor

    '        gsCompany = Trim(cboCoCde.Text)
    '        Call Update_gs_Value(gsCompany)

    '        gspStr = "sp_list_SYSALREL '" & cboCoCde.Text & "'"
    '        rtnLong = execute_SQLStatement(gspStr, rs_SYSALREL, rtnStr)
    '        gspStr = ""

    '        '' Cursor = Cursors.Default

    '        If rtnLong <> RC_SUCCESS Then
    '            MsgBox("Error on loading cboCus1NoClick sp_list_SYSALREL :" & rtnStr)
    '            '' Cursor = Cursors.Default
    '            Exit Sub
    '        End If

    '        If rs_SYSALREL.Tables("RESULT").Rows.Count = 0 Then       '***  Not Found Record
    '            cboSalDiv.Enabled = False
    '            cboSalDiv.Items.Clear()
    '            cboSalDiv.Text = ""

    '            cboSalRep.Enabled = False
    '            cboSalRep.Items.Clear()
    '            cboSalRep.Text = ""
    '        Else
    '            sFilter = "ssr_saltem = " & "'" & dr(0)("cbi_saltem").ToString.Trim & "'"
    '            rs_SYSALREL.Tables("RESULT").DefaultView.RowFilter = sFilter
    '            rs_SYSALREL.Tables("RESULT").DefaultView.Sort = "ssr_saldiv, ssr_saltem"
    '            sFilter = ""

    '            If rs_SYSALREL.Tables("RESULT").DefaultView.Count = 0 Then
    '                cboSalDiv.Enabled = False
    '                cboSalDiv.Items.Clear()
    '                cboSalDiv.Text = ""

    '                cboSalRep.Enabled = False
    '                cboSalRep.Items.Clear()
    '                cboSalRep.Text = ""
    '            Else

    '                cboSalDiv.Enabled = True
    '                cboSalDiv.Items.Clear()
    '                cboSalDiv.Text = ""

    '                Dim sTmpDiv, sTmpTeam As String

    '                sTmpDiv = rs_SYSALREL.Tables("RESULT").DefaultView(0)("ssr_saldiv").ToString.Trim
    '                sTmpTeam = rs_SYSALREL.Tables("RESULT").DefaultView(0)("ssr_saltem").ToString.Trim

    '                cboSalDiv.Items.Add("")
    '                cboSalDiv.Items.Add("Division " & sTmpDiv & " (Team " & sTmpTeam & ")")

    '                If rs_SYSALREL.Tables("RESULT").DefaultView.Count > 1 Then
    '                    For index As Integer = 1 To rs_SYSALREL.Tables("RESULT").DefaultView.Count - 1
    '                        If sTmpDiv <> rs_SYSALREL.Tables("RESULT").DefaultView(index)("ssr_saldiv").ToString.Trim Or _
    '                            sTmpTeam <> rs_SYSALREL.Tables("RESULT").DefaultView(index)("ssr_saltem").ToString.Trim Then

    '                            sTmpDiv = rs_SYSALREL.Tables("RESULT").DefaultView(index)("ssr_saldiv").ToString.Trim
    '                            sTmpTeam = rs_SYSALREL.Tables("RESULT").DefaultView(index)("ssr_saltem").ToString.Trim

    '                            cboSalDiv.Items.Add("Division " & sTmpDiv & " (Team " & sTmpTeam & ")")
    '                        End If
    '                    Next

    '                    display_combo("Division " & sTmpDiv & " (Team " & sTmpTeam & ")", cboSalDiv)
    '                End If

    '                '        'Modify 2013
    '                cboSalDiv.Enabled = False
    '                cboSalRep.Enabled = True
    '                cboSalRep.Items.Clear()
    '                cboSalRep.Text = ""

    '                Dim usrname As String

    '                cboSalRep.Items.Add("")
    '                For index As Integer = 0 To rs_SYSALREL.Tables("RESULT").DefaultView.Count - 1
    '                    cboSalRep.Items.Add(rs_SYSALREL.Tables("RESULT").DefaultView(index)("ssr_usrnam").ToString.Trim & " (" & _
    '                                        rs_SYSALREL.Tables("RESULT").DefaultView(index)("ssr_salrep").ToString.Trim & ")")
    '                    If srname = rs_SYSALREL.Tables("RESULT").DefaultView(index)("ssr_salrep").ToString.Trim Then
    '                        usrname = rs_SYSALREL.Tables("RESULT").DefaultView(index)("ssr_usrnam").ToString.Trim
    '                    End If
    '                Next

    '                sFilter = "ssr_saltem = " & "'" & dr(0)("cbi_saltem").ToString.Trim & "' and " & "ssr_default = 'Y'"
    '                rs_SYSALREL.Tables("RESULT").DefaultView.RowFilter = sFilter
    '                '                    sFilter = ""

    '                If srname <> "" Then
    '                    display_combo(usrname & " (" & srname & ")", cboSalRep)
    '                Else
    '                    If rs_SYSALREL.Tables("RESULT").DefaultView.Count > 0 Then
    '                        display_combo(rs_SYSALREL.Tables("RESULT").DefaultView(0)("ssr_usrnam").ToString.Trim & " (" & _
    '                                            rs_SYSALREL.Tables("RESULT").DefaultView(0)("ssr_salrep").ToString.Trim & ")", cboSalRep)
    '                    End If
    '                End If
    '            End If
    '        End If




    '        '*** Phase 2 comment it
    '        '*** Sales Rep for Primary Customer
    '        'Cursor = Cursors.WaitCursor

    '        'gsCompany = Trim(cboCoCde.Text)
    '        'Call Update_gs_Value(gsCompany)

    '        'gspStr = "sp_select_CUBASINF_SR '" & cboCoCde.Text & "','" & dr(0)("cbi_salrep").ToString & "','" & gsUsrID & "'"
    '        'rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_SR, rtnStr)
    '        'gspStr = ""

    '        'Cursor = Cursors.Default

    '        'If rtnLong <> RC_SUCCESS Then
    '        '    MsgBox("Error on loading cboCus1NoClick sp_select_CUBASINF_SR :" & rtnStr)
    '        '   '' Cursor = Cursors.Default
    '        '    Exit Sub
    '        'End If

    '        'If rs_CUBASINF_SR.Tables("RESULT").Rows.Count = 0 Then       '***  Not Found Record
    '        '    cboSalRep.Enabled = False
    '        'Else
    '        '    cboSalRep.Enabled = True
    '        '    cboSalRep.Items.Clear()
    '        '    cboSalRep.Text = ""
    '        '    cboSalRep.Items.Add("")
    '        '    For index As Integer = 0 To rs_CUBASINF_SR.Tables("RESULT").Rows.Count - 1
    '        '        cboSalRep.Items.Add(rs_CUBASINF_SR.Tables("RESULT").Rows(index)("dsc").ToString)
    '        '    Next

    '        '    dr = rs_CUBASINF_SR.Tables("RESULT").Select("ysr_code1 = " & "'" & dr(0)("cbi_salrep").ToString & "'")
    '        '    If dr.Length > 0 Then
    '        '        cboSalRep.Text = dr(0)("dsc").ToString
    '        '    End If
    '        'End If

    '        '*** Currency Rate
    '        '*** For multi currency, assume IM Basic Price is USD
    '        strCurExRat = "0"

    '        '' Cursor = Cursors.WaitCursor

    '        gsCompany = Trim(cboCoCde.Text)
    '        Call Update_gs_Value(gsCompany)

    '        gspStr = "sp_select_CUBASINF_Curex '" & cboCoCde.Text & "','','0','','N'"
    '        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_CR, rtnStr)
    '        gspStr = ""

    '        '' Cursor = Cursors.Default

    '        If rtnLong <> RC_SUCCESS Then
    '            MsgBox("Error on loading cboCus1NoClick sp_select_CUBASINF_Curex :" & rtnStr)
    '            '' Cursor = Cursors.Default
    '            Exit Sub
    '        End If

    '        If rs_CUBASINF_CR.Tables("RESULT").Rows.Count = 0 Then       '***  Not Found Record
    '            MsgBox("No Currency in System")
    '        End If

    '        '*** Change Customer to re-calcualte all the standard price
    '        If last_cust <> "" Then
    '            If last_cust <> cboCus1No.Text Then
    '                Call reset_Detail()
    '            End If
    '        End If
    '        last_cust = cboCus1No.Text
    '    End If
    'End Sub


    Private Function save_QUCPTBKD() As Boolean

        save_QUCPTBKD = False

        Dim QCB_COCDE As String
        Dim QCB_QUTNO As String
        Dim QCB_QUTSEQ As String
        Dim QCB_ITMNO As String
        Dim QCB_CPTSEQ As String
        Dim QCB_CPT As String
        Dim QCB_CURCDE As String
        Dim QCB_CST As String
        Dim QCB_CSTPCT As String
        Dim QCB_PCT As String
        Dim QCB_CREUSR As String

        Dim i As Integer



        gsCompany = Trim(strNewCocde)
        Call Update_gs_Value(gsCompany)

        gspStr = "sp_select_QUCPTBKD '" & strNewCocde & "','" & ma.txtQutNo.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_QUCPTBKD, rtnStr)
        gspStr = ""

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading txtQutNoKeyPress sp_select_QUCPTBKD :" & rtnStr)
            Exit Function
        End If

        For i2 As Integer = 0 To rs_QUCPTBKD.Tables("RESULT").Columns.Count - 1
            rs_QUCPTBKD.Tables("RESULT").Columns(i2).ReadOnly = False
        Next i2

        'If rs_QUCPTBKD.Tables("RESULT").Rows.Count > 0 Then
        '    If txtSeq.Text <> "" Then
        '        sFilter = "qcb_qutseq = " & txtSeq.Text
        '    Else
        '        sFilter = "qcb_qutseq = ''"
        '    End If

        '    rs_QUCPTBKD.Tables("RESULT").DefaultView.RowFilter = sFilter
        '    dgMatBkd.DataSource = rs_QUCPTBKD.Tables("RESULT").DefaultView
        '           Call display_Component()
        'End If



        For i = 0 To rs_QUCPTBKD.Tables("RESULT").Rows.Count - 1
            QCB_COCDE = rs_QUCPTBKD.Tables("RESULT").Rows(i).Item("qcb_cocde")
            QCB_QUTNO = rs_QUCPTBKD.Tables("RESULT").Rows(i).Item("qcb_qutno")
            QCB_QUTSEQ = rs_QUCPTBKD.Tables("RESULT").Rows(i).Item("qcb_qutseq")
            QCB_ITMNO = rs_QUCPTBKD.Tables("RESULT").Rows(i).Item("qcb_itmno")
            QCB_CPTSEQ = rs_QUCPTBKD.Tables("RESULT").Rows(i).Item("qcb_cptseq")
            QCB_CPT = rs_QUCPTBKD.Tables("RESULT").Rows(i).Item("qcb_cpt")
            QCB_CURCDE = rs_QUCPTBKD.Tables("RESULT").Rows(i).Item("qcb_curcde")
            QCB_CST = rs_QUCPTBKD.Tables("RESULT").Rows(i).Item("qcb_cst")
            QCB_CSTPCT = rs_QUCPTBKD.Tables("RESULT").Rows(i).Item("qcb_cstpct")
            QCB_PCT = rs_QUCPTBKD.Tables("RESULT").Rows(i).Item("qcb_pct")
            QCB_CREUSR = rs_QUCPTBKD.Tables("RESULT").Rows(i).Item("qcb_creusr")


            QCB_CREUSR = "~*ADD*~"


            If QCB_CREUSR = "~*DEL*~" Then
                gspStr = "sp_physical_delete_QUCPTBKD '" & QCB_COCDE & "','" & QCB_QUTNO & "','" & QCB_QUTSEQ & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_QUCPTBKD sp_physical_delete_QUCPTBKD:" & rtnStr)
                    save_QUCPTBKD = False
                    Exit Function
                End If
            ElseIf QCB_CREUSR = "~*ADD*~" Or QCB_CREUSR = "~*NEW*~" Then
                gspStr = "sp_insert_QUCPTBKD '" & QCB_COCDE & "','" & Trim(txtQutNo2.Text) & "','" & QCB_QUTSEQ & "','" & QCB_ITMNO & "','" & QCB_CPTSEQ & "','" & _
                                                        QCB_CPT & "','" & QCB_CURCDE & "','" & QCB_CST & "','" & QCB_CSTPCT & "','" & CInt(QCB_PCT) & "','" & gsUsrID & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_QUCPTBKD sp_insert_QUCPTBKD:" & rtnStr)
                    save_QUCPTBKD = False
                    Exit Function
                End If
            ElseIf QCB_CREUSR = "~*UPD*~" Then
                gspStr = "sp_update_QUCPTBKD '" & QCB_COCDE & "','" & QCB_QUTNO & "','" & QCB_QUTSEQ & "','" & QCB_ITMNO & "','" & QCB_CPTSEQ & "','" & _
                                                        QCB_CPT & "','" & QCB_CURCDE & "','" & QCB_CST & "','" & QCB_CSTPCT & "','" & QCB_PCT & "','" & gsUsrID & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_QUCPTBKD sp_update_QUCPTBKD:" & rtnStr)
                    save_QUCPTBKD = False
                    Exit Function
                End If
            End If
        Next i
        save_QUCPTBKD = True
    End Function



    Private Sub calculate_gbPandelCstEmt_adjprc(ByVal qutseq As Integer)
        Dim i As Integer
        i = 0

        Dim loc As Integer
        loc = -1

        For i = 0 To rs_QUOTNDTL.Tables("RESULT").Rows.Count - 1
            If rs_QUOTNDTL.Tables("RESULT").Rows(i).Item("qud_qutseq") = qutseq Then
                loc = i
            End If
        Next i

        If loc = -1 Then
            Exit Sub
        End If

        Dim calBasicPrice As Decimal

        'Dim calMarkup_Org As Decimal
        'Dim calMarkup_Usr As Decimal

        Dim calPckCstAmt As Decimal
        Dim calCommPer As Decimal
        Dim calCommAmt As Decimal

        Dim calCURounding As Integer

        Dim calAdjustedPrice As Decimal


        ' StdPrc = BP * MU Org = MU Prc Org + PckCst Amt * CommPer + CommAmt
        ' AdjPrc = BP * MU Usr = MU Prc Usr + PckCst Amt * CommPer + CommAmt
        calBasicPrice = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_basprc")
        calAdjustedPrice = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_cus1dp")

        calPckCstAmt = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_pkgper")
        calCommPer = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_comper")
        calCommAmt = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_icmper")

        calCURounding = cus1_rounding 'temporary hard code : used in Standard Price and Adjusted Price

        '' ''1. Calculate Markup Price
        Dim resMarkupPrice As Decimal

        ' ''resMarkupPrice = (calAdjustedPrice * (1 - (calCommPer / 100))) - calPckCstAmt

        '' ''2. Calculate Markup %
        Dim resMarkup_Usr As Decimal

        'resMarkup_Usr = round((1 + calPckCstAmt - calBasicPrice / ((calAdjustedPrice - calCommAmt) * (1 - calCommPer / 100))), calCURounding)
        If calAdjustedPrice = 0 Then
            resMarkup_Usr = 0
            resMarkupPrice = 0
        Else
            If ((calAdjustedPrice - calCommAmt) * (1 - calCommPer / 100) - calPckCstAmt) <> 0 Then
                resMarkup_Usr = round(100 * (1 - calBasicPrice / ((calAdjustedPrice - calCommAmt) * (1 - calCommPer / 100) - calPckCstAmt)), calCURounding)
            End If


            If (1 - resMarkup_Usr / 100) <> 0 Then
                resMarkupPrice = round(calBasicPrice / (1 - resMarkup_Usr / 100), calCURounding)
            End If
        End If


        ' ''If resMarkupPrice = 0 Then
        ' ''    resMarkup_Usr = 0
        ' ''Else
        ' ''    resMarkup_Usr = round((1 - (calBasicPrice / resMarkupPrice)) * 100, 4)
        ' ''End If

        ''???
        ''        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_muprc") = resMarkupPrice
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_muprc") = resMarkupPrice
        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qpe_mu") = resMarkup_Usr


        '4 Calculate Sample Price
        Dim strUM As String
        Dim samplePrice As Decimal
        Dim itmtyp As String
        Dim umftr As Decimal

        strUM = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_untcde")
        gspStr = "sp_select_CUBASINF_Q '','" & strUM & "','Conversion'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYCONFTR, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading calculate_gbPandelCstEmt sp_select_CUBASINF_Q :" & rtnStr)
            Exit Sub
        End If

        If rs_SYCONFTR.Tables("RESULT").Rows.Count = 0 Then
            samplePrice = Format(round(calAdjustedPrice, calCURounding), "###,###,##0.0000")
        Else
            samplePrice = Format(round(calAdjustedPrice / rs_SYCONFTR.Tables("RESULT").Rows(0)("ycf_value"), calCURounding), "###,###,##0.0000")
        End If

        itmtyp = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_itmtyp")

        If itmtyp = "ASS" Then
            If Not IsNumeric(rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_conftr")) Then
                umftr = 1
            Else
                umftr = rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_conftr")
            End If

            samplePrice = Format(round(calAdjustedPrice / umftr, calCURounding), "###,###,##0.0000")
        End If

        rs_QUOTNDTL.Tables("RESULT").Rows(loc).Item("qud_smpprc") = samplePrice


    End Sub
    Private Sub dgValid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgValid.CellClick
        '''101
        If dgValid.CurrentCell.ColumnIndex = 101 Then

            comboBoxCell(dgValid, "TransTerm")

        End If


    End Sub



    Private Sub comboBoxCell(ByVal dgv As DataGridView, ByVal typ As String)
        Dim cboCell As New DataGridViewComboBoxCell
        Dim iCol As Integer = dgv.CurrentCell.ColumnIndex
        Dim iRow As Integer = dgv.CurrentCell.RowIndex

        Dim row As DataGridViewRow = dgv.CurrentRow
        'dgv.Rows(iRow).Cells(iCol).ReadOnly = True
        Dim i As Integer

        Select Case typ
            Case "TransTerm"
                cboCell.Items.Add("")
                'For i = 0 To rs_QUOTNDTL_copy.Tables("RESULT").Rows.Count - 1
                '    cboCell.Items.Add(rs_QUOTNDTL_copy.Tables("RESULT").Rows(i).Item("imu_trantrm"))
                'Next i

                cboCell.Items.Add("FCL")
                cboCell.Items.Add("LCL")
                cboCell.Items.Add("LCL13")
                cboCell.Items.Add("LCL20")
                cboCell.Items.Add("LCL28")
                cboCell.Items.Add("LCL33")
                cboCell.Items.Add("LCL5")
                cboCell.Items.Add("LCL50")
                cboCell.Items.Add("LCL63")
                cboCell.Items.Add("LCL7")

        End Select

        'cboCell.DropDownWidth = 150
        cboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox

        dgv.Rows(iRow).Cells(iCol) = cboCell
        dgv.Rows(iRow).Cells(iCol).ReadOnly = False
    End Sub


    Private Sub dgValid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgValid.CellContentClick

    End Sub

    Public Function revisedItmno(ByVal itmNo As String) As String
        '*** The objective of this function is to replace any "/" or " /" in
        '*** an item number with an "_"
        '*** converting format of item no:
        itmNo = Replace(itmNo, " /", "_")
        itmNo = Replace(itmNo, "/", "_")
        itmNo = Replace(itmNo, "-", "_")
        itmNo = Replace(itmNo, " ", "")
        revisedItmno = itmNo
    End Function

    Public Function SearchImgPath(ByVal itmNo As String) As String
        '*** The objective of this function is to search for the sub-directory
        '*** of an item image.  This sub-directory is defined as the first 3
        '*** characters of a "revised" item number
        '*** converting format of the item no:
        itmNo = revisedItmno(itmNo)
        '*** Take the first 3 characters of the item no.
        SearchImgPath = Microsoft.VisualBasic.Left(itmNo, 8)
    End Function

End Class
