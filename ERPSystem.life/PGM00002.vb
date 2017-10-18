Imports System.Collections.Generic
Public Class PGM00002
    Const tab_hdr As Integer = 0
    Const tab_dtl As Integer = 1
    Const tab_sum As Integer = 2

    Dim Enq_right_local As Boolean
    Dim Del_right_local As Boolean
    Dim mode As String
    Dim rs_CUBASINF_P As DataSet
    Dim rs_CUBASINF_S As DataSet
    Dim rs_SYPAKCAT As DataSet
    Dim rs_PKIMBAIF As DataSet
    Dim Add_flag As Boolean = False
    Dim recordstatus As Boolean = False
    Dim rs_TOSCHEADER As DataSet
    Dim rs_TOSCDETAIL As DataSet
    Dim rs_PKREQDTL As DataSet
    Dim rs_VNBASINF As DataSet
    Dim rs_VNBASINF_02 As DataSet
    Dim rs_syswasge As DataSet
    Dim pkgtype As String

    Dim rs_PKREQHDR As DataSet

    Public FrmPGM00010 As PGM00010

    Dim dgPkgITem_cocde As Integer
    Dim dgPkgITem_ordno As Integer
    Dim dgPkgITem_seq As Integer
    Dim dgPkgITem_realitem As Integer
    Dim dgPkgITem_tempitem As Integer
    Dim dgPkgITem_venno As Integer
    Dim dgPkgITem_venitem As Integer
    Dim dgPkgITem_stqty As Integer
    Dim dgPkgItem_colcde As Integer
    Dim dgPkgITem_um As Integer
    Dim dgPkgITem_inr As Integer
    Dim dgPkgITem_mst As Integer
    Dim dgPkgItem_cft As Integer
    Dim dgPkgITem_ftyprctrm As Integer
    Dim dgPkgITem_hkprctrm As Integer
    Dim dgPkgITem_trantrm As Integer
    Dim dgPkgITem_Terms As Integer
    Dim dgPkgITem_curcde As Integer
    Dim dgPkgITem_Scno As Integer
    Dim dgPkgITem_ScSeq As Integer
    Dim dgPkgITem_ScItem As Integer
    Dim dgPkgItem_ScQty As Integer
    Dim dgPkgITem_cusitem As Integer
    Dim dgPkgITem_sku As Integer
    Dim dgPkgItem_assitem As Integer
    Dim dgSum_bonqty As Integer



    Dim dgSum_ordqty As Integer
    Dim dgSum_pkgven As Integer
    Dim dgSum_creusr As Integer
    Dim dgSum_UnitPrc As Integer
    Dim dgSum_ttlqty As Integer
    Dim dgSum_ttlAmt As Integer
    Dim dgSum_seq As Integer

    Dim dgPkgItem_ConFtr As Integer

    Dim dgPkgItem_BigMst As Integer

    Dim rs_VNCTNPER_09 As DataSet


    Dim flag_panpack_keypress As Boolean

    Dim MouseClickCbo As Boolean = False

    Public FrmPGM00003 As PGM00003
    Public FrmPGR00001 As PGR00001

    Dim rs_PKESHDR As DataSet
    Dim rs_PKESDTL As DataSet



    Dim mmdPrint_Right As Boolean = False
    Dim mmdFunction_Right As Boolean = False


    Private Sub PGM00002_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call AccessRight("PGR00001")
        mmdPrint_Right = Enq_right

        Call AccessRight("PGM00003")
        mmdFunction_Right = Enq_right

        Call Formstartup(Me.Name)
        Call AccessRight(Me.Name)
        Enq_right_local = Enq_right
        Del_right_local = Del_right

        Call FillCompCombo(gsUsrID, cbococde)

        Format_cboStatus()


        gspStr = "sp_list_VNCTNPER_PG09 ''"
        rtnLong = execute_SQLStatement(gspStr, rs_VNCTNPER_09, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading PGM00002_Load sp_list_VNCTNPER_PG09 :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_list_pkwasge_02 ''"
        rtnLong = execute_SQLStatement(gspStr, rs_syswasge, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Me.Cursor = Cursors.Default
            MsgBox("Error on loading PGM00002_Load sp_list_pkwasge :" & rtnStr)
            Exit Sub
        End If




        mode = "INIT"
        formInit(mode)

        cbococde.SelectedIndex = 0
        recordstatus = False

  



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

    Private Sub Format_cboStatus()







        cboScStatus.Items.Clear()
        cboToStatus.Items.Clear()
        cboStatus.Items.Clear()

        cboScStatus.Items.Add("")
        cboScStatus.Items.Add("ACT - Active")
        cboScStatus.Items.Add("HLD - Waiting for Approval")
        cboScStatus.Items.Add("REL - Released")
        cboScStatus.Items.Add("CAN - Cancel")
        cboScStatus.Items.Add("CLO - Close")
        cboScStatus.Items.Add("OPE - Open")
        cboScStatus.Items.Add("REL - Released")

        cboToStatus.Items.Add("")
        cboToStatus.Items.Add("ACT - Active")
        cboToStatus.Items.Add("HLD - Waiting for Approval")
        cboToStatus.Items.Add("REL - Released")
        cboToStatus.Items.Add("CAN - Cancel")
        cboToStatus.Items.Add("CLO - Close")
        cboToStatus.Items.Add("OPE - Open")
        cboToStatus.Items.Add("REL - Released")

        cboStatus.Items.Add("")
        cboStatus.Items.Add("ACT - Active")
        cboStatus.Items.Add("HLD - Waiting for Approval")
        cboStatus.Items.Add("REL - Released")
        cboStatus.Items.Add("CAN - Cancel")
        cboStatus.Items.Add("CLO - Close")
        cboStatus.Items.Add("OPE - Open")
        cboStatus.Items.Add("REL - Released")




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
    Private Sub resetcmdButton(ByVal Mode As String)
        If Mode = "INIT" Then
            mmdAdd.Enabled = Enq_right_local
            mmdSave.Enabled = False
            mmdDelete.Enabled = False

            mmdCopy.Enabled = False

            mmdFind.Enabled = True
            mmdInsRow.Enabled = False
            mmdDelRow.Enabled = False
            mmdExit.Enabled = True
            mmdClear.Enabled = True
            mmdSearch.Enabled = False

            'Add_flag = False



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



            'txtVenNam.Enabled = False
            'txtVenChnNam.Enabled = False
            'chkfty.Enabled = False
            'txtVenSna.Enabled = False
            'chkDiCoTi.Enabled = False
            'chkActivate.Enabled = False
            'ChkMOQChg.Enabled = False




        End If

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
    Private Sub resetdisplay(ByVal mode As String)
        If mode = "INIT" Then



            Me.StatusBar.Items("lblLeft").Text = ""
            Me.StatusBar.Items("lblRight").Text = ""
            ' cbococde.Text = ""
            Panel1.Visible = False
            txtReqno.Text = ""
            txtVerno.Text = ""
            txtIssDate.Text = ""
            txtRevDate.Text = ""
            cboStatus.Text = ""
            cboPriCust.Text = ""
            cboSecCust.Text = ""
            txtHeadScNo.Text = ""
            txtHeadToNo.Text = ""
            txtToNo.Text = ""
            txtToVer.Text = ""
            cboToStatus.Text = ""
            txtToIssDate.Text = ""
            txtToRevDate.Text = ""
            txtRefQuot.Text = ""
            rdoPack.Checked = False
            rdoMock.Checked = False

            txtSalesDiv.Text = ""
            cboSalesRep.Text = ""
            txtScNo.Text = ""
            txtScVer.Text = ""
            cboScStatus.Text = ""
            txtScIssDat.Text = ""
            txtScRevDate.Text = ""
            txtCustPoDate.Text = ""
            txtScCancelDate.Text = ""
            txtScShipDateEnd.Text = ""
            txtScShipDateStr.Text = ""
            txtScRemark.Text = ""
            txtSeq.Text = ""
            txtItemNo.Text = ""
            txtTerms.Text = ""
            txtPkgItem.Text = ""
            cboPkgVendor.Text = ""
            txtCate.Text = ""
            cboRemi.Text = ""
            txtPkgChDesc.Text = ""
            txtPkgAddress.Text = ""
            txtPkgEnDesc.Text = ""
            txtPkgRemark.Text = ""
            txtPkgState.Text = ""
            txtPkgCtry.Text = ""
            txtZip.Text = ""
            txtTel.Text = ""
            txtPkgCtnPer.Text = ""
            txtPkgSTQty.Text = ""
            cboSTOUM.Text = ""
            txtPkgMult.Text = ""
            txtPkgOrdQty.Text = ""
            cboOrdUm.Text = ""
            txtPkgWastPer.Text = ""
            txtPkgWast.Text = ""
            txtBonQty.Text = ""
            cboWasUm.Text = ""
            cboWastUm.Text = ""
            txtPkgTtlQty.Text = ""
            cboTtlUm.Text = ""
            txtPkgUnitPriCur.Text = ""
            txtPkgUnitPri.Text = ""
            txtTtlAmtCur.Text = ""
            txtTtlAmt.Text = ""
            txtPkgRcive.Text = ""
            cboReceUm.Text = ""

            txtTerms.Text = ""

            txtEISizeH.Text = ""
            txtEISizeL.Text = ""
            txtEISizeW.Text = ""

            txtECSizeH.Text = ""
            txtECSizeL.Text = ""
            txtEISizeW.Text = ""

            txtFCSizeH.Text = ""
            txtFCSizeL.Text = ""
            txtFCSizeW.Text = ""
            txtFISizeH.Text = ""
            txtFISizeL.Text = ""
            txtFISizeW.Text = ""

            txtMatri.Text = ""
            txtTcknes.Text = ""
            txtPrtMtd.Text = ""
            txtForntCol.Text = ""
            txtBackCol.Text = ""
            txtFinish.Text = ""

            txtMatDsc.Text = ""
            txtTckDsc.Text = ""
            txtPrtDsc.Text = ""

            txtConftr.Text = ""
            txtPOno.Text = ""
            txtQuoteCur.Text = ""
            txtQuotePrice.Text = ""
            cboPkgCtnPer.Text = ""

            txtColor.Text = ""
            txtSKU.Text = ""
            txtCustomer.Text = ""


            ChkDel.Checked = False


            cbococde.Enabled = True
            txtReqno.Enabled = True

            mmdRel.Enabled = False


            cmdRelease.Enabled = False

            cmdUnRelease.Enabled = False
            cmdReChose.Enabled = False

            mmdSearch.Enabled = True

            mmdPrint.Enabled = False
            mmdAttach.Enabled = False
            mmdFunction.Enabled = False
            mmdLink.Enabled = False



            freeze_TabControl(0)
            BaseTabControl1.SelectedIndex = 0

            mmdCancel.Enabled = False
            cmdCancelReq.Enabled = False

            'lstCty.DataSource = Nothing
            'lstCty.Visible = False

        ElseIf mode = "ReadOnly" Then
            Panel1.Visible = False
            cmdReChose.Enabled = False
            cbococde.Enabled = False
            txtReqno.Enabled = False
            txtVerno.Enabled = False
            txtIssDate.Enabled = False
            txtRevDate.Enabled = False
            cboStatus.Enabled = False
            mmdRel.Enabled = True
            cmdRelease.Enabled = True
            cmdUnRelease.Enabled = True
            cboPriCust.Enabled = False
            cboSecCust.Enabled = False
            txtHeadScNo.Enabled = False
            txtHeadToNo.Enabled = False
            txtToNo.Enabled = False
            txtToVer.Enabled = False
            cboToStatus.Enabled = False
            txtToIssDate.Enabled = False
            txtToRevDate.Enabled = False
            txtRefQuot.Enabled = False
            rdoMock.Enabled = False
            rdoPack.Enabled = False
            txtSalesDiv.Enabled = False
            cboSalesRep.Enabled = False
            txtScNo.Enabled = False
            txtScVer.Enabled = False
            cboScStatus.Enabled = False
            txtScIssDat.Enabled = False
            txtScRevDate.Enabled = False
            txtCustPoDate.Enabled = False
            txtScCancelDate.Enabled = False
            txtScShipDateEnd.Enabled = False
            txtScShipDateStr.Enabled = False
            txtScRemark.Enabled = False
            txtSeq.Enabled = False
            txtItemNo.Enabled = False
            txtTerms.Enabled = False
            txtPkgItem.Enabled = False
            txtCate.Enabled = False
            txtPkgChDesc.Enabled = False
            txtPkgEnDesc.Enabled = False
            txtPkgRemark.Enabled = False
            cboPkgVendor.Enabled = False
            cboRemi.Enabled = False
            txtPkgAddress.Enabled = False
            txtPkgState.Enabled = False
            txtPkgCtry.Enabled = False
            txtZip.Enabled = False
            txtTel.Enabled = False
            txtPkgCtnPer.Enabled = False
            txtEISizeH.Enabled = False
            txtEISizeL.Enabled = False
            txtEISizeW.Enabled = False
            txtECSizeH.Enabled = False
            txtECSizeL.Enabled = False
            txtECSizeW.Enabled = False
            txtFCSizeH.Enabled = False
            txtFCSizeL.Enabled = False
            txtFCSizeW.Enabled = False
            txtFISizeH.Enabled = False
            txtFISizeL.Enabled = False
            txtFISizeW.Enabled = False
            txtMatri.Enabled = False
            txtTcknes.Enabled = False
            txtPrtMtd.Enabled = False
            txtForntCol.Enabled = False
            txtBackCol.Enabled = False
            txtFinish.Enabled = False
            txtPkgSTQty.Enabled = False
            cboSTOUM.Enabled = False
            txtPkgMult.Enabled = False
            txtPkgOrdQty.Enabled = False
            txtPkgWastPer.Enabled = False
            txtPkgWast.Enabled = False
            txtBonQty.Enabled = False
            cboWasUm.Enabled = False
            txtPkgTtlQty.Enabled = False
            txtPkgUnitPri.Enabled = False
            txtTtlAmt.Enabled = False
            txtPkgRcive.Enabled = False
            cboOrdUm.Enabled = False
            cboWastUm.Enabled = False
            cboTtlUm.Enabled = False
            txtPkgUnitPriCur.Enabled = False
            txtTtlAmtCur.Enabled = False
            cboReceUm.Enabled = False
            ChkDel.Enabled = False
            txtConftr.Enabled = False

            txtQuoteCur.Enabled = False
            txtQuotePrice.Enabled = False

            txtMatDsc.Enabled = False
            txtTckDsc.Enabled = False
            txtPrtDsc.Enabled = False



            cmdBack.Enabled = True
            cmdNext.Enabled = True

            mmdPrint.Enabled = mmdPrint_Right
            mmdFunction.Enabled = mmdFunction_Right

            mmdAdd.Enabled = False
            mmdSave.Enabled = False
            mmdDelete.Enabled = False
            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdClear.Enabled = True
            mmdInsRow.Enabled = False
            mmdExit.Enabled = True
            mmdSearch.Enabled = False

            cmdIMG.Enabled = True
            cboPkgCtnPer.Enabled = False
            cmdCancelReq.Enabled = False
            mmdCancel.Enabled = False

      

            txtColor.Enabled = False
            txtSKU.Enabled = False
            txtCustomer.Enabled = False



            txtColor.Text = ""
            txtSKU.Text = ""
            txtCustomer.Text = ""


            '  txtReqno.Text = ""
            txtVerno.Text = ""
            txtIssDate.Text = ""
            txtRevDate.Text = ""
            cboStatus.Text = ""
            cboPriCust.Text = ""
            cboSecCust.Text = ""
            txtHeadScNo.Text = ""
            txtHeadToNo.Text = ""
            txtToNo.Text = ""
            txtToVer.Text = ""
            cboToStatus.Text = ""
            txtToIssDate.Text = ""
            txtToRevDate.Text = ""
            txtRefQuot.Text = ""
            rdoPack.Checked = False
            rdoMock.Checked = False
            txtSalesDiv.Text = ""
            cboSalesRep.Text = ""
            txtScNo.Text = ""
            txtScVer.Text = ""
            cboScStatus.Text = ""
            txtScIssDat.Text = ""
            txtScRevDate.Text = ""
            txtCustPoDate.Text = ""
            txtScCancelDate.Text = ""
            txtScShipDateEnd.Text = ""
            txtScShipDateStr.Text = ""
            txtScRemark.Text = ""
            txtSeq.Text = ""
            txtItemNo.Text = ""
            txtTerms.Text = ""
            txtPkgItem.Text = ""
            cboPkgVendor.Text = ""
            txtCate.Text = ""
            cboRemi.Text = ""
            txtPkgChDesc.Text = ""
            txtPkgAddress.Text = ""
            txtPkgEnDesc.Text = ""
            txtPkgRemark.Text = ""
            txtPkgState.Text = ""
            txtPkgCtry.Text = ""
            txtZip.Text = ""
            txtTel.Text = ""
            txtPkgCtnPer.Text = ""
            txtPkgSTQty.Text = ""
            cboSTOUM.Text = ""
            txtPkgMult.Text = ""
            txtPkgOrdQty.Text = ""
            cboOrdUm.Text = ""
            txtPkgWastPer.Text = ""
            txtPkgWast.Text = ""
            txtBonQty.Text = ""
            cboWasUm.Text = ""
            cboWastUm.Text = ""
            txtPkgTtlQty.Text = ""
            cboTtlUm.Text = ""
            txtPkgUnitPriCur.Text = ""
            txtPkgUnitPri.Text = ""
            txtTtlAmtCur.Text = ""
            txtTtlAmt.Text = ""
            txtPkgRcive.Text = ""
            cboReceUm.Text = ""

            txtTerms.Text = ""

            txtEISizeH.Text = ""
            txtEISizeL.Text = ""
            txtEISizeW.Text = ""

            txtECSizeH.Text = ""
            txtECSizeL.Text = ""
            txtEISizeW.Text = ""

            txtFCSizeH.Text = ""
            txtFCSizeL.Text = ""
            txtFCSizeW.Text = ""
            txtFISizeH.Text = ""
            txtFISizeL.Text = ""
            txtFISizeW.Text = ""

            txtMatri.Text = ""
            txtTcknes.Text = ""
            txtPrtMtd.Text = ""
            txtForntCol.Text = ""
            txtBackCol.Text = ""
            txtFinish.Text = ""

            txtMatDsc.Text = ""
            txtTckDsc.Text = ""
            txtPrtDsc.Text = ""
            ChkDel.Checked = False
            txtConftr.Text = ""
            txtPOno.Text = ""
            txtQuoteCur.Text = ""
            txtQuotePrice.Text = ""
            cboPkgCtnPer.Text = ""



            Call SetStatusBar(mode)



        ElseIf mode = "UPDATE" Then
            Panel1.Visible = False
            cmdReChose.Enabled = False
            cbococde.Enabled = False
            txtReqno.Enabled = False
            txtVerno.Enabled = False
            txtIssDate.Enabled = False
            txtRevDate.Enabled = False
            cboStatus.Enabled = False
            mmdRel.Enabled = True
            cmdRelease.Enabled = True
            cmdUnRelease.Enabled = True
            cboPriCust.Enabled = False
            cboSecCust.Enabled = False
            txtHeadScNo.Enabled = False
            txtHeadToNo.Enabled = False
            txtToNo.Enabled = False
            txtToVer.Enabled = False
            cboToStatus.Enabled = False
            txtToIssDate.Enabled = False
            txtToRevDate.Enabled = False
            txtRefQuot.Enabled = False
            rdoMock.Enabled = False
            rdoPack.Enabled = False
            txtSalesDiv.Enabled = False
            cboSalesRep.Enabled = False
            txtScNo.Enabled = False
            txtScVer.Enabled = False
            cboScStatus.Enabled = False
            txtScIssDat.Enabled = False
            txtScRevDate.Enabled = False
            txtCustPoDate.Enabled = False
            txtScCancelDate.Enabled = False
            txtScShipDateEnd.Enabled = False
            txtScShipDateStr.Enabled = False
            txtScRemark.Enabled = False
            txtSeq.Enabled = False
            txtItemNo.Enabled = False
            txtTerms.Enabled = False
            txtPkgItem.Enabled = False
            txtCate.Enabled = False
            txtPkgChDesc.Enabled = False
            txtPkgEnDesc.Enabled = False
            txtPkgRemark.Enabled = False
            cboPkgVendor.Enabled = True
            cboRemi.Enabled = False
            txtPkgAddress.Enabled = False
            txtPkgState.Enabled = False
            txtPkgCtry.Enabled = False
            txtZip.Enabled = False
            txtTel.Enabled = False
            txtPkgCtnPer.Enabled = False
            txtEISizeH.Enabled = False
            txtEISizeL.Enabled = False
            txtEISizeW.Enabled = False
            txtECSizeH.Enabled = False
            txtECSizeL.Enabled = False
            txtECSizeW.Enabled = False
            txtFCSizeH.Enabled = False
            txtFCSizeL.Enabled = False
            txtFCSizeW.Enabled = False
            txtFISizeH.Enabled = False
            txtFISizeL.Enabled = False
            txtFISizeW.Enabled = False
            txtMatri.Enabled = False
            txtTcknes.Enabled = False
            txtPrtMtd.Enabled = False
            txtForntCol.Enabled = False
            txtBackCol.Enabled = False
            txtFinish.Enabled = False
            txtPkgSTQty.Enabled = False
            cboSTOUM.Enabled = False
            txtPkgMult.Enabled = True
            txtPkgOrdQty.Enabled = True
            txtPkgWastPer.Enabled = False
            txtBonQty.Enabled = True
            cboWasUm.Enabled = False
            txtPkgWast.Enabled = False
            txtPkgTtlQty.Enabled = False
            txtPkgUnitPri.Enabled = True
            txtTtlAmt.Enabled = False
            txtPkgRcive.Enabled = False  '*
            cboOrdUm.Enabled = False
            cboWastUm.Enabled = False
            cboTtlUm.Enabled = False
            txtPkgUnitPriCur.Enabled = False
            txtTtlAmtCur.Enabled = False
            cboReceUm.Enabled = False
            ChkDel.Enabled = True
            txtMatDsc.Enabled = False
            txtTckDsc.Enabled = False
            txtPrtDsc.Enabled = False

            cmdBack.Enabled = True
            cmdNext.Enabled = True

            mmdPrint.Enabled = mmdPrint_Right
            mmdFunction.Enabled = mmdFunction_Right


            mmdAdd.Enabled = False
            mmdSave.Enabled = Enq_right_local
            mmdDelete.Enabled = False
            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdClear.Enabled = True
            mmdInsRow.Enabled = True
            mmdExit.Enabled = True

            mmdSearch.Enabled = False
            txtConftr.Enabled = False

            txtQuoteCur.Enabled = False
            txtQuotePrice.Enabled = True
            cmdIMG.Enabled = True
            cboPkgCtnPer.Enabled = True
            cmdCancelReq.Enabled = True
            mmdCancel.Enabled = True

            txtColor.Enabled = False
            txtSKU.Enabled = False
            txtCustomer.Enabled = False



            txtColor.Text = ""
            txtSKU.Text = ""
            txtCustomer.Text = ""


            'txtReqno.Text = ""
            txtVerno.Text = ""
            txtIssDate.Text = ""
            txtRevDate.Text = ""
            cboStatus.Text = ""
            cboPriCust.Text = ""
            cboSecCust.Text = ""
            txtHeadScNo.Text = ""
            txtHeadToNo.Text = ""
            txtToNo.Text = ""
            txtToVer.Text = ""
            cboToStatus.Text = ""
            txtToIssDate.Text = ""
            txtToRevDate.Text = ""
            txtRefQuot.Text = ""
            rdoPack.Checked = False
            rdoMock.Checked = False
            txtSalesDiv.Text = ""
            cboSalesRep.Text = ""
            txtScNo.Text = ""
            txtScVer.Text = ""
            cboScStatus.Text = ""
            txtScIssDat.Text = ""
            txtScRevDate.Text = ""
            txtCustPoDate.Text = ""
            txtScCancelDate.Text = ""
            txtScShipDateEnd.Text = ""
            txtScShipDateStr.Text = ""
            txtScRemark.Text = ""
            txtSeq.Text = ""
            txtItemNo.Text = ""
            txtTerms.Text = ""
            txtPkgItem.Text = ""
            cboPkgVendor.Text = ""
            txtCate.Text = ""
            cboRemi.Text = ""
            txtPkgChDesc.Text = ""
            txtPkgAddress.Text = ""
            txtPkgEnDesc.Text = ""
            txtPkgRemark.Text = ""
            txtPkgState.Text = ""
            txtPkgCtry.Text = ""
            txtZip.Text = ""
            txtTel.Text = ""
            txtPkgCtnPer.Text = ""
            txtPkgSTQty.Text = ""
            cboSTOUM.Text = ""
            txtPkgMult.Text = ""
            txtPkgOrdQty.Text = ""
            cboOrdUm.Text = ""
            txtPkgWastPer.Text = ""
            txtPkgWast.Text = ""
            txtBonQty.Text = ""
            cboWasUm.Text = ""
            cboWastUm.Text = ""
            txtPkgTtlQty.Text = ""
            cboTtlUm.Text = ""
            txtPkgUnitPriCur.Text = ""
            txtPkgUnitPri.Text = ""
            txtTtlAmtCur.Text = ""
            txtTtlAmt.Text = ""
            txtPkgRcive.Text = ""
            cboReceUm.Text = ""

            txtTerms.Text = ""

            txtEISizeH.Text = ""
            txtEISizeL.Text = ""
            txtEISizeW.Text = ""

            txtECSizeH.Text = ""
            txtECSizeL.Text = ""
            txtEISizeW.Text = ""

            txtFCSizeH.Text = ""
            txtFCSizeL.Text = ""
            txtFCSizeW.Text = ""
            txtFISizeH.Text = ""
            txtFISizeL.Text = ""
            txtFISizeW.Text = ""

            txtMatri.Text = ""
            txtTcknes.Text = ""
            txtPrtMtd.Text = ""
            txtForntCol.Text = ""
            txtBackCol.Text = ""
            txtFinish.Text = ""
            txtMatDsc.Text = ""
            txtTckDsc.Text = ""
            txtPrtDsc.Text = ""
            ChkDel.Checked = False

            txtConftr.Text = ""
            txtPOno.Text = ""
            txtQuoteCur.Text = ""
            txtQuotePrice.Text = ""
            cboPkgCtnPer.Text = ""
            Call SetStatusBar(mode)





        ElseIf mode = "ADD" Then
            Panel1.Visible = False
            cmdReChose.Enabled = False
            cbococde.Enabled = False
            txtReqno.Enabled = False
            txtVerno.Enabled = False
            txtIssDate.Enabled = False
            txtRevDate.Enabled = False
            cboStatus.Enabled = False
            mmdRel.Enabled = False
            cmdRelease.Enabled = False
            cmdUnRelease.Enabled = False
            cboPriCust.Enabled = False
            cboSecCust.Enabled = False
            txtHeadScNo.Enabled = False
            txtHeadToNo.Enabled = False
            txtToNo.Enabled = True
            txtToVer.Enabled = False
            cboToStatus.Enabled = False
            txtToIssDate.Enabled = False
            txtToRevDate.Enabled = False
            txtRefQuot.Enabled = False
            rdoMock.Enabled = False
            rdoPack.Enabled = False
            txtSalesDiv.Enabled = False
            cboSalesRep.Enabled = False
            txtScNo.Enabled = True
            txtScVer.Enabled = False
            cboScStatus.Enabled = False
            txtScIssDat.Enabled = False
            txtScRevDate.Enabled = False
            txtCustPoDate.Enabled = False
            txtScCancelDate.Enabled = False
            txtScShipDateEnd.Enabled = False
            txtScShipDateStr.Enabled = False
            txtScRemark.Enabled = False
            txtSeq.Enabled = False
            txtItemNo.Enabled = False
            txtTerms.Enabled = False
            txtPkgItem.Enabled = False
            txtCate.Enabled = False
            txtPkgChDesc.Enabled = False
            txtPkgEnDesc.Enabled = False
            txtPkgRemark.Enabled = False
            cboPkgVendor.Enabled = False
            cboRemi.Enabled = False
            txtPkgAddress.Enabled = False
            txtPkgState.Enabled = False
            txtPkgCtry.Enabled = False
            txtZip.Enabled = False
            txtTel.Enabled = False
            txtPkgCtnPer.Enabled = False
            txtEISizeH.Enabled = False
            txtEISizeL.Enabled = False
            txtEISizeW.Enabled = False
            txtECSizeH.Enabled = False
            txtECSizeL.Enabled = False
            txtECSizeW.Enabled = False
            txtFCSizeH.Enabled = False
            txtFCSizeL.Enabled = False
            txtFCSizeW.Enabled = False
            txtFISizeH.Enabled = False
            txtFISizeL.Enabled = False
            txtFISizeW.Enabled = False
            txtMatri.Enabled = False
            txtTcknes.Enabled = False
            txtPrtMtd.Enabled = False
            txtForntCol.Enabled = False
            txtBackCol.Enabled = False
            txtFinish.Enabled = False
            txtPkgSTQty.Enabled = False
            cboSTOUM.Enabled = False
            txtPkgMult.Enabled = False
            txtPkgOrdQty.Enabled = False
            txtPkgWastPer.Enabled = False
            txtBonQty.Enabled = False
            cboWasUm.Enabled = False
            txtPkgWast.Enabled = False
            txtPkgTtlQty.Enabled = False
            txtPkgUnitPri.Enabled = False
            txtTtlAmt.Enabled = False
            txtPkgRcive.Enabled = False
            cboOrdUm.Enabled = False
            cboWastUm.Enabled = False
            cboTtlUm.Enabled = False
            txtPkgUnitPriCur.Enabled = False
            txtTtlAmtCur.Enabled = False
            cboReceUm.Enabled = False
            ChkDel.Enabled = True
            txtMatDsc.Enabled = False
            txtTckDsc.Enabled = False
            txtPrtDsc.Enabled = False

            cmdBack.Enabled = True
            cmdNext.Enabled = True

            mmdPrint.Enabled = False
            mmdFunction.Enabled = False



            mmdAdd.Enabled = False
            mmdSave.Enabled = Enq_right_local
            mmdDelete.Enabled = False
            mmdCopy.Enabled = False
            mmdFind.Enabled = False
            mmdClear.Enabled = True
            mmdInsRow.Enabled = True
            mmdExit.Enabled = True
            mmdSearch.Enabled = False
            txtConftr.Enabled = False


            txtQuoteCur.Enabled = False
            txtQuotePrice.Enabled = False
            cmdIMG.Enabled = True
            cboPkgCtnPer.Enabled = False
            cmdCancelReq.Enabled = False
            mmdCancel.Enabled = False


            txtColor.Enabled = False
            txtSKU.Enabled = False
            txtCustomer.Enabled = False



            txtColor.Text = ""
            txtSKU.Text = ""
            txtCustomer.Text = ""



            txtReqno.Text = ""
            txtVerno.Text = ""
            txtIssDate.Text = ""
            txtRevDate.Text = ""
            cboStatus.Text = ""
            cboPriCust.Text = ""
            cboSecCust.Text = ""
            txtHeadScNo.Text = ""
            txtHeadToNo.Text = ""
            txtToNo.Text = ""
            txtToVer.Text = ""
            cboToStatus.Text = ""
            txtToIssDate.Text = ""
            txtToRevDate.Text = ""
            txtRefQuot.Text = ""
            rdoPack.Checked = False
            rdoMock.Checked = False
            txtSalesDiv.Text = ""
            cboSalesRep.Text = ""
            txtScNo.Text = ""
            txtScVer.Text = ""
            cboScStatus.Text = ""
            txtScIssDat.Text = ""
            txtScRevDate.Text = ""
            txtCustPoDate.Text = ""
            txtScCancelDate.Text = ""
            txtScShipDateEnd.Text = ""
            txtScShipDateStr.Text = ""
            txtScRemark.Text = ""
            txtSeq.Text = ""
            txtItemNo.Text = ""
            txtTerms.Text = ""
            txtPkgItem.Text = ""
            cboPkgVendor.Text = ""
            txtCate.Text = ""
            cboRemi.Text = ""
            txtPkgChDesc.Text = ""
            txtPkgAddress.Text = ""
            txtPkgEnDesc.Text = ""
            txtPkgRemark.Text = ""
            txtPkgState.Text = ""
            txtPkgCtry.Text = ""
            txtZip.Text = ""
            txtTel.Text = ""
            txtPkgCtnPer.Text = ""
            txtPkgSTQty.Text = ""
            cboSTOUM.Text = ""
            txtPkgMult.Text = ""
            txtPkgOrdQty.Text = ""
            cboOrdUm.Text = ""
            txtPkgWastPer.Text = ""
            txtPkgWast.Text = ""
            txtBonQty.Text = ""
            cboWasUm.Text = ""
            cboWastUm.Text = ""
            txtPkgTtlQty.Text = ""
            cboTtlUm.Text = ""
            txtPkgUnitPriCur.Text = ""
            txtPkgUnitPri.Text = ""
            txtTtlAmtCur.Text = ""
            txtTtlAmt.Text = ""
            txtPkgRcive.Text = ""
            cboReceUm.Text = ""

            txtTerms.Text = ""

            txtEISizeH.Text = ""
            txtEISizeL.Text = ""
            txtEISizeW.Text = ""

            txtECSizeH.Text = ""
            txtECSizeL.Text = ""
            txtEISizeW.Text = ""

            txtFCSizeH.Text = ""
            txtFCSizeL.Text = ""
            txtFCSizeW.Text = ""
            txtFISizeH.Text = ""
            txtFISizeL.Text = ""
            txtFISizeW.Text = ""

            txtMatri.Text = ""
            txtTcknes.Text = ""
            txtPrtMtd.Text = ""
            txtForntCol.Text = ""
            txtBackCol.Text = ""
            txtFinish.Text = ""
            ChkDel.Checked = False

            txtMatDsc.Text = ""
            txtTckDsc.Text = ""
            txtPrtDsc.Text = ""
            txtConftr.Text = ""
            txtPOno.Text = ""

            txtQuoteCur.Text = ""
            txtQuotePrice.Text = ""
            cboPkgCtnPer.Text = ""
            Call SetStatusBar(mode)

            Me.BaseTabControl1.TabPages(0).Enabled = True
            Me.BaseTabControl1.TabPages(1).Enabled = False  'False



        End If



    End Sub

    Private Sub cbococde_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbococde.SelectedIndexChanged
        gsCompany = Trim(cbococde.Text)
        Update_gs_Value(gsCompany)
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

    Private Sub mmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdAdd.Click
        mode = "ADD"
        Add_flag = True
        recordstatus = True
        resetdisplay(mode)
        txtToNo.Select()


    End Sub


    Private Sub txtToNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtToNo.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then


            Cursor = Cursors.WaitCursor

            If CheckExistPKG("TO", txtToNo.Text) = False Then
                Cursor = Cursors.Default
                Exit Sub
            End If

            pkgtype = "TO"


            gspStr = "sp_select_TOORDHDR_PKG02 '" & cbococde.Text & "','" & txtToNo.Text & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_TOSCHEADER, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Cursor = Cursors.Default
                MsgBox("Error on loading txtToNo_KeyPress sp_select_TOORDHDR_PKG02 :" & rtnStr)
                Exit Sub
            End If

            If rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("toh_ordsts") = "CLO" Then
                Cursor = Cursors.Default
                MsgBox("TO status is close , action cancel.")
                Exit Sub
            End If


            gspStr = "sp_select_TOORDDTL_PKG02 '" & cbococde.Text & "','" & txtToNo.Text & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_TOSCDETAIL, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Cursor = Cursors.Default
                MsgBox("Error on loading txtToNo_KeyPress sp_select_TOORDDTL_PKG02 :" & rtnStr)
                Exit Sub
            End If

            gspStr = "sp_select_PKREQDTL '','@!#@!#!@#'"
            rtnLong = execute_SQLStatement(gspStr, rs_PKREQDTL, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Cursor = Cursors.Default
                MsgBox("Error on loading txtToNo_KeyPress sp_select_PKREQDTL :" & rtnStr)
                Exit Sub
            End If


            gspStr = "sp_select_PKESHDR '" & cbococde.Text & "','" & "@!#@!#!@#" & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_PKESHDR, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Cursor = Cursors.Default
                MsgBox("Error on loading cmdFind_Click sp_select_PKESHDR :" & rtnStr)
                Exit Sub
            End If

            gspStr = "sp_select_PKESDTL '" & cbococde.Text & "','" & "@!#@!#!@#" & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_PKESDTL, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Cursor = Cursors.Default
                MsgBox("Error on loading cmdFind_Click sp_select_PKESDTL :" & rtnStr)
                Exit Sub
            End If





            gspStr = "sp_list_VNBASINF_PD ''"
            rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Cursor = Cursors.Default
                MsgBox("Error on loading txtToNo_KeyPress sp_list_VNBASINF :" & rtnStr)
                Exit Sub
            End If


            gspStr = "sp_list_VNBASINF_PKG02 ''"
            rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF_02, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Cursor = Cursors.Default
                MsgBox("Error on loading txtToNo_KeyPress sp_list_VNBASINF :" & rtnStr)
                Exit Sub
            End If
            't




            For i As Integer = 0 To rs_PKREQDTL.Tables("RESULT").Columns.Count - 1
                rs_PKREQDTL.Tables("RESULT").Columns(i).ReadOnly = False
            Next



            If rs_TOSCHEADER.Tables("RESULT").Rows.Count <> 0 And rs_TOSCDETAIL.Tables("RESULT").Rows.Count <> 0 Then

                cboPriCust.Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("toh_cus1no") + " - " + rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("cus1name")
                'cboSecCust.Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("toh_cus2no")

                If rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("toh_cus2no") <> "" Then
                    cboSecCust.Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("toh_cus2no") + " - " + rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("cus2name")
                Else
                    cboSecCust.Text = ""
                End If


                txtSalesDiv.Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("toh_saltem")
                cboSalesRep.Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("toh_salrep")
                txtToNo.Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("toh_toordno")
                txtToVer.Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("toh_verno")

                ' cboToStatus.Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("toh_ordsts")


                display_combo(rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("toh_ordsts"), cboToStatus)

                txtToIssDate.Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("toh_issdat")


                txtToRevDate.Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("toh_rvsdat")
                txtRefQuot.Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("toh_refqut")

                SetdgSCTO_TO()


                txtScNo.Text = ""
                txtScVer.Text = ""
                cboScStatus.Text = ""
                txtScIssDat.Text = ""
                txtScRevDate.Text = ""
                txtCustPoDate.Text = ""
                txtScCancelDate.Text = ""
                txtScShipDateEnd.Text = ""
                txtScShipDateStr.Text = ""
                txtScRemark.Text = ""

                txtHeadToNo.Text = txtToNo.Text

                txtScNo.Enabled = False
                txtToNo.Enabled = False

                Me.BaseTabControl1.TabPages(0).Enabled = True
                Me.BaseTabControl1.TabPages(1).Enabled = True
                Me.BaseTabControl1.TabPages(2).Enabled = True
                Me.BaseTabControl1.TabPages(3).Enabled = True

                SetdgPkgITem()
                format_VendorCombo()
                SetdgPKESHDR()
                SetdgPKESDTL("ped_itemno = '!@#$'")

                Cursor = Cursors.Default

            End If

            Cursor = Cursors.Default

        End If
    End Sub


    Private Sub format_VendorCombo()
        Dim i As Integer
        Dim strList As String

        cboPkgVendor.Items.Clear()
        cboPkgVendor.Items.Add("")

        If rs_VNBASINF.Tables("RESULT").Rows.Count > 0 Then
            For i = 0 To rs_VNBASINF.Tables("RESULT").Rows.Count - 1
                strList = rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_vensna")
                If strList <> "" Then
                    cboPkgVendor.Items.Add(strList)

                End If
            Next i
        End If
    End Sub


    Private Sub SetdgPkgITem()
        If rs_TOSCDETAIL.Tables("RESULT").Rows.Count = 0 Then
            Exit Sub
        End If


        dgPKGITEM.DataSource = rs_TOSCDETAIL.Tables("RESULT").DefaultView


        dgPKGITEM.RowHeadersWidth = 18
        dgPKGITEM.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgPKGITEM.ColumnHeadersHeight = 18
        dgPKGITEM.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgPKGITEM.AllowUserToResizeColumns = True
        dgPKGITEM.AllowUserToResizeRows = False
        dgPKGITEM.RowTemplate.Height = 18


        Dim i As Integer

        'If mode = "UPDATE" Or mode = "ADD" Then
        For i = 0 To rs_TOSCDETAIL.Tables("RESULT").Columns.Count - 1
            rs_TOSCDETAIL.Tables("RESULT").Columns(i).ReadOnly = False
        Next i
        'End If
        i = 0
        dgPkgITem_cocde = i

        dgPKGITEM.Columns(i).Visible = False
        i = i + 1
        dgPkgITem_ordno = i
        dgPKGITEM.Columns(i).Visible = False
        i = i + 1
        dgPkgITem_seq = i
        dgPKGITEM.Columns(i).Visible = True
        dgPKGITEM.Columns(i).HeaderText = "Seq"
        dgPKGITEM.Columns(i).Width = 40
        dgPKGITEM.Columns(i).ReadOnly = True
        i = i + 1
        dgPkgITem_realitem = i
        dgPKGITEM.Columns(i).Visible = True
        dgPKGITEM.Columns(i).HeaderText = "Item No"
        dgPKGITEM.Columns(i).Width = 120
        dgPKGITEM.Columns(i).ReadOnly = True

        i = i + 1
        dgPkgItem_assitem = i
        dgPKGITEM.Columns(i).Visible = True
        dgPKGITEM.Columns(i).HeaderText = "Ass. Itm"
        dgPKGITEM.Columns(i).Width = 120
        dgPKGITEM.Columns(i).ReadOnly = True

        i = i + 1
        dgPkgITem_cusitem = i
        dgPKGITEM.Columns(i).Visible = True
        dgPKGITEM.Columns(i).HeaderText = "Cust.Itm#"
        dgPKGITEM.Columns(i).Width = 80
        dgPKGITEM.Columns(i).ReadOnly = True


        i = i + 1
        dgPkgITem_sku = i
        dgPKGITEM.Columns(i).Visible = True
        dgPKGITEM.Columns(i).HeaderText = "SKU#"
        dgPKGITEM.Columns(i).Width = 80
        dgPKGITEM.Columns(i).ReadOnly = True

        i = i + 1
        dgPkgITem_tempitem = i
        dgPKGITEM.Columns(i).Visible = True
        dgPKGITEM.Columns(i).HeaderText = "Tmp.Itm No"
        dgPKGITEM.Columns(i).Width = 120
        dgPKGITEM.Columns(i).ReadOnly = True
        i = i + 1
        dgPkgITem_venitem = i
        dgPKGITEM.Columns(i).Visible = True
        dgPKGITEM.Columns(i).HeaderText = "Ven.Itm No"
        dgPKGITEM.Columns(i).Width = 120
        dgPKGITEM.Columns(i).ReadOnly = True
        i = i + 1
        dgPkgITem_venno = i
        dgPKGITEM.Columns(i).Visible = True
        dgPKGITEM.Columns(i).HeaderText = "PV"
        dgPKGITEM.Columns(i).Width = 60
        dgPKGITEM.Columns(i).ReadOnly = True
        i = i + 1
        dgPkgItem_colcde = i
        dgPKGITEM.Columns(i).Visible = True
        dgPKGITEM.Columns(i).HeaderText = "Color Code"
        dgPKGITEM.Columns(i).Width = 60
        dgPKGITEM.Columns(i).ReadOnly = True
        i = i + 1
        dgPkgITem_stqty = i
        dgPKGITEM.Columns(i).Visible = True
        dgPKGITEM.Columns(i).HeaderText = "Ord Qty"
        dgPKGITEM.Columns(i).Width = 60
        dgPKGITEM.Columns(i).ReadOnly = True
        i = i + 1
        dgPkgITem_um = i
        dgPKGITEM.Columns(i).Visible = False
        i = i + 1
        dgPkgITem_inr = i
        dgPKGITEM.Columns(i).Visible = False
        i = i + 1
        dgPkgITem_mst = i
        dgPKGITEM.Columns(i).Visible = False
        i = i + 1
        dgPkgItem_cft = i
        dgPKGITEM.Columns(i).Visible = False
        i = i + 1
        dgPkgITem_ftyprctrm = i
        dgPKGITEM.Columns(i).Visible = False
        i = i + 1
        dgPkgITem_hkprctrm = i
        dgPKGITEM.Columns(i).Visible = False
        i = i + 1
        dgPkgITem_trantrm = i
        dgPKGITEM.Columns(i).Visible = False
        i = i + 1
        dgPkgITem_Terms = i
        dgPKGITEM.Columns(i).Visible = True
        dgPKGITEM.Columns(i).HeaderText = "Terms"
        dgPKGITEM.Columns(i).Width = 200
        dgPKGITEM.Columns(i).ReadOnly = True

        i = i + 1
        dgPkgITem_curcde = i
        dgPKGITEM.Columns(i).Visible = False

        i = i + 1
        dgPkgITem_Scno = i
        dgPKGITEM.Columns(i).Visible = True
        dgPKGITEM.Columns(i).HeaderText = "SC Order NO."
        dgPKGITEM.Columns(i).Width = 90
        dgPKGITEM.Columns(i).ReadOnly = True

        i = i + 1
        dgPkgITem_ScSeq = i
        dgPKGITEM.Columns(i).Visible = True
        dgPKGITEM.Columns(i).HeaderText = "SC Order Seq"
        dgPKGITEM.Columns(i).Width = 60
        dgPKGITEM.Columns(i).ReadOnly = True

        i = i + 1
        dgPkgITem_ScItem = i
        dgPKGITEM.Columns(i).Visible = True
        dgPKGITEM.Columns(i).HeaderText = "SC Item"
        dgPKGITEM.Columns(i).Width = 120
        dgPKGITEM.Columns(i).ReadOnly = True


        i = i + 1
        dgPkgItem_ScQty = i
        dgPKGITEM.Columns(i).Visible = True
        dgPKGITEM.Columns(i).HeaderText = "SC Order Qty"
        dgPKGITEM.Columns(i).Width = 60
        dgPKGITEM.Columns(i).ReadOnly = True


        i = i + 1
        dgPkgItem_ConFtr = i
        dgPKGITEM.Columns(i).Visible = False
        dgPKGITEM.Columns(i).HeaderText = ""

        i = i + 1
        dgPkgItem_BigMst = i
        dgPKGITEM.Columns(i).Visible = False
        dgPKGITEM.Columns(i).HeaderText = ""


        'Dim ii As Integer

        'For ii = 0 To dgPKGITEM.Columns.Count - 1

        '    dgPKGITEM.Columns(ii).SortMode = DataGridViewColumnSortMode.NotSortable

        'Next ii


    End Sub



    Private Sub SetdgSCTO_TO()
        If rs_TOSCHEADER.Tables.Count = 0 Then
            Exit Sub
        End If


        dgSCTO.DataSource = rs_TOSCHEADER.Tables("RESULT").DefaultView


        dgSCTO.RowHeadersWidth = 18
        dgSCTO.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgSCTO.ColumnHeadersHeight = 18
        dgSCTO.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgSCTO.AllowUserToResizeColumns = True
        dgSCTO.AllowUserToResizeRows = False
        dgSCTO.RowTemplate.Height = 18


        Dim i As Integer

        'If mode = "UPDATE" Or mode = "ADD" Then
        For i = 0 To rs_TOSCHEADER.Tables("RESULT").Columns.Count - 1
            rs_TOSCHEADER.Tables("RESULT").Columns(i).ReadOnly = False
        Next i
        'End If
        i = 0
        dgSCTO.Columns(i).Visible = False
        i = i + 1
        dgSCTO.Columns(i).Visible = False
        i = i + 1
        dgSCTO.Columns(i).Visible = False
        i = i + 1
        dgSCTO.Columns(i).Visible = False
        i = i + 1
        dgSCTO.Columns(i).Visible = False
        i = i + 1
        dgSCTO.Columns(i).Visible = False
        i = i + 1
        dgSCTO.Columns(i).Visible = False
        i = i + 1
        dgSCTO.Columns(i).Visible = False
        i = i + 1
        dgSCTO.Columns(i).Visible = False
        i = i + 1
        dgSCTO.Columns(i).Visible = False
        i = i + 1
        dgSCTO.Columns(i).Visible = False
        i = i + 1
        dgSCTO.Columns(i).Visible = False
        i = i + 1
        dgSCTO.Columns(i).HeaderText = "SC Order No"
        dgSCTO.Columns(i).Width = 80
        i = i + 1
        dgSCTO.Columns(i).HeaderText = "SC Seq"
        dgSCTO.Columns(i).Width = 60
        i = i + 1
        dgSCTO.Columns(i).HeaderText = "To Seq"
        dgSCTO.Columns(i).Width = 60
        dgSCTO.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        i = i + 1
        dgSCTO.Columns(i).HeaderText = "Item No"
        dgSCTO.Columns(i).Width = 110

        i = i + 1

        dgSCTO.Columns(i).HeaderText = "Color"
        dgSCTO.Columns(i).Width = 50

        i = i + 1

        dgSCTO.Columns(i).HeaderText = "Tmp.Item No"
        dgSCTO.Columns(i).Width = 100


        i = i + 1

        dgSCTO.Columns(i).HeaderText = "Ven.Item No"
        dgSCTO.Columns(i).Width = 100





        i = i + 1

        dgSCTO.Columns(i).HeaderText = "PV"
        dgSCTO.Columns(i).Width = 50


        i = i + 1
        dgSCTO.Columns(i).HeaderText = "Ship Str"
        dgSCTO.Columns(i).Width = 70

        i = i + 1
        dgSCTO.Columns(i).HeaderText = "Ship End"
        dgSCTO.Columns(i).Width = 70


        i = i + 1

        dgSCTO.Columns(i).HeaderText = "Packaging"
        dgSCTO.Columns(i).Width = 110

        i = i + 1

        dgSCTO.Columns(i).HeaderText = "Order Qty"
        dgSCTO.Columns(i).Width = 65
        dgSCTO.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight






        'Dim ii As Integer

        'For ii = 0 To dgSCTO.Columns.Count - 1

        '    dgSCTO.Columns(ii).SortMode = DataGridViewColumnSortMode.NotSortable

        'Next ii


    End Sub


    Private Sub SetdgSCTO_SC()
        If rs_TOSCHEADER.Tables.Count = 0 Then
            Exit Sub
        End If


        dgSCTO.DataSource = rs_TOSCHEADER.Tables("RESULT").DefaultView


        dgSCTO.RowHeadersWidth = 18
        dgSCTO.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgSCTO.ColumnHeadersHeight = 18
        dgSCTO.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgSCTO.AllowUserToResizeColumns = True
        dgSCTO.AllowUserToResizeRows = False
        dgSCTO.RowTemplate.Height = 18


        Dim i As Integer

        'If mode = "UPDATE" Or mode = "ADD" Then
        For i = 0 To rs_TOSCHEADER.Tables("RESULT").Columns.Count - 1
            rs_TOSCHEADER.Tables("RESULT").Columns(i).ReadOnly = False
        Next i
        'End If
        i = 0
        dgSCTO.Columns(i).Visible = False
        i = i + 1
        dgSCTO.Columns(i).Visible = False
        i = i + 1
        dgSCTO.Columns(i).Visible = False
        i = i + 1
        dgSCTO.Columns(i).Visible = False
        i = i + 1
        dgSCTO.Columns(i).Visible = False
        i = i + 1
        dgSCTO.Columns(i).Visible = False
        i = i + 1
        dgSCTO.Columns(i).Visible = False
        i = i + 1
        dgSCTO.Columns(i).Visible = False
        i = i + 1
        dgSCTO.Columns(i).Visible = False
        i = i + 1
        dgSCTO.Columns(i).Visible = False
        i = i + 1
        dgSCTO.Columns(i).Visible = False
        i = i + 1
        dgSCTO.Columns(i).Visible = False
        i = i + 1
        dgSCTO.Columns(i).Visible = False
        i = i + 1
        dgSCTO.Columns(i).Visible = False
        i = i + 1
        dgSCTO.Columns(i).Visible = False
        i = i + 1
        dgSCTO.Columns(i).Visible = False
        i = i + 1
        dgSCTO.Columns(i).Visible = False
        i = i + 1
        dgSCTO.Columns(i).HeaderText = "TO No"
        dgSCTO.Columns(i).Width = 80
        i = i + 1
        dgSCTO.Columns(i).HeaderText = "SC Seq"
        dgSCTO.Columns(i).Width = 60
        i = i + 1
        dgSCTO.Columns(i).HeaderText = "To Seq"
        dgSCTO.Columns(i).Width = 60

        i = i + 1
        dgSCTO.Columns(i).HeaderText = "Item No"
        dgSCTO.Columns(i).Width = 110

        i = i + 1
        dgSCTO.Columns(i).HeaderText = "Color"
        dgSCTO.Columns(i).Width = 50


        i = i + 1

        dgSCTO.Columns(i).HeaderText = "Tmp.Item No"
        dgSCTO.Columns(i).Width = 100


        i = i + 1

        dgSCTO.Columns(i).HeaderText = "Ven.Item No"
        dgSCTO.Columns(i).Width = 100



        i = i + 1

        dgSCTO.Columns(i).HeaderText = "PV"
        dgSCTO.Columns(i).Width = 50

        i = i + 1
        dgSCTO.Columns(i).HeaderText = "Ship Str"
        dgSCTO.Columns(i).Width = 70

        i = i + 1
        dgSCTO.Columns(i).HeaderText = "Ship End"
        dgSCTO.Columns(i).Width = 70


        i = i + 1

        dgSCTO.Columns(i).HeaderText = "Packaging"
        dgSCTO.Columns(i).Width = 110

        i = i + 1

        dgSCTO.Columns(i).HeaderText = "Order Qty"
        dgSCTO.Columns(i).Width = 65



        'Dim ii As Integer

        'For ii = 0 To dgSCTO.Columns.Count - 1

        '    dgSCTO.Columns(ii).SortMode = DataGridViewColumnSortMode.NotSortable

        'Next ii


    End Sub




    Private Sub txtToNo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtToNo.KeyUp

    End Sub
    Private Sub txtToNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtToNo.TextChanged

    End Sub



    Private Function CheckExistPKG(ByVal type As String, ByVal ordno As String) As Boolean

        If type = "TO" Then

            gspStr = "sp_select_EXISTPKG '" & cbococde.Text & "','" & ordno & "','" & type & "'"
            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading CheckExistPKG sp_select_EXISTPKG :" & rtnStr)
                Exit Function
            End If

            If rs.Tables("RESULT").Rows.Count <> 0 Then
                If rs.Tables("RESULT").Rows(0).Item("CountedData") = "0" Then

                    MsgBox("TO not found")
                    Return False
                    Exit Function
                ElseIf rs.Tables("RESULT").Rows(0).Item("CountedData") = "1" Then

                    If IsDBNull(rs.Tables("RESULT").Rows(0).Item("prh_ToNo")) = True Then

                        Select Case MsgBox("The TO(related SC) you input is already created Packaging Request , Would you like to display it?", MsgBoxStyle.YesNo)
                            Case MsgBoxResult.Yes

                                FindReqBySCTO(txtToNo.Text, "TO")
                                Return False
                                Exit Function
                            Case MsgBoxResult.No
                                Return False
                                Exit Function
                        End Select
                    Else
                        MsgBox("The TO(related SC) you input is already created Packaging Request.")
                        Return False
                        Exit Function

                    End If



                End If


            End If

        ElseIf type = "SC" Then

            gspStr = "sp_select_EXISTPKG '" & cbococde.Text & "','" & ordno & "','" & type & "'"
            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading CheckExistPKG sp_select_EXISTPKG :" & rtnStr)
                Exit Function
            End If

            If rs.Tables("RESULT").Rows.Count <> 0 Then
                If rs.Tables("RESULT").Rows(0).Item("CountedData") = "0" Then

                    MsgBox("Sc not found")
                    Return False
                    Exit Function
                ElseIf rs.Tables("RESULT").Rows(0).Item("CountedData") = "1" Then
                    Select Case MsgBox("The SC you input is already created Packaging Request , Would you like to display it?", MsgBoxStyle.YesNo)
                        Case MsgBoxResult.Yes
                            If rs.Tables("RESULT").Rows(0).Item("prh_ToNo").ToString = "" Then
                                FindReqBySCTO(txtScNo.Text, "SC")
                                Return False
                                Exit Function
                            ElseIf rs.Tables("RESULT").Rows(0).Item("prh_Scno").ToString = "" Then
                                FindReqBySCTO(rs.Tables("RESULT").Rows(0).Item("prh_ToNo").ToString, "TO")
                                Return False
                                Exit Function
                            End If
                        Case MsgBoxResult.No
                            Return False
                            Exit Function
                    End Select
                End If


            End If
        End If

        Return True

    End Function



    Private Sub FindReqBySCTO(ByVal SCTO As String, ByVal type As String)
        gspStr = "sp_select_PKREQHDR_SCTO '" & cbococde.Text & "','" & SCTO & "','" & type & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading FindReqBySCTO sp_select_PKREQHDR_SCTO :" & rtnStr)
            Exit Sub
        End If

        Dim reqno As String = ""
        If rs.Tables("RESULT").Rows.Count <> 0 Then
            reqno = rs.Tables("RESULT").Rows(0).Item(0)
        Else
            MsgBox("Request No. not found , Please check.")
            Exit Sub
        End If

        If reqno <> "" Then
            txtReqno.Text = reqno
            mmdFind_Click(Nothing, Nothing)
        End If


    End Sub


    Private Sub txtScNo_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtScNo.Enter

    End Sub

    Private Sub txtScNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtScNo.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then
            Cursor = Cursors.WaitCursor
            If CheckExistPKG("SC", txtScNo.Text) = False Then
                Cursor = Cursors.Default
                Exit Sub
            End If

            pkgtype = "SC"


            gspStr = "sp_select_SCORDHDR_PKG02 '" & cbococde.Text & "','" & txtScNo.Text & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_TOSCHEADER, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Cursor = Cursors.Default
                MsgBox("Error on loading txtScNo_KeyPress sp_select_SCORDHDR_PKG02 :" & rtnStr)
                Exit Sub
            End If


            If rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("soh_ordsts") = "CLO" Then
                Cursor = Cursors.Default
                MsgBox("SC status is close , action cancel.")
                Exit Sub
            End If


            gspStr = "sp_select_SCORDDTL_PKG02 '" & cbococde.Text & "','" & txtScNo.Text & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_TOSCDETAIL, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Cursor = Cursors.Default
                MsgBox("Error on loading txtScNo_KeyPress sp_select_SCORDDTL_PKG02 :" & rtnStr)
                Exit Sub
            End If

            gspStr = "sp_select_PKREQDTL '','@!#@!#!@#'"
            rtnLong = execute_SQLStatement(gspStr, rs_PKREQDTL, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Cursor = Cursors.Default
                MsgBox("Error on loading txtToNo_KeyPress sp_select_PKREQDTL :" & rtnStr)
                Exit Sub
            End If



            gspStr = "sp_select_PKESHDR '" & cbococde.Text & "','" & "@!#@!#!@#" & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_PKESHDR, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Cursor = Cursors.Default
                MsgBox("Error on loading cmdFind_Click sp_select_PKESHDR :" & rtnStr)
                Exit Sub
            End If

            gspStr = "sp_select_PKESDTL '" & cbococde.Text & "','" & "@!#@!#!@#" & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_PKESDTL, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Cursor = Cursors.Default
                MsgBox("Error on loading cmdFind_Click sp_select_PKESDTL :" & rtnStr)
                Exit Sub
            End If





            gspStr = "sp_list_VNBASINF_PD ''"
            rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Cursor = Cursors.Default
                MsgBox("Error on loading txtToNo_KeyPress sp_list_VNBASINF :" & rtnStr)
                Exit Sub
            End If


            gspStr = "sp_list_VNBASINF_PKG02 ''"
            rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF_02, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Cursor = Cursors.Default
                MsgBox("Error on loading txtToNo_KeyPress sp_list_VNBASINF :" & rtnStr)
                Exit Sub
            End If
            't




            For i As Integer = 0 To rs_PKREQDTL.Tables("RESULT").Columns.Count - 1
                rs_PKREQDTL.Tables("RESULT").Columns(i).ReadOnly = False
            Next



            If rs_TOSCHEADER.Tables("RESULT").Rows.Count <> 0 And rs_TOSCDETAIL.Tables("RESULT").Rows.Count <> 0 Then

                cboPriCust.Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("soh_cus1no") + " - " + rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("cus1name")

                If rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("soh_cus2no") <> "" Then
                    cboSecCust.Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("soh_cus2no") + " - " + rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("cus2name")
                Else
                    cboSecCust.Text = ""
                End If



                txtSalesDiv.Text = "Division " + rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("soh_saldiv") + _
                " (TEAM " + rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("soh_saltem") + ")"
                cboSalesRep.Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("soh_srname")


                txtScNo.Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("soh_ordno")
                txtScVer.Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("soh_verno")

                'cboScStatus.Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("soh_ordsts")
                display_combo(rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("soh_ordsts"), cboScStatus)


                txtScIssDat.Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("soh_issdat")

                txtScRevDate.Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("soh_rvsdat")
                txtCustPoDate.Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("soh_cpodat")
                txtScCancelDate.Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("soh_candat")
                txtScShipDateStr.Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("soh_shpstr")
                txtScShipDateEnd.Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("soh_shpend")
                txtScRemark.Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("soh_rmk")

                txtHeadScNo.Text = txtScNo.Text

                SetdgSCTO_SC()

                txtScNo.Enabled = False
                txtToNo.Enabled = False

                Me.BaseTabControl1.TabPages(0).Enabled = True
                Me.BaseTabControl1.TabPages(1).Enabled = True
                Me.BaseTabControl1.TabPages(2).Enabled = True
                Me.BaseTabControl1.TabPages(3).Enabled = True

                SetdgPkgITem()
                format_VendorCombo()
                SetdgPKESHDR()
                SetdgPKESDTL("ped_itemno = '!@#!@$'")

                Cursor = Cursors.Default
            End If

            Cursor = Cursors.Default

        End If
    End Sub



    Private Sub txtScNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScNo.TextChanged

    End Sub
    Public Sub mmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdFind.Click
        Cursor = Cursors.WaitCursor


        If (Trim(txtReqno.Text) = "" And txtReqno.Enabled = True) Then
            If txtReqno.Enabled And txtReqno.Visible Then
                txtReqno.Select()
                MsgBox("Please input Request No.")
                Cursor = Cursors.Default
                Exit Sub
            End If
        End If

        txtReqno.Text = txtReqno.Text.ToUpper


        gsCompany = Trim(cbococde.Text)
        Call Update_gs_Value(gsCompany)


        gspStr = "sp_select_PKREQHDR '" & cbococde.Text & "','" & txtReqno.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_PKREQHDR, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading cmdFind_Click sp_select_PKREQHDR :" & rtnStr)
            Exit Sub
        End If



        If rs_PKREQHDR.Tables("RESULT").Rows.Count <> 1 Then
            MsgBox("Request not found!")
            txtReqno.Select()
            Cursor = Cursors.Default
            Exit Sub
        End If


        gspStr = " sp_select_PKREQDTL '" & cbococde.Text & "','" & txtReqno.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_PKREQDTL, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading cmdFind_Click sp_select_PKREQDTL :" & rtnStr)
            Exit Sub
        End If


        'If rs_PKREQDTL.Tables("RESULT").Rows.Count = 0 Then
        '    MsgBox("Request have no detail!")
        '    txtReqno.Select()
        '    Cursor = Cursors.Default
        '    Exit Sub
        'End If


        For i As Integer = 0 To rs_PKREQDTL.Tables("RESULT").Columns.Count - 1
            rs_PKREQDTL.Tables("RESULT").Columns(i).ReadOnly = False

        Next


        gspStr = "sp_list_VNBASINF_PD ''"
        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading cmdFind_Click sp_list_VNBASINF :" & rtnStr)
            Exit Sub
        End If


        gspStr = "sp_list_VNBASINF_PKG02 ''"
        rtnLong = execute_SQLStatement(gspStr, rs_VNBASINF_02, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading cmdFind_Click sp_list_VNBASINF :" & rtnStr)
            Exit Sub
        End If



        gspStr = "sp_select_PKESHDR '" & cbococde.Text & "','" & txtReqno.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_PKESHDR, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading cmdFind_Click sp_select_PKESHDR :" & rtnStr)
            Exit Sub
        End If

        gspStr = "sp_select_PKESDTL '" & cbococde.Text & "','" & txtReqno.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_PKESDTL, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            Cursor = Cursors.Default
            MsgBox("Error on loading cmdFind_Click sp_select_PKESDTL :" & rtnStr)
            Exit Sub
        End If


        Format_cboStatus()
        format_VendorCombo()




        If Enq_right_local = True Then
            mode = "UPDATE"
        Else
            mode = "ReadOnly"
        End If

        If rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_status") = "REL" Or rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_status") = "CAN" Then
            mode = "ReadOnly"

        End If


        Dim SOTO As String

        If rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_ToNo").ToString <> "" Then
            SOTO = rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_ToNo").ToString

            gspStr = "sp_select_TOORDDTL_PKG02 '" & cbococde.Text & "','" & SOTO & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_TOSCDETAIL, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Cursor = Cursors.Default
                MsgBox("Error on loading cmdFind_Click sp_select_TOORDDTL_PKG02 :" & rtnStr)
                Exit Sub
            End If


            gspStr = "sp_select_TOORDHDR_PKG02 '" & cbococde.Text & "','" & SOTO & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_TOSCHEADER, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Cursor = Cursors.Default
                MsgBox("Error on loading cmdFind_Click sp_select_TOORDHDR_PKG02 :" & rtnStr)
                Exit Sub
            End If

            SetdgSCTO_TO()

        Else
            SOTO = rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_ScNo").ToString


            gspStr = "sp_select_SCORDDTL_PKG02 '" & cbococde.Text & "','" & SOTO & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_TOSCDETAIL, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Cursor = Cursors.Default
                MsgBox("Error on loading cmdFind_Click sp_select_SCORDDTL_PKG02 :" & rtnStr)
                Exit Sub
            End If



            gspStr = "sp_select_SCORDHDR_PKG02 '" & cbococde.Text & "','" & SOTO & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_TOSCHEADER, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                Cursor = Cursors.Default
                MsgBox("Error on loading cmdFind_Click sp_select_SCORDHDR_PKG02 :" & rtnStr)
                Exit Sub
            End If


            SetdgSCTO_SC()

        End If


        Me.BaseTabControl1.TabPages(0).Enabled = True
        Me.BaseTabControl1.TabPages(1).Enabled = True
        Me.BaseTabControl1.TabPages(2).Enabled = True
        Me.BaseTabControl1.TabPages(3).Enabled = True

        SetdgPkgITem()

        resetdisplay(mode) 'do


        display_REQUEST()

        If rs_PKREQDTL.Tables("RESULT").Rows.Count <> 0 Then
            display_PKREQDTL(0)
        Else ' Set for ready insert
            txtPkgItem.Enabled = False
            cboPkgVendor.Enabled = False
            txtPkgMult.Enabled = False
            txtPkgOrdQty.Enabled = False
            txtPkgWastPer.Enabled = False
            txtPkgWast.Enabled = False
            txtPkgUnitPri.Enabled = False
            ChkDel.Enabled = False
            cmdNext.Enabled = False
            cmdBack.Enabled = False
            txtQuotePrice.Enabled = False
        End If

        display_dgSummary()
        SetdgPKESHDR()
        SetdgPKESDTL("ped_itemno ='!@$%!@'")

        recordstatus = False
        Cursor = Cursors.Default

    End Sub

   



    Private Sub display_REQUEST()

        If rs_PKREQHDR.Tables("RESULT").Rows.Count = 0 Then
            Exit Sub
        End If

        'If rs_PKREQDTL.Tables("RESULT").Rows.Count = 0 Then
        '    Exit Sub
        'End If

        txtVerno.Text = rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_ver")
        txtIssDate.Text = rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_issdat")
        txtRevDate.Text = rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_revdat")

        display_combo(rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_status"), cboStatus)

        If cboStatus.Text.Split(" -")(0) = "CAN" Then
            mmdRel.Enabled = False
            cmdRelease.Enabled = False
        End If


        cboPriCust.Text = rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_cus1no") + " - " + rs_PKREQHDR.Tables("RESULT").Rows(0).Item("cus1name")
        'cboSecCust.Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("toh_cus2no")

        If rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_cus2no") <> "" Then
            cboSecCust.Text = rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_cus2no") + " - " + rs_PKREQHDR.Tables("RESULT").Rows(0).Item("cus2name")
        Else
            cboSecCust.Text = ""
        End If



        txtSalesDiv.Text = "Division " + rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_saldiv") + _
              " (TEAM " + rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_saltem") + ")"


        cboSalesRep.Text = rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_salrep")
        txtToNo.Text = rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_ToNo")
        txtToVer.Text = rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_ToVer")



        ' cboToStatus.Text = rs_TOSCHEADER.Tables("RESULT").Rows(0).Item("toh_ordsts")


        display_combo(rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_ToSts"), cboToStatus)


        If rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_ToIsdat").ToString <> "01/01/1900" Then
            txtToIssDate.Text = rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_ToIsdat")
        Else
            txtToIssDate.Text = ""
        End If


        If rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_ToRevdat").ToString <> "01/01/1900" Then
            txtToRevDate.Text = rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_ToRevdat")
        Else
            txtToRevDate.Text = ""

        End If

        txtRefQuot.Text = rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_ToRefqut")




        txtScNo.Text = rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_ScNo")
        txtScVer.Text = rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_ScVer")

        display_combo(rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_ScSts"), cboScStatus)






        If rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_ScIsdat").ToString <> "01/01/1900" Then
            txtScIssDat.Text = rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_ScIsdat")
        Else
            txtScIssDat.Text = ""
        End If


        If rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_ScRevdat").ToString <> "01/01/1900" Then
            txtScRevDate.Text = rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_ScRevdat")
        Else
            txtScRevDate.Text = ""
        End If


        If rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_ScPodat").ToString <> "01/01/1900" Then
            txtCustPoDate.Text = rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_ScPodat")
        Else
            txtCustPoDate.Text = ""
        End If


        If rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_ScCandat").ToString <> "01/01/1900" Then

            txtScCancelDate.Text = rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_ScCandat")
        Else
            txtScCancelDate.Text = ""
        End If


        If rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_ScShpdatend") <> "01/01/1900" Then
            txtScShipDateEnd.Text = rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_ScShpdatend")
        Else
            txtScShipDateEnd.Text = ""
        End If



        If rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_ScShpdatstr") <> "01/01/1900" Then
            txtScShipDateStr.Text = rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_ScShpdatstr")
        Else
            txtScShipDateStr.Text = ""
        End If


        txtScRemark.Text = rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_ScRemark")

        txtHeadScNo.Text = txtScNo.Text
        txtHeadToNo.Text = txtToNo.Text



        Me.StatusBar.Items("lblRight").Text = Convert.ToDateTime(rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_credat")).ToString("dd/MM/yyyy") & " " _
     & Convert.ToDateTime(rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_upddat")).ToString("dd/MM/yyyy") _
     & " " & rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_updusr")



        ' dgSCTO.DataSource = rs_TOSCHEADER.Tables("RESULT").DefaultView

    End Sub




    Private Sub BaseTabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BaseTabControl1.SelectedIndexChanged
        If BaseTabControl1.SelectedIndex = 1 Then 'tab_sum Then


            If rs_PKREQDTL.Tables("RESULT").Rows.Count <> 0 Then
                If CheckValid() = False Then

                    Exit Sub
                End If
            End If
            'update_PKREQDTL()

            display_dgSummary()

        ElseIf BaseTabControl1.SelectedIndex = 2 Then

            dgSummary.ClearSelection()
            dgSummary.CurrentCell = Nothing
        ElseIf BaseTabControl1.SelectedIndex = 3 Then

            dgSummary.ClearSelection()
            dgSummary.CurrentCell = Nothing
        ElseIf BaseTabControl1.SelectedIndex = 0 Then 'tab_dtl Then

            If rs_PKREQDTL.Tables("RESULT").Rows.Count = 0 Then
                Exit Sub
            End If

            'If txtSeq.Text = "" Then
            '    Exit Sub
            'End If


            'Dim seq As Integer

            'seq = txtSeq.Text

            If dgSummary.RowCount > 0 Then
                If dgSummary.SelectedCells.Count = 1 Or dgSummary.SelectedRows.Count = 1 Then
                    Dim dgseq As Integer
                    Dim ver As Integer

                    If dgSummary.SelectedCells.Count = 1 Then
                        dgseq = dgSummary.Item(dgSum_seq, dgSummary.SelectedCells.Item(0).RowIndex).Value

                    Else
                        dgseq = dgSummary.SelectedRows.Item(0).Cells(dgSum_seq).Value

                    End If

                    ' If Not (seq = txtSeq.Text And ver = txtVerNo.Text) Then

                    Dim loc As Integer = -1


                    For i As Integer = 0 To rs_PKREQDTL.Tables("RESULT").Rows.Count - 1
                        If dgseq = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_seq") Then
                            loc = i
                        End If

                    Next

                    If loc = -1 Then
                        MsgBox("Error Request detail not found!")
                        Exit Sub
                    End If


                    display_PKREQDTL(loc)
                    'End If
                Else
                    Dim seq As Integer
                    If txtSeq.Text <> "" Then
                        seq = txtSeq.Text
                    Else
                        seq = 0
                    End If
                    Dim loc As Integer = -1


                    For i As Integer = 0 To rs_PKREQDTL.Tables("RESULT").Rows.Count - 1
                        If seq = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_seq") Then
                            loc = i
                        End If

                    Next

                    If loc = -1 Then
                        MsgBox("Error Request detail not found!")
                        Exit Sub
                    End If


                    display_PKREQDTL(loc)


                End If
            End If






        End If
    End Sub
    Private Sub mmdInsRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdInsRow.Click
        If BaseTabControl1.SelectedIndex <> 0 Then
            Exit Sub
        End If

        If rs_PKREQDTL Is Nothing Then
            Exit Sub
        End If


        If rs_PKREQDTL.Tables("RESULT").Rows.Count <> 0 Then
            If CheckValid() = False Then
                Exit Sub
            End If
            update_PKREQDTL()
        End If


        'txtPkgItem.Enabled = False
        'cboPkgVendor.Enabled = False
        'txtPkgMult.Enabled = False
        'txtPkgOrdQty.Enabled = False
        'txtPkgWastPer.Enabled = False
        'txtPkgWast.Enabled = False
        'txtPkgUnitPri.Enabled = False
        'txtQuotePrice.Enabled = False
        'ChkDel.Checked = False
        'ChkDel.Enabled = False
        'cmdNext.Enabled = False
        'cmdBack.Enabled = False
        'cboPkgCtnPer.Enabled = False

        Panel1.Visible = True

        Panel1.BringToFront()

    End Sub




    Private Sub dgPKGITEM_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPKGITEM.CellDoubleClick





        If cmdReChose.Text = "" Then


            txtPkgItem.Enabled = False
            cboPkgVendor.Enabled = False
            txtPkgMult.Enabled = False
            txtPkgOrdQty.Enabled = False
            txtPkgWastPer.Enabled = False
            txtPkgWast.Enabled = False
            txtPkgUnitPri.Enabled = False
            txtQuotePrice.Enabled = False
            txtBonQty.Enabled = False
            ChkDel.Checked = False
            ChkDel.Enabled = False
            cmdNext.Enabled = False
            cmdBack.Enabled = False
            cboPkgCtnPer.Enabled = False


            Dim rowcount As Integer




            Dim dv As DataView
            dv = rs_PKREQDTL.Tables("RESULT").DefaultView
            dv.Sort = "prd_seq asc"

            For i As Integer = 0 To dv.Count - 1
                rowcount = dv(i)("prd_seq")

            Next





            ' rowcount = rs_PKREQDTL.Tables("RESULT").Rows.Count


            txtItemNo.Text = dgPKGITEM.Item(dgPkgITem_realitem, dgPKGITEM.CurrentCell.RowIndex).Value + " / " + _
            dgPKGITEM.Item(dgPkgItem_assitem, dgPKGITEM.CurrentCell.RowIndex).Value + " / " + _
            dgPKGITEM.Item(dgPkgITem_tempitem, dgPKGITEM.CurrentCell.RowIndex).Value + " / " + _
            dgPKGITEM.Item(dgPkgITem_venitem, dgPKGITEM.CurrentCell.RowIndex).Value + " / " + _
            dgPKGITEM.Item(dgPkgITem_venno, dgPKGITEM.CurrentCell.RowIndex).Value + " : " + _
            dgPKGITEM.Item(dgPkgItem_colcde, dgPKGITEM.CurrentCell.RowIndex).Value


            ' txtItemNo.Text = "realitem" + " / " + _
            '                    "tempitem" + " / " + _
            ' "venitem" + " / " + _
            '"venno"


            txtTerms.Text = dgPKGITEM.Item(dgPkgITem_Terms, dgPKGITEM.CurrentCell.RowIndex).Value

            txtPkgSTQty.Text = dgPKGITEM.Item(dgPkgITem_stqty, dgPKGITEM.CurrentCell.RowIndex).Value '* _
            '(dgPKGITEM.Item(dgPkgITem_mst, dgPKGITEM.CurrentCell.RowIndex).Value / dgPKGITEM.Item(dgPkgItem_BigMst, dgPKGITEM.CurrentCell.RowIndex).Value)

            txtConftr.Text = dgPKGITEM.Item(dgPkgItem_ConFtr, dgPKGITEM.CurrentCell.RowIndex).Value

            cboSTOUM.Text = dgPKGITEM.Item(dgPkgITem_um, dgPKGITEM.CurrentCell.RowIndex).Value
            cboOrdUm.Text = "PC"
            cboWastUm.Text = "PC"
            cboWasUm.Text = "PC"
            cboTtlUm.Text = "PC"
            cboReceUm.Text = "PC"
            'txtPkgUnitPriCur.Text = dgPKGITEM.Item(dgPkgITem_curcde, dgPKGITEM.CurrentCell.RowIndex).Value
            'txtTtlAmtCur.Text = dgPKGITEM.Item(dgPkgITem_curcde, dgPKGITEM.CurrentCell.RowIndex).Value

            txtPOno.Text = ""
            txtPkgItem.Text = ""
            txtCate.Text = ""
            txtPkgChDesc.Text = ""
            txtPkgEnDesc.Text = ""
            txtPkgRemark.Text = ""
            cboPkgVendor.Text = ""
            cboRemi.Text = ""
            txtPkgAddress.Text = ""
            txtPkgState.Text = ""
            txtPkgCtry.Text = ""
            txtZip.Text = ""
            txtPkgCtnPer.Text = ""
            cboPkgCtnPer.Text = ""
            txtTel.Text = ""
            txtPkgMult.Text = ""
            txtPkgOrdQty.Text = ""
            txtPkgWastPer.Text = ""
            txtPkgWast.Text = ""
            txtPkgTtlQty.Text = ""
            txtPkgUnitPri.Text = ""
            txtBonQty.Text = ""
            txtTtlAmt.Text = ""
            txtPkgRcive.Text = ""
            txtEISizeH.Text = ""
            txtEISizeL.Text = ""
            txtEISizeW.Text = ""
            txtECSizeH.Text = ""
            txtECSizeL.Text = ""
            txtECSizeW.Text = ""
            txtFISizeH.Text = ""
            txtFISizeL.Text = ""
            txtFISizeW.Text = ""
            txtFCSizeH.Text = ""
            txtFCSizeL.Text = ""
            txtFCSizeW.Text = ""
            txtMatri.Text = ""
            txtTcknes.Text = ""
            txtPrtMtd.Text = ""
            txtForntCol.Text = ""
            txtBackCol.Text = ""
            txtFinish.Text = ""
            'txtForntFin.Text = ""
            'txtBackFin.Text = ""
            txtMatDsc.Text = ""
            txtTckDsc.Text = ""
            txtPrtDsc.Text = ""
            txtQuoteCur.Text = ""
            txtQuotePrice.Text = ""
            txtColor.Text = dgPKGITEM.Item(dgPkgItem_colcde, dgPKGITEM.CurrentCell.RowIndex).Value
            txtSKU.Text = dgPKGITEM.Item(dgPkgITem_sku, dgPKGITEM.CurrentCell.RowIndex).Value
            txtCustomer.Text = dgPKGITEM.Item(dgPkgITem_cusitem, dgPKGITEM.CurrentCell.RowIndex).Value

            Dim rsrowcount As Integer
            rsrowcount = rs_PKREQDTL.Tables("RESULT").Rows.Count

            rs_PKREQDTL.Tables("RESULT").Rows.Add()

            txtSeq.Text = rowcount + 1
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_cocde") = cbococde.Text
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_reqno") = ""
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_seq") = txtSeq.Text
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_itemno") = dgPKGITEM.Item(dgPkgITem_realitem, dgPKGITEM.CurrentCell.RowIndex).Value
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_assitm") = dgPKGITEM.Item(dgPkgItem_assitem, dgPKGITEM.CurrentCell.RowIndex).Value
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_tmpitmno") = dgPKGITEM.Item(dgPkgITem_tempitem, dgPKGITEM.CurrentCell.RowIndex).Value
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_venno") = dgPKGITEM.Item(dgPkgITem_venitem, dgPKGITEM.CurrentCell.RowIndex).Value
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_venitm") = dgPKGITEM.Item(dgPkgITem_venno, dgPKGITEM.CurrentCell.RowIndex).Value
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_colcde") = dgPKGITEM.Item(dgPkgItem_colcde, dgPKGITEM.CurrentCell.RowIndex).Value
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_conftr") = dgPKGITEM.Item(dgPkgItem_ConFtr, dgPKGITEM.CurrentCell.RowIndex).Value
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_sctoqty") = dgPKGITEM.Item(dgPkgITem_stqty, dgPKGITEM.CurrentCell.RowIndex).Value
            '  * _ (dgPKGITEM.Item(dgPkgITem_mst, dgPKGITEM.CurrentCell.RowIndex).Value / dgPKGITEM.Item(dgPkgItem_BigMst, dgPKGITEM.CurrentCell.RowIndex).Value)



            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_pckunt") = dgPKGITEM.Item(dgPkgITem_um, dgPKGITEM.CurrentCell.RowIndex).Value
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_inrqty") = dgPKGITEM.Item(dgPkgITem_inr, dgPKGITEM.CurrentCell.RowIndex).Value
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_mtrqty") = dgPKGITEM.Item(dgPkgITem_mst, dgPKGITEM.CurrentCell.RowIndex).Value
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_cft") = dgPKGITEM.Item(dgPkgItem_cft, dgPKGITEM.CurrentCell.RowIndex).Value
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_ftyprctrm") = dgPKGITEM.Item(dgPkgITem_ftyprctrm, dgPKGITEM.CurrentCell.RowIndex).Value
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_hkprctrm") = dgPKGITEM.Item(dgPkgITem_hkprctrm, dgPKGITEM.CurrentCell.RowIndex).Value
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_trantrm") = dgPKGITEM.Item(dgPkgITem_trantrm, dgPKGITEM.CurrentCell.RowIndex).Value
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_pkgitm") = txtPkgItem.Text
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_pkgven") = cboPkgVendor.Text
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_cate") = txtCate.Text '*
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_chndsc") = txtPkgChDesc.Text
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_engdsc") = txtPkgEnDesc.Text
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_remark") = txtPkgRemark.Text
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_EInchL") = 0
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_EInchW") = 0
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_EInchH") = 0
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_EcmL") = 0
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_EcmW") = 0
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_EcmH") = 0
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_FInchL") = 0
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_FinchW") = 0
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_FinchH") = 0
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_FcmL") = 0
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_FcmW") = 0
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_FcmH") = 0
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_matral") = txtMatri.Text
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_tiknes") = txtTcknes.Text
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_prtmtd") = txtPrtMtd.Text
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_clrfot") = txtForntCol.Text
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_clrbck") = txtBackCol.Text
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_finish") = txtFinish.Text
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_rmtnce") = cboRemi.Text
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_addres") = txtPkgAddress.Text
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_state") = txtPkgState.Text
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_cntry") = txtPkgCtry.Text
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_zip") = txtZip.Text
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_Tel") = txtTel.Text
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_cntper") = cboPkgCtnPer.Text
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_sctoqty") = 0
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_qtyum") = cboSTOUM.Text
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_curcde") = txtPkgUnitPriCur.Text
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_multip") = 0 'care txtPkgMult.Text
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_ordqty") = 0


            If txtPkgWastPer.Text = "" Then
                rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_wasper") = 0
            Else
                rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_wasper") = txtPkgWastPer.Text
            End If

            If Trim(txtPkgWast.Text) = "" Then
                rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_wasqty") = 0
            Else
                rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_wasqty") = txtPkgWast.Text
            End If



            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_ttlordqty") = 0
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_untprc") = 0
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_ttlamtqty") = 0
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_receqty") = 0 '*
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_creusr") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_finfot") = txtForntFin.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_finbck") = txtBackFin.Text

            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_matDsc") = txtMatDsc.Text
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_tikDsc") = txtTckDsc.Text
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_prtDsc") = txtPrtDsc.Text



            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_ordno") = ""

            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_salprc") = 0

            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_ScToNo") = dgPKGITEM.Item(dgPkgITem_ordno, dgPKGITEM.CurrentCell.RowIndex).Value
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_ScToSeq") = dgPKGITEM.Item(dgPkgITem_seq, dgPKGITEM.CurrentCell.RowIndex).Value

            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_sku") = dgPKGITEM.Item(dgPkgITem_sku, dgPKGITEM.CurrentCell.RowIndex).Value
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_cusitm") = dgPKGITEM.Item(dgPkgITem_cusitem, dgPKGITEM.CurrentCell.RowIndex).Value
            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_bonqty") = 0

            rs_PKREQDTL.Tables("RESULT").Rows(rsrowcount).Item("prd_creusr") = "~*ADD*~"

            txtPkgItem.Enabled = True
            cboPkgVendor.Enabled = False
            txtPkgMult.Enabled = False
            txtPkgOrdQty.Enabled = False
            txtPkgWastPer.Enabled = False
            txtPkgWast.Enabled = False
            txtPkgUnitPri.Enabled = False
            txtQuotePrice.Enabled = False
            ChkDel.Enabled = True

            If rsrowcount = rs_PKREQDTL.Tables("RESULT").Rows.Count - 1 Then
                cmdNext.Enabled = False
            Else
                cmdNext.Enabled = True
            End If

            If rsrowcount = 0 Then
                cmdBack.Enabled = False
            Else
                cmdBack.Enabled = True
            End If

            txtPkgItem.Select()


        ElseIf cmdReChose.Text = "_" Then ''Useless Part

            Dim seq As Integer
            seq = txtSeq.Text
            Dim loc As Integer = -1


            For i As Integer = 0 To rs_PKREQDTL.Tables("RESULT").Rows.Count - 1
                If seq = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_seq") Then
                    loc = i
                End If

            Next

            If loc = -1 Then
                MsgBox("Error Request detail not found!")
                Exit Sub
            End If




            txtItemNo.Text = dgPKGITEM.Item(dgPkgITem_realitem, dgPKGITEM.CurrentCell.RowIndex).Value + " / " + _
                               dgPKGITEM.Item(dgPkgItem_assitem, dgPKGITEM.CurrentCell.RowIndex).Value + " / " + _
                               dgPKGITEM.Item(dgPkgITem_tempitem, dgPKGITEM.CurrentCell.RowIndex).Value + " / " + _
                               dgPKGITEM.Item(dgPkgITem_venitem, dgPKGITEM.CurrentCell.RowIndex).Value + " / " + _
                               dgPKGITEM.Item(dgPkgITem_venno, dgPKGITEM.CurrentCell.RowIndex).Value + " : " + _
                               dgPKGITEM.Item(dgPkgItem_colcde, dgPKGITEM.CurrentCell.RowIndex).Value


            ' txtItemNo.Text = "realitem" + " / " + _
            '                    "tempitem" + " / " + _
            ' "venitem" + " / " + _
            '"venno"


            txtTerms.Text = dgPKGITEM.Item(dgPkgITem_Terms, dgPKGITEM.CurrentCell.RowIndex).Value

            txtPkgSTQty.Text = dgPKGITEM.Item(dgPkgITem_stqty, dgPKGITEM.CurrentCell.RowIndex).Value


            cboSTOUM.Text = dgPKGITEM.Item(dgPkgITem_um, dgPKGITEM.CurrentCell.RowIndex).Value
            cboOrdUm.Text = "PC"
            cboWastUm.Text = "PC"
            cboTtlUm.Text = "PC"
            cboReceUm.Text = "PC"
            cboWasUm.Text = "PC"
            txtPkgUnitPriCur.Text = dgPKGITEM.Item(dgPkgITem_curcde, dgPKGITEM.CurrentCell.RowIndex).Value
            txtTtlAmtCur.Text = dgPKGITEM.Item(dgPkgITem_curcde, dgPKGITEM.CurrentCell.RowIndex).Value


            txtPkgItem.Text = ""
            txtCate.Text = ""
            txtPkgChDesc.Text = ""
            txtPkgEnDesc.Text = ""
            txtPkgRemark.Text = ""
            cboPkgVendor.Text = ""
            cboRemi.Text = ""
            txtPkgAddress.Text = ""
            txtPkgState.Text = ""
            txtPkgCtry.Text = ""
            txtZip.Text = ""
            txtPkgCtnPer.Text = ""
            cboPkgCtnPer.Text = ""
            txtTel.Text = ""
            txtPkgMult.Text = ""
            txtPkgOrdQty.Text = ""
            txtPkgWastPer.Text = ""
            txtPkgWast.Text = ""
            txtPkgTtlQty.Text = ""
            txtPkgUnitPri.Text = ""
            txtTtlAmt.Text = ""
            txtPkgRcive.Text = ""
            txtEISizeH.Text = ""
            txtEISizeL.Text = ""
            txtEISizeW.Text = ""
            txtECSizeH.Text = ""
            txtECSizeL.Text = ""
            txtECSizeW.Text = ""
            txtFISizeH.Text = ""
            txtFISizeL.Text = ""
            txtFISizeW.Text = ""
            txtFCSizeH.Text = ""
            txtFCSizeL.Text = ""
            txtFCSizeW.Text = ""
            txtMatri.Text = ""
            txtTcknes.Text = ""
            txtPrtMtd.Text = ""
            txtForntCol.Text = ""
            txtBackCol.Text = ""
            txtFinish.Text = ""
            'txtForntFin.Text = ""
            'txtBackFin.Text = ""

            txtMatDsc.Text = ""
            txtTckDsc.Text = ""
            txtPrtDsc.Text = ""


            ''rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_cocde") = ""
            ''rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_reqno") = ""
            ''rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_seq") = txtSeq.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_itemno") = dgPKGITEM.Item(dgPkgITem_realitem, dgPKGITEM.CurrentCell.RowIndex).Value
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_tmpitmno") = dgPKGITEM.Item(dgPkgITem_tempitem, dgPKGITEM.CurrentCell.RowIndex).Value
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_venno") = dgPKGITEM.Item(dgPkgITem_venitem, dgPKGITEM.CurrentCell.RowIndex).Value
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_venitm") = dgPKGITEM.Item(dgPkgITem_venno, dgPKGITEM.CurrentCell.RowIndex).Value
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_pckunt") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_inrqty") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_mtrqty") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_ftyprctrm") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_hkprctrm") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_trantrm") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_pkgitm") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_pkgven") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_cate") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_chndsc") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_engdsc") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_remark") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_EInchL") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_EInchW") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_EInchH") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_EcmL") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_EcmW") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_EcmH") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_FInchL") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_FinchW") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_FinchH") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_FcmL") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_FcmW") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_FcmH") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_matral") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_tiknes") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_prtmtd") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_clrfot") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_clrbck") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_finish") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_rmtnce") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_addres") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_state") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_cntry") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_zip") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_Tel") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_cntper") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_sctoqty") = dgPKGITEM.Item(dgPkgITem_stqty, dgPKGITEM.CurrentCell.RowIndex).Value
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_qtyum") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_curcde") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_multip") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_ordqty") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_wasper") = cbococde.Text

            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_wasqty") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_ttlordqty") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_untprc") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_ttlamtqty") = cbococde.Text
            'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_receqty") = cbococde.Text


            txtPkgItem.Enabled = True
            cboPkgVendor.Enabled = False
            txtPkgMult.Enabled = False
            txtPkgOrdQty.Enabled = False
            txtPkgWastPer.Enabled = False
            txtPkgWast.Enabled = False
            txtPkgUnitPri.Enabled = False
            txtQuotePrice.Enabled = False
            txtBonQty.Enabled = False
        End If


        cmdReChose.Text = ""
        cmdReChose.Enabled = True
        Panel1.Visible = False

    End Sub


    Private Sub update_PKREQDTL()

        If rs_PKREQDTL.Tables("RESULT").Rows.Count = 0 Then
            Exit Sub

        End If

        Dim seq As Integer
        seq = txtSeq.Text
        Dim loc As Integer = -1


        For i As Integer = 0 To rs_PKREQDTL.Tables("RESULT").Rows.Count - 1
            If seq = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_seq") Then
                loc = i
            End If

        Next

        If loc = -1 Then
            MsgBox("Error Request detail not found!")
            Exit Sub
        End If

        If rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_creusr") = "~*NEW*~" Or _
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_creusr") = "~*DEL*~" Then
            Exit Sub
        End If


        Dim realitem As String
        Dim tmpitem As String
        Dim venitem As String
        Dim venno As String

        Dim PackUnt As String
        Dim inr As Integer
        Dim master As Integer
        Dim ftyprctrm As String
        Dim hkprctrm As String
        Dim trantrm As String
        Dim cft As Decimal
        Dim colcde As String
        Dim wholeItemno As String
        Dim assitem As String


        wholeItemno = Split(txtItemNo.Text, " : ")(0)

        colcde = Split(txtItemNo.Text, " : ")(1)

        realitem = Split(wholeItemno, " / ")(0)
        assitem = Split(wholeItemno, " / ")(1)
        tmpitem = Split(wholeItemno, " / ")(2)
        venitem = Split(wholeItemno, " / ")(3)
        venno = Split(wholeItemno, " / ")(4)

        PackUnt = Split(txtTerms.Text, " / ")(0)
        inr = Split(txtTerms.Text, " / ")(1)
        master = Split(txtTerms.Text, " / ")(2)
        cft = Split(txtTerms.Text, " / ")(3)
        ftyprctrm = Split(txtTerms.Text, " / ")(4)
        hkprctrm = Split(txtTerms.Text, " / ")(5)
        trantrm = Split(txtTerms.Text, " / ")(6)


        'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_cocde") = cbococde.Text
        'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_reqno") = ""
        'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_seq") = txtSeq.Text
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_colcde") = colcde
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_itemno") = realitem
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_assitm") = assitem
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_tmpitmno") = tmpitem
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_venno") = venno
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_venitm") = venitem
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_pckunt") = PackUnt
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_inrqty") = inr
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_mtrqty") = master
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_cft") = cft
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_ftyprctrm") = ftyprctrm
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_hkprctrm") = hkprctrm
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_trantrm") = trantrm
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_pkgitm") = txtPkgItem.Text
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_pkgven") = cboPkgVendor.Text
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_cate") = txtCate.Text '*
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_chndsc") = txtPkgChDesc.Text
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_engdsc") = txtPkgEnDesc.Text
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_remark") = txtPkgRemark.Text
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_EInchL") = IIf(txtEISizeL.Text = "", 0, txtEISizeL.Text)
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_EInchW") = IIf(txtEISizeW.Text = "", 0, txtEISizeW.Text)
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_EInchH") = IIf(txtEISizeH.Text = "", 0, txtEISizeH.Text)
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_EcmL") = IIf(txtECSizeL.Text = "", 0, txtECSizeL.Text)
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_EcmW") = IIf(txtECSizeW.Text = "", 0, txtECSizeW.Text)
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_EcmH") = IIf(txtECSizeH.Text = "", 0, txtECSizeH.Text)
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_FInchL") = IIf(txtFISizeL.Text = "", 0, txtFISizeL.Text)
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_FinchW") = IIf(txtFISizeW.Text = "", 0, txtFISizeW.Text)
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_FinchH") = IIf(txtFISizeH.Text = "", 0, txtFISizeH.Text)
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_FcmL") = IIf(txtFCSizeL.Text = "", 0, txtFCSizeL.Text)
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_FcmW") = IIf(txtFCSizeW.Text = "", 0, txtFCSizeW.Text)
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_FcmH") = IIf(txtFCSizeH.Text = "", 0, txtFCSizeH.Text)
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_matral") = txtMatri.Text
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_tiknes") = txtTcknes.Text
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_prtmtd") = txtPrtMtd.Text
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_clrfot") = txtForntCol.Text
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_clrbck") = txtBackCol.Text
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_finish") = txtFinish.Text
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_rmtnce") = cboRemi.Text
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_addres") = txtPkgAddress.Text
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_state") = txtPkgState.Text
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_cntry") = txtPkgCtry.Text
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_zip") = txtZip.Text
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_Tel") = txtTel.Text
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_cntper") = cboPkgCtnPer.Text
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_sctoqty") = IIf(txtPkgSTQty.Text = "", 0, txtPkgSTQty.Text)
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_qtyum") = cboSTOUM.Text
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_curcde") = txtPkgUnitPriCur.Text
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_multip") = IIf(txtPkgMult.Text = "", 0, txtPkgMult.Text) 'care  0
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_ordqty") = IIf(txtPkgOrdQty.Text = "", 0, txtPkgOrdQty.Text)


        If txtPkgWastPer.Text = "" Then
            rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_wasper") = 0
        Else
            rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_wasper") = txtPkgWastPer.Text
        End If

        If Trim(txtPkgWast.Text) = "" Then
            rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_wasqty") = 0
        Else
            rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_wasqty") = txtPkgWast.Text
        End If



        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_ttlordqty") = IIf(txtPkgTtlQty.Text = "", 0, txtPkgTtlQty.Text)
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_untprc") = txtPkgUnitPri.Text
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_ttlamtqty") = IIf(txtTtlAmt.Text = "", 0, txtTtlAmt.Text)
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_receqty") = 0 '*
        'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_creusr") = cbococde.Text
        'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_finfot") = txtForntFin.Text
        'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_finbck") = txtBackFin.Text

        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_matDsc") = txtMatDsc.Text
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_tikDsc") = txtTckDsc.Text
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_prtDsc") = txtPrtDsc.Text

        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_sku") = txtSKU.Text
        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_cusitm") = txtCustomer.Text


        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_salprc") = IIf(Trim(txtQuotePrice.Text) = "", 0, txtQuotePrice.Text)

        rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_bonqty") = IIf(Trim(txtBonQty.Text) = "", 0, txtBonQty.Text)


    End Sub



    Private Sub txtPkgItem_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPkgItem.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then



            gspStr = "sp_select_PKIMBAIF '" & txtPkgItem.Text & "'"
            rtnLong = execute_SQLStatement(gspStr, rs_PKIMBAIF, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading txtPkgItem_KeyPress sp_select_PKIMBAIF :" & rtnStr)
                Exit Sub
            End If

            If rs_PKIMBAIF.Tables("RESULT").Rows.Count <> 0 Then

                Dim realitem As String
                Dim tmpitem As String
                Dim venitem As String
                Dim venno As String
                Dim assitem As String
                Dim PackUnt As String
                Dim inr As Integer
                Dim master As Integer
                Dim ftyprctrm As String
                Dim hkprctrm As String
                Dim trantrm As String
                Dim cft As Decimal
                Dim colcde As String
                Dim wholeitemno As String

                Dim est_flag As String

                wholeitemno = Split(txtItemNo.Text, " : ")(0)


                colcde = Split(txtItemNo.Text, " : ")(1)

                realitem = Split(wholeitemno, " / ")(0)
                assitem = Split(wholeitemno, " / ")(1)
                tmpitem = Split(wholeitemno, " / ")(2)
                venitem = Split(wholeitemno, " / ")(3)
                venno = Split(wholeitemno, " / ")(4)

                PackUnt = Split(txtTerms.Text, " / ")(0)
                inr = Split(txtTerms.Text, " / ")(1)
                master = Split(txtTerms.Text, " / ")(2)
                cft = Split(txtTerms.Text, " / ")(3)
                ftyprctrm = Split(txtTerms.Text, " / ")(4)
                hkprctrm = Split(txtTerms.Text, " / ")(5)
                trantrm = Split(txtTerms.Text, " / ")(6)
                Dim dr() As DataRow

                dr = rs_PKREQDTL.Tables("RESULT").Select("prd_itemno = '" & realitem & "' and " & _
                                                          "prd_assitm = '" & assitem & "' and " & _
                                                  "prd_tmpitmno = '" & tmpitem & "' and " & _
                                                   "prd_venno = '" & venno & "' and " & _
                                                   "prd_venitm = '" & venitem & "' and " & _
                                                   "prd_pkgitm = '" & Trim(txtPkgItem.Text) & "' and " & _
                                                   "prd_colcde = '" & colcde & "'")

                If dr.Length <> 0 Then
                    'MsgBox("Duplicate Packaging Item for the Product Item.")
                    'Exit Sub
                End If





                txtPkgItem.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_pgitmno")
                txtCate.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_cate") + " - " + rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("ypc_pakna")
                txtPkgChDesc.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_chndsc")
                txtPkgEnDesc.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_engdsc")
                txtPkgRemark.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_remark")

                txtEISizeH.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_EInchH")
                txtEISizeW.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_EInchW")
                txtEISizeL.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_EInchL")

                txtECSizeH.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_EcmH")
                txtECSizeW.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_EcmW")
                txtECSizeL.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_EcmL")

                txtFISizeH.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_FInchH")
                txtFISizeL.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_FInchL")
                txtFISizeW.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_FInchW")

                txtFCSizeH.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_FcmH")
                txtFCSizeL.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_FcmL")
                txtFCSizeW.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_FcmW")

                txtMatri.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_matral")
                txtTcknes.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_tiknes")
                txtPrtMtd.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_prtmtd")
                txtForntCol.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_clrfot")
                txtBackCol.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_clrbck")
                txtFinish.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_finish")
                'txtForntFin.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_finfot")
                'txtBackFin.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_finbck")

                txtMatDsc.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_matDsc")
                txtTckDsc.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_tikDsc")
                txtPrtDsc.Text = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_prtDsc")

                est_flag = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_estflg")
                'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_cate") = txtCate.Text

                txtPkgItem.Enabled = False
                txtPkgItem.Text = UCase(txtPkgItem.Text)



                cboPkgVendor.Enabled = True
                txtPkgMult.Enabled = True
                txtPkgOrdQty.Enabled = True
                txtPkgWastPer.Enabled = False
                txtPkgWast.Enabled = False
                txtPkgUnitPri.Enabled = True
                txtQuotePrice.Enabled = True
                cboPkgCtnPer.Enabled = True
                txtBonQty.Enabled = True

                txtPkgOrdQty.Text = 0
                txtPkgUnitPri.Text = 0
                txtPkgTtlQty.Text = 0
                txtTtlAmt.Text = 0
                txtQuotePrice.Text = 0


                update_PKREQDTL()

                Dim curcde As String
                Dim dr_TOSCDETAIL() As DataRow
                dr_TOSCDETAIL = rs_TOSCDETAIL.Tables("RESULT").Select("realitem = '" & realitem & "' and " & _
                                                          "assitem = '" & assitem & "' and " & _
                                                  "tempitem = '" & tmpitem & "' and " & _
                                                   "venitemno = '" & venno & "' and " & _
                                                   "venitem = '" & venitem & "' and " & _
                                                    "colcde = '" & colcde & "'")
                If dr_TOSCDETAIL.Length <> 0 Then
                    curcde = dr_TOSCDETAIL(0)("curcde")
                Else
                    curcde = ""
                End If



                Dim dr_PKESHDR() As DataRow

                dr = rs_PKESHDR.Tables("RESULT").Select("peh_itemno = '" & realitem & "' and " & _
                                                          "peh_assitm = '" & assitem & "' and " & _
                                                  "peh_tmpitmno = '" & tmpitem & "' and " & _
                                                   "peh_venno = '" & venno & "' and " & _
                                                   "peh_venitm = '" & venitem & "' and " & _
                                                    "peh_colcde = '" & colcde & "'")


                If dr.Length = 0 Then
                    Dim rowcount_hdr As Integer
                    rowcount_hdr = rs_PKESHDR.Tables("RESULT").Rows.Count
                    rs_PKESHDR.Tables("RESULT").Rows.Add()
                    rs_PKESHDR.Tables("RESULT").Rows(rowcount_hdr).Item("peh_itemno") = realitem
                    rs_PKESHDR.Tables("RESULT").Rows(rowcount_hdr).Item("peh_assitm") = assitem
                    rs_PKESHDR.Tables("RESULT").Rows(rowcount_hdr).Item("peh_tmpitmno") = tmpitem
                    rs_PKESHDR.Tables("RESULT").Rows(rowcount_hdr).Item("peh_venno") = venno
                    rs_PKESHDR.Tables("RESULT").Rows(rowcount_hdr).Item("peh_venitm") = venitem
                    rs_PKESHDR.Tables("RESULT").Rows(rowcount_hdr).Item("peh_colcde") = colcde
                    rs_PKESHDR.Tables("RESULT").Rows(rowcount_hdr).Item("peh_price") = 0
                    rs_PKESHDR.Tables("RESULT").Rows(rowcount_hdr).Item("peh_curcde") = "HKD"
                    rs_PKESHDR.Tables("RESULT").Rows(rowcount_hdr).Item("peh_creusr") = "~*ADD*~"
                    rs_PKESHDR.Tables("RESULT").Rows(rowcount_hdr).Item("est_flag") = est_flag
                End If

                Dim seq As Integer = 1
                Dim dr_dtl() As DataRow
                dr_dtl = rs_PKESDTL.Tables("RESULT").Select("ped_itemno = '" & realitem & "' and " & _
                                                         "ped_assitm = '" & assitem & "' and " & _
                                                 "ped_tmpitmno = '" & tmpitem & "' and " & _
                                                  "ped_venno = '" & venno & "' and " & _
                                                  "ped_venitm = '" & venitem & "' and " & _
                                                   "ped_colcde = '" & colcde & "'")
                Dim lagerSeq As Integer = 0
                For i As Integer = 0 To dr_dtl.Length - 1
                    If lagerSeq <= dr_dtl(i)("ped_seq") Then
                        lagerSeq = dr_dtl(i)("ped_seq")
                    End If

                Next
                seq = lagerSeq + 1


                Dim rowcount_dtl As Integer
                rowcount_dtl = rs_PKESDTL.Tables("RESULT").Rows.Count
                rs_PKESDTL.Tables("RESULT").Rows.Add()
                rs_PKESDTL.Tables("RESULT").Rows(rowcount_dtl).Item("ped_reqseq") = txtSeq.Text
                rs_PKESDTL.Tables("RESULT").Rows(rowcount_dtl).Item("ped_seq") = seq
                rs_PKESDTL.Tables("RESULT").Rows(rowcount_dtl).Item("ped_itemno") = realitem
                rs_PKESDTL.Tables("RESULT").Rows(rowcount_dtl).Item("ped_assitm") = assitem
                rs_PKESDTL.Tables("RESULT").Rows(rowcount_dtl).Item("ped_tmpitmno") = tmpitem
                rs_PKESDTL.Tables("RESULT").Rows(rowcount_dtl).Item("ped_venno") = venno
                rs_PKESDTL.Tables("RESULT").Rows(rowcount_dtl).Item("ped_venitm") = venitem
                rs_PKESDTL.Tables("RESULT").Rows(rowcount_dtl).Item("ped_colcde") = colcde
                rs_PKESDTL.Tables("RESULT").Rows(rowcount_dtl).Item("ped_pkgitem") = txtPkgItem.Text
                rs_PKESDTL.Tables("RESULT").Rows(rowcount_dtl).Item("ped_price") = 0
                rs_PKESDTL.Tables("RESULT").Rows(rowcount_dtl).Item("ped_curcde") = "HKD"
                rs_PKESDTL.Tables("RESULT").Rows(rowcount_dtl).Item("ped_creusr") = "~*ADD*~"


                '--------------------EL HDR-----------------------'
                For i As Integer = 0 To rs_PKESHDR.Tables("RESULT").Rows.Count - 1
                    If rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_itemno") = realitem And _
                        rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_assitm") = assitem And _
                        rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_tmpitmno") = tmpitem And _
                        rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_venno") = venno And _
                        rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_venitm") = venitem And _
                        rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_colcde") = colcde Then


                        If rs_PKESHDR.Tables("RESULT").Rows(i).Item("est_flag") = "N" And est_flag = "Y" Then
                            rs_PKESHDR.Tables("RESULT").Rows(i).Item("est_flag") = "Y"
                        End If
                    End If


                    If rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_creusr") = "~*ADD*~" Then
                        '  rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_creusr") = "~*UPD*~"
                    ElseIf rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_creusr") = "~*NEW*~" Then
                        rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_creusr") = "~*ADD*~"
                    ElseIf rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_creusr") = "~*DEL*~" Then
                        rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_creusr") = "~*UPD*~"

                    End If



                Next
                '--------------------EL HDR-----------------------'



            Else
                '  MsgBox("Packaging Item not found") 't


                Select Case MsgBox("Packaging Item not found. Do you want to create the new Packaging Item now?", MsgBoxStyle.YesNoCancel)
                    Case MsgBoxResult.Yes

                        Dim frmPGM00010 As New PGM00010

                        frmPGM00010.keyName = txtPkgItem.Name
                        'frmSYM00018.strModule = "PK"

                        frmPGM00010.show_frmPGM00010(Me)



                        Me.Cursor = Cursors.Default
                    Case MsgBoxResult.No
                        Exit Sub
                End Select




                Exit Sub
            End If


        End If
    End Sub

    Private Sub txtPkgItem_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPkgItem.TextChanged

    End Sub

    Private Sub TabPage2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub cboPkgVendor_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPkgVendor.KeyUp
        auto_search_combo(cboPkgVendor, e.KeyCode)
    End Sub

    Private Sub cboPkgVendor_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cboPkgVendor.MouseClick


        MouseClickCbo = True

    End Sub

    Private Sub cboPkgVendor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPkgVendor.SelectedIndexChanged
        'Dim dv As DataView
        'dv = rs_VNBASINF.Tables("RESULT").DefaultView

        Dim dr() As DataRow
        dr = rs_VNBASINF_02.Tables("RESULT").Select("vbi_venno = '" & Split(cboPkgVendor.Text, " - ")(0) & "'")

        If dr.Length <> 0 Then
            txtPkgAddress.Text = dr(0)("vci_address").ToString
            txtPkgState.Text = dr(0)("vci_stt").ToString
            txtPkgCtry.Text = dr(0)("vci_cty").ToString
            txtZip.Text = dr(0)("vci_zip").ToString
            'txtTel.Text = dr(0)("vci_cntphn").ToString
            ' txtPkgCtnPer.Text = dr(0)("vci_cntctp").ToString
            txtPkgUnitPriCur.Text = dr(0)("vbi_curcde").ToString
            txtTtlAmtCur.Text = dr(0)("vbi_curcde").ToString
            txtQuoteCur.Text = dr(0)("vbi_curcde").ToString


        End If


        cboPkgCtnPer.Items.Clear()
        cboPkgCtnPer.Items.Add("")
        Dim dr_Ctnper() As DataRow
        dr_Ctnper = rs_VNCTNPER_09.Tables("RESULT").Select("vci_venno = '" & Split(cboPkgVendor.Text, " - ")(0) & "'")

        If dr_Ctnper.Length <> 0 Then
            For i As Integer = 0 To dr_Ctnper.Length - 1
                cboPkgCtnPer.Items.Add(dr_Ctnper(i)("vci_cntctp"))
            Next
        End If

        If dr_Ctnper.Length <> 0 Then
            cboPkgCtnPer.SelectedIndex = 1
        End If


        Dim dr_tel() As DataRow
        dr_tel = rs_VNCTNPER_09.Tables("RESULT").Select("vci_venno = '" & Split(cboPkgVendor.Text, " - ")(0) & "' and vci_cntctp = '" & cboPkgCtnPer.Text & "'")
        If dr_tel.Length <> 0 Then
            txtTel.Text = dr_tel(0)("vci_cntphn")
        Else
            txtTel.Text = ""
        End If




        If MouseClickCbo = True Then
            MouseClickCbo = False

            SetAsUpdate(txtSeq.Text)
            recordstatus = True
        End If




    End Sub

    Private Sub txtPkgOrdQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPkgOrdQty.KeyPress

        If Not ((Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or (Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 13)) Then
            e.KeyChar = Chr(0)
            MsgBox("Please input integer value.")
        End If

        recordstatus = True
        flag_panpack_keypress = True
        SetAsUpdate(txtSeq.Text)




    End Sub

    Private Sub txtPkgOrdQty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPkgOrdQty.KeyDown
        ' if (e.KeyCode == Keys.Delete)
        If e.KeyValue = Keys.Delete Then
            recordstatus = True
            flag_panpack_keypress = True
            SetAsUpdate(txtSeq.Text)

        End If
    End Sub

    Private Sub txtPkgOrdQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPkgOrdQty.TextChanged
        If flag_panpack_keypress = True Then
            flag_panpack_keypress = False
            If txtPkgOrdQty.Text = "" Then
                txtPkgOrdQty.Text = 0
            End If




            Dim cate As String = Split(txtCate.Text, " - ")(0)
            Dim ordqty As Integer = txtPkgOrdQty.Text

            Dim dr() As DataRow
            dr = rs_syswasge.Tables("RESULT").Select("pwa_code = '" & cate & "' and pwa_qtyfrm <= " & ordqty & " and pwa_qtyto >= " & ordqty)

            If dr.Length <> 0 Then
                If dr(0)("pwa_um") = "%" Then

                    txtPkgWastPer.Text = Fix(dr(0).Item("pwa_wasage"))
                    'txtWasQty.Text = Math.Round(sumqty * dr(0).Item("pwa_wasage") / 100)
                    ' txtStandWasage.Text = Math.Round(sumqty * dr(0).Item("pwa_wasage") / 100)
                    txtPkgWast.Text = Math.Round(ordqty * dr(0).Item("pwa_wasage") / 100, 0, MidpointRounding.AwayFromZero)
                    txtBonQty.Text = txtPkgWast.Text
                Else
                    txtPkgWastPer.Text = ""
                    'txtWasQty.Text = Fix(dr(0).Item("pwa_wasage"))
                    txtPkgWast.Text = Fix(dr(0).Item("pwa_wasage"))
                    txtBonQty.Text = txtPkgWast.Text
                End If

            End If

            If txtBonQty.Text <> txtPkgWast.Text Then
                txtBonQty.ForeColor = Color.Red
            Else
                txtBonQty.ForeColor = Color.Black
            End If

            'txtPkgWastPer.Text = ""
            'txtPkgWast.Text = 0


            calTotalOrdQty()
            calTotalAMT()
        End If
    End Sub

    Private Sub txtPkgWastPer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPkgWastPer.KeyPress
        recordstatus = True
        SetAsUpdate(txtSeq.Text)
    End Sub

    Private Sub txtPkgWastPer_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPkgWastPer.KeyUp

    End Sub

    Private Sub txtPkgWastPer_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPkgWastPer.LostFocus

    End Sub

    Private Sub txtPkgWastPer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPkgWastPer.TextChanged

    End Sub

    Private Sub txtPkgWast_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPkgWast.KeyPress
        recordstatus = True
        txtPkgWastPer.Text = ""
        SetAsUpdate(txtSeq.Text)
    End Sub



    Private Sub txtPkgWast_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPkgWast.TextChanged

    End Sub


    Private Sub calTotalOrdQty()

        Dim orderqty As Integer

        If txtPkgOrdQty.Text = "" Then
            orderqty = 0
        Else
            orderqty = txtPkgOrdQty.Text
        End If


        Dim Wast As Integer


        If txtBonQty.Text = "" Then
            Wast = 0
        Else
            Wast = txtBonQty.Text
        End If




        txtPkgTtlQty.Text = orderqty + Wast


    End Sub


    Private Sub calTotalAMT()
        Dim totalOrderQty As Integer
        Dim unitprice As Decimal

        If txtPkgTtlQty.Text = "" Then
            totalOrderQty = 0
        Else
            totalOrderQty = txtPkgTtlQty.Text
        End If

        If txtPkgUnitPri.Text = "" Then
            unitprice = 0
        Else
            unitprice = txtPkgUnitPri.Text

        End If


        'txtTtlAmt.Text = Math.Round(totalOrderQty * Math.Round(unitprice, 5), 2)
        txtTtlAmt.Text = round(totalOrderQty * round(unitprice, 5), 2)


        'Math.Round(sumqty * dr2(0).Item("pwa_wasage") / 100, 0, MidpointRounding.AwayFromZero)


    End Sub


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



    Private Sub txtPkgTtlQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPkgTtlQty.TextChanged

    End Sub

    Private Sub txtPkgUnitPri_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPkgUnitPri.KeyDown
        ' if (e.KeyCode == Keys.Delete)
        If e.KeyValue = Keys.Delete Then

            recordstatus = True
            flag_panpack_keypress = True
            SetAsUpdate(txtSeq.Text)
        End If
    End Sub

    Private Sub txtPkgUnitPri_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPkgUnitPri.KeyPress

        If Not ((Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 46 Or Asc(e.KeyChar) = 13) Then
            e.KeyChar = Chr(0)
            MsgBox("Please input integer value.")
        End If

        If txtPkgUnitPri.Text.Contains(".") = True Then
            If Asc(e.KeyChar) = 46 Then
                e.KeyChar = Chr(0)
                MsgBox("Please input integer value.")
            End If
        End If



        recordstatus = True
        flag_panpack_keypress = True
        SetAsUpdate(txtSeq.Text)


    End Sub



    Private Sub txtPkgMult_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPkgMult.KeyPress
        If Not ((Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or (Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 13)) Then
            e.KeyChar = Chr(0)
            MsgBox("Please input integer value.")
        End If

        recordstatus = True
        flag_panpack_keypress = True
        SetAsUpdate(txtSeq.Text)
    End Sub

    Private Sub txtPkgMult_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPkgMult.TextChanged

    End Sub


    Private Sub SetAsUpdate(ByVal seq As String)

        Dim loc As Integer = -1


        For i As Integer = 0 To rs_PKREQDTL.Tables("RESULT").Rows.Count - 1
            If seq = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_seq") Then
                loc = i
            End If

        Next

        If loc = -1 Then
            MsgBox("Error Request detail not found!")
            Exit Sub
        End If


        If rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_creusr") <> "~*ADD*~" Then
            rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_creusr") = "~*UPD*~"

        End If




    End Sub

    Private Sub txtPkgMult_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPkgMult.Validated

        update_PKREQDTL()
    End Sub


    Private Sub txtPkgMult_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPkgMult.Validating
        If txtPkgMult.Text = "" Then
            txtPkgMult.Text = 0
            Exit Sub
        End If


        If IsNumeric(txtPkgMult.Text) = False Then

            MsgBox("Please input valid integer")
            txtPkgMult.Focus()
            e.Cancel = True
        End If
    End Sub

    Private Sub txtPkgOrdQty_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPkgOrdQty.Validated
        txtPkgOrdQty.Text = Convert.ToInt32(txtPkgOrdQty.Text)
        update_PKREQDTL()
    End Sub

    Private Sub txtPkgOrdQty_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPkgOrdQty.Validating
        If txtPkgOrdQty.Text = "" Then
            txtPkgOrdQty.Text = 0
            Exit Sub
        End If

        If IsNumeric(txtPkgOrdQty.Text) = False Then

            MsgBox("Please input valid integer")
            txtPkgOrdQty.Focus()
            e.Cancel = True
        End If


    End Sub

    Private Sub txtPkgWastPer_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPkgWastPer.Validated

        If txtPkgWastPer.Text = "" Then
            Exit Sub
        End If

        If txtPkgOrdQty.Text = "" Or IsNumeric(txtPkgOrdQty.Text) = False Then
            MsgBox("Please input valid Order qty")
        Else




            If Math.Round(txtPkgOrdQty.Text * txtPkgWastPer.Text / 100) = 0 Then
                txtPkgWast.Text = 1
            Else
                txtPkgWast.Text = Math.Round(txtPkgOrdQty.Text * txtPkgWastPer.Text / 100)
            End If
            calTotalOrdQty()
            calTotalAMT()
        End If
    End Sub

    Private Sub txtPkgWastPer_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPkgWastPer.Validating

        If txtPkgWastPer.Text = "" Then
            Exit Sub
        End If

        If IsNumeric(txtPkgWastPer.Text) = False Then

            MsgBox("Please input valid integer")
            txtPkgWastPer.Focus()
            e.Cancel = True
        End If
    End Sub

    Private Sub txtPkgWast_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPkgWast.Validated
        calTotalOrdQty()
        calTotalAMT()
    End Sub

    Private Sub txtPkgWast_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPkgWast.Validating

        If txtPkgWast.Text = "" Then
            Exit Sub
        End If


        If IsNumeric(txtPkgWast.Text) = False Then

            MsgBox("Please input valid integer")
            txtPkgWast.Focus()
            e.Cancel = True
        End If
    End Sub

    Private Sub txtPkgUnitPri_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPkgUnitPri.Validated
        Dim unitpri As Decimal = txtPkgUnitPri.Text
        txtPkgUnitPri.Text = unitpri
        update_PKREQDTL()


        For i As Integer = 0 To rs_PKESDTL.Tables("RESULT").Rows.Count - 1
            If rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_reqseq") = txtSeq.Text Then
                rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_price") = txtPkgUnitPri.Text

                If rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_creusr") <> "~*ADD*~" Then
                    rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_creusr") = "~*UPD*~"
                End If

            End If
        Next




    End Sub

    Private Sub txtPkgUnitPri_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPkgUnitPri.Validating


        If txtPkgUnitPri.Text = "" Then
            txtPkgUnitPri.Text = 0
            Exit Sub
        End If

        If IsNumeric(txtPkgUnitPri.Text) = False Then

            MsgBox("Please input valid integer")

            txtPkgUnitPri.Focus()
            e.Cancel = True
            Exit Sub
        End If


        If txtPkgUnitPri.Text.Contains("..") Then
            MsgBox("Please input valid integer")

            txtPkgUnitPri.Focus()
            e.Cancel = True
            Exit Sub
        End If

        Dim realitem As String
        Dim tmpitem As String
        Dim venitem As String
        Dim venno As String
        Dim assitem As String
        Dim PackUnt As String
        Dim inr As Integer
        Dim master As Integer
        Dim ftyprctrm As String
        Dim hkprctrm As String
        Dim trantrm As String
        Dim cft As Decimal
        Dim colcde As String
        Dim wholeitemno As String
        Dim unitprice As Decimal
        wholeitemno = Split(txtItemNo.Text, " : ")(0)


        colcde = Split(txtItemNo.Text, " : ")(1)

        realitem = Split(wholeitemno, " / ")(0)
        assitem = Split(wholeitemno, " / ")(1)
        tmpitem = Split(wholeitemno, " / ")(2)
        venitem = Split(wholeitemno, " / ")(3)
        venno = Split(wholeitemno, " / ")(4)

        PackUnt = Split(txtTerms.Text, " / ")(0)
        inr = Split(txtTerms.Text, " / ")(1)
        master = Split(txtTerms.Text, " / ")(2)
        cft = Split(txtTerms.Text, " / ")(3)
        ftyprctrm = Split(txtTerms.Text, " / ")(4)
        hkprctrm = Split(txtTerms.Text, " / ")(5)
        trantrm = Split(txtTerms.Text, " / ")(6)
        unitprice = txtPkgUnitPri.Text

        Dim dr() As DataRow

        dr = rs_PKREQDTL.Tables("RESULT").Select("prd_itemno = '" & realitem & "' and " & _
                                                  "prd_assitm = '" & assitem & "' and " & _
                                          "prd_tmpitmno = '" & tmpitem & "' and " & _
                                           "prd_venno = '" & venno & "' and " & _
                                           "prd_venitm = '" & venitem & "' and " & _
                                           "prd_pkgitm = '" & Trim(txtPkgItem.Text) & "' and " & _
                                           "prd_colcde = '" & colcde & "' and " & _
                                           "prd_pckunt = '" & PackUnt & "' and " & _
                                           "prd_untprc = " & unitprice)
        If dr.Length <> 0 Then
            Dim fail As Boolean
            For i As Integer = 0 To dr.Length - 1
                If dr(i).Item("prd_seq") <> txtSeq.Text Then
                    fail = True
                    Exit For
                End If
            Next

            If fail = True Then
                MsgBox("Duplicate Packaging Item with Unit Price for the Product Item.")
                BaseTabControl1.SelectedIndex = 0
                txtPkgUnitPri.Focus()
                e.Cancel = True
                Exit Sub
            End If


        End If




    End Sub

    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click

        If rs_PKREQDTL Is Nothing Then
            Exit Sub
        End If

        If rs_PKREQDTL.Tables("RESULT").Rows.Count = 0 Then
            Exit Sub

        End If



        If CheckValid() = False Then
            Exit Sub
        End If


        Dim seq As Integer
        seq = txtSeq.Text
        Dim loc As Integer = -1


        For i As Integer = 0 To rs_PKREQDTL.Tables("RESULT").Rows.Count - 1
            If seq = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_seq") Then
                loc = i
            End If

        Next

        If loc = -1 Then
            MsgBox("Error Request detail not found!")
            Exit Sub
        End If


        If loc = rs_PKREQDTL.Tables("RESULT").Rows.Count - 1 Then
            MsgBox("Last Reocrd")
            Exit Sub
        End If

        Dim seque As Integer = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_seq")


        update_PKREQDTL()

        display_PKREQDTL(loc + 1)


    End Sub


    Private Sub display_PKREQDTL(ByVal Specseq As Integer)
        Dim loc As Integer = Specseq



        'loc = -1

        'Dim i As Integer
        'i = 0

        'Dim seq As Integer

        'For i = 0 To rs_PKREQDTL.Tables("RESULT").Rows.Count - 1
        '    seq = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_seq")


        '    If Specseq = seq Then
        '        loc = i
        '        Exit For
        '    End If
        'Next i

        'If loc = -1 Then
        '    MsgBox("Request detail not found!")
        '    Exit Sub
        'End If


        ''rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_cocde") = cbococde.Text
        ''rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_reqno") = ""
        ''rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_seq") = txtSeq.Text
        ''rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_itemno") = realitem
        ''rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_tmpitmno") = tmpitem
        ''rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_venno") = venno
        ''rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_venitm") = venitem
        'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_pckunt") = PackUnt
        'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_inrqty") = inr
        'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_mtrqty") = master
        'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_ftyprctrm") = ftyprctrm
        'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_hkprctrm") = hkprctrm
        'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_trantrm") = trantrm



        If rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_pkgven").ToString <> "" Then

            cboPkgCtnPer.Items.Clear()
            cboPkgCtnPer.Items.Add("")
            Dim dr_Ctnper() As DataRow
            dr_Ctnper = rs_VNCTNPER_09.Tables("RESULT").Select("vci_venno = '" & rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_pkgven").ToString & "'")

            If dr_Ctnper.Length <> 0 Then
                For i As Integer = 0 To dr_Ctnper.Length - 1
                    cboPkgCtnPer.Items.Add(dr_Ctnper(i)("vci_cntctp"))
                Next
            End If

            'If dr_Ctnper.Length <> 0 Then
            '    cboPkgCtnPer.SelectedIndex = 1
            'End If

        End If




        txtSeq.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_seq")

        txtItemNo.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_itemno") & " / " & _
                         rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_assitm") & " / " & _
                            rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_tmpitmno") & " / " & _
                            rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_venitm") & " / " & _
                            rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_venno") & " : " & _
                            rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_colcde")

        txtTerms.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_pckunt") & " / " & _
                            rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_inrqty") & " / " & _
                            rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_mtrqty") & " / " & _
                            rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_cft") & " / " & _
                            rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_ftyprctrm") & " / " & _
                              rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_hkprctrm") & " / " & _
                              rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_trantrm")



        txtPkgItem.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_pkgitm")

        'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_pkgven") = Split(cboPkgVendor.Text, " - ")(0)

        display_combo(rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_pkgven"), cboPkgVendor)


        txtCate.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_cate")  '*


        txtPkgChDesc.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_chndsc")
        txtPkgEnDesc.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_engdsc")
        txtPkgRemark.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_remark")
        txtEISizeL.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_EInchL")
        txtEISizeW.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_EInchW")
        txtEISizeH.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_EInchH")
        txtECSizeL.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_EcmL")
        txtECSizeW.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_EcmW")
        txtECSizeH.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_EcmH")
        txtFISizeL.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_FInchL")
        txtFISizeW.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_FinchW")
        txtFISizeH.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_FinchH")
        txtFCSizeL.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_FcmL")
        txtFCSizeW.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_FcmW")
        txtFCSizeH.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_FcmH")
        txtMatri.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_matral")
        txtTcknes.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_tiknes")
        txtPrtMtd.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_prtmtd")
        txtForntCol.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_clrfot")
        txtBackCol.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_clrbck")
        txtFinish.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_finish")
        cboRemi.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_rmtnce")
        txtPkgAddress.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_addres")
        txtPkgState.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_state")
        txtPkgCtry.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_cntry")
        txtZip.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_zip")
        txtTel.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_Tel")
        txtPkgCtnPer.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_cntper")
        cboPkgCtnPer.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_cntper")


        txtPkgSTQty.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_sctoqty")
        cboSTOUM.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_qtyum")
        txtPkgUnitPriCur.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_curcde")
        txtPkgMult.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_multip")
        txtPkgOrdQty.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_ordqty")

        If rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_wasper").ToString <> "" Then
            If rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_wasper") <> 0 Then
                txtPkgWastPer.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_wasper")
            Else
                txtPkgWastPer.Text = ""
            End If
        Else
            txtPkgWastPer.Text = ""
        End If
        txtPkgWast.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_wasqty")
        txtPkgTtlQty.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_ttlordqty")
        txtPkgUnitPri.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_untprc")
        txtTtlAmt.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_ttlamtqty")
        txtTtlAmtCur.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_curcde")
        'cboOrdUm.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_qtyum")
        ' cboWastUm.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_qtyum")
        ' cboTtlUm.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_qtyum")
        ' cboReceUm.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_qtyum")
        'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_receqty") = 1 '*
        'rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_creusr") = cbococde.Text

        txtConftr.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_conftr")

        cboOrdUm.Text = "PC"
        cboWastUm.Text = "PC"
        cboWasUm.Text = "PC"
        cboTtlUm.Text = "PC"
        cboReceUm.Text = "PC"
        ' cboStkUm.Text = "PC"

        txtSKU.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_sku")
        txtCustomer.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_cusitm")
        txtColor.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_colcde")


        'txtForntFin.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_finfot")
        'txtBackFin.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_finbck")


        txtMatDsc.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_matDsc")
        txtTckDsc.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_tikDsc")
        txtPrtDsc.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_prtDsc")

        txtPOno.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_ordno").ToString

        txtQuotePrice.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_salprc")
        txtBonQty.Text = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_bonqty")


        If rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_creusr") <> "~*ADD*~" Then
            cmdReChose.Enabled = False
        Else
            cmdReChose.Enabled = True
        End If



        If rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_creusr") = "~*DEL*~" Or _
       rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_creusr") = "~*NEW*~" Then


            ChkDel.Checked = True



            cboPkgVendor.Enabled = False
            txtPkgOrdQty.Enabled = False
            txtPkgUnitPri.Enabled = False

        Else
            If mode <> "ReadOnly" Then
                cboPkgVendor.Enabled = True
                txtPkgOrdQty.Enabled = True
                txtPkgUnitPri.Enabled = True

                ChkDel.Checked = False
            End If
        End If


        If rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_ordno").ToString <> "" Then
            ChkDel.Enabled = False
            cboPkgVendor.Enabled = False
            cboPkgCtnPer.Enabled = False
            txtPkgUnitPri.Enabled = False
        Else
            ChkDel.Enabled = True
            If mode <> "ReadOnly" Then
                cboPkgVendor.Enabled = True
                cboPkgCtnPer.Enabled = True
                txtPkgUnitPri.Enabled = True
            End If
        End If




        If loc = rs_PKREQDTL.Tables("RESULT").Rows.Count - 1 Then
            cmdNext.Enabled = False
        Else
            cmdNext.Enabled = True
        End If

        If loc = 0 Then
            cmdBack.Enabled = False
        Else
            cmdBack.Enabled = True
        End If



        If txtBonQty.Text <> txtPkgWast.Text Then
            txtBonQty.ForeColor = Color.Red
        Else
            txtBonQty.ForeColor = Color.Black
        End If





    End Sub

    Private Sub cmdBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBack.Click


        If rs_PKREQDTL Is Nothing Then
            Exit Sub
        End If

        If rs_PKREQDTL.Tables("RESULT").Rows.Count = 0 Then
            Exit Sub

        End If


        If CheckValid() = False Then
            Exit Sub
        End If


        Dim seq As Integer
        seq = txtSeq.Text
        Dim loc As Integer = -1


        For i As Integer = 0 To rs_PKREQDTL.Tables("RESULT").Rows.Count - 1
            If seq = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_seq") Then
                loc = i
            End If

        Next

        If loc = -1 Then
            MsgBox("Error Request detail not found!")
            Exit Sub
        End If



        If loc = 0 Then
            MsgBox("First Record")
            Exit Sub
        End If


        Dim seque As Integer = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_seq")

        update_PKREQDTL()


        display_PKREQDTL(loc - 1)




    End Sub

    Private Function CheckValid() As Boolean

        dgSummary.ClearSelection()
        dgSummary.CurrentCell = Nothing

        If ChkDel.Checked = True Then
            Return True
            Exit Function
        End If


        If Trim(txtItemNo.Text) = "" Then
            MsgBox("Please select UCP Item")
            Return False
            Exit Function
        End If

        If Trim(txtTerms.Text) = "" Then
            MsgBox("Please select UCP Item")
            Return False
            Exit Function
        End If


        If Trim(txtPkgItem.Text) = "" Then
            MsgBox("Please input Packaging Item")
            BaseTabControl1.SelectedIndex = 0
            txtPkgItem.Focus()
            Return False
            Exit Function
        End If


        If Trim(txtCate.Text) = "" Then
            MsgBox("Please input Packaging Item and Press 'Enter' to get information")
            BaseTabControl1.SelectedIndex = 0
            txtPkgItem.Focus()
            Return False
            Exit Function
        End If


        If Trim(cboPkgVendor.Text) = "" Then
            MsgBox("Please Select Printer Co.")
            BaseTabControl1.SelectedIndex = 0
            cboPkgVendor.Focus()
            Return False
            Exit Function
        End If


        'If Trim(txtPkgMult.Text) = "" Then
        '    MsgBox("Please input Multiplier")
        '    txtPkgMult.Focus()
        ' BaseTabControl1.SelectedIndex = 1
        '    Return False
        '    Exit Function
        'Else
        '    If IsNumeric(txtPkgMult.Text) = False Then
        '        MsgBox("Please input valid qty for Multiplier")
        ' BaseTabControl1.SelectedIndex = 1
        '        txtPkgMult.Focus()
        '        Return False
        '        Exit Function
        '    End If
        'End If

        If Trim(txtPkgOrdQty.Text) = "" Then
            MsgBox("Please input Order Qty")
            BaseTabControl1.SelectedIndex = 0
            txtPkgOrdQty.Focus()
            Return False
            Exit Function
        Else
            If IsNumeric(txtPkgOrdQty.Text) = False Then
                MsgBox("Please input valid qty for Order Qty")
                BaseTabControl1.SelectedIndex = 0
                txtPkgOrdQty.Focus()
                Return False
                Exit Function
            End If

            If Trim(txtPkgOrdQty.Text) = 0 And txtVerno.Text = "" Then
                MsgBox("Order Qty cannot be 0")
                BaseTabControl1.SelectedIndex = 0
                txtPkgOrdQty.Focus()
                Return False
                Exit Function
            ElseIf Trim(txtPkgOrdQty.Text) = 0 And txtVerno.Text = "1" Then
                MsgBox("Order Qty cannot be 0")
                BaseTabControl1.SelectedIndex = 0
                txtPkgOrdQty.Focus()
                Return False
                Exit Function
            End If

        End If

        'If Trim(txtPkgWast.Text) = "" Then
        '    MsgBox("Please input Wastage Qty")
        '    BaseTabControl1.SelectedIndex = 1
        '    txtPkgWast.Focus()
        '    Return False
        '    Exit Function
        'Else
        '    If IsNumeric(txtPkgWast.Text) = False Then
        '        MsgBox("Please input valid qty for Wastage Qty")
        '        BaseTabControl1.SelectedIndex = 1
        '        txtPkgWast.Focus()
        '        Return False
        '        Exit Function
        '    End If
        'End If


        If Trim(txtPkgUnitPri.Text) = "" Then
            MsgBox("Please input Unit Price")
            BaseTabControl1.SelectedIndex = 0
            txtPkgUnitPri.Focus()
            Return False
            Exit Function
        Else
            If IsNumeric(txtPkgUnitPri.Text) = False Then
                MsgBox("Please input valid price for Unit Price")
                BaseTabControl1.SelectedIndex = 0
                txtPkgUnitPri.Focus()
                Return False
                Exit Function
            End If

            If txtPkgUnitPri.Text = 0 Then
                MsgBox("Unit Price cannot be 0")
                BaseTabControl1.SelectedIndex = 0
                txtPkgUnitPri.Focus()
                Return False
                Exit Function
            End If

        End If


        If Trim(txtPkgWastPer.Text) <> "" Then
            If IsNumeric(txtPkgWastPer.Text) = False Then
                MsgBox("Please input valid qty for Wastage %")
                BaseTabControl1.SelectedIndex = 0
                txtPkgWastPer.Focus()
                Return False
                Exit Function
            End If

        End If


        'If Trim(txtQuotePrice.Text) = "" Then   '05-02-2014
        '    MsgBox("Please input Sale Quote Price")
        '    BaseTabControl1.SelectedIndex = 1
        '    txtQuotePrice.Focus()
        '    Return False
        '    Exit Function
        'Else
        '    If IsNumeric(txtQuotePrice.Text) = False Then
        '        MsgBox("Please input valid price for Sale Quote Price")
        '        BaseTabControl1.SelectedIndex = 1
        '        txtQuotePrice.Focus()
        '        Return False
        '        Exit Function
        '    End If

        '    If txtQuotePrice.Text = 0 Then
        '        MsgBox("Sale Quote Price cannot be 0")
        '        BaseTabControl1.SelectedIndex = 1
        '        txtQuotePrice.Focus()
        '        Return False
        '        Exit Function
        '    End If

        'End If



        Return True

    End Function

    Private Function checkTimeStamp() As Boolean
        Dim save_timestamp As Long
        Dim curr_timestamp As Long

        gspStr = "sp_select_PKREQHDR '" & cbococde.Text & "','" & txtReqno.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading checkTimeStamp sp_select_VNBASINF :" & rtnStr)
            Exit Function
        End If

        save_timestamp = rs.Tables("RESULT").Rows(0).Item("prh_timstp")
        curr_timestamp = rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_timstp")

        If save_timestamp <> curr_timestamp Then
            checkTimeStamp = False
        Else
            checkTimeStamp = True
        End If

    End Function
    Private Sub mmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdSave.Click
        If checkFocus(Me) Then Exit Sub
        If mode = "UPDATE" Then
            If Not checkTimeStamp() Then
                MsgBox("Data does not synchronous please refresh.", vbInformation, gsCompany)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
        End If

        'If CheckValid() = False Then
        '    Exit Sub
        'End If







        ' update_PKREQDTL()


        If Check_SaveValid() = False Then
            Exit Sub
        End If





        If save_PKREQHDR() = True Then

        Else
            MsgBox("Header Record Save Fail!")
            Exit Sub
        End If

        If save_PKESHDR() = True Then
        Else
            MsgBox("Product Item Estimated Cost Record Save Fail!")
            Exit Sub
        End If

        If save_PKESDTL() = True Then
        Else
            MsgBox("Packaging Item Estimated Cost Record Save Fail!")
            Exit Sub
        End If


        If save_PKREQDTL() = True Then
            MsgBox("Record Saved")
            recordstatus = False
            mmdClear_Click(sender, e)
        Else
            MsgBox("Detail Record Save Fail!")
            Exit Sub
        End If



    End Sub

  


    Private Function save_PKREQHDR() As Boolean

        If mode <> "ADD" Then

            For i As Integer = 0 To rs_PKREQDTL.Tables("RESULT").Rows.Count - 1
                rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_reqno") = rs_PKREQHDR.Tables("RESULT").Rows(0).Item("prh_reqno")
            Next

            save_PKREQHDR = True
            Exit Function
        End If


        Dim cocde As String
        Dim reqno As String
        Dim ver As Integer
        Dim issdat As String
        Dim revdat As String
        Dim status As String
        Dim cus1no As String
        Dim cus2no As String
        Dim saldiv As String
        Dim saltem As String
        Dim salrep As String
        Dim ToNo As String
        Dim ToVer As String
        Dim ToSts As String
        Dim ToIsdat As Object
        Dim ToRevdat As Object
        Dim ToRefqut As String
        Dim potyp As String
        Dim ScNo As String
        Dim ScVer As String
        Dim ScSts As String
        Dim ScIsdat As Object
        Dim ScRevdat As Object
        Dim ScPodat As Object
        Dim ScCandat As Object
        Dim ScShpDatstr As Object
        Dim ScShpdatend As Object
        Dim ScRemark As String

        Dim NewNO As String
        gspStr = "sp_select_DOC_GEN '" & cbococde.Text & "','KR','" & gsUsrID & "'"
        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdSaveClick sp_select_DOC_GEN :" & rtnStr)
            Exit Function
        End If

        NewNO = rs.Tables("RESULT").Rows(0).Item(0)

        For i As Integer = 0 To rs_PKREQDTL.Tables("RESULT").Rows.Count - 1
            rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_reqno") = NewNO
        Next


        txtReqno.Text = NewNO
        cocde = cbococde.Text
        reqno = NewNO
        ver = 1
        issdat = DateTime.Now.ToShortDateString  '?
        revdat = DateTime.Now.ToShortDateString
        status = "OPE"
        cus1no = Split(cboPriCust.Text, " - ")(0)
        cus2no = Split(cboSecCust.Text, " - ")(0)
        saldiv = Split(txtSalesDiv.Text, " ")(1)

        Try
            saltem = Split(txtSalesDiv.Text, " ")(3).Substring(0, 1)

        Catch
        End Try

        salrep = Split(cboSalesRep.Text, " - ")(0)
        ToNo = txtToNo.Text
        ToVer = txtToVer.Text
        ToSts = Split(cboToStatus.Text, " - ")(0)

        If txtToIssDate.Text <> "" Then
            ToIsdat = txtToIssDate.Text
        Else
            ToIsdat = DBNull.Value
        End If

        If txtToRevDate.Text <> "" Then
            ToRevdat = txtToRevDate.Text
        Else
            ToRevdat = DBNull.Value
        End If


        ToRefqut = txtRefQuot.Text

        potyp = ""
        ScNo = txtScNo.Text
        ScVer = txtScVer.Text
        ScSts = Split(cboScStatus.Text, " - ")(0)

        If txtScIssDat.Text <> "" Then
            ScIsdat = txtScIssDat.Text
        Else
            ScIsdat = DBNull.Value
        End If

        If txtScRevDate.Text <> "" Then
            ScRevdat = txtScRevDate.Text
        Else
            ScRevdat = DBNull.Value
        End If

        If txtCustPoDate.Text <> "" Then
            ScPodat = txtCustPoDate.Text
        Else
            ScPodat = DBNull.Value

        End If

        If txtScCancelDate.Text <> "" Then
            ScCandat = txtScCancelDate.Text
        Else
            ScCandat = DBNull.Value
        End If


        If txtScShipDateStr.Text <> "" Then
            ScShpDatstr = txtScShipDateStr.Text
        Else
            ScShpDatstr = DBNull.Value
        End If

        If txtScShipDateEnd.Text <> "" Then
            ScShpdatend = txtScShipDateEnd.Text
        Else
            ScShpdatend = DBNull.Value
        End If


        ScRemark = Replace(txtScRemark.Text, "'", "''")

        If mode = "ADD" Then
            gspStr = "sp_insert_PKREQHDR '" & cocde & "','" & reqno & "'," & ver & ",'" & issdat & "','" & revdat & "','" & _
                                            status & "','" & cus1no & "','" & cus2no & "','" & saldiv & "','" & saltem & "','" & _
                                            salrep & "','" & ToNo & "','" & ToVer & "','" & ToSts & "','" & ToIsdat & "','" & _
                                            ToRevdat & "','" & ToRefqut & "','" & potyp & "','" & ScNo & "','" & ScVer & "','" & _
                                            ScSts & "','" & ScIsdat & "','" & ScRevdat & "','" & ScPodat & "','" & ScCandat & "','" & _
                                            ScShpDatstr & "','" & ScShpdatend & "','" & ScRemark & "','" & "02" & "','" & gsUsrID & "'"


            rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
            If rtnLong <> RC_SUCCESS Then
                MsgBox("Error on loading save_TOORDHDR sp_insert_TOORDHDR :" & rtnStr)
                save_PKREQHDR = False
                Exit Function
            End If


        End If


        save_PKREQHDR = True

    End Function



    Private Function save_PKREQDTL() As Boolean

        If rs_PKREQDTL.Tables("RESULT").Rows.Count = 0 Then
            save_PKREQDTL = True
            Exit Function
        End If


        Dim cocde As String
        Dim reqno As String
        Dim seq As Integer
        Dim itemno As String
        Dim assitm As String
        Dim tmpitmno As String
        Dim venno As String
        Dim venitm As String
        Dim pckunt As String
        Dim inrqty As Integer
        Dim mtrqty As Integer
        Dim cft As Decimal
        Dim colcde As String
        Dim conftr As Integer
        Dim ftyprctrm As String
        Dim hkprctrm As String
        Dim trantrm As String
        Dim pkgitm As String
        Dim pkgven As String
        Dim cate As String
        Dim chndsc As String
        Dim engdsc As String
        Dim remark As String
        Dim EinchL As Decimal
        Dim EinchW As Decimal
        Dim EinchH As Decimal
        Dim EcmL As Decimal
        Dim EcmW As Decimal
        Dim EcmH As Decimal
        Dim FinchL As Decimal
        Dim FinchW As Decimal
        Dim FinchH As Decimal
        Dim FcmL As Decimal
        Dim FcmW As Decimal
        Dim FcmH As Decimal
        Dim matral As String
        Dim tiknes As String
        Dim prtmtd As String
        Dim clrfot As String
        Dim clrbck As String
        Dim finish As String
        Dim matdsc As String
        Dim tckdsc As String
        Dim prtdsc As String
        'Dim finfot As String
        'Dim finbck As String
        Dim rmtnce As String
        Dim addres As String
        Dim state As String
        Dim cntry As String
        Dim zip As String
        Dim Tel As String
        Dim cntper As String
        Dim sctoqty As Integer
        Dim qtyum As String
        Dim curcde As String
        Dim multip As Integer
        Dim ordqty As Integer
        Dim wasper As Decimal
        Dim wasqty As Integer
        Dim ttlordqty As Integer
        Dim untprc As Decimal
        Dim ttlamtqty As Decimal
        Dim receqty As Integer
        Dim quoteprice As Decimal
        Dim ScToNo As String
        Dim ScToSeq As Integer
        Dim sku As String
        Dim cusitm As String
        Dim bonqty As Integer
        Dim cresur As String



        For i As Integer = 0 To rs_PKREQDTL.Tables("RESULT").Rows.Count - 1


            cocde = cbococde.Text
            reqno = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_reqno")
            seq = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_seq")
            itemno = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_itemno")
            assitm = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_assitm")
            tmpitmno = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_tmpitmno")
            venno = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_venno")
            venitm = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_venitm")
            pckunt = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_pckunt")
            inrqty = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_inrqty")
            mtrqty = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_mtrqty")
            cft = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_cft")
            colcde = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_colcde")
            conftr = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_conftr")
            ftyprctrm = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_ftyprctrm")
            hkprctrm = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_hkprctrm")
            trantrm = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_trantrm")
            pkgitm = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_pkgitm")
            pkgven = Split(rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_pkgven"), " - ")(0)
            cate = Split(rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_cate"), " - ")(0)
            chndsc = Replace(rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_chndsc"), "'", "''")
            engdsc = Replace(rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_engdsc"), "'", "''")
            remark = Replace(rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_remark"), "'", "''")
            EinchL = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_EInchL")
            EinchW = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_EInchW")
            EinchH = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_EInchH")
            EcmL = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_EcmL")
            EcmW = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_EcmW")
            EcmH = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_EcmH")
            FinchL = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_FInchL")
            FinchW = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_FinchW")
            FinchH = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_FinchH")
            FcmL = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_FcmL")
            FcmW = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_FcmW")
            FcmH = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_FcmH")
            matral = Replace(rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_matral"), "'", "''")
            tiknes = Replace(rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_tiknes"), "'", "''")
            prtmtd = Replace(rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_prtmtd"), "'", "''")
            clrfot = Replace(rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_clrfot"), "'", "''")
            clrbck = Replace(rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_clrbck"), "'", "''")
            finish = Replace(rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_finish"), "'", "''")
            matdsc = Replace(rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_matDsc"), "'", "''")
            tckdsc = Replace(rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_tikDsc"), "'", "''")
            prtdsc = Replace(rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_prtDsc"), "'", "''")
            'finfot = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_finfot")
            'finbck = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_finbck")
            rmtnce = Replace(rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_rmtnce"), "'", "''")
            addres = Replace(rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_addres"), "'", "''")
            state = Replace(rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_state"), "'", "''")
            cntry = Replace(rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_cntry"), "'", "''")
            zip = Replace(rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_zip"), "'", "''")
            Tel = Replace(rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_Tel"), "'", "''")
            cntper = Replace(rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_cntper"), "'", "''")
            sctoqty = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_sctoqty")
            qtyum = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_qtyum")
            curcde = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_curcde")

            multip = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_multip") 'care txtPkgMult.Text

            ordqty = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_ordqty")



            wasper = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_wasper")



            wasqty = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_wasqty")
            ttlordqty = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_ttlordqty")
            untprc = round(rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_untprc"), 5)
            ttlamtqty = round(rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_ttlamtqty"), 2)
            receqty = 0 'rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_receqty")   '*
            quoteprice = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_salprc")

            ScToNo = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_ScToNo")
            ScToSeq = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_ScToSeq")


            sku = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_sku")
            cusitm = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_cusitm")

            bonqty = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_bonqty")
            cresur = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_creusr")
            'rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_creusr") = cbococde.Text


            If cresur = "~*ADD*~" Then


                gspStr = "sp_insert_PKREQDTL '" & cocde & "','" & reqno & "'," & seq & ",'" & itemno & "','" & assitm & "','" & tmpitmno & "','" & _
                                           venno & "','" & venitm & "','" & pckunt & "'," & inrqty & "," & mtrqty & "," & cft & ",'" & colcde & "'," & conftr & ",'" & _
                                           ftyprctrm & "','" & hkprctrm & "','" & trantrm & "','" & pkgitm & "','" & pkgven & "','" & _
                                           cate & "','" & chndsc & "','" & engdsc & "','" & remark & "'," & EinchL & "," & _
                                           EinchW & "," & EinchH & "," & EcmL & "," & EcmW & "," & EcmH & "," & _
                                           FinchL & "," & FinchW & "," & FinchH & "," & FcmL & "," & FcmW & "," & _
                                              FcmH & ",'" & matral & "','" & tiknes & "','" & prtmtd & "','" & clrfot & "','" & _
                                           clrbck & "','" & finish & "','" & matdsc & "','" & tckdsc & "','" & prtdsc & "','" & rmtnce & "','" & addres & "','" & state & "','" & _
                                           cntry & "','" & zip & "','" & Tel & "','" & cntper & "'," & sctoqty & ",'" & _
                                           qtyum & "','" & curcde & "'," & multip & "," & ordqty & "," & wasper & "," & _
                                           wasqty & "," & ttlordqty & "," & untprc & "," & ttlamtqty & "," & receqty & ",'" & "02" & "'," & quoteprice & ",'" & _
                                           ScToNo & "'," & ScToSeq & ",'" & sku & "','" & cusitm & "'," & bonqty & ",'" & gsUsrID & "'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_PKREQDTL sp_insert_PKREQDTL :" & rtnStr)
                    save_PKREQDTL = False
                    Exit Function
                End If



            ElseIf cresur = "~*UPD*~" Then

                gspStr = "sp_update_PKREQDTL '" & cocde & "','" & reqno & "'," & seq & "," & multip & "," & ordqty & "," & wasper & "," & _
                                          wasqty & "," & ttlordqty & "," & untprc & "," & ttlamtqty & "," & receqty & ",'" & pkgven & "'," & _
                                          quoteprice & ",'" & cntper & "','" & Tel & "','" & curcde & "'," & bonqty & ",'" & gsUsrID & "'"

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_PKREQDTL sp_update_PKREQDTL :" & rtnStr)
                    save_PKREQDTL = False
                    Exit Function
                End If


            ElseIf cresur = "~*DEL*~" Then

                gspStr = "sp_physical_delete_PKREQDTL '" & cocde & "','" & reqno & "'," & seq

                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_PKREQDTL sp_physical_delete_PKREQDTL :" & rtnStr)
                    save_PKREQDTL = False
                    Exit Function
                End If
            End If


        Next



        save_PKREQDTL = True




    End Function




    Private Function Check_SaveValid() As Boolean
        'If Trim(txtItemNo.Text) = "" Then
        '    MsgBox("Please select UCP Item")
        '    Return False
        '    Exit Function
        'End If

        If rs_PKREQDTL Is Nothing Then
            MsgBox("Please input Details!")
            Return False
        End If

        If rs_PKREQDTL.Tables("RESULT").Rows.Count = 0 Then
            MsgBox("Please input Details!")
            Return False
        End If



        For i As Integer = 0 To rs_PKREQDTL.Tables("RESULT").Rows.Count - 1

            If rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_creusr") = "~*DEL*~" Or _
               rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_creusr") = "~*NEW*~" Then
                Continue For
            End If

            If rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_itemno") = "" And _
            rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_tmpitmno") = "" And _
            rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_venitm") = "" Then

                display_PKREQDTL(i)


                MsgBox("Please select UCP Item")
                Return False
                Exit Function
            End If

            If rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_pkgitm").ToString = "" Or _
                rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_cate").ToString = "" Then
                display_PKREQDTL(i)
                MsgBox("Please input Packaging Item")
                txtPkgItem.Focus()
                Return False
                Exit Function
            End If

            If rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_pkgven").ToString = "" Then
                display_PKREQDTL(i)
                MsgBox("Please select Printer Co.")
                cboPkgVendor.Focus()
                Return False
                Exit Function
            End If



            'If rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_multip").ToString = "" Then
            '    display_PKREQDTL(i)
            '    MsgBox("Please input Multiplier")
            '    txtPkgMult.Focus()
            '    Return False
            '    Exit Function
            'Else
            '    If IsNumeric(rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_multip")) = False Then
            '        display_PKREQDTL(i)
            '        MsgBox("Please input valid qty for Multiplier")
            '        txtPkgMult.Focus()
            '        Return False
            '        Exit Function
            '    End If
            'End If


            If rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_ordqty").ToString = "" Then
                display_PKREQDTL(i)
                MsgBox("Please input Order Qty")
                txtPkgOrdQty.Focus()
                Return False
                Exit Function
            Else
                If IsNumeric(rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_ordqty")) = False Then
                    display_PKREQDTL(i)
                    MsgBox("Please input valid qty for Order Qty")
                    txtPkgOrdQty.Focus()
                    Return False
                    Exit Function
                ElseIf Trim(txtPkgOrdQty.Text) = 0 And txtVerno.Text = "" Then

                    display_PKREQDTL(i)
                    MsgBox("Order Qty cannot be 0")
                    txtPkgOrdQty.Focus()
                    Return False
                    Exit Function
                ElseIf Trim(txtPkgOrdQty.Text) = 0 And txtVerno.Text = "1" Then
                    display_PKREQDTL(i)
                    MsgBox("Order Qty cannot be 0")
                    txtPkgOrdQty.Focus()
                    Return False
                    Exit Function
                End If
            End If






            'If rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_wasqty").ToString = "" Then
            '    display_PKREQDTL(i)
            '    MsgBox("Please input Wastage Qty")
            '    txtPkgWast.Focus()
            '    Return False
            '    Exit Function
            'Else
            '    If IsNumeric(rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_wasqty")) = False Then
            '        display_PKREQDTL(i)
            '        MsgBox("Please input valid qty for Wastage Qty")
            '        txtPkgWast.Focus()
            '        Return False
            '        Exit Function
            '    End If

            'End If

            If rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_untprc").ToString = "" Then
                display_PKREQDTL(i)
                MsgBox("Please input Unit Price")
                txtPkgUnitPri.Focus()
                Return False
                Exit Function
            Else
                If IsNumeric(rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_untprc")) = False Then
                    display_PKREQDTL(i)
                    MsgBox("Please input valid price for Unit Price")
                    txtPkgUnitPri.Focus()
                    Return False
                    Exit Function

                ElseIf rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_untprc") = 0 Then
                    display_PKREQDTL(i)
                    MsgBox("Unit Price cannot be zero")
                    txtPkgUnitPri.Focus()
                    Return False
                    Exit Function
                End If


            End If




            'If rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_salprc").ToString = "" Then  05-02-2014
            '    display_PKREQDTL(i)
            '    MsgBox("Please input Sale Quote Price")
            '    txtQuotePrice.Focus()
            '    Return False
            '    Exit Function
            'Else
            '    If IsNumeric(rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_salprc")) = False Then
            '        display_PKREQDTL(i)
            '        MsgBox("Please input valid qty for Sale Quote Price")
            '        txtQuotePrice.Focus()
            '        Return False
            '        Exit Function

            '    ElseIf rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_salprc") = 0 Then
            '        display_PKREQDTL(i)
            '        MsgBox("Sale Quote Price cannot be zero")
            '        txtQuotePrice.Focus()
            '        Return False
            '        Exit Function
            '    End If


            'End If







            'If rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_wasper").ToString <> "" Then
            '    If IsNumeric(rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_wasper")) = False Then
            '        display_PKREQDTL(i)
            '        MsgBox("Please input valid qty for Wastage %")
            '        txtPkgWastPer.Focus()
            '        Return False
            '        Exit Function
            '    End If

            'End If

        Next




        'If Trim(txtTerms.Text) = "" Then
        '    MsgBox("Please select UCP Item")
        '    Return False
        '    Exit Function
        'End If


        'If Trim(txtPkgItem.Text) = "" Then
        '    MsgBox("Please input Packaging Item")
        '    txtPkgItem.Focus()
        '    Return False
        '    Exit Function
        'End If


        'If Trim(txtCate.Text) = "" Then
        '    MsgBox("Please input Packaging Item and Press 'Enter' to get information")
        '    txtPkgItem.Focus()
        '    Return False
        '    Exit Function
        'End If


        'If Trim(cboPkgVendor.Text) = "" Then
        '    MsgBox("Please input Packaging Item and Press 'Enter' to get information")
        '    cboPkgVendor.Focus()
        '    Return False
        '    Exit Function
        'End If


        'If Trim(txtPkgMult.Text) = "" Then
        '    MsgBox("Please input Multiplier")
        '    txtPkgMult.Focus()
        '    Return False
        '    Exit Function
        'Else
        '    If IsNumeric(txtPkgMult.Text) = False Then
        '        MsgBox("Please input valid qty for Multiplier")
        '        txtPkgMult.Focus()
        '        Return False
        '        Exit Function
        '    End If
        'End If




        'If Trim(txtPkgOrdQty.Text) = "" Then
        '    MsgBox("Please input Order Qty")
        '    txtPkgOrdQty.Focus()
        '    Return False
        '    Exit Function
        'Else
        '    If IsNumeric(txtPkgOrdQty.Text) = False Then
        '        MsgBox("Please input valid qty for Order Qty")
        '        txtPkgOrdQty.Focus()
        '        Return False
        '        Exit Function
        '    End If
        'End If

        'If Trim(txtPkgWast.Text) = "" Then
        '    MsgBox("Please input Wastage Qty")
        '    txtPkgWast.Focus()
        '    Return False
        '    Exit Function
        'Else
        '    If IsNumeric(txtPkgWast.Text) = False Then
        '        MsgBox("Please input valid qty for Wastage Qty")
        '        txtPkgWast.Focus()
        '        Return False
        '        Exit Function
        '    End If
        'End If


        'If Trim(txtPkgUnitPri.Text) = "" Then
        '    MsgBox("Please input Unit Price")
        '    txtPkgUnitPri.Focus()
        '    Return False
        '    Exit Function
        'Else
        '    If IsNumeric(txtPkgUnitPri.Text) = False Then
        '        MsgBox("Please input valid qty for Unit Price")
        '        txtPkgUnitPri.Focus()
        '        Return False
        '        Exit Function
        '    End If
        'End If


        'If Trim(txtPkgWastPer.Text) <> "" Then
        '    If IsNumeric(txtPkgWastPer.Text) = False Then
        '        MsgBox("Please input valid qty for Wastage %")
        '        txtPkgWastPer.Focus()
        '        Return False
        '        Exit Function
        '    End If

        'End If



        Return True


    End Function

    Private Sub txtReqno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtReqno.KeyPress
        If e.KeyChar.Equals(Chr(13)) Then
            Call mmdFind_Click(sender, e)
        End If
    End Sub

    Private Sub txtReqno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReqno.TextChanged

    End Sub
    Private Sub mmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdClear.Click
        If checkFocus(Me) Then Exit Sub
        Dim tmp_reqno As String
        Dim tmp_cocde As String

        If recordstatus = True Then
            Select Case MsgBox("Record has been modified. Do you want to save before clear the screen?", MsgBoxStyle.YesNoCancel)
                Case MsgBoxResult.Yes
                    If Enq_right_local Then
                        Call mmdSave_Click(sender, e)
                    Else
                        MsgBox("You have no Save record rights!")
                    End If
                    Me.Cursor = Cursors.Default
                Case MsgBoxResult.No
                    tmp_cocde = cbococde.Text
                    tmp_reqno = txtReqno.Text
                    formInit("INIT")
                    txtReqno.Text = tmp_reqno
                    cbococde.Text = tmp_cocde
                    txtReqno.Select()
                    Me.Cursor = Cursors.Default
            End Select
        Else
            tmp_reqno = txtReqno.Text
            tmp_cocde = cbococde.Text
            formInit("INIT")
            txtReqno.Text = tmp_reqno
            cbococde.Text = tmp_cocde
            txtReqno.Select()
            Me.Cursor = Cursors.Default
        End If
    End Sub

   

    Private Sub cmdReChose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReChose.Click




        cmdReChose.Text = "_"


        txtPkgItem.Enabled = False
        cboPkgVendor.Enabled = False
        txtPkgMult.Enabled = False
        txtPkgOrdQty.Enabled = False
        txtPkgWastPer.Enabled = False
        txtPkgWast.Enabled = False
        txtPkgUnitPri.Enabled = False

        Panel1.Visible = True
        Panel1.BringToFront()
    End Sub

    Private Sub cmdItemCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdItemCancel.Click
        'If cmdReChose.Text = "_" Then
        '    txtPkgItem.Enabled = True
        '    cboPkgVendor.Enabled = True
        '    txtPkgMult.Enabled = True
        '    txtPkgOrdQty.Enabled = True
        '    txtPkgWastPer.Enabled = True
        '    txtPkgWast.Enabled = True
        '    txtPkgUnitPri.Enabled = True
        'End If

        Panel1.Visible = False
        cmdReChose.Text = ""

    End Sub






    Private Sub ChkDel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkDel.CheckedChanged

    End Sub

    Private Sub ChkDel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkDel.Click
        If ChkDel.Checked = True Then
            If rs_PKREQDTL.Tables("RESULT").Rows.Count = 0 Then
                Exit Sub

            End If

            Dim seq As Integer
            seq = txtSeq.Text
            Dim loc As Integer = -1


            For i As Integer = 0 To rs_PKREQDTL.Tables("RESULT").Rows.Count - 1
                If seq = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_seq") Then
                    loc = i
                End If

            Next

            If loc = -1 Then
                MsgBox("Error Request detail not found!")
                Exit Sub
            End If

            ' rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_creusr") = "~*DEL*~"

            '--------------------Request DTL-----------------------'

            If rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_creusr") <> "~*ADD*~" And _
                  rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_creusr") <> "~*DEL*~" And _
                  rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_creusr") <> "~*NEW*~" Then
                rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_creusr") = "~*DEL*~"
            ElseIf rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_creusr") = "~*ADD*~" Then
                rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_creusr") = "~*NEW*~"
            End If
            '--------------------Request DTL-----------------------'

            Dim realitem As String = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_itemno")
            Dim assitem As String = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_assitm")
            Dim tmpitem As String = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_tmpitmno")
            Dim venno As String = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_venno")
            Dim venitem As String = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_venitm")
            Dim colcde As String = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_colcde")


            '  '--------------------ELimtited DTL-----------------------'
            For i As Integer = 0 To rs_PKESDTL.Tables("RESULT").Rows.Count - 1
                If rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_reqseq") = txtSeq.Text Then

                    If rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_creusr") <> "~*ADD*~" And _
           rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_creusr") <> "~*DEL*~" And _
           rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_creusr") <> "~*NEW*~" Then
                        rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_creusr") = "~*DEL*~"
                    ElseIf rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_creusr") = "~*ADD*~" Then
                        rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_creusr") = "~*NEW*~"
                    End If


                End If
            Next
            '  '--------------------ELimtited DTL-----------------------'
            Dim dr_PKREQDTL() As DataRow

            dr_PKREQDTL = rs_PKREQDTL.Tables("RESULT").Select("prd_itemno = '" & realitem & "' and " & _
                                                            "prd_assitm = '" & assitem & "' and " & _
                                              "prd_tmpitmno = '" & tmpitem & "' and " & _
                                               "prd_venno = '" & venno & "' and " & _
                                               "prd_venitm = '" & venitem & "' and " & _
                                                "prd_colcde = '" & colcde & "'")

            Dim ttl_Dtl As Integer = dr_PKREQDTL.Length

            Dim ttl_Del As Integer = 0


            For i As Integer = 0 To dr_PKREQDTL.Length - 1
                If dr_PKREQDTL(i)("prd_creusr") = "~*DEL*~" Or dr_PKREQDTL(i)("prd_creusr") = "~*NEW*~" Then
                    ttl_Del = ttl_Del + 1
                End If
            Next
            '  '--------------------ELimtited HDR-----------------------'
            If ttl_Del = ttl_Dtl Then
                For i As Integer = 0 To rs_PKESHDR.Tables("RESULT").Rows.Count - 1
                    If rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_itemno") = realitem And _
                        rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_assitm") = assitem And _
                        rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_tmpitmno") = tmpitem And _
                        rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_venno") = venno And _
                        rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_venitm") = venitem And _
                        rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_colcde") = colcde Then


                        If rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_creusr") <> "~*ADD*~" And _
                         rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_creusr") <> "~*DEL*~" And _
                         rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_creusr") <> "~*NEW*~" Then
                            rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_creusr") = "~*DEL*~"
                        ElseIf rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_creusr") = "~*ADD*~" Then
                            rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_creusr") = "~*NEW*~"
                        End If

                    End If
                Next
            End If
            '  '--------------------ELimtited HDR-----------------------'

            'Dim dr_PKESHDR() As DataRow

            'dr_PKESHDR = rs_PKESHDR.Tables("RESULT").Select("peh_itemno = '" & realitem & "' and " & _
            '                                          "peh_assitm = '" & assitem & "' and " & _
            '                                  "peh_tmpitmno = '" & tmpitem & "' and " & _
            '                                   "peh_venno = '" & venno & "' and " & _
            '                                   "peh_venitm = '" & venitem & "' and " & _
            '                                    "peh_colcde = '" & colcde & "'")







            txtPkgItem.Enabled = False
            cboPkgVendor.Enabled = False
            txtPkgOrdQty.Enabled = False
            txtPkgUnitPri.Enabled = False





        Else

            If rs_PKREQDTL.Tables("RESULT").Rows.Count = 0 Then
                Exit Sub

            End If

            Dim seq As Integer
            seq = txtSeq.Text
            Dim loc As Integer = -1


            For i As Integer = 0 To rs_PKREQDTL.Tables("RESULT").Rows.Count - 1
                If seq = rs_PKREQDTL.Tables("RESULT").Rows(i).Item("prd_seq") Then
                    loc = i
                End If

            Next

            If loc = -1 Then
                MsgBox("Error Request detail not found!")
                Exit Sub
            End If

            ' rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_creusr") = "~*DEL*~"

            '--------------------Request DTL-----------------------'
            If rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_creusr") = "~*ADD*~" Then
                rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_creusr") = "~*UPD*~"
            ElseIf rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_creusr") = "~*NEW*~" Then
                rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_creusr") = "~*ADD*~"
            ElseIf rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_creusr") = "~*DEL*~" Then
                rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_creusr") = "~*UPD*~"
            End If
            '--------------------Request DTL-----------------------'
            Dim realitem As String = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_itemno")
            Dim assitem As String = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_assitm")
            Dim tmpitem As String = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_tmpitmno")
            Dim venno As String = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_venno")
            Dim venitem As String = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_venitm")
            Dim colcde As String = rs_PKREQDTL.Tables("RESULT").Rows(loc).Item("prd_colcde")

            For i As Integer = 0 To rs_PKESDTL.Tables("RESULT").Rows.Count - 1
                If rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_reqseq") = txtSeq.Text Then

                    '--------------------EL DTL-----------------------'
                    If rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_creusr") = "~*ADD*~" Then
                        rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_creusr") = "~*UPD*~"
                    ElseIf rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_creusr") = "~*NEW*~" Then
                        rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_creusr") = "~*ADD*~"
                    ElseIf rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_creusr") = "~*DEL*~" Then
                        rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_creusr") = "~*UPD*~"
                    End If

                    '--------------------EL DTL-----------------------'

                End If
            Next

            Dim dr_PKREQDTL() As DataRow

            dr_PKREQDTL = rs_PKREQDTL.Tables("RESULT").Select("prd_itemno = '" & realitem & "' and " & _
                                                            "prd_assitm = '" & assitem & "' and " & _
                                              "prd_tmpitmno = '" & tmpitem & "' and " & _
                                               "prd_venno = '" & venno & "' and " & _
                                               "prd_venitm = '" & venitem & "' and " & _
                                                "prd_colcde = '" & colcde & "'")
            '--------------------EL HDR-----------------------'
            For i As Integer = 0 To rs_PKESHDR.Tables("RESULT").Rows.Count - 1
                If rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_itemno") = realitem And _
                    rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_assitm") = assitem And _
                    rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_tmpitmno") = tmpitem And _
                    rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_venno") = venno And _
                    rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_venitm") = venitem And _
                    rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_colcde") = colcde Then



                    If rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_creusr") = "~*ADD*~" Then
                        ' rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_creusr") = "~*UPD*~"
                    ElseIf rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_creusr") = "~*NEW*~" Then
                        rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_creusr") = "~*ADD*~"
                    ElseIf rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_creusr") = "~*DEL*~" Then
                        rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_creusr") = "~*UPD*~"

                    End If



                End If
            Next
            '--------------------EL HDR-----------------------'


            If Trim(txtPkgItem.Text) = "" And Trim(txtCate.Text) = "" Then
                txtPkgItem.Enabled = True
                cboPkgVendor.Enabled = False
                txtPkgOrdQty.Enabled = False
                txtPkgUnitPri.Enabled = False
            ElseIf Trim(txtPkgItem.Text) <> "" And Trim(txtCate.Text) = "" Then
                txtPkgItem.Enabled = True
                cboPkgVendor.Enabled = False
                txtPkgOrdQty.Enabled = False
                txtPkgUnitPri.Enabled = False
            ElseIf txtCate.Text <> "" Then
                txtPkgItem.Enabled = False
                cboPkgVendor.Enabled = True
                txtPkgOrdQty.Enabled = True
                txtPkgUnitPri.Enabled = True
            End If





        End If
    End Sub

    Private Sub mmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdDelete.Click

    End Sub

    Private Sub mmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdExit.Click
        If checkFocus(Me) Then Exit Sub
        If recordstatus = True Then
            mmdClear_Click(sender, e)
        End If
        Me.Close()


    End Sub

 

    Private Sub cmdRelease_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRelease.Click




        'For i As Integer = 0 To rs_PKESHDR.Tables("RESULT").Rows.Count - 1
        '    If rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_creusr") = "~*DEL*~" Or _
        '        rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_creusr") = "~*NEW*~" Then
        '        Continue For
        '    End If

        '    If rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_price") = 0 Then
        '        MsgBox("Please Enter Estimated Cost for Product Item.")
        '        BaseTabControl1.SelectedIndex = 3
        '        Exit Sub
        '    End If
        'Next

        'If save_PKESHDR() = True Then
        'Else
        '    MsgBox("Product Item Estimated Cost Record Save Fail!")
        '    Exit Sub
        'End If



        FrmPGM00003 = New PGM00003
        FrmPGM00003.txtFrom.Text = txtReqno.Text
        FrmPGM00003.txtTo.Text = txtReqno.Text
        FrmPGM00003.companycode = cbococde.Text


        FrmPGM00003.txtFrom.Enabled = False
        FrmPGM00003.txtTo.Enabled = False
        FrmPGM00003.optRel.Enabled = False
        FrmPGM00003.optUnr.Enabled = False

        If cboStatus.Text.Split(" -")(0) = "REL" Then
            FrmPGM00003.optUnr.Checked = True
        Else
            FrmPGM00003.optRel.Checked = True
        End If

        FrmPGM00003.ShowDialog()
    End Sub


    Private Sub display_dgSummary()
        dgSummary.DataSource = rs_PKREQDTL.Tables("RESULT").DefaultView
        dgSummary.AllowUserToResizeColumns = True
        dgSummary.AllowUserToResizeRows = False




        For i As Integer = 0 To dgSummary.Columns.Count - 1
            dgSummary.Columns(i).Visible = True
            dgSummary.Columns(i).ReadOnly = True
            Select Case LCase(dgSummary.Columns(i).Name)
                Case "prd_seq"
                    dgSum_seq = i
                    dgSummary.Columns(i).HeaderText = "Seq"
                    dgSummary.Columns(i).Width = 40
                    dgSummary.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "prd_itemno"
                    dgSummary.Columns(i).HeaderText = "Itm No."
                    dgSummary.Columns(i).Width = 120
                Case "prd_assitm"
                    dgSummary.Columns(i).HeaderText = "Ass Itm No."
                    dgSummary.Columns(i).Width = 120
                    dgSummary.Columns(i).DisplayIndex = 4
                Case "prd_tmpitmno"
                    dgSummary.Columns(i).HeaderText = "Tmp Itm No."
                    dgSummary.Columns(i).Width = 120
                Case "prd_venno"
                    dgSummary.Columns(i).HeaderText = "DV"
                    dgSummary.Columns(i).Width = 40
                Case "prd_venitm"
                    dgSummary.Columns(i).HeaderText = "Vend Itm No."
                    dgSummary.Columns(i).Width = 80
                Case "prd_pckunt"
                    dgSummary.Columns(i).HeaderText = "UM"
                    dgSummary.Columns(i).Width = 40
                Case "prd_inrqty"
                    dgSummary.Columns(i).HeaderText = "Inr"
                    dgSummary.Columns(i).Width = 30
                    dgSummary.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "prd_mtrqty"
                    dgSummary.Columns(i).HeaderText = "Mtr"
                    dgSummary.Columns(i).Width = 30
                    dgSummary.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "prd_cft"
                    dgSummary.Columns(i).HeaderText = "CFT"
                    dgSummary.Columns(i).Width = 50
                    dgSummary.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "prd_ftyprctrm"
                    dgSummary.Columns(i).HeaderText = "Fty Prc Trm"
                    dgSummary.Columns(i).Width = 80
                Case "prd_hkprctrm"
                    dgSummary.Columns(i).HeaderText = "HK Prc Trm"
                    dgSummary.Columns(i).Width = 80
                Case "prd_trantrm"
                    dgSummary.Columns(i).HeaderText = "Tran Trm"
                    dgSummary.Columns(i).Width = 60
                Case "prd_pkgitm"
                    dgSummary.Columns(i).HeaderText = "Pkg Itm"
                    dgSummary.Columns(i).Width = 100
                Case "prd_pkgven"
                    dgSum_pkgven = i
                    dgSummary.Columns(i).HeaderText = "Pkg Ven"
                    dgSummary.Columns(i).Width = 180

                Case "prd_cate"
                    dgSummary.Columns(i).HeaderText = "Category"
                    dgSummary.Columns(i).Width = 120
                Case "prd_chndsc"
                    dgSummary.Columns(i).HeaderText = "Chin Desc"
                    dgSummary.Columns(i).Width = 150
                Case "prd_engdsc"
                    dgSummary.Columns(i).HeaderText = "Eng Desc"
                    dgSummary.Columns(i).Width = 150
                Case "prd_remark"
                    dgSummary.Columns(i).HeaderText = "Remark"
                    dgSummary.Columns(i).Width = 150
                Case "prd_einchl"
                    dgSummary.Columns(i).HeaderText = "Exp L (in)"
                    dgSummary.Columns(i).Width = 80
                    dgSummary.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "prd_einchw"
                    dgSummary.Columns(i).HeaderText = "Exp W (in)"
                    dgSummary.Columns(i).Width = 80
                    dgSummary.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "prd_einchh"
                    dgSummary.Columns(i).HeaderText = "Exp H (in)"
                    dgSummary.Columns(i).Width = 80
                    dgSummary.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "prd_ecml"
                    dgSummary.Columns(i).HeaderText = "Exp L (cm)"
                    dgSummary.Columns(i).Width = 80
                    dgSummary.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "prd_ecmw"
                    dgSummary.Columns(i).HeaderText = "Exp W (cm)"
                    dgSummary.Columns(i).Width = 80
                    dgSummary.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "prd_ecmh"
                    dgSummary.Columns(i).HeaderText = "Exp H (cm)"
                    dgSummary.Columns(i).Width = 80
                    dgSummary.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "prd_finchl"
                    dgSummary.Columns(i).HeaderText = "Fld L (in)"
                    dgSummary.Columns(i).Width = 80
                    dgSummary.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "prd_finchw"
                    dgSummary.Columns(i).HeaderText = "Fld W (in)"
                    dgSummary.Columns(i).Width = 80
                    dgSummary.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "prd_finchh"
                    dgSummary.Columns(i).HeaderText = "Fld H (in)"
                    dgSummary.Columns(i).Width = 80
                    dgSummary.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "prd_fcml"
                    dgSummary.Columns(i).HeaderText = "Fld L (cm)"
                    dgSummary.Columns(i).Width = 80
                    dgSummary.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "prd_fcmw"
                    dgSummary.Columns(i).HeaderText = "Fld W (cm)"
                    dgSummary.Columns(i).Width = 80
                    dgSummary.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "prd_fcmh"
                    dgSummary.Columns(i).HeaderText = "Fld H (cm)"
                    dgSummary.Columns(i).Width = 80
                    dgSummary.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "prd_matral"
                    dgSummary.Columns(i).HeaderText = "Material"
                    dgSummary.Columns(i).Width = 80
                Case "prd_tiknes"
                    dgSummary.Columns(i).HeaderText = "Thickness"
                    dgSummary.Columns(i).Width = 80
                Case "prd_prtmtd"
                    dgSummary.Columns(i).HeaderText = "Print Method"
                    dgSummary.Columns(i).Width = 80
                Case "prd_clrfot"
                    dgSummary.Columns(i).HeaderText = "Col (Front)"
                    dgSummary.Columns(i).Width = 80
                Case "prd_clrbck"
                    dgSummary.Columns(i).HeaderText = "Col (Back)"
                    dgSummary.Columns(i).Width = 80
                Case "prd_finish"
                    dgSummary.Columns(i).HeaderText = "Finishing"
                    dgSummary.Columns(i).Width = 80
                Case "prd_finfot"
                    dgSummary.Columns(i).HeaderText = "Finishing (Front)"
                    dgSummary.Columns(i).Width = 110
                Case "prd_finbck"
                    dgSummary.Columns(i).HeaderText = "Finishing (Back)"
                    dgSummary.Columns(i).Width = 110
                Case "prd_sctoqty"
                    dgSummary.Columns(i).HeaderText = "SC/TO Qty"
                    dgSummary.Columns(i).Width = 80
                    dgSummary.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "prd_qtyum"
                    dgSummary.Columns(i).HeaderText = "Qty UM"
                    dgSummary.Columns(i).Width = 50
                Case "prd_curcde"
                    dgSummary.Columns(i).HeaderText = "CCY"
                    dgSummary.Columns(i).Width = 50
                Case "prd_ordqty"
                    dgSum_ordqty = i
                    dgSummary.Columns(i).HeaderText = "Ord Qty"
                    dgSummary.Columns(i).Width = 60
                    dgSummary.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    If mode = "UPDATE" Or mode = "ADD" Then
                        dgSummary.Columns(i).ReadOnly = False
                    End If



                Case "prd_wasper"
                    dgSummary.Columns(i).HeaderText = "Waste %"
                    dgSummary.Columns(i).Width = 70
                    dgSummary.Columns(i).Visible = False
                Case "prd_wasqty"
                    dgSummary.Columns(i).HeaderText = "Waste Qty"
                    dgSummary.Columns(i).Width = 70
                    dgSummary.Columns(i).Visible = False
                    dgSummary.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "prd_bonqty"
                    dgSum_bonqty = i
                    dgSummary.Columns(i).HeaderText = "Was Qty"
                    dgSummary.Columns(i).Width = 60
                    dgSummary.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    If mode = "UPDATE" Or mode = "ADD" Then
                        dgSummary.Columns(i).ReadOnly = False
                    End If
                Case "prd_ttlordqty"
                    dgSummary.Columns(i).HeaderText = "Ttl Ord Qty"
                    dgSummary.Columns(i).Width = 65
                    dgSummary.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgSum_ttlqty = i
                Case "prd_untprc"
                    dgSum_UnitPrc = i
                    dgSummary.Columns(i).HeaderText = "Unit Prc"
                    dgSummary.Columns(i).Width = 65
                    dgSummary.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    If mode = "UPDATE" Or mode = "ADD" Then
                        dgSummary.Columns(i).ReadOnly = False
                    End If
                Case "prd_ttlamtqty"
                    dgSummary.Columns(i).HeaderText = "Ttl Amt"
                    dgSummary.Columns(i).Width = 65
                    dgSum_ttlAmt = i
                    dgSummary.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "prd_creusr"
                    dgSummary.Columns(i).Visible = False
                    dgSum_creusr = i
                Case Else
                    dgSummary.Columns(i).Visible = False
            End Select
        Next

        ' dgSummary.ClearSelection()
    End Sub

    Private Sub txtPkgUnitPri_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPkgUnitPri.TextChanged



        If flag_panpack_keypress = True Then
            flag_panpack_keypress = False

            If IsNumeric(txtPkgUnitPri.Text) = False Then
                Exit Sub
            End If


            calTotalAMT()
        End If
    End Sub
    Private Sub mmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdSearch.Click

        Dim frmSYM00018 As New SYM00018

        frmSYM00018.keyName = txtReqno.Name
        frmSYM00018.strModule = "PR"

        frmSYM00018.show_frmSYM00018(Me)
    End Sub


    Private Sub dgSummary_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSummary.CellClick
        If mode = "ReadOnly" Then
            Exit Sub
        End If






        Select Case dgSummary.CurrentCell.ColumnIndex

            Case dgSum_pkgven
                'comboBoxCell(dgSummary, "VN")


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
            Case "VN"

                For i = 0 To rs_VNBASINF.Tables("RESULT").Rows.Count - 1
                    cboCell.Items.Add(rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_venno") & " - " & rs_VNBASINF.Tables("RESULT").Rows(i).Item("vbi_vensna"))
                Next i
            Case "Curr"

                cboCell.Items.Clear()
                cboCell.Items.Add("HKD")
                cboCell.Items.Add("USD")
                cboCell.Items.Add("RMB")

        End Select

        'cboCell.DropDownWidth = 150
        cboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox

        dgv.Rows(iRow).Cells(iCol) = cboCell
        dgv.Rows(iRow).Cells(iCol).ReadOnly = False

    End Sub

    Private Sub dgSummary_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSummary.CellEndEdit
        If mode = "UPDATE" Then
            recordstatus = True

            If dgSummary.Item(dgSum_creusr, e.RowIndex).Value <> "~*ADD*~" Then
                dgSummary.Item(dgSum_creusr, e.RowIndex).Value = "~*UPD*~"
            End If

        End If


        Select Case dgSummary.CurrentCell.ColumnIndex
            Case dgSum_UnitPrc
                Dim reqseq As Integer

                reqseq = dgSummary.Item(dgSum_seq, e.RowIndex).Value

                If rs_PKESDTL.Tables("RESULT").Rows.Count <> 0 Then
                    For i As Integer = 0 To rs_PKESDTL.Tables("RESULT").Rows.Count - 1
                        If rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_reqseq") = reqseq Then
                            rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_price") = dgSummary.Item(dgSum_UnitPrc, e.RowIndex).Value
                            If rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_creusr") <> "~*ADD*~" Then
                                rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_creusr") = "~*UPD*~"
                            End If

                        End If
                    Next
                End If




        End Select

        Try
            Dim txtCell As New DataGridViewTextBoxCell
            Select Case dgSummary.CurrentCell.ColumnIndex

                Case dgSum_pkgven
                    'dgTODtl.Item(dgTODtl_tod_dsgven, dgTODtl.CurrentCell.RowIndex).Value = Split(dgTODtl.Item(dgTODtl_tod_dsgven, dgTODtl.CurrentCell.RowIndex).Value, " - ")(0)
                    dgSummary.Item(dgSum_pkgven, dgSummary.CurrentCell.RowIndex) = txtCell



            End Select
        Catch
        End Try





    End Sub

    Private Sub dgSummary_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSummary.CellValidated


        Dim row As DataGridViewRow = dgSummary.CurrentRow
        If row.Cells(e.ColumnIndex).IsInEditMode Then
            Select Case e.ColumnIndex

                Case dgSum_UnitPrc, dgSum_ordqty, dgSum_bonqty

                    If dgSummary("prd_ordno", dgSummary.CurrentCell.RowIndex).Value.ToString.Trim <> "" Then
                        Exit Sub
                    End If

                    If e.ColumnIndex = dgSum_ordqty Then
                        Dim cate As String = Split(dgSummary("prd_cate", dgSummary.CurrentCell.RowIndex).Value, " - ")(0)
                        Dim tmpordqty As Integer = dgSummary(dgSum_ordqty, dgSummary.CurrentCell.RowIndex).Value

                        Dim dr() As DataRow
                        dr = rs_syswasge.Tables("RESULT").Select("pwa_code = '" & cate & "' and pwa_qtyfrm <= " & tmpordqty & " and pwa_qtyto >= " & tmpordqty)

                        If dr.Length <> 0 Then
                            If dr(0)("pwa_um") = "%" Then

                                dgSummary("prd_wasper", dgSummary.CurrentCell.RowIndex).Value = Fix(dr(0).Item("pwa_wasage"))
                                'txtWasQty.Text = Math.Round(sumqty * dr(0).Item("pwa_wasage") / 100)
                                ' txtStandWasage.Text = Math.Round(sumqty * dr(0).Item("pwa_wasage") / 100)
                                dgSummary("prd_wasqty", dgSummary.CurrentCell.RowIndex).Value = Math.Round(tmpordqty * dr(0).Item("pwa_wasage") / 100, 0, MidpointRounding.AwayFromZero)
                                dgSummary("prd_bonqty", dgSummary.CurrentCell.RowIndex).Value = Math.Round(tmpordqty * dr(0).Item("pwa_wasage") / 100, 0, MidpointRounding.AwayFromZero)
                            Else
                                dgSummary("prd_wasper", dgSummary.CurrentCell.RowIndex).Value = 0
                                'txtWasQty.Text = Fix(dr(0).Item("pwa_wasage"))
                                dgSummary("prd_wasqty", dgSummary.CurrentCell.RowIndex).Value = Fix(dr(0).Item("pwa_wasage"))
                                dgSummary("prd_bonqty", dgSummary.CurrentCell.RowIndex).Value = Fix(dr(0).Item("pwa_wasage"))
                            End If

                        End If
                    End If


                    Dim ordqty As Integer
                    Dim unitprice As Decimal
                    Dim ttlordqty As Integer
                    Dim ttlamt As Decimal
                    Dim bonqty As Integer

                    ordqty = dgSummary(dgSum_ordqty, dgSummary.CurrentCell.RowIndex).Value
                    unitprice = round(dgSummary(dgSum_UnitPrc, dgSummary.CurrentCell.RowIndex).Value, 5)
                    bonqty = dgSummary(dgSum_bonqty, dgSummary.CurrentCell.RowIndex).Value

                    ttlordqty = ordqty + bonqty
                    ttlamt = round(ttlordqty * unitprice, 2)

                    dgSummary(dgSum_ttlqty, dgSummary.CurrentCell.RowIndex).Value = ttlordqty
                    dgSummary(dgSum_ttlAmt, dgSummary.CurrentCell.RowIndex).Value = ttlamt

            End Select
        End If

    End Sub

    Private Sub dgSummary_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgSummary.CellValidating
        Dim row As DataGridViewRow = dgSummary.CurrentRow
        Dim strNewVal As String

        strNewVal = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim

        If row.Cells(e.ColumnIndex).IsInEditMode Then
            Select Case e.ColumnIndex


                Case dgSum_UnitPrc
                    If Not IsNumeric(strNewVal) Then
                        MsgBox("Please input integer value!")
                        e.Cancel = True
                        Exit Sub
                    End If


                    Dim realitem As String
                    Dim assitem As String
                    Dim tmpitem As String
                    Dim venno As String
                    Dim venitem As String
                    Dim PkgItem As String
                    Dim colcde As String
                    Dim unitprice As Decimal
                    Dim seq As Integer

                    realitem = dgSummary.Item("prd_itemno", e.RowIndex).Value
                    assitem = dgSummary.Item("prd_assitm", e.RowIndex).Value
                    tmpitem = dgSummary.Item("prd_tmpitmno", e.RowIndex).Value
                    venno = dgSummary.Item("prd_venno", e.RowIndex).Value
                    venitem = dgSummary.Item("prd_venitm", e.RowIndex).Value
                    PkgItem = dgSummary.Item("prd_pkgitm", e.RowIndex).Value
                    colcde = dgSummary.Item("prd_colcde", e.RowIndex).Value
                    unitprice = strNewVal
                    seq = dgSummary.Item("prd_seq", e.RowIndex).Value

                    Dim dr() As DataRow

                    dr = rs_PKREQDTL.Tables("RESULT").Select("prd_itemno = '" & realitem & "' and " & _
                                                              "prd_assitm = '" & assitem & "' and " & _
                                                      "prd_tmpitmno = '" & tmpitem & "' and " & _
                                                       "prd_venno = '" & venno & "' and " & _
                                                       "prd_venitm = '" & venitem & "' and " & _
                                                       "prd_pkgitm = '" & PkgItem & "' and " & _
                                                       "prd_colcde = '" & colcde & "' and " & _
                                                       "prd_untprc = " & unitprice)

                    If dr.Length <> 0 Then
                        Dim fail As Boolean
                        For i As Integer = 0 To dr.Length - 1
                            If dr(i).Item("prd_seq") <> seq Then
                                fail = True
                                Exit For
                            End If
                        Next

                        If fail = True Then
                            MsgBox("Duplicate Packaging Item with Unit Price for the Product Item.")
                            e.Cancel = True
                            Exit Sub
                        End If


                    End If






                Case dgSum_ordqty
                    If Not IsNumeric(strNewVal) Then
                        MsgBox("Please input integer value!")
                        e.Cancel = True
                        Exit Sub
                    End If

                    If strNewVal.ToString.Contains(".") = True Then
                        MsgBox("Please input integer value!")
                        e.Cancel = True
                        Exit Sub
                    End If

                Case dgSum_bonqty
                    If Not IsNumeric(strNewVal) Then
                        MsgBox("Please input integer value!")
                        e.Cancel = True
                        Exit Sub
                    End If

                    If strNewVal.ToString.Contains(".") = True Then
                        MsgBox("Please input integer value!")
                        e.Cancel = True
                        Exit Sub
                    End If

            End Select
        End If
    End Sub

    Private Sub dgSummary_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgSummary.EditingControlShowing

        Dim txtbox As TextBox = CType(e.Control, TextBox)
        If Not (txtbox Is Nothing) Then
            Select Case dgSummary.CurrentCell.ColumnIndex
                'Case dgSum_pkgven
                '    If TypeOf (e.Control) Is DataGridViewComboBoxEditingControl Then
                '        Dim cboBox As ComboBox = CType(e.Control, ComboBox)
                '        If Not cboBox Is Nothing Then
                '            'RemoveHandler cboBox.SelectedIndexChanged, AddressOf cbopckunt_dgPacking_SelectedIndexChanged
                '            'AddHandler cboBox.SelectedIndexChanged, AddressOf cbopckunt_dgPacking_SelectedIndexChanged
                '        End If
                '    End If
                Case dgSum_ordqty, dgSum_UnitPrc
                    RemoveHandler txtbox.KeyPress, AddressOf txt_Check
                    AddHandler txtbox.KeyPress, AddressOf txt_Check
                    e.CellStyle.BackColor = Color.White

            End Select
        End If
    End Sub


    Private Sub txt_Check(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If dgSummary.Item("prd_ordno", dgSummary.CurrentCell.RowIndex).Value <> "" Then
            e.KeyChar = Chr(0)


        End If

    End Sub




    Private Sub cboPkgVendor_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPkgVendor.Validated
        If Trim(cboPkgVendor.Text) = "" Then
            Exit Sub
        End If

        If checkValidCombo(cboPkgVendor, cboPkgVendor.Text) = False Then
            MsgBox("Data Invalid")
            cboPkgVendor.Text = ""
            Exit Sub
        End If



        For i As Integer = 0 To rs_PKESDTL.Tables("RESULT").Rows.Count - 1
            If rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_reqseq") = txtSeq.Text Then
                rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_curcde") = txtPkgUnitPriCur.Text

                If rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_creusr") <> "~*ADD*~" Then
                    rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_creusr") = "~*UPD*~"
                End If

            End If
        Next



        update_PKREQDTL()
    End Sub


    Private Sub txtQuotePrice_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQuotePrice.KeyPress

        If Not ((Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 46 Or Asc(e.KeyChar) = 13) Then
            e.KeyChar = Chr(0)
            MsgBox("Please input integer value.")
        End If

        If txtPkgUnitPri.Text.Contains(".") = True Then
            If Asc(e.KeyChar) = 46 Then
                e.KeyChar = Chr(0)
                MsgBox("Please input integer value.")
            End If
        End If



        recordstatus = True
        flag_panpack_keypress = True
        SetAsUpdate(txtSeq.Text)
    End Sub


    Private Sub txtQuotePrice_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQuotePrice.Validated
        Dim quotepri As Decimal = txtQuotePrice.Text
        txtQuotePrice.Text = quotepri
        update_PKREQDTL()
    End Sub

    Private Sub txtQuotePrice_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtQuotePrice.Validating

        If txtQuotePrice.Text = "" Then
            txtQuotePrice.Text = 0
            Exit Sub
        End If

        If IsNumeric(txtQuotePrice.Text) = False Then

            MsgBox("Please input valid integer")

            txtQuotePrice.Focus()
            e.Cancel = True
            Exit Sub
        End If


        If txtQuotePrice.Text.Contains("..") Then
            MsgBox("Please input valid integer")

            txtQuotePrice.Focus()
            e.Cancel = True
            Exit Sub
        End If
    End Sub


    Private Sub cmdIMG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIMG.Click

        Dim path As String
        gspStr = "sp_select_PKIMBAIF '" & txtPkgItem.Text & "'"
        rtnLong = execute_SQLStatement(gspStr, rs_PKIMBAIF, rtnStr)
        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdIMG_Click sp_select_PKIMBAIF :" & rtnStr)
            Exit Sub
        End If

        If rs_PKIMBAIF.Tables("RESULT").Rows.Count <> 0 Then
            path = rs_PKIMBAIF.Tables("RESULT").Rows(0).Item("pib_img")
        Else
            MsgBox("Packaging Item Not Found.")
            Exit Sub
        End If


        If Trim(path.ToString) = "" Then
            Exit Sub
        End If

        Try
            frmImage.pbImage.Load(path)
        Catch ex As Exception

        End Try

        frmImage.ShowDialog()
    End Sub



    Private Sub SetdgPKESHDR()
        If rs_PKESHDR.Tables.Count = 0 Then
            Exit Sub
        End If


        dgPKESHDR.DataSource = rs_PKESHDR.Tables("RESULT").DefaultView


        dgPKESHDR.RowHeadersWidth = 18
        dgPKESHDR.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgPKESHDR.ColumnHeadersHeight = 18
        dgPKESHDR.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgPKESHDR.AllowUserToResizeColumns = True
        dgPKESHDR.AllowUserToResizeRows = False
        dgPKESHDR.RowTemplate.Height = 18


        Dim i As Integer

        'If mode = "UPDATE" Or mode = "ADD" Then
        For i = 0 To rs_PKESHDR.Tables("RESULT").Columns.Count - 1
            rs_PKESHDR.Tables("RESULT").Columns(i).ReadOnly = False
        Next i
        'End If
        i = 0
        dgPKESHDR.Columns(i).Visible = False
        i = i + 1
        dgPKESHDR.Columns(i).Visible = False
        i = i + 1
        dgPKESHDR.Columns(i).HeaderText = "Itm No."
        dgPKESHDR.Columns(i).Width = 110
        dgPKESHDR.Columns(i).ReadOnly = True
        i = i + 1
        dgPKESHDR.Columns(i).HeaderText = "Ass Itm No."
        dgPKESHDR.Columns(i).Width = 85
        dgPKESHDR.Columns(i).ReadOnly = True
        i = i + 1
        dgPKESHDR.Columns(i).HeaderText = "Tmp Itm No."
        dgPKESHDR.Columns(i).Width = 80
        dgPKESHDR.Columns(i).ReadOnly = True
        i = i + 1
        dgPKESHDR.Columns(i).HeaderText = "PV"
        dgPKESHDR.Columns(i).Width = 70
        dgPKESHDR.Columns(i).ReadOnly = True
        i = i + 1
        dgPKESHDR.Columns(i).HeaderText = "Ven Itm No."
        dgPKESHDR.Columns(i).Width = 80
        dgPKESHDR.Columns(i).ReadOnly = True
        i = i + 1
        dgPKESHDR.Columns(i).HeaderText = "Color"
        dgPKESHDR.Columns(i).Width = 65
        dgPKESHDR.Columns(i).ReadOnly = True
        i = i + 1
        dgPKESHDR.Columns(i).HeaderText = "Price"
        dgPKESHDR.Columns(i).Width = 55
        If mode = "UPDATE" Or mode = "ADD" Then
            dgPKESHDR.Columns(i).ReadOnly = False
        End If
        dgPKESHDR.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        i = i + 1
        dgPKESHDR.Columns(i).HeaderText = "Curr"
        dgPKESHDR.Columns(i).Width = 50
        dgPKESHDR.Columns(i).ReadOnly = True


        i = i + 1
        dgPKESHDR.Columns(i).Visible = False
        i = i + 1
        dgPKESHDR.Columns(i).Visible = False
        i = i + 1
        dgPKESHDR.Columns(i).Visible = False
        i = i + 1
        dgPKESHDR.Columns(i).Visible = False
        i = i + 1
        dgPKESHDR.Columns(i).HeaderText = "Est"
        dgPKESHDR.Columns(i).Width = 40
        dgPKESHDR.Columns(i).ReadOnly = True

        Dim ii As Integer

        For ii = 0 To dgPKESHDR.Columns.Count - 1

            dgPKESHDR.Columns(ii).SortMode = DataGridViewColumnSortMode.NotSortable

        Next ii


    End Sub

    Private Sub SetdgPKESDTL(ByVal value As String)
        If rs_PKESDTL.Tables.Count = 0 Then
            Exit Sub
        End If

        rs_PKESDTL.Tables("RESULT").DefaultView.RowFilter = value


        dgPKESDTL.DataSource = rs_PKESDTL.Tables("RESULT").DefaultView


        dgPKESDTL.RowHeadersWidth = 18
        dgPKESDTL.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        dgPKESDTL.ColumnHeadersHeight = 18
        dgPKESDTL.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgPKESDTL.AllowUserToResizeColumns = True
        dgPKESDTL.AllowUserToResizeRows = False
        dgPKESDTL.RowTemplate.Height = 18


        Dim i As Integer

        'If mode = "UPDATE" Or mode = "ADD" Then
        For i = 0 To rs_PKESDTL.Tables("RESULT").Columns.Count - 1
            rs_PKESDTL.Tables("RESULT").Columns(i).ReadOnly = False
        Next i
        'End If
        i = 0
        dgPKESDTL.Columns(i).Visible = False
        i = i + 1
        dgPKESDTL.Columns(i).Visible = False
        i = i + 1
        dgPKESDTL.Columns(i).Visible = False
        i = i + 1
        dgPKESDTL.Columns(i).HeaderText = "Seq"
        dgPKESDTL.Columns(i).Width = 40
        dgPKESDTL.Columns(i).ReadOnly = True
        i = i + 1
        dgPKESDTL.Columns(i).Visible = False
        i = i + 1
        dgPKESDTL.Columns(i).Visible = False
        i = i + 1
        dgPKESDTL.Columns(i).Visible = False
        i = i + 1
        dgPKESDTL.Columns(i).Visible = False
        i = i + 1
        dgPKESDTL.Columns(i).Visible = False
        i = i + 1
        dgPKESDTL.Columns(i).Visible = False
        i = i + 1
        dgPKESDTL.Columns(i).HeaderText = "Pkg. Itm"
        dgPKESDTL.Columns(i).Width = 100
        dgPKESDTL.Columns(i).ReadOnly = True
        i = i + 1
        dgPKESDTL.Columns(i).HeaderText = "Price"
        dgPKESDTL.Columns(i).Width = 70
        dgPKESDTL.Columns(i).ReadOnly = True
        'If mode = "UPDATE" Or mode = "ADD" Then
        '    dgPKESDTL.Columns(i).ReadOnly = False
        'End If
        i = i + 1
        dgPKESDTL.Columns(i).HeaderText = "Curr"
        dgPKESDTL.Columns(i).Width = 50
        dgPKESDTL.Columns(i).ReadOnly = True
        i = i + 1
        dgPKESDTL.Columns(i).Visible = False
        i = i + 1
        dgPKESDTL.Columns(i).Visible = False
        i = i + 1
        dgPKESDTL.Columns(i).Visible = False
        i = i + 1
        dgPKESDTL.Columns(i).Visible = False

        Dim ii As Integer

        For ii = 0 To dgPKESDTL.Columns.Count - 1

            dgPKESDTL.Columns(ii).SortMode = DataGridViewColumnSortMode.NotSortable

        Next ii


    End Sub

    Private Sub dgPKESHDR_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPKESHDR.CellClick
        Dim ped_itemno As String
        Dim ped_assitm As String
        Dim ped_tmpitmno As String
        Dim ped_venno As String
        Dim ped_venitm As String
        Dim ped_colcde As String

        ped_itemno = dgPKESHDR.Item(2, dgPKESHDR.CurrentCell.RowIndex).Value
        ped_assitm = dgPKESHDR.Item(3, dgPKESHDR.CurrentCell.RowIndex).Value
        ped_tmpitmno = dgPKESHDR.Item(4, dgPKESHDR.CurrentCell.RowIndex).Value
        ped_venno = dgPKESHDR.Item(5, dgPKESHDR.CurrentCell.RowIndex).Value
        ped_venitm = dgPKESHDR.Item(6, dgPKESHDR.CurrentCell.RowIndex).Value
        ped_colcde = dgPKESHDR.Item(7, dgPKESHDR.CurrentCell.RowIndex).Value

        SetdgPKESDTL("ped_itemno = '" & ped_itemno & "'" & _
                     "and ped_assitm = '" & ped_assitm & "'" & _
                     "and ped_tmpitmno = '" & ped_tmpitmno & "'" & _
                     "and ped_venno = '" & ped_venno & "'" & _
                    "and ped_venitm = '" & ped_venitm & "'" & _
                    "and ped_colcde = '" & ped_colcde & "'")



        If mode = "ReadOnly" Then
            Exit Sub
        End If

        Select Case dgPKESHDR.CurrentCell.ColumnIndex

            Case 9

                comboBoxCell(dgPKESHDR, "Curr")


        End Select



    End Sub

    Private Function save_PKESHDR() As Boolean

        If rs_PKESHDR.Tables("RESULT").Rows.Count = 0 Then
            Return True
            Exit Function
        End If

        For i As Integer = 0 To rs_PKESHDR.Tables("RESULT").Rows.Count - 1
            Dim peh_cocde As String
            Dim peh_reqno As String
            Dim peh_itemno As String
            Dim peh_assitm As String
            Dim peh_tmpitmno As String
            Dim peh_venno As String
            Dim peh_venitm As String
            Dim peh_colcde As String
            Dim peh_price As Decimal
            Dim peh_curcde As String
            Dim peh_creusr As String

            peh_cocde = cbococde.Text
            peh_reqno = txtReqno.Text '
            peh_itemno = rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_itemno").ToString
            peh_assitm = rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_assitm").ToString
            peh_tmpitmno = rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_tmpitmno").ToString
            peh_venno = rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_venno").ToString
            peh_venitm = rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_venitm").ToString
            peh_colcde = rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_colcde").ToString
            peh_price = rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_price")
            peh_curcde = rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_curcde")
            peh_creusr = rs_PKESHDR.Tables("RESULT").Rows(i).Item("peh_creusr").ToString


            If peh_creusr = "~*ADD*~" Then
                gspStr = "sp_insert_PKESHDR '" & peh_cocde & "','" & peh_reqno & "','" & peh_itemno & "','" & peh_assitm & "','" & peh_tmpitmno & "','" & _
                                                peh_venno & "','" & peh_venitm & "','" & peh_colcde & "'," & peh_price & ",'" & peh_curcde & "','" & gsUsrID & "'"



                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_PKESHDR sp_insert_PKESHDR :" & rtnStr)
                    save_PKESHDR = False
                    Exit Function
                End If

            ElseIf peh_creusr = "~*UPD*~" Then

                gspStr = "sp_update_PKESHDR '" & peh_cocde & "','" & peh_reqno & "','" & peh_itemno & "','" & peh_assitm & "','" & peh_tmpitmno & "','" & _
                                                peh_venno & "','" & peh_venitm & "','" & peh_colcde & "'," & peh_price & ",'" & peh_curcde & "','" & gsUsrID & "'"


                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_PKESHDR sp_update_PKESHDR :" & rtnStr)
                    save_PKESHDR = False
                    Exit Function
                End If

            ElseIf peh_creusr = "~*DEL*~" Then

                gspStr = "sp_physical_delete_PKESHDR '" & peh_cocde & "','" & peh_reqno & "','" & peh_itemno & "','" & peh_assitm & "','" & peh_tmpitmno & "','" & _
                                               peh_venno & "','" & peh_venitm & "','" & peh_colcde & "'"


                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_PKESHDR sp_physical_delete_PKESHDR :" & rtnStr)
                    save_PKESHDR = False
                    Exit Function
                End If

            End If
        Next

        save_PKESHDR = True

    End Function


    Private Function save_PKESDTL() As Boolean

        If rs_PKESDTL.Tables("RESULT").Rows.Count = 0 Then
            Return True
            Exit Function
        End If

        For i As Integer = 0 To rs_PKESDTL.Tables("RESULT").Rows.Count - 1
            Dim ped_cocde As String
            Dim ped_reqno As String
            Dim ped_reqseq As Integer
            Dim ped_seq As Integer
            Dim ped_itemno As String
            Dim ped_assitm As String
            Dim ped_tmpitmno As String
            Dim ped_venno As String
            Dim ped_venitm As String
            Dim ped_colcde As String
            Dim ped_pkgitem As String
            Dim ped_price As Decimal
            Dim ped_curcde As String
            Dim ped_creusr As String

            ped_cocde = cbococde.Text
            ped_reqno = txtReqno.Text '
            ped_reqseq = rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_reqseq")
            ped_seq = rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_seq")
            ped_itemno = rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_itemno").ToString
            ped_assitm = rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_assitm").ToString
            ped_tmpitmno = rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_tmpitmno").ToString
            ped_venno = rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_venno").ToString
            ped_venitm = rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_venitm").ToString
            ped_colcde = rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_colcde").ToString
            ped_pkgitem = rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_pkgitem").ToString
            ped_price = round(rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_price"), 5)
            ped_curcde = rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_curcde")
            ped_creusr = rs_PKESDTL.Tables("RESULT").Rows(i).Item("ped_creusr").ToString


            If ped_creusr = "~*ADD*~" Then
                gspStr = "sp_insert_PKESDTL '" & ped_cocde & "','" & ped_reqno & "'," & ped_reqseq & "," & ped_seq & ",'" & ped_itemno & "','" & _
                ped_assitm & "','" & ped_tmpitmno & "','" & ped_venno & "','" & ped_venitm & "','" & ped_colcde & "','" & ped_pkgitem & "'," & ped_price & ",'" & ped_curcde & "','" & gsUsrID & "'"



                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_PKESDTL sp_insert_PKESHDR :" & rtnStr)
                    save_PKESDTL = False
                    Exit Function
                End If

            ElseIf ped_creusr = "~*UPD*~" Then

                gspStr = "sp_update_PKESDTL '" & ped_cocde & "','" & ped_reqno & "'," & ped_reqseq & "," & ped_seq & ",'" & ped_itemno & "','" & _
                ped_assitm & "','" & ped_tmpitmno & "','" & ped_venno & "','" & ped_venitm & "','" & ped_colcde & "','" & ped_pkgitem & "'," & ped_price & ",'" & ped_curcde & "','" & gsUsrID & "'"


                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_PKESDTL sp_update_PKESHDR :" & rtnStr)
                    save_PKESDTL = False
                    Exit Function
                End If

            ElseIf ped_creusr = "~*DEL*~" Then

                gspStr = "sp_physical_delete_PKESDTL '" & ped_cocde & "','" & ped_reqno & "'," & ped_reqseq


                rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)
                If rtnLong <> RC_SUCCESS Then
                    MsgBox("Error on loading save_PKESDTL sp_physical_delete_PKESDTL :" & rtnStr)
                    save_PKESDTL = False
                    Exit Function
                End If

            End If
        Next

        save_PKESDTL = True

    End Function

    Private Sub dgPKESHDR_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPKESHDR.CellEndEdit
        If mode = "UPDATE" Then
            recordstatus = True

            If dgPKESHDR.Item(10, e.RowIndex).Value <> "~*ADD*~" And _
            dgPKESHDR.Item(10, e.RowIndex).Value <> "~*NEW*~" And _
             dgPKESHDR.Item(10, e.RowIndex).Value <> "~*DEL*~" Then
                dgPKESHDR.Item(10, e.RowIndex).Value = "~*UPD*~"
            End If

        End If

        Try
            Dim txtCell As New DataGridViewTextBoxCell
            Select Case dgPKESHDR.CurrentCell.ColumnIndex

                Case 9
                    'dgTODtl.Item(dgTODtl_tod_dsgven, dgTODtl.CurrentCell.RowIndex).Value = Split(dgTODtl.Item(dgTODtl_tod_dsgven, dgTODtl.CurrentCell.RowIndex).Value, " - ")(0)
                    dgPKESHDR.Item(9, dgPKESHDR.CurrentCell.RowIndex) = txtCell



            End Select
        Catch
        End Try







    End Sub

    Private Sub dgPKESDTL_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPKESDTL.CellContentClick

    End Sub

    Private Sub dgPKESDTL_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPKESDTL.CellEndEdit
        If mode = "UPDATE" Then
            recordstatus = True

            If dgPKESDTL.Item(13, e.RowIndex).Value <> "~*ADD*~" And _
            dgPKESDTL.Item(13, e.RowIndex).Value <> "~*NEW*~" And _
            dgPKESDTL.Item(13, e.RowIndex).Value <> "~*DEL*~" Then
                dgPKESDTL.Item(13, e.RowIndex).Value = "~*UPD*~"
            End If

        End If
    End Sub

    Private Sub dgPKESHDR_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgPKESHDR.CellValidating
        Dim row As DataGridViewRow = dgPKESHDR.CurrentRow
        Dim strNewVal As String

        strNewVal = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim

        If row.Cells(e.ColumnIndex).IsInEditMode Then
            Select Case e.ColumnIndex

                Case 8
                    If Not IsNumeric(strNewVal) Then
                        MsgBox("Please input integer value!")
                        e.Cancel = True
                        Exit Sub
                    End If



                    'Case dgSum_UnitPrc
                    '    If Not IsNumeric(strNewVal) Then
                    '        MsgBox("Please input integer value!")
                    '        e.Cancel = True
                    '        Exit Sub
                    '    End If

                    'Case dgSum_ordqty
                    '    If Not IsNumeric(strNewVal) Then
                    '        MsgBox("Please input integer value!")
                    '        e.Cancel = True
                    '        Exit Sub
                    '    End If

                    '    If strNewVal.ToString.Contains(".") = True Then
                    '        MsgBox("Please input integer value!")
                    '        e.Cancel = True
                    '        Exit Sub
                    '    End If

            End Select
        End If
    End Sub

    Private Sub dgPKESDTL_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgPKESDTL.CellValidating
        Dim row As DataGridViewRow = dgPKESDTL.CurrentRow
        Dim strNewVal As String

        strNewVal = row.Cells(e.ColumnIndex).EditedFormattedValue.ToString.Trim

        If row.Cells(e.ColumnIndex).IsInEditMode Then
            Select Case e.ColumnIndex

                Case 11
                    If Not IsNumeric(strNewVal) Then
                        MsgBox("Please input integer value!")
                        e.Cancel = True
                        Exit Sub
                    End If



                    'Case dgSum_UnitPrc
                    '    If Not IsNumeric(strNewVal) Then
                    '        MsgBox("Please input integer value!")
                    '        e.Cancel = True
                    '        Exit Sub
                    '    End If

                    'Case dgSum_ordqty
                    '    If Not IsNumeric(strNewVal) Then
                    '        MsgBox("Please input integer value!")
                    '        e.Cancel = True
                    '        Exit Sub
                    '    End If

                    '    If strNewVal.ToString.Contains(".") = True Then
                    '        MsgBox("Please input integer value!")
                    '        e.Cancel = True
                    '        Exit Sub
                    '    End If

            End Select
        End If
    End Sub

    Private Sub cboPkgCtnPer_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPkgCtnPer.GotFocus
        MouseClickCbo = True
    End Sub

    Private Sub cboPkgCtnPer_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPkgCtnPer.KeyUp
        auto_search_combo(cboPkgCtnPer, e.KeyCode)
    End Sub

    Private Sub cboPkgCtnPer_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cboPkgCtnPer.MouseClick
        MouseClickCbo = True
    End Sub

    Private Sub cboPkgCtnPer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPkgCtnPer.SelectedIndexChanged

        Dim dr_tel() As DataRow
        dr_tel = rs_VNCTNPER_09.Tables("RESULT").Select("vci_venno = '" & Split(cboPkgVendor.Text, " - ")(0) & "' and vci_cntctp = '" & cboPkgCtnPer.Text & "'")
        If dr_tel.Length <> 0 Then
            txtTel.Text = dr_tel(0)("vci_cntphn")
        Else
            txtTel.Text = ""
        End If

        If MouseClickCbo = True Then
            MouseClickCbo = False

            SetAsUpdate(txtSeq.Text)
            recordstatus = True
        End If




    End Sub

    Private Sub cboPkgCtnPer_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPkgCtnPer.Validated
        'If Trim(cboPkgCtnPer.Text) = "" Then
        '    Exit Sub
        'End If

        If checkValidCombo(cboPkgCtnPer, cboPkgCtnPer.Text) = False Then
            If Not Trim(cboPkgCtnPer.Text) = "" Then
                MsgBox("Data Invalid")
                cboPkgCtnPer.Text = ""
                Exit Sub
            End If


        End If


        update_PKREQDTL()
    End Sub


    Private Sub dgPKESHDR_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgPKESHDR.EditingControlShowing
        Select Case dgPKESHDR.CurrentCell.ColumnIndex
            Case 9
                If TypeOf (e.Control) Is DataGridViewComboBoxEditingControl Then
                    Dim cboBox As ComboBox = CType(e.Control, ComboBox)
                    If Not cboBox Is Nothing Then
                        'RemoveHandler cboBox.SelectedIndexChanged, AddressOf cbopckunt_dgPacking_SelectedIndexChanged
                        'AddHandler cboBox.SelectedIndexChanged, AddressOf cbopckunt_dgPacking_SelectedIndexChanged
                    End If
                End If

        End Select
    End Sub

    Private Sub dgSCTO_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSCTO.CellContentClick

    End Sub

    Private Sub cmdCancelReq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelReq.Click

        Select Case MsgBox("Are you sure to Cancel?", MsgBoxStyle.YesNo)
            Case MsgBoxResult.Yes
            Case MsgBoxResult.No
                Exit Sub

        End Select


        gspStr = "sp_update_PKREQHDR_CAN '" & cbococde.Text & "','" & txtReqno.Text & "','" & gsUsrID & "'"

        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdCanOrd_Click sp_select_PKORDHDR_cancel :" & rtnStr)
            Exit Sub
        End If

        MsgBox("Record Saved")
        recordstatus = False
        mmdClear_Click(sender, e)





    End Sub

    Private Sub txtCate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCate.TextChanged

    End Sub

    Private Sub txtBonQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBonQty.KeyPress
        If Not ((Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or (Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 13)) Then
            e.KeyChar = Chr(0)
            MsgBox("Please input integer value.")
        End If

        recordstatus = True
        flag_panpack_keypress = True
        SetAsUpdate(txtSeq.Text)

    End Sub

    Private Sub txtBonQty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBonQty.KeyDown
        ' if (e.KeyCode == Keys.Delete)
        If e.KeyValue = Keys.Delete Then
            recordstatus = True
            flag_panpack_keypress = True
            SetAsUpdate(txtSeq.Text)
        End If
    End Sub

    Private Sub txtBonQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBonQty.TextChanged
        If flag_panpack_keypress = True Then
            flag_panpack_keypress = False
            If txtBonQty.Text = "" Then
                txtBonQty.Text = 0
                txtBonQty.SelectAll()
            End If

            If txtBonQty.Text <> txtPkgWast.Text Then
                txtBonQty.ForeColor = Color.Red
            Else
                txtBonQty.ForeColor = Color.Black
            End If



            'Dim cate As String = Split(txtCate.Text, " - ")(0)
            'Dim ordqty As Integer = txtPkgOrdQty.Text

            'Dim dr() As DataRow
            'dr = rs_syswasge.Tables("RESULT").Select("pwa_code = '" & cate & "' and pwa_qtyfrm <= " & ordqty & " and pwa_qtyto >= " & ordqty)

            'If dr.Length <> 0 Then
            '    If dr(0)("pwa_um") = "%" Then

            '        txtPkgWastPer.Text = Fix(dr(0).Item("pwa_wasage"))
            '        'txtWasQty.Text = Math.Round(sumqty * dr(0).Item("pwa_wasage") / 100)
            '        ' txtStandWasage.Text = Math.Round(sumqty * dr(0).Item("pwa_wasage") / 100)
            '        txtPkgWast.Text = Math.Round(ordqty * dr(0).Item("pwa_wasage") / 100, 0, MidpointRounding.AwayFromZero)
            '        txtBonQty.Text = txtPkgWast.Text
            '    Else
            '        txtPkgWastPer.Text = ""
            '        'txtWasQty.Text = Fix(dr(0).Item("pwa_wasage"))
            '        txtPkgWast.Text = Fix(dr(0).Item("pwa_wasage"))
            '        txtBonQty.Text = txtPkgWast.Text
            '    End If

            'End If


            'txtPkgWastPer.Text = ""
            'txtPkgWast.Text = 0


            calTotalOrdQty()
            calTotalAMT()
        End If
    End Sub

    Private Sub txtBonQty_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBonQty.Validated
        txtBonQty.Text = Convert.ToInt32(txtBonQty.Text)
        update_PKREQDTL()
    End Sub

    Private Sub txtBonQty_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtBonQty.Validating
        If txtBonQty.Text = "" Then
            txtBonQty.Text = 0
            Exit Sub
        End If

        If IsNumeric(txtBonQty.Text) = False Then

            MsgBox("Please input valid integer")
            txtBonQty.Focus()
            e.Cancel = True
        End If
    End Sub

 
    Private Sub dgPKESHDR_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub
    Private Sub txtQuotePrice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub dgSummary_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub
    Private Sub dgSummary_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub
    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub Label97_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub txtTerms_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub Label70_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub txtItemNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub mmdRel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdRel.Click
        FrmPGM00003 = New PGM00003
        FrmPGM00003.txtFrom.Text = txtReqno.Text
        FrmPGM00003.txtTo.Text = txtReqno.Text
        FrmPGM00003.companycode = cbococde.Text
        FrmPGM00003.cboCoCde.Enabled = False

        FrmPGM00003.txtFrom.Enabled = False
        FrmPGM00003.txtTo.Enabled = False
        FrmPGM00003.optRel.Enabled = False
        FrmPGM00003.optUnr.Enabled = False

        If cboStatus.Text.Split(" -")(0) = "REL" Then
            FrmPGM00003.optUnr.Checked = True
        Else
            FrmPGM00003.optRel.Checked = True
        End If

        FrmPGM00003.ShowDialog()
    End Sub


    Private Sub mmdRel_EnabledChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdRel.EnabledChanged, mmdCancel.EnabledChanged
        mmdFunction.Enabled = mmdFunction_Right
        If mmdRel.Enabled = False And mmdCancel.Enabled = False Then
            mmdFunction.Enabled = False
        End If
    End Sub

    Private Sub mmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdPrint.Click
        FrmPGR00001 = New PGR00001
        FrmPGR00001.chkQutUpd.Checked = True
        FrmPGR00001.txt_S_PKGNo.Text = txtReqno.Text
        FrmPGR00001.txt_S_PriCustAll.Text = cboPriCust.Text.Split(" -")(0)

        FrmPGR00001.txt_S_PriCustAll.Enabled = False
        FrmPGR00001.txt_S_SecCustAll.Enabled = False
        FrmPGR00001.txt_S_PKGNo.Enabled = False
        FrmPGR00001.txt_S_PkItmNo.Enabled = False
        FrmPGR00001.txt_S_PV_PC.Enabled = False
        FrmPGR00001.txt_S_ItmNo.Enabled = False
        FrmPGR00001.txt_S_SKUNo.Enabled = False
        FrmPGR00001.txt_S_CusStyleNo.Enabled = False
        FrmPGR00001.txt_S_SCNo.Enabled = False
        FrmPGR00001.txt_S_TONo.Enabled = False

        FrmPGR00001.txtSCIssdatFm.Text = txtIssDate.Text
        FrmPGR00001.txtSCIssdatTo.Text = txtIssDate.Text

        FrmPGR00001.txtSCIssdatFm.Enabled = False
        FrmPGR00001.txtSCIssdatTo.Enabled = False


        FrmPGR00001.rdoQutUpd.Enabled = False
        FrmPGR00001.rdoQutNew.Enabled = False

        FrmPGR00001.cmd_S_CoCde.Enabled = False
        FrmPGR00001.cmd_S_PriCust.Enabled = False
        FrmPGR00001.cmd_S_SecCust.Enabled = False
        FrmPGR00001.cmd_S_PKGNo.Enabled = False
        FrmPGR00001.cmd_S_PkItmNo.Enabled = False
        FrmPGR00001.cmd_S_PV_PC.Enabled = False
        FrmPGR00001.cmd_S_ItmNo.Enabled = False
        FrmPGR00001.Button1.Enabled = False
        FrmPGR00001.Button2.Enabled = False
        FrmPGR00001.cmd_S_SCNo.Enabled = False
        FrmPGR00001.cmd_S_TONo.Enabled = False


        FrmPGR00001.ShowDialog()
    End Sub

    Private Sub CancelRequestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmdCancel.Click
        Select Case MsgBox("Are you sure to Cancel?", MsgBoxStyle.YesNo)
            Case MsgBoxResult.Yes
            Case MsgBoxResult.No
                Exit Sub

        End Select


        gspStr = "sp_update_PKREQHDR_CAN '" & cbococde.Text & "','" & txtReqno.Text & "','" & gsUsrID & "'"

        rtnLong = execute_SQLStatement(gspStr, rs, rtnStr)

        If rtnLong <> RC_SUCCESS Then
            MsgBox("Error on loading cmdCanOrd_Click sp_select_PKORDHDR_cancel :" & rtnStr)
            Exit Sub
        End If

        MsgBox("Record Saved")
        recordstatus = False
        mmdClear_Click(sender, e)

    End Sub

   
End Class
