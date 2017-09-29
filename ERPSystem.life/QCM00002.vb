Imports System.Collections
Imports System.Net.Mail


Public Class QCM00002
    Public Recordstatus As Boolean

    Public save_mode As String = "UPD" 'ADD, UPD
    Dim stage As String = "INIT"



    Public ma_QCM00004 As QCM00004 'This should be declared in QCM00004


    Dim frm_QCM00001 As QCM00001

    'Core
    Public rs_QCM00002 As DataSet
    Private rs_QCM00002_ADD As DataSet
    Public rs_QCM00002Hdr As DataSet
    Public rs_QCM00002Dtl As DataSet
    Public rs_QCM00002Dtl_2 As DataSet
    Private rs_QCM00002Hdr_ADD As DataSet
    Public rs_QCM00002_QCPODTL As DataSet
    Public rs_QCM00002_QCPODTL_ALLDTL As DataSet
    Private rs_QCM00002_QCPODTL_ADD As DataSet

    'Info
    Public rs_QCM00002_VNCNTINF_Q As DataSet    'Vendor Addr
    Public rs_QCM00002_VNCNTINF_QCFA As DataSet 'Vendor Contact
    Dim rs_VNCNTINF As DataSet
    Public rs_email As DataSet

    Dim rs As New DataSet

    Dim rs_CUBASINF_P As DataSet
    Dim rs_CUBASINF_S As DataSet
    Dim rs_CUBASINF_S_All As DataSet
    Dim rs_VNBASINF As DataSet
    Dim sHdrPriCust As String
    Dim sHdrSecCust As String
    Dim sHdrVendor As String

    Dim Pointer_CurPOSeq As Integer = 0 'QCPOHeader
    Dim Pointer_CurQCseq As Integer = 0 'QCDetail

    Dim dtl_mapping As New Hashtable()
    Dim itmdtl_mapping As New Hashtable()
    Dim dtl_upditm As New Hashtable()
    Dim hdrVen_mapping As New Hashtable()
    Dim page2_mapping As New Hashtable()


    Dim dg_POHeader_mapping As New Hashtable()
    Dim dg_POHeaderView As DataView
    Dim tbl_POHeader As DataTable

    Dim dg_Summary_mapping As New Hashtable()
    Dim dg_SummaryView As DataView
    Dim tbl_Summary As DataTable
    Dim today As DateTime = Date.Today


#Region "Mapping of sql_col & form obj"
    Private Sub Init_HdrMapping()
        'hdrVen_mapping.Add("vci_adr", "cboVenAddr")
        hdrVen_mapping.Add("qvi_adr", "txtRemAddr")
        hdrVen_mapping.Add("qvi_stt", "txtStt")
        hdrVen_mapping.Add("qvi_cty", "txtCty")
        hdrVen_mapping.Add("qvi_city", "txtCity")
        hdrVen_mapping.Add("qvi_town", "txtTown")
        hdrVen_mapping.Add("qvi_zip", "txtPst")


        hdrVen_mapping.Add("qvi_cntctp", "txtcntctp")
        hdrVen_mapping.Add("qvi_cntphn", "txtcntphn")

    End Sub

    Private Sub Init_POHdrMapping()
        'POORDHDR
        page2_mapping.Add("poh_cocde", "cboCoCde_page2")
        page2_mapping.Add("poh_purord", "txtPONo_page2")
        page2_mapping.Add("poh_ordno", "txtOrdNo_page2")        'SC No
        page2_mapping.Add("poh_credat", "DTDPOISS_page2")
        page2_mapping.Add("poh_issdat", "DTDPOREV_page2")
        page2_mapping.Add("poh_venno", "txtVendor_page2")
        page2_mapping.Add("poh_cuspno", "txtCusPno_page2")
        page2_mapping.Add("poh_reppno", "txtRepPno_page2")
        page2_mapping.Add("poh_shpstr", "txtShpStr_page2")
        page2_mapping.Add("poh_shpend", "txtShpEnd_page2")
        page2_mapping.Add("poh_rmk", "txtHRmk_page2")           'POORDHDR Rmk
    End Sub

    Private Sub Init_dg_POHeader()
        'Init Mapping
        dg_POHeader_mapping.Add("qpd_purord", "PO No")
        dg_POHeader_mapping.Add("qch_inspyear", "Year")
        dg_POHeader_mapping.Add("view_inspweek", "Week")
        'dg_POHeader_mapping.Add("qch_inspweek", "Week")
        dg_POHeader_mapping.Add("qpd_mon", "Mon")
        dg_POHeader_mapping.Add("qpd_tue", "Tue")
        dg_POHeader_mapping.Add("qpd_wed", "Wed")
        dg_POHeader_mapping.Add("qpd_thur", "Thur")
        dg_POHeader_mapping.Add("qpd_fri", "Fri")
        dg_POHeader_mapping.Add("qpd_sat", "Sat")
        dg_POHeader_mapping.Add("qpd_sun", "Sun")

        dg_POHeader_mapping.Add("view_prmcus", "Pri Cust.")
        dg_POHeader_mapping.Add("view_seccus", "Sec Cust.")
        dg_POHeader_mapping.Add("poh_cuspno", "Customer PO")
        dg_POHeader_mapping.Add("view_vensna", "Factory")
        'dg_POHeader_mapping.Add("poh_prmcus", "Pri Cust.")
        'dg_POHeader_mapping.Add("poh_seccus", "Sec Cust.")
        'dg_POHeader_mapping.Add("qch_insptyp", "Insp. Typ")


    End Sub

    'With PO Or Without PO Mapping
    Private Sub Init_dtlMapping()
        'POORDHDR
        dtl_mapping.Add("qcd_cocde", "cboCoCde_page3")
        dtl_mapping.Add("poh_purord", "txtPONo")
        dtl_mapping.Add("poh_ordno", "txtOrdNo")        'SC No
        'dtl_mapping.Add("poh_pursts", "
        dtl_mapping.Add("poh_credat", "DTDPOISS")
        dtl_mapping.Add("poh_issdat", "DTDPOREV")
        dtl_mapping.Add("poh_venno", "txtVendor")
        dtl_mapping.Add("poh_cuspno", "txtCusPno")
        dtl_mapping.Add("poh_reppno", "txtRepPno")
        dtl_mapping.Add("poh_shpstr", "txtShpStr")
        dtl_mapping.Add("poh_shpend", "txtShpEnd")
        dtl_mapping.Add("poh_rmk", "txtHRmk")           'POORDHDR Rmk

        'POORRDTL
        dtl_mapping.Add("pod_purseq", "txtPurSeq")      'PO Seq
        'dtl_mapping.Add("pod_itmno", "txtItmNo")        'ItemNo
        dtl_mapping.Add("view_itmno", "txtItmNo")
        dtl_mapping.Add("pod_jobord", "txtJobOrd")
        dtl_mapping.Add("pod_prdven", "txtPrdVen")      'PV
        dtl_mapping.Add("pod_tradeven", "txtTradeVen")  'TV
        dtl_mapping.Add("pod_examven", "txtExamVen")    'FA
        dtl_mapping.Add("pod_venitm", "txtVenItm")      'VenItm
        dtl_mapping.Add("pod_cusitm", "txtCusItm")      'CusItm
        dtl_mapping.Add("pod_seccusitm", "txtSecCusItm")
        dtl_mapping.Add("pod_cussku", "txtCusSku")
        dtl_mapping.Add("pod_engdsc", "txtEngDsc")
        dtl_mapping.Add("pod_chndsc", "txtChnDsc")
        dtl_mapping.Add("pod_vencol", "txtVenCol")
        dtl_mapping.Add("pod_cuscol", "txtCusCol")
        dtl_mapping.Add("pod_coldsc", "txtColDsc")
        dtl_mapping.Add("pod_pckitr", "txtPckItr")
        dtl_mapping.Add("pod_untcde", "txtUntCde")
        dtl_mapping.Add("pod_inrctn", "txtInrCtn")
        dtl_mapping.Add("pod_mtrctn", "txtMtrCtn")
        dtl_mapping.Add("pod_cubcft", "txtCubCft")
        dtl_mapping.Add("pod_ordqty", "txtOrdQty")
        dtl_mapping.Add("pod_cuspno", "txtDCusPno")
        dtl_mapping.Add("pod_respno", "txtDResPno")
        dtl_mapping.Add("pod_candat", "DTDPOCan")
        dtl_mapping.Add("pod_shpstr", "DTDShpStr")
        dtl_mapping.Add("pod_shpend", "DTDShpEnd")
        dtl_mapping.Add("pod_ctnstr", "txtCtnStr")
        dtl_mapping.Add("pod_ctnend", "txtCtnEnd")
        dtl_mapping.Add("pod_ttlctn", "txtTtlCtn")


        'QCREQDTL
        dtl_mapping.Add("qcd_qcseq", "txtQCSeq")
        dtl_mapping.Add("qch_inspyear", "txtDInspYear")
        dtl_mapping.Add("qcd_dtlsts", "cbo_dtlsts")
        dtl_mapping.Add("qcd_schdat", "DTDSchInspDat")
        'dtl_mapping.Add("qcd_mon", "chk_qcd_mon")
        'dtl_mapping.Add("qcd_tue", "chk_qcd_tue")
        'dtl_mapping.Add("qcd_wed", "chk_qcd_wed")
        'dtl_mapping.Add("qcd_thur", "chk_qcd_thur")
        'dtl_mapping.Add("qcd_fri", "chk_qcd_fri")
        'dtl_mapping.Add("qcd_sat", "chk_qcd_sat")
        'dtl_mapping.Add("qcd_sun", "chk_qcd_sun")
        'dtl_mapping.Add("qcd_sidate", "txt_qcd_sidate")
        'dtl_mapping.Add("qcd_cydate", "txt_qcd_cydate")
        dtl_mapping.Add("qcd_rmk", "txtDRmk")
        dtl_mapping.Add("DEL", "chkDelete")

        itmdtl_mapping.Add("qcd_xitmno", "txt_ItmNo")
        itmdtl_mapping.Add("qcd_xitmdsc", "txt_ItmDesc")
        itmdtl_mapping.Add("qcd_xcolor", "txt_Color")
        itmdtl_mapping.Add("qcd_xpack", "txt_PackInstruction")
        itmdtl_mapping.Add("qcd_xmtrdcm", "txtMtrdcm")
        itmdtl_mapping.Add("qcd_xmtrwcm", "txtMtrwcm")
        itmdtl_mapping.Add("qcd_xmtrhcm", "txtMtrhcm")
        itmdtl_mapping.Add("qcd_xinrdcm", "txtInrdcm")
        itmdtl_mapping.Add("qcd_xinrwcm", "txtInrwcm")
        itmdtl_mapping.Add("qcd_xinrhcm", "txtInrhcm")
        itmdtl_mapping.Add("qcd_xgrswgt", "txt_GrossW")
        itmdtl_mapping.Add("qcd_xnetwgt", "txt_NetW")
        itmdtl_mapping.Add("qcd_ordqty", "txt_Ordqty")



    End Sub



    Private Sub Init_SummaryMapping()
        dg_Summary_mapping.Add("DEL", "DEL")
        dg_Summary_mapping.Add("qcd_qcseq", "QC Seq")
        dg_Summary_mapping.Add("qcd_purord", "PO NO")
        dg_Summary_mapping.Add("qcd_purseq", "PO Seq")
        dg_Summary_mapping.Add("view_itmno", "Itm No")
        dg_Summary_mapping.Add("pod_cusitm", "Customer item #")
        dg_Summary_mapping.Add("view_cuspno", "Customer PO #")
        dg_Summary_mapping.Add("qcd_mon", "Mon")
        dg_Summary_mapping.Add("qcd_tue", "Tue")
        dg_Summary_mapping.Add("qcd_wed", "Wed")
        dg_Summary_mapping.Add("qcd_thur", "Thur")
        dg_Summary_mapping.Add("qcd_fri", "Fri")
        dg_Summary_mapping.Add("qcd_sat", "Sat")
        dg_Summary_mapping.Add("qcd_sun", "Sun")

        '20151028 Add
        dg_Summary_mapping.Add("view_prmcus", "Pri. Cust")
        dg_Summary_mapping.Add("view_seccus", "Sec. Cust")
        dg_Summary_mapping.Add("view_vensna", "Factory")
        dg_Summary_mapping.Add("view_inspweek", "Week")
    End Sub

    Dim dayList As String() = {"mon", "tue", "wed", "thur", "fri", "sat", "sun"}
#End Region

    Private Sub Init_RS()
        gspStr = "sp_select_QCM00002Hdr '','Y','',''"
        rtnLong = execute_SQLStatement(gspStr, rs_QCM00002Hdr_ADD, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading sp_select_QCM0002Hdr:" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_select_QCM00002 '','Y',''"
        rtnLong = execute_SQLStatement(gspStr, rs_QCM00002_ADD, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading sp_select_QCM0002:" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_select_QCM00002_QCPODTL '', 'Y', ''"
        rtnLong = execute_SQLStatement(gspStr, rs_QCM00002_QCPODTL_ADD, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading sp_select_QCM00002_QCPODTL:" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_select_QCM00002_VNCNTINF_Q '',''"
        rtnLong = execute_SQLStatement(gspStr, rs_QCM00002_VNCNTINF_Q, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading sp_select_QCM00002_VNCNTINF_Q:" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_select_QCM00002_VNCNTINF_QCFA '', ''"
        rtnLong = execute_SQLStatement(gspStr, rs_QCM00002_VNCNTINF_QCFA, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading sp_select_QCM00002_VNCNTINF_QCFA:" & rtnStr)
            Exit Sub
        End If


        For i As Integer = 0 To rs_QCM00002_ADD.Tables("RESULT").Columns.Count - 1
            rs_QCM00002_ADD.Tables("RESULT").Columns(i).ReadOnly = False
        Next
        rs_QCM00002 = rs_QCM00002_ADD.Clone()


        For i As Integer = 0 To rs_QCM00002_QCPODTL_ADD.Tables("RESULT").Columns.Count - 1
            rs_QCM00002_QCPODTL_ADD.Tables("RESULT").Columns(i).ReadOnly = False
        Next
        rs_QCM00002_QCPODTL = rs_QCM00002_QCPODTL_ADD.Clone()



        For i As Integer = 0 To rs_QCM00002Hdr_ADD.Tables("RESULT").Columns.Count - 1
            rs_QCM00002Hdr_ADD.Tables("RESULT").Columns(i).ReadOnly = False
        Next
        rs_QCM00002Hdr = rs_QCM00002Hdr_ADD.Clone

    End Sub


#Region "QCM00001 Related"
    Private Function Init_QCM00001()
        '20151023 - Disable Checking
        'If Not check_InspTyp() Then
        '    Exit Function
        'End If

        frm_QCM00001 = New QCM00001
        frm_QCM00001.ma = Me
        frm_QCM00001.str_typ = If(opt_typ1.Checked, "PO", "ITM")
        frm_QCM00001.ShowDialog()
    End Function

    Public Sub InsertRowsFrom_QCM00001(ByVal insertrows As DataRow())
        Dim Hdrtbl As DataTable = rs_QCM00002Hdr.Tables("RESULT")
        Dim POtbl As DataTable = rs_QCM00002_QCPODTL.Tables("RESULT")
        Dim Dtltbl As DataTable = rs_QCM00002.Tables("RESULT")
        Dim POtblALL As DataTable = rs_QCM00002_QCPODTL_ALLDTL.Tables("RESULT") 'For calculate new qcposeq


        Dim flg_havedetail As Boolean = If(Dtltbl.Rows.Count > 0, True, False)    'Different handle if no Dtl rows
        Dim QCWeekDay As WeekDay = New WeekDay()




        For i As Integer = 0 To insertrows.Length - 1
            Dim tmprows As DataRow() = POtbl.Select("qpd_purord = '" + insertrows(i).Item("PO No") + "'")


            Dim POWeekDay As WeekDay = New WeekDay()


            'Create new QCPORDTL row
            If tmprows.Length = 0 Then
                Dim qpd_qcposeq As Integer ' = POtbl.Rows(POtbl.Rows.Count - 1).Item("qpd_qcposeq") + 1
                Dim qpd_ctrlstate As String = "ADD"
                Dim qpd_del As String = ""
                'PO Not Exist , Create new QCPORDTL row
                Dim tmp_max As Integer
                tmp_max = 1
                For ii As Integer = 0 To POtblALL.Rows.Count - 1
                    If POtblALL.Rows(ii).Item("qpd_qcposeq") >= tmp_max Then
                        tmp_max = POtblALL.Rows(ii).Item("qpd_qcposeq") + 1
                    End If
                Next
                qpd_qcposeq = tmp_max




                Dim newPORow As DataRow = POtbl.NewRow()
                Dim newPOALLRow As DataRow = POtblALL.NewRow()
                gspStr = "sp_select_QCM00002_POORDHDR '" & Hdrtbl.Rows(0).Item("qch_cocde") & "','" & _
                    insertrows(i).Item("PO No") & "'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    Cursor = Cursors.Default
                    MsgBox("Error on loading sp_select_QCM00002_POORDHDR:" & rtnStr)
                    Exit Sub
                End If

                Dim tmp_tbl As DataTable = rs.Tables("RESULT")

                newPORow.Item("qpd_cocde") = Hdrtbl.Rows(0).Item("qch_cocde")
                newPORow.Item("qch_inspyear") = Hdrtbl.Rows(0).Item("qch_inspyear")
                newPORow.Item("qch_inspweek") = Hdrtbl.Rows(0).Item("qch_inspweek")
                newPORow.Item("qch_insptyp") = Hdrtbl.Rows(0).Item("qch_insptyp")

                newPORow.Item("qpd_qcno") = Hdrtbl.Rows(0).Item("qch_qcno")
                newPORow.Item("qpd_qcposeq") = qpd_qcposeq
                newPORow.Item("qpd_purord") = insertrows(i).Item("PO No")
                newPORow.Item("qpd_ctrlstate") = qpd_ctrlstate
                newPORow.Item("qpd_del") = qpd_del

                'not correct need to change??
                newPORow.Item("qpd_mon") = insertrows(i).Item("Mon")
                newPORow.Item("qpd_tue") = insertrows(i).Item("Tue")
                newPORow.Item("qpd_wed") = insertrows(i).Item("Wed")
                newPORow.Item("qpd_thur") = insertrows(i).Item("Thur")
                newPORow.Item("qpd_fri") = insertrows(i).Item("Fri")
                newPORow.Item("qpd_sat") = insertrows(i).Item("Sat")
                newPORow.Item("qpd_sun") = insertrows(i).Item("Sun")

                newPORow.Item("view_vensna") = Split(cboHVenno.Text, " - ")(1)
                newPORow.Item("view_prmcus") = insertrows(i).Item("pricust_r")
                newPORow.Item("view_seccus") = insertrows(i).Item("seccust_r")


                Dim tmptbl_collist As String() = { _
                    "poh_cocde", "poh_purord", "poh_ordno", "poh_ordno", _
                    "poh_credat", _
                    "poh_issdat", _
                    "poh_venno", "poh_cuspno", "poh_reppno", _
                    "poh_shpstr", _
                    "poh_shpend", _
                    "poh_rmk", _
                    "qpd_act", _
                    "poh_prmcus", _
                    "poh_seccus" _
                }

                For j As Integer = 0 To tmptbl_collist.Length - 1
                    'newPORow.Item(tmptbl_collist(i)) = newPORow.Item(tmptbl_collist(i))
                    newPORow.Item(tmptbl_collist(j)) = tmp_tbl.Rows(0).Item(tmptbl_collist(j))
                Next
                For j As Integer = 0 To rs_QCM00002_QCPODTL_ALLDTL.Tables("RESULT").Columns.Count - 1
                    'newPORow.Item(tmptbl_collist(i)) = newPORow.Item(tmptbl_collist(i))
                    newPOALLRow.Item(j) = newPORow.Item(j)
                Next
                POtbl.Rows.Add(newPORow)
                POtblALL.Rows.Add(newPOALLRow)
            End If

            'Create QCREQDTL row
            Dim newQCDtl As DataRow = Dtltbl.NewRow()
            gspStr = "sp_select_QCM00002_POORDDTL '" & Hdrtbl.Rows(0).Item("qch_cocde") & "','" & _
                insertrows(i).Item("PO No") & "','" & _
                insertrows(i).Item("PO_Seq") & "'"

            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Cursor = Cursors.Default
                MsgBox("Error on loading sp_select_QCM00002_POORDDTL:" & rtnStr)
                Exit Sub
            End If

            Dim qcd_qcseq As Integer ' = Dtltbl.Rows(Dtltbl.Rows.Count - 1).Item("qcd_qcseq") + 1
            Dim qcd_dtlsts As String = "OPE"
            Dim qcd_flgpolink As String = "Y"
            Dim qcd_qcposeq As Integer = POtbl.Select("qpd_purord='" & insertrows(i).Item("PO No") + "'")(0).Item("qpd_qcposeq")
            Dim qcd_ctrlstate As String = "ADD"
            Dim qcd_DEL As String = ""

            qcd_qcseq = If(Dtltbl.Rows.Count = 0, 1, Dtltbl.Rows(Dtltbl.Rows.Count - 1).Item("qcd_qcseq") + 1)




            'newQCDtl.Item("qch_venno") = Hdrtbl.Rows(0).Item("qch_venno")
            'newQCDtl.Item("qch_prmcus") = Hdrtbl.Rows(0).Item("qch_prmcus")
            'newQCDtl.Item("qch_seccus") = Hdrtbl.Rows(0).Item("qch_seccus")
            newQCDtl.Item("qch_inspyear") = Hdrtbl.Rows(0).Item("qch_inspyear")
            newQCDtl.Item("qch_inspweek") = Hdrtbl.Rows(0).Item("qch_inspweek")
            newQCDtl.Item("qch_insptyp") = Hdrtbl.Rows(0).Item("qch_insptyp")


            newQCDtl.Item("qcd_cocde") = Hdrtbl.Rows(0).Item("qch_cocde")
            newQCDtl.Item("qcd_qcno") = Hdrtbl.Rows(0).Item("qch_qcno")
            newQCDtl.Item("qcd_qcseq") = qcd_qcseq
            newQCDtl.Item("qcd_dtlsts") = qcd_dtlsts
            newQCDtl.Item("qcd_genby") = insertrows(i).Item("GenBy")
            newQCDtl.Item("qcd_flgpolink") = qcd_flgpolink
            newQCDtl.Item("qcd_qcposeq") = qcd_qcposeq
            newQCDtl.Item("qcd_purord") = insertrows(i).Item("PO No")
            newQCDtl.Item("qcd_purseq") = insertrows(i).Item("PO_Seq")
            newQCDtl.Item("qcd_mon") = insertrows(i).Item("Mon")
            newQCDtl.Item("qcd_tue") = insertrows(i).Item("Tue")
            newQCDtl.Item("qcd_wed") = insertrows(i).Item("Wed")
            newQCDtl.Item("qcd_thur") = insertrows(i).Item("Thur")
            newQCDtl.Item("qcd_fri") = insertrows(i).Item("Fri")
            newQCDtl.Item("qcd_sat") = insertrows(i).Item("Sat")
            newQCDtl.Item("qcd_sun") = insertrows(i).Item("Sun")
            newQCDtl.Item("qcd_samhdl") = insertrows(i).Item("Sample")
            'newQCDtl.Item("qcd_sidate") = insertrows(i).Item("SI Date")
            'newQCDtl.Item("qcd_cydate") = insertrows(i).Item("CY Date")
            newQCDtl.Item("qcd_rmk") = insertrows(i).Item("Remark")

            newQCDtl.Item("qcd_ctrlstate") = qcd_ctrlstate
            newQCDtl.Item("DEL") = qcd_DEL

            newQCDtl.Item("qcd_samhdl") = insertrows(i).Item("Sample")


            newQCDtl.Item("qcd_xitmno") = ""
            newQCDtl.Item("qcd_xitmdsc") = ""
            newQCDtl.Item("qcd_xcolor") = ""
            newQCDtl.Item("qcd_xpack") = ""
            newQCDtl.Item("qcd_xmtrdcm") = 0
            newQCDtl.Item("qcd_xmtrwcm") = 0
            newQCDtl.Item("qcd_xmtrhcm") = 0
            newQCDtl.Item("qcd_xinrdcm") = 0
            newQCDtl.Item("qcd_xinrwcm") = 0
            newQCDtl.Item("qcd_xinrhcm") = 0
            newQCDtl.Item("qcd_xgrswgt") = 0
            newQCDtl.Item("qcd_xnetwgt") = 0
            newQCDtl.Item("qcd_ordqty") = 0
            '******IMPORTANT********: Remember to add new column according


            Dim tmpcollist As String() = { _
                "poh_purord", _
                "poh_ordno", _
                "poh_pursts", _
                "poh_credat", _
                "poh_issdat", _
                "poh_venno", _
                "poh_cuspno", "poh_reppno", _
                "poh_shpstr", _
                "poh_shpend", _
                "poh_rmk", _
 _
                "pod_purseq", _
                "pod_itmno", _
                "pod_jobord", _
                "pod_prdven", "pod_tradeven", "pod_examven", _
                "pod_venitm", "pod_cusitm", "pod_seccusitm", "pod_cussku", _
                "pod_engdsc", "pod_chndsc", _
                "pod_vencol", "pod_cuscol", "pod_coldsc", "pod_pckitr", _
 _
                "pod_untcde", "pod_inrctn", "pod_mtrctn", "pod_cubcft", _
                "pod_ordqty", "pod_cuspno", "pod_respno", _
                "pod_candat", _
                "pod_shpstr", _
                "pod_shpend", _
                "pod_ctnstr", "pod_ctnend", "pod_ttlctn", _
                "pod_rmk" _
            }

            For j As Integer = 0 To tmpcollist.Length - 1
                newQCDtl.Item(tmpcollist(j)) = rs.Tables("RESULT").Rows(0).Item(tmpcollist(j))
            Next

            'View column
            newQCDtl.Item("view_itmno") = rs.Tables("RESULT").Rows(0).Item("pod_itmno")
            newQCDtl.Item("view_cuspno") = If(rs.Tables("RESULT").Rows(0).Item("poh_cuspno").ToString() = "", rs.Tables("RESULT").Rows(0).Item("pod_cuspno"), rs.Tables("RESULT").Rows(0).Item("poh_cuspno"))




            Dtltbl.Rows.Add(newQCDtl)

            'WeekDay

            QCWeekDay.Mon = If(newQCDtl.Item("qcd_mon") = "Y", True, QCWeekDay.Mon)
            QCWeekDay.Tue = If(newQCDtl.Item("qcd_tue") = "Y", True, QCWeekDay.Tue)
            QCWeekDay.Wed = If(newQCDtl.Item("qcd_wed") = "Y", True, QCWeekDay.Wed)
            QCWeekDay.Thur = If(newQCDtl.Item("qcd_thur") = "Y", True, QCWeekDay.Thur)
            QCWeekDay.Fri = If(newQCDtl.Item("qcd_fri") = "Y", True, QCWeekDay.Fri)
            QCWeekDay.Sat = If(newQCDtl.Item("qcd_sat") = "Y", True, QCWeekDay.Sat)
            QCWeekDay.Sun = If(newQCDtl.Item("qcd_sun") = "Y", True, QCWeekDay.Sun)

            POWeekDay.Mon = If(newQCDtl.Item("qcd_mon") = "Y", True, POWeekDay.Mon)
            POWeekDay.Tue = If(newQCDtl.Item("qcd_tue") = "Y", True, POWeekDay.Tue)
            POWeekDay.Wed = If(newQCDtl.Item("qcd_wed") = "Y", True, POWeekDay.Wed)
            POWeekDay.Thur = If(newQCDtl.Item("qcd_thur") = "Y", True, POWeekDay.Thur)
            POWeekDay.Fri = If(newQCDtl.Item("qcd_fri") = "Y", True, POWeekDay.Fri)
            POWeekDay.Sat = If(newQCDtl.Item("qcd_sat") = "Y", True, POWeekDay.Sat)
            POWeekDay.Sun = If(newQCDtl.Item("qcd_sun") = "Y", True, POWeekDay.Sun)



            Dim POrow As DataRow() = POtbl.Select("qpd_purord ='" & insertrows(i).Item("PO No") & "'")
            'Update POHDR date info
            For j As Integer = 0 To dayList.Length - 1
                POrow(0).Item("qpd_" + dayList(j)) = If(String.Compare(POWeekDay.to_YFormat(j + 1), "Y") = 0, POWeekDay.to_YFormat(j + 1), POrow(0).Item("qpd_" + dayList(j)))
            Next

            If String.Compare(POrow(0).Item("qpd_ctrlstate"), "") = 0 Then
                POrow(0).Item("qpd_ctrlstate") = "UPD"
            End If


        Next

        'Update QCHDR date info
        If flg_havedetail Then
            For i As Integer = 0 To dayList.Length - 1
                Hdrtbl.Rows(0).Item("qch_" + dayList(i)) = If(String.Compare(QCWeekDay.to_YFormat(i + 1), "Y") = 0, QCWeekDay.to_YFormat(i + 1), Hdrtbl.Rows(0).Item("qch_" + dayList(i)))
            Next
        Else
            For i As Integer = 0 To dayList.Length - 1
                Hdrtbl.Rows(0).Item("qch_" + dayList(i)) = QCWeekDay.to_YFormat(i + 1)
            Next
        End If


        'Refresh Page
        FillQCHeader()
        FillQCPOHeaderGrid()
        FillSummayGrid()

        Pointer_CurQCseq = Dtltbl.Rows.Count - 1
        FillQCDetail()
        set_cmdBackNextControl()



    End Sub

    Public Sub InsertIMRowsFrom_QCM00001(ByVal retdata As Hashtable)
        Dim Hdrtbl As DataTable = rs_QCM00002Hdr.Tables("RESULT")
        Dim POtbl As DataTable = rs_QCM00002_QCPODTL.Tables("RESULT")
        Dim Dtltbl As DataTable = rs_QCM00002.Tables("RESULT")

        Dim QCWeekDay As WeekDay = New WeekDay()


        Dim newQCDtl As DataRow = Dtltbl.NewRow()


        Dim qcd_qcseq As Integer
        If Dtltbl.Rows.Count = 0 Then
            qcd_qcseq = 1
        Else
            qcd_qcseq = Dtltbl.Rows(Dtltbl.Rows.Count - 1).Item("qcd_qcseq") + 1
        End If

        Dim qcd_dtlsts As String = "OPE"
        Dim qcd_flgpolink As String = ""
        Dim qcd_qcposeq As Integer = 0
        Dim qcd_ctrlstate As String = "ADD"
        Dim qcd_DEL As String = ""

        'newQCDtl.Item("qch_venno") = Hdrtbl.Rows(0).Item("qch_venno")
        'newQCDtl.Item("qch_prmcus") = Hdrtbl.Rows(0).Item("qch_prmcus")
        'newQCDtl.Item("qch_seccus") = Hdrtbl.Rows(0).Item("qch_seccus")
        newQCDtl.Item("qch_inspyear") = Hdrtbl.Rows(0).Item("qch_inspyear")
        newQCDtl.Item("qch_inspweek") = Hdrtbl.Rows(0).Item("qch_inspweek")
        newQCDtl.Item("qch_insptyp") = Hdrtbl.Rows(0).Item("qch_insptyp")


        newQCDtl.Item("qcd_cocde") = Hdrtbl.Rows(0).Item("qch_cocde")
        newQCDtl.Item("qcd_qcno") = Hdrtbl.Rows(0).Item("qch_qcno")
        newQCDtl.Item("qcd_qcseq") = qcd_qcseq
        newQCDtl.Item("qcd_dtlsts") = qcd_dtlsts
        newQCDtl.Item("qcd_genby") = ""
        newQCDtl.Item("qcd_flgpolink") = qcd_flgpolink
        newQCDtl.Item("qcd_qcposeq") = qcd_qcposeq

        newQCDtl.Item("qcd_purord") = ""
        newQCDtl.Item("qcd_purseq") = 0



        'Important all ItmDtl level is in here
        For Each de As DictionaryEntry In retdata
            newQCDtl.Item(de.Key) = de.Value
        Next de

        newQCDtl.Item("qcd_ctrlstate") = qcd_ctrlstate
        newQCDtl.Item("DEL") = qcd_DEL


        Dim tmpcollist As String() = { _
            "poh_purord", _
            "poh_ordno", _
            "poh_pursts", _
            "poh_credat", _
            "poh_issdat", _
            "poh_venno", _
            "poh_cuspno", "poh_reppno", _
            "poh_shpstr", _
            "poh_shpend", _
            "poh_rmk", _
 _
            "pod_purseq", _
            "pod_itmno", _
            "pod_jobord", _
            "pod_prdven", "pod_tradeven", "pod_examven", _
            "pod_venitm", "pod_cusitm", "pod_seccusitm", "pod_cussku", _
            "pod_engdsc", "pod_chndsc", _
            "pod_vencol", "pod_cuscol", "pod_coldsc", "pod_pckitr", _
 _
            "pod_untcde", "pod_inrctn", "pod_mtrctn", "pod_cubcft", _
            "pod_ordqty", "pod_cuspno", "pod_respno", _
            "pod_candat", _
            "pod_shpstr", _
            "pod_shpend", _
            "pod_ctnstr", "pod_ctnend", "pod_ttlctn", _
            "pod_rmk" _
        }

        'Set PO detail
        For j As Integer = 0 To tmpcollist.Length - 1
            Dim colDataType As String = newQCDtl.Table.Columns(tmpcollist(j)).DataType.Name
            If colDataType = "String" Then
                newQCDtl.Item(tmpcollist(j)) = ""
            ElseIf colDataType = "Int32" Or colDataType = "Decimal" Then
                newQCDtl.Item(tmpcollist(j)) = 0
            ElseIf colDataType = "DateTime" Then
                newQCDtl.Item(tmpcollist(j)) = New DateTime(1900, 1, 1)
            Else
                newQCDtl.Item(tmpcollist(j)) = ""
            End If
            'newQCDtl.Item(tmpcollist(j)) = ""
        Next

        'View Column
        newQCDtl.Item("view_itmno") = retdata.Item("qcd_xitmno")
        newQCDtl.Item("view_cuspno") = ""




        '20151023 - Change due to IM do not need to input  insp date now
        'QCWeekDay.Mon = If(newQCDtl.Item("qcd_mon") = "Y", True, QCWeekDay.Mon)
        'QCWeekDay.Tue = If(newQCDtl.Item("qcd_tue") = "Y", True, QCWeekDay.Tue)
        'QCWeekDay.Wed = If(newQCDtl.Item("qcd_wed") = "Y", True, QCWeekDay.Wed)
        'QCWeekDay.Thur = If(newQCDtl.Item("qcd_thur") = "Y", True, QCWeekDay.Thur)
        'QCWeekDay.Fri = If(newQCDtl.Item("qcd_fri") = "Y", True, QCWeekDay.Fri)
        'QCWeekDay.Sat = If(newQCDtl.Item("qcd_sat") = "Y", True, QCWeekDay.Sat)
        'QCWeekDay.Sun = If(newQCDtl.Item("qcd_sun") = "Y", True, QCWeekDay.Sun)

        For i As Integer = 0 To dayList.Length - 1
            QCWeekDay.setReqDate(i + 1, Hdrtbl.Rows(0).Item("qch_" + dayList(i)))
        Next

        'Update QCDtl date info
        For i As Integer = 0 To dayList.Length - 1
            newQCDtl.Item("qcd_" + dayList(i)) = QCWeekDay.to_YFormat(i + 1)
        Next

        Dtltbl.Rows.Add(newQCDtl)


        'Update QCHDR date info
        'For i As Integer = 0 To dayList.Length - 1
        '    Hdrtbl.Rows(0).Item("qch_" + dayList(i)) = If(String.Compare(QCWeekDay.to_YFormat(i + 1), "Y") = 0, QCWeekDay.to_YFormat(i + 1), Hdrtbl.Rows(0).Item("qch_" + dayList(i)))
        'Next




        'Refresh Page
        FillQCHeader()
        FillQCPOHeaderGrid()
        FillSummayGrid()

        Pointer_CurQCseq = Dtltbl.Rows.Count - 1
        FillQCDetail()
        set_cmdBackNextControl()



    End Sub


    Public Function check_InspTyp()
        check_InspTyp = False
        Dim Hdrtbl As DataTable = rs_QCM00002Hdr.Tables("RESULT")

        Dim Insptyp As String = Hdrtbl.Rows(0).Item("qch_insptyp")
        If opt_typ1.Checked Then
            If Insptyp = "P" Or Insptyp = "M" Then
                MsgBox("Inspection Type [" + Insptyp + "] cannot insert PO detail!")
                Exit Function
            End If
        Else
            If Insptyp = "F" Or Insptyp = "FC" Then
                MsgBox("Inspection Type [" + Insptyp + "] cannot insert Item detail!")
                Exit Function
            End If
        End If

        check_InspTyp = True
    End Function

#End Region

#Region "QCM00002 Related"
    Private Sub QCM00002_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formstartup(Me.Name)

        Init_RS()
        Init_PanelAdd()
        Init_ComboBox() 'TabPage Combobox
        ToStage("INIT")

        Init_dtlMapping()
        'Init_dtlUpdItm()


        Init_HdrMapping()   'TabPage1 Venodor Contact Info

        Init_POHdrMapping() 'TabPage2 PO Header Info
        Init_dg_POHeader() 'TabPage2 dg_POHeader
        Init_SummaryMapping() 'TabePage3 dg_Summary

        'Init_HdrEvent()



        FillQCHeader()
        FillQCDetail()
        FillQCPOHeader()
        FillSummayGrid()
        set_cmdBackNextControl()
        set_cmdBackNextPOControl()


        If ma_QCM00004 Is Nothing Then
            'Not from QCM00004
        Else
            'From QCM0002
            QCM00004_INIT()
        End If


    End Sub
#End Region

#Region "QCM00004 Related"
    Private Function QCM00004_INIT()
        Cursor = Cursors.WaitCursor
        QCFind(txtQCno.Text)
        Cursor = Cursors.Default
    End Function
#End Region


    Private Sub txtQCno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQCno.KeyPress
        If e.KeyChar = Chr(13) And mmdFind.Enabled = True Then
            Call mmdFind_Click(sender, e)
        End If

    End Sub

    Private Sub Init_PanelAdd()
        today = Date.Today
        fillcboPriCust()
        fillcboSecCust()
        fillcboVendor()
        FillCompCombo(gsUsrID, cboCoCde)

        'today = New DateTime(2017, 12, 30)
        Dim cur_year As Integer = today.Year
        cboYear_PanelAdd.Items.Add(cur_year)
        cboYear_PanelAdd.SelectedIndex = 0


        ''FillWeekBox(cboWeek_PanelAdd, GetWeekByDate(Date.Today, True), cboYear_PanelAdd.SelectedItem)
        FillWeekBox(cboWeek_PanelAdd, GetWeekByDate(today, True), cboYear_PanelAdd.SelectedItem)

        UpdateWeekDate2(cboYear_PanelAdd.Text, Split(Split(cboWeek_PanelAdd.Text, " - ")(0), " ")(1))


    End Sub

    Private Sub Init_ComboBox()
        Dim dr() As DataRow = rs_CUBASINF_P.Tables("RESULT").Select("cbi_cusno >= '50000'")
        If dr.Length > 0 Then
            cboCus1No.Items.Clear()

            For i As Integer = 0 To dr.Length - 1
                cboCus1No.Items.Add(dr(i).Item("cbi_cusno") & " - " & dr(i).Item("cbi_cussna"))
            Next
        End If

        dr = rs_CUBASINF_S.Tables("RESULT").Select("csc_seccus >= 60000")

        If dr.Length > 0 Then

        End If

        If Not dr Is Nothing Then
            'possible bug ?
            'If dr.Length > 1 Then
            If dr.Length > 0 Then
                For index As Integer = 0 To dr.Length - 1
                    cboCus2no_PanelAdd.Items.Add(dr(index)("csc_seccus").ToString + " - " + dr(index)("cbi_cussna").ToString)
                Next
            End If
        End If




        Dim strList As String
        If rs_VNBASINF.Tables("RESULT").Rows.Count > 0 Then
            For i As Integer = 0 To rs_VNBASINF.Tables("RESULT").Rows.Count - 1
                strList = rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_vensna")
                If strList <> "" Then
                    cboHVenno.Items.Add(strList)

                End If
            Next i
        End If




    End Sub




#Region "Form Basic Control"
    Public Sub mmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdFind.Click
        '  If checkFocus(Me) Then Exit Sub

        txtQCno.Text = UCase(Trim(txtQCno.Text))
        If QCFind(txtQCno.Text) Then
        End If
    End Sub

    Private Sub mmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdAdd.Click
        If checkFocus(Me) Then Exit Sub

        txtQCno.Text = ""
        clear_PanelAdd()
        display_PanelAdd(True)


    End Sub

    Private Sub mmdCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdCopy.Click
        If checkFocus(Me) Then Exit Sub
        If Recordstatus = True Then
            MsgBox("QC in edit mode. Not available for copy.")
            Exit Sub
        End If

        Dim copyQC = New frmCopyQC
        copyQC.ma = Me

        copyQC.ShowDialog()
        'QCClear()
        'ToStage("INIT")
        ''20130729

    End Sub

    Public Sub mmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdSave.Click
        If checkFocus(Me) Then Exit Sub
        Call saveClick()
    End Sub

    Public Sub saveClick()
        If Not check_QCSave() Then
            Exit Sub
        End If

        If QCSave() Then
            Dim QCNo As String = rs_QCM00002Hdr.Tables("RESULT").Rows(0).Item("qch_qcno")
            MsgBox(QCNo + " Save Success")
            txtQCno.Text = QCNo
            QCClear()
            ToStage("INIT")
        Else
            MsgBox("Save Fail")
        End If
    End Sub

    Private Sub mmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdExit.Click
        If checkFocus(Me) Then Exit Sub
        Me.Close()
    End Sub

    Private Sub mmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdClear.Click
        If checkFocus(Me) Then Exit Sub

        Dim answer As Integer = MsgBox("All Unsave data will be clear. Are you srue?", MsgBoxStyle.YesNo)
        If answer = MsgBoxResult.Yes Then
            QCClear()
            ToStage("INIT")
        End If
    End Sub

    Private Sub mmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdInsRow.Click
        If checkFocus(Me) Then Exit Sub

        Recordstatus = True
        TabControl1.SelectedIndex = 2
        display_PanelInsRow(True)
        freeze_TabControl(2)

    End Sub

    Private Sub mmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdSearch.Click
        If checkFocus(Me) Then Exit Sub

        Dim frmSYM00018 As New SYM00018


        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)


        frmSYM00018.keyName = txtQCno.Name
        frmSYM00018.strModule = "QC"

        frmSYM00018.show_frmSYM00018(Me)

    End Sub

    Private Sub cmdAttach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAttach.Click
        Dim frm_QCM00009 As New QCM00009

        If Trim(txtQCno.Text) = "" Or stage <> "LOAD" Then
            Exit Sub
        End If

        frm_QCM00009.ma_QCM00002 = Me


        frm_QCM00009.Text = "Single Inspection Request Attachment"
        'frm_QCM00009.cboCoCde.Text = cboCocde_Page1.Text    'Not working since in QCM00002 will overwrite
        frm_QCM00009.GroupBox1.Enabled = True
        'frm_QCM00009.grpSC.Enabled = False
        frm_QCM00009.grpSC.Visible = False
        frm_QCM00009.txtSCFm.Text = Trim(txtQCno.Text)
        frm_QCM00009.txtSCTo.Text = Trim(txtQCno.Text)

        frm_QCM00009.grpQC.Visible = True
        frm_QCM00009.grpQC.Size = New Size(690, 44)
        frm_QCM00009.grpQC.Location = New Point(12, 73)

        frm_QCM00009.txtQCNo.Text = Trim(txtQCno.Text)



        frm_QCM00009.Opt_Q.Checked = True

        frm_QCM00009.ShowDialog()

    End Sub

    Private Sub cmdCancelQC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelQC.Click

        Dim answer As Integer = MsgBox("This action will Cancel the whole QC. Are you sure?", MsgBoxStyle.YesNo)
        If answer = MsgBoxResult.Yes Then

            If QCCancel() Then
                MsgBox("Cancel Success")
            End If
            QCClear()
            ToStage("INIT")
        End If
    End Sub

    Private Sub cmdRelease_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRelease.Click
        Dim Hdrtbl As DataTable = rs_QCM00002Hdr.Tables("RESULT")

        If Recordstatus = True Then
            MsgBox("QC is in Edit mode. Not available for release.")
            Exit Sub
        End If


        Dim qch_qcsts As String = Hdrtbl.Rows(0).Item("qch_qcsts")

        If qch_qcsts = "CAN" Or qch_qcsts = "DEL" Then
            MsgBox("QC with ststus " + qch_qcsts + " can not be released OR unreleased")
            Exit Sub
        End If

        Dim action As String = If(qch_qcsts = "OPE", "Release", If(qch_qcsts = "REL", "Unrelease", "Error"))
        If action = "Error" Then
            MsgBox("Error Happens, Release Fail")
            Exit Sub
        End If



        Dim answer As Integer = MsgBox("This action will " + action + " the  QC. Are you sure?", MsgBoxStyle.YesNo)
        If answer = MsgBoxResult.Yes Then
            Dim flg As String = If(action = "Release", "R", "U")

            If QCRelease(flg) Then
                MsgBox(action + " Success")
                If flg = "R" Then
                    checkCurweekRequest(flg)
                ElseIf flg = "U" Then
                    checkCurweekRequest(flg)
                End If
            Else
                MsgBox(action + " Fail")
            End If
            QCClear()
            ToStage("INIT")
        End If

    End Sub

    Private Sub display_PanelInsRow(ByVal flag As Boolean)
        PanelInsRow.Visible = flag
    End Sub
    Private Sub AlertCurrentWeekRequestRelease(ByVal action As String)
        Dim emailHost As String = "192.168.1.235"
        Dim MailMsg As String = ""
        Dim MailFrAddress As String = "erpalert@ucp.com.hk"
        ''''Dim MailToAddress As String = "henryli@ucp.com.hk;chrisleung@ucp.com.hk;marco@ucp.com.hk;michaelchiu@ucp.com.hk;terry.ng@ucpsz.com;ken.zhang@ucpsz.com"
        Dim MailToAddress As String = "michaelchiu@ucp.com.hk"
        Dim toAddressList = ""
        Dim mail As New MailMessage()
        Dim SmtpServer As New SmtpClient()
        Dim mailBody As String = ""

        Try



            gspStr = "sp_select_SYEMLALT '" & "QC" & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_email, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("Error on loading QCM00003 sp_select_EMLALTMAP : " & rtnStr)
                Exit Sub
            End If


            MailToAddress = rs_email.Tables("RESULT").Rows(0).Item("sea_email")
            toAddressList = MailToAddress.Split(";")

            MsgBox("Send email to " & MailToAddress)



            mail.From = New MailAddress("erpalert@ucp.com.hk")
            For toIndex As Integer = 0 To toAddressList.Length - 1
                If toAddressList(toIndex) <> "" Then
                    mail.To.Add(toAddressList(toIndex))
                End If
            Next
            mail.Subject = ""
            mailBody = ""
            mail.Body = ""
            If action = "R" Then
                mail.Subject = "User " & gsUsrID & " has just released a QC request " & rs_QCM00002Hdr.Tables("RESULT").Rows(0).Item("qch_qcno") & " in " & rs_QCM00002Hdr.Tables("RESULT").Rows(0).Item("qch_venno") & _
                  "-" & rs_QCM00002Hdr.Tables("RESULT").Rows(0).Item("vbi_vensna") & _
                  " for " & rs_QCM00002Hdr.Tables("RESULT").Rows(0).Item("qch_prmcus") & "-" & rs_QCM00002Hdr.Tables("RESULT").Rows(0).Item("cbi_cussna") & _
                  " with " & rs_QCM00002Dtl_2.Tables("RESULT").Rows.Count & " item(s) " & _
                  " on week " & GetCurrentWeek()

                mailBody = mailBody & "The released QC request is " & rs_QCM00002Hdr.Tables("RESULT").Rows(0).Item("qch_qcno") & vbCrLf


                mailBody = mailBody & "The released QC request contains following PR#:" & vbCrLf

                For i As Integer = 0 To rs_QCM00002Dtl.Tables("RESULT").Rows.Count - 1
                    'If tmpItem <> rs_QCM00002Dtl.Tables("RESULT").Rows(i).Item("qcd_purord") Then
                    mailBody = mailBody & rs_QCM00002Dtl.Tables("RESULT").Rows(i).Item("qcd_purord") & vbCrLf
                    'tmpItem = rs_QCM00002Dtl.Tables("RESULT").Rows(i).Item("qcd_purord")
                    ' End If
                Next

                mailBody = mailBody & "The released QC request contains following Item#:" & vbCrLf

                ' tmpItem = ""
                For i As Integer = 0 To rs_QCM00002Dtl_2.Tables("RESULT").Rows.Count - 1
                    '  If tmpItem <> rs_QCM00002Dtl_2.Tables("RESULT").Rows(i).Item("sod_itmno") Then
                    mailBody = mailBody & rs_QCM00002Dtl_2.Tables("RESULT").Rows(i).Item("sod_itmno") & vbCrLf
                    'tmpItem = rs_QCM00002Dtl_2.Tables("RESULT").Rows(i).Item("sod_itmno")
                    '  End If
                Next
            ElseIf action = "U" Then
                mail.Subject = "User " & gsUsrID & " has just unreleased a QC request " & rs_QCM00002Hdr.Tables("RESULT").Rows(0).Item("qch_qcno") & " in " & rs_QCM00002Hdr.Tables("RESULT").Rows(0).Item("qch_venno") & _
                  "-" & rs_QCM00002Hdr.Tables("RESULT").Rows(0).Item("vbi_vensna") & _
                  " for " & rs_QCM00002Hdr.Tables("RESULT").Rows(0).Item("qch_prmcus") & "-" & rs_QCM00002Hdr.Tables("RESULT").Rows(0).Item("cbi_cussna") & _
                  " with " & rs_QCM00002Hdr.Tables("RESULT").Rows(0).Item("res_itmcount") & " item(s) " & _
                  " on week " & GetCurrentWeek()
                mail.Body = "The unreleased QC request is " & rs_QCM00002Hdr.Tables("RESULT").Rows(0).Item("qch_qcno") & _
                    ". The QC request's status changed from Released to Unreleased."
            End If

            mail.Body = mailBody
            SmtpServer.Port = 25
            SmtpServer.Credentials = New System.Net.NetworkCredential("192.168.1.235", "basic")
            SmtpServer.Host = emailHost

            SmtpServer.Send(mail)


        Catch ex As Exception
            MessageBox.Show("The QC Request is saved but Mail cannot be send. Please contart the QC with other method. The reason fail to send is :\n------------" & ex.ToString)
        End Try
        'MessageBox.Show("mail Send")

        ''

        If action = "R" Then
            gspStr = "sp_update_QCREQACT '" & rs_QCM00002Hdr.Tables("RESULT").Rows(0).Item("qch_qcno") & "','" & _
               rs_QCM00002Hdr.Tables("RESULT").Rows(0).Item("qch_verno") & "'" & _
                ",'R'" & _
                ",'" & gsUsrID & "'" & _
                 ",'E'"

        ElseIf action = "U" Then
            gspStr = "sp_update_QCREQACT '" & rs_QCM00002Hdr.Tables("RESULT").Rows(0).Item("qch_qcno") & "','" & _
               rs_QCM00002Hdr.Tables("RESULT").Rows(0).Item("qch_verno") & "'" & _
                ",'U'" & _
                ",'" & gsUsrID & "'" & _
                 ",'E'"
        End If

        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading sp_update_QCREQACT:" & rtnStr)
            Exit Sub
        End If
    End Sub
    Private Sub freeze_TabControl(ByVal tabpageno As Integer)
        Dim i As Integer
        For i = 0 To TabControl1.TabPages.Count - 1
            If i = tabpageno Then
                Me.TabControl1.TabPages(i).Enabled = True
            Else
                Me.TabControl1.TabPages(i).Enabled = False
            End If
        Next i
    End Sub

    Private Sub release_TabControl()
        Dim i As Integer
        For i = 0 To TabControl1.TabPages.Count - 1
            Me.TabControl1.TabPages(i).Enabled = True
        Next i
    End Sub


    'Private Sub chkCancel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCancel.CheckedChanged

    '    If chkCancel.Checked = True Then
    '        Dim answer As Integer = MsgBox("This action will Cancel the whole QC. Are you sure?", MsgBoxStyle.YesNo)
    '        If answer = MsgBoxResult.Yes Then

    '            If QCCancel() Then
    '                MsgBox("Cancel Success")
    '            End If
    '            QCClear()
    '            ToStage("INIT")
    '        Else
    '            chkCancel.Checked = False
    '        End If
    '    End If


    'End Sub


#End Region


#Region "Core Function"
    Private Function QCAdd() As Boolean
        QCAdd = False


        gspStr = "sp_select_QCM00002Hdr '','Y','',''"
        rtnLong = execute_SQLStatement(gspStr, rs_QCM00002Hdr, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading sp_select_QCM0002Hdr:" & rtnStr)
            Exit Function
        End If

        For i As Integer = 0 To rs_QCM00002Hdr_ADD.Tables("RESULT").Columns.Count - 1
            rs_QCM00002Hdr.Tables("RESULT").Columns(i).ReadOnly = False
        Next

        Dim Hdrtbl As DataTable = rs_QCM00002Hdr.Tables("RESULT")




        Hdrtbl.Rows(0).Item("qch_cocde") = cboCoCde.Text
        Hdrtbl.Rows(0).Item("qch_venno") = Split(cboVenno_PanelAdd.Text, " - ")(0)
        Hdrtbl.Rows(0).Item("qch_prmcus") = Split(cboCus1no_PanelAdd.Text, " - ")(0)
        Hdrtbl.Rows(0).Item("qch_seccus") = Split(cboCus2no_PanelAdd.Text, " - ")(0)
        Hdrtbl.Rows(0).Item("qch_inspyear") = cboYear_PanelAdd.Text
        Hdrtbl.Rows(0).Item("qch_inspweek") = Split(Split(cboWeek_PanelAdd.Text, " - ")(0), " ")(1)

        For Each ctrl As Control In PanelAdd_groupbox2.Controls
            If ctrl.GetType() Is GetType(CheckBox) Then
                Dim chk As CheckBox = CType(ctrl, CheckBox)
                If chk.Checked Then
                    Dim idx As Integer = Array.IndexOf(dayList, LCase(ctrl.Text))
                    If idx <> -1 Then
                        Hdrtbl.Rows(0).Item("qch_" + dayList(idx)) = "Y"
                    End If

                End If
            End If
        Next

        'Hdrtbl.Rows(0).Item("qch_insptyp") = If(opt1_PanelAdd.Checked, "P", "M")

        For Each ctrl As Control In PanelAdd_groupbox1.Controls
            If ctrl.GetType() Is GetType(RadioButton) Then
                Dim rb As RadioButton = CType(ctrl, RadioButton)
                If rb.Checked Then

                    Hdrtbl.Rows(0).Item("qch_insptyp") = Convert_Insptype(rb.Text)
                End If
            End If
        Next



        gspStr = "sp_select_QCM00002_VNCNTINF_Q 'ALL', '" & rs_QCM00002Hdr.Tables("RESULT").Rows(0).Item("qch_venno") & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_QCM00002_VNCNTINF_Q, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading sp_select_QCM00002_VNCNTINF_Q:" & rtnStr)
            Exit Function
        End If


        gspStr = "sp_select_QCM00002_VNCNTINF_QCFA 'ALL', '" & rs_QCM00002Hdr.Tables("RESULT").Rows(0).Item("qch_venno") & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_QCM00002_VNCNTINF_QCFA, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading sp_select_QCM00002_VNCNTINF_QCFA:" & rtnStr)
            Exit Function
        End If


        Fill_cboVenInfo()

        cboVenAddr.SelectedIndex = 1

        'gspStr = "sp_list_VNCNTINF '" & gsCompany & "','" & Split(Hdrtbl.Rows(0).Item("qch_venno"), " - ")(0) & "','M','ADR'"
        'rtnLong = execute_SQLStatement(gspStr, rs_VNCNTINF, rtnStr)

        'If rtnLong <> RC_SUCCESS Then
        '    Cursor = Cursors.Default
        '    MsgBox("Error on loading sp_list_VNCNTINF:" & rtnStr)
        '    Exit Function
        'End If

        ToStage("ADD")
        FillQCHeader()
        FillQCDetail()
        FillQCPOHeader()
        FillSummayGrid()
        set_cmdBackNextControl()
        set_cmdBackNextPOControl()




        QCAdd = True
    End Function


    Public Function QCFind(ByVal QC As String) As Boolean
        QCFind = False

        ''Get rs_QCM00002Hdr & rs_QCM00002 Start
        gspStr = "sp_select_QCM00002Hdr '','','" & txtQCno.Text & "','" & gsUsrID & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_QCM00002Hdr, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading sp_select_QCM00002Hdr:" & rtnStr)
            Exit Function
        End If


        If rs_QCM00002Hdr.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("No Records Found Or You have no access right to view this Request")
            Exit Function
        Else
            If rs_QCM00002Hdr.Tables("RESULT").Rows(0).Item("qch_qcsts") = "DEL" Then
                MsgBox(rs_QCM00002Hdr.Tables("RESULT").Rows(0).Item("qch_qcno") + " is Deleted")
                Exit Function
            End If

        End If


        gspStr = "sp_select_QCM00002_QCPODTL '','','" & txtQCno.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_QCM00002_QCPODTL, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading sp_select_QCM00002_QCPODtl:" & rtnStr)
            Exit Function
        End If

        gspStr = "sp_select_QCM00002_QCPODTL_ALLDTL '','','" & txtQCno.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_QCM00002_QCPODTL_ALLDTL, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading sp_select_QCM00002_QCPODtl_ALLDTL:" & rtnStr)
            Exit Function
        End If

        gspStr = "sp_select_QCM00002 '','','" & txtQCno.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_QCM00002, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading sp_select_QCM00002:" & rtnStr)
            Exit Function
        End If

        '20151026 - Remove this checking
        'If rs_QCM00002.Tables("RESULT").Rows.Count = 0 Then
        '    MsgBox("No Detail Records Found")
        '    Exit Function
        'End If


        gspStr = "sp_select_QCM00002_VNCNTINF_Q 'ALL', '" & rs_QCM00002Hdr.Tables("RESULT").Rows(0).Item("qch_venno") & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_QCM00002_VNCNTINF_Q, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading sp_select_QCM00002_VNCNTINF_Q:" & rtnStr)
            Exit Function
        End If


        gspStr = "sp_select_QCM00002_VNCNTINF_QCFA 'ALL', '" & rs_QCM00002Hdr.Tables("RESULT").Rows(0).Item("qch_venno") & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_QCM00002_VNCNTINF_QCFA, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading sp_select_QCM00002_VNCNTINF_QCFA:" & rtnStr)
            Exit Function
        End If


        gspStr = "sp_select_QCM00002Dtl '" & txtQCno.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_QCM00002Dtl, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading sp_select_QCM00002Dtl:" & rtnStr)
            Exit Function
        End If
        gspStr = "sp_select_QCM00002Dtl_2 '" & txtQCno.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_QCM00002Dtl_2, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading sp_select_QCM00002Dtl_2:" & rtnStr)
            Exit Function
        End If
        Fill_cboVenInfo()



        'gspStr = "sp_select_QCM00002 '" & "','" & txtQCno.Text & "'"

        'rtnLong = execute_SQLStatement(gspStr, rs_QCM00002, rtnStr)
        'If rtnLong <> RC_SUCCESS Then
        '    Cursor = Cursors.Default
        '    MsgBox("Error on loading sp_select_QCM00002:" & rtnStr)
        '    Exit Function
        'End If

        'If rs_QCM00002.Tables("RESULT").Rows.Count = 0 Or rs_QCM00002Hdr.Tables("RESULT").Rows.Count = 0 Then
        '    MsgBox("No Records Found")
        '    Exit Function
        'End If

        'For i As Integer = 0 To rs_QCM00002.Tables("RESULT").Columns.Count - 1
        '    rs_QCM00002.Tables("RESULT").Columns(i).ReadOnly = False
        'Next
        'For i As Integer = 0 To rs_QCM00002Hdr.Tables("RESULT").Columns.Count - 1
        '    rs_QCM00002Hdr.Tables("RESULT").Columns(i).ReadOnly = False
        'Next

        'Get rs_QCM00002Hdr & rs_QCM00002 End
        'Get rs_VNCNTINF Start
        'gspStr = "sp_list_VNCNTINF '" & gsCompany & "','" & rs_QCM00002Hdr.Tables("RESULT").Rows(0).Item("qch_venno") & "','M','ADR'"
        'rtnLong = execute_SQLStatement(gspStr, rs_VNCNTINF, rtnStr)

        'If rtnLong <> RC_SUCCESS Then
        '    Cursor = Cursors.Default
        '    MsgBox("Error on loading sp_list_VNCNTINF:" & rtnStr)
        '    Exit Function
        'End If

        'Get rs_VNCNTINF End

        For i As Integer = 0 To rs_QCM00002.Tables("RESULT").Columns.Count - 1
            rs_QCM00002.Tables("RESULT").Columns(i).ReadOnly = False
        Next
        For i As Integer = 0 To rs_QCM00002_QCPODTL.Tables("RESULT").Columns.Count - 1
            rs_QCM00002_QCPODTL.Tables("RESULT").Columns(i).ReadOnly = False
        Next
        For i As Integer = 0 To rs_QCM00002Hdr.Tables("RESULT").Columns.Count - 1
            rs_QCM00002Hdr.Tables("RESULT").Columns(i).ReadOnly = False
        Next
        For i As Integer = 0 To rs_QCM00002_QCPODTL_ALLDTL.Tables("RESULT").Columns.Count - 1
            rs_QCM00002_QCPODTL_ALLDTL.Tables("RESULT").Columns(i).ReadOnly = False
        Next


        Me.StatusBar.Items("lblRight").Text = ""
        Dim dv2 As DataView = rs_QCM00002.Tables("RESULT").DefaultView
        If Not dv2.Count = 0 Then
            dv2.Sort = "pod_upddat desc"
            Dim drv As DataRowView = dv2(0)
            Me.StatusBar.Items("lblRight").Text = Format(drv.Item("pod_credat"), "MM/dd/yyyy") & " " & Format(drv.Item("pod_upddat"), "MM/dd/yyyy") & " " & drv.Item("pod_updusr")

            dv2.Sort = Nothing
        End If





        TabControl1.Enabled = True
        ToStage("LOAD")
        set_QCHdrStatusControl()
        set_cmdBackNextControl()
        set_cmdBackNextPOControl()
        FillQCHeader()
        FillQCPOHeader()
        FillQCDetail()
        FillQCSummary()



        QCFind = True
    End Function

    Private Sub Fill_cboVenInfo()
        Dim tbl As DataTable = rs_QCM00002_VNCNTINF_Q.Tables("RESULT")
        If cboVenAddr.Items.Count > 0 Then
            cboVenAddr.Items.Clear()
        End If

        cboVenAddr.Items.Add("")
        For i As Integer = 0 To tbl.Rows.Count - 1
            cboVenAddr.Items.Add(tbl.Rows(i).Item("vci_adr"))
        Next

        tbl = rs_QCM00002_VNCNTINF_QCFA.Tables("RESULT")
        If cboPorCtp.Items.Count > 0 Then
            cboPorCtp.Items.Clear()
        End If

        cboPorCtp.Items.Add("")
        For i As Integer = 0 To tbl.Rows.Count - 1
            cboPorCtp.Items.Add(tbl.Rows(i).Item("vci_cntctp") + " (" + tbl.Rows(i).Item("vci_cnttyp") + ")")
        Next



    End Sub


    Private Sub setQCHeaderControl(ByVal flag As Boolean)
        grp_qchdate.Enabled = flag
    End Sub

    Private Sub FillQCHeader()
        'rs_QCM00002Hdr

        If rs_QCM00002Hdr.Tables("RESULT").Rows.Count = 0 Then
            setQCHeaderControl(False)
            Exit Sub
        ElseIf rs_QCM00002.Tables("RESULT").Rows.Count = 0 Then
            'Don't have Detail rows, not allow to change schedule date
            'setQCHeaderControl(False)
        Else
            setQCHeaderControl(True)
        End If

        Dim cur_row As DataRow = rs_QCM00002Hdr.Tables("RESULT").Rows(0)
        cboCocde_Page1.Text = cur_row.Item("qch_cocde")
        cboStatus.Text = cur_row.Item("qch_qcsts")
        txtUpdUsr.Text = cur_row.Item("qch_updusr")
        TxtUpdDat.Text = cur_row.Item("qch_upddat")
        DTIssDat.Text = cur_row.Item("qch_credat")
        txtVerNo.Text = cur_row.Item("qch_verno")

        txt_HRmk.Text = cur_row.Item("qch_rmk")

        'Vendor Type
        'For Each ctrl As Control In GB_HVenTyp.Controls
        '    If ctrl.GetType() Is GetType(RadioButton) Then
        '        Dim rb As RadioButton = CType(ctrl, RadioButton)
        '        If String.Compare(rb.Text.ToString(), rs_QCM00002Hdr.Tables("RESULT").Rows(0).Item("qch_genby").ToString()) = 0 Then
        '            rb.Checked = True
        '        End If
        '    End If
        'Next

        cboHVenno.Text = cur_row.Item("qch_venno")

        cboCus1No.Text = cur_row.Item("qch_prmcus")
        cboCus2No.Text = cur_row.Item("qch_seccus")
        cboHYear.Text = cur_row.Item("qch_inspyear")
        'cboHWeek.Text = cur_row.Item("qch_inspweek")
        cboHWeek.Items.Clear()
        FillWeekBox(cboHWeek, cur_row.Item("qch_inspweek"), cur_row.Item("qch_inspyear"))
        UpdateWeekDate(cur_row.Item("qch_inspyear"), cur_row.Item("qch_inspweek"))

        txt_HcyDate.Text = cur_row.Item("qch_cydate")
        txt_Hsidate.Text = cur_row.Item("qch_sidate")
        txt_HcispDate.Text = cur_row.Item("qch_cispdate")

        If cboCus1No.Text <> "" Then
            auto_search_combo(cboCus1No)
            cboCus1No.Select(0, 0)

        End If

        If cboCus2No.Text <> "" Then
            auto_search_combo(cboCus2No)
            cboCus2No.Select(0, 0)
        End If

        If cboHVenno.Text <> "" Then
            auto_search_combo(cboHVenno)
            cboHVenno.Select(0, 0)
        End If

        'Insp Date
        For Each ctrl As Control In grp_qchdate.Controls
            If ctrl.GetType() Is GetType(CheckBox) Then
                Dim chk As CheckBox = CType(ctrl, CheckBox)
                Dim datestr As String = chk.Name.Substring(4)
                If String.Compare(cur_row.Item(datestr).ToString(), "Y") = 0 Then
                    chk.Checked = True
                Else
                    chk.Checked = False
                End If
            End If
        Next

        'Insp type
        For Each ctrl As Control In GB_HInspTyp.Controls
            If ctrl.GetType() Is GetType(RadioButton) Then
                Dim rb As RadioButton = CType(ctrl, RadioButton)
                If String.Compare(Convert_Insptype(rb.Text.ToString()), cur_row.Item("qch_insptyp").ToString()) = 0 Then
                    rb.Checked = True
                End If
            End If
        Next

        'Sample Handle
        For Each ctrl As Control In GB_HSamHdl.Controls
            If ctrl.GetType() Is GetType(RadioButton) Then
                Dim rb As RadioButton = CType(ctrl, RadioButton)
                If String.Compare(rb.Text.ToString(), cur_row.Item("qch_samhdl").ToString()) = 0 Then
                    rb.Checked = True
                End If
            End If
        Next


        'DTHInspDat.Text = cur_row.Item("qch_inspdate")

        'chk_SO.Checked = False
        'chk_TO.Checked = False


        'If cur_row.Item("qch_transactyp") = "S" Then
        '    chk_SO.Checked = True
        '    Gb_TOInfo.Enabled = False
        'Else
        '    chk_TO.Checked = True
        '    Gb_TOInfo.Enabled = True

        '    FillQCHeader_TO()
        'End If


        'cboHWeek.Items.Clear()


        For Each de As DictionaryEntry In hdrVen_mapping
            Dim crtl As Control = grp_view1.Controls(de.Value)
            crtl.Text = rs_QCM00002Hdr.Tables("RESULT").Rows(0).Item(de.Key)
        Next de




        ''

    End Sub

    Private Sub FillQCPOHeader()
        'Prevent No PO Hdr Case
        If rs_QCM00002_QCPODTL.Tables("RESULT").Rows.Count = 0 Then
            Exit Sub
        End If

        FillQCPOHeader_ByRowID(Pointer_CurQCseq)
        FillQCPOHeaderGrid()
    End Sub

    Private Sub FillQCPOHeader_ByRowID(ByVal seq As Integer)
        Dim cur_row As DataRow = rs_QCM00002_QCPODTL.Tables("RESULT").Rows(seq)
        'Fill TextBox, CboBox
        For Each de As DictionaryEntry In page2_mapping
            Dim crtl As Control = TabPage2.Controls(de.Value)
            crtl.Text = cur_row.Item(de.Key)
        Next de
    End Sub

    Private Sub FillQCPOHeaderGrid()
        Dim POtbl As DataTable = rs_QCM00002_QCPODTL.Tables(0)

        If POtbl.Rows.Count > 0 Then
            For i As Integer = 0 To POtbl.Rows.Count - 1
                POtbl.Rows(i).Item("view_inspweek") = Split(Split(cboHWeek.Text, " - ")(0), " ")(1) + " [" + Split(cboHWeek.Text, " - ")(1) + "]"
            Next
        End If


        Dim view_header_arr As String() = { _
            "qpd_purord", _
            "qch_inspyear", _
            "view_inspweek", _
            "qpd_mon", _
            "qpd_tue", _
            "qpd_wed", _
            "qpd_thur", _
            "qpd_fri", _
            "qpd_sat", _
            "qpd_sun", _
            "view_prmcus", _
            "view_seccus", _
            "poh_cuspno", _
            "view_vensna" _
        }

        '  "poh_prmcus", _
        '  "poh_seccus" _
        '"qch_insptyp" _

        dg_POHeaderView = New DataView(rs_QCM00002_QCPODTL.Tables("RESULT"))
        tbl_POHeader = dg_POHeaderView.ToTable(False, view_header_arr)
        dg_POHeader.DataSource = tbl_POHeader.DefaultView


        With dg_POHeader
            For Each element As DictionaryEntry In dg_POHeader_mapping
                .Columns(element.Key).HeaderText = element.Value
                .Columns(element.Key).ReadOnly = False
            Next

            .Columns("qpd_purord").Width = 80
            .Columns("qch_inspyear").Width = 40
            .Columns("view_inspweek").Width = 100
            .Columns("qpd_mon").Width = 30
            .Columns("qpd_tue").Width = 30
            .Columns("qpd_wed").Width = 30
            .Columns("qpd_thur").Width = 30
            .Columns("qpd_fri").Width = 30
            .Columns("qpd_sat").Width = 30
            .Columns("qpd_sun").Width = 30
            .Columns("view_prmcus").Width = 70
            .Columns("view_seccus").Width = 70
            .Columns("poh_cuspno").Width = 70
            .Columns("view_vensna").Width = 70
            '.Columns("qch_insptyp").Width = 60


        End With

    End Sub

    Private Sub FillQCSummary()
        FillSummayGrid()
    End Sub
    Private Sub FillSummayGrid()
        Dim Dtltbl As DataTable = rs_QCM00002.Tables(0)

        For i As Integer = 0 To Dtltbl.Rows.Count - 1
            Dtltbl.Rows(i).Item("view_prmcus") = Split(cboCus1No.Text, " - ")(1)
            Dtltbl.Rows(i).Item("view_seccus") = If(cboCus2No.Text <> "", Split(cboCus2No.Text, " - ")(1), "")
            Dtltbl.Rows(i).Item("view_vensna") = Split(cboHVenno.Text, " - ")(1)
            Dtltbl.Rows(i).Item("view_inspweek") = Split(Split(cboHWeek.Text, " - ")(0), " ")(1) + " [" + Split(cboHWeek.Text, " - ")(1) + "]"
        Next


        Dim view_arr As String() = { _
            "DEL", _
            "qcd_qcseq", _
            "qcd_purord", _
            "qcd_purseq", _
            "view_itmno", _
            "pod_cusitm", _
            "view_cuspno", _
            "view_inspweek", _
            "qcd_mon", _
            "qcd_tue", _
            "qcd_wed", _
            "qcd_thur", _
            "qcd_fri", _
            "qcd_sat", _
            "qcd_sun", _
            "view_prmcus", _
            "view_seccus", _
            "view_vensna" _
        }


        dg_SummaryView = New DataView(rs_QCM00002.Tables("result"))
        tbl_Summary = dg_SummaryView.ToTable(False, view_arr)
        dg_Summary.DataSource = tbl_Summary.DefaultView

        With dg_Summary
            .Columns("DEL").Width = 40
            .Columns("qcd_qcseq").Width = 50
            .Columns("qcd_purord").Width = 80
            .Columns("qcd_purseq").Width = 50
            .Columns("view_itmno").Width = 120
            .Columns("view_inspweek").Width = 100
            .Columns("qcd_mon").Width = 40
            .Columns("qcd_tue").Width = 40
            .Columns("qcd_wed").Width = 40
            .Columns("qcd_thur").Width = 40
            .Columns("qcd_fri").Width = 40
            .Columns("qcd_sat").Width = 40
            .Columns("qcd_sun").Width = 40

            .Columns("view_prmcus").Width = 70
            .Columns("view_seccus").Width = 70
            .Columns("view_vensna").Width = 70




            For Each element As DictionaryEntry In dg_Summary_mapping
                .Columns(element.Key).HeaderText = element.Value
                .Columns(element.Key).ReadOnly = True
            Next

        End With


    End Sub

    Private Sub SetQCDetailControl(ByVal flag As Boolean)

        If rs_QCM00002Hdr.Tables("RESULT").Rows.Count = 0 Then
            chkDelete.Enabled = flag
            grp_qcddate.Enabled = flag
            grp_ItmDtl.Enabled = flag
            cmdBOM.Enabled = flag
            cmdAss.Enabled = flag
            cmdShpMrk.Enabled = flag
            cmdShpDatMore.Enabled = flag
            Exit Sub
        End If


        If rs_QCM00002Hdr.Tables("RESULT").Rows(0).Item("qch_qcsts") <> "OPE" Then
            chkDelete.Enabled = False
            grp_qcddate.Enabled = False
            grp_ItmDtl.Enabled = False
        Else
            chkDelete.Enabled = flag
            grp_qcddate.Enabled = flag
            grp_ItmDtl.Enabled = flag
        End If

        cmdBOM.Enabled = flag
        cmdAss.Enabled = flag
        cmdShpMrk.Enabled = flag
        cmdShpDatMore.Enabled = flag



        'GB_DInspTyp.Enabled = flag
        'GB_DSampleHdl.Enabled = flag
    End Sub

    Private Sub FillQCDetail()
        'Prevent No QC Dtl Case
        If rs_QCM00002.Tables("RESULT").Rows.Count = 0 Then
            SetQCDetailControl(False)
            Exit Sub
        End If

        SetQCDetailControl(True)
        FillQCDetail_ByRowID(Pointer_CurQCseq)
    End Sub


    Private Sub FillQCDetail_ByRowID(ByVal seq As Integer)
        Dim cur_row As DataRow = rs_QCM00002.Tables("RESULT").Rows(seq)
        'QCDetail Type
        If cur_row.Item("qcd_flgpolink") = "Y" Then
            opt_detailtyp1.Checked = True
        Else
            opt_detailtyp2.Checked = True
        End If

        'Fill TextBox, CboBox
        For Each de As DictionaryEntry In dtl_mapping
            Dim ctrl As Control = TabPage3.Controls(de.Value)
            If TypeOf ctrl Is TextBox Or TypeOf ctrl Is MaskedTextBox Or TypeOf ctrl Is ComboBox Then
                ctrl.Text = cur_row.Item(de.Key).ToString()
            End If
        Next

        'Inspection Date
        For i As Integer = 0 To dayList.Length - 1
            Dim str As String = "qcd_" + dayList(i)

            Dim chkbox As CheckBox = CType(grp_qcddate.Controls("chk_" + str), CheckBox)
            If cur_row.Item(str) = "Y" Then
                chkbox.Checked = True
            Else
                chkbox.Checked = False
            End If


        Next


        'Inspection Week
        cbo_Dweek.Items.Clear()
        FillWeekBox(cbo_Dweek, rs_QCM00002Hdr.Tables("RESULT").Rows(0).Item("qch_inspweek"), rs_QCM00002Hdr.Tables("RESULT").Rows(0).Item("qch_inspyear"))
        'Inspect type
        '20150909 Comment it
        'For Each ctrl As Control In GB_DInspTyp.Controls
        '    If ctrl.GetType() Is GetType(RadioButton) Then
        '        Dim rb As RadioButton = CType(ctrl, RadioButton)
        '        If String.Compare(rb.Text.ToString(), cur_row.Item("qch_insptyp").ToString()) = 0 Then
        '            rb.Checked = True
        '        End If
        '    End If
        'Next

        'Sample Handle
        For Each ctrl As Control In GB_DSampleHdl.Controls
            If ctrl.GetType() Is GetType(RadioButton) Then
                Dim rb As RadioButton = CType(ctrl, RadioButton)
                If String.Compare(rb.Text.ToString(), cur_row.Item("qcd_samhdl").ToString()) = 0 Then
                    rb.Checked = True
                End If
            End If
        Next

        If cur_row.Item("qcd_flgpolink") = "" Then
            'Overwrite Other Info
            txtItmNo.Text = cur_row.Item("qcd_xitmno")
        End If

        If cur_row.Item("DEL") = "Y" Then
            chkDelete.Checked = True
        Else
            chkDelete.Checked = False

        End If

        'Fill QC Item Detail if It is Itm Detail
        If cur_row.Item("qcd_flgpolink") = "Y" Then
            grp_ItmDtl.Size = New Size(0, 0)
        Else
            grp_ItmDtl.Visible = True
            grp_ItmDtl.Size = New Size(355, 348)
            FillQCItmDetail_ByRowID(seq)
        End If


    End Sub

    Private Sub FillQCItmDetail_ByRowID(ByVal seq As Integer)
        Dim cur_row As DataRow = rs_QCM00002.Tables("RESULT").Rows(seq)

        For Each de As DictionaryEntry In itmdtl_mapping
            Dim ctrl As Control = grp_ItmDtl.Controls(de.Value)
            If TypeOf ctrl Is TextBox Or TypeOf ctrl Is MaskedTextBox Or TypeOf ctrl Is ComboBox Then
                ctrl.Text = cur_row.Item(de.Key).ToString()
            End If
        Next


    End Sub






    Private Function QCRefresh() As Boolean
        QCRefresh = False
        'Dim cur_row As DataRow = rs_QCM00002.Tables("RESULT").Rows(Pointer_CurQCseq)

        'If Not CheckDtlPageInput() Then
        '    Exit Function
        'End If

        'If opt_inspmode1.Checked Then
        '    'Date
        '    'Detail Page
        '    If String.Compare(DTDInspDat.Text, cur_row("qcd_inspdate")) <> 0 Then
        '        Dim base_year As Integer = GetWeekBaseYearByDate(DTDInspDat.Text)
        '        Dim base_week As Integer = GetWeekByDate(DTDInspDat.Text, False)
        '        cbo_Dweekfm.Items.Clear()
        '        cbo_Dweekto.Items.Clear()
        '        FillWeekBox(cbo_Dweekfm, cbo_Dweekto, base_week, base_year)
        '        txtDInspYear.Text = base_year
        '    End If


        '    If UpdateRowData(Pointer_CurQCseq) Then
        '        UpdateDtlRowState(Pointer_CurQCseq)
        '    End If

        '    'Header Page
        '    UpdateHeaderData()
        'Else
        '    If UpdateRowData(Pointer_CurQCseq) Then
        '        UpdateDtlRowState(Pointer_CurQCseq)
        '    End If

        '    'Detail Page


        'End If

        QCRefresh = True
    End Function

    Private Function QCClear() As Boolean
        QCClear = False

        Init_RS()

        ClearForm(grp_view1)
        ClearForm(TabPage2)
        ClearForm(TabPage3)
        dg_POHeader.DataSource = ""
        dg_Summary.DataSource = ""

        TabControl1.Enabled = False


        'Items that is not in Group/Tab

        DTIssDat.Text = "##/##/####"
        cboStatus.Text = ""
        txtUpdUsr.Text = ""
        TxtUpdDat.Text = ""
        txtVerNo.Text = ""
        'chkCancel.Checked = False
        'chkRelease.Checked = False


        QCClear = True
    End Function

    Private Sub ClearForm(ByVal ctrlParent As Control)
        Dim ctrl As Control
        For Each ctrl In ctrlParent.Controls
            If TypeOf ctrl Is TextBox Or TypeOf ctrl Is MaskedTextBox Or TypeOf ctrl Is ComboBox Then
                ctrl.Text = ""
            ElseIf TypeOf ctrl Is CheckBox Then
                CType(ctrl, CheckBox).Checked = False
            End If
            If ctrl.HasChildren Then
                ClearForm(ctrl)
            End If
        Next
    End Sub

    Private Function QCCancel() As Boolean
        QCCancel = False

        gspStr = "sp_update_QCM00002_cancelQC  '" & txtQCno.Text & "','" & gsUsrID & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading sp_cancel_QC:" & rtnStr)
            Exit Function
        End If


        QCCancel = True
    End Function


#End Region

#Region "Form Component Enable Related"
    Public Sub ToStage(ByVal _stage As String)
        stage = _stage

        Select Case _stage
            Case "INIT"
                Recordstatus = False
                save_mode = "UPD"
                'Header Command

                mmdAdd.Enabled = True
                mmdInsRow.Enabled = False
                mmdDelRow.Enabled = False
                mmdSave.Enabled = False
                mmdDelete.Enabled = False
                mmdFind.Enabled = True
                mmdClear.Enabled = False
                mmdCopy.Enabled = False
                mmdSearch.Enabled = True
                txtQCno.Enabled = True
                'chkCancel.Enabled = False
                'chkRelease.Enabled = False
                cmdCancelQC.Enabled = False
                mmdCancel.Enabled = False
                cmdRelease.Enabled = False
                mmdRel.Enabled = False


                TabControl1.Enabled = False
                TabControl1.SelectedIndex = 0

                TabPage1.Enabled = True
                dg_POHeader.Enabled = True
                grp_qcddate.Enabled = True
                TabPage4.Enabled = True


                'Header Page
                grp_qchdate.Enabled = False



                'Logic Control
                Pointer_CurPOSeq = 0
                Pointer_CurQCseq = 0

                mmdPrint.Enabled = False
                mmdAttach.Enabled = False
                mmdFunction.Enabled = False
                mmdLink.Enabled = False
                Call SetStatusBar(_stage)

            Case "LOAD"
                save_mode = "UPD"

                mmdAdd.Enabled = False
                mmdInsRow.Enabled = True
                mmdSave.Enabled = True
                mmdDelete.Enabled = False
                mmdFind.Enabled = False
                mmdClear.Enabled = True
                mmdCopy.Enabled = True
                mmdSearch.Enabled = False
                txtQCno.Enabled = False
                'chkCancel.Enabled = True
                'chkRelease.Enabled = True
                cmdCancelQC.Enabled = True
                mmdCancel.Enabled = True
                cmdRelease.Enabled = True
                mmdRel.Enabled = True
                TabControl1.Enabled = True


                'Header Page
                grp_qchdate.Enabled = True
                'grp_qchdate.Enabled = False

                Call SetStatusBar(_stage)

            Case "ADD"
                save_mode = "ADD"
                mmdAdd.Enabled = False
                mmdInsRow.Enabled = True
                mmdSave.Enabled = True
                mmdDelete.Enabled = False
                mmdFind.Enabled = False
                mmdClear.Enabled = True
                mmdCopy.Enabled = False
                mmdSearch.Enabled = False
                txtQCno.Enabled = False
                'chkCancel.Enabled = False
                'chkRelease.Enabled = False
                cmdCancelQC.Enabled = False
                mmdCancel.Enabled = False
                cmdRelease.Enabled = False
                mmdRel.Enabled = False
                TabControl1.Enabled = True

                'Header Page
                'grp_qchdate.Enabled = False
                grp_qchdate.Enabled = True
                Call SetStatusBar(_stage)

        End Select
    End Sub

    Private Sub set_QCHdrStatusControl()
        Dim hdr_status = rs_QCM00002Hdr.Tables("RESULT").Rows(0).Item("qch_qcsts")

        If hdr_status = "REL" Or hdr_status = "SCH" Or hdr_status = "CAN" Or hdr_status = "DEL" Then
            mmdSave.Enabled = False
            mmdInsRow.Enabled = False

            grp_apply.Enabled = False
            GB_HInspTyp.Enabled = False

            TabPage1.Enabled = False
            dg_POHeader.Enabled = False
            grp_qcddate.Enabled = False
            TabPage4.Enabled = True

            'GB_DInspTyp.Enabled = False
            'GB_DSampleHdl.Enabled = False
            'chkRelease.Enabled = False
            'chkCancel.Enabled = False
            cmdRelease.Enabled = If(hdr_status = "REL", True, False) '20151102 Allow Release button to Unrelease
            mmdRel.Enabled = If(hdr_status = "REL", True, False)
            cmdCancelQC.Enabled = False
            mmdCancel.Enabled = False
        Else
            mmdSave.Enabled = True
            mmdInsRow.Enabled = True

            grp_apply.Enabled = True
            GB_HInspTyp.Enabled = True

            TabPage1.Enabled = True
            dg_POHeader.Enabled = True
            grp_qcddate.Enabled = True
            TabPage4.Enabled = True


            'GB_DInspTyp.Enabled = True
            'GB_DSampleHdl.Enabled = True
            'chkRelease.Enabled = True
            'chkCancel.Enabled = True

            cmdRelease.Enabled = True
            mmdRel.Enabled = True
            cmdCancelQC.Enabled = True
            mmdCancel.Enabled = True
        End If
    End Sub


#End Region

#Region "InsertRow Panel Control"
    Private Sub cmd_typoptPanelExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_typoptPanelExit.Click
        display_PanelInsRow(False)
        release_TabControl()
    End Sub


    Private Sub cmd_typoptPanelGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_typoptPanelGo.Click
        display_PanelInsRow(False)
        release_TabControl()
        Init_QCM00001()
    End Sub
#End Region




#Region "DtlPage Button Control"
    Private Sub cmdAss_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAss.Click
        Dim rs_PODTLASS As DataSet
        Dim cur_row As DataRow = rs_QCM00002.Tables("RESULT").Rows(Pointer_CurQCseq)
        Dim cur_cocde As String = cur_row.Item("qcd_cocde").ToString()
        Dim cur_PONo As String = cur_row.Item("poh_purord").ToString()
        Dim cur_POSeq As String = cur_row.Item("pod_purseq").ToString()

        If String.Compare(cur_cocde, "") = 0 Or String.Compare(cur_PONo, "") = 0 Then
            MsgBox("Error: Invalid Call of cmdAss_Click!")
            Exit Sub
        End If


        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Dim gspStr = "sp_select_PODTLASS '" & cur_cocde & "','" & cur_PONo & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_PODTLASS, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading QCM00002 cmdAss_Click sp_select_PODTLASS : " & rtnStr)
            Exit Sub
        End If

        Dim drPODTLASS() As DataRow = rs_PODTLASS.Tables("RESULT").Select("pda_seq = '" & cur_POSeq & "'")

        If drPODTLASS.Length > 0 Then
            Dim frm_frmPOAss As New frmPOAss(rs_PODTLASS, cur_POSeq)
            frm_frmPOAss.grdPOAss.ReadOnly = True
            frm_frmPOAss.MdiParent = Me.MdiParent
            frm_frmPOAss.Show()
        Else
            MsgBox("No Assortment Found")
            Exit Sub
        End If

    End Sub

    Private Sub cmdBOM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBOM.Click
        Dim rs_PODTLBOM As DataSet
        Dim cur_row As DataRow = rs_QCM00002.Tables("RESULT").Rows(Pointer_CurQCseq)

        Dim cur_cocde As String = cur_row.Item("qcd_cocde").ToString()
        Dim cur_PONo As String = cur_row.Item("poh_purord").ToString()
        Dim cur_POSeq As String = cur_row.Item("pod_purseq").ToString()

        If String.Compare(cur_cocde, "") = 0 Or String.Compare(cur_PONo, "") = 0 Then
            MsgBox("Error: Invalid Call of cmdBOM_Click!")
            Exit Sub
        End If


        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        gspStr = "sp_select_PODTLBOM '" & cur_cocde & "','" & cur_PONo & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_PODTLBOM, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading QCM00002 cmdBOM_Click sp_select_PODTLBOM : " & rtnStr)
            Exit Sub
        End If

        Dim drPODTLBOM() As DataRow = rs_PODTLBOM.Tables("RESULT").Select("pdb_seq ='" & cur_POSeq & "'")

        If drPODTLBOM.Length > 0 Then
            Dim frm_frmPOBom As New frmPOBom(rs_PODTLBOM, cur_POSeq)
            frm_frmPOBom.grdPOBom.ReadOnly = True
            frm_frmPOBom.MdiParent = Me.MdiParent
            frm_frmPOBom.Show()
        Else
            MsgBox("No BOM Found")
            Exit Sub
        End If

    End Sub

    Private Sub cmdShpMrk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShpMrk.Click
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Dim cur_row As DataRow = rs_QCM00002.Tables("RESULT").Rows(Pointer_CurQCseq)
        Dim cur_cocde As String = cur_row.Item("qcd_cocde").ToString()
        Dim cur_PONo As String = cur_row.Item("poh_purord").ToString()
        Dim cur_SCNo As String = cur_row.Item("poh_ordno").ToString()


        Dim frm_frmPOShipMark As New frmPOShipMark(cur_cocde, cur_PONo, cur_SCNo)
        frm_frmPOShipMark.MdiParent = Me.MdiParent
        frm_frmPOShipMark.Show()

        Me.Cursor = Windows.Forms.Cursors.Default



    End Sub

    Private Sub cmdShpDatMore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShpDatMore.Click
        Dim rs_PODTLSHP As DataSet
        Dim cur_row As DataRow = rs_QCM00002.Tables("RESULT").Rows(Pointer_CurQCseq)

        Dim cur_cocde As String = cur_row.Item("qcd_cocde").ToString()
        Dim cur_PONo As String = cur_row.Item("poh_purord").ToString()
        Dim cur_POSeq As String = cur_row.Item("pod_purseq").ToString()


        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        gspStr = "sp_select_PODTLSHP '" & cur_cocde & "','" & cur_PONo & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_PODTLSHP, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading QCM00002 cmdShpDatMore_Click sp_select_PODTLSHP : " & rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            Exit Sub
        End If


        Dim frm_frmPOShip As New frmPOShip(rs_PODTLSHP, cur_POSeq)
        frm_frmPOShip.grdPOShip.ReadOnly = True
        frm_frmPOShip.MdiParent = Me.MdiParent
        frm_frmPOShip.Show()

    End Sub

    Private Sub cmdBackD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBackD.Click
        If Pointer_CurQCseq = 0 Then
            'Prevent View Error
            Exit Sub
        Else
            If Not QCRefresh() Then
                Exit Sub
            End If
            Pointer_CurQCseq -= 1
            set_cmdBackNextControl()

            FillQCDetail()
        End If
        Me.StatusBar.Items("lblRight").Text = ""
        Dim dv2 As DataView = rs_QCM00002.Tables("RESULT").DefaultView
        If Not dv2.Count = 0 Then
            dv2.Sort = "pod_upddat desc"
            Dim drv As DataRowView = dv2(0)
            Me.StatusBar.Items("lblRight").Text = Format(drv.Item("pod_credat"), "MM/dd/yyyy") & " " & Format(drv.Item("pod_upddat"), "MM/dd/yyyy") & " " & drv.Item("pod_updusr")

            dv2.Sort = Nothing
        End If
    End Sub

    Private Sub cmdNextD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNextD.Click
        Dim dtl_rowcnt As Integer = rs_QCM00002.Tables("RESULT").Rows.Count

        If Pointer_CurQCseq = dtl_rowcnt - 1 Then
            'Should not happen
        Else
            If Not QCRefresh() Then
                Exit Sub
            End If
            Pointer_CurQCseq += 1
            set_cmdBackNextControl()
            FillQCDetail()
        End If

        Me.StatusBar.Items("lblRight").Text = ""
        Dim dv2 As DataView = rs_QCM00002.Tables("RESULT").DefaultView
        If Not dv2.Count = 0 Then
            dv2.Sort = "pod_upddat desc"
            Dim drv As DataRowView = dv2(0)
            Me.StatusBar.Items("lblRight").Text = Format(drv.Item("pod_credat"), "MM/dd/yyyy") & " " & Format(drv.Item("pod_upddat"), "MM/dd/yyyy") & " " & drv.Item("pod_updusr")

            dv2.Sort = Nothing
        End If
    End Sub

    Private Sub set_cmdBackNextControl()
        Dim dtl_rowcnt As Integer = rs_QCM00002.Tables("RESULT").Rows.Count

        If dtl_rowcnt = 0 Then
            cmdBackD.Enabled = False
            cmdNextD.Enabled = False
        ElseIf dtl_rowcnt = 1 Then
            cmdBackD.Enabled = False
            cmdNextD.Enabled = False
        Else
            'Casedtl_rowcnt > 1
            If Pointer_CurQCseq = 0 Then
                cmdBackD.Enabled = False
                cmdNextD.Enabled = True
            ElseIf Pointer_CurQCseq = dtl_rowcnt - 1 Then
                cmdBackD.Enabled = True
                cmdNextD.Enabled = False
            Else
                cmdBackD.Enabled = True
                cmdNextD.Enabled = True
            End If
        End If

    End Sub

    'Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Refresh.Click
    '    If Not QCRefresh() Then
    '        Exit Sub
    '    End If
    '    FillQCDetail()
    '    FillQCHeader()
    'End Sub
#End Region

#Region "DtlPage checkbox Delete "


    Private Sub chkDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDelete.Click
        Dim Dtltbl As DataTable = rs_QCM00002.Tables("RESULT")

        If Dtltbl.Rows.Count = 0 Then
            Exit Sub
        End If

        Dtltbl.Rows(Pointer_CurQCseq).Item("qcd_ctrlstate") = "UPD"

        If chkDelete.Checked = True Then
            Dtltbl.Rows(Pointer_CurQCseq).Item("DEL") = "Y"

            For Each ctrl As Control In grp_reqdate.Controls
                If ctrl.GetType() Is GetType(CheckBox) Then
                    Dim chk As CheckBox = CType(ctrl, CheckBox)
                    chk.Checked = False
                End If
            Next
            applyChange_TabPage3(Pointer_CurQCseq)
            FillQCHeader()
            FillQCPOHeaderGrid()
            FillQCDetail()
            FillQCSummary()

        Else
            Dtltbl.Rows(Pointer_CurQCseq).Item("DEL") = ""
            MsgBox("Please Select QC Request Date!")
        End If
    End Sub
#End Region

#Region "POPage Button Control"
    Private Sub cmdBackPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBackPO.Click
        If Pointer_CurPOSeq = 0 Then
            'Prevent View Error
            Exit Sub
        Else
            'If Not QCRefresh() Then
            '    Exit Sub
            'End If
            Pointer_CurPOSeq -= 1
            set_cmdBackNextPOControl()

            FillQCPOHeader_ByRowID(Pointer_CurPOSeq)
            dg_POHeader.ClearSelection()
            dg_POHeader.Rows(Pointer_CurPOSeq).Selected = True
        End If


    End Sub

    Private Sub cmdNextPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNextPO.Click
        Dim po_rowcnt As Integer = rs_QCM00002_QCPODTL.Tables("RESULT").Rows.Count

        If Pointer_CurPOSeq = po_rowcnt - 1 Then
            Exit Sub
        Else
            'If Not QCRefresh() Then
            '    Exit Sub
            'End If
            Pointer_CurPOSeq += 1
            set_cmdBackNextPOControl()
            FillQCPOHeader_ByRowID(Pointer_CurPOSeq)
            dg_POHeader.ClearSelection()
            dg_POHeader.Rows(Pointer_CurPOSeq).Selected = True
        End If



    End Sub

    Private Sub set_cmdBackNextPOControl()
        Dim po_rowcnt As Integer = rs_QCM00002_QCPODTL.Tables("RESULT").Rows.Count

        If po_rowcnt = 0 Then
            cmdBackPO.Enabled = False
            cmdNextPO.Enabled = False
        ElseIf po_rowcnt = 1 Then
            cmdBackPO.Enabled = False
            cmdNextPO.Enabled = False
        Else
            'Casedtl_rowcnt > 1
            If Pointer_CurPOSeq = 0 Then
                cmdBackPO.Enabled = False
                cmdNextPO.Enabled = True
            ElseIf Pointer_CurPOSeq = po_rowcnt - 1 Then
                cmdBackPO.Enabled = True
                cmdNextPO.Enabled = False
            Else
                cmdBackPO.Enabled = True
                cmdNextPO.Enabled = True
            End If
        End If

    End Sub
#End Region

#Region "Function Related to Apply"
    Private Sub cmdApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApply.Click
        Recordstatus = True
        'Check Input parameter
        If Not check_ApplyParameters() Then
            Exit Sub
        End If

        If TabControl1.SelectedIndex = 0 Then
            applyChange_TabPage1()
        ElseIf TabControl1.SelectedIndex = 1 Then
            Dim row_cnt = dg_POHeader.SelectedRows.Count
            If row_cnt = 0 Then
                MsgBox("No rows are selected")
                Exit Sub
            Else
                For i As Integer = 0 To row_cnt - 1
                    Dim cur_row As DataGridViewRow = dg_POHeader.SelectedRows(i)
                    applyChange_TabPage2(cur_row.Index)
                Next
            End If


        ElseIf TabControl1.SelectedIndex = 2 Then
            applyChange_TabPage3(Pointer_CurQCseq)
        End If

        FillQCHeader()
        FillQCPOHeaderGrid()
        FillQCDetail()
        FillQCSummary()

    End Sub

    Private Function check_ApplyParameters() As Boolean
        Dim flg_haveReqDates As Boolean = False
        'Request dates
        For Each ctrl As Control In grp_reqdate.Controls
            If ctrl.GetType() Is GetType(CheckBox) Then
                Dim chk As CheckBox = CType(ctrl, CheckBox)
                If chk.Checked Then
                    flg_haveReqDates = True
                    Exit For
                End If
            End If
        Next

        If Not flg_haveReqDates Then
            MsgBox("Must have at least one Request Inspection date!")
            Exit Function
        End If

        If txt_apply_cydate.Text <> "  /  /" Then
            If (Not IsDate(txt_apply_cydate.Text) Or txt_apply_cydate.Text.Length <> 10) Then
                MsgBox("Invalid Apply CY Date!")
                Exit Function
            End If
        End If

        If txt_apply_sidate.Text <> "  /  /" Then
            If (Not IsDate(txt_apply_sidate.Text) Or txt_apply_sidate.Text.Length <> 10) Then
                MsgBox("Invalid Apply SI Date!")
                Exit Function
            End If
        End If

        check_ApplyParameters = True
    End Function

    Private Sub applyChange_TabPage1()
        Dim Hdrtbl As DataTable = rs_QCM00002Hdr.Tables("RESULT")
        Dim POtbl As DataTable = rs_QCM00002_QCPODTL.Tables("RESULT")
        Dim Dtltbl As DataTable = rs_QCM00002.Tables("RESULT")


        For Each ctrl As Control In grp_reqdate.Controls
            If ctrl.GetType() Is GetType(CheckBox) Then
                Dim chk As CheckBox = CType(ctrl, CheckBox)
                Dim day As String
                Dim daystr As String
                day = chk.Name.Split("_")(2)
                daystr = "qch_" + day
                If chk.Checked Then
                    'Use chkbox Text as weekday for simplicity
                    Hdrtbl.Rows(0).Item(daystr) = "Y"
                Else
                    Hdrtbl.Rows(0).Item(daystr) = ""
                End If
            End If
        Next

        'Hdrtbl.Rows(0).Item("qch_sidate") = If(String.Compare(txt_apply_sidate.Text, "  /  /") = 0, txt_apply_sidate.Text, "")
        'Hdrtbl.Rows(0).Item("qch_cydate") = If(String.Compare(txt_apply_cydate.Text, "  /  /") = 0, txt_apply_cydate.Text, "")
        Dim apply_sidate As String = If(String.Compare(txt_apply_sidate.Text, "  /  /") = 0, txt_apply_sidate.Text, "")
        Dim apply_cydate As String = If(String.Compare(txt_apply_cydate.Text, "  /  /") = 0, txt_apply_cydate.Text, "")


        If POtbl.Rows.Count > 0 Then
            For i As Integer = 0 To POtbl.Rows.Count - 1
                'Date
                For j As Integer = 0 To dayList.Length - 1
                    POtbl.Rows(i).Item("qpd_" + dayList(j)) = Hdrtbl.Rows(0).Item("qch_" + dayList(j))

                    Dim qpd_ctrlstate As String = POtbl.Rows(i).Item("qpd_ctrlstate")
                    If String.Compare(qpd_ctrlstate, "") = 0 Then
                        POtbl.Rows(i).Item("qpd_ctrlstate") = "UPD"
                    End If

                Next

            Next
        End If

        If Dtltbl.Rows.Count > 0 Then
            For i As Integer = 0 To Dtltbl.Rows.Count - 1
                For j As Integer = 0 To dayList.Length - 1
                    Dtltbl.Rows(i).Item("qcd_" + dayList(j)) = Hdrtbl.Rows(0).Item("qch_" + dayList(j))
                Next

                'Dtltbl.Rows(i).Item("qcd_sidate") = apply_sidate
                'Dtltbl.Rows(i).Item("qcd_cydate") = apply_cydate

                Dim qcd_ctrlstate As String = Dtltbl.Rows(i).Item("qcd_ctrlstate")
                If String.Compare(qcd_ctrlstate, "") = 0 Then
                    Dtltbl.Rows(i).Item("qcd_ctrlstate") = "UPD"
                End If
            Next
        End If


    End Sub

    Private Sub applyChange_TabPage2(ByVal rowindex As Integer)
        Dim Hdrtbl As DataTable = rs_QCM00002Hdr.Tables("RESULT")
        Dim POtbl As DataTable = rs_QCM00002_QCPODTL.Tables("RESULT")
        Dim Dtltbl As DataTable = rs_QCM00002.Tables("RESULT")

        'Dim PONo As String = dg_POHeader.Rows(rowindex).Cells("qpd_purord").Value.ToString
        Dim PONo As String = POtbl.Rows(rowindex).Item("qpd_purord")


        'PO Level
        For Each ctrl As Control In grp_reqdate.Controls
            If ctrl.GetType() Is GetType(CheckBox) Then
                Dim chk As CheckBox = CType(ctrl, CheckBox)
                Dim day As String
                Dim daystr As String
                day = chk.Name.Split("_")(2)
                daystr = "qpd_" + day
                If chk.Checked Then
                    'Use chkbox Text as weekday for simplicity
                    POtbl.Rows(rowindex).Item(daystr) = "Y"
                Else
                    POtbl.Rows(rowindex).Item(daystr) = ""
                End If
            End If
        Next

        Dim apply_sidate As String = If(String.Compare(txt_apply_sidate.Text, "  /  /") = 0, txt_apply_sidate.Text, "")
        Dim apply_cydate As String = If(String.Compare(txt_apply_cydate.Text, "  /  /") = 0, txt_apply_cydate.Text, "")

        Dim qpd_ctrlstate As String = POtbl.Rows(rowindex).Item("qpd_ctrlstate")
        If String.Compare(qpd_ctrlstate, "") = 0 Then
            POtbl.Rows(rowindex).Item("qpd_ctrlstate") = "UPD"
        End If

        'Detail Level
        Dim Applyrows As DataRow() = Dtltbl.Select("qcd_purord ='" + PONo + "'")
        If Applyrows.Length <> 0 Then
            For i As Integer = 0 To Applyrows.Length - 1

                For j As Integer = 0 To dayList.Length - 1
                    Applyrows(i).Item("qcd_" + dayList(j)) = POtbl.Rows(rowindex).Item("qpd_" + dayList(j))
                Next
                'Applyrows(i).Item("qcd_sidate") = apply_sidate
                'Applyrows(i).Item("qcd_cydate") = apply_cydate

                Dim qcd_ctrlstate As String = Applyrows(i).Item("qcd_ctrlstate")
                If qcd_ctrlstate = "" Then
                    Applyrows(i).Item("qcd_ctrlstate") = "UPD"
                End If


            Next
        End If

        'Header Level
        Dim QCWeekDay As WeekDay = New WeekDay()
        For i As Integer = 0 To Dtltbl.Rows.Count - 1
            Dim cur_row As DataRow = Dtltbl.Rows(i)
            QCWeekDay.Mon = If(cur_row.Item("qcd_mon") = "Y", True, QCWeekDay.Mon)
            QCWeekDay.Tue = If(cur_row.Item("qcd_tue") = "Y", True, QCWeekDay.Tue)
            QCWeekDay.Wed = If(cur_row.Item("qcd_wed") = "Y", True, QCWeekDay.Wed)
            QCWeekDay.Thur = If(cur_row.Item("qcd_thur") = "Y", True, QCWeekDay.Thur)
            QCWeekDay.Fri = If(cur_row.Item("qcd_fri") = "Y", True, QCWeekDay.Fri)
            QCWeekDay.Sat = If(cur_row.Item("qcd_sat") = "Y", True, QCWeekDay.Sat)
            QCWeekDay.Sun = If(cur_row.Item("qcd_sun") = "Y", True, QCWeekDay.Sun)
        Next

        For i As Integer = 0 To 6
            Hdrtbl.Rows(0).Item("qch_" + dayList(i)) = QCWeekDay.to_YFormat(i + 1)
        Next



    End Sub

    Private Sub applyChange_TabPage3(ByVal rowindex As Integer)
        Dim Hdrtbl As DataTable = rs_QCM00002Hdr.Tables("RESULT")
        Dim POtbl As DataTable = rs_QCM00002_QCPODTL.Tables("RESULT")
        Dim Dtltbl As DataTable = rs_QCM00002.Tables("RESULT")

        Dim PONo As String = Dtltbl.Rows(Pointer_CurQCseq).Item("qcd_purord")

        'Detail Level
        For Each ctrl As Control In grp_reqdate.Controls
            If ctrl.GetType() Is GetType(CheckBox) Then
                Dim chk As CheckBox = CType(ctrl, CheckBox)
                Dim day As String
                Dim daystr As String
                day = chk.Name.Split("_")(2)
                daystr = "qcd_" + day
                If chk.Checked Then
                    'Use chkbox Text as weekday for simplicity
                    Dtltbl.Rows(rowindex).Item(daystr) = "Y"
                Else
                    Dtltbl.Rows(rowindex).Item(daystr) = ""
                End If
            End If
        Next

        'Dtltbl.Rows(Pointer_CurQCseq).Item("qcd_sidate") = If(String.Compare(txt_apply_sidate.Text, "  /  /") = 0, txt_apply_sidate.Text, "")
        'Dtltbl.Rows(Pointer_CurQCseq).Item("qcd_cydate") = If(String.Compare(txt_apply_cydate.Text, "  /  /") = 0, txt_apply_cydate.Text, "")

        Dim qcd_ctrlstate As String = Dtltbl.Rows(Pointer_CurQCseq).Item("qcd_ctrlstate")
        If qcd_ctrlstate = "" Then
            Dtltbl.Rows(Pointer_CurQCseq).Item("qcd_ctrlstate") = "UPD"
        End If




        'PO Level
        Dim Applyrows As DataRow() = POtbl.Select("qpd_purord ='" + PONo + "'")
        'Avoid 9insert type in QCDetail level
        If Applyrows.Length <> 0 Then
            Dim Dtlrows As DataRow() = Dtltbl.Select("qcd_purord = '" + PONo + "'")
            Dim POWeekDay As WeekDay = New WeekDay()
            For i As Integer = 0 To Dtlrows.Length - 1
                Dim cur_row As DataRow = Dtltbl.Rows(i)
                POWeekDay.Mon = If(cur_row.Item("qcd_mon") = "Y", True, POWeekDay.Mon)
                POWeekDay.Tue = If(cur_row.Item("qcd_tue") = "Y", True, POWeekDay.Tue)
                POWeekDay.Wed = If(cur_row.Item("qcd_wed") = "Y", True, POWeekDay.Wed)
                POWeekDay.Thur = If(cur_row.Item("qcd_thur") = "Y", True, POWeekDay.Thur)
                POWeekDay.Fri = If(cur_row.Item("qcd_fri") = "Y", True, POWeekDay.Fri)
                POWeekDay.Sat = If(cur_row.Item("qcd_sat") = "Y", True, POWeekDay.Sat)
                POWeekDay.Sun = If(cur_row.Item("qcd_sun") = "Y", True, POWeekDay.Sun)
            Next

            For i As Integer = 0 To 6
                Applyrows(0).Item("qpd_" + dayList(i)) = POWeekDay.to_YFormat(i + 1)
            Next

            Dim qpd_ctrlstate As String = Applyrows(0).Item("qpd_ctrlstate")
            If qpd_ctrlstate = "" Then
                Applyrows(0).Item("qpd_ctrlstate") = "UPD"
            End If

        End If

        'Header Level
        Dim QCWeekDay As WeekDay = New WeekDay()
        For i As Integer = 0 To Dtltbl.Rows.Count - 1
            Dim cur_row As DataRow = Dtltbl.Rows(i)
            QCWeekDay.Mon = If(cur_row.Item("qcd_mon") = "Y", True, QCWeekDay.Mon)
            QCWeekDay.Tue = If(cur_row.Item("qcd_tue") = "Y", True, QCWeekDay.Tue)
            QCWeekDay.Wed = If(cur_row.Item("qcd_wed") = "Y", True, QCWeekDay.Wed)
            QCWeekDay.Thur = If(cur_row.Item("qcd_thur") = "Y", True, QCWeekDay.Thur)
            QCWeekDay.Fri = If(cur_row.Item("qcd_fri") = "Y", True, QCWeekDay.Fri)
            QCWeekDay.Sat = If(cur_row.Item("qcd_sat") = "Y", True, QCWeekDay.Sat)
            QCWeekDay.Sun = If(cur_row.Item("qcd_sun") = "Y", True, QCWeekDay.Sun)
        Next

        For i As Integer = 0 To 6
            Hdrtbl.Rows(0).Item("qch_" + dayList(i)) = QCWeekDay.to_YFormat(i + 1)
        Next




    End Sub


#End Region



#Region "Function Related to Save"
    Private Function check_QCSave() As Boolean
        check_QCSave = False

        Dim Hdrtbl As DataTable = rs_QCM00002Hdr.Tables("RESULT")
        Dim POtbl As DataTable = rs_QCM00002_QCPODTL.Tables("RESULT")
        Dim Dtltbl As DataTable = rs_QCM00002.Tables("RESULT")

        If save_mode = "UPD" Then
            'Check Dtl records with no request date
            Dim dr() As DataRow = Dtltbl.Select("`DEL` = ''")
            If dr.Length <> 0 Then
                For i As Integer = 0 To dr.Length - 1
                    If dr(i).Item("qcd_mon") = "" And dr(i).Item("qcd_tue") = "" And dr(i).Item("qcd_wed") = "" And dr(i).Item("qcd_thur") = "" And dr(i).Item("qcd_fri") = "" And dr(i).Item("qcd_sat") = "" And dr(i).Item("qcd_sun") = "" Then
                        MsgBox("There exists QC Detail which have no QC Request Date!")
                        Exit Function
                    End If

                Next
            End If




        ElseIf save_mode = "ADD" Then
            '20151026 - Allow no QC Records. Hell!
            'Check Dtl records
            'If Dtltbl.Rows.Count = 0 Then
            '    MsgBox("No QC Detail!")
            '    Exit Function
            'Else
            '    Dim dr() As DataRow = Dtltbl.Select("`DEL` = ''")
            '    If dr.Length = 0 Then
            '        MsgBox("No QC Detail!")
            '        Exit Function
            '    End If
            'End If

        End If

        check_QCSave = True

    End Function


    Public Function QCSave() As Boolean
        QCSave = False

        Dim Hdrtbl As DataTable = rs_QCM00002Hdr.Tables("RESULT")
        Dim POtbl As DataTable = rs_QCM00002_QCPODTL.Tables("RESULT")
        Dim Dtltbl As DataTable = rs_QCM00002.Tables("RESULT")

        If Not save_QCREQHDR() Then
            Exit Function
        End If

        If Not save_QCVENINF() Then
            Exit Function
        End If

        If POtbl.Rows.Count > 0 Then
            If Not save_QCPORDTL() Then
                Exit Function
            End If
        End If

        If Dtltbl.Rows.Count > 0 Then
            If Not save_QCREQDTL() Then
                Exit Function
            End If
        End If




        QCSave = True
    End Function

    Private Function save_QCREQHDR() As Boolean
        save_QCREQHDR = False
        Dim Hdrtbl As DataTable = rs_QCM00002Hdr.Tables("RESULT")
        Dim hdr_currow As DataRow = Hdrtbl.Rows(0)
        Dim ctrlstate As String = Hdrtbl.Rows(0).Item("qch_ctrlstate")

        'Update QCREQHDR

        If String.Compare(ctrlstate, "UPD") = 0 Then
            gspStr = "sp_update_QCREQHDR '" & _
              hdr_currow.Item("qch_cocde") & "','" & _
              hdr_currow.Item("qch_qcno") & "','" & _
              hdr_currow.Item("qch_qcsts") & "','" & _
              hdr_currow.Item("qch_insptyp") & "','" & _
              hdr_currow.Item("qch_mon") & "','" & _
              hdr_currow.Item("qch_tue") & "','" & _
              hdr_currow.Item("qch_wed") & "','" & _
              hdr_currow.Item("qch_thur") & "','" & _
              hdr_currow.Item("qch_fri") & "','" & _
              hdr_currow.Item("qch_sat") & "','" & _
              hdr_currow.Item("qch_sun") & "','" & _
              hdr_currow.Item("qch_sidate") & "','" & _
              hdr_currow.Item("qch_cydate") & "','" & _
              hdr_currow.Item("qch_cispdate") & "','" & _
              hdr_currow.Item("qch_rmk") & "','" & _
              hdr_currow.Item("qch_samhdl") & "','" & _
              gsUsrID & "'"

            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Cursor = Cursors.Default
                MsgBox("Error on loading sp_update_QCREQHDR:" & rtnStr)
                Exit Function
            End If
        ElseIf String.Compare(ctrlstate, "ADD") = 0 Then
            'Insert function

            Dim rs_docno As DataSet
            gspStr = "sp_select_DOC_GEN '" & "','QC','" & gsUsrID & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_docno, rtnStr)

            If rtnLong <> RC_SUCCESS Then
                Cursor = Cursors.Default
                MsgBox("Error on loading sp_select_DOC_GEN:" & rtnStr)
                Exit Function
            End If


            hdr_currow.Item("qch_qcno") = rs_docno.Tables("RESULT").Rows(0).Item(0).ToString
            Dim qch_flgautogen As String = ""
            Dim qch_rmk As String = txt_HRmk.Text


            gspStr = "sp_insert_QCREQHDR '" & _
                hdr_currow.Item("qch_cocde") & "','" & _
                hdr_currow.Item("qch_qcno") & "','" & _
                hdr_currow.Item("qch_qcsts") & "','" & _
                qch_flgautogen & "','" & _
                hdr_currow.Item("qch_venno") & "','" & _
                hdr_currow.Item("qch_prmcus") & "','" & _
                hdr_currow.Item("qch_seccus") & "','" & _
                hdr_currow.Item("qch_inspyear") & "','" & _
                hdr_currow.Item("qch_inspweek") & "','" & _
                hdr_currow.Item("qch_insptyp") & "','" & _
                hdr_currow.Item("qch_mon") & "','" & _
                hdr_currow.Item("qch_tue") & "','" & _
                hdr_currow.Item("qch_wed") & "','" & _
                hdr_currow.Item("qch_thur") & "','" & _
                hdr_currow.Item("qch_fri") & "','" & _
                hdr_currow.Item("qch_sat") & "','" & _
                hdr_currow.Item("qch_sun") & "','" & _
                hdr_currow.Item("qch_samhdl") & "','" & _
                hdr_currow.Item("qch_sidate") & "','" & _
                hdr_currow.Item("qch_cydate") & "','" & _
                hdr_currow.Item("qch_cispdate") & "','" & _
                qch_rmk & "','" & _
                gsUsrID & "'"

            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Cursor = Cursors.Default
                MsgBox("Error on loading sp_insert_QCREQHDR:" & rtnStr)
                Exit Function
            End If




        End If

        save_QCREQHDR = True
    End Function

    Private Function save_QCPORDTL() As Boolean
        save_QCPORDTL = False
        Dim POtbl As DataTable = rs_QCM00002_QCPODTL.Tables("RESULT")
        Dim Hdrtbl As DataTable = rs_QCM00002Hdr.Tables("RESULT")


        For i As Integer = 0 To POtbl.Rows.Count - 1
            Dim currow As DataRow = POtbl.Rows(i)
            Dim ctrlstate As String = currow.Item("qpd_ctrlstate")

            If String.Compare(currow.Item("qpd_ctrlstate"), "UPD") = 0 Then
                gspStr = "sp_update_QCPORDTL '" & _
                    currow.Item("qpd_cocde") & "','" & _
                    currow.Item("qpd_qcno") & "','" & _
                    currow.Item("qpd_qcposeq") & "','" & _
                    currow.Item("qpd_del") & "','" & _
                    currow.Item("qpd_mon") & "','" & _
                    currow.Item("qpd_tue") & "','" & _
                    currow.Item("qpd_wed") & "','" & _
                    currow.Item("qpd_thur") & "','" & _
                    currow.Item("qpd_fri") & "','" & _
                    currow.Item("qpd_sat") & "','" & _
                    currow.Item("qpd_sun") & "','" & _
                    currow.Item("qpd_rmk") & "','" & _
                    gsUsrID & "'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    Cursor = Cursors.Default
                    MsgBox("Error on loading sp_update_QCPORDTL:" & rtnStr)
                    Exit Function
                End If
            ElseIf String.Compare(currow.Item("qpd_ctrlstate"), "ADD") = 0 Then
                'INSERT sp
                gspStr = "sp_insert_QCPORDTL '" & Hdrtbl.Rows(0).Item("qch_cocde") & "','" & _
                    Hdrtbl.Rows(0).Item("qch_qcno") & "','" & _
                    currow.Item("qpd_qcposeq") & "','" & _
                    currow.Item("qpd_purord") & "','" & _
                    currow.Item("qpd_mon") & "','" & _
                    currow.Item("qpd_tue") & "','" & _
                    currow.Item("qpd_wed") & "','" & _
                    currow.Item("qpd_thur") & "','" & _
                    currow.Item("qpd_fri") & "','" & _
                    currow.Item("qpd_sat") & "','" & _
                    currow.Item("qpd_sun") & "','" & _
                    currow.Item("qpd_rmk") & "','" & _
                    gsUsrID & "'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    Cursor = Cursors.Default
                    MsgBox("Error on loading sp_insert_QCPORDTL:" & rtnStr)
                    Exit Function
                End If

            End If

        Next


        save_QCPORDTL = True
    End Function

    Private Function save_QCREQDTL() As Boolean
        save_QCREQDTL = False

        Dim Hdrtbl As DataTable = rs_QCM00002Hdr.Tables("RESULT")
        Dim Dtltbl As DataTable = rs_QCM00002.Tables("RESULT")

        For i As Integer = 0 To Dtltbl.Rows.Count - 1
            Dim currow As DataRow = Dtltbl.Rows(i)
            Dim ctrlstate As String = currow.Item("qcd_ctrlstate")
            Dim flg_delete As String = currow.Item("DEL").ToString

            'Dim qcd_sidate As String = If(currow.Item("qcd_sidate") = "  /  /", "", currow.Item("qcd_sidate"))
            'Dim qcd_cydate As String = If(currow.Item("qcd_cydate") = "  /  /", "", currow.Item("qcd_cydate"))

            'Dim qcd_sidate As String = ""
            'Dim qcd_cydate As String = ""

            If String.Compare(ctrlstate, "UPD") = 0 Then
                If flg_delete = "Y" Then
                    'This sp will set QCREQHDR, QCPORDTL status to 'DEL' if necessary
                    gspStr = "sp_delete_QCREQDTL '" & _
                        currow.Item("qcd_cocde") & "','" & _
                        currow.Item("qcd_qcno") & "','" & _
                        currow.Item("qcd_qcseq") & "','" & _
                        currow.Item("qcd_flgpolink") & "','" & _
                        currow.Item("qcd_qcposeq") & "','" & _
                        gsUsrID & "'"

                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)

                    If rtnLong <> RC_SUCCESS Then
                        Cursor = Cursors.Default
                        MsgBox("Error on loading sp_delete_QCREQDTL:" & rtnStr)
                        Exit Function
                    End If


                Else
                    'Update 
                    gspStr = "sp_update_QCREQDTL '" & _
                    currow.Item("qcd_cocde") & "','" & _
                    currow.Item("qcd_qcno") & "','" & _
                    currow.Item("qcd_qcseq") & "','" & _
                    currow.Item("qcd_dtlsts") & "','" & _
                    currow.Item("qcd_mon") & "','" & _
                    currow.Item("qcd_tue") & "','" & _
                    currow.Item("qcd_wed") & "','" & _
                    currow.Item("qcd_thur") & "','" & _
                    currow.Item("qcd_fri") & "','" & _
                    currow.Item("qcd_sat") & "','" & _
                    currow.Item("qcd_sun") & "','" & _
                    currow.Item("qcd_samhdl") & "','" & _
                    currow.Item("qcd_rmk") & "','" & _
 _
                    currow.Item("qcd_xitmno") & "','" & _
                    currow.Item("qcd_xitmdsc") & "','" & _
                    currow.Item("qcd_xcolor") & "','" & _
                    currow.Item("qcd_xpack") & "','" & _
                    currow.Item("qcd_xmtrdcm") & "','" & _
                    currow.Item("qcd_xmtrwcm") & "','" & _
                    currow.Item("qcd_xmtrhcm") & "','" & _
                    currow.Item("qcd_xinrdcm") & "','" & _
                    currow.Item("qcd_xinrwcm") & "','" & _
                    currow.Item("qcd_xinrhcm") & "','" & _
                    currow.Item("qcd_xgrswgt") & "','" & _
                    currow.Item("qcd_xnetwgt") & "','" & _
                    currow.Item("qcd_ordqty") & "','" & _
 _
                    gsUsrID & "'"


                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        Cursor = Cursors.Default
                        MsgBox("Error on loading sp_update_QCREQDTL:" & rtnStr)
                        Exit Function
                    End If
                End If


            ElseIf String.Compare(ctrlstate, "ADD") = 0 Then
                'insert


                If flg_delete <> "Y" Then
                    gspStr = "sp_insert_QCREQDTL '" & Hdrtbl.Rows(0).Item("qch_cocde") & "','" & _
                     Hdrtbl.Rows(0).Item("qch_qcno") & "','" & _
                     currow.Item("qcd_qcseq") & "','" & _
                     currow.Item("qcd_dtlsts") & "','" & _
                     currow.Item("qcd_genby") & "','" & _
                     currow.Item("qcd_flgpolink") & "','" & _
                     currow.Item("qcd_qcposeq") & "','" & _
                     currow.Item("qcd_purord") & "','" & _
                     currow.Item("qcd_purseq") & "','" & _
 _
                     currow.Item("qcd_mon") & "','" & _
                     currow.Item("qcd_tue") & "','" & _
                     currow.Item("qcd_wed") & "','" & _
                     currow.Item("qcd_thur") & "','" & _
                     currow.Item("qcd_fri") & "','" & _
                     currow.Item("qcd_sat") & "','" & _
                     currow.Item("qcd_sun") & "','" & _
                     currow.Item("qcd_samhdl") & "','" & _
                     currow.Item("qcd_rmk") & "','" & _
 _
                    currow.Item("qcd_xitmno") & "','" & _
                    currow.Item("qcd_xitmdsc") & "','" & _
                    currow.Item("qcd_xcolor") & "','" & _
                    currow.Item("qcd_xpack") & "','" & _
                    currow.Item("qcd_xmtrdcm") & "','" & _
                    currow.Item("qcd_xmtrwcm") & "','" & _
                    currow.Item("qcd_xmtrhcm") & "','" & _
                    currow.Item("qcd_xinrdcm") & "','" & _
                    currow.Item("qcd_xinrwcm") & "','" & _
                    currow.Item("qcd_xinrhcm") & "','" & _
                    currow.Item("qcd_xgrswgt") & "','" & _
                    currow.Item("qcd_xnetwgt") & "','" & _
                    currow.Item("qcd_ordqty") & "','" & _
 _
                     gsUsrID & "'"


                    '                   gspStr = "sp_insert_QCREQDTL '" & gsCompany & "','" & _
                    '                    Hdrtbl.Rows(0).Item("qch_qcno") & "','" & _
                    '                    currow.Item("qcd_qcseq") & "','" & _
                    '                    currow.Item("qcd_dtlsts") & "','" & _
                    '                    currow.Item("qcd_genby") & "','" & _
                    '                    currow.Item("qcd_flgpolink") & "','" & _
                    '                    currow.Item("qcd_qcposeq") & "','" & _
                    '                    currow.Item("qcd_purord") & "','" & _
                    '                    currow.Item("qcd_purseq") & "','" & _
                    '_
                    '                    currow.Item("qcd_mon") & "','" & _
                    '                    currow.Item("qcd_tue") & "','" & _
                    '                    currow.Item("qcd_wed") & "','" & _
                    '                    currow.Item("qcd_thur") & "','" & _
                    '                    currow.Item("qcd_fri") & "','" & _
                    '                    currow.Item("qcd_sat") & "','" & _
                    '                    currow.Item("qcd_sun") & "','" & _
                    '                    currow.Item("qcd_samhdl") & "','" & _
                    '                    currow.Item("qcd_sidate") & "','" & _
                    '                    currow.Item("qcd_cydate") & "','" & _
                    '                    currow.Item("qcd_rmk") & "','" & _
                    '_
                    '                   currow.Item("qcd_xitmno") & "','" & _
                    '_
                    '                    gsUsrID & "'"


                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        Cursor = Cursors.Default
                        MsgBox("Error on loading sp_insert_QCREQDTL:" & rtnStr)
                        Exit Function
                    End If

                End If
            End If

        Next

        save_QCREQDTL = True
    End Function

    Private Function save_QCVENINF() As Boolean
        save_QCVENINF = False

        Dim Hdrtbl As DataTable = rs_QCM00002Hdr.Tables("RESULT")
        Dim hdr_currow As DataRow = Hdrtbl.Rows(0)
        Dim ctrlstate As String = Hdrtbl.Rows(0).Item("qch_ctrlstate")

        If ctrlstate = "ADD" Then
            gspStr = "sp_insert_QCVENINF_QCM00002 '" & _
             hdr_currow.Item("qch_cocde") & "','" & _
             hdr_currow.Item("qch_qcno") & "','" & _
             hdr_currow.Item("qch_venno") & "','" & _
             hdr_currow.Item("qvi_adr") & "','" & _
             hdr_currow.Item("qvi_cty") & "','" & _
             hdr_currow.Item("qvi_stt") & "','" & _
             hdr_currow.Item("qvi_city") & "','" & _
             hdr_currow.Item("qvi_town") & "','" & _
             hdr_currow.Item("qvi_zip") & "','" & _
             hdr_currow.Item("qvi_cntctp") & "','" & _
             hdr_currow.Item("qvi_cnttil") & "','" & _
             hdr_currow.Item("qvi_cntphn") & "','" & _
             hdr_currow.Item("qvi_cntfax") & "','" & _
             hdr_currow.Item("qvi_cnteml") & "','" & _
             gsUsrID & "'"

            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Cursor = Cursors.Default
                MsgBox("Error on loading sp_insert_QCVENINF_QCM00002:" & rtnStr)
                Exit Function
            End If

        ElseIf ctrlstate = "UPD" Then
            gspStr = "sp_update_QCVENINF_QCM00002 '" & _
                hdr_currow.Item("qch_cocde") & "','" & _
                hdr_currow.Item("qch_qcno") & "','" & _
                hdr_currow.Item("qch_venno") & "','" & _
                hdr_currow.Item("qvi_adr") & "','" & _
                hdr_currow.Item("qvi_cty") & "','" & _
                hdr_currow.Item("qvi_stt") & "','" & _
                hdr_currow.Item("qvi_city") & "','" & _
                hdr_currow.Item("qvi_town") & "','" & _
                hdr_currow.Item("qvi_zip") & "','" & _
                hdr_currow.Item("qvi_cntctp") & "','" & _
                hdr_currow.Item("qvi_cnttil") & "','" & _
                hdr_currow.Item("qvi_cntphn") & "','" & _
                hdr_currow.Item("qvi_cntfax") & "','" & _
                hdr_currow.Item("qvi_cnteml") & "','" & _
                gsUsrID & "'"

            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Cursor = Cursors.Default
                MsgBox("Error on loading sp_update_QCVENINF_QCM00002:" & rtnStr)
                Exit Function
            End If

        End If

        save_QCVENINF = True
    End Function


#End Region

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        mmdDelRow.Enabled = False
        If TabControl1.SelectedIndex = 0 Then
            grp_apply.Parent = TabPage1
        ElseIf TabControl1.SelectedIndex = 1 Then
            grp_apply.Parent = TabPage2
        ElseIf TabControl1.SelectedIndex = 2 Then
            mmdDelRow.Enabled = True
            grp_apply.Parent = TabPage3
        End If

        Set_grp_apply_Control()
    End Sub

    Private Sub Set_grp_apply_Control()
        If rs_QCM00002.Tables("RESULT").Rows.Count = 0 Then
            grp_apply.Enabled = False
        Else
            grp_apply.Enabled = True
        End If
    End Sub

    Private Sub FillWeekBox(ByVal WeekCombo As ComboBox, ByVal base_week As Integer, ByVal base_year As Integer)
        today = Date.Today
        Dim conf_weekshown As Integer = 3
        Dim flg_from_lastyear As Boolean = False
        Dim flg_overlap_nextyear As Boolean = False
        Dim flg_count_as_nextyear As Boolean = False

        Dim cur_week As Integer = base_week
        Dim cur_year As Integer = today.Year 'base_year
        Dim prev_year As Integer = cur_year - 1
        Dim next_year As Integer = cur_year + 1

        If cur_week <= 0 Then
            flg_from_lastyear = True

        End If

        If Not (today.AddDays(3).Year = today.Year) And (today.DayOfWeek = DayOfWeek.Monday Or today.DayOfWeek = DayOfWeek.Tuesday Or today.DayOfWeek = DayOfWeek.Wednesday) Then
            flg_count_as_nextyear = True
        End If

        If cur_week <= LastWeekOfYear(cur_year) And cur_week >= LastWeekOfYear(cur_year) - conf_weekshown + 1 And Not (flg_count_as_nextyear) Then
            flg_overlap_nextyear = True
            cboYear_PanelAdd.Enabled = True
        End If

        WeekCombo.Items.Clear()

        If flg_from_lastyear Then
            Dim _week As Integer = LastWeekOfYear(prev_year)
            cboYear_PanelAdd.Enabled = True

            If cboYear_PanelAdd.Items.Contains(prev_year) = False Then
                cboYear_PanelAdd.Items.Add(prev_year)
            End If

            'sort the year
            If cboYear_PanelAdd.Items.Count() = 2 And cboYear_PanelAdd.Items.Item(0) > cboYear_PanelAdd.Items.Item(1) Then
                Dim temp As Integer = cboYear_PanelAdd.Items.Item(0)
                cboYear_PanelAdd.Items.Item(0) = cboYear_PanelAdd.Items.Item(1)
                cboYear_PanelAdd.Items.Item(1) = temp
            End If

            If cboYear_PanelAdd.SelectedItem = cur_year Then
                For i As Integer = 0 To conf_weekshown - 2
                    WeekCombo.Items.Add(gen_WeekString(cur_year, i + 1))
                Next
            Else
                WeekCombo.Items.Add(gen_WeekString(prev_year, LastWeekOfYear(prev_year)))
            End If
        ElseIf flg_overlap_nextyear Then
            If cboYear_PanelAdd.Items.Contains(next_year) = False Then

                cboYear_PanelAdd.Items.Add(next_year)
            End If


            'For i As Integer = 1 To conf_weekshown - week_cnt
            '    WeekCombo.Items.Add(gen_WeekString(next_year, i))
            'Next
            '
            'The week of next year will be added when the next year is selected

            Dim week_cnt As Integer = LastWeekOfYear(cur_year) - cur_week + 1
            If cboYear_PanelAdd.SelectedItem = cur_year Then
                For i As Integer = 1 To week_cnt
                    WeekCombo.Items.Add(gen_WeekString(cur_year, LastWeekOfYear(cur_year) - week_cnt + i))
                Next
            Else
                For i As Integer = 1 To conf_weekshown - week_cnt
                    WeekCombo.Items.Add(gen_WeekString(next_year, i))
                Next
            End If
        ElseIf flg_count_as_nextyear Then

            For i As Integer = 0 To conf_weekshown - 1
                WeekCombo.Items.Add(gen_WeekString(next_year, i + 1))
            Next
            If cboYear_PanelAdd.SelectedItem = cur_year Then

                cboYear_PanelAdd.Items.Clear()
                cboYear_PanelAdd.Items.Add(next_year)
            End If
            cboYear_PanelAdd.SelectedIndex = 0

        Else
            For i As Integer = 0 To conf_weekshown - 1
                WeekCombo.Items.Add(gen_WeekString(cur_year, cur_week + i))
            Next
        End If

        WeekCombo.SelectedIndex = 0

    End Sub

    Private Sub dg_Summary_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_Summary.CellClick
        Dim QCtbl As DataTable = rs_QCM00002.Tables("RESULT")
        If e.RowIndex >= 0 Then

            If e.ColumnIndex = 0 And cboStatus.Text.Trim = "OPE" Then

                dg_Summary.Columns(e.ColumnIndex).ReadOnly = False

                If dg_Summary.Columns(e.ColumnIndex).ReadOnly = False Then
                    rs_QCM00002.Tables("RESULT").Rows(e.RowIndex).Item("qcd_ctrlstate") = "UPD"

                    If rs_QCM00002.Tables("RESULT").Rows(e.RowIndex)("Del").ToString = "Y" Then
                        rs_QCM00002.Tables("RESULT").Rows(e.RowIndex)("Del") = "N"
                        chkDelete.Checked = False
                    Else
                        rs_QCM00002.Tables("RESULT").Rows(e.RowIndex)("Del") = "Y"
                        chkDelete.Checked = True
                    End If
                    rs_QCM00002.Tables("RESULT").AcceptChanges()
                End If
            End If
            FillSummayGrid()

        End If


        If e.RowIndex >= 0 Then
            'Dim qc_pointer As String =

            For index As Integer = 0 To QCtbl.Rows.Count - 1
                If QCtbl.Rows(index).Item("qcd_qcseq") = dg_Summary.Rows(e.RowIndex).Cells("qcd_qcseq").Value.ToString Then
                    Pointer_CurQCseq = index
                    FillQCDetail()
                    set_cmdBackNextControl()
                End If
            Next

        End If
    End Sub

#Region "Function & Event Related to PanelAdd"
    Private Function clear_PanelAdd()
        cboVenno_PanelAdd.Text = ""
        cboCus1no_PanelAdd.Text = ""
        cboCus2no_PanelAdd.Text = ""

        For Each ctrl As Control In PanelAdd_groupbox2.Controls
            If ctrl.GetType() Is GetType(CheckBox) Then
                Dim chk As CheckBox = CType(ctrl, CheckBox)
                chk.Checked = False
            End If
        Next


    End Function

    Private Sub display_PanelAdd(ByVal flag As Boolean)
        PanelAdd.Visible = True


        mmdAdd.Enabled = Not flag
        mmdFind.Enabled = Not flag
        mmdSearch.Enabled = Not flag
        txtQCno.Enabled = Not flag

        If flag Then
            TabControl1.Enabled = flag
            'TabPage1.Enabled = flag
            PanelAdd.Size = New Size(795, 444)
        Else
            TabControl1.Enabled = flag
            'TabPage1.Enabled = flag
            PanelAdd.Size = New Size(0, 0)
        End If


    End Sub

    Private Sub cmdGo_PanelAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGo_PanelAdd.Click
        If Not check_cmdGo_PanelAdd() Then
            Exit Sub
        End If


        display_PanelAdd(False)

        If QCAdd() Then
        End If
    End Sub

    Private Function check_cmdGo_PanelAdd() As Boolean
        check_cmdGo_PanelAdd = False

        If cboCus1no_PanelAdd.Text = "" Then
            MsgBox("Missing Primary Customer")
            Exit Function
        End If

        If cboVenno_PanelAdd.Text = "" Then
            MsgBox("Missing Vendor No")
            Exit Function
        End If

        Dim tmp_cnt As Integer = 0
        For Each ctrl As Control In PanelAdd_groupbox2.Controls
            If ctrl.GetType() Is GetType(CheckBox) Then
                Dim chk As CheckBox = CType(ctrl, CheckBox)
                If chk.Checked = True Then
                    tmp_cnt = tmp_cnt + 1
                End If
            End If
        Next

        If tmp_cnt = 0 Then
            MsgBox("Missing Inspection Date")
            Exit Function
        End If

        'Check Rights to Create
        gspStr = "sp_select_SYUSRRIGHT_CHECK '" & cboCoCde.Text & "','" & _
            gsUsrID & "','" & _
            Split(cboCus1no_PanelAdd.Text, " - ")(0) & "','" & _
            "CU'"

        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_select_SYUSRRIGHT_CHECK :" & rtnStr)
            Exit Function
        End If

        If rs.Tables(0).Rows.Count = 0 Then
            MsgBox("YOu have no rights to create QC with this Customer")
            Exit Function
        End If

        check_cmdGo_PanelAdd = True
    End Function

    Private Sub cmdquit_PanelAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdquit_PanelAdd.Click
        display_PanelAdd(False)
    End Sub




    Private Sub cboCocde_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCoCde.KeyUp
        auto_search_combo(cboCoCde)
    End Sub


    Private Sub fillcboVendor()

        gspStr = "sp_list_VNBASINF ''"
        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading CLM00001_Load sp_list_VNBASINF :" & rtnStr)
            Exit Sub
        End If


        Dim i As Integer
        Dim strList As String

        cboVenno_PanelAdd.Items.Clear()

        If rs_VNBASINF.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_VNBASINF.Tables("RESULT").Rows.Count - 1
                strList = rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_vensna")
                If strList <> "" Then
                    cboVenno_PanelAdd.Items.Add(strList)
                End If
            Next i
        End If
    End Sub

    Private Sub cboVendor_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVenno_PanelAdd.KeyUp
        If cboVenno_PanelAdd.Text.Length > 0 Then
            If e.KeyCode <> Keys.Back Then
                sHdrVendor = cboVenno_PanelAdd.Text
                auto_search_combo(cboVenno_PanelAdd)
            Else
                cboVenno_PanelAdd.Text = sHdrVendor.Substring(0, sHdrVendor.Length - 1)
                auto_search_combo(cboVenno_PanelAdd)
                sHdrVendor = sHdrVendor.Substring(0, sHdrVendor.Length - 1)
            End If
        End If
    End Sub

    Private Sub cboVendor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboVenno_PanelAdd.Validating
        Dim i As Integer
        Dim Y As Integer
        Dim inCombo As Boolean

        i = cboVenno_PanelAdd.Items.Count
        If cboVenno_PanelAdd.Text <> "" And cboVenno_PanelAdd.Enabled = True And cboVenno_PanelAdd.Items.Count > 0 Then
            For Y = 0 To i - 1
                If Trim(cboVenno_PanelAdd.Text) = Trim(cboVenno_PanelAdd.Items(Y)) Then
                    inCombo = True
                End If
            Next

            If inCombo = False Then

                cboVenno_PanelAdd.Text = ""
                cboVenno_PanelAdd.Focus()

            Else

            End If
        End If
    End Sub

    Private Sub fillcboPriCust()

        gspStr = "sp_select_CUBASINF_CA '','" & gsUsrID & "','QU','Primary'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_P, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading CLM00001_Load sp_list_CUBASINF :" & rtnStr)
            Exit Sub
        End If


        Dim dr() As DataRow
        '        If addFlag = True Then


        gspStr = "sp_select_CUBASINF_CA '','" & gsUsrID & "','QU','Primary'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_P, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading CLM00001_Load sp_list_CUBASINF :" & rtnStr)
            Exit Sub
        End If

        dr = rs_CUBASINF_P.Tables("RESULT").Select("cbi_cusno >= '50000'")
        'Else
        'dr = rs_CUBASINF_P.Tables("RESULT").Select("")
        'End If

        If dr.Length > 0 Then
            cboCus1no_PanelAdd.Items.Clear()

            For i As Integer = 0 To dr.Length - 1
                cboCus1no_PanelAdd.Items.Add(dr(i).Item("cbi_cusno") & " - " & dr(i).Item("cbi_cussna"))
            Next
        End If

    End Sub

    Private Sub cboPriCust_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCus1no_PanelAdd.SelectedIndexChanged
        Call cboPriCustClick()
        If checkValidCombo(cboCus1no_PanelAdd, cboCus1no_PanelAdd.Text) Then
            Call format_cboSecCust(Split(cboCus1no_PanelAdd.Text, " - ")(0).ToString)
        End If
    End Sub

    Private Sub cboPriCust_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboCus1no_PanelAdd.Validating
        Dim i As Integer
        Dim Y As Integer
        Dim inCombo As Boolean

        i = cboCus1no_PanelAdd.Items.Count
        If cboCus1no_PanelAdd.Text <> "" And cboCus1no_PanelAdd.Enabled = True And cboCus1no_PanelAdd.Items.Count > 0 Then
            For Y = 0 To i - 1
                If Trim(cboCus1no_PanelAdd.Text) = Trim(cboCus1no_PanelAdd.Items(Y)) Then
                    inCombo = True
                End If
            Next

            If inCombo = False Then

                cboCus1no_PanelAdd.Text = ""
                cboCus1no_PanelAdd.Focus()

            Else

            End If
        End If
    End Sub

    Private Sub cboPriCust_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCus1no_PanelAdd.KeyUp
        If cboCus1no_PanelAdd.Text.Length > 0 Then
            If e.KeyCode <> Keys.Back Then
                sHdrPriCust = cboCus1no_PanelAdd.Text
                auto_search_combo(cboCus1no_PanelAdd)
            Else
                cboCus1no_PanelAdd.Text = sHdrPriCust.Substring(0, sHdrPriCust.Length - 1)
                auto_search_combo(cboCus1no_PanelAdd)
                sHdrPriCust = sHdrPriCust.Substring(0, sHdrPriCust.Length - 1)
            End If
        End If
    End Sub

    Private Sub cboPriCustClick()
        Dim dr() As DataRow

        If cboCus1no_PanelAdd.Text <> "" Then
            cboCus2no_PanelAdd.Items.Clear()
            cboCus2no_PanelAdd.Text = ""

            If InStr(cboCus1no_PanelAdd.Text, " - ") - 1 >= 0 Then
                dr = rs_CUBASINF_P.Tables("RESULT").Select("cbi_cusno = " & "'" & Microsoft.VisualBasic.Left(cboCus1no_PanelAdd.Text, InStr(cboCus1no_PanelAdd.Text, " - ") - 1) & "'")
            End If



            gsCompany = Trim(cboCoCde.Text)
            Call Update_gs_Value(gsCompany)

            gspStr = "sp_select_CUBASINF_Q '" & cboCoCde.Text & "','" & Microsoft.VisualBasic.Left(cboCus1no_PanelAdd.Text, InStr(cboCus1no_PanelAdd.Text, " - ") - 1) & "','Secondary'"
            rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_S, rtnStr)
            gspStr = ""

            '' Cursor = Cursors.Default

            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cboPriCustClick sp_select_CUBASINF_Q 2 :" & rtnStr)
                '' Cursor = Cursors.Default
                Exit Sub
            End If

            If rs_CUBASINF_S.Tables("RESULT").Rows.Count = 0 Then       '***  Not Found Record
                cboCus2no_PanelAdd.Enabled = False
            Else
                cboCus2no_PanelAdd.Enabled = True
                cboCus2no_PanelAdd.Items.Clear()
                cboCus2no_PanelAdd.Text = ""

                dr = rs_CUBASINF_S.Tables("RESULT").Select("csc_seccus >= 60000")

                If Not dr Is Nothing Then
                    'possible bug ?
                    'If dr.Length > 1 Then
                    If dr.Length > 0 Then
                        For index As Integer = 0 To dr.Length - 1
                            cboCus2no_PanelAdd.Items.Add(dr(index)("csc_seccus").ToString + " - " + dr(index)("cbi_cussna").ToString)
                        Next
                    End If
                End If
            End If



        End If

    End Sub

    Private Sub fillcboSecCust()
        gspStr = "sp_select_CUBASINF_Q '', 'ALL','Secondary'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_S, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading sp_list_CUBASINF_Q :" & rtnStr)
            Exit Sub
        End If

        Dim dr As DataRow()
        dr = rs_CUBASINF_S.Tables("RESULT").Select("csc_seccus >= '60000'")
        'Else
        'dr = rs_CUBASINF_P.Tables("RESULT").Select("")
        'End If

        If dr.Length > 0 Then


            For i As Integer = 0 To dr.Length - 1
                cboCus2No.Items.Add(dr(i).Item("csc_seccus") & " - " & dr(i).Item("cbi_cussna"))
            Next
        End If

    End Sub

    Private Sub cboSecCust_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCus2no_PanelAdd.KeyUp
        If cboCus2no_PanelAdd.Text.Length > 0 Then
            If e.KeyCode <> Keys.Back Then
                sHdrSecCust = cboCus2no_PanelAdd.Text
                auto_search_combo(cboCus2no_PanelAdd)
            Else
                cboCus2no_PanelAdd.Text = sHdrSecCust.Substring(0, sHdrSecCust.Length - 1)
                auto_search_combo(cboCus2no_PanelAdd)
                sHdrSecCust = sHdrSecCust.Substring(0, sHdrSecCust.Length - 1)
            End If
        End If
    End Sub

    Private Sub format_cboSecCust(ByVal PriCust As String)
        cboCus2no_PanelAdd.Items.Clear()

        gspStr = "sp_select_CUBASINF_Q ''," & PriCust & ",'Secondary'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_S, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading CLM00001 #002 sp_list_CUBASINF :" & rtnStr)
            Exit Sub
        End If

        Dim i As Integer
        Dim strList As String

        If rs_CUBASINF_S.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_CUBASINF_S.Tables("RESULT").Rows.Count - 1
                strList = ""
                strList = rs_CUBASINF_S.Tables("RESULT").Rows(i).Item("csc_seccus") & " - " & rs_CUBASINF_S.Tables("RESULT").Rows(i).Item("cbi_cussna")
                If strList <> "" Then
                    cboCus2no_PanelAdd.Items.Add(strList)
                End If
            Next i
        End If
    End Sub


    Private Sub format_cboSecCustAll()
        Dim i As Integer
        Dim strList As String

        cboCus2no_PanelAdd.Items.Clear()

        If rs_CUBASINF_S_All.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_CUBASINF_S_All.Tables("RESULT").Rows.Count - 1
                strList = ""
                If rs_CUBASINF_S_All.Tables("RESULT").Rows(i).Item("cbi_cusno") > "50000" Then
                    strList = rs_CUBASINF_S_All.Tables("RESULT").Rows(i).Item("cbi_cusno") & " - " & rs_CUBASINF_S_All.Tables("RESULT").Rows(i).Item("cbi_cussna")
                End If

                If strList <> "" Then
                    cboCus2no_PanelAdd.Items.Add(strList)
                End If
            Next i
        End If
    End Sub

    Private Sub cboWeek_PanelAdd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboWeek_PanelAdd.SelectedIndexChanged
        Dim curweek As String = Split(Split(cboWeek_PanelAdd.Text, " - ")(0), " ")(1)

        UpdateWeekDate2(cboYear_PanelAdd.Text, curweek)
    End Sub


    Private Sub cbo_year_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboYear_PanelAdd.SelectedIndexChanged

        'Dim today As DateTime = Date.Today
        'today = New DateTime(2017, 1, 2)
        FillWeekBox(cboWeek_PanelAdd, GetWeekByDate(today, True), today.Year)

    End Sub



#End Region


#Region "Function Related to Release"

    'Private Sub chkRelease_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRelease.CheckedChanged
    '    Dim Hdrtbl As DataTable = rs_QCM00002Hdr.Tables("RESULT")


    '    If Recordstatus = True Then
    '        If chkRelease.Checked = False Then
    '            Exit Sub
    '        End If
    '        MsgBox("QC is in Edit mode. Not available for release.")
    '        chkRelease.Checked = False
    '        Exit Sub
    '    End If


    '    Dim qch_qcsts As String = Hdrtbl.Rows(0).Item("qch_qcsts")

    '    If qch_qcsts = "REL" Or qch_qcsts = "CAN" Or qch_qcsts = "DEL" Then
    '        MsgBox("QC with ststus " + qch_qcsts + " can not be released")
    '        chkRelease.Checked = False
    '        Exit Sub
    '    End If




    '    If chkRelease.Checked = True Then
    '        Dim answer As Integer = MsgBox("This action will release the  QC. Are you sure?", MsgBoxStyle.YesNo)
    '        If answer = MsgBoxResult.Yes Then

    '            If QCRelease() Then
    '                MsgBox("Release Success")
    '            Else
    '                MsgBox("Release Fail")
    '            End If
    '            QCClear()
    '            ToStage("INIT")
    '        Else
    '            chkRelease.Checked = False
    '        End If
    '    End If

    'End Sub

    Private Function QCRelease(ByVal action As String)
        QCRelease = False

        Dim Hdrtbl As DataTable = rs_QCM00002Hdr.Tables("RESULT")

        gspStr = "sp_release_QCM00002 '" & Hdrtbl.Rows(0).Item("qch_qcno") & "','" & _
            action & "','" & _
            gsUsrID & "'"

        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading sp_release_QCM00002:" & rtnStr)
            Exit Function
        End If


        QCRelease = True
    End Function

    Private Sub checkCurweekRequest(ByVal action As String)
        If rs_QCM00002Hdr.Tables("RESULT").Rows(0).Item("qch_inspweek") = GetCurrentWeek() And rs_QCM00002Hdr.Tables("RESULT").Rows(0).Item("qch_inspyear") = Date.Today.Year Then
            'MsgBox("QCR in current week is released. A remind email will be send")
            AlertCurrentWeekRequestRelease(action)
        Else
            'MsgBox("QCR not in current week is released")
        End If
    End Sub

#End Region





    'Private Sub chk_qch_mon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_qch_mon.Click

    'End Sub

#Region "Function Related to check change of request date"
    'Header date Change
    Private Sub chk_HeaderClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
        chk_qch_mon.Click, chk_qch_tue.Click, chk_qch_wed.Click, chk_qch_thur.Click, chk_qch_fri.Click, chk_qch_sat.Click, chk_qch_sun.Click

        Dim flg As Boolean = False
        Dim chk As CheckBox
        Dim countday As Integer = 0

        Recordstatus = True

        For i As Integer = 0 To dayList.Length - 1
            Dim str As String = "chk_qch_" + dayList(i)
            chk = CType(grp_qchdate.Controls(str), CheckBox)
            If chk.Checked Then
                countday = countday + 1
            End If
        Next

        If countday = 0 Then
            MsgBox("Must have at least one Inspection Date")
            FillQCHeader()  'Rollback to original Inspection date
            Exit Sub
        End If

        If flg = True Then




            Dim Hdrtbl As DataTable = rs_QCM00002Hdr.Tables("RESULT")
            Dim POtbl As DataTable = rs_QCM00002_QCPODTL.Tables("RESULT")
            Dim Dtltbl As DataTable = rs_QCM00002.Tables("RESULT")

            Dim chkbox As CheckBox = CType(sender, CheckBox)
            Dim applyname As String = Split(chkbox.Name, "_")(1) + "_" + Split(chkbox.Name, "_")(2)
            Dim applydate As String = Split(applyname, "_")(1)
            Dim applyvalue As String = If(chkbox.Checked, "Y", "")

            Hdrtbl.Rows(0).Item(applyname) = applyvalue

            For i As Integer = 0 To POtbl.Rows.Count - 1
                POtbl.Rows(i).Item("qpd_" + applydate) = applyvalue

                Dim qpd_ctrlstate As String = POtbl.Rows(i).Item("qpd_ctrlstate")
                If qpd_ctrlstate = "" Then
                    POtbl.Rows(i).Item("qpd_ctrlstate") = "UPD"
                End If

            Next

            For i As Integer = 0 To Dtltbl.Rows.Count - 1
                Dtltbl.Rows(i).Item("qcd_" + applydate) = applyvalue

                Dim qcd_ctrlstate As String = Dtltbl.Rows(i).Item("qcd_ctrlstate")
                If qcd_ctrlstate = "" Then
                    Dtltbl.Rows(i).Item("qcd_ctrlstate") = "UPD"
                End If

            Next
        End If


        For Each ctrl As Control In grp_qchdate.Controls
            If ctrl.GetType() Is GetType(CheckBox) Then
                Dim chk1 As CheckBox = CType(ctrl, CheckBox)
                Dim day As String
                Dim str As String
                day = chk1.Name.Split("_")(2)
                str = "chk_apply_" + day
                Dim applychk As CheckBox = CType(grp_reqdate.Controls(str), CheckBox)
                If chk1.Checked Then
                    'Use chkbox Text as weekday for simplicity
                    applychk.Checked = True
                Else
                    applychk.Checked = False
                End If
            End If
        Next

        applyChange_TabPage1()

        FillQCHeader()
        FillQCPOHeaderGrid()
        FillQCDetail()
        FillQCSummary()

    End Sub

    Private Sub chk_DetailClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
    chk_qcd_mon.Click, chk_qcd_tue.Click, chk_qcd_wed.Click, chk_qcd_thur.Click, chk_qcd_fri.Click, chk_qcd_sat.Click, chk_qcd_sun.Click



        Dim chk As CheckBox
        Dim countday As Integer = 0

        Recordstatus = True

        For i As Integer = 0 To dayList.Length - 1
            Dim str As String = "chk_qcd_" + dayList(i)
            chk = CType(grp_qcddate.Controls(str), CheckBox)
            If chk.Checked Then
                countday = countday + 1
            End If
        Next

        If countday = 0 Then
            MsgBox("Must have at least one Inspection Date")
            FillQCDetail()  'Rollback to original Inspection date
            Exit Sub
        End If




        Dim Hdrtbl As DataTable = rs_QCM00002Hdr.Tables("RESULT")
        Dim POtbl As DataTable = rs_QCM00002_QCPODTL.Tables("RESULT")
        Dim Dtltbl As DataTable = rs_QCM00002.Tables("RESULT")

        Dim chkbox As CheckBox = CType(sender, CheckBox)
        Dim applyname As String = Split(chkbox.Name, "_")(1) + "_" + Split(chkbox.Name, "_")(2)
        Dim applydate As String = Split(applyname, "_")(1)
        Dim applyvalue As String = If(chkbox.Checked, "Y", "")


        Dim PONo As String = Dtltbl.Rows(Pointer_CurQCseq).Item("qcd_purord")

        'Detail Level
        Dtltbl.Rows(Pointer_CurQCseq).Item(applyname) = applyvalue
        Dim qcd_ctrlstate As String = Dtltbl.Rows(Pointer_CurQCseq).Item("qcd_ctrlstate")
        If qcd_ctrlstate = "" Then
            Dtltbl.Rows(Pointer_CurQCseq).Item("qcd_ctrlstate") = "UPD"
        End If

        'Dtltbl.AcceptChanges()


        'PO Level
        Dim Applyrows As DataRow() = POtbl.Select("qpd_purord ='" + PONo + "'")
        'Avoid 9insert type in QCDetail level
        If Applyrows.Length <> 0 Then
            Dim Dtlrows As DataRow() = Dtltbl.Select("qcd_purord = '" + PONo + "'")
            Dim POWeekDay As WeekDay = New WeekDay()
            For i As Integer = 0 To Dtlrows.Length - 1
                Dim cur_row As DataRow = Dtlrows(i)
                POWeekDay.Mon = If(cur_row.Item("qcd_mon") = "Y", True, POWeekDay.Mon)
                POWeekDay.Tue = If(cur_row.Item("qcd_tue") = "Y", True, POWeekDay.Tue)
                POWeekDay.Wed = If(cur_row.Item("qcd_wed") = "Y", True, POWeekDay.Wed)
                POWeekDay.Thur = If(cur_row.Item("qcd_thur") = "Y", True, POWeekDay.Thur)
                POWeekDay.Fri = If(cur_row.Item("qcd_fri") = "Y", True, POWeekDay.Fri)
                POWeekDay.Sat = If(cur_row.Item("qcd_sat") = "Y", True, POWeekDay.Sat)
                POWeekDay.Sun = If(cur_row.Item("qcd_sun") = "Y", True, POWeekDay.Sun)
            Next

            For i As Integer = 0 To 6
                Applyrows(0).Item("qpd_" + dayList(i)) = POWeekDay.to_YFormat(i + 1)
            Next

            Dim qpd_ctrlstate As String = Applyrows(0).Item("qpd_ctrlstate")
            If qpd_ctrlstate = "" Then
                Applyrows(0).Item("qpd_ctrlstate") = "UPD"
            End If

        End If

        'Header Level
        Dim QCWeekDay As WeekDay = New WeekDay()
        For i As Integer = 0 To Dtltbl.Rows.Count - 1
            Dim cur_row As DataRow = Dtltbl.Rows(i)
            QCWeekDay.Mon = If(cur_row.Item("qcd_mon") = "Y", True, QCWeekDay.Mon)
            QCWeekDay.Tue = If(cur_row.Item("qcd_tue") = "Y", True, QCWeekDay.Tue)
            QCWeekDay.Wed = If(cur_row.Item("qcd_wed") = "Y", True, QCWeekDay.Wed)
            QCWeekDay.Thur = If(cur_row.Item("qcd_thur") = "Y", True, QCWeekDay.Thur)
            QCWeekDay.Fri = If(cur_row.Item("qcd_fri") = "Y", True, QCWeekDay.Fri)
            QCWeekDay.Sat = If(cur_row.Item("qcd_sat") = "Y", True, QCWeekDay.Sat)
            QCWeekDay.Sun = If(cur_row.Item("qcd_sun") = "Y", True, QCWeekDay.Sun)
        Next

        For i As Integer = 0 To 6
            Hdrtbl.Rows(0).Item("qch_" + dayList(i)) = QCWeekDay.to_YFormat(i + 1)
        Next

        FillQCHeader()
        FillQCPOHeaderGrid()
        FillQCDetail()
        FillQCSummary()



    End Sub

    Private Sub dg_POHeader_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_POHeader.CellClick
        If e.RowIndex >= 0 Then
            'Mon To Sun
            If e.ColumnIndex >= 3 And e.ColumnIndex <= 9 Then
                Dim Hdrtbl As DataTable = rs_QCM00002Hdr.Tables("RESULT")
                Dim POtbl As DataTable = rs_QCM00002_QCPODTL.Tables("RESULT")
                Dim Dtltbl As DataTable = rs_QCM00002.Tables("RESULT")

                Recordstatus = True

                Dim rowindex As Integer = e.RowIndex

                Dim applydate As String = dayList(e.ColumnIndex - 3)
                Dim applyvalue As String = If(dg_POHeader.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "", "Y", "")

                Dim countday As Integer = 0
                For i As Integer = 0 To dayList.Length - 1
                    Dim str As String = "qpd_" + dayList(i)

                    If POtbl.Rows(rowindex).Item(str) = "Y" Then
                        countday = countday + 1
                    End If
                Next

                If countday = 1 And dg_POHeader.Rows(rowindex).Cells(e.ColumnIndex).Value = "Y" Then
                    MsgBox("Must have at least one Inspection Date")
                    Exit Sub
                End If

                dg_POHeader.Item(e.ColumnIndex, e.RowIndex).Value = applyvalue

                Dim flag As Boolean = False
                If flag Then
                    'Dim PONo As String = dg_POHeader.Rows(rowindex).Cells("qpd_purord").Value.ToString
                    Dim PONo As String = POtbl.Rows(rowindex).Item("qpd_purord")


                    'PO Level
                    POtbl.Rows(rowindex).Item("qpd_" + applydate) = applyvalue

                    Dim qpd_ctrlstate As String = POtbl.Rows(rowindex).Item("qpd_ctrlstate")
                    If String.Compare(qpd_ctrlstate, "") = 0 Then
                        POtbl.Rows(rowindex).Item("qpd_ctrlstate") = "UPD"
                    End If


                    'For Each ctrl As Control In grp_reqdate.Controls
                    '    If ctrl.GetType() Is GetType(CheckBox) Then
                    '        Dim chk As CheckBox = CType(ctrl, CheckBox)
                    '        Dim day As String
                    '        Dim daystr As String
                    '        day = chk.Name.Split("_")(2)
                    '        daystr = "qpd_" + day
                    '        If chk.Checked Then
                    '            'Use chkbox Text as weekday for simplicity
                    '            POtbl.Rows(rowindex).Item(daystr) = "Y"
                    '        Else
                    '            POtbl.Rows(rowindex).Item(daystr) = ""
                    '        End If
                    '    End If
                    'Next

                    'Detail Level
                    Dim Applyrows As DataRow() = Dtltbl.Select("qcd_purord ='" + PONo + "'")
                    If Applyrows.Length <> 0 Then
                        For i As Integer = 0 To Applyrows.Length - 1

                            For j As Integer = 0 To dayList.Length - 1
                                Applyrows(i).Item("qcd_" + dayList(j)) = POtbl.Rows(rowindex).Item("qpd_" + dayList(j))
                            Next
                            'Applyrows(i).Item("qcd_sidate") = apply_sidate
                            'Applyrows(i).Item("qcd_cydate") = apply_cydate

                            Dim qcd_ctrlstate As String = Applyrows(i).Item("qcd_ctrlstate")
                            If qcd_ctrlstate = "" Then
                                Applyrows(i).Item("qcd_ctrlstate") = "UPD"
                            End If


                        Next
                    End If

                    'Header Level
                    Dim QCWeekDay As WeekDay = New WeekDay()
                    For i As Integer = 0 To Dtltbl.Rows.Count - 1
                        Dim cur_row As DataRow = Dtltbl.Rows(i)
                        QCWeekDay.Mon = If(cur_row.Item("qcd_mon") = "Y", True, QCWeekDay.Mon)
                        QCWeekDay.Tue = If(cur_row.Item("qcd_tue") = "Y", True, QCWeekDay.Tue)
                        QCWeekDay.Wed = If(cur_row.Item("qcd_wed") = "Y", True, QCWeekDay.Wed)
                        QCWeekDay.Thur = If(cur_row.Item("qcd_thur") = "Y", True, QCWeekDay.Thur)
                        QCWeekDay.Fri = If(cur_row.Item("qcd_fri") = "Y", True, QCWeekDay.Fri)
                        QCWeekDay.Sat = If(cur_row.Item("qcd_sat") = "Y", True, QCWeekDay.Sat)
                        QCWeekDay.Sun = If(cur_row.Item("qcd_sun") = "Y", True, QCWeekDay.Sun)
                    Next

                    For i As Integer = 0 To 6
                        Hdrtbl.Rows(0).Item("qch_" + dayList(i)) = QCWeekDay.to_YFormat(i + 1)
                    Next
                End If


                'Start from here


                For i As Integer = 0 To dayList.Length - 1
                    Dim day As String
                    Dim str As String
                    day = dayList(i)
                    str = "chk_apply_" + day
                    Dim applychk As CheckBox = CType(grp_reqdate.Controls(str), CheckBox)
                    If dg_POHeader.Item(i + 3, e.RowIndex).Value = "Y" Then
                        applychk.Checked = True
                    Else
                        applychk.Checked = False
                    End If
                Next

                applyChange_TabPage2(e.RowIndex)



                FillQCHeader()
                FillQCPOHeaderGrid()
                FillQCDetail()
                FillQCSummary()

            End If
        End If

    End Sub




#End Region






#Region "User Change - Header Page"
    Private Sub txt_Hsidate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_Hsidate.Validating
        Dim tmpstr As String
        tmpstr = txt_Hsidate.Text
        Recordstatus = True


        If Not IsDate(tmpstr) And tmpstr <> "  /  /" Then
            MsgBox("Not a valid SI date!")
            txt_Hsidate.Focus()
        Else
            If tmpstr = "  /  /" Then
                tmpstr = ""
            End If
            rs_QCM00002Hdr.Tables("RESULT").Rows(0).Item("qch_sidate") = tmpstr
        End If

    End Sub

    Private Sub txt_HcyDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_HcyDate.Validating
        Dim tmpstr As String
        tmpstr = txt_HcyDate.Text
        Recordstatus = True


        If Not IsDate(tmpstr) And tmpstr <> "  /  /" Then
            MsgBox("Not a valid CY date!")
            txt_Hsidate.Focus()
        Else
            If tmpstr = "  /  /" Then
                tmpstr = ""
            End If
            rs_QCM00002Hdr.Tables("RESULT").Rows(0).Item("qch_cydate") = tmpstr
        End If

    End Sub

    Private Sub txt_HcispDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_HcispDate.Validating
        Dim tmpstr As String
        tmpstr = txt_HcispDate.Text
        Recordstatus = True

        If Not IsDate(tmpstr) And tmpstr <> "  /  /" Then
            MsgBox("Not a valid Customer Inspection date!")
            txt_HcispDate.Focus()
        Else
            If tmpstr = "  /  /" Then
                tmpstr = ""
            End If
            rs_QCM00002Hdr.Tables("RESULT").Rows(0).Item("qch_cispdate") = tmpstr
        End If
    End Sub

    Private Sub txt_HRmk_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_HRmk.Validating
        Dim tmpstr As String
        tmpstr = txt_HRmk.Text
        Recordstatus = True

        If tmpstr.Length > 300 Then
            MsgBox("Remark length exceeds 300!")
            txt_HRmk.Focus()
        Else
            rs_QCM00002Hdr.Tables("RESULT").Rows(0).Item("qch_rmk") = tmpstr
        End If


    End Sub


    Private Sub txtRemAddr_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtRemAddr.Validating
        Dim tmpstr As String
        tmpstr = txtRemAddr.Text
        Recordstatus = True

        If tmpstr.Length > 300 Then
            MsgBox("Addr length exceeds 300!")
            txtRemAddr.Focus()
        Else
            Dim Hdrrow As DataRow = rs_QCM00002Hdr.Tables("RESULT").Rows(0)
            Hdrrow.Item("qvi_adr") = tmpstr
            If Hdrrow.Item("qvi_ctrlstate") = "" Then
                Hdrrow.Item("qvi_ctrlstate") = "UPD"
            End If
        End If
    End Sub

    Private Sub txtStt_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtStt.Validating
        Dim tmpstr As String
        tmpstr = txtStt.Text
        Recordstatus = True

        If tmpstr.Length > 300 Then
            MsgBox("Remark length exceeds 300!")
            txtStt.Focus()
        Else
            Dim Hdrrow As DataRow = rs_QCM00002Hdr.Tables("RESULT").Rows(0)
            Hdrrow.Item("qvi_stt") = tmpstr
            If Hdrrow.Item("qvi_ctrlstate") = "" Then
                Hdrrow.Item("qvi_ctrlstate") = "UPD"
            End If
        End If
    End Sub

    Private Sub txtCty_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCty.Validating
        Dim tmpstr As String
        tmpstr = txtCty.Text
        Recordstatus = True

        If tmpstr.Length > 300 Then
            MsgBox("Country length exceeds 300!")
            txtCty.Focus()
        Else
            Dim Hdrrow As DataRow = rs_QCM00002Hdr.Tables("RESULT").Rows(0)
            Hdrrow.Item("qvi_cty") = tmpstr
            If Hdrrow.Item("qvi_ctrlstate") = "" Then
                Hdrrow.Item("qvi_ctrlstate") = "UPD"
            End If
        End If
    End Sub

    Private Sub txtTown_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTown.Validating
        Dim tmpstr As String
        tmpstr = txtTown.Text
        Recordstatus = True

        If tmpstr.Length > 300 Then
            MsgBox("Town length exceeds 300!")
            txtTown.Focus()
        Else
            Dim Hdrrow As DataRow = rs_QCM00002Hdr.Tables("RESULT").Rows(0)
            Hdrrow.Item("qvi_town") = tmpstr
            If Hdrrow.Item("qvi_ctrlstate") = "" Then
                Hdrrow.Item("qvi_ctrlstate") = "UPD"
            End If
        End If
    End Sub

    Private Sub txtCity_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCity.Validating
        Dim tmpstr As String
        tmpstr = txtCity.Text
        Recordstatus = True

        If tmpstr.Length > 300 Then
            MsgBox("City length exceeds 300!")
            txtCity.Focus()
        Else
            rs_QCM00002Hdr.Tables("RESULT").Rows(0).Item("qvi_city") = tmpstr
        End If
    End Sub

    Private Sub txtPst_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPst.Validating
        Dim tmpstr As String
        tmpstr = txtPst.Text
        Recordstatus = True

        If tmpstr.Length > 300 Then
            MsgBox("Zip length exceeds 300!")
            txtPst.Focus()
        Else
            Dim Hdrrow As DataRow = rs_QCM00002Hdr.Tables("RESULT").Rows(0)
            Hdrrow.Item("qvi_zip") = tmpstr
            If Hdrrow.Item("qvi_ctrlstate") = "" Then
                Hdrrow.Item("qvi_ctrlstate") = "UPD"
            End If
        End If
    End Sub

    Private Sub txtcntctp_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtcntctp.Validating
        Dim tmpstr As String
        tmpstr = txtcntctp.Text
        Recordstatus = True

        If tmpstr.Length > 100 Then
            MsgBox("Contact Person length exceeds 100!")
            txtPst.Focus()
        Else
            Dim Hdrrow As DataRow = rs_QCM00002Hdr.Tables("RESULT").Rows(0)
            Hdrrow.Item("qvi_cntctp") = tmpstr
            If Hdrrow.Item("qvi_ctrlstate") = "" Then
                Hdrrow.Item("qvi_ctrlstate") = "UPD"
            End If
        End If
    End Sub

    Private Sub txtcntphn_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtcntphn.Validating
        Dim tmpstr As String
        tmpstr = txtcntphn.Text
        Recordstatus = True

        If tmpstr.Length > 30 Then
            MsgBox("Contact Person length exceeds 30!")
            txtPst.Focus()
        Else
            Dim Hdrrow As DataRow = rs_QCM00002Hdr.Tables("RESULT").Rows(0)
            Hdrrow.Item("qvi_cntphn") = tmpstr
            If Hdrrow.Item("qvi_ctrlstate") = "" Then
                Hdrrow.Item("qvi_ctrlstate") = "UPD"
            End If
        End If
    End Sub


    Private Sub cboVenAddr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVenAddr.SelectedIndexChanged
        Dim select_index As Integer = cboVenAddr.SelectedIndex
        Recordstatus = True

        If select_index = 0 Then
            Exit Sub
        Else
            Dim Hdrtbl As DataTable = rs_QCM00002Hdr.Tables("RESULT")

            Dim venrow As DataRow = rs_QCM00002_VNCNTINF_Q.Tables("RESULT").Rows(select_index - 1)
            Hdrtbl.Rows(0).Item("qvi_adr") = venrow.Item("vci_adr")
            Hdrtbl.Rows(0).Item("qvi_cty") = venrow.Item("vci_cty")
            Hdrtbl.Rows(0).Item("qvi_stt") = venrow.Item("vci_stt")
            Hdrtbl.Rows(0).Item("qvi_city") = venrow.Item("vci_city")
            Hdrtbl.Rows(0).Item("qvi_town") = venrow.Item("vci_town")
            Hdrtbl.Rows(0).Item("qvi_zip") = venrow.Item("vci_zip")

            If Hdrtbl.Rows(0).Item("qvi_ctrlstate") = "" Then
                Hdrtbl.Rows(0).Item("qvi_ctrlstate") = "UPD"
            End If




            cboVenAddr.SelectedIndex = 0
            FillQCHeader()
        End If

    End Sub

    Private Sub cboPorCtp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPorCtp.SelectedIndexChanged
        Dim select_index As Integer = cboPorCtp.SelectedIndex
        Recordstatus = True

        If select_index = 0 Then
            Exit Sub
        Else
            Dim Hdrtbl As DataTable = rs_QCM00002Hdr.Tables("RESULT")

            Dim venrow As DataRow = rs_QCM00002_VNCNTINF_QCFA.Tables("RESULT").Rows(select_index - 1)
            Hdrtbl.Rows(0).Item("qvi_cntctp") = venrow.Item("vci_cntctp")
            Hdrtbl.Rows(0).Item("qvi_cnttil") = venrow.Item("vci_cnttil")
            Hdrtbl.Rows(0).Item("qvi_cntphn") = venrow.Item("vci_cntphn")
            Hdrtbl.Rows(0).Item("qvi_cntfax") = venrow.Item("vci_cntfax")
            Hdrtbl.Rows(0).Item("qvi_cnteml") = venrow.Item("vci_cnteml")

            If Hdrtbl.Rows(0).Item("qvi_ctrlstate") = "" Then
                Hdrtbl.Rows(0).Item("qvi_ctrlstate") = "UPD"
            End If




            cboPorCtp.SelectedIndex = 0
            FillQCHeader()
        End If

    End Sub


    Private Sub HeaderInspTyp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles RadioButton1.Click, RadioButton2.Click, RadioButton3.Click, RadioButton4.Click, RadioButton5.Click, _
        RadioButton6.Click, RadioButton8.Click, RadioButton9.Click

        Dim Hdrtbl As DataTable = rs_QCM00002Hdr.Tables("RESULT")
        Dim rb As RadioButton = CType(sender, RadioButton)
        Hdrtbl.Rows(0).Item("qch_insptyp") = Convert_Insptype(rb.Text)

    End Sub

    Private Sub HeaderSamHdl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton10.Click, RadioButton7.Click
        Dim hdrtbl As DataTable = rs_QCM00002Hdr.Tables("RESULT")
        Dim rb As RadioButton = CType(sender, RadioButton)
        hdrtbl.Rows(0).Item("qch_samhdl") = rb.Text
    End Sub






#End Region

#Region "User Change - Item Detail Page"
    Private Sub txt_ItmNo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_ItmNo.Validating
        Dim tmpstr As String
        tmpstr = txt_ItmNo.Text
        Recordstatus = True

        If tmpstr.Length > 300 Then
            MsgBox("Remark length exceeds 300!")
            txt_HRmk.Focus()
        Else
            rs_QCM00002.Tables("RESULT").Rows(Pointer_CurQCseq).Item("qcd_xitmno") = tmpstr
            If rs_QCM00002.Tables("RESULT").Rows(Pointer_CurQCseq).Item("qcd_ctrlstate") = "" Then
                rs_QCM00002.Tables("RESULT").Rows(Pointer_CurQCseq).Item("qcd_ctrlstate") = "UPD"
            End If
        End If

    End Sub

    Private Sub txt_ItmDesc_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_ItmDesc.Validating
        Dim tmpstr As String
        tmpstr = txt_ItmDesc.Text
        Recordstatus = True

        If tmpstr.Length > 300 Then
            MsgBox("Item Desc length exceeds 300!")
            txt_ItmDesc.Focus()
        Else
            rs_QCM00002.Tables("RESULT").Rows(Pointer_CurQCseq).Item("qcd_xitmdsc") = tmpstr
            If rs_QCM00002.Tables("RESULT").Rows(Pointer_CurQCseq).Item("qcd_ctrlstate") = "" Then
                rs_QCM00002.Tables("RESULT").Rows(Pointer_CurQCseq).Item("qcd_ctrlstate") = "UPD"
            End If
        End If
    End Sub

    Private Sub txt_Color_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_Color.Validating
        Dim tmpstr As String
        tmpstr = txt_Color.Text
        Recordstatus = True

        If tmpstr.Length > 300 Then
            MsgBox("Color length exceeds 300!")
            txt_Color.Focus()
        Else
            rs_QCM00002.Tables("RESULT").Rows(Pointer_CurQCseq).Item("qcd_xcolor") = tmpstr
            If rs_QCM00002.Tables("RESULT").Rows(Pointer_CurQCseq).Item("qcd_ctrlstate") = "" Then
                rs_QCM00002.Tables("RESULT").Rows(Pointer_CurQCseq).Item("qcd_ctrlstate") = "UPD"
            End If
        End If
    End Sub

    Private Sub txt_PackInstruction_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_PackInstruction.Validating
        Dim tmpstr As String
        tmpstr = txt_PackInstruction.Text
        Recordstatus = True

        If tmpstr.Length > 300 Then
            MsgBox("PackInstruction length exceeds 300!")
            txt_PackInstruction.Focus()
        Else
            rs_QCM00002.Tables("RESULT").Rows(Pointer_CurQCseq).Item("qcd_xpack") = tmpstr
            If rs_QCM00002.Tables("RESULT").Rows(Pointer_CurQCseq).Item("qcd_ctrlstate") = "" Then
                rs_QCM00002.Tables("RESULT").Rows(Pointer_CurQCseq).Item("qcd_ctrlstate") = "UPD"
            End If
        End If
    End Sub

    Private Sub txtNumeric_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
        txtMtrdcm.KeyPress, txtMtrwcm.KeyPress, txtMtrhcm.KeyPress, txtInrwcm.KeyPress, txtInrhcm.KeyPress, txtInrdcm.KeyPress, txt_NetW.KeyPress, txt_GrossW.KeyPress
        Dim txtbox As TextBox = CType(sender, TextBox)

        If Not (e.KeyChar = vbBack Or e.KeyChar.ToString() = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        Else
            If txtbox.Text.IndexOf(".") > 0 And e.KeyChar.ToString() = "." Then
                e.KeyChar = ""
            End If
        End If

    End Sub

    Private Sub txtNumeric_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        txtMtrdcm.Validating, txtMtrwcm.Validating, txtMtrhcm.Validating, txtInrwcm.Validating, txtInrhcm.Validating, txtInrdcm.Validating, txt_Ordqty.Validating, txt_NetW.Validating, txt_GrossW.Validating
        Dim txtbox As TextBox = CType(sender, TextBox)

        Recordstatus = True

        If txtbox.Text = "0" Then
            Exit Sub
        End If


        Dim result As Double

        If Not Double.TryParse(txtbox.Text, result) Then
            txtbox.Text = 0
            txtbox.Focus()
        Else
            txtbox.Text = result.ToString()
        End If

        'Reflect in result set
        For Each de As DictionaryEntry In itmdtl_mapping
            If txtbox.Name = de.Value Then
                rs_QCM00002.Tables("RESULT").Rows(Pointer_CurQCseq).Item(de.Key) = txtbox.Text
                If rs_QCM00002.Tables("RESULT").Rows(Pointer_CurQCseq).Item("qcd_ctrlstate") = "" Then
                    rs_QCM00002.Tables("RESULT").Rows(Pointer_CurQCseq).Item("qcd_ctrlstate") = "UPD"
                End If
                Exit For
            End If
        Next
    End Sub

    Private Sub txt_Ordqty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Ordqty.KeyPress
        If Not (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9") Then
            e.KeyChar = ""
        End If
    End Sub
#End Region

#Region "User Change - Detail Page"

    Private Sub txtDRmk_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDRmk.Validating
        Dim tmpstr As String
        tmpstr = txtDRmk.Text
        Recordstatus = True

        Dim Dtltbl As DataTable = rs_QCM00002.Tables("RESULT")
        If Dtltbl.Rows.Count = 0 Then
            Exit Sub
        End If


        If tmpstr.Length > 300 Then
            MsgBox("Remark length exceeds 300!")
            txt_HRmk.Focus()
        Else
            rs_QCM00002.Tables("RESULT").Rows(Pointer_CurQCseq).Item("qcd_rmk") = tmpstr
            If rs_QCM00002.Tables("RESULT").Rows(Pointer_CurQCseq).Item("qcd_ctrlstate") = "" Then
                rs_QCM00002.Tables("RESULT").Rows(Pointer_CurQCseq).Item("qcd_ctrlstate") = "UPD"
            End If

        End If

    End Sub
#End Region


    Private Function Convert_Insptype(ByVal insptype As String) As String
        Dim ret As String
        Select Case insptype
            Case "Pre-Pro (P)"
                ret = "P"
            Case "PP Meeting (PP)"
                ret = "PP"
            Case "In-Line (M)"
                ret = "M"
            Case "Customer In-Line (CM)"
                ret = "CM"
            Case "Customer In-line with QC (DCM)"
                ret = "DCM"
            Case "Final (F)"
                ret = "F"
            Case "Customer Final (CF)"
                ret = "CF"
            Case "Customer Final with QC (DCF)"
                ret = "DCF"
            Case Else
                ret = "E"
        End Select

        Return ret
    End Function

    Private Sub UpdateWeekDate(ByVal year As Integer, ByVal week As Integer)


        Dim firstdate As Date = FirstDateOfWeekISO8601(year, week)

        lbl_mon.Text = firstdate.ToString("MM/dd")
        lbl_tue.Text = firstdate.AddDays(1).ToString("MM/dd")
        lbl_wed.Text = firstdate.AddDays(2).ToString("MM/dd")
        lbl_thur.Text = firstdate.AddDays(3).ToString("MM/dd")
        lbl_fri.Text = firstdate.AddDays(4).ToString("MM/dd")
        lbl_sat.Text = firstdate.AddDays(5).ToString("MM/dd")
        lbl_sun.Text = firstdate.AddDays(6).ToString("MM/dd")

        lbl_monD.Text = firstdate.ToString("MM/dd")
        lbl_tueD.Text = firstdate.AddDays(1).ToString("MM/dd")
        lbl_wedD.Text = firstdate.AddDays(2).ToString("MM/dd")
        lbl_thurD.Text = firstdate.AddDays(3).ToString("MM/dd")
        lbl_friD.Text = firstdate.AddDays(4).ToString("MM/dd")
        lbl_satD.Text = firstdate.AddDays(5).ToString("MM/dd")
        lbl_sunD.Text = firstdate.AddDays(6).ToString("MM/dd")


    End Sub

    Private Sub UpdateWeekDate2(ByVal year As Integer, ByVal week As Integer)
        Dim firstdate As Date = FirstDateOfWeekISO8601(year, week)
        lbl2_mon.Text = firstdate.ToString("MM/dd")
        lbl2_tue.Text = firstdate.AddDays(1).ToString("MM/dd")
        lbl2_wed.Text = firstdate.AddDays(2).ToString("MM/dd")
        lbl2_thur.Text = firstdate.AddDays(3).ToString("MM/dd")
        lbl2_fri.Text = firstdate.AddDays(4).ToString("MM/dd")
        lbl2_sat.Text = firstdate.AddDays(5).ToString("MM/dd")
        lbl2_sun.Text = firstdate.AddDays(6).ToString("MM/dd")
    End Sub
    Private Sub SetStatusBar(ByVal mode As String)

        If mode = "INIT" Then
            Me.StatusBar.Items("lblLeft").Text = "Init"
        ElseIf mode = "ADD" Then
            Me.StatusBar.Items("lblLeft").Text = "Add"
        ElseIf mode = "LOAD" Then
            Me.StatusBar.Items("lblLeft").Text = "Loading"
        ElseIf mode = "Clear" Then
            Me.StatusBar.Items("lblLeft").Text = "Clear Screen"
        End If
    End Sub




    Private Sub mmdDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdDelRow.Click
        If checkFocus(Me) Then Exit Sub

        If TabControl1.SelectedIndex = 2 Then
            If chkDelete.Checked Then
                chkDelete.Checked = False
            Else
                chkDelete.Checked = True
            End If
        End If
    End Sub

    Private Sub mmdRel_EnabledChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdRel.EnabledChanged, mmdCancel.EnabledChanged
        mmdFunction.Enabled = True
        If mmdRel.Enabled = False And mmdCancel.Enabled = False Then
            mmdFunction.Enabled = False
        End If
    End Sub

    Private Sub mmdRel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdRel.Click
        Dim Hdrtbl As DataTable = rs_QCM00002Hdr.Tables("RESULT")

        If Recordstatus = True Then
            MsgBox("QC is in Edit mode. Not available for release.")
            Exit Sub
        End If


        Dim qch_qcsts As String = Hdrtbl.Rows(0).Item("qch_qcsts")

        If qch_qcsts = "CAN" Or qch_qcsts = "DEL" Then
            MsgBox("QC with ststus " + qch_qcsts + " can not be released OR unreleased")
            Exit Sub
        End If

        Dim action As String = If(qch_qcsts = "OPE", "Release", If(qch_qcsts = "REL", "Unrelease", "Error"))
        If action = "Error" Then
            MsgBox("Error Happens, Release Fail")
            Exit Sub
        End If



        Dim answer As Integer = MsgBox("This action will " + action + " the  QC. Are you sure?", MsgBoxStyle.YesNo)
        If answer = MsgBoxResult.Yes Then
            Dim flg As String = If(action = "Release", "R", "U")

            If QCRelease(flg) Then
                MsgBox(action + " Success")
                If flg = "R" Then
                    checkCurweekRequest(flg)
                ElseIf flg = "U" Then
                    checkCurweekRequest(flg)
                End If
            Else
                MsgBox(action + " Fail")
            End If
            QCClear()
            ToStage("INIT")
        End If
    End Sub

    Private Sub mmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdCancel.Click
        Label4.Focus()
        Dim answer As Integer = MsgBox("This action will Cancel the whole QC. Are you sure?", MsgBoxStyle.YesNo)
        If answer = MsgBoxResult.Yes Then

            If QCCancel() Then
                MsgBox("Cancel Success")
            End If
            QCClear()
            ToStage("INIT")
        End If
    End Sub

    Private Sub mmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdDelete.Click
        If checkFocus(Me) Then Exit Sub
    End Sub

    Private Sub mmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdPrint.Click
        If checkFocus(Me) Then Exit Sub
    End Sub

    Private Sub mmdAttach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdAttach.Click
        If checkFocus(Me) Then Exit Sub
    End Sub

    Private Sub mmdFunction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdFunction.Click
        If checkFocus(Me) Then Exit Sub
    End Sub

    Private Sub mmdLink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdLink.Click
        If checkFocus(Me) Then Exit Sub
    End Sub
End Class
