Imports System.IO
Public Class VNM00001
    Inherits System.Windows.Forms.Form
    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean
    Dim lstrowindexVen1 As Integer
    Dim Got_Focus_Grid As String
    Dim PrcTrmRowIndex As Integer
    Dim rs_SYSETINF02 As New DataSet
    Dim rs_SYSETINF03 As New DataSet
    Dim rs_SYSETINF04 As New DataSet
    Dim rs_SYCURRENCY As New DataSet
    Dim rs_SYSETINF13 As New DataSet
    Dim rs_SYCATREL1 As New DataSet
    Dim rs_VNBASINF As New DataSet
    Dim rs_VNBASINF_READ As New DataSet
    Dim rs_VNCATREL_READ As New DataSet
    Dim rs_VNITMNAT_READ As New DataSet
    Dim rs_VNCNTINF_M_READ As New DataSet
    Dim rs_VNCNTINF_C_READ As New DataSet
    Dim rs_VNCNTINF_U_READ As New DataSet
    Dim rs_VNCNTPER_READ As New DataSet
    Dim rs_VNCSEINF_B_READ As New DataSet
    Dim rs_VNPUCINF_READ As New DataSet
    Dim rs_VNSUBVN_V_READ As New DataSet
    Dim rs_VNSUBVN_F_READ As New DataSet
    Dim rs_SYITMNAT_READ As New DataSet
    Dim rs_VNBASINF_ALL As New DataSet
    Dim rs_VNCUGREL_READ As New DataSet
    Dim rs_VNPRCTRM_READ As New DataSet
    Dim rs_VNEXCCUS As New DataSet
    Dim rs_SYSALLCUS As New DataSet

    Dim rs_VNBASINF_V_ADD As New DataSet
    Dim rs_VNBASINF_ADD As New DataSet
    Dim rs_VNSUBVN_V_ADD As New DataSet
    Dim rs_VNSUBVN_F_ADD As New DataSet
    Dim rs_VNBASINF_ADD2 As New DataSet
    Dim rs_VNCATREL_ADD As New DataSet
    Dim rs_VNCNTINF_M_ADR_ADD As New DataSet
    Dim rs_VNCNTINF_U_ADR_ADD As New DataSet
    Dim rs_VNCNTINF_all_PER_ADD As New DataSet
    Dim rs_VNCSEINF_B_ADD As New DataSet
    Dim rs_VNPUCINF_ADD As New DataSet
    'Dim rs_VNITMNAT_ADD As New DataSet

    Dim rs_QUOTNDTL As New DataSet
    Dim rs_SCORDDTL As New DataSet
    Dim rs_IMBASINF_1 As New DataSet
    Dim rs_IMVENINF_1 As New DataSet

    Dim lstrowindexVen2 As Integer


    Dim mode As String
    Dim Recordstatus As Boolean
    Dim Add_flag As Boolean
    Dim current_timstamp As Long

    Dim grdPceTme_vpt_cocde As Integer
    Dim grdPceTme_vpt_venno As Integer
    Dim grdPceTme_vpt_prctrm As Integer
    Dim grdPceTme_vpt_prcdef As Integer
    Dim grdPceTme_vpt_creusr As Integer
    Dim grdPceTme_vpt_updusr As Integer
    Dim grdPceTme_vpt_credat As Integer
    Dim grdPceTme_vpt_upddat As Integer
    Dim grdPceTme_vpt_timstp As Integer


    'grd
    Dim grdItmNat_vin_status As Integer
    Dim grdItmNat_vin_venno As Integer

    Dim grdItmNat_vin_itmnat As Integer

    Dim grdItmNat_vin_creusr As Integer

    Dim grdItmNat_vin_natseq As Integer


    Dim grdVnCntInf_vci_status As Integer
    Dim grdVnCntInf_vci_cnttyp As Integer
    Dim grdVnCntInf_vci_adr As Integer
    Dim grdVnCntInf_vci_city As Integer
    Dim grdVnCntInf_vci_town As Integer
    Dim grdVnCntInf_vci_stt As Integer
    Dim grdVnCntInf_vci_cty As Integer
    Dim grdVnCntInf_vci_zip As Integer
    Dim grdVnCntInf_vci_adrdtl As Integer
    Dim grdVnCntInf_vci_creusr As Integer
    Dim grdVnCntInf_vci_seq As Integer
    Dim grdVnCntInf_vci_chnadr As Integer

    Dim grdVnCntPer_vci_status As Integer
    Dim grdVnCntPer_vci_cnttyp As Integer
    Dim grdVnCntPer_vci_cntctp As Integer
    Dim grdVnCntPer_vci_cnttil As Integer
    Dim grdVnCntPer_vci_cntphn As Integer
    Dim grdVnCntPer_vci_cntfax As Integer
    Dim grdVnCntPer_vci_cnteml As Integer
    Dim grdVnCntPer_vci_cntdef As Integer
    Dim grdVnCntPer_vci_creusr As Integer
    Dim grdVnCntPer_vci_seq As Integer


    Dim grdVnCseBnk_vcs_status As Integer
    Dim grdVnCseBnk_vcs_csenam As Integer
    Dim grdVnCseBnk_vcs_accno As Integer
    Dim grdVnCseBnk_vcs_accnam As Integer
    Dim grdVnCseBnk_vcs_cseadr As Integer
    Dim grdVnCseBnk_vcs_csestt As Integer
    Dim grdVnCseBnk_vcs_csecty As Integer
    Dim grdVnCseBnk_vcs_csezip As Integer
    Dim grdVnCseBnk_vcs_csectp As Integer
    Dim grdVnCseBnk_vcs_csetil As Integer
    Dim grdVnCseBnk_vcs_csephn As Integer
    Dim grdVnCseBnk_vcs_csefax As Integer
    Dim grdVnCseBnk_vcs_cseeml As Integer
    Dim grdVnCseBnk_vcs_csermk As Integer
    Dim grdVnCseBnk_vcs_csedef As Integer
    Dim grdVnCseBnk_vcs_creusr As Integer
    Dim grdVnCseBnk_vcs_cretyp As Integer
    Dim grdVnCseBnk_vcs_creseq As Integer


    Dim grdVnPucInf_vpf_yymm As Integer
    Dim grdVnPucInf_vpf_mtdbok As Integer
    Dim grdVnPucInf_vpf_mtdpur As Integer

    Dim grdvengrp_vcr_cocde As Integer



    Dim grdvengrp_vcr_venno As Integer



    Dim grdvengrp_vcr_cugrpcde As Integer


    Dim grdvengrp_vcr_flg_int As Integer



    Dim grdvengrp_vcr_flg_ext As Integer

    Dim grdvengrp_icf_mrkup As Integer


    Dim grdvengrp_vcr_creusr As Integer



    Dim grdvengrp_vcr_updusr As Integer



    Dim grdvengrp_vcr_credat As Integer



    Dim grdvengrp_vcr_upddat As Integer



    Dim grdvengrp_vcr_timstp As Integer


    Dim grdFactoryRel_vsv_del As Integer
    Dim grdFactoryRel_vsv_code As Integer
    Dim grdFactoryRel_vsv_ven1cde As Integer
    Dim grdFactoryRel_vsv_ven1name As Integer
    Dim grdFactoryRel_vsv_ven2cde As Integer
    Dim grdFactoryRel_vsv_ven2name As Integer
    Dim grdFactoryRel_vsv_venrel As Integer
    Dim grdFactoryRel_vsv_creusr As Integer
    Dim grdFactoryRel_vsv_updusr As Integer
    Dim grdFactoryRel_vsv_credat As Integer
    Dim grdFactoryRel_vsv_upddat As Integer
    Dim grdFactoryRel_vsv_timstp As Integer


    Dim grdVendorRel_vsv_del As Integer
    Dim grdVendorRel_vsv_code As Integer
    Dim grdVendorRel_vsv_ven1cde As Integer
    Dim grdVendorRel_vsv_ven1name As Integer
    Dim grdVendorRel_vsv_ven2cde As Integer
    Dim grdVendorRel_vsv_ven2name As Integer
    Dim grdVendorRel_vsv_venrel As Integer
    Dim grdVendorRel_vsv_creusr As Integer
    Dim grdVendorRel_vsv_updusr As Integer
    Dim grdVendorRel_vsv_credat As Integer
    Dim grdVendorRel_vsv_upddat As Integer
    Dim grdVendorRel_vsv_timstp As Integer


    Dim grdExcCus_vec_cocde As Integer

    Dim grdExcCus_vec_venno As Integer

    Dim grdExcCus_vec_cusno As Integer

    Dim grdExcCus_vec_cotry As Integer

    Dim grdExcCus_vec_valid As Integer

    Dim grdExcCus_vec_rmark As Integer

    Dim grdExcCus_vec_creusr As Integer

    Dim grdExcCus_vec_updusr As Integer

    Dim grdExcCus_vec_credat As Integer

    Dim grdExcCus_vec_upddat As Integer






    Private Sub VNM00001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call Formstartup(Me.Name)
        Call AccessRight(Me.Name)
        Enq_right_local = Enq_right
        Del_right_local = Del_right
        format_cboVenType()
        format_cboTranFlag()
        format_cboVenSts()
        format_cboVenRat()

        gspStr = "sp_select_SYSETINF '','02'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYSETINF02, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading VNM00001_Load sp_select_SYSETINF02 :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_select_SYSETINF '','03'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYSETINF03, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading VNM00001_Load sp_select_SYSETINF03 :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_select_SYSETINF '','04'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYSETINF04, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading VNM00001_Load sp_select_SYSETINF04 :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_select_SYCURRENCY '','N'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYCURRENCY, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading VNM00001_Load sp_select_SYCURRENCY :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_select_SYSETINF '','13'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYSETINF13, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading VNM00001_Load sp_select_SYSETINF13 :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_list_SYCATREL1 ''"
        rtnLong = execute_SQLStatement(gspStr, rs_SYCATREL1, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading VNM00001_Load sp_list_SYCATREL1 :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_list_VNBASINF ''"
        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading VNM00001_Load sp_list_VNBASINF :" & rtnStr)
            Exit Sub
        End If


        gspStr = "sp_select_CUBASINF_VNEXCCUS"
        rtnLong = execute_SQLStatement(gspStr, rs_SYSALLCUS, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading VNM00001_Load sp_list_VNBASINF :" & rtnStr)
            Exit Sub
        End If



        mode = "INIT"
        formInit(mode)
        'format_cboPrcTrm()
        format_cboCty()
        format_cbopaytrm()
        format_cboCurCde()
        format_cboThcCry()
        format_cboVndFlag()
        txtVenNo.Enabled = True



        txtVenNo.Select()
    End Sub

    Private Sub format_itmnat()

        If rs_VNBASINF_READ.Tables.Count = 0 Then
            gspStr = "sp_select_SYITMNAT ''"
        Else
            If rs_VNBASINF_READ.Tables("RESULT").Rows(0).Item("vbi_venflag") = "P" Or rs_VNBASINF_READ.Tables("RESULT").Rows(0).Item("vbi_venflag") = "D" Then
                gspStr = "SP_SELECT_SYITMNAT_31 ''"
            Else
                gspStr = "sp_select_SYITMNAT ''"
            End If
        End If

        'gspStr = "sp_select_SYITMNAT ''"
        rtnLong = execute_SQLStatement(gspStr, rs_SYITMNAT_READ, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdFind_Click sp_select_SYITMNAT :" & rtnStr)
            Exit Sub
        End If


        Dim i As Integer
        Dim strList As String
        cboItmNat.Items.Clear()
        cboItmNat.Items.Add("< None >")
        If rs_SYITMNAT_READ.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_SYITMNAT_READ.Tables("RESULT").Rows.Count - 1
                strList = rs_SYITMNAT_READ.Tables("RESULT").Rows(i).Item("itmnat")
                If strList <> "" Then
                    cboItmNat.Items.Add(strList)

                End If
            Next i
        End If
        cboItmNat.SelectedIndex = 0


    End Sub

    Private Sub format_cboCurCde()
        Dim i As Integer
        Dim strList As String
        cboCurCde.Items.Clear()

        If rs_SYCURRENCY.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_SYCURRENCY.Tables("RESULT").Rows.Count - 1
                strList = rs_SYCURRENCY.Tables("RESULT").Rows(i).Item("ycu_curcde") & " - " & rs_SYCURRENCY.Tables("RESULT").Rows(i).Item("ycu_curnam")
                If strList <> "" Then
                    cboCurCde.Items.Add(strList)

                End If
            Next i
        End If


    End Sub
    Private Sub format_cboThcCry()
        Dim i As Integer
        Dim strList As String
        cboThcCry.Items.Clear()

        If rs_SYCURRENCY.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_SYCURRENCY.Tables("RESULT").Rows.Count - 1
                strList = rs_SYCURRENCY.Tables("RESULT").Rows(i).Item("ycu_curcde")
                If strList <> "" Then
                    cboThcCry.Items.Add(strList)

                End If
            Next i
        End If
    End Sub
    Private Sub format_cbopaytrm()
        Dim i As Integer
        Dim strList As String
        cboPayTrm.Items.Clear()

        If rs_SYSETINF04.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_SYSETINF04.Tables("RESULT").Rows.Count - 1
                strList = rs_SYSETINF04.Tables("RESULT").Rows(i).Item("ysi_cde") & " - " & rs_SYSETINF04.Tables("RESULT").Rows(i).Item("ysi_dsc")
                If strList <> "" Then
                    cboPayTrm.Items.Add(strList)

                End If
            Next i
        End If


    End Sub
    Private Sub format_cboCty()
        Dim i As Integer
        Dim strList As String
        cboCty.Items.Clear()

        If rs_SYSETINF02.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_SYSETINF02.Tables("RESULT").Rows.Count - 1
                strList = rs_SYSETINF02.Tables("RESULT").Rows(i).Item("ysi_cde") & " - " & rs_SYSETINF02.Tables("RESULT").Rows(i).Item("ysi_dsc")
                If strList <> "" Then
                    cboCty.Items.Add(strList)

                End If
            Next i
        End If



    End Sub

    Private Sub format_cboPrcTrm()
        Dim i As Integer
        Dim strList As String
        cboPrcTrm.Items.Clear()

        If rs_SYSETINF03.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_SYSETINF03.Tables("RESULT").Rows.Count - 1
                strList = rs_SYSETINF03.Tables("RESULT").Rows(i).Item("ysi_cde") & " - " & rs_SYSETINF03.Tables("RESULT").Rows(i).Item("ysi_dsc")
                If strList <> "" Then
                    cboPrcTrm.Items.Add(strList)

                End If
            Next i
        End If

    End Sub

    Private Sub format_cboVndFlag()
        cboVndFlag.Items.Clear()
        cboVndFlag.Items.Add("U - UCP Vendor")
        cboVndFlag.Items.Add("M - MPO")
        cboVndFlag.Items.Add("P - Printing")
        cboVndFlag.Items.Add("D - Design House")
    End Sub


    Private Sub format_cboTranFlag()
        cboTranFlag.Items.Clear()
        cboTranFlag.Items.Add("Y")
        cboTranFlag.Items.Add("N")

    End Sub
    Private Sub format_cboVenType()
        cboVenType.Items.Clear()
        cboVenType.Items.Add("Internal")
        cboVenType.Items.Add("External")
        cboVenType.Items.Add("Joint Venture")
    End Sub

    Private Sub format_cboVenSts()
        cboVenSts.Items.Clear()

        cboVenSts.Items.Add("A - Active")
        cboVenSts.Items.Add("D - Discontinue")
        cboVenSts.Items.Add("I - Inactive")



    End Sub

    Private Sub format_cboVenRat()
        cboVenRat.Items.Clear()

        cboVenRat.Items.Add("A - Top Grade")
        cboVenRat.Items.Add("B - High Grade")
        cboVenRat.Items.Add("C - Upper Middle Grade")
        cboVenRat.Items.Add("D - Lower Middle Grade")
        cboVenRat.Items.Add("E - Low Grade")


    End Sub
    Private Sub resetcmdButton(ByVal Mode As String)
        If Mode = "INIT" Then
            mmdAdd.Enabled = Enq_right_local
            mmdSave.Enabled = False
            mmdDelete.Enabled = False
            mmdCopy.Enabled = False 'True '*** For Access Right use, added by Tommy on 5 Oct 2001
            mmdFind.Enabled = True
            mmdInsRow.Enabled = False
            mmdDelRow.Enabled = False
            mmdExit.Enabled = True
            mmdClear.Enabled = True
            mmdSearch.Enabled = True

            Me.mmdPrint.Enabled = False
            Me.mmdAttach.Enabled = False
            Me.mmdFunction.Enabled = False
            Me.mmdLink.Enabled = False

            Add_flag = False
            txtVenNo.Enabled = True


            '   cmdAddCat.Enabled = False '''

        ElseIf Mode = "DisableAll" Then 'For copy disable
            mmdAdd.Enabled = False
            mmdSave.Enabled = False
            mmdDelete.Enabled = False
            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdInsRow.Enabled = False
            mmdDelRow.Enabled = False
            mmdClear.Enabled = False
            mmdSearch.Enabled = False



            txtVenNam.Enabled = False
            txtVenChnNam.Enabled = False
            chkfty.Enabled = False
            txtVenSna.Enabled = False
            chkDiCoTi.Enabled = False
            chkActivate.Enabled = False
            ChkMOQChg.Enabled = False




        End If

    End Sub
    Private Sub resetdisplay(ByVal mode As String)
        If mode = "INIT" Then

            txtVenNam.ReadOnly = False


            txtVenChnNam.ReadOnly = False


            txtVenSna.ReadOnly = False


            txtRmk.ReadOnly = False


            txtAdr2.ReadOnly = False


            txtAdr.ReadOnly = False



            txtVenNo.Enabled = True
            txtVenNo.Text = ""
            txtVenNam.Text = ""
            txtVenSna.Text = ""
            txtDisCnt.Text = ""
            txtLedTim.Text = ""
            txtTstTim.Text = ""
            txtBufDay.Text = ""
            txtOrgVen.Text = ""
            txtRmk.Text = ""
            txtVenChnNam.Text = ""



            cboTranFlag.Items.Clear()
            format_cboTranFlag()

            cboPrcTrm.Text = ""
            cboCty.Text = ""

            cboPayTrm.Text = ""
            cboPayTrm.Visible = True
            txtPayTrm.Text = ""
            txtPayTrm.Visible = False
            txtPayTrm.ReadOnly = True

            cboCurCde.Text = ""
            cboVenRat.Text = ""
            cboVenSts.SelectedIndex = -1
            chkActivate.Checked = False
            chkActivate.Visible = False
            chkDiCoTi.Checked = False
            chkfty.Checked = False



            freeze_TabControl(0)
            Me.BaseTabControl1.SelectedIndex = 0
            'grdBasicCat.datasource 
            grdItmNat.DataSource = Nothing
            cboItmNat.Enabled = False
            cboItmNat.Items.Clear()

            txtAdr.Text = ""
            txtAdr2.Text = ""

            txtTown.Text = ""
            txtTown2.Text = ""

            txtCity.Text = ""
            txtCity2.Text = ""

            txtStt.Text = ""
            txtStt2.Text = ""

            txtZip.Text = ""
            txtZip2.Text = ""

            cboCty.Text = ""
            cboCty2.Text = ""

            txtEngAdrDisplay.Text = ""
            txtChnAdrDisplay.Text = ""

            'cboCty.SelectedText = "CN - China"
            txtVenWeb.Text = ""
            grdVnCntInf.DataSource = Nothing

            Me.StatusBar.Items("lblLeft").Text = ""
            Me.StatusBar.Items("lblRight").Text = ""
            'lstCty.DataSource = Nothing
            'lstCty.Visible = False

        ElseIf mode = "ReadOnly" Then

            txtVenNam.Enabled = True
            txtVenNam.ReadOnly = True

            txtVenChnNam.Enabled = True
            txtVenChnNam.ReadOnly = True

            txtVenSna.Enabled = True
            txtVenSna.ReadOnly = True

            txtRmk.Enabled = True
            txtRmk.ReadOnly = True

            txtAdr.Enabled = True
            txtAdr.ReadOnly = True
            txtAdr2.Enabled = True
            txtAdr2.ReadOnly = True

            txtTown.Enabled = True
            txtTown.ReadOnly = True
            txtTown2.Enabled = True
            txtTown2.ReadOnly = True

            txtCity.Enabled = True
            txtCity.ReadOnly = True
            txtCity2.Enabled = True
            txtCity2.ReadOnly = True

            txtStt.Enabled = True
            txtStt.ReadOnly = True
            txtStt2.Enabled = True
            txtStt2.ReadOnly = True

            txtZip.Enabled = True
            txtZip.ReadOnly = True
            txtZip2.Enabled = True
            txtZip2.ReadOnly = True

            cboCty.Enabled = False
            cboCty2.Enabled = False

            cboPayTrm.Visible = False
            txtPayTrm.Enabled = True
            txtPayTrm.ReadOnly = True
            txtPayTrm.Visible = True


            txtVenNo.Enabled = False
            cmdAddItmNat.Enabled = False
            mmdAdd.Enabled = False
            mmdSave.Enabled = False
            mmdFind.Enabled = False
            mmdDelete.Enabled = Del_right_local
            mmdCopy.Enabled = Enq_right_local
            mmdInsRow.Enabled = False
            mmdDelRow.Enabled = False
            mmdSearch.Enabled = False
            mmdClear.Enabled = True
            If Microsoft.VisualBasic.Left(cboVenSts.Text, 1) = "D" And Enq_right_local = True And gsUsrRank <= 4 Then
                chkDiCoTi.Enabled = True



            End If

            Call SetStatusBar(mode)



        ElseIf mode = "UPDATE" Then
            txtVenNo.Enabled = False
            txtVenNam.Enabled = True
            txtVenChnNam.Enabled = True
            chkfty.Enabled = True
            txtVenSna.Enabled = True
            chkDiCoTi.Enabled = True
            ChkMOQChg.Enabled = True
            cboVenRat.Enabled = True
            cboPrcTrm.Enabled = True

            cboPayTrm.Visible = True
            cboPayTrm.Enabled = True
            txtPayTrm.Visible = False

            cboCurCde.Enabled = True
            txtDisCnt.Enabled = True
            cboTranFlag.Enabled = True
            txtLedTim.Enabled = True
            txtTstTim.Enabled = True
            txtBufDay.Enabled = True
            txtRmk.Enabled = True
            cboItmNat.Enabled = True
            GroupBox1.Enabled = True
            GroupBox2.Enabled = True

            GroupBox3.Enabled = True
            cboThcCry.Enabled = True
            cboVndFlag.Enabled = True
            txtThcAmt.Enabled = True


            txtAdr.Enabled = True
            txtAdr.ReadOnly = False
            txtAdr2.Enabled = True
            txtAdr2.ReadOnly = False

            txtTown.Enabled = True
            txtTown.ReadOnly = False
            txtTown2.Enabled = True
            txtTown2.ReadOnly = False

            txtCity.Enabled = True
            txtCity.ReadOnly = False
            txtCity2.Enabled = True
            txtCity2.ReadOnly = False

            txtStt.Enabled = True
            txtStt.ReadOnly = False
            txtStt2.Enabled = True
            txtStt2.ReadOnly = False

            txtZip.Enabled = True
            txtZip.ReadOnly = False
            txtZip2.Enabled = True
            txtZip2.ReadOnly = False

            cboCty.Enabled = True
            cboCty2.Enabled = True

            txtVenWeb.Enabled = True

            mmdClear.Enabled = True
            cmdAddItmNat.Enabled = False
            mmdAdd.Enabled = False
            mmdSave.Enabled = True
            mmdFind.Enabled = False
            mmdDelete.Enabled = True
            mmdCopy.Enabled = Enq_right_local
            mmdInsRow.Enabled = True
            mmdDelRow.Enabled = True
            mmdSearch.Enabled = False
            Call SetStatusBar(mode)
        ElseIf mode = "ADD" Then
            txtVenNo.Enabled = False
            txtVenNam.Enabled = True
            txtVenChnNam.Enabled = True
            chkfty.Enabled = True
            txtVenSna.Enabled = True
            chkDiCoTi.Enabled = True
            ChkMOQChg.Enabled = True
            cboVenRat.Enabled = True
            cboPrcTrm.Enabled = True

            cboPayTrm.Visible = True
            cboPayTrm.Enabled = True
            txtPayTrm.Visible = False

            cboCurCde.Enabled = True
            txtDisCnt.Enabled = True
            cboTranFlag.Enabled = True
            txtLedTim.Enabled = True
            txtTstTim.Enabled = True
            txtBufDay.Enabled = True
            txtRmk.Enabled = True
            cboItmNat.Enabled = True
            GroupBox1.Enabled = True
            GroupBox2.Enabled = True

            GroupBox3.Enabled = True
            cboThcCry.Enabled = True
            cboVndFlag.Enabled = True
            txtThcAmt.Enabled = True


            txtAdr.Enabled = True
            txtAdr.ReadOnly = False
            txtAdr2.Enabled = True
            txtAdr2.ReadOnly = False

            txtTown.Enabled = True
            txtTown.ReadOnly = False
            txtTown2.Enabled = True
            txtTown2.ReadOnly = False

            txtCity.Enabled = True
            txtCity.ReadOnly = False
            txtCity2.Enabled = True
            txtCity2.ReadOnly = False

            txtStt.Enabled = True
            txtStt.ReadOnly = False
            txtStt2.Enabled = True
            txtStt2.ReadOnly = False

            txtZip.Enabled = True
            txtZip.ReadOnly = False
            txtZip2.Enabled = True
            txtZip2.ReadOnly = False

            cboCty.Enabled = True
            cboCty2.Enabled = True


            txtVenWeb.Enabled = True


            txtDisCnt.Text = 0
            txtTstTim.Text = 0
            txtLedTim.Text = 0
            txtBufDay.Text = 0
            txtOrgVen.Text = ""
            txtRmk.Text = ""

            cboTranFlag.Items.Clear()
            format_cboTranFlag()

            InitGrid()
            'call
            chkDiCoTi.Enabled = False
            txtVenNo.Enabled = False

            Me.BaseTabControl1.TabPages(1).Enabled = True
            Me.BaseTabControl1.TabPages(2).Enabled = True
            Me.BaseTabControl1.TabPages(3).Enabled = True
            Me.BaseTabControl1.TabPages(4).Enabled = True


            mmdSave.Enabled = Enq_right_local
            mmdDelete.Enabled = False
            mmdFind.Enabled = False
            mmdAdd.Enabled = False
            mmdSearch.Enabled = False
            mmdInsRow.Enabled = True
            mmdDelRow.Enabled = True
            mmdCopy.Enabled = False




            Call SetStatusBar(mode)
            chkDiCoTi.Enabled = False

            If Focus() Then
                txtVenNam.Focus()
            End If

            Call format_itmnat()


        End If



    End Sub
    Private Sub SetStatusBar(ByVal mode As String)

        If mode = "INIT" Then
            Me.StatusBar.Items("lblLeft").Text = "Init"
        ElseIf mode = "ADD" Then
            Me.StatusBar.Items("lblLeft").Text = "Add"
        ElseIf mode = "UPDATE" Then
            Me.StatusBar.Items("lblLeft").Text = "Updating"
        ElseIf mode = "Save" Then
            Me.StatusBar.Items("lblLeft").Text = "Record Saved"
        ElseIf mode = "DelRow" Then
            Me.StatusBar.Items("lblLeft").Text = "Record Row Deleted"
        ElseIf mode = "ReadOnly" Then
            Me.StatusBar.Items("lblLeft").Text = "Read Only"
        ElseIf mode = "Clear" Then
            Me.StatusBar.Items("lblLeft").Text = "Clear Screen"
        End If
    End Sub
    Private Sub freeze_TabControl(ByVal tabpageno As Integer)
        Dim i As Integer
        For i = 0 To BaseTabControl1.TabPages.Count - 1
            If i = tabpageno Then
                Me.BaseTabControl1.TabPages(i).Enabled = True
            Else
                Me.BaseTabControl1.TabPages(i).Enabled = False
            End If
        Next i
    End Sub
    Private Sub formInit(ByVal m As String)
        If m = "INIT" Then
            Call clearAllDisplay(Me)
        End If

        Call resetcmdButton(m)

        Call resetdisplay(m)

        'Me.StatusBar.Text = m
        SetStatusBar(m)

    End Sub
    Private Sub clearAllDisplay(ByVal fv As Control)
        Dim v As Control
        For Each v In fv.Controls

            If TypeOf v Is BaseTabControl Then
                Dim btc As BaseTabControl
                btc = v
                Dim i As Integer
                For i = 0 To btc.TabPages.Count - 1
                    Call clearAllDisplay(btc.TabPages(i))
                Next i
            ElseIf TypeOf v Is GroupBox Then
                Call clearAllDisplay(v)
                v.Enabled = False
            Else
                If TypeOf v Is TextBox Or TypeOf v Is MaskedTextBox Or TypeOf v Is ComboBox Or TypeOf v Is RichTextBox Then
                    v.Text = ""
                    v.Enabled = False
                ElseIf TypeOf v Is ListBox Then
                    Dim lb As ListBox
                    lb = v
                    lb.Items.Clear()
                    v.Enabled = False
                ElseIf TypeOf v Is CheckBox Then
                    Dim cb As CheckBox
                    cb = v
                    cb.Checked = False
                    v.Enabled = False
                ElseIf TypeOf v Is DataGridView Then
                    Dim dg As DataGridView
                    dg = v
                    dg.DataSource = Nothing
                End If
            End If
        Next v

    End Sub

    Private Sub txtVenNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVenNo.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then

            Call mmdFind_Click(sender, e)
        End If
    End Sub

    Private Sub txtVenNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVenNo.TextChanged

    End Sub

    Public Sub mmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdFind.Click

        Me.Cursor = Cursors.WaitCursor

        txtVenNo.Text = UCase(txtVenNo.Text)

        cboVenType.Items.Clear()
        cboVenType.Items.Add("Internal")
        cboVenType.Items.Add("External")
        cboVenType.Items.Add("Joint Venture")


        If Enq_right_local Then
            mode = "UPDATE"
        Else
            mode = "ReadOnly"
        End If

        If Trim(txtVenNo.Text) = "" Then
            MsgBox("Please input Item No.")
            txtVenNo.Focus()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        gspStr = "sp_select_VNBASINF '','" & txtVenNo.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF_READ, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdFind_Click sp_select_VNBASINF :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If


        If rs_VNBASINF_READ.Tables("RESULT").Rows.Count <= 0 Then
            MsgBox("Not Record Found")
            txtVenNo.Focus()
            Me.Cursor = Cursors.Default
            Exit Sub

        Else
            Add_flag = False
            current_timstamp = rs_VNBASINF_READ.Tables("RESULT").Rows(0).Item("vbi_timstp")

            gspStr = "sp_list_VNCATREL '','" & txtVenNo.Text & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_VNCATREL_READ, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cmdFind_Click sp_list_VNCATREL :" & rtnStr)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            Dim code As String = rs_VNBASINF_READ.Tables("RESULT").Rows(0).Item("vbi_venflag")

            If code = "P" Or code = "D" Then
                gspStr = "sp_list_VNITMNAT '','" & txtVenNo.Text & "','" & "31" & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_VNITMNAT_READ, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading cmdFind_Click sp_list_VNITMNAT :" & rtnStr)
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
            Else
                gspStr = "sp_list_VNITMNAT '','" & txtVenNo.Text & "','" & "25" & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_VNITMNAT_READ, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading cmdFind_Click sp_list_VNITMNAT :" & rtnStr)
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
            End If

            gspStr = "sp_list_VNCNTINF '','" & txtVenNo.Text & "','M','ADR'"
            rtnLong = execute_SQLStatement(gspStr, rs_VNCNTINF_M_READ, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cmdFind_Click sp_list_VNCNTINF_M :" & rtnStr)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            gspStr = "sp_list_VNCNTINF '','" & txtVenNo.Text & "','C','ADR'"
            rtnLong = execute_SQLStatement(gspStr, rs_VNCNTINF_C_READ, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cmdFind_Click sp_list_VNCNTINF_M :" & rtnStr)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If



            gspStr = "sp_list_VNCNTINF '','" & txtVenNo.Text & "','Q','ADR'"
            '            gspStr = "sp_list_VNCNTINF '','" & txtVenNo.Text & "','U','ADR'"
            rtnLong = execute_SQLStatement(gspStr, rs_VNCNTINF_U_READ, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cmdFind_Click sp_list_VNCNTINF_U :" & rtnStr)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If


            gspStr = "sp_list_VNCNTINF '','" & txtVenNo.Text & "','*','PER'"
            rtnLong = execute_SQLStatement(gspStr, rs_VNCNTPER_READ, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cmdFind_Click sp_list_VNCNTINF_*_PER :" & rtnStr)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If


            gspStr = "sp_list_VNCSEINF '','" & txtVenNo.Text & "','B'"
            rtnLong = execute_SQLStatement(gspStr, rs_VNCSEINF_B_READ, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cmdFind_Click sp_list_VNCSEINF_B :" & rtnStr)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If


            gspStr = "sp_list_VNPUCINF '','" & txtVenNo.Text & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_VNPUCINF_READ, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cmdFind_Click sp_list_VNPUCINF :" & rtnStr)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If


            gspStr = "sp_select_VNSUBVN '','" & txtVenNo.Text & "','V'"
            rtnLong = execute_SQLStatement(gspStr, rs_VNSUBVN_V_READ, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cmdFind_Click sp_select_VNSUBVN_V :" & rtnStr)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            gspStr = "sp_select_VNSUBVN '','" & txtVenNo.Text & "','F'"
            rtnLong = execute_SQLStatement(gspStr, rs_VNSUBVN_F_READ, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cmdFind_Click sp_select_VNSUBVN_F :" & rtnStr)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            gspStr = "sp_list_VNBASINF ''"
            rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF_ALL, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cmdFind_Click sp_list_VNBASINF :" & rtnStr)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            gspStr = "sp_list_VNCUGREL '','" & txtVenNo.Text & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_VNCUGREL_READ, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cmdFind_Click sp_list_VNCUGREL :" & rtnStr)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            gspStr = "sp_list_vnprctrm '','" & txtVenNo.Text & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_VNPRCTRM_READ, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cmdFind_Click sp_list_vnprctrm :" & rtnStr)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If


            gspStr = "sp_select_VNEXCCUS '','" & txtVenNo.Text & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_VNEXCCUS, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cmdADD_Click sp_select_VNEXCCUS :" & rtnStr)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If


            'gspStr = "sp_select_SYITMNAT ''"
            'rtnLong = execute_SQLStatement(gspStr, rs_SYITMNAT_READ, rtnStr)
            'If rtnLong <> RC_SUCCESS Then
            '    MsgBox("Error on loading cmdFind_Click sp_select_SYITMNAT :" & rtnStr)
            '    Exit Sub
            'End If




            Call display()
            Call resetdisplay(mode) 'do

            If Microsoft.VisualBasic.Left(cboVenSts.Text, 1) = "I" And Enq_right_local = True And gsUsrRank <= 4 Then
                chkActivate.Visible = True
                chkActivate.Enabled = True
                mmdSave.Enabled = True
            Else
                chkActivate.Visible = False
                chkActivate.Enabled = False

            End If


            If Microsoft.VisualBasic.Left(cboVenSts.Text, 1) = "D" And Enq_right_local = True And gsUsrRank <= 4 Then

                chkDiCoTi.Enabled = True



            End If



            If gsUsrGrp = "CED-S" Or gsUsrGrp = "EDP-S" Or gsUsrGrp = "MSAL-A" Or gsUsrRank = 1 Then
                Me.BaseTabControl1.TabPages(4).Enabled = True
                '                grdVnPucInf.TabStop = True
            Else
                Me.BaseTabControl1.TabPages(4).Enabled = False
                'Modified by Victor Leung 20030122
                '-- Prevent the tab function to display the folder "Purchase Summary"
                '-- Depended on Access right
                grdVnPucInf.TabStop = False
                grdVnPucInf.Visible = False
            End If


            format_itmnat()

            If (Microsoft.VisualBasic.Left(cboVenSts.Text, 1) = "D" Or Microsoft.VisualBasic.Left(cboVenSts.Text, 1) = "A") And gsUsrRank <= 4 And Enq_right_local = True Then
                chkDiCoTi.Visible = True
            Else
                chkDiCoTi.Visible = False
            End If

        End If


        Me.Cursor = Cursors.Default

        'txtVenNam.Select()


    End Sub
    Private Sub display()

        Dim tmpString As String

        'tap1

        txtVenNo.Text = rs_VNBASINF_READ.Tables("RESULT").Rows(0).Item("vbi_venno")
        txtVenNam.Text = rs_VNBASINF_READ.Tables("RESULT").Rows(0).Item("vbi_vennam")
        txtVenChnNam.Text = rs_VNBASINF_READ.Tables("RESULT").Rows(0).Item("vbi_venchnnam")
        txtVenSna.Text = rs_VNBASINF_READ.Tables("RESULT").Rows(0).Item("vbi_vensna")

        tmpString = rs_VNBASINF_READ.Tables("RESULT").Rows(0).Item("vbi_discnt")
        txtDisCnt.Text = Str(tmpString)
        txtDisCnt.Text = Trim(txtDisCnt.Text)
        If txtDisCnt.Text.StartsWith(".") Then
            txtDisCnt.Text = "0" + txtDisCnt.Text
        End If

        cboTranFlag.Text = rs_VNBASINF_READ.Tables("RESULT").Rows(0).Item("vbi_ventranflg")



        txtOrgVen.Text = rs_VNBASINF_READ.Tables("RESULT").Rows(0).Item("vbi_orgven")

        txtRmk.Text = rs_VNBASINF_READ.Tables("RESULT").Rows(0).Item("vbi_rmk")


        txtLedTim.Text = rs_VNBASINF_READ.Tables("RESULT").Rows(0).Item("vbi_ledtim")


        txtTstTim.Text = rs_VNBASINF_READ.Tables("RESULT").Rows(0).Item("vbi_tsttim")


        txtBufDay.Text = rs_VNBASINF_READ.Tables("RESULT").Rows(0).Item("vbi_bufday")


        txtVenWeb.Text = rs_VNBASINF_READ.Tables("RESULT").Rows(0).Item("vbi_venweb")


        Dim ventyp As String = rs_VNBASINF_READ.Tables("RESULT").Rows(0).Item("vbi_ventyp")
        If ventyp = "I" Then
            cboVenType.SelectedIndex = 0

            Me.BaseTabControl1.TabPages(1).Enabled = True '''(2)
            Me.BaseTabControl1.TabPages(2).Enabled = True '''(3)
            Me.BaseTabControl1.TabPages(3).Enabled = True '''(4)
            Me.BaseTabControl1.TabPages(4).Enabled = True '''(5)
            Me.BaseTabControl1.TabPages(5).Enabled = False
        ElseIf ventyp = "E" Then
            cboVenType.SelectedIndex = 1

            Me.BaseTabControl1.TabPages(1).Enabled = True '''(2)
            Me.BaseTabControl1.TabPages(2).Enabled = True '''(3)
            Me.BaseTabControl1.TabPages(3).Enabled = True '''(4)
            Me.BaseTabControl1.TabPages(4).Enabled = True '''(5)
            Me.BaseTabControl1.TabPages(5).Enabled = True
        ElseIf ventyp = "J" Then
            cboVenType.SelectedIndex = 2

            Me.BaseTabControl1.TabPages(1).Enabled = True '''(2)
            Me.BaseTabControl1.TabPages(2).Enabled = True '''(3)
            Me.BaseTabControl1.TabPages(3).Enabled = True '''(4)
            Me.BaseTabControl1.TabPages(4).Enabled = True '''(5)
            Me.BaseTabControl1.TabPages(5).Enabled = False
        Else
            cboVenType.SelectedIndex = -1

            Me.BaseTabControl1.TabPages(1).Enabled = True '''(2)
            Me.BaseTabControl1.TabPages(2).Enabled = True '''(3)
            Me.BaseTabControl1.TabPages(3).Enabled = True '''(4)
            Me.BaseTabControl1.TabPages(4).Enabled = True '''(5)
            Me.BaseTabControl1.TabPages(5).Enabled = False
        End If

        Dim venfty As String = rs_VNBASINF_READ.Tables("RESULT").Rows(0).Item("vbi_venfty")
        If venfty = "F" Then
            chkfty.Checked = True
        Else
            chkfty.Checked = False
        End If

        Dim moqchg As String = rs_VNBASINF_READ.Tables("RESULT").Rows(0).Item("vbi_moqchg")
        If moqchg = "Y" Then
            ChkMOQChg.Checked = True
        Else
            ChkMOQChg.Checked = False
        End If


        Call display_combo(rs_VNBASINF_READ.Tables("RESULT").Rows(0).Item("vbi_vensts"), cboVenSts)
        If rs_VNBASINF_READ.Tables("RESULT").Rows(0).Item("vbi_vensts").ToString = "D" Then
            chkDiCoTi.Checked = True
        Else
            chkDiCoTi.Checked = False
        End If

        If Split(cboVenSts.Text, " - ")(0) = "I" Or Split(cboVenSts.Text, " - ")(0) = "D" Then
            mode = "ReadOnly"

        End If


        Call display_combo(rs_VNBASINF_READ.Tables("RESULT").Rows(0).Item("vbi_venrat"), cboVenRat)
        'Call display_combo(rs_VNBASINF_READ.Tables("RESULT").Rows(0).Item("vbi_prctrm"), cboPrcTrm)
        Call display_combo(rs_VNBASINF_READ.Tables("RESULT").Rows(0).Item("vbi_paytrm"), cboPayTrm)
        txtPayTrm.Text = cboPayTrm.Text

        Call display_combo(rs_VNBASINF_READ.Tables("RESULT").Rows(0).Item("vbi_curcde"), cboCurCde)

        display_grdItmNat("VNM")

        'tap2
        txtAdr.Text = rs_VNCNTINF_M_READ.Tables("RESULT").Rows(0).Item("vci_adrdtl")
        txtStt.Text = rs_VNCNTINF_M_READ.Tables("RESULT").Rows(0).Item("vci_stt")
        txtCity.Text = rs_VNCNTINF_M_READ.Tables("RESULT").Rows(0).Item("vci_city")
        txtTown.Text = rs_VNCNTINF_M_READ.Tables("RESULT").Rows(0).Item("vci_town")
        'cboCty.Text = rs_VNCNTINF_M_READ.Tables("RESULT").Rows(0).Item("vci_cty")
        Call display_combo(rs_VNCNTINF_M_READ.Tables("RESULT").Rows(0).Item("vci_cty"), cboCty)
        txtZip.Text = rs_VNCNTINF_M_READ.Tables("RESULT").Rows(0).Item("vci_zip")
        txtEngAdrDisplay.Text = rs_VNCNTINF_M_READ.Tables("RESULT").Rows(0).Item("vci_adr")


        If rs_VNCNTINF_C_READ.Tables("RESULT").Rows.Count > 0 Then
            txtAdr2.Text = rs_VNCNTINF_C_READ.Tables("RESULT").Rows(0).Item("vci_adrdtl")
            txtStt2.Text = rs_VNCNTINF_C_READ.Tables("RESULT").Rows(0).Item("vci_stt")
            txtCity2.Text = rs_VNCNTINF_C_READ.Tables("RESULT").Rows(0).Item("vci_city")
            txtTown2.Text = rs_VNCNTINF_C_READ.Tables("RESULT").Rows(0).Item("vci_town")
            txtZip2.Text = rs_VNCNTINF_C_READ.Tables("RESULT").Rows(0).Item("vci_zip")
            If IsDBNull(rs_VNCNTINF_C_READ.Tables("RESULT").Rows(0).Item("vci_cty")) Then
                cboCty2.Text = ""
            Else
                cboCty2.Text = rs_VNCNTINF_C_READ.Tables("RESULT").Rows(0).Item("vci_cty")
            End If
            txtChnAdrDisplay.Text = rs_VNCNTINF_C_READ.Tables("RESULT").Rows(0).Item("vci_adr")
        End If



        txtThcAmt.Text = rs_VNBASINF_READ.Tables("RESULT").Rows(0).Item("vbi_framt")

        cboThcCry.Text = rs_VNBASINF_READ.Tables("RESULT").Rows(0).Item("vbi_frurcde")



        Call display_combo(rs_VNBASINF_READ.Tables("RESULT").Rows(0).Item("vbi_venflag"), cboVndFlag)

        display_grdVnCntInf("VNM")


        'tap3
        display_grdVnCntPer("VNM")

        'tap4

        display_grdVnCseBnk("VNM")

        'tap5
        display_grdVnPucInf("VNM")

        'tap6
        display_grdFactoryRel("VNM")
        display_grdVendorRel("VNM")

        display_grdvengrp("VNM")
        display_grdPceTme("VNM")


        display_grdExcCus()

        Dim tmpcredat As DateTime
        Dim tmpupddat As DateTime

        tmpcredat = rs_VNBASINF_READ.Tables("RESULT").Rows(0).Item("vbi_credat")
        tmpupddat = rs_VNBASINF_READ.Tables("RESULT").Rows(0).Item("vbi_upddat")

        Me.StatusBar.Items("lblRight").Text = tmpcredat.Date & " " & tmpupddat.Date & " " & rs_VNBASINF_READ.Tables("RESULT").Rows(0).Item("vbi_updusr")






    End Sub
    Private Sub display_grdItmNat(ByVal type As String)
        If rs_VNITMNAT_READ.Tables.Count = 0 Then
            Exit Sub
        End If

        If type = "VNM" Then
            grdItmNat.DataSource = rs_VNITMNAT_READ.Tables("RESULT").DefaultView
        End If

        grdItmNat.RowHeadersWidth = 18
        grdItmNat.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        grdItmNat.ColumnHeadersHeight = 18
        grdItmNat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        grdItmNat.AllowUserToResizeColumns = False
        grdItmNat.AllowUserToResizeRows = False
        grdItmNat.RowTemplate.Height = 18

        Dim i As Integer

        'If mode = "UPDATE" Or mode = "ADD" Then
        For i = 0 To rs_VNITMNAT_READ.Tables("RESULT").Columns.Count - 1
            rs_VNITMNAT_READ.Tables("RESULT").Columns(i).ReadOnly = False
        Next i
        'End If


        i = 0
        grdItmNat_vin_status = i
        grdItmNat.Columns(i).HeaderText = "Del"
        grdItmNat.Columns(i).Width = 30
        grdItmNat.Columns(i).ReadOnly = True
        i = i + 1 '1
        grdItmNat_vin_venno = i
        grdItmNat.Columns(i).Visible = False
        i = i + 1 '2
        grdItmNat_vin_itmnat = i
        grdItmNat.Columns(i).HeaderText = "Item Nature"
        grdItmNat.Columns(i).Width = 200
        grdItmNat.Columns(i).ReadOnly = True
        i = i + 1 '3
        grdItmNat_vin_creusr = i
        grdItmNat.Columns(i).Visible = False
        i = i + 1 '4
        grdItmNat_vin_natseq = i
        grdItmNat.Columns(i).Visible = False


    End Sub
    Private Sub display_grdVnCntInf(ByVal type As String)
        If rs_VNCNTINF_U_READ.Tables.Count = 0 Then
            Exit Sub
        End If

        If type = "VNM" Then
            grdVnCntInf.DataSource = rs_VNCNTINF_U_READ.Tables("RESULT").DefaultView
        End If

        grdVnCntInf.RowHeadersWidth = 18
        grdVnCntInf.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        grdVnCntInf.ColumnHeadersHeight = 18
        grdVnCntInf.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        grdVnCntInf.AllowUserToResizeColumns = True
        grdVnCntInf.AllowUserToResizeRows = False
        grdVnCntInf.RowTemplate.Height = 18

        Dim i As Integer

        'If mode = "UPDATE" Or mode = "ADD" Then
        For i = 0 To rs_VNCNTINF_U_READ.Tables("RESULT").Columns.Count - 1
            rs_VNCNTINF_U_READ.Tables("RESULT").Columns(i).ReadOnly = False
        Next i
        'End If


        i = 0
        grdVnCntInf_vci_status = i
        grdVnCntInf.Columns(i).HeaderText = "Del"
        grdVnCntInf.Columns(i).Width = 30
        grdItmNat.Columns(i).ReadOnly = True
        i = i + 1 '1
        grdVnCntInf_vci_cnttyp = i
        grdVnCntInf.Columns(i).HeaderText = "Type"
        grdVnCntInf.Columns(i).Width = 43

        grdVnCntInf.Columns(i).ReadOnly = False

        i = i + 1 '2
        grdVnCntInf_vci_adr = i
        grdVnCntInf.Columns(i).HeaderText = "Address"
        grdVnCntInf.Columns(i).Width = 300
        If mode = "UPDATE" Or mode = "ADD" Then
            grdVnCntInf.Columns(i).ReadOnly = False
        Else
            grdVnCntInf.Columns(i).ReadOnly = True
        End If
        i = i + 1 '3
        grdVnCntInf_vci_town = i
        grdVnCntInf.Columns(i).HeaderText = "Town"
        grdVnCntInf.Columns(i).Width = 90
        If mode = "UPDATE" Or mode = "ADD" Then
            grdVnCntInf.Columns(i).ReadOnly = False
        Else
            grdVnCntInf.Columns(i).ReadOnly = True
        End If
        i = i + 1 '4
        grdVnCntInf_vci_city = i
        grdVnCntInf.Columns(i).HeaderText = "City"
        grdVnCntInf.Columns(i).Width = 90
        If mode = "UPDATE" Or mode = "ADD" Then
            grdVnCntInf.Columns(i).ReadOnly = False
        Else
            grdVnCntInf.Columns(i).ReadOnly = True
        End If
        i = i + 1 '5
        grdVnCntInf_vci_stt = i
        grdVnCntInf.Columns(i).HeaderText = "State/Province"
        grdVnCntInf.Columns(i).Width = 130
        If mode = "UPDATE" Or mode = "ADD" Then
            grdVnCntInf.Columns(i).ReadOnly = False
        Else
            grdVnCntInf.Columns(i).ReadOnly = True
        End If
        i = i + 1 '6
        grdVnCntInf_vci_cty = i
        grdVnCntInf.Columns(i).HeaderText = "Country"
        grdVnCntInf.Columns(i).Width = 125

        grdVnCntInf.Columns(i).ReadOnly = True

        i = i + 1 '7
        grdVnCntInf_vci_zip = i
        grdVnCntInf.Columns(i).HeaderText = "Zip/Postal"
        grdVnCntInf.Columns(i).Width = 110
        If mode = "UPDATE" Or mode = "ADD" Then
            grdVnCntInf.Columns(i).ReadOnly = False
        Else
            grdVnCntInf.Columns(i).ReadOnly = True
        End If
        i = i + 1 '8
        grdVnCntInf_vci_creusr = i
        grdVnCntInf.Columns(i).Visible = False
        i = i + 1 '9
        grdVnCntInf_vci_seq = i
        grdVnCntInf.Columns(i).Visible = False
        i = i + 1 '10
        grdVnCntInf_vci_chnadr = i
        grdVnCntInf.Columns(i).Visible = False
        i = i + 1 '11
        grdVnCntInf_vci_adrdtl = i
        grdVnCntInf.Columns(i).Visible = False

    End Sub
    Private Sub display_grdVnCntPer(ByVal type As String)
        If rs_VNCNTPER_READ.Tables.Count = 0 Then
            Exit Sub
        End If

        If type = "VNM" Then
            grdVnCntPer.DataSource = rs_VNCNTPER_READ.Tables("RESULT").DefaultView
        End If

        grdVnCntPer.RowHeadersWidth = 18
        grdVnCntPer.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        grdVnCntPer.ColumnHeadersHeight = 18
        grdVnCntPer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        grdVnCntPer.AllowUserToResizeColumns = True
        grdVnCntPer.AllowUserToResizeRows = False
        grdVnCntPer.RowTemplate.Height = 18


        Dim i As Integer

        For i = 0 To rs_VNCNTPER_READ.Tables("RESULT").Columns.Count - 1
            rs_VNCNTPER_READ.Tables("RESULT").Columns(i).ReadOnly = False
        Next i

        i = 0
        grdVnCntPer_vci_status = i
        grdVnCntPer.Columns(i).HeaderText = "Del"
        grdVnCntPer.Columns(i).Width = 30
        grdVnCntPer.Columns(i).ReadOnly = True
        i = i + 1
        grdVnCntPer_vci_cnttyp = i
        grdVnCntPer.Columns(i).HeaderText = "Nature"
        grdVnCntPer.Columns(i).Width = 80
        grdVnCntPer.Columns(i).ReadOnly = True
        i = i + 1
        grdVnCntPer_vci_cntctp = i
        grdVnCntPer.Columns(i).HeaderText = "Contact Person"
        grdVnCntPer.Columns(i).Width = 120
        If mode = "UPDATE" Or mode = "ADD" Then
            grdVnCntPer.Columns(i).ReadOnly = False
        Else
            grdVnCntPer.Columns(i).ReadOnly = True
        End If
        i = i + 1
        grdVnCntPer_vci_cnttil = i
        grdVnCntPer.Columns(i).HeaderText = "Title"
        If mode = "UPDATE" Or mode = "ADD" Then
            grdVnCntPer.Columns(i).ReadOnly = False
        Else
            grdVnCntPer.Columns(i).ReadOnly = True
        End If
        i = i + 1
        grdVnCntPer_vci_cntphn = i
        grdVnCntPer.Columns(i).HeaderText = "Phone No."
        If mode = "UPDATE" Or mode = "ADD" Then
            grdVnCntPer.Columns(i).ReadOnly = False
        Else
            grdVnCntPer.Columns(i).ReadOnly = True
        End If
        i = i + 1
        grdVnCntPer_vci_cntfax = i
        grdVnCntPer.Columns(i).HeaderText = "Fax No."
        If mode = "UPDATE" Or mode = "ADD" Then
            grdVnCntPer.Columns(i).ReadOnly = False
        Else
            grdVnCntPer.Columns(i).ReadOnly = True
        End If
        i = i + 1
        grdVnCntPer_vci_cnteml = i
        grdVnCntPer.Columns(i).HeaderText = "E-mail"
        grdVnCntPer.Columns(i).Width = 150
        If mode = "UPDATE" Or mode = "ADD" Then
            grdVnCntPer.Columns(i).ReadOnly = False
        Else
            grdVnCntPer.Columns(i).ReadOnly = True
        End If
        i = i + 1
        grdVnCntPer_vci_cntdef = i
        grdVnCntPer.Columns(i).HeaderText = "Default"
        grdVnCntPer.Columns(i).ReadOnly = True
        i = i + 1
        grdVnCntPer_vci_creusr = i
        grdVnCntPer.Columns(i).Visible = False
        i = i + 1
        grdVnCntPer_vci_seq = i
        grdVnCntPer.Columns(i).Visible = False

    End Sub
    Private Sub display_grdVnCseBnk(ByVal type As String)
        If rs_VNCSEINF_B_READ.Tables.Count = 0 Then
            Exit Sub
        End If

        If type = "VNM" Then
            grdVnCseBnk.DataSource = rs_VNCSEINF_B_READ.Tables("Result").DefaultView
        End If

        grdVnCseBnk.RowHeadersWidth = 18
        grdVnCseBnk.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        grdVnCseBnk.ColumnHeadersHeight = 18
        grdVnCseBnk.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        grdVnCseBnk.AllowUserToResizeColumns = True
        grdVnCseBnk.AllowUserToResizeRows = False
        grdVnCseBnk.RowTemplate.Height = 18


        Dim i As Integer

        For i = 0 To rs_VNCSEINF_B_READ.Tables("RESULT").Columns.Count - 1
            rs_VNCSEINF_B_READ.Tables("RESULT").Columns(i).ReadOnly = False
        Next i


        i = 0
        grdVnCseBnk_vcs_status = i
        grdVnCseBnk.Columns(i).HeaderText = "Del"
        grdVnCseBnk.Columns(i).Width = 30
        grdVnCseBnk.Columns(i).ReadOnly = True
        i = i + 1
        grdVnCseBnk_vcs_csenam = i
        grdVnCseBnk.Columns(i).HeaderText = "Bank Name"
        If mode = "UPDATE" Or mode = "ADD" Then
            grdVnCseBnk.Columns(i).ReadOnly = False
        Else
            grdVnCseBnk.Columns(i).ReadOnly = True
        End If
        i = i + 1
        grdVnCseBnk_vcs_accno = i
        grdVnCseBnk.Columns(i).HeaderText = "Account No."
        If mode = "UPDATE" Or mode = "ADD" Then
            grdVnCseBnk.Columns(i).ReadOnly = False
        Else
            grdVnCseBnk.Columns(i).ReadOnly = True
        End If
        i = i + 1
        grdVnCseBnk_vcs_accnam = i
        grdVnCseBnk.Columns(i).HeaderText = "Account Name"
        If mode = "UPDATE" Or mode = "ADD" Then
            grdVnCseBnk.Columns(i).ReadOnly = False
        Else
            grdVnCseBnk.Columns(i).ReadOnly = True
        End If
        i = i + 1
        grdVnCseBnk_vcs_cseadr = i
        grdVnCseBnk.Columns(i).HeaderText = "Address"
        grdVnCseBnk.Columns(i).Width = 300
        If mode = "UPDATE" Or mode = "ADD" Then
            grdVnCseBnk.Columns(i).ReadOnly = False
        Else
            grdVnCseBnk.Columns(i).ReadOnly = True
        End If
        i = i + 1
        grdVnCseBnk_vcs_csestt = i
        grdVnCseBnk.Columns(i).HeaderText = "State/Province"
        If mode = "UPDATE" Or mode = "ADD" Then
            grdVnCseBnk.Columns(i).ReadOnly = False
        Else
            grdVnCseBnk.Columns(i).ReadOnly = True
        End If
        i = i + 1
        grdVnCseBnk_vcs_csecty = i
        grdVnCseBnk.Columns(i).HeaderText = "Country"
        grdVnCseBnk.Columns(i).ReadOnly = True
        i = i + 1
        grdVnCseBnk_vcs_csezip = i
        grdVnCseBnk.Columns(i).HeaderText = "Zip/Postal"
        If mode = "UPDATE" Or mode = "ADD" Then
            grdVnCseBnk.Columns(i).ReadOnly = False
        Else
            grdVnCseBnk.Columns(i).ReadOnly = True
        End If
        i = i + 1
        grdVnCseBnk_vcs_csectp = i
        grdVnCseBnk.Columns(i).HeaderText = "Contact Person"
        If mode = "UPDATE" Or mode = "ADD" Then
            grdVnCseBnk.Columns(i).ReadOnly = False
        Else
            grdVnCseBnk.Columns(i).ReadOnly = True
        End If
        i = i + 1
        grdVnCseBnk_vcs_csetil = i
        grdVnCseBnk.Columns(i).HeaderText = "Title"
        grdVnCseBnk.Columns(i).Width = 120
        If mode = "UPDATE" Or mode = "ADD" Then
            grdVnCseBnk.Columns(i).ReadOnly = False
        Else
            grdVnCseBnk.Columns(i).ReadOnly = True
        End If
        i = i + 1
        grdVnCseBnk_vcs_csephn = i
        grdVnCseBnk.Columns(i).HeaderText = "Phone No."
        grdVnCseBnk.Columns(i).Width = 100
        If mode = "UPDATE" Or mode = "ADD" Then
            grdVnCseBnk.Columns(i).ReadOnly = False
        Else
            grdVnCseBnk.Columns(i).ReadOnly = True
        End If
        i = i + 1
        grdVnCseBnk_vcs_csefax = i
        grdVnCseBnk.Columns(i).HeaderText = "Fax"
        grdVnCseBnk.Columns(i).Width = 100
        If mode = "UPDATE" Or mode = "ADD" Then
            grdVnCseBnk.Columns(i).ReadOnly = False
        Else
            grdVnCseBnk.Columns(i).ReadOnly = True
        End If
        i = i + 1
        grdVnCseBnk_vcs_cseeml = i
        grdVnCseBnk.Columns(i).HeaderText = "E-mail"
        grdVnCseBnk.Columns(i).Width = 150
        If mode = "UPDATE" Or mode = "ADD" Then
            grdVnCseBnk.Columns(i).ReadOnly = False
        Else
            grdVnCseBnk.Columns(i).ReadOnly = True
        End If
        i = i + 1
        grdVnCseBnk_vcs_csermk = i
        grdVnCseBnk.Columns(i).HeaderText = "Remark"
        If mode = "UPDATE" Or mode = "ADD" Then
            grdVnCseBnk.Columns(i).ReadOnly = False
        Else
            grdVnCseBnk.Columns(i).ReadOnly = True
        End If
        i = i + 1
        grdVnCseBnk_vcs_csedef = i
        grdVnCseBnk.Columns(i).HeaderText = "Default"

        grdVnCseBnk.Columns(i).ReadOnly = True

        i = i + 1
        grdVnCseBnk_vcs_creusr = i
        grdVnCseBnk.Columns(i).Visible = False
        i = i + 1
        grdVnCseBnk_vcs_cretyp = i
        grdVnCseBnk.Columns(i).Visible = False
        i = i + 1
        grdVnCseBnk_vcs_creseq = i
        grdVnCseBnk.Columns(i).Visible = False

    End Sub
    Private Sub display_grdvengrp(ByVal type As String)

        If rs_VNCUGREL_READ.Tables.Count = 0 Then
            Exit Sub
        End If

        If type = "VNM" Then
            grdvengrp.DataSource = rs_VNCUGREL_READ.Tables("RESULT").DefaultView
        End If

        grdvengrp.RowHeadersWidth = 18
        grdvengrp.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        grdvengrp.ColumnHeadersHeight = 18
        grdvengrp.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        grdvengrp.AllowUserToResizeColumns = True
        grdvengrp.AllowUserToResizeRows = False
        grdvengrp.RowTemplate.Height = 18

        Dim i As Integer

        For i = 0 To rs_VNCUGREL_READ.Tables("RESULT").Columns.Count - 1
            rs_VNCUGREL_READ.Tables("RESULT").Columns(i).ReadOnly = False
        Next i
        rs_VNCUGREL_READ.Tables("RESULT").Columns(5).ReadOnly = False

        i = 0
        grdvengrp_vcr_cocde = i
        grdvengrp.Columns(i).Visible = False
        'grdvengrp.Columns(i).HeaderText = "Del"
        'If mode = "UPDATE" Or mode = "ADD" Then
        '    grdvengrp.Columns(i).ReadOnly = False
        'Else
        '    grdvengrp.Columns(i).ReadOnly = True
        'End If
        'grdvengrp.Columns(i).Width = 30
        i = i + 1
        grdvengrp_vcr_venno = i
        grdvengrp.Columns(i).Visible = False

        i = i + 1
        grdvengrp_vcr_cugrpcde = i
        grdvengrp.Columns(i).HeaderText = "Customer Group"

        grdvengrp.Columns(i).ReadOnly = True



        i = i + 1
        grdvengrp_vcr_flg_int = i
        grdvengrp.Columns(i).Visible = False

        i = i + 1
        grdvengrp_vcr_flg_ext = i
        grdvengrp.Columns(i).HeaderText = "Access Type"

        grdvengrp.Columns(i).ReadOnly = True


        i = i + 1
        grdvengrp_icf_mrkup = i
        grdvengrp.Columns(i).HeaderText = "Mark Up"
        If mode = "ReadOnly" Then
            grdvengrp.Columns(i).ReadOnly = True
        Else
            grdvengrp.Columns(i).ReadOnly = False
        End If


        i = i + 1
        grdvengrp_vcr_creusr = i
        grdvengrp.Columns(i).Visible = False

        i = i + 1
        grdvengrp_vcr_updusr = i
        grdvengrp.Columns(i).Visible = False

        i = i + 1
        grdvengrp_vcr_credat = i
        grdvengrp.Columns(i).Visible = False

        i = i + 1
        grdvengrp_vcr_upddat = i
        grdvengrp.Columns(i).Visible = False

        i = i + 1
        grdvengrp_vcr_timstp = i
        grdvengrp.Columns(i).Visible = False


        Dim j As Integer

        For j = 0 To grdvengrp.Columns.Count - 1

            grdvengrp.Columns(j).SortMode = DataGridViewColumnSortMode.NotSortable

        Next j
    End Sub

    Private Sub display_grdVnPucInf(ByVal type As String)
        If rs_VNPUCINF_READ.Tables.Count = 0 Then
            Exit Sub
        End If


        If type = "VNM" Then
            grdVnPucInf.DataSource = rs_VNPUCINF_READ.Tables("Result").DefaultView
        End If

        grdVnPucInf.RowHeadersWidth = 18
        grdVnPucInf.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        grdVnPucInf.ColumnHeadersHeight = 18
        grdVnPucInf.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        grdVnPucInf.AllowUserToResizeColumns = True
        grdVnPucInf.AllowUserToResizeRows = False
        grdVnPucInf.RowTemplate.Height = 18

        Dim i As Integer

        'If mode = "UPDATE" Or mode = "ADD" Then
        For i = 0 To rs_VNPUCINF_READ.Tables("RESULT").Columns.Count - 1
            rs_VNPUCINF_READ.Tables("RESULT").Columns(i).ReadOnly = False
        Next i
        'End If

        i = 0
        grdVnPucInf_vpf_yymm = i
        grdVnPucInf.Columns(i).HeaderText = "Year/Month"
        grdVnPucInf.Columns(i).ReadOnly = True
        i = i + 1
        grdVnPucInf_vpf_mtdbok = i
        grdVnPucInf.Columns(i).HeaderText = "MTD Booking (USD)"
        grdVnPucInf.Columns(i).ReadOnly = True
        grdVnPucInf.Columns(i).DefaultCellStyle.Format = "##,###,##0"
        i = i + 1
        grdVnPucInf_vpf_mtdpur = i
        grdVnPucInf.Columns(i).HeaderText = "MTD Purchase (USD)"
        grdVnPucInf.Columns(i).ReadOnly = True
        grdVnPucInf.Columns(i).DefaultCellStyle.Format = "##,###,##0"

    End Sub

    Private Sub display_grdPceTme(ByVal type As String)
        If rs_VNPRCTRM_READ.Tables.Count = 0 Then
            Exit Sub
        End If

        If type = "VNM" Then
            grdPrcTrm.DataSource = rs_VNPRCTRM_READ.Tables("RESULT").DefaultView
        End If


        grdPrcTrm.RowHeadersWidth = 18
        grdPrcTrm.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        grdPrcTrm.ColumnHeadersHeight = 18
        grdPrcTrm.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        grdPrcTrm.AllowUserToResizeColumns = True
        grdPrcTrm.AllowUserToResizeRows = False
        grdPrcTrm.RowTemplate.Height = 18

        Dim i As Integer

        For i = 0 To rs_VNPRCTRM_READ.Tables("RESULT").Columns.Count - 1
            rs_VNPRCTRM_READ.Tables("RESULT").Columns(i).ReadOnly = False
        Next

        i = 0
        grdPceTme_vpt_cocde = i
        grdPrcTrm.Columns(i).HeaderText = "Del"
        grdPrcTrm.Columns(i).Width = 30
        i = i + 1
        grdPceTme_vpt_venno = i
        grdPrcTrm.Columns(i).Visible = False
        i = i + 1
        grdPceTme_vpt_prctrm = i
        grdPrcTrm.Columns(i).HeaderText = "Price Terms"
        grdPrcTrm.Columns(i).ReadOnly = True
        grdPrcTrm.Columns(i).Width = 220
        i = i + 1
        grdPceTme_vpt_prcdef = i
        grdPrcTrm.Columns(i).HeaderText = "Default"
        grdPrcTrm.Columns(i).ReadOnly = True
        grdPrcTrm.Columns(i).Width = 50
        i = i + 1
        grdPceTme_vpt_creusr = i
        grdPrcTrm.Columns(i).Visible = False
        i = i + 1
        grdPceTme_vpt_updusr = i
        grdPrcTrm.Columns(i).Visible = False
        i = i + 1
        grdPceTme_vpt_credat = i
        grdPrcTrm.Columns(i).Visible = False
        i = i + 1
        grdPceTme_vpt_upddat = i
        grdPrcTrm.Columns(i).Visible = False
        i = i + 1
        grdPceTme_vpt_timstp = i
        grdPrcTrm.Columns(i).Visible = False

    End Sub

    Private Sub display_grdFactoryRel(ByVal type As String)
        If rs_VNSUBVN_V_READ.Tables.Count = 0 Then
            Exit Sub
        End If

        If type = "VNM" Then
            grdFactoryRel.DataSource = rs_VNSUBVN_V_READ.Tables("Result").DefaultView
        End If

        grdFactoryRel.RowHeadersWidth = 18
        grdFactoryRel.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        grdFactoryRel.ColumnHeadersHeight = 18
        grdFactoryRel.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        grdFactoryRel.AllowUserToResizeColumns = True
        grdFactoryRel.AllowUserToResizeRows = False
        grdFactoryRel.RowTemplate.Height = 18




        Dim i As Integer

        'If mode = "UPDATE" Or mode = "ADD" Then
        For i = 0 To rs_VNSUBVN_V_READ.Tables("RESULT").Columns.Count - 1
            rs_VNSUBVN_V_READ.Tables("RESULT").Columns(i).ReadOnly = False
        Next i
        'End If

        i = 0 ' 0
        grdFactoryRel_vsv_del = i
        grdFactoryRel.Columns(i).HeaderText = "Del"
        grdFactoryRel.Columns(i).Width = 30
        i = i + 1 '1
        grdFactoryRel_vsv_code = i
        grdFactoryRel.Columns(i).Visible = False
        i = i + 1 '2
        grdFactoryRel_vsv_ven1cde = i
        grdFactoryRel.Columns(i).Visible = False
        i = i + 1 '3
        grdFactoryRel_vsv_ven1name = i
        grdFactoryRel.Columns(i).Visible = False
        i = i + 1 '4
        grdFactoryRel_vsv_ven2cde = i
        grdFactoryRel.Columns(i).HeaderText = "Factory Code"
        grdFactoryRel.Columns(i).ReadOnly = True
        grdFactoryRel.Columns(i).Width = 100
        i = i + 1 '5
        grdFactoryRel_vsv_ven2name = i
        grdFactoryRel.Columns(i).HeaderText = "Factory Name"
        grdFactoryRel.Columns(i).ReadOnly = True
        grdFactoryRel.Columns(i).Width = 170
        i = i + 1 '6
        grdFactoryRel_vsv_venrel = i
        grdFactoryRel.Columns(i).Visible = False
        i = i + 1 '7 
        grdFactoryRel_vsv_creusr = i
        grdFactoryRel.Columns(i).Visible = False
        i = i + 1 '8
        grdFactoryRel_vsv_updusr = i
        grdFactoryRel.Columns(i).Visible = False
        i = i + 1 '9
        grdFactoryRel_vsv_credat = i
        grdFactoryRel.Columns(i).Visible = False
        i = i + 1 '10
        grdFactoryRel_vsv_upddat = i
        grdFactoryRel.Columns(i).Visible = False
        i = i + 1  '11
        grdFactoryRel_vsv_timstp = i
        grdFactoryRel.Columns(i).Visible = False

    End Sub

    Private Sub display_grdVendorRel(ByVal type As String)
        If rs_VNSUBVN_F_READ.Tables.Count = 0 Then
            Exit Sub
        End If

        If type = "VNM" Then
            grdVendorRel.DataSource = rs_VNSUBVN_F_READ.Tables("Result").DefaultView
        End If

        grdVendorRel.RowHeadersWidth = 18
        grdVendorRel.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        grdVendorRel.ColumnHeadersHeight = 18
        grdVendorRel.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        grdVendorRel.AllowUserToResizeColumns = True
        grdVendorRel.AllowUserToResizeRows = False
        grdVendorRel.RowTemplate.Height = 18

        Dim i As Integer

        'If mode = "UPDATE" Or mode = "ADD" Then
        For i = 0 To rs_VNSUBVN_F_READ.Tables("RESULT").Columns.Count - 1
            rs_VNSUBVN_F_READ.Tables("RESULT").Columns(i).ReadOnly = False
        Next i
        'End If


        i = 0 ' 0
        grdVendorRel_vsv_del = i
        grdVendorRel.Columns(i).HeaderText = "Del"
        grdVendorRel.Columns(i).Width = 30
        i = i + 1 '1
        grdVendorRel_vsv_code = i
        grdVendorRel.Columns(i).Visible = False
        i = i + 1 '2
        grdVendorRel_vsv_ven1cde = i
        grdVendorRel.Columns(i).HeaderText = "Vendor Code"
        grdVendorRel.Columns(i).ReadOnly = True
        grdVendorRel.Columns(i).Width = 100
        i = i + 1 '3
        grdVendorRel_vsv_ven1name = i
        grdVendorRel.Columns(i).HeaderText = "Vendor Name"
        grdVendorRel.Columns(i).ReadOnly = True
        grdVendorRel.Columns(i).Width = 170
        i = i + 1 '4
        grdVendorRel_vsv_ven2cde = i
        grdVendorRel.Columns(i).Visible = False
        i = i + 1 '5
        grdVendorRel_vsv_ven2name = i
        grdVendorRel.Columns(i).Visible = False
        i = i + 1 '6
        grdVendorRel_vsv_venrel = i
        grdVendorRel.Columns(i).Visible = False
        i = i + 1 '7 
        grdVendorRel_vsv_creusr = i
        grdVendorRel.Columns(i).Visible = False
        i = i + 1 '8
        grdVendorRel_vsv_updusr = i
        grdVendorRel.Columns(i).Visible = False
        i = i + 1 '9
        grdVendorRel_vsv_credat = i
        grdVendorRel.Columns(i).Visible = False
        i = i + 1 '10
        grdVendorRel_vsv_upddat = i
        grdVendorRel.Columns(i).Visible = False
        i = i + 1  '11
        grdVendorRel_vsv_timstp = i
        grdVendorRel.Columns(i).Visible = False











    End Sub

    Private Sub cboVenRat_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVenRat.KeyUp
        auto_search_combo(cboVenRat, e.KeyCode)
    End Sub

    Private Sub cboVenRat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVenRat.SelectedIndexChanged



        If mode = "UPDATE" Then
            If rs_VNBASINF_READ.Tables("RESULT").Rows.Count = 1 Then
                If cboVenRat.Text <> "" Then

                    Dim dv As String
                    dv = Split(cboVenRat.Text, " - ")(0)
                    If dv <> rs_VNBASINF_READ.Tables("RESULT").Rows(0).Item("vbi_venrat") Then
                        Recordstatus = True

                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cboPrcTrm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPrcTrm.SelectedIndexChanged

        If mode = "UPDATE" Then
            If rs_VNBASINF_READ.Tables("RESULT").Rows.Count = 1 Then
                If cboPrcTrm.Text <> "" Then

                    Dim dv As String
                    dv = Split(cboPrcTrm.Text, " - ")(0)
                    If dv <> rs_VNBASINF_READ.Tables("RESULT").Rows(0).Item("vbi_prctrm") Then
                        Recordstatus = True

                    End If
                End If
            End If
        End If
    End Sub

    Private Sub mmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdClear.Click
        Dim tmp_itmno As String = txtVenNo.Text
        If Recordstatus = True Then
            Select Case MsgBox("Record has been modified. Do you want to save before clear the screen?", MsgBoxStyle.YesNoCancel)
                Case MsgBoxResult.Yes
                    If Enq_right_local Then
                        Call mmdSave_Click(sender, e)
                    Else
                        MsgBox("You have no Save record rights!")
                    End If
                    Me.Cursor = Cursors.Default
                Case MsgBoxResult.No
                    formInit("INIT")
                    txtVenNo.Text = tmp_itmno
                    txtVenNo.Select()
                    Me.Cursor = Cursors.Default
            End Select
        Else
            formInit("INIT")
            txtVenNo.Text = tmp_itmno
            txtVenNo.Select()
            Me.Cursor = Cursors.Default
        End If


        Recordstatus = False





    End Sub

    Private Sub mmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdAdd.Click
        cboVenSts.Text = "A - Active"
        If cboVenType.Text = "" Then
            MsgBox("Please select the Vendor Type")
            txtVenNo.Text = ""
            txtVenNo.Enabled = False
            cboVenType.Enabled = True
            mmdFind.Enabled = False

            cboVenType.Items.Clear()
            cboVenType.Items.Add("Internal")
            cboVenType.Items.Add("External")
            cboVenType.Items.Add("Joint Venture")



            cboVenType.Focus()
            Exit Sub


        Else
            If cboVenType.Text = "External" Then
                gspStr = "sp_list_VNBASINF ''"
                rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF_V_ADD, rtnStr)

                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading cmdADD_Click rs_VNBASINF_V_ADD :" & rtnStr)
                    Exit Sub
                End If

                Dim dr As DataRow() = rs_VNBASINF_V_ADD.Tables("RESULT").Select("vbi_venno >= '1000' and vbi_venno <= '5000'", "vbi_venno")
                ' rs_VNBASINF_V_ADD.Tables("RESULT").Rows.Count(-1)
                Dim sMaxVenNum As Integer = dr(dr.Length - 1).Item("vbi_venno")
                sMaxVenNum = sMaxVenNum + 1
                txtVenNo.Text = sMaxVenNum

                Me.BaseTabControl1.TabPages(5).Enabled = True
            Else
                Me.BaseTabControl1.TabPages(5).Enabled = False
            End If
        End If

        If (Trim(txtVenNo.Text) = "") Then
            txtVenNo.Enabled = True
            txtVenNo.Focus()
            MsgBox("Please input Vendor No.")
            Exit Sub
        End If

        txtVenNo.Text = txtVenNo.Text.ToUpper

        If Len(txtVenNo.Text) = 1 And Asc(Microsoft.VisualBasic.Left(txtVenNo.Text, 1)) < Asc("A") Or Asc(Microsoft.VisualBasic.Left(txtVenNo.Text, 1)) > Asc("Z") Then
            txtVenNo.Enabled = True
            txtVenNo.Focus()
            MsgBox("Invalid Input! (Vendor No. must be between A to Z)")
            Exit Sub
        Else
            If Len(txtVenNo.Text) = 1 Then
                cboVenType.Items.Clear()
                cboVenType.Items.Add("Internal")
                cboVenType.Items.Add("Joint Venture")
                cboVenType.SelectedIndex = 0
            Else
                If Len(txtVenNo.Text) > 4 Or Not IsNumeric(txtVenNo.Text) Or Not InStr(1, txtVenNo.Text, ".") = 0 Or txtVenNo.Text = "0000" Then
                    txtVenNo.Enabled = True
                    txtVenNo.Focus()
                    MsgBox("Invalid Input! (Vendor No. must be between 1001-9999)")
                    Exit Sub
                Else
                    If Len(txtVenNo.Text) = 3 Then txtVenNo.Text = "0" + txtVenNo.Text
                    If Len(txtVenNo.Text) = 2 Then txtVenNo.Text = "00" + txtVenNo.Text
                    If Len(txtVenNo.Text) = 1 Then txtVenNo.Text = "000" + txtVenNo.Text
                    cboVenType.Items.Clear()
                    cboVenType.Items.Add("External")
                    cboVenType.SelectedIndex = 0
                End If
            End If
        End If

        gspStr = "sp_select_VNBASINF '','" & txtVenNo.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF_ADD, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdADD_Click rs_VNBASINF_ADD :" & rtnStr)
            Exit Sub
        End If

        If rs_VNBASINF_ADD.Tables("RESULT").Rows.Count > 0 Then
            MsgBox("Record already existed")
            txtVenNo.Focus()
            Exit Sub
        Else
            Add_flag = True
            mode = "ADD"
            resetdisplay(mode)
            cboItmNat.SelectedIndex = 0
            cboVenType.Enabled = True

        End If

        gspStr = "sp_select_VNSUBVN '','" & txtVenNo.Text & "','V'"
        rtnLong = execute_SQLStatement(gspStr, rs_VNSUBVN_V_ADD, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdADD_Click rs_VNSUBVN_V_ADD :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_select_VNSUBVN '','" & txtVenNo.Text & "','F'"
        rtnLong = execute_SQLStatement(gspStr, rs_VNSUBVN_F_ADD, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdADD_Click rs_VNSUBVN_F_ADD :" & rtnStr)
            Exit Sub
        End If


        gspStr = "sp_list_VNBASINF ''"
        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF_ALL, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdFind_Click sp_list_VNBASINF :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If


        txtVenNam.Focus()

    End Sub
    Public Sub InitGrid()

        gspStr = "sp_select_VNBASINF '','" & txtVenNo.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF_ADD2, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdADD_Click rs_VNBASINF_ADD2 :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_list_VNCATREL '','" & "!@#$%^&*" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_VNCATREL_ADD, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdADD_Click rs_VNCATREL_ADD :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_list_VNCNTINF '','" & "!@#$%^&*" & "','M','ADR'"
        rtnLong = execute_SQLStatement(gspStr, rs_VNCNTINF_M_ADR_ADD, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdADD_Click rs_VNCNTINF_M_ADR_ADD :" & rtnStr)
            Exit Sub
        End If


        gspStr = "sp_list_VNCNTINF '','" & "!@#$%^&*" & "','U','ADR'"
        rtnLong = execute_SQLStatement(gspStr, rs_VNCNTINF_U_READ, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdADD_Click rs_VNCNTINF_U_READ :" & rtnStr)
            Exit Sub
        End If


        gspStr = "sp_list_VNCNTINF '','" & "!@#$%^&*" & "','*','PER'"
        rtnLong = execute_SQLStatement(gspStr, rs_VNCNTPER_READ, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdADD_Click rs_VNCNTPER_READ :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_list_VNCSEINF '','" & "!@#$%^&*" & "','B'"
        rtnLong = execute_SQLStatement(gspStr, rs_VNCSEINF_B_READ, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdADD_Click rs_VNCSEINF_B_READ :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_list_VNPUCINF '','" & "!@#$%^&*'"
        rtnLong = execute_SQLStatement(gspStr, rs_VNPUCINF_READ, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdADD_Click rs_VNPUCINF_READ :" & rtnStr)
            Exit Sub
        End If

        'cboVenSts.SelectedIndex = 0
        'cboVenRat.SelectedIndex = 0
        'cboPrcTrm.SelectedIndex = 0
        'cboPayTrm.SelectedIndex = 0
        'cboCurCde.SelectedIndex = 0

        txtDisCnt.Text = 0

        'gspStr = "sp_list_VNITMNAT '','" & "!@#$%^&*'"
        gspStr = "sp_list_VNITMNAT '','" & "!@#$%^&*" & "','" & "31" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_VNITMNAT_READ, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdADD_Click rs_VNITMNAT_READ :" & rtnStr)
            Exit Sub
        End If


        gspStr = "sp_select_VNSUBVN '','" & txtVenNo.Text & "','V'"
        rtnLong = execute_SQLStatement(gspStr, rs_VNSUBVN_V_READ, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdADD_Click rs_VNSUBVN_V_ADD :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_select_VNSUBVN '','" & txtVenNo.Text & "','F'"
        rtnLong = execute_SQLStatement(gspStr, rs_VNSUBVN_F_READ, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdADD_Click rs_VNSUBVN_F_ADD :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_list_VNCUGREL '','" & "!@#$%^" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_VNCUGREL_READ, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdADD_Click sp_list_VNCUGREL :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        gspStr = "sp_list_vnprctrm '','" & "!@#$%^&" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_VNPRCTRM_READ, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdADD_Click sp_list_vnprctrm :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If


        gspStr = "sp_select_VNEXCCUS '','" & "!@#$@!" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_VNEXCCUS, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdADD_Click sp_select_VNEXCCUS :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If




        Call display_grdItmNat("VNM")
        Call display_grdVnCntInf("VNM")
        Call display_grdVnCntPer("VNM")
        Call display_grdVnCseBnk("VNM")
        Call display_grdVnPucInf("VNM")
        Call display_grdFactoryRel("VNM")
        Call display_grdVendorRel("VNM")
        Call display_grdvengrp("VNM")
        Call display_grdPceTme("VNM")
        Call display_grdExcCus()



        addCustomerGroup()


    End Sub

    Private Sub display_grdExcCus()

        grdExcCus.DataSource = rs_VNEXCCUS.Tables("Result").DefaultView

        grdExcCus.RowHeadersWidth = 18
        grdExcCus.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        grdExcCus.ColumnHeadersHeight = 18
        grdExcCus.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        grdExcCus.AllowUserToResizeColumns = True
        grdExcCus.AllowUserToResizeRows = False
        grdExcCus.RowTemplate.Height = 18

        Dim i As Integer

        For i = 0 To rs_VNEXCCUS.Tables("RESULT").Columns.Count - 1
            rs_VNEXCCUS.Tables("RESULT").Columns(i).ReadOnly = False
        Next

        i = 0
        grdExcCus_vec_cocde = i
        grdExcCus.Columns(i).HeaderText = "Del"
        grdExcCus.Columns(i).Width = 30
        i = i + 1
        grdExcCus_vec_venno = i
        grdExcCus.Columns(i).Visible = False
        i = i + 1
        grdExcCus_vec_cusno = i
        grdExcCus.Columns(i).HeaderText = "Cust Code"
        grdExcCus.Columns(i).ReadOnly = True
        grdExcCus.Columns(i).Width = 180
        i = i + 1
        grdExcCus_vec_cotry = i
        grdExcCus.Columns(i).Visible = False
        i = i + 1
        grdExcCus_vec_valid = i
        grdExcCus.Columns(i).Visible = False
        i = i + 1
        grdExcCus_vec_rmark = i
        grdExcCus.Columns(i).HeaderText = "Remarks"
        grdExcCus.Columns(i).ReadOnly = False
        grdExcCus.Columns(i).Width = 220
        i = i + 1
        grdExcCus_vec_creusr = i
        grdExcCus.Columns(i).Visible = False
        i = i + 1
        grdExcCus_vec_updusr = i
        grdExcCus.Columns(i).Visible = False
        i = i + 1
        grdExcCus_vec_credat = i
        grdExcCus.Columns(i).Visible = False
        i = i + 1
        grdExcCus_vec_upddat = i
        grdExcCus.Columns(i).Visible = False


    End Sub


    Private Sub cboItmNat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboItmNat.SelectedIndexChanged
        If Trim(cboItmNat.Text) <> "" And Trim(cboItmNat.Text) <> "< None >" Then
            Dim dr As DataRow() = rs_VNITMNAT_READ.Tables("RESULT").Select("Itmnat = '" + cboItmNat.SelectedItem.ToString + "'")

            If dr.Length = 0 Then
                cmdAddItmNat.Enabled = True
            Else
                cmdAddItmNat.Enabled = False
            End If


        Else
            cmdAddItmNat.Enabled = False

        End If
    End Sub

    Private Sub cmdAddItmNat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddItmNat.Click
        Dim tmpstr As String
        tmpstr = cboItmNat.Text

        If cboItmNat.Items.IndexOf(tmpstr) = -1 Then
            MsgBox("Invalid Item Nature!")
            Exit Sub
        End If



        Dim rowcount As Integer
        rowcount = rs_VNITMNAT_READ.Tables("RESULT").Rows.Count
        With rs_VNITMNAT_READ
            .Tables("RESULT").Rows.Add()
            .Tables("RESULT").Rows(rowcount).Item("status") = ""
            .Tables("RESULT").Rows(rowcount).Item("vin_venno") = txtVenNo.Text
            .Tables("RESULT").Rows(rowcount).Item("itmnat") = cboItmNat.Text
            .Tables("RESULT").Rows(rowcount).Item("vin_creusr") = "~*ADD*~"
            .Tables("RESULT").Rows(rowcount).Item("vin_natseq") = -1
        End With
        Recordstatus = True
        cmdAddItmNat.Enabled = False

    End Sub

    Private Sub grdVnCntInf_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdVnCntInf.CellClick
        If mode <> "ADD" And mode <> "UPDATE" Then
            Exit Sub
        End If

        If grdVnCntInf.RowCount = 0 Then
            Exit Sub
        End If

        Select Case grdVnCntInf.CurrentCell.ColumnIndex
            Case grdVnCntInf_vci_cty
                comboBoxCell(grdVnCntInf, "Cty")
            Case grdVnCntInf_vci_cnttyp
                comboBoxCell(grdVnCntInf, "Type")

        End Select


    End Sub
    Private Sub comboBoxCell(ByVal dgv As DataGridView, ByVal typ As String)
        Dim cboCell As New DataGridViewComboBoxCell

        Dim iCol As Integer = dgv.CurrentCell.ColumnIndex
        Dim iRow As Integer = dgv.CurrentCell.RowIndex

        Dim row As DataGridViewRow = dgv.CurrentRow

        'dgv.Rows(iRow).Cells(iCol).ReadOnly = True

        Dim i As Integer

        Select Case typ
            Case "Cty"
                For i = 0 To rs_SYSETINF02.Tables("RESULT").Rows.Count - 1
                    cboCell.Items.Add(rs_SYSETINF02.Tables("RESULT").Rows(i).Item("ysi_cde") + " - " + rs_SYSETINF02.Tables("RESULT").Rows(i).Item("ysi_dsc"))

                Next i
            Case "Type"
                cboCell.Items.Add("U - Other")
                cboCell.Items.Add("Q - QC")
            Case "Nat"
                For i = 0 To rs_SYSETINF13.Tables("RESULT").Rows.Count - 1
                    cboCell.Items.Add(rs_SYSETINF13.Tables("RESULT").Rows(i).Item("ysi_cde") + " - " + rs_SYSETINF13.Tables("RESULT").Rows(i).Item("ysi_dsc"))
                Next i
            Case "ven2"
                Dim dr As DataRow() = rs_VNBASINF_ALL.Tables("RESULT").Select("vbi_venno >= '1000' and vbi_venno <= '5000'")

                For i = 0 To dr.Length - 1
                    cboCell.Items.Add(dr(i).Item("vbi_venno") + " - " + dr(i).Item("vbi_vensna"))
                Next i
            Case "ven1"
                Dim dr As DataRow() = rs_VNBASINF_ALL.Tables("RESULT").Select("vbi_venno >= '1000' and vbi_venno <= '5000'")

                For i = 0 To dr.Length - 1
                    cboCell.Items.Add(dr(i).Item("vbi_venno") + " - " + dr(i).Item("vbi_vensna"))
                Next i

            Case "PrcTrm"
                For i = 0 To rs_SYSETINF03.Tables("RESULT").Rows.Count - 1
                    cboCell.Items.Add(rs_SYSETINF03.Tables("RESULT").Rows(i).Item("ysi_cde") & " - " & rs_SYSETINF03.Tables("RESULT").Rows(i).Item("ysi_dsc"))
                Next

            Case "Cus"

                Dim dr As DataRow() = rs_SYSALLCUS.Tables("RESULT").Select("cbi_cusno >= '50000' and cbi_cusno <= '69999'")

                For i = 0 To dr.Length - 1
                    cboCell.Items.Add(dr(i).Item("cbi_cusno") & " - " & dr(i).Item("cbi_cussna"))
                Next


        End Select

        cboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox

        dgv.Rows(iRow).Cells(iCol) = cboCell
        dgv.Rows(iRow).Cells(iCol).ReadOnly = False

    End Sub

    Private Sub grdVnCntInf_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdVnCntInf.GotFocus
        lblVncNtInf.ForeColor = Color.DarkCyan
        Got_Focus_Grid = "VNCNTINF"
    End Sub

    Private Sub grdVnCntInf_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdVnCntInf.LostFocus
        lblVncNtInf.ForeColor = Color.Blue
    End Sub

    Private Sub grdVnCntPer_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdVnCntPer.CellClick
        If mode <> "ADD" And mode <> "UPDATE" Then
            Exit Sub
        End If

        Select Case grdVnCntPer.CurrentCell.ColumnIndex
            Case grdVnCntPer_vci_cnttyp
                If grdVnCntPer.Item(grdVnCntPer_vci_creusr, grdVnCntPer.CurrentCell.RowIndex).Value = "~*ADD*~" Then
                    comboBoxCell(grdVnCntPer, "Nat")
                End If

        End Select

    End Sub

    Private Sub grdVnCntPer_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdVnCntPer.GotFocus
        lblVnCntPer.ForeColor = Color.DarkCyan
        Got_Focus_Grid = "VNCNTPER"
    End Sub

    Private Sub grdVnCseBnk_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdVnCseBnk.CellClick
        If mode <> "ADD" And mode <> "UPDATE" Then
            Exit Sub
        End If

        Select Case grdVnCseBnk.CurrentCell.ColumnIndex
            Case grdVnCseBnk_vcs_csecty
                comboBoxCell(grdVnCseBnk, "Cty")


        End Select

    End Sub

    Private Sub grdVnCseBnk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdVnCseBnk.GotFocus
        lblVnCseBnk.ForeColor = Color.DarkCyan
        Got_Focus_Grid = "VNCSEBNK"
    End Sub

    Private Sub grdVnCseBnk_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdVnCseBnk.LostFocus
        lblVnCseBnk.ForeColor = Color.Blue
    End Sub

    Private Sub grdVnCntPer_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdVnCntPer.LostFocus
        lblVnCntPer.ForeColor = Color.Blue
    End Sub


    Private Sub mmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdInsRow.Click
        Select Case Got_Focus_Grid
            Case "VNCNTINF"

                Call add_VNCNTINF()
            Case "VNCNTPER"

                Call add_VNCNTPER()
            Case "VNCSEBNK"
                Call add_VNCSEBNK()
            Case "FactoryRel"
                Call add_FactoryRel()
            Case "VendorRel"
                Call add_VendorRel()
            Case "VNPRCTRM"
                Call add_Vnprctrm()
            Case "VNEXCCUS"
                Call add_VNEXCCUS()
        End Select
    End Sub


    Private Sub add_VNEXCCUS()
        Dim rowcount As Integer
        rowcount = rs_VNEXCCUS.Tables("RESULT").Rows.Count
        Dim dr() As DataRow = rs_VNEXCCUS.Tables("RESULT").Select("vec_cusno = ''")
        If dr.Length = 0 Then
            rs_VNEXCCUS.Tables("RESULT").Rows.Add()

            rs_VNEXCCUS.Tables("RESULT").Rows(rowcount).Item("vec_cocde") = ""
            rs_VNEXCCUS.Tables("RESULT").Rows(rowcount).Item("vec_venno") = txtVenNo.Text
            rs_VNEXCCUS.Tables("RESULT").Rows(rowcount).Item("vec_cusno") = ""
            rs_VNEXCCUS.Tables("RESULT").Rows(rowcount).Item("vec_cotry") = ""
            rs_VNEXCCUS.Tables("RESULT").Rows(rowcount).Item("vec_valid") = ""
            rs_VNEXCCUS.Tables("RESULT").Rows(rowcount).Item("vec_rmark") = ""
            rs_VNEXCCUS.Tables("RESULT").Rows(rowcount).Item("vec_creusr") = "~*ADD*~"




        End If


    End Sub


    Private Sub add_Vnprctrm()
        Dim rowcount As Integer
        rowcount = rs_VNPRCTRM_READ.Tables("RESULT").Rows.Count
        Dim dr() As DataRow = rs_VNPRCTRM_READ.Tables("RESULT").Select("vpt_prctrm = ''")
        If dr.Length = 0 Then
            rs_VNPRCTRM_READ.Tables("RESULT").Rows.Add()


            rs_VNPRCTRM_READ.Tables("RESULT").Rows(rowcount).Item("vpt_prctrm") = ""
            If rowcount = 0 Then
                rs_VNPRCTRM_READ.Tables("RESULT").Rows(rowcount).Item("vpt_prcdef") = "Y"
            Else
                rs_VNPRCTRM_READ.Tables("RESULT").Rows(rowcount).Item("vpt_prcdef") = "N"
            End If
            rs_VNPRCTRM_READ.Tables("RESULT").Rows(rowcount).Item("vpt_cocde") = ""
            rs_VNPRCTRM_READ.Tables("RESULT").Rows(rowcount).Item("vpt_creusr") = "~*ADD*~"
            'Done This


            grdPrcTrm.CurrentCell = grdPrcTrm.Rows(rowcount).Cells(grdPceTme_vpt_prctrm)
        End If


    End Sub

    Private Sub add_VendorRel()



        Dim rowcount As Integer
        rowcount = rs_VNSUBVN_F_READ.Tables("RESULT").Rows.Count
        Dim dr() As DataRow = rs_VNSUBVN_F_READ.Tables("RESULT").Select("vsv_ven1cde = ''")
        If dr.Length = 0 Then
            rs_VNSUBVN_F_READ.Tables("RESULT").Rows.Add()
            rs_VNSUBVN_F_READ.Tables("RESULT").Rows(rowcount).Item("vsv_del") = ""
            rs_VNSUBVN_F_READ.Tables("RESULT").Rows(rowcount).Item("vsv_creusr") = "~*ADD*~"
            rs_VNSUBVN_F_READ.Tables("RESULT").Rows(rowcount).Item("vsv_ven1cde") = ""
            rs_VNSUBVN_F_READ.Tables("RESULT").Rows(rowcount).Item("vsv_ven2cde") = txtVenNo.Text
            rs_VNSUBVN_F_READ.Tables("RESULT").Rows(rowcount).Item("vsv_venrel") = "F"



            Recordstatus = True
        End If


    End Sub
    Private Sub add_FactoryRel()


        Dim rowcount As Integer
        rowcount = rs_VNSUBVN_V_READ.Tables("RESULT").Rows.Count
        Dim dr() As DataRow = rs_VNSUBVN_V_READ.Tables("RESULT").Select("vsv_ven2cde = ''")
        If dr.Length = 0 Then
            rs_VNSUBVN_V_READ.Tables("RESULT").Rows.Add()
            rs_VNSUBVN_V_READ.Tables("RESULT").Rows(rowcount).Item("vsv_del") = ""
            rs_VNSUBVN_V_READ.Tables("RESULT").Rows(rowcount).Item("vsv_creusr") = "~*ADD*~"

            rs_VNSUBVN_V_READ.Tables("RESULT").Rows(rowcount).Item("vsv_ven2cde") = ""

            rs_VNSUBVN_V_READ.Tables("RESULT").Rows(rowcount).Item("vsv_ven1cde") = txtVenNo.Text
            rs_VNSUBVN_V_READ.Tables("RESULT").Rows(rowcount).Item("vsv_venrel") = "F"



            Recordstatus = True
        End If


    End Sub
    Private Sub add_VNCSEBNK()



        Dim rowcount As Integer
        rowcount = rs_VNCSEINF_B_READ.Tables("RESULT").Rows.Count
        Dim dr() As DataRow = rs_VNCSEINF_B_READ.Tables("RESULT").Select("vcs_csenam = ''")
        If dr.Length = 0 Then
            rs_VNCSEINF_B_READ.Tables("RESULT").Rows.Add()
            rs_VNCSEINF_B_READ.Tables("RESULT").Rows(rowcount).Item("vcs_creusr") = "~*ADD*~"
            rs_VNCSEINF_B_READ.Tables("RESULT").Rows(rowcount).Item("status") = ""
            rs_VNCSEINF_B_READ.Tables("RESULT").Rows(rowcount).Item("vcs_csenam") = ""
            rs_VNCSEINF_B_READ.Tables("RESULT").Rows(rowcount).Item("vcs_cseadr") = ""
            rs_VNCSEINF_B_READ.Tables("RESULT").Rows(rowcount).Item("vcs_csestt") = ""
            rs_VNCSEINF_B_READ.Tables("RESULT").Rows(rowcount).Item("vcs_csecty") = "CN - CHINA"
            rs_VNCSEINF_B_READ.Tables("RESULT").Rows(rowcount).Item("vcs_csezip") = ""
            rs_VNCSEINF_B_READ.Tables("RESULT").Rows(rowcount).Item("vcs_csectp") = ""
            rs_VNCSEINF_B_READ.Tables("RESULT").Rows(rowcount).Item("vcs_csetil") = ""
            rs_VNCSEINF_B_READ.Tables("RESULT").Rows(rowcount).Item("vcs_csephn") = ""
            rs_VNCSEINF_B_READ.Tables("RESULT").Rows(rowcount).Item("vcs_csefax") = ""
            rs_VNCSEINF_B_READ.Tables("RESULT").Rows(rowcount).Item("vcs_cseeml") = ""
            rs_VNCSEINF_B_READ.Tables("RESULT").Rows(rowcount).Item("vcs_csermk") = ""
            rs_VNCSEINF_B_READ.Tables("RESULT").Rows(rowcount).Item("vcs_accno") = ""
            rs_VNCSEINF_B_READ.Tables("RESULT").Rows(rowcount).Item("vcs_accnam") = ""
            rs_VNCSEINF_B_READ.Tables("RESULT").Rows(rowcount).Item("vcs_csedef") = "N"
            rs_VNCSEINF_B_READ.Tables("RESULT").Rows(rowcount).Item("vcs_csetyp") = "B"
            rs_VNCSEINF_B_READ.Tables("RESULT").Rows(rowcount).Item("vcs_cseseq") = -1


            Recordstatus = True
        End If


    End Sub
    Private Sub add_VNCNTPER()
        Dim cnttyp As String = rs_SYSETINF13.Tables("RESULT").Rows(0).Item(0)


        Dim rowcount As Integer
        rowcount = rs_VNCNTPER_READ.Tables("RESULT").Rows.Count
        Dim dr() As DataRow = rs_VNCNTPER_READ.Tables("RESULT").Select("vci_cntctp = ''")
        If dr.Length = 0 Then

            Dim tmp_dr() As DataRow = rs_VNCNTPER_READ.Tables("RESULT").Select("vci_cnttyp = '" + cnttyp + "'")
            Dim tmp_default As String = "Y"
            Dim tmp_flg As Boolean = False
            If tmp_dr.Length > 0 Then
                For i As Integer = 0 To tmp_dr.Length - 1
                    If tmp_dr(i).Item("status") = "" Then
                        tmp_flg = True
                    End If
                Next

                If tmp_flg Then
                    tmp_default = "N"
                End If
            End If


            rs_VNCNTPER_READ.Tables("RESULT").Rows.Add()
            rs_VNCNTPER_READ.Tables("RESULT").Rows(rowcount).Item("vci_creusr") = "~*ADD*~"
            rs_VNCNTPER_READ.Tables("RESULT").Rows(rowcount).Item("status") = ""
            rs_VNCNTPER_READ.Tables("RESULT").Rows(rowcount).Item("vci_cnttyp") = cnttyp
            rs_VNCNTPER_READ.Tables("RESULT").Rows(rowcount).Item("vci_cntctp") = ""
            rs_VNCNTPER_READ.Tables("RESULT").Rows(rowcount).Item("vci_cnttil") = ""
            rs_VNCNTPER_READ.Tables("RESULT").Rows(rowcount).Item("vci_cntphn") = ""
            rs_VNCNTPER_READ.Tables("RESULT").Rows(rowcount).Item("vci_cntfax") = ""
            rs_VNCNTPER_READ.Tables("RESULT").Rows(rowcount).Item("vci_cnteml") = ""
            rs_VNCNTPER_READ.Tables("RESULT").Rows(rowcount).Item("vci_cntdef") = tmp_default
            rs_VNCNTPER_READ.Tables("RESULT").Rows(rowcount).Item("vci_seq") = -1
            Recordstatus = True
        End If


    End Sub
    Private Sub add_VNCNTINF()

        Dim rowcount As Integer
        rowcount = rs_VNCNTINF_U_READ.Tables("RESULT").Rows.Count
        Dim dr() As DataRow = rs_VNCNTINF_U_READ.Tables("RESULT").Select("vci_adr = ''")
        If dr.Length = 0 Then
            rs_VNCNTINF_U_READ.Tables("RESULT").Rows.Add()
            rs_VNCNTINF_U_READ.Tables("RESULT").Rows(rowcount).Item("vci_creusr") = "~*ADD*~"
            rs_VNCNTINF_U_READ.Tables("RESULT").Rows(rowcount).Item("status") = ""
            rs_VNCNTINF_U_READ.Tables("RESULT").Rows(rowcount).Item("vci_cnttyp") = ""
            rs_VNCNTINF_U_READ.Tables("RESULT").Rows(rowcount).Item("vci_adr") = ""
            rs_VNCNTINF_U_READ.Tables("RESULT").Rows(rowcount).Item("vci_stt") = ""
            rs_VNCNTINF_U_READ.Tables("RESULT").Rows(rowcount).Item("vci_city") = ""
            rs_VNCNTINF_U_READ.Tables("RESULT").Rows(rowcount).Item("vci_town") = ""
            rs_VNCNTINF_U_READ.Tables("RESULT").Rows(rowcount).Item("vci_cty") = ""
            rs_VNCNTINF_U_READ.Tables("RESULT").Rows(rowcount).Item("vci_zip") = ""
            rs_VNCNTINF_U_READ.Tables("RESULT").Rows(rowcount).Item("vci_adrdtl") = ""
            rs_VNCNTINF_U_READ.Tables("RESULT").Rows(rowcount).Item("vci_seq") = -1


            Recordstatus = True
        End If


    End Sub


    Private Sub grdVnCntInf_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdVnCntInf.CellContentClick

    End Sub

    Private Sub grdFactoryRel_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdFactoryRel.CellClick
        If mode <> "ADD" And mode <> "UPDATE" Then
            Exit Sub
        End If




        Select Case grdFactoryRel.CurrentCell.ColumnIndex
            Case grdFactoryRel_vsv_ven2name

                If Not grdFactoryRel.Item(grdFactoryRel_vsv_creusr, grdFactoryRel.CurrentCell.RowIndex).Value = "~*ADD*~" Then
                    Exit Sub
                End If

                If lstVen2.Visible = True Then
                    lstVen2.Visible = False
                    Exit Sub
                End If


                fill_lstVen2()


                'display
                display_lstVen2()
                lstrowindexVen2 = grdFactoryRel.CurrentCell.RowIndex

        End Select
    End Sub
    Private Sub display_lstVen2()
        Dim currcellrectangle As Rectangle = _
        grdFactoryRel.GetCellDisplayRectangle(grdFactoryRel.CurrentCell.ColumnIndex, _
                                            grdFactoryRel.CurrentCell.RowIndex, _
                                            True)


        lstVen2.Enabled = True
        lstVen2.Visible = True
        lstVen2.Top = currcellrectangle.Top + grdFactoryRel.Item(0, 0).DataGridView.Top + grdFactoryRel.Item(0, 0).DataGridView.ColumnHeadersHeight
        lstVen2.Left = grdFactoryRel.Item(0, 0).DataGridView.Left + grdFactoryRel.Item(0, 0).DataGridView.RowHeadersWidth + grdFactoryRel.Columns(0).Width
        lstVen2.Width = 270 'grdview column (2) (3)
        lstVen2.Focus()



        'lstCustomer.Top = grdRelCus.Item(0, 0).DataGridView.Top + grdRelCus.Item(0, 0).DataGridView.ColumnHeadersHeight + grdRelCus.RowTemplate.Height * (grdRelCus.CurrentCell.RowIndex + 1)
        'lstCustomer.Left = grdRelCus.Item(0, 0).DataGridView.Left + grdRelCus.Item(0, 0).DataGridView.RowHeadersWidth

    End Sub
    Private Sub display_lstVen1()
        Dim currcellrectangle As Rectangle = _
        grdVendorRel.GetCellDisplayRectangle(grdVendorRel.CurrentCell.ColumnIndex, _
                                            grdVendorRel.CurrentCell.RowIndex, _
                                            True)


        lstVen1.Enabled = True
        lstVen1.Visible = True
        lstVen1.Top = currcellrectangle.Top + grdVendorRel.Item(0, 0).DataGridView.Top + grdVendorRel.Item(0, 0).DataGridView.ColumnHeadersHeight
        lstVen1.Left = grdVendorRel.Item(0, 0).DataGridView.Left + grdVendorRel.Item(0, 0).DataGridView.RowHeadersWidth + grdVendorRel.Columns(0).Width
        lstVen1.Width = 270 'grdview column (2) (3)
        lstVen1.Focus()



        'lstCustomer.Top = grdRelCus.Item(0, 0).DataGridView.Top + grdRelCus.Item(0, 0).DataGridView.ColumnHeadersHeight + grdRelCus.RowTemplate.Height * (grdRelCus.CurrentCell.RowIndex + 1)
        'lstCustomer.Left = grdRelCus.Item(0, 0).DataGridView.Left + grdRelCus.Item(0, 0).DataGridView.RowHeadersWidth

    End Sub
    Private Sub fill_lstVen2()
        lstVen2.Items.Clear()

        Dim i As Integer
        For i = 0 To rs_VNBASINF_ALL.Tables("RESULT").Rows.Count - 1
            If rs_VNBASINF_ALL.Tables("RESULT").Rows(i).Item("vbi_venno") >= "1000" And rs_VNBASINF_ALL.Tables("RESULT").Rows(i).Item("vbi_venno") <= "5000" Then
                lstVen2.Items.Add(rs_VNBASINF_ALL.Tables("RESULT").Rows(i).Item("vbi_venno") + " - " + Trim(rs_VNBASINF_ALL.Tables("RESULT").Rows(i).Item("vbi_vensna")))
            End If
        Next i


    End Sub

    Private Sub fill_lstVen1()
        lstVen1.Items.Clear()

        Dim i As Integer
        For i = 0 To rs_VNBASINF_ALL.Tables("RESULT").Rows.Count - 1
            If rs_VNBASINF_ALL.Tables("RESULT").Rows(i).Item("vbi_venno") >= "1000" And rs_VNBASINF_ALL.Tables("RESULT").Rows(i).Item("vbi_venno") <= "5000" Then
                lstVen1.Items.Add(rs_VNBASINF_ALL.Tables("RESULT").Rows(i).Item("vbi_venno") + " - " + Trim(rs_VNBASINF_ALL.Tables("RESULT").Rows(i).Item("vbi_vensna")))
            End If
        Next i


    End Sub
    Private Sub grdFactoryRel_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdFactoryRel.CellContentClick

    End Sub

    Private Sub grdFactoryRel_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdFactoryRel.CellDoubleClick
        If mode = "ReadOnly" Then
            Exit Sub
        End If


        If e.RowIndex = -1 Then
            Exit Sub
        End If


        If grdFactoryRel.RowCount > 0 Then
            Dim iCol As Integer = grdFactoryRel.CurrentCell.ColumnIndex
            Dim iRow As Integer = grdFactoryRel.CurrentCell.RowIndex




            If grdFactoryRel.CurrentCell.ColumnIndex = grdFactoryRel_vsv_del Then

                Dim curvalue As String
                curvalue = grdFactoryRel.CurrentCell.Value
                If Trim(curvalue) = "" Then
                    Dim i As Integer
                    Dim counter As Integer
                    counter = 0
                    For i = 0 To grdFactoryRel.RowCount - 1
                        If Trim(grdFactoryRel.Item(grdFactoryRel_vsv_del, i).Value) = "" Then
                            counter = counter + 1
                        End If
                    Next i

                    'If counter = 1 Then
                    '    MsgBox("At least one color must exist!")
                    '    Exit Sub
                    'Else
                    grdFactoryRel.Item(grdFactoryRel_vsv_del, iRow).Value = "Y"
                    'End If

                Else
                    grdFactoryRel.Item(grdFactoryRel_vsv_del, iRow).Value = ""


                End If



                If grdFactoryRel.Item(grdFactoryRel_vsv_creusr, iRow).Value <> "~*ADD*~" Then
                    grdFactoryRel.Item(grdFactoryRel_vsv_creusr, iRow).Value = "~*UPD*~"
                    Recordstatus = True
                End If

            End If
        End If
    End Sub







    Private Sub grdFactoryRel_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdFactoryRel.CellValidated


        'Dim i As Integer
        'For i = 0 To rs_VNSUBVN_V_READ.Tables("RESULT").Columns.Count - 1
        '    rs_VNSUBVN_V_READ.Tables("RESULT").Columns(i).ReadOnly = False
        'Next i

        'If grdFactoryRel.CurrentCell.ColumnIndex = grdFactoryRel_vsv_ven2name Then
        '    If grdFactoryRel.Item(grdFactoryRel_vsv_creusr, grdFactoryRel.CurrentCell.RowIndex).Value = "~*ADD*~" Then
        '        If grdFactoryRel.Rows(grdFactoryRel.CurrentCell.RowIndex).Cells("vsv_ven2name").Value.ToString <> "" Then
        '            grdFactoryRel.Rows(grdFactoryRel.CurrentCell.RowIndex).Cells("vsv_ven2cde").Value = Split(grdFactoryRel.Rows(grdFactoryRel.CurrentCell.RowIndex).Cells("vsv_ven2name").Value.ToString, " - ")(0)
        '        End If
        '    End If
        'End If
    End Sub

    Private Sub grdFactoryRel_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdFactoryRel.EditingControlShowing
        If grdFactoryRel.RowCount = 0 Then
            Exit Sub
        End If
        e.CellStyle.BackColor = Color.White

        Select Case grdFactoryRel.CurrentCell.ColumnIndex
            Case grdFactoryRel_vsv_ven2name
                If TypeOf (e.Control) Is DataGridViewComboBoxEditingControl Then
                    Dim cboBox As ComboBox = CType(e.Control, ComboBox)
                    If Not cboBox Is Nothing Then
                        'RemoveHandler cboBox.SelectedIndexChanged, AddressOf cbo_dgCostPrice_SelectedIndexChanged
                        'AddHandler cboBox.SelectedIndexChanged, AddressOf cbo_dgCostPrice_SelectedIndexChanged
                    End If
                End If

        End Select

        If mode = "UPDATE" Or mode = "ADD" Then
            Recordstatus = True
            If grdFactoryRel.Item(grdFactoryRel_vsv_creusr, grdFactoryRel.CurrentCell.RowIndex).Value <> "~*ADD*~" Then
                grdFactoryRel.Item(grdFactoryRel_vsv_creusr, grdFactoryRel.CurrentCell.RowIndex).Value = "~*UPD*~"
            End If
        End If
    End Sub

    Private Sub grdFactoryRel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdFactoryRel.GotFocus
        Got_Focus_Grid = "FactoryRel"
        lblFactoryRel.ForeColor = Color.DarkCyan
    End Sub

    Private Sub grdFactoryRel_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdFactoryRel.LostFocus
        lblFactoryRel.ForeColor = Color.Blue
    End Sub

    Private Sub grdVendorRel_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdVendorRel.CellClick
        If mode <> "ADD" And mode <> "UPDATE" Then
            Exit Sub
        End If




        Select Case grdVendorRel.CurrentCell.ColumnIndex
            Case grdVendorRel_vsv_ven1name
                If Not grdVendorRel.Item(grdVendorRel_vsv_creusr, grdVendorRel.CurrentCell.RowIndex).Value = "~*ADD*~" Then
                    Exit Sub
                End If
                If lstVen1.Visible = True Then
                    lstVen1.Visible = False
                    Exit Sub
                End If


                fill_lstVen1()


                display_lstVen1()
                lstrowindexVen1 = grdVendorRel.CurrentCell.RowIndex



        End Select
    End Sub

    Private Sub grdVendorRel_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdVendorRel.CellContentClick

    End Sub

    Private Sub grdVendorRel_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdVendorRel.CellDoubleClick
        If mode = "ReadOnly" Then
            Exit Sub
        End If


        If e.RowIndex = -1 Then
            Exit Sub
        End If

        If grdVendorRel.RowCount > 0 Then
            Dim iCol As Integer = grdVendorRel.CurrentCell.ColumnIndex
            Dim iRow As Integer = grdVendorRel.CurrentCell.RowIndex


            If grdVendorRel.CurrentCell.ColumnIndex = grdVendorRel_vsv_del Then
                Dim curvalue As String
                curvalue = grdVendorRel.CurrentCell.Value
                If Trim(curvalue) = "" Then
                    Dim i As Integer
                    Dim counter As Integer
                    counter = 0
                    For i = 0 To grdVendorRel.RowCount - 1
                        If Trim(grdVendorRel.Item(grdVendorRel_vsv_del, i).Value) = "" Then
                            counter = counter + 1
                        End If
                    Next i

                    'If counter = 1 Then
                    '    MsgBox("At least one color must exist!")
                    '    Exit Sub
                    'Else
                    grdVendorRel.Item(grdVendorRel_vsv_del, iRow).Value = "Y"
                    'End If

                Else
                    grdVendorRel.Item(grdVendorRel_vsv_del, iRow).Value = ""


                End If



                If grdVendorRel.Item(grdVendorRel_vsv_creusr, iRow).Value <> "~*ADD*~" Then
                    grdVendorRel.Item(grdVendorRel_vsv_creusr, iRow).Value = "~*UPD*~"
                    Recordstatus = True
                End If

            End If
        End If
    End Sub

    Private Sub grdVendorRel_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdVendorRel.CellValidated


        'Dim i As Integer
        'For i = 0 To rs_VNSUBVN_F_READ.Tables("RESULT").Columns.Count - 1
        '    rs_VNSUBVN_F_READ.Tables("RESULT").Columns(i).ReadOnly = False
        'Next i

        'If grdVendorRel.CurrentCell.ColumnIndex = grdVendorRel_vsv_ven1name Then
        '    If grdVendorRel.Item(grdVendorRel_vsv_creusr, grdVendorRel.CurrentCell.RowIndex).Value = "~*ADD*~" Then
        '        If grdVendorRel.Rows(grdVendorRel.CurrentCell.RowIndex).Cells("vsv_ven1name").Value.ToString <> "" Then
        '            grdVendorRel.Rows(grdVendorRel.CurrentCell.RowIndex).Cells("vsv_ven1cde").Value = Split(grdVendorRel.Rows(grdVendorRel.CurrentCell.RowIndex).Cells("vsv_ven1name").Value.ToString, " - ")(0)
        '        End If
        '    End If
        'End If
    End Sub

    Private Sub grdVendorRel_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdVendorRel.EditingControlShowing
        If grdVendorRel.RowCount = 0 Then
            Exit Sub
        End If
        e.CellStyle.BackColor = Color.White

        Select Case grdVendorRel.CurrentCell.ColumnIndex
            Case grdVendorRel_vsv_ven1name
                If TypeOf (e.Control) Is DataGridViewComboBoxEditingControl Then
                    Dim cboBox As ComboBox = CType(e.Control, ComboBox)
                    If Not cboBox Is Nothing Then
                        'RemoveHandler cboBox.SelectedIndexChanged, AddressOf cbo_dgCostPrice_SelectedIndexChanged
                        'AddHandler cboBox.SelectedIndexChanged, AddressOf cbo_dgCostPrice_SelectedIndexChanged
                    End If
                End If

        End Select

        If mode = "UPDATE" Or mode = "ADD" Then
            Recordstatus = True
            If grdVendorRel.Item(grdVendorRel_vsv_creusr, grdVendorRel.CurrentCell.RowIndex).Value <> "~*ADD*~" Then
                grdVendorRel.Item(grdVendorRel_vsv_creusr, grdVendorRel.CurrentCell.RowIndex).Value = "~*UPD*~"
            End If
        End If
    End Sub

    Private Sub grdVendorRel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdVendorRel.GotFocus
        Got_Focus_Grid = "VendorRel"
        lblVendorRel.ForeColor = Color.DarkCyan
    End Sub

    Private Sub grdVendorRel_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdVendorRel.LostFocus
        lblVendorRel.ForeColor = Color.Blue
    End Sub

    Private Sub grdVnCntInf_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdVnCntInf.EditingControlShowing
        If grdVnCntInf.RowCount = 0 Then
            Exit Sub
        End If
        e.CellStyle.BackColor = Color.White

        Select Case grdVnCntInf.CurrentCell.ColumnIndex
            Case grdVnCntInf_vci_cty
                If TypeOf (e.Control) Is DataGridViewComboBoxEditingControl Then
                    Dim cboBox As ComboBox = CType(e.Control, ComboBox)
                    If Not cboBox Is Nothing Then
                        'RemoveHandler cboBox.SelectedIndexChanged, AddressOf cbo_dgCostPrice_SelectedIndexChanged
                        'AddHandler cboBox.SelectedIndexChanged, AddressOf cbo_dgCostPrice_SelectedIndexChanged
                    End If
                End If

        End Select


        If mode = "UPDATE" Or mode = "ADD" Then
            Recordstatus = True
            If grdVnCntInf.Item(grdVnCntInf_vci_creusr, grdVnCntInf.CurrentCell.RowIndex).Value <> "~*ADD*~" Then
                grdVnCntInf.Item(grdVnCntInf_vci_creusr, grdVnCntInf.CurrentCell.RowIndex).Value = "~*UPD*~"
            End If
        End If


    End Sub



    Private Sub grdVnCntPer_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdVnCntPer.EditingControlShowing
        If grdVnCntPer.RowCount = 0 Then
            Exit Sub
        End If
        e.CellStyle.BackColor = Color.White

        Select Case grdVnCntPer.CurrentCell.ColumnIndex
            Case grdVnCntPer_vci_cnttyp
                If TypeOf (e.Control) Is DataGridViewComboBoxEditingControl Then
                    Dim cboBox As ComboBox = CType(e.Control, ComboBox)
                    If Not cboBox Is Nothing Then
                        'RemoveHandler cboBox.SelectedIndexChanged, AddressOf cbo_dgCostPrice_SelectedIndexChanged
                        'AddHandler cboBox.SelectedIndexChanged, AddressOf cbo_dgCostPrice_SelectedIndexChanged
                    End If
                End If

        End Select

        If mode = "UPDATE" Or mode = "ADD" Then
            Recordstatus = True
            If grdVnCntPer.Item(grdVnCntPer_vci_creusr, grdVnCntPer.CurrentCell.RowIndex).Value <> "~*ADD*~" Then
                grdVnCntPer.Item(grdVnCntPer_vci_creusr, grdVnCntPer.CurrentCell.RowIndex).Value = "~*UPD*~"
            End If
        End If

    End Sub

    Private Sub grdVnCseBnk_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdVnCseBnk.CellContentClick

    End Sub

    Private Sub grdVnCseBnk_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdVnCseBnk.EditingControlShowing
        If grdVnCseBnk.RowCount = 0 Then
            Exit Sub
        End If
        e.CellStyle.BackColor = Color.White

        Select Case grdVnCseBnk.CurrentCell.ColumnIndex
            Case grdVnCseBnk_vcs_csecty
                If TypeOf (e.Control) Is DataGridViewComboBoxEditingControl Then
                    Dim cboBox As ComboBox = CType(e.Control, ComboBox)
                    If Not cboBox Is Nothing Then
                        'RemoveHandler cboBox.SelectedIndexChanged, AddressOf cbo_dgCostPrice_SelectedIndexChanged
                        'AddHandler cboBox.SelectedIndexChanged, AddressOf cbo_dgCostPrice_SelectedIndexChanged
                    End If
                End If

        End Select

        If mode = "UPDATE" Or mode = "ADD" Then
            Recordstatus = True
            If grdVnCseBnk.Item(grdVnCseBnk_vcs_creusr, grdVnCseBnk.CurrentCell.RowIndex).Value <> "~*ADD*~" Then
                grdVnCseBnk.Item(grdVnCseBnk_vcs_creusr, grdVnCseBnk.CurrentCell.RowIndex).Value = "~*UPD*~"
            End If
        End If


    End Sub

    Private Sub grdVnCntPer_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdVnCntPer.CellDoubleClick
        If mode = "ReadOnly" Then
            Exit Sub
        End If


        If e.RowIndex = -1 Then
            Exit Sub
        End If

        If grdVnCntPer.RowCount > 0 Then
            Dim iCol As Integer = grdVnCntPer.CurrentCell.ColumnIndex
            Dim iRow As Integer = grdVnCntPer.CurrentCell.RowIndex
            Dim curvalue As String
            curvalue = grdVnCntPer.CurrentCell.Value
            Dim curcnttyp = rs_VNCNTPER_READ.Tables("RESULT").Rows(iRow).Item("vci_cnttyp")

            If grdVnCntPer.CurrentCell.ColumnIndex = grdVnCntPer_vci_status And e.ColumnIndex = 0 And e.RowIndex >= 0 Then
                If Trim(curvalue) = "" Then
                    grdVnCntPer.Item(grdVnCntInf_vci_status, iRow).Value = "Y"

                    If grdVnCntPer.Item(grdVnCntPer_vci_cntdef, iRow).Value = "Y" Then
                        grdVnCntPer.Item(grdVnCntPer_vci_cntdef, iRow).Value = "N"
                        For i As Integer = 0 To grdVnCntPer.Rows.Count - 1
                            If i <> iRow Then
                                If ( _
                                        rs_VNCNTPER_READ.Tables("RESULT").Rows(i).Item("vci_cnttyp") = curcnttyp And _
                                        rs_VNCNTPER_READ.Tables("RESULT").Rows(i).Item("vci_cntdef") = "N" _
                                   ) Then
                                    If grdVnCntPer.Item(grdVnCntPer_vci_status, i).Value <> "Y" Then
                                        grdVnCntPer.Item(grdVnCntPer_vci_cntdef, i).Value = "Y"
                                        Exit For
                                    End If
                                End If
                            End If
                        Next
                    End If

                Else
                    grdVnCntPer.Item(grdVnCntPer_vci_status, iRow).Value = ""
                    Dim tmp_flg As Boolean = True
                    For i As Integer = 0 To grdVnCntPer.Rows.Count - 1
                        If i <> iRow Then
                            If ( _
                                        rs_VNCNTPER_READ.Tables("RESULT").Rows(i).Item("vci_cnttyp") = curcnttyp And _
                                        rs_VNCNTPER_READ.Tables("RESULT").Rows(i).Item("vci_cntdef") = "Y" _
                                   ) Then
                                tmp_flg = False
                                Exit For
                            End If
                        End If
                    Next

                    If tmp_flg Then
                        grdVnCntPer.Item(grdVnCntPer_vci_cntdef, iRow).Value = "Y"
                    End If

                End If

            ElseIf grdVnCntPer.CurrentCell.ColumnIndex = 7 And e.ColumnIndex = 7 And e.RowIndex >= 0 Then
                If grdVnCntPer.Item(grdVnCntPer_vci_status, iRow).Value <> "Y" Then
                    changeDefaultgrdVnCntPer()
                End If

            End If

            If grdVnCntPer.Item(grdVnCntPer_vci_creusr, iRow).Value <> "~*ADD*~" Then
                grdVnCntPer.Item(grdVnCntPer_vci_creusr, iRow).Value = "~*UPD*~"
                Recordstatus = True
            End If


        End If
    End Sub

    Private Sub delete_PER()
        'If grdVnCntPer.Item(7, grdVnCntPer.CurrentCell.RowIndex).Value = "Y" Then
        '    MsgBox("Default PV cannot be deleted!")
        '    Exit Sub
        'End If

        'Dim strDV As String
        'strDV = Split(cboDV.Text, " - ")(0)

        'Dim del_pv As String
        'del_pv = dgPV.Item(4, dgPV.CurrentCell.RowIndex).Value

        'If strDV = del_pv Then
        '    MsgBox("Design Vendor PV cannot be deleted!")
        '    Exit Sub
        'End If

        'If MsgBox("All Cost Price related to this Production Vendor will be deleted!", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
        '    Exit Sub
        'End If


        'Dim tmp_pv As String

        'Dim i As Integer
        'For i = 0 To rs_IMVENINF.Tables("RESULT").Rows.Count - 1
        '    tmp_pv = rs_IMVENINF.Tables("RESULT").Rows(i).Item("ivi_venno")

        '    If del_pv = tmp_pv Then
        '        'rs_IMVENINF.Tables("RESULT").Rows(i).Item("ivi_creusr") = "~*DEL*~"
        '        rs_IMVENINF.Tables("RESULT").Rows(i).Item("ivi_cocde") = "Y"
        '        Recordstatus = True
        '    End If
        'Next i

        'For i = 0 To rs_IMPRCINF.Tables("RESULT").Rows.Count - 1
        '    tmp_pv = rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_prdven")

        '    If del_pv = tmp_pv Then
        '        Recordstatus = True
        '        'rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_creusr") = "~*DEL*~"
        '        rs_IMPRCINF.Tables("RESULT").Rows(i).Item("imu_cocde") = "Y"
        '    End If
        'Next i
    End Sub

    Private Sub changeDefaultgrdVnCntPer()



        If grdVnCntPer.Item(7, grdVnCntPer.CurrentCell.RowIndex).Value = "Y" Then
            Exit Sub
        End If

        Dim default_vn As String
        default_vn = grdVnCntPer.Item(1, grdVnCntPer.CurrentCell.RowIndex).Value

        Dim tmp_vn As String

        Dim i As Integer
        For i = 0 To rs_VNCNTPER_READ.Tables("RESULT").Rows.Count - 1
            tmp_vn = rs_VNCNTPER_READ.Tables("RESULT").Rows(i).Item("vci_cnttyp")

            If default_vn = tmp_vn Then
                If rs_VNCNTPER_READ.Tables("RESULT").Rows(i).Item("vci_creusr") <> "~*ADD*~" Then
                    rs_VNCNTPER_READ.Tables("RESULT").Rows(i).Item("vci_creusr") = "~*UPD*~"
                End If
                rs_VNCNTPER_READ.Tables("RESULT").Rows(i).Item("vci_cntdef") = "N"
                Recordstatus = True
                'ElseIf rs_VNCNTPER_READ.Tables("RESULT").Rows(i).Item("vci_cntdef") = "Y" Then
                '    If rs_VNCNTPER_READ.Tables("RESULT").Rows(i).Item("vci_creusr") <> "~*ADD*~" Then
                '        rs_VNCNTPER_READ.Tables("RESULT").Rows(i).Item("vci_creusr") = "~*UPD*~"
                '    End If
                '    rs_VNCNTPER_READ.Tables("RESULT").Rows(i).Item("vci_cntdef") = "N"
                '    Recordstatus = True
            End If

        Next i

        grdVnCntPer.Item(grdVnCntPer_vci_cntdef, grdVnCntPer.CurrentCell.RowIndex).Value = "Y"

        If grdVnCntPer.Item(grdVnCntPer_vci_creusr, grdVnCntPer.CurrentCell.RowIndex).Value <> "~*ADD*~" Then
            grdVnCntPer.Item(grdVnCntPer_vci_creusr, grdVnCntPer.CurrentCell.RowIndex).Value = "~*UPD*~"
            Recordstatus = True

        End If


        'If grdVnCntPer.Item(7, grdVnCntPer.CurrentCell.RowIndex).Value = "Y" Then
        '    Exit Sub
        'End If

        'Dim default_vn As String
        'default_vn = grdVnCntPer.Item(2, grdVnCntPer.CurrentCell.RowIndex).Value

        'Dim tmp_vn As String

        'Dim i As Integer
        'For i = 0 To rs_VNCNTPER_READ.Tables("RESULT").Rows.Count - 1
        '    tmp_vn = rs_VNCNTPER_READ.Tables("RESULT").Rows(i).Item("vci_cntctp")

        '    If default_vn = tmp_vn Then
        '        If rs_VNCNTPER_READ.Tables("RESULT").Rows(i).Item("vci_creusr") <> "~*ADD*~" Then
        '            rs_VNCNTPER_READ.Tables("RESULT").Rows(i).Item("vci_creusr") = "~*UPD*~"
        '        End If
        '        rs_VNCNTPER_READ.Tables("RESULT").Rows(i).Item("vci_cntdef") = "Y"
        '        Recordstatus = True
        '    ElseIf rs_VNCNTPER_READ.Tables("RESULT").Rows(i).Item("vci_cntdef") = "Y" Then
        '        If rs_VNCNTPER_READ.Tables("RESULT").Rows(i).Item("vci_creusr") <> "~*ADD*~" Then
        '            rs_VNCNTPER_READ.Tables("RESULT").Rows(i).Item("vci_creusr") = "~*UPD*~"
        '        End If
        '        rs_VNCNTPER_READ.Tables("RESULT").Rows(i).Item("vci_cntdef") = "N"
        '        Recordstatus = True
        '    End If

        'Next i


    End Sub

    Private Sub changecnttyp_procedure()


        Dim current_row As Integer = grdVnCntPer.CurrentCell.RowIndex
        Dim current_vn As String = grdVnCntPer.Item(1, current_row).Value


        Dim old_vn As String = rs_VNCNTPER_READ.Tables("RESULT").Rows(current_row).Item("vci_cnttyp")
        Dim old_defaultflg As String = rs_VNCNTPER_READ.Tables("RESULT").Rows(current_row).Item("vci_cntdef")


        For i As Integer = 0 To grdVnCntPer.Rows.Count - 1
            If i <> current_row Then
                If rs_VNCNTPER_READ.Tables("RESULT").Rows(i).Item("vci_cnttyp") = old_vn Then
                    If (old_defaultflg = "Y" And grdVnCntPer.Item(grdVnCntPer_vci_status, i).Value <> "Y") Then
                        rs_VNCNTPER_READ.Tables("RESULT").Rows(i).Item("vci_cntdef") = "Y"
                        Exit For
                    End If
                End If
            End If
        Next

        Dim tmp_flg As Boolean = True
        For i As Integer = 0 To grdVnCntPer.Rows.Count - 1
            If i <> current_row Then
                If (rs_VNCNTPER_READ.Tables("RESULT").Rows(i).Item("vci_cnttyp") = current_vn And rs_VNCNTPER_READ.Tables("RESULT").Rows(i).Item("vci_cntdef") = "Y") Then
                    tmp_flg = False
                End If
            End If
        Next
        If (tmp_flg And grdVnCntPer.Item(grdVnCntPer_vci_status, current_row).Value <> "Y") Then
            rs_VNCNTPER_READ.Tables("RESULT").Rows(current_row).Item("vci_cntdef") = "Y"
        Else
            rs_VNCNTPER_READ.Tables("RESULT").Rows(current_row).Item("vci_cntdef") = "N"
        End If


        'Dim dr() As DataRow = rs_VNCNTPER_READ.Tables("RESULT").Select("vci_cnttyp = '" + current_vn + "'")


    End Sub

    Private Sub grdVnCseBnk_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdVnCseBnk.CellDoubleClick
        If mode = "ReadOnly" Then
            Exit Sub
        End If


        If e.RowIndex = -1 Then
            Exit Sub
        End If

        If grdVnCseBnk.RowCount > 0 Then
            Dim iCol As Integer = grdVnCseBnk.CurrentCell.ColumnIndex
            Dim iRow As Integer = grdVnCseBnk.CurrentCell.RowIndex
            Dim curvalue As String
            curvalue = grdVnCseBnk.CurrentCell.Value

            If grdVnCseBnk.CurrentCell.ColumnIndex = grdVnCseBnk_vcs_status And e.ColumnIndex = 0 And e.RowIndex >= 0 Then
                If Trim(curvalue) = "" Then

                    grdVnCseBnk.Item(grdVnCseBnk_vcs_status, iRow).Value = "Y"
                Else
                    grdVnCseBnk.Item(grdVnCseBnk_vcs_status, iRow).Value = ""

                End If


            ElseIf grdVnCseBnk.CurrentCell.ColumnIndex = 14 And e.ColumnIndex = 14 And e.RowIndex >= 0 Then
                changeDefaultgrdVnCseBnk()

            End If

            If grdVnCseBnk.Item(grdVnCseBnk_vcs_creusr, iRow).Value <> "~*ADD*~" Then
                grdVnCseBnk.Item(grdVnCseBnk_vcs_creusr, iRow).Value = "~*UPD*~"
                Recordstatus = True
            End If


        End If
    End Sub

    Private Sub changeDefaultgrdVnCseBnk()



        If grdVnCseBnk.Item(14, grdVnCseBnk.CurrentCell.RowIndex).Value = "Y" Then
            Exit Sub
        End If

        Dim default_vn As String
        default_vn = grdVnCseBnk.Item(1, grdVnCseBnk.CurrentCell.RowIndex).Value

        Dim tmp_vn As String

        Dim i As Integer
        For i = 0 To rs_VNCSEINF_B_READ.Tables("RESULT").Rows.Count - 1
            tmp_vn = rs_VNCSEINF_B_READ.Tables("RESULT").Rows(i).Item("vcs_csenam")

            If default_vn = tmp_vn Then
                If rs_VNCSEINF_B_READ.Tables("RESULT").Rows(i).Item("vcs_creusr") <> "~*ADD*~" Then
                    rs_VNCSEINF_B_READ.Tables("RESULT").Rows(i).Item("vcs_creusr") = "~*UPD*~"
                End If
                rs_VNCSEINF_B_READ.Tables("RESULT").Rows(i).Item("vcs_csedef") = "Y"
                Recordstatus = True
            ElseIf rs_VNCSEINF_B_READ.Tables("RESULT").Rows(i).Item("vcs_csedef") = "Y" Then
                If rs_VNCSEINF_B_READ.Tables("RESULT").Rows(i).Item("vcs_creusr") <> "~*ADD*~" Then
                    rs_VNCSEINF_B_READ.Tables("RESULT").Rows(i).Item("vcs_creusr") = "~*UPD*~"
                End If
                rs_VNCSEINF_B_READ.Tables("RESULT").Rows(i).Item("vcs_csedef") = "N"
                Recordstatus = True
            End If

        Next i
    End Sub

    Private Sub grdItmNat_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdItmNat.CellContentClick

    End Sub

    Private Sub grdItmNat_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdItmNat.CellDoubleClick
        If mode = "ReadOnly" Then
            Exit Sub
        End If


        If e.RowIndex = -1 Then
            Exit Sub
        End If


        If grdItmNat.RowCount > 0 Then
            Dim iCol As Integer = grdItmNat.CurrentCell.ColumnIndex
            Dim iRow As Integer = grdItmNat.CurrentCell.RowIndex
            Dim curvalue As String
            curvalue = grdItmNat.CurrentCell.Value

            If grdItmNat.CurrentCell.ColumnIndex = grdItmNat_vin_status And e.ColumnIndex = 0 And e.RowIndex >= 0 Then
                If Trim(curvalue) = "" Then
                    Dim i As Integer
                    Dim counter As Integer
                    counter = 0
                    For i = 0 To grdItmNat.RowCount - 1
                        If Trim(grdItmNat.Item(grdItmNat_vin_status, i).Value) = "" Then
                            counter = counter + 1
                        End If
                    Next i

                    'If counter = 1 Then
                    '    MsgBox("At least one color must exist!")
                    '    Exit Sub
                    'Else
                    grdItmNat.Item(grdItmNat_vin_status, iRow).Value = "Y"
                    'End If

                Else
                    grdItmNat.Item(grdItmNat_vin_status, iRow).Value = ""

                End If



                If grdItmNat.Item(grdItmNat_vin_creusr, iRow).Value <> "~*ADD*~" Then
                    grdItmNat.Item(grdItmNat_vin_creusr, iRow).Value = "~*UPD*~"
                    Recordstatus = True
                End If

            End If
        End If


    End Sub

    Private Sub grdVnCntInf_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdVnCntInf.CellDoubleClick
        If mode = "ReadOnly" Then
            Exit Sub
        End If


        If e.RowIndex = -1 Then
            Exit Sub
        End If

        If grdVnCntInf.RowCount > 0 Then
            Dim iCol As Integer = grdVnCntInf.CurrentCell.ColumnIndex
            Dim iRow As Integer = grdVnCntInf.CurrentCell.RowIndex
            Dim curvalue As String
            curvalue = grdVnCntInf.CurrentCell.Value

            If grdVnCntInf.CurrentCell.ColumnIndex = grdVnCntInf_vci_status Then
                If Trim(curvalue) = "" Then
                    Dim i As Integer
                    Dim counter As Integer
                    counter = 0
                    For i = 0 To grdVnCntInf.RowCount - 1
                        If Trim(grdVnCntInf.Item(grdVnCntInf_vci_status, i).Value) = "" Then
                            counter = counter + 1
                        End If
                    Next i

                    'If counter = 1 Then
                    '    MsgBox("At least one color must exist!")
                    '    Exit Sub
                    'Else
                    grdVnCntInf.Item(grdVnCntInf_vci_status, iRow).Value = "Y"
                    'End If

                Else
                    grdVnCntInf.Item(grdVnCntInf_vci_status, iRow).Value = ""


                End If



                If grdVnCntInf.Item(grdVnCntInf_vci_creusr, iRow).Value <> "~*ADD*~" Then
                    grdVnCntInf.Item(grdVnCntInf_vci_creusr, iRow).Value = "~*UPD*~"
                    Recordstatus = True
                End If

            End If
        End If
    End Sub

    Private Sub mmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdSave.Click



        Me.Cursor = Cursors.WaitCursor

        If mode = "UPDATE" Then
            If checkTimeStamp() = False Then
                MsgBox("The record has been modified by other users, please clear and try again.")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
        End If

        If check_Vendor() = False Then
            Me.Cursor = Cursors.Default
            Exit Sub
        End If




        Dim i As Integer
        If save_Vendor() = True Then
            MsgBox("Record Saved!")
        Else
            MsgBox("Error during save, please check!")
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        Dim tmp_itmno As String = txtVenNo.Text
        mode = "INIT"
        formInit(mode)
        txtVenNo.Text = tmp_itmno
        txtVenNo.Select()

        cboVenSts.Text = "A - Active"

        Me.Cursor = Cursors.Default

    End Sub

    Private Function save_Vendor() As Boolean 'see'
        save_Vendor = True


        If save_VNBASINF() = False Then
            save_Vendor = False
            Exit Function
        End If

        If save_VNITMNAT() = False Then
            save_Vendor = False
            Exit Function
        End If

        If save_VnCntInf() = False Then
            save_Vendor = False
            Exit Function
        End If

        If save_VNCNTPER() = False Then
            save_Vendor = False
            Exit Function
        End If

        If save_VnCseBnk() = False Then
            save_Vendor = False
            Exit Function
        End If

        If save_FactoryRel() = False Then
            save_Vendor = False
            Exit Function
        End If


        If save_VendorRel() = False Then
            save_Vendor = False
            Exit Function
        End If

        If save_VNCUGREL() = False Then
            save_Vendor = False
            Exit Function
        End If

        If save_VNPRCTRM() = False Then
            save_Vendor = False
            Exit Function
        End If

        If save_VNEXCCUS() = False Then
            save_Vendor = False
            Exit Function
        End If



    End Function
    Private Function save_VNEXCCUS() As Boolean
        If rs_VNEXCCUS.Tables("RESULT").Rows.Count = 0 Then
            save_VNEXCCUS = True
            Exit Function
        End If


        Dim vec_cocde As String
        Dim vec_venno As String
        Dim vec_cusno As String
        Dim vec_rmark As String
        Dim vec_creusr As String

        Dim i As Integer

        For i = 0 To rs_VNEXCCUS.Tables("RESULT").Rows.Count - 1
            vec_cocde = rs_VNEXCCUS.Tables("RESULT").Rows(i).Item("vec_cocde").ToString
            vec_venno = txtVenNo.Text
            vec_cusno = Split(rs_VNEXCCUS.Tables("RESULT").Rows(i).Item("vec_cusno").ToString, " - ")(0)
            vec_rmark = Replace(rs_VNEXCCUS.Tables("RESULT").Rows(i).Item("vec_rmark").ToString, "'", "''")
            vec_creusr = rs_VNEXCCUS.Tables("RESULT").Rows(i).Item("vec_creusr").ToString


            gspStr = ""


            If vec_cocde = "Y" Then
                gspStr = "sp_physical_delete_VNEXCCUS '','" & vec_venno & "','" & vec_cusno & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_VNEXCCUS sp_physical_delete_VNEXCCUS:" & rtnStr)
                    save_VNEXCCUS = False
                    Exit Function

                End If
            ElseIf vec_creusr = "~*ADD*~" Then




                gspStr = "sp_insert_VNEXCCUS '','" & vec_venno & "','" & vec_cusno & "','" & vec_rmark & "','" & gsUsrID & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_VNEXCCUS sp_insert_VNEXCCUS:" & rtnStr)
                    save_VNEXCCUS = False
                    Exit Function

                End If

            ElseIf vec_creusr = "~*UPD*~" Then

                'change default

                gspStr = "sp_update_VNEXCCUS '','" & vec_venno & "','" & vec_cusno & "','" & vec_rmark & "','" & gsUsrID & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_VNEXCCUS sp_update_VNEXCCUS :" & rtnStr)
                    save_VNEXCCUS = False
                    Exit Function
                End If


            End If

        Next i

        save_VNEXCCUS = True
    End Function

    Private Function save_VNPRCTRM() As Boolean
        If rs_VNPRCTRM_READ.Tables("RESULT").Rows.Count = 0 Then
            save_VNPRCTRM = True
            Exit Function
        End If


        Dim vpt_cocde As String
        Dim vpt_venno As String
        Dim vpt_prctrm As String
        Dim vpt_prcdef As String
        Dim vpt_creusr As String

        Dim i As Integer

        For i = 0 To rs_VNPRCTRM_READ.Tables("RESULT").Rows.Count - 1
            vpt_cocde = rs_VNPRCTRM_READ.Tables("RESULT").Rows(i).Item("vpt_cocde").ToString
            vpt_venno = txtVenNo.Text
            vpt_prctrm = Split(rs_VNPRCTRM_READ.Tables("RESULT").Rows(i).Item("vpt_prctrm").ToString, " - ")(0)
            vpt_prcdef = rs_VNPRCTRM_READ.Tables("RESULT").Rows(i).Item("vpt_prcdef").ToString
            vpt_creusr = rs_VNPRCTRM_READ.Tables("RESULT").Rows(i).Item("vpt_creusr").ToString


            gspStr = ""


            If vpt_cocde = "Y" Then
                gspStr = "sp_physical_delete_VNPRCTRM '','" & vpt_venno & "','" & vpt_prctrm & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_VNPRCTRM sp_physical_delete_VNPRCTRM:" & rtnStr)
                    save_VNPRCTRM = False
                    Exit Function

                End If
            ElseIf vpt_creusr = "~*ADD*~" Then




                gspStr = "sp_insert_VNPRCTRM '','" & vpt_venno & "','" & vpt_prctrm & "','" & vpt_prcdef & "','" & gsUsrID & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_VNPRCTRM sp_insert_VNPRCTRM:" & rtnStr)
                    save_VNPRCTRM = False
                    Exit Function

                End If

            ElseIf vpt_creusr = "~*UPD*~" Then

                'change default

                gspStr = "sp_update_VNPRCTRM '" & "" & "','" & vpt_venno & "','" & vpt_prcdef & "','" & _
                                                 vpt_prctrm & "','" & gsUsrID & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_VNPRCTRM sp_update_VNPRCTRM :" & rtnStr)
                    save_VNPRCTRM = False
                    Exit Function
                End If


            End If

        Next i

        save_VNPRCTRM = True
    End Function



    Private Function save_VNCUGREL() As Boolean

        If rs_VNCUGREL_READ.Tables("RESULT").Rows.Count = 0 Then
            save_VNCUGREL = True
            Exit Function
        End If


        Dim vcr_cocde As String
        Dim vcr_venno As String
        Dim vcr_cugrpcde As String
        Dim vcr_flg_int As String
        Dim vcr_flg_ext As String
        Dim vcr_creusr As String
        Dim icf_mrkup As Decimal


        Dim i As Integer

        For i = 0 To rs_VNCUGREL_READ.Tables("RESULT").Rows.Count - 1
            vcr_cocde = rs_VNCUGREL_READ.Tables("RESULT").Rows(i).Item("vcr_cocde").ToString
            vcr_venno = txtVenNo.Text
            vcr_cugrpcde = rs_VNCUGREL_READ.Tables("RESULT").Rows(i).Item("vcr_cugrpcde").ToString
            vcr_flg_int = rs_VNCUGREL_READ.Tables("RESULT").Rows(i).Item("vcr_flg_int").ToString
            vcr_flg_ext = rs_VNCUGREL_READ.Tables("RESULT").Rows(i).Item("vcr_flg_ext").ToString

            icf_mrkup = IIf(rs_VNCUGREL_READ.Tables("RESULT").Rows(i).Item("icf_mrkup").ToString = "", 0, rs_VNCUGREL_READ.Tables("RESULT").Rows(i).Item("icf_mrkup").ToString)

            vcr_creusr = rs_VNCUGREL_READ.Tables("RESULT").Rows(i).Item("vcr_creusr").ToString



            gspStr = ""

            If vcr_creusr = "~*ADD*~" Then
                gspStr = "sp_insert_VNCUGREL '','" & vcr_venno & "','" & vcr_cugrpcde & "','" & vcr_flg_int & "','" & vcr_flg_ext & "'," & icf_mrkup & ",'" & gsUsrID & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_VNCUGREL sp_insert_VNCUGREL:" & rtnStr)
                    save_VNCUGREL = False
                    Exit Function

                End If
            ElseIf vcr_creusr = "~*UPD*~" Then

                gspStr = "sp_update_VNCUGREL '" & "" & "','" & vcr_venno & "','" & vcr_cugrpcde & "','" & _
                                                   vcr_flg_ext & "'," & icf_mrkup & ",'" & gsUsrID & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_VNCUGREL sp_update_VNCUGREL :" & rtnStr)
                    save_VNCUGREL = False
                    Exit Function
                End If
            End If









        Next i


        save_VNCUGREL = True
    End Function
    Private Function save_VendorRel() As Boolean

        If rs_VNSUBVN_F_READ.Tables("RESULT").Rows.Count = 0 Then
            save_VendorRel = True
            Exit Function
        End If


        Dim vsv_cocde As String

        Dim vsv_ven1cde As String

        Dim vsv_ven2cde As String

        Dim vsv_venrel As String

        Dim vsv_creusr As String




        Dim i As Integer

        For i = 0 To rs_VNSUBVN_F_READ.Tables("RESULT").Rows.Count - 1
            vsv_cocde = rs_VNSUBVN_F_READ.Tables("RESULT").Rows(i).Item("vsv_del").ToString

            vsv_ven1cde = rs_VNSUBVN_F_READ.Tables("RESULT").Rows(i).Item("vsv_ven1cde").ToString
            vsv_ven2cde = txtVenNo.Text
            vsv_venrel = rs_VNSUBVN_F_READ.Tables("RESULT").Rows(i).Item("vsv_ven1name").ToString
            vsv_creusr = rs_VNSUBVN_F_READ.Tables("RESULT").Rows(i).Item("vsv_creusr").ToString



            gspStr = ""

            If vsv_cocde = "Y" Then
                gspStr = "sp_physical_delete_VNSUBVN '','" & vsv_ven1cde & "','" & vsv_ven2cde & "','" & gsUsrID & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_VendorRel sp_physical_delete_VNSUBVN:" & rtnStr)
                    save_VendorRel = False
                    Exit Function

                End If
            ElseIf vsv_creusr = "~*ADD*~" Then

                gspStr = "sp_insert_VNSUBVN '" & vsv_cocde & "','" & vsv_ven1cde & "','" & vsv_ven2cde & "','" & _
                                                   vsv_venrel & "','" & gsUsrID & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_VendorRel sp_insert_VNSUBVN :" & rtnStr)
                    save_VendorRel = False
                    Exit Function
                End If
            End If









        Next i


        save_VendorRel = True
    End Function
    Private Function save_FactoryRel() As Boolean

        If rs_VNSUBVN_V_READ.Tables("RESULT").Rows.Count = 0 Then
            save_FactoryRel = True
            Exit Function
        End If


        Dim vsv_cocde As String

        Dim vsv_ven1cde As String

        Dim vsv_ven2cde As String

        Dim vsv_venrel As String

        Dim vsv_creusr As String




        Dim i As Integer

        For i = 0 To rs_VNSUBVN_V_READ.Tables("RESULT").Rows.Count - 1
            vsv_cocde = rs_VNSUBVN_V_READ.Tables("RESULT").Rows(i).Item("vsv_del").ToString

            vsv_ven1cde = txtVenNo.Text
            vsv_ven2cde = rs_VNSUBVN_V_READ.Tables("RESULT").Rows(i).Item("vsv_ven2cde").ToString
            vsv_venrel = rs_VNSUBVN_V_READ.Tables("RESULT").Rows(i).Item("vsv_ven2name").ToString
            vsv_creusr = rs_VNSUBVN_V_READ.Tables("RESULT").Rows(i).Item("vsv_creusr").ToString



            gspStr = ""

            If vsv_cocde = "Y" Then
                gspStr = "sp_physical_delete_VNSUBVN '','" & vsv_ven1cde & "','" & vsv_ven2cde & "','" & gsUsrID & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_FactoryRel sp_physical_delete_VNSUBVN:" & rtnStr)
                    save_FactoryRel = False
                    Exit Function

                End If
            ElseIf vsv_creusr = "~*ADD*~" Then

                gspStr = "sp_insert_VNSUBVN '" & vsv_cocde & "','" & vsv_ven1cde & "','" & vsv_ven2cde & "','" & _
                                                   vsv_venrel & "','" & gsUsrID & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_FactoryRel sp_insert_VNSUBVN :" & rtnStr)
                    save_FactoryRel = False
                    Exit Function
                End If
            End If









        Next i


        save_FactoryRel = True
    End Function
    Private Function save_VNBASINF() As Boolean   '''''''''''''''''''''''''finish it!!!!!'''''''''''''''
        Dim vbi_cocde As String

        Dim vbi_venno As String
        Dim vbi_vensts As String
        Dim vbi_vensna As String
        Dim vbi_vennam As String
        Dim vbi_venrat As String
        Dim vbi_prctrm As String
        Dim vbi_paytrm As String
        Dim vbi_curcde As String
        Dim vbi_discnt As Double
        Dim vbi_orgven As String
        Dim vbi_rmk As String
        Dim vbi_ledtim As String 'Integer
        Dim vbi_tsttim As String 'Integer
        Dim vbi_bufday As String 'Integer
        Dim vbi_venweb As String
        Dim vbi_ventyp As String
        Dim vbi_moqchg As String
        Dim vci_adr As String
        Dim vci_stt As String
        Dim vci_city As String
        Dim vci_town As String

        Dim vci_cty As String
        Dim vci_zip As String
        Dim vbi_frurcde As String
        Dim vbi_framt As String 'Integer


        Dim vbi_venchnnam As String
        Dim vci_chnadr As String
        Dim vbi_venfty As String
        Dim vbi_updusr As String
        Dim vbi_ventranflg As String
        Dim vbi_venflag As String

        Dim i As Integer
        For i = 0 To rs_VNPRCTRM_READ.Tables("RESULT").Rows.Count - 1
            If rs_VNPRCTRM_READ.Tables("RESULT").Rows(i).Item("vpt_prcdef") = "Y" Then
                vbi_prctrm = Split(rs_VNPRCTRM_READ.Tables("RESULT").Rows(i).Item("vpt_prctrm"), " - ")(0)
            End If
        Next

        vbi_ventranflg = cboTranFlag.Text

        vbi_cocde = ""
        vbi_venno = txtVenNo.Text
        vbi_vensts = Split(cboVenSts.Text, " - ")(0)
        vbi_vensna = Replace(txtVenSna.Text, "'", "''")
        vbi_vennam = Replace(txtVenNam.Text, "'", "''")
        vbi_venrat = Split(cboVenRat.Text, " - ")(0)
        'vbi_prctrm = Split(cboPrcTrm.Text, " - ")(0)
        vbi_paytrm = Split(cboPayTrm.Text, " - ")(0)
        vbi_curcde = Split(cboCurCde.Text, " - ")(0)

        vbi_discnt = Trim(txtDisCnt.Text)
        vbi_orgven = txtOrgVen.Text
        vbi_rmk = Replace(txtRmk.Text, "'", "''")

        If Trim(txtLedTim.Text) = "" Then
            vbi_ledtim = 0
        Else
            vbi_ledtim = txtLedTim.Text
        End If

        If Trim(txtTstTim.Text) = "" Then
            vbi_tsttim = 0
        Else
            vbi_tsttim = txtTstTim.Text
        End If

        If Trim(txtBufDay.Text) = "" Then
            vbi_bufday = 0
        Else
            vbi_bufday = txtBufDay.Text
        End If


        vbi_venweb = txtVenWeb.Text
        vbi_frurcde = cboThcCry.Text

        If txtThcAmt.Text = "" Then
            vbi_framt = 0
        Else
            vbi_framt = txtThcAmt.Text
        End If


        If cboVenType.Text = "Internal" Then
            vbi_ventyp = "I"
        ElseIf cboVenType.Text = "External" Then
            vbi_ventyp = "E"
        ElseIf cboVenType.Text = "Joint Venture" Then
            vbi_ventyp = "J"
        Else
            vbi_ventyp = " "
        End If

        If ChkMOQChg.Checked = True Then
            vbi_moqchg = "Y"
        ElseIf ChkMOQChg.Checked = False Then
            vbi_moqchg = "N"
        End If

        If chkActivate.Checked = True Then
            vbi_vensts = "A"
        End If


        vci_adr = Replace(txtAdr.Text, "'", "''")
        vci_stt = txtStt.Text
        vci_city = txtCity.Text
        vci_town = txtTown.Text

        vci_cty = Split(cboCty.Text, " - ")(0)
        vci_zip = txtZip.Text
        vbi_venchnnam = Replace(txtVenChnNam.Text, "'", "''")
        vci_chnadr = Replace(txtAdr2.Text, "'", "''")

        If chkfty.Checked = True Then
            vbi_venfty = "F"
        Else
            vbi_venfty = "A"
        End If

        If cboVndFlag.Text = "" Then
            cboVndFlag.Text = "U - UCP Vendor"
        End If

        vbi_venflag = Split(cboVndFlag.Text, " - ")(0)

        If Add_flag = True Then

            gspStr = "sp_insert_VNBASINF '" & vbi_cocde & "','" & vbi_venno & "','" & vbi_vensts & "','" & vbi_vensna & "','" & _
                   vbi_vennam & "','" & vbi_venrat & "','" & vbi_prctrm & "','" & vbi_paytrm & "','" & vbi_curcde & "'," & vbi_discnt & ",'" & _
                   vbi_orgven & "','" & vbi_rmk & "'," & vbi_ledtim & "," & vbi_tsttim & "," & vbi_bufday & ",'" & vbi_venweb & _
                   "','" & vbi_ventyp & "','" & vbi_moqchg & "','" & vbi_frurcde & "'," & vbi_framt & ",'" _
                   & vci_adr & "','" & vci_stt & "','" & vci_city & "','" & vci_town & "','" & vci_cty & _
                    "','" & vci_zip & "','" & vbi_venchnnam & "','" & vci_chnadr & "','" & vbi_venfty & "','" & vbi_ventranflg & "','" & vbi_venflag & "','" & gsUsrID & "'"

            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading save_VNBASINF sp_insert_VNBASINF :" & rtnStr)
                save_VNBASINF = False
                Exit Function
            End If

        Else

            gspStr = "sp_update_VNBASINF '" & vbi_cocde & "','" & vbi_venno & "','" & vbi_vensts & "','" & vbi_vensna & "','" & _
                  vbi_vennam & "','" & vbi_venrat & "','" & vbi_prctrm & "','" & vbi_paytrm & "','" & vbi_curcde & "'," & vbi_discnt & ",'" & _
                  vbi_orgven & "','" & vbi_rmk & "'," & vbi_ledtim & "," & vbi_tsttim & "," & vbi_bufday & ",'" & vbi_venweb & _
                  "','" & vbi_ventyp & "','" & vbi_moqchg & "','" & vbi_frurcde & "'," & vbi_framt & _
                   ",'" & vbi_venchnnam & "','" & vbi_venfty & "','" & vbi_ventranflg & "','" & vbi_venflag & "','" & gsUsrID & "'"

            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading save_VNBASINF sp_update_VNBASINF :" & rtnStr)
                save_VNBASINF = False
                Exit Function
            End If



        End If

        save_VNBASINF = True
    End Function




    Private Function save_VnCseBnk() As Boolean   'VnCseBnk 'Done it here'

        If rs_VNCSEINF_B_READ.Tables("RESULT").Rows.Count = 0 Then
            save_VnCseBnk = True
            Exit Function
        End If

        Dim vcs_cocde As String

        Dim vcs_venno As String
        Dim vcs_csetyp As String

        Dim vcs_csenam As String
        Dim vcs_cseadr As String
        Dim vcs_csestt As String
        Dim vcs_csecty As String
        Dim vcs_csezip As String

        Dim vcs_csectp As String
        Dim vcs_csetil As String
        Dim vcs_csephn As String
        Dim vcs_csefax As String
        Dim vcs_cseeml As String
        Dim vcs_csermk As String

        Dim vcs_accno As String
        Dim vcs_accnam As String
        Dim vcs_csedef As String

        Dim vcs_updusr As String
        Dim vcs_cseseq As Integer

        Dim i As Integer

        For i = 0 To rs_VNCSEINF_B_READ.Tables("RESULT").Rows.Count - 1
            vcs_cocde = rs_VNCSEINF_B_READ.Tables("RESULT").Rows(i).Item("status").ToString
            vcs_venno = txtVenNo.Text
            vcs_csetyp = rs_VNCSEINF_B_READ.Tables("RESULT").Rows(i).Item("vcs_csetyp").ToString
            vcs_csenam = Replace(rs_VNCSEINF_B_READ.Tables("RESULT").Rows(i).Item("vcs_csenam").ToString, "'", "''")
            vcs_cseadr = Replace(rs_VNCSEINF_B_READ.Tables("RESULT").Rows(i).Item("vcs_cseadr").ToString, "'", "''")
            vcs_csestt = rs_VNCSEINF_B_READ.Tables("RESULT").Rows(i).Item("vcs_csestt").ToString
            vcs_csecty = Split(rs_VNCSEINF_B_READ.Tables("RESULT").Rows(i).Item("vcs_csecty").ToString, " - ")(0)
            vcs_csezip = rs_VNCSEINF_B_READ.Tables("RESULT").Rows(i).Item("vcs_csezip").ToString
            vcs_csectp = rs_VNCSEINF_B_READ.Tables("RESULT").Rows(i).Item("vcs_csectp").ToString
            vcs_csetil = rs_VNCSEINF_B_READ.Tables("RESULT").Rows(i).Item("vcs_csetil").ToString
            vcs_csephn = rs_VNCSEINF_B_READ.Tables("RESULT").Rows(i).Item("vcs_csephn").ToString
            vcs_csefax = rs_VNCSEINF_B_READ.Tables("RESULT").Rows(i).Item("vcs_csefax").ToString
            vcs_cseeml = rs_VNCSEINF_B_READ.Tables("RESULT").Rows(i).Item("vcs_cseeml").ToString
            vcs_csermk = Replace(rs_VNCSEINF_B_READ.Tables("RESULT").Rows(i).Item("vcs_csermk").ToString, "'", "''")
            vcs_accno = rs_VNCSEINF_B_READ.Tables("RESULT").Rows(i).Item("vcs_accno").ToString
            vcs_accnam = rs_VNCSEINF_B_READ.Tables("RESULT").Rows(i).Item("vcs_accnam").ToString
            vcs_csedef = rs_VNCSEINF_B_READ.Tables("RESULT").Rows(i).Item("vcs_csedef").ToString
            vcs_updusr = rs_VNCSEINF_B_READ.Tables("RESULT").Rows(i).Item("vcs_creusr").ToString
            vcs_cseseq = rs_VNCSEINF_B_READ.Tables("RESULT").Rows(i).Item("vcs_cseseq")


            gspStr = ""

            If vcs_cocde = "Y" Then
                gspStr = "sp_physical_delete_VNCSEINF '','" & vcs_venno & "','" & vcs_csetyp & "'," & vcs_cseseq
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_VnCseBnk sp_physical_delete_VNCSEINF:" & rtnStr)
                    save_VnCseBnk = False
                    Exit Function

                End If

            ElseIf vcs_updusr = "~*ADD*~" Then
                If vcs_csenam <> "" Then
                    gspStr = "sp_insert_VNCSEINF '" & vcs_cocde & "','" & vcs_venno & "','" & vcs_csetyp & "','" & vcs_csenam & "','" & _
                   vcs_cseadr & "','" & vcs_csestt & "','" & vcs_csecty & "','" & vcs_csezip & "','" & vcs_csectp & "','" & vcs_csetil & "','" & _
                   vcs_csephn & "','" & vcs_csefax & "','" & vcs_cseeml & "','" & vcs_csermk & "','" & vcs_accno & "','" & vcs_accnam & _
                   "','" & vcs_csedef & "','" & gsUsrID & "'"

                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading save_VnCseBnk sp_insert_VNCSEINF :" & rtnStr)
                        save_VnCseBnk = False
                        Exit Function
                    End If
                End If
            ElseIf vcs_updusr = "~*UPD*~" Then
                If vcs_csenam <> "" Then
                    gspStr = "sp_update_VNCSEINF '" & vcs_cocde & "','" & vcs_venno & "','" & vcs_csetyp & "'," & vcs_cseseq & ",'" & vcs_csenam & "','" & _
                   vcs_cseadr & "','" & vcs_csestt & "','" & vcs_csecty & "','" & vcs_csezip & "','" & vcs_csectp & "','" & vcs_csetil & "','" & _
                   vcs_csephn & "','" & vcs_csefax & "','" & vcs_cseeml & "','" & vcs_csermk & "','" & vcs_accno & "','" & vcs_accnam & _
                   "','" & vcs_csedef & "','" & gsUsrID & "'"

                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading save_VnCseBnk sp_update_VNCSEINF :" & rtnStr)
                        save_VnCseBnk = False
                        Exit Function
                    End If
                End If


            End If







        Next i


        save_VnCseBnk = True
    End Function
    Private Function save_VNCNTPER() As Boolean

        If rs_VNCNTPER_READ.Tables("RESULT").Rows.Count = 0 Then
            save_VNCNTPER = True
            Exit Function
        End If
        Dim vci_cocde As String
        Dim vci_venno As String
        Dim vci_cnttyp As String
        Dim vci_adr As String
        Dim vci_stt As String

        Dim vci_city As String
        Dim vci_town As String

        Dim vci_cty As String
        Dim vci_zip As String
        Dim vci_adrdtl As String
        Dim vci_cntctp As String
        Dim vci_cnttil As String
        Dim vci_cntphn As String
        Dim vci_cntfax As String
        Dim vci_cnteml As String
        Dim vci_cntdef As String
        Dim vci_updusr As String
        Dim vci_seq As Integer
        Dim vci_chnadr As String


        Dim i As Integer

        For i = 0 To rs_VNCNTPER_READ.Tables("RESULT").Rows.Count - 1

            vci_cocde = rs_VNCNTPER_READ.Tables("RESULT").Rows(i).Item("Status").ToString
            vci_venno = txtVenNo.Text
            vci_cnttyp = rs_VNCNTPER_READ.Tables("RESULT").Rows(i).Item("vci_cnttyp").ToString
            vci_adr = ""
            vci_stt = ""
            vci_city = ""
            vci_town = ""
            vci_cty = ""
            vci_zip = ""
            vci_adrdtl = ""
            vci_cntctp = rs_VNCNTPER_READ.Tables("RESULT").Rows(i).Item("vci_cntctp").ToString
            vci_cnttil = rs_VNCNTPER_READ.Tables("RESULT").Rows(i).Item("vci_cnttil").ToString
            vci_cntphn = rs_VNCNTPER_READ.Tables("RESULT").Rows(i).Item("vci_cntphn").ToString
            vci_cntfax = rs_VNCNTPER_READ.Tables("RESULT").Rows(i).Item("vci_cntfax").ToString
            vci_cnteml = rs_VNCNTPER_READ.Tables("RESULT").Rows(i).Item("vci_cnteml").ToString
            vci_cntdef = rs_VNCNTPER_READ.Tables("RESULT").Rows(i).Item("vci_cntdef").ToString
            vci_updusr = rs_VNCNTPER_READ.Tables("RESULT").Rows(i).Item("vci_creusr").ToString
            vci_seq = rs_VNCNTPER_READ.Tables("RESULT").Rows(i).Item("vci_seq")
            vci_chnadr = ""

            gspStr = ""



            If vci_cocde = "Y" Then

                gspStr = "sp_physical_delete_VNCNTINF '','" & vci_venno & "','" & vci_cnttyp & "'," & vci_seq
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_VNCNTPER sp_physical_delete_VNCNTINF:" & rtnStr)
                    save_VNCNTPER = False
                    Exit Function

                End If


            ElseIf vci_updusr = "~*ADD*~" Then
                If vci_cntctp <> "" Then
                    gspStr = "sp_insert_VNCNTINF '" & vci_cocde & "','" & vci_venno & "','" & vci_cnttyp & "','" & vci_adr & "','" & _
                   vci_stt & "','" & vci_city & "','" & vci_town & "','" & vci_cty & "','" & vci_zip & "','" & vci_adrdtl & "','" & vci_cntctp & "','" & vci_cnttil & "','" & vci_cntphn & "','" & _
                   vci_cntfax & "','" & vci_cnteml & "','" & vci_cntdef & "','" & gsUsrID & "'"

                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading save_VNCNTPER sp_insert_VNCNTINF :" & rtnStr)
                        save_VNCNTPER = False
                        Exit Function
                    End If
                End If
            ElseIf vci_updusr = "~*UPD*~" Then
                If vci_cntctp <> "" Then
                    gspStr = "sp_update_VNCNTINF '" & vci_cocde & "','" & vci_venno & "','" & vci_cnttyp & "'," & vci_seq & ",'" & vci_adr & "','" & _
                   vci_stt & "','" & vci_city & "','" & vci_town & "','" & vci_cty & "','" & vci_zip & "','" & vci_adrdtl & "','" & vci_cntctp & "','" & vci_cnttil & "','" & vci_cntphn & "','" & _
                   vci_cntfax & "','" & vci_cnteml & "','" & vci_cntdef & "','" & vci_chnadr & "','" & gsUsrID & "'"

                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading save_VNCNTPER sp_update_VNCNTINF :" & rtnStr)
                        save_VNCNTPER = False
                        Exit Function
                    End If
                End If

            End If







        Next i

        save_VNCNTPER = True

    End Function
    Private Function save_VNITMNAT() As Boolean

        If rs_VNITMNAT_READ.Tables("RESULT").Rows.Count = 0 Then
            save_VNITMNAT = True
            Exit Function
        End If


        Dim vin_cocde As String

        Dim vin_venno As String

        Dim vin_natcde As String
        Dim vin_natdsc As String
        Dim vin_creusr As String
        Dim vin_natseq As Integer

        Dim i As Integer

        For i = 0 To rs_VNITMNAT_READ.Tables("RESULT").Rows.Count - 1
            vin_cocde = rs_VNITMNAT_READ.Tables("RESULT").Rows(i).Item("Status").ToString

            vin_venno = txtVenNo.Text
            vin_natcde = Split(rs_VNITMNAT_READ.Tables("RESULT").Rows(i).Item("itmnat").ToString, " - ")(0)
            vin_natdsc = Split(rs_VNITMNAT_READ.Tables("RESULT").Rows(i).Item("itmnat").ToString, " - ")(1)
            vin_creusr = rs_VNITMNAT_READ.Tables("RESULT").Rows(i).Item("vin_creusr").ToString
            vin_natseq = rs_VNITMNAT_READ.Tables("RESULT").Rows(i).Item("vin_natseq")


            gspStr = ""

            If vin_cocde = "Y" Then
                gspStr = "sp_physical_delete_VNITMNAT '','" & vin_venno & "'," & vin_natseq
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_VNITMNAT sp_physical_delete_VNITMNAT:" & rtnStr)
                    save_VNITMNAT = False
                    Exit Function

                End If
            ElseIf vin_creusr = "~*ADD*~" Then
                If vin_natcde <> "" Then
                    gspStr = "sp_insert_VNITMNAT '" & vin_cocde & "','" & vin_venno & "','" & vin_natcde & "','" & vin_natdsc & "','" & _
                                                        gsUsrID & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading save_VNITMNAT sp_insert_VNITMNAT :" & rtnStr)
                        save_VNITMNAT = False
                        Exit Function
                    End If
                End If




            End If







        Next i


        save_VNITMNAT = True
    End Function

    Private Function save_VnCntInf() As Boolean '' rs_VNCNTINF_U_READ



        Dim vci_cocde As String
        Dim vci_venno As String
        Dim vci_cnttyp As String
        Dim vci_adr As String
        Dim vci_stt As String
        Dim vci_city As String
        Dim vci_town As String
        Dim vci_cty As String
        Dim vci_zip As String
        Dim vci_adrdtl As String
        Dim vci_cntctp As String
        Dim vci_cnttil As String
        Dim vci_cntphn As String
        Dim vci_cntfax As String
        Dim vci_cnteml As String
        Dim vci_cntdef As String
        Dim vci_updusr As String
        Dim vci_chnadr As String
        Dim vci_seq As Integer
        Dim i As Integer

        vci_cocde = " "
        vci_venno = txtVenNo.Text
        vci_cnttyp = "M"
        vci_seq = 1
        'vci_adr = Replace(txtAdr.Text, "'", "''")
        vci_adr = Replace(txtEngAdrDisplay.Text, "'", "''")
        vci_adrdtl = Replace(txtAdr.Text, "'", "''")


        vci_stt = Replace(txtStt.Text, "'", "''")
        vci_city = Replace(txtCity.Text, "'", "''")
        vci_town = Replace(txtTown.Text, "'", "''")


        vci_cty = Split(cboCty.Text, " - ")(0)
        vci_zip = txtZip.Text
        vci_cntctp = " "
        vci_cnttil = " "
        vci_cntphn = " "
        vci_cntfax = " "
        vci_cnteml = " "
        vci_cntdef = " "
        vci_chnadr = Replace(txtAdr2.Text, "'", "''")


        gspStr = "sp_update_VNCNTINF '" & vci_cocde & "','" & vci_venno & "','" & vci_cnttyp & "'," & vci_seq & ",'" & vci_adr & "','" & _
                    vci_stt & "','" & vci_city & "','" & vci_town & "','" & vci_cty & "','" & vci_zip & "','" & vci_adrdtl & "','" & vci_cntctp & "','" & vci_cnttil & "','" & vci_cntphn & "','" & _
                    vci_cntfax & "','" & vci_cnteml & "','" & vci_cntdef & "','" & vci_chnadr & "','" & gsUsrID & "'"

        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading save_VnCntInf sp_update_VNCNTINF:" & rtnStr)
            save_VnCntInf = False
            Exit Function

        End If

        '2
        vci_cnttyp = "C"
        vci_seq = 1
        'vci_adr = Replace(txtAdr2.Text, "'", "''")
        vci_adr = Replace(txtChnAdrDisplay.Text, "'", "''")
        vci_adrdtl = Replace(txtAdr2.Text, "'", "''")
        vci_stt = Replace(txtStt2.Text, "'", "''")
        vci_city = Replace(txtCity2.Text, "'", "''")
        vci_town = Replace(txtTown2.Text, "'", "''")
        vci_cty = Trim(cboCty2.Text)
        vci_zip = txtZip2.Text

        gspStr = "sp_update_VNCNTINF '" & vci_cocde & "','" & vci_venno & "','" & vci_cnttyp & "'," & vci_seq & ",'" & vci_adr & "','" & _
                    vci_stt & "','" & vci_city & "','" & vci_town & "','" & vci_cty & "','" & vci_zip & "','" & vci_adrdtl & "','" & vci_cntctp & "','" & vci_cnttil & "','" & vci_cntphn & "','" & _
                    vci_cntfax & "','" & vci_cnteml & "','" & vci_cntdef & "','" & vci_chnadr & "','" & gsUsrID & "'"

        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading save_VnCntInf sp_update_VNCNTINF:" & rtnStr)
            save_VnCntInf = False
            Exit Function

        End If




        If rs_VNCNTINF_U_READ.Tables("RESULT").Rows.Count = 0 Then
            save_VnCntInf = True
            Exit Function
        End If






        For i = 0 To rs_VNCNTINF_U_READ.Tables("RESULT").Rows.Count - 1
            vci_cocde = rs_VNCNTINF_U_READ.Tables("RESULT").Rows(i).Item("Status").ToString
            vci_venno = txtVenNo.Text

            vci_cnttyp = Split(rs_VNCNTINF_U_READ.Tables("RESULT").Rows(i).Item("vci_cnttyp").ToString, " - ")(0)

            'vci_cnttyp = "U"
            vci_adr = Replace(rs_VNCNTINF_U_READ.Tables("RESULT").Rows(i).Item("vci_adr").ToString, "'", "''")
            vci_adrdtl = ""
            vci_stt = Replace(rs_VNCNTINF_U_READ.Tables("RESULT").Rows(i).Item("vci_stt").ToString, "'", "''")
            vci_city = Replace(rs_VNCNTINF_U_READ.Tables("RESULT").Rows(i).Item("vci_city").ToString, "'", "''")
            vci_town = Replace(rs_VNCNTINF_U_READ.Tables("RESULT").Rows(i).Item("vci_town").ToString, "'", "''")
            vci_cty = Split(rs_VNCNTINF_U_READ.Tables("RESULT").Rows(i).Item("vci_cty").ToString, " - ")(0)
            vci_zip = rs_VNCNTINF_U_READ.Tables("RESULT").Rows(i).Item("vci_zip").ToString
            vci_cntctp = " "
            vci_cnttil = " "
            vci_cntphn = " "
            vci_cntfax = " "
            vci_cnteml = " "
            vci_cntdef = " "
            vci_updusr = rs_VNCNTINF_U_READ.Tables("RESULT").Rows(i).Item("vci_creusr").ToString
            vci_seq = rs_VNCNTINF_U_READ.Tables("RESULT").Rows(i).Item("vci_seq")
            vci_chnadr = " "
            gspStr = ""




            If vci_cocde = "Y" Then
                gspStr = "sp_physical_delete_VNCNTINF '','" & vci_venno & "','" & vci_cnttyp & " '," & vci_seq
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_VnCntInf sp_physical_delete_VNCNTINF:" & rtnStr)
                    save_VnCntInf = False
                    Exit Function

                End If
            ElseIf vci_updusr = "~*ADD*~" Then
                If vci_adr <> "" Then
                    gspStr = "sp_insert_VNCNTINF '" & vci_cocde & "','" & vci_venno & "','" & vci_cnttyp & "','" & vci_adr & "','" & _
                    vci_stt & "','" & vci_city & "','" & vci_town & "','" & vci_cty & "','" & vci_zip & "','" & vci_adrdtl & "','" & vci_cntctp & "','" & vci_cnttil & "','" & vci_cntphn & "','" & _
                    vci_cntfax & "','" & vci_cnteml & "','" & vci_cntdef & "','" & gsUsrID & "'"

                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading save_VnCntInf sp_insert_VNCNTINF :" & rtnStr)
                        save_VnCntInf = False
                        Exit Function
                    End If
                End If

            ElseIf vci_updusr = "~*UPD*~" Then
                gspStr = "sp_update_VNCNTINF '" & vci_cocde & "','" & vci_venno & "','" & vci_cnttyp & "'," & vci_seq & ",'" & vci_adr & "','" & _
                    vci_stt & "','" & vci_city & "','" & vci_town & "','" & vci_cty & "','" & vci_zip & "','" & vci_adrdtl & "','" & vci_cntctp & "','" & vci_cnttil & "','" & vci_cntphn & "','" & _
                    vci_cntfax & "','" & vci_cnteml & "','" & vci_cntdef & "','" & vci_chnadr & "','" & gsUsrID & "'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_VnCntInf sp_update_VNCNTINF :" & rtnStr)
                    save_VnCntInf = False
                    Exit Function
                End If

            End If







        Next i

        save_VnCntInf = True

    End Function

    Private Function check_Vendor() As Boolean
        check_Vendor = True

        Dim i As Integer





        If Trim(txtVenNo.Text) = "" Then
            MsgBox("Please Input Vendor No.")
            check_Vendor = False
            Me.BaseTabControl1.SelectedIndex = 0
            txtVenNo.Select()
            Exit Function
        End If

        If Trim(txtVenNam.Text) = "" And Trim(txtVenChnNam.Text) = "" Then
            MsgBox("Please Input Vendor Name")
            check_Vendor = False
            Me.BaseTabControl1.SelectedIndex = 0
            txtVenNam.Select()
            Exit Function
        End If

        If cboVenType.Text = "" Then
            MsgBox("Missing Vendor Type!")
            check_Vendor = False
            Me.BaseTabControl1.SelectedIndex = 0
            txtVenNam.Select()
            Exit Function
        End If



        'Tab1 

        'If cboPrcTrm.Text = "" Then
        '    MsgBox("Missing Price Terms!")
        '    Me.BaseTabControl1.SelectedIndex = 0
        '    check_Vendor = False
        '    cboPrcTrm.Select()
        '    Exit Function
        'End If



        If rs_VNPRCTRM_READ.Tables("RESULT").Rows.Count = 0 Then
            Me.BaseTabControl1.SelectedIndex = 0
            MsgBox("Missing Price Terms!")
            grdPrcTrm.Focus()
            check_Vendor = False
            Exit Function
        Else
            Dim ii As Integer

            For ii = 0 To rs_VNPRCTRM_READ.Tables("RESULT").Rows.Count - 1
                If Trim(rs_VNPRCTRM_READ.Tables("RESULT").Rows(ii).Item(grdPceTme_vpt_prctrm).ToString) = "" Then
                    Me.BaseTabControl1.SelectedIndex = 0
                    MsgBox("Missing Price Terms!")
                    grdPrcTrm.Focus()
                    check_Vendor = False
                    Exit Function
                End If
            Next
        End If


        If cboPayTrm.Text = "" Then
            MsgBox("Missing Payment Terms!")
            Me.BaseTabControl1.SelectedIndex = 0
            check_Vendor = False
            cboPayTrm.Select()
            Exit Function
        End If


        If cboCurCde.Text = "" Then
            MsgBox("Missing Currency for Price!")
            Me.BaseTabControl1.SelectedIndex = 0
            check_Vendor = False
            cboCurCde.Select()
            Exit Function
        End If

        'Tab2

        If Trim(txtAdr.Text) = "" And Trim(txtAdr2.Text) = "" Then
            MsgBox("Missing Company Address!")
            Me.BaseTabControl1.SelectedIndex = 1
            check_Vendor = False
            txtAdr.Select()
            Exit Function

        End If

        If cboCty.Text = "" Then
            MsgBox("Missing Country!")
            Me.BaseTabControl1.SelectedIndex = 1
            check_Vendor = False
            cboCty.Select()
            Exit Function
        End If


        If cboTranFlag.Text = "" Then
            MsgBox("Missing Tran Flag!")
            Me.BaseTabControl1.SelectedIndex = 0
            check_Vendor = False
            cboTranFlag.Select()
            Exit Function
        End If

        If cboVndFlag.Text = "" Then
            MsgBox("Missing Vender Flag!")
            Me.BaseTabControl1.SelectedIndex = 0
            check_Vendor = False
            cboVndFlag.Select()
            Exit Function
        End If



    End Function

    Private Sub mmdDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdDelRow.Click


        If mode = "ReadOnly" Then
            Exit Sub
        End If




        Select Case Got_Focus_Grid


            Case "ItmNat"
                Call Del_ItmNat()
            Case "VNCNTINF"
                Call Del_VNCNTINF()
            Case "VNCNTPER"
                Call Del_VNCNTPER()
            Case "VNCSEBNK"
                Call Del_VNCSEBNK()
            Case "FactoryRel"
                Call Del_FactoryRel()


        End Select












    End Sub

    Private Sub Del_FactoryRel()
        If grdFactoryRel.RowCount > 0 Then
            Dim iCol As Integer = grdFactoryRel.CurrentCell.ColumnIndex
            Dim iRow As Integer = grdFactoryRel.CurrentCell.RowIndex
            Dim curvalue As String
            curvalue = grdFactoryRel.Item(grdFactoryRel_vsv_del, iRow).Value

            If Trim(curvalue) = "" Then
                grdFactoryRel.Item(grdFactoryRel_vsv_del, iRow).Value = "Y"

            Else
                grdFactoryRel.Item(grdFactoryRel_vsv_del, iRow).Value = ""

            End If

            If grdFactoryRel.Item(grdFactoryRel_vsv_creusr, iRow).Value <> "~*ADD*~" Then
                grdFactoryRel.Item(grdFactoryRel_vsv_creusr, iRow).Value = "~*UPD*~"
                Recordstatus = True
            End If
        End If
    End Sub





    Private Sub Del_VNCSEBNK()

        If grdVnCseBnk.RowCount > 0 Then
            Dim iCol As Integer = grdVnCseBnk.CurrentCell.ColumnIndex
            Dim iRow As Integer = grdVnCseBnk.CurrentCell.RowIndex
            Dim curvalue As String
            curvalue = grdVnCseBnk.Item(grdVnCseBnk_vcs_status, iRow).Value

            If Trim(curvalue) = "" Then

                grdVnCseBnk.Item(grdVnCseBnk_vcs_status, iRow).Value = "Y"
            Else
                grdVnCseBnk.Item(grdVnCseBnk_vcs_status, iRow).Value = ""

            End If


            If grdVnCseBnk.Item(grdVnCseBnk_vcs_creusr, iRow).Value <> "~*ADD*~" Then
                grdVnCseBnk.Item(grdVnCseBnk_vcs_creusr, iRow).Value = "~*UPD*~"
                Recordstatus = True
            End If


        End If
    End Sub


    Private Sub Del_VNCNTPER()



        If grdVnCntPer.RowCount > 0 Then
            Dim iCol As Integer = grdVnCntPer.CurrentCell.ColumnIndex
            Dim iRow As Integer = grdVnCntPer.CurrentCell.RowIndex
            Dim curvalue As String
            Dim curcnttyp As String
            curvalue = grdVnCntPer.Item(grdVnCntInf_vci_status, iRow).Value
            curcnttyp = rs_VNCNTPER_READ.Tables("RESULT").Rows(iRow).Item("vci_cnttyp")

            If Trim(curvalue) = "" Then
                grdVnCntPer.Item(grdVnCntInf_vci_status, iRow).Value = "Y"

                If grdVnCntPer.Item(grdVnCntPer_vci_cntdef, iRow).Value = "Y" Then
                    grdVnCntPer.Item(grdVnCntPer_vci_cntdef, iRow).Value = "N"
                    For i As Integer = 0 To grdVnCntPer.Rows.Count - 1
                        If i <> iRow Then
                            If ( _
                                    rs_VNCNTPER_READ.Tables("RESULT").Rows(i).Item("vci_cnttyp") = curcnttyp And _
                                    rs_VNCNTPER_READ.Tables("RESULT").Rows(i).Item("vci_cntdef") = "N" _
                               ) Then
                                If grdVnCntPer.Item(grdVnCntInf_vci_status, i).Value <> "Y" Then
                                    grdVnCntPer.Item(grdVnCntPer_vci_cntdef, i).Value = "Y"
                                    Exit For
                                End If
                            End If
                        End If
                    Next
                End If


            Else
                grdVnCntPer.Item(grdVnCntInf_vci_status, iRow).Value = ""

                Dim tmp_flg As Boolean = True
                For i As Integer = 0 To grdVnCntPer.Rows.Count - 1
                    If i <> iRow Then
                        If ( _
                                    rs_VNCNTPER_READ.Tables("RESULT").Rows(i).Item("vci_cnttyp") = curcnttyp And _
                                    rs_VNCNTPER_READ.Tables("RESULT").Rows(i).Item("vci_cntdef") = "Y" _
                               ) Then
                            tmp_flg = False
                            Exit For
                        End If
                    End If
                Next

                If tmp_flg Then
                    grdVnCntPer.Item(grdVnCntPer_vci_cntdef, iRow).Value = "Y"
                End If

            End If


            If grdVnCntPer.Item(grdVnCntPer_vci_creusr, iRow).Value <> "~*ADD*~" Then
                grdVnCntPer.Item(grdVnCntPer_vci_creusr, iRow).Value = "~*UPD*~"
                Recordstatus = True


            End If
        End If
    End Sub
    Private Sub Del_ItmNat()
        If grdItmNat.RowCount > 0 Then
            Dim iCol As Integer = grdItmNat.CurrentCell.ColumnIndex
            Dim iRow As Integer = grdItmNat.CurrentCell.RowIndex
            Dim curvalue As String
            curvalue = grdItmNat.Item(grdItmNat_vin_status, iRow).Value

            If Trim(curvalue) = "" Then
                grdItmNat.Item(grdItmNat_vin_status, iRow).Value = "Y"

            Else
                grdItmNat.Item(grdItmNat_vin_status, iRow).Value = ""

            End If

            If grdItmNat.Item(grdItmNat_vin_creusr, iRow).Value <> "~*ADD*~" Then
                grdItmNat.Item(grdItmNat_vin_creusr, iRow).Value = "~*UPD*~"
                Recordstatus = True
            End If
        End If
    End Sub

    Private Sub Del_VNCNTINF()
        If grdVnCntInf.RowCount > 0 Then
            Dim iCol As Integer = grdVnCntInf.CurrentCell.ColumnIndex
            Dim iRow As Integer = grdVnCntInf.CurrentCell.RowIndex
            Dim curvalue As String
            curvalue = grdVnCntInf.Item(grdVnCntInf_vci_status, iRow).Value



            If Trim(curvalue) = "" Then
                grdVnCntInf.Item(grdVnCntInf_vci_status, iRow).Value = "Y"

            Else
                grdVnCntInf.Item(grdVnCntInf_vci_status, iRow).Value = ""

            End If



            If grdVnCntInf.Item(grdVnCntInf_vci_creusr, iRow).Value <> "~*ADD*~" Then
                grdVnCntInf.Item(grdVnCntInf_vci_creusr, iRow).Value = "~*UPD*~"
                Recordstatus = True
            End If


        End If
    End Sub

    Private Sub mmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdDelete.Click


        If mode = "UPDATE" Then
            If checkTimeStamp() = False Then
                MsgBox("The record has been modified by other users, please clear and try again.")
                Exit Sub
            End If
        End If

        If MsgBox("Are you sure to delete Vendor " & txtVenNo.Text & "?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        gspStr = "sp_list_QUOTNDTL_VNM00001 '','" & txtVenNo.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_QUOTNDTL, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdDelete_Click sp_list_QUOTNDTL_VNM00001 :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If


        gspStr = "sp_list_SCORDDTL_VNM00001 '','" & txtVenNo.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SCORDDTL, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdDelete_Click sp_list_SCORDDTL_VNM00001 :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If


        gspStr = "sp_list_IMBASINF_1 '','" & txtVenNo.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_IMBASINF_1, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdDelete_Click sp_list_IMBASINF_1 :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If


        gspStr = "sp_list_IMVENINF_1 '','" & txtVenNo.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_IMVENINF_1, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdDelete_Click sp_list_IMVENINF_1 :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If rs_QUOTNDTL.Tables("RESULT").Rows.Count > 0 Then
            MsgBox("This vendor is referenced by Quotation. Record cannot delete!")
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If rs_SCORDDTL.Tables("RESULT").Rows.Count > 0 Then
            MsgBox("This vendor is referenced by SC. Record cannot delete!")

            Me.Cursor = Cursors.Default
            Exit Sub
        End If


        If rs_IMBASINF_1.Tables("RESULT").Rows.Count > 0 Then
            MsgBox("Cannot delete Vendor! Vendor is referenced by Item Masster")
            Me.Cursor = Cursors.Default
            Exit Sub
        End If


        If rs_IMVENINF_1.Tables("RESULT").Rows.Count > 0 Then
            MsgBox("Cannot delete Vendor! Vendor is referenced by Item Masster")
            Me.Cursor = Cursors.Default
            Exit Sub
        End If


        gspStr = "sp_physical_delete_VNBASINF '','" & txtVenNo.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdDelete_Click sp_physical_delete_VNBASINF :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        MsgBox("Record Deleted!")

        mode = "INIT"
        formInit(mode)
        txtVenNo.Select()

        Me.Cursor = Cursors.Default

    End Sub

    Private Function checkTimeStamp() As Boolean
        Dim save_timestamp As Long
        Dim curr_timestamp As Long

        gspStr = "sp_select_VNBASINF '','" & txtVenNo.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading checkTimeStamp sp_select_VNBASINF :" & rtnStr)
            Exit Function
        End If

        save_timestamp = rs.Tables("RESULT").Rows(0).Item("vbi_timstp")
        curr_timestamp = rs_VNBASINF_READ.Tables("RESULT").Rows(0).Item("vbi_timstp")

        If save_timestamp <> curr_timestamp Then
            checkTimeStamp = False
        Else
            checkTimeStamp = True
        End If

    End Function

    Private Sub mmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdExit.Click
        If Recordstatus = True Then
            mmdClear_Click(sender, e)
        End If
        Me.Close()
    End Sub

    Private Sub mmdCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdCopy.Click
        If Recordstatus = True Then
            MsgBox("Vendor has been modified, please save it before Copy")
            Me.Cursor = Cursors.Default
            Exit Sub
        End If



        If PanelCopy.Visible = True Then
            MsgBox("Vendor in Copy Panel Process, Vendor not copy!")
            Me.Cursor = Cursors.Default
            Exit Sub
        End If



        freeze_TabControl(-1)
        resetcmdButton("DisableAll")
        txtPanCopyVendorNo.Text = ""

        PanelCopy.Height = 97
        PanelCopy.Width = 257
        PanelCopy.Top = 12
        PanelCopy.Left = 167


        cmdPanCopyCopy.Enabled = True
        cmdPanCopyCancel.Enabled = True
        txtPanCopyVendorNo.Enabled = True
        PanelCopy.Visible = True
    End Sub

    Private Sub cmdPanCopyCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPanCopyCancel.Click
        PanelCopy.Visible = False
        If cboVenType.Text = "External" Then
            Me.BaseTabControl1.TabPages(0).Enabled = True
            Me.BaseTabControl1.TabPages(1).Enabled = True
            Me.BaseTabControl1.TabPages(2).Enabled = True
            Me.BaseTabControl1.TabPages(3).Enabled = True
            Me.BaseTabControl1.TabPages(4).Enabled = True
            Me.BaseTabControl1.TabPages(5).Enabled = True
        Else
            Me.BaseTabControl1.TabPages(0).Enabled = True
            Me.BaseTabControl1.TabPages(1).Enabled = True
            Me.BaseTabControl1.TabPages(2).Enabled = True
            Me.BaseTabControl1.TabPages(3).Enabled = True
            Me.BaseTabControl1.TabPages(4).Enabled = True
        End If

        resetdisplay(mode)


    End Sub

    Private Sub cmdPanCopyCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPanCopyCopy.Click
        Me.Cursor = Cursors.WaitCursor

        txtPanCopyVendorNo.Text = txtPanCopyVendorNo.Text.ToUpper

        If txtPanCopyVendorNo.Text = "" Then
            MsgBox("Vendor Number cannot empty!")
            txtPanCopyVendorNo.Select()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If txtPanCopyVendorNo.Text = txtVenNo.Text Then
            MsgBox("Vendor Number same as Copy")
            txtPanCopyVendorNo.Select()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If Len(txtPanCopyVendorNo.Text) = 1 And Len(txtPanCopyVendorNo.Text) > 0 Then
            If Len(txtVenNo.Text) = 1 And Asc(Microsoft.VisualBasic.Left(txtPanCopyVendorNo.Text, 1)) < Asc("A") Or Asc(Microsoft.VisualBasic.Left(txtPanCopyVendorNo.Text, 1)) > Asc("Z") Then
                txtPanCopyVendorNo.Focus()
                MsgBox("Invalid Input! (Vendor No. must be between A to Z)")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
        Else
            If Len(txtPanCopyVendorNo.Text) > 4 Or Not IsNumeric(txtPanCopyVendorNo.Text) Or Not InStr(1, txtPanCopyVendorNo.Text, ".") = 0 Or txtPanCopyVendorNo.Text = "0000" Then
                txtPanCopyVendorNo.Focus()
                MsgBox("Invalid Input! (Vendor No. must be between 1001 to 9999")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            If Len(txtPanCopyVendorNo.Text) = 3 Then txtPanCopyVendorNo.Text = "0" + txtPanCopyVendorNo.Text
            If Len(txtPanCopyVendorNo.Text) = 2 Then txtPanCopyVendorNo.Text = "00" + txtPanCopyVendorNo.Text
            If Len(txtPanCopyVendorNo.Text) = 1 Then txtPanCopyVendorNo.Text = "000" + txtPanCopyVendorNo.Text
        End If


        If MsgBox("Are you sure want to copy this record " & "?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Me.Cursor = Cursors.Default
            Exit Sub
        End If


        gspStr = "sp_select_VNBASINF '','" & txtPanCopyVendorNo.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdPanCopyCopy_Click sp_select_VNBASINF :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If rs.Tables("RESULT").Rows.Count > 0 Then
            MsgBox("Duplicate vendor no exists")
            Me.Cursor = Cursors.Default
            Exit Sub
        End If


        gspStr = "sp_select_CopyVendor '','" & txtVenNo.Text & "','" & txtPanCopyVendorNo.Text & "','" & gsUsrID & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdPanCopyCopy_Click sp_select_CopyVendor :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        txtVenNo.Text = txtPanCopyVendorNo.Text
        Call mmdFind_Click(sender, e)
        Call cmdPanCopyCancel_Click(sender, e)

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PanelCopy_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelCopy.Paint

    End Sub

    Private Sub txtDisCnt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDisCnt.KeyPress
        Dim val As String
        val = Trim(txtDisCnt.Text)

        If (InStr("0123456789.", Chr(Asc(e.KeyChar))) = 0) And Asc(e.KeyChar) > 31 Or _
        ((InStr(val, ".") <> 0) And Asc(e.KeyChar) > 31 And Chr(Asc(e.KeyChar)) = ".") Then
            e.KeyChar = Chr(0)
        ElseIf UBound(Split(val, ".")) = 0 Then
            If (Microsoft.VisualBasic.Len(val) + 1 > 3) And Asc(e.KeyChar) > 31 And (Chr(Asc(e.KeyChar)) <> ".") Then
                e.KeyChar = Chr(0)
            End If
        ElseIf UBound(Split(val, ".")) > 0 Then


            If txtDisCnt.SelectionStart <= Microsoft.VisualBasic.Len(Split(val, ".")(0)) Then

                If (Microsoft.VisualBasic.Len(Split(val, ".")(0)) + 1 > 3) And Asc(e.KeyChar) > 31 Then
                    e.KeyChar = Chr(0)

                End If
            Else

                If (Microsoft.VisualBasic.Len(Split(val, ".")(1)) + 1 > 3) And Asc(e.KeyChar) > 31 Then
                    e.KeyChar = Chr(0)

                End If

            End If
        End If

    End Sub

    Private Sub txtDisCnt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDisCnt.LostFocus
        'If IsNumeric(txtDisCnt.Text) = True Then
        '    If Convert.ToInt32(txtDisCnt.Text) > 100 Then
        '        MsgBox("Discount % cannot over 100")
        '        txtDisCnt.Focus()
        '    End If
        'End If
    End Sub

    Private Sub txtDisCnt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDisCnt.TextChanged

    End Sub

    Private Sub txtDisCnt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDisCnt.Validating
        If IsNumeric(txtDisCnt.Text) = True Then
            If Convert.ToDouble(txtDisCnt.Text) > 100 Then
                e.Cancel = True
                MsgBox("Discount % cannot over 100")
                txtDisCnt.Focus()
            End If
        ElseIf Trim(txtDisCnt.Text) = "" Then
            txtDisCnt.Text = 0
        End If

        If txtDisCnt.Text.StartsWith(".") Then
            txtDisCnt.Text = "0" + txtDisCnt.Text
        End If

    End Sub

    Private Sub txtLedTim_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLedTim.KeyPress
        If Not ((Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8) Then
            e.KeyChar = Chr(0)
            MsgBox("Please input integer value.")
        End If
        If mode = "UPDATE" Then
            Recordstatus = True
        End If
    End Sub

    Private Sub txtLedTim_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLedTim.TextChanged

    End Sub

    Private Sub txtBufDay_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBufDay.KeyPress
        If Not ((Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8) Then
            e.KeyChar = Chr(0)
            MsgBox("Please input integer value.")
        End If
        If mode = "UPDATE" Then
            Recordstatus = True
        End If
    End Sub

    Private Sub txtBufDay_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBufDay.TextChanged

    End Sub

    Private Sub txtTstTim_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTstTim.KeyPress
        If Not ((Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8) Then
            e.KeyChar = Chr(0)
            MsgBox("Please input integer value.")
        End If
        If mode = "UPDATE" Then
            Recordstatus = True
        End If
    End Sub

    Private Sub chkDiCoTi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDiCoTi.CheckedChanged



    End Sub

    Private Sub chkDiCoTi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDiCoTi.Click
        If mode = "UPDATE" Then
            Recordstatus = True
        End If

        If chkDiCoTi.Checked = True Then
            resetcmdButton("DisableAll")
            freeze_TabControl(-1)
            chkDiCoTi.Enabled = True
            mmdSave.Enabled = True
            mmdClear.Enabled = True
            cboVenSts.SelectedIndex = 1

        ElseIf chkDiCoTi.Checked = False Then
            If cboVenType.Text = "External" Then
                Me.BaseTabControl1.TabPages(0).Enabled = True
                Me.BaseTabControl1.TabPages(1).Enabled = True
                Me.BaseTabControl1.TabPages(2).Enabled = True
                Me.BaseTabControl1.TabPages(3).Enabled = True
                Me.BaseTabControl1.TabPages(4).Enabled = True
                Me.BaseTabControl1.TabPages(5).Enabled = True
            Else
                Me.BaseTabControl1.TabPages(0).Enabled = True
                Me.BaseTabControl1.TabPages(1).Enabled = True
                Me.BaseTabControl1.TabPages(2).Enabled = True
                Me.BaseTabControl1.TabPages(3).Enabled = True
                Me.BaseTabControl1.TabPages(4).Enabled = True
            End If

            cboVenSts.SelectedIndex = 0

            mode = "UPDATE"
            resetdisplay(mode)
            addCustomerGroup()
        End If
    End Sub

    Private Sub grdItmNat_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdItmNat.GotFocus
        Got_Focus_Grid = "ItmNat"
    End Sub

    Private Sub grdItmNat_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdItmNat.LostFocus

    End Sub

    Private Sub txtVenNam_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVenNam.LostFocus
        txtVenNam.Text = UCase(txtVenNam.Text)
    End Sub

    Private Sub txtVenNam_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVenNam.TextChanged


    End Sub

    Private Sub txtVenNam_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVenNam.KeyPress
        If mode = "UPDATE" Then
            Recordstatus = True
        End If
    End Sub

    Private Sub txtVenNam_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtVenNam.KeyUp
        If mode = "UPDATE" Then
            Recordstatus = True
        End If
    End Sub

    Private Sub txtVenChnNam_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVenChnNam.KeyPress
        If mode = "UPDATE" Then
            Recordstatus = True
        End If
    End Sub

    Private Sub txtVenChnNam_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtVenChnNam.KeyUp
        If mode = "UPDATE" Then
            Recordstatus = True
        End If
    End Sub

    Private Sub chkfty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkfty.Click
        If mode = "UPDATE" Then
            Recordstatus = True
        End If
    End Sub

    Private Sub txtVenSna_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVenSna.KeyPress
        If mode = "UPDATE" Then
            Recordstatus = True
        End If
    End Sub

    Private Sub txtVenSna_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtVenSna.KeyUp
        If mode = "UPDATE" Then
            Recordstatus = True
        End If
    End Sub

    Private Sub txtVenSna_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVenSna.LostFocus
        txtVenSna.Text = UCase(txtVenSna.Text)
    End Sub

    Private Sub ChkMOQChg_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkMOQChg.Click
        If mode = "UPDATE" Then
            Recordstatus = True
        End If
    End Sub

    Private Sub cboVenRat_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboVenRat.Validating
        Dim tmpstr As String
        tmpstr = cboVenRat.Text

        If cboVenRat.Items.IndexOf(tmpstr) = -1 Then
            'MsgBox("Invalid Vendor Rating!")
            cboVenRat.Text = ""
        End If
    End Sub

    Private Sub cboPrcTrm_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPrcTrm.KeyUp
        auto_search_combo(cboPrcTrm, e.KeyCode)
    End Sub

    Private Sub cboPrcTrm_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboPrcTrm.Validating
        Dim tmpstr As String
        tmpstr = cboPrcTrm.Text

        If cboPrcTrm.Items.IndexOf(tmpstr) = -1 Then
            MsgBox("Invalid Price Terms!")
            e.Cancel = True
        End If
    End Sub

    Private Sub cboPayTrm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPayTrm.SelectedIndexChanged


        If mode = "UPDATE" Then
            If rs_VNBASINF_READ.Tables("RESULT").Rows.Count = 1 Then
                If cboPayTrm.Text <> "" Then

                    Dim dv As String
                    dv = Split(cboPayTrm.Text, " - ")(0)
                    If dv <> rs_VNBASINF_READ.Tables("RESULT").Rows(0).Item("vbi_paytrm") Then
                        Recordstatus = True

                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cboPayTrm_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPayTrm.KeyUp
        auto_search_combo(cboPrcTrm, e.KeyCode)
    End Sub

    Private Sub cboPayTrm_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboPayTrm.Validating
        Dim tmpstr As String
        tmpstr = cboPayTrm.Text

        If Trim(tmpstr) = "" Then
            Exit Sub
        End If


        If cboPayTrm.Items.IndexOf(tmpstr) = -1 Then
            MsgBox("Invalid Payment Term!")
            e.Cancel = True
        End If
    End Sub

    Private Sub cboCurCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCurCde.SelectedIndexChanged

        If mode = "UPDATE" Then
            If rs_VNBASINF_READ.Tables("RESULT").Rows.Count = 1 Then
                If cboCurCde.Text <> "" Then

                    Dim dv As String
                    dv = Split(cboCurCde.Text, " - ")(0)
                    If dv <> rs_VNBASINF_READ.Tables("RESULT").Rows(0).Item("vbi_curcde") Then
                        Recordstatus = True

                    End If
                End If
            End If
        End If
    End Sub
    Private Sub addCustomerGroup()


        If rs_VNCUGREL_READ.Tables("RESULT").Rows.Count <> 0 Then
            Exit Sub
        End If

        Dim i As Integer
        For i = 0 To 2
            rs_VNCUGREL_READ.Tables("RESULT").Rows.Add()
            rs_VNCUGREL_READ.Tables("RESULT").Rows(i).Item("vcr_creusr") = "~*ADD*~"
            rs_VNCUGREL_READ.Tables("RESULT").Rows(i).Item("vcr_venno") = txtVenNo.Text
            rs_VNCUGREL_READ.Tables("RESULT").Rows(i).Item("vcr_cugrpcde") = i + 1
            rs_VNCUGREL_READ.Tables("RESULT").Rows(i).Item("vcr_flg_ext") = "N"
            rs_VNCUGREL_READ.Tables("RESULT").Rows(i).Item("icf_mrkup") = 0
        Next i



        'rowcount = rs_CUMCOVEN.Tables("RESULT").Rows.Count
        'Dim dr() As DataRow = rs_CUMCOVEN.Tables("RESULT").Select("ccv_ventyp = ''")
        'If dr.Length = 0 Then
        '    rs_CUMCOVEN.Tables("RESULT").Rows.Add()
        '    rs_CUMCOVEN.Tables("RESULT").Rows(rowcount).Item("ccv_creusr") = "~*ADD*~"
        '    rs_CUMCOVEN.Tables("RESULT").Rows(rowcount).Item("ccv_cusno") = txtCusno.Text
        '    rs_CUMCOVEN.Tables("RESULT").Rows(rowcount).Item("ccv_cocde") = ""
        '    rs_CUMCOVEN.Tables("RESULT").Rows(rowcount).Item("ccv_ventyp") = ""
        '    rs_CUMCOVEN.Tables("RESULT").Rows(rowcount).Item("ccv_effdat") = Format(Date.Now, "yyyy-MM-dd")
        '    rs_CUMCOVEN.Tables("RESULT").Rows(rowcount).Item("ccv_del") = ""
        '    If rowcount = 0 Then
        '        rs_CUMCOVEN.Tables("RESULT").Rows(rowcount).Item("ccv_vendef") = "Y"
        '    Else
        '        rs_CUMCOVEN.Tables("RESULT").Rows(rowcount).Item("ccv_vendef") = "N"
        '    End If
        '    Recordstatus = True

        '    grdCoVen.CurrentCell = grdCoVen.Rows(rowcount).Cells(2)
        'End If





    End Sub

    Private Sub cboCurCde_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboCurCde.Validating
        Dim tmpstr As String
        tmpstr = cboCurCde.Text


        If Trim(tmpstr) = "" Then
            Exit Sub
        End If


        If cboCurCde.Items.IndexOf(tmpstr) = -1 Then
            MsgBox("Invalid Price Currency!")
            e.Cancel = True
        End If
    End Sub

    Private Sub cboCurCde_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCurCde.KeyUp
        auto_search_combo(cboCurCde, e.KeyCode)
    End Sub

    Private Sub txtDisCnt_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDisCnt.KeyUp
        If mode = "UPDATE" Then
            Recordstatus = True
        End If
    End Sub

    Private Sub txtLedTim_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLedTim.KeyUp
        If mode = "UPDATE" Then
            Recordstatus = True
        End If
    End Sub

    Private Sub txtTstTim_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTstTim.KeyUp
        If mode = "UPDATE" Then
            Recordstatus = True
        End If
    End Sub

    Private Sub txtBufDay_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBufDay.KeyUp
        If mode = "UPDATE" Then
            Recordstatus = True
        End If
    End Sub

    Private Sub txtRmk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRmk.GotFocus

        txtRmk.Height = txtRmk.Height + 50
    End Sub

    Private Sub txtRmk_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRmk.KeyPress
        If mode = "UPDATE" Then
            Recordstatus = True
        End If
    End Sub

    Private Sub txtRmk_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRmk.KeyUp
        If mode = "UPDATE" Then
            Recordstatus = True
        End If
    End Sub

    Private Sub txtAdr_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAdr.KeyPress
        If mode = "UPDATE" Then
            Recordstatus = True
        End If
    End Sub

    Private Sub txtAdr_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAdr.KeyUp
        If mode = "UPDATE" Then
            Recordstatus = True
        End If
    End Sub

    Private Sub txtChnAdr_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAdr2.KeyPress
        If mode = "UPDATE" Then
            Recordstatus = True
        End If
    End Sub

    Private Sub txtChnAdr_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAdr2.KeyUp
        If mode = "UPDATE" Then
            Recordstatus = True
        End If
    End Sub

    Private Sub txtStt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtStt.KeyPress
        If mode = "UPDATE" Then
            Recordstatus = True
        End If
    End Sub
    Private Sub txtCity_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCity.KeyPress
        If mode = "UPDATE" Then
            Recordstatus = True
        End If
    End Sub
    Private Sub txtTown_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTown.KeyPress
        If mode = "UPDATE" Then
            Recordstatus = True
        End If
    End Sub

    Private Sub txtStt_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtStt.KeyUp
        If mode = "UPDATE" Then
            Recordstatus = True
        End If
    End Sub
    Private Sub txtCity_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCity.KeyUp
        If mode = "UPDATE" Then
            Recordstatus = True
        End If
    End Sub
    Private Sub txtTown_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTown.KeyUp
        If mode = "UPDATE" Then
            Recordstatus = True
        End If
    End Sub

    Private Sub txtZip_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtZip.KeyPress
        If mode = "UPDATE" Then
            Recordstatus = True
        End If
    End Sub

    Private Sub txtZip_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtZip.KeyUp
        If mode = "UPDATE" Then
            Recordstatus = True
        End If
    End Sub

    Private Sub txtVenWeb_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVenWeb.KeyPress
        If mode = "UPDATE" Then
            Recordstatus = True
        End If
    End Sub

    Private Sub txtVenWeb_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtVenWeb.KeyUp
        If mode = "UPDATE" Then
            Recordstatus = True
        End If
    End Sub

    Private Sub cboCty_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCty.SelectedIndexChanged

        If mode = "UPDATE" Then
            If rs_VNCNTINF_M_READ.Tables("RESULT").Rows.Count = 1 Then
                If cboCty.Text <> "" Then

                    Dim dv As String
                    dv = cboCty.Text
                    If dv <> rs_VNCNTINF_M_READ.Tables("RESULT").Rows(0).Item("vci_cty") Then
                        Recordstatus = True

                    End If
                End If
            End If
        End If
        txtEngAdrDisplay.Text = display_address("E", cboCty.Text, txtStt.Text, txtCity.Text, txtTown.Text, txtAdr.Text, txtZip.Text)

    End Sub

    Private Sub cboCty_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboCty.Validating
        Dim tmpstr As String
        tmpstr = cboCty.Text

        If Trim(tmpstr) = "" Then
            Exit Sub
        End If

        If cboCty.Items.IndexOf(tmpstr) = -1 Then
            MsgBox("Invalid Country!")
            e.Cancel = True
        End If
    End Sub

    Private Sub cboCty_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCty.KeyUp
        auto_search_combo(cboCty, e.KeyCode)
    End Sub

    Private Sub cboItmNat_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboItmNat.KeyUp
        auto_search_combo(cboItmNat, e.KeyCode)
    End Sub

    Private Sub mmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdSearch.Click
        Dim frmSYM00018 As New SYM00018

        frmSYM00018.keyName = txtVenNo.Name
        frmSYM00018.strModule = "VN"

        frmSYM00018.show_frmSYM00018(Me)
    End Sub

    Private Sub txtAdr_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAdr.LostFocus
        txtAdr.Text = UCase(txtAdr.Text)
    End Sub


    Private Sub grdPrcTrm_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdPrcTrm.CellClick
        If mode <> "ADD" And mode <> "UPDATE" Then
            Exit Sub
        End If

        If grdPrcTrm.RowCount = 0 Then
            Exit Sub
        End If

        Select Case grdPrcTrm.CurrentCell.ColumnIndex
            Case grdPceTme_vpt_prctrm
                If grdPrcTrm.Item(grdPceTme_vpt_creusr, grdPrcTrm.CurrentCell.RowIndex).Value = "~*ADD*~" Then
                    PrcTrmRowIndex = grdPrcTrm.CurrentCell.RowIndex
                    comboBoxCell(grdPrcTrm, "PrcTrm")

                End If
        End Select




    End Sub

    Private Sub grdvengrp_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdvengrp.CellDoubleClick
        If mode = "ReadOnly" Then
            Exit Sub
        End If


        If grdvengrp.RowCount > 0 Then
            Dim iCol As Integer = grdvengrp.CurrentCell.ColumnIndex
            Dim iRow As Integer = grdvengrp.CurrentCell.RowIndex
            Dim curvalue As String
            curvalue = grdvengrp.CurrentCell.Value

            If grdvengrp.CurrentCell.ColumnIndex = grdvengrp_vcr_flg_ext Then
                If Trim(curvalue) = "N" Then

                    grdvengrp.Item(grdvengrp_vcr_flg_ext, iRow).Value = "Y"
                Else
                    grdvengrp.Item(grdvengrp_vcr_flg_ext, iRow).Value = "N"
                End If


            End If

            If grdvengrp.Item(grdvengrp_vcr_creusr, iRow).Value <> "~*ADD*~" Then
                grdvengrp.Item(grdvengrp_vcr_creusr, iRow).Value = "~*UPD*~"
                Recordstatus = True
            End If


        End If
    End Sub

    Private Sub grdPrcTrm_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdPrcTrm.CellDoubleClick
        If mode = "ReadOnly" Then
            Exit Sub
        End If

        If e.RowIndex = -1 Then
            Exit Sub
        End If

        If grdPrcTrm.RowCount > 0 Then
            Dim iCol As Integer = grdPrcTrm.CurrentCell.ColumnIndex
            Dim iRow As Integer = grdPrcTrm.CurrentCell.RowIndex
            Dim curvalue As String
            curvalue = grdPrcTrm.CurrentCell.Value

            If grdPrcTrm.CurrentCell.ColumnIndex = grdPceTme_vpt_prcdef And e.RowIndex >= 0 Then

                If grdPrcTrm.Item(grdPceTme_vpt_prcdef, grdPrcTrm.CurrentCell.RowIndex).Value = "Y" Then
                    Exit Sub
                End If

                If grdPrcTrm.Item(grdPceTme_vpt_cocde, grdPrcTrm.CurrentCell.RowIndex).Value = "Y" Then
                    MsgBox("Cannot set default which record will be deleted")
                    Exit Sub
                End If


                Dim default_vn As String
                default_vn = grdPrcTrm.Item(grdPceTme_vpt_prctrm, grdPrcTrm.CurrentCell.RowIndex).Value

                Dim tmp_vn As String

                Dim i As Integer
                For i = 0 To rs_VNPRCTRM_READ.Tables("RESULT").Rows.Count - 1
                    tmp_vn = rs_VNPRCTRM_READ.Tables("RESULT").Rows(i).Item("vpt_prctrm")

                    If default_vn = tmp_vn Then
                        If rs_VNPRCTRM_READ.Tables("RESULT").Rows(i).Item("vpt_creusr") <> "~*ADD*~" Then
                            rs_VNPRCTRM_READ.Tables("RESULT").Rows(i).Item("vpt_creusr") = "~*UPD*~"
                        End If
                        rs_VNPRCTRM_READ.Tables("RESULT").Rows(i).Item("vpt_prcdef") = "Y"
                        Recordstatus = True
                    ElseIf rs_VNPRCTRM_READ.Tables("RESULT").Rows(i).Item("vpt_prcdef") = "Y" Then
                        If rs_VNPRCTRM_READ.Tables("RESULT").Rows(i).Item("vpt_creusr") <> "~*ADD*~" Then
                            rs_VNPRCTRM_READ.Tables("RESULT").Rows(i).Item("vpt_creusr") = "~*UPD*~"
                        End If
                        rs_VNPRCTRM_READ.Tables("RESULT").Rows(i).Item("vpt_prcdef") = "N"
                        Recordstatus = True
                    End If

                Next i



            ElseIf grdPrcTrm.CurrentCell.ColumnIndex = grdPceTme_vpt_cocde And e.RowIndex >= 0 Then
                If grdPrcTrm.Rows(grdPrcTrm.CurrentCell.RowIndex).Cells("vpt_prctrm").Value.ToString = "" Then
                    MsgBox("Please select type")
                    Exit Sub
                End If

                Dim curvalue2 As String
                curvalue2 = grdPrcTrm.CurrentCell.Value.ToString
                If Trim(curvalue2) = "" Then


                    'If counter = 1 Then
                    '    MsgBox("At least one color must exist!")
                    '    Exit Sub
                    'Else

                    rs_VNPRCTRM_READ.Tables("RESULT").AcceptChanges()


                    If rs_VNPRCTRM_READ.Tables("RESULT").Rows.Count = 1 Then
                        MsgBox("Please change default to other record")
                        Exit Sub

                    ElseIf rs_VNPRCTRM_READ.Tables("RESULT").Rows.Count > 1 Then
                        If grdPrcTrm.Item(grdPceTme_vpt_prcdef, iRow).Value = "Y" Then
                            MsgBox("Please change default to other record")
                            Exit Sub
                        End If
                    End If
                    grdPrcTrm.Item(grdPceTme_vpt_cocde, iRow).Value = "Y"

                Else
                    grdPrcTrm.Item(grdPceTme_vpt_cocde, iRow).Value = ""


                End If
            End If




            If grdPrcTrm.Item(grdPceTme_vpt_creusr, iRow).Value <> "~*ADD*~" Then
                grdPrcTrm.Item(grdPceTme_vpt_creusr, iRow).Value = "~*UPD*~"
                Recordstatus = True
            End If


        End If
    End Sub

    Private Sub grdPrcTrm_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdPrcTrm.CellEndEdit


        rs_VNPRCTRM_READ.Tables("RESULT").AcceptChanges()




        Dim prctrm As String = Trim(grdPrcTrm.Item(grdPceTme_vpt_prctrm, PrcTrmRowIndex).Value.ToString)


        If prctrm <> "" Then
            Dim drr() As DataRow = rs_VNPRCTRM_READ.Tables("RESULT").Select("vpt_prctrm = '" & prctrm & "'")

            If drr.Length > 1 Then

                MsgBox("Duplicate Price Term!")
                grdPrcTrm.Item(grdPceTme_vpt_prctrm, PrcTrmRowIndex).Value = ""



            End If

        End If

        grdPrcTrm.Columns(grdPceTme_vpt_prctrm).ReadOnly = True

    End Sub



    Private Sub grdPrcTrm_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdPrcTrm.EditingControlShowing
        If grdPrcTrm.RowCount = 0 Then
            Exit Sub
        End If
        e.CellStyle.BackColor = Color.White

        Select Case grdPrcTrm.CurrentCell.ColumnIndex
            Case grdPceTme_vpt_prctrm
                If TypeOf (e.Control) Is DataGridViewComboBoxEditingControl Then
                    Dim cboBox As ComboBox = CType(e.Control, ComboBox)
                    If Not cboBox Is Nothing Then
                        'RemoveHandler cboBox.SelectedIndexChanged, AddressOf cbo_dgCostPrice_SelectedIndexChanged
                        'AddHandler cboBox.SelectedIndexChanged, AddressOf cbo_dgCostPrice_SelectedIndexChanged
                    End If
                End If
        End Select


        If mode = "UPDATE" Or mode = "ADD" Then
            Recordstatus = True
            If grdPrcTrm.Item(grdPceTme_vpt_creusr, grdPrcTrm.CurrentCell.RowIndex).Value <> "~*ADD*~" Then
                grdPrcTrm.Item(grdPceTme_vpt_creusr, grdPrcTrm.CurrentCell.RowIndex).Value = "~*UPD*~"
            End If
        End If
    End Sub

    Private Sub grdPceTme_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdPrcTrm.GotFocus
        lblprctrm.ForeColor = Color.DarkCyan
        Got_Focus_Grid = "VNPRCTRM"
    End Sub

    Private Sub grdPrcTrm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdPrcTrm.LostFocus
        lblprctrm.ForeColor = Color.Blue
    End Sub

    Private Sub grdVnCntPer_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles grdVnCntPer.DataError

    End Sub

    Private Sub grdVnCntPer_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdVnCntPer.CellValidated
        'Dim i As Integer
        'For i = 0 To rs_CUCNTINF_C.Tables("RESULT").Columns.Count - 1
        '    rs_CUCNTINF_C.Tables("RESULT").Columns(i).ReadOnly = False
        'Next i



        'If grdRelCus.CurrentCell.ColumnIndex = grdFactoryRel_vsv_ven2name Then
        '    If grdRelCus.Item(grdFactoryRel_vsv_creusr, grdFactoryRel.CurrentCell.RowIndex).Value = "~*ADD*~" Then
        'If grdRelCus.Rows(grdRelCus.CurrentCell.RowIndex).Cells("vsv_ven2name").Value.ToString <> "" Then
        Try
            If e.ColumnIndex = grdVnCntPer_vci_cnttyp Then
                Dim txtCell As New DataGridViewTextBoxCell
                grdVnCntPer.Rows(grdVnCntPer.CurrentCell.RowIndex).Cells("vci_cnttyp").Value = Split(grdVnCntPer.Rows(grdVnCntPer.CurrentCell.RowIndex).Cells("vci_cnttyp").Value, " - ")(0)

                changecnttyp_procedure()

                grdVnCntPer.Rows(grdVnCntPer.CurrentCell.RowIndex).Cells("vci_cnttyp") = txtCell
                Dim tmp_row As Integer = grdVnCntPer.CurrentCell.RowIndex
                Dim tmp_col As Integer = grdVnCntPer.CurrentCell.ColumnIndex
                grdVnCntPer.CurrentCell = Nothing
                grdVnCntPer.CurrentCell = grdVnCntPer(tmp_row, tmp_col)

            End If
        Catch 'ex As Exception
            'MsgBox(ex.Message)
        End Try


        'End If
        '    End If
        'End If
    End Sub

    Private Sub lstVen2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstVen2.DoubleClick
        lstVen2.Visible = False
        Dim cusno As String
        Dim cusnam As String
        cusno = Split(lstVen2.Text, " - ")(0)
        cusnam = Split(lstVen2.Text, " - ")(1)
        'If Me.cboFCurr.Text = "CNY" Then

        rs_VNSUBVN_V_READ.Tables("RESULT").Rows(lstrowindexVen2).Item("vsv_ven2cde") = cusno
        rs_VNSUBVN_V_READ.Tables("RESULT").Rows(lstrowindexVen2).Item("vsv_ven2name") = cusnam



        ' checkRelcus()

        'Else
        'rs_SHCHGDTL_CORE.Tables("RESULT").Rows(rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - 3).Item("VENDOR") = vennam
        'rs_SHCHGDTL_CORE.Tables("RESULT").Rows(rs_SHCHGDTL_CORE.Tables("RESULT").Rows.Count - 3).Item("VENCDE") = venno
        'End If

        'dsNewRow = rs_SHIPGDTL_CTNETD.Tables("RESULT").NewRow()
        'dsNewRow.Item("tmp_vbi_vensna") = vennam
        'dsNewRow.Item("tmp_vbi_venno") = venno
        'dsNewRow.Item("tmp_creusr") = "~*ADD*~"
        'dsNewRow.Item("tmp_mancbm") = 0

        'rs_SHIPGDTL_CTNETD.Tables("RESULT").Rows.Add(dsNewRow)
    End Sub

    Private Sub lstVen2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstVen2.SelectedIndexChanged

    End Sub

    Private Sub lstVen1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstVen1.DoubleClick
        lstVen1.Visible = False
        Dim cusno As String
        Dim cusnam As String
        cusno = Split(lstVen1.Text, " - ")(0)
        cusnam = Split(lstVen1.Text, " - ")(1)
        'If Me.cboFCurr.Text = "CNY" Then

        rs_VNSUBVN_F_READ.Tables("RESULT").Rows(lstrowindexVen1).Item("vsv_ven1cde") = cusno
        rs_VNSUBVN_F_READ.Tables("RESULT").Rows(lstrowindexVen1).Item("vsv_ven1name") = cusnam


    End Sub

    Private Sub txtThcAmt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtThcAmt.KeyPress
        If Not (e.KeyChar = vbBack Or e.KeyChar = ChrW(Keys.Delete) Or e.KeyChar = ChrW(Keys.Enter) Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txtVenChnNam_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVenChnNam.LostFocus
        txtVenChnNam.Text = UCase(txtVenChnNam.Text)
    End Sub

    Private Sub txtChnAdr_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAdr2.LostFocus
        txtAdr2.Text = UCase(txtAdr2.Text)
    End Sub

    Private Sub txtChnAdr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAdr2.TextChanged
        txtChnAdrDisplay.Text = display_address("C", cboCty2.Text, txtStt2.Text, txtCity2.Text, txtTown2.Text, txtAdr2.Text, "")
    End Sub

    Private Sub txtTranFlag_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim val As String
        val = UCase(e.KeyChar)


        If Asc(val) <> 89 And Asc(val) <> 78 And Asc(val) <> 8 Then
            e.KeyChar = Chr(0)
        End If

    End Sub

    Private Sub txtTranFlag_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If mode = "UPDATE" Then
            Recordstatus = True
        End If
    End Sub

    Private Sub cboTranFlag_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTranFlag.KeyUp
        auto_search_combo(cboCurCde, e.KeyCode)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTranFlag.SelectedIndexChanged



        If mode = "UPDATE" Then
            If rs_VNBASINF_READ.Tables("RESULT").Rows.Count = 1 Then
                If cboTranFlag.Text <> "" Then

                    Dim dv As String
                    dv = cboTranFlag.Text
                    If dv <> rs_VNBASINF_READ.Tables("RESULT").Rows(0).Item("vbi_ventranflg") Then
                        Recordstatus = True

                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cboThcCry_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboThcCry.KeyUp
        auto_search_combo(cboThcCry, e.KeyCode)
    End Sub

    Private Sub cboThcCry_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboThcCry.SelectedIndexChanged
        If mode = "UPDATE" Then
            If cboThcCry.Text <> "" Then
                Recordstatus = True
            End If
        End If
    End Sub

    Private Sub cboVndFlag_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVndFlag.KeyUp
        auto_search_combo(cboVndFlag, e.KeyCode)
    End Sub

    Private Sub cboVndFlag_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVndFlag.SelectedIndexChanged

        If mode = "UPDATE" Then
            If rs_VNBASINF_READ.Tables("RESULT").Rows.Count = 1 Then
                If cboVndFlag.Text <> "" Then

                    Dim dv As String
                    dv = Split(cboVndFlag.Text, " - ")(0)
                    If dv <> rs_VNBASINF_READ.Tables("RESULT").Rows(0).Item("vbi_venflag") Then
                        Recordstatus = True

                    End If
                End If
            End If
        End If



        Dim code As String = Split(cboVndFlag.Text)(0)


        If code = "D" Or code = "P" Then
            gspStr = "SP_SELECT_SYITMNAT_31 ''"
        Else
            gspStr = "sp_select_SYITMNAT ''"
        End If

        rtnLong = execute_SQLStatement(gspStr, rs_SYITMNAT_READ, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdFind_Click sp_select_SYITMNAT :" & rtnStr)
            Exit Sub
        End If


        Dim i As Integer
        Dim strList As String
        cboItmNat.Items.Clear()
        cboItmNat.Items.Add("< None >")
        If rs_SYITMNAT_READ.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_SYITMNAT_READ.Tables("RESULT").Rows.Count - 1
                strList = rs_SYITMNAT_READ.Tables("RESULT").Rows(i).Item("itmnat")
                If strList <> "" Then
                    cboItmNat.Items.Add(strList)

                End If
            Next i
        End If
        cboItmNat.SelectedIndex = 0


    End Sub

    Private Sub cboVndFlag_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboVndFlag.Validating
        Dim tmpstr As String
        tmpstr = cboVndFlag.Text


        If Trim(tmpstr) = "" Then
            Exit Sub
        End If


        If cboVndFlag.Items.IndexOf(tmpstr) = -1 Then
            MsgBox("Invalid Code!")
            e.Cancel = True
        End If
    End Sub

    Private Sub cboThcCry_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboThcCry.Validating
        Dim tmpstr As String
        tmpstr = cboThcCry.Text

        If cboThcCry.Items.IndexOf(tmpstr) = -1 Then
            MsgBox("Invalid Code!")
            e.Cancel = True
        End If
    End Sub

    Private Sub grdExcCus_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdExcCus.CellClick
        If mode <> "ADD" And mode <> "UPDATE" Then
            Exit Sub
        End If

        If grdExcCus.RowCount = 0 Then
            Exit Sub
        End If

        Select Case grdExcCus.CurrentCell.ColumnIndex


            Case grdExcCus_vec_cusno

                'Dim code As String = grdExcCus.Item(grdExcCus_vec_cusno, grdExcCus.CurrentCell.RowIndex).Value.ToString
                'If code <> "" Then
                '    grdExcCus.Item(grdExcCus_vec_cusno, grdExcCus.CurrentCell.RowIndex).Value = displayCusName(code)
                'End If
                If grdExcCus.Item(grdExcCus_vec_creusr, grdExcCus.CurrentCell.RowIndex).Value = "~*ADD*~" Then
                    comboBoxCell(grdExcCus, "Cus")
                End If


        End Select
    End Sub

    Private Function displayCusName(ByVal name As String) As String
        For i As Integer = 0 To rs_SYSALLCUS.Tables("RESULT").Rows.Count - 1
            If name = rs_SYSALLCUS.Tables("RESULT").Rows(i).Item("cbi_cusno") Then
                Return rs_SYSALLCUS.Tables("RESULT").Rows(i).Item("cbi_cusno") & " - " & rs_SYSALLCUS.Tables("RESULT").Rows(i).Item("cbi_cussna")
                Exit Function
            End If

        Next

        Return name
    End Function


    Private Sub grdExcCus_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdExcCus.CellDoubleClick
        If mode = "ReadOnly" Then
            Exit Sub
        End If


        If e.RowIndex = -1 Then
            Exit Sub
        End If

        If grdExcCus.RowCount > 0 Then
            Dim iCol As Integer = grdExcCus.CurrentCell.ColumnIndex
            Dim iRow As Integer = grdExcCus.CurrentCell.RowIndex
            Dim curvalue As String
            curvalue = grdExcCus.CurrentCell.Value

            If grdExcCus.CurrentCell.ColumnIndex = grdExcCus_vec_cocde Then
                If Trim(curvalue) = "" Then
                    'Dim i As Integer
                    'Dim counter As Integer
                    'counter = 0
                    'For i = 0 To grdVnCntInf.RowCount - 1
                    '    If Trim(grdVnCntInf.Item(grdVnCntInf_vci_status, i).Value) = "" Then
                    '        counter = counter + 1
                    '    End If
                    'Next i

                    'If counter = 1 Then
                    '    MsgBox("At least one color must exist!")
                    '    Exit Sub
                    'Else
                    grdExcCus.Item(grdExcCus_vec_cocde, iRow).Value = "Y"
                    'End If

                Else
                    grdExcCus.Item(grdExcCus_vec_cocde, iRow).Value = ""


                End If



                If grdExcCus.Item(grdExcCus_vec_creusr, iRow).Value <> "~*ADD*~" Then
                    grdExcCus.Item(grdExcCus_vec_creusr, iRow).Value = "~*UPD*~"
                    Recordstatus = True
                End If

            End If
        End If
    End Sub

    Private Sub grdExcCus_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdExcCus.CellEndEdit
        If grdExcCus.RowCount = 0 Then
            Exit Sub
        End If
        'do
        Dim strvalue As String = Trim(grdExcCus.Item(grdExcCus_vec_cusno, grdExcCus.CurrentCell.RowIndex).Value.ToString)

        Dim currentrow As Integer = grdExcCus.CurrentCell.RowIndex

        ' grdExcCus.Columns(grdAgent_cai_cusagt).ReadOnly = True




        rs_VNEXCCUS.Tables("RESULT").AcceptChanges()
        If strvalue <> "" Then
            Dim drr() As DataRow = rs_VNEXCCUS.Tables("RESULT").Select("vec_cusno = '" & strvalue & "'")

            If drr.Length > 1 Then

                MsgBox("Duplicate Customer Code")
                grdExcCus.Item(grdExcCus_vec_cusno, currentrow).Value = ""



            End If

        End If

        grdExcCus.Columns(grdExcCus_vec_cusno).ReadOnly = True

    End Sub


    Private Sub grdExcCus_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles grdExcCus.DataError

    End Sub

    Private Sub grdExcCus_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdExcCus.EditingControlShowing
        If grdExcCus.RowCount = 0 Then
            Exit Sub
        End If
        e.CellStyle.BackColor = Color.White

        Select Case grdExcCus.CurrentCell.ColumnIndex
            Case grdExcCus_vec_cusno
                If TypeOf (e.Control) Is DataGridViewComboBoxEditingControl Then
                    Dim cboBox As ComboBox = CType(e.Control, ComboBox)
                    If Not cboBox Is Nothing Then
                        'RemoveHandler cboBox.SelectedIndexChanged, AddressOf cbo_dgCostPrice_SelectedIndexChanged
                        'AddHandler cboBox.SelectedIndexChanged, AddressOf cbo_dgCostPrice_SelectedIndexChanged
                    End If
                End If

        End Select


        If mode = "UPDATE" Or mode = "ADD" Then
            Recordstatus = True
            If grdExcCus.Item(grdExcCus_vec_creusr, grdExcCus.CurrentCell.RowIndex).Value <> "~*ADD*~" Then
                grdExcCus.Item(grdExcCus_vec_creusr, grdExcCus.CurrentCell.RowIndex).Value = "~*UPD*~"
            End If
        End If
    End Sub

    Private Sub grdExcCus_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdExcCus.GotFocus
        lblExcCus.ForeColor = Color.DarkCyan
        Got_Focus_Grid = "VNEXCCUS"
    End Sub

    Private Sub grdExcCus_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdExcCus.LostFocus
        lblExcCus.ForeColor = Color.Blue
    End Sub

    Private Sub cboTranFlag_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboTranFlag.Validating
        Dim tmpstr As String
        tmpstr = cboTranFlag.Text


        If Trim(tmpstr) = "" Then
            Exit Sub
        End If


        If cboTranFlag.Items.IndexOf(tmpstr) = -1 Then
            MsgBox("Invalid Flag!")
            e.Cancel = True
        End If
    End Sub

    Private Sub txtRmk_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRmk.LostFocus
        txtRmk.Height = 114
    End Sub

    Private Sub grdVnCntInf_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles grdVnCntInf.DataError
        Try
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Function display_address(ByVal lang As String, ByVal cty As String, ByVal stt As String, ByVal city As String, ByVal town As String, ByVal adr As String, ByVal zip As String) As String
        If lang = "C" Then
            display_address = cty & stt & city & town & adr & zip
        ElseIf lang = "E" Then
            Dim ctyeng As String
            If cty <> "" Then
                ctyeng = Split(cty, " - ")(1).ToString.ToUpper
            Else
                ctyeng = ""
            End If

            display_address = IIf(adr = "", "", adr & ", ") & IIf(town = "", "", town & ", ") & IIf(city = "", "", city & ", ") & IIf(stt = "", "", stt & ", ") & IIf(cty = "", "", ctyeng) & IIf(zip = "", "", " " & zip)
        End If
        txtChnAdrDisplay.Enabled = True
        txtChnAdrDisplay.ReadOnly = True
        txtEngAdrDisplay.Enabled = True
        txtEngAdrDisplay.ReadOnly = True
    End Function

    Private Sub cboCty2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCty2.SelectedIndexChanged
        txtChnAdrDisplay.Text = display_address("C", cboCty2.Text, txtStt2.Text, txtCity2.Text, txtTown2.Text, txtAdr2.Text, txtZip2.Text)
    End Sub

    Private Sub txtZip2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtZip2.TextChanged
        txtChnAdrDisplay.Text = display_address("C", cboCty2.Text, txtStt2.Text, txtCity2.Text, txtTown2.Text, txtAdr2.Text, txtZip2.Text)
    End Sub

    Private Sub txtStt2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStt2.TextChanged
        txtChnAdrDisplay.Text = display_address("C", cboCty2.Text, txtStt2.Text, txtCity2.Text, txtTown2.Text, txtAdr2.Text, txtZip2.Text)
    End Sub

    Private Sub txtCity2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCity2.TextChanged
        txtChnAdrDisplay.Text = display_address("C", cboCty2.Text, txtStt2.Text, txtCity2.Text, txtTown2.Text, txtAdr2.Text, txtZip2.Text)
    End Sub

    Private Sub txtTown2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTown2.TextChanged
        txtChnAdrDisplay.Text = display_address("C", cboCty2.Text, txtStt2.Text, txtCity2.Text, txtTown2.Text, txtAdr2.Text, txtZip2.Text)
    End Sub


    Private Sub txtAdr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAdr.TextChanged
        txtEngAdrDisplay.Text = display_address("E", cboCty.Text, txtStt.Text, txtCity.Text, txtTown.Text, txtAdr.Text, txtZip.Text)
    End Sub


    Private Sub txtTown_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTown.TextChanged
        txtEngAdrDisplay.Text = display_address("E", cboCty.Text, txtStt.Text, txtCity.Text, txtTown.Text, txtAdr.Text, txtZip.Text)
    End Sub

    Private Sub txtCity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCity.TextChanged
        txtEngAdrDisplay.Text = display_address("E", cboCty.Text, txtStt.Text, txtCity.Text, txtTown.Text, txtAdr.Text, txtZip.Text)

    End Sub

    Private Sub txtStt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStt.TextChanged
        txtEngAdrDisplay.Text = display_address("E", cboCty.Text, txtStt.Text, txtCity.Text, txtTown.Text, txtAdr.Text, txtZip.Text)

    End Sub

    Private Sub txtZip_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtZip.TextChanged
        txtEngAdrDisplay.Text = display_address("E", cboCty.Text, txtStt.Text, txtCity.Text, txtTown.Text, txtAdr.Text, txtZip.Text)

    End Sub

    Private Sub cboCty2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCty2.TextChanged
        txtChnAdrDisplay.Text = display_address("C", cboCty2.Text, txtStt2.Text, txtCity2.Text, txtTown2.Text, txtAdr2.Text, txtZip2.Text)
    End Sub

    Private Sub grdvengrp_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdvengrp.CellEndEdit
        If mode = "ReadOnly" Then
            Exit Sub
        End If


        If grdvengrp.RowCount > 0 Then
            Dim iCol As Integer = grdvengrp.CurrentCell.ColumnIndex
            Dim iRow As Integer = grdvengrp.CurrentCell.RowIndex
            Dim curvalue As String
            curvalue = grdvengrp.CurrentCell.Value

            If grdvengrp.Item(grdvengrp_vcr_creusr, iRow).Value <> "~*ADD*~" Then
                grdvengrp.Item(grdvengrp_vcr_creusr, iRow).Value = "~*UPD*~"
                Recordstatus = True
            End If


        End If

    End Sub

    Private Sub grdvengrp_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdvengrp.CellValidating


        If grdvengrp.RowCount > 0 Then
            'Dim iCol As Integer = grdvengrp.CurrentCell.ColumnIndex
            'Dim iRow As Integer = grdvengrp.CurrentCell.RowIndex
            Dim curvalue As String
            'curvalue = grdvengrp.CurrentCell.Value

            curvalue = e.FormattedValue


            If Trim(curvalue) = "" Then
                Exit Sub
            End If

            If grdvengrp.CurrentCell.ColumnIndex = grdvengrp_icf_mrkup Then
                If Not IsNumeric(Trim(curvalue)) Then
                    MsgBox("Please input a numeric value for markup!")
                    grdvengrp.CurrentCell.Value = ""
                    e.Cancel = True
                    Exit Sub
                End If

                If CDbl(Trim(curvalue)) < 0 Then
                    MsgBox("Please input a valid value for markup!")
                    grdvengrp.CurrentCell.Value = ""
                    e.Cancel = True
                    Exit Sub
                End If

                If CDbl(Trim(curvalue)) > 2 Then
                    MsgBox("Please input a valid value for markup!")
                    grdvengrp.CurrentCell.Value = ""
                    e.Cancel = True
                    Exit Sub
                End If

            End If

        End If

    End Sub

    Private Sub grdvengrp_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles grdvengrp.DataError

        Try


        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdvengrp_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdvengrp.EditingControlShowing
        Dim txtbox_mku As TextBox = CType(e.Control, TextBox)
        AddHandler txtbox_mku.KeyPress, AddressOf cell_KeyDown

    End Sub

    Private Sub cell_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If Not (e.KeyChar = vbBack Or e.KeyChar = "." Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
            e.KeyChar = ""
        End If

    End Sub

End Class
