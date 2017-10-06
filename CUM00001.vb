Public Class CUM00001
    Dim FRecordstatus As Boolean
    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean
    Dim status As String
    Dim CUM00001_RECNO As Integer
    Dim tempstring As String
    Dim csc_seccus As String
    Dim cbi_cusnam As String
    Dim CellEdit As DataGridViewTextBoxEditingControl
    Dim csc_prmcus As String
    Dim DisPreEditCellRow As Integer
    Dim lstrowindex As Integer
    Dim DisPreEditCellCol As Integer

    Dim copyflag As Boolean

    Dim FlagDiscontinue As Boolean
    Dim rs_CUCALFML_Distinct As DataSet
    Dim tab1 As Boolean
    Dim tab2 As Boolean
    Dim tab3 As Boolean
    Dim tab4 As Boolean
    Dim tab5 As Boolean
    Dim tab6 As Boolean
    Dim tab7 As Boolean
    Dim tab8 As Boolean
    Dim tab9 As Boolean
    Dim tab10 As Boolean
    Dim cmdshipdoc As Boolean

    Dim DefaultDir As String
    Dim EditModeHdr As String
    Dim CanModify As Boolean
    Dim tmpcusno As String
    Dim Recordstatus As Boolean
    Dim Add_flag As Boolean
    Dim Current_TimeStamp As Long
    Dim PriCusCurr As String
    Dim save_ok As Boolean
    Dim tmp As String
    Dim IsUpdated As Boolean
    Dim Got_Focus_Grid As String
    Dim grd_action As String
    Dim currentShipmark As Integer

    Dim CusTyp As String
    Dim rs_CUPRCTRM As New DataSet
    Dim rs_CUBASINF_AddNo As New DataSet
    Dim rs_SYUSRPRF2 As New DataSet
    Dim rs_CUBASINF As New DataSet
    Dim rs_SYUSRRIGHT As New DataSet
    Dim rs_SYSALMGR As New DataSet
    Dim rs_SYUSRPRF_2 As New DataSet
    Dim rs_1 As New DataSet
    Dim rs_2 As New DataSet
    Dim rs_SYSALREP As New DataSet
    Dim rs_SYLNEFML As New DataSet
    Dim rs_CUPRCINF As New DataSet
    Dim rs_SYSALINF As New DataSet
    Dim rs_SYSETINF_02 As New DataSet
    Dim rs_SYSETINF_03 As New DataSet
    Dim rs_SYSETINF_04 As New DataSet
    Dim rs_SYSETINF_06 As New DataSet
    Dim rs_SYSETINF_08 As New DataSet
    Dim rs_SYSETINF_13 As New DataSet
    Dim rs_SYFMLINF As New DataSet
    Dim rs_CUSHPMRK As New DataSet
    Dim rs_CUCNTINF_M As New DataSet
    Dim rs_CUBOKSAL As New DataSet
    Dim rs_SYAGTINF As New DataSet
    Dim rs_SYSMPTRM As New DataSet
    Dim rs_CUMCOVEN As New DataSet
    Dim rs_SYSETINF_01 As New DataSet
    Dim rs_CUMCAMRK As New DataSet
    Dim rs_sycominf As New DataSet
    Dim rs_SYCATCDE As New DataSet
    Dim rs_SYSETINF_17 As New DataSet
    Dim rs_SYSETINF_18 As New DataSet
    Dim rs_CUBASINF_L As New DataSet
    Dim rs_CUVENINF As New DataSet
    Dim rs_CUAGTINF As New DataSet
    Dim rs_CUCNTINF_B As New DataSet
    Dim rs_CUCNTINF_S As New DataSet
    Dim rs_CUCNTINF_C As New DataSet
    Dim rs_CUSHPINF_B As New DataSet
    Dim rs_CUSHPINF_C As New DataSet
    Dim rs_CUSUBCUS_P As New DataSet
    Dim rs_CUBCR As New DataSet
    Dim rs_CUBCR_Alias As New DataSet
    Dim rs_CUCSTEMT As New DataSet
    Dim rs_CUCSTAMT As New DataSet
    Dim rs_CURETPRC As New DataSet
    Dim rs_CUELC As New DataSet
    Dim rs_CUELCDTL As New DataSet
    Dim rs_CUFLGRAT As New DataSet
    Dim rs_SYAGTINF_S As New DataSet
    Dim rs_CUCALFML As New DataSet
    Dim rs_CUSHPFML As New DataSet
    Dim rs_VNBASINF As New DataSet

    Dim bindSrc As New BindingSource

    Dim CustRepChange As Boolean = False
    Dim CustConfirmChange As Boolean = False


    Dim flag_grdCusBufSetup_keypress As Boolean

#Region " Datagrid Variable "
    Dim grdAgent_Status As Integer
    Dim grdAgent_cai_cocde As Integer
    Dim grdAgent_cai_cusno As Integer
    Dim grdAgent_cai_cusagt As Integer
    Dim grdAgent_cai_comrat As Integer
    Dim grdAgent_cai_cusdef As Integer
    Dim grdAgent_cai_creusr As Integer
    Dim grdAgent_cai_updusr As Integer
    Dim grdAgent_cai_credat As Integer
    Dim grdAgent_cai_upddat As Integer
    Dim grdAgent_cai_timstp As Integer

    Dim grdBilling_Status As Integer
    Dim grdBilling_cci_cntadr As Integer
    Dim grdBilling_cci_cntstt As Integer
    Dim grdBilling_cci_cntcty As Integer
    Dim grdBilling_cci_cntpst As Integer
    Dim grdBilling_cci_cntdef As Integer
    Dim grdBilling_cci_cntseq As Integer
    Dim grdBilling_cci_creusr As Integer
    Dim grdBilling_cci_updusr As Integer
    Dim grdBilling_cci_sapshcusno As Integer

    Dim grdShipping_Status As Integer
    Dim grdShipping_cci_cntadr As Integer
    Dim grdShipping_cci_cntstt As Integer
    Dim grdShipping_cci_cntcty As Integer
    Dim grdShipping_cci_cntpst As Integer
    Dim grdShipping_cci_cntdef As Integer
    Dim grdShipping_cci_cntseq As Integer
    Dim grdShipping_cci_creusr As Integer
    Dim grdShipping_cci_updusr As Integer
    Dim grdShipping_cci_sapshcusno As Integer

    Dim grdContact_Status As Integer
    Dim grdContact_cci_cnttyp As Integer
    Dim grdContact_cci_cntseq As Integer
    Dim grdContact_cci_cntctp As Integer
    Dim grdContact_cci_cnttil As Integer
    Dim grdContact_cci_cntphn As Integer
    Dim grdContact_cci_cntfax As Integer
    Dim grdContact_cci_cnteml As Integer
    Dim grdContact_cci_cntdef As Integer
    Dim grdContact_cci_creusr As Integer
    Dim grdContact_cci_updusr As Integer

    Dim grdBank_Status As Integer
    Dim grdBank_csi_csetyp As Integer
    Dim grdBank_csi_csenam As Integer
    Dim grdBank_csi_cseseq As Integer
    Dim grdBank_csi_cseadr As Integer
    Dim grdBank_csi_csestt As Integer
    Dim grdBank_csi_csecty As Integer
    Dim grdBank_csi_csepst As Integer
    Dim grdBank_csi_csectp As Integer
    Dim grdBank_csi_csetil As Integer
    Dim grdBank_csi_csephn As Integer
    Dim grdBank_csi_csefax As Integer
    Dim grdBank_csi_cseeml As Integer
    Dim grdBank_csi_csedef As Integer
    Dim grdBank_csi_creusr As Integer
    Dim grdBank_csi_updusr As Integer

    Dim grdCourier_Status As Integer
    Dim grdCourier_csi_csetyp As Integer
    Dim grdCourier_csi_cseseq As Integer
    Dim grdCourier_csi_csenam As Integer
    Dim grdCourier_csi_cseacc As Integer
    Dim grdCourier_csi_dsc As Integer
    Dim grdCourier_csi_cseadr As Integer
    Dim grdCourier_csi_csestt As Integer
    Dim grdCourier_csi_csecty As Integer
    Dim grdCourier_csi_csepst As Integer
    Dim grdCourier_csi_csectp As Integer
    Dim grdCourier_csi_csetil As Integer
    Dim grdCourier_csi_csephn As Integer
    Dim grdCourier_csi_csefax As Integer
    Dim grdCourier_csi_cseeml As Integer
    Dim grdCourier_csi_cseinr As Integer
    Dim grdCourier_csi_csedef As Integer
    Dim grdCourier_csi_creusr As Integer
    Dim grdCourier_csi_updusr As Integer

    Dim grdBooking_cbs_cocde As Integer
    Dim grdBooking_cbs_cusno As Integer
    Dim grdBooking_cbs_nocn1 As Integer
    Dim grdBooking_cbs_yymm As Integer
    Dim grdBooking_cbs_nocn2 As Integer
    Dim grdBooking_cbs_nocn3 As Integer
    Dim grdBooking_cbs_nocn4 As Integer
    Dim grdBooking_cbs_creusr As Integer
    Dim grdBooking_cbs_updusr As Integer
    Dim grdBooking_cbs_credat As Integer
    Dim grdBooking_cbs_upddat As Integer
    Dim grdBooking_cbs_timstp As Integer
    Dim grdBooking_cbs_nocn5 As Integer

    Dim grdCoVen_del As Integer
    Dim grdCoVen_ccv_cusno As Integer
    Dim grdCoVen_ccv_ventyp As Integer
    Dim grdCoVen_ccv_cocde As Integer
    Dim grdCoVen_yco_shtnam As Integer
    Dim grdCoVen_ccv_vendef As Integer
    Dim grdCoVen_ccv_effdat As Integer
    Dim grdCoVen_ccv_creus As Integer
    Dim grdCoVen_csc_cocde As Integer
    Dim grdCoVen_csc_seccus As Integer
    Dim grdCoVen_cbi_cusnam As Integer
    Dim grdCoVen_csc_cusrel As Integer
    Dim grdCoVen_csc_creusr As Integer
    Dim grdCoVen_csc_updusr As Integer
    Dim grdCoVen_csc_credat As Integer
    Dim grdCoVen_csc_upddat As Integer
    Dim grdCoVen_csc_timstp As Integer

    Dim grdItmCatMarkup_ocm_del As Integer
    Dim grdItmCatMarkup_ocm_cusno As Integer
    Dim grdItmCatMarkup_ocm_ventyp As Integer
    Dim grdItmCatMarkup_ocm_cat As Integer
    Dim grdItmCatMarkup_ocm_markup As Integer
    Dim grdItmCatMarkup_ocm_markupfml As Integer
    Dim grdItmCatMarkup_ocm_effdat As Integer
    Dim grdItmCatMarkup_ocm_creusr As Integer

    Dim grdRskCdt_cbc_del As Integer
    Dim grdRskCdt_cbc_cusno As Integer
    Dim grdRskCdt_cbc_cocde As Integer
    Dim grdRskCdt_cbc_curcde As Integer
    Dim grdRskCdt_cbc_rsklmt As Integer
    Dim grdRskCdt_cbc_rskuse As Integer
    Dim grdRskCdt_cbc_cdtlmt As Integer
    Dim grdRskCdt_cbc_cdtuse As Integer
    Dim grdRskCdt_cbc_creusr As Integer

    Dim grdRelCus_csc_cocde As Integer
    Dim grdRelCus_csc_seccus As Integer
    Dim grdRelCus_cbi_cusnam As Integer
    Dim grdRelCus_csc_cusrel As Integer
    Dim grdRelCus_csc_creusr As Integer
    Dim grdRelCus_csc_updusr As Integer
    Dim grdRelCus_csc_credat As Integer
    Dim grdRelCus_csc_upddat As Integer
    Dim grdRelCus_csc_timstp As Integer
    Dim grdRelCus_Status As Integer

    Dim grdPrctrm_cpt_cocde As Integer
    Dim grdPrctrm_cpt_cusno As Integer
    Dim grdPrctrm_cpt_prctrm As Integer
    Dim grdPrctrm_cpt_prcdef As Integer
    Dim grdPrctrm_cpt_creusr As Integer
    Dim grdPrctrm_cpt_updusr As Integer
    Dim grdPrctrm_cpt_credat As Integer
    Dim grdPrctrm_cpt_upddat As Integer
    Dim grdPrctrm_cpt_timstp As Integer

    Dim grdCusVen_Status As Integer
    Dim grdCusVen_cvi_cocde As Integer
    Dim grdCusVen_cvi_cusno As Integer
    Dim grdCusVen_cvi_assvid As Integer
    Dim grdCusVen_cvi_assdsc As Integer
    Dim grdcusven_cvi_creusr As Integer
    Dim grdcusven_cvi_updusr As Integer
    Dim grdCusVen_cvi_credat As Integer
    Dim grdCusVen_cvi_uppddat As Integer
    Dim grdcusven_cvi_timstp As Integer
    Dim grdCusVen_cvi_orgvid As Integer

    Dim grdCUCALFML_DEL As Integer
    Dim grdCUCALFML_ccf_cocde As Integer
    Dim grdCUCALFML_ccf_cus1no As Integer
    Dim grdCUCALFML_ccf_cus2no As Integer
    Dim grdCUCALFML_ccf_cat As Integer
    Dim grdCUCALFML_ccf_venno As Integer
    Dim grdCUCALFML_ccf_prctrm As Integer
    Dim grdCUCALFML_ccf_trantrm As Integer
    Dim grdCUCALFML_ccf_curcde As Integer
    Dim grdCUCALFML_ccf_cumu As Integer
    Dim grdCUCALFML_ccf_pm As Integer
    Dim grdCUCALFML_ccf_cush As Integer
    Dim grdCUCALFML_ccf_thccusper As Integer
    Dim grdCUCALFML_ccf_upsper As Integer
    Dim grdCUCALFML_ccf_labper As Integer
    Dim grdCUCALFML_ccf_faper As Integer
    Dim grdCUCALFML_ccf_cstbufper As Integer
    Dim grdCUCALFML_ccf_othper As Integer
    Dim grdCUCALFML_ccf_pliper As Integer
    Dim grdCUCALFML_ccf_dmdper As Integer
    Dim grdCUCALFML_ccf_rbtper As Integer
    Dim grdCUCALFML_ccf_pkgper As Integer
    Dim grdCUCALFML_ccf_comper As Integer
    Dim grdCUCALFML_ccf_icmper As Integer
    Dim grdCUCALFML_ccf_subttl As Integer
    Dim grdCUCALFML_ccf_creusr As Integer
    Dim grdCUCALFML_ccf_updusr As Integer
    Dim grdCUCALFML_ccf_credat As Integer
    Dim grdCUCALFML_ccf_upddat As Integer
    Dim grdCUCALFML_ccf_latest As Integer '
    Dim grdCUCALFML_ccf_effdat As Integer

    Dim grdCusBufSetup_DEL As Integer
    Dim grdCusBufSetup_csf_cocde As Integer
    Dim grdCusBufSetup_csf_cus1no As Integer
    Dim grdCusBufSetup_csf_cus2no As Integer
    Dim grdCusBufSetup_csf_venno As Integer
    Dim grdCusBufSetup_csf_shpstrbuf As Integer
    Dim grdCusBufSetup_csf_shpendbuf As Integer
    Dim grdCusBufSetup_csf_cancelbuf As Integer
    Dim grdCusBufSetup_csf_creusr As Integer
    Dim grdCusBufSetup_csf_updusr As Integer
    Dim grdCusBufSetup_csf_credat As Integer
    Dim grdCusBufSetup_csf_upddat As Integer
#End Region



    Private Sub CUM00001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Formstartup(Me.Name)
        AccessRight(Me.Name)
        Enq_right_local = Enq_right
        Del_right_local = Del_right
        CanModify = True

        txtCerDoc.MaxLength = 400

        DefaultDir = ShpMrk_pth
        clearAllDisplay(Me)
        setStatus("Init")

        gspStr = "sp_select_SYUSRPRF '','" & gsUsrID & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYUSRPRF2, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading CUM00001_Load sp_select_SYUSRPRF :" & rtnStr)
            Exit Sub
        End If

        If (gsUsrGrp = "CED-S" Or gsUsrGrp = "EDP-S" Or gsUsrGrp = "MSAL-A" Or gsUsrGrp = "MGT-S") Then
            chkDiscontinue.Visible = True
            'CmdDelete.Enabled = True
        Else
            chkDiscontinue.Visible = False
            'CmdDelete.Enabled = False
        End If

        txtCusno.Select()
    End Sub

    Private Sub setStatus(ByVal Mode As String)
        If Mode = "Init" Then

            optcbinvNo.Checked = True
            optcbinvyes.Checked = False

            optcbinvWarnNo.Checked = True
            optcbinvWarnYes.Checked = False

            Panel2.Visible = False
            cboEffDat.Visible = True
            txtEffDat.Visible = False
            chkEff.Checked = False
            cmdAddEffDat.Text = "Add Eff Date"

            Call SetInputBoxesStatus("DisableAll")

            mmdAdd.Enabled = Enq_right_local 'True
            mmdSave.Enabled = False
            mmdDelete.Enabled = False
            mmdCopy.Enabled = False
            mmdFind.Enabled = True
            mmdInsRow.Enabled = False
            mmdDelRow.Enabled = False
            mmdExit.Enabled = True
            mmdClear.Enabled = True
            mmdSearch.Enabled = True

            mmdPrint.Enabled = False
            mmdAttach.Enabled = False
            mmdFunction.Enabled = False
            mmdLink.Enabled = False

            cmdShpDocM.Enabled = False
 

            txtSAPSHCUSNOM.Enabled = False

            cmdAddEffDat.Enabled = False
            cmdEffdatExit.Enabled = False

            chkEff.Enabled = False
            Call ResetDefaultDisp()
            Call SetatusBar(Mode)

            Me.BaseTabControl1.SelectedIndex = 0
            '*** Enable key field(s) in header
            txtCusno.Text = tmpcusno
            txtCusno.Enabled = True

            '***Reset the flag
            Recordstatus = False

            'Add your codes here
            '--------------------------------------------
            'Lester Wu 2004/09/16
            'Set default value of MOA/MOQ charge checkbox
            Me.ChkMoaChg.Checked = False
            Me.ChkMoqChg.Checked = False
            lstCustomer.Visible = False

            'cboCUCALFMLKey.Visible = True
            cboPriCate.Visible = False
            cboPriPri.Visible = False
            cboPriVen.Visible = False
            cboPriTran.Visible = False
            cmdAddPri.Text = "Add"

        ElseIf Mode = "Updating" Then

            Call SetInputBoxesStatus("EnableAll")
            Panel2.Visible = False
            cboEffDat.Visible = True
            txtEffDat.Visible = False
            chkEff.Checked = False
            cmdAddEffDat.Text = "Add Eff Date"
            cmdAddEffDat.Enabled = Enq_right_local
            cmdEffdatExit.Enabled = False



            mmdAdd.Enabled = False
            mmdSave.Enabled = Enq_right_local 'True
            '*** Allan Unremark this function
            mmdDelete.Enabled = Del_right_local 'True
            'CmdDelete.Enabled = True
            mmdCopy.Enabled = Enq_right_local 'True
            mmdFind.Enabled = False
            mmdSearch.Enabled = False


            mmdInsRow.Enabled = Enq_right_local 'True
            mmdDelRow.Enabled = Enq_right_local 'True 'Del_right_local
            mmdExit.Enabled = True
            mmdClear.Enabled = True

            chkEff.Enabled = False
            If gsUsrGrp = "MSAL-A" Or gsUsrGrp = "SAL-ZS" Or gsUsrGrp = "SAL-ZE" Or gsUsrGrp = "SAL-ZG" Or gsUsrGrp = "SAL-ZP" Then
                '    cmdShpDocM.Enabled = True
                cmdShpDocM.Enabled = False
            Else
                cmdShpDocM.Enabled = False
            End If


            '*** Added by Tommy on 24 July 2002



            '***Reset the flag
            Recordstatus = False

            Call SetatusBar(Mode)

        ElseIf Mode = "Clear" Then


            Call ResetDefaultDisp()

            Call setStatus("Init")

            Call SetatusBar(Mode)

            Me.BaseTabControl1.SelectedIndex = 0
            txtCusno.Text = tmpcusno
            txtCusno.Focus()
            lstCustomer.Visible = False
            Panel1.Visible = False
            cboPriCate.Text = ""
            cboPriVen.Text = ""
            cboPriPri.Text = ""
            cboPriTran.Text = ""
            cmdEffdatExit.Enabled = False
            Got_Focus_Grid = ""
        ElseIf Mode = "Add" Then
            EditModeHdr = Mode

            Panel2.Visible = False
            cboEffDat.Visible = True
            txtEffDat.Visible = False
            chkEff.Checked = False
            cmdAddEffDat.Text = "Add Eff Date"
            cmdEffdatExit.Enabled = False

            Call SetInputBoxesStatus("EnableAll")

 

            mmdSave.Enabled = Enq_right_local 'True
            mmdDelete.Enabled = False
            mmdAdd.Enabled = False
            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdSearch.Enabled = False
            mmdInsRow.Enabled = Enq_right_local 'True
            mmdDelRow.Enabled = Enq_right_local 'True 'Del_right_local

            txtCusno.Enabled = False

            chkEff.Enabled = False
            cmdShpDocM.Enabled = False

            txtSAPSHCUSNOM.Enabled = False
            '*** Added by Tommy on 24 July 2002

            Call SetatusBar(Mode)

            'Add your codes here
            '--------------------------------------------
            'Lester Wu 2004/09/16
            'Set default value of MOA/MOQ charge checkbox
            Me.ChkMoaChg.Checked = False
            Me.ChkMoqChg.Checked = False
            '--------------------------------------------

        ElseIf Mode = "ShipDoc" Then

            'Call SetInputBoxesStatus("DisableAll")


            mmdAdd.Enabled = False
            mmdSave.Enabled = True
            mmdDelete.Enabled = False
            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdSearch.Enabled = False
            mmdInsRow.Enabled = True
            mmdDelRow.Enabled = True
            mmdExit.Enabled = True
            mmdClear.Enabled = True

            cmdShpDocM.Enabled = False


            Recordstatus = False

            Call SetatusBar(Mode)
        ElseIf Mode = "CopyCancel" Then


            mmdAdd.Enabled = False
            mmdSave.Enabled = Enq_right_local 'True
            '*** Allan Unremark this function
            mmdDelete.Enabled = Del_right_local 'True
            'CmdDelete.Enabled = True
            mmdCopy.Enabled = Enq_right_local 'True
            mmdFind.Enabled = False
            mmdSearch.Enabled = False
            mmdInsRow.Enabled = Enq_right_local 'True
            mmdDelRow.Enabled = Enq_right_local 'True 'Del_right_local
            mmdExit.Enabled = True
            mmdClear.Enabled = True


            If gsUsrGrp = "MSAL-A" Or gsUsrGrp = "SAL-ZS" Or gsUsrGrp = "SAL-ZE" Or gsUsrGrp = "SAL-ZG" Or gsUsrGrp = "SAL-ZP" Then
                'cmdShpDocM.Enabled = True
                cmdShpDocM.Enabled = False
            Else
                cmdShpDocM.Enabled = False
            End If
        End If
    End Sub

    Private Sub SetatusBar(ByVal Mode As String)
        If Mode = "Init" Then
            Me.StatusBar.Items("lblLeft").Text = "Init"
        ElseIf Mode = "Updating" Then
            Me.StatusBar.Items("lblLeft").Text = "Updating"
        ElseIf Mode = "Add" Then
            Me.StatusBar.Items("lblLeft").Text = "Add"
        End If

    End Sub
    Private Sub ResetDefaultDisp()
        cboEffDat.Items.Clear()
        cboPriCate.Items.Clear()
        cboPriVen.Items.Clear()
        cboPriPri.Items.Clear()
        cboPriTran.Items.Clear()
        Panel2.Visible = False
        '==== CUM00001, Main , TabNo 0 ====
        txtCusno.Text = ""
        txtCusnam.Text = ""
        txtCussna.Text = ""
        cboStatus.Items.Clear()

        'optTemp.checked = True

        optSecCus.Checked = False
        chkDiscontinue.Checked = False
        chkActivate.Checked = False

        '==== CUM00001_01, Basic, TabNo 1 ====
        cboSalRep.Items.Clear()
        txtSalMgt.Text = ""
        cboCusRat.Items.Clear()

        cboMrkReg.Items.Clear()
        cboMrkTyp.Items.Clear()
        txtRefNo.Text = ""
        chkAdvOrd.Checked = False
        'lblCusAli.Enabled = True                ' Add by Lewis
        txtCusAli.Enabled = False                ' Add by Lewis
        txtSalMgt.Enabled = False
        txtSalDiv.Enabled = False
        txtCusAli.Text = ""                     ' Add by Lewis
        txtRemark.Text = ""
        grdCusVen.DataSource = Nothing
        grdAgent.DataSource = Nothing
        grdCoVen.DataSource = Nothing



        'Label40.Visible = False

        '==== CUM00001_02, Address, TabNo 2 ====
        txtCusWeb.Text = ""
        cboCountry.Items.Clear()
        txtComAdr.Text = ""
        txtCusStt.Text = ""
        txtSAPSHCUSNOM.Text = ""
        txtZIP.Text = ""

        grdBilling.DataSource = Nothing
        grdShipping.DataSource = Nothing

        '==== CUM00001_03, Contact, TabNo 3 ====

        grdContact.DataSource = Nothing

        '==== CUM00001_04, Price, TabNo 4 ====

        optGrsMgn.Checked = True
        optMarkup.Checked = False
        txtgrsMgn.Text = ""
        cboPrcTrm.Items.Clear()
        cboPayTrm.Items.Clear()
        cboProTrm.Items.Clear()
        cboFrgTrm.Items.Clear()
        cboCurcde.Items.Clear()
        txtquplus.Text = ""
        txtquminus.Text = ""

        '*** Modified by Tommy on 23 July 2002
        'txtCurLmt.Text = "USD"
        'txtCurUse.Text = "USD"
        'txtCurLmt.Text = ""
        'txtCurUse.Text = ""
        ''*** Modified by Tommy on 23 July 2002

        'txtRskLmt.Text = "1"
        'txtRskUse.Text = "0"
        ''***** Add by Lewis on 16 Jul 2003*****
        'InRskCdtCurCde.Visible = False
        'InRskCdtCocde.Visible = False
        'grdrskcdtalias.Visible = False
        'chkrskcdtali.Enabled = False
        'lblWithAlias.Visible = False


        grdCusBufSetup.DataSource = Nothing


        '==== Price Detail, TabNo 5 ====
        grdCstEmt.DataSource = Nothing

        grdRetPrc.DataSource = Nothing

        grdELC.DataSource = Nothing

        grdELCDtl.DataSource = Nothing



        '==== CUM00001_05, Consigee, TabNo 6 ====
        grdBank.DataSource = Nothing


        grdCourier.DataSource = Nothing
        txtCusPOD.Text = ""
        txtCusFDE.Text = ""
        '==== CUM00001_06, Ship Mark / Documents, TabNo 7 ====
        chkDelete.Checked = False
        chkDelete.Enabled = False
        optMain.Checked = True
        txtShpMrk1.Text = ""
        txtShpMrk2.Text = ""
        txtShpMrk3.Text = ""
        txtShpMrk4.Text = ""
        'txtShpMrk(5).Text = ""
        txtShpMrk6.Text = ""
        txtShpMrk7.Text = ""
        'lblRecCount.Caption = ""
        txtCerDoc.Text = ""
        imgShpMrk.ImageLocation = Nothing


        '==== CUM00001_07, Bookins / Sales Summary, TabNo 8 ====
        grdBooking.DataSource = Nothing


        '==== CUM00001_08, Related Customer, TabNo 9 ====
        grdRelCus.DataSource = Nothing

        '==== CUM00001_09, Profile, TabNo 10 ====
        txtMemo.Text = ""


        flag_grdCusBufSetup_keypress = False

    End Sub
    Private Sub SetInputBoxesStatus(ByVal Mode As String)

        'Dim v

        ''*** (1) If Mode = "EnableAll", enable all controls
        If Mode = "EnableAll" Then
            Call enableAllDisplay(Me)

            '    If EditModeHdr = "ADD" Then
            '        CmdSave.Enabled = False
            '        CmdDelete.Enabled = False

            '    ElseIf EditModeHdr = "Updating" Then
            '        CmdAdd.Enabled = False
            '    End If

            '    If Not CanModify Then
            '        CmdAdd.Enabled = False
            '        CmdSave.Enabled = False
            '        CmdDelete.Enabled = False

            '        cmdInsRow.Enabled = False
            '        cmdDelRow.Enabled = False
            '    End If
            'Me.BaseTabControl1.TabPages(0).Enabled = True
            'Me.BaseTabControl1.TabPages(1).Enabled = True
            'Me.BaseTabControl1.TabPages(2).Enabled = True
            'Me.BaseTabControl1.TabPages(3).Enabled = True
            'Me.BaseTabControl1.TabPages(4).Enabled = True
            'Me.BaseTabControl1.TabPages(5).Enabled = True
            'Me.BaseTabControl1.TabPages(6).Enabled = True
            'Me.BaseTabControl1.TabPages(7).Enabled = True
            'Me.BaseTabControl1.TabPages(8).Enabled = True
            'Me.BaseTabControl1.TabPages(9).Enabled = True
            '    SSTabCus.TabEnabled(0) = True
            '    SSTabCus.TabEnabled(1) = True
            '    SSTabCus.TabEnabled(2) = True
            '    SSTabCus.TabEnabled(3) = True
            '    SSTabCus.TabEnabled(4) = True
            '    SSTabCus.TabEnabled(5) = True
            '    SSTabCus.TabEnabled(6) = True
            '    SSTabCus.TabEnabled(7) = True
            '    SSTabCus.TabEnabled(8) = True
            '    SSTabCus.TabEnabled(9) = True

            '    '*** (2) If Mode = "DisableAll", disable all controls
        ElseIf Mode = "DisableAll" Then
            Call clearAllDisplay(Me)
            Call freeze_TabControl(0)
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
                ElseIf TypeOf v Is RadioButton Then
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
                ElseIf TypeOf v Is PictureBox Then
                    v.Enabled = False

                End If
            End If
        Next v

    End Sub
    Private Sub enableAllDisplay(ByVal fv As Control)
        Me.BaseTabControl1.TabPages(0).Enabled = True
        Me.BaseTabControl1.TabPages(1).Enabled = True
        Me.BaseTabControl1.TabPages(2).Enabled = True
        Me.BaseTabControl1.TabPages(3).Enabled = True
        Me.BaseTabControl1.TabPages(4).Enabled = True
        Me.BaseTabControl1.TabPages(5).Enabled = True
        Me.BaseTabControl1.TabPages(6).Enabled = True
        Me.BaseTabControl1.TabPages(7).Enabled = True
        Me.BaseTabControl1.TabPages(8).Enabled = True
        Me.BaseTabControl1.TabPages(9).Enabled = True

        Dim v As Control
        For Each v In fv.Controls

            If TypeOf v Is BaseTabControl Then
                Dim btc As BaseTabControl
                btc = v
                Dim i As Integer
                For i = 0 To btc.TabPages.Count - 1
                    Call enableAllDisplay(btc.TabPages(i))
                Next i
            ElseIf TypeOf v Is GroupBox Then
                Call enableAllDisplay(v)
                v.Enabled = True
            Else
                If TypeOf v Is TextBox Or TypeOf v Is MaskedTextBox Or TypeOf v Is ComboBox Or TypeOf v Is RichTextBox Then

                    v.Enabled = True
                ElseIf TypeOf v Is RadioButton Then
                    v.Enabled = True
                ElseIf TypeOf v Is ListBox Then
                    Dim lb As ListBox
                    lb = v
                    lb.Items.Clear()
                    v.Enabled = True
                ElseIf TypeOf v Is CheckBox Then
                    Dim cb As CheckBox
                    cb = v
                    cb.Checked = False
                    v.Enabled = True
                ElseIf TypeOf v Is DataGridView Then
                    Dim dg As DataGridView
                    dg = v

                ElseIf TypeOf v Is PictureBox Then
                    v.Enabled = True

                End If
            End If
        Next v

    End Sub

    Private Sub txtCusFDE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCusFDE.GotFocus
        txtCusFDE.Top = 285
        txtCusFDE.Height = 120
    End Sub

    Private Sub txtCusFDE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCusFDE.KeyPress
        Recordstatus = True
    End Sub

    Private Sub txtCusFDE_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCusFDE.LostFocus
        txtCusFDE.Top = 344
        txtCusFDE.Height = 44
    End Sub

    Private Sub txtCusFDE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCusFDE.TextChanged

    End Sub
    Public Sub mmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdFind.Click
        'If checkFocus(Me) Then Exit Sub

        status = "Find"

        If (Trim(txtCusno.Text) = "") Then
            txtCusno.Focus()
            MsgBox("Please input value.")
            Exit Sub
        End If


        gspStr = "sp_select_CUBASINF '','" & txtCusno.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdFind_Click sp_select_CUBASINF :" & rtnStr)
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        If rs_CUBASINF.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("Customer Not Found")
            txtCusno.Focus()
            Me.Cursor = Cursors.Default
            Exit Sub
        Else
            gspStr = "sp_select_SYUSRRIGHT_Check '','" & gsUsrID & "','" & txtCusno.Text & "','CU'"
            rtnLong = execute_SQLStatement(gspStr, rs_SYUSRRIGHT, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cmdFind_Click sp_select_SYUSRRIGHT_Check :" & rtnStr)
                Me.Cursor = Cursors.Default

                Exit Sub
            End If

            If rs_SYUSRRIGHT.Tables("RESULT").Rows.Count = 0 Then
                Me.Cursor = Cursors.Default
                MsgBox("You have no right to access this Customer record")
                txtCusno.Focus()
                Exit Sub
            End If

            Add_flag = False
            Recordstatus = False

            Current_TimeStamp = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_timstp")
            setStatus("Updating") ''''

            func_ReadRecordset()

            Display()





            If Microsoft.VisualBasic.Left(cboStatus.Text, 1) = "I" And Enq_right_local = True _
            And gsUsrRank <= 4 Then
                chkActivate.Visible = True
                chkActivate.Enabled = True
                mmdSave.Enabled = True
            Else
                chkActivate.Visible = False
                chkActivate.Enabled = False
            End If


            'If Mid(gsUsrGrp, 1, 3) = "PKG" Then '20130418 BN
            '    Me.BaseTabControl1.TabPages(3).Enabled = False
            '    Me.BaseTabControl1.TabPages(4).Enabled = False
            'End If

            If Mid(gsUsrGrp, 1, 3) = "SAL" Then
                If Mid(gsUsrGrp, 1, 5) = "SAL-Z" And gsUsrGrp <> "SAL-ZS" Then
                    Me.BaseTabControl1.TabPages(4).Enabled = False
                Else
                    Me.BaseTabControl1.TabPages(4).Enabled = True
                End If
            ElseIf Mid(gsUsrGrp, 1, 3) = "CED" Or Mid(gsUsrGrp, 1, 3) = "EDP" Or Mid(gsUsrGrp, 1, 3) = "MGT" Or Mid(gsUsrGrp, 1, 3) = "MIS" Then
                Me.BaseTabControl1.TabPages(4).Enabled = True
            Else
                Me.BaseTabControl1.TabPages(4).Enabled = False
            End If




            If rs_CUSHPMRK.Tables("RESULT").Rows.Count > 0 Then
                cmdFindMark.Enabled = True
            Else
                cmdFindMark.Enabled = False
            End If

            If gsUsrGrp = "CED-S" Or gsUsrGrp = "EDP-S" Or gsUsrGrp = "MSAL-A" Or gsUsrRank = 1 Then
                Me.BaseTabControl1.TabPages(7).Enabled = True
                grdBooking.Visible = True
            Else
                Me.BaseTabControl1.TabPages(7).Enabled = False
                grdBooking.Visible = False
            End If

        End If

        Me.BaseTabControl1.SelectedIndex = 0
        Me.Cursor = Cursors.Default
        Call SetgrdCoVen()





    End Sub


    Public Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        status = "Find"

        If (Trim(txtCusno.Text) = "") Then
            txtCusno.Focus()
            MsgBox("Please input value.")
            Exit Sub
        End If


        gspStr = "sp_select_CUBASINF '','" & txtCusno.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdFind_Click sp_select_CUBASINF :" & rtnStr)
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        If rs_CUBASINF.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("Customer Not Found")
            txtCusno.Focus()
            Me.Cursor = Cursors.Default
            Exit Sub
        Else
            gspStr = "sp_select_SYUSRRIGHT_Check '','" & gsUsrID & "','" & txtCusno.Text & "','CU'"
            rtnLong = execute_SQLStatement(gspStr, rs_SYUSRRIGHT, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cmdFind_Click sp_select_SYUSRRIGHT_Check :" & rtnStr)
                Me.Cursor = Cursors.Default

                Exit Sub
            End If

            If rs_SYUSRRIGHT.Tables("RESULT").Rows.Count = 0 Then
                Me.Cursor = Cursors.Default
                MsgBox("You have no right to access this Customer record")
                txtCusno.Focus()
                Exit Sub
            End If

            Add_flag = False
            Recordstatus = False

            Current_TimeStamp = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_timstp")
            setStatus("Updating") ''''

            func_ReadRecordset()

            Display()

            If rs_CUSHPMRK.Tables("RESULT").Rows.Count <> 0 Then
                cmdShpMrkBack.Enabled = True
                cmdShpMrkNext.Enabled = True
            End If




            If Microsoft.VisualBasic.Left(cboStatus.Text, 1) = "I" And Enq_right_local = True _
            And gsUsrRank <= 4 Then
                chkActivate.Visible = True
                chkActivate.Enabled = True
                mmdSave.Enabled = True
            Else
                chkActivate.Visible = False
                chkActivate.Enabled = False
            End If


            'If Mid(gsUsrGrp, 1, 3) = "PKG" Then '20130418 BN
            '    Me.BaseTabControl1.TabPages(3).Enabled = False
            '    Me.BaseTabControl1.TabPages(4).Enabled = False
            'End If

            If Mid(gsUsrGrp, 1, 3) = "SAL" Then
                If Mid(gsUsrGrp, 1, 5) = "SAL-Z" And gsUsrGrp <> "SAL-ZS" Then
                    Me.BaseTabControl1.TabPages(4).Enabled = False
                Else
                    Me.BaseTabControl1.TabPages(4).Enabled = True
                End If
            ElseIf Mid(gsUsrGrp, 1, 3) = "CED" Or Mid(gsUsrGrp, 1, 3) = "EDP" Or Mid(gsUsrGrp, 1, 3) = "MGT" Or Mid(gsUsrGrp, 1, 3) = "MIS" Then
                Me.BaseTabControl1.TabPages(4).Enabled = True
            Else
                Me.BaseTabControl1.TabPages(4).Enabled = False
            End If




            If rs_CUSHPMRK.Tables("RESULT").Rows.Count > 0 Then
                cmdFindMark.Enabled = True
            Else
                cmdFindMark.Enabled = False
            End If

            If gsUsrGrp = "CED-S" Or gsUsrGrp = "EDP-S" Or gsUsrGrp = "MSAL-A" Or gsUsrRank = 1 Then
                Me.BaseTabControl1.TabPages(7).Enabled = True
                grdBooking.Visible = True
            Else
                Me.BaseTabControl1.TabPages(7).Enabled = False
                grdBooking.Visible = False
            End If

        End If

        Me.BaseTabControl1.SelectedIndex = 0
        Me.Cursor = Cursors.Default
        Call SetgrdCoVen()





    End Sub

    Private Function func_FillComboBox()


        Call func_AddControlContent(0, "Status")
        Call FillcboSalRep()
        Call FillcboMrkTyp()
        Call func_AddControlContent(1, "Rate")
        Call FillcboCountry()
        Call FillcboSalTem()
        'Call fillcboPrcTrm()
        Call fillcboPayTrm()
        Call FillcboProTrm()
        Call FillcboFrgTrm()
        Call FillcboCurcde()
        Call FillcboExtGrp()
        Call FillcboIntGrp()

        Call func_AddControlContent(4, "SmpPrdTrm")
        Call func_AddControlContent(4, "SmpFrgTrm")
        Call func_AddControlContent(5, "lstBnkTyp")
        Call FillcboMrkReg()

        Call fillcboPriCate()
        Call fillcboPriVen()
        Call fillcboPriPri()
        Call fillcboPriTran()
        Call fillcboRoudning()
    End Function

    Private Sub fillcboPriCate()
        cboPriCate.Items.Clear()
        cboPriCate.Items.Add("FLORAL FTY")
        cboPriCate.Items.Add("HD/AB1.1")
        cboPriCate.Items.Add("HD/SC1.2")
        cboPriCate.Items.Add("HD/SC1.4")
        cboPriCate.Items.Add("MAGICSILK")
        cboPriCate.Items.Add("STANDARD")
        cboPriCate.Items.Add("XMAS TREE")
    End Sub

    Private Sub fillcboPriVen()
        cboPriVen.Items.Clear()
        cboPriVen.Items.Add("EXT")
        cboPriVen.Items.Add("INT")
    End Sub


    Private Sub fillcboPriPri()

        Dim i As Integer
        Dim strList As String
        cboPriPri.Items.Clear()

        If rs_SYSETINF_03.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_SYSETINF_03.Tables("RESULT").Rows.Count - 1
                strList = rs_SYSETINF_03.Tables("RESULT").Rows(i).Item("ysi_cde") + " - " + rs_SYSETINF_03.Tables("RESULT").Rows(i).Item("ysi_dsc")
                If strList <> "" Then
                    cboPriPri.Items.Add(strList)
                End If
            Next


        End If

    End Sub

    Private Sub fillcboPriTran()
        cboPriTran.Items.Clear()
        cboPriTran.Items.Add("FCL")
        cboPriTran.Items.Add("LCL")

    End Sub

    Private Sub fillcboRoudning()
        cboRounding.Items.Clear()
        cboRounding.Items.Add("2")
        cboRounding.Items.Add("3")
        cboRounding.Items.Add("4")
    End Sub

    Private Sub FillcboMrkReg()
        Dim i As Integer
        Dim strList As String
        cboMrkReg.Items.Clear()

        If rs_SYSETINF_01.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_SYSETINF_01.Tables("RESULT").Rows.Count - 1
                strList = rs_SYSETINF_01.Tables("RESULT").Rows(i).Item("ysi_cde") + " - " + rs_SYSETINF_01.Tables("RESULT").Rows(i).Item("ysi_dsc")
                If strList <> "" Then
                    cboMrkReg.Items.Add(strList)
                End If
            Next


        End If
    End Sub

    Private Sub FillcboCurcde()
        Dim i As Integer
        Dim strList As String
        cboCurcde.Items.Clear()

        If rs_SYSETINF_06.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_SYSETINF_06.Tables("RESULT").Rows.Count - 1
                strList = rs_SYSETINF_06.Tables("RESULT").Rows(i).Item("ycu_curcde") + " - " + rs_SYSETINF_06.Tables("RESULT").Rows(i).Item("ycu_curnam")
                If strList <> "" Then
                    cboCurcde.Items.Add(strList)
                End If
            Next


        End If
    End Sub

    Private Sub FillcboIntGrp()
       
        cboIntGrp.Items.Clear()

        cboIntGrp.Items.Add("A - Group A")
        cboIntGrp.Items.Add("B - Group B")
        cboIntGrp.Items.Add("I - Group I")
 
    End Sub

    Private Sub FillcboExtGrp()

        cboExtGrp.Items.Clear()

        cboExtGrp.Items.Add("1 - Group 1")
        cboExtGrp.Items.Add("2 - Group 2")
        cboExtGrp.Items.Add("3 - Group 3")

    End Sub

    Private Sub FillcboFrgTrm()
        Dim i As Integer
        Dim strList As String
        cboFrgTrm.Items.Clear()

        If rs_SYSMPTRM.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_SYSMPTRM.Tables("RESULT").Rows.Count - 1
                strList = rs_SYSMPTRM.Tables("RESULT").Rows(i).Item("yst_trmcde") + " - " + rs_SYSMPTRM.Tables("RESULT").Rows(i).Item("yst_trmdsc")
                If strList <> "" Then
                    cboFrgTrm.Items.Add(strList)
                End If
            Next


        End If
    End Sub


    Private Sub FillcboProTrm()
        Dim i As Integer
        Dim strList As String
        cboProTrm.Items.Clear()

        If rs_SYSMPTRM.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_SYSMPTRM.Tables("RESULT").Rows.Count - 1
                strList = rs_SYSMPTRM.Tables("RESULT").Rows(i).Item("yst_trmcde") + " - " + rs_SYSMPTRM.Tables("RESULT").Rows(i).Item("yst_trmdsc")
                If strList <> "" Then
                    cboProTrm.Items.Add(strList)
                End If
            Next


        End If
    End Sub


    Private Sub fillcboPayTrm()
        Dim i As Integer
        Dim strList As String
        cboPayTrm.Items.Clear()

        If rs_SYSETINF_04.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_SYSETINF_04.Tables("RESULT").Rows.Count - 1
                strList = rs_SYSETINF_04.Tables("RESULT").Rows(i).Item("ysi_cde") + " - " + rs_SYSETINF_04.Tables("RESULT").Rows(i).Item("ysi_dsc")
                If strList <> "" Then
                    cboPayTrm.Items.Add(strList)
                End If
            Next


        End If
    End Sub


    Private Sub fillcboPrcTrm()
        Dim i As Integer
        Dim strList As String
        cboPrcTrm.Items.Clear()

        If rs_SYSETINF_03.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_SYSETINF_03.Tables("RESULT").Rows.Count - 1
                strList = rs_SYSETINF_03.Tables("RESULT").Rows(i).Item("ysi_cde") + " - " + rs_SYSETINF_03.Tables("RESULT").Rows(i).Item("ysi_dsc")
                If strList <> "" Then
                    cboPrcTrm.Items.Add(strList)
                End If
            Next


        End If
    End Sub



    Private Sub FillcboCountry()
        Dim i As Integer
        Dim strList As String
        cboCountry.Items.Clear()

        If rs_SYSETINF_02.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_SYSETINF_02.Tables("RESULT").Rows.Count - 1
                strList = rs_SYSETINF_02.Tables("RESULT").Rows(i).Item("ysi_cde") + " - " + rs_SYSETINF_02.Tables("RESULT").Rows(i).Item("ysi_dsc")
                If strList <> "" Then
                    cboCountry.Items.Add(strList)
                End If
            Next


        End If
    End Sub

    Private Sub FillcboMrkTyp()
        Dim i As Integer
        Dim strList As String
        cboMrkTyp.Items.Clear()

        If rs_SYSETINF_08.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_SYSETINF_08.Tables("RESULT").Rows.Count - 1
                strList = rs_SYSETINF_08.Tables("RESULT").Rows(i).Item("ysi_cde") + " - " + rs_SYSETINF_08.Tables("RESULT").Rows(i).Item("ysi_dsc")
                If strList <> "" Then
                    cboMrkTyp.Items.Add(strList)
                End If
            Next


        End If
    End Sub


    Private Sub FillcboSalRep()
        Dim i As Integer
        Dim strList As String
        cboSalRep.Items.Clear()
        If rs_SYUSRPRF_2.Tables("RESULT").Rows.Count > 0 Then
            ' Added by Marco at 20040110 requested by Anita for sorting in sales Team and Sales Rep Name 
            ' Change by BN 20130409
            'rs_SYSALREP.Tables("RESULT").DefaultView.Sort = "ysr_saltem, ysr_dsc"


            For i = 0 To rs_SYUSRPRF_2.Tables("RESULT").Rows.Count - 1
                strList = rs_SYUSRPRF_2.Tables("RESULT").Rows(i).Item("ssr_salrep") + " - " + rs_SYUSRPRF_2.Tables("RESULT").Rows(i).Item("yup_repnam")
                'cboSalRep.AddItem(Trim(rs_SYSALREP("ysr_dsc") + " (Team " + rs_SYSALREP("ysr_saltem") + " )" + " - " + rs_SYSALREP("ysr_code1")))
                If strList <> "" Then
                    cboSalRep.Items.Add(strList)
                End If
            Next i
        End If



    End Sub
    Private Sub FillcboSalTem()
        Dim i As Integer
        Dim strList As String
        cboSalTem.Items.Clear()
        If rs_SYSALINF.Tables("RESULT").Rows.Count > 0 Then
            ' Added by Marco at 20040110 requested by Anita for sorting in sales Team and Sales Rep Name



            For i = 0 To rs_SYSALINF.Tables("RESULT").Rows.Count - 1
                strList = rs_SYSALINF.Tables("RESULT").Rows(i).Item("ssi_saltem") & " - Team " & rs_SYSALINF.Tables("RESULT").Rows(i).Item("ssi_saltem")
                'cboSalRep.AddItem(Trim(rs_SYSALREP("ysr_dsc") + " (Team " + rs_SYSALREP("ysr_saltem") + " )" + " - " + rs_SYSALREP("ysr_code1")))
                If strList <> "" Then
                    cboSalTem.Items.Add(strList)
                End If
            Next i
        End If



    End Sub
    Private Sub func_updateCurCde() 'wtf
        Dim read As Integer
        For read = 0 To rs_CUBCR.Tables("RESULT").Columns.Count - 1
            rs_CUBCR.Tables("RESULT").Columns(read).ReadOnly = False
        Next

        For read = 0 To rs_CUCSTEMT.Tables("RESULT").Columns.Count - 1
            rs_CUCSTEMT.Tables("RESULT").Columns(read).ReadOnly = False
        Next

        For read = 0 To rs_CUCSTAMT.Tables("RESULT").Columns.Count - 1
            rs_CUCSTAMT.Tables("RESULT").Columns(read).ReadOnly = False
        Next


        If rs_CUBCR.Tables("RESULT").Rows.Count > 0 Then
            Dim i As Integer
            For i = 0 To rs_CUBCR.Tables("RESULT").Rows.Count - 1
                'If rs_CUBCR("cbc_creusr") = "~*ADD*~" Then
                rs_CUBCR.Tables("RESULT").Rows(i).Item("cbc_curcde") = Trim(Split(cboCurcde.Text, "-")(0))
                If cboStatus.Text = "A - Active" Then
                    rs_CUBCR.Tables("RESULT").Rows(i).Item("cbc_creusr") = "~*UPD*~"
                End If

                'End If

            Next
            '    End If

        End If

        If cboCurcde.Text <> "" And (status = "ADD" Or cboCurcde.Enabled = True) Then
            If rs_CUCSTEMT.Tables("RESULT").Rows.Count > 0 Then
                Dim i As Integer
                For i = 0 To rs_CUCSTEMT.Tables("RESULT").Rows.Count - 1
                    rs_CUCSTEMT.Tables("RESULT").Rows(i).Item("cce_curcde") = Trim(Split(cboCurcde.Text, "-")(0))
                    If rs_CUCSTEMT.Tables("RESULT").Rows(i).Item("cce_creusr") <> "~*NEW*~" And rs_CUCSTEMT.Tables("RESULT").Rows(i).Item("cce_creusr") <> "~*ADD*~" Then
                        rs_CUCSTEMT.Tables("RESULT").Rows(i).Item("cce_creusr") = "~*UPD*~"
                    End If

                Next

            End If

            If rs_CUCSTAMT.Tables("RESULT").Rows.Count > 0 Then
                Dim i As Integer
                For i = 0 To rs_CUCSTAMT.Tables("RESULT").Rows.Count - 1
                    rs_CUCSTAMT.Tables("RESULT").Rows(i).Item("cca_curcde") = Trim(Split(cboCurcde.Text, "-")(0))
                    If rs_CUCSTAMT.Tables("RESULT").Rows(i).Item("cca_creusr") <> "~*NEW*~" And rs_CUCSTAMT.Tables("RESULT").Rows(i).Item("cca_creusr") <> "~*ADD*~" Then
                        rs_CUCSTAMT.Tables("RESULT").Rows(i).Item("cca_creusr") = "~*UPD*~"
                    End If

                Next

            End If
        End If

    End Sub


    Private Function func_AddControlContent(ByVal TabNo As Integer, ByVal ControlName As String)

        '==== CUM00001_00, Customer Heading, TabNo 0 ====
        If TabNo = 0 And ControlName = "Status" Then
            cboStatus.Items.Add("A - Active")
            cboStatus.Items.Add("D - Discontinue")
            cboStatus.Items.Add("H - On Hold due to over limit")
            cboStatus.Items.Add("I - Inactive")
        End If

        '==== CUM00001_01, Basic, TabNo 1 ====
        If TabNo = 1 And ControlName = "Rate" Then
            cboCusRat.Items.Add("A+")
            cboCusRat.Items.Add("A")
            cboCusRat.Items.Add("A-")
            cboCusRat.Items.Add("B+")
            cboCusRat.Items.Add("B")
            cboCusRat.Items.Add("B-")
            cboCusRat.Items.Add("C+")
            cboCusRat.Items.Add("C")
            cboCusRat.Items.Add("C-")
            cboCusRat.Items.Add("D+")
            cboCusRat.Items.Add("D")
            cboCusRat.Items.Add("D-")
            cboCusRat.Items.Add("E")
            cboCusRat.Items.Add("NEW")
        End If

        '==== CUM00001_05, Shipment, TabNo 5 ====


    End Function
    Private Function func_DisableInactiveCustomer(ByVal fv As Control)
        Dim v As Control
        For Each v In FV.Controls

            If TypeOf v Is BaseTabControl Then
                Dim btc As BaseTabControl
                btc = v
                Dim i As Integer
                For i = 0 To btc.TabPages.Count - 1
                    Call func_DisableInactiveCustomer(btc.TabPages(i))
                Next i
            ElseIf TypeOf v Is GroupBox Then
                Call func_DisableInactiveCustomer(v)
                v.Enabled = False
            Else
                If TypeOf v Is TextBox Or TypeOf v Is MaskedTextBox Or TypeOf v Is ComboBox Or TypeOf v Is RichTextBox Then

                    v.Enabled = False
                ElseIf TypeOf v Is RadioButton Then
                    v.Enabled = False
                ElseIf TypeOf v Is ListBox Then
                    Dim lb As ListBox
                    
                    v.Enabled = False
                ElseIf TypeOf v Is CheckBox Then
                    Dim cb As CheckBox
                    
                    v.Enabled = False
                ElseIf TypeOf v Is DataGridView Then
                   

                ElseIf TypeOf v Is PictureBox Then
                    v.Enabled = False

                End If
            End If
        Next v


        cboSalRep.Enabled = True
        cboSalRep.Focus()
        txtSalMgt.Enabled = True
        'txtSalMgt.Locked = True


        mmdExit.Enabled = True
        mmdClear.Enabled = True
        mmdCopy.Enabled = True
        mmdDelete.Enabled = True
        mmdInsRow.Enabled = False
        mmdDelRow.Enabled = False
        mmdSave.Enabled = Enq_right_local 'True

        chkDiscontinue.Enabled = True
        Me.BaseTabControl1.SelectedIndex = 0
    End Function
    Public Sub DisplaySpecialCombo(ByVal val As String, ByVal combo As ComboBox)

        If val = "" Then
            combo.Text = val
            Exit Sub
        End If

        Dim i As Integer

        For i = 0 To combo.Items.Count - 1
            If val = Split(combo.Items(i), " - ")(1) Then
                combo.Text = combo.Items(i)
                Exit Sub
            End If
        Next i

        combo.Text = val
    End Sub
    Private Sub Display()
        If rs_CUBASINF Is Nothing Then
            Exit Sub
        End If

        If rs_CUBASINF.Tables("RESULT").Rows.Count = 0 Then
            Exit Sub
        End If

        Call func_FillComboBox()

        checkrightCucalfml()


        Me.StatusBar.Items("lblRight").Text = Convert.ToDateTime(rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_credat")).ToString("MM/dd/yyyy") & " " _
        & Convert.ToDateTime(rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_upddat")).ToString("MM/dd/yyyy") _
        & " " & rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_updusr")

        'tab 01

        txtCusno.Text = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cusno")
        txtCusnam.Text = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cusnam")
        txtCussna.Text = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cussna")
        txtCusno.Enabled = False

        If rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cussts") = "A" Then
            cboStatus.Text = "A - Active"
        ElseIf rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cussts") = "H" Then
            cboStatus.Text = "H - On Hold due to over limit"
        ElseIf rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cussts") = "I" Then
            cboStatus.Text = "I - Inactive"

            If gsUsrGrp = "CED-S" Or gsUsrGrp = "EDP-S" Or gsUsrGrp = "MSAL-A" Or gsUsrRank = 1 Then
                Call func_DisableInactiveCustomer(me)
            End If
        ElseIf rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cussts") = "D" Then
            cboStatus.Text = "D - Discontinue"
            mmdSave.Enabled = False
            mmdDelete.Enabled = False
        End If



        txtCerDoc.Text = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cerdoc")
        cboStatus.Enabled = False
        txtCerDoc.Text = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cerdoc")
        If rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_custyp") = "P" Then
            optPriCus.Checked = True
            optPriCus.Enabled = True
            optSecCus.Enabled = False
        ElseIf rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_custyp") = "S" Then
            optSecCus.Checked = True
            optPriCus.Enabled = False
            optSecCus.Enabled = True
        End If
        grdCoVen.Enabled = True

        Call display_combo(rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_srname"), cboSalRep) '

        txtSalMgt.Text = UCase(rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_salmgt"))

        txtSalDiv.Text = UCase(rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_SalDiv")) + " - Division " + UCase(rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_SalDiv"))


        Call display_combo(rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cusrat"), cboCusRat)

        Call display_combo(rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_mrktyp"), cboMrkTyp)

        Call display_combo(rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_saltem"), cboSalTem)

        Call display_combo(rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cugrptyp_int"), cboIntGrp)
        Call display_combo(rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cugrptyp_ext"), cboExtGrp)


        Call DisplaySpecialCombo(rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_mrkreg"), cboMrkReg)

        txtRefNo.Text = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_refno")
        txtCusPOD.Text = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cuspod") 'here
        txtCusFDE.Text = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cusfde")

        If rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cuscfs") = "Y" Then
            optCFSyes.Checked = True
        Else
            optCFSNo.Checked = True
        End If

        If rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_custhc") = "Y" Then
            optTHCYes.Checked = True
        Else
            optTHCNo.Checked = True
        End If

        'cbi_cuscfs = CFS
        'cbi_custhc = THC

        If rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_advord") = "Y" Then
            chkAdvOrd.Checked = True
        Else
            chkAdvOrd.Checked = False
        End If

        txtCusAli.Text = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cusali")
        txtRemark.Text = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_rmk")

        If (txtCusAli.Text = "") And (Microsoft.VisualBasic.Mid(txtCusno.Text, 1, 1) = 1 Or Microsoft.VisualBasic.Mid(txtCusno.Text, 1, 1) = 2 Or Microsoft.VisualBasic.Mid(txtCusno.Text, 1, 1) = 3 Or Mid(txtCusno.Text, 1, 1) = 4) Then
            txtCusAli.Enabled = True
        Else
            txtCusAli.Enabled = False
        End If

        If Not IsDBNull(rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cusweb")) = True Then
            txtCusWeb.Text = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cusweb")
        End If
        Dim CNTCDE As String
        Dim regcde As String
        If rs_CUCNTINF_M.Tables("RESULT").Rows.Count > 0 Then
            txtComAdr.Text = rs_CUCNTINF_M.Tables("RESULT").Rows(0).Item("cci_cntadr")
            txtCusStt.Text = rs_CUCNTINF_M.Tables("RESULT").Rows(0).Item("cci_cntstt")
            txtSAPSHCUSNOM.Text = rs_CUCNTINF_M.Tables("RESULT").Rows(0).Item("cci_sapshcusno")
            Call display_combo(rs_CUCNTINF_M.Tables("RESULT").Rows(0).Item("cci_cntcty"), cboCountry)
            txtZIP.Text = rs_CUCNTINF_M.Tables("RESULT").Rows(0).Item("cci_cntpst")
            CNTCDE = rs_CUCNTINF_M.Tables("RESULT").Rows(0).Item("cci_cntcty")

            Dim dr As DataRow() = rs_SYSETINF_02.Tables("RESULT").Select("ysi_cde = '" & CNTCDE & "'")
            If Not dr.Length = 0 Then
                regcde = rs_SYSETINF_02.Tables("RESULT").Rows(0).Item("ysi_value")

            End If

        End If

        If rs_CUPRCINF.Tables("RESULT").Rows.Count > 0 Then
            If rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_custyp") = "P" Then
                'If Microsoft.VisualBasic.Left(txtCusno.Text, 1) > 4 Or rs_CUAGTINF.Tables("RESULT").Rows(0).Item("cbi_credat") = "~*ADD*~" Then

                'End If
                optGrsMgn.Enabled = False
                optMarkup.Enabled = False
                txtgrsMgn.Text = ""
                txtgrsMgn.Enabled = False
            ElseIf rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_custyp") = "S" Then
                If Microsoft.VisualBasic.Left(txtCusno.Text, 1) > 4 Then

                Else

                End If
                grdItmCatMarkup.Enabled = False
                optGrsMgn.Enabled = True
                optMarkup.Enabled = True
                txtgrsMgn.Enabled = True
                tempstring = rs_CUPRCINF.Tables("RESULT").Rows(0).Item("cpi_grsmgn")
                txtgrsMgn.Text = Str(tempstring)
            End If
        End If
        If rs_CUPRCINF.Tables("RESULT").Rows.Count > 0 Then
            If optPriCus.Checked = True Then

            End If
            If rs_CUPRCINF.Tables("RESULT").Rows(0).Item("cpi_prcsec") = "GM" Then
                optGrsMgn.Checked = True
            Else
                optMarkup.Checked = True
            End If

            'Call display_combo(rs_CUPRCINF.Tables("RESULT").Rows(0).Item("cpi_prctrm"), cboPrcTrm)
            Call display_combo(rs_CUPRCINF.Tables("RESULT").Rows(0).Item("cpi_paytrm"), cboPayTrm)
            Call display_combo(rs_CUPRCINF.Tables("RESULT").Rows(0).Item("cpi_smpprd"), cboProTrm)
            Call display_combo(rs_CUPRCINF.Tables("RESULT").Rows(0).Item("cpi_smpfgt"), cboFrgTrm)
            Call display_combo(rs_CUPRCINF.Tables("RESULT").Rows(0).Item("cpi_curcde"), cboCurcde)
            Call display_combo(rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_rounding"), cboRounding)
            'tempstring = Str(rs_CUPRCINF.Tables("RESULT").Rows(0).Item("cpi_quplus"))
            ''txtquplus.Text = Str(tempstring)
            'tempstring = Str(rs_CUPRCINF.Tables("RESULT").Rows(0).Item("cpi_quminus"))
            'txtquminus.Text = Str(tempstring)
            Call func_updateCurCde()

            If rs_CUBCR.Tables("RESULT").Rows.Count > 0 Then
                'If Convert.ToInt32(rs_CUBCR_Alias.Tables("RESULT").Rows.Item("cbc_ali")) > 0 Then

                'End If
            End If

            If rs_CUPRCINF.Tables("RESULT").Rows(0).Item("cpi_moqchgflg") = "Y" Then
                ChkMoqChg.Checked = True
            Else
                ChkMoqChg.Checked = False
            End If
            If rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_custyp") = "S" Then
                ChkMoqChg.Enabled = False
            Else
                ChkMoqChg.Enabled = True
            End If

            If rs_CUPRCINF.Tables("RESULT").Rows(0).Item("cpi_moachgflg") = "Y" Then
                ChkMoaChg.Checked = True
            Else
                ChkMoaChg.Checked = False
            End If

            If rs_CUBOKSAL.Tables("RESULT").Rows.Count = 0 Then
                cboCurcde.Enabled = True
            Else
                cboCurcde.Enabled = False
            End If

            If rs_CUPRCINF.Tables("RESULT").Rows(0).Item("cpi_rsklmt") = "0" Then

            Else
            End If


        End If

        If IsDBNull(rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cuspro")) = False Then
            txtMemo.Text = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cuspro")
        End If

        Call func_SetGrid()

        If rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cussts") = "D" Then
            If gsUsrGrp = "CED-S" Or gsUsrGrp = "EDP-S" Or gsUsrGrp = "MSAL-A" Or gsUsrRank = 1 Then
                Call func_DisableInactiveCustomer(Me)
            End If
            chkDiscontinue.Checked = True
        End If

        Recordstatus = False
        txtSalMgt.Enabled = False
        txtSalDiv.Enabled = False


        Dim i As Integer
        Dim tmpstr As String

        cboCUCALFMLKey.Items.Clear()
        For i = 0 To rs_CUCALFML.Tables("RESULT").Rows.Count - 1
            If rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_latest") = "Y" Then
                tmpstr = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_cat") & " / " & _
                            rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_venno") & " / " & _
                            rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_prctrm") & " / " & _
                            rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_trantrm")
                cboCUCALFMLKey.Items.Add(tmpstr)
            End If
        Next i

        'Dim dv As DataView = rs_CUCALFML.Tables("RESULT").DefaultView
        'dv.RowFilter = "ccf_latest = '@#$%^&*('"

        'Call SetgrdCUCALFML(dv)

        cboEffDat.Visible = True
        txtEffDat.Visible = False
        chkEff.Checked = False




        'If cboCUCALFMLKey.Items.Count > 0 Then
        '    cboCUCALFMLKey.SelectedIndex = 0
        'End If





        cboEffDat.Items.Clear()
        For i = 0 To rs_CUCALFML_Distinct.Tables("RESULT").Rows.Count - 1
            If rs_CUCALFML_Distinct.Tables("RESULT").Rows(i).Item("ccf_effdat") <> "1900-01-01" Then
                cboEffDat.Items.Add(Format(rs_CUCALFML_Distinct.Tables("RESULT").Rows(i).Item("ccf_effdat"), "MM/dd/yyyy"))

            End If
        Next

        'Dim dr_CUCALFML() As DataRow
        'dr_CUCALFML = rs_CUCALFML.Tables("RESULT").Select("ccf_latest = 'Y'")
        'If dr_CUCALFML.Length <> 0 Then
        '    Dim latestdate As String
        '    latestdate = Format(dr_CUCALFML(0)("ccf_effdat"), "MM/dd/yyyy")
        '    cboEffDat.Text = latestdate
        'End If
        Dim dv_CUCALFML As DataView
        'dv_CUCALFML = rs_CUCALFML.Tables("RESULT").Select("ccf_effdat <= #" & DateTime.Now & "#")
        dv_CUCALFML = rs_CUCALFML.Tables("RESULT").DefaultView
        dv_CUCALFML.RowFilter = "ccf_effdat <= #" & DateTime.Now & "#"
        dv_CUCALFML.Sort = "ccf_effdat desc"
        If dv_CUCALFML.Count <> 0 Then
            Dim latestdate As String
            latestdate = Format(dv_CUCALFML(0)("ccf_effdat"), "MM/dd/yyyy")

            cboEffDat.Text = latestdate
        End If


        If rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cbinv") = "Y" Then
            optcbinvyes.Checked = True
            optcbinvNo.Checked = False
        Else
            optcbinvNo.Checked = True
            optcbinvyes.Checked = False
        End If

        If rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cbinvwarn") = "Y" Then
            optcbinvWarnYes.Checked = True
            optcbinvWarnNo.Checked = False
        Else
            optcbinvWarnNo.Checked = True
            optcbinvWarnYes.Checked = False
        End If

    End Sub


    Private Sub checkrightCucalfml()



        If gsUsrGrp = "CED-S" Or gsUsrGrp = "CED-R" Or gsUsrGrp = "CED-G" Or gsUsrGrp = "CED-G2" Or gsUsrGrp = "MIS-S" Or Mid(gsUsrGrp, 1, 3) = "EDP" Then

            cmdAddPri.Enabled = True
            cmdSavePri.Enabled = True
            cmdEffDate.Enabled = True
            cmdaddFormula.Enabled = False
            cmdEffdatSave.Enabled = True
            cmdEffdatExit.Enabled = False
            cboCUCALFMLKey.Enabled = True
            cboPriPri.Enabled = True
            cboPriVen.Enabled = True
            cboPriCate.Enabled = True
            cboPriTran.Enabled = True
            'cmdaddFormula.Enabled = True
            txtCustMU.ReadOnly = False
            txtPM.ReadOnly = False
            txtTHC.ReadOnly = False
            txtUPS.ReadOnly = False
            txtLab.ReadOnly = False
            txtFA.ReadOnly = False
            txtCostBuf.ReadOnly = False
            txtOthers.ReadOnly = False
            txtPLI.ReadOnly = False
            txtDefMD.ReadOnly = False
            txtRebate.ReadOnly = False
            txtCush.ReadOnly = False
            txtComm.ReadOnly = False
        Else
            cmdaddFormula.Enabled = False
            cmdAddPri.Enabled = False
            cmdSavePri.Enabled = False
            cmdEffDate.Enabled = False
            cmdEffdatSave.Enabled = False
            cmdEffdatExit.Enabled = False
            cboCUCALFMLKey.Enabled = True
            cboPriPri.Enabled = False
            cboPriVen.Enabled = False
            cboPriCate.Enabled = False
            cboPriTran.Enabled = False
            txtCustMU.ReadOnly = True
            txtPM.ReadOnly = True
            txtTHC.ReadOnly = True
            txtUPS.ReadOnly = True
            txtLab.ReadOnly = True
            txtFA.ReadOnly = True
            txtCostBuf.ReadOnly = True
            txtOthers.ReadOnly = True
            txtPLI.ReadOnly = True
            txtDefMD.ReadOnly = True
            txtRebate.ReadOnly = True
            txtCush.ReadOnly = True
            txtComm.ReadOnly = True
        End If
    End Sub

    Private Sub SetgrdCusBufSetup()
        If rs_CUSHPFML.Tables.Count = 0 Then
            Exit Sub
        End If


        grdCusBufSetup.DataSource = rs_CUSHPFML.Tables("RESULT").DefaultView


        grdCusBufSetup.RowHeadersWidth = 18
        grdCusBufSetup.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        grdCusBufSetup.ColumnHeadersHeight = 18
        grdCusBufSetup.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        grdCusBufSetup.AllowUserToResizeColumns = True
        grdCusBufSetup.AllowUserToResizeRows = False
        grdCusBufSetup.RowTemplate.Height = 18


        Dim i As Integer
        For i = 0 To rs_CUSHPFML.Tables("RESULT").Columns.Count - 1
            rs_CUSHPFML.Tables("RESULT").Columns(i).ReadOnly = False
        Next i

        i = 0
        grdCusBufSetup_DEL = i
        grdCusBufSetup.Columns(i).HeaderText = "Del"
        grdCusBufSetup.Columns(i).Width = 30
        i = i + 1
        grdCusBufSetup_csf_cocde = i
        grdCusBufSetup.Columns(i).Visible = False
        i = i + 1
        grdCusBufSetup_csf_cus1no = i
        grdCusBufSetup.Columns(i).Visible = False
        i = i + 1
        grdCusBufSetup_csf_cus2no = i
        grdCusBufSetup.Columns(i).Visible = False
        i = i + 1
        grdCusBufSetup_csf_venno = i
        grdCusBufSetup.Columns(i).HeaderText = "Vendor"
        grdCusBufSetup.Columns(i).ReadOnly = True
        grdCusBufSetup.Columns(i).Width = 150
        i = i + 1
        grdCusBufSetup_csf_shpstrbuf = i
        grdCusBufSetup.Columns(i).HeaderText = "Start Date"
        grdCusBufSetup.Columns(i).ReadOnly = False
        grdCusBufSetup.Columns(i).Width = 60
        i = i + 1
        grdCusBufSetup_csf_shpendbuf = i
        grdCusBufSetup.Columns(i).HeaderText = "End Date"
        grdCusBufSetup.Columns(i).ReadOnly = False
        grdCusBufSetup.Columns(i).Width = 60
        i = i + 1
        grdCusBufSetup_csf_cancelbuf = i
        grdCusBufSetup.Columns(i).HeaderText = "Cancel Date"
        grdCusBufSetup.Columns(i).ReadOnly = False
        grdCusBufSetup.Columns(i).Width = 60
        i = i + 1
        grdCusBufSetup_csf_creusr = i
        grdCusBufSetup.Columns(i).Visible = False
        i = i + 1
        grdCusBufSetup_csf_updusr = i
        grdCusBufSetup.Columns(i).Visible = False
        i = i + 1
        grdCusBufSetup_csf_credat = i
        grdCusBufSetup.Columns(i).Visible = False
        i = i + 1
        grdCusBufSetup_csf_upddat = i
        grdCusBufSetup.Columns(i).Visible = False

        Dim ii As Integer

        For ii = 0 To grdCusBufSetup.Columns.Count - 1
            grdCusBufSetup.Columns(ii).SortMode = DataGridViewColumnSortMode.NotSortable
        Next ii


    End Sub

    Private Sub SetGrdPrctrm()
        If rs_CUPRCTRM.Tables.Count = 0 Then
            Exit Sub
        End If


        grdPrctrm.DataSource = rs_CUPRCTRM.Tables("RESULT").DefaultView


        grdPrctrm.RowHeadersWidth = 18
        grdPrctrm.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        grdPrctrm.ColumnHeadersHeight = 18
        grdPrctrm.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        grdPrctrm.AllowUserToResizeColumns = True
        grdPrctrm.AllowUserToResizeRows = False
        grdPrctrm.RowTemplate.Height = 18


        Dim i As Integer

        'If mode = "UPDATE" Or mode = "ADD" Then
        For i = 0 To rs_CUPRCTRM.Tables("RESULT").Columns.Count - 1
            rs_CUPRCTRM.Tables("RESULT").Columns(i).ReadOnly = False
        Next i
        'End If
        i = 0
        grdPrctrm_cpt_cocde = i
        grdPrctrm.Columns(i).HeaderText = "Del"
        grdPrctrm.Columns(i).Width = 30
        i = i + 1
        grdPrctrm_cpt_cusno = i
        grdPrctrm.Columns(i).Visible = False
        i = i + 1
        grdPrctrm_cpt_prctrm = i
        grdPrctrm.Columns(i).HeaderText = "Price Terms"
        grdPrctrm.Columns(i).ReadOnly = True
        grdPrctrm.Columns(i).Width = 220
        i = i + 1
        grdPrctrm_cpt_prcdef = i
        grdPrctrm.Columns(i).HeaderText = "Default"
        grdPrctrm.Columns(i).ReadOnly = True
        grdPrctrm.Columns(i).Width = 50
        i = i + 1
        grdPrctrm_cpt_creusr = i
        grdPrctrm.Columns(i).Visible = False
        i = i + 1
        grdPrctrm_cpt_updusr = i
        grdPrctrm.Columns(i).Visible = False
        i = i + 1
        grdPrctrm_cpt_credat = i
        grdPrctrm.Columns(i).Visible = False
        i = i + 1
        grdPrctrm_cpt_upddat = i
        grdPrctrm.Columns(i).Visible = False
        i = i + 1
        grdPrctrm_cpt_timstp = i
        grdPrctrm.Columns(i).Visible = False


        Dim ii As Integer

        For ii = 0 To grdPrctrm.Columns.Count - 1

            grdPrctrm.Columns(ii).SortMode = DataGridViewColumnSortMode.NotSortable

        Next ii


    End Sub
    Private Sub SetGrdAgent()
        If rs_CUAGTINF.Tables.Count = 0 Then
            Exit Sub
        End If


        grdAgent.DataSource = rs_CUAGTINF.Tables("RESULT").DefaultView


        grdAgent.RowHeadersWidth = 18
        grdAgent.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        grdAgent.ColumnHeadersHeight = 18
        grdAgent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        grdAgent.AllowUserToResizeColumns = True
        grdAgent.AllowUserToResizeRows = False
        grdAgent.RowTemplate.Height = 18


        Dim i As Integer

        'If mode = "UPDATE" Or mode = "ADD" Then
        For i = 0 To rs_CUAGTINF.Tables("RESULT").Columns.Count - 1
            rs_CUAGTINF.Tables("RESULT").Columns(i).ReadOnly = False
        Next i
        'End If
        i = 0
        grdAgent_Status = i
        grdAgent.Columns(i).HeaderText = "Del"
        grdAgent.Columns(i).Width = 30
        grdAgent.Columns(i).ReadOnly = True
        i = i + 1
        grdAgent_cai_cocde = i
        grdAgent.Columns(i).Visible = False
        i = i + 1
        grdAgent.Columns(i).Visible = False
        grdAgent_cai_cusno = i
        i = i + 1
        grdAgent_cai_cusagt = i
        grdAgent.Columns(i).HeaderText = "Agent"
        grdAgent.Columns(i).Width = 140
        grdAgent.Columns(i).ReadOnly = True
        i = i + 1
        grdAgent_cai_comrat = i
        grdAgent.Columns(i).HeaderText = "Commission(%)"
        grdAgent.Columns(i).Width = 110
        grdAgent.Columns(i).ReadOnly = False
        CType(Me.grdAgent.Columns(i), DataGridViewTextBoxColumn).MaxInputLength = 3

        i = i + 1
        grdAgent_cai_cusdef = i
        grdAgent.Columns(i).HeaderText = "Default (Y/N)"
        grdAgent.Columns(i).Width = 70
        grdAgent.Columns(i).ReadOnly = True
        i = i + 1
        grdAgent_cai_creusr = i
        grdAgent.Columns(i).Visible = False
        i = i + 1
        grdAgent_cai_updusr = i
        grdAgent.Columns(i).Visible = False
        i = i + 1
        grdAgent_cai_credat = i
        grdAgent.Columns(i).Visible = False
        i = i + 1
        grdAgent_cai_upddat = i
        grdAgent.Columns(i).Visible = False
        i = i + 1
        grdAgent_cai_timstp = i
        grdAgent.Columns(i).Visible = False


        Dim ii As Integer

        For ii = 0 To grdAgent.Columns.Count - 1

            grdAgent.Columns(ii).SortMode = DataGridViewColumnSortMode.NotSortable

        Next ii


    End Sub
    Private Sub SetgrdCusVen()
        If rs_CUVENINF.Tables.Count = 0 Then
            Exit Sub
        End If


        grdCusVen.DataSource = rs_CUVENINF.Tables("RESULT").DefaultView


        grdCusVen.RowHeadersWidth = 18
        grdCusVen.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        grdCusVen.ColumnHeadersHeight = 18
        grdCusVen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        grdCusVen.AllowUserToResizeColumns = True
        grdCusVen.AllowUserToResizeRows = False
        grdCusVen.RowTemplate.Height = 18

        Dim i As Integer

        'If mode = "UPDATE" Or mode = "ADD" Then
        For i = 0 To rs_CUVENINF.Tables("RESULT").Columns.Count - 1
            rs_CUVENINF.Tables("RESULT").Columns(i).ReadOnly = False
        Next i
        'End If


        i = 0
        grdCusVen_Status = i
        grdCusVen.Columns(i).HeaderText = "Del"
        grdCusVen.Columns(i).Width = 30
        grdCusVen.Columns(i).ReadOnly = True
        i = i + 1
        grdCusVen_cvi_cocde = i
        grdCusVen.Columns(i).Visible = False
        i = i + 1
        grdCusVen.Columns(i).Visible = False
        grdCusVen_cvi_cusno = i
        i = i + 1
        grdCusVen_cvi_assvid = i
        grdCusVen.Columns(i).HeaderText = "Assigned Vendor ID"
        grdCusVen.Columns(i).Width = 150
        grdCusVen.Columns(i).ReadOnly = False
        i = i + 1
        grdCusVen_cvi_assdsc = i
        grdCusVen.Columns(i).HeaderText = "Description"
        grdCusVen.Columns(i).Width = 300
        grdCusVen.Columns(i).ReadOnly = False
        i = i + 1
        grdcusven_cvi_creusr = i
        grdCusVen.Columns(i).Visible = False
        i = i + 1
        grdcusven_cvi_updusr = i
        grdCusVen.Columns(i).Visible = False
        i = i + 1
        grdCusVen_cvi_credat = i
        grdCusVen.Columns(i).Visible = False
        i = i + 1
        grdCusVen_cvi_uppddat = i
        grdCusVen.Columns(i).Visible = False
        i = i + 1
        grdcusven_cvi_timstp = i
        grdCusVen.Columns(i).Visible = False
        i = i + 1
        grdCusVen_cvi_orgvid = i
        grdCusVen.Columns(i).Visible = False

        Dim ii As Integer

        For ii = 0 To grdCusVen.Columns.Count - 1

            grdCusVen.Columns(ii).SortMode = DataGridViewColumnSortMode.NotSortable

        Next ii

    End Sub
    Private Function func_SetGrid()
        Call SetgrdCusVen()
        Call SetGrdAgent()
        Call SetGrdBilling()
        Call Setgrdshipping()
        Call SetGrdContact()
        Call SetgrdBank()
        Call SetgrdCourier()
        Call SetgrdShipMark()
        Call func_ReadShipMarkRec()
        Call SetGrdPrctrm()
        Call SetgrdBooking()
        Call SetgrdCoVen()

        If Not Add_flag Then
            Call SetgrdRelCus()
        End If

        'Call setGrdItmCatMarkup()

        Call setgrdrskcdt()

        Call setgrdCusBufSetup()

        'Add for Price Detail Page 5
        'grdCstEmt.DataSource = rs_CUCSTEMT
        'Call SetgrdCstEmt()


        'grdRetPrc.DataSource = rs_CURETPRC
        'Call SetgrdRetPrc()

        'grdELC.DataSource = rs_CUELC
        'Call SetgrdELC()

        'grdELCDtl.DataSource = rs_CUELCDTL
        'Call SetgrdELCDtl()

        'grdFlgRat.DataSource = rs_CUFLGRAT
        'Call SetgrdFlgRat()




    End Function
    Private Sub setgrdrskcdt()

        If rs_CUBCR.Tables.Count = 0 Then
            Exit Sub
        End If

        grdRskCdt.DataSource = rs_CUBCR.Tables("RESULT").DefaultView




        'grdRskCdt.RowHeadersWidth = 18
        grdRskCdt.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        'grdRskCdt.ColumnHeadersHeight = 18
        grdRskCdt.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        grdRskCdt.AllowUserToResizeColumns = True
        grdRskCdt.AllowUserToResizeRows = False
        'grdRskCdt.RowTemplate.Height = 18

        Dim i As Integer

        'If mode = "UPDATE" Or mode = "ADD" Then
        For i = 0 To rs_CUBCR.Tables("RESULT").Columns.Count - 1
            rs_CUBCR.Tables("RESULT").Columns(i).ReadOnly = False
        Next i


        
        i = 0
        grdRskCdt_cbc_del = i
        grdRskCdt.Columns(i).HeaderText = "Del"
        grdRskCdt.Columns(i).Visible = False
        grdRskCdt.Columns(i).ReadOnly = True
        i = i + 1
        grdRskCdt_cbc_cusno = i
        grdRskCdt.Columns(i).Visible = False
        i = i + 1
        grdRskCdt_cbc_cocde = i
        grdRskCdt.Columns(i).Width = 60
        grdRskCdt.Columns(i).HeaderText = "Co. Code"
        grdRskCdt.Columns(i).ReadOnly = True
        i = i + 1
        grdRskCdt_cbc_curcde = i
        grdRskCdt.Columns(i).Visible = False
        grdRskCdt.Columns(i).HeaderText = "Cur Code"
        i = i + 1
        grdRskCdt_cbc_rsklmt = i
        grdRskCdt.Columns(i).Width = 100
        grdRskCdt.Columns(i).HeaderText = "Risk Limit"
        grdRskCdt.Columns(i).DefaultCellStyle.Format = "###,###,##0"
        CType(Me.grdRskCdt.Columns(i), DataGridViewTextBoxColumn).MaxInputLength = 9

        grdRskCdt.Columns(i).ReadOnly = False
        i = i + 1
        grdRskCdt_cbc_rskuse = i
        grdRskCdt.Columns(i).Width = 100
        grdRskCdt.Columns(i).HeaderText = "Risk Used"
        grdRskCdt.Columns(i).DefaultCellStyle.Format = "###,###,##0.00"
        grdRskCdt.Columns(i).ReadOnly = True
        i = i + 1
        grdRskCdt_cbc_cdtlmt = i
        grdRskCdt.Columns(i).Width = 100
        grdRskCdt.Columns(i).HeaderText = "Credit Limit"
        grdRskCdt.Columns(i).DefaultCellStyle.Format = "###,###,##0"
        grdRskCdt.Columns(i).ReadOnly = False
        CType(Me.grdRskCdt.Columns(i), DataGridViewTextBoxColumn).MaxInputLength = 9
        i = i + 1
        grdRskCdt_cbc_cdtuse = i
        grdRskCdt.Columns(i).Width = 100
        grdRskCdt.Columns(i).HeaderText = "Credit Used"
        grdRskCdt.Columns(i).DefaultCellStyle.Format = "###,###,##0.00"
        grdRskCdt.Columns(i).ReadOnly = True
        i = i + 1
        grdRskCdt_cbc_creusr = i
        grdRskCdt.Columns(i).Visible = False

        'Dim ii As Integer

        'For ii = 0 To grdRskCdt.Columns.Count - 1

        '    grdRskCdt.Columns(ii).SortMode = DataGridViewColumnSortMode.NotSortable

        'Next ii


    End Sub
    Private Sub setGrdItmCatMarkup()
        If rs_CUMCAMRK.Tables.Count = 0 Then
            Exit Sub
        End If

        grdItmCatMarkup.DataSource = rs_CUMCAMRK.Tables("RESULT").DefaultView

        grdItmCatMarkup.RowHeadersWidth = 18
        grdItmCatMarkup.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        grdItmCatMarkup.ColumnHeadersHeight = 18
        grdItmCatMarkup.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        grdItmCatMarkup.AllowUserToResizeColumns = True
        grdItmCatMarkup.AllowUserToResizeRows = False
        grdItmCatMarkup.RowTemplate.Height = 18

        Dim i As Integer

        'If mode = "UPDATE" Or mode = "ADD" Then
        For i = 0 To rs_CUMCAMRK.Tables("RESULT").Columns.Count - 1
            rs_CUMCAMRK.Tables("RESULT").Columns(i).ReadOnly = False
        Next i

        i = 0
        grdItmCatMarkup_ocm_del = i
        grdItmCatMarkup.Columns(i).HeaderText = "Del"
        grdItmCatMarkup.Columns(i).Width = 30
        grdItmCatMarkup.Columns(i).ReadOnly = True
        i = i + 1
        grdItmCatMarkup_ocm_cusno = i
        grdItmCatMarkup.Columns(i).Visible = False
        i = i + 1
        grdItmCatMarkup_ocm_ventyp = i
        grdItmCatMarkup.Columns(i).HeaderText = "Ven Type"
        grdItmCatMarkup.Columns(i).Width = 120
        i = i + 1
        grdItmCatMarkup_ocm_cat = i
        grdItmCatMarkup.Columns(i).HeaderText = "Category"
        grdItmCatMarkup.Columns(i).Width = 170
        i = i + 1
        grdItmCatMarkup_ocm_markup = i
        grdItmCatMarkup.Columns(i).Visible = False
        i = i + 1
        grdItmCatMarkup_ocm_markupfml = i
        grdItmCatMarkup.Columns(i).HeaderText = "Markup Formula"
        grdItmCatMarkup.Columns(i).Width = 180
        i = i + 1
        grdItmCatMarkup_ocm_effdat = i
        grdItmCatMarkup.Columns(i).HeaderText = "Effective Date"
        grdItmCatMarkup.Columns(i).Visible = False
        i = i + 1
        grdItmCatMarkup_ocm_creusr = i
        grdItmCatMarkup.Columns(i).Visible = False
        i = i + 1

        'Dim ii As Integer

        'For ii = 0 To grdItmCatMarkup.Columns.Count - 1

        '    grdItmCatMarkup.Columns(ii).SortMode = DataGridViewColumnSortMode.NotSortable

        'Next ii

    End Sub
    Private Sub SetgrdRelCus()
        If rs_CUSUBCUS_P.Tables.Count = 0 Then
            Exit Sub
        End If

        grdRelCus.DataSource = rs_CUSUBCUS_P.Tables("RESULT").DefaultView

        grdRelCus.RowHeadersWidth = 18
        grdRelCus.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        grdRelCus.ColumnHeadersHeight = 18
        grdRelCus.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        grdRelCus.AllowUserToResizeColumns = True
        grdRelCus.AllowUserToResizeRows = False
        grdRelCus.RowTemplate.Height = 18

        Dim i As Integer

        'If mode = "UPDATE" Or mode = "ADD" Then
        For i = 0 To rs_CUSUBCUS_P.Tables("RESULT").Columns.Count - 1
            rs_CUSUBCUS_P.Tables("RESULT").Columns(i).ReadOnly = False
        Next i

        i = 0
        grdRelCus_Status = i
        grdRelCus.Columns(i).HeaderText = "Del"
        grdRelCus.Columns(i).Width = 30
        grdRelCus.Columns(i).ReadOnly = True
        i = i + 1
        grdRelCus_csc_cocde = i
        grdRelCus.Columns(i).Visible = False
        i = i + 1
        grdRelCus_csc_seccus = i
        grdRelCus.Columns(i).HeaderText = "Related Customer Code"
        grdRelCus.Columns(i).Width = 120
        i = i + 1
        grdRelCus_cbi_cusnam = i
        grdRelCus.Columns(i).HeaderText = "Related Customer Name"
        grdRelCus.Columns(i).Width = 360
        i = i + 1
        grdRelCus_csc_cusrel = i
        grdRelCus.Columns(i).HeaderText = "Relation (Active / Passive)"
        grdRelCus.Columns(i).Width = 180
        i = i + 1
        grdRelCus_csc_creusr = i
        grdRelCus.Columns(i).Visible = False
        i = i + 1
        grdRelCus_csc_updusr = i
        grdRelCus.Columns(i).Visible = False
        i = i + 1
        grdRelCus_csc_credat = i
        grdRelCus.Columns(i).Visible = False
        i = i + 1
        grdRelCus_csc_upddat = i
        grdRelCus.Columns(i).Visible = False
        i = i + 1
        grdRelCus_csc_timstp = i
        grdRelCus.Columns(i).Visible = False


        grdRelCus.MultiSelect = False

        'Dim ii As Integer

        'For ii = 0 To grdRelCus.Columns.Count - 1

        '    grdRelCus.Columns(ii).SortMode = DataGridViewColumnSortMode.NotSortable

        'Next ii

    End Sub

    Private Function func_EnabledShpMrk()
        If rs_CUSHPMRK.Tables("RESULT").Rows.Count = 0 Then
            optMain.Enabled = False
            optSide.Enabled = False
            optInner.Enabled = False
            txtShpMrk1.Enabled = False
            txtShpMrk2.Enabled = False
            txtShpMrk3.Enabled = False
            txtShpMrk4.Enabled = False
            'txtShpMrk(5).Enabled = False
            txtShpMrk6.Enabled = False
            txtShpMrk7.Enabled = False
            cmdShpMrkBack.Enabled = False
            cmdShpMrkNext.Enabled = False
            cmdFindMark.Enabled = False
            cmdShowPic.Enabled = False
            chkDelete.Enabled = False

        Else
            optMain.Enabled = True
            optSide.Enabled = True
            optInner.Enabled = True
            txtShpMrk1.Enabled = True
            txtShpMrk2.Enabled = True
            txtShpMrk3.Enabled = True
            txtShpMrk4.Enabled = True
            'txtShpMrk(5).Enabled = True
            txtShpMrk6.Enabled = True
            txtShpMrk7.Enabled = True
            cmdShpMrkBack.Enabled = True
            cmdShpMrkNext.Enabled = True
            cmdFindMark.Enabled = True
            cmdShowPic.Enabled = True
            chkDelete.Enabled = True

        End If
    End Function

    Private Function func_ReadShipMarkRec()
        'On Error GoTo showimageErr


        If rs_CUSHPMRK.Tables("RESULT").Rows.Count > 0 Then ''need to change (hard code)''
            lblloading.Visible = True
            chkDelete.Enabled = True
            lblRecCount.Text = currentShipmark + 1 & "  /  " & rs_CUSHPMRK.Tables("RESULT").Rows.Count & "   Records"
            If Not Trim(rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_imgpth")) = "" Then
                'imgShpMrk.ImageLocation = l
                lblloading.Visible = False

            Else
                imgShpMrk.Image = Nothing
                lblloading.Visible = True
                lblloading.Text = "There's no picture of this Ship Mark"
            End If
            If rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_shptyp") = "M" Then
                optMain.Checked = True
            ElseIf rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_shptyp") = "S" Then
                optSide.Checked = True
            ElseIf rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_shptyp") = "I" Then
                optInner.Checked = True
            End If

            txtShpMrk1.Text = rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_engdsc")
            txtShpMrk2.Text = rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_chndsc")
            txtShpMrk4.Text = rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_chnrmk")
            txtShpMrk3.Text = rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_engrmk")
            txtShpMrk6.Text = rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_imgpth")
            txtShpMrk7.Text = rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_imgnam")
        Else
            Call func_EnabledShpMrk()

        End If





        'showimageErr:
        '        Select Case Err.Number
        '            Case 53, 75, 76, 94
        '                txtShpMrk6.Text = ""
        '                txtShpMrk7.Text = ""
        '                imgShpMrk.Image = Nothing
        '        End Select
    End Function
    Private Sub SetgrdShipMark()
        If rs_CUSHPMRK.Tables.Count = 0 Then
            Exit Sub
        End If


 

        Dim i As Integer

        'If mode = "UPDATE" Or mode = "ADD" Then
        For i = 0 To rs_CUSHPMRK.Tables("RESULT").Columns.Count - 1
            rs_CUSHPMRK.Tables("RESULT").Columns(i).ReadOnly = False
        Next i

        




    End Sub
    Private Sub SetgrdCoVen() 'do
        If rs_CUMCOVEN.Tables.Count = 0 Then
            Exit Sub
        End If

        grdCoVen.DataSource = rs_CUMCOVEN.Tables("RESULT").DefaultView

        grdCoVen.RowHeadersWidth = 18
        grdCoVen.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        grdCoVen.ColumnHeadersHeight = 18
        grdCoVen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        grdCoVen.AllowUserToResizeColumns = True
        grdCoVen.AllowUserToResizeRows = False
        grdCoVen.RowTemplate.Height = 18


        Dim i As Integer

        'If mode = "UPDATE" Or mode = "ADD" Then
        For i = 0 To rs_CUMCOVEN.Tables("RESULT").Columns.Count - 1
            rs_CUMCOVEN.Tables("RESULT").Columns(i).ReadOnly = False
        Next i

        i = 0
        grdCoVen_del = i
        grdCoVen.Columns(i).HeaderText = "Del"
        grdCoVen.Columns(i).Width = 30
        grdCoVen.Columns(i).ReadOnly = True
        i = i + 1
        grdCoVen_ccv_cusno = i
        grdCoVen.Columns(i).Visible = False
        i = i + 1
        grdCoVen_ccv_ventyp = i
        grdCoVen.Columns(i).HeaderText = "Ven Type"
        grdCoVen.Columns(i).Width = 60
        grdCoVen.Columns(i).ReadOnly = True
        i = i + 1
        grdCoVen_ccv_cocde = i
        grdCoVen.Columns(i).HeaderText = "Company"
        grdCoVen.Columns(i).Width = 80
        grdCoVen.Columns(i).ReadOnly = True
        i = i + 1
        grdCoVen_yco_shtnam = i
        grdCoVen.Columns(i).HeaderText = "Company Name"
        grdCoVen.Columns(i).Width = 180
        grdCoVen.Columns(i).ReadOnly = True
        i = i + 1
        grdCoVen_ccv_vendef = i
        grdCoVen.Columns(i).HeaderText = "Default"
        grdCoVen.Columns(i).Width = 60
        grdCoVen.Columns(i).ReadOnly = True
        i = i + 1
        grdCoVen_ccv_effdat = i
        grdCoVen.Columns(i).HeaderText = "Effective Date"
        grdCoVen.Columns(i).Visible = False
        i = i + 1
        grdCoVen_ccv_creus = i
        grdCoVen.Columns(i).Visible = False

        Dim ii As Integer

        For ii = 0 To grdCoVen.Columns.Count - 1

            grdCoVen.Columns(ii).SortMode = DataGridViewColumnSortMode.NotSortable

        Next ii




    End Sub


    Private Sub SetgrdBooking()
        If rs_CUBOKSAL.Tables.Count = 0 Then
            Exit Sub
        End If

        grdBooking.DataSource = rs_CUBOKSAL.Tables("RESULT").DefaultView

        grdBooking.RowHeadersWidth = 18
        grdBooking.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        grdBooking.ColumnHeadersHeight = 18
        grdBooking.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        grdBooking.AllowUserToResizeColumns = True
        grdBooking.AllowUserToResizeRows = False
        grdBooking.RowTemplate.Height = 18

        Dim i As Integer

        'If mode = "UPDATE" Or mode = "ADD" Then
        For i = 0 To rs_CUBOKSAL.Tables("RESULT").Columns.Count - 1
            rs_CUBOKSAL.Tables("RESULT").Columns(i).ReadOnly = False
        Next i



        i = 0
        grdBooking_cbs_cocde = i
        grdBooking.Columns(i).Visible = False
        i = i + 1
        grdBooking_cbs_cusno = i
        grdBooking.Columns(i).Visible = False
        i = i + 1
        grdBooking_cbs_nocn1 = i
        grdBooking.Columns(i).Visible = False
        i = i + 1
        grdBooking_cbs_yymm = i
        grdBooking.Columns(i).HeaderText = "Year/Month"
        grdBooking.Columns(i).Width = 75
        i = i + 1
        grdBooking_cbs_nocn2 = i

        grdBooking.Columns(i).HeaderText = "MTD Booking (USD)"
        grdBooking.Columns(i).Width = 140

        grdBooking.Columns(i).DefaultCellStyle.Format = "##,0"


        i = i + 1
        grdBooking_cbs_nocn3 = i

        grdBooking.Columns(i).HeaderText = "MTD Sales (USD)"
        grdBooking.Columns(i).Width = 120
        grdBooking.Columns(i).DefaultCellStyle.Format = "##,0"
        i = i + 1
        grdBooking_cbs_nocn4 = i

        grdBooking.Columns(i).HeaderText = "MTD Purchase (USD)"
        grdBooking.Columns(i).Width = 140
        grdBooking.Columns(i).DefaultCellStyle.Format = "##,0"
        i = i + 1
        grdBooking_cbs_creusr = i
        grdBooking.Columns(i).Visible = False
        i = i + 1
        grdBooking_cbs_updusr = i
        grdBooking.Columns(i).Visible = False
        i = i + 1
        grdBooking_cbs_credat = i
        grdBooking.Columns(i).Visible = False
        i = i + 1
        grdBooking_cbs_upddat = i
        grdBooking.Columns(i).Visible = False
        i = i + 1
        grdBooking_cbs_timstp = i
        grdBooking.Columns(i).Visible = False
        i = i + 1
        grdBooking_cbs_nocn5 = i

        grdBooking.Columns(i).HeaderText = "MTD Margin (%)"
        grdBooking.Columns(i).Width = 120
        grdBooking.Columns(i).DefaultCellStyle.Format = "C"

        'Dim ii As Integer

        'For ii = 0 To grdBooking.Columns.Count - 1

        '    grdBooking.Columns(ii).SortMode = DataGridViewColumnSortMode.NotSortable

        'Next ii


    End Sub


    Private Sub SetgrdCourier()
        If rs_CUSHPINF_C.Tables.Count = 0 Then
            Exit Sub
        End If

        grdCourier.DataSource = rs_CUSHPINF_C.Tables("RESULT").DefaultView

        grdCourier.RowHeadersWidth = 18
        grdCourier.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        grdCourier.ColumnHeadersHeight = 18
        grdCourier.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        grdCourier.AllowUserToResizeColumns = True
        grdCourier.AllowUserToResizeRows = False
        grdCourier.RowTemplate.Height = 18

        Dim i As Integer

        'If mode = "UPDATE" Or mode = "ADD" Then
        For i = 0 To rs_CUSHPINF_C.Tables("RESULT").Columns.Count - 1
            rs_CUSHPINF_C.Tables("RESULT").Columns(i).ReadOnly = False
        Next i

        i = 0
        grdCourier_Status = i
        grdCourier.Columns(i).HeaderText = "Del"
        grdCourier.Columns(i).Width = 30
        grdCourier.Columns(i).ReadOnly = True
        i = i + 1
        grdCourier_csi_csetyp = i
        grdCourier.Columns(i).HeaderText = "Type (FO/FA/FT/CO)"
        grdCourier.Columns(i).Width = 140
        grdCourier.Columns(i).ReadOnly = True
        i = i + 1
        grdCourier_csi_cseseq = i
        grdCourier.Columns(i).Visible = False
        i = i + 1
        grdCourier_csi_csenam = i
        grdCourier.Columns(i).HeaderText = "Name"
        grdCourier.Columns(i).Width = 120
        grdCourier.Columns(i).ReadOnly = False
        i = i + 1
        grdCourier_csi_cseacc = i
        grdCourier.Columns(i).HeaderText = "Account Number"
        grdCourier.Columns(i).Width = 150
        grdCourier.Columns(i).ReadOnly = False
        i = i + 1
        grdCourier_csi_dsc = i
        grdCourier.Columns(i).HeaderText = "Description"
        grdCourier.Columns(i).Width = 180
        grdCourier.Columns(i).ReadOnly = False
        i = i + 1
        grdCourier_csi_cseadr = i
        grdCourier.Columns(i).HeaderText = "Address"
        grdCourier.Columns(i).Width = 220
        grdCourier.Columns(i).ReadOnly = False
        i = i + 1
        grdCourier_csi_csestt = i
        grdCourier.Columns(i).HeaderText = "Province / State"
        grdCourier.Columns(i).Width = 150
        grdCourier.Columns(i).ReadOnly = False
        i = i + 1
        grdCourier_csi_csecty = i
        grdCourier.Columns(i).HeaderText = "Country"
        grdCourier.Columns(i).Width = 150
        i = i + 1
        grdCourier_csi_csepst = i
        grdCourier.Columns(i).HeaderText = "Postal / ZIP"
        grdCourier.Columns(i).Width = 120
        grdCourier.Columns(i).ReadOnly = False
        i = i + 1
        grdCourier_csi_csectp = i
        grdCourier.Columns(i).HeaderText = "Contact Person"
        grdCourier.Columns(i).Width = 140
        grdCourier.Columns(i).ReadOnly = False
        i = i + 1
        grdCourier_csi_csetil = i
        grdCourier.Columns(i).HeaderText = "Title"
        grdCourier.Columns(i).Width = 140
        grdCourier.Columns(i).ReadOnly = False
        i = i + 1
        grdCourier_csi_csephn = i
        grdCourier.Columns(i).HeaderText = "Phone No."
        grdCourier.Columns(i).Width = 140
        grdCourier.Columns(i).ReadOnly = False
        i = i + 1
        grdCourier_csi_csefax = i
        grdCourier.Columns(i).HeaderText = "Fax No."
        grdCourier.Columns(i).Width = 140
        grdCourier.Columns(i).ReadOnly = False
        i = i + 1
        grdCourier_csi_cseeml = i
        grdCourier.Columns(i).HeaderText = "E-mail"
        grdCourier.Columns(i).Width = 180
        grdCourier.Columns(i).ReadOnly = False
        i = i + 1
        grdCourier_csi_cseinr = i
        grdCourier.Columns(i).HeaderText = "Instruction"
        grdCourier.Columns(i).Width = 280
        grdCourier.Columns(i).ReadOnly = False
        i = i + 1
        grdCourier_csi_csedef = i
        grdCourier.Columns(i).Visible = False
        grdCourier.Columns(i).HeaderText = "Default (Y/N)"
        grdCourier.Columns(i).Width = 80
        i = i + 1
        grdCourier_csi_creusr = i
        grdCourier.Columns(i).Visible = False
        i = i + 1
        grdCourier_csi_updusr = i
        grdCourier.Columns(i).Visible = False



        'Dim ii As Integer

        'For ii = 0 To grdCourier.Columns.Count - 1

        '    grdCourier.Columns(ii).SortMode = DataGridViewColumnSortMode.NotSortable

        'Next ii


    End Sub

    Private Sub SetgrdBank()
        If rs_CUSHPINF_B.Tables.Count = 0 Then
            Exit Sub
        End If

        grdBank.DataSource = rs_CUSHPINF_B.Tables("RESULT").DefaultView



        grdBank.RowHeadersWidth = 18
        grdBank.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        grdBank.ColumnHeadersHeight = 18
        grdBank.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        grdBank.AllowUserToResizeColumns = True
        grdBank.AllowUserToResizeRows = False
        grdBank.RowTemplate.Height = 18

        Dim i As Integer

        'If mode = "UPDATE" Or mode = "ADD" Then
        For i = 0 To rs_CUSHPINF_B.Tables("RESULT").Columns.Count - 1
            rs_CUSHPINF_B.Tables("RESULT").Columns(i).ReadOnly = False
        Next i



        i = 0
        grdBank_Status = i
        grdBank.Columns(i).HeaderText = "Del"
        grdBank.Columns(i).Width = 30
        grdBank.Columns(i).ReadOnly = True
        i = i + 1
        grdBank_csi_csetyp = i
        grdBank.Columns(i).HeaderText = "Type (BK/NP/CN)"
        grdBank.Columns(i).Width = 120
        grdBank.Columns(i).ReadOnly = True
        i = i + 1
        grdBank_csi_csenam = i
        grdBank.Columns(i).HeaderText = "Name"
        grdBank.Columns(i).Width = 170
        grdBank.Columns(i).ReadOnly = False
        i = i + 1
        grdBank_csi_cseseq = i

        grdBank.Columns(i).Visible = False
        i = i + 1
        grdBank_csi_cseadr = i
        grdBank.Columns(i).HeaderText = "Address"
        grdBank.Columns(i).Width = 250
        grdBank.Columns(i).ReadOnly = False
        i = i + 1
        grdBank_csi_csestt = i
        grdBank.Columns(i).HeaderText = "State / Province"
        grdBank.Columns(i).Width = 140
        grdBank.Columns(i).ReadOnly = False
        i = i + 1
        grdBank_csi_csecty = i
        grdBank.Columns(i).HeaderText = "Country"
        grdBank.Columns(i).Width = 170
        i = i + 1
        grdBank_csi_csepst = i
        grdBank.Columns(i).HeaderText = "ZIP / Postal"
        grdBank.Columns(i).Width = 80
        grdBank.Columns(i).ReadOnly = False
        i = i + 1
        grdBank_csi_csectp = i
        grdBank.Columns(i).HeaderText = "Contact Person"
        grdBank.Columns(i).Width = 140
        grdBank.Columns(i).ReadOnly = False
        i = i + 1
        grdBank_csi_csetil = i
        grdBank.Columns(i).HeaderText = "Title"
        grdBank.Columns(i).Width = 140
        grdBank.Columns(i).ReadOnly = False
        i = i + 1
        grdBank_csi_csephn = i
        grdBank.Columns(i).HeaderText = "Phone No"
        grdBank.Columns(i).Width = 140
        grdBank.Columns(i).ReadOnly = False
        i = i + 1
        grdBank_csi_csefax = i
        grdBank.Columns(i).HeaderText = "Fax No"
        grdBank.Columns(i).Width = 140
        grdBank.Columns(i).ReadOnly = False
        i = i + 1
        grdBank_csi_cseeml = i
        grdBank.Columns(i).HeaderText = "E-mail address"
        grdBank.Columns(i).Width = 180
        grdBank.Columns(i).ReadOnly = False
        i = i + 1
        grdBank_csi_csedef = i
        grdBank.Columns(i).HeaderText = "Default (Y/N)"
        grdBank.Columns(i).Width = 60
        grdBank.Columns(i).Visible = False
        i = i + 1
        grdBank_csi_creusr = i
        grdBank.Columns(i).Visible = False
        i = i + 1
        grdBank_csi_updusr = i
        grdBank.Columns(i).Visible = False




        'Dim ii As Integer

        'For ii = 0 To grdBank.Columns.Count - 1

        '    grdBank.Columns(ii).SortMode = DataGridViewColumnSortMode.NotSortable

        'Next ii



    End Sub

    Private Sub SetGrdContact()
        If rs_CUCNTINF_C.Tables.Count = 0 Then
            Exit Sub
        End If

        grdContact.DataSource = rs_CUCNTINF_C.Tables("RESULT").DefaultView

        grdContact.RowHeadersWidth = 18
        grdContact.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        grdContact.ColumnHeadersHeight = 18
        grdContact.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        grdContact.AllowUserToResizeColumns = True
        grdContact.AllowUserToResizeRows = False
        grdContact.RowTemplate.Height = 18

        Dim i As Integer

        'If mode = "UPDATE" Or mode = "ADD" Then
        For i = 0 To rs_CUCNTINF_C.Tables("RESULT").Columns.Count - 1
            rs_CUCNTINF_C.Tables("RESULT").Columns(i).ReadOnly = False
        Next i


        i = 0
        grdContact_Status = i
        grdContact.Columns(i).HeaderText = "Del"
        grdContact.Columns(i).Width = 30
        grdContact.Columns(i).ReadOnly = True
        i = i + 1
        grdContact_cci_cnttyp = i
        grdContact.Columns(i).HeaderText = "Nature"
        grdContact.Columns(i).Width = 80
        grdContact.Columns(i).ReadOnly = True
        i = i + 1
        grdContact_cci_cntseq = i
        grdContact.Columns(i).Visible = False
        i = i + 1
        grdContact_cci_cntctp = i
        grdContact.Columns(i).HeaderText = "Contact Person"
        grdContact.Columns(i).Width = 140
        grdContact.Columns(i).ReadOnly = False
        i = i + 1
        grdContact_cci_cnttil = i
        grdContact.Columns(i).HeaderText = "Title"
        grdContact.Columns(i).Width = 160
        grdContact.Columns(i).ReadOnly = False
        i = i + 1
        grdContact_cci_cntphn = i
        grdContact.Columns(i).HeaderText = "Phone No"
        grdContact.Columns(i).Width = 120
        grdContact.Columns(i).ReadOnly = False
        i = i + 1
        grdContact_cci_cntfax = i
        grdContact.Columns(i).HeaderText = "Fax No"
        grdContact.Columns(i).Width = 120
        grdContact.Columns(i).ReadOnly = False
        i = i + 1
        grdContact_cci_cnteml = i
        grdContact.Columns(i).HeaderText = "E-mail Address"
        grdContact.Columns(i).Width = 170
        grdContact.Columns(i).ReadOnly = False
        i = i + 1
        grdContact_cci_cntdef = i
        grdContact.Columns(i).HeaderText = "Default (Y/N)"
        grdContact.Columns(i).Width = 60

        i = i + 1

        grdContact_cci_creusr = i
        grdContact.Columns(i).Visible = False
        i = i + 1
        grdContact_cci_updusr = i
        grdContact.Columns(i).Visible = False


        'Dim ii As Integer

        'For ii = 0 To grdContact.Columns.Count - 1

        '    grdContact.Columns(ii).SortMode = DataGridViewColumnSortMode.NotSortable

        'Next ii


    End Sub
    Private Sub Setgrdshipping()
        If rs_CUCNTINF_S.Tables.Count = 0 Then
            Exit Sub
        End If

        grdShipping.DataSource = rs_CUCNTINF_S.Tables("RESULT").DefaultView

        grdShipping.RowHeadersWidth = 18
        grdShipping.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        grdShipping.ColumnHeadersHeight = 18
        grdShipping.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        grdShipping.AllowUserToResizeColumns = True
        grdShipping.AllowUserToResizeRows = False
        grdShipping.RowTemplate.Height = 18

        Dim i As Integer

        'If mode = "UPDATE" Or mode = "ADD" Then
        For i = 0 To rs_CUCNTINF_S.Tables("RESULT").Columns.Count - 1
            rs_CUCNTINF_S.Tables("RESULT").Columns(i).ReadOnly = False
        Next i
        'End If


        i = 0
        grdShipping_Status = i
        grdShipping.Columns(i).HeaderText = "Del"
        grdShipping.Columns(i).Width = 30
        grdShipping.Columns(i).ReadOnly = True
        i = i + 1
        grdShipping_cci_cntadr = i
        grdShipping.Columns(i).HeaderText = "Shipping Address"
        grdShipping.Columns(i).Width = 340
        grdShipping.Columns(i).ReadOnly = False
        i = i + 1
        grdShipping_cci_cntstt = i
        grdShipping.Columns(i).HeaderText = "State/Province"
        grdShipping.Columns(i).Width = 100
        grdShipping.Columns(i).ReadOnly = False
        i = i + 1
        grdShipping_cci_cntcty = i
        grdShipping.Columns(i).HeaderText = "Country"
        grdShipping.Columns(i).Width = 140
        grdShipping.Columns(i).ReadOnly = True
        i = i + 1
        grdShipping_cci_cntpst = i
        grdShipping.Columns(i).HeaderText = "ZIP/Postal"
        grdShipping.Columns(i).Width = 70
        grdShipping.Columns(i).ReadOnly = False
        i = i + 1
        grdShipping_cci_cntdef = i
        grdShipping.Columns(i).HeaderText = "Default (Y/N)"
        grdShipping.Columns(i).Width = 60
        grdShipping.Columns(i).ReadOnly = True
        i = i + 1
        grdShipping_cci_cntseq = i
        grdShipping.Columns(i).Visible = False
        i = i + 1
        grdShipping_cci_creusr = i
        grdShipping.Columns(i).Visible = False
        i = i + 1
        grdShipping_cci_updusr = i
        grdShipping.Columns(i).Visible = False
        i = i + 1
        grdShipping_cci_sapshcusno = i
        grdShipping.Columns(i).HeaderText = "SAP Customer No."
        grdShipping.Columns(i).Width = 150
        grdShipping.Columns(i).ReadOnly = True

        'Dim ii As Integer

        'For ii = 0 To grdShipping.Columns.Count - 1

        '    grdShipping.Columns(ii).SortMode = DataGridViewColumnSortMode.NotSortable

        'Next ii


    End Sub



    Private Sub SetGrdBilling()
        If rs_CUCNTINF_B.Tables.Count = 0 Then
            Exit Sub
        End If

        grdBilling.DataSource = rs_CUCNTINF_B.Tables("RESULT").DefaultView

        grdBilling.RowHeadersWidth = 18
        grdBilling.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        grdBilling.ColumnHeadersHeight = 18
        grdBilling.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        grdBilling.AllowUserToResizeColumns = True
        grdBilling.AllowUserToResizeRows = False
        grdBilling.RowTemplate.Height = 18

        Dim i As Integer

        'If mode = "UPDATE" Or mode = "ADD" Then
        For i = 0 To rs_CUCNTINF_B.Tables("RESULT").Columns.Count - 1
            rs_CUCNTINF_B.Tables("RESULT").Columns(i).ReadOnly = False
        Next i
        'End If


        i = 0
        grdBilling_Status = i
        grdBilling.Columns(i).HeaderText = "Del"
        grdBilling.Columns(i).Width = 30
        grdBilling.Columns(i).ReadOnly = True
        i = i + 1
        grdBilling_cci_cntadr = i
        grdBilling.Columns(i).HeaderText = "Billing Address"
        grdBilling.Columns(i).Width = 340
        grdBilling.Columns(i).ReadOnly = False
        i = i + 1
        grdBilling_cci_cntstt = i

        grdBilling.Columns(i).HeaderText = "State/Province"
        grdBilling.Columns(i).Width = 100
        grdBilling.Columns(i).ReadOnly = False
        i = i + 1
        grdBilling_cci_cntcty = i
        grdBilling.Columns(i).HeaderText = "Country"
        grdBilling.Columns(i).Width = 140
        i = i + 1
        grdBilling_cci_cntpst = i
        grdBilling.Columns(i).HeaderText = "ZIP/Postal"
        grdBilling.Columns(i).Width = 70
        grdBilling.Columns(i).ReadOnly = False
        i = i + 1
        grdBilling_cci_cntdef = i
        grdBilling.Columns(i).HeaderText = "Default (Y/N)"
        grdBilling.Columns(i).Width = 60
        grdBilling.Columns(i).ReadOnly = True
        i = i + 1
        grdBilling_cci_cntseq = i
        grdBilling.Columns(i).Visible = False
        i = i + 1
        grdBilling_cci_creusr = i
        grdBilling.Columns(i).Visible = False
        i = i + 1
        grdBilling_cci_updusr = i
        grdBilling.Columns(i).Visible = False
        i = i + 1
        grdBilling_cci_sapshcusno = i
        grdBilling.Columns(i).HeaderText = "SAP Customer No."
        grdBilling.Columns(i).Width = 150
        grdBilling.Columns(i).ReadOnly = True

        'Dim ii As Integer

        'For ii = 0 To grdBilling.Columns.Count - 1

        '    grdBilling.Columns(ii).SortMode = DataGridViewColumnSortMode.NotSortable

        'Next ii

    End Sub


    Private Function func_ReadRecordset()

        gspStr = "sp_list_VNBASINF ''"
        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_ReadRecordset sp_list_VNBASINF :" & rtnStr)
            Exit Function
        End If

        gspStr = "sp_list_SYSALINF_CU ''"
        rtnLong = execute_SQLStatement(gspStr, rs_SYSALINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_ReadRecordset sp_list_SYSALINF_CU :" & rtnStr)
            Exit Function
        End If


        gspStr = "sp_list_SYSALREP ''"
        rtnLong = execute_SQLStatement(gspStr, rs_SYSALREP, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_ReadRecordset sp_list_SYSALREP :" & rtnStr)
            Exit Function
        End If

        gspStr = "sp_list_SYLNEFML ''"
        rtnLong = execute_SQLStatement(gspStr, rs_SYLNEFML, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_ReadRecordset sp_list_SYLNEFML :" & rtnStr)
            Exit Function
        End If

        gspStr = "sp_select_CUPRCINF_CUM00001 '','" & txtCusno.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUPRCINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_ReadRecordset sp_select_CUPRCINF_CUM00001 :" & rtnStr)
            Exit Function
        End If

        gspStr = "sp_select_SYSETINF_all '','" & "02" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYSETINF_02, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_ReadRecordset sp_select_SYSETINF_all :" & rtnStr)
            Exit Function
        End If




        gspStr = "sp_select_SYSETINF '','" & "03" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYSETINF_03, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_ReadRecordset sp_select_SYSETINF_03 :" & rtnStr)
            Exit Function
        End If

        gspStr = "sp_select_SYSETINF '','" & "04" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYSETINF_04, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_ReadRecordset sp_select_SYSETINF_04 :" & rtnStr)
            Exit Function
        End If

        gspStr = "sp_select_SYCURRENCY '','" & "N" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYSETINF_06, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_ReadRecordset sp_select_SYCURRENCY :" & rtnStr)
            Exit Function
        End If

        gspStr = "sp_select_SYSETINF '','" & "08" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYSETINF_08, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_ReadRecordset sp_select_SYSETINF_08 :" & rtnStr)
            Exit Function
        End If

        gspStr = "sp_select_SYSETINF '','" & "13" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYSETINF_13, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_ReadRecordset sp_select_SYSETINF_13 :" & rtnStr)
            Exit Function
        End If

        gspStr = "sp_list_SYFMLINF ''"
        rtnLong = execute_SQLStatement(gspStr, rs_SYFMLINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_ReadRecordset sp_list_SYFMLINF :" & rtnStr)
            Exit Function

        End If

        gspStr = "sp_select_CUSHPMRK '','" & txtCusno.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUSHPMRK, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_ReadRecordset sp_select_CUSHPMRK :" & rtnStr)
            Exit Function
        End If

        gspStr = "sp_list_CUCNTINF '','" & txtCusno.Text & "','M'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUCNTINF_M, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_ReadRecordset sp_list_CUCNTINF :" & rtnStr)
            Exit Function
        End If

        gspStr = "sp_select_CUBOKSAL '','" & txtCusno.Text & "','999999'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUBOKSAL, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_ReadRecordset sp_select_CUBOKSAL :" & rtnStr)
            Exit Function
        End If

        gspStr = "sp_select_CUSHPFML '','" & txtCusno.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUSHPFML, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_ReadRecordset sp_select_CUSHPFML :" & rtnStr)
            Exit Function
        End If

        gspStr = "sp_list_SYAGTINF ''"
        rtnLong = execute_SQLStatement(gspStr, rs_SYAGTINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_ReadRecordset sp_list_SYAGTINF :" & rtnStr)
            Exit Function
        End If

        gspStr = "sp_list_SYSMPTRM ''"
        rtnLong = execute_SQLStatement(gspStr, rs_SYSMPTRM, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_ReadRecordset sp_list_SYSMPTRM :" & rtnStr)
            Exit Function
        End If

        gspStr = "sp_select_CUMCOVEN '','" & txtCusno.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUMCOVEN, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_ReadRecordset sp_select_CUMCOVEN :" & rtnStr)
            Exit Function
        End If

        gspStr = "sp_select_CUCALFML '','" & txtCusno.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUCALFML, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_ReadRecordset sp_select_CUCALFML :" & rtnStr)
            Exit Function
        End If


        gspStr = "sp_select_Distinct_CUCALFML '','" & txtCusno.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUCALFML_Distinct, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_ReadRecordset sp_select_Distinct_CUCALFML :" & rtnStr)
            Exit Function
        End If


        Dim i As Integer = 0
        For i = 0 To rs_CUCALFML.Tables("RESULT").Columns.Count - 1
            rs_CUCALFML.Tables("RESULT").Columns(i).ReadOnly = False
        Next

        gspStr = "sp_select_SYSETINF '','" & "01" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYSETINF_01, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_ReadRecordset sp_select_SYSETINF :" & rtnStr)
            Exit Function
        End If

        'gspStr = "sp_select_CUMCAMRK '','" & txtCusno.Text & "'"
        'rtnLong = execute_SQLStatement(gspStr, rs_CUMCAMRK, rtnStr)
        'If rtnLong <> RC_SUCCESS Then
        '    MsgBox("Error on loading func_ReadRecordset sp_select_CUMCAMRK :" & rtnStr)
        '    Exit Function
        'End If

        gspStr = "sp_select_SYCOMINF_M '','" & "ALL" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_sycominf, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_ReadRecordset sp_select_SYCOMINF_M :" & rtnStr)
            Exit Function
        End If

        gspStr = "sp_list_SYCATCDE_CUM00001 '','" & "3" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYCATCDE, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_ReadRecordset sp_list_SYCATCDE_CUM00001 :" & rtnStr)
            Exit Function
        End If


        gspStr = "sp_select_SYSETINF '','" & "17" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYSETINF_17, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_ReadRecordset sp_list_SYSETINF_17 :" & rtnStr)
            Exit Function
        End If

        gspStr = "sp_select_SYSETINF '','" & "18" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYSETINF_18, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_ReadRecordset sp_list_SYSETINF_18 :" & rtnStr)
            Exit Function
        End If


        Dim dr_sycominf As DataRow() = rs_sycominf.Tables("RESULT").Select("yco_cogrp = '" & gsCompanyGroup & "'")

        If Not Add_flag Then
            If rs_CUBASINF.Tables("RESULT").Rows.Count > 0 Then
                If rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_custyp") = "P" Then
                    gspStr = "sp_list_CUBASINF '','" & "P" & "'"
                Else
                    gspStr = "sp_list_CUBASINF '','" & "S" & "'"
                End If
                rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_L, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading func_ReadRecordset sp_list_CUBASINF :" & rtnStr)
                    Exit Function
                End If
            End If
        Else
            gspStr = "sp_list_CUBASINF '','" & "A" & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_L, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading func_ReadRecordset sp_list_CUBASINF :" & rtnStr)
                Exit Function
            End If
        End If

        gspStr = "sp_select_CUVENINF '','" & txtCusno.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUVENINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_ReadRecordset sp_select_CUVENINF :" & rtnStr)
            Exit Function
        End If

        gspStr = "sp_select_CUAGTINF '','" & txtCusno.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUAGTINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_ReadRecordset sp_select_CUAGTINF :" & rtnStr)
            Exit Function
        End If

        gspStr = "sp_list_CUCNTINF '','" & txtCusno.Text & "','B'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUCNTINF_B, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_ReadRecordset sp_list_CUCNTINF_B :" & rtnStr)
            Exit Function
        End If

        gspStr = "sp_list_CUCNTINF '','" & txtCusno.Text & "','S'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUCNTINF_S, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_ReadRecordset sp_list_CUCNTINF_S :" & rtnStr)
            Exit Function
        End If

        gspStr = "sp_list_CUCNTINF '','" & txtCusno.Text & "','C'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUCNTINF_C, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_ReadRecordset sp_list_CUCNTINF_C :" & rtnStr)
            Exit Function
        End If

        gspStr = "sp_list_CUSHPINF '','" & txtCusno.Text & "','B'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUSHPINF_B, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_ReadRecordset sp_list_CUSHPINF_B :" & rtnStr)
            Exit Function
        End If

        gspStr = "sp_list_CUSHPINF '','" & txtCusno.Text & "','C'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUSHPINF_C, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_ReadRecordset sp_list_CUSHPINF_C :" & rtnStr)
            Exit Function
        End If


        gspStr = "sp_select_CUSHPMRK '','" & txtCusno.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUSHPMRK, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_ReadRecordset sp_select_CUSHPMRK :" & rtnStr)
            Exit Function
        End If

        If Not Add_flag Then
            If rs_CUBASINF.Tables("RESULT").Rows.Count > 0 Then
                If rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_custyp") = "P" Then
                    gspStr = "sp_select_CUSUBCUS '','" & txtCusno.Text & "','P'"
                Else
                    gspStr = "sp_select_CUSUBCUS '','" & txtCusno.Text & "','S'"
                End If
                rtnLong = execute_SQLStatement(gspStr, rs_CUSUBCUS_P, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading func_ReadRecordset sp_select_CUSUBCUS_P :" & rtnStr)
                    Exit Function
                End If
            End If

            PriCusCurr = ""
            If rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_custyp") = "S" Then
                If rs_CUSUBCUS_P.Tables("RESULT").Rows.Count > 0 Then

                    gspStr = "sp_select_CUPRCINF_CUM00001 '','" & rs_CUSUBCUS_P.Tables("RESULT").Rows(0).Item("csc_prmcus") & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading func_ReadRecordset sp_select_CUSUBCUS_P :" & rtnStr)
                        Exit Function
                    Else
                        PriCusCurr = rs.Tables("RESULT").Rows(0).Item("cpi_curcde")
                    End If

                End If
            End If

        End If

        If Not Add_flag Then
            If rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_custyp") = "P" Then
                gspStr = "sp_select_CUBCR '','ONE','" & txtCusno.Text & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_CUBCR, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading func_ReadRecordset sp_select_CUBCR :" & rtnStr)
                    Exit Function
                End If

                gspStr = "sp_list_CUBCR_alias '','" & txtCusno.Text & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_CUBCR_Alias, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading func_ReadRecordset sp_list_CUBCR_alias :" & rtnStr)
                    Exit Function
                End If
            Else
                gspStr = "sp_select_CUBCR '','ONE','" & "XXX999" & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_CUBCR, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading func_ReadRecordset sp_select_CUBCR :" & rtnStr)
                    Exit Function
                End If

                gspStr = "sp_list_CUBCR_alias '','" & "XXX999" & "'"
                rtnLong = execute_SQLStatement(gspStr, rs_CUBCR_Alias, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading func_ReadRecordset sp_list_CUBCR_alias :" & rtnStr)
                    Exit Function
                End If

            End If

        Else
            gspStr = "sp_select_CUBCR '','ONE','" & "XXX999" & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_CUBCR, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading func_ReadRecordset sp_select_CUBCR :" & rtnStr)
                Exit Function
            End If

            gspStr = "sp_list_CUBCR_alias '','" & "XXX999" & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_CUBCR_Alias, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading func_ReadRecordset sp_list_CUBCR_alias :" & rtnStr)
                Exit Function
            End If
        End If

        gspStr = "sp_select_CUCSTEMT '','" & txtCusno.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUCSTEMT, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_ReadRecordset sp_select_CUCSTEMT :" & rtnStr)
            Exit Function
        End If


        gspStr = "sp_select_CUCSTAMT '','" & txtCusno.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUCSTAMT, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_ReadRecordset sp_select_CUCSTAMT :" & rtnStr)
            Exit Function
        End If

        gspStr = "sp_select_CURETPRC '','" & txtCusno.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_CURETPRC, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_ReadRecordset sp_select_CURETPRC :" & rtnStr)
            Exit Function
        End If

        gspStr = "sp_select_CUELC '','" & txtCusno.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUELC, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_ReadRecordset sp_select_CUELC :" & rtnStr)
            Exit Function
        End If

        gspStr = "sp_select_CUELCDTL '','" & txtCusno.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUELCDTL, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_ReadRecordset sp_select_CUELCDTL :" & rtnStr)
            Exit Function
        End If


        gspStr = "sp_select_CUFLGRAT '','" & txtCusno.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUFLGRAT, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_ReadRecordset sp_select_CUFLGRAT :" & rtnStr)
            Exit Function
        End If


        'A rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_saltem").ToString

        If txtCusno.Text <> "A" Then
            gspStr = "sp_list_SYUSRPRF_2 '','" & rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_saltem").ToString & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_SYUSRPRF_2, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading func_ReadRecordset sp_list_SYUSRPRF_2 :" & rtnStr)
                Exit Function
            End If
        Else
            gspStr = "sp_list_SYUSRPRF_2 '','" & txtCusno.Text & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_SYUSRPRF_2, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading func_ReadRecordset sp_list_SYUSRPRF_2 :" & rtnStr)
                Exit Function
            End If
        End If


        gspStr = "sp_list_CUPRCTRM '','" & txtCusno.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUPRCTRM, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_ReadRecordset sp_list_CUPRCTRM :" & rtnStr)
            Exit Function
        End If



    End Function

    Private Sub txtCusno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCusno.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then

            Call cmdFind_Click(sender, e)
        End If
    End Sub


    Private Sub txtCusno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCusno.TextChanged

    End Sub

    Private Sub mmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdClear.Click
        If checkFocus(Me) Then Exit Sub

        tmpcusno = txtCusno.Text
        status = "Clear"

        If Recordstatus = True And Trim(txtCusno.Text) = "" And mmdSave.Enabled = True Then
            If MsgBox("Record is newly created. Do you want to save before clear the screen?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                mmdSave_Click(sender, e)
            ElseIf MsgBoxResult.No Then
                Call setStatus("Clear")
                Call setStatus("Init")
                Add_flag = False
                Recordstatus = False
                currentShipmark = 0
                copyflag = False
                OptCpyPricus.Checked = False
                optSecCus.Checked = False
                lblRecCount.Text = ""
                txtCusno.Focus()
            ElseIf MsgBoxResult.Cancel Then
                If txtCussna.Enabled = True Then
                    txtCussna.Focus()
                End If

            End If
        ElseIf (Recordstatus = True Or FRecordstatus = True) And txtCusno.Text <> "" And mmdSave.Enabled = True Then
            If MsgBox("Record has been modified. Do you want to save before clear the screen?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                save_CUCALFML_2()
                mmdSave_Click(sender, e)
            ElseIf MsgBoxResult.No Then
                Call setStatus("Clear")
                Call setStatus("Init")
                Add_flag = False
                Recordstatus = False
                currentShipmark = 0
                copyflag = False
                OptCpyPricus.Checked = False
                optSecCus.Checked = False
                lblRecCount.Text = ""
                txtCusno.Focus()
            ElseIf MsgBoxResult.Cancel Then
                If txtCussna.Enabled = True Then
                    txtCussna.Focus()
                End If
            End If
        Else

            Call setStatus("Clear")
            Call setStatus("Init")
            optPriCus.Checked = False
            Add_flag = False
            copyflag = False
            Recordstatus = False
            OptCpyPricus.Checked = False
            optSecCus.Checked = False
            currentShipmark = 0
            lblRecCount.Text = ""
            txtCusno.Focus()

        End If



    End Sub

    Private Sub mmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdAdd.Click
        If checkFocus(Me) Then Exit Sub
        status = "ADD"

        txtCusno.Text = ""
        Add_flag = True


        txtCusno.Text = "A"
        '*** Query Customer Master Data


        gspStr = "sp_select_CUBASINF '','" & txtCusno.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdAdd_Click sp_select_CUBASINF :" & rtnStr)
            Exit Sub
        End If


        Me.StatusBar.Items("lblright").Text = Today & " " & Today & " " & gsUsrID

        Call func_ReadRecordset()
        Call setStatus("Add")
        txtCusno.Text = ""
        txtCusnam.Enabled = True
        txtCusnam.Focus()
        Call func_SetGrid()
        Call func_FillComboBox()

        rs_CUBASINF.Tables("RESULT").Rows.Add() 'rs_CUBASINF.AddNew()

        cboStatus.SelectedIndex = 0
        cboStatus.Enabled = False
        chkDiscontinue.Enabled = False

        cboCountry.Text = "US - United States" 'recordstatus change to true
        Recordstatus = False
        '-- Added by Victor Leung 20030209
        '-- To clear the textbox "Credit Limit" and "Credit Used"

        txtCusAli.Enabled = False
        txtSalMgt.Enabled = False
        txtSalDiv.Enabled = False
        '--------------------------------------------------------
    End Sub

   

    Private Sub mmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdSave.Click
        If checkFocus(Me) Then Exit Sub

        Dim YNC As Integer

        status = "Save"

        Me.Cursor = Cursors.WaitCursor


        If gsUsrGrp = "MSAL-A" Or gsUsrGrp = "SAL-ZS" Or gsUsrGrp = "SAL-ZE" Or gsUsrGrp = "SAL-ZG" Or gsUsrGrp = "SAL-ZP" Then
            ' Save ship mark only
            'Call save_currentshipmrk()

            'call save_CUSHPMRK() 

            'MsgBox("Record Saved")

            'Call setStatus("Clear")

            'txtCusno.Text = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cusno")
            'Me.Cursor = Cursors.Default
            'Exit Sub
        Else




            If chkActivate.Checked = True Then
                If MsgBox("Are you sure to Activate Customer " & txtCusno.Text & "?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Me.Cursor = Cursors.Default
                    chkActivate.Checked = False
                    save_ok = False
                    Exit Sub
                End If
            End If

            If Not InputIsValid() Then
                Me.Cursor = Cursors.Default
                save_ok = False
                Exit Sub
            End If


            Call save_currentshipmrk()




            If Not Add_flag Then
                '***check timeStamp is equal
                If Not checkTimeStamp() Then
                    MsgBox("Refresh", vbInformation, gsCompany)
                    Me.Cursor = Cursors.Default
                    save_ok = False
                    Exit Sub
                End If
            End If

            If optPriCus.Checked = True Then
                CusTyp = "P"
            Else
                CusTyp = "S"
            End If

            If Add_flag = True Then
                func_AddNewCustNo()
                tmpcusno = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cusno")


                Dim csf_cus1no As String
                Dim csf_cus2no As String

                'If rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_custyp") = "P" Then
                If optPriCus.Checked = True Then
                    csf_cus1no = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cusno")
                    csf_cus2no = ""
                Else
                    csf_cus1no = rs_CUSUBCUS_P.Tables("RESULT").Rows(0).Item("csc_prmcus")
                    csf_cus2no = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cusno")
                End If


                Dim jj As Integer
                For jj = 0 To rs_CUSHPFML.Tables("RESULT").Rows.Count - 1
                    rs_CUSHPFML.Tables("RESULT").Rows(jj).Item("csf_cus1no") = csf_cus1no
                    rs_CUSHPFML.Tables("RESULT").Rows(jj).Item("csf_cus2no") = csf_cus2no
                Next jj

            Else
                Dim ii As Integer
                For ii = 0 To rs_CUBASINF.Tables("RESULT").Columns.Count - 1
                    rs_CUBASINF.Tables("RESULT").Columns(ii).ReadOnly = False
                Next ii
                rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cusno") = txtCusno.Text
                tmpcusno = txtCusno.Text
            End If

            Call func_SaveRecordset()

            If IsUpdated Then
                If Add_flag = True Then
                    tmp = ""
                    tmp = MsgBox("Customer Added! The Customer No of this record is :  '" & rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cusno") & "'", vbInformation, gsCompany)
                Else
                    MsgBox("Record Saved")
                End If
                tmp = ""
                tmp = txtCusno.Text

                Call setStatus("Clear")
            Else
                tmp = ""
                tmp = txtCusno.Text
                MsgBox("Record Not Updated!")
            End If
            'End If



        End If

        txtCusno.Text = tmpcusno
        tmp = ""
        Add_flag = False
        Recordstatus = False
        optPriCus.Checked = False
        Add_flag = False
        copyflag = False
        Recordstatus = False
        OptCpyPricus.Checked = False
        optSecCus.Checked = False
        currentShipmark = 0
        lblRecCount.Text = ""
        CusTyp = ""
        Me.Cursor = Cursors.Default
        Call setStatus("Clear") 'copy need delete


    End Sub

   

    Public Function func_AddNewCustNo()
        Dim ii As Integer
        For ii = 0 To rs_CUBASINF.Tables("RESULT").Columns.Count - 1
            rs_CUBASINF.Tables("RESULT").Columns(ii).ReadOnly = False
        Next ii

        gspStr = "sp_list_SYSALREP ''"
        rtnLong = execute_SQLStatement(gspStr, rs_SYSALREP, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_AddNewCustNo sp_list_SYSALREP :" & rtnStr)
            Exit Function
        End If


        Dim rs() As ADOR.Recordset
        Dim S As String
        Dim i As Integer
        Dim NoOfZeros As Integer

        '*** Auto a new customer number
        '   txtCusno.Text = ""

        If gsCompanyGroup = "MSG" Then
            gspStr = "sp_list_CUBASINF '','NM'"

        Else
            gspStr = "sp_list_CUBASINF '','N'"
        End If

        rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_AddNo, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading func_ReadRecordset sp_list_SYSALREP :" & rtnStr)
            Exit Function
        Else

            NoOfZeros = rs_CUBASINF_AddNo.Tables("RESULT").Rows(0).Item("cbi_cusno")

            NoOfZeros = 4 - Microsoft.VisualBasic.Len(rs_CUBASINF_AddNo.Tables("RESULT").Rows(0).Item("cbi_cusno").ToString)

            '--Added by Victor Leung 20030210
            '--To reset the value of credit used

            '-----------------------------------
            If CusTyp = "P" Then
                'If gsCompany = "UCPP" Then
                '    rs_CUBASINF("CBI_CUSNO") = "1" & String(NoOfZeros, "0") & rs_CUBASINF_AddNo("cbi_cusno")
                'ElseIf gsCompany = "UCP" Then
                '    rs_CUBASINF("CBI_CUSNO") = "3" & String(NoOfZeros, "0") & rs_CUBASINF_AddNo("cbi_cusno")
                'End If

                If gsCompanyGroup = "MSG" Then
                    rs_CUBASINF.Tables("RESULT").Rows(0).Item("CBI_CUSNO") = "7" & StrDup(NoOfZeros, "0") & rs_CUBASINF_AddNo.Tables("RESULT").Rows(0).Item("cbi_cusno")
                Else
                    rs_CUBASINF.Tables("RESULT").Rows(0).Item("CBI_CUSNO") = "5" & StrDup(NoOfZeros, "0") & rs_CUBASINF_AddNo.Tables("RESULT").Rows(0).Item("cbi_cusno")
                End If
            ElseIf CusTyp = "S" Then
                'If gsCompany = "UCPP" Then
                '    rs_CUBASINF("CBI_CUSNO") = "2" & String(NoOfZeros, "0") & rs_CUBASINF_AddNo("cbi_cusno")
                'ElseIf gsCompany = "UCP" Then
                '    rs_CUBASINF("CBI_CUSNO") = "4" & String(NoOfZeros, "0") & rs_CUBASINF_AddNo("cbi_cusno")
                'End If

                If gsCompanyGroup = "MSG" Then
                    rs_CUBASINF.Tables("RESULT").Rows(0).Item("CBI_CUSNO") = "8" & StrDup(NoOfZeros, "0") & rs_CUBASINF_AddNo.Tables("RESULT").Rows(0).Item("cbi_cusno")
                Else
                    rs_CUBASINF.Tables("RESULT").Rows(0).Item("CBI_CUSNO") = "6" & StrDup(NoOfZeros, "0") & rs_CUBASINF_AddNo.Tables("RESULT").Rows(0).Item("cbi_cusno")
                End If
            Else
                MsgBox("Cannot Gen A New Customer Number, Please Check the database.", vbInformation, gsCompany)
            End If
        End If





    End Function
    Private Function InputIsValid() As Boolean

        InputIsValid = True
        Dim recordcount As Integer
        Dim dr() As DataRow

        '==== CUM00001, Main , TabNo 0 ====
        If Not Add_flag Then
            If Trim(txtCusno.Text) = "" Then
                MsgBox("Please input value")
                Me.BaseTabControl1.SelectedIndex = 0
                txtCusno.Focus()
                InputIsValid = False
                Exit Function
            End If
        End If

        If Trim(txtCusnam.Text) = "" Then
            MsgBox("Please input value")
            Me.BaseTabControl1.SelectedIndex = 0
            txtCusnam.Focus()
            InputIsValid = False
            Exit Function
        End If

        If Trim(txtCussna.Text) = "" Then
            MsgBox("Please input value")
            txtCussna.Focus()
            InputIsValid = False
            Exit Function
        End If

        If optPriCus.Checked = False And optSecCus.Checked = False Then
            MsgBox("Please Select Customer Type")
            InputIsValid = False
            Exit Function
        End If

        If Trim(cboExtGrp.Text) = "" Then
            MsgBox("Please EXT Cust Group")
            Me.BaseTabControl1.SelectedIndex = 0
            cboExtGrp.Focus()
            InputIsValid = False
            Exit Function
        End If

        'If ValidateCombo(cboSalRep) = False Then
        '    Exit Function
        'End If

        If Trim(cboSalTem.Text) = "" Then
            MsgBox("Please input value")
            Me.BaseTabControl1.SelectedIndex = 0
            cboSalTem.Focus()
            InputIsValid = False
            Exit Function
        End If

        If IsDBNull(txtCusAli.Text) Then
            txtCusAli.Text = ""
            'Exit Function
        End If

        'If ValidateCombo(cboCusRat) = False Then
        '    Exit Function
        'End If

        'If cboMrkReg.Text = "" Or ValidateCombo(cboMrkReg) = False Then

        '    MsgBox ("Invalid Market Region, Please select again!")
        '    SSTabCus.Tab = 0                                               ' remark for Not a compulsory field
        '    cboMrkReg.SetFocus
        '    Exit Function
        'End If

        'If ValidateCombo(cboMrkTyp) = False Then
        '    Exit Function
        'End If

        If txtRemark.TextLength > 200 Then
            MsgBox("Remark Exit Field Length")
            Me.BaseTabControl1.SelectedIndex = 0
            txtRemark.Focus()
            InputIsValid = False
            Exit Function
        End If

        ' tab1
        Dim i As Integer

        If rs_CUVENINF.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_CUVENINF.Tables("RESULT").Rows.Count - 1
                If Trim(rs_CUVENINF.Tables("RESULT").Rows(i).Item("cvi_assvid").ToString) = "" And rs_CUVENINF.Tables("RESULT").Rows(i).Item("cvi_assdsc").ToString <> "" Then
                    MsgBox("Please input Assigned Vendor ID")
                    Me.BaseTabControl1.SelectedIndex = 0
                    grdCusVen.Focus()
                    InputIsValid = False
                    Exit Function
                End If
            Next
        End If

        If rs_CUMCOVEN.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_CUMCOVEN.Tables("RESULT").Rows.Count - 1
                If rs_CUMCOVEN.Tables("RESULT").Rows(i).Item("ccv_creusr") <> "~*NEW*~" And rs_CUMCOVEN.Tables("RESULT").Rows(i).Item("ccv_creusr") <> "~*DEL*~" Then

                    If Trim(rs_CUMCOVEN.Tables("RESULT").Rows(i).Item("ccv_ventyp")) = "" Then
                        MsgBox("Please input Vendor Type!")
                        Me.BaseTabControl1.SelectedIndex = 0
                        grdCoVen.Focus()
                        InputIsValid = False
                        Exit Function
                    End If

                    If Trim(rs_CUMCOVEN.Tables("RESULT").Rows(i).Item("ccv_cocde")) = "" Then
                        MsgBox("Please input Company!")
                        Me.BaseTabControl1.SelectedIndex = 0
                        grdCoVen.Focus()
                        InputIsValid = False
                        Exit Function
                    End If


                    If Not IsDate(rs_CUMCOVEN.Tables("RESULT").Rows(i).Item("ccv_effdat")) Then
                        MsgBox("Invalid Effective Date!")
                        Me.BaseTabControl1.SelectedIndex = 0
                        grdCoVen.Focus()
                        InputIsValid = False
                        Exit Function
                    End If
                End If
            Next


            Dim vtyp As String
            Dim dcnt As Integer
            Dim vtyploc As Integer
            vtyp = ""
            dcnt = 0
            vtyploc = 0

            Dim checkDefaultCompany As Boolean
            checkDefaultCompany = True
 
            recordCount = 0

            For i = 0 To rs_CUMCOVEN.Tables("RESULT").Rows.Count - 1

                recordCount = recordCount + 1

            Next

            Dim checkVenTyp As Object
            Dim checkVenDef As Object
            ReDim checkVenTyp(recordCount)
            ReDim checkVenDef(recordCount)

            Dim counter As Integer
            counter = 0

            For counter = 0 To recordCount - 1
                checkVenTyp(counter) = rs_CUMCOVEN.Tables("RESULT").Rows(counter).Item("ccv_ventyp")
                checkVenDef(counter) = rs_CUMCOVEN.Tables("RESULT").Rows(counter).Item("ccv_vendef")
            Next

            Dim counterI As Integer
            Dim counterJ As Integer
            Dim tmpVenTyp As String
            Dim tmpVenDef As String

            counterI = 0
            counterJ = 0
            tmpVenTyp = ""
            tmpVenDef = ""

            For counterI = 0 To recordCount - 1
                dcnt = 0
                tmpVenTyp = checkVenTyp(counterI)
                tmpVenDef = checkVenDef(counterI)

                If (tmpVenDef = "Y") Then
                    dcnt = dcnt + 1
                End If

                For counterJ = 0 To recordCount - 1
                    If (counterI <> counterJ) Then
                        If ((tmpVenTyp = checkVenTyp(counterJ)) And (checkVenDef(counterJ) = "Y")) Then
                            dcnt = dcnt + 1
                        End If
                    End If
                Next counterJ

                If (dcnt <> 1) Then
                    checkDefaultCompany = False
                    If (vtyploc = 0) Then
                        vtyploc = counterI + 1
                    End If
                End If
            Next counterI

            If (checkDefaultCompany) Then
                dcnt = 1
            Else
                dcnt = 0
            End If

            If dcnt = 0 Then
                MsgBox("There must have default company on each vendor type")
                Me.BaseTabControl1.SelectedIndex = 0
                'rs_CUMCOVEN.MoveFirst
                '     Call gotorecord(rs_CUMCOVEN, vtyploc) 'neeeeed?
                grdCoVen.Focus()
                InputIsValid = False
                Exit Function
            End If

        ElseIf optPriCus.Checked = True Then
            MsgBox("There are no Customer and Company Relationship existed, Please Input")
            If grdCoVen.Enabled = True Then
                Me.BaseTabControl1.SelectedIndex = 0
                grdCoVen.Focus()

            End If
            InputIsValid = False
            Exit Function
        End If

        If rs_CUAGTINF.Tables("RESULT").Rows.Count > 0 Then
            If rs_CUAGTINF.Tables("RESULT").Rows.Count > 1 Then
                dr = Nothing
                dr = rs_CUAGTINF.Tables("RESULT").Select("cai_cusdef = 'Y'")
                If dr.Length = 0 Then
                    MsgBox("There is no Default record in Agent Grid") 'm00242
                    grdAgent.Focus()
                    Me.BaseTabControl1.SelectedIndex = 0
                    InputIsValid = False
                    Exit Function
                End If
            End If

            For i = 0 To rs_CUAGTINF.Tables("RESULT").Rows.Count - 1
                If (IsDBNull(rs_CUAGTINF.Tables("RESULT").Rows(i).Item("cai_comrat")) = True) Then
                    MsgBox("Please input Agent Commission Rate")
                    Me.BaseTabControl1.SelectedIndex = 0
                    grdAgent.Focus()
                    InputIsValid = False
                    Exit Function

                End If

                If Trim(rs_CUAGTINF.Tables("RESULT").Rows(i).Item("cai_cusagt") <> "") And rs_CUAGTINF.Tables("RESULT").Rows(i).Item("cai_cusdef") = "Y" And (Trim(rs_CUAGTINF.Tables("RESULT").Rows(i).Item("cai_comrat").ToString <> "")) Then
                    If rs_CUAGTINF.Tables("RESULT").Rows.Count > 1 Then
                        If rs_CUAGTINF.Tables("RESULT").Rows(i).Item("status") = "Y" And rs_CUAGTINF.Tables("RESULT").Rows(i).Item("cai_cusdef") = "Y" Then
                            MsgBox("There is not default record in Agent Grid")
                            Me.BaseTabControl1.SelectedIndex = 0
                            grdAgent.Focus()
                            InputIsValid = False
                            Exit Function
                        End If
                    End If

                    If Trim(rs_CUAGTINF.Tables("RESULT").Rows(i).Item("cai_cusagt") = "") And rs_CUAGTINF.Tables("RESULT").Rows(i).Item("cai_cusdef") = "Y" Then
                        MsgBox("Please input Agent")
                        Me.BaseTabControl1.SelectedIndex = 0
                        InputIsValid = False
                        grdAgent.Focus()
                        Exit Function
                    End If

                    If Trim(rs_CUAGTINF.Tables("RESULT").Rows(i).Item("cai_cusagt")) = "" And _
                    (Trim(rs_CUAGTINF.Tables("RESULT").Rows(i).Item("cai_comrat")) <> "" Or IsDBNull(rs_CUAGTINF.Tables("RESULT").Rows(i).Item("cai_comrat") = False)) Then  '*** Check Agent Name
                        MsgBox("RFO")
                        Me.BaseTabControl1.SelectedIndex = 0
                        grdAgent.Focus()
                        InputIsValid = False
                        Exit Function
                    End If

                    If Trim(rs_CUAGTINF.Tables("RESULT").Rows(i).Item("cai_cusagt")) <> "" And (Trim(rs_CUAGTINF.Tables("RESULT").Rows(i).Item("cai_comrat")) = "" Or _
                        IsDBNull(rs_CUAGTINF.Tables("RESULT").Rows(i).Item("cai_comrat") = True)) Then
                        MsgBox("Please input Agent Commission Rate")
                        Me.BaseTabControl1.SelectedIndex = 0
                        grdAgent.Focus()
                        InputIsValid = False
                        Exit Function
                    End If
                End If
            Next


        End If

        'tab02
        If optPriCus.Checked = True Then
            If txtComAdr.Text = "" Then
                MsgBox("Please input value")
                Me.BaseTabControl1.SelectedIndex = 1
                txtComAdr.Focus()
                InputIsValid = False
                Exit Function
            End If
        End If

        If Trim(cboCountry.Text) = "" Then
            MsgBox("Please input value")
            Me.BaseTabControl1.SelectedIndex = 1
            cboCountry.Focus()
            InputIsValid = False
            Exit Function
        End If

        If rs_CUCNTINF_B.Tables("RESULT").Rows.Count > 0 Then   '*** Check the Address field is not empty
            For i = 0 To rs_CUCNTINF_B.Tables("RESULT").Rows.Count - 1
                If Trim(rs_CUCNTINF_B.Tables("RESULT").Rows(i).Item("cci_cntadr")) = "" And rs_CUCNTINF_B.Tables("RESULT").Rows(i).Item("cci_cntdef") = "Y" Then
                    Me.BaseTabControl1.SelectedIndex = 1
                    grdBilling.Focus()
                    MsgBox("Please input Address")
                    InputIsValid = False
                    Exit Function
                Else

                End If
            Next
        End If

        If rs_CUCNTINF_B.Tables("RESULT").Rows.Count > 0 Then
            dr = Nothing
            dr = rs_CUCNTINF_B.Tables("RESULT").Select("cci_cntdef = 'Y'")
            If dr.Length = 0 Then
                MsgBox("There are no default Billing Address! Please select.")
                grdBilling.Focus()
                InputIsValid = False
                Exit Function

            Else



            End If
        End If

        If rs_CUCNTINF_S.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_CUCNTINF_S.Tables("RESULT").Rows.Count - 1
                If Trim(rs_CUCNTINF_S.Tables("RESULT").Rows(i).Item("cci_cntadr")) = "" And rs_CUCNTINF_S.Tables("RESULT").Rows(i).Item("cci_cntdef") = "Y" Then
                    Me.BaseTabControl1.SelectedIndex = 1
                    grdShipping.Focus()
                    MsgBox("Please input Address")
                    InputIsValid = False
                    Exit Function
                End If
            Next
        End If
        If rs_CUCNTINF_S.Tables("RESULT").Rows.Count > 0 Then
            dr = Nothing
            dr = rs_CUCNTINF_S.Tables("RESULT").Select("cci_cntdef = 'Y'")
            If rs_CUCNTINF_S.Tables("RESULT").Rows.Count = 0 Then
                MsgBox("There are no default Shipping Address! Please select.")
                grdShipping.Focus()
                InputIsValid = False
                Exit Function
            Else
            End If
        End If

        If rs_CUCNTINF_C.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_CUCNTINF_C.Tables("RESULT").Rows.Count - 1
                If (Trim(rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("cci_cnttyp").ToString) <> "" Or IsDBNull(rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("cci_cnttyp").ToString) = False) _
                    And (Trim(rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("cci_cntctp").ToString) = "" Or IsDBNull(rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("cci_cntctp").ToString) = True) _
                    And rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("status").ToString = "" Then
                    Me.BaseTabControl1.SelectedIndex = 2
                    MsgBox("Please input Contact Person")
                    grdContact.Focus()
                    InputIsValid = False
                    Exit Function
                End If

                If (Trim(rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("cci_cnttyp")) = "" Or IsDBNull(rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("cci_cnttyp")) = True) _
                And (Trim(rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("cci_cntctp")) <> "" Or IsDBNull(rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("cci_cntctp")) = False) Then
                    Me.BaseTabControl1.SelectedIndex = 2
                    MsgBox("Please select Nature")
                    grdContact.Focus()
                    InputIsValid = False
                    Exit Function
                End If

                If (Trim(rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("cci_cnttyp")) = "" Or _
                    IsDBNull(rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("cci_cnttyp")) = True) And _
                    (rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("cci_cntctp").ToString <> "" Or _
                     rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("cci_cntctp").ToString <> "" Or _
                     rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("cci_cntphn").ToString <> "" Or _
                     rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("cci_cntfax").ToString <> "" Or _
                     rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("cci_cnteml").ToString <> "") Then
                    Me.BaseTabControl1.SelectedIndex = 2
                    MsgBox("Please select Nature")
                    grdContact.Focus()
                    InputIsValid = False
                    Exit Function
                End If

            Next

        End If


        recordcount = 0

        If (rs_CUCNTINF_C.Tables("RESULT").Rows.Count > 0) Then
            For i = 0 To rs_CUCNTINF_C.Tables("RESULT").Rows.Count - 1
                recordcount = recordcount + 1
            Next

            Dim cnttyp As Object
            Dim cntdef As Object
            ReDim cnttyp(recordcount)
            ReDim cntdef(recordcount)

            Dim defcnt As Integer
            Dim counter As Integer

            counter = 0

            For counter = 0 To recordcount - 1
                cnttyp(counter) = rs_CUCNTINF_C.Tables("RESULT").Rows(counter).Item("cci_cnttyp")
                cntdef(counter) = rs_CUCNTINF_C.Tables("RESULT").Rows(counter).Item("cci_cntdef")

            Next

            Dim tmpCntTyp As String
            Dim tmpCntDef As String
            Dim counterI As Integer
            Dim counterJ As Integer

            counterI = 0
            counterJ = 0
            tmpCntTyp = ""
            tmpCntDef = ""

            For counterI = 0 To recordcount - 1
                defcnt = 0
                tmpCntTyp = cnttyp(counterI)
                tmpCntDef = cntdef(counterI)

                If (tmpCntDef = "Y") Then
                    defcnt = defcnt + 1
                End If

                For counterJ = 0 To recordcount - 1
                    If (counterI <> counterJ) Then
                        If ((tmpCntTyp = cnttyp(counterJ)) And (cntdef(counterJ) = "Y")) Then
                            defcnt = defcnt + 1
                        End If
                    End If
                Next

                If defcnt = 0 Then
                    MsgBox("There is no default Contact Information!")
                    grdContact.Focus()
                    InputIsValid = False
                    Exit Function
                ElseIf defcnt > 1 Then
                    MsgBox("There is only one default Contact allowed!")
                    grdContact.Focus()
                    InputIsValid = False
                    Exit Function
                End If
            Next


        End If

        If optSecCus.Checked = True Then
            If optMarkup.Checked = True And txtgrsMgn.Text = "" Then
                txtgrsMgn.Text = "0"
            End If
        End If
        If optPriCus.Checked = True Then
            'If Trim(cboPrcTrm.Text) = "" Then
            '    Me.BaseTabControl1.SelectedIndex = 3
            '    MsgBox("Please input value")
            '    cboPrcTrm.Focus()
            '    InputIsValid = False
            '    Exit Function
            'End If

            If rs_CUPRCTRM.Tables("RESULT").Rows.Count = 0 Then
                Me.BaseTabControl1.SelectedIndex = 3
                MsgBox("Please input Price term(s)")
                grdPrctrm.Focus()
                InputIsValid = False
                Exit Function

           

            Else

                For i = 0 To rs_CUPRCTRM.Tables("RESULT").Rows.Count - 1
                    If Trim(rs_CUPRCTRM.Tables("RESULT").Rows(i).Item("cpt_prctrm")) = "" Then
                        Me.BaseTabControl1.SelectedIndex = 3
                        MsgBox("Please input Price term(s)")
                        grdPrctrm.Focus()
                        InputIsValid = False
                        Exit Function
                    End If
                Next
            End If

            If Trim(cboPayTrm.Text) = "" Then
                Me.BaseTabControl1.SelectedIndex = 3
                MsgBox("Please input value")
                cboPayTrm.Focus()
                InputIsValid = False
                Exit Function
            End If


            If Trim(cboProTrm.Text) = "" Then
                Me.BaseTabControl1.SelectedIndex = 3
                MsgBox("Please input value")
                cboProTrm.Focus()
                InputIsValid = False
                Exit Function
            End If

            If Trim(cboFrgTrm.Text) = "" Then
                Me.BaseTabControl1.SelectedIndex = 3
                MsgBox("Please input value")
                cboFrgTrm.Focus()
                InputIsValid = False
                Exit Function
            End If


            If Trim(cboCurcde.Text) = "" Then
                Me.BaseTabControl1.SelectedIndex = 3
                MsgBox("Please input value")
                cboCurcde.Focus()
                InputIsValid = False
                Exit Function
            End If
        End If


        Dim j As Integer
        Dim cancelbuf As Integer
        Dim shpendbuf As Integer
        Dim showfirst As Boolean
        showfirst = True

        For j = 0 To rs_CUSHPFML.Tables("RESULT").Rows.Count - 1
            cancelbuf = rs_CUSHPFML.Tables("RESULT").Rows(j).Item("csf_cancelbuf")
            shpendbuf = rs_CUSHPFML.Tables("RESULT").Rows(j).Item("csf_shpendbuf")
            If cancelbuf > shpendbuf And showfirst = True Then
                If MsgBox("Cancel Date Buffer is greater than Ship End Buffer, Are you sure?", 260) = MsgBoxResult.No Then
                    Me.BaseTabControl1.SelectedIndex = 3
                    InputIsValid = False
                    Exit Function
                End If
                showfirst = False
            End If

        Next j

        'If Trim(txtquplus.Text) = "" Then
        '    Me.BaseTabControl1.SelectedIndex = 3
        '    MsgBox("Quotation Approval cannot empty!")
        '    txtquplus.Focus()
        '    InputIsValid = False
        '    Exit Function
        'End If

        'If Trim(txtquminus.Text) = "" Then
        '    Me.BaseTabControl1.SelectedIndex = 3
        '    MsgBox("Quotation Approval cannot empty!")
        '    txtquminus.Focus()
        '    InputIsValid = False
        '    Exit Function
        'End If

        'tab03 
        'dr = Nothing
        'dr = rs_CUMCAMRK.Tables("RESULT").Select("ccm_del <> 'Y'")
        'If optPriCus.Checked = True Then
        '    If rs_CUMCAMRK.Tables("RESULT").Rows.Count = 0 Then
        '        MsgBox("There are no Category markup existed, Please input at least one STANDARD Markup for Vendor Type")
        '        Me.BaseTabControl1.SelectedIndex = 3
        '        grdItmCatMarkup.Focus()
        '        InputIsValid = False
        '        Exit Function
        '    End If

        '    For i = 0 To rs_CUMCAMRK.Tables("RESULT").Rows.Count - 1
        '        If (rs_CUMCAMRK.Tables("RESULT").Rows(i).Item("ccm_ventyp").ToString = "" Or _
        '            rs_CUMCAMRK.Tables("RESULT").Rows(i).Item("ccm_cat").ToString = "" Or _
        '             rs_CUMCAMRK.Tables("RESULT").Rows(i).Item("ccm_markupfml").ToString = "" Or _
        '             IsDBNull(rs_CUMCAMRK.Tables("RESULT").Rows(i).Item("ccm_effdat")) = True) And _
        '            rs_CUMCAMRK.Tables("RESULT").Rows(i).Item("ccm_del").ToString <> "Y" Then
        '            MsgBox("Incomplete Item Category Markup Data!")
        '            Me.BaseTabControl1.SelectedIndex = 3
        '            InputIsValid = False
        '            Exit Function
        '        End If

        '    Next


        '    If rs_CUMCOVEN.Tables("RESULT").Rows.Count > 0 Then
        '        For i = 0 To rs_CUMCOVEN.Tables("RESULT").Rows.Count - 1
        '            dr = rs_CUMCAMRK.Tables("RESULT").Select("ccm_ventyp = '" & rs_CUMCOVEN.Tables("RESULT").Rows(i).Item("ccv_ventyp") & "'" & " and ccm_cat = 'STANDARD' and ccm_del <> 'Y'")
        '            If dr.Length = 0 Then
        '                MsgBox("Missing Category Markup for " & rs_CUMCOVEN.Tables("RESULT").Rows(i).Item("ccv_ventyp") & " Vendor Type, STANDARD markup must exist")

        '                Me.BaseTabControl1.SelectedIndex = 3
        '                grdItmCatMarkup.Focus()
        '                InputIsValid = False
        '                Exit Function

        '            End If

        '        Next

        '    End If
        'End If





    End Function

    Public Function func_SaveRecordset() As Boolean  'seesave
        func_SaveRecordset = True

        If save_CUBASINF() = False Then
            func_SaveRecordset = False
            Exit Function
        End If

        If save_CUVENINF() = False Then
            func_SaveRecordset = False
            Exit Function
        End If

        If save_CUMCOVEN() = False Then
            func_SaveRecordset = False
            Exit Function
        End If

        If save_CUAGTINF() = False Then
            func_SaveRecordset = False
            Exit Function
        End If

        If save_CUPRCINF() = False Then
            func_SaveRecordset = False
            Exit Function
        End If

        'If save_CUMCAMRK() = False Then
        '    func_SaveRecordset = False
        '    Exit Function
        'End If


        If save_CUBCR() = False Then
            func_SaveRecordset = False
            Exit Function
        End If


        If save_CUSHPINF() = False Then
            func_SaveRecordset = False
            Exit Function
        End If

        If save_CUSHPINF_C() = False Then
            func_SaveRecordset = False
            Exit Function
        End If


        If save_CUCNTINF() = False Then
            func_SaveRecordset = False
            Exit Function
        End If

        If save_CUCNTINF_B() = False Then
            func_SaveRecordset = False
            Exit Function
        End If

        If save_CUCNTINF_S() = False Then
            func_SaveRecordset = False
            Exit Function
        End If

        If save_CUCNTINF_C() = False Then
            func_SaveRecordset = False
            Exit Function
        End If


        If save_CUSHPMRK() = False Then 'c
            func_SaveRecordset = False
            Exit Function

        End If

        If save_CUSUBCUS_P() = False Then ''problem '1'o
            func_SaveRecordset = False
            Exit Function
        End If

        If save_CUPRCTRM() = False Then
            func_SaveRecordset = False
            Exit Function
        End If

        If save_CUSHPFML() = False Then
            func_SaveRecordset = False
            Exit Function
        End If

    End Function

    Private Function save_CUPRCTRM() As Boolean
        If rs_CUPRCTRM.Tables("RESULT").Rows.Count = 0 Then
            save_CUPRCTRM = True
            Exit Function
        End If


        Dim cpt_cocde As String
        Dim cpt_cusno As String
        Dim cpt_prctrm As String
        Dim cpt_prcdef As String
        Dim cpt_creusr As String
        IsUpdated = False

        Dim i As Integer

        For i = 0 To rs_CUPRCTRM.Tables("RESULT").Rows.Count - 1
            cpt_cocde = rs_CUPRCTRM.Tables("RESULT").Rows(i).Item("cpt_cocde").ToString
            cpt_cusno = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cusno").ToString
            cpt_prctrm = Split(rs_CUPRCTRM.Tables("RESULT").Rows(i).Item("cpt_prctrm").ToString, " - ")(0)
            cpt_prcdef = rs_CUPRCTRM.Tables("RESULT").Rows(i).Item("cpt_prcdef").ToString
            cpt_creusr = rs_CUPRCTRM.Tables("RESULT").Rows(i).Item("cpt_creusr").ToString

            If (cpt_creusr = "~*ADD*~" Or copyflag = True) Then

                gspStr = "sp_insert_CUPRCTRM '','" & cpt_cusno & "','" & cpt_prctrm & "','" & cpt_prcdef & "','" & gsUsrID & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUPRCTRM sp_insert_CUPRCTRM:" & rtnStr)
                    save_CUPRCTRM = False
                    Exit Function

                End If


            ElseIf cpt_creusr = "~*UPD*~" Then

                gspStr = "sp_update_CUPRCTRM '" & "" & "','" & cpt_cusno & "','" & cpt_prcdef & "','" & _
                                                   cpt_prctrm & "','" & gsUsrID & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUPRCTRM sp_update_CUPRCTRM :" & rtnStr)
                    save_CUPRCTRM = False
                    Exit Function
                End If


            ElseIf cpt_creusr = "~*DEL*~" Then

                gspStr = "sp_physical_delete_CUPRCTRM '','" & cpt_cusno & "','" & cpt_prctrm & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUPRCTRM sp_physical_delete_CUPRCTRM:" & rtnStr)
                    save_CUPRCTRM = False
                    Exit Function

                End If


            End If

        Next

        save_CUPRCTRM = True
        IsUpdated = True

    End Function

    Private Function save_CUBCR() As Boolean

        If rs_CUBCR.Tables("RESULT").Rows.Count = 0 Then
            save_CUBCR = True
            Exit Function
        End If


        Dim dummy As String
        Dim mode As String
        Dim cbc_cocde As String
        Dim cbc_cusno As String
        Dim cbc_rsklmt As Integer
        Dim cbc_rskuse As Integer
        Dim cbc_cdtlmt As Integer
        Dim cbc_cdtuse As Integer
        Dim cbc_curcde As String
        Dim cbc_creusr As String
        Dim cbc_updprg As String
        IsUpdated = False

        Dim i As Integer

        For i = 0 To rs_CUBCR.Tables("RESULT").Rows.Count - 1
            dummy = ""
            mode = "ONE"
            cbc_cocde = rs_CUBCR.Tables("RESULT").Rows(i).Item("cbc_cocde").ToString
            cbc_cusno = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cusno").ToString
            cbc_rsklmt = rs_CUBCR.Tables("RESULT").Rows(i).Item("cbc_rsklmt")
            cbc_rskuse = rs_CUBCR.Tables("RESULT").Rows(i).Item("cbc_rskuse")
            cbc_cdtlmt = rs_CUBCR.Tables("RESULT").Rows(i).Item("cbc_cdtlmt")
            cbc_cdtuse = rs_CUBCR.Tables("RESULT").Rows(i).Item("cbc_cdtuse")
            cbc_curcde = Split(cboCurcde.Text, "-")(0)
            cbc_creusr = rs_CUBCR.Tables("RESULT").Rows(i).Item("cbc_creusr")

            If copyflag = True Then
                cbc_rskuse = 0
                cbc_cdtuse = 0
            End If



            If (cbc_creusr = "~*ADD*~" Or copyflag = True) Then


                gspStr = "sp_insert_CUBCR '" & dummy & "','" & mode & "','" & cbc_cocde & "','" & cbc_cusno & "'," & _
                      cbc_rsklmt & "," & cbc_rskuse & "," & cbc_cdtlmt & "," & cbc_cdtuse & ",'" & _
                      cbc_curcde & "','" & gsUsrID & "','" & Me.Name & "'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUBCR sp_insert_CUBCR :" & rtnStr)
                    save_CUBCR = False
                    Exit Function
                End If


            ElseIf cbc_creusr = "~*UPD*~" Then

                gspStr = "sp_update_CUBCR '" & dummy & "','" & mode & "','" & cbc_cocde & "','" & cbc_cusno & "'," & _
                      cbc_rsklmt & "," & cbc_rskuse & "," & cbc_cdtlmt & "," & cbc_cdtuse & ",'" & _
                      cbc_curcde & "','" & gsUsrID & "','" & Me.Name & "'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUBCR sp_update_CUBCR :" & rtnStr)
                    save_CUBCR = False
                    Exit Function
                End If

            ElseIf cbc_creusr = "~*DEL*~" Then

                gspStr = "sp_physical_delete_CUBCR '" & dummy & "','" & cbc_cocde & "','" & cbc_cusno & "'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUBCR sp_physical_delete_CUBCR :" & rtnStr)
                    save_CUBCR = False
                    Exit Function
                End If

            End If





        Next
        save_CUBCR = True
        IsUpdated = True


    End Function

    Private Function save_CUSHPMRK() As Boolean

        If rs_CUSHPMRK.Tables("RESULT").Rows.Count = 0 Then
            save_CUSHPMRK = True
            Exit Function
        End If

        Dim csm_cocde As String
        Dim csm_cusno As String
        Dim csm_custyp As String
        Dim csm_shptyp As String
        Dim csm_engdsc As String
        Dim csm_chndsc As String
        Dim csm_engrmk As String
        Dim csm_chnrmk As String
        Dim csm_imgpth As String
        Dim csm_imgnam As String
        Dim csm_cerdoc As String
        Dim csm_creusr As String
        Dim csm_seqno As Integer
        IsUpdated = False
        Dim i As Integer



        For i = 0 To rs_CUSHPMRK.Tables("RESULT").Rows.Count - 1

            csm_cocde = ""
            csm_cusno = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cusno").ToString
            csm_custyp = CusTyp
            csm_shptyp = Replace(rs_CUSHPMRK.Tables("RESULT").Rows(i).Item("csm_shptyp").ToString, "'", "''")
            csm_engdsc = Replace(rs_CUSHPMRK.Tables("RESULT").Rows(i).Item("csm_engdsc").ToString, "'", "''")
            csm_chndsc = Replace(rs_CUSHPMRK.Tables("RESULT").Rows(i).Item("csm_chndsc").ToString, "'", "''")
            csm_engrmk = Replace(rs_CUSHPMRK.Tables("RESULT").Rows(i).Item("csm_engrmk").ToString, "'", "''")
            csm_chnrmk = Replace(rs_CUSHPMRK.Tables("RESULT").Rows(i).Item("csm_chnrmk").ToString, "'", "''")
            csm_imgpth = Replace(rs_CUSHPMRK.Tables("RESULT").Rows(i).Item("csm_imgpth").ToString, "'", "''")
            csm_imgnam = Replace(rs_CUSHPMRK.Tables("RESULT").Rows(i).Item("csm_imgnam").ToString, "'", "''")
            csm_cerdoc = Replace(rs_CUSHPMRK.Tables("RESULT").Rows(i).Item("csm_cerdoc").ToString, "'", "''")
            csm_creusr = rs_CUSHPMRK.Tables("RESULT").Rows(i).Item("csm_creusr").ToString
            csm_seqno = rs_CUSHPMRK.Tables("RESULT").Rows(i).Item("csm_seqno")
            gspStr = ""

            If csm_creusr = "~*ADD*~" Then  '''''''''''''''''''''Copy flag
                gspStr = "sp_insert_CUSHPMRK '" & csm_cocde & "','" & csm_cusno & "','" & csm_custyp & "','" _
                & csm_shptyp & "','" & csm_engdsc & "','" & csm_chndsc & "','" & csm_engrmk & "','" & csm_chnrmk _
                & "','" & csm_imgpth & "','" & csm_imgnam & "','" & csm_cerdoc & "','" & gsUsrID & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUSHPMRK sp_insert_CUSHPMRK:" & rtnStr)
                    save_CUSHPMRK = False
                    Exit Function

                End If

            ElseIf csm_creusr = "~*UPD*~" Then

                gspStr = "sp_update_CUSHPMRK '" & csm_cocde & "','" & csm_cusno & "'," & csm_seqno & ",'" & csm_custyp & "','" _
                & csm_shptyp & "','" & csm_engdsc & "','" & csm_chndsc & "','" & csm_engrmk & "','" & csm_chnrmk _
                & "','" & csm_imgpth & "','" & csm_imgnam & "','" & csm_cerdoc & "','" & gsUsrID & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUSHPMRK sp_update_CUSHPMRK:" & rtnStr)
                    save_CUSHPMRK = False
                    Exit Function

                End If

            ElseIf csm_creusr = "~*DEL*~" Then

                gspStr = "sp_physical_delete_CUSHPMRK '" & csm_cocde & "','" & csm_cusno & "','" & csm_shptyp & "'," & csm_seqno & ",'" & "DDtl" & "'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUSHPMRK sp_physical_delete_CUSHPMRK:" & rtnStr)
                    save_CUSHPMRK = False
                    Exit Function

                End If


            End If












        Next i


        save_CUSHPMRK = True
        IsUpdated = True
    End Function


    Private Function save_CUSUBCUS_P() As Boolean

        If rs_CUSUBCUS_P.Tables("RESULT").Rows.Count = 0 Then
            save_CUSUBCUS_P = True
            Exit Function
        End If


        Dim csc_cocde As String
        Dim csc_prmcus As String
        Dim csc_seccus As String
        Dim csc_cusrel As String
        Dim csc_creusr As String
        IsUpdated = False
        Dim i As Integer

        For i = 0 To rs_CUSUBCUS_P.Tables("RESULT").Rows.Count - 1
            If optPriCus.Checked = True Then
                csc_cocde = ""
                csc_prmcus = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cusno").ToString
                csc_seccus = rs_CUSUBCUS_P.Tables("RESULT").Rows(i).Item("csc_seccus").ToString
                csc_cusrel = Microsoft.VisualBasic.Left(rs_CUSUBCUS_P.Tables("RESULT").Rows(i).Item("csc_cusrel").ToString, 1)
                csc_creusr = rs_CUSUBCUS_P.Tables("RESULT").Rows(i).Item("csc_creusr").ToString
                
            ElseIf optSecCus.Checked = True Then
                csc_cocde = ""
                csc_prmcus = rs_CUSUBCUS_P.Tables("RESULT").Rows(i).Item("csc_prmcus").ToString
                csc_seccus = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cusno").ToString
                csc_cusrel = Microsoft.VisualBasic.Left(rs_CUSUBCUS_P.Tables("RESULT").Rows(i).Item("csc_cusrel").ToString, 1)
                csc_creusr = rs_CUSUBCUS_P.Tables("RESULT").Rows(i).Item("csc_creusr").ToString
               
            End If


            gspStr = ""

            If csc_creusr = "~*ADD*~" And csc_prmcus <> "" And csc_seccus <> "" Then  '''''''''''''''''''''Copy flag
                gspStr = "sp_insert_CUSUBCUS '" & csc_cocde & "','" & csc_prmcus & "','" & csc_seccus & "','" _
                & csc_cusrel & "','" & gsUsrID & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUSUBCUS_P sp_insert_CUSUBCUS:" & rtnStr)
                    save_CUSUBCUS_P = False
                    Exit Function

                End If

            ElseIf csc_creusr = "~*UPD*~" And csc_prmcus <> "" And csc_seccus <> "" Then

                gspStr = "sp_update_CUSUBCUS '" & csc_cocde & "','" & csc_prmcus & "','" & csc_seccus & "','" _
                & csc_cusrel & "','" & gsUsrID & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUSUBCUS_P sp_update_CUSUBCUS:" & rtnStr)
                    save_CUSUBCUS_P = False
                    Exit Function

                End If


            ElseIf csc_creusr = "~*DEL*~" Then

                gspStr = "sp_physical_delete_CUSUBCUS '" & csc_cocde & "','" & csc_prmcus & "','" & csc_seccus & "','DDtl'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUSUBCUS_P sp_physical_delete_CUSUBCUS:" & rtnStr)
                    save_CUSUBCUS_P = False
                    Exit Function

                End If



            End If












        Next i


        save_CUSUBCUS_P = True
        IsUpdated = True
    End Function


    Private Function save_CUCNTINF_C() As Boolean



        If rs_CUCNTINF_C.Tables("RESULT").Rows.Count = 0 Then
            save_CUCNTINF_C = True
            Exit Function
        End If

        Dim cci_cocde As String
        Dim cci_cusno As String
        Dim cci_cnttyp As String
        Dim cci_cntadr As String
        Dim cci_cntstt As String
        Dim cci_cntcty As String
        Dim cci_cntpst As String
        Dim cci_cntctp As String
        Dim cci_cnttil As String
        Dim cci_cntphn As String
        Dim cci_cntfax As String
        Dim cci_cnteml As String
        Dim cci_cntrmk As String
        Dim cci_cntdef As String
        Dim cci_creusr As String

        Dim cci_cntseq As Integer
        IsUpdated = False

        Dim i As Integer

        For i = 0 To rs_CUCNTINF_C.Tables("RESULT").Rows.Count - 1

            cci_cocde = ""
            cci_cusno = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cusno").ToString
            cci_cnttyp = rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("cci_cnttyp").ToString
            cci_cntadr = ""

            cci_cntcty = ""

            cci_cntpst = ""
            cci_cntctp = Replace(rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("cci_cntctp").ToString, "'", "''")
            cci_cnttil = Replace(rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("cci_cnttil").ToString, "'", "''")
            cci_cntphn = Replace(rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("cci_cntphn").ToString, "'", "''")
            cci_cntfax = Replace(rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("cci_cntfax").ToString, "'", "''")
            cci_cnteml = Replace(rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("cci_cnteml").ToString, "'", "''")
            cci_cntrmk = ""
            cci_cntdef = rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("cci_cntdef").ToString
            cci_creusr = rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("cci_creusr").ToString
            cci_cntseq = rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("cci_cntseq")

            If (cci_creusr = "~*ADD*~" Or copyflag = True) And cci_cnttyp <> "" Then  '''''''''''''''''''''Copy flag

                gspStr = "sp_insert_CUCNTINF '" & cci_cocde & "','" & cci_cusno & "','" & cci_cnttyp & "','" & cci_cntadr & "','" & _
                                cci_cntstt & "','" & cci_cntcty & "','" & cci_cntpst & "','" & cci_cntctp & "','" & cci_cnttil & "','" & _
                          cci_cntphn & "','" & cci_cntfax & "','" & cci_cnteml & "','" & cci_cntrmk & "','" & cci_cntdef & "','" & gsUsrID & "'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUCNTINF_C sp_insert_CUCNTINF :" & rtnStr)
                    save_CUCNTINF_C = False
                    Exit Function
                End If


            ElseIf cci_creusr = "~*UPD*~" And cci_cnttyp <> "" Then


                gspStr = "sp_update_CUCNTINF '" & cci_cocde & "','" & cci_cusno & "'," & cci_cntseq & ",'" & cci_cnttyp & "','" & cci_cntadr & "','" & _
                                cci_cntstt & "','" & cci_cntcty & "','" & cci_cntpst & "','" & cci_cntctp & "','" & cci_cnttil & "','" & _
                          cci_cntphn & "','" & cci_cntfax & "','" & cci_cnteml & "','" & cci_cntrmk & "','" & cci_cntdef & "','" & gsUsrID & "','C'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUCNTINF_C sp_update_CUCNTINF :" & rtnStr)
                    save_CUCNTINF_C = False
                    Exit Function
                End If


            ElseIf cci_creusr = "~*DEL*~" Then


                gspStr = "sp_physical_delete_CUCNTINF '" & cci_cocde & "','" & cci_cusno & "','" & cci_cnttyp & "'," & cci_cntseq & ",'" & "DDtl" & "'"


                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUCNTINF_S sp_physical_delete_CUCNTINF :" & rtnStr)
                    save_CUCNTINF_C = False
                    Exit Function
                End If




            End If





        Next
        save_CUCNTINF_C = True
        IsUpdated = True






    End Function


    Private Function save_CUCNTINF_S() As Boolean



        If rs_CUCNTINF_S.Tables("RESULT").Rows.Count = 0 Then
            save_CUCNTINF_S = True
            Exit Function
        End If

        Dim cci_cocde As String
        Dim cci_cusno As String
        Dim cci_cnttyp As String
        Dim cci_cntadr As String
        Dim cci_cntstt As String
        Dim cci_cntcty As String
        Dim cci_cntpst As String
        Dim cci_cntctp As String
        Dim cci_cnttil As String
        Dim cci_cntphn As String
        Dim cci_cntfax As String
        Dim cci_cnteml As String
        Dim cci_cntrmk As String
        Dim cci_cntdef As String
        Dim cci_creusr As String
        Dim cci_cntseq As String

        IsUpdated = False

        Dim i As Integer

        For i = 0 To rs_CUCNTINF_S.Tables("RESULT").Rows.Count - 1

            cci_cocde = ""
            cci_cusno = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cusno").ToString
            cci_cnttyp = "S"
            cci_cntadr = Replace(rs_CUCNTINF_S.Tables("RESULT").Rows(i).Item("cci_cntadr").ToString, "'", "''")
            cci_cntstt = Replace(rs_CUCNTINF_S.Tables("RESULT").Rows(i).Item("cci_cntstt").ToString, "'", "''")
            If UBound(Split(rs_CUCNTINF_S.Tables("RESULT").Rows(i).Item("cci_cntcty").ToString, " - ")) < 0 Then
                cci_cntcty = ""
            Else
                cci_cntcty = Split(rs_CUCNTINF_S.Tables("RESULT").Rows(i).Item("cci_cntcty").ToString, " - ")(0)
            End If

            cci_cntpst = Replace(rs_CUCNTINF_S.Tables("RESULT").Rows(i).Item("cci_cntpst").ToString, "'", "''")
            cci_cntctp = ""
            cci_cnttil = ""
            cci_cntphn = ""
            cci_cntfax = ""
            cci_cnteml = ""
            cci_cntrmk = ""
            cci_cntdef = rs_CUCNTINF_S.Tables("RESULT").Rows(i).Item("cci_cntdef").ToString
            cci_creusr = rs_CUCNTINF_S.Tables("RESULT").Rows(i).Item("cci_creusr").ToString
            cci_cntseq = rs_CUCNTINF_S.Tables("RESULT").Rows(i).Item("cci_cntseq").ToString

            If (cci_creusr = "~*ADD*~" Or copyflag = True) And cci_cntadr <> "" Then  '''''''''''''''''''''Copy flag

                gspStr = "sp_insert_CUCNTINF '" & cci_cocde & "','" & cci_cusno & "','" & cci_cnttyp & "','" & cci_cntadr & "','" & _
                                cci_cntstt & "','" & cci_cntcty & "','" & cci_cntpst & "','" & cci_cntctp & "','" & cci_cnttil & "','" & _
                          cci_cntphn & "','" & cci_cntfax & "','" & cci_cnteml & "','" & cci_cntrmk & "','" & cci_cntdef & "','" & gsUsrID & "'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUCNTINF_S sp_insert_CUCNTINF :" & rtnStr)
                    save_CUCNTINF_S = False
                    Exit Function
                End If


            ElseIf cci_creusr = "~*UPD*~" And cci_cntadr <> "" Then

                gspStr = "sp_update_CUCNTINF '" & cci_cocde & "','" & cci_cusno & "'," & cci_cntseq & ",'" & cci_cnttyp & "','" & cci_cntadr & "','" & _
                                cci_cntstt & "','" & cci_cntcty & "','" & cci_cntpst & "','" & cci_cntctp & "','" & cci_cnttil & "','" & _
                          cci_cntphn & "','" & cci_cntfax & "','" & cci_cnteml & "','" & cci_cntrmk & "','" & cci_cntdef & "','" & gsUsrID & "','S'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUCNTINF_S sp_update_CUCNTINF :" & rtnStr)
                    save_CUCNTINF_S = False
                    Exit Function
                End If

            ElseIf cci_creusr = "~*DEL*~" Then

                gspStr = "sp_physical_delete_CUCNTINF '" & cci_cocde & "','" & cci_cusno & "','" & cci_cnttyp & "'," & cci_cntseq & ",'" & "DDtl" & "'"


                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUCNTINF_S sp_physical_delete_CUCNTINF :" & rtnStr)
                    save_CUCNTINF_S = False
                    Exit Function
                End If

            End If





        Next
        save_CUCNTINF_S = True
        IsUpdated = True






    End Function



    Private Function save_CUCNTINF_B() As Boolean



        If rs_CUCNTINF_B.Tables("RESULT").Rows.Count = 0 Then
            save_CUCNTINF_B = True
            Exit Function
        End If

        Dim cci_cocde As String
        Dim cci_cusno As String
        Dim cci_cnttyp As String
        Dim cci_cntadr As String
        Dim cci_cntstt As String
        Dim cci_cntcty As String
        Dim cci_cntpst As String
        Dim cci_cntctp As String
        Dim cci_cnttil As String
        Dim cci_cntphn As String
        Dim cci_cntfax As String
        Dim cci_cnteml As String
        Dim cci_cntrmk As String
        Dim cci_cntdef As String
        Dim cci_creusr As String
        Dim cci_cntseq As Integer
        IsUpdated = False

        Dim i As Integer

        For i = 0 To rs_CUCNTINF_B.Tables("RESULT").Rows.Count - 1

            cci_cocde = ""
            cci_cusno = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cusno").ToString
            cci_cnttyp = "B"
            cci_cntadr = Replace(rs_CUCNTINF_B.Tables("RESULT").Rows(i).Item("cci_cntadr").ToString, "'", "''")
            cci_cntstt = Replace(rs_CUCNTINF_B.Tables("RESULT").Rows(i).Item("cci_cntstt").ToString, "'", "''")
            If UBound(Split(rs_CUCNTINF_B.Tables("RESULT").Rows(i).Item("cci_cntcty").ToString, " - ")) < 0 Then
                cci_cntcty = ""
            Else
                cci_cntcty = Split(rs_CUCNTINF_B.Tables("RESULT").Rows(i).Item("cci_cntcty").ToString, " - ")(0)
            End If

            cci_cntpst = Replace(rs_CUCNTINF_B.Tables("RESULT").Rows(i).Item("cci_cntpst").ToString, "'", "''")
            cci_cntctp = ""
            cci_cnttil = ""
            cci_cntphn = ""
            cci_cntfax = ""
            cci_cnteml = ""
            cci_cntrmk = ""
            cci_cntdef = rs_CUCNTINF_B.Tables("RESULT").Rows(i).Item("cci_cntdef").ToString
            cci_creusr = rs_CUCNTINF_B.Tables("RESULT").Rows(i).Item("cci_creusr").ToString
            cci_cntseq = rs_CUCNTINF_B.Tables("RESULT").Rows(i).Item("cci_cntseq")

            If (cci_creusr = "~*ADD*~" Or copyflag = True) And cci_cntadr <> "" Then  '''''''''''''''''''''Copy flag

                gspStr = "sp_insert_CUCNTINF '" & cci_cocde & "','" & cci_cusno & "','" & cci_cnttyp & "','" & cci_cntadr & "','" & _
                                cci_cntstt & "','" & cci_cntcty & "','" & cci_cntpst & "','" & cci_cntctp & "','" & cci_cnttil & "','" & _
                          cci_cntphn & "','" & cci_cntfax & "','" & cci_cnteml & "','" & cci_cntrmk & "','" & cci_cntdef & "','" & gsUsrID & "'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUCNTINF_B sp_insert_CUCNTINF :" & rtnStr)
                    save_CUCNTINF_B = False
                    Exit Function
                End If


            ElseIf cci_creusr = "~*UPD*~" And cci_cntadr <> "" Then

                gspStr = "sp_update_CUCNTINF '" & cci_cocde & "','" & cci_cusno & "'," & cci_cntseq & ",'" & cci_cnttyp & "','" & cci_cntadr & "','" & _
                                cci_cntstt & "','" & cci_cntcty & "','" & cci_cntpst & "','" & cci_cntctp & "','" & cci_cnttil & "','" & _
                          cci_cntphn & "','" & cci_cntfax & "','" & cci_cnteml & "','" & cci_cntrmk & "','" & cci_cntdef & "','" & gsUsrID & "','B'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUCNTINF_B sp_update_CUCNTINF :" & rtnStr)
                    save_CUCNTINF_B = False
                    Exit Function
                End If


            ElseIf cci_creusr = "~*DEL*~" Then

                gspStr = "sp_physical_delete_CUCNTINF '" & cci_cocde & "','" & cci_cusno & "','" & cci_cnttyp & "'," & cci_cntseq & ",'" & "DDtl" & "'"


                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUCNTINF_B sp_physical_delete_CUCNTINF :" & rtnStr)
                    save_CUCNTINF_B = False
                    Exit Function
                End If

            End If





        Next
        save_CUCNTINF_B = True
        IsUpdated = True






    End Function


    Private Function save_CUCNTINF() As Boolean


        Dim cci_cocde As String
        Dim cci_cusno As String
        Dim cci_cnttyp As String
        Dim cci_cntadr As String
        Dim cci_cntstt As String
        Dim cci_cntcty As String
        Dim cci_cntpst As String
        Dim cci_cntctp As String
        Dim cci_cnttil As String
        Dim cci_cntphn As String
        Dim cci_cntfax As String
        Dim cci_cnteml As String
        Dim cci_cntrmk As String
        Dim cci_cntdef As String
        Dim cci_updusr As String
        Dim cci_cntseq As Integer

        IsUpdated = False



        cci_cocde = ""
        cci_cusno = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cusno").ToString
        cci_cnttyp = "M"
        cci_cntadr = Replace(txtComAdr.Text, "'", "''")
        cci_cntstt = Replace(txtCusStt.Text, "'", "''")
        cci_cntcty = Split(cboCountry.Text, " - ")(0)
        cci_cntpst = txtZIP.Text
        cci_cntctp = ""
        cci_cnttil = ""
        cci_cntphn = ""
        cci_cntfax = ""
        cci_cnteml = ""
        cci_cntrmk = ""
        cci_cntdef = ""


        If Add_flag = True Or copyflag = True Then  '''''''''''''''''''''Copy flag


            gspStr = "sp_insert_CUCNTINF '" & cci_cocde & "','" & cci_cusno & "','" & cci_cnttyp & "','" & cci_cntadr & "','" & _
                  cci_cntstt & "','" & cci_cntcty & "','" & cci_cntpst & "','" & cci_cntctp & "','" & cci_cnttil & "','" & _
            cci_cntphn & "','" & cci_cntfax & "','" & cci_cnteml & "','" & cci_cntrmk & "','" & cci_cntdef & "','" & gsUsrID & "'"

            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading save_CUCNTINF sp_insert_CUCNTINF :" & rtnStr)
                save_CUCNTINF = False
                Exit Function
            End If


        Else
            If Add_flag Then
                cci_cntseq = 1
            Else
                cci_cntseq = 0
            End If
            gspStr = "sp_update_CUCNTINF '" & cci_cocde & "','" & cci_cusno & "'," & cci_cntseq & ",'" & cci_cnttyp & "','" & cci_cntadr & "','" & _
                  cci_cntstt & "','" & cci_cntcty & "','" & cci_cntpst & "','" & cci_cntctp & "','" & cci_cnttil & "','" & _
            cci_cntphn & "','" & cci_cntfax & "','" & cci_cnteml & "','" & cci_cntrmk & "','" & cci_cntdef & "','" & gsUsrID & "','M'"

            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading save_CUCNTINF sp_update_CUCNTINF :" & rtnStr)
                save_CUCNTINF = False
                Exit Function
            End If

        End If





        save_CUCNTINF = True
        IsUpdated = True





    End Function
    Private Function save_CUSHPINF_C() As Boolean
        If rs_CUSHPINF_C.Tables("RESULT").Rows.Count = 0 Then
            save_CUSHPINF_C = True
            Exit Function
        End If

        Dim csi_cocde As String
        Dim csi_cusno As String
        Dim csi_csetyp As String
        Dim csi_csenam As String
        Dim csi_cseacc As String
        Dim csi_csedsc As String
        Dim csi_cseadr As String
        Dim csi_csestt As String
        Dim csi_csecty As String
        Dim csi_csepst As String
        Dim csi_csectp As String
        Dim csi_csetil As String
        Dim csi_csephn As String
        Dim csi_csefax As String
        Dim csi_cseeml As String
        Dim csi_csermk As String
        Dim csi_csedef As String
        Dim csi_cseinr As String
        Dim csi_creusr As String
        Dim csi_cseseq As String

        IsUpdated = False
        Dim i As Integer


        For i = 0 To rs_CUSHPINF_C.Tables("RESULT").Rows.Count - 1
            csi_cocde = ""
            csi_cusno = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cusno").ToString
            csi_csetyp = Split(rs_CUSHPINF_C.Tables("RESULT").Rows(i).Item("csi_csetyp").ToString, " - ")(0)
            csi_csenam = Replace(rs_CUSHPINF_C.Tables("RESULT").Rows(i).Item("csi_csenam").ToString, "'", "''")
            csi_cseacc = Replace(rs_CUSHPINF_C.Tables("RESULT").Rows(i).Item("csi_cseacc").ToString, "'", "''")
            csi_csedsc = Replace(rs_CUSHPINF_C.Tables("RESULT").Rows(i).Item("csi_csedsc").ToString, "'", "''")
            csi_cseadr = Replace(rs_CUSHPINF_C.Tables("RESULT").Rows(i).Item("csi_cseadr").ToString, "'", "''")
            csi_csestt = Replace(rs_CUSHPINF_C.Tables("RESULT").Rows(i).Item("csi_csestt").ToString, "'", "''")
            If IsDBNull(rs_CUSHPINF_C.Tables("RESULT").Rows(i).Item("csi_csecty")) = True Then
                csi_csecty = ""
            ElseIf UBound(Split(rs_CUSHPINF_C.Tables("RESULT").Rows(i).Item("csi_csecty"))) < 0 Then
                csi_csecty = ""
            Else
                csi_csecty = Split(rs_CUSHPINF_C.Tables("RESULT").Rows(i).Item("csi_csecty"), " - ")(0)
            End If
            csi_csepst = Replace(rs_CUSHPINF_C.Tables("RESULT").Rows(i).Item("csi_csepst").ToString, "'", "''")
            csi_csectp = Replace(rs_CUSHPINF_C.Tables("RESULT").Rows(i).Item("csi_csectp").ToString, "'", "''")
            csi_csetil = Replace(rs_CUSHPINF_C.Tables("RESULT").Rows(i).Item("csi_csetil").ToString, "'", "''")
            csi_csephn = Replace(rs_CUSHPINF_C.Tables("RESULT").Rows(i).Item("csi_csephn").ToString, "'", "''")
            csi_csefax = Replace(rs_CUSHPINF_C.Tables("RESULT").Rows(i).Item("csi_csefax").ToString, "'", "''")
            csi_cseeml = Replace(rs_CUSHPINF_C.Tables("RESULT").Rows(i).Item("csi_cseeml").ToString, "'", "''")
            csi_csermk = ""
            csi_csedef = rs_CUSHPINF_C.Tables("RESULT").Rows(i).Item("csi_csedef").ToString
            csi_cseinr = rs_CUSHPINF_C.Tables("RESULT").Rows(i).Item("csi_cseinr").ToString
            csi_creusr = rs_CUSHPINF_C.Tables("RESULT").Rows(i).Item("csi_creusr")
            csi_cseseq = rs_CUSHPINF_C.Tables("RESULT").Rows(i).Item("csi_cseseq")


            If (csi_creusr = "~*ADD*~" Or copyflag = True) And IsDBNull(csi_csetyp) = False Then  '''''''''''''''''''''Copy flag


                gspStr = "sp_insert_CUSHPINF '" & csi_cocde & "','" & csi_cusno & "','" & csi_csetyp & "','" & csi_csenam & "','" & _
                     csi_cseacc & "','" & csi_csedsc & "','" & csi_cseadr & "','" & csi_csestt & "','" & csi_csecty & "','" & _
                     csi_csepst & "','" & csi_csectp & "','" & csi_csetil & "','" & csi_csephn & "','" & csi_csefax & "','" & _
                     csi_cseeml & "','" & csi_csermk & "','" & csi_csedef & "','" & csi_cseinr & "','" & gsUsrID & "'"


                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUSHPINF_C sp_insert_CUSHPINF :" & rtnStr)
                    save_CUSHPINF_C = False
                    Exit Function
                End If


            ElseIf csi_creusr = "~*UPD*~" And IsDBNull(csi_csetyp) = False Then


                gspStr = "sp_update_CUSHPINF '" & csi_cocde & "','" & csi_cusno & "','" & csi_csetyp & "'," & csi_cseseq & _
                    ",'" & csi_csenam & "','" & _
                      csi_cseacc & "','" & csi_csedsc & "','" & csi_cseadr & "','" & csi_csestt & "','" & csi_csecty & "','" & _
                      csi_csepst & "','" & csi_csectp & "','" & csi_csetil & "','" & csi_csephn & "','" & csi_csefax & "','" & _
                      csi_cseeml & "','" & csi_csermk & "','" & csi_csedef & "','" & csi_cseinr & "','" & gsUsrID & "','C'"


                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUSHPINF_C sp_update_CUSHPINF :" & rtnStr)
                    save_CUSHPINF_C = False
                    Exit Function
                End If


            ElseIf csi_creusr = "~*DEL*~" Then

                gspStr = "sp_physical_delete_CUSHPINF '" & csi_cocde & "','" & csi_cusno & "','" & csi_csetyp & "'," & csi_cseseq & ",'DDtl'"


                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUMCAMRK sp_physical_delete_CUSHPINF :" & rtnStr)
                    save_CUSHPINF_C = False
                    Exit Function
                End If

            End If




        Next
        save_CUSHPINF_C = True
        IsUpdated = True




    End Function
    Private Function save_CUSHPINF() As Boolean

        If rs_CUSHPINF_B.Tables("RESULT").Rows.Count = 0 Then
            save_CUSHPINF = True
            Exit Function
        End If

        Dim csi_cocde As String
        Dim csi_cusno As String
        Dim csi_csetyp As String
        Dim csi_csenam As String
        Dim csi_cseacc As String
        Dim csi_csedsc As String
        Dim csi_cseadr As String
        Dim csi_csestt As String
        Dim csi_csecty As String
        Dim csi_csepst As String
        Dim csi_csectp As String
        Dim csi_csetil As String
        Dim csi_csephn As String
        Dim csi_csefax As String
        Dim csi_cseeml As String
        Dim csi_csermk As String
        Dim csi_csedef As String
        Dim csi_cseinr As String
        Dim csi_creusr As String
        Dim csi_cseseq As Integer

         

        IsUpdated = False
        Dim i As Integer

        For i = 0 To rs_CUSHPINF_B.Tables("RESULT").Rows.Count - 1
            csi_cocde = ""
            csi_cusno = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cusno").ToString
            csi_csetyp = Split(rs_CUSHPINF_B.Tables("RESULT").Rows(i).Item("csi_csetyp").ToString, " - ")(0)
            csi_csenam = Replace(rs_CUSHPINF_B.Tables("RESULT").Rows(i).Item("csi_csenam").ToString, "'", "''")
            csi_cseacc = ""
            csi_csedsc = ""
            csi_cseadr = Replace(rs_CUSHPINF_B.Tables("RESULT").Rows(i).Item("csi_cseadr").ToString, "'", "''")
            csi_csestt = Replace(rs_CUSHPINF_B.Tables("RESULT").Rows(i).Item("csi_csestt").ToString, "'", "''")
            If IsDBNull(rs_CUSHPINF_B.Tables("RESULT").Rows(i).Item("csi_csecty")) = True Then
                csi_csecty = ""
            ElseIf UBound(Split(rs_CUSHPINF_B.Tables("RESULT").Rows(i).Item("csi_csecty"))) < 0 Then
                csi_csecty = ""
            Else
                csi_csecty = Split(rs_CUSHPINF_B.Tables("RESULT").Rows(i).Item("csi_csecty"), " - ")(0)
            End If
            csi_csepst = Replace(rs_CUSHPINF_B.Tables("RESULT").Rows(i).Item("csi_csepst").ToString, "'", "''")
            csi_csectp =  Replace(rs_CUSHPINF_B.Tables("RESULT").Rows(i).Item("csi_csectp").ToString, "'", "''")
            csi_csetil = Replace(rs_CUSHPINF_B.Tables("RESULT").Rows(i).Item("csi_csetil").ToString, "'", "''")
            csi_csephn = Replace(rs_CUSHPINF_B.Tables("RESULT").Rows(i).Item("csi_csephn").ToString, "'", "''")
            csi_csefax = Replace(rs_CUSHPINF_B.Tables("RESULT").Rows(i).Item("csi_csefax").ToString, "'", "''")
            csi_cseeml = Replace(rs_CUSHPINF_B.Tables("RESULT").Rows(i).Item("csi_cseeml").ToString, "'", "''")
            csi_csermk = ""
            csi_csedef = rs_CUSHPINF_B.Tables("RESULT").Rows(i).Item("csi_csedef").ToString
            csi_cseinr = ""
            csi_creusr = rs_CUSHPINF_B.Tables("RESULT").Rows(i).Item("csi_creusr")
            csi_cseseq = rs_CUSHPINF_B.Tables("RESULT").Rows(i).Item("csi_cseseq")


            If (csi_creusr = "~*ADD*~" Or copyflag = True) And IsDBNull(csi_csetyp) = False Then  '''''''''''''''''''''Copy flag


                gspStr = "sp_insert_CUSHPINF '" & csi_cocde & "','" & csi_cusno & "','" & csi_csetyp & "','" & csi_csenam & "','" & _
                      csi_cseacc & "','" & csi_csedsc & "','" & csi_cseadr & "','" & csi_csestt & "','" & csi_csecty & "','" & _
                      csi_csepst & "','" & csi_csectp & "','" & csi_csetil & "','" & csi_csephn & "','" & csi_csefax & "','" & _
                      csi_cseeml & "','" & csi_csermk & "','" & csi_csedef & "','" & csi_cseinr & "','" & gsUsrID & "'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUMCAMRK sp_insert_CUMCAMRK :" & rtnStr)
                    save_CUSHPINF = False
                    Exit Function
                End If


            ElseIf csi_creusr = "~*UPD*~" And csi_csetyp <> "" Then
                gspStr = "sp_update_CUSHPINF '" & csi_cocde & "','" & csi_cusno & "','" & csi_csetyp & "'," & csi_cseseq & _
                        ",'" & csi_csenam & "','" & _
                     csi_cseacc & "','" & csi_csedsc & "','" & csi_cseadr & "','" & csi_csestt & "','" & csi_csecty & "','" & _
                     csi_csepst & "','" & csi_csectp & "','" & csi_csetil & "','" & csi_csephn & "','" & csi_csefax & "','" & _
                     csi_cseeml & "','" & csi_csermk & "','" & csi_csedef & "','" & csi_cseinr & "','" & gsUsrID & "','B'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUMCAMRK sp_update_CUSHPINF :" & rtnStr)
                    save_CUSHPINF = False
                    Exit Function
                End If

            ElseIf csi_creusr = "~*DEL*~" Then

                gspStr = "sp_physical_delete_CUSHPINF '" & csi_cocde & "','" & csi_cusno & "','" & csi_csetyp & "'," & csi_cseseq & ",'DDtl'"


                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUMCAMRK sp_physical_delete_CUSHPINF :" & rtnStr)
                    save_CUSHPINF = False
                    Exit Function
                End If


            End If




        Next
        save_CUSHPINF = True
        IsUpdated = True


    End Function
    Private Function save_CUMCAMRK() As Boolean 'for now


        If rs_CUMCAMRK.Tables("RESULT").Rows.Count = 0 Then
            save_CUMCAMRK = True
            Exit Function
        End If


        Dim ccm_cocde As String
        Dim ccm_cusno As String
        Dim ccm_cat As String
        Dim ccm_ventyp As String
        Dim ccm_markup As String
        Dim ccm_effdat As String
        Dim ccm_creusr As String
        Dim ccm_updprg As String
        IsUpdated = False

        Dim i As Integer

        For i = 0 To rs_CUMCAMRK.Tables("RESULT").Rows.Count - 1
            ccm_cocde = ""
            ccm_cusno = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cusno").ToString
            ccm_cat = rs_CUMCAMRK.Tables("RESULT").Rows(i).Item("ccm_cat").ToString
            ccm_ventyp = Microsoft.VisualBasic.Left(rs_CUMCAMRK.Tables("RESULT").Rows(i).Item("ccm_ventyp").ToString, 1)
            ccm_markup = Split(rs_CUMCAMRK.Tables("RESULT").Rows(i).Item("ccm_markupfml"), " - ")(0)
            ccm_effdat = rs_CUMCAMRK.Tables("RESULT").Rows(i).Item("ccm_effdat")
            ccm_creusr = rs_CUMCAMRK.Tables("RESULT").Rows(i).Item("ccm_creusr")
            ccm_updprg = "CUM00001"

            If (ccm_creusr = "~*ADD*~" Or copyflag = True And CusTyp = "P") Then  '''''''''''''''''''''Copy flag


                gspStr = "sp_insert_CUMCAMRK '" & ccm_cocde & "','" & ccm_cusno & "','" & ccm_cat & "','" & ccm_ventyp & "','" & _
                      ccm_markup & "','" & ccm_effdat & "','" & gsUsrID & "','" & ccm_updprg & "'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUMCAMRK sp_insert_CUMCAMRK :" & rtnStr)
                    save_CUMCAMRK = False
                    Exit Function
                End If


            ElseIf ccm_creusr = "~*UPD*~" Then

                gspStr = "sp_update_CUMCAMRK '" & ccm_cocde & "','" & ccm_cusno & "','" & ccm_cat & "','" & ccm_ventyp & "','" & _
                      ccm_markup & "','" & ccm_effdat & "','" & gsUsrID & "','" & ccm_updprg & "'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUMCAMRK sp_update_CUMCAMRK :" & rtnStr)
                    save_CUMCAMRK = False
                    Exit Function
                End If

            ElseIf ccm_creusr = "~*DEL*~" Then

                gspStr = "sp_physical_delete_CUMCAMRK '" & ccm_cocde & "','" & ccm_cusno & "','" & ccm_ventyp & "','" & _
                      ccm_cat & "','" & ccm_effdat & "'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUMCAMRK sp_physical_delete_CUMCAMRK :" & rtnStr)
                    save_CUMCAMRK = False
                    Exit Function
                End If

            End If





        Next
        save_CUMCAMRK = True
        IsUpdated = True





    End Function
    Private Function save_CUPRCINF() As Boolean


        IsUpdated = False
        Dim cpi_cocde As String
        Dim cpi_cusno As String
        Dim cpi_prcfml As String
        Dim cpi_prcsec As String
        Dim cpi_grsmgn As String
        Dim cpi_prctrm As String
        Dim cpi_paytrm As String
        Dim cpi_smpprd As String
        Dim cpi_smpfgt As String
        Dim cpi_curcde As String
        Dim cpi_rsklmt As Double
        Dim cpi_rskuse As Double
        Dim cpi_cdtlmt As Double
        Dim cpi_cdtuse As Double
        Dim cpi_moqchgflg As String
        Dim cpi_moachgflg As String
        Dim cpi_quplus As String
        Dim cpi_quminus As String
        Dim cpi_updusr As String




        Dim PrcSec As String
        Dim markup As Single

        If optGrsMgn.Checked = True Then
            PrcSec = "GM"
            If txtgrsMgn.Text = "" Then
                txtgrsMgn.Text = "0"
            End If
            markup = txtgrsMgn.Text
        Else
            PrcSec = "MU"
            If txtgrsMgn.Text = "" Then
                txtgrsMgn.Text = "0"
            End If
            markup = txtgrsMgn.Text
        End If

        Dim prctrm As String
        'If UBound(Split(cboPrcTrm.Text, " - ")) < 0 Then
        '    prctrm = cboPrcTrm.Text
        'Else
        '    prctrm = Split(cboPrcTrm.Text, " - ")(0)
        'End If
        Dim i As Integer
        For i = 0 To rs_CUPRCTRM.Tables("RESULT").Rows.Count - 1
            If rs_CUPRCTRM.Tables("RESULT").Rows(i).Item("cpt_prcdef") = "Y" Then
                prctrm = Split(rs_CUPRCTRM.Tables("RESULT").Rows(i).Item("cpt_prctrm"), " - ")(0)
            End If
        Next

        Dim protrm As String
        If UBound(Split(cboProTrm.Text, " - ")) < 0 Then
            protrm = cboProTrm.Text
        Else
            protrm = Split(cboProTrm.Text, " - ")(0)
        End If

        Dim frgtrm As String
        If UBound(Split(cboFrgTrm.Text, " - ")) < 0 Then
            frgtrm = cboFrgTrm.Text
        Else
            frgtrm = Split(cboFrgTrm.Text, " - ")(0)
        End If

        'Dim prcfml As String   空格
        'If UBound(Split(cboPrcFml.Text, " - ")) < 0 Then
        '    prcfml = cboPrcFml.Text
        'Else
        '    prcfml = Split(cboPrcFml.Text, " - ")(0)
        'End If

        Dim CurCde As String
        If UBound(Split(cboCurcde.Text, " - ")) < 0 Then
            CurCde = cboCurcde.Text
        Else
            CurCde = Split(cboCurcde.Text, " - ")(0)
        End If

        Dim Payterm As String
        If UBound(Split(cboPayTrm.Text, " - ")) < 0 Then
            Payterm = cboPayTrm.Text
        Else
            Payterm = Split(cboPayTrm.Text, " - ")(0)
        End If

        'Dim rsklmt As Double     '1    '1
        'If Trim(txtRskLmt.Text) = "" Then
        '    rsklmt = "0"
        'Else
        '    rsklmt = Replace(Split(txtRskLmt.Text, ".")(0), ",", "")
        'End If

        'Dim cdtlmt As Double '0    '0
        'If Trim(txtCdtLmt.Text) = "" Then
        '    cdtlmt = "0"
        'Else
        '    cdtlmt = Replace(Split(txtCdtLmt.Text, ".")(0), ",", "")
        'End If

        'Dim rskuse As Double   '0   0
        'If Trim(txtRskUse.Text) = "" Or Trim(txtRskUse.Text) = "0" Then
        '    rskuse = "0"
        'Else
        '    rskuse = Replace(Split(txtRskUse.Text, ".")(0), ",", "") + "." + Split(txtRskUse.Text, ".")(1)
        'End If

        'Dim cdtuse As Double   '0   0
        'If Trim(txtCdtUse.Text) = "" Or Trim(txtCdtUse.Text) = "0" Then
        '    cdtuse = "0"
        'Else
        '    cdtuse = Replace(Split(txtCdtUse.Text, ".")(0), ",", "") + "." + Split(txtCdtUse.Text, ".")(1)
        'End If

        '************Kenny add on 30-09-2002**************
        'If IsNumeric(txtCdtUse.Text) = False Then    '0    0
        '    cdtuse = 0
        'End If

        cpi_cocde = ""
        cpi_cusno = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cusno").ToString
        cpi_prcfml = ""
        cpi_prcsec = PrcSec
        cpi_grsmgn = markup
        cpi_prctrm = prctrm
        cpi_paytrm = Payterm
        cpi_smpprd = protrm
        cpi_smpfgt = frgtrm
        cpi_curcde = CurCde
        cpi_rsklmt = 1
        cpi_rskuse = 0
        cpi_cdtlmt = 0
        cpi_cdtuse = 0
        If ChkMoqChg.Checked = True Then
            cpi_moqchgflg = "Y"
        Else
            cpi_moqchgflg = "N"
        End If

        If ChkMoaChg.Checked = True Then
            cpi_moachgflg = "Y"
        Else
            cpi_moachgflg = "N"
        End If

        cpi_quplus = "3" 'Change by BN 20130412 remove Quotation Approval % (Hard Code 3)
        cpi_quminus = "3"
        cpi_updusr = gsUsrID

        If Add_flag = True Or copyflag = True Or (copyflag = True And CusTyp = "P") Then  '''''''''''''''''''''Copy flag


            gspStr = "sp_insert_CUPRCINF '" & cpi_cocde & "','" & cpi_cusno & "','" & cpi_prcfml & "','" & cpi_prcsec & "','" & _
                  cpi_grsmgn & "','" & cpi_prctrm & "','" & cpi_paytrm & "','" & cpi_smpprd & "','" & cpi_smpfgt & "','" & cpi_curcde & "','" & _
                  cpi_rsklmt & "','" & cpi_rskuse & "','" & cpi_cdtlmt & "','" & cpi_cdtuse & "','" & cpi_moqchgflg & "','" & cpi_moachgflg & _
                  "','" & cpi_quplus & "','" & cpi_quminus & "','" & cpi_updusr & "'"

            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading save_CUPRCINF sp_insert_CUPRCINF :" & rtnStr)
                save_CUPRCINF = False
                Exit Function
            End If


        Else

            gspStr = "sp_update_CUPRCINF '" & cpi_cocde & "','" & cpi_cusno & "','" & cpi_prcfml & "','" & cpi_prcsec & "','" & _
                cpi_grsmgn & "','" & cpi_prctrm & "','" & cpi_paytrm & "','" & cpi_smpprd & "','" & cpi_smpfgt & "','" & cpi_curcde & "','" & _
                cpi_rsklmt & "','" & cpi_rskuse & "','" & cpi_cdtlmt & "','" & cpi_cdtuse & "','" & cpi_moqchgflg & "','" & cpi_moachgflg & _
                "','" & cpi_quplus & "','" & cpi_quminus & "','" & cpi_updusr & "'"

            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading save_CUPRCINF sp_update_CUPRCINF :" & rtnStr)
                save_CUPRCINF = False
                Exit Function
            End If





        End If
        IsUpdated = True
        save_CUPRCINF = True




    End Function


    Private Function save_CUAGTINF() As Boolean

        If rs_CUAGTINF.Tables("RESULT").Rows.Count = 0 Then
            save_CUAGTINF = True
            Exit Function
        End If


        Dim cai_cocde As String
        Dim cai_cusno As String
        Dim cai_cusagt As String
        Dim cai_comrat As String
        Dim cai_cusdef As String
        Dim cai_creusr As String
        IsUpdated = False

        Dim i As Integer

        For i = 0 To rs_CUAGTINF.Tables("RESULT").Rows.Count - 1
            cai_cocde = ""
            cai_cusno = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cusno").ToString
            cai_cusagt = Split(rs_CUAGTINF.Tables("RESULT").Rows(i).Item("cai_cusagt").ToString, " - ")(0)
            cai_comrat = rs_CUAGTINF.Tables("RESULT").Rows(i).Item("cai_comrat").ToString
            cai_cusdef = rs_CUAGTINF.Tables("RESULT").Rows(i).Item("cai_cusdef").ToString
            cai_creusr = rs_CUAGTINF.Tables("RESULT").Rows(i).Item("cai_creusr")

            If (cai_creusr = "~*ADD*~" Or copyflag = True) And IsDBNull(cai_cusagt) = False Then  '''''''''''''''''''''Copy flag


                gspStr = "sp_insert_CUAGTINF '" & cai_cocde & "','" & cai_cusno & "','" & cai_cusagt & "','" & cai_comrat & "','" & _
                      cai_cusdef & "','" & gsUsrID & "'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUAGTINF sp_insert_CUAGTINF :" & rtnStr)
                    save_CUAGTINF = False
                    Exit Function
                End If


            ElseIf cai_creusr = "~*UPD*~" And cai_cusagt <> "" Then

                gspStr = "sp_update_CUAGTINF '" & cai_cocde & "','" & cai_cusno & "','" & cai_cusagt & "','" & cai_comrat & "','" & _
                      cai_cusdef & "','" & gsUsrID & "'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUAGTINF sp_update_CUAGTINF :" & rtnStr)
                    save_CUAGTINF = False
                    Exit Function
                End If

            ElseIf cai_creusr = "~*DEL*~" Then

                gspStr = "sp_physical_delete_CUAGTINF '" & cai_cocde & "','" & cai_cusno & "','" & cai_cusagt & "','" & "DDtl" & "'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUAGTINF sp_physical_delete_CUAGTINF :" & rtnStr)
                    save_CUAGTINF = False
                    Exit Function
                End If

            End If





        Next
        save_CUAGTINF = True
        IsUpdated = True


    End Function

    Private Function save_CUMCOVEN() As Boolean


        If rs_CUMCOVEN.Tables("RESULT").Rows.Count = 0 Then
            save_CUMCOVEN = True
            Exit Function
        End If


        Dim running_cocde As String
        Dim ccv_cocde As String
        Dim ccv_cusno As String
        Dim ccv_ventyp As String
        Dim ccv_vendef As String
        Dim ccv_effdat As Date
        Dim ccv_creusr As String
        Dim ccv_updprg As String

        IsUpdated = False

        Dim i As Integer

        For i = 0 To rs_CUMCOVEN.Tables("RESULT").Rows.Count - 1
            running_cocde = ""
            ccv_cocde = rs_CUMCOVEN.Tables("RESULT").Rows(i).Item("ccv_cocde").ToString
            ccv_cusno = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cusno").ToString
            ccv_ventyp = Microsoft.VisualBasic.Left(rs_CUMCOVEN.Tables("RESULT").Rows(i).Item("ccv_ventyp").ToString, 1)
            ccv_vendef = rs_CUMCOVEN.Tables("RESULT").Rows(i).Item("ccv_vendef").ToString
            ccv_effdat = rs_CUMCOVEN.Tables("RESULT").Rows(i).Item("ccv_effdat")
            ccv_creusr = rs_CUMCOVEN.Tables("RESULT").Rows(i).Item("ccv_creusr")
            ccv_updprg = Me.Name





            If (ccv_creusr = "~*ADD*~" Or copyflag = True And CusTyp = "P") Then  '''''''''''''''''''''Copy flag 'ppppppppppppppppppppp


                gspStr = "sp_insert_CUMCOVEN '" & running_cocde & "','" & ccv_cocde & "','" & ccv_cusno & "','" & ccv_ventyp & "','" & _
                      ccv_vendef & "','" & ccv_effdat & "','" & gsUsrID & "','" & ccv_updprg & "'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUMCOVEN sp_insert_CUMCOVEN :" & rtnStr)
                    save_CUMCOVEN = False
                    Exit Function
                End If



            ElseIf ccv_creusr = "~*UPD*~" Then


                gspStr = "sp_update_CUMCOVEN '" & running_cocde & "','" & ccv_cocde & "','" & ccv_cusno & "','" & ccv_ventyp & "','" & _
                      ccv_vendef & "','" & ccv_effdat & "','" & gsUsrID & "','" & ccv_updprg & "'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUMCOVEN sp_update_CUMCOVEN :" & rtnStr)
                    save_CUMCOVEN = False
                    Exit Function
                End If

            ElseIf ccv_creusr = "~*DEL*~" Then 'd

                gspStr = "sp_physical_delete_CUMCOVEN '" & running_cocde & "','" & ccv_cocde & "','" & ccv_cusno & "','" & ccv_ventyp & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUMCOVEN sp_physical_delete_CUMCOVEN :" & rtnStr)
                    save_CUMCOVEN = False
                    Exit Function
                End If


            End If
            Dim dr() As DataRow
            If ccv_creusr = "~*ADD*~" And CusTyp = "P" Then
                If rs_CUBCR.Tables("RESULT").Rows.Count > 0 Then

                    dr = rs_CUBCR.Tables("RESULT").Select("cbc_cocde = '" & ccv_cocde & "'")
                    If dr.Length = 0 Then

                        gspStr = "sp_insert_CUBCR '" & "" & "','" & "ONE" & "','" & ccv_cocde & "','" & ccv_cusno & "','" & _
                              "999999999" & "','" & "0" & "','" & "999999999" & "','" & "0" & "','" & Split(cboCurcde.Text, "-")(0) & _
                              "','" & gsUsrID & "','" & Me.Name & "'"

                        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                        If rtnLong <> RC_SUCCESS Then
                            MsgBox("Error on loading save_CUMCOVEN sp_insert_CUBCR :" & rtnStr)
                            save_CUMCOVEN = False
                            Exit Function
                        Else
                            Dim rowcount As Integer
                            rowcount = rs_CUBCR.Tables("RESULT").Rows.Count  'opp
                            rs_CUBCR.Tables("RESULT").Rows.Add()
                            rs_CUBCR.Tables("RESULT").Rows(rowcount).Item("cbc_del") = ""
                            rs_CUBCR.Tables("RESULT").Rows(rowcount).Item("cbc_cusno") = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cusno").ToString
                            rs_CUBCR.Tables("RESULT").Rows(rowcount).Item("cbc_cocde") = rs_CUMCOVEN.Tables("RESULT").Rows(i).Item("ccv_cocde").ToString
                            rs_CUBCR.Tables("RESULT").Rows(rowcount).Item("cbc_curcde") = Trim(Split(cboCurcde.Text, "-")(0))
                            rs_CUBCR.Tables("RESULT").Rows(rowcount).Item("cbc_rsklmt") = 999999999
                            rs_CUBCR.Tables("RESULT").Rows(rowcount).Item("cbc_rskuse") = 0
                            rs_CUBCR.Tables("RESULT").Rows(rowcount).Item("cbc_cdtlmt") = 999999999
                            rs_CUBCR.Tables("RESULT").Rows(rowcount).Item("cbc_cdtuse") = 0
                            rs_CUBCR.Tables("RESULT").Rows(rowcount).Item("cbc_creusr") = gsUsrID

                        End If


                    End If
                Else
                    gspStr = "sp_insert_CUBCR '" & "" & "','" & "ONE" & "','" & ccv_cocde & "','" & ccv_cusno & "','" & _
                             "999999999" & "','" & "0" & "','" & "999999999" & "','" & "0" & "','" & Split(cboCurcde.Text, "-")(0) & _
                             "','" & gsUsrID & "','" & Me.Name & "'"

                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading save_CUMCOVEN sp_insert_CUBCR :" & rtnStr)
                        save_CUMCOVEN = False
                        Exit Function
                    Else
                        Dim rowcount As Integer
                        rowcount = rs_CUBCR.Tables("RESULT").Rows.Count  'opp
                        rs_CUBCR.Tables("RESULT").Rows.Add()
                        rs_CUBCR.Tables("RESULT").Rows(rowcount).Item("cbc_del") = ""
                        rs_CUBCR.Tables("RESULT").Rows(rowcount).Item("cbc_cusno") = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cusno").ToString
                        rs_CUBCR.Tables("RESULT").Rows(rowcount).Item("cbc_cocde") = rs_CUMCOVEN.Tables("RESULT").Rows(i).Item("ccv_cocde").ToString
                        rs_CUBCR.Tables("RESULT").Rows(rowcount).Item("cbc_curcde") = Trim(Split(cboCurcde.Text, "-")(0))
                        rs_CUBCR.Tables("RESULT").Rows(rowcount).Item("cbc_rsklmt") = 999999999
                        rs_CUBCR.Tables("RESULT").Rows(rowcount).Item("cbc_rskuse") = 0
                        rs_CUBCR.Tables("RESULT").Rows(rowcount).Item("cbc_cdtlmt") = 999999999
                        rs_CUBCR.Tables("RESULT").Rows(rowcount).Item("cbc_cdtuse") = 0
                        rs_CUBCR.Tables("RESULT").Rows(rowcount).Item("cbc_creusr") = gsUsrID

                    End If

                End If

            End If
        Next
        IsUpdated = True
        save_CUMCOVEN = True
    End Function
    Private Function save_CUVENINF() As Boolean


        If rs_CUVENINF.Tables("RESULT").Rows.Count = 0 Then
            save_CUVENINF = True
            Exit Function
        End If


        Dim cvi_cocde As String
        Dim cvi_cusno As String
        Dim cvi_assvid As String
        Dim cvi_assdsc As String
        Dim cvi_creusr As String
        Dim cvi_orgvid As String

        IsUpdated = False

        Dim i As Integer

        For i = 0 To rs_CUVENINF.Tables("RESULT").Rows.Count - 1
            cvi_cocde = ""
            cvi_cusno = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cusno").ToString
            cvi_assvid = rs_CUVENINF.Tables("RESULT").Rows(i).Item("cvi_assvid").ToString
            cvi_assdsc = rs_CUVENINF.Tables("RESULT").Rows(i).Item("cvi_assdsc").ToString
            cvi_creusr = rs_CUVENINF.Tables("RESULT").Rows(i).Item("cvi_creusr").ToString
            cvi_orgvid = rs_CUVENINF.Tables("RESULT").Rows(i).Item("cvi_orgvid").ToString




            If cvi_creusr = "~*ADD*~" And cvi_assvid <> "" Or copyflag = True Then  '''''''''''''''''''''Copy flag


                gspStr = "sp_insert_CUVENINF '" & cvi_cocde & "','" & cvi_cusno & "','" & cvi_assvid & "','" & cvi_assdsc & "','" & _
                      gsUsrID & "'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUVENINF sp_insert_CUVENINF :" & rtnStr)
                    save_CUVENINF = False
                    Exit Function
                End If


            ElseIf cvi_creusr = "~*UPD*~" And cvi_assvid <> "" Then

                gspStr = "sp_update_CUVENINF '" & cvi_cocde & "','" & cvi_cusno & "','" & cvi_orgvid & "','" & cvi_assvid & "','" & cvi_assdsc & "','" & _
                      gsUsrID & "'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUVENINF sp_update_CUVENINF :" & rtnStr)
                    save_CUVENINF = False
                    Exit Function
                End If

            ElseIf cvi_creusr = "~*DEL*~" Then

                gspStr = "sp_physical_delete_CUVENINF '" & cvi_cocde & "','" & cvi_cusno & "','" & cvi_assvid & "','" & "DDtl" & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUVENINF sp_physical_delete_CUVENINF :" & rtnStr)
                    save_CUVENINF = False
                    Exit Function
                End If

            End If

        Next
        IsUpdated = True
        save_CUVENINF = True

    End Function

    Private Function save_CUBASINF() As Boolean
        Dim AdvOrd As String
        Dim THC As String
        Dim CFS As String
        Dim rating As String
        Dim market As String
        Dim tmpMrkReg As String

        Dim cbi_cocde As String
        Dim cbi_cusno As String
        Dim cbi_custyp As String
        Dim cbi_cussts As String
        Dim cbi_cussna As String
        Dim cbi_cusnam As String
        Dim cbi_cusweb As String
        Dim cbi_salrep As String
        Dim cbi_salmgt As String
        Dim cbi_refno As String
        Dim cbi_cusrat As String
        Dim cbi_mrkreg As String
        Dim cbi_mrktyp As String
        Dim cbi_advord As String
        Dim cbi_rmk As String
        Dim cbi_cuspod As String
        Dim cbi_cusfde As String
        Dim cbi_cuscfs As String
        Dim cbi_custhc As String
        Dim cbi_cuspro As String
        Dim cbi_cerdoc As String
        Dim cbi_cusali As String
        Dim cbi_updusr As String
        Dim cbi_saltem As String
        Dim cbi_saldiv As String
        Dim cbi_cugrptyp_int As String
        Dim cbi_cugrptyp_ext As String
        Dim cbi_srname As String
        Dim cbi_roudning As Integer
        Dim cbi_cbinv As String
        Dim cbi_cbinvwarn As String


        IsUpdated = False

        cbi_saltem = Split(cboSalTem.Text, " - ")(0)
        cbi_saldiv = Split(txtSalDiv.Text, " - ")(0)

        cbi_cugrptyp_int = Split(cboIntGrp.Text, " - ")(0)
        cbi_cugrptyp_ext = Split(cboExtGrp.Text, " - ")(0)

        If chkAdvOrd.Checked = True Then
            AdvOrd = "Y"
        Else
            AdvOrd = "N"
        End If

        If optTHCYes.Checked = True Then
            THC = "Y"
        Else
            THC = "N"
        End If

        If optCFSyes.Checked = True Then
            CFS = "Y"
        Else
            CFS = "N"
        End If

        rating = cboCusRat.Text

        If UBound(Split(cboMrkTyp.Text, " - ")) < 0 Then
            market = cboMrkTyp.Text
        Else
            market = Split(cboMrkTyp.Text, " - ")(0)
        End If


        If Trim(cboMrkReg.Text) <> "" Then
            tmpMrkReg = Trim(Split(cboMrkReg.Text, "-")(1))
        Else
            tmpMrkReg = ""
        End If



        cbi_cocde = ""
        cbi_cusno = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cusno")
        cbi_custyp = CusTyp
        cbi_cussts = Split(cboStatus.Text, " - ")(0) 'copyflag

        If chkActivate.Checked = True Then
            cbi_cussts = "A"
        End If

        If copyflag = True Then
            cbi_cussts = "A"
        End If
        cbi_cussna = Replace(UCase(txtCussna.Text), "'", "''")
        cbi_cusnam = Replace(UCase(txtCusnam.Text), "'", "''")
        cbi_cusweb = txtCusWeb.Text
        cbi_salrep = Split(cboSalRep.Text, " - ")(0)
        cbi_srname = Split(cboSalRep.Text, " - ")(0)
        cbi_salmgt = txtSalMgt.Text
        cbi_refno = txtRefNo.Text
        cbi_cusrat = rating
        cbi_mrkreg = tmpMrkReg
        cbi_mrktyp = market
        cbi_advord = AdvOrd
        cbi_rmk = Replace(Trim(txtRemark.Text), "'", "''")
        cbi_cuspod = Replace(Trim(txtCusPOD.Text), "'", "''")
        cbi_cusfde = Replace(Trim(txtCusFDE.Text), "'", "''")
        cbi_cuscfs = CFS
        cbi_custhc = THC
        cbi_cuspro = Replace(Trim(txtMemo.Text), "'", "''")
        cbi_cerdoc = Replace(Trim(txtCerDoc.Text), "'", "''")
        cbi_cusali = txtCusAli.Text
        cbi_updusr = gsUsrID

        If cboRounding.Text = "" Then
            cbi_roudning = 4
        Else
            cbi_roudning = cboRounding.Text
        End If

        If optcbinvyes.Checked = True Then
            cbi_cbinv = "Y"
        Else
            cbi_cbinv = "N"
        End If

        If optcbinvWarnYes.Checked = True Then
            cbi_cbinvwarn = "Y"
        Else
            cbi_cbinvwarn = "N"
        End If

        If Add_flag = True Or copyflag = True Then  '''''''''''''''''''''Copy flag


            gspStr = "sp_insert_CUBASINF '" & cbi_cocde & "','" & cbi_cusno & "','" & cbi_custyp & "','" & cbi_cussts & "','" & _
         cbi_cussna & "','" & cbi_cusnam & "','" & cbi_cusweb & "','" & cbi_saltem & "','" & cbi_saldiv & _
           "','" & cbi_salrep & "','" & cbi_salmgt & "','" & cbi_srname & "','" & cbi_refno & "','" & _
         cbi_cusrat & "','" & cbi_mrkreg & "','" & cbi_mrktyp & "','" & cbi_advord & "','" & cbi_rmk & "','" & cbi_cuspod & _
         "','" & cbi_cusfde & "','" & cbi_cuscfs & "','" & cbi_custhc & "','" & cbi_cuspro & "','" & cbi_cerdoc & _
          "','" & cbi_cusali & "','" & cbi_cugrptyp_int & "','" & cbi_cugrptyp_ext & "','" & cbi_updusr & "'," & _
          cbi_roudning & " ,'" & cbi_cbinv & "','" & cbi_cbinvwarn & "'"



            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading save_CUBASINF sp_insert_CUBASINF :" & rtnStr)
                save_CUBASINF = False
                Exit Function
            End If


        Else


            gspStr = "sp_update_CUBASINF '" & cbi_cocde & "','" & cbi_cusno & "','" & cbi_custyp & "','" & cbi_cussts & "','" & _
                 cbi_cussna & "','" & cbi_cusnam & "','" & cbi_cusweb & "','" & cbi_saltem & "','" & cbi_saldiv & _
                 "','" & cbi_salrep & "','" & cbi_salmgt & "','" & cbi_srname & "','" & cbi_refno & "','" & _
                 cbi_cusrat & "','" & cbi_mrkreg & "','" & cbi_mrktyp & "','" & cbi_advord & "','" & cbi_rmk & "','" & cbi_cuspod & _
                 "','" & cbi_cusfde & "','" & cbi_cuscfs & "','" & cbi_custhc & "','" & cbi_cuspro & "','" & cbi_cerdoc & _
                  "','" & cbi_cusali & "','" & cbi_cugrptyp_int & "','" & cbi_cugrptyp_ext & "'," & cbi_roudning & " ,'" & cbi_cbinv & "','" & cbi_cbinvwarn & "','" & cbi_updusr & "'"

            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading save_CUBASINF sp_update_CUBASINF :" & rtnStr)
                save_CUBASINF = False
                Exit Function
            End If




        End If
        IsUpdated = True
        save_CUBASINF = True

    End Function
    Private Sub mmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdInsRow.Click
        If checkFocus(Me) Then Exit Sub

        If Me.BaseTabControl1.SelectedIndex = 6 Then
            Got_Focus_Grid = "ShipMark"
        End If

        Select Case Got_Focus_Grid
            Case "Coven"
                Call add_Coven()
            Case "Agent"
                Call add_Agent()
            Case "CusVen"
                Call add_CusVen()
            Case "Billing"
                Call add_Billing()
            Case "Shipping"
                Call add_Shipping()
            Case "Contact"
                Call add_Contact()
            Case "ItmCatMarkup"
                Call add_ItmCatMarkup()
            Case "Bank"
                Call add_Bank()
            Case "Courier"
                Call add_Courrier()
            Case "RelCus"
                Call add_RelCus()
            Case "ShipMark"
                Call add_ShipMark()
            Case "Prctrm"
                Call add_prctrm()
            Case "CusBufSetup"
                Call add_CusBufSetup()
        End Select
        grd_action = "ADD"
    End Sub

    Private Sub cmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.BaseTabControl1.SelectedIndex = 6 Then
            Got_Focus_Grid = "ShipMark"
        End If

        Select Case Got_Focus_Grid
            Case "Coven"
                Call add_Coven()
            Case "Agent"
                Call add_Agent()
            Case "CusVen"
                Call add_CusVen()
            Case "Billing"
                Call add_Billing()
            Case "Shipping"
                Call add_Shipping()
            Case "Contact"
                Call add_Contact()
            Case "ItmCatMarkup"
                Call add_ItmCatMarkup()
            Case "Bank"
                Call add_Bank()
            Case "Courier"
                Call add_Courrier()
            Case "RelCus"
                Call add_RelCus()
            Case "ShipMark"
                Call add_ShipMark()
            Case "Prctrm"
                Call add_prctrm()
            Case "CusBufSetup"
                Call add_CusBufSetup()
        End Select
        grd_action = "ADD"
    End Sub

    Private Sub add_ShipMark() 'doar
        If rs_CUSHPMRK.Tables("RESULT").Rows.Count > 0 Then
            If Not func_ShpMrkIsValid() Then
                Exit Sub
            End If
            'func_ShpMrkUpdAddNew()
        End If
        save_currentshipmrk()
        optMain.Enabled = True
        optSide.Enabled = True
        optInner.Enabled = True
        txtShpMrk1.Enabled = True
        txtShpMrk2.Enabled = True
        txtShpMrk3.Enabled = True
        txtShpMrk4.Enabled = True
        'txtShpMrk(5).Enabled = True
        txtShpMrk6.Enabled = True
        txtShpMrk7.Enabled = True
        cmdShpMrkBack.Enabled = True
        cmdShpMrkNext.Enabled = True
        cmdShowPic.Enabled = True


        chkDelete.Checked = False
        optMain.Enabled = True
        optSide.Enabled = True
        optInner.Enabled = True
        txtShpMrk1.Text = ""
        txtShpMrk2.Text = ""
        txtShpMrk3.Text = ""
        txtShpMrk4.Text = ""
        'txtShpMrk(5).Text = ""
        txtShpMrk6.Text = ""
        txtShpMrk7.Text = ""
        imgShpMrk.Image = Nothing

        add_shipmrk()
        txtShpMrk7.Focus()


    End Sub
    Private Sub add_shipmrk()
        Dim rowcount As Integer
        rowcount = rs_CUSHPMRK.Tables("RESULT").Rows.Count

        rs_CUSHPMRK.Tables("RESULT").Rows.Add()
        rs_CUSHPMRK.Tables("RESULT").Rows(rowcount).Item("csm_creusr") = "~*ADD*~"
        rs_CUSHPMRK.Tables("RESULT").Rows(rowcount).Item("status") = ""
        rs_CUSHPMRK.Tables("RESULT").Rows(rowcount).Item("csm_cusno") = ""
        rs_CUSHPMRK.Tables("RESULT").Rows(rowcount).Item("csm_seqno") = 0
        rs_CUSHPMRK.Tables("RESULT").Rows(rowcount).Item("csm_custyp") = ""
        rs_CUSHPMRK.Tables("RESULT").Rows(rowcount).Item("csm_shptyp") = ""
        rs_CUSHPMRK.Tables("RESULT").Rows(rowcount).Item("csm_engdsc") = ""
        rs_CUSHPMRK.Tables("RESULT").Rows(rowcount).Item("csm_chndsc") = ""
        rs_CUSHPMRK.Tables("RESULT").Rows(rowcount).Item("csm_engrmk") = ""
        rs_CUSHPMRK.Tables("RESULT").Rows(rowcount).Item("csm_chnrmk") = ""
        rs_CUSHPMRK.Tables("RESULT").Rows(rowcount).Item("csm_imgpth") = ""
        rs_CUSHPMRK.Tables("RESULT").Rows(rowcount).Item("csm_imgnam") = ""
        rs_CUSHPMRK.Tables("RESULT").Rows(rowcount).Item("csm_cerdoc") = ""


        lblRecCount.Text = rowcount + 1 & "  /  " & rowcount + 1 & "   Records"

        currentShipmark = rowcount

    End Sub
    Private Sub add_RelCus() 'Doing
        If optPriCus.Checked = False And optSecCus.Checked = False Then
            MsgBox("Please select type")
            Exit Sub
        End If
        Dim dr() As DataRow
        Dim rowcount As Integer
        rowcount = rs_CUSUBCUS_P.Tables("RESULT").Rows.Count
        If optPriCus.Checked = True Then
            dr = rs_CUSUBCUS_P.Tables("RESULT").Select("csc_seccus = ''")
        Else
            dr = rs_CUSUBCUS_P.Tables("RESULT").Select("csc_prmcus = ''")
        End If

        If dr.Length = 0 Then
            rs_CUSUBCUS_P.Tables("RESULT").Rows.Add()
            rs_CUSUBCUS_P.Tables("RESULT").Rows(rowcount).Item("csc_creusr") = "~*ADD*~"
            rs_CUSUBCUS_P.Tables("RESULT").Rows(rowcount).Item("Status") = ""
            If optPriCus.Checked = True Then
                rs_CUSUBCUS_P.Tables("RESULT").Rows(rowcount).Item("csc_seccus") = ""
            Else
                rs_CUSUBCUS_P.Tables("RESULT").Rows(rowcount).Item("csc_prmcus") = ""
            End If
            rs_CUSUBCUS_P.Tables("RESULT").Rows(rowcount).Item("csc_cusrel") = "Active"

            Recordstatus = True
            grdRelCus.CurrentCell = grdRelCus.Rows(rowcount).Cells(2)
        End If


    End Sub
    Private Sub add_Courrier()

        Dim rowcount As Integer
        rowcount = rs_CUSHPINF_C.Tables("RESULT").Rows.Count
        Dim dr() As DataRow = rs_CUSHPINF_C.Tables("RESULT").Select("csi_csetyp = ''")
        If dr.Length = 0 Then
            rs_CUSHPINF_C.Tables("RESULT").Rows.Add()
            rs_CUSHPINF_C.Tables("RESULT").Rows(rowcount).Item("csi_creusr") = "~*ADD*~"
            rs_CUSHPINF_C.Tables("RESULT").Rows(rowcount).Item("status") = ""
            rs_CUSHPINF_C.Tables("RESULT").Rows(rowcount).Item("csi_csetyp") = ""
            rs_CUSHPINF_C.Tables("RESULT").Rows(rowcount).Item("csi_cseseq") = -1
            rs_CUSHPINF_C.Tables("RESULT").Rows(rowcount).Item("csi_csenam") = ""
            rs_CUSHPINF_C.Tables("RESULT").Rows(rowcount).Item("csi_cseacc") = ""
            rs_CUSHPINF_C.Tables("RESULT").Rows(rowcount).Item("csi_csedsc") = ""
            rs_CUSHPINF_C.Tables("RESULT").Rows(rowcount).Item("csi_cseadr") = ""
            rs_CUSHPINF_C.Tables("RESULT").Rows(rowcount).Item("csi_csestt") = ""
            rs_CUSHPINF_C.Tables("RESULT").Rows(rowcount).Item("csi_csecty") = "US - UNITED STATES"
            rs_CUSHPINF_C.Tables("RESULT").Rows(rowcount).Item("csi_csepst") = ""
            rs_CUSHPINF_C.Tables("RESULT").Rows(rowcount).Item("csi_csectp") = ""
            rs_CUSHPINF_C.Tables("RESULT").Rows(rowcount).Item("csi_csetil") = ""
            rs_CUSHPINF_C.Tables("RESULT").Rows(rowcount).Item("csi_csephn") = ""
            rs_CUSHPINF_C.Tables("RESULT").Rows(rowcount).Item("csi_csefax") = ""
            rs_CUSHPINF_C.Tables("RESULT").Rows(rowcount).Item("csi_cseeml") = ""
            rs_CUSHPINF_C.Tables("RESULT").Rows(rowcount).Item("csi_cseinr") = ""
            rs_CUSHPINF_C.Tables("RESULT").Rows(rowcount).Item("csi_csedef") = "N"

            Recordstatus = True
        End If


    End Sub


    Private Sub add_CusBufSetup()


        Dim rowcount As Integer
        rowcount = rs_CUSHPFML.Tables("RESULT").Rows.Count
        Dim dr() As DataRow = rs_CUSHPFML.Tables("RESULT").Select("csf_venno = ''")

        If dr.Length = 0 Then
            rs_CUSHPFML.Tables("RESULT").Rows.Add()

            Dim csf_cus1no As String
            Dim csf_cus2no As String


            If Add_flag = True Then
                csf_cus1no = ""
                csf_cus2no = ""
            ElseIf rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_custyp") = "P" Then
                csf_cus1no = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cusno")
                csf_cus2no = ""
            Else
                If rs_CUSUBCUS_P.Tables("RESULT").Rows.Count = 0 Then
                    MsgBox("No Primary Customer, please check")
                    Exit Sub
                End If
                csf_cus1no = rs_CUSUBCUS_P.Tables("RESULT").Rows(0).Item("csc_prmcus")
                csf_cus2no = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cusno")
            End If



            rs_CUSHPFML.Tables("RESULT").Rows(rowcount).Item("DEL") = ""
            rs_CUSHPFML.Tables("RESULT").Rows(rowcount).Item("csf_cocde") = ""
            rs_CUSHPFML.Tables("RESULT").Rows(rowcount).Item("csf_cus1no") = csf_cus1no
            rs_CUSHPFML.Tables("RESULT").Rows(rowcount).Item("csf_cus2no") = csf_cus2no
            rs_CUSHPFML.Tables("RESULT").Rows(rowcount).Item("csf_venno") = ""
            rs_CUSHPFML.Tables("RESULT").Rows(rowcount).Item("csf_shpstrbuf") = "0"
            rs_CUSHPFML.Tables("RESULT").Rows(rowcount).Item("csf_shpendbuf") = "0"
            rs_CUSHPFML.Tables("RESULT").Rows(rowcount).Item("csf_cancelbuf") = "0"
            rs_CUSHPFML.Tables("RESULT").Rows(rowcount).Item("csf_creusr") = "~*ADD*~"

            Recordstatus = True
        End If

    End Sub

    Private Sub add_prctrm()
        Dim rowcount As Integer
        rowcount = rs_CUPRCTRM.Tables("RESULT").Rows.Count
        Dim dr() As DataRow = rs_CUPRCTRM.Tables("RESULT").Select("cpt_prctrm = ''")

        If dr.Length = 0 Then
            rs_CUPRCTRM.Tables("RESULT").Rows.Add()


            rs_CUPRCTRM.Tables("RESULT").Rows(rowcount).Item("cpt_prctrm") = ""
            If rowcount = 0 Then
                rs_CUPRCTRM.Tables("RESULT").Rows(rowcount).Item("cpt_prcdef") = "Y"
            Else
                rs_CUPRCTRM.Tables("RESULT").Rows(rowcount).Item("cpt_prcdef") = "N"
            End If
            rs_CUPRCTRM.Tables("RESULT").Rows(rowcount).Item("cpt_cocde") = ""
            rs_CUPRCTRM.Tables("RESULT").Rows(rowcount).Item("cpt_creusr") = "~*ADD*~"
            'Done This


            Recordstatus = True
        End If

    End Sub
    Private Sub add_Bank()

        Dim rowcount As Integer
        rowcount = rs_CUSHPINF_B.Tables("RESULT").Rows.Count
        Dim dr() As DataRow = rs_CUSHPINF_B.Tables("RESULT").Select("csi_csetyp = ''")
        If dr.Length = 0 Then
            rs_CUSHPINF_B.Tables("RESULT").Rows.Add()
            rs_CUSHPINF_B.Tables("RESULT").Rows(rowcount).Item("csi_creusr") = "~*ADD*~"
            rs_CUSHPINF_B.Tables("RESULT").Rows(rowcount).Item("status") = ""
            rs_CUSHPINF_B.Tables("RESULT").Rows(rowcount).Item("csi_csetyp") = ""
            rs_CUSHPINF_B.Tables("RESULT").Rows(rowcount).Item("csi_cseseq") = -1
            rs_CUSHPINF_B.Tables("RESULT").Rows(rowcount).Item("csi_csenam") = ""
            rs_CUSHPINF_B.Tables("RESULT").Rows(rowcount).Item("csi_cseadr") = ""
            rs_CUSHPINF_B.Tables("RESULT").Rows(rowcount).Item("csi_csecty") = "US - UNITED STATES"
            rs_CUSHPINF_B.Tables("RESULT").Rows(rowcount).Item("csi_csepst") = ""
            rs_CUSHPINF_B.Tables("RESULT").Rows(rowcount).Item("csi_csectp") = ""
            rs_CUSHPINF_B.Tables("RESULT").Rows(rowcount).Item("csi_csetil") = ""
            rs_CUSHPINF_B.Tables("RESULT").Rows(rowcount).Item("csi_csephn") = ""
            rs_CUSHPINF_B.Tables("RESULT").Rows(rowcount).Item("csi_csefax") = ""
            rs_CUSHPINF_B.Tables("RESULT").Rows(rowcount).Item("csi_cseeml") = ""
            rs_CUSHPINF_B.Tables("RESULT").Rows(rowcount).Item("csi_csedef") = "N"

            Recordstatus = True
        End If


    End Sub
    Private Sub add_ItmCatMarkup()
        If optPriCus.Checked = True Then
            Dim rowcount As Integer
            rowcount = rs_CUMCAMRK.Tables("RESULT").Rows.Count
            Dim dr() As DataRow = rs_CUMCAMRK.Tables("RESULT").Select("ccm_ventyp = ''")
            If dr.Length = 0 Then
                rs_CUMCAMRK.Tables("RESULT").Rows.Add()
                rs_CUMCAMRK.Tables("RESULT").Rows(rowcount).Item("ccm_creusr") = "~*ADD*~"
                rs_CUMCAMRK.Tables("RESULT").Rows(rowcount).Item("ccm_cusno") = txtCusno.Text
                rs_CUMCAMRK.Tables("RESULT").Rows(rowcount).Item("ccm_markup") = ""
                rs_CUMCAMRK.Tables("RESULT").Rows(rowcount).Item("ccm_markupfml") = ""
                rs_CUMCAMRK.Tables("RESULT").Rows(rowcount).Item("ccm_effdat") = Today
                rs_CUMCAMRK.Tables("RESULT").Rows(rowcount).Item("ccm_del") = ""


                Recordstatus = True
                grdItmCatMarkup.CurrentCell = grdItmCatMarkup.Rows(rowcount).Cells(2)
            End If

        End If
    End Sub
    Private Sub add_Contact()

        Dim rowcount As Integer
        rowcount = rs_CUCNTINF_C.Tables("RESULT").Rows.Count
        Dim dr() As DataRow = rs_CUCNTINF_C.Tables("RESULT").Select("cci_cnttyp = ''")
        If dr.Length = 0 Then
            rs_CUCNTINF_C.Tables("RESULT").Rows.Add()
            rs_CUCNTINF_C.Tables("RESULT").Rows(rowcount).Item("cci_creusr") = "~*ADD*~"
            rs_CUCNTINF_C.Tables("RESULT").Rows(rowcount).Item("status") = ""
            rs_CUCNTINF_C.Tables("RESULT").Rows(rowcount).Item("cci_cnttyp") = ""
            rs_CUCNTINF_C.Tables("RESULT").Rows(rowcount).Item("cci_cntfax") = ""
            rs_CUCNTINF_C.Tables("RESULT").Rows(rowcount).Item("cci_cnteml") = ""
            rs_CUCNTINF_C.Tables("RESULT").Rows(rowcount).Item("cci_cntseq") = -1
            If rs_CUCNTINF_C.Tables("RESULT").Rows.Count = 1 Then
                rs_CUCNTINF_C.Tables("RESULT").Rows(rowcount).Item("cci_cntdef") = "Y"
            Else
                rs_CUCNTINF_C.Tables("RESULT").Rows(rowcount).Item("cci_cntdef") = "N"
            End If

            Recordstatus = True
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


            Case "ventyp"
                cboCell.Items.Add("INT")
                cboCell.Items.Add("EXT")
                cboCell.Items.Add("JV")
            Case "cocde"
                For i = 0 To rs_sycominf.Tables("RESULT").Rows.Count - 1
                    cboCell.Items.Add(rs_sycominf.Tables("RESULT").Rows(i).Item("yco_cocde"))

                Next i
            Case "cusagt"
                For i = 0 To rs_SYAGTINF.Tables("RESULT").Rows.Count - 1
                    cboCell.Items.Add(rs_SYAGTINF.Tables("RESULT").Rows(i).Item("yai_agtcde") + " - " + rs_SYAGTINF.Tables("RESULT").Rows(i).Item("yai_stnam"))

                Next i

            Case "Billcntcty"
                For i = 0 To rs_SYSETINF_02.Tables("RESULT").Rows.Count - 1
                    cboCell.Items.Add(rs_SYSETINF_02.Tables("RESULT").Rows(i).Item("ysi_cde") + " - " + rs_SYSETINF_02.Tables("RESULT").Rows(i).Item("ysi_dsc"))

                Next i
            Case "Shipcntcty"
                For i = 0 To rs_SYSETINF_02.Tables("RESULT").Rows.Count - 1
                    cboCell.Items.Add(rs_SYSETINF_02.Tables("RESULT").Rows(i).Item("ysi_cde") + " - " + rs_SYSETINF_02.Tables("RESULT").Rows(i).Item("ysi_dsc"))

                Next i

            Case "cnttyp"
                For i = 0 To rs_SYSETINF_13.Tables("RESULT").Rows.Count - 1
                    cboCell.Items.Add(rs_SYSETINF_13.Tables("RESULT").Rows(i).Item("ysi_cde") + " - " + rs_SYSETINF_13.Tables("RESULT").Rows(i).Item("ysi_dsc"))

                Next i

            Case "Markupventyp"
                cboCell.Items.Add("INT")
                cboCell.Items.Add("EXT")
                cboCell.Items.Add("JV")

            Case "Markupcat"
                cboCell.Items.Add("STANDARD")
                For i = 0 To rs_SYCATCDE.Tables("RESULT").Rows.Count - 1
                    cboCell.Items.Add(rs_SYCATCDE.Tables("RESULT").Rows(i).Item("ycc_catcde"))

                Next i

            Case "Markup"
                Dim dv As New DataView
                dv = rs_SYFMLINF.Tables("RESULT").DefaultView
                dv.Sort = "yfi_fml asc"
                Dim sortds As New DataSet
                sortds.Tables.Add(dv.ToTable("RESULT"))


                For i = 0 To sortds.Tables("RESULT").Rows.Count - 1
                    cboCell.Items.Add(sortds.Tables("RESULT").Rows(i).Item("yfi_fmlopt") + " - " + sortds.Tables("RESULT").Rows(i).Item("yfi_fml"))

                Next i

            Case "Bankcsetyp"
                cboCell.Items.Add("BK - Bank")
                cboCell.Items.Add("NP - Notify Party")
                cboCell.Items.Add("CN - Consignee")


            Case "Couriercsetyp"
                cboCell.Items.Add("FO - Ocean Forwarder")
                cboCell.Items.Add("FA - Air Forwarder")
                cboCell.Items.Add("FT - Other Forwarder")
                cboCell.Items.Add("CO - Courier")

            Case "seccus"
                For i = 0 To rs_CUBASINF_L.Tables("RESULT").Rows.Count - 1
                    If rs_CUBASINF_L.Tables("RESULT").Rows(i).Item("cbi_cusno") > "50000" Then
                        cboCell.Items.Add(rs_CUBASINF_L.Tables("RESULT").Rows(i).Item("cbi_cusno") + " - " + Trim(rs_CUBASINF_L.Tables("RESULT").Rows(i).Item("cbi_cusnam")))
                    End If
                Next i

            Case "cusnam"

                For i = 0 To rs_CUBASINF_L.Tables("RESULT").Rows.Count - 1
                    If rs_CUBASINF_L.Tables("RESULT").Rows(i).Item("cbi_cusno") > "50000" Then
                        cboCell.Items.Add(rs_CUBASINF_L.Tables("RESULT").Rows(i).Item("cbi_cusnam") + " - " + Trim(rs_CUBASINF_L.Tables("RESULT").Rows(i).Item("cbi_cusnam")))
                    End If
                Next i

            Case "PrcTrm"

                For i = 0 To rs_SYSETINF_03.Tables("RESULT").Rows.Count - 1
                    cboCell.Items.Add(rs_SYSETINF_03.Tables("RESULT").Rows(i).Item("ysi_cde") & " - " & rs_SYSETINF_03.Tables("RESULT").Rows(i).Item("ysi_dsc"))
                Next
            Case "Vendor"
                cboCell.Items.Add("INT - Internal Vendor")
                cboCell.Items.Add("EXT - External Vendor")

                For i = 0 To rs_VNBASINF.Tables("RESULT").Rows.Count - 1
                    If rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_vensts") = "A" And rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_venflag") = "U" Then
                        cboCell.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_vensna"))
                    End If
                Next i

        End Select
        cboCell.DropDownWidth = 250
        cboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox

        dgv.Rows(iRow).Cells(iCol) = cboCell
        dgv.Rows(iRow).Cells(iCol).ReadOnly = False
    End Sub
    Private Sub grdCoVen_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCoVen.CellClick
        If grdCoVen.RowCount = 0 Then
            Exit Sub
        End If

        If cboStatus.Text <> "A - Active" Then
            Exit Sub
        End If

        If grdCoVen.Rows(grdCoVen.CurrentCell.RowIndex).Cells("ccv_creusr").Value.ToString <> "~*ADD*~" Then
            Exit Sub
        End If

        Select Case grdCoVen.CurrentCell.ColumnIndex
            Case grdCoVen_ccv_ventyp
                comboBoxCell(grdCoVen, "ventyp")
            Case grdCoVen_ccv_cocde
                If grdCoVen.Rows(grdCoVen.CurrentCell.RowIndex).Cells("ccv_ventyp").Value.ToString = "" Then
                    MsgBox("Please select type")
                Else
                    comboBoxCell(grdCoVen, "cocde")
                End If
        End Select
    End Sub
    Private Sub grdCoVen_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCoVen.CellContentClick

    End Sub

    Private Sub grdCoVen_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCoVen.CellDoubleClick

        If cboStatus.Text <> "A - Active" Then
            Exit Sub
        End If

        If e.RowIndex = -1 Then
            Exit Sub
        End If

        If grdCoVen.RowCount > 0 Then
            
            Dim iCol As Integer = grdCoVen.CurrentCell.ColumnIndex
            Dim iRow As Integer = grdCoVen.CurrentCell.RowIndex

            If grdCoVen.CurrentCell.ColumnIndex = grdCoVen_del Then
                If grdCoVen.Rows(grdCoVen.CurrentCell.RowIndex).Cells("ccv_ventyp").Value.ToString = "" Then
                    MsgBox("Please select type")
                    Exit Sub
                End If

                Dim curvalue As String
                curvalue = grdCoVen.CurrentCell.Value.ToString
                If Trim(curvalue) = "" Then
                    Dim i As Integer
                    Dim counter As Integer
                    counter = 0
                    For i = 0 To grdCoVen.RowCount - 1
                        If Trim(grdCoVen.Item(grdCoVen_del, i).Value) = "" Then
                            counter = counter + 1
                        End If
                    Next i

                    'If counter = 1 Then
                    '    MsgBox("At least one color must exist!")
                    '    Exit Sub
                    'Else

                    rs_CUMCOVEN.Tables("RESULT").AcceptChanges()
                    Dim current As String = grdCoVen.Item(grdCoVen_ccv_ventyp, iRow).Value
                    Dim dr() As DataRow
                    dr = rs_CUMCOVEN.Tables("RESULT").Select("ccv_ventyp = '" & current & "'")
                    If dr.Length = 1 Then
                        If MsgBox("Are you sure to delete Default record", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                            Exit Sub
                        End If
                    ElseIf dr.Length > 1 Then
                        If grdCoVen.Item(grdCoVen_ccv_vendef, iRow).Value = "Y" Then
                            MsgBox("Please change default to other record")
                            Exit Sub
                        End If
                    End If
                    grdCoVen.Item(grdCoVen_del, iRow).Value = "Y"

                    If grdCoVen.Item(grdCoVen_ccv_creus, iRow).Value <> "~*ADD*~" And _
                    grdCoVen.Item(grdCoVen_ccv_creus, iRow).Value <> "~*DEL*~" And _
                    grdCoVen.Item(grdCoVen_ccv_creus, iRow).Value <> "~*NEW*~" Then
                        grdCoVen.Item(grdCoVen_ccv_creus, iRow).Value = "~*DEL*~"
                    ElseIf grdCoVen.Item(grdCoVen_ccv_creus, iRow).Value = "~*ADD*~" Then
                        grdCoVen.Item(grdCoVen_ccv_creus, iRow).Value = "~*NEW*~"
                    End If

                    'End If

                Else

                    grdCoVen.Item(grdCoVen_del, iRow).Value = ""
                    If grdCoVen.Item(grdCoVen_ccv_creus, iRow).Value = "~*ADD*~" Then
                        grdCoVen.Item(grdCoVen_ccv_creus, iRow).Value = "~*UPD*~"
                    ElseIf grdCoVen.Item(grdCoVen_ccv_creus, iRow).Value = "~*NEW*~" Then
                        grdCoVen.Item(grdCoVen_ccv_creus, iRow).Value = "~*ADD*~"
                    ElseIf grdCoVen.Item(grdCoVen_ccv_creus, iRow).Value = "~*DEL*~" Then
                        grdCoVen.Item(grdCoVen_ccv_creus, iRow).Value = "~*UPD*~"
                    End If

                End If



            ElseIf grdCoVen.CurrentCell.ColumnIndex = grdCoVen_ccv_vendef Then

                changeDefaultgrdCoVen()


            End If

            If grdCoVen.Item(grdCoVen_ccv_creus, iRow).Value <> "~*ADD*~" And _
             grdCoVen.Item(grdCoVen_ccv_creus, iRow).Value <> "~*NEW*~" And _
              grdCoVen.Item(grdCoVen_ccv_creus, iRow).Value <> "~*DEL*~" Then
                grdCoVen.Item(grdCoVen_ccv_creus, iRow).Value = "~*UPD*~"
                Recordstatus = True
            End If
        End If

    End Sub
    Private Sub changeDefaultgrdCoVen()



        If grdCoVen.Item(5, grdCoVen.CurrentCell.RowIndex).Value = "Y" Then
            Exit Sub
        End If

        If grdCoVen.Item(grdCoVen_del, grdCoVen.CurrentCell.RowIndex).Value = "Y" Then
            Exit Sub
        End If

        Dim default_vn As String
        default_vn = grdCoVen.Item(grdCoVen_ccv_ventyp, grdCoVen.CurrentCell.RowIndex).Value

        Dim tmp_vn As String

        Dim i As Integer
        For i = 0 To rs_CUMCOVEN.Tables("RESULT").Rows.Count - 1
            tmp_vn = rs_CUMCOVEN.Tables("RESULT").Rows(i).Item("ccv_ventyp")

            If default_vn = tmp_vn Then
                If rs_CUMCOVEN.Tables("RESULT").Rows(i).Item("ccv_creusr") <> "~*ADD*~" Then
                    rs_CUMCOVEN.Tables("RESULT").Rows(i).Item("ccv_creusr") = "~*UPD*~"
                End If

                rs_CUMCOVEN.Tables("RESULT").Rows(i).Item("ccv_vendef") = "N"
                Recordstatus = True


            End If

        Next i
        grdCoVen.Item(5, grdCoVen.CurrentCell.RowIndex).Value = "Y"
        If grdCoVen.Item(7, grdCoVen.CurrentCell.RowIndex).Value <> "~*ADD*~" And _
        grdCoVen.Item(7, grdCoVen.CurrentCell.RowIndex).Value <> "~*UPD*~" And _
        grdCoVen.Item(7, grdCoVen.CurrentCell.RowIndex).Value <> "~*NEW*~" And _
        grdCoVen.Item(7, grdCoVen.CurrentCell.RowIndex).Value <> "~*DEL*~" Then
            grdCoVen.Item(7, grdCoVen.CurrentCell.RowIndex).Value = "~*UPD*~"
        End If
    End Sub

    Private Sub grdCoVen_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCoVen.CellEndEdit
        If grdCoVen.RowCount = 0 Then
            Exit Sub
        End If
        'do
        Dim cocde As String = Trim(grdCoVen.Item(grdCoVen_ccv_cocde, grdCoVen.CurrentCell.RowIndex).Value.ToString)
        Dim type As String = Trim(grdCoVen.Item(grdCoVen_ccv_ventyp, grdCoVen.CurrentCell.RowIndex).Value.ToString)
        Dim currentrow As Integer = grdCoVen.CurrentCell.RowIndex
        grdCoVen.Columns(grdCoVen.CurrentCell.ColumnIndex).ReadOnly = True

        Select Case grdCoVen.CurrentCell.ColumnIndex

            Case grdCoVen_ccv_cocde
                If Trim(grdCoVen.CurrentCell.Value.ToString) = "" Then
                    Exit Sub
                Else
                    Dim dr() As DataRow = rs_sycominf.Tables("RESULT").Select("yco_cocde = '" & grdCoVen.CurrentCell.Value & "'")
                    If dr.Length <> 0 Then
                        grdCoVen.Item(grdCoVen_yco_shtnam, grdCoVen.CurrentCell.RowIndex).Value = dr(0).Item("yco_shtnam")
                    Else
                        MsgBox("Company Not Found! Please select again.")
                    End If
                End If
            Case grdCoVen_ccv_ventyp

                Dim current As String
                current = grdCoVen.Item(grdCoVen_ccv_ventyp, currentrow).Value
                rs_CUMCOVEN.Tables("RESULT").AcceptChanges()

                Dim dr1() As DataRow = rs_CUMCOVEN.Tables("RESULT").Select("ccv_ventyp = '" & current & "'")
                If dr1.Length = 1 Then
                    grdCoVen.Item(grdCoVen_ccv_vendef, grdCoVen.CurrentCell.RowIndex).Value = "Y"
                End If

                Dim dr() As DataRow = rs_CUMCOVEN.Tables("RESULT").Select("ccv_vendef = 'Y' and ccv_ventyp = '" & current & "'")
                If dr.Length > 1 Then
                    grdCoVen.Item(grdCoVen_ccv_vendef, grdCoVen.CurrentCell.RowIndex).Value = "N"
                End If

        End Select


    
        rs_CUMCOVEN.Tables("RESULT").AcceptChanges()
        If cocde <> "" And type <> "" Then
            Dim drr() As DataRow = rs_CUMCOVEN.Tables("RESULT").Select("ccv_cocde = '" & cocde & "' and ccv_ventyp = '" _
                                                                 & type & "'")
            If drr.Length > 1 Then

                MsgBox("Duplicate Vendor type and Company record")
                grdCoVen.Item(grdCoVen_ccv_cocde, currentrow).Value = ""
                grdCoVen.Item(grdCoVen_yco_shtnam, currentrow).Value = ""


            End If

        End If

        

    End Sub

    
    Private Sub grdCoVen_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCoVen.CellValidated
     


    End Sub

    

    Private Sub grdCoVen_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdCoVen.EditingControlShowing
        If grdCoVen.RowCount = 0 Then
            Exit Sub
        End If
        If cboStatus.Text <> "A - Active" Then
            Exit Sub
        End If

        e.CellStyle.BackColor = Color.White

        Select Case grdCoVen.CurrentCell.ColumnIndex
            Case grdCoVen_ccv_ventyp, grdCoVen_ccv_cocde
                If TypeOf (e.Control) Is DataGridViewComboBoxEditingControl Then
                    Dim cboBox As ComboBox = CType(e.Control, ComboBox)
                    If Not cboBox Is Nothing Then
                        'RemoveHandler cboBox.SelectedIndexChanged, AddressOf cbo_dgCostPrice_SelectedIndexChanged
                        'AddHandler cboBox.SelectedIndexChanged, AddressOf cbo_dgCostPrice_SelectedIndexChanged
                    End If
                End If

        End Select


        'If mode = "UPDATE" Or mode = "ADD" Then

        Recordstatus = True
        If grdCoVen.Item(grdCoVen_ccv_creus, grdCoVen.CurrentCell.RowIndex).Value <> "~*ADD*~" And _
        grdCoVen.Item(grdCoVen_ccv_creus, grdCoVen.CurrentCell.RowIndex).Value <> "~*DEL*~" And _
        grdCoVen.Item(grdCoVen_ccv_creus, grdCoVen.CurrentCell.RowIndex).Value <> "~*UPD*~" And _
        grdCoVen.Item(grdCoVen_ccv_creus, grdCoVen.CurrentCell.RowIndex).Value <> "~*NEW*~" Then ''creusr or upusr?
            grdCoVen.Item(grdCoVen_ccv_creus, grdCoVen.CurrentCell.RowIndex).Value = "~*UPD*~"
        End If
        'End If
    End Sub

    Private Sub grdCoVen_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdCoVen.GotFocus
        Got_Focus_Grid = "Coven"
    End Sub


    Private Sub add_Shipping()

        Dim rowcount As Integer
        rowcount = rs_CUCNTINF_S.Tables("RESULT").Rows.Count
        Dim dr() As DataRow = rs_CUCNTINF_S.Tables("RESULT").Select("cci_cntadr = ''")
        If dr.Length = 0 Then
            rs_CUCNTINF_S.Tables("RESULT").Rows.Add()
            rs_CUCNTINF_S.Tables("RESULT").Rows(rowcount).Item("cci_creusr") = "~*ADD*~"
            rs_CUCNTINF_S.Tables("RESULT").Rows(rowcount).Item("status") = ""
            rs_CUCNTINF_S.Tables("RESULT").Rows(rowcount).Item("cci_cntadr") = ""
            rs_CUCNTINF_S.Tables("RESULT").Rows(rowcount).Item("cci_cntstt") = ""
            rs_CUCNTINF_S.Tables("RESULT").Rows(rowcount).Item("cci_cntcty") = "US - UNITED STATES"
            rs_CUCNTINF_S.Tables("RESULT").Rows(rowcount).Item("cci_cntpst") = ""
            rs_CUCNTINF_S.Tables("RESULT").Rows(rowcount).Item("cci_cntseq") = -1
            If rs_CUCNTINF_S.Tables("RESULT").Rows.Count = 1 Then
                rs_CUCNTINF_S.Tables("RESULT").Rows(rowcount).Item("cci_cntdef") = "Y"
            Else
                rs_CUCNTINF_S.Tables("RESULT").Rows(rowcount).Item("cci_cntdef") = "N"
            End If

            Recordstatus = True

            grdShipping.CurrentCell = grdShipping.Item(1, rowcount)
        End If


    End Sub



    Private Sub add_Billing()

        Dim rowcount As Integer
        rowcount = rs_CUCNTINF_B.Tables("RESULT").Rows.Count
        Dim dr() As DataRow = rs_CUCNTINF_B.Tables("RESULT").Select("cci_cntadr = ''")
        If dr.Length = 0 Then
            rs_CUCNTINF_B.Tables("RESULT").Rows.Add()
            rs_CUCNTINF_B.Tables("RESULT").Rows(rowcount).Item("cci_creusr") = "~*ADD*~"
            rs_CUCNTINF_B.Tables("RESULT").Rows(rowcount).Item("status") = ""
            rs_CUCNTINF_B.Tables("RESULT").Rows(rowcount).Item("cci_cntadr") = ""
            rs_CUCNTINF_B.Tables("RESULT").Rows(rowcount).Item("cci_cntstt") = ""
            rs_CUCNTINF_B.Tables("RESULT").Rows(rowcount).Item("cci_cntcty") = "US - UNITED STATES"
            rs_CUCNTINF_B.Tables("RESULT").Rows(rowcount).Item("cci_cntpst") = ""
            rs_CUCNTINF_B.Tables("RESULT").Rows(rowcount).Item("cci_cntseq") = -1
            If rs_CUCNTINF_B.Tables("RESULT").Rows.Count = 1 Then
                rs_CUCNTINF_B.Tables("RESULT").Rows(rowcount).Item("cci_cntdef") = "Y"
            Else
                rs_CUCNTINF_B.Tables("RESULT").Rows(rowcount).Item("cci_cntdef") = "N"
            End If

            Recordstatus = True
        End If


    End Sub




    Private Sub add_Agent()

        Dim rowcount As Integer
        rowcount = rs_CUAGTINF.Tables("RESULT").Rows.Count
        Dim dr() As DataRow = rs_CUAGTINF.Tables("RESULT").Select("cai_cusagt = ''")
        If dr.Length = 0 Then
            rs_CUAGTINF.Tables("RESULT").Rows.Add()
            rs_CUAGTINF.Tables("RESULT").Rows(rowcount).Item("cai_creusr") = "~*ADD*~"
            If rs_CUAGTINF.Tables("RESULT").Rows.Count = 1 Then
                rs_CUAGTINF.Tables("RESULT").Rows(rowcount).Item("cai_cusdef") = "Y"
            Else
                rs_CUAGTINF.Tables("RESULT").Rows(rowcount).Item("cai_cusdef") = "N"
            End If

            rs_CUAGTINF.Tables("RESULT").Rows(rowcount).Item("cai_cusagt") = ""
            ' rs_CUAGTINF.Tables("RESULT").Rows(rowcount).Item("cai_comrat") = 0
            rs_CUAGTINF.Tables("RESULT").Rows(rowcount).Item("Status") = ""
            Recordstatus = True
        End If


    End Sub
    Private Sub add_CusVen()

        Dim rowcount As Integer
        rowcount = rs_CUVENINF.Tables("RESULT").Rows.Count
        Dim dr() As DataRow = rs_CUVENINF.Tables("RESULT").Select("cvi_assvid = ''")
        If dr.Length = 0 Then
            rs_CUVENINF.Tables("RESULT").Rows.Add()
            rs_CUVENINF.Tables("RESULT").Rows(rowcount).Item("cvi_creusr") = "~*ADD*~"
            rs_CUVENINF.Tables("RESULT").Rows(rowcount).Item("cvi_assvid") = ""
            rs_CUVENINF.Tables("RESULT").Rows(rowcount).Item("status") = ""
            Recordstatus = True

            grdCusVen.CurrentCell = grdCusVen.Rows(rowcount).Cells(grdCusVen_cvi_assvid)
        End If


    End Sub
    Private Sub add_Coven()
        If optPriCus.Checked = True Then
            Dim rowcount As Integer
            rowcount = rs_CUMCOVEN.Tables("RESULT").Rows.Count
            Dim dr() As DataRow = rs_CUMCOVEN.Tables("RESULT").Select("ccv_ventyp = ''")
            If dr.Length = 0 Then
                rs_CUMCOVEN.Tables("RESULT").Rows.Add()
                rs_CUMCOVEN.Tables("RESULT").Rows(rowcount).Item("ccv_creusr") = "~*ADD*~"
                rs_CUMCOVEN.Tables("RESULT").Rows(rowcount).Item("ccv_cusno") = txtCusno.Text
                rs_CUMCOVEN.Tables("RESULT").Rows(rowcount).Item("ccv_cocde") = ""
                rs_CUMCOVEN.Tables("RESULT").Rows(rowcount).Item("ccv_ventyp") = ""
                rs_CUMCOVEN.Tables("RESULT").Rows(rowcount).Item("ccv_effdat") = Format(Date.Now, "yyyy-MM-dd")
                rs_CUMCOVEN.Tables("RESULT").Rows(rowcount).Item("ccv_del") = ""
                If rowcount = 0 Then
                    rs_CUMCOVEN.Tables("RESULT").Rows(rowcount).Item("ccv_vendef") = "Y"
                Else
                    rs_CUMCOVEN.Tables("RESULT").Rows(rowcount).Item("ccv_vendef") = "N"
                End If
                Recordstatus = True

                grdCoVen.CurrentCell = grdCoVen.Rows(rowcount).Cells(2)
            End If

        End If
    End Sub

    Private Sub grdAgent_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdAgent.CellClick

        If cboStatus.Text <> "A - Active" Then
            Exit Sub
        End If

        If grdAgent.RowCount = 0 Then
            Exit Sub
        End If



        Select Case grdAgent.CurrentCell.ColumnIndex
            Case grdAgent_cai_cusagt

                If grdAgent.Rows(grdAgent.CurrentCell.RowIndex).Cells("cai_creusr").Value.ToString <> "~*ADD*~" Then
                    Exit Sub
                End If
                comboBoxCell(grdAgent, "cusagt")


        End Select
    End Sub

    Private Sub grdAgent_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdAgent.CellContentClick

    End Sub

    Private Sub grdAgent_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdAgent.CellDoubleClick

        If cboStatus.Text <> "A - Active" Then
            Exit Sub
        End If
        If e.RowIndex = -1 Then
            Exit Sub
        End If


        If grdAgent.RowCount > 0 Then
           
            Dim iCol As Integer = grdAgent.CurrentCell.ColumnIndex
            Dim iRow As Integer = grdAgent.CurrentCell.RowIndex

            If grdAgent.CurrentCell.ColumnIndex = grdAgent_Status And e.ColumnIndex = 0 And e.RowIndex >= 0 Then
                If grdAgent.Rows(grdAgent.CurrentCell.RowIndex).Cells("cai_cusagt").Value.ToString = "" Then
                    MsgBox("Please select type")
                    Exit Sub
                End If
               
                Dim curvalue As String
                curvalue = grdAgent.CurrentCell.Value
                If Trim(curvalue) = "" Then
                    Dim i As Integer
                    Dim counter As Integer
                    counter = 0
                    For i = 0 To grdAgent.RowCount - 1
                        If Trim(grdAgent.Item(grdAgent_Status, i).Value) = "" Then
                            counter = counter + 1
                        End If
                    Next i

                    'If counter = 1 Then
                    '    MsgBox("At least one color must exist!")
                    '    Exit Sub
                    'Else
                    rs_CUAGTINF.Tables("RESULT").AcceptChanges()
                    If rs_CUAGTINF.Tables("RESULT").Rows.Count = 1 Then
                        If MsgBox("Are you sure to delete Default Agent", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                            Exit Sub
                        End If
                    ElseIf rs_CUAGTINF.Tables("RESULT").Rows.Count > 1 Then
                        If grdAgent.Item(grdAgent_cai_cusdef, iRow).Value = "Y" Then
                            MsgBox("Please change default to other record")
                            Exit Sub
                        End If
                    End If



                    grdAgent.Item(grdAgent_Status, iRow).Value = "Y"
                    If grdAgent.Item(grdAgent_cai_creusr, iRow).Value <> "~*ADD*~" And _
                    grdAgent.Item(grdAgent_cai_creusr, iRow).Value <> "~*DEL*~" And _
                    grdAgent.Item(grdAgent_cai_creusr, iRow).Value <> "~*NEW*~" Then
                        grdAgent.Item(grdAgent_cai_creusr, iRow).Value = "~*DEL*~"
                    ElseIf grdAgent.Item(grdAgent_cai_creusr, iRow).Value = "~*ADD*~" Then
                        grdAgent.Item(grdAgent_cai_creusr, iRow).Value = "~*NEW*~"
                    End If

                Else
                    grdAgent.Item(grdAgent_Status, iRow).Value = ""
                    If grdAgent.Item(grdAgent_cai_creusr, iRow).Value = "~*ADD*~" Then
                        grdAgent.Item(grdAgent_cai_creusr, iRow).Value = "~*UPD*~"
                    ElseIf grdAgent.Item(grdAgent_cai_creusr, iRow).Value = "~*NEW*~" Then
                        grdAgent.Item(grdAgent_cai_creusr, iRow).Value = "~*ADD*~"
                    ElseIf grdAgent.Item(grdAgent_cai_creusr, iRow).Value = "~*DEL*~" Then
                        grdAgent.Item(grdAgent_cai_creusr, iRow).Value = "~*UPD*~"
                    End If


                End If
            ElseIf grdAgent.CurrentCell.ColumnIndex = grdAgent_cai_cusdef And e.ColumnIndex = 5 And e.RowIndex >= 0 Then

                changeDefaultgrdAgent()

            End If
            If grdAgent.Item(grdAgent_cai_creusr, iRow).Value <> "~*ADD*~" And _
            grdAgent.Item(grdAgent_cai_creusr, iRow).Value <> "~*DEL*~" And _
            grdAgent.Item(grdAgent_cai_creusr, iRow).Value <> "~*NEW*~" And _
             grdAgent.Item(grdAgent_cai_creusr, iRow).Value <> "~*UPD*~" Then
                grdAgent.Item(grdAgent_cai_creusr, iRow).Value = "~*UPD*~"
                Recordstatus = True
            End If

        End If


    End Sub
    Private Sub changeDefaultprctrm()
        If grdPrctrm.Item(grdPrctrm_cpt_prcdef, grdPrctrm.CurrentCell.RowIndex).Value = "Y" Then
            Exit Sub
        End If

        If grdPrctrm.Item(grdPrctrm_cpt_cocde, grdPrctrm.CurrentCell.RowIndex).Value = "Y" Then
            Exit Sub
        End If

        Dim default_vn As String
        default_vn = grdPrctrm.Item(grdPrctrm_cpt_prctrm, grdPrctrm.CurrentCell.RowIndex).Value

        Dim tmp_vn As String

        Dim i As Integer
        For i = 0 To rs_CUPRCTRM.Tables("RESULT").Rows.Count - 1
            tmp_vn = rs_CUPRCTRM.Tables("RESULT").Rows(i).Item("cpt_prctrm")

            If default_vn = tmp_vn Then
                If rs_CUPRCTRM.Tables("RESULT").Rows(i).Item("cpt_creusr") <> "~*ADD*~" And _
                    rs_CUPRCTRM.Tables("RESULT").Rows(i).Item("cpt_creusr") <> "~*NEW*~" And _
                    rs_CUPRCTRM.Tables("RESULT").Rows(i).Item("cpt_creusr") <> "~*UPD*~" And _
                    rs_CUPRCTRM.Tables("RESULT").Rows(i).Item("cpt_creusr") <> "~*DEL*~" Then
                    rs_CUPRCTRM.Tables("RESULT").Rows(i).Item("cpt_creusr") = "~*UPD*~"
                End If
                rs_CUPRCTRM.Tables("RESULT").Rows(i).Item("cpt_prcdef") = "Y"
                Recordstatus = True
            ElseIf rs_CUPRCTRM.Tables("RESULT").Rows(i).Item("cpt_prcdef") = "Y" Then
                If rs_CUPRCTRM.Tables("RESULT").Rows(i).Item("cpt_creusr") <> "~*ADD*~" And _
                rs_CUPRCTRM.Tables("RESULT").Rows(i).Item("cpt_creusr") <> "~*NEW*~" And _
                rs_CUPRCTRM.Tables("RESULT").Rows(i).Item("cpt_creusr") <> "~*UPD*~" And _
                rs_CUPRCTRM.Tables("RESULT").Rows(i).Item("cpt_creusr") <> "~*DEL*~" Then
                    rs_CUPRCTRM.Tables("RESULT").Rows(i).Item("cpt_creusr") = "~*UPD*~"
                End If
                rs_CUPRCTRM.Tables("RESULT").Rows(i).Item("cpt_prcdef") = "N"
                Recordstatus = True

            End If
        Next

    End Sub
    Private Sub changeDefaultgrdAgent()



        If grdAgent.Item(grdAgent_cai_cusdef, grdAgent.CurrentCell.RowIndex).Value = "Y" Then
            Exit Sub
        End If

        If grdAgent.Item(grdAgent_Status, grdAgent.CurrentCell.RowIndex).Value = "Y" Then
            Exit Sub
        End If

        Dim default_vn As String
        default_vn = grdAgent.Item(grdAgent_cai_cusagt, grdAgent.CurrentCell.RowIndex).Value

        Dim tmp_vn As String

        Dim i As Integer
        For i = 0 To rs_CUAGTINF.Tables("RESULT").Rows.Count - 1
            tmp_vn = rs_CUAGTINF.Tables("RESULT").Rows(i).Item("cai_cusagt")

            If default_vn = tmp_vn Then
                If rs_CUAGTINF.Tables("RESULT").Rows(i).Item("cai_creusr") <> "~*ADD*~" And _
                rs_CUAGTINF.Tables("RESULT").Rows(i).Item("cai_creusr") <> "~*NEW*~" And _
                rs_CUAGTINF.Tables("RESULT").Rows(i).Item("cai_creusr") <> "~*UPD*~" And _
                rs_CUAGTINF.Tables("RESULT").Rows(i).Item("cai_creusr") <> "~*DEL*~" Then
                    rs_CUAGTINF.Tables("RESULT").Rows(i).Item("cai_creusr") = "~*UPD*~"
                End If
                rs_CUAGTINF.Tables("RESULT").Rows(i).Item("cai_cusdef") = "Y"
                Recordstatus = True
            ElseIf rs_CUAGTINF.Tables("RESULT").Rows(i).Item("cai_cusdef") = "Y" Then
                If rs_CUAGTINF.Tables("RESULT").Rows(i).Item("cai_creusr") <> "~*ADD*~" And _
                rs_CUAGTINF.Tables("RESULT").Rows(i).Item("cai_creusr") <> "~*NEW*~" And _
                rs_CUAGTINF.Tables("RESULT").Rows(i).Item("cai_creusr") <> "~*UPD*~" And _
                rs_CUAGTINF.Tables("RESULT").Rows(i).Item("cai_creusr") <> "~*DEL*~" Then
                    rs_CUAGTINF.Tables("RESULT").Rows(i).Item("cai_creusr") = "~*UPD*~"
                End If
                rs_CUAGTINF.Tables("RESULT").Rows(i).Item("cai_cusdef") = "N"
                Recordstatus = True
            End If

        Next i
    End Sub

    Private Sub grdAgent_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdAgent.CellEndEdit
        If grdAgent.RowCount = 0 Then
            Exit Sub
        End If
        'do
        Dim Agent As String = Trim(grdAgent.Item(grdAgent_cai_cusagt, grdAgent.CurrentCell.RowIndex).Value.ToString)

        Dim currentrow As Integer = grdAgent.CurrentCell.RowIndex

        grdAgent.Columns(grdAgent_cai_cusagt).ReadOnly = True


        Select Case grdAgent.CurrentCell.ColumnIndex
            Case grdAgent_cai_cusagt
                If Trim(grdAgent.CurrentCell.Value.ToString) = "" Then
                    Exit Sub
                Else
                    Dim Agentcode As String
                    Agentcode = Split(grdAgent.CurrentCell.Value.ToString, " - ")(0)

                    gspStr = "sp_select_SYAGTINF '','" & Agentcode & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs_SYAGTINF_S, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading grdAgent_CellEndEdit sp_select_SYAGTINF :" & rtnStr)
                        Exit Sub
                    End If

                    If rs_SYAGTINF_S.Tables("RESULT").Rows.Count <> 0 Then
                        grdAgent.Item(grdAgent_cai_comrat, grdAgent.CurrentCell.RowIndex).Value = rs_SYAGTINF_S.Tables("RESULT").Rows(0).Item("yai_bscrat")
                    Else
                        grdAgent.Item(grdAgent_cai_comrat, grdAgent.CurrentCell.RowIndex).Value = 0
                    End If

                  
                End If


        End Select

        rs_CUAGTINF.Tables("RESULT").AcceptChanges()
        If Agent <> "" Then
            Dim drr() As DataRow = rs_CUAGTINF.Tables("RESULT").Select("cai_cusagt = '" & Agent & "'")

            If drr.Length > 1 Then

                MsgBox("Duplicate Agent record")
                grdAgent.Item(grdAgent_cai_cusagt, currentrow).Value = ""

                grdAgent.Item(grdAgent_cai_comrat, currentrow).Value = 0

            End If

        End If



    End Sub

    Private Sub grdAgent_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdAgent.CellValidating
        If e.ColumnIndex = grdAgent_cai_comrat Then
            If Not IsNumeric(e.FormattedValue) Then
                MsgBox("Commission must be a numeric value.")
                e.Cancel = True
            End If

        End If
    End Sub

    Private Sub grdAgent_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdAgent.EditingControlShowing
        If grdAgent.RowCount = 0 Then
            Exit Sub
        End If
        If cboStatus.Text <> "A - Active" Then
            Exit Sub
        End If

        e.CellStyle.BackColor = Color.White

        Select Case grdAgent.CurrentCell.ColumnIndex
            Case grdAgent_cai_cusagt
                If TypeOf (e.Control) Is DataGridViewComboBoxEditingControl Then
                    Dim cboBox As ComboBox = CType(e.Control, ComboBox)
                    If Not cboBox Is Nothing Then
                        'RemoveHandler cboBox.SelectedIndexChanged, AddressOf cbo_dgCostPrice_SelectedIndexChanged
                        'AddHandler cboBox.SelectedIndexChanged, AddressOf cbo_dgCostPrice_SelectedIndexChanged
                    End If
                End If

        End Select


        'If mode = "UPDATE" Or mode = "ADD" Then
        Recordstatus = True
        If grdAgent.Item(grdAgent_cai_creusr, grdAgent.CurrentCell.RowIndex).Value <> "~*ADD*~" And _
        grdAgent.Item(grdAgent_cai_creusr, grdAgent.CurrentCell.RowIndex).Value <> "~*UPD*~" And _
        grdAgent.Item(grdAgent_cai_creusr, grdAgent.CurrentCell.RowIndex).Value <> "~*NEW*~" And _
        grdAgent.Item(grdAgent_cai_creusr, grdAgent.CurrentCell.RowIndex).Value <> "~*DEL*~" Then ''creusr or upusr?
            grdAgent.Item(grdAgent_cai_creusr, grdAgent.CurrentCell.RowIndex).Value = "~*UPD*~"
        End If
    End Sub

    Private Sub grdAgent_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdAgent.GotFocus
        Got_Focus_Grid = "Agent"
    End Sub

    Private Sub grdCusVen_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCusVen.CellContentClick

    End Sub

    Private Sub grdCusVen_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCusVen.CellDoubleClick

        If cboStatus.Text <> "A - Active" Then
            Exit Sub
        End If
        If e.RowIndex = -1 Then
            Exit Sub
        End If

        If grdCusVen.RowCount > 0 Then
            
            If grdCusVen.CurrentCell.ColumnIndex = grdCusVen_Status And e.ColumnIndex = 0 And e.RowIndex >= 0 Then
                Dim iCol As Integer = grdCusVen.CurrentCell.ColumnIndex
                Dim iRow As Integer = grdCusVen.CurrentCell.RowIndex
                Dim curvalue As String
                curvalue = grdCusVen.CurrentCell.Value

                If Trim(curvalue) = "" Then
                    Dim i As Integer
                    Dim counter As Integer
                    counter = 0
                    For i = 0 To grdCusVen.RowCount - 1
                        If Trim(grdCusVen.Item(grdCusVen_Status, i).Value) = "" Then
                            counter = counter + 1
                        End If
                    Next i

                    'If counter = 1 Then
                    '    MsgBox("At least one color must exist!")
                    '    Exit Sub
                    'Else
                    grdCusVen.Item(grdCusVen_Status, iRow).Value = "Y"
                    If grdCusVen.Item(grdcusven_cvi_creusr, iRow).Value <> "~*ADD*~" And _
                     grdCusVen.Item(grdcusven_cvi_creusr, iRow).Value <> "~*DEL*~" And _
                     grdCusVen.Item(grdcusven_cvi_creusr, iRow).Value <> "~*NEW*~" Then
                        grdCusVen.Item(grdcusven_cvi_creusr, iRow).Value = "~*DEL*~"
                    ElseIf grdCusVen.Item(grdcusven_cvi_creusr, iRow).Value = "~*ADD*~" Then
                        grdCusVen.Item(grdcusven_cvi_creusr, iRow).Value = "~*NEW*~"
                    End If


                Else
                    grdCusVen.Item(grdCusVen_Status, iRow).Value = ""
                    If grdCusVen.Item(grdcusven_cvi_creusr, iRow).Value = "~*ADD*~" Then
                        grdCusVen.Item(grdcusven_cvi_creusr, iRow).Value = "~*UPD*~"
                    ElseIf grdCusVen.Item(grdcusven_cvi_creusr, iRow).Value = "~*NEW*~" Then
                        grdCusVen.Item(grdcusven_cvi_creusr, iRow).Value = "~*ADD*~"
                    ElseIf grdCusVen.Item(grdcusven_cvi_creusr, iRow).Value = "~*DEL*~" Then
                        grdCusVen.Item(grdcusven_cvi_creusr, iRow).Value = "~*UPD*~"
                    End If
                End If



                If grdCusVen.Item(grdcusven_cvi_creusr, iRow).Value <> "~*ADD*~" And _
grdCusVen.Item(grdcusven_cvi_creusr, iRow).Value <> "~*UPD*~" And _
grdCusVen.Item(grdcusven_cvi_creusr, iRow).Value <> "~*DEL*~" And _
grdCusVen.Item(grdcusven_cvi_creusr, iRow).Value <> "~*NEW*~" Then
                    grdCusVen.Item(grdcusven_cvi_creusr, iRow).Value = "~*UPD*~"
                    Recordstatus = True
                End If

            End If
        End If


    End Sub

    Private Sub grdCusVen_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCusVen.CellEndEdit
        
    End Sub

    Private Sub grdCusVen_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdCusVen.EditingControlShowing
        If cboStatus.Text <> "A - Active" Then
            Exit Sub
        End If

        If rs_CUVENINF.Tables("RESULT").Rows.Count > 0 Then
            Recordstatus = True
            If grdCusVen.Item(grdcusven_cvi_creusr, grdCusVen.CurrentCell.RowIndex).Value <> "~*ADD*~" And _
            grdCusVen.Item(grdcusven_cvi_creusr, grdCusVen.CurrentCell.RowIndex).Value <> "~*DEL*~" And _
            grdCusVen.Item(grdcusven_cvi_creusr, grdCusVen.CurrentCell.RowIndex).Value <> "~*NEW*~" And _
            grdCusVen.Item(grdcusven_cvi_creusr, grdCusVen.CurrentCell.RowIndex).Value <> "~*UPD*~" Then
                grdCusVen.Item(grdcusven_cvi_creusr, grdCusVen.CurrentCell.RowIndex).Value = "~*UPD*~"
                Recordstatus = True
            End If
        End If

    End Sub

   
  

    Private Sub grdCusVen_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdCusVen.GotFocus
        Got_Focus_Grid = "CusVen"
    End Sub

    Private Sub grdBilling_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdBilling.CellClick
        If grdBilling.RowCount = 0 Then
            Exit Sub
        End If
        If cboStatus.Text <> "A - Active" Then
            Exit Sub
        End If

        Select Case grdBilling.CurrentCell.ColumnIndex
            Case grdBilling_cci_cntcty
                comboBoxCell(grdBilling, "Billcntcty")


        End Select
    End Sub

    Private Sub grdBilling_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdBilling.CellContentClick

    End Sub

    Private Sub grdBilling_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdBilling.CellDoubleClick
        If cboStatus.Text <> "A - Active" Then
            Exit Sub
        End If
        If e.RowIndex = -1 Then
            Exit Sub
        End If
        'lok
        If grdBilling.RowCount > 0 Then
            
            Dim iCol As Integer = grdBilling.CurrentCell.ColumnIndex
            Dim iRow As Integer = grdBilling.CurrentCell.RowIndex
            If grdBilling.CurrentCell.ColumnIndex = grdBilling_Status And e.ColumnIndex = 0 And e.RowIndex >= 0 Then
               
                Dim curvalue As String
                curvalue = grdBilling.CurrentCell.Value
                If Trim(curvalue) = "" Then
                    Dim i As Integer
                    Dim counter As Integer
                    counter = 0
                    For i = 0 To grdBilling.RowCount - 1
                        If Trim(grdBilling.Item(grdBilling_Status, i).Value) = "" Then
                            counter = counter + 1
                        End If
                    Next i

                    'If counter = 1 Then
                    '    MsgBox("At least one color must exist!")
                    '    Exit Sub
                    'Else

                    If rs_CUCNTINF_B.Tables("RESULT").Rows.Count = 1 Then
                        If MsgBox("Are you sure to delete Default Bill", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                            Exit Sub
                        End If
                    ElseIf rs_CUCNTINF_B.Tables("RESULT").Rows.Count > 1 Then
                        If grdBilling.Item(grdBilling_cci_cntdef, iRow).Value = "Y" Then
                            MsgBox("Please change default to other record")
                            Exit Sub
                        End If
                    End If

                    grdBilling.Item(grdBilling_Status, iRow).Value = "Y"

                    If grdBilling.Item(grdBilling_cci_creusr, iRow).Value <> "~*ADD*~" And _
                   grdBilling.Item(grdBilling_cci_creusr, iRow).Value <> "~*DEL*~" And _
                   grdBilling.Item(grdBilling_cci_creusr, iRow).Value <> "~*NEW*~" Then
                        grdBilling.Item(grdBilling_cci_creusr, iRow).Value = "~*DEL*~"
                    ElseIf grdBilling.Item(grdBilling_cci_creusr, iRow).Value = "~*ADD*~" Then
                        grdBilling.Item(grdBilling_cci_creusr, iRow).Value = "~*NEW*~"
                    End If

                Else
                    grdBilling.Item(grdBilling_Status, iRow).Value = ""
                    If grdBilling.Item(grdBilling_cci_creusr, iRow).Value = "~*ADD*~" Then
                        grdBilling.Item(grdBilling_cci_creusr, iRow).Value = "~*UPD*~"
                    ElseIf grdBilling.Item(grdBilling_cci_creusr, iRow).Value = "~*NEW*~" Then
                        grdBilling.Item(grdBilling_cci_creusr, iRow).Value = "~*ADD*~"
                    ElseIf grdBilling.Item(grdBilling_cci_creusr, iRow).Value = "~*DEL*~" Then
                        grdBilling.Item(grdBilling_cci_creusr, iRow).Value = "~*UPD*~"
                    End If
                End If

            ElseIf grdBilling.CurrentCell.ColumnIndex = grdBilling_cci_cntdef And e.ColumnIndex = 5 And e.RowIndex >= 0 Then

                changeDefaultgrdbill()

            End If


            If grdBilling.Item(grdBilling_cci_creusr, iRow).Value <> "~*ADD*~" And _
            grdBilling.Item(grdBilling_cci_creusr, iRow).Value <> "~*UPD*~" And _
            grdBilling.Item(grdBilling_cci_creusr, iRow).Value <> "~*NEW*~" And _
            grdBilling.Item(grdBilling_cci_creusr, iRow).Value <> "~*DEL*~" Then
                grdBilling.Item(grdBilling_cci_creusr, iRow).Value = "~*UPD*~"
                Recordstatus = True

            End If


        End If




    End Sub
    Private Sub changeDefaultgrdbill()



        If grdBilling.Item(5, grdBilling.CurrentCell.RowIndex).Value = "Y" Then
            Exit Sub
        End If

        If grdBilling.Item(grdBilling_Status, grdBilling.CurrentCell.RowIndex).Value = "Y" Then
            Exit Sub
        End If


        Dim default_vn As String
        default_vn = grdBilling.Item(1, grdBilling.CurrentCell.RowIndex).Value

        Dim tmp_vn As String

        Dim i As Integer
        For i = 0 To rs_CUCNTINF_B.Tables("RESULT").Rows.Count - 1
            tmp_vn = rs_CUCNTINF_B.Tables("RESULT").Rows(i).Item("cci_cntadr")

            If default_vn = tmp_vn Then
                If rs_CUCNTINF_B.Tables("RESULT").Rows(i).Item("cci_creusr") <> "~*ADD*~" And _
                rs_CUCNTINF_B.Tables("RESULT").Rows(i).Item("cci_creusr") <> "~*UPD*~" And _
                rs_CUCNTINF_B.Tables("RESULT").Rows(i).Item("cci_creusr") <> "~*NEW*~" And _
                rs_CUCNTINF_B.Tables("RESULT").Rows(i).Item("cci_creusr") <> "~*DEL*~" Then
                    rs_CUCNTINF_B.Tables("RESULT").Rows(i).Item("cci_creusr") = "~*UPD*~"
                End If
                rs_CUCNTINF_B.Tables("RESULT").Rows(i).Item("cci_cntdef") = "Y"
                Recordstatus = True
            ElseIf rs_CUCNTINF_B.Tables("RESULT").Rows(i).Item("cci_cntdef") = "Y" Then
                If rs_CUCNTINF_B.Tables("RESULT").Rows(i).Item("cci_creusr") <> "~*ADD*~" And _
                rs_CUCNTINF_B.Tables("RESULT").Rows(i).Item("cci_creusr") <> "~*UPD*~" And _
                rs_CUCNTINF_B.Tables("RESULT").Rows(i).Item("cci_creusr") <> "~*NEW*~" And _
                rs_CUCNTINF_B.Tables("RESULT").Rows(i).Item("cci_creusr") <> "~*DEL*~" Then
                    rs_CUCNTINF_B.Tables("RESULT").Rows(i).Item("cci_creusr") = "~*UPD*~"
                End If
                rs_CUCNTINF_B.Tables("RESULT").Rows(i).Item("cci_cntdef") = "N"
                Recordstatus = True
            End If

        Next i
    End Sub

    Private Sub grdBilling_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles grdBilling.DataError

    End Sub
    Private Sub grdBilling_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdBilling.EditingControlShowing
        If grdBilling.RowCount = 0 Then
            Exit Sub
        End If

        If cboStatus.Text <> "A - Active" Then
            Exit Sub
        End If


        e.CellStyle.BackColor = Color.White

        Select Case grdBilling.CurrentCell.ColumnIndex
            Case grdBilling_cci_cntcty
                If TypeOf (e.Control) Is DataGridViewComboBoxEditingControl Then
                    Dim cboBox As ComboBox = CType(e.Control, ComboBox)
                    If Not cboBox Is Nothing Then
                        'RemoveHandler cboBox.SelectedIndexChanged, AddressOf cbo_dgCostPrice_SelectedIndexChanged
                        'AddHandler cboBox.SelectedIndexChanged, AddressOf cbo_dgCostPrice_SelectedIndexChanged
                    End If
                End If

        End Select


        'If mode = "UPDATE" Or mode = "ADD" Then
        Recordstatus = True
        If grdBilling.Item(grdBilling_cci_creusr, grdBilling.CurrentCell.RowIndex).Value <> "~*ADD*~" And _
        grdBilling.Item(grdBilling_cci_creusr, grdBilling.CurrentCell.RowIndex).Value <> "~*UPD*~" And _
        grdBilling.Item(grdBilling_cci_creusr, grdBilling.CurrentCell.RowIndex).Value <> "~*DEL*~" And _
        grdBilling.Item(grdBilling_cci_creusr, grdBilling.CurrentCell.RowIndex).Value <> "~*NEW*~" Then ''creusr or upusr?
            grdBilling.Item(grdBilling_cci_creusr, grdBilling.CurrentCell.RowIndex).Value = "~*UPD*~"
        End If
    End Sub

    Private Sub grdBilling_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdBilling.GotFocus
        Got_Focus_Grid = "Billing"
    End Sub

    Private Sub grdShipping_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdShipping.CellClick
        If grdShipping.RowCount = 0 Then
            Exit Sub
        End If

        If cboStatus.Text <> "A - Active" Then
            Exit Sub
        End If


        Select Case grdShipping.CurrentCell.ColumnIndex
            Case grdShipping_cci_cntcty
                comboBoxCell(grdShipping, "Shipcntcty")


        End Select
    End Sub

    

    Private Sub grdShipping_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdShipping.CellDoubleClick
        If cboStatus.Text <> "A - Active" Then
            Exit Sub
        End If
        If e.RowIndex = -1 Then
            Exit Sub
        End If

        If grdShipping.RowCount > 0 Then
            Dim iCol As Integer = grdShipping.CurrentCell.ColumnIndex
            Dim iRow As Integer = grdShipping.CurrentCell.RowIndex
            Dim curvalue As String
            curvalue = grdShipping.CurrentCell.Value.ToString

            If grdShipping.CurrentCell.ColumnIndex = grdShipping_Status And e.ColumnIndex = 0 And e.RowIndex >= 0 Then
                If Trim(curvalue) = "" Then
                    Dim i As Integer
                    Dim counter As Integer
                    counter = 0
                    For i = 0 To grdShipping.RowCount - 1
                        If Trim(grdShipping.Item(grdShipping_Status, i).Value) = "" Then
                            counter = counter + 1
                        End If
                    Next i

                    'If counter = 1 Then
                    '    MsgBox("At least one color must exist!")
                    '    Exit Sub
                    'Else

                    'End If

                    If rs_CUCNTINF_S.Tables("RESULT").Rows.Count = 1 Then
                        If MsgBox("Are you sure to delete Default record?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                            Exit Sub
                        End If
                    ElseIf rs_CUCNTINF_S.Tables("RESULT").Rows.Count > 1 Then
                        If grdShipping.Item(grdShipping_cci_cntdef, iRow).Value = "Y" Then
                            MsgBox("Please change default to other record")
                            Exit Sub
                        End If
                    End If

                    If grdShipping.Item(grdShipping_cci_creusr, iRow).Value <> "~*ADD*~" And _
                    grdShipping.Item(grdShipping_cci_creusr, iRow).Value <> "~*DEL*~" And _
                    grdShipping.Item(grdShipping_cci_creusr, iRow).Value <> "~*NEW*~" Then
                        grdShipping.Item(grdShipping_cci_creusr, iRow).Value = "~*DEL*~"
                    ElseIf grdShipping.Item(grdShipping_cci_creusr, iRow).Value = "~*ADD*~" Then
                        grdShipping.Item(grdShipping_cci_creusr, iRow).Value = "~*NEW*~"
                    End If
                    grdShipping.Item(grdShipping_Status, iRow).Value = "Y"
                Else
                    grdShipping.Item(grdShipping_Status, iRow).Value = ""
                    If grdShipping.Item(grdShipping_cci_creusr, iRow).Value = "~*ADD*~" Then
                        grdShipping.Item(grdShipping_cci_creusr, iRow).Value = "~*UPD*~"
                    ElseIf grdShipping.Item(grdShipping_cci_creusr, iRow).Value = "~*NEW*~" Then
                        grdShipping.Item(grdShipping_cci_creusr, iRow).Value = "~*ADD*~"
                    ElseIf grdShipping.Item(grdShipping_cci_creusr, iRow).Value = "~*DEL*~" Then
                        grdShipping.Item(grdShipping_cci_creusr, iRow).Value = "~*UPD*~"
                    End If
                End If

            ElseIf grdShipping.CurrentCell.ColumnIndex = grdShipping_cci_cntdef And e.ColumnIndex = 5 And e.RowIndex >= 0 Then

                changeDefaultgrdship()

            End If

            If grdShipping.Item(grdShipping_cci_creusr, iRow).Value <> "~*ADD*~" And _
            grdShipping.Item(grdShipping_cci_creusr, iRow).Value <> "~*UPD*~" And _
            grdShipping.Item(grdShipping_cci_creusr, iRow).Value <> "~*DEL*~" And _
            grdShipping.Item(grdShipping_cci_creusr, iRow).Value <> "~*NEW*~" Then
                grdShipping.Item(grdShipping_cci_creusr, iRow).Value = "~*UPD*~"
                Recordstatus = True
            End If

        End If

    End Sub
    Private Sub changeDefaultgrdship()



        If grdShipping.Item(5, grdShipping.CurrentCell.RowIndex).Value = "Y" Then
            Exit Sub
        End If


        If grdShipping.Item(grdShipping_Status, grdShipping.CurrentCell.RowIndex).Value = "Y" Then
            Exit Sub
        End If




        Dim default_vn As String
        default_vn = grdShipping.Item(1, grdShipping.CurrentCell.RowIndex).Value

        Dim tmp_vn As String

        Dim i As Integer
        For i = 0 To rs_CUCNTINF_S.Tables("RESULT").Rows.Count - 1
            tmp_vn = rs_CUCNTINF_S.Tables("RESULT").Rows(i).Item("cci_cntadr")

            If default_vn = tmp_vn Then
                If rs_CUCNTINF_S.Tables("RESULT").Rows(i).Item("cci_creusr") <> "~*ADD*~" And _
                rs_CUCNTINF_S.Tables("RESULT").Rows(i).Item("cci_creusr") <> "~*UPD*~" And _
                rs_CUCNTINF_S.Tables("RESULT").Rows(i).Item("cci_creusr") <> "~*DEL*~" And _
                rs_CUCNTINF_S.Tables("RESULT").Rows(i).Item("cci_creusr") <> "~*NEW*~" Then
                    rs_CUCNTINF_S.Tables("RESULT").Rows(i).Item("cci_creusr") = "~*UPD*~"
                End If
                rs_CUCNTINF_S.Tables("RESULT").Rows(i).Item("cci_cntdef") = "Y"
                Recordstatus = True
            ElseIf rs_CUCNTINF_S.Tables("RESULT").Rows(i).Item("cci_cntdef") = "Y" Then
                If rs_CUCNTINF_S.Tables("RESULT").Rows(i).Item("cci_creusr") <> "~*ADD*~" And _
                rs_CUCNTINF_S.Tables("RESULT").Rows(i).Item("cci_creusr") <> "~*UPD*~" And _
                rs_CUCNTINF_S.Tables("RESULT").Rows(i).Item("cci_creusr") <> "~*DEL*~" And _
                rs_CUCNTINF_S.Tables("RESULT").Rows(i).Item("cci_creusr") <> "~*NEW*~" Then
                    rs_CUCNTINF_S.Tables("RESULT").Rows(i).Item("cci_creusr") = "~*UPD*~"
                End If
                rs_CUCNTINF_S.Tables("RESULT").Rows(i).Item("cci_cntdef") = "N"
                Recordstatus = True
            End If

        Next i
    End Sub
    Private Sub grdShipping_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdShipping.EditingControlShowing
        If grdShipping.RowCount = 0 Then
            Exit Sub
        End If
        If cboStatus.Text <> "A - Active" Then
            Exit Sub
        End If

        e.CellStyle.BackColor = Color.White

        Select Case grdShipping.CurrentCell.ColumnIndex
            Case grdShipping_cci_cntcty
                If TypeOf (e.Control) Is DataGridViewComboBoxEditingControl Then
                    Dim cboBox As ComboBox = CType(e.Control, ComboBox)
                    If Not cboBox Is Nothing Then
                        'RemoveHandler cboBox.SelectedIndexChanged, AddressOf cbo_dgCostPrice_SelectedIndexChanged
                        'AddHandler cboBox.SelectedIndexChanged, AddressOf cbo_dgCostPrice_SelectedIndexChanged
                    End If
                End If

        End Select


        'If mode = "UPDATE" Or mode = "ADD" Then
        Recordstatus = True
        If grdShipping.Item(grdShipping_cci_creusr, grdShipping.CurrentCell.RowIndex).Value <> "~*ADD*~" And _
         grdShipping.Item(grdShipping_cci_creusr, grdShipping.CurrentCell.RowIndex).Value <> "~*UPD*~" And _
         grdShipping.Item(grdShipping_cci_creusr, grdShipping.CurrentCell.RowIndex).Value <> "~*NEW*~" And _
         grdShipping.Item(grdShipping_cci_creusr, grdShipping.CurrentCell.RowIndex).Value <> "~*DEL*~" Then ''creusr or upusr?
            grdShipping.Item(grdShipping_cci_creusr, grdShipping.CurrentCell.RowIndex).Value = "~*UPD*~"
        End If
    End Sub

    Private Sub grdShipping_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdShipping.GotFocus
        Got_Focus_Grid = "Shipping"
    End Sub

    Private Sub grdContact_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdContact.CellClick
        If cboStatus.Text <> "A - Active" Then
            Exit Sub
        End If
        If grdContact.RowCount = 0 Then
            Exit Sub
        End If

        Select Case grdContact.CurrentCell.ColumnIndex
            Case grdContact_cci_cnttyp



                If grdContact.Rows(grdContact.CurrentCell.RowIndex).Cells("cci_creusr").Value.ToString <> "~*ADD*~" Then
                    Exit Sub
                End If
                comboBoxCell(grdContact, "cnttyp")


        End Select
    End Sub

    Private Sub grdContact_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdContact.CellContentClick

    End Sub

    Private Sub grdContact_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdContact.CellDoubleClick
        If cboStatus.Text <> "A - Active" Then
            Exit Sub
        End If

        If e.RowIndex = -1 Then
            Exit Sub
        End If

        If grdContact.RowCount > 0 Then

            Dim iCol As Integer = grdContact.CurrentCell.ColumnIndex
            Dim iRow As Integer = grdContact.CurrentCell.RowIndex

            If grdContact.CurrentCell.ColumnIndex = grdContact_Status Then
                'If grdContact.Rows(grdContact.CurrentCell.RowIndex).Cells("ccv_ventyp").Value.ToString = "" Then
                '    MsgBox("Please select type")
                '    Exit Sub
                'End If

                Dim curvalue As String
                curvalue = grdContact.CurrentCell.Value.ToString
                If Trim(curvalue) = "" Then


                    'If counter = 1 Then
                    '    MsgBox("At least one color must exist!")
                    '    Exit Sub
                    'Else
                    Dim current As String = grdContact.Item(grdContact_cci_cnttyp, iRow).Value
                    rs_CUCNTINF_C.Tables("RESULT").AcceptChanges()

                    Dim dr() As DataRow
                    dr = rs_CUCNTINF_C.Tables("RESULT").Select("cci_cnttyp = '" & current & "'")
                    If dr.Length = 1 Then
                        If MsgBox("Are you sure to delete Default record?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                            Exit Sub
                        End If
                    ElseIf dr.Length > 1 Then
                        If grdContact.Item(8, iRow).Value = "Y" Then
                            MsgBox("Please change default to other record")
                            Exit Sub
                        End If
                    End If
                    grdContact.Item(grdContact_Status, iRow).Value = "Y"

                    If grdContact.Item(grdContact_cci_creusr, iRow).Value <> "~*ADD*~" And _
                    grdContact.Item(grdContact_cci_creusr, iRow).Value <> "~*DEL*~" And _
                    grdContact.Item(grdContact_cci_creusr, iRow).Value <> "~*NEW*~" Then
                        grdContact.Item(grdContact_cci_creusr, iRow).Value = "~*DEL*~"
                    ElseIf grdContact.Item(grdContact_cci_creusr, iRow).Value = "~*ADD*~" Then
                        grdContact.Item(grdContact_cci_creusr, iRow).Value = "~*NEW*~"
                    End If

                    'End If

                Else

                    grdContact.Item(grdContact_Status, iRow).Value = ""
                    If grdContact.Item(grdContact_cci_creusr, iRow).Value = "~*ADD*~" Then
                        grdContact.Item(grdContact_cci_creusr, iRow).Value = "~*UPD*~"
                    ElseIf grdContact.Item(grdContact_cci_creusr, iRow).Value = "~*NEW*~" Then
                        grdContact.Item(grdContact_cci_creusr, iRow).Value = "~*ADD*~"
                    ElseIf grdContact.Item(grdContact_cci_creusr, iRow).Value = "~*DEL*~" Then
                        grdContact.Item(grdContact_cci_creusr, iRow).Value = "~*UPD*~"
                    End If

                End If



            ElseIf grdContact.CurrentCell.ColumnIndex = grdContact_cci_cntdef Then

                changeDefaultgrdContact()


            End If

            If grdContact.Item(grdContact_cci_creusr, iRow).Value <> "~*ADD*~" And _
             grdContact.Item(grdContact_cci_creusr, iRow).Value <> "~*NEW*~" And _
              grdContact.Item(grdContact_cci_creusr, iRow).Value <> "~*DEL*~" Then
                grdContact.Item(grdContact_cci_creusr, iRow).Value = "~*UPD*~"
                Recordstatus = True
            End If
        End If


        'If grdContact.Item(8, grdContact.CurrentCell.RowIndex).Value = "Y" Then
        '    Exit Sub
        'End If

        'Dim default_vn As String
        'default_vn = grdContact.Item(grdContact_cci_cnttyp, grdContact.CurrentCell.RowIndex).Value

        'Dim tmp_vn As String

        'Dim i As Integer

        'For i = 0 To rs_CUCNTINF_C.Tables("RESULT").Rows.Count - 1
        '    tmp_vn = rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("cci_cnttyp")

        '    If default_vn = tmp_vn Then
        '        If rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("cci_creusr") <> "~*ADD*~" Then
        '            rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("cci_creusr") = "~*UPD*~"
        '        End If

        '        rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("cci_cntdef") = "N"
        '        Recordstatus = True


        '    End If

        'Next i


        'grdContact.Item(8, grdContact.CurrentCell.RowIndex).Value = "Y"
        'If grdContact.Item(9, grdContact.CurrentCell.RowIndex).Value <> "~*ADD*~" Then
        '    grdContact.Item(9, grdContact.CurrentCell.RowIndex).Value = "~*UPD*~"
        'End If
    End Sub
    Private Sub changeDefaultgrdContact()



        If grdContact.Item(grdContact_cci_cntdef, grdContact.CurrentCell.RowIndex).Value = "Y" Then
            Exit Sub
        End If

        If grdContact.Item(grdContact_Status, grdContact.CurrentCell.RowIndex).Value = "Y" Then
            Exit Sub
        End If

        Dim default_vn As String
        default_vn = grdContact.Item(grdContact_cci_cnttyp, grdContact.CurrentCell.RowIndex).Value

        Dim tmp_vn As String

        Dim i As Integer
        For i = 0 To rs_CUCNTINF_C.Tables("RESULT").Rows.Count - 1
            tmp_vn = rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("cci_cnttyp")

            If default_vn = tmp_vn Then
                If rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("cci_creusr") <> "~*ADD*~" And _
rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("cci_creusr") <> "~*NEW*~" And _
rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("cci_creusr") <> "~*DEL*~" And _
rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("cci_creusr") <> "~*UPD*~" Then
                    rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("cci_creusr") = "~*UPD*~"
                End If

                rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("cci_cntdef") = "N"
                Recordstatus = True


            End If

        Next i
        grdContact.Item(grdContact_cci_cntdef, grdContact.CurrentCell.RowIndex).Value = "Y"
        If grdContact.Item(grdContact_cci_creusr, grdContact.CurrentCell.RowIndex).Value <> "~*ADD*~" And _
        grdContact.Item(grdContact_cci_creusr, grdContact.CurrentCell.RowIndex).Value <> "~*UPD*~" And _
        grdContact.Item(grdContact_cci_creusr, grdContact.CurrentCell.RowIndex).Value <> "~*DEL*~" And _
        grdContact.Item(grdContact_cci_creusr, grdContact.CurrentCell.RowIndex).Value <> "~*NEW*~" Then
            grdContact.Item(grdContact_cci_creusr, grdContact.CurrentCell.RowIndex).Value = "~*UPD*~"
        End If
    End Sub

    Private Sub grdContact_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdContact.CellEndEdit
        If grdContact.RowCount = 0 Then
            Exit Sub
        End If
        'do
        'Dim cocde As String = Trim(grdCoVen.Item(grdCoVen_ccv_cocde, grdCoVen.CurrentCell.RowIndex).Value.ToString)
        'Dim type As String = Trim(grdCoVen.Item(grdCoVen_ccv_ventyp, grdCoVen.CurrentCell.RowIndex).Value.ToString)
        grdContact.Columns(grdContact_cci_cnttyp).ReadOnly = True
        Dim currentrow As Integer = grdContact.CurrentCell.RowIndex
        Select Case grdContact.CurrentCell.ColumnIndex

            Case grdContact_cci_cnttyp

                Dim current As String
                current = grdContact.Item(grdContact_cci_cnttyp, currentrow).Value
                rs_CUCNTINF_C.Tables("RESULT").AcceptChanges()

                Dim dr1() As DataRow = rs_CUCNTINF_C.Tables("RESULT").Select("cci_cnttyp = '" & current & "'")
                If dr1.Length = 1 Then
                    grdContact.Item(grdContact_cci_cntdef, grdContact.CurrentCell.RowIndex).Value = "Y"
                Else
                    grdContact.Item(grdContact_cci_cntdef, grdContact.CurrentCell.RowIndex).Value = "N"
                End If

                'Dim dr() As DataRow = rs_CUMCOVEN.Tables("RESULT").Select("ccv_vendef = 'Y' and ccv_ventyp = '" & current & "'")
                'If dr.Length > 1 Then
                '    grdCoVen.Item(grdCoVen_ccv_vendef, grdCoVen.CurrentCell.RowIndex).Value = "N"
                'End If

        End Select

    End Sub

    Private Sub grdContact_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdContact.CellValidated
        Dim i As Integer
        For i = 0 To rs_CUCNTINF_C.Tables("RESULT").Columns.Count - 1
            rs_CUCNTINF_C.Tables("RESULT").Columns(i).ReadOnly = False
        Next i



        'If grdRelCus.CurrentCell.ColumnIndex = grdFactoryRel_vsv_ven2name Then
        '    If grdRelCus.Item(grdFactoryRel_vsv_creusr, grdFactoryRel.CurrentCell.RowIndex).Value = "~*ADD*~" Then
        'If grdRelCus.Rows(grdRelCus.CurrentCell.RowIndex).Cells("vsv_ven2name").Value.ToString <> "" Then
        Try
            If e.ColumnIndex = grdContact_cci_cnttyp Then
                Dim txtCell As New DataGridViewTextBoxCell

                grdContact.Rows(grdContact.CurrentCell.RowIndex).Cells("cci_cnttyp").Value = Split(grdContact.Rows(grdContact.CurrentCell.RowIndex).Cells("cci_cnttyp").Value, " - ")(0)


                grdContact.Rows(grdContact.CurrentCell.RowIndex).Cells("cci_cnttyp") = txtCell
            End If
        Catch

        End Try


        'End If
        '    End If
        'End If
    End Sub

    Private Sub grdContact_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles grdContact.DataError

    End Sub


    'Private Sub changeDefaultgrdContact()



    '    If grdContact.Item(7, grdContact.CurrentCell.RowIndex).Value = "Y" Then
    '        Exit Sub
    '    End If

    '    Dim default_vn As String
    '    default_vn = grdContact.Item(2, grdContact.CurrentCell.RowIndex).Value

    '    Dim tmp_vn As String

    '    Dim i As Integer
    '    For i = 0 To rs_CUCNTINF_C.Tables("RESULT").Rows.Count - 1
    '        tmp_vn = rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("vci_cntctp")

    '        If default_vn = tmp_vn Then
    '            If rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("vci_creusr") <> "~*ADD*~" Then
    '                rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("vci_creusr") = "~*UPD*~"
    '            End If
    '            rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("vci_cntdef") = "Y"
    '            Recordstatus = True
    '        ElseIf rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("vci_cntdef") = "Y" Then
    '            If rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("vci_creusr") <> "~*ADD*~" Then
    '                rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("vci_creusr") = "~*UPD*~"
    '            End If
    '            rs_CUCNTINF_C.Tables("RESULT").Rows(i).Item("vci_cntdef") = "N"
    '            Recordstatus = True
    '        End If

    '    Next i
    'End Sub

    Private Sub grdContact_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdContact.EditingControlShowing
        If cboStatus.Text <> "A - Active" Then
            Exit Sub
        End If
        If grdContact.RowCount = 0 Then
            Exit Sub
        End If

        e.CellStyle.BackColor = Color.White

        Select Case grdContact.CurrentCell.ColumnIndex
            Case grdContact_cci_cnttyp
                If TypeOf (e.Control) Is DataGridViewComboBoxEditingControl Then
                    Dim cboBox As ComboBox = CType(e.Control, ComboBox)
                    If Not cboBox Is Nothing Then
                        'RemoveHandler cboBox.SelectedIndexChanged, AddressOf cbo_dgCostPrice_SelectedIndexChanged
                        'AddHandler cboBox.SelectedIndexChanged, AddressOf cbo_dgCostPrice_SelectedIndexChanged
                    End If
                End If
            Case grdContact_cci_cntfax
                CellEdit = CType(e.Control, DataGridViewTextBoxEditingControl)
                CellEdit.SelectAll()

                AddHandler CellEdit.KeyPress, AddressOf grdContactCells_KeyPress
            Case grdContact_cci_cntphn
                CellEdit = CType(e.Control, DataGridViewTextBoxEditingControl)
                CellEdit.SelectAll()

                AddHandler CellEdit.KeyPress, AddressOf grdContactCells_KeyPress
        End Select


        'If mode = "UPDATE" Or mode = "ADD" Then
        Recordstatus = True
        If grdContact.Item(grdContact_cci_creusr, grdContact.CurrentCell.RowIndex).Value <> "~*ADD*~" And _
         grdContact.Item(grdContact_cci_creusr, grdContact.CurrentCell.RowIndex).Value <> "~*DEL*~" And _
         grdContact.Item(grdContact_cci_creusr, grdContact.CurrentCell.RowIndex).Value <> "~*UPD*~" And _
         grdContact.Item(grdContact_cci_creusr, grdContact.CurrentCell.RowIndex).Value <> "~*NEW*~" Then ''creusr or upusr? ''creusr or upusr?
            grdContact.Item(grdContact_cci_creusr, grdContact.CurrentCell.RowIndex).Value = "~*UPD*~"
        End If
    End Sub

    Private Sub grdContact_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdContact.GotFocus
        Got_Focus_Grid = "Contact"
    End Sub

    Private Sub grdItmCatMarkup_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdItmCatMarkup.CellClick
        If cboStatus.Text <> "A - Active" Then
            Exit Sub
        End If
        If grdItmCatMarkup.RowCount = 0 Then
            Exit Sub
        End If

        Select Case grdItmCatMarkup.CurrentCell.ColumnIndex
            Case grdItmCatMarkup_ocm_ventyp
                If grdItmCatMarkup.Rows(grdItmCatMarkup.CurrentCell.RowIndex).Cells("ccm_creusr").Value.ToString <> "~*ADD*~" Then
                    Exit Sub
                End If
                comboBoxCell(grdItmCatMarkup, "Markupventyp")
            Case grdItmCatMarkup_ocm_cat
                If grdItmCatMarkup.Rows(grdItmCatMarkup.CurrentCell.RowIndex).Cells("ccm_creusr").Value.ToString <> "~*ADD*~" Then
                    Exit Sub
                End If
                comboBoxCell(grdItmCatMarkup, "Markupcat")

            Case grdItmCatMarkup_ocm_markupfml
                comboBoxCell(grdItmCatMarkup, "Markup")
        End Select
    End Sub

    Private Sub grdItmCatMarkup_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdItmCatMarkup.CellContentClick

    End Sub

    Private Sub grdItmCatMarkup_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdItmCatMarkup.CellDoubleClick
        If cboStatus.Text <> "A - Active" Then
            Exit Sub
        End If

        If grdItmCatMarkup.RowCount > 0 Then
           

            If grdItmCatMarkup.CurrentCell.ColumnIndex = grdItmCatMarkup_ocm_del And e.ColumnIndex = 0 And e.RowIndex >= 0 Then
                Dim iCol As Integer = grdItmCatMarkup.CurrentCell.ColumnIndex
                Dim iRow As Integer = grdItmCatMarkup.CurrentCell.RowIndex
                Dim curvalue As String
                curvalue = grdItmCatMarkup.CurrentCell.Value
                If Trim(curvalue) = "" Then
                    Dim i As Integer
                    Dim counter As Integer
                    counter = 0
                    For i = 0 To grdItmCatMarkup.RowCount - 1
                        If Trim(grdItmCatMarkup.Item(grdItmCatMarkup_ocm_del, i).Value) = "" Then
                            counter = counter + 1
                        End If
                    Next i

                    'If counter = 1 Then
                    '    MsgBox("At least one color must exist!")
                    '    Exit Sub
                    'Else
                    grdItmCatMarkup.Item(grdItmCatMarkup_ocm_del, iRow).Value = "Y"
                    'End If
                    If grdItmCatMarkup.Item(grdItmCatMarkup_ocm_creusr, iRow).Value <> "~*ADD*~" And _
                     grdItmCatMarkup.Item(grdItmCatMarkup_ocm_creusr, iRow).Value <> "~*DEL*~" And _
                     grdItmCatMarkup.Item(grdItmCatMarkup_ocm_creusr, iRow).Value <> "~*NEW*~" Then
                        grdItmCatMarkup.Item(grdItmCatMarkup_ocm_creusr, iRow).Value = "~*DEL*~"
                    ElseIf grdItmCatMarkup.Item(grdItmCatMarkup_ocm_creusr, iRow).Value = "~*ADD*~" Then
                        grdItmCatMarkup.Item(grdItmCatMarkup_ocm_creusr, iRow).Value = "~*NEW*~"
                    End If


                Else
                    grdItmCatMarkup.Item(grdItmCatMarkup_ocm_del, iRow).Value = ""
                    If grdItmCatMarkup.Item(grdItmCatMarkup_ocm_creusr, iRow).Value = "~*ADD*~" Then
                        grdItmCatMarkup.Item(grdItmCatMarkup_ocm_creusr, iRow).Value = "~*UPD*~"
                    ElseIf grdItmCatMarkup.Item(grdItmCatMarkup_ocm_creusr, iRow).Value = "~*NEW*~" Then
                        grdItmCatMarkup.Item(grdItmCatMarkup_ocm_creusr, iRow).Value = "~*ADD*~"

                    ElseIf grdItmCatMarkup.Item(grdItmCatMarkup_ocm_creusr, iRow).Value = "~*DEL*~" Then
                        grdItmCatMarkup.Item(grdItmCatMarkup_ocm_creusr, iRow).Value = "~*UPD*~"
                    End If
                End If



                If grdItmCatMarkup.Item(grdItmCatMarkup_ocm_creusr, iRow).Value <> "~*ADD*~" And _
grdItmCatMarkup.Item(grdItmCatMarkup_ocm_creusr, iRow).Value <> "~*UPD*~" And _
grdItmCatMarkup.Item(grdItmCatMarkup_ocm_creusr, iRow).Value <> "~*DEL*~" And _
grdItmCatMarkup.Item(grdItmCatMarkup_ocm_creusr, iRow).Value <> "~*NEW*~" Then
                    grdItmCatMarkup.Item(grdItmCatMarkup_ocm_creusr, iRow).Value = "~*UPD*~"
                    Recordstatus = True
                End If

            End If
        End If
    End Sub

    Private Sub grdItmCatMarkup_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdItmCatMarkup.CellEndEdit
        If rs_CUMCAMRK.Tables("RESULT").Rows.Count = 0 Then
            Exit Sub
        End If

        grdItmCatMarkup.Columns(grdItmCatMarkup_ocm_ventyp).ReadOnly = True
        grdItmCatMarkup.Columns(grdItmCatMarkup_ocm_cat).ReadOnly = True

        Dim currentrow As Integer = grdItmCatMarkup.CurrentCell.RowIndex
       
        Dim ventyp As String = Trim(grdItmCatMarkup.Item(grdItmCatMarkup_ocm_ventyp, currentrow).Value.ToString)
        Dim cat As String = Trim(grdItmCatMarkup.Item(grdItmCatMarkup_ocm_cat, currentrow).Value.ToString)
        rs_CUMCAMRK.Tables("RESULT").AcceptChanges()
        If ventyp <> "" And cat <> "" Then
            Dim drr() As DataRow = rs_CUMCAMRK.Tables("RESULT").Select("ccm_ventyp = '" & ventyp & "' and ccm_cat = '" _
                                                                 & cat & "'")
            If drr.Length > 1 Then

                MsgBox("Duplicate Vendor type and Category record")

                grdItmCatMarkup.Item(grdItmCatMarkup_ocm_cat, currentrow).Value = ""


            End If
        End If
    End Sub

    Private Sub grdItmCatMarkup_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdItmCatMarkup.EditingControlShowing
        If cboStatus.Text <> "A - Active" Then
            Exit Sub
        End If
        If grdItmCatMarkup.RowCount = 0 Then
            Exit Sub
        End If
        e.CellStyle.BackColor = Color.White

        Select Case grdItmCatMarkup.CurrentCell.ColumnIndex
            Case grdItmCatMarkup_ocm_ventyp, grdItmCatMarkup_ocm_cat, grdItmCatMarkup_ocm_markupfml
                If TypeOf (e.Control) Is DataGridViewComboBoxEditingControl Then
                    Dim cboBox As ComboBox = CType(e.Control, ComboBox)
                    If Not cboBox Is Nothing Then
                        'RemoveHandler cboBox.SelectedIndexChanged, AddressOf cbo_dgCostPrice_SelectedIndexChanged
                        'AddHandler cboBox.SelectedIndexChanged, AddressOf cbo_dgCostPrice_SelectedIndexChanged
                    End If
                End If

        End Select


        'If mode = "UPDATE" Or mode = "ADD" Then
        Recordstatus = True
        If grdItmCatMarkup.Item(grdItmCatMarkup_ocm_creusr, grdItmCatMarkup.CurrentCell.RowIndex).Value <> "~*ADD*~" And _
       grdItmCatMarkup.Item(grdItmCatMarkup_ocm_creusr, grdItmCatMarkup.CurrentCell.RowIndex).Value <> "~*DEL*~" And _
       grdItmCatMarkup.Item(grdItmCatMarkup_ocm_creusr, grdItmCatMarkup.CurrentCell.RowIndex).Value <> "~*UPD*~" And _
       grdItmCatMarkup.Item(grdItmCatMarkup_ocm_creusr, grdItmCatMarkup.CurrentCell.RowIndex).Value <> "~*NEW*~" Then ''creusr or upusr?
            grdItmCatMarkup.Item(grdItmCatMarkup_ocm_creusr, grdItmCatMarkup.CurrentCell.RowIndex).Value = "~*UPD*~"
        End If
    End Sub

    Private Sub grdItmCatMarkup_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdItmCatMarkup.GotFocus
        Got_Focus_Grid = "ItmCatMarkup"
    End Sub

    Private Sub grdBank_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdBank.CellClick
        If cboStatus.Text <> "A - Active" Then
            Exit Sub
        End If
        If grdBank.RowCount = 0 Then
            Exit Sub
        End If

        Select Case grdBank.CurrentCell.ColumnIndex
            Case grdBank_csi_csetyp


                comboBoxCell(grdBank, "Bankcsetyp")

            Case grdBank_csi_csecty
                comboBoxCell(grdBank, "Billcntcty")

        End Select

    End Sub

    Private Sub grdBank_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdBank.CellContentClick

    End Sub

    Private Sub grdBank_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdBank.CellDoubleClick
        If cboStatus.Text <> "A - Active" Then
            Exit Sub
        End If
        If e.RowIndex = -1 Then
            Exit Sub
        End If

        If grdBank.RowCount > 0 Then
           

            If grdBank.CurrentCell.ColumnIndex = grdBank_Status And e.ColumnIndex = 0 And e.RowIndex >= 0 Then
                Dim iCol As Integer = grdBank.CurrentCell.ColumnIndex
                Dim iRow As Integer = grdBank.CurrentCell.RowIndex
                Dim curvalue As String
                curvalue = grdBank.CurrentCell.Value
                If Trim(curvalue) = "" Then
                    Dim i As Integer
                    Dim counter As Integer
                    counter = 0
                    For i = 0 To grdBank.RowCount - 1
                        If Trim(grdBank.Item(grdBank_Status, i).Value) = "" Then
                            counter = counter + 1
                        End If
                    Next i

                    'If counter = 1 Then
                    '    MsgBox("At least one color must exist!")
                    '    Exit Sub
                    'Else
                    'toogood

                    grdBank.Item(grdBank_Status, iRow).Value = "Y"
                    If grdBank.Item(grdBank_csi_creusr, iRow).Value <> "~*ADD*~" And _
                     grdBank.Item(grdBank_csi_creusr, iRow).Value <> "~*DEL*~" And _
                     grdBank.Item(grdBank_csi_creusr, iRow).Value <> "~*NEW*~" Then
                        grdBank.Item(grdBank_csi_creusr, iRow).Value = "~*DEL*~"
                    ElseIf grdBank.Item(grdBank_csi_creusr, iRow).Value = "~*ADD*~" Then
                        grdBank.Item(grdBank_csi_creusr, iRow).Value = "~*NEW*~"
                    End If

                Else
                    grdBank.Item(grdBank_Status, iRow).Value = ""
                    If grdBank.Item(grdBank_csi_creusr, iRow).Value = "~*ADD*~" Then
                        grdBank.Item(grdBank_csi_creusr, iRow).Value = "~*UPD*~"
                    ElseIf grdBank.Item(grdBank_csi_creusr, iRow).Value = "~*NEW*~" Then
                        grdBank.Item(grdBank_csi_creusr, iRow).Value = "~*ADD*~"

                    ElseIf grdBank.Item(grdBank_csi_creusr, iRow).Value = "~*DEL*~" Then
                        grdBank.Item(grdBank_csi_creusr, iRow).Value = "~*UPD*~"
                    End If
                End If



                If grdBank.Item(grdBank_csi_creusr, iRow).Value <> "~*ADD*~" And _
                grdBank.Item(grdBank_csi_creusr, iRow).Value <> "~*UPD*~" And _
                    grdBank.Item(grdBank_csi_creusr, iRow).Value <> "~*DEL*~" And _
                    grdBank.Item(grdBank_csi_creusr, iRow).Value <> "~*NEW*~" Then
                    grdBank.Item(grdBank_csi_creusr, iRow).Value = "~*UPD*~"
                    Recordstatus = True
                End If

            End If
        End If
    End Sub

    Private Sub grdBank_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdBank.EditingControlShowing
        If cboStatus.Text <> "A - Active" Then
            Exit Sub
        End If
        If grdBank.RowCount = 0 Then
            Exit Sub
        End If
        e.CellStyle.BackColor = Color.White

        Select Case grdBank.CurrentCell.ColumnIndex
            Case grdBank_csi_csetyp, grdBank_csi_csecty
                If TypeOf (e.Control) Is DataGridViewComboBoxEditingControl Then
                    Dim cboBox As ComboBox = CType(e.Control, ComboBox)
                    If Not cboBox Is Nothing Then
                        'RemoveHandler cboBox.SelectedIndexChanged, AddressOf cbo_dgCostPrice_SelectedIndexChanged
                        'AddHandler cboBox.SelectedIndexChanged, AddressOf cbo_dgCostPrice_SelectedIndexChanged
                    End If
                End If
            Case grdBank_csi_csefax
                CellEdit = CType(e.Control, DataGridViewTextBoxEditingControl)
                CellEdit.SelectAll()

                AddHandler CellEdit.KeyPress, AddressOf grdBankCells_KeyPress
            Case grdBank_csi_csephn
                CellEdit = CType(e.Control, DataGridViewTextBoxEditingControl)
                CellEdit.SelectAll()

                AddHandler CellEdit.KeyPress, AddressOf grdBankCells_KeyPress
        End Select


        'If mode = "UPDATE" Or mode = "ADD" Then
        Recordstatus = True
        If grdBank.Item(grdBank_csi_creusr, grdBank.CurrentCell.RowIndex).Value <> "~*ADD*~" And _
       grdBank.Item(grdBank_csi_creusr, grdBank.CurrentCell.RowIndex).Value <> "~*DEL*~" And _
       grdBank.Item(grdBank_csi_creusr, grdBank.CurrentCell.RowIndex).Value <> "~*UPD*~" And _
       grdBank.Item(grdBank_csi_creusr, grdBank.CurrentCell.RowIndex).Value <> "~*NEW*~" Then ''creusr or upusr?
            grdBank.Item(grdBank_csi_creusr, grdBank.CurrentCell.RowIndex).Value = "~*UPD*~"
        End If
    End Sub

    Private Sub grdBank_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdBank.GotFocus
        Got_Focus_Grid = "Bank"
    End Sub

    Private Sub grdCourier_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCourier.CellClick
        If cboStatus.Text <> "A - Active" Then
            Exit Sub
        End If
        If grdCourier.RowCount = 0 Then
            Exit Sub
        End If

        Select Case grdCourier.CurrentCell.ColumnIndex
            Case grdCourier_csi_csetyp


                comboBoxCell(grdCourier, "Couriercsetyp")

            Case grdCourier_csi_csecty
                comboBoxCell(grdCourier, "Billcntcty")

        End Select

    End Sub

    Private Sub grdCourier_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCourier.CellContentClick

    End Sub

    Private Sub grdCourier_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCourier.CellDoubleClick
        If cboStatus.Text <> "A - Active" Then
            Exit Sub
        End If
        If e.RowIndex = -1 Then
            Exit Sub
        End If

        If grdCourier.RowCount > 0 Then
            

            If grdCourier.CurrentCell.ColumnIndex = grdCourier_Status And e.ColumnIndex = 0 And e.RowIndex >= 0 Then
                Dim iCol As Integer = grdCourier.CurrentCell.ColumnIndex
                Dim iRow As Integer = grdCourier.CurrentCell.RowIndex
                Dim curvalue As String
                curvalue = grdCourier.CurrentCell.Value
                If Trim(curvalue) = "" Then
                    Dim i As Integer
                    Dim counter As Integer
                    counter = 0
                    For i = 0 To grdCourier.RowCount - 1
                        If Trim(grdCourier.Item(grdCourier_Status, i).Value) = "" Then
                            counter = counter + 1
                        End If
                    Next i

                    'If counter = 1 Then
                    '    MsgBox("At least one color must exist!")
                    '    Exit Sub
                    'Else
                    grdCourier.Item(grdCourier_Status, iRow).Value = "Y"
                    If grdCourier.Item(grdCourier_csi_creusr, iRow).Value <> "~*ADD*~" And _
                   grdCourier.Item(grdCourier_csi_creusr, iRow).Value <> "~*DEL*~" And _
                   grdCourier.Item(grdCourier_csi_creusr, iRow).Value <> "~*NEW*~" Then
                        grdCourier.Item(grdCourier_csi_creusr, iRow).Value = "~*DEL*~"
                    ElseIf grdCourier.Item(grdCourier_csi_creusr, iRow).Value = "~*ADD*~" Then
                        grdCourier.Item(grdCourier_csi_creusr, iRow).Value = "~*NEW*~"
                    End If

                Else
                    grdCourier.Item(grdCourier_Status, iRow).Value = ""
                    If grdCourier.Item(grdCourier_csi_creusr, iRow).Value = "~*ADD*~" Then
                        grdCourier.Item(grdCourier_csi_creusr, iRow).Value = "~*UPD*~"
                    ElseIf grdCourier.Item(grdCourier_csi_creusr, iRow).Value = "~*NEW*~" Then
                        grdCourier.Item(grdCourier_csi_creusr, iRow).Value = "~*ADD*~"
                    ElseIf grdCourier.Item(grdCourier_csi_creusr, iRow).Value = "~*DEL*~" Then
                        grdCourier.Item(grdCourier_csi_creusr, iRow).Value = "~*UPD*~"

                    End If
                End If



                If grdCourier.Item(grdCourier_csi_creusr, iRow).Value <> "~*ADD*~" And _
                    grdCourier.Item(grdCourier_csi_creusr, iRow).Value <> "~*UPD*~" And _
                        grdCourier.Item(grdCourier_csi_creusr, iRow).Value <> "~*DEL*~" And _
                        grdCourier.Item(grdCourier_csi_creusr, iRow).Value <> "~*NEW*~" Then
                    grdCourier.Item(grdCourier_csi_creusr, iRow).Value = "~*UPD*~"
                    Recordstatus = True
                End If

            End If
        End If
    End Sub

    Private Sub grdCourier_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdCourier.EditingControlShowing
        If cboStatus.Text <> "A - Active" Then
            Exit Sub
        End If
        If grdCourier.RowCount = 0 Then
            Exit Sub
        End If
        e.CellStyle.BackColor = Color.White

        Select Case grdCourier.CurrentCell.ColumnIndex
            Case grdCourier_csi_csetyp, grdCourier_csi_csecty
                If TypeOf (e.Control) Is DataGridViewComboBoxEditingControl Then
                    Dim cboBox As ComboBox = CType(e.Control, ComboBox)
                    If Not cboBox Is Nothing Then
                        'RemoveHandler cboBox.SelectedIndexChanged, AddressOf cbo_dgCostPrice_SelectedIndexChanged
                        'AddHandler cboBox.SelectedIndexChanged, AddressOf cbo_dgCostPrice_SelectedIndexChanged
                    End If
                End If
            Case grdCourier_csi_csefax
                CellEdit = CType(e.Control, DataGridViewTextBoxEditingControl)
                CellEdit.SelectAll()

                AddHandler CellEdit.KeyPress, AddressOf grdCourierCells_KeyPress
            Case grdCourier_csi_csephn
                CellEdit = CType(e.Control, DataGridViewTextBoxEditingControl)
                CellEdit.SelectAll()

                AddHandler CellEdit.KeyPress, AddressOf grdCourierCells_KeyPress
        End Select


        'If mode = "UPDATE" Or mode = "ADD" Then
        Recordstatus = True
        If grdCourier.Item(grdCourier_csi_creusr, grdCourier.CurrentCell.RowIndex).Value <> "~*ADD*~" And _
        grdCourier.Item(grdCourier_csi_creusr, grdCourier.CurrentCell.RowIndex).Value <> "~*DEL*~" And _
        grdCourier.Item(grdCourier_csi_creusr, grdCourier.CurrentCell.RowIndex).Value <> "~*UPD*~" And _
        grdCourier.Item(grdCourier_csi_creusr, grdCourier.CurrentCell.RowIndex).Value <> "~*NEW*~" Then ''creusr or upusr?
            grdCourier.Item(grdCourier_csi_creusr, grdCourier.CurrentCell.RowIndex).Value = "~*UPD*~"
        End If
    End Sub

    Private Sub grdCourier_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdCourier.GotFocus
        Got_Focus_Grid = "Courier"
    End Sub

    Private Sub grdRelCus_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles grdRelCus.CellBeginEdit
       
    End Sub

    Private Sub grdRelCus_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdRelCus.CellClick
        If cboStatus.Text <> "A - Active" Then
            Exit Sub
        End If
        If grdRelCus.RowCount = 0 Then
            Exit Sub
        End If




        Select Case grdRelCus.CurrentCell.ColumnIndex
            Case grdRelCus_csc_seccus

                If grdRelCus.Rows(grdRelCus.CurrentCell.RowIndex).Cells("csc_creusr").Value.ToString <> "~*ADD*~" Then

                    Exit Sub
                End If


 


                If optPriCus.Checked = True Then
                    gspStr = "sp_list_CUBASINF '','" & "P" & "'"
                Else
                    gspStr = "sp_list_CUBASINF '','" & "S" & "'"
                End If
                rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_L, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading grdRelCus_CellClick sp_list_CUBASINF :" & rtnStr)
                    Exit Sub
                End If

                fill_lstCustomer()
                display_lstCustomer(rs_CUBASINF_L.Tables("RESULT").Rows.Count)
                lstrowindex = grdRelCus.CurrentCell.RowIndex
            Case grdRelCus_cbi_cusnam

                If grdRelCus.Rows(grdRelCus.CurrentCell.RowIndex).Cells("csc_creusr").Value.ToString <> "~*ADD*~" Then

                    Exit Sub
                End If

               
                If optPriCus.Checked = True Then
                    gspStr = "sp_list_CUBASINF '','" & "P" & "'"
                Else
                    gspStr = "sp_list_CUBASINF '','" & "S" & "'"
                End If
                rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF_L, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading grdRelCus_CellClick sp_list_CUBASINF :" & rtnStr)
                    Exit Sub
                End If
                fill_lstCustomer()
                display_lstCustomer(rs_CUBASINF_L.Tables("RESULT").Rows.Count)
             
                lstrowindex = grdRelCus.CurrentCell.RowIndex

            Case grdRelCus_csc_cusrel
                lstCustomer.Visible = False
            Case grdRelCus_Status
                lstCustomer.Visible = False
        End Select

    End Sub

    Private Sub fill_lstCustomer()
        lstCustomer.Items.Clear()

        Dim i As Integer
        For i = 0 To rs_CUBASINF_L.Tables("RESULT").Rows.Count - 1
            If rs_CUBASINF_L.Tables("RESULT").Rows(i).Item("cbi_cusno") > "50000" Then
                lstCustomer.Items.Add(rs_CUBASINF_L.Tables("RESULT").Rows(i).Item("cbi_cusno") + " - " + Trim(rs_CUBASINF_L.Tables("RESULT").Rows(i).Item("cbi_cusnam")))
            End If
        Next i


    
    End Sub
    Private Sub display_lstCustomer(ByVal rowcount As Integer)
        Dim currcellrectangle As Rectangle = _
        grdRelCus.GetCellDisplayRectangle(grdRelCus.CurrentCell.ColumnIndex, _
                                            grdRelCus.CurrentCell.RowIndex, _
                                            True)



        lstCustomer.Visible = True
        lstCustomer.Top = currcellrectangle.Top + grdRelCus.Item(0, 0).DataGridView.Top + grdRelCus.Item(0, 0).DataGridView.ColumnHeadersHeight
        lstCustomer.Left = grdRelCus.Item(0, 0).DataGridView.Left + grdRelCus.Item(0, 0).DataGridView.RowHeadersWidth + grdRelCus.Columns(0).Width
        lstCustomer.Width = 120 + 360 'grdview column (2) (3)
        lstCustomer.Focus()



        'lstCustomer.Top = grdRelCus.Item(0, 0).DataGridView.Top + grdRelCus.Item(0, 0).DataGridView.ColumnHeadersHeight + grdRelCus.RowTemplate.Height * (grdRelCus.CurrentCell.RowIndex + 1)
        'lstCustomer.Left = grdRelCus.Item(0, 0).DataGridView.Left + grdRelCus.Item(0, 0).DataGridView.RowHeadersWidth

    End Sub

   

    Private Sub grdRelCus_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdRelCus.CellDoubleClick
        If cboStatus.Text <> "A - Active" Then
            Exit Sub
        End If
        If e.RowIndex = -1 Then
            Exit Sub
        End If
        If grdRelCus.RowCount > 0 Then
            Dim iCol As Integer = grdRelCus.CurrentCell.ColumnIndex
            Dim iRow As Integer = grdRelCus.CurrentCell.RowIndex

            If grdRelCus.CurrentCell.ColumnIndex = grdRelCus_Status And e.ColumnIndex = 0 And e.RowIndex >= 0 Then
               
                Dim curvalue As String
                curvalue = grdRelCus.CurrentCell.Value
                If Trim(curvalue) = "" Then
                    Dim i As Integer
                    Dim counter As Integer
                    counter = 0
                    For i = 0 To grdRelCus.RowCount - 1
                        If Trim(grdRelCus.Item(grdRelCus_Status, i).Value) = "" Then
                            counter = counter + 1
                        End If
                    Next i

                    'If counter = 1 Then
                    '    MsgBox("At least one color must exist!")
                    '    Exit Sub
                    'Else
                    grdRelCus.Item(grdRelCus_Status, iRow).Value = "Y"
                    If grdRelCus.Item(grdRelCus_csc_creusr, iRow).Value <> "~*ADD*~" And _
                    grdRelCus.Item(grdRelCus_csc_creusr, iRow).Value <> "~*DEL*~" And _
                    grdRelCus.Item(grdRelCus_csc_creusr, iRow).Value <> "~*NEW*~" Then
                        grdRelCus.Item(grdRelCus_csc_creusr, iRow).Value = "~*DEL*~"
                    ElseIf grdRelCus.Item(grdRelCus_csc_creusr, iRow).Value = "~*ADD*~" Then
                        grdRelCus.Item(grdRelCus_csc_creusr, iRow).Value = "~*NEW*~"
                    End If

                Else
                    grdRelCus.Item(grdRelCus_Status, iRow).Value = ""
                    If grdRelCus.Item(grdRelCus_csc_creusr, iRow).Value = "~*ADD*~" Then
                        grdRelCus.Item(grdRelCus_csc_creusr, iRow).Value = "~*UPD*~"
                    ElseIf grdRelCus.Item(grdRelCus_csc_creusr, iRow).Value = "~*NEW*~" Then
                        grdRelCus.Item(grdRelCus_csc_creusr, iRow).Value = "~*ADD*~"
                    ElseIf grdRelCus.Item(grdRelCus_csc_creusr, iRow).Value = "~*DEL*~" Then
                        grdRelCus.Item(grdRelCus_csc_creusr, iRow).Value = "~*UPD*~"
                    End If
                End If

            ElseIf grdRelCus.CurrentCell.ColumnIndex = grdRelCus_csc_cusrel And e.ColumnIndex = 4 And e.RowIndex >= 0 Then
                Dim curvalue As String
                curvalue = grdRelCus.CurrentCell.Value
                If Trim(curvalue) = "Passive" Then
                    grdRelCus.Item(grdRelCus_csc_cusrel, iRow).Value = "Active"
                ElseIf Trim(curvalue) = "Active" Then
                    grdRelCus.Item(grdRelCus_csc_cusrel, iRow).Value = "Passive"
                End If
            End If
            If grdRelCus.Item(grdRelCus_csc_creusr, iRow).Value <> "~*ADD*~" And _
                grdRelCus.Item(grdRelCus_csc_creusr, iRow).Value <> "~*UPD*~" And _
                grdRelCus.Item(grdRelCus_csc_creusr, iRow).Value <> "~*DEL*~" And _
                grdRelCus.Item(grdRelCus_csc_creusr, iRow).Value <> "~*NEW*~" Then
                grdRelCus.Item(grdRelCus_csc_creusr, iRow).Value = "~*UPD*~"
                Recordstatus = True
            End If

        End If

    End Sub

   

   

   


    Private Sub grdRelCus_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles grdRelCus.DataError

    End Sub

    Private Sub grdRelCus_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdRelCus.EditingControlShowing
        If cboStatus.Text <> "A - Active" Then
            Exit Sub
        End If
        If grdRelCus.RowCount = 0 Then
            Exit Sub
        End If
        e.CellStyle.BackColor = Color.White

        Select Case grdRelCus.CurrentCell.ColumnIndex
            Case grdRelCus_csc_seccus, grdRelCus_cbi_cusnam
                If TypeOf (e.Control) Is DataGridViewComboBoxEditingControl Then
                    Dim cboBox As ComboBox = CType(e.Control, ComboBox)
                    If Not cboBox Is Nothing Then
                        'RemoveHandler cboBox.SelectedIndexChanged, AddressOf cbo_dgCostPrice_SelectedIndexChanged
                        'AddHandler cboBox.SelectedIndexChanged, AddressOf cbo_dgCostPrice_SelectedIndexChanged
                    End If
                End If

        End Select


        'If mode = "UPDATE" Or mode = "ADD" Then
        Recordstatus = True
        If grdRelCus.Item(grdRelCus_csc_creusr, grdRelCus.CurrentCell.RowIndex).Value <> "~*ADD*~" And _
        grdRelCus.Item(grdRelCus_csc_creusr, grdRelCus.CurrentCell.RowIndex).Value <> "~*DEL*~" And _
        grdRelCus.Item(grdRelCus_csc_creusr, grdRelCus.CurrentCell.RowIndex).Value <> "~*UPD*~" And _
        grdRelCus.Item(grdRelCus_csc_creusr, grdRelCus.CurrentCell.RowIndex).Value <> "~*NEW*~" Then ''creusr or upusr?
            grdRelCus.Item(grdRelCus_csc_creusr, grdRelCus.CurrentCell.RowIndex).Value = "~*UPD*~"
        End If
    End Sub

    Private Sub grdRelCus_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdRelCus.GotFocus
        Got_Focus_Grid = "RelCus"
    End Sub

    Private Sub txtSAPSHCUSNOM_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSAPSHCUSNOM.TextChanged

    End Sub

    Private Sub optPriCus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPriCus.CheckedChanged

    End Sub

    Private Sub optPriCus_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optPriCus.Click
        If Add_flag = True And optSecCus.Checked = False Then
            If MsgBox("Customer Type cannot be changed once selected. Are you sure?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Recordstatus = True

                'cboPrcFml.Enabled = True

                ' Label40.Visible = False
                optPriCus.Checked = True
                optSecCus.Enabled = False
                optMarkup.Enabled = False
                txtgrsMgn.Text = ""
                txtgrsMgn.Enabled = False
                optGrsMgn.Enabled = False

                gspStr = "sp_select_CUSUBCUS '','A','P'"
                rtnLong = execute_SQLStatement(gspStr, rs_CUSUBCUS_P, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading optPriCus_Click sp_select_CUSUBCUS :" & rtnStr)
                    Me.Cursor = Cursors.Default

                    Exit Sub
                Else
                    Call SetgrdRelCus()
                End If


                Call add_CusBufSetup()
                rs_CUSHPFML.Tables("RESULT").Rows(0).Item("csf_venno") = "INT - Internal Vendor"

                Call add_CusBufSetup()
                rs_CUSHPFML.Tables("RESULT").Rows(1).Item("csf_venno") = "EXT - External Vendor"

                Call SetgrdCusBufSetup()
            Else
                optPriCus.Checked = False


            End If
        End If
    End Sub
    Private Function func_ShpMrkIsValid() As Boolean

        func_ShpMrkIsValid = False

        If (Trim(txtShpMrk1.Text) <> "" Or Trim(txtShpMrk2.Text) <> "" Or _
            Trim(txtShpMrk3.Text) <> "") Or Trim(txtShpMrk4.Text) <> "" Or Trim(txtShpMrk7.Text) <> "" Then
            func_ShpMrkIsValid = True
        Else
            'If Trim(txtShpMrk(7).Text) = "" Then
            'Msg "M00017"
            'SSTabCus.Tab = 5
            'txtShpMrk(7).SetFocus
            'If Trim(txtShpMrk(1).Text) = "" Then
            'Msg "M00017"
            'SSTabCus.Tab = 5
            'txtShpMrk(1).SetFocus
            'ElseIf txtShpMrk(2).Text = "" Then
            'Msg "M00017"
            'SSTabCus.Tab = 5
            'txtShpMrk(2).SetFocus
            'Else
            MsgBox("Please input information for this Ship Mark")
            func_ShpMrkIsValid = False
            'End If
        End If
    End Function



    Private Sub cmdShpMrkBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShpMrkBack.Click
        If Not rs_CUSHPMRK.Tables("RESULT").Rows.Count = 0 Then
            If Not func_ShpMrkIsValid() = False Then
                'Call func_shp
            Else : Exit Sub
            End If

            If currentShipmark = 0 Then
                MsgBox("This is the First Record")
            Else
                save_currentshipmrk()
                currentShipmark = currentShipmark - 1
                Call func_ReadShipMarkRec()
                If rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("status") = "Y" Then
                    chkDelete.Checked = True
                Else
                    chkDelete.Checked = False
                End If
            End If

        End If
    End Sub
    Private Sub save_currentshipmrk()
        If cboStatus.Text <> "A - Active" Then
            Exit Sub
        End If
        If rs_CUSHPMRK.Tables("RESULT").Rows.Count = 0 Then
            Exit Sub
        End If

        Dim shiptype As String
        Dim status As String
        If chkDelete.Checked = True Then
            status = "Y"
        Else
            status = "N"
        End If


        If optMain.Checked = True Then
            shiptype = "M"
        ElseIf optSide.Checked = True Then
            shiptype = "S"
        ElseIf optInner.Checked = True Then
            shiptype = "I"
        End If
         


        '  rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") = "~*ADD*~"
        rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("status") = status
        '  rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_cusno") = ""
        ' rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_seqno") = 0
        ' rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_custyp") = ""
        rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_shptyp") = shiptype
        rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_engdsc") = txtShpMrk1.Text
        rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_chndsc") = txtShpMrk2.Text
        rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_engrmk") = txtShpMrk3.Text
        rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_chnrmk") = txtShpMrk4.Text
        rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_imgpth") = txtShpMrk6.Text
        rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_imgnam") = txtShpMrk7.Text
        rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_cerdoc") = txtCerDoc.Text

        If rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") <> "~*ADD*~" And _
        rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") <> "~*UPD*~" And _
        rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") <> "~*NEW*~" And _
        rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") <> "~*DEL*~" Then
            rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") = "~*UPD*~"
        End If

 
    End Sub




    Private Sub cmdShpMrkNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShpMrkNext.Click
        If Not rs_CUSHPMRK.Tables("RESULT").Rows.Count = 0 Then
            If Not func_ShpMrkIsValid() = False Then
                'Call func_shp
            Else : Exit Sub
            End If

            If currentShipmark = rs_CUSHPMRK.Tables("RESULT").Rows.Count - 1 Then
                MsgBox("This is the Last Record")
            Else
                save_currentshipmrk()
                currentShipmark = currentShipmark + 1
                Call func_ReadShipMarkRec()
                If rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("status") = "Y" Then
                    chkDelete.Checked = True
                Else
                    chkDelete.Checked = False
                End If
            End If

        End If
    End Sub

    Private Sub optMain_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optMain.CheckedChanged

    End Sub

    Private Sub optMain_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optMain.Click
        If rs_CUSHPMRK.Tables("RESULT").Rows.Count = 0 Then
            Exit Sub
        End If

       
        rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_shptyp") = "M"

        If rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") <> "~*ADD*~" And _
        rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") <> "~*UPD*~" And _
        rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") <> "~*NEW*~" And _
        rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") <> "~*DEL*~" Then
            rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") = "~*UPD*~"
        End If
       

    End Sub

    Private Sub optSide_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optSide.CheckedChanged

    End Sub

    Private Sub optSide_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optSide.Click
        If rs_CUSHPMRK.Tables("RESULT").Rows.Count = 0 Then
            Exit Sub
        End If

      
        rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_shptyp") = "S"

        If rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") <> "~*ADD*~" And _
       rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") <> "~*UPD*~" And _
       rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") <> "~*DEL*~" And _
       rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") <> "~*NEW*~" Then
            rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub optInner_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optInner.CheckedChanged

    End Sub

    Private Sub optInner_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optInner.Click
        If rs_CUSHPMRK.Tables("RESULT").Rows.Count = 0 Then
            Exit Sub
        End If

       
        rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_shptyp") = "I"
        If rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") <> "~*ADD*~" And _
        rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") <> "~*UPD*~" And _
        rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") <> "~*NEW*~" And _
        rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") <> "~*DEL*~" Then
            rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") = "~*UPD*~"
        End If

    End Sub

    Private Sub txtShpMrk7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtShpMrk7.KeyPress
      
      
    End Sub

    Private Sub txtShpMrk7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShpMrk7.TextChanged
        '        If rs_CUSHPMRK.Tables("RESULT").Rows.Count = 0 Then
        '            Exit Sub
        '        End If
        '        Dim shiptype As String
        '        If optMain.Checked = True Then
        '            shiptype = "M"
        '        ElseIf optSide.Checked = True Then
        '            shiptype = "S"
        '        ElseIf optInner.Checked = True Then
        '            shiptype = "I"
        '        End If



        '        '  rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") = "~*ADD*~"
        '        '    rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("status") = status

        '        rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_imgnam") = txtShpMrk7.Text

        '        If rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") <> "~*ADD*~" And _
        'rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") <> "~*UPD*~" And _
        'rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") <> "~*NEW*~" And _
        'rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") <> "~*DEL*~" Then
        '            rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") = "~*UPD*~"
        '        End If

    End Sub

    Private Sub txtShpMrk1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtShpMrk1.GotFocus
        txtShpMrk1.Height = 90
        txtShpMrk1.BringToFront()
        ' txtShpMrk1.Top = txtShpMrk1.Top + 52

    End Sub

    Private Sub txtShpMrk1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtShpMrk1.KeyPress
       
    End Sub
    Public Function MultiLineTextIsValid(ByVal S As String, ByVal maxChar As Integer) As Boolean

        MultiLineTextIsValid = True

        Dim v   '*** Variant
        Dim temp   '*** temp variable

        v = Split(S, Chr(13) + Chr(10))   '*** split string by "vbNewLine"

        For Each temp In v
            If Len(temp) > maxChar Then   '*** if length of each string > maxChar
                MultiLineTextIsValid = False   '***return false
            End If
        Next

    End Function
    Private Sub txtShpMrk1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtShpMrk1.LostFocus

        If MultiLineTextIsValid(txtShpMrk1.Text, 40) = False Then
            If Me.BaseTabControl1.SelectedIndex = 0 Then

            End If
            MsgBox("Each line qty cannot over 40")
            txtShpMrk4.Top = 292
            txtShpMrk4.Left = 146
            txtShpMrk4.Width = 369
            txtShpMrk4.Height = 74
            If txtShpMrk1.Enabled = True Then
                txtShpMrk1.Focus()
            End If
        Else
            save_currentshipmrk()
        End If

        txtShpMrk1.Height = 74
        ' txtShpMrk1.Top = txtShpMrk1.Top - 52
    End Sub

   

    Private Sub txtShpMrk1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShpMrk1.TextChanged
        'If rs_CUSHPMRK.Tables("RESULT").Rows.Count = 0 Then
        '    Exit Sub
        'End If
        'Dim shiptype As String
        'If optMain.Checked = True Then
        '    shiptype = "M"
        'ElseIf optSide.Checked = True Then
        '    shiptype = "S"
        'ElseIf optInner.Checked = True Then
        '    shiptype = "I"
        'End If



        ''  rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") = "~*ADD*~"
        ''   rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("status") = status

        'rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_engdsc") = txtShpMrk1.Text

        'If rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") <> "~*ADD*~" And _
        'rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") <> "~*UPD*~" And _
        'rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") <> "~*NEW*~" And _
        'rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") <> "~*DEL*~" Then
        '    rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") = "~*UPD*~"
        'End If
       

    End Sub

    Private Sub txtShpMrk2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtShpMrk2.GotFocus
        txtShpMrk2.Height = 90
        txtShpMrk2.BringToFront()
        ' txtShpMrk2.Top = txtShpMrk2.Top - 52
    End Sub

    Private Sub txtShpMrk2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtShpMrk2.KeyPress
        
    End Sub

    Private Sub txtShpMrk2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtShpMrk2.LostFocus
        If MultiLineTextIsValid(txtShpMrk2.Text, 40) = False Then
            If Me.BaseTabControl1.SelectedIndex <> 6 Then
                Me.BaseTabControl1.SelectedIndex = 6
            End If
            MsgBox("Each line qty cannot over 40")
            If txtShpMrk2.Enabled = True Then
                txtShpMrk2.Focus()
            End If
        Else
            save_currentshipmrk()
        End If
        txtShpMrk2.Height = 74
        'txtShpMrk2.Top = txtShpMrk2.Top + 52
    End Sub

    Private Sub txtShpMrk2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShpMrk2.TextChanged
        'If rs_CUSHPMRK.Tables("RESULT").Rows.Count = 0 Then
        '    Exit Sub
        'End If
        'Dim shiptype As String
        'If optMain.Checked = True Then
        '    shiptype = "M"
        'ElseIf optSide.Checked = True Then
        '    shiptype = "S"
        'ElseIf optInner.Checked = True Then
        '    shiptype = "I"
        'End If



        ''  rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") = "~*ADD*~"
        ''rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("status") = status
        'rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_chndsc") = txtShpMrk2.Text
        'If rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") <> "~*ADD*~" And _
        'rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") <> "~*UPD*~" And _
        'rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") <> "~*NEW*~" And _
        'rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") <> "~*DEL*~" Then
        '    rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") = "~*UPD*~"
        'End If
         

    End Sub

    Private Sub txtShpMrk3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtShpMrk3.GotFocus
        txtShpMrk3.Height = 90
        txtShpMrk3.BringToFront()
        ' txtShpMrk3.Top = txtShpMrk3.Top - 52
    End Sub

    Private Sub txtShpMrk3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtShpMrk3.KeyPress
      

    End Sub

    Private Sub txtShpMrk3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtShpMrk3.LostFocus
        txtShpMrk3.Height = 74
        'txtShpMrk3.Top = txtShpMrk3.Top + 52
    End Sub

    Private Sub txtShpMrk3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShpMrk3.TextChanged
        'If rs_CUSHPMRK.Tables("RESULT").Rows.Count = 0 Then
        '    Exit Sub
        'End If
        'Dim shiptype As String
        'If optMain.Checked = True Then
        '    shiptype = "M"
        'ElseIf optSide.Checked = True Then
        '    shiptype = "S"
        'ElseIf optInner.Checked = True Then
        '    shiptype = "I"
        'End If



        ''  rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") = "~*ADD*~"
        ''  rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("status") = status

        'rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_engrmk") = txtShpMrk3.Text
        'If rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") <> "~*UPD*~" And _
        'rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") <> "~*NEW*~" And _
        'rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") <> "~*DEL*~" And _
        'rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") <> "~*UPD*~" Then
        '    rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") = "~*UPD*~"
        'End If
         

    End Sub

    Private Sub txtShpMrk4_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtShpMrk4.GotFocus
        txtShpMrk4.Height = 90
        'txtShpMrk4.Top = txtShpMrk4.Top - 42
        txtShpMrk4.BringToFront()
    End Sub

    Private Sub txtShpMrk4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtShpMrk4.KeyPress
        

    End Sub

    Private Sub txtShpMrk4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtShpMrk4.LostFocus
        txtShpMrk4.Height = 74
        txtShpMrk4.Top = 292 'txtShpMrk4.Top + 42
    End Sub

    Private Sub txtShpMrk4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShpMrk4.TextChanged
        'If rs_CUSHPMRK.Tables("RESULT").Rows.Count = 0 Then
        '    Exit Sub
        'End If
        'Dim shiptype As String
        'If optMain.Checked = True Then
        '    shiptype = "M"
        'ElseIf optSide.Checked = True Then
        '    shiptype = "S"
        'ElseIf optInner.Checked = True Then
        '    shiptype = "I"
        'End If



        ''  rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") = "~*ADD*~"
        '' rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("status") = status

        'rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_chnrmk") = txtShpMrk4.Text
        'If rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") <> "~*ADD*~" And _
        'rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") <> "~*UPD*~" And _
        'rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") <> "~*DEL*~" And _
        'rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") <> "~*NEW*~" Then
        '    rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") = "~*UPD*~"
        'End If
       
    End Sub

    Private Sub txtCerDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCerDoc.KeyPress
        If rs_CUSHPMRK.Tables("RESULT").Rows.Count = 0 Then
            Exit Sub
        End If
        Dim i As Integer
        For i = 0 To rs_CUSHPMRK.Tables("RESULT").Rows.Count - 1
            rs_CUSHPMRK.Tables("RESULT").Rows(i).Item("csm_cerdoc") = txtCerDoc.Text
        Next


    End Sub

    Private Sub txtCerDoc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCerDoc.TextChanged
        'If rs_CUSHPMRK.Tables("RESULT").Rows.Count = 0 Then
        '    Exit Sub
        'End If
        'Dim i As Integer
        'For i = 0 To rs_CUSHPMRK.Tables("RESULT").Rows.Count - 1
        '    rs_CUSHPMRK.Tables("RESULT").Rows(i).Item("csm_cerdoc") = txtCerDoc.Text
        'Next


    End Sub

    Private Sub optSecCus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optSecCus.CheckedChanged

    End Sub

    Private Sub optSecCus_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optSecCus.Click
        If Add_flag = True And optPriCus.Checked = False Then
            If MsgBox("Customer Type cannot be changed once selected. Are you sure?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Recordstatus = True

                'cboPrcFml.Enabled = True

                ' Label40.Visible = False
                optPriCus.Checked = False
                optPriCus.Enabled = False
                optSecCus.Checked = True
                ' optSecCus.Enabled = False


                gspStr = "sp_select_CUSUBCUS '','A','S'"
                rtnLong = execute_SQLStatement(gspStr, rs_CUSUBCUS_P, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading optSecCus_Click sp_select_CUSUBCUS :" & rtnStr)
                    Me.Cursor = Cursors.Default

                    Exit Sub
                Else
                    Call SetgrdRelCus()
                End If
            Else
                optSecCus.Checked = False



            End If
        End If
    End Sub

    Private Sub cboSalRep_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSalRep.Click
        Dim i As Integer

        If cboSalTem.Text = "" Then
            Exit Sub
        End If

        gspStr = "sp_list_SYUSRPRF_2 '','" & Split(Trim(cboSalTem.Text), " - ")(0) & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_SYUSRPRF_2, rtnStr)
            If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cboSalRep_Click sp_list_SYUSRPRF_2 :" & rtnStr)
                Exit Sub
            End If

        If Not rs_SYUSRPRF_2.Tables("RESULT").Rows.Count = 0 Then
            cboSalRep.Items.Clear()
            For i = 0 To rs_SYUSRPRF_2.Tables("RESULT").Rows.Count - 1
                cboSalRep.Items.Add(rs_SYUSRPRF_2.Tables("RESULT").Rows(i).Item("ssr_salrep") + " - " + rs_SYUSRPRF_2.Tables("RESULT").Rows(i).Item("yup_repnam"))
                'txtSalMgt.Text = UCase(rs_SYSALMGR.Tables("RESULT").Rows(0).Item("yup_usrnam"))
            Next i
        End If



    End Sub

    Private Sub cboSalRep_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSalRep.KeyUp
        auto_search_combo(cboSalRep, e.KeyCode)
    End Sub

    Private Sub cboSalRep_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSalRep.LostFocus


        'txtSalMgt.Text = ""
        'Dim userid As String

        'Try
        '    Dim test As String = Split(cboSalRep.Text, " - ")(1)
        '    If cboSalRep.Text <> "" Then
        '        If cboSalRep.SelectedIndex = -1 Then
        '            MsgBox("Data Invalid")
        '            txtSalMgt.Text = ""
        '            Exit Sub
        '        End If
        '    End If
        'Catch ex As Exception
        '    MsgBox("Data invalid")
        '    txtSalMgt.Text = ""
        '    Exit Sub
        'End Try



        'If cboSalRep.Text <> "" Then
        '    If Split(cboSalRep.Text, " - ")(1) <> "" Then

        '        gspStr = "sp_list_SYSALMGR '','" & Split(cboSalRep.Text, " - ")(1) & "'"
        '        rtnLong = execute_SQLStatement(gspStr, rs_SYSALMGR, rtnStr)
        '        If rtnLong <> RC_SUCCESS Then
        '            MsgBox("Error on loading cboSalRep_LostFocus sp_select_SYSALMGR_Check :" & rtnStr)
        '            Me.Cursor = Cursors.Default

        '            Exit Sub
        '        End If





        '    End If

        '    If Not rs_SYSALMGR.Tables("RESULT").Rows.Count = 0 Then
        '        txtSalMgt.Text = UCase(rs_SYSALMGR.Tables("RESULT").Rows(0).Item("yup_usrnam"))
        '    End If


        'End If

    End Sub

    Private Sub cboSalRep_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSalRep.SelectedIndexChanged
        Recordstatus = True
    End Sub

    Private Sub grdRelCus_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdRelCus.CellContentClick

    End Sub


    Private Sub chkDelete_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDelete.CheckedChanged

    End Sub

    Private Sub chkDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDelete.Click
        If rs_CUSHPMRK.Tables("RESULT").Rows.Count = 0 Then
            Exit Sub
        End If
        Dim shiptype As String
        If optMain.Checked = True Then
            shiptype = "M"
        ElseIf optSide.Checked = True Then
            shiptype = "S"
        ElseIf optInner.Checked = True Then
            shiptype = "I"
        End If



        '  rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") = "~*ADD*~"
        'rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("status") = status
        If Trim(rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("status")) = "" Then
            rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("status") = "Y"
            chkDelete.Checked = True
            If rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") <> "~*ADD*~" And _
                    rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") <> "~*DEL*~" And _
                    rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") <> "~*NEW*~" Then
                rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") = "~*DEL*~"
            ElseIf rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") = "~*ADD*~" Then
                rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") = "~*NEW*~"
            End If
        Else
            rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("status") = ""
            chkDelete.Checked = False
            If rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") = "~*ADD*~" Then
                rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") = "~*UPD*~"
            ElseIf rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") = "~*NEW*~" Then
                rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") = "~*ADD*~"
            ElseIf rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") = "~*DEL*~" Then
                rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") = "~*UPD*~"
            End If
        End If

        

    End Sub

    Private Sub cmdShpDocM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShpDocM.Click
        setStatus("ShipDoc")

        Me.BaseTabControl1.SelectedIndex = 6
        Me.BaseTabControl1.TabPages(0).Enabled = False
        Me.BaseTabControl1.TabPages(1).Enabled = False
        Me.BaseTabControl1.TabPages(2).Enabled = False
        Me.BaseTabControl1.TabPages(3).Enabled = False
        Me.BaseTabControl1.TabPages(4).Enabled = False
        Me.BaseTabControl1.TabPages(5).Enabled = False
        Me.BaseTabControl1.TabPages(6).Enabled = True
        Me.BaseTabControl1.TabPages(7).Enabled = False
        Me.BaseTabControl1.TabPages(8).Enabled = False
        Me.BaseTabControl1.TabPages(9).Enabled = False
        txtCusno.Enabled = False
        txtCusnam.Enabled = False
        txtCussna.Enabled = False
        chkActivate.Enabled = False
        chkAdvOrd.Enabled = False
        chkDiscontinue.Enabled = False
        func_ReadShipMarkRec()
        Call func_EnabledShpMrk()
    End Sub

    Private Sub grdRskCdt_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdRskCdt.CellContentClick

    End Sub
    Private Sub mmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdDelete.Click
        If checkFocus(Me) Then Exit Sub

        status = "Delete"

        If Not Add_flag Then
            If Not checkTimeStamp() Then
                MsgBox("Refresh")
                Exit Sub
            End If
        End If

        If Not Add_flag Then
            If optPriCus.Checked = True Then
                gspStr = "sp_list_QUOTNHDR_CUM00001 '','" & txtCusno.Text & "','P'"
            Else
                gspStr = "sp_list_QUOTNHDR_CUM00001 '','" & txtCusno.Text & "','S'"
            End If

            rtnLong = execute_SQLStatement(gspStr, rs_1, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cmdDelete_Click sp_list_QUOTNHDR_CUM00001 :" & rtnStr)
                Exit Sub
            Else
                If rs_1.Tables("RESULT").Rows.Count > 0 Then
                    MsgBox("This customer is referenced by Quotation. Record cannot delete!")
                    Exit Sub
                End If
            End If

            If optPriCus.Checked = True Then
                gspStr = "sp_list_SCORDHDR_CUM00001 '','" & txtCusno.Text & "','P'"
            Else
                gspStr = "sp_list_SCORDHDR_CUM00001 '','" & txtCusno.Text & "','S'"
            End If

            rtnLong = execute_SQLStatement(gspStr, rs_2, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cmdDelete_Click sp_list_SCORDHDR_CUM00001 :" & rtnStr)
                Exit Sub
            Else
                If rs_2.Tables("RESULT").Rows.Count > 0 Then
                    MsgBox("This vendor is referenced by SC. Record cannot delete!")
                    Exit Sub
                End If
            End If

        End If

        If MsgBox("Are you sure to Delete " & txtCusno.Text & "?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            txtCusnam.Focus()
            Exit Sub
        End If

        gspStr = "sp_physical_delete_CUAGTINF '','" & txtCusno.Text & "','','" & "DMtr" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdDelete_Click sp_physical_delete_CUAGTINF :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If


        gspStr = "sp_physical_delete_CUVENINF '','" & txtCusno.Text & "','','" & "DMtr" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdDelete_Click sp_physical_delete_CUVENINF :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        gspStr = "sp_physical_delete_CUMCOVEN '','" & "ALL" & "','" & txtCusno.Text & "','" & "A" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdDelete_Click sp_physical_delete_CUMCOVEN :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        gspStr = "sp_physical_delete_CUCNTINF '','" & txtCusno.Text & "',''," & 0 & ",'" & "DMtr" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdDelete_Click sp_physical_delete_CUCNTINF :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        gspStr = "sp_physical_delete_CUSHPINF '','" & txtCusno.Text & "',''," & 0 & ",'" & "DMtr" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdDelete_Click sp_physical_delete_CUSHPINF :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If


        gspStr = "sp_physical_delete_CUPRCINF '','" & txtCusno.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdDelete_Click sp_physical_delete_CUPRCINF :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If


        gspStr = "sp_physical_delete_CUmcamrk '','" & txtCusno.Text & "','A','All','" & Now.Date & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdDelete_Click sp_physical_delete_CUmcamrk :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        gspStr = "sp_physical_delete_CUBCR '','" & txtCusno.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdDelete_Click sp_physical_delete_CUBCR :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        gspStr = "sp_physical_delete_CUSHPMRK '','" & txtCusno.Text & "','','','DMtr'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdDelete_Click sp_physical_delete_CUSHPMRK :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        gspStr = "sp_physical_delete_CUSUBCUS '','" & txtCusno.Text & "','','DMtr'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdDelete_Click sp_physical_delete_CUSUBCUS :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        gspStr = "sp_physical_delete_CUPRCTRM_2 '','" & txtCusno.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdDelete_Click sp_physical_delete_CUPRCTRM_2 :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If



        gspStr = "sp_physical_delete_CUBASINF '','" & txtCusno.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdDelete_Click sp_physical_delete_CUBASINF :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        MsgBox("Deleted")
        Call setStatus("Init")
        txtCusno.Focus()

    End Sub


    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        status = "Delete"

        If Not Add_flag Then
            If Not checkTimeStamp() Then
                MsgBox("Refresh")
                Exit Sub
            End If
        End If

        If Not Add_flag Then
            If optPriCus.Checked = True Then
                gspStr = "sp_list_QUOTNHDR_CUM00001 '','" & txtCusno.Text & "','P'"
            Else
                gspStr = "sp_list_QUOTNHDR_CUM00001 '','" & txtCusno.Text & "','S'"
            End If

            rtnLong = execute_SQLStatement(gspStr, rs_1, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cmdDelete_Click sp_list_QUOTNHDR_CUM00001 :" & rtnStr)
                Exit Sub
            Else
                If rs_1.Tables("RESULT").Rows.Count > 0 Then
                    MsgBox("This customer is referenced by Quotation. Record cannot delete!")
                    Exit Sub
                End If
            End If

            If optPriCus.Checked = True Then
                gspStr = "sp_list_SCORDHDR_CUM00001 '','" & txtCusno.Text & "','P'"
            Else
                gspStr = "sp_list_SCORDHDR_CUM00001 '','" & txtCusno.Text & "','S'"
            End If

            rtnLong = execute_SQLStatement(gspStr, rs_2, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cmdDelete_Click sp_list_SCORDHDR_CUM00001 :" & rtnStr)
                Exit Sub
            Else
                If rs_2.Tables("RESULT").Rows.Count > 0 Then
                    MsgBox("This vendor is referenced by SC. Record cannot delete!")
                    Exit Sub
                End If
            End If

        End If

        If MsgBox("Are you sure to Delete " & txtCusno.Text & "?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            txtCusnam.Focus()
            Exit Sub
        End If

        gspStr = "sp_physical_delete_CUAGTINF '','" & txtCusno.Text & "','','" & "DMtr" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdDelete_Click sp_physical_delete_CUAGTINF :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If


        gspStr = "sp_physical_delete_CUVENINF '','" & txtCusno.Text & "','','" & "DMtr" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdDelete_Click sp_physical_delete_CUVENINF :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        gspStr = "sp_physical_delete_CUMCOVEN '','" & "ALL" & "','" & txtCusno.Text & "','" & "A" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdDelete_Click sp_physical_delete_CUMCOVEN :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        gspStr = "sp_physical_delete_CUCNTINF '','" & txtCusno.Text & "',''," & 0 & ",'" & "DMtr" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdDelete_Click sp_physical_delete_CUCNTINF :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        gspStr = "sp_physical_delete_CUSHPINF '','" & txtCusno.Text & "',''," & 0 & ",'" & "DMtr" & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdDelete_Click sp_physical_delete_CUSHPINF :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If


        gspStr = "sp_physical_delete_CUPRCINF '','" & txtCusno.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdDelete_Click sp_physical_delete_CUPRCINF :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If


        gspStr = "sp_physical_delete_CUmcamrk '','" & txtCusno.Text & "','A','All','" & Now.Date & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdDelete_Click sp_physical_delete_CUmcamrk :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        gspStr = "sp_physical_delete_CUBCR '','" & txtCusno.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdDelete_Click sp_physical_delete_CUBCR :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        gspStr = "sp_physical_delete_CUSHPMRK '','" & txtCusno.Text & "','','','DMtr'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdDelete_Click sp_physical_delete_CUSHPMRK :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        gspStr = "sp_physical_delete_CUSUBCUS '','" & txtCusno.Text & "','','DMtr'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdDelete_Click sp_physical_delete_CUSUBCUS :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        gspStr = "sp_physical_delete_CUPRCTRM_2 '','" & txtCusno.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdDelete_Click sp_physical_delete_CUPRCTRM_2 :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If



        gspStr = "sp_physical_delete_CUBASINF '','" & txtCusno.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdDelete_Click sp_physical_delete_CUBASINF :" & rtnStr)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        MsgBox("Deleted")
        Call setStatus("Init")
        txtCusno.Focus()

    End Sub
    Private Sub mmdCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdCopy.Click
        If checkFocus(Me) Then Exit Sub

        copyflag = True

        tab1 = Me.BaseTabControl1.TabPages(0).Enabled
        tab2 = Me.BaseTabControl1.TabPages(1).Enabled
        tab3 = Me.BaseTabControl1.TabPages(2).Enabled
        tab4 = Me.BaseTabControl1.TabPages(3).Enabled
        tab5 = Me.BaseTabControl1.TabPages(4).Enabled
        tab6 = Me.BaseTabControl1.TabPages(5).Enabled
        tab7 = Me.BaseTabControl1.TabPages(6).Enabled
        tab8 = Me.BaseTabControl1.TabPages(7).Enabled
        tab9 = Me.BaseTabControl1.TabPages(8).Enabled
        tab10 = Me.BaseTabControl1.TabPages(9).Enabled

        Me.BaseTabControl1.TabPages(0).Enabled = False
        Me.BaseTabControl1.TabPages(1).Enabled = False
        Me.BaseTabControl1.TabPages(2).Enabled = False
        Me.BaseTabControl1.TabPages(3).Enabled = False
        Me.BaseTabControl1.TabPages(4).Enabled = False
        Me.BaseTabControl1.TabPages(5).Enabled = False
        Me.BaseTabControl1.TabPages(6).Enabled = False
        Me.BaseTabControl1.TabPages(7).Enabled = False
        Me.BaseTabControl1.TabPages(8).Enabled = False
        Me.BaseTabControl1.TabPages(9).Enabled = False

        txtCusnam.Enabled = False
        txtCussna.Enabled = False
        chkAdvOrd.Enabled = False
        chkDiscontinue.Enabled = False
        cmdshipdoc = cmdShpDocM.Enabled
        cmdShpDocM.Enabled = False


        mmdSave.Enabled = False
        mmdDelete.Enabled = False
        mmdClear.Enabled = False
        mmdInsRow.Enabled = False
        mmdDelRow.Enabled = False
        mmdCopy.Enabled = False
        mmdExit.Enabled = False



        PanelCopy.Height = 108
        PanelCopy.Width = 294
        PanelCopy.Top = 102
        PanelCopy.Left = 167
        PanelCopy.Visible = True


    End Sub


    Private Sub cmdCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        copyflag = True

        tab1 = Me.BaseTabControl1.TabPages(0).Enabled
        tab2 = Me.BaseTabControl1.TabPages(1).Enabled
        tab3 = Me.BaseTabControl1.TabPages(2).Enabled
        tab4 = Me.BaseTabControl1.TabPages(3).Enabled
        tab5 = Me.BaseTabControl1.TabPages(4).Enabled
        tab6 = Me.BaseTabControl1.TabPages(5).Enabled
        tab7 = Me.BaseTabControl1.TabPages(6).Enabled
        tab8 = Me.BaseTabControl1.TabPages(7).Enabled
        tab9 = Me.BaseTabControl1.TabPages(8).Enabled
        tab10 = Me.BaseTabControl1.TabPages(9).Enabled

        Me.BaseTabControl1.TabPages(0).Enabled = False
        Me.BaseTabControl1.TabPages(1).Enabled = False
        Me.BaseTabControl1.TabPages(2).Enabled = False
        Me.BaseTabControl1.TabPages(3).Enabled = False
        Me.BaseTabControl1.TabPages(4).Enabled = False
        Me.BaseTabControl1.TabPages(5).Enabled = False
        Me.BaseTabControl1.TabPages(6).Enabled = False
        Me.BaseTabControl1.TabPages(7).Enabled = False
        Me.BaseTabControl1.TabPages(8).Enabled = False
        Me.BaseTabControl1.TabPages(9).Enabled = False

        txtCusnam.Enabled = False
        txtCussna.Enabled = False
        chkAdvOrd.Enabled = False
        chkDiscontinue.Enabled = False
        cmdshipdoc = cmdShpDocM.Enabled
        cmdShpDocM.Enabled = False

        PanelCopy.Height = 108
        PanelCopy.Width = 294
        PanelCopy.Top = 102
        PanelCopy.Left = 167
        PanelCopy.Visible = True


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        If tab1 = True Then
            Me.BaseTabControl1.TabPages(0).Enabled = True
        End If
        If tab2 = True Then
            Me.BaseTabControl1.TabPages(1).Enabled = True
        End If
        If tab3 = True Then
            Me.BaseTabControl1.TabPages(2).Enabled = True
        End If
        If tab4 = True Then
            Me.BaseTabControl1.TabPages(3).Enabled = True
        End If
        If tab5 = True Then
            Me.BaseTabControl1.TabPages(4).Enabled = True
        End If
        If tab6 = True Then
            Me.BaseTabControl1.TabPages(5).Enabled = True
        End If
        If tab7 = True Then
            Me.BaseTabControl1.TabPages(6).Enabled = True
        End If
        If tab8 = True Then
            Me.BaseTabControl1.TabPages(7).Enabled = True
        End If
        If tab9 = True Then
            Me.BaseTabControl1.TabPages(8).Enabled = True
        End If
        If tab10 = True Then
            Me.BaseTabControl1.TabPages(9).Enabled = True
        End If


        txtCusnam.Enabled = True
        txtCussna.Enabled = True
        chkAdvOrd.Enabled = True
        chkDiscontinue.Enabled = True

        mmdExit.Enabled = True
        If cmdshipdoc = True Then
            cmdShpDocM.Enabled = True

        End If


        Me.BaseTabControl1.TabPages(0).Enabled = True
        copyflag = False
        Add_flag = False
        copyflag = False
        Recordstatus = False
        currentShipmark = 0
        PanelCopy.Visible = False




        setStatus("CopyCancel")

        
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If OptCpyPricus.Checked = False And OptCpySeccus.Checked = False Then
            MsgBox("Please select Customer Type.")
            Exit Sub
        End If

        If MsgBox("Are you sure to Copy Customer " & txtCusno.Text & "?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.Cursor = Cursors.WaitCursor
            Me.StatusBar.Items("lblLeft").Text = "Copying . . . ."

            If OptCpyPricus.Checked = True Then
                CusTyp = "P"
            Else
                CusTyp = "S"
            End If

            Call func_AddNewCustNo()


            Dim csf_cus1no As String
            Dim csf_cus2no As String
            Dim i As Integer

            If CusTyp = "P" Then
                csf_cus1no = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cusno")
                csf_cus2no = ""

                For i = 0 To rs_CUSHPFML.Tables("RESULT").Rows.Count - 1
                    rs_CUSHPFML.Tables("RESULT").Rows(i).Item("csf_cus1no") = csf_cus1no
                    rs_CUSHPFML.Tables("RESULT").Rows(i).Item("csf_cus2no") = csf_cus2no
                    rs_CUSHPFML.Tables("RESULT").Rows(i).Item("csf_creusr") = "~*NEW*~"
                Next i
            End If

            Call func_SaveRecordset()

            Call AddNewPriceTerm()

            tmpcusno = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cusno")


            mmdExit.Enabled = True

            tmp = ""
            Add_flag = False
            copyflag = False
            Recordstatus = False
            currentShipmark = 0
            CusTyp = ""
            Me.Cursor = Cursors.Default
            Call setStatus("Clear") 'copy need delete
            PanelCopy.Visible = False
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub AddNewPriceTerm()
        If rs_CUCALFML.Tables("RESULT").Rows.Count = 0 Then
            Exit Sub
        End If

        Dim dv_CUCALFML As DataView
        'dv_CUCALFML = rs_CUCALFML.Tables("RESULT").Select("ccf_effdat <= #" & DateTime.Now & "#")
        dv_CUCALFML = rs_CUCALFML.Tables("RESULT").DefaultView
        dv_CUCALFML.RowFilter = "ccf_effdat <= #" & DateTime.Now & "#"
        dv_CUCALFML.Sort = "ccf_effdat desc"
        If dv_CUCALFML.Count <> 0 Then
            Dim latestdate As String
            latestdate = Format(dv_CUCALFML(0)("ccf_effdat"), "MM/dd/yyyy")

            Dim dr() As DataRow
            dr = rs_CUCALFML.Tables("RESULT").Select("ccf_effdat = #" & latestdate & "#")

            If dr.Length <> 0 Then
                Dim ccf_del As String
                Dim ccf_cocde As String
                Dim ccf_cus1no As String
                Dim ccf_cus2no As String
                Dim ccf_cat As String
                Dim ccf_venno As String
                Dim ccf_prctrm As String
                Dim ccf_trantrm As String
                Dim ccf_curcde As String
                Dim ccf_cumu As Decimal
                Dim ccf_pm As Decimal
                Dim ccf_cush As Decimal
                Dim ccf_thccusper As Decimal
                Dim ccf_upsper As Decimal
                Dim ccf_labper As Decimal
                Dim ccf_faper As Decimal
                Dim ccf_cstbufper As Decimal
                Dim ccf_othper As Decimal
                Dim ccf_pliper As Decimal
                Dim ccf_dmdper As Decimal
                Dim ccf_rbtper As Decimal
                Dim ccf_pkgper As Decimal
                Dim ccf_comper As Decimal
                Dim ccf_icmper As Decimal
                Dim ccf_creusr As String
                Dim ccf_latest As String
                Dim ccf_effdat As DateTime
                Dim ccf_iseff As String


                Dim i As Integer





                For i = 0 To dr.Length - 1
                    '  If rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_latest") = "Y" Then

                    ccf_cocde = ""


                    If CusTyp = "P" Then
                        ccf_cus1no = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cusno")
                        ccf_cus2no = ""
                    ElseIf CusTyp = "S" Then

                        ccf_cus1no = ""
                        ccf_cus2no = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cusno")
                    End If
                  
                    ccf_cat = dr(i)("ccf_cat")
                    ccf_venno = dr(i)("ccf_venno")
                    ccf_prctrm = dr(i)("ccf_prctrm")
                    ccf_trantrm = dr(i)("ccf_trantrm")
                    ccf_curcde = dr(i)("ccf_curcde")
                    ccf_cumu = dr(i)("ccf_cumu") / 100
                    ccf_pm = dr(i)("ccf_pm") / 100
                    ccf_cush = dr(i)("ccf_cush") / 100
                    ccf_thccusper = dr(i)("ccf_thccusper") / 100
                    ccf_upsper = dr(i)("ccf_upsper") / 100
                    ccf_labper = dr(i)("ccf_labper") / 100
                    ccf_faper = dr(i)("ccf_faper") / 100
                    ccf_cstbufper = dr(i)("ccf_cstbufper") / 100
                    ccf_othper = dr(i)("ccf_othper") / 100
                    ccf_pliper = dr(i)("ccf_pliper") / 100
                    ccf_dmdper = dr(i)("ccf_dmdper") / 100
                    ccf_rbtper = dr(i)("ccf_rbtper") / 100
                    ccf_pkgper = dr(i)("ccf_pkgper") / 100
                    ccf_comper = dr(i)("ccf_comper") / 100
                    ccf_icmper = dr(i)("ccf_icmper") / 100
                    ccf_creusr = dr(i)("ccf_creusr")
                    ccf_latest = dr(i)("ccf_latest")
                    ccf_effdat = dr(i)("ccf_effdat")
                    ccf_iseff = dr(i)("ccf_iseff")




                    gspStr = "sp_insert_CUCALFML_EFFDAT '" & ccf_cocde & "','" & ccf_cus1no & "','" & ccf_cus2no & "','" & ccf_cat & "','" & _
                              ccf_venno & "','" & ccf_prctrm & "','" & ccf_trantrm & "','" & ccf_curcde & "'," & ccf_cumu & "," & _
                              ccf_pm & "," & ccf_cush & "," & ccf_thccusper & "," & ccf_upsper & "," & ccf_labper & "," & ccf_faper & "," & _
                              ccf_cstbufper & "," & ccf_othper & "," & ccf_pliper & "," & ccf_dmdper & "," & ccf_rbtper & "," & ccf_pkgper & "," & _
                              ccf_comper & "," & ccf_icmper & ",'" & ccf_effdat & "','" & ccf_iseff & "','" & gsUsrID & "'"

                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading AddNewPriceTerm sp_insert_CUCALFML_EFFDAT :" & rtnStr)

                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If





                Next


            End If



        End If



    End Sub



    Private Sub grdRskCdt_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdRskCdt.CellEndEdit
        If cboStatus.Text <> "A - Active" Then
            Exit Sub
        End If
        If grdRskCdt.CurrentCell.ColumnIndex = grdRskCdt_cbc_rsklmt Then
            If grdRskCdt.Item(grdRskCdt_cbc_rsklmt, grdRskCdt.CurrentCell.RowIndex).Value.ToString = "" Then
                grdRskCdt.Item(grdRskCdt_cbc_rsklmt, grdRskCdt.CurrentCell.RowIndex).Value = 0
            ElseIf grdRskCdt.Item(grdRskCdt_cbc_rsklmt, grdRskCdt.CurrentCell.RowIndex).Value > 999999999 Then
                grdRskCdt.Item(grdRskCdt_cbc_rsklmt, grdRskCdt.CurrentCell.RowIndex).Value = 999999999
            End If

        ElseIf grdRskCdt.CurrentCell.ColumnIndex = grdRskCdt_cbc_cdtlmt Then
            If grdRskCdt.Item(grdRskCdt_cbc_cdtlmt, grdRskCdt.CurrentCell.RowIndex).Value.ToString = "" Then
                grdRskCdt.Item(grdRskCdt_cbc_cdtlmt, grdRskCdt.CurrentCell.RowIndex).Value = 0

            ElseIf grdRskCdt.Item(grdRskCdt_cbc_cdtlmt, grdRskCdt.CurrentCell.RowIndex).Value > 999999999 Then
                grdRskCdt.Item(grdRskCdt_cbc_cdtlmt, grdRskCdt.CurrentCell.RowIndex).Value = 999999999

            End If

        End If
    End Sub

    Private Sub grdRskCdt_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdRskCdt.CellValidating
        If e.ColumnIndex = grdRskCdt_cbc_cdtlmt Then
            If Not IsNumeric(e.FormattedValue) Then
                MsgBox("Credit limit must be a numeric value.")
                e.Cancel = True
            End If
        ElseIf e.ColumnIndex = grdRskCdt_cbc_rsklmt Then
            If Not IsNumeric(e.FormattedValue) Then
                MsgBox("Risk limit must be a numeric value.")
                e.Cancel = True
            End If
        End If


    End Sub


    Private Sub grdRskCdt_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles grdRskCdt.DataError


    End Sub

   

    Private Sub grdRskCdt_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdRskCdt.EditingControlShowing
        If cboStatus.Text <> "A - Active" Then
            Exit Sub
        End If
        If grdRskCdt.RowCount = 0 Then
            Exit Sub
        End If
        e.CellStyle.BackColor = Color.White

      


        'If mode = "UPDATE" Or mode = "ADD" Then
        Recordstatus = True
        If grdRskCdt.Item(grdRskCdt_cbc_creusr, grdRskCdt.CurrentCell.RowIndex).Value <> "~*ADD*~" And _
        grdRskCdt.Item(grdRskCdt_cbc_creusr, grdRskCdt.CurrentCell.RowIndex).Value <> "~*DEL*~" And _
        grdRskCdt.Item(grdRskCdt_cbc_creusr, grdRskCdt.CurrentCell.RowIndex).Value <> "~*UPD*~" And _
        grdRskCdt.Item(grdRskCdt_cbc_creusr, grdRskCdt.CurrentCell.RowIndex).Value <> "~*NEW*~" Then ''creusr or upusr?
            grdRskCdt.Item(grdRskCdt_cbc_creusr, grdRskCdt.CurrentCell.RowIndex).Value = "~*UPD*~"
        End If
    End Sub

  
    Private Sub cmdFindMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFindMark.Click
        save_currentshipmrk()
        CUM00001_RECNO = rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_seqno")
        grdshowship.DataSource = rs_CUSHPMRK.Tables("RESULT").DefaultView



        Call setGrdshowshpmrk()

        shipmrkPanel.Height = 250
        shipmrkPanel.Width = 654
        shipmrkPanel.Top = 164
        shipmrkPanel.Left = 158

        shipmrkPanel.Visible = True

    End Sub

    Private Sub setGrdshowshpmrk()
        If rs_CUSHPMRK.Tables.Count = 0 Then
            Exit Sub
        End If





        grdshowship.RowHeadersWidth = 18
        grdshowship.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        grdshowship.ColumnHeadersHeight = 18
        grdshowship.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        grdshowship.AllowUserToResizeColumns = False
        grdshowship.AllowUserToResizeRows = False
        grdshowship.RowTemplate.Height = 18


        Dim i As Integer

        'If mode = "UPDATE" Or mode = "ADD" Then
        For i = 0 To rs_CUSHPMRK.Tables("RESULT").Columns.Count - 1
            rs_CUSHPMRK.Tables("RESULT").Columns(i).ReadOnly = False
        Next i
        'End If
        i = 0

        grdshowship.Columns(i).Visible = False
        i = i + 1

        grdshowship.Columns(i).Visible = False
        i = i + 1
        grdshowship.Columns(i).Visible = False
          i = i + 1

        grdshowship.Columns(i).HeaderText = "#"
        grdshowship.Columns(i).Width = 30
        grdshowship.Columns(i).ReadOnly = True
        i = i + 1

        grdshowship.Columns(i).Visible = False
        i = i + 1

        grdshowship.Columns(i).HeaderText = "Type"
        grdshowship.Columns(i).Width = 35
        grdshowship.Columns(i).ReadOnly = True
        i = i + 1

        grdshowship.Columns(i).HeaderText = "English Description"
        grdshowship.Columns(i).Width = 250
        grdshowship.Columns(i).ReadOnly = True
        i = i + 1

        grdshowship.Columns(i).HeaderText = "Chi Desc"
        grdshowship.Columns(i).Width = 100
        grdshowship.Columns(i).ReadOnly = True
        i = i + 1

        grdshowship.Columns(i).Visible = False

        i = i + 1
        grdshowship.Columns(i).Visible = False

        i = i + 1

        grdshowship.Columns(i).HeaderText = "Image Path"
        grdshowship.Columns(i).Width = 100
        grdshowship.Columns(i).ReadOnly = True
        i = i + 1

        grdshowship.Columns(i).HeaderText = "Ship Mark File"
        grdshowship.Columns(i).Width = 100
        grdshowship.Columns(i).ReadOnly = True
        i = i + 1
        grdshowship.Columns(i).Visible = False
        i = i + 1
        grdshowship.Columns(i).Visible = False
        i = i + 1
        grdshowship.Columns(i).Visible = False
        i = i + 1
        grdshowship.Columns(i).Visible = False
        i = i + 1
        grdshowship.Columns(i).Visible = False
        i = i + 1
        grdshowship.Columns(i).Visible = False
      

    End Sub

    Private Sub grdshowship_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdshowship.CellContentClick

    End Sub

    Private Sub grdshowship_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdshowship.CellDoubleClick
        If rs_CUSHPMRK.Tables("RESULT").Rows.Count = 0 Then
            Exit Sub
        End If

        Dim dr() As DataRow
        dr = rs_CUSHPMRK.Tables("RESULT").Select("csm_seqno =" & grdshowship.Rows(grdshowship.CurrentCell.RowIndex).Cells("csm_seqno").Value)
        rs_CUSHPMRK.Tables("RESULT").Rows.IndexOf(dr(0))

        currentShipmark = rs_CUSHPMRK.Tables("RESULT").Rows.IndexOf(dr(0))


        func_ReadShipMarkRec()

        If rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("status") = "Y" Then
            chkDelete.Checked = True
        Else
            chkDelete.Checked = False
        End If

        shipmrkPanel.Visible = False

        'shipmrkPanel.Visible = False

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        shipmrkPanel.Visible = False
    End Sub

    Private Sub txtShpMrk6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShpMrk6.TextChanged

    End Sub

    Private Sub chkDiscontinue_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDiscontinue.CheckedChanged

    End Sub

    Private Sub chkDiscontinue_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDiscontinue.Click
        Recordstatus = True
        Dim tmp_advord As String
        If chkAdvOrd.Enabled Then
            tmp_advord = "Y"
        Else
            tmp_advord = "N"
        End If
        '*****
        FlagDiscontinue = True
        If Not Add_flag And Me.StatusBar.Items("lblLeft").Text <> "Clearing" Then
            If chkDiscontinue.Checked = True Then
                cboStatus.Text = "D - Discontinue"
                If gsUsrGrp = "CED-S" Or gsUsrGrp = "EDP-S" Or gsUsrGrp = "MSAL-A" Or gsUsrRank = 1 Then
                    Call func_DisableInactiveCustomer(Me)
                End If
            Else    'chkDiscontinue.Value = 0
                If rs_CUBASINF.Tables("RESULT").Rows.Count > 0 Then
                    If rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cussts") = "A" Then
                        cboStatus.Text = "A - Active"
                    ElseIf rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cussts") = "H" Then
                        cboStatus.Text = "H - On Hold due to over limit"
                    ElseIf rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cussts") = "I" Then
                        cboStatus.Text = "I - Inactive"
                        If gsUsrGrp = "CED-S" Or gsUsrGrp = "EDP-S" Or gsUsrGrp = "MSAL-A" Or gsUsrRank = 1 Then
                            Call func_DisableInactiveCustomer(Me)
                        End If
                    ElseIf rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cussts") = "D" Then
                        cboStatus.Text = "A - Active"
                    End If
                    If rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_advord") = "Y" Then
                        chkAdvOrd.Checked = True
                    Else
                        chkAdvOrd.Checked = False

                    End If
                    Call setStatus("Updating")

                    'added by tommy on 15 nov 2002
                    If rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_custyp") = "P" Then
                        optPriCus.Checked = True
                        optPriCus.Enabled = True
                        optSecCus.Enabled = False
                        optGrsMgn.Enabled = False
                        optMarkup.Enabled = False
                        txtgrsMgn.Text = ""
                        txtgrsMgn.Enabled = False
                        If Microsoft.VisualBasic.Left(txtCusno.Text, 1) > 4 Then


                        End If
                    ElseIf rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_custyp") = "S" Then
                        optSecCus.Checked = True
                        optPriCus.Enabled = False
                        optSecCus.Enabled = True
                        If Microsoft.VisualBasic.Left(txtCusno.Text, 1) > 4 Then
                          
                        Else

                        End If
                        optGrsMgn.Enabled = True
                        optMarkup.Enabled = True
                        txtgrsMgn.Enabled = True
                    End If

                    txtCusno.Enabled = False
                End If
            End If
        End If

        '*** Resume the Advance Order Status ******
        If tmp_advord = "Y" Then
            chkAdvOrd.Enabled = True
        Else
            chkAdvOrd.Enabled = False
        End If

    End Sub
    Private Sub mmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdSearch.Click
        If checkFocus(Me) Then Exit Sub

        Dim frmSYM00018 As New SYM00018

        frmSYM00018.keyName = txtCusno.Name
        frmSYM00018.strModule = "CU"

        frmSYM00018.show_frmSYM00018(Me)
    End Sub

    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frmSYM00018 As New SYM00018

        frmSYM00018.keyName = txtCusno.Name
        frmSYM00018.strModule = "CU"

        frmSYM00018.show_frmSYM00018(Me)
    End Sub

    Private Sub txtCusPOD_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCusPOD.GotFocus
        txtCusPOD.Height = 120
        txtCusPOD.Top = 285
    End Sub

    Private Sub txtCusPOD_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCusPOD.KeyPress
        Recordstatus = True
    End Sub

    Private Sub txtCusPOD_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCusPOD.LostFocus
        txtCusPOD.Height = 44
        txtCusPOD.Top = 344
    End Sub

    Private Sub txtCusPOD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCusPOD.TextChanged

    End Sub
    Private Function checkTimeStamp() As Boolean
        Dim save_timestamp As Long
        Dim curr_timestamp As Long

        gspStr = "sp_select_CUBASINF '','" & txtCusno.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading checkTimeStamp sp_select_VNBASINF :" & rtnStr)
            Exit Function
        End If

        save_timestamp = rs.Tables("RESULT").Rows(0).Item("cbi_timstp")
        curr_timestamp = rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_timstp")

        If save_timestamp <> curr_timestamp Then
            checkTimeStamp = False
        Else
            checkTimeStamp = True
        End If

    End Function

    Private Sub cboCountry_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCountry.KeyUp
        auto_search_combo(cboCountry, e.KeyCode)
    End Sub

    Private Sub cboCountry_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCountry.SelectedIndexChanged
        Recordstatus = True
    End Sub

    Private Sub cboCusRat_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCusRat.KeyUp
        auto_search_combo(cboCusRat, e.KeyCode)
    End Sub

    Private Sub cboCusRat_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCusRat.LostFocus
        
    End Sub

    Private Sub cboCusRat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCusRat.SelectedIndexChanged
        Recordstatus = True
    End Sub

    Private Sub cboCurcde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCurcde.SelectedIndexChanged
        Recordstatus = True
    End Sub

    Private Sub cboFrgTrm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFrgTrm.KeyUp
        auto_search_combo(cboFrgTrm, e.KeyCode)
    End Sub

    Private Sub cboFrgTrm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFrgTrm.SelectedIndexChanged
        Recordstatus = True
    End Sub

    Private Sub cboMrkReg_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMrkReg.KeyUp
        auto_search_combo(cboMrkReg, e.KeyCode)
    End Sub

    Private Sub cboMrkReg_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMrkReg.LostFocus
        
    End Sub

    Private Sub cboMrkReg_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMrkReg.SelectedIndexChanged
        Recordstatus = True
    End Sub

    Private Sub cboPayTrm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPayTrm.KeyUp
        auto_search_combo(cboPayTrm, e.KeyCode)
    End Sub

    Private Sub cboPayTrm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPayTrm.SelectedIndexChanged
        Recordstatus = True
    End Sub

    Private Sub cboPrcTrm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPrcTrm.KeyUp
        auto_search_combo(cboPrcTrm, e.KeyCode)
    End Sub

    Private Sub cboPrcTrm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPrcTrm.SelectedIndexChanged
        Recordstatus = True
    End Sub

    Private Sub txtCusnam_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCusnam.KeyPress
        Recordstatus = True
    End Sub

    Private Sub txtCusnam_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCusnam.LostFocus
        txtCusnam.Text = UCase(txtCusnam.Text)
    End Sub

    Private Sub txtCusnam_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCusnam.TextChanged

    End Sub

    Private Sub txtCussna_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCussna.KeyPress
        Recordstatus = True
    End Sub

    Private Sub txtCussna_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCussna.LostFocus
        txtCussna.Text = UCase(txtCussna.Text)
    End Sub

    Private Sub txtCussna_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCussna.TextChanged

    End Sub

    Private Sub chkActivate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkActivate.CheckedChanged

    End Sub

    Private Sub chkActivate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkActivate.Click
        Recordstatus = True
    End Sub

    Private Sub grdshowship_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdshowship.CellValidating

    End Sub

    Private Sub cboMrkTyp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMrkTyp.LostFocus
        
    End Sub

   

    Private Sub cboMrkTyp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMrkTyp.SelectedIndexChanged
        Recordstatus = True
    End Sub

    Private Sub txtSalMgt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSalMgt.TextChanged

    End Sub

    Private Sub txtComAdr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtComAdr.KeyPress
        Recordstatus = True
    End Sub

    Private Sub txtComAdr_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtComAdr.LostFocus
        txtComAdr.Text = UCase(txtComAdr.Text)
    End Sub

     

    Private Sub txtComAdr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtComAdr.TextChanged

    End Sub

    Private Sub txtRemark_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRemark.TextChanged

    End Sub

    Private Sub chkAdvOrd_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAdvOrd.CheckedChanged

    End Sub

    Private Sub chkAdvOrd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAdvOrd.Click
        Recordstatus = True
    End Sub

    Private Sub txtCusStt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCusStt.KeyPress
        Recordstatus = True
    End Sub

     

    Private Sub txtCusStt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCusStt.TextChanged

    End Sub

    Private Sub txtZIP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtZIP.KeyPress
        Recordstatus = True
    End Sub

    Private Sub txtZIP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtZIP.TextChanged

    End Sub

    Private Sub cboProTrm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboProTrm.KeyUp
        auto_search_combo(cboProTrm, e.KeyCode)
    End Sub

    Private Sub cboProTrm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProTrm.SelectedIndexChanged
        Recordstatus = True
    End Sub

    Private Sub ChkMoqChg_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMoqChg.CheckedChanged

    End Sub

    Private Sub ChkMoqChg_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkMoqChg.Click
        Recordstatus = True
    End Sub

    Private Sub ChkMoaChg_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMoaChg.CheckedChanged

    End Sub

    Private Sub ChkMoaChg_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkMoaChg.Click
        Recordstatus = True
    End Sub

    Private Sub txtquplus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtquplus.KeyPress
        Recordstatus = True
        Dim val As String
        val = Trim(txtquplus.Text)

        If (InStr("0123456789.", Chr(Asc(e.KeyChar))) = 0) And Asc(e.KeyChar) > 31 Or _
        ((InStr(val, ".") <> 0) And Asc(e.KeyChar) > 31 And Chr(Asc(e.KeyChar)) = ".") Then
            e.KeyChar = Chr(0)
        ElseIf UBound(Split(val, ".")) = 0 Then
            If (Microsoft.VisualBasic.Len(val) + 1 > 3) And Asc(e.KeyChar) > 31 And (Chr(Asc(e.KeyChar)) <> ".") Then
                e.KeyChar = Chr(0)
            End If
        ElseIf UBound(Split(val, ".")) > 0 Then


            If txtquplus.SelectionStart <= Microsoft.VisualBasic.Len(Split(val, ".")(0)) Then

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

    Private Sub txtquplus_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtquplus.TextChanged

    End Sub

    Private Sub txtquminus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtquminus.KeyPress
        Recordstatus = True
        Dim val As String
        val = Trim(txtquminus.Text)

        If (InStr("0123456789.", Chr(Asc(e.KeyChar))) = 0) And Asc(e.KeyChar) > 31 Or _
        ((InStr(val, ".") <> 0) And Asc(e.KeyChar) > 31 And Chr(Asc(e.KeyChar)) = ".") Then
            e.KeyChar = Chr(0)
        ElseIf UBound(Split(val, ".")) = 0 Then
            If (Microsoft.VisualBasic.Len(val) + 1 > 3) And Asc(e.KeyChar) > 31 And (Chr(Asc(e.KeyChar)) <> ".") Then
                e.KeyChar = Chr(0)
            End If
        ElseIf UBound(Split(val, ".")) > 0 Then


            If txtquminus.SelectionStart <= Microsoft.VisualBasic.Len(Split(val, ".")(0)) Then

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

    Private Sub txtquminus_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtquminus.TextChanged

    End Sub

    Private Sub txtMemo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMemo.KeyPress
        Recordstatus = True
    End Sub

    Private Sub txtMemo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMemo.TextChanged

    End Sub

    Private Sub txtquplus_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtquplus.Validating
        If IsNumeric(txtquplus.Text) = True Then
            If Convert.ToDouble(txtquplus.Text) > 100 Then
                e.Cancel = True
                MsgBox("% cannot over 100")
                txtquplus.Focus()
            End If
        ElseIf Trim(txtquplus.Text) = "" Then
            txtquplus.Text = 0
        End If

        If txtquplus.Text.StartsWith(".") Then
            txtquplus.Text = "0" + txtquplus.Text
        End If
    End Sub

    Private Sub txtquminus_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtquminus.Validating
        If IsNumeric(txtquminus.Text) = True Then
            If Convert.ToDouble(txtquminus.Text) > 100 Then
                e.Cancel = True
                MsgBox("% cannot over 100")
                txtquminus.Focus()
            End If
        ElseIf Trim(txtquminus.Text) = "" Then
            txtquminus.Text = 0
        End If

        If txtquminus.Text.StartsWith(".") Then
            txtquminus.Text = "0" + txtquminus.Text
        End If
    End Sub

    Private Sub txtgrsMgn_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtgrsMgn.KeyPress
        Recordstatus = True
        Dim val As String
        val = Trim(txtgrsMgn.Text)

        If (InStr("0123456789.", Chr(Asc(e.KeyChar))) = 0) And Asc(e.KeyChar) > 31 Or _
        ((InStr(val, ".") <> 0) And Asc(e.KeyChar) > 31 And Chr(Asc(e.KeyChar)) = ".") Then
            e.KeyChar = Chr(0)
        ElseIf UBound(Split(val, ".")) = 0 Then
            If (Microsoft.VisualBasic.Len(val) + 1 > 3) And Asc(e.KeyChar) > 31 And (Chr(Asc(e.KeyChar)) <> ".") Then
                e.KeyChar = Chr(0)
            End If
        ElseIf UBound(Split(val, ".")) > 0 Then


            If txtgrsMgn.SelectionStart <= Microsoft.VisualBasic.Len(Split(val, ".")(0)) Then

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

    Private Sub txtgrsMgn_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtgrsMgn.TextChanged

    End Sub

    Private Sub txtgrsMgn_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtgrsMgn.Validating
        If IsNumeric(txtgrsMgn.Text) = True Then
            If Convert.ToDouble(txtgrsMgn.Text) > 100 Then
                e.Cancel = True
                MsgBox("% cannot over 100")
                txtgrsMgn.Focus()
            End If
        ElseIf Trim(txtgrsMgn.Text) = "" Then
            txtgrsMgn.Text = 0
        End If

        If txtgrsMgn.Text.StartsWith(".") Then
            txtgrsMgn.Text = "0" + txtgrsMgn.Text
        End If

    End Sub
    Private Sub mmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdExit.Click
        If checkFocus(Me) Then Exit Sub
        If Recordstatus = True Then
            mmdClear_Click(sender, e)
        End If
        Me.Close()
    End Sub


    Private Sub cboMrkTyp_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMrkTyp.KeyUp
        auto_search_combo(cboMrkTyp, e.KeyCode)
    End Sub


    Private Sub mmdDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdDelRow.Click
        If checkFocus(Me) Then Exit Sub

        If Me.BaseTabControl1.SelectedIndex = 6 Then
            Got_Focus_Grid = "ShipMark"
        End If

        Select Case Got_Focus_Grid
            Case "Coven"
                Call Del_Coven()
            Case "Agent"
                Call Del_Agent()
            Case "CusVen"
                Call Del_cusven()
            Case "Billing"
                Call Del_Billing()
            Case "Shipping"
                Call Del_Shipping()
            Case "Contact"
                Call del_contact()
            Case "ItmCatMarkup"
                Call del_itmcatmarkup()
            Case "Bank"
                Call del_bank()
            Case "Courier"
                Call del_courrier()
            Case "RelCus"
                Call del_relcus()
            Case "ShipMark"
                Call del_shipMark()
        End Select
    End Sub
  
   
    Private Sub del_shipMark()
        If rs_CUSHPMRK.Tables("RESULT").Rows.Count = 0 Then
            Exit Sub
        End If

       

        Dim shiptype As String
        If optMain.Checked = True Then
            shiptype = "M"
        ElseIf optSide.Checked = True Then
            shiptype = "S"
        ElseIf optInner.Checked = True Then
            shiptype = "I"
        End If



        '  rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") = "~*ADD*~"
        'rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("status") = status


        If Trim(rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("status")) = "" Then
            rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("status") = "Y"
            chkDelete.Checked = True
            If rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") <> "~*ADD*~" And _
                    rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") <> "~*DEL*~" And _
                    rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") <> "~*NEW*~" Then
                rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") = "~*DEL*~"
            ElseIf rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") = "~*ADD*~" Then
                rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") = "~*NEW*~"
            End If
        Else
            rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("status") = ""
            chkDelete.Checked = False
            If rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") = "~*ADD*~" Then
                rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") = "~*UPD*~"
            ElseIf rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") = "~*NEW*~" Then
                rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") = "~*ADD*~"
            ElseIf rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") = "~*DEL*~" Then
                rs_CUSHPMRK.Tables("RESULT").Rows(currentShipmark).Item("csm_creusr") = "~*UPD*~"
            End If
        End If

        rs_CUSHPMRK.Tables("RESULT").AcceptChanges()
    End Sub

    Private Sub del_relcus()
        If grdRelCus.RowCount > 0 Then
            Dim iCol As Integer = grdRelCus.CurrentCell.ColumnIndex
            Dim iRow As Integer = grdRelCus.CurrentCell.RowIndex



            Dim curvalue As String
            curvalue = grdRelCus.Item(grdRelCus_Status, iRow).Value
            If Trim(curvalue) = "" Then
                Dim i As Integer
                Dim counter As Integer
                counter = 0
                For i = 0 To grdRelCus.RowCount - 1
                    If Trim(grdRelCus.Item(grdRelCus_Status, i).Value) = "" Then
                        counter = counter + 1
                    End If
                Next i

                'If counter = 1 Then
                '    MsgBox("At least one color must exist!")
                '    Exit Sub
                'Else
                grdRelCus.Item(grdRelCus_Status, iRow).Value = "Y"
                If grdRelCus.Item(grdRelCus_csc_creusr, iRow).Value <> "~*ADD*~" And _
                grdRelCus.Item(grdRelCus_csc_creusr, iRow).Value <> "~*DEL*~" And _
                grdRelCus.Item(grdRelCus_csc_creusr, iRow).Value <> "~*NEW*~" Then
                    grdRelCus.Item(grdRelCus_csc_creusr, iRow).Value = "~*DEL*~"
                ElseIf grdRelCus.Item(grdRelCus_csc_creusr, iRow).Value = "~*ADD*~" Then
                    grdRelCus.Item(grdRelCus_csc_creusr, iRow).Value = "~*NEW*~"
                End If

            Else
                grdRelCus.Item(grdRelCus_Status, iRow).Value = ""
                If grdRelCus.Item(grdRelCus_csc_creusr, iRow).Value = "~*ADD*~" Then
                    grdRelCus.Item(grdRelCus_csc_creusr, iRow).Value = "~*UPD*~"
                ElseIf grdRelCus.Item(grdRelCus_csc_creusr, iRow).Value = "~*NEW*~" Then
                    grdRelCus.Item(grdRelCus_csc_creusr, iRow).Value = "~*ADD*~"
                ElseIf grdRelCus.Item(grdRelCus_csc_creusr, iRow).Value = "~*DEL*~" Then
                    grdRelCus.Item(grdRelCus_csc_creusr, iRow).Value = "~*UPD*~"
                End If
            End If
        End If
        rs_CUSUBCUS_P.Tables("RESULT").AcceptChanges()

    End Sub


    Private Sub del_courrier()
        If grdCourier.RowCount > 0 Then



            Dim iCol As Integer = grdCourier.CurrentCell.ColumnIndex
            Dim iRow As Integer = grdCourier.CurrentCell.RowIndex
            Dim curvalue As String
            curvalue = grdCourier.Item(grdCourier_Status, iRow).Value
            If Trim(curvalue) = "" Then
                Dim i As Integer
                Dim counter As Integer
                counter = 0
                For i = 0 To grdCourier.RowCount - 1
                    If Trim(grdCourier.Item(grdCourier_Status, i).Value) = "" Then
                        counter = counter + 1
                    End If
                Next i

                'If counter = 1 Then
                '    MsgBox("At least one color must exist!")
                '    Exit Sub
                'Else
                grdCourier.Item(grdCourier_Status, iRow).Value = "Y"
                If grdCourier.Item(grdCourier_csi_creusr, iRow).Value <> "~*ADD*~" And _
               grdCourier.Item(grdCourier_csi_creusr, iRow).Value <> "~*DEL*~" And _
               grdCourier.Item(grdCourier_csi_creusr, iRow).Value <> "~*NEW*~" Then
                    grdCourier.Item(grdCourier_csi_creusr, iRow).Value = "~*DEL*~"
                ElseIf grdCourier.Item(grdCourier_csi_creusr, iRow).Value = "~*ADD*~" Then
                    grdCourier.Item(grdCourier_csi_creusr, iRow).Value = "~*NEW*~"
                End If

            Else
                grdCourier.Item(grdCourier_Status, iRow).Value = ""
                If grdCourier.Item(grdCourier_csi_creusr, iRow).Value = "~*ADD*~" Then
                    grdCourier.Item(grdCourier_csi_creusr, iRow).Value = "~*UPD*~"
                ElseIf grdCourier.Item(grdCourier_csi_creusr, iRow).Value = "~*NEW*~" Then
                    grdCourier.Item(grdCourier_csi_creusr, iRow).Value = "~*ADD*~"
                ElseIf grdCourier.Item(grdCourier_csi_creusr, iRow).Value = "~*DEL*~" Then
                    grdCourier.Item(grdCourier_csi_creusr, iRow).Value = "~*UPD*~"

                End If
            End If
        End If
        rs_CUSHPINF_C.Tables("RESULT").AcceptChanges()
    End Sub

    Private Sub del_bank()
        If grdBank.RowCount > 0 Then



            Dim iCol As Integer = grdBank.CurrentCell.ColumnIndex
            Dim iRow As Integer = grdBank.CurrentCell.RowIndex
            Dim curvalue As String
            curvalue = grdBank.Item(grdBank_Status, iRow).Value
            If Trim(curvalue) = "" Then
                Dim i As Integer
                Dim counter As Integer
                counter = 0
                For i = 0 To grdBank.RowCount - 1
                    If Trim(grdBank.Item(grdBank_Status, i).Value) = "" Then
                        counter = counter + 1
                    End If
                Next i

                'If counter = 1 Then
                '    MsgBox("At least one color must exist!")
                '    Exit Sub
                'Else
                'toogood

                grdBank.Item(grdBank_Status, iRow).Value = "Y"
                If grdBank.Item(grdBank_csi_creusr, iRow).Value <> "~*ADD*~" And _
                 grdBank.Item(grdBank_csi_creusr, iRow).Value <> "~*DEL*~" And _
                 grdBank.Item(grdBank_csi_creusr, iRow).Value <> "~*NEW*~" Then
                    grdBank.Item(grdBank_csi_creusr, iRow).Value = "~*DEL*~"
                ElseIf grdBank.Item(grdBank_csi_creusr, iRow).Value = "~*ADD*~" Then
                    grdBank.Item(grdBank_csi_creusr, iRow).Value = "~*NEW*~"
                End If

            Else
                grdBank.Item(grdBank_Status, iRow).Value = ""
                If grdBank.Item(grdBank_csi_creusr, iRow).Value = "~*ADD*~" Then
                    grdBank.Item(grdBank_csi_creusr, iRow).Value = "~*UPD*~"
                ElseIf grdBank.Item(grdBank_csi_creusr, iRow).Value = "~*NEW*~" Then
                    grdBank.Item(grdBank_csi_creusr, iRow).Value = "~*ADD*~"

                ElseIf grdBank.Item(grdBank_csi_creusr, iRow).Value = "~*DEL*~" Then
                    grdBank.Item(grdBank_csi_creusr, iRow).Value = "~*UPD*~"
                End If
            End If
        End If
        rs_CUSHPINF_B.Tables("RESULT").AcceptChanges()
    End Sub
    Private Sub del_itmcatmarkup()
        If grdItmCatMarkup.RowCount > 0 Then



            Dim iCol As Integer = grdItmCatMarkup.CurrentCell.ColumnIndex
            Dim iRow As Integer = grdItmCatMarkup.CurrentCell.RowIndex
            Dim curvalue As String
            curvalue = grdItmCatMarkup.Item(grdItmCatMarkup_ocm_del, iRow).Value
            If Trim(curvalue) = "" Then
                Dim i As Integer
                Dim counter As Integer
                counter = 0
                For i = 0 To grdItmCatMarkup.RowCount - 1
                    If Trim(grdItmCatMarkup.Item(grdItmCatMarkup_ocm_del, i).Value) = "" Then
                        counter = counter + 1
                    End If
                Next i

                'If counter = 1 Then
                '    MsgBox("At least one color must exist!")
                '    Exit Sub
                'Else
                grdItmCatMarkup.Item(grdItmCatMarkup_ocm_del, iRow).Value = "Y"
                'End If
                If grdItmCatMarkup.Item(grdItmCatMarkup_ocm_creusr, iRow).Value <> "~*ADD*~" And _
                 grdItmCatMarkup.Item(grdItmCatMarkup_ocm_creusr, iRow).Value <> "~*DEL*~" And _
                 grdItmCatMarkup.Item(grdItmCatMarkup_ocm_creusr, iRow).Value <> "~*NEW*~" Then
                    grdItmCatMarkup.Item(grdItmCatMarkup_ocm_creusr, iRow).Value = "~*DEL*~"
                ElseIf grdItmCatMarkup.Item(grdItmCatMarkup_ocm_creusr, iRow).Value = "~*ADD*~" Then
                    grdItmCatMarkup.Item(grdItmCatMarkup_ocm_creusr, iRow).Value = "~*NEW*~"
                End If


            Else
                grdItmCatMarkup.Item(grdItmCatMarkup_ocm_del, iRow).Value = ""
                If grdItmCatMarkup.Item(grdItmCatMarkup_ocm_creusr, iRow).Value = "~*ADD*~" Then
                    grdItmCatMarkup.Item(grdItmCatMarkup_ocm_creusr, iRow).Value = "~*UPD*~"
                ElseIf grdItmCatMarkup.Item(grdItmCatMarkup_ocm_creusr, iRow).Value = "~*NEW*~" Then
                    grdItmCatMarkup.Item(grdItmCatMarkup_ocm_creusr, iRow).Value = "~*ADD*~"

                ElseIf grdItmCatMarkup.Item(grdItmCatMarkup_ocm_creusr, iRow).Value = "~*DEL*~" Then
                    grdItmCatMarkup.Item(grdItmCatMarkup_ocm_creusr, iRow).Value = "~*UPD*~"
                End If
            End If
        End If
        rs_CUMCAMRK.Tables("RESULT").AcceptChanges()
    End Sub


    Private Sub del_contact()
        If grdContact.RowCount > 0 Then

            Dim iCol As Integer = grdContact.CurrentCell.ColumnIndex
            Dim iRow As Integer = grdContact.CurrentCell.RowIndex


            'If grdContact.Rows(grdContact.CurrentCell.RowIndex).Cells("ccv_ventyp").Value.ToString = "" Then
            '    MsgBox("Please select type")
            '    Exit Sub
            'End If

            Dim curvalue As String
            curvalue = grdContact.Item(grdContact_Status, iRow).Value
            If Trim(curvalue) = "" Then


                'If counter = 1 Then
                '    MsgBox("At least one color must exist!")
                '    Exit Sub
                'Else
                Dim current As String = grdContact.Item(grdContact_cci_cnttyp, iRow).Value
                rs_CUCNTINF_C.Tables("RESULT").AcceptChanges()

                Dim dr() As DataRow
                dr = rs_CUCNTINF_C.Tables("RESULT").Select("cci_cnttyp = '" & current & "'")
                If dr.Length = 1 Then
                    If MsgBox("Are you sure to delete Default record?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                ElseIf dr.Length > 1 Then
                    If grdContact.Item(8, iRow).Value = "Y" Then
                        MsgBox("Please change default to other record")
                        Exit Sub
                    End If
                End If
                grdContact.Item(grdContact_Status, iRow).Value = "Y"

                If grdContact.Item(grdContact_cci_creusr, iRow).Value <> "~*ADD*~" And _
                grdContact.Item(grdContact_cci_creusr, iRow).Value <> "~*DEL*~" And _
                grdContact.Item(grdContact_cci_creusr, iRow).Value <> "~*NEW*~" Then
                    grdContact.Item(grdContact_cci_creusr, iRow).Value = "~*DEL*~"
                ElseIf grdContact.Item(grdContact_cci_creusr, iRow).Value = "~*ADD*~" Then
                    grdContact.Item(grdContact_cci_creusr, iRow).Value = "~*NEW*~"
                End If

                'End If

            Else

                grdContact.Item(grdContact_Status, iRow).Value = ""
                If grdContact.Item(grdContact_cci_creusr, iRow).Value = "~*ADD*~" Then
                    grdContact.Item(grdContact_cci_creusr, iRow).Value = "~*UPD*~"
                ElseIf grdContact.Item(grdContact_cci_creusr, iRow).Value = "~*NEW*~" Then
                    grdContact.Item(grdContact_cci_creusr, iRow).Value = "~*ADD*~"
                ElseIf grdContact.Item(grdContact_cci_creusr, iRow).Value = "~*DEL*~" Then
                    grdContact.Item(grdContact_cci_creusr, iRow).Value = "~*UPD*~"
                End If

            End If

        End If
        rs_CUCNTINF_C.Tables("RESULT").AcceptChanges()
    End Sub


    Private Sub Del_Shipping()
        If grdShipping.RowCount > 0 Then
            Dim iCol As Integer = grdShipping.CurrentCell.ColumnIndex
            Dim iRow As Integer = grdShipping.CurrentCell.RowIndex
            Dim curvalue As String
            curvalue = grdShipping.Item(grdShipping_Status, iRow).Value


            If Trim(curvalue) = "" Then
                Dim i As Integer
                Dim counter As Integer
                counter = 0
                For i = 0 To grdShipping.RowCount - 1
                    If Trim(grdShipping.Item(grdShipping_Status, i).Value) = "" Then
                        counter = counter + 1
                    End If
                Next i

                'If counter = 1 Then
                '    MsgBox("At least one color must exist!")
                '    Exit Sub
                'Else

                'End If

                If rs_CUCNTINF_S.Tables("RESULT").Rows.Count = 1 Then
                    If MsgBox("Are you sure to delete Default record?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                ElseIf rs_CUCNTINF_S.Tables("RESULT").Rows.Count > 1 Then
                    If grdShipping.Item(grdShipping_cci_cntdef, iRow).Value = "Y" Then
                        MsgBox("Please change default to other record")
                        Exit Sub
                    End If
                End If

                If grdShipping.Item(grdShipping_cci_creusr, iRow).Value <> "~*ADD*~" And _
                grdShipping.Item(grdShipping_cci_creusr, iRow).Value <> "~*DEL*~" And _
                grdShipping.Item(grdShipping_cci_creusr, iRow).Value <> "~*NEW*~" Then
                    grdShipping.Item(grdShipping_cci_creusr, iRow).Value = "~*DEL*~"
                ElseIf grdShipping.Item(grdShipping_cci_creusr, iRow).Value = "~*ADD*~" Then
                    grdShipping.Item(grdShipping_cci_creusr, iRow).Value = "~*NEW*~"
                End If
                grdShipping.Item(grdShipping_Status, iRow).Value = "Y"
            Else
                grdShipping.Item(grdShipping_Status, iRow).Value = ""
                If grdShipping.Item(grdShipping_cci_creusr, iRow).Value = "~*ADD*~" Then
                    grdShipping.Item(grdShipping_cci_creusr, iRow).Value = "~*UPD*~"
                ElseIf grdShipping.Item(grdShipping_cci_creusr, iRow).Value = "~*NEW*~" Then
                    grdShipping.Item(grdShipping_cci_creusr, iRow).Value = "~*ADD*~"
                ElseIf grdShipping.Item(grdShipping_cci_creusr, iRow).Value = "~*DEL*~" Then
                    grdShipping.Item(grdShipping_cci_creusr, iRow).Value = "~*UPD*~"
                End If
            End If
        End If
        rs_CUCNTINF_S.Tables("RESULT").AcceptChanges()
    End Sub


    Private Sub Del_Billing()
        If grdBilling.RowCount > 0 Then

            Dim iCol As Integer = grdBilling.CurrentCell.ColumnIndex
            Dim iRow As Integer = grdBilling.CurrentCell.RowIndex


            Dim curvalue As String
            curvalue = grdBilling.Item(grdBilling_Status, iRow).Value
            If Trim(curvalue) = "" Then
                Dim i As Integer
                Dim counter As Integer
                counter = 0
                For i = 0 To grdBilling.RowCount - 1
                    If Trim(grdBilling.Item(grdBilling_Status, i).Value) = "" Then
                        counter = counter + 1
                    End If
                Next i

                'If counter = 1 Then
                '    MsgBox("At least one color must exist!")
                '    Exit Sub
                'Else

                If rs_CUCNTINF_B.Tables("RESULT").Rows.Count = 1 Then
                    If MsgBox("Are you sure to delete Default Bill", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                ElseIf rs_CUCNTINF_B.Tables("RESULT").Rows.Count > 1 Then
                    If grdBilling.Item(grdBilling_cci_cntdef, iRow).Value = "Y" Then
                        MsgBox("Please change default to other record")
                        Exit Sub
                    End If
                End If

                grdBilling.Item(grdBilling_Status, iRow).Value = "Y"

                If grdBilling.Item(grdBilling_cci_creusr, iRow).Value <> "~*ADD*~" And _
               grdBilling.Item(grdBilling_cci_creusr, iRow).Value <> "~*DEL*~" And _
               grdBilling.Item(grdBilling_cci_creusr, iRow).Value <> "~*NEW*~" Then
                    grdBilling.Item(grdBilling_cci_creusr, iRow).Value = "~*DEL*~"
                ElseIf grdBilling.Item(grdBilling_cci_creusr, iRow).Value = "~*ADD*~" Then
                    grdBilling.Item(grdBilling_cci_creusr, iRow).Value = "~*NEW*~"
                End If

            Else
                grdBilling.Item(grdBilling_Status, iRow).Value = ""
                If grdBilling.Item(grdBilling_cci_creusr, iRow).Value = "~*ADD*~" Then
                    grdBilling.Item(grdBilling_cci_creusr, iRow).Value = "~*UPD*~"
                ElseIf grdBilling.Item(grdBilling_cci_creusr, iRow).Value = "~*NEW*~" Then
                    grdBilling.Item(grdBilling_cci_creusr, iRow).Value = "~*ADD*~"
                ElseIf grdBilling.Item(grdBilling_cci_creusr, iRow).Value = "~*DEL*~" Then
                    grdBilling.Item(grdBilling_cci_creusr, iRow).Value = "~*UPD*~"
                End If
            End If

        End If
        rs_CUCNTINF_B.Tables("RESULT").AcceptChanges()
    End Sub
    Private Sub Del_cusven()
        If grdCusVen.RowCount > 0 Then

            Dim iCol As Integer = grdCusVen.CurrentCell.ColumnIndex
            Dim iRow As Integer = grdCusVen.CurrentCell.RowIndex
            Dim curvalue As String
            curvalue = grdCusVen.Item(grdCusVen_Status, iRow).Value

            If Trim(curvalue) = "" Then
                Dim i As Integer
                Dim counter As Integer
                counter = 0
                For i = 0 To grdCusVen.RowCount - 1
                    If Trim(grdCusVen.Item(grdCusVen_Status, i).Value) = "" Then
                        counter = counter + 1
                    End If
                Next i

                'If counter = 1 Then
                '    MsgBox("At least one color must exist!")
                '    Exit Sub
                'Else
                grdCusVen.Item(grdCusVen_Status, iRow).Value = "Y"
                If grdCusVen.Item(grdcusven_cvi_creusr, iRow).Value <> "~*ADD*~" And _
                 grdCusVen.Item(grdcusven_cvi_creusr, iRow).Value <> "~*DEL*~" And _
                 grdCusVen.Item(grdcusven_cvi_creusr, iRow).Value <> "~*NEW*~" Then
                    grdCusVen.Item(grdcusven_cvi_creusr, iRow).Value = "~*DEL*~"
                ElseIf grdCusVen.Item(grdcusven_cvi_creusr, iRow).Value = "~*ADD*~" Then
                    grdCusVen.Item(grdcusven_cvi_creusr, iRow).Value = "~*NEW*~"
                End If


            Else
                grdCusVen.Item(grdCusVen_Status, iRow).Value = ""
                If grdCusVen.Item(grdcusven_cvi_creusr, iRow).Value = "~*ADD*~" Then
                    grdCusVen.Item(grdcusven_cvi_creusr, iRow).Value = "~*UPD*~"
                ElseIf grdCusVen.Item(grdcusven_cvi_creusr, iRow).Value = "~*NEW*~" Then
                    grdCusVen.Item(grdcusven_cvi_creusr, iRow).Value = "~*ADD*~"
                ElseIf grdCusVen.Item(grdcusven_cvi_creusr, iRow).Value = "~*DEL*~" Then
                    grdCusVen.Item(grdcusven_cvi_creusr, iRow).Value = "~*UPD*~"
                End If
            End If
        End If
        rs_CUVENINF.Tables("RESULT").AcceptChanges()
    End Sub
    Private Sub Del_Coven()
        If grdCoVen.RowCount > 0 Then

            Dim iCol As Integer = grdCoVen.CurrentCell.ColumnIndex
            Dim iRow As Integer = grdCoVen.CurrentCell.RowIndex


            If grdCoVen.Rows(grdCoVen.CurrentCell.RowIndex).Cells("ccv_ventyp").Value.ToString = "" Then
                MsgBox("Please select type")
                Exit Sub
            End If

            Dim curvalue As String
            curvalue = grdCoVen.Item(grdCoVen_del, iRow).Value
            If Trim(curvalue) = "" Then
                Dim i As Integer
                Dim counter As Integer
                counter = 0
                For i = 0 To grdCoVen.RowCount - 1
                    If Trim(grdCoVen.Item(grdCoVen_del, i).Value) = "" Then
                        counter = counter + 1
                    End If
                Next i

                'If counter = 1 Then
                '    MsgBox("At least one color must exist!")
                '    Exit Sub
                'Else

                rs_CUMCOVEN.Tables("RESULT").AcceptChanges()
                Dim current As String = grdCoVen.Item(grdCoVen_ccv_ventyp, iRow).Value
                Dim dr() As DataRow
                dr = rs_CUMCOVEN.Tables("RESULT").Select("ccv_ventyp = '" & current & "'")
                If dr.Length = 1 Then
                    If MsgBox("Are you sure to delete Default record", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                ElseIf dr.Length > 1 Then
                    If grdCoVen.Item(grdCoVen_ccv_vendef, iRow).Value = "Y" Then
                        MsgBox("Please change default to other record")
                        Exit Sub
                    End If
                End If
                grdCoVen.Item(grdCoVen_del, iRow).Value = "Y"

                If grdCoVen.Item(grdCoVen_ccv_creus, iRow).Value <> "~*ADD*~" And _
                grdCoVen.Item(grdCoVen_ccv_creus, iRow).Value <> "~*DEL*~" And _
                grdCoVen.Item(grdCoVen_ccv_creus, iRow).Value <> "~*NEW*~" Then
                    grdCoVen.Item(grdCoVen_ccv_creus, iRow).Value = "~*DEL*~"
                ElseIf grdCoVen.Item(grdCoVen_ccv_creus, iRow).Value = "~*ADD*~" Then
                    grdCoVen.Item(grdCoVen_ccv_creus, iRow).Value = "~*NEW*~"
                End If
            Else

                grdCoVen.Item(grdCoVen_del, iRow).Value = ""
                If grdCoVen.Item(grdCoVen_ccv_creus, iRow).Value = "~*ADD*~" Then
                    grdCoVen.Item(grdCoVen_ccv_creus, iRow).Value = "~*UPD*~"
                ElseIf grdCoVen.Item(grdCoVen_ccv_creus, iRow).Value = "~*NEW*~" Then
                    grdCoVen.Item(grdCoVen_ccv_creus, iRow).Value = "~*ADD*~"
                ElseIf grdCoVen.Item(grdCoVen_ccv_creus, iRow).Value = "~*DEL*~" Then
                    grdCoVen.Item(grdCoVen_ccv_creus, iRow).Value = "~*UPD*~"
                End If

            End If
        End If

        rs_CUMCOVEN.Tables("RESULT").AcceptChanges()
        'End If
    End Sub

    Private Sub Del_Agent()
        If grdAgent.RowCount > 0 Then

            Dim iCol As Integer = grdAgent.CurrentCell.ColumnIndex
            Dim iRow As Integer = grdAgent.CurrentCell.RowIndex


            If grdAgent.Rows(grdAgent.CurrentCell.RowIndex).Cells("cai_cusagt").Value.ToString = "" Then
                MsgBox("Please select type")
                Exit Sub
            End If

            Dim curvalue As String
            curvalue = grdAgent.Item(grdAgent_Status, iRow).Value
            If Trim(curvalue) = "" Then
                Dim i As Integer
                Dim counter As Integer
                counter = 0
                For i = 0 To grdAgent.RowCount - 1
                    If Trim(grdAgent.Item(grdAgent_Status, i).Value) = "" Then
                        counter = counter + 1
                    End If
                Next i

                'If counter = 1 Then
                '    MsgBox("At least one color must exist!")
                '    Exit Sub
                'Else
                rs_CUAGTINF.Tables("RESULT").AcceptChanges()
                If rs_CUAGTINF.Tables("RESULT").Rows.Count = 1 Then
                    If MsgBox("Are you sure to delete Default Agent", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                ElseIf rs_CUAGTINF.Tables("RESULT").Rows.Count > 1 Then
                    If grdAgent.Item(grdAgent_cai_cusdef, iRow).Value = "Y" Then
                        MsgBox("Please change default to other record")
                        Exit Sub
                    End If
                End If



                grdAgent.Item(grdAgent_Status, iRow).Value = "Y"
                If grdAgent.Item(grdAgent_cai_creusr, iRow).Value <> "~*ADD*~" And _
                grdAgent.Item(grdAgent_cai_creusr, iRow).Value <> "~*DEL*~" And _
                grdAgent.Item(grdAgent_cai_creusr, iRow).Value <> "~*NEW*~" Then
                    grdAgent.Item(grdAgent_cai_creusr, iRow).Value = "~*DEL*~"
                ElseIf grdAgent.Item(grdAgent_cai_creusr, iRow).Value = "~*ADD*~" Then
                    grdAgent.Item(grdAgent_cai_creusr, iRow).Value = "~*NEW*~"
                End If

            Else
                grdAgent.Item(grdAgent_Status, iRow).Value = ""
                If grdAgent.Item(grdAgent_cai_creusr, iRow).Value = "~*ADD*~" Then
                    grdAgent.Item(grdAgent_cai_creusr, iRow).Value = "~*UPD*~"
                ElseIf grdAgent.Item(grdAgent_cai_creusr, iRow).Value = "~*NEW*~" Then
                    grdAgent.Item(grdAgent_cai_creusr, iRow).Value = "~*ADD*~"
                ElseIf grdAgent.Item(grdAgent_cai_creusr, iRow).Value = "~*DEL*~" Then
                    grdAgent.Item(grdAgent_cai_creusr, iRow).Value = "~*UPD*~"
                End If


            End If
        End If
        rs_CUAGTINF.Tables("RESULT").AcceptChanges()

    End Sub
    Private Sub grdContactCells_KeyPress(ByVal sender As System.Object, ByVal e As KeyPressEventArgs)
        '判断当前列是不是要控制的列
        If grdContact.CurrentCellAddress.X = grdContact_cci_cntfax Or grdContact.CurrentCellAddress.X = grdContact_cci_cntphn Then
            If ((Convert.ToInt32(e.KeyChar) < 48 Or Convert.ToInt32(e.KeyChar) > 57) And Convert.ToInt32(e.KeyChar) <> 46 And Convert.ToInt32(e.KeyChar) <> 8 And Convert.ToInt32(e.KeyChar) <> 13 _
                And Convert.ToInt32(e.KeyChar) <> 40 And Convert.ToInt32(e.KeyChar) <> 41 And Convert.ToInt32(e.KeyChar) <> 32 And Convert.ToInt32(e.KeyChar) <> 45) Then
                '输入非法就屏蔽
                e.Handled = True
            End If
        Else
            If Convert.ToInt32(e.KeyChar) = 46 Then
                'e.Handled = True 'cancel at 07/07/2014
            End If
        End If
    End Sub
    Private Sub grdBankCells_KeyPress(ByVal sender As System.Object, ByVal e As KeyPressEventArgs)
        '判断当前列是不是要控制的列
        If grdBank.CurrentCellAddress.X = grdBank_csi_csefax Or grdBank.CurrentCellAddress.X = grdBank_csi_csephn Then
            If ((Convert.ToInt32(e.KeyChar) < 48 Or Convert.ToInt32(e.KeyChar) > 57) And Convert.ToInt32(e.KeyChar) <> 46 And Convert.ToInt32(e.KeyChar) <> 8 And Convert.ToInt32(e.KeyChar) <> 13 _
                And Convert.ToInt32(e.KeyChar) <> 40 And Convert.ToInt32(e.KeyChar) <> 41 And Convert.ToInt32(e.KeyChar) <> 32 And Convert.ToInt32(e.KeyChar) <> 45) Then
                '输入非法就屏蔽
                e.Handled = True
            End If
        Else
            If Convert.ToInt32(e.KeyChar) = 46 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub grdCourierCells_KeyPress(ByVal sender As System.Object, ByVal e As KeyPressEventArgs)
        '判断当前列是不是要控制的列
        If grdCourier.CurrentCellAddress.X = grdCourier_csi_csefax Or grdCourier.CurrentCellAddress.X = grdCourier_csi_csephn Then
            If ((Convert.ToInt32(e.KeyChar) < 48 Or Convert.ToInt32(e.KeyChar) > 57) And Convert.ToInt32(e.KeyChar) <> 46 And Convert.ToInt32(e.KeyChar) <> 8 And Convert.ToInt32(e.KeyChar) <> 13 _
                And Convert.ToInt32(e.KeyChar) <> 40 And Convert.ToInt32(e.KeyChar) <> 41 And Convert.ToInt32(e.KeyChar) <> 32 And Convert.ToInt32(e.KeyChar) <> 45) Then
                '输入非法就屏蔽
                e.Handled = True
            End If
        Else
            If Convert.ToInt32(e.KeyChar) = 46 Then
                e.Handled = True
            End If
        End If
    End Sub

  
    Private Sub grdRelCus_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdRelCus.CellEndEdit
        


    End Sub

    Private Sub lstCustomer_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstCustomer.DoubleClick
        lstCustomer.Visible = False
        Dim cusno As String
        Dim cusnam As String
        cusno = Split(lstCustomer.Text, " - ")(0)
        cusnam = Split(lstCustomer.Text, " - ")(1)
        'If Me.cboFCurr.Text = "CNY" Then
        If optPriCus.Checked = True Then
            rs_CUSUBCUS_P.Tables("RESULT").Rows(lstrowindex).Item("csc_seccus") = cusno
            rs_CUSUBCUS_P.Tables("RESULT").Rows(lstrowindex).Item("cbi_cusnam") = cusnam
        ElseIf optSecCus.Checked = True Then
            rs_CUSUBCUS_P.Tables("RESULT").Rows(lstrowindex).Item("csc_prmcus") = cusno
            rs_CUSUBCUS_P.Tables("RESULT").Rows(lstrowindex).Item("cbi_cusnam") = cusnam
        End If

        checkRelcus()

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
    Private Sub checkRelcus()
        If grdRelCus.RowCount = 0 Then
            Exit Sub
        End If
        'do
        Dim code As String = Trim(grdRelCus.Item(grdRelCus_csc_seccus, grdRelCus.CurrentCell.RowIndex).Value.ToString)






        rs_CUSUBCUS_P.Tables("RESULT").AcceptChanges()
        If code <> "" Then
            If optPriCus.Checked = True Then
                Dim drr() As DataRow = rs_CUSUBCUS_P.Tables("RESULT").Select("csc_seccus = '" & code & "'")

                If drr.Length > 1 Then

                    MsgBox("Duplicate record")
                    grdRelCus.Item(grdRelCus_csc_seccus, lstrowindex).Value = ""
                    grdRelCus.Item(grdRelCus_cbi_cusnam, lstrowindex).Value = ""


                End If
            ElseIf optSecCus.Checked = True Then
                Dim drr() As DataRow = rs_CUSUBCUS_P.Tables("RESULT").Select("csc_prmcus = '" & code & "'")

                If drr.Length > 1 Then

                    MsgBox("Duplicate record")
                    grdRelCus.Item(grdRelCus_csc_seccus, lstrowindex).Value = ""
                    grdRelCus.Item(grdRelCus_cbi_cusnam, lstrowindex).Value = ""


                End If


            End If
        End If
    End Sub

    Private Sub lstCustomer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lstCustomer.KeyPress
        Try

            Dim ipos As Integer
            Dim strSearch As String = ""

            lstCustomer.SelectionMode = SelectionMode.One
            lstCustomer.ClearSelected()

            If Not lstCustomer.Tag Is Nothing Then
                If Convert.ToInt16(e.KeyChar) <> 8 Then
                    strSearch = lstCustomer.Tag.ToString() + e.KeyChar.ToString()
                Else
                    strSearch = lstCustomer.Tag.ToString()
                    If strSearch.Length >= 1 Then
                        strSearch = strSearch.Substring(0, strSearch.Length - 1)
                    End If
                End If
            Else
                If Convert.ToInt16(e.KeyChar) <> 8 Then
                    strSearch = strSearch + e.KeyChar.ToString()
                End If

                If strSearch.Length >= 1 Then
                    If Convert.ToInt16(e.KeyChar) = 8 Then
                        strSearch = strSearch.Substring(0, strSearch.Length - 1)
                    End If
                End If
            End If

            Dim str As String
            For Each str In lstCustomer.Items
                If str.Length >= strSearch.Length Then
                    If str.Substring(0, strSearch.Length).ToUpper() = strSearch.ToUpper() Then
                        lstCustomer.SelectedItem = str
                        lstCustomer.Tag = strSearch
                        Return
                    End If
                End If
            Next


            If str.Substring(0, strSearch.Length).ToUpper() = strSearch.ToUpper() Then
                lstCustomer.SelectedItem = str
                lstCustomer.Tag = strSearch
            Else

                strSearch = ""

            End If




            lstCustomer.Tag = strSearch
            lstCustomer.Text = strSearch
        Catch ex As Exception
        Finally

        End Try

    End Sub

    
   
   

    Private Sub lstCustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstCustomer.SelectedIndexChanged

    End Sub

    Private Sub grdRelCus_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdRelCus.CellValidated
        'If grdRelCus.RowCount = 0 Then
        '    Exit Sub
        'End If
        ''do
        'Dim code As String = Trim(grdRelCus.Item(grdRelCus_csc_seccus, grdRelCus.CurrentCell.RowIndex).Value.ToString)

        'Dim currentrow As Integer = grdRelCus.CurrentCell.RowIndex




        'rs_CUSUBCUS_P.Tables("RESULT").AcceptChanges()
        'If code <> "" Then
        '    Dim drr() As DataRow = rs_CUSUBCUS_P.Tables("RESULT").Select("csc_seccus = '" & code & "'")

        '    If drr.Length > 1 Then

        '        MsgBox("Duplicate Vendor type and Company record")
        '        grdRelCus.Item(grdRelCus_csc_seccus, currentrow).Value = ""
        '        grdRelCus.Item(grdRelCus_cbi_cusnam, currentrow).Value = ""


        '    End If

        'End If
    End Sub

    Private Sub grdShipping_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdShipping.CellContentClick

    End Sub

    Private Sub cboSalTem_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSalTem.Enter
        CustRepChange = True
    End Sub

    Private Sub cboSalTem_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSalTem.GotFocus
        CustRepChange = True
    End Sub

    Private Sub cboSalTem_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSalTem.KeyUp
        auto_search_combo(cboSalTem, e.KeyCode)
    End Sub

    

    Private Sub cboSalTem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSalTem.SelectedIndexChanged
        Recordstatus = True


        If CustRepChange = True Then



            'CustRepChange = False
            'CustConfirmChange = True


            If Trim(cboSalTem.Text) = "" Then
                Exit Sub
            End If

            If checkValidCombo(cboSalTem, cboSalTem.Text) = False Then
                MsgBox("Data Invalid")
                cboSalTem.Text = ""
                Exit Sub
            End If


            If cboSalTem.Text = "" Then
                Exit Sub
            End If



            Dim userid As String
            Dim i As Integer
            Try
                Dim test As String = Split(cboSalTem.Text, " - ")(1)
                If cboSalTem.Text <> "" Then
                    If cboSalTem.SelectedIndex = -1 Then
                        MsgBox("Data Invalid")
                        txtSalMgt.Text = ""
                        Exit Sub
                    End If
                End If
            Catch ex As Exception
                MsgBox("Data invalid")
                txtSalMgt.Text = ""
                Exit Sub
            End Try


            'If CustConfirmChange = True Then
            '    CustConfirmChange = False
            If cboSalTem.Text <> "" Then
                If Split(cboSalTem.Text, " - ")(1) <> "" Then

                    gspStr = "sp_list_SYUSRPRF_2 '','" & Split(cboSalTem.Text, " - ")(0) & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs_SYUSRPRF_2, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading cboSalTem_Validated sp_list_SYUSRPRF_2 :" & rtnStr)
                        Me.Cursor = Cursors.Default

                        Exit Sub
                    End If





                End If

                If Not rs_SYUSRPRF_2.Tables("RESULT").Rows.Count = 0 Then
                    txtSalMgt.Text = ""
                    txtSalDiv.Text = ""
                    cboSalRep.Text = ""
                    cboSalRep.Items.Clear()

                    For i = 0 To rs_SYUSRPRF_2.Tables("RESULT").Rows.Count - 1
                        cboSalRep.Items.Add(rs_SYUSRPRF_2.Tables("RESULT").Rows(i).Item("ssr_salrep") + " - " + rs_SYUSRPRF_2.Tables("RESULT").Rows(i).Item("yup_repnam"))
                        'txtSalMgt.Text = UCase(rs_SYSALMGR.Tables("RESULT").Rows(0).Item("yup_usrnam"))
                    Next i
                    cboSalRep.SelectedIndex = 0
                    txtSalMgt.Text = UCase(rs_SYUSRPRF_2.Tables("RESULT").Rows(0).Item("yup_mgrnam"))
                    txtSalDiv.Text = rs_SYUSRPRF_2.Tables("RESULT").Rows(0).Item("ssr_saldiv") + " - Division " + rs_SYUSRPRF_2.Tables("RESULT").Rows(0).Item("ssr_saldiv").ToString
                End If


                'End If
            End If


        End If



    End Sub

    Private Sub grdPrctrm_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdPrctrm.CellClick
        If grdPrctrm.RowCount = 0 Then
            Exit Sub
        End If
        If cboStatus.Text <> "A - Active" Then
            Exit Sub
        End If



        Select Case grdPrctrm.CurrentCell.ColumnIndex
            Case grdPrctrm_cpt_prctrm

                If grdPrctrm.Rows(grdPrctrm.CurrentCell.RowIndex).Cells("cpt_creusr").Value.ToString <> "~*ADD*~" Then
                    Exit Sub
                End If


                comboBoxCell(grdPrctrm, "PrcTrm")


        End Select
    End Sub


    Private Sub grdPrctrm_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdPrctrm.CellDoubleClick
        If cboStatus.Text <> "A - Active" Then
            Exit Sub

        End If
        If e.RowIndex = -1 Then
            Exit Sub
        End If

        If grdPrctrm.RowCount > 0 Then

            Dim icol As Integer = grdPrctrm.CurrentCell.ColumnIndex
            Dim irow As Integer = grdPrctrm.CurrentCell.RowIndex

            If grdPrctrm.CurrentCell.ColumnIndex = grdPrctrm_cpt_cocde And e.RowIndex >= 0 Then
                If grdPrctrm.Rows(grdPrctrm.CurrentCell.RowIndex).Cells("cpt_prctrm").Value.ToString = "" Then
                    MsgBox("Please select type")
                    Exit Sub
                End If

                Dim curvalue As String
                curvalue = grdPrctrm.CurrentCell.Value
                If Trim(curvalue) = "" Then
                    

                    rs_CUPRCTRM.Tables("RESULT").AcceptChanges()
                    If rs_CUPRCTRM.Tables("RESULT").Rows.Count = 1 Then
                        If MsgBox("Are you sure to delete Default record?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                            Exit Sub
                        End If
                    ElseIf rs_CUPRCTRM.Tables("RESULT").Rows.Count > 1 Then
                        If grdPrctrm.Item(grdPrctrm_cpt_prcdef, irow).Value = "Y" Then
                            MsgBox("Please change default to other record")
                            Exit Sub
                        End If
                    End If



                    grdPrctrm.Item(grdPrctrm_cpt_cocde, irow).Value = "Y"
                    If grdPrctrm.Item(grdPrctrm_cpt_creusr, irow).Value <> "~*ADD*~" And _
                    grdPrctrm.Item(grdPrctrm_cpt_creusr, irow).Value <> "~*DEL*~" And _
                    grdPrctrm.Item(grdPrctrm_cpt_creusr, irow).Value <> "~*NEW*~" Then
                        grdPrctrm.Item(grdPrctrm_cpt_creusr, irow).Value = "~*DEL*~"
                    ElseIf grdPrctrm.Item(grdPrctrm_cpt_creusr, irow).Value = "~*ADD*~" Then
                        grdPrctrm.Item(grdPrctrm_cpt_creusr, irow).Value = "~*NEW*~"
                    End If

                Else
                    grdPrctrm.Item(grdPrctrm_cpt_cocde, irow).Value = ""
                    If grdPrctrm.Item(grdPrctrm_cpt_creusr, irow).Value = "~*ADD*~" Then
                        grdPrctrm.Item(grdPrctrm_cpt_creusr, irow).Value = "~*UPD*~"
                    ElseIf grdPrctrm.Item(grdPrctrm_cpt_creusr, irow).Value = "~*NEW*~" Then
                        grdPrctrm.Item(grdPrctrm_cpt_creusr, irow).Value = "~*ADD*~"
                    ElseIf grdPrctrm.Item(grdPrctrm_cpt_creusr, irow).Value = "~*DEL*~" Then
                        grdPrctrm.Item(grdPrctrm_cpt_creusr, irow).Value = "~*UPD*~"
                    End If

                End If

            ElseIf grdPrctrm.CurrentCell.ColumnIndex = grdPrctrm_cpt_prcdef And e.RowIndex >= 0 Then

                changeDefaultPrctrm()


            End If


            If grdPrctrm.Item(grdPrctrm_cpt_creusr, irow).Value <> "~*ADD*~" And _
             grdPrctrm.Item(grdPrctrm_cpt_creusr, irow).Value <> "~*NEW*~" And _
              grdPrctrm.Item(grdPrctrm_cpt_creusr, irow).Value <> "~*DEL*~" Then
                grdPrctrm.Item(grdPrctrm_cpt_creusr, irow).Value = "~*UPD*~"
                Recordstatus = True
            End If

        End If



    End Sub

    Private Sub grdPrctrm_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdPrctrm.CellEndEdit
        If grdPrctrm.RowCount = 0 Then
            Exit Sub
        End If
        'do
        Dim Value As String = Trim(grdPrctrm.Item(grdPrctrm_cpt_prctrm, grdPrctrm.CurrentCell.RowIndex).Value.ToString)

        Dim currentrow As Integer = grdPrctrm.CurrentCell.RowIndex

        grdPrctrm.Columns(grdPrctrm_cpt_prctrm).ReadOnly = True

        rs_CUPRCTRM.Tables("RESULT").AcceptChanges()
        If Value <> "" Then
            Dim drr() As DataRow = rs_CUPRCTRM.Tables("RESULT").Select("cpt_prctrm = '" & Value & "'")

            If drr.Length > 1 Then

                MsgBox("Duplicate record")
                grdPrctrm.Item(grdPrctrm_cpt_prctrm, currentrow).Value = ""



            End If

        End If


    End Sub

    Private Sub grdPrctrm_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdPrctrm.EditingControlShowing
        If grdPrctrm.RowCount = 0 Then
            Exit Sub
        End If

        If cboStatus.Text <> "A - Active" Then
            Exit Sub
        End If


        e.CellStyle.BackColor = Color.White

        Select Case grdPrctrm.CurrentCell.ColumnIndex
            Case grdPrctrm_cpt_prctrm
                If TypeOf (e.Control) Is DataGridViewComboBoxEditingControl Then
                    Dim cboBox As ComboBox = CType(e.Control, ComboBox)
                    If Not cboBox Is Nothing Then
                        'RemoveHandler cboBox.SelectedIndexChanged, AddressOf cbo_dgCostPrice_SelectedIndexChanged
                        'AddHandler cboBox.SelectedIndexChanged, AddressOf cbo_dgCostPrice_SelectedIndexChanged
                    End If
                End If

        End Select


        'If mode = "UPDATE" Or mode = "ADD" Then
        Recordstatus = True
        If grdPrctrm.Item(grdPrctrm_cpt_creusr, grdPrctrm.CurrentCell.RowIndex).Value <> "~*ADD*~" And _
        grdPrctrm.Item(grdPrctrm_cpt_creusr, grdPrctrm.CurrentCell.RowIndex).Value <> "~*UPD*~" And _
        grdPrctrm.Item(grdPrctrm_cpt_creusr, grdPrctrm.CurrentCell.RowIndex).Value <> "~*DEL*~" And _
        grdPrctrm.Item(grdPrctrm_cpt_creusr, grdPrctrm.CurrentCell.RowIndex).Value <> "~*NEW*~" Then ''creusr or upusr?
            grdPrctrm.Item(grdPrctrm_cpt_creusr, grdPrctrm.CurrentCell.RowIndex).Value = "~*UPD*~"
        End If
    End Sub

    Private Sub grdPrctrm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdPrctrm.GotFocus
        Got_Focus_Grid = "Prctrm"
    End Sub

    Private Sub cboIntGrp_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboIntGrp.KeyUp
        auto_search_combo(cboIntGrp, e.KeyCode)
    End Sub

    Private Sub cboIntGrp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIntGrp.LostFocus
       
    End Sub

    Private Sub cboIntGrp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboIntGrp.SelectedIndexChanged
        Recordstatus = True
    End Sub

    Private Sub cboExtGrp_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboExtGrp.KeyUp
        auto_search_combo(cboExtGrp, e.KeyCode)
    End Sub

    Private Sub cboExtGrp_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboExtGrp.LostFocus

    End Sub

    Private Sub cboExtGrp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboExtGrp.SelectedIndexChanged
        Recordstatus = True
    End Sub

    Private Sub cboMrkTyp_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMrkTyp.Validated

        If Trim(cboMrkTyp.Text) = "" Then
            Exit Sub
        End If

        If checkValidCombo(cboMrkTyp, cboMrkTyp.Text) = False Then
            MsgBox("Data Invalid")
            cboMrkTyp.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub cboMrkReg_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMrkReg.Validated
        If Trim(cboMrkReg.Text) = "" Then
            Exit Sub
        End If

        If checkValidCombo(cboMrkReg, cboMrkReg.Text) = False Then
            MsgBox("Data Invalid")
            cboMrkReg.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub cboCusRat_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCusRat.Validated
        If Trim(cboCusRat.Text) = "" Then
            Exit Sub
        End If

        If checkValidCombo(cboCusRat, cboCusRat.Text) = False Then
            MsgBox("Data Invalid")
            cboCusRat.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub cboSalRep_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSalRep.Validated
        If Trim(cboSalRep.Text) = "" Then
            Exit Sub
        End If

        If checkValidCombo(cboSalRep, cboSalRep.Text) = False Then
            MsgBox("Data Invalid")
            cboSalRep.Text = ""
            Exit Sub
        End If

    End Sub

    Private Sub cboSalTem_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSalTem.Validated
        CustRepChange = False
        CustConfirmChange = True
        'If Trim(cboSalTem.Text) = "" Then
        '    Exit Sub
        'End If

        'If checkValidCombo(cboSalTem, cboSalTem.Text) = False Then
        '    MsgBox("Data Invalid")
        '    cboSalTem.Text = ""
        '    Exit Sub
        'End If


        'If cboSalTem.Text = "" Then
        '    Exit Sub
        'End If



        'Dim userid As String
        'Dim i As Integer
        'Try
        '    Dim test As String = Split(cboSalTem.Text, " - ")(1)
        '    If cboSalTem.Text <> "" Then
        '        If cboSalTem.SelectedIndex = -1 Then
        '            MsgBox("Data Invalid")
        '            txtSalMgt.Text = ""
        '            Exit Sub
        '        End If
        '    End If
        'Catch ex As Exception
        '    MsgBox("Data invalid")
        '    txtSalMgt.Text = ""
        '    Exit Sub
        'End Try


        'If CustConfirmChange = True Then
        '    CustConfirmChange = False
        '    If cboSalTem.Text <> "" Then
        '        If Split(cboSalTem.Text, " - ")(1) <> "" Then

        '            gspStr = "sp_list_SYUSRPRF_2 '','" & Split(cboSalTem.Text, " - ")(0) & "'"
        '            rtnLong = execute_SQLStatement(gspStr, rs_SYUSRPRF_2, rtnStr)
        '            If rtnLong <> RC_SUCCESS Then
        '                MsgBox("Error on loading cboSalTem_Validated sp_list_SYUSRPRF_2 :" & rtnStr)
        '                Me.Cursor = Cursors.Default

        '                Exit Sub
        '            End If





        '        End If

        '        If Not rs_SYUSRPRF_2.Tables("RESULT").Rows.Count = 0 Then
        '            txtSalMgt.Text = ""
        '            txtSalDiv.Text = ""
        '            cboSalRep.Text = ""
        '            cboSalRep.Items.Clear()

        '            For i = 0 To rs_SYUSRPRF_2.Tables("RESULT").Rows.Count - 1
        '                cboSalRep.Items.Add(rs_SYUSRPRF_2.Tables("RESULT").Rows(i).Item("ssr_salrep") + " - " + rs_SYUSRPRF_2.Tables("RESULT").Rows(i).Item("yup_repnam"))
        '                'txtSalMgt.Text = UCase(rs_SYSALMGR.Tables("RESULT").Rows(0).Item("yup_usrnam"))
        '            Next i
        '            cboSalRep.SelectedIndex = 0
        '            txtSalMgt.Text = UCase(rs_SYUSRPRF_2.Tables("RESULT").Rows(0).Item("yup_mgrnam"))
        '            txtSalDiv.Text = rs_SYUSRPRF_2.Tables("RESULT").Rows(0).Item("ssr_saldiv") + " - Division " + rs_SYUSRPRF_2.Tables("RESULT").Rows(0).Item("ssr_saldiv").ToString
        '        End If


        '    End If
        'End If
    End Sub

    Private Sub cboIntGrp_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIntGrp.Validated
        If Trim(cboIntGrp.Text) = "" Then
            Exit Sub
        End If

        If checkValidCombo(cboIntGrp, cboIntGrp.Text) = False Then
            MsgBox("Data Invalid")
            cboIntGrp.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub cboExtGrp_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboExtGrp.Validated

        If Trim(cboExtGrp.Text) = "" Then
            Exit Sub
        End If

        If checkValidCombo(cboExtGrp, cboExtGrp.Text) = False Then
            MsgBox("Data Invalid")
            cboExtGrp.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub cboCountry_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCountry.Validated

        If Trim(cboCountry.Text) = "" Then
            Exit Sub
        End If

        If checkValidCombo(cboCountry, cboCountry.Text) = False Then
            MsgBox("Data Invalid")
            cboCountry.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub cboPayTrm_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPayTrm.Validated
        If Trim(cboPayTrm.Text) = "" Then
            Exit Sub
        End If

        If checkValidCombo(cboPayTrm, cboPayTrm.Text) = False Then
            MsgBox("Data Invalid")
            cboPayTrm.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub cboProTrm_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProTrm.Validated
        If Trim(cboProTrm.Text) = "" Then
            Exit Sub
        End If

        If checkValidCombo(cboProTrm, cboProTrm.Text) = False Then
            MsgBox("Data Invalid")
            cboProTrm.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub cboFrgTrm_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFrgTrm.Validated
        If Trim(cboFrgTrm.Text) = "" Then
            Exit Sub
        End If

        If checkValidCombo(cboFrgTrm, cboFrgTrm.Text) = False Then
            MsgBox("Data Invalid")
            cboFrgTrm.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub cboCurcde_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCurcde.Validated
        If Trim(cboCurcde.Text) = "" Then
            Exit Sub
        End If

        If checkValidCombo(cboCurcde, cboCurcde.Text) = False Then
            MsgBox("Data Invalid")
            cboCurcde.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub cboCUCALFMLKey_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCUCALFMLKey.SelectedIndexChanged
        If rs_CUCALFML.Tables("RESULT").Rows.Count > 0 Then
            Dim tmp_cat As String
            Dim tmp_ven As String
            Dim tmp_prctrm As String
            Dim tmp_trantrm As String

            tmp_cat = Split(cboCUCALFMLKey.Text, " / ")(0)
            tmp_ven = Split(cboCUCALFMLKey.Text, " / ")(1)
            tmp_prctrm = Split(cboCUCALFMLKey.Text, " / ")(2)
            tmp_trantrm = Split(cboCUCALFMLKey.Text, " / ")(3)

            Dim dr() As DataRow
            dr = rs_CUCALFML.Tables("RESULT").Select("ccf_latest = 'Y' and ccf_cat = '" & tmp_cat & "' and ccf_venno = '" & tmp_ven & "' and ccf_prctrm = '" & tmp_prctrm & "' and ccf_trantrm = '" & tmp_trantrm & "'")
        
            If dr.Length >= 1 Then
                txtCustMU.Text = dr(0).Item("ccf_cumu")
                txtPM.Text = dr(0).Item("ccf_pm")
                txtCush.Text = dr(0).Item("ccf_cush")

                txtTHC.Text = dr(0).Item("ccf_thccusper")
                txtUPS.Text = dr(0).Item("ccf_upsper")
                txtLab.Text = dr(0).Item("ccf_labper")
                txtFA.Text = dr(0).Item("ccf_faper")
                txtCostBuf.Text = dr(0).Item("ccf_cstbufper")
                txtOthers.Text = dr(0).Item("ccf_othper")
                txtPLI.Text = dr(0).Item("ccf_pliper")
                txtDefMD.Text = dr(0).Item("ccf_dmdper")
                txtRebate.Text = dr(0).Item("ccf_rbtper")

                txtSubTtl.Text = dr(0).Item("ccf_subttl")
                txtComm.Text = dr(0).Item("ccf_comper")
            End If
        End If
    End Sub

    Private Sub MarkCustomerUpdate()
        If cmdAddPri.Text = "A" Then
            Exit Sub
        End If

      


        If Trim(txtCustMU.Text) = "" Then
            MsgBox("Please input value")
            Me.BaseTabControl1.SelectedIndex = 4
            txtCustMU.Focus()
            Exit Sub
        End If

        If Trim(txtPM.Text) = "" Then
            MsgBox("Please input value")
            Me.BaseTabControl1.SelectedIndex = 4
            txtPM.Focus()
            Exit Sub
        End If

        If Trim(txtTHC.Text) = "" Then
            MsgBox("Please input value")
            Me.BaseTabControl1.SelectedIndex = 4
            txtTHC.Focus()
            Exit Sub
        End If

        If Trim(txtUPS.Text) = "" Then
            MsgBox("Please input value")
            Me.BaseTabControl1.SelectedIndex = 4
            txtUPS.Focus()
            Exit Sub
        End If

        If Trim(txtLab.Text) = "" Then
            MsgBox("Please input value")
            Me.BaseTabControl1.SelectedIndex = 4
            txtLab.Focus()
            Exit Sub
        End If

        If Trim(txtFA.Text) = "" Then
            MsgBox("Please input value")
            Me.BaseTabControl1.SelectedIndex = 4
            txtFA.Focus()
            Exit Sub
        End If

        If Trim(txtCostBuf.Text) = "" Then
            MsgBox("Please input value")
            Me.BaseTabControl1.SelectedIndex = 4
            txtCostBuf.Focus()
            Exit Sub
        End If

        If Trim(txtOthers.Text) = "" Then
            MsgBox("Please input value")
            Me.BaseTabControl1.SelectedIndex = 4
            txtOthers.Focus()
            Exit Sub
        End If

        If Trim(txtPLI.Text) = "" Then
            MsgBox("Please input value")
            Me.BaseTabControl1.SelectedIndex = 4
            txtPLI.Focus()
            Exit Sub
        End If

        If Trim(txtDefMD.Text) = "" Then
            MsgBox("Please input value")
            Me.BaseTabControl1.SelectedIndex = 4
            txtDefMD.Focus()
            Exit Sub
        End If

        If Trim(txtRebate.Text) = "" Then
            MsgBox("Please input value")
            Me.BaseTabControl1.SelectedIndex = 4
            txtRebate.Focus()
            Exit Sub
        End If

        If Trim(txtCush.Text) = "" Then
            MsgBox("Please input value")
            Me.BaseTabControl1.SelectedIndex = 4
            txtCush.Focus()
            Exit Sub
        End If

        If Trim(txtComm.Text) = "" Then
            MsgBox("Please input value")
            Me.BaseTabControl1.SelectedIndex = 4
            txtCush.Focus()
            Exit Sub
        End If





        Dim tmp_cat As String
        Dim tmp_ven As String
        Dim tmp_prctrm As String
        Dim tmp_trantrm As String
        Dim tmp_effdat As DateTime

        tmp_cat = Split(txtCubasfmltxt.Text, " / ")(0)
        tmp_ven = Split(txtCubasfmltxt.Text, " / ")(1)
        tmp_prctrm = Split(txtCubasfmltxt.Text, " / ")(2)
        tmp_trantrm = Split(txtCubasfmltxt.Text, " / ")(3)
        tmp_effdat = txteffdate.Text


        Dim i As Integer
        Dim loc As Integer
        loc = -1
        For i = 0 To rs_CUCALFML.Tables("RESULT").Rows.Count - 1
            If tmp_cat = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_cat") And tmp_ven = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_venno") _
            And tmp_prctrm = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_prctrm") And tmp_trantrm = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_trantrm") And _
                tmp_effdat = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_effdat") Then
                'rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_latest") = "Y" Then
                loc = i
                Exit For
            End If
        Next i

        If loc = -1 Then
            MsgBox("Error,Cannot find specific formula")
            Exit Sub
        End If

        Dim Custmu As Decimal
        Dim PM As Decimal
        Dim thc As Decimal
        Dim ups As Decimal
        Dim lab As Decimal
        Dim FA As Decimal
        Dim CostBuf As Decimal
        Dim Others As Decimal
        Dim PLI As Decimal
        Dim DefMD As Decimal
        Dim ReBate As Decimal
        Dim cush As Decimal
        Dim subttl As Decimal
        Dim comm As Decimal

        If txtCustMU.Text = "" Then
            Custmu = 0
        Else
            Custmu = txtCustMU.Text
        End If

        If txtPM.Text = "" Then
            PM = 0
        Else
            PM = txtPM.Text
        End If

        If txtTHC.Text = "" Then
            thc = 0
        Else
            thc = txtTHC.Text
        End If

        If txtUPS.Text = "" Then
            ups = 0
        Else
            ups = txtUPS.Text
        End If

        If txtLab.Text = "" Then
            lab = 0
        Else
            lab = txtLab.Text
        End If

        If txtFA.Text = "" Then
            FA = 0
        Else
            FA = txtFA.Text
        End If

        If txtCostBuf.Text = "" Then
            CostBuf = 0
        Else
            CostBuf = txtCostBuf.Text
        End If

        If txtOthers.Text = "" Then
            Others = 0
        Else
            Others = txtOthers.Text

        End If

        If txtPLI.Text = "" Then
            PLI = 0
        Else
            PLI = txtPLI.Text
        End If

        If txtDefMD.Text = "" Then
            DefMD = 0
        Else
            DefMD = txtDefMD.Text
        End If

        If txtRebate.Text = "" Then
            ReBate = 0
        Else
            ReBate = txtRebate.Text
        End If

        If txtCush.Text = "" Then
            cush = 0
        Else
            cush = txtCush.Text
        End If

        If txtSubTtl.Text = "" Then
            subttl = 0
        Else
            subttl = txtSubTtl.Text
        End If

        If txtComm.Text = "" Then
            comm = 0
        Else
            comm = txtComm.Text

        End If





        rs_CUCALFML.Tables("RESULT").Rows(loc).Item("ccf_cumu") = Custmu
        rs_CUCALFML.Tables("RESULT").Rows(loc).Item("ccf_pm") = PM
        rs_CUCALFML.Tables("RESULT").Rows(loc).Item("ccf_cush") = cush

        rs_CUCALFML.Tables("RESULT").Rows(loc).Item("ccf_thccusper") = thc
        rs_CUCALFML.Tables("RESULT").Rows(loc).Item("ccf_upsper") = ups
        rs_CUCALFML.Tables("RESULT").Rows(loc).Item("ccf_labper") = lab
        rs_CUCALFML.Tables("RESULT").Rows(loc).Item("ccf_faper") = FA
        rs_CUCALFML.Tables("RESULT").Rows(loc).Item("ccf_cstbufper") = CostBuf
        rs_CUCALFML.Tables("RESULT").Rows(loc).Item("ccf_othper") = Others
        rs_CUCALFML.Tables("RESULT").Rows(loc).Item("ccf_pliper") = PLI
        rs_CUCALFML.Tables("RESULT").Rows(loc).Item("ccf_dmdper") = DefMD
        rs_CUCALFML.Tables("RESULT").Rows(loc).Item("ccf_rbtper") = ReBate
        rs_CUCALFML.Tables("RESULT").Rows(loc).Item("ccf_subttl") = subttl
        rs_CUCALFML.Tables("RESULT").Rows(loc).Item("ccf_comper") = comm

        If rs_CUCALFML.Tables("RESULT").Rows(loc).Item("ccf_creusr") <> "~*ADD*~" Then
            rs_CUCALFML.Tables("RESULT").Rows(loc).Item("ccf_creusr") = "~*UPD*~"
        End If

        FRecordstatus = True

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddPri.Click
        If cmdAddPri.Text = "Add" Then
            cboCUCALFMLKey.Visible = False
            cboPriCate.Visible = True
            cboPriPri.Visible = True
            cboPriTran.Visible = True
            cboPriVen.Visible = True
            cmdAddPri.Text = "Cancel"

            txtCustMU.Text = ""
            txtPM.Text = ""
            txtTHC.Text = ""
            txtUPS.Text = ""
            txtLab.Text = ""
            txtFA.Text = ""
            txtCostBuf.Text = ""
            txtOthers.Text = ""
            txtPLI.Text = ""
            txtDefMD.Text = ""
            txtRebate.Text = ""
            txtCush.Text = ""
            txtComm.Text = ""

            txtSubTtl.Text = ""

        Else
            'cboCUCALFMLKey.Visible = True
            cboPriCate.Visible = False
            cboPriPri.Visible = False
            cboPriTran.Visible = False
            cboPriVen.Visible = False
            cmdAddPri.Text = "Add"

            cboCUCALFMLKey.SelectedIndex = 0
            cboCUCALFMLKey_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub cboPriCate_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPriCate.KeyUp
        auto_search_combo(cboPriCate, e.KeyCode)
    End Sub

    Private Sub cboPriCate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPriCate.SelectedIndexChanged

    End Sub

    Private Sub cboPriCate_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPriCate.Validated

        If Trim(cboPriCate.Text) = "" Then
            Exit Sub
        End If

        If checkValidCombo(cboPriCate, cboPriCate.Text) = False Then
            MsgBox("Data Invalid")
            cboPriCate.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub cboPriVen_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPriVen.KeyUp
        auto_search_combo(cboPriVen, e.KeyCode)
    End Sub

    Private Sub cboPriVen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPriVen.SelectedIndexChanged

    End Sub

    Private Sub cboPriVen_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPriVen.Validated
        If Trim(cboPriVen.Text) = "" Then
            Exit Sub
        End If

        If checkValidCombo(cboPriVen, cboPriVen.Text) = False Then
            MsgBox("Data Invalid")
            cboPriVen.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub cboPriPri_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPriPri.KeyUp
        auto_search_combo(cboPriPri, e.KeyCode)
    End Sub

    Private Sub cboPriPri_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPriPri.SelectedIndexChanged

    End Sub

    Private Sub cboPriPri_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPriPri.Validated
        If Trim(cboPriPri.Text) = "" Then
            Exit Sub
        End If

        If checkValidCombo(cboPriPri, cboPriPri.Text) = False Then
            MsgBox("Data Invalid")
            cboPriPri.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub cboPriTran_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPriTran.KeyUp
        auto_search_combo(cboPriTran, e.KeyCode)
    End Sub

    Private Sub cboPriTran_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPriTran.SelectedIndexChanged

    End Sub

    Private Sub cboPriTran_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPriTran.Validated
        If Trim(cboPriTran.Text) = "" Then
            Exit Sub
        End If

        If checkValidCombo(cboPriTran, cboPriTran.Text) = False Then
            MsgBox("Data Invalid")
            cboPriTran.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub cmdSavePri_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSavePri.Click
        If cmdAddPri.Text = "A" Then
            If Trim(cboPriCate.Text) = "" Then
                MsgBox("Please input value")
                Me.BaseTabControl1.SelectedIndex = 4
                cboPriCate.Focus()

                Exit Sub
            End If

            If Trim(cboPriPri.Text) = "" Then
                MsgBox("Please input value")
                Me.BaseTabControl1.SelectedIndex = 4
                cboPriPri.Focus()

                Exit Sub
            End If

            If Trim(cboPriTran.Text) = "" Then
                MsgBox("Please input value")
                Me.BaseTabControl1.SelectedIndex = 4
                cboPriTran.Focus()

                Exit Sub
            End If

            If Trim(cboPriVen.Text) = "" Then
                MsgBox("Please input value")
                Me.BaseTabControl1.SelectedIndex = 4
                cboPriVen.Focus()

                Exit Sub
            End If


            If Trim(txtCustMU.Text) = "" Then
                MsgBox("Please input value")
                Me.BaseTabControl1.SelectedIndex = 4
                txtCustMU.Focus()
                Exit Sub
            End If

            If Trim(txtPM.Text) = "" Then
                MsgBox("Please input value")
                Me.BaseTabControl1.SelectedIndex = 4
                txtPM.Focus()
                Exit Sub
            End If

            If Trim(txtTHC.Text) = "" Then
                MsgBox("Please input value")
                Me.BaseTabControl1.SelectedIndex = 4
                txtTHC.Focus()
                Exit Sub
            End If

            If Trim(txtUPS.Text) = "" Then
                MsgBox("Please input value")
                Me.BaseTabControl1.SelectedIndex = 4
                txtUPS.Focus()
                Exit Sub
            End If

            If Trim(txtLab.Text) = "" Then
                MsgBox("Please input value")
                Me.BaseTabControl1.SelectedIndex = 4
                txtLab.Focus()
                Exit Sub
            End If

            If Trim(txtFA.Text) = "" Then
                MsgBox("Please input value")
                Me.BaseTabControl1.SelectedIndex = 4
                txtFA.Focus()
                Exit Sub
            End If

            If Trim(txtCostBuf.Text) = "" Then
                MsgBox("Please input value")
                Me.BaseTabControl1.SelectedIndex = 4
                txtCostBuf.Focus()
                Exit Sub
            End If

            If Trim(txtOthers.Text) = "" Then
                MsgBox("Please input value")
                Me.BaseTabControl1.SelectedIndex = 4
                txtOthers.Focus()
                Exit Sub
            End If

            If Trim(txtPLI.Text) = "" Then
                MsgBox("Please input value")
                Me.BaseTabControl1.SelectedIndex = 4
                txtPLI.Focus()
                Exit Sub
            End If

            If Trim(txtDefMD.Text) = "" Then
                MsgBox("Please input value")
                Me.BaseTabControl1.SelectedIndex = 4
                txtDefMD.Focus()
                Exit Sub
            End If

            If Trim(txtRebate.Text) = "" Then
                MsgBox("Please input value")
                Me.BaseTabControl1.SelectedIndex = 4
                txtRebate.Focus()
                Exit Sub
            End If

            If Trim(txtCush.Text) = "" Then
                MsgBox("Please input value")
                Me.BaseTabControl1.SelectedIndex = 4
                txtCush.Focus()
                Exit Sub
            End If

            If Trim(txtComm.Text) = "" Then
                MsgBox("Please input value")
                Me.BaseTabControl1.SelectedIndex = 4
                txtCush.Focus()
                Exit Sub
            End If

            Dim tmp_cat As String
            Dim tmp_ven As String
            Dim tmp_prctrm As String
            Dim tmp_trantrm As String
            Dim tmp_effdat As DateTime = txteffdate.Text

            tmp_cat = cboPriCate.Text
            tmp_ven = cboPriVen.Text
            tmp_prctrm = Split(cboPriPri.Text, " - ")(0)
            tmp_trantrm = cboPriTran.Text

            Dim dr() As DataRow
            dr = rs_CUCALFML.Tables("RESULT").Select("ccf_cat = '" & tmp_cat & "' and ccf_venno = '" & tmp_ven & "' and ccf_prctrm = '" & tmp_prctrm & "' and ccf_trantrm = '" & tmp_trantrm & "' and ccf_effdat = '" & tmp_effdat & "'")

            If dr.Length = 0 Then
                Dim rowcount As Integer = rs_CUCALFML.Tables("RESULT").Rows.Count
                rs_CUCALFML.Tables("RESULT").Rows.Add()

                If txtCusno.Text.StartsWith("5") Then
                    rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_cus1no") = Trim(txtCusno.Text)
                    rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_cus2no") = ""
                ElseIf txtCusno.Text.StartsWith("6") Then
                    If rs_CUSUBCUS_P.Tables("RESULT").Rows.Count <> 0 Then
                        rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_cus1no") = rs_CUSUBCUS_P.Tables("RESULT").Rows(0).Item(2)
                    Else
                        rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_cus1no") = ""
                    End If

                    rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_cus2no") = Trim(txtCusno.Text)

                End If
                rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("DEL") = ""
                rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_cat") = cboPriCate.Text
                rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_venno") = cboPriVen.Text
                rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_prctrm") = Split(cboPriPri.Text, " - ")(0)
                rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_trantrm") = cboPriTran.Text
                rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_curcde") = ""
                rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_cumu") = txtCustMU.Text
                rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_pm") = txtPM.Text
                rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_cush") = txtCush.Text
                rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_thccusper") = txtTHC.Text
                rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_upsper") = txtUPS.Text
                rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_labper") = txtLab.Text
                rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_faper") = txtFA.Text
                rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_cstbufper") = txtCostBuf.Text
                rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_othper") = txtOthers.Text
                rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_pliper") = txtPLI.Text
                rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_dmdper") = txtDefMD.Text
                rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_rbtper") = txtRebate.Text
                rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_pkgper") = 0
                rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_comper") = txtComm.Text
                rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_icmper") = 0

                'rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_cumu") = rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_cumu") / 100
                'rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_pm") = rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_pm") / 100
                'rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_cush") = rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_cush") / 100
                'rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_thccusper") = rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_thccusper") / 100
                'rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_upsper") = rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_upsper") / 100
                'rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_labper") = rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_labper") / 100
                'rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_faper") = rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_faper") / 100
                'rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_cstbufper") = rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_cstbufper") / 100
                'rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_othper") = rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_othper") / 100
                'rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_pliper") = rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_pliper") / 100
                'rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_dmdper") = rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_dmdper") / 100
                'rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_rbtper") = rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_rbtper") / 100
                'rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_comper") = rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_comper") / 100


                rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_subttl") = txtSubTtl.Text
                rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_effdat") = txteffdate.Text
                rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_creusr") = "~*ADD*~"
                rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_latest") = "Y"

                rs_CUCALFML.Tables("RESULT").Rows(rowcount).Item("ccf_iseff") = "Y"

                cboPriCate.Visible = False
                cboPriPri.Visible = False
                cboPriTran.Visible = False
                cboPriVen.Visible = False
                'If save_CUCALFML() = True Then

                Panel2.Visible = False



                'MsgBox("Record Saved")

                'gspStr = "sp_select_CUCALFML '','" & txtCusno.Text & "'"
                'rtnLong = execute_SQLStatement(gspStr, rs_CUCALFML, rtnStr)
                'If rtnLong <> RC_SUCCESS Then
                '    MsgBox("Error on loading func_ReadRecordset sp_select_CUCALFML :" & rtnStr)
                '    Exit Sub
                'End If



                'Dim i As Integer
                'For i = 0 To rs_CUCALFML.Tables("RESULT").Columns.Count - 1
                '    rs_CUCALFML.Tables("RESULT").Columns(i).ReadOnly = False
                'Next
                'Dim tmpstr As String

                'cboCUCALFMLKey.Items.Clear()
                'For i = 0 To rs_CUCALFML.Tables("RESULT").Rows.Count - 1
                '    If rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_latest") = "Y" Then
                '        tmpstr = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_cat") & " / " & _
                '                    rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_venno") & " / " & _
                '                    rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_prctrm") & " / " & _
                '                    rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_trantrm")
                '        cboCUCALFMLKey.Items.Add(tmpstr)
                '    End If
                'Next i

                'If cboCUCALFMLKey.Items.Count > 0 Then
                '    cboCUCALFMLKey.SelectedIndex = 0
                'End If

                'cboCUCALFMLKey.Visible = True
               
                'cmdAddPri.Text = "Add"



                'Dim dv As DataView = rs_CUCALFML.Tables("RESULT").DefaultView
                'dv.RowFilter = "ccf_latest = '@#$%^&*('"

                'Call SetgrdCUCALFML(dv)

                'End If

            Else
                MsgBox("Action Fail,Selected Value Already Exist")
            End If
        Else
            MarkCustomerUpdate()
            Panel2.Visible = False
            'If save_CUCALFML() = True Then
            '    MsgBox("Record Saved")

            '    gspStr = "sp_select_CUCALFML '','" & txtCusno.Text & "'"
            '    rtnLong = execute_SQLStatement(gspStr, rs_CUCALFML, rtnStr)
            '    If rtnLong <> RC_SUCCESS Then
            '        MsgBox("Error on loading func_ReadRecordset sp_select_CUCALFML :" & rtnStr)
            '        Exit Sub
            '    End If

            '    Dim i As Integer
            '    For i = 0 To rs_CUCALFML.Tables("RESULT").Columns.Count - 1
            '        rs_CUCALFML.Tables("RESULT").Columns(i).ReadOnly = False
            '    Next
            '    Dim tmpstr As String

            '    'cboCUCALFMLKey.Items.Clear()
            '    'For i = 0 To rs_CUCALFML.Tables("RESULT").Rows.Count - 1
            '    '    If rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_latest") = "Y" Then
            '    '        tmpstr = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_cat") & " / " & _
            '    '                    rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_venno") & " / " & _
            '    '                    rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_prctrm") & " / " & _
            '    '                    rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_trantrm")
            '    '        cboCUCALFMLKey.Items.Add(tmpstr)
            '    '    End If
            '    'Next i

            '    'If cboCUCALFMLKey.Items.Count > 0 Then
            '    '    cboCUCALFMLKey.SelectedIndex = 0
            '    'End If

            '    'cboCUCALFMLKey.Visible = True
            '    cboPriCate.Visible = False
            '    cboPriPri.Visible = False
            '    cboPriTran.Visible = False
            '    cboPriVen.Visible = False
            '    ' cmdAddPri.Text = "Add"


            '    Dim dv As DataView = rs_CUCALFML.Tables("RESULT").DefaultView
            '    dv.RowFilter = "ccf_latest = '@#$%^&*('"

            '    Call SetgrdCUCALFML(dv)


            'End If



        End If

    End Sub
    Private Function save_CUCALFML() As Boolean





        'Dim ccf_cocde As String
        'Dim ccf_cus1no As String
        'Dim ccf_cus2no As String
        'Dim ccf_cat As String
        'Dim ccf_venno As String
        'Dim ccf_prctrm As String
        'Dim ccf_trantrm As String
        'Dim ccf_curcde As String
        'Dim ccf_cumu As Decimal
        'Dim ccf_pm As Decimal
        'Dim ccf_cush As Decimal
        'Dim ccf_thccusper As Decimal
        'Dim ccf_upsper As Decimal
        'Dim ccf_labper As Decimal
        'Dim ccf_faper As Decimal
        'Dim ccf_cstbufper As Decimal
        'Dim ccf_othper As Decimal
        'Dim ccf_pliper As Decimal
        'Dim ccf_dmdper As Decimal
        'Dim ccf_rbtper As Decimal
        'Dim ccf_pkgper As Decimal
        'Dim ccf_comper As Decimal
        'Dim ccf_icmper As Decimal
        'Dim ccf_creusr As String
        'Dim ccf_latest As String
        'Dim ccf_effdat As DateTime

        'If cmdAddPri.Text = "A" Then  'em
        '    ccf_cocde = ""
        '    If txtCusno.Text.StartsWith("5") Then
        '        ccf_cus1no = Trim(txtCusno.Text)
        '        ccf_cus2no = ""
        '    ElseIf txtCusno.Text.StartsWith("6") Then
        '        If rs_CUSUBCUS_P.Tables("RESULT").Rows.Count <> 0 Then
        '            ccf_cus1no = rs_CUSUBCUS_P.Tables("RESULT").Rows(0).Item(2)
        '        Else
        '            ccf_cus1no = ""
        '        End If

        '        ccf_cus2no = Trim(txtCusno.Text)

        '    End If
        '    ccf_cat = cboPriCate.Text
        '    ccf_venno = cboPriVen.Text
        '    ccf_prctrm = cboPriPri.Text
        '    ccf_trantrm = cboPriTran.Text
        '    ccf_curcde = ""
        '    ccf_cumu = txtCustMU.Text
        '    ccf_pm = txtPM.Text
        '    ccf_cush = txtCush.Text
        '    ccf_thccusper = txtTHC.Text
        '    ccf_upsper = txtUPS.Text
        '    ccf_labper = txtLab.Text
        '    ccf_faper = txtFA.Text
        '    ccf_cstbufper = txtCostBuf.Text
        '    ccf_othper = txtOthers.Text
        '    ccf_pliper = txtPLI.Text
        '    ccf_dmdper = txtDefMD.Text
        '    ccf_rbtper = txtRebate.Text
        '    ccf_pkgper = 0
        '    ccf_comper = txtComm.Text
        '    ccf_icmper = 0

        '    ccf_cumu = ccf_cumu / 100
        '    ccf_pm = ccf_pm / 100
        '    ccf_cush = ccf_cush / 100
        '    ccf_thccusper = ccf_thccusper / 100
        '    ccf_upsper = ccf_upsper / 100
        '    ccf_labper = ccf_labper / 100
        '    ccf_faper = ccf_faper / 100
        '    ccf_cstbufper = ccf_cstbufper / 100
        '    ccf_othper = ccf_othper / 100
        '    ccf_pliper = ccf_pliper / 100
        '    ccf_dmdper = ccf_dmdper / 100
        '    ccf_rbtper = ccf_rbtper / 100
        '    ccf_comper = ccf_comper / 100
        '    ccf_effdat = txteffdate.Text

        '    gspStr = "sp_insert_CUCALFML '" & ccf_cocde & "','" & ccf_cus1no & "','" & ccf_cus2no & "','" & ccf_cat & "','" & _
        '              ccf_venno & "','" & ccf_prctrm & "','" & ccf_trantrm & "','" & ccf_curcde & "'," & ccf_cumu & "," & _
        '              ccf_pm & "," & ccf_cush & "," & ccf_thccusper & "," & ccf_upsper & "," & ccf_labper & "," & ccf_faper & "," & _
        '              ccf_cstbufper & "," & ccf_othper & "," & ccf_pliper & "," & ccf_dmdper & "," & ccf_rbtper & "," & ccf_pkgper & "," & _
        '              ccf_comper & "," & ccf_icmper & ",'" & gsUsrID & "','" & ccf_effdat & "'"

        '    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        '    If rtnLong <> RC_SUCCESS Then
        '        MsgBox("Error on loading save_CUCALFML sp_insert_CUCALFML :" & rtnStr)
        '        save_CUCALFML = False
        '        Exit Function
        '    End If


        'End If





        'Dim i As Integer





        'For i = 0 To rs_CUCALFML.Tables("RESULT").Rows.Count - 1
        '    ccf_cocde = ""
        '    ccf_cus1no = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_cus1no")
        '    ccf_cus2no = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_cus2no")
        '    ccf_cat = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_cat")
        '    ccf_venno = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_venno")
        '    ccf_prctrm = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_prctrm")
        '    ccf_trantrm = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_trantrm")
        '    ccf_curcde = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_curcde")
        '    ccf_cumu = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_cumu") / 100
        '    ccf_pm = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_pm") / 100
        '    ccf_cush = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_cush") / 100
        '    ccf_thccusper = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_thccusper") / 100
        '    ccf_upsper = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_upsper") / 100
        '    ccf_labper = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_labper") / 100
        '    ccf_faper = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_faper") / 100
        '    ccf_cstbufper = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_cstbufper") / 100
        '    ccf_othper = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_othper") / 100
        '    ccf_pliper = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_pliper") / 100
        '    ccf_dmdper = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_dmdper") / 100
        '    ccf_rbtper = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_rbtper") / 100
        '    ccf_pkgper = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_pkgper") / 100
        '    ccf_comper = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_comper") / 100
        '    ccf_icmper = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_icmper") / 100
        '    ccf_creusr = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_creusr")
        '    ccf_latest = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_latest")


        '    If ccf_latest = "Y" And (ccf_creusr = "~*UPD*~" Or copyflag = True) Then  '''''''''''''''''''''Copy flag


        '        gspStr = "sp_update_CUCALFML '" & ccf_cocde & "','" & ccf_cus1no & "','" & ccf_cus2no & "','" & ccf_cat & "','" & _
        '                  ccf_venno & "','" & ccf_prctrm & "','" & ccf_trantrm & "','" & ccf_curcde & "'," & ccf_cumu & "," & _
        '                  ccf_pm & "," & ccf_cush & "," & ccf_thccusper & "," & ccf_upsper & "," & ccf_labper & "," & ccf_faper & "," & _
        '                  ccf_cstbufper & "," & ccf_othper & "," & ccf_pliper & "," & ccf_dmdper & "," & ccf_rbtper & "," & ccf_pkgper & "," & _
        '                  ccf_comper & "," & ccf_icmper & ",'" & gsUsrID & "'"

        '        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        '        If rtnLong <> RC_SUCCESS Then
        '            MsgBox("Error on loading save_CUCALFML sp_update_CUCALFML :" & rtnStr)
        '            save_CUCALFML = False
        '            Exit Function
        '        End If





        '    End If

        'Next

        '    save_CUCALFML = True

    End Function

    Private Sub txtCustMU_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCustMU.KeyPress
        Dim val As String
        val = Trim(txtCustMU.Text)

        If (InStr("0123456789.", Chr(Asc(e.KeyChar))) = 0) And Asc(e.KeyChar) > 31 Or _
        ((InStr(val, ".") <> 0) And Asc(e.KeyChar) > 31 And Chr(Asc(e.KeyChar)) = ".") Then
            e.KeyChar = Chr(0)
        ElseIf UBound(Split(val, ".")) = 0 Then
            If (Microsoft.VisualBasic.Len(val) + 1 > 3) And Asc(e.KeyChar) > 31 And (Chr(Asc(e.KeyChar)) <> ".") Then
                e.KeyChar = Chr(0)
            End If
        ElseIf UBound(Split(val, ".")) > 0 Then


            If txtCustMU.SelectionStart <= Microsoft.VisualBasic.Len(Split(val, ".")(0)) Then

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

    




    Private Sub txtPM_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPM.KeyPress
        Dim val As String
        val = Trim(txtPM.Text)

        If (InStr("0123456789.", Chr(Asc(e.KeyChar))) = 0) And Asc(e.KeyChar) > 31 Or _
        ((InStr(val, ".") <> 0) And Asc(e.KeyChar) > 31 And Chr(Asc(e.KeyChar)) = ".") Then
            e.KeyChar = Chr(0)
        ElseIf UBound(Split(val, ".")) = 0 Then
            If (Microsoft.VisualBasic.Len(val) + 1 > 3) And Asc(e.KeyChar) > 31 And (Chr(Asc(e.KeyChar)) <> ".") Then
                e.KeyChar = Chr(0)
            End If
        ElseIf UBound(Split(val, ".")) > 0 Then


            If txtPM.SelectionStart <= Microsoft.VisualBasic.Len(Split(val, ".")(0)) Then

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

    Private Sub txtTHC_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTHC.KeyPress
        Dim val As String
        val = Trim(txtTHC.Text)

        If (InStr("0123456789.", Chr(Asc(e.KeyChar))) = 0) And Asc(e.KeyChar) > 31 Or _
        ((InStr(val, ".") <> 0) And Asc(e.KeyChar) > 31 And Chr(Asc(e.KeyChar)) = ".") Then
            e.KeyChar = Chr(0)
        ElseIf UBound(Split(val, ".")) = 0 Then
            If (Microsoft.VisualBasic.Len(val) + 1 > 3) And Asc(e.KeyChar) > 31 And (Chr(Asc(e.KeyChar)) <> ".") Then
                e.KeyChar = Chr(0)
            End If
        ElseIf UBound(Split(val, ".")) > 0 Then


            If txtTHC.SelectionStart <= Microsoft.VisualBasic.Len(Split(val, ".")(0)) Then

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

    Private Sub txtUPS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUPS.KeyPress
        Dim val As String
        val = Trim(txtUPS.Text)

        If (InStr("0123456789.", Chr(Asc(e.KeyChar))) = 0) And Asc(e.KeyChar) > 31 Or _
        ((InStr(val, ".") <> 0) And Asc(e.KeyChar) > 31 And Chr(Asc(e.KeyChar)) = ".") Then
            e.KeyChar = Chr(0)
        ElseIf UBound(Split(val, ".")) = 0 Then
            If (Microsoft.VisualBasic.Len(val) + 1 > 3) And Asc(e.KeyChar) > 31 And (Chr(Asc(e.KeyChar)) <> ".") Then
                e.KeyChar = Chr(0)
            End If
        ElseIf UBound(Split(val, ".")) > 0 Then


            If txtUPS.SelectionStart <= Microsoft.VisualBasic.Len(Split(val, ".")(0)) Then

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

    Private Sub txtLab_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLab.KeyPress
        Dim val As String
        val = Trim(txtLab.Text)

        If (InStr("0123456789.", Chr(Asc(e.KeyChar))) = 0) And Asc(e.KeyChar) > 31 Or _
        ((InStr(val, ".") <> 0) And Asc(e.KeyChar) > 31 And Chr(Asc(e.KeyChar)) = ".") Then
            e.KeyChar = Chr(0)
        ElseIf UBound(Split(val, ".")) = 0 Then
            If (Microsoft.VisualBasic.Len(val) + 1 > 3) And Asc(e.KeyChar) > 31 And (Chr(Asc(e.KeyChar)) <> ".") Then
                e.KeyChar = Chr(0)
            End If
        ElseIf UBound(Split(val, ".")) > 0 Then


            If txtLab.SelectionStart <= Microsoft.VisualBasic.Len(Split(val, ".")(0)) Then

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

    Private Sub txtFA_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFA.KeyPress
        Dim val As String
        val = Trim(txtFA.Text)

        If (InStr("0123456789.", Chr(Asc(e.KeyChar))) = 0) And Asc(e.KeyChar) > 31 Or _
        ((InStr(val, ".") <> 0) And Asc(e.KeyChar) > 31 And Chr(Asc(e.KeyChar)) = ".") Then
            e.KeyChar = Chr(0)
        ElseIf UBound(Split(val, ".")) = 0 Then
            If (Microsoft.VisualBasic.Len(val) + 1 > 3) And Asc(e.KeyChar) > 31 And (Chr(Asc(e.KeyChar)) <> ".") Then
                e.KeyChar = Chr(0)
            End If
        ElseIf UBound(Split(val, ".")) > 0 Then


            If txtFA.SelectionStart <= Microsoft.VisualBasic.Len(Split(val, ".")(0)) Then

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

    Private Sub txtCostBuf_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCostBuf.KeyPress
        Dim val As String
        val = Trim(txtCostBuf.Text)

        If (InStr("0123456789.", Chr(Asc(e.KeyChar))) = 0) And Asc(e.KeyChar) > 31 Or _
        ((InStr(val, ".") <> 0) And Asc(e.KeyChar) > 31 And Chr(Asc(e.KeyChar)) = ".") Then
            e.KeyChar = Chr(0)
        ElseIf UBound(Split(val, ".")) = 0 Then
            If (Microsoft.VisualBasic.Len(val) + 1 > 3) And Asc(e.KeyChar) > 31 And (Chr(Asc(e.KeyChar)) <> ".") Then
                e.KeyChar = Chr(0)
            End If
        ElseIf UBound(Split(val, ".")) > 0 Then


            If txtCostBuf.SelectionStart <= Microsoft.VisualBasic.Len(Split(val, ".")(0)) Then

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

    Private Sub txtOthers_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOthers.KeyPress
        Dim val As String
        val = Trim(txtOthers.Text)

        If (InStr("0123456789.", Chr(Asc(e.KeyChar))) = 0) And Asc(e.KeyChar) > 31 Or _
        ((InStr(val, ".") <> 0) And Asc(e.KeyChar) > 31 And Chr(Asc(e.KeyChar)) = ".") Then
            e.KeyChar = Chr(0)
        ElseIf UBound(Split(val, ".")) = 0 Then
            If (Microsoft.VisualBasic.Len(val) + 1 > 3) And Asc(e.KeyChar) > 31 And (Chr(Asc(e.KeyChar)) <> ".") Then
                e.KeyChar = Chr(0)
            End If
        ElseIf UBound(Split(val, ".")) > 0 Then


            If txtOthers.SelectionStart <= Microsoft.VisualBasic.Len(Split(val, ".")(0)) Then

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

    Private Sub txtPLI_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPLI.KeyPress
        Dim val As String
        val = Trim(txtPLI.Text)

        If (InStr("0123456789.", Chr(Asc(e.KeyChar))) = 0) And Asc(e.KeyChar) > 31 Or _
        ((InStr(val, ".") <> 0) And Asc(e.KeyChar) > 31 And Chr(Asc(e.KeyChar)) = ".") Then
            e.KeyChar = Chr(0)
        ElseIf UBound(Split(val, ".")) = 0 Then
            If (Microsoft.VisualBasic.Len(val) + 1 > 3) And Asc(e.KeyChar) > 31 And (Chr(Asc(e.KeyChar)) <> ".") Then
                e.KeyChar = Chr(0)
            End If
        ElseIf UBound(Split(val, ".")) > 0 Then


            If txtPLI.SelectionStart <= Microsoft.VisualBasic.Len(Split(val, ".")(0)) Then

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

    Private Sub txtDefMD_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDefMD.KeyPress
        Dim val As String
        val = Trim(txtDefMD.Text)

        If (InStr("0123456789.", Chr(Asc(e.KeyChar))) = 0) And Asc(e.KeyChar) > 31 Or _
        ((InStr(val, ".") <> 0) And Asc(e.KeyChar) > 31 And Chr(Asc(e.KeyChar)) = ".") Then
            e.KeyChar = Chr(0)
        ElseIf UBound(Split(val, ".")) = 0 Then
            If (Microsoft.VisualBasic.Len(val) + 1 > 3) And Asc(e.KeyChar) > 31 And (Chr(Asc(e.KeyChar)) <> ".") Then
                e.KeyChar = Chr(0)
            End If
        ElseIf UBound(Split(val, ".")) > 0 Then


            If txtDefMD.SelectionStart <= Microsoft.VisualBasic.Len(Split(val, ".")(0)) Then

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

    Private Sub txtRebate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRebate.KeyPress
        Dim val As String
        val = Trim(txtRebate.Text)

        If (InStr("0123456789.", Chr(Asc(e.KeyChar))) = 0) And Asc(e.KeyChar) > 31 Or _
        ((InStr(val, ".") <> 0) And Asc(e.KeyChar) > 31 And Chr(Asc(e.KeyChar)) = ".") Then
            e.KeyChar = Chr(0)
        ElseIf UBound(Split(val, ".")) = 0 Then
            If (Microsoft.VisualBasic.Len(val) + 1 > 3) And Asc(e.KeyChar) > 31 And (Chr(Asc(e.KeyChar)) <> ".") Then
                e.KeyChar = Chr(0)
            End If
        ElseIf UBound(Split(val, ".")) > 0 Then


            If txtRebate.SelectionStart <= Microsoft.VisualBasic.Len(Split(val, ".")(0)) Then

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

    Private Sub txtCush_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCush.KeyPress
        Dim val As String
        val = Trim(txtCush.Text)

        If (InStr("0123456789.", Chr(Asc(e.KeyChar))) = 0) And Asc(e.KeyChar) > 31 Or _
        ((InStr(val, ".") <> 0) And Asc(e.KeyChar) > 31 And Chr(Asc(e.KeyChar)) = ".") Then
            e.KeyChar = Chr(0)
        ElseIf UBound(Split(val, ".")) = 0 Then
            If (Microsoft.VisualBasic.Len(val) + 1 > 3) And Asc(e.KeyChar) > 31 And (Chr(Asc(e.KeyChar)) <> ".") Then
                e.KeyChar = Chr(0)
            End If
        ElseIf UBound(Split(val, ".")) > 0 Then


            If txtCush.SelectionStart <= Microsoft.VisualBasic.Len(Split(val, ".")(0)) Then

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

    Private Sub txtComm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtComm.KeyPress
        Dim val As String
        val = Trim(txtComm.Text)

        If (InStr("0123456789.", Chr(Asc(e.KeyChar))) = 0) And Asc(e.KeyChar) > 31 Or _
        ((InStr(val, ".") <> 0) And Asc(e.KeyChar) > 31 And Chr(Asc(e.KeyChar)) = ".") Then
            e.KeyChar = Chr(0)
        ElseIf UBound(Split(val, ".")) = 0 Then
            If (Microsoft.VisualBasic.Len(val) + 1 > 3) And Asc(e.KeyChar) > 31 And (Chr(Asc(e.KeyChar)) <> ".") Then
                e.KeyChar = Chr(0)
            End If
        ElseIf UBound(Split(val, ".")) > 0 Then


            If txtComm.SelectionStart <= Microsoft.VisualBasic.Len(Split(val, ".")(0)) Then

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

    Private Sub CalucatePriceTTL()

        Dim Custmu As Decimal
        Dim PM As Decimal
        Dim thc As Decimal
        Dim ups As Decimal
        Dim lab As Decimal
        Dim FA As Decimal
        Dim CostBuf As Decimal
        Dim Others As Decimal
        Dim PLI As Decimal
        Dim DefMD As Decimal
        Dim ReBate As Decimal

        If txtCustMU.Text = "" Then
            Custmu = 0
        Else
            Custmu = txtCustMU.Text
        End If

        If txtPM.Text = "" Then
            PM = 0
        Else
            PM = txtPM.Text
        End If

        If txtTHC.Text = "" Then
            thc = 0
        Else
            thc = txtTHC.Text
        End If

        If txtUPS.Text = "" Then
            ups = 0
        Else
            ups = txtUPS.Text
        End If

        If txtLab.Text = "" Then
            lab = 0
        Else
            lab = txtLab.Text
        End If

        If txtFA.Text = "" Then
            FA = 0
        Else
            FA = txtFA.Text
        End If

        If txtCostBuf.Text = "" Then
            CostBuf = 0
        Else
            CostBuf = txtCostBuf.Text
        End If

        If txtOthers.Text = "" Then
            Others = 0
        Else
            Others = txtOthers.Text

        End If

        If txtPLI.Text = "" Then
            PLI = 0
        Else
            PLI = txtPLI.Text
        End If

        If txtDefMD.Text = "" Then
            DefMD = 0
        Else
            DefMD = txtDefMD.Text
        End If

        If txtRebate.Text = "" Then
            ReBate = 0
        Else
            ReBate = txtRebate.Text
        End If

        txtSubTtl.Text = Custmu + PM + thc + ups + lab + FA + CostBuf + Others + PLI + DefMD + ReBate
        

    End Sub

    Private Sub txtCustMU_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCustMU.Validating
        'MarkCustomerUpdate()
    End Sub

    Private Sub txtCustMU_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustMU.TextChanged
        CalucatePriceTTL()
    End Sub

    Private Sub cboRounding_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRounding.SelectedIndexChanged
        Recordstatus = True
    End Sub

    Private Sub cboRounding_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRounding.Validated
        If Trim(cboRounding.Text) = "" Then
            Exit Sub
        End If

        If checkValidCombo(cboRounding, cboRounding.Text) = False Then
            MsgBox("Data Invalid")
            cboRounding.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub txtPM_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPM.TextChanged
        CalucatePriceTTL()
    End Sub

    Private Sub txtTHC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTHC.TextChanged
        CalucatePriceTTL()
    End Sub

    Private Sub txtUPS_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUPS.TextChanged
        CalucatePriceTTL()
    End Sub

    Private Sub txtLab_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLab.TextChanged
        CalucatePriceTTL()
    End Sub

    Private Sub txtFA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFA.TextChanged
        CalucatePriceTTL()
    End Sub

    Private Sub txtCostBuf_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCostBuf.TextChanged
        CalucatePriceTTL()
    End Sub

    Private Sub txtOthers_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOthers.TextChanged
        CalucatePriceTTL()
    End Sub

    Private Sub txtPLI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPLI.TextChanged
        CalucatePriceTTL()
    End Sub

    Private Sub txtDefMD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDefMD.TextChanged
        CalucatePriceTTL()
    End Sub

    Private Sub txtRebate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRebate.TextChanged
        CalucatePriceTTL()
    End Sub

    Private Sub txtCush_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCush.TextChanged
        CalucatePriceTTL()
    End Sub

    Private Sub txtComm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtComm.TextChanged
        CalucatePriceTTL()
    End Sub

    Private Sub txtPM_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPM.Validating
        'MarkCustomerUpdate()
    End Sub

    Private Sub txtTHC_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTHC.Validating
        'MarkCustomerUpdate()
    End Sub

    Private Sub txtUPS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtUPS.Validating
        ' MarkCustomerUpdate()
    End Sub

    Private Sub txtLab_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLab.Validating
        '  MarkCustomerUpdate()
    End Sub

    Private Sub txtFA_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtFA.Validating
        '  MarkCustomerUpdate()
    End Sub

    Private Sub txtCostBuf_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCostBuf.Validating
        ' MarkCustomerUpdate()
    End Sub

  

    Private Sub txtOthers_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtOthers.Validating
        '  MarkCustomerUpdate()
    End Sub

    Private Sub txtPLI_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPLI.Validating
        '  MarkCustomerUpdate()
    End Sub

    Private Sub txtDefMD_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDefMD.Validating
        '  MarkCustomerUpdate()
    End Sub

    Private Sub txtRebate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtRebate.Validating
        '  MarkCustomerUpdate()
    End Sub

    Private Sub txtCush_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCush.Validating
        '  MarkCustomerUpdate()
    End Sub

    Private Sub txtComm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtComm.Validating
        ' MarkCustomerUpdate()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEffDate.Click
        Dim dv As DataView = rs_CUCALFML.Tables("RESULT").DefaultView
        dv.RowFilter = "ccf_latest = '@#$%^&*('"

        Call SetgrdCUCALFML(dv)

        cboEffDat.Visible = True
        txtEffDat.Visible = False
        chkEff.Checked = False
        cmdAddEffDat.Text = "Add"


        Panel1.Height = 388
        Panel1.Width = 837
        Panel1.Top = 11
        Panel1.Left = 23

        Panel1.Visible = True



    End Sub

    Private Sub SetgrdCUCALFML(Optional ByVal dv As DataView = Nothing)
        'ch na



        If dv Is Nothing Then dv = rs_CUCALFML.Tables("RESULT").DefaultView
        bindSrc.DataSource = dv
        grdCUCALFML.DataSource = Nothing
        grdCUCALFML.DataSource = bindSrc



        grdCUCALFML.RowHeadersWidth = 18
        grdCUCALFML.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        grdCUCALFML.ColumnHeadersHeight = 22
        grdCUCALFML.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        grdCUCALFML.AllowUserToResizeColumns = True
        grdCUCALFML.AllowUserToResizeRows = False
        grdCUCALFML.RowTemplate.Height = 18

        Dim i As Integer

        ''If mode = "UPDATE" Or mode = "ADD" Then
        'For i = 0 To rs_CUCALFML.Tables("RESULT").Columns.Count - 1
        '    rs_CUCALFML.Tables("RESULT").Columns(i).ReadOnly = False
        'Next i
        ''End If


        i = 0
        grdCUCALFML_DEL = i
        grdCUCALFML.Columns(i).HeaderText = "Del"
        grdCUCALFML.Columns(i).Width = 30
        grdCUCALFML.Columns(i).ReadOnly = True
        i = i + 1
        grdCUCALFML_ccf_cocde = i
        grdCUCALFML.Columns(i).Visible = False
        i = i + 1
        grdCUCALFML_ccf_cus1no = i
        grdCUCALFML.Columns(i).Visible = False
        i = i + 1
        grdCUCALFML.Columns(i).Visible = False
        grdCUCALFML_ccf_cus2no = i
        i = i + 1
        grdCUCALFML_ccf_cat = i
        grdCUCALFML.Columns(i).HeaderText = "Category"
        grdCUCALFML.Columns(i).Width = 90
        grdCUCALFML.Columns(i).ReadOnly = True
        i = i + 1
        grdCUCALFML_ccf_venno = i
        grdCUCALFML.Columns(i).HeaderText = "Vendor Type"
        grdCUCALFML.Columns(i).Width = 90
        grdCUCALFML.Columns(i).ReadOnly = True
        i = i + 1
        grdCUCALFML_ccf_prctrm = i
        grdCUCALFML.Columns(i).HeaderText = "Price Term"
        grdCUCALFML.Columns(i).Width = 80
        grdCUCALFML.Columns(i).ReadOnly = True
        i = i + 1
        grdCUCALFML_ccf_trantrm = i
        grdCUCALFML.Columns(i).HeaderText = "Tran Term"
        grdCUCALFML.Columns(i).Width = 70
        grdCUCALFML.Columns(i).ReadOnly = True
        i = i + 1
        grdCUCALFML_ccf_curcde = i
        grdCUCALFML.Columns(i).Visible = False
        i = i + 1
        grdCUCALFML_ccf_cumu = i
        grdCUCALFML.Columns(i).HeaderText = "Cust. MU"
        grdCUCALFML.Columns(i).Width = 70
        grdCUCALFML.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        If DateTime.Compare(CType(cboEffDat.Text, Date), System.DateTime.Now) < 0 And CType(cboEffDat.Text, Date) <> System.DateTime.Now.ToShortDateString Then
            grdCUCALFML.Columns(i).ReadOnly = True
        Else
            grdCUCALFML.Columns(i).ReadOnly = False
        End If
        i = i + 1
        grdCUCALFML_ccf_pm = i
        grdCUCALFML.Columns(i).HeaderText = "Profit Margin"
        grdCUCALFML.Columns(i).Width = 90
        grdCUCALFML.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        If DateTime.Compare(CType(cboEffDat.Text, Date), System.DateTime.Now) < 0 And CType(cboEffDat.Text, Date) <> System.DateTime.Now.ToShortDateString Then
            grdCUCALFML.Columns(i).ReadOnly = True
        Else
            grdCUCALFML.Columns(i).ReadOnly = False
        End If
        i = i + 1
        grdCUCALFML_ccf_cush = i
        grdCUCALFML.Columns(i).HeaderText = "Cushion"
        grdCUCALFML.Columns(i).Width = 70
        grdCUCALFML.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        If DateTime.Compare(CType(cboEffDat.Text, Date), System.DateTime.Now) < 0 And CType(cboEffDat.Text, Date) <> System.DateTime.Now.ToShortDateString Then
            grdCUCALFML.Columns(i).ReadOnly = True
        Else
            grdCUCALFML.Columns(i).ReadOnly = False
        End If
        i = i + 1
        grdCUCALFML_ccf_thccusper = i
        grdCUCALFML.Columns(i).HeaderText = "THC"
        grdCUCALFML.Columns(i).Width = 60
        grdCUCALFML.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        If DateTime.Compare(CType(cboEffDat.Text, Date), System.DateTime.Now) < 0 And CType(cboEffDat.Text, Date) <> System.DateTime.Now.ToShortDateString Then
            grdCUCALFML.Columns(i).ReadOnly = True
        Else
            grdCUCALFML.Columns(i).ReadOnly = False
        End If
        i = i + 1
        grdCUCALFML_ccf_upsper = i
        grdCUCALFML.Columns(i).HeaderText = "UPS/Sampling"
        grdCUCALFML.Columns(i).Width = 90
        grdCUCALFML.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        If DateTime.Compare(CType(cboEffDat.Text, Date), System.DateTime.Now) < 0 And CType(cboEffDat.Text, Date) <> System.DateTime.Now.ToShortDateString Then
            grdCUCALFML.Columns(i).ReadOnly = True
        Else
            grdCUCALFML.Columns(i).ReadOnly = False
        End If
        i = i + 1
        grdCUCALFML_ccf_labper = i
        grdCUCALFML.Columns(i).HeaderText = "Lab Test"
        grdCUCALFML.Columns(i).Width = 70
        grdCUCALFML.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        If DateTime.Compare(CType(cboEffDat.Text, Date), System.DateTime.Now) < 0 And CType(cboEffDat.Text, Date) <> System.DateTime.Now.ToShortDateString Then
            grdCUCALFML.Columns(i).ReadOnly = True
        Else
            grdCUCALFML.Columns(i).ReadOnly = False
        End If
        i = i + 1
        grdCUCALFML_ccf_faper = i
        grdCUCALFML.Columns(i).HeaderText = "Fty Audit"
        grdCUCALFML.Columns(i).Width = 90
        grdCUCALFML.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        If DateTime.Compare(CType(cboEffDat.Text, Date), System.DateTime.Now) < 0 And CType(cboEffDat.Text, Date) <> System.DateTime.Now.ToShortDateString Then
            grdCUCALFML.Columns(i).ReadOnly = True
        Else
            grdCUCALFML.Columns(i).ReadOnly = False
        End If
        i = i + 1
        grdCUCALFML_ccf_cstbufper = i
        grdCUCALFML.Columns(i).HeaderText = "Costing Buffer"
        grdCUCALFML.Columns(i).Width = 100
        grdCUCALFML.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        If DateTime.Compare(CType(cboEffDat.Text, Date), System.DateTime.Now) < 0 And CType(cboEffDat.Text, Date) <> System.DateTime.Now.ToShortDateString Then
            grdCUCALFML.Columns(i).ReadOnly = True
        Else
            grdCUCALFML.Columns(i).ReadOnly = False
        End If
        i = i + 1
        grdCUCALFML_ccf_othper = i
        grdCUCALFML.Columns(i).HeaderText = "Others"
        grdCUCALFML.Columns(i).Width = 70
        grdCUCALFML.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        If DateTime.Compare(CType(cboEffDat.Text, Date), System.DateTime.Now) < 0 And CType(cboEffDat.Text, Date) <> System.DateTime.Now.ToShortDateString Then
            grdCUCALFML.Columns(i).ReadOnly = True
        Else
            grdCUCALFML.Columns(i).ReadOnly = False
        End If
        i = i + 1
        grdCUCALFML_ccf_pliper = i
        grdCUCALFML.Columns(i).HeaderText = "PLI"
        grdCUCALFML.Columns(i).Width = 60
        grdCUCALFML.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        If DateTime.Compare(CType(cboEffDat.Text, Date), System.DateTime.Now) < 0 And CType(cboEffDat.Text, Date) <> System.DateTime.Now.ToShortDateString Then
            grdCUCALFML.Columns(i).ReadOnly = True
        Else
            grdCUCALFML.Columns(i).ReadOnly = False
        End If
        i = i + 1
        grdCUCALFML_ccf_dmdper = i
        grdCUCALFML.Columns(i).HeaderText = "Defective Markdown"
        grdCUCALFML.Columns(i).Width = 150
        grdCUCALFML.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        If DateTime.Compare(CType(cboEffDat.Text, Date), System.DateTime.Now) < 0 And CType(cboEffDat.Text, Date) <> System.DateTime.Now.ToShortDateString Then
            grdCUCALFML.Columns(i).ReadOnly = True
        Else
            grdCUCALFML.Columns(i).ReadOnly = False
        End If
        i = i + 1
        grdCUCALFML_ccf_rbtper = i
        grdCUCALFML.Columns(i).HeaderText = "Rebate"
        grdCUCALFML.Columns(i).Width = 70
        grdCUCALFML.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        If DateTime.Compare(CType(cboEffDat.Text, Date), System.DateTime.Now) < 0 And CType(cboEffDat.Text, Date) <> System.DateTime.Now.ToShortDateString Then
            grdCUCALFML.Columns(i).ReadOnly = True
        Else
            grdCUCALFML.Columns(i).ReadOnly = False
        End If
        i = i + 1
        grdCUCALFML_ccf_pkgper = i
        grdCUCALFML.Columns(i).HeaderText = "pkgper"
        grdCUCALFML.Columns(i).Width = 70
        grdCUCALFML.Columns(i).ReadOnly = True
        grdCUCALFML.Columns(i).Visible = False
        i = i + 1
        grdCUCALFML_ccf_comper = i
        grdCUCALFML.Columns(i).HeaderText = "Commission"
        grdCUCALFML.Columns(i).Width = 90
        grdCUCALFML.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        If DateTime.Compare(CType(cboEffDat.Text, Date), System.DateTime.Now) < 0 And CType(cboEffDat.Text, Date) <> System.DateTime.Now.ToShortDateString Then
            grdCUCALFML.Columns(i).ReadOnly = True
        Else
            grdCUCALFML.Columns(i).ReadOnly = False
        End If
        i = i + 1
        grdCUCALFML_ccf_icmper = i
        grdCUCALFML.Columns(i).HeaderText = "icmper"
        grdCUCALFML.Columns(i).Width = 70
        grdCUCALFML.Columns(i).ReadOnly = True
        grdCUCALFML.Columns(i).Visible = False
        i = i + 1
        grdCUCALFML_ccf_subttl = i
        grdCUCALFML.Columns(i).HeaderText = "Sub Total%"
        grdCUCALFML.Columns(i).Width = 90
        grdCUCALFML.Columns(i).ReadOnly = True
        grdCUCALFML.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        i = i + 1
        grdCUCALFML.Columns(i).Visible = False
        i = i + 1
        grdCUCALFML.Columns(i).Visible = False
        i = i + 1
        grdCUCALFML.Columns(i).Visible = False
        i = i + 1
        grdCUCALFML.Columns(i).Visible = False
        i = i + 1
        grdCUCALFML.Columns(i).Visible = False
        i = i + 1
        grdCUCALFML_ccf_effdat = i
        grdCUCALFML.Columns(i).Visible = False
        i = i + 1
        grdCUCALFML.Columns(i).Visible = False


        



        If gsUsrGrp <> "CED-S" And gsUsrGrp <> "CED-R" And gsUsrGrp <> "CED-G" And gsUsrGrp <> "CED-G2" And gsUsrGrp <> "MIS-S" And Mid(gsUsrGrp, 1, 3) <> "EDP" Then
            grdCUCALFML.ReadOnly = True
        End If


        'Dim ii As Integer

        'For ii = 0 To grdCUCALFML.Columns.Count - 1

        '    grdCUCALFML.Columns(ii).SortMode = DataGridViewColumnSortMode.NotSortable

        'Next ii
    End Sub

    Private Sub cmdAddEffDat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddEffDat.Click

        If rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cusno").ToString = "" Then
            MsgBox("Please create customer first.")
            Exit Sub
        End If


        Dim drr() As DataRow
        Dim dr As DataRow
        Dim dt As DataTable
        Dim i As Integer
        If cmdAddEffDat.Text = "Add Eff Date" Then
            txtEffDat.Visible = True
            cboEffDat.Visible = False
            'chkEff.Checked = False
            txtEffDat.Clear()
            txtEffDat.Focus()
            If cboEffDat.Text <> "" Then
                Dim dv As DataView = rs_CUCALFML.Tables("RESULT").DefaultView
                '            dv.RowFilter = "ccf_latest = #" & cboEffDat.Text & "#"
                dv.RowFilter = "ccf_effdat = #" & cboEffDat.Text & "#"
                Call SetgrdCUCALFML(dv)
            End If
            cmdAddEffDat.Text = "OK"
            cmdEffdatExit.Enabled = True
            cmdEffdatSave.Enabled = False
        Else
            If txtEffDat.Text = "" Then
                txtEffDat.Clear()
                txtEffDat.Focus()
                MsgBox("Effective date is empty, please input again!")

            ElseIf Not IsDate(txtEffDat.Text) Or Len(txtEffDat.Text) < 10 Then
                txtEffDat.Clear()
                txtEffDat.Focus()
                MsgBox("Effective date is not a valid date, please input again!")

            ElseIf DateTime.Compare(CType(txtEffDat.Text, Date), System.DateTime.Now) < 0 And CType(txtEffDat.Text, Date) <> System.DateTime.Now.ToShortDateString Then
                txtEffDat.Clear()
                txtEffDat.Focus()
                MsgBox("Effective date cannot earlier than today date, please input again!")

            Else
                dt = rs_CUCALFML.Tables("RESULT")
                drr = dt.Select("ccf_effdat = #" & txtEffDat.Text & "#")
                If drr.Length > 0 Then
                    txtEffDat.Clear()
                    txtEffDat.Focus()
                    MsgBox("Effective date is duplicate, please input again!")

                Else
                    If cboEffDat.Text <> "" Then
                        dt = rs_CUCALFML.Tables("RESULT")
                        ' drr = dt.Select("ccf_latest = 'Y'")
                        drr = dt.Select("ccf_effdat = #" & cboEffDat.Text & "#")
                        For i = 0 To drr.Length - 1
                            dr = dt.NewRow
                            dr.Item("DEL") = ""
                            dr.Item("ccf_cocde") = drr(i).Item("ccf_cocde")
                            dr.Item("ccf_cus1no") = drr(i).Item("ccf_cus1no")
                            dr.Item("ccf_cus2no") = drr(i).Item("ccf_cus2no")
                            dr.Item("ccf_cat") = drr(i).Item("ccf_cat")
                            dr.Item("ccf_venno") = drr(i).Item("ccf_venno")
                            dr.Item("ccf_prctrm") = drr(i).Item("ccf_prctrm")
                            dr.Item("ccf_trantrm") = drr(i).Item("ccf_trantrm")

                            dr.Item("ccf_curcde") = drr(i).Item("ccf_curcde")
                            dr.Item("ccf_cumu") = drr(i).Item("ccf_cumu")
                            dr.Item("ccf_pm") = drr(i).Item("ccf_pm")
                            dr.Item("ccf_cush") = drr(i).Item("ccf_cush")
                            dr.Item("ccf_thccusper") = drr(i).Item("ccf_thccusper")
                            dr.Item("ccf_upsper") = drr(i).Item("ccf_upsper")
                            dr.Item("ccf_labper") = drr(i).Item("ccf_labper")
                            dr.Item("ccf_faper") = drr(i).Item("ccf_faper")

                            dr.Item("ccf_cstbufper") = drr(i).Item("ccf_cstbufper")
                            dr.Item("ccf_othper") = drr(i).Item("ccf_othper")
                            dr.Item("ccf_pliper") = drr(i).Item("ccf_pliper")
                            dr.Item("ccf_dmdper") = drr(i).Item("ccf_dmdper")
                            dr.Item("ccf_rbtper") = drr(i).Item("ccf_rbtper")
                            dr.Item("ccf_pkgper") = drr(i).Item("ccf_pkgper")
                            dr.Item("ccf_comper") = drr(i).Item("ccf_comper")
                            dr.Item("ccf_icmper") = drr(i).Item("ccf_icmper")
                            dr.Item("ccf_subttl") = drr(i).Item("ccf_subttl")
                            dr.Item("ccf_creusr") = "~*ADD*~"
                            dr.Item("ccf_updusr") = "~*ADD*~"
                            dr.Item("ccf_credat") = drr(i).Item("ccf_credat")
                            dr.Item("ccf_upddat") = drr(i).Item("ccf_upddat")
                            dr.Item("ccf_latest") = "Y"
                            dr.Item("ccf_effdat") = CType(txtEffDat.Text, DateTime)

                            'If chkEff.Checked = True Then

                            dr.Item("ccf_iseff") = "Y"

                            'Else
                            'dr.Item("ccf_iseff") = "N"
                            'End If
                            dt.Rows.Add(dr)
                        Next
                    End If
                    For ii As Integer = 0 To rs_CUCALFML.Tables("RESULT").Rows.Count - 1
                        If rs_CUCALFML.Tables("RESULT").Rows(ii).Item("ccf_effdat") <> CType(txtEffDat.Text, DateTime) Then
                            rs_CUCALFML.Tables("RESULT").Rows(ii).Item("ccf_latest") = "N"
                            rs_CUCALFML.Tables("RESULT").Rows(ii).Item("ccf_iseff") = "N"
                        End If
                    Next

                    FRecordstatus = True

                    'If chkEff.Checked = True Then '*************************CARE*********

                    '    Dim ii As Integer
                    '    For ii = 0 To rs_CUCALFML.Tables("RESULT").Rows.Count - 1
                    '        If rs_CUCALFML.Tables("RESULT").Rows(ii).Item("ccf_latest") = "N" And _
                    '        rs_CUCALFML.Tables("RESULT").Rows(ii).Item("ccf_effdat") <> CType(txtEffDat.Text, DateTime) And _
                    '        rs_CUCALFML.Tables("RESULT").Rows(ii).Item("ccf_creusr") <> "~*ADD*~" Then
                    '            rs_CUCALFML.Tables("RESULT").Rows(ii).Item("ccf_iseff") = "N"
                    '            rs_CUCALFML.Tables("RESULT").Rows(ii).Item("ccf_creusr") = "~*UPD*~"
                    '        ElseIf rs_CUCALFML.Tables("RESULT").Rows(ii).Item("ccf_latest") = "N" And _
                    '    rs_CUCALFML.Tables("RESULT").Rows(ii).Item("ccf_effdat") <> CType(txtEffDat.Text, DateTime) And _
                    '    rs_CUCALFML.Tables("RESULT").Rows(ii).Item("ccf_creusr") = "~*ADD*~" Then
                    '            rs_CUCALFML.Tables("RESULT").Rows(ii).Item("ccf_iseff") = "N"

                    '        End If
                    '    Next

                    'End If


                    ''  dt = rs_curEffDat.Tables("RESULT")
                    'drr = dt.Select("yce_iseff = 'Y'")
                    'For i = 0 To drr.Length - 1
                    '    dr = dt.NewRow
                    '    dr.Item("yce_effdat") = CType(txtEffDat.Text, DateTime)
                    '    If chkEff.Checked Then
                    '        dr.Item("yce_iseff") = "Y"
                    '        drr(i).Item("yce_iseff") = "N"
                    '    Else
                    '        dr.Item("yce_iseff") = "N"
                    '    End If
                    '    dt.Rows.Add(dr)
                    'Next

                    cboEffDat.Items.Add(txtEffDat.Text)
                    cboEffDat.SelectedIndex = cboEffDat.Items.Count - 1
                    cmdAddEffDat.Text = "Add Eff Date"
                    cmdAddEffDat.Enabled = False
                    cmdEffdatExit.Enabled = False
                    txtEffDat.Visible = False
                    cboEffDat.Visible = True
                    chkEff.Checked = True
                    cmdEffdatSave.Enabled = True
                    End If
            End If

        End If
    End Sub

    Private Sub cboEffDat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEffDat.SelectedIndexChanged
        Dim dr() As DataRow

        If Not cboEffDat.SelectedItem Is Nothing Then
            dr = rs_CUCALFML.Tables("RESULT").Select("ccf_iseff = 'Y' and ccf_effdat = #" & cboEffDat.SelectedItem & "#")

            If DateTime.Compare(CType(cboEffDat.SelectedItem, Date), System.DateTime.Now) < 0 And CType(cboEffDat.SelectedItem, Date) <> System.DateTime.Now.ToShortDateString Then
                cmdaddFormula.Enabled = False
            Else
                cmdaddFormula.Enabled = Enq_right_local
            End If

            'If dr.Length > 0 Then
            '    Me.chkEff.Checked = True
            '    cmdaddFormula.Enabled = True
            '    'cmdAddEffDat.Enabled = True
            'Else
            '    Me.chkEff.Checked = False
            '    cmdaddFormula.Enabled = False
            '    'cmdAddEffDat.Enabled = False
            'End If

            Dim dv As DataView = rs_CUCALFML.Tables("RESULT").DefaultView
            dv.RowFilter = "ccf_effdat = #" & cboEffDat.SelectedItem & "#"
            dv.Sort = "ccf_cat,ccf_venno,ccf_prctrm,ccf_trantrm ASC"



            Call SetgrdCUCALFML(dv)
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEffdatExit.Click
        'Panel1.Visible = False
        cboEffDat.Visible = True
        txtEffDat.Visible = False
        cmdAddEffDat.Text = "Add Eff Date"
        cmdEffdatExit.Enabled = False


        'Dim dv As DataView = rs_CUCALFML.Tables("RESULT").DefaultView
        'dv.RowFilter = "ccf_latest = '@#$%^&*('"

        'Call SetgrdCUCALFML(dv)

        'If cboEffDat.Items.Count > 0 Then
        '    cboEffDat.SelectedIndex = 0
        'End If


        'chkEff.Checked = False
    End Sub

   

    Private Sub chkEff_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkEff.Click

        If cboEffDat.Visible = False Then
            Exit Sub
        End If

        If Not cboEffDat.SelectedItem Is Nothing Then
            If chkEff.Checked Then
                For Each dr As DataRow In rs_CUCALFML.Tables("RESULT").Rows
                    If dr.Item("ccf_effdat") = CType(cboEffDat.SelectedItem, DateTime) And dr.Item("ccf_latest") <> "Y" Then
                        dr.Item("ccf_iseff") = "Y"
                        If dr.Item("ccf_creusr") <> "~*ADD*~" Then
                            dr.Item("ccf_creusr") = "~*UPD*~"
                        End If
                    Else
                        dr.Item("ccf_iseff") = "N"
                        If dr.Item("ccf_creusr") <> "~*ADD*~" Then
                            dr.Item("ccf_creusr") = "~*UPD*~"
                        End If
                    End If
                Next

                
            Else
                For Each dr As DataRow In rs_CUCALFML.Tables("RESULT").Rows
                    If dr.Item("ccf_effdat") = CType(cboEffDat.SelectedItem, DateTime) Then
                        dr.Item("ccf_iseff") = "N"
                        If dr.Item("ccf_creusr") <> "~*ADD*~" Then
                            dr.Item("ccf_creusr") = "~*UPD*~"
                        End If
                    End If
                Next

                
            End If
        End If

    End Sub

   

    


    Private Function save_CUCALFML_2() As Boolean

        Me.Cursor = Cursors.WaitCursor

        If rs_CUCALFML.Tables("RESULT").Rows.Count = 0 Then
            Me.Cursor = Cursors.Default
            save_CUCALFML_2 = True
            Exit Function
        End If


        Dim ccf_del As String
        Dim ccf_cocde As String
        Dim ccf_cus1no As String
        Dim ccf_cus2no As String
        Dim ccf_cat As String
        Dim ccf_venno As String
        Dim ccf_prctrm As String
        Dim ccf_trantrm As String
        Dim ccf_curcde As String
        Dim ccf_cumu As Decimal
        Dim ccf_pm As Decimal
        Dim ccf_cush As Decimal
        Dim ccf_thccusper As Decimal
        Dim ccf_upsper As Decimal
        Dim ccf_labper As Decimal
        Dim ccf_faper As Decimal
        Dim ccf_cstbufper As Decimal
        Dim ccf_othper As Decimal
        Dim ccf_pliper As Decimal
        Dim ccf_dmdper As Decimal
        Dim ccf_rbtper As Decimal
        Dim ccf_pkgper As Decimal
        Dim ccf_comper As Decimal
        Dim ccf_icmper As Decimal
        Dim ccf_creusr As String
        Dim ccf_latest As String
        Dim ccf_effdat As DateTime
        Dim ccf_iseff As String







        Dim i As Integer





        For i = 0 To rs_CUCALFML.Tables("RESULT").Rows.Count - 1
            '  If rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_latest") = "Y" Then
            ccf_del = rs_CUCALFML.Tables("RESULT").Rows(i).Item("DEL")
            ccf_cocde = ""
            ccf_cus1no = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_cus1no")
            ccf_cus2no = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_cus2no")
            ccf_cat = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_cat")
            ccf_venno = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_venno")
            ccf_prctrm = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_prctrm")
            ccf_trantrm = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_trantrm")
            ccf_curcde = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_curcde")
            ccf_cumu = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_cumu") / 100
            ccf_pm = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_pm") / 100
            ccf_cush = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_cush") / 100
            ccf_thccusper = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_thccusper") / 100
            ccf_upsper = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_upsper") / 100
            ccf_labper = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_labper") / 100
            ccf_faper = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_faper") / 100
            ccf_cstbufper = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_cstbufper") / 100
            ccf_othper = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_othper") / 100
            ccf_pliper = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_pliper") / 100
            ccf_dmdper = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_dmdper") / 100
            ccf_rbtper = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_rbtper") / 100
            ccf_pkgper = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_pkgper") / 100
            ccf_comper = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_comper") / 100
            ccf_icmper = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_icmper") / 100
            ccf_creusr = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_creusr")
            ccf_latest = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_latest")
            ccf_effdat = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_effdat")
            ccf_iseff = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_iseff")



            If ccf_del = "Y" Then



                gspStr = "sp_physical_delete_CUCALFML_EFFDAT '" & ccf_cocde & "','" & ccf_cus1no & "','" & ccf_cus2no & "','" & ccf_cat & "','" & _
                          ccf_venno & "','" & ccf_prctrm & "','" & ccf_trantrm & "','" & ccf_effdat & "'"


                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUCALFML_2 sp_physical_delete_CUCALFML_EFFDAT :" & rtnStr)
                    save_CUCALFML_2 = False
                    Me.Cursor = Cursors.Default
                    Exit Function
                End If

            ElseIf ccf_creusr = "~*ADD*~" Then ' ElseIf ccf_latest = "Y" And ccf_creusr = "~*ADD*~" Then


                gspStr = "sp_insert_CUCALFML_EFFDAT '" & ccf_cocde & "','" & ccf_cus1no & "','" & ccf_cus2no & "','" & ccf_cat & "','" & _
                          ccf_venno & "','" & ccf_prctrm & "','" & ccf_trantrm & "','" & ccf_curcde & "'," & ccf_cumu & "," & _
                          ccf_pm & "," & ccf_cush & "," & ccf_thccusper & "," & ccf_upsper & "," & ccf_labper & "," & ccf_faper & "," & _
                          ccf_cstbufper & "," & ccf_othper & "," & ccf_pliper & "," & ccf_dmdper & "," & ccf_rbtper & "," & ccf_pkgper & "," & _
                          ccf_comper & "," & ccf_icmper & ",'" & ccf_effdat & "','" & ccf_iseff & "','" & gsUsrID & "'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUCALFML_2 sp_insert_CUCALFML_EFFDAT :" & rtnStr)
                    save_CUCALFML_2 = False
                    Me.Cursor = Cursors.Default
                    Exit Function
                End If


            ElseIf ccf_creusr = "~*UPD*~" Then ' ElseIf ccf_latest = "Y" And ccf_creusr = "~*UPD*~" Then


                gspStr = "sp_update_CUCALFML_EFFDAT '" & ccf_cocde & "','" & ccf_cus1no & "','" & ccf_cus2no & "','" & ccf_cat & "','" & _
                          ccf_venno & "','" & ccf_prctrm & "','" & ccf_trantrm & "','" & ccf_curcde & "'," & ccf_cumu & "," & _
                          ccf_pm & "," & ccf_cush & "," & ccf_thccusper & "," & ccf_upsper & "," & ccf_labper & "," & ccf_faper & "," & _
                          ccf_cstbufper & "," & ccf_othper & "," & ccf_pliper & "," & ccf_dmdper & "," & ccf_rbtper & "," & ccf_pkgper & "," & _
                          ccf_comper & "," & ccf_icmper & ",'" & ccf_effdat & "','" & ccf_iseff & "','" & gsUsrID & "'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUCALFML_2 sp_insert_CUCALFML_EFFDAT :" & rtnStr)
                    save_CUCALFML_2 = False
                    Me.Cursor = Cursors.Default
                    Exit Function
                End If

            End If
            'End If
        Next

        save_CUCALFML_2 = True
        Me.Cursor = Cursors.Default
    End Function

    Private Sub cmdEffdatSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEffdatSave.Click


        If save_CUCALFML_2() = True Then
            MsgBox("Save Complete")

            cboEffDat.Visible = True
            txtEffDat.Visible = False
            cmdAddEffDat.Text = "Add Eff Date"
            cmdAddEffDat.Enabled = True
            chkEff.Checked = False
            FRecordstatus = False


            gspStr = "sp_select_CUCALFML '','" & txtCusno.Text & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_CUCALFML, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cmdEffdatSave_Click sp_select_CUCALFML :" & rtnStr)
                Exit Sub
            End If


            gspStr = "sp_select_Distinct_CUCALFML '','" & txtCusno.Text & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_CUCALFML_Distinct, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading cmdEffdatSave_Click sp_select_Distinct_CUCALFML :" & rtnStr)
                Exit Sub
            End If


            Dim i As Integer = 0
            For i = 0 To rs_CUCALFML.Tables("RESULT").Columns.Count - 1
                rs_CUCALFML.Tables("RESULT").Columns(i).ReadOnly = False
            Next


            Dim tmpstr As String

            'cboCUCALFMLKey.Items.Clear()
            'For i = 0 To rs_CUCALFML.Tables("RESULT").Rows.Count - 1
            '    If rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_latest") = "Y" Then
            '        tmpstr = rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_cat") & " / " & _
            '                    rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_venno") & " / " & _
            '                    rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_prctrm") & " / " & _
            '                    rs_CUCALFML.Tables("RESULT").Rows(i).Item("ccf_trantrm")
            '        cboCUCALFMLKey.Items.Add(tmpstr)
            '    End If
            'Next i

            'If cboCUCALFMLKey.Items.Count > 0 Then
            '    cboCUCALFMLKey.SelectedIndex = 0
            'End If


            cboEffDat.Items.Clear()
            For i = 0 To rs_CUCALFML_Distinct.Tables("RESULT").Rows.Count - 1
                If rs_CUCALFML_Distinct.Tables("RESULT").Rows(i).Item("ccf_effdat") <> "1900-01-01" Then
                    cboEffDat.Items.Add(Format(rs_CUCALFML_Distinct.Tables("RESULT").Rows(i).Item("ccf_effdat"), "MM/dd/yyyy"))

                End If
            Next


            If cboEffDat.Items.Count > 0 Then
                cboEffDat.SelectedIndex = 0
            End If



            'Dim dv As DataView = rs_CUCALFML.Tables("RESULT").DefaultView
            'dv.RowFilter = "ccf_latest = '@#$%^&*('"

            'Call SetgrdCUCALFML(dv)

            grdCUCALFML.DataSource = Nothing

            Dim dv_CUCALFML As DataView
            'dv_CUCALFML = rs_CUCALFML.Tables("RESULT").Select("ccf_effdat <= #" & DateTime.Now & "#")
            dv_CUCALFML = rs_CUCALFML.Tables("RESULT").DefaultView
            dv_CUCALFML.RowFilter = "ccf_effdat <= #" & DateTime.Now & "#"
            dv_CUCALFML.Sort = "ccf_effdat desc"
            If dv_CUCALFML.Count <> 0 Then
                Dim latestdate As String
                latestdate = Format(dv_CUCALFML(0)("ccf_effdat"), "MM/dd/yyyy")

                cboEffDat.Text = latestdate
            End If
            If cboEffDat.Text <> "" Then
                If DateTime.Compare(CType(cboEffDat.SelectedItem, Date), System.DateTime.Now) < 0 And CType(cboEffDat.SelectedItem, Date) <> System.DateTime.Now.ToShortDateString Then
                    cmdaddFormula.Enabled = False
                Else
                    cmdaddFormula.Enabled = True
                End If
            Else
                cmdaddFormula.Enabled = False
            End If


        End If
    End Sub

    Private Sub chkEff_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEff.CheckedChanged

    End Sub

    Private Sub grdCUCALFML_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCUCALFML.CellClick
        If chkEff.Checked = False Then
            Exit Sub
        End If


    End Sub

    Private Sub grdCUCALFML_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCUCALFML.CellContentClick

    End Sub

    Private Sub grdCUCALFML_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCUCALFML.CellDoubleClick

        'If chkEff.Checked = False Then
        '    Exit Sub
        'End If

        'If e.ColumnIndex <> -1 Then
        '    Exit Sub
        'End If


        If e.RowIndex = -1 Then
            Exit Sub
        End If

        Dim iCol As Integer = grdCUCALFML.CurrentCell.ColumnIndex
        Dim iRow As Integer = grdCUCALFML.CurrentCell.RowIndex

        Dim ccf_cus2no As String = grdCUCALFML.Item(grdCUCALFML_ccf_cus2no, iRow).Value
        Dim ccf_cat As String = grdCUCALFML.Item(grdCUCALFML_ccf_cat, iRow).Value
        Dim ccf_venno As String = grdCUCALFML.Item(grdCUCALFML_ccf_venno, iRow).Value
        Dim ccf_prctrm As String = grdCUCALFML.Item(grdCUCALFML_ccf_prctrm, iRow).Value
        Dim ccf_trantrm As String = grdCUCALFML.Item(grdCUCALFML_ccf_trantrm, iRow).Value
        Dim ccf_effdat As DateTime = grdCUCALFML.Item(grdCUCALFML_ccf_effdat, iRow).Value


        Select Case e.ColumnIndex

            Case grdCUCALFML_DEL


                If gsUsrGrp <> "CED-S" And gsUsrGrp <> "CED-R" And gsUsrGrp <> "CED-G" And gsUsrGrp <> "CED-G2" And gsUsrGrp <> "MIS-S" Then
                    Exit Sub
                End If



                If DateTime.Compare(CType(ccf_effdat, Date), System.DateTime.Now) < 0 And CType(ccf_effdat, Date) <> System.DateTime.Now.ToShortDateString Then

                Else
                    If rs_CUCALFML.Tables("RESULT").Rows.Count > 0 Then
                        Dim curvalue As String
                        curvalue = grdCUCALFML.CurrentCell.Value
                        If Trim(curvalue) = "" Then


                            grdCUCALFML.Item(grdCUCALFML_DEL, iRow).Value = "Y"



                        Else
                            grdCUCALFML.Item(grdCUCALFML_DEL, iRow).Value = ""

                        End If
                    End If
                End If

               


            Case -1

                If rs_CUCALFML.Tables("RESULT").Rows.Count > 0 Then
                    'Dim tmp_cat As String
                    'Dim tmp_ven As String
                    'Dim tmp_prctrm As String
                    'Dim tmp_trantrm As String

                    'tmp_cat = Split(cboCUCALFMLKey.Text, " / ")(0)
                    'tmp_ven = Split(cboCUCALFMLKey.Text, " / ")(1)
                    'tmp_prctrm = Split(cboCUCALFMLKey.Text, " / ")(2)
                    'tmp_trantrm = Split(cboCUCALFMLKey.Text, " / ")(3)

                    Dim dr() As DataRow
                    dr = rs_CUCALFML.Tables("RESULT").Select("ccf_cat = '" & ccf_cat & "' and ccf_venno = '" & ccf_venno & "' and ccf_prctrm = '" & ccf_prctrm & "' and ccf_trantrm = '" & ccf_trantrm & "' and ccf_effdat = '" & ccf_effdat & "'") 'ccf_effdat = #" & txtEffDat.Text & "#"

                    If dr.Length >= 1 Then
                        txtCustMU.Text = dr(0).Item("ccf_cumu")
                        txtPM.Text = dr(0).Item("ccf_pm")
                        txtCush.Text = dr(0).Item("ccf_cush")

                        txtTHC.Text = dr(0).Item("ccf_thccusper")
                        txtUPS.Text = dr(0).Item("ccf_upsper")
                        txtLab.Text = dr(0).Item("ccf_labper")
                        txtFA.Text = dr(0).Item("ccf_faper")
                        txtCostBuf.Text = dr(0).Item("ccf_cstbufper")
                        txtOthers.Text = dr(0).Item("ccf_othper")
                        txtPLI.Text = dr(0).Item("ccf_pliper")
                        txtDefMD.Text = dr(0).Item("ccf_dmdper")
                        txtRebate.Text = dr(0).Item("ccf_rbtper")

                        txtSubTtl.Text = dr(0).Item("ccf_subttl")
                        txtComm.Text = dr(0).Item("ccf_comper")

                        cmdAddPri.Text = "U"

                        cboCUCALFMLKey.Visible = False

                        txtCubasfmltxt.Visible = True
                        cboPriPri.Visible = False
                        cboPriCate.Visible = False
                        cboPriVen.Visible = False
                        cboPriTran.Visible = False


                        cmdSavePri.Visible = False
                        cmdSavePri.Enabled = False
                        txtCustMU.ReadOnly = True
                        txtPM.ReadOnly = True
                        txtCush.ReadOnly = True

                        txtTHC.ReadOnly = True
                        txtUPS.ReadOnly = True
                        txtLab.ReadOnly = True
                        txtFA.ReadOnly = True
                        txtCostBuf.ReadOnly = True
                        txtOthers.ReadOnly = True
                        txtPLI.ReadOnly = True
                        txtDefMD.ReadOnly = True
                        txtRebate.ReadOnly = True

                        txtSubTtl.ReadOnly = True
                        txtComm.ReadOnly = True

                        cmdAddPri.Text = "U"

                        cboCUCALFMLKey.Visible = False

                        txtCubasfmltxt.Visible = True
                        cboPriPri.Visible = False
                        cboPriCate.Visible = False
                        cboPriVen.Visible = False
                        cboPriTran.Visible = False

                        'If chkEff.Checked = True Then
                        '    cmdSavePri.Enabled = True
                        '    txtCustMU.ReadOnly = False
                        '    txtPM.ReadOnly = False
                        '    txtCush.ReadOnly = False

                        '    txtTHC.ReadOnly = False
                        '    txtUPS.ReadOnly = False
                        '    txtLab.ReadOnly = False
                        '    txtFA.ReadOnly = False
                        '    txtCostBuf.ReadOnly = False
                        '    txtOthers.ReadOnly = False
                        '    txtPLI.ReadOnly = False
                        '    txtDefMD.ReadOnly = False
                        '    txtRebate.ReadOnly = False

                        '    txtSubTtl.ReadOnly = False
                        '    txtComm.ReadOnly = False

                        '    cmdAddPri.Text = "U"

                        '    cboCUCALFMLKey.Visible = False

                        '    txtCubasfmltxt.Visible = True
                        '    cboPriPri.Visible = False
                        '    cboPriCate.Visible = False
                        '    cboPriVen.Visible = False
                        '    cboPriTran.Visible = False
                        'ElseIf chkEff.Checked = False Then
                        '    cmdSavePri.Enabled = False
                        '    txtCustMU.ReadOnly = True
                        '    txtPM.ReadOnly = True
                        '    txtCush.ReadOnly = True

                        '    txtTHC.ReadOnly = True
                        '    txtUPS.ReadOnly = True
                        '    txtLab.ReadOnly = True
                        '    txtFA.ReadOnly = True
                        '    txtCostBuf.ReadOnly = True
                        '    txtOthers.ReadOnly = True
                        '    txtPLI.ReadOnly = True
                        '    txtDefMD.ReadOnly = True
                        '    txtRebate.ReadOnly = True

                        '    txtSubTtl.ReadOnly = True
                        '    txtComm.ReadOnly = True

                        '    cmdAddPri.Text = "U"

                        '    cboCUCALFMLKey.Visible = False

                        '    txtCubasfmltxt.Visible = True
                        '    cboPriPri.Visible = False
                        '    cboPriCate.Visible = False
                        '    cboPriVen.Visible = False
                        '    cboPriTran.Visible = False
                        'End If


                        Panel2.Visible = True
                        Panel2.Width = 862
                        Panel2.Height = 396
                        Panel2.Top = 6
                        Panel2.Left = 3

                        txtCubasfmltxt.Text = ccf_cat & " / " & ccf_venno & " / " & ccf_prctrm & " / " & ccf_trantrm
                        txteffdate.Text = ccf_effdat
                    End If
                End If
        End Select

        
    End Sub

    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdaddFormula.Click

        If rs_CUBASINF.Tables("RESULT").Rows(0).Item("cbi_cusno").ToString = "" Then
            MsgBox("Please create customer first.")
            Exit Sub
        End If

        'If chkEff.Checked = False Then
        '    MsgBox("Please select the date which is effective.")
        '    Exit Sub
        'End If

        If IsDate(cboEffDat.Text) = False Then
            MsgBox("Please select valid effective date")
            Exit Sub
        End If

        cboPriCate.Text = ""
        cboPriVen.Text = ""
        cboPriPri.Text = ""
        cboPriTran.Text = ""



        txtCubasfmltxt.Visible = False
        cboPriPri.Visible = True
        cboPriCate.Visible = True
        cboPriVen.Visible = True
        cboPriTran.Visible = True
        cmdSavePri.Visible = True
        cmdSavePri.Enabled = True

        txtCustMU.ReadOnly = False
        txtPM.ReadOnly = False
        txtCush.ReadOnly = False

        txtTHC.ReadOnly = False
        txtUPS.ReadOnly = False
        txtLab.ReadOnly = False
        txtFA.ReadOnly = False
        txtCostBuf.ReadOnly = False
        txtOthers.ReadOnly = False
        txtPLI.ReadOnly = False
        txtDefMD.ReadOnly = False
        txtRebate.ReadOnly = False

        txtSubTtl.ReadOnly = True
        txtComm.ReadOnly = False


        txteffdate.Text = cboEffDat.Text
        cmdAddPri.Text = "A"
        txtCustMU.Text = 0
        txtPM.Text = 0
        txtTHC.Text = 0
        txtUPS.Text = 0
        txtLab.Text = 0
        txtFA.Text = 0
        txtCostBuf.Text = 0
        txtOthers.Text = 0
        txtPLI.Text = 0
        txtDefMD.Text = 0
        txtRebate.Text = 0
        txtSubTtl.Text = 0
        txtCush.Text = 0
        txtComm.Text = 0
        Panel2.Visible = True
        Panel2.Width = 862
        Panel2.Height = 396
        Panel2.Top = 6
        Panel2.Left = 3

        FRecordstatus = True
    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Panel2.Visible = False
    End Sub

    Private Sub grdCUCALFML_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCUCALFML.CellEndEdit
        Dim ccf_cumu As Decimal
        Dim ccf_pm As Decimal

        Dim ccf_thccusper As Decimal
        Dim ccf_upsper As Decimal
        Dim ccf_labper As Decimal
        Dim ccf_faper As Decimal
        Dim ccf_cstbufper As Decimal
        Dim ccf_othper As Decimal
        Dim ccf_pliper As Decimal
        Dim ccf_dmdper As Decimal
        Dim ccf_rbtper As Decimal


        ccf_cumu = grdCUCALFML.Item(grdCUCALFML_ccf_cumu, grdCUCALFML.CurrentCell.RowIndex).Value
        ccf_pm = grdCUCALFML.Item(grdCUCALFML_ccf_pm, grdCUCALFML.CurrentCell.RowIndex).Value

        ccf_thccusper = grdCUCALFML.Item(grdCUCALFML_ccf_thccusper, grdCUCALFML.CurrentCell.RowIndex).Value
        ccf_upsper = grdCUCALFML.Item(grdCUCALFML_ccf_upsper, grdCUCALFML.CurrentCell.RowIndex).Value

        ccf_labper = grdCUCALFML.Item(grdCUCALFML_ccf_labper, grdCUCALFML.CurrentCell.RowIndex).Value
        ccf_faper = grdCUCALFML.Item(grdCUCALFML_ccf_faper, grdCUCALFML.CurrentCell.RowIndex).Value
        ccf_cstbufper = grdCUCALFML.Item(grdCUCALFML_ccf_cstbufper, grdCUCALFML.CurrentCell.RowIndex).Value
        ccf_othper = grdCUCALFML.Item(grdCUCALFML_ccf_othper, grdCUCALFML.CurrentCell.RowIndex).Value
        ccf_pliper = grdCUCALFML.Item(grdCUCALFML_ccf_pliper, grdCUCALFML.CurrentCell.RowIndex).Value
        ccf_dmdper = grdCUCALFML.Item(grdCUCALFML_ccf_dmdper, grdCUCALFML.CurrentCell.RowIndex).Value
        ccf_rbtper = grdCUCALFML.Item(grdCUCALFML_ccf_rbtper, grdCUCALFML.CurrentCell.RowIndex).Value


        grdCUCALFML.Item("ccf_subttl", grdCUCALFML.CurrentCell.RowIndex).Value = ccf_cumu + ccf_pm + ccf_thccusper + ccf_upsper + ccf_labper + ccf_faper + _
        ccf_cstbufper + ccf_othper + ccf_pliper + ccf_dmdper + ccf_rbtper



    End Sub

    Private Sub grdCUCALFML_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdCUCALFML.CellValidating
        Dim row As DataGridViewRow = grdCUCALFML.CurrentRow
        Dim strNewVal As String

        strNewVal = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim

        If row.Cells(e.ColumnIndex).IsInEditMode Then
            Select Case e.ColumnIndex

                Case grdCUCALFML_ccf_cumu, grdCUCALFML_ccf_pm, grdCUCALFML_ccf_cush, grdCUCALFML_ccf_thccusper, grdCUCALFML_ccf_upsper, _
                    grdCUCALFML_ccf_labper, grdCUCALFML_ccf_faper, grdCUCALFML_ccf_cstbufper, grdCUCALFML_ccf_othper, _
                    grdCUCALFML_ccf_pliper, grdCUCALFML_ccf_dmdper, grdCUCALFML_ccf_rbtper, grdCUCALFML_ccf_comper



                    If Not IsNumeric(strNewVal) Then
                        MsgBox("Invalid Quantity!")
                        e.Cancel = True
                        Exit Sub
                    End If




 

            End Select

        End If
    End Sub

    Private Sub grdCUCALFML_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdCUCALFML.EditingControlShowing
       

        If grdCUCALFML.Item("ccf_creusr", grdCUCALFML.CurrentCell.RowIndex).Value <> "~*ADD*~" Then
            grdCUCALFML.Item("ccf_creusr", grdCUCALFML.CurrentCell.RowIndex).Value = "~*UPD*~"
        End If

        FRecordstatus = True
    End Sub

    Private Sub txtEffDat_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtEffDat.MaskInputRejected

    End Sub

    Private Sub optCFSyes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCFSyes.CheckedChanged

    End Sub

    Private Sub optCFSNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCFSNo.CheckedChanged

    End Sub

    Private Sub BaseTabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BaseTabControl1.SelectedIndexChanged
        If BaseTabControl1.SelectedIndex = 4 Then
            mmdSave.Enabled = False
        Else
            mmdSave.Enabled = Enq_right_local 'True
        End If
    End Sub

    Private Sub grdShipping_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles grdShipping.DataError

    End Sub

    Private Sub grdCusBufSetup_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCusBufSetup.CellClick
        If grdCusBufSetup.RowCount = 0 Then
            Exit Sub
        End If
        If cboStatus.Text <> "A - Active" Then
            Exit Sub
        End If

        Dim iCol As Integer = grdCusBufSetup.CurrentCell.ColumnIndex
        Dim iRow As Integer = grdCusBufSetup.CurrentCell.RowIndex

        Select Case grdCusBufSetup.CurrentCell.ColumnIndex
            Case grdCusBufSetup_csf_venno
                If grdCusBufSetup.Rows(grdCusBufSetup.CurrentCell.RowIndex).Cells("csf_creusr").Value.ToString <> "~*ADD*~" Or _
                                  grdCusBufSetup.Item(grdCusBufSetup_csf_venno, iRow).Value = "INT - Internal Vendor" Or grdCusBufSetup.Item(grdCusBufSetup_csf_venno, iRow).Value = "EXT - External Vendor" Then
                    Exit Sub
                End If
                comboBoxCell(grdCusBufSetup, "Vendor")
        End Select
    End Sub


    Private Sub grdCusBufSetup_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdCusBufSetup.GotFocus
        Got_Focus_Grid = "CusBufSetup"
    End Sub


    Private Sub grdCusBufSetup_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCusBufSetup.CellDoubleClick
        If grdCusBufSetup.RowCount = 0 Then
            Exit Sub
        End If
        If cboStatus.Text <> "A - Active" Then
            Exit Sub
        End If

        Dim iCol As Integer = grdCusBufSetup.CurrentCell.ColumnIndex
        Dim iRow As Integer = grdCusBufSetup.CurrentCell.RowIndex
        Dim curvalue As String
        curvalue = grdCusBufSetup.CurrentCell.Value

        Select Case grdCusBufSetup.CurrentCell.ColumnIndex
            Case grdCusBufSetup_csf_venno
                If grdCusBufSetup.Rows(grdCusBufSetup.CurrentCell.RowIndex).Cells("csf_creusr").Value.ToString <> "~*ADD*~" Or _
                    grdCusBufSetup.Item(grdCusBufSetup_csf_venno, iRow).Value = "INT - Internal Vendor" Or grdCusBufSetup.Item(grdCusBufSetup_csf_venno, iRow).Value = "EXT - External Vendor" Then
                    Exit Sub
                End If
                comboBoxCell(grdCusBufSetup, "Vendor")
            Case grdCusBufSetup_DEL
                If grdCusBufSetup.Item(grdCusBufSetup_csf_venno, iRow).Value = "INT - Internal Vendor" Or grdCusBufSetup.Item(grdCusBufSetup_csf_venno, iRow).Value = "EXT - External Vendor" Then
                    grdCusBufSetup.Item(grdCusBufSetup_DEL, iRow).Value = ""
                ElseIf curvalue = "Y" Then
                    grdCusBufSetup.Item(grdCusBufSetup_DEL, iRow).Value = ""
                Else
                    grdCusBufSetup.Item(grdCusBufSetup_DEL, iRow).Value = "Y"
                End If
        End Select

        If grdCusBufSetup.Item(grdCusBufSetup_csf_creusr, iRow).Value <> "~*ADD*~" Then
            grdCusBufSetup.Item(grdCusBufSetup_csf_creusr, iRow).Value = "~*UPD*~"
        End If

    End Sub

    Private Sub grdCusBufSetup_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdCusBufSetup.CellValidating
        Dim row As DataGridViewRow = grdCusBufSetup.CurrentRow
        Dim strNewVal As String

        strNewVal = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim

        If row.Cells(e.ColumnIndex).IsInEditMode Then
            If e.ColumnIndex = grdCusBufSetup_csf_venno Then
                Dim tmp_venno As String

                tmp_venno = strNewVal

                For Each drr As DataGridViewRow In grdCusBufSetup.Rows
                    If drr.Index <> e.RowIndex Then
                        If drr.Cells("csf_venno").Value.ToString.ToUpper = tmp_venno.ToUpper Then
                            MsgBox("Duplicated Vendor Code!")
                            e.Cancel = True
                            Exit For
                        End If
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub grdCusBufSetup_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdCusBufSetup.EditingControlShowing
        If grdCusBufSetup.RowCount = 0 Then
            Exit Sub
        End If

        e.CellStyle.BackColor = Color.White

        Select Case grdCusBufSetup.CurrentCell.ColumnIndex
            Case grdCusBufSetup_csf_shpstrbuf, grdCusBufSetup_csf_shpendbuf, grdCusBufSetup_csf_cancelbuf
                Dim txtbox As TextBox = CType(e.Control, TextBox)
                If Not (txtbox Is Nothing) Then
                    AddHandler txtbox.KeyPress, AddressOf txt_grdCusBufSetup_KeyPress
                    AddHandler txtbox.TextChanged, AddressOf txt_grdCusBufSetup_TextChanged
                End If
        End Select

        If grdCusBufSetup.Item(grdCusBufSetup_csf_creusr, grdCusBufSetup.CurrentCell.RowIndex).Value <> "~*ADD*~" Then
            grdCusBufSetup.Item(grdCusBufSetup_csf_creusr, grdCusBufSetup.CurrentCell.RowIndex).Value = "~*UPD*~"
            Recordstatus = True
        End If

    End Sub

    Private Sub txt_grdCusBufSetup_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim iRow As Integer = grdCusBufSetup.CurrentCell.RowIndex
        Dim iCol As Integer = grdCusBufSetup.CurrentCell.ColumnIndex

        Dim curvalue As String = grdCusBufSetup.CurrentCell.EditedFormattedValue

        Select Case grdCusBufSetup.CurrentCell.ColumnIndex
            Case grdCusBufSetup_csf_shpstrbuf, grdCusBufSetup_csf_shpendbuf, grdCusBufSetup_csf_cancelbuf

                ' Check Number
                If Not (e.KeyChar = vbBack Or (e.KeyChar.ToString() >= "0" And e.KeyChar.ToString() <= "9")) Then
                    e.KeyChar = ""
                Else
                    If curvalue.IndexOf(".") > 0 And e.KeyChar.ToString() = "." Then
                        e.KeyChar = ""
                    End If
                End If
                flag_grdCusBufSetup_keypress = True
        End Select


    End Sub


    Private Sub txt_grdCusBufSetup_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim iRow As Integer = grdCusBufSetup.CurrentCell.RowIndex
        Dim iCol As Integer = grdCusBufSetup.CurrentCell.ColumnIndex

        Dim curvalue As String = grdCusBufSetup.CurrentCell.EditedFormattedValue
        Dim i As Integer

        Select Case grdCusBufSetup.CurrentCell.ColumnIndex
            Case grdCusBufSetup_csf_shpstrbuf, grdCusBufSetup_csf_shpendbuf, grdCusBufSetup_csf_cancelbuf

                If flag_grdCusBufSetup_keypress = True Then
                    flag_grdCusBufSetup_keypress = False
                End If
        End Select
    End Sub



    Private Function save_CUSHPFML() As Boolean
        If rs_CUSHPFML.Tables("RESULT").Rows.Count = 0 Then
            save_CUSHPFML = True
            Exit Function
        End If

        Dim DEL As String
        Dim CSF_COCDE As String
        Dim CSF_CUS1NO As String
        Dim CSF_CUS2NO As String
        Dim CSF_VENNO As String
        Dim CSF_SHPSTRBUF As String
        Dim CSF_SHPENDBUF As String
        Dim CSF_CANCELBUF As String
        Dim CSF_CREUSR As String




        Dim i As Integer

        For i = 0 To rs_CUSHPFML.Tables("RESULT").Rows.Count - 1
            DEL = rs_CUSHPFML.Tables("RESULT").Rows(i).Item("DEL")
            CSF_COCDE = rs_CUSHPFML.Tables("RESULT").Rows(i).Item("csf_cocde")
            CSF_CUS1NO = rs_CUSHPFML.Tables("RESULT").Rows(i).Item("csf_cus1no")
            CSF_CUS2NO = rs_CUSHPFML.Tables("RESULT").Rows(i).Item("csf_cus2no")
            CSF_VENNO = Split(rs_CUSHPFML.Tables("RESULT").Rows(i).Item("csf_venno"), " - ")(0)
            CSF_SHPSTRBUF = rs_CUSHPFML.Tables("RESULT").Rows(i).Item("csf_shpstrbuf")
            CSF_SHPENDBUF = rs_CUSHPFML.Tables("RESULT").Rows(i).Item("csf_shpendbuf")
            CSF_CANCELBUF = rs_CUSHPFML.Tables("RESULT").Rows(i).Item("csf_cancelbuf")
            CSF_CREUSR = rs_CUSHPFML.Tables("RESULT").Rows(i).Item("csf_creusr")

            gspStr = ""
            If DEL = "Y" Then
                If CSF_CREUSR = "~*UPD*~" Then
                    gspStr = "sp_physical_delete_CUSHPFML '','" & CSF_CUS1NO & "','" & CSF_CUS2NO & "','" & CSF_VENNO & "'"
                    rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                    If rtnLong <> RC_SUCCESS Then
                        MsgBox("Error on loading save_CUSHPFML sp_physical_delete_CUSHPFML:" & rtnStr)
                        save_CUSHPFML = False
                        Exit Function
                    End If
                End If
            ElseIf CSF_CREUSR = "~*ADD*~" Or CSF_CREUSR = "~*NEW*~" Then
                gspStr = "sp_insert_CUSHPFML '','" & CSF_CUS1NO & "','" & CSF_CUS2NO & "','" & CSF_VENNO & "'," & CSF_SHPSTRBUF & "," & CSF_SHPENDBUF & "," & CSF_CANCELBUF & ",'" & gsUsrID & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUSHPFML sp_insert_CUSHPFML :" & rtnStr)
                    save_CUSHPFML = False
                    Exit Function
                End If
            ElseIf CSF_CREUSR = "~*UPD*~" Then
                gspStr = "sp_update_CUSHPFML '','" & CSF_CUS1NO & "','" & CSF_CUS2NO & "','" & CSF_VENNO & "'," & CSF_SHPSTRBUF & "," & CSF_SHPENDBUF & "," & CSF_CANCELBUF & ",'" & gsUsrID & "'"
                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_CUSHPFML sp_update_CUSHPFML :" & rtnStr)
                    save_CUSHPFML = False
                    Exit Function
                End If
            End If
        Next i

        save_CUSHPFML = True
    End Function



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

