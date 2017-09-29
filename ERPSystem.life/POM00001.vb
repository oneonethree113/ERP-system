Public Class POM00001

    Dim ShipmrkAttchmnt As SCM00001_ShpmrkAtchmt

    Public rs_POORDHDR As DataSet
    Public rs_SYSETINF As DataSet
    Public rs_SYAGTINF As DataSet
    'Public rs_SYSALREP As DataSet
    Public rs_SYSALREL As DataSet
    Public rs_CUBASINF As DataSet
    Public rs_POCNTINF As DataSet
    Public rs_CVNCNTINF As DataSet
    Public rs_PODISPRM_D As DataSet
    Public rs_PODISPRM_P As DataSet
    Public rs_sydisprm As DataSet
    Public rs_POSHPMRK As DataSet
    Public rs_POORDDTL As DataSet
    Public rs_POORDDTL_sort As DataSet
    Public rs_PODTLSHP As DataSet
    Public rs_PODTLSHPC As DataSet
    Public rs_PODTLCTN As DataSet
    Public rs_PODTLCTNC As DataSet
    Public rs_PODTLBOM As DataSet
    Public rs_PODTLBOMC As DataSet
    Public rs_PODTLASS As DataSet
    Public rs_VNBASINF As DataSet
    Public rs_VNCNTINF As DataSet        'Lester Wu 2004/09/30 For Vendor Address
    '--
    Public rs_SYUSRRIGHT As DataSet
    'Public rs_PODTLBOM_FILTER As DataSet
    'Public rs_PODTLASS_FILTER As DataSet
    Public rs_PODTLCTN_temp As DataSet
    'Public rs_PODTLCTN_FILTER As DataSet
    'Public rs_PODTLSHP_FILTER As DataSet
    Public rs_PODISPRM_DEL As DataSet
    Public rs_PODISPRM_DEL2 As DataSet
    Public rs_PODISPRM_INS As DataSet
    Public rs_PODISPRM_INS2 As DataSet
    Public rs_PODISPRM_UPT As DataSet
    Public rs_PODISPRM_UPT2 As DataSet
    Public rs_POORDDTL_UPT As DataSet
    Public rs_PODTLBOM_UPT As DataSet
    Public rs_PODTLSHP_DEL As DataSet
    Public rs_PODTLSHP_ADD As DataSet
    Public rs_PODTLSHP_UPT As DataSet
    Public rs_POORDHDR_UPT As DataSet
    Dim PreviousTab As Integer
    Dim selectedRow As Integer


    '--


    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean
    Dim varSort As String

    Dim IsUpdated As Boolean
    Dim save_ok As Boolean
    Dim Current_TimeStamp As Long
    Dim find_flag As Boolean
    Dim Recordstatus As Boolean
    Dim Form_Error As Boolean
    Dim flag_grdcontrol As String
    Dim flag_exit As Boolean
    Dim Temp_POno As String
    Dim dateok As Boolean
    Dim Total_D_Amt As Double
    Dim Total_D_Per As Double
    Dim Total_P_Amt As Double
    Dim Total_P_Per As Double
    Dim VendorType As String

    Dim current_row As Integer

    Dim befVenAddr As String
    ' Added by Joe 20100513
    Public strModule As String
    'Dim default_date As Date = Format(DateTime.Parse("01/01/1900"), "MM/dd/yyyy")
    Dim default_date As Date = Format(DateTime.Parse("01/01/1900"), "MM/dd/yyyy")


    Dim prevShpMrkTyp As String


    Private Sub POM00001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.Icon = ERP00000.Icon

        strModule = "PO"
        Enq_right_local = Enq_right
        Del_right_local = Del_right
        FillCompCombo(gsUsrID, cboCoCde)         'Get availble Company
        GetDefaultCompany(cboCoCde, txtCoNam)
        AccessRight(Me.Name) '*** For Access Right use, added by Tommy on 5 Oct 2001
        varSort = "pod_purseq"
        Enq_right_local = Enq_right
        Del_right_local = Del_right
        Call Formstartup(Me.Name)
        '#If useMTS Then
        '        Set objBSGate = CreateObject("ucpBS_Gate.clsBSGate", serverName)
        '#Else
        '        objBSGate = CreateObject("ucpBS_Gate.clsBSGate")
        '#End If
        'If gsConnStr = "" Then
        '    gsConnStr = getConnectionString()
        'End If
        If gsCompany = "UCP" Then
            Label73.Text = "Factory Cost :"
        End If
        txtFtyPrc.Visible = True
        cboPOStatus.Items.Add("OPE - OPEN")
        cboPOStatus.Items.Add("REL - Released")
        cboPOStatus.Items.Add("CLO - Closed")
        cboPOStatus.Items.Add("CAN - Cancelled")
        cboForTyp.Items.Add("FO - Ocean Forwarder")
        cboForTyp.Items.Add("FA - Air Forwarder")
        cboForTyp.Items.Add("FT - Other Forwarder")
        cboForTyp.Items.Add("CO - Courier")
        'txtEngRmk.MaxLength = 1600
        'txtChnRmk.MaxLength = 3200

        gspStr = "sp_list_SYSETINF '" & gsCompany & "'"

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_SYSETINF, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading POM00001 POM00001_Load sp_list_SYSETINF : " & rtnStr)
        Else
            gspStr = "sp_list_SYAGTINF '" & gsCompany & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_SYAGTINF, rtnStr)

            'gspStr = "sp_list_SYSALREP '" & gsCompany & "'"
            'rtnLong = execute_SQLStatement(gspStr, rs_SYSALREP, rtnStr)

            gspStr = "sp_list_SYSALREL ''"
            rtnLong = execute_SQLStatement(gspStr, rs_SYSALREL, rtnStr)

            gspStr = "sp_list_CUBASINF '" & gsCompany & "','A'"
            rtnLong = execute_SQLStatement(gspStr, rs_CUBASINF, rtnStr)

            gspStr = "sp_select_SYDISPRM_All '" & gsCompany & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_sydisprm, rtnStr)

            If rs_SYSETINF.Tables("RESULT").Rows.Count = 0 Then
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("No Record in SYSTEMINF") 'msg("M00110")
                Call setStatus("Init")
                Exit Sub
            Else
                fillcboAgent()
                fillcboSalesRep()
                fillcboPrcTrm()
                fillcboPayTrm()
                filllstDipPrm()
                fillcboCusCur()
            End If
        End If


        Me.KeyPreview = True
        Me.TabPageMain.SelectedIndex = 0
        setStatus("Init")

        find_flag = False

        Me.Cursor = Windows.Forms.Cursors.Default

        Recordstatus = False
        'default_date = Format(DateTime.Parse("01/01/1900"), "MM/dd/yyyy")
        'TextBox9.Text = default_date
        'TextBox9.Enabled = True
        'TextBox9.ReadOnly = False
    End Sub


    Private Sub setStatus(ByVal Mode As String)

        If Mode = "Init" Then
            Me.TabPageMain.SelectedIndex = 0
            freeze_TabControl(-1) 'SSTab1.Enabled = False

            SetStatusBar(Mode)
            'DoEvents()
            cmdAdd.Enabled = False '*** Access Right used  - added by Tommy on 10 March 2002
            cmdSave.Enabled = False  '*** Access Right used  - added by Tommy on 10 March 2002
            cmdCopy.Enabled = False
            cmdInsRow.Enabled = False
            cboCoCde.Enabled = True

            cmdDelete.Enabled = False
            cmdDelRow.Enabled = False


            cmdFind.Enabled = True
            'CmdLookup.Enabled = True

            cmdExit.Enabled = True
            cmdClear.Enabled = True
            cmdSearch.Enabled = True
            CmdQCRpt.Enabled = True
            'cmdspecial.Enabled = True
            'cmdbrowlist.Enabled = True

            cmdfirst.Enabled = False
            cmdlast.Enabled = False
            cmdNext.Enabled = False
            cmdPrv.Enabled = False

            CmdDtlPre.Enabled = False

            txtPONo.Enabled = True
            txtPeriod.Enabled = False
            txtPeriod.BackColor = Color.White
            txtIMPeriod.Enabled = False
            txtIMPeriod.BackColor = Color.White
            '==
            txtCoNam.Enabled = False
            txtCoNam.BackColor = Color.White
            cboPOStatus.Enabled = False
            cboPOStatus.BackColor = Color.White
            txtOrdNo.Enabled = False
            txtOrdNo.BackColor = Color.White
            chkRpl.Enabled = False
            DTIssDat.Enabled = False
            DTIssDat.BackColor = Color.White
            DTRvsDat.Enabled = False
            DTRvsDat.BackColor = Color.White
            chkVndAck.Enabled = False
            current_row = 0


            '===fix select main shpmrk on init===
            optMain.Checked = True
            prevShpMrkTyp = "M"
            '====================================


            '==
            'cboSalesRep.Items.Clear()
            'cboSalesRep.Text = "abc"
            'cboPayTrm.Items.Clear()
            'cboPayTrm.Text = "abc"
            'cboPrcTrm.Items.Clear()
            'cboPrcTrm.Text = "abc"


            ClearScreen()
        ElseIf Mode = "Updating" Then
            Call SetStatusBar(Mode)
            cmdFind.Enabled = False
            cmdSearch.Enabled = False
            CmdQCRpt.Enabled = False

            txtPONo.Enabled = False
            txtPONo.BackColor = Color.White
            release_TabControl() 'SSTab1.Enabled = True
            cboCoCde.Enabled = False
            cboCoCde.BackColor = Color.White
            ' User Request to release discount field for update at 21/07/2003
            If gsUsrRank <= 4 Then
                txtDiscnt.Enabled = True
            End If

            cmdInsRow.Enabled = Enq_right_local 'True '*** Access Right used  - added by Tommy on 10 March 2002
            cmdDelRow.Enabled = Del_right_local 'True '*** Access Right used  - added by Tommy on 10 March 2002
            cmdSave.Enabled = Enq_right_local 'True '*** Access Right used  - added by Tommy on 10 March 2002

        ElseIf Mode = "Save" Then
            Call setStatus("Init")
            Call SetStatusBar(Mode)
            MsgBox("Record Saved!") 'msg("M00025")
            If txtPONo.Enabled And txtPONo.Visible Then txtPONo.Focus()
            Call ClearScreen()
        ElseIf Mode = "Clear" Then




            Call ClearScreen()

        End If

        chkstatus()
    End Sub

    Private Sub chkstatus()

        If cboPOStatus.SelectedIndex <> 0 Then
            cboPorCtp.Enabled = False
            cboPorCtp.BackColor = Color.White
            txtPoCDatFrm.Enabled = False
            txtPoCDatFrm.BackColor = Color.White
            txtPoCDatTo.Enabled = False
            txtPoCDatTo.BackColor = Color.White
            txtShpStr.Enabled = False
            txtShpStr.BackColor = Color.White
            txtShpEnd.Enabled = False
            txtShpEnd.BackColor = Color.White
            txtLblDue.Enabled = False
            txtLblDue.BackColor = Color.White
            txtRmk.ReadOnly = True
            DTDCanDat.Enabled = False
            DTDCanDat.BackColor = Color.White
            DTDShpStr.Enabled = False
            DTDShpStr.BackColor = Color.White
            DTDShpEnd.Enabled = False
            DTDShpEnd.BackColor = Color.White

            txtDRmk.Enabled = True
            txtSEngDsc.ReadOnly = True
            txtSChnDsc.ReadOnly = True
            txtChnDsc.ReadOnly = True
            txtEngRmk.ReadOnly = True
            txtChnRmk.ReadOnly = True

            txtEngRmk.ReadOnly = True
            txtChnRmk.ReadOnly = True

            cboPrcTrm.Enabled = False
            cboPrcTrm.BackColor = Color.White
            cboPayTrm.Enabled = False
            cboPayTrm.BackColor = Color.White

            GrdDis.Enabled = False
            GrdPre.Enabled = False
            cmdSave.Enabled = False

            '*** Modified by Johnson Lai as at 27-Jun-2002
            'Header
            cboPayTrm.Enabled = True
            txtShpAdr.Enabled = True
            txtShpAdr.ReadOnly = True
            txtRemAddr.Enabled = True
            txtRemAddr.ReadOnly = True
            ' Added by Mark Lau 20081202
            txtRemChnAddr.Enabled = True
            txtRemChnAddr.ReadOnly = True
            'Detail
            txtLblCde1.Enabled = True
            txtLblCde1.ReadOnly = True
            txtLblCde2.Enabled = True
            txtLblCde2.ReadOnly = True
            txtLblCde3.Enabled = True
            txtLblCde3.ReadOnly = True
            txtDRmk.Enabled = True
            txtDRmk.ReadOnly = True

            '*** END Modified by Johnson Lai as at 27-Jun-2002

        Else
            cboPorCtp.Enabled = True

            'txtPoCDatFrm.Enabled = True
            'txtPoCDatTo.Enabled = True
            'txtShpStr.Enabled = True
            txtPoCDatFrm.Enabled = False
            txtPoCDatTo.Enabled = False
            txtShpStr.Enabled = False
            'txtShpEnd.Enabled = True
            txtShpEnd.Enabled = False
            txtLblDue.Enabled = True
            txtRmk.ReadOnly = False
            'DTDShpStr.Enabled = True
            'DTDShpEnd.Enabled = True
            'DTDCanDat.Enabled = True
            DTDCanDat.Enabled = False
            DTDShpStr.Enabled = False
            DTDShpEnd.Enabled = False
            txtDRmk.Enabled = True
            txtEngRmk.ReadOnly = False
            txtChnRmk.ReadOnly = False
            txtSEngDsc.ReadOnly = False
            txtSChnDsc.ReadOnly = False
            txtChnDsc.ReadOnly = False
            txtEngRmk.ReadOnly = False
            txtChnRmk.ReadOnly = False

            '*** Modified by Johnson Lai as at 27-Jun-2002
            '*** Modified by Lewis To at 21-Feb-2002 changed txtShpAdr and txtRemAdr Locked to True
            txtShpAdr.Enabled = True
            txtShpAdr.ReadOnly = True
            txtRemAddr.Enabled = True
            txtRemAddr.ReadOnly = True
            ' Added by Mark Lau 20081202
            txtRemChnAddr.Enabled = True
            txtRemChnAddr.ReadOnly = True
            'txtRemAddr.Locked = False
            'Detail
            '        txtCusItm.Enabled = True
            '        txtCusItm.Locked = True
            '        txtCusSku.Enabled = True
            '        txtCusSku.Locked = False
            '        txtVenCol.Enabled = True
            '        txtVenCol.Locked = False
            '        txtCusCol.Enabled = True
            '        txtCusCol.Locked = False
            '        txtColDsc.Enabled = True
            '        txtColDsc.Locked = True
            '        txtPckItr.Enabled = True
            '        txtPckItr.Locked = False
            '        txtDCusPno.Enabled = True
            '        txtDCusPno.Locked = False
            '        txtDResPno.Enabled = True
            '        txtDResPno.Locked = False
            '        txtLblCde1.Enabled = True
            '        txtLblCde1.Locked = False
            '        txtLblCde2.Enabled = True
            '        txtLblCde2.Locked = False
            '        txtLblCde3.Enabled = True
            '        txtLblCde3.Locked = False
            txtDRmk.Enabled = True
            txtDRmk.ReadOnly = False

            '*** END Modified by Johnson Lai as at 27-Jun-2002

            '*** Modified by Solo So as at 03-Apr-2002
            If gsUsrRank <= 6 And Enq_right_local Then
                cboPrcTrm.Enabled = True
                cboPayTrm.Enabled = True
            Else
                cboPrcTrm.Enabled = False
                cboPrcTrm.BackColor = Color.White
                cboPayTrm.Enabled = False
                cboPayTrm.BackColor = Color.White
            End If
            '*** End Modification by Solo So as at 03-Apr-2002



            GrdDis.Enabled = True
            GrdPre.Enabled = True
            cmdSave.Enabled = Enq_right_local 'True '*** Access Right used  - added by Tommy on 10 March 2002
        End If

        txtCusItm.Enabled = True
        txtCusItm.ReadOnly = True
        txtCusSku.Enabled = True
        txtCusSku.ReadOnly = True
        txtVenCol.Enabled = True
        txtVenCol.ReadOnly = True
        txtCusCol.Enabled = True
        txtCusCol.ReadOnly = True
        txtColDsc.Enabled = True
        txtColDsc.ReadOnly = True
        txtPckitr.Enabled = True
        txtPckItr.ReadOnly = True
        txtDCusPno.Enabled = True
        txtDCusPno.ReadOnly = True
        txtDResPno.Enabled = True
        txtDResPno.ReadOnly = True
        'Lester Wu 2005-06-01, show Secondary Cust Item No
        txtSecCusItm.Enabled = True
        txtSecCusItm.ReadOnly = True


    End Sub
    Private Sub SetStatusBar(ByVal Mode As String)

        If Mode = "Init" Then
            StatusBar.Items("lblLeft2").Text = "Please Enter a PO No."
            'Add your codes here

        ElseIf Mode = "ADD" Then
            StatusBar.Items("lblLeft2").Text = "ADD"
            'Add your codes here

        ElseIf Mode = "Updating" Then
            StatusBar.Items("lblLeft2").Text = "Updating"
            'Add your codes here

        ElseIf Mode = "Save" Then
            StatusBar.Items("lblLeft2").Text = "Record Saved"
            'Add your codes here

        ElseIf Mode = "Delete" Then
            StatusBar.Items("lblLeft2").Text = "Record Deleted"
            'Add your codes here

        ElseIf Mode = "ReadOnly" Then
            StatusBar.Items("lblLeft2").Text = "Read Only"
            'Add your codes here
        ElseIf Mode = "Clear" Then
            StatusBar.Items("lblLeft2").Text = "Clear Screen"
            'Add your codes here
        End If
    End Sub
    Private Sub freeze_TabControl(ByVal tabpageno As Integer)
        cboVenAddr.DropDownStyle = ComboBoxStyle.DropDownList
        cboPorCtp.DropDownStyle = ComboBoxStyle.DropDownList
        cboAgent.DropDownStyle = ComboBoxStyle.DropDownList
        cboSalesRep.DropDownStyle = ComboBoxStyle.DropDownList
        cboPrcTrm.DropDownStyle = ComboBoxStyle.DropDownList
        cboPayTrm.DropDownStyle = ComboBoxStyle.DropDownList
        cboCountry1.DropDownStyle = ComboBoxStyle.DropDownList
        cboCountry2.DropDownStyle = ComboBoxStyle.DropDownList
        cboSalesRep.DropDownStyle = ComboBoxStyle.DropDownList
        cboForTyp.DropDownStyle = ComboBoxStyle.DropDownList
        Dim i As Integer
        For i = 0 To TabPageMain.TabPages.Count - 1
            If i = tabpageno Then
                Me.TabPageMain.TabPages(i).Enabled = True
            Else
                Me.TabPageMain.TabPages(i).Enabled = False
            End If
        Next i
    End Sub

    Private Sub release_TabControl()
        cboVenAddr.DropDownStyle = ComboBoxStyle.DropDown
        cboPorCtp.DropDownStyle = ComboBoxStyle.DropDown
        cboAgent.DropDownStyle = ComboBoxStyle.DropDown
        cboSalesRep.DropDownStyle = ComboBoxStyle.DropDown
        cboPrcTrm.DropDownStyle = ComboBoxStyle.DropDown
        cboPayTrm.DropDownStyle = ComboBoxStyle.DropDown
        cboCountry1.DropDownStyle = ComboBoxStyle.DropDown
        cboForTyp.DropDownStyle = ComboBoxStyle.DropDown
        cboCountry2.DropDownStyle = ComboBoxStyle.DropDown
        cboSalesRep.DropDownStyle = ComboBoxStyle.DropDown
        Dim i As Integer
        For i = 0 To TabPageMain.TabPages.Count - 1
            Me.TabPageMain.TabPages(i).Enabled = True
        Next i

        TabPageMain.TabPages(1).Enabled = False
    End Sub
    Private Sub ClearScreen()

        '*************Header**************************
        'txtPONo.Text = ""
        txtOrdNo.Text = ""
        DTIssDat.Text = Format(Now, "MM/dd/yyyy") 'DTIssDat.Text = Format(Date, "mm/dd/yyyy")
        DTRvsDat.Text = Format(Now, "MM/dd/yyyy") 'DTRvsDat.Text = Format(Date, "mm/dd/yyyy")
        display_combo("", cboPOStatus) 'Call DisplayCombo(cboPOStatus, "")


        chkRpl.Checked = False
        chkSignApp.Checked = False

        txtVendor.Text = ""
        txtRemAddr.Text = ""
        ' Added by Mark Lau 20081202
        txtRemChnAddr.Text = ""
        txtStt.Text = ""
        txtPst.Text = ""
        txtCty.Text = ""

        cboPorCtp.Items.Clear()
        cboPorCtp.Text = ""

        display_combo("", cboAgent) 'Call DisplayCombo(cboAgent, "")
        display_combo("", cboSalesRep) 'Call DisplayCombo(cboSalesRep, "")
        display_combo("", cboPrcTrm) 'Call DisplayCombo(cboPrcTrm, "")
        display_combo("", cboPayTrm) 'Call DisplayCombo(cboPayTrm, "")

        txtDiscnt.Text = ""
        txtTtlAmt.Text = ""

        txtNetAmt.Text = ""

        txtTtlCube.Text = ""
        txtCur1.Text = ""
        txtCur2.Text = ""
        txtCarton.Text = ""
        txtPrmCus.Text = ""
        txtSecCus.Text = ""
        txtShpAdr.Text = ""
        txtShpStt.Text = ""
        txtShpCty.Text = ""
        txtShpPst.Text = ""
        txtCusPno.Text = ""
        txtCPODat.Text = "" 'txtCPODat.Text = Format(Now, "MM/dd/yyyy") 'txtCPODat.Text = Format(Date, "mm/dd/yyyy")
        txtRepPno.Text = ""
        txtPoCDatFrm.Text = "" 'txtPoCDat.Text = Format(Now, "MM/dd/yyyy") 'txtPoCDat.Text = Format(Date, "mm/dd/yyyy")
        txtPoCDatTo.Text = ""
        txtShpStr.Text = Format(Now, "MM/dd/yyyy") 'txtShpStr.Text = Format(Date, "mm/dd/yyyy")
        txtShpEnd.Text = Format(Now, "MM/dd/yyyy") 'txtShpEnd.Text = Format(Date, "mm/dd/yyyy")
        txtLblDue.Text = Format(Now, "MM/dd/yyyy") 'txtLblDue.Text = Format(Date, "mm/dd/yyyy")
        txtCusTtlCtn.Text = ""
        txtDest.Text = ""
        txtLblVen.Text = ""
        txtRmk.Text = ""

        '====fix clear screen====
        cboVenAddr.SelectedIndex = -1
        cboVenAddr.Text = ""
        cboSalesRep.SelectedIndex = -1
        cboSalesRep.Text = ""
        cboPayTrm.SelectedIndex = -1
        cboPayTrm.Text = ""
        cboPrcTrm.SelectedIndex = -1
        cboPrcTrm.Text = ""
        chkVndAck.Checked = False
        '========================

    End Sub
    Private Sub fillcboAgent()
        cboAgent.Items.Clear()
        If rs_SYAGTINF.Tables("RESULT").Rows.Count > 0 Then
            'rs_SYAGTINF.MoveFirst()
            For i As Integer = 0 To rs_SYAGTINF.Tables("RESULT").Rows.Count - 1
                cboAgent.Items.Add(rs_SYAGTINF.Tables("RESULT").Rows(i).Item("yai_agtcde") & " - " & rs_SYAGTINF.Tables("RESULT").Rows(i).Item("yai_stnam"))
            Next

        End If
    End Sub
    Private Sub fillcboSalesRep()
        cboSalesRep.Items.Clear()
        'If rs_SYSALREP.Tables("RESULT").Rows.Count > 0 Then
        '    For i As Integer = 0 To rs_SYSALREP.Tables("RESULT").Rows.Count - 1
        '        cboSalesRep.Items.Add(rs_SYSALREP.Tables("RESULT").Rows(i).Item("ysr_code1") & " - " & rs_SYSALREP.Tables("RESULT").Rows(i).Item("ysr_dsc"))
        '    Next
        'End If
        If rs_SYSALREL.Tables("RESULT").Rows.Count > 0 Then
            For i As Integer = 0 To rs_SYSALREL.Tables("RESULT").Rows.Count - 1
                cboSalesRep.Items.Add(rs_SYSALREL.Tables("RESULT").Rows(i).Item("ssr_salrep") & " - " & rs_SYSALREL.Tables("RESULT").Rows(i).Item("ssr_usrnam"))
            Next
        End If
    End Sub
    Private Sub fillcboPrcTrm()
        Dim drSYSETINF() As DataRow = rs_SYSETINF.Tables("RESULT").Select("ysi_typ ='03'", "ysi_cde")
        If drSYSETINF.Length() <> 0 Then
            For i As Integer = 0 To drSYSETINF.Length() - 1
                cboPrcTrm.Items.Add(drSYSETINF(i).Item("ysi_cde") & " - " & drSYSETINF(i).Item("ysi_dsc"))
            Next
        End If
    End Sub
    Private Sub fillcboPayTrm()
        Dim drSYSETINF() As DataRow = rs_SYSETINF.Tables("RESULT").Select("ysi_typ ='04'", "ysi_cde")
        If drSYSETINF.Length() <> 0 Then
            For i As Integer = 0 To drSYSETINF.Length() - 1
                cboPayTrm.Items.Add(drSYSETINF(i).Item("ysi_cde") & " - " & drSYSETINF(i).Item("ysi_dsc"))
            Next
        End If
    End Sub
    Private Sub filllstDipPrm()
        If rs_sydisprm.Tables("RESULT").Rows.Count > 0 Then
            Dim drsydisprm() As DataRow = rs_sydisprm.Tables("RESULT").Select("ydp_type = 'D'")
            If drsydisprm.Length() <> 0 Then
                For i As Integer = 0 To drsydisprm.Length() - 1
                    LstDis.Items.Add(drsydisprm(i).Item("ydp_cde") & " - " & drsydisprm(i).Item("ydp_dsc"))
                Next
            End If
            Dim drsydisprm2() As DataRow = rs_sydisprm.Tables("RESULT").Select("ydp_type = 'P'")
            If drsydisprm2.Length() <> 0 Then
                For i As Integer = 0 To drsydisprm2.Length() - 1
                    LstPre.Items.Add(drsydisprm2(i).Item("ydp_cde") & " - " & drsydisprm2(i).Item("ydp_dsc"))
                Next
            End If
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Public Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click

        find_flag = True

        If (Trim(txtPONo.Text) = "") Then
            If txtPONo.Enabled And txtPONo.Visible Then txtPONo.Focus()
            MsgBox("Please Input a PO No.") 'msg("M00264")
            Exit Sub
        End If

        '    Dim rsPOORDHDR() As ADOR.Recordset
        '    Dim rs() As ADOR.Recordset
        '    Dim S As String
        '    Dim sPOORDHDR As String

        '--- Update Company Code before execute ---
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)
        '    '------------------------------------------
        '    '*** query item master header





        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        gspStr = "sp_select_PODTLSHP '" & gsCompany & "','" & txtPONo.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_PODTLSHP, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading POM00001 cmdFind_Click sp_select_PODTLSHP : " & rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            Exit Sub
        Else
            rs_PODTLSHPC = rs_PODTLSHP.Copy()
            '        rs_PODTLSHP = CopyRS(rsPOORDHDR(2))
            '        rs_PODTLSHPC = CopyRS(rsPOORDHDR(2))
        End If

        gspStr = "sp_select_PODTLASS '" & gsCompany & "','" & txtPONo.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_PODTLASS, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading POM00001 cmdFind_Click sp_select_PODTLASS : " & rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            Exit Sub
        Else
            '        rs_PODTLASS = CopyRS(rsPOORDHDR(3))
        End If

        gspStr = "sp_select_PODTLBOM '" & gsCompany & "','" & txtPONo.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_PODTLBOM, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading POM00001 cmdFind_Click sp_select_PODTLBOM : " & rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            Exit Sub
        Else
            rs_PODTLBOMC = rs_PODTLBOM.Copy()
            '        rs_PODTLBOM = CopyRS(rsPOORDHDR(4))
            '        rs_PODTLBOMC = CopyRS(rsPOORDHDR(4))
        End If

        gspStr = "sp_list_VNBASINFC '" & gsCompany & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading POM00001 cmdFind_Click sp_list_VNBASINFC : " & rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            Exit Sub
        Else
            '        rs_VNBASINF = rsPOORDHDR(5)
        End If

        gspStr = "sp_select_SYUSRRIGHT_Check '" & gsCompany & "','" & gsUsrID & "','" & txtPONo.Text & "','" & strModule & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_SYUSRRIGHT, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading POM00001 cmdFind_Click sp_select_SYUSRRIGHT_Check : " & rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            Exit Sub
        Else
            '       rsPOORDHDR(6)
        End If


        gspStr = "sp_select_POORDHDR '" & gsCompany & "','" & txtPONo.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_POORDHDR, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading POM00001 cmdFind_Click sp_select_POORDHDR : " & rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            Exit Sub
        Else
            If rs_POORDHDR.Tables("RESULT").Rows.Count = 0 Then
                Me.Cursor = Windows.Forms.Cursors.Default
                MsgBox("No Record Found!") 'msg("M00071")
                Exit Sub
            Else

                'S = "㊣POCNTINF※S※" & txtPONo.Text & _
                '    "㊣PODISPRM※S※" & txtPONo.Text & "※D" & _
                '    "㊣PODISPRM※S※" & txtPONo.Text & "※P" & _
                '    "㊣POSHPMRK※S※" & txtPONo.Text & _
                '    "㊣POORDDTL※L※" & txtPONo.Text
            End If
        End If
        'S = "㊣POCNTINF※S※" & txtPONo.Text & _
        '    "㊣PODISPRM※S※" & txtPONo.Text & "※D" & _
        '    "㊣PODISPRM※S※" & txtPONo.Text & "※P" & _
        '    "㊣POSHPMRK※S※" & txtPONo.Text & _
        '    "㊣POORDDTL※L※" & txtPONo.Text

        gspStr = "sp_select_POCNTINF '" & gsCompany & "','" & txtPONo.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_POCNTINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading POM00001 cmdFind_Click sp_select_POCNTINF : " & rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            Exit Sub
        Else
            '        rs_POCNTINF = CopyRS(rs(1))
        End If
        gspStr = "sp_select_PODISPRM '" & gsCompany & "','" & txtPONo.Text & "','D'"
        rtnLong = execute_SQLStatement(gspStr, rs_PODISPRM_D, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading POM00001 cmdFind_Click sp_select_PODISPRM : " & rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            Exit Sub
        Else
            '        rs_PODISPRM_D = CopyRS(rs(2))
            For i As Integer = 0 To rs_PODISPRM_D.Tables("RESULT").Columns.Count - 1
                rs_PODISPRM_D.Tables("RESULT").Columns(i).ReadOnly = False
            Next
        End If

        gspStr = "sp_select_PODISPRM '" & gsCompany & "','" & txtPONo.Text & "','P'"
        rtnLong = execute_SQLStatement(gspStr, rs_PODISPRM_P, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading POM00001 cmdFind_Click sp_select_PODISPRM : " & rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            Exit Sub
        Else
            '        rs_PODISPRM_P = CopyRS(rs(3))
            For i As Integer = 0 To rs_PODISPRM_P.Tables("RESULT").Columns.Count - 1
                rs_PODISPRM_P.Tables("RESULT").Columns(i).ReadOnly = False
            Next
        End If

        gspStr = "sp_select_POSHPMRK '" & gsCompany & "','" & txtPONo.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_POSHPMRK, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading POM00001 cmdFind_Click sp_select_POSHPMRK : " & rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            Exit Sub
        Else
            '        rs_POSHPMRK = CopyRS(rs(4))
        End If

        gspStr = "sp_list_POORDDTL '" & gsCompany & "','" & txtPONo.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_POORDDTL, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading POM00001 cmdFind_Click sp_list_POORDDTL : " & rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            Exit Sub
        Else
            '        rs_POORDDTL = CopyRS(rs(5))
            '--- Reset the sort sequence ---
            'rs_POORDDTL.sort = "pod_purseq"
            'varSort = rs_POORDDTL.sort
            varSort = "pod_purseq"
            Dim drPOORDDTL() As DataRow = rs_POORDDTL.Tables("RESULT").Select("", "pod_purseq")

            '-------------------------------

            Dim salrep As String


            If rs_POORDHDR.Tables("RESULT").Rows.Count > 0 Then
                salrep = rs_POORDHDR.Tables("RESULT").Rows(0).Item("cbi_saltem")

                If Not rs_SYUSRRIGHT.Tables("RESULT").Rows.Count = 0 Then

                    Current_TimeStamp = rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_timstp")
                    Call Display()
                    Call FillContactPerson()
                    Call display_combo(rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_porctp"), cboPorCtp)
                    Call setStatus("Updating")
                    grdSummary.DataSource = rs_POORDDTL.Tables("RESULT").DefaultView
                    grdSummary.DataSource.Sort = "pod_purseq"
                    Call Display_Summary()
                Else
                    Me.Cursor = Windows.Forms.Cursors.Default
                    MsgBox("You have no Right access this document.") 'msg("m00371")
                    Exit Sub
                End If

                Me.Cursor = Windows.Forms.Cursors.Default
                Recordstatus = False
                If gsUsrRank <= 4 Then
                    txtDiscnt.Enabled = True
                End If


                If rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_pursts") = "OPE" Then
                    Me.cboVenAddr.Enabled = True
                Else
                    Me.cboVenAddr.Enabled = False
                    cboVenAddr.BackColor = Color.White
                End If
                '------------------------------------------
            End If


        End If

        If rs_POORDHDR.Tables("RESULT").Rows(0)("poh_pursts") = "REL" Then
            cboPayTrm.Enabled = False
            txtDiscnt.Enabled = False
            txtEngDsc.Enabled = False
            txtCtnStr.Enabled = False
            txtCtnEnd.Enabled = False
            txtTtlCtn.Enabled = False
            cmdSave.Enabled = Enq_right_local
        End If


        'Set rs_PODTLSHP = Nothing
        rs_PODTLCTN = Nothing
        'Set rs_PODTLBOM = Nothing
        Recordstatus = False
        '==


    End Sub

    Private Sub Display()
        '*************Hearder**************************
        txtPONo.Text = rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_purord")
        txtOrdNo.Text = rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_ordno")
        DTIssDat.Text = Format(rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_credat"), "MM/dd/yyyy")
        DTRvsDat.Text = Format(rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_issdat"), "MM/dd/yyyy")
        Call display_combo(rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_pursts"), cboPOStatus)
        Call chkstatus()


        If rs_POORDHDR.Tables("RESULT").Rows(0).Item("soh_rplmnt") = "Y" Then
            chkRpl.Checked = True
        Else
            chkRpl.Checked = False
        End If

        If rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_signappflg") = "S" Or rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_signappflg") = "Y" Then
            chkSignApp.Checked = True
        Else
            chkSignApp.Checked = False
        End If

        If rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_pursts") = "REL" Then
            chkVndAck.Enabled = True
        Else
            chkVndAck.Enabled = False
        End If

        If rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_vndackflg") = "Y" Then
            chkVndAck.Checked = True
        Else
            chkVndAck.Checked = False
        End If

        txtVendor.Text = rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_venno") & " - " & rs_POORDHDR.Tables("RESULT").Rows(0).Item("vbi_vensna")
        'Lester Wu 2004/09/30
        Call Display_VenAddr()
        '--------------------
        txtRemAddr.Text = rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_puradr")
        ' Added by Mark Lau 20081202
        txtRemChnAddr.Text = rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_purchnadr")

        txtStt.Text = rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_purstt")
        txtPst.Text = rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_purpst")


        Dim drSYSETINF() As DataRow = rs_SYSETINF.Tables("RESULT").Select("ysi_typ ='02' and ysi_cde ='" & rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_purcty") & "'")
        If drSYSETINF.Length() > 0 Then
            'Lester Wu 2004/10/02
            'Show City with code value
            '----------------------------------------------------------------------------------------
            '    txtCty.Text = rs_SYSETINF("ysi_dsc") 
            txtCty.Text = rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_purcty") & " - " & drSYSETINF(0).Item("ysi_dsc")
            '----------------------------------------------------------------------------------------
        End If

        If Not rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_puragt") Is Nothing Then
            'Call fillcboAgent
            Call display_combo(rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_puragt"), cboAgent)
        End If

        If Not rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_srname") Is Nothing Then
            'Call fillcboSalesRep
            'Call display_combo(rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_salrep"), cboSalesRep)
            display_combo(rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_srname"), cboSalesRep)
        End If

        'Call fillcboPrcTrm
        Call display_combo(rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_prctrm"), cboPrcTrm)

        'Call fillcboPayTrm
        Call display_combo(rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_paytrm"), cboPayTrm)

        txtTtlCube.Text = rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_ttlcbm")
        txtCur1.Text = rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_curcde")
        txtCur2.Text = rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_curcde")
        txtCarton.Text = rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_ttlctn")
        'txtDiscnt.Text = rs_POORDHDR("poh_discnt") 
        'txtTtlAmt.Text = rs_POORDHDR("poh_ttlamt") 
        '
        'txtNetAmt.Text = rs_POORDHDR("poh_netamt") 

        Dim drCUBASINF() As DataRow = rs_CUBASINF.Tables("RESULT").Select("cbi_cusno ='" & rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_prmcus") & "'")
        'rs_CUBASINF.Filter = "cbi_cusno ='" & rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_prmcus")  & "'"
        If drCUBASINF.Length() <> 0 Then
            'rs_CUBASINF.MoveFirst()
            txtPrmCus.Text = drCUBASINF(0).Item("cbi_cusno") & " - " & drCUBASINF(0).Item("cbi_cussna")
        End If

        Dim drCUBASINF2() As DataRow = rs_CUBASINF.Tables("RESULT").Select("cbi_cusno ='" & rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_seccus") & "'")
        'rs_CUBASINF.Filter = "cbi_cusno ='" & rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_seccus")  & "'"
        If drCUBASINF2.Length() <> 0 Then
            'rs_CUBASINF.MoveFirst()
            txtSecCus.Text = drCUBASINF2(0).Item("cbi_cusno") & " - " & drCUBASINF2(0).Item("cbi_cussna")
        End If

        txtShpAdr.Text = rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_shpadr")
        txtShpStt.Text = rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_shpstt")

        Dim drSYSETINF2() As DataRow = rs_SYSETINF.Tables("RESULT").Select("ysi_typ ='02' and ysi_cde ='" & rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_shpcty") & "'")
        'rs_SYSETINF.Filter = "ysi_typ ='02' and ysi_cde ='" & rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_shpcty")  & "'"
        If drSYSETINF2.Length() <> 0 Then
            txtShpCty.Text = drSYSETINF2(0).Item("ysi_dsc")
        End If

        txtShpPst.Text = rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_shppst")

        txtCusPno.Text = rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_cuspno")
        txtCPODat.Text = rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_cpodat")
        txtRepPno.Text = rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_reppno")
        If IsDate(rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_pocdat")) Then
            txtPoCDatFrm.Text = Format(DateTime.Parse(rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_pocdat")), "MM/dd/yyyy") 'txtPoCDat.Text = rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_pocdat") ' txtPoCDat.Text = Format(rs_POORDHDR("poh_pocdat") , "mm/dd/yyyy")
        Else
            txtPoCDatFrm.Text = rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_pocdat")
        End If

        If IsDate(rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_pocdatend")) Then
            txtPoCDatTo.Text = Format(DateTime.Parse(rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_pocdatend")), "MM/dd/yyyy")
        Else
            txtPoCDatTo.Text = rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_pocdatend")
        End If

        '        If (rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_pocdat") = "  /  /    ") Then
        '        End If


        txtShpStr.Text = Format(DateTime.Parse(rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_shpstr")), "MM/dd/yyyy") 'txtShpStr.Text = rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_shpstr") 'txtShpStr.Text = Format(rs_POORDHDR("poh_shpstr") , "mm/dd/yyyy")


        txtShpEnd.Text = Format(DateTime.Parse(rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_shpend")), "MM/dd/yyyy") 'txtShpEnd.Text = rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_shpend") 'txtShpEnd.Text = Format(rs_POORDHDR("poh_shpend") , "mm/dd/yyyy")
        txtLblDue.Text = Format(DateTime.Parse(rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_lbldue")), "MM/dd/yyyy") 'txtLblDue.Text = rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_lbldue") 'txtLblDue.Text = Format(rs_POORDHDR("poh_lbldue") , "mm/dd/yyyy")
        txtLblVen.Text = rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_lblven")
        txtRmk.Text = rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_rmk")

        txtCusTtlCtn.Text = rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_cusctn")
        txtDest.Text = rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_dest")

        '''''''''''''''''''Contact'''''''''''''''''''''''''''''''
        If rs_POCNTINF.Tables("RESULT").Rows.Count > 0 And False Then
            txtConName.Text = rs_POCNTINF.Tables("RESULT").Rows(0).Item("pci_csenam")
            txtConAdd.Text = rs_POCNTINF.Tables("RESULT").Rows(0).Item("pci_cseadr")
            txtConSP.Text = rs_POCNTINF.Tables("RESULT").Rows(0).Item("pci_csestt")
            Call fillcountry()
            Call display_combo(rs_POCNTINF.Tables("RESULT").Rows(0).Item("pci_csecty"), cboCountry1)
            txtConZIP.Text = rs_POCNTINF.Tables("RESULT").Rows(0).Item("pci_csezip")


            txtForAcc.Text = rs_POCNTINF.Tables("RESULT").Rows(0).Item("pci_fwdacc")
            txtForDepc.Text = rs_POCNTINF.Tables("RESULT").Rows(0).Item("pci_fwddsc")
            txtForInst.Text = rs_POCNTINF.Tables("RESULT").Rows(0).Item("pci_fwditr")
            Call display_combo(rs_POCNTINF.Tables("RESULT").Rows(0).Item("pci_fwdtyp"), cboForTyp)

            txtNotTitle.Text = rs_POCNTINF.Tables("RESULT").Rows(0).Item("pci_noptil")
            txtNotAdd.Text = rs_POCNTINF.Tables("RESULT").Rows(0).Item("pci_nopadr")
            txtNotSP.Text = rs_POCNTINF.Tables("RESULT").Rows(0).Item("pci_nopstt")
            Call display_combo(rs_POCNTINF.Tables("RESULT").Rows(0).Item("pci_nopcty"), cboCountry2)
            txtNotZIP.Text = rs_POCNTINF.Tables("RESULT").Rows(0).Item("pci_nopzip")
            txtNotPhone.Text = rs_POCNTINF.Tables("RESULT").Rows(0).Item("pci_nopphn")
            txtNotFax.Text = rs_POCNTINF.Tables("RESULT").Rows(0).Item("pci_nopfax")
            txtNotEmail.Text = rs_POCNTINF.Tables("RESULT").Rows(0).Item("pci_nopeml")
        End If

        '''''''''''''''''''Discount Premium'''''''''''''''''''''''''''''''
        GrdDis.DataSource = rs_PODISPRM_D.Tables("RESULT").DefaultView
        Call DisplayDis()

        GrdPre.DataSource = rs_PODISPRM_P.Tables("RESULT").DefaultView
        Call DisplayPre()

        '''''''''''''''''''Ship Mark'''''''''''''''''''''''''''''''

        Call Display_ShpMrk()

        '''''''''''''''''''Detail'''''''''''''''''''''''''''''''

        If rs_POORDDTL.Tables("RESULT").Rows.Count > 0 Then
            'rs_POORDDTL.MoveFirst()
            Call DisplayPODetail()


            checkBackNext()
            'If rs_POORDDTL.AbsolutePosition <> rs_POORDDTL.recordCount Then
            '    CmdDtlNext.Enabled = True
            'Else
            '    CmdDtlNext.Enabled = False
            'End If

        End If

        txtDiscnt.Text = rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_discnt")
        txtTtlAmt.Text = Format(CDbl(rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_ttlamt")), "######0.00") 'txtTtlAmt.Text = Format(rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_ttlamt"), "#####.00")

        '''''''''''''''' Display Panel ''''''''''''''''''''''''''''
        StatusBar.Items("lblRight2").Text = Format(rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_credat"), "MM/dd/yyyy") & " " & Format(rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_upddat"), "MM/dd/yyyy") & _
                                      " " & rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_updusr")

        Call CalNetAmt()



    End Sub

    Private Sub FillContactPerson()



        gspStr = "sp_list_CVNCNTINF '" & gsCompany & "','" & Split(txtVendor.Text, " - ")(0) & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_CVNCNTINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading POM00001 FillContactPerson rs_CVNCNTINF : " & rtnStr)
            Exit Sub
        Else
            '    rs_CVNCNTINF = CopyRS(rs(1))
        End If

        If rs_CVNCNTINF.Tables("RESULT").Rows.Count > 0 Then
            For i As Integer = 0 To rs_CVNCNTINF.Tables("RESULT").Rows.Count - 1
                cboPorCtp.Items.Add(rs_CVNCNTINF.Tables("RESULT").Rows(i).Item("vci_cntctp"))
            Next

        End If

    End Sub
    Private Sub Display_Summary()
        With grdSummary

            For i As Integer = 0 To rs_POORDDTL.Tables("RESULT").Columns.Count - 1
                Select Case i
                    Case 0
                        .Columns(i).HeaderText = "Seq #"
                        .Columns(i).Width = 60
                    Case 1
                        .Columns(i).HeaderText = "Prd. Ven"
                    Case 2
                        .Columns(i).HeaderText = "Trd. Ven"
                    Case 3
                        .Columns(i).HeaderText = "Fty Aud"
                    Case 4
                        .Columns(i).HeaderText = "Item #"
                    Case 5
                        .Columns(i).HeaderText = "Job #"
                    Case 6
                        .Columns(i).HeaderText = "Running #"
                    Case 7
                        .Columns(i).HeaderText = "Prev. Job #"
                    Case 8
                        .Columns(i).HeaderText = "Sub Code"
                    Case 9
                        .Columns(i).HeaderText = "Vdr. Item #"
                    Case 10
                        .Columns(i).HeaderText = "Cust. Item #"
                    Case 11
                        .Columns(i).HeaderText = "SKU #"
                    Case 12
                        .Columns(i).HeaderText = "Sec. Cust. Item #"
                    Case 13
                        .Columns(i).HeaderText = "Vdr. Color Code"
                    Case 14
                        .Columns(i).HeaderText = "Cust. Color Code"
                    Case 15
                        .Columns(i).HeaderText = "Color Desc."
                    Case 16
                        .Columns(i).HeaderText = "Packing (UM/Inner/Master/CFT)"
                    Case 17
                        .Columns(i).HeaderText = "Packing Instruction"
                    Case 18
                        .Columns(i).HeaderText = "Order Qty."
                    Case 19
                        .Columns(i).HeaderText = "Received Qty."
                    Case 20
                        .Columns(i).HeaderText = "O/S Qty."
                    Case 21
                        .Columns(i).HeaderText = "CCY"
                        If gsFlgCst = 1 And gsFlgCstExt = 1 Then
                            .Columns(i).Visible = True
                        Else
                            .Columns(i).Visible = False
                        End If
                    Case 22
                        .Columns(i).HeaderText = "Item Cost"
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        If gsFlgCst = 1 And gsFlgCstExt = 1 Then
                            .Columns(i).Visible = True
                        Else
                            .Columns(i).Visible = False
                        End If
                    Case 23
                        .Columns(i).HeaderText = "Start CTN"
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Case 24
                        .Columns(i).HeaderText = "End CTN"
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Case 25
                        .Columns(i).HeaderText = "TTL CTN"
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Case 26
                        .Columns(i).HeaderText = "Ship Start Date"
                    Case 27
                        .Columns(i).HeaderText = "Ship End Date"
                    Case 28
                        .Columns(i).HeaderText = "Cancel Date"
                    Case 29
                        .Columns(i).HeaderText = "HSTU/Tariff #"
                    Case 30
                        .Columns(i).HeaderText = "Duty"
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Case 31
                        .Columns(i).HeaderText = "UPC/EAN# (M)"
                    Case 32
                        .Columns(i).HeaderText = "UPC/EAN# (I)"
                    Case 33
                        .Columns(i).HeaderText = "UPC/EAN# (C)"
                    Case 34
                        .Columns(i).HeaderText = "Retail 1 CCY"
                    Case 35
                        .Columns(i).HeaderText = "Retail 1 Amt"
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Case 36
                        .Columns(i).HeaderText = "Retail 2 CCY"
                    Case 37
                        .Columns(i).HeaderText = "Retail 2 Amt"
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Case 61
                        .Columns(i).HeaderText = "BOM"
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Case 62
                        .Columns(i).HeaderText = "Assort"
                        .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Case Else
                        .Columns(i).Visible = False
                End Select
            Next
        End With
    End Sub
    Private Sub Display_VenAddr()

        Dim venno As String
        cboVenAddr.Items.Clear()
        If Me.txtVendor.Text = "" Then Exit Sub
        venno = Trim(Strings.Left(Me.txtVendor.Text, InStr(Me.txtVendor.Text, " - ")))
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)



        '---
        gspStr = "sp_list_VNCNTINF '" & gsCompany & "','" & venno & "','M','ADR'"
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        rtnLong = execute_SQLStatement(gspStr, rs_VNCNTINF, rtnStr)
        Me.Cursor = Windows.Forms.Cursors.Default
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading POM00001 Display_VenAddr sp_list_VNCNTINF : " & rtnStr)
            Exit Sub
        ElseIf rs_VNCNTINF.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("No vendor address found!")
            Exit Sub
        End If
        '---



        Me.cboVenAddr.Items.Add("")
        'rs_VNCNTINF.MoveFirst()
        'While Not rs_VNCNTINF.EOF
        For i As Integer = 0 To rs_VNCNTINF.Tables("RESULT").Rows.Count - 1
            If Trim(rs_VNCNTINF.Tables("RESULT").Rows(i).Item("vci_chnadr")) <> "" Then
                Me.cboVenAddr.Items.Add(Trim(rs_VNCNTINF.Tables("RESULT").Rows(i).Item("vci_chnadr")))
            Else
                Me.cboVenAddr.Items.Add(Trim(rs_VNCNTINF.Tables("RESULT").Rows(i).Item("vci_adr")))
            End If
        Next
        'rs_VNCNTINF.MoveNext()
        'End While

    End Sub

    Private Sub fillcountry()

        Dim drSYSETINF3() As DataRow = rs_SYSETINF.Tables("RESULT").Select("ysi_typ ='02'", "ysi_cde")
        If drSYSETINF3.Length() > 0 Then
            For i As Integer = 0 To drSYSETINF3.Length() - 1
                cboCountry1.Items.Add(drSYSETINF3(i).Item("ysi_cde") & " - " & drSYSETINF3(i).Item("ysi_dsc"))
                cboCountry2.Items.Add(drSYSETINF3(i).Item("ysi_cde") & " - " & drSYSETINF3(i).Item("ysi_dsc"))
            Next

        End If


    End Sub
    Private Sub DisplayDis()
        With grdDis


            .Columns(0).HeaderCell.Value = "Del"
            .Columns(0).Width = 40 '.Columns(0).width = 420
            .Columns(0).ReadOnly = True
            '.Columns(0).Button = True

            .Columns(1).Visible = False '.Columns(1).width = 0
            .Columns(2).Visible = False '.Columns(2).width = 0
            .Columns(3).Visible = False '.Columns(3).width = 0


            .Columns(4).HeaderCell.Value = "Code"
            '.Columns(4).width = 1500
            '.Columns(4).Button = True
            .Columns(4).ReadOnly = True

            .Columns(5).HeaderCell.Value = "Description"
            .Columns(5).ReadOnly = False
            .Columns(5).Width = 150 '.Columns(5).width = 4700

            .Columns(6).HeaderCell.Value = "Percentage/Amount"
            '.Columns(6).width = 1500
            '.Columns(6).Button = True
            .Columns(6).ReadOnly = True

            .Columns(7).HeaderCell.Value = "%"
            '.Columns(7).width = 1200

            .Columns(8).HeaderCell.Value = "Amount"
            '.Columns(8).width = 1200

            If VendorType = "E" Then
                If gsFlgCstExt = 1 Then
                    .Columns(8).Visible = True
                    .Columns(8).Visible = True
                Else
                    .Columns(8).Visible = False
                    .Columns(8).Visible = False
                End If
            Else
                If gsFlgCst = 1 Then
                    .Columns(8).Visible = True
                    .Columns(8).Visible = True
                Else
                    .Columns(8).Visible = False
                    .Columns(8).Visible = False
                End If
            End If


            .Columns(9).Visible = False '.Columns(9).width = 0 'creusr
            .Columns(10).Visible = False '.Columns(10).width = 0
            .Columns(11).Visible = False '.Columns(11).width = 0
            .Columns(12).Visible = False '.Columns(12).width = 0
            .Columns(13).Visible = False '.Columns(13).width = 0



        End With

    End Sub
    Private Sub DisplayPre()
        With grdPre

            .Columns(0).HeaderCell.Value = "Del"
            .Columns(0).Width = 40 '.Columns(0).width = 420
            .Columns(0).ReadOnly = True
            '.Columns(0).Button = True

            .Columns(1).Visible = False '.Columns(1).width = 0
            .Columns(2).Visible = False '.Columns(2).width = 0
            .Columns(3).Visible = False '.Columns(3).width = 0


            .Columns(4).HeaderCell.Value = "Code"
            '.Columns(4).width = 1500
            '.Columns(4).Button = True
            .Columns(4).ReadOnly = True

            .Columns(5).HeaderCell.Value = "Description"
            .Columns(5).ReadOnly = False
            .Columns(5).Width = 150 '.Columns(5).width = 4700

            .Columns(6).HeaderCell.Value = "Percentage/Amount"
            '.Columns(6).width = 1500
            '.Columns(6).Button = True
            .Columns(6).ReadOnly = True

            .Columns(7).HeaderCell.Value = "%"
            '.Columns(7).width = 1200

            .Columns(8).HeaderCell.Value = "Amount"
            '.Columns(8).width = 1200

            If VendorType = "E" Then
                If gsFlgCstExt = 1 Then
                    .Columns(8).Visible = True
                    .Columns(8).Visible = True
                Else
                    .Columns(8).Visible = False
                    .Columns(8).Visible = False
                End If
            Else
                If gsFlgCst = 1 Then
                    .Columns(8).Visible = True
                    .Columns(8).Visible = True
                Else
                    .Columns(8).Visible = False
                    .Columns(8).Visible = False
                End If
            End If


            .Columns(9).Visible = False 'creusr '.Columns(9).width = 0
            .Columns(10).Visible = False '.Columns(10).width = 0
            .Columns(11).Visible = False '.Columns(11).width = 0
            .Columns(12).Visible = False '.Columns(12).width = 0
            .Columns(13).Visible = False '.Columns(13).width = 0

        End With
    End Sub
    Private Sub Display_ShpMrk()
        Dim pth As String
        Dim shptype As String
        If optMain.Checked = True Then
            shptype = "M"
        ElseIf optSide.Checked = True Then
            shptype = "S"
        Else
            shptype = "I"
        End If

        txtShpMrk.Text = ""
        txtImgPth.Text = ""
        txtSEngDsc.Text = ""
        txtSChnDsc.Text = ""
        txtEngRmk.Text = ""
        txtChnRmk.Text = ""
        imgShpMrk.Image = Nothing



        Dim drPOSHPMRK_M() As DataRow = rs_POSHPMRK.Tables("RESULT").Select("psm_shptyp = 'M'") 'rs_POSHPMRK.Filter = "psm_shptyp = 'M'"
        If drPOSHPMRK_M.Length() > 0 Then
            optMain.Enabled = True
        Else
            optMain.Enabled = False
        End If

        Dim drPOSHPMRK_S() As DataRow = rs_POSHPMRK.Tables("RESULT").Select("psm_shptyp = 'S'") 'rs_POSHPMRK.Filter = "psm_shptyp = 'S'"
        If drPOSHPMRK_S.Length() > 0 Then
            optSide.Enabled = True
        Else
            optSide.Enabled = False
        End If

        Dim drPOSHPMRK_I() As DataRow = rs_POSHPMRK.Tables("RESULT").Select("psm_shptyp = 'I'") 'rs_POSHPMRK.Filter = "psm_shptyp = 'I'"
        If drPOSHPMRK_I.Length() > 0 Then
            optInner.Enabled = True
        Else
            optInner.Enabled = False
        End If

        'rs_POSHPMRK.Filter = ""

        If rs_POSHPMRK.Tables("RESULT").Rows.Count > 0 Then
            'rs_POSHPMRK.MoveFirst()
            Dim drPOSHPMRK() As DataRow = rs_POSHPMRK.Tables("RESULT").Select("psm_shptyp = " & "'" & shptype & "'") 'rs_POSHPMRK.Find("psm_shptyp = " & "'" & shptype & "'")

            If drPOSHPMRK.Length() > 0 Then
                txtShpMrk.Text = drPOSHPMRK(0).Item("psm_imgnam")
                txtImgPth.Text = drPOSHPMRK(0).Item("psm_imgpth")
                txtSEngDsc.Text = drPOSHPMRK(0).Item("psm_engdsc")
                txtSChnDsc.Text = drPOSHPMRK(0).Item("psm_chndsc")
                txtEngRmk.Text = drPOSHPMRK(0).Item("psm_engrmk")
                txtChnRmk.Text = drPOSHPMRK(0).Item("psm_chnrmk")

                Me.Cursor = Windows.Forms.Cursors.WaitCursor

                On Error Resume Next
                imgShpMrk.Load(drPOSHPMRK(0).Item("psm_imgpth"))

                Me.Cursor = Windows.Forms.Cursors.Default

            End If

        End If


    End Sub

    Private Sub checkBackNext()
        If rs_POORDDTL.Tables("RESULT").Rows.Count <= 0 Then
            CmdDtlPre.Enabled = False
            CmdDtlNext.Enabled = False
        Else
            If current_row = 0 Then
                CmdDtlPre.Enabled = False
            Else
                CmdDtlPre.Enabled = True
            End If

            If current_row = rs_POORDDTL.Tables("RESULT").Rows.Count - 1 Then
                CmdDtlNext.Enabled = False
            Else
                CmdDtlNext.Enabled = True
            End If
        End If


    End Sub
    Private Sub DisplayPODetail()

        checkBackNext()
        'If rs_POORDDTL.AbsolutePosition <> 1 Then
        '    CmdDtlPre.Enabled = True
        'Else
        '    CmdDtlPre.Enabled = False
        'End If

        'If rs_POORDDTL.AbsolutePosition <> rs_POORDDTL.recordCount Then
        '    CmdDtlNext.Enabled = True
        'Else
        '    CmdDtlNext.Enabled = False
        'End If

        txtSubCde.Text = rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("sod_subcde")
        txtPurSeq.Text = rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_purseq")
        txtItmNo.Text = rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_itmno")
        txtJobOrd.Text = rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_jobord")
        txtCusItm.Text = rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_cusitm")
        txtCusSku.Text = rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_cussku")
        txtEngDsc.Text = rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_engdsc")
        txtChnDsc.Text = rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_chndsc")
        txtVenCol.Text = rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_vencol")
        txtCusCol.Text = rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_cuscol")
        txtColDsc.Text = rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_coldsc")
        txtPckItr.Text = rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_pckitr")
        txtUntCde.Text = rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_untcde")
        txtInrCtn.Text = rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_inrctn")
        txtMtrCtn.Text = rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_mtrctn")
        txtCubCft.Text = rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_cubcft")
        txtOrdQty.Text = rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_ordqty")
        txtRecQty.Text = rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_recqty")
        txtDCur.Text = rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_curcde")
        txtFtyPrc.Text = rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_ftyprc")
        txtDCusPno.Text = rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_cuspno")
        txtDResPno.Text = rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_respno")
        txtDept.Text = rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_dept")
        txtHrmCde.Text = rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_hrmcde")
        txtDRmk.Text = rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_rmk")
        txtDtyRat.Text = rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_dtyrat")
        txtRunNo.Text = rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_runno")
        'Lester Wu 2005-06-01, show production vendor, previous job no, secondary cust item no
        Me.txtSecCusItm.Text = rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_seccusitm")
        Me.txtPrdVen.Text = rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_prdven")
        txtTradeVen.Text = rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_tradeven")
        txtExamVen.Text = rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_examven")
        Me.txtPreJobNo.Text = rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("sod_pjobno")

        'Frankie Cheung 20100712
        If CStr(Year(rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_qutdat"))) <> "1900" Then
            txtPeriod.Text = CStr(Year(rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_qutdat"))) + "-" + Strings.Right("00" + CStr(Month(rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_qutdat"))), 2)
        Else
            txtPeriod.Text = ""
        End If


        'Frankie Cheung 20100810 Add IM Period
        If CStr(Year(rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_imqutdat"))) <> "1900" Then
            txtIMPeriod.Text = CStr(Year(rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_imqutdat"))) + "-" + Strings.Right("00" + CStr(Month(rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_imqutdat"))), 2)
        Else
            txtIMPeriod.Text = ""
        End If
        'typcode
        If rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_typcode") = "U" Then
            optUPC.Checked = True
        Else
            optEAN.Checked = True
        End If

        txtLblCde1.Text = rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_code1")
        txtLblCde2.Text = rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_code2")
        txtLblCde3.Text = rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_code3")

        display_combo(rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_cususdcur"), cboCusUSDCur)
        txtCusUsd.Text = rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_cususd")
        display_combo(rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_cuscadcur"), cboCusCADCur)
        txtCusCad.Text = rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_cuscad")
        If IsDate(rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_candat")) Then
            DTDCanDat.Text = Format(DateTime.Parse(rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_candat")), "MM/dd/yyyy")
        Else
            DTDCanDat.Text = ""
        End If

        If IsDate(rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_shpstr")) Then
            DTDShpStr.Text = Format(DateTime.Parse(rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_shpstr")), "MM/dd/yyyy")
        Else
            DTDShpStr.Text = ""
        End If
        If IsDate(rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_shpend")) Then
            DTDShpEnd.Text = Format(DateTime.Parse(rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_shpend")), "MM/dd/yyyy")
        Else
            DTDShpEnd.Text = ""
        End If

        txtCtnStr.Text = rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_ctnstr")
        txtCtnEnd.Text = rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_ctnend")
        txtTtlCtn.Text = rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_ttlctn")
        txtVnItmNo.Text = rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_venitm")

        If Trim(rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_itmsts")) = "CMP" Then
            txtPODSts.Text = "Completed"
        Else
            txtPODSts.Text = "Incompleted"
        End If

        Dim drPODTLSHP() As DataRow = rs_PODTLSHP.Tables("RESULT").Select("pds_seq = '" & txtPurSeq.Text & "'")

        If drPODTLSHP.Length > 1 Then
            DTDShpStr.Enabled = False
            DTDShpStr.BackColor = Color.White
            DTDShpEnd.Enabled = False
            DTDShpEnd.BackColor = Color.White
        Else
            If cboPOStatus.SelectedIndex = 0 Then
                DTDShpStr.Enabled = True
                DTDShpEnd.Enabled = True
            End If
        End If

        Dim drPODTLASS() As DataRow = rs_PODTLASS.Tables("RESULT").Select("pda_seq = '" & txtPurSeq.Text & "'")
        If drPODTLASS.Length > 0 Then
            cmdAss.Enabled = True
        Else
            cmdAss.Enabled = False
        End If

        Dim drPODTLBOM() As DataRow = rs_PODTLBOM.Tables("RESULT").Select("pdb_seq ='" & txtPurSeq.Text & "'")

        If drPODTLBOM.Length > 0 Then
            cmdBOM.Enabled = True
        Else
            cmdBOM.Enabled = False
        End If

    End Sub

    Private Sub CmdDtlPre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdDtlPre.Click
        Update_PODtl()
        If current_row = 0 Then
            'msgbox("should not happen")
        Else
            CmdDtlNext.Enabled = True
            current_row = current_row - 1
            checkBackNext()
        End If
        DisplayPODetail()
    End Sub

    Private Sub CmdDtlNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdDtlNext.Click
        Update_PODtl()
        If current_row = rs_POORDDTL.Tables("RESULT").Rows.Count - 1 Then
            'msgbox("should not happen")
        Else
            CmdDtlNext.Enabled = True
            current_row = current_row + 1
            checkBackNext()
        End If
        DisplayPODetail()
    End Sub

    Private Sub Update_PODtl()

        rs_POORDDTL.Tables("RESULT").Columns("pod_rmk").ReadOnly = False
        rs_POORDDTL.Tables("RESULT").Columns("pod_chndsc").ReadOnly = False
        rs_POORDDTL.Tables("RESULT").Columns("pod_candat").ReadOnly = False
        rs_POORDDTL.Tables("RESULT").Columns("pod_shpstr").ReadOnly = False
        rs_POORDDTL.Tables("RESULT").Columns("pod_shpend").ReadOnly = False

        '05/23/2016 Fix for incorrect update of PO Chinese description
        Dim i As Integer

        For i = 0 To rs_POORDDTL.Tables("RESULT").Rows.Count - 1
            If txtPurSeq.Text = rs_POORDDTL.Tables("RESULT").Rows(i).Item("pod_purseq") Then
                current_row = i
                Exit For
            End If
        Next i


        If Not rs_POORDDTL Is Nothing Then 'If Trim(txtPONo.Text) <> "" Then
            'If Not rs_POORDDTL.EOF Then
            rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_rmk") = txtDRmk.Text
            rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_chndsc") = txtChnDsc.Text
            If IsDate(DTDCanDat.Text) Then
                rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_candat") = DTDCanDat.Text
            Else
                rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_candat") = ""
            End If
            rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_shpstr") = DTDShpStr.Text
            rs_POORDDTL.Tables("RESULT").Rows(current_row).Item("pod_shpend") = DTDShpEnd.Text
            'rs_POORDDTL.Update()
            'End If
        End If
        rs_POORDDTL.Tables("RESULT").Columns("pod_rmk").ReadOnly = True
        rs_POORDDTL.Tables("RESULT").Columns("pod_chndsc").ReadOnly = True
        rs_POORDDTL.Tables("RESULT").Columns("pod_candat").ReadOnly = True
        rs_POORDDTL.Tables("RESULT").Columns("pod_shpstr").ReadOnly = True
        rs_POORDDTL.Tables("RESULT").Columns("pod_shpend").ReadOnly = True
    End Sub



    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click

        'Dim YesNoCancel As Integer
        If Recordstatus = True Then

            'YesNoCancel = msg("M00248")
            Dim YesNoCancel As Microsoft.VisualBasic.MsgBoxResult = MsgBox("Record has been modified. Do you want to save before clear the screen?", MsgBoxStyle.YesNoCancel)

            If YesNoCancel = MsgBoxResult.Yes Then
                If cmdSave.Enabled Then
                    flag_exit = True
                    cmdSave_Click(sender, e)
                    If save_ok = True Then
                        Temp_POno = txtPONo.Text
                        setStatus("Init")
                    Else
                        flag_exit = False
                        Exit Sub
                    End If
                Else
                    flag_exit = False
                    MsgBox("You are not allow to save record!") 'msg("M00253")
                    Exit Sub
                End If

            ElseIf YesNoCancel = MsgBoxResult.No Then
                Temp_POno = txtPONo.Text
                Call setStatus("Init")

                txtDiscnt.Enabled = False
                txtDiscnt.BackColor = Color.White
                chkSignApp.Enabled = False
            ElseIf YesNoCancel = vbCancel Then
                flag_exit = False
                Exit Sub
            End If
        Else
            Temp_POno = txtPONo.Text
            Call setStatus("Init")
        End If
        Recordstatus = False
        If txtPONo.Enabled And txtPONo.Visible Then txtPONo.Focus()

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        txtLblCde1.Focus()
        cmdClear.Focus()
        ''--- Update Company Code before execute ---
        gsCompany = Trim(cboCoCde.Text)
        Call Update_gs_Value(gsCompany)
        ''------------------------------------------
        ''--- re-calculate the discount / preimun price --
        CalNetAmt()
        ''------------------------------------------------
        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        If Enq_right_local = False Then '*** Access Right used  - added by Tommy on 10 March 2002
            MsgBox("You have no right to SAVE.")
            Me.Cursor = Windows.Forms.Cursors.Default
            Exit Sub
        End If

        If txtRemAddr.Text = "" And txtRemChnAddr.Text = "" Then
            Me.TabPageMain.SelectedIndex = 0
            Me.Cursor = Windows.Forms.Cursors.Default
            MsgBox("Please Select Vendor Address.")
            If Me.cboVenAddr.Visible = True And Me.cboVenAddr.Enabled = True Then Me.cboVenAddr.Focus()
            Exit Sub
        End If

        If Not ChkDate Then
            Me.Cursor = Windows.Forms.Cursors.Default
            Exit Sub
        End If

        If Not ChecktimeStamp Then
            MsgBox("The record has been modified by other users, please clear and try again.") 'msg("M00064")
            Me.Cursor = Windows.Forms.Cursors.Default
            save_ok = False
            Exit Sub
        End If

        Dim YesNoCancel As Microsoft.VisualBasic.MsgBoxResult 'Dim YesNo As Integer
        YesNoCancel = MsgBoxResult.No
        Dim UpdDtlFlg As Integer
        UpdDtlFlg = 0

        Dim txtPOCDate As String ' store txtPOCDat.text
        If Not IsDate(txtPoCDatFrm.Text) Then
            txtPOCDate = default_date
        Else
            txtPOCDate = txtPoCDatFrm.Text
        End If

        rs_POORDHDR.Tables("RESULT").Columns("poh_pocdat").ReadOnly = False
        If Not IsDate(rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_pocdat")) Then 'change it to default_date if rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_pocdat") is null (__/__/____)
            rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_pocdat") = default_date
        End If

        'TextBox9.Text = rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_pocdat")

        If txtPOCDate <> Format(DateTime.Parse(rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_pocdat")), "MM/dd/yyyy") Or txtShpEnd.Text <> Format(DateTime.Parse(rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_shpend")), "MM/dd/yyyy") Or txtShpStr.Text <> Format(DateTime.Parse(rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_shpstr")), "MM/dd/yyyy") Then
            YesNoCancel = MsgBox("Cancel or Ship Date in Header has been modified, details will be updated. Are you sure?", MsgBoxStyle.YesNoCancel)
            If YesNoCancel = MsgBoxResult.Cancel Then
                Me.Cursor = Windows.Forms.Cursors.Default
                save_ok = False
                Exit Sub
            Else
                save_ok = True
                If YesNoCancel = MsgBoxResult.No Then
                    UpdDtlFlg = 0
                Else
                    UpdDtlFlg = 1
                End If
            End If
        End If

        'Dim S As String
        'Dim rs As ADOR.Recordset


        '************************************************************************************************************
        '*********************************SCDISPRM Dis**********************************************

        '****************************
        '*** Delete Details Record***
        '****************************
        Dim drPODISPRM_D() As DataRow = rs_PODISPRM_D.Tables("RESULT").Select("pdp_creusr ='~*DEL*~'")
        For i As Integer = 0 To drPODISPRM_D.Length() - 1
            gspStr = "sp_Physical_Delete_PODISPRM '" & gsCompany & "','" & UCase(txtPONo.Text) & "','D','" & drPODISPRM_D(i).Item("pdp_seqno") & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_PODISPRM_DEL, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading POM00001 cmdSave_Click sp_Physical_Delete_PODISPRM : " & rtnStr)
                Me.Cursor = Windows.Forms.Cursors.Default
                IsUpdated = False
            Else
                IsUpdated = True
            End If
        Next



        '****************************
        '*** Add Details Record***
        '****************************
        Dim drPODISPRM_D_ADD() As DataRow = rs_PODISPRM_D.Tables("RESULT").Select("pdp_creusr ='~*ADD*~'")
        For i As Integer = 0 To drPODISPRM_D_ADD.Length() - 1


            gspStr = "sp_insert_PODISPRM '" & gsCompany & "','" & UCase(txtPONo.Text) & "','D','" & drPODISPRM_D_ADD(i).Item("pdp_dpltyp") & "','" & _
                    drPODISPRM_D_ADD(i).Item("pdp_dsc") & "','" & _
                    drPODISPRM_D_ADD(i).Item("pdp_pctamt") & "','" & drPODISPRM_D_ADD(i).Item("pdp_purpct") & "','" & _
                    drPODISPRM_D_ADD(i).Item("pdp_paamt") & "','" & gsUsrID & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_PODISPRM_INS, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading POM00001 cmdSave_Click sp_insert_PODISPRM : " & rtnStr)
                Me.Cursor = Windows.Forms.Cursors.Default
                IsUpdated = False
            Else
                IsUpdated = True
            End If
        Next


        '****************************
        '*** Update Details Record***
        '****************************
        Dim drPODISPRM_D_UPT() As DataRow = rs_PODISPRM_D.Tables("RESULT").Select("pdp_creusr ='~*UPD*~'")
        For i As Integer = 0 To drPODISPRM_D_UPT.Length() - 1


            gspStr = "sp_Update_PODISPRM '" & gsCompany & "','" & UCase(txtPONo.Text) & "','D','" & drPODISPRM_D_UPT(i).Item("pdp_seqno") & "','" & drPODISPRM_D_UPT(i).Item("pdp_dpltyp") & "','" & _
                    drPODISPRM_D_UPT(i).Item("pdp_dsc") & "','" & _
                    drPODISPRM_D_UPT(i).Item("pdp_pctamt") & "','" & drPODISPRM_D_UPT(i).Item("pdp_purpct") & "','" & _
                    drPODISPRM_D_UPT(i).Item("pdp_paamt") & "','" & gsUsrID & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_PODISPRM_UPT, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading POM00001 cmdSave_Click sp_Update_PODISPRM : " & rtnStr)
                Me.Cursor = Windows.Forms.Cursors.Default
                IsUpdated = False
            Else
                IsUpdated = True
            End If
        Next



        '*********************************************************************************************
        '*********************************SCDISPRM Pre**********************************************

        '****************************
        '*** Delete Details Record***
        '****************************
        Dim drPODISPRM_P_DEL() As DataRow = rs_PODISPRM_P.Tables("RESULT").Select("pdp_creusr ='~*DEL*~'")
        For i As Integer = 0 To drPODISPRM_P_DEL.Length() - 1
            gspStr = "sp_Physical_Delete_PODISPRM '" & gsCompany & "','" & UCase(txtPONo.Text) & "','P','" & drPODISPRM_P_DEL(i).Item("pdp_seqno") & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_PODISPRM_DEL2, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading POM00001 cmdSave_Click SCDISPRMPre sp_Physical_Delete_PODISPRM : " & rtnStr)
                Me.Cursor = Windows.Forms.Cursors.Default
                IsUpdated = False
            Else
                IsUpdated = True
            End If
        Next



        '****************************
        '*** Add Details Record***
        '****************************
        Dim drPODISPRM_P_ADD() As DataRow = rs_PODISPRM_P.Tables("RESULT").Select("pdp_creusr ='~*ADD*~'")
        For i As Integer = 0 To drPODISPRM_P_ADD.Length() - 1


            gspStr = "sp_insert_PODISPRM '" & gsCompany & "','" & UCase(txtPONo.Text) & "','P','" & drPODISPRM_P_ADD(i).Item("pdp_dpltyp") & "','" & _
                    drPODISPRM_P_ADD(i).Item("pdp_dsc") & "','" & _
                    drPODISPRM_P_ADD(i).Item("pdp_pctamt") & "','" & drPODISPRM_P_ADD(i).Item("pdp_purpct") & "','" & _
                    drPODISPRM_P_ADD(i).Item("pdp_paamt") & "','" & gsUsrID & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_PODISPRM_INS2, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading POM00001 cmdSave_Click SCDISPRMPre sp_insert_PODISPRM : " & rtnStr)
                Me.Cursor = Windows.Forms.Cursors.Default
                IsUpdated = False
            Else
                IsUpdated = True
            End If
        Next


        '****************************
        '*** Update Details Record***
        '****************************
        Dim drPODISPRM_P_UPT() As DataRow = rs_PODISPRM_P.Tables("RESULT").Select("pdp_creusr ='~*UPD*~'")
        For i As Integer = 0 To drPODISPRM_P_UPT.Length() - 1


            gspStr = "sp_Update_PODISPRM '" & gsCompany & "','" & UCase(txtPONo.Text) & "','P','" & drPODISPRM_P_UPT(i).Item("pdp_seqno") & "','" & drPODISPRM_P_UPT(i).Item("pdp_dpltyp") & "','" & _
                    drPODISPRM_P_UPT(i).Item("pdp_dsc") & "','" & _
                    drPODISPRM_P_UPT(i).Item("pdp_pctamt") & "','" & drPODISPRM_P_UPT(i).Item("pdp_purpct") & "','" & _
                    drPODISPRM_P_UPT(i).Item("pdp_paamt") & "','" & gsUsrID & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_PODISPRM_UPT2, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading POM00001 cmdSave_Click SCDISPRMPre drPODISPRM_P_UPT : " & rtnStr)
                Me.Cursor = Windows.Forms.Cursors.Default
                IsUpdated = False
            Else
                IsUpdated = True
            End If
        Next



        ''*********************************************************************************************
        Call Update_ShpMrk()
        For i As Integer = 0 To rs_POSHPMRK.Tables("RESULT").Rows.Count - 1

            gspStr = "sp_Update_POSHPMRK '" & gsCompany & "','" & UCase(txtPONo.Text) & "','" & rs_POSHPMRK.Tables("RESULT").Rows(i).Item("psm_shptyp") & "','" & _
            Replace(rs_POSHPMRK.Tables("RESULT").Rows(i).Item("psm_engdsc"), "'", "''") & "','" & _
            Replace(rs_POSHPMRK.Tables("RESULT").Rows(i).Item("psm_chndsc"), "'", "''") & "','" & Replace(rs_POSHPMRK.Tables("RESULT").Rows(i).Item("psm_engrmk"), "'", "''") & "','" & _
            Replace(rs_POSHPMRK.Tables("RESULT").Rows(i).Item("psm_chnrmk"), "'", "''") & "','" & gsUsrID & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_PODISPRM_UPT2, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading POM00001 cmdSave_Click sp_select_POSHPMRK : " & rtnStr)
                Me.Cursor = Windows.Forms.Cursors.Default
                IsUpdated = False
            Else
                IsUpdated = True
            End If
        Next


        ''************************ Update PO Detail ********************************************
        Call Update_PODtl() 'Call Update_PODtl
        'rs_POORDDTL.MoveFirst()
        rs_POORDDTL.Tables("RESULT").Columns("pod_candat").ReadOnly = False
        For i As Integer = 0 To rs_POORDDTL.Tables("RESULT").Rows.Count - 1
            If Not IsDate(rs_POORDDTL.Tables("RESULT").Rows(i).Item("pod_candat")) Then
                rs_POORDDTL.Tables("RESULT").Rows(i).Item("pod_candat") = default_date
            End If
            gspStr = ""
            If txtPOCDate = Format(rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_pocdat"), "MM/dd/yyyy") And txtShpEnd.Text = Format(rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_shpend"), "MM/dd/yyyy") And txtShpStr.Text = Format(rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_shpstr"), "MM/dd/yyyy") Or YesNoCancel = MsgBoxResult.No Then
                gspStr = "sp_Update_POORDDTL '" & gsCompany & "','" & UCase(txtPONo.Text) & "','" & rs_POORDDTL.Tables("RESULT").Rows(i).Item("pod_purseq") & "','" & _
                        Replace(rs_POORDDTL.Tables("RESULT").Rows(i).Item("pod_rmk"), "'", "''") & "','" & _
                        IIf(rs_POORDDTL.Tables("RESULT").Rows(i).Item("pod_candat") = default_date, "", Format(CDate(rs_POORDDTL.Tables("RESULT").Rows(i).Item("pod_candat")))) & "','" & _
                        Format(CDate(rs_POORDDTL.Tables("RESULT").Rows(i).Item("pod_shpstr")), "MM/dd/yyyy") & "','" & _
                        Format(CDate(rs_POORDDTL.Tables("RESULT").Rows(i).Item("pod_shpend")), "MM/dd/yyyy") & "','" & _
                        Replace(rs_POORDDTL.Tables("RESULT").Rows(i).Item("pod_chndsc"), "'", "''") & "','" & gsUsrID & "'"



            Else

                'If txtPoCDat.Text <> "  /  /    " Then
                'txtPoCDat.Text = Format(CDate(txtPoCDat.Text), "MM/DD/YYYY")
                'End If
                If txtPOCDate <> Format(rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_pocdat"), "MM/dd/yyyy") And txtShpEnd.Text = Format(rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_shpend"), "MM/dd/yyyy") And txtShpStr.Text = Format(rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_shpstr"), "MM/dd/yyyy") Then

                    gspStr = "sp_Update_POORDDTL '" & gsCompany & "','" & UCase(txtPONo.Text) & "','" & rs_POORDDTL.Tables("RESULT").Rows(i).Item("pod_purseq") & "','" & _
                            Replace(rs_POORDDTL.Tables("RESULT").Rows(i).Item("pod_rmk"), "'", "''") & "','" & _
                            IIf(txtPOCDate = default_date, "", Format(CDate(txtPOCDate))) & "','" & _
                            Format(CDate(rs_POORDDTL.Tables("RESULT").Rows(i).Item("pod_shpstr")), "MM/dd/yyyy") & "','" & _
                            Format(CDate(rs_POORDDTL.Tables("RESULT").Rows(i).Item("pod_shpend")), "MM/dd/yyyy") & "','" & _
                            Replace(rs_POORDDTL.Tables("RESULT").Rows(i).Item("pod_chndsc"), "'", "''") & "','" & gsUsrID & "'"


                Else
                    'If rs_POORDDTL("pod_candat") <> "  /  /    " Then
                    'rs_POORDDTL("pod_candat") = Format(CDate(rs_POORDDTL("pod_candat")), "MM/DD/YYYY")
                    'End If
                    If txtPOCDate = Format(rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_pocdat"), "MM/dd/yyyy") And (txtShpEnd.Text <> Format(rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_shpend"), "MM/dd/yyyy") Or txtShpStr.Text = Format(rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_shpstr"), "MM/dd/yyyy")) Then

                        gspStr = "sp_Update_POORDDTL '" & gsCompany & "','" & UCase(txtPONo.Text) & "','" & rs_POORDDTL.Tables("RESULT").Rows(i).Item("pod_purseq") & "','" & _
                                Replace(rs_POORDDTL.Tables("RESULT").Rows(i).Item("pod_rmk"), "'", "''") & "','" & _
                                IIf(rs_POORDDTL.Tables("RESULT").Rows(i).Item("pod_candat") = default_date, "", Format(CDate(rs_POORDDTL.Tables("RESULT").Rows(i).Item("pod_candat")))) & "','" & _
                                CDate(txtShpStr.Text) & "','" & _
                                CDate(txtShpEnd.Text) & "','" & _
                                Replace(rs_POORDDTL.Tables("RESULT").Rows(i).Item("pod_chndsc"), "'", "''") & "','" & gsUsrID & "'"



                    Else

                        'If txtPoCDat.Text <> "  /  /    " Then
                        'txtPoCDat.Text = Format(CDate(txtPoCDat.Text), "MM/DD/YYYY")
                        'End If

                        gspStr = "sp_Update_POORDDTL '" & gsCompany & "','" & UCase(txtPONo.Text) & "','" & rs_POORDDTL.Tables("RESULT").Rows(i).Item("pod_purseq") & "','" & _
                                Replace(rs_POORDDTL.Tables("RESULT").Rows(i).Item("pod_rmk"), "'", "''") & "','" & _
                                IIf(txtPOCDate = default_date, "", Format(txtPOCDate)) & "','" & _
                                CDate(txtShpStr.Text) & "','" & _
                                CDate(txtShpEnd.Text) & "','" & _
                                Replace(rs_POORDDTL.Tables("RESULT").Rows(i).Item("pod_chndsc"), "'", "''") & "','" & gsUsrID & "'"



                    End If
                End If
            End If





            If gspStr <> "" Then  '*** if there is something to do with s ...

                rtnLong = execute_SQLStatement(gspStr, rs_POORDDTL_UPT, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading POM00001 cmdSave_Click sp_Update_POORDDTL : " & rtnStr)
                    IsUpdated = False
                Else
                    IsUpdated = True
                End If
            End If
        Next


        '**************************Update PODTLBOM*****************************************
        If Not rs_PODTLBOM Is Nothing Then

            'rs_PODTLBOM.Filter = ""

            For i As Integer = 0 To rs_PODTLBOM.Tables("RESULT").Rows.Count - 1

                gspStr = "sp_Update_PODTLBOM '" & gsCompany & "','" & UCase(txtPONo.Text) & "','" & rs_PODTLBOM.Tables("RESULT").Rows(i).Item("pdb_seq") & "','" & _
                        rs_PODTLBOM.Tables("RESULT").Rows(i).Item("pdb_assitm") & "','" & _
                        rs_PODTLBOM.Tables("RESULT").Rows(i).Item("pdb_bomitm") & "','" & _
                        rs_PODTLBOM.Tables("RESULT").Rows(i).Item("pdb_colcde") & "','" & _
                        rs_PODTLBOM.Tables("RESULT").Rows(i).Item("pdb_venno") & "','" & _
                        rs_PODTLBOM.Tables("RESULT").Rows(i).Item("pdb_curcde") & "','" & _
                        rs_PODTLBOM.Tables("RESULT").Rows(i).Item("pdb_ftyprc") & "','" & gsUsrID & "'"

                'If S <> "" Then  '*** if there is something to do with s ...
                rtnLong = execute_SQLStatement(gspStr, rs_PODTLBOM_UPT, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading POM00001 cmdSave_Click sp_Update_PODTLBOM : " & rtnStr)
                    IsUpdated = False
                Else
                    IsUpdated = True
                End If
                'End If
            Next

        End If




        '**************************Update PODTLSHP*****************************************
        If txtShpEnd.Text <> Format(DateTime.Parse(rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_shpend")), "MM/dd/yyyy") Or txtShpStr.Text <> Format(DateTime.Parse(rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_shpstr")), "MM/dd/yyyy") Then
            gspStr = "sp_Physical_Delete_PODTLSHP '" & gsCompany & "','" & UCase(txtPONo.Text) & "','99','99'"
            'if S <> "" Then  '*** if there is something to do with s ...
            rtnLong = execute_SQLStatement(gspStr, rs_PODTLSHP_DEL, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading POM00001 cmdSave_Click sp_Physical_Delete_PODTLSHP : " & rtnStr)
                IsUpdated = False
            Else
                IsUpdated = True
            End If
            'End If
        Else
            '****************************
            '*** Delete Details Record***
            '****************************

            Dim drPODTLSHP_DEL() As DataRow = rs_PODTLSHP.Tables("RESULT").Select("pds_creusr ='~*DEL*~'")
            'rs_PODTLSHP.Filter = "pds_creusr ='~*DEL*~'"
            'S = ""
            'While Not rs_PODTLSHP.EOF
            For i As Integer = 0 To drPODTLSHP_DEL.Length - 1
                gspStr = "sp_Physical_Delete_PODTLSHP '" & gsCompany & "','" & UCase(txtPONo.Text) & "','" & drPODTLSHP_DEL(i).Item("pds_seq") & "','" & drPODTLSHP_DEL(i).Item("pds_shpseq") & "'"
                'if S <> "" Then  '*** if there is something to do with s ...
                rtnLong = execute_SQLStatement(gspStr, rs_PODTLSHP_DEL, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading POM00001 cmdSave_Click sp_Physical_Delete_PODTLSHP : " & rtnStr)

                    IsUpdated = False
                Else
                    IsUpdated = True
                End If
                'End If
            Next
            'rs_PODTLSHP.MoveNext()
            'End While

            '****************************
            '*** Add Details Record***
            '****************************
            Dim drPODTLSHP_ADD() As DataRow = rs_PODTLSHP.Tables("RESULT").Select("pds_creusr ='~*ADD*~' ")
            'S = ""

            'While Not rs_PODTLSHP.EOF
            For i As Integer = 0 To drPODTLSHP_ADD.Length - 1


                gspStr = "sp_insert_PODTLSHP '" & gsCompany & "','" & UCase(txtPONo.Text) & "','" & drPODTLSHP_ADD(i).Item("pds_seq") & "','" & _
                        drPODTLSHP_ADD(i).Item("pds_from") & "','" & drPODTLSHP_ADD(i).Item("pds_to") & "','" & _
                        drPODTLSHP_ADD(i).Item("pds_ttlctn") & "','" & gsUsrID & "'"

                'If S <> "" Then  '*** if there is something to do with s ...
                rtnLong = execute_SQLStatement(gspStr, rs_PODTLSHP_ADD, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading POM00001 cmdSave_Click sp_insert_PODTLSHP : " & rtnStr)
                    IsUpdated = False
                Else
                    IsUpdated = True
                End If
            Next

            'End If
            'rs_PODTLSHP.MoveNext()
            'End While


            Dim drPODTLSHP_UPT() As DataRow = rs_PODTLSHP.Tables("RESULT").Select("pds_creusr ='~*UPD*~'")
            'S = ""

            'While Not rs_PODTLSHP.EOF
            For i As Integer = 0 To drPODTLSHP_UPT.Length - 1
                gspStr = "sp_Update_PODTLSHP '" & gsCompany & "','" & UCase(txtPONo.Text) & "','" & drPODTLSHP_UPT(i).Item("pds_seq") & "','" & _
                        drPODTLSHP_UPT(i).Item("pds_shpseq") & "','" & _
                        drPODTLSHP_UPT(i).Item("pds_from") & "','" & drPODTLSHP_UPT(i).Item("pds_to") & "','" & _
                        drPODTLSHP_UPT(i).Item("pds_ttlctn") & "','" & gsUsrID & "'"

                'If S <> "" Then  '*** if there is something to do with s ...
                rtnLong = execute_SQLStatement(gspStr, rs_PODTLSHP_UPT, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading POM00001 cmdSave_Click sp_insert_PODTLSHP : " & rtnStr)
                    IsUpdated = False
                Else
                    IsUpdated = True
                End If
            Next
            '    End If
            '    rs_PODTLSHP.MoveNext()
            '    End While
        End If
        Call CalNetAmt()

        Dim Agent As String
        Dim sales As String
        Dim prctrm As String
        Dim PayTrm As String

        If UBound(Split(cboAgent.Text, " - ")) > 0 Then
            Agent = Split(cboAgent.Text, " - ")(0)
        Else
            Agent = ""
        End If


        If UBound(Split(cboSalesRep.Text, " - ")) > 0 Then
            sales = Split(cboSalesRep.Text, " - ")(0)
        Else
            sales = ""
        End If

        If UBound(Split(cboPrcTrm.Text, " - ")) > 0 Then
            prctrm = Split(cboPrcTrm.Text, " - ")(0)
        Else
            prctrm = ""
        End If

        If UBound(Split(cboPayTrm.Text, " - ")) > 0 Then
            PayTrm = Split(cboPayTrm.Text, " - ")(0)
        Else
            PayTrm = ""
        End If
        If IsDate(txtPOCDate) Then
            txtPOCDate = CDate(txtPOCDate)
        End If


        Dim cty As String
        If UBound(Split(Me.txtCty.Text, " - ")) > 0 Then
            cty = Split(Me.txtCty.Text, " - ")(0)
        Else
            cty = ""
        End If


        gspStr = "sp_Update_POORDHDR '" & gsCompany & "','" & UCase(txtPONo.Text) & _
              "','" & cboPorCtp.Text & _
              "','" & Agent & _
              "','" & sales & _
              "','" & CDate(txtShpStr.Text) & _
              "','" & CDate(txtShpEnd.Text) & _
              "','" & txtLblDue.Text & _
              "','" & IIf(txtPOCDate = default_date, "", txtPOCDate) & _
              "','" & txtNetAmt.Text & _
              "','" & prctrm & _
              "','" & PayTrm & _
              "','" & Replace(txtRmk.Text, "'", "''") & _
              "','" & txtDiscnt.Text & _
              "','" & Replace(txtRemAddr.Text, "'", "''") & _
              "','" & Me.txtStt.Text & _
              "','" & cty & _
              "','" & Me.txtPst.Text & _
              "','" & Replace(txtRemChnAddr.Text, "'", "''") & _
              "','" & IIf(chkSignApp.Checked = True, "Y", "N") & _
              "','" & IIf(chkVndAck.Checked = True, "Y", "N") & _
              "','" & txtDest.Text & _
              "','" & gsUsrID & "'"

        rtnLong = execute_SQLStatement(gspStr, rs_POORDHDR_UPT, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading POM00001 cmdSave_Click sp_Update_POORDHDR : " & rtnStr)
            IsUpdated = False
        Else
            IsUpdated = True
        End If

        cmdFind_Click(sender, e)

        Me.Cursor = Windows.Forms.Cursors.Default

        If IsUpdated Then
            Call setStatus("Save")
        End If
        Recordstatus = False

    End Sub

    Private Sub txtDRmk_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Recordstatus = True
    End Sub

    Private Sub cmdBOM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBOM.Click
        'rs_PODTLBOM_FILTER = rs_PODTLBOM.Clone
        Dim drPODTLBOM() As DataRow = rs_PODTLBOM.Tables("RESULT").Select("pdb_seq ='" & txtPurSeq.Text & "'")

        If drPODTLBOM.Length > 0 Then
            Dim frm_frmPOBom As New frmPOBom(rs_PODTLBOM, txtPurSeq.Text)
            frm_frmPOBom.MdiParent = Me.MdiParent
            frm_frmPOBom.Show()

            AddHandler frm_frmPOBom.returnSelectedRecords, AddressOf returnSelectedRecordsHandler
        End If


        'rs_PODTLBOM.Filter = "pdb_seq ='" & txtPurSeq.Text & "'"

        'If rs_PODTLBOM.recordCount > 0 Then

        '    frmPOBom.grdPOBom.DataSource = rs_PODTLBOM
        '    Call Display_GrdPOBOM()
        '    Call Fill_LstVen()

        '    frmPOBom.Left = (Me.Width / 2) - (frmPOBom.width / 2)
        '    frmPOBom.Top = (Me.Height / 2) - (frmPOBom.Height / 2)
        '    frmPOBom.Show(vbModal)
        'End If
    End Sub

    Private Sub returnSelectedRecordsHandler(ByVal sender As Object, ByVal temp_RecordStatus As Boolean, ByVal temp_rs_PODTLBOM As DataSet)
        MsgBox(temp_RecordStatus)
        If temp_RecordStatus = True Then
            rs_PODTLBOM = temp_rs_PODTLBOM
            Recordstatus = True
        End If
    End Sub

    Private Sub cmdAss_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAss.Click



        'rs_PODTLASS.Filter = "pda_seq = '" & txtPurSeq.Text & "'"



        'If rs_PODTLASS.recordCount > 0 Then

        '    frmPOAss.grdPOAss.DataSource = rs_PODTLASS
        '    Call Display_GrdPOAss()

        '    frmPOAss.Left = (Me.Width / 2) - (frmPOAss.width / 2)
        '    frmPOAss.Top = (Me.Height / 2) - (frmPOAss.Height / 2)
        '    frmPOAss.Show(vbModal)

        'End If
        'rs_PODTLASS_FILTER = rs_PODTLASS.Clone
        Dim drPODTLASS() As DataRow = rs_PODTLASS.Tables("RESULT").Select("pda_seq = '" & txtPurSeq.Text & "'")

        If drPODTLASS.Length > 0 Then
            Dim frm_frmPOAss As New frmPOAss(rs_PODTLASS, txtPurSeq.Text)
            frm_frmPOAss.MdiParent = Me.MdiParent
            frm_frmPOAss.Show()

        End If

    End Sub

    Private Sub cmdCartonMore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCartonMore.Click

        ''Dim S As String
        ''Dim rs() As ADOR.Recordset
        ''Dim PODTCTN_Reccount As Integer

        'gspStr = "sp_select_PODTLCTN '" & gsCompany & "','" & txtPONo.Text & "'"
        'Me.Cursor = Windows.Forms.Cursors.WaitCursor
        'rtnLong = execute_SQLStatement(gspStr, rs_PODTLCTN_temp, rtnStr)
        'Me.Cursor = Windows.Forms.Cursors.Default
        'If rtnLong <> RC_SUCCESS Then
        '    MsgBox("Error on loading POM00001 cmdCartonMore_Click sp_select_PODTLCTN : " & rtnStr)
        '    Exit Sub
        'Else
        '    If rs_PODTLCTN Is Nothing Then
        '        rs_PODTLCTN = rs_PODTLCTN_temp
        '        rs_PODTLCTNC = rs_PODTLCTN_temp
        '    End If
        'End If
        'If rs_PODTLCTN.Tables("RESULT").Rows.Count = 0 Then
        '    MsgBox("No Record Found!") '    msg("M00071")
        '    Exit Sub
        'Else



        '    Dim frm_frmPOCarton As New frmPOCarton(rs_PODTLCTN, cboPOStatus, rs_POORDDTL, current_row, txtPurSeq.Text)
        '    frm_frmPOCarton.MdiParent = Me.MdiParent
        '    frm_frmPOCarton.Show()

        '    AddHandler frm_frmPOCarton.returnSelectedRecords, AddressOf returnCartonSelectedRecordsHandler

        'End If





        ' ''*** Add Checking of record count is more than 0
        ''If rs_PODTLCTN.recordCount <> 0 Then
        ''    Screen.MousePointer = vbDefault
        ''    frmPOCarton.Left = (Me.Width / 2) - (frmPOCarton.Width / 2)
        ''    frmPOCarton.Top = (Me.Height / 2) - (frmPOCarton.Height / 2)
        ''    frmPOCarton.Show(vbModal)
        ''Else
        ''    Screen.MousePointer = vbDefault
        ''    msg("M00071")
        ''    rs_PODTLCTN.Filter = ""
        ''End If
    End Sub

    Private Sub returnCartonSelectedRecordsHandler(ByVal sender As Object, ByVal temp_RecordStatus As Boolean, ByVal temp_rs_PODTLCTN As DataSet)
        MsgBox(temp_RecordStatus)
        If temp_RecordStatus = True Then
            rs_PODTLCTN = temp_rs_PODTLCTN
            Recordstatus = True
        End If
    End Sub



    Private Sub cmdShpDatMore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShpDatMore.Click
        'rs_PODTLSHP.Filter = "pds_seq = '" & txtPurSeq.Text & "'"

        'frmPOShip.totalQty = rs_POORDDTL("pod_ordqty").Value


        'frmPOShip.grdPOShip.DataSource = rs_PODTLSHP
        'Call Display_GrdPOShip()

        'frmPOShip.Left = (Me.Width / 2) - (frmPOShip.Width / 2)
        'frmPOShip.Top = (Me.Height / 2) - (frmPOShip.Height / 2)
        'frmPOShip.Show(vbModal)



        Dim frm_frmPOShip As New frmPOShip(rs_PODTLSHP, cboPOStatus, txtPurSeq.Text)
        frm_frmPOShip.MdiParent = Me.MdiParent
        frm_frmPOShip.Show()

        AddHandler frm_frmPOShip.returnSelectedRecords, AddressOf returnShipSelectedRecordsHandler

    End Sub

    Private Sub returnShipSelectedRecordsHandler(ByVal sender As Object, ByVal temp_RecordStatus As Boolean, ByVal temp_rs_PODTLSHP As DataSet)
        'MsgBox(temp_RecordStatus)
        If temp_RecordStatus = True Then
            rs_PODTLSHP = temp_rs_PODTLSHP
            Recordstatus = True
        End If
    End Sub
    Private Sub CalNetAmt()
        Dim disamt As Double
        Dim preamt As Double
        For i As Integer = 0 To rs_PODISPRM_D.Tables("RESULT").Rows.Count - 1
            rs_PODISPRM_D.Tables("RESULT").Columns(i).ReadOnly = False
        Next
        Dim dr_PODISPRM_D() As DataRow = rs_PODISPRM_D.Tables("RESULT").Select("pdp_creusr <> '~*DEL*~' and pdp_creusr <> '~*NEW*~'")
        rs_PODISPRM_D.Tables("RESULT").Columns("pdp_paamt").ReadOnly = False
        rs_PODISPRM_D.Tables("RESULT").Columns("pdp_creusr").ReadOnly = False
        For i As Integer = 0 To dr_PODISPRM_D.Length - 1
            If dr_PODISPRM_D(i).Item("pdp_pctamt") = "P" Then
                disamt = txtTtlAmt.Text * dr_PODISPRM_D(i).Item("pdp_purpct") / 100 + disamt
            Else
                disamt = disamt + dr_PODISPRM_D(i).Item("pdp_paamt")
            End If
        Next

        For i As Integer = 0 To rs_PODISPRM_P.Tables("RESULT").Rows.Count - 1
            rs_PODISPRM_P.Tables("RESULT").Columns(i).ReadOnly = False
        Next
        Dim dr_PODISPRM_P() As DataRow = rs_PODISPRM_P.Tables("RESULT").Select("pdp_creusr <> '~*DEL*~' and pdp_creusr <> '~*NEW*~'")
        rs_PODISPRM_P.Tables("RESULT").Columns("pdp_paamt").ReadOnly = False
        rs_PODISPRM_P.Tables("RESULT").Columns("pdp_creusr").ReadOnly = False

        For i As Integer = 0 To dr_PODISPRM_P.Length - 1
            If dr_PODISPRM_P(i).Item("pdp_pctamt") = "P" Then
                preamt = txtTtlAmt.Text * dr_PODISPRM_P(i).Item("pdp_purpct") / 100 + preamt
            Else
                preamt = preamt + dr_PODISPRM_P(i).Item("pdp_paamt")
            End If
        Next



        Dim tempamt As Double

        'Call Cal_DisPre()
        Total_D_Amt = 0
        Total_D_Per = 0
        Total_P_Amt = 0
        Total_P_Per = 0

        If dr_PODISPRM_D.Length > 0 Then

            For i As Integer = 0 To dr_PODISPRM_D.Length - 1
                If dr_PODISPRM_D(i).Item("pdp_creusr") <> "~*DEL*~" And dr_PODISPRM_D(i).Item("pdp_creusr") <> "~*NEW*~" Then
                    If dr_PODISPRM_D(i).Item("pdp_pctamt") = "P" Then
                        Total_D_Per = Total_D_Per + dr_PODISPRM_D(i).Item("pdp_purpct")
                        dr_PODISPRM_D(i).Item("pdp_paamt") = CDbl(txtTtlAmt.Text) * (CDbl(dr_PODISPRM_D(i).Item("pdp_purpct")) / 100)
                    Else
                        Total_D_Amt = Total_D_Amt + dr_PODISPRM_D(i).Item("pdp_paamt")
                    End If
                    If dr_PODISPRM_D(i).Item("pdp_creusr") <> "~*ADD*~" And _
                        dr_PODISPRM_D(i).Item("pdp_creusr") <> "~*DEL*~" And _
                        dr_PODISPRM_D(i).Item("pdp_creusr") <> "~*NEW*~" Then
                        dr_PODISPRM_D(i).Item("pdp_creusr") = "~*UPD*~"
                    End If

                    'rs_PODISPRM_D.Update()

                End If
            Next
        End If


        If dr_PODISPRM_P.Length > 0 Then
            For i As Integer = 0 To dr_PODISPRM_P.Length - 1
                If dr_PODISPRM_P(i).Item("pdp_creusr") <> "~*DEL*~" And dr_PODISPRM_P(i).Item("pdp_creusr") <> "~*NEW*~" Then
                    If dr_PODISPRM_P(i).Item("pdp_pctamt") = "P" Then
                        Total_P_Per = Total_P_Per + dr_PODISPRM_P(i).Item("pdp_purpct")
                        dr_PODISPRM_P(i).Item("pdp_paamt") = CDbl(txtTtlAmt.Text) * (CDbl(dr_PODISPRM_P(i).Item("pdp_purpct")) / 100)
                    Else
                        Total_P_Amt = Total_P_Amt + dr_PODISPRM_P(i).Item("pdp_paamt")
                    End If
                    If dr_PODISPRM_P(i).Item("pdp_creusr") <> "~*ADD*~" And _
                        dr_PODISPRM_P(i).Item("pdp_creusr") <> "~*DEL*~" And _
                        dr_PODISPRM_P(i).Item("pdp_creusr") <> "~*NEW*~" Then
                        dr_PODISPRM_P(i).Item("pdp_creusr") = "~*UPD*~"
                    End If

                End If
            Next
        End If
        If txtTtlAmt.Text = "" Then txtTtlAmt.Text = 0
        tempamt = txtTtlAmt.Text + preamt - disamt
        If txtDiscnt.Text = "" Then txtDiscnt.Text = 0
        txtNetAmt.Text = tempamt - (tempamt * txtDiscnt.Text / 100)
        txtNetAmt.Text = Format(CDbl(txtNetAmt.Text), "#####.00")

    End Sub

    Private Function ChkDate() As Boolean
        ChkDate = False


        If CDate(txtShpStr.Text) > CDate(txtShpEnd.Text) Then
            MsgBox("Ship Start Date should not be greater than Ship End Date")
            If txtShpEnd.Enabled And txtShpEnd.Visible Then txtShpEnd.Focus()

            Exit Function

        End If

        '2016-01-05 Confirmed EDP change check for PO Cancel Start with Ship Start, PO Cancel End with Ship End

        'If IsDate(txtPoCDatFrm.Text) Then
        '    If CDate(txtPoCDatFrm.Text) < CDate(txtShpEnd.Text) Or CDate(txtPoCDatFrm.Text) < CDate(txtShpStr.Text) Then
        '        MsgBox("PO Cancel Date should not be earlier than Ship Date")
        '        If txtPoCDatFrm.Enabled And txtPoCDatFrm.Visible Then txtPoCDatFrm.Focus()
        '        Exit Function
        '    End If

        'End If

        If IsDate(txtPoCDatFrm.Text) Then
            If CDate(txtPoCDatFrm.Text) < CDate(txtShpStr.Text) Or CDate(txtPoCDatTo.Text) < CDate(txtShpEnd.Text) Then
                MsgBox("PO Cancel Date should not be earlier than Ship Date")
                If txtPoCDatFrm.Enabled And txtPoCDatFrm.Visible Then txtPoCDatFrm.Focus()
                Exit Function
            End If
        End If


        If IsDate(DTDCanDat.Text) Then

        End If
        If IsDate(DTDCanDat.Text) Then
            If CDate(DTDCanDat.Text) < CDate(DTDShpEnd.Text) Or CDate(DTDCanDat.Text) < CDate(DTDShpStr.Text) Then
                MsgBox("PO Cancel Date should not be earlier than Ship Date")
                If DTDCanDat.Enabled And DTDCanDat.Visible Then DTDCanDat.Focus()
                Exit Function
            End If
        End If
        If CDate(DTDShpStr.Text) > CDate(DTDShpEnd.Text) Then
            MsgBox("Ship Start Date should not be greater than Ship End Date")
            If DTDShpEnd.Enabled And DTDShpEnd.Visible Then DTDShpEnd.Focus()
            Exit Function
        End If



        ChkDate = True

    End Function

    Private Function ChecktimeStamp() As Boolean
        'Compare the current record's timestamp and the DB timestamp
        Dim Save_TimeStamp As Long


        gspStr = "sp_select_POORDHDR '" & gsCompany & "','" & txtPONo.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_POORDHDR, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading POM00001 ChecktimeStamp sp_select_POORDHDR : " & rtnStr)
            Me.Cursor = Windows.Forms.Cursors.Default
            Exit Function
        ElseIf rs_POORDHDR.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("RFO") 'msg("M00232")
            ChecktimeStamp = False
            Exit Function
        Else
            Save_TimeStamp = rs_POORDHDR.Tables("RESULT").Rows(0).Item("poh_timstp")
        End If


        'Write your code for Compare
        If Current_TimeStamp <> Save_TimeStamp Then
            ChecktimeStamp = False
        Else
            ChecktimeStamp = True
        End If

    End Function
    Private Sub Update_ShpMrk()
        'If Not rs_POSHPMRK.EOF Then
        'For i As Integer = 0 To rs_POSHPMRK.Tables("RESULT").Rows.Count - 1
        Dim dr() As DataRow

        If prevShpMrkTyp = "M" Then
            dr = rs_POSHPMRK.Tables("RESULT").Select("psm_shptyp = 'M'")
        ElseIf prevShpMrkTyp = "S" Then
            dr = rs_POSHPMRK.Tables("RESULT").Select("psm_shptyp = 'S'")
        ElseIf prevShpMrkTyp = "I" Then 'optInner.Checked = True Then
            dr = rs_POSHPMRK.Tables("RESULT").Select("psm_shptyp = 'I'")
        End If

        If Not dr Is Nothing Then
            If dr.Length > 0 Then
                rs_POSHPMRK.Tables("RESULT").Columns("psm_engdsc").ReadOnly = False
                rs_POSHPMRK.Tables("RESULT").Columns("psm_chndsc").ReadOnly = False
                rs_POSHPMRK.Tables("RESULT").Columns("psm_engrmk").ReadOnly = False
                rs_POSHPMRK.Tables("RESULT").Columns("psm_chnrmk").ReadOnly = False
                dr(0).Item("psm_engdsc") = txtSEngDsc.Text
                dr(0).Item("psm_chndsc") = txtSChnDsc.Text
                dr(0).Item("psm_engrmk") = txtEngRmk.Text
                dr(0).Item("psm_chnrmk") = txtChnRmk.Text
                rs_POSHPMRK.Tables("RESULT").Columns("psm_engdsc").ReadOnly = True
                rs_POSHPMRK.Tables("RESULT").Columns("psm_chndsc").ReadOnly = True
                rs_POSHPMRK.Tables("RESULT").Columns("psm_engrmk").ReadOnly = True
                rs_POSHPMRK.Tables("RESULT").Columns("psm_chnrmk").ReadOnly = True
            End If
        End If

        'Next
        'rs_POSHPMRK.Update()
        'End If
        Call Display_ShpMrk()
    End Sub

    Private Sub TabPageMain_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPageMain.SelectedIndexChanged

        If PreviousTab = 3 Then
            'DoEvents()
            Call Update_PODtl()
            'DoEvents
        End If



        If Me.TabPageMain.SelectedIndex = 0 And find_flag Then
            Call CalNetAmt()
        ElseIf Me.TabPageMain.SelectedIndex = 2 Then
            Call CalNetAmt()
        ElseIf Me.TabPageMain.SelectedIndex = 3 Then
            'Dim varBookmark As Object
            'varSort = rs_POORDDTL.sort
            'varBookmark = rs_POORDDTL.bookmark
            'rs_POORDDTL.bookmark = varBookmark
            Call DisplayPODetail()
        ElseIf Me.TabPageMain.SelectedIndex = 5 Then
            'If Trim(varSort) <> "" Then
            '    rs_POORDDTL.sort = varSort
            'End If
        End If
    End Sub

    Private Sub TabPageMain_Deselected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles TabPageMain.Deselected
        PreviousTab = e.TabPageIndex
    End Sub

    Private Sub txtVendor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVendor.TextChanged
        If Trim(txtVendor.Text) <> "" Then
            If Len(Trim(Split(txtVendor.Text, "-")(0))) > 1 And Trim(Split(txtVendor.Text, "-")(0)) <> "0005" And Trim(Split(txtVendor.Text, "-")(0)) <> "0006" And Trim(Split(txtVendor.Text, "-")(0)) <> "0007" And Trim(Split(txtVendor.Text, "-")(0)) <> "0008" And Trim(Split(txtVendor.Text, "-")(0)) <> "0009" Then
                VendorType = "E"
            Else
                VendorType = "I"
            End If

            If VendorType = "E" Then
                If gsFlgCstExt = 1 Then
                    txtFtyPrc.Visible = True
                    txtTtlAmt.Visible = True
                    txtNetAmt.Visible = True
                    txtDCur.Visible = True
                    Label73.Visible = True
                    txtCur1.Visible = True
                    txtCur2.Visible = True
                    txtDiscnt.Visible = True
                    Label9.Visible = True
                    Label10.Visible = True
                    Label11.Visible = True
                Else
                    txtFtyPrc.Visible = False
                    txtTtlAmt.Visible = False
                    txtNetAmt.Visible = False
                    txtDCur.Visible = False
                    Label73.Visible = False
                    txtCur1.Visible = False
                    txtCur2.Visible = False
                    txtDiscnt.Visible = False
                    Label9.Visible = False
                    Label10.Visible = False
                    Label11.Visible = False
                End If
            Else
                If gsFlgCst = 1 Then
                    txtFtyPrc.Visible = True
                    txtTtlAmt.Visible = True
                    txtNetAmt.Visible = True
                    txtDCur.Visible = True
                    Label73.Visible = True
                    txtCur1.Visible = True
                    txtCur2.Visible = True
                    txtDiscnt.Visible = True
                    Label9.Visible = True
                    Label10.Visible = True
                    Label11.Visible = True

                Else
                    txtFtyPrc.Visible = False
                    txtTtlAmt.Visible = False
                    txtNetAmt.Visible = False
                    txtDCur.Visible = False
                    Label73.Visible = False
                    txtCur1.Visible = False
                    txtCur2.Visible = False
                    txtDiscnt.Visible = False
                    Label9.Visible = False
                    Label10.Visible = False
                    Label11.Visible = False
                End If
            End If
        End If
    End Sub



    Private Sub GrdDis_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GrdDis.Enter
        flag_grdcontrol = "grdDis"
        'GroupBox5.ForeColor = Color.DarkCyan
    End Sub

    Private Sub GrdDis_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GrdDis.Leave
        'GroupBox5.ForeColor = Color.Blue
    End Sub

    Private Sub GrdPre_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GrdPre.Enter
        flag_grdcontrol = "grdPre"
        'GroupBox6.ForeColor = Color.DarkCyan
    End Sub

    Private Sub GrdPre_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GrdPre.Leave
        'GroupBox6.ForeColor = Color.Blue
    End Sub

    Private Sub cboCoCde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoCde.SelectedIndexChanged
        txtCoNam.Text = ChangeCompany(cboCoCde.Text, Me.Name)
        Call getDefault_Path()
        Enq_right_local = Enq_right
        Del_right_local = Del_right
    End Sub

    Private Sub cboPayTrm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPayTrm.KeyPress
        If cboPOStatus.SelectedIndex <> 0 Then
            e.KeyChar = "" 'KeyAscii = 0
        End If
    End Sub

    Private Sub cboPorCtp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPorCtp.SelectedIndexChanged
        Recordstatus = True
    End Sub

    Private Sub cboPOStatus_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPOStatus.Leave
        chkstatus()
    End Sub

    Private Sub cboVenAddr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVenAddr.SelectedIndexChanged
        If Me.cboVenAddr.Text = "" Then
            txtRemAddr.Text = ""
            ' Added by Mark Lau 20081202
            txtRemChnAddr.Text = ""
            txtStt.Text = ""
            txtCty.Text = ""
            txtPst.Text = ""
            Exit Sub
        End If

        If rs_VNCNTINF Is Nothing Then Exit Sub
        If rs_VNCNTINF.Tables("RESULT").Rows.Count = 0 Then Exit Sub

        ' Added by Mark Lau 20081202
        'rs_VNCNTINF.Filter = "vci_adr='" & Trim(Me.cboVenAddr.Text) & "' or vci_chnadr ='" & Trim(Me.cboVenAddr.Text) & "'"
        Dim dr_VNCNTINF() As DataRow = rs_VNCNTINF.Tables("RESULT").Select("vci_adr='" & Trim(Me.cboVenAddr.Text) & "' or vci_chnadr ='" & Trim(Me.cboVenAddr.Text) & "'")
        If dr_VNCNTINF.Length > 0 Then
            ' Added by Mark Lau 20081202
            txtRemAddr.Text = dr_VNCNTINF(0).Item("vci_adr")
            txtRemChnAddr.Text = dr_VNCNTINF(0).Item("vci_chnadr")
            txtStt.Text = dr_VNCNTINF(0).Item("vci_stt")
            txtCty.Text = dr_VNCNTINF(0).Item("vci_cty")
            txtPst.Text = dr_VNCNTINF(0).Item("vci_zip")
        End If
        'rs_VNCNTINF.Filter = ""
    End Sub

    Private Sub cboVenAddr_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVenAddr.Enter
        befVenAddr = Me.cboVenAddr.Text
    End Sub

    Private Sub cboVenAddr_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboVenAddr.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            Call cboVenAddr_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub cboVenAddr_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVenAddr.KeyUp
        Call auto_search_combo(Me.cboVenAddr) 'Call AutoSearch(Me.cboVenAddr, KeyCode)
    End Sub

    Private Sub cboVenAddr_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVenAddr.Leave
        If checkValidCombo(Me.cboVenAddr, cboVenAddr.Text) = False Then 'If ValidateCombo(Me.cboVenAddr) = False Then
            Exit Sub
        End If
        If befVenAddr <> Me.cboVenAddr.Text Then
            Call cboVenAddr_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub cmdDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelRow.Click
        Select Case flag_grdcontrol
            Case "grdDis"
                If Me.TabPageMain.SelectedIndex <> 2 Then
                    Me.TabPageMain.SelectedIndex = 2
                End If
                rs_PODISPRM_D.Tables("RESULT").Columns("pdp_status").ReadOnly = False
                rs_PODISPRM_D.Tables("RESULT").Columns("pdp_creusr").ReadOnly = False
                If Not rs_PODISPRM_D Is Nothing Then
                    Recordstatus = True
                    If rs_PODISPRM_D.Tables("RESULT").Rows(selectedRow).Item("pdp_status").ToString = "Y" Then
                        'GrdDis.col = 0
                        'Call Grddis_DblClick()
                        'Recordstatus = True

                        If rs_PODISPRM_D.Tables("RESULT").Rows.Count > 0 Then 'If rs_PODISPRM_D.recordCount > 0 And Not rs_PODISPRM_D.EOF Then

                            'If GrdDis.col = 0 Then
                            If rs_PODISPRM_D.Tables("RESULT").Rows(selectedRow).Item("pdp_status") = "Y" Then
                                rs_PODISPRM_D.Tables("RESULT").Rows(selectedRow).Item("pdp_status") = ""

                                If rs_PODISPRM_D.Tables("RESULT").Rows(selectedRow).Item("pdp_creusr") = "~*NEW*~" Then
                                    rs_PODISPRM_D.Tables("RESULT").Rows(selectedRow).Item("pdp_creusr") = "~*ADD*~"
                                Else
                                    rs_PODISPRM_D.Tables("RESULT").Rows(selectedRow).Item("pdp_creusr") = "~*UPD*~"
                                End If
                            Else
                                rs_PODISPRM_D.Tables("RESULT").Rows(selectedRow).Item("pdp_status") = "Y"
                                rs_PODISPRM_D.Tables("RESULT").Rows(selectedRow).Item("pdp_creusr") = "~*DEL*~"
                            End If

                            'End If

                        End If

                    Else

                        If rs_PODISPRM_D.Tables("RESULT").Rows(selectedRow).Item("pdp_creusr") <> "~*ADD*~" Then

                            rs_PODISPRM_D.Tables("RESULT").Rows(selectedRow).Item("pdp_creusr") = "~*DEL*~"
                            rs_PODISPRM_D.Tables("RESULT").Rows(selectedRow).Item("pdp_status") = "Y"

                        ElseIf rs_PODISPRM_D.Tables("RESULT").Rows(selectedRow).Item("pdp_creusr") = "~*ADD*~" Then

                            rs_PODISPRM_D.Tables("RESULT").Rows(selectedRow).Item("pdp_creusr") = "~*NEW*~"
                            rs_PODISPRM_D.Tables("RESULT").Rows(selectedRow).Item("pdp_status") = "Y"

                        End If
                    End If
                Else
                    MsgBox("Please Choose a Record") 'msg("M00065")
                End If
                If GrdDis.Enabled And GrdDis.Visible Then GrdDis.Focus()
            Case "grdPre"



                If Me.TabPageMain.SelectedIndex <> 2 Then
                    Me.TabPageMain.SelectedIndex = 2
                End If
                rs_PODISPRM_P.Tables("RESULT").Columns("pdp_status").ReadOnly = False
                rs_PODISPRM_P.Tables("RESULT").Columns("pdp_creusr").ReadOnly = False
                If Not rs_PODISPRM_P Is Nothing Then
                    Recordstatus = True
                    If rs_PODISPRM_P.Tables("RESULT").Rows(selectedRow).Item("pdp_status").ToString = "Y" Then

                        'Call GrdPre_DblClick()
                        If rs_PODISPRM_P.Tables("RESULT").Rows.Count > 0 Then 'If rs_PODISPRM_P.recordCount > 0 And Not rs_PODISPRM_P.EOF Then

                            'If GrdDis.col = 0 Then
                            If rs_PODISPRM_P.Tables("RESULT").Rows(selectedRow).Item("pdp_status") = "Y" Then
                                rs_PODISPRM_P.Tables("RESULT").Rows(selectedRow).Item("pdp_status") = ""

                                If rs_PODISPRM_P.Tables("RESULT").Rows(selectedRow).Item("pdp_creusr") = "~*NEW*~" Then
                                    rs_PODISPRM_P.Tables("RESULT").Rows(selectedRow).Item("pdp_creusr") = "~*ADD*~"
                                Else
                                    rs_PODISPRM_P.Tables("RESULT").Rows(selectedRow).Item("pdp_creusr") = "~*UPD*~"
                                End If
                            Else
                                rs_PODISPRM_P.Tables("RESULT").Rows(selectedRow).Item("pdp_status") = "Y"
                                rs_PODISPRM_P.Tables("RESULT").Rows(selectedRow).Item("pdp_creusr") = "~*DEL*~"
                            End If

                            'End If

                        End If

                    Else

                        If rs_PODISPRM_P.Tables("RESULT").Rows(selectedRow).Item("pdp_creusr") <> "~*ADD*~" Then

                            rs_PODISPRM_P.Tables("RESULT").Rows(selectedRow).Item("pdp_creusr") = "~*DEL*~"
                            rs_PODISPRM_P.Tables("RESULT").Rows(selectedRow).Item("pdp_status") = "Y"

                        ElseIf rs_PODISPRM_P.Tables("RESULT").Rows(selectedRow).Item("pdp_creusr") = "~*ADD*~" Then

                            rs_PODISPRM_P.Tables("RESULT").Rows(selectedRow).Item("pdp_creusr") = "~*NEW*~"
                            rs_PODISPRM_P.Tables("RESULT").Rows(selectedRow).Item("pdp_status") = "Y"

                        End If
                    End If
                Else
                    MsgBox("Please Choose a Record") 'msg("M00065")
                End If

                If GrdPre.Enabled And GrdPre.Visible Then GrdPre.Focus()

        End Select
    End Sub

    Private Sub GrdDis_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdDis.CellEnter
        selectedRow = e.RowIndex
        Recordstatus = True
        If rs_PODISPRM_D.Tables("RESULT").Rows.Count > 0 Then
            Select Case e.ColumnIndex

                Case 7

                    If rs_PODISPRM_D.Tables("RESULT").Rows(selectedRow).Item("pdp_pctamt") = "P" Then
                        rs_PODISPRM_D.Tables("RESULT").Columns("pdp_purpct").ReadOnly = False
                        GrdDis.Columns(7).ReadOnly = False
                    Else
                        rs_PODISPRM_D.Tables("RESULT").Columns("pdp_purpct").ReadOnly = True
                        GrdDis.Columns(7).ReadOnly = True
                    End If



                Case 8
                    If rs_PODISPRM_D.Tables("RESULT").Rows(selectedRow).Item("pdp_pctamt") = "A" Then
                        rs_PODISPRM_D.Tables("RESULT").Columns("pdp_paamt").ReadOnly = False
                        GrdDis.Columns(8).ReadOnly = False
                    Else
                        rs_PODISPRM_D.Tables("RESULT").Columns("pdp_paamt").ReadOnly = True
                        GrdDis.Columns(8).ReadOnly = True

                    End If
            End Select
        End If
    End Sub

    Private Sub GrdPre_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdPre.CellEnter
        selectedRow = e.RowIndex
        Recordstatus = True
        If rs_PODISPRM_P.Tables("RESULT").Rows.Count > 0 Then
            Select Case e.ColumnIndex

                Case 7

                    If rs_PODISPRM_P.Tables("RESULT").Rows(selectedRow).Item("pdp_pctamt") = "P" Then
                        rs_PODISPRM_P.Tables("RESULT").Columns("pdp_purpct").ReadOnly = False
                        GrdPre.Columns(7).ReadOnly = False
                    Else
                        rs_PODISPRM_P.Tables("RESULT").Columns("pdp_purpct").ReadOnly = True
                        GrdPre.Columns(7).ReadOnly = True
                    End If



                Case 8
                    If rs_PODISPRM_P.Tables("RESULT").Rows(selectedRow).Item("pdp_pctamt") = "A" Then
                        rs_PODISPRM_P.Tables("RESULT").Columns("pdp_paamt").ReadOnly = False
                        GrdPre.Columns(8).ReadOnly = False
                    Else
                        rs_PODISPRM_P.Tables("RESULT").Columns("pdp_paamt").ReadOnly = True
                        GrdPre.Columns(8).ReadOnly = True

                    End If
            End Select
        End If
    End Sub

    Private Sub cmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInsRow.Click
        Recordstatus = True

        Select Case flag_grdcontrol
            '**************************GrdBasicCol****************************************************
            Case "grdDis"
                If Me.TabPageMain.SelectedIndex <> 2 Then
                    Me.TabPageMain.SelectedIndex = 2
                End If
                If rs_PODISPRM_D.Tables("RESULT").Rows.Count = 0 Then

                    Dim newRow As DataRow = rs_PODISPRM_D.Tables("RESULT").NewRow()
                    newRow.Item("pdp_seqno") = rs_PODISPRM_D.Tables("RESULT").Rows.Count + 1
                    newRow.Item("pdp_dsc") = ""
                    newRow.Item("pdp_pctamt") = "P"
                    newRow.Item("pdp_purpct") = 0
                    newRow.Item("pdp_paamt") = 0
                    newRow.Item("pdp_creusr") = "~*ADD*~"
                    rs_PODISPRM_D.Tables("RESULT").Rows.Add(newRow)
                End If
                If rs_PODISPRM_D.Tables("RESULT").Rows.Count > 0 Then
                    'rs_PODISPRM_D.MoveFirst()
                    Dim dr_PODISPRM_D() As DataRow = rs_PODISPRM_D.Tables("RESULT").Select("pdp_dsc = ''")

                    If dr_PODISPRM_D.Length = 0 Then
                        Dim newRow As DataRow = rs_PODISPRM_D.Tables("RESULT").NewRow()
                        newRow.Item("pdp_seqno") = rs_PODISPRM_D.Tables("RESULT").Rows.Count + 1
                        newRow.Item("pdp_dsc") = ""
                        newRow.Item("pdp_pctamt") = "P"
                        newRow.Item("pdp_purpct") = 0
                        newRow.Item("pdp_paamt") = 0
                        newRow.Item("pdp_creusr") = "~*ADD*~"
                        rs_PODISPRM_D.Tables("RESULT").Rows.Add(newRow)
                    End If

                End If
                'rs_PODISPRM_D.Update()
                'GrdDis.Columns(7).ReadOnly = False
                'GrdDis.Columns(8).ReadOnly = True
                'GrdDis.col = 4
                If GrdDis.Enabled And GrdDis.Visible Then GrdDis.Focus()
            Case "grdPre"
                If Me.TabPageMain.SelectedIndex <> 2 Then
                    Me.TabPageMain.SelectedIndex = 2
                End If
                If rs_PODISPRM_P.Tables("RESULT").Rows.Count = 0 Then
                    'rs_PODISPRM_P.MoveFirst()

                    Dim newRow As DataRow = rs_PODISPRM_P.Tables("RESULT").NewRow()
                    newRow.Item("pdp_seqno") = rs_PODISPRM_P.Tables("RESULT").Rows.Count + 1
                    newRow.Item("pdp_dsc") = ""
                    newRow.Item("pdp_pctamt") = "P"
                    newRow.Item("pdp_purpct") = 0
                    newRow.Item("pdp_paamt") = 0
                    newRow.Item("pdp_creusr") = "~*ADD*~"
                    rs_PODISPRM_P.Tables("RESULT").Rows.Add(newRow)
                End If
                If rs_PODISPRM_P.Tables("RESULT").Rows.Count > 0 Then
                    'rs_PODISPRM_D.MoveFirst()
                    Dim dr_PODISPRM_P() As DataRow = rs_PODISPRM_P.Tables("RESULT").Select("pdp_dsc = ''")

                    If dr_PODISPRM_P.Length = 0 Then
                        Dim newRow As DataRow = rs_PODISPRM_P.Tables("RESULT").NewRow()
                        newRow.Item("pdp_seqno") = rs_PODISPRM_P.Tables("RESULT").Rows.Count + 1
                        newRow.Item("pdp_dsc") = ""
                        newRow.Item("pdp_pctamt") = "P"
                        newRow.Item("pdp_purpct") = 0
                        newRow.Item("pdp_paamt") = 0
                        newRow.Item("pdp_creusr") = "~*ADD*~"
                        rs_PODISPRM_P.Tables("RESULT").Rows.Add(newRow)
                    End If

                End If


                'GrdPre.Columns(7).ReadOnly = False
                'GrdPre.Columns(8).ReadOnly = True
                'GrdPre.col = 4
                If GrdPre.Enabled And GrdPre.Visible Then GrdPre.Focus()


        End Select
    End Sub


    Private Sub DTDCanDat_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTDCanDat.Enter
        Call HighlightMask(DTDCanDat)
    End Sub
    Public Sub HighlightMask(ByVal t As MaskedTextBox)
        t.SelectionStart = 0
        t.SelectionLength = Len(t.Text)
    End Sub

    Private Sub DTDCanDat_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTDCanDat.Leave
        'Recordstatus = True
        If Not (DTDCanDat.Text = "  /  /    " Or DTDCanDat.Text = "  /  /") Then 'If DTDCanDat.Text <> "  /  /    " Then
            If Not IsDate(DTDCanDat.Text) Then
                MsgBox("Date is Invalid!") 'msg("M00325")
                If DTDCanDat.Enabled And DTDCanDat.Visible Then DTDCanDat.Focus()
            End If
        End If

        ' Update Data
        Call Update_PODtl()
    End Sub


    Private Sub DTDShpEnd_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTDShpEnd.Enter
        Call HighlightMask(DTDShpEnd)
    End Sub

    Private Sub DTDShpEnd_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTDShpEnd.Leave
        'Recordstatus = True


        If Not IsDate(DTDShpEnd.Text) Then
            MsgBox("Date is Invalid!") 'msg("M00325")
            If DTDShpEnd.Enabled And DTDShpEnd.Visible Then DTDShpEnd.Focus()
        End If

        ' Update Data
        Call Update_PODtl()
    End Sub


    Private Sub DTDShpStr_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTDShpStr.Enter
        Call HighlightMask(DTDShpStr)
    End Sub

    Private Sub DTDShpStr_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTDShpStr.Leave
        'Recordstatus = True

        If Not IsDate(DTDShpStr.Text) Then
            MsgBox("Date is Invalid!") 'msg("M00325")
            If DTDShpStr.Enabled And DTDShpStr.Visible Then DTDShpStr.Focus()
        End If

        ' Update Data
        Call Update_PODtl()
    End Sub


    Private Sub GrdDis_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdDis.CellClick
        Recordstatus = True
        If rs_PODISPRM_D.Tables("RESULT").Rows.Count > 0 Then
            rs_PODISPRM_D.Tables("RESULT").Columns("pdp_status").ReadOnly = False
            Select Case e.ColumnIndex

                Case 0

                    If IsDBNull(rs_PODISPRM_D.Tables("RESULT").Rows(selectedRow).Item("pdp_status")) Then
                        rs_PODISPRM_D.Tables("RESULT").Rows(selectedRow).Item("pdp_status") = ""
                    End If

                    If rs_PODISPRM_D.Tables("RESULT").Rows(selectedRow).Item("pdp_status") = "" Then
                        rs_PODISPRM_D.Tables("RESULT").Rows(selectedRow).Item("pdp_status") = "Y"
                    ElseIf rs_PODISPRM_D.Tables("RESULT").Rows(selectedRow).Item("pdp_status") = "Y" Then
                        rs_PODISPRM_D.Tables("RESULT").Rows(selectedRow).Item("pdp_status") = ""
                    End If
                    'Call Grddis_DblClick()

                    If rs_PODISPRM_D.Tables("RESULT").Rows.Count > 0 Then 'If rs_PODISPRM_D.recordCount > 0 And Not rs_PODISPRM_D.EOF Then
                        'If GrdDis.col = 0 Then
                        If rs_PODISPRM_D.Tables("RESULT").Rows(selectedRow).Item("pdp_status") = "Y" Then
                            rs_PODISPRM_D.Tables("RESULT").Rows(selectedRow).Item("pdp_creusr") = "~*DEL*~"
                        Else
                            rs_PODISPRM_D.Tables("RESULT").Rows(selectedRow).Item("pdp_status") = ""
                            If rs_PODISPRM_D.Tables("RESULT").Rows(selectedRow).Item("pdp_creusr") = "~*NEW*~" Then
                                rs_PODISPRM_D.Tables("RESULT").Rows(selectedRow).Item("pdp_creusr") = "~*ADD*~"
                            Else
                                rs_PODISPRM_D.Tables("RESULT").Rows(selectedRow).Item("pdp_creusr") = "~*UPD*~"
                            End If
                        End If

                        'End If

                    End If

                Case 4
                    'lstDis.Move (grdDis.Columns(ColIndex).Left + fmeDis.Left + grdDis.Left), (grdDis.RowTop(grdDis.row) + grdDis.Columns(ColIndex).Top + fmeDis.Top + grdDis.Top - 300)
                    LstDis.Visible = True
                    If LstDis.Enabled And LstDis.Visible Then LstDis.Focus()
                    If LstDis.Items.Count > 0 Then
                        LstDis.SelectedIndex = 0
                    End If
                Case 6
                    For i As Integer = 0 To rs_PODISPRM_D.Tables("RESULT").Columns.Count - 1
                        rs_PODISPRM_D.Tables("RESULT").Columns(i).ReadOnly = False
                    Next


                    If rs_PODISPRM_D.Tables("RESULT").Rows(selectedRow).Item("pdp_pctamt") = "P" Then
                        rs_PODISPRM_D.Tables("RESULT").Rows(selectedRow).Item("pdp_pctamt") = "A"
                        rs_PODISPRM_D.Tables("RESULT").Rows(selectedRow).Item("pdp_purpct") = 0
                        'GrdDis.Columns(7).Locked = True
                        'GrdDis.Columns(8).Locked = False

                    Else
                        rs_PODISPRM_D.Tables("RESULT").Rows(selectedRow).Item("pdp_pctamt") = "P"
                        rs_PODISPRM_D.Tables("RESULT").Rows(selectedRow).Item("pdp_paamt") = 0
                        'GrdDis.Columns(8).Locked = True
                        'GrdDis.Columns(7).Locked = False

                    End If

                    If rs_PODISPRM_D.Tables("RESULT").Rows(selectedRow).Item("pdp_creusr") <> "~*ADD*~" And _
                        rs_PODISPRM_D.Tables("RESULT").Rows(selectedRow).Item("pdp_creusr") <> "~*DEL*~" And _
                        rs_PODISPRM_D.Tables("RESULT").Rows(selectedRow).Item("pdp_creusr") <> "~*NEW*~" Then
                        rs_PODISPRM_D.Tables("RESULT").Rows(selectedRow).Item("pdp_creusr") = "~*UPD*~"
                    End If

            End Select
        End If
    End Sub

    Private Sub LstDis_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstDis.DoubleClick
        If rs_PODISPRM_D.Tables("RESULT").Rows(selectedRow).Item("pdp_creusr") <> "~*ADD*~" And _
            rs_PODISPRM_D.Tables("RESULT").Rows(selectedRow).Item("pdp_creusr") <> "~*DEL*~" And _
            rs_PODISPRM_D.Tables("RESULT").Rows(selectedRow).Item("pdp_creusr") <> "~*NEW*~" Then
            rs_PODISPRM_D.Tables("RESULT").Rows(selectedRow).Item("pdp_creusr") = "~*UPD*~"
        End If
        rs_PODISPRM_D.Tables("RESULT").Columns("pdp_dpltyp").ReadOnly = False
        rs_PODISPRM_D.Tables("RESULT").Columns("pdp_dsc").ReadOnly = False
        rs_PODISPRM_D.Tables("RESULT").Rows(selectedRow).Item("pdp_dpltyp") = Split(LstDis.Items(LstDis.SelectedIndex), " - ")(0)
        rs_PODISPRM_D.Tables("RESULT").Rows(selectedRow).Item("pdp_dsc") = Split(LstDis.Items(LstDis.SelectedIndex), " - ")(1)
        rs_PODISPRM_D.Tables("RESULT").Columns("pdp_dpltyp").ReadOnly = True
        'rs_PODISPRM_D.Tables("RESULT").Columns("pdp_dsc").ReadOnly = True
        If GrdDis.Enabled And GrdDis.Visible Then GrdDis.Focus()
    End Sub

    Private Sub LstDis_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstDis.Leave
        LstDis.Visible = False
        If GrdDis.Enabled And GrdDis.Visible Then
            GrdDis.Focus()
        End If
    End Sub

    Private Sub LstDis_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles LstDis.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.Chr(32) Then
            LstDis_DoubleClick(sender, e)
        End If

        If e.KeyChar = Microsoft.VisualBasic.Chr(27) Then
            LstDis_Leave(sender, e)
        End If
    End Sub

    Private Sub GrdPre_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdPre.CellClick
        Recordstatus = True
        If rs_PODISPRM_P.Tables("RESULT").Rows.Count > 0 Then
            Select Case e.ColumnIndex

                Case 0
                    rs_PODISPRM_P.Tables("RESULT").Columns("pdp_status").ReadOnly = False

                    If IsDBNull(rs_PODISPRM_P.Tables("RESULT").Rows(selectedRow).Item("pdp_status")) Then
                        rs_PODISPRM_P.Tables("RESULT").Rows(selectedRow).Item("pdp_status") = ""
                    End If

                    If rs_PODISPRM_P.Tables("RESULT").Rows(selectedRow).Item("pdp_status") = "" Then
                        rs_PODISPRM_P.Tables("RESULT").Rows(selectedRow).Item("pdp_status") = "Y"
                    ElseIf rs_PODISPRM_P.Tables("RESULT").Rows(selectedRow).Item("pdp_status") = "Y" Then
                        rs_PODISPRM_P.Tables("RESULT").Rows(selectedRow).Item("pdp_status") = ""
                    End If
                    'Call Grddis_DblClick()

                    If rs_PODISPRM_P.Tables("RESULT").Rows.Count > 0 Then 'If rs_PODISPRM_P.recordCount > 0 And Not rs_PODISPRM_P.EOF Then
                        'If GrdDis.col = 0 Then
                        If rs_PODISPRM_P.Tables("RESULT").Rows(selectedRow).Item("pdp_status") = "Y" Then
                            rs_PODISPRM_P.Tables("RESULT").Rows(selectedRow).Item("pdp_creusr") = "~*DEL*~"
                        Else
                            rs_PODISPRM_P.Tables("RESULT").Rows(selectedRow).Item("pdp_status") = ""
                            If rs_PODISPRM_P.Tables("RESULT").Rows(selectedRow).Item("pdp_creusr") = "~*NEW*~" Then
                                rs_PODISPRM_P.Tables("RESULT").Rows(selectedRow).Item("pdp_creusr") = "~*ADD*~"
                            Else
                                rs_PODISPRM_P.Tables("RESULT").Rows(selectedRow).Item("pdp_creusr") = "~*UPD*~"
                            End If
                        End If

                        'End If

                    End If

                Case 4
                    'lstDis.Move (grdDis.Columns(ColIndex).Left + fmeDis.Left + grdDis.Left), (grdDis.RowTop(grdDis.row) + grdDis.Columns(ColIndex).Top + fmeDis.Top + grdDis.Top - 300)
                    LstPre.Visible = True
                    If LstPre.Enabled And LstPre.Visible Then LstPre.Focus()
                    If LstPre.Items.Count > 0 Then
                        LstPre.SelectedIndex = 0
                    End If
                Case 6
                    For i As Integer = 0 To rs_PODISPRM_P.Tables("RESULT").Columns.Count - 1
                        rs_PODISPRM_P.Tables("RESULT").Columns(i).ReadOnly = False
                    Next


                    If rs_PODISPRM_P.Tables("RESULT").Rows(selectedRow).Item("pdp_pctamt") = "P" Then
                        rs_PODISPRM_P.Tables("RESULT").Rows(selectedRow).Item("pdp_pctamt") = "A"
                        rs_PODISPRM_P.Tables("RESULT").Rows(selectedRow).Item("pdp_purpct") = 0
                        'GrdDis.Columns(7).Locked = True
                        'GrdDis.Columns(8).Locked = False

                    Else
                        rs_PODISPRM_P.Tables("RESULT").Rows(selectedRow).Item("pdp_pctamt") = "P"
                        rs_PODISPRM_P.Tables("RESULT").Rows(selectedRow).Item("pdp_paamt") = 0
                        'GrdDis.Columns(8).Locked = True
                        'GrdDis.Columns(7).Locked = False

                    End If

                    If rs_PODISPRM_P.Tables("RESULT").Rows(selectedRow).Item("pdp_creusr") <> "~*ADD*~" And _
                        rs_PODISPRM_P.Tables("RESULT").Rows(selectedRow).Item("pdp_creusr") <> "~*DEL*~" And _
                        rs_PODISPRM_P.Tables("RESULT").Rows(selectedRow).Item("pdp_creusr") <> "~*NEW*~" Then
                        rs_PODISPRM_P.Tables("RESULT").Rows(selectedRow).Item("pdp_creusr") = "~*UPD*~"
                    End If
            End Select
        End If
    End Sub

    Private Sub LstPre_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstPre.DoubleClick
        If rs_PODISPRM_P.Tables("RESULT").Rows(selectedRow).Item("pdp_creusr") <> "~*ADD*~" And _
            rs_PODISPRM_P.Tables("RESULT").Rows(selectedRow).Item("pdp_creusr") <> "~*DEL*~" And _
            rs_PODISPRM_P.Tables("RESULT").Rows(selectedRow).Item("pdp_creusr") <> "~*NEW*~" Then
            rs_PODISPRM_P.Tables("RESULT").Rows(selectedRow).Item("pdp_creusr") = "~*UPD*~"
        End If
        rs_PODISPRM_P.Tables("RESULT").Columns("pdp_dpltyp").ReadOnly = False
        rs_PODISPRM_P.Tables("RESULT").Columns("pdp_dsc").ReadOnly = False
        rs_PODISPRM_P.Tables("RESULT").Rows(selectedRow).Item("pdp_dpltyp") = Split(LstPre.Items(LstPre.SelectedIndex), " - ")(0)
        rs_PODISPRM_P.Tables("RESULT").Rows(selectedRow).Item("pdp_dsc") = Split(LstPre.Items(LstPre.SelectedIndex), " - ")(1)
        rs_PODISPRM_P.Tables("RESULT").Columns("pdp_dpltyp").ReadOnly = True
        'rs_PODISPRM_P.Tables("RESULT").Columns("pdp_dsc").ReadOnly = True
        If GrdDis.Enabled And GrdDis.Visible Then GrdDis.Focus()
    End Sub

    Private Sub LstPre_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstPre.Leave
        LstPre.Visible = False
        If GrdPre.Enabled And GrdPre.Visible Then
            GrdPre.Focus()
        End If
    End Sub

    Private Sub LstPre_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles LstPre.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(32) Then
            LstPre_DoubleClick(sender, e)
        End If

        If e.KeyChar = Microsoft.VisualBasic.Chr(27) Then
            LstPre_Leave(sender, e)
        End If
    End Sub

    Private Sub optMain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optMain.Click
        Update_ShpMrk()
        prevShpMrkTyp = "M"
    End Sub

    Private Sub optSide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optSide.Click
        Update_ShpMrk()
        prevShpMrkTyp = "S"
    End Sub

    Private Sub optInner_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optInner.Click
        Update_ShpMrk()
        prevShpMrkTyp = "I"
    End Sub


    Private Sub txtChnRmk_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtChnRmk.TextChanged
        Recordstatus = True
        If Len(txtChnRmk.Text) Mod 40 = 0 And Len(txtChnRmk.Text) > 39 Then
            txtChnRmk.Text = txtChnRmk.Text & vbCrLf
            txtChnRmk.SelectionStart = Len(txtChnRmk.Text)
            txtChnRmk.SelectionLength = Len(txtChnRmk.Text)
        End If
    End Sub

    Private Sub txtChnRmk_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtChnRmk.Enter
        Call HighlightText(txtChnRmk)
        txtChnRmk.BringToFront()
        txtChnRmk.Height = txtChnRmk.Height + 20
    End Sub

    Public Sub HighlightText(ByVal t As TextBox)
        t.SelectionStart = 0
        t.SelectionLength = Len(t.Text)
    End Sub

    Private Sub txtColDsc_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtColDsc.Enter
        txtColDsc.Height = txtColDsc.Height + 20
    End Sub

    Private Sub txtColDsc_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtColDsc.Leave
        txtColDsc.Height = txtColDsc.Height - 20
    End Sub

    Private Sub txtDiscnt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiscnt.TextChanged
        If Trim(txtDiscnt.Text) = "" Then
            txtDiscnt.Text = "0"
        End If
    End Sub

    Private Sub txtEngDsc_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtEngDsc.Height = txtEngDsc.Height + 50
    End Sub

    Private Sub txtEngDsc_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtEngDsc.Height = txtEngDsc.Height - 50
    End Sub

    Private Sub txtEngRmk_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEngRmk.TextChanged
        Recordstatus = True
        If Len(txtEngRmk.Text) Mod 40 = 0 And Len(txtEngRmk.Text) > 39 Then
            txtEngRmk.Text = txtEngRmk.Text & vbCrLf
            txtEngRmk.SelectionStart = Len(txtEngRmk.Text)
            txtEngRmk.SelectionLength = Len(txtEngRmk.Text)
        End If
    End Sub

    Private Sub txtLblDue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLblDue.TextChanged
        Recordstatus = True
    End Sub

    Private Sub txtLblDue_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLblDue.Enter
        Call HighlightMask(txtLblDue)
    End Sub

    Private Sub txtPckItr_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPckItr.Enter
        txtPckItr.Height = txtPckItr.Height + 20
    End Sub

    Private Sub txtPckItr_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPckItr.Leave
        txtPckItr.Height = txtPckItr.Height - 20
    End Sub

    Private Sub txtPoCDat_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPoCDatFrm.Enter
        Call HighlightMask(txtPoCDatFrm)
    End Sub

    Private Sub txtLblDue_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLblDue.Leave
        'Recordstatus = True
        If txtPoCDatFrm.Text <> "  /  /    " Then
            If Not IsDate(txtPoCDatFrm.Text) Then
                MsgBox("Date is Invalid!") 'msg("M00325")
                If txtPoCDatFrm.Enabled And txtPoCDatFrm.Visible Then txtPoCDatFrm.Focus()
            End If
        End If
    End Sub

    Private Sub txtPONo_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPONo.Enter
        Call HighlightText(txtPONo)
    End Sub

    Private Sub txtPONo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPONo.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(13) Then
            cmdFind_Click(sender, e)
        End If

    End Sub

    Private Sub txtRemAddr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRemAddr.TextChanged
        Recordstatus = True
    End Sub

    Private Sub txtRemAddr_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRemAddr.Enter
        txtRemAddr.Height = txtRemAddr.Height + 50
    End Sub

    Private Sub txtRemAddr_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRemAddr.Leave
        txtRemAddr.Height = txtRemAddr.Height - 50
    End Sub

    Private Sub txtRemChnAddr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRemChnAddr.TextChanged
        Recordstatus = True
    End Sub

    Private Sub txtRemChnAddr_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRemChnAddr.Enter
        txtRemChnAddr.Height = txtRemChnAddr.Height + 50
    End Sub

    Private Sub txtRemChnAddr_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRemChnAddr.Leave
        txtRemChnAddr.Height = txtRemChnAddr.Height - 50
    End Sub



    Private Sub txtRmk_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRmk.TextChanged

        Recordstatus = True
    End Sub


    Private Sub txtRmk_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRmk.Enter
        HighlightText(txtRmk)
        txtRmk.Height = txtRmk.Height + 50
        txtRmk.Top = txtRmk.Top - 50
    End Sub



    Private Sub txtRmk_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRmk.Leave
        txtRmk.Height = txtRmk.Height - 50
        txtRmk.Top = txtRmk.Top + 50

    End Sub

    Private Sub txtDRmk_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDRmk.Enter
        Call HighlightText(txtDRmk)
        txtDRmk.Height = txtDRmk.Height + 50
        txtDRmk.Top = txtDRmk.Top - 50
        'txtDRmk.Top = 3435
    End Sub

    Private Sub txtDRmk_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDRmk.Leave
        txtDRmk.Height = txtDRmk.Height - 50
        txtDRmk.Top = txtDRmk.Top + 50
    End Sub

    Private Sub txtSChnDsc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSChnDsc.TextChanged
        Recordstatus = True
        If Len(txtSChnDsc.Text) Mod 40 = 0 And Len(txtSChnDsc.Text) > 39 Then
            txtSChnDsc.Text = txtSChnDsc.Text & vbCrLf
            txtSChnDsc.SelectionStart = Len(txtSChnDsc.Text)
            txtSChnDsc.SelectionLength = Len(txtSChnDsc.Text)
        End If
    End Sub

    Private Sub txtSChnDsc_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSChnDsc.Enter
        Call HighlightText(txtSChnDsc)
        txtSChnDsc.Height = txtSChnDsc.Height + 50
        txtSChnDsc.BringToFront()
    End Sub

    Private Sub txtSChnDsc_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSChnDsc.Leave
        'If MultiLineTextIsValid(txtSChnDsc(1).Text, 40) = False Then
        '    If SSTab1.Tab <> 4 Then
        '        SSTab1.Tab = 4
        '    End If
        '    msg("M00349")
        '    If txtSChnDsc(1).Enabled And txtSChnDsc(1).Visible Then txtSChnDsc(1).SetFocus()
        'End If
        txtSChnDsc.Height = txtSChnDsc.Height - 50
    End Sub

    Private Sub txtSEngDsc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSEngDsc.TextChanged
        Recordstatus = True
        If Len(txtSEngDsc.Text) Mod 40 = 0 And Len(txtSEngDsc.Text) > 39 Then
            txtSEngDsc.Text = txtSEngDsc.Text & vbCrLf
            txtSEngDsc.SelectionStart = Len(txtSEngDsc.Text)
            txtSEngDsc.SelectionLength = Len(txtSEngDsc.Text)
        End If
    End Sub

    Private Sub txtSEngDsc_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSEngDsc.Enter
        Call HighlightText(txtSEngDsc)
        txtSEngDsc.Height = txtSEngDsc.Height + 50
        txtSEngDsc.BringToFront()

    End Sub

    Private Sub txtSEngDsc_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSEngDsc.Leave
        'If MultiLineTextIsValid(txtSEngDsc(0).Text, 40) = False Then
        '    If SSTab1.Tab <> 4 Then
        '        SSTab1.Tab = 4
        '    End If
        '    msg("M00349")
        '    If txtSEngDsc(0).Enabled And txtSEngDsc(0).Visible Then txtSEngDsc(0).SetFocus()
        'End If
        txtSEngDsc.Height = txtSEngDsc.Height - 50

    End Sub

    Private Sub txtShpEnd_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShpEnd.Enter
        Call HighlightMask(txtShpEnd)
    End Sub

    Private Sub txtShpEnd_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShpEnd.Leave
        'Recordstatus = True
        If Not IsDate(txtShpEnd.Text) Then 'If Not CheckDate(txtShpEnd.Text) Then
            MsgBox("Date is Invalid!") 'msg("M00325")
            If txtShpEnd.Enabled And txtShpEnd.Visible Then txtShpEnd.Focus()

        End If
    End Sub

    Private Sub txtShpStr_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShpStr.Enter
        Call HighlightMask(txtShpStr)
    End Sub

    Private Sub txtShpStr_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShpStr.Leave
        'Recordstatus = True

        If Not IsDate(txtShpStr.Text) Then
            MsgBox("Date is Invalid!") 'msg("M00325")
            If txtShpStr.Enabled And txtShpStr.Visible Then txtShpStr.Focus()

        End If
    End Sub


    Private Sub txtPoCDat_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPoCDatFrm.Leave
        'Recordstatus = True
        If Not (txtPoCDatFrm.Text = "  /  /    " Or txtPoCDatFrm.Text = "  /  /") Then
            If Not IsDate(txtPoCDatFrm.Text) Then
                MsgBox("Date is Invalid!") 'msg("M00325")
                If txtPoCDatFrm.Enabled And txtPoCDatFrm.Visible Then txtPoCDatFrm.Focus()
            End If
        End If
    End Sub


    Private Sub txtShpEnd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShpEnd.TextChanged
        Recordstatus = True
    End Sub

    Private Sub txtPoCDat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPoCDatFrm.TextChanged
        Recordstatus = True
    End Sub

    Private Sub txtShpStr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShpStr.TextChanged
        Recordstatus = True
    End Sub

    Private Sub DTDShpStr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTDShpStr.TextChanged
        Recordstatus = True
    End Sub

    Private Sub DTDShpEnd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTDShpEnd.TextChanged
        Recordstatus = True
    End Sub

    Private Sub DTDCanDat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTDCanDat.TextChanged
        Recordstatus = True
    End Sub


    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        Dim frmSYM00018 As New SYM00018

        frmSYM00018.keyName = txtPONo.Name
        frmSYM00018.strModule = "PO"

        frmSYM00018.show_frmSYM00018(Me)
    End Sub

    Private Sub POM00001_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If (e.Alt) Then
            If e.KeyCode = Keys.D1 Then
                Me.TabPageMain.SelectedIndex = 0
            ElseIf e.KeyCode = Keys.D2 Then
                Me.TabPageMain.SelectedIndex = 1
            ElseIf e.KeyCode = Keys.D3 Then
                Me.TabPageMain.SelectedIndex = 2
            ElseIf e.KeyCode = Keys.D4 Then
                Me.TabPageMain.SelectedIndex = 3
            ElseIf e.KeyCode = Keys.D5 Then
                Me.TabPageMain.SelectedIndex = 4
            ElseIf e.KeyCode = Keys.D6 Then
                Me.TabPageMain.SelectedIndex = 5
            End If
        End If
    End Sub

    Private Sub grdSummary_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdSummary.CellEnter
        If e.RowIndex >= 0 Then
            Dim dr() As DataRow = rs_POORDDTL.Tables("RESULT").Select("", "pod_purseq")
            For index As Integer = 0 To dr.Length - 1
                If rs_POORDDTL.Tables("RESULT").DefaultView(e.RowIndex)("pod_purseq") = dr(index)("pod_purseq") Then
                    current_row = index
                End If
            Next
        End If
    End Sub

    Private Sub txtEngRmk_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEngRmk.Enter
        txtEngRmk.Height = txtEngRmk.Height + 50
        txtEngRmk.BringToFront()
    End Sub

    Private Sub txtEngRmk_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEngRmk.Leave
        txtEngRmk.Height = txtEngRmk.Height - 50
    End Sub

    Private Sub txtChnRmk_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtChnRmk.Leave
        txtChnRmk.Height = txtChnRmk.Height - 20
    End Sub

    Private Sub cmdShpmrkAttchmnt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShpmrkAttchmnt.Click
        If ShipmrkAttchmnt Is Nothing Then
            ShipmrkAttchmnt = New SCM00001_ShpmrkAtchmt
        End If

        ShipmrkAttchmnt.setCompanyCode(cboCoCde.Text, txtCoNam.Text)
        ShipmrkAttchmnt.setSCNo(rs_POORDDTL.Tables("RESULT").Rows(0)("pod_scno"))

        ShipmrkAttchmnt.ShowDialog()
    End Sub

    Private Sub fillcboCusCur()
        cboCusUSDCur.Items.Clear()
        cboCusCADCur.Items.Clear()

        cboCusUSDCur.Text = ""
        cboCusCADCur.Text = ""

        cboCusUSDCur.Items.Add("AUD")
        cboCusUSDCur.Items.Add("CAD")
        cboCusUSDCur.Items.Add("CNY")
        cboCusUSDCur.Items.Add("EUR")
        cboCusUSDCur.Items.Add("GBP")
        cboCusUSDCur.Items.Add("JPY")
        cboCusUSDCur.Items.Add("USD")

        cboCusCADCur.Items.Add("AUD")
        cboCusCADCur.Items.Add("CAD")
        cboCusCADCur.Items.Add("CNY")
        cboCusUSDCur.Items.Add("GBP")
        cboCusCADCur.Items.Add("EUR")
        cboCusCADCur.Items.Add("JPY")
        cboCusCADCur.Items.Add("USD")
    End Sub

    Private Sub txtDest_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDest.Validated
        Recordstatus = True
    End Sub

    Private Sub chkVndAck_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVndAck.Validated
        Recordstatus = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdQCRpt.Click
        If Me.txtPONo.Text.Trim = "" Then
            MsgBox("Please Input PO number!")
            Me.txtPONo.Focus()
            Exit Sub
        End If
        Dim frm_frmPOQCRpt As New frmPOQCRpt(Me.txtPONo.Text.Trim)
        frm_frmPOQCRpt.MdiParent = Me.MdiParent
        frm_frmPOQCRpt.Show()
    End Sub
End Class